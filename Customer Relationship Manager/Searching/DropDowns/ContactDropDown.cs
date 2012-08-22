using System;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Navigation;
using rkcrm.Objects.Contact;

namespace rkcrm.Searching.DropDowns
{
	class ContactDropDown : ToolStripDropDown
	{

		#region Variables

		private ToolStripDropDownButton tdbMenuItems;
		private ToolStripButton tsbEdit;
		private ToolStripSeparator tss_0;
		private ToolStripButton tsbDelete;
		private ToolStripMenuItem tsmEdit;
		private ToolStripSeparator mss_0;
		private ToolStripMenuItem tsmDelete;
		private ToolStripMenuItem tsmRestore;
		private ToolStripButton tsbRestore;

		private ListView theReferencedList;
		private ToolStripSeparator tss_1;
		private ToolStripButton tsbProperties;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmProperties;
		private int ColumnIndex;

		#endregion


		#region Security Variables

		private bool bolDeleteIsAccessible;
		private bool bolRestoreIsAccessible;
		private bool bolGotoContactIsAccessible;
		private bool bolPropertiesIsAccessible;

		#endregion


		#region Properties

		public bool HasDelete
		{
			get { return bolDeleteIsAccessible; }
		}

		public bool HasRestore
		{
			get { return bolRestoreIsAccessible; }
		}

		public bool HasGotoContact
		{
			get { return bolGotoContactIsAccessible; }
		}

		public bool HasViewProperties
		{
			get { return bolPropertiesIsAccessible; }
		}

		#endregion


