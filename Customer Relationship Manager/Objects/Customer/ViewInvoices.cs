using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer
{
	class ViewInvoices : ObjectListBase
	{
		private System.Windows.Forms.ColumnHeader chOrderID;
		private System.Windows.Forms.ColumnHeader chInvoiceID;
		private System.Windows.Forms.ColumnHeader chDepartment;
		private System.Windows.Forms.ColumnHeader chInvoiced;
		private System.Windows.Forms.ColumnHeader chAmount;
		private System.Windows.Forms.ColumnHeader chSalesRep;
		private System.Windows.Forms.ColumnHeader chEnterer;
		private System.Windows.Forms.ColumnHeader chInvTerms;
		private System.Windows.Forms.ColumnHeader chAccTerms;

		private int sortedColumnIndex = -1;
		private int myCustomerID;

		#region Methods

		private void InitializeComponent()
		{
			this.chOrderID = new System.Windows.Forms.ColumnHeader();
			this.chInvoiceID = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chInvoiced = new System.Windows.Forms.ColumnHeader();
			this.chAmount = new System.Windows.Forms.ColumnHeader();
			this.chSalesRep = new System.Windows.Forms.ColumnHeader();
			this.chEnterer = new System.Windows.Forms.ColumnHeader();
			this.chAccTerms = new System.Windows.Forms.ColumnHeader();
			this.chInvTerms = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// btnClearSearch
			// 
			this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(113, 10);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lvwResults
			// 
			this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOrderID,
            this.chInvoiceID,
            this.chDepartment,
            this.chInvoiced,
            this.chAmount,
            this.chSalesRep,
            this.chEnterer,
            this.chAccTerms,
            this.chInvTerms});
			this.lvwResults.Size = new System.Drawing.Size(749, 152);
			this.lvwResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwList_ColumnClick);
			// 
			// chOrderID
			// 
			this.chOrderID.Text = "Order Number";
			this.chOrderID.Width = 90;
			// 
			// chInvoiceID
			// 
			this.chInvoiceID.Text = "Invoice Number";
			this.chInvoiceID.Width = 90;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 70;
			// 
			// chInvoiced
			// 
			this.chInvoiced.Text = "Invoiced";
			this.chInvoiced.Width = 80;
			// 
			// chAmount
			// 
			this.chAmount.Text = "Amount";
			this.chAmount.Width = 80;
			// 
			// chSalesRep
			// 
			this.chSalesRep.Text = "Sales Rep";
			this.chSalesRep.Width = 80;
			// 
			// chEnterer
			// 
			this.chEnterer.Text = "Entered By";
			this.chEnterer.Width = 80;
			// 
			// chAccTerms
			// 
			this.chAccTerms.Text = "Account Terms";
			this.chAccTerms.Width = 85;
			// 
			// chInvTerms
			// 
			this.chInvTerms.Text = "Invoice Terms";
			this.chInvTerms.Width = 80;
			// 
			// ViewInvoices
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(749, 262);
			this.Name = "ViewInvoices";
			this.SelectsObjects = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Title = "Invoices";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void RefreshList()
		{
			this.ClearResults();

			using (CustomerController theController = new CustomerController())
			{
				ListViewItem newItem;

				foreach (DataRow oRow in theController.GetInvoices(myCustomerID).Rows)
				{
					newItem = new ListViewItem();

					newItem.Text = oRow["order_id"].ToString();
					newItem.SubItems.Add(oRow["invoice_id"].ToString());
					newItem.SubItems.Add(oRow["name"].ToString());
					newItem.SubItems.Add(Convert.ToDateTime(oRow["invoiced"]).ToShortDateString());
					newItem.SubItems.Add(Convert.ToDecimal(oRow["amount"]).ToString("C"));
					newItem.SubItems.Add(oRow["sales_rep"].ToString());
					newItem.SubItems.Add(oRow["entered_by"].ToString());
					newItem.SubItems.Add(oRow["account_terms"].ToString());
					newItem.SubItems.Add(oRow["invoice_terms"].ToString());
					
					lvwResults.Items.Add(newItem);
				}
			}
		}

		private void ShowResults()
		{
			DataTable dtResults;

			using (CustomerController theController = new CustomerController())
			{
				dtResults = theController.GetInvoices(myCustomerID, cboSearchIn.SelectedValue.ToString(), txtLookFor.Text);
			}

			if (dtResults.Rows.Count > 0)
			{
				ListViewItem newItem;

				foreach (DataRow oRow in dtResults.Rows)
				{
					newItem = new ListViewItem();

					newItem.Text = oRow["order_id"].ToString();
					newItem.SubItems.Add(oRow["invoice_id"].ToString());
					newItem.SubItems.Add(oRow["name"].ToString());
					newItem.SubItems.Add(Convert.ToDateTime(oRow["invoiced"]).ToShortDateString());
					newItem.SubItems.Add(Convert.ToDecimal(oRow["amount"]).ToString("C"));
					newItem.SubItems.Add(oRow["sales_rep"].ToString());
					newItem.SubItems.Add(oRow["entered_by"].ToString());
					newItem.SubItems.Add(oRow["account_terms"].ToString());
					newItem.SubItems.Add(oRow["invoice_terms"].ToString());

					lvwResults.Items.Add(newItem);
				}
			}

		}

		#endregion


		#region Event Handlers

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void lvwList_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column != sortedColumnIndex)
			{
				sortedColumnIndex = e.Column;
				((ListView)sender).Sorting = SortOrder.Ascending;
			}
			else
				if (((ListView)sender).Sorting == SortOrder.Ascending)
					((ListView)sender).Sorting = SortOrder.Descending;
				else
					((ListView)sender).Sorting = SortOrder.Descending;

			((ListView)sender).ListViewItemSorter = new ListViewItemComparer(e.Column, ((ListView)sender).Sorting);
			((ListView)sender).Sort();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.ClearResults();

			if (cboSearchIn.SelectedValue.ToString() == "i.`invoiced`")
			{
				try
				{
					DateTime theDate = DateTime.Parse(txtLookFor.Text);

					ShowResults();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, MySettings.AppTitle);
				}
			}
			else
				ShowResults();
		}

		private void btnClearSearch_Click(object sender, EventArgs e)
		{
			RefreshList();
		}

		#endregion		


		#region Constructor

		public ViewInvoices(int CustomerID)
			: base()
		{
			myCustomerID = CustomerID;

			InitializeComponent();

			//Populate the search in combo box
			DataTable oSearchInValues = new DataTable();
			oSearchInValues.Columns.Add("Column_Name");
			oSearchInValues.Columns.Add("Description");

			oSearchInValues.Rows.Add("i.`order_id`", "Order Number");
			oSearchInValues.Rows.Add("i.`invoice_id`", "Invoice Number");
			oSearchInValues.Rows.Add("d.`name`", "Department");
			oSearchInValues.Rows.Add("i.`invoiced`", "Invoiced Date");
			oSearchInValues.Rows.Add("i.`amount`", "Total Merch");
			oSearchInValues.Rows.Add("i.`sales_rep`", "Sales Rep");
			oSearchInValues.Rows.Add("i.`entered_by`", "Entered By");
			oSearchInValues.Rows.Add("i.`account_terms`", "Account Terms");
			oSearchInValues.Rows.Add("i.`invoice_terms`", "Invoice Terms");

			cboSearchIn.DataSource = oSearchInValues;
			cboSearchIn.DisplayMember = "Description";
			cboSearchIn.ValueMember = "Column_Name";


			RefreshList();
		}

		#endregion

	}
}
