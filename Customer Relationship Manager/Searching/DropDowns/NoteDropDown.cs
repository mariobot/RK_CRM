using System;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Navigation;
using rkcrm.Objects.Customer;
using rkcrm.Objects.Note;
using rkcrm.Objects.Project;
using rkcrm.Reminder_Module;

namespace rkcrm.Searching.DropDowns
{
	class NoteDropDown : ToolStripDropDown
	{

		#region Variables

		private ToolStripDropDownButton tdbMenuItems;
		private ToolStripButton tsbEdit;
		private ToolStripSeparator tss_0;
		private ToolStripButton tsbDelete;
		private ToolStripButton tsbRestore;
		private ToolStripSeparator tss_1;
		private ToolStripMenuItem tsmCustomer;
		private ToolStripMenuItem tsmProject;
		private ToolStripSeparator mss_0;
		private ToolStripMenuItem tsmEdit;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmDelete;
		private ToolStripMenuItem tsmRestore;
		private ToolStripSeparator mss_2;
		private ToolStripMenuItem tsmFollowUp;
		private ToolStripButton tsbFollowUp;

		private ListView theReferencedList;
		private int NoteIndex;
		private int ProjectIndex;
		private int CustomerIndex;
		private const int FOLLOW_UP_ON_QUOTES = 5;
		private ToolStripSeparator mss_3;
		private ToolStripMenuItem tsmOtherProjects;
		private ToolStripSeparator tss_2;
		private ToolStripButton tsbOtherProjects;
		private ToolStripSeparator mss_4;
		private ToolStripMenuItem tsmProperties;
		private ToolStripSeparator tss_3;
		private ToolStripButton tsbProperties;
		private const int COMPLETED_INDEX = 3;
		private const int ADMINISTRATOR = 1;

		#endregion


		#region Security Variables

		private bool bolDelete;
		private bool bolFollowUp;
		private bool bolRestore;
		private bool bolGotoNote;
		private bool bolViewOtherProjects;
		private bool bolViewProperties;

		#endregion


		#region Properties

		public bool HasDelete
		{
			get { return bolDelete; }
		}

		public bool HasFollowUp
		{
			get { return bolFollowUp; }
		}

		public bool HasRestore
		{
			get { return bolRestore; }
		}

		public bool HasGotoNote
		{
			get { return bolGotoNote; }
		}

		public bool HasViewOtherProjects
		{
			get { return bolViewOtherProjects; }
		}

		public bool HasViewProperties
		{
			get { return bolViewProperties; }
		}
		#endregion


