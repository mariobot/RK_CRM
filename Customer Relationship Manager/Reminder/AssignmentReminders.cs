using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Navigation;
using rkcrm.Objects.Cross_Lead;
using rkcrm.Objects.Cross_Lead.Assigment;
using rkcrm.Objects.Customer;
using rkcrm.Objects.Note;
using rkcrm.Objects.Project;

namespace rkcrm.Reminder_Module
{
    public partial class AssignmentReminders : UserControl
    {

		#region Variables

		private int intAssignmentCount = 0;
		private CrossLead selectedLead;
		private const int LEAD_ID_INDEX = 0;

		#endregion


		#region Properties

		public int AssignmentCount
		{
			get { return intAssignmentCount; }
		}

		public bool PaperPlansAvailable
		{
			get { return (pbxPaperPlans.Image != null); }
			set
			{
				if (value)
				{
					pbxPaperPlans.Image = rkcrm.Properties.Resources.Check_icon_16x16;
					lblTracking.Visible = true;
					lblTrackingID.Visible = true;
				}
				else
				{
					pbxPaperPlans.Image = null;
					lblTracking.Visible = false;
					lblTrackingID.Visible = false;
				}
			}
		}

		public bool DigitalPlansAvailable
		{
			get { return pbxDigitalPlans.Image != null; }
			set
			{
				if (value)
					pbxDigitalPlans.Image = rkcrm.Properties.Resources.Check_icon_16x16;
				else
					pbxDigitalPlans.Image = null;
			}
		}

		public bool HasMaterialsList
		{
			get { return pbxMaterialsList.Image != null; }
			set
			{
				if (value)
					pbxMaterialsList.Image = rkcrm.Properties.Resources.Check_icon_16x16;
				else
					pbxMaterialsList.Image = null;
			}
		}

		public bool ContactCustomer
		{
			get { return pbxContactCustomer.Image != null; }
			set
			{
				if (value)
					pbxContactCustomer.Image = rkcrm.Properties.Resources.Check_icon_16x16;
				else
					pbxContactCustomer.Image = null;
			}
		}

		public string DueDate
		{
			get { return lblDueDate.Text; }
			set { lblDueDate.Text = value; }
		}

		public string Note
		{
			get { return lblNotes.Text.Substring(6); }
			set { lblNotes.Text = "Notes: " + value; }
		}

		public string TrackingID
		{
			get { return lblTrackingID.Text; }
			set { lblTrackingID.Text = value; }
		}

		#endregion
		
		
		#region Methods

		private void Clear()
		{
			PaperPlansAvailable = false;
			DigitalPlansAvailable = false;
			HasMaterialsList = false;
			ContactCustomer = false;
			TrackingID = string.Empty;
			DueDate = string.Empty;
			Note = string.Empty;

			LoadList();
		}

		private void LoadList()
		{
			DataTable oTable;
			ListViewItem theItem;
			ListViewGroup notContacted = new ListViewGroup("Not Contacted", HorizontalAlignment.Left);
			ListViewGroup notCompleted = new ListViewGroup("Contacted, Not Completed", HorizontalAlignment.Left);
			int yellowWeekendDays = 0;
			int redWeekendDays = 0;
			DateTime assigned, overdue, warning;

			lvwCrossLeads.Items.Clear();

			lvwCrossLeads.Groups.Add(notContacted);
			lvwCrossLeads.Groups.Add(notCompleted);

			using (AssignmentController theController = new AssignmentController())
			{
				oTable = theController.GetUserAssignments(thisUser.ID);
			}

			foreach (DataRow oLead in oTable.Rows)
			{
				assigned = Convert.ToDateTime(oLead["Assigned"]);

				theItem = new ListViewItem();

				theItem.Text = oLead["lead_id"].ToString();
				theItem.SubItems.Add(assigned.ToShortDateString());
				theItem.SubItems.Add(oLead["project"].ToString());
				theItem.SubItems.Add(oLead["customer"].ToString());
				theItem.SubItems.Add(oLead["sender"].ToString());
				
				if (Convert.ToInt32(oLead["group"]) == 1)
				{
					notContacted.Items.Add(theItem);

					switch (assigned.DayOfWeek)
					{
						case  DayOfWeek.Thursday:
							yellowWeekendDays = 0;
							redWeekendDays = 2;
							break;
						case DayOfWeek.Friday:
							yellowWeekendDays = 2;
							redWeekendDays = 2;
							break;
						case DayOfWeek.Saturday:
							yellowWeekendDays = 1;
							redWeekendDays = 1;
							break;
						default:
							yellowWeekendDays = 0;
							redWeekendDays = 0;
							break;
					}

					if (oLead["bid_due"] == DBNull.Value)
					{
						overdue = assigned.AddDays(2 + redWeekendDays);
						warning = assigned.AddDays(1 + yellowWeekendDays);
					}
					else
					{
						overdue = Convert.ToDateTime(oLead["bid_due"]);
						if (overdue < assigned.AddDays(1 + yellowWeekendDays))
							warning = DateTime.Today;
						else
							warning = assigned.AddDays(1 + yellowWeekendDays);
					}
				}
				else
				{
					switch (assigned.DayOfWeek)
					{
						case DayOfWeek.Sunday:
							yellowWeekendDays = 2;
							redWeekendDays = 2;
							break;
						case DayOfWeek.Monday:
							yellowWeekendDays = 2;
							redWeekendDays = 4;
							break;
						case DayOfWeek.Tuesday:
							yellowWeekendDays = 4;
							redWeekendDays = 4;
							break;
						case DayOfWeek.Wednesday:
							yellowWeekendDays = 4;
							redWeekendDays = 4;
							break;
						case DayOfWeek.Thursday:
							yellowWeekendDays = 4;
							redWeekendDays = 4;
							break;
						case DayOfWeek.Friday:
							yellowWeekendDays = 4;
							redWeekendDays = 4;
							break;
						case DayOfWeek.Saturday:
							yellowWeekendDays = 3;
							redWeekendDays = 3;
							break;
						default:
							yellowWeekendDays = 0;
							redWeekendDays = 0;
							break;
					}

					if (oLead["bid_due"] == DBNull.Value)
					{
						overdue = assigned.AddDays(10 + redWeekendDays);
						warning = assigned.AddDays(9 + yellowWeekendDays);
					}
					else
					{
						overdue = Convert.ToDateTime(oLead["bid_due"]);
						warning = overdue.AddDays(-1);
					}
				}

				if (overdue < DateTime.Now)
					theItem.BackColor = Color.IndianRed;
				else if (warning < DateTime.Now)
					theItem.BackColor = Color.Yellow;
				else
					theItem.BackColor = Color.White;

				lvwCrossLeads.Items.Add(theItem);
			}

			intAssignmentCount = lvwCrossLeads.Items.Count;
			tslAssignmentCount.Text = "Cross Lead Assignments: " + AssignmentCount;

			OnCountChanged(new EventArgs());
		}

