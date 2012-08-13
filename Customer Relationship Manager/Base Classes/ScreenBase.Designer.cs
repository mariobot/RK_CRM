namespace rkcrm.Base_Classes
{
    partial class ScreenBase
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
			this.scMain = new System.Windows.Forms.SplitContainer();
			this.cmsActions = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmActions = new System.Windows.Forms.ToolStripMenuItem();
			this.scMain.SuspendLayout();
			this.cmsActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// scMain
			// 
			this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scMain.Location = new System.Drawing.Point(0, 0);
			this.scMain.Name = "scMain";
			this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.BackColor = System.Drawing.Color.White;
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.AutoScroll = true;
			this.scMain.Size = new System.Drawing.Size(733, 497);
			this.scMain.SplitterDistance = 243;
			this.scMain.TabIndex = 0;
			// 
			// cmsActions
			// 
			this.cmsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmActions});
			this.cmsActions.Name = "cmsActions";
			this.cmsActions.Size = new System.Drawing.Size(153, 48);
			// 
			// tsmActions
			// 
			this.tsmActions.Name = "tsmActions";
			this.tsmActions.Size = new System.Drawing.Size(152, 22);
			this.tsmActions.Text = "Actions";
			// 
			// ScreenBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.scMain);
			this.Name = "ScreenBase";
			this.Size = new System.Drawing.Size(733, 497);
			this.Load += new System.EventHandler(this.ScreenBase_Load);
			this.DockChanged += new System.EventHandler(this.ScreenBase_DockChanged);
			this.scMain.ResumeLayout(false);
			this.cmsActions.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		public System.Windows.Forms.SplitContainer scMain;
		protected internal System.Windows.Forms.ContextMenuStrip cmsActions;
		protected internal System.Windows.Forms.ToolStripMenuItem tsmActions;

    }
}
