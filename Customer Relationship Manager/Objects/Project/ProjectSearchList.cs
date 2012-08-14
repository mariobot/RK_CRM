using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Project
{
	class ProjectSearchList : DetailListBase
	{

		#region Variables

		private ColumnHeader chID;
		private ColumnHeader chName;
		private ColumnHeader chAddress;
		private ColumnHeader chCity;
		private const int ADMINISTRATOR = 1;

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.chID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chAddress = new System.Windows.Forms.ColumnHeader();
			this.chCity = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chName,
            this.chAddress,
            this.chCity});
			// 
			// btnOK
			// 
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// chID
			// 
			this.chID.Text = "ID";
			this.chID.Width = 0;
			// 
			// chName
			// 
			this.chName.Text = "Project Name";
			this.chName.Width = 200;
			// 
			// chAddress
			// 
			this.chAddress.Text = "Address";
			this.chAddress.Width = 200;
			// 
			// chCity
			// 
			this.chCity.Text = "City";
			this.chCity.Width = 150;
			// 
			// ProjectSearchList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(684, 262);
			this.Name = "ProjectSearchList";
			this.Text = "Select a Project";
			this.Title = "Select a project to link too.";
			this.ResumeLayout(false);
			this.PerformLayout();

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
							newItem.SubItems.Add(oRow["project"].ToString());
							newItem.SubItems.Add(oRow["address"].ToString());
							newItem.SubItems.Add(oRow["city"].ToString());

							if (Convert.ToBoolean(oRow["is_archived"]))
								newItem.BackColor = System.Drawing.Color.LightSteelBlue;

							lvwList.Items.Add(newItem);
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
				using (ProjectController theController = new ProjectController())
				{
					objReturnValue = theController.GetProject(Convert.ToInt32(lvwList.SelectedItems[0].SubItems[0].Text));
				}
				strReturnString = ((Project)ReturnValue).Name;

				DialogResult = DialogResult.OK;
				this.Close();
			}
			else
				MessageBox.Show("Please select a project from the list.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion


		#region Constructor

		public ProjectSearchList()
			: base()
		{
			InitializeComponent();

			//Populate the search in combo box
			DataTable oSearchInValues = new DataTable();
			oSearchInValues.Columns.Add("Column_Name");
			oSearchInValues.Columns.Add("Description");

			oSearchInValues.Rows.Add("p.`name`", "Project Name");
			oSearchInValues.Rows.Add("c.`name`", "Customer Name");
			oSearchInValues.Rows.Add("`contact_name`", "Contact Name");
			oSearchInValues.Rows.Add("pt.`name`", "Project Type");
			oSearchInValues.Rows.Add("view_all", "View All");

			cboSearchIn.DataSource = oSearchInValues;
			cboSearchIn.DisplayMember = "Description";
			cboSearchIn.ValueMember = "Column_Name";
		}

		#endregion

	}
}
