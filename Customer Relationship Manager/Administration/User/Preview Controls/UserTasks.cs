using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.User.Preview_Controls
{
	class UserTasks : PreviewBase
	{

		#region Variables

		private System.Windows.Forms.GroupBox gbxAdministration;
		internal System.Windows.Forms.CheckBox chkDemonstration;
		internal System.Windows.Forms.CheckBox chkAssignCrossLeads;
		internal System.Windows.Forms.CheckBox chkManageLeadSources;
		internal System.Windows.Forms.CheckBox chkManageCrossLeads;
		internal System.Windows.Forms.CheckBox chkViewProperties;
		private System.Windows.Forms.GroupBox gbxNoteQuote;
		internal System.Windows.Forms.CheckBox chkRestoreNote;
		internal System.Windows.Forms.CheckBox chkDeleteNote;
		internal System.Windows.Forms.CheckBox chkSaveNote;
		internal System.Windows.Forms.CheckBox chkRestoreQuote;
		internal System.Windows.Forms.CheckBox chkDeleteQuote;
		internal System.Windows.Forms.CheckBox chkViewReminders;
		internal System.Windows.Forms.CheckBox chkViewOtherProjects;
		internal System.Windows.Forms.CheckBox chkSaveQuote;
		internal System.Windows.Forms.CheckBox chkFollowUp;
		private System.Windows.Forms.GroupBox gbxProject;
		internal System.Windows.Forms.CheckBox chkRestoreProject;
		internal System.Windows.Forms.CheckBox chkDeleteProject;
		internal System.Windows.Forms.CheckBox chkUnlink;
		internal System.Windows.Forms.CheckBox chkLink;
		internal System.Windows.Forms.CheckBox chkLoseProject;
		internal System.Windows.Forms.CheckBox chkSellProject;
		internal System.Windows.Forms.CheckBox chkCrossLead;
		internal System.Windows.Forms.CheckBox chkSaveProject;
		internal System.Windows.Forms.CheckBox chkReopenProject;
		private System.Windows.Forms.GroupBox gbxCustomerContact;
		internal System.Windows.Forms.CheckBox chkRestoreContact;
		internal System.Windows.Forms.CheckBox chkDeleteContact;
		internal System.Windows.Forms.CheckBox chkSaveContact;
		internal System.Windows.Forms.CheckBox chkViewInvoices;
		internal System.Windows.Forms.CheckBox chkActivityStatus;
		internal System.Windows.Forms.CheckBox chkCreditCard;
		internal System.Windows.Forms.CheckBox chkSaveCustomer;
		internal System.Windows.Forms.CheckBox chkTaxExempt;
		private System.Windows.Forms.GroupBox gbxNavigation;
		internal System.Windows.Forms.CheckBox chkAdministrationScreen;
		internal System.Windows.Forms.CheckBox chkContactScreen;
		internal System.Windows.Forms.CheckBox chkReportScreen;
		internal System.Windows.Forms.CheckBox chkQuoteScreen;
		internal System.Windows.Forms.CheckBox chkNoteScreen;
		internal System.Windows.Forms.CheckBox chkProjectScreen;
		internal System.Windows.Forms.CheckBox chkCustomerScreen;
		internal System.Windows.Forms.CheckBox chkQuoteSearch;
		internal System.Windows.Forms.CheckBox chkProjectSearch;

		#endregion	


		#region Methods

		private void InitializeComponent()
		{
			this.gbxAdministration = new System.Windows.Forms.GroupBox();
			this.chkDemonstration = new System.Windows.Forms.CheckBox();
			this.chkAssignCrossLeads = new System.Windows.Forms.CheckBox();
			this.chkManageLeadSources = new System.Windows.Forms.CheckBox();
			this.chkManageCrossLeads = new System.Windows.Forms.CheckBox();
			this.chkViewProperties = new System.Windows.Forms.CheckBox();
			this.gbxNoteQuote = new System.Windows.Forms.GroupBox();
			this.chkRestoreNote = new System.Windows.Forms.CheckBox();
			this.chkDeleteNote = new System.Windows.Forms.CheckBox();
			this.chkSaveNote = new System.Windows.Forms.CheckBox();
			this.chkRestoreQuote = new System.Windows.Forms.CheckBox();
			this.chkDeleteQuote = new System.Windows.Forms.CheckBox();
			this.chkViewReminders = new System.Windows.Forms.CheckBox();
			this.chkViewOtherProjects = new System.Windows.Forms.CheckBox();
			this.chkSaveQuote = new System.Windows.Forms.CheckBox();
			this.chkFollowUp = new System.Windows.Forms.CheckBox();
			this.gbxProject = new System.Windows.Forms.GroupBox();
			this.chkRestoreProject = new System.Windows.Forms.CheckBox();
			this.chkDeleteProject = new System.Windows.Forms.CheckBox();
			this.chkUnlink = new System.Windows.Forms.CheckBox();
			this.chkLink = new System.Windows.Forms.CheckBox();
			this.chkLoseProject = new System.Windows.Forms.CheckBox();
			this.chkSellProject = new System.Windows.Forms.CheckBox();
			this.chkCrossLead = new System.Windows.Forms.CheckBox();
			this.chkSaveProject = new System.Windows.Forms.CheckBox();
			this.chkReopenProject = new System.Windows.Forms.CheckBox();
			this.gbxCustomerContact = new System.Windows.Forms.GroupBox();
			this.chkRestoreContact = new System.Windows.Forms.CheckBox();
			this.chkDeleteContact = new System.Windows.Forms.CheckBox();
			this.chkSaveContact = new System.Windows.Forms.CheckBox();
			this.chkViewInvoices = new System.Windows.Forms.CheckBox();
			this.chkActivityStatus = new System.Windows.Forms.CheckBox();
			this.chkCreditCard = new System.Windows.Forms.CheckBox();
			this.chkSaveCustomer = new System.Windows.Forms.CheckBox();
			this.chkTaxExempt = new System.Windows.Forms.CheckBox();
			this.gbxNavigation = new System.Windows.Forms.GroupBox();
			this.chkAdministrationScreen = new System.Windows.Forms.CheckBox();
			this.chkContactScreen = new System.Windows.Forms.CheckBox();
			this.chkReportScreen = new System.Windows.Forms.CheckBox();
			this.chkQuoteScreen = new System.Windows.Forms.CheckBox();
			this.chkNoteScreen = new System.Windows.Forms.CheckBox();
			this.chkProjectScreen = new System.Windows.Forms.CheckBox();
			this.chkCustomerScreen = new System.Windows.Forms.CheckBox();
			this.chkQuoteSearch = new System.Windows.Forms.CheckBox();
			this.chkProjectSearch = new System.Windows.Forms.CheckBox();
			this.gbxAdministration.SuspendLayout();
			this.gbxNoteQuote.SuspendLayout();
			this.gbxProject.SuspendLayout();
			this.gbxCustomerContact.SuspendLayout();
			this.gbxNavigation.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxAdministration
			// 
			this.gbxAdministration.Controls.Add(this.chkDemonstration);
			this.gbxAdministration.Controls.Add(this.chkAssignCrossLeads);
			this.gbxAdministration.Controls.Add(this.chkManageLeadSources);
			this.gbxAdministration.Controls.Add(this.chkManageCrossLeads);
			this.gbxAdministration.Controls.Add(this.chkViewProperties);
			this.gbxAdministration.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxAdministration.Location = new System.Drawing.Point(0, 422);
			this.gbxAdministration.Name = "gbxAdministration";
			this.gbxAdministration.Size = new System.Drawing.Size(605, 76);
			this.gbxAdministration.TabIndex = 4;
			this.gbxAdministration.TabStop = false;
			this.gbxAdministration.Text = "Administration";
			// 
			// chkDemonstration
			// 
			this.chkDemonstration.AutoSize = true;
			this.chkDemonstration.Location = new System.Drawing.Point(344, 25);
			this.chkDemonstration.Name = "chkDemonstration";
			this.chkDemonstration.Size = new System.Drawing.Size(120, 17);
			this.chkDemonstration.TabIndex = 4;
			this.chkDemonstration.Text = "Demonstration Form";
			this.chkDemonstration.UseVisualStyleBackColor = true;
			// 
			// chkAssignCrossLeads
			// 
			this.chkAssignCrossLeads.AutoSize = true;
			this.chkAssignCrossLeads.Location = new System.Drawing.Point(15, 48);
			this.chkAssignCrossLeads.Name = "chkAssignCrossLeads";
			this.chkAssignCrossLeads.Size = new System.Drawing.Size(118, 17);
			this.chkAssignCrossLeads.TabIndex = 1;
			this.chkAssignCrossLeads.Text = "Assign Cross Leads";
			this.chkAssignCrossLeads.UseVisualStyleBackColor = true;
			// 
			// chkManageLeadSources
			// 
			this.chkManageLeadSources.AutoSize = true;
			this.chkManageLeadSources.Location = new System.Drawing.Point(175, 48);
			this.chkManageLeadSources.Name = "chkManageLeadSources";
			this.chkManageLeadSources.Size = new System.Drawing.Size(134, 17);
			this.chkManageLeadSources.TabIndex = 3;
			this.chkManageLeadSources.Text = "Manage Lead Sources";
			this.chkManageLeadSources.UseVisualStyleBackColor = true;
			// 
			// chkManageCrossLeads
			// 
			this.chkManageCrossLeads.AutoSize = true;
			this.chkManageCrossLeads.Location = new System.Drawing.Point(175, 25);
			this.chkManageCrossLeads.Name = "chkManageCrossLeads";
			this.chkManageCrossLeads.Size = new System.Drawing.Size(126, 17);
			this.chkManageCrossLeads.TabIndex = 2;
			this.chkManageCrossLeads.Text = "Manage Cross Leads";
			this.chkManageCrossLeads.UseVisualStyleBackColor = true;
			// 
			// chkViewProperties
			// 
			this.chkViewProperties.AutoSize = true;
			this.chkViewProperties.Location = new System.Drawing.Point(15, 25);
			this.chkViewProperties.Name = "chkViewProperties";
			this.chkViewProperties.Size = new System.Drawing.Size(99, 17);
			this.chkViewProperties.TabIndex = 0;
			this.chkViewProperties.Text = "View Properties";
			this.chkViewProperties.UseVisualStyleBackColor = true;
			// 
			// gbxNoteQuote
			// 
			this.gbxNoteQuote.Controls.Add(this.chkRestoreNote);
			this.gbxNoteQuote.Controls.Add(this.chkDeleteNote);
			this.gbxNoteQuote.Controls.Add(this.chkSaveNote);
			this.gbxNoteQuote.Controls.Add(this.chkRestoreQuote);
			this.gbxNoteQuote.Controls.Add(this.chkDeleteQuote);
			this.gbxNoteQuote.Controls.Add(this.chkViewReminders);
			this.gbxNoteQuote.Controls.Add(this.chkViewOtherProjects);
			this.gbxNoteQuote.Controls.Add(this.chkSaveQuote);
			this.gbxNoteQuote.Controls.Add(this.chkFollowUp);
			this.gbxNoteQuote.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxNoteQuote.Location = new System.Drawing.Point(0, 322);
			this.gbxNoteQuote.Name = "gbxNoteQuote";
			this.gbxNoteQuote.Size = new System.Drawing.Size(605, 100);
			this.gbxNoteQuote.TabIndex = 3;
			this.gbxNoteQuote.TabStop = false;
			this.gbxNoteQuote.Text = "Note && Quote";
			// 
			// chkRestoreNote
			// 
			this.chkRestoreNote.AutoSize = true;
			this.chkRestoreNote.Location = new System.Drawing.Point(133, 71);
			this.chkRestoreNote.Name = "chkRestoreNote";
			this.chkRestoreNote.Size = new System.Drawing.Size(89, 17);
			this.chkRestoreNote.TabIndex = 5;
			this.chkRestoreNote.Text = "Restore Note";
			this.chkRestoreNote.UseVisualStyleBackColor = true;
			// 
			// chkDeleteNote
			// 
			this.chkDeleteNote.AutoSize = true;
			this.chkDeleteNote.Location = new System.Drawing.Point(133, 48);
			this.chkDeleteNote.Name = "chkDeleteNote";
			this.chkDeleteNote.Size = new System.Drawing.Size(83, 17);
			this.chkDeleteNote.TabIndex = 4;
			this.chkDeleteNote.Text = "Delete Note";
			this.chkDeleteNote.UseVisualStyleBackColor = true;
			// 
			// chkSaveNote
			// 
			this.chkSaveNote.AutoSize = true;
			this.chkSaveNote.Location = new System.Drawing.Point(133, 25);
			this.chkSaveNote.Name = "chkSaveNote";
			this.chkSaveNote.Size = new System.Drawing.Size(77, 17);
			this.chkSaveNote.TabIndex = 3;
			this.chkSaveNote.Text = "Save Note";
			this.chkSaveNote.UseVisualStyleBackColor = true;
			// 
			// chkRestoreQuote
			// 
			this.chkRestoreQuote.AutoSize = true;
			this.chkRestoreQuote.Location = new System.Drawing.Point(15, 71);
			this.chkRestoreQuote.Name = "chkRestoreQuote";
			this.chkRestoreQuote.Size = new System.Drawing.Size(95, 17);
			this.chkRestoreQuote.TabIndex = 2;
			this.chkRestoreQuote.Text = "Restore Quote";
			this.chkRestoreQuote.UseVisualStyleBackColor = true;
			// 
			// chkDeleteQuote
			// 
			this.chkDeleteQuote.AutoSize = true;
			this.chkDeleteQuote.Location = new System.Drawing.Point(15, 48);
			this.chkDeleteQuote.Name = "chkDeleteQuote";
			this.chkDeleteQuote.Size = new System.Drawing.Size(89, 17);
			this.chkDeleteQuote.TabIndex = 1;
			this.chkDeleteQuote.Text = "Delete Quote";
			this.chkDeleteQuote.UseVisualStyleBackColor = true;
			// 
			// chkViewReminders
			// 
			this.chkViewReminders.AutoSize = true;
			this.chkViewReminders.Location = new System.Drawing.Point(260, 71);
			this.chkViewReminders.Name = "chkViewReminders";
			this.chkViewReminders.Size = new System.Drawing.Size(102, 17);
			this.chkViewReminders.TabIndex = 8;
			this.chkViewReminders.Text = "View Reminders";
			this.chkViewReminders.UseVisualStyleBackColor = true;
			// 
			// chkViewOtherProjects
			// 
			this.chkViewOtherProjects.AutoSize = true;
			this.chkViewOtherProjects.Location = new System.Drawing.Point(260, 48);
			this.chkViewOtherProjects.Name = "chkViewOtherProjects";
			this.chkViewOtherProjects.Size = new System.Drawing.Size(119, 17);
			this.chkViewOtherProjects.TabIndex = 7;
			this.chkViewOtherProjects.Text = "View Other Projects";
			this.chkViewOtherProjects.UseVisualStyleBackColor = true;
			// 
			// chkSaveQuote
			// 
			this.chkSaveQuote.AutoSize = true;
			this.chkSaveQuote.Location = new System.Drawing.Point(15, 25);
			this.chkSaveQuote.Name = "chkSaveQuote";
			this.chkSaveQuote.Size = new System.Drawing.Size(83, 17);
			this.chkSaveQuote.TabIndex = 0;
			this.chkSaveQuote.Text = "Save Quote";
			this.chkSaveQuote.UseVisualStyleBackColor = true;
			// 
			// chkFollowUp
			// 
			this.chkFollowUp.AutoSize = true;
			this.chkFollowUp.Location = new System.Drawing.Point(260, 25);
			this.chkFollowUp.Name = "chkFollowUp";
			this.chkFollowUp.Size = new System.Drawing.Size(73, 17);
			this.chkFollowUp.TabIndex = 6;
			this.chkFollowUp.Text = "Follow Up";
			this.chkFollowUp.UseVisualStyleBackColor = true;
			// 
			// gbxProject
			// 
			this.gbxProject.Controls.Add(this.chkRestoreProject);
			this.gbxProject.Controls.Add(this.chkDeleteProject);
			this.gbxProject.Controls.Add(this.chkUnlink);
			this.gbxProject.Controls.Add(this.chkLink);
			this.gbxProject.Controls.Add(this.chkLoseProject);
			this.gbxProject.Controls.Add(this.chkSellProject);
			this.gbxProject.Controls.Add(this.chkCrossLead);
			this.gbxProject.Controls.Add(this.chkSaveProject);
			this.gbxProject.Controls.Add(this.chkReopenProject);
			this.gbxProject.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxProject.Location = new System.Drawing.Point(0, 222);
			this.gbxProject.Name = "gbxProject";
			this.gbxProject.Size = new System.Drawing.Size(605, 100);
			this.gbxProject.TabIndex = 2;
			this.gbxProject.TabStop = false;
			this.gbxProject.Text = "Project";
			// 
			// chkRestoreProject
			// 
			this.chkRestoreProject.AutoSize = true;
			this.chkRestoreProject.Location = new System.Drawing.Point(15, 71);
			this.chkRestoreProject.Name = "chkRestoreProject";
			this.chkRestoreProject.Size = new System.Drawing.Size(99, 17);
			this.chkRestoreProject.TabIndex = 2;
			this.chkRestoreProject.Text = "Restore Project";
			this.chkRestoreProject.UseVisualStyleBackColor = true;
			// 
			// chkDeleteProject
			// 
			this.chkDeleteProject.AutoSize = true;
			this.chkDeleteProject.Location = new System.Drawing.Point(15, 48);
			this.chkDeleteProject.Name = "chkDeleteProject";
			this.chkDeleteProject.Size = new System.Drawing.Size(93, 17);
			this.chkDeleteProject.TabIndex = 1;
			this.chkDeleteProject.Text = "Delete Project";
			this.chkDeleteProject.UseVisualStyleBackColor = true;
			// 
			// chkUnlink
			// 
			this.chkUnlink.AutoSize = true;
			this.chkUnlink.Location = new System.Drawing.Point(260, 71);
			this.chkUnlink.Name = "chkUnlink";
			this.chkUnlink.Size = new System.Drawing.Size(56, 17);
			this.chkUnlink.TabIndex = 8;
			this.chkUnlink.Text = "Unlink";
			this.chkUnlink.UseVisualStyleBackColor = true;
			// 
			// chkLink
			// 
			this.chkLink.AutoSize = true;
			this.chkLink.Location = new System.Drawing.Point(260, 48);
			this.chkLink.Name = "chkLink";
			this.chkLink.Size = new System.Drawing.Size(46, 17);
			this.chkLink.TabIndex = 7;
			this.chkLink.Text = "Link";
			this.chkLink.UseVisualStyleBackColor = true;
			// 
			// chkLoseProject
			// 
			this.chkLoseProject.AutoSize = true;
			this.chkLoseProject.Location = new System.Drawing.Point(133, 71);
			this.chkLoseProject.Name = "chkLoseProject";
			this.chkLoseProject.Size = new System.Drawing.Size(85, 17);
			this.chkLoseProject.TabIndex = 5;
			this.chkLoseProject.Text = "Lose Project";
			this.chkLoseProject.UseVisualStyleBackColor = true;
			// 
			// chkSellProject
			// 
			this.chkSellProject.AutoSize = true;
			this.chkSellProject.Location = new System.Drawing.Point(133, 48);
			this.chkSellProject.Name = "chkSellProject";
			this.chkSellProject.Size = new System.Drawing.Size(79, 17);
			this.chkSellProject.TabIndex = 4;
			this.chkSellProject.Text = "Sell Project";
			this.chkSellProject.UseVisualStyleBackColor = true;
			// 
			// chkCrossLead
			// 
			this.chkCrossLead.AutoSize = true;
			this.chkCrossLead.Location = new System.Drawing.Point(260, 25);
			this.chkCrossLead.Name = "chkCrossLead";
			this.chkCrossLead.Size = new System.Drawing.Size(79, 17);
			this.chkCrossLead.TabIndex = 6;
			this.chkCrossLead.Text = "Cross Lead";
			this.chkCrossLead.UseVisualStyleBackColor = true;
			// 
			// chkSaveProject
			// 
			this.chkSaveProject.AutoSize = true;
			this.chkSaveProject.Location = new System.Drawing.Point(15, 25);
			this.chkSaveProject.Name = "chkSaveProject";
			this.chkSaveProject.Size = new System.Drawing.Size(87, 17);
			this.chkSaveProject.TabIndex = 0;
			this.chkSaveProject.Text = "Save Project";
			this.chkSaveProject.UseVisualStyleBackColor = true;
			// 
			// chkReopenProject
			// 
			this.chkReopenProject.AutoSize = true;
			this.chkReopenProject.Location = new System.Drawing.Point(133, 25);
			this.chkReopenProject.Name = "chkReopenProject";
			this.chkReopenProject.Size = new System.Drawing.Size(100, 17);
			this.chkReopenProject.TabIndex = 3;
			this.chkReopenProject.Text = "Reopen Project";
			this.chkReopenProject.UseVisualStyleBackColor = true;
			// 
			// gbxCustomerContact
			// 
			this.gbxCustomerContact.Controls.Add(this.chkRestoreContact);
			this.gbxCustomerContact.Controls.Add(this.chkDeleteContact);
			this.gbxCustomerContact.Controls.Add(this.chkSaveContact);
			this.gbxCustomerContact.Controls.Add(this.chkViewInvoices);
			this.gbxCustomerContact.Controls.Add(this.chkActivityStatus);
			this.gbxCustomerContact.Controls.Add(this.chkCreditCard);
			this.gbxCustomerContact.Controls.Add(this.chkSaveCustomer);
			this.gbxCustomerContact.Controls.Add(this.chkTaxExempt);
			this.gbxCustomerContact.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxCustomerContact.Location = new System.Drawing.Point(0, 124);
			this.gbxCustomerContact.Name = "gbxCustomerContact";
			this.gbxCustomerContact.Size = new System.Drawing.Size(605, 98);
			this.gbxCustomerContact.TabIndex = 1;
			this.gbxCustomerContact.TabStop = false;
			this.gbxCustomerContact.Text = "Customer && Contact";
			// 
			// chkRestoreContact
			// 
			this.chkRestoreContact.AutoSize = true;
			this.chkRestoreContact.Location = new System.Drawing.Point(344, 71);
			this.chkRestoreContact.Name = "chkRestoreContact";
			this.chkRestoreContact.Size = new System.Drawing.Size(103, 17);
			this.chkRestoreContact.TabIndex = 7;
			this.chkRestoreContact.Text = "Restore Contact";
			this.chkRestoreContact.UseVisualStyleBackColor = true;
			// 
			// chkDeleteContact
			// 
			this.chkDeleteContact.AutoSize = true;
			this.chkDeleteContact.Location = new System.Drawing.Point(344, 48);
			this.chkDeleteContact.Name = "chkDeleteContact";
			this.chkDeleteContact.Size = new System.Drawing.Size(97, 17);
			this.chkDeleteContact.TabIndex = 6;
			this.chkDeleteContact.Text = "Delete Contact";
			this.chkDeleteContact.UseVisualStyleBackColor = true;
			// 
			// chkSaveContact
			// 
			this.chkSaveContact.AutoSize = true;
			this.chkSaveContact.Location = new System.Drawing.Point(344, 25);
			this.chkSaveContact.Name = "chkSaveContact";
			this.chkSaveContact.Size = new System.Drawing.Size(91, 17);
			this.chkSaveContact.TabIndex = 5;
			this.chkSaveContact.Text = "Save Contact";
			this.chkSaveContact.UseVisualStyleBackColor = true;
			// 
			// chkViewInvoices
			// 
			this.chkViewInvoices.AutoSize = true;
			this.chkViewInvoices.Location = new System.Drawing.Point(15, 71);
			this.chkViewInvoices.Name = "chkViewInvoices";
			this.chkViewInvoices.Size = new System.Drawing.Size(92, 17);
			this.chkViewInvoices.TabIndex = 2;
			this.chkViewInvoices.Text = "View Invoices";
			this.chkViewInvoices.UseVisualStyleBackColor = true;
			// 
			// chkActivityStatus
			// 
			this.chkActivityStatus.AutoSize = true;
			this.chkActivityStatus.Location = new System.Drawing.Point(15, 48);
			this.chkActivityStatus.Name = "chkActivityStatus";
			this.chkActivityStatus.Size = new System.Drawing.Size(114, 17);
			this.chkActivityStatus.TabIndex = 1;
			this.chkActivityStatus.Text = "Edit Activity Status";
			this.chkActivityStatus.UseVisualStyleBackColor = true;
			// 
			// chkCreditCard
			// 
			this.chkCreditCard.AutoSize = true;
			this.chkCreditCard.Location = new System.Drawing.Point(175, 48);
			this.chkCreditCard.Name = "chkCreditCard";
			this.chkCreditCard.Size = new System.Drawing.Size(148, 17);
			this.chkCreditCard.TabIndex = 4;
			this.chkCreditCard.Text = "Edit Credit Card Expiration";
			this.chkCreditCard.UseVisualStyleBackColor = true;
			// 
			// chkSaveCustomer
			// 
			this.chkSaveCustomer.AutoSize = true;
			this.chkSaveCustomer.Location = new System.Drawing.Point(15, 25);
			this.chkSaveCustomer.Name = "chkSaveCustomer";
			this.chkSaveCustomer.Size = new System.Drawing.Size(98, 17);
			this.chkSaveCustomer.TabIndex = 0;
			this.chkSaveCustomer.Text = "Save Customer";
			this.chkSaveCustomer.UseVisualStyleBackColor = true;
			// 
			// chkTaxExempt
			// 
			this.chkTaxExempt.AutoSize = true;
			this.chkTaxExempt.Location = new System.Drawing.Point(175, 25);
			this.chkTaxExempt.Name = "chkTaxExempt";
			this.chkTaxExempt.Size = new System.Drawing.Size(152, 17);
			this.chkTaxExempt.TabIndex = 3;
			this.chkTaxExempt.Text = "Edit Tax Exempt Expiration";
			this.chkTaxExempt.UseVisualStyleBackColor = true;
			// 
			// gbxNavigation
			// 
			this.gbxNavigation.Controls.Add(this.chkAdministrationScreen);
			this.gbxNavigation.Controls.Add(this.chkContactScreen);
			this.gbxNavigation.Controls.Add(this.chkReportScreen);
			this.gbxNavigation.Controls.Add(this.chkQuoteScreen);
			this.gbxNavigation.Controls.Add(this.chkNoteScreen);
			this.gbxNavigation.Controls.Add(this.chkProjectScreen);
			this.gbxNavigation.Controls.Add(this.chkCustomerScreen);
			this.gbxNavigation.Controls.Add(this.chkQuoteSearch);
			this.gbxNavigation.Controls.Add(this.chkProjectSearch);
			this.gbxNavigation.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbxNavigation.Location = new System.Drawing.Point(0, 24);
			this.gbxNavigation.Name = "gbxNavigation";
			this.gbxNavigation.Size = new System.Drawing.Size(605, 100);
			this.gbxNavigation.TabIndex = 0;
			this.gbxNavigation.TabStop = false;
			this.gbxNavigation.Text = "Navigation";
			// 
			// chkAdministrationScreen
			// 
			this.chkAdministrationScreen.AutoSize = true;
			this.chkAdministrationScreen.Location = new System.Drawing.Point(302, 69);
			this.chkAdministrationScreen.Name = "chkAdministrationScreen";
			this.chkAdministrationScreen.Size = new System.Drawing.Size(128, 17);
			this.chkAdministrationScreen.TabIndex = 8;
			this.chkAdministrationScreen.Text = "Administration Screen";
			this.chkAdministrationScreen.UseVisualStyleBackColor = true;
			// 
			// chkContactScreen
			// 
			this.chkContactScreen.AutoSize = true;
			this.chkContactScreen.Location = new System.Drawing.Point(175, 23);
			this.chkContactScreen.Name = "chkContactScreen";
			this.chkContactScreen.Size = new System.Drawing.Size(100, 17);
			this.chkContactScreen.TabIndex = 3;
			this.chkContactScreen.Text = "Contact Screen";
			this.chkContactScreen.UseVisualStyleBackColor = true;
			// 
			// chkReportScreen
			// 
			this.chkReportScreen.AutoSize = true;
			this.chkReportScreen.Location = new System.Drawing.Point(302, 46);
			this.chkReportScreen.Name = "chkReportScreen";
			this.chkReportScreen.Size = new System.Drawing.Size(95, 17);
			this.chkReportScreen.TabIndex = 7;
			this.chkReportScreen.Text = "Report Screen";
			this.chkReportScreen.UseVisualStyleBackColor = true;
			// 
			// chkQuoteScreen
			// 
			this.chkQuoteScreen.AutoSize = true;
			this.chkQuoteScreen.Location = new System.Drawing.Point(302, 23);
			this.chkQuoteScreen.Name = "chkQuoteScreen";
			this.chkQuoteScreen.Size = new System.Drawing.Size(92, 17);
			this.chkQuoteScreen.TabIndex = 6;
			this.chkQuoteScreen.Text = "Quote Screen";
			this.chkQuoteScreen.UseVisualStyleBackColor = true;
			// 
			// chkNoteScreen
			// 
			this.chkNoteScreen.AutoSize = true;
			this.chkNoteScreen.Location = new System.Drawing.Point(175, 69);
			this.chkNoteScreen.Name = "chkNoteScreen";
			this.chkNoteScreen.Size = new System.Drawing.Size(86, 17);
			this.chkNoteScreen.TabIndex = 5;
			this.chkNoteScreen.Text = "Note Screen";
			this.chkNoteScreen.UseVisualStyleBackColor = true;
			// 
			// chkProjectScreen
			// 
			this.chkProjectScreen.AutoSize = true;
			this.chkProjectScreen.Location = new System.Drawing.Point(175, 46);
			this.chkProjectScreen.Name = "chkProjectScreen";
			this.chkProjectScreen.Size = new System.Drawing.Size(96, 17);
			this.chkProjectScreen.TabIndex = 4;
			this.chkProjectScreen.Text = "Project Screen";
			this.chkProjectScreen.UseVisualStyleBackColor = true;
			// 
			// chkCustomerScreen
			// 
			this.chkCustomerScreen.AutoSize = true;
			this.chkCustomerScreen.Location = new System.Drawing.Point(15, 69);
			this.chkCustomerScreen.Name = "chkCustomerScreen";
			this.chkCustomerScreen.Size = new System.Drawing.Size(107, 17);
			this.chkCustomerScreen.TabIndex = 2;
			this.chkCustomerScreen.Text = "Customer Screen";
			this.chkCustomerScreen.UseVisualStyleBackColor = true;
			// 
			// chkQuoteSearch
			// 
			this.chkQuoteSearch.AutoSize = true;
			this.chkQuoteSearch.Location = new System.Drawing.Point(15, 46);
			this.chkQuoteSearch.Name = "chkQuoteSearch";
			this.chkQuoteSearch.Size = new System.Drawing.Size(129, 17);
			this.chkQuoteSearch.TabIndex = 1;
			this.chkQuoteSearch.Text = "Quote Search Screen";
			this.chkQuoteSearch.UseVisualStyleBackColor = true;
			// 
			// chkProjectSearch
			// 
			this.chkProjectSearch.AutoSize = true;
			this.chkProjectSearch.Location = new System.Drawing.Point(15, 23);
			this.chkProjectSearch.Name = "chkProjectSearch";
			this.chkProjectSearch.Size = new System.Drawing.Size(133, 17);
			this.chkProjectSearch.TabIndex = 0;
			this.chkProjectSearch.Text = "Project Search Screen";
			this.chkProjectSearch.UseVisualStyleBackColor = true;
			// 
			// UserTasks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.gbxAdministration);
			this.Controls.Add(this.gbxNoteQuote);
			this.Controls.Add(this.gbxProject);
			this.Controls.Add(this.gbxCustomerContact);
			this.Controls.Add(this.gbxNavigation);
			this.Name = "UserTasks";
			this.Size = new System.Drawing.Size(605, 503);
			this.Title = "User Security Access";
			this.Controls.SetChildIndex(this.gbxNavigation, 0);
			this.Controls.SetChildIndex(this.gbxCustomerContact, 0);
			this.Controls.SetChildIndex(this.gbxProject, 0);
			this.Controls.SetChildIndex(this.gbxNoteQuote, 0);
			this.Controls.SetChildIndex(this.gbxAdministration, 0);
			this.gbxAdministration.ResumeLayout(false);
			this.gbxAdministration.PerformLayout();
			this.gbxNoteQuote.ResumeLayout(false);
			this.gbxNoteQuote.PerformLayout();
			this.gbxProject.ResumeLayout(false);
			this.gbxProject.PerformLayout();
			this.gbxCustomerContact.ResumeLayout(false);
			this.gbxCustomerContact.PerformLayout();
			this.gbxNavigation.ResumeLayout(false);
			this.gbxNavigation.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion


		#region Contructor

		public UserTasks()
			: base()
		{
			InitializeComponent();
		}

		#endregion


	}
}
