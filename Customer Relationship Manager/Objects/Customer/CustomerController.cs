using System;
using System.Collections.Generic;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Customer
{
	/// <summary>
	/// Contains methods to retrieve and manipulate customer data
	/// </summary>
	class CustomerController : EntityBase
	{
		/// <summary>
		/// Gets a list of inidividual words (longer that 3 characters) within the FullText
		/// </summary>
		/// <param name="FullText"></param>
		/// <returns></returns>
		private List<string> GetWords(string FullText)
		{
			List<string> theList = new List<string>();
			string word = string.Empty;

			foreach (char oChar in FullText.ToCharArray())
				if (!(char.IsWhiteSpace(oChar)))
					word += oChar;
				else
				{
					if (word.Length > 3)
						theList.Add(word);

					word = string.Empty;
				}

			//so the last word is added to the list
			if (word.Length > 3)
				theList.Add(word);

			return theList;

		}

		/// <summary>
		/// Queries customer data based on the ColumnName and Criteria provided
		/// </summary>
		/// <param name="ColumnName"></param>
		/// <param name="Criteria"></param>
		/// <returns>System.Data.DataTable</returns>
		public DataTable GetSearchResults(string ColumnName, string Criteria)
		{
			DataTable results = new DataTable();
			string Select;
			string From;
			string Where;
			string Having = string.Empty;
			string GroupBy;
			
			Where = "WHERE d.`is_profit_center` = 1 ";

			switch (ColumnName)
			{
				case "ContactName":
					Having = "HAVING `ContactName` LIKE '%" + Criteria + "%' ";
					GroupBy = "GROUP BY `ContactName`, ";
					break;
				case "phone_number":
					int index = 0;

					foreach (char oChar in Criteria.ToCharArray())
					{
						if (!char.IsNumber(oChar))
							Criteria.Remove(index, 1);
						index++;
					}

					Where += "AND (cup.`" + ColumnName + "` LIKE '%" + Criteria + "%' OR cop.`" + ColumnName + "` LIKE '%" + Criteria + "%') ";
					GroupBy = " GROUP BY `" + ColumnName + "`, ";
					break;
				case "view_all":
					GroupBy = "GROUP BY ";
					break;
				default:
					Where += "AND " + ColumnName + " LIKE '%" + Criteria + "%' ";
					GroupBy = " GROUP BY " + ColumnName + ", ";
					break;
			}

			if (thisUser.HomeDepartment.IsProfitCenter)
			{
				Select = "SELECT c.`customer_id`, co.`contact_id`, d.`department_id`, IFNULL(cd.`is_active`, 1) AS `is_active`, c.`name` AS `customer`, " +
				"t.`name` AS `type`, cup.`phone_number`, co.`first_name`, co.`last_name`, cop.`phone_number` AS `contact_number`, co.`email_address`, " +
				"pt2.`abbreviation`, CONCAT(co.`first_name`, ' ', co.`last_name`) AS `ContactName`, c.`address`, c.`falcon_id` ";

				Where += "AND d.`department_id` = " + thisUser.HomeDepartment.ID + " ";

				GroupBy += "c.`customer_id`, co.`contact_id`, cop.`phone_number`, d.`department_id` ";
			}
			else
			{
				Select = "SELECT c.`customer_id`, co.`contact_id`, IF(cd.`is_active` IS NULL, 1, BIT_AND(cd.`is_active`)) AS `is_active`, c.`name` AS `customer`, " +
				"t.`name` AS `type`, cup.`phone_number`, co.`first_name`, co.`last_name`, cop.`phone_number` AS `contact_number`, co.`email_address`, " +
				"pt2.`abbreviation`, CONCAT(co.`first_name`, ' ', co.`last_name`) AS `ContactName`, c.`address`, c.`falcon_id` ";

				GroupBy += "c.`customer_id`, co.`contact_id`, cop.`phone_number` ";
			}
			
			From = "FROM ((`ref_departments` d, `customers` c) " +
				"LEFT JOIN `rel_customer_department` cd ON d.`department_id` = cd.`department_id` AND c.`customer_id` = cd.`customer_id`) " +
				"JOIN `ref_customer_types` t ON c.`type_id` = t.`type_id` " +
				"JOIN `link_customer_phonenumbers` lcp ON c.`customer_id` = lcp.`customer_id` " +
				"JOIN `phone_numbers` cup ON lcp.`phone_number_id` = cup.`phone_number_id` " +
				"LEFT JOIN `contacts` co ON c.`customer_id` = co.`customer_id` AND co.`is_archived` = 0 " +
				"JOIN `link_contact_phonenumbers` lc ON co.`contact_id` = lc.`contact_id` " +
				"JOIN `phone_numbers` cop ON lc.`phone_number_id` = cop.`phone_number_id` " +
				"LEFT JOIN `ref_phone_types` pt2 ON cop.`type_id` = pt2.`type_id` ";

			try
			{
				SQL = Select + From + Where + GroupBy + Having;

				InitializeCommand();
				OpenConnection();

				FillDataTable(results);

			}
			catch (Exception e)
			{
				Error_Handling.ErrorHandler.ProcessException(e, false);
			}

			return results;
		}

		/// <summary>
		/// Gets a list of projects, account information and sales history for a given customer
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <returns></returns>
		public DataSet GetSearchPreview(int CustomerID)
		{
			DataSet theData = new DataSet();

			SQL = "SELECT p.`project_id`, p.`customer_id`, p.`name`, p.`address`, p.`city`, pt.`name` AS `type`, p.`is_archived` " + 
				  "FROM `projects` p LEFT JOIN `ref_project_types` pt ON p.`type_id` = pt.`type_id` ";

			if (thisUser.RoleID == 1)
				SQL += "WHERE p.`customer_id` = " + CustomerID + "; ";
			else
				SQL += "WHERE p.`is_archived` = 0 AND p.`customer_id` = " + CustomerID + "; ";

			SQL += "SELECT c.`falcon_id`, c.`terms_code`, c.`first_sale`, c.`tax_id_expiration`, c.`creditcard_expiration` FROM `customers` c " +
				   "WHERE c.`customer_id` = " + CustomerID + "; ";

			SQL += "SELECT d.`name`, cd.`last_sale`, i.`amount`, i.`sales_rep`, i.`invoice_terms`, " +
				   "(SELECT SUM(y.`amount`) FROM `invoices` y WHERE y.`customer_id` = cd.`customer_id` AND y.`falcon_whs` = d.`falcon_whs` AND " +
				   "    y.`invoiced` >= CONVERT(CONCAT(YEAR(CURDATE()),'-01-01') USING latin1)) AS `ytd_sales`, " +
				   "(SELECT SUM(y.`amount`) FROM `invoices` y WHERE y.`customer_id` = cd.`customer_id` AND y.`falcon_whs` = d.`falcon_whs` AND " +
				   "    y.`invoiced` BETWEEN CONVERT(CONCAT(YEAR(CURDATE()) - 1,'-01-01') USING latin1) AND CONVERT(CONCAT(YEAR(CURDATE()),'-01-01') USING latin1)) AS `last_year_sales` " +
				   "FROM `invoices` i " +
				   "JOIN `ref_departments` d ON i.`falcon_whs` = d.`falcon_whs` " +
				   "JOIN `rel_customer_department` cd ON i.`customer_id` = cd.`customer_id` AND d.`department_id` = cd.`department_id` AND i.`invoiced` = cd.`last_sale` " +
				   "WHERE i.`customer_id` = " + CustomerID + " GROUP BY d.`name`;";

			try
			{
				InitializeCommand();
				OpenConnection();

				FillDataSet(theData);
			}
			catch(Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return theData;
		}

		/// <summary>
		/// Gets a list of department ID's and a value that determine whether the customer is active in that department
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <returns></returns>
		public DataTable GetActivityStatuses(int CustomerID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT cd.`department_id`, cd.`is_active` FROM `rel_customer_department` cd WHERE cd.`customer_id` = " + CustomerID + " ORDER BY cd.`department_id`;";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("The customer id, " + CustomerID + ", is not associated with any department.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		/// <summary>
		/// Returns a value that determines whether the customer is active for a particular department
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <param name="DepartmentID"></param>
		/// <returns></returns>
		internal bool IsActive(int CustomerID, int DepartmentID)
		{
			bool result = true;

			try
			{
				SQL = "SELECT cd.`is_active` FROM `rel_customer_department` cd WHERE cd.`customer_id` = " + CustomerID + " AND cd.`department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				result = Convert.ToBoolean(Command.ExecuteScalar());
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}

			return result;
		}

		/// <summary>
		/// Activates the customer in a given department
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <param name="DepartmentID"></param>
		public void Activate(int CustomerID, int DepartmentID)
		{
			try
			{
				SQL = "UPDATE `customers` c SET c.`updated` = NOW(), c.`updater_id` = " + thisUser.ID + " WHERE c.`customer_id` = " + CustomerID + "; " +
					"UPDATE `rel_customer_department` cd SET cd.`is_active` = 1 WHERE cd.`customer_id` = " + CustomerID + " AND cd.`department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				if(ExecuteStoredProcedure() == 0)
					throw new Exception("The customer ID, " + CustomerID + ", was not marked as active for department, " + DepartmentID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		/// <summary>
		/// deactivates the customer in a given department
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <param name="DepartmentID"></param>
		public void Deactivate(int CustomerID, int DepartmentID)
		{
			try
			{
				SQL = "UPDATE `customers` c SET c.`updated` = NOW(), c.`updater_id` = " + thisUser.ID + " WHERE c.`customer_id` = " + CustomerID + "; " +
					"UPDATE `rel_customer_department` cd SET cd.`is_active` = 0 WHERE cd.`customer_id` = " + CustomerID + " AND cd.`department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				if(ExecuteStoredProcedure() == 0)
					throw new Exception("The customer ID, " + CustomerID + ", was not marked as inactive for department, " + DepartmentID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		/// <summary>
		/// Activates the customer in all departments
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <param name="DepartmentID"></param>
		public void ActivateAll(int CustomerID)
		{
			try
			{
				SQL = "UPDATE `customers` c SET c.`updated` = NOW(), c.`updater_id` = " + thisUser.ID + " WHERE c.`customer_id` = " + CustomerID + "; " +
					"UPDATE `rel_customer_department` cd SET cd.`is_active` = 1 WHERE cd.`customer_id` = " + CustomerID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The customer ID, " + CustomerID + ", was not marked as active.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		/// <summary>
		/// Deactivates the customer in all departments
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <param name="DepartmentID"></param>
		public void DeactivateAll(int CustomerID)
		{
			try
			{
				SQL = "UPDATE `customers` c SET c.`updated` = NOW(), c.`updater_id` = " + thisUser.ID + " WHERE c.`customer_id` = " + CustomerID + "; " +
					"UPDATE `rel_customer_department` cd SET cd.`is_active` = 0 WHERE cd.`customer_id` = " + CustomerID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The customer ID, " + CustomerID + ", was not marked as inactive.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

        /// <summary>
        /// Gets a all invoices for a given customer
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
		public DataTable GetInvoices(int CustomerID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT i.`order_id`, i.`invoice_id`, d.`name`, i.`invoiced`, i.`amount`, i.`sales_rep`, i.`entered_by`, " +
					"i.`account_terms`, i.`invoice_terms` " +
					"FROM `invoices` i " +
					"JOIN `ref_departments` d ON i.`falcon_whs` = d.`falcon_whs` " +
					"WHERE i.`customer_id` = " + CustomerID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				return oTable;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public DataTable GetInvoices(int CustomerID, string ColumnName, string Criteria)
		{
			try
			{
				DataTable oTable = new DataTable();
				string oWhere = string.Empty;

				switch (ColumnName)
				{
					case "i.`invoiced`":
						DateTime theDate = DateTime.Parse(Criteria);
						oWhere = ColumnName + " = '" + theDate.ToString("yyyy-MM-dd") + "'";
						break;
					default:
						oWhere = ColumnName + " LIKE '%" + Criteria + "%'";
						break;
				}

				SQL = "SELECT i.`order_id`, i.`invoice_id`, d.`name`, i.`invoiced`, i.`amount`, i.`sales_rep`, i.`entered_by`, " +
					"i.`account_terms`, i.`invoice_terms` " +
					"FROM `invoices` i " +
					"JOIN `ref_departments` d ON i.`falcon_whs` = d.`falcon_whs` " +
					"WHERE i.`customer_id` = " + CustomerID + " AND " + oWhere + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				return oTable;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		/// <summary>
		/// Updated the customer data on the database
		/// </summary>
		/// <param name="theCustomer"></param>
		public bool UpdateCustomer(Customer theCustomer)
		{
			try
			{
				//Get the original data for the customer
				Customer origCustomer = GetCustomer(theCustomer.ID);


				SQL = "UPDATE `customers` c SET ";

				//Determine which fields should be included in the update
				if (origCustomer.Name != theCustomer.Name)
					SQL += "c.`name` = '" + BuildSafeString(theCustomer.Name.ToUpper()) + "', ";

				if (origCustomer.Address != theCustomer.Address)
					SQL += "c.`address` = '" + BuildSafeString(theCustomer.Address.ToUpper()) + "', ";

				if (origCustomer.City != theCustomer.City)
					SQL += "c.`city` = '" + BuildSafeString(theCustomer.City.ToUpper()) + "', ";

				if (origCustomer.State != theCustomer.State)
					SQL += "c.`state` = '" + BuildSafeString(theCustomer.State.ToUpper()) + "', ";

				if (origCustomer.ZipCode != theCustomer.ZipCode)
				{
					if (theCustomer.ZipCode == 0)
						SQL = "c.`zip_code` = NULL, ";
					else
						SQL += "c.`zip_code` = " + theCustomer.ZipCode + ", ";
				}

				if (origCustomer.AptLotSte != theCustomer.AptLotSte)
					SQL += "c.`apt_lot_ste` = '" + BuildSafeString(theCustomer.AptLotSte.ToUpper()) + "', ";

				if (origCustomer.TypeID != theCustomer.TypeID)
					SQL += "c.`type_id` = " + theCustomer.TypeID + ", ";

				if (origCustomer.FalconID != theCustomer.FalconID)
					SQL += "c.`falcon_id` = '" + BuildSafeString(theCustomer.FalconID.ToUpper()) + "', ";

				if (origCustomer.TermsCode != theCustomer.TermsCode)
					SQL += "c.`terms_code` = '" + BuildSafeString(theCustomer.TermsCode.ToUpper()) + "', ";

				if (origCustomer.TaxIDExpiration != theCustomer.TaxIDExpiration)
				{
					if (theCustomer.TaxIDExpiration == DateTime.MinValue)
						SQL += "c.`tax_id_expiration` = NULL, ";
					else
						SQL += "c.`tax_id_expiration` = '" + theCustomer.TaxIDExpiration.ToString("yyyy/MM/dd") + "', ";
				}

				if (origCustomer.CreditCardExpiration != theCustomer.CreditCardExpiration)
				{
					if (theCustomer.CreditCardExpiration == DateTime.MinValue)
						SQL += "c.`creditcard_expiration` = NULL, ";
					else
						SQL += "c.`creditcard_expiration` = '" + theCustomer.CreditCardExpiration.ToString("yyyy/MM/dd") + "', ";
				}

				if (origCustomer.CannotCrossLead != theCustomer.CannotCrossLead)
					SQL += " c.`cannot_cross_lead` = " + theCustomer.CannotCrossLead + ", ";

				//Finish off the SQL statement and send it to the server
				SQL += "c.`updated` = NOW(), c.`updater_id` = " + thisUser.ID + " WHERE c.`customer_id` = " + theCustomer.ID + ";";

				InitializeCommand();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The customer with ID, " + theCustomer.ID + ", was not updated.");

				if (origCustomer.PhoneNumber != theCustomer.PhoneNumber)
				{
					using (Phone_Number.PhoneNumberController theController = new rkcrm.Objects.Phone_Number.PhoneNumberController())
					{
						if (theController.DoesExist(theCustomer.PhoneNumber))
						{
							theController.RemoveAllCustomerLinks(theCustomer.ID);
							theController.LinkCustomer(theCustomer.PhoneNumber, theCustomer.ID);
						}
						else
							if (theController.IsInUse(origCustomer.PhoneNumber, theCustomer.ID))
							{
								//Create the new number
								Phone_Number.PhoneNumber theNumber = new Phone_Number.PhoneNumber();
								theNumber.Number = theCustomer.PhoneNumber;
								theNumber = theController.InsertPhoneNumber(theNumber);

								if (theNumber.ID > 0)
								{
									//Remove any links
									theController.RemoveAllCustomerLinks(theCustomer.ID);

									//Link the customer to it
									theController.LinkCustomer(theCustomer.PhoneNumber, theCustomer.ID);
								}
							}
							else
							{
								//Get the original phone number object
								Phone_Number.PhoneNumber theNumber = origCustomer.GetPhoneNumber();

								//Change the phone number to the new rendering
								theNumber.Number = theCustomer.PhoneNumber;

								//Send it to the controller to be updated
								theController.UpdatePhoneNumber(theNumber);
							}

					}
				}

				return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
			
		}

		public Customer InsertCustomer(Customer newCustomer)
		{
			try
			{
				SQL = "INSERT INTO `customers` SET " +
					"`name` = '" + BuildSafeString(newCustomer.Name) + "', " +
					"`address` = '" + BuildSafeString(newCustomer.Address) + "', " +
					"`city` = '" + BuildSafeString(newCustomer.City) + "', " +
					"`state` = '" + BuildSafeString(newCustomer.State) + "', " +
					"`zip_code` = " + newCustomer.ZipCode + ", " +
					"`apt_lot_ste` = '" + BuildSafeString(newCustomer.AptLotSte) + "', " +
					"`type_id` = " + newCustomer.TypeID + ", " +
					"`created` = NOW(), " +
					"`creator_id` = " + thisUser.ID + ", " +
					"`updated` = NOW(), " +
					"`updater_id` = " + thisUser.ID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save customer.");
				else
				{
					int newCustomerID;
					SQL = "SELECT MAX(c.`customer_id`) FROM `customers` c;";
					InitializeCommand();

					newCustomerID = Convert.ToInt32(Command.ExecuteScalar());

					using (Phone_Number.PhoneNumberController theController = new rkcrm.Objects.Phone_Number.PhoneNumberController())
					{
						if (theController.DoesExist(newCustomer.PhoneNumber))
							theController.LinkCustomer(newCustomer.PhoneNumber, newCustomerID);
						else
						{
							//Create the new number
							Phone_Number.PhoneNumber theNumber = new Phone_Number.PhoneNumber();
							theNumber.Number = newCustomer.PhoneNumber;
							theNumber = theController.InsertPhoneNumber(theNumber);

							if (theNumber.ID > 0)
								theController.LinkCustomer(theNumber.ID, newCustomerID);
						}
					}					

					return GetCustomer(newCustomerID);
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return newCustomer;
			}
		}

		/// <summary>
		/// Gets a rkcrm.Objects.Customer.Customer object based on the customer id provided
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <returns></returns>
		public Customer GetCustomer(int CustomerID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT c.*, p.`phone_number` FROM `customers` c " +
					"JOIN `link_customer_phonenumbers` cp ON c.`customer_id` = cp.`customer_id` " +
					"JOIN `phone_numbers` p ON cp.`phone_number_id` = p.`phone_number_id` " +
					"WHERE c.`customer_id` = " + CustomerID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new Customer(oTable.Rows[0]);
				else
					throw new Exception("The customer ID either doesn't exist or there are more than one customers with the ID of " + CustomerID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		/// <summary>
		/// Gets a System.Data.DataTable object that contains a list of all phone numbers owned by the customer or its contacts
		/// </summary>
		/// <param name="CustomerID"></param>
		/// <returns></returns>
		public DataTable GetPhoneNumbers(int CustomerID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT p.`phone_number_id`, p.`phone_number` FROM `customers` c " +
					"JOIN `link_customer_phonenumbers` cup ON c.`customer_id` = cup.`customer_id` " +
					"JOIN `phone_numbers` p ON cup.`phone_number_id` = p.`phone_number_id` " +
					"WHERE c.`customer_id` = " + CustomerID + " " +
					"UNION " +
					"SELECT p.`phone_number_id`, p.`phone_number` FROM `contacts` c " +
					"JOIN `link_contact_phonenumbers` cop ON c.`contact_id` = cop.`contact_id` " +
					"JOIN `phone_numbers` p ON cop.`phone_number_id` = p.`phone_number_id` " +
					"WHERE c.`customer_id` = " + CustomerID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count > 0)
					return oTable;
				else
					throw new Exception("This customer does not have a phone number.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public DataTable GetRelatedCustomers(int CustomerID)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT " +
					"    c.`customer_id`, " +
					"    c.`name` AS `customer` " +
					"FROM `link_customer_phonenumbers` cp " +
					"JOIN `link_customer_phonenumbers` p ON cp.`customer_id` != p.`customer_id` AND cp.`phone_number_id` = p.`phone_number_id` " +
					"JOIN `customers` c ON c.`customer_id` = p.`customer_id` " +
					"WHERE cp.`customer_id` = " + CustomerID + " " +
					"UNION " +
					"SELECT " +
					"    cu.`customer_id`, " +
					"    cu.`name` AS `customer` " +
					"FROM `link_contact_phonenumbers` cp " +
					"JOIN `contacts` co ON cp.`contact_id` = co.`contact_id` " +
					"JOIN ( " +
					"        SELECT " +
					"            p.`phone_number_id`, " +
					"            co.`customer_id` " +
					"        FROM `link_contact_phonenumbers` p " +
					"        JOIN `contacts` co ON p.`contact_id` = co.`contact_id` " +
					"     ) cop ON co.`customer_id` != cop.`customer_id` AND cp.`phone_number_id` = cop.`phone_number_id` " +
					"JOIN `customers` cu ON cu.`customer_id` = cop.`customer_id` " +
					"WHERE co.`customer_id` = " + CustomerID + ";";
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

		public DataTable GetDuplicateCustomers(Customer theCustomer)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT c.`customer_id`, c.`name`, p.`phone_number`, t.`name` AS `type`, c.`address`, " +
					"CONCAT(u.`first_name`, ' ' , u.`last_name`) AS `creator`, t.`require_unique_name` " +
					"FROM `customers` c " +
					"JOIN `link_customer_phonenumbers` cp ON c.`customer_id` = cp.`customer_id` " +
					"JOIN `phone_numbers` p ON cp.`phone_number_id` = p.`phone_number_id` " +
					"JOIN `ref_customer_types` t ON c.`type_id` = t.`type_id` " +
					"JOIN `users` u ON c.`creator_id` = u.`user_id`" +
					"WHERE c.`name` LIKE '" + theCustomer.Name + "' AND NOT c.`customer_id` = " + theCustomer.ID + ";";

				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				return oTable;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public DataTable GetDuplicateCustomers(string Name, int CustomerID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT c.`customer_id`, c.`name`, p.`phone_number`, t.`name` AS `type`, c.`address`, " +
					"CONCAT(u.`first_name`, ' ' , u.`last_name`) AS `creator`, t.`require_unique_name` " +
					"FROM `customers` c " +
					"JOIN `link_customer_phonenumbers` cp ON c.`customer_id` = cp.`customer_id` " +
					"JOIN `phone_numbers` p ON cp.`phone_number_id` = p.`phone_number_id` " +
					"JOIN `ref_customer_types` t ON c.`type_id` = t.`type_id` " +
					"JOIN `users` u ON c.`creator_id` = u.`user_id`" +
					"WHERE c.`name` LIKE '" + Name + "' AND NOT c.`customer_id` = " + CustomerID + ";";

				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				return oTable;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public void LogDuplicateOccurance(Customer theCustomer, string EnteredName, int DuplicatesCount, string ButtonClicked)
		{
			try
			{
				SQL = "INSERT INTO `log_similar_name` (`original_name`, `new_name`, `possible_matches`, `button_chosen`, `is_name_valid`, `updater_id`, `updated`) " +
					"VALUES ('" + theCustomer.Name + "', '" + EnteredName + "', " + DuplicatesCount + ", '" + ButtonClicked + "', " + 
					theCustomer.GetCustomerType().RequireUniqueName + ", " + thisUser.ID + ", NOW());";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Log duplicate name occurance failed.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

	}
}
