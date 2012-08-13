namespace rkcrm.Base_Classes
{
	partial class ObjectListBase
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectListBase));
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnClearSearch = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.cboSearchIn = new System.Windows.Forms.ComboBox();
			this.lblSearchIn = new System.Windows.Forms.Label();
			this.txtLookFor = new System.Windows.Forms.TextBox();
			this.lblLookFor = new System.Windows.Forms.Label();
			this.lvwResults = new System.Windows.Forms.ListView();
			this.lblMessage = new System.Windows.Forms.Label();
			this.pnlFooter.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.pnlButtons);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 212);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(684, 50);
			this.pnlFooter.TabIndex = 1;
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnOK);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButtons.Location = new System.Drawing.Point(484, 0);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(200, 50);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(113, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(32, 10);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 30);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
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
			this.pnlHeader.TabIndex = 2;
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
			// lvwResults
			// 
			this.lvwResults.AllowColumnReorder = true;
			this.lvwResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwResults.FullRowSelect = true;
			this.lvwResults.HideSelection = false;
			this.lvwResults.Location = new System.Drawing.Point(0, 60);
			this.lvwResults.MultiSelect = false;
			this.lvwResults.Name = "lvwResults";
			this.lvwResults.Size = new System.Drawing.Size(684, 152);
			this.lvwResults.TabIndex = 3;
			this.lvwResults.UseCompatibleStateImageBehavior = false;
			this.lvwResults.View = System.Windows.Forms.View.Details;
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.BackColor = System.Drawing.Color.White;
			this.lblMessage.Location = new System.Drawing.Point(291, 125);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(103, 13);
			this.lblMessage.TabIndex = 11;
			this.lblMessage.Text = "Message goes here.";
			this.lblMessage.Visible = false;
			this.lblMessage.VisibleChanged += new System.EventHandler(this.lblMessage_VisibleChanged);
			this.lblMessage.TextChanged += new System.EventHandler(this.lblMessage_TextChanged);
			// 
			// ObjectListBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 262);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.lvwResults);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.pnlFooter);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(700, 300);
			this.Name = "ObjectListBase";
			this.Text = "R&K CRM";
			this.pnlFooter.ResumeLayout(false);
			this.pnlButtons.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlFooter;
		internal System.Windows.Forms.Panel pnlHeader;
		internal System.Windows.Forms.Label lblTitle;
		internal System.Windows.Forms.Label lblSearchIn;
		internal System.Windows.Forms.TextBox txtLookFor;
		internal System.Windows.Forms.Label lblLookFor;
		private System.Windows.Forms.Panel pnlButtons;
		public System.Windows.Forms.Button btnClearSearch;
		public System.Windows.Forms.Button btnSearch;
		public System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Button btnOK;
		public System.Windows.Forms.ListView lvwResults;
		private System.Windows.Forms.Label lblMessage;
		public System.Windows.Forms.ComboBox cboSearchIn;
	}
}