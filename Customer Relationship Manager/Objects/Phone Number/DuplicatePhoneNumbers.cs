using System;
using System.Data;
using System.Windows.Forms;

namespace rkcrm.Objects.Phone_Number
{
	public partial class DuplicatePhoneNumbers : Form
	{

		#region Properties

		public string PhoneNumber
		{
			set { lblTitle.Text = "The phone number, " + FormatPhoneNumber(value) + ", already exists on the following customers. Are you sure you want to continue?"; }
		}

		public DataTable OwnerList
		{
			set
			{
				int index = 0;
				ListViewItem newItem;

				while (index < value.Rows.Count)
				{

					if (!(value.Rows[index]["contact"] == DBNull.Value && value.Rows[index]["name"].ToString() == value.Rows[index + 1]["name"].ToString()))
					{
						newItem = new ListViewItem();
						newItem.Text = value.Rows[index]["name"].ToString();
						newItem.SubItems.Add(value.Rows[index]["contact"].ToString());

						lvwOwners.Items.Add(newItem);
					}

					index++;
				}
			}
		}

		#endregion


		#region Methods

		/// <summary>
		/// Format the given string to (xxx) xxx-xxxx
		/// </summary>
		/// <param name="PhoneNumber"></param>
		/// <returns></returns>
		private string FormatPhoneNumber(string PhoneNumber)
		{
			PhoneNumber = PhoneNumber.Insert(0, "(");
			PhoneNumber = PhoneNumber.Insert(4, ") ");
			PhoneNumber = PhoneNumber.Insert(9, "-");

			return PhoneNumber;
		}

		#endregion


		#region Event Handlers

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion


		#region Constructor

		public DuplicatePhoneNumbers()
		{
			InitializeComponent();
		}

		#endregion

	}
}
