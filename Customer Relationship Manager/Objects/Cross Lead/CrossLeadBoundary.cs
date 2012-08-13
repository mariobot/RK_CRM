using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.Department;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Cross_Lead
{
	class CrossLeadBoundary : BoundaryBase
	{
		private GroupBox gbxDepartments;
		internal GroupBox gbxBiddingInfo;
		internal CheckBox chkAskCustomer;
		internal CheckBox chkIsMaterialsListAvailable;
		internal CheckBox chkIsDigitalPlanAvailable;
		internal CheckBox chkIsPaperPlanAvailable;
		internal Label lblBidDue;
		internal TextBox txtNotes;
		internal Label lblNotes;
		internal GroupBox gbxPreviousLeads;
		internal ListView lvwPreviousLeads;
		internal ColumnHeader chLeadID;
		internal ColumnHeader chDepartment;
		internal ColumnHeader chSalesRep;
		internal ListBox lbxDepartments;

		private Project.Project clsMyProject;
		private MaskedTextBox mtxtBidDue;
		private ColumnHeader chAssignedTo;
		internal TextBox txtTrackingID;
		internal Label lblTrackingID;
		private CrossLead clsMyCrossLead;
		private int difference;

		#region Properties

		public Project.Project MyProject
		{
			get { return clsMyProject; }
			set 
			{ 
				clsMyProject = value;

				if (value != null)
					LoadList();

				if (clsMyCrossLead != null)
					clsMyCrossLead.ProjectID = clsMyProject.ID;
			}
		}

		public CrossLead MyCrossLead
		{
			get { return clsMyCrossLead; }
			set 
			{
				if (clsMyCrossLead != value && clsMyCrossLead != null)
					clsMyCrossLead.Dispose();
				
				clsMyCrossLead = value;

				if (value != null)
					SetAddingMode();

				if (clsMyProject != null)
					clsMyCrossLead.ProjectID = clsMyProject.ID;

				OnMyCrossLeadChanged(new EventArgs());
			}
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.gbxDepartments = new System.Windows.Forms.GroupBox();
			this.lbxDepartments = new System.Windows.Forms.ListBox();
			this.gbxBiddingInfo = new System.Windows.Forms.GroupBox();
			this.chkAskCustomer = new System.Windows.Forms.CheckBox();
			this.chkIsMaterialsListAvailable = new System.Windows.Forms.CheckBox();
			this.chkIsDigitalPlanAvailable = new System.Windows.Forms.CheckBox();
			this.chkIsPaperPlanAvailable = new System.Windows.Forms.CheckBox();
			this.lblBidDue = new System.Windows.Forms.Label();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.lblNotes = new System.Windows.Forms.Label();
			this.gbxPreviousLeads = new System.Windows.Forms.GroupBox();
			this.lvwPreviousLeads = new System.Windows.Forms.ListView();
			this.chLeadID = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chSalesRep = new System.Windows.Forms.ColumnHeader();
			this.chAssignedTo = new System.Windows.Forms.ColumnHeader();
			this.mtxtBidDue = new System.Windows.Forms.MaskedTextBox();
			this.txtTrackingID = new System.Windows.Forms.TextBox();
			this.lblTrackingID = new System.Windows.Forms.Label();
			this.pnlControls.SuspendLayout();
			this.gbxDepartments.SuspendLayout();
			this.gbxBiddingInfo.SuspendLayout();
			this.gbxPreviousLeads.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.txtTrackingID);
			this.pnlControls.Controls.Add(this.lblTrackingID);
			this.pnlControls.Controls.Add(this.mtxtBidDue);
			this.pnlControls.Controls.Add(this.gbxPreviousLeads);
			this.pnlControls.Controls.Add(this.lblBidDue);
			this.pnlControls.Controls.Add(this.txtNotes);
			this.pnlControls.Controls.Add(this.lblNotes);
			this.pnlControls.Controls.Add(this.gbxBiddingInfo);
			this.pnlControls.Controls.Add(this.gbxDepartments);
			this.pnlControls.Size = new System.Drawing.Size(557, 410);
			// 
			// gbxDepartments
			// 
			this.gbxDepartments.Controls.Add(this.lbxDepartments);
			this.gbxDepartments.Location = new System.Drawing.Point(14, 12);
			this.gbxDepartments.Name = "gbxDepartments";
			this.gbxDepartments.Size = new System.Drawing.Size(162, 89);
			this.gbxDepartments.TabIndex = 0;
			this.gbxDepartments.TabStop = false;
			this.gbxDepartments.Text = "Select Departments To Notify";
			// 
			// lbxDepartments
			// 
			this.lbxDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbxDepartments.FormattingEnabled = true;
			this.lbxDepartments.Location = new System.Drawing.Point(3, 16);
			this.lbxDepartments.Name = "lbxDepartments";
			this.lbxDepartments.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbxDepartments.Size = new System.Drawing.Size(156, 69);
			this.lbxDepartments.TabIndex = 0;
			this.lbxDepartments.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// gbxBiddingInfo
			// 
			this.gbxBiddingInfo.Controls.Add(this.chkAskCustomer);
			this.gbxBiddingInfo.Controls.Add(this.chkIsMaterialsListAvailable);
			this.gbxBiddingInfo.Controls.Add(this.chkIsDigitalPlanAvailable);
			this.gbxBiddingInfo.Controls.Add(this.chkIsPaperPlanAvailable);
			this.gbxBiddingInfo.Location = new System.Drawing.Point(182, 12);
			this.gbxBiddingInfo.Name = "gbxBiddingInfo";
			this.gbxBiddingInfo.Size = new System.Drawing.Size(357, 89);
			this.gbxBiddingInfo.TabIndex = 7;
			this.gbxBiddingInfo.TabStop = false;
			this.gbxBiddingInfo.Text = "Bidding Information";
			// 
			// chkAskCustomer
			// 
			this.chkAskCustomer.AutoSize = true;
			this.chkAskCustomer.Location = new System.Drawing.Point(179, 57);
			this.chkAskCustomer.Name = "chkAskCustomer";
			this.chkAskCustomer.Size = new System.Drawing.Size(175, 17);
			this.chkAskCustomer.TabIndex = 8;
			this.chkAskCustomer.Text = "Contact the customer for details";
			this.chkAskCustomer.UseVisualStyleBackColor = true;
			this.chkAskCustomer.CheckedChanged += new System.EventHandler(this.control_Changed);
			// 
			// chkIsMaterialsListAvailable
			// 
			this.chkIsMaterialsListAvailable.AutoSize = true;
			this.chkIsMaterialsListAvailable.Location = new System.Drawing.Point(179, 26);
			this.chkIsMaterialsListAvailable.Name = "chkIsMaterialsListAvailable";
			this.chkIsMaterialsListAvailable.Size = new System.Drawing.Size(147, 17);
			this.chkIsMaterialsListAvailable.TabIndex = 7;
			this.chkIsMaterialsListAvailable.Text = "A materials list is available";
			this.chkIsMaterialsListAvailable.UseVisualStyleBackColor = true;
			this.chkIsMaterialsListAvailable.CheckedChanged += new System.EventHandler(this.control_Changed);
			// 
			// chkIsDigitalPlanAvailable
			// 
			this.chkIsDigitalPlanAvailable.AutoSize = true;
			this.chkIsDigitalPlanAvailable.Location = new System.Drawing.Point(18, 57);
			this.chkIsDigitalPlanAvailable.Name = "chkIsDigitalPlanAvailable";
			this.chkIsDigitalPlanAvailable.Size = new System.Drawing.Size(146, 17);
			this.chkIsDigitalPlanAvailable.TabIndex = 6;
			this.chkIsDigitalPlanAvailable.Text = "Digital plans are available";
			this.chkIsDigitalPlanAvailable.UseVisualStyleBackColor = true;
			this.chkIsDigitalPlanAvailable.CheckedChanged += new System.EventHandler(this.control_Changed);
			// 
			// chkIsPaperPlanAvailable
			// 
			this.chkIsPaperPlanAvailable.AutoSize = true;
			this.chkIsPaperPlanAvailable.Location = new System.Drawing.Point(18, 26);
			this.chkIsPaperPlanAvailable.Name = "chkIsPaperPlanAvailable";
			this.chkIsPaperPlanAvailable.Size = new System.Drawing.Size(145, 17);
			this.chkIsPaperPlanAvailable.TabIndex = 5;
			this.chkIsPaperPlanAvailable.Text = "Paper plans are available";
			this.chkIsPaperPlanAvailable.UseVisualStyleBackColor = true;
			this.chkIsPaperPlanAvailable.CheckedChanged += new System.EventHandler(this.chkIsPaperPlanAvailable_CheckedChanged);
			// 
			// lblBidDue
			// 
			this.lblBidDue.AutoSize = true;
			this.lblBidDue.Location = new System.Drawing.Point(45, 146);
			this.lblBidDue.Name = "lblBidDue";
			this.lblBidDue.Size = new System.Drawing.Size(63, 13);
			this.lblBidDue.TabIndex = 11;
			this.lblBidDue.Text = "Bid Due By:";
			// 
			// txtNotes
			// 
			this.txtNotes.Location = new System.Drawing.Point(14, 193);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new System.Drawing.Size(525, 63);
			this.txtNotes.TabIndex = 10;
			this.txtNotes.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblNotes
			// 
			this.lblNotes.AutoSize = true;
			this.lblNotes.Location = new System.Drawing.Point(11, 177);
			this.lblNotes.Name = "lblNotes";
			this.lblNotes.Size = new System.Drawing.Size(84, 13);
			this.lblNotes.TabIndex = 9;
			this.lblNotes.Text = "Additional Notes";
			// 
			// gbxPreviousLeads
			// 
			this.gbxPreviousLeads.Controls.Add(this.lvwPreviousLeads);
			this.gbxPreviousLeads.Location = new System.Drawing.Point(14, 275);
			this.gbxPreviousLeads.Name = "gbxPreviousLeads";
			this.gbxPreviousLeads.Size = new System.Drawing.Size(525, 129);
			this.gbxPreviousLeads.TabIndex = 13;
			this.gbxPreviousLeads.TabStop = false;
			this.gbxPreviousLeads.Text = "Previous Cross Leads";
			// 
			// lvwPreviousLeads
			// 
			this.lvwPreviousLeads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLeadID,
            this.chDepartment,
            this.chSalesRep,
            this.chAssignedTo});
			this.lvwPreviousLeads.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwPreviousLeads.Location = new System.Drawing.Point(3, 16);
			this.lvwPreviousLeads.Name = "lvwPreviousLeads";
			this.lvwPreviousLeads.Size = new System.Drawing.Size(519, 110);
			this.lvwPreviousLeads.TabIndex = 0;
			this.lvwPreviousLeads.UseCompatibleStateImageBehavior = false;
			this.lvwPreviousLeads.View = System.Windows.Forms.View.Details;
			// 
			// chLeadID
			// 
			this.chLeadID.Text = "Lead ID";
			this.chLeadID.Width = 0;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 80;
			// 
			// chSalesRep
			// 
			this.chSalesRep.Text = "Sales Rep";
			this.chSalesRep.Width = 160;
			// 
			// chAssignedTo
			// 
			this.chAssignedTo.Text = "Assigned To";
			this.chAssignedTo.Width = 160;
			// 
			// mtxtBidDue
			// 
			this.mtxtBidDue.Location = new System.Drawing.Point(114, 143);
			this.mtxtBidDue.Mask = "00/00/00";
			this.mtxtBidDue.Name = "mtxtBidDue";
			this.mtxtBidDue.Size = new System.Drawing.Size(77, 20);
			this.mtxtBidDue.TabIndex = 14;
			this.mtxtBidDue.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// txtTrackingID
			// 
			this.txtTrackingID.Location = new System.Drawing.Point(114, 117);
			this.txtTrackingID.MaxLength = 5;
			this.txtTrackingID.Name = "txtTrackingID";
			this.txtTrackingID.Size = new System.Drawing.Size(78, 20);
			this.txtTrackingID.TabIndex = 16;
			this.txtTrackingID.Visible = false;
			// 
			// lblTrackingID
			// 
			this.lblTrackingID.AutoSize = true;
			this.lblTrackingID.Location = new System.Drawing.Point(11, 120);
			this.lblTrackingID.Name = "lblTrackingID";
			this.lblTrackingID.Size = new System.Drawing.Size(97, 13);
			this.lblTrackingID.TabIndex = 15;
			this.lblTrackingID.Text = "Plan Tracking ID* :";
			this.lblTrackingID.Visible = false;
			// 
			// CrossLeadBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScroll = true;
			this.ChangeHistoryVisible = false;
			this.MinimumSize = new System.Drawing.Size(557, 460);
			this.Name = "CrossLeadBoundary";
			this.Size = new System.Drawing.Size(557, 460);
			this.Title = "Cross Lead Notification";
			this.Load += new System.EventHandler(this.CrossLeadBoundary_Load);
			this.pnlControls.ResumeLayout(false);
			this.pnlControls.PerformLayout();
			this.gbxDepartments.ResumeLayout(false);
			this.gbxBiddingInfo.ResumeLayout(false);
			this.gbxBiddingInfo.PerformLayout();
			this.gbxPreviousLeads.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		private void LoadList()
		{
			using (CrossLeadController theController = new CrossLeadController())
			{
				ListViewItem newItem;

				foreach (DataRow oRow in theController.GetCrossLeads(MyProject.ID).Rows)
				{
					newItem = new ListViewItem();
					newItem.Text = oRow["lead_id"].ToString();
					newItem.SubItems.Add(oRow["department"].ToString());
					newItem.SubItems.Add(oRow["sender"].ToString());
					newItem.SubItems.Add(oRow["owner"].ToString());

					lvwPreviousLeads.Items.Add(newItem);
				}
			}
		}

		public bool CommitChanges()
		{
			try
			{
				if (lbxDepartments.SelectedItems.Count == 0)
					throw new Exception("Please select at least one department to notify.");
				if (chkIsPaperPlanAvailable.Checked && string.IsNullOrEmpty(txtTrackingID.Text))
					throw new Exception("The \"Plan Tracking ID*\" cannot be blank.");
				if (chkIsPaperPlanAvailable.Checked && txtTrackingID.TextLength < 5)
					throw new Exception("The \"*Plan Tracking ID\" must be a 5 digit number.");
				if (mtxtBidDue.MaskCompleted && Convert.ToDateTime(mtxtBidDue.Text) < DateTime.Today)
					throw new Exception("The \"Bid Due By\" field must be today or later");


				MyCrossLead.BidDue = !mtxtBidDue.MaskCompleted ? DateTime.MinValue : Convert.ToDateTime(mtxtBidDue.Text);
				MyCrossLead.CustomerHasDetails = chkAskCustomer.Checked;
				MyCrossLead.IsDigitalAvailable = chkIsDigitalPlanAvailable.Checked;
				MyCrossLead.IsListAvailable = chkIsMaterialsListAvailable.Checked;
				MyCrossLead.IsPaperAvailable = chkIsPaperPlanAvailable.Checked;
				MyCrossLead.PlanID = chkIsPaperPlanAvailable.Checked ? Convert.ToInt32(txtTrackingID.Text) : 0;
				MyCrossLead.Notes = txtNotes.Text;
				
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}

		private void SetAddingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			this.IsDirty = false;
			this.State = BoundaryState.Adding;
		}

		private new void Clear()
		{
			base.Clear();

			lbxDepartments.SelectedIndices.Clear();
			chkAskCustomer.Checked = false;
			chkIsDigitalPlanAvailable.Checked = false;
			chkIsMaterialsListAvailable.Checked = false;
			chkIsPaperPlanAvailable.Checked = false;
			mtxtBidDue.Clear();
			txtNotes.Clear();
			txtTrackingID.Clear();
		}

		#endregion


		#region Event Handlers

		private void CrossLeadBoundary_Load(object sender, EventArgs e)
		{
			BoundaryState current = this.State;
			this.State = BoundaryState.Loading;

			using (DepartmentController theController = new DepartmentController())
			{
				DataTable departments;

				if (MyProject != null)
					departments = theController.GetCrossLeadableDepartments(MyProject.ID);
				else
					departments = theController.GetProfitCenters();

				lbxDepartments.DataSource = departments;
				lbxDepartments.DisplayMember = "name";
				lbxDepartments.ValueMember = "department_id";
				lbxDepartments.SelectedItems.Clear();
			}

			this.State = current;
		}

		private void control_Changed(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Adding && !IsDirty)
				this.IsDirty = true;
		}

		private void chkIsPaperPlanAvailable_CheckedChanged(object sender, EventArgs e)
		{
			if (chkIsPaperPlanAvailable.Checked)
			{
				lblTrackingID.Visible = true;
				txtTrackingID.Visible = true;
				gbxPreviousLeads.Location = new System.Drawing.Point(gbxPreviousLeads.Location.X, gbxPreviousLeads.Location.Y + difference);
				lblBidDue.Location = new System.Drawing.Point(lblBidDue.Location.X, lblBidDue.Location.Y + difference);
				mtxtBidDue.Location = new System.Drawing.Point(mtxtBidDue.Location.X, mtxtBidDue.Location.Y + difference);
				lblNotes.Location = new System.Drawing.Point(lblNotes.Location.X, lblNotes.Location.Y + difference);
				txtNotes.Location = new System.Drawing.Point(txtNotes.Location.X, txtNotes.Location.Y + difference);
			}
			else
			{
				lblTrackingID.Visible = false;
				txtTrackingID.Visible = false;
				gbxPreviousLeads.Location = new System.Drawing.Point(gbxPreviousLeads.Location.X, gbxPreviousLeads.Location.Y - difference);
				lblBidDue.Location = new System.Drawing.Point(lblBidDue.Location.X, lblBidDue.Location.Y - difference);
				mtxtBidDue.Location = new System.Drawing.Point(mtxtBidDue.Location.X, mtxtBidDue.Location.Y - difference);
				lblNotes.Location = new System.Drawing.Point(lblNotes.Location.X, lblNotes.Location.Y - difference);
				txtNotes.Location = new System.Drawing.Point(txtNotes.Location.X, txtNotes.Location.Y - difference);
			}
		}

		#endregion


		#region Events

		public event EventHandler<EventArgs> MyCrossLeadChanged;
		protected virtual void OnMyCrossLeadChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = MyCrossLeadChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion

		#region Constructor

		public CrossLeadBoundary()
			: base()
		{
			InitializeComponent();

			difference = mtxtBidDue.Location.Y - txtTrackingID.Location.Y;
			chkIsPaperPlanAvailable.CheckedChanged += new EventHandler(control_Changed);

			gbxPreviousLeads.Location = new System.Drawing.Point(gbxPreviousLeads.Location.X, gbxPreviousLeads.Location.Y - difference);
			lblBidDue.Location = new System.Drawing.Point(lblBidDue.Location.X, lblBidDue.Location.Y - difference);
			mtxtBidDue.Location = new System.Drawing.Point(mtxtBidDue.Location.X, mtxtBidDue.Location.Y - difference);
			lblNotes.Location = new System.Drawing.Point(lblNotes.Location.X, lblNotes.Location.Y - difference);
			txtNotes.Location = new System.Drawing.Point(txtNotes.Location.X, txtNotes.Location.Y - difference);
		}

		#endregion

	}
}
