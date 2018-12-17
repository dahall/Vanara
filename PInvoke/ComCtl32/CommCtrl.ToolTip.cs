using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		public const int TTN_FIRST = -520;

		/// <summary>Specify the icon to be displayed.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760414")]
		public enum ToolTipIcon
		{
			/// <summary>No icon.</summary>
			TTI_NONE = 0,

			/// <summary>Info icon.</summary>
			TTI_INFO = 1,

			/// <summary>Warning icon</summary>
			TTI_WARNING = 2,

			/// <summary>Error Icon</summary>
			TTI_ERROR = 3,

			/// <summary>Large error Icon</summary>
			TTI_INFO_LARGE = 4,

			/// <summary>Large error Icon</summary>
			TTI_WARNING_LARGE = 5,

			/// <summary>Large error Icon</summary>
			TTI_ERROR_LARGE = 6,
		}

		/// <summary>Flags that control the tooltip display.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760256")]
		[Flags]
		public enum ToolTipInfoFlags : uint
		{
			/// <summary>Indicates that the uId member is the window handle to the tool. If this flag is not set, uId is the tool's identifier.</summary>
			TTF_IDISHWND = 0x0001,

			/// <summary>Centers the tooltip window below the tool specified by the uId member.</summary>
			TTF_CENTERTIP = 0x0002,

			/// <summary>Indicates that the tooltip text will be displayed in the opposite direction to the text in the parent window.</summary>
			TTF_RTLREADING = 0x0004,

			/// <summary>
			/// Indicates that the tooltip control should subclass the tool's window to intercept messages, such as WM_MOUSEMOVE. If this
			/// flag is not set, you must use the TTM_RELAYEVENT message to forward messages to the tooltip control. For a list of messages
			/// that a tooltip control processes, see TTM_RELAYEVENT.
			/// </summary>
			TTF_SUBCLASS = 0x0010,

			/// <summary>
			/// Positions the tooltip window next to the tool to which it corresponds and moves the window according to coordinates supplied
			/// by the TTM_TRACKPOSITION messages. You must activate this type of tool using the TTM_TRACKACTIVATE message.
			/// </summary>
			TTF_TRACK = 0x0020,

			/// <summary>
			/// Positions the tooltip window at the same coordinates provided by TTM_TRACKPOSITION. This flag must be used with the TTF_TRACK flag.
			/// </summary>
			TTF_ABSOLUTE = 0x0080,

			/// <summary>
			/// Causes the tooltip control to forward mouse event messages to the parent window. This is limited to mouse events that occur
			/// within the bounds of the tooltip window.
			/// </summary>
			TTF_TRANSPARENT = 0x0100,

			/// <summary>
			/// Version 6.0 and later. Indicates that links in the tooltip text should be parsed.
			/// <para>
			/// Note that Comctl32.dll version 6 is not redistributable but it is included in Windows or later. To use Comctl32.dll version
			/// 6, specify it in a manifest. For more information on manifests, see Enabling Visual Styles.
			/// </para>
			/// </summary>
			TTF_PARSELINKS = 0x1000,

			/// <summary>The TTF di setitem</summary>
			TTF_DI_SETITEM = 0x8000, // valid only on the TTN_NEEDTEXT callback
		}

		[PInvokeData("Commctrl.h", MSDNShortId = "bb760542")]
		public enum ToolTipMessage
		{
			TTM_ACTIVATE = WindowMessage.WM_USER + 1,
			TTM_SETDELAYTIME = WindowMessage.WM_USER + 3,
			TTM_ADDTOOL = WindowMessage.WM_USER + 50,
			TTM_DELTOOL = WindowMessage.WM_USER + 51,
			TTM_NEWTOOLRECT = WindowMessage.WM_USER + 52,
			TTM_RELAYEVENT = WindowMessage.WM_USER + 7, // Win7: wParam = GetMessageExtraInfo() when relaying WM_MOUSEMOVE
			TTM_GETTOOLINFO = WindowMessage.WM_USER + 53,
			TTM_SETTOOLINFO = WindowMessage.WM_USER + 54,
			TTM_HITTEST = WindowMessage.WM_USER + 55,
			TTM_GETTEXT = WindowMessage.WM_USER + 56,
			TTM_UPDATETIPTEXT = WindowMessage.WM_USER + 57,
			TTM_GETTOOLCOUNT = WindowMessage.WM_USER + 13,
			TTM_ENUMTOOLS = WindowMessage.WM_USER + 58,
			TTM_GETCURRENTTOOL = WindowMessage.WM_USER + 59,
			TTM_WINDOWFROMPOINT = WindowMessage.WM_USER + 16,
			TTM_TRACKACTIVATE = WindowMessage.WM_USER + 17, // wParam = TRUE/FALSE start end  lparam = LPTOOLINFO
			TTM_TRACKPOSITION = WindowMessage.WM_USER + 18, // lParam = dwPos
			TTM_SETTIPBKCOLOR = WindowMessage.WM_USER + 19,
			TTM_SETTIPTEXTCOLOR = WindowMessage.WM_USER + 20,
			TTM_GETDELAYTIME = WindowMessage.WM_USER + 21,
			TTM_GETTIPBKCOLOR = WindowMessage.WM_USER + 22,
			TTM_GETTIPTEXTCOLOR = WindowMessage.WM_USER + 23,
			TTM_SETMAXTIPWIDTH = WindowMessage.WM_USER + 24,
			TTM_GETMAXTIPWIDTH = WindowMessage.WM_USER + 25,
			TTM_SETMARGIN = WindowMessage.WM_USER + 26, // lParam = lprc
			TTM_GETMARGIN = WindowMessage.WM_USER + 27, // lParam = lprc
			TTM_POP = WindowMessage.WM_USER + 28,
			TTM_UPDATE = WindowMessage.WM_USER + 29,
			TTM_GETBUBBLESIZE = WindowMessage.WM_USER + 30,
			TTM_ADJUSTRECT = WindowMessage.WM_USER + 31,
			TTM_SETTITLE = WindowMessage.WM_USER + 33, // wParam = TTI_*, lParam = wchar* szTitle
			TTM_POPUP = WindowMessage.WM_USER + 34,
			TTM_GETTITLE = WindowMessage.WM_USER + 35, // wParam = 0, lParam = TTGETTITLE*
			TTM_SETWINDOWTHEME = CommonControlMessage.CCM_SETWINDOWTHEME
		}

		[PInvokeData("Commctrl.h", MSDNShortId = "ff486070")]
		public enum ToolTipNotification
		{
			/// <summary>
			/// Sent by a tooltip control to retrieve information needed to display a tooltip window. This notification code is sent in the
			/// form of a WM_NOTIFY message.
			/// </summary>
			TTN_GETDISPINFO = TTN_FIRST - 10,

			/// <summary>
			/// Notifies the owner window that a tooltip control is about to be displayed. This notification code is sent in the form of a
			/// WM_NOTIFY message.
			/// </summary>
			TTN_SHOW = TTN_FIRST - 1,

			/// <summary>
			/// Notifies the owner window that a tooltip is about to be hidden. This notification code is sent in the form of a WM_NOTIFY message.
			/// </summary>
			TTN_POP = TTN_FIRST - 2,

			/// <summary>
			/// Sent when a text link inside a balloon tooltip is clicked. This notification code is sent in the form of a WM_NOTIFY message.
			/// </summary>
			TTN_LINKCLICK = TTN_FIRST - 3,

			/// <summary>
			/// Sent by a tooltip control to retrieve information needed to display a tooltip window. This notification code is identical to
			/// TTN_GETDISPINFO. This notification code is sent in the form of a WM_NOTIFY message.
			/// </summary>
			TTN_NEEDTEXT = TTN_GETDISPINFO,
		}

		/// <summary>
		/// Contains information used in handling the TTN_GETDISPINFO notification code. This structure supersedes the TOOLTIPTEXT structure.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760258")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NMTTDISPINFO
		{
			/// <summary>NMHDR structure that contains additional information about the notification.</summary>
			public NMHDR hdr;

			/// <summary>
			/// Pointer to a null-terminated string that will be displayed as the tooltip text. If hinst specifies an instance handle, this
			/// member must be the identifier of a string resource.
			/// </summary>
			public string lpszText;

			/// <summary>
			/// Buffer that receives the tooltip text. An application can copy the text to this buffer instead of specifying a string address
			/// or string resource. For tooltip text that exceeds 80 TCHARs, see comments in the remarks section of this document.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr, SizeConst = 80)]
			public string szText;

			/// <summary>
			/// Handle to the instance that contains a string resource to be used as the tooltip text. If lpszText is the address of the
			/// tooltip text string, this member must be NULL.
			/// </summary>
			public HINSTANCE hinst;

			/// <summary>
			/// Flags that indicates how to interpret the idFrom member of the included NMHDR structure.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TTF_IDISHWND</term>
			/// <description>If this flag is set, idFrom is the tool's handle. Otherwise, it is the tool's identifier.</description>
			/// </item>
			/// <item>
			/// <term>TTF_RTLREADING</term>
			/// <description>
			/// Windows can be mirrored to display languages such as Hebrew or Arabic that read right-to-left (RTL). Normally, tooltip text
			/// is read in same direction as the text in its parent window. To have a tooltip read in the opposite direction from its parent
			/// window, add the TTF_RTLREADING flag to the uFlags member when processing the notification.
			/// </description>
			/// </item>
			/// <item>
			/// <term>TTF_DI_SETITEM</term>
			/// <description>
			/// Version 4.70. If you add this flag to uFlags while processing the notification, the tooltip control will retain the supplied
			/// information and not request it again.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			public ToolTipInfoFlags uFlags;

			/// <summary>Version 4.70. Application-defined data associated with the tool.</summary>
			public IntPtr lParam;
		}

		/// <summary>The TOOLINFO structure contains information about a tool in a tooltip control.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760256")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TOOLINFO
		{
			/// <summary>Size of this structure, in bytes. This member must be specified.</summary>
			public uint cbSize;

			/// <summary>Flags that control the tooltip display. This member can be a combination of the following values:</summary>
			public ToolTipInfoFlags uFlags;

			/// <summary>
			/// Handle to the window that contains the tool. If lpszText includes the LPSTR_TEXTCALLBACK value, this member identifies the
			/// window that receives the TTN_GETDISPINFO notification codes.
			/// </summary>
			public HWND hwnd;

			/// <summary>
			/// Application-defined identifier of the tool. If uFlags includes the TTF_IDISHWND flag, uId must specify the window handle to
			/// the tool.
			/// </summary>
			public IntPtr uId;

			/// <summary>
			/// The bounding rectangle coordinates of the tool. The coordinates are relative to the upper-left corner of the client area of
			/// the window identified by hwnd. If uFlags includes the TTF_IDISHWND flag, this member is ignored.
			/// </summary>
			public RECT rect;

			/// <summary>
			/// Handle to the instance that contains the string resource for the tool. If lpszText specifies the identifier of a string
			/// resource, this member is used.
			/// </summary>
			public HINSTANCE hinst;

			/// <summary>
			/// Pointer to the buffer that contains the text for the tool, or identifier of the string resource that contains the text. This
			/// member is sometimes used to return values. If you need to examine the returned value, must point to a valid buffer of
			/// sufficient size. Otherwise, it can be set to NULL. If lpszText is set to LPSTR_TEXTCALLBACK, the control sends the
			/// TTN_GETDISPINFO notification code to the owner window to retrieve the text.
			/// </summary>
			public StrPtrAuto lpszText;

			/// <summary>Version 4.70 and later. A 32-bit application-defined value that is associated with the tool.</summary>
			public IntPtr lParam;

			/// <summary>Reserved. Must be set to NULL.</summary>
			public IntPtr lpReserved;
		}

		/// <summary>Provides information about the title of a tooltip control.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760260")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TTGETTITLE
		{
			/// <summary>DWORD that specifies size of structure. Set to sizeof(TTGETTITLE).</summary>
			public uint dwSize;

			/// <summary>UINT that specifies the tooltip icon.</summary>
			public ToolTipIcon uTitleBitmap;

			/// <summary>UINT that specifies the number of characters in the title.</summary>
			public uint cch;

			/// <summary>Pointer to a wide character string that contains the title.</summary>
			public StrPtrUni pszTitle;
		}

		/// <summary>
		/// Contains information that a tooltip control uses to determine whether a point is in the bounding rectangle of the specified tool.
		/// If the point is in the rectangle, the structure receives information about the tool.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760262")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TTHITTESTINFO
		{
			/// <summary>Handle to the tool or window with the specified tool.</summary>
			public HWND hwnd;

			/// <summary>Client coordinates of the point to test.</summary>
			public Point pt;

			/// <summary>
			/// TOOLINFO structure. If the point specified by pt is in the tool specified by hwnd, this structure receives information about
			/// the tool. The cbSize member of this structure must be filled in before sending this message.
			/// </summary>
			public TOOLINFO ti;
		}
	}
}