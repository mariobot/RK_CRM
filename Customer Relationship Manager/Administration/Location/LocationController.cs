using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Location
{
    /// <summary>
    /// Contains methods to retrieve and manipulate location data
    /// </summary>
    class LocationController : EntityBase
    {
        #region Methods

        /// <summary>
        /// Gets a locatin object
        /// </summary>
        /// <param name="LocationID">The ID of the Location to retrieve</param>
        /// <returns>Location object</returns>
        public Location GetLocation(int LocationID)
        {
            try
            {
                DataTable theData = new DataTable();

                SQL = "SELECT * FROM `ref_locations` l WHERE l.`location_id` = " + LocationID + ";";
                InitializeCommand();
                OpenConnection();

                FillDataTable(theData);
                if (theData.Rows.Count == 1)
                    return new Location(theData.Rows[0]);
                else
                    throw new Exception("The location ID either doesn't exist or there are more than one locations with the ID of " + LocationID + ".");
            }
            catch (Exception e)
            {
                ErrorHandler.ProcessException(e, false);
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all available locations
        /// </summary>
        /// <returns></returns>
        public DataTable GetLocations()
        {
            try
            {
                DataTable oTable = new DataTable();

                SQL = "SELECT l.`location_id`, l.`name` FROM `ref_locations` l WHERE l.`is_available` = 1 ORDER BY l.`name`;";
                InitializeCommand();
                OpenConnection();

                FillDataTable(oTable);

                if (oTable.Rows.Count > 0)
                    return oTable;
                else
                    throw new Exception("There are no available locations.");
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
