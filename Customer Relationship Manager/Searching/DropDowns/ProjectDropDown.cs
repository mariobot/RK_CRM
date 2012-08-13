using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Navigation;
using rkcrm.Objects.Note;
using rkcrm.Objects.Project;
using rkcrm.Objects.Project.Department;
using rkcrm.Objects.Project.Lost_Report;
using rkcrm.Objects.Quote;
using rkcrm.Reminder_Module;

namespace rkcrm.Searching.DropDowns
{
	class ProjectDropDown : ToolStripDropDown
	{

		#region Variables

		private ToolStripDropDownButton tdbMenuItems;
		private ToolStripButton tsbEditProject;
		private ToolStripButton tsbAddQuote;
		private ToolStripButton tsbSell;
		private ToolStripButton tsbLose;
		private ToolStripButton tsbReopen;
		private ToolStripSeparator tss_0;
		private ToolStripSeparator tss_1;
		private ToolStripSeparator tss_2;
		private ToolStripMenuItem tsmEditProject;
		private ToolStripSeparator mss_0;
		private ToolStripMenuItem tsmAddNote;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmAddQuote;
		private ToolStripSeparator mss_2;
		private ToolStripMenuItem tsmSell;
		private ToolStripMenuItem tsmLose;
		private ToolStripMenuItem tsmReopen;
		private ToolStripSeparator mss_3;
		private ToolStripMenuItem tsmCrossLead;
		private ToolStripButton tsbAddNote;
		private ToolStripMenuItem tsmCustomer;
		private ToolStripButton tsbCrossLead;

