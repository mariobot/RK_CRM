namespace rkcrm.Objects.Project
{
	partial class DuplicateProjects
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicateProjects));
			this.lblTitle = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lvwProjects = new System.Windows.Forms.ListView();
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.chCustomer = new System.Windows.Forms.ColumnHeader();
			this.chProject = new System.Windows.Forms.ColumnHeader();
			this.chType = new System.Windows.Forms.ColumnHeader();
			this.chAddress = new System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
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
			this.lblTitle.Size = new System.Drawing.Size(784, 70);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = resources.GetString("lblTitle.Text");
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 257);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(784, 50);
			this.panel1.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(697, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(616, 10);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 30);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "Goto";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lvwProjects
			// 
			this.lvwProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProjectID,
            this.chCustomer,
            this.chProject,
            this.chType,
            this.chAddress});
			this.lvwProjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwProjects.FullRowSelect = true;
			this.lvwProjects.HideSelection = false;
			this.lvwProjects.Location = new System.Drawing.Point(0, 70);
			this.lvwProjects.MultiSelect = false;
			this.lvwProjects.Name = "lvwProjects";
			this.lvwProjects.Size = new System.Drawing.Size(784, 187);
			this.lvwProjects.TabIndex = 2;
			this.lvwProjects.UseCompatibleStateImageBehavior = false;
			this.lvwProjects.View = System.Windows.Forms.View.Details;
			// 
			// chProjectID
			// 
			this.chProjectID.Text = "Project ID";
			this.chProjectID.Width = 0;
			// 
			// chCustomer
			// 
			this.chCustomer.Text = "Customer";
			this.chCustomer.Width = 150;
			// 
			// chProject
			// 
			this.chProject.Text = "Project";
			this.chProject.Width = 150;
			// 
			// chType
			// 
			this.chType.Text = "Project Type";
			this.chType.Width = 120;
			// 
			// chAddress
			// 
			this.chAddress.Text = "Address";
			this.chAddress.Width = 250;
			// 
			// DuplicateProjects
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(784, 307);
			this.Controls.Add(this.lvwProjects);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblTitle);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DuplicateProjects";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Duplicate Projects";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListView lvwProjects;
		private System.Windows.Forms.ColumnHeader chCustomer;
		private System.Windows.Forms.ColumnHeader chProject;
		private System.Windows.Forms.ColumnHeader chAddress;
		private System.Windows.Forms.ColumnHeader chType;
		private System.Windows.Forms.ColumnHeader chProjectID;
	}
}