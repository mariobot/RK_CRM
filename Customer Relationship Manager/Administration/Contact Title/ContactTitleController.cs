using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Contact_Title
{
	class ContactTitleController : EntityBase
	{

		public ContactTitle GetTitle(int TitleID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_contact_titles` ct WHERE ct.`title_id` = " + TitleID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new ContactTitle(oTable.Rows[0]);
				else
					throw new Exception("The contact title either does not exist or there is more than one contact title with the ID of " + TitleID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new ContactTitle();
			}
		}

		public DataTable GetTitles()
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_contact_titles` ct WHERE ct.`is_available` = 1 ORDER BY ct.`name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("There are no available contact titles in the database.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new DataTable();
			}
		}


	}
}
