using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;
using rkcrm.Event_Arguments;
using rkcrm.Navigation;
using rkcrm.Objects.Customer;
using rkcrm.Objects.Project;
using rkcrm.Searching.DropDowns;

namespace rkcrm.Searching
{
    class CustomerSearchScreen : SearchScreenBase
    {

		#region Variables

		private System.Windows.Forms.ColumnHeader chCustomerID;
		private System.Windows.Forms.ColumnHeader chCustomerName;
		private System.Windows.Forms.ColumnHeader chContact;
		private System.Windows.Forms.ColumnHeader chPhoneNumber;
		private System.Windows.Forms.GroupBox gbxProjects;
		private System.Windows.Forms.GroupBox gbxSalesHistory;
		private System.Windows.Forms.GroupBox gbxGeneralInfo;
		private System.Windows.Forms.ListView lvwProjects;
		private System.Windows.Forms.ColumnHeader chProjectID;
		private System.Windows.Forms.ColumnHeader chProjectName;
		private System.Windows.Forms.ColumnHeader chAddess;
		private System.Windows.Forms.ColumnHeader chCity;
		private System.Windows.Forms.ColumnHeader chType;
		internal System.Windows.Forms.Label DlblCCExpiration;
		internal System.Windows.Forms.Label lblCCExpiration;
		internal System.Windows.Forms.Label lblCustomerStatus;
		internal System.Windows.Forms.Label DlblFSD;
		internal System.Windows.Forms.Label lblFSD;
		internal System.Windows.Forms.Label DlblAccountTerms;
		internal System.Windows.Forms.Label DlblFalconNumber;
		internal System.Windows.Forms.Label DlblTaxExempt;
		internal System.Windows.Forms.Label lblAccountTerms;
		internal System.Windows.Forms.Label lblFalconNumber;
		internal System.Windows.Forms.Label lblTaxExempt;
		private System.Windows.Forms.ListView lvwSalesHistory;
		private System.Windows.Forms.ColumnHeader chDepartment;
		private System.Windows.Forms.ColumnHeader chLastSale;
		private System.Windows.Forms.ColumnHeader chAmount;
		private System.Windows.Forms.ColumnHeader chRep;
		private System.Windows.Forms.ColumnHeader chTerms;
		private System.Windows.Forms.ColumnHeader chYTD;
		private System.Windows.Forms.ColumnHeader chLYS;
		private ColumnHeader chEmail;
		private ColumnHeader chProjectCustomerID;
		private System.Windows.Forms.ColumnHeader chContactID;

		private const int CUSTOMER_INDEX = 2;
		private const int CONTACT_ID_INDEX = 1;
		private const int ADMINISTRATOR = 1;

		#endregion


        #region Methods

		/// <summary>
		/// Clears the entire screen of all data
		/// </summary>
        public new void Clear()
        {
            base.Clear();

			ClearResults();
		}

		/// <summary>
		/// Clears those controls that are used to display search results
		/// </summary>
		private new void ClearResults()
		{
			base.ClearResults();

			ClearPreview();
		}

		/// <summary>
		/// Clears all data from the controls in scMain.Panel2
		/// </summary>
		private void ClearPreview()
		{
			if (lvwProjects.SelectedItems.Count > 0)
				//This fires the ItemSelectionChanged event on the individual drop down objects
				lvwProjects.SelectedItems[0].Selected = false;

			lvwProjects.Items.Clear();
			lvwProjects.Sorting = SortOrder.None;
			lvwProjects.ListViewItemSorter = null;
			lvwSalesHistory.Items.Clear();

			DlblAccountTerms.Text = string.Empty;
			DlblCCExpiration.Text = string.Empty;
			DlblFalconNumber.Text = string.Empty;
			DlblFSD.Text = string.Empty;
			DlblTaxExempt.Text = string.Empty;
			DlblCCExpiration.BackColor = Color.Transparent;
			DlblTaxExempt.BackColor = Color.Transparent;

			lblCustomerStatus.Visible = false;
		}

		/// <summary>
		/// Determines if the provided string contains one or more letters
		/// </summary>
		/// <param name="theText"></param>
		/// <returns></returns>
		private bool ContainsLetters(string theText)
		{
			bool value = false;

			foreach (char oChar in theText.ToCharArray())
				if (char.IsLetter(oChar))
					value = true;

			return value;
		}

		/// <summary>
		/// Format the given string to (xxx) xxx-xxxx
		/// </summary>
		/// <param name="PhoneNumber"></param>
		/// <returns></returns>
		private string FormatPhoneNumber(string PhoneNumber)
		{
			PhoneNumber = PhoneNumber.Insert(0, "(");
			PhoneNumber = PhoneNumber.Insert(4, ") ");
			PhoneNumber = PhoneNumber.Insert(9, "-");

			return PhoneNumber;
		}

