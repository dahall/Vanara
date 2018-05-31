using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable InconsistentNaming ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		public const int CBEN_FIRST = -800;
		public const int CBM_FIRST = 0x1700;
		public const string WC_COMBOBOXEX = "ComboBoxEx32";

		/// <summary>A value that specifies the action that generated the CBEN_ENDEDIT notification code.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775750")]
		public enum CBEN_ENDEDIT_FLAG
		{
			/// <summary>The edit box lost the keyboard focus.</summary>
			CBENF_KILLFOCUS = 1,

			/// <summary>The user completed the edit operation by pressing ENTER.</summary>
			CBENF_RETURN = 2,

			/// <summary>The user pressed ESC.</summary>
			CBENF_ESCAPE = 3,

			/// <summary>The user activated the drop-down list.</summary>
			CBENF_DROPDOWN = 4,
		}

		/// <summary>
		/// A set of bit flags that specify attributes of COMBOBOXEXITEM or of an operation that is using this structure. The flags specify members that are
		/// valid or must be filled in.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775746")]
		[Flags]
		public enum ComboBoxExItemMask
		{
			/// <summary>The pszText member is valid or must be filled in.</summary>
			CBEIF_TEXT = 0x00000001,

			/// <summary>The iImage member is valid or must be filled in.</summary>
			CBEIF_IMAGE = 0x00000002,

			/// <summary>The iSelectedImage member is valid or must be filled in.</summary>
			CBEIF_SELECTEDIMAGE = 0x00000004,

			/// <summary>The iOverlay member is valid or must be filled in.</summary>
			CBEIF_OVERLAY = 0x00000008,

			/// <summary>The iIndent member is valid or must be filled in.</summary>
			CBEIF_INDENT = 0x00000010,

			/// <summary>The lParam member is valid or must be filled in.</summary>
			CBEIF_LPARAM = 0x00000020,

			/// <summary>
			/// Set this flag when processing CBEN_GETDISPINFO; the ComboBoxEx control will retain the supplied information and will not request it again.
			/// </summary>
			CBEIF_DI_SETITEM = 0x10000000,
		}

		/// <summary>Support the extended styles that are listed in this section as well as most standard combo box control styles.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775742")]
		public enum ComboBoxExStyle
		{
			/// <summary>The edit box and the dropdown list will not display item images.</summary>
			CBES_EX_NOEDITIMAGE = 0x00000001,

			/// <summary>The edit box and the dropdown list will not display item images.</summary>
			CBES_EX_NOEDITIMAGEINDENT = 0x00000002,

			/// <summary>
			/// Windows NT only. The edit box will use the slash (/), backslash (\), and period (.) characters as word delimiters. This makes keyboard shortcuts
			/// for word-by-word cursor movement effective in path names and URLs.
			/// </summary>
			CBES_EX_PATHWORDBREAKPROC = 0x00000004,

			/// <summary>
			/// Allows the ComboBoxEx control to be vertically sized smaller than its contained combo box control. If the ComboBoxEx is sized smaller than the
			/// combo box, the combo box will be clipped.
			/// </summary>
			CBES_EX_NOSIZELIMIT = 0x00000008,

			/// <summary>
			/// BSTR searches in the list will be case sensitive. This includes searches as a result of text being typed in the edit box and the
			/// CB_FINDSTRINGEXACT message.
			/// </summary>
			CBES_EX_CASESENSITIVE = 0x00000010,

			/// <summary>
			/// Windows Vista and later. Causes items in the drop-down list and the edit box (when the edit box is read only) to be truncated with an ellipsis
			/// ("...") rather than just clipped by the edge of the control. This is useful when the control needs to be set to a fixed width, yet the entries in
			/// the list may be long.
			/// </summary>
			CBES_EX_TEXTENDELLIPSIS = 0x00000020,
		}

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

		public enum ComboBoxMessage
		{
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
			CBEM_DELETEITEM = ComboBoxMessage.CB_DELETESTRING,
			CBEM_GETCOMBOCONTROL = WindowMessage.WM_USER + 6,
			CBEM_GETEDITCONTROL = WindowMessage.WM_USER + 7,
			CBEM_SETEXSTYLE = WindowMessage.WM_USER + 8, // use  SETEXTENDEDSTYLE instead
			CBEM_SETEXTENDEDSTYLE = WindowMessage.WM_USER + 14, // lparam == new style, wParam (optional) == mask
			CBEM_GETEXSTYLE = WindowMessage.WM_USER + 9, // use GETEXTENDEDSTYLE instead
			CBEM_GETEXTENDEDSTYLE = WindowMessage.WM_USER + 9,
			CBEM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,
			CBEM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT,
			CBEM_HASEDITCHANGED = WindowMessage.WM_USER + 10,
			CBEM_INSERTITEM = WindowMessage.WM_USER + 11,
			CBEM_SETITEM = WindowMessage.WM_USER + 12,
			CBEM_GETITEM = WindowMessage.WM_USER + 13,
			CBEM_SETWINDOWTHEME = CommonControlMessage.CCM_SETWINDOWTHEME,
		}

		/// <summary>Combo Box Notification Codes</summary>
		[PInvokeData("Winuser.h", MSDNShortId = "ff485902")]
		public enum ComboBoxNotification
		{
			/// <summary>
			/// Sent when a combo box cannot allocate enough memory to meet a specific request. The parent window of the combo box receives this notification
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
			CBN_ERRSPACE = (-1),

			/// <summary>
			/// Sent when the user changes the current selection in the list box of a combo box. The user can change the selection by clicking in the list box or
			/// by using the arrow keys. The parent window of the combo box receives this notification code in the form of a WM_COMMAND message.
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
			/// Sent when the user double-clicks a string in the list box of a combo box. The parent window of the combo box receives this notification code
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
			CBN_DBLCLK = 2,

			/// <summary>
			/// Sent when a combo box receives the keyboard focus. The parent window of the combo box receives this notification code through the WM_COMMAND message.
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
			/// Sent when a combo box loses the keyboard focus. The parent window of the combo box receives this notification code through the WM_COMMAND message.
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
			/// Sent after the user has taken an action that may have altered the text in the edit control portion of a combo box. Unlike the CBN_EDITUPDATE
			/// notification code, this notification code is sent after the system updates the screen. The parent window of the combo box receives this
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
			CBN_EDITCHANGE = 5,

			/// <summary>
			/// Sent when the edit control portion of a combo box is about to display altered text. This notification code is sent after the control has
			/// formatted the text, but before it displays the text. The parent window of the combo box receives this notification code through the WM_COMMAND message.
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
			/// Sent when the list box of a combo box is about to be made visible. The parent window of the combo box receives this notification code through the
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
			CBN_DROPDOWN = 7,

			/// <summary>
			/// Sent when the list box of a combo box has been closed. The parent window of the combo box receives this notification code through the WM_COMMAND message.
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
			/// Sent when the user selects a list item, or selects an item and then closes the list. It indicates that the user's selection is to be processed.
			/// The parent window of the combo box receives this notification code through the WM_COMMAND message.
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
			/// Sent when the user selects an item, but then selects another control or closes the dialog box. It indicates the user's initial selection is to be
			/// ignored. The parent window of the combo box receives this notification code through the WM_COMMAND message.
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
			/// A pointer to an <see cref="NMCOMBOBOXEX"/> structure containing information about the notification code and the item that was inserted.
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
			/// A pointer to an <see cref="NMCOMBOBOXEX"/> structure that contains information about the notification code and the deleted item.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			CBEN_DELETEITEM = CBEN_FIRST - 2,

			/// <summary>
			/// Sent when the user activates the drop-down list or clicks in the control's edit box. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an <see cref="NMHDR"/> structure that contains information about the notification code.</description>
			/// </item>
			/// </list>
			/// </summary>
			CBEN_BEGINEDIT = CBEN_FIRST - 4,

			/// <summary>
			/// Sent when the user has concluded an operation within the edit box or has selected an item from the control's drop-down list. This notification
			/// code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an <see cref="NMCBEENDEDIT"/> structure that contains information about how the user concluded the edit operation.</description>
			/// </item>
			/// </list>
			/// </summary>
			CBEN_ENDEDITA = CBEN_FIRST - 5,

			/// <summary>
			/// Sent when the user has concluded an operation within the edit box or has selected an item from the control's drop-down list. This notification
			/// code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an <see cref="NMCBEENDEDIT"/> structure that contains information about how the user concluded the edit operation.</description>
			/// </item>
			/// </list>
			/// </summary>
			CBEN_ENDEDITW = CBEN_FIRST - 6,

			/// <summary>
			/// Sent to retrieve display information about a callback item. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an <see cref="NMCOMBOBOXEX"/> structure that contains information about the notification code.</description>
			/// </item>
			/// </list>
			/// </summary>
			CBEN_GETDISPINFO = CBEN_FIRST - 7,

			/// <summary>
			/// Sent when the user begins dragging the image of the item displayed in the edit portion of the control. This notification code is sent in the form
			/// of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to a <see cref="NMCBEDRAGBEGIN"/> structure that contains information about the notification code.</description>
			/// </item>
			/// </list>
			/// </summary>
			CBEN_DRAGBEGIN = CBEN_FIRST - 9,
		}

		/// <summary>
		/// To create a combo box using the CreateWindow or CreateWindowEx function, specify the COMBOBOX class, appropriate window style constants, and a
		/// combination of the following combo box styles.
		/// </summary>
		[PInvokeData("CommCtrl.h", MSDNShortId = "bb775796")]
		public enum ComboBoxStyle
		{
			/// <summary>Displays the list box at all times. The current selection in the list box is displayed in the edit control.</summary>
			CBS_SIMPLE = 0x0001,

			/// <summary>Similar to CBS_SIMPLE, except that the list box is not displayed unless the user selects an icon next to the edit control.</summary>
			CBS_DROPDOWN = 0x0002,

			/// <summary>
			/// Similar to CBS_DROPDOWN, except that the edit control is replaced by a static text item that displays the current selection in the list box.
			/// </summary>
			CBS_DROPDOWNLIST = 0x0003,

			/// <summary>
			/// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are all the same height. The
			/// owner window receives a WM_MEASUREITEM message when the combo box is created and a WM_DRAWITEM message when a visual aspect of the combo box has changed.
			/// </summary>
			CBS_OWNERDRAWFIXED = 0x0010,

			/// <summary>
			/// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are variable in height. The
			/// owner window receives a WM_MEASUREITEM message for each item in the combo box when you create the combo box and a WM_DRAWITEM message when a
			/// visual aspect of the combo box has changed.
			/// </summary>
			CBS_OWNERDRAWVARIABLE = 0x0020,

			/// <summary>
			/// Automatically scrolls the text in an edit control to the right when the user types a character at the end of the line. If this style is not set,
			/// only text that fits within the rectangular boundary is allowed.
			/// </summary>
			CBS_AUTOHSCROLL = 0x0040,

			/// <summary>
			/// Converts text entered in the combo box edit control from the Windows character set to the OEM character set and then back to the Windows
			/// character set. This ensures proper character conversion when the application calls the CharToOem function to convert a Windows string in the
			/// combo box to OEM characters. This style is most useful for combo boxes that contain file names and applies only to combo boxes created with the
			/// CBS_SIMPLE or CBS_DROPDOWN style.
			/// </summary>
			CBS_OEMCONVERT = 0x0080,

			/// <summary>Automatically sorts strings added to the list box.</summary>
			CBS_SORT = 0x0100,

			/// <summary>
			/// Specifies that an owner-drawn combo box contains items consisting of strings. The combo box maintains the memory and address for the strings so
			/// the application can use the CB_GETLBTEXT message to retrieve the text for a particular item.
			/// </summary>
			CBS_HASSTRINGS = 0x0200,

			/// <summary>
			/// Specifies that the size of the combo box is exactly the size specified by the application when it created the combo box. Normally, the system
			/// sizes a combo box so that it does not display partial items.
			/// </summary>
			CBS_NOINTEGRALHEIGHT = 0x0400,

			/// <summary>
			/// Shows a disabled vertical scroll bar in the list box when the box does not contain enough items to scroll. Without this style, the scroll bar is
			/// hidden when the list box does not contain enough items.
			/// </summary>
			CBS_DISABLENOSCROLL = 0x0800,

			/// <summary>Converts to uppercase all text in both the selection field and the list.</summary>
			CBS_UPPERCASE = 0x2000,

			/// <summary>Converts to lowercase all text in both the selection field and the list.</summary>
			CBS_LOWERCASE = 0x4000,
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return
		/// until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to
		/// all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not
		/// sent to child windows.
		/// </param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="item">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage(HandleRef hWnd, ComboBoxMessage Msg, int wParam, ref COMBOBOXINFO item) => User32_Gdi.SendMessage(hWnd, Msg, wParam, ref item);

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
			public IntPtr hwndCombo;

			/// <summary>A handle to the edit box.</summary>
			public IntPtr hwndEdit;

			/// <summary>A handle to the drop-down list.</summary>
			public IntPtr hwndList;

			/// <summary>Creates an instance of the <see cref="COMBOBOXINFO"/> structure from a handle and retrieves its values.</summary>
			/// <param name="hComboBox">The handle to a ComboBox.</param>
			/// <returns>A <see cref="COMBOBOXINFO"/> structure with values from the supplied handle.</returns>
			[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
			public static COMBOBOXINFO FromHandle(HandleRef hComboBox)
			{
				if (hComboBox.Handle == IntPtr.Zero)
					throw new ArgumentException("ComboBox handle cannot be NULL.", nameof(hComboBox));

				var cbi = new COMBOBOXINFO() { cbSize = Marshal.SizeOf(typeof(COMBOBOXINFO)) };
				SendMessage(hComboBox, ComboBoxMessage.CB_GETCOMBOBOXINFO, 0, ref cbi);
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
			public System.Drawing.Rectangle ItemRectangle => rcItem;

			/// <summary>Gets the button rectangle.</summary>
			/// <value>The button rectangle.</value>
			public System.Drawing.Rectangle ButtonRectangle => rcButton;
		}

		/// <summary>Contains information used with the CBEN_DRAGBEGIN notification code.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775748")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NMCBEDRAGBEGIN
		{
			/// <summary>The NMHDR structure that contains information about the notification code.</summary>
			public NMHDR hdr;

			/// <summary>
			/// The zero-based index of the item being dragged. This value will always be -1, indicating that the item being dragged is the item displayed in the
			/// edit portion of the control.
			/// </summary>
			public int iItemId;

			/// <summary>The character buffer that contains the text of the item being dragged.</summary>
			public string szText;
		}

		/// <summary>
		/// Contains information about the conclusion of an edit operation within a ComboBoxEx control. This structure is used with the CBEN_ENDEDIT notification code.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775750")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NMCBEENDEDIT
		{
			/// <summary>The NMHDR structure that contains information about the notification code.</summary>
			public NMHDR hdr;

			/// <summary>
			/// A value indicating whether the contents of the control's edit box have changed. This value is nonzero if the contents have been modified, or zero otherwise.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fChanged;

			/// <summary>
			/// The zero-based index of the item that will be selected after completing the edit operation. This value can be CB_ERR if no item will be selected.
			/// </summary>
			public int iNewSelection;

			/// <summary>A zero-terminated string that contains the text from within the control's edit box.</summary>
			public string szText;

			/// <summary>A value that specifies the action that generated the CBEN_ENDEDIT notification code.</summary>
			public CBEN_ENDEDIT_FLAG iWhy;
		}

		/// <summary>Contains information specific to ComboBoxEx items for use with notification codes.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775752")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NMCOMBOBOXEX
		{
			/// <summary>The NMHDR structure that contains information about the notification code.</summary>
			public NMHDR hdr;

			/// <summary>
			/// The COMBOBOXEXITEM structure that holds item information specific to the current notification. Upon receiving a notification code, the
			/// COMBOBOXEXITEM structure holds information required for the owner to respond. The members of this structure are often used as fields for the
			/// owner to return values in response to the notification.
			/// </summary>
			public COMBOBOXEXITEM ceItem;
		}

		/// <summary>Contains information about an item in a ComboBoxEx control.</summary>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775746")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public sealed class COMBOBOXEXITEM : IDisposable
		{
			/// <summary>
			/// A set of bit flags that specify attributes of this structure or of an operation that is using this structure. The flags specify members that are
			/// valid or must be filled in.
			/// </summary>
			public ComboBoxExItemMask mask;

			/// <summary>The zero-based index of the item.</summary>
			[MarshalAs(UnmanagedType.SysInt)] public int iItem;

			/// <summary>
			/// A pointer to a character buffer that contains or receives the item's text. If text information is being retrieved, this member must be set to the
			/// address of a character buffer that will receive the text. The size of this buffer must also be indicated in cchTextMax. If this member is set to
			/// LPSTR_TEXTCALLBACK, the control will request the information by using the CBEN_GETDISPINFO notification codes.
			/// </summary>
			public IntPtr pszText;

			/// <summary>The length of pszText, in TCHARs. If text information is being set, this member is ignored.</summary>
			public int cchTextMax;

			/// <summary>
			/// The zero-based index of an image within the image list. The specified image will be displayed for the item when it is not selected. If this
			/// member is set to I_IMAGECALLBACK, the control will request the information by using CBEN_GETDISPINFO notification codes.
			/// </summary>
			public int iImage;

			/// <summary>
			/// The zero-based index of an image within the image list. The specified image will be displayed for the item when it is selected. If this member is
			/// set to I_IMAGECALLBACK, the control will request the information by using CBEN_GETDISPINFO notification codes.
			/// </summary>
			public int iSelectedImage;

			/// <summary>
			/// The one-based index of an overlay image within the image list. If this member is set to I_IMAGECALLBACK, the control will request the information
			/// by using CBEN_GETDISPINFO notification codes.
			/// </summary>
			public int iOverlay;

			/// <summary>
			/// The number of indent spaces to display for the item. Each indentation equals 10 pixels. If this member is set to I_INDENTCALLBACK, the control
			/// will request the information by using CBEN_GETDISPINFO notification codes.
			/// </summary>
			public int iIndent;

			/// <summary>A value specific to the item.</summary>
			public IntPtr lParam;

			/// <summary>Initializes a new instance of the <see cref="COMBOBOXEXITEM"/> class.</summary>
			/// <param name="textBufferSize">Size of the text buffer. If this value is 0, no buffer is created.</param>
			public COMBOBOXEXITEM(int textBufferSize = 0) : this(textBufferSize == 0 ? null : new string('\0', textBufferSize)) { }

			/// <summary>Initializes a new instance of the <see cref="COMBOBOXEXITEM"/> class.</summary>
			/// <param name="text">The text.</param>
			public COMBOBOXEXITEM(string text) { Text = text; }

			/// <summary>Gets or sets the item's text.</summary>
			/// <value>The text value.</value>
			public string Text
			{
				get => pszText == LPSTR_TEXTCALLBACK ? null : Marshal.PtrToStringAuto(pszText);
				set
				{
					((IDisposable)this).Dispose();
					if (value == null) return;
					pszText = Marshal.StringToCoTaskMemAuto(value);
					cchTextMax = value.Length;
					mask |= ComboBoxExItemMask.CBEIF_TEXT;
				}
			}

			/// <summary>Gets or sets a value indicating whether to use a text callback method.</summary>
			/// <value><c>true</c> if using text callback method; otherwise, <c>false</c>.</value>
			public bool UseTextCallback
			{
				get => pszText == LPSTR_TEXTCALLBACK;
				set
				{
					if (value)
					{
						((IDisposable)this).Dispose();
						pszText = LPSTR_TEXTCALLBACK;
					}
					mask |= ComboBoxExItemMask.CBEIF_TEXT;
				}
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose()
			{
				if (pszText != IntPtr.Zero && pszText != LPSTR_TEXTCALLBACK)
				{
					Marshal.FreeCoTaskMem(pszText);
					pszText = IntPtr.Zero;
					cchTextMax = 0;
				}
			}
		}
	}
}