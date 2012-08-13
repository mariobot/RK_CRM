using System;
using System.Windows.Forms;
using rkcrm.Objects.Customer;

namespace rkcrm.Objects.Cross_Sale
{
	public partial class CrossSaleManagement : Form
	{


		#region Event Handlers

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void chkNoCrossLead_CheckedChanged(object sender, EventArgs e)
		{
			myScreen.tsbAdd.Enabled = !chkNoCrossLead.Checked;
		}

		private void CrossSaleManagement_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (myScreen.IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (myScreen.Save())
							myScreen.MyCrossSale = new CrossSale();
						else
							e.Cancel = true;
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
					default:
						myScreen.MyCrossSale = new CrossSale();
						break;
				}
			}
			else
				myScreen.MyCrossSale = new CrossSale();

			if (chkNoCrossLead.Checked != myScreen.MyCustomer.CannotCrossLead)
			{
				using (CustomerController theController = new CustomerController())
				{
					myScreen.MyCustomer.CannotCrossLead = chkNoCrossLead.Checked;

					if (!theController.UpdateCustomer(myScreen.MyCustomer))
					{
						//Reset the CannotCrossLead value so that it will attempt to save the value the next time the form closes
						myScreen.MyCustomer.CannotCrossLead = !chkNoCrossLead.Checked;
						e.Cancel = true;
					}
				}
			}

		}

		#endregion


		#region Constructors

		internal CrossSaleManagement()
		{
			InitializeComponent();

			myScreen.MyCustomer = null;
		}

		internal CrossSaleManagement(Customer.Customer theCustomer)
		{
			InitializeComponent();

			myScreen.MyCustomer = theCustomer;

			chkNoCrossLead.Checked = theCustomer.CannotCrossLead;
		}

		#endregion

	}
}
