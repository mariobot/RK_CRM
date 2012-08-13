using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using rkcrm.Error_Handling;
using rkcrm.Custom_Controls;

namespace rkcrm.Objects.Cross_Lead
{
	public partial class CrossLeadAssignments : Form
	{

		#region Variables

		private const int ADMINISTRATOR = 1;
		private int panel2Height;
		private const string DIRTY_FONT_FAMILY = "Arial Rounded MT Bold";
		private List<Assigment.Assignment> UpdatedAssignments;
		private bool IsDirty = false;
		private int CurrentProject = 0; //This is used to ensure that the preview data is loaded at the right time

		#endregion


		#region Properties

		#endregion


		#region Methods

		private void LoadDepartments()
		{
			using (rkcrm.Administration.Department.DepartmentController theController = new rkcrm.Administration.Department.DepartmentController())
			{
				tscDepartment.ComboBox.DataSource = theController.GetProfitCenters();
				tscDepartment.ComboBox.DisplayMember = "name";
				tscDepartment.ComboBox.ValueMember = "department_id";
			}
		}

		private void LoadSalesReps(int DepartmentID)
		{
			DataGridViewComboBoxColumn cbo = (DataGridViewComboBoxColumn)dgvCrossLeads.Columns[0];

			using (rkcrm.Administration.User.UserController theController = new rkcrm.Administration.User.UserController())
			{
				cbo.DataSource = theController.GetDepartmentReps(DepartmentID);
				cbo.DisplayMember = "name";
				cbo.ValueMember = "user_id";
			}
		}

		private void LoadData(int DepartmentID)
		{
			DataTable oTable;
			DataGridViewRow newRow;

			using (Assigment.AssignmentController theController = new Assigment.AssignmentController())
			{
				oTable = theController.GetAssignments(DepartmentID.ToString());
			}

			foreach (DataRow oRow in oTable.Rows)
			{
				newRow = new DataGridViewRow();
				newRow.CreateCells(dgvCrossLeads);

				newRow.SetValues(
					oRow["owner_id"],
					(oRow["plans_received"] != DBNull.Value ? Convert.ToDateTime(oRow["plans_received"]).ToShortDateString() : null),
					(oRow["expected_completion"] != DBNull.Value ? Convert.ToDateTime(oRow["expected_completion"]).ToShortDateString() : null),
					(oRow["Received"] != DBNull.Value ? Convert.ToDateTime(oRow["Received"]).ToShortDateString() : null), 
					oRow["Sender"],
					(oRow["assigned"] != DBNull.Value ? Convert.ToDateTime(oRow["assigned"]).ToShortDateString() : null),
					(oRow["First_Contact"] != DBNull.Value ? Convert.ToDateTime(oRow["First_Contact"]).ToShortDateString() : null),
					(oRow["Quote_Delivered"] != DBNull.Value ? Convert.ToDateTime(oRow["Quote_Delivered"]).ToShortDateString() : null), 
					oRow["customer_id"], 
					oRow["project_id"],
					oRow["lead_id"],
					oRow["department_id"]);

				if (oRow["Quote_Delivered"] != DBNull.Value || oRow["assigned"] != DBNull.Value)
					newRow.Visible = false;
				else
				{
					DateTime received = Convert.ToDateTime(oRow["Received"]);
					int hours = 0;

					switch (received.DayOfWeek)
					{
						case DayOfWeek.Sunday :
							hours = 48;
							break;
						case DayOfWeek.Friday :
							hours = 72;
							break;
						case DayOfWeek.Saturday :
							hours = 60;
							break;
						default :
							hours = 24;
							break;
					}

					if (oRow["assigned"] == DBNull.Value)
						if (received.AddHours(hours) < DateTime.Now)
							foreach (DataGridViewCell oCell in newRow.Cells)
								oCell.Style.BackColor = Color.IndianRed;
						else if(received.AddHours(4) < DateTime.Now)
							foreach (DataGridViewCell oCell in newRow.Cells)
								oCell.Style.BackColor = Color.Yellow;

					if(oRow["expected_completion"] != DBNull.Value)
						if(Convert.ToDateTime(oRow["expected_completion"]) < DateTime.Today)
							foreach (DataGridViewCell oCell in newRow.Cells)
								oCell.Style.BackColor = Color.IndianRed;
				}

				dgvCrossLeads.Rows.Add(newRow);
			}

		}

