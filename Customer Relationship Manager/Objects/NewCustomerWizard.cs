using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Reminder_Module;

namespace rkcrm.Objects
{
	public partial class NewCustomerWizard : Form
	{

		#region Variables

		private int page = 0;
		private const int FORWARD = 1;
		private const int BACKWARD = -1;
		private const int CUSTOMER = 0;
		private const int PROJECT = 1;
		private const int QUOTE = 2;
		private const int NOTE = 3;
		private const int FOLLOW_UP_ON_QUOTES = 5;
		private const int PHONE_NUMBER_INDEX = 3;
		private const int COMPANY_INDEX = 6;
		private const int PHONE_TYPE_INDEX = 2;
		private Color ACTIVE_COLOR = Color.White;
		private Font ACTIVE_FONT = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		private Color INACTIVE_COLOR = Color.Silver;
		private Font INACTIVE_FONT = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		private List<Label> headerLabels = new List<Label>();
		private List<Panel> screens = new List<Panel>();
		private Project.Project.ProjectStatus theProjectStatus = rkcrm.Objects.Project.Project.ProjectStatus.Outstanding;

		#endregion


		#region Properties

		internal Customer.Customer MyCustomer
		{
			get { return customerControls.MyCustomer; }
		}

		#endregion


		#region Methods

		private void move(int direction)
		{
			screens[page].Dock = DockStyle.None;
			screens[page].Location = new Point(2500, 2500);

			if (direction == FORWARD)
			{
				headerLabels[page].Font = INACTIVE_FONT;

				if (page < NOTE)
					page += direction;
			}
			else
			{
				headerLabels[page].ForeColor = INACTIVE_COLOR;
				headerLabels[page].Font = INACTIVE_FONT;

				if (page > CUSTOMER)
					page += direction;
			}

			ManageButtons();
			PassData();

			headerLabels[page].ForeColor = ACTIVE_COLOR;
			headerLabels[page].Font = ACTIVE_FONT;

			screens[page].Dock = DockStyle.Fill;
		}

		private void GoToPage(int PageID)
		{
			while(PageID != page)
			{
				if(PageID < page)
					move(BACKWARD);
				else
					move(FORWARD);
			}
		}

		private void PassData()
		{
			rkcrm.Base_Classes.BoundaryBase.BoundaryState origState;

			switch (page)
			{
				case PROJECT:
					origState = projectControls.State;
					projectControls.State = rkcrm.Base_Classes.BoundaryBase.BoundaryState.Loading;

					if (customerControls.MyCustomer.GetCustomerType().DefaultProjectName)
						projectControls.txtName.Text = customerControls.txtName.Text;

					string contact = contactControls.txtFirstName.Text.ToUpper() + " " + contactControls.txtLastName.Text.ToUpper();
					projectControls.cboContact.Text = contact;
					quoteControls.cboContact.Text = contact;
					noteControls.cboContact.Text = contact;

					lblProjectTitle.Text = "Project Information For " + customerControls.txtName.Text;

					projectControls.State = origState;
					break;
				case QUOTE:
					origState = quoteControls.State;
					quoteControls.State = rkcrm.Base_Classes.BoundaryBase.BoundaryState.Loading;

					quoteControls.cboDepartment.SelectedValue = customerControls.MyLeadSource.lbxDepartments.SelectedValue;
					quoteControls.MyProjectDepartment.SetDepartmentID(Convert.ToInt32(customerControls.MyLeadSource.lbxDepartments.SelectedValue));
					quoteControls.MyProjectDepartment.GetNextScope();
					lblQuoteTitle.Text = "Quote Information For " + projectControls.txtName.Text;

					quoteControls.State = origState;
					break;
				case NOTE:
					origState = noteControls.State;
					noteControls.State = rkcrm.Base_Classes.BoundaryBase.BoundaryState.Loading;

					if (quoteControls.IsDirty)
					{
						noteControls.cboDepartment.SelectedValue = quoteControls.cboDepartment.SelectedValue;
						noteControls.cboMethod.SelectedValue = quoteControls.cboMethod.SelectedValue;
						noteControls.cboPurpose.SelectedValue = FOLLOW_UP_ON_QUOTES;
						noteControls.cboSalesRep.SelectedValue = quoteControls.cboSalesRep.SelectedValue;
						noteControls.cboSupport.SelectedValue = quoteControls.cboSupport.SelectedValue;
					}
					else
						noteControls.cboDepartment.SelectedValue = customerControls.MyLeadSource.lbxDepartments.SelectedValue;

					lblNoteTitle.Text = "Note Information For " + projectControls.txtName.Text;

					noteControls.State = origState;
					break;
			}
		}

