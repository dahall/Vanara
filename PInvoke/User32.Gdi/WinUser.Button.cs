using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32_Gdi
	{
		private const int BCM_FIRST = 0x1600;
		private const int BCN_FIRST = -1250;

		/// <summary>Message identifiers used with the SendMessage function.</summary>
		[PInvokeData("winuser.h")]
		public enum ButtonMessage
		{
			/// <summary>
			/// Gets the check state of a radio button or check box. Return value is one of the <see cref="ButtonStateFlags"/> values.
			/// </summary>
			BM_GETCHECK = 0x00F0,

			/// <summary>Sets the check state of a radio button or check box. wParam is one of the <see cref="ButtonStateFlags"/> values.</summary>
			BM_SETCHECK = 0x00F1,

			/// <summary>Retrieves the state of a button or check box. Return value is one of the <see cref="ButtonStateFlags"/> values.</summary>
			BM_GETSTATE = 0x00F2,

			/// <summary>
			/// Sets the highlight state of a button. The highlight state indicates whether the button is highlighted as if the user had
			/// pushed it.
			/// </summary>
			BM_SETSTATE = 0x00F3,

			/// <summary>Sets the style of a button.</summary>
			BM_SETSTYLE = 0x00F4,

			/// <summary>
			/// Simulates the user clicking a button. This message causes the button to receive the WM_LBUTTONDOWN and WM_LBUTTONUP messages,
			/// and the button's parent window to receive a BN_CLICKED notification code.
			/// </summary>
			BM_CLICK = 0x00F5,

			/// <summary>Retrieves a handle to the image (icon or bitmap) associated with the button.</summary>
			BM_GETIMAGE = 0x00F6,

			/// <summary>Associates a new image (icon or bitmap) with the button.</summary>
			BM_SETIMAGE = 0x00F7,

			/// <summary>Sets a flag on a radio button that controls the generation of BN_CLICKED messages when the button receives focus.</summary>
			BM_SETDONTCLICK = 0x00F8,

			/// <summary>Gets the size of the button that best fits its text and image, if an image list is present.</summary>
			BCM_GETIDEALSIZE = BCM_FIRST + 0x0001,

			/// <summary>Assigns an image list to a button control.</summary>
			BCM_SETIMAGELIST = BCM_FIRST + 0x0002,

			/// <summary>Gets the BUTTON_IMAGELIST structure that describes the image list assigned to a button control.</summary>
			BCM_GETIMAGELIST = BCM_FIRST + 0x0003,

			/// <summary>The BCM_SETTEXTMARGIN message sets the margins for drawing text in a button control.</summary>
			BCM_SETTEXTMARGIN = BCM_FIRST + 0x0004,

			/// <summary>Gets the margins used to draw text in a button control.</summary>
			BCM_GETTEXTMARGIN = BCM_FIRST + 0x0005,

			/// <summary>Sets the drop down state for a button with style TBSTYLE_DROPDOWN.</summary>
			BCM_SETDROPDOWNSTATE = BCM_FIRST + 0x0006,

			/// <summary>Sets information for a split button control.</summary>
			BCM_SETSPLITINFO = BCM_FIRST + 0x0007,

			/// <summary>Gets information for a split button control.</summary>
			BCM_GETSPLITINFO = BCM_FIRST + 0x0008,

			/// <summary>Sets the text of the note associated with a command link button.</summary>
			BCM_SETNOTE = BCM_FIRST + 0x0009,

			/// <summary>Gets the text of the note associated with a command link button.</summary>
			BCM_GETNOTE = BCM_FIRST + 0x000A,

			/// <summary>Gets the length of the note text that may be displayed in the description for a command link button.</summary>
			BCM_GETNOTELENGTH = BCM_FIRST + 0x000B,

			/// <summary>Sets the elevation required state for a specified button or command link to display an elevated icon.</summary>
			BCM_SETSHIELD = BCM_FIRST + 0x000C,
		}

		[PInvokeData("winuser.h")]
		public enum ButtonNotification
		{
			/// <summary>
			/// Sent when the user clicks a button. The parent window of the button receives this notification code through the WM_COMMAND message.
			/// </summary>
			BN_CLICKED = 0,

			/// <summary>
			/// Sent when a button should be painted. <note type="note">This notification code is provided only for compatibility with 16-bit
			/// versions of Windows earlier than version 3.0. Applications should use the BS_OWNERDRAW button style and the DRAWITEMSTRUCT
			/// structure for this task.</note>
			/// <para>The parent window of the button receives this notification code through the WM_COMMAND message.</para>
			/// </summary>
			BN_PAINT = 1,

			/// <summary>
			/// Sent when the user selects a button. <note type="note">This notification code is provided only for compatibility with 16-bit
			/// versions of Windows earlier than version 3.0. Applications should use the BS_OWNERDRAW button style and the DRAWITEMSTRUCT
			/// structure for this task.</note>
			/// <para>The parent window of the button receives this notification code through the WM_COMMAND message.</para>
			/// </summary>
			BN_HILITE = 2,

			/// <summary>
			/// Sent when the highlight should be removed from a button. <note type="note">This notification code is provided only for
			/// compatibility with 16-bit versions of Windows earlier than version 3.0. Applications should use the BS_OWNERDRAW button style
			/// and the DRAWITEMSTRUCT structure for this task.</note>
			/// <para>The parent window of the button receives this notification code through the WM_COMMAND message.</para>
			/// </summary>
			BN_UNHILITE = 3,

			/// <summary>
			/// Sent when a button is disabled. <note type="note">This notification code is provided only for compatibility with 16-bit
			/// versions of Windows earlier than version 3.0. Applications should use the BS_OWNERDRAW button style and the DRAWITEMSTRUCT
			/// structure for this task.</note>
			/// <para>The parent window of the button receives this notification code through the WM_COMMAND message.</para>
			/// </summary>
			BN_DISABLE = 4,

			/// <summary>
			/// Sent when the user double-clicks a button. This notification code is sent automatically for BS_USERBUTTON, BS_RADIOBUTTON,
			/// and BS_OWNERDRAW buttons. Other button types send BN_DBLCLK only if they have the BS_NOTIFY style. The parent window of the
			/// button receives this notification code through the WM_COMMAND message.
			/// </summary>
			BN_DOUBLECLICKED = 5,

			/// <summary>
			/// Sent when the push state of a button is set to pushed. <note type="note">This notification code is provided only for
			/// compatibility with 16-bit versions of Windows earlier than version 3.0. Applications should use the BS_OWNERDRAW button style
			/// and the DRAWITEMSTRUCT structure for this task.</note>
			/// <para>The parent window of the button receives this notification code through the WM_COMMAND message.</para>
			/// </summary>
			BN_PUSHED = BN_HILITE,

			/// <summary>
			/// Sent when the push state of a button is set to unpushed. <note type="note">This notification code is provided only for
			/// compatibility with 16-bit versions of Windows earlier than version 3.0. Applications should use the BS_OWNERDRAW button style
			/// and the DRAWITEMSTRUCT structure for this task.</note>
			/// <para>The parent window of the button receives this notification code through the WM_COMMAND message.</para>
			/// </summary>
			BN_UNPUSHED = BN_UNHILITE,

			/// <summary>
			/// Sent when the user double-clicks a button. This notification code is sent automatically for BS_USERBUTTON, BS_RADIOBUTTON,
			/// and BS_OWNERDRAW buttons. Other button types send BN_DBLCLK only if they have the BS_NOTIFY style. The parent window of the
			/// button receives this notification code through the WM_COMMAND message.
			/// </summary>
			BN_DBLCLK = BN_DOUBLECLICKED,

			/// <summary>
			/// Sent when a button receives the keyboard focus. The button must have the BS_NOTIFY style to send this notification code.
			/// <para>The parent window of the button receives this notification code through the WM_COMMAND message.</para>
			/// </summary>
			BN_SETFOCUS = 6,

			/// <summary>
			/// Sent when a button loses the keyboard focus. The button must have the BS_NOTIFY style to send this notification code.
			/// <para>The parent window of the button receives this notification code through the WM_COMMAND message.</para>
			/// </summary>
			BN_KILLFOCUS = 7,

			/// <summary>
			/// Notifies the button control owner that the mouse is entering or leaving the client area of the button control. The button
			/// control sends this notification code in the form of a WM_NOTIFY message.
			/// </summary>
			BCN_HOTITEMCHANGE = BCN_FIRST + 0x0001,

			/// <summary>
			/// Sent when the user clicks a drop down arrow on a button. The parent window of the control receives this notification code in
			/// the form of a WM_NOTIFY message.
			/// </summary>
			BCN_DROPDOWN = BCN_FIRST + 0x0002,

			/// <summary>
			/// Sent by a button control to its parent to get measurements for the two rectangles of the split button. This notification code
			/// is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>
			/// A pointer to an NMCUSTOMSPLITRECTINFO to receive bounding rectangles information. The NMCUSTOMSPLITRECTINFO structure is sent
			/// with the notification code as a request for the parent to provide measurements for the rectangles of the split button.
			/// </description>
			/// </item>
			/// <item>
			/// <term>Return value</term>
			/// <description>
			/// Return CDRF_SKIPDEFAULT to tell the button control to use the values returned in the NMCUSTOMSPLITRECTINFO structure;
			/// otherwise, return CDRF_DODEFAULT.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			NM_GETCUSTOMSPLITRECT = BCN_FIRST + 0x0003,
		}

		[PInvokeData("winuser.h")]
		[Flags]
		public enum ButtonStateFlags
		{
			/// <summary>No special state. Equivalent to zero.</summary>
			BST_UNCHECKED = 0x0000,

			/// <summary>The button is checked.</summary>
			BST_CHECKED = 0x0001,

			/// <summary>The state of the button is indeterminate. Applies only if the button has the BS_3STATE or BS_AUTO3STATE style.</summary>
			BST_INDETERMINATE = 0x0002,

			/// <summary>The button is being shown in the pushed state.</summary>
			BST_PUSHED = 0x0004,

			/// <summary>The button has the keyboard focus.</summary>
			BST_FOCUS = 0x0008,

			/// <summary>The button is hot; that is, the mouse is hovering over it.</summary>
			BST_HOT = 0x0200,

			/// <summary>
			/// <c>Windows Vista.</c> The button is in the drop-down state. Applies only if the button has the TBSTYLE_DROPDOWN style.
			/// </summary>
			BST_DROPDOWNPUSHED = 0x0400
		}

		/// <summary>
		/// Specifies a combination of button styles. If you create a button using the BUTTON class with the CreateWindow or CreateWindowEx
		/// function, you can specify any of the button styles listed below.
		/// </summary>
		[PInvokeData("winuser.h", MSDNShortId = "30254cb5-43cd-407f-8ad6-bd7f9ec3edc7")]
		[Flags]
		public enum ButtonStyle
		{
			/// <summary>
			/// Creates a button that is the same as a check box, except that the box can be grayed as well as checked or cleared. Use the
			/// grayed state to show that the state of the check box is not determined.
			/// </summary>
			BS_3STATE = 0x00000005,

			/// <summary>
			/// Creates a button that is the same as a three-state check box, except that the box changes its state when the user selects it.
			/// The state cycles through checked, indeterminate, and cleared.
			/// </summary>
			BS_AUTO3STATE = 0x00000006,

			/// <summary>
			/// Creates a button that is the same as a check box, except that the check state automatically toggles between checked and
			/// cleared each time the user selects the check box.
			/// </summary>
			BS_AUTOCHECKBOX = 0x00000003,

			/// <summary>
			/// Creates a button that is the same as a radio button, except that when the user selects it, the system automatically sets the
			/// button's check state to checked and automatically sets the check state for all other buttons in the same group to cleared.
			/// </summary>
			BS_AUTORADIOBUTTON = 0x00000009,

			/// <summary>Specifies that the button displays a bitmap. See the Remarks section for its interaction with BS_ICON.</summary>
			BS_BITMAP = 0x00000080,

			/// <summary>Places text at the bottom of the button rectangle.</summary>
			BS_BOTTOM = 0x00000800,

			/// <summary>Centers text horizontally in the button rectangle.</summary>
			BS_CENTER = 0x00000300,

			/// <summary>
			/// Creates a small, empty check box with text. By default, the text is displayed to the right of the check box. To display the
			/// text to the left of the check box, combine this flag with the BS_LEFTTEXT style (or with the equivalent BS_RIGHTBUTTON style).
			/// </summary>
			BS_CHECKBOX = 0x00000002,

			/// <summary>
			/// Creates a command link button that behaves like a BS_PUSHBUTTON style button, but the command link button has a green arrow
			/// on the left pointing to the button text. A caption for the button text can be set by sending the BCM_SETNOTE message to the button.
			/// </summary>
			BS_COMMANDLINK = 0x0000000E,

			/// <summary>
			/// Creates a command link button that behaves like a BS_PUSHBUTTON style button. If the button is in a dialog box, the user can
			/// select the command link button by pressing the ENTER key, even when the command link button does not have the input focus.
			/// This style is useful for enabling the user to quickly select the most likely (default) option.
			/// </summary>
			BS_DEFCOMMANDLINK = 0x0000000F,

			/// <summary>
			/// Creates a push button that behaves like a BS_PUSHBUTTON style button, but has a distinct appearance. If the button is in a
			/// dialog box, the user can select the button by pressing the ENTER key, even when the button does not have the input focus.
			/// This style is useful for enabling the user to quickly select the most likely (default) option.
			/// </summary>
			BS_DEFPUSHBUTTON = 0x00000001,

			/// <summary>
			/// Creates a split button that behaves like a BS_PUSHBUTTON style button, but also has a distinctive appearance. If the split
			/// button is in a dialog box, the user can select the split button by pressing the ENTER key, even when the split button does
			/// not have the input focus. This style is useful for enabling the user to quickly select the most likely (default) option.
			/// </summary>
			BS_DEFSPLITBUTTON = 0x0000000D,

			/// <summary>
			/// Creates a rectangle in which other controls can be grouped. Any text associated with this style is displayed in the
			/// rectangle's upper left corner.
			/// </summary>
			BS_GROUPBOX = 0x00000007,

			/// <summary>Specifies that the button displays an icon. See the Remarks section for its interaction with BS_BITMAP.</summary>
			BS_ICON = 0x00000040,

			/// <summary>Specifies that the button is two-dimensional; it does not use the default shading to create a 3-D image.</summary>
			BS_FLAT = 0x00008000,

			/// <summary>
			/// Left-justifies the text in the button rectangle. However, if the button is a check box or radio button that does not have the
			/// BS_RIGHTBUTTON style, the text is left justified on the right side of the check box or radio button.
			/// </summary>
			BS_LEFT = 0x00000100,

			/// <summary>
			/// Places text on the left side of the radio button or check box when combined with a radio button or check box style. Same as
			/// the BS_RIGHTBUTTON style.
			/// </summary>
			BS_LEFTTEXT = 0x00000020,

			/// <summary>
			/// Wraps the button text to multiple lines if the text string is too long to fit on a single line in the button rectangle.
			/// </summary>
			BS_MULTILINE = 0x00002000,

			/// <summary>
			/// Enables a button to send BN_KILLFOCUS and BN_SETFOCUS notification codes to its parent window.
			/// <para>
			/// Note that buttons send the BN_CLICKED notification code regardless of whether it has this style. To get BN_DBLCLK
			/// notification codes, the button must have the BS_RADIOBUTTON or BS_OWNERDRAW style.
			/// </para>
			/// </summary>
			BS_NOTIFY = 0x00004000,

			/// <summary>
			/// Creates an owner-drawn button. The owner window receives a WM_DRAWITEM message when a visual aspect of the button has
			/// changed. Do not combine the BS_OWNERDRAW style with any other button styles.
			/// </summary>
			BS_OWNERDRAW = 0x0000000B,

			/// <summary>Creates a push button that posts a WM_COMMAND message to the owner window when the user selects the button.</summary>
			BS_PUSHBUTTON = 0x00000000,

			/// <summary>
			/// Makes a button (such as a check box, three-state check box, or radio button) look and act like a push button. The button
			/// looks raised when it isn't pushed or checked, and sunken when it is pushed or checked.
			/// </summary>
			BS_PUSHLIKE = 0x00001000,

			/// <summary>
			/// Creates a small circle with text. By default, the text is displayed to the right of the circle. To display the text to the
			/// left of the circle, combine this flag with the BS_LEFTTEXT style (or with the equivalent BS_RIGHTBUTTON style). Use radio
			/// buttons for groups of related, but mutually exclusive choices.
			/// </summary>
			BS_RADIOBUTTON = 0x00000004,

			/// <summary>
			/// Right-justifies text in the button rectangle. However, if the button is a check box or radio button that does not have the
			/// BS_RIGHTBUTTON style, the text is right justified on the right side of the check box or radio button.
			/// </summary>
			BS_RIGHT = 0x00000200,

			/// <summary>
			/// Positions a radio button's circle or a check box's square on the right side of the button rectangle. Same as the BS_LEFTTEXT style.
			/// </summary>
			BS_RIGHTBUTTON = BS_LEFTTEXT,

			/// <summary>Creates a split button. A split button has a drop down arrow.</summary>
			BS_SPLITBUTTON = 0x0000000C,

			/// <summary>Specifies that the button displays text.</summary>
			BS_TEXT = 0x00000000,

			/// <summary>Places text at the top of the button rectangle.</summary>
			BS_TOP = 0x00000400,

			/// <summary>
			/// Do not use this style. A composite style bit that results from using the OR operator on BS_* style bits. It can be used to
			/// mask out valid BS_* bits from a given bitmask. Note that this is out of date and does not correctly include all valid styles.
			/// Thus, you should not use this style.
			/// </summary>
			BS_TYPEMASK = 0x0000000F,

			/// <summary>
			/// Obsolete, but provided for compatibility with 16-bit versions of Windows. Applications should use BS_OWNERDRAW instead.
			/// </summary>
			BS_USERBUTTON = 0x00000008,

			/// <summary>Places text in the middle (vertically) of the button rectangle.</summary>
			BS_VCENTER = 0x00000C00,
		}

		/// <summary>
		/// <para>Changes the check state of a button control.</para>
		/// </summary>
		/// <param name="hDlg">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the dialog box that contains the button.</para>
		/// </param>
		/// <param name="nIDButton">
		/// <para>Type: <c>int</c></para>
		/// <para>The identifier of the button to modify.</para>
		/// </param>
		/// <param name="uCheck">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The check state of the button. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BST_CHECKED</term>
		/// <term>Sets the button state to checked.</term>
		/// </item>
		/// <item>
		/// <term>BST_INDETERMINATE</term>
		/// <term>
		/// Sets the button state to grayed, indicating an indeterminate state. Use this value only if the button has the BS_3STATE or
		/// BS_AUTO3STATE style.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BST_UNCHECKED</term>
		/// <term>Sets the button state to cleared</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CheckDlgButton</c> function sends a BM_SETCHECK message to the specified button control in the specified dialog box.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see <c>Creating a Modeless Dialog Box</c> in Using Dialog Boxes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-checkdlgbutton BOOL CheckDlgButton( HWND hDlg, int
		// nIDButton, UINT uCheck );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "checkdlgbutton")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckDlgButton(HandleRef hDlg, int nIDButton, ButtonStateFlags uCheck);

		/// <summary>
		/// <para>
		/// Adds a check mark to (checks) a specified radio button in a group and removes a check mark from (clears) all other radio buttons
		/// in the group.
		/// </para>
		/// </summary>
		/// <param name="hDlg">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the dialog box that contains the radio button.</para>
		/// </param>
		/// <param name="nIDFirstButton">
		/// <para>Type: <c>int</c></para>
		/// <para>The identifier of the first radio button in the group.</para>
		/// </param>
		/// <param name="nIDLastButton">
		/// <para>Type: <c>int</c></para>
		/// <para>The identifier of the last radio button in the group.</para>
		/// </param>
		/// <param name="nIDCheckButton">
		/// <para>Type: <c>int</c></para>
		/// <para>The identifier of the radio button to select.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CheckRadioButton</c> function sends a BM_SETCHECK message to each of the radio buttons in the indicated group.</para>
		/// <para>
		/// The nIDFirstButton and nIDLastButton parameters specify a range of button identifiers (normally the resource IDs of the buttons).
		/// The position of buttons in the tab order is irrelevant; if a button forms part of a group, but has an ID outside the specified
		/// range, it is not affected by this call.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-checkradiobutton BOOL CheckRadioButton( HWND hDlg, int
		// nIDFirstButton, int nIDLastButton, int nIDCheckButton );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "checkradiobutton")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckRadioButton(HandleRef hDlg, int nIDFirstButton, int nIDLastButton, int nIDCheckButton);

		/// <summary>
		/// <para>
		/// The <c>IsDlgButtonChecked</c> function determines whether a button control is checked or whether a three-state button control is
		/// checked, unchecked, or indeterminate.
		/// </para>
		/// </summary>
		/// <param name="hDlg">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the dialog box that contains the button control.</para>
		/// </param>
		/// <param name="nIDButton">
		/// <para>Type: <c>int</c></para>
		/// <para>The identifier of the button control.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The return value from a button created with the BS_AUTOCHECKBOX, BS_AUTORADIOBUTTON, BS_AUTO3STATE, BS_CHECKBOX, BS_RADIOBUTTON,
		/// or BS_3STATE styles can be one of the values in the following table. If the button has any other style, the return value is zero.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>BST_CHECKED</term>
		/// <term>The button is checked.</term>
		/// </item>
		/// <item>
		/// <term>BST_INDETERMINATE</term>
		/// <term>The button is in an indeterminate state (applies only if the button has the BS_3STATE or BS_AUTO3STATE style).</term>
		/// </item>
		/// <item>
		/// <term>BST_UNCHECKED</term>
		/// <term>The button is not checked.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>IsDlgButtonChecked</c> function sends a BM_GETCHECK message to the specified button control.</para>
		/// <para>Examples</para>
		/// <para>For an example, see the section titled "Creating a Modeless Dialog Box" in Using Dialog Boxes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isdlgbuttonchecked UINT IsDlgButtonChecked( HWND hDlg, int
		// nIDButton );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "isdlgbuttonchecked")]
		public static extern ButtonStateFlags IsDlgButtonChecked(HandleRef hDlg, int nIDButton);
	}
}