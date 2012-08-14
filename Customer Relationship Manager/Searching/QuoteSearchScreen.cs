using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Navigation;
using rkcrm.Objects.Customer;
using rkcrm.Objects.Project;
using rkcrm.Objects.Quote;
using rkcrm.Searching.DropDowns;

namespace rkcrm.Searching
{
    class QuoteSearchScreen : SearchScreenBase
    {

		#region Variables

		private System.Windows.Forms.ColumnHeader chQuoteID;
		private System.Windows.Forms.ColumnHeader chQuoteNumber;
		private System.Windows.Forms.ColumnHeader chAmount;
		private System.Windows.Forms.ColumnHeader chDepartment;
		private System.Windows.Forms.ColumnHeader chStatus;
		private System.Windows.Forms.ColumnHeader chCustomerName;
		private System.Windows.Forms.ColumnHeader chSalesRep;
		private ColumnHeader chCustomerID;
		private ColumnHeader chProjectID;
		private ColumnHeader chDepartmentID;
		private System.Windows.Forms.ColumnHeader chProjectName;
		private const int ADMINISTRATOR = 1;

		#endregion


        #region Methods

        private void InitializeComponent()
        {
			this.chQuoteID = new System.Windows.Forms.ColumnHeader();
			this.chQuoteNumber = new System.Windows.Forms.ColumnHeader();
			this.chAmount = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chStatus = new System.Windows.Forms.ColumnHeader();
			this.chProjectName = new System.Windows.Forms.ColumnHeader();
			this.chCustomerName = new System.Windows.Forms.ColumnHeader();
			this.chSalesRep = new System.Windows.Forms.ColumnHeader();
			this.chCustomerID = new System.Windows.Forms.ColumnHeader();
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.chDepartmentID = new System.Windows.Forms.ColumnHeader();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwResults
			// 
			this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQuoteID,
            this.chCustomerID,
            this.chProjectID,
            this.chDepartmentID,
            this.chQuoteNumber,
            this.chAmount,
            this.chDepartment,
            this.chStatus,
            this.chProjectName,
            this.chCustomerName,
            this.chSalesRep});
			this.lvwResults.Size = new System.Drawing.Size(598, 428);
			this.lvwResults.DoubleClick += new System.EventHandler(this.lvwResults_DoubleClick);
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
			this.scMain.Panel2Collapsed = true;
			// 
			// chQuoteID
			// 
			this.chQuoteID.Text = "Quote ID";
			this.chQuoteID.Width = 0;
			// 
			// chQuoteNumber
			// 
			this.chQuoteNumber.Text = "Quote Number";
			this.chQuoteNumber.Width = 150;
			// 
			// chAmount
			// 
			this.chAmount.Text = "Amount";
			this.chAmount.Width = 100;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 80;
			// 
			// chStatus
			// 
			this.chStatus.Text = "Project Status";
			this.chStatus.Width = 100;
			// 
			// chProjectName
			// 
			this.chProjectName.Text = "Project Name";
			this.chProjectName.Width = 150;
			// 
			// chCustomerName
			// 
			this.chCustomerName.Text = "Customer Name";
			this.chCustomerName.Width = 150;
			// 
			// chSalesRep
			// 
			this.chSalesRep.Text = "Sales Rep";
			this.chSalesRep.Width = 90;
			// 
			// chCustomerID
			// 
			this.chCustomerID.Text = "Customer ID";
			this.chCustomerID.Width = 0;
			// 
			// chProjectID
			// 
			this.chProjectID.Text = "Project ID";
			this.chProjectID.Width = 0;
			// 
			// chDepartmentID
			// 
			this.chDepartmentID.Text = "DepartmentID";
			this.chDepartmentID.Width = 0;
			// 
			// QuoteSearchScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "QuoteSearchScreen";
			this.ScreenTitle = "Quote Search";
			this.Load += new System.EventHandler(this.QuoteSearchScreen_Load);
			this.Controls.SetChildIndex(this.scMain, 0);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel1.PerformLayout();
			this.scMain.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        private void InitializeDropDown()
        {
            int index = 0;

			using (QuoteDropDown myItems = new QuoteDropDown(lvwResults, 0, 1, 2, 3, 7))
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

			using (QuoteDropDown myItems = new QuoteDropDown(lvwResults, 0, 1, 2, 3, 7))
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
        }

