namespace rkcrm.Base_Classes
{
	partial class PreviewBase
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewBase));
			this.imlExpandCollapse = new System.Windows.Forms.ImageList(this.components);
			this.pnlListHeader = new System.Windows.Forms.Panel();
			this.pbxMinMax = new System.Windows.Forms.PictureBox();
			this.lblTilte = new System.Windows.Forms.Label();
			this.pnlLine = new System.Windows.Forms.Panel();
			this.pnlListHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxMinMax)).BeginInit();
			this.SuspendLayout();
			// 
			// imlExpandCollapse
			// 
			this.imlExpandCollapse.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlExpandCollapse.ImageStream")));
			this.imlExpandCollapse.TransparentColor = System.Drawing.Color.Transparent;
			this.imlExpandCollapse.Images.SetKeyName(0, "Collapse_Icon.png");
			this.imlExpandCollapse.Images.SetKeyName(1, "Expand_Icon.png");
			// 
			// pnlListHeader
			// 
			this.pnlListHeader.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlListHeader.BackgroundImage = global::rkcrm.Properties.Resources.PreviewBackground;
			this.pnlListHeader.Controls.Add(this.pbxMinMax);
			this.pnlListHeader.Controls.Add(this.lblTilte);
			this.pnlListHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlListHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlListHeader.Name = "pnlListHeader";
			this.pnlListHeader.Size = new System.Drawing.Size(605, 24);
			this.pnlListHeader.TabIndex = 4;
			// 
			// pbxMinMax
			// 
			this.pbxMinMax.Image = global::rkcrm.Properties.Resources.Collapse_Icon;
			this.pbxMinMax.Location = new System.Drawing.Point(8, 4);
			this.pbxMinMax.Name = "pbxMinMax";
			this.pbxMinMax.Size = new System.Drawing.Size(16, 16);
			this.pbxMinMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbxMinMax.TabIndex = 3;
			this.pbxMinMax.TabStop = false;
			this.pbxMinMax.Tag = "";
			this.pbxMinMax.Click += new System.EventHandler(this.pbxMinMax_Click);
			// 
			// lblTilte
			// 
			this.lblTilte.AutoSize = true;
			this.lblTilte.BackColor = System.Drawing.Color.Transparent;
			this.lblTilte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTilte.ForeColor = System.Drawing.Color.White;
			this.lblTilte.Location = new System.Drawing.Point(28, 5);
			this.lblTilte.Name = "lblTilte";
			this.lblTilte.Size = new System.Drawing.Size(31, 14);
			this.lblTilte.TabIndex = 0;
			this.lblTilte.Text = "Title";
			// 
			// pnlLine
			// 
			this.pnlLine.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlLine.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlLine.Location = new System.Drawing.Point(0, 149);
			this.pnlLine.Name = "pnlLine";
			this.pnlLine.Size = new System.Drawing.Size(605, 1);
			this.pnlLine.TabIndex = 5;
			// 
			// PreviewBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlLine);
			this.Controls.Add(this.pnlListHeader);
			this.Name = "PreviewBase";
			this.Size = new System.Drawing.Size(605, 150);
			this.pnlListHeader.ResumeLayout(false);
			this.pnlListHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxMinMax)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.Panel pnlListHeader;
		internal System.Windows.Forms.PictureBox pbxMinMax;
		internal System.Windows.Forms.Label lblTilte;
		internal System.Windows.Forms.ImageList imlExpandCollapse;
		private System.Windows.Forms.Panel pnlLine;
	}
}
