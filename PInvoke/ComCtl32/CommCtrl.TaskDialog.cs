using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>The signature of the callback that receives messages from the Task Dialog when various events occur.</summary>
		/// <param name="hwnd">The window handle of the</param>
		/// <param name="msg">The message being passed.</param>
		/// <param name="wParam">wParam which is interpreted differently depending on the message.</param>
		/// <param name="lParam">wParam which is interpreted differently depending on the message.</param>
		/// <param name="refData">The reference data that was set to TaskDialog.CallbackData.</param>
		/// <returns>A HRESULT value. The return value is specific to the message being processed.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760542")]
		public delegate HRESULT TaskDialogCallbackProc([In] IntPtr hwnd, [In] TaskDialogNotification msg, [In] IntPtr wParam, [In] IntPtr lParam, [In] IntPtr refData);

		/// <summary>Specifies the push buttons displayed in the task dialog. If no common buttons are specified and no custom buttons are specified using the cButtons and pButtons members, the task dialog will contain the OK button by default. This parameter may be a combination of flags</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760540")]
		[Flags]
		public enum TASKDIALOG_COMMON_BUTTON_FLAGS
		{
			/// <summary>The task dialog contains the push button: OK.</summary>
			TDCBF_OK_BUTTON = 0x0001,

			/// <summary>The task dialog contains the push button: Yes.</summary>
			TDCBF_YES_BUTTON = 0x0002,

			/// <summary>The task dialog contains the push button: No.</summary>
			TDCBF_NO_BUTTON = 0x0004,

			/// <summary>
			/// The task dialog contains the push button: Cancel. If this button is specified, the task dialog will respond to typical cancel actions (Alt-F4 and Escape).
			/// </summary>
			TDCBF_CANCEL_BUTTON = 0x0008,

			/// <summary>The task dialog contains the push button: Retry.</summary>
			TDCBF_RETRY_BUTTON = 0x0010,

			/// <summary>The task dialog contains the push button: Close.</summary>
			TDCBF_CLOSE_BUTTON = 0x0020,
		}

		/// <summary>Indicates element to update for the TDM_UPDATE_ELEMENT_TEXT message.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760536")]
		public enum TASKDIALOG_ELEMENTS
		{
			/// <summary>The content element.</summary>
			TDE_CONTENT,

			/// <summary>Expanded Information.</summary>
			TDE_EXPANDED_INFORMATION,

			/// <summary>Footer.</summary>
			TDE_FOOTER,

			/// <summary>Main Instructions</summary>
			TDE_MAIN_INSTRUCTION
		}

		/// <summary>Specifies the behavior of the task dialog.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787473")]
		[Flags]
		public enum TASKDIALOG_FLAGS
		{
			/// <summary>Enables hyperlink processing for the strings specified in the pszContent, pszExpandedInformation and pszFooter members. When enabled, these members may point to strings that contain hyperlinks in the following form:
			/// <code><![CDATA[<A HREF = "executablestring" > Hyperlink Text</A>]]></code>
			/// <note type="warning">Enabling hyperlinks when using content from an unsafe source may cause security vulnerabilities.</note>
			/// <note>Task Dialogs will not actually execute any hyperlinks.Hyperlink execution must be handled in the callback function specified by pfCallback.For more details, see TaskDialogCallbackProc.</note></summary>
			TDF_ENABLE_HYPERLINKS = 0x0001,

			/// <summary>Indicates that the dialog should use the icon referenced by the handle in the hMainIcon member as the primary icon in the task dialog. If this flag is specified, the pszMainIcon member is ignored.</summary>
			TDF_USE_HICON_MAIN = 0x0002,

			/// <summary>Indicates that the dialog should use the icon referenced by the handle in the hFooterIcon member as the footer icon in the task dialog. If this flag is specified, the pszFooterIcon member is ignored.</summary>
			TDF_USE_HICON_FOOTER = 0x0004,

			/// <summary>Indicates that the dialog should be able to be closed using Alt-F4, Escape, and the title bar's close button even if no cancel button is specified in either the dwCommonButtons or pButtons members.</summary>
			TDF_ALLOW_DIALOG_CANCELLATION = 0x0008,

			/// <summary>Indicates that the buttons specified in the pButtons member are to be displayed as command links (using a standard task dialog glyph) instead of push buttons. When using command links, all characters up to the first new line character in the pszButtonText member will be treated as the command link's main text, and the remainder will be treated as the command link's note. This flag is ignored if the cButtons member is zero.</summary>
			TDF_USE_COMMAND_LINKS = 0x0010,

			/// <summary>Indicates that the buttons specified in the pButtons member are to be displayed as command links (without a glyph) instead of push buttons. When using command links, all characters up to the first new line character in the pszButtonText member will be treated as the command link's main text, and the remainder will be treated as the command link's note. This flag is ignored if the cButtons member is zero.</summary>
			TDF_USE_COMMAND_LINKS_NO_ICON = 0x0020,

			/// <summary>Indicates that the string specified by the pszExpandedInformation member is displayed at the bottom of the dialog's footer area instead of immediately after the dialog's content. This flag is ignored if the pszExpandedInformation member is NULL.</summary>
			TDF_EXPAND_FOOTER_AREA = 0x0040,

			/// <summary>Indicates that the string specified by the pszExpandedInformation member is displayed when the dialog is initially displayed. This flag is ignored if the pszExpandedInformation member is NULL.</summary>
			TDF_EXPANDED_BY_DEFAULT = 0x0080,

			/// <summary>Indicates that the verification checkbox in the dialog is checked when the dialog is initially displayed. This flag is ignored if the pszVerificationText parameter is NULL.</summary>
			TDF_VERIFICATION_FLAG_CHECKED = 0x0100,

			/// <summary>Indicates that a Progress Bar is to be displayed.</summary>
			TDF_SHOW_PROGRESS_BAR = 0x0200,

			/// <summary>Indicates that an Marquee Progress Bar is to be displayed.</summary>
			TDF_SHOW_MARQUEE_PROGRESS_BAR = 0x0400,

			/// <summary>Indicates that the task dialog's callback is to be called approximately every 200 milliseconds.</summary>
			TDF_CALLBACK_TIMER = 0x0800,

			/// <summary>Indicates that the task dialog is positioned (centered) relative to the window specified by hwndParent. If the flag is not supplied (or no hwndParent member is specified), the task dialog is positioned (centered) relative to the monitor.</summary>
			TDF_POSITION_RELATIVE_TO_WINDOW = 0x1000,

			/// <summary>Indicates that text is displayed reading right to left.</summary>
			TDF_RTL_LAYOUT = 0x2000,

			/// <summary>Indicates that no default item will be selected.</summary>
			TDF_NO_DEFAULT_RADIO_BUTTON = 0x4000,

			/// <summary>Indicates that the task dialog can be minimized.</summary>
			TDF_CAN_BE_MINIMIZED = 0x8000,

			/// <summary>Don't call SetForegroundWindow() when activating the dialog.</summary>
			TDF_NO_SET_FOREGROUND = 0x00010000,

			/// <summary>
			/// Indicates that the width of the task dialog is determined by the width of its content area. This flag is ignored if cxWidth is not set to 0.
			/// </summary>
			TDF_SIZE_TO_CONTENT = 0x01000000
		}

		/// <summary>Indicates which icon element to update for the TDM_UPDATE_ICON message.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760538")]
		public enum TASKDIALOG_ICON_ELEMENTS
		{
			/// <summary>Main instruction icon.</summary>
			TDIE_ICON_MAIN,

			/// <summary>Footer icon.</summary>
			TDIE_ICON_FOOTER
		}

		/// <summary>TaskDialogMessage taken from CommCtrl.h.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787473")]
		public enum TaskDialogMessage : uint
		{
			/// <summary>Navigate page.</summary>
			TDM_NAVIGATE_PAGE = WindowMessage.WM_USER + 101,

			/// <summary>Click button.</summary>
			TDM_CLICK_BUTTON = WindowMessage.WM_USER + 102, // wParam = Button ID

			/// <summary>Set Progress bar to be marquee mode.</summary>
			TDM_SET_MARQUEE_PROGRESS_BAR = WindowMessage.WM_USER + 103, // wParam = 0 (nonMarque) wParam != 0 (Marquee)

			/// <summary>Set Progress bar state.</summary>
			TDM_SET_PROGRESS_BAR_STATE = WindowMessage.WM_USER + 104, // wParam = new progress state

			/// <summary>Set progress bar range.</summary>
			TDM_SET_PROGRESS_BAR_RANGE = WindowMessage.WM_USER + 105, // lParam = MAKELPARAM(nMinRange, nMaxRange)

			/// <summary>Set progress bar position.</summary>
			TDM_SET_PROGRESS_BAR_POS = WindowMessage.WM_USER + 106, // wParam = new position

			/// <summary>Set progress bar marquee (animation).</summary>
			TDM_SET_PROGRESS_BAR_MARQUEE = WindowMessage.WM_USER + 107, // wParam = 0 (stop marquee), wParam != 0 (start marquee), lparam = speed (milliseconds between repaints)

			/// <summary>Set a text element of the Task Dialog.</summary>
			TDM_SET_ELEMENT_TEXT = WindowMessage.WM_USER + 108, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)

			/// <summary>Click a radio button.</summary>
			TDM_CLICK_RADIO_BUTTON = WindowMessage.WM_USER + 110, // wParam = Radio Button ID

			/// <summary>Enable or disable a button.</summary>
			TDM_ENABLE_BUTTON = WindowMessage.WM_USER + 111, // lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID

			/// <summary>Enable or disable a radio button.</summary>
			TDM_ENABLE_RADIO_BUTTON = WindowMessage.WM_USER + 112, // lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID

			/// <summary>Check or uncheck the verification checkbox.</summary>
			TDM_CLICK_VERIFICATION = WindowMessage.WM_USER + 113, // wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)

			/// <summary>Update the text of an element (no effect if originally set as null).</summary>
			TDM_UPDATE_ELEMENT_TEXT = WindowMessage.WM_USER + 114, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)

			/// <summary>Designate whether a given Task Dialog button or command link should have a User Account Control (UAC) shield icon.</summary>
			TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE = WindowMessage.WM_USER + 115, // wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)

			/// <summary>Refreshes the icon of the task dialog.</summary>
			TDM_UPDATE_ICON = WindowMessage.WM_USER + 116 // wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
		}

		/// <summary>The System icons the TaskDialog supports for <see cref="TASKDIALOGCONFIG.footerIcon"/> and <see cref="TASKDIALOGCONFIG.mainIcon"/>.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787473")]
		[SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")] // Type comes from CommCtrl.h
		public enum TaskDialogIcon : uint
		{
			/// <summary>An exclamation-point icon appears in the task dialog.</summary>
			TD_WARNING_ICON = 0xFFFF, // MAKEINTRESOURCEW(-1)

			/// <summary>A stop-sign icon appears in the task dialog.</summary>
			TD_ERROR_ICON = 0xFFFE, // MAKEINTRESOURCEW(-2)

			/// <summary>An icon consisting of a lowercase letter i in a circle appears in the task dialog.</summary>
			TD_INFORMATION_ICON = 0xFFFD, // MAKEINTRESOURCEW(-3)

			/// <summary>A shield icon appears in the task dialog.</summary>
			TD_SHIELD_ICON = 0xFFFC, // MAKEINTRESOURCEW(-4)

			/// <summary>Shield icon on a blue background. Only available on Windows 8 and later.</summary>
			TD_SHIELDBLUE_ICON = 0xFFFB, // MAKEINTRESOURCEW(-5)

			/// <summary>Warning Shield icon on a yellow background. Only available on Windows 8 and later.</summary>
			TD_SECURITYWARNING_ICON = 0xFFFA, // MAKEINTRESOURCEW(-6)

			/// <summary>Error Shield icon on a red background. Only available on Windows 8 and later.</summary>
			TD_SECURITYERROR_ICON = 0xFFF9, // MAKEINTRESOURCEW(-7)

			/// <summary>Success Shield icon on a green background. Only available on Windows 8 and later.</summary>
			TD_SECURITYSUCCESS_ICON = 0xFFF8, // MAKEINTRESOURCEW(-8)

			/// <summary>Shield icon on a gray background. Only available on Windows 8 and later.</summary>
			TD_SHIELDGRAY_ICON = 0xFFF7, // MAKEINTRESOURCEW(-9)
		}

		/// <summary>Task Dialog callback notifications.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787473")]
		public enum TaskDialogNotification : uint
		{
			/// <summary>Sent by the task dialog after the dialog has been created and before it is displayed. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.</summary>
			TDN_CREATED = 0,

			/// <summary>
			/// Sent by a task dialog when navigation has occurred. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.
			/// </summary>
			TDN_NAVIGATED = 1,

			/// <summary>
			/// Sent by a task dialog when the user selects a button or command link in the task dialog. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method. To prevent the task dialog from closing, the application must return S_FALSE, otherwise the task dialog is closed and the button ID is returned via the original application call.
			/// </summary>
			TDN_BUTTON_CLICKED = 2,

			/// <summary>
			/// Sent by a task dialog when the user clicks a hyperlink in the task dialog content. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.
			/// </summary>
			TDN_HYPERLINK_CLICKED = 3,

			/// <summary>
			/// Sent by a task dialog approximately every 200 milliseconds. This notification code is sent when the TDF_CALLBACK_TIMER flag has been set in the dwFlags member of the TASKDIALOGCONFIG structure that was passed to the TaskDialogIndirect function. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.
			/// </summary>
			TDN_TIMER = 4,

			/// <summary>Sent by a task dialog when it is destroyed and its window handle is no longer valid. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.</summary>
			TDN_DESTROYED = 5,

			/// <summary>
			/// Sent by a task dialog when the user selects a radio button or command link in the task dialog. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.
			/// </summary>
			TDN_RADIO_BUTTON_CLICKED = 6,

			/// <summary>Sent by a task dialog after the dialog has been created and before it is displayed. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.</summary>
			TDN_DIALOG_CONSTRUCTED = 7,

			/// <summary>
			/// Sent by a task dialog when the user clicks the task dialog verification check box. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.
			/// </summary>
			TDN_VERIFICATION_CLICKED = 8,

			/// <summary>
			/// Sent by a task dialog when the user presses F1 on the keyboard while the dialog has focus. This notification code is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.
			/// </summary>
			TDN_HELP = 9,

			/// <summary>
			/// Sent by the task dialog when the user clicks on the dialog's expando button. This notification is received only through the task dialog callback function, which can be registered using the TaskDialogIndirect method.
			/// </summary>
			TDN_EXPANDO_BUTTON_CLICKED = 10
		}

		/// <summary>
		/// The TaskDialog function creates, displays, and operates a task dialog. The task dialog contains application-defined message text and title, icons, and any combination of predefined push buttons. This function does not support the registration of a callback function to receive notifications.
		/// </summary>
		/// <param name="hwndParent">Handle to the owner window of the task dialog to be created. If this parameter is NULL, the task dialog has no owner window.</param>
		/// <param name="hInstance">Handle to the module that contains the icon resource identified by the pszIcon member, and the string resources identified by the pszWindowTitle and pszMainInstruction members. If this parameter is NULL, pszIcon must be NULL or a pointer to a null-terminated, Unicode string that contains a system resource identifier, for example, TD_ERROR_ICON.</param>
		/// <param name="pszWindowTitle">Pointer to the string to be used for the task dialog title. This parameter is a null-terminated, Unicode string that contains either text, or an integer resource identifier passed through the MAKEINTRESOURCE macro. If this parameter is NULL, the filename of the executable program is used.</param>
		/// <param name="pszMainInstruction">Pointer to the string to be used for the main instruction. This parameter is a null-terminated, Unicode string that contains either text, or an integer resource identifier passed through the MAKEINTRESOURCE macro. This parameter can be NULL if no main instruction is wanted.</param>
		/// <param name="pszContent">Pointer to a string used for additional text that appears below the main instruction, in a smaller font. This parameter is a null-terminated, Unicode string that contains either text, or an integer resource identifier passed through the MAKEINTRESOURCE macro. Can be NULL if no additional text is wanted.</param>
		/// <param name="dwCommonButtons">Specifies the push buttons displayed in the dialog box. This parameter may be a combination of flags from the following group.</param>
		/// <param name="pszIcon">Pointer to a string that identifies the icon to display in the task dialog. This parameter must be an integer resource identifier passed to the MAKEINTRESOURCE macro or one of the following predefined values. If this parameter is NULL, no icon will be displayed. If the hInstance parameter is NULL and one of the predefined values is not used, the TaskDialog function fails.</param>
		/// <param name="pnButton">When this function returns, contains a pointer to an integer location that receives one of the standard button result values.</param>
		/// <returns>This function can return one of these values.
		/// <list type="table">
		/// <listheader><term>Return code</term><term>Description</term></listheader>
		/// <item><term>S_OK</term><term>The operation completed successfully.</term></item>
		/// <item><term>E_OUTOFMEMORY</term><term>There is insufficient memory to complete the operation.</term></item>
		/// <item><term>E_INVALIDARG</term><term>One or more arguments are not valid.</term></item>
		/// <item><term>E_FAIL</term><term>The operation failed.</term></item>
		/// </list>
		/// </returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760540")]
		[DllImport(Lib.ComCtl32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern HRESULT TaskDialog(HandleRef hwndParent, SafeLibraryHandle hInstance, string pszWindowTitle, string pszMainInstruction, string pszContent, TASKDIALOG_COMMON_BUTTON_FLAGS dwCommonButtons, IntPtr pszIcon, out int pnButton);

		/// <summary>The TaskDialogIndirect function creates, displays, and operates a task dialog. The task dialog contains application-defined icons, messages, title, verification check box, command links, push buttons, and radio buttons. This function can register a callback function to receive notification messages.</summary>
		/// <param name="pTaskConfig">Pointer to a TASKDIALOGCONFIG structure that contains information used to display the task dialog.</param>
		/// <param name="pnButton">Address of a variable that receives one of the button IDs specified in the pButtons member of the pTaskConfig parameter or a standard button ID value.</param>
		/// <param name="pnRadioButton">Address of a variable that receives one of the button IDs specified in the pRadioButtons member of the pTaskConfig parameter. If this parameter is NULL, no value is returned.</param>
		/// <param name="pfVerificationFlagChecked">Address of a variable that receives a value indicating if the verification checkbox was checked when the dialog was dismissed.</param>
		/// <returns>This function can return one of these values.
		/// <list type="table">
		/// <listheader><term>Return code</term><term>Description</term></listheader>
		/// <item><term>S_OK</term><term>The operation completed successfully.</term></item>
		/// <item><term>E_OUTOFMEMORY</term><term>There is insufficient memory to complete the operation.</term></item>
		/// <item><term>E_INVALIDARG</term><term>One or more arguments are not valid.</term></item>
		/// <item><term>E_FAIL</term><term>The operation failed.</term></item>
		/// </list>
		/// </returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760544")]
		[DllImport(Lib.ComCtl32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern HRESULT TaskDialogIndirect(ref TASKDIALOGCONFIG pTaskConfig, out int pnButton, out int pnRadioButton, [MarshalAs(UnmanagedType.Bool)] out bool pfVerificationFlagChecked);

		/// <summary>
		/// The TASKDIALOG_BUTTON structure contains information used to display a button in a task dialog. The TASKDIALOGCONFIG structure uses this structure.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787475")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TASKDIALOG_BUTTON
		{
			/// <summary>Indicates the value to be returned when this button is selected.</summary>
			public int nButtonID;
			/// <summary>Pointer that references the string to be used to label the button. This parameter can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. When using Command Links, you delineate the command from the note by placing a new line character in the string.</summary>
			public ResourceIdUni pszButtonText;
		}

		/// <summary>The TASKDIALOGCONFIG structure contains information used to display a task dialog. The TaskDialogIndirect function uses this structure.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787473")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
		public struct TASKDIALOGCONFIG
		{
			/// <summary>Specifies the structure size, in bytes.</summary>
			public uint cbSize;

			/// <summary>Handle to the parent window. This member can be NULL.</summary>
			[SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
			public IntPtr hwndParent;

			/// <summary>Handle to the module that contains the icon resource identified by the pszMainIcon or pszFooterIcon members, and the string resources identified by the pszWindowTitle, pszMainInstruction, pszContent, pszVerificationText, pszExpandedInformation, pszExpandedControlText, pszCollapsedControlText or pszFooter members.</summary>
			[SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
			public IntPtr hInstance;

			/// <summary>Specifies the behavior of the task dialog. This parameter can be a combination of flags.</summary>
			public TASKDIALOG_FLAGS dwFlags;

			/// <summary>Specifies the push buttons displayed in the task dialog. If no common buttons are specified and no custom buttons are specified using the cButtons and pButtons members, the task dialog will contain the OK button by default. This parameter may be a combination of flags.</summary>
			public TASKDIALOG_COMMON_BUTTON_FLAGS dwCommonButtons;

			/// <summary>Pointer that references the string to be used for the task dialog title. This parameter can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. If this parameter is NULL, the filename of the executable program is used.</summary>
			public ResourceIdUni pszWindowTitle;

			/// <summary>A handle to an Icon that is to be displayed in the task dialog. This member is ignored unless the TDF_USE_HICON_MAIN flag is specified. If this member is NULL and the TDF_USE_HICON_MAIN is specified, no icon will be displayed.
			/// <para><c>OR</c></para>
			/// <para>Pointer that references the icon to be displayed in the task dialog. This parameter is ignored if the USE_HICON_MAIN flag is specified. Otherwise, if this parameter is NULL or the hInstance parameter is NULL, no icon will be displayed. This parameter must be an integer resource identifier passed to the MAKEINTRESOURCE macro.</para>
			/// </summary>
			[SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
			public ResourceIdUni mainIcon;

			/// <summary>Pointer that references the string to be used for the main instruction. This parameter can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro.</summary>
			public ResourceIdUni pszMainInstruction;

			/// <summary>Pointer that references the string to be used for the dialog's primary content. This parameter can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. If the ENABLE_HYPERLINKS flag is specified for the dwFlags member, then this string may contain hyperlinks in the form: <A HREF="executablestring">Hyperlink Text</A>. WARNING: Enabling hyperlinks when using content from an unsafe source may cause security vulnerabilities.</summary>
			public ResourceIdUni pszContent;

			/// <summary>The number of entries in the pButtons array that is used to create buttons or command links in the task dialog. If this member is zero and no common buttons have been specified using the dwCommonButtons member, then the task dialog will have a single OK button displayed.</summary>
			public uint cButtons;

			/// <summary>Pointer to an array of TASKDIALOG_BUTTON structures containing the definition of the custom buttons that are to be displayed in the task dialog. This array must contain at least the number of entries that are specified by the cButtons member.</summary>
			[SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
			public IntPtr pButtons;

			/// <summary>The default button for the task dialog. This may be any of the values specified in nButtonID members of one of the TASKDIALOG_BUTTON structures in the pButtons array, or one of the IDs corresponding to the buttons specified in the dwCommonButtons member. If this member is zero or its value does not correspond to any button ID in the dialog, then the first button in the dialog will be the default.</summary>
			public int nDefaultButton;

			/// <summary>The number of entries in the pRadioButtons array that is used to create radio buttons in the task dialog.</summary>
			public uint cRadioButtons;

			/// <summary>Pointer to an array of TASKDIALOG_BUTTON structures containing the definition of the radio buttons that are to be displayed in the task dialog. This array must contain at least the number of entries that are specified by the cRadioButtons member. This parameter can be NULL.</summary>
			[SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
			public IntPtr pRadioButtons;

			/// <summary>The button ID of the radio button that is selected by default. If this value does not correspond to a button ID, the first button in the array is selected by default.</summary>
			public int nDefaultRadioButton;

			/// <summary>Pointer that references the string to be used to label the verification checkbox. This parameter can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. If this parameter is NULL, the verification checkbox is not displayed in the task dialog. If the pfVerificationFlagChecked parameter of TaskDialogIndirect is NULL, the checkbox is not enabled.</summary>
			public ResourceIdUni pszVerificationText;

			/// <summary>Pointer that references the string to be used for displaying additional information. This parameter can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. The additional information is displayed either immediately below the content or below the footer text depending on whether the TDF_EXPAND_FOOTER_AREA flag is specified. If the TDF_ENABLE_HYPERLINKS flag is specified for the dwFlags member, then this string may contain hyperlinks in the form: <A HREF="executablestring">Hyperlink Text</A>. WARNING: Enabling hyperlinks when using content from an unsafe source may cause security vulnerabilities.</summary>
			public ResourceIdUni pszExpandedInformation;

			/// <summary>Pointer that references the string to be used to label the button for collapsing the expandable information. This parameter can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. This member is ignored when the pszExpandedInformation member is NULL. If this member is NULL and the pszCollapsedControlText is specified, then the pszCollapsedControlText value will be used for this member as well.</summary>
			public ResourceIdUni pszExpandedControlText;

			/// <summary>Pointer that references the string to be used to label the button for expanding the expandable information. This parameter can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. This member is ignored when the pszExpandedInformation member is NULL. If this member is NULL and the pszCollapsedControlText is specified, then the pszCollapsedControlText value will be used for this member as well.</summary>
			public ResourceIdUni pszCollapsedControlText;

			/// <summary>A handle to an Icon that is to be displayed in the footer of the task dialog. This member is ignored unless the TDF_USE_HICON_FOOTER flag is specified and the pszFooterIcon is not. If this member is NULL and the TDF_USE_HICON_FOOTER is specified, no icon is displayed.
			/// <para><c>OR</c></para>
			/// <para>Pointer that references the icon to be displayed in the footer area of the task dialog. This parameter is ignored if the TDF_USE_HICON_FOOTER flag is specified, or if pszFooter is NULL. Otherwise, if this parameter is NULL or the hInstance parameter is NULL, no icon is displayed. This parameter must be an integer resource identifier passed to the MAKEINTRESOURCE macro or one of the predefined values listed for pszMainIcon.</para>
			/// </summary>
			[SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
			public ResourceIdUni footerIcon;

			/// <summary>Pointer that references the icon to be displayed in the footer area of the task dialog. This parameter is ignored if the TDF_USE_HICON_FOOTER flag is specified, or if pszFooter is NULL. Otherwise, if this parameter is NULL or the hInstance parameter is NULL, no icon is displayed. This parameter must be an integer resource identifier passed to the MAKEINTRESOURCE macro or one of the predefined values listed for pszMainIcon.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public ResourceIdUni pszFooter;

			/// <summary>Pointer to an application-defined callback function. For more information see TaskDialogCallbackProc.</summary>
			public TaskDialogCallbackProc pfCallbackProc;

			/// <summary>A pointer to application-defined reference data. This value is defined by the caller.</summary>
			[SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
			public IntPtr lpCallbackData;

			/// <summary>The width of the task dialog's client area, in dialog units. If 0, the task dialog manager will calculate the ideal width.</summary>
			public uint cxWidth;
		}
	}
}