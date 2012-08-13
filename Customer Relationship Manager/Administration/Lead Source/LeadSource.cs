using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Lead_Source
{
	class LeadSource : ObjectBase
	{

		#region Variables

		private int intID;
		private string strName;
		private bool bolDetailsRequired;
		private string strListObject;
		private bool bolIsAvailable;

		#endregion		


		#region Properties

		/// <summary>
		/// Gets the ID of this rkcrm.Administration.Lead_Source.LeadSource
		/// </summary>
		public int ID
		{
			get { return intID; }
		}


		/// <summary>
		/// Gets or sets the name of this rkcrm.Administration.Lead_Source.LeadSource
		/// </summary>
		public string Name
		{
			get { return strName; }
			set { strName = value; }
		}

		/// <summary>
		/// Gets or sets the value that determines whether extra information is required when used by the user
		/// </summary>
		public bool DetailsRequired
		{
			get { return bolDetailsRequired; }
			set { bolDetailsRequired = value; }
		}

		/// <summary>
		/// Gets or sets the name of the object that is created when this lead source is selected
		/// </summary>
		public string ListObject
		{
			get { return strListObject; }
			set { strListObject = value; }
		}

		/// <summary>
		/// Gets or sets a value that determines whether this lead source is availible to users
		/// </summary>
		public bool IsAvailable
		{
			get { return bolIsAvailable; }
			set { bolIsAvailable = value; }
		}

		#endregion


		#region Constructors

		public LeadSource(DataRow LeadSourceData)
			: base()
		{
			intID = Convert.ToInt32(LeadSourceData["source_id"]);
			strName = LeadSourceData["name"].ToString();
			bolDetailsRequired = Convert.ToBoolean(LeadSourceData["details_required"]);
			strListObject = LeadSourceData["list_object"].ToString();
			bolIsAvailable = Convert.ToBoolean(LeadSourceData["is_available"]);
			intCreatorID = Convert.ToInt32(LeadSourceData["creator_id"]);
			datCreated = Convert.ToDateTime(LeadSourceData["created"]);
			intUpdaterID = Convert.ToInt32(LeadSourceData["updater_id"]);
			datUpdated = Convert.ToDateTime(LeadSourceData["updated"]);
		}

		public LeadSource()
			: base()
		{
			intID = 0;
			strName = string.Empty;
			bolDetailsRequired = false;
			strListObject = string.Empty;
			bolIsAvailable = true;
		}

		#endregion

	}
}
