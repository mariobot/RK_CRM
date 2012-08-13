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

		#endregion

	}
}
