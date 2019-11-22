//Copyright (c) Microsoft Corporation.  All rights reserved.


namespace Microsoft.WindowsAPICodePack.Samples
{
    partial class ExplorerBrowserTestForm
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
			this.label3 = new System.Windows.Forms.Label();
			this.itemsTextBox = new System.Windows.Forms.RichTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.filePathNavigate = new System.Windows.Forms.Button();
			this.filePathEdit = new System.Windows.Forms.TextBox();
			this.knownFolderNavigate = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.knownFolderCombo = new System.Windows.Forms.ComboBox();
			this.navigateButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.pathEdit = new System.Windows.Forms.TextBox();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.clearHistoryButton = new System.Windows.Forms.Button();
			this.forwardButton = new System.Windows.Forms.Button();
			this.navigationHistoryCombo = new System.Windows.Forms.ComboBox();
			this.backButton = new System.Windows.Forms.Button();
			this.failNavigationCheckBox = new System.Windows.Forms.CheckBox();
			this.itemsTabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.selectedItemsTextBox = new System.Windows.Forms.RichTextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.eventHistoryTextBox = new System.Windows.Forms.RichTextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.explorerBrowser = new Vanara.Windows.Forms.ExplorerBrowser();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.itemsTabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.label3.Size = new System.Drawing.Size(97, 19);
			this.label3.TabIndex = 9;
			this.label3.Text = "Navigation Options";
			// 
			// itemsTextBox
			// 
			this.itemsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsTextBox.Location = new System.Drawing.Point(3, 3);
			this.itemsTextBox.Name = "itemsTextBox";
			this.itemsTextBox.Size = new System.Drawing.Size(644, 158);
			this.itemsTextBox.TabIndex = 0;
			this.itemsTextBox.Text = "";
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 7);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(51, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "File Path:";
			// 
			// filePathNavigate
			// 
			this.filePathNavigate.Enabled = false;
			this.filePathNavigate.Location = new System.Drawing.Point(523, 3);
			this.filePathNavigate.Name = "filePathNavigate";
			this.filePathNavigate.Size = new System.Drawing.Size(126, 22);
			this.filePathNavigate.TabIndex = 7;
			this.filePathNavigate.Text = "Navigate File";
			this.filePathNavigate.UseVisualStyleBackColor = true;
			this.filePathNavigate.Click += new System.EventHandler(this.filePathNavigate_Click);
			// 
			// filePathEdit
			// 
			this.filePathEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.filePathEdit.Location = new System.Drawing.Point(84, 3);
			this.filePathEdit.Name = "filePathEdit";
			this.filePathEdit.Size = new System.Drawing.Size(433, 20);
			this.filePathEdit.TabIndex = 6;
			this.filePathEdit.TextChanged += new System.EventHandler(this.filePathEdit_TextChanged);
			// 
			// knownFolderNavigate
			// 
			this.knownFolderNavigate.Enabled = false;
			this.knownFolderNavigate.Location = new System.Drawing.Point(523, 60);
			this.knownFolderNavigate.Name = "knownFolderNavigate";
			this.knownFolderNavigate.Size = new System.Drawing.Size(126, 23);
			this.knownFolderNavigate.TabIndex = 5;
			this.knownFolderNavigate.Text = "Navigate Known Folder";
			this.knownFolderNavigate.UseVisualStyleBackColor = true;
			this.knownFolderNavigate.Click += new System.EventHandler(this.knownFolderNavigate_Click);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 65);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Known Folder:";
			// 
			// knownFolderCombo
			// 
			this.knownFolderCombo.Dock = System.Windows.Forms.DockStyle.Top;
			this.knownFolderCombo.FormattingEnabled = true;
			this.knownFolderCombo.Location = new System.Drawing.Point(84, 60);
			this.knownFolderCombo.Name = "knownFolderCombo";
			this.knownFolderCombo.Size = new System.Drawing.Size(433, 21);
			this.knownFolderCombo.TabIndex = 3;
			this.knownFolderCombo.SelectedIndexChanged += new System.EventHandler(this.knownFolderCombo_SelectedIndexChanged);
			// 
			// navigateButton
			// 
			this.navigateButton.Enabled = false;
			this.navigateButton.Location = new System.Drawing.Point(523, 31);
			this.navigateButton.Name = "navigateButton";
			this.navigateButton.Size = new System.Drawing.Size(127, 23);
			this.navigateButton.TabIndex = 2;
			this.navigateButton.Text = "Navigate Path";
			this.navigateButton.UseVisualStyleBackColor = true;
			this.navigateButton.Click += new System.EventHandler(this.navigateButton_Click);
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Folder Path:";
			// 
			// pathEdit
			// 
			this.pathEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.pathEdit.Location = new System.Drawing.Point(84, 31);
			this.pathEdit.Name = "pathEdit";
			this.pathEdit.Size = new System.Drawing.Size(433, 20);
			this.pathEdit.TabIndex = 0;
			this.pathEdit.TextChanged += new System.EventHandler(this.pathEdit_TextChanged);
			// 
			// propertyGrid
			// 
			this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Top;
			this.propertyGrid.Location = new System.Drawing.Point(3, 22);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(250, 527);
			this.propertyGrid.TabIndex = 11;
			// 
			// clearHistoryButton
			// 
			this.clearHistoryButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.clearHistoryButton.Location = new System.Drawing.Point(523, 119);
			this.clearHistoryButton.Name = "clearHistoryButton";
			this.clearHistoryButton.Size = new System.Drawing.Size(125, 23);
			this.clearHistoryButton.TabIndex = 14;
			this.clearHistoryButton.Text = "Clear History";
			this.clearHistoryButton.UseVisualStyleBackColor = true;
			this.clearHistoryButton.Click += new System.EventHandler(this.clearHistoryButton_Click);
			// 
			// forwardButton
			// 
			this.forwardButton.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.forwardButton.Location = new System.Drawing.Point(33, 3);
			this.forwardButton.Name = "forwardButton";
			this.forwardButton.Size = new System.Drawing.Size(24, 24);
			this.forwardButton.TabIndex = 13;
			this.forwardButton.Text = ">";
			this.forwardButton.UseVisualStyleBackColor = true;
			this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
			// 
			// navigationHistoryCombo
			// 
			this.navigationHistoryCombo.Dock = System.Windows.Forms.DockStyle.Top;
			this.navigationHistoryCombo.FormattingEnabled = true;
			this.navigationHistoryCombo.Location = new System.Drawing.Point(84, 89);
			this.navigationHistoryCombo.Name = "navigationHistoryCombo";
			this.navigationHistoryCombo.Size = new System.Drawing.Size(433, 21);
			this.navigationHistoryCombo.TabIndex = 12;
			this.navigationHistoryCombo.SelectedIndexChanged += new System.EventHandler(this.navigationHistoryCombo_SelectedIndexChanged);
			// 
			// backButton
			// 
			this.backButton.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.backButton.Location = new System.Drawing.Point(3, 3);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(24, 24);
			this.backButton.TabIndex = 10;
			this.backButton.Text = "<";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// failNavigationCheckBox
			// 
			this.failNavigationCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.failNavigationCheckBox.AutoSize = true;
			this.failNavigationCheckBox.Location = new System.Drawing.Point(523, 91);
			this.failNavigationCheckBox.Name = "failNavigationCheckBox";
			this.failNavigationCheckBox.Size = new System.Drawing.Size(138, 17);
			this.failNavigationCheckBox.TabIndex = 9;
			this.failNavigationCheckBox.Text = "Force Navigation to Fail";
			this.failNavigationCheckBox.UseVisualStyleBackColor = true;
			// 
			// itemsTabControl
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.itemsTabControl, 3);
			this.itemsTabControl.Controls.Add(this.tabPage1);
			this.itemsTabControl.Controls.Add(this.tabPage2);
			this.itemsTabControl.Controls.Add(this.tabPage3);
			this.itemsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsTabControl.Location = new System.Drawing.Point(3, 641);
			this.itemsTabControl.Name = "itemsTabControl";
			this.itemsTabControl.SelectedIndex = 0;
			this.itemsTabControl.Size = new System.Drawing.Size(658, 190);
			this.itemsTabControl.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.itemsTextBox);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(650, 164);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Items (Count=0)";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.selectedItemsTextBox);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(664, 164);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Selected Items (Count=0)";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// selectedItemsTextBox
			// 
			this.selectedItemsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectedItemsTextBox.Location = new System.Drawing.Point(3, 3);
			this.selectedItemsTextBox.Name = "selectedItemsTextBox";
			this.selectedItemsTextBox.Size = new System.Drawing.Size(658, 158);
			this.selectedItemsTextBox.TabIndex = 0;
			this.selectedItemsTextBox.Text = "";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.eventHistoryTextBox);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(664, 164);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Event History";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// eventHistoryTextBox
			// 
			this.eventHistoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.eventHistoryTextBox.Location = new System.Drawing.Point(0, 0);
			this.eventHistoryTextBox.Name = "eventHistoryTextBox";
			this.eventHistoryTextBox.Size = new System.Drawing.Size(664, 164);
			this.eventHistoryTextBox.TabIndex = 0;
			this.eventHistoryTextBox.Text = "";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.label3);
			this.flowLayoutPanel1.Controls.Add(this.propertyGrid);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(256, 834);
			this.flowLayoutPanel1.TabIndex = 12;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.clearHistoryButton, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.navigationHistoryCombo, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.explorerBrowser, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.itemsTabControl, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.filePathNavigate, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.pathEdit, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.knownFolderCombo, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.navigateButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.failNavigationCheckBox, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.knownFolderNavigate, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.filePathEdit, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(263, 7);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 834);
			this.tableLayoutPanel1.TabIndex = 13;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 2);
			this.flowLayoutPanel2.Controls.Add(this.forwardButton);
			this.flowLayoutPanel2.Controls.Add(this.backButton);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 116);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(60, 30);
			this.flowLayoutPanel2.TabIndex = 14;
			// 
			// explorerBrowser
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.explorerBrowser, 3);
			this.explorerBrowser.ContentFlags = ((Vanara.Windows.Forms.ExplorerBrowserContentSectionOptions)((Vanara.Windows.Forms.ExplorerBrowserContentSectionOptions.NoWebView | Vanara.Windows.Forms.ExplorerBrowserContentSectionOptions.UseSearchFolder)));
			this.explorerBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.explorerBrowser.Location = new System.Drawing.Point(3, 152);
			this.explorerBrowser.Name = "explorerBrowser";
			this.explorerBrowser.NavigationFlags = Vanara.Windows.Forms.ExplorerBrowserNavigateOptions.ShowFrames;
			this.explorerBrowser.PropertyBagName = "Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser";
			this.explorerBrowser.Size = new System.Drawing.Size(658, 483);
			this.explorerBrowser.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(263, 7);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 834);
			this.splitter1.TabIndex = 14;
			this.splitter1.TabStop = false;
			// 
			// ExplorerBrowserTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(934, 848);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "ExplorerBrowserTestForm";
			this.Padding = new System.Windows.Forms.Padding(7);
			this.Text = "Explorer Browser Demo";
			this.itemsTabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button navigateButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pathEdit;
        private System.Windows.Forms.Button knownFolderNavigate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox knownFolderCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button filePathNavigate;
        private System.Windows.Forms.TextBox filePathEdit;
        private System.Windows.Forms.RichTextBox itemsTextBox;
        private Vanara.Windows.Forms.ExplorerBrowser explorerBrowser;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.CheckBox failNavigationCheckBox;
        private System.Windows.Forms.TabControl itemsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox selectedItemsTextBox;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.ComboBox navigationHistoryCombo;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox eventHistoryTextBox;
        private System.Windows.Forms.Button clearHistoryButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Splitter splitter1;
	}
}

