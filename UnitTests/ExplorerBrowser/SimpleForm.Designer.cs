namespace Microsoft.WindowsAPICodePack.Samples
{
    partial class SimpleForm
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
            this.explorerBrowser1 = new Vanara.Windows.Forms.ExplorerBrowser();
            this.SuspendLayout();
            // 
            // explorerBrowser1
            // 
            this.explorerBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.explorerBrowser1.ContentFlags = ((Vanara.Windows.Forms.ExplorerBrowserContentSectionOptions)((Vanara.Windows.Forms.ExplorerBrowserContentSectionOptions.NoWebView | Vanara.Windows.Forms.ExplorerBrowserContentSectionOptions.UseSearchFolder)));
            this.explorerBrowser1.Location = new System.Drawing.Point(124, 48);
            this.explorerBrowser1.Name = "explorerBrowser1";
            this.explorerBrowser1.NavigationFlags = Vanara.Windows.Forms.ExplorerBrowserNavigateOptions.ShowFrames;
            this.explorerBrowser1.Size = new System.Drawing.Size(541, 335);
            this.explorerBrowser1.TabIndex = 0;
            // 
            // SimpleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.explorerBrowser1);
            this.Name = "SimpleForm";
            this.Text = "SimpleForm";
            this.Load += new System.EventHandler(this.SimpleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Vanara.Windows.Forms.ExplorerBrowser explorerBrowser1;
    }
}