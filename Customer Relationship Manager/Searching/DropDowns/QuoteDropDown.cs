using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Navigation;
using rkcrm.Objects.Customer;
using rkcrm.Objects.Project;
using rkcrm.Objects.Project.Department;
using rkcrm.Objects.Project.Lost_Report;
using rkcrm.Objects.Quote;
using rkcrm.Reminder_Module;

namespace rkcrm.Searching.DropDowns
{
	class QuoteDropDown : ToolStripDropDown
	{

		#region Variables

		private ToolStripDropDownButton tdbMenuItems;
		private ToolStripButton tsbSell;
		private ToolStripButton tsbLose;
		private ToolStripButton tsbReopen;
		private ToolStripSeparator tss_0;
		private ToolStripSeparator mss_0;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmSell;
		private ToolStripMenuItem tsmLose;
		private ToolStripMenuItem tsmReopen;
		private ToolStripButton tsbEditQuote;
		private ToolStripMenuItem tsmCustomer;
		private ToolStripMenuItem tsmProject;
		private ToolStripMenuItem tsmEditQuote;

		private ListView theReferencedList;
		private int intQuoteIDIndex;
		private int intProjectIDIndex;
		private int intCustomerIDIndex;
		private int intDepartmentIDIndex;
		private ToolStripSeparator mss_2;
		private ToolStripMenuItem tsmProperties;
		private ToolStripSeparator tss_1;
		private ToolStripButton tsbProperties;
		private int intStatusIndex;

		#endregion


