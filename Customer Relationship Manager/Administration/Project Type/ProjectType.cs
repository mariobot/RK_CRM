using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Project_Type
{
	class ProjectType : ObjectBase
	{
		private int intID;
		private string strName;
		private bool bolIsAvailable;

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

		public ProjectType()
			: base()
		{
			intID = 0;
			strName = string.Empty;
			bolIsAvailable = true;
		}

		public ProjectType(DataRow TypeData)
			: base()
		{
			intID = Convert.ToInt32(TypeData["type_id"]);
			strName = TypeData["name"].ToString();
			bolIsAvailable = Convert.ToBoolean(TypeData["is_available"]);
			intCreatorID = Convert.ToInt32(TypeData["creator_id"]);
			datCreated = Convert.ToDateTime(TypeData["created"]);
			intUpdaterID = Convert.ToInt32(TypeData["updater_id"]);
			datUpdated = Convert.ToDateTime(TypeData["updated"]);
		}

	}
}
