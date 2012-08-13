using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Navigation;
using rkcrm.Objects.Note;
using rkcrm.Objects.Quote;

namespace rkcrm.Objects.Project
{
	class ProjectScreen : ObjectScreenBase
	{

        #region Variables

        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbSaveClose;
        private System.Windows.Forms.ToolStripButton tsbSaveNew;
        private System.Windows.Forms.ToolStripSeparator tss_0;
        private System.Windows.Forms.ToolStripButton tsbAddProject;
        private System.Windows.Forms.ToolStripButton tsbAddNote;
        private System.Windows.Forms.ToolStripButton tsbAddQuote;
        private System.Windows.Forms.ToolStripSeparator tss_1;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator tss_2;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbRestore;
        private System.Windows.Forms.ToolStripSeparator tss_3;
        private System.Windows.Forms.ToolStripButton tsbLink;
        private System.Windows.Forms.ToolStripButton tsbRemoveLink;
        private System.Windows.Forms.ToolStripSeparator tss_4;
        private System.Windows.Forms.ToolStripButton tsbReopen;
        private System.Windows.Forms.ToolStripButton tsbSell;
        private System.Windows.Forms.ToolStripButton tsbLose;
        private System.Windows.Forms.ToolStripSeparator tss_5;
        private System.Windows.Forms.ToolStripButton tsbCrossLead;
        private System.Windows.Forms.ColumnHeader chProjectID;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chAddress;
        private System.Windows.Forms.ColumnHeader chCity;
        private System.Windows.Forms.ColumnHeader chType;
        private ProjectBoundary projectControls;
        private System.Windows.Forms.ToolStrip tsMain;

        private const int OUTSTANDING = 1;
        private const int SOLD = 2;
		private ToolStripMenuItem tsmAddNote;
		private ToolStripMenuItem tsmAddQuote;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmLink;
		private ToolStripMenuItem tsmRemoveLink;
		private ToolStripSeparator mss_2;
		private ToolStripMenuItem tsmReopen;
		private ToolStripMenuItem tsmSell;
		private ToolStripMenuItem tsmLose;
		private ToolStripSeparator mss_3;
		private ToolStripMenuItem tsmCrossLead;
		private ToolStripSeparator mss_4;
		private ToolStripMenuItem tsmDelete;
		private ToolStripMenuItem tsmRestore;
		private ToolStripSeparator mss_5;
		private ToolStripMenuItem tsmCancel;
        private const int LOST = 3;

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
					MyProject = new Project();

