using System;
using System.Data;
using System.ComponentModel;
using rkcrm.Administration.Competitor;
using rkcrm.Administration.Lost_Reason;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Project.Lost_Report
{
	class LostProjectReport : ObjectBase
	{

		#region Variables

		int intProjectID;
		int intDepartmentID;
		int intScope;
		int intReasonID;
		int intCompetitorID;
		string strReasonDetails;
		string strCompetitorDetails;
		string strComments;

		#endregion


		#region Properties

		[Category("System")]
		[Description("The ID of the project that is associated with this lost sale report. References the projects table in the database")]
		[DisplayName("Project ID")]
		public int ProjectID
		{
			get { return intProjectID; }
			set { intProjectID = value; }
		}

		[Category("System")]
		[Description("The ID of the department that is associated with this lost sale report. References the departments table in the database")]
		[DisplayName("Department ID")]
		public int DepartmentID
		{
			get { return intDepartmentID; }
			set { intDepartmentID = value; }
		}

		[Category("System")]
		[Description("The scope that is associated with this lost sale report")]
		public int Scope
		{
			get { return intScope; }
			set { intScope = value; }
		}

		[Category("General")]
		[Description("The ID of the reason why this project was lost that is associated with this lost sale report. References the lost reasons table in the database")]
		[DisplayName("Reason ID")]
		public int ReasonID
		{
			get { return intReasonID; }
			set { intReasonID = value; }
		}

		[Category("General")]
		[Description("The ID of the competitor the project was lost too. References the competitors table in the database")]
		[DisplayName("Competitor ID")]
		public int CompetitorID
		{
			get { return intCompetitorID; }
			set { intCompetitorID = value; }
		}

		[Category("General")]
		[Description("Provides more insight into why the project was lost")]
		[DisplayName("Reason Details")]
		public string ReasonDetails
		{
			get { return strReasonDetails; }
			set { strReasonDetails = value; }
		}

		[Category("General")]
		[DisplayName("Competitor Details")]
		public string CompetitorDetails
		{
			get { return strCompetitorDetails; }
			set { strCompetitorDetails = value; }
		}

		[Category("General")]
		public string Comments
		{
			get { return strComments; }
			set { strComments = value; }
		}

		#endregion


		#region Methods

		public Competitor GetCompetitor()
		{
			if (intCompetitorID > 0)
			{
				using (CompetitorController theController = new CompetitorController())
				{
					return theController.GetCompetitor(intCompetitorID);
				}
			}
			else
				return new Competitor();
		}

		public Reason GetReason()
		{
			if (intReasonID > 0)
			{
				using (ReasonController theController = new ReasonController())
				{
					return theController.GetReason(intReasonID);
				}
			}
			else
				return new Reason();
		}

		internal Administration.Department.Department GetDepartment()
		{
			if (intDepartmentID > 0)
			{
				using (Administration.Department.DepartmentController theController = new rkcrm.Administration.Department.DepartmentController())
				{
					return theController.GetDepartment(intDepartmentID);
				}
			}
			else
				return new Administration.Department.Department();
		}

		#endregion


		#region Constructors

		public LostProjectReport(DataRow ReportData)
			: base()
		{
			intProjectID = Convert.ToInt32(ReportData["project_id"]);
			intDepartmentID = Convert.ToInt32(ReportData["department_id"]);
			intScope = Convert.ToInt32(ReportData["scope"]);
			intReasonID = Convert.ToInt32(ReportData["reason_id"]);
			intCompetitorID = Convert.ToInt32(ReportData["competitor_id"]);
			strComments = ReportData["comments"].ToString();
			strCompetitorDetails = ReportData["competitor_details"].ToString();
			strReasonDetails = ReportData["reason_details"].ToString();
			intCreatorID = Convert.ToInt32(ReportData["creator_id"]);
			datCreated = Convert.ToDateTime(ReportData["created"]);
			intUpdaterID = Convert.ToInt32(ReportData["updater_id"]);
			datUpdated = Convert.ToDateTime(ReportData["updated"]);
		}

		public LostProjectReport()
			: base()
		{
			intProjectID = 0;
			intDepartmentID = 0;
			intScope = 1;
			intReasonID = 0;
			intCompetitorID = 0;
		}

		#endregion

	}
}
