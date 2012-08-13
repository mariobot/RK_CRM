using System;
using System.Data;
using MySql.Data.MySqlClient;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Reports
{
	class ReportController : EntityBase
	{

		public DataTable GetPageNames()
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "(SELECT r.`name` AS `page` " + 
					"FROM `reports` rp " +
					"JOIN `rel_report_role` rr ON rp.`report_id` = rr.`report_id` " +
					"JOIN `ref_roles` r ON rr.`role_id` = r.`role_id` " +
					"GROUP BY r.`name`) " +
					"UNION " +
					"(SELECT d.`name` AS `page` " +
					"FROM `reports` rp " +
					"JOIN `rel_report_department` rd ON rp.`report_id` = rd.`report_id` " +
					"JOIN `ref_departments` d ON rd.`department_id` = d.`department_id` " +
					"GROUP BY d.`name`);";
				//clear any other command
				if (Command != null)
				{
					Command.Dispose();
					Command = null;
				}

				Command = new MySql.Data.MySqlClient.MySqlCommand(SQL, Connection);
				Command.CommandType = CommandType.Text;

				OpenConnection();

				FillDataTable(oTable);

				return oTable;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new DataTable();
			}
		}

		public DataTable GetReports()
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT r.`name` AS `page`, rg.`name` AS `group`, rp.`name` AS `report`, rp.`parameter_form` " +
					"FROM `reports` rp " +
					"LEFT JOIN `ref_report_groups` rg ON rp.`group_id` = rg.`group_id` " +
					"JOIN `rel_report_role` rr ON rp.`report_id` = rr.`report_id` " +
					"JOIN `ref_roles` r ON rr.`role_id` = r.`role_id` " +
					"WHERE rp.`is_available` = 1 " +
					"UNION " +
					"SELECT d.`name` AS `page`, rg.`name` AS `group`, rp.`name` AS `report`, rp.`parameter_form` " +
					"FROM `reports` rp " +
					"LEFT JOIN `ref_report_groups` rg ON rp.`group_id` = rg.`group_id` " +
					"JOIN `rel_report_department` rd ON rp.`report_id` = rd.`report_id` " +
					"JOIN `ref_departments` d ON rd.`department_id` = d.`department_id` " +
					"WHERE rp.`is_available` = 1 " +
					"ORDER BY `page`, `group`, `report`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				return oTable;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new DataTable();
			}
		}

		public DataTable GetMyCrossLeadAnalysis(int RepID, DateTime Start, DateTime End)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "report_MyCrossLeadAnalysis";
				InitializeCommand();
				OpenConnection();

				AddParameter("p_rep_id", MySqlDbType.Int32, 133, RepID);
				AddParameter("p_start", MySqlDbType.Date, 133, Start.ToString("yyyy-MM-dd"));
				AddParameter("p_end", MySqlDbType.Date, 133, End.ToString("yyyy-MM-dd"));
				AddParameter("p_user", MySqlDbType.VarChar, 45, Environment.UserName);

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
