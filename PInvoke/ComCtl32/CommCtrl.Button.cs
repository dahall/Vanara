using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>Used in the <see cref="BUTTON_IMAGELIST"/> structure himl member to indicate that no glyph should be displayed.</summary>
		public static IntPtr BCCL_NOGLYPH = new IntPtr(-1);

		private const int BCM_FIRST = 0x1600;
		private const int BCN_FIRST = -1250;

		/// <summary>Used by the <see cref="BUTTON_IMAGELIST.uAlign"/> member to specify alignment.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775953")]
		public enum ButtonImageListAlign
		{
			/// <summary>Align the image with the left margin.</summary>
			BUTTON_IMAGELIST_ALIGN_LEFT = 0,
			/// <summary>Align the image with the right margin.</summary>
			BUTTON_IMAGELIST_ALIGN_RIGHT = 1,
			/// <summary>Align the image with the top margin.</summary>
			BUTTON_IMAGELIST_ALIGN_TOP = 2,
			/// <summary>Align the image with the bottom margin.</summary>
			BUTTON_IMAGELIST_ALIGN_BOTTOM = 3,
			/// <summary>Center the image.</summary>
			BUTTON_IMAGELIST_ALIGN_CENTER = 4  // Doesn't draw text
		}

		/// <summary>Message identifiers used with the SendMessage function.</summary>
		public enum ButtonMessage
		{
			/// <summary>Gets the check state of a radio button or check box. Return value is one of the <see cref="ButtonStateFlags"/> values.</summary>
			BM_GETCHECK = 0x00F0,
			/// <summary>Sets the check state of a radio button or check box. wParam is one of the <see cref="ButtonStateFlags"/> values.</summary>
			BM_SETCHECK = 0x00F1,
			/// <summary>Retrieves the state of a button or check box. Return value is one of the <see cref="ButtonStateFlags"/> values.</summary>
			BM_GETSTATE = 0x00F2,
			/// <summary>
			/// Sets the highlight state of a button. The highlight state indicates whether the button is highlighted as if the user had pushed it.
			/// </summary>
			BM_SETSTATE = 0x00F3,
			/// <summary>Sets the style of a button.</summary>
			BM_SETSTYLE = 0x00F4,
			/// <summary>
			/// Simulates the user clicking a button. This message causes the button to receive the WM_LBUTTONDOWN and WM_LBUTTONUP messages, and the button's
			/// parent window to receive a BN_CLICKED notification code.
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

		public enum ButtonNotification
		{
			BN_CLICKED        = 0,
			BN_PAINT          = 1,
			BN_HILITE         = 2,
			BN_UNHILITE       = 3,
			BN_DISABLE        = 4,
			BN_DOUBLECLICKED  = 5,
			BN_PUSHED         = BN_HILITE,
			BN_UNPUSHED       = BN_UNHILITE,
			BN_DBLCLK         = BN_DOUBLECLICKED,
			BN_SETFOCUS       = 6,
			BN_KILLFOCUS      = 7,
			BCN_HOTITEMCHANGE = BCN_FIRST + 0x0001,
			BCN_DROPDOWN = BCN_FIRST + 0x0002,
			/// <summary>Sent by a button control to its parent to get measurements for the two rectangles of the split button. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item><term>lParam</term><description>A pointer to an NMCUSTOMSPLITRECTINFO to receive bounding rectangles information. The NMCUSTOMSPLITRECTINFO structure is sent with the notification code as a request for the parent to provide measurements for the rectangles of the split button.</description></item>
			/// <item><term>Return value</term><description>Return CDRF_SKIPDEFAULT to tell the button control to use the values returned in the NMCUSTOMSPLITRECTINFO structure; otherwise, return CDRF_DODEFAULT.</description></item>
			/// </list></summary>
			NM_GETCUSTOMSPLITRECT = BCN_FIRST + 0x0003,
		}

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
			/// <summary><c>Windows Vista.</c> The button is in the drop-down state. Applies only if the button has the TBSTYLE_DROPDOWN style.</summary>
			BST_DROPDOWNPUSHED = 0x0400
		}

		public enum ButtonStyle
		{
			BS_SPLITBUTTON = 0x0000000C,
			BS_DEFSPLITBUTTON = 0x0000000D,
			BS_COMMANDLINK = 0x0000000E,
			BS_DEFCOMMANDLINK = 0x0000000F,
		}

		/// <summary>A set of flags that specify which members of <see cref="BUTTON_SPLITINFO"/> contain data to be set or which members are being requested.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775955")]
		[Flags]
		public enum SplitButtonInfoMask
		{
			/// <summary>himlGlyph is valid.</summary>
			BCSIF_GLYPH = 0x1,
			/// <summary>himlGlyph is valid. Use when uSplitStyle is set to BCSS_IMAGE.</summary>
			BCSIF_IMAGE = 0x2,
			/// <summary>uSplitStyle is valid.</summary>
			BCSIF_STYLE = 0x4,
			/// <summary>size is valid.</summary>
			BCSIF_SIZE = 0x8
		}

		/// <summary>The split button style for the uSplitStyle member of <see cref="BUTTON_SPLITINFO"/>.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775955")]
		[Flags]
		public enum SplitButtonInfoStyle
		{
			/// <summary>No split.</summary>
			BCSS_NOSPLIT = 0x1,
			/// <summary>Stretch glyph, but try to retain aspect ratio.</summary>
			BCSS_STRETCH = 0x2,
			/// <summary>Align the image or glyph horizontally with the left margin.</summary>
			BCSS_ALIGNLEFT = 0x4,
			/// <summary>Draw an icon image as the glyph.</summary>
			BCSS_IMAGE = 0x8
		}

		/// <summary>Contains information about an image list that is used with a button control.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775953")]
		[StructLayout(LayoutKind.Sequential)]
		public struct BUTTON_IMAGELIST
		{
			/// <summary>
			/// A handle to the image list. The provider retains ownership of the image list and is ultimately responsible for its disposal. Under Windows Vista,
			/// you can pass BCCL_NOGLYPH in this parameter to indicate that no glyph should be displayed.
			/// </summary>
			public IntPtr himl;
			/// <summary>A RECT that specifies the margin around the icon.</summary>
			public RECT margin;
			/// <summary>A UINT that specifies the alignment to use.</summary>
			public ButtonImageListAlign uAlign;
		}

		/// <summary>
		/// Contains information that defines a split button (BS_SPLITBUTTON and BS_DEFSPLITBUTTON styles). Used with the BCM_GETSPLITINFO and BCM_SETSPLITINFO messages.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775955")]
		[StructLayout(LayoutKind.Sequential)]
		public struct BUTTON_SPLITINFO
		{
			/// <summary>A set of flags that specify which members of this structure contain data to be set or which members are being requested.</summary>
			public SplitButtonInfoMask mask;
			/// <summary>A handle to the image list. The provider retains ownership of the image list and is ultimately responsible for its disposal.</summary>
			public IntPtr himlGlyph;
			/// <summary>The split button style.</summary>
			public SplitButtonInfoStyle uSplitButtonInfoStyle;
			/// <summary>A SIZE structure that specifies the size of the glyph in himlGlyph.</summary>
			public Size size;

			/// <summary>Initializes a new instance of the <see cref="BUTTON_SPLITINFO"/> struct and sets the uSplitStyle value.</summary>
			/// <param name="buttonInfoStyle">The style.</param>
			public BUTTON_SPLITINFO(SplitButtonInfoStyle buttonInfoStyle) : this() { uSplitButtonInfoStyle = buttonInfoStyle; mask = SplitButtonInfoMask.BCSIF_STYLE; }

			/// <summary>Initializes a new instance of the <see cref="BUTTON_SPLITINFO"/> struct and sets an ImageList</summary>
			/// <param name="hImageList">The h image list.</param>
			public BUTTON_SPLITINFO(HandleRef hImageList) : this() { himlGlyph = hImageList.Handle != IntPtr.Zero ? hImageList.Handle : IntPtr.Zero; mask = SplitButtonInfoMask.BCSIF_IMAGE; }
		}

		/// <summary>Contains information about a BCN_DROPDOWN notification.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775957")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMBCDROPDOWN
		{
			/// <summary>An NMHDR structure containing information about the notification.</summary>
			public NMHDR hdr;
			/// <summary>A RECT structure that contains the client area of the button.</summary>
			public RECT rcButton;
		}

		/// <summary>Contains information about the movement of the mouse over a button control.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775959")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMBCHOTITEM
		{
			/// <summary>An NMHDR structure.</summary>
			public NMHDR hdr;
			/// <summary>The action of the mouse. This parameter can be one of the following values combined with HICF_MOUSE.</summary>
			public HotItemChangeFlags dwFlags;
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
		/// <param name="splitInfo">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Unicode, SetLastError = false)]
		public static extern IntPtr SendMessage(HandleRef hWnd, ButtonMessage Msg, int wParam, ref BUTTON_SPLITINFO splitInfo);

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
		/// <param name="imageList">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Unicode, SetLastError = false)]
		public static extern IntPtr SendMessage(HandleRef hWnd, ButtonMessage Msg, int wParam, ref BUTTON_IMAGELIST imageList);
	}
}