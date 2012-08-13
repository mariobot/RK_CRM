using System;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer
{
	class UpdateTaxExpiration : UpdateDateBase
	{
		private Customer myCustomer;

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// UpdateTaxExpiration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(334, 192);
			this.Name = "UpdateTaxExpiration";
			this.Title = "Edit Tax Exempt Expiration";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				try
				{
					DateTime newDate;

					if (this.Date == "  /  /")
						newDate = DateTime.MinValue;
					else
						newDate = Convert.ToDateTime(this.Date);

					if (newDate != myCustomer.TaxIDExpiration)
					{
						myCustomer.TaxIDExpiration = newDate;

						using (CustomerController theController = new CustomerController())
						{
							if (theController.UpdateCustomer(myCustomer))
							{
								this.DialogResult = System.Windows.Forms.DialogResult.OK;
								this.Close();
							}
						}
					}
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
			}
		}

		public UpdateTaxExpiration(Customer theCustomer)
			: base()
		{
			myCustomer = theCustomer;

			InitializeComponent();

			this.CustomerName = myCustomer.Name;
			this.Date = (myCustomer.TaxIDExpiration == DateTime.MinValue ? string.Empty : myCustomer.TaxIDExpiration.ToString("MM/dd/yyyy"));
		}

	}
}
