using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Administration.ZipCode;

namespace rkcrm.Objects.Customer.Preview_Controls
{
	class AddressPreview : PreviewBase
	{

		#region Varibales

		internal System.Windows.Forms.Label lblAddress;
		internal System.Windows.Forms.TextBox txtAddress;
		internal System.Windows.Forms.TextBox txtAptBldNum;
		internal System.Windows.Forms.Label lblAptBldNum;
		internal System.Windows.Forms.TextBox txtCity;
		internal System.Windows.Forms.Label lblCity;
		internal System.Windows.Forms.Label lblZipcode;
		internal System.Windows.Forms.TextBox txtState;
		internal System.Windows.Forms.TextBox txtZipcode;
		internal System.Windows.Forms.Label lblState;

		private bool bolIsDirty;

		#endregion


		#region Properties

		public bool IsDirty
		{
			get { return bolIsDirty; }
			set 
			{ 
				bolIsDirty = value;
				OnIsDirtyChanged(new EventArgs());
			}
		}

		#endregion


		#region Event Handlers

		private void txtZipcode_TextChanged(object sender, EventArgs e)
		{
			if (txtZipcode.Text.Length == 5)
			{
				if (!IsInteger(txtZipcode.Text))
					MessageBox.Show("The zip code must be a 5 digit number.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				else
				{
					ZipCode currentZip;

					using (ZipcodeController theController = new ZipcodeController())
					{
						currentZip = theController.GetZipCode(txtZipcode.Text, true);
					}

					if (currentZip.Code > 0)
					{
						txtState.Text = currentZip.Abbreviation;
						txtCity.Text = currentZip.City;
					}
				}
			}
		}

		private void control_Changed(object sender, EventArgs e)
		{
			if (!IsDirty)
				IsDirty = true;
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.lblAddress = new System.Windows.Forms.Label();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.txtAptBldNum = new System.Windows.Forms.TextBox();
			this.lblAptBldNum = new System.Windows.Forms.Label();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.lblCity = new System.Windows.Forms.Label();
			this.lblZipcode = new System.Windows.Forms.Label();
			this.txtState = new System.Windows.Forms.TextBox();
			this.txtZipcode = new System.Windows.Forms.TextBox();
			this.lblState = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.Location = new System.Drawing.Point(5, 35);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(76, 13);
			this.lblAddress.TabIndex = 54;
			this.lblAddress.Text = "Street Address";
			// 
			// txtAddress
			// 
			this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAddress.Location = new System.Drawing.Point(8, 51);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(269, 20);
			this.txtAddress.TabIndex = 49;
			this.txtAddress.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// txtAptBldNum
			// 
			this.txtAptBldNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAptBldNum.Location = new System.Drawing.Point(283, 51);
			this.txtAptBldNum.Name = "txtAptBldNum";
			this.txtAptBldNum.Size = new System.Drawing.Size(56, 20);
			this.txtAptBldNum.TabIndex = 50;
			this.txtAptBldNum.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblAptBldNum
			// 
			this.lblAptBldNum.AutoSize = true;
			this.lblAptBldNum.Location = new System.Drawing.Point(280, 35);
			this.lblAptBldNum.Name = "lblAptBldNum";
			this.lblAptBldNum.Size = new System.Drawing.Size(53, 13);
			this.lblAptBldNum.TabIndex = 55;
			this.lblAptBldNum.Text = "Apt/Bld #";
			// 
			// txtCity
			// 
			this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCity.Location = new System.Drawing.Point(8, 94);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(125, 20);
			this.txtCity.TabIndex = 51;
			this.txtCity.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblCity
			// 
			this.lblCity.AutoSize = true;
			this.lblCity.Location = new System.Drawing.Point(5, 78);
			this.lblCity.Name = "lblCity";
			this.lblCity.Size = new System.Drawing.Size(24, 13);
			this.lblCity.TabIndex = 56;
			this.lblCity.Text = "City";
			// 
			// lblZipcode
			// 
			this.lblZipcode.AutoSize = true;
			this.lblZipcode.Location = new System.Drawing.Point(174, 78);
			this.lblZipcode.Name = "lblZipcode";
			this.lblZipcode.Size = new System.Drawing.Size(50, 13);
			this.lblZipcode.TabIndex = 58;
			this.lblZipcode.Text = "Zip Code";
			// 
			// txtState
			// 
			this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtState.Location = new System.Drawing.Point(139, 94);
			this.txtState.MaxLength = 2;
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(32, 20);
			this.txtState.TabIndex = 52;
			this.txtState.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// txtZipcode
			// 
			this.txtZipcode.Location = new System.Drawing.Point(177, 94);
			this.txtZipcode.MaxLength = 5;
			this.txtZipcode.Name = "txtZipcode";
			this.txtZipcode.Size = new System.Drawing.Size(100, 20);
			this.txtZipcode.TabIndex = 53;
			this.txtZipcode.TextChanged += new System.EventHandler(this.txtZipcode_TextChanged);
			// 
			// lblState
			// 
			this.lblState.AutoSize = true;
			this.lblState.Location = new System.Drawing.Point(136, 78);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(32, 13);
			this.lblState.TabIndex = 57;
			this.lblState.Text = "State";
			// 
			// AddressPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.lblAddress);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.txtAptBldNum);
			this.Controls.Add(this.lblAptBldNum);
			this.Controls.Add(this.txtCity);
			this.Controls.Add(this.lblCity);
			this.Controls.Add(this.lblZipcode);
			this.Controls.Add(this.txtState);
			this.Controls.Add(this.txtZipcode);
			this.Controls.Add(this.lblState);
			this.ExpandedHeight = 125;
			this.Name = "AddressPreview";
			this.Size = new System.Drawing.Size(605, 125);
			this.Title = "Address";
			this.Controls.SetChildIndex(this.lblState, 0);
			this.Controls.SetChildIndex(this.txtZipcode, 0);
			this.Controls.SetChildIndex(this.txtState, 0);
			this.Controls.SetChildIndex(this.lblZipcode, 0);
			this.Controls.SetChildIndex(this.lblCity, 0);
			this.Controls.SetChildIndex(this.txtCity, 0);
			this.Controls.SetChildIndex(this.lblAptBldNum, 0);
			this.Controls.SetChildIndex(this.txtAptBldNum, 0);
			this.Controls.SetChildIndex(this.txtAddress, 0);
			this.Controls.SetChildIndex(this.lblAddress, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

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

		#endregion


		#region Events

		public event EventHandler<EventArgs> IsDirtyChanged;
		protected virtual void OnIsDirtyChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = IsDirtyChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion


		#region Constructor

		public AddressPreview()
			: base()
		{
			InitializeComponent();
			bolIsDirty = false;
		}

		#endregion


	}
}
