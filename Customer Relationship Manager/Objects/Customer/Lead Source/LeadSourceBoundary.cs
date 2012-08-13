using System;
using System.Data;
using System.Windows.Forms;
using rkcrm.Administration.Department;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Customer.Lead_Source
{
	class LeadSourceBoundary : BoundaryBase
	{
		private System.Windows.Forms.Label lblDetails;
		public Label lblDepartments;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.TextBox txtDetails;
		public ListBox lbxDepartments;
		public DateTimePicker dtpEffective;
		public Label lblEffective;
		private System.Windows.Forms.ComboBox cboSource;

		private LeadSource clsMySource;
		private bool IsUpdating = false;
		private bool bolIsBasic = false;
		private bool bolShowDepartment = true;

		#region Properties

		public LeadSource MySource
		{
			get { return clsMySource; }
			set
			{
				if (clsMySource != value && clsMySource != null)
					clsMySource.Dispose();

				clsMySource = value;

				if (value == null)
					SetSearchingMode();
				else
				{
					if (value.ID > 0)
						SetEditingMode();
					else
						SetAddingMode();
				}

				OnMySourceChanged(new EventArgs());
			}
		}

		public bool IsBasic
		{
			get { return bolIsBasic; }
			set
			{
				bolIsBasic = value;

				if (value)
				{
					if (thisUser.HomeDepartment.IsProfitCenter || !bolShowDepartment)
						ShowDepartments = false;
					else
						ShowDepartments = true;

					lblEffective.Visible = false;
					dtpEffective.Visible = false;
				}
				else
				{
					lblDepartments.Visible = true;
					lbxDepartments.Visible = true;
					lblEffective.Visible = true;
					dtpEffective.Visible = true;
				}
			}
		}

		public bool ShowDepartments
		{
			get { return bolShowDepartment; }
			set
			{
				bolShowDepartment = value;

				if (value)
				{
					lblDepartments.Visible = true;
					lbxDepartments.Visible = true;
				}
				else
				{
					lblDepartments.Visible = false;
					lbxDepartments.Visible = false;
				}
			}
		}

		#endregion


		#region Methods

		private void InitializeComponent()
		{
			this.cboSource = new System.Windows.Forms.ComboBox();
			this.lbxDepartments = new System.Windows.Forms.ListBox();
			this.txtDetails = new System.Windows.Forms.TextBox();
			this.lblSource = new System.Windows.Forms.Label();
			this.lblDepartments = new System.Windows.Forms.Label();
			this.lblDetails = new System.Windows.Forms.Label();
			this.dtpEffective = new System.Windows.Forms.DateTimePicker();
			this.lblEffective = new System.Windows.Forms.Label();
			this.pnlControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlControls
			// 
			this.pnlControls.BackColor = System.Drawing.Color.White;
			this.pnlControls.Controls.Add(this.lblEffective);
			this.pnlControls.Controls.Add(this.dtpEffective);
			this.pnlControls.Controls.Add(this.lblDetails);
			this.pnlControls.Controls.Add(this.lblDepartments);
			this.pnlControls.Controls.Add(this.lblSource);
			this.pnlControls.Controls.Add(this.txtDetails);
			this.pnlControls.Controls.Add(this.lbxDepartments);
			this.pnlControls.Controls.Add(this.cboSource);
			this.pnlControls.Size = new System.Drawing.Size(590, 162);
			// 
			// cboSource
			// 
			this.cboSource.FormattingEnabled = true;
			this.cboSource.Location = new System.Drawing.Point(9, 26);
			this.cboSource.Name = "cboSource";
			this.cboSource.Size = new System.Drawing.Size(186, 21);
			this.cboSource.TabIndex = 0;
			this.cboSource.SelectionChangeCommitted += new System.EventHandler(this.cboSource_SelectionChangeCommitted);
			this.cboSource.TextChanged += new System.EventHandler(this.control_TextChanged);
			// 
			// lbxDepartments
			// 
			this.lbxDepartments.FormattingEnabled = true;
			this.lbxDepartments.Location = new System.Drawing.Point(9, 77);
			this.lbxDepartments.Name = "lbxDepartments";
			this.lbxDepartments.Size = new System.Drawing.Size(150, 69);
			this.lbxDepartments.TabIndex = 1;
			this.lbxDepartments.SelectedIndexChanged += new System.EventHandler(this.control_TextChanged);
			// 
			// txtDetails
			// 
			this.txtDetails.Location = new System.Drawing.Point(201, 26);
			this.txtDetails.Name = "txtDetails";
			this.txtDetails.Size = new System.Drawing.Size(317, 20);
			this.txtDetails.TabIndex = 2;
			this.txtDetails.TextChanged += new System.EventHandler(this.txtDetails_TextChanged);
			this.txtDetails.EnabledChanged += new System.EventHandler(this.txtDetails_EnabledChanged);
			// 
			// lblSource
			// 
			this.lblSource.AutoSize = true;
			this.lblSource.Location = new System.Drawing.Point(6, 10);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(68, 13);
			this.lblSource.TabIndex = 3;
			this.lblSource.Text = "Lead Source";
			// 
			// lblDepartments
			// 
			this.lblDepartments.AutoSize = true;
			this.lblDepartments.Location = new System.Drawing.Point(6, 61);
			this.lblDepartments.Name = "lblDepartments";
			this.lblDepartments.Size = new System.Drawing.Size(67, 13);
			this.lblDepartments.TabIndex = 4;
			this.lblDepartments.Text = "Departments";
			// 
			// lblDetails
			// 
			this.lblDetails.AutoSize = true;
			this.lblDetails.Location = new System.Drawing.Point(198, 10);
			this.lblDetails.Name = "lblDetails";
			this.lblDetails.Size = new System.Drawing.Size(39, 13);
			this.lblDetails.TabIndex = 5;
			this.lblDetails.Text = "Details";
			// 
			// dtpEffective
			// 
			this.dtpEffective.CustomFormat = "M/d/yy";
			this.dtpEffective.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEffective.Location = new System.Drawing.Point(190, 77);
			this.dtpEffective.Name = "dtpEffective";
			this.dtpEffective.Size = new System.Drawing.Size(95, 20);
			this.dtpEffective.TabIndex = 6;
			this.dtpEffective.ValueChanged += new System.EventHandler(this.control_TextChanged);
			// 
			// lblEffective
			// 
			this.lblEffective.AutoSize = true;
			this.lblEffective.Location = new System.Drawing.Point(187, 61);
			this.lblEffective.Name = "lblEffective";
			this.lblEffective.Size = new System.Drawing.Size(49, 13);
			this.lblEffective.TabIndex = 7;
			this.lblEffective.Text = "Effective";
			// 
			// LeadSourceBoundary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "LeadSourceBoundary";
			this.Size = new System.Drawing.Size(590, 212);
			this.Title = "Lead Sources";
			this.pnlControls.ResumeLayout(false);
			this.pnlControls.PerformLayout();
			this.ResumeLayout(false);

		}

		private void SetAddingMode()
		{
			this.State = BoundaryState.Loading;

			Clear();

			cboSource.Enabled = true;
			lbxDepartments.Enabled = true;
			txtDetails.Enabled = false;
			dtpEffective.Enabled = true;

			lbxDepartments.SelectedIndices.Add(IndexOfDepartment(thisUser.HomeDepartment.ID));
			dtpEffective.Value = DateTime.Today;

			this.IsDirty = false;
			this.State = BoundaryState.Adding;
			this.Title = "Add New Lead Source";
		}

		private void SetEditingMode()
		{
			this.State = BoundaryState.Loading;

			Clear();

			cboSource.Enabled = !MySource.IsArchived;
			lbxDepartments.Enabled = !MySource.IsArchived;
			txtDetails.Enabled = MySource.GetLeadSource().DetailsRequired && !MySource.IsArchived;
			dtpEffective.Enabled = !MySource.IsArchived;

			cboSource.SelectedValue = MySource.SourceID;
			lbxDepartments.SelectedValue = MySource.DepartmentID;
			txtDetails.Text = MySource.Details;
			dtpEffective.Value = MySource.Activated;
			ObjectCreated = MySource.Created.ToString("M/d/yyyy HH:mm");
			ObjectCreatedBy = MySource.GetCreator().UserName;
			ObjectUpdated = MySource.Updated.ToString("M/d/yyyy HH:mm");
			ObjectUpdatedBy = MySource.GetUpdater().UserName;

			//This enables the boundary to display those types that are no longer available
			if (cboSource.SelectedItem == null)
				cboSource.Text = MySource.GetLeadSource().Name;

			this.IsDirty = false;
			this.State = BoundaryState.Editing;
			this.Title = "Edit Lead Source";
		}

		public void SetSearchingMode()
		{
			this.State = BoundaryState.Loading;

			Clear();

			cboSource.Enabled = false;
			lbxDepartments.Enabled = false;
			txtDetails.Enabled = false;
			dtpEffective.Enabled = false;

			this.IsDirty = false;
			this.State = BoundaryState.Searching;
			this.Title = "Search Lead Sources";
		}

		private new void Clear()
		{
			base.Clear();

			cboSource.SelectedItem = null;
			lbxDepartments.SelectedItems.Clear();
			txtDetails.Clear();
			dtpEffective.Value = DateTime.Today;

		}

		public bool CommitChanges()
		{
			try
			{
				Administration.Lead_Source.LeadSource MyLeadSource = MySource.GetLeadSource();

				if (!IsSelectionValid(cboSource) && cboSource.Text != MyLeadSource.Name || string.IsNullOrEmpty(cboSource.Text))
					throw new Exception("The \"Lead Source\" is not valid.");
				if (Convert.ToBoolean(((DataRowView)cboSource.SelectedItem).Row["details_required"]) && string.IsNullOrEmpty(txtDetails.Text))
					throw new Exception("The \"Details*\" cannot be blank.");
				if (lbxDepartments.SelectedItems.Count == 0)
					throw new Exception("At least one department must be selected.");

				if (cboSource.SelectedItem != null)
					MySource.SourceID = Convert.ToInt32(cboSource.SelectedValue);
				MySource.Details = txtDetails.Text;
				MySource.DepartmentID = Convert.ToInt32(lbxDepartments.SelectedValue);
				MySource.Activated = dtpEffective.Value;
				
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, MySettings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		public int IndexOfDepartment(int DepartmentID)
		{
			int result = -1;

			foreach (object row in lbxDepartments.Items)
			{
				if (Convert.ToInt32(((DataRowView)row)["department_id"]) == DepartmentID)
					result = lbxDepartments.Items.IndexOf(row);
			}

			return result;
		}

		public bool Save()
		{
			bool result = true;

			if (CommitChanges())
			{
				using (LeadSourceController theController = new LeadSourceController())
				{
					if (MySource.ID > 0)
						result = theController.UpdateLeadSource(MySource);
					else
					{
						clsMySource = theController.InsertLeadSource(MySource);

						result = (MySource.ID > 0);
					}
				}
			}
			else
				result = false;

			return result;
		}

		#endregion


		#region Event Handlers

		private void txtDetails_EnabledChanged(object sender, EventArgs e)
		{
			lblDetails.Text = txtDetails.Enabled ? "Details*" : "Details";
		}

		private void cboSource_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if ((this.State == BoundaryState.Editing || this.State == BoundaryState.Adding) && cboSource.SelectedValue != null)
			{
				IsUpdating = true;
				txtDetails.Clear();
				IsUpdating = false;

				txtDetails.Enabled = Convert.ToBoolean(((DataRowView)cboSource.SelectedItem).Row["details_required"]);

				if (MySource != null && Convert.ToInt32(cboSource.SelectedValue) == MySource.SourceID)
				{
					//restore the original details
					IsUpdating = true;
					txtDetails.Text = MySource.Details;
					IsUpdating = false;
				}

				if (!string.IsNullOrEmpty(((DataRowView)cboSource.SelectedItem).Row["list_object"].ToString()))
				{
					// The details require a form to be fill out
					DetailFormBase oForm = (DetailFormBase)ObjectFactory.GetObject(((DataRowView)cboSource.SelectedItem).Row["list_object"].ToString());
					oForm.ShowDialog();

					if (oForm.DialogResult == DialogResult.OK)
					{
						IsUpdating = true;
						txtDetails.Text = oForm.ReturnString;
						IsUpdating = false;
					}
					else
					{
						if (MySource != null)
						{
							cboSource.SelectedValue = MySource.SourceID;
							IsUpdating = true;
							txtDetails.Text = MySource.Details;
							IsUpdating = false;

							if(cboSource.SelectedItem != null)
								txtDetails.Enabled = Convert.ToBoolean(((DataRowView)cboSource.SelectedItem).Row["details_required"]);
						}
					}

					oForm.Dispose();
					oForm = null;
				}
			}
		}

		private void txtDetails_TextChanged(object sender, EventArgs e)
		{
			if (!IsUpdating)
			{
				control_TextChanged(sender, e);

				if ((this.State == BoundaryState.Editing || this.State == BoundaryState.Adding) && cboSource.SelectedValue != null)
				{
					if (!string.IsNullOrEmpty(((DataRowView)cboSource.SelectedItem).Row["list_object"].ToString()))
					{
						// The details require a form to be fill out
						DetailFormBase oForm = (DetailFormBase)ObjectFactory.GetObject(((DataRowView)cboSource.SelectedItem).Row["list_object"].ToString());
						oForm.ShowDialog();

						if (oForm.DialogResult == DialogResult.OK)
						{
							IsUpdating = true;
							txtDetails.Text = oForm.ReturnString;
							IsUpdating = false;
						}
						else
						{
							if (MySource != null)
							{
								cboSource.SelectedValue = MySource.SourceID;
								IsUpdating = true;
								txtDetails.Text = MySource.Details;
								IsUpdating = false;
							}
						}

						oForm.Dispose();
						oForm = null;
					}
				}
			}
		}

		private void control_TextChanged(object sender, EventArgs e)
		{
			if (this.State == BoundaryState.Editing || this.State == BoundaryState.Adding)
				this.IsDirty = true;
		}

		#endregion


		#region Events

		public event EventHandler<EventArgs> MySourceChanged;
		protected virtual void OnMySourceChanged(EventArgs e)
		{
			EventHandler<EventArgs> handler = MySourceChanged;

			if (handler != null)
				handler(this, e);
		}

		#endregion


		#region Constructor

		public LeadSourceBoundary()
			: base()
		{
			InitializeComponent();

			using (Administration.Lead_Source.LeadSourceController theController = new Administration.Lead_Source.LeadSourceController())
			{
				cboSource.DataSource = theController.GetLeadSources();
				cboSource.DisplayMember = "name";
				cboSource.ValueMember = "source_id";
				cboSource.SelectedItem = null;
			}

			using (DepartmentController theController = new DepartmentController())
			{
				lbxDepartments.DataSource = theController.GetProfitCenters();
				lbxDepartments.DisplayMember = "name";
				lbxDepartments.ValueMember = "department_id";
				lbxDepartments.SelectedItems.Clear();
			}
		}

		#endregion

	}
}
