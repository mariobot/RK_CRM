using System;
using System.Windows.Forms;

namespace rkcrm.Reminder_Module
{
    public partial class RemindersForm : Form
    {
		
		#region Methods

		public void RefreshData()
		{
			followUpReminders1.RefreshData();
			assignmentReminders1.RefreshData();

			if (followUpReminders1.ActiveCount + assignmentReminders1.AssignmentCount == 0)
				this.Close();
		}

		#endregion
		
		
		#region Constructor

		public RemindersForm()
		{
			InitializeComponent();

			followUpReminders1.CountChanged += new EventHandler<EventArgs>(followUpReminders1_CountChanged);
			assignmentReminders1.CountChanged += new EventHandler<EventArgs>(assignmentReminders1_CountChanged);

			tcpCrossLeads.Text = "Cross Leads - " + assignmentReminders1.AssignmentCount;
		}

		#endregion


		#region Event Handlers

		void assignmentReminders1_CountChanged(object sender, EventArgs e)
		{
			tcpCrossLeads.Text = "Cross Leads - " + assignmentReminders1.AssignmentCount;
			
			if (followUpReminders1.ActiveCount + assignmentReminders1.AssignmentCount == 0)
				this.Close();
		}

		void followUpReminders1_CountChanged(object sender, EventArgs e)
		{
			tcpNotes.Text = "Notes - " + followUpReminders1.ActiveCount;

			if (followUpReminders1.ActiveCount + assignmentReminders1.AssignmentCount == 0)
				this.Close();
		}

		private void RemindersForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Form otherProjects = null;

			foreach (Form oForm in Application.OpenForms)
				if (oForm is rkcrm.Objects.Note.ViewOtherProjects)
					otherProjects = oForm;

			if (otherProjects != null)
				otherProjects.Close();
		}

		#endregion

    }
}
