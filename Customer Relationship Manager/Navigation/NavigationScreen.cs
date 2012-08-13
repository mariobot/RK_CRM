using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Base_Classes;

namespace rkcrm.Navigation
{
    public partial class NavigationScreen : UserControl
    {


        #region Variables

        private const int Highlighted = 0;
        private const int Pressed = 1;
        private int OriginalDistance;
        private ScreenBase sbCurrentScreen;

        private List<ScreenBase> lstOpenScreens = new List<ScreenBase>();

        #endregion


        #region Properties

        /// <summary>
        /// The UserControl that is currently in the foreground of this screen
        /// </summary>
        public ScreenBase CurrentScreen
        {
            get { return sbCurrentScreen; }
            set { sbCurrentScreen = value; }
        }

		/// <summary>
		/// Gets the list of screens currently in existance within this rkcrm.Navigation.NavigationScreen
		/// </summary>
		public List<ScreenBase> OpenScreens
		{
			get { return lstOpenScreens; }
		}

        #endregion

        
        #region Methods

        /// <summary>
        /// Navigates the user to the specified screen type
        /// </summary>
        /// <param name="ScreenType">System.Type of the screen the user wants to see in the foreground</param>
		public void NavigateTo(Type ScreenType)
		{
			if (CurrentScreen != null)
			{
				if (CurrentScreen.IsDirty)
				{
					switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
					{
						case DialogResult.Yes:
							// If attempt fails then don't move away
							if (CurrentScreen.Save())
							{
								CurrentScreen.RefreshData();
								GetNextScreen(ScreenType);
							}
							break;
						case DialogResult.Cancel:
							break;
						default:
							CurrentScreen.RefreshData();
							GetNextScreen(ScreenType);
							break;
					}
				}
				else
					GetNextScreen(ScreenType);
			}
			else
				GetNextScreen(ScreenType);

		}

		private void GetNextScreen(Type ScreenType)
		{
			ScreenBase lastScreen = CurrentScreen;
			CurrentScreen = null;

			int index = 0;
			//Determine if the desired screen already exists
			//and clean up the ScreenBase collection by removing any screens marked as disposable
			while (index < lstOpenScreens.Count)
			{
				if (lstOpenScreens[index].GetType().Equals(ScreenType))
					CurrentScreen = lstOpenScreens[index];
				else
					if (lstOpenScreens[index].IsDisposable && lstOpenScreens[index] != lastScreen)
						scMain.Panel2.Controls.Remove(lstOpenScreens[index]);

				index++;
			}

			if (CurrentScreen == null)
			{
				//if the screen was not found in the openScreens collection then create it
				CurrentScreen = (ScreenBase)ObjectFactory.GetObject(ScreenType);

				//add the new screen object to the openScreens collection
				if (CurrentScreen != null)
					this.scMain.Panel2.Controls.Add(CurrentScreen);
			}

			//if the current screen happens to be the screen already in the foreground, do nothing else
			if (lastScreen != CurrentScreen)
			{
				if (lastScreen != null)
				{
					if (lastScreen.IsDisposable)
						scMain.Panel2.Controls.Remove(lastScreen);
					else
					{
						lastScreen.Dock = DockStyle.None;
						lastScreen.Location = new Point(5000, 5000);
					}
				}

				CurrentScreen.Dock = DockStyle.Fill;
			}
		}

		private void ValidateSecurityAccess()
		{
			//pnlButtons.Controls[0] = btnAdministration
			//pnlButtons.Controls[1] = btnReports
			//pnlButtons.Controls[2] = btnCustomers
			//pnlButtons.Controls[3] = btnSearch

			//string text = string.Empty;
			//foreach (Control c in pnlButtons.Controls)
			//    text += "pnlButtons.Controls[" + pnlButtons.Controls.IndexOf(c) + "] = " + c.Name + "\r\n";
			//MessageBox.Show(text);

			// accessCode = 7 (0b0111) excludes btnAdministration
			// accessCode = 15 (0b1111) Access to all buttons

			int accessCode = 15;
			char[] charArray = Convert.ToString(accessCode, 2).PadLeft(pnlButtons.Controls.Count, '0').ToCharArray();
			int index = 0;

			foreach (Control oControl in pnlButtons.Controls)
			{
				oControl.Visible = charArray[index] == '0' ? false : true;
				index++;
			}

		}

		/// <summary>
		/// Clears and removes all ScreenBase objects from the OpenScreens collection regardless the value if IsDisposable
		/// </summary>
		public void ClearUnusedScreens()
		{
			int index = 0;

			while (index < OpenScreens.Count)
			{
				if (OpenScreens[index] != CurrentScreen)
					this.scMain.Panel2.Controls.Remove(OpenScreens[index]);
				else
					index++;
			}
		}

        #endregion


        #region Constructor

