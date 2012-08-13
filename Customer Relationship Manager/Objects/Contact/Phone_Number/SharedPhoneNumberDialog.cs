using System;
using System.Windows.Forms;

namespace rkcrm.Objects.Contact.Phone_Number
{
	public partial class SharedPhoneNumberDialog : Form
	{
		public SharedPhoneNumberDialog()
		{
			InitializeComponent();
		}

		private void btnYes_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}

		private void btnNo_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}

	}
}
