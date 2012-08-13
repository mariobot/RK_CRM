namespace rkcrm.Reminder_Module
{
    partial class AssignmentReminders
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
			this.lblNotes = new System.Windows.Forms.Label();
			this.lvwCrossLeads = new System.Windows.Forms.ListView();
			this.chLeadID = new System.Windows.Forms.ColumnHeader();
			this.chReceived = new System.Windows.Forms.ColumnHeader();
			this.chProject = new System.Windows.Forms.ColumnHeader();
			this.chCustomer = new System.Windows.Forms.ColumnHeader();
			this.chSender = new System.Windows.Forms.ColumnHeader();
			this.gbxBiddingInfo = new System.Windows.Forms.GroupBox();
			this.lblTrackingID = new System.Windows.Forms.Label();
			this.lblTracking = new System.Windows.Forms.Label();
			this.lblDueDate = new System.Windows.Forms.Label();
			this.lblBidDue = new System.Windows.Forms.Label();
			this.lblDigitalPlans = new System.Windows.Forms.Label();
			this.pbxDigitalPlans = new System.Windows.Forms.PictureBox();
			this.lblMaterialsList = new System.Windows.Forms.Label();
			this.pbxMaterialsList = new System.Windows.Forms.PictureBox();
			this.lblContactCustomer = new System.Windows.Forms.Label();
			this.pbxContactCustomer = new System.Windows.Forms.PictureBox();
			this.lblPaperPlans = new System.Windows.Forms.Label();
			this.pbxPaperPlans = new System.Windows.Forms.PictureBox();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnNewQuote = new System.Windows.Forms.Button();
			this.btnNewNote = new System.Windows.Forms.Button();
			this.btnProject = new System.Windows.Forms.Button();
			this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tslAssignmentCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnReport = new System.Windows.Forms.Button();
			this.gbxBiddingInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxDigitalPlans)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxMaterialsList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxContactCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxPaperPlans)).BeginInit();
			this.pnlFooter.SuspendLayout();
			this.StatusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblNotes
			// 
			this.lblNotes.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblNotes.Location = new System.Drawing.Point(0, 74);
			this.lblNotes.Name = "lblNotes";
			this.lblNotes.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.lblNotes.Size = new System.Drawing.Size(550, 58);
			this.lblNotes.TabIndex = 12;
			this.lblNotes.Text = "Note: ";
			// 
			// lvwCrossLeads
			// 
			this.lvwCrossLeads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLeadID,
            this.chReceived,
            this.chProject,
            this.chCustomer,
            this.chSender});
			this.lvwCrossLeads.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwCrossLeads.FullRowSelect = true;
			this.lvwCrossLeads.HideSelection = false;
			this.lvwCrossLeads.Location = new System.Drawing.Point(0, 132);
			this.lvwCrossLeads.MultiSelect = false;
			this.lvwCrossLeads.Name = "lvwCrossLeads";
			this.lvwCrossLeads.Size = new System.Drawing.Size(550, 156);
			this.lvwCrossLeads.TabIndex = 11;
			this.lvwCrossLeads.UseCompatibleStateImageBehavior = false;
			this.lvwCrossLeads.View = System.Windows.Forms.View.Details;
			this.lvwCrossLeads.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwCrossLeads_ItemSelectionChanged);
			// 
			// chLeadID
			// 
			this.chLeadID.Text = "Lead ID";
			this.chLeadID.Width = 0;
			// 
			// chReceived
			// 
			this.chReceived.Text = "Received";
			this.chReceived.Width = 70;
			// 
			// chProject
			// 
			this.chProject.Text = "Project";
			this.chProject.Width = 175;
			// 
			// chCustomer
			// 
			this.chCustomer.Text = "Customer";
			this.chCustomer.Width = 175;
			// 
			// chSender
			// 
			this.chSender.Text = "Sender";
			this.chSender.Width = 125;
			// 
			// gbxBiddingInfo
			// 
			this.gbxBiddingInfo.Controls.Add(this.lblTrackingID);
			this.gbxBiddingInfo.Controls.Add(this.lblTracking);
			this.gbxBiddingInfo.Controls.Add(this.lblDueDate);
			this.gbxBiddingInfo.Controls.Add(this.lblBidDue);
			this.gbxBiddingInfo.Controls.Add(this.lblDigitalPlans);
			this.gbxBiddingInfo.Controls.Add(this.pbxDigitalPlans);
			this.gbxBiddingInfo.Controls.Add(this.lblMaterialsList);
			this.gbxBiddingInfo.Controls.Add(this.pbxMaterialsList);
			this.gbxBiddingInfo.Controls.Add(this.lblContactCustomer);
			this.gbxBiddingInfo.Controls.Add(this.pbxContactCustomer);
			this.gbxBiddingInfo.Controls.Add(this.lblPaperPlans);
			this.gbxBiddingInfo.Controls.Add(this.pbxPaperPlans);
			this.gbxBiddingInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxBiddingInfo.Location = new System.Drawing.Point(0, 0);
			this.gbxBiddingInfo.Name = "gbxBiddingInfo";
			this.gbxBiddingInfo.Size = new System.Drawing.Size(550, 74);
			this.gbxBiddingInfo.TabIndex = 10;
			this.gbxBiddingInfo.TabStop = false;
			this.gbxBiddingInfo.Text = "Bidding Information";
			// 
			// lblTrackingID
			// 
			this.lblTrackingID.BackColor = System.Drawing.Color.White;
			this.lblTrackingID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTrackingID.Location = new System.Drawing.Point(469, 45);
			this.lblTrackingID.Name = "lblTrackingID";
			this.lblTrackingID.Size = new System.Drawing.Size(75, 20);
			this.lblTrackingID.TabIndex = 16;
			this.lblTrackingID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTracking
			// 
			this.lblTracking.AutoSize = true;
			this.lblTracking.Location = new System.Drawing.Point(373, 49);
			this.lblTracking.Name = "lblTracking";
			this.lblTracking.Size = new System.Drawing.Size(90, 13);
			this.lblTracking.TabIndex = 15;
			this.lblTracking.Text = "Plan Tracking ID:";
			// 
			// lblDueDate
			// 
			this.lblDueDate.BackColor = System.Drawing.Color.White;
			this.lblDueDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDueDate.Location = new System.Drawing.Point(469, 16);
			this.lblDueDate.Name = "lblDueDate";
			this.lblDueDate.Size = new System.Drawing.Size(75, 20);
			this.lblDueDate.TabIndex = 12;
			this.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblBidDue
			// 
			this.lblBidDue.AutoSize = true;
			this.lblBidDue.Location = new System.Drawing.Point(400, 20);
			this.lblBidDue.Name = "lblBidDue";
			this.lblBidDue.Size = new System.Drawing.Size(63, 13);
			this.lblBidDue.TabIndex = 11;
			this.lblBidDue.Text = "Bid Due By:";
			// 
			// lblDigitalPlans
			// 
			this.lblDigitalPlans.AutoSize = true;
			this.lblDigitalPlans.Location = new System.Drawing.Point(35, 49);
			this.lblDigitalPlans.Name = "lblDigitalPlans";
			this.lblDigitalPlans.Size = new System.Drawing.Size(127, 13);
			this.lblDigitalPlans.TabIndex = 10;
			this.lblDigitalPlans.Text = "Digital plans are available";
			// 
			// pbxDigitalPlans
			// 
			this.pbxDigitalPlans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbxDigitalPlans.Location = new System.Drawing.Point(13, 47);
			this.pbxDigitalPlans.Name = "pbxDigitalPlans";
			this.pbxDigitalPlans.Padding = new System.Windows.Forms.Padding(1);
			this.pbxDigitalPlans.Size = new System.Drawing.Size(16, 16);
			this.pbxDigitalPlans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxDigitalPlans.TabIndex = 9;
			this.pbxDigitalPlans.TabStop = false;
			// 
			// lblMaterialsList
			// 
			this.lblMaterialsList.AutoSize = true;
			this.lblMaterialsList.Location = new System.Drawing.Point(201, 24);
			this.lblMaterialsList.Name = "lblMaterialsList";
			this.lblMaterialsList.Size = new System.Drawing.Size(130, 13);
			this.lblMaterialsList.TabIndex = 8;
			this.lblMaterialsList.Text = "A maiterials list is available";
			// 
			// pbxMaterialsList
			// 
			this.pbxMaterialsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbxMaterialsList.Location = new System.Drawing.Point(179, 22);
			this.pbxMaterialsList.Name = "pbxMaterialsList";
			this.pbxMaterialsList.Padding = new System.Windows.Forms.Padding(1);
			this.pbxMaterialsList.Size = new System.Drawing.Size(16, 16);
			this.pbxMaterialsList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxMaterialsList.TabIndex = 7;
			this.pbxMaterialsList.TabStop = false;
			// 
			// lblContactCustomer
			// 
			this.lblContactCustomer.AutoSize = true;
			this.lblContactCustomer.Location = new System.Drawing.Point(201, 49);
			this.lblContactCustomer.Name = "lblContactCustomer";
			this.lblContactCustomer.Size = new System.Drawing.Size(156, 13);
			this.lblContactCustomer.TabIndex = 6;
			this.lblContactCustomer.Text = "Contact the customer for details";
			// 
			// pbxContactCustomer
			// 
			this.pbxContactCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbxContactCustomer.Location = new System.Drawing.Point(179, 47);
			this.pbxContactCustomer.Name = "pbxContactCustomer";
			this.pbxContactCustomer.Padding = new System.Windows.Forms.Padding(1);
			this.pbxContactCustomer.Size = new System.Drawing.Size(16, 16);
			this.pbxContactCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxContactCustomer.TabIndex = 5;
			this.pbxContactCustomer.TabStop = false;
			// 
			// lblPaperPlans
			// 
			this.lblPaperPlans.AutoSize = true;
			this.lblPaperPlans.Location = new System.Drawing.Point(35, 24);
			this.lblPaperPlans.Name = "lblPaperPlans";
			this.lblPaperPlans.Size = new System.Drawing.Size(126, 13);
			this.lblPaperPlans.TabIndex = 4;
			this.lblPaperPlans.Text = "Paper plans are available";
			// 
			// pbxPaperPlans
			// 
			this.pbxPaperPlans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbxPaperPlans.Location = new System.Drawing.Point(13, 22);
			this.pbxPaperPlans.Name = "pbxPaperPlans";
			this.pbxPaperPlans.Padding = new System.Windows.Forms.Padding(1);
			this.pbxPaperPlans.Size = new System.Drawing.Size(16, 16);
			this.pbxPaperPlans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxPaperPlans.TabIndex = 0;
			this.pbxPaperPlans.TabStop = false;
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.btnReport);
			this.pnlFooter.Controls.Add(this.btnNewQuote);
			this.pnlFooter.Controls.Add(this.btnNewNote);
			this.pnlFooter.Controls.Add(this.btnProject);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 288);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(550, 50);
			this.pnlFooter.TabIndex = 8;
			// 
			// btnNewQuote
			// 
			this.btnNewQuote.Enabled = false;
			this.btnNewQuote.Image = global::rkcrm.Properties.Resources.New_Quote_icon16x16;
			this.btnNewQuote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNewQuote.Location = new System.Drawing.Point(450, 10);
			this.btnNewQuote.Name = "btnNewQuote";
			this.btnNewQuote.Size = new System.Drawing.Size(85, 30);
			this.btnNewQuote.TabIndex = 2;
			this.btnNewQuote.Text = "Add Quote";
			this.btnNewQuote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNewQuote.UseVisualStyleBackColor = true;
			this.btnNewQuote.Click += new System.EventHandler(this.btnNewQuote_Click);
			// 
			// btnNewNote
			// 
			this.btnNewNote.Enabled = false;
			this.btnNewNote.Image = global::rkcrm.Properties.Resources.New_Note_Icon16x16;
			this.btnNewNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNewNote.Location = new System.Drawing.Point(367, 10);
			this.btnNewNote.Name = "btnNewNote";
			this.btnNewNote.Size = new System.Drawing.Size(77, 30);
			this.btnNewNote.TabIndex = 1;
			this.btnNewNote.Text = "Add Note";
			this.btnNewNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNewNote.UseVisualStyleBackColor = true;
			this.btnNewNote.Click += new System.EventHandler(this.btnNewNote_Click);
			// 
			// btnProject
			// 
			this.btnProject.Enabled = false;
			this.btnProject.Image = global::rkcrm.Properties.Resources.Projects16x16;
			this.btnProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnProject.Location = new System.Drawing.Point(266, 10);
			this.btnProject.Name = "btnProject";
			this.btnProject.Size = new System.Drawing.Size(95, 30);
			this.btnProject.TabIndex = 0;
			this.btnProject.Text = "Go to Project";
			this.btnProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnProject.UseVisualStyleBackColor = true;
			this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
			// 
			// StatusStrip1
			// 
			this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslAssignmentCount});
			this.StatusStrip1.Location = new System.Drawing.Point(0, 338);
			this.StatusStrip1.Name = "StatusStrip1";
			this.StatusStrip1.Size = new System.Drawing.Size(550, 22);
			this.StatusStrip1.TabIndex = 9;
			this.StatusStrip1.Text = "StatusStrip1";
			// 
			// tslAssignmentCount
			// 
			this.tslAssignmentCount.Name = "tslAssignmentCount";
			this.tslAssignmentCount.Size = new System.Drawing.Size(140, 17);
			this.tslAssignmentCount.Text = "Cross Lead Assigments: 5";
			// 
			// btnReport
			// 
			this.btnReport.Enabled = false;
			this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnReport.Location = new System.Drawing.Point(13, 10);
			this.btnReport.Name = "btnReport";
			this.btnReport.Size = new System.Drawing.Size(111, 30);
			this.btnReport.TabIndex = 3;
			this.btnReport.Text = "Assignments Report";
			this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnReport.UseVisualStyleBackColor = true;
			// 
			// AssignmentReminders
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lvwCrossLeads);
			this.Controls.Add(this.lblNotes);
			this.Controls.Add(this.gbxBiddingInfo);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.StatusStrip1);
			this.Name = "AssignmentReminders";
			this.Size = new System.Drawing.Size(550, 360);
			this.Load += new System.EventHandler(this.AssignmentReminders_Load);
			this.gbxBiddingInfo.ResumeLayout(false);
			this.gbxBiddingInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxDigitalPlans)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxMaterialsList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxContactCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxPaperPlans)).EndInit();
			this.pnlFooter.ResumeLayout(false);
			this.StatusStrip1.ResumeLayout(false);
			this.StatusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ListView lvwCrossLeads;
        private System.Windows.Forms.ColumnHeader chLeadID;
        private System.Windows.Forms.ColumnHeader chReceived;
        private System.Windows.Forms.ColumnHeader chProject;
        private System.Windows.Forms.ColumnHeader chCustomer;
        private System.Windows.Forms.ColumnHeader chSender;
        private System.Windows.Forms.GroupBox gbxBiddingInfo;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblBidDue;
        private System.Windows.Forms.Label lblDigitalPlans;
        private System.Windows.Forms.PictureBox pbxDigitalPlans;
        private System.Windows.Forms.Label lblMaterialsList;
        private System.Windows.Forms.PictureBox pbxMaterialsList;
        private System.Windows.Forms.Label lblContactCustomer;
        private System.Windows.Forms.PictureBox pbxContactCustomer;
        private System.Windows.Forms.Label lblPaperPlans;
        private System.Windows.Forms.PictureBox pbxPaperPlans;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnNewQuote;
        private System.Windows.Forms.Button btnNewNote;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel tslAssignmentCount;
		private System.Windows.Forms.Label lblTrackingID;
		internal System.Windows.Forms.Label lblTracking;
		private System.Windows.Forms.Button btnReport;
    }
}
