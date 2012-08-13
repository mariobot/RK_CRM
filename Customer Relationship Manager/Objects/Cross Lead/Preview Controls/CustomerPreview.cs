using rkcrm.Base_Classes;

namespace rkcrm.Objects.Cross_Lead.Preview_Controls
{
	class CustomerPreview : PreviewBase
	{

		#region Variables

		internal System.Windows.Forms.Label lblPhone;
		internal System.Windows.Forms.Label lblType;
		internal System.Windows.Forms.Label lblName;
		internal System.Windows.Forms.Label lblPhoneNumber;
		internal System.Windows.Forms.Label lblCustomerType;
		internal System.Windows.Forms.Label lblCustomerName;

		#endregion


		#region Properties

		public string CustomerName
		{
			get { return lblName.Text; }
			set { lblName.Text = value; }
		}

		public string CustomerType
		{
			get { return lblType.Text; }
			set { lblType.Text = value; }
		}

		public string PhoneNumber
		{
			get { return lblPhone.Text; }
			set { lblPhone.Text = value; }
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.lblPhone = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblPhoneNumber = new System.Windows.Forms.Label();
			this.lblCustomerType = new System.Windows.Forms.Label();
			this.lblCustomerName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblPhone
			// 
			this.lblPhone.BackColor = System.Drawing.Color.White;
			this.lblPhone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPhone.Location = new System.Drawing.Point(488, 52);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(99, 20);
			this.lblPhone.TabIndex = 32;
			this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblType
			// 
			this.lblType.BackColor = System.Drawing.Color.White;
			this.lblType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblType.Location = new System.Drawing.Point(21, 52);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(149, 20);
			this.lblType.TabIndex = 31;
			this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblName
			// 
			this.lblName.BackColor = System.Drawing.Color.White;
			this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblName.Location = new System.Drawing.Point(176, 52);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(306, 20);
			this.lblName.TabIndex = 30;
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPhoneNumber
			// 
			this.lblPhoneNumber.AutoSize = true;
			this.lblPhoneNumber.Location = new System.Drawing.Point(485, 36);
			this.lblPhoneNumber.Name = "lblPhoneNumber";
			this.lblPhoneNumber.Size = new System.Drawing.Size(78, 13);
			this.lblPhoneNumber.TabIndex = 29;
			this.lblPhoneNumber.Text = "Phone Number";
			// 
			// lblCustomerType
			// 
			this.lblCustomerType.AutoSize = true;
			this.lblCustomerType.Location = new System.Drawing.Point(18, 36);
			this.lblCustomerType.Name = "lblCustomerType";
			this.lblCustomerType.Size = new System.Drawing.Size(78, 13);
			this.lblCustomerType.TabIndex = 28;
			this.lblCustomerType.Text = "Customer Type";
			// 
			// lblCustomerName
			// 
			this.lblCustomerName.AutoSize = true;
			this.lblCustomerName.Location = new System.Drawing.Point(173, 36);
			this.lblCustomerName.Name = "lblCustomerName";
			this.lblCustomerName.Size = new System.Drawing.Size(82, 13);
			this.lblCustomerName.TabIndex = 27;
			this.lblCustomerName.Text = "Customer Name";
			// 
			// CustomerPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.lblPhone);
			this.Controls.Add(this.lblType);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.lblPhoneNumber);
			this.Controls.Add(this.lblCustomerType);
			this.Controls.Add(this.lblCustomerName);
			this.ExpandedHeight = 85;
			this.Name = "CustomerPreview";
			this.Size = new System.Drawing.Size(605, 85);
			this.Title = "Customer";
			this.Controls.SetChildIndex(this.lblCustomerName, 0);
			this.Controls.SetChildIndex(this.lblCustomerType, 0);
			this.Controls.SetChildIndex(this.lblPhoneNumber, 0);
			this.Controls.SetChildIndex(this.lblName, 0);
			this.Controls.SetChildIndex(this.lblType, 0);
			this.Controls.SetChildIndex(this.lblPhone, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void Clear()
		{
			Title = "Customer";

			lblName.Text = string.Empty;
			lblType.Text = string.Empty;
			lblPhone.Text = string.Empty;
		}

		public void LoadData(Customer.Customer theCustomer)
		{
			CustomerName = theCustomer.Name;
			CustomerType = theCustomer.GetCustomerType().Name;
			PhoneNumber = theCustomer.PhoneNumber;
		}

		#endregion	


		#region Constructors

		public CustomerPreview()
			: base()
		{
			InitializeComponent();

			Clear();
		}

		#endregion
	}
}
