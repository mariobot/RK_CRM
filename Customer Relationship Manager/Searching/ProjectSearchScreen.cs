using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Navigation;
using rkcrm.Objects.Customer;
using rkcrm.Objects.Note;
using rkcrm.Objects.Project;
using rkcrm.Objects.Quote;
using rkcrm.Searching.DropDowns;

namespace rkcrm.Searching
{
    class ProjectSearchScreen : SearchScreenBase
    {

		#region Variables

		private System.Windows.Forms.GroupBox gbxQuotes;
		private System.Windows.Forms.GroupBox gbxNotes;
		private System.Windows.Forms.ColumnHeader chProjectID;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chCustomer;
		private System.Windows.Forms.ColumnHeader chType;
		private System.Windows.Forms.ColumnHeader chAddress;
		private System.Windows.Forms.ColumnHeader chCity;
		private System.Windows.Forms.ListView lvwQuotes;
		private System.Windows.Forms.ListView lvwNotes;
		private System.Windows.Forms.ColumnHeader chNoteID;
		private System.Windows.Forms.ColumnHeader chFollowedUp;
		private System.Windows.Forms.ColumnHeader chPurpose;
		private System.Windows.Forms.ColumnHeader chContacted;
		private System.Windows.Forms.ColumnHeader chSalesRep;
		private System.Windows.Forms.ColumnHeader chContactMethod;
		private System.Windows.Forms.ColumnHeader chQuoteID;
		private System.Windows.Forms.ColumnHeader chDepartment;
		private System.Windows.Forms.ColumnHeader chRep;
		private System.Windows.Forms.ColumnHeader chQuoteName;
		private System.Windows.Forms.ColumnHeader chAmount;
		private System.Windows.Forms.ColumnHeader chStatus;
		private ColumnHeader chNoteCustomerID;
		private ColumnHeader chNoteProjectID;
		private ColumnHeader chProjectCustomerID;
		private ColumnHeader chQuoteCustomerID;
		private ColumnHeader chQuoteProjectID;
		private ColumnHeader chQuoteDepartmentID;
		private System.Windows.Forms.ColumnHeader chContact;
		private const int ADMINISTRATOR = 1;

		#endregion


		#region Methods

		/// <summary>
		/// Clears the rkcrm.Searching.ProjectSearchScreen of all data
		/// </summary>
        private new void Clear()
        {
			base.Clear();

			ClearResults();
        }

		/// <summary>
		/// Clears the data from all controls that display search results
		/// </summary>
        private new void ClearResults()
        {
			base.ClearResults();
			ClearPreview();
        }

		/// <summary>
		/// Clears all data from controls that show preview information
		/// </summary>
		private void ClearPreview()
		{
			//These if statements ensure that the ItemSelectionChanged event is fired for the System.Windows.Forms.ListView objects
			if (lvwNotes.SelectedItems.Count > 0)
				lvwNotes.SelectedItems[0].Selected = false;

			if (lvwQuotes.SelectedItems.Count > 0)
				lvwQuotes.SelectedItems[0].Selected = false;

			lvwNotes.Items.Clear();
			lvwNotes.Sorting = SortOrder.None;
			lvwNotes.ListViewItemSorter = null;
			lvwQuotes.Items.Clear();
			lvwQuotes.Sorting = SortOrder.None;
			lvwQuotes.ListViewItemSorter = null;
		}

