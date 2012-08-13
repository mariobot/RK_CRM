using rkcrm.Base_Classes;

namespace rkcrm.Navigation
{
	public class AdministrationButton : NavigationButtonBase
    {
        public System.Windows.Forms.TreeView trvOptions;
        internal System.Windows.Forms.ImageList imlTreeView;
        private System.ComponentModel.IContainer components;

        #region Methods
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Import Errors");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Merge Customers");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Competitors");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Contact Methods");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Contact Purpose");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Contact Titles");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Customer Types");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Departments");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Lead Sources");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Locations");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Lost Reasons");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Phone Number Types");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Project Types");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Security Roles");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Users");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("System Configuration", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrationButton));
            this.trvOptions = new System.Windows.Forms.TreeView();
            this.imlTreeView = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // trvOptions
            // 
            this.trvOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOptions.HideSelection = false;
            this.trvOptions.ImageIndex = 0;
            this.trvOptions.ImageList = this.imlTreeView;
            this.trvOptions.ItemHeight = 18;
            this.trvOptions.Location = new System.Drawing.Point(0, 32);
            this.trvOptions.Name = "trvOptions";
            treeNode1.Name = "ndImportErrors";
            treeNode1.Text = "Import Errors";
            treeNode2.Name = "ndMerge";
            treeNode2.Text = "Merge Customers";
            treeNode3.Name = "ndCompetitors";
            treeNode3.Text = "Competitors";
            treeNode4.Name = "ndContactMethods";
            treeNode4.Text = "Contact Methods";
            treeNode5.Name = "ndPuposes";
            treeNode5.Text = "Contact Purpose";
            treeNode6.Name = "ndContactTitles";
            treeNode6.Text = "Contact Titles";
            treeNode7.Name = "ndCustomerTypes";
            treeNode7.Text = "Customer Types";
            treeNode8.Name = "ndDepartments";
            treeNode8.Text = "Departments";
            treeNode9.Name = "ndLeadSources";
            treeNode9.Text = "Lead Sources";
            treeNode10.Name = "ndLocations";
            treeNode10.Text = "Locations";
            treeNode11.Name = "ndLostReasons";
            treeNode11.Text = "Lost Reasons";
            treeNode12.Name = "ndPhoneTypes";
            treeNode12.Text = "Phone Number Types";
            treeNode13.Name = "ndProjectTypes";
            treeNode13.Text = "Project Types";
            treeNode14.Name = "ndRoles";
            treeNode14.Text = "Security Roles";
            treeNode15.Name = "ndUsers";
            treeNode15.Text = "Users";
            treeNode16.Name = "ndConfiguation";
            treeNode16.Text = "System Configuration";
            this.trvOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode16});
            this.trvOptions.SelectedImageIndex = 1;
            this.trvOptions.ShowLines = false;
            this.trvOptions.ShowPlusMinus = false;
            this.trvOptions.ShowRootLines = false;
            this.trvOptions.Size = new System.Drawing.Size(254, 109);
            this.trvOptions.TabIndex = 1;
            this.trvOptions.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.trvOptions_AfterCollapse);
            this.trvOptions.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.trvOptions_AfterExpand);
            // 
            // imlTreeView
            // 
            this.imlTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTreeView.ImageStream")));
            this.imlTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTreeView.Images.SetKeyName(0, "BD14870_.GIF");
            this.imlTreeView.Images.SetKeyName(1, "BD14868_.GIF");
            // 
            // AdministrationButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ButtonText = "Administration";
            this.Controls.Add(this.trvOptions);
            this.Icon = global::rkcrm.Properties.Resources.Administrator;
            this.Name = "AdministrationButton";
            this.Size = new System.Drawing.Size(254, 142);
            this.Click += new System.EventHandler(this.AdministrationButton_Click);
            this.Controls.SetChildIndex(this.trvOptions, 0);
            this.ResumeLayout(false);

        }

		public void PerformClick()
		{
			OnClick(new System.EventArgs());
		}

        #endregion


        #region Event Handlers

        private void trvOptions_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.Height = (CountVisibleNodes(trvOptions.Nodes) + 1) * 18 + 32;
        }

        private void trvOptions_AfterCollapse(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.Height = (CountVisibleNodes(trvOptions.Nodes) + 1) * 18 + 32;
        }

        private void AdministrationButton_Click(object sender, System.EventArgs e)
        {
            Select();
        }

        #endregion


        #region Constructor

        public AdministrationButton()
            : base()
        {
            InitializeComponent();
        }

        #endregion
    }
}
