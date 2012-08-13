namespace rkcrm.Objects.Customer.Lead_Source
{
	partial class AddLeadSource
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLeadSource));
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.pnlButton = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.mySourceBoundary = new rkcrm.Objects.Customer.Lead_Source.LeadSourceBoundary();
			this.pnlHeader.SuspendLayout();
			this.pnlFooter.SuspendLayout();
			this.pnlButton.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
			this.pnlHeader.BackgroundImage = global::rkcrm.Properties.Resources.BoundaryTitleBar;
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(607, 50);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(12, 15);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(192, 19);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Add a New Lead Source";
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.pnlButton);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 131);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(607, 50);
			this.pnlFooter.TabIndex = 1;
			// 
			// pnlButton
			// 
			this.pnlButton.Controls.Add(this.btnCancel);
			this.pnlButton.Controls.Add(this.btnAdd);
			this.pnlButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButton.Location = new System.Drawing.Point(437, 0);
			this.pnlButton.Name = "pnlButton";
			this.pnlButton.Size = new System.Drawing.Size(170, 50);
			this.pnlButton.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(84, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(3, 10);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 30);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// mySourceBoundary
			// 
			this.mySourceBoundary.BackColor = System.Drawing.Color.White;
			this.mySourceBoundary.ChangeHistoryVisible = false;
			this.mySourceBoundary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mySourceBoundary.IsBasic = true;
			this.mySourceBoundary.Location = new System.Drawing.Point(0, 50);
			this.mySourceBoundary.MySource = null;
			this.mySourceBoundary.Name = "mySourceBoundary";
			this.mySourceBoundary.ShowDepartments = false;
			this.mySourceBoundary.Size = new System.Drawing.Size(607, 81);
			this.mySourceBoundary.TabIndex = 2;
			this.mySourceBoundary.Title = "Search Lead Sources";
			this.mySourceBoundary.TitleBarVisible = false;
			// 
			// AddLeadSource
			// 
			this.AcceptButton = this.btnAdd;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(607, 181);
			this.Controls.Add(this.mySourceBoundary);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.pnlHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddLeadSource";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add New Lead Source";
			this.Load += new System.EventHandler(this.AddLeadSource_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlFooter.ResumeLayout(false);
			this.pnlButton.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Panel pnlButton;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAdd;
		private LeadSourceBoundary mySourceBoundary;
	}
}