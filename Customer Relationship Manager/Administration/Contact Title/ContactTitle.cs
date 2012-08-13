using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Contact_Title
{
	class ContactTitle : ObjectBase
	{

		#region Variables

		private int intTitleID;
		private string strName;
		private bool bolIsAvailable;

		#endregion


		#region Properties

		public int TitleID
		{
			get { return intTitleID; }
			set { intTitleID = value; }
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

		public ContactTitle(DataRow TitleData)
			: base()
		{
			intTitleID = Convert.ToInt32(TitleData["title_id"]);
			strName = TitleData["name"].ToString();
			bolIsAvailable = Convert.ToBoolean(TitleData["is_available"]);

			intCreatorID = Convert.ToInt32(TitleData["creator_id"]);
			datCreated = Convert.ToDateTime(TitleData["created"]);
			intUpdaterID = Convert.ToInt32(TitleData["updater_id"]);
			datUpdated = Convert.ToDateTime(TitleData["updated"]);
		}


		public ContactTitle()
			: base()
		{
			intTitleID = 0;
			strName = string.Empty;
			bolIsAvailable = true;
		}

		#endregion

	}
}
