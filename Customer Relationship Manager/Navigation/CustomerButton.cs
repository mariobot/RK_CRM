using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Objects.Contact;
using rkcrm.Objects.Customer;
using rkcrm.Objects.Note;
using rkcrm.Objects.Project;
using rkcrm.Objects.Quote;

namespace rkcrm.Navigation
{
    public class CustomerButton : NavigationButtonBase
    {
        public System.Windows.Forms.TreeView trvOptions;
        internal System.Windows.Forms.ImageList imlTreeView;
        private System.ComponentModel.IContainer components;


		#region Variables

		private Customer clsMyCustomer;
		private Project clsMyProject;

		#endregion


		#region Properties

		internal Customer MyCustomer
		{
			get { return clsMyCustomer; }
			set 
			{
				bool HasChanged = (clsMyCustomer != value);

				clsMyCustomer = value;

				if (HasChanged)
					MyProject = new Project();

				if (value == null || value.ID == 0)
					trvOptions.Nodes[0].Text = "Customer";
				else
				{
					trvOptions.Nodes[0].Text = "Customer - " + value.Name;

					CheckForLeadSource();
				}
			}
		}

		internal Project MyProject
		{
			get { return clsMyProject; }
			set 
			{
				//The Expand and Collapse commands change which node is selected
				TreeNode selectedNode = trvOptions.SelectedNode;

				clsMyProject = value;

				if (value != null && value.ID > 0)
				{
					trvOptions.Nodes[0].Nodes[1].Expand();
					trvOptions.Nodes[0].Nodes[1].Text = "Projects - " + value.Name;
				}
				else
				{
					trvOptions.Nodes[0].Nodes[1].Collapse();
					trvOptions.Nodes[0].Nodes[1].Text = "Projects";
				}
				
				trvOptions.SelectedNode = selectedNode;
			}
		}

		#endregion


