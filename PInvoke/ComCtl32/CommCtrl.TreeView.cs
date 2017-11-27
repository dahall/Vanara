using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using HTREEITEM = System.IntPtr;
using static Vanara.PInvoke.User32;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		private const int TV_FIRST = 0x1100;
		private const int TVN_FIRST = -400;

		public const int I_CHILDRENAUTO = -2;
		public const int I_CHILDRENCALLBACK = -1;

		/// <summary>TreeView's custom draw return meaning don't draw images.  valid on CDRF_NOTIFYITEMPREPAINT</summary>
		public const int TVCDRF_NOIMAGES = 0x00010000;

		/// <summary>
		/// An application-defined callback function, which is called during a sort operation each time the relative order of two list items needs to be compared.
		/// </summary>
		/// <param name="lParam1">Corresponds to the lParam member of the first TVITEM structure for the two items being compared.</param>
		/// <param name="lParam2">Corresponds to the lParam member of the second TVITEM structure for the two items being compared.</param>
		/// <param name="lParamSort">Corresponds to the lParam member of this structure.</param>
		/// <returns>
		/// The callback function must return a negative value if the first item should precede the second, a positive value if the first item should follow the
		/// second, or zero if the two items are equivalent.
		/// </returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773462")]
		public delegate int PFNTVCOMPARE(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);

		/// <summary>Action that the sender (the tree-view control) should execute on return.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773413")]
		public enum AsyncDrawRetFlags
		{
			/// <summary>Proceed to draw the image anyway, that is, synchronously extract the image and paint. Assuming the control is on the UI thread, use of this flag implies low priority UI performance, since extraction times may vary and the UI could be unresponsive for an extended period of time during extraction.</summary>
			ADRF_DRAWSYNC = 0,
			/// <summary>Do not draw an image.</summary>
			ADRF_DRAWNOTHING = 1,
			/// <summary>Draw fallback text.</summary>
			ADRF_DRAWFALLBACK = 2,
			/// <summary>Draw the image specified by iRetImageIndex.</summary>
			ADRF_DRAWIMAGE = 3,
		}

		/// <summary>Specifies the item to retrieve using TVM_GETNEXTITEM or the action for TVM_SELECTITEM.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760143")]
		public enum TreeViewActionFlag
		{
			/// <summaryRetrieves the currently selected item. You can use the TreeView_GetSelection macro to send this message.</summary>
			TVGN_CARET = 0x0009,
			/// <summaryRetrieves the first child item of the item specified by the hitem parameter. You can use the TreeView_GetChild macro to send this message.</summary>
			TVGN_CHILD = 0x0004,
			/// <summary>Retrieves the item that is the target of a drag-and-drop operation. You can use the TreeView_GetDropHilight macro to send this message.</summary>
			TVGN_DROPHILITE = 0x0008,
			/// <summary>Retrieves the first item that is visible in the tree-view window. You can use the TreeView_GetFirstVisible macro to send this message.</summary>
			TVGN_FIRSTVISIBLE = 0x0005,
			/// <summary>Version 4.71. Retrieves the last expanded item in the tree. This does not retrieve the last item visible in the tree-view window. You can use the TreeView_GetLastVisible macro to send this message.</summary>
			TVGN_LASTVISIBLE = 0x000A,
			/// <summary>Retrieves the next sibling item. You can use the TreeView_GetNextSibling macro to send this message.</summary>
			TVGN_NEXT = 0x0001,
			/// <summary>Windows Vista and later. Retrieves the next selected item. You can use the TreeView_GetNextSelected macro to send this message.</summary>
			TVGN_NEXTSELECTED = 0x000B,
			/// <summary>Retrieves the next visible item that follows the specified item. The specified item must be visible. Use the TVM_GETITEMRECT message to determine whether an item is visible. You can use the TreeView_GetNextVisible macro to send this message.</summary>
			TVGN_NEXTVISIBLE = 0x0006,
			/// <summary>Retrieves the parent of the specified item. You can use the TreeView_GetParent macro to send this message.</summary>
			TVGN_PARENT = 0x0003,
			/// <summary>Retrieves the previous sibling item. You can use the TreeView_GetPrevSibling macro to send this message.</summary>
			TVGN_PREVIOUS = 0x0002,
			/// <summary>Retrieves the first visible item that precedes the specified item. The specified item must be visible. Use the TVM_GETITEMRECT message to determine whether an item is visible. You can use the TreeView_GetPrevVisible macro to send this message.</summary>
			TVGN_PREVIOUSVISIBLE = 0x0007,
			/// <summary>Retrieves the topmost or very first item of the tree-view control. You can use the TreeView_GetRoot macro to send this message.</summary>
			TVGN_ROOT = 0x0000,
			/// <summary>When a single item is selected, ensures that the treeview does not expand the children of that item. This is valid only if used with the TVGN_CARET flag.</summary>
			TVSI_NOSINGLEEXPAND = 0x8000
		}

		/// <summary>Action to take when using TVM_EXPAND.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773568")]
		[Flags]
		public enum TreeViewExpandFlags
		{
			/// <summary>Collapses the list.</summary>
			TVE_COLLAPSE = 0x0001,
			/// <summary>Expands the list.</summary>
			TVE_EXPAND = 0x0002,
			/// <summary>Collapses the list if it is expanded or expands it if it is collapsed.</summary>
			TVE_TOGGLE = 0x0003,
			/// <summary>Version 4.70. Partially expands the list. In this state the child items are visible and the parent item's plus sign (+), indicating that it can be expanded, is displayed. This flag must be used in combination with the TVE_EXPAND flag.</summary>
			TVE_EXPANDPARTIAL = 0x4000,
			/// <summary>Collapses the list and removes the child items. The TVIS_EXPANDEDONCE state flag is reset. This flag must be used with the TVE_COLLAPSE flag.</summary>
			TVE_COLLAPSERESET = 0x8000,
		}

		/// <summary>Information about the results of a hit test.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773448")]
		[Flags]
		public enum TreeViewHitTestFlags
		{
			/// <summary>In the client area, but below the last item.</summary>
			TVHT_NOWHERE = 0x0001,
			/// <summary>On the bitmap associated with an item.</summary>
			TVHT_ONITEMICON = 0x0002,
			/// <summary>On the label (string) associated with an item.</summary>
			TVHT_ONITEMLABEL = 0x0004,
			/// <summary>On the bitmap or label associated with an item.</summary>
			TVHT_ONITEM = TVHT_ONITEMICON | TVHT_ONITEMLABEL | TVHT_ONITEMSTATEICON,
			/// <summary>In the indentation associated with an item.</summary>
			TVHT_ONITEMINDENT = 0x0008,
			/// <summary>On the button associated with an item.</summary>
			TVHT_ONITEMBUTTON = 0x0010,
			/// <summary>In the area to the right of an item.</summary>
			TVHT_ONITEMRIGHT = 0x0020,
			/// <summary>On the state icon for a tree-view item that is in a user-defined state.</summary>
			TVHT_ONITEMSTATEICON = 0x0040,
			/// <summary>Above the client area.</summary>
			TVHT_ABOVE = 0x0100,
			/// <summary>Below the client area.</summary>
			TVHT_BELOW = 0x0200,
			/// <summary>To the right of the client area.</summary>
			TVHT_TORIGHT = 0x0400,
			/// <summary>To the left of the client area.</summary>
			TVHT_TOLEFT = 0x0800,
		}

		/// <summary>Values used as alternatives to tree item handle (HTREEITEM) in TVINSERTSTRUCT.hInsertAfter.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773448")]
		public enum TreeViewInsert
		{
			/// <summary>Inserts the item at the beginning of the list.</summary>
			TVI_FIRST = -0x0FFFF,
			/// <summary>Inserts the item at the end of the list.</summary>
			TVI_LAST = -0x0FFFE,
			/// <summary>Add the item as a root item.</summary>
			TVI_ROOT = -0x10000,
			/// <summary>Inserts the item into the list in alphabetical order.</summary>
			TVI_SORT = -0x0FFFD
		}

		/// <summary>Used in <see cref="TVITEM"/> and <see cref="TVITMEEX"/> mask members to indicate which structure members contain valid data.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773459")]
		[Flags]
		public enum TreeViewItemMask
		{
			/// <summary>The cChildren member is valid.</summary>
			TVIF_CHILDREN = 0x0040,
			/// <summary>The tree-view control will retain the supplied information and will not request it again. This flag is valid only when processing the TVN_GETDISPINFO notification.</summary>
			TVIF_DI_SETITEM = 0x1000,
			/// <summary>Version 6.00 and Windows Vista. The iExpandedImage member is valid.</summary>
			TVIF_EXPANDEDIMAGE = 0x0200,
			/// <summary>The hItem member is valid.</summary>
			TVIF_HANDLE = 0x0010,
			/// <summary>The iImage member is valid.</summary>
			TVIF_IMAGE = 0x0002,
			/// <summary>The iIntegral member is valid.</summary>
			TVIF_INTEGRAL = 0x0080,
			/// <summary>The lParam member is valid.</summary>
			TVIF_PARAM = 0x0004,
			/// <summary>The iSelectedImage member is valid.</summary>
			TVIF_SELECTEDIMAGE = 0x0020,
			/// <summary>The state and stateMask members are valid.</summary>
			TVIF_STATE = 0x0008,
			/// <summary>Version 6.00 and Windows Vista. The uStateEx member is valid.</summary>
			TVIF_STATEEX = 0x0100,
			/// <summary>The pszText and cchTextMax members are valid.</summary>
			TVIF_TEXT = 0x0001,
		}

		/// <summary>
		/// Set of bit flags and image list indexes that indicate the item's state. When setting the state of an item, the stateMask member indicates the valid bits of this member. When retrieving the state of an item, this member returns the current state for the bits indicated in the stateMask member.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773459")]
		[Flags]
		public enum TreeViewItemStates
		{
			/// <summary>The item is selected. Its appearance depends on whether it has the focus. The item will be drawn using the system colors for selection.</summary>
			TVIS_SELECTED = 0x0002,
			/// <summary>The item is selected as part of a cut-and-paste operation.</summary>
			TVIS_CUT = 0x0004,
			/// <summary>The item is selected as a drag-and-drop target.</summary>
			TVIS_DROPHILITED = 0x0008,
			/// <summary>The item is bold.</summary>
			TVIS_BOLD = 0x0010,
			/// <summary>The item's list of child items is currently expanded; that is, the child items are visible. This value applies only to parent items.</summary>
			TVIS_EXPANDED = 0x0020,
			/// <summary>The item's list of child items has been expanded at least once. The TVN_ITEMEXPANDING and TVN_ITEMEXPANDED notification codes are not generated for parent items that have this state set in response to a TVM_EXPAND message. Using TVE_COLLAPSE and TVE_COLLAPSERESET with TVM_EXPAND will cause this state to be reset. This value applies only to parent items.</summary>
			TVIS_EXPANDEDONCE = 0x0040,
			/// <summary>Version 4.70. A partially expanded tree-view item. In this state, some, but not all, of the child items are visible and the parent item's plus symbol is displayed.</summary>
			TVIS_EXPANDPARTIAL = 0x0080,
			/// <summary>Mask for the bits used to specify the item's overlay image index.</summary>
			TVIS_OVERLAYMASK = 0x0F00,
			/// <summary>Mask for the bits used to specify the item's state image index.</summary>
			TVIS_STATEIMAGEMASK = 0xF000,
			/// <summary>Same as TVIS_STATEIMAGEMASK.</summary>
			TVIS_USERMASK = 0xF000,
			/// <summary>Version 6.00 and Windows Vista. The iExpandedImage member is valid.</summary>
			TVIF_EXPANDEDIMAGE = 0x0200,
			/// <summary>Version 6.00 and Windows Vista. The uStateEx member is valid.</summary>
			TVIF_STATEEX = 0x0100
		}

		/// <summary>Tree view item extended states.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773459")]
		[Flags]
		public enum TreeViewItemStatesEx
		{
			/// <summary>Creates a flat item—the item is virtual and is not visible in the tree; instead, its children take its place in the tree hierarchy. This state is valid only when adding an item to the tree-view control.</summary>
			TVIS_EX_FLAT = 0x0001,
			/// <summary>Windows Vista and later. Creates a control that is drawn in gray, that the user cannot interact with.</summary>
			TVIS_EX_DISABLED = 0x0002,
			/// <summary>Creates a separate HWND for the item. This state is valid only when adding an item to the tree-view control.</summary>
			TVIS_EX_HWND = 0x0004,
		}

		[PInvokeData("Commctrl.h", MSDNShortId = "ff486106")]
		public enum TreeViewMessage
		{
			TVM_DELETEITEM = TV_FIRST + 1,
			TVM_EXPAND = TV_FIRST + 2,
			TVM_GETITEMRECT = TV_FIRST + 4,
			TVM_GETCOUNT = TV_FIRST + 5,
			TVM_GETINDENT = TV_FIRST + 6,
			TVM_SETINDENT = TV_FIRST + 7,
			TVM_GETIMAGELIST = TV_FIRST + 8,
			TVM_SETIMAGELIST = TV_FIRST + 9,
			TVM_GETNEXTITEM = TV_FIRST + 10,
			TVM_SELECTITEM = TV_FIRST + 11,
			TVM_GETEDITCONTROL = TV_FIRST + 15,
			TVM_GETVISIBLECOUNT = TV_FIRST + 16,
			TVM_HITTEST = TV_FIRST + 17,
			TVM_CREATEDRAGIMAGE = TV_FIRST + 18,
			TVM_SORTCHILDREN = TV_FIRST + 19,
			TVM_ENSUREVISIBLE = TV_FIRST + 20,
			TVM_SORTCHILDRENCB = TV_FIRST + 21,
			TVM_ENDEDITLABELNOW = TV_FIRST + 22,
			TVM_SETTOOLTIPS = TV_FIRST + 24,
			TVM_GETTOOLTIPS = TV_FIRST + 25,
			TVM_SETINSERTMARK = TV_FIRST + 26,
			TVM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,
			TVM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT,
			TVM_SETITEMHEIGHT = TV_FIRST + 27,
			TVM_GETITEMHEIGHT = TV_FIRST + 28,
			TVM_SETBKCOLOR = TV_FIRST + 29,
			TVM_SETTEXTCOLOR = TV_FIRST + 30,
			TVM_GETBKCOLOR = TV_FIRST + 31,
			TVM_GETTEXTCOLOR = TV_FIRST + 32,
			TVM_SETSCROLLTIME = TV_FIRST + 33,
			TVM_GETSCROLLTIME = TV_FIRST + 34,
			TVM_SETINSERTMARKCOLOR = TV_FIRST + 37,
			TVM_GETINSERTMARKCOLOR = TV_FIRST + 38,
			TVM_SETBORDER = TV_FIRST + 35,
			TVM_GETITEMSTATE = TV_FIRST + 39,
			TVM_SETLINECOLOR = TV_FIRST + 40,
			TVM_GETLINECOLOR = TV_FIRST + 41,
			TVM_MAPACCIDTOHTREEITEM = TV_FIRST + 42,
			TVM_MAPHTREEITEMTOACCID = TV_FIRST + 43,
			TVM_SETEXTENDEDSTYLE = TV_FIRST + 44,
			TVM_GETEXTENDEDSTYLE = TV_FIRST + 45,
			TVM_INSERTITEM = TV_FIRST + 50,
			TVM_SETAUTOSCROLLINFO = TV_FIRST + 59,
			TVM_SETHOT = TV_FIRST + 58,
			TVM_GETITEM = TV_FIRST + 62,
			TVM_SETITEM = TV_FIRST + 63,
			TVM_GETISEARCHSTRING = TV_FIRST + 64,
			TVM_EDITLABEL = TV_FIRST + 65,
			TVM_GETSELECTEDCOUNT = TV_FIRST + 70,
			TVM_SHOWINFOTIP = TV_FIRST + 71,
			TVM_GETITEMPARTRECT = TV_FIRST + 72,
		}

		[PInvokeData("Commctrl.h", MSDNShortId = "ff486107")]
		public enum TreeViewNotification
		{
			TVN_ASYNCDRAW = TVN_FIRST - 20,
			TVN_BEGINDRAG = TVN_FIRST - 56,
			TVN_BEGINLABELEDIT = TVN_FIRST - 59,
			TVN_BEGINRDRAG = TVN_FIRST - 57,
			TVN_DELETEITEM = TVN_FIRST - 58,
			TVN_ENDLABELEDIT = TVN_FIRST - 60,
			TVN_GETDISPINFO = TVN_FIRST - 52,
			TVN_GETINFOTIP = TVN_FIRST - 14,
			TVN_ITEMCHANGED = TVN_FIRST - 19,
			TVN_ITEMCHANGING = TVN_FIRST - 17,
			TVN_ITEMEXPANDED = TVN_FIRST - 55,
			TVN_ITEMEXPANDING = TVN_FIRST - 54,
			TVN_KEYDOWN = TVN_FIRST - 12,
			TVN_SELCHANGED = TVN_FIRST - 51,
			TVN_SELCHANGING = TVN_FIRST - 50,
			TVN_SETDISPINFO = TVN_FIRST - 53,
			TVN_SINGLEEXPAND = TVN_FIRST - 15,
		}

		/// <summary>Used as return values to the TVN_SINGLEEXPAND notification.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773553")]
		public enum TreeViewNotificationReturnBehavior
		{
			/// <summary>Allow the default behavior to occur.</summary>
			TVNRET_DEFAULT = 0,
			/// <summary>Skip default processing of the item being unselected.</summary>
			TVNRET_SKIPOLD = 1,
			/// <summary>Skip default processing of the item being selected.</summary>
			TVNRET_SKIPNEW = 2,
		}

		/// <summary>Used in the <see cref="NMTREEVIEW.action"/> action member coming through the lParam of a TVN_SELCHANGED notification.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773544")]
		public enum TreeViewSelChangedCause
		{
			/// <summary>Unknown.</summary>
			TVC_UNKNOWN = 0x0000,
			/// <summary>By a mouse click.</summary>
			TVC_BYMOUSE = 0x0001,
			/// <summary>By a keystroke.</summary>
			TVC_BYKEYBOARD = 0x0002,
		}

		/// <summary>Used as the wParam value in a TVM_SETBORDER message.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "ee663567")]
		[Flags]
		public enum TreeViewSetBorderFlags
		{
			/// <summary>Applies the specified border size to the left side of the items in the tree-view control.</summary>
			TVSBF_XBORDER = 0x00000001,
			/// <summary>Applies the specified border size to the top of the items in the tree-view control.</summary>
			TVSBF_YBORDER = 0x00000002,
		}

		/// <summary>Used as the wParam value in a TVM_SETIMAGELIST and TVM_GETIMAGELIST messages.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773747")]
		public enum TreeViewSetImageListType
		{
			/// <summary>Indicates the normal image list, which contains selected, nonselected, and overlay images for the items of a tree-view control.</summary>
			TVSIL_NORMAL = 0,
			/// <summary>Indicates the state image list. You can use state images to indicate application-defined item states. A state image is displayed to the left of an item's selected or nonselected image.</summary>
			TVSIL_STATE = 2
		}

		/// <summary>Window styles used when creating tree-view controls.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760013")]
		[Flags]
		public enum TreeViewStyle
		{
			/// <summary>Version 4.70. Enables check boxes for items in a tree-view control. A check box is displayed only if an image is associated with the item. When set to this style, the control effectively uses DrawFrameControl to create and set a state image list containing two images. State image 1 is the unchecked box and state image 2 is the checked box. Setting the state image to zero removes the check box altogether. For more information, see Working with state image indexes. <para>Version 5.80. Displays a check box even if no image is associated with the item.</para><para>Once a tree-view control is created with this style, the style cannot be removed. Instead, you must destroy the control and create a new one in its place. Destroying the tree-view control does not destroy the check box state image list. You must destroy it explicitly. Get the handle to the state image list by sending the tree-view control a TVM_GETIMAGELIST message. Then destroy the image list with ImageList_Destroy.</para><para>If you want to use this style, you must set the TVS_CHECKBOXES style with SetWindowLong after you create the treeview control, and before you populate the tree. Otherwise, the checkboxes might appear unchecked, depending on timing issues.</para></summary>
			TVS_CHECKBOXES = 0x0100,
			/// <summary>Prevents the tree-view control from sending TVN_BEGINDRAG notification codes.</summary>
			TVS_DISABLEDRAGDROP = 0x0010,
			/// <summary>Allows the user to edit the labels of tree-view items.</summary>
			TVS_EDITLABELS = 0x0008,
			/// <summary>Version 4.71. Enables full-row selection in the tree view. The entire row of the selected item is highlighted, and clicking anywhere on an item's row causes it to be selected. This style cannot be used in conjunction with the TVS_HASLINES style.</summary>
			TVS_FULLROWSELECT = 0x1000,
			/// <summary>Displays plus (+) and minus (-) buttons next to parent items. The user clicks the buttons to expand or collapse a parent item's list of child items. To include buttons with items at the root of the tree view, TVS_LINESATROOT must also be specified.</summary>
			TVS_HASBUTTONS = 0x0001,
			/// <summary>Uses lines to show the hierarchy of items.</summary>
			TVS_HASLINES = 0x0002,
			/// <summary>Version 4.71. Obtains tooltip information by sending the TVN_GETINFOTIP notification.</summary>
			TVS_INFOTIP = 0x0800,
			/// <summary>Uses lines to link items at the root of the tree-view control. This value is ignored if TVS_HASLINES is not also specified.</summary>
			TVS_LINESATROOT = 0x0004,
			/// <summary>Version 5.80. Disables horizontal scrolling in the control. The control will not display any horizontal scroll bars.</summary>
			TVS_NOHSCROLL = 0x8000,
			/// <summary>Version 4.71 Sets the height of the items to an odd height with the TVM_SETITEMHEIGHT message. By default, the height of items must be an even value.</summary>
			TVS_NONEVENHEIGHT = 0x4000,
			/// <summary>Version 4.71. Disables both horizontal and vertical scrolling in the control. The control will not display any scroll bars.</summary>
			TVS_NOSCROLL = 0x2000,
			/// <summary>Version 4.70. Disables tooltips.</summary>
			TVS_NOTOOLTIPS = 0x0080,
			/// <summary>Version 4.70. Causes text to be displayed from right-to-left (RTL). Usually, windows display text left-to-right (LTR). Windows can be mirrored to display languages such as Hebrew or Arabic that read RTL. Typically, tree-view text is displayed in the same direction as the text in its parent window. If TVS_RTLREADING is set, tree-view text reads in the opposite direction from the text in the parent window.</summary>
			TVS_RTLREADING = 0x0040,
			/// <summary>Causes a selected item to remain selected when the tree-view control loses focus.</summary>
			TVS_SHOWSELALWAYS = 0x0020,
			/// <summary>Version 4.71. Causes the item being selected to expand and the item being unselected to collapse upon selection in the tree view. If the mouse is used to single-click the selected item and that item is closed, it will be expanded. If the user holds down the CTRL key while selecting an item, the item being unselected will not be collapsed.<para>Version 5.80. Causes the item being selected to expand and the item being unselected to collapse upon selection in the tree view. If the user holds down the CTRL key while selecting an item, the item being unselected will not be collapsed.</para></summary>
			TVS_SINGLEEXPAND = 0x0400,
			/// <summary>Version 4.70. Enables hot tracking in a tree-view control.</summary>
			TVS_TRACKSELECT = 0x0200,
		}

		/// <summary>Extended styles used when creating tree-view controls. The value of extended styles is a bitwise combination of these styles.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb759981")]
		[Flags]
		public enum TreeViewStyleEx
		{
			/// <summary>Windows Vista. Remove the horizontal scroll bar and auto-scroll depending on mouse position.</summary>
			TVS_EX_AUTOHSCROLL = 0x0020,
			/// <summary>Windows Vista. Include dimmed checkbox state if the control has the TVS_CHECKBOXES style.</summary>
			TVS_EX_DIMMEDCHECKBOXES = 0x0200,
			/// <summary>Windows Vista. Specifies how the background is erased or filled.</summary>
			TVS_EX_DOUBLEBUFFER = 0x0004,
			/// <summary>Windows Vista. Retrieves calendar grid information.</summary>
			TVS_EX_DRAWIMAGEASYNC = 0x0400,
			/// <summary>Windows Vista. Include exclusion checkbox state if the control has the TVS_CHECKBOXES style.</summary>
			TVS_EX_EXCLUSIONCHECKBOXES = 0x0100,
			/// <summary>Windows Vista. Fade expando buttons in or out when the mouse moves away or into a state of hovering over the control.</summary>
			TVS_EX_FADEINOUTEXPANDOS = 0x0040,
			/// <summary>Not supported. Do not use.</summary>
			TVS_EX_MULTISELECT = 0x0002,
			/// <summary>Windows Vista. Do not indent the tree view for the expando buttons.</summary>
			TVS_EX_NOINDENTSTATE = 0x0008,
			/// <summary>Windows Vista. Intended for internal use; not recommended for use in applications. Do not collapse the previously selected tree-view item unless it has the same parent as the new selection. This style must be used with the TVS_SINGLEEXPAND style.<note>This style may not be supported in future versions of Comctl32.dll. Also, this style is not defined in commctrl.h.</note></summary>
			TVS_EX_NOSINGLECOLLAPSE = 0x0001,
			/// <summary>Windows Vista. Include partial checkbox state if the control has the TVS_CHECKBOXES style.</summary>
			TVS_EX_PARTIALCHECKBOXES = 0x0080,
			/// <summary>Windows Vista. Allow rich tooltips in the tree view (custom drawn with icon and text).</summary>
			TVS_EX_RICHTOOLTIP = 0x0010,
		}

		[PInvokeData("Commctrl.h", MSDNShortId = "bb773442")]
		public enum TVITEMPART
		{
			/// <summary>Button item part.</summary>
			TVGIPR_BUTTON = 0x0001,
		}

		/// <summary>
		/// Contains information about a tree-view notification message. This structure is identical to the NM_TREEVIEW structure, but it has been renamed to follow current naming conventions.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773411")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NMTREEVIEW
		{
			/// <summary>NMHDR structure that contains information about this notification message.</summary>
			public NMHDR hdr;
			/// <summary>Notification-specific action flag. This member is used with the following notification codes: TVN_ITEMEXPANDING, TVN_ITEMEXPANDED, TVN_SELCHANGING, TVN_SELCHANGED. For the possible action flag values, see TVM_EXPAND and TVN_SELCHANGED.</summary>
			public int action;
			/// <summary>TVITEM structure that contains information about the old item state. This member is zero for notification messages that do not use it.</summary>
			public TVITEM itemOld;
			/// <summary>TVITEM structure that contains information about the new item state. This member is zero for notification messages that do not use it.</summary>
			public TVITEM itemNew;
			/// <summary>POINT structure that contains the client coordinates of the mouse at the time the event occurred that caused the notification message to be sent.</summary>
			public Point ptDrag;
		}

		/// <summary>
		/// Contains an explanation of why the draw of an icon or overlay tree item failed. This structure is sent on a TVN_ASYNCDRAW notification. Set the dwRetFlags member to indicate what action the control should take. Note that a draw can fail if there is no image; in other words, when the icon image has not been extracted.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773413")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMTVASYNCDRAW
		{
			/// <summary>NMHDR structure.</summary>
			public NMHDR hdr;
			/// <summary>IMAGELISTDRAWPARAMS structure describing the image that failed to draw.</summary>
			public IMAGELISTDRAWPARAMS pimldp;
			/// <summary>Result code indicating why the draw failed, either ILDRF_IMAGELOWQUALITY, ILDRF_OVERLAYLOWQUALITY, E_PENDING, or S_OK. A code of S_OK indicates that the image is present but not at the required image quality.</summary>
			public HRESULT hr;
			/// <summary>Handle of the tree item that failed to draw.</summary>
			public HTREEITEM hItem;
			/// <summary>Data for hItem. This is the same data for the item that is retrieved with the message TVM_GETITEM using the appropriate mask in structure TVITEM. This data is parent specific; the parent can store information that helps it identify the tree item or other information. Data is provided in lParam for convenience, so that the parent does not need to send message TVM_GETITEM.</summary>
			public IntPtr lParam;
			/// <summary>Action that the sender (the tree-view control) should execute on return.</summary>
			public AsyncDrawRetFlags dwRetFlags;
			/// <summary>Index of the image to draw in the image list. Used if ADRF_DRAWIMAGE is returned in dwRetFlags.</summary>
			public int iRetImageIndex;
		}

		/// <summary>Contains information specific to an NM_CUSTOMDRAW (tree view) notification code sent by a tree-view control.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773415")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMTVCUSTOMDRAW
		{
			/// <summary>NMCUSTOMDRAW structure that contains general custom draw information.</summary>
			public NMCUSTOMDRAW nmcd;
			/// <summary>COLORREF value representing the color that will be used to display text foreground in the tree-view control.</summary>
			public int clrText;
			/// <summary>COLORREF value representing the color that will be used to display text background in the tree-view control.</summary>
			public int clrTextBk;
			/// <summary>Version 4.71. Zero-based level of the item being drawn. The root item is at level zero, a child of the root item is at level one, and so on.</summary>
			public int iLevel;
		}

		/// <summary>
		/// Contains and receives display information for a tree-view item. This structure is identical to the TV_DISPINFO structure, but it has been renamed to
		/// follow current naming conventions.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773418")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NMTVDISPINFO
		{
			/// <summary>NMHDR structure that contains information about this notification.</summary>
			public NMHDR hdr;
			/// <summary>TVITEM structure that identifies and contains information about the tree-view item. The mask member of the TVITEM structure specifies which information is being set or retrieved.</summary>
			public TVITEM item;
		}

		/// <summary>Contains information pertaining to extended TreeView notification information.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760143")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NMTVDISPINFOEX
		{
			/// <summary>NMHDR structure that contains information about this notification.</summary>
			public NMHDR hdr;
			/// <summary>Specifies or receives attributes of a TreeView item.</summary>
			public TVITEMEX item;
		}

		/// <summary>
		/// Contains and receives tree-view item information needed to display a tooltip for an item. This structure is used with the TVN_GETINFOTIP notification code.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773421")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NMTVGETINFOTIP
		{
			/// <summary>NMHDR structure that contains information about this notification.</summary>
			public NMHDR hdr;
			/// <summary>Address of a character buffer that contains the text to be displayed. If you want to change the text displayed in the tooltip, you will need to modify the contents of this buffer. The size of this buffer is specified by the cchTextMax structure.</summary>
			public StrPtrAuto pszText;
			/// <summary>Size of the buffer at pszText, in characters. Although you should never assume that this buffer will be of any particular size, the INFOTIPSIZE value can be used for design purposes.</summary>
			public int cchTextMax;
			/// <summary>Tree handle to the item for which the tooltip is being displayed.</summary>
			public HTREEITEM hItem;
			/// <summary>Application-defined data associated with the item for which the tooltip is being displayed.</summary>
			public IntPtr lParam;
		}

		/// <summary>
		/// Contains information about a keyboard event in a tree-view control. This structure is used with the TVN_KEYDOWN notification code. The structure is identical to the TV_KEYDOWN structure, but it has been renamed to follow current naming conventions.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773433")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMTVKEYDOWN
		{
			/// <summary>NMHDR structure that contains information about this notification.</summary>
			public NMHDR hdr;
			/// <summary>Virtual key code.</summary>
			public ushort wVKey;
			/// <summary>Always zero.</summary>
			public uint flags;
		}

		/// <summary>
		/// Contains information for identifying the "hit zone" for a specified part of a tree item. The structure is used with the TVM_GETITEMPARTRECT message and the TreeView_GetItemPartRect macro.
		/// </summary>
		/// <seealso cref="System.IDisposable" />
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773442")]
		[StructLayout(LayoutKind.Sequential)]
		public sealed class TVGETITEMPARTRECTINFO : IDisposable
		{
			/// <summary>Handle to the parent item.</summary>
			public HTREEITEM hti;
			/// <summary>Pointer to a RECT structure to receive the coordinates of the bounding rectangle. The sender of the message (the caller) is responsible for allocating this structure.</summary>
			public IntPtr prc;
			/// <summary>ID of the item part. This value must be TVGIPR_BUTTON (0x0001).</summary>
			public TVITEMPART partID;

			/// <summary>Initializes a new instance of the <see cref="TVGETITEMPARTRECTINFO"/> class.</summary>
			/// <param name="hTreeNode">The h tree node.</param>
			public TVGETITEMPARTRECTINFO(HTREEITEM hTreeNode)
			{
				hti = hTreeNode;
				prc = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(RECT)));
				partID = TVITEMPART.TVGIPR_BUTTON;
			}

			/// <summary>Gets the bounds.</summary>
			/// <value>The bounds.</value>
			public Rectangle Bounds => prc.ToStructure<RECT>();

			/// <summary>
			/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
			/// </summary>
			void IDisposable.Dispose() { Marshal.FreeCoTaskMem(prc); }
		}

		/// <summary>
		/// Contains information used to determine the location of a point relative to a tree-view control. This structure is used with the TVM_HITTEST message. The structure is identical to the TV_HITTESTINFO structure, but it has been renamed to follow current naming conventions.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773448")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TVHITTESTINFO
		{
			/// <summary>Client coordinates of the point to test.</summary>
			public Point pt;
			/// <summary>Variable that receives information about the results of a hit test.</summary>
			public TreeViewHitTestFlags flags;
			/// <summary>Handle to the item that occupies the point.</summary>
			public HTREEITEM hItem;
		}

		/// <summary>
		/// Contains information used to add a new item to a tree-view control. This structure is used with the TVM_INSERTITEM message. The structure is identical to the TV_INSERTSTRUCT structure, but it has been renamed to follow current naming conventions.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773452")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TVINSERTSTRUCT
		{
			/// <summary>Handle to the parent item. If this member is the TVI_ROOT value or NULL, the item is inserted at the root of the tree-view control.</summary>
			public HTREEITEM hParent;
			/// <summary>Handle to the item after which the new item is to be inserted, or one of the following values:</summary>
			public HTREEITEM hInsertAfter;
			/// <summary>Version 4.71. TVITEMEX structure that contains information about the item to add.</summary>
			public TVITEMEX itemex;
		}

		/// <summary>Contains information on a tree-view item change. This structure is sent with the TVN_ITEMCHANGED and TVN_ITEMCHANGING notifications.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773425")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NMTVITEMCHANGE
		{
			/// <summary>NMHDR structure that contains information about the notification.</summary>
			public NMHDR hdr;
			/// <summary>Specifies the attribute. The only supported attribute is state. uChanged must have the following value: TVIF_STATE = The change is the state attribute.</summary>
			public TreeViewItemMask uChanged;
			/// <summary>Handle to the changed tree-view item.</summary>
			public HTREEITEM hItem;
			/// <summary>Flag that specifies the new item state.</summary>
			public TreeViewItemStates uStateNew;
			/// <summary>Flag that specifies the item's previous state.</summary>
			public TreeViewItemStates uStateOld;
			/// <summary>Reserved for application specific data. For example, a value to associate with the item.</summary>
			public IntPtr lParam;
		}

		/// <summary>
		/// Specifies or receives attributes of a tree-view item. This structure is identical to the TV_ITEM structure, but it has been renamed to follow current
		/// naming conventions. New applications should use this structure.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773456")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TVITEM
		{
			/// <summary>Array of flags that indicate which of the other structure members contain valid data. When this structure is used with the TVM_GETITEM message, the mask member indicates the item attributes to retrieve. If used with the TVM_SETITEM message, the mask indicates the attributes to set.</summary>
			public TreeViewItemMask mask;
			/// <summary>Handle to the item.</summary>
			public HTREEITEM hItem;
			/// <summary>Set of bit flags and image list indexes that indicate the item's state. When setting the state of an item, the stateMask member indicates the valid bits of this member. When retrieving the state of an item, this member returns the current state for the bits indicated in the stateMask member.</summary>
			public uint state;
			/// <summary>Bits of the state member that are valid. If you are retrieving an item's state, set the bits of the stateMask member to indicate the bits to be returned in the state member. If you are setting an item's state, set the bits of the stateMask member to indicate the bits of the state member that you want to set. To set or retrieve an item's overlay image index, set the TVIS_OVERLAYMASK bits. To set or retrieve an item's state image index, set the TVIS_STATEIMAGEMASK bits.</summary>
			public TreeViewItemStates stateMask;
			/// <summary>Pointer to a null-terminated string that contains the item text if the structure specifies item attributes. If this member is the LPSTR_TEXTCALLBACK value, the parent window is responsible for storing the name. In this case, the tree-view control sends the parent window a TVN_GETDISPINFO notification code when it needs the item text for displaying, sorting, or editing and a TVN_SETDISPINFO notification code when the item text changes. If the structure is receiving item attributes, this member is the address of the buffer that receives the item text. Note that although the tree-view control allows any length string to be stored as item text, only the first 260 characters are displayed.</summary>
			public IntPtr pszText;
			/// <summary>Size of the buffer pointed to by the pszText member, in characters. If this structure is being used to set item attributes, this member is ignored.</summary>
			public int cchTextMax;
			/// <summary>Index in the tree-view control's image list of the icon image to use when the item is in the nonselected state. If this member is the I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the tree-view control sends the parent a TVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.</summary>
			public int iImage;
			/// <summary>Index in the tree-view control's image list of the icon image to use when the item is in the selected state. If this member is the I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the tree-view control sends the parent a TVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.</summary>
			public int iSelectedImage;
			/// <summary>Flag that indicates whether the item has associated child items. This member can be one of the following values.
			/// <list type="table">
			/// <listheader><term>Value</term><term>Meaning</term></listheader>
			/// <item><term>zero</term><description>The item has no child items.</description></item>
			/// <item><term>one</term><description>The item has one or more child items.</description></item>
			/// <item><term>I_CHILDRENCALLBACK</term><description>The parent window keeps track of whether the item has child items.In this case, when the tree-view control needs to display the item, the control sends the parent a TVN_GETDISPINFO notification code to determine whether the item has child items.<para>If the tree-view control has the TVS_HASBUTTONS style, it uses this member to determine whether to display the button indicating the presence of child items. You can use this member to force the control to display the button even though the item does not have any child items inserted. This allows you to display the button while minimizing the control's memory usage by inserting child items only when the item is visible or expanded.</para></description></item>
			/// <item><term>I_CHILDRENAUTO</term><description>Version 6.0 Intended for internal use; not recommended for use in applications.The tree-view control automatically determines whether the item has child items.<note>This flag may not be supported in future versions of Comctl32.dll.Also, this flag is not defined in commctrl.h.Add the following definition to the source files of your application to use the flag:</note><code>#define I_CHILDRENAUTO (-2)</code></description></item>
			/// </list>
			/// </summary>
			public int cChildren;
			/// <summary>A value to associate with the item.</summary>
			public IntPtr lParam;

			/// <summary>Gets or sets a value indicating whether this <see cref="TVITEM"/> is bold.</summary>
			/// <value><c>true</c> if bold; otherwise, <c>false</c>.</value>
			public bool Bold
			{
				get => GetState(TreeViewItemStates.TVIS_BOLD); set => SetState(TreeViewItemStates.TVIS_BOLD, value);
			}

			/// <summary>Gets or sets a value indicating whether this <see cref="TVITEM"/> is expanded.</summary>
			/// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
			public bool Expanded
			{
				get => GetState(TreeViewItemStates.TVIS_EXPANDED); set => SetState(TreeViewItemStates.TVIS_EXPANDED, value);
			}

			/// <summary>Gets or sets a value indicating whether child items have been expanded at least once.</summary>
			/// <value><c>true</c> if child items have been expanded at least once; otherwise, <c>false</c>.</value>
			public bool ExpandedOnce
			{
				get => GetState(TreeViewItemStates.TVIS_EXPANDEDONCE); set => SetState(TreeViewItemStates.TVIS_EXPANDEDONCE, value);
			}

			/// <summary>Gets or sets a value indicating whether item is partially expanded.</summary>
			/// <value><c>true</c> if partially expanded; otherwise, <c>false</c>.</value>
			public bool ExpandedPartial
			{
				get => GetState(TreeViewItemStates.TVIS_EXPANDPARTIAL); set => SetState(TreeViewItemStates.TVIS_EXPANDPARTIAL, value);
			}

			/// <summary>Gets or sets the index of the overlay image.</summary>
			/// <value>The index of the overlay image.</value>
			/// <exception cref="ArgumentOutOfRangeException">OverlayImageIndex - Overlay image index must be between 0 and 15</exception>
			public uint OverlayImageIndex
			{
				get => (state & 0x00000F00) >> 8; set
				{
					if (value > 15)
						throw new ArgumentOutOfRangeException(nameof(OverlayImageIndex), "Overlay image index must be between 0 and 15");
					mask |= TreeViewItemMask.TVIF_STATE;
					stateMask |= TreeViewItemStates.TVIS_OVERLAYMASK;
					state = (value << 8) | (state & 0xFFFFF0FF);
				}
			}

			/// <summary>Gets or sets a value indicating whether this <see cref="TVITEM"/> is selected.</summary>
			/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
			public bool Selected
			{
				get => GetState(TreeViewItemStates.TVIS_SELECTED); set => SetState(TreeViewItemStates.TVIS_SELECTED, value);
			}

			/// <summary>Gets or sets a value indicating whether item is selected as part of a cut-and-paste operation.</summary>
			/// <value><c>true</c> if item is selected as part of a cut-and-paste operation; otherwise, <c>false</c>.</value>
			public bool SelectedForCut
			{
				get => GetState(TreeViewItemStates.TVIS_CUT); set => SetState(TreeViewItemStates.TVIS_CUT, value);
			}

			/// <summary>Gets or sets a value indicating whether item is selected as a drag-and-drop target.</summary>
			/// <value><c>true</c> if item is selected as a drag-and-drop target; otherwise, <c>false</c>.</value>
			public bool SelectedForDragDrop
			{
				get => GetState(TreeViewItemStates.TVIS_DROPHILITED); set => SetState(TreeViewItemStates.TVIS_DROPHILITED, value);
			}

			/// <summary>Gets the state.</summary>
			/// <value>The state.</value>
			public TreeViewItemStates State => (TreeViewItemStates)(state & 0x000000FF);

			/// <summary>Gets or sets the index of the state image.</summary>
			/// <value>The index of the state image.</value>
			/// <exception cref="ArgumentOutOfRangeException">StateImageIndex - State image index must be between 0 and 15</exception>
			public uint StateImageIndex
			{
				get => (state & 0x0000F000) >> 12; set
				{
					if (value > 15)
						throw new ArgumentOutOfRangeException(nameof(StateImageIndex), "State image index must be between 0 and 15");
					mask |= TreeViewItemMask.TVIF_STATE;
					stateMask |= TreeViewItemStates.TVIS_STATEIMAGEMASK;
					state = (value << 12) | (state & 0xFFFF0FFF);
				}
			}

			/// <summary>Gets the text.</summary>
			/// <value>The text.</value>
			public string Text => pszText == LPSTR_TEXTCALLBACK ? null : Marshal.PtrToStringUni(pszText);

			/// <summary>Gets or sets a value indicating whether to use text callback.</summary>
			/// <value><c>true</c> if to use text callback; otherwise, <c>false</c>.</value>
			public bool UseTextCallback
			{
				get => pszText == LPSTR_TEXTCALLBACK;
				set
				{
					if (value)
						pszText = LPSTR_TEXTCALLBACK;
					mask |= TreeViewItemMask.TVIF_TEXT;
				}
			}

			/// <summary>Gets a value on whether the specified state is set.</summary>
			/// <param name="itemState">State of the item.</param>
			/// <returns><c>true</c> if the specified state is set; otherwise, <c>false</c>.</returns>
			public bool GetState(TreeViewItemStates itemState) => State.IsFlagSet(itemState);

			/// <summary>Sets the state of the specified state.</summary>
			/// <param name="itemState">State of the item.</param>
			/// <param name="on">if set to <c>true</c> set this state on.</param>
			public void SetState(TreeViewItemStates itemState, bool on = true)
			{
				mask |= TreeViewItemMask.TVIF_STATE;
				stateMask |= itemState;
				var tempState = State;
				EnumExtensions.SetFlags(ref tempState, itemState, on);
				state = (uint)tempState | (state & 0xFFFFFF00);
			}

			/// <summary>Sets the text.</summary>
			/// <param name="managedStringPtr">The managed string PTR.</param>
			/// <param name="stringLen">Length of the string.</param>
			public void SetText(IntPtr managedStringPtr, int stringLen)
			{
				pszText = managedStringPtr;
				cchTextMax = stringLen;
				mask |= TreeViewItemMask.TVIF_TEXT;
			}

			/// <summary>Returns a <see cref="System.String" /> that represents this instance.</summary>
			/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
			public override string ToString() => $"TVITEM: pszText={Text}; iImage={iImage}; iSelectedImage={iSelectedImage}; state={state}; cChildren={cChildren}";
		}

		/// <summary>
		/// Specifies or receives attributes of a tree-view item. This structure is an enhancement to the TVITEM structure. New applications should use this structure where appropriate.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773459")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TVITEMEX
		{
			/// <summary>Array of flags that indicate which of the other structure members contain valid data. When this structure is used with the TVM_GETITEM message, the mask member indicates the item attributes to retrieve. If used with the TVM_SETITEM message, the mask indicates the attributes to set.</summary>
			public TreeViewItemMask mask;
			/// <summary>Handle to the item.</summary>
			public HTREEITEM hItem;
			/// <summary>Set of bit flags and image list indexes that indicate the item's state. When setting the state of an item, the stateMask member indicates the valid bits of this member. When retrieving the state of an item, this member returns the current state for the bits indicated in the stateMask member.</summary>
			public uint state;
			/// <summary>Bits of the state member that are valid. If you are retrieving an item's state, set the bits of the stateMask member to indicate the bits to be returned in the state member. If you are setting an item's state, set the bits of the stateMask member to indicate the bits of the state member that you want to set. To set or retrieve an item's overlay image index, set the TVIS_OVERLAYMASK bits. To set or retrieve an item's state image index, set the TVIS_STATEIMAGEMASK bits.</summary>
			public TreeViewItemStates stateMask;
			/// <summary>Pointer to a null-terminated string that contains the item text if the structure specifies item attributes. If this member is the LPSTR_TEXTCALLBACK value, the parent window is responsible for storing the name. In this case, the tree-view control sends the parent window a TVN_GETDISPINFO notification code when it needs the item text for displaying, sorting, or editing and a TVN_SETDISPINFO notification code when the item text changes. If the structure is receiving item attributes, this member is the address of the buffer that receives the item text. Note that although the tree-view control allows any length string to be stored as item text, only the first 260 characters are displayed.</summary>
			public IntPtr pszText;
			/// <summary>Size of the buffer pointed to by the pszText member, in characters. If this structure is being used to set item attributes, this member is ignored.</summary>
			public int cchTextMax;
			/// <summary>Index in the tree-view control's image list of the icon image to use when the item is in the nonselected state. If this member is the I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the tree-view control sends the parent a TVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.</summary>
			public int iImage;
			/// <summary>Index in the tree-view control's image list of the icon image to use when the item is in the selected state. If this member is the I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the tree-view control sends the parent a TVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.</summary>
			public int iSelectedImage;
			/// <summary>Flag that indicates whether the item has associated child items. This member can be one of the following values.
			/// <list type="table">
			/// <listheader><term>Value</term><term>Meaning</term></listheader>
			/// <item><term>zero</term><description>The item has no child items.</description></item>
			/// <item><term>one</term><description>The item has one or more child items.</description></item>
			/// <item><term>I_CHILDRENCALLBACK</term><description>The parent window keeps track of whether the item has child items.In this case, when the tree-view control needs to display the item, the control sends the parent a TVN_GETDISPINFO notification code to determine whether the item has child items.<para>If the tree-view control has the TVS_HASBUTTONS style, it uses this member to determine whether to display the button indicating the presence of child items. You can use this member to force the control to display the button even though the item does not have any child items inserted. This allows you to display the button while minimizing the control's memory usage by inserting child items only when the item is visible or expanded.</para></description></item>
			/// <item><term>I_CHILDRENAUTO</term><description>Version 6.0 Intended for internal use; not recommended for use in applications.The tree-view control automatically determines whether the item has child items.<note>This flag may not be supported in future versions of Comctl32.dll.Also, this flag is not defined in commctrl.h.Add the following definition to the source files of your application to use the flag:</note><code>#define I_CHILDRENAUTO (-2)</code></description></item>
			/// </list>
			/// </summary>
			public int cChildren;
			/// <summary>A value to associate with the item.</summary>
			public IntPtr lParam;
			/// <summary>The i integral</summary>
			public int iIntegral;
			/// <summary>The u state ex</summary>
			public TreeViewItemStatesEx uStateEx;
			/// <summary>The HWND</summary>
			public IntPtr hwnd;
			/// <summary>The i expanded image</summary>
			public int iExpandedImage;
			/// <summary>The i reserved</summary>
			public int iReserved;

			/// <summary>Gets or sets a value indicating whether this <see cref="TVITEM"/> is bold.</summary>
			/// <value><c>true</c> if bold; otherwise, <c>false</c>.</value>
			public bool Bold
			{
				get => GetState(TreeViewItemStates.TVIS_BOLD); set => SetState(TreeViewItemStates.TVIS_BOLD, value);
			}

			/// <summary>Gets or sets a value indicating whether this <see cref="TVITEM"/> is expanded.</summary>
			/// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
			public bool Expanded
			{
				get => GetState(TreeViewItemStates.TVIS_EXPANDED); set => SetState(TreeViewItemStates.TVIS_EXPANDED, value);
			}

			/// <summary>Gets or sets a value indicating whether child items have been expanded at least once.</summary>
			/// <value><c>true</c> if child items have been expanded at least once; otherwise, <c>false</c>.</value>
			public bool ExpandedOnce
			{
				get => GetState(TreeViewItemStates.TVIS_EXPANDEDONCE); set => SetState(TreeViewItemStates.TVIS_EXPANDEDONCE, value);
			}

			/// <summary>Gets or sets a value indicating whether item is partially expanded.</summary>
			/// <value><c>true</c> if partially expanded; otherwise, <c>false</c>.</value>
			public bool ExpandedPartial
			{
				get => GetState(TreeViewItemStates.TVIS_EXPANDPARTIAL); set => SetState(TreeViewItemStates.TVIS_EXPANDPARTIAL, value);
			}

			/// <summary>Gets or sets the index of the overlay image.</summary>
			/// <value>The index of the overlay image.</value>
			/// <exception cref="ArgumentOutOfRangeException">OverlayImageIndex - Overlay image index must be between 0 and 15</exception>
			public uint OverlayImageIndex
			{
				get => (state & 0x00000F00) >> 8; set
				{
					if (value > 15)
						throw new ArgumentOutOfRangeException(nameof(OverlayImageIndex), "Overlay image index must be between 0 and 15");
					mask |= TreeViewItemMask.TVIF_STATE;
					stateMask |= TreeViewItemStates.TVIS_OVERLAYMASK;
					state = (value << 8) | (state & 0xFFFFF0FF);
				}
			}

			/// <summary>Gets or sets a value indicating whether this <see cref="TVITEM"/> is selected.</summary>
			/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
			public bool Selected
			{
				get => GetState(TreeViewItemStates.TVIS_SELECTED); set => SetState(TreeViewItemStates.TVIS_SELECTED, value);
			}

			/// <summary>Gets or sets a value indicating whether item is selected as part of a cut-and-paste operation.</summary>
			/// <value><c>true</c> if item is selected as part of a cut-and-paste operation; otherwise, <c>false</c>.</value>
			public bool SelectedForCut
			{
				get => GetState(TreeViewItemStates.TVIS_CUT); set => SetState(TreeViewItemStates.TVIS_CUT, value);
			}

			/// <summary>Gets or sets a value indicating whether item is selected as a drag-and-drop target.</summary>
			/// <value><c>true</c> if item is selected as a drag-and-drop target; otherwise, <c>false</c>.</value>
			public bool SelectedForDragDrop
			{
				get => GetState(TreeViewItemStates.TVIS_DROPHILITED); set => SetState(TreeViewItemStates.TVIS_DROPHILITED, value);
			}

			/// <summary>Gets the state.</summary>
			/// <value>The state.</value>
			public TreeViewItemStates State => (TreeViewItemStates)(state & 0x000000FF);

			/// <summary>Gets or sets the index of the state image.</summary>
			/// <value>The index of the state image.</value>
			/// <exception cref="ArgumentOutOfRangeException">StateImageIndex - State image index must be between 0 and 15</exception>
			public uint StateImageIndex
			{
				get => (state & 0x0000F000) >> 12; set
				{
					if (value > 15)
						throw new ArgumentOutOfRangeException(nameof(StateImageIndex), "State image index must be between 0 and 15");
					mask |= TreeViewItemMask.TVIF_STATE;
					stateMask |= TreeViewItemStates.TVIS_STATEIMAGEMASK;
					state = (value << 12) | (state & 0xFFFF0FFF);
				}
			}

			/// <summary>Gets the text.</summary>
			/// <value>The text.</value>
			public string Text => pszText == LPSTR_TEXTCALLBACK ? null : Marshal.PtrToStringUni(pszText);

			/// <summary>Gets or sets a value indicating whether to use text callback.</summary>
			/// <value><c>true</c> if to use text callback; otherwise, <c>false</c>.</value>
			public bool UseTextCallback
			{
				get => pszText == LPSTR_TEXTCALLBACK;
				set
				{
					if (value)
						pszText = LPSTR_TEXTCALLBACK;
					mask |= TreeViewItemMask.TVIF_TEXT;
				}
			}

			/// <summary>Gets a value on whether the specified state is set.</summary>
			/// <param name="itemState">State of the item.</param>
			/// <returns><c>true</c> if the specified state is set; otherwise, <c>false</c>.</returns>
			public bool GetState(TreeViewItemStates itemState) => State.IsFlagSet(itemState);

			/// <summary>Sets the state of the specified state.</summary>
			/// <param name="itemState">State of the item.</param>
			/// <param name="on">if set to <c>true</c> set this state on.</param>
			public void SetState(TreeViewItemStates itemState, bool on = true)
			{
				mask |= TreeViewItemMask.TVIF_STATE;
				stateMask |= itemState;
				var tempState = State;
				EnumExtensions.SetFlags(ref tempState, itemState, on);
				state = (uint)tempState | (state & 0xFFFFFF00);
			}

			/// <summary>Sets the text.</summary>
			/// <param name="managedStringPtr">The managed string PTR.</param>
			/// <param name="stringLen">Length of the string.</param>
			public void SetText(IntPtr managedStringPtr, int stringLen)
			{
				pszText = managedStringPtr;
				cchTextMax = stringLen;
				mask |= TreeViewItemMask.TVIF_TEXT;
			}

			/// <summary>Returns a <see cref="string" /> that represents this instance.</summary>
			/// <returns>A <see cref="string" /> that represents this instance.</returns>
			public override string ToString() => $"TVITEM: pszText={Text}; iImage={iImage}; iSelectedImage={iSelectedImage}; state={state}; iExpandedImage={iExpandedImage}; iIntegral={iIntegral}; cChildren={cChildren}";
		}

		/// <summary>
		/// Contains information used to sort child items in a tree-view control. This structure is used with the TVM_SORTCHILDRENCB message. This structure is
		/// identical to the TV_SORTCB structure, but it has been renamed to follow current naming conventions.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb773462")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TVSORTCB
		{
			/// <summary>Handle to the parent item.</summary>
			public HTREEITEM hParent;
			/// <summary>
			/// Address of an application-defined callback function, which is called during a sort operation each time the relative order of two list items needs
			/// to be compared.
			/// </summary>
			public PFNTVCOMPARE lpfnCompare;
			/// <summary>Application-defined value that gets passed as the lParamSort argument in the callback function specified in lpfnCompare.</summary>
			public IntPtr lParam;
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="item">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Unicode, SetLastError = false)]
		public static extern IntPtr SendMessage(HandleRef hWnd, TreeViewMessage Msg, int wParam, TVGETITEMPARTRECTINFO item);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="hitTestInfo">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Unicode, SetLastError = false)]
		public static extern IntPtr SendMessage(HandleRef hWnd, TreeViewMessage Msg, [MarshalAs(UnmanagedType.Bool)] bool wParam, ref TVHITTESTINFO hitTestInfo);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="item">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Unicode, SetLastError = false)]
		public static extern IntPtr SendMessage(HandleRef hWnd, TreeViewMessage Msg, int wParam, ref TVINSERTSTRUCT item);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="sortInfo">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Unicode, SetLastError = false)]
		public static extern IntPtr SendMessage(HandleRef hWnd, TreeViewMessage Msg, int wParam, ref TVSORTCB sortInfo);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="item">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Unicode, SetLastError = false)]
		public static extern IntPtr SendMessage(HandleRef hWnd, TreeViewMessage Msg, int wParam, ref TVITEMEX item);
	}
}