		private void DisplayData()
		{
			if (selectedLead != null)
			{
				ContactCustomer = selectedLead.CustomerHasDetails;
				DigitalPlansAvailable = selectedLead.IsDigitalAvailable;
				HasMaterialsList = selectedLead.IsListAvailable;
				PaperPlansAvailable = selectedLead.IsPaperAvailable;
				DueDate = selectedLead.BidDue == DateTime.MinValue ? string.Empty : selectedLead.BidDue.ToShortDateString();
				Note = selectedLead.Notes;
				TrackingID = selectedLead.PlanID > 0 ? selectedLead.PlanID.ToString() : string.Empty;
			}
			else
				Clear();
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

		public void RefreshData()
		{
			ListViewItem selectedItem = null;

			if (lvwCrossLeads.SelectedItems.Count > 0)
				selectedItem = lvwCrossLeads.SelectedItems[0];

			Clear();
			LoadList();

			if (selectedItem != null)
				foreach (ListViewItem oItem in lvwCrossLeads.Items)
					if (oItem.Text == selectedItem.Text)
						oItem.Selected = true;
		}

		#endregion


		#region Event Handlers

		private void AssignmentReminders_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		private void btnNewQuote_Click(object sender, EventArgs e)
		{
			if(selectedLead != null)
			{
				Project myProject = selectedLead.GetProject();
				Customer myCustomer = myProject.GetCustomer();
				NavigationScreen myNavigation = GetNavigationScreen();

				myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[1];

				myNavigation.btnCustomer.MyCustomer = myCustomer;
				myNavigation.btnCustomer.MyProject = myProject;

				myNavigation.btnCustomer.PerformClick();

				((rkcrm.Objects.Quote.QuoteScreen)myNavigation.CurrentScreen).MyProject = myProject;
				((rkcrm.Objects.Quote.QuoteScreen)myNavigation.CurrentScreen).MyQuote = new rkcrm.Objects.Quote.Quote();

				((MainForm)myNavigation.Parent).Activate();
			}
		}

		private void btnNewNote_Click(object sender, EventArgs e)
		{
			if (selectedLead != null)
			{
				AddNote oForm = new AddNote();
				Note newNote = new Note();
				newNote.ProjectID = selectedLead.ProjectID;
				oForm.MyNote = newNote;

				oForm.noteControls.cboSalesRep.Enabled = false;
				oForm.noteControls.cboSupport.Enabled = false;
				oForm.noteControls.cboDepartment.Enabled = false;

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					using (NoteController theController = new NoteController())
					{
						oForm.MyNote = theController.InsertNote(oForm.MyNote);
					}

					LoadList();
				}
			}
		}

		private void btnProject_Click(object sender, EventArgs e)
		{
			if (selectedLead != null)
			{
				Project myProject = selectedLead.GetProject();
				Customer myCustomer = myProject.GetCustomer();
				NavigationScreen myNavigation = GetNavigationScreen();

				myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1];

				myNavigation.btnCustomer.MyCustomer = myCustomer;
				myNavigation.btnCustomer.MyProject = myProject;

				myNavigation.btnCustomer.PerformClick();

				((ProjectScreen)myNavigation.CurrentScreen).MyProject = myProject;

				((MainForm)myNavigation.Parent).Activate();
			}
		}

		private void lvwCrossLeads_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
			{
				if (selectedLead != null && Convert.ToInt32(e.Item.SubItems[LEAD_ID_INDEX].Text) != selectedLead.ID)
				{
					selectedLead.Dispose();
					selectedLead = null;
				}

				using (CrossLeadController theController = new CrossLeadController())
				{
					selectedLead = theController.GetCrossLead(Convert.ToInt32(e.Item.SubItems[LEAD_ID_INDEX].Text));
				}

				if (selectedLead != null)
				{
					DisplayData();

					btnNewNote.Enabled = true;
					btnNewQuote.Enabled = true;
					btnProject.Enabled = true;
				}
			}
			else
			{
				btnNewNote.Enabled = false;
				btnNewQuote.Enabled = false;
				btnProject.Enabled = false;
			}
		}

		#endregion


		#region Constructor

		public AssignmentReminders()
		{
			InitializeComponent();

			selectedLead = null;

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
