using System;
using System.Windows.Forms;

namespace rkcrm.Reports
{
	class ReportTabPage : TabPage
	{
		public ImageList imlList;
		private System.ComponentModel.IContainer components;
		public ListView lvwReports;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportTabPage));
			this.lvwReports = new System.Windows.Forms.ListView();
			this.imlList = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// lvwReports
			// 
			this.lvwReports.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwReports.LargeImageList = this.imlList;
			this.lvwReports.Location = new System.Drawing.Point(0, 0);
			this.lvwReports.MultiSelect = false;
			this.lvwReports.Name = "lvwReports";
			this.lvwReports.Size = new System.Drawing.Size(121, 97);
			this.lvwReports.TabIndex = 0;
			this.lvwReports.UseCompatibleStateImageBehavior = false;
			this.lvwReports.DoubleClick += new System.EventHandler(this.lvwReports_DoubleClick);
			// 
			// imlList
			// 
			this.imlList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlList.ImageStream")));
			this.imlList.TransparentColor = System.Drawing.Color.Transparent;
			this.imlList.Images.SetKeyName(0, "Document_icon.png");
			this.imlList.Images.SetKeyName(1, "Document_Unavailable.png");
			// 
			// ReportTabPage
			// 
			this.BackColor = System.Drawing.Color.White;
			this.ResumeLayout(false);

		}

		public ReportTabPage()
			: base()
		{
			InitializeComponent();
			this.Controls.Add(lvwReports);
		}

		public ReportTabPage(string Text)
			: base(Text)
		{
			InitializeComponent();
			this.Controls.Add(lvwReports);
		}

		private void lvwReports_DoubleClick(object sender, EventArgs e)
		{
			if (lvwReports.SelectedItems.Count > 0)
			{
				if (!string.IsNullOrEmpty(lvwReports.SelectedItems[0].SubItems[1].Text))
				{
					Form oForm = (Form)ObjectFactory.GetObject("rkcrm.Reports.Parameter_Forms");
				}
			}
		}
	}
}
