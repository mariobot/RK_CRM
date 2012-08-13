namespace rkcrm.Objects.Project
{
	partial class SendCrossLead
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendCrossLead));
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnSend = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlLine = new System.Windows.Forms.Panel();
			this.pnlLineLeft = new System.Windows.Forms.Panel();
			this.pnlLineRight = new System.Windows.Forms.Panel();
			this.crossLeadControls = new rkcrm.Objects.Cross_Lead.CrossLeadBoundary();
			this.pnlFooter.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.pnlLine.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.pnlButtons);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 451);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(560, 50);
			this.pnlFooter.TabIndex = 0;
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnSend);
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButtons.Location = new System.Drawing.Point(384, 0);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(176, 50);
			this.pnlButtons.TabIndex = 4;
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(3, 10);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 30);
			this.btnSend.TabIndex = 2;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(84, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// pnlLine
			// 
			this.pnlLine.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlLine.Controls.Add(this.pnlLineLeft);
			this.pnlLine.Controls.Add(this.pnlLineRight);
			this.pnlLine.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlLine.Location = new System.Drawing.Point(0, 450);
			this.pnlLine.Name = "pnlLine";
			this.pnlLine.Size = new System.Drawing.Size(560, 1);
			this.pnlLine.TabIndex = 1;
			// 
			// pnlLineLeft
			// 
			this.pnlLineLeft.BackColor = System.Drawing.SystemColors.Control;
			this.pnlLineLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLineLeft.Location = new System.Drawing.Point(0, 0);
			this.pnlLineLeft.Name = "pnlLineLeft";
			this.pnlLineLeft.Size = new System.Drawing.Size(15, 1);
			this.pnlLineLeft.TabIndex = 3;
			// 
			// pnlLineRight
			// 
			this.pnlLineRight.BackColor = System.Drawing.SystemColors.Control;
			this.pnlLineRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlLineRight.Location = new System.Drawing.Point(545, 0);
			this.pnlLineRight.Name = "pnlLineRight";
			this.pnlLineRight.Size = new System.Drawing.Size(15, 1);
			this.pnlLineRight.TabIndex = 2;
			// 
			// crossLeadControls
			// 
			this.crossLeadControls.AutoScroll = true;
			this.crossLeadControls.BackColor = System.Drawing.Color.White;
			this.crossLeadControls.ChangeHistoryVisible = false;
			this.crossLeadControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crossLeadControls.Location = new System.Drawing.Point(0, 0);
			this.crossLeadControls.MinimumSize = new System.Drawing.Size(557, 451);
			this.crossLeadControls.MyCrossLead = null;
			this.crossLeadControls.MyProject = null;
			this.crossLeadControls.Name = "crossLeadControls";
			this.crossLeadControls.Size = new System.Drawing.Size(560, 501);
			this.crossLeadControls.TabIndex = 2;
			this.crossLeadControls.Title = "Cross Lead Notification";
			this.crossLeadControls.TitleBarVisible = true;
			this.crossLeadControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.crossLeadControls_IsDirtyChanged);
			// 
			// SendCrossLead
			// 
			this.AcceptButton = this.btnSend;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(560, 501);
			this.Controls.Add(this.pnlLine);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.crossLeadControls);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(576, 539);
			this.Name = "SendCrossLead";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Send Cross Lead";
			this.Load += new System.EventHandler(this.SendCrossLead_Load);
			this.pnlFooter.ResumeLayout(false);
			this.pnlButtons.ResumeLayout(false);
			this.pnlLine.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Panel pnlLine;
		private System.Windows.Forms.Panel pnlLineLeft;
		private System.Windows.Forms.Panel pnlLineRight;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Panel pnlButtons;
		internal rkcrm.Objects.Cross_Lead.CrossLeadBoundary crossLeadControls;
	}
}