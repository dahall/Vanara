/*
 * Copyright © 2015 David Hall
 *
 * Design Notes:-
 * --------------
 * TableLayoutPanels are the containers to hold the sub sections
 * (FlowLayoutPanels), while the FlowLayoutPanels holds and performs the layout
 * of the controls:
 *
 * - Main area (tableLayoutPanelMainArea):
 *   + Main icon (pictureBoxMainIcon).
 *   + Main information (flowLayoutPanelMainAreaControls).
 *   + Content (flowLayoutPanelMainAreaControls).
 *   + Expanded information (flowLayoutPanelMainAreaControls).
 *   + Progressbar (flowLayoutPanelMainAreaControls).
 *   + Radio buttons (flowLayoutPanelMainAreaControls).
 *   + Command links. (flowLayoutPanelMainAreaControls).
 * - Sub area (tableLayoutPanelSubArea).
 *   + Expand/Collapse button (flowLayoutPanelSubAreaControls).
 *   + Verification checkbox (flowLayoutPanelSubAreaControls).
 *   + Custom/Common buttons (flowLayoutPanelsSubAreaButtons).
 * - Footer area (tableLayoutPanelFooterArea).
 *   + Footer text (flowLayoutFooterAreaText).
 * - Footer expanded information (flowLayoutFooterExpandedInformationArea).
 *   + Expanded information (flowLayoutPanelFooterExpandedInformationAreaText).
 *
 * Limitations:
 * - Form issues:
 *   + No form icon when TaskDialog.CanBeMinimized is true.
 *     * Note: .Net does not provide an easy way to convert bitmap to icon.
 *   + Might not support right to left layouts.
 *   + "Retry" button will be added in a wrong order.
 *   + Command links has no accelerator key support.
 *     * Note: CommandLink class draws the text instead of letting the button
 *       handle the text.
 *
 * References:
 * - http://www.codeproject.com/KB/vista/Vista_TaskDialog_Wrapper.aspx
 * - http://www.codeproject.com/Articles/21276/Vista-TaskDialog-Wrapper-and-Emulator
 * - http://www.codeproject.com/Articles/17026/TaskDialog-for-WinForms
 *
 * Revision Control:-
 * ------------------
 * Created On: 2007 November 26
 * Major updates: 2015 Nov 6
 */

