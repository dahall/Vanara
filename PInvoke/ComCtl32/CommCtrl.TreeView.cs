using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary/>
	public const int I_CHILDRENAUTO = -2;

	/// <summary/>
	public const int I_CHILDRENCALLBACK = -1;

	/// <summary>TreeView's custom draw return meaning don't draw images. valid on CDRF_NOTIFYITEMPREPAINT</summary>
	public const int TVCDRF_NOIMAGES = 0x00010000;

	private const int TV_FIRST = 0x1100;
	private const int TVN_FIRST = -400;

	/// <summary>
	/// An application-defined callback function, which is called during a sort operation each time the relative order of two list items
	/// needs to be compared.
	/// </summary>
	/// <param name="lParam1">Corresponds to the lParam member of the first TVITEM structure for the two items being compared.</param>
	/// <param name="lParam2">Corresponds to the lParam member of the second TVITEM structure for the two items being compared.</param>
	/// <param name="lParamSort">Corresponds to the lParam member of this structure.</param>
	/// <returns>
	/// The callback function must return a negative value if the first item should precede the second, a positive value if the first
	/// item should follow the second, or zero if the two items are equivalent.
	/// </returns>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773462")]
	public delegate int PFNTVCOMPARE(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);

	/// <summary>Action that the sender (the tree-view control) should execute on return.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773413")]
	public enum AsyncDrawRetFlags
	{
		/// <summary>
		/// Proceed to draw the image anyway, that is, synchronously extract the image and paint. Assuming the control is on the UI
		/// thread, use of this flag implies low priority UI performance, since extraction times may vary and the UI could be
		/// unresponsive for an extended period of time during extraction.
		/// </summary>
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
		/// <summary>Retrieves the currently selected item. You can use the TreeView_GetSelection macro to send this message.</summary>
		TVGN_CARET = 0x0009,

		/// <summary>
		/// Retrieves the first child item of the item specified by the hitem parameter. You can use the TreeView_GetChild macro to send
		/// this message.
		/// </summary>
		TVGN_CHILD = 0x0004,

		/// <summary>
		/// Retrieves the item that is the target of a drag-and-drop operation. You can use the TreeView_GetDropHilight macro to send
		/// this message.
		/// </summary>
		TVGN_DROPHILITE = 0x0008,

		/// <summary>
		/// Retrieves the first item that is visible in the tree-view window. You can use the TreeView_GetFirstVisible macro to send this message.
		/// </summary>
		TVGN_FIRSTVISIBLE = 0x0005,

		/// <summary>
		/// Version 4.71. Retrieves the last expanded item in the tree. This does not retrieve the last item visible in the tree-view
		/// window. You can use the TreeView_GetLastVisible macro to send this message.
		/// </summary>
		TVGN_LASTVISIBLE = 0x000A,

		/// <summary>Retrieves the next sibling item. You can use the TreeView_GetNextSibling macro to send this message.</summary>
		TVGN_NEXT = 0x0001,

		/// <summary>
		/// Windows Vista and later. Retrieves the next selected item. You can use the TreeView_GetNextSelected macro to send this message.
		/// </summary>
		TVGN_NEXTSELECTED = 0x000B,

		/// <summary>
		/// Retrieves the next visible item that follows the specified item. The specified item must be visible. Use the TVM_GETITEMRECT
		/// message to determine whether an item is visible. You can use the TreeView_GetNextVisible macro to send this message.
		/// </summary>
		TVGN_NEXTVISIBLE = 0x0006,

		/// <summary>Retrieves the parent of the specified item. You can use the TreeView_GetParent macro to send this message.</summary>
		TVGN_PARENT = 0x0003,

		/// <summary>Retrieves the previous sibling item. You can use the TreeView_GetPrevSibling macro to send this message.</summary>
		TVGN_PREVIOUS = 0x0002,

		/// <summary>
		/// Retrieves the first visible item that precedes the specified item. The specified item must be visible. Use the
		/// TVM_GETITEMRECT message to determine whether an item is visible. You can use the TreeView_GetPrevVisible macro to send this message.
		/// </summary>
		TVGN_PREVIOUSVISIBLE = 0x0007,

		/// <summary>
		/// Retrieves the topmost or very first item of the tree-view control. You can use the TreeView_GetRoot macro to send this message.
		/// </summary>
		TVGN_ROOT = 0x0000,

		/// <summary>
		/// When a single item is selected, ensures that the treeview does not expand the children of that item. This is valid only if
		/// used with the TVGN_CARET flag.
		/// </summary>
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

		/// <summary>
		/// Version 4.70. Partially expands the list. In this state the child items are visible and the parent item's plus sign (+),
		/// indicating that it can be expanded, is displayed. This flag must be used in combination with the TVE_EXPAND flag.
		/// </summary>
		TVE_EXPANDPARTIAL = 0x4000,

		/// <summary>
		/// Collapses the list and removes the child items. The TVIS_EXPANDEDONCE state flag is reset. This flag must be used with the
		/// TVE_COLLAPSE flag.
		/// </summary>
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

	/// <summary>
	/// Used in <see cref="TVITEM"/> and <see cref="TVITEMEX"/> mask members to indicate which structure members contain valid data.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773459")]
	[Flags]
	public enum TreeViewItemMask
	{
		/// <summary>The cChildren member is valid.</summary>
		TVIF_CHILDREN = 0x0040,

		/// <summary>
		/// The tree-view control will retain the supplied information and will not request it again. This flag is valid only when
		/// processing the TVN_GETDISPINFO notification.
		/// </summary>
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
	/// Set of bit flags and image list indexes that indicate the item's state. When setting the state of an item, the stateMask member
	/// indicates the valid bits of this member. When retrieving the state of an item, this member returns the current state for the bits
	/// indicated in the stateMask member.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773459")]
	[Flags]
	public enum TreeViewItemStates
	{
		/// <summary>
		/// The item is selected. Its appearance depends on whether it has the focus. The item will be drawn using the system colors for selection.
		/// </summary>
		TVIS_SELECTED = 0x0002,

		/// <summary>The item is selected as part of a cut-and-paste operation.</summary>
		TVIS_CUT = 0x0004,

		/// <summary>The item is selected as a drag-and-drop target.</summary>
		TVIS_DROPHILITED = 0x0008,

		/// <summary>The item is bold.</summary>
		TVIS_BOLD = 0x0010,

		/// <summary>
		/// The item's list of child items is currently expanded; that is, the child items are visible. This value applies only to parent items.
		/// </summary>
		TVIS_EXPANDED = 0x0020,

		/// <summary>
		/// The item's list of child items has been expanded at least once. The TVN_ITEMEXPANDING and TVN_ITEMEXPANDED notification codes
		/// are not generated for parent items that have this state set in response to a TVM_EXPAND message. Using TVE_COLLAPSE and
		/// TVE_COLLAPSERESET with TVM_EXPAND will cause this state to be reset. This value applies only to parent items.
		/// </summary>
		TVIS_EXPANDEDONCE = 0x0040,

		/// <summary>
		/// Version 4.70. A partially expanded tree-view item. In this state, some, but not all, of the child items are visible and the
		/// parent item's plus symbol is displayed.
		/// </summary>
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
		/// <summary>
		/// Creates a flat item—the item is virtual and is not visible in the tree; instead, its children take its place in the tree
		/// hierarchy. This state is valid only when adding an item to the tree-view control.
		/// </summary>
		TVIS_EX_FLAT = 0x0001,

		/// <summary>Windows Vista and later. Creates a control that is drawn in gray, that the user cannot interact with.</summary>
		TVIS_EX_DISABLED = 0x0002,

		/// <summary>Creates a separate HWND for the item. This state is valid only when adding an item to the tree-view control.</summary>
		TVIS_EX_HWND = 0x0004,
	}

	/// <summary>
	/// Tree View Messages
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "ff486106")]
	public enum TreeViewMessage
	{
		/// <summary>
		/// Removes an item and all its children from a tree-view control. You can send this message explicitly or by using the
		/// <c>TreeView_DeleteItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// <c>HTREEITEM</c> handle to the item to delete. If lParam is set to TVI_ROOT or to <c>NULL</c>, all items are deleted. You can
		/// also use the <c>TreeView_DeleteAllItems</c> macro to delete all items.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>It is not safe to delete items in response to a notification such as TVN_SELCHANGING.</para>
		/// <para>Once an item is deleted, its handle is invalid and cannot be used.</para>
		/// <para>The parent window receives a TVN_DELETEITEM notification code when each item is removed.</para>
		/// <para>
		/// If the item label is being edited, the edit operation is canceled and the parent window receives the TVN_ENDLABELEDIT
		/// notification code.
		/// </para>
		/// <para>
		/// If you delete all items in a tree-view control that has the <c>TVS_NOSCROLL</c> style, items subsequently added may not
		/// display properly. For more information, see <c>TreeView_DeleteAllItems</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-deleteitem
		TVM_DELETEITEM = TV_FIRST + 1,

		/// <summary>
		/// The <c>TVM_EXPAND</c> message expands or collapses the list of child items associated with the specified parent item, if any.
		/// You can send this message explicitly or by using the <c>TreeView_Expand</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Action flag. This parameter can be one or more of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TVE_COLLAPSE</c></term>
		/// <term>Collapses the list.</term>
		/// </item>
		/// <item>
		/// <term><c>TVE_COLLAPSERESET</c></term>
		/// <term>
		/// Collapses the list and removes the child items. The <c>TVIS_EXPANDEDONCE</c> state flag is reset. This flag must be used with
		/// the TVE_COLLAPSE flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVE_EXPAND</c></term>
		/// <term>Expands the list.</term>
		/// </item>
		/// <item>
		/// <term><c>TVE_EXPANDPARTIAL</c></term>
		/// <term>
		/// Version 4.70. Partially expands the list. In this state the child items are visible and the parent item's plus sign (+),
		/// indicating that it can be expanded, is displayed. This flag must be used in combination with the TVE_EXPAND flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVE_TOGGLE</c></term>
		/// <term>Collapses the list if it is expanded or expands it if it is collapsed.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the parent item to expand or collapse.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if the operation was successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Expanding a node that is already expanded is considered a successful operation and <c>SendMessage</c> returns a nonzero
		/// value. Collapsing a node returns zero if the node is already collapsed; otherwise it returns nonzero. Attempting to expand or
		/// collapse a node that has no children is considered a failure and <c>SendMessage</c> returns zero.
		/// </para>
		/// <para>
		/// When an item is first expanded by a <c>TVM_EXPAND</c> message, the action generates TVN_ITEMEXPANDING and TVN_ITEMEXPANDED
		/// notification codes and the item's <c>TVIS_EXPANDEDONCE</c> state flag is set. As long as this state flag remains set,
		/// subsequent <c>TVM_EXPAND</c> messages do not generate TVN_ITEMEXPANDING or TVN_ITEMEXPANDED notifications. To reset the
		/// <c>TVIS_EXPANDEDONCE</c> state flag, you must send a <c>TVM_EXPAND</c> message with the TVE_COLLAPSE and TVE_COLLAPSERESET
		/// flags set. Attempting to explicitly set <c>TVIS_EXPANDEDONCE</c> will result in unpredictable behavior.
		/// </para>
		/// <para>
		/// The expand operation may fail if the owner of the treeview control denies the operation in response to a TVN_ITEMEXPANDING notification.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-expand
		TVM_EXPAND = TV_FIRST + 2,

		/// <summary>
		/// Retrieves the bounding rectangle for a tree-view item and indicates whether the item is visible. You can send this message
		/// explicitly or by using the <c>TreeView_GetItemRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Value specifying the portion of the item for which to retrieve the bounding rectangle. If this parameter is <c>TRUE</c>, the
		/// bounding rectangle includes only the text of the item. Otherwise, it includes the entire line that the item occupies in the
		/// tree-view control.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that, when sending the message, contains the handle of the item to retrieve the rectangle
		/// for. See the example below for more information on how to place the item handle in this parameter. After returning from the
		/// message, this parameter contains the bounding rectangle. The coordinates are relative to the upper-left corner of the
		/// tree-view control.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the item is visible and the bounding rectangle was successfully retrieved, the return value is <c>TRUE</c>. Otherwise, the
		/// message returns <c>FALSE</c> and does not retrieve the bounding rectangle.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When sending this message, the lParam parameter contains the handle of the item that the rectangle is being retrieved for.
		/// The handle is placed in lParam as shown in the following example:
		/// </para>
		/// <para>
		/// <code>RECT rc; *(HTREEITEM*)&amp;rc = hTreeItem; SendMessage(hwndTreeView, TVM_GETITEMRECT, FALSE, (LPARAM)&amp;rc);</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getitemrect
		TVM_GETITEMRECT = TV_FIRST + 4,

		/// <summary>
		/// Retrieves a count of the items in a tree-view control. You can send this message explicitly or by using the
		/// <c>TreeView_GetCount</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the count of items.</para>
		/// </summary>
		/// <remarks>
		/// The node count returned by <c>TreeView_GetCount</c> is limited to integer values. If you add a node beyond 32767 the macro
		/// returns a negative value. After adding 65536 nodes the count returns to zero. When this occurs, the tree-view control appears
		/// empty with no scrollbars.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getcount
		TVM_GETCOUNT = TV_FIRST + 5,

		/// <summary>
		/// Retrieves the amount, in pixels, that child items are indented relative to their parent items. You can send this message
		/// explicitly or by using the <c>TreeView_GetIndent</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the amount of indentation.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getindent
		TVM_GETINDENT = TV_FIRST + 6,

		/// <summary>
		/// Sets the width of indentation for a tree-view control and redraws the control to reflect the new width. You can send this
		/// message explicitly or by using the <c>TreeView_SetIndent</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Width, in pixels, of the indentation. If this parameter is less than the system-defined minimum width, the new width is set
		/// to the system-defined minimum.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// The system-defined minimum indent value is typically five pixels, but it is not fixed. To retrieve the exact value of the
		/// minimum indent on a particular system, send a <c>TVM_SETINDENT</c> message with wParam set to zero. Then send a
		/// <c>TVM_GETINDENT</c> message to retrieve the minimum indent value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setindent
		TVM_SETINDENT = TV_FIRST + 7,

		/// <summary>
		/// Retrieves the handle to the normal or state image list associated with a tree-view control. You can send this message
		/// explicitly or by using the <c>TreeView_GetImageList</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Type of image list to retrieve. This parameter can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TVSIL_NORMAL</c></term>
		/// <term>
		/// Indicates the normal image list, which contains selected, nonselected, and overlay images for the items of a tree-view control.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVSIL_STATE</c></term>
		/// <term>
		/// Indicates the state image list. You can use state images to indicate application-defined item states. A state image is
		/// displayed to the left of an item's selected or nonselected image.
		/// </term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns an HIMAGELIST handle to the specified image list.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getimagelist
		TVM_GETIMAGELIST = TV_FIRST + 8,

		/// <summary>
		/// Sets the normal or state image list for a tree-view control and redraws the control using the new images. You can send this
		/// message explicitly or by using the <c>TreeView_SetImageList</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Type of image list to set. This parameter can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TVSIL_NORMAL</c></term>
		/// <term>
		/// Indicates the normal image list, which contains selected, nonselected, and overlay images for the items of a tree-view control.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVSIL_STATE</c></term>
		/// <term>
		/// Indicates the state image list. You can use state images to indicate application-defined item states. A state image is
		/// displayed to the left of an item's selected or nonselected image.
		/// </term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Handle to the image list. If lParam is <c>NULL</c>, the message removes the specified image list from the tree-view control.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the previous image list, if any, or <c>NULL</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The tree-view control will not destroy the image list specified with this message. Your application must destroy the image
		/// list when it is no longer needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setimagelist
		TVM_SETIMAGELIST = TV_FIRST + 9,

		/// <summary>
		/// Retrieves the tree-view item that bears the specified relationship to a specified item. You can send this message explicitly,
		/// by using the <c>TreeView_GetNextItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Flag specifying the item to retrieve. This parameter can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TVGN_CARET</c></term>
		/// <term>Retrieves the currently selected item. You can use the <c>TreeView_GetSelection</c> macro to send this message.</term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_CHILD</c></term>
		/// <term>
		/// Retrieves the first child item of the item specified by the <c>hitem</c> parameter. You can use the <c>TreeView_GetChild</c>
		/// macro to send this message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_DROPHILITE</c></term>
		/// <term>
		/// Retrieves the item that is the target of a drag-and-drop operation. You can use the <c>TreeView_GetDropHilight</c> macro to
		/// send this message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_FIRSTVISIBLE</c></term>
		/// <term>
		/// Retrieves the first item that is visible in the tree-view window. You can use the <c>TreeView_GetFirstVisible</c> macro to
		/// send this message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_LASTVISIBLE</c></term>
		/// <term>
		/// Version 4.71. Retrieves the last expanded item in the tree. This does not retrieve the last item visible in the tree-view
		/// window. You can use the <c>TreeView_GetLastVisible</c> macro to send this message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_NEXT</c></term>
		/// <term>Retrieves the next sibling item. You can use the <c>TreeView_GetNextSibling</c> macro to send this message.</term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_NEXTSELECTED</c></term>
		/// <term>
		/// <c>Windows Vista and later.</c> Retrieves the next selected item. You can use the <c>TreeView_GetNextSelected</c> macro to
		/// send this message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_NEXTVISIBLE</c></term>
		/// <term>
		/// Retrieves the next visible item that follows the specified item. The specified item must be visible. Use the
		/// <c>TVM_GETITEMRECT</c> message to determine whether an item is visible. You can use the <c>TreeView_GetNextVisible</c> macro
		/// to send this message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_PARENT</c></term>
		/// <term>Retrieves the parent of the specified item. You can use the <c>TreeView_GetParent</c> macro to send this message.</term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_PREVIOUS</c></term>
		/// <term>Retrieves the previous sibling item. You can use the <c>TreeView_GetPrevSibling</c> macro to send this message.</term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_PREVIOUSVISIBLE</c></term>
		/// <term>
		/// Retrieves the first visible item that precedes the specified item. The specified item must be visible. Use the
		/// <c>TVM_GETITEMRECT</c> message to determine whether an item is visible. You can use the <c>TreeView_GetPrevVisible</c> macro
		/// to send this message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_ROOT</c></term>
		/// <term>
		/// Retrieves the topmost or very first item of the tree-view control. You can use the <c>TreeView_GetRoot</c> macro to send this message.
		/// </term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Handle to an item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the item if successful. For most cases, the message returns a <c>NULL</c> value to indicate an error.
		/// See the Remarks section for details.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message will return <c>NULL</c> if the item being retrieved is the root node of the tree. For example, if you use this
		/// message with the TVGN_PARENT flag on a first-level child of the tree view's root node, the message will return <c>NULL</c>.
		/// </para>
		/// <para>You can also use one of these related macros:</para>
		/// <list type="table">
		/// <listheader>
		/// <term/>
		/// </listheader>
		/// <item>
		/// <term><c>TreeView_GetChild</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetDropHilight</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetFirstVisible</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetLastVisible</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetNextSibling</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetNextVisible</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetParent</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetPrevSibling</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetPrevVisible</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetRoot</c></term>
		/// </item>
		/// <item>
		/// <term><c>TreeView_GetSelection</c></term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getnextitem
		TVM_GETNEXTITEM = TV_FIRST + 10,

		/// <summary>
		/// Selects the specified tree-view item, scrolls the item into view, or redraws the item in the style used to indicate the
		/// target of a drag-and-drop operation. You can send this message explicitly or by using the <c>TreeView_Select</c>,
		/// <c>TreeView_SelectItem</c>, or <c>TreeView_SelectDropTarget</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Action flag. This parameter can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TVGN_CARET</c></term>
		/// <term>
		/// Sets the selection to the specified item. The tree-view control's parent window receives the TVN_SELCHANGING and
		/// TVN_SELCHANGED notification codes.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_DROPHILITE</c></term>
		/// <term>Redraws the specified item in the style used to indicate the target of a drag-and-drop operation.</term>
		/// </item>
		/// <item>
		/// <term><c>TVGN_FIRSTVISIBLE</c></term>
		/// <term>
		/// Ensures that the specified item is visible, and, if possible, displays it at the top of the control's window. Tree-view
		/// controls display as many items as will fit in the window. If the specified item is near the bottom of the control's hierarchy
		/// of items, it might not become the first visible item, depending on how many items fit in the window.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TVSI_NOSINGLEEXPAND</c></term>
		/// <term>
		/// When a single item is selected, ensures that the treeview does not expand the children of that item. This is valid only if
		/// used with the TVGN_CARET flag.
		/// </term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Handle to an item. If lParam is <c>NULL</c>, the control is set to have no selected item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the specified item is the child of a collapsed parent item, the parent's list of child items is expanded to reveal the
		/// specified item. In this case, the control's parent window receives the TVN_ITEMEXPANDING and TVN_ITEMEXPANDED notification codes.
		/// </para>
		/// <para>
		/// Using the <c>TreeView_SelectItem</c> macro is equivalent to sending the <c>TVM_SELECTITEM</c> message with wParam set to the
		/// TVGN_CARET value. Using the <c>TreeView_SelectDropTarget</c> macro is equivalent to sending the <c>TVM_SELECTITEM</c> message
		/// with wParam set to the TVGN_DROPHILITE value. Using <c>TreeView_SelectSetFirstVisible</c> is equivalent to sending the
		/// <c>TVM_SELECTITEM</c> message with wParam set to the TVGN_FIRSTVISIBLE value.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-selectitem
		TVM_SELECTITEM = TV_FIRST + 11,

		/// <summary>
		/// Retrieves the handle to the edit control being used to edit a tree-view item's text. You can send this message explicitly or
		/// by using the <c>TreeView_GetEditControl</c> macro.
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
		/// When label editing begins, an edit control is created, but not positioned or displayed. Before it is displayed, the tree-view
		/// control sends its parent window an TVN_BEGINLABELEDIT notification code.
		/// </para>
		/// <para>
		/// To customize label editing, implement a handler for TVN_BEGINLABELEDIT and have it send a <c>TVM_GETEDITCONTROL</c> message
		/// to the tree-view control. If a label is being edited, the return value will be a handle to the edit control. Use this handle
		/// to customize the edit control by sending the usual <c>EM_XXX</c> messages.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-geteditcontrol
		TVM_GETEDITCONTROL = TV_FIRST + 15,

		/// <summary>
		/// Obtains the number of items that can be fully visible in the client window of a tree-view control. You can send this message
		/// explicitly or by using the <c>TreeView_GetVisibleCount</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the number of items that can be fully visible in the client window of the tree-view control.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The number of items that can be fully visible may be greater than the number of items in the control. The control calculates
		/// this value by dividing the height of the client window by the height of an item.
		/// </para>
		/// <para>
		/// Note that the return value is the number of items that can be fully visible. If you can see all of 20 items and part of one
		/// more item, the return value is 20.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getvisiblecount
		TVM_GETVISIBLECOUNT = TV_FIRST + 16,

		/// <summary>
		/// Determines the location of the specified point relative to the client area of a tree-view control. You can send this message
		/// explicitly or by using the <c>TreeView_HitTest</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TVHITTESTINFO</c> structure. When the message is sent, the <c>pt</c> member specifies the coordinates of the
		/// point to test. When the message returns, the <c>hItem</c> member is the handle to the item at the specified point or
		/// <c>NULL</c> if no item occupies the point. Also, when the message returns, the <c>flags</c> member is a hit test value that
		/// indicates the location of the specified point. For a list of hit test values, see the description of the <c>TVHITTESTINFO</c> structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the tree-view item that occupies the specified point, or <c>NULL</c> if no item occupies the point.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-hittest
		TVM_HITTEST = TV_FIRST + 17,

		/// <summary>
		/// Creates a dragging bitmap for the specified item in a tree-view control. The message also creates an image list for the
		/// bitmap and adds the bitmap to the image list. An application can display the image when dragging the item by using the image
		/// list functions. You can send this message explicitly or by using the <c>TreeView_CreateDragImage</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the item that receives the new dragging bitmap.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the image list to which the dragging bitmap was added if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If you create a tree-view control without an associated image list, you cannot use the <c>TVM_CREATEDRAGIMAGE</c> message to
		/// create the image to display during a drag operation. You must implement your own method of creating a drag cursor.
		/// </para>
		/// <para>Your application is responsible for destroying the image list when it is no longer needed.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-createdragimage
		TVM_CREATEDRAGIMAGE = TV_FIRST + 18,

		/// <summary>
		/// Sorts the child items of the specified parent item in a tree-view control. You can send this message explicitly or by using
		/// the <c>TreeView_SortChildren</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Value that specifies whether the sorting is recursive. Set wParam to <c>TRUE</c> to sort all levels of child items below the
		/// parent item. Otherwise, only the parent's immediate children are sorted.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the parent item whose child items are to be sorted.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// This message alphabetizes the tree items using <c>lstrcmpi</c> on the item name. You can use the <c>TVM_SORTCHILDRENCB</c>
		/// message to customize the ordering behavior.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-sortchildren
		TVM_SORTCHILDREN = TV_FIRST + 19,

		/// <summary>
		/// Ensures that a tree-view item is visible, expanding the parent item or scrolling the tree-view control, if necessary. You can
		/// send this message explicitly or by using the <c>TreeView_EnsureVisible</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns nonzero if the system scrolled the items in the tree-view control and no items were expanded. Otherwise, the message
		/// returns zero.
		/// </para>
		/// </summary>
		/// <remarks>
		/// If the TVM_ENSUREVISIBLE message expands the parent item, the parent window receives the TVN_ITEMEXPANDING and
		/// TVN_ITEMEXPANDED notification codes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-ensurevisible
		TVM_ENSUREVISIBLE = TV_FIRST + 20,

		/// <summary>
		/// Sorts tree-view items using an application-defined callback function that compares the items. You can send this message
		/// explicitly or by using the <c>TreeView_SortChildrenCB</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Reserved. Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TVSORTCB</c> structure. The <c>lpfnCompare</c> member is the address of the application-defined callback
		/// function, which is called during the sort operation each time the relative order of two list items needs to be compared. For
		/// more information about the callback function, see the description of <c>TVSORTCB</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-sortchildrencb
		TVM_SORTCHILDRENCB = TV_FIRST + 21,

		/// <summary>
		/// Ends the editing of a tree-view item's label. You can send this message explicitly or by using the
		/// <c>TreeView_EndEditLabelNow</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Variable that indicates whether the editing is canceled without being saved to the label. If this parameter is <c>TRUE</c>,
		/// the system cancels editing without saving the changes. Otherwise, the system saves the changes to the label.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>This message causes the TVN_ENDLABELEDIT notification code to be sent to the parent window of the tree-view control.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-endeditlabelnow
		TVM_ENDEDITLABELNOW = TV_FIRST + 22,

		/// <summary>
		/// Sets a tree-view control's child tooltip control. You can send this message explicitly or by using the
		/// <c>TreeView_SetToolTips</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to a tooltip control.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to tooltip control previously set for the tree-view control, or <c>NULL</c> if tooltips were not
		/// previously used.
		/// </para>
		/// </summary>
		/// <remarks>
		/// When created, tree-view controls automatically create a child tooltip control. To prevent a tree-view control from using
		/// tooltips, create the control with the <c>TVS_NOTOOLTIPS</c> style.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-settooltips
		TVM_SETTOOLTIPS = TV_FIRST + 24,

		/// <summary>
		/// Retrieves the handle to the child tooltip control used by a tree-view control. You can send this message explicitly or by
		/// using the <c>TreeView_GetToolTips</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the child tooltip control, or <c>NULL</c> if the control is not using tooltips.</para>
		/// </summary>
		/// <remarks>
		/// When created, tree-view controls automatically create a child tooltip control. To cause a tree-view control not to use
		/// tooltips, create the control with the <c>TVS_NOTOOLTIPS</c> style.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-gettooltips
		TVM_GETTOOLTIPS = TV_FIRST + 25,

		/// <summary>
		/// Sets the insertion mark in a tree-view control. You can send this message explicitly or by using the
		/// <c>TreeView_SetInsertMark</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// <c>BOOL</c> value that specifies if the insertion mark is placed before or after the specified item. If this argument is
		/// nonzero, the insertion mark will be placed after the item. If this argument is zero, the insertion mark will be placed before
		/// the item.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// <c>HTREEITEM</c> that specifies at which item the insertion mark will be placed. If this argument is <c>NULL</c>, the
		/// insertion mark is removed.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// In some circumstances, the insert mark can appear in two places after a node is expanded. If you are using insertion marks,
		/// it is recommended that you force a refresh of the control after expanding a node.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setinsertmark
		TVM_SETINSERTMARK = TV_FIRST + 26,

		/// <summary>
		/// Sets the Unicode character format flag for the control. This message allows you to change the character set used by the
		/// control at run time rather than having to re-create the control. You can send this message explicitly or use the
		/// <c>TreeView_SetUnicodeFormat</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Determines the character set that is used by the control. If this value is nonzero, the control will use Unicode characters.
		/// If this value is zero, the control will use ANSI characters.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous Unicode format flag for the control.</para>
		/// </summary>
		/// <remarks>See the remarks for <c>CCM_SETUNICODEFORMAT</c> for a discussion of this message.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setunicodeformat
		TVM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,

		/// <summary>
		/// Retrieves the Unicode character format flag for the control. You can send this message explicitly or use the
		/// <c>TreeView_GetUnicodeFormat</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the Unicode format flag for the control. If this value is nonzero, the control is using Unicode characters. If this
		/// value is zero, the control is using ANSI characters.
		/// </para>
		/// </summary>
		/// <remarks>See the remarks for <c>CCM_GETUNICODEFORMAT</c> for a discussion of this message.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getunicodeformat
		TVM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT,

		/// <summary>
		/// Sets the height of the tree-view items. You can send this message explicitly or by using the <c>TreeView_SetItemHeight</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// New height of every item in the tree view, in pixels. Heights less than 1 will be set to 1. If this argument is not even and
		/// the tree-view control does not have the <c>TVS_NONEVENHEIGHT</c> style, this value will be rounded down to the nearest even
		/// value. If this argument is -1, the control will revert to using its default item height.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous height of the items, in pixels.</para>
		/// </summary>
		/// <remarks>
		/// The tree-view control uses this value for the height of all items. To modify the height of individual items, see the
		/// description of the <c>iIntegral</c> member of the <c>TVITEMEX</c> structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setitemheight
		TVM_SETITEMHEIGHT = TV_FIRST + 27,

		/// <summary>
		/// Retrieves the current height of the each tree-view item. You can send this message explicitly or by using the
		/// <c>TreeView_GetItemHeight</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the height of each item, in pixels.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getitemheight
		TVM_GETITEMHEIGHT = TV_FIRST + 28,

		/// <summary>
		/// Sets the background color of the control. You can send this message explicitly or by using the <c>TreeView_SetBkColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// <c>COLORREF</c> value that contains the new background color. If this value is -1, the control will revert to using the
		/// system color for the background color.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>COLORREF</c> value that represents the previous background color. If this value is -1, the control was using the
		/// system color for the background color.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setbkcolor
		TVM_SETBKCOLOR = TV_FIRST + 29,

		/// <summary>
		/// Sets the text color of the control. You can send this message explicitly or by using the <c>TreeView_SetTextColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// <c>COLORREF</c> value that contains the new text color. If this argument is -1, the control will revert to using the system
		/// color for the text color.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>COLORREF</c> value that represents the previous text color. If this value is -1, the control was using the
		/// system color for the text color.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-settextcolor
		TVM_SETTEXTCOLOR = TV_FIRST + 30,

		/// <summary>
		/// Retrieves the current background color of the control. You can send this message explicitly or by using the
		/// <c>TreeView_GetBkColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>COLORREF</c> value that represents the current background color. If this value is -1, the control is using the
		/// system color for the background color.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getbkcolor
		TVM_GETBKCOLOR = TV_FIRST + 31,

		/// <summary>
		/// Retrieves the current text color of the control. You can send this message explicitly or by using the
		/// <c>TreeView_GetTextColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>COLORREF</c> value that represents the current text color. If this value is -1, the control is using the system
		/// color for the text color.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-gettextcolor
		TVM_GETTEXTCOLOR = TV_FIRST + 32,

		/// <summary>
		/// Sets the maximum scroll time for the tree-view control. You can send this message explicitly or by using the
		/// <c>TreeView_SetScrollTime</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>New maximum scroll time, in milliseconds.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous maximum scroll time, in milliseconds.</para>
		/// </summary>
		/// <remarks>
		/// The maximum scroll time is the longest amount of time that a scroll operation can take. Scrolling will be adjusted so that
		/// the scroll will take place within the maximum scroll time. A scroll operation may take less time than the maximum.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setscrolltime
		TVM_SETSCROLLTIME = TV_FIRST + 33,

		/// <summary>
		/// Retrieves the maximum scroll time for the tree-view control. You can send this message explicitly or by using the
		/// <c>TreeView_GetScrollTime</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the maximum scroll time, in milliseconds.</para>
		/// </summary>
		/// <remarks>
		/// The maximum scroll time is the longest amount of time that a scroll operation can take. The scrolling will be adjusted so
		/// that the scroll will take place within the maximum scroll time. A scroll operation may take less time than the maximum.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getscrolltime
		TVM_GETSCROLLTIME = TV_FIRST + 34,

		/// <summary>
		/// Sets the color used to draw the insertion mark for the tree view. You can send this message explicitly or by using the
		/// <c>TreeView_SetInsertMarkColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para><c>COLORREF</c> value that contains the new insertion mark color.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>COLORREF</c> value that contains the previous insertion mark color.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setinsertmarkcolor
		TVM_SETINSERTMARKCOLOR = TV_FIRST + 37,

		/// <summary>
		/// Retrieves the color used to draw the insertion mark for the tree view. You can send this message explicitly or by using the
		/// <c>TreeView_GetInsertMarkColor</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>COLORREF</c> value that contains the current insertion mark color.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getinsertmarkcolor
		TVM_GETINSERTMARKCOLOR = TV_FIRST + 38,

		/// <summary>
		/// <para><c>Intended for internal use; not recommended for use in applications.</c></para>
		/// <para>
		/// Sets the size of the border for the items in a tree-view control. You can send the message explicitly or by using the
		/// <c>TreeView_SetBorder</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Action flags. This parameter can be one or more of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TVSBF_XBORDER</c></term>
		/// <term>Applies the specified border size to the left side of the items in the tree-view control.</term>
		/// </item>
		/// <item>
		/// <term><c>TVSBF_YBORDER</c></term>
		/// <term>Applies the specified border size to the top of the items in the tree-view control.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is a <c>SHORT</c> that specifies the size of the left border, in pixels. The <c>HIWORD</c> is a
		/// <c>SHORT</c> that specifies the size of the top border, in pixels.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>LONG</c> value that contains the previous border size, in pixels. The <c>LOWORD</c> contains the previous size
		/// of the horizontal border, and the <c>HIWORD</c> contains the previous size of the vertical border.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para><c>Security Warning:</c> Using this message might compromise the security of your program.</para>
		/// <para>The item border is set just for spacing purposes. A successful setting triggers a recalculation of the scroll bars.</para>
		/// <para>
		/// This message may not be supported in future versions of Comctl32.dll. Also, this message is not defined in commctrl.h. Add
		/// the following definitions to the source files of your application to use the message:
		/// </para>
		/// <para>
		/// <code>#define TVM_SETBORDER (TV_FIRST + 35) #define TVSBF_XBORDER 0x00000001 #define TVSBF_YBORDER 0x00000002</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setborder
		TVM_SETBORDER = TV_FIRST + 35,

		/// <summary>
		/// Retrieves some or all of a tree-view item's state attributes. You can send this message explicitly or by using the
		/// <c>TreeView_GetItemState</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the item.</para>
		/// <para><em>lParam</em></para>
		/// <para>Mask used to specify the states to query for. It is equivalent to the <c>stateMask</c> member of <c>TVITEMEX</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>UINT</c> value with the appropriate state bits set to <c>TRUE</c>. Only those bits that are specified by lParam
		/// and that are <c>TRUE</c> will be set. This value is equivalent to the <c>state</c> member of <c>TVITEMEX</c>.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getitemstate
		TVM_GETITEMSTATE = TV_FIRST + 39,

		/// <summary>The <c>TVM_SETLINECOLOR</c> message sets the current line color.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>New line color. Use the CLR_DEFAULT value to restore the system default colors.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous line color.</para>
		/// </summary>
		/// <remarks>
		/// This message only changes line colors. To change the colors of the '+' and '-' inside the buttons, use the
		/// <c>TVM_SETTEXTCOLOR</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setlinecolor
		TVM_SETLINECOLOR = TV_FIRST + 40,

		/// <summary>The <c>TVM_GETLINECOLOR</c> message gets the current line color.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the current line color, or the CLR_DEFAULT value if none has been specified.</para>
		/// </summary>
		/// <remarks>
		/// This message only retrieves line colors. To retrieve the colors of the '+' and '-' inside the buttons, use the
		/// <c>TVM_GETTEXTCOLOR</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getlinecolor
		TVM_GETLINECOLOR = TV_FIRST + 41,

		/// <summary>Maps an accessibility ID to an <c>HTREEITEM</c>.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>**UINT** that contains the accessibility ID to map to an **HTREEITEM**.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the <c>HTREEITEM</c> that the specified accessibility ID is mapped to.</para>
		/// </summary>
		/// <remarks>
		/// <para>When you add an item to a tree-view control an <c>HTREEITEM</c> returns, which uniquely identifies the item.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-mapaccidtohtreeitem
		TVM_MAPACCIDTOHTREEITEM = TV_FIRST + 42,

		/// <summary>Maps an <c>HTREEITEM</c> to an accessibility ID.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>**HTREEITEM** that is mapped to an accessibility ID.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns an accessibility ID.</para>
		/// </summary>
		/// <remarks>
		/// <para>When you add an item to a tree-view control an <c>HTREEITEM</c> handle is returned that uniquely identifies the item.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
		/// Enabling Visual Styles.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-maphtreeitemtoaccid
		TVM_MAPHTREEITEMTOACCID = TV_FIRST + 43,

		/// <summary>Informs the tree-view control to set extended styles. Send this message or use the macro <c>TreeView_SetExtendedStyle</c>.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Mask used to select the styles to be set.</para>
		/// <para><em>lParam</em></para>
		/// <para>Value that indicates the extended style. For more information on styles, see Tree-View Control Extended Styles.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If this message succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </summary>
		/// <remarks>
		/// The extended styles for a tree-view control have nothing to do with the extended styles used with function
		/// <c>CreateWindowEx</c> or function <c>SetWindowLong</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setextendedstyle
		TVM_SETEXTENDEDSTYLE = TV_FIRST + 44,

		/// <summary>
		/// Retrieves the extended style for a tree-view control. Send this message explicitly or by using the
		/// <c>TreeView_GetExtendedStyle</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the value of extended style.For more information on styles, see Tree-View Control Extended Styles.</para>
		/// </summary>
		/// <remarks>
		/// The extended styles for a tree-view control have nothing to do with the extended styles used with function
		/// <c>CreateWindowEx</c> or function <c>SetWindowLong</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getextendedstyle
		TVM_GETEXTENDEDSTYLE = TV_FIRST + 45,

		/// <summary>
		/// Inserts a new item in a tree-view control. You can send this message explicitly or by using the <c>TreeView_InsertItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>TVINSERTSTRUCT</c> structure that specifies the attributes of the tree-view item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the <c>HTREEITEM</c> handle to the new item if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-insertitem
		TVM_INSERTITEM = TV_FIRST + 50,

		/// <summary>
		/// Sets information used to determine auto-scroll characteristics. You can send this message explicitly or by using the
		/// <c>TreeView_SetAutoScrollInfo</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies pixels per second. The offset to scroll is divided by the wParam to determine the total duration of the auto-scroll.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Specifies the redraw time interval. Redraw at every elasped interval, until the item is scrolled into view. Given wParam, the
		/// location of the item is calculated and a repaint occurs. Set this value to create smooth scrolling.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c>.</para>
		/// </summary>
		/// <remarks>
		/// Autoscroll information is used to scroll a nonvisible item into view. The control must have the <c>TVS_EX_AUTOHSCROLL</c>
		/// extended style. For information on extended styles, see Tree-View Control Extended Styles.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setautoscrollinfo
		TVM_SETAUTOSCROLLINFO = TV_FIRST + 59,

		/// <summary>
		/// <para>
		/// [Intended for internal use; not recommended for use in applications. This message may not be supported in future versions of Windows.]
		/// </para>
		/// <para>
		/// Sets the hot item for a tree-view control. You can send this message explicitly or by using the <c>TreeView_SetHot</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the new hot item. If this value is <c>NULL</c>, the tree-view control will be set to have no hot item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The hot item is the item that the mouse is hovering over. This message makes an item look like it is the hot item even if the
		/// mouse is not hovering over it.
		/// </para>
		/// <para>This message has no visible effect if the <c>TVS_TRACKSELECT</c> style is not set.</para>
		/// <para>If it succeeds, this message causes the hot item to be redrawn.</para>
		/// <para>This message is ignored if lParam is <c>NULL</c> and the tree-view control is tracking the mouse.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-sethot
		TVM_SETHOT = TV_FIRST + 58,

		/// <summary>
		/// Retrieves some or all of a tree-view item's attributes. You can send this message explicitly or by using the
		/// <c>TreeView_GetItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TVITEM</c> structure that specifies the information to retrieve and receives information about the item. With
		/// version 4.71 and later, you can use a <c>TVITEMEX</c> structure instead.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the message is sent, the <c>hItem</c> member of the <c>TVITEM</c> or <c>TVITEMEX</c> structure identifies the item to
		/// retrieve information about, and the <c>mask</c> member specifies the attributes to retrieve.
		/// </para>
		/// <para>
		/// If the TVIF_TEXT flag is set in the <c>mask</c> member of the <c>TVITEM</c> or <c>TVITEMEX</c> structure, the <c>pszText</c>
		/// member must point to a valid buffer and the <c>cchTextMax</c> member must be set to the number of characters in that buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getitem
		TVM_GETITEM = TV_FIRST + 62,

		/// <summary>
		/// The <c>TVM_SETITEM</c> message sets some or all of a tree-view item's attributes. You can send this message explicitly or by
		/// using the <c>TreeView_SetItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TVITEM</c> structure that contains the new item attributes. With version 4.71 and later, you can use a
		/// <c>TVITEMEX</c> structure instead.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The <c>hItem</c> member of the <c>TVITEM</c> or <c>TVITEMEX</c> structure identifies the item, and the <c>mask</c> member
		/// specifies which attributes to set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-setitem
		TVM_SETITEM = TV_FIRST + 63,

		/// <summary>
		/// Retrieves the incremental search string for a tree-view control. The tree-view control uses the incremental search string to
		/// select an item based on characters typed by the user. You can send this message explicitly or by using the
		/// <c>TreeView_GetISearchString</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to the buffer that receives the incremental search string.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the number of characters in the incremental search string.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <c>Security Warning:</c> Using this message incorrectly might compromise the security of your program. You must allocate a
		/// large enough buffer to hold the string. First call the message passing <c>NULL</c> in lParam. This returns the number of
		/// characters, excluding <c>NULL</c>, that are required. Then call the message a second time to retrieve the string. You should
		/// review Security Considerations: Microsoft Windows Controls before continuing.
		/// </para>
		/// <para>If the tree-view control is not in incremental search mode, the return value is zero.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getisearchstring
		TVM_GETISEARCHSTRING = TV_FIRST + 64,

		/// <summary>
		/// Begins in-place editing of the specified item's text, replacing the text of the item with a single-line edit control
		/// containing the text. This message implicitly selects and focuses the specified item. You can send this message explicitly or
		/// by using the <c>TreeView_EditLabel</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the item to edit.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the edit control used to edit the item text if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>This message sends a TVN_BEGINLABELEDIT notification code to the parent of the tree-view control.</para>
		/// <para>
		/// When the user completes or cancels editing, the edit control is destroyed and the handle is no longer valid. You can subclass
		/// the edit control, but do not destroy it.
		/// </para>
		/// <para>
		/// The control must have the focus before you send this message to the control. Focus can be set using the <c>SetFocus</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-editlabel
		TVM_EDITLABEL = TV_FIRST + 65,

		/// <summary>This message is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getselectedcount
		TVM_GETSELECTEDCOUNT = TV_FIRST + 70,

		/// <summary>
		/// Shows the infotip for a specified item in a tree-view control. You can send this message explicitly or by using the
		/// <c>TreeView_ShowInfoTip</c> macro..
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns zero.</para>
		/// </summary>
		/// <remarks>
		/// Most applications do not use this message. Infotips are shown automatically. For more information, see Using Tree-view
		/// Infotips in the About Tree-View Controls overview.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-showinfotip
		TVM_SHOWINFOTIP = TV_FIRST + 71,

		/// <summary>This message is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvm-getitempartrect
		TVM_GETITEMPARTRECT = TV_FIRST + 72,
	}

	/// <summary>Tree View Notifications</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "ff486107")]
	public enum TreeViewNotification
	{
		/// <summary>
		/// <para>
		/// Sent by a tree-view control to its parent when the drawing of a icon or overlay has failed. This notification code is sent in
		/// the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_ASYNCDRAW pnmTVAsynchDraw = (NMTVASYNCDRAW *) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTVASYNCDRAW</c> structure. The <c>NMTVASYNCDRAW</c> structure contains the reason the draw failed.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The tree-view control must have the <c>TVS_EX_DRAWIMAGEASYNC</c> extended style. Note that this is equivalent to list-view's
		/// LVN_ASYNCDRAWN flag and its corresponding style.
		/// </para>
		/// <para>
		/// This control does not draw asynchronously. Asynchronous is used in the context that the tree-view control does not
		/// synchronously extract an image if it is not available. (For instance, the image may not be available if the tree-view control
		/// uses a sparse image list, since the image may be unloaded.) Instead, when an image is not available, the control
		/// synchronously asks the parent what action to take by sending the parent an TVN_ASYNCDRAW notification with a
		/// <c>NMTVASYNCDRAW</c> structure. The <c>hr</c> member of this structure describes the reason the control's draw failed. An
		/// <c>hr</c> result of E_PENDING means the image is not present at all (the image needs to be extracted). Success indicates that
		/// the image is present but not at the required image quality.
		/// </para>
		/// <para>
		/// The parent sets the <c>dwRetFlags</c> member of the structure to inform the control how to proceed. For instance, the parent
		/// may return another image, in the <c>iRetImageIndex</c> member, for the control to draw. In this case, the parent sets the
		/// <c>dwRetFlags</c> member to ADRF_DRAWIMAGE. If the control finds the returned image has not been extracted, yet another
		/// TVN_ASYNCDRAW notification may be sent by the control.
		/// </para>
		/// <para>
		/// If an image is not available, the idea behind asynchronous is to allow the parent do the extraction in the background so that
		/// extraction does not block the UI thread, that is, the thread the control is on. The parent may return ADRF_DRAWNOTHING to the
		/// control, then launch a background thread to extract the icon. Once extracted, the parent may set the icon in the treeview
		/// control with macro <c>TreeView_SetItem</c>. This causes tree-view to invalidate the item and eventually repaint it with the
		/// extracted image in the image list.
		/// </para>
		/// <para>
		/// The following code example, to be used as part of a larger program, shows how a parent may process two possible return codes
		/// in this notification by a control, and decide what action the control should take. Setting <c>dwRetFlags</c> is not shown.
		/// </para>
		/// <para>
		/// <code>case TVN_ASYNCDRAW: NMTVASYNCDRAW *pnm = (NMTVASYNCDRAW *)lParam short dwDrawSuccessFlags = ShortFromResult(pnm-&gt;hr); if (dwDrawSuccessFlags &amp; ILDRF_IMAGELOWQUALITY) { // Need to re-extract the icon } if (dwDrawSuccessFlags &amp; ILDRF_OVERLAYLOWQUALITY) { // Need to re-extract the overlay }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-asyncdraw
		TVN_ASYNCDRAW = TVN_FIRST - 20,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that a drag-and-drop operation involving the left mouse button is being
		/// initiated. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_BEGINDRAG pnmtv = (LPNMTREEVIEW) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTREEVIEW</c> structure. The <c>itemNew</c> member is a <c>TVITEM</c> structure that contains valid
		/// information about the item being dragged in the <c>hItem</c>, <c>state</c>, and <c>lParam</c> members. The <c>ptDrag</c>
		/// member specifies the current screen coordinates of the mouse.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		/// <remarks>A tree-view control that has the <c>TVS_DISABLEDRAGDROP</c> style does not send this notification code.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-begindrag
		TVN_BEGINDRAG = TVN_FIRST - 56,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window about the start of label editing for an item. This notification code is sent in
		/// the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_BEGINLABELEDIT ptvdi = (LPNMTVDISPINFO) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTVDISPINFO</c> structure. The <c>item</c> member is a <c>TVITEM</c> structure that contains valid
		/// information about the item being edited in the <c>hItem</c>, <c>state</c>, <c>lParam</c>, and <c>pszText</c> members.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> to cancel label editing.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When label editing begins, an edit control is created but not positioned or displayed. Before it is displayed, the tree-view
		/// control sends its parent window a TVN_BEGINLABELEDIT notification code.
		/// </para>
		/// <para>
		/// To customize label editing, implement a handler for TVN_BEGINLABELEDIT and have it send a <c>TVM_GETEDITCONTROL</c> message
		/// to the tree-view control. If a label is being edited, the return value will be a handle to the edit control. Use this handle
		/// to customize the edit control by sending the usual EM_XXX messages.
		/// </para>
		/// <para>When the user cancels or completes the editing, the parent window receives a TVN_ENDLABELEDIT notification code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-beginlabeledit
		TVN_BEGINLABELEDIT = TVN_FIRST - 59,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window about the initiation of a drag-and-drop operation involving the right mouse
		/// button. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_BEGINRDRAG pnmtv = (LPNMTREEVIEW) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTREEVIEW</c> structure. The <c>itemNew</c> member is a <c>TVITEM</c> structure that contains valid
		/// information in the <c>hItem</c>, <c>state</c>, and <c>lParam</c> members about the item to be dragged. The <c>ptDrag</c>
		/// member specifies the current screen coordinates of the mouse.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-beginrdrag
		TVN_BEGINRDRAG = TVN_FIRST - 57,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that an item is being deleted. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_DELETEITEM pnmtv = (LPNMTREEVIEW) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTREEVIEW</c> structure. The <c>itemOld</c> member is a <c>TVITEM</c> structure whose <c>hItem</c> and
		/// <c>lParam</c> members contain valid information about the item being deleted.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		/// <remarks>
		/// If the <c>lParam</c> member of the <c>TVITEM</c> structure points to memory allocated by your application, you can free it
		/// when you receive the TVN_DELETEITEM notification code.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-deleteitem
		TVN_DELETEITEM = TVN_FIRST - 58,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window about the end of label editing for an item. This notification code is sent in
		/// the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_ENDLABELEDIT ptvdi = (LPNMTVDISPINFO) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTVDISPINFO</c> structure. The <c>item</c> member of this structure is a <c>TVITEM</c> structure whose
		/// <c>hItem</c>, <c>lParam</c>, and <c>pszText</c> members contain valid information about the item that was edited. If label
		/// editing was canceled, the <c>pszText</c> member of the <c>TVITEM</c> structure is <c>NULL</c>; otherwise, <c>pszText</c> is
		/// the address of the edited text.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the <c>pszText</c> member is non- <c>NULL</c>, return <c>TRUE</c> to set the item's label to the edited text. Return
		/// <c>FALSE</c> to reject the edited text and revert to the original label.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>If the <c>pszText</c> member is <c>NULL</c>, the return value is ignored.</para>
		/// <para>
		/// If you specified the LPSTR_TEXTCALLBACK value for this item and the <c>pszText</c> member is non- <c>NULL</c>, your
		/// TVN_ENDLABELEDIT handler should copy the text from <c>pszText</c> to your local storage.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-endlabeledit
		TVN_ENDLABELEDIT = TVN_FIRST - 60,

		/// <summary>
		/// <para>
		/// Requests that a tree-view control's parent window provide information needed to display or sort an item. This notification
		/// code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_GETDISPINFO lptvdi = (LPNMTVDISPINFO) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTVDISPINFO</c> structure. The <c>item</c> member is a <c>TVITEM</c> structure whose <c>mask</c>,
		/// <c>hItem</c>, <c>state</c>, and <c>lParam</c> members specify the type of information required. You must fill the members of
		/// the structure with the appropriate information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		/// <remarks>
		/// <para>This notification code is sent under the following circumstances:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the <c>pszText</c> member of the item's <c>TVITEM</c> structure is the LPSTR_TEXTCALLBACK value, the control sends this
		/// notification code to retrieve the item's text. In this case, the <c>mask</c> member of lParam will have the TVIF_TEXT flag set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the <c>iImage</c> or <c>iSelectedImage</c> member of the item's <c>TVITEM</c> structure is the I_IMAGECALLBACK value, the
		/// control sends this notification code to retrieve the index of an item's icons in the control's image list. In this case, if
		/// the item is selected, the <c>mask</c> member of lParam will have the TVIF_SELECTEDIMAGE flag set. If the item is not
		/// selected, the <c>mask</c> member of lParam will have the TVIF_IMAGE flag set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the <c>cChildren</c> member of the item's <c>TVITEM</c> structure is the I_CHILDRENCALLBACK value, the control sends this
		/// notification code to retrieve a value that indicates whether the item has child items. In this case, the <c>mask</c> member
		/// of lParam will have the TVIF_CHILDREN flag set.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-getdispinfo
		TVN_GETDISPINFO = TVN_FIRST - 52,

		/// <summary>
		/// <para>
		/// Sent by a tree-view control that has the <c>TVS_INFOTIP</c> style. This notification code is sent when the control is
		/// requesting additional text information to be displayed in a tooltip. The notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_GETINFOTIP lpGetInfoTip = (LPNMTVGETINFOTIP)lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTVGETINFOTIP</c> structure that contains information about this notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The control ignores the return value for this notification code.</para>
		/// </summary>
		/// <remarks>This notification code is only sent by tree-view controls that have the <c>TVS_INFOTIP</c> style.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-getinfotip
		TVN_GETINFOTIP = TVN_FIRST - 14,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that item attributes have changed. This notification code is sent in the form of
		/// a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_ITEMCHANGED pnm = (NMTVITEMCHANGE *) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>NMTVITEMCHANGE</c> structure describing the item that changed. The <c>uChanged</c> member is set to TVIF_STATE.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>FALSE</c> to accept the change, or <c>TRUE</c> to prevent the change.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-itemchanged
		TVN_ITEMCHANGED = TVN_FIRST - 19,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that item attributes are about to change. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_ITEMCHANGING pnm = (NMTVITEMCHANGE *) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTVITEMCHANGE</c> structure describing the item that is changing. The <c>uChanged</c> member is set to TVIF_STATE.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>FALSE</c> to accept the change, or <c>TRUE</c> to prevent the change.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-itemchanging
		TVN_ITEMCHANGING = TVN_FIRST - 17,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that a parent item's list of child items has expanded or collapsed. This
		/// notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_ITEMEXPANDED pnmtv = (LPNMTREEVIEW) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTREEVIEW</c> structure. The <c>itemNew</c> member is a <c>TVITEM</c> structure that contains valid
		/// information about the parent item in the <c>hItem</c>, <c>state</c>, and <c>lParam</c> members. The <c>action</c> member
		/// indicates whether the list expanded or collapsed. For a list of possible values, see the description of the <c>TVM_EXPAND</c> message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-itemexpanded
		TVN_ITEMEXPANDED = TVN_FIRST - 55,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that a parent item's list of child items is about to expand or collapse. This
		/// notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_ITEMEXPANDING pnmtv = (LPNMTREEVIEW) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTREEVIEW</c> structure. The <c>itemNew</c> member is a <c>TVITEM</c> structure that contains valid
		/// information about the parent item in the <c>hItem</c>, <c>state</c>, and <c>lParam</c> members. The <c>action</c> member
		/// indicates whether the list is to expand or collapse. For a list of possible values, see the description of the
		/// <c>TVM_EXPAND</c> message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> to prevent the list from expanding or collapsing.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-itemexpanding
		TVN_ITEMEXPANDING = TVN_FIRST - 54,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that the user pressed a key and the tree-view control has the input focus. This
		/// notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_KEYDOWN ptvkd = (LPNMTVKEYDOWN) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTVKEYDOWN</c> structure. The <c>wVKey</c> member specifies the virtual key code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the <c>wVKey</c> member of lParam is a character key code, the character will be used as part of an incremental search.
		/// Return nonzero to exclude the character from the incremental search, or zero to include the character in the search. For all
		/// other keys, the return value is ignored.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-keydown
		TVN_KEYDOWN = TVN_FIRST - 12,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that the selection has changed from one item to another. This notification code
		/// is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_SELCHANGED pnmtv = (LPNMTREEVIEW) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTREEVIEW</c> structure. The <c>itemOld</c> and <c>itemNew</c> members of the <c>NMTREEVIEW</c> structure
		/// are <c>TVITEM</c> structures that contain information about the previously selected item and the newly selected item. Only
		/// the <c>mask</c>, <c>hItem</c>, <c>state</c>, and <c>lParam</c> members of these structures are valid. The <c>stateMask</c>
		/// members of the <c>TVITEM</c> structures specified by <c>itemOld</c> and <c>itemNew</c> are undefined on input. The
		/// <c>action</c> member of the <c>NMTREEVIEW</c> structure indicates the type of action that caused the selection to change. It
		/// can be one of the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Requirement</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>TVC_BYKEYBOARD</term>
		/// <term>By a keystroke.</term>
		/// </item>
		/// <item>
		/// <term>TVC_BYMOUSE</term>
		/// <term>By a mouse click.</term>
		/// </item>
		/// <item>
		/// <term>TVC_UNKNOWN</term>
		/// <term>Unknown.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-selchanged
		TVN_SELCHANGED = TVN_FIRST - 51,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that the selection is about to change from one item to another. This
		/// notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_SELCHANGING pnmtv = (LPNMTREEVIEW) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTREEVIEW</c> structure. The <c>itemOld</c> and <c>itemNew</c> members contain valid information about the
		/// currently selected item and the newly selected item. The <c>action</c> member indicates whether a mouse or keyboard action is
		/// causing the selection to change. For a list of possible values, see the description of the TVN_SELCHANGED notification code.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> to prevent the selection from changing.</para>
		/// </summary>
		/// <remarks>
		/// When responding to this notification code, applications should not delete the items that are gaining or losing the selection.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-selchanging
		TVN_SELCHANGING = TVN_FIRST - 50,

		/// <summary>
		/// <para>
		/// Notifies a tree-view control's parent window that it must update the information it maintains about an item. This
		/// notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_SETDISPINFO lptvdi = (LPNMTVDISPINFO) lParam</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTVDISPINFO</c> structure that describes the item being updated. The <c>hItem</c> member of the
		/// <c>TVITEM</c> structure specifies the item being updated, and the <c>mask</c> member specifies which attributes of the item
		/// are being updated.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the <c>pszText</c> member of the item's <c>TVITEM</c> structure is the LPSTR_TEXTCALLBACK value, the control sends this
		/// notification to set the item's text. In this case, the <c>mask</c> member of lParam will have the TVIF_TEXT flag set.
		/// </para>
		/// <para>
		/// If the <c>iImage</c> or <c>iSelectedImage</c> member of the item's <c>TVITEM</c> structure is the I_IMAGECALLBACK value, the
		/// control sends this notification to retrieve the index of the icon image to display. In this case, the <c>mask</c> member of
		/// lParam will have the TVIF_IMAGE or TVIF_SELECTEDIMAGE flag set.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-setdispinfo
		TVN_SETDISPINFO = TVN_FIRST - 53,

		/// <summary>
		/// <para>
		/// Sent by a tree-view control with the <c>TVS_SINGLEEXPAND</c> style when the user opens or closes a tree item using a single
		/// click of the mouse. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TVN_SINGLEEXPAND lpnmtv = (LPNMTREEVIEW)lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTREEVIEW</c> structure that contains information about this notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return TVNRET_DEFAULT to allow the default behavior to occur. To modify the default behavior, return:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>TVNRET_SKIPOLD</c></term>
		/// <term>Skip default processing of the item being unselected.</term>
		/// </item>
		/// <item>
		/// <term><c>TVNRET_SKIPNEW</c></term>
		/// <term>Skip default processing of the item being selected.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To skip default processing of selected and unselected items, return both TVNRET_SKIPOLD and TVNRET_SKIPNEW by combining them
		/// with a logical OR.
		/// </para>
		/// <para>This notification code is only sent by tree-view controls that have the <c>TVS_SINGLEEXPAND</c> style.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tvn-singleexpand
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
		/// <summary>
		/// Indicates the normal image list, which contains selected, nonselected, and overlay images for the items of a tree-view control.
		/// </summary>
		TVSIL_NORMAL = 0,

		/// <summary>
		/// Indicates the state image list. You can use state images to indicate application-defined item states. A state image is
		/// displayed to the left of an item's selected or nonselected image.
		/// </summary>
		TVSIL_STATE = 2
	}

	/// <summary>Window styles used when creating tree-view controls.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760013")]
	[Flags]
	public enum TreeViewStyle
	{
		/// <summary>
		/// Version 4.70. Enables check boxes for items in a tree-view control. A check box is displayed only if an image is associated
		/// with the item. When set to this style, the control effectively uses DrawFrameControl to create and set a state image list
		/// containing two images. State image 1 is the unchecked box and state image 2 is the checked box. Setting the state image to
		/// zero removes the check box altogether. For more information, see Working with state image indexes.
		/// <para>Version 5.80. Displays a check box even if no image is associated with the item.</para>
		/// <para>
		/// Once a tree-view control is created with this style, the style cannot be removed. Instead, you must destroy the control and
		/// create a new one in its place. Destroying the tree-view control does not destroy the check box state image list. You must
		/// destroy it explicitly. Get the handle to the state image list by sending the tree-view control a TVM_GETIMAGELIST message.
		/// Then destroy the image list with ImageList_Destroy.
		/// </para>
		/// <para>
		/// If you want to use this style, you must set the TVS_CHECKBOXES style with SetWindowLong after you create the treeview
		/// control, and before you populate the tree. Otherwise, the checkboxes might appear unchecked, depending on timing issues.
		/// </para>
		/// </summary>
		TVS_CHECKBOXES = 0x0100,

		/// <summary>Prevents the tree-view control from sending TVN_BEGINDRAG notification codes.</summary>
		TVS_DISABLEDRAGDROP = 0x0010,

		/// <summary>Allows the user to edit the labels of tree-view items.</summary>
		TVS_EDITLABELS = 0x0008,

		/// <summary>
		/// Version 4.71. Enables full-row selection in the tree view. The entire row of the selected item is highlighted, and clicking
		/// anywhere on an item's row causes it to be selected. This style cannot be used in conjunction with the TVS_HASLINES style.
		/// </summary>
		TVS_FULLROWSELECT = 0x1000,

		/// <summary>
		/// Displays plus (+) and minus (-) buttons next to parent items. The user clicks the buttons to expand or collapse a parent
		/// item's list of child items. To include buttons with items at the root of the tree view, TVS_LINESATROOT must also be specified.
		/// </summary>
		TVS_HASBUTTONS = 0x0001,

		/// <summary>Uses lines to show the hierarchy of items.</summary>
		TVS_HASLINES = 0x0002,

		/// <summary>Version 4.71. Obtains tooltip information by sending the TVN_GETINFOTIP notification.</summary>
		TVS_INFOTIP = 0x0800,

		/// <summary>
		/// Uses lines to link items at the root of the tree-view control. This value is ignored if TVS_HASLINES is not also specified.
		/// </summary>
		TVS_LINESATROOT = 0x0004,

		/// <summary>
		/// Version 5.80. Disables horizontal scrolling in the control. The control will not display any horizontal scroll bars.
		/// </summary>
		TVS_NOHSCROLL = 0x8000,

		/// <summary>
		/// Version 4.71 Sets the height of the items to an odd height with the TVM_SETITEMHEIGHT message. By default, the height of
		/// items must be an even value.
		/// </summary>
		TVS_NONEVENHEIGHT = 0x4000,

		/// <summary>
		/// Version 4.71. Disables both horizontal and vertical scrolling in the control. The control will not display any scroll bars.
		/// </summary>
		TVS_NOSCROLL = 0x2000,

		/// <summary>Version 4.70. Disables tooltips.</summary>
		TVS_NOTOOLTIPS = 0x0080,

		/// <summary>
		/// Version 4.70. Causes text to be displayed from right-to-left (RTL). Usually, windows display text left-to-right (LTR).
		/// Windows can be mirrored to display languages such as Hebrew or Arabic that read RTL. Typically, tree-view text is displayed
		/// in the same direction as the text in its parent window. If TVS_RTLREADING is set, tree-view text reads in the opposite
		/// direction from the text in the parent window.
		/// </summary>
		TVS_RTLREADING = 0x0040,

		/// <summary>Causes a selected item to remain selected when the tree-view control loses focus.</summary>
		TVS_SHOWSELALWAYS = 0x0020,

		/// <summary>
		/// Version 4.71. Causes the item being selected to expand and the item being unselected to collapse upon selection in the tree
		/// view. If the mouse is used to single-click the selected item and that item is closed, it will be expanded. If the user holds
		/// down the CTRL key while selecting an item, the item being unselected will not be collapsed.
		/// <para>
		/// Version 5.80. Causes the item being selected to expand and the item being unselected to collapse upon selection in the tree
		/// view. If the user holds down the CTRL key while selecting an item, the item being unselected will not be collapsed.
		/// </para>
		/// </summary>
		TVS_SINGLEEXPAND = 0x0400,

		/// <summary>Version 4.70. Enables hot tracking in a tree-view control.</summary>
		TVS_TRACKSELECT = 0x0200,
	}

	/// <summary>
	/// Extended styles used when creating tree-view controls. The value of extended styles is a bitwise combination of these styles.
	/// </summary>
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

		/// <summary>
		/// Windows Vista. Fade expando buttons in or out when the mouse moves away or into a state of hovering over the control.
		/// </summary>
		TVS_EX_FADEINOUTEXPANDOS = 0x0040,

		/// <summary>Not supported. Do not use.</summary>
		TVS_EX_MULTISELECT = 0x0002,

		/// <summary>Windows Vista. Do not indent the tree view for the expando buttons.</summary>
		TVS_EX_NOINDENTSTATE = 0x0008,

		/// <summary>
		/// Windows Vista. Intended for internal use; not recommended for use in applications. Do not collapse the previously selected
		/// tree-view item unless it has the same parent as the new selection. This style must be used with the TVS_SINGLEEXPAND style.
		/// <note>This style may not be supported in future versions of Comctl32.dll. Also, this style is not defined in commctrl.h.</note>
		/// </summary>
		TVS_EX_NOSINGLECOLLAPSE = 0x0001,

		/// <summary>Windows Vista. Include partial checkbox state if the control has the TVS_CHECKBOXES style.</summary>
		TVS_EX_PARTIALCHECKBOXES = 0x0080,

		/// <summary>Windows Vista. Allow rich tooltips in the tree view (custom drawn with icon and text).</summary>
		TVS_EX_RICHTOOLTIP = 0x0010,
	}

	/// <summary>Tree view button item part.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773442")]
	public enum TVITEMPART
	{
		/// <summary>Button item part.</summary>
		TVGIPR_BUTTON = 0x0001,
	}

	/// <summary>Provides a handle to a tree view item.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HTREEITEM
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HTREEITEM"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HTREEITEM(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HTREEITEM"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HTREEITEM NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HTREEITEM"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HTREEITEM h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTREEITEM"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTREEITEM(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HTREEITEM h1, HTREEITEM h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HTREEITEM h1, HTREEITEM h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HTREEITEM h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();
	}

	/// <summary>
	/// Contains information about a tree-view notification message. This structure is identical to the NM_TREEVIEW structure, but it has
	/// been renamed to follow current naming conventions.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773411")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NMTREEVIEW : INotificationInfo
	{
		/// <summary>NMHDR structure that contains information about this notification message.</summary>
		public NMHDR hdr;

		/// <summary>
		/// Notification-specific action flag. This member is used with the following notification codes: TVN_ITEMEXPANDING,
		/// TVN_ITEMEXPANDED, TVN_SELCHANGING, TVN_SELCHANGED. For the possible action flag values, see TVM_EXPAND and TVN_SELCHANGED.
		/// </summary>
		public int action;

		/// <summary>
		/// TVITEM structure that contains information about the old item state. This member is zero for notification messages that do
		/// not use it.
		/// </summary>
		public TVITEM itemOld;

		/// <summary>
		/// TVITEM structure that contains information about the new item state. This member is zero for notification messages that do
		/// not use it.
		/// </summary>
		public TVITEM itemNew;

		/// <summary>
		/// POINT structure that contains the client coordinates of the mouse at the time the event occurred that caused the notification
		/// message to be sent.
		/// </summary>
		public POINT ptDrag;
	}

	/// <summary>
	/// Contains an explanation of why the draw of an icon or overlay tree item failed. This structure is sent on a TVN_ASYNCDRAW
	/// notification. Set the dwRetFlags member to indicate what action the control should take. Note that a draw can fail if there is no
	/// image; in other words, when the icon image has not been extracted.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773413")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMTVASYNCDRAW : INotificationInfo
	{
		/// <summary>NMHDR structure.</summary>
		public NMHDR hdr;

		/// <summary>IMAGELISTDRAWPARAMS structure describing the image that failed to draw.</summary>
		public IMAGELISTDRAWPARAMS pimldp;

		/// <summary>
		/// Result code indicating why the draw failed, either ILDRF_IMAGELOWQUALITY, ILDRF_OVERLAYLOWQUALITY, E_PENDING, or S_OK. A code
		/// of S_OK indicates that the image is present but not at the required image quality.
		/// </summary>
		public HRESULT hr;

		/// <summary>Handle of the tree item that failed to draw.</summary>
		public HTREEITEM hItem;

		/// <summary>
		/// Data for hItem. This is the same data for the item that is retrieved with the message TVM_GETITEM using the appropriate mask
		/// in structure TVITEM. This data is parent specific; the parent can store information that helps it identify the tree item or
		/// other information. Data is provided in lParam for convenience, so that the parent does not need to send message TVM_GETITEM.
		/// </summary>
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

		/// <summary>
		/// Version 4.71. Zero-based level of the item being drawn. The root item is at level zero, a child of the root item is at level
		/// one, and so on.
		/// </summary>
		public int iLevel;
	}

	/// <summary>
	/// Contains and receives display information for a tree-view item. This structure is identical to the TV_DISPINFO structure, but it
	/// has been renamed to follow current naming conventions.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773418")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NMTVDISPINFO : INotificationInfo
	{
		/// <summary>NMHDR structure that contains information about this notification.</summary>
		public NMHDR hdr;

		/// <summary>
		/// TVITEM structure that identifies and contains information about the tree-view item. The mask member of the TVITEM structure
		/// specifies which information is being set or retrieved.
		/// </summary>
		public TVITEM item;
	}

	/// <summary>Contains information pertaining to extended TreeView notification information.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760143")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NMTVDISPINFOEX : INotificationInfo
	{
		/// <summary>NMHDR structure that contains information about this notification.</summary>
		public NMHDR hdr;

		/// <summary>Specifies or receives attributes of a TreeView item.</summary>
		public TVITEMEX item;
	}

	/// <summary>
	/// Contains and receives tree-view item information needed to display a tooltip for an item. This structure is used with the
	/// TVN_GETINFOTIP notification code.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773421")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct NMTVGETINFOTIP : INotificationInfo
	{
		/// <summary>NMHDR structure that contains information about this notification.</summary>
		public NMHDR hdr;

		/// <summary>
		/// Address of a character buffer that contains the text to be displayed. If you want to change the text displayed in the
		/// tooltip, you will need to modify the contents of this buffer. The size of this buffer is specified by the cchTextMax structure.
		/// </summary>
		public StrPtrAuto pszText;

		/// <summary>
		/// Size of the buffer at pszText, in characters. Although you should never assume that this buffer will be of any particular
		/// size, the INFOTIPSIZE value can be used for design purposes.
		/// </summary>
		public int cchTextMax;

		/// <summary>Tree handle to the item for which the tooltip is being displayed.</summary>
		public HTREEITEM hItem;

		/// <summary>Application-defined data associated with the item for which the tooltip is being displayed.</summary>
		public IntPtr lParam;
	}

	/// <summary>
	/// Contains information on a tree-view item change. This structure is sent with the TVN_ITEMCHANGED and TVN_ITEMCHANGING notifications.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773425")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct NMTVITEMCHANGE : INotificationInfo
	{
		/// <summary>NMHDR structure that contains information about the notification.</summary>
		public NMHDR hdr;

		/// <summary>
		/// Specifies the attribute. The only supported attribute is state. uChanged must have the following value: TVIF_STATE = The
		/// change is the state attribute.
		/// </summary>
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
	/// Contains information about a keyboard event in a tree-view control. This structure is used with the TVN_KEYDOWN notification
	/// code. The structure is identical to the TV_KEYDOWN structure, but it has been renamed to follow current naming conventions.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773433")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMTVKEYDOWN : INotificationInfo
	{
		/// <summary>NMHDR structure that contains information about this notification.</summary>
		public NMHDR hdr;

		/// <summary>Virtual key code.</summary>
		public ushort wVKey;

		/// <summary>Always zero.</summary>
		public uint flags;
	}

	/// <summary>
	/// Contains information used to determine the location of a point relative to a tree-view control. This structure is used with the
	/// TVM_HITTEST message. The structure is identical to the TV_HITTESTINFO structure, but it has been renamed to follow current naming conventions.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773448")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TVHITTESTINFO
	{
		/// <summary>Client coordinates of the point to test.</summary>
		public POINT pt;

		/// <summary>Variable that receives information about the results of a hit test.</summary>
		public TreeViewHitTestFlags flags;

		/// <summary>Handle to the item that occupies the point.</summary>
		public HTREEITEM hItem;
	}

	/// <summary>
	/// Contains information used to add a new item to a tree-view control. This structure is used with the TVM_INSERTITEM message. The
	/// structure is identical to the TV_INSERTSTRUCT structure, but it has been renamed to follow current naming conventions.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773452")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TVINSERTSTRUCT
	{
		/// <summary>
		/// Handle to the parent item. If this member is the TVI_ROOT value or NULL, the item is inserted at the root of the tree-view control.
		/// </summary>
		public HTREEITEM hParent;

		/// <summary>Handle to the item after which the new item is to be inserted, or one of the following values:</summary>
		public HTREEITEM hInsertAfter;

		/// <summary>Version 4.71. TVITEMEX structure that contains information about the item to add.</summary>
		public TVITEMEX itemex;
	}

	/// <summary>
	/// Specifies or receives attributes of a tree-view item. This structure is identical to the TV_ITEM structure, but it has been
	/// renamed to follow current naming conventions. New applications should use this structure.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773456")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TVITEM
	{
		/// <summary>
		/// Array of flags that indicate which of the other structure members contain valid data. When this structure is used with the
		/// TVM_GETITEM message, the mask member indicates the item attributes to retrieve. If used with the TVM_SETITEM message, the
		/// mask indicates the attributes to set.
		/// </summary>
		public TreeViewItemMask mask;

		/// <summary>Handle to the item.</summary>
		public HTREEITEM hItem;

		/// <summary>
		/// Set of bit flags and image list indexes that indicate the item's state. When setting the state of an item, the stateMask
		/// member indicates the valid bits of this member. When retrieving the state of an item, this member returns the current state
		/// for the bits indicated in the stateMask member.
		/// </summary>
		public uint state;

		/// <summary>
		/// Bits of the state member that are valid. If you are retrieving an item's state, set the bits of the stateMask member to
		/// indicate the bits to be returned in the state member. If you are setting an item's state, set the bits of the stateMask
		/// member to indicate the bits of the state member that you want to set. To set or retrieve an item's overlay image index, set
		/// the TVIS_OVERLAYMASK bits. To set or retrieve an item's state image index, set the TVIS_STATEIMAGEMASK bits.
		/// </summary>
		public TreeViewItemStates stateMask;

		/// <summary>
		/// Pointer to a null-terminated string that contains the item text if the structure specifies item attributes. If this member is
		/// the LPSTR_TEXTCALLBACK value, the parent window is responsible for storing the name. In this case, the tree-view control
		/// sends the parent window a TVN_GETDISPINFO notification code when it needs the item text for displaying, sorting, or editing
		/// and a TVN_SETDISPINFO notification code when the item text changes. If the structure is receiving item attributes, this
		/// member is the address of the buffer that receives the item text. Note that although the tree-view control allows any length
		/// string to be stored as item text, only the first 260 characters are displayed.
		/// </summary>
		public IntPtr pszText;

		/// <summary>
		/// Size of the buffer pointed to by the pszText member, in characters. If this structure is being used to set item attributes,
		/// this member is ignored.
		/// </summary>
		public int cchTextMax;

		/// <summary>
		/// Index in the tree-view control's image list of the icon image to use when the item is in the nonselected state. If this
		/// member is the I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the tree-view
		/// control sends the parent a TVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.
		/// </summary>
		public int iImage;

		/// <summary>
		/// Index in the tree-view control's image list of the icon image to use when the item is in the selected state. If this member
		/// is the I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the tree-view control
		/// sends the parent a TVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.
		/// </summary>
		public int iSelectedImage;

		/// <summary>
		/// Flag that indicates whether the item has associated child items. This member can be one of the following values.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>zero</term>
		/// <description>The item has no child items.</description>
		/// </item>
		/// <item>
		/// <term>one</term>
		/// <description>The item has one or more child items.</description>
		/// </item>
		/// <item>
		/// <term>I_CHILDRENCALLBACK</term>
		/// <description>
		/// The parent window keeps track of whether the item has child items.In this case, when the tree-view control needs to display
		/// the item, the control sends the parent a TVN_GETDISPINFO notification code to determine whether the item has child items.
		/// <para>
		/// If the tree-view control has the TVS_HASBUTTONS style, it uses this member to determine whether to display the button
		/// indicating the presence of child items. You can use this member to force the control to display the button even though the
		/// item does not have any child items inserted. This allows you to display the button while minimizing the control's memory
		/// usage by inserting child items only when the item is visible or expanded.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>I_CHILDRENAUTO</term>
		/// <description>
		/// Version 6.0 Intended for internal use; not recommended for use in applications.The tree-view control automatically determines
		/// whether the item has child items. <note>This flag may not be supported in future versions of Comctl32.dll.Also, this flag is
		/// not defined in commctrl.h.Add the following definition to the source files of your application to use the flag:</note>
		/// <code>
		/// #define I_CHILDRENAUTO (-2)
		/// </code>
		/// </description>
		/// </item>
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

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => $"TVITEM: pszText={Text}; iImage={iImage}; iSelectedImage={iSelectedImage}; state={state}; cChildren={cChildren}";
	}

	/// <summary>
	/// Specifies or receives attributes of a tree-view item. This structure is an enhancement to the TVITEM structure. New applications
	/// should use this structure where appropriate.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773459")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TVITEMEX
	{
		/// <summary>
		/// Array of flags that indicate which of the other structure members contain valid data. When this structure is used with the
		/// TVM_GETITEM message, the mask member indicates the item attributes to retrieve. If used with the TVM_SETITEM message, the
		/// mask indicates the attributes to set.
		/// </summary>
		public TreeViewItemMask mask;

		/// <summary>Handle to the item.</summary>
		public HTREEITEM hItem;

		/// <summary>
		/// Set of bit flags and image list indexes that indicate the item's state. When setting the state of an item, the stateMask
		/// member indicates the valid bits of this member. When retrieving the state of an item, this member returns the current state
		/// for the bits indicated in the stateMask member.
		/// </summary>
		public uint state;

		/// <summary>
		/// Bits of the state member that are valid. If you are retrieving an item's state, set the bits of the stateMask member to
		/// indicate the bits to be returned in the state member. If you are setting an item's state, set the bits of the stateMask
		/// member to indicate the bits of the state member that you want to set. To set or retrieve an item's overlay image index, set
		/// the TVIS_OVERLAYMASK bits. To set or retrieve an item's state image index, set the TVIS_STATEIMAGEMASK bits.
		/// </summary>
		public TreeViewItemStates stateMask;

		/// <summary>
		/// Pointer to a null-terminated string that contains the item text if the structure specifies item attributes. If this member is
		/// the LPSTR_TEXTCALLBACK value, the parent window is responsible for storing the name. In this case, the tree-view control
		/// sends the parent window a TVN_GETDISPINFO notification code when it needs the item text for displaying, sorting, or editing
		/// and a TVN_SETDISPINFO notification code when the item text changes. If the structure is receiving item attributes, this
		/// member is the address of the buffer that receives the item text. Note that although the tree-view control allows any length
		/// string to be stored as item text, only the first 260 characters are displayed.
		/// </summary>
		public StrPtrAuto pszText;

		/// <summary>
		/// Size of the buffer pointed to by the pszText member, in characters. If this structure is being used to set item attributes,
		/// this member is ignored.
		/// </summary>
		public int cchTextMax;

		/// <summary>
		/// Index in the tree-view control's image list of the icon image to use when the item is in the nonselected state. If this
		/// member is the I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the tree-view
		/// control sends the parent a TVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.
		/// </summary>
		public int iImage;

		/// <summary>
		/// Index in the tree-view control's image list of the icon image to use when the item is in the selected state. If this member
		/// is the I_IMAGECALLBACK value, the parent window is responsible for storing the index. In this case, the tree-view control
		/// sends the parent a TVN_GETDISPINFO notification code to retrieve the index when it needs to display the image.
		/// </summary>
		public int iSelectedImage;

		/// <summary>
		/// Flag that indicates whether the item has associated child items. This member can be one of the following values.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>zero</term>
		/// <description>The item has no child items.</description>
		/// </item>
		/// <item>
		/// <term>one</term>
		/// <description>The item has one or more child items.</description>
		/// </item>
		/// <item>
		/// <term>I_CHILDRENCALLBACK</term>
		/// <description>
		/// The parent window keeps track of whether the item has child items.In this case, when the tree-view control needs to display
		/// the item, the control sends the parent a TVN_GETDISPINFO notification code to determine whether the item has child items.
		/// <para>
		/// If the tree-view control has the TVS_HASBUTTONS style, it uses this member to determine whether to display the button
		/// indicating the presence of child items. You can use this member to force the control to display the button even though the
		/// item does not have any child items inserted. This allows you to display the button while minimizing the control's memory
		/// usage by inserting child items only when the item is visible or expanded.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>I_CHILDRENAUTO</term>
		/// <description>
		/// Version 6.0 Intended for internal use; not recommended for use in applications.The tree-view control automatically determines
		/// whether the item has child items. <note>This flag may not be supported in future versions of Comctl32.dll.Also, this flag is
		/// not defined in commctrl.h.Add the following definition to the source files of your application to use the flag:</note>
		/// <code>
		/// #define I_CHILDRENAUTO (-2)
		/// </code>
		/// </description>
		/// </item>
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
		public HWND hwnd;

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
			get => GetState(TreeViewItemStates.TVIS_DROPHILITED);
			set => SetState(TreeViewItemStates.TVIS_DROPHILITED, value);
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
		public string Text => (IntPtr)pszText == LPSTR_TEXTCALLBACK ? null : pszText.ToString();

		/// <summary>Gets or sets a value indicating whether to use text callback.</summary>
		/// <value><c>true</c> if to use text callback; otherwise, <c>false</c>.</value>
		public bool UseTextCallback
		{
			get => (IntPtr)pszText == LPSTR_TEXTCALLBACK;
			set
			{
				if (value)
					pszText.AssignConstant(-1);
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
			pszText.Assign(managedStringPtr);
			cchTextMax = stringLen;
			mask |= TreeViewItemMask.TVIF_TEXT;
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => $"TVITEM: pszText={Text}; iImage={iImage}; iSelectedImage={iSelectedImage}; state={state}; iExpandedImage={iExpandedImage}; iIntegral={iIntegral}; cChildren={cChildren}";
	}

	/// <summary>
	/// Contains information used to sort child items in a tree-view control. This structure is used with the TVM_SORTCHILDRENCB message.
	/// This structure is identical to the TV_SORTCB structure, but it has been renamed to follow current naming conventions.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773462")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TVSORTCB
	{
		/// <summary>Handle to the parent item.</summary>
		public HTREEITEM hParent;

		/// <summary>
		/// Address of an application-defined callback function, which is called during a sort operation each time the relative order of
		/// two list items needs to be compared.
		/// </summary>
		public PFNTVCOMPARE lpfnCompare;

		/// <summary>
		/// Application-defined value that gets passed as the lParamSort argument in the callback function specified in lpfnCompare.
		/// </summary>
		public IntPtr lParam;
	}

	/// <summary>
	/// Contains information for identifying the "hit zone" for a specified part of a tree item. The structure is used with the
	/// TVM_GETITEMPARTRECT message and the TreeView_GetItemPartRect macro.
	/// </summary>
	/// <seealso cref="System.IDisposable"/>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb773442")]
	[StructLayout(LayoutKind.Sequential)]
	public sealed class TVGETITEMPARTRECTINFO : IDisposable
	{
		/// <summary>Handle to the parent item.</summary>
		public HTREEITEM hti;

		/// <summary>
		/// Pointer to a RECT structure to receive the coordinates of the bounding rectangle. The sender of the message (the caller) is
		/// responsible for allocating this structure.
		/// </summary>
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
		public RECT Bounds => prc.ToStructure<RECT>();

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose() => Marshal.FreeCoTaskMem(prc);
	}
}