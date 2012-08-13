using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Net.Mail;
using rkcrm.Administration.Project_Type;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Project
{
	class ProjectBoundary : BoundaryBase
	{

		#region Variables

		internal System.Windows.Forms.Label lblDescription;
		internal System.Windows.Forms.TextBox txtDescription;
		internal System.Windows.Forms.Label lblAddress;
		internal System.Windows.Forms.TextBox txtAddress;
		internal System.Windows.Forms.TextBox txtZipCode;
		internal System.Windows.Forms.TextBox txtState;
		internal System.Windows.Forms.TextBox txtCity;
		internal System.Windows.Forms.TextBox txtAptBldLot;
		internal System.Windows.Forms.Label lblAptBldLot;
		internal System.Windows.Forms.Label lblState;
		internal System.Windows.Forms.Label lblZipCode;
		internal System.Windows.Forms.ComboBox cboContact;
		internal System.Windows.Forms.Label lblCity;
		internal System.Windows.Forms.Label lblContact;
		internal System.Windows.Forms.Label lblName;
		internal System.Windows.Forms.TextBox txtName;
		internal System.Windows.Forms.ComboBox cboType;
		internal System.Windows.Forms.GroupBox gbxInfo;
		internal System.Windows.Forms.GroupBox gbxOthers;
		internal System.Windows.Forms.Label lblType;

		private ListView lvwRelatedList;
		private ColumnHeader chID;
		private ColumnHeader chName;
		private ColumnHeader chRep;
		private Project clsMyProject;
		private const int OUTSTANDING = 1;
		private const int SOLD = 2;
		private const int LOST = 3;
		private DataGridView dgvProjectInfo;
		private DataGridViewTextBoxColumn dcDepartment;
		private DataGridViewTextBoxColumn dcStatus;
		private DataGridViewTextBoxColumn dcNextFollowUp;
		private DataGridViewTextBoxColumn dcAvgAmount;
		private DataGridViewTextBoxColumn dcProbability;
		private DataGridViewTextBoxColumn dcValue;
        private int intLinkWithID = 0;

		#endregion


		#region Properties

		public Project MyProject
		{
			get { return clsMyProject; }
			set
			{
				if (clsMyProject != value && clsMyProject != null)
					clsMyProject.Dispose();

				clsMyProject = value;

				if (value == null)
					SetSearchingMode();
				else
				{
					LoadContacts();

					if (value.ID > 0)
						SetEditingMode();
					else
						SetAddingMode();
				}

				OnMyProjectChanged(new EventArgs());
			}
		}

        public int LinkWithID
        {
            get { return intLinkWithID; }
        }

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblAddress = new System.Windows.Forms.Label();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.txtZipCode = new System.Windows.Forms.TextBox();
			this.txtState = new System.Windows.Forms.TextBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.txtAptBldLot = new System.Windows.Forms.TextBox();
			this.lblAptBldLot = new System.Windows.Forms.Label();
			this.lblState = new System.Windows.Forms.Label();
			this.lblZipCode = new System.Windows.Forms.Label();
			this.cboContact = new System.Windows.Forms.ComboBox();
			this.lblCity = new System.Windows.Forms.Label();
			this.lblContact = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.cboType = new System.Windows.Forms.ComboBox();
			this.lblType = new System.Windows.Forms.Label();
			this.gbxInfo = new System.Windows.Forms.GroupBox();
			this.dgvProjectInfo = new System.Windows.Forms.DataGridView();
			this.dcDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dcStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dcNextFollowUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dcAvgAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dcProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gbxOthers = new System.Windows.Forms.GroupBox();
			this.lvwRelatedList = new System.Windows.Forms.ListView();
			this.chID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chRep = new System.Windows.Forms.ColumnHeader();
			this.pnlControls.SuspendLayout();
			this.gbxInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProjectInfo)).BeginInit();
			this.gbxOthers.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.gbxOthers);
			this.pnlControls.Controls.Add(this.gbxInfo);
			this.pnlControls.Controls.Add(this.lblDescription);
			this.pnlControls.Controls.Add(this.txtDescription);
			this.pnlControls.Controls.Add(this.lblAddress);
			this.pnlControls.Controls.Add(this.txtAddress);
			this.pnlControls.Controls.Add(this.txtZipCode);
			this.pnlControls.Controls.Add(this.txtState);
			this.pnlControls.Controls.Add(this.txtCity);
			this.pnlControls.Controls.Add(this.txtAptBldLot);
			this.pnlControls.Controls.Add(this.lblAptBldLot);
			this.pnlControls.Controls.Add(this.lblState);
			this.pnlControls.Controls.Add(this.lblZipCode);
			this.pnlControls.Controls.Add(this.cboContact);
			this.pnlControls.Controls.Add(this.lblCity);
			this.pnlControls.Controls.Add(this.lblContact);
			this.pnlControls.Controls.Add(this.lblName);
			this.pnlControls.Controls.Add(this.txtName);
			this.pnlControls.Controls.Add(this.cboType);
			this.pnlControls.Controls.Add(this.lblType);
			this.pnlControls.Size = new System.Drawing.Size(600, 451);
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(8, 102);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDescription.Size = new System.Drawing.Size(96, 13);
			this.lblDescription.TabIndex = 52;
			this.lblDescription.Text = "Project Description";
			// 
			// txtDescription
			// 
			this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDescription.Location = new System.Drawing.Point(8, 118);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(569, 20);
			this.txtDescription.TabIndex = 46;
			this.txtDescription.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.Location = new System.Drawing.Point(5, 57);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblAddress.Size = new System.Drawing.Size(76, 13);
			this.lblAddress.TabIndex = 51;
			this.lblAddress.Text = "Street Address";
			// 
			// txtAddress
			// 
			this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAddress.Enabled = false;
			this.txtAddress.Location = new System.Drawing.Point(8, 73);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(258, 20);
			this.txtAddress.TabIndex = 40;
			this.txtAddress.TextChanged += new System.EventHandler(this.control_Changed);
			this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
			// 
			// txtZipCode
			// 
			this.txtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtZipCode.Enabled = false;
			this.txtZipCode.Location = new System.Drawing.Point(512, 73);
			this.txtZipCode.MaxLength = 5;
			this.txtZipCode.Name = "txtZipCode";
			this.txtZipCode.Size = new System.Drawing.Size(65, 20);
			this.txtZipCode.TabIndex = 45;
			this.txtZipCode.Tag = "";
			this.txtZipCode.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// txtState
			// 
			this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtState.Enabled = false;
			this.txtState.Location = new System.Drawing.Point(477, 73);
			this.txtState.MaxLength = 2;
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(29, 20);
			this.txtState.TabIndex = 44;
			this.txtState.Tag = "";
			this.txtState.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// txtCity
			// 
			this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCity.Location = new System.Drawing.Point(372, 73);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(99, 20);
			this.txtCity.TabIndex = 43;
			this.txtCity.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// txtAptBldLot
			// 
			this.txtAptBldLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAptBldLot.Enabled = false;
			this.txtAptBldLot.Location = new System.Drawing.Point(272, 73);
			this.txtAptBldLot.Name = "txtAptBldLot";
			this.txtAptBldLot.Size = new System.Drawing.Size(94, 20);
			this.txtAptBldLot.TabIndex = 42;
			this.txtAptBldLot.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblAptBldLot
			// 
			this.lblAptBldLot.AutoSize = true;
			this.lblAptBldLot.Location = new System.Drawing.Point(269, 57);
			this.lblAptBldLot.Name = "lblAptBldLot";
			this.lblAptBldLot.Size = new System.Drawing.Size(94, 13);
			this.lblAptBldLot.TabIndex = 50;
			this.lblAptBldLot.Text = "Apt/Bld/Ste/Lot #";
			// 
			// lblState
			// 
			this.lblState.AutoSize = true;
			this.lblState.Location = new System.Drawing.Point(474, 57);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(32, 13);
			this.lblState.TabIndex = 49;
			this.lblState.Text = "State";
			// 
			// lblZipCode
			// 
			this.lblZipCode.AutoSize = true;
			this.lblZipCode.Location = new System.Drawing.Point(509, 57);
			this.lblZipCode.Name = "lblZipCode";
			this.lblZipCode.Size = new System.Drawing.Size(50, 13);
			this.lblZipCode.TabIndex = 48;
			this.lblZipCode.Text = "Zip Code";
			// 
			// cboContact
			// 
			this.cboContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboContact.Enabled = false;
			this.cboContact.FormattingEnabled = true;
			this.cboContact.Location = new System.Drawing.Point(391, 28);
			this.cboContact.Name = "cboContact";
			this.cboContact.Size = new System.Drawing.Size(186, 21);
			this.cboContact.TabIndex = 38;
			this.cboContact.SelectionChangeCommitted += new System.EventHandler(this.cboContact_SelectionChangeCommitted);
			this.cboContact.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblCity
			// 
			this.lblCity.AutoSize = true;
			this.lblCity.Location = new System.Drawing.Point(369, 57);
			this.lblCity.Name = "lblCity";
			this.lblCity.Size = new System.Drawing.Size(28, 13);
			this.lblCity.TabIndex = 47;
			this.lblCity.Text = "City*";
			// 
			// lblContact
			// 
			this.lblContact.AutoSize = true;
			this.lblContact.Location = new System.Drawing.Point(388, 12);
			this.lblContact.Name = "lblContact";
			this.lblContact.Size = new System.Drawing.Size(48, 13);
			this.lblContact.TabIndex = 41;
			this.lblContact.Text = "Contact*";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(5, 12);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(75, 13);
			this.lblName.TabIndex = 39;
			this.lblName.Text = "Project Name*";
			// 
			// txtName
			// 
			this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtName.Location = new System.Drawing.Point(8, 28);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(197, 20);
			this.txtName.TabIndex = 35;
			this.txtName.TextChanged += new System.EventHandler(this.control_Changed);
			this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
			// 
			// cboType
			// 
			this.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboType.Enabled = false;
			this.cboType.FormattingEnabled = true;
			this.cboType.Location = new System.Drawing.Point(211, 28);
			this.cboType.Name = "cboType";
			this.cboType.Size = new System.Drawing.Size(174, 21);
			this.cboType.TabIndex = 36;
			this.cboType.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.Location = new System.Drawing.Point(208, 12);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(71, 13);
			this.lblType.TabIndex = 37;
			this.lblType.Text = "Project Type*";
			// 
			// gbxInfo
			// 
			this.gbxInfo.Controls.Add(this.dgvProjectInfo);
			this.gbxInfo.Location = new System.Drawing.Point(8, 154);
			this.gbxInfo.Name = "gbxInfo";
			this.gbxInfo.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
			this.gbxInfo.Size = new System.Drawing.Size(467, 146);
			this.gbxInfo.TabIndex = 53;
			this.gbxInfo.TabStop = false;
			this.gbxInfo.Text = "Project Info";
			// 
			// dgvProjectInfo
			// 
			this.dgvProjectInfo.AllowUserToAddRows = false;
			this.dgvProjectInfo.AllowUserToDeleteRows = false;
			this.dgvProjectInfo.BackgroundColor = System.Drawing.Color.White;
			this.dgvProjectInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvProjectInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvProjectInfo.ColumnHeadersHeight = 22;
			this.dgvProjectInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvProjectInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dcDepartment,
            this.dcStatus,
            this.dcNextFollowUp,
            this.dcAvgAmount,
            this.dcProbability,
            this.dcValue});
			this.dgvProjectInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvProjectInfo.Enabled = false;
			this.dgvProjectInfo.Location = new System.Drawing.Point(6, 16);
			this.dgvProjectInfo.Name = "dgvProjectInfo";
			this.dgvProjectInfo.ReadOnly = true;
			this.dgvProjectInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvProjectInfo.RowHeadersVisible = false;
			this.dgvProjectInfo.Size = new System.Drawing.Size(455, 124);
			this.dgvProjectInfo.TabIndex = 55;
			// 
			// dcDepartment
			// 
			this.dcDepartment.HeaderText = "Department";
			this.dcDepartment.Name = "dcDepartment";
			this.dcDepartment.ReadOnly = true;
			this.dcDepartment.Width = 70;
			// 
			// dcStatus
			// 
			this.dcStatus.FillWeight = 81.80312F;
			this.dcStatus.HeaderText = "Status";
			this.dcStatus.Name = "dcStatus";
			this.dcStatus.ReadOnly = true;
			this.dcStatus.Width = 80;
			// 
			// dcNextFollowUp
			// 
			this.dcNextFollowUp.HeaderText = "Next Follow Up";
			this.dcNextFollowUp.Name = "dcNextFollowUp";
			this.dcNextFollowUp.ReadOnly = true;
			this.dcNextFollowUp.Width = 85;
			// 
			// dcAvgAmount
			// 
			this.dcAvgAmount.FillWeight = 81.80312F;
			this.dcAvgAmount.HeaderText = "Avg Quote Amt";
			this.dcAvgAmount.Name = "dcAvgAmount";
			this.dcAvgAmount.ReadOnly = true;
			this.dcAvgAmount.Width = 85;
			// 
			// dcProbability
			// 
			this.dcProbability.HeaderText = "Prob %";
			this.dcProbability.Name = "dcProbability";
			this.dcProbability.ReadOnly = true;
			this.dcProbability.Width = 50;
			// 
			// dcValue
			// 
			this.dcValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dcValue.HeaderText = "Project Value";
			this.dcValue.Name = "dcValue";
			this.dcValue.ReadOnly = true;
			// 
			// gbxOthers
			// 
			this.gbxOthers.Controls.Add(this.lvwRelatedList);
			this.gbxOthers.Location = new System.Drawing.Point(8, 316);
			this.gbxOthers.Name = "gbxOthers";
			this.gbxOthers.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
			this.gbxOthers.Size = new System.Drawing.Size(297, 128);
			this.gbxOthers.TabIndex = 54;
			this.gbxOthers.TabStop = false;
			this.gbxOthers.Text = "Other Customers Bidding This Project";
			// 
			// lvwRelatedList
			// 
			this.lvwRelatedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chName,
            this.chRep});
			this.lvwRelatedList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwRelatedList.FullRowSelect = true;
			this.lvwRelatedList.HideSelection = false;
			this.lvwRelatedList.Location = new System.Drawing.Point(6, 16);
			this.lvwRelatedList.Name = "lvwRelatedList";
			this.lvwRelatedList.Size = new System.Drawing.Size(285, 106);
			this.lvwRelatedList.TabIndex = 0;
			this.lvwRelatedList.UseCompatibleStateImageBehavior = false;
			this.lvwRelatedList.View = System.Windows.Forms.View.Details;
			this.lvwRelatedList.DoubleClick += new System.EventHandler(this.lvwRelatedList_DoubleClick);
			// 
			// chID
			// 
			this.chID.Text = "Project ID";
			this.chID.Width = 0;
			// 
			// chName
			// 
			this.chName.Text = "Customer Name";
			this.chName.Width = 150;
			// 
			// chRep
			// 
			this.chRep.Text = "Sales Rep";
			this.chRep.Width = 125;
			// 
			// ProjectBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScroll = true;
			this.Name = "ProjectBoundary";
			this.Size = new System.Drawing.Size(600, 501);
			this.pnlControls.ResumeLayout(false);
			this.pnlControls.PerformLayout();
			this.gbxInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvProjectInfo)).EndInit();
			this.gbxOthers.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		private new void Clear()
		{
			base.Clear();

			dgvProjectInfo.Rows.Clear();
			lvwRelatedList.Items.Clear();
			cboContact.SelectedItem = null;
			cboType.SelectedItem = null;
			txtAddress.Clear();
			txtAptBldLot.Clear();
			txtCity.Clear();
			txtDescription.Clear();
			txtName.Clear();
			txtState.Clear();
			txtZipCode.Clear();
		}

		private ProjectScreen GetProjectScreen()
		{
			Control theScreen = (Control)this;

			while (theScreen.Parent != null && !(theScreen is ProjectScreen))
				theScreen = theScreen.Parent;

			if (theScreen is ProjectScreen)
				return (ProjectScreen)theScreen;
			else
				return null;
		}

		private void LoadContacts()
		{
			ProjectScreen myParent = GetProjectScreen();
			int selectedIndex = cboContact.SelectedIndex;
			bool origDirty = this.IsDirty;

			if (myParent != null)
			{
				DataTable oTable;
				using (Contact.ContactController theController = new Contact.ContactController())
				{
					oTable = theController.GetContacts(myParent.MyCustomer.ID, false);
				}

				if (oTable.Rows.Count > 0)
				{
					//Remove duplicate rows
					int index = 0;
					DataRow previous = oTable.NewRow();
					DataRow current;

					previous["contact_id"] = 0;
					while (index < oTable.Rows.Count)
					{
						current = oTable.Rows[index];
						if (Convert.ToInt32(current["contact_id"]) == Convert.ToInt32(previous["contact_id"]))
							oTable.Rows.Remove(oTable.Rows[index]);
						else
						{
							previous = oTable.Rows[index];
							index++;
						}
					}

					DataRow newRow = oTable.NewRow();
					newRow["contact_id"] = 0;
					newRow["contact"] = "Add a Contact...";

					oTable.Rows.Add(newRow);

					cboContact.DataSource = oTable;
					cboContact.DisplayMember = "contact";
					cboContact.ValueMember = "contact_id";
					cboContact.SelectedItem = null;
				}
			}
			else
				cboContact.Enabled = false;

			if (selectedIndex > -1 && selectedIndex < cboContact.Items.Count)
				cboContact.SelectedIndex = selectedIndex;

			this.IsDirty = origDirty;
		}

		private void SetAddingMode()
		{
			ProjectScreen MyParent = GetProjectScreen();

			this.State = BoundaryState.Loading;

			this.Clear();

			cboContact.Enabled = (MyParent != null);
			cboType.Enabled = true;
			txtAddress.Enabled = true;
			txtAptBldLot.Enabled = true;
			txtCity.Enabled = true;
			txtDescription.Enabled = true;
			txtName.Enabled = true;
			txtState.Enabled = true;
			txtZipCode.Enabled = true;

			if (MyParent != null)
				if (MyParent.MyCustomer.GetCustomerType().DefaultProjectName)
					txtName.Text = MyParent.MyCustomer.Name;

			this.IsDirty = false;
			this.State = BoundaryState.Adding;
			this.Title = "Add New Project";
		}

		private void SetEditingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboContact.SelectedValue = MyProject.ContactID;
			cboType.SelectedValue = MyProject.TypeID;
			txtAddress.Text = MyProject.Address;
			txtAptBldLot.Text = MyProject.Apt;
			txtCity.Text = MyProject.City;
			txtDescription.Text = MyProject.Description;
			txtName.Text = MyProject.Name;
			txtState.Text = MyProject.State;
			txtZipCode.Text = MyProject.ZipCode > 0 ? MyProject.ZipCode.ToString() : string.Empty;
			ObjectCreated = MyProject.Created.ToString("M/d/yyyy HH:mm:ss");
			ObjectCreatedBy = MyProject.GetCreator().UserName;
			ObjectUpdated = MyProject.Updated.ToString("M/d/yyyy HH:mm:ss");
			ObjectUpdatedBy = MyProject.GetUpdater().UserName;

			bool IsGeneralNotes = (MyProject.Name == "GENERAL NOTES");

			cboContact.Enabled = !IsGeneralNotes && !MyProject.IsArchived;
			cboType.Enabled = !IsGeneralNotes && !MyProject.IsArchived;
			txtAddress.Enabled = !IsGeneralNotes && !MyProject.IsArchived;
			txtAptBldLot.Enabled = !IsGeneralNotes && !MyProject.IsArchived;
			txtCity.Enabled = !IsGeneralNotes && !MyProject.IsArchived;
			txtDescription.Enabled = !IsGeneralNotes && !MyProject.IsArchived;
			txtName.Enabled = !IsGeneralNotes && !MyProject.IsArchived;
			txtState.Enabled = !IsGeneralNotes && !MyProject.IsArchived;
			txtZipCode.Enabled = !IsGeneralNotes && !MyProject.IsArchived;
			cboContact.SelectedItem = !IsGeneralNotes && !MyProject.IsArchived;

			if (cboContact.SelectedItem == null)
				cboContact.Text = MyProject.GetContact().FullName;
			if (cboType.SelectedItem == null)
				cboType.Text = MyProject.GetProjectType().Name;

			RefreshPreviewData();

			this.IsDirty = false;
			this.State = BoundaryState.Editing;
			this.Title = "Edit Project";
		}

		public void RefreshPreviewData()
		{
			dgvProjectInfo.Rows.Clear();
			lvwRelatedList.Items.Clear();

			using (ProjectController theController = new ProjectController())
			{
				DataGridViewRow newRow;
				ListViewItem newItem;
				DataTable stati = theController.GetStatuses(MyProject.ID);
				Project.ProjectStatus myStatus = Project.ProjectStatus.None;

				foreach (DataRow oRow in theController.GetProjectCalculations(MyProject.ID).Rows)
				{
					myStatus = Project.ProjectStatus.None;
					
					// This for-loop is necessary because the project-department record is not deleted when the last quote in a project is deleted 
					foreach (DataRow statRow in stati.Rows)
						if (Convert.ToInt32(statRow["department_id"]) == Convert.ToInt32(oRow["department_id"]))
							myStatus = (Project.ProjectStatus)Convert.ToInt32(statRow["status_id"]);

					if (myStatus != Project.ProjectStatus.None)
					{

						newRow = new DataGridViewRow();
						newRow.CreateCells(dgvProjectInfo);

						newRow.SetValues(
						oRow["department"].ToString(),
						oRow["status"].ToString(),
						(oRow["next_follow_up"] == DBNull.Value ? string.Empty : Convert.ToDateTime(oRow["next_follow_up"]).ToShortDateString()),
						(oRow["average"] == DBNull.Value ? string.Empty : Convert.ToDecimal(oRow["average"]).ToString("C")),
						(oRow["probability"] == DBNull.Value ? string.Empty : Convert.ToInt32(oRow["probability"]).ToString() + "%"),
						(oRow["value"] == DBNull.Value ? string.Empty : Convert.ToDecimal(oRow["value"]).ToString("C")));

						switch (Convert.ToInt32(oRow["status_id"]))
						{
							case SOLD:
							foreach (DataGridViewCell oCell in newRow.Cells)
							{
								oCell.Style.BackColor = Color.LimeGreen;
								oCell.Style.ForeColor = Color.White;
							}
								break;
							case LOST:
							foreach (DataGridViewCell oCell in newRow.Cells)
							{
								oCell.Style.BackColor = Color.IndianRed;
								oCell.Style.ForeColor = Color.White;
							}
								break;
							default:
								int prevStatusID = (oRow["previous_status_id"] == DBNull.Value ? 0 : Convert.ToInt32(oRow["previous_status_id"]));

								if (prevStatusID == SOLD)
									newRow.Cells[1].Style.ForeColor = Color.LimeGreen;
								else if (prevStatusID == LOST)
									newRow.Cells[1].Style.ForeColor = Color.IndianRed;
								break;
						}

						dgvProjectInfo.Rows.Add(newRow);
					}
				}

				foreach (DataRow oRow in theController.GetLinkedProjects(MyProject).Rows)
				{
					newItem = new ListViewItem();
					newItem.Text = oRow["project_id"].ToString();
					newItem.SubItems.Add(oRow["customer"].ToString());
					newItem.SubItems.Add(oRow["sales_rep"].ToString());

					lvwRelatedList.Items.Add(newItem);
				}
			}

			dgvProjectInfo.ClearSelection();
		}

		private void SetSearchingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboContact.Enabled = false;
			cboType.Enabled = false;
			txtAddress.Enabled = false;
			txtAptBldLot.Enabled = false;
			txtCity.Enabled = true;
			txtDescription.Enabled = false;
			txtName.Enabled = true;
			txtState.Enabled = false;
			txtZipCode.Enabled = false;

			this.IsDirty = false;
			this.State = BoundaryState.Searching;
			this.Title = "Search Projects";
		}

		internal bool CommitChanges()
		{
			try
			{
				if (IsDirty)
				{
					ProjectType myType = MyProject.GetProjectType();
					Contact.Contact myContact = MyProject.GetContact();

					if (thisUser.HomeDepartment.IsProfitCenter && !HasLeadSource())
						throw new Exception("You must add a lead source for the " + thisUser.HomeDepartment.Name + " department before saving this project.");
					if (!IsSelectionValid(cboType) && cboType.Text != myType.Name || string.IsNullOrEmpty(cboType.Text))
						throw new Exception("The \"Project Type\" is not valid.");
					if (cboContact.Enabled && !IsSelectionValid(cboContact) && cboContact.Text != MyProject.GetContact().FullName || string.IsNullOrEmpty(cboContact.Text))
						throw new Exception("The \"Contact\" is not valid.");
					if (string.IsNullOrEmpty(txtName.Text))
						throw new Exception("The \"Project Name\" is not valid.");
					if (string.IsNullOrEmpty(txtCity.Text))
						throw new Exception("The \"City\" is not valid.");
					if(!char.IsLetterOrDigit(txtName.Text[0]))
						throw new Exception("The \"Project Name\" must begin with a letter or number.");
					if(!char.IsLetter(txtCity.Text[0]))
						throw new Exception("The \"City\" must begin with a letter.");
				}

				if (cboType.SelectedItem != null)
					MyProject.TypeID = Convert.ToInt32(cboType.SelectedValue);
				if (cboContact.SelectedItem != null)
					MyProject.ContactID = Convert.ToInt32(cboContact.SelectedValue);
				MyProject.Name = txtName.Text;
				MyProject.Address = txtAddress.Text;
				MyProject.Apt = txtAptBldLot.Text;
				MyProject.City = txtCity.Text;
				MyProject.State = txtState.Text;
				MyProject.Description = txtDescription.Text;

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		public int GetHouseNumber()
		{
			string number = string.Empty;
			int index = 0;

			while (index < txtAddress.Text.Length && char.IsNumber(txtAddress.Text, index))
			{
				number += txtAddress.Text[index].ToString();
				index++;
			}

			return (string.IsNullOrEmpty(number) ? 0 : Convert.ToInt32(number));
		}

		private void NotfiyAdmins(DataTable duplicates)
		{
			SmtpClient client = new SmtpClient("Young");
			using (MailMessage theMessage = new MailMessage())
			{
				try
				{
					using (rkcrm.Administration.User.UserController theController = new rkcrm.Administration.User.UserController())
					{
						foreach (DataRow oRow in theController.GetRoleMembers(1).Rows)
							theMessage.To.Add(Convert.ToString(oRow["email_address"]));
					}

					if (theMessage.To.Count > 0)
					{
						theMessage.From = new MailAddress(thisUser.EmailAddress);
						theMessage.Subject = "[CRM] Duplicate Project Alert";
						theMessage.Body = "Project " + MyProject.ID + " was found in violation of duplication laws with the following projects:\n\n";

						foreach (DataRow oRow in duplicates.Rows)
							theMessage.Body += "\t" + oRow["project"].ToString() + "\n";

						client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

						client.Send(theMessage);
					}

				}
				catch (SmtpFailedRecipientsException e0)
				{
					rkcrm.Error_Handling.ErrorHandler.ProcessException(e0, false);
				}
				catch (SmtpException e1)
				{
					rkcrm.Error_Handling.ErrorHandler.ProcessException(e1, false);
				}
				catch (Exception e2)
				{
					rkcrm.Error_Handling.ErrorHandler.ProcessException(e2, false);
				}
			}
		}

        private bool IsDuplicateInside(string Name, int HouseNumber)
        {
            DataTable duplicates;

            using (ProjectController theController = new ProjectController())
            {
                // This first query determines if there are projects that the customer owns with the same name as entered in txtName
                duplicates = theController.GetDuplicateProjects(Name, HouseNumber, MyProject.ID, MyProject.CustomerID, false);

                if (duplicates.Rows.Count > 0)
                {
					NotfiyAdmins(duplicates);

                    DuplicateProjects oForm = new DuplicateProjects();
                    oForm.Title = MyProject.GetCustomer().Name + " has the following project(s) with a similar name to the project you are adding/editng. " +
						"Please determine if one of these projects is a match to the one you are adding/editng.\n" +
                        "If so, select the project and click [Goto], otherwise, click cancel.";
                    oForm.AcceptButtonText = "Goto";
                    oForm.DataSource = duplicates;

                    oForm.ShowDialog();

                    if (oForm.DialogResult == DialogResult.OK)
                    {
                        MyProject = theController.GetProject(oForm.SelectedProjectID);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        private bool IsDuplicatesOuside(string Name, int HouseNumber)
        {
            DataTable duplicates;

            using (ProjectController theController = new ProjectController())
            {
                duplicates = theController.GetDuplicateProjects(Name, HouseNumber, MyProject.ID, MyProject.CustomerID, true);

                if (duplicates.Rows.Count > 0)
                {
                    DuplicateProjects oForm = new DuplicateProjects();
					oForm.Title = "The following project(s) for other customers have a similar name to the project you are adding/editng. " +
						"Please determine if one of these projects is a match to the one you are adding/editng.\n" +
                        "If so, select the project and click [Link], otherwise, click [Don't Link].";
                    oForm.AcceptButtonText = "Link";
                    oForm.CancelButtonText = "Don't Link";
                    oForm.DataSource = duplicates;

                    oForm.ShowDialog();

                    if (oForm.DialogResult == DialogResult.OK)
                    {
                        intLinkWithID = oForm.SelectedProjectID;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        private Duplicate IsDuplicate(string Name, int HouseNumber)
        {
			Duplicate result = Duplicate.None;

			if (IsDuplicateInside(Name, HouseNumber))
				result = Duplicate.Inside;

			if (result == Duplicate.None)
				if (IsDuplicatesOuside(Name, HouseNumber))
					result = Duplicate.Outside;

			return result;
        }

		public bool Save()
		{
			Duplicate DuplicateResult = Duplicate.None;
			bool result = true;
			bool needToCheck = (txtName.Text != MyProject.Name || txtAddress.Text != MyProject.Address);

			if (CommitChanges())
			{
				if (this.State == BoundaryState.Editing && needToCheck)
					if (MyProject.LinkID > 0)
					{
						if (MessageBox.Show("This project is currently linked to other projects. Do you want to remove this link?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							using (ProjectController theController = new ProjectController())
							{
								if (theController.RemoveLink(MyProject))
									MyProject.LinkID = 0;
							}
							DuplicateResult = IsDuplicate(txtName.Text, GetHouseNumber());
						}
					}
					else
						DuplicateResult = IsDuplicate(txtName.Text, GetHouseNumber());

				if (DuplicateResult != Duplicate.Inside)
				{
					using (ProjectController theController = new ProjectController())
					{
						if (MyProject.ID > 0)
							result = theController.UpdateProject(MyProject);
						else
						{
							MyProject = theController.InsertProject(MyProject);

							result = (MyProject.ID > 0);

							if (result)
								if (LinkWithID > 0)
								{
									MyProject.LinkID = theController.Link(MyProject, theController.GetProject(LinkWithID));

									if (MyProject.LinkID > 0)
										MyProject = MyProject;
								}
						}
					}
				}
			}
			else
				result = false;

			return result;
		}

		private bool HasLeadSource()
		{
			bool result = false;
			Customer.Customer myCustomer = MyProject.GetCustomer();

			if (thisUser.HomeDepartment.IsProfitCenter)
			{
				if (!base.HasLeadSource(myCustomer.ID, thisUser.HomeDepartment.ID))
				{
					Objects.Customer.Lead_Source.AddLeadSource addSourceForm = new rkcrm.Objects.Customer.Lead_Source.AddLeadSource();
					addSourceForm.MyCustomer = myCustomer;
					addSourceForm.Title = "How did they hear about the " + thisUser.HomeDepartment.Name + " department?";
					addSourceForm.DepartmentID = thisUser.HomeDepartment.ID;

					addSourceForm.ShowDialog();

					if (addSourceForm.DialogResult == DialogResult.OK)
					{
						result = true;

						//If the customer screen exists then refresh it so the new lead source appears
						RefreshCustomer();
					}
				}
				else
					result = true;
			}
			else
				result = true;

			return result;
		}

		#endregion


		#region Event Handlers

		private void control_Changed(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Editing || this.State == BoundaryState.Adding)
				this.IsDirty = true;
		}

		private void cboContact_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (Convert.ToInt32(cboContact.SelectedValue) == 0)
			{
				Contact.AddContact oForm = new rkcrm.Objects.Contact.AddContact();
				oForm.MyContact = new rkcrm.Objects.Contact.Contact();
				oForm.MyContact.CustomerID = MyProject.CustomerID;

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					LoadContacts();
					foreach (DataRowView oRow in cboContact.Items)
					{
						if (Convert.ToInt32(oRow["contact_id"]) == oForm.MyContact.ID)
							cboContact.SelectedItem = oRow;
					}
				}
				else
					cboContact.SelectedItem = null;
			}
		}

		private void txtName_Leave(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Adding && !string.IsNullOrEmpty(txtName.Text))
                IsDuplicate(txtName.Text, 0);
		}

		private void txtAddress_Leave(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Adding && !string.IsNullOrEmpty(txtAddress.Text))
                IsDuplicate(string.Empty, GetHouseNumber());
		}

		private void lvwRelatedList_DoubleClick(object sender, EventArgs e)
		{
			if (lvwRelatedList.SelectedItems.Count > 0)
			{
				int projectID = Convert.ToInt32(lvwRelatedList.SelectedItems[0].SubItems[0].Text);
				ProjectScreen myScreen = this.GetProjectScreen();
				Project theProject;

				if (projectID > 0 && myScreen != null)
				{
					using (ProjectController theController = new ProjectController())
					{
						theProject = theController.GetProject(projectID);

						myScreen.MyCustomer = theProject.GetCustomer();
						myScreen.GetNavigationScreen().btnCustomer.MyCustomer = myScreen.MyCustomer;
						myScreen.MyProject = theProject;
					}
				}
			}
		}

		#endregion


		#region Events

		public event EventHandler<EventArgs> MyProjectChanged;
		protected virtual void OnMyProjectChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = MyProjectChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion


		#region Enumerations

		private enum Duplicate { None, Inside, Outside };

		#endregion


		#region Constructor

		public ProjectBoundary()
			: base()
		{
			this.State = BoundaryState.Loading;

			InitializeComponent();

			using (ProjectTypeController theController = new ProjectTypeController())
			{
				cboType.DataSource = theController.GetProjectTypes();
				cboType.DisplayMember = "name";
				cboType.ValueMember = "type_id";
				cboType.SelectedItem = null;
			}
		}

		#endregion

	}
}
