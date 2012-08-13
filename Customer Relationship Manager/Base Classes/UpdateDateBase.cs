using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace rkcrm.Base_Classes
{
	public partial class UpdateDateBase : Form
	{
		private bool bolIsDirty = false;

		#region Properties

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Custom Properties")]
		public string Title
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}

		public string CustomerName
		{
			get { return DlblCustomer.Text; }
			set { DlblCustomer.Text = value; }
		}

		public string Date
		{
			get { return mtxtDate.Text; }
			set { mtxtDate.Text = value; }
		}

		protected bool IsDirty
		{
			get { return bolIsDirty; }
			set { bolIsDirty = value; }
		}

		#endregion


		#region Event Handlers

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void UpdateDateBase_Load(object sender, EventArgs e)
		{
			IsDirty = false;
		}

		private void mtxtDate_TextChanged(object sender, EventArgs e)
		{
			if (IsDirty == false)
				IsDirty = true;
		}

		#endregion


		#region Constructor

		public UpdateDateBase()
		{
			InitializeComponent();
		}

		#endregion

	}
}
