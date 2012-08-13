using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.Competitor;
using rkcrm.Administration.Lost_Reason;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Project.Lost_Report
{
	class LostProjectBoundary : BoundaryBase
	{

		#region Variables

		internal Label lblDepartment;
		internal ComboBox cboDepartment;
		internal Label lblCompetitorName;
		internal ComboBox cboCompetitor;
		internal Label lblComments;
		internal TextBox txtComments;
		internal Label lblReasonDetail;
		internal TextBox txtReasonDetails;
		internal Label lblReason;
		internal ComboBox cboReason;
		internal Label lblLostTo;
		internal TextBox txtCompetitorName;

		private int intMyProjectID;
		private const int JOB_CANCELLED = 7;
		private const int CUSTOMER_LOST_JOB = 8;
		private const int SOLD_ANOTHER_SCOPE = 10;
		private ToolTip CompetitorNameToolTip;
		private LostProjectReport clsMyLostProject;

		#endregion


		#region Properties

		public int SelectedDepartmentID
		{
			get
			{
				if (cboDepartment.SelectedItem != null)
					return Convert.ToInt32(cboDepartment.SelectedValue);
				else
					return 0;
			}
		}

		public int MyProjectID
		{
			get { return intMyProjectID; }
			set 
			{ 
				intMyProjectID = value;

				if (value > 0)
					LoadDepartments();
			}
		}

		public LostProjectReport MyLostProject
		{
			get { return clsMyLostProject; }
			set
			{
				if (clsMyLostProject != value && clsMyLostProject != null)
					clsMyLostProject.Dispose();

				clsMyLostProject = value;

				if (value == null)
					SetSearchingMode();
				else
				{
					if (value.ProjectID > 0 && value.DepartmentID > 0 && value.Scope > 0)
						SetEditingMode();
					else
						SetAddingMode();
				}
			}
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.lblDepartment = new System.Windows.Forms.Label();
			this.cboDepartment = new System.Windows.Forms.ComboBox();
			this.lblCompetitorName = new System.Windows.Forms.Label();
			this.cboCompetitor = new System.Windows.Forms.ComboBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.lblReasonDetail = new System.Windows.Forms.Label();
			this.txtReasonDetails = new System.Windows.Forms.TextBox();
			this.lblReason = new System.Windows.Forms.Label();
			this.cboReason = new System.Windows.Forms.ComboBox();
			this.lblLostTo = new System.Windows.Forms.Label();
			this.txtCompetitorName = new System.Windows.Forms.TextBox();
			this.pnlControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.lblDepartment);
			this.pnlControls.Controls.Add(this.cboDepartment);
			this.pnlControls.Controls.Add(this.lblCompetitorName);
			this.pnlControls.Controls.Add(this.cboCompetitor);
			this.pnlControls.Controls.Add(this.lblComments);
			this.pnlControls.Controls.Add(this.txtComments);
			this.pnlControls.Controls.Add(this.lblReasonDetail);
			this.pnlControls.Controls.Add(this.txtReasonDetails);
			this.pnlControls.Controls.Add(this.lblReason);
			this.pnlControls.Controls.Add(this.cboReason);
			this.pnlControls.Controls.Add(this.lblLostTo);
			this.pnlControls.Controls.Add(this.txtCompetitorName);
			this.pnlControls.Size = new System.Drawing.Size(475, 258);
			// 
			// lblDepartment
			// 
			this.lblDepartment.AutoSize = true;
			this.lblDepartment.Location = new System.Drawing.Point(11, 13);
			this.lblDepartment.Name = "lblDepartment";
			this.lblDepartment.Size = new System.Drawing.Size(66, 13);
			this.lblDepartment.TabIndex = 22;
			this.lblDepartment.Text = "Department*";
			// 
			// cboDepartment
			// 
			this.cboDepartment.FormattingEnabled = true;
			this.cboDepartment.Location = new System.Drawing.Point(17, 28);
			this.cboDepartment.Name = "cboDepartment";
			this.cboDepartment.Size = new System.Drawing.Size(145, 21);
			this.cboDepartment.TabIndex = 21;
			this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
			// 
			// lblCompetitorName
			// 
			this.lblCompetitorName.AutoSize = true;
			this.lblCompetitorName.Location = new System.Drawing.Point(165, 111);
			this.lblCompetitorName.Name = "lblCompetitorName";
			this.lblCompetitorName.Size = new System.Drawing.Size(99, 13);
			this.lblCompetitorName.TabIndex = 20;
			this.lblCompetitorName.Text = "Competitor\'s Name*";
			this.lblCompetitorName.Visible = false;
			this.lblCompetitorName.MouseHover += new System.EventHandler(this.CompetitorName_MouseHover);
			// 
			// cboCompetitor
			// 
			this.cboCompetitor.FormattingEnabled = true;
			this.cboCompetitor.Location = new System.Drawing.Point(15, 126);
			this.cboCompetitor.Name = "cboCompetitor";
			this.cboCompetitor.Size = new System.Drawing.Size(147, 21);
			this.cboCompetitor.TabIndex = 14;
			this.cboCompetitor.SelectedIndexChanged += new System.EventHandler(this.cboCompetitor_SelectedIndexChanged);
			// 
			// lblComments
			// 
			this.lblComments.AutoSize = true;
			this.lblComments.Location = new System.Drawing.Point(11, 162);
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(56, 13);
			this.lblComments.TabIndex = 19;
			this.lblComments.Text = "Comments";
			// 
			// txtComments
			// 
			this.txtComments.Location = new System.Drawing.Point(14, 178);
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(444, 64);
			this.txtComments.TabIndex = 17;
			// 
			// lblReasonDetail
			// 
			this.lblReasonDetail.AutoSize = true;
			this.lblReasonDetail.Location = new System.Drawing.Point(165, 63);
			this.lblReasonDetail.Name = "lblReasonDetail";
			this.lblReasonDetail.Size = new System.Drawing.Size(39, 13);
			this.lblReasonDetail.TabIndex = 18;
			this.lblReasonDetail.Text = "Details";
			// 
			// txtReasonDetails
			// 
			this.txtReasonDetails.Location = new System.Drawing.Point(168, 79);
			this.txtReasonDetails.Name = "txtReasonDetails";
			this.txtReasonDetails.Size = new System.Drawing.Size(290, 20);
			this.txtReasonDetails.TabIndex = 12;
			// 
			// lblReason
			// 
			this.lblReason.AutoSize = true;
			this.lblReason.Location = new System.Drawing.Point(11, 63);
			this.lblReason.Name = "lblReason";
			this.lblReason.Size = new System.Drawing.Size(48, 13);
			this.lblReason.TabIndex = 16;
			this.lblReason.Text = "Reason*";
			// 
			// cboReason
			// 
			this.cboReason.FormattingEnabled = true;
			this.cboReason.Location = new System.Drawing.Point(17, 78);
			this.cboReason.Name = "cboReason";
			this.cboReason.Size = new System.Drawing.Size(145, 21);
			this.cboReason.TabIndex = 11;
			this.cboReason.SelectedIndexChanged += new System.EventHandler(this.cboReason_SelectedIndexChanged);
			// 
			// lblLostTo
			// 
			this.lblLostTo.AutoSize = true;
			this.lblLostTo.Location = new System.Drawing.Point(14, 111);
			this.lblLostTo.Name = "lblLostTo";
			this.lblLostTo.Size = new System.Drawing.Size(74, 13);
			this.lblLostTo.TabIndex = 13;
			this.lblLostTo.Text = "Sale Lost To:*";
			// 
			// txtCompetitorName
			// 
			this.txtCompetitorName.Location = new System.Drawing.Point(168, 127);
			this.txtCompetitorName.Name = "txtCompetitorName";
			this.txtCompetitorName.Size = new System.Drawing.Size(290, 20);
			this.txtCompetitorName.TabIndex = 15;
			this.txtCompetitorName.Visible = false;
			this.txtCompetitorName.MouseHover += new System.EventHandler(this.CompetitorName_MouseHover);
			// 
			// LostProjectBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ChangeHistoryVisible = false;
			this.Name = "LostProjectBoundary";
			this.Size = new System.Drawing.Size(475, 308);
			this.Title = "Lost Project Report";
			this.pnlControls.ResumeLayout(false);
			this.pnlControls.PerformLayout();
			this.ResumeLayout(false);

		}

		private void SetAddingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboCompetitor.Enabled = true;
			cboDepartment.Enabled = true;
			cboReason.Enabled = true;
			txtComments.Enabled = true;
			txtCompetitorName.Enabled = true;
			txtReasonDetails.Enabled = true;

			this.IsDirty = false;
			this.State = BoundaryState.Adding;
		}

		private void SetEditingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboCompetitor.Enabled = true;
			cboDepartment.Enabled = true;
			cboReason.Enabled = true;
			txtComments.Enabled = true;
			txtCompetitorName.Enabled = true;
			txtReasonDetails.Enabled = true;

			cboCompetitor.SelectedValue = MyLostProject.CompetitorID;
			cboDepartment.SelectedValue = MyLostProject.DepartmentID;
			cboReason.SelectedValue = MyLostProject.ReasonID;
			txtComments.Text = MyLostProject.Comments;
			txtCompetitorName.Text = MyLostProject.CompetitorDetails;
			txtReasonDetails.Text = MyLostProject.ReasonDetails;

			if (cboCompetitor.SelectedItem == null)
				cboCompetitor.Text = MyLostProject.GetCompetitor().Name;
			if (cboDepartment.SelectedItem == null)
				cboDepartment.Text = MyLostProject.GetDepartment().Name;
			if (cboReason.SelectedItem == null)
				cboReason.Text = MyLostProject.GetReason().Name;

			this.IsDirty = false;
			this.State = BoundaryState.Editing;
		}

		private void SetSearchingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboCompetitor.Enabled = false;
			cboDepartment.Enabled = false;
			cboReason.Enabled = false;
			txtComments.Enabled = false;
			txtCompetitorName.Enabled = false;
			txtReasonDetails.Enabled = false;

			this.IsDirty = false;
			this.State = BoundaryState.Searching;
		}

		internal bool CommitChanges()
		{
			try
			{
				if (!IsSelectionValid(cboDepartment) && cboDepartment.Text != MyLostProject.GetDepartment().Name || string.IsNullOrEmpty(cboDepartment.Text))
					throw new Exception("The \"Department\" is not valid.");
				if (!IsSelectionValid(cboReason) && cboReason.Text != MyLostProject.GetReason().Name || string.IsNullOrEmpty(cboReason.Text))
					throw new Exception("The \"Reason\" is not valid.");
				if ((!cboReason.Text.Contains("Other") && Convert.ToInt32(cboReason.SelectedValue) != JOB_CANCELLED && 
					Convert.ToInt32(cboReason.SelectedValue) != CUSTOMER_LOST_JOB) && 
					!IsSelectionValid(cboCompetitor) && (cboCompetitor.Text != MyLostProject.GetCompetitor().Name || string.IsNullOrEmpty(cboCompetitor.Text)))
					throw new Exception("Please select a competitor.");
				if ((cboReason.Text.Contains("Other") || Convert.ToInt32(cboReason.SelectedValue) == JOB_CANCELLED) && string.IsNullOrEmpty(txtReasonDetails.Text))
					throw new Exception("The \"Details\" field cannot be blank.");
				if (cboCompetitor.Text.Contains("Other") && string.IsNullOrEmpty(txtCompetitorName.Text))
					throw new Exception("The \"Competitor's Name\" cannot be blank.");

				MyLostProject.ProjectID = MyProjectID;
				MyLostProject.DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
				MyLostProject.ReasonID = Convert.ToInt32(cboReason.SelectedValue);
				MyLostProject.CompetitorID = cboCompetitor.SelectedItem != null ? Convert.ToInt32(cboCompetitor.SelectedValue) : 0;
				MyLostProject.Comments = txtComments.Text;
				MyLostProject.CompetitorDetails = txtCompetitorName.Text;
				MyLostProject.ReasonDetails = txtReasonDetails.Text;

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}

		private void LoadCompetitors()
		{
			if (cboCompetitor.DataSource != null)
			{
				((DataTable)cboCompetitor.DataSource).Dispose();
				cboCompetitor.Items.Clear();
			}

			using (CompetitorController theController = new CompetitorController())
			{
				cboCompetitor.DataSource = theController.GetCompetitors(SelectedDepartmentID);
				cboCompetitor.DisplayMember = "name";
				cboCompetitor.ValueMember = "competitor_id";
				cboCompetitor.SelectedItem = null;
			}
		}

		private void LoadDepartments()
		{
			if (cboDepartment.DataSource != null)
			{
				((DataTable)cboDepartment.DataSource).Dispose();
				cboDepartment.Items.Clear();
			}

			using (Department.DepartmentController theController = new rkcrm.Objects.Project.Department.DepartmentController())
			{
				cboDepartment.DataSource = theController.GetOutstandingDepartments(MyProjectID);
				cboDepartment.DisplayMember = "name";
				cboDepartment.ValueMember = "department_id";
				cboDepartment.SelectedItem = null;
			}
		}

		private new void Clear()
		{
			base.Clear();

			cboCompetitor.SelectedItem = null;
			cboDepartment.SelectedItem = null;
			cboReason.SelectedItem = null;
			txtComments.Clear();
			txtCompetitorName.Clear();
			txtReasonDetails.Clear();
		}

		#endregion


		#region Event Handlers

		private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.State != BoundaryState.Loading && this.State != BoundaryState.Searching && cboDepartment.SelectedItem != null)
				LoadCompetitors();
		}

		private void cboCompetitor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboCompetitor.Text.Contains("Other"))
			{
				txtCompetitorName.Visible = true;
				lblCompetitorName.Visible = true;
			}
			else
			{
				txtCompetitorName.Visible = false;
				lblCompetitorName.Visible = false;
				txtCompetitorName.Clear();
			}
		}

		private void cboReason_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.State != BoundaryState.Loading && cboReason.SelectedItem != null)
			{
				int value = Convert.ToInt32(cboReason.SelectedValue);

				if (value == JOB_CANCELLED)
				{
					cboCompetitor.Enabled = false;
					cboCompetitor.SelectedItem = null;
				}
				else
				{
					cboCompetitor.Enabled = true;
				}

				if (value == JOB_CANCELLED || value == SOLD_ANOTHER_SCOPE || cboReason.Text.Contains("Other"))
				{
					lblReasonDetail.Text = "Details*";
					lblLostTo.Text = "Sale lost to:";
				}
				else if (value == CUSTOMER_LOST_JOB)
				{
					lblReasonDetail.Text = "Details";
					lblLostTo.Text = "Sale lost to:";
				}
				else
				{
					lblReasonDetail.Text = "Details";
					lblLostTo.Text = "Sale lost to:*";
				}
			}
		}

		private void CompetitorName_MouseHover(object sender, EventArgs e)
		{
			CompetitorNameToolTip.SetToolTip((Control)sender, "If you do not know or forgot to ask for the Competitor's name enter \"Unknown\".");
		}

		#endregion


		#region Constructor

		public LostProjectBoundary()
			: base()
		{
			this.State = BoundaryState.Loading;

			InitializeComponent();

			using (ReasonController theController = new ReasonController())
			{
				cboReason.DataSource = theController.GetReasons();
				cboReason.DisplayMember = "name";
				cboReason.ValueMember = "reason_id";
				cboReason.SelectedItem = null;
			}

			CompetitorNameToolTip = new ToolTip();
			CompetitorNameToolTip.AutoPopDelay = 8000;
			CompetitorNameToolTip.InitialDelay = 500;
			CompetitorNameToolTip.ReshowDelay = 500;
			CompetitorNameToolTip.ShowAlways = true;
		}

		#endregion

	}
}
