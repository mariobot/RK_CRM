using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.User;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer.Lead_Source.Details_Forms
{
	class UserName : DetailListBase
	{
		private ColumnHeader chName;
		private ColumnHeader chID;
		private ColumnHeader chDepartment;


		#region Methods

		private void InitializeComponent()
		{
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chID = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chName,
            this.chDepartment});
			// 
			// btnOK
			// 
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// chName
			// 
			this.chName.Text = "Employee Name";
			this.chName.Width = 150;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 90;
			// 
			// chID
			// 
			this.chID.Text = "id";
			this.chID.Width = 0;
			// 
			// UserName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(684, 262);
			this.Name = "UserName";
			this.Title = "Search for and select an employee";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void ShowResults()
		{
			DataTable dtResults;
			ListViewItem newItem;

			using (UserController theController = new UserController())
			{
				dtResults = theController.GetSearchResults(cboSearchIn.SelectedValue.ToString(), txtLookFor.Text);
			}

			if (dtResults.Rows.Count > 0)
			{

				foreach (DataRow oRow in dtResults.Rows)
				{
					newItem = new ListViewItem();
					newItem.Text = oRow["user_id"].ToString();
					newItem.SubItems.Add(oRow["full_name"].ToString());
					newItem.SubItems.Add(oRow["department"].ToString());

					lvwList.Items.Add(newItem);
				}

			}
			else
				ShowResultsMessage("No employees were found with a " + cboSearchIn.Text + " of \"" + txtLookFor.Text + "\".");

		}

		#endregion


		#region Event Handlers

		private void btnSearch_Click(object sender, EventArgs e)
		{
			//Clear any previous results
			ClearResults();

			ShowResults();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (lvwList.SelectedItems.Count == 1)
			{
				using (UserController theController = new UserController())
				{
					objReturnValue = theController.GetUser(Convert.ToInt32(lvwList.SelectedItems[0].SubItems[0].Text));
				}
				strReturnString = ((User)objReturnValue).FullName;

				DialogResult = DialogResult.OK;
				this.Close();
			}
			else
				MessageBox.Show("Please select an employee from the list.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

		#endregion	


		#region Constructor

		public UserName()
			: base()
		{
			InitializeComponent();

			//Populate the search in combo box
			DataTable oSearchInValues = new DataTable();
			oSearchInValues.Columns.Add("Column_Name");
			oSearchInValues.Columns.Add("Description");

			oSearchInValues.Rows.Add("full_name", "Employee Name");
			oSearchInValues.Rows.Add("d.`name`", "Department");
			oSearchInValues.Rows.Add("view_all", "View All");

			cboSearchIn.DataSource = oSearchInValues;
			cboSearchIn.DisplayMember = "Description";
			cboSearchIn.ValueMember = "Column_Name";

		}

		#endregion	

	}
}
