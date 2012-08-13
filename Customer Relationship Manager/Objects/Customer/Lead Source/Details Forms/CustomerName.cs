using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Customer.Lead_Source.Details_Forms
{
	class CustomerName : DetailListBase
	{
		private System.Windows.Forms.ColumnHeader chCustomerID;
		private System.Windows.Forms.ColumnHeader chContact;
		private System.Windows.Forms.ColumnHeader chPhone;
		private System.Windows.Forms.ColumnHeader chEmail;
		private System.Windows.Forms.ColumnHeader chName;


		#region Methods

		/// <summary>
		/// Determines if the provided string contains one or more letters
		/// </summary>
		/// <param name="theText"></param>
		/// <returns></returns>
		private bool ContainsLetters(string theText)
		{
			bool value = false;

			foreach (char oChar in theText.ToCharArray())
				if (char.IsLetter(oChar))
					value = true;

			return value;
		}

		private void InitializeComponent()
		{
			this.chCustomerID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chContact = new System.Windows.Forms.ColumnHeader();
			this.chPhone = new System.Windows.Forms.ColumnHeader();
			this.chEmail = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCustomerID,
            this.chName,
            this.chContact,
            this.chPhone,
            this.chEmail});
			// 
			// btnOK
			// 
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// chCustomerID
			// 
			this.chCustomerID.Text = "ID";
			this.chCustomerID.Width = 0;
			// 
			// chName
			// 
			this.chName.Text = "Customer Name";
			this.chName.Width = 200;
			// 
			// chContact
			// 
			this.chContact.Text = "Contact";
			this.chContact.Width = 150;
			// 
			// chPhone
			// 
			this.chPhone.Text = "Phone Number";
			this.chPhone.Width = 105;
			// 
			// chEmail
			// 
			this.chEmail.Text = "Email Address";
			this.chEmail.Width = 160;
			// 
			// CustomerName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(684, 262);
			this.Name = "CustomerName";
			this.Title = "Search for and select a customer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

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

		/// <summary>
		/// Loads the results set into the ListView object
		/// </summary>
		private void ShowResults()
		{
			DataTable dtResults;

			using (CustomerController theController = new CustomerController())
			{
				dtResults = theController.GetSearchResults(cboSearchIn.SelectedValue.ToString(), txtLookFor.Text);
			}

			if (dtResults.Rows.Count > 0)
			{
				try
				{
					ListViewGroup oGroup = null;
					ListViewItem oItem;
					DataRow previousRow = dtResults.NewRow();

					foreach (DataRow oRow in dtResults.Rows)
					{
						if (oRow["customer_id"].ToString() == previousRow["customer_id"].ToString())
						{
							oItem = new ListViewItem();
							oItem.Text = oRow["customer_id"].ToString();
							oItem.SubItems.Add(string.Empty);

							if (oRow["contact_id"].ToString() == previousRow["contact_id"].ToString())
								oItem.SubItems.Add(string.Empty);
							else
								oItem.SubItems.Add(oRow["first_name"].ToString() + " " + oRow["last_name"].ToString());

							oItem.SubItems.Add(FormatPhoneNumber(oRow["contact_number"].ToString()) + " " + oRow["abbreviation"].ToString());

							if (oRow["contact_id"].ToString() == previousRow["contact_id"].ToString())
								oItem.SubItems.Add(string.Empty);
							else
								oItem.SubItems.Add(oRow["email_address"].ToString());

							if (!Convert.ToBoolean(oRow["is_active"]))
								oItem.BackColor = Color.LightSteelBlue;

							oGroup.Items.Add(oItem);
							lvwList.Items.Add(oItem);

							previousRow = oRow;
						}
						else
						{

							oGroup = new ListViewGroup();
							oGroup.Header = string.Empty;

							lvwList.Groups.Add(oGroup);

							oItem = new ListViewItem();

							oItem.Text = oRow["customer_id"].ToString();
							oItem.SubItems.Add(oRow["customer"].ToString());
							oItem.SubItems.Add(string.Empty);
							oItem.SubItems.Add(FormatPhoneNumber(oRow["phone_number"].ToString()));
							oItem.SubItems.Add(string.Empty);

							if (!Convert.ToBoolean(oRow["is_active"]))
								oItem.BackColor = Color.LightSteelBlue;

							oGroup.Items.Add(oItem);
							lvwList.Items.Add(oItem);

							oItem = new ListViewItem();

							oItem.Text = oRow["customer_id"].ToString();
							oItem.SubItems.Add(string.Empty);
							oItem.SubItems.Add(oRow["first_name"].ToString() + " " + oRow["last_name"].ToString());
							oItem.SubItems.Add(FormatPhoneNumber(oRow["contact_number"].ToString()) + " " + oRow["abbreviation"].ToString());
							oItem.SubItems.Add(oRow["email_address"].ToString());

							if (!Convert.ToBoolean(oRow["is_active"]))
								oItem.BackColor = Color.LightSteelBlue;

							oGroup.Items.Add(oItem);
							lvwList.Items.Add(oItem);

							previousRow = oRow;
						}
					}

				}
				catch (Exception e)
				{
					ErrorHandler.ProcessException(e, false);
				}
			}
			else
			{
				ShowResultsMessage("No customers were found with a " + cboSearchIn.Text + " of \"" + txtLookFor.Text + "\".");
			}
		}

		#endregion


		#region Event Handlers

		private void btnSearch_Click(object sender, EventArgs e)
		{
			//Clear any previous results
			ClearResults();

			if (ContainsLetters(txtLookFor.Text) && cboSearchIn.SelectedIndex == 0)
				cboSearchIn.SelectedIndex = 1;

			ShowResults();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (lvwList.SelectedItems.Count == 1)
			{
				using (CustomerController theController = new CustomerController())
				{
					objReturnValue = theController.GetCustomer(Convert.ToInt32(lvwList.SelectedItems[0].SubItems[0].Text));
				}
				strReturnString = ((Customer)ReturnValue).Name;

				DialogResult = DialogResult.OK;
				this.Close();
			}
			else
				MessageBox.Show("Please select a customer from the list.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion


		#region Constructor

		public CustomerName()
			: base()
		{
			InitializeComponent();

			//Populate the search in combo box
			DataTable oSearchInValues = new DataTable();
			oSearchInValues.Columns.Add("Column_Name");
			oSearchInValues.Columns.Add("Description");

			oSearchInValues.Rows.Add("phone_number", "Phone Number");
			oSearchInValues.Rows.Add("c.`name`", "Company Name");
			oSearchInValues.Rows.Add("ContactName", "Contact Name");
			oSearchInValues.Rows.Add("co.`first_name`", "First Name");
			oSearchInValues.Rows.Add("co.`last_name`", "Last Name");
			oSearchInValues.Rows.Add("c.`falcon_id`", "Falcon Number");
			oSearchInValues.Rows.Add("view_all", "View All");

			cboSearchIn.DataSource = oSearchInValues;
			cboSearchIn.DisplayMember = "Description";
			cboSearchIn.ValueMember = "Column_Name";

		}

		#endregion

	}
}
