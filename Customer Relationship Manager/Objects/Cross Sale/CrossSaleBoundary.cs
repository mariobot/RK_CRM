using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.Department;
using rkcrm.Administration.User;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Cross_Sale
{
	class CrossSaleBoundary : BoundaryBase
	{

		#region Variables

		internal System.Windows.Forms.CheckBox chkNeverExpires;
		internal System.Windows.Forms.Label lblDepartment;
		internal System.Windows.Forms.ComboBox cboDepartment;
		internal System.Windows.Forms.Label lblValidated;
		internal System.Windows.Forms.Label lblVerified;
		internal System.Windows.Forms.MaskedTextBox mtxtValidated;
		internal System.Windows.Forms.MaskedTextBox mtxtVerified;
		internal System.Windows.Forms.Label lblSalesRep;
		internal System.Windows.Forms.ComboBox cboSalesRep;

		private Customer.Customer clsMyCustomer;
		private CrossSale clsMyCrossSale;
		private DataTable ProfitCenters;
		private DataTable SalesReps;
		private List<int> AvailableDepartments;

		#endregion


		#region Properties

		public Customer.Customer MyCustomer
		{
			get { return clsMyCustomer; }
			set 
			{ 
				clsMyCustomer = value;

				if (MyCrossSale != null)
					MyCrossSale.CustomerID = value.ID;
			}
		}
		
		public CrossSale MyCrossSale
		{
			get { return clsMyCrossSale; }
			set
			{
				if (clsMyCrossSale != value && clsMyCrossSale != null)
					clsMyCrossSale.Dispose();

				clsMyCrossSale = value;

				if (value == null)
					SetSearchingMode();
				else
				{
					if (value.CustomerID > 0 && value.DepartmentID > 0)
						SetEditingMode();
					else
					{
						clsMyCrossSale.CustomerID = MyCustomer.ID;
						SetAddingMode();
					}
				}
			}
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.chkNeverExpires = new System.Windows.Forms.CheckBox();
			this.lblDepartment = new System.Windows.Forms.Label();
			this.cboDepartment = new System.Windows.Forms.ComboBox();
			this.lblValidated = new System.Windows.Forms.Label();
			this.lblVerified = new System.Windows.Forms.Label();
			this.mtxtValidated = new System.Windows.Forms.MaskedTextBox();
			this.mtxtVerified = new System.Windows.Forms.MaskedTextBox();
			this.lblSalesRep = new System.Windows.Forms.Label();
			this.cboSalesRep = new System.Windows.Forms.ComboBox();
			this.pnlControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.chkNeverExpires);
			this.pnlControls.Controls.Add(this.lblDepartment);
			this.pnlControls.Controls.Add(this.cboDepartment);
			this.pnlControls.Controls.Add(this.lblValidated);
			this.pnlControls.Controls.Add(this.lblVerified);
			this.pnlControls.Controls.Add(this.mtxtValidated);
			this.pnlControls.Controls.Add(this.mtxtVerified);
			this.pnlControls.Controls.Add(this.lblSalesRep);
			this.pnlControls.Controls.Add(this.cboSalesRep);
			// 
			// chkNeverExpires
			// 
			this.chkNeverExpires.AutoSize = true;
			this.chkNeverExpires.Location = new System.Drawing.Point(503, 33);
			this.chkNeverExpires.Name = "chkNeverExpires";
			this.chkNeverExpires.Size = new System.Drawing.Size(92, 17);
			this.chkNeverExpires.TabIndex = 17;
			this.chkNeverExpires.Text = "Never Expires";
			this.chkNeverExpires.UseVisualStyleBackColor = true;
			this.chkNeverExpires.CheckedChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblDepartment
			// 
			this.lblDepartment.AutoSize = true;
			this.lblDepartment.Location = new System.Drawing.Point(165, 15);
			this.lblDepartment.Name = "lblDepartment";
			this.lblDepartment.Size = new System.Drawing.Size(62, 13);
			this.lblDepartment.TabIndex = 16;
			this.lblDepartment.Text = "Department";
			// 
			// cboDepartment
			// 
			this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboDepartment.FormattingEnabled = true;
			this.cboDepartment.Location = new System.Drawing.Point(165, 31);
			this.cboDepartment.Name = "cboDepartment";
			this.cboDepartment.Size = new System.Drawing.Size(120, 21);
			this.cboDepartment.TabIndex = 10;
			this.cboDepartment.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblValidated
			// 
			this.lblValidated.AutoSize = true;
			this.lblValidated.Location = new System.Drawing.Point(394, 15);
			this.lblValidated.Name = "lblValidated";
			this.lblValidated.Size = new System.Drawing.Size(51, 13);
			this.lblValidated.TabIndex = 15;
			this.lblValidated.Text = "Validated";
			// 
			// lblVerified
			// 
			this.lblVerified.AutoSize = true;
			this.lblVerified.Location = new System.Drawing.Point(288, 15);
			this.lblVerified.Name = "lblVerified";
			this.lblVerified.Size = new System.Drawing.Size(42, 13);
			this.lblVerified.TabIndex = 14;
			this.lblVerified.Text = "Verified";
			// 
			// mtxtValidated
			// 
			this.mtxtValidated.Location = new System.Drawing.Point(397, 32);
			this.mtxtValidated.Mask = "00/00/00";
			this.mtxtValidated.Name = "mtxtValidated";
			this.mtxtValidated.Size = new System.Drawing.Size(100, 20);
			this.mtxtValidated.TabIndex = 13;
			this.mtxtValidated.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// mtxtVerified
			// 
			this.mtxtVerified.Location = new System.Drawing.Point(291, 31);
			this.mtxtVerified.Mask = "00/00/00";
			this.mtxtVerified.Name = "mtxtVerified";
			this.mtxtVerified.Size = new System.Drawing.Size(100, 20);
			this.mtxtVerified.TabIndex = 12;
			this.mtxtVerified.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblSalesRep
			// 
			this.lblSalesRep.AutoSize = true;
			this.lblSalesRep.Location = new System.Drawing.Point(12, 15);
			this.lblSalesRep.Name = "lblSalesRep";
			this.lblSalesRep.Size = new System.Drawing.Size(56, 13);
			this.lblSalesRep.TabIndex = 11;
			this.lblSalesRep.Text = "Sales Rep";
			// 
			// cboSalesRep
			// 
			this.cboSalesRep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboSalesRep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboSalesRep.FormattingEnabled = true;
			this.cboSalesRep.Location = new System.Drawing.Point(12, 31);
			this.cboSalesRep.Name = "cboSalesRep";
			this.cboSalesRep.Size = new System.Drawing.Size(147, 21);
			this.cboSalesRep.TabIndex = 9;
			this.cboSalesRep.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// CrossSaleBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "CrossSaleBoundary";
			this.pnlControls.ResumeLayout(false);
			this.pnlControls.PerformLayout();
			this.ResumeLayout(false);

		}

		private void LoadComboBoxes()
		{
			using (CrossSaleController theController = new CrossSaleController())
			{
				AvailableDepartments = theController.GetAvailableDepartments(MyCustomer.ID);
			}

			LoadDepartmentComboBox();
			LoadRepComboBox();
		}

		private void LoadDepartmentComboBox()
		{
			DataTable departments = ProfitCenters.Copy();
			DataRow homeDepartment = null;
			bool found = false;
			int index = 0, deptID;

			if (cboDepartment.DataSource != null)
			{
				((DataTable)cboDepartment.DataSource).Dispose();
				cboDepartment.DataSource = null;
			}

			//remove unavailable departments
			while (index < departments.Rows.Count)
			{
				deptID = Convert.ToInt32(departments.Rows[index]["department_id"]);
				found = false;

				foreach (int ID in AvailableDepartments)
					if (deptID == ID)
						found = true;

				if (!found && deptID != MyCrossSale.DepartmentID)
					departments.Rows.Remove(departments.Rows[index]);
				else
					index++;
			}

			if (MyCrossSale.SalesRepID > 0)
				homeDepartment = departments.Rows.Find(MyCrossSale.GetSalesRep().HomeDepartment.ID);

			//Remove the sales reps department as well
			if (homeDepartment != null)
				departments.Rows.Remove(homeDepartment);

			cboDepartment.DataSource = departments;
			cboDepartment.DisplayMember = "name";
			cboDepartment.ValueMember = "department_id";
			cboDepartment.SelectedItem = null;
		}

		private void LoadRepComboBox()
		{
			DataTable reps = SalesReps.Copy();

			if (cboSalesRep.DataSource != null)
			{
				((DataTable)cboSalesRep.DataSource).Dispose();
				cboSalesRep.DataSource = null;
			}

			if (clsMyCrossSale != null)
			{
				int index = 0;

				while (index < reps.Rows.Count)
				{
					if (Convert.ToInt32(reps.Rows[index]["department_id"]) == clsMyCrossSale.DepartmentID)
						reps.Rows.Remove(reps.Rows[index]);
					else
						index++;
				}
			}

			cboSalesRep.DataSource = reps;
			cboSalesRep.DisplayMember = "name";
			cboSalesRep.ValueMember = "user_id";
			cboSalesRep.SelectedItem = null;
		}

		private void SetAddingMode()
		{
			LoadComboBoxes();
		
			cboDepartment.Enabled = true;
			cboSalesRep.Enabled = true;
			mtxtVerified.Enabled = true;
			mtxtValidated.Enabled = true;
			chkNeverExpires.Enabled = true;

			this.Title = "New Cross Sale";
			this.IsDirty = false;
			this.State = BoundaryState.Adding;
		}

		private void SetEditingMode()
		{
			LoadComboBoxes();

			this.State = BoundaryState.Loading;

			cboDepartment.SelectedValue = clsMyCrossSale.DepartmentID;
			cboSalesRep.SelectedValue = clsMyCrossSale.SalesRepID;
			mtxtVerified.Text = clsMyCrossSale.Verified.ToString("MM/dd/yy");
			mtxtValidated.Text = (clsMyCrossSale.Validated != DateTime.MinValue ? clsMyCrossSale.Validated.ToString("MM/dd/yy") : string.Empty);
			chkNeverExpires.Checked = clsMyCrossSale.NeverExpires;

			if (cboDepartment.SelectedValue == null)
				cboDepartment.Text = clsMyCrossSale.GetDepartment().Name;
			if (cboSalesRep.SelectedValue == null)
				cboSalesRep.Text = clsMyCrossSale.GetUpdater().FullName;

			if (!clsMyCrossSale.IsArchived)
			{
				cboDepartment.Enabled = true;
				cboSalesRep.Enabled = true;
				mtxtVerified.Enabled = true;
				mtxtValidated.Enabled = true;
				chkNeverExpires.Enabled = true;
			}
			else
			{
				cboDepartment.Enabled = false;
				cboSalesRep.Enabled = false;
				mtxtVerified.Enabled = false;
				mtxtValidated.Enabled = false;
				chkNeverExpires.Enabled = false;
			}

			this.Title = "Edit Cross Sale";
			this.IsDirty = false;
			this.State = BoundaryState.Editing;
		}

		private void SetSearchingMode()
		{
			Clear();

			cboDepartment.Enabled = false;
			cboSalesRep.Enabled = false;
			mtxtVerified.Enabled = false;
			mtxtValidated.Enabled = false;
			chkNeverExpires.Enabled = false;

			this.Title = "Search Cross Sales";
			IsDirty = false;
			this.State = BoundaryState.Searching;
		}

		public new void Clear()
		{
			base.Clear();
			cboDepartment.SelectedItem = null;
			cboDepartment.Text = string.Empty;
			cboSalesRep.SelectedItem = null;
			cboSalesRep.Text = string.Empty;
			mtxtVerified.Clear();
			mtxtValidated.Clear();
			chkNeverExpires.Checked = false;
		}

		internal bool CommitChanges()
		{
			try
			{
				Department myDepot = MyCrossSale.GetDepartment();
				User myRep = MyCrossSale.GetUpdater();

				if (!IsSelectionValid(cboDepartment) && cboDepartment.Text != myDepot.Name)
					throw new Exception("The \"Department\" is not valid.");
				if (!IsSelectionValid(cboSalesRep) && cboSalesRep.Text != myRep.FullName)
					throw new Exception("The \"Sales Rep\" is not valid.");
				if (!mtxtVerified.MaskCompleted)
					throw new Exception("The \"Verified\" date is not valid.");
				


				if (cboDepartment.SelectedValue != null)
					MyCrossSale.DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
				if (cboSalesRep.SelectedValue != null)
					MyCrossSale.SalesRepID = Convert.ToInt32(cboSalesRep.SelectedValue);
				MyCrossSale.Verified = Convert.ToDateTime(mtxtVerified.Text);
				MyCrossSale.Validated = (mtxtValidated.MaskCompleted ? Convert.ToDateTime(mtxtValidated.Text) : DateTime.MinValue);
				MyCrossSale.NeverExpires = chkNeverExpires.Checked;

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		#endregion


		#region Event Handlers

		private void control_Changed(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Editing || this.State == BoundaryState.Adding)
				this.IsDirty = true;
		}

		#endregion


		#region Constructor

		public CrossSaleBoundary()
			: base()
		{
			InitializeComponent();

			using (DepartmentController theController = new DepartmentController())
			{
				ProfitCenters = theController.GetProfitCenters();
			}

			using (UserController theController = new UserController())
			{
				SalesReps = theController.GetSalesReps();
			}

			AvailableDepartments = new List<int>();
		}

		#endregion


	}
}
