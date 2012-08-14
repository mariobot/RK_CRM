using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Objects.Quote;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Cross_Lead.Preview_Controls
{
	class QuotePreview : PreviewBase
	{

		#region Variables

		public System.Windows.Forms.ListView lvwList;
		internal System.Windows.Forms.ColumnHeader chQuoteID;
		internal System.Windows.Forms.ColumnHeader chProjectID;
		internal System.Windows.Forms.ColumnHeader chDepartment;
		internal System.Windows.Forms.ColumnHeader chSalesRep;
		internal System.Windows.Forms.ColumnHeader chName;
		internal System.Windows.Forms.ColumnHeader chAmount;
		internal System.Windows.Forms.ColumnHeader chStatus;

		private const int ADMINISTRATOR = 1;

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.lvwList = new System.Windows.Forms.ListView();
			this.chQuoteID = new System.Windows.Forms.ColumnHeader();
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chSalesRep = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chAmount = new System.Windows.Forms.ColumnHeader();
			this.chStatus = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.AllowColumnReorder = true;
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQuoteID,
            this.chProjectID,
            this.chDepartment,
            this.chSalesRep,
            this.chName,
            this.chAmount,
            this.chStatus});
			this.lvwList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwList.FullRowSelect = true;
			this.lvwList.HideSelection = false;
			this.lvwList.Location = new System.Drawing.Point(0, 24);
			this.lvwList.Name = "lvwList";
			this.lvwList.Size = new System.Drawing.Size(605, 126);
			this.lvwList.TabIndex = 5;
			this.lvwList.UseCompatibleStateImageBehavior = false;
			this.lvwList.View = System.Windows.Forms.View.Details;
			// 
			// chQuoteID
			// 
			this.chQuoteID.Text = "Quote ID";
			this.chQuoteID.Width = 0;
			// 
			// chProjectID
			// 
			this.chProjectID.Text = "Project ID";
			this.chProjectID.Width = 0;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 80;
			// 
			// chSalesRep
			// 
			this.chSalesRep.Text = "Sales Rep";
			this.chSalesRep.Width = 90;
			// 
			// chName
			// 
			this.chName.Text = "Quote Name";
			this.chName.Width = 150;
			// 
			// chAmount
			// 
			this.chAmount.Text = "Amount";
			this.chAmount.Width = 100;
			// 
			// chStatus
			// 
			this.chStatus.Text = "Status";
			this.chStatus.Width = 100;
			// 
			// QuotePreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.lvwList);
			this.Name = "QuotePreview";
			this.Title = "Quotes";
			this.Controls.SetChildIndex(this.lvwList, 0);
			this.ResumeLayout(false);

		}

		public void Clear()
		{
			Title = "Quotes";
			lvwList.Items.Clear();
		}

		public void LoadQuotes(int ProjectID)
		{
			DataTable quotes;
			ListViewItem oItem;

			lvwList.Items.Clear();

			using (QuoteController theController = new QuoteController())
			{
				quotes = theController.GetQuotes(ProjectID, (thisUser.RoleID == ADMINISTRATOR));
			}

			Title = "Quotes - Count: " + quotes.Rows.Count;

			foreach (DataRow oQuote in quotes.Rows)
			{
				oItem = new ListViewItem();

				oItem.Text = oQuote["quote_id"].ToString();
				oItem.SubItems.Add(oQuote["project_id"].ToString());
				oItem.SubItems.Add(oQuote["department"].ToString());
				oItem.SubItems.Add(oQuote["rep"].ToString());
				oItem.SubItems.Add(oQuote["name"].ToString());
				oItem.SubItems.Add(Convert.ToDecimal(oQuote["amount"]).ToString("C"));
				oItem.SubItems.Add(oQuote["status"].ToString());

				if (Convert.ToBoolean(oQuote["is_archived"]))
					oItem.BackColor = Color.LightSteelBlue;
				else
					oItem.BackColor = Color.White;

				lvwList.Items.Add(oItem);
			}
		}

		#endregion


		#region Constructor

		public QuotePreview()
			: base()
		{
			InitializeComponent();

			Clear();
		}

		#endregion

	}
}
