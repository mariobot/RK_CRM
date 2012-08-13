using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace rkcrm.Base_Classes
{
	public partial class PreviewBase : UserControl
	{

		#region Variables

		private bool bolIsExpanded = true;
		private int intExpandedHeight = 200;

		#endregion


		#region Properties

		[Category("Custom Properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public bool IsExpanded
		{
			get { return bolIsExpanded; }
			set
			{
				bolIsExpanded = value;

				if (value)
				{
					this.Height = intExpandedHeight;
					pbxMinMax.Image = imlExpandCollapse.Images[0];
					pnlLine.Visible = true;
				}
				else
				{
					this.Height = 27;
					pbxMinMax.Image = imlExpandCollapse.Images[1];
					pnlLine.Visible = false;
				}

				OnExpandedChanged(new EventArgs());
			}
		}

		[Category("Custom Properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string Title
		{
			get { return lblTilte.Text; }
			set { lblTilte.Text = value; }
		}

		[Category("Custom Properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public int ExpandedHeight
		{
			get { return intExpandedHeight; }
			set 
			{ 
				intExpandedHeight = value;
				IsExpanded = true;
			}
		}

		#endregion


		#region Event Handlers

		private void pbxMinMax_Click(object sender, EventArgs e)
		{
			IsExpanded = !IsExpanded;
		}

		#endregion


		#region Constructors

		public PreviewBase()
		{
			InitializeComponent();

			if (intExpandedHeight <= 27)
				intExpandedHeight = 200;
			else
				intExpandedHeight = this.Height;
		}

		#endregion


		#region Custom Events

		public event EventHandler<EventArgs> ExpandedChanged;
		protected virtual void OnExpandedChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = ExpandedChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion
	
	}
}
