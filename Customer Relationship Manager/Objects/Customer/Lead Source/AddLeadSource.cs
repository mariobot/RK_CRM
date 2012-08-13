using System;
using System.Data;
using System.Windows.Forms;

namespace rkcrm.Objects.Customer.Lead_Source
{
	public partial class AddLeadSource : Form
	{

		#region Variables

		private Customer clsMyCustomer;

		#endregion


		#region Properties

		internal Customer MyCustomer
		{
			get { return clsMyCustomer; }
			set
			{
				clsMyCustomer = value;
				mySourceBoundary.MySource = new LeadSource();
				mySourceBoundary.MySource.CustomerID = clsMyCustomer.ID;
			}
		}

		public string Title
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}

		public int DepartmentID
		{
			get { return Convert.ToInt32(mySourceBoundary.lbxDepartments.SelectedValue); }
			set
			{
				mySourceBoundary.lbxDepartments.SelectedItems.Clear();
				mySourceBoundary.lbxDepartments.SelectedIndices.Add(mySourceBoundary.IndexOfDepartment(value));
			}
		}

		#endregion


		#region Event Handlers

		private void AddLeadSource_Load(object sender, EventArgs e)
		{
			if (mySourceBoundary.lbxDepartments.SelectedItems.Count == 0)
			{
				this.Height = 290;
				mySourceBoundary.lblDepartments.Visible = true;
				mySourceBoundary.lbxDepartments.Visible = true;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (mySourceBoundary.IsDirty && mySourceBoundary.CommitChanges())
			{
				foreach (object oItem in mySourceBoundary.lbxDepartments.SelectedItems)
				{
					mySourceBoundary.MySource.DepartmentID = Convert.ToInt32(((DataRowView)oItem)["department_id"]);

					using (LeadSourceController theController = new LeadSourceController())
					{
						theController.InsertLeadSource(mySourceBoundary.MySource);
					}
				}

				DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion


		#region Constructor

		public AddLeadSource()
		{
			InitializeComponent();
		}

		#endregion

	}
}
