namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary/>
	public const int CBEN_FIRST = -800;

	/// <summary/>
	public const int CBM_FIRST = 0x1700;

	/// <summary>Contains combo box status information.</summary>
	[PInvokeData("Winuser.h", MSDNShortId = "bb775798")]
	[Flags]
	public enum ComboBoxInfoState
	{
		/// <summary>The button exists and is not pressed.</summary>
		None = 0,

		/// <summary>There is no button.</summary>
		STATE_SYSTEM_INVISIBLE = 0x00008000,

		/// <summary>The button is pressed.</summary>
		STATE_SYSTEM_PRESSED = 0x00000008
	}

	/// <summary>Windows messages for combo-boxes.</summary>
	public enum ComboBoxMessage
	{
		/// <summary>
		/// Gets the starting and ending character positions of the current selection in the edit control of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A pointer to a <c>DWORD</c> value that receives the starting position of the selection. This parameter can be <c>NULL</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>DWORD</c> value that receives the ending position of the selection. This parameter can be <c>NULL</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is a zero-based <c>DWORD</c> value with the starting position of the selection in the <c>LOWORD</c> and with the
		/// ending position of the first character after the last selected character in the <c>HIWORD</c>.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-geteditsel
		[MsgParams(typeof(uint?), typeof(uint?), LResultType = typeof(uint))]
		CB_GETEDITSEL = 0x0140,

		/// <summary>
		/// Limits the length of the text the user may type into the edit control of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The maximum number of <c>TCHARs</c> the user can enter, not including the terminating null character. If this parameter is zero,
		/// the text length is limited to 0x7FFFFFFE characters.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is always <c>TRUE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the combo box does not have the <c>CBS_AUTOHSCROLL</c> style, setting the text limit to be larger than the size of the edit
		/// control has no effect.
		/// </para>
		/// <para>
		/// The <c>CB_LIMITTEXT</c> message limits only the text the user can enter. It has no effect on any text already in the edit control
		/// when the message is sent, nor does it affect the length of the text copied to the edit control when a string in the list box is selected.
		/// </para>
		/// <para>The default limit to the text a user can enter in the edit control is 30,000 <c>TCHARs</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/cb-limittext
		[MsgParams(typeof(uint), null, LResultType = null)]
		CB_LIMITTEXT = 0x0141,

		/// <summary>
		/// An application sends a <c>CB_SETEDITSEL</c> message to select characters in the edit control of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>The <c>LOWORD</c> of lParam specifies the starting position. If the <c>LOWORD</c> is -1, the selection, if any, is removed.</para>
		/// <para>
		/// The <c>HIWORD</c> of lParam specifies the ending position. If the <c>HIWORD</c> is -1, all text from the starting position to the
		/// last character in the edit control is selected.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the message succeeds, the return value is <c>TRUE</c>. If the message is sent to a combo box with the <c>CBS_DROPDOWNLIST</c>
		/// style, it is CB_ERR.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The positions are zero-based. The first character of the edit control is in the zero position. The first character after the last
		/// selected character is in the ending position. For example, to select the first four characters of the edit control, use a
		/// starting position of 0 and an ending position of 4.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/cb-seteditsel
		[MsgParams(null, typeof(uint), LResultType = typeof(bool))]
		CB_SETEDITSEL = 0x0142,

		/// <summary>
		/// Adds a string to the list box of a combo box. If the combo box does not have the <c>CBS_SORT</c> style, the string is added to
		/// the end of the list. Otherwise, the string is inserted into the list, and the list is sorted.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// An <c>LPCTSTR</c> pointer to the null-terminated string to be added. If you create the combo box with an owner-drawn style but
		/// without the <c>CBS_HASSTRINGS</c> style, the value of the lParam parameter is stored as item data rather than the string it would
		/// otherwise point to. The item data can be retrieved or modified by sending the <c>CB_GETITEMDATA</c> or <c>CB_SETITEMDATA</c> message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the zero-based index to the string in the list box of the combo box. If an error occurs, the return value is
		/// CB_ERR. If insufficient space is available to store the new string, it is CB_ERRSPACE.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If you create an owner-drawn combo box with the <c>CBS_SORT</c> style but without the <c>CBS_HASSTRINGS</c> style, the
		/// <c>WM_COMPAREITEM</c> message is sent one or more times to the owner of the combo box so the new item can be properly placed in
		/// the list.
		/// </para>
		/// <para>To insert a string at a specific location within the list, use the <c>CB_INSERTSTRING</c> message.</para>
		/// <para>
		/// If the combo box has <c>WS_HSCROLL</c> style and you add a string wider than the combo box, send a <c>LB_SETHORIZONTALEXTENT</c>
		/// message to ensure the horizontal scroll bar appears.
		/// </para>
		/// <para>
		/// <c>Comclt32.dll version 5.0 or later:</c> If <c>CBS_LOWERCASE</c> or <c>CBS_UPPERCASE</c> is set, the Unicode version of
		/// <c>CB_ADDSTRING</c> alters the string. If using read-only global memory, this causes the application to fail.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-addstring
		[MsgParams(null, typeof(StrPtrAuto), LResultType = typeof(int))]
		CB_ADDSTRING = 0x0143,

		/// <summary>
		/// Deletes a string in the list box of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the string to delete.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is a count of the strings remaining in the list. If the wParam parameter specifies an index greater than the
		/// number of items in the list, the return value is CB_ERR.
		/// </para>
		/// </summary>
		/// <remarks>
		/// If you create the combo box with an owner-drawn style but without the <c>CBS_HASSTRINGS</c> style, the system sends a
		/// <c>WM_DELETEITEM</c> message to the owner of the combo box so the application can free any additional data associated with the item.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-deletestring
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		CB_DELETESTRING = 0x0144,

		/// <summary>
		/// Adds names to the list displayed by the combo box. The message adds the names of directories and files that match a specified
		/// string and set of file attributes. <c>CB_DIR</c> can also add mapped drive letters to the list.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The attributes of the files or directories to be added to the combo box. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>DDL_ARCHIVE</c></description>
		/// <description>Includes archived files.</description>
		/// </item>
		/// <item>
		/// <description><c>DDL_DIRECTORY</c></description>
		/// <description>Includes subdirectories, which are enclosed in square brackets ([ ]).</description>
		/// </item>
		/// <item>
		/// <description><c>DDL_DRIVES</c></description>
		/// <description>
		/// All mapped drives are added to the list. Drives are listed in the form [- <c>x</c>-], where <c>x</c> is the drive letter.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>DDL_EXCLUSIVE</c></description>
		/// <description>
		/// Includes only files with the specified attributes. By default, read/write files are listed even if DDL_READWRITE is not specified.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>DDL_HIDDEN</c></description>
		/// <description>Includes hidden files.</description>
		/// </item>
		/// <item>
		/// <description><c>DDL_READONLY</c></description>
		/// <description>Includes read-only files.</description>
		/// </item>
		/// <item>
		/// <description><c>DDL_READWRITE</c></description>
		/// <description>Includes read/write files with no additional attributes. This is the default.</description>
		/// </item>
		/// <item>
		/// <description><c>DDL_SYSTEM</c></description>
		/// <description>Includes system files.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// An <c>LPCTSTR</c> pointer to a null-terminated string that specifies an absolute path, relative path, or file name. An absolute
		/// path can begin with a drive letter (for example, d:) or a UNC name (for example, \\machinename\sharename). If the string
		/// specifies a file name or directory that has the attributes specified by the wParam parameter, the file name or directory is added
		/// to the list. If the file name or directory name contains wildcard characters (? or *), all files or directories that match the
		/// wildcard expression and have the attributes specified by the wParam parameter are added to the list displayed in the combo box.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, the return value is the zero-based index of the last name added to the list.</para>
		/// <para>
		/// If an error occurs, the return value is CB_ERR. If there is insufficient space to store the new strings, the return value is CB_ERRSPACE.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If wParam includes the DDL_DIRECTORY flag and lParam specifies all the subdirectories of a first-level directory, such as
		/// C:\TEMP\*, the list box will always include a ".." entry for the root directory. This is true even if the root directory has
		/// hidden or system attributes and the DDL_HIDDEN and DDL_SYSTEM flags are not specified. The root directory of an NTFS volume has
		/// hidden and system attributes.
		/// </para>
		/// <para>The list displays long file names, if any.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-dir
		[MsgParams(typeof(DDL), typeof(StrPtrAuto), LResultType = typeof(int))]
		CB_DIR = 0x0145,

		/// <summary>
		/// Gets the number of items in the list box of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the number of items in the list box. If an error occurs, it is CB_ERR.</para>
		/// </summary>
		/// <remarks>The index is zero-based, so the returned count is one greater than the index value of the last item.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getcount
		[MsgParams(LResultType = typeof(int))]
		CB_GETCOUNT = 0x0146,

		/// <summary>
		/// An application sends a <c>CB_GETCURSEL</c> message to retrieve the index of the currently selected item, if any, in the list box
		/// of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the zero-based index of the currently selected item. If no item is selected, it is CB_ERR.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getcursel
		[MsgParams(LResultType = typeof(int))]
		CB_GETCURSEL = 0x0147,

		/// <summary>
		/// Gets a string from the list of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the string to retrieve.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the buffer that receives the string. The buffer must have sufficient space for the string and a terminating null
		/// character. You can send a <c>CB_GETLBTEXTLEN</c> message prior to the <c>CB_GETLBTEXT</c> message to retrieve the length, in
		/// <c>TCHAR</c> s, of the string. If it is an ANSI string this is the number of bytes, but if it is a Unicode string this is the
		/// number of characters.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the length of the string, in <c>TCHAR</c> s, excluding the terminating null character. If wParam does not
		/// specify a valid index, the return value is CB_ERR.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <c>Security Warning:</c> Using this message incorrectly can compromise the security of your program. This message does not
		/// provide a way for you to know the size of the buffer. If you use this message, first call <c>CB_GETLBTEXTLEN</c> to get the
		/// number of characters that are required and then call the message to retrieve the string. You should review the Security
		/// Considerations: Microsoft Windows Controls before continuing.
		/// </para>
		/// <para>
		/// If you create the combo box with an owner-drawn style but without the <c>CBS_HASSTRINGS</c> style, the buffer pointed to by
		/// lParam receives the data associated with the item.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getlbtext
		[MsgParams(typeof(int), typeof(StrPtrAuto), LResultType = typeof(int))]
		CB_GETLBTEXT = 0x0148,

		/// <summary>
		/// Gets the length, in characters, of a string in the list of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the string.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the length of the string, in <c>TCHAR</c> s, excluding the terminating null character. If an ANSI string this
		/// is the number of bytes, and if it is a Unicode string this is the number of characters. Under certain conditions, this value may
		/// actually be greater than the length of the text. For more information, see the Remarks section.
		/// </para>
		/// <para>If the wParam parameter does not specify a valid index, the return value is CB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Under certain conditions, the return value is larger than the actual length of the text. This occurs with certain mixtures of
		/// ANSI and Unicode, and is due to the operating system allowing for the possible existence of double-byte character set (DBCS)
		/// characters within the text. The return value, however, will always be at least as large as the actual length of the text; so you
		/// can always use it to guide buffer allocation. This behavior can occur when an application uses both ANSI functions and common
		/// dialogs, which use Unicode.
		/// </para>
		/// <para>
		/// To obtain the exact length of the text, use the <c>WM_GETTEXT</c>, <c>LB_GETTEXT</c>, or <c>CB_GETLBTEXT</c> messages, or the
		/// <c>GetWindowText</c> function.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getlbtextlen
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		CB_GETLBTEXTLEN = 0x0149,

		/// <summary>
		/// Inserts a string or item data into the list of a combo box. Unlike the <c>CB_ADDSTRING</c> message, the <c>CB_INSERTSTRING</c>
		/// message does not cause a list with the <c>CBS_SORT</c> style to be sorted.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the position at which to insert the string. If this parameter is -1, the string is added to the end of
		/// the list.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the null-terminated string to be inserted. If you create the combo box with an owner-drawn style but without the
		/// <c>CBS_HASSTRINGS</c> style, the value of the lParam parameter is stored rather than the string to which it would otherwise point.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the index of the position at which the string was inserted. If an error occurs, the return value is CB_ERR.
		/// If there is insufficient space available to store the new string, it is CB_ERRSPACE.
		/// </para>
		/// <para>
		/// If the combo box has <c>WS_HSCROLL</c> style and you insert a string wider than the combo box, you should send a
		/// <c>LB_SETHORIZONTALEXTENT</c> message to ensure the horizontal scroll bar appears.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-insertstring
		[MsgParams(typeof(int), typeof(string), LResultType = typeof(int))]
		CB_INSERTSTRING = 0x014A,

		/// <summary>
		/// Removes all items from the list box and edit control of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message always returns CB_OKAY.</para>
		/// </summary>
		/// <remarks>
		/// If you create the combo box with an owner-drawn style but without the <c>CBS_HASSTRINGS</c> style, the owner of the combo box
		/// receives a <c>WM_DELETEITEM</c> message for each item in the combo box.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-resetcontent
		[MsgParams()]
		CB_RESETCONTENT = 0x014B,

		/// <summary>
		/// Searches the list box of a combo box for an item beginning with the characters in a specified string.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the item preceding the first item to be searched. When the search reaches the bottom of the list box, it
		/// continues from the top of the list box back to the item specified by the wParam parameter. If wParam is -1, the entire list box
		/// is searched from the beginning.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the null-terminated string that contains the characters for which to search. The search is not case sensitive, so
		/// this string can contain any combination of uppercase and lowercase letters.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the zero-based index of the matching item. If the search is unsuccessful, it is CB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// If you create the combo box with an owner-drawn style but without the <c>CBS_HASSTRINGS</c> style, what the <c>CB_FINDSTRING</c>
		/// message does depends on whether your application uses the <c>CBS_SORT</c> style. If you use the <c>CBS_SORT</c> style,
		/// <c>WM_COMPAREITEM</c> messages are sent to the owner of the combo box to determine which item matches the specified string. If
		/// you do not use the <c>CBS_SORT</c> style, the <c>CB_FINDSTRING</c> message searches for a list item that matches the value of the
		/// lParam parameter.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-findstring
		[MsgParams(typeof(int), typeof(string), LResultType = typeof(int))]
		CB_FINDSTRING = 0x014C,

		/// <summary>
		/// Searches the list of a combo box for an item that begins with the characters in a specified string. If a matching item is found,
		/// it is selected and copied to the edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the item preceding the first item to be searched. When the search reaches the bottom of the list, it
		/// continues from the top of the list back to the item specified by the wParam parameter. If wParam is -1, the entire list is
		/// searched from the beginning.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the null-terminated string that contains the characters for which to search. The search is not case sensitive, so
		/// this string can contain any combination of uppercase and lowercase letters.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the string is found, the return value is the index of the selected item. If the search is unsuccessful, the return value is
		/// CB_ERR and the current selection is not changed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>A string is selected only if the characters from the starting point match the characters in the prefix string.</para>
		/// <para>
		/// If you create the combo box with an owner-drawn style but without the <c>CBS_HASSTRINGS</c> style, what the
		/// <c>CB_SELECTSTRING</c> message does depends on whether you use the <c>CBS_SORT</c> style. If the <c>CBS_SORT</c> style is used,
		/// the system sends <c>WM_COMPAREITEM</c> messages to the owner of the combo box to determine which item matches the specified
		/// string. If you do not use the <c>CBS_SORT</c> style, <c>CB_SELECTSTRING</c> attempts to match the <c>DWORD</c> value against the
		/// value of the lParam parameter.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-selectstring
		[MsgParams(typeof(int), typeof(string), LResultType = typeof(int))]
		CB_SELECTSTRING = 0x014D,

		/// <summary>
		/// An application sends a <c>CB_SETCURSEL</c> message to select a string in the list of a combo box. If necessary, the list scrolls
		/// the string into view. The text in the edit control of the combo box changes to reflect the new selection, and any previous
		/// selection in the list is removed.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies the zero-based index of the string to select. If this parameter is -1, any current selection in the list is removed and
		/// the edit control is cleared.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the message is successful, the return value is the index of the item selected. If wParam is greater than the number of items
		/// in the list or if wParam is -1, the return value is CB_ERR and the selection is cleared.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-setcursel
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		CB_SETCURSEL = 0x014E,

		/// <summary>
		/// An application sends a <c>CB_SHOWDROPDOWN</c> message to show or hide the list box of a combo box that has the
		/// <c>CBS_DROPDOWN</c> or <c>CBS_DROPDOWNLIST</c> style.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A <c>BOOL</c> that specifies whether the drop-down list box is to be shown or hidden. A value of <c>TRUE</c> shows the list box;
		/// a value of <c>FALSE</c> hides it.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is always <c>TRUE</c>.</para>
		/// </summary>
		/// <remarks>This message has no effect on a combo box created with the <c>CBS_SIMPLE</c> style.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-showdropdown
		[MsgParams(typeof(bool), null, LResultType = typeof(bool))]
		CB_SHOWDROPDOWN = 0x014F,

		/// <summary>
		/// An application sends a <c>CB_GETITEMDATA</c> message to a combo box to retrieve the application-supplied value associated with
		/// the specified item in the combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the item.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the value associated with the item. If an error occurs, it is CB_ERR.</para>
		/// <para>
		/// If the item is in an owner-drawn combo box created without the <c>CBS_HASSTRINGS</c> style, the return value is the value
		/// contained in the lParam parameter of the <c>CB_ADDSTRING</c> or <c>CB_INSERTSTRING</c> message, that added the item to the combo
		/// box. If the <c>CBS_HASSTRINGS</c> style was not used, the return value is the lParam parameter contained in a
		/// <c>CB_SETITEMDATA</c> message.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getitemdata
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		CB_GETITEMDATA = 0x0150,

		/// <summary>
		/// An application sends a <c>CB_SETITEMDATA</c> message to set the value associated with the specified item in a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the item's zero-based index.</para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies the new value to be associated with the item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an error occurs, the return value is CB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// If the specified item is in an owner-drawn combo box created without the <c>CBS_HASSTRINGS</c> style, this message replaces the
		/// value in the lParam parameter of the <c>CB_ADDSTRING</c> or <c>CB_INSERTSTRING</c> message that added the item to the combo box.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-setitemdata
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(int))]
		CB_SETITEMDATA = 0x0151,

		/// <summary>
		/// An application sends a <c>CB_GETDROPPEDCONTROLRECT</c> message to retrieve the screen coordinates of a combo box in its
		/// dropped-down state.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to the <c>RECT</c> structure that receives the coordinates of the combo box in its dropped-down state.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, the return value is nonzero.</para>
		/// <para>If the message fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getdroppedcontrolrect
		[MsgParams(null, typeof(RECT), LResultType = typeof(BOOL))]
		CB_GETDROPPEDCONTROLRECT = 0x0152,

		/// <summary>
		/// An application sends a <c>CB_SETITEMHEIGHT</c> message to set the height of list items or the selection field in a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the component of the combo box for which to set the height.</para>
		/// <para>
		/// This parameter must be 1 to set the height of the selection field. It must be zero to set the height of list items, unless the
		/// combo box has the <c>CBS_OWNERDRAWVARIABLE</c> style. In that case, the wParam parameter is the zero-based index of a specific
		/// list item.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies the height, in pixels, of the combo box component identified by wParam.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the index or height is invalid, the return value is CB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// The selection field height in a combo box is set independently of the height of the list items. An application must ensure that
		/// the height of the selection field is not smaller than the height of a particular list item.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-setitemheight
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(int))]
		CB_SETITEMHEIGHT = 0x0153,

		/// <summary>
		/// Determines the height of list items or the selection field in a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The combo box component whose height is to be retrieved. This parameter must be -1 to retrieve the height of the selection field.
		/// It must be zero to retrieve the height of list items, unless the combo box has the <c>CBS_OWNERDRAWVARIABLE</c> style. In that
		/// case, the wParam parameter is the zero-based index of a specific list item.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the height, in pixels, of the list items in a combo box. If the combo box has the
		/// <c>CBS_OWNERDRAWVARIABLE</c> style, it is the height of the item specified by the wParam parameter. If wParam is -1, the return
		/// value is the height of the edit control (or static-text) portion of the combo box. If an error occurs, the return value is CB_ERR.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/cb-getitemheight
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		CB_GETITEMHEIGHT = 0x0154,

		/// <summary>
		/// An application sends a <c>CB_SETEXTENDEDUI</c> message to select either the default UI or the extended UI for a combo box that
		/// has the <c>CBS_DROPDOWN</c> or <c>CBS_DROPDOWNLIST</c> style.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A <c>BOOL</c> that specifies whether the combo box uses the extended UI ( <c>TRUE</c>) or the default UI ( <c>FALSE</c>).</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is CB_OKAY. If an error occurs, it is CB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// By default, the F4 key opens or closes the list and the DOWN ARROW changes the current selection. In the extended UI, the F4 key
		/// is disabled and the DOWN ARROW key opens the drop-down list. The mouse wheel, which normally scrolls through the items in the
		/// list, has no effect when the extended UI is set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-setextendedui
		[MsgParams(typeof(BOOL), null, LResultType = typeof(int))]
		CB_SETEXTENDEDUI = 0x0155,

		/// <summary>
		/// Determines whether a combo box has the default user interface or the extended user interface.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the combo box has the extended user interface, the return value is <c>TRUE</c>; otherwise, it is <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// By default, the F4 key opens or closes the list and the DOWN ARROW changes the current selection. In a combo box with the
		/// extended user interface, the F4 key is disabled and pressing the DOWN ARROW key opens the drop-down list.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getextendedui
		[MsgParams(LResultType = typeof(BOOL))]
		CB_GETEXTENDEDUI = 0x0156,

		/// <summary>
		/// Determines whether the list box of a combo box is dropped down.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the list box is visible, the return value is <c>TRUE</c>; otherwise, it is <c>FALSE</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getdroppedstate
		[MsgParams(LResultType = typeof(BOOL))]
		CB_GETDROPPEDSTATE = 0x0157,

		/// <summary>
		/// Finds the first list box string in a combo box that matches the string specified in the lParam parameter.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the item preceding the first item to be searched. When the search reaches the bottom of the list box, it
		/// continues from the top of the list box back to the item specified by the wParam parameter. If wParam is -1, the entire list box
		/// is searched from the beginning.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the null-terminated string for which to search. The search is not case sensitive, so this string can contain any
		/// combination of uppercase and lowercase letters.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the zero-based index of the matching item. If the search is unsuccessful, it is CB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This function is successful only if the specified string and a combo box item have the same length (except for the terminating
		/// null character) and the same characters.
		/// </para>
		/// <para>
		/// If you create the combo box with an owner-drawn style but without the <c>CBS_HASSTRINGS</c> style, the functionality of
		/// <c>CB_FINDSTRINGEXACT</c> message depends on whether your application uses the <c>CBS_SORT</c> style. If you use the
		/// <c>CBS_SORT</c> style, <c>WM_COMPAREITEM</c> messages are sent to the owner of the combo box to determine which item matches the
		/// specified string. If you do not use the <c>CBS_SORT</c> style, the <c>CB_FINDSTRINGEXACT</c> message searches for a list item
		/// that matches the value of the lParam parameter.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-findstringexact
		[MsgParams(typeof(int), typeof(string), LResultType = typeof(int))]
		CB_FINDSTRINGEXACT = 0x0158,

		/// <summary>
		/// An application sends a <c>CB_SETLOCALE</c> message to set the current locale of the combo box. If the combo box has the
		/// <c>CBS_SORT</c> style and strings are added using <c>CB_ADDSTRING</c>, the locale of a combo box affects how list items are sorted.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the locale identifier for the combo box to use for sorting when adding text.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the previous locale identifier. If wParam specifies a locale not installed on the system, the return value is
		/// CB_ERR and the current combo box locale is not changed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Use the <c>MAKELCID</c> macro to construct a locale identifier and the <c>MAKELANGID</c> macro to construct a language
		/// identifier. The language identifier is made up of a primary language identifier and a sublanguage identifier.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-setlocale
		[MsgParams(typeof(LCID), null, LResultType = typeof(LCID))]
		CB_SETLOCALE = 0x0159,

		/// <summary>
		/// Gets the current locale of the combo box. The locale is used to determine the correct sorting order of displayed text for combo
		/// boxes with the <c>CBS_SORT</c> style and text added by using the <c>CB_ADDSTRING</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value specifies the current locale of the combo box. The <c>HIWORD</c> contains the country/region code and the
		/// <c>LOWORD</c> contains the language identifier.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The language identifier is made up of a sublanguage identifier and a primary language identifier. The <c>PRIMARYLANGID</c> macro
		/// obtains the primary language identifier and the <c>SUBLANGID</c> macro obtains the sublanguage identifier.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/cb-getlocale
		[MsgParams(LResultType = typeof(LCID))]
		CB_GETLOCALE = 0x015A,

		/// <summary>
		/// An application sends the <c>CB_GETTOPINDEX</c> message to retrieve the zero-based index of the first visible item in the list box
		/// portion of a combo box. Initially, the item with index 0 is at the top of the list box, but if the list box contents have been
		/// scrolled, another item may be at the top.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message is successful, the return value is the index of the first visible item in the list box of the combo box.</para>
		/// <para>If the message fails, the return value is CB_ERR.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/cb-gettopindex
		[MsgParams(LResultType = typeof(int))]
		CB_GETTOPINDEX = 0x015b,

		/// <summary>
		/// An application sends the <c>CB_SETTOPINDEX</c> message to ensure that a particular item is visible in the list box of a combo
		/// box. The system scrolls the list box contents so that either the specified item appears at the top of the list box or the maximum
		/// scroll range has been reached.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the zero-based index of the list item.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message is successful, the return value is zero.</para>
		/// <para>If the message fails, the return value is CB_ERR.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/cb-settopindex
		[MsgParams(typeof(int), null)]
		CB_SETTOPINDEX = 0x015c,

		/// <summary>
		/// Gets the width, in pixels, that the list box can be scrolled horizontally (the scrollable width). This is applicable only if the
		/// list box has a horizontal scroll bar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the scrollable width, in pixels.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-gethorizontalextent
		[MsgParams(LResultType = typeof(int))]
		CB_GETHORIZONTALEXTENT = 0x015d,

		/// <summary>
		/// An application sends the <c>CB_SETHORIZONTALEXTENT</c> message to set the width, in pixels, by which a list box can be scrolled
		/// horizontally (the scrollable width). If the width of the list box is smaller than this value, the horizontal scroll bar
		/// horizontally scrolls items in the list box. If the width of the list box is equal to or greater than this value, the horizontal
		/// scroll bar is hidden or, if the combo box has the <c>CBS_DISABLENOSCROLL</c> style, disabled.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the scrollable width of the list box, in pixels.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-sethorizontalextent
		[MsgParams(typeof(int), null)]
		CB_SETHORIZONTALEXTENT = 0x015e,

		/// <summary>
		/// Gets the minimum allowable width, in pixels, of the list box of a combo box with the <c>CBS_DROPDOWN</c> or
		/// <c>CBS_DROPDOWNLIST</c> style.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, the return value is the width, in pixels.</para>
		/// <para>If the message fails, the return value is CB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// By default, the minimum allowable width of the drop-down list box is zero. The width of the list box is either the minimum
		/// allowable width or the combo box width, whichever is larger.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getdroppedwidth
		[MsgParams(LResultType = typeof(int))]
		CB_GETDROPPEDWIDTH = 0x015f,

		/// <summary>
		/// An application sends the <c>CB_SETDROPPEDWIDTH</c> message to set the minimum allowable width, in pixels, of the list box of a
		/// combo box with the <c>CBS_DROPDOWN</c> or <c>CBS_DROPDOWNLIST</c> style.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The minimum allowable width of the list box, in pixels.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message is successful, The return value is the new width of the list box.</para>
		/// <para>If the message fails, the return value is CB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// By default, the minimum allowable width of the drop-down list box is zero. The width of the list box is either the minimum
		/// allowable width or the combo box width, whichever is larger.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-setdroppedwidth
		[MsgParams(typeof(int), null)]
		CB_SETDROPPEDWIDTH = 0x0160,

		/// <summary>
		/// An application sends the <c>CB_INITSTORAGE</c> message before adding a large number of items to the list box portion of a combo
		/// box. This message allocates memory for storing list box items.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The number of items to add.</para>
		/// <para><em>lParam</em></para>
		/// <para>The amount of memory to allocate for item strings, in bytes.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the message is successful, the return value is the total number of items for which memory has been pre-allocated, that is, the
		/// total number of items added by all successful <c>CB_INITSTORAGE</c> messages.
		/// </para>
		/// <para>If the message fails, the return value is CB_ERRSPACE.</para>
		/// <para>The message allocates memory and returns the success and error values described above.</para>
		/// </summary>
		/// <remarks>
		/// The <c>CB_INITSTORAGE</c> message helps speed up the initialization of combo boxes that have a large number of items (over 100).
		/// It reserves the specified amount of memory so that subsequent <c>CB_ADDSTRING</c>, <c>CB_INSERTSTRING</c>, and <c>CB_DIR</c>
		/// messages take the shortest possible time. You can use estimates for the wParam and lParam parameters. If you overestimate, the
		/// extra memory is allocated, if you underestimate, the normal allocation is used for items that exceed the requested amount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-initstorage
		[MsgParams(typeof(int), typeof(int))]
		CB_INITSTORAGE = 0x0161,

		/// <summary/>
		CB_MULTIPLEADDSTRING = 0x0163,

		/// <summary>
		/// Gets information about the specified combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>COMBOBOXINFO</c> structure that receives the information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </summary>
		/// <remarks>This message is equivalent to <c>GetComboBoxInfo</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getcomboboxinfo
		[MsgParams(null, typeof(COMBOBOXINFO?), LResultType = typeof(BOOL))]
		CB_GETCOMBOBOXINFO = 0x0164,

		/// <summary>
		/// An application sends a <c>CB_SETMINVISIBLE</c> message to set the minimum number of visible items in the drop-down list of a
		/// combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the minimum number of visible items.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message is successful, the return value is <c>TRUE</c>. Otherwise the return value is <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the number of items in the drop-down list is greater than the minimum, the combo box uses a scroll bar. By default, 30 is
		/// the minimum number of visible items.
		/// </para>
		/// <para>This message is ignored if the combo box control has style <c>CBS_NOINTEGRALHEIGHT</c>.</para>
		/// <para>
		/// To use <c>CB_SETMINVISIBLE</c>, the application must specify comctl32.dll version 6 in the manifest. For more information, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-setminvisible
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		CB_SETMINVISIBLE = CBM_FIRST + 1,

		/// <summary>
		/// Gets the minimum number of visible items in the drop-down list of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the minimum number of visible items.</para>
		/// </summary>
		/// <remarks>
		/// <para>When the number of items in the drop-down list is greater than the minimum, the combo box uses a scroll bar.</para>
		/// <para>This message is ignored if the combo box control has style <c>CBS_NOINTEGRALHEIGHT</c>.</para>
		/// <para>
		/// To use <c>CB_GETMINVISIBLE</c>, the application must specify comctl32.dll version 6 in the manifest. For more information, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getminvisible
		[MsgParams()]
		CB_GETMINVISIBLE = CBM_FIRST + 2,

		/// <summary>
		/// Sets the cue banner text that is displayed for the edit control of a combo box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a null-terminated Unicode string buffer that contains the text.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns 1 if successful, or an error value otherwise.</para>
		/// </summary>
		/// <remarks>The cue banner is text that is displayed in the edit control of a combo box when there is no selection.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-setcuebanner
		[MsgParams(null, typeof(StrPtrUni), LResultType = typeof(int))]
		CB_SETCUEBANNER = CBM_FIRST + 3,

		/// <summary>
		/// Gets the cue banner text displayed in the edit control of a combo box. Send this message explicitly or by using the
		/// <c>ComboBox_GetCueBannerText</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A pointer to a Unicode string buffer that receives the cue banner text. The calling application is responsible for allocating the
		/// memory for the buffer. The buffer size must be equal to the length of the cue banner string in <c>WCHARs</c>, plus 1 for the
		/// terminating <c>NULL</c><c>WCHAR</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>The size of the buffer pointed to by lpcwText in <c>WCHARs</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns 1 if successful, or an error value otherwise.</para>
		/// <para>
		/// If there is no cue banner text to get, the return value is 0. If the calling application fails to allocate a buffer, or set
		/// lParam before sending this message, undefined behavior may result and the return value may not be reliable.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cb-getcuebanner
		[MsgParams(typeof(StrPtrUni), typeof(int), LResultType = typeof(int))]
		CB_GETCUEBANNER = CBM_FIRST + 4,

		/// <summary>
		/// Sets an image list for a ComboBoxEx control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the image list to be set for the control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the image list previously associated with the control, or returns <c>NULL</c> if no image list was
		/// previously set.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Important</para>
		/// <para>
		/// The height of images in your image list might change the size requirements of the ComboBoxEx control. It is recommended that you
		/// resize the control after sending this message to ensure that it is displayed properly.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setimagelist
		[MsgParams(null, typeof(HIMAGELIST), LResultType = typeof(HIMAGELIST))]
		CBEM_SETIMAGELIST = WindowMessage.WM_USER + 2,

		/// <summary>
		/// Gets the handle to an image list assigned to a ComboBoxEx control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the image list assigned to the control if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-getimagelist
		[MsgParams(LResultType = typeof(HIMAGELIST))]
		CBEM_GETIMAGELIST = WindowMessage.WM_USER + 3,

		/// <summary>
		/// Removes an item from a ComboBoxEx control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the item to be removed.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns an INT value that represents the number of items remaining in the control. If iIndex is invalid, the message returns CB_ERR.
		/// </para>
		/// </summary>
		/// <remarks>This message maps to the combo box control message <c>CB_DELETESTRING</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-deleteitem
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		CBEM_DELETEITEM = CB_DELETESTRING,

		/// <summary>
		/// Gets the handle to the child combo box control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the combo box control within the ComboBoxEx control.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-getcombocontrol
		[MsgParams(LResultType = typeof(HWND))]
		CBEM_GETCOMBOCONTROL = WindowMessage.WM_USER + 6,

		/// <summary>
		/// Gets the handle to the edit control portion of a ComboBoxEx control. A ComboBoxEx control uses an edit box when it is set to the
		/// <c>CBS_DROPDOWN</c> style.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the edit control within the ComboBoxEx control if it uses the <c>CBS_DROPDOWN</c> style. Otherwise, the
		/// message returns <c>NULL</c>.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-geteditcontrol
		[MsgParams(LResultType = typeof(HWND))]
		CBEM_GETEDITCONTROL = WindowMessage.WM_USER + 7,

		/// <summary/>
		[Obsolete("Use CBEM_SETEXTENDEDSTYLE instead.", false)]
		CBEM_SETEXSTYLE = WindowMessage.WM_USER + 8,

		/// <summary>
		/// Sets extended styles within a ComboBoxEx control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A <c>DWORD</c> value that indicates which styles in lParam are to be affected. Only the extended styles in wParam will be
		/// changed. If this parameter is zero, then all of the styles in lParam will be affected.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>DWORD</c> value that contains the ComboBoxEx Control Extended Styles to set for the control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>DWORD</c> value that contains the extended styles previously used for the control.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// wParam enables you to modify one or more extended styles without having to retrieve the existing styles first. For example, if
		/// you pass <c>CBES_EX_NOEDITIMAGE</c> for wParam and 0 for lParam, the <c>CBES_EX_NOEDITIMAGE</c> style will be cleared, but all
		/// other styles will remain the same.
		/// </para>
		/// <para>
		/// If you try to set an extended style for a ComboBoxEx control created with the <c>CBS_SIMPLE</c> style, it may not repaint properly.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setextendedstyle
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(int))]
		CBEM_SETEXTENDEDSTYLE = WindowMessage.WM_USER + 14,

		/// <summary/>
		[Obsolete("Use CBEM_GETEXTENDEDSTYLE instead.", false)]
		CBEM_GETEXSTYLE = WindowMessage.WM_USER + 9,

		/// <summary>
		/// Gets the extended styles that are in use for a ComboBoxEx control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a DWORD value that contains the ComboBoxEx control extended styles in use for the control.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-getextendedstyle
		[MsgParams(LResultType = typeof(int))]
		CBEM_GETEXTENDEDSTYLE = WindowMessage.WM_USER + 9,

		/// <summary>
		/// Sets the UNICODE character format flag for the control. This message enables you to change the character set used by the control
		/// at run time rather than having to re-create the control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Determines the character set that is used by the control. If this value is nonzero, the control will use Unicode characters. If
		/// this value is zero, the control will use ANSI characters.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous Unicode format flag for the control.</para>
		/// </summary>
		/// <remarks>See the remarks for <c>CCM_SETUNICODEFORMAT</c> for a discussion of this message.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setunicodeformat
		[MsgParams(typeof(BOOL), null, LResultType = typeof(BOOL))]
		CBEM_SETUNICODEFORMAT = 0x2005,

		/// <summary>
		/// Gets the UNICODE character format flag for the control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the Unicode format flag for the control. If this value is nonzero, the control is using Unicode characters. If this value
		/// is zero, the control is using ANSI characters.
		/// </para>
		/// </summary>
		/// <remarks>See the remarks for <c>CCM_GETUNICODEFORMAT</c> for a discussion of this message.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-getunicodeformat
		[MsgParams(LResultType = typeof(BOOL))]
		CBEM_GETUNICODEFORMAT = 0x2006,

		/// <summary>
		/// Determines whether the user has changed the text of a ComboBoxEx edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if the text in the control's edit box has been changed, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A ComboBoxEx control uses an edit box control when it is set to the <c>CBS_DROPDOWN</c> style. You can retrieve the edit box
		/// control's window handle by sending a <c>CBEM_GETEDITCONTROL</c> message.
		/// </para>
		/// <para>
		/// When the user begins editing, you will receive a CBEN_BEGINEDIT notification. When editing is complete, or the focus changes, you
		/// will receive a CBEN_ENDEDIT notification. The <c>CBEM_HASEDITCHANGED</c> message is only useful for determining whether the text
		/// has been changed if it is sent before the CBEN_ENDEDIT notification. If the message is sent afterward, it will return
		/// <c>FALSE</c>. For example, suppose the user starts to edit the text in the edit box but changes focus, generating a CBEN_ENDEDIT
		/// notification. If you then send a <c>CBEM_HASEDITCHANGED</c> message, it will return <c>FALSE</c>, even though the text has been changed.
		/// </para>
		/// <para>The <c>CBS_SIMPLE</c> style does not work correctly with <c>CBEM_HASEDITCHANGED</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-haseditchanged
		[MsgParams(LResultType = typeof(BOOL))]
		CBEM_HASEDITCHANGED = WindowMessage.WM_USER + 10,

		/// <summary>
		/// Inserts a new item in a ComboBoxEx control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>COMBOBOXEXITEM</c> structure that contains information about the item to be inserted. When the message is sent,
		/// the <c>iItem</c> member must be set to indicate the zero-based index at which to insert the item. To insert an item at the end of
		/// the list, set the <c>iItem</c> member to -1.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index at which the new item was inserted if successful, or -1 otherwise.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-insertitem
		[MsgParams(null, typeof(IntPtr), LResultType = typeof(int))]
		CBEM_INSERTITEM = WindowMessage.WM_USER + 11,

		/// <summary>
		/// Sets the attributes for an item in a ComboBoxEx control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>COMBOBOXEXITEM</c> structure that contains the item information to be set. When the message is sent, the
		/// <c>mask</c> member of the structure must be set to indicate which attributes are valid and the <c>iItem</c> member must specify
		/// the zero-based index of the item to be modified. Setting the <c>iItem</c> member to -1 will modify the item displayed in the edit control.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setitem
		[MsgParams(null, typeof(IntPtr), LResultType = typeof(BOOL))]
		CBEM_SETITEM = WindowMessage.WM_USER + 12,

		/// <summary>
		/// Gets item information for a given ComboBoxEx item.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>COMBOBOXEXITEM</c> structure that receives the item information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the message is sent, the <c>iItem</c> and <c>mask</c> members of the structure must be set to indicate the index of the
		/// target item and the type of information to be retrieved. Other members are set as needed. For example, to retrieve text, you must
		/// set the CBEIF_TEXT flag in <c>mask</c>, and assign a value to <c>cchTextMax</c>. Setting the <c>iItem</c> member to -1 will
		/// retrieve the item displayed in the edit control.
		/// </para>
		/// <para>
		/// If the CBEIF_TEXT flag is set in the <c>mask</c> member of the <c>COMBOBOXEXITEM</c> structure, the control may change the
		/// <c>pszText</c> member of the structure to point to the new text instead of filling the buffer with the requested text.
		/// Applications should not assume that the text will always be placed in the requested buffer.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/cbem-getitem
		[MsgParams(null, typeof(IntPtr), LResultType = typeof(BOOL))]
		CBEM_GETITEM = WindowMessage.WM_USER + 13,

		/// <summary>
		/// Sets the visual style of a ComboBoxEx control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a Unicode string that contains the control visual style to set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32 version 6.0. For more information on manifests, see Enabling
		/// Visual Styles.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setwindowtheme
		[MsgParams(null, typeof(StrPtrUni), LResultType = null)]
		CBEM_SETWINDOWTHEME = 0x200B,
	}

	/// <summary>Combo Box Notification Codes</summary>
	[PInvokeData("Winuser.h", MSDNShortId = "ff485902")]
	public enum ComboBoxNotification
	{
		/// <summary>
		/// Sent when a combo box cannot allocate enough memory to meet a specific request. The parent window of the combo box receives this
		/// notification code through the WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_ERRSPACE = -1,

		/// <summary>
		/// Sent when the user changes the current selection in the list box of a combo box. The user can change the selection by clicking in
		/// the list box or by using the arrow keys. The parent window of the combo box receives this notification code in the form of a
		/// WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_SELCHANGE = 1,

		/// <summary>
		/// Sent when the user double-clicks a string in the list box of a combo box. The parent window of the combo box receives this
		/// notification code through the WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_DBLCLK = 2,

		/// <summary>
		/// Sent when a combo box receives the keyboard focus. The parent window of the combo box receives this notification code through the
		/// WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_SETFOCUS = 3,

		/// <summary>
		/// Sent when a combo box loses the keyboard focus. The parent window of the combo box receives this notification code through the
		/// WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_KILLFOCUS = 4,

		/// <summary>
		/// Sent after the user has taken an action that may have altered the text in the edit control portion of a combo box. Unlike the
		/// CBN_EDITUPDATE notification code, this notification code is sent after the system updates the screen. The parent window of the
		/// combo box receives this notification code through the WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_EDITCHANGE = 5,

		/// <summary>
		/// Sent when the edit control portion of a combo box is about to display altered text. This notification code is sent after the
		/// control has formatted the text, but before it displays the text. The parent window of the combo box receives this notification
		/// code through the WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_EDITUPDATE = 6,

		/// <summary>
		/// Sent when the list box of a combo box is about to be made visible. The parent window of the combo box receives this notification
		/// code through the WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_DROPDOWN = 7,

		/// <summary>
		/// Sent when the list box of a combo box has been closed. The parent window of the combo box receives this notification code through
		/// the WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_CLOSEUP = 8,

		/// <summary>
		/// Sent when the user selects a list item, or selects an item and then closes the list. It indicates that the user's selection is to
		/// be processed. The parent window of the combo box receives this notification code through the WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_SELENDOK = 9,

		/// <summary>
		/// Sent when the user selects an item, but then selects another control or closes the dialog box. It indicates the user's initial
		/// selection is to be ignored. The parent window of the combo box receives this notification code through the WM_COMMAND message.
		/// <list>
		/// <item>
		/// <term>wParam</term>
		/// <description>The LOWORD contains the control identifier of the combo box. The HIWORD specifies the notification code.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the combo box.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBN_SELENDCANCEL = 10,

		/// <summary>
		/// Sent when a new item has been inserted in the control. This notification code is sent in the form of a WM_NOTIFY message.
		/// <list>
		/// <item>
		/// <term>lParam</term>
		/// <description>
		/// A pointer to an <c>NMCOMBOBOXEX</c> structure containing information about the notification code and the item that was inserted.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_INSERTITEM = CBEN_FIRST - 1,

		/// <summary>
		/// Sent when an item has been deleted. This notification code is sent in the form of a WM_NOTIFY message.
		/// <list>
		/// <item>
		/// <term>lParam</term>
		/// <description>
		/// A pointer to an <c>NMCOMBOBOXEX</c> structure that contains information about the notification code and the deleted item.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_DELETEITEM = CBEN_FIRST - 2,

		/// <summary>
		/// Sent when the user activates the drop-down list or clicks in the control's edit box. This notification code is sent in the form
		/// of a WM_NOTIFY message.
		/// <list>
		/// <item>
		/// <term>lParam</term>
		/// <description>A pointer to an <see cref="NMHDR"/> structure that contains information about the notification code.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_BEGINEDIT = CBEN_FIRST - 4,

		/// <summary>
		/// Sent when the user has concluded an operation within the edit box or has selected an item from the control's drop-down list. This
		/// notification code is sent in the form of a WM_NOTIFY message.
		/// <list>
		/// <item>
		/// <term>lParam</term>
		/// <description>
		/// A pointer to an <c>NMCBEENDEDIT</c> structure that contains information about how the user concluded the edit operation.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_ENDEDITA = CBEN_FIRST - 5,

		/// <summary>
		/// Sent when the user has concluded an operation within the edit box or has selected an item from the control's drop-down list. This
		/// notification code is sent in the form of a WM_NOTIFY message.
		/// <list>
		/// <item>
		/// <term>lParam</term>
		/// <description>
		/// A pointer to an <c>NMCBEENDEDIT</c> structure that contains information about how the user concluded the edit operation.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_ENDEDITW = CBEN_FIRST - 6,

		/// <summary>
		/// Sent to retrieve display information about a callback item. This notification code is sent in the form of a WM_NOTIFY message.
		/// <list>
		/// <item>
		/// <term>lParam</term>
		/// <description>A pointer to an <c>NMCOMBOBOXEX</c> structure that contains information about the notification code.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_GETDISPINFO = CBEN_FIRST - 7,

		/// <summary>
		/// Sent when the user begins dragging the image of the item displayed in the edit portion of the control. This notification code is
		/// sent in the form of a WM_NOTIFY message.
		/// <list>
		/// <item>
		/// <term>lParam</term>
		/// <description>A pointer to a <c>NMCBEDRAGBEGIN</c> structure that contains information about the notification code.</description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_DRAGBEGIN = CBEN_FIRST - 9,
	}

	/// <summary>
	/// To create a combo box using the CreateWindow or CreateWindowEx function, specify the COMBOBOX class, appropriate window style
	/// constants, and a combination of the following combo box styles.
	/// </summary>
	[PInvokeData("winuser.h", MSDNShortId = "bb775796")]
	[Flags]
	public enum ComboBoxStyle
	{
		/// <summary>Displays the list box at all times. The current selection in the list box is displayed in the edit control.</summary>
		CBS_SIMPLE = 0x0001,

		/// <summary>
		/// Similar to CBS_SIMPLE, except that the list box is not displayed unless the user selects an icon next to the edit control.
		/// </summary>
		CBS_DROPDOWN = 0x0002,

		/// <summary>
		/// Similar to CBS_DROPDOWN, except that the edit control is replaced by a static text item that displays the current selection in
		/// the list box.
		/// </summary>
		CBS_DROPDOWNLIST = 0x0003,

		/// <summary>
		/// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are all the
		/// same height. The owner window receives a WM_MEASUREITEM message when the combo box is created and a WM_DRAWITEM message when a
		/// visual aspect of the combo box has changed.
		/// </summary>
		CBS_OWNERDRAWFIXED = 0x0010,

		/// <summary>
		/// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are variable
		/// in height. The owner window receives a WM_MEASUREITEM message for each item in the combo box when you create the combo box and a
		/// WM_DRAWITEM message when a visual aspect of the combo box has changed.
		/// </summary>
		CBS_OWNERDRAWVARIABLE = 0x0020,

		/// <summary>
		/// Automatically scrolls the text in an edit control to the right when the user types a character at the end of the line. If this
		/// style is not set, only text that fits within the rectangular boundary is allowed.
		/// </summary>
		CBS_AUTOHSCROLL = 0x0040,

		/// <summary>
		/// Converts text entered in the combo box edit control from the Windows character set to the OEM character set and then back to the
		/// Windows character set. This ensures proper character conversion when the application calls the CharToOem function to convert a
		/// Windows string in the combo box to OEM characters. This style is most useful for combo boxes that contain file names and applies
		/// only to combo boxes created with the CBS_SIMPLE or CBS_DROPDOWN style.
		/// </summary>
		CBS_OEMCONVERT = 0x0080,

		/// <summary>Automatically sorts strings added to the list box.</summary>
		CBS_SORT = 0x0100,

		/// <summary>
		/// Specifies that an owner-drawn combo box contains items consisting of strings. The combo box maintains the memory and address for
		/// the strings so the application can use the CB_GETLBTEXT message to retrieve the text for a particular item.
		/// </summary>
		CBS_HASSTRINGS = 0x0200,

		/// <summary>
		/// Specifies that the size of the combo box is exactly the size specified by the application when it created the combo box.
		/// Normally, the system sizes a combo box so that it does not display partial items.
		/// </summary>
		CBS_NOINTEGRALHEIGHT = 0x0400,

		/// <summary>
		/// Shows a disabled vertical scroll bar in the list box when the box does not contain enough items to scroll. Without this style,
		/// the scroll bar is hidden when the list box does not contain enough items.
		/// </summary>
		CBS_DISABLENOSCROLL = 0x0800,

		/// <summary>Converts to uppercase all text in both the selection field and the list.</summary>
		CBS_UPPERCASE = 0x2000,

		/// <summary>Converts to lowercase all text in both the selection field and the list.</summary>
		CBS_LOWERCASE = 0x4000,
	}

	/// <summary>Contains combo box status information.</summary>
	[PInvokeData("Winuser.h", MSDNShortId = "bb775798")]
	[StructLayout(LayoutKind.Sequential)]
	public struct COMBOBOXINFO
	{
		/// <summary>The size, in bytes, of the structure. The calling application must set this to sizeof(COMBOBOXINFO).</summary>
		public int cbSize;

		/// <summary>A RECT structure that specifies the coordinates of the edit box.</summary>
		public RECT rcItem;

		/// <summary>A RECT structure that specifies the coordinates of the button that contains the drop-down arrow.</summary>
		public RECT rcButton;

		/// <summary>The combo box button state.</summary>
		public ComboBoxInfoState buttonState;

		/// <summary>A handle to the combo box.</summary>
		public HWND hwndCombo;

		/// <summary>A handle to the edit box.</summary>
		public HWND hwndEdit;

		/// <summary>A handle to the drop-down list.</summary>
		public HWND hwndList;

		/// <summary>Creates an instance of the <see cref="COMBOBOXINFO"/> structure from a handle and retrieves its values.</summary>
		/// <param name="hComboBox">The handle to a ComboBox.</param>
		/// <returns>A <see cref="COMBOBOXINFO"/> structure with values from the supplied handle.</returns>
		public static COMBOBOXINFO FromHandle(HWND hComboBox)
		{
			if (hComboBox.IsNull)
				throw new ArgumentException("ComboBox handle cannot be NULL.", nameof(hComboBox));

			COMBOBOXINFO cbi = new() { cbSize = Marshal.SizeOf(typeof(COMBOBOXINFO)) };
			_ = SendMessage(hComboBox, ComboBoxMessage.CB_GETCOMBOBOXINFO, 0, ref cbi);
			return cbi;
		}

		/// <summary>Gets a value indicating whether this <see cref="COMBOBOXINFO"/> is invisible.</summary>
		/// <value><c>true</c> if invisible; otherwise, <c>false</c>.</value>
		public bool Invisible => (buttonState & ComboBoxInfoState.STATE_SYSTEM_INVISIBLE) == ComboBoxInfoState.STATE_SYSTEM_INVISIBLE;

		/// <summary>Gets a value indicating whether this <see cref="COMBOBOXINFO"/> is pressed.</summary>
		/// <value><c>true</c> if pressed; otherwise, <c>false</c>.</value>
		public bool Pressed => (buttonState & ComboBoxInfoState.STATE_SYSTEM_PRESSED) == ComboBoxInfoState.STATE_SYSTEM_PRESSED;

		/// <summary>Gets the item rectangle.</summary>
		/// <value>The item rectangle.</value>
		public RECT ItemRectangle => rcItem;

		/// <summary>Gets the button rectangle.</summary>
		/// <value>The button rectangle.</value>
		public RECT ButtonRectangle => rcButton;
	}
}