using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Department
{
    /// <summary>
    /// Represents department data in the rkcrm database
    /// </summary>
	class Department : ObjectBase
	{

		#region Variables

        private int intID;
        private string strName;
        private int intFalconWHS;
        private bool bolIsProfitCenter;
        private bool bolIsAvailable;

        #endregion

		#region Properties

        /// <summary>
        /// Gets the ID of this department
        /// </summary>
        public int ID
        {
            get { return intID; }
        }

        /// <summary>
        /// Gets or sets the name of this department
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// Gets or sets the Falcon warehouse of the this department
        /// </summary>
        public int FalconWHS
        {
            get { return intFalconWHS; }
            set { intFalconWHS = value; }
        }

        /// <summary>
        /// Gets or sets the value that determines whether this department is a profit center
        /// </summary>
        public bool IsProfitCenter
        {
            get { return bolIsProfitCenter; }
            set { bolIsProfitCenter = value; }
        }

        /// <summary>
        /// Gets or sets the value that determines whether this department is availible for use
        /// </summary>
        public bool IsAvailable
        {
            get { return bolIsAvailable; }
            set { bolIsAvailable = value; }
        }

		#endregion

		#region Constructor/Destructor

        /// <summary>
        /// Creates a new department object based on the data provided
        /// </summary>
        /// <param name="DepartmentData"></param>
        public Department(DataRow DepartmentData) 
            : base()
        {
            intID = Convert.ToInt32(DepartmentData["department_id"]);
            strName = Convert.ToString(DepartmentData["name"]);
            if (!(DepartmentData["falcon_whs"] is DBNull))
                intFalconWHS = Convert.ToInt32(DepartmentData["falcon_whs"]);
            bolIsProfitCenter = Convert.ToBoolean(DepartmentData["is_profit_center"]);
            bolIsAvailable = Convert.ToBoolean(DepartmentData["is_available"]);
            intCreatorID = Convert.ToInt32(DepartmentData["creator_id"]);
            datCreated = Convert.ToDateTime(DepartmentData["created"]);
            intUpdaterID = Convert.ToInt32(DepartmentData["updater_id"]);
            datUpdated = Convert.ToDateTime(DepartmentData["updated"]);
        }

        /// <summary>
        /// Creates a new department object with default values
        /// </summary>
        public Department()
            : base()
        {
            intID = 0;
            intFalconWHS = 0;
            bolIsAvailable = true;
            bolIsProfitCenter = false;
        }
		#endregion

    }
}
