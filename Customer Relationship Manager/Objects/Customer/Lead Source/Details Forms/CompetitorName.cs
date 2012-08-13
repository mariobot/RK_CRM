using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.Competitor;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer.Lead_Source.Details_Forms
{
	class CompetitorName : DetailFormBase
	{
		private Panel pnlHeader;
		private Panel pnlFooter;
		private Label lblTitle;
		private Button btnCancel;
		private Button btnOK;
		private ListView lvwList;
		private ColumnHeader chID;
		private ColumnHeader chName;
		private Panel pnlButton;


		#region Methods

		private void InitializeComponent()
		{
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.pnlButton = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lvwList = new System.Windows.Forms.ListView();
			this.chID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.pnlHeader.SuspendLayout();
			this.pnlFooter.SuspendLayout();
			this.pnlButton.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.pnlHeader.Size = new System.Drawing.Size(234, 50);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(12, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(222, 50);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Select the competitor that referred this customer";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.pnlButton);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 202);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(234, 50);
			this.pnlFooter.TabIndex = 1;
			// 
			// pnlButton
			// 
			this.pnlButton.Controls.Add(this.btnCancel);
			this.pnlButton.Controls.Add(this.btnOK);
			this.pnlButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButton.Location = new System.Drawing.Point(57, 0);
			this.pnlButton.Name = "pnlButton";
			this.pnlButton.Size = new System.Drawing.Size(177, 50);
			this.pnlButton.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(84, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(3, 10);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 30);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "Select";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lvwList
			// 
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chName});
			this.lvwList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwList.FullRowSelect = true;
			this.lvwList.HideSelection = false;
			this.lvwList.Location = new System.Drawing.Point(0, 50);
			this.lvwList.MultiSelect = false;
			this.lvwList.Name = "lvwList";
			this.lvwList.Size = new System.Drawing.Size(234, 152);
			this.lvwList.TabIndex = 2;
			this.lvwList.UseCompatibleStateImageBehavior = false;
			this.lvwList.View = System.Windows.Forms.View.Details;
			// 
			// chID
			// 
			this.chID.Text = "ID";
			this.chID.Width = 0;
			// 
			// chName
			// 
			this.chName.Text = "Competitor Name";
			this.chName.Width = 200;
			// 
			// CompetitorName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(234, 252);
			this.Controls.Add(this.lvwList);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.pnlHeader);
			this.MinimumSize = new System.Drawing.Size(250, 290);
			this.Name = "CompetitorName";
			this.Load += new System.EventHandler(this.CompetitorName_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlFooter.ResumeLayout(false);
			this.pnlButton.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		private void LoadList()
		{
			DataTable oTable;

			using (CompetitorController theController = new CompetitorController())
			{
				oTable = theController.GetCompetitors(false);
			}

			if (oTable != null)
			{
				ListViewItem oItem;

				foreach (DataRow oRow in oTable.Rows)
				{
					oItem = new ListViewItem();
					oItem.Text = oRow["competitor_id"].ToString();
					oItem.SubItems.Add(oRow["name"].ToString());

					lvwList.Items.Add(oItem);
				}
			}
		}

		#endregion


		#region Event Handlers

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (lvwList.SelectedItems.Count > 0)
			{
				using (CompetitorController theController = new CompetitorController())
				{
					objReturnValue = theController.GetCompetitor(Convert.ToInt32(lvwList.SelectedItems[0].Text));
				}
				strReturnString = ((Competitor)objReturnValue).Name;

				DialogResult = DialogResult.OK;
				this.Close();
			}
			else
				MessageBox.Show("Please select a competitor from the list.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void CompetitorName_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		#endregion


		#region Constructor

		public CompetitorName()
			: base()
		{
			InitializeComponent();
		}

		#endregion

	}
}
