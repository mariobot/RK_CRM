using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Lost_Reason
{
	class Reason : ObjectBase
	{

		#region Variables

		int intID;
		string strName;
		bool bolIsAvailable;

		#endregion


		#region Properties

		public int ID
		{
			get { return intID; }
			set { intID = value; }
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


		#region Constructor

		public Reason()
			: base()
		{
			intID = 0;
			bolIsAvailable = true;
		}

		public Reason(DataRow ReasonData)
			: base()
		{
			intID = Convert.ToInt32(ReasonData["reason_id"]);
			strName = ReasonData["name"].ToString();
			bolIsAvailable = Convert.ToBoolean(ReasonData["is_available"]);
			intCreatorID = Convert.ToInt32(ReasonData["creator_id"]);
			datCreated = Convert.ToDateTime(ReasonData["created"]);
			intUpdaterID = Convert.ToInt32(ReasonData["updater_id"]);
			datUpdated = Convert.ToDateTime(ReasonData["updated"]);
		}

		#endregion

	}
}
