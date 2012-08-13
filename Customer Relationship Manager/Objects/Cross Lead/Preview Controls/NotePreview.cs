using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rkcrm.Objects.Note;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Cross_Lead.Preview_Controls
{
	class NotePreview : PreviewBase
	{

		#region Variables

		public System.Windows.Forms.ListView lvwList;
		internal System.Windows.Forms.ColumnHeader chNoteID;
		internal System.Windows.Forms.ColumnHeader chProjectID;
		internal System.Windows.Forms.ColumnHeader chFollowUp;
		internal System.Windows.Forms.ColumnHeader chFollowedUp;
		internal System.Windows.Forms.ColumnHeader chPupose;
		internal System.Windows.Forms.ColumnHeader chContact;
		internal System.Windows.Forms.ColumnHeader cSalesRep;
		internal System.Windows.Forms.ColumnHeader chMethod;

		private const int ADMINISTRATOR = 1;

		#endregion	


		#region Methods

		private void InitializeComponent()
		{
			this.lvwList = new System.Windows.Forms.ListView();
			this.chNoteID = new System.Windows.Forms.ColumnHeader();
			this.chProjectID = new System.Windows.Forms.ColumnHeader();
			this.chFollowUp = new System.Windows.Forms.ColumnHeader();
			this.chFollowedUp = new System.Windows.Forms.ColumnHeader();
			this.chPupose = new System.Windows.Forms.ColumnHeader();
			this.chContact = new System.Windows.Forms.ColumnHeader();
			this.cSalesRep = new System.Windows.Forms.ColumnHeader();
			this.chMethod = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwList
			// 
			this.lvwList.AllowColumnReorder = true;
			this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNoteID,
            this.chProjectID,
            this.chFollowUp,
            this.chFollowedUp,
            this.chPupose,
            this.chContact,
            this.cSalesRep,
            this.chMethod});
			this.lvwList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwList.FullRowSelect = true;
			this.lvwList.HideSelection = false;
			this.lvwList.Location = new System.Drawing.Point(0, 24);
			this.lvwList.MultiSelect = false;
			this.lvwList.Name = "lvwList";
			this.lvwList.Size = new System.Drawing.Size(605, 176);
			this.lvwList.TabIndex = 5;
			this.lvwList.UseCompatibleStateImageBehavior = false;
			this.lvwList.View = System.Windows.Forms.View.Details;
			// 
			// chNoteID
			// 
			this.chNoteID.Text = "Note ID";
			this.chNoteID.Width = 0;
			// 
			// chProjectID
			// 
			this.chProjectID.Text = "Project ID";
			this.chProjectID.Width = 0;
			// 
			// chFollowUp
			// 
			this.chFollowUp.Text = "Followed Up on";
			this.chFollowUp.Width = 90;
			// 
			// chFollowedUp
			// 
			this.chFollowedUp.Text = "Followed Up";
			this.chFollowedUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.chFollowedUp.Width = 71;
			// 
			// chPupose
			// 
			this.chPupose.Text = "Purpose";
			this.chPupose.Width = 80;
			// 
			// chContact
			// 
			this.chContact.Text = "Person Contacted";
			this.chContact.Width = 125;
			// 
			// cSalesRep
			// 
			this.cSalesRep.Text = "Sales Rep";
			this.cSalesRep.Width = 88;
			// 
			// chMethod
			// 
			this.chMethod.Text = "Contact Method";
			this.chMethod.Width = 125;
			// 
			// NotePreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.lvwList);
			this.ExpandedHeight = 200;
			this.Name = "NotePreview";
			this.Size = new System.Drawing.Size(605, 200);
			this.Title = "Notes";
			this.Controls.SetChildIndex(this.lvwList, 0);
			this.ResumeLayout(false);

		}

		public void Clear()
		{
			Title = "Notes";
			lvwList.Items.Clear();
		}

		public void LoadNotes(int ProjectID)
		{
			DataTable notes;
			ListViewItem oItem;

			lvwList.Items.Clear();

			using (NoteController theController = new NoteController())
			{
				notes = theController.GetNotes(ProjectID, (thisUser.Role.ID == ADMINISTRATOR));
			}

			Title = "Notes - Count: " + notes.Rows.Count;

			foreach (DataRow oNote in notes.Rows)
			{
				oItem = new ListViewItem();

				oItem.Text = oNote["note_id"].ToString();
				oItem.SubItems.Add(oNote["project_id"].ToString());
				oItem.SubItems.Add(oNote["next_follow_up"] != DBNull.Value ? Convert.ToDateTime(oNote["next_follow_up"]).ToShortDateString() : string.Empty);
				oItem.SubItems.Add(oNote["completed"] != DBNull.Value ? Convert.ToDateTime(oNote["completed"]).ToShortDateString() : string.Empty);
				oItem.SubItems.Add(oNote["purpose"].ToString());
				oItem.SubItems.Add(oNote["contact"].ToString());
				oItem.SubItems.Add(oNote["sales_rep"].ToString());
				oItem.SubItems.Add(oNote["method"].ToString());

				if (Convert.ToBoolean(oNote["is_archived"]))
					oItem.BackColor = Color.LightSteelBlue;
				else
					oItem.BackColor = Color.White;

				lvwList.Items.Add(oItem);
			}
		}

		#endregion


		#region Constructor

		public NotePreview()
			: base()
		{
			InitializeComponent();

			Clear();
		}

		#endregion

	}
}
