using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using rkcrm.Administration.User;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Reports.Parameter_Forms.User
{
	class MyCrossLeadAnalysis : ParameterBase
	{
		internal System.Windows.Forms.DateTimePicker dtpEnd;
		internal System.Windows.Forms.DateTimePicker dtpStart;
		internal System.Windows.Forms.Label lblEnd;
		internal System.Windows.Forms.Label lblStart;
		internal System.Windows.Forms.Label lblSalesRep;
		internal System.Windows.Forms.ComboBox cboSalesRep;


		#region Methods

		public override ReportDocument GetReport()
		{
			ReportDocument oReport = new ReportDocument();

			using (ReportController theController = new ReportController())
			{
				DataTable oTable = theController.GetMyCrossLeadAnalysis((int)cboSalesRep.SelectedValue, dtpStart.Value, dtpEnd.Value);

				if (oTable.Rows.Count > 0)
				{
					try
					{
						if (File.Exists(ReportPath))
						{
							oReport.Load(ReportPath);
							oReport.SetDataSource(oTable);
						}
						else
							throw new Exception("The report file \"" + ReportPath + "\" could not be found.");
					}
					catch (Exception e)
					{
						ErrorHandler.ProcessException(e, false);
					}
				}
				else
					MessageBox.Show("There is no data for this report.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return oReport;
		}

		public override bool IsInputValid()
		{
			if (cboSalesRep.SelectedValue == null)
				MessageBox.Show("Please select a \"Sales Rep\" and try again.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			return (cboSalesRep.SelectedValue != null);
		}

		private void InitializeComponent()
		{
			this.dtpEnd = new System.Windows.Forms.DateTimePicker();
			this.dtpStart = new System.Windows.Forms.DateTimePicker();
			this.lblEnd = new System.Windows.Forms.Label();
			this.lblStart = new System.Windows.Forms.Label();
			this.lblSalesRep = new System.Windows.Forms.Label();
			this.cboSalesRep = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// dtpEnd
			// 
			this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpEnd.Location = new System.Drawing.Point(125, 117);
			this.dtpEnd.Name = "dtpEnd";
			this.dtpEnd.Size = new System.Drawing.Size(107, 20);
			this.dtpEnd.TabIndex = 41;
			// 
			// dtpStart
			// 
			this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpStart.Location = new System.Drawing.Point(12, 117);
			this.dtpStart.Name = "dtpStart";
			this.dtpStart.Size = new System.Drawing.Size(107, 20);
			this.dtpStart.TabIndex = 40;
			// 
			// lblEnd
			// 
			this.lblEnd.AutoSize = true;
			this.lblEnd.Location = new System.Drawing.Point(122, 101);
			this.lblEnd.Name = "lblEnd";
			this.lblEnd.Size = new System.Drawing.Size(26, 13);
			this.lblEnd.TabIndex = 39;
			this.lblEnd.Text = "End";
			// 
			// lblStart
			// 
			this.lblStart.AutoSize = true;
			this.lblStart.Location = new System.Drawing.Point(12, 101);
			this.lblStart.Name = "lblStart";
			this.lblStart.Size = new System.Drawing.Size(29, 13);
			this.lblStart.TabIndex = 38;
			this.lblStart.Text = "Start";
			// 
			// lblSalesRep
			// 
			this.lblSalesRep.AutoSize = true;
			this.lblSalesRep.Location = new System.Drawing.Point(12, 52);
			this.lblSalesRep.Name = "lblSalesRep";
			this.lblSalesRep.Size = new System.Drawing.Size(56, 13);
			this.lblSalesRep.TabIndex = 37;
			this.lblSalesRep.Text = "Sales Rep";
			// 
			// cboSalesRep
			// 
			this.cboSalesRep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboSalesRep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboSalesRep.Location = new System.Drawing.Point(12, 68);
			this.cboSalesRep.Name = "cboSalesRep";
			this.cboSalesRep.Size = new System.Drawing.Size(153, 21);
			this.cboSalesRep.TabIndex = 36;
			// 
			// MyCrossLeadAnalysis
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(274, 205);
			this.Controls.Add(this.dtpEnd);
			this.Controls.Add(this.dtpStart);
			this.Controls.Add(this.lblEnd);
			this.Controls.Add(this.lblStart);
			this.Controls.Add(this.lblSalesRep);
			this.Controls.Add(this.cboSalesRep);
			this.Name = "MyCrossLeadAnalysis";
			this.Load += new System.EventHandler(this.MyCrossLeadAnalysis_Load);
			this.Controls.SetChildIndex(this.cboSalesRep, 0);
			this.Controls.SetChildIndex(this.lblSalesRep, 0);
			this.Controls.SetChildIndex(this.lblStart, 0);
			this.Controls.SetChildIndex(this.lblEnd, 0);
			this.Controls.SetChildIndex(this.dtpStart, 0);
			this.Controls.SetChildIndex(this.dtpEnd, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion


		#region Event Handlers

		private void MyCrossLeadAnalysis_Load(object sender, EventArgs e)
		{
			using (UserController theController = new UserController())
			{
				if (thisUser.Role.ID == 3)
					cboSalesRep.DataSource = theController.GetDepartmentReps(thisUser.HomeDepartment.ID);
				else
					cboSalesRep.DataSource = theController.GetSalesReps();

				cboSalesRep.DisplayMember = "name";
				cboSalesRep.ValueMember = "user_id";
				cboSalesRep.SelectedValue = thisUser.ID;

				if (thisUser.Role.ID != 1 && thisUser.Role.ID != 3)
				{
					this.Height -= (dtpStart.Location.Y - cboSalesRep.Location.Y);
					dtpStart.Location = new System.Drawing.Point(dtpStart.Location.X, cboSalesRep.Location.Y);
					lblStart.Location = new System.Drawing.Point(lblStart.Location.X, lblSalesRep.Location.Y);
					dtpEnd.Location = new System.Drawing.Point(dtpEnd.Location.X, dtpStart.Location.Y);
					lblEnd.Location = new System.Drawing.Point(lblEnd.Location.X, lblStart.Location.Y);
					cboSalesRep.Visible = false;
					lblSalesRep.Visible = false;
				}

				dtpStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
				dtpEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
			}
		}

		#endregion


		#region Constructor

		public MyCrossLeadAnalysis()
			: base()
		{
			InitializeComponent();

			ReportName = "My Cross Lead Analysis";
			ReportPath = MySettings.ReportsPath + "Sales Rep\\My Cross Lead Analysis.rpt";

			this.lblTitle.Text = ReportName;
		}

		#endregion

	}
}
