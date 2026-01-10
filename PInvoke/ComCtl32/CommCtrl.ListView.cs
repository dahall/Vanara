using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary>
	/// Specifies that the size of the column array and the array itself (puColumns) are obtained by sending a LVN_GETDISPINFO notification.
	/// </summary>
	public const int I_COLUMNSCALLBACK = -1;

	/// <summary>The listview control sends the parent an LVN_GETDISPINFO notification code to retrieve the index of the group.</summary>
	public const int I_GROUPIDCALLBACK = -1;

	/// <summary>The item does not belong to a group.</summary>
	public const int I_GROUPIDNONE = -2;

	/// <summary>Automatically sizes the column.</summary>
	public const int LVSCW_AUTOSIZE = -1;

	/// <summary>
	/// Automatically sizes the column to fit the header text. If you use this value with the last column, its width is set to fill the
	/// remaining width of the list-view control.
	/// </summary>
	public const int LVSCW_AUTOSIZE_USEHEADER = -2;

	private const uint LVM_FIRST = 0x1000;

	private const int LVN_FIRST = -100;

	/// <summary>
	/// The <c>LVGroupCompare</c> function is an application-defined callback function used with the LVM_INSERTGROUPSORTED and LVM_SORTGROUPS
	/// messages. It defines the ordering of the groups, based on the ID. The <c>LVGROUPCOMPARE</c> type defines a pointer to this callback
	/// function. <c>LVGroupCompare</c> is a placeholder for the application-defined function name.
	/// </summary>
	/// <param name="unnamedParam1">
	/// <para>Type: <c>INT</c></para>
	/// <para>The ID of the first group.</para>
	/// </param>
	/// <param name="unnamedParam2">
	/// <para>Type: <c>INT</c></para>
	/// <para>The ID of the second group.</para>
	/// </param>
	/// <param name="unnamedParam3">
	/// <para>Type: <c>VOID*</c></para>
	/// <para>
	/// A pointer to the application-defined information. This comes from the message that was called; for LVM_INSERTGROUPSORTED it is
	/// LVINSERTGROUPSORTED.pvData, and for LVM_SORTGROUPS it is the <c>plv</c> parameter.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>INT</c></para>
	/// <para>
	/// Returns a negative value if the data for <c>Group1_ID</c> is less than the data for <c>Group2_ID</c>, a positive value if it is
	/// greater, or zero if it is the same.
	/// </para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nc-commctrl-pfnlvgroupcompare PFNLVGROUPCOMPARE Pfnlvgroupcompare; int
	// Pfnlvgroupcompare( int unnamedParam1, int unnamedParam2, void *unnamedParam3 ) {...}
	[PInvokeData("commctrl.h", MSDNShortId = "NC:commctrl.PFNLVGROUPCOMPARE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate int LVGroupCompare(int unnamedParam1, int unnamedParam2, IntPtr unnamedParam3);

	/// <summary>Flags for <see cref="NMLVEMPTYMARKUP"/>.</summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLVEMPTYMARKUP")]
	public enum EMF
	{
		/// <summary>Render markup centered in the listview area.</summary>
		EMF_CENTERED = 0x00000001,
	}

	/// <summary>Values that specify alignment for LVM_ARRANGE.</summary>
	[PInvokeData("Commctrl.h")]
	public enum ListViewArrange
	{
		/// <summary>Aligns items according to the list-view control's current alignment styles (the default value).</summary>
		LVA_DEFAULT = 0x0000,

		/// <summary>Not implemented. Apply the LVS_ALIGNLEFT style instead.</summary>
		LVA_ALIGNLEFT = 0x0001,

		/// <summary>Not implemented. Apply the LVS_ALIGNTOP style instead.</summary>
		LVA_ALIGNTOP = 0x0002,

		/// <summary>Snaps all icons to the nearest grid position.</summary>
		LVA_SNAPTOGRID = 0x0005,
	}

	/// <summary>Flags for the <see cref="LVBKIMAGE.ulFlags"/> member.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774742")]
	[Flags]
	public enum ListViewBkImageFlag : uint
	{
		/// <summary>The list-view control has no background image.</summary>
		LVBKIF_SOURCE_NONE = 0X00000000,

		/// <summary>
		/// A background bitmap is supplied via the hbm member of LVBKIMAGE. If the message LVM_SETBKIMAGE succeeds, then the list-view takes
		/// ownership of the bitmap.
		/// </summary>
		LVBKIF_SOURCE_HBITMAP = 0X00000001,

		/// <summary>The pszImage member contains the URL of the background image.</summary>
		LVBKIF_SOURCE_URL = 0X00000002,

		/// <summary>You can use the LVBKIF_SOURCE_MASK value to mask off all but the source flags.</summary>
		LVBKIF_SOURCE_MASK = 0X00000003,

		/// <summary>The background image is displayed normally.</summary>
		LVBKIF_STYLE_NORMAL = 0X00000000,

		/// <summary>The background image will be tiled to fill the entire background of the control.</summary>
		LVBKIF_STYLE_TILE = 0X00000010,

		/// <summary>You can use the LVBKIF_STYLE_MASK value to mask off all but the style flags.</summary>
		LVBKIF_STYLE_MASK = 0X00000010,

		/// <summary>
		/// Specify the coordinates of the first tile. This flag is valid only if the LVBKIF_STYLE_TILE flag is also specified. If this flag
		/// is not specified, the first tile begins at the upper-left corner of the client area. If you use ComCtl32.dll Version 6.0 the
		/// xOffsetPercent and yOffsetPercent fields contain pixels, not percentage values, to specify the coordinates of the first tile.
		/// Comctl32.dll version 6 is not redistributable but it is included in Windows or later. Also, you must specify Comctl32.dll version
		/// 6 in a manifest. For more information on manifests, see Enabling Visual Styles.
		/// </summary>
		LVBKIF_FLAG_TILEOFFSET = 0X00000100,

		/// <summary>
		/// A watermark background bitmap is supplied via the hbm member of LVBKIMAGE. If the LVM_SETBKIMAGE message succeeds, then the
		/// list-view control takes ownership of the bitmap.
		/// </summary>
		LVBKIF_TYPE_WATERMARK = 0X10000000,

		/// <summary>
		/// Valid only when LVBKIF_TYPE_WATERMARK is also specified. This flag indicates the bitmap provided via LVBKIF_TYPE_WATERMARK
		/// contains a valid alpha channel.
		/// </summary>
		LVBKIF_FLAG_ALPHABLEND = 0X20000000,
	}

	/// <summary>Mask flags used by <see cref="LVCOLUMN.mask"/>.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	[Flags]
	public enum ListViewColumMask
	{
		/// <summary>The fmt member is valid.</summary>
		LVCF_FMT = 0X0001,

		/// <summary>The cx member is valid.</summary>
		LVCF_WIDTH = 0X0002,

		/// <summary>The pszText member is valid.</summary>
		LVCF_TEXT = 0X0004,

		/// <summary>The iSubItem member is valid.</summary>
		LVCF_SUBITEM = 0X0008,

		/// <summary>Version 4.70. The iImage member is valid.</summary>
		LVCF_IMAGE = 0X0010,

		/// <summary>Version 4.70. The iOrder member is valid</summary>
		LVCF_ORDER = 0X0020,

		/// <summary>Version 6.00 and Windows Vista.The cxMin member is valid.</summary>
		LVCF_MINWIDTH = 0X0040,

		/// <summary>Version 6.00 and Windows Vista.The cxDefault member is valid.</summary>
		LVCF_DEFAULTWIDTH = 0X0080,

		/// <summary>Version 6.00 and Windows Vista.The cxIdeal member is valid</summary>
		LVCF_IDEALWIDTH = 0X0100,
	}

	/// <summary>
	/// Alignment of the column header and the subitem text in the column. The alignment of the leftmost column is always LVCFMT_LEFT; it
	/// cannot be changed. This member can be a combination of the following values. Note that not all combinations are valid.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774743")]
	[Flags]
	public enum ListViewColumnFormat
	{
		/// <summary>Text is left-aligned.</summary>
		LVCFMT_LEFT = 0X0000,

		/// <summary>Text is right-aligned.</summary>
		LVCFMT_RIGHT = 0X0001,

		/// <summary>Text is centered.</summary>
		LVCFMT_CENTER = 0X0002,

		/// <summary>
		/// A bitmask used to select those bits of fmt that control field justification. To check the format of a column, use a logical "and"
		/// to combine LCFMT_JUSTIFYMASK with fmt. You can then use a switch statement to determine whether the LVCFMT_LEFT, LVCFMT_RIGHT, or
		/// LVCFMT_CENTER bits are set.
		/// </summary>
		LVCFMT_JUSTIFYMASK = 0X0003,

		/// <summary>Version 4.70. The item displays an image from an image list.</summary>
		LVCFMT_IMAGE = 0X0800,

		/// <summary>
		/// Version 4.70. The bitmap appears to the right of text. This does not affect an image from an image list assigned to the header item.
		/// </summary>
		LVCFMT_BITMAP_ON_RIGHT = 0X1000,

		/// <summary>Version 4.70. The header item contains an image in the image list.</summary>
		LVCFMT_COL_HAS_IMAGES = 0X8000,

		/// <summary>Version 6.00 and Windows Vista. Can't resize the column; same as HDF_FIXEDWIDTH.</summary>
		LVCFMT_FIXED_WIDTH = 0X00100,

		/// <summary>Version 6.00 and Windows Vista. If not set, CCM_DPISCALE will govern scaling up fixed width.</summary>
		LVCFMT_NO_DPI_SCALE = 0X40000,

		/// <summary>Version 6.00 and Windows Vista. Width will augment with the row height.</summary>
		LVCFMT_FIXED_RATIO = 0X80000,

		/// <summary>Forces the column to wrap to the top of the next list of columns.</summary>
		LVCFMT_LINE_BREAK = 0X100000,

		/// <summary>Fills the remainder of the tile area. Might have a title.</summary>
		LVCFMT_FILL = 0X200000,

		/// <summary>Allows the column to wrap within the remaining space in its list of columns.</summary>
		LVCFMT_WRAP = 0X400000,

		/// <summary>Removes the title from the subitem.</summary>
		LVCFMT_NO_TITLE = 0X800000,

		/// <summary>Equivalent to a combination of LVCFMT_LINE_BREAK and LVCFMT_FILL.</summary>
		LVCFMT_TILE_PLACEMENTMASK = LVCFMT_LINE_BREAK | LVCFMT_FILL,

		/// <summary>
		/// Version 6.00 and Windows Vista. Column is a split button (same as HDF_SPLITBUTTON). The header of the column displays a split
		/// button (same as HDF_SPLITBUTTON).
		/// </summary>
		LVCFMT_SPLITBUTTON = 0X1000000,
	}

	/// <summary>Flags used in the <see cref="LVFINDINFO.flags"/> member.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774745")]
	[Flags]
	public enum ListViewFindInfoFlag
	{
		/// <summary>Searches for a match between this structure's lParam member and the lParam member of an item's LVITEM structure.</summary>
		LVFI_PARAM = 0X0001,

		/// <summary>
		/// Searches based on the item text. Unless additional values are specified, the item text of the matching item must exactly match
		/// the string pointed to by the psz member. However, the search is case-insensitive.
		/// </summary>
		LVFI_STRING = 0X0002,

		/// <summary>Windows Vista and later. Equivalent to LVFI_PARTIAL.</summary>
		LVFI_SUBSTRING = 0X0004,

		/// <summary>Checks to see if the item text begins with the string pointed to by the psz member. This value implies use of LVFI_STRING.</summary>
		LVFI_PARTIAL = 0X0008,

		/// <summary>
		/// Continues the search at the beginning if no match is found. If this flag is used by itself, it is assumed that a string search is wanted.
		/// </summary>
		LVFI_WRAP = 0X0020,

		/// <summary>
		/// Finds the item nearest to the position specified in the pt member, in the direction specified by the vkDirection member. This
		/// flag is supported only by large icon and small icon modes. If LVFI_NEARESTXY is specified, all other flags are ignored.
		/// </summary>
		LVFI_NEARESTXY = 0X0040,
	}

	/// <summary>
	/// Indicates the alignment of the header or footer text for the group. It can have one or more of the following values. Use one of the
	/// header flags. Footer flags are optional.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	[Flags]
	public enum ListViewGroupAlignment
	{
		/// <summary>Header text is aligned at the left of the window.</summary>
		LVGA_HEADER_LEFT = 0x00000001,

		/// <summary>Header text is centered horizontally in the window.</summary>
		LVGA_HEADER_CENTER = 0x00000002,

		/// <summary>Header text is aligned at the right of the window.</summary>
		LVGA_HEADER_RIGHT = 0x00000004,  // Don't forget to validate exclusivity

		/// <summary>Footer text is aligned at the left of the window.</summary>
		LVGA_FOOTER_LEFT = 0x00000008,

		/// <summary>Footer text is centered horizontally in the window.</summary>
		LVGA_FOOTER_CENTER = 0x00000010,

		/// <summary>Footer text is aligned at the right of the window.</summary>
		LVGA_FOOTER_RIGHT = 0x00000020,  // Don't forget to validate exclusivity
	}

	/// <summary>Used to set and retrieve groups.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774769")]
	[Flags]
	public enum ListViewGroupMask : uint
	{
		/// <summary>No other items are valid.</summary>
		LVGF_NONE = 0x00000000,

		/// <summary>pszHeader and cchHeader members are valid.</summary>
		LVGF_HEADER = 0x00000001,

		/// <summary>pszFooter and cchFooter members are valid.</summary>
		LVGF_FOOTER = 0x00000002,

		/// <summary>state and stateMask members are valid.</summary>
		LVGF_STATE = 0x00000004,

		/// <summary>uAlign member is valid.</summary>
		LVGF_ALIGN = 0x00000008,

		/// <summary>iGroupId member is valid.</summary>
		LVGF_GROUPID = 0x00000010,

		/// <summary>Version 6.00 and later. The pszSubtitle member is valid.</summary>
		LVGF_SUBTITLE = 0x00000100,

		/// <summary>Version 6.00 and later. The pszTask member is valid.</summary>
		LVGF_TASK = 0x00000200,

		/// <summary>Version 6.00 and later. The pszDescriptionTop member is valid.</summary>
		LVGF_DESCRIPTIONTOP = 0x00000400,

		/// <summary>Version 6.00 and later. The pszDescriptionBottom member is valid.</summary>
		LVGF_DESCRIPTIONBOTTOM = 0x00000800,

		/// <summary>Version 6.00 and later. The iTitleImage member is valid.</summary>
		LVGF_TITLEIMAGE = 0x00001000,

		/// <summary>Version 6.00 and later. The iExtendedImage member is valid.</summary>
		LVGF_EXTENDEDIMAGE = 0x00002000,

		/// <summary>Version 6.00 and later. The cItems member is valid.</summary>
		LVGF_ITEMS = 0x00004000,

		/// <summary>Version 6.00 and later. The pszSubsetTitle member is valid.</summary>
		LVGF_SUBSET = 0x00008000,

		/// <summary>Version 6.00 and later. The cchSubsetTitle member is valid.</summary>
		LVGF_SUBSETITEMS = 0x00010000,
	}

	/// <summary>Flags that specify which members contain or are to receive valid data.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774752")]
	[Flags]
	public enum ListViewGroupMetricsMask
	{
		/// <summary>No members are valid.</summary>
		LVGMF_NONE = 0x00000000,

		/// <summary>The Left, Top, Right, and Bottom members are valid.</summary>
		LVGMF_BORDERSIZE = 0x00000001,

		/// <summary>Not implemented.</summary>
		LVGMF_BORDERCOLOR = 0x00000002,

		/// <summary>Not implemented.</summary>
		LVGMF_TEXTCOLOR = 0x00000004,
	}

	/// <summary>Value used in LVM_GETGROUPRECT lparam value to specify coordinates of the rectangle to get.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	public enum ListViewGroupRect
	{
		/// <summary>Coordinates of the entire expanded group.</summary>
		LVGGR_GROUP = 0,

		/// <summary>Coordinates of the header only (collapsed group).</summary>
		LVGGR_HEADER = 1,

		/// <summary>Coordinates of the label only.</summary>
		LVGGR_LABEL = 2,

		/// <summary>
		/// Coordinates of the subset link only (markup subset). A list-view control can limit the number of visible items displayed in each
		/// group. A link is presented to the user to allow the user to expand the group. This flag will return the bounding rectangle of the
		/// subset link if the group is a subset (group state of LVGS_SUBSETED, see structure LVGROUP, member state). This flag is provided
		/// so that accessibility applications can located the link.
		/// </summary>
		LVGGR_SUBSETLINK = 3,
	}

	/// <summary></summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	[Flags]
	public enum ListViewGroupState : uint
	{
		/// <summary>Groups are expanded, the group name is displayed, and all items in the group are displayed.</summary>
		LVGS_NORMAL = 0x00000000,

		/// <summary>The group is collapsed.</summary>
		LVGS_COLLAPSED = 0x00000001,

		/// <summary>The group is hidden.</summary>
		LVGS_HIDDEN = 0x00000002,

		/// <summary>Version 6.00 and later. The group does not display a header.</summary>
		LVGS_NOHEADER = 0x00000004,

		/// <summary>Version 6.00 and later. The group can be collapsed.</summary>
		LVGS_COLLAPSIBLE = 0x00000008,

		/// <summary>Version 6.00 and later. The group has keyboard focus.</summary>
		LVGS_FOCUSED = 0x00000010,

		/// <summary>Version 6.00 and later. The group is selected.</summary>
		LVGS_SELECTED = 0x00000020,

		/// <summary>Version 6.00 and later. The group displays only a portion of its items.</summary>
		LVGS_SUBSETED = 0x00000040,

		/// <summary>Version 6.00 and later. The subset link of the group has keyboard focus.</summary>
		LVGS_SUBSETLINKFOCUSED = 0x00000080,
	}

	/// <summary>The results of a hit test. This member can be one or more of the following values:</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774754")]
	[Flags]
	public enum ListViewHitTestFlag : uint
	{
		/// <summary>The position is inside the list-view control's client window, but it is not over a list item.</summary>
		LVHT_NOWHERE = 0X00000001,

		/// <summary>The position is over a list-view item's icon.</summary>
		LVHT_ONITEMICON = 0X00000002,

		/// <summary>The position is over a list-view item's text.</summary>
		LVHT_ONITEMLABEL = 0X00000004,

		/// <summary>The position is over the state image of a list-view item.</summary>
		LVHT_ONITEMSTATEICON = 0X00000008,

		/// <summary>The position is over a list-view item.</summary>
		LVHT_ONITEM = LVHT_ONITEMICON | LVHT_ONITEMLABEL | LVHT_ONITEMSTATEICON,

		/// <summary>The position is above the control's client area.</summary>
		LVHT_ABOVE = 0X00000008,

		/// <summary>The position is below the control's client area.</summary>
		LVHT_BELOW = 0X00000010,

		/// <summary>The position is to the right of the list-view control's client area.</summary>
		LVHT_TORIGHT = 0X00000020,

		/// <summary>The position is to the left of the list-view control's client area.</summary>
		LVHT_TOLEFT = 0X00000040,

		/// <summary>Windows Vista. The point is within the group header.</summary>
		LVHT_EX_GROUP_HEADER = 0X10000000,

		/// <summary>Windows Vista. The point is within the group footer.</summary>
		LVHT_EX_GROUP_FOOTER = 0X20000000,

		/// <summary>Windows Vista. The point is within the collapse/expand button of the group.</summary>
		LVHT_EX_GROUP_COLLAPSE = 0X40000000,

		/// <summary>Windows Vista. The point is within the area of the group where items are displayed.</summary>
		LVHT_EX_GROUP_BACKGROUND = 0X80000000,

		/// <summary>Windows Vista. The point is within the state icon of the group.</summary>
		LVHT_EX_GROUP_STATEICON = 0X01000000,

		/// <summary>Windows Vista. The point is within the subset link of the group.</summary>
		LVHT_EX_GROUP_SUBSETLINK = 0X02000000,

		/// <summary>
		/// Windows Vista. LVHT_EX_GROUP_BACKGROUND | LVHT_EX_GROUP_COLLAPSE | LVHT_EX_GROUP_FOOTER | LVHT_EX_GROUP_HEADER |
		/// LVHT_EX_GROUP_STATEICON | LVHT_EX_GROUP_SUBSETLINK.
		/// </summary>
		LVHT_EX_GROUP = LVHT_EX_GROUP_BACKGROUND | LVHT_EX_GROUP_COLLAPSE | LVHT_EX_GROUP_FOOTER | LVHT_EX_GROUP_HEADER | LVHT_EX_GROUP_STATEICON | LVHT_EX_GROUP_SUBSETLINK,

		/// <summary>Windows Vista. The point is within the icon or text content of the item and not on the background.</summary>
		LVHT_EX_ONCONTENTS = 0X04000000,

		/// <summary>Windows Vista. The point is within the footer of the list-view control.</summary>
		LVHT_EX_FOOTER = 0X08000000,
	}

	/// <summary>Type of image list.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	public enum ListViewImageList
	{
		/// <summary>Image list with large icons.</summary>
		LVSIL_NORMAL,

		/// <summary>Image list with small icons.</summary>
		LVSIL_SMALL,

		/// <summary>Image list with state images.</summary>
		LVSIL_STATE,

		/// <summary>Image list for group header.</summary>
		LVSIL_GROUPHEADER
	}

	/// <summary>Flag that specifies where the insertion point should appear.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774758")]
	public enum ListViewInsertMarkFlag
	{
		/// <summary>The insertion point appears before the item</summary>
		LVIM_BEFORE,

		/// <summary>The insertion point appears after the item</summary>
		LVIM_AFTER
	}

	/// <summary>
	/// Set of flags that specify which members of the <see cref="LVITEM"/> structure contain data to be set or which members are being
	/// requested. This member can have one or more of the following flags set:
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774760")]
	[Flags]
	public enum ListViewItemMask : uint
	{
		/// <summary>The pszText member is valid or must be set.</summary>
		LVIF_TEXT = 0x00000001,

		/// <summary>The iImage member is valid or must be set.</summary>
		LVIF_IMAGE = 0x00000002,

		/// <summary>The lParam member is valid or must be set.</summary>
		LVIF_PARAM = 0x00000004,

		/// <summary>The state member is valid or must be set.</summary>
		LVIF_STATE = 0x00000008,

		/// <summary>The iIndent member is valid or must be set.</summary>
		LVIF_INDENT = 0x00000010,

		/// <summary>
		/// The control will not generate LVN_GETDISPINFO to retrieve text information if it receives an LVM_GETITEM message. Instead, the
		/// pszText member will contain LPSTR_TEXTCALLBACK.
		/// </summary>
		LVIF_NORECOMPUTE = 0x00000800,

		/// <summary>
		/// The iGroupId member is valid or must be set. If this flag is not set when an LVM_INSERTITEM message is sent, the value of
		/// iGroupId is assumed to be I_GROUPIDCALLBACK.
		/// </summary>
		LVIF_GROUPID = 0x00000100,

		/// <summary>The cColumns member is valid or must be set.</summary>
		LVIF_COLUMNS = 0x00000200,

		/// <summary>
		/// Windows Vista and later. The piColFmt member is valid or must be set. If this flag is used, the cColumns member is valid or must
		/// be set.
		/// </summary>
		LVIF_COLFMT = 0x00010000,

		/// <summary>
		/// The operating system should store the requested list item information and not ask for it again. This flag is used only with the
		/// LVN_GETDISPINFO notification code.
		/// </summary>
		LVIF_DISETITEM = 0x1000,

		/// <summary>Complete mask.</summary>
		LVIF_ALL = 0x0001FFFF
	}

	/// <summary>Used by LVM_GETITEMINDEXRECT.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	public enum ListViewItemRect
	{
		/// <summary>Returns the bounding rectangle of the entire subitem, including the icon and label.</summary>
		LVIR_BOUNDS,

		/// <summary>Returns the bounding rectangle of the icon or small icon of the subitem.</summary>
		LVIR_ICON,

		/// <summary>Returns the bounding rectangle of the subitem text.</summary>
		LVIR_LABEL,

		/// <summary>Returns the union of the LVIR_ICON and LVIR_LABEL rectangles, but excludes columns in report view.</summary>
		LVIR_SELECTBOUNDS
	}

	/// <summary>
	/// An item's state value consists of the item's state, an optional overlay mask index, and an optional state image mask index. An item's
	/// state determines its appearance and functionality. The state can be zero or one or more of the following values:
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	[Flags]
	public enum ListViewItemState : uint
	{
		/// <summary>No flags set.</summary>
		LVIS_NONE = 0x0000,

		/// <summary>
		/// The item has the focus, so it is surrounded by a standard focus rectangle. Although more than one item may be selected, only one
		/// item can have the focus.
		/// </summary>
		LVIS_FOCUSED = 0x0001,

		/// <summary>
		/// The item is selected. The appearance of a selected item depends on whether it has the focus and also on the system colors used
		/// for selection.
		/// </summary>
		LVIS_SELECTED = 0x0002,

		/// <summary>The item is marked for a cut-and-paste operation.</summary>
		LVIS_CUT = 0x0004,

		/// <summary>The item is highlighted as a drag-and-drop target.</summary>
		LVIS_DROPHILITED = 0x0008,

		/// <summary>Undocumented.</summary>
		LVIS_GLOW = 0x0010,

		// ///
		// <summary>Not currently supported.</summary>
		// Activating = 0x0020,
		/// <summary>The item's overlay image index is retrieved by a mask.</summary>
		LVIS_OVERLAYMASK = 0x0F00,

		/// <summary>The item's state image index is retrieved by a mask.</summary>
		LVIS_STATEIMAGEMASK = 0xF000,

		/// <summary>All flags.</summary>
		LVIS_ALL = 0xFFFFFFFF
	}

	/// <summary>LVM_ Messages for SendMessage</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	public enum ListViewMessage : uint
	{
		/// <summary>
		/// Sets the UNICODE character format flag for the control. This message allows you to change the character set used by the control
		/// at run time rather than having to re-create the control. You can send this message explicitly or use the
		/// <c>ListView_SetUnicodeFormat</c> macro.
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
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setunicodeformat
		[MsgParams(typeof(CommonControlMessage), null, LResultType = typeof(CommonControlMessage))]
		LVM_SETUNICODEFORMAT = 0X2005,        // CCM_SETUNICODEFORMAT,

		/// <summary>
		/// Retrieves the UNICODE character format flag for the control. You can send this message explicitly or use the
		/// <c>ListView_GetUnicodeFormat</c> macro.
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
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getunicodeformat
		[MsgParams(null, null, LResultType = typeof(CommonControlMessage))]
		LVM_GETUNICODEFORMAT = 0X2006,        // CCM_GETUNICODEFORMAT,

		/// <summary>
		/// Gets the background color of a list-view control. You can send this message explicitly or by using the <c>ListView_GetBkColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the background color of the list-view control.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getbkcolor
		[MsgParams(null, null, LResultType = typeof(COLORREF))]
		LVM_GETBKCOLOR = LVM_FIRST + 0,

		/// <summary>
		/// Sets the background color of a list-view control. You can send this message explicitly or by using the <c>ListView_SetBkColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Background color to set or the CLR_NONE value for no background color. List-view controls with background colors redraw
		/// themselves significantly faster than those without background colors.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setbkcolor
		[MsgParams(typeof(COLORREF), null, LResultType = typeof(COLORREF))]
		LVM_SETBKCOLOR = LVM_FIRST + 1,

		/// <summary>
		/// Retrieves the handle to an image list used for drawing list-view items. You can send this message explicitly or by using the
		/// <c>ListView_GetImageList</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Image list to retrieve. This parameter can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVSIL_NORMAL</c></term>
		/// <term>Image list with large icons.</term>
		/// </item>
		/// <item>
		/// <term><c>LVSIL_SMALL</c></term>
		/// <term>Image list with small icons.</term>
		/// </item>
		/// <item>
		/// <term><c>LVSIL_STATE</c></term>
		/// <term>Image list with state images.</term>
		/// </item>
		/// <item>
		/// <term><c>LVSIL_GROUPHEADER</c></term>
		/// <term>Image list for group header.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the specified image list if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getimagelist
		[MsgParams(typeof(ListViewImageList), null, LResultType = typeof(HIMAGELIST))]
		LVM_GETIMAGELIST = LVM_FIRST + 2,

		/// <summary>
		/// Assigns an image list to a list-view control. You can send this message explicitly or by using the <c>ListView_SetImageList</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Type of image list. This parameter can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVSIL_NORMAL</c></term>
		/// <term>Image list with large icons.</term>
		/// </item>
		/// <item>
		/// <term><c>LVSIL_SMALL</c></term>
		/// <term>Image list with small icons.</term>
		/// </item>
		/// <item>
		/// <term><c>LVSIL_STATE</c></term>
		/// <term>Image list with state images.</term>
		/// </item>
		/// <item>
		/// <term><c>LVSIL_GROUPHEADER</c></term>
		/// <term>Image list for group header.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the image list to assign.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the image list previously associated with the control if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The current image list will be destroyed when the list-view control is destroyed unless the <c>LVS_SHAREIMAGELISTS</c> style is
		/// set. If you use this message to replace one image list with another, your application must explicitly destroy all image lists
		/// other than the current one.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setimagelist
		[MsgParams(typeof(ListViewImageList), typeof(HIMAGELIST), LResultType = typeof(HIMAGELIST))]
		LVM_SETIMAGELIST = LVM_FIRST + 3,

		/// <summary>
		/// Retrieves the number of items in a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_GetItemCount</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the number of items.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getitemcount
		[MsgParams()]
		LVM_GETITEMCOUNT = LVM_FIRST + 4,

		/// <summary>
		/// Retrieves some or all of a list-view item's attributes. You can send this message explicitly or by using the
		/// <c>ListView_GetItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>LVITEM</c> structure that specifies the information to retrieve and receives information about the list-view item.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the <c>LVM_GETITEM</c> message is sent, the <c>iItem</c> and <c>iSubItem</c> members identify the item or subitem to
		/// retrieve information about and the <c>mask</c> member specifies which attributes to retrieve. For a list of possible values, see
		/// the description of the <c>LVITEM</c> structure.
		/// </para>
		/// <para>
		/// If the LVIF_TEXT flag is set in the <c>mask</c> member of the <c>LVITEM</c> structure, the <c>pszText</c> member must point to a
		/// valid buffer and the <c>cchTextMax</c> member must be set to the number of characters in that buffer. Applications should not
		/// assume that the text will necessarily be placed in the specified buffer. The control may instead change the <c>pszText</c> member
		/// of the structure to point to the new text, rather than place it in the buffer.
		/// </para>
		/// <para>
		/// If the <c>mask</c> member specifies the LVIF_STATE value, the <c>stateMask</c> member must specify the item state bits to
		/// retrieve. On output, the <c>state</c> member contains the values of the specified state bits.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getitem
		[MsgParams(null, typeof(LVITEM), LResultType = typeof(BOOL))]
		LVM_GETITEM = LVM_FIRST + 75,

		/// <summary>
		/// Sets some or all of a list-view item's attributes. You can also send LVM_SETITEM to set the text of a subitem. You can send this
		/// message explicitly or by using the <c>ListView_SetItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>LVITEM</c> structure that contains the new item attributes. The <c>iItem</c> and <c>iSubItem</c> members
		/// identify the item or subitem, and the <c>mask</c> member specifies which attributes to set. If the <c>mask</c> member specifies
		/// the LVIF_TEXT value, the <c>pszText</c> member is the address of a null-terminated string and the <c>cchTextMax</c> member is
		/// ignored. If the <c>mask</c> member specifies the LVIF_STATE value, the <c>stateMask</c> member specifies which item states to
		/// change and the <c>state</c> member contains the values for those states.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To set the attributes of a list-view item, set the <c>iItem</c> member of the <c>LVITEM</c> structure to the index of the item,
		/// and set the <c>iSubItem</c> member to zero. For an item, you can set the <c>state</c>, <c>pszText</c>, <c>iImage</c>, and
		/// <c>lParam</c> members of the <c>LVITEM</c> structure.
		/// </para>
		/// <para>
		/// To set the text of a subitem, set the <c>iItem</c> and <c>iSubItem</c> members to indicate the specific subitem, and use the
		/// <c>pszText</c> member to specify the text. Alternatively, you can use the <c>ListView_SetItemText</c> macro to set the text of a
		/// subitem. You cannot set the <c>state</c> or <c>lParam</c> members for subitems because subitems do not have these attributes. In
		/// version 4.70 and later, you can set the <c>iImage</c> member for subitems. The subitem image will be displayed if the list-view
		/// control has the <c>LVS_EX_SUBITEMIMAGES</c> extended style. Previous versions will ignore the subitem image.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setitem
		[MsgParams(null, typeof(LVITEM), LResultType = typeof(BOOL))]
		LVM_SETITEM = LVM_FIRST + 76,

		/// <summary>
		/// Inserts a new item in a list-view control. You can send this message explicitly or by using the <c>ListView_InsertItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>LVITEM</c> structure that specifies the attributes of the list-view item. Use the <c>iItem</c> member to specify
		/// the zero-based index at which the new item should be inserted. If this value is greater than the number of items currently
		/// contained by the listview, the new item will be appended to the end of the list and assigned the correct index. Examine the
		/// message's return value to determine the actual index assigned to the item.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the new item if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You cannot use <c>ListView_InsertItem</c> or <c>LVM_INSERTITEM</c> to insert subitems. The <c>iSubItem</c> member of the
		/// <c>LVITEM</c> structure must be zero. See <c>LVM_SETITEM</c> for information on setting subitems.
		/// </para>
		/// <para>
		/// If a list-view control has the <c>LVS_EX_CHECKBOXES</c> style set, any value placed in bits 12 through 15 of the <c>state</c>
		/// member of the <c>LVITEM</c> structure will be ignored. When an item is added with this style set, it will always be set to the
		/// unchecked state.
		/// </para>
		/// <para>
		/// If a list-view control has either the <c>LVS_SORTASCENDING</c> or <c>LVS_SORTDESCENDING</c> window style, an
		/// <c>LVM_INSERTITEM</c> message will fail if you try to insert an item that has LPSTR_TEXTCALLBACK as the value for its
		/// <c>pszText</c> member.
		/// </para>
		/// <para>
		/// The <c>LVM_INSERTITEM</c> message will insert the new item in the proper position in the sort order if the following conditions hold:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>You are using one of the LVS_SORTXXX styles.</term>
		/// </item>
		/// <item>
		/// <term>You are not using the <c>LVS_OWNERDRAW</c> style.</term>
		/// </item>
		/// <item>
		/// <term>The <c>pszText</c> member of the structure pointed to by <c>pitem</c> is not set to LPSTR_TEXTCALLBACK.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the <c>LVITEM</c> structure does not contain LVIF_GROUPID in the <c>mask</c> member, the value of the <c>iGroupId</c> member
		/// is I_GROUPIDCALLBACK by default.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-insertitem
		[MsgParams(null, typeof(LVITEM))]
		LVM_INSERTITEM = LVM_FIRST + 77,

		/// <summary>
		/// Removes an item from a list-view control. You can send this message explicitly or by using the <c>ListView_DeleteItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the list-view item to delete.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-deleteitem
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		LVM_DELETEITEM = LVM_FIRST + 8,

		/// <summary>
		/// Removes all items from a list-view control. You can send this message explicitly or by using the <c>ListView_DeleteAllItems</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// When a list-view control receives the <c>LVM_DELETEALLITEMS</c> message, it sends the <c>LVN_DELETEALLITEMS</c> notification code
		/// to its parent window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-deleteallitems
		[MsgParams(LResultType = typeof(BOOL))]
		LVM_DELETEALLITEMS = LVM_FIRST + 9,

		/// <summary>
		/// Gets the callback mask for a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_GetCallbackMask</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the callback mask.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getcallbackmask
		[MsgParams(LResultType = typeof(ListViewItemState))]
		LVM_GETCALLBACKMASK = LVM_FIRST + 10,

		/// <summary>
		/// Changes the callback mask for a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_SetCallbackMask</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Value of the callback mask. The bits of the mask indicate the item states or images for which the application stores the current
		/// state data. This value can be any combination of the following constants:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVIS_CUT</c></term>
		/// <term>The item is marked for a cut-and-paste operation.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_DROPHILITED</c></term>
		/// <term>The item is highlighted as a drag-and-drop target.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_FOCUSED</c></term>
		/// <term>The item has the focus.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_SELECTED</c></term>
		/// <term>The item is selected.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_OVERLAYMASK</c></term>
		/// <term>The application stores the image list index of the current overlay image for each item.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_STATEIMAGEMASK</c></term>
		/// <term>The application stores the image list index of the current state image for each item.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The callback mask of a list-view control is a set of bit flags that specify the item states for which the application, rather
		/// than the control, stores the current data. The callback mask applies to all of the control's items, unlike the callback item
		/// designation, which applies to a specific item. The callback mask is zero by default, meaning that the list-view control stores
		/// all item state information. After creating a list-view control and initializing its items, you can send the
		/// <c>LVM_SETCALLBACKMASK</c> message to change the callback mask. To retrieve the current callback mask, send the
		/// <c>LVM_GETCALLBACKMASK</c> message.
		/// </para>
		/// <para>For more information about overlay images and state images, see Adding List-View Image Lists.</para>
		/// <para>For more information on list-view callbacks, see Callback Items and the Callback Mask.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setcallbackmask
		[MsgParams(typeof(ListViewItemState), null, LResultType = typeof(BOOL))]
		LVM_SETCALLBACKMASK = LVM_FIRST + 11,

		/// <summary>
		/// Searches for a list-view item that has the specified properties and bears the specified relationship to a specified item. You can
		/// send this message explicitly or by using the <c>ListView_GetNextItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Index of the item to begin the search with, or -1 to find the first item that matches the specified flags. The specified item
		/// itself is excluded from the search.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies the relationship to the item specified in wParam. This can be one or a combination of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Searches by index.</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term><c>LVNI_ALL</c></term>
		/// <term>Searches for a subsequent item by index, the default value.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_PREVIOUS</c></term>
		/// <term>
		/// <c>Windows Vista and later:</c> Searches for an item that is ordered before the item specified in <c>wParam</c>. The
		/// LVNI_PREVIOUS flag is not directional (LVNI_ABOVE will find the item positioned above, while LVNI_PREVIOUS will find the item
		/// ordered before.) The LVNI_PREVIOUS flag basically reverses the logic of the search performed by the <c>LVM_GETNEXTITEM</c> or
		/// <c>LVM_GETNEXTITEMINDEX</c> messages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Searches by physical relationship to the index of the item where the search is to begin.</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term><c>LVNI_ABOVE</c></term>
		/// <term>Searches for an item that is above the specified item.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_BELOW</c></term>
		/// <term>Searches for an item that is below the specified item.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_TOLEFT</c></term>
		/// <term>Searches for an item to the left of the specified item.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_TORIGHT</c></term>
		/// <term>Searches for an item to the right of the specified item.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_DIRECTIONMASK</c></term>
		/// <term>
		/// <c>Windows Vista and later:</c> A directional flag mask with value as follows: LVNI_ABOVE | LVNI_BELOW | LVNI_TOLEFT | LVNI_TORIGHT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The state of the item to find can be specified with one or a combination of the following values:</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term><c>LVNI_CUT</c></term>
		/// <term>The item has the <c>LVIS_CUT</c> state flag set.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_DROPHILITED</c></term>
		/// <term>The item has the <c>LVIS_DROPHILITED</c> state flag set</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_FOCUSED</c></term>
		/// <term>The item has the <c>LVIS_FOCUSED</c> state flag set.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_SELECTED</c></term>
		/// <term>The item has the <c>LVIS_SELECTED</c> state flag set.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_STATEMASK</c></term>
		/// <term><c>Windows Vista and later:</c> A state flag mask with value as follows: LVNI_FOCUSED | LVNI_SELECTED | LVNI_CUT | LVNI_DROPHILITED.</term>
		/// </item>
		/// <item>
		/// <term>Searches by appearance of items or by group</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term><c>LVNI_VISIBLEORDER</c></term>
		/// <term><c>Windows Vista and later:</c> Search the visible order.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_VISIBLEONLY</c></term>
		/// <term><c>Windows Vista and later:</c> Search the visible items.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_SAMEGROUPONLY</c></term>
		/// <term><c>Windows Vista and later:</c> Search the current group.</term>
		/// </item>
		/// <item>
		/// <term>If an item does not have all of the specified state flags set, the search continues with the next item.</term>
		/// <term/>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the next item if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// Note that the following flags, for use only with Windows Vista, are mutually exclusive of any other flags in use:
		/// LVNI_VISIBLEONLY, LVNI_SAMEGROUPONLY, LVNI_VISIBLEORDER, LVNI_DIRECTIONMASK, and LVNI_STATEMASK.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getnextitem
		[MsgParams(typeof(int), typeof(ListViewNextItemFlag))]
		LVM_GETNEXTITEM = LVM_FIRST + 12,

		/// <summary>
		/// Searches for a list-view item with the specified characteristics. You can send this message explicitly or by using the
		/// <c>ListView_FindItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The index of the item to begin the search with or -1 to start from the beginning. The specified item is itself excluded from the search.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to an <c>LVFINDINFO</c> structure that contains information about what to search for.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the item if successful, or -1 otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-finditem
		[MsgParams(typeof(int), typeof(LVFINDINFO?))]
		LVM_FINDITEM = LVM_FIRST + 83,

		/// <summary>
		/// Retrieves the bounding rectangle for all or part of an item in the current view. You can send this message explicitly or by using
		/// the <c>ListView_GetItemRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the list-view item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that receives the bounding rectangle. When the message is sent, the <c>left</c> member of this
		/// structure is used to specify the portion of the list-view item from which to retrieve the bounding rectangle. It must be set to
		/// one of the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVIR_BOUNDS</c></term>
		/// <term>Returns the bounding rectangle of the entire item, including the icon and label.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIR_ICON</c></term>
		/// <term>Returns the bounding rectangle of the icon or small icon.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIR_LABEL</c></term>
		/// <term>Returns the bounding rectangle of the item text.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIR_SELECTBOUNDS</c></term>
		/// <term>Returns the union of the LVIR_ICON and LVIR_LABEL rectangles, but excludes columns in report view.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getitemrect
		[MsgParams(typeof(int), typeof(RECT?), LResultType = typeof(BOOL))]
		LVM_GETITEMRECT = LVM_FIRST + 14,

		/// <summary>
		/// Moves an item to a specified position in a list-view control (must be in icon or small icon view). You can send this message
		/// explicitly or by using the <c>ListView_SetItemPosition</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the list-view item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the new x-position of the item's upper-left corner, in view coordinates. The <c>HIWORD</c> specifies
		/// the new y-position of the item's upper-left corner, in view coordinates.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the list-view control has the <c>LVS_AUTOARRANGE</c> style, the items in the list-view control are arranged after the position
		/// of the item is set.
		/// </para>
		/// <para>
		/// On Windows Vista, sending this message to a list-view control with the <c>LVS_AUTOARRANGE</c> style does nothing, and the return
		/// value is <c>FALSE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setitemposition
		[MsgParams(typeof(int), typeof(POINTS), LResultType = typeof(BOOL))]
		LVM_SETITEMPOSITION = LVM_FIRST + 15,

		/// <summary>
		/// Retrieves the position of a list-view item. You can send this message explicitly or by using the <c>ListView_GetItemPosition</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the list-view item.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>POINT</c> structure that receives the position of the item's upper-left corner, in view coordinates.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getitemposition
		[MsgParams(typeof(int), typeof(POINT?), LResultType = typeof(BOOL))]
		LVM_GETITEMPOSITION = LVM_FIRST + 16,

		/// <summary>
		/// Determines the width of a specified string using the specified list-view control's current font. You can send this message
		/// explicitly or by using the <c>ListView_GetStringWidth</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a null-terminated string.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the string width if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The LVM_GETSTRINGWIDTH message returns the exact width, in pixels, of the specified string. If you use the returned string width
		/// as the column width in the <c>LVM_SETCOLUMNWIDTH</c> message, the string will be truncated. To retrieve the column width that can
		/// contain the string without truncating it, you must add padding to the returned string width.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getstringwidth
		[MsgParams(null, typeof(StrPtrAuto))]
		LVM_GETSTRINGWIDTH = LVM_FIRST + 87,

		/// <summary>
		/// Determines which list-view item, if any, is at a specified position. You can send this message explicitly or by using the
		/// <c>ListView_HitTest</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Must be 0. **Windows Vista.** Should be -1 if the **iGroup** and **iSubItem** members of the *lParam* structure are to be retrieved.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>LVHITTESTINFO</c> structure that contains the position to hit test and receives information about the results of
		/// the hit test.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the item at the specified position, if any, or -1 otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-hittest
		[MsgParams(typeof(int), typeof(LVHITTESTINFO?))]
		LVM_HITTEST = LVM_FIRST + 18,

		/// <summary>
		/// Ensures that a list-view item is either entirely or partially visible, scrolling the list-view control if necessary. You can send
		/// this message explicitly or by using the <c>ListView_EnsureVisible</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the list-view item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A value specifying whether the item must be entirely visible. If this parameter is <c>TRUE</c>, no scrolling occurs if the item
		/// is at least partially visible.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>The message fails if the window style includes <c>LVS_NOSCROLL</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-ensurevisible
		[MsgParams(typeof(int), typeof(BOOL), LResultType = typeof(BOOL))]
		LVM_ENSUREVISIBLE = LVM_FIRST + 19,

		/// <summary>
		/// Scrolls the content of a list-view control. You can send this message explicitly or by using the <c>ListView_Scroll</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Value of type <c>int</c> that specifies the amount of horizontal scrolling, in pixels, relative to the current position of the
		/// list view content. If the list-view control is in list view, this value is rounded up to the nearest number of pixels that form a
		/// whole column.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Value of type <c>int</c> that specifies the amount of vertical scrolling, in pixels, relative to the current position of the list
		/// view content.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// When the list-view control is in report view, the control can only be scrolled vertically in whole line increments. Therefore,
		/// the lParam parameter will be rounded to the nearest number of pixels that form a whole line increment. For example, if the height
		/// of a line is 16 pixels and 8 is passed for lParam, the list will be scrolled by 16 pixels (1 line). If 7 is passed for lParam,
		/// the list will be scrolled 0 pixels (0 lines).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-scroll
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(BOOL))]
		LVM_SCROLL = LVM_FIRST + 20,

		/// <summary>
		/// Forces a list-view control to redraw a range of items. You can send this message explicitly or by using the
		/// <c>ListView_RedrawItems</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the first item to redraw.</para>
		/// <para><em>lParam</em></para>
		/// <para>Index of the last item to redraw.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The specified items are not actually redrawn until the list-view window receives a <c>WM_PAINT</c> message to repaint. To repaint
		/// immediately, call the <c>UpdateWindow</c> function after using this macro.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-redrawitems
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(BOOL))]
		LVM_REDRAWITEMS = LVM_FIRST + 21,

		/// <summary>
		/// Arranges items in icon view. You can send this message explicitly or by using the <c>ListView_Arrange</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>One of the following values that specifies alignment:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVA_ALIGNLEFT</c></term>
		/// <term>Not implemented. Apply the <c>LVS_ALIGNLEFT</c> style instead.</term>
		/// </item>
		/// <item>
		/// <term><c>LVA_ALIGNTOP</c></term>
		/// <term>Not implemented. Apply the <c>LVS_ALIGNTOP</c> style instead.</term>
		/// </item>
		/// <item>
		/// <term><c>LVA_DEFAULT</c></term>
		/// <term>Aligns items according to the list-view control's current alignment styles (the default value).</term>
		/// </item>
		/// <item>
		/// <term><c>LVA_SNAPTOGRID</c></term>
		/// <term>Snaps all icons to the nearest grid position.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-arrange
		[MsgParams(typeof(ListViewArrange), null, LResultType = typeof(BOOL))]
		LVM_ARRANGE = LVM_FIRST + 22,

		/// <summary>
		/// Begins in-place editing of the specified list-view item's text. The message implicitly selects and focuses the specified item.
		/// You can send this message explicitly or by using the <c>ListView_EditLabel</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the list-view item. To cancel editing, set the index to -1.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the edit control that is used to edit the item text if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the user completes or cancels editing, the edit control is destroyed and the handle is no longer valid. You can subclass the
		/// edit control, but you should not destroy it.
		/// </para>
		/// <para>
		/// The control must have the focus before you send this message to the control. Focus can be set using the <c>SetFocus</c> function.
		/// </para>
		/// <para>If wParam is -1, an LVN_ENDLABELEDIT notification code is sent.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-editlabel
		[MsgParams(typeof(int), null, LResultType = typeof(HWND))]
		LVM_EDITLABEL = LVM_FIRST + 118,

		/// <summary>
		/// Gets the handle to the edit control being used to edit a list-view item's text. You can send this message explicitly or by using
		/// the <c>ListView_GetEditControl</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the edit control if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When label editing begins, an edit control is created, positioned, and initialized. Before it is displayed, the list-view control
		/// sends its parent window an LVN_BEGINLABELEDIT notification code.
		/// </para>
		/// <para>
		/// To customize label editing, implement a handler for LVN_BEGINLABELEDIT and have it send an <c>LVM_GETEDITCONTROL</c> message to
		/// the list-view control. If a label is being edited, the return value will be a handle to the edit control. Use this handle to
		/// customize the edit control by sending the usual <c>EM_XXX</c> messages.
		/// </para>
		/// <para>
		/// When the user completes or cancels editing, the edit control is destroyed and the handle is no longer valid. You can subclass the
		/// edit control, but you should not destroy it. To cancel editing, send the list-view control a <c>WM_CANCELMODE</c> message.
		/// </para>
		/// <para>
		/// The list-view item being edited is the currently focused item that is, the item in the focused state. To find an item based on
		/// its state, use the <c>LVM_GETNEXTITEM</c> message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-geteditcontrol
		[MsgParams(LResultType = typeof(HWND))]
		LVM_GETEDITCONTROL = LVM_FIRST + 24,

		/// <summary>
		/// Gets the attributes of a list-view control's column. You can send this message explicitly or by using the
		/// <c>ListView_GetColumn</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the column.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to an <c>LVCOLUMN</c> structure that specifies the information to retrieve and receives information about the column.
		/// The <c>mask</c> member specifies which column attributes to retrieve. If the <c>mask</c> member specifies the LVCF_TEXT value,
		/// the <c>pszText</c> member must contain the address of the buffer that receives the item text and the <c>cchTextMax</c> member
		/// must specify the size of the buffer.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getcolumn
		[MsgParams(typeof(int), typeof(LVCOLUMN), LResultType = typeof(BOOL))]
		LVM_GETCOLUMN = LVM_FIRST + 95,

		/// <summary>
		/// Sets the attributes of a list-view column. You can send this message explicitly or by using the <c>ListView_SetColumn</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the column.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>LVCOLUMN</c> structure that contains the new column attributes. The <c>mask</c> member specifies which column
		/// attributes to set. If the <c>mask</c> member specifies the LVCF_TEXT value, the <c>pszText</c> member is the address of a
		/// null-terminated string and the <c>cchTextMax</c> member is ignored.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setcolumn
		[MsgParams(typeof(int), typeof(LVCOLUMN), LResultType = typeof(BOOL))]
		LVM_SETCOLUMN = LVM_FIRST + 96,

		/// <summary>
		/// Inserts a new column in a list-view control. You can send this message explicitly or by using the <c>ListView_InsertColumn</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the new column.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>LVCOLUMN</c> structure that contains the attributes of the new column.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the new column if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>Columns are visible only in report (details) view.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-insertcolumn
		[MsgParams(typeof(int), typeof(LVCOLUMN))]
		LVM_INSERTCOLUMN = LVM_FIRST + 97,

		/// <summary>
		/// Removes a column from a list-view control. You can send this message explicitly or by using the <c>ListView_DeleteColumn</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the column to delete.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// Deleting column zero of a list-view control is supported only in ComCtl32.dll version 6 and later. Version 5 also supports
		/// deleting column zero, but only after you use <c>CCM_SETVERSION</c> to set the version to 5 or later. In versions prior to version
		/// 5, if you must delete column zero, insert a zero length dummy column zero and delete column one and above.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-deletecolumn
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		LVM_DELETECOLUMN = LVM_FIRST + 28,

		/// <summary>
		/// Gets the width of a column in report or list view. You can send this message explicitly or by using the
		/// <c>ListView_GetColumnWidth</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the column. This parameter is ignored in list view.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the column width if successful, or zero otherwise. If this message is sent to a list-view control with the
		/// <c>LVS_REPORT</c> style and the specified column does not exist, the return value is undefined.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getcolumnwidth
		[MsgParams(typeof(int), null)]
		LVM_GETCOLUMNWIDTH = LVM_FIRST + 29,

		/// <summary>
		/// Changes the width of a column in report-view mode or the width of all columns in list-view mode. You can send this message
		/// explicitly or use the <c>ListView_SetColumnWidth</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of a valid column. For list-view mode, this parameter must be set to zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>New width of the column, in pixels. For report-view mode, the following special values are supported:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVSCW_AUTOSIZE</c></term>
		/// <term>Automatically sizes the column.</term>
		/// </item>
		/// <item>
		/// <term><c>LVSCW_AUTOSIZE_USEHEADER</c></term>
		/// <term>
		/// Automatically sizes the column to fit the header text. If you use this value with the last column, its width is set to fill the
		/// remaining width of the list-view control.
		/// </term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// Assume that you have a 2-column list-view control with a width of 500 pixels. If the width of column zero is set to 200 pixels,
		/// and you send this message with wParam = 1 and lParam = LVSCW_AUTOSIZE_USEHEADER, the second (and last) column will be 300 pixels wide.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setcolumnwidth
		[MsgParams(typeof(uint), typeof(int), LResultType = typeof(BOOL))]
		LVM_SETCOLUMNWIDTH = LVM_FIRST + 30,

		/// <summary>
		/// Gets the handle to the header control used by the list-view control. You can send this message explicitly or use the
		/// <c>ListView_GetHeader</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the header control.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getheader
		[MsgParams(LResultType = typeof(HWND))]
		LVM_GETHEADER = LVM_FIRST + 31,

		/// <summary>
		/// Creates a drag image list for the specified item. You can send this message explicitly or by using the
		/// <c>ListView_CreateDragImage</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>POINT</c> structure that receives the initial location of the upper-left corner of the image, in view coordinates.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the drag image list if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		/// <remarks>Your application is responsible for destroying the image list when it is no longer needed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-createdragimage
		[MsgParams(typeof(int), typeof(POINT?), LResultType = typeof(HWND))]
		LVM_CREATEDRAGIMAGE = LVM_FIRST + 33,

		/// <summary>
		/// Retrieves the bounding rectangle of all items in the list-view control. The list view must be in icon or small icon view. You can
		/// send this message explicitly or by using the <c>ListView_GetViewRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that receives the bounding rectangle. All coordinates are relative to the visible area of the
		/// list-view control.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getviewrect
		[MsgParams(null, typeof(RECT?), LResultType = typeof(BOOL))]
		LVM_GETVIEWRECT = LVM_FIRST + 34,

		/// <summary>
		/// Retrieves the text color of a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_GetTextColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the text color.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-gettextcolor
		[MsgParams(LResultType = typeof(COLORREF))]
		LVM_GETTEXTCOLOR = LVM_FIRST + 35,

		/// <summary>
		/// Sets the text color of a list-view control. You can send this message explicitly or by using the <c>ListView_SetTextColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>COLORREF</c> that specifies the new text color.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-settextcolor
		[MsgParams(null, typeof(COLORREF), LResultType = typeof(BOOL))]
		LVM_SETTEXTCOLOR = LVM_FIRST + 36,

		/// <summary>
		/// Retrieves the text background color of a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_GetTextBkColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the background color of the text.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-gettextbkcolor
		[MsgParams(LResultType = typeof(COLORREF))]
		LVM_GETTEXTBKCOLOR = LVM_FIRST + 37,

		/// <summary>
		/// Sets the background color of text in a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_SetTextBkColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>New text background color. This can be CLR_NONE for no background color.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-settextbkcolor
		[MsgParams(LResultType = typeof(BOOL))]
		LVM_SETTEXTBKCOLOR = LVM_FIRST + 38,

		/// <summary>
		/// Retrieves the index of the topmost visible item when in list or report view. You can send this message explicitly or by using the
		/// <c>ListView_GetTopIndex</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the index of the item if successful. Returns zero if the list-view control is in icon or small icon view, or if the
		/// list-view control is in details view with groups enabled.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-gettopindex
		[MsgParams()]
		LVM_GETTOPINDEX = LVM_FIRST + 39,

		/// <summary>
		/// Calculates the number of items that can fit vertically in the visible area of a list-view control when in list or report view.
		/// Only fully visible items are counted. You can send this message explicitly or by using the <c>ListView_GetCountPerPage</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the number of fully visible items if successful. If the current view is icon or small icon view, the return value is the
		/// total number of items in the list-view control.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getcountperpage
		[MsgParams(LResultType = typeof(uint))]
		LVM_GETCOUNTPERPAGE = LVM_FIRST + 40,

		/// <summary>
		/// Retrieves the current view origin for a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_GetOrigin</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>POINT</c> structure that receives the view origin.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> if the current view is list or report view.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getorigin
		[MsgParams(null, typeof(POINT?), LResultType = typeof(BOOL))]
		LVM_GETORIGIN = LVM_FIRST + 41,

		/// <summary>
		/// Updates a list-view item. If the list-view control has the <c>LVS_AUTOARRANGE</c> style, this macro causes the list-view control
		/// to be arranged. You can send this message explicitly or by using the <c>ListView_Update</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the item to update.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-update
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		LVM_UPDATE = LVM_FIRST + 42,

		/// <summary>
		/// Changes the state of an item in a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_SetItemState</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the list-view item. If this parameter is -1, then the state change is applied to all items.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>LVITEM</c> structure. The <c>stateMask</c> member specifies which state bits to change, and the <c>state</c>
		/// member contains the new values for those bits. The other members are ignored.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If you send this message explicitly, it returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// An item's state value includes a set of bit flags that indicate the item's state. The state value can also include image list
		/// indexes that indicate the item's state image and overlay image.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setitemstate
		[MsgParams(typeof(int), typeof(LVITEM), LResultType = typeof(BOOL))]
		LVM_SETITEMSTATE = LVM_FIRST + 43,

		/// <summary>
		/// Retrieves the state of a list-view item. You can send this message explicitly or by using the <c>ListView_GetItemState</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the list-view item.</para>
		/// <para><em>lParam</em></para>
		/// <para>State information to retrieve. This parameter can be a combination of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVIS_CUT</c></term>
		/// <term>The item is marked for a cut-and-paste operation.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_DROPHILITED</c></term>
		/// <term>The item is highlighted as a drag-and-drop target.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_FOCUSED</c></term>
		/// <term>
		/// The item has the focus, so it is surrounded by a standard focus rectangle. Although more than one item may be selected, only one
		/// item can have the focus.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_SELECTED</c></term>
		/// <term>
		/// The item is selected. The appearance of a selected item depends on whether it has the focus and also on the system colors used
		/// for selection.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_OVERLAYMASK</c></term>
		/// <term>Use this mask to retrieve the item's overlay image index.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIS_STATEIMAGEMASK</c></term>
		/// <term>Use this mask to retrieve the item's state image index.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the current state for the specified item. The only valid bits in the return value are those that correspond to the bits
		/// set in the lParam parameter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// An item's state information includes a set of bit flags as well as image list indexes that indicate the item's state image and
		/// overlay image.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getitemstate
		[MsgParams(typeof(int), typeof(ListViewItemState), LResultType = typeof(ListViewItemState))]
		LVM_GETITEMSTATE = LVM_FIRST + 44,

		/// <summary>
		/// Retrieves the text of a list-view item or subitem. You can send this message explicitly or by using the
		/// <c>ListView_GetItemText</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the list-view item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>LVITEM</c> structure. To retrieve the item text, set <c>iSubItem</c> to zero. To retrieve the text of a subitem,
		/// set <c>iSubItem</c> to the subitem's index. The <c>pszText</c> member points to a buffer that receives the text. The
		/// <c>cchTextMax</c> member specifies the number of characters in the buffer.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If you send this message explicitly, it returns the number of characters in the <c>pszText</c> member of the <c>LVITEM</c> structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can also send this message by calling the <c>ListView_GetItemText</c> macro. However, this macro does not return the string length.
		/// </para>
		/// <para><c>LVM_GETITEMTEXT</c> is not supported under the <c>LVS_OWNERDATA</c> style.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getitemtext
		[MsgParams(typeof(int), typeof(LVITEM), LResultType = typeof(uint))]
		LVM_GETITEMTEXT = LVM_FIRST + 115,

		/// <summary>
		/// Changes the text of a list-view item or subitem. You can send this message explicitly or by using the <c>ListView_SetItemText</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the list-view item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>LVITEM</c> structure. The <c>iSubItem</c> member is the index of the subitem, or it can be zero to set the item
		/// label. The <c>pszText</c> member is the address of a null-terminated string containing the new text; it can also be <c>NULL</c>.
		/// The <c>pszText</c> member can also be LPSTR_TEXTCALLBACK to indicate a callback item for which the parent window stores the text.
		/// In this case, the list-view control sends the parent an <c>LVN_GETDISPINFO</c> notification code when it needs the text.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If you send this message explicitly, it returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setitemtext
		[MsgParams(typeof(int), typeof(LVITEM), LResultType = typeof(BOOL))]
		LVM_SETITEMTEXT = LVM_FIRST + 116,

		/// <summary>
		/// Causes the list-view control to allocate memory for the specified number of items or sets the virtual number of items in a
		/// virtual list-view control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Number of items that the list-view control will ultimately contain.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Version 4.70. Values that specify the behavior of the list-view control after resetting the item count. This value can be a
		/// combination of the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVSICF_NOINVALIDATEALL</c></term>
		/// <term>The list-view control will not repaint unless affected items are currently in view.</term>
		/// </item>
		/// <item>
		/// <term><c>LVSICF_NOSCROLL</c></term>
		/// <term>The list-view control will not change the scroll position when the item count changes.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// How the memory is allocated depends on how the list-view control was created. You can send this message explicitly or use the
		/// <c>ListView_SetItemCount</c> or <c>ListView_SetItemCountEx</c> macros. For more information, see Virtual List-View Style.
		/// </para>
		/// <para>
		/// If the list-view control was created without the <c>LVS_OWNERDATA</c> style, sending this message causes the control to allocate
		/// its internal data structures for the specified number of items. This prevents the control from having to allocate the data
		/// structures every time an item is added.
		/// </para>
		/// <para>
		/// If the list-view control was created with the <c>LVS_OWNERDATA</c> style (a virtual list view), sending this message sets the
		/// virtual number of items that the control contains.
		/// </para>
		/// <para>
		/// The lParam parameter is intended only for list-view controls that use the <c>LVS_OWNERDATA</c> and <c>LVS_REPORT</c> or
		/// <c>LVS_LIST</c> styles.
		/// </para>
		/// <para>
		/// When the common control list-view is a virtualized list-view ( <c>LVS_OWNERDATA</c>), there is a 100,000,000 item limit on the
		/// list-view. In this scenario, <c>LVM_SETITEMCOUNT</c> will return FALSE when it has a wParam of 100,000,001.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setitemcount
		[MsgParams(typeof(int), typeof(LVSICF), LResultType = typeof(BOOL))]
		LVM_SETITEMCOUNT = LVM_FIRST + 47,

		/// <summary>
		/// Uses an application-defined comparison function to sort the items of a list-view control. The index of each item changes to
		/// reflect the new sequence. You can send this message explicitly or by using the <c>ListView_SortItems</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Application-defined value that is passed to the comparison function.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to the application-defined comparison function. The comparison function is called during the sort operation each time the
		/// relative order of two list items needs to be compared.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>The comparison function has the following form:</para>
		/// <para>
		/// <code>int CALLBACK CompareFunc(LPARAM lParam1, LPARAM lParam2, LPARAM lParamSort);</code>
		/// </para>
		/// <para>
		/// The lParam1 parameter is the value associated with the first item being compared, and the lParam2 parameter is the value
		/// associated with the second item. These are the values that were specified in the <c>lParam</c> member of the items' <c>LVITEM</c>
		/// structure when they were inserted into the list. The <c>ListView_SortItems</c>'s wParam parameter is passed to the callback
		/// function as its third parameter.
		/// </para>
		/// <para>
		/// The comparison function must return a negative value if the first item should precede the second, a positive value if the first
		/// item should follow the second, or zero if the two items are equivalent.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// During the sorting process, the list-view contents are unstable. If the callback function sends any messages to the list-view
		/// control aside from <c>LVM_GETITEM</c> ( <c>ListView_GetItem</c>), the results are unpredictable.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-sortitems
		[MsgParams(typeof(IntPtr), typeof(Func<IntPtr, IntPtr, IntPtr, int>), LResultType = typeof(BOOL))]
		LVM_SORTITEMS = LVM_FIRST + 48,

		/// <summary>
		/// Moves an item to a specified position in a list-view control (must be in icon or small icon view). This message differs from the
		/// <c>LVM_SETITEMPOSITION</c> message in that it uses 32-bit coordinates. You can send this message explicitly or by using the
		/// <c>ListView_SetItemPosition32</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the list-view item for which to set the position.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>POINT</c> structure that contains the new position of the item, in list-view coordinates.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setitemposition32
		[MsgParams(typeof(int), typeof(POINT?), LResultType = null)]
		LVM_SETITEMPOSITION32 = LVM_FIRST + 49,

		/// <summary>
		/// Determines the number of selected items in a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_GetSelectedCount</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the number of selected items.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getselectedcount
		[MsgParams()]
		LVM_GETSELECTEDCOUNT = LVM_FIRST + 50,

		/// <summary>
		/// Determines the spacing between items in a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_GetItemSpacing</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// View for which to retrieve the item spacing. This parameter is <c>TRUE</c> for small icon view, or <c>FALSE</c> for icon view.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the amount of spacing between items. The horizontal spacing is contained in the <c>LOWORD</c> and the vertical spacing is
		/// contained in the <c>HIWORD</c>.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getitemspacing
		[MsgParams(typeof(BOOL), null, LResultType = typeof(uint))]
		LVM_GETITEMSPACING = LVM_FIRST + 51,

		/// <summary>
		/// Retrieves the incremental search string of a list-view control. You can send this message explicitly or by using the
		/// <c>ListView_GetISearchString</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a buffer that receives the incremental search string. To just retrieve the length of the string, set lParam to <c>NULL</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the number of characters in the incremental search string, not including the terminating NULL character, or zero if the
		/// list-view control is not in incremental search mode.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <c>Security Warning:</c> Using this message incorrectly might compromise the security of your program. This message does not
		/// provide a way for you to know the size of the buffer. If you use this message, first call the message passing <c>NULL</c> in the
		/// lParam, this returns the number of characters, excluding <c>NULL</c> that are required. Then call the message a second time to
		/// retrieve the string. You should review the Security Considerations: Microsoft Windows Controls before continuing.
		/// </para>
		/// <para>
		/// The incremental search string is the character sequence that the user types while the list view has the input focus. Each time
		/// the user types a character, the system appends the character to the search string and then searches for a matching item. If the
		/// system finds a match, it selects the item and, if necessary, scrolls it into view.
		/// </para>
		/// <para>
		/// A time-out period is associated with each character that the user types. If the time-out period elapses before the user types
		/// another character, the incremental search string is reset.
		/// </para>
		/// <para>
		/// Make sure that the buffer is large enough to hold the string and the terminating NULL character. If it is too small, an immediate
		/// invalid page fault will result.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getisearchstring
		[MsgParams(null, typeof(IntPtr))]
		LVM_GETISEARCHSTRING = LVM_FIRST + 117,

		/// <summary>
		/// Sets the spacing between icons in list-view controls that have the <c>LVS_ICON</c> style. You can send this message explicitly or
		/// by using the <c>ListView_SetIconSpacing</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the distance, in pixels, to set between icons on the x-axis. The <c>HIWORD</c> specifies the
		/// distance, in pixels, to set between icons on the y-axis. See Remarks.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>DWORD</c> value that contains the previous x-axis distance in the low word, and the previous y-axis distance in the
		/// high word.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Values for lParam are relative to the upper-left corner of an icon bitmap. Therefore, to set spacing between icons that do not
		/// overlap, the lParam values must include the size of the icon, plus the amount of empty space desired between icons. Values that
		/// do not include the width of the icon will result in overlaps.
		/// </para>
		/// <para>
		/// When defining the icon spacing, the lParam values must set to 4 or larger. Smaller values will not yield the desired layout. To
		/// reset the icons to the default spacing, set the lParam values to -1.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-seticonspacing
		[MsgParams(null, typeof(uint), LResultType = typeof(uint))]
		LVM_SETICONSPACING = LVM_FIRST + 53,

		/// <summary>
		/// Sets extended styles in list-view controls. You can send this message explicitly or use the
		/// <c>ListView_SetExtendedListViewStyle</c> or <c>ListView_SetExtendedListViewStyleEx</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// <c>DWORD</c> value that specifies which styles in lParam are to be affected. This parameter can be a combination of <c>Extended
		/// List-View Styles</c>. Only the extended styles in wParam will be changed. All other styles will be maintained as they are. If
		/// this parameter is zero, all of the styles in lParam will be affected.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// <c>DWORD</c> value that specifies the extended list-view control styles to set. This parameter can be a combination of
		/// <c>Extended List-View Styles</c>. Styles that are not set, but that are specified in wParam, are removed.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>DWORD</c> value that contains the previous extended list-view control styles.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The wParam parameter allows you to modify one or more extended styles without having to retrieve the existing styles first. For
		/// example, if you pass <c>LVS_EX_FULLROWSELECT</c> for wParam and 0 for lParam, the <c>LVS_EX_FULLROWSELECT</c> style will be
		/// cleared but all other styles will remain the same.
		/// </para>
		/// <para>
		/// For backward compatibility reasons, the <c>ListView_SetExtendedListViewStyle</c> macro has not been updated to use wParam. To use
		/// the wParam value, use the <c>ListView_SetExtendedListViewStyleEx</c> macro.
		/// </para>
		/// <para>
		/// When you use this message to set the <c>LVS_EX_CHECKBOXES</c> style, any previously set state image index will be discarded. All
		/// check boxes will be initialized to the unchecked state. The state image index is contained in bits 12 through 15 of the
		/// <c>state</c> member of the <c>LVITEM</c> structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setextendedlistviewstyle
		[MsgParams(typeof(ListViewStyleEx), typeof(ListViewStyleEx), LResultType = typeof(ListViewStyleEx))]
		LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54,            // OPTIONAL WPARAM == MASK

		/// <summary>
		/// Gets the extended styles that are currently in use for a given list-view control. You can send this message explicitly or use the
		/// <c>ListView_GetExtendedListViewStyle</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>DWORD</c> that represents the styles currently in use for a given list-view control. This value can be a combination
		/// of Extended List-View Styles.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getextendedlistviewstyle
		[MsgParams(LResultType = typeof(ListViewStyleEx))]
		LVM_GETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 55,

		/// <summary>
		/// Retrieves information about the bounding rectangle for a subitem in a list-view control. You can send this message explicitly or
		/// by using the <c>ListView_GetSubItemRect</c> macro (recommended). This message is intended to be used only with list-view controls
		/// that use the <c>LVS_REPORT</c> style.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the subitem's parent item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that will receive the subitem bounding rectangle information. Its members must be initialized
		/// according to the following member/value relationships:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>top</c></term>
		/// <term>The one-based index of the subitem.</term>
		/// </item>
		/// <item>
		/// <term><c>left</c></term>
		/// <term>Flag value (see remarks). Indicates the portion of the list-view subitem for which to retrieve the bounding rectangle.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>Following are the flag values that may be set.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Requirement</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term><c>Flag Value</c></term>
		/// <term><c>Meaning</c></term>
		/// </item>
		/// <item>
		/// <term>LVIR_BOUNDS</term>
		/// <term>Returns the bounding rectangle of the entire item, including the icon and label.</term>
		/// </item>
		/// <item>
		/// <term>LVIR_ICON</term>
		/// <term>Returns the bounding rectangle of the icon or small icon.</term>
		/// </item>
		/// <item>
		/// <term>LVIR_LABEL</term>
		/// <term>Returns the bounding rectangle of the entire item, including the icon and label. This is identical to LVIR_BOUNDS.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getsubitemrect
		[MsgParams(typeof(int), typeof(RECT?), LResultType = typeof(BOOL))]
		LVM_GETSUBITEMRECT = LVM_FIRST + 56,

		/// <summary>
		/// Determines which list-view item or subitem is at a given position. You can send this message explicitly or by using the
		/// <c>ListView_SubItemHitTest</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be 0. **Windows Vista.** Should be -1 if the **iGroup** member of *lParam* is to be retrieved.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>LVHITTESTINFO</c> structure. The <c>POINT</c> structure within <c>LVHITTESTINFO</c> should be set to the client
		/// coordinates to be hit-tested.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the index of the item or subitem tested, if any, or -1 otherwise. If an item or subitem is at the given coordinates, the
		/// fields of the <c>LVHITTESTINFO</c> structure will be filled with the applicable hit information.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-subitemhittest
		[MsgParams(typeof(int), typeof(LVHITTESTINFO?))]
		LVM_SUBITEMHITTEST = LVM_FIRST + 57,

		/// <summary>
		/// Sets the left-to-right order of columns in a list-view control. You can send this message explicitly or use the
		/// <c>ListView_SetColumnOrderArray</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Size, in elements, of the buffer at lParam.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an array that specifies the order in which columns should be displayed, from left to right. For example, if the
		/// contents of the array are {2,0,1}, the control displays column 2, column 0, and column 1 in that order.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setcolumnorderarray
		[MsgParams(typeof(int), typeof(int[]), LResultType = typeof(BOOL))]
		LVM_SETCOLUMNORDERARRAY = LVM_FIRST + 58,

		/// <summary>
		/// Gets the current left-to-right order of columns in a list-view control. You can send this message explicitly or use the
		/// <c>ListView_GetColumnOrderArray</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The number of columns in the list-view control.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to an array of integers that receives the index values of the columns in the list-view control. The array must be large
		/// enough to hold wParam elements.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If successful, returns nonzero, and the buffer at lParam receives the column index of each column in the control in the order
		/// they appear from left to right. Otherwise, the return value is zero.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getcolumnorderarray
		[MsgParams(typeof(int), typeof(int[]), LResultType = typeof(BOOL))]
		LVM_GETCOLUMNORDERARRAY = LVM_FIRST + 59,

		/// <summary>
		/// Sets the hot item for a list-view control. You can send this message explicitly or use the <c>ListView_SetHotItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the item to be set as the hot item.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the item that was previously hot.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-sethotitem
		[MsgParams(typeof(int), null)]
		LVM_SETHOTITEM = LVM_FIRST + 60,

		/// <summary>
		/// Retrieves the index of the hot item. You can send this message explicitly or use the <c>ListView_GetHotItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the item that is hot.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-gethotitem
		[MsgParams(null, null)]
		LVM_GETHOTITEM = LVM_FIRST + 61,

		/// <summary>
		/// Sets the HCURSOR value that the list-view control uses when the pointer is over an item while hot tracking is enabled. You can
		/// send this message explicitly or use the <c>ListView_SetHotCursor</c> macro. To check whether hot tracking is enabled, call <c>SystemParametersInfo</c>.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the cursor to be set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns an HCURSOR value that is the previous hot cursor.</para>
		/// </summary>
		/// <remarks>A list-view control uses hot tracking and hover selection when the <c>LVS_EX_TRACKSELECT</c> style is set.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-sethotcursor
		[MsgParams(null, typeof(HCURSOR), LResultType = typeof(HCURSOR))]
		LVM_SETHOTCURSOR = LVM_FIRST + 62,

		/// <summary>
		/// Retrieves the HCURSOR value used when the pointer is over an item while hot tracking is enabled. You can send this message
		/// explicitly or use the <c>ListView_GetHotCursor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns an HCURSOR value that is the handle to the cursor that the list-view control uses when hot tracking is enabled.</para>
		/// </summary>
		/// <remarks>A list-view control uses hot tracking and hover selection when the <c>LVS_EX_TRACKSELECT</c> style is set.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-gethotcursor
		[MsgParams(LResultType = typeof(HCURSOR))]
		LVM_GETHOTCURSOR = LVM_FIRST + 63,

		/// <summary>
		/// Calculates the approximate width and height required to display a given number of items. You can send this message explicitly or
		/// use the <c>ListView_ApproximateViewRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The number of items to be displayed in the control. If this parameter is set to -1, the message uses the total number of items in
		/// the control.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is the proposed x-dimension of the control, in pixels. This parameter can be set to -1 to allow the message to
		/// use the current width value.
		/// </para>
		/// <para>
		/// The <c>HIWORD</c> is the proposed y-dimension of the control, in pixels. This parameter can be set to -1 to allow the message to
		/// use the current height value.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>DWORD</c> value that holds the approximate width (in the <c>LOWORD</c>) and height (in the <c>HIWORD</c>) needed to
		/// display the items, in pixels.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Setting the size of the list-view control based on the dimensions provided by this message can optimize redraw and reduce flicker.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-approximateviewrect
		[MsgParams(typeof(int), typeof(SIZES), LResultType = typeof(SIZES))]
		LVM_APPROXIMATEVIEWRECT = LVM_FIRST + 64,

		/// <summary>
		/// Sets the working areas within a list-view control. You can send this message explicitly or use the <c>ListView_SetWorkAreas</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The number of structures in the array at lprc. The maximum number of working areas allowed is defined by the LV_MAX_WORKAREAS value.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an array of <c>RECT</c> structures that contain the new working areas of the list-view control. Values in these
		/// structures are in client coordinates. If this parameter is <c>NULL</c>, the working area will be set to the client area of the
		/// control. wParam specifies the number of structures in this array.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value for this message is not used.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setworkareas
		[MsgParams(typeof(int), typeof(RECT[]), LResultType = null)]
		LVM_SETWORKAREAS = LVM_FIRST + 65,

		/// <summary>
		/// Retrieves the working areas from a list-view control. You can send this message explicitly or use the
		/// <c>ListView_GetWorkAreas</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The number of <c>RECT</c> structures in the array at lParam.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an array of <c>RECT</c> structures that receive the current working areas of the list-view control. Values in these
		/// structures are in client coordinates. wParam specifies the number of structures in this array.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value for this message is not used.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getworkareas
		[MsgParams(typeof(int), typeof(RECT[]), LResultType = null)]
		LVM_GETWORKAREAS = LVM_FIRST + 70,

		/// <summary>
		/// Retrieves the number of working areas in a list-view control. You can send this message explicitly or use the
		/// <c>ListView_GetNumberOfWorkAreas</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a UINT value that receives the number of working areas in the list-view control. If zero is placed in this variable,
		/// then no working areas are currently set. This value cannot be <c>NULL</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value for this message is not used.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getnumberofworkareas
		[MsgParams(null, typeof(uint), LResultType = null)]
		LVM_GETNUMBEROFWORKAREAS = LVM_FIRST + 73,

		/// <summary>
		/// Retrieves the selection mark from a list-view control. You can send this message explicitly or use the
		/// <c>ListView_GetSelectionMark</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the zero-based selection mark, or -1 if there is no selection mark.</para>
		/// </summary>
		/// <remarks>The selection mark is the item index from which a multiple selection starts.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getselectionmark
		[MsgParams()]
		LVM_GETSELECTIONMARK = LVM_FIRST + 66,

		/// <summary>
		/// Sets the selection mark in a list-view control. You can send this message explicitly or use the <c>ListView_SetSelectionMark</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Zero-based index of the new selection mark. If set to -1, the selection mark is removed.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous selection mark, or -1 if there is no previous selection mark.</para>
		/// </summary>
		/// <remarks>
		/// The selection mark is the item index from which a multiple selection starts. This message does not affect the selection state of
		/// the item.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setselectionmark
		[MsgParams(null, typeof(int))]
		LVM_SETSELECTIONMARK = LVM_FIRST + 67,

		/// <summary>
		/// Sets the amount of time which the mouse cursor must hover over an item before it is selected. You can send this message
		/// explicitly or use the <c>ListView_SetHoverTime</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The new amount of time, in milliseconds, that the mouse cursor must hover over an item before it is selected. If this value is (
		/// <c>DWORD</c>)-1, then the hover time is set to the default hover time.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous hover time.</para>
		/// </summary>
		/// <remarks>
		/// The hover time only affects list-view controls that have the <c>LVS_EX_TRACKSELECT</c>, <c>LVS_EX_ONECLICKACTIVATE</c>, or
		/// <c>LVS_EX_TWOCLICKACTIVATE</c> extended list-view style.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-sethovertime
		[MsgParams(null, typeof(int))]
		LVM_SETHOVERTIME = LVM_FIRST + 71,

		/// <summary>
		/// Retrieves the amount of time that the mouse cursor must hover over an item before it is selected. You can send this message
		/// explicitly or use the <c>ListView_GetHoverTime</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the amount of time, in milliseconds, that the mouse cursor must hover over an item before it is selected. If the return
		/// value is ( <c>DWORD</c>)-1, then the hover time is the default hover time.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The hover time only affects list-view controls that have the <c>LVS_EX_TRACKSELECT</c>, <c>LVS_EX_ONECLICKACTIVATE</c>, or
		/// <c>LVS_EX_TWOCLICKACTIVATE</c> extended list-view style.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-gethovertime
		[MsgParams()]
		LVM_GETHOVERTIME = LVM_FIRST + 72,

		/// <summary>
		/// Sets the tooltip control that the list-view control will use to display tooltips. You can send this message explicitly or use the
		/// <c>ListView_SetToolTips</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the tooltip control to be set.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the previous tooltip control.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-settooltips
		[MsgParams(typeof(HWND), null, LResultType = typeof(HWND))]
		LVM_SETTOOLTIPS = LVM_FIRST + 74,

		/// <summary>
		/// Retrieves the tooltip control that the list-view control uses to display tooltips. You can send this message explicitly or use
		/// the <c>ListView_GetToolTips</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle of the tooltip control.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-gettooltips
		[MsgParams(LResultType = typeof(HWND))]
		LVM_GETTOOLTIPS = LVM_FIRST + 78,

		/// <summary>
		/// Uses an application-defined comparison function to sort the items of a list-view control. The index of each item changes to
		/// reflect the new sequence. You can send this message explicitly or by using the <c>ListView_SortItemsEx</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Application-defined value that is passed to the comparison function.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an application-defined comparison function. It is called during the sort operation each time the relative order of two
		/// list items needs to be compared.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>The comparison function has the following form:</para>
		/// <para>
		/// <code>int CALLBACK CompareFunc(LPARAM lParam1, LPARAM lParam2, LPARAM lParamSort);</code>
		/// </para>
		/// <para>
		/// This message is similar to <c>LVM_SORTITEMS</c>, except for the type of information passed to the comparison function. With
		/// <c>LVM_SORTITEMSEX</c>, lParam1 is the current index of the first item, and lParam2 is the current index of the second item. You
		/// can send an <c>LVM_GETITEMTEXT</c> message to retrieve more information on an item, if needed.
		/// </para>
		/// <para>
		/// The comparison function must return a negative value if the first item should precede the second, a positive value if the first
		/// item should follow the second, or zero if the two items are equivalent.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// During the sorting process, the list-view contents are unstable. If the callback function sends any messages to the list-view
		/// control aside from <c>LVM_GETITEM</c> ( <c>ListView_GetItem</c>), the results are unpredictable.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-sortitemsex
		[MsgParams(typeof(IntPtr), typeof(Func<IntPtr, IntPtr, IntPtr, int>), LResultType = typeof(BOOL))]
		LVM_SORTITEMSEX = LVM_FIRST + 81,

		/// <summary>
		/// Sets the background image in a list-view control. You can send this message explicitly or by using the <c>ListView_SetBkImage</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>LVBKIMAGE</c> structure that contains the new background image information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns nonzero if successful, or zero otherwise. Returns zero if the <c>ulFlags</c> member of the <c>LVBKIMAGE</c> structure is <c>LVBKIF_SOURCE_NONE</c>.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Because the list-view control uses OLE COM to manipulate the background images, the calling application must call
		/// <c>CoInitialize</c> or <c>OleInitialize</c> before sending this message. It is best to call one of these functions when the
		/// application is initialized and call either <c>CoUninitialize</c> or <c>OleUninitialize</c> when the application is terminating.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setbkimage
		[MsgParams(null, typeof(LVBKIMAGE), LResultType = typeof(BOOL))]
		LVM_SETBKIMAGE = LVM_FIRST + 138,

		/// <summary>
		/// Gets the background image in a list-view control. You can send this message explicitly or by using the <c>ListView_GetBkImage</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to an <c>LVBKIMAGE</c> structure that will receive the background image information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getbkimage
		[MsgParams(null, typeof(LVBKIMAGE), LResultType = typeof(BOOL))]
		LVM_GETBKIMAGE = LVM_FIRST + 139,

		/// <summary>
		/// Sets the index of the selected column.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Value of type **int** that specifies the column index.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>The column indices are stored in an <c>int</c> array. See the <c>puColumns</c> member of <c>LVITEM</c>.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setselectedcolumn
		[MsgParams(typeof(int), null, LResultType = null)]
		LVM_SETSELECTEDCOLUMN = LVM_FIRST + 140,

		/// <summary>
		/// Sets the view of a list-view control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>**DWORD** that specifies the view.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns 1 if successful, or -1 otherwise. For example, -1 is returned if the view is invalid.</para>
		/// </summary>
		/// <remarks>
		/// <para>Following are the values for views.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>LV_VIEW_DETAILS</term>
		/// </item>
		/// <item>
		/// <term>LV_VIEW_ICON</term>
		/// </item>
		/// <item>
		/// <term>LV_VIEW_LIST</term>
		/// </item>
		/// <item>
		/// <term>LV_VIEW_SMALLICON</term>
		/// </item>
		/// <item>
		/// <term>LV_VIEW_TILE</term>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comctl32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setview
		[MsgParams(typeof(LV_VIEW), null)]
		LVM_SETVIEW = LVM_FIRST + 142,

		/// <summary>
		/// Retrieves the current view of a list-view control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>DWORD</c> that specifies the current view.</para>
		/// </summary>
		/// <remarks>
		/// <para>Following are the values for views.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>LV_VIEW_DETAILS</term>
		/// </item>
		/// <item>
		/// <term>LV_VIEW_ICON</term>
		/// </item>
		/// <item>
		/// <term>LV_VIEW_LIST</term>
		/// </item>
		/// <item>
		/// <term>LV_VIEW_SMALLICON</term>
		/// </item>
		/// <item>
		/// <term>LV_VIEW_TILE</term>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getview
		[MsgParams(LResultType = typeof(LV_VIEW))]
		LVM_GETVIEW = LVM_FIRST + 143,

		/// <summary>
		/// Inserts a group into a list-view control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index where the group is to be added. If this is -1, the group is added at the end of the list.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a</para>
		/// <para>**LVGROUP**</para>
		/// <para>structure that contains the group to add.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the item that the group was added to, or -1 if the operation failed.</para>
		/// </summary>
		/// <remarks>
		/// <para>To turn on group mode, call <c>LVM_ENABLEGROUPVIEW</c> or <c>ListView_EnableGroupView</c>.</para>
		/// <para>A group cannot be inserted into an empty list-view control.</para>
		/// <para>
		/// Be sure to set the <c>iGroupId</c> in the item(s) the group was added to. Otherwise after <c>LVM_ENABLEGROUPVIEW</c> message
		/// processing with <c>TRUE</c> the listview control will not show any items.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32 version 6.0. For more information on manifests, see Enabling
		/// Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-insertgroup
		[MsgParams(typeof(int), typeof(LVGROUP))]
		LVM_INSERTGROUP = LVM_FIRST + 145,

		/// <summary>
		/// Sets group information. Send this message explicitly or by using the <c>ListView_SetGroupInfo</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>ID that specifies the group whose information is to be set.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a [**LVGROUP**](windows/win32/api/commctrl/ns-commctrl-lvgroup) structure that contains the information to set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the ID of the group if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To change a group ID of an existing group add <c>LVGF_GROUPID</c> to <c>LVGROUP.mask</c> and set <c>LVGROUP.iGroupId</c> to the
		/// new ID. The call will fail if <c>LVGROUP.iGroupId</c> contains ID of an existing group.
		/// </para>
		/// <para>
		/// To update other properties of an existing group (e.g. update an alignment of the header or footer text for the group,
		/// <c>uAlign</c>) <c>LVGROUP.mask</c> must not contain <c>LVGF_GROUPID</c>, else the update will fail.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setgroupinfo
		[MsgParams(typeof(int), typeof(LVGROUP))]
		LVM_SETGROUPINFO = LVM_FIRST + 147,

		/// <summary>
		/// Gets group information.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>An ID that specifies the group whose information is retrieved.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer an</para>
		/// <para>**LVGROUP**</para>
		/// <para>structure that receives the retrieved information. Set the **cbSize** member of this structure to sizeof(LVGROUP).</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the ID of the group if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>Before attempting to retrieve the header for a group, first ensure that the group does not have the LBGS_NOHEADER style.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getgroupinfo
		[MsgParams(typeof(int), typeof(LVGROUP))]
		LVM_GETGROUPINFO = LVM_FIRST + 149,

		/// <summary>
		/// Removes a group from a list-view control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>ID that specifies the group to remove.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be <c>NULL</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the group if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-removegroup
		[MsgParams(typeof(int), null)]
		LVM_REMOVEGROUP = LVM_FIRST + 150,

		/// <summary>This message is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-movegroup
		LVM_MOVEGROUP = LVM_FIRST + 151,

		/// <summary>
		/// Gets the number of groups.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used. Should be 0.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used. Should be 0.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the number of groups.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getgroupcount
		[MsgParams()]
		LVM_GETGROUPCOUNT = LVM_FIRST + 152,

		/// <summary>
		/// Gets information on a specified group. Send this message explicitly or by using the <c>ListView_GetGroupInfoByIndex</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the group.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to an <c>LVGROUP</c> structure to receive information on the group specified by wParam. The calling process is
		/// responsible for allocating memory for the structure and any buffers in the structure, such as the one pointed to by the
		/// <c>pszHeader</c> member. Set any contingent members of the structure, such as <c>cchHeader</c> the size of the buffer pointed to
		/// by <c>pszHeader</c> in <c>WCHARs</c> including the terminating <c>NULL</c>. Set <c>cbSize</c> to sizeof(LVGROUP).
		/// </para>
		/// <para>The message receiver is responsible for setting the structure members with information for the group specified by wParam.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getgroupinfobyindex
		[MsgParams(typeof(int), typeof(LVGROUP), LResultType = typeof(BOOL))]
		LVM_GETGROUPINFOBYINDEX = LVM_FIRST + 153,

		/// <summary>This message is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-moveitemtogroup
		LVM_MOVEITEMTOGROUP = LVM_FIRST + 154,

		/// <summary>
		/// Gets the rectangle for a specified group. Send this message explicitly or by using the <c>ListView_GetGroupRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the group by <c>iGroupId</c> (see <c>LVGROUP</c> structure).</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>RECT</c> structure to receive information on the group specified by wParam. The message receiver is responsible
		/// for setting the structure members with information for the group specified by wParam.
		/// </para>
		/// <para>
		/// The calling process is responsible for allocating memory for the structure. Set the <c>top</c> member of the <c>RECT</c> to one
		/// of the following flags to specify the coordinates of the rectangle to get.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVGGR_GROUP</c></term>
		/// <term>Coordinates of the entire expanded group.</term>
		/// </item>
		/// <item>
		/// <term><c>LVGGR_HEADER</c></term>
		/// <term>Coordinates of the header only (collapsed group).</term>
		/// </item>
		/// <item>
		/// <term><c>LVGGR_LABEL</c></term>
		/// <term>Coordinates of the label only.</term>
		/// </item>
		/// <item>
		/// <term><c>LVGGR_SUBSETLINK</c></term>
		/// <term>
		/// Coordinates of the subset link only (markup subset). A list-view control can limit the number of visible items displayed in each
		/// group. A link is presented to the user to allow the user to expand the group. This flag will return the bounding rectangle of the
		/// subset link if the group is a subset (group state of LVGS_SUBSETED, see structure <c>LVGROUP</c>, member <c>state</c>). This flag
		/// is provided so that accessibility applications can located the link.
		/// </term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getgrouprect
		[MsgParams(typeof(int), typeof(RECT?), LResultType = typeof(BOOL))]
		LVM_GETGROUPRECT = LVM_FIRST + 98,

		/// <summary>
		/// Sets information about the display of groups.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an</para>
		/// <para>**LVGROUPMETRICS**</para>
		/// <para>structure that contains the metrics to set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setgroupmetrics
		[MsgParams(null, typeof(LVGROUPMETRICS?), LResultType = null)]
		LVM_SETGROUPMETRICS = LVM_FIRST + 155,

		/// <summary>
		/// Gets information about the display of groups.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to an</para>
		/// <para>**LVGROUPMETRICS**</para>
		/// <para>structure that receives the retrieved metrics.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getgroupmetrics
		[MsgParams(null, typeof(LVGROUPMETRICS?), LResultType = null)]
		LVM_GETGROUPMETRICS = LVM_FIRST + 156,

		/// <summary>
		/// Enables or disables whether the items in a list-view control display as a group.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A **BOOL** that indicates whether to enable a list-view control to group displayed items. Use **TRUE** to enable grouping,
		/// **FALSE** to disable it.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>0</c></term>
		/// <term>The ability to display list-view items as a group is already enabled or disabled.</term>
		/// </item>
		/// <item>
		/// <term><c>1</c></term>
		/// <term>The state of the control was successfully changed.</term>
		/// </item>
		/// <item>
		/// <term><c>-1</c></term>
		/// <term>The operation failed.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para><c>LVM_ENABLEGROUPVIEW</c> is not supported under the <c>LVS_OWNERDATA</c> style.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-enablegroupview
		[MsgParams(typeof(BOOL), null)]
		LVM_ENABLEGROUPVIEW = LVM_FIRST + 157,

		/// <summary>
		/// Uses an application-defined comparison function to sort groups by ID within a list-view control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Pointer to an application-defined comparison function, <c>LVGroupCompare</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>Void pointer to the application-defined information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns 1 if successful, or 0 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-sortgroups
		[MsgParams(typeof(LVGroupCompare), typeof(IntPtr), LResultType = typeof(BOOL))]
		LVM_SORTGROUPS = LVM_FIRST + 158,

		/// <summary>
		/// Inserts a group into an ordered list of groups.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Pointer to an <c>LVINSERTGROUPSORTED</c> structure that contains the group to insert.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The ordering of the list is based on the ID of the group. The order is defined by the application-defined ordering function,
		/// <c>LVGroupCompare</c>, that is passed in the <c>LVINSERTGROUPSORTED</c> structure by the wParam parameter.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-insertgroupsorted
		[MsgParams(typeof(LVINSERTGROUPSORTED?), null, LResultType = null)]
		LVM_INSERTGROUPSORTED = LVM_FIRST + 159,

		/// <summary>
		/// Removes all groups from a list-view control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-removeallgroups
		[MsgParams(LResultType = null)]
		LVM_REMOVEALLGROUPS = LVM_FIRST + 160,

		/// <summary>
		/// Determines whether the list-view control has a specified group.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>ID of the group.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be **NULL**.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if the list-view control has the specified group, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-hasgroup
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		LVM_HASGROUP = LVM_FIRST + 161,

		/// <summary>
		/// Gets the state for a specified group. Send this message explicitly or by using the <c>ListView_GetGroupState</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the group by <c>iGroupId</c> (see <c>LVGROUP</c> structure).</para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies the state values to retrieve. This is a combination of the flags listed for the <c>state</c> member of <c>LVGROUP</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the combination of state values that are set. For example, if lParam is LVGS_COLLAPSED and the value returned is zero,
		/// the LVGS_COLLAPSED state is not set. Zero is returned if the group is not found.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getgroupstate
		[MsgParams(typeof(int), typeof(ListViewGroupState), LResultType = typeof(ListViewGroupState))]
		LVM_GETGROUPSTATE = LVM_FIRST + 92,

		/// <summary>
		/// Gets the group that has the focus. Send this message explicitly or by using the <c>ListView_GetFocusedGroup</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the group with state of LVGS_FOCUSED, or -1 if there is no group with state of LVGS_FOCUSED.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getfocusedgroup
		[MsgParams(LResultType = typeof(ListViewGroupState))]
		LVM_GETFOCUSEDGROUP = LVM_FIRST + 93,

		/// <summary>
		/// Sets information that a list-view control uses in tile view.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>**LVTILEVIEWINFO**</c> structure that contains the information to set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-settileviewinfo
		[MsgParams(null, typeof(LVTILEVIEWINFO?), LResultType = typeof(BOOL))]
		LVM_SETTILEVIEWINFO = LVM_FIRST + 162,

		/// <summary>
		/// Retrieves information about a list-view control in tile view.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>**LVTILEVIEWINFO**</c> structure that receives the retrieved information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return value not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-gettileviewinfo
		[MsgParams(null, typeof(LVTILEVIEWINFO?), LResultType = null)]
		LVM_GETTILEVIEWINFO = LVM_FIRST + 163,

		/// <summary>
		/// Sets information for an existing tile of a list-view control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>**LVTILEINFO**</c> structure that contains the information to set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para><c>LVM_SETTILEINFO</c> is not supported under the <c>LVS_OWNERDATA</c> style.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-settileinfo
		[MsgParams(null, typeof(LVTILEINFO), LResultType = typeof(BOOL))]
		LVM_SETTILEINFO = LVM_FIRST + 164,

		/// <summary>
		/// Retrieves information about a tile in a list-view control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>**LVTILEINFO**</c> structure that receives the retrieved information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return value not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Tile view is a new way of arranging and displaying items in a list-view control. The other views are icon, small icon, details,
		/// and list.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-gettileinfo
		[MsgParams(null, typeof(LVTILEINFO), LResultType = null)]
		LVM_GETTILEINFO = LVM_FIRST + 165,

		/// <summary>
		/// Sets the insertion point to the defined position.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a</para>
		/// <para>LVINSERTMARK</para>
		/// <para>structure that specifies where to set the insertion point.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. <c>FALSE</c> is returned if the size in the <c>cbSize</c> member of
		/// the <c>LVINSERTMARK</c> structure does not equal the actual size of the structure, or when an insertion point does not apply in
		/// the current view.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An insertion point can only appear if the list-view control is in icon view, small icon view, or tile view, and is not in
		/// group-view mode.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setinsertmark
		[MsgParams(null, typeof(LVINSERTMARK?), LResultType = typeof(BOOL))]
		LVM_SETINSERTMARK = LVM_FIRST + 166,

		/// <summary>
		/// Retrieves the position of the insertion point.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a</para>
		/// <para>LVINSERTMARK</para>
		/// <para>structure that receives the position of the insertion point.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. <c>FALSE</c> is returned if the size in the <c>cbSize</c> member of
		/// the <c>LVINSERTMARK</c> structure does not equal the actual size of the structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An insertion point can appear only if the list-view control is in icon view, small icon view, or tile view, and is not in
		/// group-view mode.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getinsertmark
		[MsgParams(null, typeof(LVINSERTMARK?), LResultType = typeof(BOOL))]
		LVM_GETINSERTMARK = LVM_FIRST + 167,

		/// <summary>
		/// Retrieves the insertion point closest to a specified point.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Pointer to a **POINT** structure that contains the hit test coordinates.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an</para>
		/// <para>LVINSERTMARK</para>
		/// <para>structure that specifies the insertion point closest to the coordinates defined by the *wParam* parameter.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. <c>FALSE</c> is returned if the size in the <c>cbSize</c> member of
		/// the <c>LVINSERTMARK</c> structure does not equal the actual size of the structure, or when an insertion point does not apply in
		/// the current view.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An insertion point can only appear if the list-view control is in icon view, small icon view, or tile view and is not in
		/// group-view mode.
		/// </para>
		/// <para>If insertion points do not apply for the view, the <c>LVINSERTMARK</c> structure contains a -1 in the <c>iItem</c> member.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-insertmarkhittest
		[MsgParams(typeof(POINT?), typeof(LVINSERTMARK?), LResultType = typeof(BOOL))]
		LVM_INSERTMARKHITTEST = LVM_FIRST + 168,

		/// <summary>
		/// Retrieves the rectangle that bounds the insertion point.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a</para>
		/// <para>**RECT**</para>
		/// <para>structure that contains the coordinates of a rectangle that bounds the insertion point.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>0</c></term>
		/// <term>No insertion point found.</term>
		/// </item>
		/// <item>
		/// <term><c>1</c></term>
		/// <term>Insertion point found.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getinsertmarkrect
		[MsgParams(null, typeof(RECT?))]
		LVM_GETINSERTMARKRECT = LVM_FIRST + 169,

		/// <summary>
		/// Sets the color of the insertion point.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>**COLORREF** structure that specifies the color to set the insertion point.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>COLORREF</c> structure set to the previous color.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setinsertmarkcolor
		[MsgParams(null, typeof(COLORREF), LResultType = typeof(COLORREF))]
		LVM_SETINSERTMARKCOLOR = LVM_FIRST + 170,

		/// <summary>
		/// Retrieves the color of the insertion point.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>COLORREF</c> structure that contains the color of the insertion point.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getinsertmarkcolor
		[MsgParams(LResultType = typeof(COLORREF))]
		LVM_GETINSERTMARKCOLOR = LVM_FIRST + 171,

		/// <summary>
		/// Retrieves an integer that specifies the selected column.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns an <c>UINT</c> that specifies the selected column.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getselectedcolumn
		[MsgParams(LResultType = typeof(uint))]
		LVM_GETSELECTEDCOLUMN = LVM_FIRST + 174,

		/// <summary>
		/// Checks whether the list-view control has group view enabled.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if group view is enabled, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-isgroupviewenabled
		[MsgParams(LResultType = typeof(BOOL))]
		LVM_ISGROUPVIEWENABLED = LVM_FIRST + 175,

		/// <summary>
		/// Retrieves the color of the border of a list-view control if the <c>LVS_EX_BORDERSELECT</c> extended window style is set.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>COLORREF</c> structure that contains the color of the border of a list-view control.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getoutlinecolor
		[MsgParams(LResultType = typeof(COLORREF))]
		LVM_GETOUTLINECOLOR = LVM_FIRST + 176,

		/// <summary>
		/// Sets the color of the border of a list-view control if the <c>LVS_EX_BORDERSELECT</c> extended window style is set.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>**COLORREF** structure that specifies the color to set the border.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>COLORREF</c> structure that contains the outline color.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setoutlinecolor
		[MsgParams(null, typeof(COLORREF), LResultType = typeof(COLORREF))]
		LVM_SETOUTLINECOLOR = LVM_FIRST + 177,

		/// <summary>
		/// Cancels an item text editing operation.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// <para>This message causes a an LVN_ENDLABELEDIT notification to be sent.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-canceleditlabel
		[MsgParams(LResultType = null)]
		LVM_CANCELEDITLABEL = LVM_FIRST + 179,

		/// <summary>
		/// Maps the index of an item to a unique ID.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of an item.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a unique ID.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// List-view controls internally track items by index. This can present problems because indexes can change during the control's lifetime.
		/// </para>
		/// <para>
		/// The list-view control can tag an item with an ID when the item is created. You can use this ID to guarantee uniqueness during the
		/// lifetime of the list-view control.
		/// </para>
		/// <para>
		/// To uniquely identify an item, take the index that is returned from a call such as <c>IComponent::GetDisplayInfo</c> and call
		/// <c>LVM_MAPINDEXTOID</c>. The return value is a unique ID.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// In a multithreaded environment, the index is only guaranteed on the thread that hosts the list-view control, not on background threads.
		/// </para>
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-mapindextoid
		[MsgParams(typeof(int), null, LResultType = typeof(uint))]
		LVM_MAPINDEXTOID = LVM_FIRST + 180,

		/// <summary>
		/// Maps the ID of an item to an index.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The unique ID of an item.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the most current index.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// List-view controls internally track items by index. This can present problems because indexes can change during the control's lifetime.
		/// </para>
		/// <para>
		/// The list-view control can tag an item with an ID when the item is created. You can use this ID to guarantee uniqueness during the
		/// lifetime of the list-view control.
		/// </para>
		/// <para>
		/// To uniquely identify an item, take the index that is returned from a call such as <c>IComponent::GetDisplayInfo</c> and call
		/// <c>LVM_MAPINDEXTOID</c>. The return value is a unique ID.
		/// </para>
		/// <para>
		/// If you need the index of an item after an ID is created you can call <c>LVM_MAPIDTOINDEX</c> with the unique ID and it returns
		/// the most current index.
		/// </para>
		/// <para><c>LVM_MAPIDTOINDEX</c> is not supported under the <c>LVS_OWNERDATA</c> style.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// In a multithreaded environment, the index is only guaranteed on the thread that hosts the list-view control, not on background threads.
		/// </para>
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-mapidtoindex
		[MsgParams(typeof(uint), null)]
		LVM_MAPIDTOINDEX = LVM_FIRST + 181,

		/// <summary>
		/// Indicates if an item in the list-view control is visible. Send this message explicitly or by using the
		/// <c>ListView_IsItemVisible</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>An index of the item in the list-view control.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if visible, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-isitemvisible
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		LVM_ISITEMVISIBLE = LVM_FIRST + 182,

		/// <summary/>
		LVM_GETACCVERSION = LVM_FIRST + 193,

		/// <summary>
		/// Gets the text meant for display when the list-view control appears empty. Send this message explicitly or by using the
		/// <c>ListView_GetEmptyText</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The size of the buffer pointed to by lParam, including the terminating <c>NULL</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a null-terminated, Unicode buffer of size specified by wParam to receive the text. The caller is responsible for
		/// allocating the buffer.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getemptytext
		[MsgParams(typeof(uint), typeof(StrPtrUni), LResultType = typeof(BOOL))]
		LVM_GETEMPTYTEXT = LVM_FIRST + 204,

		/// <summary>
		/// Retrieves the coordinates of the footer for a list-view control. Send this message explicitly or by using the
		/// <c>ListView_GetFooterRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used. Must be 0.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>RECT</c> structure to receive the coordinates. The calling process is responsible for allocating this
		/// structure. The coordinates received are expressed as client coordinates.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getfooterrect
		[MsgParams(null, typeof(RECT?), LResultType = typeof(BOOL))]
		LVM_GETFOOTERRECT = LVM_FIRST + 205,

		/// <summary>
		/// Gets information about the footer of a list-view control. Send this message explicitly or by using the
		/// <c>ListView_GetFooterInfo</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used. Must be 0.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>LVFOOTERINFO</c> structure to receive information depending on the value of the <c>mask</c> member. The calling
		/// process is responsible for allocating this structure and setting the <c>mask</c> member.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c>.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getfooterinfo
		[MsgParams(null, typeof(LVFOOTERINFO?), LResultType = typeof(BOOL))]
		LVM_GETFOOTERINFO = LVM_FIRST + 206,

		/// <summary>
		/// Gets the coordinates of a footer for a specified item in a list-view control. Send this message explicitly or by using the
		/// <c>ListView_GetFooterItemRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the item in the list-view control.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>RECT</c> structure to receive the coordinates. The calling application is responsible for allocating this
		/// structure. The coordinates received are expressed as client coordinates.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getfooteritemrect
		[MsgParams(typeof(int), typeof(RECT?), LResultType = typeof(BOOL))]
		LVM_GETFOOTERITEMRECT = LVM_FIRST + 207,

		/// <summary>
		/// Gets information on a footer item in a list-view control. Send this message explicitly or by using the
		/// <c>ListView_GetFooterItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The index of the item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>LVFOOTERITEM</c> structure to receive a value for the <c>state</c> and/or <c>pszText</c> members according to
		/// the value of the <c>mask</c> member. The calling process is responsible for allocating this structure and setting its members to
		/// indicate to the receiver what information to return. For more information, see <c>LVFOOTERITEM</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getfooteritem
		[MsgParams(typeof(int), typeof(LVFOOTERITEM?), LResultType = typeof(BOOL))]
		LVM_GETFOOTERITEM = LVM_FIRST + 208,

		/// <summary>
		/// Retrieves the bounding rectangle for all or part of a subitem in the current view of a list-view control. Send this message
		/// explicitly or by using the <c>ListView_GetItemIndexRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A pointer to a <c>LVITEMINDEX</c> structure for the parent item of the subitem. The calling process is responsible for allocating
		/// this structure and setting its members. wParam must not be <c>NULL</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>RECT</c> structure to receive the coordinates. The calling process is responsible for allocating this
		/// structure. lParam must not be <c>NULL</c>. Set the <c>top</c> member to the index of the subitem. Set the <c>left</c> member to
		/// one of the following values, indicating the part of the subitem for which the bounding rectangle is to be retrieved.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>LVIR_BOUNDS</c></term>
		/// <term>Returns the bounding rectangle of the entire subitem, including the icon and label.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIR_ICON</c></term>
		/// <term>Returns the bounding rectangle of the icon or small icon of the subitem.</term>
		/// </item>
		/// <item>
		/// <term><c>LVIR_LABEL</c></term>
		/// <term>Returns the bounding rectangle of the subitem text.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getitemindexrect
		[MsgParams(typeof(LVITEMINDEX?), typeof(RECT?), LResultType = typeof(BOOL))]
		LVM_GETITEMINDEXRECT = LVM_FIRST + 209,

		/// <summary>
		/// Sets the state of a list-view item. Send this message explicitly or by using the <c>ListView_SetItemIndexState</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A pointer to an <c>LVITEMINDEX</c> structure for the item. The calling process is responsible for allocating this structure and
		/// setting the members.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to an <c>LVITEM</c> structure. The calling process is responsible for allocating memory for the structure. Set the
		/// <c>state</c> member to one or more (as a bitwise combination) of the List-View Item States flags. Set the <c>stateMask</c> member
		/// of the structure to indicate the valid bits of the <c>state</c> member. For more information, see the <c>stateMask</c> member of
		/// the <c>LVITEM</c> structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns one of the following values of type <c>HRESULT</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>E_FAIL</c></term>
		/// <term>The state could not be set.</term>
		/// </item>
		/// <item>
		/// <term><c>E_UNEXPECTED</c></term>
		/// <term>The list-view control was not ready for the operation.</term>
		/// </item>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation was successful.</term>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-setitemindexstate
		[MsgParams(typeof(LVITEMINDEX?), typeof(LVITEM), LResultType = typeof(HRESULT))]
		LVM_SETITEMINDEXSTATE = LVM_FIRST + 210,

		/// <summary>
		/// Retrieves the index of an item in a specified list-view control that matches the specified properties and relationship to another
		/// item. Send this message explicitly or by using the <c>ListView_GetNextItemIndex</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A pointer to the <c>LVITEMINDEX</c> structure for the item to begin the search with, or -1 to find the first item that matches
		/// the specified flags. The calling process is responsible for allocating this structure and setting its members.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies the relationship to the item listed in parameter wParam. This can be one or a combination of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Searches by index.</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term><c>LVNI_ALL</c></term>
		/// <term>Searches for a subsequent item by index, the default value.</term>
		/// </item>
		/// <item>
		/// <term>Searches by physical relationship to the index of the item where the search is to begin.</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term><c>LVNI_ABOVE</c></term>
		/// <term>Searches for an item that is above the specified item.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_BELOW</c></term>
		/// <term>Searches for an item that is below the specified item.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_TOLEFT</c></term>
		/// <term>Searches for an item to the left of the specified item.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_PREVIOUS</c></term>
		/// <term>
		/// <c>Windows Vista and later:</c> Searches for an item that is ordered before the item specified in <c>wParam</c>. The
		/// LVNI_PREVIOUS flag is not directional (LVNI_ABOVE will find the item positioned above, while LVNI_PREVIOUS will find the item
		/// ordered before.) The LVNI_PREVIOUS flag basically reverses the logic of the search performed by the LVM_GETNEXTITEM or
		/// LVM_GETNEXTITEMINDEX messages.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_TORIGHT</c></term>
		/// <term>Searches for an item to the right of the specified item.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_DIRECTIONMASK</c></term>
		/// <term>
		/// <c>Windows Vista and later:</c> A directional flag mask with value as follows: LVNI_ABOVE | LVNI_BELOW | LVNI_TOLEFT | LVNI_TORIGHT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The state of the item to find can be specified with one or a combination of the following values:</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term><c>LVNI_CUT</c></term>
		/// <term>The item has the <c>LVIS_CUT</c> state flag set.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_DROPHILITED</c></term>
		/// <term>The item has the <c>LVIS_DROPHILITED</c> state flag set</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_FOCUSED</c></term>
		/// <term>The item has the <c>LVIS_FOCUSED</c> state flag set.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_SELECTED</c></term>
		/// <term>The item has the <c>LVIS_SELECTED</c> state flag set.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_STATEMASK</c></term>
		/// <term><c>Windows Vista and later:</c> A state flag mask with value as follows: LVNI_FOCUSED | LVNI_SELECTED | LVNI_CUT | LVNI_DROPHILITED.</term>
		/// </item>
		/// <item>
		/// <term>Searches by appearance of items or by group.</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term><c>LVNI_VISIBLEORDER</c></term>
		/// <term><c>Windows Vista and later:</c> Search the visible order.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_VISIBLEONLY</c></term>
		/// <term><c>Windows Vista and later:</c> Search the visible items.</term>
		/// </item>
		/// <item>
		/// <term><c>LVNI_SAMEGROUPONLY</c></term>
		/// <term><c>Windows Vista and later:</c> Search the current group.</term>
		/// </item>
		/// <item>
		/// <term>If an item does not have all of the specified state flags set, the search continues with the next item.</term>
		/// <term/>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// Note that the following flags, for use only with Windows Vista, are mutually exclusive of any other flags in use: LVNI_PREVIOUS,
		/// LVNI_VISIBLEONLY, LVNI_SAMEGROUPONLY, LVNI_VISIBLEORDER, LVNI_DIRECTIONMASK, and LVNI_STATEMASK.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvm-getnextitemindex
		[MsgParams(typeof(LVITEMINDEX?), typeof(ListViewNextItemFlag), LResultType = typeof(BOOL))]
		LVM_GETNEXTITEMINDEX = LVM_FIRST + 211,

		/// <summary/>
		LVM_SETPRESERVEALPHA = LVM_FIRST + 212,

		/// <summary>Undocumented. Calls ResetEmptyText method; returns TRUE.</summary>
		LVM_RESETEMPTYTEXT = LVM_FIRST + 84,

		/// <summary>Undocumented. Returns indirect result of GetFocusedColumn method.</summary>
		LVM_GETFOCUSEDCOLUMN = LVM_FIRST + 186,

		/*LVM_SetBkImage               = SETBKIMAGEW,
		LVM_GetBkImage               = GETBKIMAGEW,*/
	}

	/// <summary>Specifies the relationship to the item listed in parameter wParam in LVM_GETNEXTITEMINDEX.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	[Flags]
	public enum ListViewNextItemFlag
	{
		/// <summary>Searches for a subsequent item by index, the default value.</summary>
		LVNI_ALL = 0X0000,

		/// <summary>The item has the LVIS_FOCUSED state flag set.</summary>
		LVNI_FOCUSED = 0X0001,

		/// <summary>The item has the LVIS_SELECTED state flag set.</summary>
		LVNI_SELECTED = 0X0002,

		/// <summary>The item has the LVIS_CUT state flag set.</summary>
		LVNI_CUT = 0X0004,

		/// <summary>The item has the LVIS_DROPHILITED state flag set</summary>
		LVNI_DROPHILITED = 0X0008,

		/// <summary>Windows Vista and later: A state flag mask with value as follows: LVNI_FOCUSED | LVNI_SELECTED | LVNI_CUT | LVNI_DROPHILITED.</summary>
		LVNI_STATEMASK = LVNI_FOCUSED | LVNI_SELECTED | LVNI_CUT | LVNI_DROPHILITED,

		/// <summary>Windows Vista and later: Search the visible order.</summary>
		LVNI_VISIBLEORDER = 0X0010,

		/// <summary>
		/// Windows Vista and later: Searches for an item that is ordered before the item specified in wParam. The LVNI_PREVIOUS flag is not
		/// directional (LVNI_ABOVE will find the item positioned above, while LVNI_PREVIOUS will find the item ordered before.) The
		/// LVNI_PREVIOUS flag basically reverses the logic of the search performed by the LVM_GETNEXTITEM or LVM_GETNEXTITEMINDEX messages.
		/// </summary>
		LVNI_PREVIOUS = 0X0020,

		/// <summary>Windows Vista and later: Search the visible items.</summary>
		LVNI_VISIBLEONLY = 0X0040,

		/// <summary>Windows Vista and later: Search the current group.</summary>
		LVNI_SAMEGROUPONLY = 0X0080,

		/// <summary>Searches for an item that is above the specified item.</summary>
		LVNI_ABOVE = 0X0100,

		/// <summary>Searches for an item that is below the specified item.</summary>
		LVNI_BELOW = 0X0200,

		/// <summary>Searches for an item to the left of the specified item.</summary>
		LVNI_TOLEFT = 0X0400,

		/// <summary>Searches for an item to the right of the specified item.</summary>
		LVNI_TORIGHT = 0X0800,

		/// <summary>Windows Vista and later: A directional flag mask with value as follows: LVNI_ABOVE | LVNI_BELOW | LVNI_TOLEFT | LVNI_TORIGHT.</summary>
		LVNI_DIRECTIONMASK = LVNI_ABOVE | LVNI_BELOW | LVNI_TOLEFT | LVNI_TORIGHT,
	}

	/// <summary>ListView notification identifiers.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	public enum ListViewNotification
	{
		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that a drag-and-drop operation involving the left mouse button is being initiated.
		/// This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_BEGINDRAG pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLISTVIEW</c> structure. The <c>iItem</c> member identifies the item being dragged, and the other members are zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-begindrag
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_BEGINDRAG = LVN_FIRST - 9,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window about the start of label editing for an item. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_BEGINLABELEDIT pdi = (LPNMLVDISPINFO) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure. The <c>item</c> member of this structure is an <c>LVITEM</c> structure whose
		/// <c>iItem</c> member identifies the item being edited. Note that subitems cannot be edited; the <c>iSubItem</c> member is always
		/// set to zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>To allow the user to edit the label, return <c>FALSE</c>.</para>
		/// <para>To prevent the user from editing the label, return <c>TRUE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When label editing begins, an edit control is created, positioned, and initialized. Before it is displayed, the list-view control
		/// sends its parent window an LVN_BEGINLABELEDIT notification code.
		/// </para>
		/// <para>
		/// To customize label editing, implement a handler for LVN_BEGINLABELEDIT and have it send an <c>LVM_GETEDITCONTROL</c> message to
		/// the list-view control. If a label is being edited, the return value will be a handle to the edit control. Use this handle to
		/// customize the edit control by sending the usual <c>EM_XXX</c> messages.
		/// </para>
		/// <para>When the user cancels or completes the editing, the parent window receives an LVN_ENDLABELEDIT notification code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-beginlabeledit
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_BEGINLABELEDIT = LVN_BEGINLABELEDITW,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window about the start of label editing for an item. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_BEGINLABELEDIT pdi = (LPNMLVDISPINFO) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure. The <c>item</c> member of this structure is an <c>LVITEM</c> structure whose
		/// <c>iItem</c> member identifies the item being edited. Note that subitems cannot be edited; the <c>iSubItem</c> member is always
		/// set to zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>To allow the user to edit the label, return <c>FALSE</c>.</para>
		/// <para>To prevent the user from editing the label, return <c>TRUE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When label editing begins, an edit control is created, positioned, and initialized. Before it is displayed, the list-view control
		/// sends its parent window an LVN_BEGINLABELEDIT notification code.
		/// </para>
		/// <para>
		/// To customize label editing, implement a handler for LVN_BEGINLABELEDIT and have it send an <c>LVM_GETEDITCONTROL</c> message to
		/// the list-view control. If a label is being edited, the return value will be a handle to the edit control. Use this handle to
		/// customize the edit control by sending the usual <c>EM_XXX</c> messages.
		/// </para>
		/// <para>When the user cancels or completes the editing, the parent window receives an LVN_ENDLABELEDIT notification code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-beginlabeledit
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_BEGINLABELEDITA = LVN_FIRST - 5,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window about the start of label editing for an item. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_BEGINLABELEDIT pdi = (LPNMLVDISPINFO) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure. The <c>item</c> member of this structure is an <c>LVITEM</c> structure whose
		/// <c>iItem</c> member identifies the item being edited. Note that subitems cannot be edited; the <c>iSubItem</c> member is always
		/// set to zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>To allow the user to edit the label, return <c>FALSE</c>.</para>
		/// <para>To prevent the user from editing the label, return <c>TRUE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When label editing begins, an edit control is created, positioned, and initialized. Before it is displayed, the list-view control
		/// sends its parent window an LVN_BEGINLABELEDIT notification code.
		/// </para>
		/// <para>
		/// To customize label editing, implement a handler for LVN_BEGINLABELEDIT and have it send an <c>LVM_GETEDITCONTROL</c> message to
		/// the list-view control. If a label is being edited, the return value will be a handle to the edit control. Use this handle to
		/// customize the edit control by sending the usual <c>EM_XXX</c> messages.
		/// </para>
		/// <para>When the user cancels or completes the editing, the parent window receives an LVN_ENDLABELEDIT notification code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-beginlabeledit
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_BEGINLABELEDITW = LVN_FIRST - 75,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that a drag-and-drop operation involving the right mouse button is being initiated.
		/// This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_BEGINRDRAG pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLISTVIEW</c> structure. The <c>iItem</c> member identifies the item being dragged, and the other members are zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-beginrdrag
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_BEGINRDRAG = LVN_FIRST - 11,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window when a scrolling operation starts. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_BEGINSCROLL pnmLVScroll = (LPNMLVSCROLL) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>NMLVSCROLL</c> structure that contains the horizontal or vertical position of where the scroll operation starts.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return value not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this notification code, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on
		/// manifests, see Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-beginscroll
		[CorrespondingType(typeof(NMLVSCROLL))]
		LVN_BEGINSCROLL = LVN_FIRST - 80,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that a column header was clicked while the list-view control was in report mode.
		/// This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_COLUMNCLICK pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLISTVIEW</c> structure. The <c>iItem</c> member is -1, and the <c>iSubItem</c> member identifies the column.
		/// All other members are zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// Using header control formats such as HDF_CHECKBOX to modify the format of column headers in a list-view control causes the
		/// control to send the HDN_ITEMSTATEICONCLICK notification code instead of LVN_COLUMNCLICK when a header item is clicked.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-columnclick
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_COLUMNCLICK = LVN_FIRST - 8,

		/// <summary>
		/// <para>
		/// Sent by a list-view control when the list-view's drop-down button is pressed. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_COLUMNDROPDOWN pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>NMLISTVIEW</c> structure that describes the notification code. The caller is responsible for allocating this
		/// structure, including the contained <c>NMHDR</c> structure. Set the members of the <c>NMHDR</c> structure. The <c>code</c> member
		/// must be set to LVN_COLUMNDROPDOWN.
		/// </para>
		/// <para>
		/// Set the <c>iItem</c> member of the <c>NMLISTVIEW</c> structure to -1. Set the <c>iSubItem</c> member to the index of the subitem.
		/// Set the <c>uNewState</c>, <c>uOldState</c>, and <c>lParam</c> members to zero. The remaining members of the <c>NMLISTVIEW</c>
		/// structure are not used.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The notification receiver casts lParam to retrieve the <c>NMLISTVIEW</c> structure. The wParam parameter contains the ID of the
		/// control that sends the notification code.
		/// </para>
		/// <para>
		/// If a header control is a child of the list-view, the header control should send this notidication code to the list-view control
		/// when the header control receives the HDN_DROPDOWN notification code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-columndropdown
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_COLUMNDROPDOWN = LVN_FIRST - 64,

		/// <summary>
		/// <para>
		/// Sent by a list-view control when its overflow button is clicked. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_COLUMNOVERFLOWCLICK pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>NMLISTVIEW</c> structure that describes the notification code. The caller is responsible for allocating this
		/// structure, including the contained <c>NMHDR</c> structure. Set the members of the <c>NMHDR</c> structure. The <c>code</c> member
		/// must be set to LVN_COLUMNOVERFLOWCLICK.
		/// </para>
		/// <para>
		/// Set the <c>iItem</c> member of the <c>NMLISTVIEW</c> structure to -1. Set the <c>iSubItem</c> member to the index of the subitem.
		/// Set the <c>uNewState</c>, <c>uOldState</c>, and <c>lParam</c> members to zero. The remaining members of the <c>NMLISTVIEW</c>
		/// structure are not used.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The notification receiver casts lParam to retrieve the <c>NMLISTVIEW</c> structure. The wParam parameter contains the ID of the
		/// control that sends the notification code.
		/// </para>
		/// <para>
		/// If a header control is a child of the listview, the header control should send this notification code to the listview control
		/// when the header control receives the HDN_OVERFLOWCLICK notification code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-columnoverflowclick
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_COLUMNOVERFLOWCLICK = LVN_FIRST - 66,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that all items in the control are about to be deleted. This notification code is
		/// sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_DELETEALLITEMS pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLISTVIEW</c> structure. The <c>iItem</c> member is -1, and the other members are zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>To suppress subsequent LVN_DELETEITEM notification codes, return <c>TRUE</c>.</para>
		/// <para>To receive subsequent LVN_DELETEITEM notification codes, return <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A list-view control sends the <c>LVM_DELETEALLITEMS</c> notification code when it is destroyed or when it receives the
		/// <c>LVM_DELETEALLITEMS</c> message. If <c>LVM_DELETEALLITEMS</c> does not return <c>TRUE</c>, the control will also send an
		/// LVN_DELETEITEM notification code as each item is deleted.
		/// </para>
		/// <para>
		/// If the <c>LVM_DELETEALLITEMS</c> message handler is in a dialog box procedure, return <c>TRUE</c> from the dialog box procedure,
		/// and use the <c>SetWindowLong</c> function with DWL_MSGRESULT to set the message return value.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-deleteallitems
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_DELETEALLITEMS = LVN_FIRST - 4,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that an item is about to be deleted. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_DELETEITEM pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLISTVIEW</c> structure. The <c>iItem</c> member identifies the item being deleted. If the control does not
		/// have the <c>LVS_OWNERDATA</c> style, then the lParam is the application-defined data associated with the item. All other members
		/// of this structure are zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>Do not add, delete, or rearrange items in the list view while processing this notification code.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-deleteitem
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_DELETEITEM = LVN_FIRST - 3,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window about the end of label editing for an item. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ENDLABELEDIT pdi = (LPNMLVDISPINFO) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure. The <c>item</c> member of this structure is an <c>LVITEM</c> structure whose
		/// <c>iItem</c> member identifies the item being edited. The <c>pszText</c> member of <c>item</c> contains a valid value when the
		/// LVN_ENDLABELEDIT notification code is sent, regardless of whether the LVIF_TEXT flag is set in the <c>mask</c> member of the
		/// <c>LVITEM</c> structure. If the user cancels editing, the <c>pszText</c> member of the <c>LVITEM</c> structure is <c>NULL</c>;
		/// otherwise, <c>pszText</c> is the address of the edited text.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the <c>pszText</c> member of the <c>LVITEM</c> structure is non- <c>NULL</c>, return <c>TRUE</c> to set the item's label to
		/// the edited text. Return <c>FALSE</c> to reject the edited text and revert to the original label.
		/// </para>
		/// <para>If the <c>pszText</c> member of the <c>LVITEM</c> structure is <c>NULL</c>, the return value is ignored.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The return value of the dialog procedure is whether the message was handled. The second return value must be set by calling
		/// <c>SetwindowLongPtr</c> with <c>DWLP_MSGRESULT</c>.
		/// </para>
		/// <para>
		/// When the user begins editing an item label, the parent window of the list-view control receives an LVN_BEGINLABELEDIT
		/// notification code. When the user cancels or completes the editing, the parent window receives an LVN_ENDLABELEDIT notification code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-endlabeledit
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_ENDLABELEDIT = LVN_ENDLABELEDITW,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window about the end of label editing for an item. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ENDLABELEDIT pdi = (LPNMLVDISPINFO) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure. The <c>item</c> member of this structure is an <c>LVITEM</c> structure whose
		/// <c>iItem</c> member identifies the item being edited. The <c>pszText</c> member of <c>item</c> contains a valid value when the
		/// LVN_ENDLABELEDIT notification code is sent, regardless of whether the LVIF_TEXT flag is set in the <c>mask</c> member of the
		/// <c>LVITEM</c> structure. If the user cancels editing, the <c>pszText</c> member of the <c>LVITEM</c> structure is <c>NULL</c>;
		/// otherwise, <c>pszText</c> is the address of the edited text.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the <c>pszText</c> member of the <c>LVITEM</c> structure is non- <c>NULL</c>, return <c>TRUE</c> to set the item's label to
		/// the edited text. Return <c>FALSE</c> to reject the edited text and revert to the original label.
		/// </para>
		/// <para>If the <c>pszText</c> member of the <c>LVITEM</c> structure is <c>NULL</c>, the return value is ignored.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The return value of the dialog procedure is whether the message was handled. The second return value must be set by calling
		/// <c>SetwindowLongPtr</c> with <c>DWLP_MSGRESULT</c>.
		/// </para>
		/// <para>
		/// When the user begins editing an item label, the parent window of the list-view control receives an LVN_BEGINLABELEDIT
		/// notification code. When the user cancels or completes the editing, the parent window receives an LVN_ENDLABELEDIT notification code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-endlabeledit
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_ENDLABELEDITA = LVN_FIRST - 6,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window about the end of label editing for an item. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ENDLABELEDIT pdi = (LPNMLVDISPINFO) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure. The <c>item</c> member of this structure is an <c>LVITEM</c> structure whose
		/// <c>iItem</c> member identifies the item being edited. The <c>pszText</c> member of <c>item</c> contains a valid value when the
		/// LVN_ENDLABELEDIT notification code is sent, regardless of whether the LVIF_TEXT flag is set in the <c>mask</c> member of the
		/// <c>LVITEM</c> structure. If the user cancels editing, the <c>pszText</c> member of the <c>LVITEM</c> structure is <c>NULL</c>;
		/// otherwise, <c>pszText</c> is the address of the edited text.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the <c>pszText</c> member of the <c>LVITEM</c> structure is non- <c>NULL</c>, return <c>TRUE</c> to set the item's label to
		/// the edited text. Return <c>FALSE</c> to reject the edited text and revert to the original label.
		/// </para>
		/// <para>If the <c>pszText</c> member of the <c>LVITEM</c> structure is <c>NULL</c>, the return value is ignored.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The return value of the dialog procedure is whether the message was handled. The second return value must be set by calling
		/// <c>SetwindowLongPtr</c> with <c>DWLP_MSGRESULT</c>.
		/// </para>
		/// <para>
		/// When the user begins editing an item label, the parent window of the list-view control receives an LVN_BEGINLABELEDIT
		/// notification code. When the user cancels or completes the editing, the parent window receives an LVN_ENDLABELEDIT notification code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-endlabeledit
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_ENDLABELEDITW = LVN_FIRST - 76,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window when a scrolling operation ends. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ENDSCROLL pnmLVScroll = (LPNMLVSCROLL) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>NMLVSCROLL</c> structure that contains the horizontal or vertical position of where the scroll operation ends.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return value not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this notification code, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on
		/// manifests, see Enabling Visual Styles.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-endscroll
		[CorrespondingType(typeof(NMLVSCROLL))]
		LVN_ENDSCROLL = LVN_FIRST - 81,

		/// <summary>
		/// <para>
		/// Sent by a list-view control to its parent window. It is a request for the parent window to provide information needed to display
		/// or sort a list-view item. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_GETDISPINFO pdi = (NMLVDISPINFO*) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure. On input, the <c>LVITEM</c> structure contained in this structure specifies the type
		/// of information required and identifies the item or subitem of interest. Use the <c>LVITEM</c> structure to return the requested
		/// information to the control. If your message handler sets the LVIF_DI_SETITEM flag in the <c>mask</c> member of the <c>LVITEM</c>
		/// structure, the list-view control stores the requested information and will not ask for it again.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The notification receiver casts lParam to retrieve the <c>NMLVDISPINFO</c> structure. The wParam parameter contains the
		/// notification code.
		/// </para>
		/// <para>
		/// A list-view control sends the <c>LVN_GETDISPINFO</c> notification code to retrieve item information that is stored by the
		/// application rather than the control. The information can be text or icon information for an item. It can also be item state
		/// information. See the <c>LVM_SETCALLBACKMASK</c> message for more information on implementing item state on a callback basis.
		/// </para>
		/// <para>For more information on list-view callbacks, see Callback Items and the Callback Mask.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-getdispinfo
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_GETDISPINFO = LVN_GETDISPINFOW,

		/// <summary>
		/// <para>
		/// Sent by a list-view control to its parent window. It is a request for the parent window to provide information needed to display
		/// or sort a list-view item. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_GETDISPINFO pdi = (NMLVDISPINFO*) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure. On input, the <c>LVITEM</c> structure contained in this structure specifies the type
		/// of information required and identifies the item or subitem of interest. Use the <c>LVITEM</c> structure to return the requested
		/// information to the control. If your message handler sets the LVIF_DI_SETITEM flag in the <c>mask</c> member of the <c>LVITEM</c>
		/// structure, the list-view control stores the requested information and will not ask for it again.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The notification receiver casts lParam to retrieve the <c>NMLVDISPINFO</c> structure. The wParam parameter contains the
		/// notification code.
		/// </para>
		/// <para>
		/// A list-view control sends the <c>LVN_GETDISPINFO</c> notification code to retrieve item information that is stored by the
		/// application rather than the control. The information can be text or icon information for an item. It can also be item state
		/// information. See the <c>LVM_SETCALLBACKMASK</c> message for more information on implementing item state on a callback basis.
		/// </para>
		/// <para>For more information on list-view callbacks, see Callback Items and the Callback Mask.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-getdispinfo
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_GETDISPINFOA = LVN_FIRST - 50,

		/// <summary>
		/// <para>
		/// Sent by a list-view control to its parent window. It is a request for the parent window to provide information needed to display
		/// or sort a list-view item. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_GETDISPINFO pdi = (NMLVDISPINFO*) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure. On input, the <c>LVITEM</c> structure contained in this structure specifies the type
		/// of information required and identifies the item or subitem of interest. Use the <c>LVITEM</c> structure to return the requested
		/// information to the control. If your message handler sets the LVIF_DI_SETITEM flag in the <c>mask</c> member of the <c>LVITEM</c>
		/// structure, the list-view control stores the requested information and will not ask for it again.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The notification receiver casts lParam to retrieve the <c>NMLVDISPINFO</c> structure. The wParam parameter contains the
		/// notification code.
		/// </para>
		/// <para>
		/// A list-view control sends the <c>LVN_GETDISPINFO</c> notification code to retrieve item information that is stored by the
		/// application rather than the control. The information can be text or icon information for an item. It can also be item state
		/// information. See the <c>LVM_SETCALLBACKMASK</c> message for more information on implementing item state on a callback basis.
		/// </para>
		/// <para>For more information on list-view callbacks, see Callback Items and the Callback Mask.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-getdispinfo
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_GETDISPINFOW = LVN_FIRST - 77,

		/// <summary>
		/// <para>
		/// Sent by list-view control to its parent window when the control has no items. The LVN_GETEMPTYMARKUP notification code is a
		/// request for the parent window to provide markup text. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_GETEMPTYMARKUP pnmMarkup = (NMLVEMPTYMARKUP*) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>NMLVEMPTYMARKUP</c> structure. Set the members of this structure to provide markup text for the list-view control.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return <c>TRUE</c> to set the markup text in the list-view control, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The notification receiver casts lParam to retrieve the <c>NMLVEMPTYMARKUP</c> structure. The wParam parameter contains the ID of
		/// the control that sends this message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-getemptymarkup
		[CorrespondingType(typeof(NMLVEMPTYMARKUP))]
		LVN_GETEMPTYMARKUP = LVN_FIRST - 87,

		/// <summary>
		/// <para>
		/// Sent by a large icon view list-view control that has the <c>LVS_EX_INFOTIP</c> extended style. This notification code is sent
		/// when the list-view control is requesting additional text information to be displayed in a tooltip. It is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_GETINFOTIP pGetInfoTip = (LPNMLVGETINFOTIP) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVGETINFOTIP</c> structure that contains information about this notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value for this notification is not used.</para>
		/// </summary>
		/// <remarks>
		/// This notification code is only sent by list-view controls that have the <c>LVS_EX_INFOTIP</c> extended style. The LVN_GETINFOTIP
		/// notification code is sent only for subitem 0.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-getinfotip
		[CorrespondingType(typeof(NMLVGETINFOTIP))]
		LVN_GETINFOTIP = LVN_GETINFOTIPW,

		/// <summary>
		/// <para>
		/// Sent by a large icon view list-view control that has the <c>LVS_EX_INFOTIP</c> extended style. This notification code is sent
		/// when the list-view control is requesting additional text information to be displayed in a tooltip. It is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_GETINFOTIP pGetInfoTip = (LPNMLVGETINFOTIP) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVGETINFOTIP</c> structure that contains information about this notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value for this notification is not used.</para>
		/// </summary>
		/// <remarks>
		/// This notification code is only sent by list-view controls that have the <c>LVS_EX_INFOTIP</c> extended style. The LVN_GETINFOTIP
		/// notification code is sent only for subitem 0.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-getinfotip
		[CorrespondingType(typeof(NMLVGETINFOTIP))]
		LVN_GETINFOTIPA = LVN_FIRST - 57,

		/// <summary>
		/// <para>
		/// Sent by a large icon view list-view control that has the <c>LVS_EX_INFOTIP</c> extended style. This notification code is sent
		/// when the list-view control is requesting additional text information to be displayed in a tooltip. It is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_GETINFOTIP pGetInfoTip = (LPNMLVGETINFOTIP) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVGETINFOTIP</c> structure that contains information about this notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value for this notification is not used.</para>
		/// </summary>
		/// <remarks>
		/// This notification code is only sent by list-view controls that have the <c>LVS_EX_INFOTIP</c> extended style. The LVN_GETINFOTIP
		/// notification code is sent only for subitem 0.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-getinfotip
		[CorrespondingType(typeof(NMLVGETINFOTIP))]
		LVN_GETINFOTIPW = LVN_FIRST - 58,

		/// <summary>
		/// <para>
		/// Sent by a list-view control when the user moves the mouse over an item. This notification code is only sent by list-view controls
		/// that have the <c>LVS_EX_TRACKSELECT</c> extended list-view style. It is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_HOTTRACK lpnmlv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLISTVIEW</c> structure that contains information about this notification code. The <c>iItem</c>,
		/// <c>iSubItem</c>, and <c>ptAction</c> members of this structure contain information about the item. The receiving application can
		/// modify the <c>iItem</c> member to specify the item that will be selected. If <c>iItem</c> is set to -1, no item will be selected.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Return zero to allow the list view to perform its normal track select processing. If the application returns nonzero, the item
		/// will not be selected.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-hottrack
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_HOTTRACK = LVN_FIRST - 21,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that an incremental search has started. This notification code is sent in the form
		/// of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_INCREMENTALSEARCH pnmv = (LPNMLVFINDITEM) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>NMLVFINDITEM</c> structure that describes the notification code. The caller is responsible for allocating this
		/// structure, including the contained <c>NMHDR</c> and <c>LVFINDINFO</c> structures. Set the members of the <c>NMHDR</c> structure.
		/// The <c>code</c> member must be set to LVN_INCREMENTALSEARCH.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The notification receiver casts lParam to retrieve the <c>NMLVFINDITEM</c> structure. The wParam parameter contains the ID of the
		/// control that sends this notification code.
		/// </para>
		/// <para>
		/// This notification code gives an application (or the notification receiver) the opportunity to customize an incremental search.
		/// For example, if the search items are numeric, the application can perform a numerical search instead of a string search.
		/// </para>
		/// <para>
		/// The application sets the <c>lParam</c> member of the <c>LVFINDINFO</c> structure contained in <c>NMLVFINDITEM</c> structure to
		/// the result of the search, or to another application defined value to fail the search and indicate to the control how to proceed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-incrementalsearch
		[CorrespondingType(typeof(NMLVFINDITEM))]
		LVN_INCREMENTALSEARCH = LVN_INCREMENTALSEARCHW,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that an incremental search has started. This notification code is sent in the form
		/// of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_INCREMENTALSEARCH pnmv = (LPNMLVFINDITEM) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>NMLVFINDITEM</c> structure that describes the notification code. The caller is responsible for allocating this
		/// structure, including the contained <c>NMHDR</c> and <c>LVFINDINFO</c> structures. Set the members of the <c>NMHDR</c> structure.
		/// The <c>code</c> member must be set to LVN_INCREMENTALSEARCH.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The notification receiver casts lParam to retrieve the <c>NMLVFINDITEM</c> structure. The wParam parameter contains the ID of the
		/// control that sends this notification code.
		/// </para>
		/// <para>
		/// This notification code gives an application (or the notification receiver) the opportunity to customize an incremental search.
		/// For example, if the search items are numeric, the application can perform a numerical search instead of a string search.
		/// </para>
		/// <para>
		/// The application sets the <c>lParam</c> member of the <c>LVFINDINFO</c> structure contained in <c>NMLVFINDITEM</c> structure to
		/// the result of the search, or to another application defined value to fail the search and indicate to the control how to proceed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-incrementalsearch
		[CorrespondingType(typeof(NMLVFINDITEM))]
		LVN_INCREMENTALSEARCHA = LVN_FIRST - 62,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that an incremental search has started. This notification code is sent in the form
		/// of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_INCREMENTALSEARCH pnmv = (LPNMLVFINDITEM) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>NMLVFINDITEM</c> structure that describes the notification code. The caller is responsible for allocating this
		/// structure, including the contained <c>NMHDR</c> and <c>LVFINDINFO</c> structures. Set the members of the <c>NMHDR</c> structure.
		/// The <c>code</c> member must be set to LVN_INCREMENTALSEARCH.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The notification receiver casts lParam to retrieve the <c>NMLVFINDITEM</c> structure. The wParam parameter contains the ID of the
		/// control that sends this notification code.
		/// </para>
		/// <para>
		/// This notification code gives an application (or the notification receiver) the opportunity to customize an incremental search.
		/// For example, if the search items are numeric, the application can perform a numerical search instead of a string search.
		/// </para>
		/// <para>
		/// The application sets the <c>lParam</c> member of the <c>LVFINDINFO</c> structure contained in <c>NMLVFINDITEM</c> structure to
		/// the result of the search, or to another application defined value to fail the search and indicate to the control how to proceed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-incrementalsearch
		[CorrespondingType(typeof(NMLVFINDITEM))]
		LVN_INCREMENTALSEARCHW = LVN_FIRST - 63,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that a new item was inserted. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_INSERTITEM pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLISTVIEW</c> structure. The <c>iItem</c> member identifies the new item, and the other members are zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-insertitem
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_INSERTITEM = LVN_FIRST - 2,

		/// <summary>
		/// <para>
		/// Sent by a list-view control when the user activates an item. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ITEMACTIVATE #if (_WIN32_IE &gt;= 0x0400) lpnmia = (LPNMITEMACTIVATE)lParam; #else lpnm = (LPNMHDR)lParam; #endif</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Version 4.71. Pointer to an <c>NMITEMACTIVATE</c> structure that contains information about this notification code.</para>
		/// <para>Version 4.70 and earlier. Pointer to an <c>NMHDR</c> structure that contains information about this notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The application receiving this notification code must return zero.</para>
		/// </summary>
		/// <remarks>
		/// To obtain the items being activated, the receiving application should use the <c>LVM_GETSELECTEDCOUNT</c> message to retrieve the
		/// number of items that are selected and then send the <c>LVM_GETNEXTITEM</c> message with <c>LVNI_SELECTED</c> until all of the
		/// items have been retrieved.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-itemactivate
		[CorrespondingType(typeof(NMITEMACTIVATE))]
		LVN_ITEMACTIVATE = LVN_FIRST - 14,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that an item has changed. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ITEMCHANGED pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLISTVIEW</c> structure that identifies the item and specifies which of its attributes have changed. If the
		/// <c>iItem</c> member of the structure pointed to by lParam is -1, the change has been applied to all items in the list view.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// If a list-view control has the <c>LVS_OWNERDATA</c> style, and the user selects a range of items by holding down the SHIFT key
		/// and clicking the mouse, LVN_ITEMCHANGED notification codes are not sent for each selected or deselected item. Instead, you will
		/// receive a single LVN_ODSTATECHANGED notification code, indicating that a range of items has changed state.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-itemchanged
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_ITEMCHANGED = LVN_FIRST - 1,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that an item is changing. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ITEMCHANGING pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLISTVIEW</c> structure that identifies the item and specifies which of its attributes are changing.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> to prevent the change, or <c>FALSE</c> to allow the change.</para>
		/// </summary>
		/// <remarks>If the list-view control has the <c>LVS_OWNERDATA</c> style, LVN_ITEMCHANGING notification codes are not sent.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-itemchanging
		[CorrespondingType(typeof(NMLISTVIEW))]
		LVN_ITEMCHANGING = LVN_FIRST - 0,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that a key has been pressed. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_KEYDOWN pnkd = (LPNMLVKEYDOWN) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVKEYDOWN</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-keydown
		[CorrespondingType(typeof(NMLVKEYDOWN))]
		LVN_KEYDOWN = LVN_FIRST - 55,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that a link has been clicked on. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_LINKCLICK pLinkInfo = (NMLVLINK*) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVLINK</c> structure. The identifier of the group containing the link is in the <c>iSubItem</c> member.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The following example shows how an application might respond to this notification code in its <c>WM_NOTIFY</c> message handler.
		/// The example toggles the collapsed state of the group and sets the appropriate link text.
		/// </para>
		/// <para>
		/// <code>case LVN_LINKCLICK: { NMLVLINK* pLinkInfo = (NMLVLINK*)lParam; HWND hList = pLinkInfo-&gt;hdr.hwndFrom; LVGROUP groupInfo; groupInfo.cbSize = sizeof(groupInfo); groupInfo.mask = LVGF_TASK; int groupIndex = pLinkInfo-&gt;iSubItem; if (ListView_GetGroupState(hList, groupIndex, LVGS_COLLAPSED)) { ListView_SetGroupState(hList, groupIndex, LVGS_COLLAPSED, 0); groupInfo.pszTask = L"Hide"; } else { ListView_SetGroupState(hList, groupIndex, LVGS_COLLAPSED, LVGS_COLLAPSED); groupInfo.pszTask = L"Show"; } ListView_SetGroupInfo(hList, groupIndex, &amp;groupInfo); break; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-linkclick
		[CorrespondingType(typeof(NMLVLINK))]
		LVN_LINKCLICK = LVN_FIRST - 84,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that a bounding box (marquee) selection has begun. This notification code is sent in
		/// the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_MARQUEEBEGIN pnmv = (LPNMLISTVIEW) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMHDR</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>To accept the notification code, return zero. To quit the bounding box selection, return nonzero.</para>
		/// </summary>
		/// <remarks>
		/// A bounding box selection is the process of clicking the list-view window's client area and dragging to select multiple items simultaneously.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-marqueebegin
		[CorrespondingType(typeof(NMHDR))]
		LVN_MARQUEEBEGIN = LVN_FIRST - 56,

		/// <summary>
		/// <para>
		/// Sent by a virtual list-view control when the contents of its display area have changed. For example, a list-view control sends
		/// this notification code when the user scrolls the control's display. The LVN_ODCACHEHINT notification code is sent in the form of
		/// a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ODCACHEHINT pCachehint = (NMLVCACHEHINT *) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVCACHEHINT</c> structure containing information about the range of items to be cached.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The application receiving this notification code must return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Handling this message allows the application to update the item information held in cache so that it is readily available when an
		/// LVN_GETDISPINFO notification code is sent.
		/// </para>
		/// <para>
		/// Note that this notification code is not always an exact representation of the items that will be requested by LVN_GETDISPINFO.
		/// Therefore, if the requested item is not cached while handling LVN_GETDISPINFO, the application must be prepared to supply the
		/// requested information from a source outside the cache.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-odcachehint
		[CorrespondingType(typeof(NMLVCACHEHINT))]
		LVN_ODCACHEHINT = LVN_FIRST - 13,

		/// <summary>
		/// <para>
		/// Sent by a virtual list-view control when it needs the owner to find a particular callback item. For example, the control will
		/// send this notification code when it receives shortcut keyboard input or when it receives an <c>LVM_FINDITEM</c> message. The
		/// LVN_ODFINDITEM notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ODFINDITEM pFindInfo = (PNMLVFINDITEM) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVFINDITEM</c> structure that includes information to be used for the search.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return the index of the item found, or -1 if no item is found.</para>
		/// </summary>
		/// <remarks>
		/// Search information is sent in the form of an <c>LVFINDINFO</c> structure, which is a member of the <c>NMLVFINDITEM</c> structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-odfinditem
		[CorrespondingType(typeof(NMLVFINDITEM))]
		LVN_ODFINDITEM = LVN_ODFINDITEMW,

		/// <summary>
		/// <para>
		/// Sent by a virtual list-view control when it needs the owner to find a particular callback item. For example, the control will
		/// send this notification code when it receives shortcut keyboard input or when it receives an <c>LVM_FINDITEM</c> message. The
		/// LVN_ODFINDITEM notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ODFINDITEM pFindInfo = (PNMLVFINDITEM) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVFINDITEM</c> structure that includes information to be used for the search.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return the index of the item found, or -1 if no item is found.</para>
		/// </summary>
		/// <remarks>
		/// Search information is sent in the form of an <c>LVFINDINFO</c> structure, which is a member of the <c>NMLVFINDITEM</c> structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-odfinditem
		[CorrespondingType(typeof(NMLVFINDITEM))]
		LVN_ODFINDITEMA = LVN_FIRST - 52,

		/// <summary>
		/// <para>
		/// Sent by a virtual list-view control when it needs the owner to find a particular callback item. For example, the control will
		/// send this notification code when it receives shortcut keyboard input or when it receives an <c>LVM_FINDITEM</c> message. The
		/// LVN_ODFINDITEM notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ODFINDITEM pFindInfo = (PNMLVFINDITEM) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVFINDITEM</c> structure that includes information to be used for the search.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return the index of the item found, or -1 if no item is found.</para>
		/// </summary>
		/// <remarks>
		/// Search information is sent in the form of an <c>LVFINDINFO</c> structure, which is a member of the <c>NMLVFINDITEM</c> structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-odfinditem
		[CorrespondingType(typeof(NMLVFINDITEM))]
		LVN_ODFINDITEMW = LVN_FIRST - 79,

		/// <summary>
		/// <para>
		/// Sent by a list-view control when the state of an item or range of items has changed. This notification code is sent in the form
		/// of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_ODSTATECHANGED lpStateChange = (LPNMLVODSTATECHANGE) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMLVODSTATECHANGE</c> structure that contains information about the item or items that have changed.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The application receiving this notification code must return zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-odstatechanged
		[CorrespondingType(typeof(NMLVODSTATECHANGE))]
		LVN_ODSTATECHANGED = LVN_FIRST - 15,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that it must update the information it maintains for an item. This notification code
		/// is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_SETDISPINFO pdi = (NMLVDISPINFO*) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure that specifies information for the changed item. The <c>item</c> member of this
		/// structure is an <c>LVITEM</c> structure that contains information about the item that was changed. The <c>pszText</c> member of
		/// <c>item</c> contains a valid value, regardless of whether the LVIF_TEXT flag is set in the <c>mask</c> member of this structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// The notification receiver casts lParam to retrieve the <c>NMLVDISPINFO</c> structure. The wParam parameter contains the message code.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-setdispinfo
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_SETDISPINFO = LVN_SETDISPINFOW,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that it must update the information it maintains for an item. This notification code
		/// is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_SETDISPINFO pdi = (NMLVDISPINFO*) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure that specifies information for the changed item. The <c>item</c> member of this
		/// structure is an <c>LVITEM</c> structure that contains information about the item that was changed. The <c>pszText</c> member of
		/// <c>item</c> contains a valid value, regardless of whether the LVIF_TEXT flag is set in the <c>mask</c> member of this structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// The notification receiver casts lParam to retrieve the <c>NMLVDISPINFO</c> structure. The wParam parameter contains the message code.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-setdispinfo
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_SETDISPINFOA = LVN_FIRST - 51,

		/// <summary>
		/// <para>
		/// Notifies a list-view control's parent window that it must update the information it maintains for an item. This notification code
		/// is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>LVN_SETDISPINFO pdi = (NMLVDISPINFO*) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMLVDISPINFO</c> structure that specifies information for the changed item. The <c>item</c> member of this
		/// structure is an <c>LVITEM</c> structure that contains information about the item that was changed. The <c>pszText</c> member of
		/// <c>item</c> contains a valid value, regardless of whether the LVIF_TEXT flag is set in the <c>mask</c> member of this structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// The notification receiver casts lParam to retrieve the <c>NMLVDISPINFO</c> structure. The wParam parameter contains the message code.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/lvn-setdispinfo
		[CorrespondingType(typeof(NMLVDISPINFO))]
		LVN_SETDISPINFOW = LVN_FIRST - 78,
	}

	/// <summary>The following window styles are specific to list-view controls.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	[Flags]
	public enum ListViewStyle : uint
	{
		/// <summary>Items are left-aligned in icon and small icon view.</summary>
		LVS_ALIGNLEFT = 0x0800,

		/// <summary>The control's current alignment.</summary>
		LVS_ALIGNMASK = 0x0c00,

		/// <summary>Items are aligned with the top of the list-view control in icon and small icon view.</summary>
		LVS_ALIGNTOP = 0x0000,

		/// <summary>Icons are automatically kept arranged in icon and small icon view.</summary>
		LVS_AUTOARRANGE = 0x0100,

		/// <summary>Item text can be edited in place. The parent window must process the LVN_ENDLABELEDIT notification code.</summary>
		LVS_EDITLABELS = 0x0200,

		/// <summary>This style specifies icon view.</summary>
		LVS_ICON = 0x0000,

		/// <summary>This style specifies list view.</summary>
		LVS_LIST = 0x0003,

		/// <summary>Column headers are not displayed in report view. By default, columns have headers in report view.</summary>
		LVS_NOCOLUMNHEADER = 0x4000,

		/// <summary>Item text is displayed on a single line in icon view. By default, item text may wrap in icon view.</summary>
		LVS_NOLABELWRAP = 0x0080,

		/// <summary>
		/// Scrolling is disabled. All items must be within the client area. This style is not compatible with the LVS_LIST or LVS_REPORT
		/// styles. See Knowledge Base Article Q137520 for further discussion.
		/// </summary>
		LVS_NOSCROLL = 0x2000,

		/// <summary>
		/// Column headers do not work like buttons. This style can be used if clicking a column header in report view does not carry out an
		/// action, such as sorting.
		/// </summary>
		LVS_NOSORTHEADER = 0x8000,

		/// <summary>
		/// Version 4.70. This style specifies a virtual list-view control. For more information about this list control style, see About
		/// List-View Controls.
		/// </summary>
		LVS_OWNERDATA = 0x1000,

		/// <summary>
		/// The owner window can paint items in report view. The list-view control sends a WM_DRAWITEM message to paint each item; it does
		/// not send separate messages for each subitem. The iItemData member of the DRAWITEMSTRUCT structure contains the item data for the
		/// specified list-view item.
		/// </summary>
		LVS_OWNERDRAWFIXED = 0x0400,

		/// <summary>
		/// This style specifies report view. When using the LVS_REPORT style with a list-view control, the first column is always
		/// left-aligned. You cannot use LVCFMT_RIGHT to change this alignment. See LVCOLUMN for further information on column alignment.
		/// </summary>
		LVS_REPORT = 0x0001,

		/// <summary>
		/// The image list will not be deleted when the control is destroyed. This style enables the use of the same image lists with
		/// multiple list-view controls.
		/// </summary>
		LVS_SHAREIMAGELISTS = 0x0040,

		/// <summary>The selection, if any, is always shown, even if the control does not have the focus.</summary>
		LVS_SHOWSELALWAYS = 0x0008,

		/// <summary>Only one item at a time can be selected. By default, multiple items may be selected.</summary>
		LVS_SINGLESEL = 0x0004,

		/// <summary>This style specifies small icon view.</summary>
		LVS_SMALLICON = 0x0002,

		/// <summary>Item indexes are sorted based on item text in ascending order.</summary>
		LVS_SORTASCENDING = 0x0010,

		/// <summary>Item indexes are sorted based on item text in descending order.</summary>
		LVS_SORTDESCENDING = 0x0020,

		/// <summary>Determines the control's current window style.</summary>
		LVS_TYPEMASK = 0x0003,

		/// <summary>Determines the window styles that control item alignment and header appearance and behavior.</summary>
		LVS_TYPESTYLEMASK = 0xfc00,
	}

	/// <summary>
	/// Extended List-View Styles. Use the LVM_SETEXTENDEDLISTVIEWSTYLE message or one of the ListView_SetExtendedListViewStyle or
	/// ListView_SetExtendedListViewStyleEx macros to employ these extended list-view control styles.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	[Flags]
	public enum ListViewStyleEx : uint
	{
		/// <summary>Windows Vista and later. Automatically arrange icons if no icon positions have been set (Similar to LVS_AUTOARRANGE).</summary>
		LVS_EX_AUTOAUTOARRANGE = 0X01000000,

		/// <summary>Windows Vista and later. Automatically select check boxes on single click.</summary>
		LVS_EX_AUTOCHECKSELECT = 0X08000000,

		/// <summary>Windows Vista and later. Automatically size listview columns.</summary>
		LVS_EX_AUTOSIZECOLUMNS = 0X10000000,

		/// <summary>Version 4.71 and later. Changes border color when an item is selected, instead of highlighting the item.</summary>
		LVS_EX_BORDERSELECT = 0X00008000,

		/// <summary>
		/// Version 4.70. Enables check boxes for items in a list-view control. When set to this style, the control creates and sets a state
		/// image list with two images using DrawFrameControl. State image 1 is the unchecked box, and state image 2 is the checked box.
		/// Setting the state image to zero removes the check box.
		/// <para>
		/// Version 6.00 and later Check boxes are visible and functional with all list view modes except the tile view mode introduced in
		/// ComCtl32.dll version 6. Clicking a checkbox in tile view mode only selects the item; the state does not change.
		/// </para>
		/// <para>
		/// You can obtain the state of the check box for a given item with ListView_GetCheckState. To set the check state, use
		/// ListView_SetCheckState. If this style is set, the list-view control automatically toggles the check state when the user clicks
		/// the check box or presses the space bar.
		/// </para>
		/// </summary>
		LVS_EX_CHECKBOXES = 0X00000004,

		/// <summary>
		/// Indicates that an overflow button should be displayed in icon/tile view if there is not enough client width to display the
		/// complete set of header items. The list-view control sends the LVN_COLUMNOVERFLOWCLICK notification when the overflow button is
		/// clicked. This flag is only valid when LVS_EX_HEADERINALLVIEWS is also specified.
		/// </summary>
		LVS_EX_COLUMNOVERFLOW = 0X80000000,

		/// <summary>Windows Vista and later. Snap to minimum column width when the user resizes a column.</summary>
		LVS_EX_COLUMNSNAPPOINTS = 0X40000000,

		/// <summary>
		/// Version 6.00 and later. Paints via double-buffering, which reduces flicker. This extended style also enables alpha-blended
		/// marquee selection on systems where it is supported.
		/// </summary>
		LVS_EX_DOUBLEBUFFER = 0X00010000,

		/// <summary>
		/// Enables flat scroll bars in the list view. If you need more control over the appearance of the list view's scroll bars, you
		/// should manipulate the list view's scroll bars directly using the Flat Scroll Bar APIs. If the system metrics change, you are
		/// responsible for adjusting the scroll bar metrics with FlatSB_SetScrollProp. See Flat Scroll Bars for further details.
		/// </summary>
		LVS_EX_FLATSB = 0X00000100,

		/// <summary>
		/// When an item is selected, the item and all its subitems are highlighted. This style is available only in conjunction with the
		/// LVS_REPORT style.
		/// </summary>
		LVS_EX_FULLROWSELECT = 0X00000020,

		/// <summary>Displays gridlines around items and subitems. This style is available only in conjunction with the LVS_REPORT style.</summary>
		LVS_EX_GRIDLINES = 0X00000001,

		/// <summary>
		/// Enables drag-and-drop reordering of columns in a list-view control. This style is only available to list-view controls that use
		/// the LVS_REPORT style.
		/// </summary>
		LVS_EX_HEADERDRAGDROP = 0X00000010,

		/// <summary>Windows Vista and later. Show column headers in all view modes.</summary>
		LVS_EX_HEADERINALLVIEWS = 0X02000000,

		/// <summary>Version 6.00 and later. Hides the labels in icon and small icon view.</summary>
		LVS_EX_HIDELABELS = 0X00020000,

		/// <summary>
		/// When a list-view control uses the LVS_EX_INFOTIP style, the LVN_GETINFOTIP notification code is sent to the parent window before
		/// displaying an item's tooltip.
		/// </summary>
		LVS_EX_INFOTIP = 0X00000400,

		/// <summary>Windows Vista and later. Icons are lined up in columns that use up the whole view.</summary>
		LVS_EX_JUSTIFYCOLUMNS = 0X00200000,

		/// <summary>
		/// If a partially hidden label in any list view mode lacks tooltip text, the list-view control will unfold the label. If this style
		/// is not set, the list-view control will unfold partly hidden labels only for the large icon mode.
		/// </summary>
		LVS_EX_LABELTIP = 0X00004000,

		/// <summary>
		/// If the list-view control has the LVS_AUTOARRANGE style, the control will not autoarrange its icons until one or more work areas
		/// are defined (see LVM_SETWORKAREAS). To be effective, this style must be set before any work areas are defined and any items have
		/// been added to the control.
		/// </summary>
		LVS_EX_MULTIWORKAREAS = 0X00002000,

		/// <summary>
		/// The list-view control sends an LVN_ITEMACTIVATE notification code to the parent window when the user clicks an item. This style
		/// also enables hot tracking in the list-view control. Hot tracking means that when the cursor moves over an item, it is highlighted
		/// but not selected. See the Extended List-View Styles Remarks section for a discussion of item activation.
		/// </summary>
		LVS_EX_ONECLICKACTIVATE = 0X00000040,

		/// <summary>
		/// Version 4.71 through Version 5.80 only. Not supported on Windows Vista and later. Sets the list view window region to include
		/// only the item icons and text using SetWindowRgn. Any area that is not part of an item is excluded from the window region. This
		/// style is only available to list-view controls that use the LVS_ICON style.
		/// </summary>
		LVS_EX_REGIONAL = 0X00000200,

		/// <summary>
		/// Version 6.00 and later. In icon view, moves the state image of the control to the top right of the large icon rendering. In views
		/// other than icon view there is no change. When the user changes the state by using the space bar, all selected items cycle over,
		/// not the item with the focus.
		/// </summary>
		LVS_EX_SIMPLESELECT = 0X00100000,

		/// <summary>Version 6.00 and later. Not used.</summary>
		LVS_EX_SINGLEROW = 0X00040000,

		/// <summary>Version 6.00 and later. In icon view, icons automatically snap into a grid.</summary>
		LVS_EX_SNAPTOGRID = 0X00080000,

		/// <summary>Allows images to be displayed for subitems. This style is available only in conjunction with the LVS_REPORT style.</summary>
		LVS_EX_SUBITEMIMAGES = 0X00000002,

		/// <summary>
		/// Enables hot-track selection in a list-view control. Hot track selection means that an item is automatically selected when the
		/// cursor remains over the item for a certain period of time. The delay can be changed from the default system setting with a
		/// LVM_SETHOVERTIME message. This style applies to all styles of list-view control. You can check whether hot-track selection is
		/// enabled by calling SystemParametersInfo.
		/// </summary>
		LVS_EX_TRACKSELECT = 0X00000008,

		/// <summary>Windows Vista and later. Background is painted by the parent via WM_PRINTCLIENT.</summary>
		LVS_EX_TRANSPARENTBKGND = 0X00400000,

		/// <summary>Windows Vista and later. Enable shadow text on transparent backgrounds only.</summary>
		LVS_EX_TRANSPARENTSHADOWTEXT = 0X00800000,

		/// <summary>
		/// The list-view control sends an LVN_ITEMACTIVATE notification code to the parent window when the user double-clicks an item. This
		/// style also enables hot tracking in the list-view control. Hot tracking means that when the cursor moves over an item, it is
		/// highlighted but not selected. See the Extended List-View Styles Remarks section for a discussion of item activation.
		/// </summary>
		LVS_EX_TWOCLICKACTIVATE = 0X00000080,

		/// <summary>
		/// Causes those non-hot items that may be activated to be displayed with underlined text. This style requires that
		/// LVS_EX_TWOCLICKACTIVATE be set also. See the Extended List-View Styles Remarks section for a discussion of item activation.
		/// </summary>
		LVS_EX_UNDERLINECOLD = 0X00001000,

		/// <summary>
		/// Causes those hot items that may be activated to be displayed with underlined text. This style requires that
		/// LVS_EX_ONECLICKACTIVATE or LVS_EX_TWOCLICKACTIVATE also be set. See the Extended List-View Styles Remarks section for a
		/// discussion of item activation.
		/// </summary>
		LVS_EX_UNDERLINEHOT = 0X00000800,
	}

	/// <summary>Flags that determines how the tiles are sized in tile view.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774768")]
	[Flags]
	public enum ListViewTileViewFlag : uint
	{
		/// <summary>Size the tiles automatically.</summary>
		LVTVIF_AUTOSIZE = 0x00000000,

		/// <summary>Apply a fixed width to the tiles.</summary>
		LVTVIF_FIXEDWIDTH = 0x00000001,

		/// <summary>Apply a fixed height to the tiles.</summary>
		LVTVIF_FIXEDHEIGHT = 0x00000002,

		/// <summary>Apply a fixed height and width to the tiles.</summary>
		LVTVIF_FIXEDSIZE = 0x00000003,

		/// <summary>This flag is not supported and should not be used.</summary>
		LVTVIF_EXTENDED = 0x00000004,
	}

	/// <summary>Mask that determines which members of the LVTILEVIEWINFO structure are valid.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774768")]
	[Flags]
	public enum ListViewTileViewMask : uint
	{
		/// <summary>sizeTile is valid.</summary>
		LVTVIM_TILESIZE = 0x00000001,

		/// <summary>cLines is valid.</summary>
		LVTVIM_COLUMNS = 0x00000002,

		/// <summary>rcLabelMargin is valid.</summary>
		LVTVIM_LABELMARGIN = 0x00000004,
	}

	/// <summary>Values for wParam of LVM_SETVIEW and LVM_GETVIEW.</summary>
	[PInvokeData("Commctrl.h")]
	public enum LV_VIEW
	{
		/// <summary>Icon</summary>
		LV_VIEW_ICON = 0x0000,

		/// <summary>Details</summary>
		LV_VIEW_DETAILS = 0x0001,

		/// <summary>Small icon</summary>
		LV_VIEW_SMALLICON = 0x0002,

		/// <summary>List</summary>
		LV_VIEW_LIST = 0x0003,

		/// <summary>Tile</summary>
		LV_VIEW_TILE = 0x0004,
	}

	/// <summary>Flags for <see cref="LVFOOTERINFO"/></summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLVFOOTERINFO")]
	public enum LVFF
	{
		/// <summary>cItems is specified.</summary>
		LVFF_ITEMCOUNT = 0x00000001,
	}

	/// <summary>
	/// Set of flags that specify which members of <see cref="LVFOOTERITEM"/> contain data to be set or which members are being requested.
	/// </summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLVFOOTERITEM")]
	[Flags]
	public enum LVFIF
	{
		/// <summary>The <c>pszText</c> member is valid input from the caller or is requested and thus should be set by the receiver.</summary>
		LVFIF_TEXT = 0x00000001,

		/// <summary>The <c>state</c> member is valid input from the caller or is requested and thus should be set by the receiver.</summary>
		LVFIF_STATE = 0x00000002,
	}

	/// <summary>Indicates the item's state. The <c>stateMask</c> member indicates the valid bits of this member.</summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLVFOOTERITEM")]
	[Flags]
	public enum LVFIS
	{
		/// <summary>Bit indicating focus state. Set if the item is in focus, otherwise cleared.</summary>
		LVFIS_FOCUSED = 1
	}

	/// <summary>Flags for <see cref="NMLVGETINFOTIP"/></summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLVGETINFOTIPA")]
	[Flags]
	public enum LVGIT : uint
	{
		/// <summary>The full text of the item is already displayed, so there is no need to display it in the tooltip.</summary>
		LVGIT_UNFOLDED = 0x0001,
	}

	/// <summary>Modifier keys that were pressed at the time of the activation.</summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMITEMACTIVATE")]
	[Flags]
	public enum LVKF : uint
	{
		/// <summary>The ALT key is pressed.</summary>
		LVKF_ALT = 0x0001,

		/// <summary>The CTRL key is pressed.</summary>
		LVKF_CONTROL = 0x0002,

		/// <summary>The SHIFT key is pressed.</summary>
		LVKF_SHIFT = 0x0004
	}

	/// <summary>Values that specify the behavior of the list-view control after resetting the item count.</summary>
	[PInvokeData("Commctrl.h")]
	[Flags]
	public enum LVSICF
	{
		/// <term>The list-view control will not repaint unless affected items are currently in view.</term>
		LVSICF_NOINVALIDATEALL = 0x00000001,

		/// <term>The list-view control will not change the scroll position when the item count changes.</term>
		LVSICF_NOSCROLL = 0x00000002,
	}

	/// <summary>
	/// <para>
	/// Gets the bounding rectangle for all or part of a subitem in the current view of a specified list-view control. Use this macro or send
	/// the LVM_GETITEMINDEXRECT message explicitly.
	/// </para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the list-view control.</para>
	/// </param>
	/// <param name="plvii">
	/// <para>Type: <c>LVITEMINDEX*</c></para>
	/// <para>
	/// A pointer to a LVITEMINDEX structure for the parent item of the subitem. The caller is responsible for allocating this structure and
	/// setting its members. plvii must not be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="iSubItem">
	/// <para>Type: <c>LONG</c></para>
	/// <para>The index of the subitem.</para>
	/// </param>
	/// <param name="code">
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// The portion of the list-view subitem for which to retrieve the bounding rectangle. This parameter must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LVIR_BOUNDS</term>
	/// <term>Returns the bounding rectangle of the entire subitem, including the icon and label.</term>
	/// </item>
	/// <item>
	/// <term>LVIR_ICON</term>
	/// <term>Returns the bounding rectangle of the icon or small icon of the subitem.</term>
	/// </item>
	/// <item>
	/// <term>LVIR_LABEL</term>
	/// <term>Returns the bounding rectangle of the subitem text.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="prc">
	/// <para>A Rectangle structure to receive the coordinates.</para>
	/// </param>
	/// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
	/// <remarks>
	/// <para>
	/// If iSubItem is zero, this macro returns the coordinates of the rectangle to the item pointed to by plvii. The value LVIR_SELECTBOUNDS
	/// for the parameter code is not supported.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/commctrl/nf-commctrl-listview_getitemindexrect
	[PInvokeData("commctrl.h", MSDNShortId = "listview_getitemindexrect")]
	public static bool ListView_GetItemIndexRect(HWND hwnd, in LVITEMINDEX plvii, int iSubItem, ListViewItemRect code, out RECT prc)
	{
		RECT rc = new((int)code, iSubItem, 0, 0);
		IntPtr lr = SendMessage(hwnd, ListViewMessage.LVM_GETITEMINDEXRECT, in plvii, ref rc);
		prc = lr == IntPtr.Zero ? RECT.Empty : rc;
		return lr != IntPtr.Zero;
	}

	/// <summary>
	/// Gets the index of the item in a particular list-view control that has the specified properties and relationship to another specific
	/// item. Use this macro or send the <c>LVM_GETNEXTITEMINDEX</c> message explicitly.
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c><c>HWND</c></c></para>
	/// <para>A handle to the list-view control.</para>
	/// </param>
	/// <param name="plvii">
	/// <para>Type: <c><c>LVITEMINDEX</c>*</c></para>
	/// <para>
	/// A pointer to the <c>LVITEMINDEX</c> structure with which the item begins the search, or -1 to find the first item that matches the
	/// specified flags. The calling process is responsible for allocating this structure and setting its members.
	/// </para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>The relationship to the item specified in parameter plvii. This can be one or a combination of the following values:</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>Searches by index.</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>LVNI_ALL</term>
	/// <term>Searches for a subsequent item by index, the default value.</term>
	/// </item>
	/// <item>
	/// <term>Searches by physical relationship to the index of the item where the search is to begin.</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>LVNI_ABOVE</term>
	/// <term>Searches for an item that is above the specified item.</term>
	/// </item>
	/// <item>
	/// <term>LVNI_BELOW</term>
	/// <term>Searches for an item that is below the specified item.</term>
	/// </item>
	/// <item>
	/// <term>LVNI_TOLEFT</term>
	/// <term>Searches for an item to the left of the specified item.</term>
	/// </item>
	/// <item>
	/// <term>LVNI_PREVIOUS</term>
	/// <term>
	/// Windows Vista and later: Searches for the item that is previous to the specified item. The LVNI_PREVIOUS flag is not directional
	/// (LVNI_ABOVE will find the item positioned above, while LVNI_PREVIOUS will find the item ordered before.) The LVNI_PREVIOUS flag
	/// essentially reverses the logic of the search performed via the LVM_GETNEXTITEM or LVM_GETNEXTITEMINDEX messages.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LVNI_TORIGHT</term>
	/// <term>Searches for an item to the right of the specified item.</term>
	/// </item>
	/// <item>
	/// <term>LVNI_DIRECTIONMASK</term>
	/// <term>Windows Vista and later: A directional flag mask with value as follows: LVNI_ABOVE | LVNI_BELOW | LVNI_TOLEFT | LVNI_TORIGHT.</term>
	/// </item>
	/// <item>
	/// <term>The state of the item to find can be specified with one or a combination of the following values:</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>LVNI_CUT</term>
	/// <term>The item has the LVIS_CUT state flag set.</term>
	/// </item>
	/// <item>
	/// <term>LVNI_DROPHILITED</term>
	/// <term>The item has the LVIS_DROPHILITED state flag set</term>
	/// </item>
	/// <item>
	/// <term>LVNI_FOCUSED</term>
	/// <term>The item has the LVIS_FOCUSED state flag set.</term>
	/// </item>
	/// <item>
	/// <term>LVNI_SELECTED</term>
	/// <term>The item has the LVIS_SELECTED state flag set.</term>
	/// </item>
	/// <item>
	/// <term>LVNI_STATEMASK</term>
	/// <term>Windows Vista and later: A state flag mask with value as follows: LVNI_FOCUSED | LVNI_SELECTED | LVNI_CUT | LVNI_DROPHILITED.</term>
	/// </item>
	/// <item>
	/// <term>Searches by appearance of items or by group.</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>LVNI_VISIBLEORDER</term>
	/// <term>Windows Vista and later: Search the visible order.</term>
	/// </item>
	/// <item>
	/// <term>LVNI_VISIBLEONLY</term>
	/// <term>Windows Vista and later: Search the visible items.</term>
	/// </item>
	/// <item>
	/// <term>LVNI_SAMEGROUPONLY</term>
	/// <term>Windows Vista and later: Search the current group.</term>
	/// </item>
	/// <item>
	/// <term>If an item does not have all of the specified state flags set, the search continues with the next item.</term>
	/// <term/>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</returns>
	// BOOL ListView_GetNextItemIndex( [in] HWND hwnd, [in, out] LVITEMINDEX *plvii, LPARAM flags); https://msdn.microsoft.com/en-us/library/windows/desktop/bb774986(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774986")]
	public static bool ListView_GetNextItemIndex(HWND hwnd, in LVITEMINDEX plvii, ListViewNextItemFlag flags) =>
		SendMessage(hwnd, (uint)ListViewMessage.LVM_GETNEXTITEMINDEX, (IntPtr)SafeCoTaskMemHandle.CreateFromStructure(plvii), (IntPtr)(int)flags) != IntPtr.Zero;

	/// <summary>
	/// <para>Sets the state of a specified list-view item. Use this macro or send the LVM_SETITEMINDEXSTATE message explicitly.</para>
	/// </summary>
	/// <param name="hwndLV">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the list-view control.</para>
	/// </param>
	/// <param name="plvii">
	/// <para>Type: <c>LVITEMINDEX*</c></para>
	/// <para>
	/// A pointer to an LVITEMINDEX structure for the item. The caller is responsible for allocating this structure and setting the members.
	/// </para>
	/// </param>
	/// <param name="data">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The state to set on the item as one or more (as a bitwise combination) of the List-View Item States flags.</para>
	/// </param>
	/// <param name="mask">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The valid bits of the state specified by parameter data. For more information, see the stateMask member of the LVITEM) structure.</para>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/commctrl/nf-commctrl-listview_setitemindexstate void ListView_SetItemIndexState(
	// hwndLV, plvii, data, mask );
	[PInvokeData("commctrl.h", MSDNShortId = "listview_setitemindexstate")]
	public static HRESULT ListView_SetItemIndexState(HWND hwndLV, in LVITEMINDEX plvii, uint data, ListViewItemState mask)
	{
		LVITEM lvi = new(0) { stateMask = mask, state = data };
		using PinnedObject plvi = new(lvi);
		return new HRESULT(SendMessage(hwndLV, (uint)ListViewMessage.LVM_SETITEMINDEXSTATE, in plvii, plvi).ToInt32());
	}

	/// <summary>
	/// Contains information used when searching for a list-view item. This structure is identical to LV_FINDINFO but has been renamed to fit
	/// standard naming conventions.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774745")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LVFINDINFO
	{
		/// <summary>Type of search to perform.</summary>
		public ListViewFindInfoFlag flags;

		/// <summary>
		/// Address of a null-terminated string to compare with the item text. It is valid only if LVFI_STRING or LVFI_PARTIAL is set in the
		/// flags member.
		/// </summary>
		public string? psz;

		/// <summary>
		/// Value to compare with the lParam member of a list-view item's LVITEM structure. It is valid only if LVFI_PARAM is set in the
		/// flags member.
		/// </summary>
		public IntPtr lParam;

		/// <summary>POINT structure with the initial search position. It is valid only if LVFI_NEARESTXY is set in the flags member.</summary>
		public POINT pt;

		/// <summary>Virtual key code that specifies the direction to search.</summary>
		public ConsoleKey vkDirection;

		/// <summary>Initializes a new instance of the <see cref="LVFINDINFO"/> struct.</summary>
		/// <param name="searchString">The search string.</param>
		/// <param name="allowPartial">if set to <c>true</c> if <paramref name="searchString"/> is the beginning of an item's text.</param>
		/// <param name="wrap">if set to <c>true</c> continues the search at the beginning if no match is found.</param>
		public LVFINDINFO(string searchString, bool allowPartial, bool wrap) : this()
		{
			psz = searchString;
			flags = ListViewFindInfoFlag.LVFI_STRING;
			if (allowPartial)
				flags |= ListViewFindInfoFlag.LVFI_PARTIAL;
			if (wrap)
				flags |= ListViewFindInfoFlag.LVFI_WRAP;
		}

		/// <summary>Initializes a new instance of the <see cref="LVFINDINFO"/> struct.</summary>
		/// <param name="lParam">The value to compare to the lParam member of a list-view item.</param>
		public LVFINDINFO(IntPtr lParam) : this()
		{
			flags = ListViewFindInfoFlag.LVFI_PARAM;
			this.lParam = lParam;
		}

		/// <summary>Initializes a new instance of the <see cref="LVFINDINFO"/> struct.</summary>
		/// <param name="point">The initial search position.</param>
		/// <param name="searchDirection">The search direction.</param>
		public LVFINDINFO(POINT point, ConsoleKey searchDirection) : this()
		{
			flags = ListViewFindInfoFlag.LVFI_NEARESTXY;
			pt = point;
			vkDirection = searchDirection;
		}
	}

	/// <summary>Contains information on a footer in a list-view control.</summary>
	/// <remarks>
	/// <para>This structure is used with the ListView_GetFooterInfo macro and the LVM_GETFOOTERINFO message.</para>
	/// <para>The creation of footers in list-view controls is currently not supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-lvfooterinfo typedef struct tagLVFOOTERINFO { UINT mask;
	// LPWSTR pszText; int cchTextMax; UINT cItems; } LVFOOTERINFO, *LPLVFOOTERINFO;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLVFOOTERINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LVFOOTERINFO
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Set of flags that specify which members of this structure contain data to be set or which members are being requested. Currently,
		/// this value must be LVFF_ITEMCOUNT, for the <c>cItems</c> member.
		/// </para>
		/// </summary>
		public LVFF mask;

		/// <summary>
		/// <para>Type: <c>LPWSTR</c></para>
		/// <para>Not supported. Must be set to zero.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszText;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Not supported. Must be set to zero.</para>
		/// </summary>
		public int cchTextMax;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of items in the footer. When this structure is used to get information, this member will be set by the message receiver.
		/// </para>
		/// </summary>
		public uint cItems;

		/// <summary>Initializes a new instance of the <see cref="LVFOOTERINFO"/> struct.</summary>
		/// <param name="footerItemCount">The number of items in the footer.</param>
		public LVFOOTERINFO(uint footerItemCount)
		{
			cItems = footerItemCount;
			mask = LVFF.LVFF_ITEMCOUNT;
		}
	}

	/// <summary>Contains information on a footer item.</summary>
	/// <remarks>This structure is used with the ListView_GetFooterItem macro and the LVM_GETFOOTERITEM message.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-lvfooteritem typedef struct tagLVFOOTERITEM { UINT mask; int
	// iItem; LPWSTR pszText; int cchTextMax; UINT state; UINT stateMask; } LVFOOTERITEM, *LPLVFOOTERITEM;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLVFOOTERITEM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LVFOOTERITEM
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Set of flags that specify which members of this structure contain data to be set or which members are being requested. This
		/// parameter must be one of the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>LVFIF_TEXT</c></description>
		/// <description>The <c>pszText</c> member is valid input from the caller or is requested and thus should be set by the receiver.</description>
		/// </item>
		/// <item>
		/// <description><c>LVFIF_STATE</c></description>
		/// <description>The <c>state</c> member is valid input from the caller or is requested and thus should be set by the receiver.</description>
		/// </item>
		/// </list>
		/// </summary>
		public LVFIF mask;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The index of the item.</para>
		/// </summary>
		public int iItem;

		/// <summary>
		/// <para>Type: <c>LPWSTR</c></para>
		/// <para>A pointer to a null-terminated, Unicode buffer. The calling process is responsible for allocating the buffer.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszText;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The number of <c>WCHAR</c><c>s</c> in the buffer pointed to by <c>pszText</c>, including the terminating <c>NULL</c>.</para>
		/// </summary>
		public int cchTextMax;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Indicates the item's state. The <c>stateMask</c> member indicates the valid bits of this member. Currently, <c>state</c> must be
		/// set to the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>LVFIS_FOCUSED</c></description>
		/// <description>Bit indicating focus state. Set if the item is in focus, otherwise cleared.</description>
		/// </item>
		/// </list>
		/// </summary>
		public LVFIS state;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Value specifying which bits of the <c>state</c> member will be retrieved or modified. Currently, this value must be the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>LVFIS_FOCUSED</c></description>
		/// <description>
		/// The LVFIS_FOCUSED bit of member <c>state</c> is valid. For example, setting this member to LVFIS_FOCUSED will cause the focus
		/// state to be retrieved to member <c>state</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public LVFIS stateMask;
	}

	/// <summary>Contains information about the display of groups in a list-view control.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774752")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LVGROUPMETRICS
	{
		/// <summary>Size of the LVGROUPMETRICS structure.</summary>
		public uint cbSize;

		/// <summary>Flags that specify which members contain or are to receive valid data.</summary>
		public ListViewGroupMetricsMask mask;

		/// <summary>Specifies the width of the left border in icon, small icon, or tile view.</summary>
		public int Left;

		/// <summary>Specifies the width of the top border in all group views.</summary>
		public int Top;

		/// <summary>Specifies the width of the right border in icon, small icon, or tile view.</summary>
		public int Right;

		/// <summary>Specifies the width of the bottom border in all group views.</summary>
		public int Bottom;

		/// <summary>Specifies the color of the left border. Not implemented.</summary>
		public uint crLeft;

		/// <summary>Specifies the color of the top border. Not implemented.</summary>
		public uint crTop;

		/// <summary>Specifies the color of the right border. Not implemented.</summary>
		public uint crRight;

		/// <summary>Specifies the color of the bottom border. Not implemented.</summary>
		public uint crBottom;

		/// <summary>Specifies the color of the header text. Not implemented.</summary>
		public uint crHeader;

		/// <summary>Specifies the color of the footer text. Not implemented.</summary>
		public uint crFooter;

		/// <summary>Initializes a new instance of the <see cref="LVGROUPMETRICS"/> class.</summary>
		/// <param name="mask">The mask.</param>
		public LVGROUPMETRICS(ListViewGroupMetricsMask mask = ListViewGroupMetricsMask.LVGMF_NONE) : this()
		{
			cbSize = (uint)Marshal.SizeOf<LVGROUPMETRICS>();
			this.mask = mask;
		}

		/// <summary>Initializes a new instance of the <see cref="LVGROUPMETRICS"/> class.</summary>
		/// <param name="left">The width of the left border.</param>
		/// <param name="top">The width of the top border.</param>
		/// <param name="right">The width of the right border.</param>
		/// <param name="bottom">The width of the bottom border.</param>
		public LVGROUPMETRICS(int left, int top, int right, int bottom) : this()
		{
			cbSize = (uint)Marshal.SizeOf<LVGROUPMETRICS>();
			SetBorderSize(left, top, right, bottom);
		}

		/// <summary>Sets the size of the border.</summary>
		/// <param name="left">The left.</param>
		/// <param name="top">The top.</param>
		/// <param name="right">The right.</param>
		/// <param name="bottom">The bottom.</param>
		public void SetBorderSize(int left, int top, int right, int bottom)
		{
			mask = ListViewGroupMetricsMask.LVGMF_BORDERSIZE;
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}
	}

	/// <summary>
	/// Contains information about a hit test. This structure has been extended to accommodate subitem hit-testing. It is used in association
	/// with the LVM_HITTEST and LVM_SUBITEMHITTEST messages and their related macros. This structure supersedes the LVHITTESTINFO structure.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774754")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LVHITTESTINFO
	{
		/// <summary>The position to hit test, in client coordinates.</summary>
		public POINT pt;

		/// <summary>
		/// The variable that receives information about the results of a hit test. This member can be one or more of the following values:
		/// <para>
		/// You can use LVHT_ABOVE, LVHT_BELOW, LVHT_TOLEFT, and LVHT_TORIGHT to determine whether to scroll the contents of a list-view
		/// control.Two of these values may be combined. For example, if the position is above and to the left of the client area, you could
		/// use both LVHT_ABOVE and LVHT_TOLEFT.
		/// </para>
		/// <para>
		/// You can test for LVHT_ONITEM to determine whether a specified position is over a list-view item. This value is a bitwise-OR
		/// operation on LVHT_ONITEMICON, LVHT_ONITEMLABEL, and LVHT_ONITEMSTATEICON.
		/// </para>
		/// </summary>
		public ListViewHitTestFlag flags;

		/// <summary>
		/// Receives the index of the matching item. Or if hit-testing a subitem, this value represents the subitem's parent item.
		/// </summary>
		public int iItem;

		/// <summary>Version 4.70. Receives the index of the matching subitem. When hit-testing an item, this member will be zero.</summary>
		public int iSubItem;

		/// <summary>
		/// Windows Vista. Group index of the item hit (read only). Valid only for owner data. If the point is within an item that is
		/// displayed in multiple groups then iGroup will specify the group index of the item.
		/// </summary>
		public int iGroup;

		/// <summary>Initializes a new instance of the <see cref="LVHITTESTINFO"/> class.</summary>
		/// <param name="pt">The pt.</param>
		public LVHITTESTINFO(POINT pt) : this() => this.pt = pt;
	}

	/// <summary>Used to sort groups. It is used with LVM_INSERTGROUPSORTED.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-lvinsertgroupsorted typedef struct tagLVINSERTGROUPSORTED {
	// PFNLVGROUPCOMPARE pfnGroupCompare; void *pvData; LVGROUP lvGroup; } LVINSERTGROUPSORTED, *PLVINSERTGROUPSORTED;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLVINSERTGROUPSORTED")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LVINSERTGROUPSORTED
	{
		/// <summary>
		/// <para>Type: <c>PFNLVGROUPCOMPARE</c></para>
		/// <para>Pointer to application-defined function LVGroupCompare that is used to sort the groups.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LVGroupCompare pfnGroupCompare;

		/// <summary>
		/// <para>Type: <c>LPVOID*</c></para>
		/// <para>Data to sort; this is application-defined.</para>
		/// </summary>
		public IntPtr pvData;

		/// <summary>
		/// <para>Type: <c>LVGROUP</c></para>
		/// <para>Group to sort; this is application-defined.</para>
		/// </summary>
		public LVGROUP lvGroup;
	}

	/// <summary>Used to describe insertion points.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774758")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LVINSERTMARK
	{
		/// <summary>Size of the LVINSERTMARK structure.</summary>
		public uint cbSize;

		/// <summary>Flag that specifies where the insertion point should appear.</summary>
		public ListViewInsertMarkFlag dwFlags;

		/// <summary>Item next to which the insertion point appears. If this member contains -1, there is no insertion point.</summary>
		public int iItem;

		/// <summary>Reserved. Must be zero.</summary>
		public uint dwReserved;

		/// <summary>Initializes a new instance of the <see cref="LVINSERTMARK"/> struct.</summary>
		/// <param name="insertAtItem">Index at which to insert the item.</param>
		/// <param name="insertAfter">if set to <c>true</c> the insertion point appears after the item specified.</param>
		public LVINSERTMARK(int insertAtItem, bool insertAfter = false) : this()
		{
			cbSize = (uint)Marshal.SizeOf<LVINSERTMARK>();
			dwFlags = insertAfter ? ListViewInsertMarkFlag.LVIM_AFTER : ListViewInsertMarkFlag.LVIM_BEFORE;
			iItem = insertAtItem;
		}
	}

	/// <summary>Helper structure for <see cref="LVITEM"/> to easily capture column order and format information.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774760")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LVITEMCOLUMNINFO
	{
		/// <summary>The column index</summary>
		public uint columnIndex;

		/// <summary>
		/// Windows Vista: Not implemented. Windows 7 and later: A flag specifying the format of this column in extended tile view.
		/// </summary>
		public ListViewColumnFormat format;

		/// <summary>Initializes a new instance of the <see cref="LVITEMCOLUMNINFO"/> struct.</summary>
		/// <param name="colIdx">Index of the column.</param>
		/// <param name="fmt">The format of the column.</param>
		public LVITEMCOLUMNINFO(uint colIdx, ListViewColumnFormat fmt = 0)
		{
			columnIndex = colIdx;
			format = fmt;
		}
	}

	/// <summary>Contains index information about a list-view item.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LVITEMINDEX
	{
		/// <summary>The index of the item.</summary>
		public int iItem;

		/// <summary>The index of the group the item belongs to.</summary>
		public int iGroup;
	}

	/// <summary>Provides information about a list-view control when it is displayed in tile view.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774768")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LVTILEVIEWINFO
	{
		/// <summary>Size of the LVTILEVIEWINFO structure.</summary>
		public uint cbSize;

		/// <summary>Mask that determines which members are valid. This member may be one of the following values.</summary>
		public ListViewTileViewMask dwMask;

		/// <summary>Flags that determines how the tiles are sized in tile view. This member may be one of the following values.</summary>
		public ListViewTileViewFlag dwFlags;

		/// <summary>Size of an individual tile. Values for dimensions not specified as fixed in dwFlags are ignored.</summary>
		public SIZE sizeTile;

		/// <summary>Maximum number of text lines in each item label, not counting the title.</summary>
		public int cLines;

		/// <summary>RECT that contains coordinates of the label margin.</summary>
		public RECT rcLabelMargin;

		/// <summary>Initializes a new instance of the <see cref="LVTILEVIEWINFO"/> struct.</summary>
		/// <param name="mask">The mask.</param>
		public LVTILEVIEWINFO(ListViewTileViewMask mask) : this()
		{
			cbSize = (uint)Marshal.SizeOf<LVTILEVIEWINFO>();
			dwMask = mask;
		}

		/// <summary>Gets or sets a value indicating whether to size the tiles automatically.</summary>
		/// <value><c>true</c> if tiles are automatically sized; otherwise, <c>false</c>.</value>
		public bool AutoSize
		{
			get => dwFlags.IsFlagSet(ListViewTileViewFlag.LVTVIF_AUTOSIZE);
			set { dwFlags = ListViewTileViewFlag.LVTVIF_AUTOSIZE; dwMask |= ListViewTileViewMask.LVTVIM_TILESIZE; sizeTile.cy = sizeTile.cx = 0; }
		}

		/// <summary>Gets or sets the size of an individual tile.</summary>
		/// <value>The size of an individual tile.</value>
		public SIZE TileSize
		{
			get => sizeTile;
			set { sizeTile = value; dwMask |= ListViewTileViewMask.LVTVIM_TILESIZE; dwFlags |= ListViewTileViewFlag.LVTVIF_FIXEDSIZE; }
		}

		/// <summary>Gets or sets the height of an individual tile.</summary>
		/// <value>The height of an individual tile.</value>
		public int TileHeight
		{
			get => sizeTile.cy;
			set { sizeTile.cy = value; dwMask |= ListViewTileViewMask.LVTVIM_TILESIZE; dwFlags |= ListViewTileViewFlag.LVTVIF_FIXEDHEIGHT; }
		}

		/// <summary>Gets or sets the width of an individual tile.</summary>
		/// <value>The width of an individual tile.</value>
		public int TileWidth
		{
			get => sizeTile.cx;
			set { sizeTile.cx = value; dwMask |= ListViewTileViewMask.LVTVIM_TILESIZE; dwFlags |= ListViewTileViewFlag.LVTVIF_FIXEDWIDTH; }
		}

		/// <summary>Gets or sets the maximum number of text lines in each item label, not counting the title.</summary>
		/// <value>The maximum number of text lines in each item label, not counting the title.</value>
		public int MaxTextLines
		{
			get => cLines;
			set { cLines = value; dwMask |= ListViewTileViewMask.LVTVIM_COLUMNS; }
		}

		/// <summary>Gets or sets the tile padding.</summary>
		/// <value>The tile padding.</value>
		public RECT TilePadding
		{
			get => rcLabelMargin;
			set { rcLabelMargin = value; dwMask |= ListViewTileViewMask.LVTVIM_LABELMARGIN; }
		}
	}

	/// <summary>Contains information about an LVN_ITEMACTIVATE notification code.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmitemactivate typedef struct tagNMITEMACTIVATE { NMHDR hdr;
	// int iItem; int iSubItem; UINT uNewState; UINT uOldState; UINT uChanged; POINT ptAction; LPARAM lParam; UINT uKeyFlags; }
	// NMITEMACTIVATE, *LPNMITEMACTIVATE;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMITEMACTIVATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMITEMACTIVATE : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains information about this notification code.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Index of the list-view item. If the item index is not used for the notification, this member will contain -1.</para>
		/// </summary>
		public int iItem;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// One-based index of the subitem. If the subitem index is not used for the notification or the notification does not apply to a
		/// subitem, this member will contain zero.
		/// </para>
		/// </summary>
		public int iSubItem;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>New item state. This member is zero for notification codes that do not use it.</para>
		/// </summary>
		public ListViewItemState uNewState;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Old item state. This member is zero for notification codes that do not use it.</para>
		/// </summary>
		public ListViewItemState uOldState;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Set of flags that indicate the item attributes that have changed. This member is zero for notifications that do not use it.
		/// Otherwise, it can have the same values as the <c>mask</c> member of the LVITEM structure.
		/// </para>
		/// </summary>
		public ListViewItemMask uChanged;

		/// <summary>
		/// <para>Type: <c>POINT</c></para>
		/// <para>
		/// POINT structure that indicates the location at which the event occurred, in client coordinates. This member is undefined for
		/// notification codes that do not use it.
		/// </para>
		/// </summary>
		public POINT ptAction;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Application-defined value of the item. This member is undefined for notification codes that do not use it.</para>
		/// </summary>
		public IntPtr lParam;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Modifier keys that were pressed at the time of the activation. This member contains zero or a combination of the following flags:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>LVKF_ALT</c></description>
		/// <description>The key is pressed.</description>
		/// </item>
		/// <item>
		/// <description><c>LVKF_CONTROL</c></description>
		/// <description>The key is pressed.</description>
		/// </item>
		/// <item>
		/// <description><c>LVKF_SHIFT</c></description>
		/// <description>The key is pressed.</description>
		/// </item>
		/// </list>
		/// </summary>
		public LVKF uKeyFlags;
	}

	/// <summary>
	/// Contains information about a list-view notification message. This structure is the same as the NM_LISTVIEW structure but has been
	/// renamed to fit standard naming conventions.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774773")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMLISTVIEW : INotificationInfo
	{
		/// <summary>NMHDR structure that contains information about this notification message</summary>
		public NMHDR hdr;

		/// <summary>Identifies the list-view item, or -1 if not used.</summary>
		public int iItem;

		/// <summary>Identifies the subitem, or zero if none.</summary>
		public int iSubItem;

		/// <summary>
		/// New item state. This member is zero for notification messages that do not use it. For a list of possible values, see List-View
		/// Item States.
		/// </summary>
		public ListViewItemState uNewState;

		/// <summary>
		/// Old item state. This member is zero for notification messages that do not use it. For a list of possible values, see List-View
		/// Item States.
		/// </summary>
		public ListViewItemState uOldState;

		/// <summary>
		/// Set of flags that indicate the item attributes that have changed. This member is zero for notifications that do not use it.
		/// Otherwise, it can have the same values as the mask member of the LVITEM structure.
		/// </summary>
		public ListViewItemMask uChanged;

		/// <summary>
		/// POINT structure that indicates the location at which the event occurred. This member is undefined for notification messages that
		/// do not use it.
		/// </summary>
		public POINT ptAction;

		/// <summary>Application-defined value of the item. This member is undefined for notification messages that do not use it.</summary>
		public IntPtr lParam;
	}

	/// <summary>Contains information used to update the cached item information for use with a virtual list view.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlvcachehint typedef struct tagNMLVCACHEHINT { NMHDR hdr;
	// int iFrom; int iTo; } NMLVCACHEHINT, *LPNMLVCACHEHINT;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLVCACHEHINT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMLVCACHEHINT : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains information about this notification message.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Starting index of the requested range of items. This value is inclusive.</para>
		/// </summary>
		public int iFrom;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Ending index of the requested range of items. This value is inclusive.</para>
		/// </summary>
		public int iTo;
	}

	/// <summary>
	/// Contains information about an LVN_GETDISPINFO or LVN_SETDISPINFO notification code. This structure is the same as the
	/// <c>LV_DISPINFO</c> structure, but has been renamed to fit standard naming conventions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If the LVITEM structure is receiving item text, the <c>pszText</c> and <c>cchTextMax</c> members specify the address and size of a
	/// buffer. You can either copy text to the buffer or assign the address of a string to the <c>pszText</c> member. In the latter case,
	/// you must not change or delete the string until the corresponding item text is deleted or two additional LVN_GETDISPINFO messages have
	/// been sent.
	/// </para>
	/// <para>
	/// If you are handling the LVN_GETDISPINFO message, you can set the LVIF_DI_SETITEM flag in the <c>mask</c> member of the LVITEM
	/// structure. This tells the operating system to store the requested list item information and not ask for it again. For list-view
	/// controls with the LVS_REPORT style, this flag only applies to the first (subitem 0) column's information. The control will not store
	/// information for subitems.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The commctrl.h header defines NMLVDISPINFO as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlvdispinfoa typedef struct tagLVDISPINFO { NMHDR hdr;
	// LVITEMA item; } NMLVDISPINFOA, *LPNMLVDISPINFOA;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLVDISPINFO")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NMLVDISPINFO : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains information about this notification code.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>LVITEM</c></para>
		/// <para>
		/// LVITEM structure that identifies the item or subitem. The structure either contains or receives information about the item. The
		/// <c>mask</c> member contains a set of bit flags that specify which item attributes are relevant. For more information on the
		/// available bit flags, see <c>LVITEM</c>.
		/// </para>
		/// </summary>
		public LVITEM item;
	}

	/// <summary>Contains information used with the LVN_GETEMPTYMARKUP notification code.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlvemptymarkup typedef struct tagNMLVEMPTYMARKUP { NMHDR
	// hdr; DWORD dwFlags; WCHAR szMarkup[L_MAX_URL_LENGTH]; } NMLVEMPTYMARKUP;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLVEMPTYMARKUP")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct NMLVEMPTYMARKUP : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>Info on the notification message.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One of the following values. If <c>NULL</c>, markup is rendered left-justified in the listview area.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>EMF_CENTERED</c></description>
		/// <description>Render markup centered in the listview area.</description>
		/// </item>
		/// </list>
		/// </summary>
		public EMF dwFlags;

		/// <summary>
		/// <para>Type: <c>WCHAR[L_MAX_URL_LENGTH]</c></para>
		/// <para>Markup to display.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = L_MAX_URL_LENGTH)]
		public string szMarkup;
	}

	/// <summary>
	/// Contains information the owner needs to find items requested by a virtual list-view control. This structure is used with the
	/// LVN_ODFINDITEM notification code.
	/// </summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The commctrl.h header defines NMLVFINDITEM as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlvfinditemw typedef struct tagNMLVFINDITEMW { NMHDR hdr;
	// int iStart; LVFINDINFOW lvfi; } NMLVFINDITEMW, *LPNMLVFINDITEMW;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLVFINDITEMW")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NMLVFINDITEM : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains information on this notification code.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Index of the item at which the search will start.</para>
		/// </summary>
		public int iStart;

		/// <summary>
		/// <para>Type: <c>LVFINDINFO</c></para>
		/// <para>LVFINDINFO structure that contains information necessary to perform a search.</para>
		/// </summary>
		public LVFINDINFO lvfi;
	}

	/// <summary>
	/// Contains and receives list-view item information needed to display a tooltip for an item. This structure is used with the
	/// LVN_GETINFOTIP notification code.
	/// </summary>
	/// <remarks>
	/// <para>
	/// An item is said to be folded when the currently displayed text is truncated. If LVGIT_UNFOLDED is returned in <c>dwFlags</c>, the
	/// full text of the item is already displayed, so there is no need to display it in the tooltip.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The commctrl.h header defines NMLVGETINFOTIP as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlvgetinfotipa typedef struct tagNMLVGETINFOTIPA { NMHDR
	// hdr; DWORD dwFlags; LPSTR pszText; int cchTextMax; int iItem; int iSubItem; LPARAM lParam; } NMLVGETINFOTIPA, *LPNMLVGETINFOTIPA;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLVGETINFOTIPA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NMLVGETINFOTIP : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains information on this notification code.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Either zero or LVGIT_UNFOLDED. See Remarks.</para>
		/// </summary>
		public LVGIT dwFlags;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// Address of a string buffer that receives any additional text information. If <c>dwFlags</c> is zero, this member will contain the
		/// existing item text. In this case, you should append any additional text onto the end of this string. The size of this buffer is
		/// specified by the <c>cchTextMax</c> structure.
		/// </para>
		/// </summary>
		public StrPtrAuto pszText;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Size, in characters, of the buffer pointed to by <c>pszText</c>. Although you should never assume that this buffer will be of any
		/// particular size, the INFOTIPSIZE value can be used for design purposes.
		/// </para>
		/// </summary>
		public int cchTextMax;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Zero-based index of the item to which this structure refers.</para>
		/// </summary>
		public int iItem;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// One-based index of the subitem to which this structure refers. If this member is zero, the structure is referring to the item and
		/// not a subitem. This member is not currently used and will always be zero.
		/// </para>
		/// </summary>
		public int iSubItem;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Application-defined value associated with the item. This member is not currently used and will always be zero.</para>
		/// </summary>
		public IntPtr lParam;
	}

	/// <summary>
	/// Contains information used in processing the LVN_KEYDOWN notification code. This structure is the same as the <c>NMLVKEYDOWN</c>
	/// structure but has been renamed to fit standard naming conventions.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlvkeydown typedef struct tagLVKEYDOWN { NMHDR hdr; WORD
	// wVKey; UINT flags; } NMLVKEYDOWN, *LPNMLVKEYDOWN;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLVKEYDOWN")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMLVKEYDOWN : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Virtual key code. Cast this value to <see cref="VK"/>.</para>
		/// </summary>
		public ushort wVKey;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>This member must always be zero.</para>
		/// </summary>
		public uint flags;
	}

	/// <summary>Contains information about an LVN_LINKCLICK notification code.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlvlink typedef struct tagNMLVLINK { NMHDR hdr; LITEM link;
	// int iItem; int iSubItem; } NMLVLINK, *PNMLVLINK;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLVLINK")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMLVLINK : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains basic information about the notification code.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>LITEM</c></para>
		/// <para>LITEM structure that contains information about the link that was clicked.</para>
		/// </summary>
		public LITEM link;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Index of the item that contains the link.</para>
		/// </summary>
		public int iItem;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Subitem, if any. This member may be <c>NULL</c>. For a link in a group header, this is the group identifier, as set in LVGROUP.
		/// </para>
		/// </summary>
		public int iSubItem;
	}

	/// <summary>Structure that contains information for use in processing the LVN_ODSTATECHANGED notification code.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlvodstatechange typedef struct tagNMLVODSTATECHANGE { NMHDR
	// hdr; int iFrom; int iTo; UINT uNewState; UINT uOldState; } NMLVODSTATECHANGE, *LPNMLVODSTATECHANGE;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLVODSTATECHANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMLVODSTATECHANGE : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Zero-based index of the first item in the range of items.</para>
		/// </summary>
		public int iFrom;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Zero-based index of the last item in the range of items.</para>
		/// </summary>
		public int iTo;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Value indicating the new state for the item or items. This member can be any valid combination of the list-view item states.</para>
		/// </summary>
		public ListViewItemState uNewState;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Value indicating the old state for the item or items. This member can be any valid combination of the list-view item states.</para>
		/// </summary>
		public ListViewItemState uOldState;
	}

	/// <summary>Provides information about a scrolling operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmlvscroll typedef struct tagNMLVSCROLL { NMHDR hdr; int dx;
	// int dy; } NMLVSCROLL, *LPNMLVSCROLL;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagNMLVSCROLL")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMLVSCROLL : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains information about a LVN_ENDSCROLL or a LVN_BEGINSCROLL notification code.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies in pixels the horizontal position where a scrolling operation should begin or end.</para>
		/// </summary>
		public int dx;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies in pixels the vertical position where a scrolling operation should begin or end.</para>
		/// </summary>
		public int dy;
	}

	/// <summary>
	/// Contains information about the background image of a list-view control. This structure is used for both setting and retrieving
	/// background image information.
	/// </summary>
	/// <seealso cref="IDisposable"/>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774742")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public sealed class LVBKIMAGE : IDisposable
	{
		/// <summary>
		/// This member may be one or more of the following flags. You can use the LVBKIF_SOURCE_MASK value to mask off all but the source
		/// flags. You can use the LVBKIF_STYLE_MASK value to mask off all but the style flags.
		/// </summary>
		public ListViewBkImageFlag ulFlags;

		/// <summary>The handle of the background bitmap. This member is valid only if the LVBKIF_SOURCE_HBITMAP flag is set in ulFlags.</summary>
		public HBITMAP hBmp = IntPtr.Zero;

		/// <summary>
		/// Address of a NULL-terminated string that contains the URL of the background image. This member is valid only if the
		/// LVBKIF_SOURCE_URL flag is set in ulFlags. This member must be initialized to point to the buffer that contains or receives the
		/// text before sending the message.
		/// </summary>
		public StrPtrAuto pszImage;

		/// <summary>Size of the buffer at the address in pszImage. If information is being sent to the control, this member is ignored.</summary>
		public uint cchImageMax;

		/// <summary>
		/// Percentage of the control's client area that the image should be offset horizontally. For example, at 0 percent, the image will
		/// be displayed against the left edge of the control's client area. At 50 percent, the image will be displayed horizontally centered
		/// in the control's client area. At 100 percent, the image will be displayed against the right edge of the control's client area.
		/// This member is valid only when LVBKIF_STYLE_NORMAL is specified in ulFlags. If both LVBKIF_FLAG_TILEOFFSET and LVBKIF_STYLE_TILE
		/// are specified in ulFlags, then the value specifies the pixel, not percentage offset, of the first tile. Otherwise, the value is ignored.
		/// </summary>
		public int xOffset;

		/// <summary>
		/// Percentage of the control's client area that the image should be offset vertically. For example, at 0 percent, the image will be
		/// displayed against the top edge of the control's client area. At 50 percent, the image will be displayed vertically centered in
		/// the control's client area. At 100 percent, the image will be displayed against the bottom edge of the control's client area. This
		/// member is valid only when LVBKIF_STYLE_NORMAL is specified in ulFlags. If both LVBKIF_FLAG_TILEOFFSET and LVBKIF_STYLE_TILE are
		/// specified in ulFlags, then the value specifies the pixel, not percentage offset, of the first tile. Otherwise, the value is ignored.
		/// </summary>
		public int yOffset;

		/// <summary>Initializes a new instance of the <see cref="LVBKIMAGE"/> class.</summary>
		/// <param name="bmp">The handle of the background bitmap.</param>
		/// <param name="isWatermark">if set to <c>true</c> a watermark bitmap is applied.</param>
		/// <param name="isWatermarkAlphaBlended">if set to <c>true</c> the watermark is alpha blended.</param>
		public LVBKIMAGE(HBITMAP bmp, bool isWatermark, bool isWatermarkAlphaBlended)
		{
			hBmp = bmp;
			ulFlags = isWatermark ? ListViewBkImageFlag.LVBKIF_TYPE_WATERMARK : ListViewBkImageFlag.LVBKIF_SOURCE_HBITMAP;
			if (isWatermark && isWatermarkAlphaBlended)
				ulFlags |= ListViewBkImageFlag.LVBKIF_FLAG_ALPHABLEND;
		}

		/// <summary>Initializes a new instance of the <see cref="LVBKIMAGE"/> class.</summary>
		/// <param name="bmp">The handle of the background bitmap.</param>
		/// <param name="isTiled">if set to <c>true</c>, the bitmap image is tiled.</param>
		public LVBKIMAGE(HBITMAP bmp, bool isTiled)
		{
			hBmp = bmp;
			ulFlags = ListViewBkImageFlag.LVBKIF_SOURCE_HBITMAP;
			if (isTiled)
				ulFlags |= ListViewBkImageFlag.LVBKIF_STYLE_TILE;
		}

		/// <summary>Initializes a new instance of the <see cref="LVBKIMAGE"/> class.</summary>
		/// <param name="url">The URL of the background image.</param>
		/// <param name="isTiled">if set to <c>true</c>, the bitmap image is tiled.</param>
		public LVBKIMAGE(string url, bool isTiled)
		{
			Url = url;
			ulFlags = ListViewBkImageFlag.LVBKIF_SOURCE_URL;
			if (isTiled)
				ulFlags |= ListViewBkImageFlag.LVBKIF_STYLE_TILE;
		}

		/// <summary>Initializes a new instance of the <see cref="LVBKIMAGE"/> class.</summary>
		public LVBKIMAGE() : this(ListViewBkImageFlag.LVBKIF_SOURCE_NONE)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="LVBKIMAGE"/> class.</summary>
		/// <param name="flags">The flags.</param>
		public LVBKIMAGE(ListViewBkImageFlag flags)
		{
			ulFlags = flags;
			if (ulFlags.IsFlagSet(ListViewBkImageFlag.LVBKIF_SOURCE_URL))
				pszImage = new StrPtrAuto(cchImageMax = 1024);
		}

		/// <summary>Gets or sets the URL.</summary>
		/// <value>The URL.</value>
		public string Url
		{
			get => pszImage.ToString();
			set => EnumExtensions.SetFlags(ref ulFlags, ListViewBkImageFlag.LVBKIF_SOURCE_URL, pszImage.Assign(value, out cchImageMax));
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose() => pszImage.Free();
	}

	/// <summary>
	/// Contains information about a column in report view. This structure is used both for creating and manipulating columns. This structure
	/// supersedes the LV_COLUMN structure.
	/// </summary>
	/// <seealso cref="IDisposable"/>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774743")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public sealed class LVCOLUMN : IDisposable
	{
		/// <summary>
		/// Variable specifying which members contain valid information. This member can be zero, or one or more of the following values:
		/// </summary>
		public ListViewColumMask mask;

		/// <summary>
		/// Alignment of the column header and the subitem text in the column. The alignment of the leftmost column is always LVCFMT_LEFT; it
		/// cannot be changed. This member can be a combination of the following values. Note that not all combinations are valid.
		/// </summary>
		public ListViewColumnFormat fmt;

		/// <summary>Width of the column, in pixels.</summary>
		public int cx;

		/// <summary>
		/// If column information is being set, this member is the address of a null-terminated string that contains the column header text.
		/// If the structure is receiving information about a column, this member specifies the address of the buffer that receives the
		/// column header text.
		/// </summary>
		public StrPtrAuto pszText;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszText member. If the structure is not receiving information about a column, this
		/// member is ignored.
		/// </summary>
		public uint cchTextMax;

		/// <summary>Index of subitem associated with the column.</summary>
		public int iSubItem;

		/// <summary>Version 4.70. Zero-based index of an image within the image list. The specified image will appear within the column.</summary>
		public int iImage;

		/// <summary>
		/// Version 4.70. Zero-based column offset. Column offset is in left-to-right order. For example, zero indicates the leftmost column.
		/// </summary>
		public int iOrder;

		/// <summary>Windows Vista. Minimum width of the column in pixels.</summary>
		public int cxMin;

		/// <summary>
		/// Windows Vista. Application-defined value typically used to store the default width of the column. This member is ignored by the
		/// list-view control.
		/// </summary>
		public int cxDefault;

		/// <summary>
		/// Windows Vista. Read-only. The ideal width of the column in pixels, as the column may currently be autosized to a lesser width.
		/// </summary>
		public int cxIdeal;

		/// <summary>Initializes a new instance of the <see cref="LVCOLUMN"/> class.</summary>
		/// <param name="mask">The mask.</param>
		public LVCOLUMN(ListViewColumMask mask)
		{
			this.mask = mask;
			if (mask.IsFlagSet(ListViewColumMask.LVCF_TEXT))
				pszText = new StrPtrAuto(cchTextMax = 1024);
		}

		/// <summary>Gets or sets the format.</summary>
		/// <value>The format.</value>
		public ListViewColumnFormat Format
		{
			get => fmt; set { fmt = value; EnumExtensions.SetFlags(ref mask, ListViewColumMask.LVCF_FMT); }
		}

		/// <summary>Gets or sets the header text.</summary>
		/// <value>
		/// The header text. Setting this value will free any previous buffer and will allocate a new buffer sufficient to hold the string.
		/// </value>
		public string Text
		{
			get => pszText.ToString();
			set => EnumExtensions.SetFlags(ref mask, ListViewColumMask.LVCF_TEXT, pszText.Assign(value, out cchTextMax));
		}

		/// <summary>Gets or sets the index of subitem associated with the column.</summary>
		/// <value>The index of subitem.</value>
		public int Subitem
		{
			get => iSubItem; set { iSubItem = value; EnumExtensions.SetFlags(ref mask, ListViewColumMask.LVCF_SUBITEM); }
		}

		/// <summary>Gets or sets the zero-based index of an image within the image list.</summary>
		/// <value>The index of and image in the image list.</value>
		public int ImageListIndex
		{
			get => iImage; set { iImage = value; EnumExtensions.SetFlags(ref mask, ListViewColumMask.LVCF_IMAGE); }
		}

		/// <summary>Gets or sets the column position.</summary>
		/// <value>The column position.</value>
		public int ColumnPosition
		{
			get => iOrder; set { iOrder = value; EnumExtensions.SetFlags(ref mask, ListViewColumMask.LVCF_ORDER); }
		}

		/// <summary>Gets or sets the default width.</summary>
		/// <value>The default width.</value>
		public int DefaultWidth
		{
			get => cxDefault; set { cxDefault = value; EnumExtensions.SetFlags(ref mask, ListViewColumMask.LVCF_DEFAULTWIDTH); }
		}

		/// <summary>Gets or sets the minimum width.</summary>
		/// <value>The minimum width.</value>
		public int MinWidth
		{
			get => cxMin; set { cxMin = value; EnumExtensions.SetFlags(ref mask, ListViewColumMask.LVCF_MINWIDTH); }
		}

		/// <summary>Gets or sets the ideal width.</summary>
		/// <value>The ideal width.</value>
		public int IdealWidth
		{
			get => cxIdeal; set { cxIdeal = value; EnumExtensions.SetFlags(ref mask, ListViewColumMask.LVCF_IDEALWIDTH); }
		}

		/// <summary>Gets or sets the width.</summary>
		/// <value>The width.</value>
		public int Width
		{
			get => cx; set { cx = value; EnumExtensions.SetFlags(ref mask, ListViewColumMask.LVCF_WIDTH); }
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose() => pszText.Free();
	}

	/// <summary>Used to set and retrieve groups.</summary>
	/// <seealso cref="IDisposable"/>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774769")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public sealed class LVGROUP : IDisposable
	{
		/// <summary>Size of this structure, in bytes.</summary>
		public int cbSize = Marshal.SizeOf<LVGROUP>();

		/// <summary>Mask that specifies which members of the structure are valid input.</summary>
		public ListViewGroupMask mask;

		/// <summary>
		/// Pointer to a null-terminated string that contains the header text when item information is being set. If group information is
		/// being retrieved, this member specifies the address of the buffer that receives the header text.
		/// </summary>
		public StrPtrAuto pszHeader;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszHeader member. If the structure is not receiving information about a group,
		/// this member is ignored.
		/// </summary>
		public uint cchHeader;

		/// <summary>
		/// Pointer to a null-terminated string that contains the footer text when item information is being set. If group information is
		/// being retrieved, this member specifies the address of the buffer that receives the footer text.
		/// </summary>
		public StrPtrAuto pszFooter;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszFooter member. If the structure is not receiving information about a group,
		/// this member is ignored.
		/// </summary>
		public uint cchFooter;

		/// <summary>ID of the group.</summary>
		public int iGroupId;

		/// <summary>
		/// Mask used with LVM_GETGROUPINFO and LVM_SETGROUPINFO to specify which flags in the state value are being retrieved or set.
		/// </summary>
		public ListViewGroupState stateMask;

		/// <summary>Flag that can have one of the following values:</summary>
		public ListViewGroupState state;

		/// <summary>
		/// Indicates the alignment of the header or footer text for the group. It can have one or more of the following values. Use one of
		/// the header flags. Footer flags are optional.
		/// </summary>
		public ListViewGroupAlignment uAlign;

		/// <summary>
		/// Pointer to a null-terminated string that contains the subtitle text when item information is being set. If group information is
		/// being retrieved, this member specifies the address of the buffer that receives the subtitle text. This element is drawn under the
		/// header text.
		/// </summary>
		public StrPtrAuto pszSubtitle;

		/// <summary>
		/// Size, in TCHARs, of the buffer pointed to by the pszSubtitle member. If the structure is not receiving information about a group,
		/// this member is ignored.
		/// </summary>
		public uint cchSubtitle;

		/// <summary>
		/// Pointer to a null-terminated string that contains the text for a task link when item information is being set. If group
		/// information is being retrieved, this member specifies the address of the buffer that receives the task text. This item is drawn
		/// right-aligned opposite the header text. When clicked by the user, the task link generates an LVN_LINKCLICK notification.
		/// </summary>
		public StrPtrAuto pszTask;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszTask member. If the structure is not receiving information about a group, this
		/// member is ignored.
		/// </summary>
		public uint cchTask;

		/// <summary>
		/// Pointer to a null-terminated string that contains the top description text when item information is being set. If group
		/// information is being retrieved, this member specifies the address of the buffer that receives the top description text. This item
		/// is drawn opposite the title image when there is a title image, no extended image, and uAlign==LVGA_HEADER_CENTER.
		/// </summary>
		public StrPtrAuto pszDescriptionTop;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszDescriptionTop member. If the structure is not receiving information about a
		/// group, this member is ignored.
		/// </summary>
		public uint cchDescriptionTop;

		/// <summary>
		/// Pointer to a null-terminated string that contains the bottom description text when item information is being set. If group
		/// information is being retrieved, this member specifies the address of the buffer that receives the bottom description text. This
		/// item is drawn under the top description text when there is a title image, no extended image, and uAlign==LVGA_HEADER_CENTER.
		/// </summary>
		public StrPtrAuto pszDescriptionBottom;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszDescriptionBottom member. If the structure is not receiving information about a
		/// group, this member is ignored.
		/// </summary>
		public uint cchDescriptionBottom;

		/// <summary>Index of the title image in the control imagelist.</summary>
		public int iTitleImage;

		/// <summary>Index of the extended image in the control imagelist.</summary>
		public int iExtendedImage;

		/// <summary>Read-only.</summary>
		public int iFirstItem;

		/// <summary>Read-only in non-owner data mode.</summary>
		public uint cItems;

		/// <summary>
		/// NULL if group is not a subset. Pointer to a null-terminated string that contains the subset title text when item information is
		/// being set. If group information is being retrieved, this member specifies the address of the buffer that receives the subset
		/// title text.
		/// </summary>
		public StrPtrAuto pszSubsetTitle;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszSubsetTitle member. If the structure is not receiving information about a
		/// group, this member is ignored.
		/// </summary>
		public uint cchSubsetTitle;

		/*public LVGROUP(ListViewGroup grp) : this(ListViewGroupMask.LVGF_NONE, grp.Header)
		{
			HeaderAlignment = grp.HeaderAlignment;
			var pi = grp.GetType().GetProperty("ID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, typeof(int), Type.EmptyTypes, null);
			if (pi != null)
				ID = (int)pi.GetValue(grp, null);
		}*/

		/// <summary>Initializes a new instance of the <see cref="LVGROUP"/> class.</summary>
		/// <param name="mask">The mask.</param>
		/// <param name="header">The header text.</param>
		public LVGROUP(ListViewGroupMask mask = ListViewGroupMask.LVGF_NONE, string? header = null)
		{
			this.mask = mask;

			if (header != null)
				Header = header;
			else if ((mask & ListViewGroupMask.LVGF_HEADER) != 0)
				pszHeader = new StrPtrAuto(cchHeader = 1024);

			if ((mask & ListViewGroupMask.LVGF_FOOTER) != 0)
				pszFooter = new StrPtrAuto(cchFooter = 1024);

			if ((mask & ListViewGroupMask.LVGF_SUBTITLE) != 0)
				pszSubtitle = new StrPtrAuto(cchSubtitle = 1024);

			if ((mask & ListViewGroupMask.LVGF_TASK) != 0)
				pszTask = new StrPtrAuto(cchTask = 1024);

			if ((mask & ListViewGroupMask.LVGF_DESCRIPTIONBOTTOM) != 0)
				pszDescriptionBottom = new StrPtrAuto(cchDescriptionBottom = 1024);

			if ((mask & ListViewGroupMask.LVGF_DESCRIPTIONTOP) != 0)
				pszDescriptionTop = new StrPtrAuto(cchDescriptionTop = 1024);
		}

		/// <summary>Gets or sets the bottom description text.</summary>
		/// <value>The bottom description text.</value>
		public string? DescriptionBottom
		{
			get => pszDescriptionBottom.ToString();
			set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_DESCRIPTIONBOTTOM, pszDescriptionBottom.Assign(value, out cchDescriptionBottom));
		}

		/// <summary>Gets or sets the top description text.</summary>
		/// <value>The top description text.</value>
		public string? DescriptionTop
		{
			get => pszDescriptionTop.ToString();
			set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_DESCRIPTIONTOP, pszDescriptionTop.Assign(value, out cchDescriptionTop));
		}

		/// <summary>Gets or sets the footer.</summary>
		/// <value>The footer.</value>
		public string? Footer
		{
			get => pszFooter.ToString();
			set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_FOOTER, pszFooter.Assign(value, out cchFooter));
		}

		/// <summary>Gets or sets the identifier.</summary>
		/// <value>The identifier.</value>
		public int ID
		{
			get => iGroupId; set { iGroupId = value; mask |= ListViewGroupMask.LVGF_GROUPID; }
		}

		/// <summary>Gets or sets the index of the title image.</summary>
		/// <value>The index of the title image.</value>
		public int TitleImageIndex
		{
			get => iTitleImage; set { iTitleImage = value; mask |= ListViewGroupMask.LVGF_TITLEIMAGE; }
		}

		/// <summary>Gets or sets the index of the extended image.</summary>
		/// <value>The index of the extended image.</value>
		public int ExtendedImageIndex
		{
			get => iExtendedImage; set { iExtendedImage = value; mask |= ListViewGroupMask.LVGF_EXTENDEDIMAGE; }
		}

		/// <summary>Gets the first item.</summary>
		/// <value>The first item.</value>
		public int FirstItem => iFirstItem;

		/// <summary>Gets the item count.</summary>
		/// <value>The item count.</value>
		public uint ItemCount => cItems;

		/// <summary>Gets or sets the alignment.</summary>
		/// <value>The alignment.</value>
		public ListViewGroupAlignment Alignment
		{
			get => uAlign; set { uAlign = value; mask |= ListViewGroupMask.LVGF_ALIGN; }
		}

		/// <summary>Gets or sets the header text.</summary>
		/// <value>The header text.</value>
		public string? Header
		{
			get => pszHeader.ToString();
			set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_HEADER, pszHeader.Assign(value, out cchHeader));
		}

		/// <summary>Gets or sets the subtitle.</summary>
		/// <value>The subtitle.</value>
		public string? Subtitle
		{
			get => pszSubtitle.ToString();
			set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_SUBTITLE, pszSubtitle.Assign(value, out cchSubtitle));
		}

		/// <summary>Gets or sets the task link text.</summary>
		/// <value>The task link text.</value>
		public string? TaskLink
		{
			get => pszTask.ToString();
			set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_TASK, pszTask.Assign(value, out cchTask));
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			pszHeader.Free();
			pszFooter.Free();
			pszSubtitle.Free();
			pszTask.Free();
			pszDescriptionBottom.Free();
			pszDescriptionTop.Free();
		}

		/// <summary>Sets the state.</summary>
		/// <param name="gState">State of the g.</param>
		/// <param name="on">if set to <c>true</c> [on].</param>
		public void SetState(ListViewGroupState gState, bool on = true)
		{
			mask |= ListViewGroupMask.LVGF_STATE;
			stateMask |= gState;
			EnumExtensions.SetFlags(ref state, gState, on);
		}
	}

	/// <summary>
	/// Specifies or receives the attributes of a list-view item. This structure has been updated to support a new mask value (LVIF_INDENT)
	/// that enables item indenting. This structure supersedes the LV_ITEM structure.
	/// </summary>
	/// <seealso cref="IDisposable"/>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774760")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public sealed class LVITEM : IDisposable
	{
		private const int MAX_COLS = 20;
		private const int OverlayShift = 8;
		private const int StateImageShift = 12;

		/// <summary>
		/// Set of flags that specify which members of this structure contain data to be set or which members are being requested. This
		/// member can have one or more of the following flags set:
		/// </summary>
		public ListViewItemMask mask;

		/// <summary>Zero-based index of the item to which this structure refers.</summary>
		public int iItem;

		/// <summary>
		/// One-based index of the subitem to which this structure refers, or zero if this structure refers to an item rather than a subitem.
		/// </summary>
		public int iSubItem;

		/// <summary>
		/// Indicates the item's state, state image, and overlay image. The stateMask member indicates the valid bits of this member.
		/// <para>Bits 0 through 7 of this member contain the item state flags. This can be one or more of the item state values.</para>
		/// <para>
		/// Bits 8 through 11 of this member specify the one-based overlay image index. Both the full-sized icon image list and the small
		/// icon image list can have overlay images. The overlay image is superimposed over the item's icon image. If these bits are zero,
		/// the item has no overlay image. To isolate these bits, use the LVIS_OVERLAYMASK mask. To set the overlay image index in this
		/// member, you should use the INDEXTOOVERLAYMASK macro. The image list's overlay images are set with the ImageList_SetOverlayImage function.
		/// </para>
		/// <para>
		/// Bits 12 through 15 of this member specify the state image index. The state image is displayed next to an item's icon to indicate
		/// an application-defined state. If these bits are zero, the item has no state image. To isolate these bits, use the
		/// LVIS_STATEIMAGEMASK mask. To set the state image index, use the INDEXTOSTATEIMAGEMASK macro. The state image index specifies the
		/// index of the image in the state image list that should be drawn. The state image list is specified with the LVM_SETIMAGELIST message.
		/// </para>
		/// </summary>
		public uint state;

		/// <summary>
		/// Value specifying which bits of the state member will be retrieved or modified. For example, setting this member to LVIS_SELECTED
		/// will cause only the item's selection state to be retrieved.
		/// <para>
		/// This member allows you to modify one or more item states without having to retrieve all of the item states first.For example,
		/// setting this member to LVIS_SELECTED and state to zero will cause the item's selection state to be cleared, but none of the other
		/// states will be affected.
		/// </para>
		/// <para>To retrieve or modify all of the states, set this member to(UINT)-1.</para>
		/// <para>You can use the macro ListView_SetItemState both to set and to clear bits.</para>
		/// </summary>
		public ListViewItemState stateMask;

		/// <summary>
		/// If the structure specifies item attributes, pszText is a pointer to a null-terminated string containing the item text. When
		/// responding to an LVN_GETDISPINFO notification, be sure that this pointer remains valid until after the next notification has been received.
		/// <para>
		/// If the structure receives item attributes, pszText is a pointer to a buffer that receives the item text. Note that although the
		/// list-view control allows any length string to be stored as item text, only the first 260 TCHARs are displayed.
		/// </para>
		/// <para>
		/// If the value of pszText is LPSTR_TEXTCALLBACK, the item is a callback item.If the callback text changes, you must explicitly set
		/// pszText to LPSTR_TEXTCALLBACK and notify the list-view control of the change by sending an LVM_SETITEM or LVM_SETITEMTEXT message.
		/// </para>
		/// <para>Do not set pszText to LPSTR_TEXTCALLBACK if the list-view control has the LVS_SORTASCENDING or LVS_SORTDESCENDING style.</para>
		/// </summary>
		public StrPtrAuto pszText;

		/// <summary>
		/// Number of TCHARs in the buffer pointed to by pszText, including the terminating NULL.
		/// <para>
		/// This member is only used when the structure receives item attributes.It is ignored when the structure specifies item
		/// attributes.For example, cchTextMax is ignored during LVM_SETITEM and LVM_INSERTITEM.It is read-only during LVN_GETDISPINFO and
		/// other LVN_ notifications.
		/// </para>
		/// <note>Never copy more than cchTextMax TCHARs—where cchTextMax includes the terminating NULL—into pszText during an LVN_
		/// notification, otherwise your program can fail.</note>
		/// </summary>
		public uint cchTextMax;

		/// <summary>
		/// Index of the item's icon in the control's image list. This applies to both the large and small image list. If this member is the
		/// I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the list-view control sends the
		/// parent an LVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.
		/// </summary>
		public int iImage;

		/// <summary>
		/// Value specific to the item. If you use the LVM_SORTITEMS message, the list-view control passes this value to the
		/// application-defined comparison function. You can also use the LVM_FINDITEM message to search a list-view control for an item with
		/// a specified lParam value.
		/// </summary>
		public IntPtr lParam;

		/// <summary>
		/// Version 4.70. Number of image widths to indent the item. A single indentation equals the width of an item image. Therefore, the
		/// value 1 indents the item by the width of one image, the value 2 indents by two images, and so on. Note that this field is
		/// supported only for items. Attempting to set subitem indentation will cause the calling function to fail.
		/// </summary>
		public int iIndent;

		/// <summary>
		/// Version 6.0 Identifier of the group that the item belongs to, or one of the following values: I_GROUPIDCALLBACK = The listview
		/// control sends the parent an LVN_GETDISPINFO notification code to retrieve the index of the group; I_GROUPIDNONE = The item does
		/// not belong to a group.
		/// </summary>
		public int iGroupId;

		/// <summary>
		/// Version 6.0 Number of data columns (subitems) to display for this item in tile view. The maximum value is 20. If this value is
		/// I_COLUMNSCALLBACK, the size of the column array and the array itself (puColumns) are obtained by sending a LVN_GETDISPINFO notification.
		/// </summary>
		public uint cColumns;

		/// <summary>
		/// Version 6.0 A pointer to an array of column indices, specifying which columns are displayed for this item, and the order of those columns.
		/// </summary>
		public IntPtr puColumns;

		/// <summary>
		/// Windows Vista: Not implemented. Windows 7 and later: A pointer to an array of the following flags (alone or in combination),
		/// specifying the format of each subitem in extended tile view.
		/// </summary>
		public IntPtr piColFmt;

		/// <summary>Windows Vista: Group index of the item. Valid only for owner data/callback (single item in multiple groups).</summary>
		public int iGroup;

		/// <summary>Initializes a new instance of the <see cref="LVITEM"/> class.</summary>
		/// <param name="item">Zero-based index of the item.</param>
		/// <param name="subitem">One-based index of the subitem.</param>
		/// <param name="mask">The mask of items to retrieve.</param>
		/// <param name="stateMask">The state items to retrieve.</param>
		public LVITEM(int item, int subitem, ListViewItemMask mask = ListViewItemMask.LVIF_ALL, ListViewItemState stateMask = ListViewItemState.LVIS_ALL)
		{
			this.mask = mask;
			if (mask.IsFlagSet(ListViewItemMask.LVIF_TEXT))
				pszText = new StrPtrAuto(cchTextMax = 1024);
			if (mask.IsFlagSet(ListViewItemMask.LVIF_COLUMNS))
				puColumns = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * MAX_COLS);
			if (mask.IsFlagSet(ListViewItemMask.LVIF_COLFMT))
				piColFmt = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * MAX_COLS);
			iItem = item;
			iSubItem = subitem;
			this.stateMask = stateMask;
		}

		/// <summary>Initializes a new instance of the <see cref="LVITEM"/> class.</summary>
		/// <param name="item">Zero-based index of the item.</param>
		/// <param name="subitem">One-based index of the subitem or zero if this structure refers to an item rather than a subitem.</param>
		/// <param name="text">The item text.</param>
		public LVITEM(int item, int subitem = 0, string? text = null)
		{
			iItem = item;
			iSubItem = subitem;
			if (text != null) Text = text;
		}

		/// <summary>Gets or sets the group identifier.</summary>
		/// <value>The group identifier.</value>
		public int GroupId
		{
			get => iGroupId;
			set { iGroupId = value; EnumExtensions.SetFlags(ref mask, ListViewItemMask.LVIF_GROUPID); }
		}

		/// <summary>Gets or sets the index of the image.</summary>
		/// <value>The index of the image.</value>
		public int ImageIndex
		{
			get => iImage;
			set { iImage = value; EnumExtensions.SetFlags(ref mask, ListViewItemMask.LVIF_IMAGE); }
		}

		/// <summary>Gets or sets the indent.</summary>
		/// <value>The indent.</value>
		public int Indent
		{
			get => iIndent;
			set { iIndent = value; EnumExtensions.SetFlags(ref mask, ListViewItemMask.LVIF_INDENT); }
		}

		/// <summary>Gets or sets the l parameter.</summary>
		/// <value>The l parameter.</value>
		public IntPtr LParam
		{
			get => lParam;
			set { lParam = value; EnumExtensions.SetFlags(ref mask, ListViewItemMask.LVIF_PARAM); }
		}

		/// <summary>Gets or sets the text.</summary>
		/// <value>The text.</value>
		public string Text
		{
			get => pszText.ToString();
			set => EnumExtensions.SetFlags(ref mask, ListViewItemMask.LVIF_TEXT, pszText.Assign(value, out cchTextMax));
		}

		/// <summary>Gets or sets the tile columns.</summary>
		/// <value>The tile columns.</value>
		public LVITEMCOLUMNINFO[] TileColumns
		{
			get
			{
				LVITEMCOLUMNINFO[] ret = new LVITEMCOLUMNINFO[cColumns];
				if (cColumns == 0) return ret;
				int[]? cols = puColumns.ToArray<int>((int)cColumns);
				int[]? fmts = piColFmt.ToArray<int>((int)cColumns);
				for (int i = 0; i < cColumns; i++)
					ret[i] = new LVITEMCOLUMNINFO((uint)(cols?[i] ?? 0), (ListViewColumnFormat)(fmts?[i] ?? 0));
				return ret;
			}
			set
			{
				Marshal.FreeHGlobal(puColumns);
				Marshal.FreeHGlobal(piColFmt);

				cColumns = (uint)(value?.Length ?? 0);
				puColumns = piColFmt = IntPtr.Zero;

				if (value == null)
				{
					EnumExtensions.SetFlags(ref mask, ListViewItemMask.LVIF_COLFMT | ListViewItemMask.LVIF_COLUMNS, false);
					return;
				}

				int[] cols = new int[cColumns];
				int[] fmts = new int[cColumns];
				bool hasFmts = false;
				for (int i = 0; i < cColumns; i++)
				{
					cols[i] = (int)value[i].columnIndex;
					fmts[i] = (int)value[i].format;
					if (fmts[i] != 0) hasFmts = true;
				}
				if (cColumns > 0)
				{
					puColumns = cols.MarshalToPtr(Marshal.AllocHGlobal, out _);
				}
				EnumExtensions.SetFlags(ref mask, ListViewItemMask.LVIF_COLUMNS);
				if (hasFmts)
				{
					piColFmt = fmts.MarshalToPtr(Marshal.AllocHGlobal, out _);
					EnumExtensions.SetFlags(ref mask, ListViewItemMask.LVIF_COLFMT);
				}
			}
		}

		/// <summary>Gets the state.</summary>
		/// <param name="state">The state.</param>
		/// <returns>The value of the specified state.</returns>
		private bool GetState(ListViewItemState state) => StateFlags.IsFlagSet(state);

		/// <summary>Sets the state.</summary>
		/// <param name="state">The state value to set.</param>
		/// <param name="value"><c>true</c> to set, <c>false</c> to unset.</param>
		private void SetState(ListViewItemState state, bool value)
		{
			mask |= ListViewItemMask.LVIF_STATE;
			stateMask |= state;
			this.state = (uint)StateFlags.SetFlags(state, value) | ((uint)state & 0xFFFFFF00);
		}

		/// <summary>Gets the state flags.</summary>
		/// <value>The state flags.</value>
		public ListViewItemState StateFlags => (ListViewItemState)(state & 0x000000FF);

		/// <summary>Gets or sets a value indicating whether the item is marked for a cut-and-paste operation.</summary>
		/// <value><c>true</c> if marked for a cut-and-paste operation; otherwise, <c>false</c>.</value>
		public bool CutOrPaste { get => GetState(ListViewItemState.LVIS_CUT); set => SetState(ListViewItemState.LVIS_CUT, value); }

		/// <summary>Gets or sets a value indicating whether the item is highlighted as a drag-and-drop target.</summary>
		/// <value><c>true</c> if highlighted as a drag-and-drop target; otherwise, <c>false</c>.</value>
		public bool DropHighlighted { get => GetState(ListViewItemState.LVIS_DROPHILITED); set => SetState(ListViewItemState.LVIS_DROPHILITED, value); }

		/// <summary>Gets or sets a value indicating whether this item has the focus.</summary>
		/// <value><c>true</c> if focused; otherwise, <c>false</c>.</value>
		public bool Focused { get => GetState(ListViewItemState.LVIS_FOCUSED); set => SetState(ListViewItemState.LVIS_FOCUSED, value); }

		/// <summary>Gets or sets a value indicating whether this item is selected.</summary>
		/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
		public bool Selected { get => GetState(ListViewItemState.LVIS_SELECTED); set => SetState(ListViewItemState.LVIS_SELECTED, value); }

		/// <summary>Gets or sets the index of the overlay image.</summary>
		/// <value>The index of the overlay image.</value>
		/// <exception cref="ArgumentOutOfRangeException">OverlayImageIndex - Overlay image index must be between 0 and 15</exception>
		public uint OverlayImageIndex
		{
			get => (state & (uint)ListViewItemState.LVIS_OVERLAYMASK) >> OverlayShift;
			set
			{
				if (value > 0xF)
					throw new ArgumentOutOfRangeException(nameof(OverlayImageIndex), "Overlay image index must be between 0 and 15");
				mask |= ListViewItemMask.LVIF_STATE;
				stateMask |= ListViewItemState.LVIS_OVERLAYMASK;
				state = (value << OverlayShift) | (state & ~(uint)ListViewItemState.LVIS_OVERLAYMASK);
			}
		}

		/// <summary>Gets or sets the index of the state image.</summary>
		/// <value>The index of the state image.</value>
		/// <exception cref="ArgumentOutOfRangeException">StateImageIndex - State image index must be between 0 and 15</exception>
		public uint StateImageIndex
		{
			get => (state & (uint)ListViewItemState.LVIS_STATEIMAGEMASK) >> StateImageShift;
			set
			{
				if (value > 0xF)
					throw new ArgumentOutOfRangeException(nameof(StateImageIndex), "State image index must be between 0 and 15");
				mask |= ListViewItemMask.LVIF_STATE;
				stateMask |= ListViewItemState.LVIS_STATEIMAGEMASK;
				state = (value << StateImageShift) | (state & ~(uint)ListViewItemState.LVIS_STATEIMAGEMASK);
			}
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => $"LVITEM: pszText={Text}; iItem={iItem}; iSubItem={iSubItem}; state={state}; iGroupId={iGroupId}; cColumns={cColumns}";

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			Marshal.FreeHGlobal(puColumns);
			Marshal.FreeHGlobal(piColFmt);
			pszText.Free();
		}
	}

	/// <summary>Provides information about an item in a list-view control when it is displayed in tile view.</summary>
	/// <remarks>
	/// <para>
	/// In tile view, the item name is displayed to the right of the icon. You can specify additional subitems (corresponding to columns in
	/// the details view), to be displayed on lines below the item name. The <c>puColumns</c> array contains the indices of subitems to be
	/// displayed. Indices should be greater than 0, because subitem 0, the item name, is already displayed.
	/// </para>
	/// <para>Column information can also be set in the LVITEM structure when creating the list item.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-lvtileinfo typedef struct tagLVTILEINFO { UINT cbSize; int
	// iItem; UINT cColumns; PUINT puColumns; int *piColFmt; } LVTILEINFO, *PLVTILEINFO;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagLVTILEINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public class LVTILEINFO : IDisposable
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the <c>LVTILEINFO</c> structure.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The item for which the information is retrieved or set.</para>
		/// </summary>
		public int iItem;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of data columns displayed for this item. When retrieving information, initialize this value to the size of the
		/// <c>puColumns</c> array. On return, the member is set to the number of columns actually set for the item.
		/// </para>
		/// </summary>
		public uint cColumns;

		/// <summary>
		/// <para>Type: <c>PUINT</c></para>
		/// <para>
		/// A pointer to an array of column indices, specifying which columns are displayed for this item, and the order of those columns.
		/// When retrieving information, allocate an array large enough to hold the greatest number of columns expected.
		/// </para>
		/// </summary>
		public IntPtr puColumns;

		/// <summary>
		/// <para>Type: <c>int*</c></para>
		/// <para>
		/// A pointer to an array of column formats (for example, LVCFMT_LEFT), one for each of the columns specified in <c>puColumns</c>.
		/// When retrieving information, allocate an array large enough to hold the greatest number of column formats expected.
		/// </para>
		/// </summary>
		public IntPtr piColFmt;

		/// <summary>Initializes a new instance of the <see cref="LVTILEINFO"/> class.</summary>
		/// <param name="item">The item for which the information is retrieved or set.</param>
		/// <param name="columnFormats">A dictionary of column indicies and their associated formats.</param>
		public LVTILEINFO(int item, IReadOnlyDictionary<int, ListViewColumnFormat> columnFormats)
		{
			cbSize = (uint)Marshal.SizeOf<LVTILEINFO>();
			iItem = item;
			ColumnFormats = columnFormats;
		}

		/// <summary>A dictionary of column indicies and their associated formats.</summary>
		public IReadOnlyDictionary<int, ListViewColumnFormat> ColumnFormats
		{
			get => cColumns == 0 ? new() : puColumns.ToArray<int>((int)cColumns)!.Zip(piColFmt.ToArray<ListViewColumnFormat>((int)cColumns)!, (i, f) => new { i, f }).
				ToDictionary(i => i.i, i => i.f);
			set
			{
				Dispose();
				cColumns = (uint)value.Count;
				puColumns = value.Keys.MarshalToPtr(Marshal.AllocCoTaskMem, out _);
				piColFmt = value.Values.Cast<int>().MarshalToPtr(Marshal.AllocCoTaskMem, out _);
			}
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			Marshal.FreeCoTaskMem(puColumns);
			Marshal.FreeCoTaskMem(piColFmt);
		}
	}
}