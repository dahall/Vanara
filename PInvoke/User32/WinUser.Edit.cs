using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class User32
{
	private const int ECM_FIRST = 0x1500;

	/// <summary>
	/// <para>An application-defined callback function used with the EM_SETWORDBREAKPROC message. A multiline edit control or a rich edit control calls an <c>EditWordBreakProc</c> function to break a line of text.</para>
	/// <para>The <c>EDITWORDBREAKPROC</c> type defines a pointer to this callback function. <c>EditWordBreakProc</c> is a placeholder for the application-defined function name.</para>
	/// </summary>
	/// <param name="lpch">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>A pointer to the text of the edit control.</para>
	/// </param>
	/// <param name="ichCurrent">
	/// <para>Type: <c>int</c></para>
	/// <para>An index to a character position in the buffer of text that identifies the point at which the function should begin checking for a word break.</para>
	/// </param>
	/// <param name="cch">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of <c>TCHARs</c> in the edit control text. For the ANSI text, this is the number of bytes; for the Unicode text, this is the number of WCHARs.</para>
	/// </param>
	/// <param name="code">
	/// <para>Type: <c>int</c></para>
	/// <para>The action to be taken by the callback function. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>WB_CLASSIFY</c></description>
	/// <description>Retrieves the character class and word break flags of the character at the specified position. This value is for use with rich edit controls.</description>
	/// </item>
	/// <item>
	/// <description><c>WB_ISDELIMITER</c></description>
	/// <description>Checks whether the character at the specified position is a delimiter.</description>
	/// </item>
	/// <item>
	/// <description><c>WB_LEFT</c></description>
	/// <description>Finds the beginning of a word to the left of the specified position.</description>
	/// </item>
	/// <item>
	/// <description><c>WB_LEFTBREAK</c></description>
	/// <description>Finds the end-of-word delimiter to the left of the specified position. This value is for use with rich edit controls.</description>
	/// </item>
	/// <item>
	/// <description><c>WB_MOVEWORDLEFT</c></description>
	/// <description>Finds the beginning of a word to the left of the specified position. This value is used during CTRL+LEFT key processing. This value is for use with rich edit controls.</description>
	/// </item>
	/// <item>
	/// <description><c>WB_MOVEWORDRIGHT</c></description>
	/// <description>Finds the beginning of a word to the right of the specified position. This value is used during CTRL+RIGHT key processing. This value is for use with rich edit controls.</description>
	/// </item>
	/// <item>
	/// <description><c>WB_RIGHT</c></description>
	/// <description>Finds the beginning of a word to the right of the specified position. This is useful in right-aligned edit controls.</description>
	/// </item>
	/// <item>
	/// <description><c>WB_RIGHTBREAK</c></description>
	/// <description>Finds the end-of-word delimiter to the right of the specified position. This is useful in right-aligned edit controls. This value is for use with rich edit controls.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the <c>code</c> parameter specifies <c>WB_ISDELIMITER</c>, the return value is nonzero (TRUE) if the character at the specified position is a delimiter, or zero if it is not. If the <c>code</c> parameter specifies <c>WB_CLASSIFY</c>, the return value is the character class and word break flags of the character at the specified position. Otherwise, the return value is an index to the beginning of a word in the buffer of text.</para>
	/// </returns>
	/// <remarks>
	/// <para>A carriage return followed by a line feed must be treated as a single word by the callback function. Two carriage returns followed by a line feed also must be treated as a single word.</para>
	/// <para>An application must install the callback function by specifying the address of the callback function in an EM_SETWORDBREAKPROC message.</para>
	/// <para><c>Rich Edit 1.0:</c>Microsoft Rich EditÂ 1.0 only passes back ANSI characters to <c>EditWordBreakProc</c>. For rich edit controls, you can alternately use the EM_SETWORDBREAKPROCEX message to replace the default extended word break procedure with an EditWordBreakProcEx callback function. This function provides additional information about the text, such as the character set.</para>
	/// <para><c>Rich Edit 2.0 and later:</c>Microsoft Rich EditÂ 2.0 and later only pass back Unicode characters to <c>EditWordBreakProc</c>. Thus, an ANSI application would convert the Rich Edit-supplied Unicode string using WideCharToMultiByte, and then translate the indices appropriately.</para>
	/// <para><para>Note</para> <para>The winuser.h header defines EDITWORDBREAKPROC as an alias which automatically selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for Function Prototypes.</para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-editwordbreakproca
	// EDITWORDBREAKPROCA Editwordbreakproca; int Editwordbreakproca( [in] LPSTR lpch, [in] int ichCurrent, [in] int cch, [in] int code ) {...}
	[PInvokeData("winuser.h", MSDNShortId = "NC:winuser.EDITWORDBREAKPROCA")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false, CharSet = CharSet.Auto)]
	public delegate int EDITWORDBREAKPROC([MarshalAs(UnmanagedType.LPTStr)] string lpch, int ichCurrent, int cch, WB code);

	/// <summary>Word-break constants.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "NC:winuser.EDITWORDBREAKPROCA")]
	public enum WB
	{
		/// <summary>Retrieves the character class and word break flags of the character at the specified position. This value is for use with rich edit controls.</summary>
		WB_CLASSIFY = 3,
		/// <summary>Checks whether the character at the specified position is a delimiter.</summary>
		WB_ISDELIMITER = 2,
		/// <summary>Finds the beginning of a word to the left of the specified position.</summary>
		WB_LEFT = 0,
		/// <summary>Finds the end-of-word delimiter to the left of the specified position. This value is for use with rich edit controls.</summary>
		WB_LEFTBREAK = 6,
		/// <summary>Finds the beginning of a word to the left of the specified position. This value is used during CTRL+LEFT key processing. This value is for use with rich edit controls.</summary>
		WB_MOVEWORDLEFT = 4,
		/// <summary>Finds the beginning of a word to the right of the specified position. This value is used during CTRL+RIGHT key processing. This value is for use with rich edit controls.</summary>
		WB_MOVEWORDRIGHT = 5,
		/// <summary>Finds the beginning of a word to the right of the specified position. This is useful in right-aligned edit controls.</summary>
		WB_RIGHT = 1,
		/// <summary>Finds the end-of-word delimiter to the right of the specified position. This is useful in right-aligned edit controls. This value is for use with rich edit controls.</summary>
		WB_RIGHTBREAK = 7,
	}

	/// <summary>Styles for the edit control.</summary>
	[PInvokeData("Winuser.h", MSDNShortId = "edit_control_constants")]
	[Flags]
	public enum EditStyle : uint
	{
		/// <summary>Left aligns text.</summary>
		ES_LEFT = 0x0000,
		/// <summary>Centers text in a single-line or multiline edit control.</summary>
		ES_CENTER = 0x0001,
		/// <summary>Right aligns text in a single-line or multiline edit control.</summary>
		ES_RIGHT = 0x0002,
		/// <summary>
		///   <para>Designates a multiline edit control. The default is single-line edit control.</para>
		///   <para>When the multiline edit control is in a dialog box, the default response to pressing the ENTER key is to activate the default button. To use the ENTER key as a carriage return, use the ES_WANTRETURN style.</para>
		///   <para>When the multiline edit control is not in a dialog box and the ES_AUTOVSCROLL style is specified, the edit control shows as many lines as possible and scrolls vertically when the user presses the ENTER key. If you do not specify ES_AUTOVSCROLL, the edit control shows as many lines as possible and beeps if the user presses the ENTER key when no more lines can be displayed.</para>
		///   <para>If you specify the ES_AUTOHSCROLL style, the multiline edit control automatically scrolls horizontally when the caret goes past the right edge of the control. To start a new line, the user must press the ENTER key. If you do not specify ES_AUTOHSCROLL, the control automatically wraps words to the beginning of the next line when necessary. A new line is also started if the user presses the ENTER key. The window size determines the position of the Wordwrap. If the window size changes, the Wordwrapping position changes and the text is redisplayed.</para>
		///   <para>Multiline edit controls can have scroll bars. An edit control with scroll bars processes its own scroll bar messages. Note that edit controls without scroll bars scroll as described in the previous paragraphs and process any scroll messages sent by the parent window.</para>
		/// </summary>
		ES_MULTILINE = 0x0004,
		/// <summary>Converts all characters to uppercase as they are typed into the edit control. To change this style after the control has been created, use SetWindowLong.</summary>
		ES_UPPERCASE = 0x0008,
		/// <summary>Converts all characters to lowercase as they are typed into the edit control. To change this style after the control has been created, use SetWindowLong.</summary>
		ES_LOWERCASE = 0x0010,
		/// <summary>Displays an asterisk (*) for each character typed into the edit control. This style is valid only for single-line edit controls.</summary>
		ES_PASSWORD = 0x0020,
		/// <summary>Automatically scrolls text up one page when the user presses the ENTER key on the last line.</summary>
		ES_AUTOVSCROLL = 0x0040,
		/// <summary>Automatically scrolls text to the right by 10 characters when the user types a character at the end of the line. When the user presses the ENTER key, the control scrolls all text back to position zero.</summary>
		ES_AUTOHSCROLL = 0x0080,
		/// <summary>Negates the default behavior for an edit control. The default behavior hides the selection when the control loses the input focus and inverts the selection when the control receives the input focus. If you specify ES_NOHIDESEL, the selected text is inverted, even if the control does not have the focus.</summary>
		ES_NOHIDESEL = 0x0100,
		/// <summary>Converts text entered in the edit control. The text is converted from the Windows character set to the OEM character set and then back to the Windows character set. This ensures proper character conversion when the application calls the CharToOem function to convert a Windows string in the edit control to OEM characters. This style is most useful for edit controls that contain file names that will be used on file systems that do not support Unicode.
		/// <para>To change this style after the control has been created, use SetWindowLong.</para></summary>
		ES_OEMCONVERT = 0x0400,
		/// <summary>Prevents the user from typing or editing text in the edit control.</summary>
		ES_READONLY = 0x0800,
		/// <summary>Specifies that a carriage return be inserted when the user presses the ENTER key while entering text into a multiline edit control in a dialog box. If you do not specify this style, pressing the ENTER key has the same effect as pressing the dialog box's default push button. This style has no effect on a single-line edit control.</summary>
		ES_WANTRETURN = 0x1000,
		/// <summary>Allows only digits to be entered into the edit control.</summary>
		ES_NUMBER = 0x2000,
	}

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

		/// <summary>Copies a line of text from an edit control and places it in a specified buffer. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the line to retrieve from a multiline edit control. A value of zero specifies the topmost line. This parameter is ignored by a single-line edit control.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to the buffer that receives a copy of the line. Before sending the message, set the first word of this buffer to the size, in <c>TCHAR</c>s, of the buffer. For ANSI text, this is the number of bytes; for Unicode text, this is the number of characters. The size in the first word is overwritten by the copied line.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the number of <c>TCHAR</c>s copied. The return value is zero if the line number specified by the wParam parameter is greater than the number of lines in the edit control.</para>
		/// <remarks>
		/// <para><c>Edit controls:</c> The copied line does not contain a terminating null character.</para>
		/// <para><c>Rich edit controls:</c> Supported in Microsoft Rich Edit 1.0 and later. The copied line does not contain a terminating null character, unless no text was copied. If no text was copied, the message places a null character at the beginning of the buffer. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getline
		[MsgParams(typeof(int), typeof(StrPtrAuto), LResultType = typeof(int))]
		EM_GETLINE = 0x00C4,

		/// <summary>
		/// <para>Sets the text limit of an edit control. The text limit is the maximum amount of text, in <c>TCHAR</c>s, that the user can type into the edit control. You can send this message to either an edit control or a rich edit control.</para>
		/// <para>For edit controls and Microsoft Rich Edit 1.0, bytes are used. For Microsoft Rich Edit 2.0 and later, characters are used.</para>
		/// </summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The maximum number of <c>TCHAR</c>s the user can enter. For ANSI text, this is the number of bytes; for Unicode text, this is the number of characters. This number does not include the terminating null character.</para>
		/// <para><c>Rich edit controls:</c> If this parameter is zero, the text length is set to 64,000 characters.</para>
		/// <para>If this parameter is zero, the text length is set to 0x7FFFFFFE characters for single-line edit controls or -1 for multiline edit controls.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>The <c>EM_LIMITTEXT</c> message limits only the text the user can enter. It does not affect any text already in the edit control when the message is sent, nor does it affect the length of the text copied to the edit control by the <c>WM_SETTEXT</c> message. If an application uses the <c>WM_SETTEXT</c> message to place more text into an edit control than is specified in the <c>EM_LIMITTEXT</c> message, the user can edit the entire contents of the edit control.</para>
		/// <para>Before <c>EM_LIMITTEXT</c> is called, the default limit for the amount of text a user can enter in an edit control is 32,767 characters.</para>
		/// <para>For single-line edit controls, the text limit is either 0x7FFFFFFE bytes or the value of the wParam parameter, whichever is smaller. For multiline edit controls, this value is either -1 byte or the value of the wParam parameter, whichever is smaller.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. Use the message <c>EM_EXLIMITTEXT</c> for text length values greater than 64,000. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-limittext
		[MsgParams(typeof(int), null, LResultType = null)]
		EM_LIMITTEXT = 0x00C5,

		/// <summary>Determines whether there are any actions in an edit control's undo queue. You can send this message to either an edit control or a rich edit control.</summary>
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
		/// <para>If there are actions in the control's undo queue, the return value is nonzero.</para>
		/// <para>If the undo queue is empty, the return value is zero.</para>
		/// <remarks>
		/// <para>If the undo queue is not empty, you can send the <c>EM_UNDO</c> message to the control to undo the most recent operation.</para>
		/// <para><c>Edit controls and Rich Edit 1.0:</c> The undo queue contains only the most recent operation.</para>
		/// <para><c>Rich Edit 2.0 and later:</c> The undo queue can contain multiple operations.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-canundo
		[MsgParams(LResultType = typeof(BOOL))]
		EM_CANUNDO = 0x00C6,

		/// <summary>This message undoes the last edit control operation in the control's undo queue. You can send this message to either an edit control or a rich edit control.</summary>
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
		/// <para>For a single-line edit control, the return value is always <c>TRUE</c>.</para>
		/// <para>For a multiline edit control, the return value is <c>TRUE</c> if the undo operation is successful, or <c>FALSE</c> if the undo operation fails.</para>
		/// <remarks>
		/// <para><c>Edit controls and Rich Edit 1.0:</c> An undo operation can also be undone. For example, you can restore deleted text with the first <c>EM_UNDO</c> message, and remove the text again with a second <c>EM_UNDO</c> message as long as there is no intervening edit operation.</para>
		/// <para><c>Rich Edit 2.0 and later:</c> The undo feature is multilevel so sending two <c>EM_UNDO</c> messages will undo the last two operations in the undo queue. To redo an operation, send the <c>EM_REDO</c> message.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-undo
		[MsgParams(LResultType = typeof(BOOL))]
		EM_UNDO = 0x00C7,

		/// <summary>Sets a flag that determines whether a multiline edit control includes soft line-break characters. A soft line break consists of two carriage returns and a line feed and is inserted at the end of a line that is broken because of wordwrapping.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies whether soft line-break characters are to be inserted. A value of <c>TRUE</c> inserts the characters; a value of <c>FALSE</c> removes them.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is identical to the wParam parameter.</para>
		/// <remarks>
		/// <para>This message affects only the buffer returned by the <c>EM_GETHANDLE</c> message and the text returned by the <c>WM_GETTEXT</c> message. It has no effect on the display of the text within the edit control.</para>
		/// <para>The <c>EM_FMTLINES</c> message does not affect a line that ends with a hard line break. A hard line break consists of one carriage return and a line feed.</para>
		/// <para><para>Note</para> <para>The size of the text changes when this message is processed.</para></para>
		/// <para><c>Rich Edit:</c> The <c>EM_FMTLINES</c> message is not supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-fmtlines
		[MsgParams(typeof(BOOL), null, LResultType = typeof(BOOL))]
		EM_FMTLINES = 0x00C8,

		/// <summary>Gets the index of the line that contains the specified character index in a multiline edit control. A character index is the zero-based index of the character from the beginning of the edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The character index of the character contained in the line whose number is to be retrieved. If this parameter is -1, <c>EM_LINEFROMCHAR</c> retrieves either the line number of the current line (the line containing the caret) or, if there is a selection, the line number of the line containing the beginning of the selection.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the zero-based line number of the line containing the character index specified by wParam.</para>
		/// <remarks><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. If the character index is greater than 64,000, use the <c>EM_EXLINEFROMCHAR</c> message. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-linefromchar
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		EM_LINEFROMCHAR = 0x00C9,

		/// <summary>
		/// <para>The <c>EM_SETTABSTOPS</c> message sets the tab stops in a multiline edit control. When text is copied to the control, any tab character in the text causes space to be generated up to the next tab stop.</para>
		/// <para>This message is processed only by multiline edit controls. You can send this message to either an edit control or a rich edit control.</para>
		/// </summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The number of tab stops contained in the array. If this parameter is zero, the lParam parameter is ignored and default tab stops are set at every 32 dialog template units. If this parameter is 1, tab stops are set at every n dialog template units, where n is the distance pointed to by the lParam parameter. If this parameter is greater than 1, lParam is a pointer to an array of tab stops.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to an array of unsigned integers specifying the tab stops, in dialog template units. If the wParam parameter is 1, this parameter is a pointer to an unsigned integer containing the distance between all tab stops, in dialog template units.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>If all the tabs are set, the return value is <c>TRUE</c>.</para>
		/// <para>If all the tabs are not set, the return value is <c>FALSE</c>.</para>
		/// <remarks>
		/// <para>The <c>EM_SETTABSTOPS</c> message does not automatically redraw the edit control window. If the application is changing the tab stops for text already in the edit control, it should call the <c>InvalidateRect</c> function to redraw the edit control window.</para>
		/// <para>The values specified in the array are in dialog template units, which are the device-independent units used in dialog box templates. To convert measurements from dialog template units to screen units (pixels), use the <c>MapDialogRect</c> function.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 3.0 and later. A rich edit control can have the maximum number of tab stops specified by MAX_TAB_STOPS. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-settabstops
		[MsgParams(typeof(uint), typeof(uint[]), LResultType = typeof(BOOL))]
		EM_SETTABSTOPS = 0x00CB,

		/// <summary>Sets or removes the password character for an edit control. When a password character is set, that character is displayed in place of the characters typed by the user. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>The character to be displayed in place of the characters typed by the user. If this parameter is zero, the control removes the current password character and displays the characters typed by the user.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>When an edit control receives the <c>EM_SETPASSWORDCHAR</c> message, the control redraws all visible characters using the character specified by the wParam parameter. If wParam is zero, the control redraws all visible characters using the characters typed by the user.</para>
		/// <para>If an edit control is created with the <c>ES_PASSWORD</c> style, the default password character is set to an asterisk (*). If an edit control is created without the <c>ES_PASSWORD</c> style, there is no password character. The <c>ES_PASSWORD</c> style is removed if an <c>EM_SETPASSWORDCHAR</c> message is sent with the wParam parameter set to zero.</para>
		/// <para><c>Edit controls:</c> Multiline edit controls do not support the password style or messages.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 2.0 and later. Both single-line and multiline edit controls support the password style and messages. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setpasswordchar
		[MsgParams(typeof(char), null, LResultType = null)]
		EM_SETPASSWORDCHAR = 0x00CC,

		/// <summary>Resets the undo flag of an edit control. The undo flag is set whenever an operation within the edit control can be undone. You can send this message to either an edit control or a rich edit control.</summary>
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
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>The undo flag is automatically reset whenever the edit control receives a <c>WM_SETTEXT</c> or <c>EM_SETHANDLE</c> message.</para>
		/// <para><c>Edit controls and Rich Edit 1.0:</c> The control can only undo or redo the most recent operation.</para>
		/// <para><c>Rich Edit 2.0 and later:</c> The <c>EM_EMPTYUNDOBUFFER</c> message empties all undo and redo buffers. Rich edit controls enable the user to undo or redo multiple operations.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-emptyundobuffer
		[MsgParams(LResultType = null)]
		EM_EMPTYUNDOBUFFER = 0x00CD,

		/// <summary>Gets the zero-based index of the uppermost visible line in a multiline edit control. You can send this message to either an edit control or a rich edit control.</summary>
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
		/// <para>The return value is the zero-based index of the uppermost visible line in a multiline edit control.</para>
		/// <para><c>Edit controls:</c> For single-line edit controls, the return value is the zero-based index of the first visible character.</para>
		/// <para><c>Rich edit controls:</c> For single-line rich edit controls, the return value is zero.</para>
		/// <remarks>
		/// <para>The number of lines and the length of the lines in an edit control depend on the width of the control and the current Wordwrap setting.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getfirstvisibleline
		[MsgParams(LResultType = typeof(int))]
		EM_GETFIRSTVISIBLELINE = 0x00CE,

		/// <summary>Sets or removes the read-only style (<c>ES_READONLY</c>) of an edit control. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies whether to set or remove the <c>ES_READONLY</c> style. A value of <c>TRUE</c> sets the <c>ES_READONLY</c> style; a value of <c>FALSE</c> removes the <c>ES_READONLY</c> style.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>If the operation succeeds, the return value is nonzero.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// <remarks>
		/// <para>When an edit control has the <c>ES_READONLY</c> style, the user cannot change the text within the edit control.</para>
		/// <para>To determine whether an edit control has the <c>ES_READONLY</c> style, use the <c>GetWindowLong</c> function with the GWL_STYLE flag.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setreadonly
		[MsgParams(typeof(BOOL), null, LResultType = typeof(BOOL))]
		EM_SETREADONLY = 0x00CF,

		/// <summary>Replaces an edit control's default Wordwrap function with an application-defined Wordwrap function. You can send this message to either an edit control or a rich edit control.</summary>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>The address of the application-defined Wordwrap function. For more information about breaking lines, see the description of the EditWordBreakProc callback function.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>A Wordwrap function scans a text buffer that contains text to be sent to the screen, looking for the first word that does not fit on the current screen line. The Wordwrap function places this word at the beginning of the next line on the screen.</para>
		/// <para>A Wordwrap function defines the point at which the system should break a line of text for multiline edit controls, usually at a space character that separates two words. Either a multiline or a single-line edit control might call this function when the user presses arrow keys in combination with the CTRL key to move the caret to the next word or previous word. The default Wordwrap function breaks a line of text at a space character. The application-defined function may define the Wordwrap to occur at a hyphen or a character other than the space character.</para>
		/// <para><c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setwordbreakproc
		[MsgParams(null, typeof(EditWordBreakProc), LResultType = null)]
		EM_SETWORDBREAKPROC = 0x00D0,

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

	/// <summary>Edit control Notification Codes</summary>
	[PInvokeData("WinUser.h")]
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