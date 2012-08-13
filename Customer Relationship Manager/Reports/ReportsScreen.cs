using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Base_Classes;

namespace rkcrm.Reports
{
    class ReportsScreen : ScreenBase
    {
		private ImageList imlList;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TabControl tcReports;
    
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsScreen));
			this.tcReports = new System.Windows.Forms.TabControl();
			this.imlList = new System.Windows.Forms.ImageList(this.components);
			this.scMain.Panel1.SuspendLayout();
			this.scMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.tcReports);
			this.scMain.Panel2Collapsed = true;
			// 
			// tcReports
			// 
			this.tcReports.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcReports.Location = new System.Drawing.Point(0, 0);
			this.tcReports.Name = "tcReports";
			this.tcReports.SelectedIndex = 0;
			this.tcReports.Size = new System.Drawing.Size(731, 495);
			this.tcReports.TabIndex = 0;
			// 
			// imlList
			// 
			this.imlList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlList.ImageStream")));
			this.imlList.TransparentColor = System.Drawing.Color.Transparent;
			this.imlList.Images.SetKeyName(0, "Document_icon.png");
			this.imlList.Images.SetKeyName(1, "Document_Unavailable.png");
			// 
			// ReportsScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "ReportsScreen";
			this.Load += new System.EventHandler(this.ReportsScreen_Load);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        public ReportsScreen()
            : base()
        {
            InitializeComponent();
        }

		private void ReportsScreen_Load(object sender, EventArgs e)
		{
			using (ReportController theController = new ReportController())
			{
				ReportTabPage thePage;

				foreach (DataRow oRow in theController.GetPageNames().Rows)
				{

					thePage = new ReportTabPage(oRow["page"].ToString());
					thePage.Name = "tp" + oRow["page"].ToString();
					thePage.BackColor = Color.White;

					tcReports.TabPages.Add(thePage);
				}

				ListViewItem newItem;
				ListViewGroup theGroup = null;
				thePage = (ReportTabPage)tcReports.TabPages[0];

				foreach (DataRow oRow in theController.GetReports().Rows)
				{
					if (thePage.Text != oRow["page"].ToString())
					{
						foreach (TabPage oPage in tcReports.TabPages)
							if (oPage.Text == oRow["page"].ToString())
								thePage = (ReportTabPage)oPage;
					}

					if (theGroup == null || theGroup.Header != oRow["group"].ToString())
					{
						if (oRow["group"] != DBNull.Value)
						{
							theGroup = new ListViewGroup(oRow["group"].ToString(), HorizontalAlignment.Left);
						thePage.lvwReports.Groups.Add(theGroup);
						}
						else
							theGroup = null;
					}

					newItem = new ListViewItem();
					newItem.Text = oRow["report"].ToString();
					newItem.SubItems.Add(oRow["parameter_form"].ToString());

					if (oRow["parameter_form"] == DBNull.Value)
						newItem.ImageIndex = 1;
					else
						newItem.ImageIndex = 0;

					if (theGroup != null)
						newItem.Group = theGroup;

					thePage.lvwReports.Items.Add(newItem);
				}
			}
		}
    }
}
