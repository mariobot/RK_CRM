namespace rkcrm.Objects.Project.Lost_Report
{
	partial class LostProjectForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LostProjectForm));
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnDone = new System.Windows.Forms.Button();
			this.lostProjectControls = new rkcrm.Objects.Project.Lost_Report.LostProjectBoundary();
			this.pnlFooter.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.btnCancel);
			this.pnlFooter.Controls.Add(this.btnDone);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 303);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(468, 50);
			this.pnlFooter.TabIndex = 3;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(381, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnDone
			// 
			this.btnDone.Location = new System.Drawing.Point(300, 10);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(75, 30);
			this.btnDone.TabIndex = 0;
			this.btnDone.Text = "Done";
			this.btnDone.UseVisualStyleBackColor = true;
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// lostProjectControls
			// 
			this.lostProjectControls.BackColor = System.Drawing.Color.White;
			this.lostProjectControls.ChangeHistoryVisible = false;
			this.lostProjectControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lostProjectControls.Location = new System.Drawing.Point(0, 0);
			this.lostProjectControls.MyLostProject = null;
			this.lostProjectControls.MyProjectID = 0;
			this.lostProjectControls.Name = "lostProjectControls";
			this.lostProjectControls.Size = new System.Drawing.Size(468, 303);
			this.lostProjectControls.TabIndex = 4;
			this.lostProjectControls.Title = "Lost Project Report";
			this.lostProjectControls.TitleBarVisible = true;
			// 
			// LostProjectForm
			// 
			this.AcceptButton = this.btnDone;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(468, 353);
			this.Controls.Add(this.lostProjectControls);
			this.Controls.Add(this.pnlFooter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LostProjectForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Lost Project Report";
			this.pnlFooter.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnDone;
		internal LostProjectBoundary lostProjectControls;
	}
}