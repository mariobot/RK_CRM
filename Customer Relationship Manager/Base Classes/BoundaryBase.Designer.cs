namespace rkcrm.Base_Classes
{
	partial class BoundaryBase
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
			this.pnlControls = new System.Windows.Forms.Panel();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlHistory = new System.Windows.Forms.Panel();
			this.DlblCreated = new System.Windows.Forms.Label();
			this.lblUpdatedBy = new System.Windows.Forms.Label();
			this.lblCreated = new System.Windows.Forms.Label();
			this.DlblUpdatedBy = new System.Windows.Forms.Label();
			this.DlblCreatedBy = new System.Windows.Forms.Label();
			this.lblUpdated = new System.Windows.Forms.Label();
			this.lblCreatedBy = new System.Windows.Forms.Label();
			this.DlblUpdated = new System.Windows.Forms.Label();
			this.pnlHeader.SuspendLayout();
			this.pnlHistory.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.AutoScroll = true;
			this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlControls.Location = new System.Drawing.Point(0, 50);
			this.pnlControls.Name = "pnlControls";
			this.pnlControls.Size = new System.Drawing.Size(600, 207);
			this.pnlControls.TabIndex = 1;
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlHeader.BackgroundImage = global::rkcrm.Properties.Resources.BoundaryTitleBar;
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Controls.Add(this.pnlHistory);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(600, 50);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(10, 15);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(41, 19);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Title";
			// 
			// pnlHistory
			// 
			this.pnlHistory.BackColor = System.Drawing.Color.Transparent;
			this.pnlHistory.Controls.Add(this.DlblCreated);
			this.pnlHistory.Controls.Add(this.lblUpdatedBy);
			this.pnlHistory.Controls.Add(this.lblCreated);
			this.pnlHistory.Controls.Add(this.DlblUpdatedBy);
			this.pnlHistory.Controls.Add(this.DlblCreatedBy);
			this.pnlHistory.Controls.Add(this.lblUpdated);
			this.pnlHistory.Controls.Add(this.lblCreatedBy);
			this.pnlHistory.Controls.Add(this.DlblUpdated);
			this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlHistory.Location = new System.Drawing.Point(206, 0);
			this.pnlHistory.Name = "pnlHistory";
			this.pnlHistory.Size = new System.Drawing.Size(394, 50);
			this.pnlHistory.TabIndex = 0;
			// 
			// DlblCreated
			// 
			this.DlblCreated.BackColor = System.Drawing.Color.White;
			this.DlblCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DlblCreated.Location = new System.Drawing.Point(6, 24);
			this.DlblCreated.Name = "DlblCreated";
			this.DlblCreated.Size = new System.Drawing.Size(120, 20);
			this.DlblCreated.TabIndex = 17;
			this.DlblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUpdatedBy
			// 
			this.lblUpdatedBy.AutoSize = true;
			this.lblUpdatedBy.BackColor = System.Drawing.Color.Transparent;
			this.lblUpdatedBy.ForeColor = System.Drawing.Color.White;
			this.lblUpdatedBy.Location = new System.Drawing.Point(324, 7);
			this.lblUpdatedBy.Name = "lblUpdatedBy";
			this.lblUpdatedBy.Size = new System.Drawing.Size(63, 13);
			this.lblUpdatedBy.TabIndex = 24;
			this.lblUpdatedBy.Text = "Updated By";
			// 
			// lblCreated
			// 
			this.lblCreated.AutoSize = true;
			this.lblCreated.BackColor = System.Drawing.Color.Transparent;
			this.lblCreated.ForeColor = System.Drawing.Color.White;
			this.lblCreated.Location = new System.Drawing.Point(6, 7);
			this.lblCreated.Name = "lblCreated";
			this.lblCreated.Size = new System.Drawing.Size(44, 13);
			this.lblCreated.TabIndex = 18;
			this.lblCreated.Text = "Created";
			// 
			// DlblUpdatedBy
			// 
			this.DlblUpdatedBy.BackColor = System.Drawing.Color.White;
			this.DlblUpdatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DlblUpdatedBy.Location = new System.Drawing.Point(324, 24);
			this.DlblUpdatedBy.Name = "DlblUpdatedBy";
			this.DlblUpdatedBy.Size = new System.Drawing.Size(60, 20);
			this.DlblUpdatedBy.TabIndex = 23;
			this.DlblUpdatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DlblCreatedBy
			// 
			this.DlblCreatedBy.BackColor = System.Drawing.Color.White;
			this.DlblCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DlblCreatedBy.Location = new System.Drawing.Point(132, 24);
			this.DlblCreatedBy.Name = "DlblCreatedBy";
			this.DlblCreatedBy.Size = new System.Drawing.Size(60, 20);
			this.DlblCreatedBy.TabIndex = 19;
			this.DlblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUpdated
			// 
			this.lblUpdated.AutoSize = true;
			this.lblUpdated.BackColor = System.Drawing.Color.Transparent;
			this.lblUpdated.ForeColor = System.Drawing.Color.White;
			this.lblUpdated.Location = new System.Drawing.Point(198, 7);
			this.lblUpdated.Name = "lblUpdated";
			this.lblUpdated.Size = new System.Drawing.Size(48, 13);
			this.lblUpdated.TabIndex = 22;
			this.lblUpdated.Text = "Updated";
			// 
			// lblCreatedBy
			// 
			this.lblCreatedBy.AutoSize = true;
			this.lblCreatedBy.BackColor = System.Drawing.Color.Transparent;
			this.lblCreatedBy.ForeColor = System.Drawing.Color.White;
			this.lblCreatedBy.Location = new System.Drawing.Point(132, 7);
			this.lblCreatedBy.Name = "lblCreatedBy";
			this.lblCreatedBy.Size = new System.Drawing.Size(59, 13);
			this.lblCreatedBy.TabIndex = 20;
			this.lblCreatedBy.Text = "Created By";
			// 
			// DlblUpdated
			// 
			this.DlblUpdated.BackColor = System.Drawing.Color.White;
			this.DlblUpdated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DlblUpdated.Location = new System.Drawing.Point(198, 24);
			this.DlblUpdated.Name = "DlblUpdated";
			this.DlblUpdated.Size = new System.Drawing.Size(120, 20);
			this.DlblUpdated.TabIndex = 21;
			this.DlblUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BoundaryBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.pnlControls);
			this.Controls.Add(this.pnlHeader);
			this.Name = "BoundaryBase";
			this.Size = new System.Drawing.Size(600, 257);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlHistory.ResumeLayout(false);
			this.pnlHistory.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel pnlHistory;
		private System.Windows.Forms.Label lblTitle;
		internal System.Windows.Forms.Label DlblCreated;
		internal System.Windows.Forms.Label lblUpdatedBy;
		internal System.Windows.Forms.Label lblCreated;
		internal System.Windows.Forms.Label DlblUpdatedBy;
		internal System.Windows.Forms.Label DlblCreatedBy;
		internal System.Windows.Forms.Label lblUpdated;
		internal System.Windows.Forms.Label lblCreatedBy;
        internal System.Windows.Forms.Label DlblUpdated;
        private System.Windows.Forms.Panel pnlHeader;
        protected System.Windows.Forms.Panel pnlControls;
	}
}