        #region Methods
        
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Contacts", 0, 0);
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Notes", 2, 2);
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Quotes", 4, 4);
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Projects", 3, 3, new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("General Information", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4});
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerButton));
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
			treeNode1.ImageIndex = 0;
			treeNode1.Name = "ndContact";
			treeNode1.SelectedImageIndex = 0;
			treeNode1.Text = "Contacts";
			treeNode2.ImageIndex = 2;
			treeNode2.Name = "ndNote";
			treeNode2.SelectedImageIndex = 2;
			treeNode2.Text = "Notes";
			treeNode3.ImageIndex = 4;
			treeNode3.Name = "ndQuote";
			treeNode3.SelectedImageIndex = 4;
			treeNode3.Text = "Quotes";
			treeNode4.ImageIndex = 3;
			treeNode4.Name = "ndProject";
			treeNode4.SelectedImageIndex = 3;
			treeNode4.Text = "Projects";
			treeNode5.ImageIndex = 1;
			treeNode5.Name = "ndCustomer";
			treeNode5.SelectedImageIndex = 1;
			treeNode5.Text = "General Information";
			this.trvOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
			this.trvOptions.SelectedImageIndex = 0;
			this.trvOptions.ShowLines = false;
			this.trvOptions.ShowPlusMinus = false;
			this.trvOptions.ShowRootLines = false;
			this.trvOptions.Size = new System.Drawing.Size(254, 129);
			this.trvOptions.TabIndex = 1;
			this.trvOptions.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.trvOptions_AfterCollapse);
			this.trvOptions.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvOptions_BeforeExpand);
			this.trvOptions.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvOptions_BeforeCollapse);
			this.trvOptions.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvOptions_NodeMouseClick);
			this.trvOptions.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.trvOptions_AfterExpand);
			// 
			// imlTreeView
			// 
			this.imlTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTreeView.ImageStream")));
			this.imlTreeView.TransparentColor = System.Drawing.Color.Transparent;
			this.imlTreeView.Images.SetKeyName(0, "Contacts16x16.png");
			this.imlTreeView.Images.SetKeyName(1, "Cutomer.png");
			this.imlTreeView.Images.SetKeyName(2, "Note16x16.png");
			this.imlTreeView.Images.SetKeyName(3, "Projects16x16.png");
			this.imlTreeView.Images.SetKeyName(4, "Quote16x16.png");
			this.imlTreeView.Images.SetKeyName(5, "Plans16x16.png");
			this.imlTreeView.Images.SetKeyName(6, "Report16x16.gif");
			// 
			// CustomerButton
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ButtonText = "Customer";
			this.Controls.Add(this.trvOptions);
			this.Icon = global::rkcrm.Properties.Resources.Customer;
			this.Name = "CustomerButton";
			this.Size = new System.Drawing.Size(254, 162);
			this.Click += new System.EventHandler(this.CustomerButton_Click);
			this.Controls.SetChildIndex(this.trvOptions, 0);
			this.ResumeLayout(false);

        }

		public void PerformClick()
		{
			OnClick(new System.EventArgs());
		}

		public new void Select()
		{
			base.Select();
			trvOptions_NodeMouseClick(trvOptions.SelectedNode, new TreeNodeMouseClickEventArgs(trvOptions.SelectedNode, MouseButtons.Left, 1, 10,
				(trvOptions.SelectedNode.Index + trvOptions.SelectedNode.Level) * 18 + 10));
		}

		protected void CheckForLeadSource()
		{
			bool result = false;
			Administration.Department.Department Home = thisUser.HomeDepartment;

			using (rkcrm.Objects.Customer.Lead_Source.LeadSourceController theController = new rkcrm.Objects.Customer.Lead_Source.LeadSourceController())
			{
				result = theController.HasLeadSource(this.MyCustomer.ID, Home.ID);
			}

			if (Home.IsProfitCenter && !result)
				if (MessageBox.Show("To add a project, note or quote for the " + Home.Name + " department you will have to state how the customer heard about the " + Home.Name + " department.\n\n" +
					"Would you like to do so now?",
					MySettings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Objects.Customer.Lead_Source.AddLeadSource oForm = new rkcrm.Objects.Customer.Lead_Source.AddLeadSource();
					oForm.MyCustomer = this.MyCustomer;
					oForm.Title = "How did they hear about the " + Home.Name + " department?";

					oForm.ShowDialog();

					if (oForm.DialogResult == DialogResult.OK)
						foreach (ScreenBase oScreen in GetNavigationScreen().OpenScreens)
							if (oScreen is CustomerScreen)
								oScreen.RefreshData();
				}

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

        private void CustomerButton_Click(object sender, System.EventArgs e)
        {
			if (trvOptions.SelectedNode != null)
			{
				if (CountVisibleNodes(trvOptions.Nodes) < 3)
					trvOptions.Nodes[0].Expand();

				if (trvOptions.SelectedNode == trvOptions.Nodes[0].Nodes[1])
					trvOptions.Nodes[0].Nodes[1].Expand();

				Select();
			}
			else
				Deselect();
        }

		private void trvOptions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			NavigationScreen myNavigation = GetNavigationScreen();

			//If the navigation screen is found then determine where to navigate the user
			if (myNavigation != null)
			{
				switch (e.Node.Name)
				{
					case "ndCustomer":
						myNavigation.NavigateTo(typeof(CustomerScreen));

						if (myNavigation.CurrentScreen is CustomerScreen)
						{
							CustomerScreen CustomerScreen = (CustomerScreen)myNavigation.CurrentScreen;

							if (CustomerScreen.MyCustomer == null || CustomerScreen.MyCustomer != this.MyCustomer)
								CustomerScreen.MyCustomer = this.MyCustomer;
						}
						break;
					case "ndContact":
						myNavigation.NavigateTo(typeof(ContactScreen));

						if (myNavigation.CurrentScreen is ContactScreen)
							((ContactScreen)myNavigation.CurrentScreen).MyContact = new Contact();

						break;
					case "ndProject":
						myNavigation.NavigateTo(typeof(ProjectScreen));

						if (myNavigation.CurrentScreen is ProjectScreen)
						{
							ProjectScreen ProjectScreen = (ProjectScreen)myNavigation.CurrentScreen;

							if (this.MyProject != null || ProjectScreen.MyProject != this.MyProject)
								ProjectScreen.MyProject = this.MyProject;
						}
						break;
					case "ndNote":
						myNavigation.NavigateTo(typeof(NoteScreen));

						if (myNavigation.CurrentScreen is NoteScreen)
						{
							NoteScreen myNoteScreen = (NoteScreen)myNavigation.CurrentScreen;

							if (myNoteScreen.MyNote == null || myNoteScreen.MyNote.ProjectID != MyProject.ID)
								myNoteScreen.MyNote = new Note();
						}
						break;
					case "ndQuote":
						myNavigation.NavigateTo(typeof(QuoteScreen));

						if (myNavigation.CurrentScreen is QuoteScreen)
						{
							QuoteScreen myQuoteScreen = (QuoteScreen)myNavigation.CurrentScreen;

							if (myQuoteScreen.MyQuote == null || myQuoteScreen.MyQuote.ProjectID != MyProject.ID)
								myQuoteScreen.MyQuote = new Quote();
						}
						break;
				}
			}
		}

		private void trvOptions_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node == trvOptions.Nodes[0] && this.MyCustomer == null)
				e.Cancel = true;

			if (e.Node == trvOptions.Nodes[0].Nodes[1] && (this.MyProject == null || this.MyProject.ID == 0))
				e.Cancel = true;
		}

		private void trvOptions_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node == trvOptions.Nodes[0] && this.MyCustomer != null)
				e.Cancel = true;

			if (e.Node == trvOptions.Nodes[0].Nodes[1] && this.MyProject != null && this.MyProject.ID > 0)
				e.Cancel = true;
		}

        #endregion


        #region Constructor

        public CustomerButton()
            : base()
        {
            InitializeComponent();
        }

        #endregion
    }
}
