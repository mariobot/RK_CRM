using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer.Preview_Controls
{
	class RelatedCustomersPreview : PreviewBase
	{
		private System.Windows.Forms.ColumnHeader chCustomerName;
		private System.Windows.Forms.ColumnHeader chCustomerID;
		internal System.Windows.Forms.ListView lvwList;

		#region Methods

		private void InitializeComponent()
		{
			this.lvwList = new System.Windows.Forms.ListView();
			this.chCustomerName = new System.Windows.Forms.ColumnHeader();
			this.chCustomerID = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCustomerID,
            this.chCustomerName});
			this.lvwList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwList.FullRowSelect = true;
			this.lvwList.Location = new System.Drawing.Point(0, 24);
			this.lvwList.Name = "lvwList";
			this.lvwList.Size = new System.Drawing.Size(605, 125);
			this.lvwList.TabIndex = 6;
			this.lvwList.UseCompatibleStateImageBehavior = false;
			this.lvwList.View = System.Windows.Forms.View.Details;
			// 
			// chCustomerName
			// 
			this.chCustomerName.Text = "Customer Name";
			this.chCustomerName.Width = 235;
			// 
			// chCustomerID
			// 
			this.chCustomerID.Text = "CustomerID";
			this.chCustomerID.Width = 0;
			// 
			// RelatedCustomersPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.lvwList);
			this.Name = "RelatedCustomersPreview";
			this.Title = "Related Customers";
			this.ExpandedChanged += new System.EventHandler<System.EventArgs>(this.RelatedCustomersPreview_ExpandedChanged);
			this.Controls.SetChildIndex(this.lvwList, 0);
			this.ResumeLayout(false);

		}

		#endregion


		#region Event Handlers

		private void RelatedCustomersPreview_ExpandedChanged(object sender, EventArgs e)
		{
			lvwList.Visible = IsExpanded;
		}

		#endregion


		#region Constructor

		public RelatedCustomersPreview()
			: base()
		{
			InitializeComponent();
		}

		#endregion


	}
}
