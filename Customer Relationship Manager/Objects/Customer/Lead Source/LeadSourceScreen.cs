using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer.Lead_Source
{
	class LeadSourceScreen : ObjectScreenBase
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
		private System.Windows.Forms.ToolStripButton tsbRestore;
		private LeadSourceBoundary leadSourceControls;
		private System.Windows.Forms.ColumnHeader chRelationID;
		private System.Windows.Forms.ColumnHeader chSource;
		private System.Windows.Forms.ColumnHeader chRange;
		private System.Windows.Forms.ColumnHeader chAdder;
		private System.Windows.Forms.ColumnHeader chDepartment;
		private System.Windows.Forms.ToolStrip tsMain;
		private ToolStripSeparator tss_3;
		private ToolStripButton tsbProperties;

		private Customer clsMyCustomer;

		#endregion


		#region Properties

		public Customer MyCustomer
		{
			get { return clsMyCustomer; }
			set
			{
				bool HasChanged = (clsMyCustomer != value);

				clsMyCustomer = value;

				if (HasChanged)
					MySource = new LeadSource(); ;
				
				if (value != null)
					LoadList();
			}
		}

		public LeadSource MySource
		{
			get { return leadSourceControls.MySource; }
			set
			{
				if (leadSourceControls.MySource != null)
					leadSourceControls.MySource.Dispose();
				
				leadSourceControls.MySource = value;
			}
		}

		public override bool IsDirty
		{
			get { return leadSourceControls.IsDirty; }
		}

		#endregion


		#region Methods

		public new void Clear()
		{
			base.Clear();

			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			lvwList.SelectedItems.Clear();
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
			this.leadSourceControls = new rkcrm.Objects.Customer.Lead_Source.LeadSourceBoundary();
			this.chRelationID = new System.Windows.Forms.ColumnHeader();
			this.chSource = new System.Windows.Forms.ColumnHeader();
			this.chRange = new System.Windows.Forms.ColumnHeader();
			this.chAdder = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.tsbProperties = new System.Windows.Forms.ToolStripButton();
			this.tss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRelationID,
            this.chSource,
            this.chDepartment,
            this.chRange,
            this.chAdder});
			this.lvwList.Size = new System.Drawing.Size(600, 223);
			this.lvwList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwList_ItemSelectionChanged);
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.leadSourceControls);
			this.scMain.Panel1.Controls.Add(this.tsMain);
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
			// 
			// tsbAdd
			// 
			this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAdd.Image = global::rkcrm.Properties.Resources.New_Icon;
			this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Size = new System.Drawing.Size(32, 32);
			this.tsbAdd.Text = "Add a Lead Source";
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
			this.tsbRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// leadSourceControls
			// 
			this.leadSourceControls.BackColor = System.Drawing.Color.White;
			this.leadSourceControls.ChangeHistoryVisible = true;
			this.leadSourceControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leadSourceControls.IsBasic = false;
			this.leadSourceControls.Location = new System.Drawing.Point(0, 35);
			this.leadSourceControls.MySource = null;
			this.leadSourceControls.Name = "leadSourceControls";
			this.leadSourceControls.ShowDepartments = true;
			this.leadSourceControls.Size = new System.Drawing.Size(600, 206);
			this.leadSourceControls.TabIndex = 1;
			this.leadSourceControls.Title = "Search Lead Sources";
			this.leadSourceControls.TitleBarVisible = true;
			this.leadSourceControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.leadSourceControls_IsDirtyChanged);
			this.leadSourceControls.MySourceChanged += new System.EventHandler<System.EventArgs>(this.sourceBoundary_MySourceChanged);
			// 
			// chRelationID
			// 
			this.chRelationID.Width = 0;
			// 
			// chSource
			// 
			this.chSource.Text = "Lead Source";
			this.chSource.Width = 180;
			// 
			// chRange
			// 
			this.chRange.Text = "Active Range";
			this.chRange.Width = 150;
			// 
			// chAdder
			// 
			this.chAdder.Text = "Added By";
			this.chAdder.Width = 90;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 75;
			// 
			// tsbProperties
			// 
			this.tsbProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsbProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbProperties.Name = "tsbProperties";
			this.tsbProperties.Size = new System.Drawing.Size(32, 32);
			this.tsbProperties.Text = "Properties";
			this.tsbProperties.Click += new System.EventHandler(this.tsbProperties_Click);
			// 
			// tss_3
			// 
			this.tss_3.Name = "tss_3";
			this.tss_3.Size = new System.Drawing.Size(6, 35);
			// 
			// LeadSourceScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ListTitle = "Lead Sources";
			this.Name = "LeadSourceScreen";
			this.Controls.SetChildIndex(this.scMain, 0);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel1.PerformLayout();
			this.scMain.Panel2.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);

		}

		private void LoadList()
		{
			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			lvwList.Items.Clear();

			using (Lead_Source.LeadSourceController thecontroller = new Lead_Source.LeadSourceController())
			{
				ListViewItem newItem;
				DataRow previousRow = null;

				foreach (DataRow oRow in thecontroller.GetLeadSources(MyCustomer.ID).Rows)
				{
					newItem = new ListViewItem();
					newItem.Text = oRow["relation_id"].ToString();
					newItem.SubItems.Add(oRow["lead_source"].ToString());
					newItem.SubItems.Add(oRow["department"].ToString());

					if (Convert.ToBoolean(oRow["is_archived"]))
					{
						newItem.BackColor = System.Drawing.Color.LightSteelBlue;
						newItem.SubItems.Add(Convert.ToDateTime(oRow["activated"]).ToString("M/d/yy"));
					}
					else
					{
						if (previousRow != null && previousRow["department"].ToString() == oRow["department"].ToString() && !Convert.ToBoolean(previousRow["is_archived"]))
							newItem.SubItems.Add(Convert.ToDateTime(oRow["activated"]).ToString("M/d/yy") + " - " + Convert.ToDateTime(previousRow["activated"]).ToString("M/d/yy"));
						else
							newItem.SubItems.Add(Convert.ToDateTime(oRow["activated"]).ToString("M/d/yy") + " - Current");

						previousRow = oRow;
					}

					newItem.SubItems.Add(oRow["adder"].ToString());

					lvwList.Items.Add(newItem);

				}
			}
		}

		public void SetAddingMode()
		{

			tsbAdd.Enabled = false;
			tsbCancel.Enabled = true;
			tsbDelete.Enabled = false;
			tsbRestore.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbProperties.Enabled = false;
			
			Clear();

			IsDisposable = true;
		}

		public void SetEditingMode()
		{
			tsbAdd.Enabled = !MySource.IsArchived;
			tsbCancel.Enabled = true;
			tsbDelete.Enabled = (MySource.ID > 0);
			tsbRestore.Enabled = tsbDelete.Enabled;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbProperties.Enabled = true;

			tsbRestore.Visible = MySource.IsArchived;
			tsbDelete.Visible = !MySource.IsArchived;

			IsDisposable = false;
		}

		public void SetSearchingMode()
		{
			tsbAdd.Enabled = true;
			tsbCancel.Enabled = true;
			tsbDelete.Enabled = false;
			tsbRestore.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbProperties.Enabled = false;

			Clear();

			if(MyCustomer != null)
				LoadList();
		}

		public override bool Save()
		{
			return leadSourceControls.Save();
		}

		#endregion


		#region Event Handlers

		private void sourceBoundary_MySourceChanged(object sender, EventArgs e)
		{
			if (MySource == null)
				SetSearchingMode();
			else
				if (MySource.ID > 0)
					SetEditingMode();
				else
				{
					if (MySource.CustomerID != MyCustomer.ID)
						MySource.CustomerID = MyCustomer.ID;

					SetAddingMode();
				}
		}

		private void leadSourceControls_IsDirtyChanged(object sender, EventArgs e)
		{
			tsbSave.Enabled = this.IsDirty;
			tsbSaveClose.Enabled = this.IsDirty;
			tsbSaveNew.Enabled = this.IsDirty;
		}

		private void lvwList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
			{
				using (LeadSourceController theController = new LeadSourceController())
				{
					this.MySource = theController.GetLeadSource(Convert.ToInt32(e.Item.Text));
				}
			}
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MySource = MySource;

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
					MySource = new LeadSource();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyCustomer != null)
						LoadList();
				}
			}
			else
				MySource = new LeadSource();
		}

		private void tsbSaveNew_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MySource = new LeadSource();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyCustomer != null)
						LoadList();
				}
			}
			else
				MySource = new LeadSource();
		}

		private void tsbAdd_Click(object sender, EventArgs e)
		{
			if (IsDirty)
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
							MySource = new LeadSource();
						break;
					case DialogResult.Cancel:
						break;
					default:
						MySource = new LeadSource();
						break;
				}
			else
				MySource = new LeadSource();
		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
							MySource = new LeadSource();
						break;
					case DialogResult.Cancel:
						break;
					default:
						MySource = new LeadSource();
						break;
				}
			}
			else
				MySource = new LeadSource();
		}

		private void tsbDelete_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						MySource.IsArchived = true;
						if (Save())
							MySource = new LeadSource();
						break;
					case DialogResult.Cancel:
						break;
					default:
						MySource.IsArchived = true;
						if (Save())
							MySource = new LeadSource();
						break;
				}
			}
			else
			{
				MySource.IsArchived = true;
				if (Save())
					MySource = new LeadSource();
			}
		}

		private void tsbRestore_Click(object sender, EventArgs e)
		{
			MySource.IsArchived = false;
			if (Save())
				MySource = MySource;

			LoadList();
		}

		private void tsbProperties_Click(object sender, EventArgs e)
		{
			if (MySource != null && MySource.ID > 0)
			{
				Objects.PropertiesWindow oForm = new rkcrm.Objects.PropertiesWindow();
				oForm.SelectedObject = MySource;
				oForm.Text = "Lead Source Properties";
				oForm.Show();
			}
		}

		#endregion


		#region Constructor

		public LeadSourceScreen()
			: base()
		{
			InitializeComponent();
		}

		#endregion

	}
}
