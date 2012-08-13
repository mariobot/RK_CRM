namespace rkcrm.Base_Classes
{
    partial class NavigationButtonBase
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationButtonBase));
			this.imlBackground = new System.Windows.Forms.ImageList(this.components);
			this.pnlButton = new System.Windows.Forms.Panel();
			this.lblButtonText = new System.Windows.Forms.Label();
			this.pbxIcon = new System.Windows.Forms.PictureBox();
			this.pnlBottomLine = new System.Windows.Forms.Panel();
			this.pnlButton.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// imlBackground
			// 
			this.imlBackground.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBackground.ImageStream")));
			this.imlBackground.TransparentColor = System.Drawing.Color.Transparent;
			this.imlBackground.Images.SetKeyName(0, "Selection Bar Highlighted.bmp");
			this.imlBackground.Images.SetKeyName(1, "Selection Bar Selected.bmp");
			this.imlBackground.Images.SetKeyName(2, "Selection Bar Unselected.bmp");
			// 
			// pnlButton
			// 
			this.pnlButton.Controls.Add(this.lblButtonText);
			this.pnlButton.Controls.Add(this.pbxIcon);
			this.pnlButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlButton.Location = new System.Drawing.Point(0, 0);
			this.pnlButton.Name = "pnlButton";
			this.pnlButton.Size = new System.Drawing.Size(254, 32);
			this.pnlButton.TabIndex = 0;
			// 
			// lblButtonText
			// 
			this.lblButtonText.AutoSize = true;
			this.lblButtonText.BackColor = System.Drawing.Color.Transparent;
			this.lblButtonText.Location = new System.Drawing.Point(36, 9);
			this.lblButtonText.Name = "lblButtonText";
			this.lblButtonText.Size = new System.Drawing.Size(62, 13);
			this.lblButtonText.TabIndex = 1;
			this.lblButtonText.Text = "Button Text";
			// 
			// pbxIcon
			// 
			this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
			this.pbxIcon.Location = new System.Drawing.Point(8, 2);
			this.pbxIcon.Name = "pbxIcon";
			this.pbxIcon.Size = new System.Drawing.Size(28, 28);
			this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxIcon.TabIndex = 0;
			this.pbxIcon.TabStop = false;
			// 
			// pnlBottomLine
			// 
			this.pnlBottomLine.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pnlBottomLine.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottomLine.Location = new System.Drawing.Point(0, 171);
			this.pnlBottomLine.Name = "pnlBottomLine";
			this.pnlBottomLine.Size = new System.Drawing.Size(254, 1);
			this.pnlBottomLine.TabIndex = 1;
			// 
			// NavigationButtonBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlBottomLine);
			this.Controls.Add(this.pnlButton);
			this.MinimumSize = new System.Drawing.Size(0, 32);
			this.Name = "NavigationButtonBase";
			this.Size = new System.Drawing.Size(254, 172);
			this.pnlButton.ResumeLayout(false);
			this.pnlButton.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.ImageList imlBackground;
        private System.Windows.Forms.PictureBox pbxIcon;
        private System.Windows.Forms.Label lblButtonText;
        private System.Windows.Forms.Panel pnlBottomLine;
    }
}
