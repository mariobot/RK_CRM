using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace rkcrm.Base_Classes
{
    public partial class NavigationButtonBase : UserControl
    {
        #region Variables

        private Image imgCurrentImage;
        
        private const int ImageHighlighted = 0;
        private const int ImageSelected = 1;
        private const int ImageUnselected = 2;

        private bool bolHasOptions = true;
        private bool bolIsSelected = false;

        #endregion


        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Custom Properties")]
        public bool HasOptions
        {
            get { return bolHasOptions; }
            set { bolHasOptions = value; }
        }
        

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Custom Properties")]
        public bool IsSelected
        {
            get { return bolIsSelected; }
            set 
            { 
                bolIsSelected = value;

                if (bolIsSelected)
                    Select();
                else
                    Deselect();
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Custom Properties")]
        public string ButtonText
        {
            get { return lblButtonText.Text; }
            set { lblButtonText.Text = value; }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Custom Properties")]
        public Image Icon
        {
            get { return pbxIcon.Image; }
            set { pbxIcon.Image = value; }
        }


        #endregion


        #region Methods

        /// <summary>
        /// Gets the rkcrm.Navigation.NavigationScreen object that contains this control
        /// </summary>
        /// <returns></returns>
        public Navigation.NavigationScreen GetNavigationScreen()
        {
            Control myNavigation = this;

            //Find the navigation screen that contains this button
            while (!(myNavigation is Navigation.NavigationScreen) && myNavigation.Parent != null)
                myNavigation = myNavigation.Parent;

            if (myNavigation is Navigation.NavigationScreen)
                return (Navigation.NavigationScreen)myNavigation;
            else
                return null;
        }

        public new void Select()
        {
            base.Select();

            if (HasOptions)
            {
                foreach (Control o in this.Controls)
                {
                    //The + 1 makes room for a possible horizontal scroll bar. The + 32 is for the pnlButton control
                    if (o is TreeView)
                        this.Height = (CountVisibleNodes(((TreeView)o).Nodes) + 1) * 18 + 32;
                }
            }

			imgCurrentImage = imlBackground.Images[ImageSelected];
			pnlButton.BackgroundImage = imgCurrentImage;
        }

        public void Deselect()
        {
			imgCurrentImage = imlBackground.Images[ImageUnselected];
			pnlButton.BackgroundImage = imgCurrentImage;
            this.Height = 32;
        }

        /// <summary>
        /// Counts all visible nodes within a TreeNodeCollection
        /// </summary>
        /// <param name="theNodes"></param>
        /// <returns></returns>
        protected int CountVisibleNodes(TreeNodeCollection theNodes)
        {
            int count = 0;

            foreach (TreeNode theNode in theNodes)
            {
                count++;

                if (theNode.IsExpanded)
                    count += CountVisibleNodes(theNode.Nodes);
            }

            return count;
        }

        #endregion


        #region EventHandlers

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            imgCurrentImage = ((Control)sender).BackgroundImage;
            ((Control)sender).BackgroundImage = imlBackground.Images[ImageHighlighted];
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = imgCurrentImage;
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            imgCurrentImage = imlBackground.Images[ImageSelected];
            this.OnClick(new EventArgs());
        }

        private void ChildControl_MouseEnter(object sender, EventArgs e)
        {
            Button_MouseEnter(((Control)sender).Parent, e);
        }

        private void ChildControl_MouseLeave(object sender, EventArgs e)
        {
            Button_MouseLeave(((Control)sender).Parent, e);
        }

        private void ChildControl_MouseUp(object sender, MouseEventArgs e)
        {
            Button_MouseUp(((Control)sender).Parent, e);
        }

        #endregion


        #region Constructor

        public NavigationButtonBase()
        {
            InitializeComponent();

            pnlButton.MouseEnter += new EventHandler(Button_MouseEnter);
            pbxIcon.MouseEnter += new EventHandler(ChildControl_MouseEnter);
            lblButtonText.MouseEnter += new EventHandler(ChildControl_MouseEnter);

            pnlButton.MouseLeave += new EventHandler(Button_MouseLeave);
            pbxIcon.MouseLeave += new EventHandler(ChildControl_MouseLeave);
            lblButtonText.MouseLeave += new EventHandler(ChildControl_MouseLeave);

            pnlButton.MouseUp += new MouseEventHandler(Button_MouseUp);
            pbxIcon.MouseUp += new MouseEventHandler(ChildControl_MouseUp);
            lblButtonText.MouseUp += new MouseEventHandler(ChildControl_MouseUp);

            pnlButton.BackgroundImage = imlBackground.Images[ImageUnselected];
            this.Height = 32;
        }

        #endregion
    }
}