        private void InitializeComponent()
        {
			this.chCustomerID = new System.Windows.Forms.ColumnHeader();
			this.chContactID = new System.Windows.Forms.ColumnHeader();
			this.chCustomerName = new System.Windows.Forms.ColumnHeader();
			this.chContact = new System.Windows.Forms.ColumnHeader();
			this.chPhoneNumber = new System.Windows.Forms.ColumnHeader();
			this.gbxProjects = new System.Windows.Forms.GroupBox();
			this.lvwProjects = new System.Windows.Forms.ListView();
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.chProjectCustomerID = new System.Windows.Forms.ColumnHeader();
			this.chProjectName = new System.Windows.Forms.ColumnHeader();
			this.chAddess = new System.Windows.Forms.ColumnHeader();
			this.chCity = new System.Windows.Forms.ColumnHeader();
			this.chType = new System.Windows.Forms.ColumnHeader();
			this.gbxGeneralInfo = new System.Windows.Forms.GroupBox();
			this.DlblCCExpiration = new System.Windows.Forms.Label();
			this.lblCCExpiration = new System.Windows.Forms.Label();
			this.lblCustomerStatus = new System.Windows.Forms.Label();
			this.DlblFSD = new System.Windows.Forms.Label();
			this.lblFSD = new System.Windows.Forms.Label();
			this.DlblAccountTerms = new System.Windows.Forms.Label();
			this.DlblFalconNumber = new System.Windows.Forms.Label();
			this.DlblTaxExempt = new System.Windows.Forms.Label();
			this.lblAccountTerms = new System.Windows.Forms.Label();
			this.lblFalconNumber = new System.Windows.Forms.Label();
			this.lblTaxExempt = new System.Windows.Forms.Label();
			this.gbxSalesHistory = new System.Windows.Forms.GroupBox();
			this.lvwSalesHistory = new System.Windows.Forms.ListView();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chLastSale = new System.Windows.Forms.ColumnHeader();
			this.chAmount = new System.Windows.Forms.ColumnHeader();
			this.chRep = new System.Windows.Forms.ColumnHeader();
			this.chTerms = new System.Windows.Forms.ColumnHeader();
			this.chYTD = new System.Windows.Forms.ColumnHeader();
			this.chLYS = new System.Windows.Forms.ColumnHeader();
			this.chEmail = new System.Windows.Forms.ColumnHeader();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.gbxProjects.SuspendLayout();
			this.gbxGeneralInfo.SuspendLayout();
			this.gbxSalesHistory.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwResults
			// 
			this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCustomerID,
            this.chContactID,
            this.chCustomerName,
            this.chContact,
            this.chPhoneNumber,
            this.chEmail});
			this.lvwResults.DoubleClick += new System.EventHandler(this.lvwResults_DoubleClick);
			this.lvwResults.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwResults_ItemSelectionChanged);
			// 
			// btnClearSearch
			// 
			this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// scMain
			// 
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Controls.Add(this.gbxSalesHistory);
			this.scMain.Panel2.Controls.Add(this.gbxGeneralInfo);
			this.scMain.Panel2.Controls.Add(this.gbxProjects);
			// 
			// chCustomerID
			// 
			this.chCustomerID.Text = "Customer ID";
			this.chCustomerID.Width = 0;
			// 
			// chContactID
			// 
			this.chContactID.Text = "Contact ID";
			this.chContactID.Width = 0;
			// 
			// chCustomerName
			// 
			this.chCustomerName.Text = "Customer";
			this.chCustomerName.Width = 150;
			// 
			// chContact
			// 
			this.chContact.Text = "Contact";
			this.chContact.Width = 150;
			// 
			// chPhoneNumber
			// 
			this.chPhoneNumber.Text = "Phone Number";
			this.chPhoneNumber.Width = 100;
			// 
			// gbxProjects
			// 
			this.gbxProjects.Controls.Add(this.lvwProjects);
			this.gbxProjects.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxProjects.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbxProjects.Location = new System.Drawing.Point(3, 3);
			this.gbxProjects.Name = "gbxProjects";
			this.gbxProjects.Size = new System.Drawing.Size(575, 110);
			this.gbxProjects.TabIndex = 0;
			this.gbxProjects.TabStop = false;
			this.gbxProjects.Text = "Project List";
			// 
			// lvwProjects
			// 
			this.lvwProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProjectID,
            this.chProjectCustomerID,
            this.chProjectName,
            this.chAddess,
            this.chCity,
            this.chType});
			this.lvwProjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvwProjects.FullRowSelect = true;
			this.lvwProjects.HideSelection = false;
			this.lvwProjects.Location = new System.Drawing.Point(3, 22);
			this.lvwProjects.MultiSelect = false;
			this.lvwProjects.Name = "lvwProjects";
			this.lvwProjects.Size = new System.Drawing.Size(569, 85);
			this.lvwProjects.TabIndex = 0;
			this.lvwProjects.UseCompatibleStateImageBehavior = false;
			this.lvwProjects.View = System.Windows.Forms.View.Details;
			this.lvwProjects.DoubleClick += new System.EventHandler(this.lvwProjects_DoubleClick);
			// 
			// chProjectID
			// 
			this.chProjectID.Text = "Project ID";
			this.chProjectID.Width = 0;
			// 
			// chProjectCustomerID
			// 
			this.chProjectCustomerID.Text = "Customer ID";
			this.chProjectCustomerID.Width = 0;
			// 
			// chProjectName
			// 
			this.chProjectName.Text = "Project Name";
			this.chProjectName.Width = 150;
			// 
			// chAddess
			// 
			this.chAddess.Text = "Address";
			this.chAddess.Width = 200;
			// 
			// chCity
			// 
			this.chCity.Text = "City";
			// 
			// chType
			// 
			this.chType.Text = "Project Type";
			this.chType.Width = 100;
			// 
			// gbxGeneralInfo
			// 
			this.gbxGeneralInfo.Controls.Add(this.DlblCCExpiration);
			this.gbxGeneralInfo.Controls.Add(this.lblCCExpiration);
			this.gbxGeneralInfo.Controls.Add(this.lblCustomerStatus);
			this.gbxGeneralInfo.Controls.Add(this.DlblFSD);
			this.gbxGeneralInfo.Controls.Add(this.lblFSD);
			this.gbxGeneralInfo.Controls.Add(this.DlblAccountTerms);
			this.gbxGeneralInfo.Controls.Add(this.DlblFalconNumber);
			this.gbxGeneralInfo.Controls.Add(this.DlblTaxExempt);
			this.gbxGeneralInfo.Controls.Add(this.lblAccountTerms);
			this.gbxGeneralInfo.Controls.Add(this.lblFalconNumber);
			this.gbxGeneralInfo.Controls.Add(this.lblTaxExempt);
			this.gbxGeneralInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxGeneralInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbxGeneralInfo.Location = new System.Drawing.Point(3, 113);
			this.gbxGeneralInfo.Name = "gbxGeneralInfo";
			this.gbxGeneralInfo.Size = new System.Drawing.Size(575, 74);
			this.gbxGeneralInfo.TabIndex = 1;
			this.gbxGeneralInfo.TabStop = false;
			this.gbxGeneralInfo.Text = "General Information";
			// 
			// DlblCCExpiration
			// 
			this.DlblCCExpiration.AutoSize = true;
			this.DlblCCExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DlblCCExpiration.Location = new System.Drawing.Point(132, 47);
			this.DlblCCExpiration.Name = "DlblCCExpiration";
			this.DlblCCExpiration.Size = new System.Drawing.Size(39, 13);
			this.DlblCCExpiration.TabIndex = 24;
			this.DlblCCExpiration.Text = "display";
			// 
			// lblCCExpiration
			// 
			this.lblCCExpiration.AutoSize = true;
			this.lblCCExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCCExpiration.Location = new System.Drawing.Point(14, 47);
			this.lblCCExpiration.Name = "lblCCExpiration";
			this.lblCCExpiration.Size = new System.Drawing.Size(112, 13);
			this.lblCCExpiration.TabIndex = 23;
			this.lblCCExpiration.Text = "Credit Card on File";
			// 
			// lblCustomerStatus
			// 
			this.lblCustomerStatus.AutoSize = true;
			this.lblCustomerStatus.BackColor = System.Drawing.Color.LightSteelBlue;
			this.lblCustomerStatus.ForeColor = System.Drawing.Color.Black;
			this.lblCustomerStatus.Location = new System.Drawing.Point(414, 20);
			this.lblCustomerStatus.Name = "lblCustomerStatus";
			this.lblCustomerStatus.Size = new System.Drawing.Size(147, 18);
			this.lblCustomerStatus.TabIndex = 22;
			this.lblCustomerStatus.Text = "Record Deactivated";
			this.lblCustomerStatus.Visible = false;
			// 
			// DlblFSD
			// 
			this.DlblFSD.AutoSize = true;
			this.DlblFSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DlblFSD.Location = new System.Drawing.Point(297, 52);
			this.DlblFSD.Name = "DlblFSD";
			this.DlblFSD.Size = new System.Drawing.Size(39, 13);
			this.DlblFSD.TabIndex = 21;
			this.DlblFSD.Text = "display";
			// 
			// lblFSD
			// 
			this.lblFSD.AutoSize = true;
			this.lblFSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFSD.Location = new System.Drawing.Point(200, 52);
			this.lblFSD.Name = "lblFSD";
			this.lblFSD.Size = new System.Drawing.Size(91, 13);
			this.lblFSD.TabIndex = 20;
			this.lblFSD.Text = "First Sale Date";
			// 
			// DlblAccountTerms
			// 
			this.DlblAccountTerms.AutoSize = true;
			this.DlblAccountTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DlblAccountTerms.Location = new System.Drawing.Point(297, 34);
			this.DlblAccountTerms.Name = "DlblAccountTerms";
			this.DlblAccountTerms.Size = new System.Drawing.Size(39, 13);
			this.DlblAccountTerms.TabIndex = 19;
			this.DlblAccountTerms.Text = "display";
			// 
			// DlblFalconNumber
			// 
			this.DlblFalconNumber.AutoSize = true;
			this.DlblFalconNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DlblFalconNumber.Location = new System.Drawing.Point(297, 16);
			this.DlblFalconNumber.Name = "DlblFalconNumber";
			this.DlblFalconNumber.Size = new System.Drawing.Size(39, 13);
			this.DlblFalconNumber.TabIndex = 18;
			this.DlblFalconNumber.Text = "display";
			// 
			// DlblTaxExempt
			// 
			this.DlblTaxExempt.AutoSize = true;
			this.DlblTaxExempt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DlblTaxExempt.Location = new System.Drawing.Point(132, 27);
			this.DlblTaxExempt.Name = "DlblTaxExempt";
			this.DlblTaxExempt.Size = new System.Drawing.Size(39, 13);
			this.DlblTaxExempt.TabIndex = 17;
			this.DlblTaxExempt.Text = "display";
			// 
			// lblAccountTerms
			// 
			this.lblAccountTerms.AutoSize = true;
			this.lblAccountTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAccountTerms.Location = new System.Drawing.Point(199, 34);
			this.lblAccountTerms.Name = "lblAccountTerms";
			this.lblAccountTerms.Size = new System.Drawing.Size(92, 13);
			this.lblAccountTerms.TabIndex = 16;
			this.lblAccountTerms.Text = "Account Terms";
			// 
			// lblFalconNumber
			// 
			this.lblFalconNumber.AutoSize = true;
			this.lblFalconNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFalconNumber.Location = new System.Drawing.Point(205, 16);
			this.lblFalconNumber.Name = "lblFalconNumber";
			this.lblFalconNumber.Size = new System.Drawing.Size(86, 13);
			this.lblFalconNumber.TabIndex = 15;
			this.lblFalconNumber.Text = "Falcon Cust #";
			// 
			// lblTaxExempt
			// 
			this.lblTaxExempt.AutoSize = true;
			this.lblTaxExempt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTaxExempt.Location = new System.Drawing.Point(22, 27);
			this.lblTaxExempt.Name = "lblTaxExempt";
			this.lblTaxExempt.Size = new System.Drawing.Size(104, 13);
			this.lblTaxExempt.TabIndex = 14;
			this.lblTaxExempt.Text = "Tax Exempt Cert.";
			// 
			// gbxSalesHistory
			// 
			this.gbxSalesHistory.Controls.Add(this.lvwSalesHistory);
			this.gbxSalesHistory.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxSalesHistory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbxSalesHistory.Location = new System.Drawing.Point(3, 187);
			this.gbxSalesHistory.Name = "gbxSalesHistory";
			this.gbxSalesHistory.Size = new System.Drawing.Size(575, 174);
			this.gbxSalesHistory.TabIndex = 2;
			this.gbxSalesHistory.TabStop = false;
			this.gbxSalesHistory.Text = "Sales History";
			// 
			// lvwSalesHistory
			// 
			this.lvwSalesHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDepartment,
            this.chLastSale,
            this.chAmount,
            this.chRep,
            this.chTerms,
            this.chYTD,
            this.chLYS});
			this.lvwSalesHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwSalesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvwSalesHistory.FullRowSelect = true;
			this.lvwSalesHistory.GridLines = true;
			this.lvwSalesHistory.HideSelection = false;
			this.lvwSalesHistory.Location = new System.Drawing.Point(3, 22);
			this.lvwSalesHistory.Name = "lvwSalesHistory";
			this.lvwSalesHistory.Size = new System.Drawing.Size(569, 149);
			this.lvwSalesHistory.TabIndex = 0;
			this.lvwSalesHistory.UseCompatibleStateImageBehavior = false;
			this.lvwSalesHistory.View = System.Windows.Forms.View.Details;
			// 
			// chDepartment
			// 
			this.chDepartment.Text = "Department";
			this.chDepartment.Width = 70;
			// 
			// chLastSale
			// 
			this.chLastSale.Text = "Last Sale";
			// 
			// chAmount
			// 
			this.chAmount.Text = "Last Sale Amount";
			this.chAmount.Width = 95;
			// 
			// chRep
			// 
			this.chRep.Text = "Last Sales Rep";
			this.chRep.Width = 85;
			// 
			// chTerms
			// 
			this.chTerms.Text = "Last Invoice Terms";
			this.chTerms.Width = 105;
			// 
			// chYTD
			// 
			this.chYTD.Text = "Year-To-Date Sales";
			this.chYTD.Width = 105;
			// 
			// chLYS
			// 
			this.chLYS.Text = "Last Year Sales";
			this.chLYS.Width = 90;
			// 
			// chEmail
			// 
			this.chEmail.Text = "Email Address";
			this.chEmail.Width = 160;
			// 
			// CustomerSearchScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "CustomerSearchScreen";
			this.ScreenTitle = "Customer Search";
			this.Load += new System.EventHandler(this.CustomerSearchScreen_Load);
			this.Controls.SetChildIndex(this.scMain, 0);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel1.PerformLayout();
			this.scMain.Panel2.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.gbxProjects.ResumeLayout(false);
			this.gbxGeneralInfo.ResumeLayout(false);
			this.gbxGeneralInfo.PerformLayout();
			this.gbxSalesHistory.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        private void InitializeDropDowns()
        {
            int index = 0;

			//Load the Actions button with customer options
            using (CustomerDropDown myItems = new CustomerDropDown(lvwResults, 0))
            {
				myItems.ActivityStatusChanged += new EventHandler<ActivityStatusChangedEventArgs>(customerItems_ActivityStatusChanged);

				while (myItems.Items.Count > 0 && index < myItems.Items.Count)
                {
                    if (myItems.Items[index] is ToolStripDropDownButton)
                        while (((ToolStripDropDownButton)myItems.Items[index]).DropDownItems.Count > 0)
                            tsmActions.DropDownItems.Add(((ToolStripDropDownButton)myItems.Items[index]).DropDownItems[0]);
                    index++;
                }
            }

            index = 0;

			//Load the results context menu with customer options
            using (CustomerDropDown myItems = new CustomerDropDown(lvwResults, 0))
            {
				myItems.ActivityStatusChanged += new EventHandler<ActivityStatusChangedEventArgs>(customerItems_ActivityStatusChanged);
				
				while (myItems.Items.Count > 0 && index < myItems.Items.Count)
                {
                    if (myItems.Items[index] is ToolStripDropDownButton)
                    {
                        while (((ToolStripDropDownButton)myItems.Items[index]).DropDownItems.Count > 0)
                            cmsResults.Items.Add(((ToolStripDropDownButton)myItems.Items[index]).DropDownItems[0]);
                        index++;
                    }
                    else
                        tsMain.Items.Add(myItems.Items[index]);

                }
            }

			index = 0;

			//Add EditContact from the ContactDropDown to all CustomerDropDowns
			using (ContactDropDown myItems = new ContactDropDown(lvwResults, 1))
			{
				while (myItems.Items.Count > 0 && index < myItems.Items.Count)
				{
					if (myItems.Items[index] is ToolStripDropDownButton)
					{
						int internalIndex = 0;
						while (internalIndex < ((ToolStripDropDownButton)myItems.Items[index]).DropDownItems.Count)
							switch (((ToolStripDropDownButton)myItems.Items[index]).DropDownItems[internalIndex].Name)
							{
								case "tsmEdit":
									cmsResults.Items.Insert(4, ((ToolStripDropDownButton)myItems.Items[index]).DropDownItems[internalIndex]);
									cmsResults.Items.Insert(5, new ToolStripSeparator());
									break;
								case "tsmProperties":
									((ToolStripDropDownButton)myItems.Items[index]).DropDownItems[internalIndex].Visible = false;
									cmsResults.Items.Insert(cmsResults.Items.Count - 1, ((ToolStripDropDownButton)myItems.Items[index]).DropDownItems[internalIndex]);
									break;
								default:
									internalIndex++;
									break;
							}

						index++;
					}
					else
						switch (myItems.Items[index].Name)
						{
							case "tsbEdit":
								tsMain.Items.Insert(4, myItems.Items[index]);
								tsMain.Items.Insert(5, new ToolStripSeparator());
								break;
							case "tsbProperties":
								myItems.Items[index].Visible = false;
								tsMain.Items.Insert(tsMain.Items.Count - 1, myItems.Items[index]);
								break;
							default:
								index++;
								break;
						}
				}
			}

			using (ContactDropDown myItems = new ContactDropDown(lvwResults, 1))
			{
				foreach(ToolStripItem oItem in myItems.Items)
					if (oItem is ToolStripDropDownButton)
					{
						index = 0;
						while (index < ((ToolStripDropDownButton)oItem).DropDownItems.Count)
							switch (((ToolStripDropDownButton)oItem).DropDownItems[index].Name)
							{
								case "tsmEdit":
									tsmActions.DropDownItems.Insert(4, ((ToolStripDropDownButton)oItem).DropDownItems[index]);
									tsmActions.DropDownItems.Insert(5, new ToolStripSeparator());
									break;
								case "tsmProperties":
									((ToolStripDropDownButton)oItem).DropDownItems[index].Visible = false;
									tsmActions.DropDownItems.Insert(tsmActions.DropDownItems.Count - 1, ((ToolStripDropDownButton)oItem).DropDownItems[index]);
									break;
								default:
									index++;
									break;
							}
					}
			}

			//create a new context menu strip for the project list and load it with project options
			ContextMenuStrip cmsProject = new ContextMenuStrip();
			index = 0;

			using (ProjectDropDown myItems = new ProjectDropDown(lvwProjects, 0, 1))
			{
				while (myItems.Items.Count > 0 && index < myItems.Items.Count)
				{
					if (myItems.Items[index] is ToolStripDropDownButton)
						while (((ToolStripDropDownButton)myItems.Items[index]).DropDownItems.Count > 0)
							cmsProject.Items.Add(((ToolStripDropDownButton)myItems.Items[index]).DropDownItems[0]);
					index++;
				}
			}

			lvwProjects.ContextMenuStrip = cmsProject;

        }

		/// <summary>
		/// Loads the results set into the ListView object
		/// </summary>
		private void ShowResults()
		{
			DataTable dtResults;

			using (CustomerController theController = new CustomerController())
			{
				dtResults = theController.GetSearchResults(cboSearchIn.SelectedValue.ToString(), txtLookFor.Text);
			}

			if (dtResults.Rows.Count > 0)
			{
				try
				{
					ListViewGroup oGroup = null;
					ListViewItem oItem;
					ListViewItem previousItem = new ListViewItem();
					previousItem.SubItems.Add("");

					foreach (DataRow oRow in dtResults.Rows)
					{
						if (oRow["customer_id"].ToString() == previousItem.SubItems[0].Text)
						{
							oItem = new ListViewItem();
							oItem.Text = oRow["customer_id"].ToString();
							oItem.SubItems.Add(oRow["contact_id"].ToString());
							oItem.SubItems.Add(string.Empty);
							
							if (oRow["contact_id"].ToString() == previousItem.SubItems[1].Text)
								oItem.SubItems.Add(string.Empty);
							else
								oItem.SubItems.Add(oRow["first_name"].ToString() + " " + oRow["last_name"].ToString());

							oItem.SubItems.Add(FormatPhoneNumber(oRow["contact_number"].ToString()) + " " + oRow["abbreviation"].ToString());

							if (oRow["contact_id"].ToString() == previousItem.SubItems[1].Text)
								oItem.SubItems.Add(string.Empty);
							else
								oItem.SubItems.Add(oRow["email_address"].ToString());

							if (!Convert.ToBoolean(oRow["is_active"]))
								oItem.BackColor = Color.LightSteelBlue;

							oGroup.Items.Add(oItem);
							lvwResults.Items.Add(oItem);

							previousItem = oItem;
						}
						else
						{

							oGroup = new ListViewGroup();
							oGroup.Header = string.Empty;

							lvwResults.Groups.Add(oGroup);

							oItem = new ListViewItem();

							oItem.Text = oRow["customer_id"].ToString();
							oItem.SubItems.Add(string.Empty);
							oItem.SubItems.Add(oRow["customer"].ToString());
							oItem.SubItems.Add(string.Empty);
							oItem.SubItems.Add(FormatPhoneNumber(oRow["phone_number"].ToString()));
							oItem.SubItems.Add(string.Empty);

							if (!Convert.ToBoolean(oRow["is_active"]))
								oItem.BackColor = Color.LightSteelBlue;

							oGroup.Items.Add(oItem);
							lvwResults.Items.Add(oItem);

							oItem = new ListViewItem();

							oItem.Text = oRow["customer_id"].ToString();
							oItem.SubItems.Add(oRow["contact_id"].ToString());
							oItem.SubItems.Add(string.Empty);
							oItem.SubItems.Add(oRow["first_name"].ToString() + " " + oRow["last_name"].ToString());
							oItem.SubItems.Add(FormatPhoneNumber(oRow["contact_number"].ToString()) + " " + oRow["abbreviation"].ToString());
							oItem.SubItems.Add(oRow["email_address"].ToString());

							if (!Convert.ToBoolean(oRow["is_active"]))
								oItem.BackColor = Color.LightSteelBlue;

							oGroup.Items.Add(oItem);
							lvwResults.Items.Add(oItem);

							previousItem = oItem;
						}
					}

				}
				catch (Exception e)
				{
					ErrorHandler.ProcessException(e, false);
				}
			}
			else
			{
				ShowResultsMessage("No customers were found with a " + cboSearchIn.Text + " of \"" + txtLookFor.Text + "\".");
			}
		}

		/// <summary>
		/// Loads the preview data for the selected customer
		/// </summary>
		/// <param name="SelectedItem"></param>
		private void ShowPreview(ListViewItem SelectedItem)
		{
			DataSet dsPreview;

			using (CustomerController theController = new CustomerController())
			{
				dsPreview = theController.GetSearchPreview(Convert.ToInt32(SelectedItem.Text));
			}

			if (dsPreview.Tables.Count > 2)
			{
				if (dsPreview.Tables[0].Rows.Count > 0)
				{
					ListViewItem oItem;

					foreach (DataRow oRow in dsPreview.Tables[0].Rows)
					{
						oItem = new ListViewItem();
						oItem.Text = oRow["project_id"].ToString();
						oItem.SubItems.Add(oRow["customer_id"].ToString());
						oItem.SubItems.Add(oRow["name"].ToString());
						oItem.SubItems.Add(oRow["address"].ToString());
						oItem.SubItems.Add(oRow["city"].ToString());
						oItem.SubItems.Add(oRow["type"].ToString());

						if (Convert.ToBoolean(oRow["is_archived"]))
							oItem.BackColor = Color.LightSteelBlue;

						lvwProjects.Items.Add(oItem);
					}
				}

				if (dsPreview.Tables[1].Rows.Count > 0)
				{
					DataRow theRow = dsPreview.Tables[1].Rows[0];

					lblCustomerStatus.Visible = (SelectedItem.BackColor == Color.LightSteelBlue);
					DlblAccountTerms.Text = theRow["terms_code"].ToString();
					DlblFalconNumber.Text = theRow["falcon_id"].ToString();
					DlblFSD.Text = theRow["first_sale"] == DBNull.Value ? string.Empty : Convert.ToDateTime(theRow["first_sale"]).ToShortDateString();

					if (theRow["creditcard_expiration"] == DBNull.Value)
						DlblCCExpiration.Text = "No";
					else
					{
						if (Convert.ToDateTime(theRow["creditcard_expiration"]) > DateTime.Today)
						{
							DlblCCExpiration.BackColor = Color.LimeGreen;
							DlblCCExpiration.Text = thisUser.RoleID == ADMINISTRATOR || thisUser.HomeDepartment.ID == 1 ? Convert.ToDateTime(theRow["creditcard_expiration"]).ToShortDateString() : "Yes";
						}
						else
						{
							DlblCCExpiration.BackColor = Color.IndianRed;
							DlblCCExpiration.Text = thisUser.RoleID == ADMINISTRATOR || thisUser.HomeDepartment.ID == 1 ? Convert.ToDateTime(theRow["creditcard_expiration"]).ToShortDateString() : "Expired";
						}
					}

					if (theRow["tax_id_expiration"] == DBNull.Value)
						DlblTaxExempt.Text = "No";
					else
					{
						if (Convert.ToDateTime(theRow["tax_id_expiration"]) > DateTime.Today)
						{
							DlblTaxExempt.BackColor = Color.LimeGreen;
							DlblTaxExempt.Text = thisUser.RoleID == ADMINISTRATOR || thisUser.HomeDepartment.ID == 1 ? Convert.ToDateTime(theRow["tax_id_expiration"]).ToShortDateString() : "Yes";
						}
						else
						{
							DlblTaxExempt.BackColor = Color.IndianRed;
							DlblTaxExempt.Text = thisUser.RoleID == ADMINISTRATOR || thisUser.HomeDepartment.ID == 1 ? Convert.ToDateTime(theRow["tax_id_expiration"]).ToShortDateString() : "Expired";
						}
					}
				}

				if (dsPreview.Tables[2].Rows.Count > 0)
				{
					ListViewItem oItem;

					foreach (DataRow oRow in dsPreview.Tables[2].Rows)
					{
						oItem = new ListViewItem();
						oItem.Text = oRow["name"].ToString();
						oItem.SubItems.Add(Convert.ToDateTime(oRow["last_sale"]).ToString("M/d/yy"));
						oItem.SubItems.Add(Convert.ToDecimal(oRow["amount"] == DBNull.Value ? 0 : oRow["amount"]).ToString("C"));
						oItem.SubItems.Add(oRow["sales_rep"].ToString());
						oItem.SubItems.Add(oRow["invoice_terms"].ToString());
						oItem.SubItems.Add(Convert.ToDecimal(oRow["ytd_sales"] == DBNull.Value ? 0 : oRow["ytd_sales"]).ToString("C"));
						oItem.SubItems.Add(Convert.ToDecimal(oRow["last_year_sales"] == DBNull.Value ? 0 : oRow["last_year_sales"]).ToString("C"));

						lvwSalesHistory.Items.Add(oItem);
					}
				}
			}
		}

        #endregion


        #region Event Handlers

        private void btnSearch_Click(object sender, EventArgs e)
        {
			//Clear any previous results
			ClearResults();

			if (ContainsLetters(txtLookFor.Text) && cboSearchIn.SelectedIndex == 0)
				cboSearchIn.SelectedIndex = 1;

			ShowResults();

			IsDisposable = false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            Clear();
        }

		void customerItems_ActivityStatusChanged(object sender, ActivityStatusChangedEventArgs e)
		{
			if (thisUser.HomeDepartment.IsProfitCenter)
			{
				bool isFound = false;

				foreach (int ID in e.InactiveDepartments)
					if (thisUser.HomeDepartment.ID == ID)
						isFound = true;

				foreach (ListViewItem oItem in lvwResults.Items)
					if (oItem.SubItems[0].Text == e.CustomerID.ToString())
						if (isFound)
							oItem.BackColor = Color.LightSteelBlue;
						else
							oItem.BackColor = Color.White;

				lblCustomerStatus.Visible = isFound;
			}
			else
			{
				foreach (ListViewItem oItem in lvwResults.Items)
					if (oItem.SubItems[0].Text == e.CustomerID.ToString())
						if (e.InactiveDepartments.Count > 0)
							oItem.BackColor = Color.LightSteelBlue;
						else
							oItem.BackColor = Color.White;

				lblCustomerStatus.Visible = (e.InactiveDepartments.Count > 0);
			}
		}

        private void CustomerSearchScreen_Load(object sender, EventArgs e)
        {
            InitializeDropDowns();
        }

		private void lvwResults_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
			{
				bool IsCustomer = !string.IsNullOrEmpty(e.Item.SubItems[CUSTOMER_INDEX].Text);

				ShowPreview(e.Item);

				cmsResults.Items[cmsResults.Items.Count - 2].Visible = !IsCustomer;
				cmsResults.Items[cmsResults.Items.Count - 1].Visible = IsCustomer;
				tsmActions.DropDownItems[tsmActions.DropDownItems.Count - 2].Visible = !IsCustomer;
				tsmActions.DropDownItems[tsmActions.DropDownItems.Count - 1].Visible = IsCustomer;
				tsMain.Items[tsMain.Items.Count - 2].Visible = !IsCustomer;
				tsMain.Items[tsMain.Items.Count - 1].Visible = IsCustomer;
			}
			else
				ClearPreview();
		}

		private void lvwResults_DoubleClick(object sender, EventArgs e)
		{
			if (lvwResults.SelectedItems.Count > 0)
			{
				if (string.IsNullOrEmpty(lvwResults.SelectedItems[0].SubItems[CUSTOMER_INDEX].Text))
				{
					Objects.Contact.Contact newContact = null;
					NavigationScreen myNavigation = GetNavigationScreen();
					myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[0];

					using (Objects.Contact.ContactController theController = new Objects.Contact.ContactController())
					{
						newContact = theController.GetContact(Convert.ToInt32(lvwResults.SelectedItems[0].SubItems[CONTACT_ID_INDEX].Text));
						myNavigation.btnCustomer.MyCustomer = newContact.GetCustomer();
					}

					myNavigation.btnCustomer.PerformClick();

					((Objects.Contact.ContactScreen)myNavigation.CurrentScreen).MyContact = newContact;
				}
				else
				{
					NavigationScreen myNavigation = GetNavigationScreen();
					myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0];

					using (CustomerController theController = new CustomerController())
					{
						myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(lvwResults.SelectedItems[0].SubItems[0].Text));
					}

					myNavigation.btnCustomer.PerformClick();
				}
			}
		}

		private void lvwProjects_DoubleClick(object sender, EventArgs e)
		{
			if (lvwProjects.SelectedItems.Count > 0)
			{
				NavigationScreen myNavigation = GetNavigationScreen();
				myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1];

				using (CustomerController theController = new CustomerController())
				{
					myNavigation.btnCustomer.MyCustomer = theController.GetCustomer(Convert.ToInt32(lvwProjects.SelectedItems[0].SubItems[1].Text));
				}

				myNavigation.btnCustomer.PerformClick();

				using (ProjectController theController = new ProjectController())
				{
					((ProjectScreen)myNavigation.CurrentScreen).MyProject = theController.GetProject(Convert.ToInt32(lvwProjects.SelectedItems[0].SubItems[0].Text));
				}
			}
		}

        #endregion


        #region Constructor

        public CustomerSearchScreen()
            : base()
        {
            InitializeComponent();

            lvwProjects.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(lvwResults_ColumnClick);
            
            //Populate the search in combo box
            DataTable oSearchInValues = new DataTable();
            oSearchInValues.Columns.Add("Column_Name");
            oSearchInValues.Columns.Add("Description");

            oSearchInValues.Rows.Add("phone_number", "Phone Number");
            oSearchInValues.Rows.Add("c.`name`", "Company Name");
            oSearchInValues.Rows.Add("ContactName", "Contact Name");
            oSearchInValues.Rows.Add("co.`first_name`", "First Name");
            oSearchInValues.Rows.Add("co.`last_name`", "Last Name");
            oSearchInValues.Rows.Add("c.`falcon_id`", "Falcon Number");
			oSearchInValues.Rows.Add("view_all", "View All");

            cboSearchIn.DataSource = oSearchInValues;
            cboSearchIn.DisplayMember = "Description";
            cboSearchIn.ValueMember = "Column_Name";

			//These columns are named so that they can be found by the rkcrm.Searching.CustomerDropDown object
			chProjectCustomerID.Name = "chCustomerID";
        }

        #endregion

    }
}
