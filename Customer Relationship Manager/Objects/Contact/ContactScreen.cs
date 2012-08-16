using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Objects.Phone_Number;
using rkcrm.Navigation;

namespace rkcrm.Objects.Contact
{
	class ContactScreen : ObjectScreenBase
	{

		#region Variables

		private System.Windows.Forms.ToolStripButton tsbSave;
		private System.Windows.Forms.ToolStripButton tsbSaveClose;
		private System.Windows.Forms.ToolStripButton tsbSaveNew;
		private System.Windows.Forms.ToolStripSeparator tss_0;
		private System.Windows.Forms.ToolStripButton tsbAdd;
		private System.Windows.Forms.ToolStripSeparator tss_1;
		private System.Windows.Forms.ToolStripButton tsbCancel;
		private System.Windows.Forms.ToolStripSeparator tss_2;
		private System.Windows.Forms.ToolStripButton tsbDelete;
		private ContactBoundary contactControls;
		private System.Windows.Forms.ColumnHeader chContactID;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chEmail;
		private System.Windows.Forms.ColumnHeader chPhoneNumber;
		private System.Windows.Forms.ToolStrip tsMain;


		private ToolStripButton tsbRestore;
		private const int ADMINISTRATOR = 1;
		private ToolStripMenuItem tsmDelete;
		private ToolStripMenuItem tsmRestore;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmCancel;
		private ToolStripSeparator mss_2;
		private ToolStripMenuItem tsmProperties;
		private ToolStripSeparator tss_3;
		private ToolStripButton tsbProperties;
		private const int NAME_INDEX = 1;
		#endregion


		#region Properties

		public Customer.Customer MyCustomer
		{
			get
			{
				NavigationScreen navigation = GetNavigationScreen();
				return navigation.btnCustomer.MyCustomer;
			}
			set
			{
				NavigationScreen navigation = GetNavigationScreen();
				bool HasChanged = (navigation.btnCustomer.MyCustomer != value);

				navigation.btnCustomer.MyCustomer = value;

				if (HasChanged)
					MyContact = new Contact();

				if (value != null)
					LoadList();
			}
		}

		public Contact MyContact
		{
			get { return contactControls.MyContact; }
			set 
			{
				if (contactControls.MyContact != null)
					contactControls.MyContact.Dispose();

				contactControls.MyContact = value;
			}
		}

