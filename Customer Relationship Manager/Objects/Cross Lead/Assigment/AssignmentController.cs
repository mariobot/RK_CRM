using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Cross_Lead.Assigment
{
	class AssignmentController : EntityBase
	{

		public Assignment GetAssignment(int LeadID, int DepartmentID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `rel_crosslead_department` cd WHERE cd.`lead_id` = " + LeadID + " AND cd.`department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new Assignment(oTable.Rows[0]);
				else
					throw new Exception("The assignment either doesn't exist or there is more than one assignment with a lead ID of " + LeadID + " and a department ID of " + DepartmentID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		internal DataTable GetUserAssignments(int UserID)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT cl.`lead_id`, cd.`assigned`, cl.`bid_due`, p.`name` AS `project`, cu.`name` AS `customer`,  " +
					"CONCAT(u.`first_name`, ' ', u.`last_name`) AS `sender`, IF(MIN(n1.`created`) IS NULL, 1, 2) AS `group` " +
					"FROM `cross_leads` cl " +
					"JOIN `rel_crosslead_department` cd ON cl.`lead_id` = cd.`lead_id` " +
					"JOIN `projects` p ON cl.`project_id` = p.`project_id` " +
					"JOIN `customers` cu ON p.`customer_id` = cu.`customer_id` " +
					"JOIN `users` u ON cl.`sender_id` = u.`user_id`" +
					"LEFT JOIN `notes` n1 ON p.`project_id` = n1.`project_id` AND cd.`department_id` = n1.`department_id` AND n1.`created` >= cl.`sent` AND n1.`is_archived` = 0 " +
					"LEFT JOIN `notes` n ON p.`project_id` = n.`project_id` AND cd.`department_id` = n.`department_id` AND n.`purpose_id` = 11 AND n.`created` >= cl.`sent` AND n.`is_archived` = 0 " +
					"LEFT JOIN `quotes` q ON p.`project_id` = q.`project_id` AND cd.`department_id` = q.`department_id` AND q.`created` >= cl.`sent` AND q.`is_archived` = 0 " +
					"WHERE n.`created` IS NULL AND q.`created` IS NULL AND cd.`owner_id` = " + UserID + " " +
					"GROUP BY cl.`lead_id` " +
					"ORDER BY `group`, cd.`assigned`, `project`, `customer`;";
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

		internal DataTable GetAssignments(string DepartmentID)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT cd.`owner_id`, cd.`assigned`, cd.`plans_received`, cd.`expected_completion`, cl.`sent` AS `Received`,  " +
					"cd.`department_id`, CONCAT(s.`first_name`, ' ', s.`last_name`) AS `Sender`, " +
					"IF(MIN(n.`created`) IS NULL || MIN(q.`created`) < MIN(n.`created`), MIN(q.`created`), MIN(n.`created`)) AS `First_Contact`, " +
					"IF(MIN(n1.`created`) IS NULL || MIN(q.`created`) < MIN(n1.`created`), MIN(q.`created`), MIN(n.`created`)) AS `Quote_Delivered`, " +
					"p.`customer_id`, p.`project_id`, cl.`lead_id` " +
					"FROM `cross_leads` cl " +
					"    JOIN `rel_crosslead_department` cd ON cl.`lead_id` = cd.`lead_id` " +
					"    JOIN `projects` p ON cl.`project_id` = p.`project_id` " +
					"    JOIN `ref_project_types` pt ON p.`type_id` = pt.`type_id` " +
					"    JOIN `users` s ON cl.`sender_id` = s.`user_id` " +
					"    LEFT JOIN `notes` n ON cl.`project_id` = n.`project_id` AND n.`department_id` = cd.`department_id` AND " +
					"        n.`created` >= cl.`sent` AND n.`is_archived` = 0 " +
					"    LEFT JOIN `notes` n1 ON cl.`project_id` = n1.`project_id` AND n1.`department_id` = cd.`department_id` AND " +
					"        n1.`created` >= cl.`sent` AND n.`is_archived` = 0 AND (n1.`purpose_id` = 11 OR n1.`purpose_id` = 14) " +
					"    LEFT JOIN `quotes` q ON cl.`project_id` = q.`project_id` AND q.`department_id` = cd.`department_id` AND " +
					"        q.`created` >= cl.`sent` AND q.`is_archived` = 0 " +
					"WHERE cd.`department_id` LIKE '" + DepartmentID + "' " +
					"GROUP BY cl.`project_id`, cd.`department_id` " +
					"ORDER BY `Received` DESC;";
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

		internal bool UpdateAssignment(Assignment theAssignment)
		{
			Assignment orig = GetAssignment(theAssignment.LeadID, theAssignment.DepartmentID);

			try
			{
				SQL = "UPDATE `rel_crosslead_department` cd SET ";

				if (orig.OwnerID != theAssignment.OwnerID)
					SQL += "cd.`owner_id` = " + theAssignment.OwnerID + ", ";
				if (orig.PlansReceived != theAssignment.PlansReceived)
					SQL += "cd.`plans_received` = " + (theAssignment.PlansReceived != DateTime.MinValue ? "'" + theAssignment.PlansReceived.ToString("yyyy/MM/dd") + "'" : "NULL") + ", ";
				if (orig.ExpectedCompletion != theAssignment.ExpectedCompletion)
					SQL += "cd.`expected_completion` = " + (theAssignment.ExpectedCompletion != DateTime.MinValue ? "'" + theAssignment.ExpectedCompletion.ToString("yyyy/MM/dd") + "'" : "NULL") + ", ";
				if (orig.Assigned != theAssignment.Assigned)
					SQL += "cd.`assigned` = " + (theAssignment.Assigned != DateTime.MinValue ? "'" + theAssignment.Assigned.ToString("yyyy/MM/dd") + "'" : "NULL") + ", ";
				if (orig.AssignerID != theAssignment.AssignerID)
					SQL += "cd.`assigner_id` = " + theAssignment.AssignerID + ", ";

				//Finish off the SQL statement
				SQL = SQL.Substring(0, SQL.Length - 2);
				SQL += " WHERE cd.`lead_id` = " + theAssignment.LeadID + " AND cd.`department_id` = " + theAssignment.DepartmentID + ";";
				
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The assignment with cross lead ID, " + theAssignment.LeadID + ", and department ID, " + theAssignment.DepartmentID + ", was not updated.");
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
