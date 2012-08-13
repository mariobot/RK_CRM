using System;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Note
{
	class NoteController : EntityBase
	{

		private const int OUTSTANDING = 1;

		public Note GetNote(int NoteID)
		{
			try
			{
				DataTable oTable = new DataTable();

				SQL = "SELECT * FROM `notes` n WHERE n.`note_id` = " + NoteID + ";";
				InitializeCommand();
				OpenConnection();

				FillDataTable(oTable);

				if (oTable.Rows.Count == 1)
					return new Note(oTable.Rows[0]);
				else
					throw new Exception("The note either does not exist or there is more than one note with ID of " + NoteID + ".");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return new Note();
			}
		}

		public DataTable GetNotes(int ProjectID, bool ShowAll)
		{
			DataTable oTable = new DataTable();
			
			try
			{
				SQL = "SELECT n.*, d.`name` AS `department`, p.`name` AS `purpose`, m.`name` AS `method`, " +
					"CONCAT(c.`first_name`, ' ', c.`last_name`) AS `contact`, CONCAT(sr.`first_name`, ' ', sr.`last_name`) AS `sales_rep` " +
					"FROM `notes` n " +
					"JOIN `users` sr ON n.`sales_rep_id` = sr.`user_id` " +
					"JOIN `ref_departments` d ON n.`department_id` = d.`department_id` " +
					"JOIN `ref_contact_methods` m ON n.`method_id` = m.`method_id` " +
					"JOIN `ref_contact_purposes` p ON n.`purpose_id` = p.`purpose_id` " +
					"JOIN `contacts` c ON n.`contact_id` = c.`contact_id` " +
					"WHERE n.`project_id` = " + ProjectID + (ShowAll ? " " : " AND n.`is_archived = 0 ") +
					"ORDER BY n.`created` DESC;";
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
		
		internal bool UpdateNote(Note theNote)
		{
			Note orig = GetNote(theNote.ID);

			try
			{
				SQL = "UPDATE `notes` n SET ";

				if (orig.ProjectID != theNote.ProjectID)
					SQL += "n.`project_id` = " + theNote.ProjectID + ", ";
				if (orig.Notes != theNote.Notes)
					SQL += "n.`notes` = '" + BuildSafeString(theNote.Notes) + "', ";
				if (orig.SalesRepID != theNote.SalesRepID)
					SQL += "n.`sales_rep_id` = " + theNote.SalesRepID + ", ";
				if (orig.SalesSupportID != theNote.SalesSupportID)
					SQL += "n.`support_id` = " + theNote.SalesSupportID + ", ";
				if (orig.DepartmentID != theNote.DepartmentID)
					SQL += "n.`department_id` = " + theNote.DepartmentID + ", ";
				if (orig.MethodID != theNote.MethodID)
					SQL += "n.`method_id` = " + theNote.MethodID + ", ";
				if (orig.PurposeID != theNote.PurposeID)
					SQL += "n.`purpose_id` = " + theNote.PurposeID + ", ";
				if (orig.ContactID != theNote.ContactID)
					SQL += "n.`contact_id` = " + theNote.ContactID + ", ";
				if (orig.NextFollowUp != theNote.NextFollowUp)
					SQL += "n.`next_follow_up` = " + (theNote.NextFollowUp != DateTime.MinValue ? "'" + theNote.NextFollowUp.ToString("yyyy/MM/dd") + "'" : "NULL") + ", ";
				if (orig.Completed != theNote.Completed)
					SQL += "n.`completed` = " + (theNote.Completed != DateTime.MinValue ? "'" + theNote.Completed.ToString("yyyy/MM/dd") + "'" : "NULL") + ", ";
				if (orig.IsArchived != theNote.IsArchived)
					SQL += "n.`is_archived` = " + theNote.IsArchived + ", ";

				//Finish off the SQL statement
				SQL += "n.`updated` = NOW(), n.`updater_id` = " + thisUser.ID + " WHERE n.`note_id` = " + theNote.ID + ";";

				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The note with ID, " + theNote.ID + ", was not updated.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal Note InsertNote(Note newNote)
		{
			try
			{
				SQL = "INSERT INTO `rkcrm_prototype`.`notes` (`project_id`, `notes`, `sales_rep_id`, `support_id`, " +
					"`department_id`, `method_id`, `purpose_id`, `contact_id`,`next_follow_up`, `completed`, `created`, " +
					"`creator_id`, `updated`, `updater_id`) " +
					"VALUES(" + newNote.ProjectID + ", '" + BuildSafeString(newNote.Notes) + "', " + newNote.SalesRepID + ", " + newNote.SalesSupportID +
					", " + newNote.DepartmentID + ", " + newNote.MethodID + ", " + newNote.PurposeID + ", " + newNote.ContactID +
					", " + (newNote.NextFollowUp != DateTime.MinValue ? "'" +newNote.NextFollowUp.ToString("yyyy/MM/dd") + "'" : "NULL") + 
					", " + (newNote.Completed != DateTime.MinValue ? "'" + newNote.Completed.ToString("yyyy/MM/dd") + "'" : "NULL") + 
					", NOW(), " + thisUser.ID +	", NOW(), " + thisUser.ID + ");";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to save note for project, " + newNote.ProjectID + ".");
				else
				{
					SQL = "SELECT MAX(n.`note_id`) FROM `notes`n WHERE n.`project_id` = " + newNote.ProjectID + ";";
					InitializeCommand();

					return GetNote(Convert.ToInt32(Command.ExecuteScalar()));
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return newNote;
			}
		}

		internal int GetOpenNoteCount(int ProjectID, int DepartmentID)
		{
			try
			{
				SQL = "SELECT COUNT(n.`note_id`) FROM `notes`n WHERE n.`is_archived` = 0 AND n.`next_follow_up` IS NOT NULL AND n.`completed` IS NULL AND " +
					"n.`project_id` = " + ProjectID + " AND n.`department_id` = " + DepartmentID + ";";
				InitializeCommand();
				OpenConnection();

				return Convert.ToInt32(Command.ExecuteScalar());
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return -1;
			}
		}

		internal bool ArchiveNote(int NoteID)
		{
			try
			{
				SQL = "UPDATE `notes` n SET n.`is_archived` = 1 WHERE n.`note_id` = " + NoteID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The note with ID, " + NoteID + ", was not archived.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal void ArchiveAllNotes(int ProjectID)
		{
			try
			{
				SQL = "UPDATE `notes` n SET " +
					"n.`is_archived` = 1, " +
					"n.`updated` = NOW(), " +
					"n.`updater_id` = " + thisUser.ID + " " +
					"WHERE n.`is_archived` = 0 AND n.`project_id` = " + ProjectID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The notes with project ID, " + ProjectID + ", were not archived.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		internal bool RestoreNote(int NoteID)
		{
			try
			{
				SQL = "UPDATE `notes` n SET n.`is_archived` = 0 WHERE n.`note_id` = " + NoteID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The note with ID, " + NoteID + ", was not archived.");
				else
					return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal DataTable getScheduledNotes(int UserID, DateTime end, bool showAll)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT n.*, p.`name` AS `project`, c.`name` AS `customer`, ph.`phone_number`, c.`customer_id` " +
					"FROM `notes` n " +
					"JOIN `projects` p ON n.`project_id` = p.`project_id` " +
					"JOIN `customers` c ON p.`customer_id` = c.`customer_id` " +
					"JOIN `link_customer_phonenumbers` cup ON c.`customer_id` = cup.`customer_id` " +
					"JOIN `phone_numbers` ph ON cup.`phone_number_id` = ph.`phone_number_id`" +
					"WHERE (n.`sales_rep_id` = " + UserID + (showAll ? " OR n.`support_id` = " + UserID + ")" : ")") + " AND n.`completed` IS NULL AND " +
					"	n.`is_archived` = 0 AND n.`next_follow_up` <= '" + end.ToString("yyyy-MM-dd") + "' " +
					"ORDER BY n.`next_follow_up` DESC;";
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

		internal void FollowUpOnAll(int ProjectID, int DepartmentID)
		{
			try
			{
				SQL = "UPDATE `notes` n SET " +
					"n.`completed` = '" + DateTime.Today.ToString("yyyy/MM/dd") + "', " +
					"n.`updated` = NOW(), " +
					"n.`updater_id` = " + thisUser.ID + " " +
					"WHERE n.`completed` IS NULL AND n.`is_archived` = 0 AND n.`department_id` = " + DepartmentID + " AND n.`project_id` = " + ProjectID + ";";

				InitializeCommand();
				OpenConnection();

				ExecuteStoredProcedure();
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		internal void RestoreAllNotes(int ProjectID)
		{
			try
			{
				SQL = "UPDATE `notes` n SET " +
					"n.`is_archived` = 0, " +
					"n.`updated` = NOW(), " +
					"n.`updater_id` = " + thisUser.ID + " " +
					"WHERE n.`project_id` = " + ProjectID + ";";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The notes with project ID, " + ProjectID + ", were not archived.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		internal void RestoreAllNotes(int ProjectID, DateTime Archived)
		{
			try
			{
				SQL = "UPDATE `notes` n SET " +
					"n.`is_archived` = 0, " +
					"n.`updated` = NOW(), " +
					"n.`updater_id` = " + thisUser.ID + " " +
					"WHERE n.`project_id` = " + ProjectID + " AND n.`updated` >= '" + Archived.ToString("yyyy/MM/dd HH:mm:ss") + "';";
				InitializeCommand();
				OpenConnection();

				if (ExecuteStoredProcedure() == 0)
					throw new Exception("The note with ID, " + ProjectID + ", was not archived.");
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
			}
		}

		internal DataTable GetOpenNotes(int CustomerID)
		{
			DataTable oTable = new DataTable();

			try
			{
				SQL = "SELECT " +
					"	n.*, " +
					"	p.`customer_id`, " +
					"	p.`name` AS `project`, " +
					"	cp.`name` AS `purpose`, " +
					"	d.`name` AS `department` " +
					"FROM `notes` n " +
					"	JOIN `projects` p ON n.`project_id` = p.`project_id` " +
					"	JOIN `ref_contact_purposes` cp ON n.`purpose_id` = cp.`purpose_id` " +
					"	JOIN `ref_departments` d ON n.`department_id` = d.`department_id` " +
					"WHERE " +
					"	n.`completed` IS NULL AND " +
					"	n.`purpose_id` NOT IN (11, 12, 13) AND " +
					"	p.`customer_id` = " + CustomerID + ";";
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
