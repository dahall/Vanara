using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class User32
{
	private const int ECM_FIRST = 0x1500;
	private const int EN_FIRST = -1520;

	/// <summary>
	/// <para>
	/// An application-defined callback function used with the EM_SETWORDBREAKPROC message. A multiline edit control or a rich edit control
	/// calls an <c>EditWordBreakProc</c> function to break a line of text.
	/// </para>
	/// <para>
	/// The <c>EDITWORDBREAKPROC</c> type defines a pointer to this callback function. <c>EditWordBreakProc</c> is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="lpch">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>A pointer to the text of the edit control.</para>
	/// </param>
	/// <param name="ichCurrent">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// An index to a character position in the buffer of text that identifies the point at which the function should begin checking for a
	/// word break.
	/// </para>
	/// </param>
	/// <param name="cch">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The number of <c>TCHARs</c> in the edit control text. For the ANSI text, this is the number of bytes; for the Unicode text, this is
	/// the number of WCHARs.
	/// </para>
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
	/// <description>
	/// Retrieves the character class and word break flags of the character at the specified position. This value is for use with rich edit controls.
	/// </description>
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
	/// <description>
	/// Finds the beginning of a word to the left of the specified position. This value is used during CTRL+LEFT key processing. This value
	/// is for use with rich edit controls.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WB_MOVEWORDRIGHT</c></description>
	/// <description>
	/// Finds the beginning of a word to the right of the specified position. This value is used during CTRL+RIGHT key processing. This value
	/// is for use with rich edit controls.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WB_RIGHT</c></description>
	/// <description>Finds the beginning of a word to the right of the specified position. This is useful in right-aligned edit controls.</description>
	/// </item>
	/// <item>
	/// <description><c>WB_RIGHTBREAK</c></description>
	/// <description>
	/// Finds the end-of-word delimiter to the right of the specified position. This is useful in right-aligned edit controls. This value is
	/// for use with rich edit controls.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// If the <c>code</c> parameter specifies <c>WB_ISDELIMITER</c>, the return value is nonzero (TRUE) if the character at the specified
	/// position is a delimiter, or zero if it is not. If the <c>code</c> parameter specifies <c>WB_CLASSIFY</c>, the return value is the
	/// character class and word break flags of the character at the specified position. Otherwise, the return value is an index to the
	/// beginning of a word in the buffer of text.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A carriage return followed by a line feed must be treated as a single word by the callback function. Two carriage returns followed by
	/// a line feed also must be treated as a single word.
	/// </para>
	/// <para>
	/// An application must install the callback function by specifying the address of the callback function in an EM_SETWORDBREAKPROC message.
	/// </para>
	/// <para>
	/// <c>Rich Edit 1.0:</c> Microsoft Rich EditÂ 1.0 only passes back ANSI characters to <c>EditWordBreakProc</c>. For rich edit controls,
	/// you can alternately use the EM_SETWORDBREAKPROCEX message to replace the default extended word break procedure with an
	/// EditWordBreakProcEx callback function. This function provides additional information about the text, such as the character set.
	/// </para>
	/// <para>
	/// <c>Rich Edit 2.0 and later:</c> Microsoft Rich EditÂ 2.0 and later only pass back Unicode characters to <c>EditWordBreakProc</c>.
	/// Thus, an ANSI application would convert the Rich Edit-supplied Unicode string using WideCharToMultiByte, and then translate the
	/// indices appropriately.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winuser.h header defines EDITWORDBREAKPROC as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-editwordbreakproca EDITWORDBREAKPROCA Editwordbreakproca; int
	// Editwordbreakproca( [in] LPSTR lpch, [in] int ichCurrent, [in] int cch, [in] int code ) {...}
	[PInvokeData("winuser.h", MSDNShortId = "NC:winuser.EDITWORDBREAKPROCA")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false, CharSet = CharSet.Auto)]
	public delegate int EDITWORDBREAKPROC([MarshalAs(UnmanagedType.LPTStr)] string lpch, int ichCurrent, int cch, WB code);

	/// <summary>The margins to set.</summary>
	[PInvokeData("WinUser.h")]
	[Flags]
	public enum EC : ushort
	{
		/// <summary>Sets the left margin.</summary>
		EC_LEFTMARGIN = 0x0001,

		/// <summary>Sets the right margin.</summary>
		EC_RIGHTMARGIN = 0x0002,

		/// <summary>
		/// Rich edit controls: Sets the left and right margins to a narrow width calculated using the text metrics of the control's current
		/// font. If no font has been set for the control, the margins are set to zero. The lParam parameter is ignored.
		/// <para>Edit controls: The EC_USEFONTINFO value cannot be used in the wParam parameter. It can only be used in the lParam parameter.</para>
		/// </summary>
		EC_USEFONTINFO = 0xffff,
	}

	/// <summary>Indicates the end of line character used by an edit control.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ne-commctrl-ec_endofline typedef enum EC_ENDOFLINE {
	// EC_ENDOFLINE_DETECTFROMCONTENT = 0, EC_ENDOFLINE_CRLF = 1, EC_ENDOFLINE_CR = 2, EC_ENDOFLINE_LF = 3 } ;
	[PInvokeData("commctrl.h", MSDNShortId = "NE:commctrl.EC_ENDOFLINE")]
	public enum EC_ENDOFLINE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>End of line character specified in content.</para>
		/// </summary>
		EC_ENDOFLINE_DETECTFROMCONTENT = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>End of line character is CRLF.</para>
		/// </summary>
		EC_ENDOFLINE_CRLF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>End of line character is CR.</para>
		/// </summary>
		EC_ENDOFLINE_CR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>End of line character is LF.</para>
		/// </summary>
		EC_ENDOFLINE_LF,
	}

	/// <summary>Defines constants that indicate the entry point of a web search.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ne-commctrl-ec_searchweb_entrypoint typedef enum EC_SEARCHWEB_ENTRYPOINT
	// { EC_SEARCHWEB_ENTRYPOINT_EXTERNAL, EC_SEARCHWEB_ENTRYPOINT_CONTEXTMENU } ;
	[PInvokeData("commctrl.h", MSDNShortId = "NE:commctrl.EC_SEARCHWEB_ENTRYPOINT")]
	public enum EC_SEARCHWEB_ENTRYPOINT
	{
		/// <summary>Entry point is external.</summary>
		EC_SEARCHWEB_ENTRYPOINT_EXTERNAL = 0,

		/// <summary>Entry point is a context menu.</summary>
		EC_SEARCHWEB_ENTRYPOINT_CONTEXTMENU,
	}

	/// <summary>Window messages for the edit control.</summary>
	[PInvokeData("Winuser.h", MSDNShortId = "edit_control_constants")]
	public enum EditMessage
	{
		/// <summary>
		/// Gets the starting and ending character positions (in <c>TCHAR</c> s) of the current selection in an edit control. You can send
		/// this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A pointer to a <c>DWORD</c> value that receives the starting position of the selection. This parameter can be <c>NULL</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>DWORD</c> value that receives the position of the first unselected character after the end of the selection.
		/// This parameter can be <c>NULL</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is a zero-based value with the starting position of the selection in the <c>LOWORD</c> and the position of the
		/// first <c>TCHAR</c> after the last selected <c>TCHAR</c> in the <c>HIWORD</c>. If either of these values exceeds 65,535, the
		/// return value is -1.
		/// </para>
		/// <para>It is better to use the values returned in wParam and lParam because they are full 32-bit values.</para>
		/// <remarks>
		/// <para>If there is no selection, the starting and ending values are both the position of the caret.</para>
		/// <para>
		/// <c>Rich edit controls:</c> You can also use the <c>EM_EXGETSEL</c> message to retrieve the same information. <c>EM_EXGETSEL</c>
		/// also returns starting and ending character positions as 32-bit values.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getsel
		[MsgParams(typeof(uint?), typeof(uint?), LResultType = typeof(uint))]
		EM_GETSEL = 0x00B0,

		/// <summary>
		/// Selects a range of characters in an edit control. You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The starting character position of the selection.</para>
		/// <para><em>lParam</em></para>
		/// <para>The ending character position of the selection.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>
		/// The start value can be greater than the end value. The lower of the two values specifies the character position of the first
		/// character in the selection. The higher value specifies the position of the first character beyond the selection.
		/// </para>
		/// <para>
		/// The start value is the anchor point of the selection, and the end value is the active end. If the user uses the SHIFT key to
		/// adjust the size of the selection, the active end can move but the anchor point remains the same.
		/// </para>
		/// <para>
		/// If the start is 0 and the end is -1, all the text in the edit control is selected. If the start is -1, any current selection is deselected.
		/// </para>
		/// <para>
		/// <c>Edit controls:</c> The control displays a flashing caret at the end position regardless of the relative values of start and end.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// <para>
		/// If the edit control has the <c>ES_NOHIDESEL</c> style, the selected text is highlighted regardless of whether the control has
		/// focus. Without the <c>ES_NOHIDESEL</c> style, the selected text is highlighted only when the edit control has the focus.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setsel
		[MsgParams(typeof(int), typeof(int), LResultType = null)]
		EM_SETSEL = 0x00B1,

		/// <summary>
		/// Gets the formatting rectangle of an edit control. The formatting rectangle is the limiting rectangle into which the control draws
		/// the text. The limiting rectangle is independent of the size of the edit-control window. You can send this message to either an
		/// edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>RECT</c> structure that receives the formatting rectangle.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not meaningful.</para>
		/// <remarks>
		/// <para>
		/// You can modify the formatting rectangle of a multiline edit control by using the <c>EM_SETRECT</c> and <c>EM_SETRECTNP</c> messages.
		/// </para>
		/// <para>
		/// Under certain conditions, <c>EM_GETRECT</c> might not return the exact values that <c>EM_SETRECT</c> or <c>EM_SETRECTNP</c> set
		/// it will be approximately correct, but it can be off by a few pixels.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. The formatting rectangle does not include the selection bar,
		/// which is an unmarked area to the left of each paragraph. When clicked, the selection bar selects the line. For information about
		/// the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getrect
		[MsgParams(null, typeof(RECT?), LResultType = null)]
		EM_GETRECT = 0x00B2,

		/// <summary>
		/// <para>
		/// Sets the formatting rectangle of a multiline edit control. The formatting rectangle is the limiting rectangle into which the
		/// control draws the text. The limiting rectangle is independent of the size of the edit control window.
		/// </para>
		/// <para>
		/// This message is processed only by multiline edit controls. You can send this message to either an edit control or a rich edit control.
		/// </para>
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// <c>Rich Edit 2.0 and later:</c> Indicates whether lParam specifies absolute or relative coordinates. A value of zero indicates
		/// absolute coordinates. A value of 1 indicates offsets relative to the current formatting rectangle. (The offsets can be positive
		/// or negative.)
		/// </para>
		/// <para><c>Edit controls and Rich Edit 1.0:</c> This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>RECT</c> structure that specifies the new dimensions of the rectangle. If this parameter is <c>NULL</c>, the
		/// formatting rectangle is set to its default values.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>
		/// Setting lParam to <c>NULL</c> has no effect if a touch device is installed, or if <c>EM_SETRECT</c> is sent from a thread that
		/// has a hook installed (see <c>SetWindowsHookEx</c>). In these cases, lParam should contain a valid pointer to a <c>RECT</c> structure.
		/// </para>
		/// <para>
		/// The <c>EM_SETRECT</c> message causes the text of the edit control to be redrawn. To change the size of the formatting rectangle
		/// without redrawing the text, use the <c>EM_SETRECTNP</c> message.
		/// </para>
		/// <para>
		/// When an edit control is first created, the formatting rectangle is set to a default size. You can use the <c>EM_SETRECT</c>
		/// message to make the formatting rectangle larger or smaller than the edit control window.
		/// </para>
		/// <para>
		/// If the edit control does not have a horizontal scroll bar, and the formatting rectangle is set to be larger than the edit control
		/// window, lines of text exceeding the width of the edit control window (but smaller than the width of the formatting rectangle) are
		/// clipped instead of wrapped.
		/// </para>
		/// <para>
		/// If the edit control contains a border, the formatting rectangle is reduced by the size of the border. If you are adjusting the
		/// rectangle returned by an <c>EM_GETRECT</c> message, you must remove the size of the border before using the rectangle with the
		/// <c>EM_SETRECT</c> message.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. The formatting rectangle does not include the selection bar,
		/// which is an unmarked area to the left of each paragraph. When the user clicks in the selection bar, the corresponding line is
		/// selected. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setrect
		[MsgParams(typeof(BOOL), typeof(RECT?), LResultType = null)]
		EM_SETRECT = 0x00B3,

		/// <summary>
		/// <para>
		/// Sets the formatting rectangle of a multiline edit control. The <c>EM_SETRECTNP</c> message is identical to the <c>EM_SETRECT</c>
		/// message, except that <c>EM_SETRECTNP</c> does not redraw the edit control window.
		/// </para>
		/// <para>
		/// The formatting rectangle is the limiting rectangle into which the control draws the text. The limiting rectangle is independent
		/// of the size of the edit control window.
		/// </para>
		/// <para>
		/// This message is processed only by multiline edit controls. You can send this message to either an edit control or a rich edit control.
		/// </para>
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// <c>Rich Edit 3.0 and later:</c> Indicates whether the new rectangle contains absolute or relative coordinates. A value of zero
		/// indicates absolute coordinates. A value of 1 indicates offsets relative to the current formatting rectangle. (The offsets can be
		/// positive or negative.)
		/// </para>
		/// <para><c>Edit controls:</c> This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>RECT</c> structure that specifies the new dimensions of the rectangle. If this parameter is <c>NULL</c>, the
		/// formatting rectangle is set to its default values.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 3.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setrectnp
		[MsgParams(typeof(BOOL), typeof(RECT?), LResultType = null)]
		EM_SETRECTNP = 0x00B4,

		/// <summary>
		/// Scrolls the text vertically in a multiline edit control. This message is equivalent to sending a <c>WM_VSCROLL</c> message to the
		/// edit control. You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
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
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the message is successful, the <c>HIWORD</c> of the return value is <c>TRUE</c>, and the <c>LOWORD</c> is the number of lines
		/// that the command scrolls. The number returned may not be the same as the actual number of lines scrolled if the scrolling moves
		/// to the beginning or the end of the text. If the wParam parameter specifies an invalid value, the return value is <c>FALSE</c>.
		/// </para>
		/// <remarks>
		/// <para>
		/// To scroll to a specific line or character position, use the <c>EM_LINESCROLL</c> message. To scroll the caret into view, use the
		/// <c>EM_SCROLLCARET</c> message.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-scroll
		[MsgParams(typeof(SBCMD), null, LResultType = typeof(uint))]
		EM_SCROLL = 0x00B5,

		/// <summary>Scrolls the text in a multiline edit control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para><c>Edit controls:</c> The number of characters to scroll horizontally.</para>
		/// <para><c>Rich edit controls:</c> This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>The number of lines to scroll vertically.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message is sent to a multiline edit control, the return value is <c>TRUE</c>.</para>
		/// <para>If the message is sent to a single-line edit control, the return value is <c>FALSE</c>.</para>
		/// <remarks>
		/// <para>
		/// The control does not scroll vertically past the last line of text in the edit control. If the current line plus the number of
		/// lines specified by the lParam parameter exceeds the total number of lines in the edit control, the value is adjusted so that the
		/// last line of the edit control is scrolled to the top of the edit-control window.
		/// </para>
		/// <para>
		/// <c>Edit controls:</c> The <c>EM_LINESCROLL</c> message scrolls the text vertically or horizontally in a multiline edit control.
		/// The <c>EM_LINESCROLL</c> message can be used to scroll horizontally past the last character of any line.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. The <c>EM_LINESCROLL</c> message scrolls the text vertically in
		/// a multiline edit control. For information about the compatibility of rich edit versions with the various system versions, see
		/// About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-linescroll
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(BOOL))]
		EM_LINESCROLL = 0x00B6,

		/// <summary>
		/// Scrolls the caret into view in an edit control. You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is reserved. It should be set to zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is reserved. It should be set to zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not meaningful.</para>
		/// <remarks>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-scrollcaret
		[MsgParams(LResultType = null)]
		EM_SCROLLCARET = 0x00B7,

		/// <summary>
		/// Gets the state of an edit control's modification flag. The flag indicates whether the contents of the edit control have been
		/// modified. You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the contents of edit control have been modified, the return value is nonzero; otherwise, it is zero.</para>
		/// <remarks>
		/// <para>
		/// The system automatically clears the modification flag to zero when the control is created. If the user changes the control's
		/// text, the system sets the flag to nonzero. You can send the <c>EM_SETMODIFY</c> message to the edit control to set or clear the flag.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getmodify
		[MsgParams(LResultType = typeof(BOOL))]
		EM_GETMODIFY = 0x00B8,

		/// <summary>
		/// Sets or clears the modification flag for an edit control. The modification flag indicates whether the text within the edit
		/// control has been modified. You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The new value for the modification flag. A value of <c>TRUE</c> indicates the text has been modified, and a value of <c>FALSE</c>
		/// indicates it has not been modified.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>
		/// The system automatically clears the modification flag to zero when the control is created. If the user changes the control's
		/// text, the system sets the flag to nonzero. You can send the <c>EM_GETMODIFY</c> message to the edit control to retrieve the
		/// current state of the flag.
		/// </para>
		/// <para>
		/// <c>Rich Edit 1.0:</c> Objects created without the <c>REO_DYNAMICSIZE</c> flag will lock in their extents when the modify flag is
		/// set to <c>FALSE</c>.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setmodify
		[MsgParams(typeof(BOOL), null, LResultType = null)]
		EM_SETMODIFY = 0x00B9,

		/// <summary>
		/// Gets the number of lines in a multiline edit control. You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is an integer specifying the total number of text lines in the multiline edit control or rich edit control. If
		/// the control has no text, the return value is 1. The return value will never be less than 1.
		/// </para>
		/// <remarks>
		/// <para>
		/// The <c>EM_GETLINECOUNT</c> message retrieves the total number of text lines, not just the number of lines that are currently visible.
		/// </para>
		/// <para>If the Wordwrap feature is enabled, the number of lines can change when the dimensions of the editing window change.</para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getlinecount
		[MsgParams(LResultType = typeof(int))]
		EM_GETLINECOUNT = 0x00BA,

		/// <summary>
		/// Gets the character index of the first character of a specified line in a multiline edit control. A character index is the
		/// zero-based index of the character from the beginning of the edit control. You can send this message to either an edit control or
		/// a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based line number. A value of -1 specifies the current line number (the line that contains the caret).</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the character index of the line specified in the wParam parameter, or it is -1 if the specified line number
		/// is greater than the number of lines in the edit control.
		/// </para>
		/// <remarks>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-lineindex
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		EM_LINEINDEX = 0x00BB,

		/// <summary>Sets the handle of the memory that will be used by a multiline edit control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A handle to the memory buffer the edit control uses to store the currently displayed text instead of allocating its own memory.
		/// If necessary, the control reallocates this memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>
		/// Before an application sets a new memory handle, it should send an <c>EM_GETHANDLE</c> message to retrieve the handle of the
		/// current memory buffer and should free that memory.
		/// </para>
		/// <para>
		/// An edit control automatically reallocates the given buffer whenever it needs additional space for text, or it removes enough text
		/// so that additional space is no longer needed.
		/// </para>
		/// <para>
		/// Sending an <c>EM_SETHANDLE</c> message clears the undo buffer ( <c>EM_CANUNDO</c> returns zero) and the internal modification
		/// flag ( <c>EM_GETMODIFY</c> returns zero). The edit control window is redrawn.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> The <c>EM_SETHANDLE</c> message is not supported. Rich edit controls do not store text as a simple array of characters.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-sethandle
		[MsgParams(typeof(Kernel32.HLOCAL), null, LResultType = null)]
		EM_SETHANDLE = 0x00BC,

		/// <summary>Gets a handle of the memory currently allocated for a multiline edit control's text.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is a memory handle identifying the buffer that holds the content of the edit control. If an error occurs, such
		/// as sending the message to a single-line edit control, the return value is zero.
		/// </para>
		/// <remarks>
		/// <para>
		/// If the function succeeds, the application can access the contents of the edit control by casting the return value to
		/// <c>HLOCAL</c> and passing it to <c>LocalLock</c>. <c>LocalLock</c> returns a pointer to a buffer that is a null-terminated array
		/// of <c>CHAR</c> s or <c>WCHAR</c> s, depending on whether an ANSI or Unicode function created the control. For example, if
		/// <c>CreateWindowExA</c> was used the buffer is an array of <c>CHAR</c> s, but if <c>CreateWindowExW</c> was used the buffer is an
		/// array of <c>WCHAR</c> s. The application may not change the contents of the buffer. To unlock the buffer, the application calls
		/// <c>LocalUnlock</c> before allowing the edit control to receive new messages.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// For Comctl32.dll version 6, the buffer always contains an array of <c>WCHAR</c> s, regardless of whether an ANSI or Unicode
		/// function created the edit control. For more information on DLL versions, see Common Control Versions.
		/// </para>
		/// </para>
		/// <para>
		/// If your application cannot abide by the restrictions imposed by <c>EM_GETHANDLE</c>, use the <c>GetWindowTextLength</c> and
		/// <c>GetWindowText</c> functions to copy the contents of the edit control into an application-provided buffer.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> The <c>EM_GETHANDLE</c> message is not supported. Rich edit controls do not store text as a simple array of characters.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gethandle
		[MsgParams(LResultType = typeof(Kernel32.HLOCAL))]
		EM_GETHANDLE = 0x00BD,

		/// <summary>
		/// Gets the position of the scroll box (thumb) in the vertical scroll bar of a multiline edit control. You can send this message to
		/// either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the position of the scroll box.</para>
		/// <remarks>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 2.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getthumb
		[MsgParams(LResultType = typeof(int))]
		EM_GETTHUMB = 0x00BE,

		/// <summary>
		/// Retrieves the length, in characters, of a line in an edit control. You can send this message to either an edit control or a rich
		/// edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The character index of a character in the line whose length is to be retrieved. If this parameter is greater than the number of
		/// characters in the control, the return value is zero.
		/// </para>
		/// <para>
		/// This parameter can be -1. In this case, the message returns the number of unselected characters on lines containing selected
		/// characters. For example, if the selection extended from the fourth character of one line through the eighth character from the
		/// end of the next line, the return value would be 10 (three characters on the first line and seven on the next).
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// For multiline edit controls, the return value is the length, in <c>TCHAR</c> s, of the line specified by the wParam parameter.
		/// For ANSI text, this is the number of bytes; for Unicode text, this is the number of characters. It does not include the
		/// carriage-return character at the end of the line.
		/// </para>
		/// <para>For single-line edit controls, the return value is the length, in <c>TCHAR</c> s, of the text in the edit control.</para>
		/// <para>If wParam is greater than the number of characters in the control, the return value is zero.</para>
		/// <remarks>
		/// <para>Use the <c>EM_LINEINDEX</c> message to retrieve a character index for a given line number within a multiline edit control.</para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-linelength
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		EM_LINELENGTH = 0x00C1,

		/// <summary>Replaces the selected text in an edit control or a rich edit control with the specified text.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies whether the replacement operation can be undone. If this is <c>TRUE</c>, the operation can be undone. If this is
		/// <c>FALSE</c> , the operation cannot be undone.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a null-terminated string containing the replacement text.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>
		/// Use the <c>EM_REPLACESEL</c> message to replace only a portion of the text in an edit control. To replace all of the text, use
		/// the <c>WM_SETTEXT</c> message.
		/// </para>
		/// <para>If there is no selection, the replacement text is inserted at the caret.</para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// <para>
		/// In a rich edit control, the replacement text takes the formatting of the character at the caret or, if there is a selection, of
		/// the first character in the selection.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-replacesel
		[MsgParams(typeof(BOOL), typeof(string), LResultType = null)]
		EM_REPLACESEL = 0x00C2,

		/// <summary>
		/// Copies a line of text from an edit control and places it in a specified buffer. You can send this message to either an edit
		/// control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the line to retrieve from a multiline edit control. A value of zero specifies the topmost line. This
		/// parameter is ignored by a single-line edit control.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the buffer that receives a copy of the line. Before sending the message, set the first word of this buffer to the
		/// size, in <c>TCHAR</c> s, of the buffer. For ANSI text, this is the number of bytes; for Unicode text, this is the number of
		/// characters. The size in the first word is overwritten by the copied line.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the number of <c>TCHAR</c> s copied. The return value is zero if the line number specified by the wParam
		/// parameter is greater than the number of lines in the edit control.
		/// </para>
		/// <remarks>
		/// <para><c>Edit controls:</c> The copied line does not contain a terminating null character.</para>
		/// <para>
		/// <c>Rich edit controls:</c> Supported in Microsoft Rich Edit 1.0 and later. The copied line does not contain a terminating null
		/// character, unless no text was copied. If no text was copied, the message places a null character at the beginning of the buffer.
		/// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getline
		[MsgParams(typeof(int), typeof(StrPtrAuto), LResultType = typeof(int))]
		EM_GETLINE = 0x00C4,

		/// <summary>
		/// <para>
		/// Sets the text limit of an edit control. The text limit is the maximum amount of text, in <c>TCHAR</c> s, that the user can type
		/// into the edit control. You can send this message to either an edit control or a rich edit control.
		/// </para>
		/// <para>For edit controls and Microsoft Rich Edit 1.0, bytes are used. For Microsoft Rich Edit 2.0 and later, characters are used.</para>
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The maximum number of <c>TCHAR</c> s the user can enter. For ANSI text, this is the number of bytes; for Unicode text, this is
		/// the number of characters. This number does not include the terminating null character.
		/// </para>
		/// <para><c>Rich edit controls:</c> If this parameter is zero, the text length is set to 64,000 characters.</para>
		/// <para>
		/// If this parameter is zero, the text length is set to 0x7FFFFFFE characters for single-line edit controls or -1 for multiline edit controls.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>
		/// The <c>EM_LIMITTEXT</c> message limits only the text the user can enter. It does not affect any text already in the edit control
		/// when the message is sent, nor does it affect the length of the text copied to the edit control by the <c>WM_SETTEXT</c> message.
		/// If an application uses the <c>WM_SETTEXT</c> message to place more text into an edit control than is specified in the
		/// <c>EM_LIMITTEXT</c> message, the user can edit the entire contents of the edit control.
		/// </para>
		/// <para>
		/// Before <c>EM_LIMITTEXT</c> is called, the default limit for the amount of text a user can enter in an edit control is 32,767 characters.
		/// </para>
		/// <para>
		/// For single-line edit controls, the text limit is either 0x7FFFFFFE bytes or the value of the wParam parameter, whichever is
		/// smaller. For multiline edit controls, this value is either -1 byte or the value of the wParam parameter, whichever is smaller.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. Use the message <c>EM_EXLIMITTEXT</c> for text length values
		/// greater than 64,000. For information about the compatibility of rich edit versions with the various system versions, see About
		/// Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-limittext
		[MsgParams(typeof(int), null, LResultType = null)]
		EM_LIMITTEXT = 0x00C5,

		/// <summary>
		/// Determines whether there are any actions in an edit control's undo queue. You can send this message to either an edit control or
		/// a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If there are actions in the control's undo queue, the return value is nonzero.</para>
		/// <para>If the undo queue is empty, the return value is zero.</para>
		/// <remarks>
		/// <para>If the undo queue is not empty, you can send the <c>EM_UNDO</c> message to the control to undo the most recent operation.</para>
		/// <para><c>Edit controls and Rich Edit 1.0:</c> The undo queue contains only the most recent operation.</para>
		/// <para><c>Rich Edit 2.0 and later:</c> The undo queue can contain multiple operations.</para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-canundo
		[MsgParams(LResultType = typeof(BOOL))]
		EM_CANUNDO = 0x00C6,

		/// <summary>
		/// This message undoes the last edit control operation in the control's undo queue. You can send this message to either an edit
		/// control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>For a single-line edit control, the return value is always <c>TRUE</c>.</para>
		/// <para>
		/// For a multiline edit control, the return value is <c>TRUE</c> if the undo operation is successful, or <c>FALSE</c> if the undo
		/// operation fails.
		/// </para>
		/// <remarks>
		/// <para>
		/// <c>Edit controls and Rich Edit 1.0:</c> An undo operation can also be undone. For example, you can restore deleted text with the
		/// first <c>EM_UNDO</c> message, and remove the text again with a second <c>EM_UNDO</c> message as long as there is no intervening
		/// edit operation.
		/// </para>
		/// <para>
		/// <c>Rich Edit 2.0 and later:</c> The undo feature is multilevel so sending two <c>EM_UNDO</c> messages will undo the last two
		/// operations in the undo queue. To redo an operation, send the <c>EM_REDO</c> message.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-undo
		[MsgParams(LResultType = typeof(BOOL))]
		EM_UNDO = 0x00C7,

		/// <summary>
		/// Sets a flag that determines whether a multiline edit control includes soft line-break characters. A soft line break consists of
		/// two carriage returns and a line feed and is inserted at the end of a line that is broken because of wordwrapping.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies whether soft line-break characters are to be inserted. A value of <c>TRUE</c> inserts the characters; a value of
		/// <c>FALSE</c> removes them.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is identical to the wParam parameter.</para>
		/// <remarks>
		/// <para>
		/// This message affects only the buffer returned by the <c>EM_GETHANDLE</c> message and the text returned by the <c>WM_GETTEXT</c>
		/// message. It has no effect on the display of the text within the edit control.
		/// </para>
		/// <para>
		/// The <c>EM_FMTLINES</c> message does not affect a line that ends with a hard line break. A hard line break consists of one
		/// carriage return and a line feed.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>The size of the text changes when this message is processed.</para>
		/// </para>
		/// <para><c>Rich Edit:</c> The <c>EM_FMTLINES</c> message is not supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-fmtlines
		[MsgParams(typeof(BOOL), null, LResultType = typeof(BOOL))]
		EM_FMTLINES = 0x00C8,

		/// <summary>
		/// Gets the index of the line that contains the specified character index in a multiline edit control. A character index is the
		/// zero-based index of the character from the beginning of the edit control. You can send this message to either an edit control or
		/// a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The character index of the character contained in the line whose number is to be retrieved. If this parameter is -1,
		/// <c>EM_LINEFROMCHAR</c> retrieves either the line number of the current line (the line containing the caret) or, if there is a
		/// selection, the line number of the line containing the beginning of the selection.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the zero-based line number of the line containing the character index specified by wParam.</para>
		/// <remarks>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. If the character index is greater than 64,000, use the
		/// <c>EM_EXLINEFROMCHAR</c> message. For information about the compatibility of rich edit versions with the various system versions,
		/// see About Rich Edit Controls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-linefromchar
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		EM_LINEFROMCHAR = 0x00C9,

		/// <summary>
		/// <para>
		/// The <c>EM_SETTABSTOPS</c> message sets the tab stops in a multiline edit control. When text is copied to the control, any tab
		/// character in the text causes space to be generated up to the next tab stop.
		/// </para>
		/// <para>
		/// This message is processed only by multiline edit controls. You can send this message to either an edit control or a rich edit control.
		/// </para>
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The number of tab stops contained in the array. If this parameter is zero, the lParam parameter is ignored and default tab stops
		/// are set at every 32 dialog template units. If this parameter is 1, tab stops are set at every n dialog template units, where n is
		/// the distance pointed to by the lParam parameter. If this parameter is greater than 1, lParam is a pointer to an array of tab stops.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to an array of unsigned integers specifying the tab stops, in dialog template units. If the wParam parameter is 1, this
		/// parameter is a pointer to an unsigned integer containing the distance between all tab stops, in dialog template units.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If all the tabs are set, the return value is <c>TRUE</c>.</para>
		/// <para>If all the tabs are not set, the return value is <c>FALSE</c>.</para>
		/// <remarks>
		/// <para>
		/// The <c>EM_SETTABSTOPS</c> message does not automatically redraw the edit control window. If the application is changing the tab
		/// stops for text already in the edit control, it should call the <c>InvalidateRect</c> function to redraw the edit control window.
		/// </para>
		/// <para>
		/// The values specified in the array are in dialog template units, which are the device-independent units used in dialog box
		/// templates. To convert measurements from dialog template units to screen units (pixels), use the <c>MapDialogRect</c> function.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 3.0 and later. A rich edit control can have the maximum number of tab stops
		/// specified by MAX_TAB_STOPS. For information about the compatibility of rich edit versions with the various system versions, see
		/// About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-settabstops
		[MsgParams(typeof(uint), typeof(uint[]), LResultType = typeof(BOOL))]
		EM_SETTABSTOPS = 0x00CB,

		/// <summary>
		/// Sets or removes the password character for an edit control. When a password character is set, that character is displayed in
		/// place of the characters typed by the user. You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The character to be displayed in place of the characters typed by the user. If this parameter is zero, the control removes the
		/// current password character and displays the characters typed by the user.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>
		/// When an edit control receives the <c>EM_SETPASSWORDCHAR</c> message, the control redraws all visible characters using the
		/// character specified by the wParam parameter. If wParam is zero, the control redraws all visible characters using the characters
		/// typed by the user.
		/// </para>
		/// <para>
		/// If an edit control is created with the <c>ES_PASSWORD</c> style, the default password character is set to an asterisk (*). If an
		/// edit control is created without the <c>ES_PASSWORD</c> style, there is no password character. The <c>ES_PASSWORD</c> style is
		/// removed if an <c>EM_SETPASSWORDCHAR</c> message is sent with the wParam parameter set to zero.
		/// </para>
		/// <para><c>Edit controls:</c> Multiline edit controls do not support the password style or messages.</para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 2.0 and later. Both single-line and multiline edit controls support the
		/// password style and messages. For information about the compatibility of rich edit versions with the various system versions, see
		/// About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setpasswordchar
		[MsgParams(typeof(char), null, LResultType = null)]
		EM_SETPASSWORDCHAR = 0x00CC,

		/// <summary>
		/// Resets the undo flag of an edit control. The undo flag is set whenever an operation within the edit control can be undone. You
		/// can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>The undo flag is automatically reset whenever the edit control receives a <c>WM_SETTEXT</c> or <c>EM_SETHANDLE</c> message.</para>
		/// <para><c>Edit controls and Rich Edit 1.0:</c> The control can only undo or redo the most recent operation.</para>
		/// <para>
		/// <c>Rich Edit 2.0 and later:</c> The <c>EM_EMPTYUNDOBUFFER</c> message empties all undo and redo buffers. Rich edit controls
		/// enable the user to undo or redo multiple operations.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-emptyundobuffer
		[MsgParams(LResultType = null)]
		EM_EMPTYUNDOBUFFER = 0x00CD,

		/// <summary>
		/// Gets the zero-based index of the uppermost visible line in a multiline edit control. You can send this message to either an edit
		/// control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the zero-based index of the uppermost visible line in a multiline edit control.</para>
		/// <para><c>Edit controls:</c> For single-line edit controls, the return value is the zero-based index of the first visible character.</para>
		/// <para><c>Rich edit controls:</c> For single-line rich edit controls, the return value is zero.</para>
		/// <remarks>
		/// <para>
		/// The number of lines and the length of the lines in an edit control depend on the width of the control and the current Wordwrap setting.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getfirstvisibleline
		[MsgParams(LResultType = typeof(int))]
		EM_GETFIRSTVISIBLELINE = 0x00CE,

		/// <summary>
		/// Sets or removes the read-only style ( <c>ES_READONLY</c>) of an edit control. You can send this message to either an edit control
		/// or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies whether to set or remove the <c>ES_READONLY</c> style. A value of <c>TRUE</c> sets the <c>ES_READONLY</c> style; a
		/// value of <c>FALSE</c> removes the <c>ES_READONLY</c> style.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is nonzero.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// <remarks>
		/// <para>When an edit control has the <c>ES_READONLY</c> style, the user cannot change the text within the edit control.</para>
		/// <para>
		/// To determine whether an edit control has the <c>ES_READONLY</c> style, use the <c>GetWindowLong</c> function with the GWL_STYLE flag.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setreadonly
		[MsgParams(typeof(BOOL), null, LResultType = typeof(BOOL))]
		EM_SETREADONLY = 0x00CF,

		/// <summary>
		/// Replaces an edit control's default Wordwrap function with an application-defined Wordwrap function. You can send this message to
		/// either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The address of the application-defined Wordwrap function. For more information about breaking lines, see the description of the
		/// EditWordBreakProc callback function.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>
		/// A Wordwrap function scans a text buffer that contains text to be sent to the screen, looking for the first word that does not fit
		/// on the current screen line. The Wordwrap function places this word at the beginning of the next line on the screen.
		/// </para>
		/// <para>
		/// A Wordwrap function defines the point at which the system should break a line of text for multiline edit controls, usually at a
		/// space character that separates two words. Either a multiline or a single-line edit control might call this function when the user
		/// presses arrow keys in combination with the CTRL key to move the caret to the next word or previous word. The default Wordwrap
		/// function breaks a line of text at a space character. The application-defined function may define the Wordwrap to occur at a
		/// hyphen or a character other than the space character.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setwordbreakproc
		[MsgParams(null, typeof(EDITWORDBREAKPROC), LResultType = null)]
		EM_SETWORDBREAKPROC = 0x00D0,

		/// <summary>
		/// Gets the address of the current Wordwrap function. You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value specifies the address of the application-defined Wordwrap function. The return value is <c>NULL</c> if no
		/// Wordwrap function exists.
		/// </para>
		/// <remarks>
		/// <para>
		/// A Wordwrap function scans a text buffer that contains text to be sent to the display, looking for the first word that does not
		/// fit on the current display line. The wordwrap function places this word at the beginning of the next line on the display. A
		/// Wordwrap function defines the point at which the system should break a line of text for multiline edit controls, usually at a
		/// space character that separates two words.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getwordbreakproc
		[MsgParams(LResultType = typeof(EDITWORDBREAKPROC))]
		EM_GETWORDBREAKPROC = 0x00D1,

		/// <summary>
		/// Gets the password character that an edit control displays when the user enters text. You can send this message to either an edit
		/// control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value specifies the character to be displayed in place of any characters typed by the user. If the return value is
		/// <c>NULL</c>, there is no password character, and the control displays the characters typed by the user.
		/// </para>
		/// <remarks>
		/// <para>
		/// If an edit control is created with the <c>ES_PASSWORD</c> style, the default password character is set to an asterisk (*). If an
		/// edit control is created without the <c>ES_PASSWORD</c> style, there is no password character. To change the password character,
		/// send the <c>EM_SETPASSWORDCHAR</c> message.
		/// </para>
		/// <para><c>Edit controls:</c> Multiline edit controls do not support the password style or messages.</para>
		/// <para>
		/// <c>Rich edit:</c> Supported in Microsoft Rich Edit 2.0 and later. Both single-line and multiline edit controls support the
		/// password style and messages. For information about the compatibility of rich edit versions with the various system versions, see
		/// About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getpasswordchar
		[MsgParams(LResultType = typeof(char))]
		EM_GETPASSWORDCHAR = 0x00D2,

		/// <summary>
		/// Sets the widths of the left and right margins for an edit control. The message redraws the control to reflect the new margins.
		/// You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The margins to set. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>EC_LEFTMARGIN</c></description>
		/// <description>Sets the left margin.</description>
		/// </item>
		/// <item>
		/// <description><c>EC_RIGHTMARGIN</c></description>
		/// <description>Sets the right margin.</description>
		/// </item>
		/// <item>
		/// <description><c>EC_USEFONTINFO</c></description>
		/// <description>
		/// <c>Rich edit controls:</c> Sets the left and right margins to a narrow width calculated using the text metrics of the control's
		/// current font. If no font has been set for the control, the margins are set to zero. The <c>lParam</c> parameter is ignored.
		/// <c>Edit controls:</c> The <c>EC_USEFONTINFO</c> value cannot be used in the <c>wParam</c> parameter. It can only be used in the
		/// <c>lParam</c> parameter.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the new width of the left margin, in pixels. This value is ignored if wParam does not include <c>EC_LEFTMARGIN</c>.
		/// </para>
		/// <para>
		/// <c>Edit controls and Rich Edit 3.0 and later:</c> The <c>LOWORD</c> can specify the <c>EC_USEFONTINFO</c> value to set the left
		/// margin to a narrow width calculated using the text metrics of the control's current font. If no font has been set for the
		/// control, the margin is set to zero.
		/// </para>
		/// <para>
		/// The <c>HIWORD</c> specifies the new width of the right margin, in pixels. This value is ignored if wParam does not include <c>EC_RIGHTMARGIN</c>.
		/// </para>
		/// <para>
		/// <c>Edit controls and Rich Edit 3.0 and later:</c> The <c>HIWORD</c> can specify the <c>EC_USEFONTINFO</c> value to set the right
		/// margin to a narrow width calculated using the text metrics of the control's current font. If no font has been set for the
		/// control, the margin is set to zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para><c>Edit controls:</c> You cannot use <c>EC_USEFONTINFO</c> in the wParam parameter, but you can use it in the lParam parameter.</para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. All rich edit versions support the use of <c>EC_USEFONTINFO</c>
		/// in the wParam parameter. However, only Microsoft Rich Edit 3.0 and later support the use of <c>EC_USEFONTINFO</c> in the lParam
		/// parameter. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setmargins
		[MsgParams(typeof(EC), typeof(uint), LResultType = null)]
		EM_SETMARGINS = 0x00D3,

		/// <summary>Gets the widths of the left and right margins for an edit control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the width of the left margin in the LOWORD, and the width of the right margin in the HIWORD.</para>
		/// <remarks><c>Rich Edit:</c> The <c>EM_GETMARGINS</c> message is not supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getmargins
		[MsgParams(LResultType = typeof(uint))]
		EM_GETMARGINS = 0x00D4,

		/// <summary>
		/// <para>
		/// Sets the text limit of an edit control. The text limit is the maximum amount of text, in <c>TCHAR</c> s, that the user can type
		/// into the edit control. You can send this message to either an edit control or a rich edit control.
		/// </para>
		/// <para>For edit controls and Microsoft Rich Edit 1.0, bytes are used. For Microsoft Rich Edit 2.0 and later, characters are used.</para>
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The maximum number of <c>TCHAR</c> s the user can enter. For ANSI text, this is the number of bytes; for Unicode text, this is
		/// the number of characters. This number does not include the terminating null character.
		/// </para>
		/// <para><c>Rich edit controls:</c> If this parameter is zero, the text length is set to 64,000 characters.</para>
		/// <para>
		/// If this parameter is zero, the text length is set to 0x7FFFFFFE characters for single-line edit controls or -1 for multiline edit controls.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// <para>
		/// The <c>EM_LIMITTEXT</c> message limits only the text the user can enter. It does not affect any text already in the edit control
		/// when the message is sent, nor does it affect the length of the text copied to the edit control by the <c>WM_SETTEXT</c> message.
		/// If an application uses the <c>WM_SETTEXT</c> message to place more text into an edit control than is specified in the
		/// <c>EM_LIMITTEXT</c> message, the user can edit the entire contents of the edit control.
		/// </para>
		/// <para>
		/// Before <c>EM_LIMITTEXT</c> is called, the default limit for the amount of text a user can enter in an edit control is 32,767 characters.
		/// </para>
		/// <para>
		/// For single-line edit controls, the text limit is either 0x7FFFFFFE bytes or the value of the wParam parameter, whichever is
		/// smaller. For multiline edit controls, this value is either -1 byte or the value of the wParam parameter, whichever is smaller.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. Use the message <c>EM_EXLIMITTEXT</c> for text length values
		/// greater than 64,000. For information about the compatibility of rich edit versions with the various system versions, see About
		/// Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-limittext
		[MsgParams(typeof(int), null, LResultType = null)]
		EM_SETLIMITTEXT = EM_LIMITTEXT,   /* ;win40 Name change */

		/// <summary>
		/// Gets the current text limit for an edit control. You can send this message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the text limit.</para>
		/// <remarks>
		/// <para>
		/// <c>Edit controls, Rich Edit 2.0 and later:</c> The text limit is the maximum amount of text, in <c>TCHAR</c> s, that the control
		/// can contain. For ANSI text, this is the number of bytes; for Unicode text, this is the number of characters. Two documents with
		/// the same character limit will yield the same text limit, even if one is ANSI and the other is Unicode.
		/// </para>
		/// <para><c>Rich Edit 1.0:</c> The text limit is the maximum amount of text, in bytes, that the rich edit control can contain.</para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getlimittext
		[MsgParams(LResultType = typeof(int))]
		EM_GETLIMITTEXT = 0x00D5,

		/// <summary>
		/// Retrieves the client area coordinates of a specified character in an edit control. You can send this message to either an edit
		/// control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// <c>Rich Edit 1.0 and 3.0:</c> A pointer to a <c>POINTL</c> structure that receives the client area coordinates of the character.
		/// The coordinates are in screen units and are relative to the upper-left corner of the control's client area.
		/// </para>
		/// <para><c>Edit controls and Rich Edit 2.0:</c> The zero-based index of the character.</para>
		/// <para><em>lParam</em></para>
		/// <para><c>Rich Edit 1.0 and 3.0:</c> The zero-based index of the character.</para>
		/// <para><c>Edit controls and Rich Edit 2.0:</c> This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para><c>Rich Edit 1.0 and 3.0:</c> The return value is not used.</para>
		/// <para>
		/// <c>Edit controls and Rich Edit 2.0:</c> The return value contains the client area coordinates of the character. The <c>LOWORD</c>
		/// contains the horizontal coordinate and the <c>HIWORD</c> contains the vertical coordinate.
		/// </para>
		/// <remarks>
		/// <para>
		/// A returned coordinate can be a negative value if the specified character is not displayed in the edit control's client area. The
		/// coordinates are truncated to integer values.
		/// </para>
		/// <para>
		/// If the character is a line delimiter, the returned coordinates indicate a point just beyond the last visible character in the
		/// line. If the specified index is greater than the index of the last character in the control, the control returns -1.
		/// </para>
		/// <para>
		/// <c>Rich Edit 3.0 and later:</c> For backward compatibility, Microsoft Rich Edit 3.0 supports the syntax used by Microsoft Rich
		/// Edit 2.0. If Microsoft Rich Edit 3.0 detects that wParam is not a valid <c>POINTL</c> pointer, it assumes the message was sent
		/// using the Microsoft Rich Edit 2.0 syntax. In this case, it uses the return value to return the coordinates.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-posfromchar
		[MsgParams(typeof(IntPtr), typeof(uint), LResultType = typeof(uint))]
		EM_POSFROMCHAR = 0x00D6,

		/// <summary>
		/// Gets information about the character closest to a specified point in the client area of an edit control. You can send this
		/// message to either an edit control or a rich edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The coordinates of a point in the control's client area. The coordinates are in screen units and are relative to the upper-left
		/// corner of the control's client area.
		/// </para>
		/// <para><c>Rich edit controls:</c> A pointer to a <c>POINTL</c> structure that contains the horizontal and vertical coordinates.</para>
		/// <para><c>Edit controls:</c> The <c>LOWORD</c> contains the horizontal coordinate. The <c>HIWORD</c> contains the vertical coordinate.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// <c>Rich edit controls:</c> The return value specifies the zero-based character index of the character nearest the specified
		/// point. The return value indicates the last character in the edit control if the specified point is beyond the last character in
		/// the control.
		/// </para>
		/// <para>
		/// <c>Edit controls:</c> The <c>LOWORD</c> specifies the zero-based index of the character nearest the specified point. This index
		/// is relative to the beginning of the control, not the beginning of the line. If the specified point is beyond the last character
		/// in the edit control, the return value indicates the last character in the control. The <c>HIWORD</c> specifies the zero-based
		/// index of the line that contains the character. For single-line edit controls, this value is zero. The index indicates the line
		/// delimiter if the specified point is beyond the last visible character in a line.
		/// </para>
		/// <remarks>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// <para>
		/// If a point is passed to <c>EM_CHARFROMPOS</c> as the lParam and the point is outside the bounds of the edit control, then the
		/// lResult is (65535, 65535).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-charfrompos
		[MsgParams(null, typeof(IntPtr), LResultType = typeof(uint))]
		EM_CHARFROMPOS = 0x00D7,

		/// <summary>Sets the status flags that determine how an edit control interacts with the Input Method Editor (IME).</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The type of status to set. This parameter can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>EMSIS_COMPOSITIONSTRING</c></description>
		/// <description>Sets behavior for the handling composition string.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Data specific to the status type. If wParam is <c>EMSIS_COMPOSITIONSTRING</c>, this parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>EIMES_GETCOMPSTRATONCE</c></description>
		/// <description>
		/// If this flag is set, the edit control hooks the <c>WM_IME_COMPOSITION</c> message with <c>lParam</c> set to GCS_RESULTSTR and
		/// returns the result string immediately. If this flag is not set, the edit control passes the <c>WM_IME_COMPOSITION</c> message to
		/// the default window procedure and handles the result string from the <c>WM_CHAR</c> message; this is the default behavior of the
		/// edit control.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>EIMES_CANCELCOMPSTRINFOCUS</c></description>
		/// <description>
		/// If this flag is set, the edit control cancels the composition string when it receives the <c>WM_SETFOCUS</c> message. If this
		/// flag is not set, the edit control does not cancel the composition string; this is the default behavior of the edit control.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>EIMES_COMPLETECOMPSTRKILLFOCUS</c></description>
		/// <description>
		/// If this flag is set, the edit control completes the composition string upon receiving the <c>WM_KILLFOCUS</c> message. If this
		/// flag is not set, the edit control does not complete the composition string; this is the default behavior of the edit control.
		/// </description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous value of the lParam parameter.</para>
		/// <remarks><c>Rich Edit:</c> The <c>EM_SETIMESTATUS</c> message is not supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setimestatus
		[MsgParams(typeof(EMSIS), typeof(EIMES), LResultType = typeof(EIMES))]
		EM_SETIMESTATUS = 0x00D8,

		/// <summary>Gets a set of status flags that indicate how the edit control interacts with the Input Method Editor (IME).</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The type of status to retrieve. This parameter can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>EMSIS_COMPOSITIONSTRING</c></description>
		/// <description>Sets behavior for handling the composition string.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Data specific to the type of status to retrieve. With the <c>EMSIS_COMPOSITIONSTRING</c> value for status, this return value is
		/// one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>EIMES_GETCOMPSTRATONCE</c></description>
		/// <description>
		/// If this flag is set, the edit control hooks the <c>WM_IME_COMPOSITION</c> message with <c>fFlags</c> set to GCS_RESULTSTR and
		/// returns the result string immediately. If this flag is not set, the edit control passes the <c>WM_IME_COMPOSITION</c> message to
		/// the default window procedure and processes the result string from the <c>WM_CHAR</c> message; this is the default behavior of the
		/// edit control.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>EIMES_CANCELCOMPSTRINFOCUS</c></description>
		/// <description>
		/// If this flag is set, the edit control cancels the composition string when it receives the <c>WM_SETFOCUS</c> message. If this
		/// flag is not set, the edit control does not cancel the composition string; this is the default behavior of the edit control.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>EIMES_COMPLETECOMPSTRKILLFOCUS</c></description>
		/// <description>
		/// If this flag is set, the edit control completes the composition string upon receiving the <c>WM_KILLFOCUS</c> message. If this
		/// flag is not set, the edit control does not complete the composition string; this is the default behavior of the edit control.
		/// </description>
		/// </item>
		/// </list>
		/// <remarks><c>Rich Edit:</c> The <c>EM_GETIMESTATUS</c> message is not supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getimestatus
		[MsgParams(typeof(EMSIS), null, LResultType = typeof(EIMES))]
		EM_GETIMESTATUS = 0x00D9,

		/// <summary>Undocumented</summary>
		EM_ENABLEFEATURE = 0x00DA,

		/// <summary>Sets the textual cue, or tip, that is displayed by the edit control to prompt the user for information.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// <c>TRUE</c> if the cue banner should show even when the edit control has focus; otherwise, <c>FALSE</c>. <c>FALSE</c> is the
		/// default behavior the cue banner disappears when the user clicks in the control.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a Unicode string that contains the text to display as the textual cue.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, it returns <c>TRUE</c>. Otherwise it returns <c>FALSE</c>.</para>
		/// <remarks>
		/// <para>
		/// An edit control that is used to begin a search may display "Enter search here" in gray text as a textual cue. When the user
		/// clicks the text, the text goes away and the user can type.
		/// </para>
		/// <para>You cannot set a cue banner on a multiline edit control or on a rich edit control.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this API, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see Enabling
		/// Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setcuebanner
		[MsgParams(typeof(BOOL), typeof(StrPtrUni), LResultType = typeof(BOOL))]
		EM_SETCUEBANNER = ECM_FIRST + 1,     // Set the cue banner with the lParm = LPCWSTR

		/// <summary>Gets the text that is displayed as the textual cue, or tip, in an edit control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A pointer to a Unicode buffer that receives the text set as the textual cue. The caller is responsible for allocating the buffer.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>The size of the buffer pointed to by wParam in <c>WCHARs</c>, including the terminating <c>NULL</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</para>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getcuebanner
		[MsgParams(typeof(StrPtrUni), typeof(uint), LResultType = typeof(BOOL))]
		EM_GETCUEBANNER = ECM_FIRST + 2,     // Set the cue banner with the lParm = LPCWSTR

		/// <summary>The <c>EM_SHOWBALLOONTIP</c> message displays a balloon tip associated with an edit control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to an <c>EDITBALLOONTIP</c> structure that contains information about the balloon tip to display.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, it returns <c>TRUE</c>. Otherwise it returns <c>FALSE</c>.</para>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-showballoontip
		[MsgParams(null, typeof(EDITBALLOONTIP?), LResultType = typeof(BOOL))]
		EM_SHOWBALLOONTIP = ECM_FIRST + 3,     // Show a balloon tip associated to the edit control

		/// <summary>Hides any balloon tip associated with an edit control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, it returns <c>TRUE</c>. Otherwise it returns <c>FALSE</c>.</para>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/em-hideballoontip
		[MsgParams(LResultType = typeof(BOOL))]
		EM_HIDEBALLOONTIP = ECM_FIRST + 4,     // Hide any balloon tip associated with the edit control

		//EM_SETHILITE           = ECM_FIRST + 5,
		//EM_GETHILITE           = ECM_FIRST + 6,

		/// <summary>
		/// <para>
		/// [Intended for internal use; not recommended for use in applications. This message may not be supported in future versions of Windows.]
		/// </para>
		/// <para>
		/// Prevents a single-line edit control from receiving keyboard focus. You can send this message explicitly or by using the
		/// <c>Edit_NoSetFocus</c> macro.
		/// </para>
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// <remarks>
		/// <para>This message is ignored if the edit control is not a single-line edit control.</para>
		/// <para>After this message is sent, the effect is permanent.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-nosetfocus
		[MsgParams(LResultType = null)]
		EM_NOSETFOCUS = ECM_FIRST + 7,

		/// <summary>
		/// <para>
		/// [Intended for internal use; not recommended for use in applications. This message may not be supported in future versions of Windows.]
		/// </para>
		/// <para>
		/// Forces a single-line edit control to receive keyboard focus. You can send this message explicitly or by using the
		/// <c>Edit_TakeFocus</c> macro.
		/// </para>
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// <remarks>
		/// <para>This message is ignored if the edit control is not a single-line edit control.</para>
		/// <para>
		/// If the edit control previously received an <c>EM_NOSETFOCUS</c> message, the edit control will appear to have the focus without
		/// actually having it; otherwise, the edit control will receive focus.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-takefocus
		[MsgParams(LResultType = null)]
		EM_TAKEFOCUS = ECM_FIRST + 8,

		/// <summary>Informs the edit control to set extended styles. Send this message or use the macro <c>Edit_SetExtendedStyle</c>.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Mask used to select the styles to be set.</para>
		/// <para><em>lParam</em></para>
		/// <para>Value that indicates the extended style. For more information on styles, see Edit Control Extended Styles.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If this message succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// <remarks>
		/// The extended styles for an edit control have nothing to do with the extended styles used with function <c>CreateWindowEx</c> or
		/// function <c>SetWindowLong</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setextendedstyle
		[MsgParams(typeof(EditStylesEx), typeof(EditStylesEx), LResultType = typeof(HRESULT))]
		EM_SETEXTENDEDSTYLE = ECM_FIRST + 10,

		/// <summary>
		/// Retrieves the extended style for a tree-view control. Send this message explicitly or by using the <c>Edit_GetExtendedStyle</c> macro.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the value of extended style.For more information on styles, see Edit Control Extended Styles.</para>
		/// <remarks>
		/// The extended styles for an edit control have nothing to do with the extended styles used with function <c>CreateWindowEx</c> or
		/// function <c>SetWindowLong</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getextendedstyle
		[MsgParams(LResultType = typeof(EditStylesEx))]
		EM_GETEXTENDEDSTYLE = ECM_FIRST + 11,

		/// <summary>Sets the end-of-line character used when a linebreak is inserted.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the end-of-line character used when a linebreak is inserted. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>EC_ENDOFLINE_DETECTFROMCONTENT</c></description>
		/// <description>Sets the end-of-line character used for new linebreaks to the character used by the current document.</description>
		/// </item>
		/// <item>
		/// <description><c>EC_ENDOFLINE_CRLF</c></description>
		/// <description>Sets the end-of-line character used for new linebreaks to carriage return followed by linefeed (CRLF).</description>
		/// </item>
		/// <item>
		/// <description><c>EC_ENDOFLINE_CR</c></description>
		/// <description>Sets the end-of-line character used for new linebreaks to carriage return (CR).</description>
		/// </item>
		/// <item>
		/// <description><c>EC_ENDOFLINE_LF</c></description>
		/// <description>Sets the end-of-line character used for new linebreaks to linefeed (LF).</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is nonzero.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// <remarks>
		/// When the end-of-line character set is <c>EC_ENDOFLINE_DETECTFROMCONTENT</c>, the edit control will only detect end-of-line
		/// characters supported according to its extended window style, see Edit Control Extended Styles.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setendofline
		[MsgParams(typeof(EC_ENDOFLINE), null)]
		EM_SETENDOFLINE = ECM_FIRST + 12,

		/// <summary>
		/// Retrieves the end-of-line character for an edit control. Send this message explicitly or by using the <c>Edit_GetEndOfLine</c> macro.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the end-of-line character used by the edit control. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>EC_ENDOFLINE_CRLF</c></description>
		/// <description>The end-of-line character used for new linebreaks is carriage return followed by linefeed (CRLF).</description>
		/// </item>
		/// <item>
		/// <description><c>EC_ENDOFLINE_CR</c></description>
		/// <description>The end-of-line character used for new linebreaks is carriage return (CR).</description>
		/// </item>
		/// <item>
		/// <description><c>EC_ENDOFLINE_LF</c></description>
		/// <description>The end-of-line character used for new linebreaks is linefeed (LF).</description>
		/// </item>
		/// </list>
		/// <remarks>
		/// When the end-of-line character used is set to <c>EC_ENDOFLINE_DETECTFROMCONTENT</c> using <c>Edit_SetEndOfLine</c>, this message
		/// will return the detected end-of-line character.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getendofline
		[MsgParams(LResultType = typeof(EC_ENDOFLINE))]
		EM_GETENDOFLINE = ECM_FIRST + 13,

		/// <summary>Enables or disables the "Search the web" feature and context menu entry.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A value of <c>TRUE</c> indicates the "Search the web" feature is enabled, and a value of <c>FALSE</c> indicates it is disabled.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>If you disable "Search the web" using this message, the <c>EM_SEARCHWEB</c> message has no effect.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/em-enablesearchweb
		[MsgParams(typeof(BOOL), null, LResultType = null)]
		EM_ENABLESEARCHWEB = ECM_FIRST + 14,

		/// <summary>Opens the browser and performs a web search with the selected text as the search term.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>If the "Search the web" feature is disabled using the <c>EM_ENABLESEARCHWEB</c> message, this message has no effect.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-searchweb
		[MsgParams(LResultType = null)]
		EM_SEARCHWEB = ECM_FIRST + 15,

		/// <summary>Sets the zero-based index value of the position of the caret in an edit control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The new zero-based index value of the position of the caret.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// <remarks>
		/// If the index is out of the range of the text in an edit control, the index will be adjusted to fit inside the range of the text.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setcaretindex
		[MsgParams(typeof(uint), null, LResultType = null)]
		EM_SETCARETINDEX = ECM_FIRST + 17,

		/// <summary>Gets the zero-based index of the position of the caret in an edit control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is a zero-based index value of the position of the caret.</para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getcaretindex
		[MsgParams(LResultType = typeof(uint))]
		EM_GETCARETINDEX = ECM_FIRST + 18,

		/// <summary>
		/// Gets the current zoom ratio for a multiline edit control or a rich edit control. The zoom ration is always between 1/64 and 64.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Receives the numerator of the zoom ratio.</para>
		/// <para><em>lParam</em></para>
		/// <para>Receives the denominator of the zoom ratio.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The message returns <c>TRUE</c> if message is processed, which it will be if both wParam and lParam are not <c>NULL</c>.</para>
		/// <remarks>
		/// <c>Edit:</c> Supported in Windows 10 1809 and later. The edit control needs to have the <c>ES_EX_ZOOMABLE</c> extended style set,
		/// for this message to have an effect, see Edit Control Extended Styles. For information about the edit control, see Edit Controls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getzoom
		[MsgParams(typeof(uint), typeof(uint), LResultType = typeof(BOOL))]
		EM_GETZOOM = (int)WM_USER + 224,

		/// <summary>
		/// Sets the zoom ratio for a multiline edit control or a rich edit control. The ratio must be a value between 1/64 and 64. The edit
		/// control needs to have the <c>ES_EX_ZOOMABLE</c> extended style set, for this message to have an effect, see Edit Control Extended Styles.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Numerator of the zoom ratio.</para>
		/// <para><em>lParam</em></para>
		/// <para>Denominator of the zoom ratio. These parameters can have the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>Both 0</c></description>
		/// <description>Turns off zooming by using the <c>EM_SETZOOM</c> message (zooming may still occur using <c>TxGetExtent</c>).</description>
		/// </item>
		/// <item>
		/// <description><c>1/64 &lt; (wParam / lParam) &lt; 64</c></description>
		/// <description>Zooms display by the zoom ratio numerator/denominator</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If the new zoom setting is accepted, the return value is <c>TRUE</c>.</para>
		/// <para>If the new zoom setting is not accepted, the return value is <c>FALSE</c>.</para>
		/// <remarks>
		/// <c>Edit:</c> Supported in Windows 10 1809 and later. The edit control needs to have the <c>ES_EX_ZOOMABLE</c> extended style set,
		/// for this message to have an effect, see Edit Control Extended Styles. For information about the edit control, see Edit Controls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setzoom
		[MsgParams(typeof(uint), typeof(uint), LResultType = typeof(BOOL))]
		EM_SETZOOM = (int)WM_USER + 225,

		/// <summary>
		/// Gets the index of the line that contains the specified character index in a multiline edit control, independently of how lines
		/// are displayed on the screen. A character index is the zero-based index of the character from the beginning of the edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The character index of the character contained in the line whose number is to be retrieved. If this parameter is -1,
		/// <c>EM_FILELINEFROMCHAR</c> retrieves either the line number of the current line (the line containing the caret) or, if there is a
		/// selection, the line number of the line containing the beginning of the selection.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the zero-based line number of the line containing the character index specified by wParam, independently of
		/// how lines are displayed on the screen.
		/// </para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-filelinefromchar
		[MsgParams(typeof(int), null, LResultType = typeof(uint))]
		EM_FILELINEFROMCHAR = ECM_FIRST + 19,

		/// <summary>
		/// Gets the character index of the first character of a specified line in a multiline edit control, independently of how lines are
		/// displayed on the screen.. A character index is the zero-based index of the character from the beginning of the edit control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based line number. A value of -1 specifies the current line number (the line that contains the caret).</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the character index of the line specified in the wParam parameter, independently of how lines are displayed
		/// on the screen, or it is -1 if the specified line number is greater than the number of lines in the edit control.
		/// </para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-filelineindex
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		EM_FILELINEINDEX = ECM_FIRST + 20,

		/// <summary>
		/// Retrieves the length, in characters, of a line in an edit control, independently of how lines are displayed on the screen.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The character index of a character in the line whose length is to be retrieved. If this parameter is greater than the number of
		/// characters in the control, the return value is zero.
		/// </para>
		/// <para>
		/// This parameter can be -1. In this case, the message returns the number of unselected characters on lines containing selected
		/// characters. For example, if the selection extended from the fourth character of one line through the eighth character from the
		/// end of the next line, the return value would be 10 (three characters on the first line and seven on the next).
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// For multiline edit controls, the return value is the length, in <c>TCHAR</c> s, of the line specified by the wParam parameter,
		/// independently of how lines are displayed on the screen. It does not include the carriage-return or linefeed character at the end
		/// of the line.
		/// </para>
		/// <para>For single-line edit controls, the return value is the length, in <c>TCHAR</c> s, of the text in the edit control.</para>
		/// <para>If wParam is greater than the number of characters in the control, the return value is zero.</para>
		/// <remarks>
		/// Use the <c>EM_FILELINEINDEX</c> message to retrieve a character index for a given line number within a multiline edit control,
		/// independently of how lines are displayed on the screen.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-filelinelength
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		EM_FILELINELENGTH = ECM_FIRST + 21,

		/// <summary>
		/// Copies a line of text from an edit control, independently of how lines are displayed on the screen, and places it in a specified buffer.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the line to retrieve from a multiline edit control. A value of zero specifies the topmost line. This
		/// parameter is ignored by a single-line edit control.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the buffer that receives a copy of the line. Before sending the message, set the first word of this buffer to the
		/// size, in <c>TCHAR</c> s, of the buffer. For ANSI text, this is the number of bytes; for Unicode text, this is the number of
		/// characters. The size in the first word is overwritten by the copied line.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the number of <c>TCHAR</c> s copied. The return value is zero if the line number specified by the wParam
		/// parameter is greater than the number of lines in the edit control.
		/// </para>
		/// <remarks>The copied line does not contain a terminating null character.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getfileline
		EM_GETFILELINE = ECM_FIRST + 22,

		/// <summary>Gets the number of lines in a multiline edit control, independently of how lines are displayed on the screen.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is an integer specifying the total number of text lines in the multiline edit control, independently of how
		/// lines are displayed on the screen. If the control has no text, the return value is 1. The return value will never be less than 1.
		/// </para>
		/// <remarks>
		/// <para>
		/// The <c>EM_GETFILELINECOUNT</c> message retrieves the total number of text lines, independently of how lines are displayed on the
		/// screen, not just the number of lines that are currently visible.
		/// </para>
		/// <para>
		/// Word-wrap does not change the number of lines this message returns, as this message works independently of how lines are
		/// displayed on the screen.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getfilelinecount
		EM_GETFILELINECOUNT = ECM_FIRST + 23,
	}

	/// <summary>Edit control Notification Codes</summary>
	[PInvokeData("WinUser.h")]
	public enum EditNotification : uint
	{
		/// <summary>
		/// Sent after an edit control performed a web search when the "Search the web" feature is enabled, see EM_ENABLESEARCHWEB. The
		/// parent window of the edit control receives this notification code through a <c>WM_NOTIFY</c> message.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the edit control.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>NMSEARCHWEB</c> structure.</para>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/en-searchweb
		[MsgParams(typeof(HWND), typeof(NMSEARCHWEB?))]
		EN_SEARCHWEB = unchecked((uint)EN_FIRST - 0),

		/// <summary>
		/// Sent when an edit control receives the keyboard focus. The parent window of the edit control receives this notification code
		/// through a <c>WM_COMMAND</c> message.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control.</para>
		/// <remarks>
		/// <para>
		/// The parent window always receives a <c>WM_COMMAND</c> message for this event, it does not require a notification mask sent with <c>EM_SETEVENTMASK</c>.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-setfocus
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_SETFOCUS = 0x0100,

		/// <summary>
		/// Sent when an edit control loses the keyboard focus. The parent window of the edit control receives this notification code through
		/// a <c>WM_COMMAND</c> message.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the edit control.</para>
		/// <remarks>
		/// <para>
		/// The parent window always receives a <c>WM_COMMAND</c> message for this event, it does not require a notification mask sent with <c>EM_SETEVENTMASK</c>.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-killfocus
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_KILLFOCUS = 0x0200,

		/// <summary>
		/// Sent when the user has taken an action that may have altered text in an edit control. Unlike the EN_UPDATE notification code,
		/// this notification code is sent after the system updates the screen. The parent window of the edit control receives this
		/// notification code through a <c>WM_COMMAND</c> message.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control.</para>
		/// <remarks>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. To receive EN_CHANGE notification codes, specify
		/// <c>ENM_CHANGE</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message. For information about the compatibility of rich edit
		/// versions with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// <para>The EN_CHANGE notification code is not sent when the <c>ES_MULTILINE</c> style is used and the text is sent through <c>WM_SETTEXT</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-change
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_CHANGE = 0x0300,

		/// <summary>
		/// Sent when an edit control is about to redraw itself. This notification code is sent after the control has formatted the text, but
		/// before it displays the text. This makes it possible to resize the edit control window, if necessary. The parent window of the
		/// edit control receives this notification code through a <c>WM_COMMAND</c> message.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control.</para>
		/// <remarks>
		/// <para>
		/// <c>Rich Edit 1.0:</c> To receive EN_UPDATE notification codes, specify <c>ENM_UPDATE</c> in the mask sent with the
		/// <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// <para>
		/// <c>Rich Edit 2.0 and later:</c> The <c>ENM_UPDATE</c> flag is ignored. The EN_UPDATE notification code is always received.
		/// However, when Microsoft Rich Edit 3.0 emulates Microsoft Rich Edit 1.0, to receive EN_UPDATE notification codes you must specify
		/// <c>ENM_UPDATE</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// <para>For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-update
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_UPDATE = 0x0400,

		/// <summary>
		/// Sent when an edit control cannot allocate enough memory to meet a specific request. The parent window of the edit control
		/// receives this notification code through a <c>WM_COMMAND</c> message.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control.</para>
		/// <remarks>
		/// <para>
		/// The parent window will always get a <c>WM_COMMAND</c> message for this event; it does not require a notification mask sent with
		/// the <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-errspace
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_ERRSPACE = 0x0500,

		/// <summary>
		/// <para>
		/// Sent when the current text insertion has exceeded the specified number of characters for the edit control. The text insertion has
		/// been truncated.
		/// </para>
		/// <para>
		/// This notification code is also sent when an edit control does not have the <c>ES_AUTOHSCROLL</c> style and the number of
		/// characters to be inserted would exceed the width of the edit control.
		/// </para>
		/// <para>
		/// This notification code is also sent when an edit control does not have the <c>ES_AUTOVSCROLL</c> style and the total number of
		/// lines resulting from a text insertion would exceed the height of the edit control.
		/// </para>
		/// <para>The parent window of the edit control receives this notification code through a <c>WM_COMMAND</c> message.</para>
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control.</para>
		/// <remarks>
		/// <para>
		/// The parent window always receives a <c>WM_COMMAND</c> message for this event, it does not require a notification mask sent with <c>EM_SETEVENTMASK</c>.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. For information about the compatibility of rich edit versions
		/// with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/en-maxtext
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_MAXTEXT = 0x0501,

		/// <summary>
		/// Sent when the user clicks an edit control's horizontal scroll bar. The parent window of the edit control receives this
		/// notification code through a <c>WM_COMMAND</c> message. The parent window is notified before the screen is updated.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control.</para>
		/// <remarks>
		/// <para>
		/// This notification code is sent for the following mouse events on the horizontal scroll bar: clicking either arrow button or
		/// clicking between the arrow button and the thumb. However, the notification code is not sent when clicking the scroll bar thumb
		/// itself. The notification code is also sent when a keyboard event causes a change in the view area of the edit control, for
		/// example, pressing HOME, END, LEFT ARROW, or RIGHT ARROW.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. To receive <c>EN_HSCROLL</c> notification codes, specify
		/// <c>ENM_SCROLL</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message. For information about the compatibility of rich edit
		/// versions with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-hscroll
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_HSCROLL = 0x0601,

		/// <summary>
		/// Sent when the user clicks an edit control's vertical scroll bar or when the user scrolls the mouse wheel over the edit control.
		/// The parent window of the edit control receives this notification code through a <c>WM_COMMAND</c> message. The parent window is
		/// notified before the screen is updated.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control.</para>
		/// <remarks>
		/// <para>
		/// This message is sent for the following mouse events on the vertical scroll bar: clicking either arrow button or clicking between
		/// the arrow button and the thumb. However, the message is not sent when clicking the scroll bar mouse itself. The message is also
		/// sent when a keyboard event causes a change in the view area of the edit control, for example, pressing HOME, END, PAGE UP, PAGE
		/// DOWN, UP ARROW, or DOWN ARROW.
		/// </para>
		/// <para>
		/// The mouse wheel is a mouse that has a center wheel that scrolls. For more information, see "The Mouse Wheel" in About Mouse Input.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> Supported in Microsoft Rich Edit 1.0 and later. To receive EN_VSCROLL notification codes, specify
		/// <c>ENM_SCROLL</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message. For information about the compatibility of rich edit
		/// versions with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-vscroll
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_VSCROLL = 0x0602,

		/// <summary>
		/// Sent when the user has changed the edit control direction to left-to-right. The parent window of the edit control receives this
		/// notification code through a <c>WM_COMMAND</c> message.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control sending the notification code.</para>
		/// <remarks>
		/// <para>
		/// If there is a bidirectional language installed on your system, for example, Arabic or Hebrew, you can change the edit control
		/// direction using CTRL+LSHIFT (for left to right) and CTRL+RSHIFT (for right to left).
		/// </para>
		/// <para><c>Rich Edit:</c> This notification code is not supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-align-ltr-ec
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_ALIGN_LTR_EC = 0x0700,

		/// <summary>
		/// Sent when the user has changed the edit control direction to right-to-left. The parent window of the edit control receives this
		/// notification code through a <c>WM_COMMAND</c> message.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control sending the notification code.</para>
		/// <remarks>
		/// <para>
		/// If there is a bidirectional language installed on your system, for example, Arabic or Hebrew, you can change the edit control
		/// direction using CTRL+LSHIFT (for left to right) and CTRL+RSHIFT (for right to left).
		/// </para>
		/// <para><c>Rich Edit:</c> This notification code is not supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-align-rtl-ec
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_ALIGN_RTL_EC = 0x0701,

		/// <summary/>
		EN_BEFORE_PASTE = 0x0800,

		/// <summary/>
		EN_AFTER_PASTE = 0x0801,
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
		/// <para>Designates a multiline edit control. The default is single-line edit control.</para>
		/// <para>
		/// When the multiline edit control is in a dialog box, the default response to pressing the ENTER key is to activate the default
		/// button. To use the ENTER key as a carriage return, use the ES_WANTRETURN style.
		/// </para>
		/// <para>
		/// When the multiline edit control is not in a dialog box and the ES_AUTOVSCROLL style is specified, the edit control shows as many
		/// lines as possible and scrolls vertically when the user presses the ENTER key. If you do not specify ES_AUTOVSCROLL, the edit
		/// control shows as many lines as possible and beeps if the user presses the ENTER key when no more lines can be displayed.
		/// </para>
		/// <para>
		/// If you specify the ES_AUTOHSCROLL style, the multiline edit control automatically scrolls horizontally when the caret goes past
		/// the right edge of the control. To start a new line, the user must press the ENTER key. If you do not specify ES_AUTOHSCROLL, the
		/// control automatically wraps words to the beginning of the next line when necessary. A new line is also started if the user
		/// presses the ENTER key. The window size determines the position of the Wordwrap. If the window size changes, the Wordwrapping
		/// position changes and the text is redisplayed.
		/// </para>
		/// <para>
		/// Multiline edit controls can have scroll bars. An edit control with scroll bars processes its own scroll bar messages. Note that
		/// edit controls without scroll bars scroll as described in the previous paragraphs and process any scroll messages sent by the
		/// parent window.
		/// </para>
		/// </summary>
		ES_MULTILINE = 0x0004,

		/// <summary>
		/// Converts all characters to uppercase as they are typed into the edit control. To change this style after the control has been
		/// created, use SetWindowLong.
		/// </summary>
		ES_UPPERCASE = 0x0008,

		/// <summary>
		/// Converts all characters to lowercase as they are typed into the edit control. To change this style after the control has been
		/// created, use SetWindowLong.
		/// </summary>
		ES_LOWERCASE = 0x0010,

		/// <summary>
		/// Displays an asterisk (*) for each character typed into the edit control. This style is valid only for single-line edit controls.
		/// </summary>
		ES_PASSWORD = 0x0020,

		/// <summary>Automatically scrolls text up one page when the user presses the ENTER key on the last line.</summary>
		ES_AUTOVSCROLL = 0x0040,

		/// <summary>
		/// Automatically scrolls text to the right by 10 characters when the user types a character at the end of the line. When the user
		/// presses the ENTER key, the control scrolls all text back to position zero.
		/// </summary>
		ES_AUTOHSCROLL = 0x0080,

		/// <summary>
		/// Negates the default behavior for an edit control. The default behavior hides the selection when the control loses the input focus
		/// and inverts the selection when the control receives the input focus. If you specify ES_NOHIDESEL, the selected text is inverted,
		/// even if the control does not have the focus.
		/// </summary>
		ES_NOHIDESEL = 0x0100,

		/// <summary>
		/// Converts text entered in the edit control. The text is converted from the Windows character set to the OEM character set and then
		/// back to the Windows character set. This ensures proper character conversion when the application calls the CharToOem function to
		/// convert a Windows string in the edit control to OEM characters. This style is most useful for edit controls that contain file
		/// names that will be used on file systems that do not support Unicode.
		/// <para>To change this style after the control has been created, use SetWindowLong.</para>
		/// </summary>
		ES_OEMCONVERT = 0x0400,

		/// <summary>Prevents the user from typing or editing text in the edit control.</summary>
		ES_READONLY = 0x0800,

		/// <summary>
		/// Specifies that a carriage return be inserted when the user presses the ENTER key while entering text into a multiline edit
		/// control in a dialog box. If you do not specify this style, pressing the ENTER key has the same effect as pressing the dialog
		/// box's default push button. This style has no effect on a single-line edit control.
		/// </summary>
		ES_WANTRETURN = 0x1000,

		/// <summary>Allows only digits to be entered into the edit control.</summary>
		ES_NUMBER = 0x2000,
	}

	/// <summary>
	/// This section lists extended styles used when creating edit controls. The value of extended styles is a bitwise combination of these styles.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/controls/edit-control-window-extended-styles
	[PInvokeData("CommCtrl.h")]
	[Flags]
	public enum EditStylesEx
	{
		/// <summary>Windows Vista and later. Enables support for carriage return (CR) end-of-line characters to break lines.</summary>
		ES_EX_ALLOWEOL_CR = 0x0001,

		/// <summary>Windows Vista and later. Enables support for linefeed (LF) end-of-line characters to break lines.</summary>
		ES_EX_ALLOWEOL_LF = 0x0002,

		/// <summary>
		/// Windows Vista and later. Enables support for both carriage return (CR) and linefeed (LF) end-of-line characters to break lines.
		/// </summary>
		ES_EX_ALLOWEOL_ALL = ES_EX_ALLOWEOL_CR | ES_EX_ALLOWEOL_LF,

		/// <summary>
		/// Windows Vista and later. Converts end-of-line characters enabled for this edit control in pasted content to match the end-of-line
		/// character used by the current document.
		/// </summary>
		ES_EX_CONVERT_EOL_ON_PASTE = 0x0004,

		/// <summary>Windows Vista and later. Enables zooming using Ctrl+MouseWheel and the EM_GETZOOM/EM_SETZOOM messages.</summary>
		ES_EX_ZOOMABLE = 0x0010,
	}

	/// <summary>
	/// Data specific to the status type. If wParam is EMSIS_COMPOSITIONSTRING, this parameter can be one or more of the following values.
	/// </summary>
	[PInvokeData("WinUser.h")]
	[Flags]
	public enum EIMES
	{
		/// <summary>
		/// If this flag is set, the edit control hooks the WM_IME_COMPOSITION message with lParam set to GCS_RESULTSTR and returns the
		/// result string immediately. If this flag is not set, the edit control passes the WM_IME_COMPOSITION message to the default window
		/// procedure and handles the result string from the WM_CHAR message; this is the default behavior of the edit control.
		/// </summary>
		EIMES_GETCOMPSTRATONCE = 0x0001,

		/// <summary>
		/// If this flag is set, the edit control cancels the composition string when it receives the WM_SETFOCUS message. If this flag is
		/// not set, the edit control does not cancel the composition string; this is the default behavior of the edit control.
		/// </summary>
		EIMES_CANCELCOMPSTRINFOCUS = 0x0002,

		/// <summary>
		/// If this flag is set, the edit control completes the composition string upon receiving the WM_KILLFOCUS message. If this flag is
		/// not set, the edit control does not complete the composition string; this is the default behavior of the edit control.
		/// </summary>
		EIMES_COMPLETECOMPSTRKILLFOCUS = 0x0004,
	}

	/// <summary>The type of status to set.</summary>
	[PInvokeData("WinUser.h")]
	[Flags]
	public enum EMSIS : ushort
	{
		/// <summary>Sets behavior for the handling composition string.</summary>
		EMSIS_COMPOSITIONSTRING = 0x0001,
	}

	/// <summary>Word-break constants.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "NC:winuser.EDITWORDBREAKPROCA")]
	public enum WB
	{
		/// <summary>
		/// Retrieves the character class and word break flags of the character at the specified position. This value is for use with rich
		/// edit controls.
		/// </summary>
		WB_CLASSIFY = 3,

		/// <summary>Checks whether the character at the specified position is a delimiter.</summary>
		WB_ISDELIMITER = 2,

		/// <summary>Finds the beginning of a word to the left of the specified position.</summary>
		WB_LEFT = 0,

		/// <summary>Finds the end-of-word delimiter to the left of the specified position. This value is for use with rich edit controls.</summary>
		WB_LEFTBREAK = 6,

		/// <summary>
		/// Finds the beginning of a word to the left of the specified position. This value is used during CTRL+LEFT key processing. This
		/// value is for use with rich edit controls.
		/// </summary>
		WB_MOVEWORDLEFT = 4,

		/// <summary>
		/// Finds the beginning of a word to the right of the specified position. This value is used during CTRL+RIGHT key processing. This
		/// value is for use with rich edit controls.
		/// </summary>
		WB_MOVEWORDRIGHT = 5,

		/// <summary>Finds the beginning of a word to the right of the specified position. This is useful in right-aligned edit controls.</summary>
		WB_RIGHT = 1,

		/// <summary>
		/// Finds the end-of-word delimiter to the right of the specified position. This is useful in right-aligned edit controls. This value
		/// is for use with rich edit controls.
		/// </summary>
		WB_RIGHTBREAK = 7,
	}

	/// <summary>Contains information about a balloon tip associated with a button control.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-editballoontip typedef struct _tagEDITBALLOONTIP { DWORD
	// cbStruct; LPCWSTR pszTitle; LPCWSTR pszText; INT ttiIcon; } EDITBALLOONTIP, *PEDITBALLOONTIP;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl._tagEDITBALLOONTIP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EDITBALLOONTIP
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A <c>DWORD</c> that contains the size, in bytes, of the structure.</para>
		/// </summary>
		public uint cbStruct;

		/// <summary>
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a Unicode string that contains the title of the balloon tip.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszTitle;

		/// <summary>
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a Unicode string that contains the balloon tip text.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszText;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// A value of type <c>INT</c> that specifies the type of icon to associate with the balloon tip. This member can be one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TTI_ERROR</c><br/> 3</description>
		/// <description>Use the error icon.</description>
		/// </item>
		/// <item>
		/// <description><c>TTI_INFO</c></description>
		/// <description>Use the information icon.</description>
		/// </item>
		/// <item>
		/// <description><c>TTI_NONE</c></description>
		/// <description>Use no icon.</description>
		/// </item>
		/// <item>
		/// <description><c>TTI_WARNING</c></description>
		/// <description>Use the warning icon.</description>
		/// </item>
		/// <item>
		/// <description><c>TTI_INFO_LARGE</c></description>
		/// <description>Use the large information icon. This is assumed to be an HICON value.</description>
		/// </item>
		/// <item>
		/// <description><c>TTI_WARNING_LARGE</c></description>
		/// <description>Use the large warning icon. This is assumed to be an HICON value.</description>
		/// </item>
		/// <item>
		/// <description><c>TTI_ERROR_LARGE</c></description>
		/// <description>Use the large error icon. This is assumed to be an HICON value.</description>
		/// </item>
		/// </list>
		/// </summary>
		public int ttiIcon;

		/// <summary>Initializes a new instance of the <see cref="EDITBALLOONTIP"/> struct.</summary>
		/// <param name="title">The title.</param>
		/// <param name="text">The text.</param>
		/// <param name="icon">The icon.</param>
		public EDITBALLOONTIP(string title, string text, int icon = 0)
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(EDITBALLOONTIP));
			pszText = text;
			pszTitle = title;
			ttiIcon = icon;
		}
	}

	/// <summary>Contains information used to handle an EN_SEARCHWEB notification code.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmsearchweb typedef struct NMSEARCHWEB { NMHDR hdr;
	// EC_SEARCHWEB_ENTRYPOINT entrypoint; BOOL hasQueryText; BOOL invokeSucceeded; } NMSEARCHWEB;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.NMSEARCHWEB")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMSEARCHWEB : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>An NMHDR structure that contains additional information about this notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>EC_SEARCHWEB_ENTRYPOINT</c></para>
		/// <para>An enum value that indicates the entry point of the search.</para>
		/// </summary>
		public EC_SEARCHWEB_ENTRYPOINT entrypoint;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>TRUE if there is query text; otherwise, FALSE.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool hasQueryText;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>TRUE if the invoke succeeded; otherwise, FALSE.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool invokeSucceeded;
	}
}