		#region Methods

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteDropDown));
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tdbMenuItems = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmCustomer = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmFollowUp = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmOtherProjects = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.tsbRestore = new System.Windows.Forms.ToolStripButton();
			this.tsbFollowUp = new System.Windows.Forms.ToolStripButton();
			this.tss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbOtherProjects = new System.Windows.Forms.ToolStripButton();
			this.tss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbProperties = new System.Windows.Forms.ToolStripButton();
			this.SuspendLayout();
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(6, 23);
			// 
			// tss_1
			// 
			this.tss_1.Name = "tss_1";
			this.tss_1.Size = new System.Drawing.Size(6, 23);
			// 
			// tdbMenuItems
			// 
			this.tdbMenuItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tdbMenuItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCustomer,
            this.tsmProject,
            this.mss_0,
            this.tsmEdit,
            this.mss_1,
            this.tsmDelete,
            this.tsmRestore,
            this.mss_2,
            this.tsmFollowUp,
            this.mss_3,
            this.tsmOtherProjects,
            this.mss_4,
            this.tsmProperties});
			this.tdbMenuItems.Image = ((System.Drawing.Image)(resources.GetObject("tdbMenuItems.Image")));
			this.tdbMenuItems.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tdbMenuItems.Name = "tdbMenuItems";
			this.tdbMenuItems.Size = new System.Drawing.Size(29, 20);
			this.tdbMenuItems.Text = "toolStripDropDownButton1";
			// 
			// tsmCustomer
			// 
			this.tsmCustomer.Image = global::rkcrm.Properties.Resources.Customer;
			this.tsmCustomer.Name = "tsmCustomer";
			this.tsmCustomer.Size = new System.Drawing.Size(177, 22);
			this.tsmCustomer.Text = "Customer";
			// 
			// tsmProject
			// 
			this.tsmProject.Image = global::rkcrm.Properties.Resources.Project_Icon_28x28;
			this.tsmProject.Name = "tsmProject";
			this.tsmProject.Size = new System.Drawing.Size(177, 22);
			this.tsmProject.Text = "Project";
			// 
			// mss_0
			// 
			this.mss_0.Name = "mss_0";
			this.mss_0.Size = new System.Drawing.Size(174, 6);
			// 
			// tsmEdit
			// 
			this.tsmEdit.Image = global::rkcrm.Properties.Resources.Edit_Note_28x28;
			this.tsmEdit.Name = "tsmEdit";
			this.tsmEdit.Size = new System.Drawing.Size(177, 22);
			this.tsmEdit.Text = "Edit Note";
			this.tsmEdit.Click += new System.EventHandler(this.Edit_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(174, 6);
			// 
			// tsmDelete
			// 
			this.tsmDelete.Image = global::rkcrm.Properties.Resources.Delete_Note_Icon;
			this.tsmDelete.Name = "tsmDelete";
			this.tsmDelete.Size = new System.Drawing.Size(177, 22);
			this.tsmDelete.Text = "Delete Note";
			this.tsmDelete.Visible = false;
			this.tsmDelete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// tsmRestore
			// 
			this.tsmRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsmRestore.Name = "tsmRestore";
			this.tsmRestore.Size = new System.Drawing.Size(177, 22);
			this.tsmRestore.Text = "Restore Note";
			this.tsmRestore.Visible = false;
			this.tsmRestore.Click += new System.EventHandler(this.Restore_Click);
			// 
			// mss_2
			// 
			this.mss_2.Name = "mss_2";
			this.mss_2.Size = new System.Drawing.Size(174, 6);
			this.mss_2.Visible = false;
			// 
			// tsmFollowUp
			// 
			this.tsmFollowUp.Image = global::rkcrm.Properties.Resources.Follow_Up_Icon;
			this.tsmFollowUp.Name = "tsmFollowUp";
			this.tsmFollowUp.Size = new System.Drawing.Size(177, 22);
			this.tsmFollowUp.Text = "Follow Up";
			this.tsmFollowUp.Click += new System.EventHandler(this.FollowUp_Click);
			// 
			// mss_3
			// 
			this.mss_3.Name = "mss_3";
			this.mss_3.Size = new System.Drawing.Size(174, 6);
			// 
			// tsmOtherProjects
			// 
			this.tsmOtherProjects.Name = "tsmOtherProjects";
			this.tsmOtherProjects.Size = new System.Drawing.Size(177, 22);
			this.tsmOtherProjects.Text = "View Other Projects";
			this.tsmOtherProjects.Click += new System.EventHandler(this.OtherProjects_Click);
			// 
			// mss_4
			// 
			this.mss_4.Name = "mss_4";
			this.mss_4.Size = new System.Drawing.Size(174, 6);
			// 
			// tsmProperties
			// 
			this.tsmProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsmProperties.Name = "tsmProperties";
			this.tsmProperties.Size = new System.Drawing.Size(177, 22);
			this.tsmProperties.Text = "Properties";
			this.tsmProperties.Click += new System.EventHandler(this.Properties_Click);
			// 
			// tsbEdit
			// 
			this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbEdit.Image = global::rkcrm.Properties.Resources.Edit_Note_28x28;
			this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEdit.Name = "tsbEdit";
			this.tsbEdit.Size = new System.Drawing.Size(23, 20);
			this.tsbEdit.Text = "Edit Note";
			this.tsbEdit.Click += new System.EventHandler(this.Edit_Click);
			// 
			// tsbDelete
			// 
			this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbDelete.Image = global::rkcrm.Properties.Resources.Delete_Note_Icon;
			this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Size = new System.Drawing.Size(23, 20);
			this.tsbDelete.Text = "Delete Note";
			this.tsbDelete.Visible = false;
			this.tsbDelete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// tsbRestore
			// 
			this.tsbRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRestore.Name = "tsbRestore";
			this.tsbRestore.Size = new System.Drawing.Size(23, 20);
			this.tsbRestore.Text = "Restore Note";
			this.tsbRestore.Visible = false;
			this.tsbRestore.Click += new System.EventHandler(this.Restore_Click);
			// 
			// tsbFollowUp
			// 
			this.tsbFollowUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbFollowUp.Image = global::rkcrm.Properties.Resources.Follow_Up_Icon;
			this.tsbFollowUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbFollowUp.Name = "tsbFollowUp";
			this.tsbFollowUp.Size = new System.Drawing.Size(23, 20);
			this.tsbFollowUp.Text = "Follow Up";
			this.tsbFollowUp.Click += new System.EventHandler(this.FollowUp_Click);
			// 
			// tss_2
			// 
			this.tss_2.Name = "tss_2";
			this.tss_2.Size = new System.Drawing.Size(6, 23);
			// 
			// tsbOtherProjects
			// 
			this.tsbOtherProjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbOtherProjects.Image = ((System.Drawing.Image)(resources.GetObject("tsbOtherProjects.Image")));
			this.tsbOtherProjects.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbOtherProjects.Name = "tsbOtherProjects";
			this.tsbOtherProjects.Size = new System.Drawing.Size(23, 20);
			this.tsbOtherProjects.Text = "View Other Projects";
			this.tsbOtherProjects.Click += new System.EventHandler(this.OtherProjects_Click);
			// 
			// tss_3
			// 
			this.tss_3.Name = "tss_3";
			this.tss_3.Size = new System.Drawing.Size(6, 23);
			// 
			// tsbProperties
			// 
			this.tsbProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsbProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbProperties.Name = "tsbProperties";
			this.tsbProperties.Size = new System.Drawing.Size(23, 20);
			this.tsbProperties.Text = "Properties";
			this.tsbProperties.Click += new System.EventHandler(this.Properties_Click);
			// 
			// NoteDropDown
			// 
			this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tdbMenuItems,
            this.tsbEdit,
            this.tss_0,
            this.tsbDelete,
            this.tsbRestore,
            this.tss_1,
            this.tsbFollowUp,
            this.tss_2,
            this.tsbOtherProjects,
            this.tss_3,
            this.tsbProperties});
			this.Size = new System.Drawing.Size(31, 257);
			this.ResumeLayout(false);

		}

		private void InitializeOtherDropDowns()
		{
			if (ProjectIndex > -1)
			{
				//Add the project options to this drop down
				using (ProjectDropDown projectItems = new ProjectDropDown(theReferencedList, ProjectIndex, CustomerIndex))
				{
					ToolStripDropDownButton theButton = (ToolStripDropDownButton)projectItems.Items["tdbMenuItems"];

					while (theButton.DropDownItems.Count > 0)
						tsmProject.DropDownItems.Add(theButton.DropDownItems[0]);
				}

			}

			if (CustomerIndex > -1)
			{

				//Add the customer options to this drop down
				using (CustomerDropDown customerItems = new CustomerDropDown(theReferencedList, CustomerIndex))
				{
					ToolStripDropDownButton theButton = (ToolStripDropDownButton)customerItems.Items["tdbMenuItems"];

					while (theButton.DropDownItems.Count > 0)
						tsmCustomer.DropDownItems.Add(theButton.DropDownItems[0]);
				}

			}
		}

		private void Enable()
		{
			tsbDelete.Enabled = true;
			tsbEdit.Enabled = true;
			tsbFollowUp.Enabled = true;
			tsbRestore.Enabled = true;
			tsbProperties.Enabled = true;
			tsbOtherProjects.Enabled = true;
			tsmCustomer.Enabled = true;
			tsmDelete.Enabled = true;
			tsmEdit.Enabled = true;
			tsmFollowUp.Enabled = (Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems["sales_rep_id"]) == thisUser.ID || thisUser.RoleID == ADMINISTRATOR);
			tsmProject.Enabled = true;
			tsmRestore.Enabled = true;
			tsmProperties.Enabled = true;
			tsmOtherProjects.Enabled = true;
		}

		private void Disable()
		{
			tsbDelete.Enabled = false;
			tsbEdit.Enabled = false;
			tsbFollowUp.Enabled = false;
			tsbRestore.Enabled = false;
			tsbProperties.Enabled = false;
			tsbOtherProjects.Enabled = false;
			tsmCustomer.Enabled = false;
			tsmDelete.Enabled = false;
			tsmEdit.Enabled = false;
			tsmFollowUp.Enabled = false;
			tsmProject.Enabled = false;
			tsmRestore.Enabled = false;
			tsmProperties.Enabled = false;
			tsmOtherProjects.Enabled = false;
		}

		private NavigationScreen GetNavigationScreen()
		{
			Control myNavigation = theReferencedList;

			while (!(myNavigation is Navigation.NavigationScreen) && myNavigation.Parent != null)
				myNavigation = myNavigation.Parent;

			if (myNavigation is NavigationScreen)
				return (NavigationScreen)myNavigation;
			else
			{
				MainForm theMainForm = null;

				foreach (Form oForm in Application.OpenForms)
					if (oForm is MainForm)
						theMainForm = (MainForm)oForm;

				if (theMainForm != null)
					return theMainForm.theNavigationScreen;
				else
					return null;
			}
		}

		private bool IsNoteNeeded(Note theNote)
		{
			int noteCount;
			Project.ProjectStatus status;
			ListViewItem theItem = theReferencedList.SelectedItems[0];

			using (NoteController theController = new NoteController())
			{
				noteCount = theController.GetOpenNoteCount(theNote.ProjectID, theNote.DepartmentID);
			}

			using (ProjectController theController = new ProjectController())
			{
				status = theController.GetStatus(theNote.ProjectID, theNote.DepartmentID);
			}

			//The note count should be 1 because the note has not been followed up with yet
			if (status == Project.ProjectStatus.Outstanding && noteCount == 1)
				return true;
			else
				return false;
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
					if (oScreen is NoteScreen || oScreen is ProjectScreen)
						oScreen.RefreshData();
		}

		public void DetermineAccess()
		{
			bolDelete = thisUser.MyTasks.Contains((int)Tasks.Delete);
			bolFollowUp = thisUser.MyTasks.Contains((int)Tasks.FollowUp);
			bolRestore = thisUser.MyTasks.Contains((int)Tasks.Restore);
			bolGotoNote = thisUser.MyTasks.Contains((int)Tasks.GotoNote);
			bolViewOtherProjects = thisUser.MyTasks.Contains((int)Tasks.ViewOtherProjects);
			bolViewProperties = thisUser.MyTasks.Contains((int)Tasks.ViewProperties);

			tsmDelete.Visible = tsbDelete.Visible = HasDelete;
			tsmEdit.Visible = tsbEdit.Visible = HasGotoNote;
			tsmFollowUp.Visible = tsbFollowUp.Visible = HasFollowUp;
			tsmOtherProjects.Visible = tsbOtherProjects.Visible = HasViewOtherProjects;
			tsmProperties.Visible = tsbProperties.Visible = HasViewProperties;
			tsmRestore.Visible = tsbRestore.Visible = HasRestore;

			tss_0.Visible = mss_0.Visible = (HasDelete || HasRestore) && HasGotoNote;
			tss_1.Visible = mss_1.Visible = HasFollowUp;
			tss_2.Visible = mss_2.Visible = HasViewOtherProjects;
			tss_3.Visible = mss_3.Visible = HasViewProperties;
		}

		#endregion


		#region Event Handlers

		void theReferencedList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
				if (e.Item.SubItems[NoteIndex].Text != string.Empty)
					Enable();
				else
					Disable();
			else
				Disable();
		}

		private void Delete_Click(object sender, System.EventArgs e)
		{
			bool success;

			using (NoteController theController = new NoteController())
			{
				success = theController.ArchiveNote(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[NoteIndex].Text));
			}

			if (success)
				theReferencedList.SelectedItems[0].BackColor = Color.LightSteelBlue;

		}

		private void Edit_Click(object sender, System.EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[0];


			using (CustomerController theController = new CustomerController())
			{
				myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[CustomerIndex].Text));
			}
			using (ProjectController theController = new ProjectController())
			{
				myNavigation.btnCustomer.MyProject = theController.GetProject(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text));
			}

			myNavigation.btnCustomer.PerformClick();

			((NoteScreen)myNavigation.CurrentScreen).MyProject = myNavigation.btnCustomer.MyProject;

			using (NoteController theController = new NoteController())
			{
				((NoteScreen)myNavigation.CurrentScreen).MyNote = theController.GetNote(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[NoteIndex].Text));
			}
		}

		private void FollowUp_Click(object sender, System.EventArgs e)
		{
			ListViewItem selectedItem = theReferencedList.SelectedItems[0];
			Note theNote;
			bool success = true;

			using (NoteController theController = new NoteController())
			{
				theNote = theController.GetNote(Convert.ToInt32(selectedItem.SubItems[NoteIndex].Text));
			}

			if (IsNoteNeeded(theNote))
			{
				Note newNote = new Note();
				newNote.ProjectID = theNote.ProjectID;

				AddNote oForm = new AddNote();
				oForm.MyNote = newNote;
				oForm.SalesSupportID = theNote.SalesSupportID;
				oForm.SalesRepID = theNote.SalesRepID;
				oForm.DepartmentID = theNote.DepartmentID;
				oForm.MethodID = theNote.MethodID;
				oForm.PurposeID = FOLLOW_UP_ON_QUOTES;
				oForm.ContactID = theNote.ContactID;
				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					using (NoteController theController = new NoteController())
					{
						newNote = theController.InsertNote(newNote);

						success = (newNote.ID > 0);
					}
				}
				else
					success = false;
			}

			if (success)
			{
				using (NoteController theController = new NoteController())
				{
					theNote.Completed = DateTime.Today;

					if (theController.UpdateNote(theNote))
						RefreshReminders();
				}
			}

		}

		private void Restore_Click(object sender, System.EventArgs e)
		{
			bool success;

			using (NoteController theController = new NoteController())
			{
				success = theController.RestoreNote(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[NoteIndex].Text));
			}

			if (success)
				theReferencedList.SelectedItems[0].BackColor = Color.White;
		}

		private void OtherProjects_Click(object sender, EventArgs e)
		{
			ViewOtherProjects oForm = null;
			Customer theCustomer = null;

			using (CustomerController theController = new CustomerController())
			{
				theCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[CustomerIndex].Text));
			}

			foreach (Form o in Application.OpenForms)
				if (o is ViewOtherProjects)
					oForm = (ViewOtherProjects)o;

			if (oForm == null)
			{
				oForm = new ViewOtherProjects();
				oForm.MyCustomer = theCustomer;
				oForm.Show();
			}
			else
				oForm.MyCustomer = theCustomer;
		}

		private void Properties_Click(object sender, EventArgs e)
		{
			Note theNote = null;
			Objects.PropertiesWindow oForm = null;

			if (!string.IsNullOrEmpty(theReferencedList.SelectedItems[0].SubItems[NoteIndex].Text))
			{
				using (NoteController theController = new NoteController())
				{
					theNote = theController.GetNote(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[NoteIndex].Text));
				}

				if (theNote != null)
				{
					oForm = new rkcrm.Objects.PropertiesWindow();
					oForm.SelectedObject = theNote;
					oForm.Text = "Note Properties";
					oForm.Show();
				}
			}
		}

		#endregion


		#region Enumerations

		private enum Tasks
		{
			Delete = 40,
			FollowUp = 25,
			Restore = 41,
			GotoNote = 7,
			ViewOtherProjects = 26,
			ViewProperties = 20
		};

		#endregion


		#region Constructor

		public NoteDropDown(ListView ReferencedList, int NoteIDIndex, int ProjectIDIndex, int CustomerIDIndex)
			: base()
		{
			theReferencedList = ReferencedList;
			theReferencedList.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(theReferencedList_ItemSelectionChanged);
			NoteIndex = NoteIDIndex;
			ProjectIndex = ProjectIDIndex;
			CustomerIndex = CustomerIDIndex;

			InitializeComponent();
			InitializeOtherDropDowns();

			DetermineAccess();
			Disable();
		}

		#endregion

	}
}