		#region Method

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactDropDown));
			this.tdbMenuItems = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbEdit = new System.Windows.Forms.ToolStripButton();
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.tsbRestore = new System.Windows.Forms.ToolStripButton();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbProperties = new System.Windows.Forms.ToolStripButton();
			this.SuspendLayout();
			// 
			// tdbMenuItems
			// 
			this.tdbMenuItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tdbMenuItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEdit,
            this.mss_0,
            this.tsmDelete,
            this.tsmRestore,
            this.mss_1,
            this.tsmProperties});
			this.tdbMenuItems.Image = ((System.Drawing.Image)(resources.GetObject("tdbMenuItems.Image")));
			this.tdbMenuItems.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tdbMenuItems.Name = "tdbMenuItems";
			this.tdbMenuItems.Size = new System.Drawing.Size(29, 20);
			this.tdbMenuItems.Text = "toolStripDropDownButton1";
			// 
			// tsmEdit
			// 
			this.tsmEdit.Image = global::rkcrm.Properties.Resources.Edit_Contact_28x28;
			this.tsmEdit.Name = "tsmEdit";
			this.tsmEdit.Size = new System.Drawing.Size(158, 22);
			this.tsmEdit.Text = "Edit Contact";
			this.tsmEdit.Click += new System.EventHandler(this.Edit_Click);
			// 
			// mss_0
			// 
			this.mss_0.Name = "mss_0";
			this.mss_0.Size = new System.Drawing.Size(155, 6);
			// 
			// tsmDelete
			// 
			this.tsmDelete.Image = global::rkcrm.Properties.Resources.Delete_Contact_Icon;
			this.tsmDelete.Name = "tsmDelete";
			this.tsmDelete.Size = new System.Drawing.Size(158, 22);
			this.tsmDelete.Text = "Delete Contact";
			// 
			// tsmRestore
			// 
			this.tsmRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsmRestore.Name = "tsmRestore";
			this.tsmRestore.Size = new System.Drawing.Size(158, 22);
			this.tsmRestore.Text = "Restore Contact";
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(155, 6);
			// 
			// tsmProperties
			// 
			this.tsmProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsmProperties.Name = "tsmProperties";
			this.tsmProperties.Size = new System.Drawing.Size(158, 22);
			this.tsmProperties.Text = "Properties";
			this.tsmProperties.Click += new System.EventHandler(this.Properties_Click);
			// 
			// tsbEdit
			// 
			this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbEdit.Image = global::rkcrm.Properties.Resources.Edit_Contact_28x28;
			this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEdit.Name = "tsbEdit";
			this.tsbEdit.Size = new System.Drawing.Size(23, 20);
			this.tsbEdit.Text = "Edit Contact";
			this.tsbEdit.Click += new System.EventHandler(this.Edit_Click);
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(6, 23);
			// 
			// tsbDelete
			// 
			this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbDelete.Image = global::rkcrm.Properties.Resources.Delete_Contact_Icon;
			this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Size = new System.Drawing.Size(23, 20);
			this.tsbDelete.Text = "Delete Contact";
			// 
			// tsbRestore
			// 
			this.tsbRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRestore.Name = "tsbRestore";
			this.tsbRestore.Size = new System.Drawing.Size(23, 20);
			this.tsbRestore.Text = "Restore Contact";
			this.tsbRestore.Visible = false;
			// 
			// tss_1
			// 
			this.tss_1.Name = "tss_1";
			this.tss_1.Size = new System.Drawing.Size(6, 23);
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
			// ContactDropDown
			// 
			this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tdbMenuItems,
            this.tsbEdit,
            this.tss_0,
            this.tsbDelete,
            this.tsbRestore,
            this.tss_1,
            this.tsbProperties});
			this.Size = new System.Drawing.Size(31, 165);
			this.ResumeLayout(false);

		}

		private void Disable()
		{
			tsbDelete.Enabled = false;
			tsbEdit.Enabled = false;
			tsbRestore.Enabled = false;
			tsbProperties.Enabled = false;
			tsmDelete.Enabled = false;
			tsmEdit.Enabled = false;
			tsmRestore.Enabled = false;
			tsmProperties.Enabled = false;
		}

		private void Enable()
		{
			tsbDelete.Enabled = true;
			tsbEdit.Enabled = true;
			tsbRestore.Enabled = true;
			tsbProperties.Enabled = true;
			tsmDelete.Enabled = true;
			tsmEdit.Enabled = true;
			tsmRestore.Enabled = true;
			tsmProperties.Enabled = true;
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

		internal void DetermineAccess()
		{
			bolDeleteIsAccessible = thisUser.MyTasks.Contains((int)Tasks.Delete);
			bolRestoreIsAccessible = thisUser.MyTasks.Contains((int)Tasks.Restore);
			bolGotoContactIsAccessible = thisUser.MyTasks.Contains((int)Tasks.GotoContact);
			bolPropertiesIsAccessible = thisUser.MyTasks.Contains((int)Tasks.ViewProperties);

			tsmDelete.Visible = tsbDelete.Visible = bolDeleteIsAccessible;
			tsmRestore.Visible = tsbRestore.Visible = bolRestoreIsAccessible;
			tsmEdit.Visible = tsbEdit.Visible = bolGotoContactIsAccessible;
			tsmProperties.Visible = tsbProperties.Visible = bolPropertiesIsAccessible;
			tss_0.Visible = mss_0.Visible = (bolGotoContactIsAccessible && (bolDeleteIsAccessible || bolRestoreIsAccessible));
			tss_1.Visible = mss_1.Visible = (bolPropertiesIsAccessible && (bolDeleteIsAccessible || bolRestoreIsAccessible));
		}

		#endregion


		#region Event Handler

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

		private void Edit_Click(object sender, System.EventArgs e)
		{
			Contact newContact = null;
			NavigationScreen myNavigation = GetNavigationScreen();
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[0];

			using (ContactController theController = new ContactController())
			{
				newContact = theController.GetContact(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));
				myNavigation.btnCustomer.MyCustomer = newContact.GetCustomer();
			}

			myNavigation.btnCustomer.PerformClick();

			foreach (ScreenBase theScreen in myNavigation.OpenScreens)
			{
				if (theScreen is ContactScreen)
				{
					((ContactScreen)theScreen).MyContact = newContact;
				}
			}
		}

		private void Properties_Click(object sender, EventArgs e)
		{
			Contact theContact = null;
			Objects.PropertiesWindow oForm = null;

			if (!string.IsNullOrEmpty(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text))
			{
				using (ContactController theController = new ContactController())
				{
					theContact = theController.GetContact(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ColumnIndex].Text));
				}

				if (theContact != null)
				{
					oForm = new rkcrm.Objects.PropertiesWindow();
					oForm.SelectedObject = theContact;
					oForm.Text = "Contact Properties";
					oForm.Show();
				}
			}
		}

		#endregion


		#region Enumerations

		private enum Tasks
		{
			Delete = 32,
			Restore = 33,
			GotoContact = 5,
			ViewProperties = 20
		};

		#endregion


		#region Constructor

		public ContactDropDown(ListView ReferencedListView, int IdColumn)
			: base()
		{
			ColumnIndex = IdColumn;
			theReferencedList = ReferencedListView;
			theReferencedList.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(theReferencedList_ItemSelectionChanged);

			InitializeComponent();
			DetermineAccess();
			Disable();
		}

		#endregion

	}
}
