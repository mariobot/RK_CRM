using rkcrm.Base_Classes;
using rkcrm.Reports;

namespace rkcrm.Navigation
{
	public class ReportsButton : NavigationButtonBase
    {
        #region Methods

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ReportsButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ButtonText = "Reports";
            this.HasOptions = false;
            this.Icon = global::rkcrm.Properties.Resources.Reports;
            this.Name = "ReportsButton";
            this.Click += new System.EventHandler(this.ReportsButton_Click);
            this.ResumeLayout(false);

        }

		public void PerformClick()
		{
			OnClick(new System.EventArgs());
		}

        #endregion


        #region Event Handlers

        private void ReportsButton_Click(object sender, System.EventArgs e)
        {
            NavigationScreen myNavigation = GetNavigationScreen();

            if (myNavigation != null)
                myNavigation.NavigateTo(typeof(ReportsScreen));
        }

        #endregion


        #region Constructor

        public ReportsButton()
            : base()
        {
            InitializeComponent();
        }

        #endregion
    }
}
