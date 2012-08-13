using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Lead_Source
{
	/// <summary>
	/// Contains methods to retrieve and manipulate lead source data
	/// </summary>
	class LeadSourceController : EntityBase
	{

		#region Methods

		/// <summary>
		/// Gets a rkcrm.Administration.Lead_Source.LeadSource object
		/// </summary>
		/// <param name="SourceID"></param>
		/// <returns></returns>
		public LeadSource GetLeadSource(int SourceID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_lead_sources` l WHERE l.`source_id` = " + SourceID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return new LeadSource(oTable.Rows[0]);
				else
					throw new Exception("The lead source ID either doesn't exist or there are more than one lead sources with the ID of " + SourceID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new LeadSource();
			}
		}

		/// <summary>
		/// Gets a list of all available lead sources
		/// </summary>
		/// <returns></returns>
		public DataTable GetLeadSources()
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_lead_sources` l WHERE l.`is_available` = 1 ORDER BY l.`name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("There are no available lead sources.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		#endregion

	}
}
