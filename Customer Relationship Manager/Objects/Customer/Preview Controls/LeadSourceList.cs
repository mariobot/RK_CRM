using System;
using System.Collections.Generic;
using System.Linq;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer.Preview_Controls
{
	class LeadSourceList : PreviewBase
	{

		#region Variables

		internal System.Windows.Forms.ListView lvwLeadSources;
		internal System.Windows.Forms.ColumnHeader chSource;
		internal System.Windows.Forms.ColumnHeader chDepartment;
		internal System.Windows.Forms.ColumnHeader chRange;
		private System.Windows.Forms.ColumnHeader chAddedBy;

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.lvwLeadSources = new System.Windows.Forms.ListView();
			this.chSource = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chRange = new System.Windows.Forms.ColumnHeader();
			this.chAddedBy = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwLeadSources
			// 
			this.lvwLeadSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSource,
            this.chDepartment,
            this.chRange,
            this.chAddedBy});
			this.lvwLeadSources.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwLeadSources.FullRowSelect = true;
			this.lvwLeadSources.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwLeadSources.HoverSelection = true;
			this.lvwLeadSources.Location = new System.Drawing.Point(0, 24);
			this.lvwLeadSources.Name = "lvwLeadSources";
			this.lvwLeadSources.Size = new System.Drawing.Size(605, 125);
			this.lvwLeadSources.TabIndex = 56;
			this.lvwLeadSources.UseCompatibleStateImageBehavior = false;
			this.lvwLeadSources.View = System.Windows.Forms.View.Details;
			// 
			// chSource
			// 
			this.chSource.Text = "Lead Source";
			this.chSource.Width = 153;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 70;
			// 
			// chRange
			// 
			this.chRange.Text = "Active Range";
			this.chRange.Width = 114;
			// 
			// chAddedBy
			// 
			this.chAddedBy.Text = "Added By";
			this.chAddedBy.Width = 115;
			// 
			// LeadSourceList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.lvwLeadSources);
			this.Name = "LeadSourceList";
			this.Title = "Lead Sources";
			this.ExpandedChanged += new System.EventHandler<System.EventArgs>(this.LeadSourceList_ExpandedChanged);
			this.Controls.SetChildIndex(this.lvwLeadSources, 0);
			this.ResumeLayout(false);

		}

		#endregion


		#region Event Handlers

		private void LeadSourceList_ExpandedChanged(object sender, EventArgs e)
		{
			lvwLeadSources.Visible = IsExpanded;
		}

		#endregion


		#region Constructor

		public LeadSourceList()
			: base()
		{
			InitializeComponent();
		}

		#endregion

	}
}
