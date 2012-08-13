using System;
using System.Windows.Forms;

namespace rkcrm.Objects.Contact
{
	public partial class AddContact : Form
	{
		#region Properties

		internal Contact MyContact
		{
			get { return contactControls.MyContact; }
			set { contactControls.MyContact = value; }
		}

		#endregion


		#region Methods

		#endregion


		#region Event Handlers

		private void btnDone_Click(object sender, EventArgs e)
		{
			if (contactControls.Save())
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion


		#region Constructor

		public AddContact()
		{
			InitializeComponent();
		}

		#endregion

	}
}
