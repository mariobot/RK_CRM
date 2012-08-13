using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer
{
	class DuplicateCustomerList : ObjectListBase
	{
		private DataTable Duplicates;
		private Customer myCustomer;
		private string newName;

		private System.Windows.Forms.ColumnHeader chCustomerID;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chPhone;
		private System.Windows.Forms.ColumnHeader chType;
		private System.Windows.Forms.ColumnHeader Address;
		private System.Windows.Forms.ColumnHeader chCreator;


		#region Methods

		private void InitializeComponent()
		{
			this.chCustomerID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chPhone = new System.Windows.Forms.ColumnHeader();
			this.chType = new System.Windows.Forms.ColumnHeader();
			this.Address = new System.Windows.Forms.ColumnHeader();
			this.chCreator = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Text = "No";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Text = "Yes";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lvwResults
			// 
			this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCustomerID,
            this.chName,
            this.chPhone,
            this.chType,
            this.Address,
            this.chCreator});
			this.lvwResults.Location = new System.Drawing.Point(0, 50);
			this.lvwResults.Size = new System.Drawing.Size(684, 162);
			// 
			// chCustomerID
			// 
			this.chCustomerID.Text = "Customer ID";
			this.chCustomerID.Width = 0;
			// 
			// chName
			// 
			this.chName.Text = "Customer Name";
			this.chName.Width = 200;
			// 
			// chPhone
			// 
			this.chPhone.Text = "Phone Number";
			this.chPhone.Width = 90;
			// 
			// chType
			// 
			this.chType.Text = "Type";
			this.chType.Width = 100;
			// 
			// Address
			// 
			this.Address.Text = "Address";
			this.Address.Width = 150;
			// 
			// chCreator
			// 
			this.chCreator.Text = "Created By";
			this.chCreator.Width = 125;
			// 
			// DuplicateCustomerList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(684, 262);
			this.IsSearchable = false;
			this.Name = "DuplicateCustomerList";
			this.Text = "Duplicate Customer Name";
			this.Title = "Are any of these the customer you\'re looking for?";
			this.Load += new System.EventHandler(this.DuplicateCustomerList_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void LoadList()
		{
			ListViewItem oItem;

			foreach (DataRow oRow in Duplicates.Rows)
			{
				oItem = new ListViewItem();
				oItem.Text = oRow["customer_id"].ToString(); ;
				oItem.SubItems.Add(oRow["name"].ToString());
				oItem.SubItems.Add(oRow["phone_number"].ToString());
				oItem.SubItems.Add(oRow["type"].ToString());
				oItem.SubItems.Add(oRow["address"].ToString());
				oItem.SubItems.Add(oRow["creator"].ToString());

				lvwResults.Items.Add(oItem);
			}
		}

		#endregion


		#region Event Handlers

		private void DuplicateCustomerList_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			using (CustomerController theController = new CustomerController())
			{
				theController.LogDuplicateOccurance(myCustomer, newName, lvwResults.Items.Count, btnCancel.Text);
			}
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (SelectedItem == null)
				MessageBox.Show("Please select a customer from the list.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
			{
				using (CustomerController theController = new CustomerController())
				{
					theController.LogDuplicateOccurance(myCustomer, newName, lvwResults.Items.Count, btnOK.Text);
				}
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

		#endregion


		#region Constructor

		public DuplicateCustomerList(DataTable theList, Customer theCustomer, string NameEntered)
			: base()
		{
			InitializeComponent();

			Duplicates = theList;
			myCustomer = theCustomer;
			newName = NameEntered;
		}

		#endregion	

	}
}
