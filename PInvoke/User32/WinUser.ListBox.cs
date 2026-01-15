namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>Windows messages for combo-boxes.</summary>
	[PInvokeData("Winuser.h")]
	public enum ListBoxMessage
	{
		/// <summary>
		/// Adds a string to a list box. If the list box does not have the <c>LBS_SORT</c> style, the string is added to the end of the list.
		/// Otherwise, the string is inserted into the list and the list is sorted.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to the null-terminated string that is to be added.</para>
		/// <para>
		/// If the list box has an owner-drawn style but not the <c>LBS_HASSTRINGS</c> style, this parameter is stored as item data instead
		/// of a string. You can send the <c>LB_GETITEMDATA</c> and <c>LB_SETITEMDATA</c> messages to retrieve or modify the item data.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the zero-based index of the string in the list box. If an error occurs, the return value is LB_ERR. If there
		/// is insufficient space to store the new string, the return value is LB_ERRSPACE.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the list box has an owner-drawn style and the <c>LBS_SORT</c> style, but not the <c>LBS_HASSTRINGS</c> style, the system sends
		/// the <c>WM_COMPAREITEM</c> message one or more times to the owner of the list box to place the new item properly in the list box.
		/// </para>
		/// <para>
		/// The <c>LB_INITSTORAGE</c> message helps speed up the initialization of list boxes that have a large number of items (more than
		/// 100). It reserves the specified amount of memory so that subsequent <c>LB_ADDSTRING</c> messages take the shortest possible time.
		/// You can use estimates for the wParam and lParam parameters. If you overestimate, the extra memory is allocated; if you
		/// underestimate, the normal allocation is used for items that exceed the requested amount.
		/// </para>
		/// <para>
		/// If the list box has the <c>WS_HSCROLL</c> style and you add a string wider than the list box, send an
		/// <c>LB_SETHORIZONTALEXTENT</c> message to ensure the horizontal scroll bar appears.
		/// </para>
		/// <para>
		/// For an ANSI application, the system converts the text in a list box to Unicode using CP_ACP. This can cause problems. For
		/// example, accented Roman characters in a non-Unicode list box in Japanese Windows will come out garbled. To fix this, either
		/// compile the application as Unicode or use an owner-drawn list box.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-addstring
		[MsgParams(null, typeof(string))]
		LB_ADDSTRING = 0x0180,

		/// <summary>
		/// Inserts a string or item data into a list box. Unlike the <c>LB_ADDSTRING</c> message, the <c>LB_INSERTSTRING</c> message does
		/// not cause a list with the <c>LBS_SORT</c> style to be sorted.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the position at which to insert the string. If this parameter is -1, the string is added to the end of
		/// the list.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the null-terminated string to be inserted. If the list box has an owner-drawn style but not the
		/// <c>LBS_HASSTRINGS</c> style, this parameter is stored as item data instead of a string. You can send the <c>LB_GETITEMDATA</c>
		/// and <c>LB_SETITEMDATA</c> messages to retrieve or modify the item data.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the index of the position at which the string was inserted. If an error occurs, the return value is LB_ERR.
		/// If there is insufficient space to store the new string, the return value is LB_ERRSPACE.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>LB_INITSTORAGE</c> message helps speed up the initialization of list boxes that have a large number of items (more than
		/// 100). It reserves the specified amount of memory so that subsequent <c>LB_INSERTSTRING</c> messages take the shortest possible
		/// time. You can use estimates for the wParam and lParam parameters. If you overestimate, the extra memory is allocated; if you
		/// underestimate, the normal allocation is used for items that exceed the requested amount.
		/// </para>
		/// <para>
		/// If the list box has <c>WS_HSCROLL</c> style and you insert a string wider than the list box, send an
		/// <c>LB_SETHORIZONTALEXTENT</c> message to ensure the horizontal scroll bar appears.
		/// </para>
		/// <para>
		/// For an ANSI application, the system converts the text in a list box to Unicode using CP_ACP. This can cause problems. For
		/// example, accented Roman characters in a non-Unicode list box in Japanese Windows will come out garbled. To fix this, either
		/// compile the application as Unicode or use an owner-drawn list box.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-insertstring
		[MsgParams(typeof(int), typeof(string))]
		LB_INSERTSTRING = 0x0181,

		/// <summary>
		/// Deletes a string in a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the string to be deleted.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is a count of the strings remaining in the list. The return value is LB_ERR if the wParam parameter specifies an
		/// index greater than the number of items in the list.
		/// </para>
		/// </summary>
		/// <remarks>
		/// If an application creates the list box with an owner-drawn style but without the <c>LBS_HASSTRINGS</c> style, the system sends a
		/// <c>WM_DELETEITEM</c> message to the owner of the list box so the application can free any additional data associated with the item.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-deletestring
		[MsgParams(typeof(int), null)]
		LB_DELETESTRING = 0x0182,

		/// <summary>
		/// Selects one or more consecutive items in a multiple-selection list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the zero-based index of the first item to select.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies the zero-based index of the last item to select.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an error occurs, the return value is LB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the wParam parameter is less than the lParam parameter, the specified range of items is selected. If wParam is greater than or
		/// equal to lParam, the range is removed from the specified range of items. To select only one item, select two items and then
		/// deselect the unwanted item.
		/// </para>
		/// <para>Use this message only with multiple-selection list boxes.</para>
		/// <para>This message can select a range only within the first 65,536 items.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-selitemrangeex
		[MsgParams(typeof(int), typeof(int))]
		LB_SELITEMRANGEEX = 0x0183,

		/// <summary>
		/// Removes all items from a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// If the list box has an owner-drawn style but not the <c>LBS_HASSTRINGS</c> style, the owner of the list box receives a
		/// <c>WM_DELETEITEM</c> message for each item in the list box.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-resetcontent
		[MsgParams(LResultType = null)]
		LB_RESETCONTENT = 0x0184,

		/// <summary>
		/// Selects an item in a multiple-selection list box and, if necessary, scrolls the item into view.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies how to set the selection. If this parameter is <c>TRUE</c>, the item is selected and highlighted; if it is
		/// <c>FALSE</c>, the highlight is removed and the item is no longer selected.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Specifies the zero-based index of the item to set. If this parameter is -1, the selection is added to or removed from all items,
		/// depending on the value of wParam, and no scrolling occurs.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an error occurs, the return value is LB_ERR.</para>
		/// </summary>
		/// <remarks>Use this message only with multiple-selection list boxes.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-setsel
		[MsgParams(typeof(BOOL), typeof(int))]
		LB_SETSEL = 0x0185,

		/// <summary>
		/// Selects a string and scrolls it into view, if necessary. When the new string is selected, the list box removes the highlight from
		/// the previously selected string.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies the zero-based index of the string that is selected. If this parameter is -1, the list box is set to have no selection.
		/// </para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an error occurs, the return value is LB_ERR. If the wParam parameter is -1, the return value is LB_ERR even though no error occurred.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Use this message only with single-selection list boxes. You cannot use it to set or remove a selection in a multiple-selection
		/// list box.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-setcursel
		[MsgParams(typeof(int), null)]
		LB_SETCURSEL = 0x0186,

		/// <summary>
		/// Gets the selection state of an item.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the item.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an item is selected, the return value is greater than zero; otherwise, it is zero. If an error occurs, the return value is LB_ERR.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getsel
		[MsgParams(typeof(int), null)]
		LB_GETSEL = 0x0187,

		/// <summary>
		/// Gets the index of the currently selected item, if any, in a single-selection list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// In a single-selection list box, the return value is the zero-based index of the currently selected item. If there is no
		/// selection, the return value is LB_ERR.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To retrieve the indexes of the selected items in a multiple-selection list box, use the <c>LB_GETSELITEMS</c> message. To
		/// determine whether the item that has the focus rectangle in a multiple selection list box is selected, use the <c>LB_GETSEL</c> message.
		/// </para>
		/// <para>
		/// If sent to a multiple-selection list box, <c>LB_GETCURSEL</c> returns the index of the item that has the focus rectangle. If no
		/// items are selected, it returns zero.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getcursel
		[MsgParams()]
		LB_GETCURSEL = 0x0188,

		/// <summary>
		/// Gets a string from a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the string to retrieve.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the buffer that will receive the string; it is type <c>LPTSTR</c> which is subsequently cast to an <c>LPARAM</c>.
		/// The buffer must have sufficient space for the string and a terminating null character. An <c>LB_GETTEXTLEN</c> message can be
		/// sent before the <c>LB_GETTEXT</c> message to retrieve the length, in <c>TCHAR</c> s, of the string.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the length of the string, in <c>TCHAR</c> s, excluding the terminating null character. If wParam does not
		/// specify a valid index, the return value is LB_ERR.
		/// </para>
		/// </summary>
		/// <remarks>
		/// If the list box has an owner-drawn style but not the <c>LBS_HASSTRINGS</c> style, the buffer pointed to by the lParam parameter
		/// receives the value associated with the item (the item data).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-gettext
		[MsgParams(typeof(int), typeof(LPTSTR))]
		LB_GETTEXT = 0x0189,

		/// <summary>
		/// Gets the length of a string in a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the string.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the length of the string, in <c>TCHAR</c> s, excluding the terminating null character. Under certain
		/// conditions, this value may actually be greater than the length of the text. For more information, see the following Remarks section.
		/// </para>
		/// <para>If the wParam parameter does not specify a valid index, the return value is LB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Under certain conditions, the return value is larger than the actual length of the text. This occurs with certain mixtures of
		/// ANSI and Unicode, and is due to the operating system allowing for the possible existence of double-byte character set (DBCS)
		/// characters within the text. The return value, however, will always be at least as large as the actual length of the text; you can
		/// thus always use it to guide buffer allocation. This behavior can occur when an application uses both ANSI functions and common
		/// dialogs, which use Unicode.
		/// </para>
		/// <para>
		/// To obtain the exact length of the text, use the <c>WM_GETTEXT</c>, <c>LB_GETTEXT</c>, or <c>CB_GETLBTEXT</c> messages, or the
		/// <c>GetWindowText</c> function.
		/// </para>
		/// <para>
		/// If the list box has an owner-drawn style, but not the <c>LBS_HASSTRINGS</c> style, the return value is always the size, in bytes,
		/// of a <c>DWORD</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-gettextlen
		[MsgParams(typeof(int), null)]
		LB_GETTEXTLEN = 0x018A,

		/// <summary>
		/// Gets the number of items in a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the number of items in the list box, or LB_ERR if an error occurs.</para>
		/// </summary>
		/// <remarks>The returned count is one greater than the index value of the last item (the index is zero-based).</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getcount
		[MsgParams()]
		LB_GETCOUNT = 0x018B,

		/// <summary>
		/// Searches a list box for an item that begins with the characters in a specified string. If a matching item is found, the item is selected.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the item before the first item to be searched. When the search reaches the bottom of the list box, it
		/// continues from the top of the list box back to the item specified by the wParam parameter. If wParam is -1, the entire list box
		/// is searched from the beginning.
		/// </para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the null-terminated string that contains the prefix for which to search. The search is case independent, so this
		/// string can contain any combination of uppercase and lowercase letters.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the search is successful, the return value is the index of the selected item. If the search is unsuccessful, the return value
		/// is LB_ERR and the current selection is not changed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The list box is scrolled, if necessary, to bring the selected item into view.</para>
		/// <para>Do not use this message with a list box that has the <c>LBS_MULTIPLESEL</c> or the <c>LBS_EXTENDEDSEL</c> styles.</para>
		/// <para>
		/// An item is selected only if its initial characters from the starting point match the characters in the string specified by the
		/// lParam parameter.
		/// </para>
		/// <para>
		/// If the list box has the owner-drawn style but not the <c>LBS_HASSTRINGS</c> style, the action taken by <c>LB_SELECTSTRING</c>
		/// depends on whether the <c>LBS_SORT</c> style is used. If <c>LBS_SORT</c> is used, the system sends <c>WM_COMPAREITEM</c> messages
		/// to the list box owner to determine which item matches the specified string. Otherwise, <c>LB_SELECTSTRING</c> attempts to find an
		/// item that has a long value (supplied as the lParam parameter of the <c>LB_ADDSTRING</c> or <c>LB_INSERTSTRING</c> message) that
		/// matches the lParam parameter.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-selectstring
		[MsgParams(typeof(int), typeof(string))]
		LB_SELECTSTRING = 0x018C,

		/// <summary>
		/// Adds names to the list displayed by a list box. The message adds the names of directories and files that match a specified string
		/// and set of file attributes. <c>LB_DIR</c> can also add mapped drive letters to the list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The attributes of the files or directories to be added to the list box. This parameter can be one or more of the following values.
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
		/// <description>Includes subdirectories. Subdirectory names are enclosed in square brackets ([ ]).</description>
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
		/// <description>Includes read/write files with no additional attributes. This is the default setting.</description>
		/// </item>
		/// <item>
		/// <description><c>DDL_SYSTEM</c></description>
		/// <description>Includes system files.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the null-terminated string that specifies an absolute path, relative path, or filename. An absolute path can begin
		/// with a drive letter (for example, d:) or a UNC name (for example, \\ machinename\ sharename).
		/// </para>
		/// <para>
		/// If the string specifies a filename or directory that has the attributes specified by the wParam parameter, the filename or
		/// directory is added to the list. If the filename or directory name contains wildcard characters (? or *), all files or directories
		/// that match the wildcard expression and have the attributes specified by the wParam parameter are added to the list.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, the return value is the zero-based index of the last name added to the list.</para>
		/// <para>
		/// If an error occurs, the return value is LB_ERR. If there is insufficient space to store the new strings, the return value is LB_ERRSPACE.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>LB_INITSTORAGE</c> message helps speed up the initialization of list boxes that have a large number of items (more than
		/// 100). It reserves the specified amount of memory so that subsequent <c>LB_DIR</c> messages take the shortest possible time. You
		/// can use estimates for the wParam and lParam parameters. If you overestimate, the extra memory is allocated; if you underestimate,
		/// the normal allocation is used for items that exceed the requested amount.
		/// </para>
		/// <para>
		/// If wParam includes the DDL_DIRECTORY flag and lParam specifies all the subdirectories of a first-level directory, such as
		/// C:\TEMP\*, the list box will always include a ".." entry for the root directory. This is true even if the root directory has
		/// hidden or system attributes and the DDL_HIDDEN and DDL_SYSTEM flags are not specified. The root directory of an NTFS volume has
		/// hidden and system attributes.
		/// </para>
		/// <para>The list displays long filenames, if any.</para>
		/// <para>
		/// For an ANSI application, the system converts the text in a list box to Unicode using CP_ACP. This can cause problems. For
		/// example, accented Roman characters in a non-Unicode list box in Japanese Windows will come out garbled. To fix this, either
		/// compile the application as Unicode or use an owner-drawn list box.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-dir
		[MsgParams(typeof(DDL), typeof(LPTSTR))]
		LB_DIR = 0x018D,

		/// <summary>
		/// Gets the index of the first visible item in a list box. Initially the item with index 0 is at the top of the list box, but if the
		/// list box contents have been scrolled another item may be at the top. The first visible item in a multiple-column list box is the
		/// top-left item.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the index of the first visible item in the list box.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-gettopindex
		[MsgParams()]
		LB_GETTOPINDEX = 0x018E,

		/// <summary>
		/// Finds the first string in a list box that begins with the specified string.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the item before the first item to be searched. When the search reaches the bottom of the list box, it
		/// continues searching from the top of the list box back to the item specified by the wParam parameter. If wParam is -1, the entire
		/// list box is searched from the beginning.
		/// </para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the null-terminated string that contains the string for which to search. The search is case independent, so this
		/// string can contain any combination of uppercase and lowercase letters.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the index of the matching item, or LB_ERR if the search was unsuccessful.</para>
		/// </summary>
		/// <remarks>
		/// If the list box has the owner-drawn style but not the <c>LBS_HASSTRINGS</c> style, the action taken by <c>LB_FINDSTRING</c>
		/// depends on whether the <c>LBS_SORT</c> style is used. If <c>LBS_SORT</c> is used, the system sends <c>WM_COMPAREITEM</c> messages
		/// to the list box owner to determine which item matches the specified string. Otherwise, <c>LB_FINDSTRING</c> attempts to find an
		/// item that has a long value (supplied as the lParam parameter of the <c>LB_ADDSTRING</c> or <c>LB_INSERTSTRING</c> message) that
		/// matches the lParam parameter.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-findstring
		[MsgParams(typeof(int), typeof(string))]
		LB_FINDSTRING = 0x018F,

		/// <summary>
		/// Gets the total number of selected items in a multiple-selection list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the count of selected items in the list box. If the list box is a single-selection list box, the return value
		/// is LB_ERR.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getselcount
		[MsgParams()]
		LB_GETSELCOUNT = 0x0190,

		/// <summary>
		/// Fills a buffer with an array of integers that specify the item numbers of selected items in a multiple-selection list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The maximum number of selected items whose item numbers are to be placed in the buffer.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a buffer large enough for the number of integers specified by the wParam parameter.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the number of items placed in the buffer. If the list box is a single-selection list box, the return value is LB_ERR.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getselitems
		[MsgParams(typeof(int), typeof(int[]))]
		LB_GETSELITEMS = 0x0191,

		/// <summary>
		/// Sets the tab-stop positions in a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the number of tab stops.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to the first member of an array of integers containing the tab stops. The integers represent the number of quarters of
		/// the average character width for the font that is selected into the list box. For example, a tab stop of 4 is placed at 1.0
		/// character units, and a tab stop of 6 is placed at 1.5 average character units. However, if the list box is part of a dialog box,
		/// the integers are in dialog template units. The tab stops must be sorted in ascending order; backward tabs are not allowed.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If all the specified tabs are set, the return value is <c>TRUE</c>; otherwise, it is <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>To respond to the <c>LB_SETTABSTOPS</c> message, the list box must have been created with the <c>LBS_USETABSTOPS</c> style.</para>
		/// <para>
		/// If wParam is 0 and lParam is <c>NULL</c>, the default tab stop is two dialog template units. If wParam is 1, the list box will
		/// have tab stops separated by the distance specified by lParam.
		/// </para>
		/// <para>
		/// If lParam points to more than a single value, a tab stop will be set for each value in lParam, up to the number specified by wParam.
		/// </para>
		/// <para>
		/// The values specified by lParam are in dialog template units, which are the device-independent units used in dialog box templates.
		/// To convert measurements from dialog template units to screen units (pixels), use the <c>MapDialogRect</c> function.
		/// </para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The buffer pointed to by lParam must reside in writable memory,
		/// even though the message does not modify the array.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-settabstops
		[MsgParams(typeof(int), typeof(int[]), LResultType = typeof(BOOL))]
		LB_SETTABSTOPS = 0x0192,

		/// <summary>
		/// Gets the width, in pixels, that a list box can be scrolled horizontally (the scrollable width) if the list box has a horizontal
		/// scroll bar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the scrollable width, in pixels, of the list box.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To respond to the <c>LB_GETHORIZONTALEXTENT</c> message, the list box must have been defined with the <c>WS_HSCROLL</c> style.
		/// </para>
		/// <para>
		/// If the application does not set the horizontal extent of the list box (using <c>LB_SETHORIZONTALEXTENT</c>), the default
		/// horizontal extent is zero. Note that the list box does not update its horizontal extent dynamically.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-gethorizontalextent
		[MsgParams()]
		LB_GETHORIZONTALEXTENT = 0x0193,

		/// <summary>
		/// Sets the width, in pixels, by which a list box can be scrolled horizontally (the scrollable width). If the width of the list box
		/// is smaller than this value, the horizontal scroll bar horizontally scrolls items in the list box. If the width of the list box is
		/// equal to or greater than this value, the horizontal scroll bar is hidden.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the number of pixels by which the list box can be scrolled.</para>
		/// <para>Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To respond to the <c>LB_SETHORIZONTALEXTENT</c> message, the list box must have been defined with the <c>WS_HSCROLL</c> style.
		/// </para>
		/// <para>Note that a list box does not update its horizontal extent dynamically.</para>
		/// <para>This message has no effect on a multiple-column list box.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-sethorizontalextent
		[MsgParams()]
		LB_SETHORIZONTALEXTENT = 0x0194,

		/// <summary>
		/// Sets the width, in pixels, of all columns in a multiple-column list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the width, in pixels, of all columns.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-setcolumnwidth
		[MsgParams(typeof(int), null, LResultType = null)]
		LB_SETCOLUMNWIDTH = 0x0195,

		/// <summary>
		/// Adds the specified filename to a list box that contains a directory listing.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a buffer that specifies the name of the file to add.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the zero-based index of the file that was added, or LB_ERR if an error occurs.</para>
		/// </summary>
		/// <remarks>
		/// <para>The list box to which lParam is added must have been filled by the <c>DlgDirList</c> function.</para>
		/// <para>
		/// The <c>LB_INITSTORAGE</c> message helps speed up the initialization of list boxes that have a large number of items (more than
		/// 100). It reserves the specified amount of memory so that subsequent <c>LB_ADDFILE</c> messages take the shortest possible time.
		/// You can use estimates for the wParam and lParam parameters. If you overestimate, the extra memory is allocated; if you
		/// underestimate, the normal allocation is used for items that exceed the requested amount.
		/// </para>
		/// <para>
		/// For an ANSI application, the system converts the text in a list box to Unicode using CP_ACP. This can cause problems. For
		/// example, accented Roman characters in a non-Unicode list box in Japanese Windows will come out garbled. To fix this, either
		/// compile the application as Unicode or use an owner-drawn list box.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-addfile
		[MsgParams(null, typeof(string))]
		LB_ADDFILE = 0x0196,

		/// <summary>
		/// Ensures that the specified item in a list box is visible.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the item in the list box.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an error occurs, the return value is LB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// The system scrolls the list box contents so that either the specified item appears at the top of the list box or the maximum
		/// scroll range has been reached.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-settopindex
		[MsgParams(typeof(int), null)]
		LB_SETTOPINDEX = 0x0197,

		/// <summary>
		/// Gets the dimensions of the rectangle that bounds a list box item as it is currently displayed in the list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the item.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>RECT</c> structure that will receive the client coordinates for the item in the list box.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an error occurs, the return value is LB_ERR.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getitemrect
		[MsgParams(typeof(int), typeof(RECT?))]
		LB_GETITEMRECT = 0x0198,

		/// <summary>
		/// Gets the application-defined value associated with the specified list box item.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the item.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the value associated with the item, or LB_ERR if an error occurs. If the item is in an owner-drawn list box
		/// and was created without the <c>LBS_HASSTRINGS</c> style, this value was in the lParam parameter of the <c>LB_ADDSTRING</c> or
		/// <c>LB_INSERTSTRING</c> message that added the item to the list box. Otherwise, it is the value in the lParam of the
		/// <c>LB_SETITEMDATA</c> message.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getitemdata
		[MsgParams(typeof(int), null)]
		LB_GETITEMDATA = 0x0199,

		/// <summary>
		/// Sets a value associated with the specified item in a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the zero-based index of the item. If this value is -1, the lParam value applies to all items in the list box.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me): The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies the value to be associated with the item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an error occurs, the return value is LB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// If the item is in an owner-drawn list box created without the <c>LBS_HASSTRINGS</c> style, this message replaces the value
		/// contained in the lParam parameter of the <c>LB_ADDSTRING</c> or <c>LB_INSERTSTRING</c> message that added the item to the list box.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-setitemdata
		[MsgParams(typeof(int), typeof(IntPtr))]
		LB_SETITEMDATA = 0x019A,

		/// <summary>
		/// Selects or deselects one or more consecutive items in a multiple-selection list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para><c>TRUE</c> to select the range of items, or <c>FALSE</c> to deselect it.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the zero-based index of the first item to select. The <c>HIWORD</c> specifies the zero-based index of
		/// the last item to select.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an error occurs, the return value is LB_ERR.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use this message only with multiple-selection list boxes.</para>
		/// <para>This message can select a range only within the first 65,536 items.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-selitemrange
		[MsgParams(typeof(BOOL), typeof(uint))]
		LB_SELITEMRANGE = 0x019B,

		/// <summary>
		/// Sets the anchor item that is, the item from which a multiple selection starts. A multiple selection spans all items from the
		/// anchor item to the caret item.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the index of the new anchor item.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, the return value is zero.</para>
		/// <para>If the message fails, the return value is LB_ERR.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-setanchorindex
		[MsgParams(typeof(int), null)]
		LB_SETANCHORINDEX = 0x019C,

		/// <summary>
		/// Gets the index of the anchor item that is, the item from which a multiple selection starts. A multiple selection spans all items
		/// from the anchor item to the caret item.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the index of the anchor item.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getanchorindex
		[MsgParams()]
		LB_GETANCHORINDEX = 0x019D,

		/// <summary>
		/// Sets the focus rectangle to the item at the specified index in a multiple-selection list box. If the item is not visible, it is
		/// scrolled into view.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the zero-based index of the list box item that is to receive the focus rectangle.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// If this value is <c>FALSE</c>, the item is scrolled until it is fully visible; if it is <c>TRUE</c>, the item is scrolled until
		/// it is at least partially visible.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an error occurs, the return value is LB_ERR (-1). Otherwise, LB_OKAY (0) is returned.</para>
		/// </summary>
		/// <remarks>
		/// If this message is sent to a single-selection list box that does not contain a selected item, the caret index is set to the item
		/// specified by the wParam parameter. If the single-selection list box does contain a selected item, the list box returns LB_ERR.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-setcaretindex
		[MsgParams(typeof(int), typeof(BOOL))]
		LB_SETCARETINDEX = 0x019E,

		/// <summary>
		/// Retrieves the index of the item that has the focus in a multiple-selection list box. The item may or may not be selected.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the zero-based index of the focused list box item, or 0 if no item has the focus.</para>
		/// </summary>
		/// <remarks>
		/// This message can also be used to get the index of the item that is currently selected in a single-selection list box.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getcaretindex
		[MsgParams()]
		LB_GETCARETINDEX = 0x019F,

		/// <summary>
		/// Sets the height, in pixels, of items in a list box. If the list box has the <c>LBS_OWNERDRAWVARIABLE</c> style, this message sets
		/// the height of the item specified by the wParam parameter. Otherwise, this message sets the height of all items in the list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies the zero-based index of the item in the list box. Use this parameter only if the list box has the
		/// <c>LBS_OWNERDRAWVARIABLE</c> style; otherwise, set it to zero.
		/// </para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies the height, in pixels, of the item. The maximum height is 255 pixels.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the index or height is invalid, the return value is LB_ERR.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-setitemheight
		[MsgParams(typeof(int), typeof(int))]
		LB_SETITEMHEIGHT = 0x01A0,

		/// <summary>
		/// Gets the height of items in a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the list box item. This index is used only if the list box has the <c>LBS_OWNERDRAWVARIABLE</c> style;
		/// otherwise, it must be zero.
		/// </para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me): The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the height, in pixels, of each item in the list box. The return value is the height of the item specified by
		/// the wParam parameter if the list box has the <c>LBS_OWNERDRAWVARIABLE</c> style. The return value is LB_ERR if an error occurs.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getitemheight
		[MsgParams(typeof(int), null)]
		LB_GETITEMHEIGHT = 0x01A1,

		/// <summary>
		/// Finds the first list box string that exactly matches the specified string, except that the search is not case sensitive.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the item before the first item to be searched. When the search reaches the bottom of the list box, it
		/// continues searching from the top of the list box back to the item specified by the wParam parameter. If wParam is -1, the entire
		/// list box is searched from the beginning.
		/// </para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the null-terminated string for which to search. The search is not case sensitive, so this string can contain any
		/// combination of uppercase and lowercase letters.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the zero-based index of the matching item, or LB_ERR if the search was unsuccessful.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This function is only successful if the specified string and a list box item have the same length (except for the null at the end
		/// of the specified string) and have exactly the same characters.
		/// </para>
		/// <para>
		/// If the list box has the owner-drawn style but not the <c>LBS_HASSTRINGS</c> style, the action taken by <c>LB_FINDSTRINGEXACT</c>
		/// depends on whether the <c>LBS_SORT</c> style is used. If <c>LBS_SORT</c> is used, the system sends <c>WM_COMPAREITEM</c> messages
		/// to the list box owner to determine which item matches the specified string. Otherwise, <c>LB_FINDSTRINGEXACT</c> attempts to find
		/// an item that has a long value (supplied as the lParam parameter of the <c>LB_ADDSTRING</c> or <c>LB_INSERTSTRING</c> message)
		/// that matches the lParam parameter.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-findstringexact
		[MsgParams(typeof(int), typeof(string))]
		LB_FINDSTRINGEXACT = 0x01A2,

		/// <summary>
		/// Sets the current locale of the list box. You can use the locale to determine the correct sorting order of displayed text (for
		/// list boxes with the <c>LBS_SORT</c> style) and of text added by the <c>LB_ADDSTRING</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the locale identifier that the list box will use for sorting when adding text.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the previous locale identifier. If the wParam parameter specifies a locale that is not installed on the
		/// system, the return value is LB_ERR and the current list box locale is not changed.
		/// </para>
		/// </summary>
		/// <remarks>Use the <c>MAKELCID</c> macro to construct a locale identifier.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-setlocale
		[MsgParams(typeof(LCID), null, LResultType = typeof(LCID))]
		LB_SETLOCALE = 0x01A5,

		/// <summary>
		/// Gets the current locale of the list box. You can use the locale to determine the correct sorting order of displayed text (for
		/// list boxes with the <c>LBS_SORT</c> style) and of text added by the <c>LB_ADDSTRING</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value specifies the current locale of the list box. The <c>HIWORD</c> contains the country/region code and the
		/// <c>LOWORD</c> contains the language identifier.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The language identifier consists of a sublanguage identifier and a primary language identifier. Use the <c>PRIMARYLANGID</c>
		/// macro to extract the primary language identifier from the <c>LOWORD</c> of the return value, and the <c>SUBLANGID</c> macro to
		/// extract the sublanguage identifier.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-getlocale
		[MsgParams(LResultType = typeof(LCID))]
		LB_GETLOCALE = 0x01A6,

		/// <summary>
		/// Sets the count of items in a list box created with the <c>LBS_NODATA</c> style and not created with the <c>LBS_HASSTRINGS</c> style.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the new count of items in the list box.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an error occurs, the return value is LB_ERR. If there is insufficient memory to store the items, the return value is LB_ERRSPACE.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The <c>LB_SETCOUNT</c> message is supported only by list boxes created with the <c>LBS_NODATA</c> style and not created with the
		/// <c>LBS_HASSTRINGS</c> style. All other list boxes return LB_ERR.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-setcount
		[MsgParams(typeof(int), null)]
		LB_SETCOUNT = 0x01A7,

		/// <summary>
		/// Allocates memory for storing list box items. This message is used before an application adds a large number of items to a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The number of items to add.</para>
		/// <para>
		/// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) : The wParam parameter is limited to 16-bit values. This means list
		/// boxes cannot contain more than 32,767 items. Although the number of items is restricted, the total size in bytes of the items in
		/// a list box is limited only by available memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>The amount of memory, in bytes, to allocate for item strings.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the message is successful, the return value is the total number of items for which memory has been pre-allocated, that is, the
		/// total number of items added by all successful <c>LB_INITSTORAGE</c> messages.
		/// </para>
		/// <para>If the message fails, the return value is LB_ERRSPACE.</para>
		/// <para>
		/// Microsoft Windows NT 4.0 : This message does not allocate the specified amount of memory; however, it always returns the value
		/// specified in the wParam parameter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The <c>LB_INITSTORAGE</c> message helps speed up the initialization of list boxes that have a large number of items (more than
		/// 100). It reserves the specified amount of memory so that subsequent <c>LB_ADDSTRING</c>, <c>LB_INSERTSTRING</c>, <c>LB_DIR</c>,
		/// and <c>LB_ADDFILE</c> messages take the shortest possible time. You can use estimates for the wParam and lParam parameters. If
		/// you overestimate, the extra memory is allocated; if you underestimate, the normal allocation is used for items that exceed the
		/// requested amount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lb-initstorage
		[MsgParams(typeof(int), typeof(int))]
		LB_INITSTORAGE = 0x01A8,

		/// <summary>
		/// Gets the zero-based index of the item nearest the specified point in a list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the x-coordinate of a point, relative to the upper-left corner of the client area of the list box.
		/// </para>
		/// <para>
		/// The <c>HIWORD</c> specifies the y-coordinate of a point, relative to the upper-left corner of the client area of the list box.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value contains the index of the nearest item in the <c>LOWORD</c>. The <c>HIWORD</c> is zero if the specified point is
		/// in the client area of the list box, or one if it is outside the client area.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-itemfrompoint
		[MsgParams(null, typeof(uint), LResultType = typeof(uint))]
		LB_ITEMFROMPOINT = 0x01A9,

		/// <summary>Undocumented.</summary>
		LB_MULTIPLEADDSTRING = 0x01B1,

		/// <summary>
		/// Gets the number of items per column in a specified list box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the number of items per column.</para>
		/// </summary>
		/// <remarks>This message is equivalent to <c>GetListBoxInfo</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lb-getlistboxinfo
		[MsgParams()]
		LB_GETLISTBOXINFO = 0x01B2,
	}

	/// <summary>List Box Notification Codes</summary>
	[PInvokeData("Winuser.h")]
	public enum ListBoxNotification
	{
		/// <summary>
		/// Notifies the application that the list box cannot allocate enough memory to meet a specific request. The parent window of the
		/// list box receives this notification code through the <c>WM_COMMAND</c> message.
		/// </summary>
		LBN_ERRSPACE = -2,

		/// <summary>
		/// Notifies the application that the selection in a list box has changed as a result of user input. The parent window of the list
		/// box receives this notification code through the <c>WM_COMMAND</c> message.
		/// </summary>
		/// <remarks>
		/// <para>This notification code is sent only by a list box that has the <c>LBS_NOTIFY</c> style.</para>
		/// <para>
		/// This notification code is not sent if the <c>LB_SETSEL</c>, <c>LB_SETCURSEL</c>, <c>LB_SELECTSTRING</c>, <c>LB_SELITEMRANGE</c>
		/// or <c>LB_SELITEMRANGEEX</c> message changes the selection.
		/// </para>
		/// <para>
		/// For a multiple-selection list box, the LBN_SELCHANGE notification code is sent whenever the user presses an arrow key, even if
		/// the selection does not change.
		/// </para>
		/// </remarks>
		LBN_SELCHANGE = 1,

		/// <summary>
		/// Notifies the application that the user has double-clicked an item in a list box. The parent window of the list box receives this
		/// notification code through the <c>WM_COMMAND</c> message.
		/// </summary>
		/// <remarks>This notification code is sent only by a list box that has the <c>LBS_NOTIFY</c> style.</remarks>
		LBN_DBLCLK = 2,

		/// <summary>
		/// Notifies the application that the user has canceled the selection in a list box. The parent window of the list box receives this
		/// notification code through the <c>WM_COMMAND</c> message.
		/// </summary>
		/// <remarks>This notification code is sent only by a list box that has the L <c>BS_NOTIFY</c> style.</remarks>
		LBN_SELCANCEL = 3,

		/// <summary>
		/// Notifies the application that the list box has received the keyboard focus. The parent window of the list box receives this
		/// notification code through the <c>WM_COMMAND</c> message.
		/// </summary>
		LBN_SETFOCUS = 4,

		/// <summary>
		/// Notifies the application that the list box has lost the keyboard focus. The parent window of the list box receives this
		/// notification code through the <c>WM_COMMAND</c> message.
		/// </summary>
		LBN_KILLFOCUS = 5,
	}

	/// <summary>Error values returned by list box messages to indicate an error condition.</summary>
	[PInvokeData("Winuser.h")]
	public enum ListBoxReturnValue
	{
		/// <summary>OK</summary>
		LB_OKAY = 0,

		/// <summary>The list box message has returned an error.</summary>
		LB_ERR = -1,

		/// <summary>If there is insufficient space to store the new string</summary>
		LB_ERRSPACE = -2,
	}

	/// <summary>
	/// To create a list box using the CreateWindow or CreateWindowEx function, specify the LISTBOX class, appropriate window style
	/// constants, and a combination of the following list box styles.
	/// </summary>
	[PInvokeData("Winuser.h")]
	public enum ListBoxStyle
	{
		/// <summary>
		/// Causes the list box to send a notification code to the parent window whenever the user clicks a list box item (LBN_SELCHANGE),
		/// double-clicks an item (LBN_DBLCLK), or cancels the selection (LBN_SELCANCEL).
		/// </summary>
		LBS_NOTIFY = 0x0001,

		/// <summary>Sorts strings in the list box alphabetically.</summary>
		LBS_SORT = 0x0002,

		/// <summary>
		/// Specifies that the list box's appearance is not updated when changes are made. To change the redraw state of the control, use the
		/// WM_SETREDRAW message.
		/// </summary>
		LBS_NOREDRAW = 0x0004,

		/// <summary>
		/// Turns string selection on or off each time the user clicks or double-clicks a string in the list box. The user can select any
		/// number of strings.
		/// </summary>
		LBS_MULTIPLESEL = 0x0008,

		/// <summary>
		/// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are the same
		/// height. The owner window receives a WM_MEASUREITEM message when the list box is created and a WM_DRAWITEM message when a visual
		/// aspect of the list box has changed.
		/// </summary>
		LBS_OWNERDRAWFIXED = 0x0010,

		/// <summary>
		/// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are variable
		/// in height. The owner window receives a WM_MEASUREITEM message for each item in the box when the list box is created and a
		/// WM_DRAWITEM message when a visual aspect of the list box has changed.
		/// <para>This style causes the LBS_NOINTEGRALHEIGHT style to be enabled.</para>
		/// <para>This style is ignored if the LBS_MULTICOLUMN style is specified.</para>
		/// </summary>
		LBS_OWNERDRAWVARIABLE = 0x0020,

		/// <summary>
		/// Specifies that a list box contains items consisting of strings. The list box maintains the memory and addresses for the strings
		/// so that the application can use the LB_GETTEXT message to retrieve the text for a particular item. By default, all list boxes
		/// except owner-drawn list boxes have this style. You can create an owner-drawn list box either with or without this style.
		/// <para>
		/// For owner-drawn list boxes without this style, the LB_GETTEXT message retrieves the value associated with an item (the item data).
		/// </para>
		/// </summary>
		LBS_HASSTRINGS = 0x0040,

		/// <summary>
		/// Enables a list box to recognize and expand tab characters when drawing its strings. You can use the LB_SETTABSTOPS message to
		/// specify tab stop positions. The default tab positions are 32 dialog template units apart. Dialog template units are the
		/// device-independent units used in dialog box templates. To convert measurements from dialog template units to screen units
		/// (pixels), use the MapDialogRect function.
		/// </summary>
		LBS_USETABSTOPS = 0x0080,

		/// <summary>
		/// Specifies that the size of the list box is exactly the size specified by the application when it created the list box. Normally,
		/// the system sizes a list box so that the list box does not display partial items.
		/// <para>For list boxes with the LBS_OWNERDRAWVARIABLE style, the LBS_NOINTEGRALHEIGHT style is always enforced.</para>
		/// </summary>
		LBS_NOINTEGRALHEIGHT = 0x0100,

		/// <summary>
		/// Specifies a multi-column list box that is scrolled horizontally. The list box automatically calculates the width of the columns,
		/// or an application can set the width by using the LB_SETCOLUMNWIDTH message. If a list box has the LBS_OWNERDRAWFIXED style, an
		/// application can set the width when the list box sends the WM_MEASUREITEM message.
		/// <para>A list box with the LBS_MULTICOLUMN style cannot scroll vertically it ignores any WM_VSCROLL messages it receives.</para>
		/// <para>
		/// The LBS_MULTICOLUMN and LBS_OWNERDRAWVARIABLE styles cannot be combined. If both are specified, LBS_OWNERDRAWVARIABLE is ignored.
		/// </para>
		/// </summary>
		LBS_MULTICOLUMN = 0x0200,

		/// <summary>
		/// Specifies that the owner of the list box receives WM_VKEYTOITEM messages whenever the user presses a key and the list box has the
		/// input focus. This enables an application to perform special processing on the keyboard input.
		/// </summary>
		LBS_WANTKEYBOARDINPUT = 0x0400,

		/// <summary>Allows multiple items to be selected by using the SHIFT key and the mouse or special key combinations.</summary>
		LBS_EXTENDEDSEL = 0x0800,

		/// <summary>
		/// Shows a disabled horizontal or vertical scroll bar when the list box does not contain enough items to scroll. If you do not
		/// specify this style, the scroll bar is hidden when the list box does not contain enough items. This style must be used with the
		/// WS_VSCROLL or WS_HSCROLL style.
		/// </summary>
		LBS_DISABLENOSCROLL = 0x1000,

		/// <summary>
		/// Specifies a no-data list box. Specify this style when the count of items in the list box will exceed one thousand. A no-data list
		/// box must also have the LBS_OWNERDRAWFIXED style, but must not have the LBS_SORT or LBS_HASSTRINGS style.
		/// <para>
		/// A no-data list box resembles an owner-drawn list box except that it contains no string or bitmap data for an item.Commands to
		/// add, insert, or delete an item always ignore any specified item data; requests to find a string within the list box always
		/// fail.The system sends the WM_DRAWITEM message to the owner window when an item must be drawn.The itemID member of the
		/// DRAWITEMSTRUCT structure passed with the WM_DRAWITEM message specifies the line number of the item to be drawn.A no-data list box
		/// does not send a WM_DELETEITEM message.
		/// </para>
		/// </summary>
		LBS_NODATA = 0x2000,

		/// <summary>Specifies that the list box contains items that can be viewed but not selected.</summary>
		LBS_NOSEL = 0x4000,

		/// <summary>
		/// Notifies a list box that it is part of a combo box. This allows coordination between the two controls so that they present a
		/// unified UI. The combo box itself must set this style. If the style is set by anything but the combo box, the list box will regard
		/// itself incorrectly as a child of a combo box and a failure will result.
		/// </summary>
		LBS_COMBOBOX = 0x8000,

		/// <summary>
		/// Sorts strings in the list box alphabetically. The parent window receives a notification code whenever the user clicks a list box
		/// item, double-clicks an item, or or cancels the selection. The list box has a vertical scroll bar, and it has borders on all
		/// sides. This style combines the LBS_NOTIFY, LBS_SORT, WS_VSCROLL, and WS_BORDER styles.
		/// </summary>
		LBS_STANDARD = LBS_NOTIFY | LBS_SORT | (int)WindowStyles.WS_VSCROLL | (int)WindowStyles.WS_BORDER,
	}

	/// <summary>Retrieves the number of items per column in a specified list box.</summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the list box whose number of items per column is to be retrieved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The return value is the number of items per column.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getlistboxinfo DWORD GetListBoxInfo( [in] HWND hwnd );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GetListBoxInfo")]
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	public static extern uint GetListBoxInfo([In, AddAsMember] HWND hwnd);

	/// <summary>Gets a string from a list box. You can use this macro or send the LB_GETTEXT message explicitly.</summary>
	/// <param name="hwndCtl">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the control.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>The zero-based index of the item.</para>
	/// </param>
	/// <returns>The string of the item at <paramref name="index"/>, or an exception if index is invalid.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/windowsx/nf-windowsx-listbox_gettext void ListBox_GetText( hwndCtl, index,
	// lpszBuffer );
	[PInvokeData("windowsx.h", MSDNShortId = "NF:windowsx.ListBox_GetText")]
	public static string ListBox_GetText([In, AddAsMember] HWND hwndCtl, int index)
	{
		int len = SendMessage(hwndCtl, ListBoxMessage.LB_GETTEXTLEN, index).ToInt32();
		StringBuilder sb = new(len + 1);
		int err = SendMessage(hwndCtl, ListBoxMessage.LB_GETTEXT, (IntPtr)index, sb).ToInt32();
		return err >= 0 ? sb.ToString() : throw Win32Error.GetLastError().GetException()!;
	}
}