using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace rkcrm.Base_Classes
{
	public partial class ObjectListBase : Form
	{


		#region Variables

		private bool bolIsSearchable = true;
		private bool bolSelectsObjects = true;

		private int sortedColumnIndex = -1;

		#endregion


		#region Properties

		[Category("Custom Properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public bool IsSearchable
		{
			get { return bolIsSearchable; }
			set
			{
				bolIsSearchable = value;

				if (bolIsSearchable)
				{
					lblTitle.Location = new Point(10, 9);
					pnlHeader.Height = 60;
					lblLookFor.Visible = true;
					txtLookFor.Visible = true;
					lblSearchIn.Visible = true;
					cboSearchIn.Visible = true;
					btnClearSearch.Visible = true;
					btnSearch.Visible = true;
				}
				else
				{
					lblTitle.Location = new Point(10, 16);
					pnlHeader.Height = 50;
					lblLookFor.Visible = false;
					txtLookFor.Visible = false;
					lblSearchIn.Visible = false;
					cboSearchIn.Visible = false;
					btnClearSearch.Visible = false;
					btnSearch.Visible = false;
				}

			}
		}

		[Category("Custom Properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string Title
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}

		[Category("Custom Properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public bool SelectsObjects
		{
			get { return bolSelectsObjects; }
			set
			{
				bolSelectsObjects = value;

				if (bolSelectsObjects)
				{
					btnCancel.Visible = true;
					btnOK.Location = new Point(32, 10);
				}
				else
				{
					btnCancel.Visible = false;
					btnOK.Location = btnCancel.Location;
				}
			}
		}

		public ListViewItem SelectedItem
		{
			get
			{
				if (lvwResults.SelectedItems.Count > 0)
					return lvwResults.SelectedItems[0];
				else
					return null;
			}
		}

		#endregion


		#region Methods

		public void Clear()
		{
			txtLookFor.Clear();

			if (cboSearchIn.Items.Count > 0)
				cboSearchIn.SelectedIndex = 0;

			ClearResults();
		}

		public void ClearResults()
		{
			if (lvwResults.SelectedItems.Count > 0)
				//This fires the ItemSelectionChanged event on the individual drop down objects
				lvwResults.SelectedItems[0].Selected = false;

			lvwResults.Items.Clear();
			lvwResults.Sorting = SortOrder.None;
			lvwResults.ListViewItemSorter = null;
			lblMessage.Visible = false;
		}

		public void ShowResultsMessage(string Message)
		{
			lblMessage.Text = Message;
			lblMessage.Visible = true;
		}

		#endregion


		#region Event Handler

		private void lblMessage_VisibleChanged(object sender, EventArgs e)
		{
			if (lblMessage.Visible)
			{
				lblMessage.Location = new Point(Convert.ToInt32(lvwResults.Location.X + 0.5 * (lvwResults.Width - lblMessage.Width)),
					Convert.ToInt32(lvwResults.Location.Y + 0.5 * (lvwResults.Height - lblMessage.Height)));
			}
		}

		private void lblMessage_TextChanged(object sender, EventArgs e)
		{
			if (lblMessage.Visible)
			{
				lblMessage.Location = new Point(Convert.ToInt32(lvwResults.Location.X + 0.5 * (lvwResults.Width - lblMessage.Width)),
					Convert.ToInt32(lvwResults.Location.Y + 0.5 * (lvwResults.Height - lblMessage.Height)));
			}
		}

		protected void lvwResults_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column != sortedColumnIndex)
			{
				sortedColumnIndex = e.Column;
				((ListView)sender).Sorting = SortOrder.Ascending;
			}
			else
				if (((ListView)sender).Sorting == SortOrder.Ascending)
					((ListView)sender).Sorting = SortOrder.Descending;
				else
					((ListView)sender).Sorting = SortOrder.Descending;

			((ListView)sender).ListViewItemSorter = new ListViewItemComparer(e.Column, ((ListView)sender).Sorting);
			((ListView)sender).Sort();
		}

		private void txtLookFor_TextChanged(object sender, EventArgs e)
		{
			btnSearch.Enabled = (cboSearchIn.SelectedValue != null && txtLookFor.TextLength > 0);
		}

		private void cboSearchIn_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnSearch.Enabled = (cboSearchIn.SelectedValue != null && txtLookFor.TextLength > 0);
		}

		private void control_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && btnSearch.Enabled)
				btnSearch.PerformClick();
		}

		private void btnClearSearch_Click(object sender, EventArgs e)
		{
			Clear();
		}

		#endregion


		#region Constructor

		public ObjectListBase()
		{
			InitializeComponent();
		}

		#endregion
	
	}
}
