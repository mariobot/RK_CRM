using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Role
{
    /// <summary>
    /// Contains methods to retrieve and manipulate role data
    /// </summary>
    class RoleController : EntityBase
    {
        #region Methods

        /// <summary>
        /// Gets a Role object
        /// </summary>
        /// <param name="RoleID">The ID of the role to retrieve</param>
        /// <returns>Role object</returns>
        public Role GetRole(int RoleID)
        {
            try
            {
                DataTable theData = new DataTable();

                SQL = "SELECT * FROM `ref_roles` r WHERE r.`role_id` = " + RoleID + ";";
                InitializeCommand();
                OpenConnection();

                FillDataTable(theData);
                
                if (theData.Rows.Count == 1)
                    return new Role(theData.Rows[0]);
                else
                    throw new Exception("The role ID either doesn't exist or there are more than one roles with the ID of " + RoleID + ".");
            }
            catch (Exception e)
            {
                ErrorHandler.ProcessException(e, false);
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all available roles
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoles()
        {
            try
            {
                DataTable oTable = new DataTable();

                SQL = "SELECT r.`role_id`, r.`name` FROM `ref_roles` r WHERE r.`is_available` = 1 ORDER BY r.`name`;";
                InitializeCommand();
                OpenConnection();

                FillDataTable(oTable);

                if (oTable.Rows.Count > 0)
                    return oTable;
                else
                    throw new Exception("There are no available roles.");
            }
            catch (Exception e)
            {
                ErrorHandler.ProcessException(e, false);
                return null;
            }
        }

        #endregion
    }
}
