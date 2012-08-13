using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.ZipCode
{
	/// <summary>
	/// Contains methods to retrieve and manipulate zip code data
	/// </summary>
	class ZipcodeController : EntityBase
	{

		#region Methods

		/// <summary>
		/// Gets a rkcrm.Administration.Zipcode.Zipcode
		/// </summary>
		/// <param name="ZipcodeID"></param>
		/// <returns></returns>
		public ZipCode GetZipCode(int ZipCode, bool SupressError)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_zip_codes` z WHERE z.`zip_code` = " + ZipCode + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return new ZipCode(oTable.Rows[0]);
				else
					throw new Exception("The zipcode either doesn't exist or there are more than one zipcode of " + ZipCode + ".");
			}
			catch (Exception e)
			{
				if(!SupressError)
					ErrorHandler.ProcessException(e, false);

				return new ZipCode();
			}
		}

		/// <summary>
		/// Gets a rkcrm.Administration.Zipcode.Zipcode
		/// </summary>
		/// <param name="ZipcodeID"></param>
		/// <returns></returns>
		internal ZipCode GetZipCode(string theZipCode, bool SupressError)
		{
			int ZipCode = Convert.ToInt32(theZipCode);

			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_zip_codes` z WHERE z.`zip_code` = " + ZipCode + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return new ZipCode(oTable.Rows[0]);
				else
					throw new Exception("The zipcode either doesn't exist or there are more than one zipcode of " + ZipCode + ".");
			}
			catch (Exception e)
			{
				if (!SupressError)
					ErrorHandler.ProcessException(e, false);

				return new ZipCode();
			}
		}

		/// <summary>
		/// Inserts a new zip code into the database
		/// </summary>
		/// <param name="newZip"></param>
		internal void InsertZipCode(ZipCode newZip)
		{
			try
			{
				SQL = "INSERT INTO `rkcrm_prototype`.`ref_zip_codes` " +
					"(`zip_code`, `city`, `state`, `state_abbreviation`, `created`, `creator_id`, `updated`, `updater_id`) VALUES " +
					"(" + newZip.Code + ", '" + newZip.City + "', '" + newZip.State + "', '" + newZip.Abbreviation + "', NOW(), " + thisUser.ID + ", NOW(), " + thisUser.ID + ");";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to insert the zip code.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		#endregion

	}
}
