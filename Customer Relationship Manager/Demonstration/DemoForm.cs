using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.Department;
using rkcrm.Administration.Job_Title;
using rkcrm.Administration.Location;
using rkcrm.Administration.Role;

namespace rkcrm.Demonstration
{
    public partial class DemoForm : Form
    {

        #region Variables

        private bool IsLoading = false;
        
        #endregion


        #region Constructor

        public DemoForm()
        {
            InitializeComponent();
            myBoundary.lstDepartment.SelectedIndexChanged += new EventHandler(lstDepartment_SelectedIndexChanged);
            myBoundary.cboJobTitle.SelectedValueChanged += new EventHandler(cboJobTitle_SelectedValueChanged);
            myBoundary.cboLocation.SelectedValueChanged += new EventHandler(cboLocation_SelectedValueChanged);
            myBoundary.cboRole.SelectedValueChanged += new EventHandler(cboRole_SelectedValueChanged);
            myBoundary.chkReceivesLeads.CheckedChanged += new EventHandler(chkReceivesLeads_CheckedChanged);
            myBoundary.chkShowReminders.CheckedChanged += new EventHandler(chkShowReminders_CheckedChanged);
        }

        #endregion


        #region Methods

        private void LoadUserData()
        {
            myBoundary.txtFirstName.Text = thisUser.FirstName;
            myBoundary.txtLastName.Text = thisUser.LastName;
            myBoundary.txtUserName.Text = thisUser.Name;
            myBoundary.cboRole.SelectedValue = thisUser.Role.ID;
            myBoundary.cboLocation.SelectedValue = thisUser.Location.ID;
            myBoundary.cboJobTitle.SelectedValue = thisUser.JobTitle.ID;
            myBoundary.txtEmail.Text = thisUser.EmailAddress;
            myBoundary.chkShowReminders.Checked = thisUser.ShowReminders;
            myBoundary.chkReceivesLeads.Checked = thisUser.ReceivesCrossLeads;

            //For each department the user is assigned too, search for and mark as selected in the available department list
            try
            {
                foreach (Department oDept in thisUser.Departments)
                {
                    int i = 0;
                    while (i < myBoundary.lstDepartment.Items.Count)
                    {
                        if (Convert.ToInt32(((DataRowView)myBoundary.lstDepartment.Items[i])[0]) == oDept.ID)
                            myBoundary.lstDepartment.SelectedItems.Add(myBoundary.lstDepartment.Items[i]);
                        i++;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ", " + e.StackTrace);
            }
        }

        #endregion


        #region Event Handlers

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            IsLoading = true;

            thisUser.Refresh();
            LoadUserData();

            IsLoading = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            MainForm theMainForm = null;

            foreach (Form o in Application.OpenForms)
            {
                if (o is MainForm)
                {
                    theMainForm = (MainForm)o;
                }
            }

            if (theMainForm != null)
            {
                theMainForm.tsmDemoMode.PerformClick();
                this.Close();
            }
        }

        private void DemoForm_Load(object sender, EventArgs e)
        {
            IsLoading = true;

            thisUser.Refresh();
            LoadUserData();

            myBoundary.txtFirstName.Enabled = false;
            myBoundary.txtLastName.Enabled = false;
            myBoundary.txtUserName.Enabled = false;
            myBoundary.txtEmail.Enabled = false;

            IsLoading = false;
        }

        void cboJobTitle_SelectedValueChanged(object sender, EventArgs e)
        {
			if (!IsLoading && myBoundary.cboJobTitle.SelectedValue != null)
				thisUser.JobTitleID = Convert.ToInt32(myBoundary.cboJobTitle.SelectedValue);
        }

        void cboLocation_SelectedValueChanged(object sender, EventArgs e)
        {
			if (!IsLoading && myBoundary.cboLocation.SelectedValue != null)
				thisUser.LocationID = Convert.ToInt32(myBoundary.cboLocation.SelectedValue);
        }

        void cboRole_SelectedValueChanged(object sender, EventArgs e)
        {
			if (!IsLoading && myBoundary.cboRole.SelectedValue != null)
				thisUser.RoleID = Convert.ToInt32(myBoundary.cboRole.SelectedValue);
        }

        void chkReceivesLeads_CheckedChanged(object sender, EventArgs e)
        {
            thisUser.ReceivesCrossLeads = myBoundary.chkReceivesLeads.Checked;
        }

        void chkShowReminders_CheckedChanged(object sender, EventArgs e)
        {
            thisUser.ShowReminders = myBoundary.chkShowReminders.Checked;
        }

        void lstDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                thisUser.Departments.Clear();

                foreach (DataRowView oRow in myBoundary.lstDepartment.SelectedItems)
                    thisUser.Departments.Add(Convert.ToInt32(oRow[0]));
            }
        }

        #endregion        
    }
}
