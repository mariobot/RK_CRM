using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Administration.Customer_Type;
using rkcrm.Administration.ZipCode;
using rkcrm.Base_Classes;
using rkcrm.Objects.Phone_Number;
using rkcrm.Objects.Customer.Lead_Source;

namespace rkcrm.Objects.Customer
{
	class CustomerBoundary : BoundaryBase
	{

		#region Variables

		internal System.Windows.Forms.MaskedTextBox mtxtPhoneNumber;
		internal System.Windows.Forms.Label lblPhoneNumber;
		internal System.Windows.Forms.Label lblCustomerType;
		internal System.Windows.Forms.ComboBox cboCustomerType;
		internal System.Windows.Forms.Label lblName;
		internal System.Windows.Forms.TextBox txtName;
		private GroupBox gbxLeadSource;
		private ImageList imlLeadSource;
		private System.ComponentModel.IContainer components;
		private Panel pnlName;
		private Panel pnlSpacer0;
		private rkcrm.Objects.Customer.Lead_Source.LeadSourceBoundary leadSourceControls;
		private Button btnAddLeadSource;

		private Customer clsMyCustomer;
		private rkcrm.Objects.Customer.Preview_Controls.AddressPreview AddressControls;
		private rkcrm.Objects.Customer.Preview_Controls.RelatedCustomersPreview relatedCustomerControls;
		private rkcrm.Objects.Customer.Preview_Controls.LeadSourceList leadSourceListControls;
		private List<LeadSource> NewLeadSources;

		#endregion


		#region Properties

		/// <summary>
		/// Gets or sets the rkcrm.Objects.Customer.Customer object used by this control
		/// </summary>
		public Customer MyCustomer
		{
			get { return clsMyCustomer; }
			set 
			{
				if (clsMyCustomer != value && clsMyCustomer != null)
					clsMyCustomer.Dispose();

				clsMyCustomer = value;

				if (clsMyCustomer != null)
				{
					if (clsMyCustomer.ID > 0)
						SetEditingMode();
					else
						SetAddingMode();

					leadSourceControls.MySource.CustomerID = clsMyCustomer.ID;
				}
				else
					IsDirty = false;

				OnMyCustomerChanged(new EventArgs());
			}
		}

		public Lead_Source.LeadSourceBoundary MyLeadSource
		{
			get { return leadSourceControls; }
		}

		#endregion


		#region Methods

		/// <summary>
		/// Clears all data from the screen
		/// </summary>
		private new void Clear()
		{
			base.Clear();

			cboCustomerType.SelectedItem = null;
			AddressControls.txtAddress.Clear();
			AddressControls.txtAptBldNum.Clear();
			AddressControls.txtCity.Clear();
			txtName.Clear();
			AddressControls.txtState.Clear();
			AddressControls.txtZipcode.Clear();
			leadSourceListControls.lvwLeadSources.Items.Clear();
			mtxtPhoneNumber.Clear();
		}

