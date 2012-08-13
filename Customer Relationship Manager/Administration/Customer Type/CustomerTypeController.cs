using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Administration.Customer_Type
{
	/// <summary>
	/// Contains methods to retrieve and manipulate customer type data
	/// </summary>
	class CustomerTypeController : EntityBase
	{
		
		#region Methods

		/// <summary>
		/// Gets a rkcrm.Administration.Customer_Type.CustomerType object based on the ID provided
		/// </summary>
		/// <param name="TypeID"></param>
		/// <returns></returns>
		public CustomerType GetCustomerType(int TypeID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_customer_types` t WHERE t.`type_id` = " + TypeID + ";";
				InitializeCommand();
				//OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return new CustomerType(oTable.Rows[0]);
				else
					throw new Exception("The customer type ID either doesn't exist or there are more than one customer types with the ID of " + TypeID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new CustomerType();
			}
		}

		/// <summary>
		/// Gets a System.Data.DataTable of all available customer types
		/// </summary>
		/// <returns></returns>
		public DataTable GetCustomerTypes()
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `ref_customer_types` t WHERE t.`is_available` = 1 ORDER BY t.`name`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("There are no available customer types.");

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
