namespace rkcrm.Objects.Note
{
	partial class AddNote
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNote));
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnDone = new System.Windows.Forms.Button();
			this.pnlLine = new System.Windows.Forms.Panel();
			this.pnlLineLeft = new System.Windows.Forms.Panel();
			this.pnlLineRight = new System.Windows.Forms.Panel();
			this.noteControls = new rkcrm.Objects.Note.NoteBoundary();
			this.pnlFooter.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.pnlLine.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.pnlButtons);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 239);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(545, 50);
			this.pnlFooter.TabIndex = 0;
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnDone);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlButtons.Location = new System.Drawing.Point(375, 0);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(170, 50);
			this.pnlButtons.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(84, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnDone
			// 
			this.btnDone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDone.Location = new System.Drawing.Point(3, 10);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(75, 30);
			this.btnDone.TabIndex = 0;
			this.btnDone.Text = "Done";
			this.btnDone.UseVisualStyleBackColor = true;
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// pnlLine
			// 
			this.pnlLine.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlLine.Controls.Add(this.pnlLineLeft);
			this.pnlLine.Controls.Add(this.pnlLineRight);
			this.pnlLine.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlLine.Location = new System.Drawing.Point(0, 238);
			this.pnlLine.Name = "pnlLine";
			this.pnlLine.Size = new System.Drawing.Size(545, 1);
			this.pnlLine.TabIndex = 2;
			// 
			// pnlLineLeft
			// 
			this.pnlLineLeft.BackColor = System.Drawing.SystemColors.Control;
			this.pnlLineLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLineLeft.Location = new System.Drawing.Point(0, 0);
			this.pnlLineLeft.Name = "pnlLineLeft";
			this.pnlLineLeft.Size = new System.Drawing.Size(15, 1);
			this.pnlLineLeft.TabIndex = 3;
			// 
			// pnlLineRight
			// 
			this.pnlLineRight.BackColor = System.Drawing.SystemColors.Control;
			this.pnlLineRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlLineRight.Location = new System.Drawing.Point(530, 0);
			this.pnlLineRight.Name = "pnlLineRight";
			this.pnlLineRight.Size = new System.Drawing.Size(15, 1);
			this.pnlLineRight.TabIndex = 2;
			// 
			// noteControls
			// 
			this.noteControls.AutoScroll = true;
			this.noteControls.AutoScrollMinSize = new System.Drawing.Size(0, 210);
			this.noteControls.BackColor = System.Drawing.Color.White;
			this.noteControls.ChangeHistoryVisible = false;
			this.noteControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noteControls.Location = new System.Drawing.Point(0, 0);
			this.noteControls.MyNote = null;
			this.noteControls.Name = "noteControls";
			this.noteControls.Size = new System.Drawing.Size(545, 238);
			this.noteControls.TabIndex = 3;
			this.noteControls.Title = "Search Notes";
			this.noteControls.TitleBarVisible = true;
			// 
			// AddNote
			// 
			this.AcceptButton = this.btnDone;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(545, 289);
			this.Controls.Add(this.noteControls);
			this.Controls.Add(this.pnlLine);
			this.Controls.Add(this.pnlFooter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddNote";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Note";
			this.pnlFooter.ResumeLayout(false);
			this.pnlButtons.ResumeLayout(false);
			this.pnlLine.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Panel pnlLine;
		private System.Windows.Forms.Panel pnlLineLeft;
		private System.Windows.Forms.Panel pnlLineRight;
		private System.Windows.Forms.Panel pnlButtons;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnDone;
		internal NoteBoundary noteControls;
	}
}