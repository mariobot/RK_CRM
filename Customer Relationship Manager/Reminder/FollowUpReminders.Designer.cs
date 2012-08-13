namespace rkcrm.Reminder_Module
{
    partial class FollowUpReminders
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
			this.pnlSpacer = new System.Windows.Forms.Panel();
			this.btnShow = new System.Windows.Forms.Button();
			this.lvwNotesList = new System.Windows.Forms.ListView();
			this.chNoteID = new System.Windows.Forms.ColumnHeader();
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.chFollowUpDate = new System.Windows.Forms.ColumnHeader();
			this.chCompanyName = new System.Windows.Forms.ColumnHeader();
			this.chPhoneNumber = new System.Windows.Forms.ColumnHeader();
			this.chProjectName = new System.Windows.Forms.ColumnHeader();
			this.cmsNotes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnProject = new System.Windows.Forms.Button();
			this.btnFollowUpReport = new System.Windows.Forms.Button();
			this.btnFollowUp = new System.Windows.Forms.Button();
			this.btnNote = new System.Windows.Forms.Button();
			this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tslActiveCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.tslOverdueCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblNotes = new System.Windows.Forms.Label();
			this.lblContacted = new System.Windows.Forms.Label();
			this.lblPurpose = new System.Windows.Forms.Label();
			this.DlblNotes = new System.Windows.Forms.Label();
			this.DlblContacted = new System.Windows.Forms.Label();
			this.DlblPurpose = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.imgNote = new System.Windows.Forms.PictureBox();
			this.chCustomerID = new System.Windows.Forms.ColumnHeader();
			this.pnlSpacer.SuspendLayout();
			this.pnlFooter.SuspendLayout();
			this.StatusStrip1.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgNote)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlSpacer
			// 
			this.pnlSpacer.Controls.Add(this.btnShow);
			this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlSpacer.Location = new System.Drawing.Point(0, 245);
			this.pnlSpacer.Name = "pnlSpacer";
			this.pnlSpacer.Size = new System.Drawing.Size(550, 45);
			this.pnlSpacer.TabIndex = 14;
			// 
			// btnShow
			// 
			this.btnShow.Location = new System.Drawing.Point(27, 8);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(89, 23);
			this.btnShow.TabIndex = 0;
			this.btnShow.Text = "Show All Notes";
			this.btnShow.UseVisualStyleBackColor = true;
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// lvwNotesList
			// 
			this.lvwNotesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNoteID,
            this.chProjectID,
            this.chCustomerID,
            this.chFollowUpDate,
            this.chCompanyName,
            this.chPhoneNumber,
            this.chProjectName});
			this.lvwNotesList.ContextMenuStrip = this.cmsNotes;
			this.lvwNotesList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwNotesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvwNotesList.FullRowSelect = true;
			this.lvwNotesList.HideSelection = false;
			this.lvwNotesList.Location = new System.Drawing.Point(0, 99);
			this.lvwNotesList.MultiSelect = false;
			this.lvwNotesList.Name = "lvwNotesList";
			this.lvwNotesList.Size = new System.Drawing.Size(550, 146);
			this.lvwNotesList.TabIndex = 13;
			this.lvwNotesList.UseCompatibleStateImageBehavior = false;
			this.lvwNotesList.View = System.Windows.Forms.View.Details;
			this.lvwNotesList.DoubleClick += new System.EventHandler(this.lvwNotesList_DoubleClick);
			this.lvwNotesList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwNotesList_ItemSelectionChanged);
			// 
			// chNoteID
			// 
			this.chNoteID.Text = "Note ID";
			this.chNoteID.Width = 0;
			// 
			// chProjectID
			// 
			this.chProjectID.Width = 0;
			// 
			// chFollowUpDate
			// 
			this.chFollowUpDate.Text = "Follow Up Date";
			this.chFollowUpDate.Width = 85;
			// 
			// chCompanyName
			// 
			this.chCompanyName.Text = "Company Name";
			this.chCompanyName.Width = 180;
			// 
			// chPhoneNumber
			// 
			this.chPhoneNumber.Text = "Phone Number";
			this.chPhoneNumber.Width = 85;
			// 
			// chProjectName
			// 
			this.chProjectName.Text = "Project Name";
			this.chProjectName.Width = 180;
			// 
			// cmsNotes
			// 
			this.cmsNotes.Name = "cmsNotes";
			this.cmsNotes.Size = new System.Drawing.Size(61, 4);
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.btnProject);
			this.pnlFooter.Controls.Add(this.btnFollowUpReport);
			this.pnlFooter.Controls.Add(this.btnFollowUp);
			this.pnlFooter.Controls.Add(this.btnNote);
			this.pnlFooter.Controls.Add(this.StatusStrip1);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 290);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(550, 70);
			this.pnlFooter.TabIndex = 12;
			// 
			// btnProject
			// 
			this.btnProject.Enabled = false;
			this.btnProject.Image = global::rkcrm.Properties.Resources.Projects16x16;
			this.btnProject.Location = new System.Drawing.Point(244, 10);
			this.btnProject.Name = "btnProject";
			this.btnProject.Size = new System.Drawing.Size(94, 30);
			this.btnProject.TabIndex = 4;
			this.btnProject.Text = "Goto Project";
			this.btnProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnProject.UseVisualStyleBackColor = true;
			this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
			// 
			// btnFollowUpReport
			// 
			this.btnFollowUpReport.Location = new System.Drawing.Point(12, 10);
			this.btnFollowUpReport.Name = "btnFollowUpReport";
			this.btnFollowUpReport.Size = new System.Drawing.Size(100, 30);
			this.btnFollowUpReport.TabIndex = 3;
			this.btnFollowUpReport.Text = "Follow Up Report";
			this.btnFollowUpReport.UseVisualStyleBackColor = true;
			this.btnFollowUpReport.Click += new System.EventHandler(this.btnFollowUpReport_Click);
			// 
			// btnFollowUp
			// 
			this.btnFollowUp.Enabled = false;
			this.btnFollowUp.Image = global::rkcrm.Properties.Resources.Follow_Up16x16;
			this.btnFollowUp.Location = new System.Drawing.Point(446, 10);
			this.btnFollowUp.Name = "btnFollowUp";
			this.btnFollowUp.Size = new System.Drawing.Size(96, 30);
			this.btnFollowUp.TabIndex = 2;
			this.btnFollowUp.Text = "&Follow Up";
			this.btnFollowUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFollowUp.UseVisualStyleBackColor = true;
			this.btnFollowUp.Click += new System.EventHandler(this.btnFollowUp_Click);
			// 
			// btnNote
			// 
			this.btnNote.Enabled = false;
			this.btnNote.Image = global::rkcrm.Properties.Resources.Note16x16;
			this.btnNote.Location = new System.Drawing.Point(344, 10);
			this.btnNote.Name = "btnNote";
			this.btnNote.Size = new System.Drawing.Size(96, 30);
			this.btnNote.TabIndex = 1;
			this.btnNote.Text = "&Open Note";
			this.btnNote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnNote.UseVisualStyleBackColor = true;
			this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
			// 
			// StatusStrip1
			// 
			this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslActiveCount,
            this.tslOverdueCount});
			this.StatusStrip1.Location = new System.Drawing.Point(0, 48);
			this.StatusStrip1.Name = "StatusStrip1";
			this.StatusStrip1.Size = new System.Drawing.Size(550, 22);
			this.StatusStrip1.SizingGrip = false;
			this.StatusStrip1.TabIndex = 0;
			this.StatusStrip1.Text = "StatusStrip1";
			// 
			// tslActiveCount
			// 
			this.tslActiveCount.Margin = new System.Windows.Forms.Padding(0, 3, 60, 2);
			this.tslActiveCount.Name = "tslActiveCount";
			this.tslActiveCount.Size = new System.Drawing.Size(147, 17);
			this.tslActiveCount.Text = "Number of Active Notes: 0";
			// 
			// tslOverdueCount
			// 
			this.tslOverdueCount.Name = "tslOverdueCount";
			this.tslOverdueCount.Size = new System.Drawing.Size(159, 17);
			this.tslOverdueCount.Text = "Number of Overdue Notes: 0";
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.lblNotes);
			this.pnlHeader.Controls.Add(this.lblContacted);
			this.pnlHeader.Controls.Add(this.lblPurpose);
			this.pnlHeader.Controls.Add(this.DlblNotes);
			this.pnlHeader.Controls.Add(this.DlblContacted);
			this.pnlHeader.Controls.Add(this.DlblPurpose);
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Controls.Add(this.imgNote);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(550, 99);
			this.pnlHeader.TabIndex = 11;
			// 
			// lblNotes
			// 
			this.lblNotes.AutoSize = true;
			this.lblNotes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNotes.Location = new System.Drawing.Point(12, 59);
			this.lblNotes.Name = "lblNotes";
			this.lblNotes.Size = new System.Drawing.Size(42, 14);
			this.lblNotes.TabIndex = 14;
			this.lblNotes.Text = "Notes:";
			// 
			// lblContacted
			// 
			this.lblContacted.AutoSize = true;
			this.lblContacted.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContacted.Location = new System.Drawing.Point(12, 41);
			this.lblContacted.Name = "lblContacted";
			this.lblContacted.Size = new System.Drawing.Size(52, 14);
			this.lblContacted.TabIndex = 12;
			this.lblContacted.Text = "Contact:";
			// 
			// lblPurpose
			// 
			this.lblPurpose.AutoSize = true;
			this.lblPurpose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPurpose.Location = new System.Drawing.Point(325, 41);
			this.lblPurpose.Name = "lblPurpose";
			this.lblPurpose.Size = new System.Drawing.Size(57, 14);
			this.lblPurpose.TabIndex = 11;
			this.lblPurpose.Text = "Purpose:";
			// 
			// DlblNotes
			// 
			this.DlblNotes.Location = new System.Drawing.Point(51, 59);
			this.DlblNotes.Name = "DlblNotes";
			this.DlblNotes.Size = new System.Drawing.Size(476, 37);
			this.DlblNotes.TabIndex = 8;
			this.DlblNotes.Tag = " ";
			this.DlblNotes.Text = "Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah ." +
				"..";
			// 
			// DlblContacted
			// 
			this.DlblContacted.AutoSize = true;
			this.DlblContacted.Location = new System.Drawing.Point(60, 41);
			this.DlblContacted.Name = "DlblContacted";
			this.DlblContacted.Size = new System.Drawing.Size(177, 13);
			this.DlblContacted.TabIndex = 7;
			this.DlblContacted.Text = "LYNDON/KATHLEEN LEONARDO";
			// 
			// DlblPurpose
			// 
			this.DlblPurpose.AutoSize = true;
			this.DlblPurpose.Location = new System.Drawing.Point(381, 41);
			this.DlblPurpose.Name = "DlblPurpose";
			this.DlblPurpose.Size = new System.Drawing.Size(146, 13);
			this.DlblPurpose.TabIndex = 6;
			this.DlblPurpose.Text = "CONFIRM ORDER DETAILS";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(36, 14);
			this.lblTitle.MaximumSize = new System.Drawing.Size(490, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(382, 13);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Wednesday, September 30, 2009 - Company Name - Project Name";
			// 
			// imgNote
			// 
			this.imgNote.Image = global::rkcrm.Properties.Resources.Edit_Note_28x28;
			this.imgNote.Location = new System.Drawing.Point(8, 5);
			this.imgNote.Name = "imgNote";
			this.imgNote.Size = new System.Drawing.Size(28, 28);
			this.imgNote.TabIndex = 0;
			this.imgNote.TabStop = false;
			// 
			// chCustomerID
			// 
			this.chCustomerID.Width = 0;
			// 
			// FollowUpReminders
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lvwNotesList);
			this.Controls.Add(this.pnlSpacer);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.pnlHeader);
			this.Name = "FollowUpReminders";
			this.Size = new System.Drawing.Size(550, 360);
			this.Load += new System.EventHandler(this.FollowUpReminders_Load);
			this.pnlSpacer.ResumeLayout(false);
			this.pnlFooter.ResumeLayout(false);
			this.pnlFooter.PerformLayout();
			this.StatusStrip1.ResumeLayout(false);
			this.StatusStrip1.PerformLayout();
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgNote)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSpacer;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ListView lvwNotesList;
        internal System.Windows.Forms.ColumnHeader chNoteID;
        internal System.Windows.Forms.ColumnHeader chFollowUpDate;
        internal System.Windows.Forms.ColumnHeader chCompanyName;
        internal System.Windows.Forms.ColumnHeader chPhoneNumber;
        internal System.Windows.Forms.ColumnHeader chProjectName;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.Button btnFollowUpReport;
        private System.Windows.Forms.Button btnFollowUp;
        private System.Windows.Forms.Button btnNote;
        private System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel tslActiveCount;
        internal System.Windows.Forms.ToolStripStatusLabel tslOverdueCount;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblContacted;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.Label DlblNotes;
        private System.Windows.Forms.Label DlblContacted;
        private System.Windows.Forms.Label DlblPurpose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox imgNote;
		private System.Windows.Forms.ContextMenuStrip cmsNotes;
		private System.Windows.Forms.ColumnHeader chProjectID;
		private System.Windows.Forms.ColumnHeader chCustomerID;
    }
}
