using System;
using System.Windows.Forms;
using rkcrm.Administration.Department;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer.Lead_Source.Details_Forms
{
	class DepartmentAndYear : DetailFormBase
	{
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Panel pnlLine;
		private System.Windows.Forms.Panel pnlLineLeft;
		private System.Windows.Forms.Panel pnlLineRight;
		private System.Windows.Forms.ComboBox cboDepartment;
		private System.Windows.Forms.Label lblDepartment;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.ComboBox cboYear;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlHeader;


		#region Methods

		private void InitializeComponent()
		{
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlLine = new System.Windows.Forms.Panel();
			this.pnlLineLeft = new System.Windows.Forms.Panel();
			this.pnlLineRight = new System.Windows.Forms.Panel();
			this.cboDepartment = new System.Windows.Forms.ComboBox();
			this.lblDepartment = new System.Windows.Forms.Label();
			this.lblYear = new System.Windows.Forms.Label();
			this.cboYear = new System.Windows.Forms.ComboBox();
			this.pnlHeader.SuspendLayout();
			this.pnlFooter.SuspendLayout();
			this.pnlLine.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(320, 50);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(12, 5);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(304, 40);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Which department did they previously purchase from and  in what year?";
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.btnOK);
			this.pnlFooter.Controls.Add(this.btnCancel);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 140);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(320, 50);
			this.pnlFooter.TabIndex = 1;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(152, 10);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 30);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(233, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// pnlLine
			// 
			this.pnlLine.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlLine.Controls.Add(this.pnlLineLeft);
			this.pnlLine.Controls.Add(this.pnlLineRight);
			this.pnlLine.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlLine.Location = new System.Drawing.Point(0, 139);
			this.pnlLine.Name = "pnlLine";
			this.pnlLine.Size = new System.Drawing.Size(320, 1);
			this.pnlLine.TabIndex = 2;
			// 
			// pnlLineLeft
			// 
			this.pnlLineLeft.BackColor = System.Drawing.SystemColors.Control;
			this.pnlLineLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLineLeft.Location = new System.Drawing.Point(0, 0);
			this.pnlLineLeft.Name = "pnlLineLeft";
			this.pnlLineLeft.Size = new System.Drawing.Size(10, 1);
			this.pnlLineLeft.TabIndex = 1;
			// 
			// pnlLineRight
			// 
			this.pnlLineRight.BackColor = System.Drawing.SystemColors.Control;
			this.pnlLineRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlLineRight.Location = new System.Drawing.Point(310, 0);
			this.pnlLineRight.Name = "pnlLineRight";
			this.pnlLineRight.Size = new System.Drawing.Size(10, 1);
			this.pnlLineRight.TabIndex = 0;
			// 
			// cboDepartment
			// 
			this.cboDepartment.FormattingEnabled = true;
			this.cboDepartment.Location = new System.Drawing.Point(41, 89);
			this.cboDepartment.Name = "cboDepartment";
			this.cboDepartment.Size = new System.Drawing.Size(158, 21);
			this.cboDepartment.TabIndex = 3;
			// 
			// lblDepartment
			// 
			this.lblDepartment.AutoSize = true;
			this.lblDepartment.Location = new System.Drawing.Point(38, 73);
			this.lblDepartment.Name = "lblDepartment";
			this.lblDepartment.Size = new System.Drawing.Size(62, 13);
			this.lblDepartment.TabIndex = 5;
			this.lblDepartment.Text = "Department";
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Location = new System.Drawing.Point(202, 73);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(29, 13);
			this.lblYear.TabIndex = 6;
			this.lblYear.Text = "Year";
			// 
			// cboYear
			// 
			this.cboYear.FormattingEnabled = true;
			this.cboYear.Location = new System.Drawing.Point(205, 89);
			this.cboYear.Name = "cboYear";
			this.cboYear.Size = new System.Drawing.Size(73, 21);
			this.cboYear.TabIndex = 7;
			// 
			// DepartmentAndYear
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(320, 190);
			this.Controls.Add(this.cboYear);
			this.Controls.Add(this.lblYear);
			this.Controls.Add(this.lblDepartment);
			this.Controls.Add(this.cboDepartment);
			this.Controls.Add(this.pnlLine);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.pnlHeader);
			this.Name = "DepartmentAndYear";
			this.Load += new System.EventHandler(this.DepartmentAndYear_Load);
			this.OriginalDetailChanged += new System.EventHandler(this.DepartmentAndYear_OriginalDetailChanged);
			this.pnlHeader.ResumeLayout(false);
			this.pnlFooter.ResumeLayout(false);
			this.pnlLine.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion


		#region Event Handlers

		private void DepartmentAndYear_Load(object sender, EventArgs e)
		{
			using (DepartmentController theController = new DepartmentController())
			{
				cboDepartment.DataSource = theController.GetProfitCenters();
				cboDepartment.DisplayMember = "name";
				cboDepartment.ValueMember = "department_id";
				cboDepartment.SelectedItem = null;
			}

			int currentYear = DateTime.Today.Year;

			while (currentYear >= 1974)
			{
				cboYear.Items.Add(currentYear);
				currentYear--;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!IsSelectionValid(cboDepartment))
				MessageBox.Show("The \"Department\" is not valid.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			else
			{
				if (!IsSelectionValid(cboYear))
					MessageBox.Show("The \"Year\" is not valid.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				else
				{
					strReturnString = cboDepartment.Text + " - " + cboYear.Text;
					DialogResult = System.Windows.Forms.DialogResult.OK;
					this.Close();
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			objReturnValue = null;
			strReturnString = string.Empty;
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

        private void DepartmentAndYear_OriginalDetailChanged(object sender, EventArgs e)
        {
            string oText = string.Empty;

            foreach (char oChar in OriginalDetail.ToCharArray())
            {
                if (oChar != '-')
                    oText += oChar;

                if (oChar == '-')
                {
                    cboDepartment.Text = oText.Substring(0, oText.Length - 2);
                    oText = string.Empty;
                }
            }

			cboYear.Text = oText.Substring(1);
        }

		#endregion


		#region Constructor

		public DepartmentAndYear()
			: base()
		{
			InitializeComponent();
		}

		#endregion

	}
}
