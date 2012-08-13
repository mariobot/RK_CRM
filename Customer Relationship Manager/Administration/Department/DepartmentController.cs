using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Department
{
    /// <summary>
    /// Contains methods to retrieve and manipulate department data
    /// </summary>
    class DepartmentController : EntityBase
    {

        #region Methods

        /// <summary>
		/// Gets a rkcrm.Administration.Department.Department object
        /// </summary>
        /// <param name="DepartmentID">The ID of the department to retrieve</param>
        /// <returns>Department Object</returns>
        public Department GetDepartment(int DepartmentID)
        {
            try
            {
                DataTable theData = new DataTable();

                SQL = "SELECT * FROM `ref_departments` d WHERE d.`department_id` = " + DepartmentID + ";";
                InitializeCommand();
                OpenConnection();

                FillDataTable(theData);

                if (theData.Rows.Count == 1)
                    return new Department(theData.Rows[0]);
                else
                    throw new Exception("The department ID either doesn't exist or there are more than one departments with the ID of " + DepartmentID + ".");
            }
            catch (Exception e)
            {
                ErrorHandler.ProcessException(e, false);
                return null;
            }
        }

        /// <summary>
        /// Gets a generic List object that contains rkcrm.Administration.Department.Department data for a specific user
        /// </summary>
        /// <param name="UserID">The ID of the user</param>
        /// <returns>List object</returns>
        public DepartmentCollection GetDepartments(int UserID)
        {
            try
            {
                DepartmentCollection theList = new DepartmentCollection();
                DataTable oTable = new DataTable();

                SQL = "SELECT d.`department_id` FROM `ref_departments` d JOIN `rel_user_departments` ud ON d.`department_id` = ud.`department_id` " +
                      "JOIN `users` u ON ud.`user_id` = u.`user_id` WHERE u.`user_id` = " + UserID + ";";
                InitializeCommand();
                OpenConnection();

                FillDataTable(oTable);

                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                        theList.Add(GetDepartment(Convert.ToInt32(oRow[0])));

                    return theList;
                }
                else
                    throw new Exception("The user ID, " + UserID + ", either doesn't exist or the user is not assigned to a department.");
            }
            catch (Exception e)
            {
                ErrorHandler.ProcessException(e, false);
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all available departments
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartments()
        {
            try
            {
                DataTable oTable = new DataTable();

                SQL = "SELECT d.`department_id`, d.`name` FROM `ref_departments` d WHERE d.`is_available` = 1 ORDER BY d.`name`;";
                InitializeCommand();
                OpenConnection();

                FillDataTable(oTable);

                if (oTable.Rows.Count > 0)
                    return oTable;
                else
                    throw new Exception("There are no available departments.");

            }
            catch (Exception e)
            {
                ErrorHandler.ProcessException(e, false);
                return null;
            }
        }

		/// <summary>
		/// Gets the rkcrm.Administration.Department.Department object that is marked as the user's home department
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public Department GetHomeDepartment(int UserID)
		{
			try
			{
				DataTable theData = new DataTable();

				SQL = "SELECT d.* FROM `ref_departments` d JOIN `rel_user_departments` ud ON d.`department_id` = ud.`department_id` WHERE ud.`is_home` = 1 AND ud.`user_id` = " + UserID + " LIMIT 1;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(theData);

				if (theData.Rows.Count == 1)
					return new Department(theData.Rows[0]);
				else
					throw new Exception("The user ID, " + UserID + ", may not have a home department.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}


		public DataTable GetProfitCenters()
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT d.`department_id`, d.`name` FROM `ref_departments` d WHERE d.`is_available` = 1 AND d.`is_profit_center` = 1 ORDER BY d.`name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				oTable.PrimaryKey = new DataColumn[] { oTable.Columns[0] };

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("There are no available departments designated as profit centers.");

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public DataTable GetCrossLeadableDepartments(int ProjectID)
		{
				DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT d.`department_id`, d.`name` " +
					"FROM (`ref_departments` d, `projects` p) " + 
					"LEFT JOIN `rel_project_department` pd ON p.`project_id` = pd.`project_id` AND d.`department_id` = pd.`department_id` " +
					"LEFT JOIN `notes` n ON p.`project_id` = n.`project_id` AND d.`department_id` = n.`department_id` AND n.`is_archived` = 0 " +
					"LEFT JOIN `quotes` q ON p.`project_id` = q.`project_id` AND d.`department_id` = q.`department_id` AND q.`is_archived` = 0 " +
					"LEFT JOIN (`cross_leads` cl JOIN `rel_crosslead_department` cd ON cl.`lead_id` = cd.`lead_id`) ON p.`project_id` = cl.`project_id` AND cd.`department_id` = d.`department_id` " + 
					"WHERE d.`is_profit_center` = 1 AND (pd.`status` = 1 OR pd.`status` IS NULL) AND p.`project_id` = " + ProjectID + " AND d.`department_id` <> " + thisUser.HomeDepartment.ID +
					" GROUP BY d.`department_id`, p.`project_id` " +
					"HAVING COUNT(DISTINCT n.`note_id`) + COUNT(DISTINCT q.`quote_id`) + COUNT(DISTINCT cl.`lead_id`) = 0;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}

			return oTable;
		}

        #endregion

    }
}
