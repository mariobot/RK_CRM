using System;
using System.Windows.Forms;
using rkcrm.Reminder_Module;

namespace rkcrm.Base_Classes
{
    public partial class ScreenBase : UserControl
    {
        #region Variables

        private bool bolIsDisposable = true;

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the value that determines whether this screen can be disposed of safely
        /// </summary>
        public bool IsDisposable
        {
            get { return bolIsDisposable; }
            set { bolIsDisposable = value; }
        }

		public virtual bool IsDirty
		{
			get { return false; }
		}

        #endregion


        #region Methods

        public void Clear()
        {
            bolIsDisposable = true;
        }

        public new void Dispose()
        {
            base.Dispose();
			tsmActions.Dispose();
        }

        /// <summary>
        /// Gets the rkcrm.Navigation.NavigationScreen object that contains this control
        /// </summary>
        /// <returns></returns>
        public Navigation.NavigationScreen GetNavigationScreen()
        {
            Control myNavigation = this;

            //Find the navigation screen that contains this button
            while (!(myNavigation is Navigation.NavigationScreen) && myNavigation.Parent != null)
                myNavigation = myNavigation.Parent;

            if (myNavigation is Navigation.NavigationScreen)
                return (Navigation.NavigationScreen)myNavigation;
            else
                return null;
        }

        /// <summary>
        /// Gets the rkcrm.MainForm object that contains this control
        /// </summary>
        /// <returns></returns>
        public MainForm GetMainForm()
        {
            Control myMainForm = this;

            while (!(myMainForm is MainForm) && myMainForm.Parent != null)
                myMainForm = myMainForm.Parent;

            if (myMainForm is MainForm)
                return (MainForm)myMainForm;
            else
                return null;
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

		protected string FormatPercent(string Number)
		{
			try
			{
				if (!string.IsNullOrEmpty(Number))
				{
					decimal percent = Convert.ToDecimal(Number);

					if (percent <= 1)
						percent = percent * 100;

					return Convert.ToInt32(percent).ToString() + "%";
				}
				else
					return Number;

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return Number.ToString();
			}
		}

		public virtual bool Save()
		{
			return true;
		}

		public virtual void RefreshData()
		{
		}

		public void RefreshReminders()
		{
			RemindersForm theForm = null;
			Navigation.NavigationScreen myNavigation = GetNavigationScreen();

			foreach (Form oForm in Application.OpenForms)
				if (oForm is RemindersForm)
					theForm = (RemindersForm)oForm;

			if (theForm != null)
				theForm.RefreshData();

			if (!(this is Objects.Note.NoteScreen))
				foreach (ScreenBase oScreen in myNavigation.OpenScreens)
					if (oScreen is Objects.Note.NoteScreen)
						oScreen.RefreshData();

			if(!(this is Objects.Project.ProjectScreen))
				foreach (ScreenBase oScreen in myNavigation.OpenScreens)
					if (oScreen is Objects.Project.ProjectScreen)
						oScreen.RefreshData();
		}

        #endregion


        #region Event Handlers

        private void ScreenBase_Load(object sender, EventArgs e)
        {
            MainForm myForm = GetMainForm();

            //Add the Actions menu item to the main tool strip
			if (myForm != null)
				myForm.msMain.Items.Insert(3, tsmActions);

        }

        private void ScreenBase_DockChanged(object sender, EventArgs e)
        {
            //only show the screen's action options if the screen is in the foreground
            tsmActions.Visible = (this.Dock == DockStyle.Fill);
        }

        #endregion


        #region Constructor

        public ScreenBase()
        {
            InitializeComponent();
        }

        #endregion
    }
}