		#region Mehtods

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuoteDropDown));
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tdbMenuItems = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmCustomer = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmEditQuote = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmSell = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmLose = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmReopen = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbEditQuote = new System.Windows.Forms.ToolStripButton();
			this.tsbSell = new System.Windows.Forms.ToolStripButton();
			this.tsbLose = new System.Windows.Forms.ToolStripButton();
			this.tsbReopen = new System.Windows.Forms.ToolStripButton();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbProperties = new System.Windows.Forms.ToolStripButton();
			this.SuspendLayout();
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(6, 23);
			// 
			// tdbMenuItems
			// 
			this.tdbMenuItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tdbMenuItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCustomer,
            this.tsmProject,
            this.mss_0,
            this.tsmEditQuote,
            this.mss_1,
            this.tsmSell,
            this.tsmLose,
            this.tsmReopen,
            this.mss_2,
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
			this.tsmCustomer.Size = new System.Drawing.Size(154, 22);
			this.tsmCustomer.Text = "Customer";
			// 
			// tsmProject
			// 
			this.tsmProject.Image = global::rkcrm.Properties.Resources.Project_Icon_28x28;
			this.tsmProject.Name = "tsmProject";
			this.tsmProject.Size = new System.Drawing.Size(154, 22);
			this.tsmProject.Text = "Project";
			// 
			// mss_0
			// 
			this.mss_0.Name = "mss_0";
			this.mss_0.Size = new System.Drawing.Size(151, 6);
			// 
			// tsmEditQuote
			// 
			this.tsmEditQuote.Image = global::rkcrm.Properties.Resources.Edit_Quote_28x28;
			this.tsmEditQuote.Name = "tsmEditQuote";
			this.tsmEditQuote.Size = new System.Drawing.Size(154, 22);
			this.tsmEditQuote.Text = "Edit Quote";
			this.tsmEditQuote.Click += new System.EventHandler(this.EditQuote_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(151, 6);
			// 
			// tsmSell
			// 
			this.tsmSell.Image = global::rkcrm.Properties.Resources.Sold_Icon;
			this.tsmSell.Name = "tsmSell";
			this.tsmSell.Size = new System.Drawing.Size(154, 22);
			this.tsmSell.Text = "Sell Project";
			this.tsmSell.Click += new System.EventHandler(this.Sell_Click);
			// 
			// tsmLose
			// 
			this.tsmLose.Image = global::rkcrm.Properties.Resources.Lost_Icon;
			this.tsmLose.Name = "tsmLose";
			this.tsmLose.Size = new System.Drawing.Size(154, 22);
			this.tsmLose.Text = "Lose Project";
			this.tsmLose.Click += new System.EventHandler(this.Lose_Click);
			// 
			// tsmReopen
			// 
			this.tsmReopen.Image = global::rkcrm.Properties.Resources.Reopen28x28;
			this.tsmReopen.Name = "tsmReopen";
			this.tsmReopen.Size = new System.Drawing.Size(154, 22);
			this.tsmReopen.Text = "Reopen Project";
			this.tsmReopen.Click += new System.EventHandler(this.Reopen_Click);
			// 
			// mss_2
			// 
			this.mss_2.Name = "mss_2";
			this.mss_2.Size = new System.Drawing.Size(151, 6);
			// 
			// tsmProperties
			// 
			this.tsmProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsmProperties.Name = "tsmProperties";
			this.tsmProperties.Size = new System.Drawing.Size(154, 22);
			this.tsmProperties.Text = "Properties";
			this.tsmProperties.Click += new System.EventHandler(this.Properties_Click);
			// 
			// tsbEditQuote
			// 
			this.tsbEditQuote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbEditQuote.Image = global::rkcrm.Properties.Resources.Edit_Quote_28x28;
			this.tsbEditQuote.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEditQuote.Name = "tsbEditQuote";
			this.tsbEditQuote.Size = new System.Drawing.Size(23, 20);
			this.tsbEditQuote.Text = "Edit Quote";
			this.tsbEditQuote.Click += new System.EventHandler(this.EditQuote_Click);
			// 
			// tsbSell
			// 
			this.tsbSell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSell.Image = global::rkcrm.Properties.Resources.Sold_Icon;
			this.tsbSell.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSell.Name = "tsbSell";
			this.tsbSell.Size = new System.Drawing.Size(23, 20);
			this.tsbSell.Text = "Sell Project";
			this.tsbSell.Click += new System.EventHandler(this.Sell_Click);
			// 
			// tsbLose
			// 
			this.tsbLose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbLose.Image = global::rkcrm.Properties.Resources.Lost_Icon;
			this.tsbLose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbLose.Name = "tsbLose";
			this.tsbLose.Size = new System.Drawing.Size(23, 20);
			this.tsbLose.Text = "Lose Project";
			this.tsbLose.Click += new System.EventHandler(this.Lose_Click);
			// 
			// tsbReopen
			// 
			this.tsbReopen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbReopen.Image = global::rkcrm.Properties.Resources.Reopen28x28;
			this.tsbReopen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbReopen.Name = "tsbReopen";
			this.tsbReopen.Size = new System.Drawing.Size(23, 20);
			this.tsbReopen.Text = "Reopen Project";
			this.tsbReopen.Click += new System.EventHandler(this.Reopen_Click);
			// 
			// tss_1
			// 
			this.tss_1.Name = "tss_1";
			this.tss_1.Size = new System.Drawing.Size(6, 23);
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
			// QuoteDropDown
			// 
			this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tdbMenuItems,
            this.tsbEditQuote,
            this.tss_0,
            this.tsbSell,
            this.tsbLose,
            this.tsbReopen,
            this.tss_1,
            this.tsbProperties});
			this.Size = new System.Drawing.Size(31, 188);
			this.ResumeLayout(false);

		}

		private void InitializeOtherDropDowns()
		{
			if (intProjectIDIndex > -1)
			{
				//Add the project options to this drop down
				using (ProjectDropDown projectItems = new ProjectDropDown(theReferencedList, intProjectIDIndex, intCustomerIDIndex))
				{
					ToolStripDropDownButton theButton = (ToolStripDropDownButton)projectItems.Items["tdbMenuItems"];

					while (theButton.DropDownItems.Count > 0)
						tsmProject.DropDownItems.Add(theButton.DropDownItems[0]);
				}

			}

			if (intCustomerIDIndex > -1)
			{

				//Add the customer options to this drop down
				using (CustomerDropDown customerItems = new CustomerDropDown(theReferencedList, intCustomerIDIndex))
				{
					ToolStripDropDownButton theButton = (ToolStripDropDownButton)customerItems.Items["tdbMenuItems"];

					while (theButton.DropDownItems.Count > 0)
						tsmCustomer.DropDownItems.Add(theButton.DropDownItems[0]);
				}

			}
		}

		private void Disable()
		{
			tsbEditQuote.Enabled = false;
			tsbLose.Enabled = false;
			tsbReopen.Enabled = false;
			tsbSell.Enabled = false;
			tsbProperties.Enabled = false;
			tsmCustomer.Enabled = false;
			tsmEditQuote.Enabled = false;
			tsmProject.Enabled = false;
			tsmProperties.Enabled = false;
			tsmLose.Enabled = false;
			tsmReopen.Enabled = false;
			tsmSell.Enabled = false;
		}

		private void Enable(int ProjectID, int DepartmentID)
		{
			tsbEditQuote.Enabled = true;
			tsbProperties.Enabled = true;
			tsmCustomer.Enabled = true;
			tsmEditQuote.Enabled = true;
			tsmProject.Enabled = true;
			tsmProperties.Enabled = true;

			tsbLose.Enabled = false;
			tsbReopen.Enabled = false;
			tsbSell.Enabled = false;
			tsmLose.Enabled = false;
			tsmReopen.Enabled = false;
			tsmSell.Enabled = false;

			using (ProjectController theController = new ProjectController())
			{
				Project.ProjectStatus theStatus = theController.GetStatus(ProjectID, DepartmentID);

				if (theStatus == Project.ProjectStatus.Outstanding)
				{
					tsbLose.Enabled = true;
					tsbSell.Enabled = true;
					tsmLose.Enabled = true;
					tsmSell.Enabled = true;
				}
				else
				{
					tsbReopen.Enabled = true;
					tsmReopen.Enabled = true;
				}
			}
		}

		private NavigationScreen GetNavigationScreen()
		{
			Control myNavigation = theReferencedList;

			while (!(myNavigation is Navigation.NavigationScreen) && myNavigation.Parent != null)
				myNavigation = myNavigation.Parent;

			if (myNavigation is NavigationScreen)
				return (NavigationScreen)myNavigation;
			else
				return null;
		}

		private bool IsNoteNeeded(int ProjectID, int DepartmentID)
		{
			int noteCount;

			using (Objects.Note.NoteController theController = new Objects.Note.NoteController())
			{
				noteCount = theController.GetOpenNoteCount(ProjectID, DepartmentID);
			}

			return (noteCount == 0);
		}

		public void RefreshReminders()
		{
			RemindersForm theForm = null;

			foreach (Form oForm in Application.OpenForms)
				if (oForm is RemindersForm)
					theForm = (RemindersForm)oForm;

			if (theForm != null)
				theForm.RefreshData();
		}

		#endregion


		#region Event Handlers

		void theReferencedList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
				if (e.Item.SubItems[intQuoteIDIndex].Text != string.Empty)
					Enable(Convert.ToInt32(e.Item.SubItems[intProjectIDIndex].Text), Convert.ToInt32(e.Item.SubItems[intDepartmentIDIndex].Text));
				else
					Disable();
			else
				Disable();
		}

		private void Lose_Click(object sender, EventArgs e)
		{
			int ProjectID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intProjectIDIndex].Text);
			int DepartmentID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intDepartmentIDIndex].Text);

			LostProjectForm oForm = new LostProjectForm(ProjectID, DepartmentID);

			oForm.ShowDialog();

			if (oForm.DialogResult == DialogResult.OK)
			{
				using (DepartmentController theController = new DepartmentController())
				{
					theController.UpdateStatus(ProjectID, DepartmentID, Project.ProjectStatus.Lost);
				}

				if (MessageBox.Show("Would you like to follow up with all remaining notes?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					using (Objects.Note.NoteController theNoteCrontroller = new Objects.Note.NoteController())
					{
						theNoteCrontroller.FollowUpOnAll(ProjectID, DepartmentID);
					}
					RefreshReminders();
				}

				theReferencedList.SelectedItems[0].SubItems[intStatusIndex].Text = "Lost";
				Enable(ProjectID, DepartmentID);
			}
		}

		private void Reopen_Click(object sender, EventArgs e)
		{
			int ProjectID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intProjectIDIndex].Text);
			int DepartmentID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intDepartmentIDIndex].Text);
			Department theProjectDepartment;

			using (DepartmentController theController = new DepartmentController())
			{
				theProjectDepartment = theController.GetDepartmentWithLastestScope(ProjectID, DepartmentID);

				if (theProjectDepartment.Status == Project.ProjectStatus.Sold)
					theController.ClearSoldMarkers(theProjectDepartment);
				else
					theController.DeleteLostProjectReports(theProjectDepartment);

				theController.UpdateStatus(theProjectDepartment, Project.ProjectStatus.Outstanding);
			}

			// Every outstanding project must have an "oustanding note" so add one that is due today
			if (IsNoteNeeded(theProjectDepartment.ProjectID, theProjectDepartment.DepartmentID))
			{
				// Here we assume that this is a simple reopen which means that at least one quote exists
				Quote latestQuote = null;

				using (QuoteController theQuoteController = new QuoteController())
				{
					latestQuote = theQuoteController.GetLatestQuote(theProjectDepartment.ProjectID, theProjectDepartment.DepartmentID);
				}

				if (latestQuote != null)
				{
					Objects.Note.Note newNote = new Objects.Note.Note();
					newNote.ProjectID = theProjectDepartment.ProjectID;
					newNote.DepartmentID = theProjectDepartment.DepartmentID;
					newNote.ContactID = latestQuote.ContactID;
					newNote.MethodID = latestQuote.MethodID;
					newNote.NextFollowUp = DateTime.Today;
					newNote.PurposeID = 5; //Follow up on Quotes
					newNote.SalesRepID = latestQuote.SalesRepID;
					newNote.SalesSupportID = latestQuote.SalesSupportID;

					using (Objects.Note.NoteController theNoteController = new Objects.Note.NoteController())
					{
						newNote = theNoteController.InsertNote(newNote);
					}

					if (newNote.ID > 0)
						RefreshReminders();
				}
			}

			theReferencedList.SelectedItems[0].SubItems[intStatusIndex].Text = "Outstanding";
			Enable(ProjectID, DepartmentID);
		}

		private void Sell_Click(object sender, EventArgs e)
		{
			int ProjectID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intProjectIDIndex].Text);
			int QuoteID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intQuoteIDIndex].Text);
			int DepartmentID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intDepartmentIDIndex].Text);

			using (QuoteController otherController = new QuoteController())
			{
				otherController.MarkAsSold(QuoteID);
			}

			using (DepartmentController theController = new DepartmentController())
			{
				theController.UpdateStatus(ProjectID, DepartmentID, Project.ProjectStatus.Sold);
			}

			if (MessageBox.Show("Would you like to follow up with all remaining notes?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				using (Objects.Note.NoteController theNoteCrontroller = new Objects.Note.NoteController())
				{
					theNoteCrontroller.FollowUpOnAll(ProjectID, DepartmentID);
				}
				RefreshReminders();
			}

			theReferencedList.SelectedItems[0].SubItems[intStatusIndex].Text = "Sold";
			Enable(ProjectID, DepartmentID);
		}

		private void EditQuote_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[1];

			using (CustomerController theController = new CustomerController())
			{
				myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intCustomerIDIndex].Text));
			}
			using (ProjectController theController = new ProjectController())
			{
				myNavigation.btnCustomer.MyProject = theController.GetProject(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intProjectIDIndex].Text));
			}

			myNavigation.btnCustomer.PerformClick();

			((QuoteScreen)myNavigation.CurrentScreen).MyProject = myNavigation.btnCustomer.MyProject;

			using (QuoteController theController = new QuoteController())
			{
				((QuoteScreen)myNavigation.CurrentScreen).MyQuote = theController.GetQuote(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intQuoteIDIndex].Text));
			}
		}

		private void Properties_Click(object sender, EventArgs e)
		{
			Quote theQuote = null;
			Objects.PropertiesWindow oForm = null;

			if (!string.IsNullOrEmpty(theReferencedList.SelectedItems[0].SubItems[intQuoteIDIndex].Text))
			{
				using (QuoteController theController = new QuoteController())
				{
					theQuote = theController.GetQuote(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[intQuoteIDIndex].Text));
				}

				if (theQuote != null)
				{
					oForm = new rkcrm.Objects.PropertiesWindow();
					oForm.SelectedObject = theQuote;
					oForm.Text = "Quote Properties";
					oForm.Show();
				}
			}
		}

		#endregion


		#region Constructor

		public QuoteDropDown(ListView ReferencedList, int QuoteIDIndex, int CustomerIDIndex, int ProjectIDIndex, int DepartmentIDIndex, int StatusIndex)
			: base()
		{
			theReferencedList = ReferencedList;
			theReferencedList.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(theReferencedList_ItemSelectionChanged);
			intQuoteIDIndex = QuoteIDIndex;
			intProjectIDIndex = ProjectIDIndex;
			intCustomerIDIndex = CustomerIDIndex;
			intDepartmentIDIndex = DepartmentIDIndex;
			intStatusIndex = StatusIndex;

			InitializeComponent();

			InitializeOtherDropDowns();

			Disable();

		}

		#endregion

	}
}
