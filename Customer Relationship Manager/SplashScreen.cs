using System;
using System.Windows.Forms;

namespace rkcrm
{
    public partial class SplashScreen : Form
    {
        private bool bolIsSplashing;

        public bool IsSplashing
        {
            get { return bolIsSplashing; }
        }

        public SplashScreen(bool IsSplashScreen)
        {
            bolIsSplashing = IsSplashScreen;
            InitializeComponent();
        }

        private void SplashScreen_Click(object sender, EventArgs e)
        {
            if (!IsSplashing)
                this.Close();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version: " + Application.ProductVersion;
        }
    }
}
