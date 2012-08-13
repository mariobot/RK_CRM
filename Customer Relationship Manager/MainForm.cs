using System;
using System.Threading;
using System.Windows.Forms;
using rkcrm.Demonstration;
using rkcrm.Reminder_Module;

namespace rkcrm
{
    public partial class MainForm : Form
    {
   
        #region Variables

        private FormModes myMode = FormModes.Live;
        
        #endregion


        #region Properties

        public FormModes Mode
        {
            get { return myMode; }
            set
            {
                myMode = value;

                if (MySettings.Mode != MySettings.applicationMode.Prototype)
                    if (myMode == FormModes.Live)
                        MySettings.Mode = MySettings.applicationMode.Live;
                    else
                        MySettings.Mode = MySettings.applicationMode.Demonstration;

            }
        }

        #endregion


        #region Methods

		#endregion


		#region EventHandlers

		private void tsmDemoMode_Click(object sender, EventArgs e)
		{
			if (myMode == FormModes.Live)
			{
                myMode = FormModes.Demonstration;
				tsmDemoMode.Image = global::rkcrm.Properties.Resources.Stop_Icon_16;
				tsmDemoMode.Text = "Demonstration Mode [Off]";
                DemoForm oFrom = new DemoForm();
                oFrom.Show();
			}
			else
			{
				myMode = FormModes.Live;
				tsmDemoMode.Image = global::rkcrm.Properties.Resources.Play_Icon_16;
				tsmDemoMode.Text = "Demonstration Mode [On]";
                thisUser.Refresh();

                DemoForm theDemo = null;

                foreach (Form oForm in Application.OpenForms)
                {
                    if (oForm is DemoForm)
                        theDemo = (DemoForm)oForm;
                }

                if (theDemo != null)
                    theDemo.Close();

			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
            //Show splash screen while form is loading
            this.Hide();
            bool isDone = false;
            ThreadPool.QueueUserWorkItem((x) =>
                {
                    using (SplashScreen oForm = new SplashScreen(true))
                    {
                        oForm.Show();
                        while (!isDone)
                            Application.DoEvents();
                        oForm.Close();
                    }
                });

            //minimum time to show splash screen
            Thread.Sleep(2000);

			try
			{
				//This populates the static user class that represents the user curently logged in
				tslCurrentUser.Text += thisUser.FullName;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			//Set Form title
			this.Text = MySettings.AppTitle;

            isDone = true;
            this.Show();
		}

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmReminders_Click(object sender, EventArgs e)
        {
            RemindersForm theForm = new RemindersForm();
            theForm.Show();
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            SplashScreen oForm = new SplashScreen(false);
            oForm.Show();
        }

        private void tsmCRMHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show((new NotImplementedException()).Message);
        }

		private void MainForm_Shown(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
			this.Activate();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (theNavigationScreen.CurrentScreen.IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						// If attempt fails then don't move away
						if (!theNavigationScreen.CurrentScreen.Save())
						{
							e.Cancel = true;
						}
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
					default:
						break;
				}
			}
			else
				e.Cancel = false;
		}

		private void tsmCrossLeads_Click(object sender, EventArgs e)
		{
			rkcrm.Objects.Cross_Lead.CrossLeadAssignments oForm = new rkcrm.Objects.Cross_Lead.CrossLeadAssignments();
			oForm.Show();
		}

		#endregion


		#region Constructors

		public MainForm()
			{
				InitializeComponent();
			}

		#endregion


        #region Enumerations

        public enum FormModes { Live, Demonstration };

        #endregion

    }
}
