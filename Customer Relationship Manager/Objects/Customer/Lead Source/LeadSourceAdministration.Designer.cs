namespace rkcrm.Objects.Customer.Lead_Source
{
	partial class LeadSourceAdministration
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
			this.theSourceScreen = new rkcrm.Objects.Customer.Lead_Source.LeadSourceScreen();
			this.SuspendLayout();
			// 
			// theSourceScreen
			// 
			this.theSourceScreen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.theSourceScreen.IsDisposable = true;
			this.theSourceScreen.ListTitle = "Lead Sources";
			this.theSourceScreen.Location = new System.Drawing.Point(0, 0);
			this.theSourceScreen.MyCustomer = null;
			this.theSourceScreen.MySource = null;
			this.theSourceScreen.Name = "theSourceScreen";
			this.theSourceScreen.Size = new System.Drawing.Size(617, 532);
			this.theSourceScreen.TabIndex = 0;
			// 
			// LeadSourceAdministration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(617, 532);
			this.Controls.Add(this.theSourceScreen);
			this.Name = "LeadSourceAdministration";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Lead Source Administration";
			this.ResumeLayout(false);

		}

		#endregion

		internal LeadSourceScreen theSourceScreen;


	}
}