namespace Vanara.PInvoke;

public static partial class User32
{
	private const int ECM_FIRST = 0x1500;

	/// <summary>Window messages for the edit control.</summary>
	[PInvokeData("Winuser.h", MSDNShortId = "edit_control_constants")]
	public enum EditMessage
	{
		/// <summary>Gets the starting and ending character positions (in <c>TCHAR</c>s) of the current selection in an edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>A pointer to a <c>DWORD</c> value that receives the starting position of the selection. This parameter can be <c>NULL</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>DWORD</c> value that receives the position of the first unselected character after the end of the selection. This parameter can be <c>NULL</c>.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is a zero-based value with the starting position of the selection in the <c>LOWORD</c> and the position of the first <c>TCHAR</c> after the last selected <c>TCHAR</c> in the <c>HIWORD</c>. If either of these values exceeds 65,535, the return value is -1.</para>
		/// <para>It is better to use the values returned in wParam and lParam because they are full 32-bit values.</para>
		/// <remarks>
		/// <para>If there is no selection, the starting and ending values are both the position of the caret.</para>
		/// <para><c>Rich edit controls:</c> You can also use the <c>EM_EXGETSEL</c> message to retrieve the same information. <c>EM_EXGETSEL</c> also returns starting and ending character positions as 32-bit values.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getsel
		[MsgParams(typeof(uint?), typeof(uint?), LResultType = typeof(uint))]
		EM_GETSEL = 0x00B0,

		/// <summary>Selects a range of characters in an edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The starting character position of the selection.</para>
		/// <para><em>lParam</em></para>
		/// <para>The ending character position of the selection.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>The start value can be greater than the end value. The lower of the two values specifies the character position of the first character in the selection. The higher value specifies the position of the first character beyond the selection.</para>
		/// <para>The start value is the anchor point of the selection, and the end value is the active end. If the user uses the SHIFT key to adjust the size of the selection, the active end can move but the anchor point remains the same.</para>
		/// <para>If the start is 0 and the end is -1, all the text in the edit control is selected. If the start is -1, any current selection is deselected.</para>
		/// <para><c>Edit controls:</c> The control displays a flashing caret at the end position regardless of the relative values of start and end.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// <para>If the edit control has the <c>ES_NOHIDESEL</c> style, the selected text is highlighted regardless of whether the control has focus. Without the <c>ES_NOHIDESEL</c> style, the selected text is highlighted only when the edit control has the focus.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setsel
		[MsgParams(typeof(int), typeof(int), LResultType = null)]
		EM_SETSEL = 0x00B1,

		/// <summary>Gets the formatting rectangle of an edit control. The formatting rectangle is the limiting rectangle into which the control draws the text. The limiting rectangle is independent of the size of the edit-control window. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>RECT</c> structure that receives the formatting rectangle.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is not meaningful.</para>
		/// <remarks>
		/// <para>You can modify the formatting rectangle of a multiline edit control by using the <c>EM_SETRECT</c> and <c>EM_SETRECTNP</c> messages.</para>
		/// <para>Under certain conditions, <c>EM_GETRECT</c> might not return the exact values that <c>EM_SETRECT</c> or <c>EM_SETRECTNP</c> set it will be approximately correct, but it can be off by a few pixels.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. The formatting rectangle does not include the selection bar, which is an unmarked area to the left of each paragraph. When clicked, the selection bar selects the line. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getrect
		[MsgParams(null, typeof(RECT?), LResultType = null)]
		EM_GETRECT = 0x00B2,

