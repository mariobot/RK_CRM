using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;
using System.Collections.Generic;

namespace rkcrm.Security
{
	class SecurityController : EntityBase
	{
		public List<int> GetUserTasks(int UserID)
		{
			List<int> theList = new List<int>();
			MySql.Data.MySqlClient.MySqlDataReader oReader;

			try
			{
				SQL = "SELECT " +
					"    ut.`task_id` " +
					"FROM `rel_user_tasks` ut " +
					"WHERE ut.`user_id` = " + UserID + ";";
				InitializeCommand();
				OpenConnection();

				oReader = Command.ExecuteReader();

				if (oReader.HasRows)
				{
					while (oReader.Read())
						theList.Add(Convert.ToInt32(oReader["task_id"]));
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return theList;
		}
	}
}
