using System;
using System.Data;
using System.Windows.Forms;

namespace rkcrm.Objects.Project
{
	public partial class DuplicateProjects : Form
	{

		#region Properties

		public string Title
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}

		public string AcceptButtonText
		{
			get { return btnOK.Text; }
			set { btnOK.Text = value; }
		}

        public string CancelButtonText
        {
            get { return btnCancel.Text; }
            set { btnCancel.Text = value; }
        }

		public int SelectedProjectID
		{
			get
			{
				if (lvwProjects.SelectedItems.Count > 0)
				{
					return Convert.ToInt32(lvwProjects.SelectedItems[0].Text);
				}
				else
					return 0;
			}
		}

		public DataTable DataSource
		{
			set
			{
				ListViewItem oItem;
				string address = string.Empty;

				foreach (DataRow oRow in value.Rows)
				{
					address += string.IsNullOrEmpty(oRow["address"].ToString()) ? string.Empty : oRow["address"].ToString();
					address += string.IsNullOrEmpty(oRow["apt"].ToString()) ? string.Empty : ", " + oRow["apt"].ToString();
					address += string.IsNullOrEmpty(oRow["city"].ToString()) ? string.Empty : ", " + oRow["city"].ToString();
					address += DBNull.Value == oRow["zip_code"] ? string.Empty : ", " + oRow["zip_code"].ToString();

					oItem = new ListViewItem();
					oItem.Text = oRow["project_id"].ToString();
					oItem.SubItems.Add(oRow["customer"].ToString());
					oItem.SubItems.Add(oRow["project"].ToString());
					oItem.SubItems.Add(oRow["type"].ToString());
					oItem.SubItems.Add(address);

					lvwProjects.Items.Add(oItem);

					address = string.Empty;
				}
			}
		}

		#endregion


		#region Event Handlers

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (lvwProjects.SelectedItems.Count > 0)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
				MessageBox.Show("Please select a project from the list.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion


		#region Constructor

		public DuplicateProjects()
		{
			InitializeComponent();
		}

		#endregion

	}
}
