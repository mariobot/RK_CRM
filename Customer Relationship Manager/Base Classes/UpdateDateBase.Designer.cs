namespace rkcrm.Base_Classes
{
	partial class UpdateDateBase
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
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlLine = new System.Windows.Forms.Panel();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblCustomer = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.DlblCustomer = new System.Windows.Forms.Label();
			this.mtxtDate = new System.Windows.Forms.MaskedTextBox();
			this.pnlHeader.SuspendLayout();
			this.pnlFooter.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(334, 50);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(12, 16);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(73, 18);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Edit Date";
			// 
			// pnlLine
			// 
			this.pnlLine.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlLine.Location = new System.Drawing.Point(15, 174);
			this.pnlLine.Name = "pnlLine";
			this.pnlLine.Size = new System.Drawing.Size(333, 1);
			this.pnlLine.TabIndex = 1;
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.pnlButtons);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 142);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(334, 50);
			this.pnlFooter.TabIndex = 2;
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnOK);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButtons.Location = new System.Drawing.Point(158, 0);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(176, 50);
			this.pnlButtons.TabIndex = 3;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(89, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(8, 10);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 30);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// lblCustomer
			// 
			this.lblCustomer.AutoSize = true;
			this.lblCustomer.Location = new System.Drawing.Point(31, 68);
			this.lblCustomer.Name = "lblCustomer";
			this.lblCustomer.Size = new System.Drawing.Size(57, 13);
			this.lblCustomer.TabIndex = 3;
			this.lblCustomer.Text = "Customer: ";
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.Location = new System.Drawing.Point(15, 100);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(73, 13);
			this.lblDate.TabIndex = 4;
			this.lblDate.Text = "Current Date: ";
			// 
			// DlblCustomer
			// 
			this.DlblCustomer.BackColor = System.Drawing.Color.White;
			this.DlblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.DlblCustomer.Location = new System.Drawing.Point(94, 64);
			this.DlblCustomer.Name = "DlblCustomer";
			this.DlblCustomer.Size = new System.Drawing.Size(229, 20);
			this.DlblCustomer.TabIndex = 6;
			this.DlblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mtxtDate
			// 
			this.mtxtDate.Location = new System.Drawing.Point(94, 97);
			this.mtxtDate.Mask = "00/00/0000";
			this.mtxtDate.Name = "mtxtDate";
			this.mtxtDate.Size = new System.Drawing.Size(77, 20);
			this.mtxtDate.TabIndex = 7;
			this.mtxtDate.ValidatingType = typeof(System.DateTime);
			this.mtxtDate.TextChanged += new System.EventHandler(this.mtxtDate_TextChanged);
			// 
			// UpdateDateBase
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(334, 192);
			this.Controls.Add(this.mtxtDate);
			this.Controls.Add(this.DlblCustomer);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.lblCustomer);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.pnlLine);
			this.Controls.Add(this.pnlHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "UpdateDateBase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Update Date";
			this.Load += new System.EventHandler(this.UpdateDateBase_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlFooter.ResumeLayout(false);
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel pnlLine;
		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Label lblCustomer;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label DlblCustomer;
		private System.Windows.Forms.Panel pnlButtons;
		private System.Windows.Forms.MaskedTextBox mtxtDate;
		public System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}