		public override bool IsDirty
		{
			get { return contactControls.IsDirty; }
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

		/// <summary>
		/// Populates the System.Windows.Forms.ListView object with the customer's contacts
		/// </summary>
		private void LoadList()
		{
			if (MyCustomer != null)
			{
				lvwList.Items.Clear();

				DataTable contacts = null;

				using (ContactController theController = new ContactController())
				{
					contacts = theController.GetContacts(MyCustomer.ID, (thisUser.Role.ID == ADMINISTRATOR));
				}

				if (contacts.Rows.Count > 0)
				{
					ListViewItem newItem;
					ListViewItem prevItem = new ListViewItem(string.Empty);

					foreach (DataRow oRow in contacts.Rows)
					{
						newItem = new ListViewItem();

						newItem.Text = oRow["contact_id"].ToString();

						if (oRow["contact_id"].ToString() == prevItem.Text)
						{
							newItem.SubItems.Add(string.Empty);
							newItem.SubItems.Add(string.Empty);
						}
						else
						{
							newItem.SubItems.Add(oRow["contact"].ToString());
							newItem.SubItems.Add(oRow["email_address"].ToString());

							prevItem = newItem;
						}

						if (Convert.ToBoolean(oRow["is_archived"]))
							newItem.BackColor = System.Drawing.Color.LightSteelBlue;
						else
							newItem.BackColor = System.Drawing.Color.White;

						newItem.SubItems.Add(FormatPhoneNumber(oRow["phone_number"].ToString()));

						lvwList.Items.Add(newItem);
					}
				}
			}
		}

		private void InitializeComponent()
		{
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.tsbSaveClose = new System.Windows.Forms.ToolStripButton();
			this.tsbSaveNew = new System.Windows.Forms.ToolStripButton();
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbAdd = new System.Windows.Forms.ToolStripButton();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCancel = new System.Windows.Forms.ToolStripButton();
			this.tss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.tsbRestore = new System.Windows.Forms.ToolStripButton();
			this.tss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbProperties = new System.Windows.Forms.ToolStripButton();
			this.contactControls = new rkcrm.Objects.Contact.ContactBoundary();
			this.chContactID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chEmail = new System.Windows.Forms.ColumnHeader();
			this.chPhoneNumber = new System.Windows.Forms.ColumnHeader();
			this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmCancel = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chContactID,
            this.chName,
            this.chEmail,
            this.chPhoneNumber});
			this.lvwList.Size = new System.Drawing.Size(600, 175);
			this.lvwList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwList_ItemSelectionChanged);
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.contactControls);
			this.scMain.Panel1.Controls.Add(this.tsMain);
			this.scMain.SplitterDistance = 291;
			// 
			// tsMain
			// 
			this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbSaveClose,
            this.tsbSaveNew,
            this.tss_0,
            this.tsbAdd,
            this.tss_1,
            this.tsbCancel,
            this.tss_2,
            this.tsbDelete,
            this.tsbRestore,
            this.tss_3,
            this.tsbProperties});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(600, 35);
			this.tsMain.TabIndex = 0;
			this.tsMain.Text = "toolStrip1";
			// 
			// tsbSave
			// 
			this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSave.Image = global::rkcrm.Properties.Resources.save;
			this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Size = new System.Drawing.Size(32, 32);
			this.tsbSave.Text = "Save Changes";
			this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
			// 
			// tsbSaveClose
			// 
			this.tsbSaveClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSaveClose.Image = global::rkcrm.Properties.Resources.Save_and_Close;
			this.tsbSaveClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSaveClose.Name = "tsbSaveClose";
			this.tsbSaveClose.Size = new System.Drawing.Size(32, 32);
			this.tsbSaveClose.Text = "Save Changes and Close";
			this.tsbSaveClose.Click += new System.EventHandler(this.tsbSaveClose_Click);
			// 
			// tsbSaveNew
			// 
			this.tsbSaveNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSaveNew.Image = global::rkcrm.Properties.Resources.Save_New;
			this.tsbSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSaveNew.Name = "tsbSaveNew";
			this.tsbSaveNew.Size = new System.Drawing.Size(32, 32);
			this.tsbSaveNew.Text = "Save Changes then Add a Contact";
			this.tsbSaveNew.Visible = false;
			this.tsbSaveNew.Click += new System.EventHandler(this.tsbSaveNew_Click);
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(6, 35);
			this.tss_0.Visible = false;
			// 
			// tsbAdd
			// 
			this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAdd.Image = global::rkcrm.Properties.Resources.New_Contact_Icon;
			this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Size = new System.Drawing.Size(32, 32);
			this.tsbAdd.Text = "Add a Contact";
			this.tsbAdd.Visible = false;
			this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
			// 
			// tss_1
			// 
			this.tss_1.Name = "tss_1";
			this.tss_1.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbCancel
			// 
			this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCancel.Image = global::rkcrm.Properties.Resources.Cancel;
			this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCancel.Name = "tsbCancel";
			this.tsbCancel.Size = new System.Drawing.Size(32, 32);
			this.tsbCancel.Text = "Cancel Changes";
			this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
			// 
			// tss_2
			// 
			this.tss_2.Name = "tss_2";
			this.tss_2.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbDelete
			// 
			this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbDelete.Image = global::rkcrm.Properties.Resources.Delete_icon;
			this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Size = new System.Drawing.Size(32, 32);
			this.tsbDelete.Text = "Delete Contact";
			this.tsbDelete.EnabledChanged += new System.EventHandler(this.tsbDelete_EnabledChanged);
			this.tsbDelete.VisibleChanged += new System.EventHandler(this.tsbDelete_VisibleChanged);
			this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// tsbRestore
			// 
			this.tsbRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRestore.Name = "tsbRestore";
			this.tsbRestore.Size = new System.Drawing.Size(32, 32);
			this.tsbRestore.Text = "Restore Contact";
			this.tsbRestore.Visible = false;
			this.tsbRestore.EnabledChanged += new System.EventHandler(this.tsbRestore_EnabledChanged);
			this.tsbRestore.VisibleChanged += new System.EventHandler(this.tsbRestore_VisibleChanged);
			this.tsbRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// tss_3
			// 
			this.tss_3.Name = "tss_3";
			this.tss_3.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbProperties
			// 
			this.tsbProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsbProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbProperties.Name = "tsbProperties";
			this.tsbProperties.Size = new System.Drawing.Size(32, 32);
			this.tsbProperties.Text = "Properties";
			this.tsbProperties.EnabledChanged += new System.EventHandler(this.tsbProperties_EnabledChanged);
			this.tsbProperties.VisibleChanged += new System.EventHandler(this.tsbProperties_VisibleChanged);
			this.tsbProperties.Click += new System.EventHandler(this.tsbProperties_Click);
			// 
			// contactControls
			// 
			this.contactControls.AutoScroll = true;
			this.contactControls.AutoScrollMinSize = new System.Drawing.Size(0, 305);
			this.contactControls.BackColor = System.Drawing.Color.White;
			this.contactControls.ChangeHistoryVisible = true;
			this.contactControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contactControls.Location = new System.Drawing.Point(0, 35);
			this.contactControls.MyContact = null;
			this.contactControls.Name = "contactControls";
			this.contactControls.Size = new System.Drawing.Size(600, 254);
			this.contactControls.TabIndex = 1;
			this.contactControls.Title = "Search Contacts";
			this.contactControls.TitleBarVisible = true;
			this.contactControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.contactControls_IsDirtyChanged);
			this.contactControls.MyContactChanged += new System.EventHandler<System.EventArgs>(this.contactControls_MyContactChanged);
			// 
			// chContactID
			// 
			this.chContactID.Width = 0;
			// 
			// chName
			// 
			this.chName.Text = "Name";
			this.chName.Width = 200;
			// 
			// chEmail
			// 
			this.chEmail.Text = "Email";
			this.chEmail.Width = 200;
			// 
			// chPhoneNumber
			// 
			this.chPhoneNumber.Text = "Phone Number";
			this.chPhoneNumber.Width = 90;
			// 
			// tsmDelete
			// 
			this.tsmDelete.Image = global::rkcrm.Properties.Resources.Delete_icon;
			this.tsmDelete.Name = "tsmDelete";
			this.tsmDelete.Size = new System.Drawing.Size(158, 22);
			this.tsmDelete.Text = "Delete Contact";
			this.tsmDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// tsmRestore
			// 
			this.tsmRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsmRestore.Name = "tsmRestore";
			this.tsmRestore.Size = new System.Drawing.Size(158, 22);
			this.tsmRestore.Text = "Restore Contact";
			this.tsmRestore.Visible = false;
			this.tsmRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(155, 6);
			// 
			// tsmCancel
			// 
			this.tsmCancel.Image = global::rkcrm.Properties.Resources.Cancel;
			this.tsmCancel.Name = "tsmCancel";
			this.tsmCancel.Size = new System.Drawing.Size(158, 22);
			this.tsmCancel.Text = "Cancel";
			this.tsmCancel.Click += new System.EventHandler(this.tsbCancel_Click);
			// 
			// mss_2
			// 
			this.mss_2.Name = "mss_2";
			this.mss_2.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmProperties
			// 
			this.tsmProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsmProperties.Name = "tsmProperties";
			this.tsmProperties.Size = new System.Drawing.Size(152, 22);
			this.tsmProperties.Text = "Properties";
			this.tsmProperties.Click += new System.EventHandler(this.tsbProperties_Click);
			// 
			// ContactScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ListTitle = "Contacts";
			this.Name = "ContactScreen";
			this.Controls.SetChildIndex(this.scMain, 0);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel1.PerformLayout();
			this.scMain.Panel2.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);

		}

		private void InitializeActions()
		{
			tsmActions.DropDownItems.AddRange(new ToolStripItem[] {
				this.tsmDelete,
				this.tsmRestore,
				this.mss_1,
				this.tsmCancel,
				this.mss_2,
				this.tsmProperties});
		}

		private void SetAddingMode()
		{
			tsbAdd.Enabled = false;
			tsbCancel.Enabled = true;
			tsbDelete.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbProperties.Enabled = false;

			tsbRestore.Visible = false;
			tsbDelete.Visible = true;

			Clear();
			IsDisposable = true;

			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			if (lvwList.SelectedItems.Count > 0)
				lvwList.SelectedItems[0].Selected = false;

			LoadList();
		}

		private void SetEditingMode()
		{
			tsbAdd.Enabled = true;
			tsbCancel.Enabled = true;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbDelete.Enabled = !MyContact.IsArchived;
			tsbRestore.Enabled = MyContact.IsArchived;
			tsbProperties.Enabled = true;

			if (thisUser.Role.ID == ADMINISTRATOR)
			{
				tsbDelete.Visible = !MyContact.IsArchived;
				tsbRestore.Visible = !tsbDelete.Visible;
			}
			else
			{
				tsbRestore.Visible = false;
				tsbDelete.Visible = true;
			}

			Clear();
			IsDisposable = false;
		}

		private void SetSearchingMode()
		{
			tsbAdd.Enabled = true;
			tsbCancel.Enabled = true;
			tsbDelete.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbProperties.Enabled = false;

			Clear();

			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			if(lvwList.SelectedItems.Count > 0)
				lvwList.SelectedItems[0].Selected = false;

			LoadList();
		}

		public new void Clear()
		{
			base.Clear();
		}

		private void SavePhoneNumbers()
		{
		}

		public override bool Save()
		{
			return contactControls.Save();
		}

		public override void RefreshData()
		{
			MyContact = MyContact;
		}

		private int GetContactCount()
		{
			int result = 0;

			foreach (ListViewItem oItem in lvwList.Items)
				if (!string.IsNullOrEmpty(oItem.SubItems[NAME_INDEX].Text) && oItem.BackColor != System.Drawing.Color.LightSteelBlue)
					result++;

			return result;
		}

		#endregion


		#region Event Handlers

		private void contactControls_MyContactChanged(object sender, EventArgs e)
		{

			if (MyContact == null)
				SetSearchingMode();
			else
				if (MyContact.ID > 0)
					SetEditingMode();
				else
				{
					if (MyContact.CustomerID != MyCustomer.ID)
						MyContact.CustomerID = MyCustomer.ID;

					SetAddingMode();
				}
		}

		private void lvwList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
			{
				if (IsDirty)
				{
					switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
					{
						case DialogResult.Yes:
							if (Save())
							{
								using (ContactController theController = new ContactController())
								{
									MyContact = theController.GetContact(Convert.ToInt32(e.Item.Text));
								}
							}
							break;
						case DialogResult.Cancel:
							break;
						default:
							using (ContactController theController = new ContactController())
							{
								MyContact = theController.GetContact(Convert.ToInt32(e.Item.Text));
							}
							break;
					}
				}
				else
				{
					using (ContactController theController = new ContactController())
					{
						MyContact = theController.GetContact(Convert.ToInt32(e.Item.Text));
					}
				}
			}
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyContact = MyContact;

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyCustomer != null)
						LoadList();
				}
			}
		}

		private void tsbSaveClose_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyContact = new Contact();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyCustomer != null)
						LoadList();
				}
			}
			else
				MyContact = new Contact();
		}

		private void tsbSaveNew_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyContact = new Contact();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyCustomer != null)
						LoadList();
				}
			}
			else
				MyContact = new Contact();
		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
							MyContact = new Contact();
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyContact = new Contact();
						break;
				}
			}
			else
				MyContact = new Contact();
		}

		private void tsbAdd_Click(object sender, EventArgs e)
		{
			if (IsDirty)
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
							MyContact = new Contact();
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyContact = new Contact();
						break;
				}
			else
				MyContact = new Contact();
		}

		private void tsbDelete_Click(object sender, EventArgs e)
		{
			if (GetContactCount() > 1)
			{
				if (IsDirty)
				{
					switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
					{
						case DialogResult.Yes:
							MyContact.IsArchived = true;
							if (Save())
								MyContact = new Contact();
							break;
						case DialogResult.Cancel:
							break;
						default:
							MyContact.IsArchived = true;
							if (Save())
								MyContact = new Contact();
							break;
					}
				}
				else
				{
					MyContact.IsArchived = true;
					if (Save())
						MyContact = new Contact();
				}
			}
			else
				MessageBox.Show("Cannot delete this contact. The customer associated with this contact must have at least one contact.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void tsbRestore_Click(object sender, EventArgs e)
		{
			MyContact.IsArchived = false;
			if (Save())
				MyContact = MyContact;

			LoadList();
		}

		private void contactControls_IsDirtyChanged(object sender, EventArgs e)
		{
			tsbSave.Enabled = this.IsDirty;
			tsbSaveClose.Enabled = this.IsDirty;
			tsbSaveNew.Enabled = this.IsDirty;
		}

		private void tsbProperties_Click(object sender, EventArgs e)
		{
			if (MyContact != null && MyContact.ID > 0)
			{
				Objects.PropertiesWindow oForm =  new rkcrm.Objects.PropertiesWindow();
				oForm.SelectedObject = MyContact;
				oForm.Text = "Contact Properties";
				oForm.Show();
			}
		}

		#endregion


		#region Constructor

		public ContactScreen()
			: base()
		{
			InitializeComponent();
			InitializeActions();
		}

		#endregion


		#region Special Button Handlers

		private void tsbDelete_EnabledChanged(object sender, EventArgs e)
		{
			tsmDelete.Enabled = tsbDelete.Enabled;
		}

		private void tsbDelete_VisibleChanged(object sender, EventArgs e)
		{
			tsmDelete.Visible = tsbDelete.Visible;
		}

		private void tsbRestore_EnabledChanged(object sender, EventArgs e)
		{
			tsmRestore.Enabled = tsbRestore.Enabled;
		}

		private void tsbRestore_VisibleChanged(object sender, EventArgs e)
		{
			tsmRestore.Visible = tsbRestore.Visible;
		}

		private void tsbProperties_EnabledChanged(object sender, EventArgs e)
		{
			tsmProperties.Enabled = tsbProperties.Enabled;
		}

		private void tsbProperties_VisibleChanged(object sender, EventArgs e)
		{
			tsmProperties.Visible = tsbProperties.Visible;
		}

		#endregion

	}
}
