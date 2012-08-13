using System;
using System.Data;
using System.ComponentModel;
using rkcrm.Administration.Department;
using rkcrm.Administration.User;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Cross_Sale
{
	class CrossSale : ObjectBase
	{

		#region Variables

		private int intID;
		private int intCustomerID;
		private int intDepartmentID;
		private int intLeadID;
		private int intRepID;
		private DateTime datVerified;
		private DateTime datValidated;
		private bool bolNeverExpires;
		private bool bolIsArchived;

		#endregion


		#region Properties

		[Category("System")]
		[Description("The ID used to uniquely identify a cross sale")]
		public int ID
		{
			get { return intID; }
		}

		[Category("System")]
		[Description("The ID of the customer that this cross sale is associated with")]
		[DisplayName("Customer ID")]
		public int CustomerID
		{
			get { return intCustomerID; }
			set { intCustomerID = value; }
		}

		[Category("System")]
		[Description("The ID of the department that this cross sale is associated with")]
		[DisplayName("Department ID")]
		public int DepartmentID
		{
			get { return intDepartmentID; }
			set { intDepartmentID = value; }
		}

		[Category("System")]
		[Description("The ID of the cross lead that this cross sale is associated with")]
		[DisplayName("Lead ID")]
		public int LeadID
		{
			get { return intLeadID; }
			set { intLeadID = value; }
		}

		[Category("General")]
		[Description("The user ID of the sales rep that receives credit for this cross sale")]
		[DisplayName("Sales Rep ID")]
		public int SalesRepID
		{
			get { return intRepID; }
			set { intRepID = value; }
		}

		[Category("General")]
		[Description("The date when the cross lead was sent and the sending sales rep was given credit for cross leading the customer")]
		public DateTime Verified
		{
			get { return datVerified; }
			set { datVerified = value; }
		}

		[Category("General")]
		[Description("The date when the cross led customer first purchases from us and the sales rep begins to receive compensation")]
		public DateTime Validated
		{
			get { return datValidated; }
			set { datValidated = value; }
		}

		[Category("Special")]
		[Description("When true, the one year time limit for a sales rep receiving compensation for a validated cross sale does not apply")]
		[DisplayName("Never Expires")]
		public bool NeverExpires
		{
			get { return bolNeverExpires; }
			set { bolNeverExpires = value; }
		}

		[Category("System")]
		[DisplayName("Is Archived")]
		public bool IsArchived
		{
			get { return bolIsArchived; }
			set { bolIsArchived = value; }
		}

		#endregion


		#region Methods

		public Department GetDepartment()
		{
			Department clsDepartment = null;

			if (intDepartmentID > 0)
				using (DepartmentController theController = new DepartmentController())
				{
					clsDepartment = theController.GetDepartment(intDepartmentID);
				}

			return clsDepartment;
		}

		public Customer.Customer GetCustomer()
		{
			Customer.Customer clsCustomer = null;

			if(intCustomerID > 0)
				using (Customer.CustomerController theController = new rkcrm.Objects.Customer.CustomerController())
				{
					clsCustomer = theController.GetCustomer(intCustomerID);
				}

			return clsCustomer;
		}

		public Cross_Lead.CrossLead GetLead()
		{
			return null;
		}

		public User GetSalesRep()
		{
			User clsRep = null;

			if (intRepID > 0)
				using (UserController theController = new UserController())
				{
					clsRep = theController.GetUser(intRepID);
				}
			return clsRep;
		}

		#endregion


		#region Constructors

		public CrossSale(DataRow SaleData)
			: base()
		{
			intID = Convert.ToInt32(SaleData["relationship_id"]);
			intCustomerID = Convert.ToInt32(SaleData["customer_id"]);
			intDepartmentID = Convert.ToInt32(SaleData["department_id"]);
			intLeadID = Convert.ToInt32(SaleData["lead_id"]);
			intRepID = Convert.ToInt32(SaleData["sales_rep_id"]);
			datVerified = Convert.ToDateTime(SaleData["verified"]);
			datValidated = (SaleData["validated"] != DBNull.Value ? Convert.ToDateTime(SaleData["validated"]) : DateTime.MinValue);
			bolIsArchived = Convert.ToBoolean(SaleData["is_archived"]);
			bolNeverExpires = Convert.ToBoolean(SaleData["never_expires"]);
			intCreatorID = Convert.ToInt32(SaleData["creator_id"]); ;
			datCreated = Convert.ToDateTime(SaleData["created"]);
			intUpdaterID = Convert.ToInt32(SaleData["updater_id"]);
			datUpdated = Convert.ToDateTime(SaleData["updated"]);
		}

		public CrossSale()
			: base()
		{
			intID = 0;
			intCustomerID = 0;
			intDepartmentID = 0;
			intLeadID = 0;
			intRepID = 0;
			datVerified = DateTime.Today;
			datValidated = DateTime.MinValue;
			bolIsArchived = false;
			bolNeverExpires = false;
			intCreatorID = thisUser.ID;
			datCreated = DateTime.Now;
			intUpdaterID = thisUser.ID;
			datUpdated = DateTime.Now;
		}

		#endregion


	}
}
