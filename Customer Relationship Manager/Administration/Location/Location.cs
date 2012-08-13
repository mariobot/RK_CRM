using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Location
{
    /// <summary>
    /// Represents location data in the rkcrm database
    /// </summary>
    class Location : ObjectBase
    {
        #region Vairables

        private int intID;
        private string strName;
        private bool bolIsAvailable;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ID of this location
        /// </summary>
        public int ID
        {
            get { return intID; }
        }

        /// <summary>
        /// Gets pr sets the name of this location
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether this location is availible for use by end users
        /// </summary>
        public bool IsAvailable
        {
            get { return bolIsAvailable; }
            set { bolIsAvailable = value; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Creates a new Location object based the data provided
        /// </summary>
        /// <param name="LocationData"></param>
        public Location(DataRow LocationData)
            : base()
        {
            intID = Convert.ToInt32(LocationData["location_id"]);
            strName = LocationData["name"].ToString();
            bolIsAvailable = Convert.ToBoolean(LocationData["is_available"]);
            intCreatorID = Convert.ToInt32(LocationData["creator_id"]);
            datCreated = Convert.ToDateTime(LocationData["created"]);
            intUpdaterID = Convert.ToInt32(LocationData["updater_id"]);
            datUpdated = Convert.ToDateTime(LocationData["updated"]);
        }

        /// <summary>
        /// Creates a new Location object with default values
        /// </summary>
        public Location()
            : base()
        {
            intID = 0;
            bolIsAvailable = true;
        }

        #endregion
    }
}
