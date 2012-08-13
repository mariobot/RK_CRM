using System;
using System.ComponentModel;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Project.Department
{
	class Department : ObjectBase
	{

		#region Variables

		private int intProjectID;
		private int intDepartmentID;
		private int intScope;
		private int intUnits;
		private decimal decProbability;
		private DateTime datExpectedShip;
		private Project.ProjectStatus psStatus;

		#endregion


		#region Properties

		[Category("System")]
		[Description("The project ID the is associated with this department. One part of a 3 column ID the uniquely identifies this department. Refereneces the projects table in the database")]
		[DisplayName("Project ID")]
		public int ProjectID
		{
			get { return intProjectID; }
		}

		[Category("System")]
		[Description("The department ID the is associated with this department. One part of a 3 column ID the uniquely identifies this department. Refereneces the department table in the database")]
		[DisplayName("Department ID")]
		public int DepartmentID
		{
			get { return intDepartmentID; }
		}

		[Category("System")]
		[Description("The scope the is associated with this department. One part of a 3 column ID the uniquely identifies this department")]
		public int Scope
		{
			get { return intScope; }
		}

		[Category("General")]
		[Description("Indicates what stage the project is currently in")]
		public Project.ProjectStatus Status
		{
			get { return psStatus; }
			set { psStatus = value; }
		}

		[Category("General")]
		public int Units
		{
			get { return intUnits; }
			set { intUnits = value; }
		}

		[Category("General")]
		[Description("The user's best guess on how likley it is that the customer will purchase from us")]
		public decimal Probability
		{
			get { return decProbability; }
			set { decProbability = value; }
		}

		[Category("General")]
		[Description("The date when material is shipped or services perform is expected")]
		[DisplayName("Expected Ship Date")]
		public DateTime ExpectedShip
		{
			get { return datExpectedShip; }
			set { datExpectedShip = value; }
		}

		#endregion


		#region Methods

		public void GetNextScope()
		{
			if (intProjectID > 0 && intDepartmentID > 0)
			{
				using (DepartmentController theController = new DepartmentController())
				{
					intScope = theController.GetNextScope(intProjectID, intDepartmentID);
				}
			}
		}

		public void SetProjectID(int ProjectID)
		{
			if (intProjectID == 0)
				intProjectID = ProjectID;
		}

		public void SetDepartmentID(int DepartmentID)
		{
			if (intDepartmentID == 0)
				intDepartmentID = DepartmentID;
		}

		#endregion


		#region Constructors

		public Department()
			: base()
		{
			intProjectID = 0;
			intDepartmentID = 0;
			intScope = 1;
			intUnits = 1;
			decProbability = 0.0M;
			datExpectedShip = DateTime.MinValue;
			psStatus = Project.ProjectStatus.Outstanding;
		}

		public Department(DataRow DepartmentData)
			: base()
		{
			intProjectID = Convert.ToInt32(DepartmentData["project_id"]);
			intDepartmentID = Convert.ToInt32(DepartmentData["department_id"]);
			intScope = Convert.ToInt32(DepartmentData["scope"]);
			intUnits = Convert.ToInt32(DepartmentData["units"]);
			decProbability = Convert.ToDecimal(DepartmentData["probability"]);
			datExpectedShip = DepartmentData["expected_ship"] != DBNull.Value ? Convert.ToDateTime(DepartmentData["expected_ship"]) : DateTime.MinValue;
			psStatus = (Project.ProjectStatus)Convert.ToInt32(DepartmentData["status_id"]);
			intCreatorID = Convert.ToInt32(DepartmentData["creator_id"]);
			datCreated = Convert.ToDateTime(DepartmentData["created"]);
			intUpdaterID = Convert.ToInt32(DepartmentData["updater_id"]);
			datUpdated = Convert.ToDateTime(DepartmentData["updated"]);
		}

		#endregion

	}
}
