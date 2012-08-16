using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Navigation;

namespace rkcrm.Objects.Quote
{
	class QuoteScreen : ObjectScreenBase
	{


		#region Variables

		private ToolStrip tsMain;
		private ToolStripButton tsbSave;
		private ToolStripButton tsbSaveClose;
		private ToolStripButton tsbSaveNew;
		private ToolStripSeparator tss_0;
		private ToolStripButton tsbAddQuote;
		private ToolStripSeparator tss_1;
		private ToolStripButton tsbCancel;
		private ToolStripSeparator tss_2;
		private ToolStripButton tsbDelete;
		private ToolStripButton tsbRestore;
		private ToolStripSeparator tss_3;
		private ToolStripButton tsbReopen;
		private ToolStripButton tsbSell;
		private ColumnHeader chID;
		private ColumnHeader chDepartment;
		private QuoteBoundary quoteControls;
		private ColumnHeader chProjectID;
		private ColumnHeader chRep;
		private ColumnHeader chNumber;
		private ColumnHeader chAmount;
		private ColumnHeader chProb;
		private ColumnHeader chStatus;
		private ToolStripButton tsbLose;
		private ToolStripMenuItem tsmReopen;
		private ToolStripMenuItem tsmSell;
		private ToolStripMenuItem tsmLose;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmDelete;
		private ToolStripMenuItem tsmRestore;
		private ToolStripSeparator mss_2;
		private ToolStripMenuItem tsmCancel;
		private ToolStripSeparator tss_4;
		private ToolStripButton tsbProperties;
		private ToolStripSeparator mss_3;
		private ToolStripMenuItem tsmProperties;

		private const int FOLLOW_UP_ON_QUOTES = 5;

		#endregion


		#region Properties

		public Project.Project MyProject
		{
			get
			{
				NavigationScreen navigation = GetNavigationScreen();
				return navigation.btnCustomer.MyProject;
			}
			set
			{
				NavigationScreen navigation = GetNavigationScreen();

				if (navigation.btnCustomer.MyProject != value)
					MyQuote = new Quote();

				navigation.btnCustomer.MyProject = value;

				if (value != null)
				{
					LoadList();
					this.ListTitle = "Quote List - " + value.GetCustomer().Name + " - " + value.Name;
				}
				else
					this.ListTitle = "Quote List";
			}
		}

		public Quote MyQuote
		{
			get { return quoteControls.MyQuote; }
			set
			{
				if (value != null && value.ProjectID != MyProject.ID)
					value.ProjectID = MyProject.ID;

				quoteControls.MyQuote = value;
			}
		}

		public override bool IsDirty
		{
			get
			{
				return quoteControls.IsDirty;
			}
		}

		#endregion		


		#region Methods

