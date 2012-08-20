using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.Contact_Method;
using rkcrm.Administration.Department;
using rkcrm.Administration.User;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Quote
{
	class QuoteBoundary : BoundaryBase
	{


		#region Variables

		internal GroupBox gbxSummary;
		internal Label DlblValue;
		internal Label lblValue;
		internal Label DlblAverage;
		internal Label lblAverage;
		internal Label DlblQuoteCount;
		internal Label lblQuoteCount;
		internal Label DlblCustCount;
		internal Label lblCustCount;
		internal Label lblSold;
		internal Label lblDescription;
		internal TextBox txtDescription;
		internal ComboBox cboSupport;
		internal Label lblSupport;
		internal TextBox txtUnits;
		internal Label lblUnits;
		internal Label lblProbability;
		internal TextBox txtProbability;
		internal Label lblAmount;
		internal TextBox txtAmount;
		internal MaskedTextBox mtxtExpShip;
		internal Label lblExpShip;
		internal Label lblName;
		internal TextBox txtName;
		internal ComboBox cboDepartment;
		internal Label lblDepartment;
		internal ComboBox cboSalesRep;
		internal ComboBox cboContact;
		internal Label lblContacted;
		internal Label lblSalesRep;
		internal ComboBox cboMethod;
		internal Label lblMethod;

		private Quote clsMyQuote;
		private Project.Department.Department clsMyProjectDepartment;
		private DataTable AvailableSalesReps;
		private bool IsTrackHousing = false;
		private const int TRACK_HOUSING = 2;

		#endregion


		#region Properties

		public Quote MyQuote
		{
			get { return clsMyQuote; }
			set 
			{
				if (clsMyQuote != value && clsMyQuote != null)
				{
					clsMyQuote.Dispose();

					if (clsMyProjectDepartment != null)
					{
						clsMyProjectDepartment.Dispose();
						clsMyProjectDepartment = null;
					}
				}

				clsMyQuote = value;

				if (value == null)
					SetSearchingMode();
				else
				{
					LoadContacts();

					if (value.ID > 0)
						SetEditingMode();
					else
						SetAddingMode();
				}

				OnMyQuoteChanged(new EventArgs());
			}
		}

		public Project.Department.Department MyProjectDepartment
		{
			get 
			{
				//This if statement was added because an issue in the new customer wizard PassData() function
				if (clsMyProjectDepartment == null)
					clsMyProjectDepartment = new rkcrm.Objects.Project.Department.Department();

				return clsMyProjectDepartment; 
			}
			//set { clsMyProjectDepartment = value; }
		}

		#endregion


		#region Methods

		private new void Clear()
		{
			base.Clear();

			cboContact.SelectedItem = null;
			cboDepartment.SelectedItem = null;
			cboMethod.SelectedItem = null;
			cboSalesRep.SelectedItem = null;
			cboSupport.SelectedItem = null;
			cboContact.Text = string.Empty;
			cboDepartment.Text = string.Empty;
			cboMethod.Text = string.Empty;
			cboSalesRep.Text = string.Empty;
			cboSupport.Text = string.Empty;
			txtAmount.Clear();
			txtDescription.Clear();
			txtName.Clear();
			txtProbability.Clear();
			txtUnits.Clear();
			DlblAverage.Text = string.Empty;
			DlblCustCount.Text = string.Empty;
			DlblQuoteCount.Text = string.Empty;
			DlblValue.Text = string.Empty;
			DlblAverage.BackColor = System.Drawing.Color.WhiteSmoke;
			DlblCustCount.BackColor = System.Drawing.Color.WhiteSmoke;
			DlblQuoteCount.BackColor = System.Drawing.Color.WhiteSmoke;
			DlblValue.BackColor = System.Drawing.Color.WhiteSmoke;
			mtxtExpShip.Clear();
		}

		private DataTable GetDepartmentReps(int DepartmentID)
		{
			DataTable DepartmentReps = AvailableSalesReps.Copy();
			int index = 0;

			while (index < DepartmentReps.Rows.Count)
			{
				if (Convert.ToInt32(DepartmentReps.Rows[index]["department_id"]) != DepartmentID)
					DepartmentReps.Rows.RemoveAt(index);
				else
					index++;
			}

			return DepartmentReps;
		}

		private void InitializeComponent()
		{
			this.gbxSummary = new System.Windows.Forms.GroupBox();
			this.DlblValue = new System.Windows.Forms.Label();
			this.lblValue = new System.Windows.Forms.Label();
			this.DlblAverage = new System.Windows.Forms.Label();
			this.lblAverage = new System.Windows.Forms.Label();
			this.DlblQuoteCount = new System.Windows.Forms.Label();
			this.lblQuoteCount = new System.Windows.Forms.Label();
			this.DlblCustCount = new System.Windows.Forms.Label();
			this.lblCustCount = new System.Windows.Forms.Label();
			this.lblSold = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.cboSupport = new System.Windows.Forms.ComboBox();
			this.lblSupport = new System.Windows.Forms.Label();
			this.txtUnits = new System.Windows.Forms.TextBox();
			this.lblUnits = new System.Windows.Forms.Label();
			this.lblProbability = new System.Windows.Forms.Label();
			this.txtProbability = new System.Windows.Forms.TextBox();
			this.lblAmount = new System.Windows.Forms.Label();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.mtxtExpShip = new System.Windows.Forms.MaskedTextBox();
			this.lblExpShip = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.cboDepartment = new System.Windows.Forms.ComboBox();
			this.lblDepartment = new System.Windows.Forms.Label();
			this.cboSalesRep = new System.Windows.Forms.ComboBox();
			this.cboContact = new System.Windows.Forms.ComboBox();
			this.lblContacted = new System.Windows.Forms.Label();
			this.lblSalesRep = new System.Windows.Forms.Label();
			this.cboMethod = new System.Windows.Forms.ComboBox();
			this.lblMethod = new System.Windows.Forms.Label();
			this.pnlControls.SuspendLayout();
			this.gbxSummary.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.gbxSummary);
			this.pnlControls.Controls.Add(this.lblDescription);
			this.pnlControls.Controls.Add(this.txtDescription);
			this.pnlControls.Controls.Add(this.cboSupport);
			this.pnlControls.Controls.Add(this.lblSupport);
			this.pnlControls.Controls.Add(this.txtUnits);
			this.pnlControls.Controls.Add(this.lblUnits);
			this.pnlControls.Controls.Add(this.lblProbability);
			this.pnlControls.Controls.Add(this.txtProbability);
			this.pnlControls.Controls.Add(this.lblAmount);
			this.pnlControls.Controls.Add(this.txtAmount);
			this.pnlControls.Controls.Add(this.mtxtExpShip);
			this.pnlControls.Controls.Add(this.lblExpShip);
			this.pnlControls.Controls.Add(this.lblName);
			this.pnlControls.Controls.Add(this.txtName);
			this.pnlControls.Controls.Add(this.cboDepartment);
			this.pnlControls.Controls.Add(this.lblDepartment);
			this.pnlControls.Controls.Add(this.cboSalesRep);
			this.pnlControls.Controls.Add(this.cboContact);
			this.pnlControls.Controls.Add(this.lblContacted);
			this.pnlControls.Controls.Add(this.lblSalesRep);
			this.pnlControls.Controls.Add(this.cboMethod);
			this.pnlControls.Controls.Add(this.lblMethod);
			// 
			// gbxSummary
			// 
			this.gbxSummary.Controls.Add(this.DlblValue);
			this.gbxSummary.Controls.Add(this.lblValue);
			this.gbxSummary.Controls.Add(this.DlblAverage);
			this.gbxSummary.Controls.Add(this.lblAverage);
			this.gbxSummary.Controls.Add(this.DlblQuoteCount);
			this.gbxSummary.Controls.Add(this.lblQuoteCount);
			this.gbxSummary.Controls.Add(this.DlblCustCount);
			this.gbxSummary.Controls.Add(this.lblCustCount);
			this.gbxSummary.Controls.Add(this.lblSold);
			this.gbxSummary.Location = new System.Drawing.Point(446, 16);
			this.gbxSummary.Name = "gbxSummary";
			this.gbxSummary.Size = new System.Drawing.Size(147, 170);
			this.gbxSummary.TabIndex = 115;
			this.gbxSummary.TabStop = false;
			this.gbxSummary.Text = "Summary";
			// 
			// DlblValue
			// 
			this.DlblValue.BackColor = System.Drawing.Color.WhiteSmoke;
			this.DlblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DlblValue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.DlblValue.Location = new System.Drawing.Point(6, 33);
			this.DlblValue.Margin = new System.Windows.Forms.Padding(3);
			this.DlblValue.Name = "DlblValue";
			this.DlblValue.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.DlblValue.Size = new System.Drawing.Size(94, 21);
			this.DlblValue.TabIndex = 61;
			// 
			// lblValue
			// 
			this.lblValue.AutoSize = true;
			this.lblValue.BackColor = System.Drawing.Color.Transparent;
			this.lblValue.Location = new System.Drawing.Point(5, 18);
			this.lblValue.Name = "lblValue";
			this.lblValue.Size = new System.Drawing.Size(70, 13);
			this.lblValue.TabIndex = 50;
			this.lblValue.Text = "Project Value";
			// 
			// DlblAverage
			// 
			this.DlblAverage.BackColor = System.Drawing.Color.WhiteSmoke;
			this.DlblAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DlblAverage.Location = new System.Drawing.Point(6, 72);
			this.DlblAverage.Margin = new System.Windows.Forms.Padding(3);
			this.DlblAverage.Name = "DlblAverage";
			this.DlblAverage.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.DlblAverage.Size = new System.Drawing.Size(94, 21);
			this.DlblAverage.TabIndex = 60;
			// 
			// lblAverage
			// 
			this.lblAverage.AutoSize = true;
			this.lblAverage.BackColor = System.Drawing.Color.Transparent;
			this.lblAverage.Location = new System.Drawing.Point(3, 57);
			this.lblAverage.Name = "lblAverage";
			this.lblAverage.Size = new System.Drawing.Size(97, 13);
			this.lblAverage.TabIndex = 52;
			this.lblAverage.Text = "Avg Quote Amount";
			// 
			// DlblQuoteCount
			// 
			this.DlblQuoteCount.BackColor = System.Drawing.Color.WhiteSmoke;
			this.DlblQuoteCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DlblQuoteCount.Location = new System.Drawing.Point(6, 113);
			this.DlblQuoteCount.Margin = new System.Windows.Forms.Padding(3);
			this.DlblQuoteCount.Name = "DlblQuoteCount";
			this.DlblQuoteCount.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.DlblQuoteCount.Size = new System.Drawing.Size(60, 21);
			this.DlblQuoteCount.TabIndex = 58;
			// 
			// lblQuoteCount
			// 
			this.lblQuoteCount.AutoSize = true;
			this.lblQuoteCount.BackColor = System.Drawing.Color.Transparent;
			this.lblQuoteCount.Location = new System.Drawing.Point(3, 98);
			this.lblQuoteCount.Name = "lblQuoteCount";
			this.lblQuoteCount.Size = new System.Drawing.Size(63, 13);
			this.lblQuoteCount.TabIndex = 54;
			this.lblQuoteCount.Text = "# of Quotes";
			// 
			// DlblCustCount
			// 
			this.DlblCustCount.BackColor = System.Drawing.Color.WhiteSmoke;
			this.DlblCustCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DlblCustCount.Location = new System.Drawing.Point(72, 113);
			this.DlblCustCount.Margin = new System.Windows.Forms.Padding(3);
			this.DlblCustCount.Name = "DlblCustCount";
			this.DlblCustCount.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.DlblCustCount.Size = new System.Drawing.Size(60, 21);
			this.DlblCustCount.TabIndex = 59;
			// 
			// lblCustCount
			// 
			this.lblCustCount.AutoSize = true;
			this.lblCustCount.BackColor = System.Drawing.Color.Transparent;
			this.lblCustCount.Location = new System.Drawing.Point(71, 98);
			this.lblCustCount.Name = "lblCustCount";
			this.lblCustCount.Size = new System.Drawing.Size(50, 13);
			this.lblCustCount.TabIndex = 56;
			this.lblCustCount.Text = "# of Cust";
			// 
			// lblSold
			// 
			this.lblSold.BackColor = System.Drawing.Color.LimeGreen;
			this.lblSold.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSold.ForeColor = System.Drawing.Color.White;
			this.lblSold.Location = new System.Drawing.Point(3, 142);
			this.lblSold.Name = "lblSold";
			this.lblSold.Size = new System.Drawing.Size(140, 21);
			this.lblSold.TabIndex = 62;
			this.lblSold.Text = "SOLD";
			this.lblSold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblSold.Visible = false;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.BackColor = System.Drawing.Color.Transparent;
			this.lblDescription.Location = new System.Drawing.Point(8, 105);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(60, 13);
			this.lblDescription.TabIndex = 114;
			this.lblDescription.Text = "Description";
			// 
			// txtDescription
			// 
			this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDescription.Location = new System.Drawing.Point(11, 121);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(429, 20);
			this.txtDescription.TabIndex = 103;
			this.txtDescription.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// cboSupport
			// 
			this.cboSupport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboSupport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboSupport.FormattingEnabled = true;
			this.cboSupport.Location = new System.Drawing.Point(11, 32);
			this.cboSupport.Name = "cboSupport";
			this.cboSupport.Size = new System.Drawing.Size(139, 21);
			this.cboSupport.TabIndex = 93;
			this.cboSupport.SelectionChangeCommitted += new System.EventHandler(this.cboSupport_SelectionChangeCommitted);
			this.cboSupport.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			this.cboSupport.SelectedValueChanged += new System.EventHandler(this.cboSupport_SelectionChangeCommitted);
			// 
			// lblSupport
			// 
			this.lblSupport.AutoSize = true;
			this.lblSupport.Location = new System.Drawing.Point(8, 16);
			this.lblSupport.Name = "lblSupport";
			this.lblSupport.Size = new System.Drawing.Size(77, 13);
			this.lblSupport.TabIndex = 113;
			this.lblSupport.Text = "Sales Support*";
			// 
			// txtUnits
			// 
			this.txtUnits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUnits.Enabled = false;
			this.txtUnits.Location = new System.Drawing.Point(379, 77);
			this.txtUnits.Name = "txtUnits";
			this.txtUnits.Size = new System.Drawing.Size(61, 20);
			this.txtUnits.TabIndex = 102;
			this.txtUnits.Visible = false;
			this.txtUnits.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblUnits
			// 
			this.lblUnits.AutoSize = true;
			this.lblUnits.BackColor = System.Drawing.Color.Transparent;
			this.lblUnits.Location = new System.Drawing.Point(379, 61);
			this.lblUnits.Name = "lblUnits";
			this.lblUnits.Size = new System.Drawing.Size(53, 13);
			this.lblUnits.TabIndex = 112;
			this.lblUnits.Text = "# of Units";
			this.lblUnits.Visible = false;
			// 
			// lblProbability
			// 
			this.lblProbability.AutoSize = true;
			this.lblProbability.BackColor = System.Drawing.Color.Transparent;
			this.lblProbability.Location = new System.Drawing.Point(329, 61);
			this.lblProbability.Name = "lblProbability";
			this.lblProbability.Size = new System.Drawing.Size(44, 13);
			this.lblProbability.TabIndex = 111;
			this.lblProbability.Text = "Prob %*";
			// 
			// txtProbability
			// 
			this.txtProbability.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProbability.Enabled = false;
			this.txtProbability.Location = new System.Drawing.Point(330, 77);
			this.txtProbability.Name = "txtProbability";
			this.txtProbability.Size = new System.Drawing.Size(43, 20);
			this.txtProbability.TabIndex = 101;
			this.txtProbability.TextChanged += new System.EventHandler(this.control_Changed);
			this.txtProbability.Leave += new System.EventHandler(this.txtProbability_Leave);
			// 
			// lblAmount
			// 
			this.lblAmount.AutoSize = true;
			this.lblAmount.BackColor = System.Drawing.Color.Transparent;
			this.lblAmount.Location = new System.Drawing.Point(243, 61);
			this.lblAmount.Name = "lblAmount";
			this.lblAmount.Size = new System.Drawing.Size(47, 13);
			this.lblAmount.TabIndex = 110;
			this.lblAmount.Text = "Amount*";
			// 
			// txtAmount
			// 
			this.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAmount.Enabled = false;
			this.txtAmount.Location = new System.Drawing.Point(244, 77);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(80, 20);
			this.txtAmount.TabIndex = 99;
			this.txtAmount.TextChanged += new System.EventHandler(this.control_Changed);
			this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
			// 
			// mtxtExpShip
			// 
			this.mtxtExpShip.Enabled = false;
			this.mtxtExpShip.Location = new System.Drawing.Point(301, 165);
			this.mtxtExpShip.Mask = "00/00/00";
			this.mtxtExpShip.Name = "mtxtExpShip";
			this.mtxtExpShip.Size = new System.Drawing.Size(77, 20);
			this.mtxtExpShip.TabIndex = 106;
			this.mtxtExpShip.ValidatingType = typeof(System.DateTime);
			this.mtxtExpShip.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblExpShip
			// 
			this.lblExpShip.AutoSize = true;
			this.lblExpShip.BackColor = System.Drawing.Color.Transparent;
			this.lblExpShip.Location = new System.Drawing.Point(298, 149);
			this.lblExpShip.Name = "lblExpShip";
			this.lblExpShip.Size = new System.Drawing.Size(78, 13);
			this.lblExpShip.TabIndex = 109;
			this.lblExpShip.Text = "Exp. Ship Date";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.BackColor = System.Drawing.Color.Transparent;
			this.lblName.Location = new System.Drawing.Point(8, 61);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(80, 13);
			this.lblName.TabIndex = 108;
			this.lblName.Text = "Quote Number*";
			// 
			// txtName
			// 
			this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtName.Location = new System.Drawing.Point(11, 77);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(227, 20);
			this.txtName.TabIndex = 97;
			this.txtName.TextChanged += new System.EventHandler(this.control_Changed);
			// 
			// cboDepartment
			// 
			this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboDepartment.FormattingEnabled = true;
			this.cboDepartment.Location = new System.Drawing.Point(301, 32);
			this.cboDepartment.Name = "cboDepartment";
			this.cboDepartment.Size = new System.Drawing.Size(139, 21);
			this.cboDepartment.TabIndex = 96;
			this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
			this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			this.cboDepartment.SelectedValueChanged += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
			// 
			// lblDepartment
			// 
			this.lblDepartment.AutoSize = true;
			this.lblDepartment.Location = new System.Drawing.Point(298, 16);
			this.lblDepartment.Name = "lblDepartment";
			this.lblDepartment.Size = new System.Drawing.Size(66, 13);
			this.lblDepartment.TabIndex = 107;
			this.lblDepartment.Text = "Department*";
			// 
			// cboSalesRep
			// 
			this.cboSalesRep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboSalesRep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboSalesRep.FormattingEnabled = true;
			this.cboSalesRep.Location = new System.Drawing.Point(156, 32);
			this.cboSalesRep.Name = "cboSalesRep";
			this.cboSalesRep.Size = new System.Drawing.Size(139, 21);
			this.cboSalesRep.TabIndex = 94;
			this.cboSalesRep.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// cboContact
			// 
			this.cboContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboContact.FormattingEnabled = true;
			this.cboContact.Location = new System.Drawing.Point(156, 165);
			this.cboContact.Name = "cboContact";
			this.cboContact.Size = new System.Drawing.Size(139, 21);
			this.cboContact.TabIndex = 105;
			this.cboContact.SelectionChangeCommitted += new System.EventHandler(this.cboContact_SelectionChangeCommitted);
			this.cboContact.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblContacted
			// 
			this.lblContacted.AutoSize = true;
			this.lblContacted.BackColor = System.Drawing.Color.Transparent;
			this.lblContacted.Location = new System.Drawing.Point(153, 149);
			this.lblContacted.Name = "lblContacted";
			this.lblContacted.Size = new System.Drawing.Size(96, 13);
			this.lblContacted.TabIndex = 100;
			this.lblContacted.Text = "Person Contacted*";
			// 
			// lblSalesRep
			// 
			this.lblSalesRep.AutoSize = true;
			this.lblSalesRep.Location = new System.Drawing.Point(153, 16);
			this.lblSalesRep.Name = "lblSalesRep";
			this.lblSalesRep.Size = new System.Drawing.Size(60, 13);
			this.lblSalesRep.TabIndex = 98;
			this.lblSalesRep.Text = "Sales Rep*";
			// 
			// cboMethod
			// 
			this.cboMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cboMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboMethod.FormattingEnabled = true;
			this.cboMethod.Location = new System.Drawing.Point(11, 165);
			this.cboMethod.Name = "cboMethod";
			this.cboMethod.Size = new System.Drawing.Size(139, 21);
			this.cboMethod.TabIndex = 104;
			this.cboMethod.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
			// 
			// lblMethod
			// 
			this.lblMethod.AutoSize = true;
			this.lblMethod.BackColor = System.Drawing.Color.Transparent;
			this.lblMethod.Location = new System.Drawing.Point(8, 149);
			this.lblMethod.Name = "lblMethod";
			this.lblMethod.Size = new System.Drawing.Size(87, 13);
			this.lblMethod.TabIndex = 95;
			this.lblMethod.Text = "Contact Method*";
			// 
			// QuoteBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScroll = true;
			this.AutoScrollMinSize = new System.Drawing.Size(0, 210);
			this.Name = "QuoteBoundary";
			this.Title = "Quotes";
			this.pnlControls.ResumeLayout(false);
			this.pnlControls.PerformLayout();
			this.gbxSummary.ResumeLayout(false);
			this.gbxSummary.PerformLayout();
			this.ResumeLayout(false);

		}

		private Project.Department.Department GetNewProjectDepartment(int ProjectID, int DepartmentID)
		{
			Project.Department.Department theDepartment = new rkcrm.Objects.Project.Department.Department();

			theDepartment.SetDepartmentID(DepartmentID);
			theDepartment.SetProjectID(ProjectID);
			theDepartment.GetNextScope();

			return theDepartment;
		}

		private Project.Department.Department GetProjectDepartment(int ProjectID, int DepartmentID)
		{
			Project.Department.Department theDepartment;

			using (Project.Department.DepartmentController theController = new Project.Department.DepartmentController())
			{
				theDepartment = theController.GetDepartmentWithLastestScope(ProjectID, Convert.ToInt32(DepartmentID));
			}

			if (theDepartment.ProjectID == 0)
			{
				theDepartment.SetProjectID(ProjectID);
				theDepartment.SetDepartmentID(DepartmentID);
			}

			return theDepartment;
		}

		private void LoadContacts()
		{
			DataTable contacts;
			Project.Project MyProject = MyQuote.GetProject();
			IsTrackHousing = (MyProject.TypeID == TRACK_HOUSING);
			int selectedIndex = cboContact.SelectedIndex;
			bool origDirty = this.IsDirty;

			using (Contact.ContactController theController = new rkcrm.Objects.Contact.ContactController())
			{
				contacts = theController.GetContacts(MyProject.CustomerID, false);
			}

			if (contacts.Rows.Count > 0)
			{
				//Remove duplicate rows
				int index = 0;
				DataRow previous = contacts.NewRow();
				DataRow current;

				previous["contact_id"] = 0;
				while (index < contacts.Rows.Count)
				{
					current = contacts.Rows[index];
					if (Convert.ToInt32(current["contact_id"]) == Convert.ToInt32(previous["contact_id"]))
						contacts.Rows.Remove(contacts.Rows[index]);
					else
					{
						previous = contacts.Rows[index];
						index++;
					}
				}
				
				DataRow newRow = contacts.NewRow();
				newRow["contact_id"] = 0;
				newRow["contact"] = "Add a Contact...";

				contacts.Rows.Add(newRow);

				cboContact.DataSource = contacts;
				cboContact.DisplayMember = "contact";
				cboContact.ValueMember = "contact_id";
				cboContact.SelectedItem = null;
			}
			else
				cboContact.Enabled = false;

			if (selectedIndex > -1)
				cboContact.SelectedIndex = selectedIndex;

			this.IsDirty = origDirty;
		}

		private void SetDepartmentDefualts()
		{
			BoundaryState current = this.State;
			this.State = BoundaryState.Loading;

			if (MyProjectDepartment.ExpectedShip != DateTime.MinValue)
				mtxtExpShip.Text = MyProjectDepartment.ExpectedShip.ToString("MM/dd/yy");

			if (MyProjectDepartment.Probability != 0)
				txtProbability.Text = FormatPercent(MyProjectDepartment.Probability);

			if (MyProjectDepartment.Units != 1)
				txtUnits.Text = MyProjectDepartment.Units.ToString();
			
			this.State = current;
		}

		private void SetAddingMode()
		{
			this.State = BoundaryState.Loading;
			this.Clear();

			cboContact.Enabled = cboContact.Items.Count > 0;
			cboDepartment.Enabled = true;
			cboMethod.Enabled = true;
			cboSalesRep.Enabled = true;
			cboSupport.Enabled = true;
			mtxtExpShip.Enabled = true;
			txtAmount.Enabled = true;
			txtDescription.Enabled = true;
			txtName.Enabled = true;
			txtProbability.Enabled = true;
			txtUnits.Enabled = true;
			txtUnits.Text = "1";
			lblSold.Visible = false;

			lblUnits.Visible = IsTrackHousing;
			txtUnits.Visible = IsTrackHousing;

			DlblAverage.BackColor = System.Drawing.Color.WhiteSmoke;
			DlblCustCount.BackColor = System.Drawing.Color.WhiteSmoke;
			DlblQuoteCount.BackColor = System.Drawing.Color.WhiteSmoke;
			DlblValue.BackColor = System.Drawing.Color.WhiteSmoke;

			this.State = BoundaryState.Adding;

			cboSupport.SelectedValue = thisUser.ID;
			cboSalesRep.SelectedValue = thisUser.ID;

			this.IsDirty = false;
			this.Title = "Add New Quote";
		}

		private void SetEditingMode()
		{
			this.State = BoundaryState.Loading;
			this.Clear();

			RestoreSalesSupport();

			clsMyProjectDepartment = GetProjectDepartment(MyQuote.ProjectID, MyQuote.DepartmentID);

			bool IsOutstanding = (MyProjectDepartment.Status == rkcrm.Objects.Project.Project.ProjectStatus.Outstanding);

			cboContact.Enabled = IsOutstanding && !MyQuote.IsArchived;
			cboDepartment.Enabled = IsOutstanding && !MyQuote.IsArchived;
			cboMethod.Enabled = IsOutstanding && !MyQuote.IsArchived;
			cboSalesRep.Enabled = IsOutstanding && !MyQuote.IsArchived;
			cboSupport.Enabled = IsOutstanding && !MyQuote.IsArchived;
			mtxtExpShip.Enabled = IsOutstanding && !MyQuote.IsArchived;
			txtAmount.Enabled = IsOutstanding && !MyQuote.IsArchived;
			txtDescription.Enabled = IsOutstanding && !MyQuote.IsArchived;
			txtName.Enabled = IsOutstanding && !MyQuote.IsArchived;
			txtProbability.Enabled = IsOutstanding && !MyQuote.IsArchived;
			txtUnits.Enabled = IsOutstanding && !MyQuote.IsArchived;

			lblUnits.Visible = IsTrackHousing;
			txtUnits.Visible = IsTrackHousing;

			DlblAverage.BackColor = System.Drawing.Color.White;
			DlblCustCount.BackColor = System.Drawing.Color.White;
			DlblQuoteCount.BackColor = System.Drawing.Color.White;
			DlblValue.BackColor = System.Drawing.Color.White;
			lblSold.Visible = MyQuote.IsSold && !MyQuote.IsArchived;

			if (!MyQuote.IsArchived)
			{
				using (Project.ProjectController theController = new rkcrm.Objects.Project.ProjectController())
				{
					DataTable statusInfo = theController.GetProjectCalculations(MyQuote.ProjectID, MyQuote.DepartmentID);

					if (statusInfo.Rows.Count > 0)
					{
						DlblAverage.Text = Convert.ToDecimal(statusInfo.Rows[0]["average"]).ToString("C");
						DlblCustCount.Text = statusInfo.Rows[0]["cust_count"].ToString();
						DlblQuoteCount.Text = statusInfo.Rows[0]["quote_count"].ToString();
						DlblValue.Text = Convert.ToDecimal(statusInfo.Rows[0]["value"]).ToString("C");
					}
				}
			}

			cboContact.SelectedValue = MyQuote.ContactID;
			cboDepartment.SelectedValue = MyQuote.DepartmentID;
			cboMethod.SelectedValue = MyQuote.MethodID;
			cboSalesRep.SelectedValue = MyQuote.SalesRepID;
			cboSupport.SelectedValue = MyQuote.SalesSupportID;
			txtAmount.Text = MyQuote.Amount.ToString("C");
			txtDescription.Text = MyQuote.Description;
			txtName.Text = MyQuote.Name;
			mtxtExpShip.Text = (MyProjectDepartment.ExpectedShip != DateTime.MinValue ? MyProjectDepartment.ExpectedShip.ToString("MM/dd/yy") : string.Empty);
			txtProbability.Text = FormatPercent(MyProjectDepartment.Probability);
			txtUnits.Text = MyProjectDepartment.Units.ToString();
			ObjectCreated = MyQuote.Created.ToString("M/d/yyyy HH:mm:ss");
			ObjectCreatedBy = MyQuote.GetCreator().UserName;
			ObjectUpdated = MyQuote.Updated.ToString("M/d/yyyy HH:mm:ss");
			ObjectUpdatedBy = MyQuote.GetUpdater().UserName;

			if (cboDepartment.SelectedItem != null)
				TruncateSalesSupport();

			if (cboContact.SelectedItem == null)
				cboContact.Text = MyQuote.GetPersonContacted().FullName;
			if (cboDepartment.SelectedItem == null)
				cboDepartment.Text = MyQuote.GetDepartment().Name;
			if (cboMethod.SelectedItem == null)
				cboMethod.Text = MyQuote.GetContactMethod().Name;
			if (cboSalesRep.SelectedItem == null)
				cboSalesRep.Text = MyQuote.GetSalesRep().FullName;
			if (cboSupport.SelectedItem == null)
				cboSupport.Text = MyQuote.GetSalesSupport().FullName;

			this.IsDirty = false;
			this.State = BoundaryState.Editing;
			this.Title = "Edit Quote";
		}

		private void SetSearchingMode()
		{
			this.State = BoundaryState.Loading;
			this.Clear();

			cboContact.Enabled = false;
			cboDepartment.Enabled = false;
			cboMethod.Enabled = false;
			cboSalesRep.Enabled = false;
			cboSupport.Enabled = false;
			mtxtExpShip.Enabled = false;
			txtAmount.Enabled = false;
			txtDescription.Enabled = false;
			txtName.Enabled = true;
			txtProbability.Enabled = false;
			txtUnits.Enabled = false;

			lblUnits.Visible = false;
			txtUnits.Visible = false;

			DlblAverage.BackColor = System.Drawing.Color.WhiteSmoke;
			DlblCustCount.BackColor = System.Drawing.Color.WhiteSmoke;
			DlblQuoteCount.BackColor = System.Drawing.Color.WhiteSmoke;
			DlblValue.BackColor = System.Drawing.Color.WhiteSmoke;

			if (clsMyProjectDepartment != null)
			{
				clsMyProjectDepartment.Dispose();
				clsMyProjectDepartment = null;
			}

			RestoreSalesSupport();

			this.IsDirty = false;
			this.State = BoundaryState.Searching;
			this.Title = "Search Quotes";
		}

		internal bool CommitChanges()
		{
			try
			{
				if (cboContact.Enabled && !IsSelectionValid(cboContact) && cboContact.Text != MyQuote.GetPersonContacted().FullName || string.IsNullOrEmpty(cboContact.Text))
					throw new Exception("The \"Person Contacted\" is not valid.");
				if (!IsSelectionValid(cboDepartment) && cboDepartment.Text != MyQuote.GetDepartment().Name || string.IsNullOrEmpty(cboDepartment.Text))
					throw new Exception("The \"Department\" is not valid.");
                if (cboDepartment.SelectedValue != null && !HasLeadSource())
                    throw new Exception("You must add a lead source for the " + cboDepartment.Text + " department before saving this quote.");
                if (!IsSelectionValid(cboMethod) && cboMethod.Text != MyQuote.GetContactMethod().Name || string.IsNullOrEmpty(cboMethod.Text))
                    throw new Exception("The \"Contact Method\" is not valid.");
				if (!IsSelectionValid(cboSalesRep) && cboSalesRep.Text != MyQuote.GetSalesRep().FullName || string.IsNullOrEmpty(cboSalesRep.Text))
					throw new Exception("The \"Sales Rep\" is not valid.");
				if (!IsSelectionValid(cboSupport) && cboSupport.Text != MyQuote.GetSalesSupport().FullName || string.IsNullOrEmpty(cboSupport.Text))
					throw new Exception("The \"Sales Support\" is not valid.");
				if (string.IsNullOrEmpty(txtAmount.Text))
					throw new Exception("The \"Amount\" cannot be blank.");
				if (Convert.ToDecimal(txtAmount.Text.Trim('$')) <= 0)
					throw new Exception("The \"Amount\" must be greater than 0.");
				if (string.IsNullOrEmpty(txtName.Text))
					throw new Exception("The \"Quote Number\" cannot be blank.");
				if (string.IsNullOrEmpty(txtProbability.Text))
					throw new Exception("The \"Prob%\" cannot be blank.");
				if (Convert.ToDecimal(txtProbability.Text.Trim('%')) <= 0 || Convert.ToDecimal(txtProbability.Text.Trim('%')) > 100)
					throw new Exception("The \"Prob%\" must be between 1 and 100.");
				if (string.IsNullOrEmpty(txtUnits.Text))
					throw new Exception("The \"Units\" cannot be blank.");
				if (Convert.ToInt32(txtUnits.Text) <= 0)
					throw new Exception("The \"Units\" must be greater 0.");
				if (mtxtExpShip.MaskCompleted && Convert.ToDateTime(mtxtExpShip.Text) < DateTime.Today)
					throw new Exception("The \"Exp. Ship Date\" must be today or later.");


				if (cboContact.SelectedValue != null)
					MyQuote.ContactID = Convert.ToInt32(cboContact.SelectedValue);
				if (cboDepartment.SelectedValue != null)
					MyQuote.DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
				if (cboMethod.SelectedValue != null)
					MyQuote.MethodID = Convert.ToInt32(cboMethod.SelectedValue);
				if (cboSalesRep.SelectedValue != null)
					MyQuote.SalesRepID = Convert.ToInt32(cboSalesRep.SelectedValue);
				if (cboSupport.SelectedValue != null)
					MyQuote.SalesSupportID = Convert.ToInt32(cboSupport.SelectedValue);
				if (mtxtExpShip.MaskCompleted)
					MyProjectDepartment.ExpectedShip = Convert.ToDateTime(mtxtExpShip.Text);
				MyQuote.Description = txtDescription.Text;
				MyQuote.Name = txtName.Text;
				MyProjectDepartment.Probability = Convert.ToDecimal(txtProbability.Text.Trim('%')) / 100;
				MyProjectDepartment.Units = Convert.ToInt32(txtUnits.Text);
				MyQuote.Amount = Convert.ToDecimal(txtAmount.Text.Trim('$'));
				

				return true;

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		private void TruncateSalesSupport()
		{
			// Store the already selected values for sales rep and sales support
			DataRowView salesRep = (DataRowView)cboSalesRep.SelectedItem;
			DataRowView salesSupport = (DataRowView)cboSupport.SelectedItem;
			BoundaryState current = this.State;
			this.State = BoundaryState.Loading;

			cboSupport.DataSource = GetDepartmentReps(Convert.ToInt32(cboDepartment.SelectedValue));
			cboSupport.DisplayMember = "name";
			cboSupport.ValueMember = "user_id";
			cboSupport.SelectedItem = null;

			// restore the original sales support if possible
			if (salesSupport != null)
				if (Convert.ToInt32(salesSupport["department_id"]) == Convert.ToInt32(cboDepartment.SelectedValue))
					cboSupport.SelectedValue = Convert.ToInt32(salesSupport["user_id"]);

			if (salesRep != null)
			{
				// Only defualt the sales support when it is not already selected
				if (cboSupport.SelectedItem == null && Convert.ToInt32(salesRep["department_id"]) == Convert.ToInt32(cboDepartment.SelectedValue))
					cboSupport.SelectedValue = cboSalesRep.SelectedValue;
			}

			this.State = current;
		}

		private void RestoreSalesSupport()
		{
			if (AvailableSalesReps != null && AvailableSalesReps.Rows.Count != ((DataTable)cboSupport.DataSource).Rows.Count)
			{
				cboSupport.DataSource = AvailableSalesReps.Copy();
				cboSupport.DisplayMember = "name";
				cboSupport.ValueMember = "user_id";
				cboSupport.SelectedItem = null;
			}
		}

        private bool HasLeadSource()
        {
            bool result = false;
            int DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue);
            Customer.Customer myCustomer = MyQuote.GetProject().GetCustomer();

            if (!base.HasLeadSource(myCustomer.ID, DepartmentID))
            {
                Objects.Customer.Lead_Source.AddLeadSource addSourceForm = new rkcrm.Objects.Customer.Lead_Source.AddLeadSource();
                addSourceForm.MyCustomer = myCustomer;
                addSourceForm.Title = "How did they hear about the " + cboDepartment.Text + " department?";
                addSourceForm.DepartmentID = DepartmentID;

                addSourceForm.ShowDialog();

                if (addSourceForm.DialogResult == DialogResult.OK)
                {
                    result = true;

                    //If the customer screen exists then refresh it so the new lead source appears
                    RefreshCustomer();
                }
            }
            else
                result = true;

            return result;
        }


		#endregion


		#region Event Handlers

		private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cboDepartment.SelectedItem != null)
			{

				if ((this.State == BoundaryState.Editing || this.State == BoundaryState.Adding) && cboDepartment.SelectedValue != null)
				{
					int count = 0;

					clsMyProjectDepartment = GetProjectDepartment(MyQuote.ProjectID, Convert.ToInt32(cboDepartment.SelectedValue));

					if (MyProjectDepartment.Status != rkcrm.Objects.Project.Project.ProjectStatus.Outstanding)
					{
						clsMyProjectDepartment = GetNewProjectDepartment(MyProjectDepartment.ProjectID, MyProjectDepartment.DepartmentID);

						using (QuoteController theController = new QuoteController())
						{
							count = theController.GetQuoteCount(MyProjectDepartment.ProjectID, MyProjectDepartment.DepartmentID);
						}

						if (count > 0)
							SetDepartmentDefualts();
					}
				}

				if (!(cboDepartment.SelectedValue is DataRowView))
					TruncateSalesSupport();
			}
			else
				RestoreSalesSupport();
		}

		private void cboSupport_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cboSupport.SelectedItem != null)
			{
				if ((this.State == BoundaryState.Editing || this.State == BoundaryState.Adding) && cboDepartment.Enabled)
				{
					BoundaryState current = this.State;
					this.State = BoundaryState.Loading;

					DataRowView salesSupport = (DataRowView)cboSupport.SelectedItem;
					cboDepartment.SelectedValue = Convert.ToInt32(salesSupport["department_id"]);

					TruncateSalesSupport();

					if (cboSalesRep.SelectedItem == null)
						cboSalesRep.SelectedValue = cboSupport.SelectedValue;

					this.State = current;
				}
			}
		}

		private void control_Changed(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Editing || this.State == BoundaryState.Adding)
				this.IsDirty = true;
		}

		private void txtAmount_Leave(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtAmount.Text))
			{
				try
				{
					decimal amount = Convert.ToDecimal(txtAmount.Text.Trim('$'));

					if (amount < 0)
						throw new Exception("The amount must be greater than zero.");

					txtAmount.Text = amount.ToString("C");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void txtProbability_Leave(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtProbability.Text))
			{
				try
				{
					decimal percent = Convert.ToDecimal(txtProbability.Text.Trim('%'));

					if (percent > 100)
						throw new Exception("The probability percent must be less than 100%.");
					if (percent < 0)
						throw new Exception("The probability percent must be greater than 0%.");

					txtProbability.Text = FormatPercent(percent);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void cboContact_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (Convert.ToInt32(cboContact.SelectedValue) == 0)
			{
				Contact.AddContact oForm = new rkcrm.Objects.Contact.AddContact();
				oForm.MyContact = new rkcrm.Objects.Contact.Contact();
				oForm.MyContact.CustomerID = MyQuote.GetProject().CustomerID;

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					LoadContacts();
					foreach (DataRowView oRow in cboContact.Items)
					{
						if (Convert.ToInt32(oRow["contact_id"]) == oForm.MyContact.ID)
							cboContact.SelectedItem = oRow;
					}
				}
				else
					cboContact.SelectedItem = null;
			}
		}

		#endregion


		#region Events

		public event EventHandler<EventArgs> MyQuoteChanged;
		protected virtual void OnMyQuoteChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = MyQuoteChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion


		#region Constructor

		public QuoteBoundary()
			: base()
		{
			this.State = BoundaryState.Loading;

			InitializeComponent();

			//Fill the sales rep combo box with avaiable sales reps whose home department is a profit center
			using (UserController theController = new UserController())
			{
				AvailableSalesReps = theController.GetAvailableEmployees();
				cboSalesRep.DataSource = AvailableSalesReps;
				cboSalesRep.DisplayMember = "name";
				cboSalesRep.ValueMember = "user_id";
				cboSalesRep.SelectedItem = null;

				cboSupport.DataSource = AvailableSalesReps.Copy();
				cboSupport.DisplayMember = "name";
				cboSupport.ValueMember = "user_id";
				cboSupport.SelectedItem = null;
			}

			//Fill the department combo box with profit center departments
			using (DepartmentController theController = new DepartmentController())
			{
				cboDepartment.DataSource = theController.GetProfitCenters();
				cboDepartment.DisplayMember = "name";
				cboDepartment.ValueMember = "department_id";
				cboDepartment.SelectedItem = null;
			}

			//Fill the contact method combo box with all available contact methods
			using (ContactMethodController theController = new ContactMethodController())
			{
				cboMethod.DataSource = theController.GetContactMethods();
				cboMethod.DisplayMember = "name";
				cboMethod.ValueMember = "method_id";
				cboMethod.SelectedItem = null;
			}

			SetSearchingMode();

		}

		#endregion

	}
}
