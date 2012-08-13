using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using rkcrm.Administration.Department;
using rkcrm.Event_Arguments;
using rkcrm.Navigation;
using rkcrm.Objects.Contact;
using rkcrm.Objects.Customer;
using rkcrm.Objects.Project;

namespace rkcrm.Searching.DropDowns
{
    class CustomerDropDown : ToolStripDropDown
    {

		#region Variables

		private ToolStripDropDownButton tdbMenuItems;
		private ToolStripButton tsbAddCustomer;
		private ToolStripButton tsbAddContact;
		private ToolStripButton tsbAddProject;
		private ToolStripButton tsbTaxExcempt;
		private ToolStripButton tsbCreditCard;
		private ToolStripButton tsbInvoices;
		private ToolStripSeparator tss_0;
		private ToolStripSeparator tss_1;
		private ToolStripSeparator tss_2;
		private ToolStripSeparator tss_3;
		private ToolStripMenuItem tsmAddCustomer;
		private ToolStripMenuItem tsmEditCustomer;
		private ToolStripSeparator mss_0;
		private ToolStripMenuItem tsmAddContact;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmAddProject;
		private ToolStripSeparator mss_2;
		private ToolStripMenuItem tsmTaxExempt;
		private ToolStripMenuItem tsmCreditCard;
		private ToolStripSeparator mss_3;
		private ToolStripMenuItem tsmActivityStatus;
		private ToolStripMenuItem tsmInvoices;
		private ToolStripButton tsbEditCustomer;

		private ListView theReferencedList;
		private int ColumnIndex;
		private const int DEACTIVATION = 12;
		private ToolStripButton tsbActivityStatus;
		private ToolStripSeparator mss_4;
		private ToolStripMenuItem tsmProperties;
		private ToolStripSeparator tss_4;
		private ToolStripButton tsbProperties;
		private const int ACTIVATION = 13;

		#endregion


