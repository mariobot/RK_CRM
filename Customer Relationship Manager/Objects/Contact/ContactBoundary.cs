using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Administration.Contact_Title;
using rkcrm.Administration.Department;
using rkcrm.Administration.Phone_Type;
using rkcrm.Base_Classes;
using rkcrm.Objects.Contact.Phone_Number;

namespace rkcrm.Objects.Contact
{
	class ContactBoundary : BoundaryBase
	{

		#region Variables

		internal System.Windows.Forms.CheckBox chkSubscribed;
		internal System.Windows.Forms.Label lblEmail;
		internal System.Windows.Forms.TextBox txtEmail;
		internal System.Windows.Forms.GroupBox gbxContactFor;
		internal System.Windows.Forms.TextBox txtLastName;
		internal System.Windows.Forms.Label lblLastName;
		internal System.Windows.Forms.Label lblFirstName;
		internal System.Windows.Forms.TextBox txtFirstName;
		internal System.Windows.Forms.ComboBox cboContactTitle;
		internal System.Windows.Forms.Label lblContactTitle;
		internal ListBox lbxDepartments;
		private GroupBox gbxPhoneNumbers;
		internal DataGridView dgvPhoneNumbers;

		private const int PHONE_NUMBER_ID_INDEX = 0;
		private const int PREFERRED_INDEX = 1;
		private const int PHONE_TYPE_INDEX = 2;
		private const int PHONE_NUMBER_INDEX = 3;
		private const int EXTENSION_INDEX = 4;
		private const int DELETE_INDEX = 5;

		private const string DIRTY_FONT_FAMILY = "Arial Rounded MT Bold";
		private const string CLEAN_FONT_FAMILY = "Microsoft Sans Serif";
		private DataGridViewTextBoxColumn dgcPhoneID;
		private DataGridViewCheckBoxColumn dgcIsPreferred;
		private DataGridViewComboBoxColumn dgcType;
		private rkcrm.Custom_Controls.DataGridViewMaskedTextBoxColumn dgcPhoneNumber;
		private DataGridViewTextBoxColumn dgcExtension;
		private DataGridViewImageColumn dgcDelete;

		private Contact clsMyContact;
		private System.Collections.Generic.List<PhoneNumber> PhoneNumberCahce;

		#endregion


		#region Properties

		public Contact MyContact
		{
			get { return clsMyContact; }
			set
			{
				if (clsMyContact != value && clsMyContact != null)
					clsMyContact.Dispose();

				clsMyContact = value;

				if (value == null)
					SetSearchingMode();
				else
				{
					if (value.ID > 0)
						SetEditingMode();
					else
						SetAddingMode();
				}

				OnMyContactChanged(new EventArgs());
			}
		}

		#endregion


		#region Methods

