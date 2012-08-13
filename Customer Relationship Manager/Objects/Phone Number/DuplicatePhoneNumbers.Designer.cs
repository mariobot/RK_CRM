namespace rkcrm.Objects.Phone_Number
{
	partial class DuplicatePhoneNumbers
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicatePhoneNumbers));
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lvwOwners = new System.Windows.Forms.ListView();
			this.chCustomer = new System.Windows.Forms.ColumnHeader();
			this.chContact = new System.Windows.Forms.ColumnHeader();
			this.pnlFooter.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 6, 0);
			this.lblTitle.Size = new System.Drawing.Size(479, 50);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "The phone number, xxx-xxx-xxxx, already exists on the following customer(s)/conta" +
				"ct(s). Do you want to continue?";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.btnCancel);
			this.pnlFooter.Controls.Add(this.btnOK);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 187);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(479, 50);
			this.pnlFooter.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(392, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "No";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(311, 10);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 30);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "Yes";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lvwOwners
			// 
			this.lvwOwners.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCustomer,
            this.chContact});
			this.lvwOwners.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwOwners.Location = new System.Drawing.Point(0, 50);
			this.lvwOwners.MultiSelect = false;
			this.lvwOwners.Name = "lvwOwners";
			this.lvwOwners.Size = new System.Drawing.Size(479, 137);
			this.lvwOwners.TabIndex = 2;
			this.lvwOwners.UseCompatibleStateImageBehavior = false;
			this.lvwOwners.View = System.Windows.Forms.View.Details;
			// 
			// chCustomer
			// 
			this.chCustomer.Text = "Customer";
			this.chCustomer.Width = 200;
			// 
			// chContact
			// 
			this.chContact.Text = "Contact";
			this.chContact.Width = 200;
			// 
			// DuplicatePhoneNumbers
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(479, 237);
			this.Controls.Add(this.lvwOwners);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.lblTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DuplicatePhoneNumbers";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Duplicate Phone Numbers";
			this.pnlFooter.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ListView lvwOwners;
		private System.Windows.Forms.ColumnHeader chCustomer;
		private System.Windows.Forms.ColumnHeader chContact;
		private System.Windows.Forms.Button btnCancel;
	}
}