		private void LoadPreview()
		{
			if (dgvCrossLeads.CurrentRow != null)
			{
				CrossLead theLead;
				Project.Project theProject;
				Customer.Customer theCustomer;

				using (CrossLeadController theController = new CrossLeadController())
				{
					theLead = theController.GetCrossLead(Convert.ToInt32(dgvCrossLeads.CurrentRow.Cells["LeadID"].Value));
				}

				if (theLead != null)
				{
					theProject = theLead.GetProject();
					theCustomer = theProject.GetCustomer();

					crossLeadPreview1.LoadData(theLead);
					customerPreview1.LoadData(theCustomer);
					notePreview1.LoadNotes(theProject.ID);
					projectPreview1.LoadData(theProject);
					quotePreview1.LoadQuotes(theProject.ID);
				}
			}
		}

		private void ClearPreview()
		{
			crossLeadPreview1.Clear();
			customerPreview1.Clear();
			projectPreview1.Clear();
			notePreview1.Clear();
			quotePreview1.Clear();
			CurrentProject = 0;
		}

		private bool Save()
		{
			Assigment.Assignment theAssignment;

			IsDirty = false;

			using (Assigment.AssignmentController theController =  new Assigment.AssignmentController())
			{
				foreach (DataGridViewRow oRow in dgvCrossLeads.Rows)
					if (oRow.Cells["Received"].Style.Font != null && oRow.Cells["Received"].Style.Font.FontFamily.Name == DIRTY_FONT_FAMILY)
					{
						theAssignment = theController.GetAssignment(Convert.ToInt32(oRow.Cells["LeadID"].Value), Convert.ToInt32(oRow.Cells["DepartmentID"].Value));

						if (theAssignment != null)
						{
							theAssignment.OwnerID = Convert.ToInt32(oRow.Cells["AssignedTo"].Value);
							theAssignment.PlansReceived = (oRow.Cells["PlansReceived"].Value != null ? Convert.ToDateTime(oRow.Cells["PlansReceived"].Value) : DateTime.MinValue);
							theAssignment.ExpectedCompletion = (oRow.Cells["ExpectedCompletion"].Value != null ? Convert.ToDateTime(oRow.Cells["ExpectedCompletion"].Value) : DateTime.MinValue);
							theAssignment.AssignerID = thisUser.ID;
							theAssignment.Assigned = DateTime.Now;

							if (theController.UpdateAssignment(theAssignment))
							{
								UpdatedAssignments.Add(theAssignment);

								oRow.Cells["assigned"].Value = theAssignment.Assigned.ToShortDateString();
								
								foreach (DataGridViewCell oCell in oRow.Cells)
									oCell.Style = oRow.DefaultCellStyle;
							}
							else
								IsDirty = true;
						}
					}
			}
			
			return (UpdatedAssignments.Count > 0);
		}

