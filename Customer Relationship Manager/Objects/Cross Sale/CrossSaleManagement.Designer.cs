namespace rkcrm.Objects.Cross_Sale
{
	partial class CrossSaleManagement
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
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.chkNoCrossLead = new System.Windows.Forms.CheckBox();
			this.myScreen = new rkcrm.Objects.Cross_Sale.CrossSaleScreen();
			this.pnlFooter.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlFooter
			// 
			this.pnlFooter.BackColor = System.Drawing.SystemColors.Control;
			this.pnlFooter.Controls.Add(this.chkNoCrossLead);
			this.pnlFooter.Controls.Add(this.pnlButtons);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 413);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(661, 50);
			this.pnlFooter.TabIndex = 0;
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnClose);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButtons.Location = new System.Drawing.Point(461, 0);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(200, 50);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(113, 10);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 30);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// chkNoCrossLead
			// 
			this.chkNoCrossLead.AutoSize = true;
			this.chkNoCrossLead.Location = new System.Drawing.Point(12, 18);
			this.chkNoCrossLead.Name = "chkNoCrossLead";
			this.chkNoCrossLead.Size = new System.Drawing.Size(173, 17);
			this.chkNoCrossLead.TabIndex = 1;
			this.chkNoCrossLead.Text = "Customer Cannot Be Cross Led";
			this.chkNoCrossLead.UseVisualStyleBackColor = true;
			this.chkNoCrossLead.CheckedChanged += new System.EventHandler(this.chkNoCrossLead_CheckedChanged);
			// 
			// myScreen
			// 
			this.myScreen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myScreen.IsDisposable = true;
			this.myScreen.ListTitle = "Cross Sales";
			this.myScreen.Location = new System.Drawing.Point(0, 0);
			this.myScreen.MyCrossSale = null;
			this.myScreen.MyCustomer = null;
			this.myScreen.Name = "myScreen";
			this.myScreen.Size = new System.Drawing.Size(661, 413);
			this.myScreen.TabIndex = 1;
			// 
			// CrossSaleManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 463);
			this.Controls.Add(this.myScreen);
			this.Controls.Add(this.pnlFooter);
			this.Name = "CrossSaleManagement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CrossSaleManagement";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CrossSaleManagement_FormClosing);
			this.pnlFooter.ResumeLayout(false);
			this.pnlFooter.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Panel pnlButtons;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckBox chkNoCrossLead;
		private CrossSaleScreen myScreen;
	}
}