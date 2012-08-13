using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Project_Type
{
	/// <summary>
	/// Contains methods for retrieving and manipulating project type data
	/// </summary>
	class ProjectTypeController : EntityBase
	{

		#region Methods

		/// <summary>
		/// Gets a rkcrm.Administration.Phone_Type.PhoneType based on the ID provided
		/// </summary>
		/// <param name="TypeID"></param>
		/// <returns></returns>
		public ProjectType GetProjectType(int TypeID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_project_types` p WHERE p.`type_id` = " + TypeID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new ProjectType(oTable.Rows[0]);
				else
					throw new Exception("The project type ID either doesn't exist or there are more than one project types with the ID of " + TypeID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public DataTable GetProjectTypes()
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_project_types` p WHERE p.`is_available` = 1 ORDER BY p.`name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("The are no available project type in the database.");
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
