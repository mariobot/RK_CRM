using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Quote
{
	class QuoteController : EntityBase
	{

		public DataTable GetSearchResults(string ColumnName, string Criteria)
		{
			DataTable results = new DataTable();

			try
			{
				SQL = "SELECT q.*, p.`customer_id`, d.`name` AS `department`, pd.`status`, p.`name` AS `project`, " +
					"c.`name` AS `customer`, CONCAT(s.`first_name`, ' ', s.`last_name`) AS `sales_rep` " +
					"FROM `quotes` q " +
					"JOIN `projects` p ON q.`project_id` = p.`project_id` " +
					"JOIN `ref_departments` d ON q.`department_id` = d.`department_id` " +
					"LEFT JOIN `rel_project_department` pd ON q.`project_id` = pd.`project_id` AND q.`department_id` = pd.`department_id` " +
					"JOIN `customers` c ON p.`customer_id` = c.`customer_id` " +
					"JOIN `users` s ON q.`sales_rep_id` = s.`user_id` ";

				if (ColumnName == "`sales_rep`")
					SQL += "HAVING " + ColumnName + " LIKE '%" + Criteria + "%' ";
				else
					SQL += "WHERE " + ColumnName + " LIKE '%" + Criteria + "%' ";

				SQL += "ORDER BY " + ColumnName + ", p.`name`, c.`name`;";

				InitializeCommand();
				OpenConnection();

				FillDataTable(results);

				return results;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public Quote GetQuote(int QuoteID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `quotes` q WHERE q.`quote_id` = " + QuoteID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new Quote(oTable.Rows[0]);
				else
					throw new Exception("The quote either doesn't exist or there are more than one quotes with the ID of " + QuoteID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new Quote();
			}
		}

		public DataTable GetQuotes(int ProjectID, bool ShowArchived)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT d.`name` AS `department`, CONCAT(r.`first_name`, ' ', r.`last_name`) AS `rep`, " +
					"CONCAT(s.`first_name`, ' ', s.`last_name`) AS `support`, cm.`name` AS `method`, " +
					"CONCAT(c.`first_name`, ' ', c.`last_name`) AS `contact`, pd.`status`, pd.`probability`, q.* " +
					"FROM `quotes` q " +
					"JOIN `ref_departments` d ON q.`department_id` = d.`department_id` " +
					"LEFT JOIN `rel_project_department` pd ON q.`project_id` = pd.`project_id` AND q.`department_id` = pd.`department_id` AND q.`scope` = pd.`scope` " +
					"LEFT JOIN `users` r ON q.`sales_rep_id` = r.`user_id` " +
					"LEFT JOIN `users` s ON q.`sales_rep_id` = s.`user_id` " +
					"LEFT JOIN `ref_contact_methods` cm ON q.`method_id` = cm.`method_id` " +
					"LEFT JOIN `contacts` c ON q.`contact_id` = c.`contact_id` " +
					"WHERE q.`project_id` = " + ProjectID;

				if (ShowArchived)
					SQL += " ORDER BY `department`, `rep`;";
				else
					SQL += " AND q.`is_archived` = 0 ORDER BY `department`, `rep`;";
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

		internal bool UpdateQuote(Quote theQuote)
		{
			Quote orig = GetQuote(theQuote.ID);

			try
			{
				SQL = "UPDATE `quotes` q SET ";

				if (orig.ProjectID != theQuote.ProjectID)
					SQL += "q.`project_id` = " + theQuote.ProjectID + ", ";
				if (orig.Description != theQuote.Description)
					SQL += "q.`description` = '" + BuildSafeString(theQuote.Description) + "', ";
				if (orig.SalesRepID != theQuote.SalesRepID)
					SQL += "q.`sales_rep_id` = " + theQuote.SalesRepID + ", ";
				if (orig.SalesSupportID != theQuote.SalesSupportID)
					SQL += "q.`support_id` = " + theQuote.SalesSupportID + ", ";
				if (orig.DepartmentID != theQuote.DepartmentID)
					SQL += "q.`department_id` = " + theQuote.DepartmentID + ", ";
				if (orig.MethodID != theQuote.MethodID)
					SQL += "q.`method_id` = " + theQuote.MethodID + ", ";
				if (orig.Name != theQuote.Name)
					SQL += "q.`name` = " + BuildSafeString(theQuote.Name) + ", ";
				if (orig.ContactID != theQuote.ContactID)
					SQL += "q.`contact_id` = " + theQuote.ContactID + ", ";
				if (orig.Amount != theQuote.Amount)
					SQL += "q.`amount` = " + theQuote.Amount + ", ";
				if (orig.IsArchived != theQuote.IsArchived)
					SQL += "q.`is_archived` = " + theQuote.IsArchived + ", ";

				//Finish off the SQL statement
				SQL += "q.`updated` = NOW(), q.`updater_id` = " + thisUser.ID + " WHERE q.`quote_id` = " + theQuote.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The quote with ID, " + theQuote.ID + ", was not updated.");
				else
					return true;

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal Quote InsertQuote(Quote newQuote)
		{
			try
			{
				SQL = "INSERT INTO `quotes` SET " +
					"`project_id` = " + newQuote.ProjectID + ", " +
					"`department_id`  = " + newQuote.DepartmentID + ", " +
					"`scope`  = " + newQuote.Scope + ", " +
					"`name`  = '" + BuildSafeString(newQuote.Name) + "', " +
					"`amount`  = " + newQuote.Amount.ToString() + ", " +
					"`description`  = '" + BuildSafeString(newQuote.Description) + "', " +
					"`sales_rep_id`  = " + newQuote.SalesRepID + ", " +
					"`support_id`  = " + newQuote.SalesSupportID + ", " +
					"`method_id`  = " + newQuote.MethodID + ", " +
					"`contact_id`  = " + newQuote.ContactID + ", " +
					"`created` = NOW(), " +
					"`creator_id` = " + thisUser.ID + ", " +
					"`updated` = NOW(), " +
					"`updater_id` = " + thisUser.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save the quote for project " + newQuote.ProjectID + ".");
				else
				{
					SQL = "SELECT MAX(q.`quote_id`) FROM `quotes` q WHERE q.`project_id` = " + newQuote.ProjectID + ";";
					InitializeCommand();

					return GetQuote(Convert.ToInt32(Command.ExecuteScalar()));
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return newQuote;
			}
		}

		public bool MarkAsSold(int QuoteID)
		{
			try
			{
				SQL = "UPDATE `quotes` q SET q.`is_sold` = 1, q.`updated` = NOW(), q.`updater_id` = " + thisUser.ID + " WHERE q.`quote_id` = " + QuoteID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The quote with ID, " + QuoteID + ", was not updated.");
				else
					return true;

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool MarkAsSold(Quote theQuote)
		{
			try
			{
				SQL = "UPDATE `quotes` q SET q.`is_sold` = 1, q.`updated` = NOW(), q.`updater_id` = " + thisUser.ID + " WHERE q.`quote_id` = " + theQuote.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The quote with ID, " + theQuote.ID + ", was not updated.");
				else
					return true;

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal void ArchiveAllQuotes(int ProjectID)
		{
			try
			{
				SQL = "UPDATE `quotes` q SET " +
					"q.`is_archived` = 1, " +
					"q.`updated` = NOW(), " +
					"q.`updater_id` = " + thisUser.ID + " " +
					"WHERE q.`is_archived` = 0 AND q.`project_id` = " + ProjectID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The quotes with project ID, " + ProjectID + ", were not archived.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		internal void RestoreAllQuotes(int ProjectID)
		{
			try
			{
				SQL = "UPDATE `quotes` q SET " +
					"q.`is_archived` = 0, " +
					"q.`updated` = NOW(), " +
					"q.`updater_id` = " + thisUser.ID + " " +
					"WHERE q.`project_id` = " + ProjectID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The quotes with ID, " + ProjectID + ", were not archived.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		internal void RestoreAllQuotes(int ProjectID, DateTime Archived)
		{
			try
			{
				SQL = "UPDATE `quotes` q SET " +
					"q.`is_archived` = 0, " +
					"q.`updated` = NOW(), " +
					"q.`updater_id` = " + thisUser.ID + " " +
					"WHERE q.`project_id` = " + ProjectID + " AND q.`updated` >= '" + Archived.ToString("yyyy/MM/dd HH:mm:ss") + "';";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The quotes with ID, " + ProjectID + ", were not archived.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		internal Quote GetLatestQuote(int ProjectID, int DepartmentID)
		{
			Quote result = null;

			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `quotes` q " +
					"WHERE q.`project_id` = " + ProjectID + " AND q.`department_id` = " + DepartmentID + " " +
					"ORDER BY q.`updated` DESC LIMIT 1;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					result = new Quote(oTable.Rows[0]);
				else
					throw new Exception("There is no quote in project " + ProjectID + " for department " + DepartmentID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return result;
		}

		internal int GetQuoteCount(int ProjectID, int DepartmentID)
		{
			int result = -1;

			try
			{
				SQL = "SELECT COUNT(q.`quote_id`) FROM `quotes` q WHERE q.`is_archived` = 0 AND q.`project_id` = " + ProjectID + 
					" AND q.`department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				result = Convert.ToInt32(Command.ExecuteScalar());
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return result;
		}

	}
}
