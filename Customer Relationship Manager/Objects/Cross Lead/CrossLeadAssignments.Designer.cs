namespace rkcrm.Objects.Cross_Lead
{
	partial class CrossLeadAssignments
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrossLeadAssignments));
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbUnassigned = new System.Windows.Forms.ToolStripButton();
			this.tsbAssigned = new System.Windows.Forms.ToolStripButton();
			this.tsbCompleted = new System.Windows.Forms.ToolStripSplitButton();
			this.tsmLast30 = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmLast60 = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmLast90 = new System.Windows.Forms.ToolStripMenuItem();
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmViewAll = new System.Windows.Forms.ToolStripMenuItem();
			this.tscDepartment = new System.Windows.Forms.ToolStripComboBox();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSendClose = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlControls = new System.Windows.Forms.Panel();
			this.notePreview1 = new rkcrm.Objects.Cross_Lead.Preview_Controls.NotePreview();
			this.quotePreview1 = new rkcrm.Objects.Cross_Lead.Preview_Controls.QuotePreview();
			this.projectPreview1 = new rkcrm.Objects.Cross_Lead.Preview_Controls.ProjectPreview();
			this.customerPreview1 = new rkcrm.Objects.Cross_Lead.Preview_Controls.CustomerPreview();
			this.crossLeadPreview1 = new rkcrm.Objects.Cross_Lead.Preview_Controls.CrossLeadPreview();
			this.spcControls = new System.Windows.Forms.SplitContainer();
			this.dgvCrossLeads = new System.Windows.Forms.DataGridView();
			this.AssignedTo = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.PlansReceived = new rkcrm.Custom_Controls.DataGridViewCalendarColumn();
			this.ExpectedCompletion = new rkcrm.Custom_Controls.DataGridViewCalendarColumn();
			this.Received = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.assigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FirstContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Delivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LeadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calendarColumn1 = new rkcrm.Custom_Controls.DataGridViewCalendarColumn();
			this.calendarColumn2 = new rkcrm.Custom_Controls.DataGridViewCalendarColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tsMain.SuspendLayout();
			this.pnlFooter.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.pnlControls.SuspendLayout();
			this.spcControls.Panel1.SuspendLayout();
			this.spcControls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCrossLeads)).BeginInit();
			this.SuspendLayout();
			// 
			// tsMain
			// 
			this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUnassigned,
            this.tsbAssigned,
            this.tsbCompleted,
            this.tscDepartment});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(659, 39);
			this.tsMain.TabIndex = 1;
			this.tsMain.Text = "ToolStrip1";
			// 
			// tsbUnassigned
			// 
			this.tsbUnassigned.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbUnassigned.Image = global::rkcrm.Properties.Resources.Unassigned_Icon;
			this.tsbUnassigned.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUnassigned.Name = "tsbUnassigned";
			this.tsbUnassigned.Size = new System.Drawing.Size(36, 36);
			this.tsbUnassigned.Text = "View Unassigned";
			this.tsbUnassigned.Click += new System.EventHandler(this.tsbUnassigned_Click);
			// 
			// tsbAssigned
			// 
			this.tsbAssigned.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAssigned.Image = global::rkcrm.Properties.Resources.Assigned_Icon;
			this.tsbAssigned.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAssigned.Name = "tsbAssigned";
			this.tsbAssigned.Size = new System.Drawing.Size(36, 36);
			this.tsbAssigned.Text = "View Assigned";
			this.tsbAssigned.Click += new System.EventHandler(this.tsbAssigned_Click);
			// 
			// tsbCompleted
			// 
			this.tsbCompleted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCompleted.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLast30,
            this.tsmLast60,
            this.tsmLast90,
            this.tss_0,
            this.tsmViewAll});
			this.tsbCompleted.Image = global::rkcrm.Properties.Resources.Completed_Icon;
			this.tsbCompleted.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCompleted.Name = "tsbCompleted";
			this.tsbCompleted.Size = new System.Drawing.Size(48, 36);
			this.tsbCompleted.Text = "View Completed";
			this.tsbCompleted.ButtonClick += new System.EventHandler(this.tsbCompleted_ButtonClick);
			// 
			// tsmLast30
			// 
			this.tsmLast30.Checked = true;
			this.tsmLast30.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsmLast30.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmLast30.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsmLast30.Name = "tsmLast30";
			this.tsmLast30.Size = new System.Drawing.Size(138, 22);
			this.tsmLast30.Text = "Last 30 Days";
			this.tsmLast30.ToolTipText = "View all cross leads received in the last 30 days";
			this.tsmLast30.Click += new System.EventHandler(this.tsmLast30_Click);
			// 
			// tsmLast60
			// 
			this.tsmLast60.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmLast60.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsmLast60.Name = "tsmLast60";
			this.tsmLast60.Size = new System.Drawing.Size(138, 22);
			this.tsmLast60.Text = "Last 60 Days";
			this.tsmLast60.Click += new System.EventHandler(this.tsmLast60_Click);
			// 
			// tsmLast90
			// 
			this.tsmLast90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmLast90.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsmLast90.Name = "tsmLast90";
			this.tsmLast90.Size = new System.Drawing.Size(138, 22);
			this.tsmLast90.Text = "Last 90 Days";
			this.tsmLast90.Click += new System.EventHandler(this.tsmLast90_Click);
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(135, 6);
			// 
			// tsmViewAll
			// 
			this.tsmViewAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmViewAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsmViewAll.Name = "tsmViewAll";
			this.tsmViewAll.Size = new System.Drawing.Size(138, 22);
			this.tsmViewAll.Text = "View All";
			this.tsmViewAll.Click += new System.EventHandler(this.tsmViewAll_Click);
			// 
			// tscDepartment
			// 
			this.tscDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.tscDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.tscDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tscDepartment.Name = "tscDepartment";
			this.tscDepartment.Size = new System.Drawing.Size(121, 39);
			this.tscDepartment.SelectedIndexChanged += new System.EventHandler(this.tscDepartment_SelectedIndexChanged);
			// 
			// pnlFooter
			// 
			this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFooter.Controls.Add(this.pnlButtons);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 527);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(659, 50);
			this.pnlFooter.TabIndex = 4;
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnSendClose);
			this.pnlButtons.Controls.Add(this.btnSend);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButtons.Location = new System.Drawing.Point(328, 0);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(329, 48);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(243, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSendClose
			// 
			this.btnSendClose.Location = new System.Drawing.Point(98, 10);
			this.btnSendClose.Name = "btnSendClose";
			this.btnSendClose.Size = new System.Drawing.Size(80, 30);
			this.btnSendClose.TabIndex = 1;
			this.btnSendClose.Text = "Send && Close";
			this.btnSendClose.UseVisualStyleBackColor = true;
			this.btnSendClose.Click += new System.EventHandler(this.btnSendClose_Click);
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(17, 10);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 30);
			this.btnSend.TabIndex = 0;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 39);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(659, 50);
			this.pnlHeader.TabIndex = 5;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(10, 16);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(185, 18);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Unassigned Cross Leads";
			// 
			// pnlControls
			// 
			this.pnlControls.AutoScroll = true;
			this.pnlControls.Controls.Add(this.notePreview1);
			this.pnlControls.Controls.Add(this.quotePreview1);
			this.pnlControls.Controls.Add(this.projectPreview1);
			this.pnlControls.Controls.Add(this.customerPreview1);
			this.pnlControls.Controls.Add(this.crossLeadPreview1);
			this.pnlControls.Controls.Add(this.spcControls);
			this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlControls.Location = new System.Drawing.Point(0, 89);
			this.pnlControls.Name = "pnlControls";
			this.pnlControls.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
			this.pnlControls.Size = new System.Drawing.Size(659, 438);
			this.pnlControls.TabIndex = 6;
			// 
			// notePreview1
			// 
			this.notePreview1.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePreview1.ExpandedHeight = 200;
			this.notePreview1.IsExpanded = false;
			this.notePreview1.Location = new System.Drawing.Point(5, 297);
			this.notePreview1.Name = "notePreview1";
			this.notePreview1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.notePreview1.Size = new System.Drawing.Size(649, 27);
			this.notePreview1.TabIndex = 19;
			this.notePreview1.Title = "Notes";
			// 
			// quotePreview1
			// 
			this.quotePreview1.Dock = System.Windows.Forms.DockStyle.Top;
			this.quotePreview1.ExpandedHeight = 150;
			this.quotePreview1.IsExpanded = false;
			this.quotePreview1.Location = new System.Drawing.Point(5, 270);
			this.quotePreview1.Name = "quotePreview1";
			this.quotePreview1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.quotePreview1.Size = new System.Drawing.Size(649, 27);
			this.quotePreview1.TabIndex = 18;
			this.quotePreview1.Title = "Quotes";
			// 
			// projectPreview1
			// 
			this.projectPreview1.Address = "";
			this.projectPreview1.Apt = "";
			this.projectPreview1.City = "";
			this.projectPreview1.ContactName = "";
			this.projectPreview1.Dock = System.Windows.Forms.DockStyle.Top;
			this.projectPreview1.ExpandedHeight = 185;
			this.projectPreview1.IsExpanded = false;
			this.projectPreview1.Location = new System.Drawing.Point(5, 243);
			this.projectPreview1.Name = "projectPreview1";
			this.projectPreview1.PhoneNumber = "";
			this.projectPreview1.ProjectName = "";
			this.projectPreview1.ProjectType = "";
			this.projectPreview1.Size = new System.Drawing.Size(649, 27);
			this.projectPreview1.State = "";
			this.projectPreview1.TabIndex = 17;
			this.projectPreview1.Title = "Project";
			this.projectPreview1.ZipCode = "";
			// 
			// customerPreview1
			// 
			this.customerPreview1.CustomerName = "";
			this.customerPreview1.CustomerType = "";
			this.customerPreview1.Dock = System.Windows.Forms.DockStyle.Top;
			this.customerPreview1.ExpandedHeight = 85;
			this.customerPreview1.IsExpanded = false;
			this.customerPreview1.Location = new System.Drawing.Point(5, 216);
			this.customerPreview1.Name = "customerPreview1";
			this.customerPreview1.PhoneNumber = "";
			this.customerPreview1.Size = new System.Drawing.Size(649, 27);
			this.customerPreview1.TabIndex = 16;
			this.customerPreview1.Title = "Customer";
			// 
			// crossLeadPreview1
			// 
			this.crossLeadPreview1.BidDue = "";
			this.crossLeadPreview1.ContactCustomer = false;
			this.crossLeadPreview1.DigitalPlansAvailable = false;
			this.crossLeadPreview1.Dock = System.Windows.Forms.DockStyle.Top;
			this.crossLeadPreview1.ExpandedHeight = 236;
			this.crossLeadPreview1.HasMaterialList = false;
			this.crossLeadPreview1.IsExpanded = false;
			this.crossLeadPreview1.Location = new System.Drawing.Point(5, 189);
			this.crossLeadPreview1.Name = "crossLeadPreview1";
			this.crossLeadPreview1.Notes = "";
			this.crossLeadPreview1.PaperPlansAvailable = false;
			this.crossLeadPreview1.PlanID = 0;
			this.crossLeadPreview1.Size = new System.Drawing.Size(649, 27);
			this.crossLeadPreview1.TabIndex = 15;
			this.crossLeadPreview1.Title = "Cross Lead";
			// 
			// spcControls
			// 
			this.spcControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.spcControls.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spcControls.Location = new System.Drawing.Point(5, 3);
			this.spcControls.Name = "spcControls";
			this.spcControls.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// spcControls.Panel1
			// 
			this.spcControls.Panel1.Controls.Add(this.dgvCrossLeads);
			this.spcControls.Panel1MinSize = 180;
			this.spcControls.Panel2MinSize = 0;
			this.spcControls.Size = new System.Drawing.Size(649, 186);
			this.spcControls.SplitterDistance = 180;
			this.spcControls.TabIndex = 10;
			this.spcControls.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.spcControls_SplitterMoved);
			// 
			// dgvCrossLeads
			// 
			this.dgvCrossLeads.AllowUserToAddRows = false;
			this.dgvCrossLeads.AllowUserToDeleteRows = false;
			this.dgvCrossLeads.AllowUserToResizeRows = false;
			this.dgvCrossLeads.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvCrossLeads.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvCrossLeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCrossLeads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AssignedTo,
            this.PlansReceived,
            this.ExpectedCompletion,
            this.Received,
            this.Sender,
            this.assigned,
            this.FirstContact,
            this.Delivered,
            this.CustomerID,
            this.ProjectID,
            this.LeadID,
            this.DepartmentID});
			this.dgvCrossLeads.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCrossLeads.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvCrossLeads.Location = new System.Drawing.Point(0, 0);
			this.dgvCrossLeads.MultiSelect = false;
			this.dgvCrossLeads.Name = "dgvCrossLeads";
			this.dgvCrossLeads.RowHeadersVisible = false;
			this.dgvCrossLeads.Size = new System.Drawing.Size(649, 180);
			this.dgvCrossLeads.TabIndex = 3;
			this.dgvCrossLeads.CurrentCellChanged += new System.EventHandler(this.dgvCrossLeads_CurrentCellChanged);
			this.dgvCrossLeads.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCrossLeads_CurrentCellDirtyStateChanged);
			// 
			// AssignedTo
			// 
			this.AssignedTo.HeaderText = "Assigned To";
			this.AssignedTo.Name = "AssignedTo";
			this.AssignedTo.Width = 125;
			// 
			// PlansReceived
			// 
			this.PlansReceived.HeaderText = "Plans Received";
			this.PlansReceived.Name = "PlansReceived";
			// 
			// ExpectedCompletion
			// 
			this.ExpectedCompletion.HeaderText = "Expected Completion";
			this.ExpectedCompletion.Name = "ExpectedCompletion";
			// 
			// Received
			// 
			this.Received.HeaderText = "Received Notice";
			this.Received.Name = "Received";
			this.Received.ReadOnly = true;
			// 
			// Sender
			// 
			this.Sender.HeaderText = "Sender";
			this.Sender.Name = "Sender";
			this.Sender.ReadOnly = true;
			// 
			// assigned
			// 
			this.assigned.HeaderText = "Assigned";
			this.assigned.Name = "assigned";
			this.assigned.ReadOnly = true;
			this.assigned.Width = 90;
			// 
			// FirstContact
			// 
			this.FirstContact.HeaderText = "First Contact";
			this.FirstContact.Name = "FirstContact";
			this.FirstContact.ReadOnly = true;
			this.FirstContact.Width = 90;
			// 
			// Delivered
			// 
			this.Delivered.HeaderText = "Quote Delivered";
			this.Delivered.Name = "Delivered";
			this.Delivered.ReadOnly = true;
			this.Delivered.Width = 90;
			// 
			// CustomerID
			// 
			this.CustomerID.HeaderText = "Customer ID";
			this.CustomerID.Name = "CustomerID";
			this.CustomerID.Visible = false;
			// 
			// ProjectID
			// 
			this.ProjectID.HeaderText = "Project ID";
			this.ProjectID.Name = "ProjectID";
			this.ProjectID.Visible = false;
			// 
			// LeadID
			// 
			this.LeadID.HeaderText = "Lead ID";
			this.LeadID.Name = "LeadID";
			this.LeadID.ReadOnly = true;
			this.LeadID.Visible = false;
			// 
			// DepartmentID
			// 
			this.DepartmentID.HeaderText = "Department ID";
			this.DepartmentID.Name = "DepartmentID";
			this.DepartmentID.ReadOnly = true;
			this.DepartmentID.Visible = false;
			// 
			// calendarColumn1
			// 
			this.calendarColumn1.HeaderText = "Plans Received";
			this.calendarColumn1.Name = "calendarColumn1";
			// 
			// calendarColumn2
			// 
			this.calendarColumn2.HeaderText = "Expected Completion";
			this.calendarColumn2.Name = "calendarColumn2";
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Received Notice";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "Sender";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "Assigned";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "First Contact";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.HeaderText = "Quote Delivered";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.HeaderText = "Customer ID";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.Visible = false;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.HeaderText = "Project ID";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Visible = false;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.HeaderText = "Relationship ID";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.Visible = false;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.HeaderText = "Lead ID";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Visible = false;
			// 
			// CrossLeadAssignments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(659, 577);
			this.Controls.Add(this.pnlControls);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.tsMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CrossLeadAssignments";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cross Lead Assigments";
			this.Load += new System.EventHandler(this.CrossLeadAssignments_Load);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.pnlFooter.ResumeLayout(false);
			this.pnlButtons.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlControls.ResumeLayout(false);
			this.spcControls.Panel1.ResumeLayout(false);
			this.spcControls.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCrossLeads)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ToolStrip tsMain;
		internal System.Windows.Forms.ToolStripButton tsbUnassigned;
		internal System.Windows.Forms.ToolStripButton tsbAssigned;
		internal System.Windows.Forms.ToolStripSplitButton tsbCompleted;
		internal System.Windows.Forms.ToolStripMenuItem tsmLast30;
		internal System.Windows.Forms.ToolStripMenuItem tsmLast60;
		internal System.Windows.Forms.ToolStripMenuItem tsmLast90;
		internal System.Windows.Forms.ToolStripSeparator tss_0;
		internal System.Windows.Forms.ToolStripMenuItem tsmViewAll;
		internal System.Windows.Forms.ToolStripComboBox tscDepartment;
		internal System.Windows.Forms.Panel pnlFooter;
		internal System.Windows.Forms.Panel pnlButtons;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnSendClose;
		internal System.Windows.Forms.Button btnSend;
		internal System.Windows.Forms.Panel pnlHeader;
		internal System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel pnlControls;
		private System.Windows.Forms.SplitContainer spcControls;
		private rkcrm.Objects.Cross_Lead.Preview_Controls.NotePreview notePreview1;
		private rkcrm.Objects.Cross_Lead.Preview_Controls.QuotePreview quotePreview1;
		private rkcrm.Objects.Cross_Lead.Preview_Controls.ProjectPreview projectPreview1;
		private rkcrm.Objects.Cross_Lead.Preview_Controls.CustomerPreview customerPreview1;
		private rkcrm.Objects.Cross_Lead.Preview_Controls.CrossLeadPreview crossLeadPreview1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		internal System.Windows.Forms.DataGridView dgvCrossLeads;
		private rkcrm.Custom_Controls.DataGridViewCalendarColumn calendarColumn1;
		private rkcrm.Custom_Controls.DataGridViewCalendarColumn calendarColumn2;
		private System.Windows.Forms.DataGridViewComboBoxColumn AssignedTo;
		private rkcrm.Custom_Controls.DataGridViewCalendarColumn PlansReceived;
		private rkcrm.Custom_Controls.DataGridViewCalendarColumn ExpectedCompletion;
		private System.Windows.Forms.DataGridViewTextBoxColumn Received;
		private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
		private System.Windows.Forms.DataGridViewTextBoxColumn assigned;
		private System.Windows.Forms.DataGridViewTextBoxColumn FirstContact;
		private System.Windows.Forms.DataGridViewTextBoxColumn Delivered;
		private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProjectID;
		private System.Windows.Forms.DataGridViewTextBoxColumn LeadID;
		private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentID;

	}
}