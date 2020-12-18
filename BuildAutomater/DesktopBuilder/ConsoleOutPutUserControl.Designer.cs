namespace DesktopBuilder
{
	partial class ConsoleOutputUserControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel = new System.Windows.Forms.Panel();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.processOutput_textBox = new System.Windows.Forms.TextBox();
			this.viewBuildFolder_button = new System.Windows.Forms.Button();
			this.OpenLog_button = new System.Windows.Forms.Button();
			this.panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.Controls.Add(this.splitContainer);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.MinimumSize = new System.Drawing.Size(200, 200);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(885, 579);
			this.panel.TabIndex = 0;
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.processOutput_textBox);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.viewBuildFolder_button);
			this.splitContainer.Panel2.Controls.Add(this.OpenLog_button);
			this.splitContainer.Size = new System.Drawing.Size(885, 579);
			this.splitContainer.SplitterDistance = 548;
			this.splitContainer.TabIndex = 7;
			// 
			// processOutput_textBox
			// 
			this.processOutput_textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.processOutput_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.processOutput_textBox.Location = new System.Drawing.Point(0, 0);
			this.processOutput_textBox.MaxLength = 327670000;
			this.processOutput_textBox.MinimumSize = new System.Drawing.Size(100, 100);
			this.processOutput_textBox.Multiline = true;
			this.processOutput_textBox.Name = "processOutput_textBox";
			this.processOutput_textBox.ReadOnly = true;
			this.processOutput_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.processOutput_textBox.ShortcutsEnabled = false;
			this.processOutput_textBox.Size = new System.Drawing.Size(885, 548);
			this.processOutput_textBox.TabIndex = 5;
			this.processOutput_textBox.TabStop = false;
			this.processOutput_textBox.WordWrap = false;
			// 
			// viewBuildFolder_button
			// 
			this.viewBuildFolder_button.Dock = System.Windows.Forms.DockStyle.Left;
			this.viewBuildFolder_button.Location = new System.Drawing.Point(0, 0);
			this.viewBuildFolder_button.Name = "viewBuildFolder_button";
			this.viewBuildFolder_button.Size = new System.Drawing.Size(160, 27);
			this.viewBuildFolder_button.TabIndex = 7;
			this.viewBuildFolder_button.Text = "Open Build Folder";
			this.viewBuildFolder_button.UseVisualStyleBackColor = true;
			this.viewBuildFolder_button.Visible = false;
			this.viewBuildFolder_button.Click += new System.EventHandler(this.ViewBuildFolder_button_Click);
			// 
			// OpenLog_button
			// 
			this.OpenLog_button.Dock = System.Windows.Forms.DockStyle.Right;
			this.OpenLog_button.Location = new System.Drawing.Point(700, 0);
			this.OpenLog_button.Name = "OpenLog_button";
			this.OpenLog_button.Size = new System.Drawing.Size(185, 27);
			this.OpenLog_button.TabIndex = 6;
			this.OpenLog_button.Text = "View Log";
			this.OpenLog_button.UseVisualStyleBackColor = true;
			this.OpenLog_button.Visible = false;
			this.OpenLog_button.Click += new System.EventHandler(this.OpenLog_button_Click);
			// 
			// ConsoleOutputUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel);
			this.Name = "ConsoleOutputUserControl";
			this.Size = new System.Drawing.Size(885, 579);
			this.panel.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.TextBox processOutput_textBox;
		public System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button OpenLog_button;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Button viewBuildFolder_button;
	}
}