#if TASKDIALOG_EMULATE
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Vanara.PInvoke;
using static Vanara.PInvoke;
using static Vanara.PInvoke;

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// Tries to emulate the Task Dialog. Form will be called when the call to
	/// Task Dialog is not supported.
	/// </summary>
	internal class EmulateTaskDialog : Form
	{
		private const int hPadding = 10;
		private System.ComponentModel.IContainer components;
		private Button defaultButton;
		private RadioButton defaultRadioButton;
		private EmulateExpInfoButton expandedInfoButton;
		private FlowLayoutPanel flowLayoutPanelFooterAreaText;
		private FlowLayoutPanel flowLayoutPanelFooterExpandedInformationText;
		private FlowLayoutPanel flowLayoutPanelMainAreaControls;
		private FlowLayoutPanel flowLayoutPanelSubAreaButtons;
		private FlowLayoutPanel flowLayoutPanelSubAreaControls;
		private bool isExpanded = true;
		private LinkLabel linkLabelExpandedInformation;
		private PictureBox pictureBoxFooterAreaIcon;
		private PictureBox pictureBoxMainAreaIcon;
		private ProgressBar progressBar;
		private Panel tableLayoutPanel1;
		private Panel tableLayoutPanel2;
		private Panel tableLayoutPanel3;
		private Panel tableLayoutPanel4;
		private TableLayoutPanel tableLayoutPanelFooterArea;
		private TableLayoutPanel tableLayoutPanelFooterExpandedInformationArea;
		private TableLayoutPanel tableLayoutPanelMainArea;
		private TableLayoutPanel tableLayoutPanelSubArea;
		private readonly TaskDialog taskDialog;
		private readonly Dictionary<int, Button> taskDialogButtons = new Dictionary<int, Button>();
		private Timer timer;
		private uint timerTickCount;

		public EmulateTaskDialog(TaskDialog newTaskDialog)
		{
			// http://dotnetperls.com/Content/Segoe-Tahoma-Windows-Forms.aspx
			// http://www.codeproject.com/KB/cs/AdjustingFontAndLayout.aspx
			// For some discussion about setting program fonts.
			Font = SystemFonts.MessageBoxFont;

			InitializeComponent();

			taskDialog = newTaskDialog;

			Reset();
		}

		public int TaskDialogRadioButtonResult { get; private set; }

		public int TaskDialogResult { get; private set; }

		public bool TaskDialogVerificationFlagChecked { get; private set; }

		/// <summary>
		/// This will return the formatted contents of the form. Useful when
		/// the user press "ctrl + c" on the form.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.AppendLine("[Window Title]");
			sb.AppendLine(Text);

			if (!string.IsNullOrEmpty(taskDialog.MainInstruction))
			{
				sb.AppendLine("");
				sb.AppendLine("[Main Instruction]");
				sb.AppendLine(taskDialog.MainInstruction);
			}

			if (!string.IsNullOrEmpty(taskDialog.Content))
			{
				sb.AppendLine("");
				sb.AppendLine("[Content]");
				sb.AppendLine(taskDialog.Content);
			}

			if (!string.IsNullOrEmpty(taskDialog.ExpandedInformation) && !taskDialog.ExpandFooterArea)
			{
				sb.AppendLine("");
				sb.AppendLine("[Expanded Information]");
				sb.AppendLine(taskDialog.ExpandedInformation);
			}

			// There should be a max of two controls here.
			foreach (Control control in flowLayoutPanelSubAreaControls.Controls)
			{
				if (control is EmulateExpInfoButton)
				{
					// Should be the expand/collapse button.
					sb.AppendLine("");
					sb.Append((isExpanded ? "[^] " : "[v] "));
					sb.Append(control.Text);
					sb.Append("  ");
				}

				var box = control as CheckBox;
				if (box == null) continue;
				sb.Append(box.Checked ? "[X] " : "[ ] ");
				sb.Append(control.Text);
				sb.Append("  ");
			}

			// Should contains only buttons. As the layout direction is right
			// to left, need to get by reverse order. Dictionary does not keep
			// the order of buttons added in. So this work around is used.
			for (var i = flowLayoutPanelSubAreaButtons.Controls.Count - 1; i >= 0; i--)
			{
				var control = flowLayoutPanelSubAreaButtons.Controls[i];
				if (!(control is Button)) continue;
				sb.Append("[" + control.Text + "]");
				sb.Append(" ");
			}

			sb.AppendLine("");

			if (!string.IsNullOrEmpty(taskDialog.Footer))
			{
				sb.AppendLine("");
				sb.AppendLine("[Footer]");
				sb.AppendLine(taskDialog.Footer);
			}

			if (!string.IsNullOrEmpty(taskDialog.ExpandedInformation) && taskDialog.ExpandFooterArea)
			{
				sb.AppendLine("");
				sb.AppendLine("[Expanded Information]");
				sb.AppendLine(taskDialog.ExpandedInformation);
			}

			return sb.ToString();
		}

		internal void EnableButton(int buttonId, bool enable)
		{
			Button btn;
			if (taskDialogButtons.TryGetValue(buttonId, out btn))
			{
				btn.Enabled = enable;
				btn.Invalidate();
			}
		}

		internal void EnableRadioButton(int buttonId, bool enable)
		{
			foreach (var c in flowLayoutPanelMainAreaControls.Controls)
			{
				var r = c as RadioButton;
				if (r != null && int.Equals(r.Tag, buttonId))
				{
					r.Enabled = enable;
					r.Invalidate();
				}
			}
		}

		internal void PerformButtonClick(int buttonId)
		{
			Button btn;
			if (taskDialogButtons.TryGetValue(buttonId, out btn))
				btn.PerformClick();
		}

		internal void PerformRadioButtonClick(int buttonId)
		{
			foreach (var c in flowLayoutPanelMainAreaControls.Controls)
			{
				var r = c as RadioButton;
				if (r != null && int.Equals(r.Tag, buttonId))
					r.PerformClick();
			}
		}

		internal void PerformVerificationClick(bool checkedState, bool setKeyboardFocusToCheckBox)
		{
			if (flowLayoutPanelSubAreaControls.Controls.ContainsKey("VerificationText"))
			{
				var cb = (CheckBox)flowLayoutPanelSubAreaControls.Controls["VerificationText"];
				cb.Checked = checkedState;
				if (setKeyboardFocusToCheckBox)
					cb.Focus();
			}
		}

		internal void SetButtonElevationRequiredState(int buttonId, bool required)
		{
			Button btn;
			if (taskDialogButtons.TryGetValue(buttonId, out btn))
			{
				var link = btn as CommandLink;
				if (link != null)
				{
					link.ShowShield = required;
				}
				else if (Environment.OSVersion.Version.Major >= 6)
				{
					btn.FlatStyle = required ? FlatStyle.System : FlatStyle.Standard;
					SendMessage(new HandleRef(btn, btn.Handle), (int)ButtonMessage.BCM_SETSHIELD, 0, required ? 1 : 0);
				}
				btn.Invalidate();
			}
		}

		internal void SetCommonIcon(TaskDialogIconElement elem, TaskDialogIcon icon)
		{
			switch (elem)
			{
				case TaskDialogIconElement.TDIE_ICON_MAIN:
					SetMainIcon(icon);
					break;

				case TaskDialogIconElement.TDIE_ICON_FOOTER:
					SetFooterIcon(icon);
					break;

				default:
					return;
			}
			Invalidate();
		}

		internal void SetElementText(TaskDialogElement elem, string text)
		{
			switch (elem)
			{
				case TaskDialogElement.TDE_CONTENT:
					if (flowLayoutPanelMainAreaControls.Controls.ContainsKey("Content"))
						flowLayoutPanelMainAreaControls.Controls["Content"].Text = text;
					break;

				case TaskDialogElement.TDE_EXPANDED_INFORMATION:
					if (flowLayoutPanelMainAreaControls.Controls.ContainsKey("ExpandedInformation"))
						flowLayoutPanelMainAreaControls.Controls["ExpandedInformation"].Text = text;
					if (flowLayoutPanelFooterExpandedInformationText.Controls.ContainsKey("ExpandedInformation"))
						flowLayoutPanelFooterExpandedInformationText.Controls["ExpandedInformation"].Text = text;
					break;

				case TaskDialogElement.TDE_FOOTER:
					if (flowLayoutPanelFooterAreaText.Controls.ContainsKey("Footer"))
						flowLayoutPanelFooterAreaText.Controls["Footer"].Text = text;
					break;

				case TaskDialogElement.TDE_MAIN_INSTRUCTION:
					if (flowLayoutPanelMainAreaControls.Controls.ContainsKey("MainInstruction"))
						flowLayoutPanelMainAreaControls.Controls["MainInstruction"].Text = text;
					break;

				default:
					return;
			}
			Invalidate();
		}

		internal void SetIcon(TaskDialogIconElement elem, Icon icon)
		{
			switch (elem)
			{
				case TaskDialogIconElement.TDIE_ICON_MAIN:
					SetMainIcon(icon);
					break;

				case TaskDialogIconElement.TDIE_ICON_FOOTER:
					SetFooterIcon(icon);
					break;

				default:
					return;
			}
			Invalidate();
		}

		internal void SetMarqueeProgressBar(bool v)
		{
			if (progressBar != null)
			{
				progressBar.Style = v ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
				progressBar.Invalidate();
			}
		}

		internal void SetProgressBarRange(int min, int max)
		{
			if (progressBar != null)
			{
				progressBar.Minimum = min;
				progressBar.Maximum = max;
				progressBar.Invalidate();
			}
		}

		internal void SetProgressBarState(ProgressBarState value)
		{
			if (progressBar != null && Environment.OSVersion.Version.Major >= 6)
			{
				const uint PBM_SETSTATE = 1040;
				SendMessage(new HandleRef(progressBar, progressBar.Handle), PBM_SETSTATE, (int)value, 0);
				progressBar.Invalidate();
			}
		}

		internal void SetProgressBarValue(int value)
		{
			if (progressBar == null) return;
			progressBar.Value = value;
			progressBar.Invalidate();
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

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			taskDialog.OnClosed();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (taskDialog.AllowDialogCancellation && e.KeyCode == Keys.Escape)
			{
				CloseForm();
				e.Handled = true;
			}
			base.OnKeyDown(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			taskDialog.InitializeButtonState();
			taskDialog.ProgressBar.Initialize();
			taskDialog.OnLoad();
		}

		protected override void WndProc(ref Message m)
		{
			if (Enum.IsDefined(typeof(TaskDialogMessage), (uint)m.Msg))
			{
				switch ((TaskDialogMessage)m.Msg)
				{
					case TaskDialogMessage.TDM_CLICK_BUTTON:
						PerformButtonClick(m.WParam.ToInt32());
						break;

					case TaskDialogMessage.TDM_SET_MARQUEE_PROGRESS_BAR:
						SetMarqueeProgressBar(m.WParam.ToInt32() == 1);
						break;

					case TaskDialogMessage.TDM_SET_PROGRESS_BAR_STATE:
						SetProgressBarState((ProgressBarState)m.WParam.ToInt32());
						break;

					case TaskDialogMessage.TDM_SET_PROGRESS_BAR_RANGE:
						var ab = unchecked(IntPtr.Size == 8 ? (uint)m.LParam.ToInt64() : (uint)m.LParam.ToInt32());
						int a = unchecked((short)ab);
						int b = unchecked((short)(ab >> 16));
						SetProgressBarRange(a, b);
						break;

					case TaskDialogMessage.TDM_SET_PROGRESS_BAR_POS:
						SetProgressBarValue(m.WParam.ToInt32());
						break;

					case TaskDialogMessage.TDM_SET_PROGRESS_BAR_MARQUEE:
						SetProgressBarValue(m.LParam.ToInt32());
						break;

					case TaskDialogMessage.TDM_SET_ELEMENT_TEXT:
					case TaskDialogMessage.TDM_UPDATE_ELEMENT_TEXT:
						SetElementText((TaskDialogElement)m.WParam.ToInt32(), Marshal.PtrToStringAuto(m.LParam));
						break;

					case TaskDialogMessage.TDM_CLICK_RADIO_BUTTON:
						PerformRadioButtonClick(m.WParam.ToInt32());
						break;

					case TaskDialogMessage.TDM_ENABLE_BUTTON:
						EnableButton(m.WParam.ToInt32(), m.LParam.ToInt32() == 1);
						break;

					case TaskDialogMessage.TDM_ENABLE_RADIO_BUTTON:
						EnableRadioButton(m.WParam.ToInt32(), m.LParam.ToInt32() == 1);
						break;

					case TaskDialogMessage.TDM_CLICK_VERIFICATION:
						PerformVerificationClick(m.WParam.ToInt32() == 1, m.LParam.ToInt32() == 1);
						break;

					case TaskDialogMessage.TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE:
						SetButtonElevationRequiredState(m.WParam.ToInt32(), m.LParam.ToInt32() == 1);
						break;

					case TaskDialogMessage.TDM_UPDATE_ICON:
						if (Enum.IsDefined(typeof(TaskDialogIcon), m.LParam.ToInt32()))
							SetCommonIcon((TaskDialogIconElement)m.WParam.ToInt32(), (TaskDialogIcon)m.LParam.ToInt32());
						else
							SetIcon((TaskDialogIconElement)m.WParam.ToInt32(), Icon.FromHandle(m.LParam));
						break;
				}
			}

			base.WndProc(ref m);
		}

		/// <summary>
		/// Creates a standard button with a common event handler to close the
		/// the form and return the button's Id.
		/// </summary>
		/// <param name="tag">The button's Id.</param>
		/// <param name="text">The button's name.</param>
		/// <returns></returns>
		private Button BuildControlButton(int tag, string text)
		{
			var button = new Button { Tag = tag, Text = text, Margin = new Padding(7, 0, 0, 7) };
			button.Width -= 5;
			button.Click += button_Click;

			taskDialogButtons.Add(tag, button);

			return button;
		}

		/// <summary>
		/// Creates a standard link label and will convert any anchor links to
		/// a proper link.
		/// </summary>
		/// <param name="margin">The margin of the link label.</param>
		/// <param name="text">The text of the link label.</param>
		/// <param name="name">The name assigned to the label.</param>
		/// <returns>A <see cref="LinkLabel"/> matching the parameters.</returns>
		private LinkLabel BuildControlLinkLabel(Padding margin, string text, string name)
		{
			var linkLabel = new LinkLabel
			{
				AutoSize = true,
				Font = new Font(Font.FontFamily, 9),
				LinkArea = new LinkArea(),
				Margin = margin,
				Name = name,
				Text = text
			};
			linkLabel.LinkClicked += linkLabel_LinkClicked;

			if (taskDialog.EnableHyperlinks)
			{
				linkLabel = ParseLinkLabel(linkLabel);
			}

			return linkLabel;
		}

		/// <summary>
		/// Main entry method to build the form.
		/// </summary>
		private void BuildForm()
		{
			ControlBox = taskDialog.AllowDialogCancellation;
			if ((MinimizeBox = taskDialog.CanBeMinimized) == true)
			{
				// If can be minimized, ControlBox must be enabled.
				ControlBox = true;
				ShowInTaskbar = true;

				// TODO: Form icon will be the TaskDialog.MainIcon. Problem is .Net framework does not provide a way to generate an icon.
			}
			StartPosition = taskDialog.PositionRelativeToWindow ? FormStartPosition.CenterParent : FormStartPosition.CenterScreen;
			Text = string.IsNullOrEmpty(taskDialog.WindowTitle) ? "" : taskDialog.WindowTitle;

			BuildFormMainArea();
			BuildFormFooterArea();
			// Build the sub area last because of the possibility of having the expanded information
			// in the footer. Then building the "expand/collapse" button will be accurate.
			BuildFormSubArea();

			SetFormHeight();
		}

		private void BuildFormFooterArea()
		{
			if (!string.IsNullOrEmpty(taskDialog.Footer))
			{
				if (taskDialog.CustomFooterIcon != null)
					SetFooterIcon(taskDialog.CustomFooterIcon);
				else
					SetFooterIcon(taskDialog.FooterIcon);

				flowLayoutPanelFooterAreaText.Controls.Add(BuildControlLinkLabel(new Padding(0, 0, 0, 11), taskDialog.Footer, "Footer"));
			}
			else
			{
				tableLayoutPanelFooterArea.AutoSize = false;
				tableLayoutPanelFooterArea.Height = 0;
				tableLayoutPanelFooterArea.Visible = false;

				tableLayoutPanel2.Height = 0;
				tableLayoutPanel2.Visible = false;
			}

			if (taskDialog.ExpandFooterArea && !string.IsNullOrEmpty(taskDialog.ExpandedInformation))
			{
				linkLabelExpandedInformation = BuildControlLinkLabel(new Padding(0), taskDialog.ExpandedInformation, "ExpandedInformation");

				flowLayoutPanelFooterExpandedInformationText.Controls.Add(linkLabelExpandedInformation);

				if (!taskDialog.ExpandedByDefault)
				{
					ToggleExpandedInformationState();
				}
			}
			else
			{
				flowLayoutPanelFooterExpandedInformationText.AutoSize = false;
				flowLayoutPanelFooterExpandedInformationText.Height = 0;
				tableLayoutPanelFooterExpandedInformationArea.Visible = false;

				tableLayoutPanel3.Height = tableLayoutPanel4.Height = 0;
				tableLayoutPanel3.Visible = tableLayoutPanel4.Visible = false;
			}
		}

		private void BuildFormMainArea()
		{
			var colorBg = Color.White;
			var colorFg = Color.FromArgb(0, 0, 51, 153);

			// Main icon
			if (taskDialog.CustomMainIcon != null)
				SetMainIcon(taskDialog.CustomMainIcon);
			else
			{
				SetMainIcon(taskDialog.MainIcon);
				switch (taskDialog.MainIcon)
				{
					case TaskDialogIcon.SecurityError:
						colorFg = Color.White;
						colorBg = Color.FromArgb(199, 1, 0);
						break;
					case TaskDialogIcon.SecurityWarning:
						colorFg = Color.Black;
						colorBg = Color.FromArgb(248, 191, 35);
						break;
					case TaskDialogIcon.SecuritySuccess:
						colorFg = Color.White;
						colorBg = Color.FromArgb(38, 134, 41);
						break;
					case TaskDialogIcon.ShieldBlue:
						colorFg = Color.White;
						colorBg = Color.FromArgb(16, 100, 131);
						break;
					case TaskDialogIcon.ShieldGray:
						colorFg = Color.White;
						colorBg = Color.FromArgb(160, 147, 138);
						break;
				}
			}

			// Main instruction
			if (!string.IsNullOrEmpty(taskDialog.MainInstruction))
			{
				var label = new Label
				{
					AutoSize = true,
					Name = "MainInstruction",
					Text = taskDialog.MainInstruction,
					Font = new Font(Font.FontFamily, 12),
					ForeColor = colorFg,
					Margin = new Padding(0, 0, 0, hPadding)
				};

				flowLayoutPanelMainAreaControls.Controls.Add(label);
				tableLayoutPanelMainArea.BackColor = colorBg;
			}

			// Content
			if (!string.IsNullOrEmpty(taskDialog.Content))
			{
				flowLayoutPanelMainAreaControls.Controls.Add(BuildControlLinkLabel(new Padding(0, 0, 0, hPadding), taskDialog.Content, "Content"));
			}

			// Expanded info
			if (!string.IsNullOrEmpty(taskDialog.ExpandedInformation) && !taskDialog.ExpandFooterArea)
			{
				linkLabelExpandedInformation = BuildControlLinkLabel(new Padding(0, 0, 0, hPadding), taskDialog.ExpandedInformation, "ExpandedInformation");

				flowLayoutPanelMainAreaControls.Controls.Add(linkLabelExpandedInformation);

				if (!taskDialog.ExpandedByDefault)
				{
					ToggleExpandedInformationState();
				}
			}

			// ProgressBar
			if (taskDialog.ShowProgressBar || taskDialog.ShowMarqueeProgressBar)
			{
				progressBar = new ProgressBar
				{
					Margin = new Padding(2, 0, 0, hPadding),
					Size = new Size(flowLayoutPanelMainAreaControls.Width - 6, 15)
				};
				if (taskDialog.ShowMarqueeProgressBar)
					progressBar.Style = ProgressBarStyle.Marquee;

				flowLayoutPanelMainAreaControls.Controls.Add(progressBar);
			}

			// Radio buttons
			for (var i = 0; i < taskDialog.RadioButtons.Count; i++)
			{
				var radioButton = new RadioButton
				{
					Text = taskDialog.RadioButtons[i].ButtonText,
					Tag = taskDialog.RadioButtons[i].ButtonId,
					AutoSize = true,
					Margin = new Padding(14, 0, 0, i == (taskDialog.RadioButtons.Count - 1) ? hPadding : 3)
				};
				radioButton.Click += radioButton_Click;
				// Select the first radio button by default.
				if ((i == 0) || (taskDialog.DefaultRadioButton == taskDialog.RadioButtons[i].ButtonId))
					defaultRadioButton = radioButton;

				flowLayoutPanelMainAreaControls.Controls.Add(radioButton);
			}

			// Command links
			if (taskDialog.UseCommandLinks)
			{
				foreach (var t in taskDialog.Buttons)
				{
					var cmdLink = new CommandLink
					{
						Tag = t.ButtonId,
						Text = t.ButtonText,
						Margin = new Padding(1, 0, 0, 1)
					};
					cmdLink.Size = cmdLink.GetPreferredSize(new Size(flowLayoutPanelMainAreaControls.Width - 10, 0));
					cmdLink.Click += button_Click;

					taskDialogButtons.Add(t.ButtonId, cmdLink);

					flowLayoutPanelMainAreaControls.Controls.Add(cmdLink);
				}
			}
		}

		private void BuildFormSubArea()
		{
			// --------------- Left side of the sub control area. ---------------
			// Check if there is any expanded information first.
			if (!string.IsNullOrEmpty(taskDialog.ExpandedInformation))
			{
				expandedInfoButton = new EmulateExpInfoButton(isExpanded, taskDialog.ExpandedControlText,
					taskDialog.CollapsedControlText) {Margin = Padding.Empty};
				expandedInfoButton.Click += expandedInfoButton_Click;

				flowLayoutPanelSubAreaControls.Controls.Add(expandedInfoButton);
				// Smallest element in this area.
				tableLayoutPanelSubArea.MinimumSize = new Size(0, 33);
			}

			if (!string.IsNullOrEmpty(taskDialog.VerificationText))
			{
				var checkBox = new CheckBox
				{
					Checked = taskDialog.VerificationFlagChecked,
					Margin = new Padding(3, 3, 0, 0),
					MaximumSize = new Size(165, 0),
					Name = "VerificationText",
					Text = taskDialog.VerificationText,
					Width = 165
				};

				checkBox.Click += verificationCheckBox_Click;

				// AdjustControls doesn't take in account the checkbox, so need
				// to work around it.
				var size = AdjustControls.GetBestSize(checkBox, checkBox.Text, new Rectangle(0, 0, checkBox.Width - 52, checkBox.Height));
				checkBox.Height = size.Height + 6;

				flowLayoutPanelSubAreaControls.Controls.Add(checkBox);
			}

			// --------------- Right side of the sub control area. ---------------
			var commBtns = taskDialog.CommonButtons;

			// If there is no button, by default there will be an "Okay" button.
			if (commBtns == TaskDialogCommonButtons.None && taskDialog.Buttons.Count == 0)
				commBtns = TaskDialogCommonButtons.Ok;

			var requiredTotalButtonsWidth = 0;

			var commonButtons = (TaskDialogCommonButtons[])Enum.GetValues(typeof(TaskDialogCommonButtons));

			// Iterate through all the common buttons. Get by reverse order
			// as the layout direction is right to left.
			for (var i = commonButtons.Length - 1; i >= 0; i--)
			{
				// There is no "None" button.
				if (!commonButtons[i].Equals(TaskDialogCommonButtons.None))
				{
					// Now to check which button is needed.
					if ((commBtns & commonButtons[i]).Equals(commonButtons[i]))
					{
						// TaskDialogCommonButtons enums is not the same as DialogResult enums. Need
						// to use another way of getting the correct DialogResult value.
						Button button;

						// DialogResult does not contain a "Close" enum, return value by TaskDialog is int 8.
						if (commonButtons[i].Equals(TaskDialogCommonButtons.Close))
						{
							button = BuildControlButton(8, TaskDialogCommonButtons.Close.ToString());
						}
						// No "Ok" button. Is it a typo for TaskDialogCommonButtons in TaskDialog.cs?
						else if (commonButtons[i].Equals(TaskDialogCommonButtons.Ok))
						{
							button = BuildControlButton((int)DialogResult.OK, DialogResult.OK.ToString());
						}
						else
						{
							var result = (DialogResult)Enum.Parse(typeof(DialogResult), commonButtons[i].ToString());
							button = BuildControlButton((int)result, result.ToString());
						}

						button.TabIndex = i + taskDialog.Buttons.Count;

						flowLayoutPanelSubAreaButtons.Controls.Add(button);

						requiredTotalButtonsWidth += button.Width + button.Margin.Left + button.Margin.Right;
					}
				}
			}

			// Custom buttons. Get by reverse order as the layout direction
			// is right to left.
			if (!taskDialog.UseCommandLinks)
			{
				for (var i = taskDialog.Buttons.Count - 1; i >= 0; i--)
				{
					var button = BuildControlButton(taskDialog.Buttons[i].ButtonId, taskDialog.Buttons[i].ButtonText);
					flowLayoutPanelSubAreaButtons.Controls.Add(button);

					button.TabIndex = i;

					requiredTotalButtonsWidth += button.Width + button.Margin.Left + button.Margin.Right;
				}
			}

			// Check if there is anything in the sub area.
			if ((requiredTotalButtonsWidth == 0) && (string.IsNullOrEmpty(taskDialog.ExpandedInformation)) && (string.IsNullOrEmpty(taskDialog.VerificationText)))
			{
				tableLayoutPanel1.Visible = false;
				tableLayoutPanel1.Height = 0;
				tableLayoutPanelSubArea.Visible = false;
			}
			else
			{
				// Padding on the right.
				requiredTotalButtonsWidth += 15;

				if (requiredTotalButtonsWidth > flowLayoutPanelSubAreaButtons.Width)
				{
					Width += requiredTotalButtonsWidth - flowLayoutPanelSubAreaButtons.Width;
				}
			}
		}

		private void button_Click(object sender, EventArgs e)
		{
			var id = (int)((Button)sender).Tag;
			if (taskDialog.OnButtonClicked(id))
				return;

			TaskDialogResult = id;
			CloseForm();
		}

		/// <summary>
		/// Closes the form and populate the necessary return results.
		/// </summary>
		private void CloseForm()
		{
			if (taskDialog.RadioButtons.Count > 0)
			{
				// Check all the radio buttons.
				foreach (Control control in flowLayoutPanelMainAreaControls.Controls)
				{
					var button = control as RadioButton;
					if (button == null) continue;
					var radioButton = button;
					if (!radioButton.Checked) continue;
					TaskDialogRadioButtonResult = (int)radioButton.Tag;
					break;
				}
			}

			if (!string.IsNullOrEmpty(taskDialog.VerificationText))
			{
				foreach (Control control in flowLayoutPanelSubAreaControls.Controls)
				{
					var box = control as CheckBox;
					if (box == null) continue;
					TaskDialogVerificationFlagChecked = box.Checked;
					break;
				}
			}

			timer.Stop();

			Close();
		}

		/// <summary>
		/// Detect user pressing "ctrl + c".
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EmulateTaskDialog_KeyDown(object sender, KeyEventArgs e)
		{
			var notWanted = Keys.Alt | Keys.Shift;

			if ((e.Modifiers & notWanted) == 0)
			{
				if ((e.Modifiers & Keys.Control) == Keys.Control)
				{
					if (e.KeyCode.Equals(Keys.C))
					{
						Clipboard.SetText(ToString());
					}
				}
			}
		}

		private void expandedInfoButton_Click(object sender, EventArgs e)
		{
			ToggleExpandedInformationState();

			expandedInfoButton.ToogleState();

			SetFormHeight();

			taskDialog.OnExpanded(isExpanded);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			tableLayoutPanelMainArea = new TableLayoutPanel();
			flowLayoutPanelMainAreaControls = new FlowLayoutPanel();
			pictureBoxMainAreaIcon = new PictureBox();
			tableLayoutPanel1 = new Panel();
			tableLayoutPanelSubArea = new TableLayoutPanel();
			flowLayoutPanelSubAreaButtons = new FlowLayoutPanel();
			flowLayoutPanelSubAreaControls = new FlowLayoutPanel();
			tableLayoutPanelFooterArea = new TableLayoutPanel();
			pictureBoxFooterAreaIcon = new PictureBox();
			flowLayoutPanelFooterAreaText = new FlowLayoutPanel();
			tableLayoutPanel2 = new Panel();
			tableLayoutPanel3 = new Panel();
			tableLayoutPanel4 = new Panel();
			tableLayoutPanelFooterExpandedInformationArea = new TableLayoutPanel();
			flowLayoutPanelFooterExpandedInformationText = new FlowLayoutPanel();
			timer = new Timer(components);
			tableLayoutPanelMainArea.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pictureBoxMainAreaIcon)).BeginInit();
			tableLayoutPanelSubArea.SuspendLayout();
			tableLayoutPanelFooterArea.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pictureBoxFooterAreaIcon)).BeginInit();
			tableLayoutPanelFooterExpandedInformationArea.SuspendLayout();
			SuspendLayout();
			//
			// tableLayoutPanelMainArea
			//
			tableLayoutPanelMainArea.AutoSize = true;
			tableLayoutPanelMainArea.BackColor = Color.White;
			tableLayoutPanelMainArea.ColumnCount = 2;
			tableLayoutPanelMainArea.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
			tableLayoutPanelMainArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanelMainArea.Controls.Add(flowLayoutPanelMainAreaControls, 1, 0);
			tableLayoutPanelMainArea.Controls.Add(pictureBoxMainAreaIcon, 0, 0);
			tableLayoutPanelMainArea.Dock = DockStyle.Top;
			tableLayoutPanelMainArea.Location = new Point(0, 0);
			tableLayoutPanelMainArea.Margin = new Padding(0);
			tableLayoutPanelMainArea.MinimumSize = new Size(0, 52);
			tableLayoutPanelMainArea.Name = "tableLayoutPanelMainArea";
			tableLayoutPanelMainArea.Padding = new Padding(10);
			tableLayoutPanelMainArea.RowCount = 1;
			tableLayoutPanelMainArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanelMainArea.Size = new Size(460, 52);
			tableLayoutPanelMainArea.TabIndex = 0;
			//
			// flowLayoutPanelMainAreaControls
			//
			flowLayoutPanelMainAreaControls.AutoSize = true;
			flowLayoutPanelMainAreaControls.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanelMainAreaControls.Dock = DockStyle.Fill;
			flowLayoutPanelMainAreaControls.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanelMainAreaControls.Location = new Point(42, 10);
			flowLayoutPanelMainAreaControls.Margin = new Padding(0);
			flowLayoutPanelMainAreaControls.Name = "flowLayoutPanelMainAreaControls";
			flowLayoutPanelMainAreaControls.Size = new Size(408, 32);
			flowLayoutPanelMainAreaControls.TabIndex = 0;
			//
			// pictureBoxMainAreaIcon
			//
			pictureBoxMainAreaIcon.Location = new Point(10, 10);
			pictureBoxMainAreaIcon.Margin = new Padding(0);
			pictureBoxMainAreaIcon.Name = "pictureBoxMainAreaIcon";
			pictureBoxMainAreaIcon.Size = new Size(32, 32);
			pictureBoxMainAreaIcon.TabIndex = 1;
			pictureBoxMainAreaIcon.TabStop = false;
			//
			// tableLayoutPanel1
			//
			tableLayoutPanel1.BackColor = SystemColors.ControlLight;
			tableLayoutPanel1.Dock = DockStyle.Top;
			tableLayoutPanel1.Location = new Point(0, 52);
			tableLayoutPanel1.Margin = new Padding(0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.Size = new Size(460, 1);
			tableLayoutPanel1.TabIndex = 1;
			//
			// tableLayoutPanelSubArea
			//
			tableLayoutPanelSubArea.AutoSize = true;
			tableLayoutPanelSubArea.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanelSubArea.BackColor = SystemColors.ButtonFace;
			tableLayoutPanelSubArea.ColumnCount = 2;
			tableLayoutPanelSubArea.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
			tableLayoutPanelSubArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanelSubArea.Controls.Add(flowLayoutPanelSubAreaButtons, 1, 0);
			tableLayoutPanelSubArea.Controls.Add(flowLayoutPanelSubAreaControls, 0, 0);
			tableLayoutPanelSubArea.Dock = DockStyle.Top;
			tableLayoutPanelSubArea.Location = new Point(0, 53);
			tableLayoutPanelSubArea.Margin = new Padding(0);
			tableLayoutPanelSubArea.MinimumSize = new Size(0, 33);
			tableLayoutPanelSubArea.Name = "tableLayoutPanelSubArea";
			tableLayoutPanelSubArea.Padding = new Padding(10, 9, 10, 9);
			tableLayoutPanelSubArea.RowCount = 1;
			tableLayoutPanelSubArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanelSubArea.Size = new Size(460, 33);
			tableLayoutPanelSubArea.TabIndex = 1;
			//
			// flowLayoutPanelSubAreaButtons
			//
			flowLayoutPanelSubAreaButtons.AutoSize = true;
			flowLayoutPanelSubAreaButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanelSubAreaButtons.Dock = DockStyle.Fill;
			flowLayoutPanelSubAreaButtons.FlowDirection = FlowDirection.RightToLeft;
			flowLayoutPanelSubAreaButtons.Location = new Point(185, 9);
			flowLayoutPanelSubAreaButtons.Margin = new Padding(0);
			flowLayoutPanelSubAreaButtons.Name = "flowLayoutPanelSubAreaButtons";
			flowLayoutPanelSubAreaButtons.Size = new Size(265, 15);
			flowLayoutPanelSubAreaButtons.TabIndex = 1;
			flowLayoutPanelSubAreaButtons.WrapContents = false;
			//
			// flowLayoutPanelSubAreaControls
			//
			flowLayoutPanelSubAreaControls.AutoSize = true;
			flowLayoutPanelSubAreaControls.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanelSubAreaControls.Dock = DockStyle.Fill;
			flowLayoutPanelSubAreaControls.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanelSubAreaControls.Location = new Point(10, 9);
			flowLayoutPanelSubAreaControls.Margin = new Padding(0);
			flowLayoutPanelSubAreaControls.Name = "flowLayoutPanelSubAreaControls";
			flowLayoutPanelSubAreaControls.Size = new Size(175, 15);
			flowLayoutPanelSubAreaControls.TabIndex = 0;
			//
			// tableLayoutPanelFooterArea
			//
			tableLayoutPanelFooterArea.AutoSize = true;
			tableLayoutPanelFooterArea.BackColor = SystemColors.Control;
			tableLayoutPanelFooterArea.ColumnCount = 2;
			tableLayoutPanelFooterArea.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 24F));
			tableLayoutPanelFooterArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanelFooterArea.Controls.Add(pictureBoxFooterAreaIcon, 0, 0);
			tableLayoutPanelFooterArea.Controls.Add(flowLayoutPanelFooterAreaText, 1, 0);
			tableLayoutPanelFooterArea.Dock = DockStyle.Top;
			tableLayoutPanelFooterArea.Location = new Point(0, 87);
			tableLayoutPanelFooterArea.Margin = new Padding(0);
			tableLayoutPanelFooterArea.Name = "tableLayoutPanelFooterArea";
			tableLayoutPanelFooterArea.Padding = new Padding(10, 10, 10, 0);
			tableLayoutPanelFooterArea.RowCount = 1;
			tableLayoutPanelFooterArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanelFooterArea.Size = new Size(460, 26);
			tableLayoutPanelFooterArea.TabIndex = 2;
			//
			// pictureBoxFooterAreaIcon
			//
			pictureBoxFooterAreaIcon.Location = new Point(10, 10);
			pictureBoxFooterAreaIcon.Margin = new Padding(0);
			pictureBoxFooterAreaIcon.Name = "pictureBoxFooterAreaIcon";
			pictureBoxFooterAreaIcon.Size = new Size(16, 16);
			pictureBoxFooterAreaIcon.TabIndex = 0;
			pictureBoxFooterAreaIcon.TabStop = false;
			//
			// flowLayoutPanelFooterAreaText
			//
			flowLayoutPanelFooterAreaText.AutoSize = true;
			flowLayoutPanelFooterAreaText.Dock = DockStyle.Fill;
			flowLayoutPanelFooterAreaText.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanelFooterAreaText.Location = new Point(34, 10);
			flowLayoutPanelFooterAreaText.Margin = new Padding(0);
			flowLayoutPanelFooterAreaText.Name = "flowLayoutPanelFooterAreaText";
			flowLayoutPanelFooterAreaText.Size = new Size(416, 16);
			flowLayoutPanelFooterAreaText.TabIndex = 1;
			//
			// tableLayoutPanel2
			//
			tableLayoutPanel2.BackColor = SystemColors.ControlLight;
			tableLayoutPanel2.Dock = DockStyle.Top;
			tableLayoutPanel2.Location = new Point(0, 86);
			tableLayoutPanel2.Margin = new Padding(0);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.Size = new Size(460, 1);
			tableLayoutPanel2.TabIndex = 4;
			//
			// tableLayoutPanel3
			//
			tableLayoutPanel3.BackColor = SystemColors.ControlLight;
			tableLayoutPanel3.Dock = DockStyle.Top;
			tableLayoutPanel3.Location = new Point(0, 113);
			tableLayoutPanel3.Margin = new Padding(0);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.Size = new Size(460, 1);
			tableLayoutPanel3.TabIndex = 7;
			//
			// tableLayoutPanel4
			//
			tableLayoutPanel4.BackColor = SystemColors.ControlLightLight;
			tableLayoutPanel4.Dock = DockStyle.Top;
			tableLayoutPanel4.Location = new Point(0, 114);
			tableLayoutPanel4.Margin = new Padding(0);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.Size = new Size(460, 1);
			tableLayoutPanel4.TabIndex = 8;
			//
			// tableLayoutPanelFooterExpandedInformationArea
			//
			tableLayoutPanelFooterExpandedInformationArea.AutoSize = true;
			tableLayoutPanelFooterExpandedInformationArea.BackColor = SystemColors.ButtonFace;
			tableLayoutPanelFooterExpandedInformationArea.ColumnCount = 1;
			tableLayoutPanelFooterExpandedInformationArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanelFooterExpandedInformationArea.Controls.Add(flowLayoutPanelFooterExpandedInformationText, 0, 0);
			tableLayoutPanelFooterExpandedInformationArea.Dock = DockStyle.Top;
			tableLayoutPanelFooterExpandedInformationArea.Location = new Point(0, 115);
			tableLayoutPanelFooterExpandedInformationArea.Margin = new Padding(0);
			tableLayoutPanelFooterExpandedInformationArea.Name = "tableLayoutPanelFooterExpandedInformationArea";
			tableLayoutPanelFooterExpandedInformationArea.Padding = new Padding(10, 10, 10, 0);
			tableLayoutPanelFooterExpandedInformationArea.RowCount = 1;
			tableLayoutPanelFooterExpandedInformationArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanelFooterExpandedInformationArea.Size = new Size(460, 10);
			tableLayoutPanelFooterExpandedInformationArea.TabIndex = 3;
			//
			// flowLayoutPanelFooterExpandedInformationText
			//
			flowLayoutPanelFooterExpandedInformationText.AutoSize = true;
			flowLayoutPanelFooterExpandedInformationText.Dock = DockStyle.Fill;
			flowLayoutPanelFooterExpandedInformationText.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanelFooterExpandedInformationText.Location = new Point(10, 10);
			flowLayoutPanelFooterExpandedInformationText.Margin = new Padding(0);
			flowLayoutPanelFooterExpandedInformationText.Name = "flowLayoutPanelFooterExpandedInformationText";
			flowLayoutPanelFooterExpandedInformationText.Size = new Size(440, 1);
			flowLayoutPanelFooterExpandedInformationText.TabIndex = 0;
			//
			// timer
			//
			timer.Tick += timer_Tick;
			//
			// EmulateTaskDialog
			//
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Control;
			ClientSize = new Size(360, 200);
			Controls.Add(tableLayoutPanelFooterExpandedInformationArea);
			Controls.Add(tableLayoutPanel4);
			Controls.Add(tableLayoutPanel3);
			Controls.Add(tableLayoutPanelFooterArea);
			Controls.Add(tableLayoutPanel2);
			Controls.Add(tableLayoutPanelSubArea);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(tableLayoutPanelMainArea);
			Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			KeyPreview = true;
			MaximizeBox = false;
			Name = "EmulateTaskDialog";
			ShowInTaskbar = false;
			Text = @"EmulateTaskDialog";
			KeyDown += EmulateTaskDialog_KeyDown;
			tableLayoutPanelMainArea.ResumeLayout(false);
			tableLayoutPanelMainArea.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(pictureBoxMainAreaIcon)).EndInit();
			tableLayoutPanelSubArea.ResumeLayout(false);
			tableLayoutPanelSubArea.PerformLayout();
			tableLayoutPanelFooterArea.ResumeLayout(false);
			tableLayoutPanelFooterArea.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(pictureBoxFooterAreaIcon)).EndInit();
			tableLayoutPanelFooterExpandedInformationArea.ResumeLayout(false);
			tableLayoutPanelFooterExpandedInformationArea.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			taskDialog.OnLinkClicked((string)e.Link.LinkData);
		}

		/// <summary>
		/// Parses a LinkLabel text and extract out all the anchor (a) tags.
		/// Then it will parse all the anchor tags and create the relevant
		/// links in the text.
		/// </summary>
		/// <param name="linkLabel"></param>
		/// <returns></returns>
		private LinkLabel ParseLinkLabel(LinkLabel linkLabel)
		{
			// Set up the text to parse.
			var text = linkLabel.Text;

			// Set up the regex for finding the link urls.
			var hrefPattern = new StringBuilder();
			// Start anchor tag and anything that comes before "href" tag.
			hrefPattern.Append("<a[^>]+");
			hrefPattern.Append("href\\s*=\\s*"); // Start href property.
												 // Three possibilities for "href":
												 // (1) enclosed in double quotes.
												 // (2) enclosed in single quotes.
												 // (3) enclosed in spaces.
			hrefPattern.Append("(?:\"(?<href>[^\"]*)\"|'(?<href>[^']*)'|(?<href>[^\"'>\\s]+))");
			// Grab the inner html too.
			hrefPattern.Append("[^>]*>(?<a>.*?)</a>"); // End of anchor tag.
			var hrefRegex = new Regex(hrefPattern.ToString(), RegexOptions.IgnoreCase);

			// Look for matches.
			var hrefCheck = hrefRegex.Match(text);

			while (hrefCheck.Success)
			{
				var href = hrefCheck.Groups["href"].Value;
				var innerText = hrefCheck.Groups["a"].Value;

				// Get the starting index of the anchor tag.
				var index = linkLabel.Text.IndexOf(hrefCheck.Value, StringComparison.Ordinal);
				// Replace it with the inner text, create a link and store the
				// link.
				linkLabel.Text = linkLabel.Text.Replace(hrefCheck.Value, innerText);
				linkLabel.Links.Add(index, innerText.Length, href);

				hrefCheck = hrefCheck.NextMatch();
			}

			return linkLabel;
		}

		private void radioButton_Click(object sender, EventArgs e)
		{
			var id = (int)((RadioButton)sender).Tag;
			taskDialog.OnRadioButtonClicked(id);
		}

		private void Reset()
		{
			BuildForm();

			// Setup the default settings.
			if (defaultRadioButton != null)
			{
				defaultRadioButton.Checked = true;
			}

			// Only can set focus after everything has been build.
			if (taskDialog.DefaultButton != 0)
			{
				// Set the default button.
				if (taskDialogButtons.TryGetValue(taskDialog.DefaultButton, out defaultButton))
				{
					defaultButton.Select();
				}
				else
				{
					if (flowLayoutPanelSubAreaButtons.Controls.Count > 0)
					{
						// Select left-most button.
						flowLayoutPanelSubAreaButtons.Controls[flowLayoutPanelSubAreaButtons.Controls.Count - 1].Select();
					}
				}
			}
			else
			{
				if (flowLayoutPanelSubAreaButtons.Controls.Count > 0)
				{
					// Set the left-most button to be the default. Dictionary does
					// not keep the order of the button that is added in, so this
					// work around is used.
					//
					// Layout right to left, left-most item is at the end of the list.
					flowLayoutPanelSubAreaButtons.Controls[flowLayoutPanelSubAreaButtons.Controls.Count - 1].Select();
				}
			}

			timer.Start();
		}

		private void SetFooterIcon(TaskDialogIcon icon)
		{
			SetFooterIcon(TaskDialog.IconFromTaskDialogIcon(icon));
		}

		private void SetFooterIcon(Icon icon)
		{
			pictureBoxFooterAreaIcon.Image = TaskDialog.GetSmallImage(icon);
			tableLayoutPanelFooterArea.ColumnStyles[0].Width = pictureBoxFooterAreaIcon.Image?.Width + 6 ?? 0;
		}

		private void SetFormHeight()
		{
			Height = (tableLayoutPanelMainArea.Height + 32)
				+ tableLayoutPanel1.Height // Separator.
										   // When empty, default height is 33. TableLayoutPanel refuses to
										   // shrink to 0 as there are items in it.
				+ ((tableLayoutPanelSubArea.Height > 33) ? tableLayoutPanelSubArea.Height : 0)
				+ tableLayoutPanel2.Height // Separator.
				+ ((tableLayoutPanelFooterArea.Height > 0) ? tableLayoutPanelFooterArea.Height : 0)
				+ tableLayoutPanel3.Height // Separator.
				+ tableLayoutPanel4.Height // Separator.
										   // When empty, default height is 6. TableLayoutPanel refuses to
										   // shrink to 0 as there are items in it.
				+ ((tableLayoutPanelFooterExpandedInformationArea.Height > hPadding) ? tableLayoutPanelFooterExpandedInformationArea.Height : 0);
		}

		private void SetMainIcon(TaskDialogIcon icon)
		{
			SetMainIcon(TaskDialog.IconFromTaskDialogIcon(icon));
		}

		private void SetMainIcon(Icon icon)
		{
			pictureBoxMainAreaIcon.Image = icon?.ToBitmap();
			tableLayoutPanelMainArea.ColumnStyles[0].Width = pictureBoxMainAreaIcon.Image?.Width + 10 ?? 0;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			timerTickCount += (uint)timer.Interval;

			if (taskDialog.OnTimer((int)timerTickCount))
				timerTickCount = 0;
		}

		private void ToggleExpandedInformationState()
		{
			if (taskDialog.ExpandFooterArea)
			{
				// Shrink/expand our upper "border".
				if (isExpanded)
				{
					tableLayoutPanel3.Visible = tableLayoutPanel4.Visible = false;
					Height -= tableLayoutPanel3.Height * 2;
				}
				else
				{
					tableLayoutPanel3.Visible = tableLayoutPanel4.Visible = true;
					Height += tableLayoutPanel3.Height * 2;
				}
			}

			if (isExpanded)
			{
				// Shrink the form first.
				Height -= linkLabelExpandedInformation.Height;
				linkLabelExpandedInformation.Visible = false;
				isExpanded = false;
			}
			else
			{
				linkLabelExpandedInformation.Visible = true;
				// Expand the form.
				Height += linkLabelExpandedInformation.Height;
				isExpanded = true;
			}
		}

		private void verificationCheckBox_Click(object sender, EventArgs e)
		{
			taskDialog.OnVerificationClicked(((CheckBox)sender).Checked);
		}

		private static class AdjustControls
		{
			/// <summary>
			/// Measure a multiline string
			/// </summary>
			/// <param name="gr">Graphics</param>
			/// <param name="text">string to measure</param>
			/// <param name="rect">Original rect. The width will be taken as fixed.</param>
			/// <param name="textboxControl">True if you want to measure the string for a textbox control</param>
			/// <returns>A Size object with the measure of the string according with the params</returns>
			public static Size GetBestSize(Graphics gr, string text, Rectangle rect, bool textboxControl)
			{
				RECT bounds = rect;
				using (var dc = new SafeDCHandle(gr))
				{
					var flags = DrawTextFlags.DT_CALCRECT | DrawTextFlags.DT_WORDBREAK;
					if (textboxControl) flags |= DrawTextFlags.DT_EDITCONTROL;
					DrawText(dc, text, text.Length, ref bounds, flags);
				}
				return new Size(bounds.Right - bounds.Left, bounds.Bottom - bounds.Top + (textboxControl ? 6 : 0));
			}

			/// <summary>
			/// Measure a multiline string for a Control
			///
			/// http://www.mobilepractices.com/2008/01/making-multiline-measurestring-work.html
			/// </summary>
			/// <param name="control">control</param>
			/// <param name="text">string to measure</param>
			/// <param name="rect">Original rect. The width will be taken as fixed.</param>
			/// <returns>A Size object with the measure of the string according with the params</returns>
			public static Size GetBestSize(Control control, string text, Rectangle rect)
			{
				Size result;
				using (var gr = control.CreateGraphics())
					using (var hDC = new SafeDCHandle(gr))
						using (new SafeDCObjectHandle(hDC, control.Font.ToHfont()))
							result = GetBestSize(gr, text, rect, control is TextBox);
				return result;
			}
		}
	}
}
#endif