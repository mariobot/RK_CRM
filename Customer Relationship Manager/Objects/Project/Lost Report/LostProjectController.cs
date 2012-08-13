using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Project.Lost_Report
{
	class LostProjectController : EntityBase
	{

		public LostProjectReport GetReport(int ProjectID, int DepartmentID, int Scope)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT pr.* " +
					"FROM `lost_project_reports` pr WHERE pr.`project_id` = " + ProjectID + " AND pr.`department_id` = " + DepartmentID +
					" AND pr.`scope` = " + Scope + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new LostProjectReport(oTable.Rows[0]);
				else
					throw new Exception("The lost project report either doesn't exist or there are more than one lost project reports with the ID of " + ProjectID + "-" + DepartmentID + "-" + Scope + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new LostProjectReport();
			}
		}

		public bool InsertLostProjectReport(LostProjectReport theReport)
		{
			try
			{
				SQL = "INSERT INTO `lost_project_reports` SET " +
					"`project_id` = " + theReport.ProjectID + ", " +
					"`department_id` = " + theReport.DepartmentID + ", " +
					"`scope` = " + theReport.Scope + ", " +
					"`reason_id` = " + theReport.ReasonID + ", " +
					"`reason_details` = " + (string.IsNullOrEmpty(theReport.ReasonDetails) ? "NULL" : "'" + BuildSafeString(theReport.ReasonDetails) + "'") + ", " +
					"`competitor_id` = " + (theReport.CompetitorID == 0 ? "NULL" : theReport.CompetitorID.ToString()) + ", " +
					"`competitor_details` = " + (string.IsNullOrEmpty(theReport.CompetitorDetails) ? "NULL" : "'" + BuildSafeString(theReport.CompetitorDetails) + "'") + ", " +
					"`comments` = " + (string.IsNullOrEmpty(theReport.Comments) ? "NULL" : "'" + BuildSafeString(theReport.Comments) + "'") + ", " +
					"`created` = NOW(), " +
					"`creator_id` = " + thisUser.ID + ", " +
					"`updated` = NOW(), " +
					"`updater_id` = " + thisUser.ID + " " +
					"ON DUPLICATE KEY UPDATE " +
					"`reason_id` = " + theReport.ReasonID + ", " +
					"`reason_details` = " + (string.IsNullOrEmpty(theReport.ReasonDetails) ? "NULL" : "'" + BuildSafeString(theReport.ReasonDetails) + "'") + ", " +
					"`competitor_id` = " + (theReport.CompetitorID == 0 ? "NULL" : theReport.CompetitorID.ToString()) + ", " +
					"`competitor_details` = " + (string.IsNullOrEmpty(theReport.CompetitorDetails) ? "NULL" : "'" + BuildSafeString(theReport.CompetitorDetails) + "'") + ", " +
					"`comments` = " + (string.IsNullOrEmpty(theReport.Comments) ? "NULL" : "'" + BuildSafeString(theReport.Comments) + "'") + ", " +
					"`updated` = NOW(), `updater_id` = " + thisUser.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save the lost project report data for project " + theReport.ProjectID + ", " +
					"department " + theReport.DepartmentID + " and scope " + theReport.Scope + ".");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

	}
}