        public NavigationScreen()
        {
            InitializeComponent();

            pbxMaximize_1.MouseDown += new MouseEventHandler(pnlCollapsedNav_MouseDown);
            pbxMaximize_2.MouseDown += new MouseEventHandler(pnlCollapsedNav_MouseDown);
            pbxCollapsedTitle.MouseDown += new MouseEventHandler(pnlCollapsedNav_MouseDown);

            pbxMaximize_1.MouseEnter += new EventHandler(pnlCollapsedNav_MouseEnter);
            pbxMaximize_2.MouseEnter += new EventHandler(pnlCollapsedNav_MouseEnter);
            pbxCollapsedTitle.MouseEnter += new EventHandler(pnlCollapsedNav_MouseEnter);

            pbxMaximize_1.MouseLeave += new EventHandler(pnlCollapsedNav_MouseLeave);
            pbxMaximize_2.MouseLeave += new EventHandler(pnlCollapsedNav_MouseLeave);
            pbxCollapsedTitle.MouseLeave += new EventHandler(pnlCollapsedNav_MouseLeave);

            pbxMaximize_1.MouseUp += new MouseEventHandler(pnlCollapsedNav_MouseUp);
            pbxMaximize_2.MouseUp += new MouseEventHandler(pnlCollapsedNav_MouseUp);
            pbxCollapsedTitle.MouseUp += new MouseEventHandler(pnlCollapsedNav_MouseUp);

            btnAdministration.Click += new EventHandler(NavigationButton_Click);
            btnCustomer.Click += new EventHandler(NavigationButton_Click);
            btnReports.Click += new EventHandler(NavigationButton_Click);
            btnSearch.Click += new EventHandler(NavigationButton_Click);

			ValidateSecurityAccess();
        }

        #endregion


        #region Event Handlers

        private void pbxNavigation_Minimize_MouseEnter(object sender, EventArgs e)
        {
            pbxMinimize.BackgroundImage = imlMinimize.Images[Highlighted];
        }

        private void pbxNavigation_Minimize_MouseDown(object sender, MouseEventArgs e)
        {
            pbxMinimize.BackgroundImage = imlMinimize.Images[Pressed];
        }

        private void pbxNavigation_Minimize_MouseLeave(object sender, EventArgs e)
        {
            pbxMinimize.BackgroundImage = null;
        }

        private void pbxNavigation_Minimize_MouseUp(object sender, MouseEventArgs e)
        {
            OriginalDistance = scMain.SplitterDistance;
            scMain.SplitterDistance = 28;
            pnlCollapsedNav.Visible = true;
        }

        private void pnlCollapsedNav_MouseEnter(object sender, EventArgs e)
        {
            pnlCollapsedNav.BackgroundImage = imlMaximize.Images[Highlighted];
        }

        private void pnlCollapsedNav_MouseDown(object sender, MouseEventArgs e)
        {
            pnlCollapsedNav.BackgroundImage = imlMaximize.Images[Pressed];
        }

        private void pnlCollapsedNav_MouseLeave(object sender, EventArgs e)
        {
            pnlCollapsedNav.BackgroundImage = imlMaximize.Images[2];
        }

        private void pnlCollapsedNav_MouseUp(object sender, MouseEventArgs e)
        {
            scMain.SplitterDistance = OriginalDistance;
            pnlCollapsedNav.Visible = false;
        }

        private void pnlCollapsedNav_SizeChanged(object sender, EventArgs e)
        {
            if (pnlCollapsedNav.Visible)
                pbxCollapsedTitle.Location = new Point(pbxCollapsedTitle.Location.X, (pnlCollapsedNav.Height - pbxCollapsedTitle.Height) / 2);
        }

        private void scMain_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            if (pnlCollapsedNav.Visible)
                e.Cancel = true;
        }

        private void NavigationScreen_SizeChanged(object sender, EventArgs e)
        {
            if (pnlCollapsedNav.Visible)
            {
                pnlCollapsedNav.Height = scMain.Height;
                scMain.SplitterDistance = 28;
            }
        }

        private void pnlCollapsedNav_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlCollapsedNav.Visible)
            {
                pnlCollapsedNav.Height = scMain.Height;
                pbxCollapsedTitle.Location = new Point(pbxCollapsedTitle.Location.X, (pnlCollapsedNav.Height - pbxCollapsedTitle.Height) / 2);
            }
        }

        private void NavigationScreen_Load(object sender, EventArgs e)
        {
            btnSearch.Select();
        }

        private void NavigationButton_Click(object sender, EventArgs e)
        {
			if (!(sender is CustomerButton) || ((CustomerButton)sender).trvOptions.SelectedNode != null)
			{
				foreach (Control theButton in pnlButtons.Controls)
				{
					if (!theButton.Equals(sender))
						((NavigationButtonBase)theButton).Deselect();
				}
			}
        }

        private void scMain_Panel2_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is ScreenBase)
                lstOpenScreens.Add((ScreenBase)e.Control);

        }

        private void scMain_Panel2_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is ScreenBase)
            {
                lstOpenScreens.Remove((ScreenBase)e.Control);
                ((ScreenBase)e.Control).Dispose();
            }
        }

        #endregion

    
    }
}
