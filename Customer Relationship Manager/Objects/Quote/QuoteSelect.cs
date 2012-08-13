using System;
using System.Data;
using System.Windows.Forms;

namespace rkcrm.Objects.Quote
{
	public partial class QuoteSelect : Form
	{


		#region Properties

		public int SelectedQuoteID
		{
			get { return Convert.ToInt32(lvwQuotes.SelectedItems[0].SubItems[0].Text); }
		}

		public int SelectedDepartmentID
		{
			get { return Convert.ToInt32(lvwQuotes.SelectedItems[0].SubItems[1].Text); }
		}

		public DataTable DataSource
		{
			set
			{
				if (value != null)
				{
					ListViewItem oItem;

					foreach (DataRow oRow in value.Rows)
					{
						oItem = new ListViewItem();

						oItem.Text = oRow["quote_id"].ToString();
						oItem.SubItems.Add(oRow["department_id"].ToString());
						oItem.SubItems.Add(oRow["department"].ToString());
						oItem.SubItems.Add(oRow["quote"].ToString());
						oItem.SubItems.Add(Convert.ToDecimal(oRow["amount"]).ToString("C"));
						oItem.SubItems.Add(oRow["description"].ToString());
						oItem.SubItems.Add(oRow["sales_rep"].ToString());

						lvwQuotes.Items.Add(oItem);
					}
				}
			}
		}

		#endregion


		#region Event Handlers

		private void btnSelect_Click(object sender, EventArgs e)
		{
			if (lvwQuotes.SelectedItems.Count > 0)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
				MessageBox.Show("Please select a quote from the list.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion


		#region Constructor

		public QuoteSelect()
		{
			InitializeComponent();
		}

		#endregion

	}
}
