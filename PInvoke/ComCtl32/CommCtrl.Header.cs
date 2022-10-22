using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>Window Class Name for Header control.</summary>
		public const string WC_HEADER = "SysHeader";

		private const int HDM_FIRST = 0x1200;
		private const int HDN_FIRST = -300;

		/// <summary>The variable that receives information about the results of a hit test.</summary>
		[Flags]
		public enum HeaderHitTestFlag : uint
		{
			/// <summary>The point is above the header control's bounding rectangle.</summary>
			HHT_ABOVE = 0x0100,

			/// <summary>The point is below the header control's bounding rectangle.</summary>
			HHT_BELOW = 0x0200,

			/// <summary>The point is inside the header control's bounding rectangle but is not over a header item.</summary>
			HHT_NOWHERE = 0x0001,

			/// <summary>The point is on the divider between two header items.</summary>
			HHT_ONDIVIDER = 0x0004,

			/// <summary>
			/// The point is on the divider of an item that has a width of zero. Dragging the divider reveals the item instead of resizing
			/// the item to the left of the divider.
			/// </summary>
			HHT_ONDIVOPEN = 0x0008,

			/// <summary>The point is within the split button of the item. The style HDF_SPLITBUTTON must be set on the item.</summary>
			HHT_ONDROPDOWN = 0x2000,

			/// <summary>The point is over the filter area.</summary>
			HHT_ONFILTER = 0x0010,

			/// <summary>The point is on the filter button.</summary>
			HHT_ONFILTERBUTTON = 0x0020,

			/// <summary>The point is to the left of the header control's bounding rectangle.</summary>
			HHT_ONHEADER = 0x0002,

			/// <summary>
			/// The point is within the state icon of the item. If style HDS_CHECKBOXES is specified, the point is within the checkbox of the item.
			/// </summary>
			HHT_ONITEMSTATEICON = 0x1000,

			/// <summary>
			/// The point is within the overflow button of the header control. The style HDS_OVERFLOW must be set on the header control.
			/// </summary>
			HHT_ONOVERFLOW = 0x4000,

			/// <summary>The point is to the left of the header control's bounding rectangle.</summary>
			HHT_TOLEFT = 0x0800,

			/// <summary>The point is to the right of the header control's bounding rectangle.</summary>
			HHT_TORIGHT = 0x0400,
		}

		/// <summary>The type of filter specified by <see cref="HDITEM.pvFilter"/>.</summary>
		public enum HeaderItemFilterType
		{
			/// <summary>String data.</summary>
			HDFT_ISSTRING = 0,

			/// <summary>Numerical data.</summary>
			HDFT_ISNUMBER = 1,

			/// <summary>Date data. The pvFilter member is a pointer to a SYSTEMTIME structure.</summary>
			HDFT_ISDATE = 2,

			/// <summary>Ignore pvFilter.</summary>
			HDFT_HASNOVALUE = 0x8000
		}

		/// <summary>Flags that specify an <see cref="HDITEM"/> format.</summary>
		[Flags]
		public enum HeaderItemFormat : uint
		{
			/// <summary>The item's contents are left-aligned.</summary>
			HDF_LEFT = 0x0000,

			/// <summary>The item's contents are right-aligned.</summary>
			HDF_RIGHT = 0x0001,

			/// <summary>The item's contents are centered.</summary>
			HDF_CENTER = 0x0002,

			/// <summary>Isolate the bits corresponding to the three justification flags listed in the preceding table.</summary>
			HDF_JUSTIFYMASK = 0x0003,

			/// <summary>
			/// Typically, windows displays text left-to-right (LTR). Windows can be mirrored to display languages such as Hebrew or Arabic
			/// that read right-to-left (RTL). Usually, header text is read in the same direction as the text in its parent window. If
			/// HDF_RTLREADING is set, header text will read in the opposite direction from the text in the parent window.
			/// </summary>
			HDF_RTLREADING = 0x0004,

			/// <summary>
			/// The item displays a checkbox. The flag is only valid when the HDS_CHECKBOXES style is first set on the header control.
			/// </summary>
			HDF_CHECKBOX = 0x0040,

			/// <summary>The item displays a checked checkbox. The flag is only valid when HDF_CHECKBOX is also set.</summary>
			HDF_CHECKED = 0x0080,

			/// <summary>The width of the item cannot be modified by a user action to resize it.</summary>
			HDF_FIXEDWIDTH = 0x0100,

			/// <summary>The header control's owner draws the item.</summary>
			HDF_OWNERDRAW = 0x8000,

			/// <summary>The item displays a string.</summary>
			HDF_STRING = 0x4000,

			/// <summary>The item displays a bitmap.</summary>
			HDF_BITMAP = 0x2000,

			/// <summary>The bitmap appears to the right of text.</summary>
			HDF_BITMAP_ON_RIGHT = 0x1000,

			/// <summary>
			/// Display an image from an image list. Specify the image list by sending an HDM_SETIMAGELIST message. Specify the index of the
			/// image in the iImage member of this structure.
			/// </summary>
			HDF_IMAGE = 0x0800,

			/// <summary>
			/// Draws an up-arrow on this item. This is typically used to indicate that information in the current window is sorted on this
			/// column in ascending order. This flag cannot be combined with HDF_IMAGE or HDF_BITMAP.
			/// </summary>
			HDF_SORTUP = 0x0400,

			/// <summary>
			/// Draws a down-arrow on this item. This is typically used to indicate that information in the current window is sorted on this
			/// column in descending order. This flag cannot be combined with HDF_IMAGE or HDF_BITMAP.
			/// </summary>
			HDF_SORTDOWN = 0x0200,

			/// <summary>The item displays a split button. The HDN_DROPDOWN notification is sent when the split button is clicked.</summary>
			HDF_SPLITBUTTON = 0x1000000
		}

		/// <summary>Determines which type of bitmap is displayed on a header column.</summary>
		[Flags]
		public enum HeaderItemImageDisplay
		{
			/// <summary>All flags related to image display are cleared.</summary>
			None,

			/// <summary>Display a supplied bitmap image. Correlates to HDF_BITMAP.</summary>
			Bitmap = 0x2000,

			/// <summary>Display a supplied image-list item. Correlates to HDF_IMAGE.</summary>
			ImageListItem = 0x0800,

			/// <summary>Display a system defined down arrow. Correlates to HDF_SORTDOWN.</summary>
			DownArrow = 0x0200,

			/// <summary>Display a system defined up arrow. Correlates to HDF_SORTUP.</summary>
			UpArrow = 0x0400,
		}

		/// <summary>Flags indicating which <see cref="HDITEM"/> structure members contain valid data or must be filled in.</summary>
		[Flags]
		public enum HeaderItemMask : uint
		{
			/// <summary>The <see cref="HDITEM.hbm"/> member is valid.</summary>
			HDI_BITMAP = 0x0010,

			/// <summary>
			/// While handling the message HDM_GETITEM, the header control may not have all the values needed to complete the request. In
			/// this case, the control must call the application back for the values via the HDN_GETDISPINFO notification. If HDI_DI_SETITEM
			/// has been passed in the HDM_GETITEM message, the control will cache any values returned from HDN_GETDISPINFO (otherwise the
			/// values remain unset.)
			/// </summary>
			HDI_DI_SETITEM = 0x0040,

			/// <summary>
			/// The <see cref="HDITEM.type"/> and <see cref="HDITEM.pvFilter"/> members are valid. This is used to filter out the values
			/// specified in the type member.
			/// </summary>
			HDI_FILTER = 0x0100,

			/// <summary>The <see cref="HDITEM.fmt"/> member is valid.</summary>
			HDI_FORMAT = 0x0004,

			/// <summary>The same as HDI_WIDTH.</summary>
			HDI_HEIGHT = HDI_WIDTH,

			/// <summary>The <see cref="HDITEM.iImage"/> member is valid and specifies the image to be displayed with the item.</summary>
			HDI_IMAGE = 0x0020,

			/// <summary>The <see cref="HDITEM.lParam"/> member is valid.</summary>
			HDI_LPARAM = 0x0008,

			/// <summary>The <see cref="HDITEM.iOrder"/> member is valid and specifies the item's order value.</summary>
			HDI_ORDER = 0x0080,

			/// <summary>The <see cref="HDITEM.state"/> member is valid.</summary>
			HDI_STATE = 0x0200,

			/// <summary>The <see cref="HDITEM.pszText"/> and <see cref="HDITEM.cchTextMax"/> members are valid.</summary>
			HDI_TEXT = 0x0002,

			/// <summary>The <see cref="HDITEM.cxy"/> member is valid and specifies the item's width.</summary>
			HDI_WIDTH = 0x0001,

			/// <summary>All <see cref="HDITEM"/> members are valid.</summary>
			HDI_ALL = 0x03FF,
		}

		/// <summary>Valid entries for <see cref="HDITEM.state"/>.</summary>
		public enum HeaderItemState
		{
			/// <summary>No state value.</summary>
			None = 0,

			/// <summary>The item has keyboard focus.</summary>
			HDIS_FOCUSED = 1
		}

		/// <summary>Header Control Messages</summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/bumper-header-control-reference-messages
		[PInvokeData("Commctrl.h", MSDNShortId = "bumper-header-control-reference-messages")]
		public enum HeaderMessage
		{
			/// <summary>
			/// Clears the filter for a given header control. You can send this message explicitly or use the <c>Header_ClearFilter</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>A column value indicating which filter to clear.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns an integer. The <c>LRESULT</c> is cast to an integer that indicates <c>TRUE</c>(1) or <c>FALSE</c>(0).</para>
			/// </summary>
			/// <remarks>
			/// If the column value is specified as -1, all the filters are cleared, and the HDN_FILTERCHANGE notification is sent only once.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-clearfilter
			HDM_CLEARFILTER = HDM_FIRST + 24, // int, 0

			/// <summary>
			/// Creates a semi-transparent version of an item's image for use as a dragging image. You can send this message explicitly or
			/// use the <c>Header_CreateDragImage</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// The zero-based index of the item within the header control. The image assigned to this item is the basis for the transparent image.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a handle to an image list that contains the new image as its only element.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-createdragimage
			HDM_CREATEDRAGIMAGE = HDM_FIRST + 16, // int, 0

			/// <summary>
			/// Deletes an item from a header control. You can send this message explicitly or use the <c>Header_DeleteItem</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>An index of the item to delete.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-deleteitem
			HDM_DELETEITEM = HDM_FIRST + 2, // int, 0

			/// <summary>Moves the input focus to the edit box when a filter button has the focus.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>A value specifying the column to edit.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A flag that specifies how to handle the user's editing changes. Use this flag to specify what to do if the user is in the
			/// process of editing the filter when the message is sent.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TRUE</c></term>
			/// <term>Discard the changes made by the user.</term>
			/// </item>
			/// <item>
			/// <term><c>FALSE</c></term>
			/// <term>Accept the changes made by the user.</term>
			/// </item>
			/// </list>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns an integer. The <c>LRESULT</c> is cast to an integer that indicates <c>TRUE</c>(1) or <c>FALSE</c>(0).</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-editfilter
			HDM_EDITFILTER = HDM_FIRST + 23, // int, bool

			/// <summary>
			/// Gets the width of the bitmap margin for a header control. You can send this message explicitly or use the
			/// <c>Header_GetBitmapMargin</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the width of the bitmap margin in pixels. If the bitmap margin was not previously specified, the default value of 3*
			/// <c>GetSystemMetrics</c> (SM_CXEDGE) is returned.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getbitmapmargin
			HDM_GETBITMAPMARGIN = HDM_FIRST + 21, // 0,0

			/// <summary>
			/// Gets the item in a header control that has the focus. Send this message explicitly or by using the
			/// <c>Header_GetFocusedItem</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Not used. Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Not used. Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the index of the item in focus.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getfocuseditem
			HDM_GETFOCUSEDITEM = HDM_FIRST + 27, // 0,0

			/// <summary>
			/// Gets the handle to the image list that has been set for an existing header control. You can send this message explicitly or
			/// use the <c>Header_GetImageList</c> or <c>Header_GetStateImageList</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>*wParam*</em></para>
			/// <para>One of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>HDSIL_NORMAL</c></term>
			/// <term>Indicates that this is a normal image list.</term>
			/// </item>
			/// <item>
			/// <term><c>HDSIL_STATE</c></term>
			/// <term>Indicates that this is a state image list.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a handle to the image list set for the header control.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getimagelist
			HDM_GETIMAGELIST = HDM_FIRST + 9, // 0, 0

			/// <summary>
			/// Gets information about an item in a header control. You can send this message explicitly or use the <c>Header_GetItem</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The index of the item for which information is to be retrieved.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>HDITEM</c> structure. When the message is sent, the <c>mask</c> member indicates the type of information
			/// being requested. When the message returns, the other members receive the requested information. If the <c>mask</c> member
			/// specifies zero, the message returns <c>TRUE</c> but copies no information to the structure.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
			/// </summary>
			/// <remarks>
			/// If the HDI_TEXT flag is set in the <c>mask</c> member of the <c>HDITEM</c> structure, the control may change the
			/// <c>pszText</c> member of the structure to point to the new text instead of filling the buffer with the requested text.
			/// Applications should not assume that the text will always be placed in the requested buffer.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getitem
			HDM_GETITEM = HDM_FIRST + 11, // int, HDITEM

			/// <summary>
			/// Gets a count of the items in a header control. You can send this message explicitly or use the <c>Header_GetItemCount</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the number of items if successful, or -1 otherwise.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getitemcount
			HDM_GETITEMCOUNT = HDM_FIRST + 0, // 0, 0

			/// <summary>
			/// Gets the bounding rectangle of the split button for a header item with style <c>HDF_SPLITBUTTON</c>. Send this message
			/// explicitly or by using the <c>Header_GetItemDropDownRect</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The zero-based index of the header control item for which to retrieve the bounding rectangle.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to a <c>RECT</c> structure that receives the bounding rectangle information. The message sender is responsible for
			/// allocating this structure. The coordinates returned in the RECT structure are expressed relative to the header control parent.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
			/// </summary>
			/// <remarks>The header item must have style <c>HDF_SPLITBUTTON</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getitemdropdownrect
			HDM_GETITEMDROPDOWNRECT = HDM_FIRST + 25, // int, RECT

			/// <summary>
			/// Gets the bounding rectangle for a given item in a header control. You can send this message explicitly or use the
			/// <c>Header_GetItemRect</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The zero-based index of the header control item for which to retrieve the bounding rectangle.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to a <c>RECT</c> structure that receives the bounding rectangle information. The message sender is responsible for
			/// allocating this structure. The coordinates returned in the RECT structure are expressed relative to the header control parent.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns nonzero if successful, or zero otherwise.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getitemrect
			HDM_GETITEMRECT = HDM_FIRST + 7, // int, RECT*

			/// <summary>
			/// Gets the current left-to-right order of items in a header control. You can send this message explicitly or use the
			/// <c>Header_GetOrderArray</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// The number of integer elements that lParam can hold. This value must be equal to the number of items in the control (see <c>HDM_GETITEMCOUNT</c>).
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>A pointer to an array of integers that receive the index values for items in the header.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns nonzero if successful, and the buffer at lParam receives the item number for each item in the header control in the
			/// order in which they appear from left to right. Otherwise, the message returns zero.
			/// </para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// The number of elements in lParam is specified in wParam and must be equal to the number of items in the control. For example,
			/// the following code fragment will reserve enough memory to hold the index values.
			/// </para>
			/// <para>
			/// <code>int iItems, *lpiArray; // Get memory for buffer. (iItems = SendMessage(hwndHD, HDM_GETITEMCOUNT, 0,0))!=-1) if(!(lpiArray = calloc(iItems,sizeof(int)))) MessageBox(hwnd, "Out of memory.","Error", MB_OK);</code>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getorderarray
			HDM_GETORDERARRAY = HDM_FIRST + 17, // iCount, lpArray

			/// <summary>
			/// Gets the bounding rectangle of the overflow button when the <c>HDS_OVERFLOW</c> style is set on the header control and the
			/// overflow button is visible. Send this message explicitly or by using the <c>Header_GetOverflowRect</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Not used. Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to a <c>RECT</c> structure to receive the bounding rectangle information. The message sender is responsible for
			/// allocating this structure. The coordinates returned in the <c>RECT</c> structure are expressed as screen coordinates.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</para>
			/// </summary>
			/// <remarks>The header control must have style <c>HDF_SPLITBUTTON</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getoverflowrect
			HDM_GETOVERFLOWRECT = HDM_FIRST + 26, // 0, RECT*

			/// <summary>
			/// Gets the Unicode character format flag for the control. You can send this message explicitly or use the
			/// <c>Header_GetUnicodeFormat</c> macro.
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
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-getunicodeformat
			HDM_GETUNICODEFORMAT = 0X2006,        // CCM_GETUNICODEFORMAT,

			/// <summary>Tests a point to determine which header item, if any, is at the specified point.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>HDHITTESTINFO</c> structure that contains the position to test and receives information about the results
			/// of the test.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the index of the item at the specified position, if any, or 1 otherwise.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-hittest
			HDM_HITTEST = HDM_FIRST + 6, // 0, HDHITTEST

			/// <summary>
			/// Inserts a new item into a header control. You can send this message explicitly or use the <c>Header_InsertItem</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// The index of the item after which the new item is to be inserted. The new item is inserted at the end of the header control
			/// if wParam is greater than or equal to the number of items in the control. If wParam is zero, the new item is inserted at the
			/// beginning of the header control.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>A pointer to an <c>HDITEM</c> structure that contains information about the new item.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the index of the new item if successful, or -1 otherwise.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-insertitem
			HDM_INSERTITEM = HDM_FIRST + 10, // int, HDITEM

			/// <summary>
			/// Retrieves information used to set the size and position of the header control within the target rectangle of the parent
			/// window. You can send this message explicitly or use the <c>Header_Layout</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>HDLAYOUT</c> structure. The <c>prc</c> member specifies the coordinates of a rectangle, and the
			/// <c>pwpos</c> member receives the size and position for the header control within the rectangle.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// The <c>pwpos</c> member of the lParam structure receives size and position values appropriate for positioning the control
			/// along the top of the specified rectangle. The height value is the sum of the heights of the control's horizontal borders and
			/// the average height of characters in the font currently selected into the control's device context.
			/// </para>
			/// <para>
			/// To use <c>HDM_LAYOUT</c> to set the initial size and position of a header control, set the initial visibility state of the
			/// control so that it is hidden. After sending <c>HDM_LAYOUT</c> to retrieve the size and position values, use the
			/// <c>SetWindowPos</c> function to set the new size, position, and visibility state.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-layout
			HDM_LAYOUT = HDM_FIRST + 5, // 0, HDLAYOUT

			/// <summary>
			/// Retrieves an index value for an item based on its order in the header control. You can send this message explicitly or use
			/// the <c>Header_OrderToIndex</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// The order in which the item appears within the header control, from left to right. For example, the index value of the item
			/// in the far left column would be 0. The value for the next item to the right would be 1, and so on.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns INT that indicates the item index. If wParam is invalid (negative or too large), the return equals wParam.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-ordertoindex
			HDM_ORDERTOINDEX = HDM_FIRST + 15, // int, 0

			/// <summary>
			/// Sets the width of the margin, specified in pixels, of a bitmap in an existing header control. You can send this message
			/// explicitly or use the <c>Header_SetBitmapMargin</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The width, specified in pixels, of the margin that surrounds a bitmap within an existing header control.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the width of the bitmap margin, in pixels. If the bitmap margin was not previously specified, the default value of 3*
			/// <c>GetSystemMetrics</c> (SM_CXEDGE) is returned.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-setbitmapmargin
			HDM_SETBITMAPMARGIN = HDM_FIRST + 20,// iWidth, 0

			/// <summary>
			/// Sets the timeout interval between the time a change takes place in the filter attributes and the posting of an
			/// HDN_FILTERCHANGE notification. You can send this message explicitly or use the <c>Header_SetFilterChangeTimeout</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>The timeout value, in milliseconds.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the index of the filter control being modified.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-setfilterchangetimeout
			HDM_SETFILTERCHANGETIMEOUT = HDM_FIRST + 22, // 0, int

			/// <summary>
			/// Sets the focus to a specified item in a header control. Send this message explicitly or by using the
			/// <c>Header_SetFocusedItem</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Not used. Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>The index of item.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-setfocuseditem
			HDM_SETFOCUSEDITEM = HDM_FIRST + 28, // 0, int

			/// <summary>
			/// Changes the color of a divider between header items to indicate the destination of an external drag-and-drop operation. You
			/// can send this message explicitly or use the <c>Header_SetHotDivider</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The type of value represented by lParam. This value can be one of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c><c>TRUE</c></c></term>
			/// <term>Indicates that <c>lParam</c> holds the client coordinates of the pointer.</term>
			/// </item>
			/// <item>
			/// <term><c><c>FALSE</c></c></term>
			/// <term>Indicates that <c>lParam</c> holds a divider index value.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>A value held in lParam is interpreted depending on the value of wParam.</para>
			/// <para>
			/// If wParam is <c>TRUE</c>, lParam represents the x- and y-coordinates of the pointer. The x-coordinate is in the low word, and
			/// the y-coordinate is in the high word. When the header control receives the message, it highlights the appropriate divider
			/// based on the lParam coordinates.
			/// </para>
			/// <para>If wParam is <c>FALSE</c>, lParam represents the integer index of the divider to be highlighted.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a value equal to the index of the divider that the control highlighted.</para>
			/// </summary>
			/// <remarks>
			/// This message creates an effect that a header control automatically produces when it has the <c>HDS_DRAGDROP</c> style. The
			/// <c>HDM_SETHOTDIVIDER</c> message is intended to be used when the owner of the control handles drag-and-drop operations manually.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-sethotdivider
			HDM_SETHOTDIVIDER = HDM_FIRST + 19, // bool, int

			/// <summary>
			/// Assigns an image list to an existing header control. You can send this message explicitly or use the
			/// <c>Header_SetImageList</c> or <c>Header_SetStateImageList</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>*wParam*</em></para>
			/// <para>One of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>HDSIL_NORMAL</c></term>
			/// <term>Indicates that this is a normal image list.</term>
			/// </item>
			/// <item>
			/// <term><c>HDSIL_STATE</c></term>
			/// <term>Indicates that this is a state image list.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>A handle to an image list.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the handle to the image list previously associated with the control. Returns <c>NULL</c> upon failure or if no image
			/// list was set previously.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-setimagelist
			HDM_SETIMAGELIST = HDM_FIRST + 8, // HDSIL_, hImageList

			/// <summary>
			/// Sets the attributes of the specified item in a header control. You can send this message explicitly or use the
			/// <c>Header_SetItem</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The current index of the item whose attributes are to be changed.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>HDITEM</c> structure that contains item information. When this message is sent, the <c>mask</c> member of
			/// the structure must be set to indicate which attributes are being set.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns nonzero upon success, or zero otherwise.</para>
			/// </summary>
			/// <remarks>
			/// The <c>HDITEM</c> structure that supports this message supports item order and image list information. By using these
			/// members, you can control the order in which items are displayed and specify images to appear with items.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-setitem
			HDM_SETITEM = HDM_FIRST + 12, // int, HDITEM

			/// <summary>
			/// Sets the left-to-right order of header items. You can send this message explicitly or use the <c>Header_SetOrderArray</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The size of the buffer at lParam, in elements. This value must equal the value returned by <c>HDM_GETITEMCOUNT</c>.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an array that specifies the order in which items should be displayed, from left to right. For example, if the
			/// contents of the array are {2,0,1}, the control displays item 2, item 0, and item 1, from left to right.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns nonzero if successful, or zero otherwise.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-setorderarray
			HDM_SETORDERARRAY = HDM_FIRST + 18, // iCount, lpArray

			/// <summary>
			/// Sets the UNICODE character format flag for the control. This message allows you to change the character set used by the
			/// control at run time rather than having to re-create the control. You can send this message explicitly or use the
			/// <c>Header_SetUnicodeFormat</c> macro.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// The character set that is used by the control. If this value is nonzero, the control will use Unicode characters. If this
			/// value is zero, the control will use ANSI characters.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous Unicode format flag for the control.</para>
			/// </summary>
			/// <remarks>See the remarks for <c>CCM_SETUNICODEFORMAT</c> for a discussion of this message.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdm-setunicodeformat
			HDM_SETUNICODEFORMAT = 0X2005,        // CCM_SETUNICODEFORMAT,
		}

		/// <summary>Header control notifications</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "ff485940")]
		public enum HeaderNotification
		{
			/// <summary>
			/// <para>
			/// Sent by a header control when a drag operation has begun on one of its items. This notification code is sent only by header
			/// controls that are set to the <c>HDS_DRAGDROP</c> style. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_BEGINDRAG pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>A pointer to an <c>NMHEADER</c> structure containing information about the header item that is being dragged.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// To allow the header control to automatically manage drag-and-drop operations, return <c>FALSE</c>. If the owner of the
			/// control is manually performing drag-and-drop reordering, return <c>TRUE</c>.
			/// </para>
			/// </summary>
			/// <remarks>
			/// A header control defaults to automatically managing drag-and-drop reordering. Returning <c>TRUE</c> to indicate external
			/// (manual) drag-and-drop management allows the owner of the control to provide custom services as part of the drag-and-drop process.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-begindrag
			HDN_BEGINDRAG = HDN_FIRST - 10,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that a filter edit has begun. This notification code is sent in the form of a
			/// <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_BEGINFILTEREDIT pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>A pointer to an <c>NMHEADER</c> structure that contains additional information about the filter that is being edited.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-beginfilteredit
			HDN_BEGINFILTEREDIT = HDN_FIRST - 14,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that the user has begun dragging a divider in the control (that is, the user has
			/// pressed the left mouse button while the mouse cursor is on a divider in the header control). This notification code is sent
			/// in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_BEGINTRACK pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHEADER</c> structure that contains information about the header control and the item whose divider is to
			/// be dragged.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>FALSE</c> to allow tracking of the divider, or <c>TRUE</c> to prevent tracking.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-begintrack
			HDN_BEGINTRACK = HDN_FIRST - 26,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that the user double-clicked the divider area of the control. This notification
			/// code is sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_DIVIDERDBLCLICK pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHEADER</c> structure that contains information about the header control and the item whose divider was double-clicked.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-dividerdblclick
			HDN_DIVIDERDBLCLICK = HDN_FIRST - 25,

			/// <summary>
			/// <para>
			/// Sent by a header control to its parent when the drop-down arrow on the header control is clicked. This notification code is
			/// sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_DROPDOWN pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>A pointer to an <c>NMHEADER</c> structure that contains information on the header control.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// The example in the Syntax section shows how the notification receiver casts <c>LPARAM</c> to retrieve the <c>NMHEADER</c>
			/// structure. <c>WPARAM</c> contains the ID of the control that sends this message.
			/// </para>
			/// <para>This message is sent only if style HDF_SPLITBUTTON is set on the header item.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-dropdown
			HDN_DROPDOWN = HDN_FIRST - 18,

			/// <summary>
			/// <para>
			/// Sent by a header control when a drag operation has ended on one of its items. This notification code is sent as a
			/// <c>WM_NOTIFY</c> message. Only header controls that are set to the <c>HDS_DRAGDROP</c> style send this notification code.
			/// </para>
			/// <para>
			/// <code>HDN_ENDDRAG pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>A pointer to an <c>NMHEADER</c> structure containing information about the header item that was being dragged.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// To allow the control to automatically place and reorder the item, return <c>FALSE</c>. To prevent the item from being placed,
			/// return <c>TRUE</c>.
			/// </para>
			/// </summary>
			/// <remarks>
			/// If the owner is performing external (manual) drag-and-drop management, it must return <c>FALSE</c>. The owner then must
			/// reorder header items manually by sending <c>HDM_SETITEM</c> or <c>HDM_SETORDERARRAY</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-enddrag
			HDN_ENDDRAG = HDN_FIRST - 11,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that a filter edit has ended. This notification code is sent in the form of a
			/// <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_ENDFILTEREDIT pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>A pointer to an <c>NMHEADER</c> structure that contains additional information about the filter that is being edited.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-endfilteredit
			HDN_ENDFILTEREDIT = HDN_FIRST - 15,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that the user has finished dragging a divider. This notification code sent in the
			/// form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_ENDTRACK pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHEADER</c> structure that contains information about the header control and the item whose divider was dragged.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-endtrack
			HDN_ENDTRACK = HDN_FIRST - 27,

			/// <summary>
			/// <para>
			/// Notifies the header control's parent window when the filter button is clicked or in response to an <c>HDM_SETITEM</c>
			/// message. This notification code sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_FILTERBTNCLICK pNMHDFilterBtnClk = (LPNMHDFILTERBTNCLICK) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHDFILTERBTNCLICK</c> structure that contains information about the header control and the header filter button.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// If you return <c>TRUE</c>, an HDN_FILTERCHANGE notification code will be sent to the header control's parent window. This
			/// notification code gives the parent window an opportunity to synchronize its user interface elements. Return <c>FALSE</c> if
			/// you do not want the notification sent.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-filterbtnclick
			HDN_FILTERBTNCLICK = HDN_FIRST - 13,

			/// <summary>
			/// <para>
			/// Notifies the header control's parent window that the attributes of a header control filter are being changed or edited. This
			/// notification code sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_FILTERCHANGE pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHEADER</c> structure that contains information about the header control and the header item, including
			/// the attributes that are about to change.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-filterchange
			HDN_FILTERCHANGE = HDN_FIRST - 12,

			/// <summary>
			/// <para>
			/// Sent to the owner of a header control when the control needs information about a callback header item. This notification code
			/// is sent as a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_GETDISPINFO pNMHDDispInfo = (LPNMHDDISPINFO) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHDDISPINFO</c> structure. On input, the fields of the structure specify what information is required and
			/// the item of interest.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns an LRESULT.</para>
			/// </summary>
			/// <remarks>
			/// Fill the appropriate members of the structure to return the requested information to the header control. If your message
			/// handler sets the <c>mask</c> member of the <c>NMHDDISPINFO</c> structure to HDI_DI_SETITEM, the header control stores the
			/// information and will not request it again.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-getdispinfo
			HDN_GETDISPINFO = HDN_FIRST - 29,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that the attributes of a header item have changed. This notification code is sent
			/// in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_ITEMCHANGED pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHEADER</c> structure that contains information about the header control, including the attributes that
			/// have changed.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-itemchanged
			HDN_ITEMCHANGED = HDN_FIRST - 21,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that the attributes of a header item are about to change. This notification code is
			/// sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_ITEMCHANGING pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHEADER</c> structure that contains information about the header control and the header item, including
			/// the attributes that are about to change.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>FALSE</c> to allow the changes, or <c>TRUE</c> to prevent them.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-itemchanging
			HDN_ITEMCHANGING = HDN_FIRST - 20,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that the user clicked the control. This notification code is sent in the form of a
			/// <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_ITEMCLICK pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHEADER</c> structure that identifies the header control and specifies the index of the header item that
			/// was clicked and the mouse button used to click the item. The <c>pItem</c> member is set to <c>NULL</c>.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>A header control sends this notification code after the user releases the left mouse button.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-itemclick
			HDN_ITEMCLICK = HDN_FIRST - 22,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that the user double-clicked the control. This notification code is sent in the
			/// form of a <c>WM_NOTIFY</c> message. Only header controls that are set to the <c>HDS_BUTTONS</c> style send this notification code.
			/// </para>
			/// <para>
			/// <code>HDN_ITEMDBLCLICK pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>A pointer to an <c>NMHEADER</c> structure that contains information about this notification code.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-itemdblclick
			HDN_ITEMDBLCLICK = HDN_FIRST - 23,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that a key has been pressed with an item selected. This notification code is sent
			/// in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_ITEMKEYDOWN pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>A pointer to an <c>NMHEADER</c> structure that contains additional information about the key that is being pressed.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-itemkeydown
			HDN_ITEMKEYDOWN = HDN_FIRST - 17,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that the user clicked an item's state icon. This notification code is sent in the
			/// form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_ITEMSTATEICONCLICK pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHEADER</c> structure that contains additional information about the state icon that was clicked on.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-itemstateiconclick
			HDN_ITEMSTATEICONCLICK = HDN_FIRST - 16,

			/// <summary>
			/// <para>
			/// Sent by a header control to its parent when the header's overflow button is clicked. This notification code is sent in the
			/// form of an <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_OVERFLOWCLICK pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to a <c>NMHEADER</c> structure that describes the notification code. The calling process is responsible for
			/// allocating this structure, including the contained <c>NMHDR</c> structure. Set the members of the <c>NMHDR</c> structure,
			/// including the code member that must be set to HDN_OVERFLOWCLICK.
			/// </para>
			/// <para>
			/// Set the <c>iItem</c> member of the <c>NMHEADER</c> structure to the index of the first header item that is not visible and
			/// thus should be displayed on an overflow.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// The notification receiver casts <c>LPARAM</c> to retrieve the <c>NMHEADER</c> structure. <c>WPARAM</c> contains the ID of the
			/// control that sends the notification.
			/// </para>
			/// <para>This message is sent only when style <c>HDS_OVERFLOW</c> is set on the header control.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-overflowclick
			HDN_OVERFLOWCLICK = HDN_FIRST - 19,

			/// <summary>
			/// <para>
			/// Notifies a header control's parent window that the user is dragging a divider in the header control. This notification code
			/// is sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>HDN_TRACK pNMHeader = (LPNMHEADER) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// A pointer to an <c>NMHEADER</c> structure that contains information about the header control and the item whose divider is
			/// being dragged.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>FALSE</c> to continue tracking the divider, or <c>TRUE</c> to end tracking.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/hdn-track
			HDN_TRACK = HDN_FIRST - 28,
		}

		/// <summary>
		/// Header controls have a number of styles, described in this section, that determine the control's appearance and behavior. You set
		/// the initial styles when you create the header control.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775241")]
		[Flags]
		public enum HeaderStyle
		{
			/// <summary>
			/// Each item in the control looks and behaves like a push button. This style is useful if an application carries out a task when
			/// the user clicks an item in the header control. For example, an application could sort information in the columns differently
			/// depending on which item the user clicks.
			/// </summary>
			HDS_BUTTONS = 0x0002,

			/// <summary>Allows drag-and-drop reordering of header items.</summary>
			HDS_DRAGDROP = 0x0040,

			/// <summary>
			/// Include a filter bar as part of the standard header control. This bar allows users to conveniently apply a filter to the
			/// display. Calls to HDM_LAYOUT will yield a new size for the control and cause the list view to update.
			/// </summary>
			HDS_FILTERBAR = 0x0100,

			/// <summary>
			/// Version 6.0 and later. Causes the header control to be drawn flat when the operating system is running in classic mode.
			/// <note>Comctl32.dll version 6 is not redistributable but it is included in Windows. To use Comctl32.dll version 6, specify it
			/// in a manifest. For more information on manifests, see Enabling Visual Styles.</note>
			/// </summary>
			HDS_FLAT = 0x0200,

			/// <summary>Causes the header control to display column contents even while the user resizes a column.</summary>
			HDS_FULLDRAG = 0x0080,

			/// <summary>
			/// Indicates a header control that is intended to be hidden. This style does not hide the control. Instead, when you send the
			/// HDM_LAYOUT message to a header control with the HDS_HIDDEN style, the control returns zero in the cy member of the WINDOWPOS
			/// structure. You would then hide the control by setting its height to zero. This can be useful when you want to use the control
			/// as an information container instead of a visual control.
			/// </summary>
			HDS_HIDDEN = 0x0008,

			/// <summary>Creates a header control with a horizontal orientation.</summary>
			HDS_HORZ = 0x0000,

			/// <summary>Enables hot tracking.</summary>
			HDS_HOTTRACK = 0x0004,

			/// <summary>
			/// Version 6.00 and later. Allows the placing of checkboxes on header items. For more information, see the fmt member of HDITEM.
			/// </summary>
			HDS_CHECKBOXES = 0x0400,

			/// <summary>Version 6.00 and later. The user cannot drag the divider on the header control.</summary>
			HDS_NOSIZING = 0x0800,

			/// <summary>
			/// Version 6.00 and later. A button is displayed when not all items can be displayed within the header control's rectangle. When
			/// clicked, this button sends an HDN_OVERFLOWCLICK notification.
			/// </summary>
			HDS_OVERFLOW = 0x1000,
		}

		/// <summary>Contains information about header control text filters.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775251")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct HDTEXTFILTER
		{
			/// <summary>A pointer to the buffer containing the filter.</summary>
			public string pszText;

			/// <summary>A value specifying the maximum size, in characters, for an edit control buffer.</summary>
			public int cchTextMax;

			/// <summary>Initializes a new instance of the <see cref="HDTEXTFILTER"/> struct.</summary>
			/// <param name="filter">The filter.</param>
			public HDTEXTFILTER(string filter)
			{
				pszText = filter;
				cchTextMax = filter.Length;
			}

			/// <summary>Initializes a new instance of the <see cref="HDTEXTFILTER"/> struct.</summary>
			/// <param name="length">The length.</param>
			public HDTEXTFILTER(int length) : this(new string('\0', length))
			{
			}

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => pszText;
		}

		/// <summary>
		/// Contains information about a hit test. This structure is used with the HDM_HITTEST message and it supersedes the HD_HITTESTINFO structure.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775245")]
		[StructLayout(LayoutKind.Sequential)]
		public sealed class HDHITTESTINFO
		{
			/// <summary>A POINT structure that contains the point to be hit test, in client coordinates.</summary>
			public POINT pt;

			/// <summary>
			/// The variable that receives information about the results of a hit test. Two of these values can be combined, such as when the
			/// position is above and to the left of the client area.
			/// </summary>
			public HeaderHitTestFlag flags;

			/// <summary>If the hit test is successful, contains the index of the item at the hit test point.</summary>
			public int iItem;
		}

		/// <summary>Contains information about an item in a header control. This structure supersedes the HD_ITEM structure.</summary>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775247")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public sealed class HDITEM : IDisposable
		{
			/// <summary>Flags indicating which other structure members contain valid data or must be filled in.</summary>
			public HeaderItemMask mask = 0;

			/// <summary>The width or height of the item.</summary>
			public int cxy;

			/// <summary>
			/// A pointer to an item string. If the text is being retrieved from the control, this member must be initialized to point to a
			/// character buffer. If this member is set to LPSTR_TEXTCALLBACK, the control will request text information for this item by
			/// sending an HDN_GETDISPINFO notification code. Note that although the header control allows a string of any length to be
			/// stored as item text, only the first 260 TCHARs are displayed.
			/// </summary>
			public StrPtrAuto pszText;

			/// <summary>A handle to the item bitmap.</summary>
			public HBITMAP hbm = IntPtr.Zero;

			/// <summary>
			/// The length of the item string, in TCHARs. If the text is being retrieved from the control, this member must contain the
			/// number of TCHARs at the address specified by pszText.
			/// </summary>
			public uint cchTextMax;

			/// <summary>Flags that specify the item's format.</summary>
			public HeaderItemFormat fmt = 0;

			/// <summary>Application-defined item data.</summary>
			public IntPtr lParam = IntPtr.Zero;

			/// <summary>
			/// The zero-based index of an image within the image list. The specified image will be displayed in the header item in addition
			/// to any image specified in the hbm field. If iImage is set to I_IMAGECALLBACK, the control requests text information for this
			/// item by using an HDN_GETDISPINFO notification code. To clear the image, set this value to I_IMAGENONE.
			/// </summary>
			public int iImage;

			/// <summary>
			/// The order in which the item appears within the header control, from left to right. That is, the value for the far left item
			/// is 0. The value for the next item to the right is 1, and so on.
			/// </summary>
			public int iOrder;

			/// <summary>The type of filter specified by pvFilter.</summary>
			public HeaderItemFilterType type;

			/// <summary>
			/// The address of an application-defined data item. The data filter type is determined by setting the flag value of the member.
			/// Use the HDFT_ISSTRING flag to indicate a string and HDFT_ISNUMBER to indicate an integer. When the HDFT_ISSTRING flag is used
			/// pvFilter is a pointer to a HDTEXTFILTER structure.
			/// </summary>
			public IntPtr pvFilter = IntPtr.Zero;

			/// <summary>The state.</summary>
			public HeaderItemState state;

			/// <summary>Initializes a new instance of the <see cref="HDITEM"/> class.</summary>
			/// <param name="mask">The mask.</param>
			public HDITEM(HeaderItemMask mask = HeaderItemMask.HDI_ALL)
			{
				if (mask.IsFlagSet(HeaderItemMask.HDI_TEXT))
					pszText = new StrPtrAuto(cchTextMax = 1024);
			}

			/// <summary>Initializes a new instance of the <see cref="HDITEM"/> class.</summary>
			/// <param name="text">The text.</param>
			public HDITEM(string text = null) => Text = text;

			/// <summary>Gets or sets a value indicating whether this <see cref="HDITEM"/> is checked.</summary>
			/// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
			public bool Checked
			{
				get => fmt.IsFlagSet(HeaderItemFormat.HDF_CHECKED);
				set { EnumExtensions.SetFlags(ref fmt, HeaderItemFormat.HDF_CHECKED, value); EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT); }
			}

			/// <summary>Gets or sets the filter. This value must be a string, integer, DateTime or SYSTEMTIME.</summary>
			/// <value>The filter.</value>
			public object Filter
			{
				get
				{
					if (!mask.IsFlagSet(HeaderItemMask.HDI_FILTER))
						return null;
					switch (type)
					{
						case HeaderItemFilterType.HDFT_ISSTRING:
							return pvFilter.ToStructure<HDTEXTFILTER>().ToString();

						case HeaderItemFilterType.HDFT_ISNUMBER:
							return pvFilter.ToInt32();

						case HeaderItemFilterType.HDFT_ISDATE:
							return pvFilter.ToStructure<SYSTEMTIME>().ToDateTime(DateTimeKind.Unspecified);

						case HeaderItemFilterType.HDFT_HASNOVALUE:
							return null;

						default:
							throw new InvalidOperationException();
					}
				}
				set
				{
					switch (value)
					{
						case null:
							type = HeaderItemFilterType.HDFT_HASNOVALUE;
							Marshal.FreeCoTaskMem(pvFilter);
							pvFilter = IntPtr.Zero;
							break;

						case DateTime dt:
							pvFilter = new SYSTEMTIME(dt).MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
							type = HeaderItemFilterType.HDFT_ISDATE;
							break;

						case string str:
							pvFilter = new HDTEXTFILTER(str).MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
							type = HeaderItemFilterType.HDFT_ISSTRING;
							break;

						case int i:
							pvFilter = new IntPtr(i);
							type = HeaderItemFilterType.HDFT_ISNUMBER;
							break;

						case SYSTEMTIME st:
							pvFilter = st.MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
							type = HeaderItemFilterType.HDFT_ISDATE;
							break;

						default:
							throw new ArgumentException("Value must be a string, integer, DateTime or SYSTEMTIME");
					}
					EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FILTER);
				}
			}

			/// <summary>Gets or sets a value indicating whether the header is fixed width.</summary>
			/// <value><c>true</c> if fixed width; otherwise, <c>false</c>.</value>
			public bool FixedWidth
			{
				get => fmt.IsFlagSet(HeaderItemFormat.HDF_FIXEDWIDTH);
				set { EnumExtensions.SetFlags(ref fmt, HeaderItemFormat.HDF_FIXEDWIDTH, value); EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT); }
			}

			/// <summary>Gets or sets a value indicating whether this header is focused.</summary>
			/// <value><c>true</c> if focused; otherwise, <c>false</c>.</value>
			public bool Focused
			{
				get => state == HeaderItemState.HDIS_FOCUSED;
				set { state = value ? HeaderItemState.HDIS_FOCUSED : HeaderItemState.None; EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_STATE); }
			}

			/// <summary>Gets or sets the header format.</summary>
			/// <value>The format.</value>
			public HeaderItemFormat Format
			{
				get => fmt;
				set { fmt = value; EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT); }
			}

			/// <summary>Gets or sets a value indicating whether the bitmap is on the right.</summary>
			/// <value><c>true</c> if bitmap is on the right; otherwise, <c>false</c>.</value>
			public bool BitmapRightToLeft
			{
				get => fmt.IsFlagSet(HeaderItemFormat.HDF_BITMAP_ON_RIGHT);
				set { EnumExtensions.SetFlags(ref fmt, HeaderItemFormat.HDF_BITMAP_ON_RIGHT, value); EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT); }
			}

			/// <summary>Gets or sets the how the image is displayed.</summary>
			/// <value>How the image is displayed.</value>
			public HeaderItemImageDisplay ImageDisplay
			{
				get
				{
					if (fmt.IsFlagSet(HeaderItemFormat.HDF_BITMAP))
						return HeaderItemImageDisplay.Bitmap;
					if (fmt.IsFlagSet(HeaderItemFormat.HDF_IMAGE))
						return HeaderItemImageDisplay.ImageListItem;
					if (fmt.IsFlagSet(HeaderItemFormat.HDF_SORTDOWN))
						return HeaderItemImageDisplay.DownArrow;
					if (fmt.IsFlagSet(HeaderItemFormat.HDF_SORTUP))
						return HeaderItemImageDisplay.UpArrow;
					return HeaderItemImageDisplay.None;
				}
				set
				{
					const HeaderItemFormat imgMask = HeaderItemFormat.HDF_BITMAP | HeaderItemFormat.HDF_IMAGE | HeaderItemFormat.HDF_SORTUP | HeaderItemFormat.HDF_SORTDOWN;
					EnumExtensions.SetFlags(ref fmt, imgMask, false);
					EnumExtensions.SetFlags(ref fmt, (HeaderItemFormat)value);
					EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT);
				}
			}

			/// <summary>Gets or sets the index of the image in the image list.</summary>
			/// <value>The index of the image.</value>
			public int ImageIndex
			{
				get => iImage;
				set { iImage = value; EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_IMAGE); }
			}

			/// <summary>Gets or sets an application defined value.</summary>
			/// <value>The parameter.</value>
			public IntPtr LParam
			{
				get => lParam;
				set { lParam = value; EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_LPARAM); }
			}

			/// <summary>Gets or sets the order in which the item appears in the header.</summary>
			/// <value>The order.</value>
			public int Order
			{
				get => iOrder;
				set { iOrder = value; EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_ORDER); }
			}

			/// <summary>Gets or sets a value indicating whether the header item is owner drawn.</summary>
			/// <value><c>true</c> if owner drawn; otherwise, <c>false</c>.</value>
			public bool OwnerDrawn
			{
				get => fmt.IsFlagSet(HeaderItemFormat.HDF_OWNERDRAW);
				set { EnumExtensions.SetFlags(ref fmt, HeaderItemFormat.HDF_OWNERDRAW, value); EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT); }
			}

			/// <summary>Gets or sets a value indicating whether header text is displayed right to left.</summary>
			/// <value><c>true</c> if right to left; otherwise, <c>false</c>.</value>
			public bool RightToLeft
			{
				get => fmt.IsFlagSet(HeaderItemFormat.HDF_RTLREADING);
				set { EnumExtensions.SetFlags(ref fmt, HeaderItemFormat.HDF_RTLREADING, value); EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT); }
			}

			/// <summary>Gets or sets a value indicating whether to show a checkbox.</summary>
			/// <value><c>true</c> if shows checkbox; otherwise, <c>false</c>.</value>
			public bool ShowCheckbox
			{
				get => fmt.IsFlagSet(HeaderItemFormat.HDF_CHECKBOX);
				set { EnumExtensions.SetFlags(ref fmt, HeaderItemFormat.HDF_CHECKBOX, value); EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT); }
			}

			/// <summary>Gets or sets a value indicating whether to show a split button.</summary>
			/// <value><c>true</c> if showing a split button; otherwise, <c>false</c>.</value>
			public bool ShowSplitButton
			{
				get => fmt.IsFlagSet(HeaderItemFormat.HDF_SPLITBUTTON);
				set { EnumExtensions.SetFlags(ref fmt, HeaderItemFormat.HDF_SPLITBUTTON, value); EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT); }
			}

			/// <summary>Gets or sets a value indicating whether to show text.</summary>
			/// <value><c>true</c> if showing text; otherwise, <c>false</c>.</value>
			public bool ShowText
			{
				get => fmt.IsFlagSet(HeaderItemFormat.HDF_STRING);
				set { EnumExtensions.SetFlags(ref fmt, HeaderItemFormat.HDF_STRING, value); EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT); }
			}

			/// <summary>Gets or sets the text.</summary>
			/// <value>The text.</value>
			/// <exception cref="System.ArgumentOutOfRangeException">Text - A header control will only display the first 260 characters.</exception>
			public string Text
			{
				get => mask.IsFlagSet(HeaderItemMask.HDI_TEXT) ? pszText.ToString() : null;
				set
				{
					if (value != null && value.Length > Kernel32.MAX_PATH) throw new ArgumentOutOfRangeException(nameof(Text), @"A header control will only display the first 260 characters.");
					EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_TEXT, pszText.Assign(value, out cchTextMax));
				}
			}

			/// <summary>Gets or sets the text alignment.</summary>
			/// <value>The text alignment.</value>
			public HeaderItemFormat TextAlignment
			{
				get => fmt & HeaderItemFormat.HDF_JUSTIFYMASK;
				set
				{
					value = value & HeaderItemFormat.HDF_JUSTIFYMASK;
					EnumExtensions.SetFlags(ref fmt, HeaderItemFormat.HDF_JUSTIFYMASK, false);
					EnumExtensions.SetFlags(ref fmt, value);
					EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_FORMAT);
				}
			}

			/// <summary>
			/// Gets or sets a value indicating whether this header requests a callback message to retrieve the text. <note>Setting this
			/// value to either true or false will remove any previously set value for the <see cref="Text"/> property or <see
			/// cref="pszText"/> field.</note>
			/// </summary>
			/// <value><c>true</c> if using text callback; otherwise, <c>false</c>.</value>
			public bool UseTextCallback
			{
				get => mask.IsFlagSet(HeaderItemMask.HDI_TEXT) && (IntPtr)pszText == LPSTR_TEXTCALLBACK;
				set { EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_TEXT, value); pszText.AssignConstant(value ? -1 : 0); }
			}

			/// <summary>Gets or sets the width.</summary>
			/// <value>The width.</value>
			public int Width
			{
				get => cxy;
				set { cxy = value; EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_WIDTH); }
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			public void Dispose()
			{
				pszText.Free();
				if (mask.IsFlagSet(HeaderItemMask.HDI_FILTER) && (type == 0 || type == HeaderItemFilterType.HDFT_ISSTRING))
					Marshal.FreeCoTaskMem(pvFilter);
			}
		}

		/// <summary>
		/// Contains information used to set the size and position of a header control. HDLAYOUT is used with the HDM_LAYOUT message. This
		/// structure supersedes the HD_LAYOUT structure.
		/// </summary>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775249")]
		[StructLayout(LayoutKind.Sequential)]
		public sealed class HDLAYOUT : IDisposable
		{
			/// <summary>Structure that contains the coordinates of a rectangle that the header control will occupy.</summary>
			public IntPtr prc;

			/// <summary>Structure that receives information about the appropriate size and position of the header control.</summary>
			public IntPtr pwpos;

			/// <summary>
			/// Initializes a new instance of the <see cref="HDLAYOUT"/> class setting the prc member and allocating memory for the pwpos member.
			/// </summary>
			/// <param name="rc">The coordinates of the header.</param>
			public HDLAYOUT(RECT rc)
			{
				prc = rc.MarshalToPtr(Marshal.AllocHGlobal, out var _);
				pwpos = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WINDOWPOS)));
			}

			/// <summary>Gets or sets the coordinates.</summary>
			/// <value>The coordinates.</value>
			public RECT Coordinates
			{
				get => prc.ToStructure<RECT>();
				set
				{
					Marshal.FreeHGlobal(prc);
					prc = value.MarshalToPtr(Marshal.AllocHGlobal, out var _);
				}
			}

			/// <summary>Gets the position.</summary>
			/// <value>The position.</value>
			public WINDOWPOS Position => pwpos.ToStructure<WINDOWPOS>();

			/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
			public void Dispose()
			{
				Marshal.FreeHGlobal(prc);
				Marshal.FreeHGlobal(pwpos);
			}
		}

		/// <summary>Contains information used in handling HDN_GETDISPINFO notification codes.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775253")]
		[StructLayout(LayoutKind.Sequential)]
		public sealed class NMHDDISPINFO
		{
			/// <summary>NMHDR structure containing information about this notification code</summary>
			public NMHDR hdr;

			/// <summary>The zero-based index of the item in the header control.</summary>
			public int iItem;

			/// <summary>A set of bit flags specifying which members of the structure must be filled in by the owner of the header control.</summary>
			public uint mask;

			/// <summary>A pointer to a null-terminated string containing the text that will be displayed for the header item.</summary>
			public StrPtrAuto pszText;

			/// <summary>The size of the buffer that pszText points to.</summary>
			public int cchTextMax;

			/// <summary>
			/// The zero-based index of an image within the image list. The specified image will be displayed with the header item, but it
			/// does not take the place of the item's bitmap. If iImage is set to I_IMAGECALLBACK, the control requests image information for
			/// this item by using an HDN_GETDISPINFO notification code.
			/// </summary>
			public int iImage;

			/// <summary>An application-defined value to associate with the item.</summary>
			public IntPtr lParam = IntPtr.Zero;
		}

		/// <summary>Specifies or receives the attributes of a filter button click.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775255")]
		[StructLayout(LayoutKind.Sequential)]
		public sealed class NMHDFILTERBTNCLICK
		{
			/// <summary>A handle of an NMHDR structure that contains additional information.</summary>
			public NMHDR hdr;

			/// <summary>The zero-based index of the control to which this structure refers.</summary>
			public int iItem;

			/// <summary>A pointer to a RECT structure that contains the client rectangle for the filter button.</summary>
			public RECT rc;
		}

		/// <summary>Contains information about header control notification messages. This structure supersedes the HD_NOTIFY structure.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775257")]
		[StructLayout(LayoutKind.Sequential)]
		public sealed class NMHEADER
		{
			/// <summary>A NMHDR structure that contains information about the notification message.</summary>
			public NMHDR nmhdr;

			/// <summary>The zero-based index of the header item that is the focus of the notification message.</summary>
			public int iItem;

			/// <summary>
			/// A value specifying the index of the mouse button used to generate the notification message. This member can be one of the
			/// following values:
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <description>Left button</description>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <description>Right button</description>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <description>Middle button</description>
			/// </item>
			/// </list>
			/// </summary>
			public int iButton;

			/// <summary>
			/// An optional pointer to an HDITEM structure containing information about the item specified by iItem. The mask member of the
			/// HDITEM structure indicates which of its members are valid.
			/// </summary>
			public IntPtr pItem = IntPtr.Zero;
		}
	}
}