		private ListView theReferencedList;
		private int ProjectIndex;
		private int CustomerIndex;
		private ToolStripSeparator mss_4;
		private ToolStripMenuItem tsmProperties;
		private ToolStripSeparator tss_3;
		private ToolStripButton tsbProperties;
		private const int OUTSTANDING = 1;

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectDropDown));
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tdbMenuItems = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmCustomer = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmEditProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmAddNote = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmAddQuote = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmSell = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmLose = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmReopen = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmCrossLead = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbEditProject = new System.Windows.Forms.ToolStripButton();
			this.tsbAddQuote = new System.Windows.Forms.ToolStripButton();
			this.tsbAddNote = new System.Windows.Forms.ToolStripButton();
			this.tsbSell = new System.Windows.Forms.ToolStripButton();
			this.tsbLose = new System.Windows.Forms.ToolStripButton();
			this.tsbReopen = new System.Windows.Forms.ToolStripButton();
			this.tsbCrossLead = new System.Windows.Forms.ToolStripButton();
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
			// tss_2
			// 
			this.tss_2.Name = "tss_2";
			this.tss_2.Size = new System.Drawing.Size(6, 23);
			// 
			// tdbMenuItems
			// 
			this.tdbMenuItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tdbMenuItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCustomer,
            this.mss_0,
            this.tsmEditProject,
            this.mss_1,
            this.tsmAddNote,
            this.tsmAddQuote,
            this.mss_2,
            this.tsmSell,
            this.tsmLose,
            this.tsmReopen,
            this.mss_3,
            this.tsmCrossLead,
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
			this.tsmCustomer.Size = new System.Drawing.Size(171, 22);
			this.tsmCustomer.Text = "Customer";
			// 
			// mss_0
			// 
			this.mss_0.Name = "mss_0";
			this.mss_0.Size = new System.Drawing.Size(168, 6);
			// 
			// tsmEditProject
			// 
			this.tsmEditProject.Image = global::rkcrm.Properties.Resources.Edit_Project_28x28;
			this.tsmEditProject.Name = "tsmEditProject";
			this.tsmEditProject.Size = new System.Drawing.Size(171, 22);
			this.tsmEditProject.Text = "Edit Project";
			this.tsmEditProject.Click += new System.EventHandler(this.EditProject_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(168, 6);
			// 
			// tsmAddNote
			// 
			this.tsmAddNote.Image = global::rkcrm.Properties.Resources.New_Note_Icon;
			this.tsmAddNote.Name = "tsmAddNote";
			this.tsmAddNote.Size = new System.Drawing.Size(171, 22);
			this.tsmAddNote.Text = "Add Note";
			this.tsmAddNote.Click += new System.EventHandler(this.AddNote_Click);
			// 
			// tsmAddQuote
			// 
			this.tsmAddQuote.Image = global::rkcrm.Properties.Resources.New_Quote_icon;
			this.tsmAddQuote.Name = "tsmAddQuote";
			this.tsmAddQuote.Size = new System.Drawing.Size(171, 22);
			this.tsmAddQuote.Text = "Add Quote";
			this.tsmAddQuote.Click += new System.EventHandler(this.AddQuote_Click);
			// 
			// mss_2
			// 
			this.mss_2.Name = "mss_2";
			this.mss_2.Size = new System.Drawing.Size(168, 6);
			// 
			// tsmSell
			// 
			this.tsmSell.Image = global::rkcrm.Properties.Resources.Sold_Icon;
			this.tsmSell.Name = "tsmSell";
			this.tsmSell.Size = new System.Drawing.Size(171, 22);
			this.tsmSell.Text = "Sell Project";
			this.tsmSell.Click += new System.EventHandler(this.Sell_Click);
			// 
			// tsmLose
			// 
			this.tsmLose.Image = global::rkcrm.Properties.Resources.Lost_Icon;
			this.tsmLose.Name = "tsmLose";
			this.tsmLose.Size = new System.Drawing.Size(171, 22);
			this.tsmLose.Text = "Lose Project";
			this.tsmLose.Click += new System.EventHandler(this.Lose_Click);
			// 
			// tsmReopen
			// 
			this.tsmReopen.Image = global::rkcrm.Properties.Resources.Reopen28x28;
			this.tsmReopen.Name = "tsmReopen";
			this.tsmReopen.Size = new System.Drawing.Size(171, 22);
			this.tsmReopen.Text = "Reopen Project";
			this.tsmReopen.Click += new System.EventHandler(this.Reopen_Click);
			// 
			// mss_3
			// 
			this.mss_3.Name = "mss_3";
			this.mss_3.Size = new System.Drawing.Size(168, 6);
			// 
			// tsmCrossLead
			// 
			this.tsmCrossLead.Image = global::rkcrm.Properties.Resources.Notify_Icon;
			this.tsmCrossLead.Name = "tsmCrossLead";
			this.tsmCrossLead.Size = new System.Drawing.Size(171, 22);
			this.tsmCrossLead.Text = "Cross Lead Project";
			this.tsmCrossLead.Click += new System.EventHandler(this.CrossLead_Click);
			// 
			// mss_4
			// 
			this.mss_4.Name = "mss_4";
			this.mss_4.Size = new System.Drawing.Size(168, 6);
			// 
			// tsmProperties
			// 
			this.tsmProperties.Image = global::rkcrm.Properties.Resources.Properties_28x28;
			this.tsmProperties.Name = "tsmProperties";
			this.tsmProperties.Size = new System.Drawing.Size(171, 22);
			this.tsmProperties.Text = "Properties";
			this.tsmProperties.Click += new System.EventHandler(this.Properties_Click);
			// 
			// tsbEditProject
			// 
			this.tsbEditProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbEditProject.Image = global::rkcrm.Properties.Resources.Edit_Project_28x28;
			this.tsbEditProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEditProject.Name = "tsbEditProject";
			this.tsbEditProject.Size = new System.Drawing.Size(23, 20);
			this.tsbEditProject.Text = "Edit Project";
			this.tsbEditProject.Click += new System.EventHandler(this.EditProject_Click);
			// 
			// tsbAddQuote
			// 
			this.tsbAddQuote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddQuote.Image = global::rkcrm.Properties.Resources.New_Quote_icon;
			this.tsbAddQuote.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddQuote.Name = "tsbAddQuote";
			this.tsbAddQuote.Size = new System.Drawing.Size(23, 20);
			this.tsbAddQuote.Text = "Add Quote";
			this.tsbAddQuote.Click += new System.EventHandler(this.AddQuote_Click);
			// 
			// tsbAddNote
			// 
			this.tsbAddNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddNote.Image = global::rkcrm.Properties.Resources.New_Note_Icon;
			this.tsbAddNote.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddNote.Name = "tsbAddNote";
			this.tsbAddNote.Size = new System.Drawing.Size(23, 20);
			this.tsbAddNote.Text = "Add Note";
			this.tsbAddNote.Click += new System.EventHandler(this.AddNote_Click);
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
			// tsbCrossLead
			// 
			this.tsbCrossLead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCrossLead.Image = global::rkcrm.Properties.Resources.Notify_Icon;
			this.tsbCrossLead.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCrossLead.Name = "tsbCrossLead";
			this.tsbCrossLead.Size = new System.Drawing.Size(23, 20);
			this.tsbCrossLead.Text = "Cross Lead Project";
			this.tsbCrossLead.Click += new System.EventHandler(this.CrossLead_Click);
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
			// ProjectDropDown
			// 
			this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tdbMenuItems,
            this.tsbEditProject,
            this.tss_0,
            this.tsbAddNote,
            this.tsbAddQuote,
            this.tss_1,
            this.tsbSell,
            this.tsbLose,
            this.tsbReopen,
            this.tss_2,
            this.tsbCrossLead,
            this.tss_3,
            this.tsbProperties});
			this.Size = new System.Drawing.Size(31, 303);
			this.ResumeLayout(false);

		}

		private void InitializeOtherDropDowns()
		{
			if (CustomerIndex > -1)
			{
				//Add customer options to this drop down
				using (CustomerDropDown customerItems = new CustomerDropDown(theReferencedList, CustomerIndex))
				{
					ToolStripDropDownButton menuItems = (ToolStripDropDownButton)customerItems.Items["tdbMenuItems"];

					while (menuItems.DropDownItems.Count > 0)
						tsmCustomer.DropDownItems.Add(menuItems.DropDownItems[0]);
				}

			}
			else
			{
				tsmCustomer.Visible = false;
				mss_0.Visible = false;
			}
		}

		private void Disable()
		{
			tsbAddNote.Enabled = false;
			tsbAddQuote.Enabled = false;
			tsbCrossLead.Enabled = false;
			tsbEditProject.Enabled = false;
			tsbLose.Enabled = false;
			tsbReopen.Enabled = false;
			tsbSell.Enabled = false;
			tsbProperties.Enabled = false;
			tsmAddNote.Enabled = false;
			tsmAddQuote.Enabled = false;
			tsmCrossLead.Enabled = false;
			tsmEditProject.Enabled = false;
			tsmLose.Enabled = false;
			tsmReopen.Enabled = false;
			tsmSell.Enabled = false;
			tsmProperties.Enabled = false;
		}

		private void Enable(int ProjectID)
		{
			tsbAddNote.Enabled = true;
			tsbAddQuote.Enabled = true;
			tsbCrossLead.Enabled = true;
			tsbEditProject.Enabled = true;
			tsbProperties.Enabled = true;
			tsmAddNote.Enabled = true;
			tsmAddQuote.Enabled = true;
			tsmCrossLead.Enabled = true;
			tsmEditProject.Enabled = true;
			tsmProperties.Enabled = true;


			tsbLose.Enabled = false;
			tsbReopen.Enabled = false;
			tsbSell.Enabled = false;
			tsmLose.Enabled = false;
			tsmReopen.Enabled = false;
			tsmSell.Enabled = false;

			using (ProjectController theController = new ProjectController())
			{
				foreach (DataRow oRow in theController.GetStatuses(ProjectID).Rows)
				{
					if (Convert.ToInt32(oRow["status_id"]) == OUTSTANDING)
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

		}

		private void ValidateSecurityAccess()
		{
			//this.Items[0] = tdbMenuItems
			//this.Items[1] = tsbEditProject
			//this.Items[2] = tss_0
			//this.Items[3] = tsbAddNote
			//this.Items[4] = tsbAddQuote
			//this.Items[5] = tss_1
			//this.Items[6] = tsbSell
			//this.Items[7] = tsbLose
			//this.Items[8] = tsbReopen
			//this.Items[9] = tss_2
			//this.Items[10] = tsbCrossLead
			//this.Items[11] = tss_2
			//this.Items[12] = tsbProperties

			//string text = string.Empty;
			//foreach (ToolStripItem c in this.Items)
			//    text += "this.Items[" + this.Items.IndexOf(c) + "] = " + c.Name + "\r\n";
			//MessageBox.Show(text);

			// accessCode = 8076 (0b1111110001100) Excludes tsbSell, tsbLose and tsbReopen
			// accessCode = 8172 (0b1111111101100) Excludes tsbReopen
			// accessCode = 8191 (0b1111111111111) Access to all buttons

			int index = 0;
			int accessCode = 8191;
			char[] charArray = Convert.ToString(accessCode, 2).PadRight(this.Items.Count, '0').ToCharArray();

			foreach (ToolStripItem oItem in this.Items)
			{
				if (oItem.Name == "tss_1")
					oItem.Visible = (charArray[index + 1] == '1' || charArray[index + 2] == '1' || charArray[index + 3] == '1');
				else
					oItem.Visible = charArray[index] == '0' ? false : true;

				index++;
			}

			//this.Items[0] = tsmCustomer
			//this.Items[1] = mss_0
			//this.Items[2] = tsmEditProject
			//this.Items[3] = mss_1
			//this.Items[4] = tsmAddNote
			//this.Items[5] = tsmAddQuote
			//this.Items[6] = mss_2
			//this.Items[7] = tsmSell
			//this.Items[8] = tsmLose
			//this.Items[9] = tsmReopen
			//this.Items[10] = mss_3
			//this.Items[11] = tsmCrossLead
			//this.Items[12] = tss_2
			//this.Items[13] = tsbProperties

			// accessCode = 16268 (0b11111110001100) Excludes tsbSell, tsbLose and tsbReopen
			// accessCode = 16364 (0b11111111101100) Excludes tsbReopen
			// accessCode = 16383 (0b11111111111111) Access to all buttons

			ToolStripDropDownButton menuItems = (ToolStripDropDownButton)this.Items[0];

			index = 0;
			accessCode = 16383;
			charArray = Convert.ToString(accessCode, 2).PadRight(this.Items.Count, '0').ToCharArray();

			foreach (ToolStripItem oItem in menuItems.DropDownItems)
			{
				if (oItem.Name == "mss_2")
					oItem.Visible = (charArray[index + 1] == '1' || charArray[index + 2] == '1' || charArray[index + 3] == '1');
				else
					oItem.Visible = charArray[index] == '0' ? false : true;
				
				index++;

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

		private bool IsNoteNeeded(int ProjectID, int DepartmentID)
		{
			int noteCount;

			using (NoteController theController = new NoteController())
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
				if (e.Item.SubItems[ProjectIndex].Text != string.Empty)
					Enable(Convert.ToInt32(e.Item.SubItems[ProjectIndex].Text));
				else
					Disable();
			else
				Disable();
		}

		private void Generic_Click(object sender, EventArgs e)
		{
			try
			{
				throw new NotImplementedException();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void EditProject_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			Project theProject;
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1];

			using (ProjectController theController = new ProjectController())
			{
				theProject = theController.GetProject(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text));
				myNavigation.btnCustomer.MyCustomer = theProject.GetCustomer();
			}
			myNavigation.btnCustomer.PerformClick();

			((ProjectScreen)myNavigation.CurrentScreen).MyProject = theProject;
		}

		private void AddNote_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			Project theProject;
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[0];

			using (ProjectController theController = new ProjectController())
			{
				//The customer must be loaded before the project as the MyProject property of the btnCustomer object is clear when the customer property is updated
				theProject = theController.GetProject(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text));
				myNavigation.btnCustomer.MyCustomer = theProject.GetCustomer();
				myNavigation.btnCustomer.MyProject = theProject;
			}
			myNavigation.btnCustomer.PerformClick();

			((NoteScreen)myNavigation.CurrentScreen).MyProject = theProject;
			((NoteScreen)myNavigation.CurrentScreen).MyNote = new Note();
		}

		private void CrossLead_Click(object sender, EventArgs e)
		{
			SendCrossLead oForm = new SendCrossLead();
			using (ProjectController theController = new ProjectController())
			{
				oForm.crossLeadControls.MyProject = theController.GetProject(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text));
			}

			oForm.ShowDialog();
		}

		private void AddQuote_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			Project theProject;
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1].Nodes[1];

			using (ProjectController theController = new ProjectController())
			{
				//The customer must be loaded before the project as the MyProject property of the btnCustomer object is clear when the customer property is updated
				theProject = theController.GetProject(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text));
				myNavigation.btnCustomer.MyCustomer = theProject.GetCustomer();
				myNavigation.btnCustomer.MyProject = theProject;
			}
			myNavigation.btnCustomer.PerformClick();

			((QuoteScreen)myNavigation.CurrentScreen).MyProject = theProject;
			((QuoteScreen)myNavigation.CurrentScreen).MyQuote = new Quote();
		}

		private void Lose_Click(object sender, EventArgs e)
		{
			int ProjectID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text);

			LostProjectForm oForm = new LostProjectForm(ProjectID);
			oForm.ShowDialog();

			if (oForm.DialogResult == DialogResult.OK)
			{
				using (DepartmentController theController = new DepartmentController())
				{
					theController.UpdateStatus(ProjectID, oForm.SelectedDepartmentID, Project.ProjectStatus.Lost);
				}

				if (MessageBox.Show("Would you like to follow up with all remaining notes?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					using (NoteController theNoteCrontroller = new NoteController())
					{
						theNoteCrontroller.FollowUpOnAll(ProjectID, oForm.SelectedDepartmentID);
					}
					RefreshReminders();
				}

				Enable(ProjectID);
			}

		}

		private void Reopen_Click(object sender, EventArgs e)
		{
			int ProjectID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text);

			Administration.Department.DepartmentSelect oForm = new rkcrm.Administration.Department.DepartmentSelect();

			using (DepartmentController theController = new DepartmentController())
			{
				Department theProjectDepartment;

				oForm.DataSource = theController.GetSoldLostDepartments(ProjectID);
				oForm.DisplayMember = "name";
				oForm.ValueMember = "department_id";

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					foreach (object Department in oForm.SelectedItems)
					{
						theProjectDepartment = theController.GetDepartmentWithLastestScope(ProjectID, Convert.ToInt32(((DataRowView)Department)["department_id"]));

						if (theProjectDepartment.Status == Project.ProjectStatus.Sold)
							theController.ClearSoldMarkers(theProjectDepartment);
						else
							theController.DeleteLostProjectReports(theProjectDepartment);

						theController.UpdateStatus(theProjectDepartment, Project.ProjectStatus.Outstanding);

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
								Note newNote = new Note();
								newNote.ProjectID = theProjectDepartment.ProjectID;
								newNote.DepartmentID = theProjectDepartment.DepartmentID;
								newNote.ContactID = latestQuote.ContactID;
								newNote.MethodID = latestQuote.MethodID;
								newNote.NextFollowUp = DateTime.Today;
								newNote.PurposeID = 5; //Follow up on Quotes
								newNote.SalesRepID = latestQuote.SalesRepID;
								newNote.SalesSupportID = latestQuote.SalesSupportID;

								using (NoteController theNoteController = new NoteController())
								{
									newNote = theNoteController.InsertNote(newNote);
								}

								if (newNote.ID > 0)
									RefreshReminders();
							}
						}
					}

					Enable(ProjectID);
				}
			}
		}

		private void Sell_Click(object sender, EventArgs e)
		{
			int ProjectID = Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text);
			
			QuoteSelect oForm = new QuoteSelect();

			using (DepartmentController theController = new DepartmentController())
			{
				oForm.DataSource = theController.GetOutstandingQuotes(ProjectID);

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					theController.UpdateStatus(ProjectID, oForm.SelectedDepartmentID, Project.ProjectStatus.Sold);

					using (QuoteController otherController = new QuoteController())
					{
						otherController.MarkAsSold(oForm.SelectedQuoteID);
					}

					if (MessageBox.Show("Would you like to follow up with all remaining notes?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						using (NoteController theNoteCrontroller = new NoteController())
						{
							theNoteCrontroller.FollowUpOnAll(ProjectID, oForm.SelectedDepartmentID);
						}
						RefreshReminders();
					}

					Enable(ProjectID);
				}
			}
		}

		private void Properties_Click(object sender, EventArgs e)
		{
			Project theProject = null;
			Objects.PropertiesWindow oForm = null;

			if (!string.IsNullOrEmpty(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text))
			{
				using (ProjectController theController = new ProjectController())
				{
					theProject = theController.GetProject(Convert.ToInt32(theReferencedList.SelectedItems[0].SubItems[ProjectIndex].Text));
				}

				if (theProject != null)
				{
					oForm = new rkcrm.Objects.PropertiesWindow();
					oForm.SelectedObject = theProject;
					oForm.Text = "Project Properties";
					oForm.Show();
				}
			}
		}

		#endregion


		#region Constructor

		public ProjectDropDown(ListView ReferencedListView, int ProjectIDIndex, int CustomerIDIndex)
			: base()
		{
			theReferencedList = ReferencedListView;
			theReferencedList.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(theReferencedList_ItemSelectionChanged);
			ProjectIndex = ProjectIDIndex;
			CustomerIndex = CustomerIDIndex;

			InitializeComponent();
			InitializeOtherDropDowns();

			Disable();

			ValidateSecurityAccess();
		}

		#endregion

	}
}