		/// <summary>
		/// <para>Sets the formatting rectangle of a multiline edit control. The formatting rectangle is the limiting rectangle into which the control draws the text. The limiting rectangle is independent of the size of the edit control window.</para>
		/// <para>This message is processed only by multiline edit controls. You can send this message to either an edit control or a rich edit control.</para>
		/// </summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para><c>Rich Edit 2.0 and later:</c> Indicates whether lParam specifies absolute or relative coordinates. A value of zero indicates absolute coordinates. A value of 1 indicates offsets relative to the current formatting rectangle. (The offsets can be positive or negative.)</para>
		/// <para><c>Edit controls and Rich Edit 1.0:</c> This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>RECT</c> structure that specifies the new dimensions of the rectangle. If this parameter is <c>NULL</c>, the formatting rectangle is set to its default values.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>Setting lParam to <c>NULL</c> has no effect if a touch device is installed, or if <c>EM_SETRECT</c> is sent from a thread that has a hook installed (see <c>SetWindowsHookEx</c>). In these cases, lParam should contain a valid pointer to a <c>RECT</c> structure.</para>
		/// <para>The <c>EM_SETRECT</c> message causes the text of the edit control to be redrawn. To change the size of the formatting rectangle without redrawing the text, use the <c>EM_SETRECTNP</c> message.</para>
		/// <para>When an edit control is first created, the formatting rectangle is set to a default size. You can use the <c>EM_SETRECT</c> message to make the formatting rectangle larger or smaller than the edit control window.</para>
		/// <para>If the edit control does not have a horizontal scroll bar, and the formatting rectangle is set to be larger than the edit control window, lines of text exceeding the width of the edit control window (but smaller than the width of the formatting rectangle) are clipped instead of wrapped.</para>
		/// <para>If the edit control contains a border, the formatting rectangle is reduced by the size of the border. If you are adjusting the rectangle returned by an <c>EM_GETRECT</c> message, you must remove the size of the border before using the rectangle with the <c>EM_SETRECT</c> message.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. The formatting rectangle does not include the selection bar, which is an unmarked area to the left of each paragraph. When the user clicks in the selection bar, the corresponding line is selected. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setrect
		[MsgParams(typeof(BOOL), typeof(RECT?), LResultType = null)]
		EM_SETRECT = 0x00B3,

		/// <summary>
		/// <para>Sets the formatting rectangle of a multiline edit control. The <c>EM_SETRECTNP</c> message is identical to the <c>EM_SETRECT</c> message, except that <c>EM_SETRECTNP</c> does not redraw the edit control window.</para>
		/// <para>The formatting rectangle is the limiting rectangle into which the control draws the text. The limiting rectangle is independent of the size of the edit control window.</para>
		/// <para>This message is processed only by multiline edit controls. You can send this message to either an edit control or a rich edit control.</para>
		/// </summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para><c>Rich Edit 3.0 and later:</c> Indicates whether the new rectangle contains absolute or relative coordinates. A value of zero indicates absolute coordinates. A value of 1 indicates offsets relative to the current formatting rectangle. (The offsets can be positive or negative.)</para>
		/// <para><c>Edit controls:</c> This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>RECT</c> structure that specifies the new dimensions of the rectangle. If this parameter is <c>NULL</c>, the formatting rectangle is set to its default values.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>This message does not return a value.</para>
		/// <remarks><c>Rich Edit:</c> Supported in Microsoft Rich Edit 3.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setrectnp
		[MsgParams(typeof(BOOL), typeof(RECT?), LResultType = null)]
		EM_SETRECTNP = 0x00B4,

		/// <summary>Scrolls the text vertically in a multiline edit control. This message is equivalent to sending a <c>WM_VSCROLL</c> message to the edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The action the scroll bar is to take. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SB_LINEDOWN</c></description>
		/// <description>Scrolls down one line.</description>
		/// </item>
		/// <item>
		/// <description><c>SB_LINEUP</c></description>
		/// <description>Scrolls up one line.</description>
		/// </item>
		/// <item>
		/// <description><c>SB_PAGEDOWN</c></description>
		/// <description>Scrolls down one page.</description>
		/// </item>
		/// <item>
		/// <description><c>SB_PAGEUP</c></description>
		/// <description>Scrolls up one page.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>If the message is successful, the <c>HIWORD</c> of the return value is <c>TRUE</c>, and the <c>LOWORD</c> is the number of lines that the command scrolls. The number returned may not be the same as the actual number of lines scrolled if the scrolling moves to the beginning or the end of the text. If the wParam parameter specifies an invalid value, the return value is <c>FALSE</c>.</para>
		/// <remarks>
		/// <para>To scroll to a specific line or character position, use the <c>EM_LINESCROLL</c> message. To scroll the caret into view, use the <c>EM_SCROLLCARET</c> message.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-scroll
		[MsgParams(typeof(SBCMD), null, LResultType = typeof(uint))]
		EM_SCROLL = 0x00B5,