				if (value != null && value.ID > 0)
				{
					this.ListTitle = "Project List - " + value.Name;
					LoadList();
				}
				else
					this.ListTitle = "Project List";
			}
		}

		public Project MyProject
		{
			get { return projectControls.MyProject; }
			set 
			{
				if (projectControls.MyProject != null)
					projectControls.MyProject.Dispose();

				projectControls.MyProject = value;
			}
		}

		public override bool IsDirty
		{
			get
			{
				return projectControls.IsDirty;
			}
		}

		#endregion


		#region Methods

		public new void Clear()
		{
			base.Clear();
		}

		private void InitializeComponent()
		{
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.tsbSaveClose = new System.Windows.Forms.ToolStripButton();
			this.tsbSaveNew = new System.Windows.Forms.ToolStripButton();
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbAddProject = new System.Windows.Forms.ToolStripButton();
			this.tsbAddNote = new System.Windows.Forms.ToolStripButton();
			this.tsbAddQuote = new System.Windows.Forms.ToolStripButton();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCancel = new System.Windows.Forms.ToolStripButton();
			this.tss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.tsbRestore = new System.Windows.Forms.ToolStripButton();
			this.tss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbLink = new System.Windows.Forms.ToolStripButton();
			this.tsbRemoveLink = new System.Windows.Forms.ToolStripButton();
			this.tss_4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbReopen = new System.Windows.Forms.ToolStripButton();
			this.tsbSell = new System.Windows.Forms.ToolStripButton();
			this.tsbLose = new System.Windows.Forms.ToolStripButton();
			this.tss_5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCrossLead = new System.Windows.Forms.ToolStripButton();
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chAddress = new System.Windows.Forms.ColumnHeader();
			this.chCity = new System.Windows.Forms.ColumnHeader();
			this.chType = new System.Windows.Forms.ColumnHeader();
			this.projectControls = new rkcrm.Objects.Project.ProjectBoundary();
			this.tsmAddNote = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmAddQuote = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmLink = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmRemoveLink = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmReopen = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmSell = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmLose = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmCrossLead = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_5 = new System.Windows.Forms.ToolStripSeparator();
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
            this.chProjectID,
            this.chName,
            this.chAddress,
            this.chCity,
            this.chType});
			this.lvwList.Size = new System.Drawing.Size(600, 223);
			this.lvwList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwList_ItemSelectionChanged);
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.projectControls);
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
            this.tsbAddProject,
            this.tsbAddNote,
            this.tsbAddQuote,
            this.tss_1,
            this.tsbCancel,
            this.tss_2,
            this.tsbDelete,
            this.tsbRestore,
            this.tss_3,
            this.tsbLink,
            this.tsbRemoveLink,
            this.tss_4,
            this.tsbReopen,
            this.tsbSell,
            this.tsbLose,
            this.tss_5,
            this.tsbCrossLead});
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
			this.tsbSaveNew.Text = "Save && Add Another Project";
			this.tsbSaveNew.ToolTipText = "Save & Add Another Project";
			this.tsbSaveNew.Visible = false;
			this.tsbSaveNew.Click += new System.EventHandler(this.tsbSaveNew_Click);
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbAddProject
			// 
			this.tsbAddProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddProject.Image = global::rkcrm.Properties.Resources.New_Project28x28;
			this.tsbAddProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddProject.Name = "tsbAddProject";
			this.tsbAddProject.Size = new System.Drawing.Size(32, 32);
			this.tsbAddProject.Text = "Add a Project";
			this.tsbAddProject.Visible = false;
			this.tsbAddProject.Click += new System.EventHandler(this.tsbAddProject_Click);
			// 
			// tsbAddNote
			// 
			this.tsbAddNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddNote.Image = global::rkcrm.Properties.Resources.New_Note_Icon;
			this.tsbAddNote.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddNote.Name = "tsbAddNote";
			this.tsbAddNote.Size = new System.Drawing.Size(32, 32);
			this.tsbAddNote.Text = "Add a Note";
			this.tsbAddNote.EnabledChanged += new System.EventHandler(this.tsbAddNote_EnabledChanged);
			this.tsbAddNote.VisibleChanged += new System.EventHandler(this.tsbAddNote_VisibleChanged);
			this.tsbAddNote.Click += new System.EventHandler(this.tsbAddNote_Click);
			// 
			// tsbAddQuote
			// 
			this.tsbAddQuote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddQuote.Image = global::rkcrm.Properties.Resources.New_Quote_icon;
			this.tsbAddQuote.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddQuote.Name = "tsbAddQuote";
			this.tsbAddQuote.Size = new System.Drawing.Size(32, 32);
			this.tsbAddQuote.Text = "Add a Quote";
			this.tsbAddQuote.EnabledChanged += new System.EventHandler(this.tsbAddQuote_EnabledChanged);
			this.tsbAddQuote.VisibleChanged += new System.EventHandler(this.tsbAddQuote_VisibleChanged);
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
			// tsbLink
			// 
			this.tsbLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbLink.Image = global::rkcrm.Properties.Resources.create_link_28x28;
			this.tsbLink.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbLink.Name = "tsbLink";
			this.tsbLink.Size = new System.Drawing.Size(32, 32);
			this.tsbLink.Text = "Link";
			this.tsbLink.EnabledChanged += new System.EventHandler(this.tsbLink_EnabledChanged);
			this.tsbLink.VisibleChanged += new System.EventHandler(this.tsbLink_VisibleChanged);
			this.tsbLink.Click += new System.EventHandler(this.tsbLink_Click);
			// 
			// tsbRemoveLink
			// 
			this.tsbRemoveLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRemoveLink.Image = global::rkcrm.Properties.Resources.remove_link;
			this.tsbRemoveLink.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRemoveLink.Name = "tsbRemoveLink";
			this.tsbRemoveLink.Size = new System.Drawing.Size(32, 32);
			this.tsbRemoveLink.Text = "Remove Link";
			this.tsbRemoveLink.EnabledChanged += new System.EventHandler(this.tsbRemoveLink_EnabledChanged);
			this.tsbRemoveLink.VisibleChanged += new System.EventHandler(this.tsbRemoveLink_VisibleChanged);
			this.tsbRemoveLink.Click += new System.EventHandler(this.tsbRemoveLink_Click);
			// 
			// tss_4
			// 
			this.tss_4.Name = "tss_4";
			this.tss_4.Size = new System.Drawing.Size(6, 35);
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
			// tss_5
			// 
			this.tss_5.Name = "tss_5";
			this.tss_5.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbCrossLead
			// 
			this.tsbCrossLead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCrossLead.Image = global::rkcrm.Properties.Resources.Notify_Icon;
			this.tsbCrossLead.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCrossLead.Name = "tsbCrossLead";
			this.tsbCrossLead.Size = new System.Drawing.Size(32, 32);
			this.tsbCrossLead.Text = "Cross Lead";
			this.tsbCrossLead.EnabledChanged += new System.EventHandler(this.tsbCrossLead_EnabledChanged);
			this.tsbCrossLead.VisibleChanged += new System.EventHandler(this.tsbCrossLead_VisibleChanged);
			this.tsbCrossLead.Click += new System.EventHandler(this.tsbCrossLead_Click);
			// 
			// chProjectID
			// 
			this.chProjectID.Text = "Project ID";
			this.chProjectID.Width = 0;
			// 
			// chName
			// 
			this.chName.Text = "Project Name";
			this.chName.Width = 150;
			// 
			// chAddress
			// 
			this.chAddress.Text = "Address";
			this.chAddress.Width = 200;
			// 
			// chCity
			// 
			this.chCity.Text = "City";
			this.chCity.Width = 80;
			// 
			// chType
			// 
			this.chType.Text = "Project Type";
			this.chType.Width = 90;
			// 
			// projectControls
			// 
			this.projectControls.AutoScroll = true;
			this.projectControls.BackColor = System.Drawing.Color.White;
			this.projectControls.ChangeHistoryVisible = true;
			this.projectControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.projectControls.Location = new System.Drawing.Point(0, 35);
			this.projectControls.MyProject = null;
			this.projectControls.Name = "projectControls";
			this.projectControls.Size = new System.Drawing.Size(600, 206);
			this.projectControls.TabIndex = 1;
			this.projectControls.Title = "Title";
			this.projectControls.TitleBarVisible = true;
			this.projectControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.projectControls_IsDirtyChanged);
			this.projectControls.MyProjectChanged += new System.EventHandler<System.EventArgs>(this.projectControls_MyProjectChanged);
			// 
			// tsmAddNote
			// 
			this.tsmAddNote.Image = global::rkcrm.Properties.Resources.New_Note_Icon;
			this.tsmAddNote.Name = "tsmAddNote";
			this.tsmAddNote.Size = new System.Drawing.Size(153, 22);
			this.tsmAddNote.Text = "Add Note";
			this.tsmAddNote.Click += new System.EventHandler(this.tsbAddNote_Click);
			// 
			// tsmAddQuote
			// 
			this.tsmAddQuote.Image = global::rkcrm.Properties.Resources.New_Quote_icon;
			this.tsmAddQuote.Name = "tsmAddQuote";
			this.tsmAddQuote.Size = new System.Drawing.Size(153, 22);
			this.tsmAddQuote.Text = "Add Quote";
			this.tsmAddQuote.Click += new System.EventHandler(this.tsbAddQuote_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(150, 6);
			// 
			// tsmLink
			// 
			this.tsmLink.Image = global::rkcrm.Properties.Resources.create_link_28x28;
			this.tsmLink.Name = "tsmLink";
			this.tsmLink.Size = new System.Drawing.Size(153, 22);
			this.tsmLink.Text = "Link";
			this.tsmLink.Click += new System.EventHandler(this.tsbLink_Click);
			// 
			// tsmRemoveLink
			// 
			this.tsmRemoveLink.Image = global::rkcrm.Properties.Resources.remove_link;
			this.tsmRemoveLink.Name = "tsmRemoveLink";
			this.tsmRemoveLink.Size = new System.Drawing.Size(153, 22);
			this.tsmRemoveLink.Text = "Remove Link";
			this.tsmRemoveLink.Click += new System.EventHandler(this.tsbRemoveLink_Click);
			// 
			// mss_2
			// 
			this.mss_2.Name = "mss_2";
			this.mss_2.Size = new System.Drawing.Size(150, 6);
			// 
			// tsmReopen
			// 
			this.tsmReopen.Image = global::rkcrm.Properties.Resources.Reopen28x28;
			this.tsmReopen.Name = "tsmReopen";
			this.tsmReopen.Size = new System.Drawing.Size(153, 22);
			this.tsmReopen.Text = "Reopen";
			this.tsmReopen.Click += new System.EventHandler(this.tsbReopen_Click);
			// 
			// tsmSell
			// 
			this.tsmSell.Image = global::rkcrm.Properties.Resources.Sold_Icon;
			this.tsmSell.Name = "tsmSell";
			this.tsmSell.Size = new System.Drawing.Size(153, 22);
			this.tsmSell.Text = "Sell";
			this.tsmSell.Click += new System.EventHandler(this.tsbSell_Click);
			// 
			// tsmLose
			// 
			this.tsmLose.Image = global::rkcrm.Properties.Resources.Lost_Icon;
			this.tsmLose.Name = "tsmLose";
			this.tsmLose.Size = new System.Drawing.Size(153, 22);
			this.tsmLose.Text = "Lose";
			this.tsmLose.Click += new System.EventHandler(this.tsbLose_Click);
			// 
			// mss_3
			// 
			this.mss_3.Name = "mss_3";
			this.mss_3.Size = new System.Drawing.Size(150, 6);
			// 
			// tsmCrossLead
			// 
			this.tsmCrossLead.Image = global::rkcrm.Properties.Resources.Notify_Icon;
			this.tsmCrossLead.Name = "tsmCrossLead";
			this.tsmCrossLead.Size = new System.Drawing.Size(153, 22);
			this.tsmCrossLead.Text = "Cross Lead";
			this.tsmCrossLead.Click += new System.EventHandler(this.tsbCrossLead_Click);
			// 
			// mss_4
			// 
			this.mss_4.Name = "mss_4";
			this.mss_4.Size = new System.Drawing.Size(150, 6);
			// 
			// tsmDelete
			// 
			this.tsmDelete.Image = global::rkcrm.Properties.Resources.Delete_icon;
			this.tsmDelete.Name = "tsmDelete";
			this.tsmDelete.Size = new System.Drawing.Size(153, 22);
			this.tsmDelete.Text = "Delete Project";
			this.tsmDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// tsmRestore
			// 
			this.tsmRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsmRestore.Name = "tsmRestore";
			this.tsmRestore.Size = new System.Drawing.Size(153, 22);
			this.tsmRestore.Text = "Restore Project";
			this.tsmRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// mss_5
			// 
			this.mss_5.Name = "mss_5";
			this.mss_5.Size = new System.Drawing.Size(150, 6);
			// 
			// tsmCancel
			// 
			this.tsmCancel.Image = global::rkcrm.Properties.Resources.Cancel;
			this.tsmCancel.Name = "tsmCancel";
			this.tsmCancel.Size = new System.Drawing.Size(153, 22);
			this.tsmCancel.Text = "Cancel";
			this.tsmCancel.Click += new System.EventHandler(this.tsbCancel_Click);
			// 
			// ProjectScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ListTitle = "Project List";
			this.Name = "ProjectScreen";
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
				this.tsmAddNote,
				this.tsmAddQuote,
				this.mss_1,
				this.tsmLink,
				this.tsmRemoveLink,
				this.mss_2,
				this.tsmReopen,
				this.tsmSell,
				this.tsmLose,
				this.mss_3,
				this.tsmCrossLead,
				this.mss_4,
				this.tsmDelete,
				this.tsmRestore,
				this.mss_5,
				this.tsmCancel});
		}

		public void LoadList()
		{
			lvwList.Items.Clear();
			
			if (MyCustomer != null)
			{
				using (ProjectController theController = new ProjectController())
				{
					ListViewItem newItem;

					foreach (DataRow oRow in theController.GetProjects(MyCustomer.ID).Rows)
					{
						newItem = new ListViewItem();
						newItem.Text = oRow["project_id"].ToString();
						newItem.SubItems.Add(oRow["name"].ToString());
						newItem.SubItems.Add(oRow["address"].ToString());
						newItem.SubItems.Add(oRow["city"].ToString());
						newItem.SubItems.Add(oRow["type"].ToString());

						if (Convert.ToBoolean(oRow["is_archived"].ToString()))
							newItem.BackColor = Color.LightSteelBlue;

						lvwList.Items.Add(newItem);
					}
				}
			}
		}

		private void RefreshList()
		{

			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			if (lvwList.SelectedItems.Count > 0)
				lvwList.SelectedItems[0].Selected = false;

            if (MyCustomer != null)
                LoadList();
		}

		private void SetAddingMode()
		{
			tsbAddNote.Enabled = false;
			tsbAddProject.Enabled = false;
			tsbAddQuote.Enabled = false;
			tsbCrossLead.Enabled = false;
			tsbDelete.Enabled = false;
			tsbLink.Enabled = false;
			tsbLose.Enabled = false;
			tsbRemoveLink.Enabled = false;
			tsbReopen.Enabled = false;
			tsbRestore.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbSell.Enabled = false;

			tsbLink.Visible = true;
			tsbRemoveLink.Visible = false;
			tsbDelete.Visible = true;
			tsbRestore.Visible = false;

			Clear();
			projectControls.MyProject.CustomerID = MyCustomer.ID;

			IsDisposable = true;
			RefreshList();
		}

		private void SetEditingMode()
		{
			bool IsGeneralNotes = (MyProject.Name == "GENERAL NOTES");

			if (!MyProject.IsArchived)
			{
				tsbAddNote.Enabled = true;
				tsbAddQuote.Enabled = !IsGeneralNotes;
				tsbCrossLead.Enabled = !IsGeneralNotes;
				tsbSave.Enabled = false;
				tsbSaveClose.Enabled = false;
				tsbSaveNew.Enabled = false;
				tsbDelete.Enabled = !IsGeneralNotes;
				tsbLink.Enabled = !IsGeneralNotes;
				tsbRemoveLink.Enabled = !IsGeneralNotes;
				tsbLink.Enabled = !IsGeneralNotes;
			}
			else
			{
				tsbAddNote.Enabled = false;
				tsbAddQuote.Enabled = false;
				tsbCrossLead.Enabled = false;
				tsbSave.Enabled = false;
				tsbSaveClose.Enabled = false;
				tsbSaveNew.Enabled = false;
				tsbDelete.Enabled = false;
				tsbLink.Enabled = false;
				tsbRemoveLink.Enabled = false;
				tsbLink.Enabled = false;
			}

			tsbAddProject.Enabled = true;
			tsbRestore.Enabled = true;

			tsbDelete.Visible = (!MyProject.IsArchived);
			tsbRestore.Visible = (MyProject.IsArchived);

			tsbLink.Visible = (MyProject.LinkID == 0);
			tsbRemoveLink.Visible = !tsbLink.Visible;

			GetStatusButtonAvailability();

			IsDisposable = false;
		}

		private void SetSearchingMode()
		{
			tsbAddNote.Enabled = false;
			tsbAddProject.Enabled = true;
			tsbAddQuote.Enabled = false;
			tsbCrossLead.Enabled = false;
			tsbDelete.Enabled = false;
			tsbLink.Enabled = false;
			tsbLose.Enabled = false;
			tsbRemoveLink.Enabled = false;
			tsbReopen.Enabled = false;
			tsbRestore.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbSell.Enabled = false;

			tsbLink.Visible = false;
			tsbRemoveLink.Visible = true;
			tsbDelete.Visible = true;
			tsbRestore.Visible = false;

			Clear();

			if (projectControls.MyProject != null)
				projectControls.MyProject.Dispose();

			projectControls.MyProject = null;

            RefreshList();
        }

		private void GetStatusButtonAvailability()
		{
			tsbLose.Enabled = false;
			tsbSell.Enabled = false;
			tsbReopen.Enabled = false;
			
			using (ProjectController theController = new ProjectController())
			{
				foreach (DataRow oRow in theController.GetStatuses(MyProject.ID).Rows)
				{
					if (Convert.ToInt32(oRow["status_id"]) == OUTSTANDING)
					{
						tsbLose.Enabled = !MyProject.IsArchived;
						tsbSell.Enabled = !MyProject.IsArchived;
					}
					else
						tsbReopen.Enabled = !MyProject.IsArchived;
				}
			}
		}

		public override bool Save()
		{
			bool result = true;

			result = projectControls.Save();

			if (result)
				RefreshList();

			return result;
		}

		public void ValidateSecurityAccess()
		{
			/*
			 * tsMain.Items[0] = tsbSave
			 * tsMain.Items[1] = tsbSaveClose
			 * tsMain.Items[2] = tsbSaveNew
			 * tsMain.Items[3] = tss_0
			 * tsMain.Items[4] = tsbAddProject
			 * tsMain.Items[5] = tsbAddNote
			 * tsMain.Items[6] = tsbAddQuote
			 * tsMain.Items[7] = tss_1
			 * tsMain.Items[8] = tsbCancel
			 * tsMain.Items[9] = tss_2
			 * tsMain.Items[10] = tsbDelete
			 * tsMain.Items[11] = tsbRestore
			 * tsMain.Items[12] = tss_3
			 * tsMain.Items[13] = tsbLink
			 * tsMain.Items[14] = tsbRemoveLink
			 * tsMain.Items[15] = tss_4
			 * tsMain.Items[16] = tsbReopen
			 * tsMain.Items[17] = tsbSell
			 * tsMain.Items[18] = tsbLose
			 * tsMain.Items[19] = tss_5
			 * tsMain.Items[20] = tsbCrossLead
			 * 
			 * AccessCode = 2097151 (0b0001_1111_1111_1111_1111_1111 0x1fffff) All Access
			 */
		}

		public override void RefreshData()
		{
			MyProject = MyProject;
		}

		private bool IsNoteNeeded(int ProjectID, int DepartmentID)
		{
			int noteCount;

			using (NoteController theController = new NoteController())
			{
				noteCount = theController.GetOpenNoteCount(ProjectID, DepartmentID);
			}

			return (noteCount == 0);
		}

		#endregion


		#region Event Handlers

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
								using (ProjectController theController = new ProjectController())
								{
									MyProject = theController.GetProject(Convert.ToInt32(e.Item.Text));
								}
							}
							break;
						case DialogResult.Cancel:
							break;
						default:
							using (ProjectController theController = new ProjectController())
							{
								MyProject = theController.GetProject(Convert.ToInt32(e.Item.Text));
							}
							break;
					}
				}
				else
				{
					using (ProjectController theController = new ProjectController())
					{
						MyProject = theController.GetProject(Convert.ToInt32(e.Item.Text));
					}
				}
			}

		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
							MyProject = new Project();
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyProject = new Project();
						break;
				}
			}
			else
				MyProject = new Project();
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
					MyProject = MyProject;
			}
		}

		private void tsbSaveClose_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
                    MyProject = new Project();
			}
			else
				MyProject = new Project();
		}

		private void tsbSaveNew_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
                if (Save())
                    MyProject = new Project();
			}
			else
				MyProject = new Project();
		}

		private void tsbAddProject_Click(object sender, EventArgs e)
		{
			if (IsDirty)
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
							MyProject = new Project();
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyProject = new Project();
						break;
				}
			else
				MyProject = new Project();
		}

		private void tsbAddNote_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			
			if (IsDirty)
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
						{
							myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[0];

							myNavigation.btnCustomer.MyProject = MyProject;
							myNavigation.btnCustomer.PerformClick();

							((NoteScreen)myNavigation.CurrentScreen).MyProject = MyProject;
							((NoteScreen)myNavigation.CurrentScreen).MyNote = new Note.Note();
						}
						break;
					case DialogResult.Cancel:
						break;
					default:
						myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[0];

						myNavigation.btnCustomer.MyProject = MyProject;
						myNavigation.btnCustomer.PerformClick();

						((NoteScreen)myNavigation.CurrentScreen).MyProject = MyProject;
						((NoteScreen)myNavigation.CurrentScreen).MyNote = new Note.Note();
						break;
				}
			else
			{
				myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[0];

				myNavigation.btnCustomer.MyProject = MyProject;
				myNavigation.btnCustomer.PerformClick();

				((NoteScreen)myNavigation.CurrentScreen).MyProject = MyProject;
				((NoteScreen)myNavigation.CurrentScreen).MyNote = new Note.Note();
			}
		}

		private void tsbAddQuote_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[1];

			myNavigation.btnCustomer.MyProject = MyProject;
			myNavigation.btnCustomer.MyCustomer = MyCustomer;

			myNavigation.btnCustomer.PerformClick();

			((QuoteScreen)myNavigation.CurrentScreen).MyProject = MyProject;
			((QuoteScreen)myNavigation.CurrentScreen).MyQuote = new rkcrm.Objects.Quote.Quote();
		}

		private void tsbDelete_Click(object sender, EventArgs e)
		{
			bool IsDeleted = false;

			using (ProjectController theController = new ProjectController())
			{
				MyProject.IsArchived = true;
				IsDeleted = theController.UpdateProject(MyProject);
			}

			if (IsDeleted)
			{
				using (NoteController theController = new NoteController())
				{
					theController.ArchiveAllNotes(MyProject.ID);
				}

				using (QuoteController theController = new QuoteController())
				{
					theController.ArchiveAllQuotes(MyProject.ID);
				}

				MyProject = new Project();

				RefreshReminders();
			}

		}

		private void tsbRestore_Click(object sender, EventArgs e)
		{
			DateTime archived = MyProject.Updated;

			MyProject.IsArchived = false;
			if (Save())
			{
				using (NoteController theController = new NoteController())
				{
					theController.RestoreAllNotes(MyProject.ID, archived);
				}

				using (QuoteController theController = new QuoteController())
				{
					theController.RestoreAllQuotes(MyProject.ID, archived);
				}

				MyProject = MyProject;
				LoadList();

				RefreshReminders();
			}
		}

		private void tsbLink_Click(object sender, EventArgs e)
		{
			ProjectSearchList oForm = new ProjectSearchList();
			oForm.ShowDialog();

			if (oForm.DialogResult == DialogResult.OK)
			{
				int LinkID;
				using (ProjectController theController = new ProjectController())
				{
					LinkID = theController.Link(MyProject, (Project)oForm.ReturnValue);
					if (LinkID > 0)
					{
						MessageBox.Show("Project successfully linked.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
						MyProject.LinkID = LinkID;
						MyProject = MyProject;
					}
				}
			}

			oForm.Dispose();
			oForm = null;
		}

		private void tsbRemoveLink_Click(object sender, EventArgs e)
		{
			using (ProjectController theController = new ProjectController())
			{
				if (theController.RemoveLink(MyProject))
				{
					MyProject.LinkID = 0;
					MessageBox.Show("Project link successfully removed.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
					SetEditingMode();
				}
			}
		}

		private void tsbReopen_Click(object sender, EventArgs e)
		{
			Administration.Department.DepartmentSelect oForm = new rkcrm.Administration.Department.DepartmentSelect();

			using (Department.DepartmentController theController = new rkcrm.Objects.Project.Department.DepartmentController())
			{
				Department.Department theProjectDepartment = null;
			
				oForm.DataSource = theController.GetSoldLostDepartments(MyProject.ID);
				oForm.DisplayMember = "name";
				oForm.ValueMember = "department_id";

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					foreach (object Department in oForm.SelectedItems)
					{
						theProjectDepartment = theController.GetDepartmentWithLastestScope(MyProject.ID, Convert.ToInt32(((DataRowView)Department)["department_id"]));

						if (theProjectDepartment.Status == Project.ProjectStatus.Sold)
							theController.ClearSoldMarkers(theProjectDepartment);
						else
							theController.DeleteLostProjectReports(theProjectDepartment);

						theController.UpdateStatus(theProjectDepartment, Project.ProjectStatus.Outstanding);

						// Every outstanding project must have an "oustanding note" so add one that is due today
						if (IsNoteNeeded(theProjectDepartment.ProjectID, theProjectDepartment.DepartmentID))
						{
							// Here we assume that this is a simple reopen which means that at least one quote exists
							Quote.Quote latestQuote = null;

							using (QuoteController theQuoteController = new QuoteController())
							{
								latestQuote = theQuoteController.GetLatestQuote(theProjectDepartment.ProjectID, theProjectDepartment.DepartmentID);
							}

							if (latestQuote != null)
							{
								Note.Note newNote = new Note.Note();
								newNote.ProjectID = theProjectDepartment.ProjectID;
								newNote.DepartmentID = theProjectDepartment.DepartmentID;
								newNote.ContactID = latestQuote.ContactID;
								newNote.MethodID = latestQuote.MethodID;
								newNote.NextFollowUp = DateTime.Today;
								newNote.PurposeID = 5; //Follow up on Quotes
								newNote.SalesRepID = latestQuote.SalesRepID;
								newNote.SalesSupportID = latestQuote.SalesSupportID;

								using (NoteController theNoteController = new NoteController())
								{
									newNote = theNoteController.InsertNote(newNote);
								}

								if (newNote.ID > 0)
									RefreshReminders();
							}
						}
					}

					projectControls.RefreshPreviewData();
					GetStatusButtonAvailability();
				}
			}
		}

		private void tsbSell_Click(object sender, EventArgs e)
		{
			QuoteSelect oForm = new QuoteSelect();

			using (Department.DepartmentController theController = new rkcrm.Objects.Project.Department.DepartmentController())
			{
				oForm.DataSource = theController.GetOutstandingQuotes(MyProject.ID);

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					theController.UpdateStatus(MyProject.ID, oForm.SelectedDepartmentID, Project.ProjectStatus.Sold);

					using (QuoteController theQuoteController = new QuoteController())
					{
						theQuoteController.MarkAsSold(oForm.SelectedQuoteID);
					}

					if (MessageBox.Show("Would you like to follow up with all remaining notes?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						using (NoteController theNoteCrontroller = new NoteController())
						{
							theNoteCrontroller.FollowUpOnAll(MyProject.ID, oForm.SelectedDepartmentID);
						}
					}

					projectControls.RefreshPreviewData();
					GetStatusButtonAvailability();
				}
			}
		}

		private void tsbLose_Click(object sender, EventArgs e)
		{
			Lost_Report.LostProjectForm oForm = new rkcrm.Objects.Project.Lost_Report.LostProjectForm(MyProject.ID);

			oForm.ShowDialog();

			if (oForm.DialogResult == DialogResult.OK)
			{
				using (Department.DepartmentController theController = new rkcrm.Objects.Project.Department.DepartmentController())
				{
					theController.UpdateStatus(MyProject.ID, oForm.SelectedDepartmentID, Project.ProjectStatus.Lost);
				}

				if (MessageBox.Show("Would you like to follow up with all remaining notes?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					using (NoteController theNoteCrontroller = new NoteController())
					{
						theNoteCrontroller.FollowUpOnAll(MyProject.ID, oForm.SelectedDepartmentID);
					}
				}

				GetStatusButtonAvailability();
				projectControls.RefreshPreviewData();
			}
		}

		private void tsbCrossLead_Click(object sender, EventArgs e)
		{
			SendCrossLead oForm = new SendCrossLead();
			oForm.crossLeadControls.MyProject = this.MyProject;

			oForm.ShowDialog();
		}

		private void projectControls_MyProjectChanged(object sender, EventArgs e)
		{
			//This tells the customer navigation button what project is currrently open 
			//which will be needed by any child screen of the project
			NavigationScreen navigation = GetNavigationScreen();
			navigation.btnCustomer.MyProject = MyProject;

			if (MyProject == null)
				SetSearchingMode();
			else
			{
				if (MyProject.ID > 0)
					SetEditingMode();
				else
				{
					if (MyProject.CustomerID != MyCustomer.ID)
						MyProject.CustomerID = MyCustomer.ID;

					SetAddingMode();
				}
			}
		}

		private void projectControls_IsDirtyChanged(object sender, EventArgs e)
		{
			bool IsGeneralNotes = (MyProject.Name == "GENERAL NOTES");

			tsbSave.Enabled = !IsGeneralNotes && IsDirty;
			tsbSaveClose.Enabled = !IsGeneralNotes && IsDirty;
			tsbSaveNew.Enabled = !IsGeneralNotes && IsDirty;
		}

		#endregion


		#region Constructor

		public ProjectScreen()
			: base()
		{
			InitializeComponent();
			InitializeActions();
		}

		#endregion


		#region Special Button Handlers

		private void tsbAddNote_EnabledChanged(object sender, EventArgs e)
		{
			tsmAddNote.Enabled = tsbAddNote.Enabled;
		}

		private void tsbAddNote_VisibleChanged(object sender, EventArgs e)
		{
			tsmAddNote.Visible = tsbAddNote.Visible;
		}

		private void tsbAddQuote_EnabledChanged(object sender, EventArgs e)
		{
			tsmAddQuote.Enabled = tsbAddQuote.Enabled;
		}

		private void tsbAddQuote_VisibleChanged(object sender, EventArgs e)
		{
			tsmAddQuote.Visible = tsbAddQuote.Visible;
		}

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

		private void tsbLink_EnabledChanged(object sender, EventArgs e)
		{
			tsmLink.Enabled = tsbLink.Enabled;
		}

		private void tsbLink_VisibleChanged(object sender, EventArgs e)
		{
			tsmLink.Visible = tsbLink.Visible;
		}

		private void tsbRemoveLink_EnabledChanged(object sender, EventArgs e)
		{
			tsmRemoveLink.Enabled = tsbRemoveLink.Enabled;
		}

		private void tsbRemoveLink_VisibleChanged(object sender, EventArgs e)
		{
			tsmRemoveLink.Visible = tsbRemoveLink.Visible;
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

		private void tsbCrossLead_EnabledChanged(object sender, EventArgs e)
		{
			tsmCrossLead.Enabled = tsbCrossLead.Enabled;
		}

		private void tsbCrossLead_VisibleChanged(object sender, EventArgs e)
		{
			tsmCrossLead.Visible = tsbCrossLead.Visible;
		}

		#endregion


	}
}
