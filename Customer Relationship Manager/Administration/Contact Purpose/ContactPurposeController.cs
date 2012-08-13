using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Contact_Purpose
{
	class ContactPurposeController : EntityBase
	{

		public ContactPurpose GetContactPurpose(int PurposeID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_contact_purposes` p WHERE p.`purpose_id` = " + PurposeID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new ContactPurpose(oTable.Rows[0]);
				else
					throw new Exception("The contact purpose either does not exist or there is more than one contact purpose with the ID of " + PurposeID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new ContactPurpose();
			}
		}


		public DataTable GetContactPurposes()
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT * FROM `ref_contact_purposes` p WHERE p.`is_available` = 1 ORDER BY p.`name`;";
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
