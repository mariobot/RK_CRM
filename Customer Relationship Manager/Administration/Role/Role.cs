using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Role
{
    /// <summary>
    /// Represents role data in the rkcrm database
    /// </summary>
    class Role : ObjectBase
    {        
        #region Vairables

        private int intID;
        private string strName;
        private bool bolIsAvailable;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ID of this role
        /// </summary>
        public int ID
        {
            get { return intID; }
        }

        /// <summary>
        /// Gets pr sets the name of this role
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether this role is availible for use by end users
        /// </summary>
        public bool IsAvailable
        {
            get { return bolIsAvailable; }
            set { bolIsAvailable = value; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Creates a new Role object based on the data provided
        /// </summary>
        /// <param name="RoleData">DataRow of Role Data</param>
        public Role(DataRow RoleData)
            : base()
        {
            intID = Convert.ToInt32(RoleData["role_id"]);
            strName = RoleData["name"].ToString();
            bolIsAvailable = Convert.ToBoolean(RoleData["is_available"]);
            intCreatorID = Convert.ToInt32(RoleData["creator_id"]);
            datCreated = Convert.ToDateTime(RoleData["created"]);
            intUpdaterID = Convert.ToInt32(RoleData["updater_id"]);
            datUpdated = Convert.ToDateTime(RoleData["updated"]);
        }

        /// <summary>
        /// Creates a new Role object with default values
        /// </summary>
        public Role()
            : base()
        {
            intID = 0;
            bolIsAvailable = true;
        }

        #endregion
    }
}
