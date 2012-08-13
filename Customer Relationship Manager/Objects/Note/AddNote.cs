using System;
using System.Windows.Forms;

namespace rkcrm.Objects.Note
{
	public partial class AddNote : Form
	{
		private const int FOLLOW_UP_ON_QUOTES = 5;
		private Quote.Quote associatedQuote;

		#region Properties

		internal Note MyNote
		{
			get { return noteControls.MyNote; }
			set 
			{ 
				noteControls.MyNote = value;

				if (noteControls.MyNote.ID == 0 && associatedQuote != null)
					SetDefaultValues();
			}
		}

		internal int SalesSupportID
		{
			get { return Convert.ToInt32(noteControls.cboSupport.SelectedValue); }
			set { noteControls.cboSupport.SelectedValue = value; }
		}

		internal int SalesRepID
		{
			get { return Convert.ToInt32(noteControls.cboSalesRep.SelectedValue); }
			set { noteControls.cboSalesRep.SelectedValue = value; }
		}

		internal int DepartmentID
		{
			get { return Convert.ToInt32(noteControls.cboDepartment.SelectedValue); }
			set { noteControls.cboDepartment.SelectedValue = value; }
		}

		internal int MethodID
		{
			get { return Convert.ToInt32(noteControls.cboMethod.SelectedValue); }
			set { noteControls.cboMethod.SelectedValue = value; }
		}

		internal int PurposeID
		{
			get { return Convert.ToInt32(noteControls.cboPurpose.SelectedValue); }
			set { noteControls.cboPurpose.SelectedValue = value; }
		}

		internal int ContactID
		{
			get { return Convert.ToInt32(noteControls.cboContact.SelectedValue); }
			set { noteControls.cboContact.SelectedValue = value; }
		}

		internal string ContactText
		{
			get { return noteControls.cboContact.Text; }
			set { noteControls.cboContact.Text = value; }
		}

		private void SetDefaultValues()
		{
			SalesRepID = associatedQuote.SalesRepID;
			SalesSupportID = associatedQuote.SalesSupportID;
			DepartmentID = associatedQuote.DepartmentID;
			MethodID = associatedQuote.MethodID;
			PurposeID = FOLLOW_UP_ON_QUOTES;
			ContactID = associatedQuote.ContactID;
		}

		#endregion


		#region Event Handlers

		private void btnDone_Click(object sender, EventArgs e)
		{
			if (noteControls.CommitChanges())
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

		public AddNote()
		{
			InitializeComponent();
		}

		internal AddNote(Quote.Quote theQuote)
		{
			InitializeComponent();

			associatedQuote = theQuote;
		}

		#endregion

	}
}
