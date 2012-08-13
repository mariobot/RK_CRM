using System;
using System.Windows.Forms;

namespace rkcrm.Objects.Project.Lost_Report
{
	public partial class LostProjectForm : Form
	{

		#region Variables

		#endregion


		#region Properties

		public int SelectedDepartmentID
		{
			get { return lostProjectControls.MyLostProject.DepartmentID; }
		}

		#endregion


		#region Methods

		private bool Save()
		{
			if (lostProjectControls.CommitChanges())
			{
				using (LostProjectController theController = new LostProjectController())
				{
					return theController.InsertLostProjectReport(lostProjectControls.MyLostProject);
				}
			}
			else
				return false;
		}

		#endregion


		#region Event Handlers

		private void btnDone_Click(object sender, EventArgs e)
		{
			if (Save())
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion


		#region Constructor

		public LostProjectForm(int ProjectID)
		{
			InitializeComponent();
			lostProjectControls.MyProjectID = ProjectID;
			lostProjectControls.MyLostProject = new LostProjectReport();
		}

		public LostProjectForm(int ProjectID, int DepartmentID)
		{
			InitializeComponent();
			lostProjectControls.MyProjectID = ProjectID;
			lostProjectControls.MyLostProject = new LostProjectReport();

			lostProjectControls.cboDepartment.SelectedValue = DepartmentID;
			lostProjectControls.cboDepartment.Enabled = false;
		}

		#endregion


	}
}