		private void ShowResults()
		{
			DataTable dtResults;

			using (QuoteController theController = new QuoteController())
			{
				dtResults = theController.GetSearchResults(cboSearchIn.SelectedValue.ToString(), txtLookFor.Text);
			}

			if (dtResults.Rows.Count > 0)
			{
				ListViewItem newItem;

				foreach (DataRow oRow in dtResults.Rows)
				{
					if (thisUser.RoleID == ADMINISTRATOR || !Convert.ToBoolean(oRow["is_archived"]))
					{
						newItem = new ListViewItem();
						newItem.Text = oRow["quote_id"].ToString();
						newItem.SubItems.Add(oRow["customer_id"].ToString());
						newItem.SubItems.Add(oRow["project_id"].ToString());
						newItem.SubItems.Add(oRow["department_id"].ToString());
						newItem.SubItems.Add(oRow["name"].ToString());
						newItem.SubItems.Add(Convert.ToDecimal(oRow["amount"]).ToString("C"));
						newItem.SubItems.Add(oRow["department"].ToString());
						newItem.SubItems.Add(oRow["status"].ToString());
						newItem.SubItems.Add(oRow["project"].ToString());
						newItem.SubItems.Add(oRow["customer"].ToString());
						newItem.SubItems.Add(oRow["sales_rep"].ToString());

						if (Convert.ToBoolean(oRow["is_archived"]))
							newItem.BackColor = Color.LightSteelBlue;

						lvwResults.Items.Add(newItem);

					}
				}
			}
			else
				ShowResultsMessage("No quotes were found with a " + cboSearchIn.Text + " of \"" + txtLookFor.Text + "\".");
		}

        #endregion


        #region EventHandlers

        private void QuoteSearchScreen_Load(object sender, EventArgs e)
        {
            InitializeDropDown();
        }

		private void btnSearch_Click(object sender, EventArgs e)
		{
			ClearResults();

			ShowResults();

			IsDisposable = false;
		}

		private void btnClearSearch_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void lvwResults_DoubleClick(object sender, EventArgs e)
		{
			if (lvwResults.SelectedItems.Count > 0)
			{
				NavigationScreen myNavigation = GetNavigationScreen();
				myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[1];

				using (CustomerController theController = new CustomerController())
				{
					myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(lvwResults.SelectedItems[0].SubItems[1].Text));
				}
				using (ProjectController theController = new ProjectController())
				{
					myNavigation.btnCustomer.MyProject = theController.GetProject(Convert.ToInt32(lvwResults.SelectedItems[0].SubItems[2].Text));
				}

				myNavigation.btnCustomer.PerformClick();

				((QuoteScreen)myNavigation.CurrentScreen).MyProject = myNavigation.btnCustomer.MyProject;

				using (QuoteController theController = new QuoteController())
				{
					((QuoteScreen)myNavigation.CurrentScreen).MyQuote = theController.GetQuote(Convert.ToInt32(lvwResults.SelectedItems[0].SubItems[0].Text));
				}
			}
		}

        #endregion


        #region Constructor

        public QuoteSearchScreen()
            : base()
        {
            InitializeComponent();

            //Populate the search in combo box
            DataTable oSearchInValues = new DataTable();
            oSearchInValues.Columns.Add("Column_Name");
            oSearchInValues.Columns.Add("Description");

			oSearchInValues.Rows.Add("q.`name`", "Quote Number");
			oSearchInValues.Rows.Add("p.`name`", "Project Name");
			oSearchInValues.Rows.Add("c.`name`", "Customer Name");
			oSearchInValues.Rows.Add("q.`amount`", "Amount");
			oSearchInValues.Rows.Add("d.`name`", "Department");
			oSearchInValues.Rows.Add("`sales_rep`", "Sales Rep");
			oSearchInValues.Rows.Add("ps.`name`", "Status");

            cboSearchIn.DataSource = oSearchInValues;
            cboSearchIn.DisplayMember = "Description";
            cboSearchIn.ValueMember = "Column_Name";
        }

        #endregion    


    }
}
