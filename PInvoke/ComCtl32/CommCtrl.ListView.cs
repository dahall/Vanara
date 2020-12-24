using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
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

		private const uint LVM_FIRST = 0x1000;
		private const int LVN_FIRST = -0x100;

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
			/// A background bitmap is supplied via the hbm member of LVBKIMAGE. If the message LVM_SETBKIMAGE succeeds, then the list-view
			/// takes ownership of the bitmap.
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
			/// Specify the coordinates of the first tile. This flag is valid only if the LVBKIF_STYLE_TILE flag is also specified. If this
			/// flag is not specified, the first tile begins at the upper-left corner of the client area. If you use ComCtl32.dll Version
			/// 6.0 the xOffsetPercent and yOffsetPercent fields contain pixels, not percentage values, to specify the coordinates of the
			/// first tile. Comctl32.dll version 6 is not redistributable but it is included in Windows or later. Also, you must specify
			/// Comctl32.dll version 6 in a manifest. For more information on manifests, see Enabling Visual Styles.
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
		/// Alignment of the column header and the subitem text in the column. The alignment of the leftmost column is always LVCFMT_LEFT;
		/// it cannot be changed. This member can be a combination of the following values. Note that not all combinations are valid.
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
			/// A bitmask used to select those bits of fmt that control field justification. To check the format of a column, use a logical
			/// "and" to combine LCFMT_JUSTIFYMASK with fmt. You can then use a switch statement to determine whether the LVCFMT_LEFT,
			/// LVCFMT_RIGHT, or LVCFMT_CENTER bits are set.
			/// </summary>
			LVCFMT_JUSTIFYMASK = 0X0003,

			/// <summary>Version 4.70. The item displays an image from an image list.</summary>
			LVCFMT_IMAGE = 0X0800,

			/// <summary>
			/// Version 4.70. The bitmap appears to the right of text. This does not affect an image from an image list assigned to the
			/// header item.
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
			/// Version 6.00 and Windows Vista. Column is a split button (same as HDF_SPLITBUTTON). The header of the column displays a
			/// split button (same as HDF_SPLITBUTTON).
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
			/// Searches based on the item text. Unless additional values are specified, the item text of the matching item must exactly
			/// match the string pointed to by the psz member. However, the search is case-insensitive.
			/// </summary>
			LVFI_STRING = 0X0002,

			/// <summary>Windows Vista and later. Equivalent to LVFI_PARTIAL.</summary>
			LVFI_SUBSTRING = 0X0004,

			/// <summary>
			/// Checks to see if the item text begins with the string pointed to by the psz member. This value implies use of LVFI_STRING.
			/// </summary>
			LVFI_PARTIAL = 0X0008,

			/// <summary>
			/// Continues the search at the beginning if no match is found. If this flag is used by itself, it is assumed that a string
			/// search is wanted.
			/// </summary>
			LVFI_WRAP = 0X0020,

			/// <summary>
			/// Finds the item nearest to the position specified in the pt member, in the direction specified by the vkDirection member.
			/// This flag is supported only by large icon and small icon modes. If LVFI_NEARESTXY is specified, all other flags are ignored.
			/// </summary>
			LVFI_NEARESTXY = 0X0040,
		}

		/// <summary>
		/// Indicates the alignment of the header or footer text for the group. It can have one or more of the following values. Use one of
		/// the header flags. Footer flags are optional.
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
			/// Coordinates of the subset link only (markup subset). A list-view control can limit the number of visible items displayed in
			/// each group. A link is presented to the user to allow the user to expand the group. This flag will return the bounding
			/// rectangle of the subset link if the group is a subset (group state of LVGS_SUBSETED, see structure LVGROUP, member state).
			/// This flag is provided so that accessibility applications can located the link.
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
			/// The control will not generate LVN_GETDISPINFO to retrieve text information if it receives an LVM_GETITEM message. Instead,
			/// the pszText member will contain LPSTR_TEXTCALLBACK.
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
			/// Windows Vista and later. The piColFmt member is valid or must be set. If this flag is used, the cColumns member is valid or
			/// must be set.
			/// </summary>
			LVIF_COLFMT = 0x00010000,

			/// <summary>
			/// The operating system should store the requested list item information and not ask for it again. This flag is used only with
			/// the LVN_GETDISPINFO notification code.
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
		/// An item's state value consists of the item's state, an optional overlay mask index, and an optional state image mask index. An
		/// item's state determines its appearance and functionality. The state can be zero or one or more of the following values:
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
		[Flags]
		public enum ListViewItemState : uint
		{
			/// <summary>No flags set.</summary>
			LVIS_NONE = 0x0000,

			/// <summary>
			/// The item has the focus, so it is surrounded by a standard focus rectangle. Although more than one item may be selected, only
			/// one item can have the focus.
			/// </summary>
			LVIS_FOCUSED = 0x0001,

			/// <summary>
			/// The item is selected. The appearance of a selected item depends on whether it has the focus and also on the system colors
			/// used for selection.
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			LVM_SETUNICODEFORMAT = 0X2005,        // CCM_SETUNICODEFORMAT,
			LVM_GETUNICODEFORMAT = 0X2006,        // CCM_GETUNICODEFORMAT,
			LVM_GETBKCOLOR = LVM_FIRST + 0,
			LVM_SETBKCOLOR = LVM_FIRST + 1,
			LVM_GETIMAGELIST = LVM_FIRST + 2,
			LVM_SETIMAGELIST = LVM_FIRST + 3,
			LVM_GETITEMCOUNT = LVM_FIRST + 4,
			LVM_GETITEM = LVM_FIRST + 75,
			LVM_SETITEM = LVM_FIRST + 76,
			LVM_INSERTITEM = LVM_FIRST + 77,
			LVM_DELETEITEM = LVM_FIRST + 8,
			LVM_DELETEALLITEMS = LVM_FIRST + 9,
			LVM_GETCALLBACKMASK = LVM_FIRST + 10,
			LVM_SETCALLBACKMASK = LVM_FIRST + 11,
			LVM_GETNEXTITEM = LVM_FIRST + 12,
			LVM_FINDITEM = LVM_FIRST + 83,
			LVM_GETITEMRECT = LVM_FIRST + 14,
			LVM_SETITEMPOSITION = LVM_FIRST + 15,
			LVM_GETITEMPOSITION = LVM_FIRST + 16,
			LVM_GETSTRINGWIDTH = LVM_FIRST + 87,
			LVM_HITTEST = LVM_FIRST + 18,
			LVM_ENSUREVISIBLE = LVM_FIRST + 19,
			LVM_SCROLL = LVM_FIRST + 20,
			LVM_REDRAWITEMS = LVM_FIRST + 21,
			LVM_ARRANGE = LVM_FIRST + 22,
			LVM_EDITLABEL = LVM_FIRST + 118,
			LVM_GETEDITCONTROL = LVM_FIRST + 24,
			LVM_GETCOLUMN = LVM_FIRST + 95,
			LVM_SETCOLUMN = LVM_FIRST + 96,
			LVM_INSERTCOLUMN = LVM_FIRST + 97,
			LVM_DELETECOLUMN = LVM_FIRST + 28,
			LVM_GETCOLUMNWIDTH = LVM_FIRST + 29,
			LVM_SETCOLUMNWIDTH = LVM_FIRST + 30,
			LVM_GETHEADER = LVM_FIRST + 31,
			LVM_CREATEDRAGIMAGE = LVM_FIRST + 33,
			LVM_GETVIEWRECT = LVM_FIRST + 34,
			LVM_GETTEXTCOLOR = LVM_FIRST + 35,
			LVM_SETTEXTCOLOR = LVM_FIRST + 36,
			LVM_GETTEXTBKCOLOR = LVM_FIRST + 37,
			LVM_SETTEXTBKCOLOR = LVM_FIRST + 38,
			LVM_GETTOPINDEX = LVM_FIRST + 39,
			LVM_GETCOUNTPERPAGE = LVM_FIRST + 40,
			LVM_GETORIGIN = LVM_FIRST + 41,
			LVM_UPDATE = LVM_FIRST + 42,
			LVM_SETITEMSTATE = LVM_FIRST + 43,
			LVM_GETITEMSTATE = LVM_FIRST + 44,
			LVM_GETITEMTEXT = LVM_FIRST + 115,
			LVM_SETITEMTEXT = LVM_FIRST + 116,
			LVM_SETITEMCOUNT = LVM_FIRST + 47,
			LVM_SORTITEMS = LVM_FIRST + 48,
			LVM_SETITEMPOSITION32 = LVM_FIRST + 49,
			LVM_GETSELECTEDCOUNT = LVM_FIRST + 50,
			LVM_GETITEMSPACING = LVM_FIRST + 51,
			LVM_GETISEARCHSTRING = LVM_FIRST + 117,
			LVM_SETICONSPACING = LVM_FIRST + 53,
			LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54,            // OPTIONAL WPARAM == MASK
			LVM_GETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 55,
			LVM_GETSUBITEMRECT = LVM_FIRST + 56,
			LVM_SUBITEMHITTEST = LVM_FIRST + 57,
			LVM_SETCOLUMNORDERARRAY = LVM_FIRST + 58,
			LVM_GETCOLUMNORDERARRAY = LVM_FIRST + 59,
			LVM_SETHOTITEM = LVM_FIRST + 60,
			LVM_GETHOTITEM = LVM_FIRST + 61,
			LVM_SETHOTCURSOR = LVM_FIRST + 62,
			LVM_GETHOTCURSOR = LVM_FIRST + 63,
			LVM_APPROXIMATEVIEWRECT = LVM_FIRST + 64,
			LVM_SETWORKAREAS = LVM_FIRST + 65,
			LVM_GETWORKAREAS = LVM_FIRST + 70,
			LVM_GETNUMBEROFWORKAREAS = LVM_FIRST + 73,
			LVM_GETSELECTIONMARK = LVM_FIRST + 66,
			LVM_SETSELECTIONMARK = LVM_FIRST + 67,
			LVM_SETHOVERTIME = LVM_FIRST + 71,
			LVM_GETHOVERTIME = LVM_FIRST + 72,
			LVM_SETTOOLTIPS = LVM_FIRST + 74,
			LVM_GETTOOLTIPS = LVM_FIRST + 78,
			LVM_SORTITEMSEX = LVM_FIRST + 81,
			LVM_SETBKIMAGE = LVM_FIRST + 138,
			LVM_GETBKIMAGE = LVM_FIRST + 139,
			LVM_SETSELECTEDCOLUMN = LVM_FIRST + 140,
			LVM_SETVIEW = LVM_FIRST + 142,
			LVM_GETVIEW = LVM_FIRST + 143,
			LVM_INSERTGROUP = LVM_FIRST + 145,
			LVM_SETGROUPINFO = LVM_FIRST + 147,
			LVM_GETGROUPINFO = LVM_FIRST + 149,
			LVM_REMOVEGROUP = LVM_FIRST + 150,
			LVM_MOVEGROUP = LVM_FIRST + 151,
			LVM_GETGROUPCOUNT = LVM_FIRST + 152,
			LVM_GETGROUPINFOBYINDEX = LVM_FIRST + 153,
			LVM_MOVEITEMTOGROUP = LVM_FIRST + 154,
			LVM_GETGROUPRECT = LVM_FIRST + 98,
			LVM_SETGROUPMETRICS = LVM_FIRST + 155,
			LVM_GETGROUPMETRICS = LVM_FIRST + 156,
			LVM_ENABLEGROUPVIEW = LVM_FIRST + 157,
			LVM_SORTGROUPS = LVM_FIRST + 158,
			LVM_INSERTGROUPSORTED = LVM_FIRST + 159,
			LVM_REMOVEALLGROUPS = LVM_FIRST + 160,
			LVM_HASGROUP = LVM_FIRST + 161,
			LVM_GETGROUPSTATE = LVM_FIRST + 92,
			LVM_GETFOCUSEDGROUP = LVM_FIRST + 93,
			LVM_SETTILEVIEWINFO = LVM_FIRST + 162,
			LVM_GETTILEVIEWINFO = LVM_FIRST + 163,
			LVM_SETTILEINFO = LVM_FIRST + 164,
			LVM_GETTILEINFO = LVM_FIRST + 165,
			LVM_SETINSERTMARK = LVM_FIRST + 166,
			LVM_GETINSERTMARK = LVM_FIRST + 167,
			LVM_INSERTMARKHITTEST = LVM_FIRST + 168,
			LVM_GETINSERTMARKRECT = LVM_FIRST + 169,
			LVM_SETINSERTMARKCOLOR = LVM_FIRST + 170,
			LVM_GETINSERTMARKCOLOR = LVM_FIRST + 171,
			LVM_GETSELECTEDCOLUMN = LVM_FIRST + 174,
			LVM_ISGROUPVIEWENABLED = LVM_FIRST + 175,
			LVM_GETOUTLINECOLOR = LVM_FIRST + 176,
			LVM_SETOUTLINECOLOR = LVM_FIRST + 177,
			LVM_CANCELEDITLABEL = LVM_FIRST + 179,
			LVM_MAPINDEXTODD = LVM_FIRST + 180,
			LVM_MAPIDTOINDEX = LVM_FIRST + 181,
			LVM_ISITEMVISIBLE = LVM_FIRST + 182,
			LVM_GETACCVERSION = LVM_FIRST + 193,
			LVM_GETEMPTYTEXT = LVM_FIRST + 204,
			LVM_GETFOOTERRECT = LVM_FIRST + 205,
			LVM_GETFOOTERINFO = LVM_FIRST + 206,
			LVM_GETFOOTERITEMRECT = LVM_FIRST + 207,
			LVM_GETFOOTERITEM = LVM_FIRST + 208,
			LVM_GETITEMINDEXRECT = LVM_FIRST + 209,
			LVM_SETITEMINDEXSTATE = LVM_FIRST + 210,
			LVM_GETNEXTITEMINDEX = LVM_FIRST + 211,
			LVM_SETPRESERVEALPHA = LVM_FIRST + 212,
			/*LVM_SetBkImage               = SETBKIMAGEW,
			LVM_GetBkImage               = GETBKIMAGEW,*/
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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

			/// <summary>
			/// Windows Vista and later: A state flag mask with value as follows: LVNI_FOCUSED | LVNI_SELECTED | LVNI_CUT | LVNI_DROPHILITED.
			/// </summary>
			LVNI_STATEMASK = LVNI_FOCUSED | LVNI_SELECTED | LVNI_CUT | LVNI_DROPHILITED,

			/// <summary>Windows Vista and later: Search the visible order.</summary>
			LVNI_VISIBLEORDER = 0X0010,

			/// <summary>
			/// Windows Vista and later: Searches for an item that is ordered before the item specified in wParam. The LVNI_PREVIOUS flag is
			/// not directional (LVNI_ABOVE will find the item positioned above, while LVNI_PREVIOUS will find the item ordered before.) The
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

			/// <summary>
			/// Windows Vista and later: A directional flag mask with value as follows: LVNI_ABOVE | LVNI_BELOW | LVNI_TOLEFT | LVNI_TORIGHT.
			/// </summary>
			LVNI_DIRECTIONMASK = LVNI_ABOVE | LVNI_BELOW | LVNI_TOLEFT | LVNI_TORIGHT,
		}

		/// <summary>ListView notification identifiers.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
		public enum ListViewNotification
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			LVN_BEGINDRAG = (LVN_FIRST - 9),
			LVN_BEGINLABELEDIT = LVN_BEGINLABELEDITW,
			LVN_BEGINLABELEDITA = (LVN_FIRST - 5),
			LVN_BEGINLABELEDITW = (LVN_FIRST - 75),
			LVN_BEGINRDRAG = (LVN_FIRST - 11),
			LVN_BEGINSCROLL = (LVN_FIRST - 80),
			LVN_COLUMNCLICK = (LVN_FIRST - 8),
			LVN_COLUMNDROPDOWN = (LVN_FIRST - 64),
			LVN_COLUMNOVERFLOWCLICK = (LVN_FIRST - 66),
			LVN_DELETEALLITEMS = (LVN_FIRST - 4),
			LVN_DELETEITEM = (LVN_FIRST - 3),
			LVN_ENDLABELEDIT = LVN_ENDLABELEDITW,
			LVN_ENDLABELEDITA = (LVN_FIRST - 6),
			LVN_ENDLABELEDITW = (LVN_FIRST - 76),
			LVN_ENDSCROLL = (LVN_FIRST - 81),
			LVN_GETDISPINFO = LVN_GETDISPINFOW,
			LVN_GETDISPINFOA = (LVN_FIRST - 50),
			LVN_GETDISPINFOW = (LVN_FIRST - 77),
			LVN_GETEMPTYMARKUP = (LVN_FIRST - 87),
			LVN_GETINFOTIP = LVN_GETINFOTIPW,
			LVN_GETINFOTIPA = (LVN_FIRST - 57),
			LVN_GETINFOTIPW = (LVN_FIRST - 58),
			LVN_HOTTRACK = (LVN_FIRST - 21),
			LVN_INCREMENTALSEARCH = LVN_INCREMENTALSEARCHW,
			LVN_INCREMENTALSEARCHA = (LVN_FIRST - 62),
			LVN_INCREMENTALSEARCHW = (LVN_FIRST - 63),
			LVN_INSERTITEM = (LVN_FIRST - 2),
			LVN_ITEMACTIVATE = (LVN_FIRST - 14),
			LVN_ITEMCHANGED = (LVN_FIRST - 1),
			LVN_ITEMCHANGING = (LVN_FIRST - 0),
			LVN_KEYDOWN = (LVN_FIRST - 55),
			LVN_LINKCLICK = (LVN_FIRST - 84),
			LVN_MARQUEEBEGIN = (LVN_FIRST - 56),
			LVN_ODCACHEHINT = (LVN_FIRST - 13),
			LVN_ODFINDITEM = LVN_ODFINDITEMW,
			LVN_ODFINDITEMA = (LVN_FIRST - 52),
			LVN_ODFINDITEMW = (LVN_FIRST - 79),
			LVN_ODSTATECHANGED = (LVN_FIRST - 15),
			LVN_SETDISPINFO = LVN_SETDISPINFOW,
			LVN_SETDISPINFOA = (LVN_FIRST - 51),
			LVN_SETDISPINFOW = (LVN_FIRST - 78),
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
			/// Scrolling is disabled. All items must be within the client area. This style is not compatible with the LVS_LIST or
			/// LVS_REPORT styles. See Knowledge Base Article Q137520 for further discussion.
			/// </summary>
			LVS_NOSCROLL = 0x2000,

			/// <summary>
			/// Column headers do not work like buttons. This style can be used if clicking a column header in report view does not carry
			/// out an action, such as sorting.
			/// </summary>
			LVS_NOSORTHEADER = 0x8000,

			/// <summary>
			/// Version 4.70. This style specifies a virtual list-view control. For more information about this list control style, see
			/// About List-View Controls.
			/// </summary>
			LVS_OWNERDATA = 0x1000,

			/// <summary>
			/// The owner window can paint items in report view. The list-view control sends a WM_DRAWITEM message to paint each item; it
			/// does not send separate messages for each subitem. The iItemData member of the DRAWITEMSTRUCT structure contains the item
			/// data for the specified list-view item.
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
			/// Version 4.70. Enables check boxes for items in a list-view control. When set to this style, the control creates and sets a
			/// state image list with two images using DrawFrameControl. State image 1 is the unchecked box, and state image 2 is the
			/// checked box. Setting the state image to zero removes the check box.
			/// <para>
			/// Version 6.00 and later Check boxes are visible and functional with all list view modes except the tile view mode introduced
			/// in ComCtl32.dll version 6. Clicking a checkbox in tile view mode only selects the item; the state does not change.
			/// </para>
			/// <para>
			/// You can obtain the state of the check box for a given item with ListView_GetCheckState. To set the check state, use
			/// ListView_SetCheckState. If this style is set, the list-view control automatically toggles the check state when the user
			/// clicks the check box or presses the space bar.
			/// </para>
			/// </summary>
			LVS_EX_CHECKBOXES = 0X00000004,

			/// <summary>
			/// Indicates that an overflow button should be displayed in icon/tile view if there is not enough client width to display the
			/// complete set of header items. The list-view control sends the LVN_COLUMNOVERFLOWCLICK notification when the overflow button
			/// is clicked. This flag is only valid when LVS_EX_HEADERINALLVIEWS is also specified.
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
			/// When an item is selected, the item and all its subitems are highlighted. This style is available only in conjunction with
			/// the LVS_REPORT style.
			/// </summary>
			LVS_EX_FULLROWSELECT = 0X00000020,

			/// <summary>
			/// Displays gridlines around items and subitems. This style is available only in conjunction with the LVS_REPORT style.
			/// </summary>
			LVS_EX_GRIDLINES = 0X00000001,

			/// <summary>
			/// Enables drag-and-drop reordering of columns in a list-view control. This style is only available to list-view controls that
			/// use the LVS_REPORT style.
			/// </summary>
			LVS_EX_HEADERDRAGDROP = 0X00000010,

			/// <summary>Windows Vista and later. Show column headers in all view modes.</summary>
			LVS_EX_HEADERINALLVIEWS = 0X02000000,

			/// <summary>Version 6.00 and later. Hides the labels in icon and small icon view.</summary>
			LVS_EX_HIDELABELS = 0X00020000,

			/// <summary>
			/// When a list-view control uses the LVS_EX_INFOTIP style, the LVN_GETINFOTIP notification code is sent to the parent window
			/// before displaying an item's tooltip.
			/// </summary>
			LVS_EX_INFOTIP = 0X00000400,

			/// <summary>Windows Vista and later. Icons are lined up in columns that use up the whole view.</summary>
			LVS_EX_JUSTIFYCOLUMNS = 0X00200000,

			/// <summary>
			/// If a partially hidden label in any list view mode lacks tooltip text, the list-view control will unfold the label. If this
			/// style is not set, the list-view control will unfold partly hidden labels only for the large icon mode.
			/// </summary>
			LVS_EX_LABELTIP = 0X00004000,

			/// <summary>
			/// If the list-view control has the LVS_AUTOARRANGE style, the control will not autoarrange its icons until one or more work
			/// areas are defined (see LVM_SETWORKAREAS). To be effective, this style must be set before any work areas are defined and any
			/// items have been added to the control.
			/// </summary>
			LVS_EX_MULTIWORKAREAS = 0X00002000,

			/// <summary>
			/// The list-view control sends an LVN_ITEMACTIVATE notification code to the parent window when the user clicks an item. This
			/// style also enables hot tracking in the list-view control. Hot tracking means that when the cursor moves over an item, it is
			/// highlighted but not selected. See the Extended List-View Styles Remarks section for a discussion of item activation.
			/// </summary>
			LVS_EX_ONECLICKACTIVATE = 0X00000040,

			/// <summary>
			/// Version 4.71 through Version 5.80 only. Not supported on Windows Vista and later. Sets the list view window region to
			/// include only the item icons and text using SetWindowRgn. Any area that is not part of an item is excluded from the window
			/// region. This style is only available to list-view controls that use the LVS_ICON style.
			/// </summary>
			LVS_EX_REGIONAL = 0X00000200,

			/// <summary>
			/// Version 6.00 and later. In icon view, moves the state image of the control to the top right of the large icon rendering. In
			/// views other than icon view there is no change. When the user changes the state by using the space bar, all selected items
			/// cycle over, not the item with the focus.
			/// </summary>
			LVS_EX_SIMPLESELECT = 0X00100000,

			/// <summary>Version 6.00 and later. Not used.</summary>
			LVS_EX_SINGLEROW = 0X00040000,

			/// <summary>Version 6.00 and later. In icon view, icons automatically snap into a grid.</summary>
			LVS_EX_SNAPTOGRID = 0X00080000,

			/// <summary>
			/// Allows images to be displayed for subitems. This style is available only in conjunction with the LVS_REPORT style.
			/// </summary>
			LVS_EX_SUBITEMIMAGES = 0X00000002,

			/// <summary>
			/// Enables hot-track selection in a list-view control. Hot track selection means that an item is automatically selected when
			/// the cursor remains over the item for a certain period of time. The delay can be changed from the default system setting with
			/// a LVM_SETHOVERTIME message. This style applies to all styles of list-view control. You can check whether hot-track selection
			/// is enabled by calling SystemParametersInfo.
			/// </summary>
			LVS_EX_TRACKSELECT = 0X00000008,

			/// <summary>Windows Vista and later. Background is painted by the parent via WM_PRINTCLIENT.</summary>
			LVS_EX_TRANSPARENTBKGND = 0X00400000,

			/// <summary>Windows Vista and later. Enable shadow text on transparent backgrounds only.</summary>
			LVS_EX_TRANSPARENTSHADOWTEXT = 0X00800000,

			/// <summary>
			/// The list-view control sends an LVN_ITEMACTIVATE notification code to the parent window when the user double-clicks an item.
			/// This style also enables hot tracking in the list-view control. Hot tracking means that when the cursor moves over an item,
			/// it is highlighted but not selected. See the Extended List-View Styles Remarks section for a discussion of item activation.
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

		/// <summary>
		/// <para>
		/// Gets the bounding rectangle for all or part of a subitem in the current view of a specified list-view control. Use this macro or
		/// send the LVM_GETITEMINDEXRECT message explicitly.
		/// </para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the list-view control.</para>
		/// </param>
		/// <param name="plvii">
		/// <para>Type: <c>LVITEMINDEX*</c></para>
		/// <para>
		/// A pointer to a LVITEMINDEX structure for the parent item of the subitem. The caller is responsible for allocating this structure
		/// and setting its members. plvii must not be <c>NULL</c>.
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
		/// If iSubItem is zero, this macro returns the coordinates of the rectangle to the item pointed to by plvii. The value
		/// LVIR_SELECTBOUNDS for the parameter code is not supported.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/commctrl/nf-commctrl-listview_getitemindexrect
		[PInvokeData("commctrl.h", MSDNShortId = "listview_getitemindexrect")]
		public static bool ListView_GetItemIndexRect(HWND hwnd, in LVITEMINDEX plvii, int iSubItem, ListViewItemRect code, out Rectangle prc)
		{
			var rc = new PRECT((int)code, iSubItem, 0, 0);
			var lr = SendMessage(hwnd, ListViewMessage.LVM_GETITEMINDEXRECT, plvii, rc);
			prc = lr == IntPtr.Zero ? Rectangle.Empty : (Rectangle)rc;
			return lr != IntPtr.Zero;
		}

		/// <summary>
		/// Gets the index of the item in a particular list-view control that has the specified properties and relationship to another
		/// specific item. Use this macro or send the <c>LVM_GETNEXTITEMINDEX</c> message explicitly.
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>A handle to the list-view control.</para>
		/// </param>
		/// <param name="plvii">
		/// <para>Type: <c><c>LVITEMINDEX</c>*</c></para>
		/// <para>
		/// A pointer to the <c>LVITEMINDEX</c> structure with which the item begins the search, or -1 to find the first item that matches
		/// the specified flags. The calling process is responsible for allocating this structure and setting its members.
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
		/// <para>
		/// The valid bits of the state specified by parameter data. For more information, see the stateMask member of the LVITEM) structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>None</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/commctrl/nf-commctrl-listview_setitemindexstate void
		// ListView_SetItemIndexState( hwndLV, plvii, data, mask );
		[PInvokeData("commctrl.h", MSDNShortId = "listview_setitemindexstate")]
		public static HRESULT ListView_SetItemIndexState(HWND hwndLV, in LVITEMINDEX plvii, uint data, ListViewItemState mask) =>
			new HRESULT(SendMessage(hwndLV, (uint)ListViewMessage.LVM_SETITEMINDEXSTATE, in plvii, new LVITEM(0) { stateMask = mask, state = data }).ToInt32());

		/// <summary>
		/// Contains information used when searching for a list-view item. This structure is identical to LV_FINDINFO but has been renamed
		/// to fit standard naming conventions.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb774745")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LVFINDINFO
		{
			/// <summary>Type of search to perform.</summary>
			public ListViewFindInfoFlag flags;

			/// <summary>
			/// Address of a null-terminated string to compare with the item text. It is valid only if LVFI_STRING or LVFI_PARTIAL is set in
			/// the flags member.
			/// </summary>
			public string psz;

			/// <summary>
			/// Value to compare with the lParam member of a list-view item's LVITEM structure. It is valid only if LVFI_PARAM is set in the
			/// flags member.
			/// </summary>
			public IntPtr lParam;

			/// <summary>POINT structure with the initial search position. It is valid only if LVFI_NEARESTXY is set in the flags member.</summary>
			public Point pt;

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
			public LVFINDINFO(Point point, ConsoleKey searchDirection) : this()
			{
				flags = ListViewFindInfoFlag.LVFI_NEARESTXY;
				pt = point;
				vkDirection = searchDirection;
			}
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
				cbSize = (uint)Marshal.SizeOf(typeof(LVGROUPMETRICS));
				this.mask = mask;
			}

			/// <summary>Initializes a new instance of the <see cref="LVGROUPMETRICS"/> class.</summary>
			/// <param name="left">The width of the left border.</param>
			/// <param name="top">The width of the top border.</param>
			/// <param name="right">The width of the right border.</param>
			/// <param name="bottom">The width of the bottom border.</param>
			public LVGROUPMETRICS(int left, int top, int right, int bottom) : this()
			{
				cbSize = (uint)Marshal.SizeOf(typeof(LVGROUPMETRICS));
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
		/// Contains information about a hit test. This structure has been extended to accommodate subitem hit-testing. It is used in
		/// association with the LVM_HITTEST and LVM_SUBITEMHITTEST messages and their related macros. This structure supersedes the
		/// LVHITTESTINFO structure.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb774754")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LVHITTESTINFO
		{
			/// <summary>The position to hit test, in client coordinates.</summary>
			public Point pt;

			/// <summary>
			/// The variable that receives information about the results of a hit test. This member can be one or more of the following values:
			/// <para>
			/// You can use LVHT_ABOVE, LVHT_BELOW, LVHT_TOLEFT, and LVHT_TORIGHT to determine whether to scroll the contents of a list-view
			/// control.Two of these values may be combined. For example, if the position is above and to the left of the client area, you
			/// could use both LVHT_ABOVE and LVHT_TOLEFT.
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
			public LVHITTESTINFO(Point pt) : this() => this.pt = pt;
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
				cbSize = (uint)Marshal.SizeOf(typeof(LVINSERTMARK));
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
				cbSize = (uint)Marshal.SizeOf(typeof(LVTILEVIEWINFO));
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
			public Size TileSize
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

		/// <summary>
		/// Contains information about a list-view notification message. This structure is the same as the NM_LISTVIEW structure but has
		/// been renamed to fit standard naming conventions.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb774773")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMLISTVIEW
		{
			/// <summary>NMHDR structure that contains information about this notification message</summary>
			public NMHDR hdr;

			/// <summary>Identifies the list-view item, or -1 if not used.</summary>
			public int iItem;

			/// <summary>Identifies the subitem, or zero if none.</summary>
			public int iSubItem;

			/// <summary>
			/// New item state. This member is zero for notification messages that do not use it. For a list of possible values, see
			/// List-View Item States.
			/// </summary>
			public ListViewItemState uNewState;

			/// <summary>
			/// Old item state. This member is zero for notification messages that do not use it. For a list of possible values, see
			/// List-View Item States.
			/// </summary>
			public ListViewItemState uOldState;

			/// <summary>
			/// Set of flags that indicate the item attributes that have changed. This member is zero for notifications that do not use it.
			/// Otherwise, it can have the same values as the mask member of the LVITEM structure.
			/// </summary>
			public ListViewItemMask uChanged;

			/// <summary>
			/// POINT structure that indicates the location at which the event occurred. This member is undefined for notification messages
			/// that do not use it.
			/// </summary>
			public Point ptAction;

			/// <summary>Application-defined value of the item. This member is undefined for notification messages that do not use it.</summary>
			public IntPtr lParam;
		}

		/// <summary>
		/// Contains information about the background image of a list-view control. This structure is used for both setting and retrieving
		/// background image information.
		/// </summary>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb774742")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public sealed class LVBKIMAGE : IDisposable
		{
			/// <summary>
			/// This member may be one or more of the following flags. You can use the LVBKIF_SOURCE_MASK value to mask off all but the
			/// source flags. You can use the LVBKIF_STYLE_MASK value to mask off all but the style flags.
			/// </summary>
			public ListViewBkImageFlag ulFlags;

			/// <summary>The handle of the background bitmap. This member is valid only if the LVBKIF_SOURCE_HBITMAP flag is set in ulFlags.</summary>
			public HBITMAP hBmp = IntPtr.Zero;

			/// <summary>
			/// Address of a NULL-terminated string that contains the URL of the background image. This member is valid only if the
			/// LVBKIF_SOURCE_URL flag is set in ulFlags. This member must be initialized to point to the buffer that contains or receives
			/// the text before sending the message.
			/// </summary>
			public StrPtrAuto pszImage;

			/// <summary>Size of the buffer at the address in pszImage. If information is being sent to the control, this member is ignored.</summary>
			public uint cchImageMax;

			/// <summary>
			/// Percentage of the control's client area that the image should be offset horizontally. For example, at 0 percent, the image
			/// will be displayed against the left edge of the control's client area. At 50 percent, the image will be displayed
			/// horizontally centered in the control's client area. At 100 percent, the image will be displayed against the right edge of
			/// the control's client area. This member is valid only when LVBKIF_STYLE_NORMAL is specified in ulFlags. If both
			/// LVBKIF_FLAG_TILEOFFSET and LVBKIF_STYLE_TILE are specified in ulFlags, then the value specifies the pixel, not percentage
			/// offset, of the first tile. Otherwise, the value is ignored.
			/// </summary>
			public int xOffset;

			/// <summary>
			/// Percentage of the control's client area that the image should be offset vertically. For example, at 0 percent, the image
			/// will be displayed against the top edge of the control's client area. At 50 percent, the image will be displayed vertically
			/// centered in the control's client area. At 100 percent, the image will be displayed against the bottom edge of the control's
			/// client area. This member is valid only when LVBKIF_STYLE_NORMAL is specified in ulFlags. If both LVBKIF_FLAG_TILEOFFSET and
			/// LVBKIF_STYLE_TILE are specified in ulFlags, then the value specifies the pixel, not percentage offset, of the first tile.
			/// Otherwise, the value is ignored.
			/// </summary>
			public int yOffset;

			/// <summary>Initializes a new instance of the <see cref="LVBKIMAGE"/> class.</summary>
			/// <param name="bmp">The BMP.</param>
			/// <param name="isWatermark">if set to <c>true</c> [is watermark].</param>
			/// <param name="isWatermarkAlphaBlended">if set to <c>true</c> [is watermark alpha blended].</param>
			public LVBKIMAGE(Bitmap bmp, bool isWatermark, bool isWatermarkAlphaBlended)
			{
				Bitmap = bmp;
				ulFlags = isWatermark ? ListViewBkImageFlag.LVBKIF_TYPE_WATERMARK : ListViewBkImageFlag.LVBKIF_SOURCE_HBITMAP;
				if (isWatermark && isWatermarkAlphaBlended)
					ulFlags |= ListViewBkImageFlag.LVBKIF_FLAG_ALPHABLEND;
			}

			/// <summary>Initializes a new instance of the <see cref="LVBKIMAGE"/> class.</summary>
			/// <param name="bmp">The BMP.</param>
			/// <param name="isTiled">if set to <c>true</c> [is tiled].</param>
			public LVBKIMAGE(Bitmap bmp, bool isTiled)
			{
				Bitmap = bmp;
				ulFlags = ListViewBkImageFlag.LVBKIF_SOURCE_HBITMAP;
				if (isTiled)
					ulFlags |= ListViewBkImageFlag.LVBKIF_STYLE_TILE;
			}

			/// <summary>Initializes a new instance of the <see cref="LVBKIMAGE"/> class.</summary>
			/// <param name="url">The URL.</param>
			/// <param name="isTiled">if set to <c>true</c> [is tiled].</param>
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

			/// <summary>Gets or sets the bitmap.</summary>
			/// <value>The bitmap.</value>
			public Bitmap Bitmap
			{
				get => hBmp.IsNull ? null : System.Drawing.Image.FromHbitmap((IntPtr)hBmp);
				set => hBmp = value?.GetHbitmap() ?? IntPtr.Zero;
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
		/// Contains information about a column in report view. This structure is used both for creating and manipulating columns. This
		/// structure supersedes the LV_COLUMN structure.
		/// </summary>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb774743")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public sealed class LVCOLUMN : IDisposable
		{
			/// <summary>
			/// Variable specifying which members contain valid information. This member can be zero, or one or more of the following values:
			/// </summary>
			public ListViewColumMask mask;

			/// <summary>
			/// Alignment of the column header and the subitem text in the column. The alignment of the leftmost column is always
			/// LVCFMT_LEFT; it cannot be changed. This member can be a combination of the following values. Note that not all combinations
			/// are valid.
			/// </summary>
			public ListViewColumnFormat fmt;

			/// <summary>Width of the column, in pixels.</summary>
			public int cx;

			/// <summary>
			/// If column information is being set, this member is the address of a null-terminated string that contains the column header
			/// text. If the structure is receiving information about a column, this member specifies the address of the buffer that
			/// receives the column header text.
			/// </summary>
			public StrPtrAuto pszText;

			/// <summary>
			/// Size in TCHARs of the buffer pointed to by the pszText member. If the structure is not receiving information about a column,
			/// this member is ignored.
			/// </summary>
			public uint cchTextMax;

			/// <summary>Index of subitem associated with the column.</summary>
			public int iSubItem;

			/// <summary>
			/// Version 4.70. Zero-based index of an image within the image list. The specified image will appear within the column.
			/// </summary>
			public int iImage;

			/// <summary>
			/// Version 4.70. Zero-based column offset. Column offset is in left-to-right order. For example, zero indicates the leftmost column.
			/// </summary>
			public int iOrder;

			/// <summary>Windows Vista. Minimum width of the column in pixels.</summary>
			public int cxMin;

			/// <summary>
			/// Windows Vista. Application-defined value typically used to store the default width of the column. This member is ignored by
			/// the list-view control.
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
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb774769")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public sealed class LVGROUP : IDisposable
		{
			/// <summary>Size of this structure, in bytes.</summary>
			public int cbSize = Marshal.SizeOf(typeof(LVGROUP));

			/// <summary>Mask that specifies which members of the structure are valid input.</summary>
			public ListViewGroupMask mask;

			/// <summary>
			/// Pointer to a null-terminated string that contains the header text when item information is being set. If group information
			/// is being retrieved, this member specifies the address of the buffer that receives the header text.
			/// </summary>
			public StrPtrAuto pszHeader;

			/// <summary>
			/// Size in TCHARs of the buffer pointed to by the pszHeader member. If the structure is not receiving information about a
			/// group, this member is ignored.
			/// </summary>
			public uint cchHeader;

			/// <summary>
			/// Pointer to a null-terminated string that contains the footer text when item information is being set. If group information
			/// is being retrieved, this member specifies the address of the buffer that receives the footer text.
			/// </summary>
			public StrPtrAuto pszFooter;

			/// <summary>
			/// Size in TCHARs of the buffer pointed to by the pszFooter member. If the structure is not receiving information about a
			/// group, this member is ignored.
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
			/// Indicates the alignment of the header or footer text for the group. It can have one or more of the following values. Use one
			/// of the header flags. Footer flags are optional.
			/// </summary>
			public ListViewGroupAlignment uAlign;

			/// <summary>
			/// Pointer to a null-terminated string that contains the subtitle text when item information is being set. If group information
			/// is being retrieved, this member specifies the address of the buffer that receives the subtitle text. This element is drawn
			/// under the header text.
			/// </summary>
			public StrPtrAuto pszSubtitle;

			/// <summary>
			/// Size, in TCHARs, of the buffer pointed to by the pszSubtitle member. If the structure is not receiving information about a
			/// group, this member is ignored.
			/// </summary>
			public uint cchSubtitle;

			/// <summary>
			/// Pointer to a null-terminated string that contains the text for a task link when item information is being set. If group
			/// information is being retrieved, this member specifies the address of the buffer that receives the task text. This item is
			/// drawn right-aligned opposite the header text. When clicked by the user, the task link generates an LVN_LINKCLICK notification.
			/// </summary>
			public StrPtrAuto pszTask;

			/// <summary>
			/// Size in TCHARs of the buffer pointed to by the pszTask member. If the structure is not receiving information about a group,
			/// this member is ignored.
			/// </summary>
			public uint cchTask;

			/// <summary>
			/// Pointer to a null-terminated string that contains the top description text when item information is being set. If group
			/// information is being retrieved, this member specifies the address of the buffer that receives the top description text. This
			/// item is drawn opposite the title image when there is a title image, no extended image, and uAlign==LVGA_HEADER_CENTER.
			/// </summary>
			public StrPtrAuto pszDescriptionTop;

			/// <summary>
			/// Size in TCHARs of the buffer pointed to by the pszDescriptionTop member. If the structure is not receiving information about
			/// a group, this member is ignored.
			/// </summary>
			public uint cchDescriptionTop;

			/// <summary>
			/// Pointer to a null-terminated string that contains the bottom description text when item information is being set. If group
			/// information is being retrieved, this member specifies the address of the buffer that receives the bottom description text.
			/// This item is drawn under the top description text when there is a title image, no extended image, and uAlign==LVGA_HEADER_CENTER.
			/// </summary>
			public StrPtrAuto pszDescriptionBottom;

			/// <summary>
			/// Size in TCHARs of the buffer pointed to by the pszDescriptionBottom member. If the structure is not receiving information
			/// about a group, this member is ignored.
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
			/// NULL if group is not a subset. Pointer to a null-terminated string that contains the subset title text when item information
			/// is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the
			/// subset title text.
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
			public LVGROUP(ListViewGroupMask mask = ListViewGroupMask.LVGF_NONE, string header = null)
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
			public string DescriptionBottom
			{
				get => pszDescriptionBottom.ToString();
				set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_DESCRIPTIONBOTTOM, pszDescriptionBottom.Assign(value, out cchDescriptionBottom));
			}

			/// <summary>Gets or sets the top description text.</summary>
			/// <value>The top description text.</value>
			public string DescriptionTop
			{
				get => pszDescriptionTop.ToString();
				set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_DESCRIPTIONTOP, pszDescriptionTop.Assign(value, out cchDescriptionTop));
			}

			/// <summary>Gets or sets the footer.</summary>
			/// <value>The footer.</value>
			public string Footer
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
			public string Header
			{
				get => pszHeader.ToString();
				set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_HEADER, pszHeader.Assign(value, out cchHeader));
			}

			/// <summary>Gets or sets the subtitle.</summary>
			/// <value>The subtitle.</value>
			public string Subtitle
			{
				get => pszSubtitle.ToString();
				set => EnumExtensions.SetFlags(ref mask, ListViewGroupMask.LVGF_SUBTITLE, pszSubtitle.Assign(value, out cchSubtitle));
			}

			/// <summary>Gets or sets the task link text.</summary>
			/// <value>The task link text.</value>
			public string TaskLink
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
		/// Specifies or receives the attributes of a list-view item. This structure has been updated to support a new mask value
		/// (LVIF_INDENT) that enables item indenting. This structure supersedes the LV_ITEM structure.
		/// </summary>
		/// <seealso cref="System.IDisposable"/>
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
			/// Bits 8 through 11 of this member specify the one-based overlay image index. Both the full-sized icon image list and the
			/// small icon image list can have overlay images. The overlay image is superimposed over the item's icon image. If these bits
			/// are zero, the item has no overlay image. To isolate these bits, use the LVIS_OVERLAYMASK mask. To set the overlay image
			/// index in this member, you should use the INDEXTOOVERLAYMASK macro. The image list's overlay images are set with the
			/// ImageList_SetOverlayImage function.
			/// </para>
			/// <para>
			/// Bits 12 through 15 of this member specify the state image index. The state image is displayed next to an item's icon to
			/// indicate an application-defined state. If these bits are zero, the item has no state image. To isolate these bits, use the
			/// LVIS_STATEIMAGEMASK mask. To set the state image index, use the INDEXTOSTATEIMAGEMASK macro. The state image index specifies
			/// the index of the image in the state image list that should be drawn. The state image list is specified with the
			/// LVM_SETIMAGELIST message.
			/// </para>
			/// </summary>
			public uint state;

			/// <summary>
			/// Value specifying which bits of the state member will be retrieved or modified. For example, setting this member to
			/// LVIS_SELECTED will cause only the item's selection state to be retrieved.
			/// <para>
			/// This member allows you to modify one or more item states without having to retrieve all of the item states first.For
			/// example, setting this member to LVIS_SELECTED and state to zero will cause the item's selection state to be cleared, but
			/// none of the other states will be affected.
			/// </para>
			/// <para>To retrieve or modify all of the states, set this member to(UINT)-1.</para>
			/// <para>You can use the macro ListView_SetItemState both to set and to clear bits.</para>
			/// </summary>
			public ListViewItemState stateMask;

			/// <summary>
			/// If the structure specifies item attributes, pszText is a pointer to a null-terminated string containing the item text. When
			/// responding to an LVN_GETDISPINFO notification, be sure that this pointer remains valid until after the next notification has
			/// been received.
			/// <para>
			/// If the structure receives item attributes, pszText is a pointer to a buffer that receives the item text. Note that although
			/// the list-view control allows any length string to be stored as item text, only the first 260 TCHARs are displayed.
			/// </para>
			/// <para>
			/// If the value of pszText is LPSTR_TEXTCALLBACK, the item is a callback item.If the callback text changes, you must explicitly
			/// set pszText to LPSTR_TEXTCALLBACK and notify the list-view control of the change by sending an LVM_SETITEM or
			/// LVM_SETITEMTEXT message.
			/// </para>
			/// <para>
			/// Do not set pszText to LPSTR_TEXTCALLBACK if the list-view control has the LVS_SORTASCENDING or LVS_SORTDESCENDING style.
			/// </para>
			/// </summary>
			public StrPtrAuto pszText;

			/// <summary>
			/// Number of TCHARs in the buffer pointed to by pszText, including the terminating NULL.
			/// <para>
			/// This member is only used when the structure receives item attributes.It is ignored when the structure specifies item
			/// attributes.For example, cchTextMax is ignored during LVM_SETITEM and LVM_INSERTITEM.It is read-only during LVN_GETDISPINFO
			/// and other LVN_ notifications.
			/// </para>
			/// <note>Never copy more than cchTextMax TCHARs—where cchTextMax includes the terminating NULL—into pszText during an LVN_
			/// notification, otherwise your program can fail.</note>
			/// </summary>
			public uint cchTextMax;

			/// <summary>
			/// Index of the item's icon in the control's image list. This applies to both the large and small image list. If this member is
			/// the I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the list-view control sends
			/// the parent an LVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.
			/// </summary>
			public int iImage;

			/// <summary>
			/// Value specific to the item. If you use the LVM_SORTITEMS message, the list-view control passes this value to the
			/// application-defined comparison function. You can also use the LVM_FINDITEM message to search a list-view control for an item
			/// with a specified lParam value.
			/// </summary>
			public IntPtr lParam;

			/// <summary>
			/// Version 4.70. Number of image widths to indent the item. A single indentation equals the width of an item image. Therefore,
			/// the value 1 indents the item by the width of one image, the value 2 indents by two images, and so on. Note that this field
			/// is supported only for items. Attempting to set subitem indentation will cause the calling function to fail.
			/// </summary>
			public int iIndent;

			/// <summary>
			/// Version 6.0 Identifier of the group that the item belongs to, or one of the following values: I_GROUPIDCALLBACK = The
			/// listview control sends the parent an LVN_GETDISPINFO notification code to retrieve the index of the group; I_GROUPIDNONE =
			/// The item does not belong to a group.
			/// </summary>
			public int iGroupId;

			/// <summary>
			/// Version 6.0 Number of data columns (subitems) to display for this item in tile view. The maximum value is 20. If this value
			/// is I_COLUMNSCALLBACK, the size of the column array and the array itself (puColumns) are obtained by sending a
			/// LVN_GETDISPINFO notification.
			/// </summary>
			public uint cColumns;

			/// <summary>
			/// Version 6.0 A pointer to an array of column indices, specifying which columns are displayed for this item, and the order of
			/// those columns.
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
					puColumns = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * MAX_COLS);
				if (mask.IsFlagSet(ListViewItemMask.LVIF_COLFMT))
					piColFmt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * MAX_COLS);
				iItem = item;
				iSubItem = subitem;
				this.stateMask = stateMask;
			}

			/// <summary>Initializes a new instance of the <see cref="LVITEM"/> class.</summary>
			/// <param name="item">Zero-based index of the item.</param>
			/// <param name="subitem">One-based index of the subitem or zero if this structure refers to an item rather than a subitem.</param>
			/// <param name="text">The item text.</param>
			public LVITEM(int item, int subitem = 0, string text = null)
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
					var ret = new LVITEMCOLUMNINFO[cColumns];
					if (cColumns == 0) return ret;
					var cols = puColumns.ToArray<int>((int)cColumns);
					var fmts = piColFmt.ToArray<int>((int)cColumns);
					for (var i = 0; i < cColumns; i++)
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

					var cols = new int[cColumns];
					var fmts = new int[cColumns];
					var hasFmts = false;
					for (var i = 0; i < cColumns; i++)
					{
						cols[i] = (int)value[i].columnIndex;
						fmts[i] = (int)value[i].format;
						if (fmts[i] != 0) hasFmts = true;
					}
					if (cColumns > 0)
					{
						puColumns = cols.MarshalToPtr<int>(Marshal.AllocHGlobal, out _);
					}
					EnumExtensions.SetFlags(ref mask, ListViewItemMask.LVIF_COLUMNS);
					if (hasFmts)
					{
						piColFmt = fmts.MarshalToPtr<int>(Marshal.AllocHGlobal, out _);
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
	}
}