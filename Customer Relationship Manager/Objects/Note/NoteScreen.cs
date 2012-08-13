using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Navigation;

namespace rkcrm.Objects.Note
{
	class NoteScreen : ObjectScreenBase
	{

		#region Variables

		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton tsbSave;
		private System.Windows.Forms.ToolStripButton tsbSaveClose;
		private System.Windows.Forms.ToolStripButton tsbSaveNew;
		private System.Windows.Forms.ToolStripSeparator tss_0;
		private System.Windows.Forms.ToolStripButton tsbAddNote;
		private System.Windows.Forms.ToolStripSeparator tss_1;
		private System.Windows.Forms.ToolStripButton tsbCancel;
		private System.Windows.Forms.ToolStripSeparator tss_2;
		private System.Windows.Forms.ToolStripButton tsbDelete;
		private System.Windows.Forms.ToolStripButton tsbRestore;
		private System.Windows.Forms.ColumnHeader chID;
		private System.Windows.Forms.ColumnHeader chDepartment;
		private System.Windows.Forms.ColumnHeader chNextFollowUp;
		private System.Windows.Forms.ColumnHeader chCompleted;
		private System.Windows.Forms.ColumnHeader chPurpose;
		private System.Windows.Forms.ColumnHeader chContact;
		private System.Windows.Forms.ColumnHeader chSalesRep;
		private System.Windows.Forms.ColumnHeader chMethod;
		private NoteBoundary noteControls;
		private ToolStripButton tsbFollowUp;
		private ToolStripSeparator tss_3;

		private Note FollowUpCache;
		private ToolStripMenuItem tsmFollowUp;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmDelete;
		private ToolStripMenuItem tsmRestore;
		private ToolStripSeparator mss_2;
		private ToolStripMenuItem tsmCancel;
		private const int FINAL_NOTE = 11;

		#endregion


		#region Properties

		public Project.Project MyProject
		{
			get 
			{
				NavigationScreen navigation = GetNavigationScreen();
				return navigation.btnCustomer.MyProject; 
			}
			set
			{
				NavigationScreen navigation = GetNavigationScreen();
				
				if (navigation.btnCustomer.MyProject != value)
					MyNote = new Note();

				navigation.btnCustomer.MyProject = value;

				if (value != null)
				{
					LoadList();
					this.ListTitle = "Note List - " + value.GetCustomer().Name + " - " + value.Name;
				}
				else
					this.ListTitle = "Note List";
			}
		}

		public Note MyNote
		{
			get { return noteControls.MyNote; }
			set
			{
				if (value != null && value.ProjectID != MyProject.ID)
					value.ProjectID = MyProject.ID;

				noteControls.MyNote = value;
			}
		}

		public override bool IsDirty
		{
			get
			{
				return noteControls.IsDirty;
			}
		}

		#endregion		


		#region Methods