		private void ManageButtons()
		{

			btnBack.Enabled = !(page == CUSTOMER);

			if (!IsDirty())
			{
				if (page == QUOTE)
				{
					btnNext.Text = "Skip >";
					btnNext.Enabled = true;
				}
				else
				{
					btnNext.Text = "Next >";
					btnNext.Enabled = false;
				}
			}
			else
			{
				btnNext.Enabled = IsDirty();
				btnNext.Text = "Next >";
			}
		}

		private bool IsDirty()
		{
			bool result = true;

			switch (page)
			{
				case CUSTOMER:
					result = customerControls.IsDirty || customerControls.MyLeadSource.IsDirty || contactControls.IsDirty;
					break;
				case PROJECT:
					result = projectControls.IsDirty || crossLeadControls.IsDirty;
					break;
				case QUOTE:
					result = quoteControls.IsDirty;
					break;
				case NOTE:
					result = noteControls.IsDirty;
					break;
				default:
					break;
			}

			return result;
		}

		private bool CommitChanges()
		{
			bool result = true;

			switch (page)
			{
				case CUSTOMER:
					if (customerControls.MyLeadSource.lbxDepartments.SelectedItems.Count == 0)
					{
						int SelectedDepartmentID;
						Administration.Department.DepartmentSelect oForm = new Administration.Department.DepartmentSelect();

						using (Administration.Department.DepartmentController theController = new rkcrm.Administration.Department.DepartmentController())
						{
							oForm.DataSource = theController.GetProfitCenters();
							oForm.DisplayMember = "name";
							oForm.ValueMember = "department_id";
							oForm.SelectedItems.Clear();
						}

						oForm.SelectionMode = SelectionMode.One;
						oForm.ShowDialog();

						if (oForm.DialogResult == DialogResult.OK)
						{
							SelectedDepartmentID = Convert.ToInt32(((DataRowView)oForm.SelectedItems[0])["department_id"]);

							customerControls.MyLeadSource.lbxDepartments.SelectedValue = SelectedDepartmentID;
						}
					}

					result = contactControls.CommitChanges() && customerControls.CommitChanges() && customerControls.MyLeadSource.CommitChanges();
					break;
				case PROJECT:
					result = projectControls.CommitChanges() && (crossLeadControls.IsDirty ? crossLeadControls.CommitChanges() : true);
					break;
				case QUOTE:
					result = quoteControls.CommitChanges();
					break;
				case NOTE:
					result = noteControls.CommitChanges();
					break;
				default:
					break;
			}

			return result;
		}

		private bool CommitAllChanges()
		{
			bool result = true;
			int origPage = page;
			int offendingPage = -1;

			while (page <= NOTE && result)
			{
				if (IsDirty())
					result = CommitChanges();
				page++;
			}

			if (!result)
			{
				offendingPage = (page - 1);
				page = origPage;

				//Go to the page that contains the conflict
				GoToPage(offendingPage);
			}
			else
				page = origPage;

			return result;
		}

		private void Clear()
		{
			switch (page)
			{
				case CUSTOMER:
					contactControls.MyContact = new rkcrm.Objects.Contact.Contact();
					customerControls.MyLeadSource.MySource = new rkcrm.Objects.Customer.Lead_Source.LeadSource();
					customerControls.MyCustomer = new rkcrm.Objects.Customer.Customer();
					break;
				case PROJECT:
					projectControls.MyProject = new rkcrm.Objects.Project.Project();
					crossLeadControls.MyCrossLead = new rkcrm.Objects.Cross_Lead.CrossLead();
					break;
				case QUOTE:
					quoteControls.MyQuote = new rkcrm.Objects.Quote.Quote();
					break;
				case NOTE:
					noteControls.MyNote = new rkcrm.Objects.Note.Note();
					break;
				default:
					break;
			}

			PassData();
		}

