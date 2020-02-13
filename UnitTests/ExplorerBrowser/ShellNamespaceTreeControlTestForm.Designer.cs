namespace ExplorerBrowser
{
	partial class ShellNamespaceTreeControlTestForm
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
			this.shellNamespaceTreeControl1 = new Vanara.Windows.Forms.ShellNamespaceTreeControl();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.log = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// shellNamespaceTreeControl1
			// 
			this.shellNamespaceTreeControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.shellNamespaceTreeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.shellNamespaceTreeControl1.Location = new System.Drawing.Point(0, 0);
			this.shellNamespaceTreeControl1.Name = "shellNamespaceTreeControl1";
			this.shellNamespaceTreeControl1.Size = new System.Drawing.Size(526, 450);
			this.shellNamespaceTreeControl1.TabIndex = 0;
			this.shellNamespaceTreeControl1.AfterExpand += new System.EventHandler<Vanara.Windows.Forms.ShellNamespaceTreeControlEventArgs>(this.shellNamespaceTreeControl1_AfterExpand);
			this.shellNamespaceTreeControl1.AfterLabelEdit += new System.EventHandler<Vanara.Windows.Forms.ShellNamespaceTreeControlItemLabelEditEventArgs>(this.shellNamespaceTreeControl1_AfterLabelEdit);
			this.shellNamespaceTreeControl1.BeforeExpand += new System.EventHandler<Vanara.Windows.Forms.ShellNamespaceTreeControlEventArgs>(this.shellNamespaceTreeControl1_BeforeExpand);
			this.shellNamespaceTreeControl1.BeforeItemDelete += new System.EventHandler<Vanara.Windows.Forms.ShellNamespaceTreeControlEventArgs>(this.shellNamespaceTreeControl1_BeforeItemDelete);
			this.shellNamespaceTreeControl1.BeforeLabelEdit += new System.EventHandler<Vanara.Windows.Forms.ShellNamespaceTreeControlItemLabelEditEventArgs>(this.shellNamespaceTreeControl1_BeforeLabelEdit);
			this.shellNamespaceTreeControl1.ItemMouseClick += new System.EventHandler<Vanara.Windows.Forms.ShellNamespaceTreeControlItemMouseClickEventArgs>(this.shellNamespaceTreeControl1_ItemMouseClick);
			this.shellNamespaceTreeControl1.ItemMouseDoubleClick += new System.EventHandler<Vanara.Windows.Forms.ShellNamespaceTreeControlItemMouseClickEventArgs>(this.shellNamespaceTreeControl1_ItemMouseDoubleClick);
			this.shellNamespaceTreeControl1.AfterSelect += new System.EventHandler(this.shellNamespaceTreeControl1_SelectionChanged);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(200, 295);
			this.propertyGrid1.TabIndex = 1;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(526, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 450);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitter2);
			this.panel1.Controls.Add(this.propertyGrid1);
			this.panel1.Controls.Add(this.log);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(529, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 450);
			this.panel1.TabIndex = 3;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(0, 292);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(200, 3);
			this.splitter2.TabIndex = 2;
			this.splitter2.TabStop = false;
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.log.Location = new System.Drawing.Point(0, 295);
			this.log.Multiline = true;
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(200, 155);
			this.log.TabIndex = 3;
			// 
			// ShellNamespaceTreeControlTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 450);
			this.Controls.Add(this.shellNamespaceTreeControl1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Name = "ShellNamespaceTreeControlTestForm";
			this.Text = "Test Shell Namespace Tree Control";
			this.Load += new System.EventHandler(this.ShellNamespaceTreeControlTestForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Vanara.Windows.Forms.ShellNamespaceTreeControl shellNamespaceTreeControl1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.TextBox log;
	}
}