		/// <summary>Scrolls the text in a multiline edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para><c>Edit controls:</c> The number of characters to scroll horizontally.</para>
		/// <para><c>Rich edit controls:</c> This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>The number of lines to scroll vertically.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>If the message is sent to a multiline edit control, the return value is <c>TRUE</c>.</para>
		/// <para>If the message is sent to a single-line edit control, the return value is <c>FALSE</c>.</para>
		/// <remarks>
		/// <para>The control does not scroll vertically past the last line of text in the edit control. If the current line plus the number of lines specified by the lParam parameter exceeds the total number of lines in the edit control, the value is adjusted so that the last line of the edit control is scrolled to the top of the edit-control window.</para>
		/// <para><c>Edit controls:</c> The <c>EM_LINESCROLL</c> message scrolls the text vertically or horizontally in a multiline edit control. The <c>EM_LINESCROLL</c> message can be used to scroll horizontally past the last character of any line.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. The <c>EM_LINESCROLL</c> message scrolls the text vertically in a multiline edit control. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-linescroll
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(BOOL))]
		EM_LINESCROLL = 0x00B6,

		/// <summary>Scrolls the caret into view in an edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is reserved. It should be set to zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is reserved. It should be set to zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is not meaningful.</para>
		/// <remarks><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-scrollcaret
		[MsgParams(LResultType = null)]
		EM_SCROLLCARET = 0x00B7,

		/// <summary>Gets the state of an edit control's modification flag. The flag indicates whether the contents of the edit control have been modified. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>If the contents of edit control have been modified, the return value is nonzero; otherwise, it is zero.</para>
		/// <remarks>
		/// <para>The system automatically clears the modification flag to zero when the control is created. If the user changes the control's text, the system sets the flag to nonzero. You can send the <c>EM_SETMODIFY</c> message to the edit control to set or clear the flag.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getmodify
		[MsgParams(LResultType = typeof(BOOL))]
		EM_GETMODIFY = 0x00B8,

		/// <summary>Sets or clears the modification flag for an edit control. The modification flag indicates whether the text within the edit control has been modified. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The new value for the modification flag. A value of <c>TRUE</c> indicates the text has been modified, and a value of <c>FALSE</c> indicates it has not been modified.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>The system automatically clears the modification flag to zero when the control is created. If the user changes the control's text, the system sets the flag to nonzero. You can send the <c>EM_GETMODIFY</c> message to the edit control to retrieve the current state of the flag.</para>
		/// <para><c>Rich Edit 1.0:</c> Objects created without the <c>REO_DYNAMICSIZE</c> flag will lock in their extents when the modify flag is set to <c>FALSE</c>.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setmodify
		[MsgParams(typeof(BOOL), null, LResultType = null)]
		EM_SETMODIFY = 0x00B9,

		/// <summary>Gets the number of lines in a multiline edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is an integer specifying the total number of text lines in the multiline edit control or rich edit control. If the control has no text, the return value is 1. The return value will never be less than 1.</para>
		/// <remarks>
		/// <para>The <c>EM_GETLINECOUNT</c> message retrieves the total number of text lines, not just the number of lines that are currently visible.</para>
		/// <para>If the Wordwrap feature is enabled, the number of lines can change when the dimensions of the editing window change.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getlinecount
		[MsgParams(LResultType = typeof(int))]
		EM_GETLINECOUNT = 0x00BA,

		/// <summary>Gets the character index of the first character of a specified line in a multiline edit control. A character index is the zero-based index of the character from the beginning of the edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based line number. A value of -1 specifies the current line number (the line that contains the caret).</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the character index of the line specified in the wParam parameter, or it is -1 if the specified line number is greater than the number of lines in the edit control.</para>
		/// <remarks><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-lineindex
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		EM_LINEINDEX = 0x00BB,

		/// <summary>Sets the handle of the memory that will be used by a multiline edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the memory buffer the edit control uses to store the currently displayed text instead of allocating its own memory. If necessary, the control reallocates this memory.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>Before an application sets a new memory handle, it should send an <c>EM_GETHANDLE</c> message to retrieve the handle of the current memory buffer and should free that memory.</para>
		/// <para>An edit control automatically reallocates the given buffer whenever it needs additional space for text, or it removes enough text so that additional space is no longer needed.</para>
		/// <para>Sending an <c>EM_SETHANDLE</c> message clears the undo buffer (<c>EM_CANUNDO</c> returns zero) and the internal modification flag (<c>EM_GETMODIFY</c> returns zero). The edit control window is redrawn.</para>
		/// <para><c>Rich Edit:</c> The <c>EM_SETHANDLE</c> message is not supported. Rich edit controls do not store text as a simple array of characters.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-sethandle
		[MsgParams(typeof(Kernel32.HLOCAL), null, LResultType = null)]
		EM_SETHANDLE = 0x00BC,

		/// <summary>Gets a handle of the memory currently allocated for a multiline edit control's text.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is a memory handle identifying the buffer that holds the content of the edit control. If an error occurs, such as sending the message to a single-line edit control, the return value is zero.</para>
		/// <remarks>
		/// <para>If the function succeeds, the application can access the contents of the edit control by casting the return value to <c>HLOCAL</c> and passing it to <c>LocalLock</c>. <c>LocalLock</c> returns a pointer to a buffer that is a null-terminated array of <c>CHAR</c>s or <c>WCHAR</c>s, depending on whether an ANSI or Unicode function created the control. For example, if <c>CreateWindowExA</c> was used the buffer is an array of <c>CHAR</c>s, but if <c>CreateWindowExW</c> was used the buffer is an array of <c>WCHAR</c>s. The application may not change the contents of the buffer. To unlock the buffer, the application calls <c>LocalUnlock</c> before allowing the edit control to receive new messages.</para>
		/// <para><para>Note</para> <para>For Comctl32.dll version 6, the buffer always contains an array of <c>WCHAR</c>s, regardless of whether an ANSI or Unicode function created the edit control. For more information on DLL versions, see Common Control Versions.</para></para>
		/// <para>If your application cannot abide by the restrictions imposed by <c>EM_GETHANDLE</c>, use the <c>GetWindowTextLength</c> and <c>GetWindowText</c> functions to copy the contents of the edit control into an application-provided buffer.</para>
		/// <para><c>Rich Edit:</c> The <c>EM_GETHANDLE</c> message is not supported. Rich edit controls do not store text as a simple array of characters.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gethandle
		[MsgParams(LResultType = typeof(Kernel32.HLOCAL))]
		EM_GETHANDLE = 0x00BD,

		/// <summary>Gets the position of the scroll box (thumb) in the vertical scroll bar of a multiline edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the position of the scroll box.</para>
		/// <remarks><c>Rich Edit:</c> Supported in Microsoft Rich Edit 2.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getthumb
		[MsgParams(LResultType = typeof(int))]
		EM_GETTHUMB = 0x00BE,

		/// <summary>Retrieves the length, in characters, of a line in an edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The character index of a character in the line whose length is to be retrieved. If this parameter is greater than the number of characters in the control, the return value is zero.</para>
		/// <para>This parameter can be -1. In this case, the message returns the number of unselected characters on lines containing selected characters. For example, if the selection extended from the fourth character of one line through the eighth character from the end of the next line, the return value would be 10 (three characters on the first line and seven on the next).</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>For multiline edit controls, the return value is the length, in <c>TCHAR</c>s, of the line specified by the wParam parameter. For ANSI text, this is the number of bytes; for Unicode text, this is the number of characters. It does not include the carriage-return character at the end of the line.</para>
		/// <para>For single-line edit controls, the return value is the length, in <c>TCHAR</c>s, of the text in the edit control.</para>
		/// <para>If wParam is greater than the number of characters in the control, the return value is zero.</para>
		/// <remarks>
		/// <para>Use the <c>EM_LINEINDEX</c> message to retrieve a character index for a given line number within a multiline edit control.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-linelength
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		EM_LINELENGTH = 0x00C1,

		/// <summary>Replaces the selected text in an edit control or a rich edit control with the specified text.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies whether the replacement operation can be undone. If this is <c>TRUE</c>, the operation can be undone. If this is <c>FALSE</c> , the operation cannot be undone.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a null-terminated string containing the replacement text.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>Use the <c>EM_REPLACESEL</c> message to replace only a portion of the text in an edit control. To replace all of the text, use the <c>WM_SETTEXT</c> message.</para>
		/// <para>If there is no selection, the replacement text is inserted at the caret.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// <para>In a rich edit control, the replacement text takes the formatting of the character at the caret or, if there is a selection, of the first character in the selection.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-replacesel
		[MsgParams(typeof(BOOL), typeof(string), LResultType = null)]
		EM_REPLACESEL = 0x00C2,
		EM_GETLINE             = 0x00C4,
		EM_LIMITTEXT           = 0x00C5,
		EM_CANUNDO             = 0x00C6,
		EM_UNDO                = 0x00C7,
		EM_FMTLINES            = 0x00C8,
		EM_LINEFROMCHAR        = 0x00C9,
		EM_SETTABSTOPS         = 0x00CB,
		EM_SETPASSWORDCHAR     = 0x00CC,
		EM_EMPTYUNDOBUFFER     = 0x00CD,
		EM_GETFIRSTVISIBLELINE = 0x00CE,
		EM_SETREADONLY         = 0x00CF,
		EM_SETWORDBREAKPROC    = 0x00D0,
		EM_GETWORDBREAKPROC    = 0x00D1,
		EM_GETPASSWORDCHAR     = 0x00D2,
		EM_SETMARGINS          = 0x00D3,
		EM_GETMARGINS          = 0x00D4,
		EM_SETLIMITTEXT        = EM_LIMITTEXT,   /* ;win40 Name change */
		EM_GETLIMITTEXT        = 0x00D5,
		EM_POSFROMCHAR         = 0x00D6,
		EM_CHARFROMPOS         = 0x00D7,
		EM_SETIMESTATUS        = 0x00D8,
		EM_GETIMESTATUS        = 0x00D9,
		EM_ENABLEFEATURE       = 0x00DA,
		EM_SETCUEBANNER        = ECM_FIRST + 1,     // Set the cue banner with the lParm = LPCWSTR
		EM_GETCUEBANNER        = ECM_FIRST + 2,     // Set the cue banner with the lParm = LPCWSTR
		EM_SHOWBALLOONTIP      = ECM_FIRST + 3,     // Show a balloon tip associated to the edit control
		EM_HIDEBALLOONTIP      = ECM_FIRST + 4,     // Hide any balloon tip associated with the edit control
		//EM_SETHILITE           = ECM_FIRST + 5,
		//EM_GETHILITE           = ECM_FIRST + 6,
		EM_NOSETFOCUS          = ECM_FIRST + 7,
		EM_TAKEFOCUS           = ECM_FIRST + 8,
	}

	public enum EditNotification
	{
		EN_SETFOCUS = 0x0100,
		EN_KILLFOCUS = 0x0200,
		EN_CHANGE = 0x0300,
		EN_UPDATE = 0x0400,
		EN_ERRSPACE = 0x0500,
		EN_MAXTEXT = 0x0501,
		EN_HSCROLL = 0x0601,
		EN_VSCROLL = 0x0602,
		EN_ALIGN_LTR_EC = 0x0700,
		EN_ALIGN_RTL_EC = 0x0701,
		EN_BEFORE_PASTE = 0x0800,
		EN_AFTER_PASTE = 0x0801,
	}
}