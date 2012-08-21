using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Customer.Lead_Source
{
	class LeadSourceController : EntityBase
	{

		public DataTable GetCurrentLeadSources(int CustomerID)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT " +
					"    cl.*, " +
					"    l.`name` AS `lead_source`, " +
					"    d.`name` AS `department`, " +
					"    CONCAT(u.`first_name`, ' ', u.`last_name`) AS `adder` " +
					"FROM `rel_customer_leadsources` cl " + 
					"    JOIN ( " +
					"        SELECT " + 
					"            MAX(c.`activated`) AS `activated`, " +
					"            c.`department_id` " + 
					"        FROM `rel_customer_leadsources` c " +
					"        WHERE c.`customer_id` = " + CustomerID + " " +
					"        GROUP BY c.`department_id`) c2 ON cl.`department_id` = c2.`department_id` AND cl.`activated` = c2.`activated` " +
					"    JOIN `ref_lead_sources` l ON cl.`source_id` = l.`source_id` " +
					"    JOIN `ref_departments` d ON cl.`department_id` = d.`department_id` " +
					"    JOIN `users` u ON cl.`creator_id` = u.`user_id` " +
					"WHERE cl.`customer_id` = " + CustomerID + " AND cl.`source_id` <> 52 AND cl.`is_archived` = 0 " +
					"ORDER BY d.`name`;";
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

		public DataTable GetLeadSources(int CustomerID)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT " +
					"    cl.*, " +
					"    l.`name` AS `lead_source`, " +
					"    d.`name` AS `department`, " +
					"    CONCAT(u.`first_name`, ' ', u.`last_name`) AS `adder` " +
					"FROM `rel_customer_leadsources` cl " +
					"    JOIN `ref_lead_sources` l ON cl.`source_id` = l.`source_id` " +
					"    JOIN `ref_departments` d ON cl.`department_id` = d.`department_id` " +
					"    JOIN `users` u ON cl.`creator_id` = u.`user_id` " +
					"WHERE cl.`customer_id` = " + CustomerID + " AND cl.`source_id` <> 52 " +
					"ORDER BY d.`name`, cl.`activated` DESC;";
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

		public LeadSource GetLeadSource(int RelationID)
		{

			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `rel_customer_leadsources` l WHERE l.`relation_id` = " + RelationID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return new LeadSource(oTable.Rows[0]);
				else
					throw new Exception("The customer lead source either does not exist or there are more than one lead source with a relation id of " + RelationID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new LeadSource();
			}
		}

		public LeadSource InsertLeadSource(LeadSource newSource)
		{
			try
			{
				SQL = "INSERT INTO `rel_customer_leadsources` SET " +
					"	`customer_id` = " + newSource.CustomerID + ", " +
					"	`department_id` = " + newSource.DepartmentID + ", " +
					"	`source_id` = " + newSource.SourceID + ", " +
					"	`activated` = '" + newSource.Activated.ToString("yyyy/MM/dd HH:mm:ss") + "', " +
					"	`details` = " + (string.IsNullOrEmpty(newSource.Details) ? "NULL" : "'" + BuildSafeString(newSource.Details) + "'") + ", " +
					"	`created` = NOW(), " +
					"	`creator_id` = " + thisUser.ID + ", " +
					"	`updated` = NOW(), " +
					"	`updater_id` = " + thisUser.ID + " " +
					"ON DUPLICATE KEY UPDATE " +
					"	`source_id` = " + newSource.SourceID + ", " +
					"	`details` = " + (string.IsNullOrEmpty(newSource.Details) ? "NULL" : "'" + BuildSafeString(newSource.Details) + "'") + ", " +
					"	`updated` = NOW(), " +
					"	`updater_id` = " + thisUser.ID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save customer lead source for customer, " + newSource.CustomerID + ", and department, " + newSource.DepartmentID + ".");
				else
				{
					SQL = "SELECT MAX(l.`relation_id`) FROM `rel_customer_leadsources` l WHERE l.`customer_id` = " + newSource.CustomerID + ";";
					InitializeCommand();

					return GetLeadSource(Convert.ToInt32(Command.ExecuteScalar()));
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return newSource;
			}
		}

		public bool UpdateLeadSource(LeadSource theSource)
		{
			LeadSource orig = GetLeadSource(theSource.ID);

			try
			{
				SQL = "UPDATE `rel_customer_leadsources` cl SET ";

				if (orig.CustomerID != theSource.CustomerID)
					SQL += "cl.`customer_id` = " + theSource.CustomerID + ", ";

				if (orig.DepartmentID != theSource.DepartmentID)
					SQL += "cl.`department_id` = " + theSource.DepartmentID + ", ";

				if (orig.SourceID != theSource.SourceID)
					SQL += "cl.`source_id` = " + theSource.SourceID + ", ";

				if (orig.Activated != theSource.Activated)
					SQL += "cl.`activated` = '" + theSource.Activated.ToString("yyyy/MM/dd HH:mm:ss") + "', ";

				if (orig.Details != theSource.Details)
					SQL += string.IsNullOrEmpty(theSource.Details) ? "cl.`details` = NULL, " : "cl.`details` = '" + BuildSafeString(theSource.Details) + "', ";

				if (orig.IsArchived != theSource.IsArchived)
					SQL += "cl.`is_archived` = " + theSource.IsArchived + ", ";

				//Finish off the SQL statement
				SQL += "cl.`updated` = NOW(), cl.`updater_id` = " + thisUser.ID + " WHERE cl.`relation_id` = " + theSource.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The customer lead source with ID, " + theSource.ID + ", was not updated.");

				return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool HasLeadSource(int CustomerID, int DepartmentID)
		{
			bool result = false;

			try
			{
				SQL = "SELECT " +
					"    COUNT(cl.`relation_id`) " +
					"FROM `rel_customer_leadsources` cl " +
					"WHERE cl.`source_id` != 52 AND cl.`customer_id` = " + CustomerID + " AND cl.`department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				result = (Convert.ToInt32(Command.ExecuteScalar()) > 0);
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return result;
		}

		public LeadSource GetLatestLeadSource(int CustomerID, int DepartmentID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `rel_customer_leadsources` l " +
					"WHERE l.`customer_id` = " + CustomerID + " AND l.`department_id` = " + DepartmentID + " " +
					"ORDER BY l.`activated` DESC LIMIT 1;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return new LeadSource(oTable.Rows[0]);
				else
					return new LeadSource();
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new LeadSource();
			}
		}

	}
}
