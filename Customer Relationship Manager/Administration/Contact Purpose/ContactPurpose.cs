using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Contact_Purpose
{
	class ContactPurpose : ObjectBase
	{

		#region Variables

		private int intID;
		private string strName;
		private bool bolIsAvailable;

		#endregion


		#region Properties

		public int ID
		{
			get { return intID; }
		}

		public string Name
		{
			get { return strName; }
			set { strName = value; }
		}

		public bool IsAvailable
		{
			get { return bolIsAvailable; }
			set { bolIsAvailable = value; }
		}

		#endregion


		#region Constructors

		public ContactPurpose(DataRow PurposeData)
			: base()
		{
			intID = Convert.ToInt32(PurposeData["purpose_id"]);
			strName = PurposeData["name"].ToString();
			bolIsAvailable = Convert.ToBoolean(PurposeData["is_available"]);
			datCreated = Convert.ToDateTime(PurposeData["created"]);
			datUpdated = Convert.ToDateTime(PurposeData["updated"]);
			intCreatorID = Convert.ToInt32(PurposeData["creator_id"]);
			intUpdaterID = Convert.ToInt32(PurposeData["updater_id"]);
		}

		public ContactPurpose()
			: base()
		{
			intID = 0;
			strName = string.Empty;
			bolIsAvailable = false;
		}

		#endregion

	}
}
