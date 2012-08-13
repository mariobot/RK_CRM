using System;
using System.Collections.Generic;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Cross_Sale
{
	class CrossSaleController : EntityBase
	{


		#region Methods

		/// <summary>
		/// Gets a rkcrm.Objects.Cross_Sale.CrossSale objects for specific customer and department
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <param name="DepartmentID"></param>
		/// <returns></returns>
		public CrossSale GetCrossSale(int RelationshipID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT cc.* FROM `rel_crosslead_customer` cc " +
					"WHERE cc.`relationship_id` = " + RelationshipID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new CrossSale(oTable.Rows[0]);
				else
					throw new Exception("The cross sale ID either does not exist or there is more than one cross sale with a ID of, " +
						RelationshipID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		/// <summary>
		/// Gets a System.Collections.Generic.List of cross sales for the customer id provided
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <returns></returns>
		public DataTable GetValidCrossSales(int CustomerID)
		{
			DataTable theList = new DataTable();
			
			try
			{
				SQL = "SELECT cc.*, cl.`sender_id`, cl.`sent` FROM `rel_crosslead_customer` cc " +
					"LEFT JOIN `cross_leads` cl ON cc.`lead_id` = cl.`lead_id` " +
					"WHERE cc.`customer_id` = " + CustomerID + " AND cc.`is_archived` = 0;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(theList);
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return theList;
		}

		internal List<int> GetAvailableDepartments(int CustomerID)
		{
			List<int> theList = new List<int>();

			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT d.`department_id` " +
					"FROM (`ref_departments` d, `customers` c) " +
					"LEFT JOIN `projects` p ON c.`customer_id` = p.`customer_id` AND p.`is_archived` = 0 " +
					"LEFT JOIN `rel_project_department` pd ON p.`project_id` = pd.`project_id` AND d.`department_id` = pd.`department_id` " +
					"LEFT JOIN `notes` n ON n.`project_id` = p.`project_id` AND n.`department_id` = d.`department_id` AND n.`is_archived` = 0 AND DATE_ADD(n.`created`, INTERVAL 3 MONTH) > CURDATE() " +
					"LEFT JOIN `quotes` q ON q.`project_id` = p.`project_id` AND q.`department_id` = d.`department_id` AND q.`is_archived` = 0 AND DATE_ADD(q.`created`, INTERVAL 3 MONTH) > CURDATE() " +
					"LEFT JOIN `invoices` i ON i.`falcon_whs` = d.`falcon_whs` AND i.`customer_id` = c.`customer_id` AND  DATE_ADD(i.`invoiced`, INTERVAL 1 YEAR) > CURDATE() " +
					"LEFT JOIN `rel_crosslead_customer` cs ON cs.`customer_id` = c.`customer_id` AND cs.`department_id` = d.`department_id` AND cs.`is_archived` = 0 AND " +
					"    (DATE_ADD(cs.`verified`, INTERVAL 3 MONTH) > CURDATE() OR DATE_ADD(cs.`validated`, INTERVAL 1 YEAR) > CURDATE()) " +
					"WHERE d.`is_Profit_Center` = 1 AND (pd.`status` <> 3 OR pd.`status` IS NULL) AND c.`customer_id` = " + CustomerID + " " +
					"GROUP BY d.`department_id` " +
					"HAVING COUNT(DISTINCT n.`note_id`) + COUNT(DISTINCT q.`quote_id`) + COUNT(DISTINCT i.`invoice_id`) + COUNT(DISTINCT cs.`department_id`) = 0;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					foreach (DataRow oRow in oTable.Rows)
						theList.Add(Convert.ToInt32(oRow["department_id"]));

			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return theList;
		}

		internal CrossSale InsertCrossSale(CrossSale newCrossSale)
		{
			try
			{
				SQL = "INSERT INTO `rel_crosslead_customer` SET " +
					"`customer_id` = " + newCrossSale.CustomerID + ", " +
					"`department_id` = " + newCrossSale.DepartmentID + ", " +
					"`lead_id` = " + newCrossSale.LeadID + ", " +
					"`sales_rep_id` = " + newCrossSale.SalesRepID + ", " +
					"`verified` = " + (newCrossSale.Verified == DateTime.MinValue ? "NOW()" : "'" + newCrossSale.Verified.ToString("yyyy/MM/dd") + "'") + ", " +
					"`validated` = " + (newCrossSale.Validated == DateTime.MinValue ? "NULL" : "'" + newCrossSale.Validated.ToString("yyyy/MM/dd") + "'") + ", " +
					"`never_expires` = " + newCrossSale.NeverExpires + ", " +
					"`created` = NOW(), " +
					"`creator_id` = " + thisUser.ID + ", " +
					"`updated` = NOW(), " +
					"`updater_id` = " + thisUser.ID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save cross lead for customer, " + newCrossSale.CustomerID + ", and department, " + newCrossSale.DepartmentID + ".");
				else
				{
					SQL = "SELECT MAX(cc.`relationship_id`) FROM `rel_crosslead_customer` cc WHERE cc.`customer_id` = " + newCrossSale.CustomerID + ";";
					InitializeCommand();

					return GetCrossSale(Convert.ToInt32(Command.ExecuteScalar()));
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return newCrossSale;
			}
		}

		internal bool UpdateCrossSale(CrossSale theCrossSale)
		{
			CrossSale orig = GetCrossSale(theCrossSale.ID);

			try
			{
				SQL = "UPDATE `rel_crosslead_customer` c SET ";

				if (orig.CustomerID != theCrossSale.CustomerID)
					SQL += "c.`customer_id` = " + theCrossSale.CustomerID + ", ";
				if (orig.DepartmentID != theCrossSale.DepartmentID)
					SQL += "c.`department_id` = " + theCrossSale.DepartmentID + ", ";
				if (orig.LeadID != theCrossSale.LeadID)
					SQL += "c.`lead_id` = " + theCrossSale.LeadID + ", ";
				if (orig.SalesRepID != theCrossSale.SalesRepID)
					SQL += "c.`sales_rep_id` = " + theCrossSale.SalesRepID + ", ";
				if (orig.Verified != theCrossSale.Verified)
					SQL += "c.`verified` = " + (theCrossSale.Verified > DateTime.MinValue ? "'" + theCrossSale.Verified.ToString("yyyy/MM/dd") + "'" : "NULL") + ", ";
				if (orig.Validated != theCrossSale.Validated)
					SQL += "c.`validated` = " + (theCrossSale.Validated > DateTime.MinValue ? "'" + theCrossSale.Validated.ToString("yyyy/MM/dd") + "'" : "NULL") + ", ";
				if (orig.NeverExpires != theCrossSale.NeverExpires)
					SQL += "c.`never_expires` = " + theCrossSale.NeverExpires + ", ";
				if (orig.IsArchived != theCrossSale.IsArchived)
					SQL += "c.`is_archived` = " + theCrossSale.IsArchived + ", ";

				//Finish off the SQL statement
				SQL += "c.`updated` = NOW(), c.`updater_id` = " + thisUser.ID + " WHERE c.`relationship_id` = " + theCrossSale.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The cross sale with ID, " + theCrossSale.ID + ", was not updated.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal DataTable GetCrossSales(int CustomerID, bool showArchived)
		{
			DataTable results = new DataTable();

			try
			{
				SQL = "SELECT cc.*, d.`name` AS `department`, CONCAT(u.`first_name`, ' ', u.`last_name`) AS `sales_rep` " +
					"FROM `rel_crosslead_customer` cc  " +
					"JOIN `ref_departments` d ON cc.`department_id` = d.`department_id` " +
					"JOIN `users` u ON cc.`sales_rep_id` = u.`user_id` " +
					"WHERE " + (showArchived ? string.Empty : "cc.`is_archived` = 0 AND ") + "cc.`customer_id` = " + CustomerID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(results);
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return results;
		}

		#endregion


	}
}
