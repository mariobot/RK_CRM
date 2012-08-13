namespace rkcrm.Objects.Quote
{
	partial class QuoteSelect
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuoteSelect));
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lvwQuotes = new System.Windows.Forms.ListView();
			this.chQuoteID = new System.Windows.Forms.ColumnHeader();
			this.chDepartmentID = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chNumber = new System.Windows.Forms.ColumnHeader();
			this.chAmount = new System.Windows.Forms.ColumnHeader();
			this.chDescription = new System.Windows.Forms.ColumnHeader();
			this.chSalesRep = new System.Windows.Forms.ColumnHeader();
			this.pnlFooter.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.btnCancel);
			this.pnlFooter.Controls.Add(this.btnSelect);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 212);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(651, 50);
			this.pnlFooter.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(564, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.Location = new System.Drawing.Point(483, 10);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(75, 30);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
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
			this.lblTitle.Size = new System.Drawing.Size(651, 50);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Please select a quote.";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lvwQuotes
			// 
			this.lvwQuotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQuoteID,
            this.chDepartmentID,
            this.chDepartment,
            this.chNumber,
            this.chAmount,
            this.chDescription,
            this.chSalesRep});
			this.lvwQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwQuotes.FullRowSelect = true;
			this.lvwQuotes.HideSelection = false;
			this.lvwQuotes.Location = new System.Drawing.Point(0, 50);
			this.lvwQuotes.MultiSelect = false;
			this.lvwQuotes.Name = "lvwQuotes";
			this.lvwQuotes.Size = new System.Drawing.Size(651, 162);
			this.lvwQuotes.TabIndex = 2;
			this.lvwQuotes.UseCompatibleStateImageBehavior = false;
			this.lvwQuotes.View = System.Windows.Forms.View.Details;
			// 
			// chQuoteID
			// 
			this.chQuoteID.Text = "Quote ID";
			this.chQuoteID.Width = 0;
			// 
			// chDepartmentID
			// 
			this.chDepartmentID.Text = "Department ID";
			this.chDepartmentID.Width = 0;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 80;
			// 
			// chNumber
			// 
			this.chNumber.Text = "Quote Number";
			this.chNumber.Width = 150;
			// 
			// chAmount
			// 
			this.chAmount.Text = "Amount";
			this.chAmount.Width = 80;
			// 
			// chDescription
			// 
			this.chDescription.Text = "Description";
			this.chDescription.Width = 200;
			// 
			// chSalesRep
			// 
			this.chSalesRep.Text = "Sales Rep";
			this.chSalesRep.Width = 125;
			// 
			// QuoteSelect
			// 
			this.AcceptButton = this.btnSelect;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(651, 262);
			this.Controls.Add(this.lvwQuotes);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.pnlFooter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuoteSelect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select a Quote";
			this.pnlFooter.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListView lvwQuotes;
		private System.Windows.Forms.ColumnHeader chQuoteID;
		private System.Windows.Forms.ColumnHeader chDepartmentID;
		private System.Windows.Forms.ColumnHeader chDepartment;
		private System.Windows.Forms.ColumnHeader chNumber;
		private System.Windows.Forms.ColumnHeader chAmount;
		private System.Windows.Forms.ColumnHeader chDescription;
		private System.Windows.Forms.ColumnHeader chSalesRep;
	}
}