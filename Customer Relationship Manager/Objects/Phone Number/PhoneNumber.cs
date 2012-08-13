using System;
using System.ComponentModel;
using System.Data;
using rkcrm.Administration.Phone_Type;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Phone_Number
{
	class PhoneNumber : ObjectBase
	{

		#region Variables

		private int intID;
		private string strNumber;
		private int intTypeID;

		#endregion


		#region Properties

		/// <summary>
		/// Gets the ID of this rkcrm.Objects.Phone_Number.PhoneNumber
		/// </summary>
		[Category("System")]
		[Description("The ID that uniquely identifies a phone number")]
		public int ID
		{
			get { return intID; }
		}

		/// <summary>
		/// Gets or sets the phone number of this rkcrm.Objects.Phone_Number.PhoneNumber object
		/// </summary>
		[Category("General")]
		[DisplayName("Phone Number")]
		public string Number
		{
			get { return strNumber; }
			set { strNumber = value; }
		}

		/// <summary>
		/// Gets or sets the phone number type of this rkcrm.Objects.Phone_Number.PhoneNumber
		/// </summary>
		[Category("General")]
		[Description("The ID that corresponds the phone's type. References the phone number type table in the database")]
		[DisplayName("Type ID")]
		public int TypeID
		{
			get { return intTypeID; }

			set { intTypeID = value; }
		}

		#endregion


		#region Methods

		public PhoneType GetPhoneType()
		{
			PhoneType clsPhoneType = null;

			if (intTypeID > 0 && clsPhoneType == null)
				using (PhoneTypeController theController = new PhoneTypeController())
				{
					clsPhoneType = theController.GetPhoneType(intTypeID);
				}
			return clsPhoneType;
		}

		public new string ToString()
		{
			string result = string.Empty;

			result += "Phone Number ID:" + this.ID + "/r/n";
			result += "Phone Number:" + this.Number + "/r/n";
			result += "Phone Type ID:" + this.TypeID + "/r/n";
			result += base.ToString();

			return result;
		}

		#endregion


		/// <summary>
		/// Creates a new rkcrm.Objects.Phone_Number.PhoneNumber with the values provided in the data row
		/// </summary>
		/// <param name="PhoneData"></param>
		public PhoneNumber(DataRow PhoneData)
			: base()
		{
			intID = Convert.ToInt32(PhoneData["phone_number_id"]);
			strNumber = PhoneData["phone_number"].ToString();
			intTypeID = PhoneData["type_id"] != DBNull.Value ? Convert.ToInt32(PhoneData["type_id"]) : 0;
			intCreatorID = Convert.ToInt32(PhoneData["creator_id"]);
			datCreated = Convert.ToDateTime(PhoneData["created"]);
			intUpdaterID = Convert.ToInt32(PhoneData["updater_id"]);
			datUpdated = Convert.ToDateTime(PhoneData["updated"]);
		}

		/// <summary>
		/// Creates a new rkcrm.Objects.Phone_Number.PhoneNumber with defualt values
		/// </summary>
		public PhoneNumber()
			: base()
		{
			intID = 0;
			strNumber = string.Empty;
			intTypeID = 0;
		}

	}
}
