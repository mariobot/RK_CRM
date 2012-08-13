using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace rkcrm.Objects.Project
{
	public partial class SendCrossLead : Form
	{


		#region Event Handlers

		private void SendCrossLead_Load(object sender, EventArgs e)
		{
			crossLeadControls.MyCrossLead = new rkcrm.Objects.Cross_Lead.CrossLead();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if (crossLeadControls.IsDirty)
			{
				if (crossLeadControls.CommitChanges())
				{
					Cross_Lead.CrossLead theCrossLead = crossLeadControls.MyCrossLead;

					List<int> departments = new List<int>();
					foreach (object Item in crossLeadControls.lbxDepartments.SelectedItems)
					{
						departments.Add(Convert.ToInt32(((DataRowView)Item)["department_id"]));
					}

					using (Cross_Lead.CrossLeadController theController = new Cross_Lead.CrossLeadController())
					{

						theCrossLead = theController.InsertCrossLead(theCrossLead, departments);

						if (theCrossLead.ID > 0)
						{
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
					DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			else
			{
				DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void crossLeadControls_IsDirtyChanged(object sender, EventArgs e)
		{
			btnSend.Enabled = crossLeadControls.IsDirty;
		}

		#endregion


		#region Constructor

		public SendCrossLead()
		{
			InitializeComponent();
			btnSend.Enabled = false;
		}

		#endregion

	}
}
