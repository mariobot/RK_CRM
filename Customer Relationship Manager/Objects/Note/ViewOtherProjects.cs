using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Objects.Customer;
using rkcrm.Navigation;
using rkcrm.Reminder_Module;
using rkcrm.Searching.DropDowns;
using rkcrm.Objects.Project;

namespace rkcrm.Objects.Note
{
	class ViewOtherProjects : ObjectListBase
	{

		#region Variables

		private System.Windows.Forms.ColumnHeader chNoteID;
		private System.Windows.Forms.ColumnHeader chProjectName;
		private System.Windows.Forms.ColumnHeader chNextFollowUp;
		private System.Windows.Forms.ColumnHeader chDepartment;
		private System.Windows.Forms.ColumnHeader chPurpose;
		private System.Windows.Forms.ColumnHeader chNotes;

		private Customer.Customer clsMyCustomer;
		private ContextMenuStrip cmsNotes;
		private System.ComponentModel.IContainer components;
		private ColumnHeader chProjectID;
		private ColumnHeader chCustomerID;
		private Note clsMyNote;
		private const int ADMINISTRATOR = 1;

		#endregion


		#region Properties

		public Customer.Customer MyCustomer
		{
			get { return clsMyCustomer; }
			set
			{
				clsMyCustomer = value;

				if (value.ID > 0)
				{
					this.Title = "Notes From Other Projects Associated With " + value.Name;
					LoadList();
				}
				else
					this.Title = "Notes From Other Projects Associated With Customer";
			}
		}

		public Note MyNote
		{
			get { return clsMyNote; }
			set { clsMyNote = value; }
		}

		#endregion


		#region Methods

