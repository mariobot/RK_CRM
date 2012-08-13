using System;
using System.Data;
using rkcrm.Base_Classes;
using System.ComponentModel;

namespace rkcrm.Objects.Cross_Lead
{
	class CrossLead : ObjectBase
	{


		#region Variables

		private int intLeadID;
		private int intProjectID;
		private int intPlanID;
		private bool bolCustomerHasDetails;
		private bool bolIsDigitalAvailable;
		private bool bolIsPaperAvailable;
		private bool bolIsListAvailable;
		private DateTime datBidDue;
		private string strNotes;

		#endregion


		#region Properties

		[Category("System")]
		[Description("This ID uniquely identifies a cross lead")]
		public int ID
		{
			get { return intLeadID; }
		}

		[Category("System")]
		[Description("The ID of the project that the cross lead is associated with")]
		[DisplayName("Project ID")]
		public int ProjectID
		{
			get { return intProjectID; }
			set { intProjectID = value; }
		}

		[Category("Plans")]
		[Description("This ID corresponds to an plan tracking spread sheet")]
		[DisplayName("Plan ID")]
		public int PlanID
		{
			get { return intPlanID; }
			set { intPlanID = value; }
		}

		[Category("Plans")]
		[Description("Indicates that the sales rep needs to contact the customer for details about the project")]
		[DisplayName("Customer Has Details")]
		public bool CustomerHasDetails
		{
			get { return bolCustomerHasDetails; }
			set { bolCustomerHasDetails = value; }
		}

		[Category("Plans")]
		[Description("Indicates that the plans should be in a digital format and can be found on the P:\\ drive")]
		[DisplayName("Is Digital Available")]
		public bool IsDigitalAvailable
		{
			get { return bolIsDigitalAvailable; }
			set { bolIsDigitalAvailable = value; }
		}

		[Category("Plans")]
		[Description("Indicates that a physical set of plans are on site")]
		[DisplayName("Is Paper Available")]
		public bool IsPaperAvailable
		{
			get { return bolIsPaperAvailable; }
			set { bolIsPaperAvailable = value; }
		}

		[Category("Plans")]
		[Description("Indicates that a physical list of materials is on site")]
		[DisplayName("Is List Available")]
		public bool IsListAvailable
		{
			get { return bolIsListAvailable; }
			set { bolIsListAvailable = value; }
		}

		[Category("General")]
		[Description("The date when the customer should have a quote")]
		[DisplayName("Bid Due")]
		public DateTime BidDue
		{
			get { return datBidDue; }
			set { datBidDue = value; }
		}

		[Category("General")]
		public string Notes
		{
			get { return strNotes; }
			set { strNotes = value; }
		}

		#endregion


		#region Methods

		public Project.Project GetProject()
		{
			if (intProjectID > 0)
			{
				using (Project.ProjectController theController = new rkcrm.Objects.Project.ProjectController())
				{
					return theController.GetProject(intProjectID);
				}
			}
			else
				return new rkcrm.Objects.Project.Project();
		}

		public new string ToString()
		{
			string result = string.Empty;

			result += "Cross Lead ID: " + this.ID + "\r\n";
			result += "Project ID: " + this.ProjectID + "\r\n";
			result += "Customer Has Details: " + this.CustomerHasDetails.ToString() + "\r\n";
			result += "Are Digital Plans Available: " + this.IsDigitalAvailable.ToString() + "\r\n";
			result += "Is a Material List Available: " + this.IsListAvailable.ToString() + "\r\n";
			result += "Are Paper Plans Available: " + this.IsPaperAvailable.ToString() + "\r\n";
			result += "Plan Tracking ID: " + this.PlanID + "\r\n";
			result += "Bid Due: " + this.BidDue.ToShortDateString() + "\r\n";
			result += "Notes: " + this.Notes + "\r\n";

			return result;
		}

		#endregion


		#region Constructors

		public CrossLead()
			: base()
		{
			intLeadID = 0;
			intProjectID = 0;
			intPlanID = 0;
			bolCustomerHasDetails = false;
			bolIsDigitalAvailable = false;
			bolIsListAvailable = false;
			bolIsPaperAvailable = false;
			datBidDue = DateTime.MinValue;
			strNotes = string.Empty;
		}

		public CrossLead(DataRow LeadData)
			: base()
		{
			intLeadID = Convert.ToInt32(LeadData["lead_id"]);
			intProjectID = Convert.ToInt32(LeadData["project_id"]);
			intPlanID = LeadData["plan_id"] != DBNull.Value ? Convert.ToInt32(LeadData["plan_id"]) : 0;
			bolCustomerHasDetails = Convert.ToBoolean(LeadData["customer_has_details"]);
			bolIsDigitalAvailable = Convert.ToBoolean(LeadData["is_digital_available"]);
			bolIsListAvailable = Convert.ToBoolean(LeadData["is_list_available"]);
			bolIsPaperAvailable = Convert.ToBoolean(LeadData["is_paper_available"]);
			datBidDue = LeadData["bid_due"] != DBNull.Value ? Convert.ToDateTime(LeadData["bid_due"]) : DateTime.MinValue;
			strNotes = LeadData["notes"].ToString();
			datCreated = Convert.ToDateTime(LeadData["sent"]);
			intCreatorID = Convert.ToInt32(LeadData["sender_id"]);
			datUpdated = Convert.ToDateTime(LeadData["sent"]);
			intUpdaterID = Convert.ToInt32(LeadData["sender_id"]);
		}

		#endregion

	}
}
