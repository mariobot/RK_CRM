using System;
using System.ComponentModel;
using rkcrm.Administration.Department;
using rkcrm.Administration.User;

namespace rkcrm.Objects.Cross_Lead.Assigment
{
	class Assignment : IDisposable
	{


		#region Variables

		private bool disposed = false;

		private int intLeadID;
		private int intDepartmentID;
		private int intOwnerID;
		private DateTime datPlansReceived;
		private DateTime datExpectedCompletion;
		private DateTime datAssigned;
		private int intAssignerID;

		#endregion


		#region Properties

		[Category("System")]
		[Description("One part of a two-column ID used to uniquely identify an assignment. References the cross lead table in the database")]
		[DisplayName("Lead ID")]
		public int LeadID
		{
			get { return intLeadID; }
			set { intLeadID = value; }
		}

		[Category("System")]
		[Description("One part of a two-column ID used to uniquely identify an assignment. References the department table in the database")]
		[DisplayName("Department ID")]
		public int DepartmentID
		{
			get { return intDepartmentID; }
			set { intDepartmentID = value; }
		}

		[Category("System")]
		[Description("The user ID of the one who has been given the assignment")]
		[DisplayName("Owner ID")]
		public int OwnerID
		{
			get { return intOwnerID; }
			set { intOwnerID = value; }
		}

		[Category("General")]
		[Description("The date when the plans arrived on site")]
		[DisplayName("Plans Received")]
		public DateTime PlansReceived
		{
			get { return datPlansReceived; }
			set { datPlansReceived = value; }
		}

		[Category("General")]
		[Description("The date when the project is expected to be quoted")]
		[DisplayName("Expected Completion")]
		public DateTime ExpectedCompletion
		{
			get { return datExpectedCompletion; }
			set { datExpectedCompletion = value; }
		}

		[Category("System")]
		[Description("The date when the assignment was given")]
		public DateTime Assigned
		{
			get { return datAssigned; }
			set { datAssigned = value; }
		}

		[Category("System")]
		[Description("The user ID of the one who gave the assignment")]
		[DisplayName("Assigner ID")]
		public int AssignerID
		{
			get { return intAssignerID; }
			set { intAssignerID = value; }
		}

		#endregion


		#region Methods

		public CrossLead GetCrossLead()
		{
			CrossLead clsCrossLead = null;

			if (intLeadID > 0)
				using (CrossLeadController theController = new CrossLeadController())
				{
					clsCrossLead = theController.GetCrossLead(intLeadID);
				}
			return clsCrossLead;
		}

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

		public User GetOwner()
		{
			User clsOwner = null;

			if (intOwnerID > 0)
				using (UserController theController = new UserController())
				{
					clsOwner = theController.GetUser(intOwnerID);
				}
			return clsOwner;
		}

		public User GetAssigner()
		{
			User clsAssigner = null;

			if (intAssignerID > 0)
				using (UserController theController = new UserController())
				{
					clsAssigner = theController.GetUser(intAssignerID);
				}
			return clsAssigner;
		}

		#endregion


		#region Event Handlers

		#endregion


		#region Constructor

		public Assignment()
		{
			intLeadID = 0;
			intDepartmentID = 0;
			intOwnerID = 0;
			intAssignerID = 0;
			datPlansReceived = DateTime.MinValue;
			datExpectedCompletion = DateTime.MinValue;
			datAssigned = DateTime.MinValue;
		}


		public Assignment(System.Data.DataRow AssigmentData)
		{
			intLeadID = (AssigmentData["lead_id"] != DBNull.Value ? Convert.ToInt32(AssigmentData["lead_id"]) : 0);
			intDepartmentID = (AssigmentData["department_id"] != DBNull.Value ? Convert.ToInt32(AssigmentData["department_id"]) : 0);
			intOwnerID = (AssigmentData["owner_id"] != DBNull.Value ? Convert.ToInt32(AssigmentData["owner_id"]) : 0);
			intAssignerID = (AssigmentData["plans_received"] != DBNull.Value ? Convert.ToInt32(AssigmentData["plans_received"]) : 0);
			datPlansReceived = (AssigmentData["expected_completion"] != DBNull.Value ? Convert.ToDateTime(AssigmentData["expected_completion"]) : DateTime.MinValue);
			datExpectedCompletion = (AssigmentData["assigned"] != DBNull.Value ? Convert.ToDateTime(AssigmentData["assigned"]) : DateTime.MinValue);
			datAssigned = (AssigmentData["assigner_id"] != DBNull.Value ? Convert.ToDateTime(AssigmentData["assigner_id"]) : DateTime.MinValue);
		}


		#endregion


		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
			}

			disposed = true;
		}

		#endregion
	}
}
