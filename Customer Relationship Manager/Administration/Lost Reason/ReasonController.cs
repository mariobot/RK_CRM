using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Lost_Reason
{
	class ReasonController : EntityBase
	{

		/// <summary>
		/// Gets a reason object
		/// </summary>
		/// <param name="LocationID">The ID of the reason to retrieve</param>
		/// <returns>Reason object</returns>
		public Reason GetReason(int ReasonID)
		{
			try
			{
				DataTable theData = new DataTable();

				SQL = "SELECT * FROM `ref_lost_reasons` r WHERE r.`reason_id` = " + ReasonID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(theData);
				if (theData.Rows.Count == 1)
					return new Reason(theData.Rows[0]);
				else
					throw new Exception("The reason ID either doesn't exist or there are more than one reasons with the ID of " + ReasonID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		/// <summary>
		/// Gets a list of all available reasons
		/// </summary>
		/// <returns></returns>
		public DataTable GetReasons()
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT r.`reason_id`, r.`name` FROM `ref_lost_reasons` r WHERE r.`is_available` = 1 ORDER BY r.`name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("There are no available reasons.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

	}
}
