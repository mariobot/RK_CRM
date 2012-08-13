using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Cross_Lead
{
	class CrossLeadController : EntityBase
	{


		#region Methods

		public CrossLead GetCrossLead(int LeadID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `cross_leads` cl WHERE cl.`lead_id` = " + LeadID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new CrossLead(oTable.Rows[0]);
				else
					throw new Exception("The cross lead ID either doesn't exist or there is more than one cross lead with the ID of " + LeadID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return null;
			}
		}

		public DataTable GetCrossLeads(int ProjectID)
		{
			DataTable oTable = new DataTable();
			
			try
			{
				SQL = "SELECT cl.*, CONCAT(u.`first_name`, ' ', u.`last_name`) AS `sender`, CONCAT(at.`first_name`, ' ', at.`last_name`) AS `owner`, d.`name` AS `department` " +
					"FROM `cross_leads` cl " +
					"JOIN `users` u ON cl.`sender_id` = u.`user_id` " +
					"JOIN `rel_crosslead_department` cd ON cl.`lead_id` = cd.`lead_id` " +
					"JOIN `ref_departments` d ON cd.`department_id` = d.`department_id` " +
					"LEFT JOIN `users` at ON cd.`owner_id` = at.`user_id` " +
					"WHERE cl.`project_id` = " + ProjectID + ";";
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

		public CrossLead InsertCrossLead(CrossLead newLead, List<int> Departments)
		{
			try
			{
				SQL = "INSERT INTO `cross_leads` SET " +
					"`project_id` = " + newLead.ProjectID + ", " +
					"`plan_id` = " + newLead.PlanID + ", " +
					"`customer_has_details` = " + newLead.CustomerHasDetails + ", " +
					"`is_digital_available` = " + newLead.IsDigitalAvailable + ", " +
					"`is_paper_available` = " + newLead.IsPaperAvailable + ", " +
					"`is_list_available` = " + newLead.IsListAvailable + ", " +
					"`bid_due` = " + (newLead.BidDue != DateTime.MinValue ? "'" + newLead.BidDue.ToString("yyyy-MM-dd") + "'" : "NULL") + ", " +
					"`notes` = '" + BuildSafeString(newLead.Notes) + "', " +
					"`sent` = NOW(), " +
					"`sender_id` = " + thisUser.ID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save the cross lead for project, " + newLead.ProjectID + ".");
				else
				{
					SQL = "SELECT MAX(cl.`lead_id`) FROM `cross_leads` cl WHERE cl.`project_id` = " + newLead.ProjectID + ";";
					InitializeCommand();

					newLead = GetCrossLead(Convert.ToInt32(Command.ExecuteScalar()));

					SQL = "INSERT INTO `rel_crosslead_department` (`lead_id`, `department_id`) VALUES ";

					foreach (int dept in Departments)
					{
						SQL += "(" + newLead.ID + ", " + dept + ")";

						if (Departments.IndexOf(dept) != Departments.Count - 1)
							SQL += ", ";
						else
							SQL += ";";
					}
					InitializeCommand();

					ExecuteStoredProcedure();

					return newLead;
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return newLead;
			}
		}

		public bool UpdateCrossLead(CrossLead theLead)
		{
			CrossLead orig = GetCrossLead(theLead.ID);

			try
			{
				SQL = "UPDATE `cross_leads` cl SET ";
				
				if (orig.ProjectID != theLead.ProjectID)
					SQL += "";
				if (orig.PlanID != theLead.PlanID)
					SQL += "";
				if (orig.CustomerHasDetails != theLead.CustomerHasDetails)
					SQL += "";
				if (orig.IsDigitalAvailable != theLead.IsDigitalAvailable)
					SQL += "";
				if (orig.IsListAvailable != theLead.IsListAvailable)
					SQL += "";
				if (orig.IsPaperAvailable != theLead.IsPaperAvailable)
					SQL += "";
				if (orig.BidDue != theLead.BidDue)
					SQL += "";
				if (orig.Notes != theLead.Notes)
					SQL += "";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The cross lead with ID, " + theLead.ID + ", was not updated.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal void SendNotifications(List<int> SelectedDepartments, CrossLead theLead)
		{
			SmtpClient client = new SmtpClient("Young");

			using (MailMessage theMessage = new MailMessage())
			{
				try
				{
					if (MySettings.Mode == MySettings.applicationMode.Live)
					{
						using (Administration.User.UserController theContorller = new rkcrm.Administration.User.UserController())
						{
							foreach (DataRow oRow in theContorller.GetLeadRecievers(SelectedDepartments).Rows)
								theMessage.To.Add(oRow["email_address"].ToString());
						}

						theMessage.CC.Add(thisUser.EmailAddress);
					}
					else
						theMessage.To.Add(thisUser.EmailAddress);

					if (theMessage.To.Count > 0)
					{
						Project.Project theProject = theLead.GetProject();
						Customer.Customer theCustomer = theProject.GetCustomer();

						theMessage.From = new MailAddress(thisUser.EmailAddress);
						theMessage.Subject = "[CRM] Lead Notification";
						theMessage.Body = "This lead was sent to you by " + thisUser.FullName + "\n\r\n\r" +
							"Customer Name: " + theCustomer.Name + "\n\r" +
							"Project Name: " + theProject.Name + "\n\r" +
							"Project Type: " + theProject.GetProjectType().Name + "\n\r" +
							(theLead.BidDue > DateTime.MinValue ? "\n\r Bid Due By: " + theLead.BidDue.ToShortDateString() + "\n\r" : string.Empty) +
							(theLead.IsDigitalAvailable || theLead.IsListAvailable || theLead.IsPaperAvailable || theLead.CustomerHasDetails ? "\n\r Additional Information: \n\r" : string.Empty) +
							(theLead.IsPaperAvailable ? "\t-\tPaper Plans are available\n\r" : string.Empty) +
							(theLead.IsPaperAvailable ? "\t-\tPlan Tracking ID: " + theLead.PlanID.ToString() + "\n\r" : string.Empty) +
							(theLead.IsDigitalAvailable ? "\t-\tDigital Plans are available\n\r" : string.Empty) +
							(theLead.IsListAvailable ? "\t-\tA materials list is available\n\r" : string.Empty) +
							(theLead.CustomerHasDetails ? "\t-\tContact Customer for the details of the project.\n\r" : string.Empty) +
							(string.IsNullOrEmpty(theLead.Notes) ? string.Empty : "\n\rNotes:\n\r" + theLead.Notes);

						client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

						client.Send(theMessage);
					}

				}
				catch (SmtpFailedRecipientsException e0)
				{
					ErrorHandler.ProcessException(e0, false);
				}
				catch (SmtpException e1)
				{
					ErrorHandler.ProcessException(e1, false);
				}
				catch (Exception e2)
				{
					ErrorHandler.ProcessException(e2, false);
				}
			}

		}

		internal bool IsCrossLed(int ProjectID, int DeprtmentID)
		{
			bool result = false;

			try
			{
				SQL = "SELECT " +
					"    IF(cd.`lead_id` IS NULL, 0, 1) AS `exists` " +
					"FROM `cross_leads` cl " +
					"    LEFT JOIN `rel_crosslead_department` cd ON cl.`lead_id` = cd.`lead_id` AND cd.`department_id` = " + DeprtmentID + " " +
					"WHERE cl.`project_id` = " + ProjectID + "; ";
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

		#endregion


	}
}
