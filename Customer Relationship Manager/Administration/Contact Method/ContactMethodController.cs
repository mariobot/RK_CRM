using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Contact_Method
{
	class ContactMethodController : EntityBase
	{

		public ContactMethod GetContactMethod(int MethodID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_contact_methods` m WHERE m.`method_id` = " + MethodID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new ContactMethod(oTable.Rows[0]);
				else
					throw new Exception("The contact method either does not exist or there is more than one contact method with the ID of " + MethodID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new ContactMethod();
			}
		}

		public DataTable GetContactMethods()
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT * FROM `ref_contact_methods` m WHERE m.`is_available` = 1 ORDER BY m.`name`;";
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