		private bool SaveCustomer()
		{
			Customer.Lead_Source.LeadSource theSource;
			theSource = customerControls.MyLeadSource.MySource;

			using (Customer.CustomerController theController = new rkcrm.Objects.Customer.CustomerController())
			{
				customerControls.MyCustomer = theController.InsertCustomer(customerControls.MyCustomer);
			}

			theSource.CustomerID = customerControls.MyCustomer.ID;

			using (Customer.Lead_Source.LeadSourceController theController = new rkcrm.Objects.Customer.Lead_Source.LeadSourceController())
			{
				theSource = theController.InsertLeadSource(theSource);
			}

			return (customerControls.MyCustomer.ID > 0);
		}

		private bool SaveProject()
		{
			bool result;

			using (Project.ProjectController theController = new rkcrm.Objects.Project.ProjectController())
			{
				projectControls.MyProject = theController.InsertProject(projectControls.MyProject);

				result = (projectControls.MyProject.ID > 0);

				if (result)
					if (projectControls.LinkWithID > 0)
						projectControls.MyProject.LinkID = theController.Link(projectControls.MyProject, theController.GetProject(projectControls.LinkWithID));
			}

			return result;
		}

		private bool SaveCrossLead()
		{
			bool result = false;

			Cross_Lead.CrossLead theCrossLead = crossLeadControls.MyCrossLead;

			using (Cross_Lead.CrossLeadController theController = new Cross_Lead.CrossLeadController())
			{

				List<int> departments = new List<int>();
				foreach (object Item in crossLeadControls.lbxDepartments.SelectedItems)
				{
					departments.Add(Convert.ToInt32(((DataRowView)Item)["department_id"]));
				}

				theCrossLead = theController.InsertCrossLead(theCrossLead, departments);

				if (theCrossLead.ID > 0)
				{
					result = true;
					theController.SendNotifications(departments, theCrossLead);
				}
			}

			using (Cross_Sale.CrossSaleController theController = new Cross_Sale.CrossSaleController())
			{
				List<int> AvailableDepts = theController.GetAvailableDepartments(crossLeadControls.MyProject.CustomerID);
				Cross_Sale.CrossSale newCrossSale;

				foreach (object Item in crossLeadControls.lbxDepartments.SelectedItems)
				{
					foreach (int Dept in AvailableDepts)
					{
						if (Convert.ToInt32(((DataRowView)Item)["department_id"]) == Dept)
						{
							newCrossSale = new rkcrm.Objects.Cross_Sale.CrossSale();
							newCrossSale.CustomerID = crossLeadControls.MyProject.CustomerID;
							newCrossSale.DepartmentID = Dept;
							newCrossSale.LeadID = theCrossLead.ID;
							newCrossSale.SalesRepID = theCrossLead.CreatorID;

							theController.InsertCrossSale(newCrossSale);
						}
					}
				}
			}

			return result;
		}

		private bool SaveQuote()
		{
			bool succeeded;

			using (Project.Department.DepartmentController theController = new rkcrm.Objects.Project.Department.DepartmentController())
			{
				succeeded = theController.InsertDepartment(quoteControls.MyProjectDepartment);
			}

			if (succeeded)
			{
				using (Quote.QuoteController quoteController = new Quote.QuoteController())
				{
					quoteControls.MyQuote = quoteController.InsertQuote(quoteControls.MyQuote);
				}

				return (quoteControls.MyQuote.ID > 0);
			}
			else
				return false;
		}

		private bool SaveNote()
		{
			using (Note.NoteController theController = new Note.NoteController())
			{
				noteControls.MyNote = theController.InsertNote(noteControls.MyNote);
			}

			return noteControls.MyNote.ID > 0;
		}