		private void SendUpdateNotices()
		{
			SmtpClient client = new SmtpClient("Young");
			MailMessage theMessage;
			CrossLead theCrossLead;
			Project.Project theProject;
			Customer.Customer theCustomer;
			Administration.User.User theOwner;

			foreach (Assigment.Assignment theAssignment in UpdatedAssignments)
			{
				theOwner = theAssignment.GetOwner();

				if (theOwner != null)
				{
					try
					{
						theCrossLead = theAssignment.GetCrossLead();
						theProject = theCrossLead.GetProject();
						theCustomer = theProject.GetCustomer();

						if (MySettings.Mode == MySettings.applicationMode.Prototype || MySettings.Mode == MySettings.applicationMode.Demonstration)
							theMessage = new MailMessage(thisUser.EmailAddress, thisUser.EmailAddress);
						else
						{
							theMessage = new MailMessage(thisUser.EmailAddress, theOwner.EmailAddress);
							theMessage.Bcc.Add("chipc@randkaz.com");
						}

						theMessage.Subject = "[CRM] Cross Lead Assignment";

						theMessage.Body = "This Assignment was sent to you by " + thisUser.FullName + "\r\n\r\n" +
							"Cross Lead Sender: " + theCrossLead.GetCreator().FullName + "\r\n\r\n" +
							"Customer Name: " + theCustomer.Name + "\r\n" +
							"Project Name: " + theProject.Name + "\r\n" +
							"Project Type: " + theProject.GetProjectType().Name + "\r\n" +
							(theCrossLead.BidDue > DateTime.MinValue ? "\r\nBid Due By: " + theCrossLead.BidDue.ToShortDateString() + "\r\n" : string.Empty) +
							(theCrossLead.IsDigitalAvailable || theCrossLead.IsListAvailable || theCrossLead.IsPaperAvailable || theCrossLead.CustomerHasDetails ? "\r\nAdditional Information:\r\n" : string.Empty) +
							(theCrossLead.IsDigitalAvailable ? "\t-\tDigital plans are available\r\n" : string.Empty) +
							(theCrossLead.IsListAvailable ? "\t-\tA materials list is available\r\n" : string.Empty) +
							(theCrossLead.CustomerHasDetails ? "\t-\tContact the customer for the details of the project\r\n" : string.Empty) +
							(theCrossLead.IsPaperAvailable ? "\t-\tPaper plans are available\r\n\t\t-\tPlan Tracking ID: " + theCrossLead.PlanID.ToString() + "\r\n" : string.Empty) +
							(!string.IsNullOrEmpty(theCrossLead.Notes) ? "\r\nNotes:\r\n" + theCrossLead.Notes : string.Empty);

						client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
						client.Send(theMessage);

					}
					catch (SmtpFailedRecipientException e1)
					{
						MessageBox.Show("Failed to send the update notice to " + e1.FailedRecipient + ".");
						ErrorHandler.ProcessException(e1, false);
					}
					catch (SmtpException e2)
					{
						ErrorHandler.ProcessException(e2, false);
					}
					catch (Exception e)
					{
						ErrorHandler.ProcessException(e, false);
					}
				}
			}
		}

		#endregion


		#region Event Handlers

		private void CrossLeadAssignments_Load(object sender, EventArgs e)
		{
			LoadData(Convert.ToInt32(tscDepartment.ComboBox.SelectedValue));
		}

