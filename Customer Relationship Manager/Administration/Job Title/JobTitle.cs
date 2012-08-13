using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Job_Title
{
    /// <summary>
    /// Represents job title data in the rkcrm database
    /// </summary>
    class JobTitle : ObjectBase
    {
        #region Vairables

        private int intID;
        private string strName;
        private bool bolIsAvailable;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ID of this job title
        /// </summary>
        public int ID
        {
            get { return intID; }
        }

        /// <summary>
        /// Gets pr sets the name of this job title
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether this job title is availible for use by end users
        /// </summary>
        public bool IsAvailable
        {
            get { return bolIsAvailable; }
            set { bolIsAvailable = value; }
        }

        #endregion

        #region Constructors/Destructors

        public JobTitle(DataRow JobTitleData)
            : base()
        {
            intID = Convert.ToInt32(JobTitleData["title_id"]);
            strName = JobTitleData["name"].ToString();
            bolIsAvailable = Convert.ToBoolean(JobTitleData["is_available"]);
            intCreatorID = Convert.ToInt32(JobTitleData["creator_id"]);
            datCreated = Convert.ToDateTime(JobTitleData["created"]);
            intUpdaterID = Convert.ToInt32(JobTitleData["updater_id"]);
            datUpdated = Convert.ToDateTime(JobTitleData["updated"]);
        }

        public JobTitle()
            : base()
        {
            intID = 0;
            bolIsAvailable = true;
        }

        #endregion
    }
}
