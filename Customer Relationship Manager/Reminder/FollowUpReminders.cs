using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Navigation;
using rkcrm.Objects.Customer;
using rkcrm.Objects.Note;
using rkcrm.Objects.Project;
using rkcrm.Searching.DropDowns;

namespace rkcrm.Reminder_Module
{
    public partial class FollowUpReminders : UserControl
    {


		#region Variables
		
		Note selectedNote = null;
		bool showAllNotes;
		private int intActive = 0;
		private int intOverdue = 0;

		private const int NOTE_ID_INDEX = 0;

		#endregion


		#region Properties

		public int ActiveCount
		{
			get { return intActive; }
		}

		public int OverdueCount
		{
			get { return intOverdue; }
		}

		#endregion

	
		#region Methods

		private void InitializeContextMenu()
		{
			using (NoteDropDown noteItems = new NoteDropDown(lvwNotesList, 0, 1, 2))
			{
				ToolStripDropDownButton theButton = (ToolStripDropDownButton)noteItems.Items["tdbMenuItems"];
			
				cmsNotes.Items.Add(theButton.DropDownItems["tsmEdit"]);
				cmsNotes.Items.Add(theButton.DropDownItems["tsmFollowUp"]);
				cmsNotes.Items.Add(new ToolStripSeparator());
				cmsNotes.Items.Add(new ToolStripSeparator());
				cmsNotes.Items.Add(theButton.DropDownItems["tsmOtherProjects"]);
			}

			using (ProjectDropDown projectItems = new ProjectDropDown(lvwNotesList, 1, 2))
			{
				ToolStripDropDownButton theButton = (ToolStripDropDownButton)projectItems.Items["tdbMenuItems"];

				cmsNotes.Items.Insert(3, theButton.DropDownItems["tsmEditProject"]);
				cmsNotes.Items.Insert(4, new ToolStripSeparator());
				cmsNotes.Items.Insert(5, theButton.DropDownItems["tsmSell"]);
				cmsNotes.Items.Insert(6, theButton.DropDownItems["tsmLose"]);
				cmsNotes.Items.Insert(7, theButton.DropDownItems["tsmReopen"]);
			}
		}

		private void Clear()
		{
			selectedNote = null;
			lvwNotesList.Items.Clear();
			ClearPreview();
			btnFollowUp.Enabled = false;
			btnNote.Enabled = false;
			btnProject.Enabled = false;
		}

		private void ClearPreview()
		{
			lblTitle.Text = string.Empty;
			DlblContacted.Text = string.Empty;
			DlblNotes.Text = string.Empty;
			DlblPurpose.Text = string.Empty;
		}

		private void LoadList()
		{
			ListViewItem newItem;
			DataTable oTable;

			lvwNotesList.Items.Clear();
			intActive = 0;
			intOverdue = 0;

			using (NoteController theContoller = new NoteController())
			{
				oTable = theContoller.getScheduledNotes(thisUser.ID, DateTime.Today, showAllNotes);
			}

			foreach (DataRow oRow in oTable.Rows)
			{
				newItem = new ListViewItem();

				newItem.Text = oRow["note_id"].ToString();
				newItem.SubItems.Add(oRow["project_id"].ToString());
				newItem.SubItems.Add(oRow["customer_id"].ToString());
				newItem.SubItems.Add(Convert.ToDateTime(oRow["next_follow_up"]).ToShortDateString());
				newItem.SubItems.Add(oRow["customer"].ToString());
				newItem.SubItems.Add(FormatPhoneNumber(oRow["phone_number"].ToString()));
				newItem.SubItems.Add(oRow["project"].ToString());

				if (thisUser.ID != Convert.ToInt32(oRow["sales_rep_id"]))
					newItem.BackColor = Color.LightGray;
				else if (Convert.ToDateTime(oRow["next_follow_up"]) < DateTime.Today)
				{
					newItem.BackColor = Color.IndianRed;
					intOverdue++;
				}

				lvwNotesList.Items.Add(newItem);

				intActive++;
			}

			tslActiveCount.Text = "Number of Active Notes: " + ActiveCount;
			tslOverdueCount.Text = "Number of Overdue Notes: " + OverdueCount;

			OnCountChanged(new EventArgs());
		}

		private void LoadPreview()
		{
			Project myProject = selectedNote.GetProject();
			Customer myCustomer = myProject.GetCustomer();

			lblTitle.Text = selectedNote.NextFollowUp.ToLongDateString() + " - " + myCustomer.Name + " - " + myProject.Name;
			DlblContacted.Text = myProject.GetContact().FullName;
			DlblPurpose.Text = selectedNote.GetContactPurpose().Name;
			DlblNotes.Text = selectedNote.Notes;
		}

		private NavigationScreen GetNavigationScreen()
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

		/// <summary>
		/// Format the given string to (xxx) xxx-xxxx
		/// </summary>
		/// <param name="PhoneNumber"></param>
		/// <returns></returns>
		private string FormatPhoneNumber(string PhoneNumber)
		{
			PhoneNumber = PhoneNumber.Insert(0, "(");
			PhoneNumber = PhoneNumber.Insert(4, ") ");
			PhoneNumber = PhoneNumber.Insert(9, "-");

			return PhoneNumber;
		}

