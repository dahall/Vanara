namespace Windows.Forms.App
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dlgCombo = new System.Windows.Forms.ComboBox();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.oneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.twoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.threeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.taskbarButton1 = new Vanara.Windows.Shell.TaskbarButton(this.components);
			this.shellItemChangeWatcher1 = new Vanara.Windows.Shell.ShellItemChangeWatcher();
			this.ipAddressBox1 = new Vanara.Windows.Forms.IPAddressBox();
			this.themedImageDraw1 = new Vanara.Windows.Forms.ThemedImageDraw();
			this.themedLabel1 = new Vanara.Windows.Forms.ThemedLabel();
			this.themedPanel1 = new Vanara.Windows.Forms.ThemedPanel();
			this.splitButton1 = new Vanara.Windows.Forms.SplitButton();
			this.enumComboBox1 = new Vanara.Windows.Forms.EnumComboBox();
			this.customButton1 = new Vanara.Windows.Forms.CustomButton();
			this.commandLink1 = new Vanara.Windows.Forms.CommandLink();
			this.vistaControlExtender1 = new Vanara.Windows.Forms.VistaControlExtender(this.components);
			this.glassExtenderProvider1 = new Vanara.Windows.Forms.GlassExtenderProvider();
			this.trackBarEx1 = new Vanara.Windows.Forms.TrackBarEx();
			this.logDisplay = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.taskbarButton1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.shellItemChangeWatcher1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vistaControlExtender1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarEx1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dlgCombo);
			this.groupBox1.Controls.Add(this.propertyGrid1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(350, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(329, 411);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dialogs";
			// 
			// dlgCombo
			// 
			this.vistaControlExtender1.SetCueBanner(this.dlgCombo, "Select which dialog to edit & show");
			this.dlgCombo.FormattingEnabled = true;
			this.dlgCombo.Location = new System.Drawing.Point(7, 23);
			this.vistaControlExtender1.SetMinVisibleItems(this.dlgCombo, 0);
			this.dlgCombo.Name = "dlgCombo";
			this.dlgCombo.Size = new System.Drawing.Size(243, 23);
			this.dlgCombo.TabIndex = 3;
			this.dlgCombo.SelectedIndexChanged += new System.EventHandler(this.dlgCombo_SelectedIndexChanged);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.Location = new System.Drawing.Point(7, 53);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(316, 352);
			this.propertyGrid1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(256, 23);
			this.button1.Name = "button1";
			this.vistaControlExtender1.SetShowShield(this.button1, true);
			this.button1.Size = new System.Drawing.Size(67, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Go";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneToolStripMenuItem,
            this.twoToolStripMenuItem,
            this.threeToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(104, 70);
			// 
			// oneToolStripMenuItem
			// 
			this.oneToolStripMenuItem.Name = "oneToolStripMenuItem";
			this.oneToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.oneToolStripMenuItem.Text = "One";
			// 
			// twoToolStripMenuItem
			// 
			this.twoToolStripMenuItem.Name = "twoToolStripMenuItem";
			this.twoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.twoToolStripMenuItem.Text = "Two";
			// 
			// threeToolStripMenuItem
			// 
			this.threeToolStripMenuItem.Name = "threeToolStripMenuItem";
			this.threeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.threeToolStripMenuItem.Text = "Three";
			// 
			// shellItemChangeWatcher1
			// 
			this.shellItemChangeWatcher1.IncludeChildren = true;
			this.shellItemChangeWatcher1.Changed += new System.EventHandler<Vanara.Windows.Shell.ShellItemChangeWatcher.ShellItemChangeEventArgs>(this.ShellItemChangeWatcher1_Changed);
			// 
			// ipAddressBox1
			// 
			this.ipAddressBox1.Location = new System.Drawing.Point(12, 452);
			this.ipAddressBox1.Name = "ipAddressBox1";
			this.ipAddressBox1.Size = new System.Drawing.Size(102, 23);
			this.ipAddressBox1.TabIndex = 9;
			this.ipAddressBox1.Text = "255.255.255.255";
			// 
			// themedImageDraw1
			// 
			this.themedImageDraw1.AutoEllipsis = false;
			this.themedImageDraw1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("themedImageDraw1.BackgroundImage")));
			this.themedImageDraw1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.themedImageDraw1.Location = new System.Drawing.Point(132, 48);
			this.themedImageDraw1.Name = "themedImageDraw1";
			this.themedImageDraw1.Size = new System.Drawing.Size(32, 32);
			this.themedImageDraw1.StyleClass = "Button";
			this.themedImageDraw1.SupportGlass = true;
			this.themedImageDraw1.TabIndex = 8;
			// 
			// themedLabel1
			// 
			this.themedLabel1.Location = new System.Drawing.Point(9, 48);
			this.themedLabel1.Name = "themedLabel1";
			this.themedLabel1.Size = new System.Drawing.Size(100, 23);
			this.themedLabel1.StyleClass = "WINDOW";
			this.themedLabel1.StylePart = 1;
			this.themedLabel1.StyleState = 1;
			this.themedLabel1.SupportGlass = true;
			this.themedLabel1.TabIndex = 6;
			this.themedLabel1.Text = "themedLabel";
			// 
			// themedPanel1
			// 
			this.themedPanel1.Location = new System.Drawing.Point(12, 375);
			this.themedPanel1.Name = "themedPanel1";
			this.themedPanel1.Size = new System.Drawing.Size(332, 70);
			this.themedPanel1.StyleClass = "ExplorerBar";
			this.themedPanel1.StylePart = 1;
			this.themedPanel1.TabIndex = 7;
			// 
			// splitButton1
			// 
			this.splitButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.splitButton1.Location = new System.Drawing.Point(12, 269);
			this.splitButton1.Name = "splitButton1";
			this.splitButton1.Size = new System.Drawing.Size(131, 23);
			this.splitButton1.SplitMenuStrip = this.contextMenuStrip1;
			this.splitButton1.TabIndex = 4;
			this.splitButton1.Text = "splitButton1";
			this.splitButton1.UseVisualStyleBackColor = true;
			// 
			// enumComboBox1
			// 
			this.enumComboBox1.ControlSize = new System.Drawing.Size(187, 105);
			this.enumComboBox1.DropSize = new System.Drawing.Size(121, 106);
			this.enumComboBox1.EnumTypeString = "System.AttributeTargets";
			this.enumComboBox1.FormattingEnabled = true;
			this.enumComboBox1.Location = new System.Drawing.Point(12, 302);
			this.vistaControlExtender1.SetMinVisibleItems(this.enumComboBox1, 0);
			this.enumComboBox1.Name = "enumComboBox1";
			this.enumComboBox1.Size = new System.Drawing.Size(332, 23);
			this.enumComboBox1.TabIndex = 3;
			// 
			// customButton1
			// 
			this.customButton1.AutoEllipsis = false;
			this.customButton1.Image = ((System.Drawing.Image)(resources.GetObject("customButton1.Image")));
			this.customButton1.Location = new System.Drawing.Point(12, 178);
			this.customButton1.Name = "customButton1";
			this.customButton1.Size = new System.Drawing.Size(102, 85);
			this.customButton1.TabIndex = 2;
			this.customButton1.Text = "customButton1";
			this.customButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// commandLink1
			// 
			this.commandLink1.Location = new System.Drawing.Point(12, 96);
			this.commandLink1.Name = "commandLink1";
			this.commandLink1.NoteText = "This is the subtext that goes underneath.";
			this.commandLink1.Size = new System.Drawing.Size(200, 76);
			this.commandLink1.TabIndex = 1;
			this.commandLink1.Text = "Command Link";
			// 
			// trackBarEx1
			// 
			this.trackBarEx1.Location = new System.Drawing.Point(12, 331);
			this.trackBarEx1.Name = "trackBarEx1";
			this.trackBarEx1.SelectionEnd = 8;
			this.trackBarEx1.SelectionStart = 2;
			this.trackBarEx1.ShowSelection = true;
			this.trackBarEx1.Size = new System.Drawing.Size(332, 33);
			this.trackBarEx1.TabIndex = 12;
			// 
			// logDisplay
			// 
			this.logDisplay.Location = new System.Drawing.Point(160, 178);
			this.logDisplay.Multiline = true;
			this.logDisplay.Name = "logDisplay";
			this.logDisplay.ReadOnly = true;
			this.logDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.logDisplay.Size = new System.Drawing.Size(184, 114);
			this.logDisplay.TabIndex = 11;
			this.logDisplay.WordWrap = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(695, 519);
			this.Controls.Add(this.logDisplay);
			this.Controls.Add(this.trackBarEx1);
			this.Controls.Add(this.ipAddressBox1);
			this.Controls.Add(this.themedImageDraw1);
			this.Controls.Add(this.themedLabel1);
			this.Controls.Add(this.themedPanel1);
			this.Controls.Add(this.splitButton1);
			this.Controls.Add(this.enumComboBox1);
			this.Controls.Add(this.customButton1);
			this.Controls.Add(this.commandLink1);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.glassExtenderProvider1.SetGlassMargins(this, new System.Windows.Forms.Padding(0, 85, 0, 0));
			this.Name = "Form1";
			this.Text = "Vanara.Windows.Forms Test App";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.taskbarButton1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.shellItemChangeWatcher1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vistaControlExtender1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarEx1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button button1;
		private Vanara.Windows.Forms.CommandLink commandLink1;
		private Vanara.Windows.Forms.VistaControlExtender vistaControlExtender1;
		private Vanara.Windows.Forms.CustomButton customButton1;
		private Vanara.Windows.Forms.EnumComboBox enumComboBox1;
		private Vanara.Windows.Forms.SplitButton splitButton1;
		private System.Windows.Forms.ComboBox dlgCombo;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem oneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem twoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem threeToolStripMenuItem;
		private Vanara.Windows.Forms.GlassExtenderProvider glassExtenderProvider1;
		private Vanara.Windows.Forms.ThemedLabel themedLabel1;
		private Vanara.Windows.Forms.ThemedPanel themedPanel1;
		private Vanara.Windows.Forms.ThemedImageDraw themedImageDraw1;
		private Vanara.Windows.Forms.IPAddressBox ipAddressBox1;
		private Vanara.Windows.Shell.TaskbarButton taskbarButton1;
		private Vanara.Windows.Shell.ShellItemChangeWatcher shellItemChangeWatcher1;
		private Vanara.Windows.Forms.TrackBarEx trackBarEx1;
		private System.Windows.Forms.TextBox logDisplay;
	}
}

