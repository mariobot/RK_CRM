using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Contact_Method
{
	class ContactMethod : ObjectBase
	{

		#region Properties

		private int intMethodID;
		private string strName;
		private bool bolIsAvailable;

		#endregion


		public int ID
		{
			get { return intMethodID; }
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


		public ContactMethod(DataRow MethodData)
			: base()
		{
			intMethodID = Convert.ToInt32(MethodData["method_id"]);
			strName = MethodData["name"].ToString();
			bolIsAvailable = Convert.ToBoolean(MethodData["is_available"]);
			datCreated = Convert.ToDateTime(MethodData["created"]);
			datUpdated = Convert.ToDateTime(MethodData["updated"]);
			intCreatorID = Convert.ToInt32(MethodData["creator_id"]);
			intUpdaterID = Convert.ToInt32(MethodData["updater_id"]);
		}
		
		public ContactMethod()
			: base()
		{
			intMethodID = 0;
			strName = string.Empty;
			bolIsAvailable = false;
		}

	}
}
