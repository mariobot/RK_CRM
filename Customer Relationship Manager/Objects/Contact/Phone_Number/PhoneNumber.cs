using System;
using System.Data;

namespace rkcrm.Objects.Contact.Phone_Number
{
	class PhoneNumber
	{

		#region Variables

		private int intContactID;
		private string strExtension;
		private bool bolIsPerferred;
		private rkcrm.Objects.Phone_Number.PhoneNumber thePhoneNumber;

		#endregion


		#region Properties

		public int ContactID
		{
			get { return intContactID; }
			set { intContactID = value; }
		}

		public int ID
		{
			get { return thePhoneNumber.ID; }
		}

		public string Number
		{
			get { return thePhoneNumber.Number; }
			set { thePhoneNumber.Number = value; }
		}

		public int TypeID
		{
			get { return thePhoneNumber.TypeID; }
			set { thePhoneNumber.TypeID = value; }
		}

		public string Extension
		{
			get { return strExtension; }
			set { strExtension = value; }
		}

		public bool IsPerferred
		{
			get { return bolIsPerferred; }
			set { bolIsPerferred = value; }
		}

		public bool IsComplete
		{
			get { return (thePhoneNumber.Number.Length == 10); }
		}

		public new string ToString()
		{
			string result = string.Empty;

			result += "Extension: " + this.Extension + "/r/n";
			result += "Is Perferred: " + this.IsPerferred + "/r/n";
			result += thePhoneNumber.ToString();

			return result;
		}

		#endregion


		#region Methods

		public rkcrm.Administration.Phone_Type.PhoneType GetPhoneType()
		{
			return thePhoneNumber.GetPhoneType();
		}

		public void SetPhoneNumber(rkcrm.Objects.Phone_Number.PhoneNumber value)
		{
			thePhoneNumber = value;
		}

		public rkcrm.Objects.Phone_Number.PhoneNumber GetPhoneNumber()
		{
			return thePhoneNumber;
		}

		#endregion


		#region Constructor

		public PhoneNumber(DataRow PhoneData)
			: base()
		{
			intContactID = Convert.ToInt32(PhoneData["contact_id"]);
			strExtension = PhoneData["extension"].ToString();
			bolIsPerferred = Convert.ToBoolean(PhoneData["is_preferred"]);

			thePhoneNumber = new rkcrm.Objects.Phone_Number.PhoneNumber(PhoneData);
		}

		public PhoneNumber()
			: base()
		{
			intContactID = 0;
			strExtension = string.Empty;
			bolIsPerferred = false;

			thePhoneNumber = new rkcrm.Objects.Phone_Number.PhoneNumber();
		}

		#endregion

	}
}
