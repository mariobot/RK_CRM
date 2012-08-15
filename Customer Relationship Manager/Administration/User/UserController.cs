using System;
using System.Collections.Generic;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.User
{
    /// <summary>
    /// Contains methods to retrieve and manipulate user data
    /// </summary>
	class UserController : EntityBase
	{

		#region Methods

		/// <summary>
		/// Gets a new rkcrm.Administration.User object based on the user name provided
		/// </summary>
		/// <param name="UserName"></param>
		/// <returns></returns>
        public User GetUser(string UserName)
        {
            try
            {
                DataTable theData = new DataTable();

                SQL = "SELECT * FROM `users` u WHERE u.`user_name` = \"" + UserName + "\";";
                InitializeCommand();
                OpenConnection();

                FillDataTable(theData);

                if (theData.Rows.Count == 1)
                    return new Administration.User.User(theData.Rows[0]);
                else
                    throw new Exception("The user name, " + UserName + ", does not exist.");
            }
            catch (Exception e)
            {
                Error_Handling.ErrorHandler.ProcessException(e, false);
                return null;
            }
        }

		/// <summary>
		/// Gets a new rkcrm.Administration.User object based on the user ID provided
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		internal User GetUser(int UserID)
		{
			try
			{
				DataTable theData = new DataTable();

				SQL = "SELECT * FROM `users` u WHERE u.`user_id` = " + UserID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(theData);

				if (theData.Rows.Count == 1)
					return new Administration.User.User(theData.Rows[0]);
				else
					throw new Exception("The user ID, " + UserID + ", does not exist.");
			}
			catch (Exception e)
			{
				Error_Handling.ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		/// <summary>
		/// Gets a System.Data.DataTable object of all active users whose home department is a profit center
		/// </summary>
		/// <returns></returns>
		public DataTable GetSalesReps()
		{
			DataTable oTable = new DataTable();
			
			try
			{

				SQL = "SELECT u.`user_id`, CONCAT(u.`first_name` , ' ', u.`last_name`) AS `name`, ud.`department_id` FROM `users` u " +
					"JOIN `rel_user_departments` ud ON u.`user_id` = ud.`user_id` AND ud.`is_home` = 1 " +
					"JOIN `ref_departments` d ON ud.`department_id` = d.`department_id` " +
					"WHERE d.`is_profit_center` = 1 AND u.`role_id` <> 4 ORDER BY `name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("There are no sales reps in the database.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return oTable;
		}

		public DataTable GetRoleMembers(int RoleID)
		{
			DataTable oTable = new DataTable();

			try
			{

				SQL = "SELECT " +
					"	 u.* " +
					"FROM `users` u " +
					"WHERE u.`role_id` = " + RoleID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("There are no sales reps with a role id of " + RoleID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return oTable;
		}

		public DataTable GetAvailableEmployees()
		{
			DataTable oTable = new DataTable();

			try
			{

				SQL = "SELECT u.`user_id`, CONCAT(u.`first_name` , ' ', u.`last_name`) AS `name`, ud.`department_id` FROM `users` u " +
					"JOIN `rel_user_departments` ud ON u.`user_id` = ud.`user_id` AND ud.`is_home` = 1 " +
					"JOIN `ref_departments` d ON ud.`department_id` = d.`department_id` " +
					"WHERE u.`role_id` <> 4 ORDER BY `name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("There are no sales reps in the database.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return oTable;
		}

		public DataTable GetDepartmentReps(int DepartmentID)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT u.`user_id`, CONCAT(u.`first_name` , ' ', u.`last_name`) AS `name`, ud.`department_id` FROM `users` u " +
					"JOIN `rel_user_departments` ud ON u.`user_id` = ud.`user_id` AND ud.`is_home` = 1 " +
					"JOIN `ref_departments` d ON ud.`department_id` = d.`department_id` " +
					"WHERE u.`role_id` <> 4 AND ud.`department_id` = " + DepartmentID + " ORDER BY `name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("There are no sales reps in the department, " + DepartmentID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return oTable;
		}

		public DataTable GetSearchResults(string ColumnName, string Criteria)
		{
			DataTable oTable = new DataTable();
			string Select;
			string Where;
			string OrderBy;

			Where = "WHERE u.`role_id` <> 4 ";

			switch (ColumnName)
			{
				case "full_name":
					Where += "HAVING `full_name` LIKE '%" + Criteria + "%'";
					OrderBy = " ORDER BY `" + ColumnName + "`;";
					break;
				case "view_all":
					OrderBy = "ORDER BY `full_name`;";
					break;
				default:
					Where += "AND " + ColumnName + " LIKE '%" + Criteria + "%' ";
					OrderBy = "ORDER BY " + ColumnName + ";";
					break;
			}

			Select = "SELECT u.`user_id`, CONCAT(u.`first_name`, ' ', u.`last_name`) AS `full_name`, d.`name` AS `department` " +
				"FROM `users` u " +
				"JOIN `rel_user_departments` ud ON u.`user_id` = ud.`user_id` AND ud.`is_home` = 1 " +
				"JOIN `ref_departments` d ON ud.`department_id` = d.`department_id`";

			try
			{
				SQL = Select + Where + OrderBy;
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

		public DataTable GetLeadRecievers(List<int> Departments)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT u.`email_address` " +
					"FROM `users` u " +
					"JOIN `rel_user_departments` ud ON u.`user_id` = ud.`user_id` AND ud.`is_home` = 1 " +
					"WHERE u.`receives_crossleads` = 1 AND (";

				foreach (int dept in Departments)
				{
					SQL += "ud.`department_id` = " + dept;

					//If dept is not the last element
					if (Departments.IndexOf(dept) != Departments.Count - 1)
						SQL += " OR ";
					else
						SQL += ");";
				}

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

		internal bool UpdateUser(User theUser)
		{
			try
			{
				User orig = GetUser(theUser.ID);

				SQL = "UPDATE `users` u SET ";

				if (orig.FirstName != theUser.UserName)
					SQL += string.IsNullOrEmpty(theUser.UserName) ? "u.`user_name` = NULL, " : "u.`user_name` = '" + BuildSafeString(theUser.UserName) + "', ";

				if (orig.FirstName != theUser.FirstName)
					SQL += string.IsNullOrEmpty(theUser.FirstName) ? "u.`first_name` = NULL, " : "u.`first_name` = '" + BuildSafeString(theUser.FirstName) + "', ";

				if (orig.LastName != theUser.LastName)
					SQL += string.IsNullOrEmpty(theUser.LastName) ? "u.`last_name` = NULL, " : "u.`last_name` = '" + BuildSafeString(theUser.LastName) + "', ";

				if (orig.EmailAddress != theUser.EmailAddress)
					SQL += string.IsNullOrEmpty(theUser.EmailAddress) ? "u.`email_address` = NULL, " : " u.`email_address` = '" + BuildSafeString(theUser.EmailAddress) + "', ";

				if (orig.JobTitleID != theUser.JobTitleID)
					SQL += (theUser.JobTitleID == 0 ? "u.`job_title_id` = NULL, " : "u.`job_title_id` = " + theUser.JobTitleID + ", ");

				if (orig.LocationID != theUser.LocationID)
					SQL += (theUser.LocationID == 0 ? "u.`location_id` = NULL, " : "u.`location_id` = " + theUser.LocationID + ", ");

				if (orig.RoleID != theUser.RoleID)
					SQL += (theUser.RoleID == 0 ? "u.`role_id` = NULL, " : "u.`role_id` = " + theUser.RoleID + ", ");

				if (orig.ReceiveCrossLeads != theUser.ReceiveCrossLeads)
					SQL += "u.`receives_crossleads` = " + theUser.ReceiveCrossLeads + ", ";

				if (orig.ShowReminders != theUser.ShowReminders)
					SQL += "u.`show_reminders` = " + theUser.ShowReminders + ", ";

				//Finish off the SQL statement
				SQL += "u.`updated` = NOW(), u.`updater_id` = " + thisUser.ID + " WHERE u.`user_id` = " + theUser.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The user with ID, " + theUser.ID + ", was not updated.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal User InsertUser(User newUser)
		{
			try
			{
				SQL = "INSERT INTO `users` SET " +
					"`user_name` = '" + BuildSafeString(newUser.UserName) + "', " +
					"`first_name` = '" + BuildSafeString(newUser.FirstName) + "', " +
					"`last_name` = '" + BuildSafeString(newUser.LastName) + "', " +
					"`email_address` = '" + BuildSafeString(newUser.EmailAddress) + "', " +
					"`job_title_id` = " + (newUser.JobTitleID == 0 ? "NULL" : newUser.JobTitleID.ToString()) + ", " +
					"`location_id` = " + (newUser.LocationID == 0 ? "NULL" : newUser.LocationID.ToString()) + ", " +
					"`role_id` = " + (newUser.RoleID == 0 ? "NULL" : newUser.RoleID.ToString()) + ", " +
					"`show_reminders` = " + newUser.ShowReminders + ", " +
					"`receives_crossleads` = " + newUser.ReceiveCrossLeads + ", " +
					"`created` = NOW(), " +
					"`creator_id` = " + thisUser.ID + ", " +
					"`updated` = NOW(), " +
					"`updater_id` = " + thisUser.ID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save the new user.");
				else
				{
					int newID;

					SQL = "SELECT MAX(u.`user_id`) FROM `users` u;";
					InitializeCommand();

					newID = Convert.ToInt32(Command.ExecuteScalar());

					return GetUser(newID);
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return newUser;
			}
		}
		
		public HashSet<int> GetUserTasks(int UserID)
		{
			HashSet<int> theList = new HashSet<int>();
			MySql.Data.MySqlClient.MySqlDataReader oReader;

			try
			{
				SQL = "SELECT " +
					"    ut.`task_id` " +
					"FROM `rel_user_tasks` ut " +
					"WHERE ut.`user_id` = " + UserID + ";";
				InitializeCommand();
				OpenConnection();

				oReader = Command.ExecuteReader();

				if (oReader.HasRows)
				{
					while (oReader.Read())
						theList.Add(Convert.ToInt32(oReader["task_id"]));
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return theList;
		}

		#endregion

	}
}
