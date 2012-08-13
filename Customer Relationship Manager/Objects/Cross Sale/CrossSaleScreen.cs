using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Cross_Sale
{
	class CrossSaleScreen : ObjectScreenBase
	{

		#region Variables

		private ColumnHeader chCustomerID;
		private ColumnHeader chDepartmentID;
		private ColumnHeader chSalesRep;
		private ColumnHeader chDepartment;
		private ColumnHeader chVerified;
		private ToolStrip tsMain;
		private ToolStripButton tsbSave;
		private ToolStripButton tsbSaveClose;
		private ToolStripButton tsbSaveNew;
		private ToolStripSeparator tss_0;
		internal ToolStripButton tsbAdd;
		private ToolStripSeparator tss_1;
		internal ToolStripButton tsbCancel;
		private ToolStripSeparator tss_2;
		private ToolStripButton tsbDelete;
		private ToolStripButton tsbRestore;
		private CrossSaleBoundary crossSaleControls;
		private ColumnHeader chValidated;
		private ColumnHeader chID;

		private const int ADMINISTRATOR = 1;
		private const int CUSTOMER_ID_INDEX = 1;
		private const int DEPARTMENT_ID_INDEX = 2;
		private ToolStripMenuItem tsmDelete;
		private ToolStripMenuItem tsmRestore;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmCancel;
		private const int ID_INDEX = 0;

		#endregion


		#region Properties

		public Customer.Customer MyCustomer
		{
			get { return crossSaleControls.MyCustomer; }
			set
			{
				bool HasChanged = (crossSaleControls.MyCustomer != value);

				crossSaleControls.MyCustomer = value;

				if (HasChanged)
					MyCrossSale = new CrossSale();

				if (value != null)
					LoadList();
			}
		}

		public CrossSale MyCrossSale
		{
			get { return crossSaleControls.MyCrossSale; }
			set
			{
				crossSaleControls.MyCrossSale = value;

				if (value == null)
					SetSearchingMode();
				else
					if (value.CustomerID > 0 && value.DepartmentID > 0)
						SetEditingMode();
					else
						SetAddingMode();
			}
		}

		public override bool IsDirty
		{
			get { return crossSaleControls.IsDirty; }
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.chCustomerID = new System.Windows.Forms.ColumnHeader();
			this.chDepartmentID = new System.Windows.Forms.ColumnHeader();
			this.chSalesRep = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chVerified = new System.Windows.Forms.ColumnHeader();
			this.chValidated = new System.Windows.Forms.ColumnHeader();
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
			this.crossSaleControls = new rkcrm.Objects.Cross_Sale.CrossSaleBoundary();
			this.chID = new System.Windows.Forms.ColumnHeader();
			this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmCancel = new System.Windows.Forms.ToolStripMenuItem();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chCustomerID,
            this.chDepartmentID,
            this.chSalesRep,
            this.chDepartment,
            this.chVerified,
            this.chValidated});
			this.lvwList.Size = new System.Drawing.Size(600, 223);
			this.lvwList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwList_ItemSelectionChanged);
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.crossSaleControls);
			this.scMain.Panel1.Controls.Add(this.tsMain);
			// 
			// chCustomerID
			// 
			this.chCustomerID.Text = "Customer ID";
			this.chCustomerID.Width = 0;
			// 
			// chDepartmentID
			// 
			this.chDepartmentID.Text = "Department ID";
			this.chDepartmentID.Width = 0;
			// 
			// chSalesRep
			// 
			this.chSalesRep.Text = "Sales Rep";
			this.chSalesRep.Width = 120;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 80;
			// 
			// chVerified
			// 
			this.chVerified.Text = "Verified";
			this.chVerified.Width = 75;
			// 
			// chValidated
			// 
			this.chValidated.Text = "Validated";
			this.chValidated.Width = 75;
			// 
			// tsMain
			// 
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
            this.tsbRestore});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(600, 35);
			this.tsMain.TabIndex = 1;
			this.tsMain.Text = "toolStrip1";
			// 
			// tsbSave
			// 
			this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSave.Image = global::rkcrm.Properties.Resources.save;
			this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Size = new System.Drawing.Size(32, 32);
			this.tsbSave.Text = "Save";
			this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
			// 
			// tsbSaveClose
			// 
			this.tsbSaveClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSaveClose.Image = global::rkcrm.Properties.Resources.Save_and_Close;
			this.tsbSaveClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSaveClose.Name = "tsbSaveClose";
			this.tsbSaveClose.Size = new System.Drawing.Size(32, 32);
			this.tsbSaveClose.Text = "Save and Close";
			this.tsbSaveClose.Click += new System.EventHandler(this.tsbSaveClose_Click);
			// 
			// tsbSaveNew
			// 
			this.tsbSaveNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSaveNew.Image = global::rkcrm.Properties.Resources.Save_New;
			this.tsbSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSaveNew.Name = "tsbSaveNew";
			this.tsbSaveNew.Size = new System.Drawing.Size(32, 32);
			this.tsbSaveNew.Text = "Save and Add a New Lead Source";
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
			this.tsbAdd.Image = global::rkcrm.Properties.Resources.New_Icon;
			this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Size = new System.Drawing.Size(32, 32);
			this.tsbAdd.Text = "Add a Lead Source";
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
			this.tsbCancel.Text = "Cancel";
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
			this.tsbDelete.Text = "Delete Lead Source";
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
			this.tsbRestore.Text = "Restore Lead Source";
			this.tsbRestore.Visible = false;
			this.tsbRestore.EnabledChanged += new System.EventHandler(this.tsbRestore_EnabledChanged);
			this.tsbRestore.VisibleChanged += new System.EventHandler(this.tsbRestore_VisibleChanged);
			this.tsbRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// crossSaleControls
			// 
			this.crossSaleControls.BackColor = System.Drawing.Color.White;
			this.crossSaleControls.ChangeHistoryVisible = false;
			this.crossSaleControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crossSaleControls.Location = new System.Drawing.Point(0, 35);
			this.crossSaleControls.MyCrossSale = null;
			this.crossSaleControls.MyCustomer = null;
			this.crossSaleControls.Name = "crossSaleControls";
			this.crossSaleControls.Size = new System.Drawing.Size(600, 206);
			this.crossSaleControls.TabIndex = 2;
			this.crossSaleControls.Title = "Search Cross Sales";
			this.crossSaleControls.TitleBarVisible = true;
			this.crossSaleControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.crossSaleControls_IsDirtyChanged);
			// 
			// chID
			// 
			this.chID.Text = "ID";
			this.chID.Width = 0;
			// 
			// tsmDelete
			// 
			this.tsmDelete.Image = global::rkcrm.Properties.Resources.Delete_icon;
			this.tsmDelete.Name = "tsmDelete";
			this.tsmDelete.Size = new System.Drawing.Size(169, 22);
			this.tsmDelete.Text = "Delete Cross Sale";
			this.tsmDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// tsmRestore
			// 
			this.tsmRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsmRestore.Name = "tsmRestore";
			this.tsmRestore.Size = new System.Drawing.Size(169, 22);
			this.tsmRestore.Text = "Restore Cross Sale";
			this.tsmRestore.Visible = false;
			this.tsmRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(166, 6);
			// 
			// tsmCancel
			// 
			this.tsmCancel.Image = global::rkcrm.Properties.Resources.Cancel;
			this.tsmCancel.Name = "tsmCancel";
			this.tsmCancel.Size = new System.Drawing.Size(169, 22);
			this.tsmCancel.Text = "Cancel";
			this.tsmCancel.Click += new System.EventHandler(this.tsbCancel_Click);
			// 
			// CrossSaleScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ListTitle = "Cross Sales";
			this.Name = "CrossSaleScreen";
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
				this.tsmCancel});
		}

		private void LoadList()
		{
			lvwList.Items.Clear();

			if (MyCustomer != null)
			{
				ListViewItem oItem;
				DataTable oTable;

				using (CrossSaleController theController = new CrossSaleController())
				{
					oTable = theController.GetCrossSales(MyCustomer.ID, (thisUser.Role.ID == ADMINISTRATOR));
				}

				foreach (DataRow oRow in oTable.Rows)
				{
					oItem = new ListViewItem();

					oItem.Text = oRow["relationship_id"].ToString();
					oItem.SubItems.Add(oRow["customer_id"].ToString());
					oItem.SubItems.Add(oRow["department_id"].ToString());
					oItem.SubItems.Add(oRow["sales_rep"].ToString());
					oItem.SubItems.Add(oRow["department"].ToString());
					oItem.SubItems.Add(Convert.ToDateTime(oRow["verified"]).ToShortDateString());
					oItem.SubItems.Add(oRow["validated"] != DBNull.Value ? Convert.ToDateTime(oRow["validated"]).ToShortDateString() : string.Empty);

					if (Convert.ToBoolean(oRow["is_archived"]))
						oItem.BackColor = System.Drawing.Color.LightSteelBlue;
					else
						oItem.BackColor = System.Drawing.Color.White;

					lvwList.Items.Add(oItem);
				}
			}
		}

		private void SetAddingMode()
		{
			tsbAdd.Enabled = false;
			tsbCancel.Enabled = true;
			tsbDelete.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;

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

			tsbDelete.Enabled = !MyCrossSale.IsArchived;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;

			if (thisUser.Role.ID == ADMINISTRATOR)
			{
				tsbDelete.Visible = !MyCrossSale.IsArchived;
				tsbRestore.Visible = !tsbDelete.Visible;
			}
			else
			{
				tsbRestore.Visible = false;
				tsbDelete.Visible = true;
			}

			Clear();
		}

		private void SetSearchingMode()
		{
			tsbAdd.Enabled = true;
			tsbCancel.Enabled = true;
			tsbDelete.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;

			Clear();

			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			if (lvwList.SelectedItems.Count > 0)
				lvwList.SelectedItems[0].Selected = false;

			LoadList();
		}

		private CrossSale GetCrossSale(int ID)
		{
			CrossSale result = null;

			using (CrossSaleController theController = new CrossSaleController())
			{
				result = theController.GetCrossSale(ID);
			}

			return result;
		}

		public new void Clear()
		{
			base.Clear();
		}

		public override bool Save()
		{
			if (crossSaleControls.CommitChanges())
			{
				using (CrossSaleController theController = new CrossSaleController())
				{
					if (MyCrossSale.ID > 0)
						return theController.UpdateCrossSale(MyCrossSale);
					else
					{
						MyCrossSale = theController.InsertCrossSale(MyCrossSale);

						return (MyCrossSale.ID > 0);
					}
				}
			}
			else
				return false;
		}

		#endregion


		#region Event Handlers

		private void lvwList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
			{
				int ID = 0;

				ID = Convert.ToInt32(e.Item.SubItems[ID_INDEX].Text);

				if (IsDirty)
				{
					switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
					{
						case DialogResult.Yes:
							if (Save())
								MyCrossSale = GetCrossSale(ID);
							break;
						case DialogResult.Cancel:
							break;
						default:
							MyCrossSale = GetCrossSale(ID);
							break;
					}
				}
				else
					MyCrossSale = GetCrossSale(ID);
			}
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyCrossSale = MyCrossSale;

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
					MyCrossSale = new CrossSale();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyCustomer != null)
						LoadList();
				}
			}
			else
				MyCrossSale = new CrossSale();
		}

		private void tsbSaveNew_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyCrossSale = new CrossSale();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyCustomer != null)
						LoadList();
				}
			}
			else
				MyCrossSale = new CrossSale();
		}

		private void tsbAdd_Click(object sender, EventArgs e)
		{
			if (IsDirty)
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
							MyCrossSale = new CrossSale();
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyCrossSale = new CrossSale();
						break;
				}
			else
				MyCrossSale = new CrossSale();
		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
							MyCrossSale = new CrossSale();
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyCrossSale = new CrossSale();
						break;
				}
			}
			else
				MyCrossSale = new CrossSale();
		}

		private void tsbDelete_Click(object sender, EventArgs e)
		{
			using (CrossSaleController theController = new CrossSaleController())
			{
				if (IsDirty)
				{
					switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
					{
						case DialogResult.Yes:
							if (crossSaleControls.CommitChanges())
							{
								MyCrossSale.IsArchived = true;
								if (Save())
									MyCrossSale = new CrossSale();
							}
							break;
						case DialogResult.Cancel:
							break;
						default:
							MyCrossSale.IsArchived = true;
							if (Save())
								MyCrossSale = new CrossSale();
							break;
					}
				}
				else
				{
					MyCrossSale.IsArchived = true;
					if (Save())
						MyCrossSale = new CrossSale();
				}
			}
		}

		private void tsbRestore_Click(object sender, EventArgs e)
		{
			MyCrossSale.IsArchived = false;
			if (Save())
				MyCrossSale = MyCrossSale;

			LoadList();
		}

		private void crossSaleControls_IsDirtyChanged(object sender, EventArgs e)
		{
			tsbSave.Enabled = this.IsDirty;
			tsbSaveClose.Enabled = this.IsDirty;
			tsbSaveNew.Enabled = this.IsDirty;
		}

		#endregion


		#region Constructor

		public CrossSaleScreen()
			: base()
		{
			InitializeComponent();
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

		#endregion

	}
}
