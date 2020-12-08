
namespace Vanara.Windows.Shell.Tests
{
	partial class ImageViewer
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
			this.flow = new System.Windows.Forms.FlowLayoutPanel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// flow
			// 
			this.flow.AutoScroll = true;
			this.flow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flow.Location = new System.Drawing.Point(0, 0);
			this.flow.Name = "flow";
			this.flow.Size = new System.Drawing.Size(578, 375);
			this.flow.TabIndex = 0;
			// 
			// ImageViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(578, 375);
			this.Controls.Add(this.flow);
			this.Name = "ImageViewer";
			this.Text = "ImageViewer";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flow;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}