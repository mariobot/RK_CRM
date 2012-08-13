using System;
using System.Data;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.ZipCode
{
	class ZipCode : ObjectBase
	{

		#region Variables
		
		private int intZipCode;
		private string strCity;
		private string strState;
		private string strAbbreviation;

		#endregion


		#region Properties

		public int Code
		{
			get { return intZipCode; }
			set { intZipCode = value; }
		}

		public string City
		{
			get { return strCity; }
			set { strCity = value; }
		}

		public string State
		{
			get { return strState; }
			set { strState = value; }
		}

		public string Abbreviation
		{
			get { return strAbbreviation; }
			set { strAbbreviation = value; }
		}

		#endregion


		/// <summary>
		/// Creates a new Zipcode object based on the data provided
		/// </summary>
		/// <param name="ZipcodeData"></param>
		public ZipCode(DataRow ZipcodeData)
			: base()
		{
			intZipCode = Convert.ToInt32(ZipcodeData["zip_code"]);
			strCity = ZipcodeData["city"].ToString();
			strState = ZipcodeData["state"].ToString();
			strAbbreviation = ZipcodeData["state_abbreviation"].ToString();
			intCreatorID = Convert.ToInt32(ZipcodeData["creator_id"]);
			datCreated = Convert.ToDateTime(ZipcodeData["created"]);
			intUpdaterID = Convert.ToInt32(ZipcodeData["updater_id"]);
			datUpdated = Convert.ToDateTime(ZipcodeData["updated"]);
		}

		/// <summary>
		/// Creates a new Zipcode object with default values
		/// </summary>
		public ZipCode()
			: base()
		{
			strAbbreviation = string.Empty;
			strCity = string.Empty;
			strState = string.Empty;
		}

	}
}
