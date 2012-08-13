using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.Contact_Method;
using rkcrm.Administration.Contact_Purpose;
using rkcrm.Administration.Department;
using rkcrm.Administration.User;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Note
{
	class NoteBoundary : BoundaryBase
	{

		#region Variables

		internal System.Windows.Forms.ComboBox cboSupport;
		internal System.Windows.Forms.Label lblSupport;
		internal System.Windows.Forms.MaskedTextBox mtxtNextFollowUp;
		internal System.Windows.Forms.MaskedTextBox mtxtCompleted;
		internal System.Windows.Forms.ComboBox cboPurpose;
		internal System.Windows.Forms.Label lblPurpose;
		internal System.Windows.Forms.ComboBox cboDepartment;
		internal System.Windows.Forms.Label lblDepartment;
		internal System.Windows.Forms.ComboBox cboSalesRep;
		internal System.Windows.Forms.Label lblNotes;
		internal System.Windows.Forms.TextBox txtNotes;
		internal System.Windows.Forms.Label lblCompleted;
		internal System.Windows.Forms.ComboBox cboContact;
		internal System.Windows.Forms.Label lblNextFollowUp;
		internal System.Windows.Forms.Label lblContact;
		internal System.Windows.Forms.Label lblSalesRep;
		internal System.Windows.Forms.ComboBox cboMethod;
		internal System.Windows.Forms.Label lblMethod;

		private DataTable AvailableSalesReps;
		private DataTable AvailablePurposes;
		private Note clsMyNote;
		private const int FINAL_NOTE = 11;
		private const int FOLLOW_UP_ON_QUOTE = 5;
		private const int OTHER = 9;
		private const int DEACTIVATION = 12;
		private const int ACTIVATION = 13;
		private const int NO_BID = 14;

		#endregion


		#region Properties

		public Note MyNote
		{
			get { return clsMyNote; }
			set 
			{
				if (clsMyNote != value && clsMyNote != null)
					clsMyNote.Dispose();

				clsMyNote = value;

				if (value == null)
					SetSearchingMode();
				else
				{
					LoadContacts();

					if (value.ID > 0)
						SetEditingMode();
					else
						SetAddingMode();
				}

				OnMyNoteChanged(new EventArgs());
			}
		}

		#endregion


		#region Methods

		private new void Clear()
		{
			base.Clear();

			cboContact.SelectedItem = null;
			cboDepartment.SelectedItem = null;
			cboMethod.SelectedItem = null;
			cboPurpose.SelectedItem = null;
			cboSalesRep.SelectedItem = null;
			cboSupport.SelectedItem = null;
			cboContact.Text = string.Empty;
			cboDepartment.Text = string.Empty;
			cboMethod.Text = string.Empty;
			cboPurpose.Text = string.Empty;
			cboSalesRep.Text = string.Empty;
			cboSupport.Text = string.Empty;
			mtxtCompleted.Clear();
			mtxtNextFollowUp.Clear();
			txtNotes.Clear();
		}

		private void InitializeComponent()
		{
			this.cboSupport = new System.Windows.Forms.ComboBox();
			this.lblSupport = new System.Windows.Forms.Label();
			this.mtxtNextFollowUp = new System.Windows.Forms.MaskedTextBox();
			this.mtxtCompleted = new System.Windows.Forms.MaskedTextBox();
			this.cboPurpose = new System.Windows.Forms.ComboBox();
			this.lblPurpose = new System.Windows.Forms.Label();
			this.cboDepartment = new System.Windows.Forms.ComboBox();
			this.lblDepartment = new System.Windows.Forms.Label();
			this.cboSalesRep = new System.Windows.Forms.ComboBox();
			this.lblNotes = new System.Windows.Forms.Label();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.lblCompleted = new System.Windows.Forms.Label();
			this.cboContact = new System.Windows.Forms.ComboBox();
			this.lblNextFollowUp = new System.Windows.Forms.Label();
			this.lblContact = new System.Windows.Forms.Label();
			this.lblSalesRep = new System.Windows.Forms.Label();
			this.cboMethod = new System.Windows.Forms.ComboBox();
			this.lblMethod = new System.Windows.Forms.Label();
			this.pnlControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.cboSupport);
			this.pnlControls.Controls.Add(this.lblSupport);
			this.pnlControls.Controls.Add(this.mtxtNextFollowUp);
			this.pnlControls.Controls.Add(this.mtxtCompleted);
			this.pnlControls.Controls.Add(this.cboPurpose);
			this.pnlControls.Controls.Add(this.lblPurpose);
			this.pnlControls.Controls.Add(this.cboDepartment);
			this.pnlControls.Controls.Add(this.lblDepartment);
			this.pnlControls.Controls.Add(this.cboSalesRep);
			this.pnlControls.Controls.Add(this.lblNotes);
			this.pnlControls.Controls.Add(this.txtNotes);
			this.pnlControls.Controls.Add(this.lblCompleted);
			this.pnlControls.Controls.Add(this.cboContact);
			this.pnlControls.Controls.Add(this.lblNextFollowUp);
			this.pnlControls.Controls.Add(this.lblContact);
			this.pnlControls.Controls.Add(this.lblSalesRep);
			this.pnlControls.Controls.Add(this.cboMethod);
			this.pnlControls.Controls.Add(this.lblMethod);
			// 
			// cboSupport
			// 
			this.cboSupport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboSupport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboSupport.FormattingEnabled = true;
			this.cboSupport.Location = new System.Drawing.Point(17, 28);
			this.cboSupport.Name = "cboSupport";
			this.cboSupport.Size = new System.Drawing.Size(139, 21);
			this.cboSupport.TabIndex = 42;
			this.cboSupport.SelectionChangeCommitted += new System.EventHandler(this.cboSupport_SelectionChangeCommitted);
			this.cboSupport.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblSupport
			// 
			this.lblSupport.AutoSize = true;
			this.lblSupport.Location = new System.Drawing.Point(14, 12);
			this.lblSupport.Name = "lblSupport";
			this.lblSupport.Size = new System.Drawing.Size(77, 13);
			this.lblSupport.TabIndex = 59;
			this.lblSupport.Text = "Sales Support*";
			// 
			// mtxtNextFollowUp
			// 
			this.mtxtNextFollowUp.Enabled = false;
			this.mtxtNextFollowUp.Location = new System.Drawing.Point(452, 76);
			this.mtxtNextFollowUp.Mask = "00/00/00";
			this.mtxtNextFollowUp.Name = "mtxtNextFollowUp";
			this.mtxtNextFollowUp.Size = new System.Drawing.Size(77, 20);
			this.mtxtNextFollowUp.TabIndex = 52;
			this.mtxtNextFollowUp.ValidatingType = typeof(System.DateTime);
			this.mtxtNextFollowUp.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// mtxtCompleted
			// 
			this.mtxtCompleted.Enabled = false;
			this.mtxtCompleted.Location = new System.Drawing.Point(452, 28);
			this.mtxtCompleted.Mask = "00/00/00";
			this.mtxtCompleted.Name = "mtxtCompleted";
			this.mtxtCompleted.Size = new System.Drawing.Size(77, 20);
			this.mtxtCompleted.TabIndex = 46;
			this.mtxtCompleted.ValidatingType = typeof(System.DateTime);
			this.mtxtCompleted.Visible = false;
			// 
			// cboPurpose
			// 
			this.cboPurpose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboPurpose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboPurpose.FormattingEnabled = true;
			this.cboPurpose.Location = new System.Drawing.Point(162, 76);
			this.cboPurpose.Name = "cboPurpose";
			this.cboPurpose.Size = new System.Drawing.Size(139, 21);
			this.cboPurpose.TabIndex = 50;
			this.cboPurpose.SelectionChangeCommitted += new System.EventHandler(this.cboPurpose_SelectionChangeCommitted);
			this.cboPurpose.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblPurpose
			// 
			this.lblPurpose.AutoSize = true;
			this.lblPurpose.Location = new System.Drawing.Point(159, 60);
			this.lblPurpose.Name = "lblPurpose";
			this.lblPurpose.Size = new System.Drawing.Size(127, 13);
			this.lblPurpose.TabIndex = 58;
			this.lblPurpose.Text = "Purpose of Next Contact*";
			// 
			// cboDepartment
			// 
			this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboDepartment.FormattingEnabled = true;
			this.cboDepartment.Location = new System.Drawing.Point(307, 28);
			this.cboDepartment.Name = "cboDepartment";
			this.cboDepartment.Size = new System.Drawing.Size(139, 21);
			this.cboDepartment.TabIndex = 45;
			this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
			// 
			// lblDepartment
			// 
			this.lblDepartment.AutoSize = true;
			this.lblDepartment.Location = new System.Drawing.Point(304, 12);
			this.lblDepartment.Name = "lblDepartment";
			this.lblDepartment.Size = new System.Drawing.Size(66, 13);
			this.lblDepartment.TabIndex = 57;
			this.lblDepartment.Text = "Department*";
			// 
			// cboSalesRep
			// 
			this.cboSalesRep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboSalesRep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboSalesRep.FormattingEnabled = true;
			this.cboSalesRep.Location = new System.Drawing.Point(162, 28);
			this.cboSalesRep.Name = "cboSalesRep";
			this.cboSalesRep.Size = new System.Drawing.Size(139, 21);
			this.cboSalesRep.TabIndex = 43;
			this.cboSalesRep.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblNotes
			// 
			this.lblNotes.AutoSize = true;
			this.lblNotes.Location = new System.Drawing.Point(14, 109);
			this.lblNotes.Name = "lblNotes";
			this.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblNotes.Size = new System.Drawing.Size(35, 13);
			this.lblNotes.TabIndex = 56;
			this.lblNotes.Text = "Notes";
			// 
			// txtNotes
			// 
			this.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNotes.Enabled = false;
			this.txtNotes.Location = new System.Drawing.Point(17, 125);
			this.txtNotes.MaxLength = 255;
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new System.Drawing.Size(512, 50);
			this.txtNotes.TabIndex = 53;
			this.txtNotes.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblCompleted
			// 
			this.lblCompleted.AutoSize = true;
			this.lblCompleted.ImageIndex = 0;
			this.lblCompleted.Location = new System.Drawing.Point(449, 12);
			this.lblCompleted.Name = "lblCompleted";
			this.lblCompleted.Size = new System.Drawing.Size(66, 13);
			this.lblCompleted.TabIndex = 55;
			this.lblCompleted.Text = "Followed Up";
			this.lblCompleted.Visible = false;
			// 
			// cboContact
			// 
			this.cboContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboContact.FormattingEnabled = true;
			this.cboContact.Location = new System.Drawing.Point(307, 76);
			this.cboContact.Name = "cboContact";
			this.cboContact.Size = new System.Drawing.Size(139, 21);
			this.cboContact.TabIndex = 51;
			this.cboContact.SelectionChangeCommitted += new System.EventHandler(this.cboContact_SelectionChangeCommitted);
			this.cboContact.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblNextFollowUp
			// 
			this.lblNextFollowUp.AutoSize = true;
			this.lblNextFollowUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblNextFollowUp.Location = new System.Drawing.Point(449, 60);
			this.lblNextFollowUp.Name = "lblNextFollowUp";
			this.lblNextFollowUp.Size = new System.Drawing.Size(83, 13);
			this.lblNextFollowUp.TabIndex = 54;
			this.lblNextFollowUp.Text = "Next Follow Up*";
			// 
			// lblContact
			// 
			this.lblContact.AutoSize = true;
			this.lblContact.Location = new System.Drawing.Point(304, 60);
			this.lblContact.Name = "lblContact";
			this.lblContact.Size = new System.Drawing.Size(96, 13);
			this.lblContact.TabIndex = 49;
			this.lblContact.Text = "Person to Contact*";
			// 
			// lblSalesRep
			// 
			this.lblSalesRep.AutoSize = true;
			this.lblSalesRep.Location = new System.Drawing.Point(159, 12);
			this.lblSalesRep.Name = "lblSalesRep";
			this.lblSalesRep.Size = new System.Drawing.Size(60, 13);
			this.lblSalesRep.TabIndex = 48;
			this.lblSalesRep.Text = "Sales Rep*";
			// 
			// cboMethod
			// 
			this.cboMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboMethod.FormattingEnabled = true;
			this.cboMethod.Location = new System.Drawing.Point(17, 76);
			this.cboMethod.Name = "cboMethod";
			this.cboMethod.Size = new System.Drawing.Size(139, 21);
			this.cboMethod.TabIndex = 47;
			this.cboMethod.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblMethod
			// 
			this.lblMethod.AutoSize = true;
			this.lblMethod.Location = new System.Drawing.Point(14, 60);
			this.lblMethod.Name = "lblMethod";
			this.lblMethod.Size = new System.Drawing.Size(142, 13);
			this.lblMethod.TabIndex = 44;
			this.lblMethod.Text = "Requested Contact Method*";
			// 
			// NoteBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScroll = true;
			this.AutoScrollMinSize = new System.Drawing.Size(0, 210);
			this.Name = "NoteBoundary";
			this.Title = "Note";
			this.pnlControls.ResumeLayout(false);
			this.pnlControls.PerformLayout();
			this.ResumeLayout(false);

		}

		private void SetAddingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboContact.Enabled = cboContact.Items.Count > 0;
			cboDepartment.Enabled = true;
			cboMethod.Enabled = true;
			cboPurpose.Enabled = true;
			cboSalesRep.Enabled = true;
			cboSupport.Enabled = true;
			mtxtNextFollowUp.Enabled = true;
			txtNotes.Enabled = true;

			//These controlls are only visible when the note is completed
			mtxtCompleted.Visible = false;
			lblCompleted.Visible = mtxtCompleted.Visible;

			cboSupport.SelectedValue = thisUser.ID;
			cboSalesRep.SelectedValue = thisUser.ID;

			this.State = BoundaryState.Adding;
			this.Title = "Add New Note";
			this.IsDirty = false;
		}

		private void SetEditingMode()
		{
			try
			{
				this.State = BoundaryState.Loading;

				this.Clear();

				RestoreSalesSupport();

				//These controlls are only visible when the note is completed
				bool IsCompleted = MyNote.Completed != DateTime.MinValue;
				bool IsLocked = (IsCompleted || MyNote.PurposeID == DEACTIVATION || MyNote.PurposeID == ACTIVATION);
				bool IsFinalNote = (MyNote.PurposeID == FINAL_NOTE);
				bool IsFollowUpOnQuote = (MyNote.PurposeID == FOLLOW_UP_ON_QUOTE);
				bool IsNoBid = (MyNote.PurposeID == NO_BID);

				mtxtCompleted.Visible = IsCompleted;
				lblCompleted.Visible = IsCompleted;

				cboContact.Enabled = !(IsLocked || MyNote.IsArchived);
				cboDepartment.Enabled = !(IsLocked || MyNote.IsArchived || IsFollowUpOnQuote);
				cboMethod.Enabled = !(IsLocked || MyNote.IsArchived);
				cboPurpose.Enabled = !(IsLocked || MyNote.IsArchived || IsFollowUpOnQuote);
				cboSalesRep.Enabled = !(IsLocked || MyNote.IsArchived);
				cboSupport.Enabled = !(IsLocked || MyNote.IsArchived);
				mtxtNextFollowUp.Enabled = !(IsLocked || MyNote.IsArchived || IsFinalNote || IsNoBid);
				txtNotes.Enabled = !(IsLocked || MyNote.IsArchived);

				cboContact.SelectedValue = MyNote.ContactID;
				cboDepartment.SelectedValue = MyNote.DepartmentID;
				cboMethod.SelectedValue = MyNote.MethodID;
				cboPurpose.SelectedValue = MyNote.PurposeID;
				cboSupport.SelectedValue = MyNote.SalesSupportID;
				cboSalesRep.SelectedValue = MyNote.SalesRepID;
				mtxtNextFollowUp.Text = (MyNote.NextFollowUp != DateTime.MinValue ? MyNote.NextFollowUp.ToString("MM/dd/yy") : string.Empty);
				mtxtCompleted.Text = (MyNote.Completed != DateTime.MinValue ? MyNote.Completed.ToString("MM/dd/yy") : string.Empty);
				txtNotes.Text = MyNote.Notes;
				ObjectCreated = MyNote.Created.ToString("M/d/yyyy HH:mm:ss");
				ObjectCreatedBy = MyNote.GetCreator().UserName;
				ObjectUpdated = MyNote.Updated.ToString("M/d/yyyy HH:mm:ss");
				ObjectUpdatedBy = MyNote.GetUpdater().UserName;

				if (cboDepartment.SelectedItem != null)
					TruncateSalesSupport();

				if (cboContact.SelectedItem == null && MyNote.ContactID > 0)
					cboContact.Text = MyNote.GetContact().FullName;
				if (cboDepartment.SelectedItem == null && MyNote.DepartmentID > 0)
					cboDepartment.Text = MyNote.GetDepartment().Name;
				if (cboMethod.SelectedItem == null && MyNote.MethodID > 0)
					cboMethod.Text = MyNote.GetContactMethod().Name;
				if (cboPurpose.SelectedItem == null && MyNote.PurposeID > 0)
					cboPurpose.Text = MyNote.GetContactPurpose().Name;
				if (cboSupport.SelectedItem == null && MyNote.SalesSupportID > 0)
					cboSupport.Text = MyNote.GetSalesSupport().FullName;
				if (cboSalesRep.SelectedItem == null && MyNote.SalesRepID > 0)
					cboSalesRep.Text = MyNote.GetSalesRep().FullName;

				this.IsDirty = false;
				this.State = BoundaryState.Editing;
				this.Title = "Edit Note";

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message + "/n/n" + e.StackTrace); 
				throw;
			}
		}

		private void SetSearchingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboContact.Enabled = false;
			cboDepartment.Enabled = true;
			cboMethod.Enabled = false;
			cboPurpose.Enabled = false;
			cboSalesRep.Enabled = true;
			cboSupport.Enabled = false;
			mtxtNextFollowUp.Enabled = false;
			txtNotes.Enabled = false;

			//These controlls are only visible when the note is completed
			mtxtCompleted.Visible = false;
			lblCompleted.Visible = mtxtCompleted.Visible;

			RestoreSalesSupport();

			this.IsDirty = false;
			this.State = BoundaryState.Searching;
			this.Title = "Search Notes";
		}

		public bool CommitChanges()
		{
			try
			{
				int DepartmentID;
				int PurposeID;
				bool dateChanged;
				Project.Project.ProjectStatus CurrentStatus;

				if(IsSelectionValid(cboDepartment))
					DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
				else
					DepartmentID = MyNote.DepartmentID;

				using (Project.ProjectController theController = new Project.ProjectController ())
				{
					CurrentStatus = theController.GetStatus(MyNote.ProjectID, DepartmentID);
				}

				if (!IsSelectionValid(cboPurpose) && cboPurpose.Text != MyNote.GetContactPurpose().Name || string.IsNullOrEmpty(cboPurpose.Text))
					throw new Exception("The \"Purpose of Next Contact\" is not valid.");
				if (Convert.ToInt32(cboPurpose.SelectedValue) == FINAL_NOTE && CurrentStatus == Project.Project.ProjectStatus.Outstanding)
					throw new Exception("A final note cannot be added to an outstanding project.");
				if (cboContact.Enabled && !IsSelectionValid(cboContact) && cboContact.Text != MyNote.GetContact().FullName || string.IsNullOrEmpty(cboContact.Text))
					throw new Exception("The \"Contact Name\" is not valid.");
				if (!IsSelectionValid(cboDepartment) && cboDepartment.Text != MyNote.GetDepartment().Name || string.IsNullOrEmpty(cboDepartment.Text))
					throw new Exception("The \"Department\" is not valid.");
				if (cboDepartment.SelectedValue != null && !HasLeadSource())
					throw new Exception("You must add a lead source for the " + cboDepartment.Text + " department before saving this note.");
				if (!IsSelectionValid(cboMethod) && cboMethod.Text != MyNote.GetContactMethod().Name || string.IsNullOrEmpty(cboMethod.Text))
					throw new Exception("The \"Requested Contact Method\" is not valid.");
				if (!IsSelectionValid(cboSalesRep) && cboSalesRep.Text != MyNote.GetSalesRep().FullName || string.IsNullOrEmpty(cboSalesRep.Text))
					throw new Exception("The \"Sales Rep\" is not valid.");
				if (!IsSelectionValid(cboSupport) && cboSupport.Text != MyNote.GetSalesSupport().FullName || string.IsNullOrEmpty(cboSupport.Text))
					throw new Exception("The \"Sales Support\" is not valid.");

				dateChanged = !mtxtNextFollowUp.MaskCompleted ? true : Convert.ToDateTime(mtxtNextFollowUp.Text) != MyNote.NextFollowUp;
				PurposeID = (MyNote.PurposeID == ACTIVATION || MyNote.PurposeID == DEACTIVATION ? MyNote.PurposeID : Convert.ToInt32(cboPurpose.SelectedValue));
				if (PurposeID != DEACTIVATION && PurposeID != ACTIVATION && PurposeID != FINAL_NOTE && PurposeID != NO_BID && ((!mtxtNextFollowUp.MaskCompleted || !IsDateValid(mtxtNextFollowUp.Text) && dateChanged)))
					throw new Exception("The \"Next Follow Up\" date is not valid.");
				if ((PurposeID == OTHER || PurposeID == FINAL_NOTE || PurposeID == DEACTIVATION || PurposeID == ACTIVATION || PurposeID == NO_BID) && string.IsNullOrEmpty(txtNotes.Text))
					throw new Exception("The \"Notes\" cannot be blank.");


				if (cboContact.SelectedValue != null)
					MyNote.ContactID = Convert.ToInt32(cboContact.SelectedValue);
				if (cboDepartment.SelectedValue != null)
					MyNote.DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
				if (cboMethod.SelectedValue != null)
					MyNote.MethodID = Convert.ToInt32(cboMethod.SelectedValue);
				if (cboPurpose.SelectedValue != null)
					MyNote.PurposeID = Convert.ToInt32(cboPurpose.SelectedValue);
				if (cboSalesRep.SelectedValue != null)
					MyNote.SalesRepID = Convert.ToInt32(cboSalesRep.SelectedValue);
				if (cboSupport.SelectedValue != null)
					MyNote.SalesSupportID = Convert.ToInt32(cboSupport.SelectedValue);
				if (PurposeID != FINAL_NOTE && PurposeID != ACTIVATION && PurposeID != DEACTIVATION && PurposeID != NO_BID)
					MyNote.NextFollowUp = Convert.ToDateTime(mtxtNextFollowUp.Text);
				MyNote.Notes = txtNotes.Text;

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		private DataTable GetDepartmentReps(int DepartmentID)
		{
			DataTable DepartmentReps = AvailableSalesReps.Copy();
			int index = 0;

			while (index < DepartmentReps.Rows.Count)
			{
				if (Convert.ToInt32(DepartmentReps.Rows[index]["department_id"]) != DepartmentID)
					DepartmentReps.Rows.RemoveAt(index);
				else
					index++;
			}

			return DepartmentReps;
		}

		private void LoadContacts()
		{
			DataTable contacts;
			Project.Project myProject = MyNote.GetProject();
			int SelectedIndex = cboContact.SelectedIndex;
			bool origDirty = this.IsDirty;

			using (Contact.ContactController theController = new rkcrm.Objects.Contact.ContactController())
			{
				contacts = theController.GetContacts(myProject.CustomerID,false);
			}

			if (contacts.Rows.Count > 0)
			{
				//Remove duplicate rows
				int index = 0;
				DataRow previous = contacts.NewRow();
				DataRow current;

				previous["contact_id"] = 0;
				while (index < contacts.Rows.Count)
				{
					current = contacts.Rows[index];
					if (Convert.ToInt32(current["contact_id"]) == Convert.ToInt32(previous["contact_id"]))
						contacts.Rows.Remove(contacts.Rows[index]);
					else
					{
						previous = contacts.Rows[index];
						index++;
					}
				}
				
				DataRow newRow = contacts.NewRow();

				newRow["contact_id"] = 0;
				newRow["contact"] = "Add a Contact...";
				contacts.Rows.Add(newRow);

				cboContact.DataSource = contacts;
				cboContact.DisplayMember = "contact";
				cboContact.ValueMember = "contact_id";
				cboContact.SelectedItem = null;
			}
			else
				cboContact.Enabled = false;

			if (SelectedIndex > -1)
				cboContact.SelectedIndex = SelectedIndex;

			this.IsDirty = origDirty;
		}

		private void TruncateSalesSupport()
		{
			BoundaryState current = this.State;
			this.State = BoundaryState.Loading;
			
			// Store the already selected values for sales rep and sales support
			DataRowView salesRep = (DataRowView)cboSalesRep.SelectedItem;
			DataRowView salesSupport = (DataRowView)cboSupport.SelectedItem;

			cboSupport.DataSource = GetDepartmentReps(Convert.ToInt32(cboDepartment.SelectedValue));
			cboSupport.DisplayMember = "name";
			cboSupport.ValueMember = "user_id";
			cboSupport.SelectedItem = null;

			// restore the original sales support if possible
			if (salesSupport != null)
				if (Convert.ToInt32(salesSupport["department_id"]) == Convert.ToInt32(cboDepartment.SelectedValue))
					cboSupport.SelectedValue = Convert.ToInt32(salesSupport["user_id"]);

			if (salesRep != null)
			{
				// Only defualt the sales support when it is not already selected
				if (cboSupport.SelectedItem == null && Convert.ToInt32(salesRep["department_id"]) == Convert.ToInt32(cboDepartment.SelectedValue))
					cboSupport.SelectedValue = cboSalesRep.SelectedValue;
			}

			this.State = current;
		}

		private void RestoreSalesSupport()
		{
			if (AvailableSalesReps != null && AvailableSalesReps.Rows.Count != ((DataTable)cboSupport.DataSource).Rows.Count)
			{
				cboSupport.DataSource = AvailableSalesReps.Copy();
				cboSupport.DisplayMember = "name";
				cboSupport.ValueMember = "user_id";
				cboSupport.SelectedItem = null;
			}
		}

		private void RemoveNoBidMethod()
		{
			DataTable NewSource = AvailablePurposes.Copy();
			DataRow NoBidRow = null;
			int origValue = 0;

			foreach (DataRow oRow in NewSource.Rows)
				if (Convert.ToInt32(oRow[cboPurpose.ValueMember]) == NO_BID)
					NoBidRow = (DataRow)oRow;

			if (NoBidRow != null)
				NewSource.Rows.Remove(NoBidRow);

			if (cboPurpose.SelectedItem != null)
				origValue = Convert.ToInt32(cboPurpose.SelectedValue);

			cboPurpose.DataSource = NewSource;

			if (origValue > 0)
				cboPurpose.SelectedValue = origValue;
			else
				cboPurpose.SelectedItem = null;
		}

		private void AddNoBidMethod()
		{
			int origValue = 0;

			if (cboPurpose.SelectedItem != null)
				origValue = Convert.ToInt32(cboPurpose.SelectedValue);

			cboPurpose.DataSource = AvailablePurposes.Copy();

			if (origValue > 0)
				cboPurpose.SelectedValue = origValue;
			else
				cboPurpose.SelectedItem = null;
		}

		private bool IsDepartmentCrossLed(int DeprtmentID)
		{
			bool result = false;

			using (Cross_Lead.CrossLeadController theController = new Cross_Lead.CrossLeadController())
			{
				result = theController.IsCrossLed(MyNote.ProjectID, DeprtmentID);
			}

			return result;
		}

		private bool HasLeadSource()
		{
			bool result = false;
			int DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
			Customer.Customer myCustomer = MyNote.GetProject().GetCustomer();

			if (!base.HasLeadSource(myCustomer.ID, DepartmentID))
			{
				Objects.Customer.Lead_Source.AddLeadSource addSourceForm = new rkcrm.Objects.Customer.Lead_Source.AddLeadSource();
				addSourceForm.MyCustomer = myCustomer;
				addSourceForm.Title = "How did they hear about the " + cboDepartment.Text + " department?";
				addSourceForm.DepartmentID = DepartmentID;

				addSourceForm.ShowDialog();

				if (addSourceForm.DialogResult == DialogResult.OK)
				{
					result = true;
					
					//If the customer screen exists then refresh it so the new lead source appears
					RefreshCustomer();
				}
			}
			else
				result = true;

			return result;
		}

		#endregion


		#region Event Handlers

		private void cboSupport_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cboSupport.SelectedItem != null)
			{
				if ((this.State == BoundaryState.Editing || this.State == BoundaryState.Adding) && cboDepartment.Enabled)
				{
					BoundaryState current = this.State;
					this.State = BoundaryState.Loading;

					DataRowView salesSupport = (DataRowView)cboSupport.SelectedItem;
					cboDepartment.SelectedValue = Convert.ToInt32(salesSupport["department_id"]);

					TruncateSalesSupport();

					if (cboSalesRep.SelectedItem == null)
						cboSalesRep.SelectedValue = cboSupport.SelectedValue;

					this.State = current;
				}
			}
		}

		private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboDepartment.SelectedItem != null)
			{
				if (!(cboDepartment.SelectedValue is DataRowView))
				{
					TruncateSalesSupport();

					if (IsDepartmentCrossLed(Convert.ToInt32(cboDepartment.SelectedValue)))
						AddNoBidMethod();
					else
						RemoveNoBidMethod();
				}

				if (this.State == BoundaryState.Adding)
					if (MyNote.PurposeID == DEACTIVATION || MyNote.PurposeID == ACTIVATION)
					{
						bool isActive;
						using (Customer.CustomerController theController = new rkcrm.Objects.Customer.CustomerController())
						{
							isActive = theController.IsActive(MyNote.GetProject().CustomerID, Convert.ToInt32(cboDepartment.SelectedValue));
						}

						MyNote.PurposeID = (isActive ? DEACTIVATION : ACTIVATION);
						cboPurpose.Text = MyNote.GetContactPurpose().Name;
					}
			}
			else
				RestoreSalesSupport();

			control_Changed(sender, e);
		}

		private void cboPurpose_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cboPurpose.SelectedItem != null)
			{
				if (this.State == BoundaryState.Editing || this.State == BoundaryState.Adding)
				{
					int PurposeID = Convert.ToInt32(cboPurpose.SelectedValue);

					if (PurposeID == FINAL_NOTE || PurposeID == NO_BID)
					{
						mtxtNextFollowUp.Enabled = false;
						lblNextFollowUp.Text = "Next Follow Up";
						mtxtNextFollowUp.Clear();
					}
					else
					{
						mtxtNextFollowUp.Enabled = true;
						lblNextFollowUp.Text = "Next Follow Up*";
					}

					lblNotes.Text = (PurposeID == OTHER || PurposeID == FINAL_NOTE || PurposeID == NO_BID ? "Notes*" : "Notes");
					
				}
			}
		}

		private void control_Changed(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Editing || this.State == BoundaryState.Adding)
				this.IsDirty = true;
		}

		private void cboContact_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (Convert.ToInt32(cboContact.SelectedValue) == 0)
			{
				Contact.AddContact oForm = new rkcrm.Objects.Contact.AddContact();
				oForm.MyContact = new rkcrm.Objects.Contact.Contact();				
				oForm.MyContact.CustomerID = MyNote.GetProject().CustomerID;

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					LoadContacts();
					foreach (DataRowView oRow in cboContact.Items)
					{
						if (Convert.ToInt32(oRow["contact_id"]) == oForm.MyContact.ID)
							cboContact.SelectedItem = oRow;
					}
				}
				else
					cboContact.SelectedItem = null;
			}
		}

		#endregion


		#region Events

		public event EventHandler<EventArgs> MyNoteChanged;
		protected virtual void OnMyNoteChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = MyNoteChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion


		#region Constructor

		public NoteBoundary()
			: base()
		{
			this.State = BoundaryState.Loading;
			InitializeComponent();

			//Fill the sales rep combo box with avaiable sales reps whose home department is a profit center
			using (UserController theController = new UserController())
			{
				AvailableSalesReps = theController.GetAvailableEmployees();
				cboSalesRep.DataSource = AvailableSalesReps;
				cboSalesRep.DisplayMember = "name";
				cboSalesRep.ValueMember = "user_id";
				cboSalesRep.SelectedItem = null;

				//Fill the sales support combo box with avaiable sales reps whose home department is a profit center
				cboSupport.DataSource = AvailableSalesReps.Copy();
				cboSupport.DisplayMember = "name";
				cboSupport.ValueMember = "user_id";
				cboSupport.SelectedItem = null;
			}

			//Fill the contact method combo box with all available contact methods
			using (ContactMethodController theController = new ContactMethodController())
			{
				cboMethod.DataSource = theController.GetContactMethods();
				cboMethod.DisplayMember = "name";
				cboMethod.ValueMember = "method_id";
				cboMethod.SelectedItem = null;
			}

			//Fill the department combo box with profit center departments
			using (DepartmentController theController = new DepartmentController())
			{
				cboDepartment.DataSource = theController.GetProfitCenters();
				cboDepartment.DisplayMember = "name";
				cboDepartment.ValueMember = "department_id";
				cboDepartment.SelectedItem = null;
			}

			//Fill the contact method combo box with all available contact methods
			using (ContactPurposeController theController = new ContactPurposeController())
			{
				AvailablePurposes = theController.GetContactPurposes();
				cboPurpose.DataSource = AvailablePurposes;
				cboPurpose.DisplayMember = "name";
				cboPurpose.ValueMember = "purpose_id";
				cboPurpose.SelectedItem = null;
			}

			RemoveNoBidMethod();

			SetSearchingMode();
		}

		#endregion

	}
}
