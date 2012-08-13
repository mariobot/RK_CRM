using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace rkcrm.Base_Classes
{
    class SearchScreenBase : ScreenBase
    {
        private System.Windows.Forms.Label lblMessage;
        public System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.Panel pnlHeader;
        internal System.Windows.Forms.Label lblSearchScreenTitle;
        public System.Windows.Forms.Button btnClearSearch;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.ComboBox cboSearchIn;
        internal System.Windows.Forms.Label lblSearchIn;
        public System.Windows.Forms.TextBox txtLookFor;
        internal System.Windows.Forms.Label lblLookFor;
        public System.Windows.Forms.ToolStrip tsMain;
        protected ContextMenuStrip cmsResults;
        private IContainer components;

        private int sortedColumnIndex = -1;

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Custom Properties")]
        public string ScreenTitle
        {
            get { return lblSearchScreenTitle.Text; }
            set { lblSearchScreenTitle.Text = value; }
        }

        #endregion


        #region Methods

        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.lblMessage = new System.Windows.Forms.Label();
			this.lvwResults = new System.Windows.Forms.ListView();
			this.cmsResults = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblSearchScreenTitle = new System.Windows.Forms.Label();
			this.btnClearSearch = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.cboSearchIn = new System.Windows.Forms.ComboBox();
			this.lblSearchIn = new System.Windows.Forms.Label();
			this.txtLookFor = new System.Windows.Forms.TextBox();
			this.lblLookFor = new System.Windows.Forms.Label();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.lblMessage);
			this.scMain.Panel1.Controls.Add(this.lvwResults);
			this.scMain.Panel1.Controls.Add(this.pnlHeader);
			this.scMain.Panel1.Controls.Add(this.tsMain);
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Padding = new System.Windows.Forms.Padding(3);
			this.scMain.Size = new System.Drawing.Size(600, 510);
			this.scMain.SplitterDistance = 250;
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.BackColor = System.Drawing.Color.White;
			this.lblMessage.Location = new System.Drawing.Point(247, 179);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(103, 13);
			this.lblMessage.TabIndex = 10;
			this.lblMessage.Text = "Message goes here.";
			this.lblMessage.Visible = false;
			this.lblMessage.VisibleChanged += new System.EventHandler(this.lblMessage_VisibleChanged);
			this.lblMessage.TextChanged += new System.EventHandler(this.lblMessage_TextChanged);
			// 
			// lvwResults
			// 
			this.lvwResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvwResults.ContextMenuStrip = this.cmsResults;
			this.lvwResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwResults.FullRowSelect = true;
			this.lvwResults.HideSelection = false;
			this.lvwResults.Location = new System.Drawing.Point(0, 80);
			this.lvwResults.MultiSelect = false;
			this.lvwResults.Name = "lvwResults";
			this.lvwResults.Size = new System.Drawing.Size(598, 168);
			this.lvwResults.TabIndex = 7;
			this.lvwResults.UseCompatibleStateImageBehavior = false;
			this.lvwResults.View = System.Windows.Forms.View.Details;
			this.lvwResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwResults_ColumnClick);
			// 
			// cmsResults
			// 
			this.cmsResults.Name = "cmsResults";
			this.cmsResults.Size = new System.Drawing.Size(61, 4);
			// 
			// tsMain
			// 
			this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(598, 25);
			this.tsMain.TabIndex = 8;
			this.tsMain.Text = "toolStrip1";
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlHeader.BackgroundImage = global::rkcrm.Properties.Resources.SearchTitleBar;
			this.pnlHeader.Controls.Add(this.lblSearchScreenTitle);
			this.pnlHeader.Controls.Add(this.btnClearSearch);
			this.pnlHeader.Controls.Add(this.btnSearch);
			this.pnlHeader.Controls.Add(this.cboSearchIn);
			this.pnlHeader.Controls.Add(this.lblSearchIn);
			this.pnlHeader.Controls.Add(this.txtLookFor);
			this.pnlHeader.Controls.Add(this.lblLookFor);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 25);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(598, 55);
			this.pnlHeader.TabIndex = 9;
			// 
			// lblSearchScreenTitle
			// 
			this.lblSearchScreenTitle.AutoSize = true;
			this.lblSearchScreenTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblSearchScreenTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSearchScreenTitle.ForeColor = System.Drawing.Color.White;
			this.lblSearchScreenTitle.Location = new System.Drawing.Point(3, 5);
			this.lblSearchScreenTitle.Name = "lblSearchScreenTitle";
			this.lblSearchScreenTitle.Size = new System.Drawing.Size(102, 16);
			this.lblSearchScreenTitle.TabIndex = 14;
			this.lblSearchScreenTitle.Text = "Search Screen";
			// 
			// btnClearSearch
			// 
			this.btnClearSearch.BackColor = System.Drawing.Color.Transparent;
			this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClearSearch.ForeColor = System.Drawing.Color.White;
			this.btnClearSearch.Location = new System.Drawing.Point(504, 28);
			this.btnClearSearch.Name = "btnClearSearch";
			this.btnClearSearch.Size = new System.Drawing.Size(83, 23);
			this.btnClearSearch.TabIndex = 13;
			this.btnClearSearch.Text = "Clear Search";
			this.btnClearSearch.UseVisualStyleBackColor = false;
			// 
			// btnSearch
			// 
			this.btnSearch.BackColor = System.Drawing.Color.Transparent;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.ForeColor = System.Drawing.Color.White;
			this.btnSearch.Location = new System.Drawing.Point(423, 28);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 12;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = false;
			// 
			// cboSearchIn
			// 
			this.cboSearchIn.AutoCompleteCustomSource.AddRange(new string[] {
            "Fisrt Name",
            "Last Name",
            "Company Name",
            "Phone Numbers"});
			this.cboSearchIn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboSearchIn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboSearchIn.FormattingEnabled = true;
			this.cboSearchIn.Location = new System.Drawing.Point(296, 29);
			this.cboSearchIn.Name = "cboSearchIn";
			this.cboSearchIn.Size = new System.Drawing.Size(121, 21);
			this.cboSearchIn.TabIndex = 11;
			this.cboSearchIn.SelectedIndexChanged += new System.EventHandler(this.cboSearchIn_SelectedIndexChanged);
			this.cboSearchIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
			// 
			// lblSearchIn
			// 
			this.lblSearchIn.AutoSize = true;
			this.lblSearchIn.BackColor = System.Drawing.Color.Transparent;
			this.lblSearchIn.ForeColor = System.Drawing.Color.White;
			this.lblSearchIn.Location = new System.Drawing.Point(234, 32);
			this.lblSearchIn.Name = "lblSearchIn";
			this.lblSearchIn.Size = new System.Drawing.Size(56, 13);
			this.lblSearchIn.TabIndex = 10;
			this.lblSearchIn.Text = "Search In:";
			// 
			// txtLookFor
			// 
			this.txtLookFor.Location = new System.Drawing.Point(61, 29);
			this.txtLookFor.Name = "txtLookFor";
			this.txtLookFor.Size = new System.Drawing.Size(159, 20);
			this.txtLookFor.TabIndex = 9;
			this.txtLookFor.TextChanged += new System.EventHandler(this.txtLookFor_TextChanged);
			this.txtLookFor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
			// 
			// lblLookFor
			// 
			this.lblLookFor.AutoSize = true;
			this.lblLookFor.BackColor = System.Drawing.Color.Transparent;
			this.lblLookFor.ForeColor = System.Drawing.Color.White;
			this.lblLookFor.Location = new System.Drawing.Point(3, 32);
			this.lblLookFor.Name = "lblLookFor";
			this.lblLookFor.Size = new System.Drawing.Size(52, 13);
			this.lblLookFor.TabIndex = 8;
			this.lblLookFor.Text = "Look For:";
			// 
			// SearchScreenBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "SearchScreenBase";
			this.Size = new System.Drawing.Size(600, 510);
			this.Controls.SetChildIndex(this.scMain, 0);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel1.PerformLayout();
			this.scMain.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.ResumeLayout(false);

        }

        public new void Clear()
        {
            base.Clear();
            txtLookFor.Clear();
            cboSearchIn.SelectedIndex = 0;

			ClearResults();
		}

		public void ClearResults()
		{
			if (lvwResults.SelectedItems.Count > 0)
				//This fires the ItemSelectionChanged event on the individual drop down objects
				lvwResults.SelectedItems[0].Selected = false;

			lvwResults.Items.Clear();
			lvwResults.Sorting = SortOrder.None;
			lvwResults.ListViewItemSorter = null;
			lblMessage.Visible = false;
		}

		public void ShowResultsMessage(string Message)
		{
			lblMessage.Text = Message;
			lblMessage.Visible = true;
		}

        #endregion


        #region Event Handler

        private void lblMessage_VisibleChanged(object sender, EventArgs e)
        {
            if (lblMessage.Visible)
            {
                lblMessage.Location = new Point(Convert.ToInt32(lvwResults.Location.X + 0.5 * (lvwResults.Width - lblMessage.Width)),
					Convert.ToInt32(lvwResults.Location.Y + 0.5 * (lvwResults.Height - lblMessage.Height)));
            }
        }

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {
            if (lblMessage.Visible)
            {
                lblMessage.Location = new Point(Convert.ToInt32(lvwResults.Location.X + 0.5 * (lvwResults.Width - lblMessage.Width)),
					Convert.ToInt32(lvwResults.Location.Y + 0.5 * (lvwResults.Height - lblMessage.Height)));
            }
        }

        protected void lvwResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortedColumnIndex)
            {
                sortedColumnIndex = e.Column;
                ((ListView)sender).Sorting = SortOrder.Ascending;
            } 
            else 
                if(((ListView)sender).Sorting == SortOrder.Ascending)
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

        #endregion


        #region Constructor

        public SearchScreenBase()
        {
            InitializeComponent();
        }
        
        #endregion

    }
}
