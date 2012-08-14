using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using rkcrm.Administration.Department;
using rkcrm.Base_Classes;
using rkcrm.Navigation;

namespace rkcrm.Objects.Customer
{
	class CustomerScreen : ScreenBase
	{

		#region Variables

		private System.Windows.Forms.Panel pnlControls;
		private CustomerBoundary customerControls;
		private System.Windows.Forms.GroupBox gbxSalesHistory;
		private System.Windows.Forms.ListView lvwSalesHistory;
		private System.Windows.Forms.ColumnHeader chDepartment;
		private System.Windows.Forms.ColumnHeader chLastSale;
		private System.Windows.Forms.ColumnHeader chAmount;
		private System.Windows.Forms.ColumnHeader chRep;
		private System.Windows.Forms.ColumnHeader chTerms;
		private System.Windows.Forms.ColumnHeader chYTD;
		private System.Windows.Forms.ColumnHeader chLYS;
		private System.Windows.Forms.GroupBox gbxGeneralInfo;
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
		private ToolStripButton tsbSave;
		private ToolStripButton tsbSaveClose;
		private ToolStripSeparator tss_0;
		private ToolStripButton tsbAddCustomer;
		private ToolStripButton tsbAddContact;
		private ToolStripButton tsbAddProject;
		private ToolStripSeparator tss_1;
		private ToolStripButton tsbClose;
		private ToolStripSeparator tss_2;
		private ToolStripSeparator tss_3;
		private ToolStripButton tsbTaxExpiration;
		private ToolStripButton tsbCardExpiration;
		private ToolStripSeparator tss_4;
		private ToolStripButton tsbInvoices;
		private ToolStripButton tsbCrossSales;
		private ToolStripButton tsbSources;
		private ToolStripButton tsbActivityStatus;
		private System.Windows.Forms.ToolStrip tsMain;
		private ToolStripMenuItem tsmAddCustomer;
		private ToolStripMenuItem tsmAddContact;
		private ToolStripMenuItem tsmAddProject;
		private ToolStripSeparator mss_1;
		private ToolStripMenuItem tsmActivityStatus;
		private ToolStripSeparator mss_2;
		private ToolStripMenuItem tsmTaxExpiration;
		private ToolStripMenuItem tsmCardExpiration;
		private ToolStripSeparator mss_3;
		private ToolStripMenuItem tsmInvoices;
		private ToolStripSeparator mss_4;
		private ToolStripMenuItem tsmCrossSales;
		private ToolStripMenuItem tsmSources;
		private ToolStripSeparator mss_5;
		private ToolStripMenuItem tsmClose;

		private const int ACTIVATION = 13;
		private const int DEACTIVATION = 12;
		private const int ADMINISTRATOR = 1;
		#endregion


		#region Properties

		public Customer MyCustomer
		{
			get { return customerControls.MyCustomer; }
			set
			{
				if (customerControls.MyCustomer != null)
					customerControls.MyCustomer.Dispose();

				customerControls.MyCustomer = value;
			}
		}

