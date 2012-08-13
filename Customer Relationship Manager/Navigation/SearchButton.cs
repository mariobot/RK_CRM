using System;
using System.Windows.Forms;
using rkcrm.Base_Classes;
using rkcrm.Searching;

namespace rkcrm.Navigation
{
    public class SearchButton : NavigationButtonBase
    {
        internal System.Windows.Forms.ImageList imlTreeView;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.TreeView trvOptions;

        #region Methods

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Customer Search");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Project Search");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Quote Search");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchButton));
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
            treeNode1.Name = "ndCustomer";
            treeNode1.Text = "Customer Search";
            treeNode2.Name = "ndProject";
            treeNode2.Text = "Project Search";
            treeNode3.Name = "ndQuote";
            treeNode3.Text = "Quote Search";
            this.trvOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.trvOptions.SelectedImageIndex = 1;
            this.trvOptions.ShowLines = false;
            this.trvOptions.ShowPlusMinus = false;
            this.trvOptions.ShowRootLines = false;
            this.trvOptions.Size = new System.Drawing.Size(191, 67);
            this.trvOptions.TabIndex = 1;
            this.trvOptions.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.trvOptions_AfterCollapse);
            this.trvOptions.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvOptions_NodeMouseClick);
            this.trvOptions.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.trvOptions_AfterExpand);
            // 
            // imlTreeView
            // 
            this.imlTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTreeView.ImageStream")));
            this.imlTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTreeView.Images.SetKeyName(0, "BD14870_.GIF");
            this.imlTreeView.Images.SetKeyName(1, "BD14868_.GIF");
            // 
            // SearchButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ButtonText = "Search";
            this.Controls.Add(this.trvOptions);
            this.Icon = global::rkcrm.Properties.Resources.Search;
            this.Name = "SearchButton";
            this.Size = new System.Drawing.Size(191, 100);
            this.Click += new System.EventHandler(this.SearchButton_Click);
            this.Controls.SetChildIndex(this.trvOptions, 0);
            this.ResumeLayout(false);

        }

        public new void Select()
        {
            base.Select();

            if (trvOptions.SelectedNode == null)
            {
                trvOptions_NodeMouseClick(trvOptions.Nodes[0], new TreeNodeMouseClickEventArgs(trvOptions.Nodes[0], MouseButtons.Left, 1, 10, 10));
                trvOptions.SelectedNode = trvOptions.Nodes[0];
            }
            else
                trvOptions_NodeMouseClick(trvOptions.SelectedNode, new TreeNodeMouseClickEventArgs(trvOptions.SelectedNode, MouseButtons.Left, 1, 10,
                    (trvOptions.SelectedNode.Index + trvOptions.SelectedNode.Level) * 18 + 10));
        }

		private void ValidateSecurityAccess()
		{
			//trvOptions.Nodes[0] = ndCustomer 
			//trvOptions.Nodes[1] = ndProject
			//trvOptions.Nodes[2] = ndQuote

			char[] charArray = Convert.ToString(7, 2).PadLeft(trvOptions.Nodes.Count, '0').ToCharArray();
			int index = 0;
			int nodeIndex = 0;

			while (index < charArray.Length && nodeIndex < trvOptions.Nodes.Count)
			{
				if (charArray[index] == '0')
					trvOptions.Nodes[nodeIndex].Remove();
				else
					nodeIndex++;
				index++;
			}

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

        private void trvOptions_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            NavigationScreen myNavigation = GetNavigationScreen();

            //If the navigation screen is found then determine where to navigate the user
            if (myNavigation != null)
            {
                switch (e.Node.Name)
                {
                    case "ndCustomer":
                        myNavigation.NavigateTo(typeof(CustomerSearchScreen));
                        break;
                    case "ndProject":
                        myNavigation.NavigateTo(typeof(ProjectSearchScreen));
                        break;
                    case "ndQuote":
                        myNavigation.NavigateTo(typeof(QuoteSearchScreen));
                        break;
                }
            }
        }

        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            Select();
        }

        #endregion


        #region Constructor

        public SearchButton()
            : base()
        {
            InitializeComponent();

			//ValidateSecurityAccess();
        }

        #endregion
    }
}