		private void InitializeComponent()
		{
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chCustomer = new System.Windows.Forms.ColumnHeader();
			this.chType = new System.Windows.Forms.ColumnHeader();
			this.chAddress = new System.Windows.Forms.ColumnHeader();
			this.chCity = new System.Windows.Forms.ColumnHeader();
			this.chContact = new System.Windows.Forms.ColumnHeader();
			this.gbxNotes = new System.Windows.Forms.GroupBox();
			this.lvwNotes = new System.Windows.Forms.ListView();
			this.chNoteID = new System.Windows.Forms.ColumnHeader();
			this.chNoteCustomerID = new System.Windows.Forms.ColumnHeader();
			this.chNoteProjectID = new System.Windows.Forms.ColumnHeader();
			this.chFollowedUp = new System.Windows.Forms.ColumnHeader();
			this.chPurpose = new System.Windows.Forms.ColumnHeader();
			this.chContacted = new System.Windows.Forms.ColumnHeader();
			this.chSalesRep = new System.Windows.Forms.ColumnHeader();
			this.chContactMethod = new System.Windows.Forms.ColumnHeader();
			this.gbxQuotes = new System.Windows.Forms.GroupBox();
			this.lvwQuotes = new System.Windows.Forms.ListView();
			this.chQuoteID = new System.Windows.Forms.ColumnHeader();
			this.chQuoteCustomerID = new System.Windows.Forms.ColumnHeader();
			this.chQuoteProjectID = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chRep = new System.Windows.Forms.ColumnHeader();
			this.chQuoteName = new System.Windows.Forms.ColumnHeader();
			this.chAmount = new System.Windows.Forms.ColumnHeader();
			this.chStatus = new System.Windows.Forms.ColumnHeader();
			this.chProjectCustomerID = new System.Windows.Forms.ColumnHeader();
			this.chQuoteDepartmentID = new System.Windows.Forms.ColumnHeader();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.gbxNotes.SuspendLayout();
			this.gbxQuotes.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwResults
			// 
			this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProjectID,
            this.chProjectCustomerID,
            this.chName,
            this.chCustomer,
            this.chType,
            this.chAddress,
            this.chCity,
            this.chContact});
			this.lvwResults.DoubleClick += new System.EventHandler(this.lvwResults_DoubleClick);
			this.lvwResults.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwResults_ItemSelectionChanged);
			// 
			// btnClearSearch
			// 
			this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// scMain
			// 
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Controls.Add(this.gbxQuotes);
			this.scMain.Panel2.Controls.Add(this.gbxNotes);
			// 
			// chProjectID
			// 
			this.chProjectID.Text = "Project ID";
			this.chProjectID.Width = 0;
			// 
			// chName
			// 
			this.chName.Text = "Project Name";
			this.chName.Width = 150;
			// 
			// chCustomer
			// 
			this.chCustomer.Text = "Customer Name";
			this.chCustomer.Width = 150;
			// 
			// chType
			// 
			this.chType.Text = "Project Type";
			this.chType.Width = 100;
			// 
			// chAddress
			// 
			this.chAddress.Text = "Street Address";
			this.chAddress.Width = 200;
			// 
			// chCity
			// 
			this.chCity.Text = "City";
			this.chCity.Width = 100;
			// 
			// chContact
			// 
			this.chContact.Text = "Contact";
			this.chContact.Width = 100;
			// 
			// gbxNotes
			// 
			this.gbxNotes.Controls.Add(this.lvwNotes);
			this.gbxNotes.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxNotes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbxNotes.Location = new System.Drawing.Point(3, 3);
			this.gbxNotes.Name = "gbxNotes";
			this.gbxNotes.Size = new System.Drawing.Size(592, 119);
			this.gbxNotes.TabIndex = 0;
			this.gbxNotes.TabStop = false;
			this.gbxNotes.Text = "Notes";
			// 
			// lvwNotes
			// 
			this.lvwNotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNoteID,
            this.chNoteCustomerID,
            this.chNoteProjectID,
            this.chFollowedUp,
            this.chPurpose,
            this.chContacted,
            this.chSalesRep,
            this.chContactMethod});
			this.lvwNotes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvwNotes.FullRowSelect = true;
			this.lvwNotes.HideSelection = false;
			this.lvwNotes.Location = new System.Drawing.Point(3, 22);
			this.lvwNotes.MultiSelect = false;
			this.lvwNotes.Name = "lvwNotes";
			this.lvwNotes.Size = new System.Drawing.Size(586, 94);
			this.lvwNotes.TabIndex = 0;
			this.lvwNotes.UseCompatibleStateImageBehavior = false;
			this.lvwNotes.View = System.Windows.Forms.View.Details;
			this.lvwNotes.DoubleClick += new System.EventHandler(this.lvwNotes_DoubleClick);
			// 
			// chNoteID
			// 
			this.chNoteID.Text = "Note ID";
			this.chNoteID.Width = 0;
			// 
			// chNoteCustomerID
			// 
			this.chNoteCustomerID.Width = 0;
			// 
			// chNoteProjectID
			// 
			this.chNoteProjectID.Width = 0;
			// 
			// chFollowedUp
			// 
			this.chFollowedUp.Text = "Followed Up On";
			this.chFollowedUp.Width = 90;
			// 
			// chPurpose
			// 
			this.chPurpose.Text = "Purpose";
			this.chPurpose.Width = 100;
			// 
			// chContacted
			// 
			this.chContacted.Text = "Person Contacted";
			this.chContacted.Width = 150;
			// 
			// chSalesRep
			// 
			this.chSalesRep.Text = "Sales Rep";
			this.chSalesRep.Width = 100;
			// 
			// chContactMethod
			// 
			this.chContactMethod.Text = "Contact Method";
			this.chContactMethod.Width = 150;
			// 
			// gbxQuotes
			// 
			this.gbxQuotes.Controls.Add(this.lvwQuotes);
			this.gbxQuotes.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxQuotes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbxQuotes.Location = new System.Drawing.Point(3, 122);
			this.gbxQuotes.Name = "gbxQuotes";
			this.gbxQuotes.Size = new System.Drawing.Size(592, 100);
			this.gbxQuotes.TabIndex = 1;
			this.gbxQuotes.TabStop = false;
			this.gbxQuotes.Text = "Quotes";
			// 
			// lvwQuotes
			// 
			this.lvwQuotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQuoteID,
            this.chQuoteCustomerID,
            this.chQuoteProjectID,
            this.chQuoteDepartmentID,
            this.chDepartment,
            this.chRep,
            this.chQuoteName,
            this.chAmount,
            this.chStatus});
			this.lvwQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwQuotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvwQuotes.FullRowSelect = true;
			this.lvwQuotes.HideSelection = false;
			this.lvwQuotes.Location = new System.Drawing.Point(3, 22);
			this.lvwQuotes.MultiSelect = false;
			this.lvwQuotes.Name = "lvwQuotes";
			this.lvwQuotes.Size = new System.Drawing.Size(586, 75);
			this.lvwQuotes.TabIndex = 1;
			this.lvwQuotes.UseCompatibleStateImageBehavior = false;
			this.lvwQuotes.View = System.Windows.Forms.View.Details;
			this.lvwQuotes.DoubleClick += new System.EventHandler(this.lvwQuotes_DoubleClick);
			// 
			// chQuoteID
			// 
			this.chQuoteID.Text = "Quote ID";
			this.chQuoteID.Width = 0;
			// 
			// chQuoteCustomerID
			// 
			this.chQuoteCustomerID.Text = "Customer ID";
			this.chQuoteCustomerID.Width = 0;
			// 
			// chQuoteProjectID
			// 
			this.chQuoteProjectID.Text = "Project ID";
			this.chQuoteProjectID.Width = 0;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 80;
			// 
			// chRep
			// 
			this.chRep.Text = "Sales Rep";
			this.chRep.Width = 90;
			// 
			// chQuoteName
			// 
			this.chQuoteName.Text = "Quote Number";
			this.chQuoteName.Width = 150;
			// 
			// chAmount
			// 
			this.chAmount.Text = "Amount";
			this.chAmount.Width = 100;
			// 
			// chStatus
			// 
			this.chStatus.Text = "Status";
			this.chStatus.Width = 100;
			// 
			// chProjectCustomerID
			// 
			this.chProjectCustomerID.Text = "Customer ID";
			this.chProjectCustomerID.Width = 0;
			// 
			// chQuoteDepartmentID
			// 
			this.chQuoteDepartmentID.Width = 0;
			// 
			// ProjectSearchScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "ProjectSearchScreen";
			this.ScreenTitle = "Project Search";
			this.Load += new System.EventHandler(this.ProjectSearchScreen_Load);
			this.Controls.SetChildIndex(this.scMain, 0);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel1.PerformLayout();
			this.scMain.Panel2.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.gbxNotes.ResumeLayout(false);
			this.gbxQuotes.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        private void InitializeDropDown()
        {
            int index = 0;

            using (ProjectDropDown myItems = new ProjectDropDown(lvwResults, 0, 1))
            {
                while (myItems.Items.Count > 0 && index < myItems.Items.Count)
                {
                    if (myItems.Items[index] is ToolStripDropDownButton)
						while (((ToolStripDropDownButton)myItems.Items[index]).DropDownItems.Count > 0)
							tsmActions.DropDownItems.Add(((ToolStripDropDownButton)myItems.Items[index]).DropDownItems[0]);
                    index++;
                }
            }

            index = 0;

			using (ProjectDropDown myItems = new ProjectDropDown(lvwResults, 0, 1))
            {
                while (myItems.Items.Count > 0 && index < myItems.Items.Count)
                {
                    if (myItems.Items[index] is ToolStripDropDownButton)
                    {
						while (((ToolStripDropDownButton)myItems.Items[index]).DropDownItems.Count > 0)
							cmsResults.Items.Add(((ToolStripDropDownButton)myItems.Items[index]).DropDownItems[0]);
                        index++;
                    }
                    else
                        tsMain.Items.Add(myItems.Items[index]);
                }
            }

			using (NoteDropDown noteItems = new NoteDropDown(lvwNotes, 0, 2, 1))
			{
				ToolStripDropDownButton theButton = (ToolStripDropDownButton)noteItems.Items["tdbMenuItems"];
				ContextMenuStrip cmsNote = new ContextMenuStrip();

				while (theButton.DropDownItems.Count > 0)
					cmsNote.Items.Add(theButton.DropDownItems[0]);

				lvwNotes.ContextMenuStrip = cmsNote;
				
			}

			using (QuoteDropDown quoteItems = new QuoteDropDown(lvwQuotes, 0, 1, 2, 3, 8))
			{
				ToolStripDropDownButton menuItems = (ToolStripDropDownButton)quoteItems.Items["tdbMenuItems"];
				ContextMenuStrip cmsQuote = new ContextMenuStrip();

				while (menuItems.DropDownItems.Count > 0)
					cmsQuote.Items.Add(menuItems.DropDownItems[0]);

				lvwQuotes.ContextMenuStrip = cmsQuote;
			}
        }

		private void ShowResults()
		{
			DataTable dtResults;

			using (ProjectController theController = new ProjectController())
			{
				dtResults = theController.GetSearchResults(cboSearchIn.SelectedValue.ToString(), txtLookFor.Text);
			}

			if (dtResults.Rows.Count > 0)
				try
				{
					ListViewItem newItem;

					foreach (DataRow oRow in dtResults.Rows)
					{
						if (thisUser.RoleID == ADMINISTRATOR || !Convert.ToBoolean(oRow["is_archived"]))
						{
							newItem = new ListViewItem();
							newItem.Text = oRow["project_id"].ToString();
							newItem.SubItems.Add(oRow["customer_id"].ToString());
							newItem.SubItems.Add(oRow["project"].ToString());
							newItem.SubItems.Add(oRow["customer"].ToString());
							newItem.SubItems.Add(oRow["type"].ToString());
							newItem.SubItems.Add(oRow["address"].ToString());
							newItem.SubItems.Add(oRow["city"].ToString());
							newItem.SubItems.Add(oRow["contact_name"].ToString());

							if(Convert.ToBoolean(oRow["is_archived"]))
								newItem.BackColor = Color.LightSteelBlue;

							lvwResults.Items.Add(newItem);
						}
					}
				}
				catch (Exception e)
				{
					Error_Handling.ErrorHandler.ProcessException(e, false);
				}
			else
				ShowResultsMessage("No projects were found with a " + cboSearchIn.Text + " of \"" + txtLookFor.Text + "\".");
		}

		private void ShowPreview(ListViewItem selectedItem)
		{
			DataSet dsPreview;

			using (ProjectController theController = new ProjectController())
			{
				dsPreview = theController.GetSearchPreview(Convert.ToInt32(selectedItem.SubItems[0].Text), thisUser.RoleID == ADMINISTRATOR);
			}

			if (dsPreview.Tables.Count > 1)
			{
				ListViewItem newItem;

				if (dsPreview.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow oRow in dsPreview.Tables[0].Rows)
					{
						newItem = new ListViewItem();
						newItem.Text = oRow["note_id"].ToString();
						newItem.SubItems.Add(oRow["customer_id"].ToString());
						newItem.SubItems.Add(oRow["project_id"].ToString());
						newItem.SubItems.Add(oRow["completed"] == DBNull.Value ? string.Empty : Convert.ToDateTime(oRow["completed"]).ToShortDateString());
						newItem.SubItems.Add(oRow["purpose"].ToString());
						newItem.SubItems.Add(oRow["contact_name"].ToString());
						newItem.SubItems.Add(oRow["sales_rep"].ToString());
						newItem.SubItems.Add(oRow["method"].ToString());

						if (Convert.ToBoolean(oRow["is_archived"]))
							newItem.BackColor = Color.LightSteelBlue;
						else
							newItem.BackColor = Color.White;

						lvwNotes.Items.Add(newItem);
					}
				}

				if (dsPreview.Tables[1].Rows.Count > 0)
				{
					foreach (DataRow oRow in dsPreview.Tables[1].Rows)
					{
						newItem = new ListViewItem();
						newItem.Text = oRow["quote_id"].ToString();
						newItem.SubItems.Add(oRow["customer_id"].ToString());
						newItem.SubItems.Add(oRow["project_id"].ToString());
						newItem.SubItems.Add(oRow["department_id"].ToString());
						newItem.SubItems.Add(oRow["department"].ToString());
						newItem.SubItems.Add(oRow["sales_rep"].ToString());
						newItem.SubItems.Add(oRow["name"].ToString());
						newItem.SubItems.Add(oRow["amount"].ToString());
						newItem.SubItems.Add(oRow["status"].ToString());

						if (Convert.ToBoolean(oRow["is_archived"]))
							newItem.BackColor = Color.LightSteelBlue;
						else
							newItem.BackColor = Color.White;

						lvwQuotes.Items.Add(newItem);
					}
				}
			}
		}

		#endregion


		#region Event Handlers

		private void btnSearch_Click(object sender, EventArgs e)
		{
			//Clear any previous results
			ClearResults();

			ShowResults();

			IsDisposable = false;
		}

		private void btnClearSearch_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void ProjectSearchScreen_Load(object sender, EventArgs e)
		{
			InitializeDropDown();
		}

		private void lvwResults_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
				ShowPreview(e.Item);
			else
				ClearPreview();
		}

		private void lvwResults_DoubleClick(object sender, EventArgs e)
		{
			if (lvwResults.SelectedItems.Count > 0)
			{
				NavigationScreen myNavigation = GetNavigationScreen();
				myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1];

				using (CustomerController theController = new CustomerController())
				{
					myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(lvwResults.SelectedItems[0].SubItems[1].Text));
				}

				myNavigation.btnCustomer.PerformClick();

				using (ProjectController theController = new ProjectController())
				{
					((ProjectScreen)myNavigation.CurrentScreen).MyProject = theController.GetProject(Convert.ToInt32(lvwResults.SelectedItems[0].SubItems[0].Text));
				}
			}
		}

		private void lvwNotes_DoubleClick(object sender, EventArgs e)
		{
			if (lvwNotes.SelectedItems.Count > 0)
			{
				NavigationScreen myNavigation = GetNavigationScreen();
				myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[0];

				using (CustomerController theController = new CustomerController())
				{
					myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(lvwNotes.SelectedItems[0].SubItems[1].Text));
				}
				using (ProjectController theController = new ProjectController())
				{
					myNavigation.btnCustomer.MyProject = theController.GetProject(Convert.ToInt32(lvwNotes.SelectedItems[0].SubItems[2].Text));
				}

				myNavigation.btnCustomer.PerformClick();

				((NoteScreen)myNavigation.CurrentScreen).MyProject = myNavigation.btnCustomer.MyProject;

				using (NoteController theController = new NoteController())
				{
					((NoteScreen)myNavigation.CurrentScreen).MyNote = theController.GetNote(Convert.ToInt32(lvwNotes.SelectedItems[0].SubItems[0].Text));
				}
			}
		}

		private void lvwQuotes_DoubleClick(object sender, EventArgs e)
		{
			if (lvwQuotes.SelectedItems.Count > 0)
			{
				NavigationScreen myNavigation = GetNavigationScreen();
				myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[1];

				using (CustomerController theController = new CustomerController())
				{
					myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(lvwQuotes.SelectedItems[0].SubItems[1].Text));
				}
				using (ProjectController theController = new ProjectController())
				{
					myNavigation.btnCustomer.MyProject = theController.GetProject(Convert.ToInt32(lvwQuotes.SelectedItems[0].SubItems[2].Text));
				}

				myNavigation.btnCustomer.PerformClick();

				using (QuoteController theController = new QuoteController())
				{
					((QuoteScreen)myNavigation.CurrentScreen).MyQuote = theController.GetQuote(Convert.ToInt32(lvwQuotes.SelectedItems[0].SubItems[0].Text));
				}
			}
		}

		#endregion


		#region Constructor

		public ProjectSearchScreen()
			: base()
		{
			InitializeComponent();

			//Populate the search in combo box
			DataTable oSearchInValues = new DataTable();
			oSearchInValues.Columns.Add("Column_Name");
			oSearchInValues.Columns.Add("Description");

			oSearchInValues.Rows.Add("p.`name`", "Project Name");
			oSearchInValues.Rows.Add("c.`name`", "Company Name");
			oSearchInValues.Rows.Add("p.`address`", "Address");
			oSearchInValues.Rows.Add("p.`city`", "City");
			oSearchInValues.Rows.Add("`contact_name`", "Contact");
			oSearchInValues.Rows.Add("pt.`name`", "Project Type");

			cboSearchIn.DataSource = oSearchInValues;
			cboSearchIn.DisplayMember = "Description";
			cboSearchIn.ValueMember = "Column_Name";
		}

		#endregion


    }
}
