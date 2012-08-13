using System;
using System.Data;
using System.ComponentModel;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Quote
{
	class Quote : ObjectBase
	{

		#region Variables

		private int intQuoteID;
		private int intProjectID;
		private int intDepartmentID;
		private int intScope;
		private string strName;
		private decimal decAmount;
		private string strDescription;
		private int intRepID;
		private int intSupportID;
		private int intMethodID;
		private int intContactID;
		private bool bolIsSold;
		private bool bolIsArchived;

		#endregion


		#region Properties

		[Category("System")]
		[Description("The ID that uniquely identifies a quote")]
		public int ID
		{
			get { return intQuoteID; }
			set { intQuoteID = value; }
		}

		[Category("System")]
		[Description("The ID of the project that is associated with this quote")]
		[DisplayName("Project ID")]
		public int ProjectID
		{
			get { return intProjectID; }
			set 
			{ 
				intProjectID = value;

				//if (intProjectID > 0 && intDepartmentID > 0)
				//    GetDepartment();
			}
		}

		[Category("System")]
		[Description("The ID of the department that is associated with this quote. References the department table in the database")]
		[DisplayName("Deparment ID")]
		public int DepartmentID
		{
			get { return intDepartmentID; }
			set 
			{ 
				intDepartmentID = value;

				//if (intProjectID > 0 && intDepartmentID > 0)
				//    GetDepartment();
			}
		}

		[Category("System")]
		public int Scope
		{
			get { return intScope; }
			set { intScope = value; }
		}

		[Category("General")]
		public string Name
		{
			get { return strName; }
			set { strName = value; }
		}

		[Category("General")]
		public decimal Amount
		{
			get { return decAmount; }
			set { decAmount = value; }
		}

		[Category("General")]
		public string Description
		{
			get { return strDescription; }
			set { strDescription = value; }
		}

		[Category("General")]
		[Description("The user ID of the sales rep associated with this quote. References the users table")]
		[DisplayName("Sales Rep ID")]
		public int SalesRepID
		{
			get { return intRepID; }
			set { intRepID = value; }
		}

		[Category("General")]
		[Description("The user ID of the sales support associated with this quote. References the users table")]
		[DisplayName("Sales Support ID")]
		public int SalesSupportID
		{
			get { return intSupportID; }
			set { intSupportID = value; }
		}

		[Category("General")]
		[Description("The ID of the contact method that is associated with this quote. References the contact method table in the database")]
		[DisplayName("Method ID")]
		public int MethodID
		{
			get { return intMethodID; }
			set { intMethodID = value; }
		}

		[Category("General")]
		[Description("The ID of the contact that is associated with this quote. References the contact table in the database")]
		[DisplayName("Contact ID")]
		public int ContactID
		{
			get { return intContactID; }
			set { intContactID = value; }
		}

		[Category("System")]
		[Description("Indicates the quote that was sold")]
		[DisplayName("Is Sold")]
		public bool IsSold
		{
			get { return bolIsSold; }
			set { bolIsSold = value; }
		}

		[Category("System")]
		public bool IsArchived
		{
			get { return bolIsArchived; }
			set { bolIsArchived = value; }
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

		public Administration.Department.Department GetDepartment()
		{
			if (intDepartmentID > 0)
			{
				using (Administration.Department.DepartmentController theController = new rkcrm.Administration.Department.DepartmentController())
				{
					return theController.GetDepartment(intDepartmentID);
				}
			}
			else
				return new rkcrm.Administration.Department.Department();
		}

		public Administration.Contact_Method.ContactMethod GetContactMethod()
		{
			if (intMethodID > 0)
			{
				using (Administration.Contact_Method.ContactMethodController theController = new rkcrm.Administration.Contact_Method.ContactMethodController())
				{
					return theController.GetContactMethod(intMethodID);
				}
			}
			else
				return new rkcrm.Administration.Contact_Method.ContactMethod();
		}

		public Contact.Contact GetPersonContacted()
		{
			if (intContactID > 0)
			{
				using (Contact.ContactController theController = new rkcrm.Objects.Contact.ContactController())
				{
					return theController.GetContact(intContactID);
				}
			}
			else
				return new rkcrm.Objects.Contact.Contact();
		}

		public Administration.User.User GetSalesRep()
		{
			if (intRepID > 0)
			{
				using (Administration.User.UserController theController = new rkcrm.Administration.User.UserController())
				{
					return theController.GetUser(intRepID);
				}
			}
			else
				return new rkcrm.Administration.User.User();
		}

		public Administration.User.User GetSalesSupport()
		{
			if (intSupportID > 0)
			{
				using (Administration.User.UserController theController = new rkcrm.Administration.User.UserController())
				{
					return theController.GetUser(intSupportID);
				}
			}
			else
				return new rkcrm.Administration.User.User();
		}

		//private void GetProjectDepartment()
		//{
		//    Department theDepartment;

		//    using (DepartmentController theController = new DepartmentController())
		//    {
		//        theDepartment = theController.GetDepartmentWithLastestScope(intProjectID, intDepartmentID);
		//    }

		//    if (theDepartment.ProjectID > 0)
		//        if (theDepartment.Status != Project.Project.ProjectStatus.Outstanding)
		//        {
		//            clsProjectDepartment = new Department();
		//            clsProjectDepartment.SetDepartmentID(intDepartmentID);
		//            clsProjectDepartment.SetProjectID(intProjectID);
		//            clsProjectDepartment.GetNextScope();
		//        }
		//        else
		//            clsProjectDepartment = theDepartment;
		//    else
		//    {
		//        theDepartment.SetProjectID(intProjectID);
		//        theDepartment.SetDepartmentID(intDepartmentID);
		//        clsProjectDepartment = theDepartment;
		//    }
		//}

		#endregion


		#region Constructors

		public Quote(DataRow QuoteData)
			: base()
		{
			bolIsArchived = Convert.ToBoolean(QuoteData["is_archived"]);
			bolIsSold = Convert.ToBoolean(QuoteData["is_sold"]); ;
			decAmount = Convert.ToDecimal(QuoteData["amount"]);
			intContactID = QuoteData["contact_id"] != DBNull.Value ? Convert.ToInt32(QuoteData["contact_id"]) : 0;
			intDepartmentID = QuoteData["department_id"] != DBNull.Value ? Convert.ToInt32(QuoteData["department_id"]) : 0;
			intMethodID = QuoteData["method_id"] != DBNull.Value ? Convert.ToInt32(QuoteData["method_id"]) : 0;
			intProjectID = Convert.ToInt32(QuoteData["project_id"]);
			intQuoteID = Convert.ToInt32(QuoteData["quote_id"]);
			intRepID = QuoteData["sales_rep_id"] != DBNull.Value ? Convert.ToInt32(QuoteData["sales_rep_id"]) : 0;
			intScope = Convert.ToInt32(QuoteData["scope"]);
			intSupportID = QuoteData["support_id"] != DBNull.Value ? Convert.ToInt32(QuoteData["support_id"]) : 0;
			strDescription = QuoteData["description"].ToString();
			strName = QuoteData["name"].ToString();
			datCreated = Convert.ToDateTime(QuoteData["created"]);
			intCreatorID = Convert.ToInt32(QuoteData["creator_id"]);
			datUpdated = Convert.ToDateTime(QuoteData["updated"]);
			intUpdaterID = Convert.ToInt32(QuoteData["updater_id"]);

			//using (DepartmentController theController = new DepartmentController())
			//{
			//    clsProjectDepartment = theController.GetDepartment(intProjectID, intDepartmentID, intScope);
			//}
		}

		public Quote()
			: base()
		{
			bolIsArchived = false;
			bolIsSold = false;
			decAmount = 0;
			intContactID = 0;
			intDepartmentID = 0;
			intMethodID = 0;
			intProjectID = 0;
			intQuoteID = 0;
			intRepID = 0;
			intScope = 1;
			intSupportID = 0;
			strDescription = string.Empty;
			strName = string.Empty;
		}

		#endregion

	}
}
