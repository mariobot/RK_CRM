using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Competitor
{
	class Competitor : ObjectBase
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

		public Competitor()
			: base()
		{
			intID = 0;
			strName = string.Empty;
			bolIsAvailable = true;
		}

		public Competitor(DataRow CompetitorData)
			: base()
		{
			intID = Convert.ToInt32(CompetitorData["competitor_id"]);
			strName = CompetitorData["name"].ToString();
			bolIsAvailable = Convert.ToBoolean(CompetitorData["is_available"]);
			datCreated = Convert.ToDateTime(CompetitorData["created"]);
			datUpdated = Convert.ToDateTime(CompetitorData["updated"]);
			intCreatorID = Convert.ToInt32(CompetitorData["creator_id"]);
			intUpdaterID = Convert.ToInt32(CompetitorData["updater_id"]);
		}

		#endregion

	}
}
