namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>
	/// <para>
	/// Indicates the state of screen auto-rotation for the system. For example, whether auto-rotation is supported, and whether it is
	/// enabled by the user. This enum is a bitwise OR of one or more of the following values.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-ar_state typedef enum tagAR_STATE { AR_ENABLED,
	// AR_DISABLED, AR_SUPPRESSED, AR_REMOTESESSION, AR_MULTIMON, AR_NOSENSOR, AR_NOT_SUPPORTED, AR_DOCKED, AR_LAPTOP } AR_STATE, *PAR_STATE;
	[PInvokeData("winuser.h", MSDNShortId = "55BCB2EB-524D-478A-8DCE-53E59DD0822D")]
	[Flags]
	public enum AR_STATE
	{
		/// <summary>Auto-rotation is enabled by the user.</summary>
		AR_ENABLED = 0x00,

		/// <summary>Auto-rotation is disabled by the user.</summary>
		AR_DISABLED = 0x01,

		/// <summary>Auto-rotation is currently suppressed by one or more process auto-rotation preferences.</summary>
		AR_SUPPRESSED = 0x02,

		/// <summary>The session is remote, and auto-rotation is temporarily disabled as a result.</summary>
		AR_REMOTESESSION = 0x04,

		/// <summary>The system has multiple monitors attached, and auto-rotation is temporarily disabled as a result.</summary>
		AR_MULTIMON = 0x08,

		/// <summary>The system does not have an auto-rotation sensor.</summary>
		AR_NOSENSOR = 0x10,

		/// <summary>Auto-rotation is not supported with the current system configuration.</summary>
		AR_NOT_SUPPORTED = 0x20,

		/// <summary>The device is docked, and auto-rotation is temporarily disabled as a result.</summary>
		AR_DOCKED = 0x40,

		/// <summary>The device is in laptop mode, and auto-rotation is temporarily disabled as a result.</summary>
		AR_LAPTOP = 0x80,
	}

	/// <summary>
	/// A set of bit flags that you can use to initialize the dialog box. The dialog box sets these flags when it sends the
	/// FINDMSGSTRING registered message to indicate the user's input.
	/// </summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagFINDREPLACEA")]
	[Flags]
	public enum FR : uint
	{
		/// <summary>
		/// If set in a FINDMSGSTRING message, indicates that the dialog box is closing. When you receive a message with this flag set,
		/// the dialog box handle returned by the FindText or ReplaceText function is no longer valid.
		/// </summary>
		FR_DIALOGTERM = 0x00000040,

		/// <summary>
		/// If set, the Down button of the direction radio buttons in a Find dialog box is selected indicating that you should search
		/// from the current location to the end of the document. If not set, the Up button is selected so you should search to the
		/// beginning of the document. You can set this flag to initialize the dialog box. If set in a FINDMSGSTRING message, indicates
		/// the user's selection.
		/// </summary>
		FR_DOWN = 0x00000001,

		/// <summary>
		/// Enables the hook function specified in the lpfnHook member. This flag is used only to initialize the dialog box.
		/// </summary>
		FR_ENABLEHOOK = 0x00000100,

		/// <summary>
		/// Indicates that the hInstance and lpTemplateName members specify a dialog box template to use in place of the default
		/// template. This flag is used only to initialize the dialog box.
		/// </summary>
		FR_ENABLETEMPLATE = 0x00000200,

		/// <summary>
		/// Indicates that the hInstance member identifies a data block that contains a preloaded dialog box template. The system
		/// ignores the lpTemplateName member if this flag is specified.
		/// </summary>
		FR_ENABLETEMPLATEHANDLE = 0x00002000,

		/// <summary>
		/// If set in a FINDMSGSTRING message, indicates that the user clicked the Find Next button in a Find or Replace dialog box. The
		/// lpstrFindWhat member specifies the string to search for.
		/// </summary>
		FR_FINDNEXT = 0x00000008,

		/// <summary>If set when initializing a Find dialog box, hides the search direction radio buttons.</summary>
		FR_HIDEUPDOWN = 0x00004000,

		/// <summary>If set when initializing a Find or Replace dialog box, hides the Match Case check box.</summary>
		FR_HIDEMATCHCASE = 0x00008000,

		/// <summary>If set when initializing a Find or Replace dialog box, hides the Match Whole Word Only check box.</summary>
		FR_HIDEWHOLEWORD = 0x00010000,

		/// <summary>
		/// If set, the Match Case check box is selected indicating that the search should be case-sensitive. If not set, the check box
		/// is unselected so the search should be case-insensitive. You can set this flag to initialize the dialog box. If set in a
		/// FINDMSGSTRING message, indicates the user's selection.
		/// </summary>
		FR_MATCHCASE = 0x00000004,

		/// <summary>If set when initializing a Find or Replace dialog box, disables the Match Case check box.</summary>
		FR_NOMATCHCASE = 0x00000800,

		/// <summary>If set when initializing a Find dialog box, disables the search direction radio buttons.</summary>
		FR_NOUPDOWN = 0x00000400,

		/// <summary>If set when initializing a Find or Replace dialog box, disables the Whole Word check box.</summary>
		FR_NOWHOLEWORD = 0x00001000,

		/// <summary>
		/// If set in a FINDMSGSTRING message, indicates that the user clicked the Replace button in a Replace dialog box. The
		/// lpstrFindWhat member specifies the string to be replaced and the lpstrReplaceWith member specifies the replacement string.
		/// </summary>
		FR_REPLACE = 0x00000010,

		/// <summary>
		/// If set in a FINDMSGSTRING message, indicates that the user clicked the Replace All button in a Replace dialog box. The
		/// lpstrFindWhat member specifies the string to be replaced and the lpstrReplaceWith member specifies the replacement string.
		/// </summary>
		FR_REPLACEALL = 0x00000020,

		/// <summary>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </summary>
		FR_SHOWHELP = 0x00000080,

		/// <summary>
		/// If set, the Match Whole Word Only check box is selected indicating that you should search only for whole words that match
		/// the search string. If not set, the check box is unselected so you should also search for word fragments that match the
		/// search string. You can set this flag to initialize the dialog box. If set in a FINDMSGSTRING message, indicates the user's selection.
		/// </summary>
		FR_WHOLEWORD = 0x00000002,

		/// <summary/>
		FR_RAW = 0x00020000,

		/// <summary/>
		FR_SHOWWRAPAROUND = 0x00040000,

		/// <summary/>
		FR_NOWRAPAROUND = 0x00080000,

		/// <summary/>
		FR_WRAPAROUND = 0x00100000,

		/// <summary/>
		FR_MATCHDIAC = 0x20000000,

		/// <summary/>
		FR_MATCHKASHIDA = 0x40000000,

		/// <summary/>
		FR_MATCHALEFHAMZA = 0x80000000,
	}

	/// <summary>Defines constants that indicate whether a window is registered or unregistered to receive tooltip dismiss notifications.</summary>
	/// <remarks>This enumeration is used by the RegisterForTooltipDismissNotification function.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-tooltip_dismiss_flags
	// typedef enum { TDF_REGISTER, TDF_UNREGISTER } TOOLTIP_DISMISS_FLAGS;
	[PInvokeData("winuser.h", MSDNShortId = "NE:winuser.__unnamed_enum_2")]
	public enum TOOLTIP_DISMISS_FLAGS
	{
		/// <summary>The window is registered to receive tooltip dismiss notifications.</summary>
		TDF_REGISTER,

		/// <summary>The window is unregistered from receiving tooltip dismiss notifications.</summary>
		TDF_UNREGISTER,
	}

	/// <summary>
	/// <para>Translates a string into the OEM-defined character set.</para>
	/// <para><c>Warning</c> Do not use. See Security Considerations.</para>
	/// </summary>
	/// <param name="pSrc">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The null-terminated string to be translated.</para>
	/// </param>
	/// <param name="pDst">
	/// <para>Type: <c>LPSTR</c></para>
	/// <para>
	/// The destination buffer, which receives the translated string. If the <c>CharToOem</c> function is being used as an ANSI function,
	/// the string can be translated in place by setting the lpszDst parameter to the same address as the lpszSrc parameter. This cannot
	/// be done if <c>CharToOem</c> is being used as a wide-character function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The return value is always nonzero except when you pass the same address to lpszSrc and lpszDst in the wide-character version of
	/// the function. In this case the function returns zero and GetLastError returns <c>ERROR_INVALID_ADDRESS</c>.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-chartooema BOOL CharToOemA( LPCSTR pSrc, LPSTR pDst );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CharToOem(string pSrc, [Out] StringBuilder pDst);

	/// <summary>Translates a specified number of characters in a string into the OEM-defined character set.</summary>
	/// <param name="lpszSrc">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The null-terminated string to be translated.</para>
	/// </param>
	/// <param name="lpszDst">
	/// <para>Type: <c>LPSTR</c></para>
	/// <para>
	/// The buffer for the translated string. If the <c>CharToOemBuff</c> function is being used as an ANSI function, the string can be
	/// translated in place by setting the lpszDst parameter to the same address as the lpszSrc parameter. This cannot be done if
	/// <c>CharToOemBuff</c> is being used as a wide-character function.
	/// </para>
	/// </param>
	/// <param name="cchDstLength">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The number of characters to translate in the string identified by the lpszSrc parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The return value is always nonzero except when you pass the same address to lpszSrc and lpszDst in the wide-character version of
	/// the function. In this case the function returns zero and GetLastError returns <c>ERROR_INVALID_ADDRESS</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// Unlike the CharToOem function, the <c>CharToOemBuff</c> function does not stop converting characters when it encounters a null
	/// character in the buffer pointed to by lpszSrc. The <c>CharToOemBuff</c> function converts all cchDstLength characters.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-chartooembuffa BOOL CharToOemBuffA( LPCSTR lpszSrc, LPSTR
	// lpszDst, DWORD cchDstLength );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CharToOemBuff(string lpszSrc, [Out] StringBuilder lpszDst, uint cchDstLength);

	/// <summary>
	/// Retrieves an AR_STATE value containing the state of screen auto-rotation for the system, for example whether auto-rotation is
	/// supported, and whether it is enabled by the user. <c>GetAutoRotationState</c> provides a robust and diverse way of querying for
	/// auto-rotation state, and more. For example, if you want your app to behave differently when multiple monitors are attached then
	/// you can determine that from the <c>AR_STATE</c> returned.
	/// </summary>
	/// <param name="pState">Pointer to a location in memory that will receive the current state of auto-rotation for the system.</param>
	/// <returns>
	/// <para>TRUE if the method succeeds, otherwise FALSE.</para>
	/// <para>See GetDisplayAutoRotationPreferences for an example of using this function.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getautorotationstate BOOL GetAutoRotationState( PAR_STATE
	// pState );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "E041717B-920E-44F8-AC7F-B30CB82F1476")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetAutoRotationState(out AR_STATE pState);

	/// <summary>
	/// <para>Translates a string from the OEM-defined character set into either an ANSI or a wide-character string.</para>
	/// <para><c>Warning</c> Do not use. See Security Considerations.</para>
	/// </summary>
	/// <param name="pSrc">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>A null-terminated string of characters from the OEM-defined character set.</para>
	/// </param>
	/// <param name="pDst">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// The destination buffer, which receives the translated string. If the <c>OemToChar</c> function is being used as an ANSI function,
	/// the string can be translated in place by setting the lpszDst parameter to the same address as the lpszSrc parameter. This cannot
	/// be done if <c>OemToChar</c> is being used as a wide-character function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The return value is always nonzero except when you pass the same address to lpszSrc and lpszDst in the wide-character version of
	/// the function. In this case the function returns zero and GetLastError returns <c>ERROR_INVALID_ADDRESS</c>.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-oemtochara BOOL OemToCharA( LPCSTR pSrc, LPSTR pDst );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OemToChar(string pSrc, [Out] StringBuilder pDst);

	/// <summary>
	/// Translates a specified number of characters in a string from the OEM-defined character set into either an ANSI or a
	/// wide-character string.
	/// </summary>
	/// <param name="lpszSrc">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>One or more characters from the OEM-defined character set.</para>
	/// </param>
	/// <param name="lpszDst">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// The destination buffer, which receives the translated string. If the <c>OemToCharBuff</c> function is being used as an ANSI
	/// function, the string can be translated in place by setting the lpszDst parameter to the same address as the lpszSrc parameter.
	/// This cannot be done if the <c>OemToCharBuff</c> function is being used as a wide-character function.
	/// </para>
	/// </param>
	/// <param name="cchDstLength">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The number of characters to be translated in the buffer identified by the lpszSrc parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The return value is always nonzero except when you pass the same address to lpszSrc and lpszDst in the wide-character version of
	/// the function. In this case the function returns zero and GetLastError returns <c>ERROR_INVALID_ADDRESS</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// Unlike the OemToChar function, the <c>OemToCharBuff</c> function does not stop converting characters when it encounters a null
	/// character in the buffer pointed to by lpszSrc. The <c>OemToCharBuff</c> function converts all cchDstLength characters.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-oemtocharbuffa BOOL OemToCharBuffA( LPCSTR lpszSrc, LPSTR
	// lpszDst, DWORD cchDstLength );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OemToCharBuff(string lpszSrc, [Out] StringBuilder lpszDst, uint cchDstLength);

	/// <summary>Registers or unregisters windows to receive notification to dismiss their tooltip windows.</summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>The handle of the window to receive the <c>WM_TOOLTIPDISMISS</c> message.</para>
	/// </param>
	/// <param name="tdFlags">
	/// <para>Type: <c>TOOLTIP_DISMISS_FLAGS</c></para>
	/// <para>
	/// A value of the enumeration that specifies whether the function registers or unregisters the window. <c>TDF_REGISTER</c> to
	/// register; <c>TDF_UNREGISTER</c> to unregister.
	/// </para>
	/// </param>
	/// <returns><c>TRUE</c> if the window was successfully registered or unregistered; otherwise, <c>FALSE</c>. (See Remarks.)</returns>
	/// <remarks>
	/// <para>
	/// This function makes tooltips more accessible by letting apps and frameworks that support tooltips register and unregister to be
	/// notified by a <c>WM_TOOLTIPDISMISS</c> message when the system requires all showing tooltips to be dismissed.
	/// </para>
	/// <para>
	/// Apps should register for this notification each time they show a tooltip and hide their tooltips in response to a
	/// <c>WM_TOOLTIPDISMISS</c> message. When a tooltip is hidden for some other reason, like a mouse action, the app should unregister.
	/// </para>
	/// <para>
	/// System-defined triggers for tooltip dismissal include a solitary Ctrl key up or Ctrl+Shift+F10. (The set of triggers may change
	/// over time.)
	/// </para>
	/// <para>The function takes either the <c>HWND</c> of a tooltip window or the <c>HWND</c> of an app window that has child tooltips.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If a tooltip <c>HWND</c> itself is registered, the tooltip window is expected to register upon showing and to dismiss upon
	/// receiving a <c>WM_TOOLTIPDISMISS</c> message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If an app <c>HWND</c> registers on behalf of its tooltips, the app's window is expected to register upon showing tooltips and
	/// dismiss all of its tooltips upon receiving a <c>WM_TOOLTIPDISMISS</c> message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Tooltip or app windows are expected to call the function to register each time tooltips are shown. Registered windows are
	/// automatically unregistered upon posting <c>WM_TOOLTIPDISMISS</c>.
	/// </para>
	/// <para>
	/// The <c>TDF_UNREGISTER</c> flag is used to explicitly unregister a window when a tooltip window is dismissed by application or
	/// framework prerogative (such as moving the cursor out of the "safe zone"). If an app or framework calls with <c>TDF_UNREGISTER</c>
	/// after the window has been automatically unregistered, the function returns <c>FALSE</c>. There is no impact on future registrations.
	/// </para>
	/// <para>Return values</para>
	/// <para>The HWND passed into the function must be owned by the calling process; otherwise, the function returns <c>FALSE</c>.</para>
	/// <para>
	/// When called with <c>TDF_REGISTER</c> and a window belonging to the calling process, the function returns <c>TRUE</c> if the
	/// window was successfully registered or <c>FALSE</c> if the window was already registered. The window is treated as registered
	/// either way.
	/// </para>
	/// <para>
	/// When called with <c>TDF_UNREGISTER</c> and a windows belonging to the calling process, the function returns <c>TRUE</c> if the
	/// window is successfully unregistered, or <c>FALSE</c> if the windows was not currently registered. The window is treated as
	/// unregistered either way.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerfortooltipdismissnotification?view=vs-2019
	// BOOL RegisterForTooltipDismissNotification( HWND hWnd, TOOLTIP_DISMISS_FLAGS tdFlags );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.RegisterForTooltipDismissNotification")]
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RegisterForTooltipDismissNotification([In, AddAsMember] HWND hWnd, TOOLTIP_DISMISS_FLAGS tdFlags);

	/// <summary>
	/// <para>Sets the last-error code.</para>
	/// <para>Currently, this function is identical to the SetLastError function. The second parameter is ignored.</para>
	/// </summary>
	/// <param name="dwErrCode">The last-error code for the thread.</param>
	/// <param name="dwType">This parameter is ignored.</param>
	/// <remarks>
	/// <para>The last-error code is kept in thread local storage so that multiple threads do not overwrite each other's values.</para>
	/// <para>
	/// Most functions call SetLastError or <c>SetLastErrorEx</c> only when they fail. However, some system functions call
	/// <c>SetLastError</c> or <c>SetLastErrorEx</c> under conditions of success; those cases are noted in each function's documentation.
	/// </para>
	/// <para>
	/// Applications can optionally retrieve the value set by this function by using the GetLastError function immediately after a
	/// function fails.
	/// </para>
	/// <para>
	/// Error codes are 32-bit values (bit 31 is the most significant bit). Bit 29 is reserved for application-defined error codes; no
	/// system error code has this bit set. If you are defining an error code for your application, set this bit to indicate that the
	/// error code has been defined by the application and to ensure that your error code does not conflict with any system-defined error codes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setlasterrorex void SetLastErrorEx( DWORD dwErrCode, DWORD
	// dwType );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "d97494db-868a-49d4-a613-e8beba86d4e6")]
	public static extern void SetLastErrorEx(uint dwErrCode, uint dwType = 0);

	/// <summary>For all notifications coming through WM_COMMAND, the <c>wParam</c> parameter can be cast to <see cref="CmdNotifyWParam"/>.</summary>
	/// <remarks>Initializes a new instance of the <see cref="CmdNotifyWParam"/> struct.</remarks>
	/// <param name="wParam">A WPARAM value.</param>
	[StructLayout(LayoutKind.Sequential)]
	public struct CmdNotifyWParam(IntPtr wParam)
	{
		/// <summary>The control's identifier.</summary>
		public ushort ctrlId = Macros.LOWORD(wParam);

		/// <summary>The notification code.</summary>
		public ushort notification = Macros.HIWORD(wParam);
	}
}