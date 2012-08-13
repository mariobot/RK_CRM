using System;
using System.Data;
using System.Windows.Forms;

namespace rkcrm.Administration.Department
{
	public partial class DepartmentSelect : Form
	{


		#region Properties

		public DataTable DataSource
		{
			get { return (DataTable)lstDepartments.DataSource; }
			set { lstDepartments.DataSource = value; }
		}

		public string DisplayMember
		{
			get { return lstDepartments.DisplayMember; }
			set { lstDepartments.DisplayMember = value; }
		}

		public string ValueMember
		{
			get { return lstDepartments.ValueMember; }
			set { lstDepartments.ValueMember = value; }
		}

		public string Title
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}

		public ListBox.SelectedObjectCollection SelectedItems
		{
			get { return lstDepartments.SelectedItems; }
		}

		public SelectionMode SelectionMode
		{
			get { return lstDepartments.SelectionMode; }
			set { lstDepartments.SelectionMode = value; }
		}

		#endregion


		#region Event Handlers

		private void btnSelect_Click(object sender, EventArgs e)
		{
			if (lstDepartments.SelectedItems.Count > 0)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
				MessageBox.Show("Please select at least one department.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion


		#region Constructor

		public DepartmentSelect()
		{
			InitializeComponent();
		}

		#endregion

	}
}
