using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;
using System.Collections.Generic;

namespace rkcrm.Objects.Phone_Number
{
	/// <summary>
	/// Contains methods to retrieve and manipulate phone number data
	/// </summary>
	class PhoneNumberController : EntityBase
	{

		#region Methods

		/// <summary>
		/// Gets a rkcrm.Objects.Phone_Number.PhoneNumber based on the ID provided
		/// </summary>
		/// <param name="PhoneNumberID"></param>
		/// <returns></returns>
		public PhoneNumber GetPhoneNumber(int PhoneNumberID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `phone_numbers` p WHERE p.`phone_number_id` = " + PhoneNumberID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new PhoneNumber(oTable.Rows[0]);
				else
					throw new Exception("The phone number ID either doesn't exist or there are more than one phone numbers with the ID of " + PhoneNumberID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		/// <summary>
		/// Gets a rkcrm.Objects.Phone_Number.PhoneNumber based on the phone number provided
		/// </summary>
		/// <param name="PhoneNumberID"></param>
		/// <returns></returns>
		internal PhoneNumber GetPhoneNumber(string PhoneNumber)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `phone_numbers` p WHERE p.`phone_number` = '" + PhoneNumber + "';";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new PhoneNumber(oTable.Rows[0]);
				else
				{
					PhoneNumber newPhone = new PhoneNumber();
					newPhone.Number = PhoneNumber;

					return newPhone;
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new PhoneNumber();
			}
		}

		/// <summary>
		/// Returns a value that determines whether the phone exists in the database
		/// </summary>
		/// <param name="PhoneNumber"></param>
		/// <returns></returns>
		public bool DoesExist(string PhoneNumber)
		{
			//bool exists = false;
			int count = 0;

			try
			{
				SQL = "SELECT COUNT(p.`phone_number`) FROM `phone_numbers` p WHERE p.`phone_number` = " + PhoneNumber + ";";
				InitializeCommand();
				OpenConnection();

				count = Convert.ToInt32(Command.ExecuteScalar());

				return (count > 0);

				//MySql.Data.MySqlClient.MySqlDataReader Reader;

				//SQL = "SELECT p.`phone_number` FROM `phone_numbers` p WHERE p.`phone_number` = " + PhoneNumber + ";";
				//InitializeCommand();
				//OpenConnection();

				//Reader = Command.ExecuteReader();
				//exists = Reader.HasRows;

				//Reader.Close();
				//Reader.Dispose();
				//Reader = null;
				//Command.Dispose();
				//Command = null;

				//return exists;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		/// <summary>
		/// Returns a value that determines whether the phone number is being used by any one other that the customer other than the customer id provided
		/// </summary>
		/// <param name="PhoneNumber"></param>
		/// <param name="CustomerID"></param>
		/// <returns></returns>
		public bool IsInUse(string PhoneNumber, int CustomerID)
		{
			try
			{
				MySql.Data.MySqlClient.MySqlDataReader Reader;
				bool inUse = false;

				SQL = "SELECT p.`phone_number` " +
					"FROM `phone_numbers` p " +
					"LEFT JOIN `link_customer_phonenumbers` cup ON p.`phone_number_id` = cup.`phone_number_id` AND NOT cup.`customer_id` = " + CustomerID +
					" LEFT JOIN `link_contact_phonenumbers` cop ON p.`phone_number_id` = cop.`phone_number_id` " +
					"JOIN `contacts` co ON cop.`contact_id` = co.`contact_id` AND NOT co.`customer_id` = " + CustomerID +
					" WHERE p.`phone_number` = '" + PhoneNumber + "';";
				InitializeCommand();
				OpenConnection();

				Reader = Command.ExecuteReader();

				inUse = Reader.HasRows;

				Reader.Close();
				Reader.Dispose();
				Reader = null;
				Command.Dispose();
				Command = null;

				return inUse;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		/// <summary>
		/// Links the phone number to the customer
		/// </summary>
		/// <param name="PhoneNumber"></param>
		/// <param name="CustomerID"></param>
		public void LinkCustomer(string PhoneNumber, int CustomerID)
		{
			try
			{
				SQL = "INSERT INTO `link_customer_phonenumbers` (`customer_id`, `phone_number_id`) " +
					"VALUES (" + CustomerID + ", (SELECT p.`phone_number_id` FROM `phone_numbers` p WHERE p.`phone_number` = '" + PhoneNumber + "'));";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The customer with ID, " + CustomerID + ", was not linked with phone number, " + PhoneNumber + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		/// <summary>
		/// Links the phone number to the customer
		/// </summary>
		/// <param name="PhoneNumberID"></param>
		/// <param name="CustomerID"></param>
		public void LinkCustomer(int PhoneNumberID, int CustomerID)
		{
			try
			{
				SQL = "INSERT INTO `link_customer_phonenumbers` (`customer_id`, `phone_number_id`) " +
					"VALUES (" + CustomerID + ", " + PhoneNumberID + ");";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The customer with ID, " + CustomerID + ", was not linked with phone number ID, " + PhoneNumberID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		public void LinkContact(rkcrm.Objects.Contact.Phone_Number.PhoneNumber thePhoneNumber, int ContactID)
		{
			try
			{
				SQL = "INSERT INTO `link_contact_phonenumbers` SET " +
					"`contact_id` = " + ContactID + ", " +
					"`phone_number_id` = " + thePhoneNumber.ID + ", " +
					"`extension` = '" + BuildSafeString(thePhoneNumber.Extension) + "', " +
					"`is_preferred` = " + thePhoneNumber.IsPerferred + " " +
					"ON DUPLICATE KEY UPDATE " +
					"`extension` = '" + BuildSafeString(thePhoneNumber.Extension) + "', " +
					"`is_preferred` = " + thePhoneNumber.IsPerferred + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The contact with ID, " + ContactID + ", was not linked with phone number ID, " + thePhoneNumber.ID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		/// <summary>
		/// Removes the link between customer and phone number
		/// </summary>
		/// <param name="PhoneNumber"></param>
		/// <param name="CustomerID"></param>
		public void RemoveCustomerLink(string PhoneNumber, int CustomerID)
		{
			try
			{
				SQL = "DELETE FROM `link_customer_phonenumbers` WHERE `customer_id` = " + CustomerID + " AND `phone_number_id` = (SELECT p.`phone_number_id` FROM `phone_numbers` p WHERE p.`phone_number` = " + PhoneNumber + ");";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The link between customer, " + CustomerID + ", and phone number, " + PhoneNumber + ", was not deleted.");

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		/// <summary>
		/// Removes the link between customer and phone number
		/// </summary>
		/// <param name="PhoneNumberID"></param>
		/// <param name="CustomerID"></param>
		public void RemoveCustomerLink(int PhoneNumberID, int CustomerID)
		{
			try
			{
				SQL = "DELETE FROM `link_customer_phonenumbers` WHERE `customer_id` = " + CustomerID + " AND `phone_number_id` = " + PhoneNumberID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The link between customer, " + CustomerID + ", and phone number, " + PhoneNumberID + ", was not deleted.");

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		/// <summary>
		/// Removes all links between the customer and a phone number
		/// </summary>
		/// <param name="CustomerID"></param>
		public void RemoveAllCustomerLinks(int CustomerID)
		{
			try
			{
				SQL = "DELETE FROM `link_customer_phonenumbers` WHERE `customer_id` = " + CustomerID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The phone number links for customer, " + CustomerID + ", were not deleted.");

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		public bool RemoveAllContactLinks(int ContactID)
		{
			try
			{
				SQL = "DELETE FROM `link_contact_phonenumbers` WHERE `contact_id` = " + ContactID + ";";
				InitializeCommand();
				OpenConnection();

				ExecuteStoredProcedure();

				return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool RemoveUnusedLinks(rkcrm.Objects.Contact.Contact theContact)
		{
			try
			{
				SQL = "DELETE FROM `link_contact_phonenumbers` WHERE `contact_id` = " + theContact.ID + " AND `phone_number_id` NOT IN (";

				int index = 0;

				while (index < theContact.MyPhoneNumbers.Count)
				{
					if (index > 0)
						SQL += ", ";

					SQL += theContact.MyPhoneNumbers[index].ID;
					
					index++;
				}
				SQL += ");";
				InitializeCommand();
				OpenConnection();

				ExecuteStoredProcedure();

				return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public void RemoveContactLink(PhoneNumber thePhoneNumber, int ContactID)
		{
			try
			{
				SQL = "DELETE FROM `link_contact_phonenumbers` WHERE `contact_id` = " + ContactID + " AND `phone_number_id` = " + thePhoneNumber.ID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The link between contact, " + ContactID + ", and phone number, " + thePhoneNumber.Number + ", was not deleted.");

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		/// <summary>
		/// Update the phone number with the data in the phone number provided
		/// </summary>
		/// <param name="thePhoneNumber"></param>
		/// <returns></returns>
		public bool UpdatePhoneNumber(PhoneNumber thePhoneNumber)
		{
			try
			{
				PhoneNumber origNumber = GetPhoneNumber(thePhoneNumber.ID);

				SQL = "UPDATE `phone_numbers` p SET ";

				if (origNumber.Number != thePhoneNumber.Number)
					SQL += "p.`phone_number` = '" + thePhoneNumber.Number + "', ";

				if (origNumber.TypeID != thePhoneNumber.TypeID && thePhoneNumber.TypeID > 0)
					SQL += "p.`type_id` = " + thePhoneNumber.TypeID + ", ";

				//Finish off the SQL statement and send it to the server
				SQL += "p.`updated` = NOW(), p.`updater_id` = " + thisUser.ID + " WHERE p.`phone_number_id` = " + origNumber.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The phone number with ID, " + origNumber.ID + ", was not updated.");

				return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}

		}

		/// <summary>
		/// Inserts the phone number into the database
		/// </summary>
		/// <param name="thePhoneNumber"></param>
		/// <returns></returns>
		public PhoneNumber InsertPhoneNumber(PhoneNumber thePhoneNumber)
		{
			try
			{
				SQL = "INSERT IGNORE INTO `phone_numbers` (`phone_number`, `type_id`, `created` ,`creator_id`, `updated`, `updater_id`) " +
					"VALUES ('" + thePhoneNumber.Number + "', " + (thePhoneNumber.TypeID == 0 ? "NULL" : thePhoneNumber.TypeID.ToString()) + 
					", NOW(), " + thisUser.ID + ", NOW(), " + thisUser.ID + ");";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
				{
					PhoneNumber otherPhone = GetPhoneNumber(thePhoneNumber.Number);

					if (otherPhone.ID == 0)
						throw new Exception("The phone number, " + thePhoneNumber.Number + ", was not added to the database.");
					else
						return otherPhone;
				}
				else
				{
					SQL = "SELECT MAX(p.`phone_number_id`) FROM `phone_numbers` p;";
					InitializeCommand();

					return GetPhoneNumber(Convert.ToInt32(Command.ExecuteScalar()));
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return thePhoneNumber;
			}
		}

		public bool DeletePhoneNumber(PhoneNumber thePhoneNumber)
		{
			try
			{
				SQL = "DELETE FROM `phone_numbers` WHERE `phone_number` = '" + thePhoneNumber.Number + "';";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The phone number, " + thePhoneNumber.Number + ", was not deleted from the database.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		/// <summary>
		/// Gets a System.Data.DataTable object of the customer and contact names who are using the phone number provided
		/// </summary>
		/// <param name="thePhoneNumber"></param>
		/// <param name="CustomerID"></param>
		/// <returns></returns>
		public DataTable GetOtherOwners(string thePhoneNumber, int CustomerID)
		{
			DataTable oTable = new DataTable();

			try
			{

				SQL = "SELECT co.`customer_id`, c.`name`, CONCAT(co.`first_name`, ' ', co.`last_name`) AS `contact` " +
					"FROM `phone_numbers` p " +
					"LEFT JOIN `link_contact_phonenumbers` cop ON p.`phone_number_id` = cop.`phone_number_id` " +
					"JOIN `contacts` co ON cop.`contact_id` = co.`contact_id` AND NOT co.`customer_id` = " + CustomerID +
					" JOIN `customers` c ON co.`customer_id` = c.`customer_id` " +
					"WHERE p.`phone_number` = '" + thePhoneNumber + "' " +
					"UNION " +
					"SELECT c.`customer_id`, c.`name`, NULL " +
					"FROM `phone_numbers` p " +
					"LEFT JOIN `link_customer_phonenumbers` cup ON p.`phone_number_id` = cup.`phone_number_id` AND NOT cup.`customer_id` = " + CustomerID +
					" JOIN `customers` c ON cup.`customer_id` = c.`customer_id` " +
					"WHERE p.`phone_number` = '" + thePhoneNumber + "' " +
					"ORDER BY `name`, `contact`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return oTable;
		}

		/// <summary>
		/// Determines whether the phone number is used by others excluding the given customer or contact
		/// </summary>
		/// <param name="thePhoneNumber"></param>
		/// <returns></returns>
		public bool IsPhoneNumberShared(string thePhoneNumber, int CustomerID, int ContactID)
		{
			try
			{
				int count; 

				SQL = "SELECT (SELECT COUNT(cup.`customer_id`) " +
					"FROM `phone_numbers` p " +
					"JOIN `link_customer_phonenumbers` cup ON p.`phone_number_id` = cup.`phone_number_id` " +
					"WHERE p.`phone_number` = '" + thePhoneNumber + "' AND cup.`customer_id` <> " + CustomerID + ") " +
					"+ " +
					"(SELECT COUNT(cop.`contact_id`) " +
					"FROM `phone_numbers` p " +
					"JOIN `link_contact_phonenumbers` cop ON p.`phone_number_id` = cop.`phone_number_id` " +
					"WHERE p.`phone_number` = '" + thePhoneNumber + "' AND cop.`contact_id` <> " + ContactID + ") AS `total`;";
				InitializeCommand();
				OpenConnection();

				count = Convert.ToInt32(Command.ExecuteScalar());

				return count > 0;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool IsPhoneNumberShared(string thePhoneNumber)
		{
			return IsPhoneNumberShared(thePhoneNumber, 0, 0);
		}
		
		public bool IsPhoneNumberShared(string thePhoneNumber, int ID, bool IsContactID)
		{
			if (IsContactID)
				return IsPhoneNumberShared(thePhoneNumber, 0, ID);
			else
				return IsPhoneNumberShared(thePhoneNumber, ID, 0);
		}

		#endregion

	}
}
