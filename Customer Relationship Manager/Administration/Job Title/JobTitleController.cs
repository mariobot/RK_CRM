using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Job_Title
{
    /// <summary>
    /// Contains methods to retrieve and manipulate job title data
    /// </summary>
    class JobTitleController : EntityBase
    {
        #region Methods

        /// <summary>
        /// Gets a JobTitle object
        /// </summary>
        /// <param name="TitleID">The ID of the job title to retrieve</param>
        /// <returns>JobTitle object</returns>
        public JobTitle GetJobTitle(int TitleID)
        {
            
            try
            {
                DataTable theData = new DataTable();
                
                SQL = "SELECT * FROM `ref_job_titles` j WHERE j.`title_id` = " + TitleID + ";";
                InitializeCommand();
                OpenConnection();

                FillDataTable(theData);

                if (theData.Rows.Count == 1)
                    return new JobTitle(theData.Rows[0]);
                else
                    throw new Exception("The job title ID either doesn't exist or there are more than one job titles with the ID of " + TitleID + ".");
            }
            catch (Exception e)
            {
                ErrorHandler.ProcessException(e, false);
                return null;
            }

        }

        /// <summary>
        /// Gets a list of all available job titles
        /// </summary>
        /// <returns></returns>
        public DataTable GetJobTitles()
        {
            try
            {
                DataTable oTable = new DataTable();

                SQL = "SELECT j.`title_id`, j.`name` FROM `ref_job_titles` j WHERE j.`is_available` = 1 ORDER BY j.`name`;";
                InitializeCommand();
                OpenConnection();

                FillDataTable(oTable);

                if (oTable.Rows.Count > 0)
                    return oTable;
                else
                    throw new Exception("There are no available job titles.");

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
