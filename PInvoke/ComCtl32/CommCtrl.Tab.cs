using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary/>
	public const int TCM_FIRST = 0x1300;

	/// <summary/>
	public const int TCN_FIRST = -550;

	/// <summary>Variable that receives the results of a hit test.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
	[Flags]
	public enum TabControlHitTestFlags
	{
		/// <summary>The position is not over a tab.</summary>
		TCHT_NOWHERE = 0x0001,

		/// <summary>The position is over a tab's icon.</summary>
		TCHT_ONITEMICON = 0x0002,

		/// <summary>The position is over a tab's text.</summary>
		TCHT_ONITEMLABEL = 0x0004,

		/// <summary>
		/// The position is over a tab but not over its icon or its text. For owner-drawn tab controls, this value is specified if the
		/// position is anywhere over a tab.
		/// </summary>
		TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL,
	}

	/// <summary>Value that specifies which members of TCITEM to retrieve or set.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760554")]
	[Flags]
	public enum TabControlItemMask
	{
		/// <summary>The pszText member is valid.</summary>
		TCIF_TEXT = 0x0001,

		/// <summary>The iImage member is valid.</summary>
		TCIF_IMAGE = 0x0002,

		/// <summary>The string pointed to by pszText will be displayed in the direction opposite to the text in the parent window.</summary>
		TCIF_RTLREADING = 0x0004,

		/// <summary>The lParam member is valid.</summary>
		TCIF_PARAM = 0x0008,

		/// <summary>Version 4.70. The dwState member is valid.</summary>
		TCIF_STATE = 0x0010,

		/// <summary>All members are valid.</summary>
		TCIF_ALL = 0x001B,
	}

	/// <summary>
	/// Tab control items now support an item state to support the TCM_DESELECTALL message. Additionally, the TCITEM structure supports
	/// item state values.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760547")]
	[Flags]
	public enum TabControlItemStates
	{
		/// <summary>
		/// Version 4.70. The tab control item is selected. This state is only meaningful if the TCS_BUTTONS style flag has been set.
		/// </summary>
		TCIS_BUTTONPRESSED = 0x0001,

		/// <summary>
		/// Version 4.71. The tab control item is highlighted, and the tab and text are drawn using the current highlight color. When
		/// using high-color, this will be a true interpolation, not a dithered color.
		/// </summary>
		TCIS_HIGHLIGHTED = 0x0002,

		/// <summary>Look at all states.</summary>
		TCIS_ALL
	}

	/// <summary>Tab Control Messages</summary>
	// https://docs.microsoft.com/en-us/windows/win32/controls/bumper-tab-control-reference-messages
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
	public enum TabControlMessage
	{
		/// <summary>
		/// Retrieves the image list associated with a tab control. You can send this message explicitly or by using the
		/// <c>TabCtrl_GetImageList</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the image list if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-getimagelist
		[MsgParams(LResultType = typeof(HIMAGELIST))]
		TCM_GETIMAGELIST = TCM_FIRST + 2,

		/// <summary>
		/// Assigns an image list to a tab control. You can send this message explicitly or by using the <c>TabCtrl_SetImageList</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the image list to assign to the tab control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the previous image list, or <c>NULL</c> if there is no previous image list.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-setimagelist
		[MsgParams(null, typeof(HIMAGELIST), LResultType = typeof(HIMAGELIST))]
		TCM_SETIMAGELIST = TCM_FIRST + 3,

		/// <summary>
		/// Retrieves the number of tabs in the tab control. You can send this message explicitly or by using the
		/// <c>TabCtrl_GetItemCount</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the number of items if successful, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-getitemcount
		[MsgParams()]
		TCM_GETITEMCOUNT = TCM_FIRST + 4,

		/// <summary>
		/// Retrieves information about a tab in a tab control. You can send this message explicitly or by using the
		/// <c>TabCtrl_GetItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the tab.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TCITEM</c> structure that specifies the information to retrieve and receives information about the tab. When
		/// the message is sent, the <c>mask</c> member specifies which attributes to return. If the <c>mask</c> member specifies the
		/// TCIF_TEXT value, the <c>pszText</c> member must contain the address of the buffer that receives the item text, and the
		/// <c>cchTextMax</c> member must specify the size of the buffer.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// If the TCIF_TEXT flag is set in the <c>mask</c> member of the <c>TCITEM</c> structure, the control may change the
		/// <c>pszText</c> member of the structure to point to the new text instead of filling the buffer with the requested text. The
		/// control may set the <c>pszText</c> member to <c>NULL</c> to indicate that no text is associated with the item.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-getitem
		[MsgParams(typeof(int), typeof(TCITEM), LResultType = typeof(BOOL))]
		TCM_GETITEM = TCM_FIRST + 60,

		/// <summary>
		/// Sets some or all of a tab's attributes. You can send this message explicitly or by using the <c>TabCtrl_SetItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TCITEM</c> structure that contains the new item attributes. The <c>mask</c> member specifies which attributes
		/// to set. If the <c>mask</c> member specifies the TCIF_TEXT value, the <c>pszText</c> member is the address of a
		/// null-terminated string and the <c>cchTextMax</c> member is ignored.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-setitem
		[MsgParams(typeof(int), typeof(TCITEM), LResultType = typeof(BOOL))]
		TCM_SETITEM = TCM_FIRST + 61,

		/// <summary>
		/// Inserts a new tab in a tab control. You can send this message explicitly or by using the <c>TabCtrl_InsertItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the new tab.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TCITEM</c> structure that specifies the attributes of the tab. The <c>dwState</c> and <c>dwStateMask</c>
		/// members of this structure are ignored by this message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the new tab if successful, or -1 otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-insertitem
		[MsgParams(typeof(int), typeof(TCITEM))]
		TCM_INSERTITEM = TCM_FIRST + 62,

		/// <summary>
		/// Removes an item from a tab control. You can send this message explicitly or by using the <c>TabCtrl_DeleteItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the item to delete.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-deleteitem
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TCM_DELETEITEM = TCM_FIRST + 8,

		/// <summary>
		/// Removes all items from a tab control. You can send this message explicitly or by using the <c>TabCtrl_DeleteAllItems</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-deleteallitems
		[MsgParams(LResultType = typeof(BOOL))]
		TCM_DELETEALLITEMS = TCM_FIRST + 9,

		/// <summary>
		/// Retrieves the bounding rectangle for a tab in a tab control. You can send this message explicitly or by using the
		/// <c>TabCtrl_GetItemRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the tab.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>RECT</c> structure that receives the bounding rectangle of the tab, in viewport coordinates.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-getitemrect
		[MsgParams(typeof(int), typeof(RECT?), LResultType = typeof(BOOL))]
		TCM_GETITEMRECT = TCM_FIRST + 10,

		/// <summary>
		/// Determines the currently selected tab in a tab control. You can send this message explicitly or by using the
		/// <c>TabCtrl_GetCurSel</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the selected tab if successful, or -1 if no tab is selected.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-getcursel
		[MsgParams()]
		TCM_GETCURSEL = TCM_FIRST + 11,

		/// <summary>
		/// Selects a tab in a tab control. You can send this message explicitly or by using the <c>TabCtrl_SetCurSel</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the tab to select.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the previously selected tab if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// A tab control does not send a TCN_SELCHANGING or TCN_SELCHANGE notification code when a tab is selected using this message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-setcursel
		[MsgParams(typeof(int), null)]
		TCM_SETCURSEL = TCM_FIRST + 12,

		/// <summary>
		/// Determines which tab, if any, is at a specified screen position. You can send this message explicitly or by using the
		/// <c>TabCtrl_HitTest</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>TCHITTESTINFO</c> structure that specifies the screen position to test.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the tab, or -1 if no tab is at the specified position.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-hittest
		[MsgParams(null, typeof(TCHITTESTINFO?))]
		TCM_HITTEST = TCM_FIRST + 13,

		/// <summary>
		/// Sets the number of bytes per tab reserved for application-defined data in a tab control. You can send this message explicitly
		/// or by using the <c>TabCtrl_SetItemExtra</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Number of extra bytes.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// By default, the number of extra bytes is four. An application that changes the number of extra bytes cannot use the
		/// <c>TCITEM</c> structure to retrieve and set the application-defined data for a tab. Instead, you must define a new structure
		/// that consists of the <c>TCITEMHEADER</c> structure followed by application-defined members.
		/// </para>
		/// <para>An application should only change the number of extra bytes when a tab control does not contain any tabs.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-setitemextra
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TCM_SETITEMEXTRA = TCM_FIRST + 14,

		/// <summary>
		/// Calculates a tab control's display area given a window rectangle, or calculates the window rectangle that would correspond to
		/// a specified display area. You can send this message explicitly or by using the <c>TabCtrl_AdjustRect</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Operation to perform. If this parameter is <c>TRUE</c>, lParam specifies a display rectangle and receives the corresponding
		/// window rectangle. If this parameter is <c>FALSE</c>, lParam specifies a window rectangle and receives the corresponding
		/// display area.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>RECT</c> structure that specifies the given rectangle and receives the calculated rectangle.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// This message applies only to tab controls that are at the top. It does not apply to tab controls that are on the sides or bottom.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-adjustrect
		[MsgParams(typeof(BOOL), typeof(RECT?), LResultType = null)]
		TCM_ADJUSTRECT = TCM_FIRST + 40,

		/// <summary>
		/// Sets the width and height of tabs in a fixed-width or owner-drawn tab control. You can send this message explicitly or by
		/// using the <c>TabCtrl_SetItemSize</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is an <c>INT</c> value that specifies the new width, in pixels. The <c>HIWORD</c> is an <c>INT</c> value
		/// that specifies the new height, in pixels.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the old width and height. The width is in the <c>LOWORD</c> of the return value, and the height is in the <c>HIWORD</c>.</para>
		/// </summary>
		/// <remarks>
		/// If the width is set to a value less than the image width set by <c>ImageList_Create</c>, the width of the tab is set to the
		/// lowest value that is greater than the image width.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-setitemsize
		[MsgParams(null, typeof(uint), LResultType = typeof(uint))]
		TCM_SETITEMSIZE = TCM_FIRST + 41,

		/// <summary>
		/// Removes an image from a tab control's image list. You can send this message explicitly or by using the
		/// <c>TabCtrl_RemoveImage</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the image to remove.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// The tab control updates each tab's image index, so each tab remains associated with the same image as before. If a tab is
		/// using the image being removed, the tab will be set to have no image.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-removeimage
		[MsgParams(typeof(int), null, LResultType = null)]
		TCM_REMOVEIMAGE = TCM_FIRST + 42,

		/// <summary>
		/// Sets the amount of space (padding) around each tab's icon and label in a tab control. You can send this message explicitly or by
		/// using the <c>TabCtrl_SetPadding</c> macro.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is an <c>INT</c> value that specifies the amount of horizontal padding, in pixels. The <c>HIWORD</c> is an
		/// <c>INT</c> value that specifies the amount of vertical padding, in pixels.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/tcm-setpadding
		[MsgParams(null, typeof(uint), LResultType = null)]
		TCM_SETPADDING = TCM_FIRST + 43,

		/// <summary>
		/// Retrieves the current number of rows of tabs in a tab control. You can send this message explicitly or by using the
		/// <c>TabCtrl_GetRowCount</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the number of rows of tabs.</para>
		/// </summary>
		/// <remarks>Only tab controls that have the <c>TCS_MULTILINE</c> style can have multiple rows of tabs.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-getrowcount
		[MsgParams()]
		TCM_GETROWCOUNT = TCM_FIRST + 44,

		/// <summary>
		/// Retrieves the handle to the tooltip control associated with a tab control. You can send this message explicitly or by using
		/// the <c>TabCtrl_GetToolTips</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the tooltip control if successful, or <c>NULL</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// A tab control creates a tooltip control if it has the <c>TCS_TOOLTIPS</c> style. You can also assign a tooltip control to a
		/// tab control by using the <c>TCM_SETTOOLTIPS</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-gettooltips
		[MsgParams(LResultType = typeof(HWND))]
		TCM_GETTOOLTIPS = TCM_FIRST + 45,

		/// <summary>
		/// Assigns a tooltip control to a tab control. You can send this message explicitly or by using the <c>TabCtrl_SetToolTips</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the tooltip control.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>You can retrieve the tooltip control associated with a tab control by using the <c>TCM_GETTOOLTIPS</c> message.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-settooltips
		[MsgParams(typeof(HWND), null, LResultType = null)]
		TCM_SETTOOLTIPS = TCM_FIRST + 46,

		/// <summary>
		/// Returns the index of the item that has the focus in a tab control. You can send this message explicitly or by using the
		/// <c>TabCtrl_GetCurFocus</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the tab item that has the focus.</para>
		/// </summary>
		/// <remarks>The item that has the focus may be different than the selected item.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-getcurfocus
		[MsgParams()]
		TCM_GETCURFOCUS = TCM_FIRST + 47,

		/// <summary>
		/// Sets the focus to a specified tab in a tab control. You can send this message explicitly or by using the
		/// <c>TabCtrl_SetCurFocus</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the tab that gets the focus.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the tab control has the <c>TCS_BUTTONS</c> style (button mode), the tab with the focus may be different from the selected
		/// tab. For example, when a tab is selected, the user can press the arrow keys to set the focus to a different tab without
		/// changing the selected tab. In button mode, <c>TCM_SETCURFOCUS</c> sets the input focus to the button associated with the
		/// specified tab, but it does not change the selected tab.
		/// </para>
		/// <para>
		/// If the tab control does not have the <c>TCS_BUTTONS</c> style, changing the focus also changes the selected tab. In this
		/// case, the tab control sends the TCN_SELCHANGING and TCN_SELCHANGE notification codes to its parent window.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-setcurfocus
		[MsgParams(typeof(int), null, LResultType = null)]
		TCM_SETCURFOCUS = TCM_FIRST + 48,

		/// <summary>
		/// Sets the minimum width of items in a tab control. You can send this message explicitly or by using the
		/// <c>TabCtrl_SetMinTabWidth</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Minimum width to be set for a tab control item. If this parameter is set to -1, the control will use the default tab width.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns an INT value that represents the previous minimum tab width.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-setmintabwidth
		[MsgParams(null, typeof(int))]
		TCM_SETMINTABWIDTH = TCM_FIRST + 49,

		/// <summary>
		/// Resets items in a tab control, clearing any that were set to the <c>TCIS_BUTTONPRESSED</c> state. You can send this message
		/// explicitly or by using the <c>TabCtrl_DeselectAll</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Flag that specifies the scope of the item deselection. If this parameter is set to <c>FALSE</c>, all tab items will be reset.
		/// If it is set to <c>TRUE</c>, then all tab items except for the one currently selected will be reset.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value for this message is not used.</para>
		/// </summary>
		/// <remarks>This message is only meaningful if the <c>TCS_BUTTONS</c> style flag has been set.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-deselectall
		[MsgParams(typeof(BOOL), null, LResultType = null)]
		TCM_DESELECTALL = TCM_FIRST + 50,

		/// <summary>
		/// Sets the highlight state of a tab item. You can send this message explicitly or by using the <c>TabCtrl_HighlightItem</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>An <c>INT</c> value that specifies the zero-based index of a tab control item.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is a <c>BOOL</c> specifying the highlight state to be set. If this value is <c>TRUE</c>, the tab is
		/// highlighted; if <c>FALSE</c>, the tab is set to its default state. The <c>HIWORD</c> must be zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>In Comctl32.dll version 6.0, this message has no visible effect when a theme is active.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-highlightitem
		[MsgParams(typeof(int), typeof(uint), LResultType = typeof(BOOL))]
		TCM_HIGHLIGHTITEM = TCM_FIRST + 51,

		/// <summary>
		/// Sets the extended styles that the tab control will use. You can send this message explicitly or by using the
		/// <c>TabCtrl_SetExtendedStyle</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A <c>DWORD</c> value that indicates which styles in lParam are to be affected. Only the extended styles in wParam will be
		/// changed. All other styles will be maintained as they are. If this parameter is zero, then all of the styles in lParam will be affected.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Value specifying the extended tab control styles. This value is a combination of tab control extended styles.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>DWORD</c> value that contains the previous tab control extended styles.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The wParam parameter allows you to modify one or more extended styles without having to retrieve the existing styles first.
		/// For example, if you pass <c>TCS_EX_FLATSEPARATORS</c> for wParam and 0 for lParam, the <c>TCS_EX_FLATSEPARATORS</c> style
		/// will be cleared, but all other styles will remain the same.
		/// </para>
		/// <para>For backward compatibility reasons, the <c>TabCtrl_SetExtendedStyle</c> macro has not been updated to use dwExMask.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-setextendedstyle
		[MsgParams(typeof(TabControlStylesEx), typeof(TabControlStylesEx), LResultType = typeof(TabControlStylesEx))]
		TCM_SETEXTENDEDSTYLE = TCM_FIRST + 52,  // optional wParam == mask

		/// <summary>
		/// Retrieves the extended styles that are currently in use for the tab control. You can send this message explicitly or by using
		/// the <c>TabCtrl_GetExtendedStyle</c> macro.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>DWORD</c> value that represents the extended styles currently in use for the tab control. This value is a
		/// combination of tab control extended styles.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-getextendedstyle
		[MsgParams(LResultType = typeof(TabControlStylesEx))]
		TCM_GETEXTENDEDSTYLE = TCM_FIRST + 53,

		/// <summary>
		/// Sets the Unicode character format flag for the control. This message allows you to change the character set used by the
		/// control at run time rather than having to re-create the control. You can send this message explicitly or use the
		/// <c>TabCtrl_SetUnicodeFormat</c> macro.
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
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-setunicodeformat
		[MsgParams(typeof(BOOL), null, LResultType = typeof(BOOL))]
		TCM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,

		/// <summary>
		/// Retrieves the Unicode character format flag for the control. You can send this message explicitly or use the
		/// <c>TabCtrl_GetUnicodeFormat</c> macro.
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
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcm-getunicodeformat
		[MsgParams(LResultType = typeof(BOOL))]
		TCM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT
	}

	/// <summary>Tab Control Notifications</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
	public enum TabControlNotification
	{
		/// <summary>
		/// <para>
		/// Notifies a tab control's parent window that a key has been pressed. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TCN_KEYDOWN pnm = (NMTCKEYDOWN*) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTCKEYDOWN</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcn-keydown
		[CorrespondingType(typeof(NMTCKEYDOWN))]
		TCN_KEYDOWN = TCN_FIRST - 0,

		/// <summary>
		/// <para>
		/// Notifies a tab control's parent window that the currently selected tab has changed. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TCN_SELCHANGE lpnmhdr = (LPNMHDR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMHDR</c> structure that contains additional information about this notification.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>To determine the currently selected tab, use the <c>TabCtrl_GetCurSel</c> macro.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcn-selchange
		[CorrespondingType(typeof(NMHDR))]
		TCN_SELCHANGE = TCN_FIRST - 1,

		/// <summary>
		/// <para>
		/// Notifies a tab control's parent window that the currently selected tab is about to change. This notification code is sent in
		/// the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TCN_SELCHANGING lpnmhdr = (LPNMHDR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMHDR</c> structure that contains additional information about this notification.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> to prevent the selection from changing, or <c>FALSE</c> to allow the selection to change.</para>
		/// </summary>
		/// <remarks>To determine the currently selected tab, use the <c>TabCtrl_GetCurSel</c> macro.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcn-selchanging
		[CorrespondingType(typeof(NMHDR))]
		TCN_SELCHANGING = TCN_FIRST - 2,

		/// <summary>
		/// <para>
		/// Sent by a tab control when it has the <c>TCS_EX_REGISTERDROP</c> extended style and an object is dragged over a tab item in
		/// the control. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TCN_GETOBJECT lpnmon = (LPNMOBJECTNOTIFY) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMOBJECTNOTIFY</c> structure that contains information about the tab item the object is dragged over and
		/// receives data the application returns in response to this message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The application processing this notification code must return zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcn-getobject
		[CorrespondingType(typeof(NMOBJECTNOTIFY))]
		TCN_GETOBJECT = TCN_FIRST - 3,

		/// <summary>
		/// <para>
		/// Notifies a tab control's parent window that the button focus has changed. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TCN_FOCUSCHANGE lpnmh = (LPNMHDR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMHDR</c> structure that contains additional information about this notification.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tcn-focuschange
		[CorrespondingType(typeof(NMHDR))]
		TCN_FOCUSCHANGE = TCN_FIRST - 4,
	}

	/// <summary>This section lists supported tab control styles.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760549")]
	[Flags]
	public enum TabControlStyles
	{
		/// <summary>Version 4.70. Unneeded tabs scroll to the opposite side of the control when a tab is selected.</summary>
		TCS_SCROLLOPPOSITE = 0x0001,

		/// <summary>
		/// Version 4.70. Tabs appear at the bottom of the control. This value equals TCS_RIGHT. This style is not supported if you use
		/// ComCtl32.dll version 6.
		/// </summary>
		TCS_BOTTOM = 0x0002,

		/// <summary>
		/// Version 4.70. Tabs appear vertically on the right side of controls that use the TCS_VERTICAL style. This value equals
		/// TCS_BOTTOM. This style is not supported if you use visual styles.
		/// </summary>
		TCS_RIGHT = 0x0002,

		/// <summary>
		/// Version 4.70. Multiple tabs can be selected by holding down the CTRL key when clicking. This style must be used with the
		/// TCS_BUTTONS style.
		/// </summary>
		TCS_MULTISELECT = 0x0004,

		/// <summary>
		/// Version 4.71. Selected tabs appear as being indented into the background while other tabs appear as being on the same plane
		/// as the background. This style only affects tab controls with the TCS_BUTTONS style.
		/// </summary>
		TCS_FLATBUTTONS = 0x0008,

		/// <summary>
		/// Icons are aligned with the left edge of each fixed-width tab. This style can only be used with the TCS_FIXEDWIDTH style.
		/// </summary>
		TCS_FORCEICONLEFT = 0x0010,

		/// <summary>
		/// Labels are aligned with the left edge of each fixed-width tab; that is, the label is displayed immediately to the right of
		/// the icon instead of being centered. This style can only be used with the TCS_FIXEDWIDTH style, and it implies the
		/// TCS_FORCEICONLEFT style.
		/// </summary>
		TCS_FORCELABELLEFT = 0x0020,

		/// <summary>
		/// Version 4.70. Items under the pointer are automatically highlighted. You can check whether hot tracking is enabled by calling SystemParametersInfo.
		/// </summary>
		TCS_HOTTRACK = 0x0040,

		/// <summary>
		/// Version 4.70. Tabs appear at the left side of the control, with tab text displayed vertically. This style is valid only when
		/// used with the TCS_MULTILINE style. To make tabs appear on the right side of the control, also use the TCS_RIGHT style. This
		/// style is not supported if you use ComCtl32.dll version 6.
		/// </summary>
		TCS_VERTICAL = 0x0080,

		/// <summary>Tabs appear as tabs, and a border is drawn around the display area. This style is the default.</summary>
		TCS_TABS = 0x0000,

		/// <summary>Tabs appear as buttons, and no border is drawn around the display area.</summary>
		TCS_BUTTONS = 0x0100,

		/// <summary>Only one row of tabs is displayed. The user can scroll to see more tabs, if necessary. This style is the default.</summary>
		TCS_SINGLELINE = 0x0000,

		/// <summary>Multiple rows of tabs are displayed, if necessary, so all tabs are visible at once.</summary>
		TCS_MULTILINE = 0x0200,

		/// <summary>
		/// The width of each tab is increased, if necessary, so that each row of tabs fills the entire width of the tab control. This
		/// window style is ignored unless the TCS_MULTILINE style is also specified.
		/// </summary>
		TCS_RIGHTJUSTIFY = 0x0000,

		/// <summary>All tabs are the same width. This style cannot be combined with the TCS_RIGHTJUSTIFY style.</summary>
		TCS_FIXEDWIDTH = 0x0400,

		/// <summary>Rows of tabs will not be stretched to fill the entire width of the control. This style is the default.</summary>
		TCS_RAGGEDRIGHT = 0x0800,

		/// <summary>The tab control receives the input focus when clicked.</summary>
		TCS_FOCUSONBUTTONDOWN = 0x1000,

		/// <summary>The parent window is responsible for drawing tabs.</summary>
		TCS_OWNERDRAWFIXED = 0x2000,

		/// <summary>The tab control has a tooltip control associated with it.</summary>
		TCS_TOOLTIPS = 0x4000,

		/// <summary>The tab control does not receive the input focus when clicked.</summary>
		TCS_FOCUSNEVER = 0x8000,
	}

	/// <summary>
	/// The tab control now supports extended styles. These styles are manipulated using the TCM_GETEXTENDEDSTYLE and
	/// TCM_SETEXTENDEDSTYLE messages and should not be confused with extended window styles that are passed to CreateWindowEx.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760546")]
	[Flags]
	public enum TabControlStylesEx
	{
		/// <summary>
		/// Version 4.71. The tab control will draw separators between the tab items. This extended style only affects tab controls that
		/// have the TCS_BUTTONS and TCS_FLATBUTTONS styles. By default, creating the tab control with the TCS_FLATBUTTONS style sets
		/// this extended style. If you do not require separators, you should remove this extended style after creating the control.
		/// </summary>
		TCS_EX_FLATSEPARATORS = 0x00000001,

		/// <summary>
		/// Version 4.71. The tab control generates TCN_GETOBJECT notification codes to request a drop target object when an object is
		/// dragged over the tab items in the control. The application must call CoInitialize or OleInitialize before setting this style.
		/// </summary>
		TCS_EX_REGISTERDROP = 0x00000002
	}

	/// <summary>
	/// Contains information about a key press in a tab control. It is used with the TCN_KEYDOWN notification code. This structure supersedes
	/// the <c>TC_KEYDOWN</c> structure.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmtckeydown typedef struct tagTCKEYDOWN { NMHDR hdr; WORD
	// wVKey; UINT flags; } NMTCKEYDOWN;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagTCKEYDOWN")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMTCKEYDOWN : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR structure that contains information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Virtual key code. Cast to <see cref="VK"/>.</para>
		/// </summary>
		public ushort wVKey;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Value that is identical to the <c>lParam</c> parameter of the <see cref="WindowMessage.WM_KEYDOWN"/> message.</para>
		/// </summary>
		public WM_KEY_LPARAM flags;
	}

	/// <summary>Contains information about a hit test. This structure supersedes the TC_HITTESTINFO structure.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760553")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TCHITTESTINFO
	{
		/// <summary>Position to hit test, in client coordinates.</summary>
		public POINT pt;

		/// <summary>Variable that receives the results of a hit test. The tab control sets this member to one of the following values:</summary>
		public TabControlHitTestFlags flags;
	}

	/// <summary>
	/// Specifies or receives the attributes of a tab item. It is used with the TCM_INSERTITEM, TCM_GETITEM, and TCM_SETITEM messages.
	/// This structure supersedes the TC_ITEM structure.
	/// </summary>
	/// <seealso cref="IDisposable"/>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760554")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public sealed class TCITEM : IDisposable
	{
		/// <summary>Value that specifies which members to retrieve or set.</summary>
		public TabControlItemMask mask;

		/// <summary>
		/// Version 4.70. Specifies the item's current state if information is being retrieved. If item information is being set, this
		/// member contains the state value to be set for the item. For a list of valid tab control item states, see Tab Control Item
		/// States. This member is ignored in the TCM_INSERTITEM message.
		/// </summary>
		public TabControlItemStates dwState;

		/// <summary>
		/// Version 4.70. Specifies which bits of the dwState member contain valid information. This member is ignored in the
		/// TCM_INSERTITEM message.
		/// </summary>
		public TabControlItemStates dwStateMask;

		/// <summary>
		/// Pointer to a null-terminated string that contains the tab text when item information is being set. If item information is
		/// being retrieved, this member specifies the address of the buffer that receives the tab text.
		/// </summary>
		public StrPtrAuto pszText;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszText member. If the structure is not receiving information, this member is ignored.
		/// </summary>
		public uint cchTextMax;

		/// <summary>Index in the tab control's image list, or -1 if there is no image for the tab.</summary>
		public int iImage;

		/// <summary>
		/// Application-defined data associated with the tab control item. If more or less than 4 bytes of application-defined data exist
		/// per tab, an application must define a structure and use it instead of the TCITEM structure. The first member of the
		/// application-defined structure must be a TCITEMHEADER structure.
		/// </summary>
		public IntPtr lParam;

		/// <summary>Initializes a new instance of the <see cref="TCITEM" /> class.</summary>
		/// <param name="itemsToGet">Value that specifies which members to retrieve or set.</param>
		/// <param name="statesToGet">Specifies which bits of the dwState member contain valid information.</param>
		public TCITEM(TabControlItemMask itemsToGet = TabControlItemMask.TCIF_ALL, TabControlItemStates statesToGet = TabControlItemStates.TCIS_ALL)
		{
			if ((itemsToGet & TabControlItemMask.TCIF_TEXT) != 0)
			{
				pszText = new StrPtrAuto(cchTextMax = 1024);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="TCITEM"/> class.</summary>
		/// <param name="text">The text.</param>
		public TCITEM(string text) => Text = text;

		/// <summary>Gets or sets the text.</summary>
		/// <value>The text.</value>
		public string Text
		{
			get => pszText.ToString();
			set
			{
				pszText.Assign(value, out cchTextMax);
				mask |= TabControlItemMask.TCIF_TEXT;
			}
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			pszText.Free();
			cchTextMax = 0;
		}
	}

	/// <summary>
	/// Specifies or receives the attributes of a tab. It is used with the TCM_INSERTITEM, TCM_GETITEM, and TCM_SETITEM messages. This
	/// structure supersedes the TC_ITEMHEADER structure.
	/// </summary>
	/// <seealso cref="IDisposable"/>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public sealed class TCITEMHEADER : IDisposable
	{
		/// <summary>Value that specifies which members to retrieve or set.</summary>
		public TabControlItemMask mask;

		/// <summary>
		/// Version 4.70. Specifies the item's current state if information is being retrieved. If item information is being set, this
		/// member contains the state value to be set for the item. For a list of valid tab control item states, see Tab Control Item
		/// States. This member is ignored in the TCM_INSERTITEM message.
		/// </summary>
		public TabControlItemStates dwState;

		/// <summary>
		/// Version 4.70. Specifies which bits of the dwState member contain valid information. This member is ignored in the
		/// TCM_INSERTITEM message.
		/// </summary>
		public TabControlItemStates dwStateMask;

		/// <summary>
		/// Pointer to a null-terminated string that contains the tab text when item information is being set. If item information is
		/// being retrieved, this member specifies the address of the buffer that receives the tab text.
		/// </summary>
		public StrPtrAuto pszText;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszText member. If the structure is not receiving information, this member is ignored.
		/// </summary>
		public uint cchTextMax;

		/// <summary>Index in the tab control's image list, or -1 if there is no image for the tab.</summary>
		public int iImage;

		/// <summary>Initializes a new instance of the <see cref="TCITEM"/> class.</summary>
		public TCITEMHEADER(TabControlItemMask itemsToGet = TabControlItemMask.TCIF_ALL, TabControlItemStates statesToGet = TabControlItemStates.TCIS_ALL)
		{
			if ((itemsToGet & TabControlItemMask.TCIF_TEXT) != 0)
			{
				pszText = new StrPtrAuto(cchTextMax = 1024);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="TCITEM"/> class.</summary>
		/// <param name="text">The text.</param>
		public TCITEMHEADER(string text) => Text = text;

		/// <summary>Gets or sets the text.</summary>
		/// <value>The text.</value>
		public string Text
		{
			get => pszText.ToString();
			set
			{
				pszText.Assign(value, out cchTextMax);
				mask |= TabControlItemMask.TCIF_TEXT;
			}
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			pszText.Free();
			cchTextMax = 0;
		}
	}
}