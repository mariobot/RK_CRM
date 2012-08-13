using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Customer_Type
{
	class CustomerType : ObjectBase
	{

		#region Variables

		private int intID;
		private string strName;
		private string strDescription;
		private bool bolRequireUniqueName;
		private bool bolDefaultName;
		private bool bolDefaultProjectName;
		private bool bolShowGeneralNotes;
		private bool bolIsAvailable;

		#endregion


		#region Properties

		/// <summary>
		/// Gets the ID of this rkcrm.Administration.Customer_Type.CustomerType
		/// </summary>
		public int ID
		{
			get { return intID; }
		}

		/// <summary>
		/// Gets or sets the name of this rkcrm.Administration.Customer_Type.CustomerType
		/// </summary>
		public string Name
		{
			get { return strName; }
			set { strName = value; }
		}

		/// <summary>
		/// Gets or sets the description of this rkcrm.Administration.Customer_Type.CustomerType
		/// </summary>
		public string Description
		{
			get { return strDescription; }
			set { strDescription = value; }
		}

		/// <summary>
		/// Gets or sets the value that determines whether this customer type requires the customer name to be unique
		/// </summary>
		public bool RequireUniqueName
		{
			get { return bolRequireUniqueName; }
			set { bolRequireUniqueName = value; }
		}

		/// <summary>
		/// Gets or set the value that determines whether this customer type will automatically default the customer name
		/// </summary>
		public bool DefualtCustomerName
		{
			get { return bolDefaultName; }
			set { bolDefaultName = value; }
		}

		/// <summary>
		/// Gets or sets the value that determines whether any new projects added to the customer will have a default project name
		/// </summary>
		public bool DefaultProjectName
		{
			get { return bolDefaultProjectName; }
			set { bolDefaultProjectName = value; }
		}

		/// <summary>
		/// Gets or sets the value that determines whether the general notes project will appear in the customers project list
		/// </summary>
		public bool ShowGeneralNotes
		{
			get { return bolShowGeneralNotes; }
			set { bolShowGeneralNotes = value; }
		}

		/// <summary>
		/// Gets or sets the value that determines whether this customer type is available to users
		/// </summary>
		public bool IsAvailable
		{
			get { return bolIsAvailable; }
			set { bolIsAvailable = value; }
		}

		#endregion


		#region Constructors

		public CustomerType(DataRow TypeData)
			: base()
		{
			intID = Convert.ToInt32(TypeData["type_id"]);
			strName = TypeData["name"].ToString();
			strDescription = TypeData["description"].ToString();
			bolRequireUniqueName = Convert.ToBoolean(TypeData["require_unique_name"]);
			bolDefaultName = Convert.ToBoolean(TypeData["default_company_name"]);
			bolDefaultProjectName = Convert.ToBoolean(TypeData["default_project_name"]);
			bolShowGeneralNotes = Convert.ToBoolean(TypeData["show_general_notes"]);
			bolIsAvailable = Convert.ToBoolean(TypeData["is_available"]);
			intCreatorID = Convert.ToInt32(TypeData["creator_id"]);
			datCreated = Convert.ToDateTime(TypeData["created"]);
			intUpdaterID = Convert.ToInt32(TypeData["updater_id"]);
			datUpdated = Convert.ToDateTime(TypeData["updated"]);
		}

		public CustomerType()
			: base()
		{
			intID = 0;
			strName = string.Empty;
			strDescription = string.Empty;
			bolRequireUniqueName = false;
			bolDefaultName = true;
			bolDefaultProjectName = true;
			bolShowGeneralNotes = false;
			bolIsAvailable = true;
		}

		#endregion

	}
}
