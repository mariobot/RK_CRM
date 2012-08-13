using System;
using System.Data;
using System.ComponentModel;
using rkcrm.Administration.Contact_Method;
using rkcrm.Administration.Contact_Purpose;
using rkcrm.Administration.Department;
using rkcrm.Administration.User;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Note
{
	class Note : ObjectBase
	{

		#region Variables

		private int intID;
		private int intProjectID;
		private string strNotes;
		private int intRepID;
		private int intSupportID;
		private int intDepartmentID;
		private int intMethodID;
		private int intPurposeID;
		private int intContactID;
		private DateTime datNextFollowUp;
		private DateTime datCompleted;
		private bool bolIsArchived;

		#endregion


		#region Properties

		[Category("System")]
		[Description("The ID that uniquely identifies a note")]
		public int ID
		{
			get { return intID; }
		}

		[Category("System")]
		[Description("The ID of the project that this note is associated with. References the project table in the database")]
		[DisplayName("Project ID")]
		public int ProjectID
		{
			get { return intProjectID; }
			set { intProjectID = value; }
		}

		[Category("General")]
		public string Notes
		{
			get { return strNotes; }
			set { strNotes = value; }
		}

		[Category("General")]
		[Description("The user ID of the sales rep that is associated with this note. References the user table in the database")]
		[DisplayName("Sales Rep ID")]
		public int SalesRepID
		{
			get { return intRepID; }
			set { intRepID = value; }
		}

		[Category("General")]
		[Description("The user ID of the sales support that is associated with this note. References the user table in the database")]
		[DisplayName("Sales Support ID")]
		public int SalesSupportID
		{
			get { return intSupportID; }
			set { intSupportID = value; }
		}

		[Category("General")]
		[Description("The ID of the department that is associated with this note. References the department table in the database")]
		[DisplayName("Department ID")]
		public int DepartmentID
		{
			get { return intDepartmentID; }
			set { intDepartmentID = value; }
		}

		[Category("General")]
		[Description("The ID of the contact method that is associated with this note. References the contact method table in the database")]
		[DisplayName("Method ID")]
		public int MethodID
		{
			get { return intMethodID; }
			set { intMethodID = value; }
		}

		[Category("General")]
		[Description("The ID of the contact purpose that is associated with this note. References the contact purpose table in the database")]
		[DisplayName("Purpose ID")]
		public int PurposeID
		{
			get { return intPurposeID; }
			set { intPurposeID = value; }
		}

		[Category("General")]
		[Description("The ID of the contact that is associated with this note. References the contact table in the database")]
		[DisplayName("Contact ID")]
		public int ContactID
		{
			get { return intContactID; }
			set { intContactID = value; }
		}

		[Category("General")]
		[Description("The date when the sales rep plans to contact the customer")]
		[DisplayName("Next Follow Up")]
		public DateTime NextFollowUp
		{
			get { return datNextFollowUp; }
			set { datNextFollowUp = value; }
		}

		[Category("General")]
		[Description("The date when the sales rep mark this note as followed up")]
		public DateTime Completed
		{
			get { return datCompleted; }
			set { datCompleted = value; }
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

		public User GetSalesRep()
		{
			if (intRepID > 0)
			{
				using (UserController theController = new UserController())
				{
					return theController.GetUser(intRepID);
				}
			}
			else
				return new User();
		}

		public User GetSalesSupport()
		{
			if (intSupportID > 0)
			{
				using (UserController theController = new UserController())
				{
					return theController.GetUser(intSupportID);
				}
			}
			else
				return new User();
		}

		public Department GetDepartment()
		{
			if (intDepartmentID > 0)
			{
				using (DepartmentController theController = new DepartmentController())
				{
					return theController.GetDepartment(intDepartmentID);
				}
			}
			else
				return new Department();
		}

		public ContactMethod GetContactMethod()
		{
			if (intMethodID > 0)
			{
				using (ContactMethodController theController = new ContactMethodController())
				{
					return theController.GetContactMethod(intMethodID);
				}
			}
			else
				return new ContactMethod();
		}

		public ContactPurpose GetContactPurpose()
		{
			if (intPurposeID > 0)
			{
				using (ContactPurposeController theController = new ContactPurposeController())
				{
					return theController.GetContactPurpose(intPurposeID);
				}
			}
			else
				return new ContactPurpose();
		}

		public Contact.Contact GetContact()
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

		#endregion


		#region Constructors

		public Note(DataRow NoteData)
			: base()
		{
			intID = Convert.ToInt32(NoteData["note_id"]);
			intProjectID = Convert.ToInt32(NoteData["project_id"]);
			strNotes = NoteData["notes"].ToString(); ;
			intRepID = Convert.ToInt32(NoteData["sales_rep_id"]);
			intSupportID = Convert.ToInt32(NoteData["support_id"]);
			intDepartmentID = Convert.ToInt32(NoteData["department_id"]);
			intMethodID = Convert.ToInt32(NoteData["method_id"]);
			intPurposeID = Convert.ToInt32(NoteData["purpose_id"]);
			intContactID = Convert.ToInt32(NoteData["contact_id"]);
			datCompleted = (NoteData["completed"] != DBNull.Value ? Convert.ToDateTime(NoteData["completed"]) : DateTime.MinValue);
			datNextFollowUp = (NoteData["next_follow_up"] != DBNull.Value ? Convert.ToDateTime(NoteData["next_follow_up"]) : DateTime.MinValue);
			bolIsArchived = Convert.ToBoolean(NoteData["is_archived"]);
			datCreated = Convert.ToDateTime(NoteData["created"]);
			intCreatorID = Convert.ToInt32(NoteData["creator_id"]);
			datUpdated = Convert.ToDateTime(NoteData["updated"]);
			intUpdaterID = Convert.ToInt32(NoteData["updater_id"]);
		}

		public Note()
			: base()
		{
			intID = 0;
			intProjectID = 0;
			strNotes = string.Empty;
			intRepID = 0;
			intSupportID = 0;
			intDepartmentID = 0;
			intMethodID = 0;
			intPurposeID = 0;
			intContactID = 0;
			datCompleted = DateTime.MinValue;
			datNextFollowUp = DateTime.MinValue;
			bolIsArchived = false;
		}

		#endregion
	
	}
}
