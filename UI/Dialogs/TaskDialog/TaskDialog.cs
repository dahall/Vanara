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
 * - http://www.codeproject.com/Articles/17026/TaskDialog-for-WinForms
 *
 * Revision Control:-
 * ------------------
 * Created On: 2007 November 26
 * Major updates: 2015 Nov 6
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.PInvoke;
using Vanara.Resources;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

// ReSharper disable InconsistentNaming

namespace Vanara.Windows.Forms
{
	/// <summary>Progress bar state.</summary>
	[SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
	public enum ProgressBarState
	{
		/// <summary>Normal.</summary>
		Normal = ProgressState.PBST_NORMAL,

		/// <summary>Error state.</summary>
		Error = ProgressState.PBST_ERROR,

		/// <summary>Paused state.</summary>
		Paused = ProgressState.PBST_PAUSED
	}

	/// <summary>Indicates how buttons are displayed on a <see cref="TaskDialog"/>.</summary>
	public enum TaskDialogButtonDisplay
	{
		/// <summary>Places buttons as a standard buttons along with common buttons.</summary>
		StandardButton,

		/// <summary>Places buttons as command links in primary panel.</summary>
		CommandLink,

		/// <summary>Places buttons as command links with no icons in primary panel.</summary>
		CommandLinkNoIcon
	}

	/// <summary>The TaskDialog common button flags used to specify the built in buttons to show in the TaskDialog.</summary>
	[Flags]
	public enum TaskDialogCommonButtons
	{
		/// <summary>No common buttons.</summary>
		None = 0,

		/// <summary>OK common button. If selected Task Dialog will return DialogResult.OK.</summary>
		Ok = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON,

		/// <summary>Yes common button. If selected Task Dialog will return DialogResult.Yes.</summary>
		Yes = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_YES_BUTTON,

		/// <summary>No common button. If selected Task Dialog will return DialogResult.No.</summary>
		No = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_NO_BUTTON,

		/// <summary>
		/// Cancel common button. If selected Task Dialog will return DialogResult.Cancel. If this button is specified, the dialog box will respond to typical
		/// cancel actions (Alt-F4 and Escape).
		/// </summary>
		Cancel = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CANCEL_BUTTON,

		/// <summary>Retry common button. If selected Task Dialog will return DialogResult.Retry.</summary>
		Retry = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_RETRY_BUTTON,

		/// <summary>Close common button. If selected Task Dialog will return this value.</summary>
		Close = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CLOSE_BUTTON,
	}

	/// <summary>The System icons the TaskDialog supports.</summary>
	[SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
	public enum TaskDialogIcon : uint
	{
		/// <summary>No Icon.</summary>
		None = 0,

		/// <summary>System warning icon.</summary>
		Warning = PInvoke.ComCtl32.TaskDialogIcon.TD_WARNING_ICON,

		/// <summary>System Error icon.</summary>
		Error = PInvoke.ComCtl32.TaskDialogIcon.TD_ERROR_ICON,

		/// <summary>System Information icon.</summary>
		Information = PInvoke.ComCtl32.TaskDialogIcon.TD_INFORMATION_ICON,

		/// <summary>Shield icon.</summary>
		Shield = PInvoke.ComCtl32.TaskDialogIcon.TD_SHIELD_ICON,

		/// <summary>Shield icon on a blue background. Only available on Windows 8 and later.</summary>
		ShieldBlue = PInvoke.ComCtl32.TaskDialogIcon.TD_SHIELDBLUE_ICON,

		/// <summary>Warning Shield icon on a yellow background. Only available on Windows 8 and later.</summary>
		SecurityWarning = PInvoke.ComCtl32.TaskDialogIcon.TD_SECURITYWARNING_ICON,

		/// <summary>Error Shield icon on a red background. Only available on Windows 8 and later.</summary>
		SecurityError = PInvoke.ComCtl32.TaskDialogIcon.TD_SECURITYERROR_ICON,

		/// <summary>Success Shield icon on a green background. Only available on Windows 8 and later.</summary>
		SecuritySuccess = PInvoke.ComCtl32.TaskDialogIcon.TD_SECURITYSUCCESS_ICON,

		/// <summary>Shield icon on a gray background. Only available on Windows 8 and later.</summary>
		ShieldGray = PInvoke.ComCtl32.TaskDialogIcon.TD_SHIELDGRAY_ICON
	}

	/// <summary>
	/// A Task Dialog. This is like a MessageBox but with many more features. For Windows version prior to Vista, an emulated version of the system dialog is displayed.
	/// </summary>
	public class TaskDialog : CommonDialog, IWin32Window
	{
		// The minimum Windows version needed to support TaskDialog.
		private static readonly Version requiredOsVersion = new Version(6, 0, 5243);

		private string content;
		private Icon customFooterIcon;
		private Icon customMainIcon;
		private string expandedInformation;
		// The otherFlags passed to TaskDialogIndirect.
		private EnumFlagIndexer<TASKDIALOG_FLAGS> flags;
		private string footer;
		private TaskDialogIcon footerIcon;
		// When active, holds the handle of the current window.
		private IntPtr handle = IntPtr.Zero;
		private TaskDialogIcon mainIcon;
		private string mainInstruction;

		/// <summary>Initializes a new instance of the <see cref="TaskDialog"/> class.</summary>
		public TaskDialog()
		{
			ProgressBar = new TaskDialogProgressBar(this);
			Reset();
		}

		/// <summary>Occurs when a button is clicked.</summary>
		[Category("Action"), Description("Occurs when a button is clicked.")]
		public event EventHandler<ButtonClickedEventArgs> ButtonClicked;

		/// <summary>Occurs when the dialog is closed.</summary>
		[Category("Behavior"), Description("Occurs when the dialog is closed.")]
		public event EventHandler Closed;

		/// <summary>Occurs when the expando button is clicked and the dialog expands or contracts.</summary>
		[Category("Behavior"), Description("Occurs when the expando button is clicked and the dialog expands or contracts.")]
		public event EventHandler<ExpandedEventArgs> Expanded;

		/// <summary>Occurs when a link is clicked.</summary>
		[Category("Action"), Description("Occurs when a link is clicked.")]
		public event LinkClickedEventHandler LinkClicked;

		/// <summary>Occurs before the dialog is displayed for the first time.</summary>
		[Category("Behavior"), Description("Occurs before the dialog is displayed for the first time.")]
		public event EventHandler Load;

		/// <summary>Occurs when a radio button is clicked.</summary>
		[Category("Action"), Description("Occurs when a radio button is clicked.")]
		public event EventHandler<ButtonClickedEventArgs> RadioButtonClicked;

		/// <summary>Occurs when the timer fires.</summary>
		[Category("Action"), Description("Occurs when the timer fires.")]
		public event EventHandler<TimerEventArgs> Timer;

		/// <summary>Occurs when the verification check box is checked or unchecked.</summary>
		[Category("Action"), Description("Occurs when the verification check box is checked or unchecked.")]
		public event EventHandler<VerificationClickedEventArgs> VerificationClicked;

		/// <summary>
		/// Indicates that the dialog should be able to be closed using Alt-F4, Escape and the title bar’s close button even if no cancel button is specified in
		/// either the CommonButtons or Buttons members.
		/// </summary>
		[DefaultValue(false)]
		[Category("Behavior"), Description("Dialog can be closed by keys with no Cancel button.")]
		public bool AllowDialogCancellation
		{
			get => flags[TASKDIALOG_FLAGS.TDF_ALLOW_DIALOG_CANCELLATION]; set => flags[TASKDIALOG_FLAGS.TDF_ALLOW_DIALOG_CANCELLATION] = value;
		}

		/// <summary>Gets or sets the placement of buttons added to the <see cref="Buttons"/> collection.</summary>
		/// <value>The button placement.</value>
		[DefaultValue(typeof(TaskDialogButtonDisplay), "StandardButton")]
		[Category("Appearance"), Description("Determines how Buttons values are displayed")]
		public TaskDialogButtonDisplay ButtonDisplay
		{
			get
			{
				if (UseCommandLinksNoIcon)
					return TaskDialogButtonDisplay.CommandLinkNoIcon;
				return UseCommandLinks ? TaskDialogButtonDisplay.CommandLink : TaskDialogButtonDisplay.StandardButton;
			}
			set
			{
				switch (value)
				{
					case TaskDialogButtonDisplay.StandardButton:
						UseCommandLinks = UseCommandLinksNoIcon = false;
						break;

					case TaskDialogButtonDisplay.CommandLink:
						UseCommandLinks = true;
						UseCommandLinksNoIcon = false;
						break;

					case TaskDialogButtonDisplay.CommandLinkNoIcon:
						UseCommandLinks = false;
						UseCommandLinksNoIcon = true;
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(ButtonDisplay));
				}
			}
		}

		/// <summary>
		/// Specifies the custom push buttons to display in the dialog. Use CommonButtons member for common buttons; OK, Yes, No, Retry and Cancel, and Buttons
		/// when you want different text on the push buttons.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Appearance"), Description("Custom push buttons.")]
		public TaskDialogButtonCollection<TaskDialogButton> Buttons { get; } = new TaskDialogButtonCollection<TaskDialogButton>();

		/// <summary>Indicates that the TaskDialog’s callback should be called approximately every 200 milliseconds.</summary>
		[DefaultValue(false)]
		[Category("Behavior"), Description("Callback timer should be called every 200 ms.")]
		public bool CallbackTimer
		{
			get => flags[TASKDIALOG_FLAGS.TDF_CALLBACK_TIMER]; set => flags[TASKDIALOG_FLAGS.TDF_CALLBACK_TIMER] = value;
		}

		/// <summary>Indicates that the TaskDialog can be minimized. Works only if there if parent window is null. Will enable cancellation also.</summary>
		[DefaultValue(false)]
		[Category("Behavior"), Description("TaskDialog can be minimized.")]
		public bool CanBeMinimized
		{
			get => flags[TASKDIALOG_FLAGS.TDF_CAN_BE_MINIMIZED]; set => flags[TASKDIALOG_FLAGS.TDF_CAN_BE_MINIMIZED] = value;
		}

		/// <summary>
		/// The string to be used to label the button for expanding the expanded information. This member is ignored when the ExpandedInformation member is null.
		/// If this member is null and the ExpandedControlText is specified, then the ExpandedControlText value will be used for this member as well.
		/// </summary>
		[DefaultValue(null), Localizable(true),
		 Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[Category("Appearance"), Description("Button label for expanding the expanded information")]
		public string CollapsedControlText { get; set; }

		/// <summary>
		/// Specifies the push buttons displayed in the dialog box. This parameter may be a combination of otherFlags. If no common buttons are specified and no
		/// custom buttons are specified using the Buttons member, the dialog box will contain the OK button by default.
		/// </summary>
		[DefaultValue(typeof(TaskDialogCommonButtons), "None")]
		[Category("Appearance"), Description("Specifies common buttons to display.")]
		[Editor(typeof(Design.FlagEnumUIEditor<TaskDialogCommonButtons>), typeof(UITypeEditor))]
		public TaskDialogCommonButtons CommonButtons { get; set; }

		/// <summary>
		/// The string to be used for the dialog’s primary content. If the EnableHyperlinks member is true, then this string may contain hyper-links in the form:
		/// <A HREF="executablestring">Hyper-link Text</A>.
		/// WARNING: Enabling hyper-links when using content from an unsafe source may cause security vulnerabilities.
		/// </summary>
		[DefaultValue(null), Localizable(true),
		 Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[Category("Appearance"), Description("Optional text for the primary content area.")]
		public string Content
		{
			get => content; set
			{
				if (content == value) return;
				content = value;
				if (handle != IntPtr.Zero)
					SendMessage(HRef, (uint)TaskDialogMessage.TDM_SET_ELEMENT_TEXT, (int)TASKDIALOG_ELEMENTS.TDE_CONTENT, content);
			}
		}

		/// <summary>
		/// Specifies a custom icon for the icon to be displayed in the footer area of the dialog box. If this is set to none and the CustomFooterIcon member is
		/// null then no footer icon will be displayed.
		/// </summary>
		[DefaultValue(null)]
		[Category("Appearance"), Description("")]
		public Icon CustomFooterIcon
		{
			get => customFooterIcon; set
			{
				if (customFooterIcon == value) return;
				customFooterIcon = value;
				if (handle != IntPtr.Zero)
					SendMessage(HRef, (uint)TaskDialogMessage.TDM_UPDATE_ICON, (IntPtr)TASKDIALOG_ICON_ELEMENTS.TDIE_ICON_FOOTER,
						customFooterIcon?.Handle ?? (IntPtr)footerIcon);
			}
		}

		/// <summary>
		/// Specifies a custom in icon for the main icon in the dialog. If this is set to none and the CustomMainIcon member is null then no main icon will be displayed.
		/// </summary>
		[DefaultValue(null)]
		[Category("Appearance"), Description("")]
		public Icon CustomMainIcon
		{
			get => customMainIcon; set
			{
				if (customMainIcon == value) return;
				customMainIcon = value;
				if (handle != IntPtr.Zero)
					SendMessage(HRef, (uint)TaskDialogMessage.TDM_UPDATE_ICON, (IntPtr)TASKDIALOG_ICON_ELEMENTS.TDIE_ICON_MAIN,
						customMainIcon?.Handle ?? (IntPtr)mainIcon);
			}
		}

		/// <summary>
		/// Indicates the default button for the dialog. This may be any of the values specified in ButtonId members of one of the TaskDialogButton structures in
		/// the Buttons array, or one a DialogResult value that corresponds to a buttons specified in the CommonButtons Member. If this member is zero or its
		/// value does not correspond to any button ID in the dialog, then the first button in the dialog will be the default.
		/// </summary>
		[DefaultValue(0)]
		[Category("Behavior"), Description("")]
		public int DefaultButton { get; set; }

		/// <summary>
		/// Indicates the default radio button for the dialog. This may be any of the values specified in ButtonId members of one of the TaskDialogButton
		/// structures in the RadioButtons array. If this member is zero or its value does not correspond to any radio button ID in the dialog, then the first
		/// button in RadioButtons will be the default. The property NoDefaultRadioButton can be set to have no default.
		/// </summary>
		[DefaultValue(0)]
		[Category("Behavior"), Description("")]
		public int DefaultRadioButton { get; set; }

		/// <summary>
		/// Enables hyper-link processing for the strings specified in the Content, ExpandedInformation and FooterText members. When enabled, these members may
		/// be strings that contain hyper-links in the form: <A HREF="executablestring">Hyper-link Text</A>.
		/// WARNING: Enabling hyper-links when using content from an unsafe source may cause security vulnerabilities.
		/// Note: Task Dialog will not actually execute any hyper-links. Hyper-link execution must be handled in the callback function specified by Callback member.
		/// </summary>
		[DefaultValue(false)]
		[Category("Behavior"), Description("")]
		public bool EnableHyperlinks
		{
			get => flags[TASKDIALOG_FLAGS.TDF_ENABLE_HYPERLINKS]; set => flags[TASKDIALOG_FLAGS.TDF_ENABLE_HYPERLINKS] = value;
		}

		/// <summary>
		/// Indicates that the string specified by the ExpandedInformation member should be displayed when the dialog is initially displayed. This flag is
		/// ignored if the ExpandedInformation member is null.
		/// </summary>
		[DefaultValue(false)]
		[Category("Appearance"), Description("")]
		public bool ExpandedByDefault
		{
			get => flags[TASKDIALOG_FLAGS.TDF_EXPANDED_BY_DEFAULT]; set => flags[TASKDIALOG_FLAGS.TDF_EXPANDED_BY_DEFAULT] = value;
		}

		/// <summary>
		/// The string to be used to label the button for collapsing the expanded information. This member is ignored when the ExpandedInformation member is
		/// null. If this member is null and the CollapsedControlText is specified, then the CollapsedControlText value will be used for this member as well.
		/// </summary>
		[DefaultValue(null), Localizable(true),
		 Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[Category("Appearance"), Description("")]
		public string ExpandedControlText { get; set; }

		/// <summary>
		/// The string to be used for displaying additional information. The additional information is displayed either immediately below the content or below
		/// the footer text depending on whether the ExpandFooterArea member is true. If the EnameHyperlinks member is true, then this string may contain
		/// hyper-links in the form: <A HREF="executablestring">Hyper-link Text</A>.
		/// WARNING: Enabling hyper-links when using content from an unsafe source may cause security vulnerabilities.
		/// </summary>
		[DefaultValue(null), Localizable(true),
		 Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[Category("Appearance"), Description("")]
		public string ExpandedInformation
		{
			get => expandedInformation; set
			{
				if (expandedInformation == value) return;
				expandedInformation = value;
				if (handle != IntPtr.Zero)
					SendMessage(HRef, (uint)TaskDialogMessage.TDM_SET_ELEMENT_TEXT,
						(IntPtr)TASKDIALOG_ELEMENTS.TDE_EXPANDED_INFORMATION, expandedInformation);
			}
		}

		/// <summary>
		/// Indicates that the string specified by the ExpandedInformation member should be displayed at the bottom of the dialog’s footer area instead of
		/// immediately after the dialog’s content. This flag is ignored if the ExpandedInformation member is null.
		/// </summary>
		[DefaultValue(false)]
		[Category("Appearance"), Description("")]
		public bool ExpandFooterArea
		{
			get => flags[TASKDIALOG_FLAGS.TDF_EXPAND_FOOTER_AREA]; set => flags[TASKDIALOG_FLAGS.TDF_EXPAND_FOOTER_AREA] = value;
		}

		/// <summary>
		/// The string to be used in the footer area of the dialog box. If the EnableHyperlinks member is true, then this string may contain hyper-links in the
		/// form: <A HREF="executablestring"> Hyper-link Text</A>.
		/// WARNING: Enabling hyper-links when using content from an unsafe source may cause security vulnerabilities.
		/// </summary>
		[DefaultValue(null), Localizable(true),
		 Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[Category("Appearance"), Description("")]
		public string Footer
		{
			get => footer; set
			{
				if (footer == value) return;
				footer = value;
				if (handle != IntPtr.Zero)
					SendMessage(HRef, (uint)TaskDialogMessage.TDM_SET_ELEMENT_TEXT, (IntPtr)TASKDIALOG_ELEMENTS.TDE_FOOTER, footer);
			}
		}

		/// <summary>
		/// Specifies a built in icon for the icon to be displayed in the footer area of the dialog box. If this is set to none and the CustomFooterIcon member
		/// is null then no footer icon will be displayed.
		/// </summary>
		[DefaultValue(typeof(TaskDialogIcon), "None")]
		[Category("Appearance"), Description("")]
		public TaskDialogIcon FooterIcon
		{
			get => footerIcon; set
			{
				if (footerIcon == value) return;
				footerIcon = value;
				if (handle != IntPtr.Zero)
					SendMessage(HRef, (uint)TaskDialogMessage.TDM_UPDATE_ICON, (IntPtr)TASKDIALOG_ICON_ELEMENTS.TDIE_ICON_FOOTER,
						(IntPtr)footerIcon);
			}
		}

		/// <summary>Gets the image for the configured footer icon.</summary>
		/// <value>The main icon image.</value>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public Image FooterIconImage => GetSmallImage(customFooterIcon ?? IconFromTaskDialogIcon(footerIcon));

		/// <summary>Gets the handle for the active dialog.</summary>
		/// <value>The handle. This value will be <c>IntPtr.Zero</c> if no active dialog is being displayed.</value>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		IntPtr IWin32Window.Handle => handle;

		/// <summary>
		/// Specifies a built in icon for the main icon in the dialog. If this is set to none and the CustomMainIcon is null then no main icon will be displayed.
		/// </summary>
		[DefaultValue(typeof(TaskDialogIcon), "None")]
		[Category("Appearance"), Description("")]
		public TaskDialogIcon MainIcon
		{
			get => mainIcon; set
			{
				if (mainIcon != value)
				{
					mainIcon = value;
					if (handle != IntPtr.Zero)
						SendMessage(HRef, (uint)TaskDialogMessage.TDM_UPDATE_ICON, (IntPtr)TASKDIALOG_ICON_ELEMENTS.TDIE_ICON_MAIN,
							(IntPtr)mainIcon);
				}
			}
		}

		/// <summary>Gets the image for the configured main icon.</summary>
		/// <value>The main icon image.</value>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public Image MainIconImage => (customFooterIcon ?? IconFromTaskDialogIcon(footerIcon)).ToBitmap();

		/// <summary>The string to be used for the main instruction.</summary>
		[DefaultValue(null), Localizable(true),
		 Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[Category("Appearance"), Description("")]
		public string MainInstruction
		{
			get => mainInstruction; set
			{
				if (mainInstruction != value)
				{
					mainInstruction = value;
					if (handle != IntPtr.Zero)
						SendMessage(HRef, (uint)TaskDialogMessage.TDM_SET_ELEMENT_TEXT, (IntPtr)TASKDIALOG_ELEMENTS.TDE_MAIN_INSTRUCTION,
							mainInstruction);
				}
			}
		}

		/// <summary>Indicates that the TaskDialog should have no default radio button.</summary>
		[DefaultValue(false)]
		[Category("Behavior"), Description("")]
		public bool NoDefaultRadioButton
		{
			get => flags[TASKDIALOG_FLAGS.TDF_NO_DEFAULT_RADIO_BUTTON]; set => flags[TASKDIALOG_FLAGS.TDF_NO_DEFAULT_RADIO_BUTTON] = value;
		}

		/// <summary>
		/// Indicates that the TaskDialog should be positioned (centered) relative to the owner window passed when calling Show. If not set (or no owner window
		/// is passed), the TaskDialog is positioned (centered) relative to the monitor.
		/// </summary>
		[DefaultValue(false)]
		[Category("Window Style"), Description("")]
		public bool PositionRelativeToWindow
		{
			get => flags[TASKDIALOG_FLAGS.TDF_POSITION_RELATIVE_TO_WINDOW]; set => flags[TASKDIALOG_FLAGS.TDF_POSITION_RELATIVE_TO_WINDOW] = value;
		}

		/// <summary>
		/// The progress bar for the <see cref="TaskDialog"/>. This will only be visible if the <see cref="TaskDialogProgressBar.Visible"/> property is set to <c>true</c>.
		/// </summary>
		/// <value>The progress bar.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Appearance"), Description("")]
		public TaskDialogProgressBar ProgressBar { get; }

		/// <summary>Specifies the radio buttons to display in the dialog.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Appearance"), Description("")]
		public TaskDialogButtonCollection<TaskDialogRadioButton> RadioButtons { get; } =
			new TaskDialogButtonCollection<TaskDialogRadioButton>();

		/// <summary>Gets the full set of results for the last showing of the <see cref="TaskDialog"/>.</summary>
		/// <value>The result set.</value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TaskDialogResult Result { get; private set; }

		/// <summary>Indicates that the TaskDialog should have right to left layout.</summary>
		[DefaultValue(false)]
		[Category("Appearance"), Description("")]
		public bool RightToLeftLayout
		{
			get => flags[TASKDIALOG_FLAGS.TDF_RTL_LAYOUT]; set => flags[TASKDIALOG_FLAGS.TDF_RTL_LAYOUT] = value;
		}

		/// <summary>
		/// Indicates that the width of the task dialog is determined by the width of its content area. This flag is ignored if <see cref="Width"/> is not set to 0.
		/// </summary>
		[DefaultValue(false)]
		[Category("Layout"), Description("")]
		public bool SizeToContent
		{
			get => flags[TASKDIALOG_FLAGS.TDF_SIZE_TO_CONTENT]; set => flags[TASKDIALOG_FLAGS.TDF_SIZE_TO_CONTENT] = value;
		}

		/// <summary>Gets or sets a value indicating whether the form should be displayed as a topmost form.</summary>
		[DefaultValue(true)]
		[Category("Window Style"), Description("")]
		public bool TopMost
		{
			get => !flags[TASKDIALOG_FLAGS.TDF_NO_SET_FOREGROUND]; set => flags[TASKDIALOG_FLAGS.TDF_NO_SET_FOREGROUND] = !value;
		}

		/// <summary>
		/// Indicates that the verification checkbox in the dialog should be checked when the dialog is initially displayed. This flag is ignored if the
		/// VerificationText parameter is null.
		/// </summary>
		[DefaultValue(false)]
		[Category("Appearance"), Description("")]
		public bool VerificationFlagChecked
		{
			get => flags[TASKDIALOG_FLAGS.TDF_VERIFICATION_FLAG_CHECKED]; set => flags[TASKDIALOG_FLAGS.TDF_VERIFICATION_FLAG_CHECKED] = value;
		}

		/// <summary>
		/// The string to be used to label the verification checkbox. If this member is null, the verification checkbox is not displayed in the dialog box.
		/// </summary>
		[DefaultValue(null), Localizable(true),
		 Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[Category("Appearance"), Description("")]
		public string VerificationText { get; set; }

		/// <summary>width of the Task Dialog's client area in DLU's. If 0, Task Dialog will calculate the ideal width.</summary>
		[DefaultValue(0)]
		[Category("Layout"), Description("")]
		public int Width { get; set; }

		/// <summary>The string to be used for the dialog box title. If this parameter is NULL, the filename of the executable program is used.</summary>
		[DefaultValue(null), Localizable(true),
		 Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[Category("Appearance"), Description("")]
		public string WindowTitle { get; set; }

		/// <summary>Indicates that an Marquee Progress Bar should be displayed.</summary>
		[DefaultValue(false)]
		internal bool ShowMarqueeProgressBar
		{
			get => flags[TASKDIALOG_FLAGS.TDF_SHOW_MARQUEE_PROGRESS_BAR]; set => flags[TASKDIALOG_FLAGS.TDF_SHOW_MARQUEE_PROGRESS_BAR] = value;
		}

		/// <summary>Indicates that a Progress Bar should be displayed.</summary>
		[DefaultValue(false)]
		internal bool ShowProgressBar
		{
			get => flags[TASKDIALOG_FLAGS.TDF_SHOW_PROGRESS_BAR]; set => flags[TASKDIALOG_FLAGS.TDF_SHOW_PROGRESS_BAR] = value;
		}

		/// <summary>
		/// Indicates that the buttons specified in the Buttons member should be displayed as command links (using a standard task dialog glyph) instead of push
		/// buttons. When using command links, all characters up to the first new line character in the ButtonText member (of the TaskDialogButton
		/// structure) will be treated as the command link’s main text, and the remainder will be treated as the command link’s note. This flag is ignored if the
		/// Buttons member has no entires.
		/// </summary>
		[DefaultValue(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal bool UseCommandLinks
		{
			get => flags[TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS]; set => flags[TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS] = value;
		}

		/// <summary>
		/// Indicates that the buttons specified in the Buttons member should be displayed as command links (without a glyph) instead of push buttons. When using
		/// command links, all characters up to the first new line character in the ButtonText member (of the TaskDialogButton structure) will be treated as the
		/// command link’s main text, and the remainder will be treated as the command link’s note. This flag is ignored if the Buttons member has no entires.
		/// </summary>
		[DefaultValue(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal bool UseCommandLinksNoIcon
		{
			get => flags[TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS_NO_ICON]; set => flags[TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS_NO_ICON] = value;
		}

		/// <summary>Gets or sets a value indicating whether this instance can raise events.</summary>
		/// <value><c>true</c> if this instance can raise events; otherwise, <c>false</c>.</value>
		protected override bool CanRaiseEvents => true;

		private HandleRef HRef => new HandleRef(this, handle);

		/// <summary>
		/// Returns true if the current operating system supports TaskDialog. If false TaskDialog.Show should not be called as the results are undefined but
		/// often results in a crash.
		/// </summary>
		private static readonly bool IsAvailable = Environment.OSVersion.Platform == PlatformID.Win32NT && (Environment.OSVersion.Version.CompareTo(requiredOsVersion) >= 0);

		/// <summary>Displays a task dialog in front of the specified window and with the specified main instruction, content, caption, buttons, and icon.</summary>
		/// <param name="win32Window">An implementation of <see cref="IWin32Window"/> that will own the modal dialog box.</param>
		/// <param name="mainInstruction">The text to display as the main instruction.</param>
		/// <param name="content">The text to show as content below the main instruction. Value can be <c>null</c>.</param>
		/// <param name="caption">The text to display in the title bar.</param>
		/// <param name="buttons">One or more of the <see cref="TaskDialogCommonButtons"/> values that specifies which buttons to display in the task dialog.</param>
		/// <param name="icon">One of the <see cref="TaskDialogIcon"/> values that specifies which icon to display in the task dialog.</param>
		/// <returns>One of the <see cref="DialogResult"/> values.</returns>
		public static int Show(IWin32Window win32Window, string mainInstruction, string content = null, string caption = "",
			TaskDialogCommonButtons buttons = TaskDialogCommonButtons.Ok, TaskDialogIcon icon = TaskDialogIcon.None)
		{
			if (mainInstruction == null) throw new ArgumentNullException(nameof(mainInstruction));
			var dlg = new TaskDialog
			{
				MainInstruction = mainInstruction,
				Content = content,
				WindowTitle = caption,
				CommonButtons = buttons,
				MainIcon = icon
			};
			dlg.PrivateShow(win32Window?.Handle ?? IntPtr.Zero);
			return dlg.Result.DialogResult;
		}

		/// <summary>Displays a task dialog in front of the specified window and with the specified main instruction, content, caption, buttons, and icon.</summary>
		/// <param name="win32Window">An implementation of <see cref="IWin32Window"/> that will own the modal dialog box.</param>
		/// <param name="mainInstruction">The text to display as the main instruction.</param>
		/// <param name="content">The text to show as content below the main instruction. Value can be <c>null</c>.</param>
		/// <param name="caption">The text to display in the title bar.</param>
		/// <param name="radioButtons">Array of labels for radio buttons.</param>
		/// <param name="buttons">One or more of the <see cref="TaskDialogCommonButtons"/> values that specifies which buttons to display in the task dialog.</param>
		/// <param name="icon">One of the <see cref="TaskDialogIcon"/> values that specifies which icon to display in the task dialog.</param>
		/// <returns>The 1-based index of the selected radio button, or <c>0</c> if no radio button was selected or the task dialog was cancelled.</returns>
		public static int Show(IWin32Window win32Window, string mainInstruction, string content, string caption,
			string[] radioButtons, TaskDialogCommonButtons buttons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel,
			TaskDialogIcon icon = TaskDialogIcon.None)
		{
			if (mainInstruction == null) throw new ArgumentNullException(nameof(mainInstruction));
			var dlg = new TaskDialog
			{
				MainInstruction = mainInstruction,
				Content = content,
				WindowTitle = caption,
				CommonButtons = buttons,
				MainIcon = icon
			};
			foreach (var s in radioButtons)
				dlg.RadioButtons.Add(new TaskDialogRadioButton(s));
			dlg.PrivateShow(win32Window?.Handle ?? IntPtr.Zero);
			return dlg.RadioButtons.FindIndex(b => b.ButtonId == dlg.Result.SelectedRadioButton) + 1;
		}

		/// <summary>Displays a task dialog with the specified main instruction, content, caption, buttons, and icon.</summary>
		/// <param name="mainInstruction">The text to display as the main instruction.</param>
		/// <param name="content">The text to show as content below the main instruction. Value can be <c>null</c>.</param>
		/// <param name="caption">The text to display in the title bar.</param>
		/// <param name="buttons">One or more of the <see cref="TaskDialogCommonButtons"/> values that specifies which buttons to display in the task dialog.</param>
		/// <param name="icon">One of the <see cref="TaskDialogIcon"/> values that specifies which icon to display in the task dialog.</param>
		/// <returns>One of the <see cref="DialogResult"/> values.</returns>
		public static int Show(string mainInstruction, string content = null, string caption = "",
			TaskDialogCommonButtons buttons = TaskDialogCommonButtons.Ok, TaskDialogIcon icon = TaskDialogIcon.None) =>
				Show(null, mainInstruction, content, caption, buttons, icon);

		/// <summary>Displays a task dialog in front of the specified window and with the specified main instruction, caption, custom buttons, and icon.</summary>
		/// <param name="win32Window">An implementation of <see cref="IWin32Window"/> that will own the modal dialog box.</param>
		/// <param name="mainInstruction">The text to display as the main instruction.</param>
		/// <param name="caption">The text to display in the title bar.</param>
		/// <param name="buttons">
		/// One or more strings to display on separate Command Link buttons in the task dialog. To specify a secondary string within a button string, include a
		/// line-feed "\n" character.
		/// </param>
		/// <param name="icon">One of the <see cref="TaskDialogIcon"/> values that specifies which icon to display in the task dialog.</param>
		/// <returns>
		/// The value of the button clicked starting with 101. Each subsequent button's id will increment by 1. (e.g. Three strings for buttons would have the
		/// identifiers of 101, 102, and 103.).
		/// </returns>
		public static int Show(IWin32Window win32Window, string mainInstruction, string caption, string[] buttons,
			TaskDialogIcon icon = TaskDialogIcon.None)
		{
			if (mainInstruction == null) throw new ArgumentNullException(nameof(mainInstruction));
			if (buttons == null) throw new ArgumentNullException(nameof(buttons));
			if (buttons.Length == 0)
				throw new ArgumentException(@"At least one string must be supplied for the buttons.", nameof(buttons));
			var dlg = new TaskDialog
			{
				MainInstruction = mainInstruction,
				WindowTitle = caption,
				CommonButtons = TaskDialogCommonButtons.Cancel,
				ButtonDisplay = TaskDialogButtonDisplay.CommandLink,
				MainIcon = icon
			};
			var id = 101;
			foreach (var s in buttons) dlg.Buttons.Add(new TaskDialogButton(s, id++));
			dlg.PrivateShow(win32Window?.Handle ?? IntPtr.Zero);
			return dlg.Result.DialogResult;
		}

		/// <summary>Displays a task dialog with the specified main instruction, caption, custom buttons, and icon.</summary>
		/// <param name="mainInstruction">The text to display as the main instruction.</param>
		/// <param name="caption">The text to display in the title bar.</param>
		/// <param name="buttons">
		/// One or more strings to display on separate Command Link buttons in the task dialog. To specify a secondary string within a button string, include a
		/// line-feed "\n" character.
		/// </param>
		/// <param name="icon">One of the <see cref="TaskDialogIcon"/> values that specifies which icon to display in the task dialog.</param>
		/// <returns>
		/// The value of the button clicked starting with 101. Each subsequent button's id will increment by 1. (e.g. Three strings for buttons would have the
		/// identifiers of 101, 102, and 103.).
		/// </returns>
		public static int Show(string mainInstruction, string caption, string[] buttons,
			TaskDialogIcon icon = TaskDialogIcon.None) =>
				Show(null, mainInstruction, caption, buttons, icon);

		/// <summary>
		/// Simulate the action of a button click in the TaskDialog. This can be a DialogResult value or the ButtonID set on a TasDialogButton set on TaskDialog.Buttons.
		/// </summary>
		/// <param name="buttonId">Indicates the button ID to be selected.</param>
		/// <returns>If the function succeeds the return value is true.</returns>
		// TDM_CLICK_BUTTON = WM_USER+102, // wParam = Button ID
		public void PerformButtonClick(int buttonId)
		{
			if (handle != IntPtr.Zero)
				SendMessage(HRef, (uint)TaskDialogMessage.TDM_CLICK_BUTTON, (IntPtr)buttonId, IntPtr.Zero);
		}

		/// <summary>Check or uncheck the verification checkbox in the TaskDialog.</summary>
		/// <param name="checkedState">The checked state to set the verification checkbox.</param>
		/// <param name="setKeyboardFocusToCheckBox">True to set the keyboard focus to the checkbox, and false otherwise.</param>
		public void PerformVerificationClick(bool checkedState, bool setKeyboardFocusToCheckBox)
		{
			// TDM_CLICK_VERIFICATION = WM_USER+113, // wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)
			if (handle != IntPtr.Zero)
				SendMessage(HRef, (uint)TaskDialogMessage.TDM_CLICK_VERIFICATION, (checkedState ? new IntPtr(1) : IntPtr.Zero),
					(setKeyboardFocusToCheckBox ? new IntPtr(1) : IntPtr.Zero));
		}

		/// <summary>Resets the Task Dialog to the state when first constructed, all properties set to their default value.</summary>
		public override void Reset()
		{
			Buttons.Clear();
			CollapsedControlText = null;
			CommonButtons = 0;
			Content = null;
			CustomFooterIcon = null;
			CustomMainIcon = null;
			DefaultButton = 0;
			DefaultRadioButton = 0;
			ExpandedControlText = null;
			ExpandedInformation = null;
			flags = (TASKDIALOG_FLAGS)0;
			Footer = null;
			FooterIcon = TaskDialogIcon.None;
			MainIcon = TaskDialogIcon.None;
			MainInstruction = null;
			ProgressBar.Reset();
			RadioButtons.Clear();
			VerificationText = null;
			Width = 0;
			WindowTitle = null;
		}

		internal static Image GetSmallImage(Icon icon)
		{
			if (icon == null) return null;
			var sz = SystemInformation.SmallIconSize;
			var bmp = new Bitmap(sz.Width, sz.Height);
			using (var g = Graphics.FromImage(bmp))
			{
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.DrawImage(icon.ToBitmap(), new Rectangle(Point.Empty, sz));
			}
			return bmp;
		}

		internal static Icon IconFromTaskDialogIcon(TaskDialogIcon icon)
		{
			if (Environment.OSVersion.Version >= requiredOsVersion)
			{
				var ie = new ResourceFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "imageres.dll"));
				switch (icon)
				{
					case TaskDialogIcon.None:
						return null;
					case TaskDialogIcon.Warning:
						return ie.GroupIcons[79];
					case TaskDialogIcon.Error:
						return ie.GroupIcons[93];
					case TaskDialogIcon.Information:
						return ie.GroupIcons[76];
					case TaskDialogIcon.SecurityWarning:
						return ie.GroupIcons[102];
					case TaskDialogIcon.SecurityError:
						return ie.GroupIcons[100];
					case TaskDialogIcon.SecuritySuccess:
						return ie.GroupIcons[101];
					default:
						return ie.GroupIcons[73];
				}
			}

			switch (icon)
			{
				case TaskDialogIcon.None:
					return null;
				case TaskDialogIcon.Warning:
					return SystemIcons.Warning;
				case TaskDialogIcon.Error:
					return SystemIcons.Error;
				case TaskDialogIcon.Information:
					return SystemIcons.Information;
				default:
					return SystemIcons.Shield;
			}
		}

		/// <summary>
		/// Enable or disable a button in the TaskDialog. The passed buttonID is the ButtonID set on a TaskDialogButton set on TaskDialog.Buttons or a common
		/// button ID.
		/// </summary>
		/// <param name="buttonId">Indicates the button ID to be enabled or disabled.</param>
		/// <param name="enable">Enable the button if true. Disable the button if false.</param>
		internal void EnableButton(int buttonId, bool enable)
		{
			// TDM_ENABLE_BUTTON = WM_USER+111, // lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID
			if (handle != IntPtr.Zero)
				SendMessage(HRef, (uint)TaskDialogMessage.TDM_ENABLE_BUTTON, (IntPtr)buttonId, (IntPtr)(enable ? 1 : 0));
		}

		/// <summary>Enable or disable a radio button in the TaskDialog. The passed buttonID is the ButtonID set on a TaskDialogButton set on TaskDialog.RadioButtons.</summary>
		/// <param name="buttonId">Indicates the button ID to be enabled or disabled.</param>
		/// <param name="enable">Enable the button if true. Disable the button if false.</param>
		internal void EnableRadioButton(int buttonId, bool enable)
		{
			// TDM_ENABLE_RADIO_BUTTON = WM_USER+112, // lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID
			if (handle != IntPtr.Zero)
				SendMessage(HRef, (uint)TaskDialogMessage.TDM_ENABLE_RADIO_BUTTON, (IntPtr)buttonId, (IntPtr)(enable ? 1 : 0));
		}

		internal void InitializeButtonState()
		{
			foreach (var b in Buttons)
			{
				if (!b.Enabled)
					EnableButton(b.ButtonId, false);
				if (b.ElevatedStateRequired)
					SetButtonElevationRequiredState(b.ButtonId, true);
			}
		}

		/// <summary>Raises the <see cref="ButtonClicked"/> event.</summary>
		/// <param name="id">The button identifier.</param>
		/// <returns><c>true</c> to prevent close; otherwise, <c>false</c>. Ignored for radio buttons.</returns>
		internal virtual bool OnButtonClicked(int id)
		{
			var btn = Buttons.Find(b => b.ButtonId == id);
			var e = new ButtonClickedEventArgs(id, btn);
			ButtonClicked?.Invoke(this, e);
			btn?.OnClick(e);
			return e.Cancel;
		}

		/// <summary>Raises the <see cref="Closed"/> event.</summary>
		internal virtual void OnClosed()
		{
			Closed?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>Called when the expando button is clicked and the dialog expands or contracts.</summary>
		/// <param name="expanded"><c>true</c> if dialog is expanded; otherwise <c>false</c>.</param>
		internal virtual void OnExpanded(bool expanded)
		{
			Expanded?.Invoke(this, new ExpandedEventArgs(expanded));
		}

		/// <summary>Raises the <see cref="LinkClicked"/> event.</summary>
		/// <param name="url">The URL of the link.</param>
		internal virtual void OnLinkClicked(string url)
		{
			LinkClicked?.Invoke(this, new LinkClickedEventArgs(url));
		}

		/// <summary>Raises the <see cref="Load"/> event.</summary>
		internal virtual void OnLoad()
		{
			Load?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>Raises the <see cref="RadioButtonClicked"/> event.</summary>
		/// <param name="id">The radio button identifier.</param>
		internal virtual void OnRadioButtonClicked(int id)
		{
			var btn = RadioButtons.Find(b => b.ButtonId == id);
			RadioButtonClicked?.Invoke(this, new ButtonClickedEventArgs(id, btn));
			btn?.OnClick(EventArgs.Empty);
		}

		/// <summary>Raises the <see cref="Timer"/> event.</summary>
		/// <param name="ticks">The tick count.</param>
		/// <returns><c>true</c> to reset tick count; otherwise, <c>false</c> to continue to increment.</returns>
		internal virtual bool OnTimer(int ticks)
		{
			var a = new TimerEventArgs(ticks);
			Timer?.Invoke(this, a);
			return a.Reset;
		}

		/// <summary>Called when the verification check box is checked or unchecked.</summary>
		/// <param name="verificationChecked"><c>true</c> if check box is checked; otherwise <c>false</c>.</param>
		internal virtual void OnVerificationClicked(bool verificationChecked)
		{
			VerificationClicked?.Invoke(this, new VerificationClickedEventArgs(verificationChecked));
		}

		/// <summary>
		/// Simulate the action of a radio button click in the TaskDialog. The passed buttonID is the ButtonID set on a TaskDialogButton set on TaskDialog.RadioButtons.
		/// </summary>
		/// <param name="buttonId">Indicates the button ID to be selected.</param>
		internal void PerformRadioButtonClick(int buttonId)
		{
			// TDM_CLICK_RADIO_BUTTON = WM_USER+110, // wParam = Radio Button ID
			if (handle != IntPtr.Zero)
				SendMessage(HRef, (uint)TaskDialogMessage.TDM_CLICK_RADIO_BUTTON, (IntPtr)buttonId, IntPtr.Zero);
		}

		/// <summary>Designate whether a given Task Dialog button or command link should have a User Account Control (UAC) shield icon.</summary>
		/// <param name="buttonId">ID of the push button or command link to be updated.</param>
		/// <param name="elevationRequired">
		/// False to designate that the action invoked by the button does not require elevation; true to designate that the action does require elevation.
		/// </param>
		internal void SetButtonElevationRequiredState(int buttonId, bool elevationRequired)
		{
			// TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE = WM_USER+115, // wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)
			if (handle != IntPtr.Zero)
				SendMessage(HRef, (uint)TaskDialogMessage.TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE, (IntPtr)buttonId,
					(IntPtr)(elevationRequired ? 1 : 0));
		}

		/// <summary>Defines the common dialog box hook procedure that is overridden to add specific functionality to a common dialog box.</summary>
		/// <param name="hWnd">The handle to the dialog box window.</param>
		/// <param name="msg">The message being received.</param>
		/// <param name="wparam">Additional information about the message.</param>
		/// <param name="lparam">Additional information about the message.</param>
		/// <returns>
		/// A zero value if the default dialog box procedure processes the message; a nonzero value if the default dialog box procedure ignores the message.
		/// </returns>
		protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
		{
			//ActiveTaskDialog activeDialog = new ActiveTaskDialog(hWnd);
			handle = hWnd;
			switch ((TaskDialogNotification)msg)
			{
				case TaskDialogNotification.TDN_CREATED:
					ProgressBar.Initialize();
					InitializeButtonState();
					OnLoad();
					break;

				case TaskDialogNotification.TDN_BUTTON_CLICKED:
					return (IntPtr)(OnButtonClicked((int)wparam) ? 1 : 0);

				case TaskDialogNotification.TDN_RADIO_BUTTON_CLICKED:
					OnRadioButtonClicked((int)wparam);
					break;

				case TaskDialogNotification.TDN_HELP:
					OnHelpRequest(EventArgs.Empty);
					break;

				case TaskDialogNotification.TDN_HYPERLINK_CLICKED:
					OnLinkClicked(Marshal.PtrToStringUni(lparam));
					break;

				case TaskDialogNotification.TDN_TIMER:
					return (IntPtr)(OnTimer((int)wparam) ? 1 : 0);

				case TaskDialogNotification.TDN_VERIFICATION_CLICKED:
					OnVerificationClicked(wparam != IntPtr.Zero);
					break;

				case TaskDialogNotification.TDN_EXPANDO_BUTTON_CLICKED:
					OnExpanded(wparam != IntPtr.Zero);
					break;

				case TaskDialogNotification.TDN_DESTROYED:
					OnClosed();
					handle = IntPtr.Zero;
					break;
			}
			return base.HookProc(hWnd, msg, wparam, lparam);
		}

		/// <summary>The required implementation of CommonDialog that shows the Task Dialog.</summary>
		/// <param name="hwndOwner">Owner window. This can be null.</param>
		/// <returns>
		/// If this method returns true, then ShowDialog will return DialogResult.OK. If this method returns false, then ShowDialog will return
		/// DialogResult.Cancel. The user of this class must use the TaskDialogResult member to get more information.
		/// </returns>
		protected override bool RunDialog(IntPtr hwndOwner)
		{
			var res = PrivateShow(hwndOwner);
			return (res.DialogResult != (int)DialogResult.Cancel);
		}

		/// <summary>The callback from the native Task Dialog. This prepares the friendlier arguments and calls the simpler callback.</summary>
		/// <param name="hwnd">The window handle of the Task Dialog that is active.</param>
		/// <param name="msg">The notification. A TaskDialogNotification value.</param>
		/// <param name="wparam">Specifies additional notification information. The contents of this parameter depends on the value of the msg parameter.</param>
		/// <param name="lparam">Specifies additional notification information. The contents of this parameter depends on the value of the msg parameter.</param>
		/// <param name="refData">Specifies the application-defined value given in the call to TaskDialogIndirect.</param>
		/// <returns>A HRESULT. It's not clear in the spec what a failed result will do.</returns>
		private HRESULT PrivateCallback([In] IntPtr hwnd, [In] TaskDialogNotification msg, [In] IntPtr wparam, [In] IntPtr lparam,
			[In] IntPtr refData) => HookProc(hwnd, (int)msg, wparam, lparam).ToInt32();

		/// <summary>
		/// Creates, displays, and operates a task dialog. The task dialog contains application-defined messages, title, verification check box, command links
		/// and push buttons, plus any combination of predefined icons and push buttons as specified on the other members of the class before calling Show.
		/// </summary>
		/// <param name="hwndOwner">Owner window the task Dialog will modal to.</param>
		/// <returns>The set of results of the dialog.</returns>
		private TaskDialogResult PrivateShow(IntPtr hwndOwner)
		{
			if (!IsAvailable)
			{
#if TASKDIALOG_EMULATE
				// Hand it off to emulator.
				using (var taskDialogEmulate = new EmulateTaskDialog(this))
				{
					taskDialogEmulate.HandleCreated += (s, e) => handle = taskDialogEmulate.Handle;
					taskDialogEmulate.ShowDialog();
					handle = IntPtr.Zero;
					Result = new TaskDialogResult(taskDialogEmulate.TaskDialogResult,
						taskDialogEmulate.TaskDialogVerificationFlagChecked, taskDialogEmulate.TaskDialogRadioButtonResult);
				}
				return Result;
#else
				throw new PlatformNotSupportedException("TaskDialog requires Windows Vista or later.");
#endif
			}

			var config = new TASKDIALOGCONFIG
			{
				cbSize = (uint)Marshal.SizeOf(typeof(TASKDIALOGCONFIG)),
				hwndParent = hwndOwner,
				dwFlags = flags,
				dwCommonButtons = (TASKDIALOG_COMMON_BUTTON_FLAGS)CommonButtons
			};


			if (!string.IsNullOrEmpty(WindowTitle))
				config.pszWindowTitle = WindowTitle;

			if (CustomMainIcon != null)
			{
				config.dwFlags |= TASKDIALOG_FLAGS.TDF_USE_HICON_MAIN;
				config.mainIcon = CustomMainIcon.Handle;
			}
			else
				config.mainIcon = (IntPtr)MainIcon;

			if (!string.IsNullOrEmpty(MainInstruction))
				config.pszMainInstruction = MainInstruction;

			if (!string.IsNullOrEmpty(Content))
				config.pszContent = Content;

			foreach (var b in Buttons) b.parent = this;
			config.pButtons = (IntPtr)Buttons;
			config.cButtons = (uint)Buttons.Count;
			config.nDefaultButton = DefaultButton;

			foreach (var b in RadioButtons) b.parent = this;
			config.pRadioButtons = (IntPtr)RadioButtons;
			config.cRadioButtons = (uint)RadioButtons.Count;
			config.nDefaultRadioButton = DefaultRadioButton;

			if (!string.IsNullOrEmpty(VerificationText))
				config.pszVerificationText = VerificationText;

			if (!string.IsNullOrEmpty(ExpandedInformation))
				config.pszExpandedInformation = ExpandedInformation;

			if (!string.IsNullOrEmpty(ExpandedControlText))
				config.pszExpandedControlText = ExpandedControlText;

			if (!string.IsNullOrEmpty(CollapsedControlText))
				config.pszCollapsedControlText = CollapsedControlText;

			config.footerIcon = (IntPtr)FooterIcon;
			if (CustomFooterIcon != null)
			{
				config.dwFlags |= TASKDIALOG_FLAGS.TDF_USE_HICON_FOOTER;
				config.footerIcon = CustomFooterIcon.Handle;
			}
			else
				config.footerIcon = (IntPtr)FooterIcon;

			if (!string.IsNullOrEmpty(Footer))
				config.pszFooter = Footer;

			config.pfCallbackProc = PrivateCallback;

			config.cxWidth = (uint)Width;

			// The call all this mucking about is here for.
			TaskDialogResult res;
			TaskDialogIndirect(ref config, out res.dialogResult, out res.selectedRadioButton, out res.verificationFlagChecked);
			Result = res;

			return res;
		}

		//private bool ShouldSerializeProgressBar() { return ProgressBar != TaskDialogProgressBar.Default; }

		/// <summary>Results from running the <see cref="TaskDialog"/>.</summary>
		public struct TaskDialogResult
		{
			internal int dialogResult, selectedRadioButton;
			internal bool verificationFlagChecked;

			internal TaskDialogResult(int result, bool verCheck, int selRadio)
			{
				dialogResult = result;
				verificationFlagChecked = verCheck;
				selectedRadioButton = selRadio;
			}

			/// <summary>
			/// Gets the dialog result. This is the value of one of the <see cref="TaskDialogCommonButtons"/> enumerate type or the ID of a <see
			/// cref="TaskDialogButton"/> that has been clicked.
			/// </summary>
			/// <value>The task dialog result.</value>
			public int DialogResult => dialogResult;

			/// <summary>If a radio button was supplied and selected, gets the value of the selected radio button's identifier.</summary>
			/// <value>The selected radio button id. A value of <c>0</c> indicates that no radio button was selected or the task dialog was cancelled.</value>
			public int SelectedRadioButton => selectedRadioButton;

			/// <summary>Gets a value indicating whether the verification flag was checked.</summary>
			/// <value><c>true</c> if verification flag checked; otherwise, <c>false</c>.</value>
			public bool VerificationFlagChecked => verificationFlagChecked;

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString()
				=> $"{dialogResult} : {(verificationFlagChecked ? "checked" : "unchecked")} : {selectedRadioButton}";
		}

		/// <summary>Provides data for the <see cref="ButtonClicked"/> and the <see cref="RadioButtonClicked"/> events.</summary>
		public class ButtonClickedEventArgs : CancelEventArgs
		{
			internal ButtonClickedEventArgs(int id, TaskDialogButtonBase button) { ButtonId = id; Button = button; }

			public TaskDialogButtonBase Button { get; }

			/// <summary>Gets the id of the button clicked.</summary>
			/// <value>The button id.</value>
			public int ButtonId { get; }
		}

		/// <summary>Provides data for the <see cref="Expanded"/> event.</summary>
		public class ExpandedEventArgs : EventArgs
		{
			internal ExpandedEventArgs(bool exp) { Expanded = exp; }

			/// <summary>Gets a value indicating whether the <see cref="TaskDialog"/> is expanded.</summary>
			/// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
			public bool Expanded { get; }
		}

		/// <summary>A custom button for the TaskDialog.</summary>
		[DefaultEvent("Clicked"), DefaultProperty("ButtonId")]
		public abstract class TaskDialogButtonBase : IEquatable<TaskDialogButtonBase>
		{
			internal static int idSeed = 101;
			internal TASKDIALOG_BUTTON nativeButton;
			internal TaskDialog parent;

			/// <summary>Initializes a new instance of the <see cref="TaskDialogButtonBase"/> class.</summary>
			protected TaskDialogButtonBase() : this(null) { }

			/// <summary>Initialize the custom button.</summary>
			/// <param name="id">
			/// The ID of the button. This value is returned by TaskDialog.Show when the button is clicked. Typically this will be a value in the DialogResult enum.
			/// </param>
			/// <param name="text">The string that appears on the button.</param>
			protected TaskDialogButtonBase(string text, int id = -1)
			{
				if (id == -1) id = idSeed++;
				nativeButton.buttonId = id;
				nativeButton.buttonText = text;
			}

			/// <summary>The ID of the button. This value is returned by TaskDialog.Show when the button is clicked.</summary>
			[DefaultValue(0)]
			[Category("Behavior"), Description("")]
			public int ButtonId
			{
				get => nativeButton.buttonId; set => nativeButton.buttonId = value;
			}

			/// <summary>The string that appears on the button.</summary>
			[DefaultValue(null), Localizable(true),
			 Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
			[Category("Appearance"), Description("")]
			public string ButtonText
			{
				get => nativeButton.buttonText; set => nativeButton.buttonText = value;
			}

			/// <summary>Gets or sets a value indicating whether this <see cref="TaskDialogButtonBase"/> is enabled.</summary>
			/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
			[DefaultValue(true)]
			[Category("Appearance"), Description("")]
			public virtual bool Enabled { get; set; } = true;

			/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
			/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
			public override bool Equals(object obj)
			{
				var bb = obj as TaskDialogButtonBase;
				return bb != null ? Equals(bb) : base.Equals(obj);
			}

			/// <summary>Determines whether the specified <see cref="TaskDialogButtonBase"/>, is equal to this instance.</summary>
			/// <param name="other">The <see cref="TaskDialogButtonBase"/> to compare with this instance.</param>
			/// <returns><c>true</c> if the specified <see cref="TaskDialogButtonBase"/> is equal to this instance; otherwise, <c>false</c>.</returns>
			public bool Equals(TaskDialogButtonBase other)
				=> other.nativeButton.buttonId == nativeButton.buttonId && other.nativeButton.buttonText == nativeButton.buttonText;

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => new {a = ButtonId, b = ButtonText}.GetHashCode();

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() => $"{ButtonText} ({ButtonId})";

			[SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
			// Would be unused code as not required for usage.
			[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
			internal struct TASKDIALOG_BUTTON
			{
				/// <summary>The ID of the button. This value is returned by TaskDialog.Show when the button is clicked.</summary>
				public int buttonId;

				/// <summary>The string that appears on the button.</summary>
				[MarshalAs(UnmanagedType.LPWStr)] public string buttonText;
			}
		}

		/// <summary>A collection of <see cref="TaskDialogButton"/> elements.</summary>
		public class TaskDialogButtonCollection<T> : List<T>, IDisposable where T : TaskDialogButtonBase
		{
			private const int hashSeed = 17;
			private IntPtr ptr = IntPtr.Zero;
			private int ptrHash = hashSeed, ptrCount;

			/// <summary>Initializes a new instance of the <see cref="TaskDialogButtonCollection{T}"/> class.</summary>
			internal TaskDialogButtonCollection() { }

			/// <summary>Explicitly converts the <see cref="TaskDialogButtonCollection{T}"/> to an in-memory array.</summary>
			/// <param name="c">The <see cref="TaskDialogButtonCollection{T}"/> instance.</param>
			/// <returns>
			/// An IntPtr pointing to a marshaled memory pointer of the array created with AllocHGlobal. This does not need to be freed as the class maintains it.
			/// </returns>
			public static explicit operator IntPtr(TaskDialogButtonCollection<T> c)
			{
				// Get hash for set
				var h = hashSeed;
				unchecked
				{
					foreach (var item in c)
						h = h*23 + item.GetHashCode();
				}

				// If new has doesn't equal old hash, reset IntPtr
				if (h != c.ptrHash)
				{
					// Clean up old array
					((IDisposable)c).Dispose();

					// Build new
					if (c.Count > 0)
					{
						var elementSize = Marshal.SizeOf(typeof(TaskDialogButtonBase.TASKDIALOG_BUTTON));
						c.ptrCount = c.Count;
						c.ptr = Marshal.AllocHGlobal(elementSize*c.ptrCount);
						for (var i = 0; i < c.ptrCount; i++)
							Marshal.StructureToPtr(c[i].nativeButton, c.ptr.Offset(i*elementSize), false);
					}

					// Set hash to new value
					c.ptrHash = h;
				}

				return c.ptr;
			}

			/// <summary>Clears this instance.</summary>
			public new void Clear()
			{
				base.Clear();
				((IDisposable)this).Dispose();
			}

			/// <summary>Releases unmanaged and managed resources.</summary>
			void IDisposable.Dispose()
			{
				if (ptr == IntPtr.Zero) return;
				lock (this)
				{
					var elementSize = Marshal.SizeOf(typeof(TaskDialogButtonBase.TASKDIALOG_BUTTON));
					for (var i = 0; i < ptrCount; i++)
						Marshal.DestroyStructure(ptr.Offset(i*elementSize), typeof(TaskDialogButtonBase.TASKDIALOG_BUTTON));
					Marshal.FreeHGlobal(ptr);
					ptr = IntPtr.Zero;
					ptrHash = hashSeed;
					ptrCount = 0;
				}
			}
		}

		[TypeConverter(typeof(BetterExpandableObjectConverter)), Serializable]
		public class TaskDialogProgressBar
		{
			private readonly TaskDialog taskDialog;
			private short max = 100, min;
			private int mSpeed = 100, val;
			private ProgressBarState state = ProgressBarState.Normal;
			private ProgressBarStyle style = ProgressBarStyle.Continuous;

			internal TaskDialogProgressBar(TaskDialog td) { taskDialog = td; }

			[DefaultValue(100)]
			public int MarqueeAnimationSpeed
			{
				get => mSpeed; set { if (mSpeed != value) SetMarqueeSpeed(mSpeed = value); }
			}

			[DefaultValue((short)100)]
			public short Maximum
			{
				get => max; set
				{
					if (max == value) return;
					max = value;
					SetProgressBarRange();
				}
			}

			[DefaultValue((short)0)]
			public short Minimum
			{
				get => min; set
				{
					if (min == value) return;
					min = value;
					SetProgressBarRange();
				}
			}

			[DefaultValue(typeof(ProgressBarState), "Normal")]
			public ProgressBarState State
			{
				get => state; set { if (state != value) SetState(state = value); }
			}

			[DefaultValue(typeof(ProgressBarStyle), "Continuous")]
			public ProgressBarStyle Style
			{
				get => style; set
				{
					if (style != value)
					{
						if (value == ProgressBarStyle.Blocks)
							throw new NotSupportedException("TaskDialog does not support Block style progress bars.");
						style = value;
						if (taskDialog == null) return;
						var cont = (style == ProgressBarStyle.Continuous);
						taskDialog.ShowProgressBar = cont;
						taskDialog.ShowMarqueeProgressBar = !cont;
						if (taskDialog.handle != IntPtr.Zero)
							SendMessage(new HandleRef(taskDialog, taskDialog.handle), (uint)TaskDialogMessage.TDM_SET_MARQUEE_PROGRESS_BAR,
								(value == ProgressBarStyle.Marquee ? (IntPtr)1 : IntPtr.Zero), IntPtr.Zero);
					}
				}
			}

			[DefaultValue(0)]
			public int Value
			{
				get => val; set { if (val != value) SetValue(val = value); }
			}

			[DefaultValue(false)]
			public bool Visible
			{
				get => taskDialog != null && (taskDialog.ShowProgressBar || taskDialog.ShowMarqueeProgressBar); set
				{
					if (!value || taskDialog == null) return;
					if (style == ProgressBarStyle.Continuous)
						taskDialog.ShowProgressBar = true;
					else
						taskDialog.ShowMarqueeProgressBar = true;
				}
			}

			internal void Initialize()
			{
				if (Visible)
				{
					if (Style == ProgressBarStyle.Marquee)
					{
						SetMarqueeSpeed(mSpeed);
					}
					else
					{
						SetProgressBarRange();
						SetValue(val);
					}
					SetState(state);
				}
			}

			internal void Reset()
			{
				mSpeed = max = 100;
				val = min = 0;
				state = ProgressBarState.Normal;
				style = ProgressBarStyle.Continuous;
			}

			private static uint MakeLong(short low, short high) => ((ushort)low | (uint)(high << 16));

			private void SetMarqueeSpeed(int value)
			{
				if (taskDialog != null && taskDialog.handle != IntPtr.Zero)
					SendMessage(new HandleRef(taskDialog, taskDialog.handle), (uint)TaskDialogMessage.TDM_SET_PROGRESS_BAR_MARQUEE, (IntPtr)(value != 0 ? 1 : 0),
						(IntPtr)value);
			}

			private void SetProgressBarRange()
			{
				if (taskDialog != null && taskDialog.handle != IntPtr.Zero)
					SendMessage(new HandleRef(taskDialog, taskDialog.handle), (uint)TaskDialogMessage.TDM_SET_PROGRESS_BAR_RANGE, IntPtr.Zero,
						(IntPtr)MakeLong(min, max));
			}

			private void SetState(ProgressBarState value)
			{
				if (taskDialog != null && taskDialog.handle != IntPtr.Zero)
					SendMessage(new HandleRef(taskDialog, taskDialog.handle), (uint)TaskDialogMessage.TDM_SET_PROGRESS_BAR_STATE, (IntPtr)value, IntPtr.Zero);
			}

			private void SetValue(int value)
			{
				if (taskDialog != null && taskDialog.handle != IntPtr.Zero)
					SendMessage(new HandleRef(taskDialog, taskDialog.handle), (uint)TaskDialogMessage.TDM_SET_PROGRESS_BAR_POS, (IntPtr)value, IntPtr.Zero);
			}
		}

		/// <summary>Provides data for the <see cref="Timer"/> event.</summary>
		public class TimerEventArgs : EventArgs
		{
			internal TimerEventArgs(int ticks) { TickCount = ticks; }

			/// <summary>Gets or sets a value indicating whether to reset the tick count.</summary>
			/// <value><c>true</c> to reset tick count; otherwise, <c>false</c> to continue to increment.</value>
			public bool Reset { get; set; } = false;

			/// <summary>Gets the tick count for this instance of the <see cref="TaskDialog"/>.</summary>
			/// <value>The tick count.</value>
			public int TickCount { get; }
		}

		/// <summary>Provides data for the <see cref="VerificationClicked"/> event.</summary>
		public class VerificationClickedEventArgs : EventArgs
		{
			internal VerificationClickedEventArgs(bool check) { Checked = check; }

			/// <summary>Gets a value indicating whether the verification check box is checked.</summary>
			/// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
			public bool Checked { get; }
		}
	}

	public class TaskDialogButton : TaskDialog.TaskDialogButtonBase
	{
		private bool shield;

		/// <summary>Initializes a new instance of the <see cref="TaskDialogButton"/> class.</summary>
		public TaskDialogButton() : this(null) { }

		/// <summary>Initialize the custom button.</summary>
		/// <param name="text">The string that appears on the button.</param>
		/// <param name="id">
		/// The ID of the button. This value is returned by TaskDialog.Show when the button is clicked. Typically this will be a value in the DialogResult enum.
		/// Specifying a value of (-1) will insert a potentially non-unique value.
		/// </param>
		public TaskDialogButton(string text, int id = -1) : base(text, id)
		{
			if (ButtonText == null) ButtonText = $"Button{ButtonId}";
		}

		/// <summary>Occurs when the button is clicked.</summary>
		[Category("Action"), Description("")]
		public event CancelEventHandler Click;

		/// <summary>
		/// Gets or sets a value indicating whether to close the <see cref="TaskDialog"/> on click and returns this button's <see
		/// cref="TaskDialog.TaskDialogButtonBase.ButtonId"/> as the result.
		/// </summary>
		/// <value><c>true</c> if dialog closes on click; otherwise, <c>false</c>.</value>
		[DefaultValue(true)]
		[Category("Behavior"), Description("")]
		public bool CloseOnClick { get; set; } = true;

		/// <summary>Gets or sets a value indicating whether button shows elevated state shield.</summary>
		/// <value><c>true</c> if elevated state shield displayed; otherwise, <c>false</c>.</value>
		[DefaultValue(false)]
		[Category("Appearance"), Description("")]
		public bool ElevatedStateRequired
		{
			get => shield; set
			{
				if (shield != value)
				{
					parent?.SetButtonElevationRequiredState(ButtonId, value);
					shield = value;
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether this <see cref="TaskDialogButton"/> is enabled.</summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		[DefaultValue(true)]
		public override bool Enabled
		{
			get => base.Enabled; set
			{
				if (base.Enabled != value)
				{
					parent?.EnableButton(ButtonId, value);
					base.Enabled = value;
				}
			}
		}

		/// <summary>Raises the <see cref="E:Click"/> event.</summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		public void OnClick(CancelEventArgs e)
		{
			e.Cancel = !CloseOnClick;
			Click?.Invoke(this, e);
		}

		/// <summary>Generates a <see cref="Click"/> event for the button.</summary>
		public void PerformClick() => parent?.PerformButtonClick(ButtonId);
	}

	public class TaskDialogRadioButton : TaskDialog.TaskDialogButtonBase
	{
		/// <summary>Initializes a new instance of the <see cref="TaskDialogButton"/> class.</summary>
		public TaskDialogRadioButton() : this(null) { }

		/// <summary>Initialize the custom radio button.</summary>
		/// <param name="text">The string that appears on the radio button.</param>
		/// <param name="id">
		/// The ID of the readio button. This value is returned by TaskDialog.Show when the button is clicked. Specifying a value of (-1) will insert a
		/// potentially non-unique value.
		/// </param>
		public TaskDialogRadioButton(string text, int id = -1) : base(text, id)
		{
			if (ButtonText == null) ButtonText = $"RadioButton{ButtonId}";
		}

		/// <summary>Occurs when the radio button is clicked.</summary>
		public event EventHandler Click;

		/// <summary>Gets or sets a value indicating whether this <see cref="TaskDialogRadioButton"/> is enabled.</summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		[DefaultValue(true)]
		public override bool Enabled
		{
			get => base.Enabled; set
			{
				if (base.Enabled != value)
				{
					parent?.EnableRadioButton(ButtonId, value);
					base.Enabled = value;
				}
			}
		}

		/// <summary>Raises the <see cref="E:Click"/> event.</summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		public void OnClick(EventArgs e)
		{
			Click?.Invoke(this, e);
		}

		/// <summary>Generates a <see cref="Click"/> event for the button.</summary>
		public void PerformClick()
		{
			parent?.PerformRadioButtonClick(ButtonId);
		}
	}
}