namespace rkcrm
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.msMain = new System.Windows.Forms.MenuStrip();
			this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmReminders = new System.Windows.Forms.ToolStripMenuItem();
			this.tssView_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmUserProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmTools = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmDemoMode = new System.Windows.Forms.ToolStripMenuItem();
			this.tssTool_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmCrossLeads = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.tssHelp_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmCRMHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tslCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
			this.theNavigationScreen = new rkcrm.Navigation.NavigationScreen();
			this.msMain.SuspendLayout();
			this.mainStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// msMain
			// 
			this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmView,
            this.tsmTools,
            this.tsmHelp});
			this.msMain.Location = new System.Drawing.Point(0, 0);
			this.msMain.Name = "msMain";
			this.msMain.Size = new System.Drawing.Size(784, 24);
			this.msMain.TabIndex = 0;
			this.msMain.Text = "menuStrip1";
			// 
			// tsmFile
			// 
			this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExit});
			this.tsmFile.Name = "tsmFile";
			this.tsmFile.Size = new System.Drawing.Size(37, 20);
			this.tsmFile.Text = "&File";
			// 
			// tsmExit
			// 
			this.tsmExit.Name = "tsmExit";
			this.tsmExit.Size = new System.Drawing.Size(92, 22);
			this.tsmExit.Text = "E&xit";
			this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
			// 
			// tsmView
			// 
			this.tsmView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmReminders,
            this.tssView_0,
            this.tsmUserProperties});
			this.tsmView.Name = "tsmView";
			this.tsmView.Size = new System.Drawing.Size(44, 20);
			this.tsmView.Text = "&View";
			// 
			// tsmReminders
			// 
			this.tsmReminders.Name = "tsmReminders";
			this.tsmReminders.Size = new System.Drawing.Size(153, 22);
			this.tsmReminders.Text = "Reminders";
			this.tsmReminders.Click += new System.EventHandler(this.tsmReminders_Click);
			// 
			// tssView_0
			// 
			this.tssView_0.Name = "tssView_0";
			this.tssView_0.Size = new System.Drawing.Size(150, 6);
			// 
			// tsmUserProperties
			// 
			this.tsmUserProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsmUserProperties.Name = "tsmUserProperties";
			this.tsmUserProperties.Size = new System.Drawing.Size(153, 22);
			this.tsmUserProperties.Text = "User Properties";
			this.tsmUserProperties.Click += new System.EventHandler(this.tsmUserProperties_Click);
			// 
			// tsmTools
			// 
			this.tsmTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDemoMode,
            this.tssTool_0,
            this.tsmCrossLeads});
			this.tsmTools.Name = "tsmTools";
			this.tsmTools.Size = new System.Drawing.Size(48, 20);
			this.tsmTools.Text = "&Tools";
			// 
			// tsmDemoMode
			// 
			this.tsmDemoMode.Image = global::rkcrm.Properties.Resources.Play_Icon_16;
			this.tsmDemoMode.Name = "tsmDemoMode";
			this.tsmDemoMode.Size = new System.Drawing.Size(214, 22);
			this.tsmDemoMode.Text = "Demonstration Mode [On]";
			this.tsmDemoMode.Click += new System.EventHandler(this.tsmDemoMode_Click);
			// 
			// tssTool_0
			// 
			this.tssTool_0.Name = "tssTool_0";
			this.tssTool_0.Size = new System.Drawing.Size(211, 6);
			// 
			// tsmCrossLeads
			// 
			this.tsmCrossLeads.Name = "tsmCrossLeads";
			this.tsmCrossLeads.Size = new System.Drawing.Size(214, 22);
			this.tsmCrossLeads.Text = "Cross Lead Assignments";
			this.tsmCrossLeads.Click += new System.EventHandler(this.tsmCrossLeads_Click);
			// 
			// tsmHelp
			// 
			this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout,
            this.tssHelp_0,
            this.tsmCRMHelp});
			this.tsmHelp.Name = "tsmHelp";
			this.tsmHelp.Size = new System.Drawing.Size(44, 20);
			this.tsmHelp.Text = "&Help";
			// 
			// tsmAbout
			// 
			this.tsmAbout.Name = "tsmAbout";
			this.tsmAbout.Size = new System.Drawing.Size(107, 22);
			this.tsmAbout.Text = "About";
			this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
			// 
			// tssHelp_0
			// 
			this.tssHelp_0.Name = "tssHelp_0";
			this.tssHelp_0.Size = new System.Drawing.Size(104, 6);
			// 
			// tsmCRMHelp
			// 
			this.tsmCRMHelp.Name = "tsmCRMHelp";
			this.tsmCRMHelp.Size = new System.Drawing.Size(107, 22);
			this.tsmCRMHelp.Text = "Help";
			this.tsmCRMHelp.Click += new System.EventHandler(this.tsmCRMHelp_Click);
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus,
            this.tslCurrentUser});
			this.mainStatusStrip.Location = new System.Drawing.Point(0, 540);
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.Size = new System.Drawing.Size(784, 22);
			this.mainStatusStrip.TabIndex = 1;
			this.mainStatusStrip.Text = "statusStrip1";
			// 
			// tslStatus
			// 
			this.tslStatus.Name = "tslStatus";
			this.tslStatus.Size = new System.Drawing.Size(39, 17);
			this.tslStatus.Text = "Ready";
			// 
			// tslCurrentUser
			// 
			this.tslCurrentUser.Name = "tslCurrentUser";
			this.tslCurrentUser.Size = new System.Drawing.Size(730, 17);
			this.tslCurrentUser.Spring = true;
			this.tslCurrentUser.Text = "Current User: ";
			this.tslCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// theNavigationScreen
			// 
			this.theNavigationScreen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.theNavigationScreen.Location = new System.Drawing.Point(0, 24);
			this.theNavigationScreen.Name = "theNavigationScreen";
			this.theNavigationScreen.Size = new System.Drawing.Size(784, 516);
			this.theNavigationScreen.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.theNavigationScreen);
			this.Controls.Add(this.mainStatusStrip);
			this.Controls.Add(this.msMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.msMain;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.msMain.ResumeLayout(false);
			this.msMain.PerformLayout();
			this.mainStatusStrip.ResumeLayout(false);
			this.mainStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.ToolStripMenuItem tsmReminders;
        private System.Windows.Forms.ToolStripMenuItem tsmTools;
        private System.Windows.Forms.ToolStripSeparator tssTool_0;
        private System.Windows.Forms.ToolStripMenuItem tsmCrossLeads;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ToolStripSeparator tssHelp_0;
        private System.Windows.Forms.ToolStripMenuItem tsmCRMHelp;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslCurrentUser;
		public System.Windows.Forms.ToolStripMenuItem tsmDemoMode;
        public System.Windows.Forms.MenuStrip msMain;
		internal rkcrm.Navigation.NavigationScreen theNavigationScreen;
		private System.Windows.Forms.ToolStripSeparator tssView_0;
		private System.Windows.Forms.ToolStripMenuItem tsmUserProperties;
    }
}