		public override bool IsDirty
		{
			get
			{
				return customerControls.IsDirty;
			}
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerScreen));
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.tsbSaveClose = new System.Windows.Forms.ToolStripButton();
			this.tsbClose = new System.Windows.Forms.ToolStripButton();
			this.tss_0 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbAddCustomer = new System.Windows.Forms.ToolStripButton();
			this.tsbAddContact = new System.Windows.Forms.ToolStripButton();
			this.tsbAddProject = new System.Windows.Forms.ToolStripButton();
			this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbActivityStatus = new System.Windows.Forms.ToolStripButton();
			this.tss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbTaxExpiration = new System.Windows.Forms.ToolStripButton();
			this.tsbCardExpiration = new System.Windows.Forms.ToolStripButton();
			this.tss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbInvoices = new System.Windows.Forms.ToolStripButton();
			this.tss_4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCrossSales = new System.Windows.Forms.ToolStripButton();
			this.tsbSources = new System.Windows.Forms.ToolStripButton();
			this.pnlControls = new System.Windows.Forms.Panel();
			this.customerControls = new rkcrm.Objects.Customer.CustomerBoundary();
			this.gbxSalesHistory = new System.Windows.Forms.GroupBox();
			this.lvwSalesHistory = new System.Windows.Forms.ListView();
			this.chDepartment = new System.Windows.Forms.ColumnHeader();
			this.chLastSale = new System.Windows.Forms.ColumnHeader();
			this.chAmount = new System.Windows.Forms.ColumnHeader();
			this.chRep = new System.Windows.Forms.ColumnHeader();
			this.chTerms = new System.Windows.Forms.ColumnHeader();
			this.chYTD = new System.Windows.Forms.ColumnHeader();
			this.chLYS = new System.Windows.Forms.ColumnHeader();
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
			this.tsmAddCustomer = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmAddContact = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmAddProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmActivityStatus = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmTaxExpiration = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmCardExpiration = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmInvoices = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmCrossSales = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmSources = new System.Windows.Forms.ToolStripMenuItem();
			this.mss_5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.tsMain.SuspendLayout();
			this.pnlControls.SuspendLayout();
			this.gbxSalesHistory.SuspendLayout();
			this.gbxGeneralInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.pnlControls);
			this.scMain.Panel1.Controls.Add(this.tsMain);
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Controls.Add(this.gbxSalesHistory);
			this.scMain.Panel2.Controls.Add(this.gbxGeneralInfo);
			this.scMain.Panel2.Padding = new System.Windows.Forms.Padding(3);
			this.scMain.Size = new System.Drawing.Size(602, 497);
			this.scMain.SplitterDistance = 302;
			// 
			// tsMain
			// 
			this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbSaveClose,
            this.tsbClose,
            this.tss_0,
            this.tsbAddCustomer,
            this.tsbAddContact,
            this.tsbAddProject,
            this.tss_1,
            this.tsbActivityStatus,
            this.tss_2,
            this.tsbTaxExpiration,
            this.tsbCardExpiration,
            this.tss_3,
            this.tsbInvoices,
            this.tss_4,
            this.tsbCrossSales,
            this.tsbSources});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(600, 35);
			this.tsMain.TabIndex = 0;
			this.tsMain.Text = "toolStrip1";
			// 
			// tsbSave
			// 
			this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSave.Image = global::rkcrm.Properties.Resources.save;
			this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Size = new System.Drawing.Size(32, 32);
			this.tsbSave.Text = "Save Changes";
			this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
			// 
			// tsbSaveClose
			// 
			this.tsbSaveClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSaveClose.Image = global::rkcrm.Properties.Resources.Save_and_Close;
			this.tsbSaveClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSaveClose.Name = "tsbSaveClose";
			this.tsbSaveClose.Size = new System.Drawing.Size(32, 32);
			this.tsbSaveClose.Text = "Save Changes and Close Customer";
			this.tsbSaveClose.Click += new System.EventHandler(this.tsbSaveClose_Click);
			// 
			// tsbClose
			// 
			this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbClose.Image = global::rkcrm.Properties.Resources.Close_Customer;
			this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbClose.Name = "tsbClose";
			this.tsbClose.Size = new System.Drawing.Size(32, 32);
			this.tsbClose.Text = "Close Customer";
			this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
			// 
			// tss_0
			// 
			this.tss_0.Name = "tss_0";
			this.tss_0.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbAddCustomer
			// 
			this.tsbAddCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddCustomer.Image = global::rkcrm.Properties.Resources.New_Customer_Icon;
			this.tsbAddCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddCustomer.Name = "tsbAddCustomer";
			this.tsbAddCustomer.Size = new System.Drawing.Size(32, 32);
			this.tsbAddCustomer.Text = "Add Customer";
			this.tsbAddCustomer.EnabledChanged += new System.EventHandler(this.tsbAddCustomer_EnabledChanged);
			this.tsbAddCustomer.VisibleChanged += new System.EventHandler(this.tsbAddCustomer_VisibleChanged);
			this.tsbAddCustomer.Click += new System.EventHandler(this.tsbAddCustomer_Click);
			// 
			// tsbAddContact
			// 
			this.tsbAddContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddContact.Image = global::rkcrm.Properties.Resources.New_Contact_Icon;
			this.tsbAddContact.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddContact.Name = "tsbAddContact";
			this.tsbAddContact.Size = new System.Drawing.Size(32, 32);
			this.tsbAddContact.Text = "Add Contact";
			this.tsbAddContact.EnabledChanged += new System.EventHandler(this.tsbAddContact_EnabledChanged);
			this.tsbAddContact.VisibleChanged += new System.EventHandler(this.tsbAddContact_VisibleChanged);
			this.tsbAddContact.Click += new System.EventHandler(this.tsbAddContact_Click);
			// 
			// tsbAddProject
			// 
			this.tsbAddProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddProject.Image = global::rkcrm.Properties.Resources.New_Project28x28;
			this.tsbAddProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddProject.Name = "tsbAddProject";
			this.tsbAddProject.Size = new System.Drawing.Size(32, 32);
			this.tsbAddProject.Text = "Add Project";
			this.tsbAddProject.EnabledChanged += new System.EventHandler(this.tsbAddProject_EnabledChanged);
			this.tsbAddProject.VisibleChanged += new System.EventHandler(this.tsbAddProject_VisibleChanged);
			this.tsbAddProject.Click += new System.EventHandler(this.tsbAddProject_Click);
			// 
			// tss_1
			// 
			this.tss_1.Name = "tss_1";
			this.tss_1.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbActivityStatus
			// 
			this.tsbActivityStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbActivityStatus.Image = global::rkcrm.Properties.Resources.Deactivate_Customer;
			this.tsbActivityStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbActivityStatus.Name = "tsbActivityStatus";
			this.tsbActivityStatus.Size = new System.Drawing.Size(32, 32);
			this.tsbActivityStatus.Text = "Change Activity Status";
			this.tsbActivityStatus.EnabledChanged += new System.EventHandler(this.tsbActivityStatus_EnabledChanged);
			this.tsbActivityStatus.VisibleChanged += new System.EventHandler(this.tsbActivityStatus_VisibleChanged);
			this.tsbActivityStatus.Click += new System.EventHandler(this.tsbActivityStatus_Click);
			// 
			// tss_2
			// 
			this.tss_2.Name = "tss_2";
			this.tss_2.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbTaxExpiration
			// 
			this.tsbTaxExpiration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbTaxExpiration.Image = global::rkcrm.Properties.Resources.Calendar_Icon;
			this.tsbTaxExpiration.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbTaxExpiration.Name = "tsbTaxExpiration";
			this.tsbTaxExpiration.Size = new System.Drawing.Size(32, 32);
			this.tsbTaxExpiration.Text = "Updated Tax Exempt Expiration";
			this.tsbTaxExpiration.EnabledChanged += new System.EventHandler(this.tsbTaxExpiration_EnabledChanged);
			this.tsbTaxExpiration.VisibleChanged += new System.EventHandler(this.tsbTaxExpiration_VisibleChanged);
			this.tsbTaxExpiration.Click += new System.EventHandler(this.tsbTaxExpiration_Click);
			// 
			// tsbCardExpiration
			// 
			this.tsbCardExpiration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCardExpiration.Image = global::rkcrm.Properties.Resources.Credit_Card_Icon;
			this.tsbCardExpiration.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCardExpiration.Name = "tsbCardExpiration";
			this.tsbCardExpiration.Size = new System.Drawing.Size(32, 32);
			this.tsbCardExpiration.Text = "Update Credit Card Expiration";
			this.tsbCardExpiration.EnabledChanged += new System.EventHandler(this.tsbCardExpiration_EnabledChanged);
			this.tsbCardExpiration.VisibleChanged += new System.EventHandler(this.tsbCardExpiration_VisibleChanged);
			this.tsbCardExpiration.Click += new System.EventHandler(this.tsbCardExpiration_Click);
			// 
			// tss_3
			// 
			this.tss_3.Name = "tss_3";
			this.tss_3.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbInvoices
			// 
			this.tsbInvoices.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbInvoices.Image = global::rkcrm.Properties.Resources.invoice_icon_28x28;
			this.tsbInvoices.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbInvoices.Name = "tsbInvoices";
			this.tsbInvoices.Size = new System.Drawing.Size(32, 32);
			this.tsbInvoices.Text = "View Invoices";
			this.tsbInvoices.EnabledChanged += new System.EventHandler(this.tsbInvoices_EnabledChanged);
			this.tsbInvoices.VisibleChanged += new System.EventHandler(this.tsbInvoices_VisibleChanged);
			this.tsbInvoices.Click += new System.EventHandler(this.tsbInvoices_Click);
			// 
			// tss_4
			// 
			this.tss_4.Name = "tss_4";
			this.tss_4.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbCrossSales
			// 
			this.tsbCrossSales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCrossSales.Image = global::rkcrm.Properties.Resources.View_Cross_Sales;
			this.tsbCrossSales.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCrossSales.Name = "tsbCrossSales";
			this.tsbCrossSales.Size = new System.Drawing.Size(32, 32);
			this.tsbCrossSales.Text = "Manage Cross Sales";
			this.tsbCrossSales.EnabledChanged += new System.EventHandler(this.tsbCrossSales_EnabledChanged);
			this.tsbCrossSales.VisibleChanged += new System.EventHandler(this.tsbCrossSales_VisibleChanged);
			this.tsbCrossSales.Click += new System.EventHandler(this.tsbCrossSales_Click);
			// 
			// tsbSources
			// 
			this.tsbSources.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSources.Image = ((System.Drawing.Image)(resources.GetObject("tsbSources.Image")));
			this.tsbSources.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSources.Name = "tsbSources";
			this.tsbSources.Size = new System.Drawing.Size(32, 32);
			this.tsbSources.Text = "Manage Lead Sources";
			this.tsbSources.EnabledChanged += new System.EventHandler(this.tsbSources_EnabledChanged);
			this.tsbSources.VisibleChanged += new System.EventHandler(this.tsbSources_VisibleChanged);
			this.tsbSources.Click += new System.EventHandler(this.tsbSources_Click);
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.customerControls);
			this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlControls.Location = new System.Drawing.Point(0, 35);
			this.pnlControls.Name = "pnlControls";
			this.pnlControls.Size = new System.Drawing.Size(600, 265);
			this.pnlControls.TabIndex = 1;
			// 
			// customerControls
			// 
			this.customerControls.AutoScroll = true;
			this.customerControls.BackColor = System.Drawing.Color.White;
			this.customerControls.ChangeHistoryVisible = true;
			this.customerControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.customerControls.Location = new System.Drawing.Point(0, 0);
			this.customerControls.MyCustomer = null;
			this.customerControls.Name = "customerControls";
			this.customerControls.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.customerControls.Size = new System.Drawing.Size(600, 265);
			this.customerControls.TabIndex = 0;
			this.customerControls.Title = "General Information";
			this.customerControls.TitleBarVisible = true;
			this.customerControls.MyCustomerChanged += new System.EventHandler<System.EventArgs>(this.customerControls_MyCustomerChanged);
			this.customerControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.customerControls_IsDirtyChanged);
			// 
			// gbxSalesHistory
			// 
			this.gbxSalesHistory.Controls.Add(this.lvwSalesHistory);
			this.gbxSalesHistory.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxSalesHistory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbxSalesHistory.Location = new System.Drawing.Point(3, 77);
			this.gbxSalesHistory.Name = "gbxSalesHistory";
			this.gbxSalesHistory.Size = new System.Drawing.Size(577, 174);
			this.gbxSalesHistory.TabIndex = 5;
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
			this.lvwSalesHistory.Size = new System.Drawing.Size(571, 149);
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
			this.gbxGeneralInfo.Location = new System.Drawing.Point(3, 3);
			this.gbxGeneralInfo.Name = "gbxGeneralInfo";
			this.gbxGeneralInfo.Size = new System.Drawing.Size(577, 74);
			this.gbxGeneralInfo.TabIndex = 4;
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
			// tsmAddCustomer
			// 
			this.tsmAddCustomer.Image = global::rkcrm.Properties.Resources.New_Customer_Icon;
			this.tsmAddCustomer.Name = "tsmAddCustomer";
			this.tsmAddCustomer.Size = new System.Drawing.Size(218, 22);
			this.tsmAddCustomer.Text = "Add Customer";
			this.tsmAddCustomer.Click += new System.EventHandler(this.tsbAddCustomer_Click);
			// 
			// tsmAddContact
			// 
			this.tsmAddContact.Image = global::rkcrm.Properties.Resources.New_Contact_Icon;
			this.tsmAddContact.Name = "tsmAddContact";
			this.tsmAddContact.Size = new System.Drawing.Size(218, 22);
			this.tsmAddContact.Text = "Add Contact";
			this.tsmAddContact.Click += new System.EventHandler(this.tsbAddContact_Click);
			// 
			// tsmAddProject
			// 
			this.tsmAddProject.Image = global::rkcrm.Properties.Resources.New_Project28x28;
			this.tsmAddProject.Name = "tsmAddProject";
			this.tsmAddProject.Size = new System.Drawing.Size(218, 22);
			this.tsmAddProject.Text = "Add Project";
			this.tsmAddProject.Click += new System.EventHandler(this.tsbAddProject_Click);
			// 
			// mss_1
			// 
			this.mss_1.Name = "mss_1";
			this.mss_1.Size = new System.Drawing.Size(215, 6);
			// 
			// tsmActivityStatus
			// 
			this.tsmActivityStatus.Image = global::rkcrm.Properties.Resources.Deactivate_Customer;
			this.tsmActivityStatus.Name = "tsmActivityStatus";
			this.tsmActivityStatus.Size = new System.Drawing.Size(218, 22);
			this.tsmActivityStatus.Text = "Deactivate";
			this.tsmActivityStatus.Click += new System.EventHandler(this.tsbActivityStatus_Click);
			// 
			// mss_2
			// 
			this.mss_2.Name = "mss_2";
			this.mss_2.Size = new System.Drawing.Size(215, 6);
			// 
			// tsmEditTax
			// 
			this.tsmTaxExpiration.Image = global::rkcrm.Properties.Resources.Calendar_Icon;
			this.tsmTaxExpiration.Name = "tsmEditTax";
			this.tsmTaxExpiration.Size = new System.Drawing.Size(218, 22);
			this.tsmTaxExpiration.Text = "Edit Tax Excempt Expiration";
			this.tsmTaxExpiration.Click += new System.EventHandler(this.tsbTaxExpiration_Click);
			// 
			// tsmEditCredit
			// 
			this.tsmCardExpiration.Image = global::rkcrm.Properties.Resources.Credit_Card_Icon;
			this.tsmCardExpiration.Name = "tsmEditCredit";
			this.tsmCardExpiration.Size = new System.Drawing.Size(218, 22);
			this.tsmCardExpiration.Text = "Edit Credit Card Expiration";
			this.tsmCardExpiration.Click += new System.EventHandler(this.tsbCardExpiration_Click);
			// 
			// mss_3
			// 
			this.mss_3.Name = "mss_3";
			this.mss_3.Size = new System.Drawing.Size(215, 6);
			// 
			// tsmViewInvoices
			// 
			this.tsmInvoices.Image = global::rkcrm.Properties.Resources.invoice_icon_28x28;
			this.tsmInvoices.Name = "tsmViewInvoices";
			this.tsmInvoices.Size = new System.Drawing.Size(218, 22);
			this.tsmInvoices.Text = "View Invoices";
			this.tsmInvoices.Click += new System.EventHandler(this.tsbInvoices_Click);
			// 
			// mss_4
			// 
			this.mss_4.Name = "mss_4";
			this.mss_4.Size = new System.Drawing.Size(215, 6);
			// 
			// tsmCrossSales
			// 
			this.tsmCrossSales.Image = global::rkcrm.Properties.Resources.View_Cross_Sales;
			this.tsmCrossSales.Name = "tsmCrossSales";
			this.tsmCrossSales.Size = new System.Drawing.Size(218, 22);
			this.tsmCrossSales.Text = "Manage Cross Sales";
			this.tsmCrossSales.Click += new System.EventHandler(this.tsbCrossSales_Click);
			// 
			// tsmLeadSources
			// 
			this.tsmSources.Name = "tsmLeadSources";
			this.tsmSources.Size = new System.Drawing.Size(218, 22);
			this.tsmSources.Text = "Manage Lead Sources";
			this.tsmSources.Click += new System.EventHandler(this.tsbSources_Click);
			// 
			// mss_5
			// 
			this.mss_5.Name = "mss_5";
			this.mss_5.Size = new System.Drawing.Size(215, 6);
			// 
			// tsmClose
			// 
			this.tsmClose.Image = global::rkcrm.Properties.Resources.Close_Customer;
			this.tsmClose.Name = "tsmClose";
			this.tsmClose.Size = new System.Drawing.Size(218, 22);
			this.tsmClose.Text = "Close Customer";
			this.tsmClose.Click += new System.EventHandler(this.tsbClose_Click);
			// 
			// CustomerScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "CustomerScreen";
			this.Size = new System.Drawing.Size(602, 497);
			this.Controls.SetChildIndex(this.scMain, 0);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel1.PerformLayout();
			this.scMain.Panel2.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.pnlControls.ResumeLayout(false);
			this.gbxSalesHistory.ResumeLayout(false);
			this.gbxGeneralInfo.ResumeLayout(false);
			this.gbxGeneralInfo.PerformLayout();
			this.ResumeLayout(false);

		}

		private void InitializeActions()
		{
			this.tsmActions.DropDownItems.AddRange(new ToolStripItem[] { 
			this.tsmAddCustomer,
			this.tsmAddContact,
			this.tsmAddProject,
			this.mss_1,
			this.tsmActivityStatus,
			this.mss_2,
			this.tsmTaxExpiration,
			this.tsmCardExpiration,
			this.mss_3,
			this.tsmInvoices,
			this.mss_4,
			this.tsmCrossSales,
			this.tsmSources,
			this.mss_5,
			this.tsmClose});
		}

		/// <summary>
		/// Loads the preview data for the customer
		/// </summary>
		/// <param name="SelectedItem"></param>
		private void ShowPreview()
		{
			DataSet dsPreview;
			DataTable dtActivityStatuses;

			using (CustomerController theController = new CustomerController())
			{
				dsPreview = theController.GetSearchPreview(MyCustomer.ID);
				dtActivityStatuses = theController.GetActivityStatuses(MyCustomer.ID);
			}

			if (dsPreview.Tables.Count > 2)
			{

				foreach (DataRow oRow in dtActivityStatuses.Rows)
					if ((!thisUser.HomeDepartment.IsProfitCenter || thisUser.HomeDepartment.ID == Convert.ToInt32(oRow["department_id"])) && !Convert.ToBoolean(oRow["is_active"]))
						lblCustomerStatus.Visible = true;

				if (dsPreview.Tables[1].Rows.Count > 0)
				{
					DataRow theRow = dsPreview.Tables[1].Rows[0];
					
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

		public new void Clear()
		{
			base.Clear();
	
			ClearPreview();
		}

		public void ClearPreview()
		{
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

		public override bool Save()
		{
			bool freeToProceed = false;

			if (customerControls.txtName.Text != MyCustomer.Name)
			{
				freeToProceed = !GotoDuplicate();
			}
			else
				freeToProceed = true;

			if (freeToProceed)
				return customerControls.Save();
			else
				return false;
		}

		public override void RefreshData()
		{
			if (MyCustomer != null)
				MyCustomer = MyCustomer;
		}

		private void CloseCustomer()
		{
			Clear();

			MyCustomer = null;

			NavigationScreen myNav = GetNavigationScreen();
			myNav.btnCustomer.trvOptions.SelectedNode = null;
			myNav.btnSearch.PerformClick();
		}

		public bool GotoDuplicate()
		{
			DataTable oTable;

			using (CustomerController theController = new CustomerController())
			{
				oTable = theController.GetDuplicateCustomers(customerControls.txtName.Text, MyCustomer.ID);
			}

			if (oTable.Rows.Count != 0)
			{
				using (DuplicateCustomerList oForm = new DuplicateCustomerList(oTable, MyCustomer, customerControls.txtName.Text))
				{
					oForm.ShowDialog();

					if (oForm.DialogResult == DialogResult.Yes)
					{
						if (MessageBox.Show("Would you like to open that customer?", MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							using (CustomerController theController = new CustomerController())
							{
								this.MyCustomer = theController.GetCustomer(Convert.ToInt32(oForm.SelectedItem.SubItems[0].Text));
							}
							return true;
						}
						else
							return false;
					}
					else
						return false;
				}
			}
			else
				return false;
		}

		#endregion


		#region Event Handlers

		private void tsbClose_Click(object sender, EventArgs e)
		{
			if (this.IsDirty)
			{
				switch (MessageBox.Show("Would you like to save your changes?", MySettings.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if (Save())
							CloseCustomer();
						break;
					case DialogResult.Cancel:
						break;
					default:
						CloseCustomer();
						break;
				}
			}
			else
				CloseCustomer();
		}

		private void tsbTaxExpiration_Click(object sender, EventArgs e)
		{
			UpdateTaxExpiration oForm = new UpdateTaxExpiration(MyCustomer);
			oForm.ShowDialog();

			if (oForm.DialogResult == DialogResult.OK)
			{
				ClearPreview();
				ShowPreview();
			}
		}

		private void tsbCardExpiration_Click(object sender, EventArgs e)
		{
			UpdateCreditExpiration oForm = new UpdateCreditExpiration(MyCustomer);
			oForm.ShowDialog();

			if (oForm.DialogResult == DialogResult.OK)
			{
				ClearPreview();
				ShowPreview();
			}
		}

		private void tsbInvoices_Click(object sender, EventArgs e)
		{
			ViewInvoices oForm = new ViewInvoices(MyCustomer.ID);
			oForm.Show();
		}

		private void tsbCrossSales_Click(object sender, EventArgs e)
		{
			Cross_Sale.CrossSaleManagement oForm = new rkcrm.Objects.Cross_Sale.CrossSaleManagement(MyCustomer);
			oForm.ShowDialog();
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if(IsDirty)
				if (Save())
					customerControls.Refresh();
		}

		private void tsbSaveClose_Click(object sender, EventArgs e)
		{
			if (IsDirty)
			{
				if (Save())
				{
					MyCustomer = null;
					CloseCustomer();
				}
			}
			else
			{
				MyCustomer = null;
				CloseCustomer();
			}
		}

		private void tsbAddContact_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[0];
			myNavigation.btnCustomer.MyCustomer = this.MyCustomer;
			myNavigation.btnCustomer.PerformClick();

			((Contact.ContactScreen)myNavigation.CurrentScreen).MyCustomer = this.MyCustomer;
			((Contact.ContactScreen)myNavigation.CurrentScreen).MyContact = new Contact.Contact();
		}

		private void tsbAddCustomer_Click(object sender, EventArgs e)
		{
			rkcrm.Objects.NewCustomerWizard oForm = new rkcrm.Objects.NewCustomerWizard();
			oForm.ShowDialog();

			if (oForm.DialogResult == DialogResult.OK)
			{
				NavigationScreen myNav = GetNavigationScreen();
				myNav.ClearUnusedScreens();

				MyCustomer = oForm.MyCustomer;
			}
		}

		private void tsbAddProject_Click(object sender, EventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();
			myNavigation.btnCustomer.trvOptions.SelectedNode = myNavigation.btnCustomer.trvOptions.Nodes[0].Nodes[1];
			myNavigation.btnCustomer.MyProject = null;
			myNavigation.btnCustomer.PerformClick();

			((Project.ProjectScreen)myNavigation.CurrentScreen).MyCustomer = myNavigation.btnCustomer.MyCustomer;
			((Project.ProjectScreen)myNavigation.CurrentScreen).MyProject = new Project.Project();
		}

		private void tsbSources_Click(object sender, EventArgs e)
		{
			Lead_Source.LeadSourceAdministration oForm = new rkcrm.Objects.Customer.Lead_Source.LeadSourceAdministration();
			oForm.theSourceScreen.MyCustomer = this.MyCustomer;
			oForm.ShowDialog();
			oForm.Dispose();
			oForm = null;

			customerControls.RefreshLeadSources();
		}

		private void tsbActivityStatus_Click(object sender, EventArgs e)
		{
			Project.Project generalNotes = MyCustomer.GetGeneralNotesProject();

			if (!generalNotes.IsArchived)
			{
				bool isActive;
				Note.AddNote oForm = new rkcrm.Objects.Note.AddNote();
				Note.Note newNote = new rkcrm.Objects.Note.Note();

				//Assume deactivation if the user is not a member of a profit center department
				if (thisUser.HomeDepartment.IsProfitCenter)
				{
					using (CustomerController theController = new CustomerController())
					{
						isActive = theController.IsActive(MyCustomer.ID, Convert.ToInt32(oForm.noteControls.cboDepartment.SelectedValue));
					}
				}
				else
					isActive = true;

				newNote.ProjectID = generalNotes.ID;

				oForm.MyNote = newNote;
				oForm.MyNote.PurposeID = (isActive ? DEACTIVATION : ACTIVATION);
				oForm.noteControls.cboPurpose.Text = oForm.MyNote.GetContactPurpose().Name;
				oForm.noteControls.cboPurpose.Enabled = false;
				oForm.noteControls.cboDepartment.Enabled = !thisUser.HomeDepartment.IsProfitCenter;
				oForm.noteControls.mtxtNextFollowUp.Enabled = false;
				oForm.noteControls.lblNextFollowUp.Text = "Next Follow Up";
				oForm.noteControls.lblNotes.Text = "Notes*";

				oForm.ShowDialog();

				if (oForm.DialogResult == DialogResult.OK)
				{
					using (Note.NoteController theController = new rkcrm.Objects.Note.NoteController())
					{
						oForm.MyNote = theController.InsertNote(oForm.MyNote);
					}

					if (oForm.MyNote.ID > 0)
					{
						using (CustomerController theController = new CustomerController())
						{
							if (oForm.MyNote.PurposeID == DEACTIVATION)
								theController.Deactivate(MyCustomer.ID, Convert.ToInt32(oForm.noteControls.cboDepartment.SelectedValue));
							else
								theController.Activate(MyCustomer.ID, Convert.ToInt32(oForm.noteControls.cboDepartment.SelectedValue));
						}

						MyCustomer = MyCustomer;
					}
				}
			}
			else
				MessageBox.Show("This customer's activity status cannot be changed. Please contact you system administrator.", MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void customerControls_MyCustomerChanged(object sender, EventArgs e)
		{
			if (GetNavigationScreen().btnCustomer.MyCustomer != MyCustomer)
				GetNavigationScreen().btnCustomer.MyCustomer = MyCustomer;

			if (MyCustomer != null)
			{
				Clear();
				ShowPreview();
				tsbActivityStatus.Enabled = MyCustomer.GetCustomerType().RequireUniqueName;
				tsmActivityStatus.Enabled = tsbActivityStatus.Enabled;
				IsDisposable = false;
			}
		}

		private void customerControls_IsDirtyChanged(object sender, EventArgs e)
		{
			tsbSave.Enabled = this.IsDirty;
			tsbSaveClose.Enabled = this.IsDirty;
		}

		#endregion


		#region Constructors

		public CustomerScreen(ref Customer theCustomer)
			: base()
		{
			InitializeComponent();
			InitializeActions();

			MyCustomer = theCustomer;

			ShowPreview();
		}

		public CustomerScreen()
			: base()
		{
			InitializeComponent();
			InitializeActions();
		}

		#endregion


		#region Special Button Handlers

		private void tsbAddCustomer_EnabledChanged(object sender, EventArgs e)
		{
			tsmAddCustomer.Enabled = tsbAddCustomer.Enabled;
		}

		private void tsbAddCustomer_VisibleChanged(object sender, EventArgs e)
		{
			tsmAddCustomer.Visible = tsbAddCustomer.Visible;
		}

		private void tsbAddContact_EnabledChanged(object sender, EventArgs e)
		{
			tsmAddContact.Enabled = tsbAddContact.Enabled;
		}

		private void tsbAddContact_VisibleChanged(object sender, EventArgs e)
		{
			tsmAddContact.Visible = tsbAddContact.Visible;
		}

		private void tsbAddProject_EnabledChanged(object sender, EventArgs e)
		{
			tsmAddProject.Enabled = tsbAddProject.Enabled;
		}

		private void tsbAddProject_VisibleChanged(object sender, EventArgs e)
		{
			tsmAddProject.Visible = tsbAddProject.Visible;
		}

		private void tsbActivityStatus_EnabledChanged(object sender, EventArgs e)
		{
			tsmActivityStatus.Enabled = tsbActivityStatus.Enabled;
		}

		private void tsbActivityStatus_VisibleChanged(object sender, EventArgs e)
		{
			tsmActivityStatus.Visible = tsbActivityStatus.Visible;
		}

		private void tsbTaxExpiration_EnabledChanged(object sender, EventArgs e)
		{
			tsmTaxExpiration.Enabled = tsbTaxExpiration.Enabled;
		}

		private void tsbTaxExpiration_VisibleChanged(object sender, EventArgs e)
		{
			tsmTaxExpiration.Visible = tsbTaxExpiration.Visible;
		}

		private void tsbCardExpiration_EnabledChanged(object sender, EventArgs e)
		{
			tsmCardExpiration.Enabled = tsbCardExpiration.Enabled;
		}

		private void tsbCardExpiration_VisibleChanged(object sender, EventArgs e)
		{
			tsmCardExpiration.Visible = tsbCardExpiration.Visible;
		}

		private void tsbInvoices_EnabledChanged(object sender, EventArgs e)
		{
			tsmInvoices.Enabled = tsbInvoices.Enabled;
		}

		private void tsbInvoices_VisibleChanged(object sender, EventArgs e)
		{
			tsmInvoices.Visible = tsbInvoices.Visible;
		}

		private void tsbCrossSales_EnabledChanged(object sender, EventArgs e)
		{
			tsmCrossSales.Enabled = tsbCrossSales.Enabled;
		}

		private void tsbCrossSales_VisibleChanged(object sender, EventArgs e)
		{
			tsmCrossSales.Visible = tsbCrossSales.Visible;
		}

		private void tsbSources_EnabledChanged(object sender, EventArgs e)
		{
			tsmSources.Enabled = tsbSources.Enabled;
		}

		private void tsbSources_VisibleChanged(object sender, EventArgs e)
		{
			tsmSources.Visible = tsbSources.Visible;
		}

		#endregion

	}


}
