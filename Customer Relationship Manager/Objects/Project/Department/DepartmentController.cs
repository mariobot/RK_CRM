using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Project.Department
{
	class DepartmentController : EntityBase
	{

		public Department GetDepartment(int ProjectID, int DepartmentID, int Scope)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT pd.*, CAST(pd.`status` AS DECIMAL) AS `status_id` " +
					"FROM `rel_project_department` pd WHERE pd.`project_id` = " + ProjectID + " AND pd.`department_id` = " + DepartmentID +
					" AND pd.`scope` = " + Scope + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new Department(oTable.Rows[0]);
				else
					throw new Exception("The department ID either doesn't exist or there are more than one departments with the ID of " + DepartmentID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new Department();
			}
		}

		public Department GetDepartmentWithLastestScope(int ProjectID, int DepartmentID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT pd.*, CAST(pd.`status` AS DECIMAL) AS `status_id` FROM `rel_project_department` pd WHERE pd.`project_id` = " + ProjectID + 
					" AND pd.`department_id` = " + DepartmentID + 
					" ORDER BY pd.`scope` DESC LIMIT 1;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new Department(oTable.Rows[0]);
				else
					return new Department();
			}
			catch (Exception e )
			{
				ErrorHandler.ProcessException(e, false);
				return new Department();
			}
		}

		public int GetNextScope(int ProjectID, int DepartmentID)
		{
			try
			{
				SQL = "SELECT IFNULL(MAX(pd.`scope`), 0) AS `max_scope` FROM `rel_project_department` pd WHERE pd.`project_id` = " + ProjectID + 
					" AND pd.`department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				return (Convert.ToInt32(Command.ExecuteScalar()) + 1);
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return 0;				
			}
		}

		public bool InsertDepartment(Department newProjectDepartment)
		{
			try
			{
				SQL = "INSERT INTO `rel_project_department` SET " +
					"`project_id` = " + newProjectDepartment.ProjectID + ", " +
					"`department_id` = " + newProjectDepartment.DepartmentID + ", " +
					"`scope` = " + newProjectDepartment.Scope + ", " +
					"`status` = " + (int)newProjectDepartment.Status + ", " +
					"`units` = " + newProjectDepartment.Units + ", " +
					"`probability` = " + newProjectDepartment.Probability + ", " +
					"`expected_ship` = " + (newProjectDepartment.ExpectedShip != DateTime.MinValue ? "'" + newProjectDepartment.ExpectedShip.ToString("yyyy/MM/dd") + "'" : "NULL") + ", " +
					"`created` = NOW(), " +
					"`creator_id` = " + thisUser.ID + ", " +
					"`updated` = NOW(), " +
					"`updater_id` = " + thisUser.ID + " " +
					"ON DUPLICATE KEY UPDATE " +
					"`status` = " + (int)newProjectDepartment.Status + ", " +
					"`units` = " + newProjectDepartment.Units + ", " +
					"`probability` = " + newProjectDepartment.Probability + ", " +
					"`expected_ship` = " + (newProjectDepartment.ExpectedShip != DateTime.MinValue ? "'" + newProjectDepartment.ExpectedShip.ToString("yyyy/MM/dd") + "'" : "NULL") + ", " +
					"`updated` = NOW(), `updater_id` = " + thisUser.ID + ";";
					
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save the project department relationship data for project " + newProjectDepartment.ProjectID + ", " +
					"department " + newProjectDepartment.DepartmentID + " and scope " + newProjectDepartment.Scope + ".");
				else
					return true;				
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool UpdateDepartment(Department ProjectDepartment)
		{
			Department orig = GetDepartment(ProjectDepartment.ProjectID, ProjectDepartment.DepartmentID, ProjectDepartment.Scope);

			try
			{
				SQL = "UPDATE `rel_project_department` pd SET ";

				if (orig.Status != ProjectDepartment.Status)
					SQL += "pd.`status` = " + (int)ProjectDepartment.Status + ", ";

				if (orig.Units != ProjectDepartment.Units)
					SQL += "pd.`units` = " + ProjectDepartment.Units + ", ";

				if (orig.Probability != ProjectDepartment.Probability)
					SQL += "pd.`probability` = " + ProjectDepartment.Probability + ", ";

				if (orig.ExpectedShip != ProjectDepartment.ExpectedShip)
					SQL += "pd.`expected_ ship` = " + (ProjectDepartment.ExpectedShip != DateTime.MinValue ? "'" + ProjectDepartment.ExpectedShip.ToString("yyyy/MM/dd") + "'" : "NULL") + ", ";

				//Finish off the SQL statement
				SQL += "pd.`updated` = NOW(), pd.`updater_id` = " + thisUser.ID + " WHERE pd.`project_id` = " + ProjectDepartment.ProjectID + 
					" AND pd.`department_id` = " + ProjectDepartment.DepartmentID + " AND pd.`scope` = " + ProjectDepartment.Scope + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to update the project department relationship data for project " + ProjectDepartment.ProjectID + ", " +
					"department " + ProjectDepartment.DepartmentID + " and scope " + ProjectDepartment.Scope + ".");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public DataTable GetSoldLostDepartments(int ProjectID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT pd.`department_id`, d.`name` " +
					"FROM `rel_project_department` pd " +
					"JOIN `ref_departments` d ON pd.`department_id` = d.`department_id` " +
					"WHERE pd.`status` <> 1 AND pd.`project_id` = " + ProjectID + ";";
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

		public DataTable GetOutstandingDepartments(int ProjectID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT " +
					"	pd.`department_id`, " +
					"	d.`name` " +
					"FROM `rel_project_department` pd " +
					"	JOIN `ref_departments` d ON pd.`department_id` = d.`department_id` " +
					"	LEFT JOIN `quotes` q ON q.`project_id` = pd.`project_id` AND q.`department_id` = pd.`department_id` AND q.`is_archived` = 0 " +
					"WHERE pd.`status` = 1 AND pd.`project_id` = " + ProjectID + " " +
					"GROUP BY pd.`project_id`, pd.`department_id` " +
					"HAVING COUNT(q.`quote_id`) > 0 " +
					"ORDER BY d.`name`, pd.`project_id`;";
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

		public DataTable GetOutstandingQuotes(int ProjectID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT q.`quote_id`, pd.`department_id`, d.`name` AS `department`, q.`name` AS `quote`, q.`amount`, q.`description`, " +
					"CONCAT(u.`first_name`, ' ', u.`last_name`) AS `sales_rep` " +
					"FROM `rel_project_department` pd " +
					"JOIN `ref_departments` d ON pd.`department_id` = d.`department_id` " +
					"JOIN `quotes` q ON pd.`project_id` = q.`project_id` AND pd.`department_id` = q.`department_id` " +
					"JOIN `users` u ON q.`sales_rep_id` = u.`user_id` " +
					"WHERE pd.`status` = 1 AND q.`is_archived` = 0 AND pd.`project_id` = " + ProjectID + ";";
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

		public bool UpdateStatus(Department ProjectDepartment, Project.ProjectStatus Status)
		{
			try
			{
				SQL = "UPDATE `rel_project_department` pd SET " +
					"pd.`status` = " + (int)Status + ", " +
					"pd.`updated` = NOW(), " +
					"pd.`updater_id` = " + thisUser.ID + " " +
					"WHERE pd.`project_id` = " + ProjectDepartment.ProjectID + " AND pd.`department_id` = " + ProjectDepartment.DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The project status was not updated.");
				else
					return true;

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool UpdateStatus(int ProjectID, int DepartmentID, Project.ProjectStatus Status)
		{
			try
			{
				SQL = "UPDATE `rel_project_department` pd SET " +
					"pd.`status` = " + (int)Status + ", " +
					"pd.`updated` = NOW(), " +
					"pd.`updater_id` = " + thisUser.ID + " " +
					"WHERE pd.`project_id` = " + ProjectID + " AND pd.`department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The project status was not updated.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool DeleteLostProjectReports(int ProjectID, int DepartmentID)
		{
			try
			{
				SQL = "DELETE FROM `lost_project_reports` WHERE `project_id` = " + ProjectID + " AND `department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Not all lost project reports were deleted for project, " + ProjectID + ", and department, " + DepartmentID + ".");
				else
					return true;

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool DeleteLostProjectReports(Department theProjectDepartment)
		{
			try
			{
				SQL = "DELETE FROM `lost_project_reports` WHERE `project_id` = " + theProjectDepartment.ProjectID + " AND `department_id` = " + theProjectDepartment.DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Not all lost project reports were deleted for project, " + theProjectDepartment.ProjectID + ", and department, " + theProjectDepartment.DepartmentID + ".");
				else
					return true;

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool ClearSoldMarkers(int ProjectID, int DepartmentID)
		{
			try
			{
				SQL = "UPDATE `quotes` q SET q.`is_sold` = 0, q.`updated` = NOW(), q.`updater_id` = " + thisUser.ID +
					" WHERE q.`project_id` = " + ProjectID + " AND q.`department_id` = " + DepartmentID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Not all sold markers were cleared for project, " + ProjectID + ", and department, " + DepartmentID + ".");
				else
					return true;

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public bool ClearSoldMarkers(Department theProjectDepartment)
		{
			try
			{
				SQL = "UPDATE `quotes` q SET q.`is_sold` = 0, q.`updated` = NOW(), q.`updater_id` = " + thisUser.ID +
					" WHERE q.`project_id` = " + theProjectDepartment.ProjectID + " AND q.`department_id` = " + theProjectDepartment.DepartmentID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Not all sold markers were cleared for project, " + theProjectDepartment.ProjectID + ", and department, " + theProjectDepartment.DepartmentID + ".");
				else
					return true;

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal void DeleteDepartment(int ProjectID, int DepartmentID)
		{
			try
			{
				SQL = "DELETE FROM `rel_project_department` WHERE `project_id` = " + ProjectID + " AND `department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The project department was not deleted.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

	}
}