		/// <summary>
		/// Updates the rkcrm.Objects.Customer.Customer in the MyCustomer property with data in the contorls
		/// </summary>
		/// <returns></returns>
		public bool CommitChanges()
		{
			try
			{
				string TypeName = MyCustomer.GetCustomerType().Name;

				if (!IsSelectionValid(cboCustomerType) && cboCustomerType.Text != TypeName || string.IsNullOrEmpty(cboCustomerType.Text))
					throw new Exception("The \"Customer Type\" is not valid.");
				if (string.IsNullOrEmpty(txtName.Text))
					throw new Exception("The \"Company Name\" cannot be blank.");
				if (!char.IsLetterOrDigit(txtName.Text[0]))
					throw new Exception("The \"Company Name\" must begin with a letter or number.");
				if (txtName.Text != MyCustomer.Name && !IsNameValid())
					throw new Exception("The \"Company Name\" is not valid.");
				if (!mtxtPhoneNumber.MaskCompleted)
					throw new Exception("The \"Phone Number\" is not complete.");
				if (!IsInteger(AddressControls.txtZipcode.Text))
					throw new Exception("The \"Zip Code\" must be a 5 digit number.");
				if (leadSourceListControls.lvwLeadSources.Items.Count == 0 && this.State == BoundaryState.Editing)
					throw new Exception("There must be at least one \"Lead Source\".");

				if (cboCustomerType.SelectedItem != null)
					MyCustomer.TypeID = Convert.ToInt32(cboCustomerType.SelectedValue);
				MyCustomer.PhoneNumber = mtxtPhoneNumber.Text;
				MyCustomer.Name = txtName.Text;
				MyCustomer.Address = AddressControls.txtAddress.Text;
				MyCustomer.AptLotSte = AddressControls.txtAptBldNum.Text;
				MyCustomer.ZipCode = AddressControls.txtZipcode.Text != string.Empty ? Convert.ToInt32(AddressControls.txtZipcode.Text) : 0;
				MyCustomer.City = AddressControls.txtCity.Text;
				MyCustomer.State = AddressControls.txtState.Text;

				return true;

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		private bool IsNameValid()
		{
			DataTable oTable;
			bool result = true;

			using (CustomerController theController = new CustomerController())
			{
				oTable = theController.GetDuplicateCustomers(txtName.Text, MyCustomer.ID);
			}

			foreach (DataRow oRow in oTable.Rows)
			{
				if (Convert.ToBoolean(oRow["require_unique_name"]))
					result = false;
			}

			return result;
		}

		/// <summary>
		/// Determines whether the string is a number
		/// </summary>
		/// <param name="theText"></param>
		/// <returns></returns>
		private bool IsInteger(string theText)
		{
			bool result = true;

			foreach (char oChar in theText.ToCharArray())
				if (!char.IsNumber(oChar))
					result = false;

			return result;
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerBoundary));
			this.mtxtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
			this.lblPhoneNumber = new System.Windows.Forms.Label();
			this.lblCustomerType = new System.Windows.Forms.Label();
			this.cboCustomerType = new System.Windows.Forms.ComboBox();
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.gbxLeadSource = new System.Windows.Forms.GroupBox();
			this.btnAddLeadSource = new System.Windows.Forms.Button();
			this.leadSourceControls = new rkcrm.Objects.Customer.Lead_Source.LeadSourceBoundary();
			this.imlLeadSource = new System.Windows.Forms.ImageList(this.components);
			this.pnlName = new System.Windows.Forms.Panel();
			this.pnlSpacer0 = new System.Windows.Forms.Panel();
			this.AddressControls = new rkcrm.Objects.Customer.Preview_Controls.AddressPreview();
			this.relatedCustomerControls = new rkcrm.Objects.Customer.Preview_Controls.RelatedCustomersPreview();
			this.leadSourceListControls = new rkcrm.Objects.Customer.Preview_Controls.LeadSourceList();
			this.pnlControls.SuspendLayout();
			this.gbxLeadSource.SuspendLayout();
			this.pnlName.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.relatedCustomerControls);
			this.pnlControls.Controls.Add(this.AddressControls);
			this.pnlControls.Controls.Add(this.leadSourceListControls);
			this.pnlControls.Controls.Add(this.pnlSpacer0);
			this.pnlControls.Controls.Add(this.gbxLeadSource);
			this.pnlControls.Controls.Add(this.pnlName);
			this.pnlControls.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.pnlControls.Size = new System.Drawing.Size(631, 377);
			// 
			// mtxtPhoneNumber
			// 
			this.mtxtPhoneNumber.Location = new System.Drawing.Point(469, 23);
			this.mtxtPhoneNumber.Mask = "(000) 000-0000";
			this.mtxtPhoneNumber.Name = "mtxtPhoneNumber";
			this.mtxtPhoneNumber.Size = new System.Drawing.Size(104, 20);
			this.mtxtPhoneNumber.TabIndex = 30;
			this.mtxtPhoneNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
			this.mtxtPhoneNumber.TextChanged += new System.EventHandler(this.mtxtPhoneNumber_TextChanged);
			// 
			// lblPhoneNumber
			// 
			this.lblPhoneNumber.AutoSize = true;
			this.lblPhoneNumber.Location = new System.Drawing.Point(466, 7);
			this.lblPhoneNumber.Name = "lblPhoneNumber";
			this.lblPhoneNumber.Size = new System.Drawing.Size(95, 13);
			this.lblPhoneNumber.TabIndex = 34;
			this.lblPhoneNumber.Text = "Company Number*";
			// 
			// lblCustomerType
			// 
			this.lblCustomerType.AutoSize = true;
			this.lblCustomerType.Location = new System.Drawing.Point(-1, 7);
			this.lblCustomerType.Name = "lblCustomerType";
			this.lblCustomerType.Size = new System.Drawing.Size(82, 13);
			this.lblCustomerType.TabIndex = 32;
			this.lblCustomerType.Text = "Customer Type*";
			// 
			// cboCustomerType
			// 
			this.cboCustomerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboCustomerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboCustomerType.FormattingEnabled = true;
			this.cboCustomerType.Location = new System.Drawing.Point(2, 23);
			this.cboCustomerType.Name = "cboCustomerType";
			this.cboCustomerType.Size = new System.Drawing.Size(149, 21);
			this.cboCustomerType.TabIndex = 26;
			this.cboCustomerType.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(154, 7);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(86, 13);
			this.lblName.TabIndex = 29;
			this.lblName.Text = "Company Name*";
			// 
			// txtName
			// 
			this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtName.Location = new System.Drawing.Point(157, 23);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(306, 20);
			this.txtName.TabIndex = 28;
			this.txtName.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// gbxLeadSource
			// 
			this.gbxLeadSource.Controls.Add(this.btnAddLeadSource);
			this.gbxLeadSource.Controls.Add(this.leadSourceControls);
			this.gbxLeadSource.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxLeadSource.Location = new System.Drawing.Point(8, 53);
			this.gbxLeadSource.Name = "gbxLeadSource";
			this.gbxLeadSource.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
			this.gbxLeadSource.Size = new System.Drawing.Size(615, 85);
			this.gbxLeadSource.TabIndex = 57;
			this.gbxLeadSource.TabStop = false;
			this.gbxLeadSource.Text = "How did they hear about R&&K?";
			// 
			// btnAddLeadSource
			// 
			this.btnAddLeadSource.BackgroundImage = global::rkcrm.Properties.Resources.New_Icon;
			this.btnAddLeadSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnAddLeadSource.FlatAppearance.BorderSize = 0;
			this.btnAddLeadSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddLeadSource.Location = new System.Drawing.Point(530, 44);
			this.btnAddLeadSource.Name = "btnAddLeadSource";
			this.btnAddLeadSource.Size = new System.Drawing.Size(16, 16);
			this.btnAddLeadSource.TabIndex = 57;
			this.btnAddLeadSource.UseVisualStyleBackColor = true;
			this.btnAddLeadSource.Click += new System.EventHandler(this.btnAddLeadSource_Click);
			// 
			// leadSourceControls
			// 
			this.leadSourceControls.BackColor = System.Drawing.Color.White;
			this.leadSourceControls.ChangeHistoryVisible = false;
			this.leadSourceControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.leadSourceControls.IsBasic = true;
			this.leadSourceControls.Location = new System.Drawing.Point(6, 16);
			this.leadSourceControls.MinimumSize = new System.Drawing.Size(0, 60);
			this.leadSourceControls.MySource = null;
			this.leadSourceControls.Name = "leadSourceControls";
			this.leadSourceControls.ShowDepartments = false;
			this.leadSourceControls.Size = new System.Drawing.Size(603, 60);
			this.leadSourceControls.TabIndex = 56;
			this.leadSourceControls.Title = "Lead Sources";
			this.leadSourceControls.TitleBarVisible = false;
			// 
			// imlLeadSource
			// 
			this.imlLeadSource.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLeadSource.ImageStream")));
			this.imlLeadSource.TransparentColor = System.Drawing.Color.Transparent;
			this.imlLeadSource.Images.SetKeyName(0, "New_Icon.png");
			// 
			// pnlName
			// 
			this.pnlName.Controls.Add(this.lblCustomerType);
			this.pnlName.Controls.Add(this.txtName);
			this.pnlName.Controls.Add(this.lblName);
			this.pnlName.Controls.Add(this.mtxtPhoneNumber);
			this.pnlName.Controls.Add(this.cboCustomerType);
			this.pnlName.Controls.Add(this.lblPhoneNumber);
			this.pnlName.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlName.Location = new System.Drawing.Point(8, 0);
			this.pnlName.Name = "pnlName";
			this.pnlName.Size = new System.Drawing.Size(615, 53);
			this.pnlName.TabIndex = 58;
			// 
			// pnlSpacer0
			// 
			this.pnlSpacer0.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlSpacer0.Location = new System.Drawing.Point(8, 138);
			this.pnlSpacer0.Name = "pnlSpacer0";
			this.pnlSpacer0.Size = new System.Drawing.Size(615, 5);
			this.pnlSpacer0.TabIndex = 59;
			// 
			// AddressControls
			// 
			this.AddressControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.AddressControls.ExpandedHeight = 125;
			this.AddressControls.IsDirty = false;
			this.AddressControls.IsExpanded = false;
			this.AddressControls.Location = new System.Drawing.Point(8, 170);
			this.AddressControls.Name = "AddressControls";
			this.AddressControls.Size = new System.Drawing.Size(615, 27);
			this.AddressControls.TabIndex = 60;
			this.AddressControls.Title = "Address";
			this.AddressControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.control_Changed);
			// 
			// relatedCustomerControls
			// 
			this.relatedCustomerControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.relatedCustomerControls.ExpandedHeight = 150;
			this.relatedCustomerControls.IsExpanded = false;
			this.relatedCustomerControls.Location = new System.Drawing.Point(8, 197);
			this.relatedCustomerControls.Name = "relatedCustomerControls";
			this.relatedCustomerControls.Size = new System.Drawing.Size(615, 27);
			this.relatedCustomerControls.TabIndex = 62;
			this.relatedCustomerControls.Title = "Related Customers";
			// 
			// leadSourceListControls
			// 
			this.leadSourceListControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.leadSourceListControls.ExpandedHeight = 150;
			this.leadSourceListControls.IsExpanded = false;
			this.leadSourceListControls.Location = new System.Drawing.Point(8, 143);
			this.leadSourceListControls.Name = "leadSourceListControls";
			this.leadSourceListControls.Size = new System.Drawing.Size(615, 27);
			this.leadSourceListControls.TabIndex = 63;
			this.leadSourceListControls.Title = "Lead Sources";
			// 
			// CustomerBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScroll = true;
			this.Name = "CustomerBoundary";
			this.Size = new System.Drawing.Size(631, 427);
			this.Title = "General Information";
			this.Load += new System.EventHandler(this.CustomerBoundary_Load);
			this.pnlControls.ResumeLayout(false);
			this.gbxLeadSource.ResumeLayout(false);
			this.pnlName.ResumeLayout(false);
			this.pnlName.PerformLayout();
			this.ResumeLayout(false);

		}

		/// <summary>
		/// Populates the combo boxes with data from the database
		/// </summary>
		private void LoadComboBoxes()
		{
			using (CustomerTypeController theController = new CustomerTypeController())
			{
				cboCustomerType.DataSource = theController.GetCustomerTypes();
				cboCustomerType.DisplayMember = "name";
				cboCustomerType.ValueMember = "type_id";
				cboCustomerType.SelectedItem = null;
			}
		}

		public void SetAddingMode()
		{
			this.State = BoundaryState.Loading;

			leadSourceControls.MySource = new rkcrm.Objects.Customer.Lead_Source.LeadSource();

			relatedCustomerControls.Visible = false;
			AddressControls.IsExpanded = true;
			btnAddLeadSource.Visible = false;

			this.Clear();

			this.Title = "New Customer";
			this.State = BoundaryState.Adding;
			this.IsDirty = false;
		}

		/// <summary>
		/// Populates controls with the data provided by the MyCustomer property
		/// </summary>
		private void SetEditingMode()
		{
			this.State = BoundaryState.Loading;

			ZipCode myZip = MyCustomer.GetZipCode();

			cboCustomerType.SelectedValue = MyCustomer.TypeID;
			txtName.Text = MyCustomer.Name;
			mtxtPhoneNumber.Text = MyCustomer.PhoneNumber;
			AddressControls.txtAddress.Text = MyCustomer.Address;
			AddressControls.txtAptBldNum.Text = MyCustomer.AptLotSte;
			AddressControls.txtZipcode.Text = (MyCustomer.ZipCode > 0 ? MyCustomer.ZipCode.ToString() : string.Empty);
			AddressControls.txtCity.Text = MyCustomer.City;
			AddressControls.txtState.Text = MyCustomer.State;

			ObjectCreated = MyCustomer.Created.ToString("MM/dd/yyyy HH:mm:ss");
			ObjectUpdated = MyCustomer.Updated.ToString("MM/dd/yyyy HH:mm:ss");
			ObjectCreatedBy = MyCustomer.GetCreator().UserName;
			ObjectUpdatedBy = MyCustomer.GetUpdater().UserName;

			//This enables the boundary to display those types that are no longer available
			if (cboCustomerType.SelectedItem == null)
				cboCustomerType.Text = MyCustomer.GetCustomerType().Name;
			
			RefreshLeadSources();
			RefreshRelatedCustomers();

			leadSourceControls.MySource = new rkcrm.Objects.Customer.Lead_Source.LeadSource();
			AddressControls.IsDirty = false;

			this.Title = "General Information";
			this.State = BoundaryState.Editing;

			this.IsDirty = false;
		}

		/// <summary>
		/// Clears all controls of data then uses the MyCustomer to load customer data back into the controls
		/// </summary>
		public override void Refresh()
		{
			Clear();
			if (MyCustomer != null)
				SetEditingMode();
		}

		public void RefreshLeadSources()
		{
			leadSourceListControls.lvwLeadSources.Items.Clear();

			using (Lead_Source.LeadSourceController thecontroller = new Lead_Source.LeadSourceController())
			{
				ListViewItem newItem;
				DataTable oTable = thecontroller.GetCurrentLeadSources(MyCustomer.ID);
				int index = 0;

				foreach (LeadSource oSource in NewLeadSources)
				{
					newItem = new ListViewItem();
					newItem.Text = oSource.GetLeadSource().Name;
					newItem.SubItems.Add(oSource.GetDeartment().Name);
					newItem.SubItems.Add(oSource.Activated.ToString("M/d/yy") + " - Current");
					newItem.SubItems.Add(thisUser.FullName);

					while (index < oTable.Rows.Count)
						if (Convert.ToInt32(oTable.Rows[index]["department_id"]) == oSource.DepartmentID)
							oTable.Rows.RemoveAt(index);
						else
							index++;

					index = 0;
					leadSourceListControls.lvwLeadSources.Items.Add(newItem);
				}

				foreach (DataRow oRow in oTable.Rows)
				{
					newItem = new ListViewItem();
					newItem.Text = oRow["lead_source"].ToString();
					newItem.SubItems.Add(oRow["department"].ToString());
					newItem.SubItems.Add(Convert.ToDateTime(oRow["activated"]).ToString("M/d/yy") + " - Current");
					newItem.SubItems.Add(oRow["adder"].ToString());

					leadSourceListControls.lvwLeadSources.Items.Add(newItem);
				}
			}
		}

		public void RefreshRelatedCustomers()
		{
			ListViewItem oItem;

			relatedCustomerControls.lvwList.Items.Clear();

			using (CustomerController theController = new CustomerController())
			{
				foreach (DataRow oRow in theController.GetRelatedCustomers(MyCustomer.ID).Rows)
				{
					oItem = new ListViewItem();
					oItem.Text = oRow["customer_id"].ToString();
					oItem.SubItems.Add(oRow["customer"].ToString());

					relatedCustomerControls.lvwList.Items.Add(oItem);
				}
			}

			relatedCustomerControls.Title = "Related Customers - " + relatedCustomerControls.lvwList.Items.Count;
			relatedCustomerControls.Visible = (relatedCustomerControls.lvwList.Items.Count > 0);
		}

		public bool Save()
		{
			bool result = true;

			if (CommitChanges())
			{
				using (CustomerController theController = new CustomerController())
				{
					if (MyCustomer.ID > 0)
						result = theController.UpdateCustomer(MyCustomer);
					else
					{
						clsMyCustomer = theController.InsertCustomer(MyCustomer);
						result = (MyCustomer.ID > 0);
					}
				}

				if (result)
				{
					result = SaveLeadSources();
					ProcessGeneralNotesProject();
				}
			}
			else
				result = false;

			NewLeadSources.Clear();
			return result;
		}

		private bool SaveLeadSources()
		{
			bool result = true;
			LeadSource container;

			using (LeadSourceController theController = new LeadSourceController())
			{
				foreach (LeadSource theSource in NewLeadSources)
				{
					container = theController.InsertLeadSource(theSource);

					if (container.ID == 0)
						result = false;
				}
			}

			return result;
		}

		private void ProcessGeneralNotesProject()
		{
			Project.Project generalNotes = MyCustomer.GetGeneralNotesProject();
			bool IsArchived = false;

			if (generalNotes == null)
			{
				generalNotes = new rkcrm.Objects.Project.Project();
				generalNotes.Name = "GENERAL NOTES";
				generalNotes.TypeID = 10;
				generalNotes.CustomerID = MyCustomer.ID;
			}
			else
				IsArchived = generalNotes.IsArchived;

			generalNotes.IsArchived = !MyCustomer.GetCustomerType().RequireUniqueName;

			using (Project.ProjectController theController = new rkcrm.Objects.Project.ProjectController())
			{
				if (generalNotes.ID == 0)
					generalNotes = theController.InsertProject(generalNotes);

				if (IsArchived != generalNotes.IsArchived)
					theController.UpdateProject(generalNotes);
			}
		}

		#endregion


		#region Event Handlers

		private void CustomerBoundary_Load(object sender, EventArgs e)
		{
			this.btnAddLeadSource.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
			this.btnAddLeadSource.Leave += new System.EventHandler(this.Button_Leave);
			this.btnAddLeadSource.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Button_KeyUp);
			this.btnAddLeadSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
			this.btnAddLeadSource.Enter += new System.EventHandler(this.Button_Enter);
			this.btnAddLeadSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
			this.btnAddLeadSource.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
			this.btnAddLeadSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_KeyDown);
		}

		private void control_Changed(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Editing || this.State == BoundaryState.Adding)
				this.IsDirty = true;
		}

		private void mtxtPhoneNumber_TextChanged(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Adding || this.State == BoundaryState.Editing)
			{
				if (!this.IsDirty)
					this.IsDirty = true;

				if (((MaskedTextBox)sender).MaskCompleted)
				{
					DataTable otherOwners;

					using (PhoneNumberController theController = new PhoneNumberController())
					{
						otherOwners = theController.GetOtherOwners(((MaskedTextBox)sender).Text, MyCustomer.ID);

						if (otherOwners.Rows.Count > 0)
						{
							DuplicatePhoneNumbers oForm = new DuplicatePhoneNumbers();

							oForm.OwnerList = otherOwners;
							oForm.PhoneNumber = ((MaskedTextBox)sender).Text;
							oForm.ShowDialog();

							if (oForm.DialogResult != DialogResult.OK)
								((MaskedTextBox)sender).Clear();
						}
					}
				}
			}
		}

		private void btnAddLeadSource_Click(object sender, EventArgs e)
		{
			if (leadSourceControls.lbxDepartments.SelectedItems.Count == 0)
			{
				int SelectedDepartmentID;
				int index = 0;
				Administration.Department.DepartmentSelect oForm = new Administration.Department.DepartmentSelect();
				oForm.SelectionMode = SelectionMode.MultiSimple;
				
				using (Administration.Department.DepartmentController theController = new rkcrm.Administration.Department.DepartmentController())
				{
					oForm.DataSource = theController.GetProfitCenters();
					oForm.DisplayMember = "name";
					oForm.ValueMember = "department_id";
					oForm.SelectedItems.Clear();
				}

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					foreach (object theSelected in oForm.SelectedItems)
					{
						SelectedDepartmentID = Convert.ToInt32(((DataRowView)theSelected)["department_id"]);

						while (index < NewLeadSources.Count)
							if (NewLeadSources[index].DepartmentID == SelectedDepartmentID)
								NewLeadSources.RemoveAt(index);
							else
								index++;

						index = 0;

						MyLeadSource.lbxDepartments.SelectedValue = SelectedDepartmentID;

						if (MyLeadSource.CommitChanges())
							NewLeadSources.Add(MyLeadSource.MySource.Copy());
					}

					MyLeadSource.MySource = new LeadSource();
					MyLeadSource.MySource.CustomerID = MyCustomer.ID;
				}
			}
			else
			{
				if (leadSourceControls.CommitChanges())
				{
					NewLeadSources.Add(leadSourceControls.MySource);
					leadSourceControls.MySource = new LeadSource();
					MyLeadSource.MySource.CustomerID = MyCustomer.ID;
				}
			}

			RefreshLeadSources();

			if (!IsDirty)
				IsDirty = true;
		}

		void lvwList_DoubleClick(object sender, EventArgs e)
		{
			if (relatedCustomerControls.lvwList.SelectedItems.Count > 0)
			{
				using (CustomerController theController = new CustomerController())
				{
					MyCustomer = theController.GetCustomer(Convert.ToInt32(relatedCustomerControls.lvwList.SelectedItems[0].Text));
				}
			}
		}

		#endregion


		#region Events

		public event EventHandler<EventArgs> MyCustomerChanged;
		protected virtual void OnMyCustomerChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = MyCustomerChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion


		#region Constructor

		public CustomerBoundary()
			: base()
		{
			InitializeComponent();
			AddressControls.txtZipcode.Click += new EventHandler(control_Changed);
			relatedCustomerControls.lvwList.DoubleClick += new EventHandler(lvwList_DoubleClick);

			LoadComboBoxes();
			NewLeadSources = new List<LeadSource>();
			if (thisUser.HomeDepartment.IsProfitCenter)
				gbxLeadSource.Text = "How did they hear about the " + thisUser.HomeDepartment.Name + " department?";
		}

		#endregion

	}
}
