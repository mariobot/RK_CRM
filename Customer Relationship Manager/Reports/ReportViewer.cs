using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace rkcrm.Reports
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        private void ReportViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ReportDocument)crvReports.ReportSource).Close();
            ((ReportDocument)crvReports.ReportSource).Dispose();
        }

        private void ReportViewer_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
