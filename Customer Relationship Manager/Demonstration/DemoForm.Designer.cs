namespace rkcrm.Demonstration
{
    partial class DemoForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.myBoundary = new rkcrm.Administration.User.UserBoundary();
			this.pnlFooter.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlFooter
			// 
			this.pnlFooter.BackColor = System.Drawing.SystemColors.Control;
			this.pnlFooter.Controls.Add(this.btnStop);
			this.pnlFooter.Controls.Add(this.btnRefresh);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(3, 336);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(522, 50);
			this.pnlFooter.TabIndex = 0;
			// 
			// btnStop
			// 
			this.btnStop.Image = global::rkcrm.Properties.Resources.Stop_Icon_16;
			this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnStop.Location = new System.Drawing.Point(386, 10);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(124, 30);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "Stop Demonstration";
			this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(12, 10);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(86, 30);
			this.btnRefresh.TabIndex = 0;
			this.btnRefresh.Text = "Refresh User";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(3, 3);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(522, 50);
			this.pnlHeader.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(13, 15);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(229, 19);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Demonstration User Security";
			// 
			// myBoundary
			// 
			this.myBoundary.BackColor = System.Drawing.SystemColors.Control;
			this.myBoundary.ChangeHistoryVisible = false;
			this.myBoundary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myBoundary.Location = new System.Drawing.Point(3, 53);
			this.myBoundary.Name = "myBoundary";
			this.myBoundary.Size = new System.Drawing.Size(522, 283);
			this.myBoundary.TabIndex = 2;
			this.myBoundary.Title = "Users";
			this.myBoundary.TitleBarVisible = false;
			// 
			// DemoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(528, 389);
			this.Controls.Add(this.myBoundary);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.pnlFooter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DemoForm";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DemoForm";
			this.Load += new System.EventHandler(this.DemoForm_Load);
			this.pnlFooter.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private rkcrm.Administration.User.UserBoundary myBoundary;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRefresh;
    }
}