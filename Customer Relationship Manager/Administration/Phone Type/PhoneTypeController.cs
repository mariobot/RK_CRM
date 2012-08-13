using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Phone_Type
{
	/// <summary>
	/// Contains methods for retrieving and manipulating phone number type data
	/// </summary>
	class PhoneTypeController : EntityBase
	{

		#region Methods

		/// <summary>
		/// Gets a rkcrm.Administration.Phone_Type.PhoneType based on the ID provided
		/// </summary>
		/// <param name="TypeID"></param>
		/// <returns></returns>
		public PhoneType GetPhoneType(int TypeID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_phone_types` p WHERE p.`type_id` = " + TypeID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new PhoneType(oTable.Rows[0]);
				else
					throw new Exception("The phone type ID either doesn't exist or there are more than one phone types with the ID of " + TypeID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public DataTable GetPhoneTypes()
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_phone_types` p WHERE p.`is_available` = 1 ORDER BY p.`name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("The are no available phone number type in the database.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new DataTable();
			}
		}

		#endregion

	}
}
