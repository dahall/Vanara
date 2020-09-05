/*
 * Copyright © 2015 David Hall
 *
 * Design Notes:-
 * --------------
 * - Maximum size: 150px. Limited by the control itself.
 *
 * References:
 * - http://www.codeproject.com/KB/vista/Vista_TaskDialog_Wrapper.aspx
 * - http://www.codeproject.com/Articles/21276/Vista-TaskDialog-Wrapper-and-Emulator
 *
 * Revision Control:-
 * ------------------
 * Created On: 2007 November 26
 * Major updates: 2015 Nov 6
 */

#if TASKDIALOG_EMULATE
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	internal class EmulateExpInfoButton : UserControl
	{
		private string collapsedText;
		private System.ComponentModel.IContainer components = null;
		private string expandedText;
		private bool isExpanded;
		private Label label;
		private PictureBox pictureBox;
		private TableLayoutPanel tableLayoutPanel;
		private readonly ImageList imageList;

		public EmulateExpInfoButton(bool newIsExpanded, string newExpandedText, string newCollapsedText)
		{
			InitializeComponent();

			isExpanded = newIsExpanded;
			expandedText = newExpandedText;
			collapsedText = newCollapsedText;
			imageList = new ImageList(components) { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(19, 21) };
			imageList.Images.AddStrip(Properties.Resources.ExpandoButtonV);

			SetState();
		}

		public override string Text
		{
			get { return label.Text; }
			set { label.Text = value; }
		}

		public void ToogleState()
		{
			isExpanded = !isExpanded;

			SetState();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				components?.Dispose();
			base.Dispose(disposing);
		}

		private void EmulateExpInfoButton_Click(object sender, EventArgs e)
		{
			OnClick(e);
		}

		private void EmulateExpInfoButton_Enter(object sender, EventArgs e)
		{
			// Focus rectangle.
			// http://msdn.microsoft.com/en-us/library/system.windows.forms.controlpaint.drawfocusrectangle(VS.71).aspx
			ControlPaint.DrawFocusRectangle(Graphics.FromHwnd(label.Handle), label.ClientRectangle);
		}

		private void EmulateExpInfoButton_Leave(object sender, EventArgs e)
		{
			// Lost focus.
			// Correct way to erase a border?
			ControlPaint.DrawBorder(Graphics.FromHwnd(label.Handle), label.ClientRectangle, label.BackColor, ButtonBorderStyle.Solid);
		}

		private void EmulateExpInfoButton_MouseDown(object sender, MouseEventArgs e)
		{
			pictureBox.Image = imageList.Images[isExpanded ? 2 : 6];
		}

		private void EmulateExpInfoButton_MouseEnter(object sender, EventArgs e)
		{
			pictureBox.Image = imageList.Images[isExpanded ? 1 : 5];
		}

		private void EmulateExpInfoButton_MouseLeave(object sender, EventArgs e)
		{
			pictureBox.Image = imageList.Images[isExpanded ? 0 : 4];
		}

		private void EmulateExpInfoButton_MouseUp(object sender, MouseEventArgs e)
		{
			pictureBox.Image = imageList.Images[isExpanded ? 0 : 4];
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pictureBox = new System.Windows.Forms.PictureBox();
			label = new Label();
			tableLayoutPanel = new TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(pictureBox)).BeginInit();
			tableLayoutPanel.SuspendLayout();
			SuspendLayout();
			//
			// pictureBox
			//
			pictureBox.Location = new System.Drawing.Point(0, 0);
			pictureBox.Margin = new System.Windows.Forms.Padding(0);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new System.Drawing.Size(20, 20);
			pictureBox.TabIndex = 2;
			pictureBox.TabStop = false;
			pictureBox.Click += new EventHandler(EmulateExpInfoButton_Click);
			pictureBox.MouseDown += new MouseEventHandler(EmulateExpInfoButton_MouseDown);
			pictureBox.MouseEnter += new EventHandler(EmulateExpInfoButton_MouseEnter);
			pictureBox.MouseLeave += new EventHandler(EmulateExpInfoButton_MouseLeave);
			pictureBox.MouseUp += new MouseEventHandler(EmulateExpInfoButton_MouseUp);
			//
			// label
			//
			label.AutoSize = true;
			label.Dock = System.Windows.Forms.DockStyle.Fill;
			label.Location = new System.Drawing.Point(20, 0);
			label.Margin = new System.Windows.Forms.Padding(0);
			label.MaximumSize = new System.Drawing.Size(130, 0);
			label.Name = "label";
			label.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			label.Size = new System.Drawing.Size(70, 20);
			label.TabIndex = 3;
			label.Text = "label";
			label.Click += new EventHandler(EmulateExpInfoButton_Click);
			label.MouseDown += new MouseEventHandler(EmulateExpInfoButton_MouseDown);
			label.MouseEnter += new EventHandler(EmulateExpInfoButton_MouseEnter);
			label.MouseLeave += new EventHandler(EmulateExpInfoButton_MouseLeave);
			label.MouseUp += new MouseEventHandler(EmulateExpInfoButton_MouseUp);
			//
			// tableLayoutPanel
			//
			tableLayoutPanel.AutoSize = true;
			tableLayoutPanel.ColumnCount = 2;
			tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
			tableLayoutPanel.Controls.Add(label, 1, 0);
			tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel.Name = "tableLayoutPanel";
			tableLayoutPanel.RowCount = 1;
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel.Size = new System.Drawing.Size(90, 20);
			tableLayoutPanel.TabIndex = 4;
			tableLayoutPanel.Click += new EventHandler(EmulateExpInfoButton_Click);
			tableLayoutPanel.MouseDown += new MouseEventHandler(EmulateExpInfoButton_MouseDown);
			tableLayoutPanel.MouseEnter += new EventHandler(EmulateExpInfoButton_MouseEnter);
			tableLayoutPanel.MouseLeave += new EventHandler(EmulateExpInfoButton_MouseLeave);
			tableLayoutPanel.MouseUp += new MouseEventHandler(EmulateExpInfoButton_MouseUp);
			//
			// EmulateExpInfoButton
			//
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoSize = true;
			Controls.Add(tableLayoutPanel);
			Margin = new System.Windows.Forms.Padding(0);
			MinimumSize = new System.Drawing.Size(0, 20);
			Name = "EmulateExpInfoButton";
			Size = new System.Drawing.Size(90, 20);
			Enter += new System.EventHandler(EmulateExpInfoButton_Enter);
			Leave += new System.EventHandler(EmulateExpInfoButton_Leave);
			((System.ComponentModel.ISupportInitialize)(pictureBox)).EndInit();
			tableLayoutPanel.ResumeLayout(false);
			tableLayoutPanel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private void SetState()
		{
			pictureBox.Image = imageList.Images[isExpanded ? 0 : 4];

			if (isExpanded)
			{
				Text = string.IsNullOrEmpty(collapsedText) ? "Hide details" : collapsedText;
			}
			else
			{
				if (string.IsNullOrEmpty(expandedText) && string.IsNullOrEmpty(collapsedText))
				{
					Text = "See details";
				}
				else if (string.IsNullOrEmpty(expandedText) && !string.IsNullOrEmpty(collapsedText))
				{
					Text = collapsedText;
				}
				else
				{
					Text = expandedText;
				}
			}
		}
	}
}
#endif