		private void InitializeContextMenu()
		{
			using (NoteDropDown noteItems = new NoteDropDown(lvwResults, 0, 1, 2))
			{
				ToolStripDropDownButton theButton = (ToolStripDropDownButton)noteItems.Items["tdbMenuItems"];

				cmsNotes.Items.Add(theButton.DropDownItems["tsmEdit"]);
				cmsNotes.Items.Add(theButton.DropDownItems["tsmFollowUp"]);
				cmsNotes.Items.Add(new ToolStripSeparator());
			}

			using (ProjectDropDown projectItems = new ProjectDropDown(lvwResults, 1, 2))
			{
				ToolStripDropDownButton theButton = (ToolStripDropDownButton)projectItems.Items["tdbMenuItems"];

				cmsNotes.Items.Add(theButton.DropDownItems["tsmEditProject"]);
				cmsNotes.Items.Add(new ToolStripSeparator());
				cmsNotes.Items.Add(theButton.DropDownItems["tsmSell"]);
				cmsNotes.Items.Add(theButton.DropDownItems["tsmLose"]);
				cmsNotes.Items.Add(theButton.DropDownItems["tsmReopen"]);
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.chNoteID = new System.Windows.Forms.ColumnHeader();
			this.chProjectName = new System.Windows.Forms.ColumnHeader();
			this.chNextFollowUp = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chPurpose = new System.Windows.Forms.ColumnHeader();
			this.chNotes = new System.Windows.Forms.ColumnHeader();
			this.cmsNotes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.chCustomerID = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Text = "Close";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Image = global::rkcrm.Properties.Resources.Follow_Up16x16;
			this.btnOK.Location = new System.Drawing.Point(12, 10);
			this.btnOK.Size = new System.Drawing.Size(95, 30);
			this.btnOK.Text = "&Follow Up";
			this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lvwResults
			// 
			this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNoteID,
            this.chProjectID,
            this.chCustomerID,
            this.chProjectName,
            this.chNextFollowUp,
            this.chDepartment,
            this.chPurpose,
            this.chNotes});
			this.lvwResults.ContextMenuStrip = this.cmsNotes;
			this.lvwResults.Location = new System.Drawing.Point(0, 50);
			this.lvwResults.Size = new System.Drawing.Size(784, 190);
			this.lvwResults.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwResults_ItemSelectionChanged);
			// 
			// chNoteID
			// 
			this.chNoteID.Text = "Note ID";
			this.chNoteID.Width = 0;
			// 
			// chProjectName
			// 
			this.chProjectName.Text = "Project Name";
			this.chProjectName.Width = 180;
			// 
			// chNextFollowUp
			// 
			this.chNextFollowUp.Text = "Next Follow Up";
			this.chNextFollowUp.Width = 85;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 90;
			// 
			// chPurpose
			// 
			this.chPurpose.Text = "Purpose";
			this.chPurpose.Width = 160;
			// 
			// chNotes
			// 
			this.chNotes.Text = "Notes";
			this.chNotes.Width = 256;
			// 
			// cmsNotes
			// 
			this.cmsNotes.Name = "cmsNotes";
			this.cmsNotes.Size = new System.Drawing.Size(61, 4);
			// 
			// chProjectID
			// 
			this.chProjectID.Text = "Project ID";
			this.chProjectID.Width = 0;
			// 
			// chCustomerID
			// 
			this.chCustomerID.Text = "Customer ID";
			this.chCustomerID.Width = 0;
			// 
			// ViewOtherProjects
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(784, 290);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.IsSearchable = false;
			this.Name = "ViewOtherProjects";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Notes From Other Projects";
			this.Title = "Notes From Other Project Associated With Customer";
			this.Controls.SetChildIndex(this.lvwResults, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void LoadList()
		{
			ListViewItem oItem;

			lvwResults.Items.Clear();

			using (NoteController theController = new NoteController())
			{
				foreach (DataRow oRow in theController.GetOpenNotes(MyCustomer.ID).Rows)
				{
					oItem = new ListViewItem();
					oItem.Text = oRow["note_id"].ToString();
					oItem.SubItems.Add(oRow["project_id"].ToString());
					oItem.SubItems.Add(oRow["customer_id"].ToString());
					oItem.SubItems.Add(oRow["project"].ToString());
					oItem.SubItems.Add(Convert.ToDateTime(oRow["next_follow_up"]).ToShortDateString());
					oItem.SubItems.Add(oRow["department"].ToString());
					oItem.SubItems.Add(oRow["purpose"].ToString());
					oItem.SubItems.Add(oRow["notes"].ToString());

					lvwResults.Items.Add(oItem);
				}
			}
		}

		private NavigationScreen GetNavigationScreen()
		{
			NavigationScreen myNavigation = null;
			MainForm theMainForm = null;

			foreach (Form oForm in Application.OpenForms)
				if (oForm is MainForm)
					theMainForm = (MainForm)oForm;

			if (theMainForm != null)
				myNavigation = theMainForm.theNavigationScreen;

			return myNavigation;
		}

		public void RefreshReminders()
		{
			RemindersForm theReminders = null;

			foreach (Form oForm in Application.OpenForms)
				if (oForm is RemindersForm)
					theReminders = (RemindersForm)oForm;

			if (theReminders != null)
				theReminders.RefreshData();

			NavigationScreen myNavigation = GetNavigationScreen();

			if (myNavigation != null)
				foreach (rkcrm.Base_Classes.ScreenBase oScreen in myNavigation.OpenScreens)
					if (oScreen is NoteScreen || oScreen is rkcrm.Objects.Project.ProjectScreen)
						oScreen.RefreshData();
		}

		private bool AddNewNote()
		{
			AddNote oForm = new AddNote();
			Note newNote = new Note();
			newNote.ProjectID = MyNote.ProjectID;
			oForm.MyNote = newNote;
			oForm.SalesSupportID = MyNote.SalesSupportID;
			oForm.SalesRepID = MyNote.SalesRepID;
			oForm.DepartmentID = MyNote.DepartmentID;
			oForm.MethodID = MyNote.MethodID;
			oForm.PurposeID = MyNote.PurposeID;
			oForm.ContactID = MyNote.ContactID;
			oForm.ShowDialog();

			if (oForm.DialogResult == DialogResult.OK)
			{
				using (NoteController theController = new NoteController())
				{
					oForm.MyNote = theController.InsertNote(oForm.MyNote);

					return (oForm.MyNote.ID > 0);
				}
			}
			else
				return false;
		}

		private bool FollowUp(Note theNote)
		{
			bool result = false;

			theNote.Completed = DateTime.Today;

			using (NoteController theController = new NoteController())
			{
				result = theController.UpdateNote(theNote);
			}

			RefreshReminders();

			return result;
		}

		private bool IsNoteNeeded()
		{
			int noteCount;
			Project.Project.ProjectStatus status;

			using (NoteController theController = new NoteController())
			{
				noteCount = theController.GetOpenNoteCount(MyNote.ProjectID, MyNote.DepartmentID);
			}

			using (ProjectController theController = new ProjectController())
			{
				status = theController.GetStatus(MyNote.ProjectID, MyNote.DepartmentID);
			}

			if (status == Project.Project.ProjectStatus.Outstanding && noteCount < 2)
				return true;
			else
				return false;
		}

		#endregion


		#region Event Handlers

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void lvwResults_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if(e.IsSelected)
				using (NoteController theController = new NoteController())
				{
					MyNote = theController.GetNote(Convert.ToInt32(e.Item.SubItems[0].Text));
				}

			btnOK.Enabled = e.IsSelected && (MyNote.SalesRepID == thisUser.ID || thisUser.RoleID == ADMINISTRATOR);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("Would you like to add another note?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
				case DialogResult.Yes:
					if (AddNewNote())
						if (FollowUp(MyNote))
							Clear();
					break;
				case DialogResult.Cancel:
					break;
				default:
					if (IsNoteNeeded())
					{
						MessageBox.Show("An outstanding project must have at least one note. Please enter a new note.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (AddNewNote())
							if (FollowUp(MyNote))
								Clear();
					}
					else
						if (FollowUp(MyNote))
							Clear();
					break;
			}

			LoadList();

		}

		#endregion


		#region Constructor

		public ViewOtherProjects()
			: base()
		{
			InitializeComponent();
			InitializeContextMenu();
		}
		
		#endregion
	}
}
