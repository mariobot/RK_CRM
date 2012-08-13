using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Project
{
    class ProjectController : EntityBase
    {

		/// <summary>
		/// Gets a list of projects based on the criteria provided
		/// </summary>
		/// <param name="ColumnName"></param>
		/// <param name="Criteria"></param>
		/// <returns></returns>
        public DataTable GetSearchResults(string ColumnName, string Criteria)
        {
            DataTable results = new DataTable();
            string Select;
            string Condition = string.Empty;
			string OrderBy = string.Empty;

            Select = "SELECT p.`project_id`, p.`customer_id`, p.`name` AS `project`, c.`name` AS `customer`, pt.`name` AS `type`, p.`address`, p.`city`, " +
                "CONCAT(co.`first_name`, ' ', co.`last_name`) AS `contact_name`, p.`is_archived` " +
                "FROM `projects` p " +
                "JOIN `customers` c ON p.`customer_id` = c.`customer_id` " +
                "JOIN `ref_project_types` pt ON p.`type_id` = pt.`type_id` " +
                "JOIN `contacts` co ON p.`contact_id` = co.`contact_id` ";

			switch (ColumnName)
			{
				case "`contact_name`":
					Condition = "HAVING " + ColumnName + " LIKE '%" + Criteria + "%' ";
					OrderBy = "ORDER BY " + ColumnName; 
					break;
				case "view_all":
					break;
				default:
					Condition = "WHERE " + ColumnName + " LIKE '%" + Criteria + "%' ";
					OrderBy = "ORDER BY " + ColumnName;
					break;
			}

            try
            {
                SQL = Select + Condition + OrderBy + ";";
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

		/// <summary>
		/// Gets a list of notes and quotes for the selected project
		/// </summary>
		/// <param name="ProjectID"></param>
		/// <returns></returns>
		public DataSet GetSearchPreview(int ProjectID, bool showAll)
		{
			string where;
			DataSet results = new DataSet();

			try
			{
				if (showAll)
					where = "WHERE t.`project_id` = " + ProjectID + " ";
				else
					where = "WHERE t.`is_archived` = 0 AND t.`project_id` = " + ProjectID + " ";

				SQL = "SELECT t.*, p.`customer_id`, cp.`name` AS `purpose`, cm.`name` AS `method`, " +
					"CONCAT(c.`first_name`, ' ', c.`last_name`) AS `contact_name`, CONCAT(s.`first_name`, ' ', s.`last_name`) AS `sales_rep` " +
					"FROM `notes` t " +
					"JOIN `projects` p ON t.`project_id` = p.`project_id` " +
					"JOIN `ref_contact_purposes` cp ON t.`purpose_id` = cp.`purpose_id` " +
					"LEFT JOIN `contacts` c ON t.`contact_id` = c.`contact_id` " +
					"JOIN `users` s ON t.`sales_rep_id` = s.`user_id` " +
					"JOIN `ref_contact_methods` cm ON t.`method_id` = cm.`method_id` " + where +
					"ORDER BY t.`created` DESC;";

				SQL += "SELECT t.*, p.`customer_id`, d.`name` AS `department`, CONCAT(s.`first_name`, ' ', s.`last_name`) AS `sales_rep`, pd.`status` " +
					"FROM `quotes` t " +
					"JOIN `projects` p ON t.`project_id` = p.`project_id` " +
					"JOIN `ref_departments` d ON t.`department_id` = d.`department_id` " +
					"JOIN `users` s ON t.`sales_rep_id` = s.`user_id` " +
					"LEFT JOIN `rel_project_department` pd ON t.`department_id` = pd.`department_id` AND t.`project_id` = pd.`project_id` " + where +
					"ORDER BY t.`created` DESC;";

				InitializeCommand();
				OpenConnection();

				FillDataSet(results);

				return results;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public Project GetProject(int ProjectID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT p.*, lp.`link_id` FROM `projects` p " +
					"LEFT JOIN `link_project_project` lp ON p.`project_id` = lp.`project_id` " +
					"WHERE p.`project_id` = " + ProjectID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new Project(oTable.Rows[0]);
				else
					throw new Exception("The project either doesn't exist or there are more than one projects with the ID of " + ProjectID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new Project();
			}
		}

		public DataTable GetProjects(int CustomerID)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT p.`project_id`, p.`name`, p.`address`, p.`city`, pt.`name` AS `type`, p.`is_archived` " +
					  "FROM `projects` p LEFT JOIN `ref_project_types` pt ON p.`type_id` = pt.`type_id` ";

				if (thisUser.Role.ID == 1)
					SQL += "WHERE p.`customer_id` = " + CustomerID + "; ";
				else
					SQL += "WHERE p.`is_archived` = 0 AND p.`customer_id` = " + CustomerID + "; ";
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

		public DataTable GetLinkedProjects(Project theProject)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT lp.*, c.`name` AS `customer`, CONCAT(sr.`first_name`, ' ', sr.`last_name`) AS `sales_rep` " +
					"FROM `link_project_project` lp " +
					"JOIN `projects` p ON lp.`project_id` = p.`project_id` " +
					"JOIN `customers` c ON p.`customer_id` = c.`customer_id` " +
					"JOIN `users` sr ON p.`creator_id` = sr.`user_id` " +
					"WHERE p.`is_archived` = 0 AND lp.`project_id` <> " + theProject.ID + " AND lp.`link_id` = " + theProject.LinkID + ";";
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

		public Project.ProjectStatus GetStatus(int ProjectID, int DepartmentID)
		{
			try
			{
				SQL = "SELECT " +
					"	IF(COUNT(q.`quote_id`) = 0, 0, CAST(pd.`status` AS DECIMAL)) AS `status_id` " +
					"FROM `rel_project_department` pd " +
					"	LEFT JOIN `quotes` q ON q.`project_id` = pd.`project_id` AND q.`department_id` = pd.`department_id` AND q.`is_archived` = 0 " +
					"WHERE pd.`project_id` = " + ProjectID + " AND pd.`department_id` = " + DepartmentID + " " +
					"GROUP BY pd.`project_id`, pd.`department_id`;";
				InitializeCommand();
				OpenConnection();

				return (Project.ProjectStatus)Convert.ToInt32(Command.ExecuteScalar());
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return Project.ProjectStatus.None;
			}
		}

		public DataTable GetStatuses(int ProjectID)
		{
				DataTable oTable = new DataTable();
			
			try
			{

				SQL = "SELECT " +
					"	pd.`department_id`, " +
					"	IF(COUNT(q.`quote_id`) = 0, NULL, pd.`status`) AS `status`, " +
					"	IF(COUNT(q.`quote_id`) = 0, 0, CAST(pd.`status` AS DECIMAL)) AS `status_id` " +
					"FROM `rel_project_department` pd " +
					"	LEFT JOIN `quotes` q ON q.`project_id` = pd.`project_id` AND q.`department_id` = pd.`department_id` AND q.`is_archived` = 0 " +
					"WHERE pd.`project_id` = " + ProjectID + " " +
					"GROUP BY pd.`project_id`, pd.`department_id`;";
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

		public DataTable GetCrossLeads(int ProjectID)
		{
			try
			{
				DataTable oTable = new DataTable();
				
				SQL = "SELECT * FROM `cross_leads` cl WHERE cl.`project_id` = " + ProjectID + ";";
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

		public DataTable GetProjectCalculations(int ProjectID)
		{
			try
			{
				DataTable oTable = new DataTable();
				SQL = "SELECT " +
					"	d.`department_id`, " +
					"	d.`name` AS `department`, " +
					"	pd.`status`, " +
					"	CAST(pd.`status` AS DECIMAL) AS `status_id`, " +
					"	ppd.`status` AS `previous_status`, " +
					"	CAST(ppd.`status` AS DECIMAL) AS `previous_status_id`, " +
					"	COUNT(tq.`quote_id`) AS `quote_count`, " +
					"	COUNT(DISTINCT tq.`project_id`) AS `cust_count`, " +
					"	SUM(tq.`amount`) / COUNT(tq.`quote_id`) AS `average`, " +
					"	(pd.`probability` * 100) AS `probability`, " +
					"	(SUM(tq.`amount`) / COUNT(tq.`quote_id`)) * pd.`probability` * pd.`units` / COUNT(DISTINCT tq.`project_id`) AS `value`, " +
					"	MAX(n.`next_follow_up`) AS `next_follow_up` " +
					"FROM `rel_project_department` pd " +
					"	 JOIN `ref_departments` d ON pd.`department_id` = d.`department_id` " +
					"    JOIN ( " +
					"            SELECT " +
					"                ipd.`project_id`, " +
					"                MAX(ipd.`scope`) AS `scope`, " +
					"                ipd.`department_id` " +
					"            FROM `rel_project_department` ipd " +
					"            WHERE ipd.`project_id` = " + ProjectID + " " +
					"            GROUP BY ipd.`project_id`, ipd.`department_id` " +
					"         ) lpd ON pd.`project_id` = lpd.`project_id` AND pd.`department_id` = lpd.`department_id` AND pd.`scope` = lpd.`scope`" +
					"	 JOIN ((SELECT q.`project_id` AS `theProjectID`, q.* " +
					"			FROM `quotes` q " +
					"			WHERE q.`is_archived` = 0) " +
					"			UNION " +
					"			(SELECT mp.`project_id` AS `theProjectID`, q.* " +
					"			FROM `link_project_project` mp " +
					"			JOIN `link_project_project` tp ON mp.`link_id` = tp.`link_id` AND mp.`project_id` <> tp.`project_id` " +
					"			JOIN `quotes` q ON q.`is_archived` = 0 AND tp.`project_id` = q.`project_id` " +
					"           WHERE mp.`project_id` = " + ProjectID + ") " +
					"    ) AS tq ON tq.`theProjectID` = pd.`project_id` AND pd.`department_id` = tq.`department_id` AND pd.`scope` = tq.`scope` " +
					"	 LEFT JOIN `notes` n ON n.`is_archived` = 0  AND n.`next_follow_up` IS NOT NULL AND n.`completed` IS NULL AND " +
					"		pd.`project_id` = n.`project_id` AND pd.`department_id` = n.`department_id` " +
					"    LEFT JOIN `rel_project_department` ppd ON pd.`project_id` = ppd.`project_id` AND " +
					"         pd.`department_id` = ppd.`department_id` AND ppd.`scope` = (pd.`scope` - 1) " +
					"WHERE pd.`project_id` = " + ProjectID + " " +
					"GROUP BY pd.`department_id`;";
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

		public DataTable GetProjectCalculations(int ProjectID, int DepartmentID)
		{
			try
			{
				DataTable oTable = new DataTable();
				SQL = "SELECT d.`name` AS `department`, pd.`status`, CAST(pd.`status` AS DECIMAL) AS `status_id`, " +
					"COUNT(tq.`quote_id`) AS `quote_count`, COUNT(DISTINCT tq.`project_id`) AS `cust_count`, " +
					"SUM(tq.`amount`) / COUNT(tq.`quote_id`) AS `average`, (pd.`probability` * 100) AS `probability`, " +
					"(SUM(tq.`amount`) / COUNT(tq.`quote_id`)) * pd.`probability` * pd.`units` / COUNT(DISTINCT tq.`project_id`) AS `value`, " +
					"MAX(n.`next_follow_up`) AS `next_follow_up` " +
					"FROM `rel_project_department` pd " +
					"JOIN `ref_departments` d ON pd.`department_id` = d.`department_id` " +
					"JOIN ((SELECT q.`project_id` AS `theProjectID`, q.* " +
					"        FROM `quotes` q " +
					"        WHERE q.`is_archived` = 0) " +
					"    UNION " +
					"    (SELECT mp.`project_id` AS `theProjectID`, q.* " +
					"        FROM `link_project_project` mp " +
					"        JOIN `link_project_project` tp ON mp.`link_id` = tp.`link_id` AND mp.`project_id` <> tp.`project_id` " +
					"        JOIN `quotes` q ON q.`is_archived` = 0 AND tp.`project_id` = q.`project_id`)) AS tq " +
					"    ON tq.`theProjectID` = pd.`project_id` AND pd.`department_id` = tq.`department_id` AND pd.`scope` = tq.`scope` " +
					"LEFT JOIN `notes` n ON n.`is_archived` = 0  AND n.`next_follow_up` IS NOT NULL AND n.`completed` IS NULL AND " +
					"    pd.`project_id` = n.`project_id` AND pd.`department_id` = n.`department_id` " +
					"WHERE pd.`project_id` = " + ProjectID + " AND pd.`department_id` = " + DepartmentID + " " +
					"GROUP BY pd.`department_id`;";
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

		public Project InsertProject(Project newProject)
		{
			try
			{
				SQL = "INSERT INTO `projects` SET " +
					"`customer_id` = " + newProject.CustomerID + ", " +
					"`name` = '" + BuildSafeString(newProject.Name) + "', " +
					"`address` = '" + BuildSafeString(newProject.Address) + "', " +
					"`apt` = '" + BuildSafeString(newProject.Apt) + "', " +
					"`city` = '" + BuildSafeString(newProject.City) + "', " +
					"`zip_code` = " + newProject.ZipCode + ", " +
					"`type_id` = " + newProject.TypeID + ", " +
					"`contact_id` = " + newProject.ContactID + ", " +
					"`description` = '" + BuildSafeString(newProject.Description) + "', " +
					"`created` = NOW(), " +
					"`creator_id` = " + thisUser.ID + ", " +
					"`updated` = NOW(), " +
					"`updater_id` = " + thisUser.ID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save project for customer, " + newProject.CustomerID + ".");
				else
				{
					SQL = "SELECT MAX(p.`project_id`) FROM `projects` p WHERE p.`customer_id` = " + newProject.CustomerID + ";";
					InitializeCommand();

					return GetProject(Convert.ToInt32(Command.ExecuteScalar()));
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return newProject;
			}
		}

		public bool UpdateProject(Project theProject)
		{
			Project orig = GetProject(theProject.ID);

			try
			{
				SQL = "UPDATE `projects` p SET ";

				if (orig.CustomerID != theProject.CustomerID)
					SQL += "p.`customer_id` = " + theProject.CustomerID + ", ";

				if (orig.Name != theProject.Name)
					SQL += string.IsNullOrEmpty(theProject.Name) ? "p.`name` = NULL, " : "p.`name` = '" + BuildSafeString(theProject.Name) + "', ";

				if (orig.Address != theProject.Address)
					SQL += string.IsNullOrEmpty(theProject.Address) ? "p.`address` = NULL, " : "p.`address` = '" + BuildSafeString(theProject.Address) + "', ";

				if (orig.Apt != theProject.Apt)
					SQL += string.IsNullOrEmpty(theProject.Apt) ? "p.`apt` = NULL, " : "p.`apt` = '" + BuildSafeString(theProject.Apt) + "', ";

				if (orig.City != theProject.City)
					SQL += string.IsNullOrEmpty(theProject.City) ? "p.`city` = NULL, " : "p.`city` = '" + BuildSafeString(theProject.City) + "', ";

				if (orig.ZipCode != theProject.ZipCode)
					SQL += "p.`zip_code` = " + theProject.ZipCode + ", ";

				if (orig.TypeID != theProject.TypeID)
					SQL += "p.`type_id` = " + theProject.TypeID + ", ";

				if (orig.ContactID != theProject.ContactID)
					SQL += "p.`contact_id` = " + theProject.ContactID + ", ";

				if (orig.IsArchived != theProject.IsArchived)
					SQL += "p.`is_archived` = " + theProject.IsArchived + ", ";

				//Finish off the SQL statement
				SQL += "p.`updated` = NOW(), p.`updater_id` = " + thisUser.ID + " WHERE p.`project_id` = " + theProject.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The project with ID, " + theProject.ID + ", was not updated.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public int Link(Project thisProject, Project thatProject)
		{
			try
			{
				if (thatProject.LinkID > 0)
					SQL = "INSERT INTO `link_project_project` (`link_id`, `project_id`) VALUES (" + thatProject.LinkID + ", " + thisProject.ID + ");";
				else
					SQL = "INSERT INTO `link_project_project` SET `project_id` = " + thatProject.ID + "; " +
						"INSERT INTO `link_project_project` (`link_id`, `project_id`) VALUES (LAST_INSERT_ID(), " + thisProject.ID + ");";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to link project, " + thisProject.ID + ", with project, " + thatProject.ID + ".");
				else
				{
                    SQL = "SELECT l.`link_id` FROM `link_project_project` l WHERE l.`project_id` = " + thatProject.ID + ";";
					InitializeCommand();

					return Convert.ToInt32(Command.ExecuteScalar());
				}

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return 0;
			}
		}

		private int InsertLinkRecord(int ProjectID)
		{
			return 0;
		}

		private int InsertLinkRecord(int ProjectID, int LinkID)
		{
			return 0;
		}

		public bool RemoveLink(Project theProject)
		{
			try
			{
				int count = 0;

				SQL = "SELECT COUNT(`project_id`) FROM `link_project_project` WHERE `link_id` = " + theProject.LinkID + ";";
				InitializeCommand();
				OpenConnection();

				count = Convert.ToInt32(Command.ExecuteScalar());

				Command.Dispose();
				Command = null;

				SQL = "DELETE FROM `link_project_project` WHERE IF(" + count + " > 2, `project_id` = " + theProject.ID + ", `link_id` = " + theProject.LinkID + ");";
				InitializeCommand();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to remove the link for project, " + theProject.ID + ".");
				else
					return true;

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		public DataTable GetDuplicateProjects(string Name, int Address, int ProjectID, int CustomerID, bool ExcludeCustomer)
		{
			DataTable oTable = new DataTable();
			
			try
			{
				string Condition = "WHERE (";

				if (!string.IsNullOrEmpty(Name))
					Condition += "p.`name` LIKE '%" + Name + "%' " + (Address > 0 ? "OR" : ") AND") + " "; ;
				if (Address > 0)
					Condition += "p.`address` LIKE '" + Address.ToString() + "%') AND ";

				Condition += (ExcludeCustomer ? " NOT " : string.Empty) + "p.`customer_id` = " + CustomerID + " AND NOT p.`project_id` = " + ProjectID + " AND p.`is_archived` = 0;";

				SQL = "SELECT p.`project_id`, p.`customer_id`, p.`name` AS `project`, c.`name` AS `customer`, pt.`name` AS `type`, p.`address`, p.`city`, " + 
					"p.`apt`, p.`zip_code`, p.`is_archived` " +
					"FROM `projects` p " +
					"JOIN `customers` c ON p.`customer_id` = c.`customer_id` " +
					"JOIN `ref_project_types` pt ON p.`type_id` = pt.`type_id` ";

				SQL += Condition;
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

		public void MergeProjects(Project OldProject, Project NewProject)
		{
			try
			{
				SQL = "UPDATE `projects` p SET ";

				if (OldProject.Name != NewProject.Name)
					SQL += string.IsNullOrEmpty(NewProject.Name) ? "p.`name` = NULL, " : "p.`name` = '" + BuildSafeString(NewProject.Name) + "', ";

				if (OldProject.Address != NewProject.Address && !string.IsNullOrEmpty(NewProject.Address))
					SQL += string.IsNullOrEmpty(NewProject.Address) ? "p.`address` = NULL, " : "p.`address` = '" + BuildSafeString(NewProject.Address) + "', ";

				if (OldProject.Apt != NewProject.Apt)
					SQL += string.IsNullOrEmpty(NewProject.Apt) ? "p.`apt` = NULL, " : "p.`apt` = '" + BuildSafeString(NewProject.Apt) + "', ";

				if (OldProject.City != NewProject.City)
					SQL += string.IsNullOrEmpty(NewProject.City) ? "p.`city` = NULL, " : "p.`city` = '" + BuildSafeString(NewProject.City) + "', ";

				if (OldProject.ZipCode != NewProject.ZipCode)
					SQL += "p.`zip_code` = " + NewProject.ZipCode + ", ";

				if (OldProject.TypeID != NewProject.TypeID)
					SQL += "p.`type_id` = " + NewProject.TypeID + ", ";

				if (OldProject.ContactID != NewProject.ContactID)
					SQL += "p.`contact_id` = " + NewProject.ContactID + ", ";

				if (OldProject.IsArchived != NewProject.IsArchived)
					SQL += "p.`is_archived` = " + NewProject.IsArchived + ", ";

				//Finish off the SQL statement
				SQL += "p.`updated` = NOW(), p.`updater_id` = " + thisUser.ID + " WHERE p.`project_id` = " + OldProject.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The project with ID, " + OldProject.ID + ", was not updated.");
				else
				{
					SQL = "DELETE FROM `projects` WHERE `project_id` = " + NewProject.ID + ";";
					InitializeCommand();

					if (ExecuteStoredProcedure() == 0)
						throw new Exception("The project with ID, " + OldProject.ID + ", was not updated.");
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		internal Project GeneralNotes(int CustomerID)
		{
			Project result = null;

			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT p.*, lp.`link_id` FROM `projects` p " +
					"LEFT JOIN `link_project_project` lp ON p.`project_id` = lp.`project_id` " +
					"WHERE p.`customer_id` = " + CustomerID + " AND p.`type_id` = 10;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					result = new Project(oTable.Rows[0]);
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return result;
		}

	}
}
