namespace rkcrm.Reminder_Module
{
    partial class RemindersForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindersForm));
			this.tbcMain = new System.Windows.Forms.TabControl();
			this.tcpNotes = new System.Windows.Forms.TabPage();
			this.followUpReminders1 = new rkcrm.Reminder_Module.FollowUpReminders();
			this.tcpCrossLeads = new System.Windows.Forms.TabPage();
			this.assignmentReminders1 = new rkcrm.Reminder_Module.AssignmentReminders();
			this.imlTab = new System.Windows.Forms.ImageList(this.components);
			this.tbcMain.SuspendLayout();
			this.tcpNotes.SuspendLayout();
			this.tcpCrossLeads.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbcMain
			// 
			this.tbcMain.Controls.Add(this.tcpNotes);
			this.tbcMain.Controls.Add(this.tcpCrossLeads);
			this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbcMain.ImageList = this.imlTab;
			this.tbcMain.Location = new System.Drawing.Point(0, 0);
			this.tbcMain.Name = "tbcMain";
			this.tbcMain.SelectedIndex = 0;
			this.tbcMain.Size = new System.Drawing.Size(564, 392);
			this.tbcMain.TabIndex = 0;
			// 
			// tcpNotes
			// 
			this.tcpNotes.Controls.Add(this.followUpReminders1);
			this.tcpNotes.ImageIndex = 1;
			this.tcpNotes.Location = new System.Drawing.Point(4, 23);
			this.tcpNotes.Name = "tcpNotes";
			this.tcpNotes.Padding = new System.Windows.Forms.Padding(3);
			this.tcpNotes.Size = new System.Drawing.Size(556, 365);
			this.tcpNotes.TabIndex = 0;
			this.tcpNotes.Text = "Notes - 0";
			this.tcpNotes.UseVisualStyleBackColor = true;
			// 
			// followUpReminders1
			// 
			this.followUpReminders1.BackColor = System.Drawing.SystemColors.Control;
			this.followUpReminders1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.followUpReminders1.Location = new System.Drawing.Point(3, 3);
			this.followUpReminders1.Name = "followUpReminders1";
			this.followUpReminders1.Size = new System.Drawing.Size(550, 359);
			this.followUpReminders1.TabIndex = 0;
			// 
			// tcpCrossLeads
			// 
			this.tcpCrossLeads.Controls.Add(this.assignmentReminders1);
			this.tcpCrossLeads.ImageIndex = 0;
			this.tcpCrossLeads.Location = new System.Drawing.Point(4, 23);
			this.tcpCrossLeads.Name = "tcpCrossLeads";
			this.tcpCrossLeads.Padding = new System.Windows.Forms.Padding(3);
			this.tcpCrossLeads.Size = new System.Drawing.Size(556, 365);
			this.tcpCrossLeads.TabIndex = 1;
			this.tcpCrossLeads.Text = "Cross Leads - 0";
			this.tcpCrossLeads.UseVisualStyleBackColor = true;
			// 
			// assignmentReminders1
			// 
			this.assignmentReminders1.BackColor = System.Drawing.SystemColors.Control;
			this.assignmentReminders1.ContactCustomer = false;
			this.assignmentReminders1.DigitalPlansAvailable = false;
			this.assignmentReminders1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.assignmentReminders1.DueDate = "";
			this.assignmentReminders1.HasMaterialsList = false;
			this.assignmentReminders1.Location = new System.Drawing.Point(3, 3);
			this.assignmentReminders1.Name = "assignmentReminders1";
			this.assignmentReminders1.Note = " ";
			this.assignmentReminders1.PaperPlansAvailable = false;
			this.assignmentReminders1.Size = new System.Drawing.Size(550, 359);
			this.assignmentReminders1.TabIndex = 0;
			this.assignmentReminders1.TrackingID = "";
			// 
			// imlTab
			// 
			this.imlTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTab.ImageStream")));
			this.imlTab.TransparentColor = System.Drawing.Color.Transparent;
			this.imlTab.Images.SetKeyName(0, "Notify_Icon.png");
			this.imlTab.Images.SetKeyName(1, "Note16x16.png");
			// 
			// RemindersForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 392);
			this.Controls.Add(this.tbcMain);
			this.MinimumSize = new System.Drawing.Size(580, 430);
			this.Name = "RemindersForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CRM Reminders";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemindersForm_FormClosing);
			this.tbcMain.ResumeLayout(false);
			this.tcpNotes.ResumeLayout(false);
			this.tcpCrossLeads.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tcpNotes;
        private System.Windows.Forms.TabPage tcpCrossLeads;
        private System.Windows.Forms.ImageList imlTab;
        private FollowUpReminders followUpReminders1;
        private AssignmentReminders assignmentReminders1;
    }
}