using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.Department;
using rkcrm.Administration.Job_Title;
using rkcrm.Administration.Location;
using rkcrm.Administration.Role;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.User
{
    class UserBoundary : BoundaryBase
    {

		#region Variables

		private System.Windows.Forms.GroupBox gbxOtherOptions;
		public System.Windows.Forms.CheckBox chkReceivesLeads;
		public System.Windows.Forms.CheckBox chkShowReminders;
		private System.Windows.Forms.Label lblEmail;
		public System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label lblDepartments;
		public System.Windows.Forms.ListBox lstDepartment;
		private System.Windows.Forms.Label lblLocation;
		private System.Windows.Forms.Label lblJobTitle;
		public System.Windows.Forms.ComboBox cboJobTitle;
		public System.Windows.Forms.ComboBox cboLocation;
		private System.Windows.Forms.Label lblRole;
		public System.Windows.Forms.ComboBox cboRole;
		private System.Windows.Forms.Label lblUserName;
		public System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label lblLastName;
		public System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.Label lblFirstName;
		public System.Windows.Forms.TextBox txtFirstName;

		private User clsMyUser;
		private const int DEPARTMENT_ID_INDEX = 0;

		#endregion


        #region Properties

		public User MyUser
		{
			get { return clsMyUser; }
			set 
			{
				if (clsMyUser != value && clsMyUser != null)
					clsMyUser.Dispose();

				clsMyUser = value;

				if (value == null)
					SetSearchingMode();
				else
					if (value.ID > 0)
						SetEditingMode();
					else
						SetAddingMode();

				OnMyUserChanged(new EventArgs());
			}
		}

        #endregion


        #region Methods

        private void InitializeComponent()
        {
			this.gbxOtherOptions = new System.Windows.Forms.GroupBox();
			this.chkReceivesLeads = new System.Windows.Forms.CheckBox();
			this.chkShowReminders = new System.Windows.Forms.CheckBox();
			this.lblEmail = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.lblDepartments = new System.Windows.Forms.Label();
			this.lstDepartment = new System.Windows.Forms.ListBox();
			this.lblLocation = new System.Windows.Forms.Label();
			this.lblJobTitle = new System.Windows.Forms.Label();
			this.cboJobTitle = new System.Windows.Forms.ComboBox();
			this.cboLocation = new System.Windows.Forms.ComboBox();
			this.lblRole = new System.Windows.Forms.Label();
			this.cboRole = new System.Windows.Forms.ComboBox();
			this.lblUserName = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.lblLastName = new System.Windows.Forms.Label();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.lblFirstName = new System.Windows.Forms.Label();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.pnlControls.SuspendLayout();
			this.gbxOtherOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.gbxOtherOptions);
			this.pnlControls.Controls.Add(this.lblEmail);
			this.pnlControls.Controls.Add(this.txtEmail);
			this.pnlControls.Controls.Add(this.lblDepartments);
			this.pnlControls.Controls.Add(this.lstDepartment);
			this.pnlControls.Controls.Add(this.lblLocation);
			this.pnlControls.Controls.Add(this.lblJobTitle);
			this.pnlControls.Controls.Add(this.cboJobTitle);
			this.pnlControls.Controls.Add(this.cboLocation);
			this.pnlControls.Controls.Add(this.lblRole);
			this.pnlControls.Controls.Add(this.cboRole);
			this.pnlControls.Controls.Add(this.lblUserName);
			this.pnlControls.Controls.Add(this.txtUserName);
			this.pnlControls.Controls.Add(this.lblLastName);
			this.pnlControls.Controls.Add(this.txtLastName);
			this.pnlControls.Controls.Add(this.lblFirstName);
			this.pnlControls.Controls.Add(this.txtFirstName);
			this.pnlControls.Size = new System.Drawing.Size(600, 287);
			// 
			// gbxOtherOptions
			// 
			this.gbxOtherOptions.Controls.Add(this.chkReceivesLeads);
			this.gbxOtherOptions.Controls.Add(this.chkShowReminders);
			this.gbxOtherOptions.Location = new System.Drawing.Point(20, 208);
			this.gbxOtherOptions.Name = "gbxOtherOptions";
			this.gbxOtherOptions.Size = new System.Drawing.Size(452, 65);
			this.gbxOtherOptions.TabIndex = 34;
			this.gbxOtherOptions.TabStop = false;
			this.gbxOtherOptions.Text = "Other Options";
			// 
			// chkReceivesLeads
			// 
			this.chkReceivesLeads.AutoSize = true;
			this.chkReceivesLeads.Location = new System.Drawing.Point(189, 28);
			this.chkReceivesLeads.Name = "chkReceivesLeads";
			this.chkReceivesLeads.Size = new System.Drawing.Size(188, 17);
			this.chkReceivesLeads.TabIndex = 1;
			this.chkReceivesLeads.Text = "Receives Cross Lead Notifications";
			this.chkReceivesLeads.UseVisualStyleBackColor = true;
			// 
			// chkShowReminders
			// 
			this.chkShowReminders.AutoSize = true;
			this.chkShowReminders.Location = new System.Drawing.Point(15, 28);
			this.chkShowReminders.Name = "chkShowReminders";
			this.chkShowReminders.Size = new System.Drawing.Size(158, 17);
			this.chkShowReminders.TabIndex = 0;
			this.chkShowReminders.Text = "Show Reminders on Startup";
			this.chkShowReminders.UseVisualStyleBackColor = true;
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.Location = new System.Drawing.Point(170, 105);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(73, 13);
			this.lblEmail.TabIndex = 33;
			this.lblEmail.Text = "Email Address";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(173, 121);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(299, 20);
			this.txtEmail.TabIndex = 28;
			// 
			// lblDepartments
			// 
			this.lblDepartments.AutoSize = true;
			this.lblDepartments.Location = new System.Drawing.Point(17, 105);
			this.lblDepartments.Name = "lblDepartments";
			this.lblDepartments.Size = new System.Drawing.Size(67, 13);
			this.lblDepartments.TabIndex = 32;
			this.lblDepartments.Text = "Departments";
			// 
			// lstDepartment
			// 
			this.lstDepartment.FormattingEnabled = true;
			this.lstDepartment.Location = new System.Drawing.Point(20, 121);
			this.lstDepartment.Name = "lstDepartment";
			this.lstDepartment.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstDepartment.Size = new System.Drawing.Size(147, 69);
			this.lstDepartment.TabIndex = 27;
			// 
			// lblLocation
			// 
			this.lblLocation.AutoSize = true;
			this.lblLocation.Location = new System.Drawing.Point(322, 59);
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(48, 13);
			this.lblLocation.TabIndex = 31;
			this.lblLocation.Text = "Location";
			// 
			// lblJobTitle
			// 
			this.lblJobTitle.AutoSize = true;
			this.lblJobTitle.Location = new System.Drawing.Point(170, 59);
			this.lblJobTitle.Name = "lblJobTitle";
			this.lblJobTitle.Size = new System.Drawing.Size(47, 13);
			this.lblJobTitle.TabIndex = 30;
			this.lblJobTitle.Text = "Job Title";
			// 
			// cboJobTitle
			// 
			this.cboJobTitle.FormattingEnabled = true;
			this.cboJobTitle.Location = new System.Drawing.Point(173, 75);
			this.cboJobTitle.Name = "cboJobTitle";
			this.cboJobTitle.Size = new System.Drawing.Size(146, 21);
			this.cboJobTitle.TabIndex = 23;
			// 
			// cboLocation
			// 
			this.cboLocation.FormattingEnabled = true;
			this.cboLocation.Location = new System.Drawing.Point(325, 75);
			this.cboLocation.Name = "cboLocation";
			this.cboLocation.Size = new System.Drawing.Size(147, 21);
			this.cboLocation.TabIndex = 25;
			// 
			// lblRole
			// 
			this.lblRole.AutoSize = true;
			this.lblRole.Location = new System.Drawing.Point(17, 59);
			this.lblRole.Name = "lblRole";
			this.lblRole.Size = new System.Drawing.Size(29, 13);
			this.lblRole.TabIndex = 29;
			this.lblRole.Text = "Role";
			// 
			// cboRole
			// 
			this.cboRole.FormattingEnabled = true;
			this.cboRole.Location = new System.Drawing.Point(20, 75);
			this.cboRole.Name = "cboRole";
			this.cboRole.Size = new System.Drawing.Size(147, 21);
			this.cboRole.TabIndex = 22;
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(409, 13);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(60, 13);
			this.lblUserName.TabIndex = 26;
			this.lblUserName.Text = "User Name";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(412, 29);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(60, 20);
			this.txtUserName.TabIndex = 21;
			// 
			// lblLastName
			// 
			this.lblLastName.AutoSize = true;
			this.lblLastName.Location = new System.Drawing.Point(213, 13);
			this.lblLastName.Name = "lblLastName";
			this.lblLastName.Size = new System.Drawing.Size(58, 13);
			this.lblLastName.TabIndex = 24;
			this.lblLastName.Text = "Last Name";
			// 
			// txtLastName
			// 
			this.txtLastName.Location = new System.Drawing.Point(216, 29);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(190, 20);
			this.txtLastName.TabIndex = 19;
			// 
			// lblFirstName
			// 
			this.lblFirstName.AutoSize = true;
			this.lblFirstName.Location = new System.Drawing.Point(17, 13);
			this.lblFirstName.Name = "lblFirstName";
			this.lblFirstName.Size = new System.Drawing.Size(57, 13);
			this.lblFirstName.TabIndex = 20;
			this.lblFirstName.Text = "First Name";
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(20, 29);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(190, 20);
			this.txtFirstName.TabIndex = 18;
			// 
			// UserBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "UserBoundary";
			this.Size = new System.Drawing.Size(600, 337);
			this.Title = "Users";
			this.Load += new System.EventHandler(this.UserBoundary_Load);
			this.pnlControls.ResumeLayout(false);
			this.pnlControls.PerformLayout();
			this.gbxOtherOptions.ResumeLayout(false);
			this.gbxOtherOptions.PerformLayout();
			this.ResumeLayout(false);

        }

        private void LoadControlData()
        {
            using (DepartmentController theController = new DepartmentController())
            {
                lstDepartment.DataSource = theController.GetDepartments();
                lstDepartment.DisplayMember = "name";
                lstDepartment.ValueMember = "department_id";
            }

            using (JobTitleController theController = new JobTitleController())
            {
                cboJobTitle.DataSource = theController.GetJobTitles();
                cboJobTitle.DisplayMember = "name";
                cboJobTitle.ValueMember = "title_id";
            }

            using (LocationController theController = new LocationController())
            {
                cboLocation.DataSource = theController.GetLocations();
                cboLocation.DisplayMember = "name";
                cboLocation.ValueMember = "location_id";
            }

            using (RoleController theController = new RoleController())
            {
                cboRole.DataSource = theController.GetRoles();
                cboRole.DisplayMember = "name";
                cboRole.ValueMember = "role_id";
            }

        }

		private void SetAddingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboJobTitle.Enabled = true;
			cboLocation.Enabled = true;
			cboRole.Enabled = true;
			chkReceivesLeads.Enabled = true;
			chkShowReminders.Enabled = true;
			lstDepartment.Enabled = true;
			txtEmail.Enabled = true;
			txtFirstName.Enabled = true;
			txtLastName.Enabled = true;
			txtUserName.Enabled = true;


			this.State = BoundaryState.Adding;
			this.Title = "Add New User";
			this.IsDirty = false;
		}

		private void SetEditingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboJobTitle.Enabled = true;
			cboLocation.Enabled = true;
			cboRole.Enabled = true;
			chkReceivesLeads.Enabled = true;
			chkShowReminders.Enabled = true;
			lstDepartment.Enabled = true;
			txtEmail.Enabled = true;
			txtFirstName.Enabled = true;
			txtLastName.Enabled = true;
			txtUserName.Enabled = true;

			cboJobTitle.SelectedValue = MyUser.JobTitle.ID;
			cboLocation.SelectedValue = MyUser.Location.ID;
			cboRole.SelectedValue = MyUser.Role.ID;
			chkReceivesLeads.Checked = MyUser.ReceiveCrossLeads;
			chkShowReminders.Checked = MyUser.ShowReminders;
			txtEmail.Text = MyUser.EmailAddress;
			txtFirstName.Text = MyUser.FirstName;
			txtLastName.Text = MyUser.LastName;
			txtUserName.Text = MyUser.UserName;

			foreach (Administration.Department.Department oDept in MyUser.Departments)
			{
				int index = 0;
				while (index < lstDepartment.Items.Count)
				{
					if (Convert.ToInt32(((DataRowView)lstDepartment.Items[index])[DEPARTMENT_ID_INDEX]) == oDept.ID)
						lstDepartment.SelectedItems.Add(lstDepartment.Items[index]);
					index++;
				}
			}

			if (cboJobTitle.SelectedItem == null && MyUser.JobTitle.ID > 0)
				cboJobTitle.Text = MyUser.JobTitle.Name;
			if (cboLocation.SelectedItem == null && MyUser.Location.ID > 0)
				cboLocation.Text = MyUser.Location.Name;
			if (cboRole.SelectedItem == null && MyUser.Role.ID > 0)
				cboRole.Text = MyUser.Role.Name;

			this.State = BoundaryState.Editing;
			this.Title = "Edit User";
			this.IsDirty = false;
		}

		private void SetSearchingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboJobTitle.Enabled = false;
			cboLocation.Enabled = false;
			cboRole.Enabled = false;
			chkReceivesLeads.Enabled = false;
			chkShowReminders.Enabled = false;
			lstDepartment.Enabled = false;
			txtEmail.Enabled = false;
			txtFirstName.Enabled = true;
			txtLastName.Enabled = true;
			txtUserName.Enabled = true;

			this.State = BoundaryState.Searching;
			this.Title = "Search Users";
			this.IsDirty = false;
		}

		private new void Clear()
		{
			base.Clear();

			cboJobTitle.SelectedItem = null;
			cboLocation.SelectedItem = null;
			cboRole.SelectedItem = null;
			chkReceivesLeads.Checked = false;
			chkShowReminders.Checked = false;
			lstDepartment.SelectedItems.Clear();
			txtEmail.Clear();
			txtFirstName.Clear();
			txtLastName.Clear();
			txtUserName.Clear();
		}

		public bool CommitChanges()
		{
			try
			{
				if (!IsSelectionValid(cboJobTitle) && cboJobTitle.Text != MyUser.JobTitle.Name || string.IsNullOrEmpty(cboJobTitle.Text))
					throw new Exception("The \"Job Title\" is not valid.");
				if (!IsSelectionValid(cboLocation) && cboLocation.Text != MyUser.Location.Name || string.IsNullOrEmpty(cboLocation.Text))
					throw new Exception("The \"Location\" is not valid.");
				if (!IsSelectionValid(cboRole) && cboRole.Text != MyUser.Role.Name || string.IsNullOrEmpty(cboRole.Text))
					throw new Exception("The \"Role\" is not valid.");
				if (string.IsNullOrEmpty(txtFirstName.Text))
					throw new Exception("The \"First Name\" cannot be blank.");
				if (string.IsNullOrEmpty(txtLastName.Text))
					throw new Exception("The \"Last Name\" cannot be blank.");
				if (string.IsNullOrEmpty(txtUserName.Text))
					throw new Exception("The \"User Name\" cannot be blank.");
				if (lstDepartment.SelectedItems.Count == 0)
					throw new Exception("The user must have at least one \"Department\".");

				if (cboJobTitle.SelectedValue != null)
					MyUser.JobTitleID = Convert.ToInt32(cboJobTitle.SelectedValue);
				if (cboLocation.SelectedValue != null)
					MyUser.LocationID = Convert.ToInt32(cboLocation.SelectedValue);
				if (cboRole.SelectedValue != null)
					MyUser.RoleID = Convert.ToInt32(cboRole.SelectedValue);
				MyUser.ReceiveCrossLeads = chkReceivesLeads.Checked;
				MyUser.ShowReminders = chkShowReminders.Checked;
				MyUser.EmailAddress = txtEmail.Text;
				MyUser.FirstName = txtFirstName.Text;
				MyUser.LastName = txtLastName.Text;
				MyUser.UserName = txtUserName.Text;

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		public bool Save()
		{
			bool result = true;

			if (CommitChanges())
			{
				using (UserController theController = new UserController())
				{
					if (MyUser.ID > 0)
						result = theController.UpdateUser(MyUser);
					else
					{
						clsMyUser = theController.InsertUser(MyUser);

						result = (MyUser.ID > 0);
					}
				}
			}
			else
				result = false;

			return result;
		}

        #endregion


        #region Event Handlers

        private void UserBoundary_Load(object sender, EventArgs e)
        {
            cboJobTitle.SelectedItem = null;
            cboLocation.SelectedItem = null;
            cboRole.SelectedItem = null;
            lstDepartment.SelectedItems.Clear();
        }

        #endregion


		#region Events

		public event EventHandler<EventArgs> MyUserChanged;
		protected virtual void OnMyUserChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = MyUserChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion


        #region Constructor

        public UserBoundary()
        {
            InitializeComponent();

            LoadControlData();
        }

        #endregion

    }
}
