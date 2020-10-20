namespace Vanara.PInvoke
{
	partial class ShellViewTestForm
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
			this.shellView1 = new Vanara.Windows.Shell.ShellView();
			this.SuspendLayout();
			// 
			// shellView1
			// 
			this.shellView1.Location = new System.Drawing.Point(327, 34);
			this.shellView1.Name = "shellView1";
			this.shellView1.Size = new System.Drawing.Size(407, 352);
			this.shellView1.TabIndex = 0;
			this.shellView1.Text = "shellView1";
			this.shellView1.Navigating += new System.EventHandler<Vanara.Windows.Shell.NavigatingEventArgs>(this.shellView1_Navigating);
			// 
			// ShellViewTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.shellView1);
			this.Name = "ShellViewTestForm";
			this.Text = "ShellViewTestForm";
			this.ResumeLayout(false);

		}

		#endregion

		private Windows.Shell.ShellView shellView1;
	}
}