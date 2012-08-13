using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using rkcrm.Reports;

namespace rkcrm.Base_Classes
{
    public partial class ParameterBase : Form
    {

        #region Variables

        protected string ReportName;
        protected string ReportPath;

        #endregion


        #region Methods

        public virtual ReportDocument GetReport()
		{
			return null;
		}

		public virtual bool IsInputValid()
		{
			return true;
		}

        #endregion

        
        #region Event Handlers

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (IsInputValid())
            {
                this.Cursor = Cursors.WaitCursor;
                ReportDocument oReport = GetReport();
                this.Cursor = Cursors.Default;

                if (oReport != null)
                {
                    using (SaveFileDialog oDialog = new SaveFileDialog())
                    {
                        oDialog.Title = "Export Report";
                        oDialog.Filter = "PDF|*.pdf";
                        oDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        oDialog.ShowDialog();

                        if (oDialog.FileName != string.Empty)
                        {
                            oReport.ExportToDisk(ExportFormatType.PortableDocFormat, oDialog.FileName);

                            if (System.IO.File.Exists(oDialog.FileName))
                                System.Diagnostics.Process.Start(oDialog.FileName);

                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There is no data for this report.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (IsInputValid())
            {
                ReportViewer oForm = new ReportViewer();

                oForm.Text = ReportName;

                this.Cursor = Cursors.WaitCursor;
                oForm.crvReports.ReportSource = GetReport();
                this.Cursor = Cursors.Default;

                if (oForm.crvReports.ReportSource != null)
                {
                    oForm.Show();
                    oForm.Activate();
                }
                else
                {
                    oForm.Close();
                    oForm.Dispose();
                    MessageBox.Show("There is no data for this report.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        

        public ParameterBase()
        {
            InitializeComponent();
        }

    }
}