		/// <summary>
		/// Format the given string to (xxx) xxx-xxxx
		/// </summary>
		/// <param name="PhoneNumber"></param>
		/// <returns></returns>
		private string FormatPhoneNumber(string thePhoneNumber)
		{
			if (!string.IsNullOrEmpty(thePhoneNumber))
			{
				if (thePhoneNumber.Length > 10)
					thePhoneNumber = thePhoneNumber.Substring(0, 10);

				thePhoneNumber = thePhoneNumber.Insert(0, "(");

				if (thePhoneNumber.Length > 4)
					thePhoneNumber = thePhoneNumber.Insert(4, ") ");
				else
					thePhoneNumber += ") ";

				if (thePhoneNumber.Length > 9)
					thePhoneNumber = thePhoneNumber.Insert(9, "-");
				else
					thePhoneNumber += "-";
			}

			return thePhoneNumber;
		}

		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.chkSubscribed = new System.Windows.Forms.CheckBox();
			this.lblEmail = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.gbxContactFor = new System.Windows.Forms.GroupBox();
			this.lbxDepartments = new System.Windows.Forms.ListBox();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.lblLastName = new System.Windows.Forms.Label();
			this.lblFirstName = new System.Windows.Forms.Label();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.cboContactTitle = new System.Windows.Forms.ComboBox();
			this.lblContactTitle = new System.Windows.Forms.Label();
			this.gbxPhoneNumbers = new System.Windows.Forms.GroupBox();
			this.dgvPhoneNumbers = new System.Windows.Forms.DataGridView();
			this.dgcPhoneID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcIsPreferred = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dgcType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dgcPhoneNumber = new rkcrm.Custom_Controls.DataGridViewMaskedTextBoxColumn();
			this.dgcExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcDelete = new System.Windows.Forms.DataGridViewImageColumn();
			this.pnlControls.SuspendLayout();
			this.gbxContactFor.SuspendLayout();
			this.gbxPhoneNumbers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPhoneNumbers)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.gbxPhoneNumbers);
			this.pnlControls.Controls.Add(this.chkSubscribed);
			this.pnlControls.Controls.Add(this.lblEmail);
			this.pnlControls.Controls.Add(this.txtEmail);
			this.pnlControls.Controls.Add(this.gbxContactFor);
			this.pnlControls.Controls.Add(this.txtLastName);
			this.pnlControls.Controls.Add(this.lblLastName);
			this.pnlControls.Controls.Add(this.lblFirstName);
			this.pnlControls.Controls.Add(this.txtFirstName);
			this.pnlControls.Controls.Add(this.cboContactTitle);
			this.pnlControls.Controls.Add(this.lblContactTitle);
			this.pnlControls.Size = new System.Drawing.Size(600, 263);
			// 
			// chkSubscribed
			// 
			this.chkSubscribed.AutoSize = true;
			this.chkSubscribed.Enabled = false;
			this.chkSubscribed.Location = new System.Drawing.Point(428, 230);
			this.chkSubscribed.Name = "chkSubscribed";
			this.chkSubscribed.Size = new System.Drawing.Size(141, 17);
			this.chkSubscribed.TabIndex = 5;
			this.chkSubscribed.Text = "Subscribe to Newsletter ";
			this.chkSubscribed.UseVisualStyleBackColor = true;
			this.chkSubscribed.CheckedChanged += new System.EventHandler(this.Control_Changed);
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.Location = new System.Drawing.Point(10, 212);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(76, 13);
			this.lblEmail.TabIndex = 57;
			this.lblEmail.Text = "E-mail Address";
			// 
			// txtEmail
			// 
			this.txtEmail.Enabled = false;
			this.txtEmail.Location = new System.Drawing.Point(13, 228);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(409, 20);
			this.txtEmail.TabIndex = 4;
			this.txtEmail.TextChanged += new System.EventHandler(this.Control_Changed);
			// 
			// gbxContactFor
			// 
			this.gbxContactFor.Controls.Add(this.lbxDepartments);
			this.gbxContactFor.Location = new System.Drawing.Point(438, 58);
			this.gbxContactFor.Name = "gbxContactFor";
			this.gbxContactFor.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
			this.gbxContactFor.Size = new System.Drawing.Size(135, 94);
			this.gbxContactFor.TabIndex = 6;
			this.gbxContactFor.TabStop = false;
			this.gbxContactFor.Text = "Contact For";
			// 
			// lbxDepartments
			// 
			this.lbxDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbxDepartments.FormattingEnabled = true;
			this.lbxDepartments.Location = new System.Drawing.Point(6, 16);
			this.lbxDepartments.Name = "lbxDepartments";
			this.lbxDepartments.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbxDepartments.Size = new System.Drawing.Size(123, 69);
			this.lbxDepartments.TabIndex = 1;
			this.lbxDepartments.SelectedIndexChanged += new System.EventHandler(this.Control_Changed);
			// 
			// txtLastName
			// 
			this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLastName.Location = new System.Drawing.Point(376, 25);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(197, 20);
			this.txtLastName.TabIndex = 2;
			this.txtLastName.TextChanged += new System.EventHandler(this.Control_Changed);
			// 
			// lblLastName
			// 
			this.lblLastName.AutoSize = true;
			this.lblLastName.Location = new System.Drawing.Point(373, 9);
			this.lblLastName.Name = "lblLastName";
			this.lblLastName.Size = new System.Drawing.Size(62, 13);
			this.lblLastName.TabIndex = 36;
			this.lblLastName.Text = "Last Name*";
			// 
			// lblFirstName
			// 
			this.lblFirstName.AutoSize = true;
			this.lblFirstName.Location = new System.Drawing.Point(170, 9);
			this.lblFirstName.Name = "lblFirstName";
			this.lblFirstName.Size = new System.Drawing.Size(61, 13);
			this.lblFirstName.TabIndex = 35;
			this.lblFirstName.Text = "First Name*";
			// 
			// txtFirstName
			// 
			this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFirstName.Location = new System.Drawing.Point(173, 25);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(197, 20);
			this.txtFirstName.TabIndex = 1;
			this.txtFirstName.TextChanged += new System.EventHandler(this.Control_Changed);
			// 
			// cboContactTitle
			// 
			this.cboContactTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboContactTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboContactTitle.Enabled = false;
			this.cboContactTitle.FormattingEnabled = true;
			this.cboContactTitle.Location = new System.Drawing.Point(12, 25);
			this.cboContactTitle.Name = "cboContactTitle";
			this.cboContactTitle.Size = new System.Drawing.Size(155, 21);
			this.cboContactTitle.TabIndex = 0;
			this.cboContactTitle.TextChanged += new System.EventHandler(this.Control_Changed);
			// 
			// lblContactTitle
			// 
			this.lblContactTitle.AutoSize = true;
			this.lblContactTitle.Location = new System.Drawing.Point(9, 9);
			this.lblContactTitle.Name = "lblContactTitle";
			this.lblContactTitle.Size = new System.Drawing.Size(27, 13);
			this.lblContactTitle.TabIndex = 32;
			this.lblContactTitle.Text = "Title";
			// 
			// gbxPhoneNumbers
			// 
			this.gbxPhoneNumbers.Controls.Add(this.dgvPhoneNumbers);
			this.gbxPhoneNumbers.Location = new System.Drawing.Point(12, 58);
			this.gbxPhoneNumbers.Name = "gbxPhoneNumbers";
			this.gbxPhoneNumbers.Size = new System.Drawing.Size(420, 142);
			this.gbxPhoneNumbers.TabIndex = 3;
			this.gbxPhoneNumbers.TabStop = false;
			this.gbxPhoneNumbers.Text = "Phone Numbers";
			// 
			// dgvPhoneNumbers
			// 
			this.dgvPhoneNumbers.AllowUserToDeleteRows = false;
			this.dgvPhoneNumbers.AllowUserToResizeRows = false;
			this.dgvPhoneNumbers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvPhoneNumbers.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvPhoneNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvPhoneNumbers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvPhoneNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPhoneNumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcPhoneID,
            this.dgcIsPreferred,
            this.dgcType,
            this.dgcPhoneNumber,
            this.dgcExtension,
            this.dgcDelete});
			this.dgvPhoneNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvPhoneNumbers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvPhoneNumbers.Location = new System.Drawing.Point(3, 16);
			this.dgvPhoneNumbers.Name = "dgvPhoneNumbers";
			this.dgvPhoneNumbers.RowHeadersVisible = false;
			this.dgvPhoneNumbers.Size = new System.Drawing.Size(414, 123);
			this.dgvPhoneNumbers.TabIndex = 0;
			this.dgvPhoneNumbers.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhoneNumbers_CellLeave);
			this.dgvPhoneNumbers.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhoneNumbers_CellMouseLeave);
			this.dgvPhoneNumbers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhoneNumbers_CellFormatting);
			this.dgvPhoneNumbers.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvPhoneNumbers_RowsAdded);
			this.dgvPhoneNumbers.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhoneNumbers_CellMouseEnter);
			this.dgvPhoneNumbers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhoneNumbers_CellEndEdit);
			this.dgvPhoneNumbers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhoneNumbers_CellClick);
			this.dgvPhoneNumbers.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPhoneNumbers_CurrentCellDirtyStateChanged);
			this.dgvPhoneNumbers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPhoneNumbers_DataError);
			this.dgvPhoneNumbers.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhoneNumbers_CellEnter);
			// 
			// dgcPhoneID
			// 
			this.dgcPhoneID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dgcPhoneID.FillWeight = 1F;
			this.dgcPhoneID.HeaderText = "Phone ID";
			this.dgcPhoneID.MinimumWidth = 2;
			this.dgcPhoneID.Name = "dgcPhoneID";
			this.dgcPhoneID.ReadOnly = true;
			this.dgcPhoneID.Visible = false;
			// 
			// dgcIsPreferred
			// 
			this.dgcIsPreferred.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dgcIsPreferred.FillWeight = 50F;
			this.dgcIsPreferred.HeaderText = "Preferred";
			this.dgcIsPreferred.Name = "dgcIsPreferred";
			this.dgcIsPreferred.Width = 60;
			// 
			// dgcType
			// 
			this.dgcType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dgcType.FillWeight = 90F;
			this.dgcType.HeaderText = "Phone Type";
			this.dgcType.Name = "dgcType";
			this.dgcType.Width = 134;
			// 
			// dgcPhoneNumber
			// 
			this.dgcPhoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dgcPhoneNumber.HeaderText = "Phone Number";
			this.dgcPhoneNumber.Mask = null;
			this.dgcPhoneNumber.Name = "dgcPhoneNumber";
			this.dgcPhoneNumber.PromptChar = '\0';
			this.dgcPhoneNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgcPhoneNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dgcPhoneNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.dgcPhoneNumber.ValidatingType = null;
			// 
			// dgcExtension
			// 
			this.dgcExtension.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dgcExtension.FillWeight = 50F;
			this.dgcExtension.HeaderText = "Ext.";
			this.dgcExtension.Name = "dgcExtension";
			this.dgcExtension.Width = 50;
			// 
			// dgcDelete
			// 
			this.dgcDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.NullValue = null;
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
			this.dgcDelete.DefaultCellStyle = dataGridViewCellStyle1;
			this.dgcDelete.HeaderText = "";
			this.dgcDelete.Image = global::rkcrm.Properties.Resources.Delete_icon;
			this.dgcDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
			this.dgcDelete.Name = "dgcDelete";
			this.dgcDelete.ReadOnly = true;
			this.dgcDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgcDelete.ToolTipText = "Delete";
			this.dgcDelete.Width = 21;
			// 
			// ContactBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScroll = true;
			this.AutoScrollMinSize = new System.Drawing.Size(0, 210);
			this.Name = "ContactBoundary";
			this.Size = new System.Drawing.Size(600, 313);
			this.Title = "Search Contacts";
			this.pnlControls.ResumeLayout(false);
			this.pnlControls.PerformLayout();
			this.gbxContactFor.ResumeLayout(false);
			this.gbxPhoneNumbers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvPhoneNumbers)).EndInit();
			this.ResumeLayout(false);

		}

		private void SetAddingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboContactTitle.Enabled = true;
			txtFirstName.Enabled = true;
			txtLastName.Enabled = true;
			gbxContactFor.Enabled = true;
			txtEmail.Enabled = true;
			dgvPhoneNumbers.Enabled = true;

			//Only available to administrators
			chkSubscribed.Enabled = (thisUser.Role.ID == 1);

			this.IsDirty = false;
			this.State = BoundaryState.Adding;
			this.Title = "Add New Contact";
		}

		private void SetEditingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			if (MyContact.IsArchived)
			{
				cboContactTitle.Enabled = false;
				txtFirstName.Enabled = false;
				txtLastName.Enabled = false;
				gbxContactFor.Enabled = false;
				txtEmail.Enabled = false;
				dgvPhoneNumbers.Enabled = false;
			}
			else
			{
				cboContactTitle.Enabled = true;
				txtFirstName.Enabled = true;
				txtLastName.Enabled = true;
				gbxContactFor.Enabled = true;
				txtEmail.Enabled = true;
				dgvPhoneNumbers.Enabled = true;
			}
			//Only available to administrators
			chkSubscribed.Enabled = (thisUser.Role.ID == 1);

			cboContactTitle.SelectedValue = MyContact.TitleID;
			txtFirstName.Text = MyContact.FirstName;
			txtLastName.Text = MyContact.LastName;
			txtEmail.Text = MyContact.Email;
			chkSubscribed.Checked = MyContact.IsSubscriber;
			DlblCreated.Text = MyContact.Created.ToString("MM/dd/yyyy HH:mm:ss");
			DlblCreatedBy.Text = MyContact.GetCreator().UserName;
			DlblUpdated.Text = MyContact.Updated.ToString("MM/dd/yyyy HH:mm:ss");
			DlblUpdatedBy.Text = MyContact.GetUpdater().UserName;

			if (cboContactTitle.SelectedItem == null)
				cboContactTitle.Text = MyContact.GetTitle().Name;

			LoadPhoneNumbers();

			this.IsDirty = false;
			this.State = BoundaryState.Editing;
			this.Title = "Edit Contact";
		}

		private void SetSearchingMode()
		{
			this.State = BoundaryState.Loading;

			this.Clear();

			cboContactTitle.Enabled = false;
			txtFirstName.Enabled = true;
			txtLastName.Enabled = true;
			gbxContactFor.Enabled = false;
			txtEmail.Enabled = false;
			chkSubscribed.Enabled = false;
			dgvPhoneNumbers.Enabled = false;

			this.IsDirty = false;
			this.State = BoundaryState.Searching;
			this.Title = "Search Contacts";
		}

		private void LoadPhoneNumbers()
		{
			DataGridViewRow newRow;

			dgvPhoneNumbers.Rows.Clear();

			foreach (PhoneNumber thePhone in MyContact.MyPhoneNumbers)
			{
				newRow = new DataGridViewRow();
				newRow.CreateCells(dgvPhoneNumbers);

				newRow.SetValues(
					thePhone.ID,
					thePhone.IsPerferred,
					(uint)thePhone.TypeID,
					FormatPhoneNumber(thePhone.Number),
					thePhone.Extension);

				dgvPhoneNumbers.Rows.Add(newRow);
			}
		}

		private new void Clear()
		{
			base.Clear();

			cboContactTitle.SelectedItem = null;
			chkSubscribed.Checked = true;
			txtEmail.Clear();
			txtFirstName.Clear();
			txtLastName.Clear();
			dgvPhoneNumbers.Rows.Clear();

			lbxDepartments.SelectedIndices.Clear();
		}

		private void LoadComboBoxes()
		{
			DataTable Types;

			using (PhoneTypeController theController = new PhoneTypeController())
			{
				Types = theController.GetPhoneTypes();
			}

			dgcType.DataSource = Types;
			dgcType.DisplayMember = "name";
			dgcType.ValueMember = "type_id";

			using (ContactTitleController theController = new ContactTitleController())
			{
				cboContactTitle.DataSource = theController.GetTitles();
				cboContactTitle.DisplayMember = "name";
				cboContactTitle.ValueMember = "title_id";
			}
		}

		private int GetDepartmentIndex(int DepartmentID)
		{
			int index = 0;

			while (index < lbxDepartments.Items.Count)
			{
				if (Convert.ToInt32(((DataRowView)lbxDepartments.Items[index])["department_id"]) == DepartmentID)
					break;

				index++;
			}

			return index;
		}

		internal bool CommitChanges()
		{
			try
			{
				dgvPhoneNumbers.EndEdit();
				RemoveEmptyPhones();

				if (string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtLastName.Text))
					throw new Exception("The contact needs a \"First Name\" or a \"Last Name\".");
				if (!IsSelectionValid(cboContactTitle) && cboContactTitle.Text != MyContact.GetTitle().Name)
					throw new Exception("The \"Contact Title\" is not valid.");
				if (PhoneNumberCount() == 0)
					throw new Exception("The contact must have at least one \"Phone Number\".");
				if (!HasPreferredNumber())
					throw new Exception("Please select the phone number that the contact prefers to be used.");

				foreach (DataGridViewRow oRow in dgvPhoneNumbers.Rows)
					if (!oRow.IsNewRow)
						CommitPhoneNumber(oRow);

				if (cboContactTitle.SelectedValue != null)
					MyContact.TitleID = Convert.ToInt32(cboContactTitle.SelectedValue);
				MyContact.FirstName = txtFirstName.Text;
				MyContact.LastName = txtLastName.Text;
				MyContact.Email = txtEmail.Text;
				MyContact.IsSubscriber = chkSubscribed.Checked;

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		private void CommitPhoneNumber(DataGridViewRow theRow)
		{
			string theNumber = Convert.ToString(theRow.Cells[PHONE_NUMBER_INDEX].Value);
			PhoneNumber oPhone = null;

			try
			{
				if (theRow.Visible)
				{
					//First determine if the data is valid
					if (ExcludePromptAndLiterals(theNumber).Length < 10)
						throw new Exception(theNumber + " is not a valid phone number.");

					theNumber = ExcludePromptAndLiterals(theNumber);

					oPhone = new PhoneNumber();

					//Fetch the phone number from the data base
					using (rkcrm.Objects.Phone_Number.PhoneNumberController theController = new rkcrm.Objects.Phone_Number.PhoneNumberController())
					{
						oPhone.SetPhoneNumber(theController.GetPhoneNumber(theNumber));
					}

					oPhone.Number = theNumber;
					oPhone.IsPerferred = Convert.ToBoolean(theRow.Cells[PREFERRED_INDEX].Value);
					oPhone.TypeID = Convert.ToInt32(theRow.Cells[PHONE_TYPE_INDEX].Value);
					oPhone.Extension = Convert.ToString(theRow.Cells[EXTENSION_INDEX].Value);

					PhoneNumberCahce.Add(oPhone);
				}

			}
			catch (Exception e)
			{
				throw e;
			}
		}

		private int PhoneNumberCount()
		{
			int result = 0;

			foreach (DataGridViewRow oRow in dgvPhoneNumbers.Rows)
				if (oRow.Visible && !oRow.IsNewRow)
					result++;

			return result;
		}

		private bool HasPreferredNumber()
		{
			bool result = false;

			foreach (DataGridViewRow oRow in dgvPhoneNumbers.Rows)
				if (oRow.Cells[PREFERRED_INDEX].Value == null ? false : (bool)oRow.Cells[PREFERRED_INDEX].Value)
					result = true;

			return result;
		}

		public bool SavePhoneNumbers()
		{
			bool result = true;
			int index = 0;
			PhoneNumber oPhone = null;

			//Clear the contacts current list of phone numbers
			MyContact.MyPhoneNumbers.Clear();

			using (rkcrm.Objects.Phone_Number.PhoneNumberController theCrontroller = new rkcrm.Objects.Phone_Number.PhoneNumberController())
			{
				while (index < PhoneNumberCahce.Count && result == true)
				{
					oPhone = PhoneNumberCahce[index];

					oPhone.ContactID = MyContact.ID;

					if (oPhone.ID > 0)
						if (theCrontroller.UpdatePhoneNumber(oPhone.GetPhoneNumber()))
							theCrontroller.LinkContact(oPhone, MyContact.ID);
						else
							result = false;
					else
					{
						oPhone.SetPhoneNumber(theCrontroller.InsertPhoneNumber(oPhone.GetPhoneNumber()));

						if (oPhone.ID == 0)
							result = false;
						else
							theCrontroller.LinkContact(oPhone, MyContact.ID);
					}

					MyContact.MyPhoneNumbers.Add(oPhone);
					index++;
				}

				if (!theCrontroller.RemoveUnusedLinks(MyContact))
					result = false;
			}
			
			return result;
		}

		public bool Save()
		{
			bool result = true;

			if (CommitChanges())
			{
				using (ContactController theController = new ContactController())
				{
					if (MyContact.ID > 0)
						result = theController.UpdateContact(MyContact);
					else
					{
						clsMyContact = theController.InsertContact(MyContact);

						result = (MyContact.ID > 0);
					}
				}

				if (result)
					result = SavePhoneNumbers();
			}
			else
				result = false;

			PhoneNumberCahce.Clear();
			return result;
		}

		private string ExcludePromptAndLiterals(string PhoneNumber)
		{
			string justNumbers = string.Empty;

			foreach (char oChar in PhoneNumber)
				if (char.IsNumber(oChar))
					justNumbers += oChar;

			return justNumbers;
		}

		private void RemoveEmptyPhones()
		{
			int index = 0;
			string theNumber = string.Empty;

			while (index < dgvPhoneNumbers.RowCount)
				if (!dgvPhoneNumbers.Rows[index].IsNewRow)
				{
					theNumber = Convert.ToString(dgvPhoneNumbers.Rows[index].Cells[PHONE_NUMBER_INDEX].Value);
					theNumber = ExcludePromptAndLiterals(theNumber);

					if (string.IsNullOrEmpty(theNumber))
						if (dgvPhoneNumbers.Rows[index].Cells[PHONE_NUMBER_ID_INDEX].Value == null)
							dgvPhoneNumbers.Rows.RemoveAt(index);
						else
						{
							dgvPhoneNumbers.Rows[index].Visible = false;
							index++;
						}
					else
						index++;
				}
				else
					index++;
		}

		#endregion

		
		#region Event Handlers

		private void Control_Changed(object sender, EventArgs e)
		{
			if ((this.State == BoundaryState.Adding || this.State == BoundaryState.Editing) && !this.IsDirty)
				this.IsDirty = true;
		}

		private void dgvPhoneNumbers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridViewImageCell oCell = null;

			if (e.ColumnIndex > 4)
			{
				oCell = (DataGridViewImageCell)dgvPhoneNumbers[e.ColumnIndex, e.RowIndex];
				e.Value = null;
			}

			if (oCell != null)
			{
				switch (e.ColumnIndex)
				{
					case DELETE_INDEX:
						e.Value = rkcrm.Properties.Resources.Delete_icon;
						break;
					default:
						break;
				}
			}
		}

		private void dgvPhoneNumbers_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
			{
				switch (e.ColumnIndex)
				{
					case DELETE_INDEX:
						dgvPhoneNumbers.Cursor = Cursors.Hand;
						break;
					default:
						break;
				}
			}
		}

		private void dgvPhoneNumbers_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
			{
				switch (e.ColumnIndex)
				{
					case DELETE_INDEX:
						dgvPhoneNumbers.Cursor = Cursors.Default;
						break;
					default:
						break;
				}
			}
		}

		private void dgvPhoneNumbers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			dgvPhoneNumbers_CellEnter(sender, e);
		}

		private void dgvPhoneNumbers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			dgvPhoneNumbers_CellLeave(sender, e);
		}

		private void dgvPhoneNumbers_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex > -1 && e.RowIndex > -1)
			{
				if (!dgvPhoneNumbers.CurrentRow.IsNewRow)
				{
					switch (e.ColumnIndex)
					{
						case DELETE_INDEX:
							if (Convert.ToBoolean(dgvPhoneNumbers.CurrentRow.Cells[PREFERRED_INDEX].Value))
								dgvPhoneNumbers[PREFERRED_INDEX, 0].Value = true;

							if (dgvPhoneNumbers.CurrentRow.Cells[PHONE_NUMBER_ID_INDEX].Value == null)
								dgvPhoneNumbers.Rows.RemoveAt(e.RowIndex);
							else
								dgvPhoneNumbers.CurrentRow.Visible = false;

							if (!IsDirty)
								IsDirty = true;
							break;
						default:
							break;
					}
				}
			}
		}

		private void dgvPhoneNumbers_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			DataGridViewCell oCell = dgvPhoneNumbers[e.ColumnIndex, e.RowIndex];

			if (oCell is DataGridViewComboBoxCell)
			{
				e.Cancel = true;
			}
		}

		private void dgvPhoneNumbers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if ((this.State == BoundaryState.Adding || this.State == BoundaryState.Editing) && !this.IsDirty)
				this.IsDirty = true;

			foreach (DataGridViewCell oCell in dgvPhoneNumbers.CurrentRow.Cells)
				oCell.Style.Font = new Font(DIRTY_FONT_FAMILY, 9F, FontStyle.Regular);

			if (dgvPhoneNumbers.CurrentCell != null)
			{
				switch (dgvPhoneNumbers.CurrentCell.ColumnIndex)
				{
					case PREFERRED_INDEX:
						if (!Convert.ToBoolean(dgvPhoneNumbers.CurrentCell.Value))
							foreach (DataGridViewRow oRow in dgvPhoneNumbers.Rows)
								if (oRow.Index != dgvPhoneNumbers.CurrentCell.RowIndex)
									oRow.Cells[PREFERRED_INDEX].Value = false;
						break;
					default:
						break;
				}
			}
		}

		private void dgvPhoneNumbers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex > -1 && e.RowIndex > -1)
			{
				switch (e.ColumnIndex)
				{
					case PHONE_NUMBER_INDEX:
						if (dgvPhoneNumbers[e.ColumnIndex, e.RowIndex].Value != null)
						{
							DataTable otherOwners;
							string justNumbers = ExcludePromptAndLiterals(dgvPhoneNumbers[e.ColumnIndex, e.RowIndex].Value.ToString());
							
							using (rkcrm.Objects.Phone_Number.PhoneNumberController theController = new rkcrm.Objects.Phone_Number.PhoneNumberController())
							{
								otherOwners = theController.GetOtherOwners(justNumbers, MyContact.CustomerID);

								if (otherOwners.Rows.Count > 0)
								{
									rkcrm.Objects.Phone_Number.DuplicatePhoneNumbers oForm = new rkcrm.Objects.Phone_Number.DuplicatePhoneNumbers();

									oForm.OwnerList = otherOwners;
									oForm.PhoneNumber = justNumbers;
									oForm.ShowDialog();

									if (oForm.DialogResult != DialogResult.OK)
										dgvPhoneNumbers[e.ColumnIndex, e.RowIndex].Value = string.Empty;
									else
										dgvPhoneNumbers[PHONE_NUMBER_ID_INDEX, e.RowIndex].Value = null;
								}
							}
						}
						break;
					case PREFERRED_INDEX:
						int count = 0;
						foreach (DataGridViewRow oRow in dgvPhoneNumbers.Rows)
							if (!oRow.IsNewRow)
								if (Convert.ToBoolean(oRow.Cells[PREFERRED_INDEX].Value))
									count++;

						if (count == 0)
							dgvPhoneNumbers[e.ColumnIndex, e.RowIndex].Value = true;
						break;
					default:
						break;
				}
			}
		}

		private void dgvPhoneNumbers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (dgvPhoneNumbers.RowCount == 2 && this.State != BoundaryState.Loading)
				dgvPhoneNumbers[PREFERRED_INDEX, 0].Value = true;
		}

		#endregion


		#region Events

		public event EventHandler<EventArgs> MyContactChanged;
		protected virtual void OnMyContactChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = MyContactChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion


		#region Constructor

		public ContactBoundary()
			: base()
		{

			InitializeComponent();

			using (DepartmentController theController = new DepartmentController())
			{
				lbxDepartments.DataSource = theController.GetProfitCenters();
				lbxDepartments.DisplayMember = "name";
				lbxDepartments.ValueMember = "department_id";
				lbxDepartments.SelectedItems.Clear();
			}
			
			LoadComboBoxes();
			PhoneNumberCahce = new System.Collections.Generic.List<PhoneNumber>();
			SetSearchingMode();
		}

		#endregion

	}
}