		private void InitializeComponent()
		{
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.tsbSaveClose = new System.Windows.Forms.ToolStripButton();
			this.tsbSaveNew = new System.Windows.Forms.ToolStripButton();
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbAddQuote = new System.Windows.Forms.ToolStripButton();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCancel = new System.Windows.Forms.ToolStripButton();
			this.tss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.tsbRestore = new System.Windows.Forms.ToolStripButton();
			this.tss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbReopen = new System.Windows.Forms.ToolStripButton();
			this.tsbSell = new System.Windows.Forms.ToolStripButton();
			this.tsbLose = new System.Windows.Forms.ToolStripButton();
			this.quoteControls = new rkcrm.Objects.Quote.QuoteBoundary();
			this.chID = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chRep = new System.Windows.Forms.ColumnHeader();
			this.chNumber = new System.Windows.Forms.ColumnHeader();
			this.chAmount = new System.Windows.Forms.ColumnHeader();
			this.chProb = new System.Windows.Forms.ColumnHeader();
			this.chStatus = new System.Windows.Forms.ColumnHeader();
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.tsmReopen = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmSell = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmLose = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmCancel = new System.Windows.Forms.ToolStripMenuItem();
			this.tss_4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbProperties = new System.Windows.Forms.ToolStripButton();
			this.mss_3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.chID,
            this.chProjectID,
            this.chDepartment,
            this.chRep,
            this.chNumber,
            this.chAmount,
            this.chProb,
            this.chStatus});
			this.lvwList.Size = new System.Drawing.Size(600, 181);
			this.lvwList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwList_ItemSelectionChanged);
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.quoteControls);
			this.scMain.Panel1.Controls.Add(this.tsMain);
			this.scMain.SplitterDistance = 285;
			// 
			// tsMain
			// 
			this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbSaveClose,
            this.tsbSaveNew,
            this.tss_0,
            this.tsbAddQuote,
            this.tss_1,
            this.tsbCancel,
            this.tss_2,
            this.tsbDelete,
            this.tsbRestore,
            this.tss_3,
            this.tsbReopen,
            this.tsbSell,
            this.tsbLose,
            this.tss_4,
            this.tsbProperties});
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
			this.tsbSaveClose.Text = "Save && Close";
			this.tsbSaveClose.ToolTipText = "Save & Close";
			this.tsbSaveClose.Click += new System.EventHandler(this.tsbSaveClose_Click);
			// 
			// tsbSaveNew
			// 
			this.tsbSaveNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSaveNew.Image = global::rkcrm.Properties.Resources.Save_New;
			this.tsbSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSaveNew.Name = "tsbSaveNew";
			this.tsbSaveNew.Size = new System.Drawing.Size(32, 32);
			this.tsbSaveNew.Text = "Save && Add Another Quote";
			this.tsbSaveNew.ToolTipText = "Save & Add Another Quote";
			this.tsbSaveNew.Visible = false;
			this.tsbSaveNew.Click += new System.EventHandler(this.tsbSaveNew_Click);
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(6, 35);
			this.tss_0.Visible = false;
			// 
			// tsbAddQuote
			// 
			this.tsbAddQuote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddQuote.Image = global::rkcrm.Properties.Resources.New_Quote_icon;
			this.tsbAddQuote.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddQuote.Name = "tsbAddQuote";
			this.tsbAddQuote.Size = new System.Drawing.Size(32, 32);
			this.tsbAddQuote.Text = "Add a Quote";
			this.tsbAddQuote.Visible = false;
			this.tsbAddQuote.Click += new System.EventHandler(this.tsbAddQuote_Click);
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
			this.tsbDelete.Text = "Delete";
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
			this.tsbRestore.Text = "Restore";
			this.tsbRestore.EnabledChanged += new System.EventHandler(this.tsbRestore_EnabledChanged);
			this.tsbRestore.VisibleChanged += new System.EventHandler(this.tsbRestore_VisibleChanged);
			this.tsbRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// tss_3
			// 
			this.tss_3.Name = "tss_3";
			this.tss_3.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbReopen
			// 
			this.tsbReopen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbReopen.Image = global::rkcrm.Properties.Resources.Reopen28x28;
			this.tsbReopen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbReopen.Name = "tsbReopen";
			this.tsbReopen.Size = new System.Drawing.Size(32, 32);
			this.tsbReopen.Text = "Reopen";
			this.tsbReopen.EnabledChanged += new System.EventHandler(this.tsbReopen_EnabledChanged);
			this.tsbReopen.VisibleChanged += new System.EventHandler(this.tsbReopen_VisibleChanged);
			this.tsbReopen.Click += new System.EventHandler(this.tsbReopen_Click);
			// 
			// tsbSell
			// 
			this.tsbSell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSell.Image = global::rkcrm.Properties.Resources.Sold_Icon;
			this.tsbSell.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSell.Name = "tsbSell";
			this.tsbSell.Size = new System.Drawing.Size(32, 32);
			this.tsbSell.Text = "Sell";
			this.tsbSell.EnabledChanged += new System.EventHandler(this.tsbSell_EnabledChanged);
			this.tsbSell.VisibleChanged += new System.EventHandler(this.tsbSell_VisibleChanged);
			this.tsbSell.Click += new System.EventHandler(this.tsbSell_Click);
			// 
			// tsbLose
			// 
			this.tsbLose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbLose.Image = global::rkcrm.Properties.Resources.Lost_Icon;
			this.tsbLose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbLose.Name = "tsbLose";
			this.tsbLose.Size = new System.Drawing.Size(32, 32);
			this.tsbLose.Text = "Lose";
			this.tsbLose.EnabledChanged += new System.EventHandler(this.tsbLose_EnabledChanged);
			this.tsbLose.VisibleChanged += new System.EventHandler(this.tsbLose_VisibleChanged);
			this.tsbLose.Click += new System.EventHandler(this.tsbLose_Click);
			// 
			// quoteControls
			// 
			this.quoteControls.AutoScroll = true;
			this.quoteControls.AutoScrollMinSize = new System.Drawing.Size(0, 210);
			this.quoteControls.BackColor = System.Drawing.Color.White;
			this.quoteControls.ChangeHistoryVisible = true;
			this.quoteControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.quoteControls.Location = new System.Drawing.Point(0, 35);
			this.quoteControls.MyQuote = null;
			this.quoteControls.Name = "quoteControls";
			this.quoteControls.Size = new System.Drawing.Size(600, 248);
			this.quoteControls.TabIndex = 2;
			this.quoteControls.Title = "Search Quotes";
			this.quoteControls.TitleBarVisible = true;
			this.quoteControls.MyQuoteChanged += new System.EventHandler<System.EventArgs>(this.quoteControls_MyQuoteChanged);
			this.quoteControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.quoteControls_IsDirtyChanged);
			// 
			// chID
			// 
			this.chID.Width = 0;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 80;
			// 
			// chRep
			// 
			this.chRep.Text = "Sales Rep";
			this.chRep.Width = 90;
			// 
			// chNumber
			// 
			this.chNumber.Text = "Quote Number";
			this.chNumber.Width = 150;
			// 
			// chAmount
			// 
			this.chAmount.Text = "Amount";
			this.chAmount.Width = 100;
			// 
			// chProb
			// 
			this.chProb.Text = "%";
			this.chProb.Width = 50;
			// 
			// chStatus
			// 
			this.chStatus.Text = "Status";
			this.chStatus.Width = 100;
			// 
			// chProjectID
			// 
			this.chProjectID.Width = 0;
			// 
			// tsmReopen
			// 
			this.tsmReopen.Image = global::rkcrm.Properties.Resources.Reopen28x28;
			this.tsmReopen.Name = "tsmReopen";
			this.tsmReopen.Size = new System.Drawing.Size(152, 22);
			this.tsmReopen.Text = "Reopen";
			this.tsmReopen.Click += new System.EventHandler(this.tsbReopen_Click);
			// 
			// tsmSell
			// 
			this.tsmSell.Image = global::rkcrm.Properties.Resources.Sold_Icon;
			this.tsmSell.Name = "tsmSell";
			this.tsmSell.Size = new System.Drawing.Size(152, 22);
			this.tsmSell.Text = "Sell";
			this.tsmSell.Click += new System.EventHandler(this.tsbSell_Click);
			// 
			// tsmLose
			// 
			this.tsmLose.Image = global::rkcrm.Properties.Resources.Lost_Icon;
			this.tsmLose.Name = "tsmLose";
			this.tsmLose.Size = new System.Drawing.Size(152, 22);
			this.tsmLose.Text = "Lose";
			this.tsmLose.Click += new System.EventHandler(this.tsbLose_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmDelete
			// 
			this.tsmDelete.Image = global::rkcrm.Properties.Resources.Delete_icon;
			this.tsmDelete.Name = "tsmDelete";
			this.tsmDelete.Size = new System.Drawing.Size(152, 22);
			this.tsmDelete.Text = "Delete Quote";
			this.tsmDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// tsmRestore
			// 
			this.tsmRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsmRestore.Name = "tsmRestore";
			this.tsmRestore.Size = new System.Drawing.Size(152, 22);
			this.tsmRestore.Text = "Restore Quote";
			this.tsmRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// mss_2
			// 
			this.mss_2.Name = "mss_2";
			this.mss_2.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmCancel
			// 
			this.tsmCancel.Image = global::rkcrm.Properties.Resources.Cancel;
			this.tsmCancel.Name = "tsmCancel";
			this.tsmCancel.Size = new System.Drawing.Size(152, 22);
			this.tsmCancel.Text = "Cancel";
			this.tsmCancel.Click += new System.EventHandler(this.tsbCancel_Click);
			// 
			// tss_4
			// 
			this.tss_4.Name = "tss_4";
			this.tss_4.Size = new System.Drawing.Size(6, 35);
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
			// toolStripSeparator1
			// 
			this.mss_3.Name = "toolStripSeparator1";
			this.mss_3.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmProperties
			// 
			this.tsmProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsmProperties.Name = "tsmProperties";
			this.tsmProperties.Size = new System.Drawing.Size(152, 22);
			this.tsmProperties.Text = "Properties";
			this.tsmProperties.Click += new System.EventHandler(this.tsbProperties_Click);
			// 
			// QuoteScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ListTitle = "Quote List";
			this.Name = "QuoteScreen";
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
				this.tsmReopen,
				this.tsmSell,
				this.tsmLose,
				this.mss_1,
				this.tsmDelete,
				this.tsmRestore,
				this.mss_2,
				this.tsmCancel,
				this.mss_3,
				this.tsmProperties});
		}

		private void LoadList()
		{
			lvwList.Items.Clear();

			if (MyProject != null)
			{
				using (QuoteController theController = new QuoteController())
				{
					ListViewItem newItem;

					foreach(DataRow oRow in theController.GetQuotes(MyProject.ID, thisUser.Role.ID == 1).Rows)
					{
						newItem = new ListViewItem();
						newItem.Text = oRow["quote_id"].ToString();
						newItem.SubItems.Add(oRow["project_id"].ToString());
						newItem.SubItems.Add(oRow["department"].ToString());
						newItem.SubItems.Add(oRow["rep"].ToString());
						newItem.SubItems.Add(oRow["name"].ToString());
						newItem.SubItems.Add(Convert.ToDecimal(oRow["amount"]).ToString("C"));
						newItem.SubItems.Add(FormatPercent(oRow["probability"].ToString()));
						newItem.SubItems.Add(oRow["status"].ToString());

						if (Convert.ToBoolean(oRow["is_archived"]))
							newItem.BackColor = System.Drawing.Color.LightSteelBlue;

						lvwList.Items.Add(newItem);
					}
				}
			}
		}

		private void GetStatusButtonAvailability()
		{
			Project.Project.ProjectStatus myStatus;
			bool IsProjectArchived = MyProject.IsArchived;

			tsbLose.Enabled = false;
			tsbSell.Enabled = false;
			tsbReopen.Enabled = false;

			using (Project.ProjectController theController = new Project.ProjectController())
			{
				myStatus = theController.GetStatus(MyQuote.ProjectID, MyQuote.DepartmentID);

				if (myStatus == rkcrm.Objects.Project.Project.ProjectStatus.Outstanding)
				{
					tsbLose.Enabled = !MyQuote.IsArchived && !IsProjectArchived;
					tsbSell.Enabled = !MyQuote.IsArchived && !IsProjectArchived;
				}
				else
					tsbReopen.Enabled = !MyQuote.IsArchived && !IsProjectArchived;
			}
		}

		private void SetSearchingMode()
		{
			tsbAddQuote.Enabled = true;
			tsbDelete.Enabled = false;
			tsbDelete.Visible = true;
			tsbLose.Enabled = false;
			tsbReopen.Enabled = false;
			tsbRestore.Enabled = false;
			tsbRestore.Visible = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbSell.Enabled = false;
			tsbProperties.Enabled = false;

			tsbSaveNew.Visible = false;
			tsbDelete.Visible = true;
			tsbRestore.Visible = false;

			Clear();

			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			if (lvwList.SelectedItems.Count > 0)
				lvwList.SelectedItems[0].Selected = false;

			LoadList();
		}

		private void SetEditingMode()
		{
			bool IsProjectArchived = MyProject.IsArchived;
			bool IsOutstanding = (quoteControls.MyProjectDepartment.Status == rkcrm.Objects.Project.Project.ProjectStatus.Outstanding);

			tsbAddQuote.Enabled = !IsProjectArchived;
			tsbDelete.Visible = !MyQuote.IsArchived;
			tsbDelete.Enabled = !IsProjectArchived && IsOutstanding;
			tsbRestore.Enabled = !IsProjectArchived && IsOutstanding;
			tsbRestore.Visible = MyQuote.IsArchived;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbProperties.Enabled = true;

			Clear();

			IsDisposable = false;

			GetStatusButtonAvailability();
		}

		private void SetAddingMode()
		{
			tsbAddQuote.Enabled = false;
			tsbDelete.Enabled = false;
			tsbDelete.Visible = true;
			tsbLose.Enabled = false;
			tsbReopen.Enabled = false;
			tsbRestore.Visible = false;
			tsbRestore.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbSell.Enabled = false;
			tsbProperties.Enabled = false;

			Clear();

			IsDisposable = true;

			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			if (lvwList.SelectedItems.Count > 0)
				lvwList.SelectedItems[0].Selected = false;

			LoadList();
		}

		private bool IsNoteNeeded()
		{
			int noteCount;
			Project.Project.ProjectStatus status;

			using (Note.NoteController theController = new rkcrm.Objects.Note.NoteController())
			{
				noteCount = theController.GetOpenNoteCount(MyQuote.ProjectID, Convert.ToInt32(quoteControls.cboDepartment.SelectedValue));
			}

			using (Project.ProjectController theController = new rkcrm.Objects.Project.ProjectController())
			{
				status = theController.GetStatus(MyQuote.ProjectID, Convert.ToInt32(quoteControls.cboDepartment.SelectedValue));
			}

			if ((status == Project.Project.ProjectStatus.None || status == Project.Project.ProjectStatus.Outstanding) && noteCount == 0)
				return true;
			else
				return false;
		}

		private bool IsNoteRequirementFulfilled()
		{
			if (IsNoteNeeded())
			{
				// Instantiate new note form
				Note.AddNote oForm = new rkcrm.Objects.Note.AddNote();
				Note.Note newNote = new rkcrm.Objects.Note.Note();
				newNote.ProjectID = MyQuote.ProjectID;
				oForm.MyNote = newNote;
				oForm.SalesSupportID = Convert.ToInt32(quoteControls.cboSupport.SelectedValue);
				oForm.SalesRepID = Convert.ToInt32(quoteControls.cboSalesRep.SelectedValue);
				oForm.DepartmentID = Convert.ToInt32(quoteControls.cboDepartment.SelectedValue);
				oForm.MethodID = Convert.ToInt32(quoteControls.cboMethod.SelectedValue);
				oForm.PurposeID = FOLLOW_UP_ON_QUOTES;
				oForm.ContactID = Convert.ToInt32(quoteControls.cboContact.SelectedValue);
				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					using (Note.NoteController theController = new Note.NoteController())
					{
						oForm.MyNote = theController.InsertNote(oForm.MyNote);
					}
				}

				return (oForm.MyNote.ID > 0);
			}
			else
				return true;
		}

		public override bool Save()
		{
			bool succeeded;

			if (quoteControls.CommitChanges())
			{
				using (Project.Department.DepartmentController theController = new rkcrm.Objects.Project.Department.DepartmentController())
				{
					succeeded = theController.InsertDepartment(quoteControls.MyProjectDepartment);
				}

				if (succeeded)
				{
					using (QuoteController quoteController = new QuoteController())
					{
						if (IsNoteRequirementFulfilled())
						{
							if (MyQuote.ID > 0)
								return quoteController.UpdateQuote(MyQuote);
							else
							{
								MyQuote = quoteController.InsertQuote(MyQuote);

								return MyQuote.ID > 0;
							}
						}
						else
						{
							MessageBox.Show("To save this quote you must add a note.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return false;
						}
					}
				}
				else 
					return false;
			}
			else
				return false;
		}

		public override void RefreshData()
		{
			MyQuote = MyQuote;
		}

		private void AddGenericNote()
		{
			Note.Note newNote = new Note.Note();
			newNote.ProjectID = MyQuote.ProjectID;
			newNote.DepartmentID = MyQuote.DepartmentID;
			newNote.ContactID = MyQuote.ContactID;
			newNote.MethodID = MyQuote.MethodID;
			newNote.NextFollowUp = DateTime.Today;
			newNote.PurposeID = 5; //Follow up on Quotes
			newNote.SalesRepID = MyQuote.SalesRepID;
			newNote.SalesSupportID = MyQuote.SalesSupportID;

			using (Note.NoteController theNoteController = new Note.NoteController())
			{
				newNote = theNoteController.InsertNote(newNote);
			}

			if (newNote.ID > 0)
				RefreshReminders();
		}

		#endregion


		#region Event Handlers

		private void quoteControls_MyQuoteChanged(object sender, EventArgs e)
		{
			if (MyQuote == null)
				SetSearchingMode();
			else
				if (MyQuote.ID > 0)
					SetEditingMode();
				else
					SetAddingMode();
		}

		private void quoteControls_IsDirtyChanged(object sender, EventArgs e)
		{
			bool IsProjectArchived = MyProject.IsArchived;
			bool IsOutstanding = (quoteControls.MyProjectDepartment.Status == rkcrm.Objects.Project.Project.ProjectStatus.Outstanding);

			tsbSave.Enabled = !IsProjectArchived && IsOutstanding && this.IsDirty;
			tsbSaveClose.Enabled = !IsProjectArchived && IsOutstanding && this.IsDirty;
			tsbSaveNew.Enabled = !IsProjectArchived && IsOutstanding && this.IsDirty;
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyQuote = MyQuote;

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyProject != null)
						LoadList();

					RefreshReminders();
				}
			}
		}

		private void tsbSaveClose_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyQuote = new Quote();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyProject != null)
						LoadList();

					RefreshReminders();
				}
			}
			else
				MyQuote = new Quote();
		}

		private void tsbSaveNew_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyQuote = new Quote();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyProject != null)
						LoadList();

					RefreshReminders();
				}
			}
			else
				MyQuote = new Quote();
		}

		private void tsbAddQuote_Click(object sender, EventArgs e)
		{
			if (IsDirty)
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
						{
							MyQuote = new Quote();

							RefreshReminders();
						}
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyQuote = new Quote();
						break;
				}
			else
				MyQuote = new Quote();
		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
						{
							MyQuote = new Quote();

							RefreshReminders();
						}
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyQuote = new Quote();
						break;
				}
			}
			else
				MyQuote = new Quote();
		}

		private void tsbDelete_Click(object sender, EventArgs e)
		{
			MyQuote.IsArchived = true;
			if (Save())
			{
				MyQuote = new Quote();

				RefreshReminders();
			}
		}

		private void tsbRestore_Click(object sender, EventArgs e)
		{
			bool succeeded = false;

			if (IsNoteNeeded())
				AddGenericNote();

			MyQuote.IsArchived = false;

			using (QuoteController theController = new QuoteController())
			{
				succeeded = theController.UpdateQuote(MyQuote);
			}

			if (succeeded)
			{
				MyQuote = MyQuote;
				LoadList();

				RefreshReminders();
			}

		}

		private void tsbReopen_Click(object sender, EventArgs e)
		{
			Administration.Department.DepartmentSelect oForm = new rkcrm.Administration.Department.DepartmentSelect();

			using (Project.Department.DepartmentController theController = new rkcrm.Objects.Project.Department.DepartmentController())
			{
				Project.Department.Department theProjectDepartment;

				theProjectDepartment = theController.GetDepartmentWithLastestScope(MyQuote.ProjectID, MyQuote.DepartmentID);

				if (theProjectDepartment.Status == Project.Project.ProjectStatus.Sold)
					theController.ClearSoldMarkers(theProjectDepartment);
				else
					theController.DeleteLostProjectReports(theProjectDepartment);

				theController.UpdateStatus(theProjectDepartment, Project.Project.ProjectStatus.Outstanding);
			}

			if (IsNoteNeeded())
				AddGenericNote();

			GetStatusButtonAvailability();
			
			using (QuoteController theController = new QuoteController())
			{
				MyQuote = theController.GetQuote(MyQuote.ID);
			}
			
			LoadList();
		}

		private void tsbSell_Click(object sender, EventArgs e)
		{
			bool saveSuccessful;

			if (IsDirty)
				saveSuccessful = Save();
			else
				saveSuccessful = true;

			if (saveSuccessful)
			{
				using (Project.Department.DepartmentController theController = new rkcrm.Objects.Project.Department.DepartmentController())
				{
					theController.UpdateStatus(MyProject.ID, MyQuote.DepartmentID, Project.Project.ProjectStatus.Sold);
				}

				using (QuoteController otherController = new QuoteController())
				{
					if (otherController.MarkAsSold(MyQuote.ID))
						MyQuote = otherController.GetQuote(MyQuote.ID);
				}

				if (MessageBox.Show("Would you like to follow up with all remaining notes?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					using (Note.NoteController theNoteCrontroller = new Note.NoteController())
					{
						theNoteCrontroller.FollowUpOnAll(MyProject.ID, MyQuote.DepartmentID);
					}
					RefreshReminders();
				}

				GetStatusButtonAvailability();

				LoadList();
			}
		}

		private void tsbLose_Click(object sender, EventArgs e)
		{
			bool saveSuccessful;

			if (IsDirty)
				saveSuccessful = Save();
			else
				saveSuccessful = true;

			if (saveSuccessful)
			{
				Project.Lost_Report.LostProjectForm oForm = new rkcrm.Objects.Project.Lost_Report.LostProjectForm(MyProject.ID);

				oForm.lostProjectControls.cboDepartment.SelectedValue = MyQuote.DepartmentID;
				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					using (Project.Department.DepartmentController theController = new rkcrm.Objects.Project.Department.DepartmentController())
					{
						theController.UpdateStatus(MyProject.ID, oForm.SelectedDepartmentID, Project.Project.ProjectStatus.Lost);
					}

					if (MessageBox.Show("Would you like to follow up with all remaining notes?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						using (Note.NoteController theNoteCrontroller = new Note.NoteController())
						{
							theNoteCrontroller.FollowUpOnAll(MyProject.ID, MyQuote.DepartmentID);
						}
						RefreshReminders();
					}

					GetStatusButtonAvailability();
					using (QuoteController theController = new QuoteController())
					{
						MyQuote = theController.GetQuote(MyQuote.ID);
					}
				}

				LoadList();
			}
		}

		private void lvwList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
			{
				using (QuoteController theController = new QuoteController())
				{
					MyQuote = theController.GetQuote(Convert.ToInt32(e.Item.Text));
				}
			}
		}

		private void tsbProperties_Click(object sender, EventArgs e)
		{
			if (MyQuote != null && MyQuote.ID > 0)
			{
				Objects.PropertiesWindow oForm = new rkcrm.Objects.PropertiesWindow();
				oForm.SelectedObject = MyQuote;
				oForm.Text = "Quote Properties";
				oForm.Show();
			}
		}

		#endregion

		
		#region Constructor

		public QuoteScreen()
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

		private void tsbReopen_EnabledChanged(object sender, EventArgs e)
		{
			tsmReopen.Enabled = tsbReopen.Enabled;
		}

		private void tsbReopen_VisibleChanged(object sender, EventArgs e)
		{
			tsmReopen.Visible = tsbReopen.Visible;
		}

		private void tsbSell_EnabledChanged(object sender, EventArgs e)
		{
			tsmSell.Enabled = tsbSell.Enabled;
		}

		private void tsbSell_VisibleChanged(object sender, EventArgs e)
		{
			tsmSell.Visible = tsbSell.Visible;
		}

		private void tsbLose_EnabledChanged(object sender, EventArgs e)
		{
			tsmLose.Enabled = tsbLose.Enabled;
		}

		private void tsbLose_VisibleChanged(object sender, EventArgs e)
		{
			tsmLose.Visible = tsbLose.Visible;
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
