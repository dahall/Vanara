using System;

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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		CB_GETEDITSEL = 0x0140,
		CB_LIMITTEXT = 0x0141,
		CB_SETEDITSEL = 0x0142,
		CB_ADDSTRING = 0x0143,
		CB_DELETESTRING = 0x0144,
		CB_DIR = 0x0145,
		CB_GETCOUNT = 0x0146,
		CB_GETCURSEL = 0x0147,
		CB_GETLBTEXT = 0x0148,
		CB_GETLBTEXTLEN = 0x0149,
		CB_INSERTSTRING = 0x014A,
		CB_RESETCONTENT = 0x014B,
		CB_FINDSTRING = 0x014C,
		CB_SELECTSTRING = 0x014D,
		CB_SETCURSEL = 0x014E,
		CB_SHOWDROPDOWN = 0x014F,
		CB_GETITEMDATA = 0x0150,
		CB_SETITEMDATA = 0x0151,
		CB_GETDROPPEDCONTROLRECT = 0x0152,
		CB_SETITEMHEIGHT = 0x0153,
		CB_GETITEMHEIGHT = 0x0154,
		CB_SETEXTENDEDUI = 0x0155,
		CB_GETEXTENDEDUI = 0x0156,
		CB_GETDROPPEDSTATE = 0x0157,
		CB_FINDSTRINGEXACT = 0x0158,
		CB_SETLOCALE = 0x0159,
		CB_GETLOCALE = 0x015A,
		CB_GETTOPINDEX = 0x015b,
		CB_SETTOPINDEX = 0x015c,
		CB_GETHORIZONTALEXTENT = 0x015d,
		CB_SETHORIZONTALEXTENT = 0x015e,
		CB_GETDROPPEDWIDTH = 0x015f,
		CB_SETDROPPEDWIDTH = 0x0160,
		CB_INITSTORAGE = 0x0161,
		CB_MULTIPLEADDSTRING = 0x0163,
		CB_GETCOMBOBOXINFO = 0x0164,
		CB_SETMINVISIBLE = CBM_FIRST + 1,
		CB_GETMINVISIBLE = CBM_FIRST + 2,
		CB_SETCUEBANNER = CBM_FIRST + 3,
		CB_GETCUEBANNER = CBM_FIRST + 4,
		CBEM_SETIMAGELIST = WindowMessage.WM_USER + 2,
		CBEM_GETIMAGELIST = WindowMessage.WM_USER + 3,
		CBEM_DELETEITEM = CB_DELETESTRING,
		CBEM_GETCOMBOCONTROL = WindowMessage.WM_USER + 6,
		CBEM_GETEDITCONTROL = WindowMessage.WM_USER + 7,
		CBEM_SETEXSTYLE = WindowMessage.WM_USER + 8, // use  SETEXTENDEDSTYLE instead
		CBEM_SETEXTENDEDSTYLE = WindowMessage.WM_USER + 14, // lparam == new style, wParam (optional) == mask
		CBEM_GETEXSTYLE = WindowMessage.WM_USER + 9, // use GETEXTENDEDSTYLE instead
		CBEM_GETEXTENDEDSTYLE = WindowMessage.WM_USER + 9,
		CBEM_SETUNICODEFORMAT = 0x2005,
		CBEM_GETUNICODEFORMAT = 0x2006,
		CBEM_HASEDITCHANGED = WindowMessage.WM_USER + 10,
		CBEM_INSERTITEM = WindowMessage.WM_USER + 11,
		CBEM_SETITEM = WindowMessage.WM_USER + 12,
		CBEM_GETITEM = WindowMessage.WM_USER + 13,
		CBEM_SETWINDOWTHEME = 0x200B,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>Combo Box Notification Codes</summary>
	[PInvokeData("Winuser.h", MSDNShortId = "ff485902")]
	public enum ComboBoxNotification
	{
		/// <summary>
		/// Sent when a combo box cannot allocate enough memory to meet a specific request. The parent window of the combo box receives
		/// this notification code through the WM_COMMAND message.
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
		CBN_ERRSPACE = (-1),

		/// <summary>
		/// Sent when the user changes the current selection in the list box of a combo box. The user can change the selection by
		/// clicking in the list box or by using the arrow keys. The parent window of the combo box receives this notification code in
		/// the form of a WM_COMMAND message.
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
		/// Sent when a combo box receives the keyboard focus. The parent window of the combo box receives this notification code through
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
		CBN_SETFOCUS = 3,

		/// <summary>
		/// Sent when a combo box loses the keyboard focus. The parent window of the combo box receives this notification code through
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
		CBN_KILLFOCUS = 4,

		/// <summary>
		/// Sent after the user has taken an action that may have altered the text in the edit control portion of a combo box. Unlike the
		/// CBN_EDITUPDATE notification code, this notification code is sent after the system updates the screen. The parent window of
		/// the combo box receives this notification code through the WM_COMMAND message.
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
		/// control has formatted the text, but before it displays the text. The parent window of the combo box receives this
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
		CBN_EDITUPDATE = 6,

		/// <summary>
		/// Sent when the list box of a combo box is about to be made visible. The parent window of the combo box receives this
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
		CBN_DROPDOWN = 7,

		/// <summary>
		/// Sent when the list box of a combo box has been closed. The parent window of the combo box receives this notification code
		/// through the WM_COMMAND message.
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
		/// Sent when the user selects a list item, or selects an item and then closes the list. It indicates that the user's selection
		/// is to be processed. The parent window of the combo box receives this notification code through the WM_COMMAND message.
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
		/// Sent when the user selects an item, but then selects another control or closes the dialog box. It indicates the user's
		/// initial selection is to be ignored. The parent window of the combo box receives this notification code through the WM_COMMAND message.
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
		/// Sent when the user activates the drop-down list or clicks in the control's edit box. This notification code is sent in the
		/// form of a WM_NOTIFY message.
		/// <list>
		/// <item>
		/// <term>lParam</term>
		/// <description>
		/// A pointer to an <see cref="User32.NMHDR"/> structure that contains information about the notification code.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_BEGINEDIT = CBEN_FIRST - 4,

		/// <summary>
		/// Sent when the user has concluded an operation within the edit box or has selected an item from the control's drop-down list.
		/// This notification code is sent in the form of a WM_NOTIFY message.
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
		/// Sent when the user has concluded an operation within the edit box or has selected an item from the control's drop-down list.
		/// This notification code is sent in the form of a WM_NOTIFY message.
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
		/// <description>
		/// A pointer to an <c>NMCOMBOBOXEX</c> structure that contains information about the notification code.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_GETDISPINFO = CBEN_FIRST - 7,

		/// <summary>
		/// Sent when the user begins dragging the image of the item displayed in the edit portion of the control. This notification code
		/// is sent in the form of a WM_NOTIFY message.
		/// <list>
		/// <item>
		/// <term>lParam</term>
		/// <description>
		/// A pointer to a <c>NMCBEDRAGBEGIN</c> structure that contains information about the notification code.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		CBEN_DRAGBEGIN = CBEN_FIRST - 9,
	}

	/// <summary>
	/// To create a combo box using the CreateWindow or CreateWindowEx function, specify the COMBOBOX class, appropriate window style
	/// constants, and a combination of the following combo box styles.
	/// </summary>
	[PInvokeData("CommCtrl.h", MSDNShortId = "bb775796")]
	public enum ComboBoxStyle
	{
		/// <summary>Displays the list box at all times. The current selection in the list box is displayed in the edit control.</summary>
		CBS_SIMPLE = 0x0001,

		/// <summary>
		/// Similar to CBS_SIMPLE, except that the list box is not displayed unless the user selects an icon next to the edit control.
		/// </summary>
		CBS_DROPDOWN = 0x0002,

		/// <summary>
		/// Similar to CBS_DROPDOWN, except that the edit control is replaced by a static text item that displays the current selection
		/// in the list box.
		/// </summary>
		CBS_DROPDOWNLIST = 0x0003,

		/// <summary>
		/// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are all
		/// the same height. The owner window receives a WM_MEASUREITEM message when the combo box is created and a WM_DRAWITEM message
		/// when a visual aspect of the combo box has changed.
		/// </summary>
		CBS_OWNERDRAWFIXED = 0x0010,

		/// <summary>
		/// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are
		/// variable in height. The owner window receives a WM_MEASUREITEM message for each item in the combo box when you create the
		/// combo box and a WM_DRAWITEM message when a visual aspect of the combo box has changed.
		/// </summary>
		CBS_OWNERDRAWVARIABLE = 0x0020,

		/// <summary>
		/// Automatically scrolls the text in an edit control to the right when the user types a character at the end of the line. If
		/// this style is not set, only text that fits within the rectangular boundary is allowed.
		/// </summary>
		CBS_AUTOHSCROLL = 0x0040,

		/// <summary>
		/// Converts text entered in the combo box edit control from the Windows character set to the OEM character set and then back to
		/// the Windows character set. This ensures proper character conversion when the application calls the CharToOem function to
		/// convert a Windows string in the combo box to OEM characters. This style is most useful for combo boxes that contain file
		/// names and applies only to combo boxes created with the CBS_SIMPLE or CBS_DROPDOWN style.
		/// </summary>
		CBS_OEMCONVERT = 0x0080,

		/// <summary>Automatically sorts strings added to the list box.</summary>
		CBS_SORT = 0x0100,

		/// <summary>
		/// Specifies that an owner-drawn combo box contains items consisting of strings. The combo box maintains the memory and address
		/// for the strings so the application can use the CB_GETLBTEXT message to retrieve the text for a particular item.
		/// </summary>
		CBS_HASSTRINGS = 0x0200,

		/// <summary>
		/// Specifies that the size of the combo box is exactly the size specified by the application when it created the combo box.
		/// Normally, the system sizes a combo box so that it does not display partial items.
		/// </summary>
		CBS_NOINTEGRALHEIGHT = 0x0400,

		/// <summary>
		/// Shows a disabled vertical scroll bar in the list box when the box does not contain enough items to scroll. Without this
		/// style, the scroll bar is hidden when the list box does not contain enough items.
		/// </summary>
		CBS_DISABLENOSCROLL = 0x0800,

		/// <summary>Converts to uppercase all text in both the selection field and the list.</summary>
		CBS_UPPERCASE = 0x2000,

		/// <summary>Converts to lowercase all text in both the selection field and the list.</summary>
		CBS_LOWERCASE = 0x4000,
	}
}