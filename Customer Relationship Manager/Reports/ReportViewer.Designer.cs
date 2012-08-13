namespace rkcrm.Reports
{
    partial class ReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crvReports = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReports
            // 
            this.crvReports.ActiveViewIndex = -1;
            this.crvReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReports.DisplayGroupTree = false;
            this.crvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReports.EnableDrillDown = false;
            this.crvReports.Location = new System.Drawing.Point(0, 0);
            this.crvReports.Name = "crvReports";
            this.crvReports.SelectionFormula = "";
            this.crvReports.ShowGroupTreeButton = false;
            this.crvReports.Size = new System.Drawing.Size(784, 646);
            this.crvReports.TabIndex = 0;
            this.crvReports.ViewTimeSelectionFormula = "";
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 646);
            this.Controls.Add(this.crvReports);
            this.Name = "ReportViewer";
            this.Text = "ReportViewer";
            this.Shown += new System.EventHandler(this.ReportViewer_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportViewer_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvReports;

    }
}