using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.User32;

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
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate HRESULT TaskDialogCallbackProc([In] HWND hwnd, [In] TaskDialogNotification msg, [In] IntPtr wParam, [In] IntPtr lParam, [In] IntPtr refData);

		/// <summary>
		/// Specifies the push buttons displayed in the task dialog. If no common buttons are specified and no custom buttons are specified
		/// using the cButtons and pButtons members, the task dialog will contain the OK button by default. This parameter may be a
		/// combination of flags
		/// </summary>
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
			/// The task dialog contains the push button: Cancel. If this button is specified, the task dialog will respond to typical cancel
			/// actions (Alt-F4 and Escape).
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
			/// <summary>
			/// Enables hyperlink processing for the strings specified in the pszContent, pszExpandedInformation and pszFooter members. When
			/// enabled, these members may point to strings that contain hyperlinks in the following form:
			/// <code>
			/// <![CDATA[<A HREF = "executablestring" > Hyperlink Text</A>]]>
			/// </code>
			/// <note type="warning">Enabling hyperlinks when using content from an unsafe source may cause security
			/// vulnerabilities.</note><note>Task Dialogs will not actually execute any hyperlinks.Hyperlink execution must be handled in the
			/// callback function specified by pfCallback.For more details, see TaskDialogCallbackProc.</note>
			/// </summary>
			TDF_ENABLE_HYPERLINKS = 0x0001,

			/// <summary>
			/// Indicates that the dialog should use the icon referenced by the handle in the hMainIcon member as the primary icon in the
			/// task dialog. If this flag is specified, the pszMainIcon member is ignored.
			/// </summary>
			TDF_USE_HICON_MAIN = 0x0002,

			/// <summary>
			/// Indicates that the dialog should use the icon referenced by the handle in the hFooterIcon member as the footer icon in the
			/// task dialog. If this flag is specified, the pszFooterIcon member is ignored.
			/// </summary>
			TDF_USE_HICON_FOOTER = 0x0004,

			/// <summary>
			/// Indicates that the dialog should be able to be closed using Alt-F4, Escape, and the title bar's close button even if no
			/// cancel button is specified in either the dwCommonButtons or pButtons members.
			/// </summary>
			TDF_ALLOW_DIALOG_CANCELLATION = 0x0008,

			/// <summary>
			/// Indicates that the buttons specified in the pButtons member are to be displayed as command links (using a standard task
			/// dialog glyph) instead of push buttons. When using command links, all characters up to the first new line character in the
			/// pszButtonText member will be treated as the command link's main text, and the remainder will be treated as the command link's
			/// note. This flag is ignored if the cButtons member is zero.
			/// </summary>
			TDF_USE_COMMAND_LINKS = 0x0010,

			/// <summary>
			/// Indicates that the buttons specified in the pButtons member are to be displayed as command links (without a glyph) instead of
			/// push buttons. When using command links, all characters up to the first new line character in the pszButtonText member will be
			/// treated as the command link's main text, and the remainder will be treated as the command link's note. This flag is ignored
			/// if the cButtons member is zero.
			/// </summary>
			TDF_USE_COMMAND_LINKS_NO_ICON = 0x0020,

			/// <summary>
			/// Indicates that the string specified by the pszExpandedInformation member is displayed at the bottom of the dialog's footer
			/// area instead of immediately after the dialog's content. This flag is ignored if the pszExpandedInformation member is NULL.
			/// </summary>
			TDF_EXPAND_FOOTER_AREA = 0x0040,

			/// <summary>
			/// Indicates that the string specified by the pszExpandedInformation member is displayed when the dialog is initially displayed.
			/// This flag is ignored if the pszExpandedInformation member is NULL.
			/// </summary>
			TDF_EXPANDED_BY_DEFAULT = 0x0080,

			/// <summary>
			/// Indicates that the verification checkbox in the dialog is checked when the dialog is initially displayed. This flag is
			/// ignored if the pszVerificationText parameter is NULL.
			/// </summary>
			TDF_VERIFICATION_FLAG_CHECKED = 0x0100,

			/// <summary>Indicates that a Progress Bar is to be displayed.</summary>
			TDF_SHOW_PROGRESS_BAR = 0x0200,

			/// <summary>Indicates that an Marquee Progress Bar is to be displayed.</summary>
			TDF_SHOW_MARQUEE_PROGRESS_BAR = 0x0400,

			/// <summary>Indicates that the task dialog's callback is to be called approximately every 200 milliseconds.</summary>
			TDF_CALLBACK_TIMER = 0x0800,

			/// <summary>
			/// Indicates that the task dialog is positioned (centered) relative to the window specified by hwndParent. If the flag is not
			/// supplied (or no hwndParent member is specified), the task dialog is positioned (centered) relative to the monitor.
			/// </summary>
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
			/// Indicates that the width of the task dialog is determined by the width of its content area. This flag is ignored if cxWidth
			/// is not set to 0.
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

		/// <summary>TaskDialogMessage taken from CommCtrl.h.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787473")]
		public enum TaskDialogMessage : uint
		{
			/// <summary>Recreates a task dialog with new contents, simulating the functionality of a multi-page wizard.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Not used. Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to a <c>TASKDIALOGCONFIG</c> structure that describes the task dialog to create. The calling application must
			/// allocate this structure and set its members. The values of the members vary depending on the kind of page the user navigates to.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// To launch a wizard task dialog, use the <c>TaskDialogIndirect</c> function. As the user navigates using the wizard, send this
			/// message to the task dialog to display the next page. A new task dialog (looks like a new page) is created with the elements
			/// specified in the structure pointed to by lParam. At creation, the entire contents of the dialog frame are destroyed and
			/// reconstructed. As a result, any state information held by controls (for example, a progress bar, expando button, or
			/// verification checkbox) in the dialog is lost.
			/// </para>
			/// <para>
			/// The layout of the task dialog may fail and this may not be reflected in the return value. A return value of S_OK reflects
			/// only that the task dialog received the message and attempted to process it. If the layout of the task dialog fails (the task
			/// dialog cannot be displayed), the dialog will close and an <c>HRESULT</c> code is returned at the registered callback
			/// function. For more information on the callback function syntax, see TaskDialogCallbackProc.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-navigate-page
			TDM_NAVIGATE_PAGE = WindowMessage.WM_USER + 101,

			/// <summary>Simulates the action of a button click in a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>An <c>int</c> that specifies the ID of the button to be clicked.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			/// <remarks>
			/// The button ID specified by wParam is sent to the <c>TaskDialogCallbackProc</c> callback function as part of a
			/// TDN_BUTTON_CLICKED notification code. After the callback function returns, the task dialog is closed if S_OK was returned
			/// from the callback function. If S_FALSE was returned from the callback function, the task dialog remains active.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-click-button
			TDM_CLICK_BUTTON = WindowMessage.WM_USER + 102, // wParam = Button ID

			/// <summary>Indicates whether the hosted progress bar of a task dialog should be displayed in marquee mode.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// A <c>BOOL</c> that indicates whether the progress bar should be shown in marquee mode. A value of <c>TRUE</c> turns on
			/// marquee mode, and a value of <c>FALSE</c> turns off marquee mode.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			/// <remarks>For information on marquee mode, see Progress Bar Control.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-set-marquee-progress-bar
			TDM_SET_MARQUEE_PROGRESS_BAR = WindowMessage.WM_USER + 103, // wParam = 0 (nonMarque) wParam != 0 (Marquee)

			/// <summary>Sets the state of the progress bar in a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>An <c>int</c> that specifies the state of the progress bar. This parameter can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>PBST_NORMAL</c></term>
			/// <term>Sets the progress bar to the normal state.</term>
			/// </item>
			/// <item>
			/// <term><c>PBST_PAUSED</c></term>
			/// <term>Sets the progress bar to the paused state.</term>
			/// </item>
			/// <item>
			/// <term><c>PBST_ERROR</c></term>
			/// <term>Set the progress bar to the error state.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>If the function succeeds, the return value is non zero.</para>
			/// <para>If the function fails, the return value is zero. To get extended error information call GetLastError.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-set-progress-bar-state
			TDM_SET_PROGRESS_BAR_STATE = WindowMessage.WM_USER + 104, // wParam = new progress state

			/// <summary>Sets the minimum and maximum values for the progress bar in a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// The <c>LOWORD</c> specifies the minimum value. By default, the minimum value is zero. The <c>HIWORD</c> specifies the maximum
			/// value. By default, the maximum value is 100.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the previous minimum and maximum values, if successful, or zero otherwise. The <c>LOWORD</c> contains the minimum
			/// value, and the <c>HIWORD</c> contains the maximum value.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-set-progress-bar-range
			TDM_SET_PROGRESS_BAR_RANGE = WindowMessage.WM_USER + 105, // lParam = MAKELPARAM(nMinRange, nMaxRange)

			/// <summary>Sets the position of the progress bar in a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>An <c>int</c> that specifies the new position.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous position.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-set-progress-bar-pos
			TDM_SET_PROGRESS_BAR_POS = WindowMessage.WM_USER + 106, // wParam = new position

			/// <summary>Starts and stops the marquee display of the progress bar in a task dialog, and sets the speed of the marquee.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// A <c>BOOL</c> that indicates whether to turn the marquee display on or off. Use <c>TRUE</c> to turn on the marquee display,
			/// or <c>FALSE</c> to turn it off.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A <c>UINT</c> that specifies the time, in milliseconds, between marquee animation updates. If this parameter is zero, the
			/// marquee animation is updated every 30 milliseconds.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			/// <remarks>For information on marquee mode, see Progress Bar Control.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-set-progress-bar-marquee
			TDM_SET_PROGRESS_BAR_MARQUEE = WindowMessage.WM_USER + 107, // wParam = 0 (stop marquee), wParam != 0 (start marquee), lparam = speed (milliseconds between repaints)

			/// <summary>Updates a text element in a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Indicates the element to update. (For an illustration, see About Task Dialogs.) This parameter must be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TDE_CONTENT</c></term>
			/// <term>Content.</term>
			/// </item>
			/// <item>
			/// <term><c>TDE_EXPANDED_INFORMATION</c></term>
			/// <term>Expanded information.</term>
			/// </item>
			/// <item>
			/// <term><c>TDE_FOOTER</c></term>
			/// <term>Footer text.</term>
			/// </item>
			/// <item>
			/// <term><c>TDE_MAIN_INSTRUCTION</c></term>
			/// <term>Main instruction.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>The new text to use.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			/// <remarks>The size or layout of the task dialog may change to accommodate the new text.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-set-element-text
			TDM_SET_ELEMENT_TEXT = WindowMessage.WM_USER + 108, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)

			/// <summary>Simulates the action of a radio button click in a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>An <c>int</c> value that specifies the ID of the radio button to be clicked.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			/// <remarks>
			/// The specified radio button ID is sent to the <c>TaskDialogCallbackProc</c> callback function as part of a
			/// TDN_RADIO_BUTTON_CLICKED notification code. After the callback function returns, the radio button will be selected.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-click-radio-button
			TDM_CLICK_RADIO_BUTTON = WindowMessage.WM_USER + 110, // wParam = Radio Button ID

			/// <summary>Enables or disables a push button in a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>An <c>int</c> value that specifies the ID of the push button to be enabled or disabled.</para>
			/// <para><em>lParam</em></para>
			/// <para>Specifies button state. Set to 0 to disable the button; set to nonzero to enable the button.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-enable-button
			TDM_ENABLE_BUTTON = WindowMessage.WM_USER + 111, // lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID

			/// <summary>Enables or disables a radio button in a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>An <c>int</c> value that specifies the ID of the radio button to be enabled or disabled.</para>
			/// <para><em>lParam</em></para>
			/// <para>Specifies button state. Set to 0 to disable the button; set to nonzero to enable the button.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-enable-radio-button
			TDM_ENABLE_RADIO_BUTTON = WindowMessage.WM_USER + 112, // lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID

			/// <summary>Simulates a click of the verification checkbox of a task dialog, if it exists.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para><c>TRUE</c> to set the state of the checkbox to be checked; <c>FALSE</c> to set it to be unchecked.</para>
			/// <para><em>lParam</em></para>
			/// <para><c>TRUE</c> to set the keyboard focus to the checkbox; <c>FALSE</c> otherwise.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-click-verification
			TDM_CLICK_VERIFICATION = WindowMessage.WM_USER + 113, // wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)

			/// <summary>Updates a text element in a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Indicates the element to update. (For an illustration of the elements, see About Task Dialogs.) This parameter must be one of
			/// the following values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TDE_CONTENT</c></term>
			/// <term>Content.</term>
			/// </item>
			/// <item>
			/// <term><c>TDE_EXPANDED_INFORMATION</c></term>
			/// <term>Expanded information.</term>
			/// </item>
			/// <item>
			/// <term><c>TDE_FOOTER</c></term>
			/// <term>Footer text.</term>
			/// </item>
			/// <item>
			/// <term><c>TDE_MAIN_INSTRUCTION</c></term>
			/// <term>Main instruction.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to a Unicode string that contains the new text.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// To avoid clipping, the new text must be no longer than the existing text. Setting the text to a shorter string does not cause
			/// the dialog box to resize.
			/// </para>
			/// <para>
			/// If the <c>pszExpandedInformation</c> member of the <c>TASKDIALOGCONFIG</c> structure used to create the task dialog was
			/// <c>NULL</c>, and you send a <c>TDM_UPDATE_ELEMENT_TEXT</c> message with TDE_EXPANDED_INFORMATION, nothing will happen.
			/// </para>
			/// <para>The above also applies to the footer and TDE_FOOTER.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-update-element-text
			TDM_UPDATE_ELEMENT_TEXT = WindowMessage.WM_USER + 114, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)

			/// <summary>
			/// Specifies whether a given task dialog button or command link should have a User Account Control (UAC) shield icon; that is,
			/// whether the action invoked by the button requires elevation.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The ID of the push button or command link to be updated.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Set to 0 to designate that the action invoked by the button does not require elevation. Set to nonzero to designate that the
			/// action requires elevation.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-set-button-elevation-required-state
			TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE = WindowMessage.WM_USER + 115, // wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)

			/// <summary>Refreshes the icon of a task dialog.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Indicates which icon element to update. This parameter must be one of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TDIE_ICON_MAIN</c></term>
			/// <term>Main icon.</term>
			/// </item>
			/// <item>
			/// <term><c>TDIE_ICON_FOOTER</c></term>
			/// <term>Footer icon.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to a string (PCWSTR) or handle to an icon (HICON) to display. If lParam is <c>NULL</c>, no icon is displayed,
			/// regardless of the value of wParam.
			/// </para>
			/// <para>
			/// If the value of wParam is TDIE_ICON_MAIN and the TDF_USE_HICON_MAIN flag is set on the <c>dwFlags</c> member of the
			/// <c>TASKDIALOGCONFIG</c> structure used to create the task dialog, lParam must contain a handle to an icon (HICON) to display.
			/// </para>
			/// <para>
			/// If the value of wParam is TDIE_ICON_FOOTER and the TDF_USE_HICON_FOOTER flag is set on the <c>dwFlags</c> member of the
			/// <c>TASKDIALOGCONFIG</c> structure used to create the task dialog, lParam must contain a handle to an icon (HICON) to display.
			/// </para>
			/// <para>
			/// If the TDF_USE_HICON_MAIN or TDF_USE_HICON_FOOTER flags are <c>not</c> set on the <c>dwFlags</c> member, lParam must point to
			/// a null-terminated, Unicode string (PCWSTR) that contains a valid resource identifier passed through the
			/// <c>MAKEINTRESOURCE</c> macro. The icon is displayed based on the value of wParam: if the value is TDIE_ICON_MAIN, the icon is
			/// displayed in the header; if the value is TDIE_ICON_FOOTER, the icon is displayed in the footer. The resource must be either
			/// from the application's resource module (specified in the <c>hInstance</c> member of the <c>TASKDIALOGCONFIG</c> structure),
			/// or if <c>hInstance</c> is <c>NULL</c>, from the system's resource module (imageres.dll). To identify a system resource, use a
			/// valid system identifier passed through the <c>MAKEINTRESOURCE</c> macro or one of the following predefined values from commctrl.h:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TD_ERROR_ICON</c></term>
			/// <term>A stop sign icon.</term>
			/// </item>
			/// <item>
			/// <term><c>TD_WARNING_ICON</c></term>
			/// <term>An exclamation point icon.</term>
			/// </item>
			/// <item>
			/// <term><c>TD_INFORMATION_ICON</c></term>
			/// <term>A lowercase letter "i" in a circle icon.</term>
			/// </item>
			/// <item>
			/// <term><c>TD_SHIELD_ICON</c></term>
			/// <term>A security shield icon.</term>
			/// </item>
			/// </list>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// The layout of the task dialog with the icon may fail and this may not be reflected in the return value. A return value of
			/// S_OK reflects only that the task dialog received the message and attempted to process it. If the layout of the task dialog
			/// fails, the dialog will close and an <c>HRESULT</c> code is returned at the registered callback function. For more information
			/// on the callback function syntax, see TaskDialogCallbackProc.
			/// </para>
			/// <para>
			/// If the task dialog is created without a footer (that is, the appropriate footer members of the <c>TASKDIALOGCONFIG</c>
			/// structure used to create the task dialog are <c>NULL</c>) and this message is sent, a footer is not dynamically added to the
			/// task dialog. The same is true for sending this message to update a header icon when a task dialog is created without a
			/// header. To add a header or footer at run time, use the <c>TDM_NAVIGATE_PAGE</c> functionality.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-update-icon
			TDM_UPDATE_ICON = WindowMessage.WM_USER + 116 // wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
		}

		/// <summary>Task Dialog callback notifications.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787473")]
		public enum TaskDialogNotification : uint
		{
			/// <summary>
			/// <para>
			/// Sent by the task dialog after the dialog has been created and before it is displayed. This notification code is received only
			/// through the task dialog callback function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_CREATED WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-created
			TDN_CREATED = 0,

			/// <summary>
			/// <para>
			/// Sent by a task dialog when navigation has occurred. This notification code is received only through the task dialog callback
			/// function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_NAVIGATED WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-navigated
			TDN_NAVIGATED = 1,

			/// <summary>
			/// <para>
			/// Sent by a task dialog when the user selects a button or command link in the task dialog. This notification code is received
			/// only through the task dialog callback function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_BUTTON_CLICKED WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>An <c>int</c> that specifies the ID of the button or comand link that was selected.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// To prevent the task dialog from closing, the application must return <c>S_FALSE</c>, otherwise the task dialog is closed and
			/// the button ID is returned via the original application call.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-button-clicked
			TDN_BUTTON_CLICKED = 2,

			/// <summary>
			/// <para>
			/// Sent by a task dialog when the user clicks a hyperlink in the task dialog content. This notification code is received only
			/// through the task dialog callback function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_HYPERLINK_CLICKED WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to a wide-character string containing the URL of the hyperlink.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-hyperlink-clicked
			TDN_HYPERLINK_CLICKED = 3,

			/// <summary>
			/// <para>
			/// Sent by a task dialog approximately every 200 milliseconds. This notification code is sent when the TDF_CALLBACK_TIMER flag
			/// has been set in the <c>dwFlags</c> member of the <c>TASKDIALOGCONFIG</c> structure that was passed to the
			/// <c>TaskDialogIndirect</c> function. This notification code is received only through the task dialog callback function, which
			/// can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_TIMER WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// A <c>DWORD</c> that specifies the number of milliseconds since the dialog was created or this notification code returned <c>S_FALSE</c>.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>To reset the tickcount, the application must return <c>S_FALSE</c>, otherwise the tickcount will continue to increment.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-timer
			TDN_TIMER = 4,

			/// <summary>
			/// <para>
			/// Sent by a task dialog when it is destroyed and its window handle is no longer valid. This notification code is received only
			/// through the task dialog callback function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_DESTROYED WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-destroyed
			TDN_DESTROYED = 5,

			/// <summary>
			/// <para>
			/// Sent by a task dialog when the user selects a radio button or command link in the task dialog. This notification code is
			/// received only through the task dialog callback function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_RADIO_BUTTON_CLICKED WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>An <c>int</c> that specifies the ID corresponding to the radio button that was clicked.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-radio-button-clicked
			TDN_RADIO_BUTTON_CLICKED = 6,

			/// <summary>
			/// <para>
			/// Sent by a task dialog after the dialog has been created and before it is displayed. This notification code is received only
			/// through the task dialog callback function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_DIALOG_CONSTRUCTED WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-dialog-constructed
			TDN_DIALOG_CONSTRUCTED = 7,

			/// <summary>
			/// <para>
			/// Sent by a task dialog when the user clicks the task dialog verification check box. This notification code is received only
			/// through the task dialog callback function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_VERIFICATION_CLICKED WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// A <c>BOOL</c> that specifies the status of the verification checkbox. It is <c>TRUE</c> if the verification checkbox is
			/// checked, or <c>FALSE</c> if it is unchecked.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-verification-clicked
			TDN_VERIFICATION_CLICKED = 8,

			/// <summary>
			/// <para>
			/// Sent by a task dialog when the user presses F1 on the keyboard while the dialog has focus. This notification code is received
			/// only through the task dialog callback function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_HELP WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-help
			TDN_HELP = 9,

			/// <summary>
			/// <para>
			/// Sent by the task dialog when the user clicks on the dialog's expando button. This notification is received only through the
			/// task dialog callback function, which can be registered using the <c>TaskDialogIndirect</c> method.
			/// </para>
			/// <para>
			/// <code>TDN_EXPANDO_BUTTON_CLICKED WPARAM wParam; LPARAM lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>A <c>BOOL</c> that is <c>TRUE</c> if the dialog is expanded, or <c>FALSE</c> if not.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is ignored.</para>
			/// </summary>
			/// <remarks>
			/// The example in the Syntax section shows the cast to wParam before sending the notification. <c>LPARAM</c> is not used and
			/// must be zero.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tdn-expando-button-clicked
			TDN_EXPANDO_BUTTON_CLICKED = 10
		}

		/// <summary>
		/// The TaskDialog function creates, displays, and operates a task dialog. The task dialog contains application-defined message text
		/// and title, icons, and any combination of predefined push buttons. This function does not support the registration of a callback
		/// function to receive notifications.
		/// </summary>
		/// <param name="hwndParent">
		/// Handle to the owner window of the task dialog to be created. If this parameter is NULL, the task dialog has no owner window.
		/// </param>
		/// <param name="hInstance">
		/// Handle to the module that contains the icon resource identified by the pszIcon member, and the string resources identified by the
		/// pszWindowTitle and pszMainInstruction members. If this parameter is NULL, pszIcon must be NULL or a pointer to a null-terminated,
		/// Unicode string that contains a system resource identifier, for example, TD_ERROR_ICON.
		/// </param>
		/// <param name="pszWindowTitle">
		/// Pointer to the string to be used for the task dialog title. This parameter is a null-terminated, Unicode string that contains
		/// either text, or an integer resource identifier passed through the MAKEINTRESOURCE macro. If this parameter is NULL, the filename
		/// of the executable program is used.
		/// </param>
		/// <param name="pszMainInstruction">
		/// Pointer to the string to be used for the main instruction. This parameter is a null-terminated, Unicode string that contains
		/// either text, or an integer resource identifier passed through the MAKEINTRESOURCE macro. This parameter can be NULL if no main
		/// instruction is wanted.
		/// </param>
		/// <param name="pszContent">
		/// Pointer to a string used for additional text that appears below the main instruction, in a smaller font. This parameter is a
		/// null-terminated, Unicode string that contains either text, or an integer resource identifier passed through the MAKEINTRESOURCE
		/// macro. Can be NULL if no additional text is wanted.
		/// </param>
		/// <param name="dwCommonButtons">
		/// Specifies the push buttons displayed in the dialog box. This parameter may be a combination of flags from the following group.
		/// </param>
		/// <param name="pszIcon">
		/// Pointer to a string that identifies the icon to display in the task dialog. This parameter must be an integer resource identifier
		/// passed to the MAKEINTRESOURCE macro or one of the following predefined values. If this parameter is NULL, no icon will be
		/// displayed. If the hInstance parameter is NULL and one of the predefined values is not used, the TaskDialog function fails.
		/// </param>
		/// <param name="pnButton">
		/// When this function returns, contains a pointer to an integer location that receives one of the standard button result values.
		/// </param>
		/// <returns>
		/// This function can return one of these values.
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760540")]
		[DllImport(Lib.ComCtl32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern HRESULT TaskDialog(HWND hwndParent, HINSTANCE hInstance, string pszWindowTitle, string pszMainInstruction, string pszContent, TASKDIALOG_COMMON_BUTTON_FLAGS dwCommonButtons, SafeResourceId pszIcon, out int pnButton);

		/// <summary>
		/// The TaskDialogIndirect function creates, displays, and operates a task dialog. The task dialog contains application-defined
		/// icons, messages, title, verification check box, command links, push buttons, and radio buttons. This function can register a
		/// callback function to receive notification messages.
		/// </summary>
		/// <param name="pTaskConfig">Pointer to a TASKDIALOGCONFIG structure that contains information used to display the task dialog.</param>
		/// <param name="pnButton">
		/// Address of a variable that receives one of the button IDs specified in the pButtons member of the pTaskConfig parameter or a
		/// standard button ID value.
		/// </param>
		/// <param name="pnRadioButton">
		/// Address of a variable that receives one of the button IDs specified in the pRadioButtons member of the pTaskConfig parameter. If
		/// this parameter is NULL, no value is returned.
		/// </param>
		/// <param name="pfVerificationFlagChecked">
		/// Address of a variable that receives a value indicating if the verification checkbox was checked when the dialog was dismissed.
		/// </param>
		/// <returns>
		/// This function can return one of these values.
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760544")]
		[DllImport(Lib.ComCtl32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern HRESULT TaskDialogIndirect([In] TASKDIALOGCONFIG pTaskConfig, out int pnButton, out int pnRadioButton, [MarshalAs(UnmanagedType.Bool)] out bool pfVerificationFlagChecked);

		/// <summary>
		/// The TASKDIALOG_BUTTON structure contains information used to display a button in a task dialog. The TASKDIALOGCONFIG structure
		/// uses this structure.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787475")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TASKDIALOG_BUTTON
		{
			/// <summary>Indicates the value to be returned when this button is selected.</summary>
			public int nButtonID;

			/// <summary>
			/// Pointer that references the string to be used to label the button. This parameter can be either a null-terminated string or
			/// an integer resource identifier passed to the MAKEINTRESOURCE macro. When using Command Links, you delineate the command from
			/// the note by placing a new line character in the string.
			/// </summary>
			public IntPtr pszButtonText;
		}

		/// <summary>
		/// The <c>TASKDIALOGCONFIG</c> structure contains information used to display a task dialog. The TaskDialogIndirect function uses
		/// this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/commctrl/ns-commctrl-_taskdialogconfig
		[PInvokeData("commctrl.h", MSDNShortId = "bb787473")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
		public class TASKDIALOGCONFIG : IDisposable
		{
			/// <summary>Specifies the structure size, in bytes.</summary>
			public uint cbSize;

			/// <summary>Handle to the parent window. This member can be NULL.</summary>
			public HWND hwndParent;

			/// <summary>
			/// Handle to the module that contains the icon resource identified by the pszMainIcon or pszFooterIcon members, and the string
			/// resources identified by the pszWindowTitle, pszMainInstruction, pszContent, pszVerificationText, pszExpandedInformation,
			/// pszExpandedControlText, pszCollapsedControlText or pszFooter members.
			/// </summary>
			public HINSTANCE hInstance;

			/// <summary>Specifies the behavior of the task dialog. This parameter can be a combination of flags.</summary>
			public TASKDIALOG_FLAGS dwFlags;

			/// <summary>
			/// Specifies the push buttons displayed in the task dialog. If no common buttons are specified and no custom buttons are
			/// specified using the cButtons and pButtons members, the task dialog will contain the OK button by default. This parameter may
			/// be a combination of flags.
			/// </summary>
			public TASKDIALOG_COMMON_BUTTON_FLAGS dwCommonButtons;

			/// <summary>
			/// Pointer that references the string to be used for the task dialog title. This parameter can be either a null-terminated
			/// string or an integer resource identifier passed to the MAKEINTRESOURCE macro. If this parameter is NULL, the filename of the
			/// executable program is used.
			/// </summary>
			public IntPtr pszWindowTitle;

			/// <summary>
			/// A handle to an Icon that is to be displayed in the task dialog. This member is ignored unless the TDF_USE_HICON_MAIN flag is
			/// specified. If this member is NULL and the TDF_USE_HICON_MAIN is specified, no icon will be displayed.
			/// <para><c>OR</c></para>
			/// <para>
			/// Pointer that references the icon to be displayed in the task dialog. This parameter is ignored if the USE_HICON_MAIN flag is
			/// specified. Otherwise, if this parameter is NULL or the hInstance parameter is NULL, no icon will be displayed. This parameter
			/// must be an integer resource identifier passed to the MAKEINTRESOURCE macro.
			/// </para>
			/// </summary>
			public IntPtr mainIcon;

			/// <summary>
			/// Pointer that references the string to be used for the main instruction. This parameter can be either a null-terminated string
			/// or an integer resource identifier passed to the MAKEINTRESOURCE macro.
			/// </summary>
			public IntPtr pszMainInstruction;

			/// <summary>
			/// Pointer that references the string to be used for the dialog's primary content. This parameter can be either a
			/// null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. If the ENABLE_HYPERLINKS flag
			/// is specified for the dwFlags member, then this string may contain hyperlinks in the form: <A
			/// HREF="executablestring">Hyperlink Text</A>. WARNING: Enabling hyperlinks when using content from an unsafe source may cause
			/// security vulnerabilities.
			/// </summary>
			public IntPtr pszContent;

			/// <summary>
			/// The number of entries in the pButtons array that is used to create buttons or command links in the task dialog. If this
			/// member is zero and no common buttons have been specified using the dwCommonButtons member, then the task dialog will have a
			/// single OK button displayed.
			/// </summary>
			public uint cButtons;

			/// <summary>
			/// Pointer to an array of TASKDIALOG_BUTTON structures containing the definition of the custom buttons that are to be displayed
			/// in the task dialog. This array must contain at least the number of entries that are specified by the cButtons member.
			/// </summary>
			public IntPtr pButtons;

			/// <summary>
			/// The default button for the task dialog. This may be any of the values specified in nButtonID members of one of the
			/// TASKDIALOG_BUTTON structures in the pButtons array, or one of the IDs corresponding to the buttons specified in the
			/// dwCommonButtons member. If this member is zero or its value does not correspond to any button ID in the dialog, then the
			/// first button in the dialog will be the default.
			/// </summary>
			public int nDefaultButton;

			/// <summary>The number of entries in the pRadioButtons array that is used to create radio buttons in the task dialog.</summary>
			public uint cRadioButtons;

			/// <summary>
			/// Pointer to an array of TASKDIALOG_BUTTON structures containing the definition of the radio buttons that are to be displayed
			/// in the task dialog. This array must contain at least the number of entries that are specified by the cRadioButtons member.
			/// This parameter can be NULL.
			/// </summary>
			public IntPtr pRadioButtons;

			/// <summary>
			/// The button ID of the radio button that is selected by default. If this value does not correspond to a button ID, the first
			/// button in the array is selected by default.
			/// </summary>
			public int nDefaultRadioButton;

			/// <summary>
			/// Pointer that references the string to be used to label the verification checkbox. This parameter can be either a
			/// null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. If this parameter is NULL, the
			/// verification checkbox is not displayed in the task dialog. If the pfVerificationFlagChecked parameter of TaskDialogIndirect
			/// is NULL, the checkbox is not enabled.
			/// </summary>
			public IntPtr pszVerificationText;

			/// <summary>
			/// Pointer that references the string to be used for displaying additional information. This parameter can be either a
			/// null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. The additional information is
			/// displayed either immediately below the content or below the footer text depending on whether the TDF_EXPAND_FOOTER_AREA flag
			/// is specified. If the TDF_ENABLE_HYPERLINKS flag is specified for the dwFlags member, then this string may contain hyperlinks
			/// in the form: <A HREF="executablestring">Hyperlink Text</A>. WARNING: Enabling hyperlinks when using content from an unsafe
			/// source may cause security vulnerabilities.
			/// </summary>
			public IntPtr pszExpandedInformation;

			/// <summary>
			/// Pointer that references the string to be used to label the button for collapsing the expandable information. This parameter
			/// can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. This member is
			/// ignored when the pszExpandedInformation member is NULL. If this member is NULL and the pszCollapsedControlText is specified,
			/// then the pszCollapsedControlText value will be used for this member as well.
			/// </summary>
			public IntPtr pszExpandedControlText;

			/// <summary>
			/// Pointer that references the string to be used to label the button for expanding the expandable information. This parameter
			/// can be either a null-terminated string or an integer resource identifier passed to the MAKEINTRESOURCE macro. This member is
			/// ignored when the pszExpandedInformation member is NULL. If this member is NULL and the pszCollapsedControlText is specified,
			/// then the pszCollapsedControlText value will be used for this member as well.
			/// </summary>
			public IntPtr pszCollapsedControlText;

			/// <summary>
			/// A handle to an Icon that is to be displayed in the footer of the task dialog. This member is ignored unless the
			/// TDF_USE_HICON_FOOTER flag is specified and the pszFooterIcon is not. If this member is NULL and the TDF_USE_HICON_FOOTER is
			/// specified, no icon is displayed.
			/// <para><c>OR</c></para>
			/// <para>
			/// Pointer that references the icon to be displayed in the footer area of the task dialog. This parameter is ignored if the
			/// TDF_USE_HICON_FOOTER flag is specified, or if pszFooter is NULL. Otherwise, if this parameter is NULL or the hInstance
			/// parameter is NULL, no icon is displayed. This parameter must be an integer resource identifier passed to the MAKEINTRESOURCE
			/// macro or one of the predefined values listed for pszMainIcon.
			/// </para>
			/// </summary>
			public IntPtr footerIcon;

			/// <summary>
			/// Pointer to the string to be used in the footer area of the task dialog. This parameter can be either a null-terminated string
			/// or an integer resource identifier passed to the MAKEINTRESOURCE macro. If the TDF_ENABLE_HYPERLINKS flag is specified for the
			/// dwFlags member, then this string may contain hyperlinks in this form.
			/// <para>&lt;A HREF="executablestring"&gt;Hyperlink Text&lt;/A&gt;</para>
			/// <note type="warning">Enabling hyperlinks when using content from an unsafe source may cause security vulnerabilities.</note>
			/// </summary>
			public IntPtr pszFooter;

			/// <summary>Pointer to an application-defined callback function. For more information see TaskDialogCallbackProc.</summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public TaskDialogCallbackProc pfCallbackProc;

			/// <summary>A pointer to application-defined reference data. This value is defined by the caller.</summary>
			public IntPtr lpCallbackData;

			/// <summary>
			/// The width of the task dialog's client area, in dialog units. If 0, the task dialog manager will calculate the ideal width.
			/// </summary>
			public uint cxWidth;

			/// <summary>
			/// Initializes a new instance of the <see cref="TASKDIALOGCONFIG"/> class setting the <see cref="cbSize"/> field properly.
			/// </summary>
			public TASKDIALOGCONFIG()
			{
				cbSize = (uint)Marshal.SizeOf(typeof(TASKDIALOGCONFIG));
			}

			/// <summary>
			/// The string to be used for the task dialog title. If this parameter is NULL, the filename of the executable program is used.
			/// </summary>
			public string WindowTitle
			{
				get => SafeResourceId.GetString(pszWindowTitle, CharSet.Unicode);
				set => StringHelper.RefreshString(ref pszWindowTitle, out var _, value, CharSet.Unicode);
			}

			/// <summary>The string to be used for the main instruction.</summary>
			public string MainInstruction
			{
				get => SafeResourceId.GetString(pszMainInstruction, CharSet.Unicode);
				set => StringHelper.RefreshString(ref pszMainInstruction, out var _, value, CharSet.Unicode);
			}

			/// <summary>
			/// The string to be used for the dialog's primary content. If the ENABLE_HYPERLINKS flag is specified for the dwFlags member,
			/// then this string may contain hyperlinks in the form: &lt;A HREF="executablestring"&gt;Hyperlink Text&lt;/A&gt;. WARNING:
			/// Enabling hyperlinks when using content from an unsafe source may cause security vulnerabilities.
			/// </summary>
			public string Content
			{
				get => SafeResourceId.GetString(pszContent, CharSet.Unicode);
				set => StringHelper.RefreshString(ref pszContent, out var _, value, CharSet.Unicode);
			}

			/// <summary>
			/// The string to be used to label the verification checkbox. If this parameter is NULL, the verification checkbox is not
			/// displayed in the task dialog. If the pfVerificationFlagChecked parameter of TaskDialogIndirect is NULL, the checkbox is not enabled.
			/// </summary>
			public string VerificationText
			{
				get => SafeResourceId.GetString(pszVerificationText, CharSet.Unicode);
				set => StringHelper.RefreshString(ref pszVerificationText, out var _, value, CharSet.Unicode);
			}

			/// <summary>
			/// The string to be used for displaying additional information. The additional information is displayed either immediately below
			/// the content or below the footer text depending on whether the TDF_EXPAND_FOOTER_AREA flag is specified. If the
			/// TDF_ENABLE_HYPERLINKS flag is specified for the dwFlags member, then this string may contain hyperlinks in the form: &lt;A
			/// HREF="executablestring"&gt;Hyperlink Text&lt;/A&gt;. WARNING: Enabling hyperlinks when using content from an unsafe source
			/// may cause security vulnerabilities.
			/// </summary>
			public string ExpandedInformation
			{
				get => SafeResourceId.GetString(pszExpandedInformation, CharSet.Unicode);
				set => StringHelper.RefreshString(ref pszExpandedInformation, out var _, value, CharSet.Unicode);
			}

			/// <summary>
			/// The string to be used to label the button for collapsing the expandable information. This member is ignored when the
			/// pszExpandedInformation member is NULL. If this member is NULL and the pszCollapsedControlText is specified, then the
			/// pszCollapsedControlText value will be used for this member as well.
			/// </summary>
			public string ExpandedControlText
			{
				get => SafeResourceId.GetString(pszExpandedControlText, CharSet.Unicode);
				set => StringHelper.RefreshString(ref pszExpandedControlText, out var _, value, CharSet.Unicode);
			}

			/// <summary>
			/// The string to be used to label the button for expanding the expandable information. This member is ignored when the
			/// pszExpandedInformation member is NULL. If this member is NULL and the pszCollapsedControlText is specified, then the
			/// pszCollapsedControlText value will be used for this member as well.
			/// </summary>
			public string CollapsedControlText
			{
				get => SafeResourceId.GetString(pszCollapsedControlText, CharSet.Unicode);
				set => StringHelper.RefreshString(ref pszCollapsedControlText, out var _, value, CharSet.Unicode);
			}

			/// <summary>
			/// The string to be used in the footer area of the task dialog. If the TDF_ENABLE_HYPERLINKS flag is specified for the dwFlags
			/// member, then this string may contain hyperlinks in this form.
			/// <para>&lt;A HREF="executablestring"&gt;Hyperlink Text&lt;/A&gt;</para>
			/// <note type="warning">Enabling hyperlinks when using content from an unsafe source may cause security vulnerabilities.</note>
			/// </summary>
			public string Footer
			{
				get => SafeResourceId.GetString(pszFooter, CharSet.Unicode);
				set => StringHelper.RefreshString(ref pszFooter, out var _, value, CharSet.Unicode);
			}

			/// <inheritdoc/>
			void IDisposable.Dispose()
			{
				FreeResource(ref pszWindowTitle);
				FreeResource(ref pszMainInstruction);
				FreeResource(ref pszContent);
				FreeResource(ref pszVerificationText);
				FreeResource(ref pszExpandedInformation);
				FreeResource(ref pszExpandedControlText);
				FreeResource(ref pszCollapsedControlText);
				FreeResource(ref pszFooter);
			}

			private static void FreeResource(ref IntPtr ptr)
			{
				StringHelper.FreeString(ptr, CharSet.Unicode);
				ptr = IntPtr.Zero;
			}
		}
	}
}