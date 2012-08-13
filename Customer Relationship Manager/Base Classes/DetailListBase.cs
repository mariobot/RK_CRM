using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace rkcrm.Base_Classes
{
	class DetailListBase : DetailFormBase
	{
		public ListView lvwList;
		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Panel pnlButton;
		public Button btnOK;
		internal System.Windows.Forms.Panel pnlHeader;
		internal System.Windows.Forms.Label lblTitle;
		public System.Windows.Forms.Button btnClearSearch;
		public System.Windows.Forms.Button btnSearch;
		internal System.Windows.Forms.ComboBox cboSearchIn;
		internal System.Windows.Forms.Label lblSearchIn;
		internal System.Windows.Forms.TextBox txtLookFor;
		internal System.Windows.Forms.Label lblLookFor;
		private System.Windows.Forms.Label lblMessage;
		public Button btnCancel;


		#region Variables

		private int sortedColumnIndex = -1;

		#endregion


		#region Properties

		[Category("Custom Properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string Title
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailListBase));
			this.lvwList = new System.Windows.Forms.ListView();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.pnlButton = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnClearSearch = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.cboSearchIn = new System.Windows.Forms.ComboBox();
			this.lblSearchIn = new System.Windows.Forms.Label();
			this.txtLookFor = new System.Windows.Forms.TextBox();
			this.lblLookFor = new System.Windows.Forms.Label();
			this.lblMessage = new System.Windows.Forms.Label();
			this.pnlFooter.SuspendLayout();
			this.pnlButton.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwList.FullRowSelect = true;
			this.lvwList.HideSelection = false;
			this.lvwList.Location = new System.Drawing.Point(0, 60);
			this.lvwList.MultiSelect = false;
			this.lvwList.Name = "lvwList";
			this.lvwList.Size = new System.Drawing.Size(684, 152);
			this.lvwList.TabIndex = 5;
			this.lvwList.UseCompatibleStateImageBehavior = false;
			this.lvwList.View = System.Windows.Forms.View.Details;
			this.lvwList.DoubleClick += new System.EventHandler(this.lvwList_DoubleClick);
			this.lvwList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwList_ColumnClick);
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.pnlButton);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 212);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(684, 50);
			this.pnlFooter.TabIndex = 4;
			// 
			// pnlButton
			// 
			this.pnlButton.Controls.Add(this.btnOK);
			this.pnlButton.Controls.Add(this.btnCancel);
			this.pnlButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButton.Location = new System.Drawing.Point(467, 0);
			this.pnlButton.Name = "pnlButton";
			this.pnlButton.Size = new System.Drawing.Size(217, 50);
			this.pnlButton.TabIndex = 1;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(49, 10);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 30);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(130, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.DarkGray;
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Controls.Add(this.btnClearSearch);
			this.pnlHeader.Controls.Add(this.btnSearch);
			this.pnlHeader.Controls.Add(this.cboSearchIn);
			this.pnlHeader.Controls.Add(this.lblSearchIn);
			this.pnlHeader.Controls.Add(this.txtLookFor);
			this.pnlHeader.Controls.Add(this.lblLookFor);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(684, 60);
			this.pnlHeader.TabIndex = 6;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(10, 9);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(40, 18);
			this.lblTitle.TabIndex = 14;
			this.lblTitle.Text = "Title";
			// 
			// btnClearSearch
			// 
			this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClearSearch.ForeColor = System.Drawing.Color.White;
			this.btnClearSearch.Location = new System.Drawing.Point(586, 31);
			this.btnClearSearch.Name = "btnClearSearch";
			this.btnClearSearch.Size = new System.Drawing.Size(83, 23);
			this.btnClearSearch.TabIndex = 13;
			this.btnClearSearch.Text = "Clear Search";
			this.btnClearSearch.UseVisualStyleBackColor = true;
			this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.ForeColor = System.Drawing.Color.White;
			this.btnSearch.Location = new System.Drawing.Point(505, 31);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 12;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			// 
			// cboSearchIn
			// 
			this.cboSearchIn.AutoCompleteCustomSource.AddRange(new string[] {
            "Company Name",
            "Phone Number",
            "Falcon Number"});
			this.cboSearchIn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboSearchIn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboSearchIn.FormattingEnabled = true;
			this.cboSearchIn.Location = new System.Drawing.Point(378, 32);
			this.cboSearchIn.Name = "cboSearchIn";
			this.cboSearchIn.Size = new System.Drawing.Size(121, 21);
			this.cboSearchIn.TabIndex = 11;
			this.cboSearchIn.SelectedIndexChanged += new System.EventHandler(this.cboSearchIn_SelectedIndexChanged);
			this.cboSearchIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
			// 
			// lblSearchIn
			// 
			this.lblSearchIn.AutoSize = true;
			this.lblSearchIn.ForeColor = System.Drawing.Color.White;
			this.lblSearchIn.Location = new System.Drawing.Point(316, 35);
			this.lblSearchIn.Name = "lblSearchIn";
			this.lblSearchIn.Size = new System.Drawing.Size(56, 13);
			this.lblSearchIn.TabIndex = 10;
			this.lblSearchIn.Text = "Search In:";
			// 
			// txtLookFor
			// 
			this.txtLookFor.Location = new System.Drawing.Point(68, 33);
			this.txtLookFor.Name = "txtLookFor";
			this.txtLookFor.Size = new System.Drawing.Size(240, 20);
			this.txtLookFor.TabIndex = 9;
			this.txtLookFor.TextChanged += new System.EventHandler(this.txtLookFor_TextChanged);
			this.txtLookFor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
			// 
			// lblLookFor
			// 
			this.lblLookFor.AutoSize = true;
			this.lblLookFor.ForeColor = System.Drawing.Color.White;
			this.lblLookFor.Location = new System.Drawing.Point(10, 36);
			this.lblLookFor.Name = "lblLookFor";
			this.lblLookFor.Size = new System.Drawing.Size(52, 13);
			this.lblLookFor.TabIndex = 8;
			this.lblLookFor.Text = "Look For:";
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.BackColor = System.Drawing.Color.White;
			this.lblMessage.Location = new System.Drawing.Point(291, 125);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(103, 13);
			this.lblMessage.TabIndex = 12;
			this.lblMessage.Text = "Message goes here.";
			this.lblMessage.Visible = false;
			this.lblMessage.VisibleChanged += new System.EventHandler(this.lblMessage_VisibleChanged);
			this.lblMessage.TextChanged += new System.EventHandler(this.lblMessage_TextChanged);
			// 
			// DetailListBase
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(684, 262);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.lvwList);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.pnlFooter);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(700, 300);
			this.Name = "DetailListBase";
			this.pnlFooter.ResumeLayout(false);
			this.pnlButton.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void Clear()
		{
			txtLookFor.Clear();
			cboSearchIn.SelectedIndex = 0;

			ClearResults();
		}

		public void ClearResults()
		{
			lvwList.Items.Clear();
			lvwList.Sorting = SortOrder.None;
			lvwList.ListViewItemSorter = null;
			lblMessage.Visible = false;
		}

		public void ShowResultsMessage(string Message)
		{
			lblMessage.Text = Message;
			lblMessage.Visible = true;
		}

		#endregion


		#region Event Handlers

		private void lblMessage_TextChanged(object sender, EventArgs e)
		{
			if (lblMessage.Visible)
			{
				lblMessage.Location = new Point(Convert.ToInt32(lvwList.Location.X + 0.5 * (lvwList.Width - lblMessage.Width)),
					Convert.ToInt32(lvwList.Location.Y + 0.5 * (lvwList.Height - lblMessage.Height)));
			}
		}

		private void lblMessage_VisibleChanged(object sender, EventArgs e)
		{
			if (lblMessage.Visible)
			{
				lblMessage.Location = new Point(Convert.ToInt32(lvwList.Location.X + 0.5 * (lvwList.Width - lblMessage.Width)),
					Convert.ToInt32(lvwList.Location.Y + 0.5 * (lvwList.Height - lblMessage.Height)));
			}
		}

		private void lvwList_ColumnClick(object sender, ColumnClickEventArgs e)
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

		private void txtLookFor_TextChanged(object sender, EventArgs e)
		{
			btnSearch.Enabled = (cboSearchIn.SelectedValue != null && txtLookFor.TextLength > 0);
		}

		private void cboSearchIn_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnSearch.Enabled = (cboSearchIn.SelectedValue != null && txtLookFor.TextLength > 0);
		}

		private void control_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && btnSearch.Enabled)
				btnSearch.PerformClick();
		}

		private void btnClearSearch_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void lvwList_DoubleClick(object sender, EventArgs e)
		{
			btnOK.PerformClick();
		}

		#endregion


		#region Constructor

		public DetailListBase()
			: base()
		{
			InitializeComponent();
		}

		#endregion

	}
}
