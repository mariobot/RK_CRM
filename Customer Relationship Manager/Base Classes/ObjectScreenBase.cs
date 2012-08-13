using System.ComponentModel;
using System.Windows.Forms;

namespace rkcrm.Base_Classes
{
    class ObjectScreenBase : ScreenBase
    {

		#region Variables

		public System.Windows.Forms.ListView lvwList;
		private System.Windows.Forms.Panel pnlListTitle;
		private System.Windows.Forms.Label lblListTitle;

		private int sortedColumnIndex = -1;

		#endregion


		#region Properties

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Custom Properties")]
		public string ListTitle
		{
			get { return lblListTitle.Text; }
			set { lblListTitle.Text = value; }
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.lvwList = new System.Windows.Forms.ListView();
			this.pnlListTitle = new System.Windows.Forms.Panel();
			this.lblListTitle = new System.Windows.Forms.Label();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.pnlListTitle.SuspendLayout();
			this.SuspendLayout();
			// 
			// scMain
			// 
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Controls.Add(this.lvwList);
			this.scMain.Panel2.Controls.Add(this.pnlListTitle);
			this.scMain.Size = new System.Drawing.Size(602, 497);
			// 
			// lvwList
			// 
			this.lvwList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwList.FullRowSelect = true;
			this.lvwList.HideSelection = false;
			this.lvwList.Location = new System.Drawing.Point(0, 25);
			this.lvwList.MultiSelect = false;
			this.lvwList.Name = "lvwList";
			this.lvwList.Size = new System.Drawing.Size(600, 222);
			this.lvwList.TabIndex = 3;
			this.lvwList.UseCompatibleStateImageBehavior = false;
			this.lvwList.View = System.Windows.Forms.View.Details;
			this.lvwList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwList_ColumnClick);
			// 
			// pnlListTitle
			// 
			this.pnlListTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlListTitle.Controls.Add(this.lblListTitle);
			this.pnlListTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlListTitle.Location = new System.Drawing.Point(0, 0);
			this.pnlListTitle.Name = "pnlListTitle";
			this.pnlListTitle.Size = new System.Drawing.Size(600, 25);
			this.pnlListTitle.TabIndex = 2;
			// 
			// lblListTitle
			// 
			this.lblListTitle.AutoSize = true;
			this.lblListTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblListTitle.ForeColor = System.Drawing.Color.White;
			this.lblListTitle.Location = new System.Drawing.Point(10, 5);
			this.lblListTitle.Name = "lblListTitle";
			this.lblListTitle.Size = new System.Drawing.Size(55, 15);
			this.lblListTitle.TabIndex = 0;
			this.lblListTitle.Text = "List Title";
			// 
			// ObjectScreenBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "ObjectScreenBase";
			this.Size = new System.Drawing.Size(602, 497);
			this.scMain.Panel2.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.pnlListTitle.ResumeLayout(false);
			this.pnlListTitle.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion


		#region Methods

		private void lvwList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			if (e.Column != sortedColumnIndex)
			{
				sortedColumnIndex = e.Column;
				((ListView)sender).Sorting = SortOrder.Ascending;
			}
			else
				if (((ListView)sender).Sorting == SortOrder.Ascending)
					((ListView)sender).Sorting = SortOrder.Descending;
				else
					((ListView)sender).Sorting = SortOrder.Descending;

			((ListView)sender).ListViewItemSorter = new ListViewItemComparer(e.Column, ((ListView)sender).Sorting);
			((ListView)sender).Sort();
		}

		#endregion


		#region Constructor

		public ObjectScreenBase()
			: base()
		{
			InitializeComponent();
		}
		
		#endregion


    }
}
