using System;
using System.ComponentModel;
using System.Data;
using rkcrm.Administration.Project_Type;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Project
{
	class Project : ObjectBase
	{

		#region Variables

		private int intID;
		private int intCustomerID;
		private string strName;
		private string strAddress;
		private string strApt;
		private string strCity;
		private string strDescription;
		private string strState;
		private int intZipCode;
		private int intTypeID;
		private int intContactID;
		private bool bolIsArchived;
		private int intLinkID;

		#endregion


		#region Properties

		[Category("System")]
		[Description("The ID that uniquely identifies a project")]
		public int ID
		{
			get { return intID; }
			set { intID = value; }
		}

		[Category("System")]
		[Description("The ID of the customer that this project is associated with")]
		[DisplayName("Customer ID")]
		[ReadOnly(true)]
		public int CustomerID
		{
			get { return intCustomerID; }
			set { intCustomerID = value; }
		}

		[Category("General")]
		public string Name
		{
			get { return strName; }
			set { strName = value; }
		}

		[Category("Address")]
		public string Address
		{
			get { return strAddress; }
			set { strAddress = value; }
		}

		[Category("Address")]
		public string Apt
		{
			get { return strApt; }
			set { strApt = value; }
		}

		[Category("Address")]
		public string City
		{
			get { return strCity; }
			set { strCity = value; }
		}

		[Category("General")]
		public string Description
		{
			get { return strDescription; }
			set { strDescription = value; }
		}

		[Category("Address")]
		public string State
		{
			get { return strState; }
			set { strState = value; }
		}

		[Category("Address")]
		public int ZipCode
		{
			get { return intZipCode; }
			set { intZipCode = value; }
		}

		[Category("General")]
		[Description("The ID of the person to contact with questions about this project. References the contact table")]
		[DisplayName("Contact ID")]
		public int ContactID
		{
			get { return intContactID; }
			set { intContactID = value; }
		}

		[Category("General")]
		[Description("The ID that corresponds to a project type. References the project type table")]
		[DisplayName("Type ID")]
		public int TypeID
		{
			get { return intTypeID; }
			set { intTypeID = value; }
		}

		[Category("System")]
		public bool IsArchived
		{
			get { return bolIsArchived; }
			set { bolIsArchived = value; }
		}

		[Category("General")]
		[Description("Indicates which other projects this project is associated with. References the link project table in the database")]
		[DisplayName("Link ID")]
		public int LinkID
		{
			get { return intLinkID; }
			set { intLinkID = value; }
		}

		#endregion


		#region Methods

		public Customer.Customer GetCustomer()
		{
			if (intCustomerID > 0)
			{
				using (Customer.CustomerController theController = new Customer.CustomerController())
				{
					return theController.GetCustomer(intCustomerID);
				}
			}
			else
				return new rkcrm.Objects.Customer.Customer();
		}

		public Contact.Contact GetContact()
		{
			if (intContactID > 0)
			{
				using (Contact.ContactController theController = new Contact.ContactController())
				{
					return theController.GetContact(intContactID);
				}
			}
			else
				return new rkcrm.Objects.Contact.Contact();
		}

		public ProjectType GetProjectType()
		{
			if (intTypeID > 0)
			{
				using (ProjectTypeController theController = new ProjectTypeController())
				{
					return theController.GetProjectType(intTypeID);
				}
			}
			else
				return new ProjectType();
		}

		#endregion


		#region Constructors

		public Project(DataRow ProjectData)
			: base()
		{
			intID = Convert.ToInt32(ProjectData["project_id"]);
			intCustomerID = Convert.ToInt32(ProjectData["customer_id"]);
			strName = ProjectData["name"].ToString();
			strAddress = ProjectData["address"].ToString();
			strApt = ProjectData["apt"].ToString();
			strCity = ProjectData["city"].ToString();
			strDescription = ProjectData["description"].ToString();
			strState = string.Empty;
			intZipCode = ProjectData["zip_code"] != DBNull.Value ? Convert.ToInt32(ProjectData["zip_code"]) : 0;
			intTypeID = ProjectData["type_id"] != DBNull.Value ? Convert.ToInt32(ProjectData["type_id"]) : 0;
			intContactID = ProjectData["contact_id"] != DBNull.Value ? Convert.ToInt32(ProjectData["contact_id"]) : 0;
			bolIsArchived = Convert.ToBoolean(ProjectData["is_archived"]);
			intLinkID = ProjectData["link_id"] != DBNull.Value ? Convert.ToInt32(ProjectData["link_id"]) : 0;
			datCreated = Convert.ToDateTime(ProjectData["created"]);
			intCreatorID = Convert.ToInt32(ProjectData["creator_id"]);
			datUpdated = Convert.ToDateTime(ProjectData["updated"]);
			intUpdaterID = Convert.ToInt32(ProjectData["updater_id"]);
		}

		public Project()
			: base()
		{
			intID = 0;
			intCustomerID = 0;
			strName = string.Empty;
			strAddress = string.Empty;
			strApt = string.Empty;
			strCity = string.Empty;
			strDescription = string.Empty;
			intZipCode = 0;
			intTypeID = 0;
			intContactID = 0;
			bolIsArchived = false;
			intLinkID = 0;
		}

		#endregion


		#region Enumerations

		public enum ProjectStatus { None = 0, Outstanding, Sold, Lost };

		#endregion

	}
}
