using rkcrm.Base_Classes;

namespace rkcrm.Objects.Cross_Lead.Preview_Controls
{
	class ProjectPreview : PreviewBase
	{

		#region Variables

		internal System.Windows.Forms.Label txtZipCode;
		internal System.Windows.Forms.Label txtState;
		internal System.Windows.Forms.Label txtCity;
		internal System.Windows.Forms.Label txtApt;
		internal System.Windows.Forms.Label txtAddress;
		internal System.Windows.Forms.Label lblAddress;
		internal System.Windows.Forms.Label lblAptBldLot;
		internal System.Windows.Forms.Label lblState;
		internal System.Windows.Forms.Label lblZipCode;
		internal System.Windows.Forms.Label lblCity;
		internal System.Windows.Forms.Label txtPhone;
		internal System.Windows.Forms.Label lblPhone;
		internal System.Windows.Forms.Label txtContact;
		internal System.Windows.Forms.Label txtType;
		internal System.Windows.Forms.Label txtName;
		internal System.Windows.Forms.Label lblContact;
		internal System.Windows.Forms.Label lblType;
		internal System.Windows.Forms.Label lblName;

		#endregion


		#region Properties

		public string ProjectName
		{
			get { return txtName.Text; }
			set { txtName.Text = value; }
		}

		public string ProjectType
		{
			get { return txtType.Text; }
			set { txtType.Text = value; }
		}

		public string ContactName
		{
			get { return txtContact.Text; }
			set { txtContact.Text = value; }
		}

		public string PhoneNumber
		{
			get { return txtPhone.Text; }
			set { txtPhone.Text = value; }
		}

		public string Address
		{
			get { return txtAddress.Text; }
			set { txtAddress.Text = value; }
		}

		public string Apt
		{
			get { return txtApt.Text; }
			set { txtApt.Text = value; }
		}

		public string City
		{
			get { return txtCity.Text; }
			set { txtCity.Text = value; }
		}

		public string State
		{
			get { return txtState.Text; }
			set { txtState.Text = value; }
		}

