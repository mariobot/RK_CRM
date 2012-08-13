using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Contact
{
	class ContactController : EntityBase
	{

		public Contact GetContact(int ContactID)
		{
			try
			{
				DataSet oSet = new DataSet();

				SQL = "SELECT * FROM `contacts` c WHERE c.`contact_id` = " + ContactID + "; " +
					"SELECT cp.`contact_id`, p.*, cp.`extension`, cp.`is_preferred` " +
					"FROM `phone_numbers` p JOIN `link_contact_phonenumbers` cp ON p.`phone_number_id` = cp.`phone_number_id` " +
					"WHERE cp.`contact_id` = " + ContactID + " ORDER BY p.`phone_number_id`; " +
					"SELECT d.`department_id` FROM `rel_contact_department` d WHERE d.`contact_id` = " + ContactID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataSet(oSet);

				if (oSet.Tables[0].Rows.Count == 1)
					return new Contact(oSet);
				else 
					throw new Exception("The contact either does not exist or there is more than one contact with the ID of " + ContactID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new Contact();
			}
		}

		public DataTable GetContacts(int CustomerID, bool showArchived)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT co.`contact_id`, CONCAT(co.`first_name`, ' ', co.`last_name`) AS `contact`, co.`email_address`, p.`phone_number`, co.`is_archived` " +
					"FROM `contacts` co " +
					"LEFT JOIN `link_contact_phonenumbers` cop ON cop.`contact_id` = co.`contact_id` " +
					"JOIN `phone_numbers` p ON cop.`phone_number_id` = p.`phone_number_id` " +
					"WHERE " + (showArchived ? string.Empty : "co.`is_archived` = 0 AND ") + "co.`customer_id` = " + CustomerID + " ORDER BY `contact`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				return oTable;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new DataTable();
			}
		}

		public Contact InsertContact(Contact newContact)
		{
			try
			{
				SQL = "INSERT INTO `contacts` SET " +
					"`customer_id` = " + newContact.CustomerID + ", " +
					"`first_name` = '" + BuildSafeString(newContact.FirstName) + "', " +
					"`last_name` = '" + BuildSafeString(newContact.LastName) + "', " +
					"`email_address` = '" + BuildSafeString(newContact.Email) + "', " +
					"`title_id` = " + (newContact.TitleID == 0 ? "NULL" : newContact.TitleID.ToString()) + ", " +
					"`is_subscriber` = " + newContact.IsSubscriber + ", " +
					"`created` = NOW(), " +
					"`creator_id` = " + thisUser.ID + ", " +
					"`updated` = NOW(), " +
					"`updater_id` = " + thisUser.ID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save the contact for customer, " + newContact.CustomerID + ".");
				else
				{
					int newID;

					SQL = "SELECT MAX(c.`contact_id`) FROM `contacts` c WHERE c.`customer_id` = " + newContact.CustomerID + ";";
					InitializeCommand();

					newID = Convert.ToInt32(Command.ExecuteScalar());

					return GetContact(newID);
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return newContact;
			}
		}

		public bool UpdateContact(Contact theContact)
		{
			try
			{
				Contact orig = GetContact(theContact.ID);

				SQL = "UPDATE `contacts` c SET ";

				if(orig.CustomerID != theContact.CustomerID)
					SQL += "c.`customer_id` = " + theContact.CustomerID + ", ";

				if (orig.FirstName != theContact.FirstName)
					SQL += string.IsNullOrEmpty(theContact.FirstName) ? "c.`first_name` = NULL, " : "c.`first_name` = '" + BuildSafeString(theContact.FirstName) + "', ";

				if (orig.LastName != theContact.LastName)
					SQL += string.IsNullOrEmpty(theContact.LastName) ? "c.`last_name` = NULL, " : "c.`last_name` = '" + BuildSafeString(theContact.LastName) + "', ";

				if (orig.Email != theContact.Email)
					SQL += string.IsNullOrEmpty(theContact.Email) ? "c.`email_address` = NULL, " : " c.`email_address` = '" + BuildSafeString(theContact.Email) + "', ";

				if (orig.TitleID != theContact.TitleID)
					SQL += (theContact.TitleID == 0 ? "c.`title_id` = NULL, " : "c.`title_id` = " + theContact.TitleID + ", ");

				if (orig.IsSubscriber != theContact.IsSubscriber)
					SQL += "c.`is_subscriber` = " + theContact.IsSubscriber + ", ";

				if (orig.IsArchived != theContact.IsArchived)
					SQL += "c.`is_archived` = " + theContact.IsArchived + ", ";

				//Finish off the SQL statement
				SQL += "c.`updated` = NOW(), c.`updater_id` = " + thisUser.ID + " WHERE c.`contact_id` = " + theContact.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The contact with ID, " + theContact.ID + ", was not updated.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

	}
}