		private bool IsNoteNeeded()
		{
			int noteCount;
			Project.ProjectStatus status;

			using (NoteController theController = new NoteController())
			{
				noteCount = theController.GetOpenNoteCount(selectedNote.ProjectID, selectedNote.DepartmentID);
			}

			using (ProjectController theController = new ProjectController())
			{
				status = theController.GetStatus(selectedNote.ProjectID, selectedNote.DepartmentID);
			}

			if (status == Project.ProjectStatus.Outstanding && noteCount < 2)
				return true;
			else
				return false;
		}

		private void RefreshMainForm()
		{
			NavigationScreen myNavigation = GetNavigationScreen();

			foreach (rkcrm.Base_Classes.ScreenBase oScreen in myNavigation.OpenScreens)
				if (oScreen is NoteScreen || oScreen is ProjectScreen)
					oScreen.RefreshData();
		}

		public void RefreshData()
		{
			ListViewItem selectedItem = null;

			if (lvwNotesList.SelectedItems.Count > 0)
				selectedItem = lvwNotesList.SelectedItems[0];

			Clear();
			LoadList();

			if (selectedItem != null)
				foreach (ListViewItem oItem in lvwNotesList.Items)
					if (oItem.Text == selectedItem.Text)
						oItem.Selected = true;
		}

		private bool AddNewNote()
		{
			AddNote oForm = new AddNote();
			Note newNote = new Note();
			newNote.ProjectID = selectedNote.ProjectID;
			oForm.MyNote = newNote;
			oForm.SalesSupportID = selectedNote.SalesSupportID;
			oForm.SalesRepID = selectedNote.SalesRepID;
			oForm.DepartmentID = selectedNote.DepartmentID;
			oForm.MethodID = selectedNote.MethodID;
			oForm.PurposeID = selectedNote.PurposeID;
			oForm.ContactID = selectedNote.ContactID;
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

			RefreshMainForm();

			return result;
		}

		private void RefreshOtherProjectsList()
		{
			foreach (Form oForm in Application.OpenForms)
				if (oForm is ViewOtherProjects)
					((ViewOtherProjects)oForm).MyCustomer = selectedNote.GetProject().GetCustomer();
		}

		#endregion


		#region Event Handlers

		private void FollowUpReminders_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		private void btnFollowUp_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("Would you like to add another note?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
				case DialogResult.Yes:
					if (AddNewNote())
						if (FollowUp(selectedNote))
							Clear();
					break;
				case DialogResult.Cancel:
					break;
				default:
					if (IsNoteNeeded())
					{
						MessageBox.Show("An outstanding project must have at least one note. Please enter a new note.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (AddNewNote())
							if (FollowUp(selectedNote))
								Clear();
					}
					else
						if (FollowUp(selectedNote))
							Clear();
					break;
			}

			LoadList();
		}

		private void btnFollowUpReport_Click(object sender, EventArgs e)
		{

		}

		private void lvwNotesList_DoubleClick(object sender, EventArgs e)
		{
			btnNote_Click(sender, e);
		}

		private void lvwNotesList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
			{
				using (NoteController theController = new NoteController())
				{
					selectedNote = theController.GetNote(Convert.ToInt32(e.Item.SubItems[NOTE_ID_INDEX].Text));
				}

				if (selectedNote != null)
				{
					LoadPreview();

					btnFollowUp.Enabled = (selectedNote.SalesRepID == thisUser.ID);
					btnNote.Enabled = true;
					btnProject.Enabled = true;
				}
				else
					ClearPreview();

				RefreshOtherProjectsList();
			}
			else
			{
				btnFollowUp.Enabled = false;
				btnNote.Enabled = false;
				btnProject.Enabled = false;
			}
		}

		private void btnNote_Click(object sender, EventArgs e)
		{
			Project myProject = selectedNote.GetProject();
			Customer myCustomer = myProject.GetCustomer();
			NavigationScreen myNavigation = GetNavigationScreen();

			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[0];

			myNavigation.btnCustomer.MyCustomer = myCustomer;
			myNavigation.btnCustomer.MyProject = myProject;

			myNavigation.btnCustomer.PerformClick();

			((NoteScreen)myNavigation.CurrentScreen).MyProject = myProject;
			((NoteScreen)myNavigation.CurrentScreen).MyNote = selectedNote;

			((MainForm)myNavigation.Parent).Activate();
		}

		private void btnProject_Click(object sender, EventArgs e)
		{
			Project myProject = selectedNote.GetProject();
			Customer myCustomer = myProject.GetCustomer();
			NavigationScreen myNavigation = GetNavigationScreen();

			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1];

			myNavigation.btnCustomer.MyCustomer = myCustomer;

			myNavigation.btnCustomer.PerformClick();

			((ProjectScreen)myNavigation.CurrentScreen).MyProject = myProject;

			((MainForm)myNavigation.Parent).Activate();
		}

		private void btnShow_Click(object sender, EventArgs e)
		{
			showAllNotes = !showAllNotes;

			LoadList();

			if (showAllNotes)
				btnShow.Text = "Hide Notes";
			else
				btnShow.Text = "Show All Notes";
		}

		#endregion


		#region Constructor

		public FollowUpReminders()
		{
			InitializeComponent();
			InitializeContextMenu();

			showAllNotes = false;
			Clear();
		}

		#endregion


		#region Custom Events

		public event EventHandler<EventArgs> CountChanged;
		protected virtual void OnCountChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = CountChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion


    }
}
