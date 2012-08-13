namespace rkcrm.Navigation
{
    partial class NavigationScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationScreen));
			this.imlMinimize = new System.Windows.Forms.ImageList(this.components);
			this.imlMaximize = new System.Windows.Forms.ImageList(this.components);
			this.scMain = new System.Windows.Forms.SplitContainer();
			this.pnlCollapsedNav = new System.Windows.Forms.Panel();
			this.pbxCollapsedTitle = new System.Windows.Forms.PictureBox();
			this.pbxMaximize_2 = new System.Windows.Forms.PictureBox();
			this.pbxMaximize_1 = new System.Windows.Forms.PictureBox();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.pnlExpandedNav = new System.Windows.Forms.Panel();
			this.pbxMinimize = new System.Windows.Forms.PictureBox();
			this.lblNavigationTitle = new System.Windows.Forms.Label();
			this.btnAdministration = new rkcrm.Navigation.AdministrationButton();
			this.btnReports = new rkcrm.Navigation.ReportsButton();
			this.btnCustomer = new rkcrm.Navigation.CustomerButton();
			this.btnSearch = new rkcrm.Navigation.SearchButton();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.SuspendLayout();
			this.pnlCollapsedNav.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxCollapsedTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxMaximize_2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxMaximize_1)).BeginInit();
			this.pnlButtons.SuspendLayout();
			this.pnlExpandedNav.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxMinimize)).BeginInit();
			this.SuspendLayout();
			// 
			// imlMinimize
			// 
			this.imlMinimize.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMinimize.ImageStream")));
			this.imlMinimize.TransparentColor = System.Drawing.Color.Transparent;
			this.imlMinimize.Images.SetKeyName(0, "MinimizedHighlight.png");
			this.imlMinimize.Images.SetKeyName(1, "MinimizedPressed.png");
			// 
			// imlMaximize
			// 
			this.imlMaximize.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMaximize.ImageStream")));
			this.imlMaximize.TransparentColor = System.Drawing.Color.Transparent;
			this.imlMaximize.Images.SetKeyName(0, "MaximizedHighlight.png");
			this.imlMaximize.Images.SetKeyName(1, "MaximizedPressed.png");
			this.imlMaximize.Images.SetKeyName(2, "MaximizeNavigation.png");
			// 
			// scMain
			// 
			this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scMain.Location = new System.Drawing.Point(0, 0);
			this.scMain.Name = "scMain";
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.pnlCollapsedNav);
			this.scMain.Panel1.Controls.Add(this.pnlButtons);
			this.scMain.Panel1.Controls.Add(this.pnlExpandedNav);
			this.scMain.Panel1MinSize = 28;
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.scMain_Panel2_ControlAdded);
			this.scMain.Panel2.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.scMain_Panel2_ControlRemoved);
			this.scMain.Size = new System.Drawing.Size(780, 515);
			this.scMain.SplitterDistance = 176;
			this.scMain.TabIndex = 0;
			this.scMain.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.scMain_SplitterMoving);
			// 
			// pnlCollapsedNav
			// 
			this.pnlCollapsedNav.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlCollapsedNav.BackgroundImage")));
			this.pnlCollapsedNav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlCollapsedNav.Controls.Add(this.pbxCollapsedTitle);
			this.pnlCollapsedNav.Controls.Add(this.pbxMaximize_2);
			this.pnlCollapsedNav.Controls.Add(this.pbxMaximize_1);
			this.pnlCollapsedNav.Location = new System.Drawing.Point(0, 0);
			this.pnlCollapsedNav.Name = "pnlCollapsedNav";
			this.pnlCollapsedNav.Size = new System.Drawing.Size(28, 514);
			this.pnlCollapsedNav.TabIndex = 2;
			this.pnlCollapsedNav.Visible = false;
			this.pnlCollapsedNav.VisibleChanged += new System.EventHandler(this.pnlCollapsedNav_VisibleChanged);
			this.pnlCollapsedNav.MouseLeave += new System.EventHandler(this.pnlCollapsedNav_MouseLeave);
			this.pnlCollapsedNav.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCollapsedNav_MouseDown);
			this.pnlCollapsedNav.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlCollapsedNav_MouseUp);
			this.pnlCollapsedNav.SizeChanged += new System.EventHandler(this.pnlCollapsedNav_SizeChanged);
			this.pnlCollapsedNav.MouseEnter += new System.EventHandler(this.pnlCollapsedNav_MouseEnter);
			// 
			// pbxCollapsedTitle
			// 
			this.pbxCollapsedTitle.BackColor = System.Drawing.Color.Transparent;
			this.pbxCollapsedTitle.Image = global::rkcrm.Properties.Resources.Navigation_0;
			this.pbxCollapsedTitle.Location = new System.Drawing.Point(1, 202);
			this.pbxCollapsedTitle.Name = "pbxCollapsedTitle";
			this.pbxCollapsedTitle.Size = new System.Drawing.Size(25, 100);
			this.pbxCollapsedTitle.TabIndex = 2;
			this.pbxCollapsedTitle.TabStop = false;
			// 
			// pbxMaximize_2
			// 
			this.pbxMaximize_2.BackColor = System.Drawing.Color.Transparent;
			this.pbxMaximize_2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pbxMaximize_2.Image = global::rkcrm.Properties.Resources.ExpandNavigation2;
			this.pbxMaximize_2.Location = new System.Drawing.Point(0, 484);
			this.pbxMaximize_2.Name = "pbxMaximize_2";
			this.pbxMaximize_2.Size = new System.Drawing.Size(26, 28);
			this.pbxMaximize_2.TabIndex = 1;
			this.pbxMaximize_2.TabStop = false;
			// 
			// pbxMaximize_1
			// 
			this.pbxMaximize_1.BackColor = System.Drawing.Color.Transparent;
			this.pbxMaximize_1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pbxMaximize_1.Image = global::rkcrm.Properties.Resources.ExpandNavigation1;
			this.pbxMaximize_1.Location = new System.Drawing.Point(0, 0);
			this.pbxMaximize_1.Name = "pbxMaximize_1";
			this.pbxMaximize_1.Size = new System.Drawing.Size(26, 28);
			this.pbxMaximize_1.TabIndex = 0;
			this.pbxMaximize_1.TabStop = false;
			// 
			// pnlButtons
			// 
			this.pnlButtons.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlButtons.Controls.Add(this.btnAdministration);
			this.pnlButtons.Controls.Add(this.btnReports);
			this.pnlButtons.Controls.Add(this.btnCustomer);
			this.pnlButtons.Controls.Add(this.btnSearch);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlButtons.Location = new System.Drawing.Point(0, 28);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(176, 487);
			this.pnlButtons.TabIndex = 0;
			// 
			// pnlExpandedNav
			// 
			this.pnlExpandedNav.BackColor = System.Drawing.Color.Transparent;
			this.pnlExpandedNav.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlExpandedNav.BackgroundImage")));
			this.pnlExpandedNav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlExpandedNav.Controls.Add(this.pbxMinimize);
			this.pnlExpandedNav.Controls.Add(this.lblNavigationTitle);
			this.pnlExpandedNav.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlExpandedNav.Location = new System.Drawing.Point(0, 0);
			this.pnlExpandedNav.Name = "pnlExpandedNav";
			this.pnlExpandedNav.Size = new System.Drawing.Size(176, 28);
			this.pnlExpandedNav.TabIndex = 1;
			// 
			// pbxMinimize
			// 
			this.pbxMinimize.BackColor = System.Drawing.Color.Transparent;
			this.pbxMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			this.pbxMinimize.Image = global::rkcrm.Properties.Resources.CollapseNavigation2;
			this.pbxMinimize.Location = new System.Drawing.Point(142, 0);
			this.pbxMinimize.Name = "pbxMinimize";
			this.pbxMinimize.Size = new System.Drawing.Size(32, 26);
			this.pbxMinimize.TabIndex = 2;
			this.pbxMinimize.TabStop = false;
			this.pbxMinimize.MouseLeave += new System.EventHandler(this.pbxNavigation_Minimize_MouseLeave);
			this.pbxMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxNavigation_Minimize_MouseDown);
			this.pbxMinimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxNavigation_Minimize_MouseUp);
			this.pbxMinimize.MouseEnter += new System.EventHandler(this.pbxNavigation_Minimize_MouseEnter);
			// 
			// lblNavigationTitle
			// 
			this.lblNavigationTitle.AutoSize = true;
			this.lblNavigationTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblNavigationTitle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNavigationTitle.ForeColor = System.Drawing.Color.White;
			this.lblNavigationTitle.Location = new System.Drawing.Point(2, 4);
			this.lblNavigationTitle.Name = "lblNavigationTitle";
			this.lblNavigationTitle.Size = new System.Drawing.Size(84, 18);
			this.lblNavigationTitle.TabIndex = 0;
			this.lblNavigationTitle.Text = "Navigation";
			// 
			// btnAdministration
			// 
			this.btnAdministration.ButtonText = "Administration";
			this.btnAdministration.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAdministration.HasOptions = true;
			this.btnAdministration.Icon = ((System.Drawing.Image)(resources.GetObject("btnAdministration.Icon")));
			this.btnAdministration.IsSelected = false;
			this.btnAdministration.Location = new System.Drawing.Point(0, 96);
			this.btnAdministration.MinimumSize = new System.Drawing.Size(0, 32);
			this.btnAdministration.Name = "btnAdministration";
			this.btnAdministration.Size = new System.Drawing.Size(174, 32);
			this.btnAdministration.TabIndex = 2;
			// 
			// btnReports
			// 
			this.btnReports.ButtonText = "Reports";
			this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnReports.HasOptions = false;
			this.btnReports.Icon = ((System.Drawing.Image)(resources.GetObject("btnReports.Icon")));
			this.btnReports.IsSelected = false;
			this.btnReports.Location = new System.Drawing.Point(0, 64);
			this.btnReports.MinimumSize = new System.Drawing.Size(0, 32);
			this.btnReports.Name = "btnReports";
			this.btnReports.Size = new System.Drawing.Size(174, 32);
			this.btnReports.TabIndex = 1;
			// 
			// btnCustomer
			// 
			this.btnCustomer.ButtonText = "Customer";
			this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnCustomer.HasOptions = true;
			this.btnCustomer.Icon = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Icon")));
			this.btnCustomer.IsSelected = false;
			this.btnCustomer.Location = new System.Drawing.Point(0, 32);
			this.btnCustomer.MinimumSize = new System.Drawing.Size(0, 32);
			this.btnCustomer.Name = "btnCustomer";
			this.btnCustomer.Size = new System.Drawing.Size(174, 32);
			this.btnCustomer.TabIndex = 0;
			// 
			// btnSearch
			// 
			this.btnSearch.ButtonText = "Search";
			this.btnSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnSearch.HasOptions = true;
			this.btnSearch.Icon = ((System.Drawing.Image)(resources.GetObject("btnSearch.Icon")));
			this.btnSearch.IsSelected = false;
			this.btnSearch.Location = new System.Drawing.Point(0, 0);
			this.btnSearch.MinimumSize = new System.Drawing.Size(0, 32);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(174, 32);
			this.btnSearch.TabIndex = 0;
			// 
			// NavigationScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.scMain);
			this.Name = "NavigationScreen";
			this.Size = new System.Drawing.Size(780, 515);
			this.Load += new System.EventHandler(this.NavigationScreen_Load);
			this.SizeChanged += new System.EventHandler(this.NavigationScreen_SizeChanged);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.pnlCollapsedNav.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbxCollapsedTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxMaximize_2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxMaximize_1)).EndInit();
			this.pnlButtons.ResumeLayout(false);
			this.pnlExpandedNav.ResumeLayout(false);
			this.pnlExpandedNav.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxMinimize)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlExpandedNav;
        internal System.Windows.Forms.PictureBox pbxMinimize;
        internal System.Windows.Forms.Label lblNavigationTitle;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.ImageList imlMinimize;
        private System.Windows.Forms.Panel pnlCollapsedNav;
        private System.Windows.Forms.PictureBox pbxMaximize_2;
        private System.Windows.Forms.PictureBox pbxMaximize_1;
        private System.Windows.Forms.ImageList imlMaximize;
		private System.Windows.Forms.PictureBox pbxCollapsedTitle;
		public System.Windows.Forms.SplitContainer scMain;
		public SearchButton btnSearch;
		public CustomerButton btnCustomer;
		public ReportsButton btnReports;
		public AdministrationButton btnAdministration;
    }
}