		public string ZipCode
		{
			get { return txtZipCode.Text; }
			set { txtZipCode.Text = value; }
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.txtZipCode = new System.Windows.Forms.Label();
			this.txtState = new System.Windows.Forms.Label();
			this.txtCity = new System.Windows.Forms.Label();
			this.txtApt = new System.Windows.Forms.Label();
			this.txtAddress = new System.Windows.Forms.Label();
			this.lblAddress = new System.Windows.Forms.Label();
			this.lblAptBldLot = new System.Windows.Forms.Label();
			this.lblState = new System.Windows.Forms.Label();
			this.lblZipCode = new System.Windows.Forms.Label();
			this.lblCity = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.Label();
			this.lblPhone = new System.Windows.Forms.Label();
			this.txtContact = new System.Windows.Forms.Label();
			this.txtType = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.Label();
			this.lblContact = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtZipCode
			// 
			this.txtZipCode.BackColor = System.Drawing.Color.White;
			this.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtZipCode.Location = new System.Drawing.Point(407, 151);
			this.txtZipCode.Name = "txtZipCode";
			this.txtZipCode.Size = new System.Drawing.Size(65, 20);
			this.txtZipCode.TabIndex = 84;
			this.txtZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtState
			// 
			this.txtState.BackColor = System.Drawing.Color.White;
			this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtState.Location = new System.Drawing.Point(372, 151);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(29, 20);
			this.txtState.TabIndex = 83;
			this.txtState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCity
			// 
			this.txtCity.BackColor = System.Drawing.Color.White;
			this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtCity.Location = new System.Drawing.Point(267, 151);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(99, 20);
			this.txtCity.TabIndex = 82;
			this.txtCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtApt
			// 
			this.txtApt.BackColor = System.Drawing.Color.White;
			this.txtApt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtApt.Location = new System.Drawing.Point(211, 151);
			this.txtApt.Name = "txtApt";
			this.txtApt.Size = new System.Drawing.Size(50, 20);
			this.txtApt.TabIndex = 81;
			this.txtApt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAddress
			// 
			this.txtAddress.BackColor = System.Drawing.Color.White;
			this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtAddress.Location = new System.Drawing.Point(8, 151);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(197, 20);
			this.txtAddress.TabIndex = 80;
			this.txtAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.Location = new System.Drawing.Point(5, 134);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblAddress.Size = new System.Drawing.Size(76, 13);
			this.lblAddress.TabIndex = 79;
			this.lblAddress.Text = "Street Address";
			// 
			// lblAptBldLot
			// 
			this.lblAptBldLot.AutoSize = true;
			this.lblAptBldLot.Location = new System.Drawing.Point(208, 134);
			this.lblAptBldLot.Name = "lblAptBldLot";
			this.lblAptBldLot.Size = new System.Drawing.Size(53, 13);
			this.lblAptBldLot.TabIndex = 78;
			this.lblAptBldLot.Text = "Apt/Lot #";
			// 
			// lblState
			// 
			this.lblState.AutoSize = true;
			this.lblState.Location = new System.Drawing.Point(369, 134);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(32, 13);
			this.lblState.TabIndex = 77;
			this.lblState.Text = "State";
			// 
			// lblZipCode
			// 
			this.lblZipCode.AutoSize = true;
			this.lblZipCode.Location = new System.Drawing.Point(404, 134);
			this.lblZipCode.Name = "lblZipCode";
			this.lblZipCode.Size = new System.Drawing.Size(50, 13);
			this.lblZipCode.TabIndex = 76;
			this.lblZipCode.Text = "Zip Code";
			// 
			// lblCity
			// 
			this.lblCity.AutoSize = true;
			this.lblCity.Location = new System.Drawing.Point(264, 134);
			this.lblCity.Name = "lblCity";
			this.lblCity.Size = new System.Drawing.Size(24, 13);
			this.lblCity.TabIndex = 75;
			this.lblCity.Text = "City";
			// 
			// txtPhone
			// 
			this.txtPhone.BackColor = System.Drawing.Color.White;
			this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPhone.Location = new System.Drawing.Point(163, 54);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(98, 20);
			this.txtPhone.TabIndex = 74;
			this.txtPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPhone
			// 
			this.lblPhone.AutoSize = true;
			this.lblPhone.Location = new System.Drawing.Point(160, 38);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(78, 13);
			this.lblPhone.TabIndex = 73;
			this.lblPhone.Text = "Phone Number";
			// 
			// txtContact
			// 
			this.txtContact.BackColor = System.Drawing.Color.White;
			this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtContact.Location = new System.Drawing.Point(8, 54);
			this.txtContact.Name = "txtContact";
			this.txtContact.Size = new System.Drawing.Size(149, 20);
			this.txtContact.TabIndex = 72;
			this.txtContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtType
			// 
			this.txtType.BackColor = System.Drawing.Color.White;
			this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtType.Location = new System.Drawing.Point(8, 100);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(149, 20);
			this.txtType.TabIndex = 71;
			this.txtType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtName
			// 
			this.txtName.BackColor = System.Drawing.Color.White;
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtName.Location = new System.Drawing.Point(163, 100);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(267, 20);
			this.txtName.TabIndex = 70;
			this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblContact
			// 
			this.lblContact.AutoSize = true;
			this.lblContact.Location = new System.Drawing.Point(5, 38);
			this.lblContact.Name = "lblContact";
			this.lblContact.Size = new System.Drawing.Size(44, 13);
			this.lblContact.TabIndex = 69;
			this.lblContact.Text = "Contact";
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.Location = new System.Drawing.Point(5, 84);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(67, 13);
			this.lblType.TabIndex = 68;
			this.lblType.Text = "Project Type";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(160, 84);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(71, 13);
			this.lblName.TabIndex = 67;
			this.lblName.Text = "Project Name";
			// 
			// ProjectPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.txtZipCode);
			this.Controls.Add(this.txtState);
			this.Controls.Add(this.txtCity);
			this.Controls.Add(this.txtApt);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.lblAddress);
			this.Controls.Add(this.lblAptBldLot);
			this.Controls.Add(this.lblState);
			this.Controls.Add(this.lblZipCode);
			this.Controls.Add(this.lblCity);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.lblPhone);
			this.Controls.Add(this.txtContact);
			this.Controls.Add(this.txtType);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lblContact);
			this.Controls.Add(this.lblType);
			this.Controls.Add(this.lblName);
			this.ExpandedHeight = 185;
			this.Name = "ProjectPreview";
			this.Size = new System.Drawing.Size(605, 185);
			this.Title = "Project";
			this.Controls.SetChildIndex(this.lblName, 0);
			this.Controls.SetChildIndex(this.lblType, 0);
			this.Controls.SetChildIndex(this.lblContact, 0);
			this.Controls.SetChildIndex(this.txtName, 0);
			this.Controls.SetChildIndex(this.txtType, 0);
			this.Controls.SetChildIndex(this.txtContact, 0);
			this.Controls.SetChildIndex(this.lblPhone, 0);
			this.Controls.SetChildIndex(this.txtPhone, 0);
			this.Controls.SetChildIndex(this.lblCity, 0);
			this.Controls.SetChildIndex(this.lblZipCode, 0);
			this.Controls.SetChildIndex(this.lblState, 0);
			this.Controls.SetChildIndex(this.lblAptBldLot, 0);
			this.Controls.SetChildIndex(this.lblAddress, 0);
			this.Controls.SetChildIndex(this.txtAddress, 0);
			this.Controls.SetChildIndex(this.txtApt, 0);
			this.Controls.SetChildIndex(this.txtCity, 0);
			this.Controls.SetChildIndex(this.txtState, 0);
			this.Controls.SetChildIndex(this.txtZipCode, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void Clear()
		{
			Title = "Project";

			txtName.Text = string.Empty;
			txtContact.Text = string.Empty;
			txtType.Text = string.Empty;
			txtAddress.Text = string.Empty;
			txtApt.Text = string.Empty;
			txtCity.Text = string.Empty;
			txtPhone.Text = string.Empty;
			txtState.Text = string.Empty;
			txtZipCode.Text = string.Empty;
		}

		public void LoadData(Project.Project theProject)
		{
			Contact.Contact theContact = theProject.GetContact();

			txtAddress.Text = theProject.Address;
			txtApt.Text = theProject.Apt;
			txtCity.Text = theProject.City;
			txtContact.Text = theContact.FullName;
			txtName.Text = theProject.Name;
			txtPhone.Text = theContact.MyPhoneNumbers[0].Number;
			txtState.Text = theProject.State;
			txtType.Text = theProject.GetProjectType().Name;
			txtZipCode.Text = theProject.ZipCode.ToString(); ;
		}

		#endregion


		#region Constructors

		public ProjectPreview()
			: base()
		{
			InitializeComponent();

			Clear();
		}

		#endregion

	}
}
