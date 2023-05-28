using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary/>
	public const int INVALID_LINK_INDEX = -1;

	/// <summary>The window class name for SysLink controls.</summary>
	[PInvokeData("commctrl.h")]
	public const string WC_LINK = "SysLink";

	private const int L_MAX_URL_LENGTH = 2048 + 32 + 4 /*sizeof("://")*/;
	private const int MAX_LINKID_TEXT = 48;

	/// <summary>The information to set or retrieve in <see cref="LITEM"/>.</summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLITEM")]
	[Flags]
	public enum LIF : uint
	{
		/// <summary>
		/// Retrieve the numeric item index. Items are always accessed by index, therefore you must always set this flag and assign a value
		/// to <c>iLink</c>. To obtain the item ID you must set both LIF_ITEMINDEX and LIF_ITEMID.
		/// </summary>
		LIF_ITEMINDEX = 0x00000001,

		/// <summary>Use <c>stateMask</c> to get or set the state of the link.</summary>
		LIF_STATE = 0x00000002,

		/// <summary>Specify the item by the ID value given in <c>szID</c>.</summary>
		LIF_ITEMID = 0x00000004,

		/// <summary>Set or get the URL for this item.</summary>
		LIF_URL = 0x00000008,
	}

	/// <summary>The state of the item in <see cref="LITEM"/>.</summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLITEM")]
	[Flags]
	public enum LIS : uint
	{
		/// <summary>The link has the keyboard focus. Pressing ENTER sends an NM_CLICK notification.</summary>
		LIS_FOCUSED = 0x00000001,

		/// <summary>
		/// The link can respond to user input. This is the default unless the entire control was created with WS_DISABLED. In this case, all
		/// links are disabled.
		/// </summary>
		LIS_ENABLED = 0x00000002,

		/// <summary>The link has been visited by the user. Changing the URL to one that has not been visited causes this flag to be cleared.</summary>
		LIS_VISITED = 0x00000004,

		/// <summary>
		/// Indicates that the syslink control will highlight in a different color (COLOR_HIGHLIGHT) when the mouse hovers over the control.
		/// </summary>
		LIS_HOTTRACK = 0x00000008,

		/// <summary>Enable custom text colors to be used.</summary>
		LIS_DEFAULTCOLORS = 0x00000010,
	}

	/// <summary>The following style constants are used when creating SysLink controls.</summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:syslink-control-style")]
	public enum LWS : uint
	{
		/// <summary>The background mix mode is transparent.</summary>
		LWS_TRANSPARENT = 0x0001,

		/// <summary>
		/// When the link has keyboard focus and the user presses Enter, the keystroke is ignored by the control and passed to the host
		/// dialog box.
		/// </summary>
		LWS_IGNORERETURN = 0x0002,

		/// <summary>
		/// Windows Vista. If the text contains an ampersand, it is treated as a literal character rather than the prefix to a shortcut key.
		/// </summary>
		LWS_NOPREFIX = 0x0004,

		/// <summary>Windows Vista. The link is displayed in the current visual style.</summary>
		LWS_USEVISUALSTYLE = 0x0008,

		/// <summary>
		/// Windows Vista. An NM_CUSTOMTEXT notification is sent when the control is drawn, so that the application can supply text dynamically.
		/// </summary>
		LWS_USECUSTOMTEXT = 0x0010,

		/// <summary>Windows Vista. The text is right-justified.</summary>
		LWS_RIGHT = 0x0020,
	}

	/// <summary>SysLink Control Messages.</summary>
	[PInvokeData("commctrl.h")]
	public enum SysLinkMessage : uint
	{
		/// <summary>Determines whether the user clicked the specified link.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a</para>
		/// <para>**LHITTESTINFO**</para>
		/// <para>structure to be filled with information about the link the user clicked, if any exists.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if user clicked on a link, otherwise returns <c>FALSE</c>.</para>
		/// <remarks>
		/// <para>
		/// If the <c>LM_HITTEST</c> message succeeds, the system fills in <c>LITEM.iLink</c> and <c>LITEM.szID</c>. If the <c>LM_HITTEST</c>
		/// message fails, do not assume that any information in <c>LITEM</c> is valid.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this API, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see Enabling
		/// Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lm-hittest
		[MsgParams(null, typeof(LHITTESTINFO?), LResultType = typeof(BOOL))]
		LM_HITTEST = WM_USER + 0x300,  // wParam: n/a, lparam: PLHITTESTINFO, ret: BOOL

		/// <summary>Retrieves the preferred height of a link for the control's current width.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Integer representing the preferred height of the link text, in pixels.</para>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lm-getidealheight
		[MsgParams()]
		LM_GETIDEALHEIGHT = WM_USER + 0x301,  // wParam: cxMaxWidth, lparam: n/a, ret: cy

		/// <summary>Sets the states and attributes of an item.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a</para>
		/// <para>LITEM</para>
		/// <para>structure containing the new states and attributes desired for the link.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if the message succeeds in setting the values and attributes specified.</para>
		/// <remarks>
		/// <para>
		/// With the <c>LM_GETITEM</c> message, links can only be accessed through the numeric index returned in the <c>iLink</c> member of
		/// <c>LITEM</c>. Accessing the link through the ID name returned in <c>szID</c> is not supported.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comctl32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lm-setitem
		[MsgParams(null, typeof(LITEM?), LResultType = typeof(BOOL))]
		LM_SETITEM = WM_USER + 0x302,  // wParam: n/a, lparam: LITEM*, ret: BOOL

		/// <summary>Retrieves the states and attributes of an item.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a</para>
		/// <para>LITEM</para>
		/// <para>structure to be filled with information about the item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if the message succeeds in getting the values and attributes specified.</para>
		/// <remarks>
		/// <para>
		/// With the <c>LM_GETITEM</c> message, links can only be accessed through the numeric index returned in the <c>iLink</c> member of
		/// <c>LITEM</c>. Accessing the link through the ID name returned in <c>szID</c> is not supported.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/lm-getitem
		[MsgParams(null, typeof(LHITTESTINFO?), LResultType = typeof(BOOL))]
		LM_GETITEM = WM_USER + 0x303,  // wParam: n/a, lparam: LITEM*, ret: BOOL

		/// <summary>Retrieves the preferred height of a link for the control's current width.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Maximum width of the link, in pixels.</para>
		/// <para><em>lParam</em></para>
		/// <para>When this message returns, contains a pointer to a</para>
		/// <para>**SIZE**</para>
		/// <para>
		/// structure. The **cy** member of this structure indicates the ideal height of the control for the given width. It adjusts the
		/// **cx** member to the amount of space actually needed.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Integer that represents the preferred height of the link text, in pixels.</para>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this API, you must provide a manifest that specifies Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/lm-getidealsize
		[MsgParams(typeof(int), typeof(SIZE?), LResultType = typeof(int))]
		LM_GETIDEALSIZE = LM_GETIDEALHEIGHT  // wParam: cxMaxWidth, lparam: SIZE*, ret: cy
	}

	/// <summary>Used to get information about the link corresponding to a given location.</summary>
	/// <remarks>
	/// <para>To convert from screen coordinates to client coordinates, use ScreenToClient.</para>
	/// <para>
	/// <c>Note</c> Â Â If the LM_HITTEST message succeeds, the system fills in LITEM.iLink and <c>LITEM.szID</c>. If the <c>LM_HITTEST</c>
	/// message fails, do not assume that any information in <c>LITEM</c> is valid.
	/// </para>
	/// <para>Â</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-lhittestinfo typedef struct tagLHITTESTINFO { POINT pt; LITEM
	// item; } LHITTESTINFO, *PLHITTESTINFO;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLHITTESTINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LHITTESTINFO
	{
		/// <summary>
		/// <para>Type: <c>POINT</c></para>
		/// <para>Location for the hit-test, in client coordinates (not screen coordinates).</para>
		/// </summary>
		public POINT pt;

		/// <summary>
		/// <para>Type: <c>LITEM</c></para>
		/// <para>Receives information about the link corresponding to <c>pt</c>.</para>
		/// </summary>
		public LITEM item;
	}

	/// <summary>Used to set and retrieve information about a link item.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-litem typedef struct tagLITEM { UINT mask; int iLink; UINT
	// state; UINT stateMask; WCHAR szID[MAX_LINKID_TEXT]; WCHAR szUrl[L_MAX_URL_LENGTH]; } LITEM, *PLITEM;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLITEM")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LITEM
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Combination of one or more of the following flags, describing the information to set or retrieve:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c> LIF_ITEMINDEX</description>
		/// <description>
		/// Retrieve the numeric item index. Items are always accessed by index, therefore you must always set this flag and assign a value
		/// to <c>iLink</c>. To obtain the item ID you must set both LIF_ITEMINDEX and LIF_ITEMID.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c> LIF_STATE</description>
		/// <description>Use <c>stateMask</c> to get or set the state of the link.</description>
		/// </item>
		/// <item>
		/// <description><c></c> LIF_ITEMID</description>
		/// <description>Specify the item by the ID value given in <c>szID</c>.</description>
		/// </item>
		/// <item>
		/// <description><c></c> LIF_URL</description>
		/// <description>Set or get the URL for this item.</description>
		/// </item>
		/// </list>
		/// </summary>
		public LIF mask;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that contains the item index. This numeric index is used to access a SysLink control link.</para>
		/// </summary>
		public int iLink;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Combination of one or more of the following flags, describing the state of the item:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c> LIS_ENABLED</description>
		/// <description>
		/// The link can respond to user input. This is the default unless the entire control was created with WS_DISABLED. In this case, all
		/// links are disabled.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c> LIS_FOCUSED</description>
		/// <description>The link has the keyboard focus. Pressing ENTER sends an NM_CLICK notification.</description>
		/// </item>
		/// <item>
		/// <description><c></c> LIS_VISITED</description>
		/// <description>
		/// The link has been visited by the user. Changing the URL to one that has not been visited causes this flag to be cleared.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c> LIS_HOTTRACK</description>
		/// <description>
		/// Indicates that the syslink control will highlight in a different color (COLOR_HIGHLIGHT) when the mouse hovers over the control.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c> LIS_DEFAULTCOLORS</description>
		/// <description>Enable custom text colors to be used.</description>
		/// </item>
		/// </list>
		/// </summary>
		public LIS state;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Combination of flags describing which state item to get or set. Allowable items are identical to those allowed in <c>state</c>.</para>
		/// </summary>
		public LIS stateMask;

		/// <summary>
		/// <para>Type: <c>WCHAR[MAX_LINKID_TEXT]</c></para>
		/// <para>
		/// <c>WCHAR</c> string that contains the ID name. The maximum number of characters in the array is MAX_LINKID_TEXT. The ID name
		/// cannot be used to access a SysLink control link. You use the item index to access the item.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_LINKID_TEXT)]
		public string? szID;

		/// <summary>
		/// <para>Type: <c>WCHAR[L_MAX_URL_LENGTH]</c></para>
		/// <para><c>WCHAR</c> string that contains the URL represented by the link. The maximum number of characters in the array is L_MAX_URL_LENGTH.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = L_MAX_URL_LENGTH)]
		public string? szUrl;

		/// <summary>Initializes a new instance of the <see cref="LITEM"/> struct.</summary>
		/// <param name="index">The item index.</param>
		/// <param name="mask">The mask of items to retrieve or set.</param>
		public LITEM(int index, LIF mask = 0)
		{
			iLink = index;
			this.mask = mask | LIF.LIF_ITEMINDEX;
		}
	}

	/// <summary>The <c>NMLINK</c> Contains notification information. Send this structure with the NM_CLICK or NM_RETURN messages.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlink typedef struct tagNMLINK { NMHDR hdr; LITEM item; }
	// NMLINK, *PNMLINK;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLINK")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMLINK : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>LITEM</c></para>
		/// <para>LITEM structure that contains information about the link item.</para>
		/// </summary>
		public LITEM item;
	}
}