		private void tscDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tscDepartment.ComboBox.SelectedItem != null && tscDepartment.ComboBox.SelectedValue is uint)
			{
				int DepartmentID = Convert.ToInt32(tscDepartment.ComboBox.SelectedValue);

				dgvCrossLeads.Rows.Clear();

				LoadSalesReps(DepartmentID);
				LoadData(DepartmentID);

				lblTitle.Text = "Unassigned Cross Leads";
				ClearPreview();
			}
		}

		private void tsbUnassigned_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow oRow in dgvCrossLeads.Rows)
				oRow.Visible = (oRow.Cells[0].Value == DBNull.Value && oRow.Cells["Delivered"].Value == null);

			lblTitle.Text = "Unassigned Cross Leads";
			ClearPreview();
		}

		private void tsbAssigned_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow oRow in dgvCrossLeads.Rows)
				oRow.Visible = (oRow.Cells[0].Value != DBNull.Value && oRow.Cells["Delivered"].Value == null);

			lblTitle.Text = "Assigned Cross Leads";
			ClearPreview();
		}

		private void tsbCompleted_ButtonClick(object sender, EventArgs e)
		{
			ClearPreview();

			//Find the ToolStripMenuItem that is currently checked and show the corresponding set of completed cross leads
			foreach (ToolStripItem oItem in tsbCompleted.DropDownItems)
				if (oItem is ToolStripMenuItem)
					if (((ToolStripMenuItem)oItem).Checked)
						((ToolStripMenuItem)oItem).PerformClick();

		}

		private void tsmLast30_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow oRow in dgvCrossLeads.Rows)
				if (oRow.Cells["Delivered"].Value != null)
					oRow.Visible = (Convert.ToDateTime(oRow.Cells["Delivered"].Value) > DateTime.Today.AddDays(-30));
				else
					oRow.Visible = false;

			lblTitle.Text = "Completed Cross Leads For The Last 30 Days";
		}

		private void tsmLast60_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow oRow in dgvCrossLeads.Rows)
				if (oRow.Cells["Delivered"].Value != null)
					oRow.Visible = (Convert.ToDateTime(oRow.Cells["Delivered"].Value) > DateTime.Today.AddDays(-60));
				else
					oRow.Visible = false;

			lblTitle.Text = "Completed Cross Leads For The Last 60 Days";
		}

		private void tsmLast90_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow oRow in dgvCrossLeads.Rows)
				if (oRow.Cells["Delivered"].Value != null)
					oRow.Visible = (Convert.ToDateTime(oRow.Cells["Delivered"].Value) > DateTime.Today.AddDays(-90));
				else
					oRow.Visible = false;

			lblTitle.Text = "Completed Cross Leads For The Last 90 Days";
		}

		private void tsmViewAll_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow oRow in dgvCrossLeads.Rows)
				oRow.Visible = (oRow.Cells["Delivered"].Value != null);

			lblTitle.Text = "All Completed Cross Leads";
		}

		private void tsmCompletedItem_Click(object sender, EventArgs e)
		{
			((ToolStripMenuItem)sender).Checked = true;

			foreach (ToolStripItem oItem in tsbCompleted.DropDownItems)
				if (oItem is ToolStripMenuItem && !oItem.Equals(sender))
					((ToolStripMenuItem)oItem).Checked = false;
		}

		private void Preview_ExpandedChanged(object sender, EventArgs e)
		{
			panel2Height = 0;

			foreach(Control oControl in spcControls.Panel2.Controls)
				if(oControl is Base_Classes.PreviewBase)
					panel2Height += (((Base_Classes.PreviewBase)oControl).IsExpanded ? ((Base_Classes.PreviewBase)oControl).ExpandedHeight : 27);

			spcControls.Height = panel2Height + spcControls.SplitterDistance + spcControls.SplitterWidth;
		}

		private void spcControls_SplitterMoved(object sender, SplitterEventArgs e)
		{
			spcControls.Height = panel2Height + spcControls.SplitterDistance + spcControls.SplitterWidth;
		}

		private void dgvCrossLeads_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			Color orig = dgvCrossLeads.CurrentCell.Style.BackColor;
			DataGridViewCellStyle newStyle = new DataGridViewCellStyle();

			newStyle.Font = new Font(DIRTY_FONT_FAMILY, 9F, FontStyle.Regular);
			newStyle.BackColor = orig;

			foreach (DataGridViewCell oCell in dgvCrossLeads.CurrentRow.Cells)
				oCell.Style = newStyle;

			if (!IsDirty)
				IsDirty = true;
		}

		private void dgvCrossLeads_CurrentCellChanged(object sender, EventArgs e)
		{
			if (dgvCrossLeads.CurrentRow != null)
				if (Convert.ToInt32(dgvCrossLeads.CurrentRow.Cells["ProjectID"].Value) != CurrentProject)
				{
					LoadPreview();
					CurrentProject = Convert.ToInt32(dgvCrossLeads.CurrentRow.Cells["ProjectID"].Value);
				}
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if (Save())
			{
				SendUpdateNotices();
				tsbUnassigned.PerformClick();
			}
		}

		private void btnSendClose_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					SendUpdateNotices();

					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion


		#region Constructor

		public CrossLeadAssignments()
		{
			InitializeComponent();

			tsmLast30.Click += new EventHandler(tsmCompletedItem_Click);
			tsmLast60.Click += new EventHandler(tsmCompletedItem_Click);
			tsmLast90.Click += new EventHandler(tsmCompletedItem_Click);
			tsmViewAll.Click += new EventHandler(tsmCompletedItem_Click);

			LoadDepartments();

			if (thisUser.HomeDepartment.IsProfitCenter)
				tscDepartment.ComboBox.SelectedValue = thisUser.HomeDepartment.ID;

			LoadSalesReps(Convert.ToInt32(tscDepartment.ComboBox.SelectedValue));

			projectPreview1.IsExpanded = true;
			UpdatedAssignments = new List<Assigment.Assignment>();
		}

		#endregion

	}
}