		private void InitializeComponent()
		{
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.tsbSaveClose = new System.Windows.Forms.ToolStripButton();
			this.tsbSaveNew = new System.Windows.Forms.ToolStripButton();
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbAddNote = new System.Windows.Forms.ToolStripButton();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCancel = new System.Windows.Forms.ToolStripButton();
			this.tss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.tsbRestore = new System.Windows.Forms.ToolStripButton();
			this.tss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbFollowUp = new System.Windows.Forms.ToolStripButton();
			this.noteControls = new rkcrm.Objects.Note.NoteBoundary();
			this.chID = new System.Windows.Forms.ColumnHeader();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chNextFollowUp = new System.Windows.Forms.ColumnHeader();
			this.chCompleted = new System.Windows.Forms.ColumnHeader();
			this.chPurpose = new System.Windows.Forms.ColumnHeader();
			this.chContact = new System.Windows.Forms.ColumnHeader();
			this.chSalesRep = new System.Windows.Forms.ColumnHeader();
			this.chMethod = new System.Windows.Forms.ColumnHeader();
			this.tsmFollowUp = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmCancel = new System.Windows.Forms.ToolStripMenuItem();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chDepartment,
            this.chNextFollowUp,
            this.chCompleted,
            this.chPurpose,
            this.chContact,
            this.chSalesRep,
            this.chMethod});
			this.lvwList.Size = new System.Drawing.Size(600, 194);
			this.lvwList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwList_ItemSelectionChanged);
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.noteControls);
			this.scMain.Panel1.Controls.Add(this.tsMain);
			this.scMain.SplitterDistance = 272;
			// 
			// tsMain
			// 
			this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbSaveClose,
            this.tsbSaveNew,
            this.tss_0,
            this.tsbAddNote,
            this.tss_1,
            this.tsbCancel,
            this.tss_2,
            this.tsbDelete,
            this.tsbRestore,
            this.tss_3,
            this.tsbFollowUp});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(600, 35);
			this.tsMain.TabIndex = 1;
			this.tsMain.Text = "toolStrip1";
			// 
			// tsbSave
			// 
			this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSave.Image = global::rkcrm.Properties.Resources.save;
			this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Size = new System.Drawing.Size(32, 32);
			this.tsbSave.Text = "Save";
			this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
			// 
			// tsbSaveClose
			// 
			this.tsbSaveClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSaveClose.Image = global::rkcrm.Properties.Resources.Save_and_Close;
			this.tsbSaveClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSaveClose.Name = "tsbSaveClose";
			this.tsbSaveClose.Size = new System.Drawing.Size(32, 32);
			this.tsbSaveClose.Text = "Save && Close";
			this.tsbSaveClose.ToolTipText = "Save & Close";
			this.tsbSaveClose.Click += new System.EventHandler(this.tsbSaveClose_Click);
			// 
			// tsbSaveNew
			// 
			this.tsbSaveNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSaveNew.Image = global::rkcrm.Properties.Resources.Save_New;
			this.tsbSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSaveNew.Name = "tsbSaveNew";
			this.tsbSaveNew.Size = new System.Drawing.Size(32, 32);
			this.tsbSaveNew.Text = "Save && Add Another Note";
			this.tsbSaveNew.ToolTipText = "Save & Add Another Note";
			this.tsbSaveNew.Visible = false;
			this.tsbSaveNew.Click += new System.EventHandler(this.tsbSaveNew_Click);
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(6, 35);
			this.tss_0.Visible = false;
			// 
			// tsbAddNote
			// 
			this.tsbAddNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddNote.Image = global::rkcrm.Properties.Resources.New_Note_Icon;
			this.tsbAddNote.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddNote.Name = "tsbAddNote";
			this.tsbAddNote.Size = new System.Drawing.Size(32, 32);
			this.tsbAddNote.Text = "Add a Note";
			this.tsbAddNote.Visible = false;
			this.tsbAddNote.Click += new System.EventHandler(this.tsbAddNote_Click);
			// 
			// tss_1
			// 
			this.tss_1.Name = "tss_1";
			this.tss_1.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbCancel
			// 
			this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCancel.Image = global::rkcrm.Properties.Resources.Cancel;
			this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCancel.Name = "tsbCancel";
			this.tsbCancel.Size = new System.Drawing.Size(32, 32);
			this.tsbCancel.Text = "Cancel";
			this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
			// 
			// tss_2
			// 
			this.tss_2.Name = "tss_2";
			this.tss_2.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbDelete
			// 
			this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbDelete.Image = global::rkcrm.Properties.Resources.Delete_icon;
			this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Size = new System.Drawing.Size(32, 32);
			this.tsbDelete.Text = "Delete";
			this.tsbDelete.EnabledChanged += new System.EventHandler(this.tsbDelete_EnabledChanged);
			this.tsbDelete.VisibleChanged += new System.EventHandler(this.tsbDelete_VisibleChanged);
			this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// tsbRestore
			// 
			this.tsbRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRestore.Name = "tsbRestore";
			this.tsbRestore.Size = new System.Drawing.Size(32, 32);
			this.tsbRestore.Text = "Restore";
			this.tsbRestore.EnabledChanged += new System.EventHandler(this.tsbRestore_EnabledChanged);
			this.tsbRestore.VisibleChanged += new System.EventHandler(this.tsbRestore_VisibleChanged);
			this.tsbRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// tss_3
			// 
			this.tss_3.Name = "tss_3";
			this.tss_3.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbFollowUp
			// 
			this.tsbFollowUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbFollowUp.Image = global::rkcrm.Properties.Resources.Follow_Up_Icon;
			this.tsbFollowUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbFollowUp.Name = "tsbFollowUp";
			this.tsbFollowUp.Size = new System.Drawing.Size(32, 32);
			this.tsbFollowUp.Text = "Follow Up on Note";
			this.tsbFollowUp.EnabledChanged += new System.EventHandler(this.tsbFollowUp_EnabledChanged);
			this.tsbFollowUp.VisibleChanged += new System.EventHandler(this.tsbFollowUp_VisibleChanged);
			this.tsbFollowUp.Click += new System.EventHandler(this.btnFollowUp_Click);
			// 
			// noteControls
			// 
			this.noteControls.AutoScroll = true;
			this.noteControls.AutoScrollMinSize = new System.Drawing.Size(0, 210);
			this.noteControls.BackColor = System.Drawing.Color.White;
			this.noteControls.ChangeHistoryVisible = true;
			this.noteControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noteControls.Location = new System.Drawing.Point(0, 35);
			this.noteControls.MyNote = null;
			this.noteControls.Name = "noteControls";
			this.noteControls.Size = new System.Drawing.Size(600, 235);
			this.noteControls.TabIndex = 2;
			this.noteControls.Title = "Search Notes";
			this.noteControls.TitleBarVisible = true;
			this.noteControls.MyNoteChanged += new System.EventHandler<System.EventArgs>(this.noteControls_MyNoteChanged);
			this.noteControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.noteControls_IsDirtyChanged);
			// 
			// chID
			// 
			this.chID.Text = "NoteID";
			this.chID.Width = 0;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 80;
			// 
			// chNextFollowUp
			// 
			this.chNextFollowUp.Text = "Next Follow Up";
			this.chNextFollowUp.Width = 90;
			// 
			// chCompleted
			// 
			this.chCompleted.Text = "Followed Up";
			this.chCompleted.Width = 90;
			// 
			// chPurpose
			// 
			this.chPurpose.Text = "Purpose";
			this.chPurpose.Width = 80;
			// 
			// chContact
			// 
			this.chContact.Text = "Contact";
			this.chContact.Width = 125;
			// 
			// chSalesRep
			// 
			this.chSalesRep.Text = "Sales Rep";
			this.chSalesRep.Width = 88;
			// 
			// chMethod
			// 
			this.chMethod.Text = "Contact Method";
			this.chMethod.Width = 125;
			// 
			// tsmFollowUp
			// 
			this.tsmFollowUp.Image = global::rkcrm.Properties.Resources.Follow_Up_Icon;
			this.tsmFollowUp.Name = "tsmFollowUp";
			this.tsmFollowUp.Size = new System.Drawing.Size(152, 22);
			this.tsmFollowUp.Text = "Follow Up";
			this.tsmFollowUp.Click += new System.EventHandler(this.btnFollowUp_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmDelete
			// 
			this.tsmDelete.Image = global::rkcrm.Properties.Resources.Delete_icon;
			this.tsmDelete.Name = "tsmDelete";
			this.tsmDelete.Size = new System.Drawing.Size(152, 22);
			this.tsmDelete.Text = "Delete Note";
			this.tsmDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// tsmRestore
			// 
			this.tsmRestore.Image = global::rkcrm.Properties.Resources.Restore_Icon;
			this.tsmRestore.Name = "tsmRestore";
			this.tsmRestore.Size = new System.Drawing.Size(152, 22);
			this.tsmRestore.Text = "Restore Note";
			this.tsmRestore.Click += new System.EventHandler(this.tsbRestore_Click);
			// 
			// mss_2
			// 
			this.mss_2.Name = "mss_2";
			this.mss_2.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmCancel
			// 
			this.tsmCancel.Image = global::rkcrm.Properties.Resources.Cancel;
			this.tsmCancel.Name = "tsmCancel";
			this.tsmCancel.Size = new System.Drawing.Size(152, 22);
			this.tsmCancel.Text = "Cancel";
			this.tsmCancel.Click += new System.EventHandler(this.tsbCancel_Click);
			// 
			// NoteScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ListTitle = "Note List - Project Name";
			this.Name = "NoteScreen";
			this.Controls.SetChildIndex(this.scMain, 0);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel1.PerformLayout();
			this.scMain.Panel2.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);

		}

		private void InitializeActions()
		{
			tsmActions.DropDownItems.AddRange(new ToolStripItem[] {
				this.tsmFollowUp,
				this.mss_1,
				this.tsmDelete,
				this.tsmRestore,
				this.mss_2,
				this.tsmCancel});
		}

		private void LoadList()
		{
			lvwList.Items.Clear();

			if (MyProject != null)
			{
				using (NoteController theController = new NoteController())
				{
					ListViewItem newItem;

					foreach (DataRow oRow in theController.GetNotes(MyProject.ID, (thisUser.Role.ID == 1)).Rows)
					{
						newItem = new ListViewItem();
						newItem.Text = oRow["note_id"].ToString();
						newItem.SubItems.Add(oRow["department"].ToString());
						newItem.SubItems.Add((oRow["next_follow_up"] != DBNull.Value ? Convert.ToDateTime(oRow["next_follow_up"]).ToShortDateString() : string.Empty));
						newItem.SubItems.Add((oRow["completed"] != DBNull.Value ? Convert.ToDateTime(oRow["completed"]).ToShortDateString() : string.Empty));
						newItem.SubItems.Add(oRow["purpose"].ToString());
						newItem.SubItems.Add(oRow["contact"].ToString());
						newItem.SubItems.Add(oRow["sales_rep"].ToString());
						newItem.SubItems.Add(oRow["method"].ToString());

						if (Convert.ToBoolean(oRow["is_archived"].ToString()))
							newItem.BackColor = System.Drawing.Color.LightSteelBlue;

						lvwList.Items.Add(newItem);
					}
				}
			}
		}

		private void SetAddingMode()
		{
			tsbAddNote.Enabled = false;
			tsbFollowUp.Enabled = false;
			tsbDelete.Enabled = false;
			tsbRestore.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;

			tsbDelete.Visible = true;
			tsbRestore.Visible = false;

			Clear();

			IsDisposable = true;

			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			if (lvwList.SelectedItems.Count > 0)
				lvwList.SelectedItems[0].Selected = false;

			LoadList();

			if (FollowUpCache != null)
			{
				FollowUpCache.Dispose();
				FollowUpCache = null;
			}
		}

		private void SetEditingMode()
		{
			//The MyNote property of the NoteBoundary should already be set
			bool IsCompleted = (noteControls.MyNote.Completed != DateTime.MinValue);
			bool IsFinalNote = (MyNote.PurposeID == FINAL_NOTE);
			bool IsProjectArchived = MyProject.IsArchived;

			tsbAddNote.Enabled = !IsProjectArchived;
			tsbFollowUp.Enabled = !(IsCompleted || MyNote.IsArchived || IsFinalNote || IsProjectArchived);
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;
			tsbDelete.Enabled = !(IsCompleted || MyNote.IsArchived || IsProjectArchived);
			tsbRestore.Enabled = !(IsCompleted || !MyNote.IsArchived || IsProjectArchived);

			tsbDelete.Visible = !(noteControls.MyNote.IsArchived);
			tsbRestore.Visible = noteControls.MyNote.IsArchived;

			Clear();

			IsDisposable = false;

			if (FollowUpCache != null)
			{
				FollowUpCache.Dispose();
				FollowUpCache = null;
			}

			SelectTheSelected();
		}

		private void SetSearchingMode()
		{
			tsbAddNote.Enabled = true;
			tsbFollowUp.Enabled = false;
			tsbDelete.Enabled = false;
			tsbRestore.Enabled = false;
			tsbSave.Enabled = false;
			tsbSaveClose.Enabled = false;
			tsbSaveNew.Enabled = false;

			tsbDelete.Visible = true;
			tsbRestore.Visible = false;

			Clear();

			lvwList.ListViewItemSorter = null;
			lvwList.Sorting = SortOrder.None;
			if (lvwList.SelectedItems.Count > 0)
				lvwList.SelectedItems[0].Selected = false;

			LoadList();

			if (FollowUpCache != null)
			{
				FollowUpCache.Dispose();
				FollowUpCache = null;
			}
		}

		public override bool Save()
		{
			if (noteControls.CommitChanges())
			{
				using (NoteController theController = new NoteController())
				{
					if (noteControls.MyNote.ID > 0)
						return theController.UpdateNote(noteControls.MyNote);
					else
					{
						Note temp = FollowUpCache;

						MyNote = theController.InsertNote(noteControls.MyNote);

						if (MyNote.ID > 0 && temp != null)
						{
							temp.Completed = DateTime.Today;
							theController.UpdateNote(temp);

							RefreshReminders();
						}

						return MyNote.ID > 0;
					}
				}
			}
			else
				return false;
		}

		private bool IsNoteNeeded()
		{
			int noteCount;
			Project.Project.ProjectStatus status;

			using (NoteController theController = new NoteController())
			{
				noteCount = theController.GetOpenNoteCount(MyNote.ProjectID, Convert.ToInt32(noteControls.cboDepartment.SelectedValue));
			}

			using (Project.ProjectController theController = new rkcrm.Objects.Project.ProjectController())
			{
				status = theController.GetStatus(MyNote.ProjectID, Convert.ToInt32(noteControls.cboDepartment.SelectedValue));
			}

			if (status == Project.Project.ProjectStatus.Outstanding && noteCount < 2)
				return true;
			else
				return false;
		}

		private void FollowUp()
		{
			if (IsNoteNeeded())
			{
				/*
				 * It is necessary to store the current note into a temporary variable because each mode change
				 * clears any note in the FollowUpCache variable. The adding mode immediately following the 
				 * Follow Up button press is an extension of the Follow up process. The current Follow up process 
				 * ends when the screen transitions from this adding mode.
				 */

				if (Save())
				{
					MessageBox.Show("An outstanding project must have at least one note. Please enter a new note.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
					
					//store the note temporarily
					Note temp = MyNote;
					//Set screen to adding mode
					MyNote = new Note();
					//Put the note to be marked as followed up in storage to be dealt with later
					FollowUpCache = temp;

					noteControls.cboContact.SelectedValue = FollowUpCache.ContactID;
					noteControls.cboDepartment.SelectedValue = FollowUpCache.DepartmentID;
					noteControls.cboMethod.SelectedValue = FollowUpCache.MethodID;
					noteControls.cboPurpose.SelectedValue = FollowUpCache.PurposeID;
					noteControls.cboSalesRep.SelectedValue = FollowUpCache.SalesRepID;
					noteControls.cboSupport.SelectedValue = FollowUpCache.SalesSupportID;
				}
			}
			else
			{
				noteControls.MyNote.Completed = DateTime.Today;

				if (Save())
					MyNote = MyNote;
			}
		}

		private bool DeleteNote()
		{
			int noteCount;
			Project.Project.ProjectStatus status;

			using (NoteController theController = new NoteController())
			{
				noteCount = theController.GetOpenNoteCount(MyNote.ProjectID, Convert.ToInt32(noteControls.cboDepartment.SelectedValue));
			}

			using (Project.ProjectController theController = new rkcrm.Objects.Project.ProjectController())
			{
				status = theController.GetStatus(MyNote.ProjectID, Convert.ToInt32(noteControls.cboDepartment.SelectedValue));
			}

			if (noteCount == 1 && status == rkcrm.Objects.Project.Project.ProjectStatus.Outstanding)
			{
				MessageBox.Show("When the project is outstanding, it requires an active note with a follow up date at all times. Please add another note before deleting this note.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else
			{
				noteControls.MyNote.IsArchived = true;
				return Save();
			}

		}

		public override void RefreshData()
		{
			ListViewItem selectedItem = null;

			if (lvwList.SelectedItems.Count > 0)
				selectedItem = lvwList.SelectedItems[0];

			LoadList();

			if (selectedItem != null)
			{
				foreach (ListViewItem oItem in lvwList.Items)
					if (oItem.Text == selectedItem.Text)
						oItem.Selected = true;
			}

			if (MyNote != null && MyNote.ID > 0)
			{
				using (NoteController theController = new NoteController())
				{
					MyNote = theController.GetNote(MyNote.ID);
				}
			}
		}

		private void SelectTheSelected()
		{
			foreach (ListViewItem oItem in lvwList.Items)
				if (Convert.ToInt32(oItem.Text) == MyNote.ID && !oItem.Selected)
					oItem.Selected = true;
		}

		#endregion


		#region Event Handlers

		private void noteControls_MyNoteChanged(object sender, EventArgs e)
		{
			if (MyNote == null)
				SetSearchingMode();
			else
				if (MyNote.ID > 0)
					SetEditingMode();
				else
					SetAddingMode();
		}

		private void noteControls_IsDirtyChanged(object sender, EventArgs e)
		{
			bool IsProjectArchived = MyProject.IsArchived;
			bool IsCompleted = (noteControls.MyNote.Completed != DateTime.MinValue);

			tsbSave.Enabled = !(IsCompleted || IsProjectArchived) && IsDirty;
			tsbSaveClose.Enabled = !(IsCompleted || IsProjectArchived) && IsDirty;
			tsbSaveNew.Enabled = !(IsCompleted || IsProjectArchived) && IsDirty;
		}

		private void lvwList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected && (MyNote == null || MyNote.ID != Convert.ToInt32(e.Item.Text)))
			{
				using (NoteController theController = new NoteController())
				{
					MyNote = theController.GetNote(Convert.ToInt32(e.Item.Text));
				}
			}

		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyNote = MyNote;

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyProject != null)
						LoadList();

					RefreshReminders();
				}
			}
		}

		private void tsbSaveClose_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyNote = new Note();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyProject != null)
						LoadList();

					RefreshReminders();
				}
			}
			else
				MyNote = new Note();
		}

		private void tsbSaveNew_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyNote = new Note();

					lvwList.ListViewItemSorter = null;
					lvwList.Sorting = SortOrder.None;

					if (MyProject != null)
						LoadList();

					RefreshReminders();
				}
			}
		}

		private void tsbAddNote_Click(object sender, EventArgs e)
		{
			if (IsDirty)
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
						{
							MyNote = new Note();

							RefreshReminders();
						}
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyNote = new Note();
						break;
				}
			else
				MyNote = new Note();
		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
						{
							MyNote = new Note();

							RefreshReminders();
						}
						break;
					case DialogResult.Cancel:
						break;
					default:
						MyNote = new Note();
						break;
				}
			}
			else
				MyNote = new Note();
		}

		private void tsbDelete_Click(object sender, EventArgs e)
		{
			if (IsNoteNeeded())
				MessageBox.Show("An outstanding project must have at least one note. Please add a new note before deleting this one.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			else
			{
				using (NoteController theController = new NoteController())
				{
					MyNote.IsArchived = true;
					if (theController.UpdateNote(MyNote))
					{
						MyNote = new Note();

						RefreshReminders();
					}
				}
			}
		}

		private void tsbRestore_Click(object sender, EventArgs e)
		{
			MyNote.IsArchived = false;
			if (Save())
			{
				// This sets the screen into edit mode
				MyNote = MyNote;
				LoadList();

				RefreshReminders();
			}
		}

		private void btnFollowUp_Click(object sender, EventArgs e)
		{
			FollowUp();

			RefreshReminders();

			MyNote = new Note();
		}

		#endregion


		#region Constructor

		public NoteScreen()
			: base()
		{
			InitializeComponent();
		}

		#endregion


		#region Special Button Handlers

		private void tsbDelete_EnabledChanged(object sender, EventArgs e)
		{
			tsmDelete.Enabled = tsbDelete.Enabled;
		}

		private void tsbDelete_VisibleChanged(object sender, EventArgs e)
		{
			tsmDelete.Visible = tsbDelete.Visible;
		}

		private void tsbRestore_EnabledChanged(object sender, EventArgs e)
		{
			tsmRestore.Enabled = tsbRestore.Enabled;
		}

		private void tsbRestore_VisibleChanged(object sender, EventArgs e)
		{
			tsmRestore.Visible = tsbRestore.Visible;
		}

		private void tsbFollowUp_EnabledChanged(object sender, EventArgs e)
		{
			tsmFollowUp.Enabled = tsbFollowUp.Enabled;
		}

		private void tsbFollowUp_VisibleChanged(object sender, EventArgs e)
		{
			tsmFollowUp.Visible = tsbFollowUp.Visible;
		}

		#endregion


	}
}
