using System;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Cross_Lead.Preview_Controls
{
	class CrossLeadPreview : PreviewBase
	{

		#region Variables

		internal System.Windows.Forms.Label txtPlanID;
		internal System.Windows.Forms.Label lblPlanID;
		internal System.Windows.Forms.GroupBox gbxBiddingInfo;
		internal System.Windows.Forms.Label lblDigitalPlans;
		internal System.Windows.Forms.PictureBox pbxDigitalPlans;
		internal System.Windows.Forms.Label lblMaterialsList;
		internal System.Windows.Forms.PictureBox pbxMaterialsList;
		internal System.Windows.Forms.Label lblContactCustomer;
		internal System.Windows.Forms.PictureBox pbxContactCustomer;
		internal System.Windows.Forms.Label lblPaperPlans;
		internal System.Windows.Forms.PictureBox pbxPaperPlans;
		internal System.Windows.Forms.Label lblSpacer;
		internal System.Windows.Forms.Label txtNotes;
		internal System.Windows.Forms.Label lblNotes;
		internal System.Windows.Forms.Label txtBidDue;
		internal System.Windows.Forms.Label lblBidDue;

		#endregion	


		#region Properties

		public string BidDue
		{
			get { return txtBidDue.Text; }
			set { txtBidDue.Text = value; }
		}

		public string Notes
		{
			get { return txtNotes.Text; }
			set { txtNotes.Text = value; }
		}

		public bool PaperPlansAvailable
		{
			get { return (pbxPaperPlans.Image != null); }
			set
			{
				if (value)
				{
					pbxPaperPlans.Image = global::rkcrm.Properties.Resources.Check_icon_16x16;
					lblPlanID.Visible = true;
					txtPlanID.Visible = true;
				}
				else
				{
					pbxPaperPlans.Image = null;
					lblPlanID.Visible = false;
					txtPlanID.Visible = false;
				}
			}
		}

		public bool DigitalPlansAvailable
		{
			get { return (pbxPaperPlans.Image != null); }
			set
			{
				if (value)
					pbxDigitalPlans.Image = global::rkcrm.Properties.Resources.Check_icon_16x16;
				else
					pbxDigitalPlans.Image = null;
			}
		}

		public bool HasMaterialList
		{
			get { return (pbxMaterialsList.Image != null); }
			set
			{
				if (value)
					pbxMaterialsList.Image = global::rkcrm.Properties.Resources.Check_icon_16x16;
				else
					pbxMaterialsList.Image = null;
			}
		}

		public bool ContactCustomer
		{
			get { return (pbxContactCustomer.Image != null); }
			set
			{
				if (value)
					pbxContactCustomer.Image = global::rkcrm.Properties.Resources.Check_icon_16x16;
				else
					pbxContactCustomer.Image = null;
			}
		}

		public int PlanID
		{
			get 
			{
				if (string.IsNullOrEmpty(txtPlanID.Text))
					return 0;
				else
					return Convert.ToInt32(txtPlanID.Text);
			}
			set 
			{
				if (value == 0)
					txtPlanID.Text = string.Empty;
				else
					txtPlanID.Text = value.ToString();
			}
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.txtPlanID = new System.Windows.Forms.Label();
			this.lblPlanID = new System.Windows.Forms.Label();
			this.gbxBiddingInfo = new System.Windows.Forms.GroupBox();
			this.lblDigitalPlans = new System.Windows.Forms.Label();
			this.pbxDigitalPlans = new System.Windows.Forms.PictureBox();
			this.lblMaterialsList = new System.Windows.Forms.Label();
			this.pbxMaterialsList = new System.Windows.Forms.PictureBox();
			this.lblContactCustomer = new System.Windows.Forms.Label();
			this.pbxContactCustomer = new System.Windows.Forms.PictureBox();
			this.lblPaperPlans = new System.Windows.Forms.Label();
			this.pbxPaperPlans = new System.Windows.Forms.PictureBox();
			this.lblSpacer = new System.Windows.Forms.Label();
			this.txtNotes = new System.Windows.Forms.Label();
			this.lblNotes = new System.Windows.Forms.Label();
			this.txtBidDue = new System.Windows.Forms.Label();
			this.lblBidDue = new System.Windows.Forms.Label();
			this.gbxBiddingInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxDigitalPlans)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxMaterialsList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxContactCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxPaperPlans)).BeginInit();
			this.SuspendLayout();
			// 
			// txtPlanID
			// 
			this.txtPlanID.BackColor = System.Drawing.Color.White;
			this.txtPlanID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPlanID.Location = new System.Drawing.Point(306, 127);
			this.txtPlanID.Name = "txtPlanID";
			this.txtPlanID.Size = new System.Drawing.Size(100, 20);
			this.txtPlanID.TabIndex = 19;
			this.txtPlanID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPlanID
			// 
			this.lblPlanID.AutoSize = true;
			this.lblPlanID.Location = new System.Drawing.Point(211, 131);
			this.lblPlanID.Name = "lblPlanID";
			this.lblPlanID.Size = new System.Drawing.Size(90, 13);
			this.lblPlanID.TabIndex = 18;
			this.lblPlanID.Text = "Plan Tracking ID:";
			// 
			// gbxBiddingInfo
			// 
			this.gbxBiddingInfo.Controls.Add(this.lblDigitalPlans);
			this.gbxBiddingInfo.Controls.Add(this.pbxDigitalPlans);
			this.gbxBiddingInfo.Controls.Add(this.lblMaterialsList);
			this.gbxBiddingInfo.Controls.Add(this.pbxMaterialsList);
			this.gbxBiddingInfo.Controls.Add(this.lblContactCustomer);
			this.gbxBiddingInfo.Controls.Add(this.pbxContactCustomer);
			this.gbxBiddingInfo.Controls.Add(this.lblPaperPlans);
			this.gbxBiddingInfo.Controls.Add(this.pbxPaperPlans);
			this.gbxBiddingInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxBiddingInfo.Location = new System.Drawing.Point(0, 27);
			this.gbxBiddingInfo.Name = "gbxBiddingInfo";
			this.gbxBiddingInfo.Size = new System.Drawing.Size(605, 81);
			this.gbxBiddingInfo.TabIndex = 12;
			this.gbxBiddingInfo.TabStop = false;
			this.gbxBiddingInfo.Text = "Bidding Information";
			// 
			// lblDigitalPlans
			// 
			this.lblDigitalPlans.AutoSize = true;
			this.lblDigitalPlans.Location = new System.Drawing.Point(35, 49);
			this.lblDigitalPlans.Name = "lblDigitalPlans";
			this.lblDigitalPlans.Size = new System.Drawing.Size(127, 13);
			this.lblDigitalPlans.TabIndex = 10;
			this.lblDigitalPlans.Text = "Digital plans are available";
			// 
			// pbxDigitalPlans
			// 
			this.pbxDigitalPlans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbxDigitalPlans.Image = global::rkcrm.Properties.Resources.Check_icon_16x16;
			this.pbxDigitalPlans.Location = new System.Drawing.Point(13, 47);
			this.pbxDigitalPlans.Name = "pbxDigitalPlans";
			this.pbxDigitalPlans.Padding = new System.Windows.Forms.Padding(1);
			this.pbxDigitalPlans.Size = new System.Drawing.Size(16, 16);
			this.pbxDigitalPlans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxDigitalPlans.TabIndex = 9;
			this.pbxDigitalPlans.TabStop = false;
			// 
			// lblMaterialsList
			// 
			this.lblMaterialsList.AutoSize = true;
			this.lblMaterialsList.Location = new System.Drawing.Point(250, 24);
			this.lblMaterialsList.Name = "lblMaterialsList";
			this.lblMaterialsList.Size = new System.Drawing.Size(130, 13);
			this.lblMaterialsList.TabIndex = 8;
			this.lblMaterialsList.Text = "A maiterials list is available";
			// 
			// pbxMaterialsList
			// 
			this.pbxMaterialsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbxMaterialsList.Image = global::rkcrm.Properties.Resources.Check_icon_16x16;
			this.pbxMaterialsList.Location = new System.Drawing.Point(228, 22);
			this.pbxMaterialsList.Name = "pbxMaterialsList";
			this.pbxMaterialsList.Padding = new System.Windows.Forms.Padding(1);
			this.pbxMaterialsList.Size = new System.Drawing.Size(16, 16);
			this.pbxMaterialsList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxMaterialsList.TabIndex = 7;
			this.pbxMaterialsList.TabStop = false;
			// 
			// lblContactCustomer
			// 
			this.lblContactCustomer.AutoSize = true;
			this.lblContactCustomer.Location = new System.Drawing.Point(250, 49);
			this.lblContactCustomer.Name = "lblContactCustomer";
			this.lblContactCustomer.Size = new System.Drawing.Size(156, 13);
			this.lblContactCustomer.TabIndex = 6;
			this.lblContactCustomer.Text = "Contact the customer for details";
			// 
			// pbxContactCustomer
			// 
			this.pbxContactCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbxContactCustomer.Image = global::rkcrm.Properties.Resources.Check_icon_16x16;
			this.pbxContactCustomer.Location = new System.Drawing.Point(228, 47);
			this.pbxContactCustomer.Name = "pbxContactCustomer";
			this.pbxContactCustomer.Padding = new System.Windows.Forms.Padding(1);
			this.pbxContactCustomer.Size = new System.Drawing.Size(16, 16);
			this.pbxContactCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxContactCustomer.TabIndex = 5;
			this.pbxContactCustomer.TabStop = false;
			// 
			// lblPaperPlans
			// 
			this.lblPaperPlans.AutoSize = true;
			this.lblPaperPlans.Location = new System.Drawing.Point(35, 24);
			this.lblPaperPlans.Name = "lblPaperPlans";
			this.lblPaperPlans.Size = new System.Drawing.Size(126, 13);
			this.lblPaperPlans.TabIndex = 4;
			this.lblPaperPlans.Text = "Paper plans are available";
			// 
			// pbxPaperPlans
			// 
			this.pbxPaperPlans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbxPaperPlans.Image = global::rkcrm.Properties.Resources.Check_icon_16x16;
			this.pbxPaperPlans.Location = new System.Drawing.Point(13, 22);
			this.pbxPaperPlans.Name = "pbxPaperPlans";
			this.pbxPaperPlans.Padding = new System.Windows.Forms.Padding(1);
			this.pbxPaperPlans.Size = new System.Drawing.Size(16, 16);
			this.pbxPaperPlans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxPaperPlans.TabIndex = 0;
			this.pbxPaperPlans.TabStop = false;
			// 
			// lblSpacer
			// 
			this.lblSpacer.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblSpacer.Location = new System.Drawing.Point(0, 24);
			this.lblSpacer.Name = "lblSpacer";
			this.lblSpacer.Size = new System.Drawing.Size(605, 3);
			this.lblSpacer.TabIndex = 17;
			// 
			// txtNotes
			// 
			this.txtNotes.BackColor = System.Drawing.Color.White;
			this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNotes.Location = new System.Drawing.Point(8, 180);
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new System.Drawing.Size(587, 50);
			this.txtNotes.TabIndex = 16;
			// 
			// lblNotes
			// 
			this.lblNotes.AutoSize = true;
			this.lblNotes.Location = new System.Drawing.Point(5, 160);
			this.lblNotes.Name = "lblNotes";
			this.lblNotes.Size = new System.Drawing.Size(84, 13);
			this.lblNotes.TabIndex = 15;
			this.lblNotes.Text = "Additional Notes";
			// 
			// txtBidDue
			// 
			this.txtBidDue.BackColor = System.Drawing.Color.White;
			this.txtBidDue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtBidDue.Location = new System.Drawing.Point(74, 127);
			this.txtBidDue.Name = "txtBidDue";
			this.txtBidDue.Size = new System.Drawing.Size(100, 20);
			this.txtBidDue.TabIndex = 14;
			this.txtBidDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblBidDue
			// 
			this.lblBidDue.AutoSize = true;
			this.lblBidDue.Location = new System.Drawing.Point(5, 131);
			this.lblBidDue.Name = "lblBidDue";
			this.lblBidDue.Size = new System.Drawing.Size(63, 13);
			this.lblBidDue.TabIndex = 13;
			this.lblBidDue.Text = "Bid Due By:";
			// 
			// CrossLeadPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.txtPlanID);
			this.Controls.Add(this.lblPlanID);
			this.Controls.Add(this.gbxBiddingInfo);
			this.Controls.Add(this.lblSpacer);
			this.Controls.Add(this.txtNotes);
			this.Controls.Add(this.lblNotes);
			this.Controls.Add(this.txtBidDue);
			this.Controls.Add(this.lblBidDue);
			this.ExpandedHeight = 236;
			this.Name = "CrossLeadPreview";
			this.Size = new System.Drawing.Size(605, 236);
			this.Title = "Cross Lead";
			this.Controls.SetChildIndex(this.lblBidDue, 0);
			this.Controls.SetChildIndex(this.txtBidDue, 0);
			this.Controls.SetChildIndex(this.lblNotes, 0);
			this.Controls.SetChildIndex(this.txtNotes, 0);
			this.Controls.SetChildIndex(this.lblSpacer, 0);
			this.Controls.SetChildIndex(this.gbxBiddingInfo, 0);
			this.Controls.SetChildIndex(this.lblPlanID, 0);
			this.Controls.SetChildIndex(this.txtPlanID, 0);
			this.gbxBiddingInfo.ResumeLayout(false);
			this.gbxBiddingInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxDigitalPlans)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxMaterialsList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxContactCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxPaperPlans)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void Clear()
		{
			Title = "Cross Lead";

			pbxContactCustomer.Image = null;
			pbxDigitalPlans.Image = null;
			pbxMaterialsList.Image = null;
			pbxPaperPlans.Image = null;
			lblBidDue.Text = string.Empty;
			txtNotes.Text = string.Empty;
			txtPlanID.Text = string.Empty;
		}

		public void LoadData(CrossLead theLead)
		{
			BidDue = theLead.BidDue.ToShortDateString();
			Notes = theLead.Notes;
			PaperPlansAvailable = theLead.IsPaperAvailable;
			DigitalPlansAvailable = theLead.IsDigitalAvailable;
			HasMaterialList = theLead.IsListAvailable;
			ContactCustomer = theLead.CustomerHasDetails;
			PlanID = theLead.PlanID;
		}

		#endregion


		#region Constructor

		public CrossLeadPreview()
			: base()
		{
			InitializeComponent();

			Clear();
		}

		#endregion

	}
}
