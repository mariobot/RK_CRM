using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.Phone_Type
{
	class PhoneType : ObjectBase
	{

		#region Varialbles

		private int intID;
		private string strName;
		private string strAbbreviation;
		private bool bolIsAvailable;

		#endregion


		#region Properties

		/// <summary>
		/// Gets the ID of this rkcrm.Administration.Phone_Type.PhoneType
		/// </summary>
		public int ID
		{
			get { return intID; }
		}

		/// <summary>
		/// Gets or sets the name of this rkcrm.Administration.Phone_Type.PhoneType
		/// </summary>
		public string Name
		{
			get { return strName; }
			set { strName = value; }
		}

		/// <summary>
		/// Gets or sets the abbreviation of this rkcrm.Administration.Phone_Type.PhoneType
		/// </summary>
		public string Abbreviation
		{
			get { return strAbbreviation; }
			set { strAbbreviation = value; }
		}

		/// <summary>
		/// Gets or sets a value that determine whether this rkcrm.Administration.Phone_Type.PhoneType is available
		/// </summary>
		public bool IsAvailable
		{
			get { return bolIsAvailable; }
			set { bolIsAvailable = value; }
		}

		#endregion


		#region Constructors

		public PhoneType(DataRow TypeData)
			: base()
		{
			intID = Convert.ToInt32(TypeData["type_id"]);
			strName = TypeData["name"].ToString();
			strAbbreviation = TypeData["abbreviation"].ToString();
			bolIsAvailable = Convert.ToBoolean(TypeData["is_available"]);
			intCreatorID = Convert.ToInt32(TypeData["creator_id"]);
			datCreated = Convert.ToDateTime(TypeData["created"]);
			intUpdaterID = Convert.ToInt32(TypeData["updater_id"]);
			datUpdated = Convert.ToDateTime(TypeData["updated"]);
		}

		public PhoneType()
			: base()
		{
			intID = 0;
			strName = string.Empty;
			strAbbreviation = string.Empty;
			bolIsAvailable = true;
		}

		#endregion

	}
}
