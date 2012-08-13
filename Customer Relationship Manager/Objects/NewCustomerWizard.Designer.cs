namespace rkcrm.Objects
{
	partial class NewCustomerWizard
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCustomerWizard));
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnFinish = new System.Windows.Forms.Button();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlQuote = new System.Windows.Forms.Panel();
			this.gbxStatus = new System.Windows.Forms.GroupBox();
			this.btnOustanding = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnLost = new System.Windows.Forms.Button();
			this.btnSold = new System.Windows.Forms.Button();
			this.lblQuoteTitle = new System.Windows.Forms.Label();
			this.pnlNote = new System.Windows.Forms.Panel();
			this.lblNoteTitle = new System.Windows.Forms.Label();
			this.pnlProject = new System.Windows.Forms.Panel();
			this.lblCrossLeadTitle = new System.Windows.Forms.Label();
			this.lblProjectTitle = new System.Windows.Forms.Label();
			this.pnlCustomer = new System.Windows.Forms.Panel();
			this.lblCustomerTitle = new System.Windows.Forms.Label();
			this.lblContactTitle = new System.Windows.Forms.Label();
			this.pnlTitleBar = new System.Windows.Forms.Panel();
			this.lblNotePosition = new System.Windows.Forms.Label();
			this.lblQuotePosition = new System.Windows.Forms.Label();
			this.lblProjectPosition = new System.Windows.Forms.Label();
			this.lblCustomerPosition = new System.Windows.Forms.Label();
			this.quoteControls = new rkcrm.Objects.Quote.QuoteBoundary();
			this.noteControls = new rkcrm.Objects.Note.NoteBoundary();
			this.crossLeadControls = new rkcrm.Objects.Cross_Lead.CrossLeadBoundary();
			this.projectControls = new rkcrm.Objects.Project.ProjectBoundary();
			this.customerControls = new rkcrm.Objects.Customer.CustomerBoundary();
			this.contactControls = new rkcrm.Objects.Contact.ContactBoundary();
			this.pnlFooter.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.pnlQuote.SuspendLayout();
			this.gbxStatus.SuspendLayout();
			this.pnlNote.SuspendLayout();
			this.pnlProject.SuspendLayout();
			this.pnlCustomer.SuspendLayout();
			this.pnlTitleBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.btnClear);
			this.pnlFooter.Controls.Add(this.btnCancel);
			this.pnlFooter.Controls.Add(this.btnBack);
			this.pnlFooter.Controls.Add(this.btnNext);
			this.pnlFooter.Controls.Add(this.btnFinish);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 512);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(624, 50);
			this.pnlFooter.TabIndex = 0;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(12, 10);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 30);
			this.btnClear.TabIndex = 4;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(294, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnBack
			// 
			this.btnBack.Enabled = false;
			this.btnBack.Location = new System.Drawing.Point(375, 10);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(75, 30);
			this.btnBack.TabIndex = 2;
			this.btnBack.Text = "<  &Back";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnNext
			// 
			this.btnNext.Enabled = false;
			this.btnNext.Location = new System.Drawing.Point(456, 10);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 30);
			this.btnNext.TabIndex = 1;
			this.btnNext.Text = "Next  >";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnFinish
			// 
			this.btnFinish.Location = new System.Drawing.Point(537, 10);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(75, 30);
			this.btnFinish.TabIndex = 0;
			this.btnFinish.Text = "Finish";
			this.btnFinish.UseVisualStyleBackColor = true;
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlQuote);
			this.pnlMain.Controls.Add(this.pnlNote);
			this.pnlMain.Controls.Add(this.pnlProject);
			this.pnlMain.Controls.Add(this.pnlCustomer);
			this.pnlMain.Controls.Add(this.pnlTitleBar);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(624, 512);
			this.pnlMain.TabIndex = 1;
			// 
			// pnlQuote
			// 
			this.pnlQuote.Controls.Add(this.quoteControls);
			this.pnlQuote.Controls.Add(this.gbxStatus);
			this.pnlQuote.Controls.Add(this.lblQuoteTitle);
			this.pnlQuote.Location = new System.Drawing.Point(500, 5000);
			this.pnlQuote.Name = "pnlQuote";
			this.pnlQuote.Size = new System.Drawing.Size(624, 462);
			this.pnlQuote.TabIndex = 3;
			// 
			// gbxStatus
			// 
			this.gbxStatus.BackColor = System.Drawing.Color.White;
			this.gbxStatus.Controls.Add(this.btnOustanding);
			this.gbxStatus.Controls.Add(this.lblStatus);
			this.gbxStatus.Controls.Add(this.btnLost);
			this.gbxStatus.Controls.Add(this.btnSold);
			this.gbxStatus.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxStatus.Location = new System.Drawing.Point(0, 23);
			this.gbxStatus.Name = "gbxStatus";
			this.gbxStatus.Size = new System.Drawing.Size(624, 67);
			this.gbxStatus.TabIndex = 2;
			this.gbxStatus.TabStop = false;
			this.gbxStatus.Text = "Status";
			// 
			// btnOustanding
			// 
			this.btnOustanding.Image = global::rkcrm.Properties.Resources.Reopen28x28;
			this.btnOustanding.Location = new System.Drawing.Point(217, 19);
			this.btnOustanding.Name = "btnOustanding";
			this.btnOustanding.Size = new System.Drawing.Size(35, 35);
			this.btnOustanding.TabIndex = 3;
			this.btnOustanding.UseVisualStyleBackColor = true;
			this.btnOustanding.Click += new System.EventHandler(this.btnOustanding_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(12, 24);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(110, 25);
			this.lblStatus.TabIndex = 2;
			this.lblStatus.Text = "Oustanding";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnLost
			// 
			this.btnLost.Image = global::rkcrm.Properties.Resources.Lost_Icon;
			this.btnLost.Location = new System.Drawing.Point(176, 19);
			this.btnLost.Name = "btnLost";
			this.btnLost.Size = new System.Drawing.Size(35, 35);
			this.btnLost.TabIndex = 1;
			this.btnLost.UseVisualStyleBackColor = true;
			this.btnLost.Click += new System.EventHandler(this.btnLost_Click);
			// 
			// btnSold
			// 
			this.btnSold.Image = global::rkcrm.Properties.Resources.Sold_Icon;
			this.btnSold.Location = new System.Drawing.Point(135, 19);
			this.btnSold.Name = "btnSold";
			this.btnSold.Size = new System.Drawing.Size(35, 35);
			this.btnSold.TabIndex = 0;
			this.btnSold.UseVisualStyleBackColor = true;
			this.btnSold.Click += new System.EventHandler(this.btnSold_Click);
			// 
			// lblQuoteTitle
			// 
			this.lblQuoteTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.lblQuoteTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblQuoteTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQuoteTitle.ForeColor = System.Drawing.Color.White;
			this.lblQuoteTitle.Location = new System.Drawing.Point(0, 0);
			this.lblQuoteTitle.Name = "lblQuoteTitle";
			this.lblQuoteTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblQuoteTitle.Size = new System.Drawing.Size(624, 23);
			this.lblQuoteTitle.TabIndex = 0;
			this.lblQuoteTitle.Text = "Quote Information";
			this.lblQuoteTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlNote
			// 
			this.pnlNote.Controls.Add(this.noteControls);
			this.pnlNote.Controls.Add(this.lblNoteTitle);
			this.pnlNote.Location = new System.Drawing.Point(319, 281);
			this.pnlNote.Name = "pnlNote";
			this.pnlNote.Size = new System.Drawing.Size(302, 222);
			this.pnlNote.TabIndex = 4;
			// 
			// lblNoteTitle
			// 
			this.lblNoteTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.lblNoteTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblNoteTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNoteTitle.ForeColor = System.Drawing.Color.White;
			this.lblNoteTitle.Location = new System.Drawing.Point(0, 0);
			this.lblNoteTitle.Name = "lblNoteTitle";
			this.lblNoteTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblNoteTitle.Size = new System.Drawing.Size(302, 23);
			this.lblNoteTitle.TabIndex = 0;
			this.lblNoteTitle.Text = "Note Information";
			this.lblNoteTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlProject
			// 
			this.pnlProject.Controls.Add(this.crossLeadControls);
			this.pnlProject.Controls.Add(this.lblCrossLeadTitle);
			this.pnlProject.Controls.Add(this.projectControls);
			this.pnlProject.Controls.Add(this.lblProjectTitle);
			this.pnlProject.Location = new System.Drawing.Point(319, 53);
			this.pnlProject.Name = "pnlProject";
			this.pnlProject.Size = new System.Drawing.Size(624, 462);
			this.pnlProject.TabIndex = 2;
			// 
			// lblCrossLeadTitle
			// 
			this.lblCrossLeadTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.lblCrossLeadTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblCrossLeadTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCrossLeadTitle.ForeColor = System.Drawing.Color.White;
			this.lblCrossLeadTitle.Location = new System.Drawing.Point(0, 173);
			this.lblCrossLeadTitle.Name = "lblCrossLeadTitle";
			this.lblCrossLeadTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblCrossLeadTitle.Size = new System.Drawing.Size(624, 23);
			this.lblCrossLeadTitle.TabIndex = 2;
			this.lblCrossLeadTitle.Text = "Cross Lead Information";
			this.lblCrossLeadTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblProjectTitle
			// 
			this.lblProjectTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.lblProjectTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblProjectTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProjectTitle.ForeColor = System.Drawing.Color.White;
			this.lblProjectTitle.Location = new System.Drawing.Point(0, 0);
			this.lblProjectTitle.Name = "lblProjectTitle";
			this.lblProjectTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblProjectTitle.Size = new System.Drawing.Size(624, 23);
			this.lblProjectTitle.TabIndex = 0;
			this.lblProjectTitle.Text = "Project Information";
			this.lblProjectTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlCustomer
			// 
			this.pnlCustomer.AutoScroll = true;
			this.pnlCustomer.Controls.Add(this.customerControls);
			this.pnlCustomer.Controls.Add(this.lblCustomerTitle);
			this.pnlCustomer.Controls.Add(this.contactControls);
			this.pnlCustomer.Controls.Add(this.lblContactTitle);
			this.pnlCustomer.Location = new System.Drawing.Point(3, 53);
			this.pnlCustomer.Name = "pnlCustomer";
			this.pnlCustomer.Size = new System.Drawing.Size(310, 222);
			this.pnlCustomer.TabIndex = 1;
			// 
			// lblCustomerTitle
			// 
			this.lblCustomerTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.lblCustomerTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblCustomerTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCustomerTitle.ForeColor = System.Drawing.Color.White;
			this.lblCustomerTitle.Location = new System.Drawing.Point(0, 233);
			this.lblCustomerTitle.Name = "lblCustomerTitle";
			this.lblCustomerTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblCustomerTitle.Size = new System.Drawing.Size(293, 23);
			this.lblCustomerTitle.TabIndex = 2;
			this.lblCustomerTitle.Text = "Customer Information";
			this.lblCustomerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblContactTitle
			// 
			this.lblContactTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.lblContactTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblContactTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContactTitle.ForeColor = System.Drawing.Color.White;
			this.lblContactTitle.Location = new System.Drawing.Point(0, 0);
			this.lblContactTitle.Name = "lblContactTitle";
			this.lblContactTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblContactTitle.Size = new System.Drawing.Size(293, 23);
			this.lblContactTitle.TabIndex = 0;
			this.lblContactTitle.Text = "Contact Information";
			this.lblContactTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlTitleBar
			// 
			this.pnlTitleBar.BackColor = System.Drawing.Color.DarkOliveGreen;
			this.pnlTitleBar.Controls.Add(this.lblNotePosition);
			this.pnlTitleBar.Controls.Add(this.lblQuotePosition);
			this.pnlTitleBar.Controls.Add(this.lblProjectPosition);
			this.pnlTitleBar.Controls.Add(this.lblCustomerPosition);
			this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
			this.pnlTitleBar.Name = "pnlTitleBar";
			this.pnlTitleBar.Size = new System.Drawing.Size(624, 50);
			this.pnlTitleBar.TabIndex = 0;
			// 
			// lblNotePosition
			// 
			this.lblNotePosition.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNotePosition.ForeColor = System.Drawing.Color.Silver;
			this.lblNotePosition.Location = new System.Drawing.Point(468, 0);
			this.lblNotePosition.Name = "lblNotePosition";
			this.lblNotePosition.Size = new System.Drawing.Size(95, 50);
			this.lblNotePosition.TabIndex = 3;
			this.lblNotePosition.Text = "Note";
			this.lblNotePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblQuotePosition
			// 
			this.lblQuotePosition.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQuotePosition.ForeColor = System.Drawing.Color.Silver;
			this.lblQuotePosition.Location = new System.Drawing.Point(332, 0);
			this.lblQuotePosition.Name = "lblQuotePosition";
			this.lblQuotePosition.Size = new System.Drawing.Size(95, 50);
			this.lblQuotePosition.TabIndex = 2;
			this.lblQuotePosition.Text = "Quote";
			this.lblQuotePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblProjectPosition
			// 
			this.lblProjectPosition.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProjectPosition.ForeColor = System.Drawing.Color.Silver;
			this.lblProjectPosition.Location = new System.Drawing.Point(196, 0);
			this.lblProjectPosition.Name = "lblProjectPosition";
			this.lblProjectPosition.Size = new System.Drawing.Size(95, 50);
			this.lblProjectPosition.TabIndex = 1;
			this.lblProjectPosition.Text = "Project";
			this.lblProjectPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblCustomerPosition
			// 
			this.lblCustomerPosition.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCustomerPosition.ForeColor = System.Drawing.Color.White;
			this.lblCustomerPosition.Location = new System.Drawing.Point(60, 0);
			this.lblCustomerPosition.Name = "lblCustomerPosition";
			this.lblCustomerPosition.Size = new System.Drawing.Size(95, 50);
			this.lblCustomerPosition.TabIndex = 0;
			this.lblCustomerPosition.Text = "Customer/\r\nContact";
			this.lblCustomerPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// quoteControls
			// 
			this.quoteControls.AutoScroll = true;
			this.quoteControls.AutoScrollMinSize = new System.Drawing.Size(0, 210);
			this.quoteControls.BackColor = System.Drawing.Color.White;
			this.quoteControls.ChangeHistoryVisible = false;
			this.quoteControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.quoteControls.Location = new System.Drawing.Point(0, 90);
			this.quoteControls.MinimumSize = new System.Drawing.Size(0, 210);
			this.quoteControls.MyQuote = null;
			this.quoteControls.Name = "quoteControls";
			this.quoteControls.Size = new System.Drawing.Size(624, 372);
			this.quoteControls.TabIndex = 1;
			this.quoteControls.Title = "Search Quotes";
			this.quoteControls.TitleBarVisible = false;
			this.quoteControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.Controls_IsDirtyChanged);
			// 
			// noteControls
			// 
			this.noteControls.AutoScroll = true;
			this.noteControls.AutoScrollMinSize = new System.Drawing.Size(0, 210);
			this.noteControls.BackColor = System.Drawing.Color.White;
			this.noteControls.ChangeHistoryVisible = false;
			this.noteControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noteControls.Location = new System.Drawing.Point(0, 23);
			this.noteControls.MyNote = null;
			this.noteControls.Name = "noteControls";
			this.noteControls.Size = new System.Drawing.Size(302, 199);
			this.noteControls.TabIndex = 1;
			this.noteControls.Title = "Search Notes";
			this.noteControls.TitleBarVisible = false;
			this.noteControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.Controls_IsDirtyChanged);
			// 
			// crossLeadControls
			// 
			this.crossLeadControls.AutoScroll = true;
			this.crossLeadControls.BackColor = System.Drawing.Color.White;
			this.crossLeadControls.ChangeHistoryVisible = false;
			this.crossLeadControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crossLeadControls.Location = new System.Drawing.Point(0, 196);
			this.crossLeadControls.MinimumSize = new System.Drawing.Size(557, 0);
			this.crossLeadControls.MyCrossLead = null;
			this.crossLeadControls.MyProject = null;
			this.crossLeadControls.Name = "crossLeadControls";
			this.crossLeadControls.Size = new System.Drawing.Size(624, 266);
			this.crossLeadControls.TabIndex = 3;
			this.crossLeadControls.Title = "Cross Lead Notification";
			this.crossLeadControls.TitleBarVisible = false;
			this.crossLeadControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.Controls_IsDirtyChanged);
			// 
			// projectControls
			// 
			this.projectControls.AutoScroll = true;
			this.projectControls.BackColor = System.Drawing.Color.White;
			this.projectControls.ChangeHistoryVisible = false;
			this.projectControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.projectControls.Location = new System.Drawing.Point(0, 23);
			this.projectControls.MinimumSize = new System.Drawing.Size(0, 150);
			this.projectControls.MyProject = null;
			this.projectControls.Name = "projectControls";
			this.projectControls.Size = new System.Drawing.Size(624, 150);
			this.projectControls.TabIndex = 1;
			this.projectControls.Title = "Search Projects";
			this.projectControls.TitleBarVisible = false;
			this.projectControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.Controls_IsDirtyChanged);
			// 
			// customerControls
			// 
			this.customerControls.AutoScroll = true;
			this.customerControls.AutoScrollMinSize = new System.Drawing.Size(0, 350);
			this.customerControls.BackColor = System.Drawing.Color.White;
			this.customerControls.ChangeHistoryVisible = false;
			this.customerControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.customerControls.Location = new System.Drawing.Point(0, 256);
			this.customerControls.MyCustomer = null;
			this.customerControls.Name = "customerControls";
			this.customerControls.Size = new System.Drawing.Size(293, 0);
			this.customerControls.TabIndex = 3;
			this.customerControls.Title = "General Information";
			this.customerControls.TitleBarVisible = false;
			this.customerControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.Controls_IsDirtyChanged);
			// 
			// contactControls
			// 
			this.contactControls.AutoScroll = true;
			this.contactControls.AutoScrollMinSize = new System.Drawing.Size(0, 255);
			this.contactControls.BackColor = System.Drawing.Color.White;
			this.contactControls.ChangeHistoryVisible = false;
			this.contactControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.contactControls.Location = new System.Drawing.Point(0, 23);
			this.contactControls.MinimumSize = new System.Drawing.Size(0, 210);
			this.contactControls.MyContact = null;
			this.contactControls.Name = "contactControls";
			this.contactControls.Size = new System.Drawing.Size(293, 210);
			this.contactControls.TabIndex = 1;
			this.contactControls.Title = "Search Contacts";
			this.contactControls.TitleBarVisible = false;
			this.contactControls.IsDirtyChanged += new System.EventHandler<System.EventArgs>(this.Controls_IsDirtyChanged);
			// 
			// NewCustomerWizard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 562);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlFooter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewCustomerWizard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Customer Wizard";
			this.pnlFooter.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			this.pnlQuote.ResumeLayout(false);
			this.gbxStatus.ResumeLayout(false);
			this.pnlNote.ResumeLayout(false);
			this.pnlProject.ResumeLayout(false);
			this.pnlCustomer.ResumeLayout(false);
			this.pnlTitleBar.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnFinish;
		private System.Windows.Forms.Panel pnlTitleBar;
		private System.Windows.Forms.Label lblProjectPosition;
		private System.Windows.Forms.Label lblCustomerPosition;
		private System.Windows.Forms.Label lblQuotePosition;
		private System.Windows.Forms.Label lblNotePosition;
		private System.Windows.Forms.Panel pnlCustomer;
		private System.Windows.Forms.Label lblContactTitle;
		private System.Windows.Forms.Panel pnlQuote;
		private System.Windows.Forms.Label lblQuoteTitle;
		private System.Windows.Forms.Panel pnlProject;
		private System.Windows.Forms.Label lblProjectTitle;
		private System.Windows.Forms.Panel pnlNote;
		private System.Windows.Forms.Label lblNoteTitle;
		private rkcrm.Objects.Customer.CustomerBoundary customerControls;
		private System.Windows.Forms.Label lblCustomerTitle;
		private rkcrm.Objects.Contact.ContactBoundary contactControls;
		private rkcrm.Objects.Project.ProjectBoundary projectControls;
		private rkcrm.Objects.Note.NoteBoundary noteControls;
		private rkcrm.Objects.Quote.QuoteBoundary quoteControls;
		private System.Windows.Forms.Label lblCrossLeadTitle;
		private rkcrm.Objects.Cross_Lead.CrossLeadBoundary crossLeadControls;
		private System.Windows.Forms.GroupBox gbxStatus;
		private System.Windows.Forms.Button btnSold;
		private System.Windows.Forms.Button btnLost;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnOustanding;
	}
}