		public bool GotoDuplicate()
		{
			DataTable oTable;

			using (Customer.CustomerController theController = new Customer.CustomerController())
			{
				oTable = theController.GetDuplicateCustomers(customerControls.txtName.Text, MyCustomer.ID);
			}

			if (oTable.Rows.Count != 0)
			{
				using (Customer.DuplicateCustomerList oForm = new Customer.DuplicateCustomerList(oTable, MyCustomer, customerControls.txtName.Text))
				{
					oForm.ShowDialog();

					if (oForm.DialogResult == DialogResult.Yes)
					{
						if (MessageBox.Show("Would you like to open that customer?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							//Find the Main form
							MainForm theMainForm = null;

							foreach (Form theForm in Application.OpenForms)
								if (theForm is MainForm)
									theMainForm = (MainForm)theForm;

							if (theMainForm != null)
							{
								//Navigate to the customer screen
								theMainForm.theNavigationScreen.btnCustomer.trvOptions.SelectedNode = theMainForm.theNavigationScreen.btnCustomer.trvOptions.Nodes[0];

								using (Customer.CustomerController theController = new Customer.CustomerController())
								{
									theMainForm.theNavigationScreen.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(oForm.SelectedItem.SubItems[0].Text));
								}
								theMainForm.theNavigationScreen.btnCustomer.PerformClick();

								return true;
							}
							else
								return false;
						}
						else
							return false;
					}
					else
						return false;
				}
			}
			else
				return false;
		}

		private void RefreshReminders()
		{
			RemindersForm theForm = null;

			foreach (Form oForm in Application.OpenForms)
				if (oForm is RemindersForm)
					theForm = (RemindersForm)oForm;

			if (theForm != null)
				theForm.RefreshData();
		}

		#endregion


		#region Event Handlers

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (IsDirty())
			{
				if (CommitChanges())
					move(FORWARD);
			}
			else
				if (page == QUOTE)
					move(FORWARD);
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			move(BACKWARD);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.Clear();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnFinish_Click(object sender, EventArgs e)
		{
			bool noteRequirementFulfilled = true;
			if (!GotoDuplicate())
			{
				if (CommitAllChanges())
				{
					if (quoteControls.IsDirty && !noteControls.IsDirty)
					{
						Note.AddNote oForm = new Note.AddNote(quoteControls.MyQuote);
						oForm.MyNote = noteControls.MyNote;
						oForm.ContactText = quoteControls.cboContact.Text;
						oForm.ShowDialog();

						noteRequirementFulfilled = (oForm.DialogResult == DialogResult.OK);
					}

					if (noteRequirementFulfilled)
					{
						try
						{
							if (SaveCustomer())
							{
								contactControls.MyContact.CustomerID = customerControls.MyCustomer.ID;
								projectControls.MyProject.CustomerID = customerControls.MyCustomer.ID;

								if (contactControls.Save())
								{
									projectControls.MyProject.ContactID = contactControls.MyContact.ID;
									quoteControls.MyQuote.ContactID = contactControls.MyContact.ID;
									noteControls.MyNote.ContactID = contactControls.MyContact.ID;

									if (projectControls.IsDirty)
									{
										if (SaveProject())
										{
											crossLeadControls.MyCrossLead.ProjectID = projectControls.MyProject.ID;
											crossLeadControls.MyProject = projectControls.MyProject;
											quoteControls.MyQuote.ProjectID = projectControls.MyProject.ID;
											quoteControls.MyProjectDepartment.SetProjectID(projectControls.MyProject.ID);
											noteControls.MyNote.ProjectID = projectControls.MyProject.ID;

											if (crossLeadControls.IsDirty)
												if (!SaveCrossLead())
													throw new Exception("An unexpected error occurred while attempting to save the cross lead data. Please contact your System Administrator.");

											if (quoteControls.IsDirty)
												if (!SaveQuote())
													throw new Exception("An unexpected error occurred while attempting to save the quote data. Please contact your System Administrator.");

											if (noteControls.IsDirty)
												if (!SaveNote())
													throw new Exception("An unexpected error occurred while attempting to save the note data. Please contact your System Administrator.");
										}
										else
											throw new Exception("An unexpected error occurred while attempting to save the project data. Please contact your System Administrator.");
									}
								}
								else
									throw new Exception("An unexpected error occurred while attempting to save the contact data. Please contact your System Administrator.");
							}
							else
								throw new Exception("An unexpected error occurred while attempting to save the customer data. Please contact your System Administrator.");

							RefreshReminders();

							this.DialogResult = DialogResult.OK;
							this.Close();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
				}
			}
			else
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}

		}

		private void Controls_IsDirtyChanged(object sender, EventArgs e)
		{
			switch (page)
			{
				case CUSTOMER:
					btnNext.Enabled = customerControls.IsDirty || (customerControls.MyLeadSource != null ? customerControls.MyLeadSource.IsDirty : false) || contactControls.IsDirty;
					break;
				case PROJECT:
					btnNext.Enabled = projectControls.IsDirty || crossLeadControls.IsDirty;
					break;
				case QUOTE:
					if (quoteControls.IsDirty)
						btnNext.Text = "Next >";
					else
						btnNext.Text = "Skip >";
					break;
				default:
					btnNext.Enabled = false;
					break;
			}

		}

		private void cboCustomerType_SelectedValueChanged(object sender, EventArgs e)
		{
			DataRowView selectedItem = (DataRowView)customerControls.cboCustomerType.SelectedItem;
			string contactName = contactControls.txtFirstName.Text + " " + contactControls.txtLastName.Text;

			if (selectedItem != null)
				if (Convert.ToBoolean(selectedItem["default_company_name"]))
				{
					int index = 0;
					DataGridView dvgPhones = contactControls.dgvPhoneNumbers;

					while (index < dvgPhones.RowCount && Convert.ToInt32(dvgPhones.Rows[index].Cells[PHONE_TYPE_INDEX].Value) != COMPANY_INDEX)
						index++;

					if (index == dvgPhones.RowCount)
						index = 0;

					customerControls.txtName.Text = contactName.Trim();

					if (!customerControls.mtxtPhoneNumber.MaskFull)
						customerControls.mtxtPhoneNumber.Text = contactControls.dgvPhoneNumbers.Rows[index].Cells[PHONE_NUMBER_INDEX].Value.ToString();
				}
		}

		private void btnSold_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Sold";
			lblStatus.ForeColor = Color.White;
			lblStatus.BackColor = Color.LimeGreen;
			quoteControls.MyQuote.IsSold = true;
			theProjectStatus = rkcrm.Objects.Project.Project.ProjectStatus.Sold;
		}

