using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace rkcrm.Base_Classes
{
	public partial class BoundaryBase : UserControl
	{

		#region Variables

		private bool bolIsDirty;
		private BoundaryState myState;

		#endregion


		#region Properties

		/// <summary>
		/// Gets or sets the state of this boudary class
		/// </summary>
		internal BoundaryState State
		{
			get { return myState; }
			set 
			{ 
				myState = value;

				if (value == BoundaryState.Adding)
					pnlHeader.BackColor = Color.DarkOliveGreen;
				else
					pnlHeader.BackColor = SystemColors.AppWorkspace;

				OnStateChanged(new EventArgs());
			}
		}

		/// <summary>
		/// Gets or sets the tile of this object
		/// </summary>
		[Category("Custom Properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public String Title
		{
			get { return this.lblTitle.Text; }
			set { this.lblTitle.Text = value; }
		}

		/// <summary>
		/// Sets the Created date in the title bar
		/// </summary>
		public String ObjectCreated
		{
			set { this.DlblCreated.Text = value; }
		}

		/// <summary>
		/// Sets the Updated date in the title bar
		/// </summary>
		public String ObjectUpdated
		{
			set { this.DlblUpdated.Text = value; }
		}

		/// <summary>
		/// Sets the Created By name in the title bar
		/// </summary>
		public String ObjectCreatedBy
		{
			set { this.DlblCreatedBy.Text = value; }
		}

		/// <summary>
		/// Sets the Updated By name in the title bar
		/// </summary>
		public String ObjectUpdatedBy
		{
			set { this.DlblUpdatedBy.Text = value; }
		}

		/// <summary>
		/// Gets or sets the value that determines whether the title bar is visible
		/// </summary>
        [Category("Custom Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool TitleBarVisible
        {
            get { return pnlHeader.Visible; }
            set 
            { 
                pnlHeader.Visible = value;

                if (pnlHeader.Visible)
                    this.Height += pnlHeader.Height;
                else
                    this.Height -= pnlHeader.Height;
            }
        }

		/// <summary>
		/// Gets or sets the value that determines whether the record history is visible
		/// </summary>
		[Category("Custom Properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public bool ChangeHistoryVisible
		{
			get { return pnlHistory.Visible; }
			set { pnlHistory.Visible = value; }
		}

		/// <summary>
		/// Gets or sets the value that determines that something has changed
		/// </summary>
		public bool IsDirty
		{
			get { return bolIsDirty; }
			protected set 
			{ 
				bolIsDirty = value;
				OnIsDirtyChanged(new EventArgs());
			}
		}

		#endregion


		#region Methods

		/// <summary>
		/// CLears the screen of all data
		/// </summary>
		protected void Clear()
		{
			DlblCreated.Text = string.Empty;
			DlblCreatedBy.Text = string.Empty;
			DlblUpdated.Text = string.Empty;
			DlblUpdatedBy.Text = string.Empty;
		}

		/// <summary>
		/// Determines whether the text in the combo box is found in the ObjectCollection
		/// </summary>
		/// <param name="oControl"></param>
		/// <returns></returns>
		protected bool IsSelectionValid(ComboBox oControl)
		{
			bool isFound = false;

			foreach (object oItem in oControl.Items)
				if (oControl.Text == ((DataRowView)oItem)[oControl.DisplayMember].ToString())
					isFound = true;

			return isFound;
		}

		protected bool IsDateValid(string theDate)
		{
			try
			{
				DateTime newDate = Convert.ToDateTime(theDate);

				if (newDate >= DateTime.Today)
					return true;
				else
					return false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		protected string FormatPercent(decimal Number)
		{
			try
			{
				decimal percent;

				if (Number <= 1)
					percent = Number * 100;
				else
					percent = Number;

				return Convert.ToInt32(percent).ToString() + "%";

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return Number.ToString();
			}
		}

		protected bool HasLeadSource(int CustomerID, int DepartmentID)
		{
			bool result = false;

			if (CustomerID > 0)
				using (rkcrm.Objects.Customer.Lead_Source.LeadSourceController theController = new rkcrm.Objects.Customer.Lead_Source.LeadSourceController())
				{
					result = theController.HasLeadSource(CustomerID, DepartmentID);
				}
			else
			{
				Control me = this;

				while (me.Parent != null && !(me is rkcrm.Objects.NewCustomerWizard))
					me = me.Parent;

				result = me is rkcrm.Objects.NewCustomerWizard;
			}

			return result;
		}

		/// <summary>
		/// Finds the currently loaded customer in the CRM and refreshes its screen if it exists
		/// </summary>
		protected void RefreshCustomer()
		{
			MainForm theFrom = null;

			foreach (Form oForm in Application.OpenForms)
				if (oForm is MainForm)
					theFrom = (MainForm)oForm;

			if (theFrom != null)
				foreach (ScreenBase oScreen in theFrom.theNavigationScreen.OpenScreens)
					if (oScreen is Objects.Customer.CustomerScreen)
						oScreen.RefreshData();
		}

		#endregion


		#region Event Handlers

		protected void Button_MouseEnter(object sender, EventArgs e)
		{
			Button theButton = (Button)sender;

			int shift = Math.Abs((theButton.Size.Height - 18) / 2);

			theButton.Size = new System.Drawing.Size(18, 18);
			theButton.Location = new System.Drawing.Point(theButton.Location.X - shift, theButton.Location.Y - shift);
		}

		protected void Button_MouseLeave(object sender, EventArgs e)
		{
			Button theButton = (Button)sender;

			int shift = Math.Abs((theButton.Size.Height - 16) / 2);

			if (theButton.Size.Height > 16)
				theButton.Location = new System.Drawing.Point(theButton.Location.X + shift, theButton.Location.Y + shift);
			else
				theButton.Location = new System.Drawing.Point(theButton.Location.X - shift, theButton.Location.Y - shift);

			theButton.Size = new System.Drawing.Size(16, 16);
		}

		protected void Button_MouseDown(object sender, MouseEventArgs e)
		{
			Button theButton = (Button)sender;

			int shift = Math.Abs((theButton.Size.Height - 14) / 2);

			theButton.Size = new System.Drawing.Size(14, 14);
			theButton.Location = new System.Drawing.Point(theButton.Location.X + shift, theButton.Location.Y + shift);
		}

		protected void Button_MouseUp(object sender, MouseEventArgs e)
		{
			Button theButton = (Button)sender;

			int shift = Math.Abs((theButton.Size.Height - 16) / 2);

			if (theButton.Size.Height > 16)
				theButton.Location = new System.Drawing.Point(theButton.Location.X + shift, theButton.Location.Y + shift);
			else
				theButton.Location = new System.Drawing.Point(theButton.Location.X - shift, theButton.Location.Y - shift);

			theButton.Size = new System.Drawing.Size(16, 16);
		}

		protected void Button_Enter(object sender, EventArgs e)
		{
			Button_MouseEnter(sender, e);
		}

		protected void Button_Leave(object sender, EventArgs e)
		{
			Button_MouseLeave(sender, e);
		}

		protected void Button_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Button theButton = (Button)sender;

				int shift = Math.Abs((theButton.Size.Height - 14) / 2);

				theButton.Size = new System.Drawing.Size(14, 14);
				theButton.Location = new System.Drawing.Point(theButton.Location.X + shift, theButton.Location.Y + shift);
			}
		}

		protected void Button_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Button theButton = (Button)sender;

				int shift = Math.Abs((theButton.Size.Height - 16) / 2);

				if (theButton.Size.Height > 16)
					theButton.Location = new System.Drawing.Point(theButton.Location.X + shift, theButton.Location.Y + shift);
				else
					theButton.Location = new System.Drawing.Point(theButton.Location.X - shift, theButton.Location.Y - shift);

				theButton.Size = new System.Drawing.Size(16, 16);
			}
		}

		#endregion



		#region Constructor

		public BoundaryBase()
		{
			InitializeComponent();
		}

		#endregion


		#region Enumerations

		internal enum BoundaryState { Adding, Editing, Searching, Loading };

		#endregion


		#region Custom Events

		public event EventHandler<EventArgs> StateChanged;
		protected virtual void OnStateChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = StateChanged;

			if (handler != null)
				handler(this, e);
		}

		public event EventHandler<EventArgs> IsDirtyChanged;
		protected virtual void OnIsDirtyChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = IsDirtyChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion

	}
}