        #region Methods

        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDropDown));
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tss_4 = new System.Windows.Forms.ToolStripSeparator();
			this.tdbMenuItems = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmAddCustomer = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmEditCustomer = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmAddContact = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmAddProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmTaxExempt = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmCreditCard = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmActivityStatus = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmInvoices = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAddCustomer = new System.Windows.Forms.ToolStripButton();
			this.tsbEditCustomer = new System.Windows.Forms.ToolStripButton();
			this.tsbAddContact = new System.Windows.Forms.ToolStripButton();
			this.tsbAddProject = new System.Windows.Forms.ToolStripButton();
			this.tsbTaxExcempt = new System.Windows.Forms.ToolStripButton();
			this.tsbCreditCard = new System.Windows.Forms.ToolStripButton();
			this.tsbActivityStatus = new System.Windows.Forms.ToolStripButton();
			this.tsbInvoices = new System.Windows.Forms.ToolStripButton();
			this.tsbProperties = new System.Windows.Forms.ToolStripButton();
			this.SuspendLayout();
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(6, 23);
			// 
			// tss_1
			// 
			this.tss_1.Name = "tss_1";
			this.tss_1.Size = new System.Drawing.Size(6, 23);
			// 
			// tss_2
			// 
			this.tss_2.Name = "tss_2";
			this.tss_2.Size = new System.Drawing.Size(6, 23);
			// 
			// tss_3
			// 
			this.tss_3.Name = "tss_3";
			this.tss_3.Size = new System.Drawing.Size(6, 23);
			// 
			// tss_4
			// 
			this.tss_4.Name = "tss_4";
			this.tss_4.Size = new System.Drawing.Size(6, 23);
			// 
			// tdbMenuItems
			// 
			this.tdbMenuItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tdbMenuItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddCustomer,
            this.tsmEditCustomer,
            this.mss_0,
            this.tsmAddContact,
            this.tsmAddProject,
            this.mss_1,
            this.tsmTaxExempt,
            this.tsmCreditCard,
            this.mss_2,
            this.tsmActivityStatus,
            this.mss_3,
            this.tsmInvoices,
            this.mss_4,
            this.tsmProperties});
			this.tdbMenuItems.Image = ((System.Drawing.Image)(resources.GetObject("tdbMenuItems.Image")));
			this.tdbMenuItems.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tdbMenuItems.Name = "tdbMenuItems";
			this.tdbMenuItems.Size = new System.Drawing.Size(29, 20);
			this.tdbMenuItems.Text = "toolStripDropDownButton1";
			// 
			// tsmAddCustomer
			// 
			this.tsmAddCustomer.Image = global::rkcrm.Properties.Resources.New_Customer_Icon;
			this.tsmAddCustomer.Name = "tsmAddCustomer";
			this.tsmAddCustomer.Size = new System.Drawing.Size(227, 22);
			this.tsmAddCustomer.Text = "Add Customer";
			this.tsmAddCustomer.Click += new System.EventHandler(this.AddCustomer_Click);
			// 
			// tsmEditCustomer
			// 
			this.tsmEditCustomer.Image = global::rkcrm.Properties.Resources.Edit_Customer_28x28;
			this.tsmEditCustomer.Name = "tsmEditCustomer";
			this.tsmEditCustomer.Size = new System.Drawing.Size(227, 22);
			this.tsmEditCustomer.Text = "Edit Customer";
			this.tsmEditCustomer.Click += new System.EventHandler(this.EditCustomer_Click);
			// 
			// mss_0
			// 
			this.mss_0.Name = "mss_0";
			this.mss_0.Size = new System.Drawing.Size(224, 6);
			// 
			// tsmAddContact
			// 
			this.tsmAddContact.Image = global::rkcrm.Properties.Resources.New_Contact_Icon;
			this.tsmAddContact.Name = "tsmAddContact";
			this.tsmAddContact.Size = new System.Drawing.Size(227, 22);
			this.tsmAddContact.Text = "Add Contact";
			this.tsmAddContact.Click += new System.EventHandler(this.AddContact_Click);
			// 
			// tsmAddProject
			// 
			this.tsmAddProject.Image = global::rkcrm.Properties.Resources.New_Project28x28;
			this.tsmAddProject.Name = "tsmAddProject";
			this.tsmAddProject.Size = new System.Drawing.Size(227, 22);
			this.tsmAddProject.Text = "Add Project";
			this.tsmAddProject.Click += new System.EventHandler(this.AddProject_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(224, 6);
			// 
			// tsmTaxExempt
			// 
			this.tsmTaxExempt.Image = global::rkcrm.Properties.Resources.Calendar_Icon;
			this.tsmTaxExempt.Name = "tsmTaxExempt";
			this.tsmTaxExempt.Size = new System.Drawing.Size(227, 22);
			this.tsmTaxExempt.Text = "Edit Tax Exempt Expiration";
			this.tsmTaxExempt.Click += new System.EventHandler(this.TaxExcempt_Click);
			// 
			// tsmCreditCard
			// 
			this.tsmCreditCard.Image = global::rkcrm.Properties.Resources.Credit_Card_Icon;
			this.tsmCreditCard.Name = "tsmCreditCard";
			this.tsmCreditCard.Size = new System.Drawing.Size(227, 22);
			this.tsmCreditCard.Text = "Edit Credit Card Expiration";
			this.tsmCreditCard.Click += new System.EventHandler(this.CreditCard_Click);
			// 
			// mss_2
			// 
			this.mss_2.Name = "mss_2";
			this.mss_2.Size = new System.Drawing.Size(224, 6);
			// 
			// tsmActivityStatus
			// 
			this.tsmActivityStatus.Image = global::rkcrm.Properties.Resources.Deactivate_Customer;
			this.tsmActivityStatus.Name = "tsmActivityStatus";
			this.tsmActivityStatus.Size = new System.Drawing.Size(227, 22);
			this.tsmActivityStatus.Text = "Edit Customer Activity Status";
			this.tsmActivityStatus.Click += new System.EventHandler(this.ActivityStatus_ButtonClick);
			// 
			// mss_3
			// 
			this.mss_3.Name = "mss_3";
			this.mss_3.Size = new System.Drawing.Size(224, 6);
			// 
			// tsmInvoices
			// 
			this.tsmInvoices.Image = global::rkcrm.Properties.Resources.invoice_icon_28x28;
			this.tsmInvoices.Name = "tsmInvoices";
			this.tsmInvoices.Size = new System.Drawing.Size(227, 22);
			this.tsmInvoices.Text = "View Customer Invoices";
			this.tsmInvoices.Click += new System.EventHandler(this.Invoices_Click);
			// 
			// mss_4
			// 
			this.mss_4.Name = "mss_4";
			this.mss_4.Size = new System.Drawing.Size(224, 6);
			// 
			// tsmProperties
			// 
			this.tsmProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsmProperties.Name = "tsmProperties";
			this.tsmProperties.Size = new System.Drawing.Size(227, 22);
			this.tsmProperties.Text = "Properties";
			this.tsmProperties.Click += new System.EventHandler(this.Properties_Click);
			// 
			// tsbAddCustomer
			// 
			this.tsbAddCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddCustomer.Image = global::rkcrm.Properties.Resources.New_Customer_Icon;
			this.tsbAddCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddCustomer.Name = "tsbAddCustomer";
			this.tsbAddCustomer.Size = new System.Drawing.Size(23, 20);
			this.tsbAddCustomer.Text = "Add Customer";
			this.tsbAddCustomer.Click += new System.EventHandler(this.AddCustomer_Click);
			// 
			// tsbEditCustomer
			// 
			this.tsbEditCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbEditCustomer.Image = global::rkcrm.Properties.Resources.Edit_Customer_28x28;
			this.tsbEditCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEditCustomer.Name = "tsbEditCustomer";
			this.tsbEditCustomer.Size = new System.Drawing.Size(23, 20);
			this.tsbEditCustomer.Text = "Edit Customer";
			this.tsbEditCustomer.Click += new System.EventHandler(this.EditCustomer_Click);
			// 
			// tsbAddContact
			// 
			this.tsbAddContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddContact.Image = global::rkcrm.Properties.Resources.New_Contact_Icon;
			this.tsbAddContact.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddContact.Name = "tsbAddContact";
			this.tsbAddContact.Size = new System.Drawing.Size(23, 20);
			this.tsbAddContact.Text = "Add Contact";
			this.tsbAddContact.Click += new System.EventHandler(this.AddContact_Click);
			// 
			// tsbAddProject
			// 
			this.tsbAddProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddProject.Image = global::rkcrm.Properties.Resources.New_Project28x28;
			this.tsbAddProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddProject.Name = "tsbAddProject";
			this.tsbAddProject.Size = new System.Drawing.Size(23, 20);
			this.tsbAddProject.Text = "Add Project";
			this.tsbAddProject.Click += new System.EventHandler(this.AddProject_Click);
			// 
			// tsbTaxExcempt
			// 
			this.tsbTaxExcempt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbTaxExcempt.Image = global::rkcrm.Properties.Resources.Calendar_Icon;
			this.tsbTaxExcempt.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbTaxExcempt.Name = "tsbTaxExcempt";
			this.tsbTaxExcempt.Size = new System.Drawing.Size(23, 20);
			this.tsbTaxExcempt.Text = "Edit Tax Exempt Expiration";
			this.tsbTaxExcempt.Click += new System.EventHandler(this.TaxExcempt_Click);
			// 
			// tsbCreditCard
			// 
			this.tsbCreditCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCreditCard.Image = global::rkcrm.Properties.Resources.Credit_Card_Icon;
			this.tsbCreditCard.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCreditCard.Name = "tsbCreditCard";
			this.tsbCreditCard.Size = new System.Drawing.Size(23, 20);
			this.tsbCreditCard.Text = "Edit Credit Card Expiration";
			this.tsbCreditCard.Click += new System.EventHandler(this.CreditCard_Click);
			// 
			// tsbActivityStatus
			// 
			this.tsbActivityStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbActivityStatus.Image = global::rkcrm.Properties.Resources.Deactivate_Customer;
			this.tsbActivityStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbActivityStatus.Name = "tsbActivityStatus";
			this.tsbActivityStatus.Size = new System.Drawing.Size(23, 20);
			this.tsbActivityStatus.Text = "Edit Customer Activity Status";
			this.tsbActivityStatus.Click += new System.EventHandler(this.ActivityStatus_ButtonClick);
			// 
			// tsbInvoices
			// 
			this.tsbInvoices.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbInvoices.Image = global::rkcrm.Properties.Resources.invoice_icon_28x28;
			this.tsbInvoices.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbInvoices.Name = "tsbInvoices";
			this.tsbInvoices.Size = new System.Drawing.Size(23, 20);
			this.tsbInvoices.Text = "View Customer Invoices";
			this.tsbInvoices.Click += new System.EventHandler(this.Invoices_Click);
			// 
			// tsbProperties
			// 
			this.tsbProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsbProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbProperties.Name = "tsbProperties";
			this.tsbProperties.Size = new System.Drawing.Size(23, 20);
			this.tsbProperties.Text = "Properties";
			this.tsbProperties.Click += new System.EventHandler(this.Properties_Click);
			// 
			// CustomerDropDown
			// 
			this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tdbMenuItems,
            this.tsbAddCustomer,
            this.tsbEditCustomer,
            this.tss_0,
            this.tsbAddContact,
            this.tsbAddProject,
            this.tss_1,
            this.tsbTaxExcempt,
            this.tsbCreditCard,
            this.tss_2,
            this.tsbActivityStatus,
            this.tss_3,
            this.tsbInvoices,
            this.tss_4,
            this.tsbProperties});
			this.Size = new System.Drawing.Size(31, 349);
			this.ResumeLayout(false);

        }

		private void Disable()
		{
			tsbActivityStatus.Enabled = false;
			tsbAddContact.Enabled = false;
			tsbAddProject.Enabled = false;
			tsbCreditCard.Enabled = false;
			tsbEditCustomer.Enabled = false;
			tsbInvoices.Enabled = false;
			tsbTaxExcempt.Enabled = false;
			tsbProperties.Enabled = false;
			tsmActivityStatus.Enabled = false;
			tsmAddContact.Enabled = false;
			tsmAddProject.Enabled = false;
			tsmCreditCard.Enabled = false;
			tsmEditCustomer.Enabled = false;
			tsmInvoices.Enabled = false;
			tsmTaxExempt.Enabled = false;
			tsmProperties.Enabled = false;
		}

		private void Enable()
		{
			tsbActivityStatus.Enabled = true;
			tsbAddContact.Enabled = true;
			tsbAddProject.Enabled = true;
			tsbCreditCard.Enabled = true;
			tsbEditCustomer.Enabled = true;
			tsbInvoices.Enabled = true;
			tsbTaxExcempt.Enabled = true;
			tsbProperties.Enabled = true;
			tsmActivityStatus.Enabled = true;
			tsmAddContact.Enabled = true;
			tsmAddProject.Enabled = true;
			tsmCreditCard.Enabled = true;
			tsmEditCustomer.Enabled = true;
			tsmInvoices.Enabled = true;
			tsmTaxExempt.Enabled = true;
			tsmProperties.Enabled = true;
		}

		private void ValidateSecurityAccess()
		{
			// this.Items[0] = tdbMenuItems
			// this.Items[1] = tsbAddCustomer
			// this.Items[2] = tsbEditCustomer
			// this.Items[3] = tss_0
			// this.Items[4] = tsbAddContact
			// this.Items[5] = tsbAddProject
			// this.Items[6] = tss_1
			// this.Items[7] = tsbTaxExcempt
			// this.Items[8] = tsbCreditCard
			// this.Items[9] = tss_2
			// this.Items[10] = tsbActivityStatus
			// this.Items[11] = tss_3
			// this.Items[12] = tsbInvoices
			// this.Items[13] = mss_4
			// this.Items[14] = tsmProperties

			//string text = string.Empty;
			//foreach (ToolStripItem c in this.Items)
			//    text += "this.Items[" + this.Items.IndexOf(c) + "] = " + c.Name + "\r\n";
			//MessageBox.Show(text);

			// accessCode = 32351 (0b111111001011111) Excludes tsbTaxExcempt, tsbCreditCard and tsbActivityStatus
			// accessCode = 32735 (0b111111111011111) Excludes tsbActivityStatus
			// accessCode = 32767 (0b111111111111111) Access to all buttons

			int accessCode = 32767;
			char[] charArray = Convert.ToString(accessCode, 2).PadRight(this.Items.Count, '0').ToCharArray();
			int index = 0;

			foreach (ToolStripItem oItem in this.Items)
			{
				switch (oItem.Name)
				{
					case "tss_1":
						oItem.Visible = (charArray[index + 1] == '1' || charArray[index + 2] == '1');
						break;
					case "tss_2":
						oItem.Visible = (charArray[index + 1] == '1');
						break;
					default:
						oItem.Visible = charArray[index] == '0' ? false : true;
						break;
				}

				index++;
			}

			// this.Items[0] = tsmAddCustomer
			// this.Items[1] = tsmEditCustomer
			// this.Items[2] = mss_0
			// this.Items[3] = tsmAddContact
			// this.Items[4] = tsmAddProject
			// this.Items[5] = mss_1
			// this.Items[6] = tsmTaxExcempt
			// this.Items[7] = tsmCreditCard
			// this.Items[8] = mss_2
			// this.Items[9] = tsmActivityStatus
			// this.Items[10] = mss_3
			// this.Items[11] = tsmInvoices
			// this.Items[12] = mss_4
			// this.Items[13] = tsmProperties

			// accessCode = 16175 (0b11111100101111) Excludes tsbTaxExcempt, tsbCreditCard and tsbActivityStatus
			// accessCode = 16367 (0b11111111101111) Excludes tsbActivityStatus
			// accessCode = 16383 (0b11111111111111) Access to all buttons

			ToolStripDropDownButton menuItems = (ToolStripDropDownButton)this.Items[0];

			index = 0;
			accessCode = 16383;
			charArray = Convert.ToString(accessCode, 2).PadRight(this.Items.Count, '0').ToCharArray();

			foreach (ToolStripItem oItem in menuItems.DropDownItems)
			{

				switch (oItem.Name)
				{
					case "mss_1":
						oItem.Visible = (charArray[index + 1] == '1' || charArray[index + 2] == '1');
						break;
					case "mss_2":
						oItem.Visible = (charArray[index + 1] == '1');
						break;
					default:
						oItem.Visible = charArray[index] == '0' ? false : true;
						break;
				}

				index++;
			}
		}

		private NavigationScreen GetNavigationScreen()
		{
			Control myNavigation = theReferencedList;

			while (!(myNavigation is Navigation.NavigationScreen) && myNavigation.Parent != null)
				myNavigation = myNavigation.Parent;

			if (myNavigation is NavigationScreen)
				return (NavigationScreen)myNavigation;
			else
				return null;
		}

        #endregion


		#region Event Handlers

		void theReferencedList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
				if (e.Item.SubItems[ColumnIndex].Text != string.Empty)
					Enable();
				else
					Disable();
			else
				Disable();
		}

		private void ActivityStatus_ButtonClick(object sender, EventArgs e)
        {
			bool isActive;
			Customer MyCustomer;
			Project generalNotes = null;

			using (CustomerController theController = new CustomerController())
			{
				MyCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));

				//Assume deactivation if the user is not a member of a profit center department
				if (thisUser.HomeDepartment.IsProfitCenter)
					isActive = theController.IsActive(MyCustomer.ID, thisUser.HomeDepartment.ID);
				else
					isActive = true;
			}

			generalNotes = MyCustomer.GetGeneralNotesProject();

			if (!generalNotes.IsArchived)
			{
				rkcrm.Objects.Note.AddNote oForm = new rkcrm.Objects.Note.AddNote();
				rkcrm.Objects.Note.Note newNote = new rkcrm.Objects.Note.Note();

				newNote.ProjectID = generalNotes.ID;

				oForm.MyNote = newNote;
				oForm.MyNote.PurposeID = (isActive ? DEACTIVATION : ACTIVATION);
				oForm.noteControls.cboPurpose.Text = oForm.MyNote.GetContactPurpose().Name;
				oForm.noteControls.cboPurpose.Enabled = false;
				oForm.noteControls.cboDepartment.Enabled = !thisUser.HomeDepartment.IsProfitCenter;
				oForm.noteControls.mtxtNextFollowUp.Enabled = false;
				oForm.noteControls.lblNextFollowUp.Text = "Next Follow Up";
				oForm.noteControls.lblNotes.Text = "Notes*";

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					List<int> Inactives = new List<int>();

					using (rkcrm.Objects.Note.NoteController theController = new rkcrm.Objects.Note.NoteController())
					{
						oForm.MyNote = theController.InsertNote(oForm.MyNote);
					}

					if (oForm.MyNote.ID > 0)
					{
						using (CustomerController theController = new CustomerController())
						{
							if (oForm.MyNote.PurposeID == DEACTIVATION)
								theController.Deactivate(MyCustomer.ID, Convert.ToInt32(oForm.noteControls.cboDepartment.SelectedValue));
							else
								theController.Activate(MyCustomer.ID, Convert.ToInt32(oForm.noteControls.cboDepartment.SelectedValue));

							foreach (DataRow oRow in theController.GetActivityStatuses(MyCustomer.ID).Rows)
								if (!Convert.ToBoolean(oRow["is_active"]))
									Inactives.Add(Convert.ToInt32(oRow["department_id"]));
						}

						OnActivityStatusChanged(new ActivityStatusChangedEventArgs(MyCustomer.ID, Inactives));
					}
				}
			}
			else
				MessageBox.Show("This customer's activity status cannot be changed. Please contact you system administrator.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void Invoices_Click(object sender, EventArgs e)
		{
			ViewInvoices oForm = new ViewInvoices(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));
			oForm.Show();
		}

		private void TaxExcempt_Click(object sender, EventArgs e)
		{
			Customer theCustomer;

			using (CustomerController theController = new CustomerController())
			{
				theCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));
			}

			UpdateTaxExpiration oForm = new UpdateTaxExpiration(theCustomer);
			oForm.ShowDialog();

			if (oForm.DialogResult == DialogResult.OK)
			{
				int index = theReferencedList.Items.IndexOf(theReferencedList.SelectedItems[0]);
				theReferencedList.SelectedItems[0].Selected = false;
				theReferencedList.Items[index].Selected = true;
			}
		}

        private void CreditCard_Click(object sender, EventArgs e)
        {
            Customer theCustomer;

            using (CustomerController theController = new CustomerController())
            {
                theCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));
            }

            UpdateCreditExpiration oForm = new UpdateCreditExpiration(theCustomer);
            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                int index = theReferencedList.Items.IndexOf(theReferencedList.SelectedItems[0]);
                theReferencedList.SelectedItems[0].Selected = false;
                theReferencedList.Items[index].Selected = true;
            }
        }

		private void EditCustomer_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0];

			using (CustomerController theController = new CustomerController())
			{
				myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));
			}
			myNavigation.btnCustomer.PerformClick();
		}

		private void AddContact_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[0];

			using (CustomerController theController = new CustomerController())
			{
				myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));
			}
			myNavigation.btnCustomer.PerformClick();

			//Set the contact screen state to adding
			((ContactScreen)myNavigation.CurrentScreen).MyCustomer = myNavigation.btnCustomer.MyCustomer;
			((ContactScreen)myNavigation.CurrentScreen).MyContact = new Contact();
		}

		private void AddProject_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1];

			using (CustomerController theController = new CustomerController())
			{
				myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));
			}
			myNavigation.btnCustomer.PerformClick();

			((ProjectScreen)myNavigation.CurrentScreen).MyProject = new Project();
		}

		private void AddCustomer_Click(object sender, EventArgs e)
		{
			rkcrm.Objects.NewCustomerWizard oForm = new rkcrm.Objects.NewCustomerWizard();
			oForm.Show();
		}

		private void Properties_Click(object sender, EventArgs e)
		{
			Customer theCustomer = null;
			Objects.PropertiesWindow oForm = null;

			if (!string.IsNullOrEmpty(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text))
			{
				using (CustomerController theController = new CustomerController())
				{
					theCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));
				}

				if (theCustomer != null)
				{
					oForm = new rkcrm.Objects.PropertiesWindow();
					oForm.SelectedObject = theCustomer;
					oForm.Text = "Customer Properties";
					oForm.Show();
				}
			}

		}


        private void Generic_Click(object sender, EventArgs e)
        {
			MessageBox.Show((new NotImplementedException()).Message);
        }

		#endregion


        #region Constructor

        public CustomerDropDown(ListView ReferencedListView, int IdColumn)
            : base()
        {
            InitializeComponent();

			ColumnIndex = IdColumn;

			theReferencedList = ReferencedListView;
			theReferencedList.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(theReferencedList_ItemSelectionChanged);

			Disable();

			ValidateSecurityAccess();
        }

        #endregion


		#region Custom Events

		public event EventHandler<ActivityStatusChangedEventArgs> ActivityStatusChanged;
		protected virtual void OnActivityStatusChanged(ActivityStatusChangedEventArgs e)
		{
			EventHandler<ActivityStatusChangedEventArgs> handler = ActivityStatusChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion

    }

}