		private void btnLost_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Lost";
			lblStatus.ForeColor = Color.IndianRed;
			lblStatus.BackColor = Color.White;
			quoteControls.MyQuote.IsSold = false;
			theProjectStatus = rkcrm.Objects.Project.Project.ProjectStatus.Lost;
		}

		private void btnOustanding_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Outstanding";
			lblStatus.ForeColor = Color.Black;
			lblStatus.BackColor = Color.White;
			quoteControls.MyQuote.IsSold = false;
			theProjectStatus = rkcrm.Objects.Project.Project.ProjectStatus.Outstanding;
		}

		#endregion


		#region Constructor

		public NewCustomerWizard()
		{
			InitializeComponent();

			headerLabels.Add(lblCustomerPosition);
			headerLabels.Add(lblProjectPosition);
			headerLabels.Add(lblQuotePosition);
			headerLabels.Add(lblNotePosition);

			screens.Add(pnlCustomer);
			screens.Add(pnlProject);
			screens.Add(pnlQuote);
			screens.Add(pnlNote);

			//Make sure the customer page shows up first
			screens[1].Dock = DockStyle.None;
			screens[1].Location = new Point(2500, 2500);
			screens[2].Dock = DockStyle.None;
			screens[2].Location = new Point(2500, 2500);
			screens[3].Dock = DockStyle.None;
			screens[3].Location = new Point(2500, 2500);
			screens[0].Dock = DockStyle.Fill;

			//Put each boundary object into adding mode
			customerControls.MyCustomer = new rkcrm.Objects.Customer.Customer();
			contactControls.MyContact = new rkcrm.Objects.Contact.Contact();
			projectControls.MyProject = new rkcrm.Objects.Project.Project();
			crossLeadControls.MyCrossLead = new rkcrm.Objects.Cross_Lead.CrossLead();
			quoteControls.MyQuote = new rkcrm.Objects.Quote.Quote();
			noteControls.MyNote = new rkcrm.Objects.Note.Note();

			projectControls.gbxInfo.Visible = false;
			projectControls.gbxOthers.Visible = false;

			this.customerControls.MyLeadSource.IsDirtyChanged += new EventHandler<System.EventArgs>(this.Controls_IsDirtyChanged);
			this.customerControls.cboCustomerType.SelectedValueChanged += new EventHandler(cboCustomerType_SelectedValueChanged);
		}

		#endregion


	}
}
