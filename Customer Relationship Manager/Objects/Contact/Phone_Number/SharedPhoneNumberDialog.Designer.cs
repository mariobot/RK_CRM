namespace rkcrm.Objects.Contact.Phone_Number
{
	partial class SharedPhoneNumberDialog
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.lvwResults = new System.Windows.Forms.ListView();
			this.chCustomerName = new System.Windows.Forms.ColumnHeader();
			this.chContactName = new System.Windows.Forms.ColumnHeader();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnNo);
			this.panel2.Controls.Add(this.btnYes);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 192);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(485, 50);
			this.panel2.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.lblTitle.Size = new System.Drawing.Size(485, 60);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "The Following customers and/or contacts also use this phone number. Should the ph" +
				"one numbers for these customers and/or contacts be updated as well?";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnYes
			// 
			this.btnYes.Location = new System.Drawing.Point(317, 10);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(75, 30);
			this.btnYes.TabIndex = 0;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnNo
			// 
			this.btnNo.Location = new System.Drawing.Point(398, 10);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(75, 30);
			this.btnNo.TabIndex = 1;
			this.btnNo.Text = "Don\'t Know";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// lvwResults
			// 
			this.lvwResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCustomerName,
            this.chContactName});
			this.lvwResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwResults.FullRowSelect = true;
			this.lvwResults.HideSelection = false;
			this.lvwResults.Location = new System.Drawing.Point(0, 60);
			this.lvwResults.MultiSelect = false;
			this.lvwResults.Name = "lvwResults";
			this.lvwResults.Size = new System.Drawing.Size(485, 132);
			this.lvwResults.TabIndex = 8;
			this.lvwResults.UseCompatibleStateImageBehavior = false;
			this.lvwResults.View = System.Windows.Forms.View.Details;
			// 
			// chCustomerName
			// 
			this.chCustomerName.Text = "Customer Name";
			this.chCustomerName.Width = 200;
			// 
			// chContactName
			// 
			this.chContactName.Text = "Contact Name";
			this.chContactName.Width = 200;
			// 
			// SharedPhoneNumberDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 242);
			this.ControlBox = false;
			this.Controls.Add(this.lvwResults);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SharedPhoneNumberDialog";
			this.Text = "Shared Phone Number Dialog";
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnYes;
		public System.Windows.Forms.ListView lvwResults;
		private System.Windows.Forms.ColumnHeader chCustomerName;
		private System.Windows.Forms.ColumnHeader chContactName;

	}
}