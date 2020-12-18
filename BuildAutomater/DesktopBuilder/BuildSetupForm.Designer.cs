namespace DesktopBuilder
{
	partial class BuildSetupForm
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
			this.startBuild_button = new System.Windows.Forms.Button();
			this.BuildType_groupBox = new System.Windows.Forms.GroupBox();
			this.shipBuild_radioButton = new System.Windows.Forms.RadioButton();
			this.devBuild_radioButton = new System.Windows.Forms.RadioButton();
			this.platform_groupBox = new System.Windows.Forms.GroupBox();
			this.platform_checkedListBox = new System.Windows.Forms.CheckedListBox();
			this.warning_label = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.options_groupBox = new System.Windows.Forms.GroupBox();
			this.cookOnly_checkBox = new System.Windows.Forms.CheckBox();
			this.stopBuild_button = new System.Windows.Forms.Button();
			this.selectFolder_button = new System.Windows.Forms.Button();
			this.rootFolder_textBox = new System.Windows.Forms.TextBox();
			this.consoleOutput_tabControl = new System.Windows.Forms.TabControl();
			this.BuildType_groupBox.SuspendLayout();
			this.platform_groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.options_groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// startBuild_button
			// 
			this.startBuild_button.Location = new System.Drawing.Point(10, 210);
			this.startBuild_button.Name = "startBuild_button";
			this.startBuild_button.Size = new System.Drawing.Size(75, 23);
			this.startBuild_button.TabIndex = 0;
			this.startBuild_button.Text = "Start Builds";
			this.startBuild_button.UseVisualStyleBackColor = true;
			this.startBuild_button.Click += new System.EventHandler(this.StartBuild_button_Click);
			// 
			// BuildType_groupBox
			// 
			this.BuildType_groupBox.Controls.Add(this.shipBuild_radioButton);
			this.BuildType_groupBox.Controls.Add(this.devBuild_radioButton);
			this.BuildType_groupBox.Location = new System.Drawing.Point(3, 56);
			this.BuildType_groupBox.Name = "BuildType_groupBox";
			this.BuildType_groupBox.Size = new System.Drawing.Size(139, 73);
			this.BuildType_groupBox.TabIndex = 1;
			this.BuildType_groupBox.TabStop = false;
			this.BuildType_groupBox.Text = "Build Type";
			// 
			// shipBuild_radioButton
			// 
			this.shipBuild_radioButton.AutoSize = true;
			this.shipBuild_radioButton.Location = new System.Drawing.Point(7, 44);
			this.shipBuild_radioButton.Name = "shipBuild_radioButton";
			this.shipBuild_radioButton.Size = new System.Drawing.Size(92, 17);
			this.shipBuild_radioButton.TabIndex = 1;
			this.shipBuild_radioButton.TabStop = true;
			this.shipBuild_radioButton.Text = "Shipping Build";
			this.shipBuild_radioButton.UseVisualStyleBackColor = true;
			// 
			// devBuild_radioButton
			// 
			this.devBuild_radioButton.AutoSize = true;
			this.devBuild_radioButton.Location = new System.Drawing.Point(7, 20);
			this.devBuild_radioButton.Name = "devBuild_radioButton";
			this.devBuild_radioButton.Size = new System.Drawing.Size(114, 17);
			this.devBuild_radioButton.TabIndex = 0;
			this.devBuild_radioButton.TabStop = true;
			this.devBuild_radioButton.Text = "Development Build";
			this.devBuild_radioButton.UseVisualStyleBackColor = true;
			// 
			// platform_groupBox
			// 
			this.platform_groupBox.Controls.Add(this.platform_checkedListBox);
			this.platform_groupBox.Location = new System.Drawing.Point(3, 135);
			this.platform_groupBox.Name = "platform_groupBox";
			this.platform_groupBox.Size = new System.Drawing.Size(200, 73);
			this.platform_groupBox.TabIndex = 2;
			this.platform_groupBox.TabStop = false;
			this.platform_groupBox.Text = "Platform";
			// 
			// platform_checkedListBox
			// 
			this.platform_checkedListBox.CheckOnClick = true;
			this.platform_checkedListBox.FormattingEnabled = true;
			this.platform_checkedListBox.Items.AddRange(new object[] {
            "Xbox",
            "Switch",
            "PS4"});
			this.platform_checkedListBox.Location = new System.Drawing.Point(7, 20);
			this.platform_checkedListBox.Name = "platform_checkedListBox";
			this.platform_checkedListBox.Size = new System.Drawing.Size(187, 49);
			this.platform_checkedListBox.TabIndex = 0;
			// 
			// warning_label
			// 
			this.warning_label.AutoEllipsis = true;
			this.warning_label.AutoSize = true;
			this.warning_label.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.warning_label.Location = new System.Drawing.Point(0, 463);
			this.warning_label.MaximumSize = new System.Drawing.Size(400, 0);
			this.warning_label.Name = "warning_label";
			this.warning_label.Size = new System.Drawing.Size(88, 13);
			this.warning_label.TabIndex = 3;
			this.warning_label.Text = "Builds not started";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.options_groupBox);
			this.splitContainer1.Panel1.Controls.Add(this.stopBuild_button);
			this.splitContainer1.Panel1.Controls.Add(this.selectFolder_button);
			this.splitContainer1.Panel1.Controls.Add(this.rootFolder_textBox);
			this.splitContainer1.Panel1.Controls.Add(this.BuildType_groupBox);
			this.splitContainer1.Panel1.Controls.Add(this.warning_label);
			this.splitContainer1.Panel1.Controls.Add(this.startBuild_button);
			this.splitContainer1.Panel1.Controls.Add(this.platform_groupBox);
			this.splitContainer1.Panel1MinSize = 355;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.consoleOutput_tabControl);
			this.splitContainer1.Panel2MinSize = 125;
			this.splitContainer1.Size = new System.Drawing.Size(1169, 476);
			this.splitContainer1.SplitterDistance = 355;
			this.splitContainer1.TabIndex = 5;
			// 
			// options_groupBox
			// 
			this.options_groupBox.Controls.Add(this.cookOnly_checkBox);
			this.options_groupBox.Location = new System.Drawing.Point(148, 56);
			this.options_groupBox.Name = "options_groupBox";
			this.options_groupBox.Size = new System.Drawing.Size(200, 46);
			this.options_groupBox.TabIndex = 7;
			this.options_groupBox.TabStop = false;
			this.options_groupBox.Text = "Options";
			// 
			// cookOnly_checkBox
			// 
			this.cookOnly_checkBox.AutoSize = true;
			this.cookOnly_checkBox.Location = new System.Drawing.Point(7, 20);
			this.cookOnly_checkBox.Name = "cookOnly_checkBox";
			this.cookOnly_checkBox.Size = new System.Drawing.Size(73, 17);
			this.cookOnly_checkBox.TabIndex = 0;
			this.cookOnly_checkBox.Text = "Cook only";
			this.cookOnly_checkBox.UseVisualStyleBackColor = true;
			// 
			// stopBuild_button
			// 
			this.stopBuild_button.Location = new System.Drawing.Point(221, 210);
			this.stopBuild_button.Name = "stopBuild_button";
			this.stopBuild_button.Size = new System.Drawing.Size(121, 23);
			this.stopBuild_button.TabIndex = 6;
			this.stopBuild_button.Text = "Stop Current Build";
			this.stopBuild_button.UseVisualStyleBackColor = true;
			this.stopBuild_button.Visible = false;
			this.stopBuild_button.Click += new System.EventHandler(this.StopBuild_button_Click);
			// 
			// selectFolder_button
			// 
			this.selectFolder_button.Location = new System.Drawing.Point(322, 4);
			this.selectFolder_button.Name = "selectFolder_button";
			this.selectFolder_button.Size = new System.Drawing.Size(26, 20);
			this.selectFolder_button.TabIndex = 5;
			this.selectFolder_button.Text = "...";
			this.selectFolder_button.UseVisualStyleBackColor = true;
			this.selectFolder_button.Click += new System.EventHandler(this.SelectFolder_button_Click);
			// 
			// rootFolder_textBox
			// 
			this.rootFolder_textBox.Location = new System.Drawing.Point(10, 4);
			this.rootFolder_textBox.Name = "rootFolder_textBox";
			this.rootFolder_textBox.Size = new System.Drawing.Size(306, 20);
			this.rootFolder_textBox.TabIndex = 4;
			this.rootFolder_textBox.Text = "D:\\Unreal4.20\\";
			// 
			// consoleOutput_tabControl
			// 
			this.consoleOutput_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.consoleOutput_tabControl.Location = new System.Drawing.Point(3, 3);
			this.consoleOutput_tabControl.Name = "consoleOutput_tabControl";
			this.consoleOutput_tabControl.SelectedIndex = 0;
			this.consoleOutput_tabControl.Size = new System.Drawing.Size(804, 470);
			this.consoleOutput_tabControl.TabIndex = 5;
			// 
			// BuildSetupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1193, 500);
			this.Controls.Add(this.splitContainer1);
			this.Name = "BuildSetupForm";
			this.Text = "The Vagrant Build Assist Tool";
			this.Load += new System.EventHandler(this.BuildSetupForm_Load);
			this.BuildType_groupBox.ResumeLayout(false);
			this.BuildType_groupBox.PerformLayout();
			this.platform_groupBox.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.options_groupBox.ResumeLayout(false);
			this.options_groupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button startBuild_button;
		private System.Windows.Forms.GroupBox BuildType_groupBox;
		private System.Windows.Forms.RadioButton shipBuild_radioButton;
		private System.Windows.Forms.RadioButton devBuild_radioButton;
		private System.Windows.Forms.GroupBox platform_groupBox;
		private System.Windows.Forms.CheckedListBox platform_checkedListBox;
		private System.Windows.Forms.Label warning_label;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl consoleOutput_tabControl;
		private System.Windows.Forms.Button selectFolder_button;
		private System.Windows.Forms.TextBox rootFolder_textBox;
		private System.Windows.Forms.Button stopBuild_button;
		private System.Windows.Forms.GroupBox options_groupBox;
		private System.Windows.Forms.CheckBox cookOnly_checkBox;
	}
}