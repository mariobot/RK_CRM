using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Competitor
{
	class CompetitorController : EntityBase
	{

		public Competitor GetCompetitor(int CompetitorID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `competitors` c WHERE c.`competitor_id` = " + CompetitorID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new Competitor(oTable.Rows[0]);
				else
					throw new Exception("The competitor either does not exist or there is more than one competitor with the ID of " + CompetitorID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new Competitor();
			}
		}

		public DataTable GetCompetitors(bool includeUnavailable)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT * FROM `competitors` c";

				if (!includeUnavailable)
					SQL += " WHERE c.`is_available` = 1 ";
					
				SQL += "ORDER BY c.`name`;";

				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return oTable;
		}

		public DataTable GetCompetitors(int DepartmentID)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT c.* FROM `competitors` c " +
					"JOIN `rel_competitor_department` cd ON c.`competitor_id` = cd.`competitor_id` " +
					"WHERE cd.`is_available` = 1 AND cd.`department_id` = " + DepartmentID + ";";

				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return oTable;
		}

	}
}
