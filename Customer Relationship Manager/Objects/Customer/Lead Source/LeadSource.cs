using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer.Lead_Source
{
	class LeadSource : ObjectBase
	{

		#region Variables

		private int intRelationID;
		private int intCustomerID;
		private int intDepartmentID;
		private int intSourceID;
		private DateTime datActivated;
		private string strDetails;
		private bool bolIsArchived;

		#endregion


		#region Properties

		public int ID
		{
			get { return intRelationID; }
		}

		public int CustomerID
		{
			get { return intCustomerID; }
			set { intCustomerID = value; }
		}

		public int DepartmentID
		{
			get { return intDepartmentID; }
			set { intDepartmentID = value; }
		}

		public int SourceID
		{
			get { return intSourceID; }
			set { intSourceID = value; }
		}

		public DateTime Activated
		{
			get { return datActivated; }
			set { datActivated = value; }
		}

		public string Details
		{
			get { return strDetails; }
			set { strDetails = value; }
		}

		public bool IsArchived
		{
			get { return bolIsArchived; }
			set { bolIsArchived = value; }
		}

		#endregion


		#region Methods

		public rkcrm.Administration.Lead_Source.LeadSource GetLeadSource()
		{
			if (intSourceID > 0)
			{
				using (Administration.Lead_Source.LeadSourceController theController = new rkcrm.Administration.Lead_Source.LeadSourceController())
				{
					return theController.GetLeadSource(intSourceID);
				}
			}
			else
				return new Administration.Lead_Source.LeadSource();
		}

		public Customer GetCustomer()
		{

			if (intCustomerID > 0)
			{
				using (CustomerController theController = new CustomerController())
				{
					return theController.GetCustomer(intCustomerID);
				}
			}
			else
				return null;
		}

		public rkcrm.Administration.Department.Department GetDeartment()
		{
			if(intDepartmentID > 0)
			{
				using (Administration.Department.DepartmentController theController = new rkcrm.Administration.Department.DepartmentController())
				{
					return theController.GetDepartment(intDepartmentID);
				}
			}
			else
				return null;
		}

		public LeadSource Copy()
		{
			LeadSource theCopy = new LeadSource();
			
			theCopy.bolIsArchived = this.bolIsArchived;
			theCopy.datActivated = this.datActivated;
			theCopy.datCreated = this.datCreated;
			theCopy.datUpdated = this.datUpdated;
			theCopy.intCreatorID = this.intCreatorID;
			theCopy.intCustomerID = this.intCustomerID;
			theCopy.intDepartmentID = this.intDepartmentID;
			theCopy.intSourceID = this.intSourceID;
			theCopy.intUpdaterID = this.intUpdaterID;
			theCopy.strDetails = this.strDetails;

			return theCopy;
		}

		#endregion


		#region Constructors

		public LeadSource()
			: base()
		{
			intRelationID = 0;
			intCustomerID = 0;
			intDepartmentID = 0;
			intSourceID = 0;
			strDetails = string.Empty;
			datActivated = DateTime.Now;
			bolIsArchived = false;
		}

		public LeadSource(DataRow SourceData)
			: base()
		{
			intRelationID = Convert.ToInt32(SourceData["relation_id"]);
			intCustomerID = Convert.ToInt32(SourceData["customer_id"]);
			intDepartmentID = Convert.ToInt32(SourceData["department_id"]);
			intSourceID = Convert.ToInt32(SourceData["source_id"]);
			datActivated = Convert.ToDateTime(SourceData["activated"]);
			strDetails = SourceData["details"].ToString();
			bolIsArchived = Convert.ToBoolean(SourceData["is_archived"]);
			intCreatorID = Convert.ToInt32(SourceData["creator_id"]);
			datCreated = Convert.ToDateTime(SourceData["created"]);
			intUpdaterID = Convert.ToInt32(SourceData["updater_id"]);
			datUpdated = Convert.ToDateTime(SourceData["updated"]);
		}

		#endregion


	}
}
