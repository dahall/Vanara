using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.User32;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
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
			/// The point is on the divider of an item that has a width of zero. Dragging the divider reveals the item instead of resizing the item to the left
			/// of the divider.
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
			/// <summary>The point is within the state icon of the item. If style HDS_CHECKBOXES is specified, the point is within the checkbox of the item.</summary>
			HHT_ONITEMSTATEICON = 0x1000,
			/// <summary>The point is within the overflow button of the header control. The style HDS_OVERFLOW must be set on the header control.</summary>
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
			/// Typically, windows displays text left-to-right (LTR). Windows can be mirrored to display languages such as Hebrew or Arabic that read
			/// right-to-left (RTL). Usually, header text is read in the same direction as the text in its parent window. If HDF_RTLREADING is set, header text
			/// will read in the opposite direction from the text in the parent window.
			/// </summary>
			HDF_RTLREADING = 0x0004,
			/// <summary>The item displays a checkbox. The flag is only valid when the HDS_CHECKBOXES style is first set on the header control.</summary>
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
			/// Display an image from an image list. Specify the image list by sending an HDM_SETIMAGELIST message. Specify the index of the image in the iImage
			/// member of this structure.
			/// </summary>
			HDF_IMAGE = 0x0800,
			/// <summary>
			/// Draws an up-arrow on this item. This is typically used to indicate that information in the current window is sorted on this column in ascending
			/// order. This flag cannot be combined with HDF_IMAGE or HDF_BITMAP.
			/// </summary>
			HDF_SORTUP = 0x0400,
			/// <summary>
			/// Draws a down-arrow on this item. This is typically used to indicate that information in the current window is sorted on this column in descending
			/// order. This flag cannot be combined with HDF_IMAGE or HDF_BITMAP.
			/// </summary>
			HDF_SORTDOWN = 0x0200,
			/// <summary>The item displays a split button. The HDN_DROPDOWN notification is sent when the split button is clicked.</summary>
			HDF_SPLITBUTTON = 0x1000000
		}

		[Flags]
		public enum HeaderItemImageDisplay
		{
			None,
			Bitmap = 0x2000,
			ImageListItem = 0x0800,
			DownArrow = 0x0200,
			UpArrow = 0x0400,
		}

		/// <summary>Flags indicating which <see cref="HDITEM"/> structure members contain valid data or must be filled in.</summary>
		[Flags]
		public enum HeaderItemMask : uint
		{
			/// <summary>The <see cref="HDITEM.hbm"/> member is valid.</summary>
			HDI_BITMAP = 0x0010,
			/// <summary>
			/// While handling the message HDM_GETITEM, the header control may not have all the values needed to complete the request. In this case, the control
			/// must call the application back for the values via the HDN_GETDISPINFO notification. If HDI_DI_SETITEM has been passed in the HDM_GETITEM message,
			/// the control will cache any values returned from HDN_GETDISPINFO (otherwise the values remain unset.)
			/// </summary>
			HDI_DI_SETITEM = 0x0040,
			/// <summary>
			/// The <see cref="HDITEM.type"/> and <see cref="HDITEM.pvFilter"/> members are valid. This is used to filter out the values specified in the type member.
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

		public enum HeaderMessage
		{
			HDM_CLEARFILTER = HDM_FIRST + 24, // int, 0
			HDM_CREATEDRAGIMAGE = HDM_FIRST + 16, // int, 0
			HDM_DELETEITEM = HDM_FIRST + 2, // int, 0
			HDM_EDITFILTER = HDM_FIRST + 23, // int, bool
			HDM_GETBITMAPMARGIN = HDM_FIRST + 21, // 0,0
			HDM_GETFOCUSEDITEM = HDM_FIRST + 27, // 0,0
			HDM_GETIMAGELIST = HDM_FIRST + 9, // 0, 0
			HDM_GETITEM = HDM_FIRST + 11, // int, HDITEM
			HDM_GETITEMCOUNT = HDM_FIRST + 0, // 0, 0
			HDM_GETITEMDROPDOWNRECT = HDM_FIRST + 25, // int, RECT
			HDM_GETITEMRECT = HDM_FIRST + 7, // int, RECT*
			HDM_GETORDERARRAY = HDM_FIRST + 17, // iCount, lpArray
			HDM_GETOVERFLOWRECT = HDM_FIRST + 26, // 0, RECT*
			HDM_GETUNICODEFORMAT = 0X2006,        // CCM_GETUNICODEFORMAT,
			HDM_HITTEST = HDM_FIRST + 6, // 0, HDHITTEST
			HDM_INSERTITEM = HDM_FIRST + 10, // int, HDITEM
			HDM_LAYOUT = HDM_FIRST + 5, // 0, HDLAYOUT
			HDM_ORDERTOINDEX = HDM_FIRST + 15, // int, 0
			HDM_SETBITMAPMARGIN = HDM_FIRST + 20,// iWidth, 0
			HDM_SETFILTERCHANGETIMEOUT = HDM_FIRST + 22, // 0, int
			HDM_SETFOCUSEDITEM = HDM_FIRST + 28, // 0, int
			HDM_SETHOTDIVIDER = HDM_FIRST + 19, // bool, int
			HDM_SETIMAGELIST = HDM_FIRST + 8, // HDSIL_, hImageList
			HDM_SETITEM = HDM_FIRST + 12, // int, HDITEM
			HDM_SETORDERARRAY = HDM_FIRST + 18, // iCount, lpArray
			HDM_SETUNICODEFORMAT = 0X2005,        // CCM_SETUNICODEFORMAT,
		}

		public enum HeaderNotification
		{
			HDN_BEGINDRAG = HDN_FIRST - 10,
			HDN_BEGINFILTEREDIT = HDN_FIRST - 14,
			HDN_BEGINTRACK = HDN_FIRST - 26,
			HDN_DIVIDERDBLCLICK = HDN_FIRST - 25,
			HDN_DROPDOWN = HDN_FIRST - 18,
			HDN_ENDDRAG = HDN_FIRST - 11,
			HDN_ENDFILTEREDIT = HDN_FIRST - 15,
			HDN_ENDTRACK = HDN_FIRST - 27,
			HDN_FILTERBTNCLICK = HDN_FIRST - 13,
			HDN_FILTERCHANGE = HDN_FIRST - 12,
			HDN_GETDISPINFO = HDN_FIRST - 29,
			HDN_ITEMCHANGED = HDN_FIRST - 21,
			HDN_ITEMCHANGING = HDN_FIRST - 20,
			HDN_ITEMCLICK = HDN_FIRST - 22,
			HDN_ITEMDBLCLICK = HDN_FIRST - 23,
			HDN_ITEMKEYDOWN = HDN_FIRST - 17,
			HDN_ITEMSTATEICONCLICK = HDN_FIRST - 16,
			HDN_OVERFLOWCLICK = HDN_FIRST - 19,
			HDN_TRACK = HDN_FIRST - 28,
		}

		/// <summary>Contains information about a hit test. This structure is used with the HDM_HITTEST message and it supersedes the HD_HITTESTINFO structure.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775245")]
		[StructLayout(LayoutKind.Sequential)]
		public sealed class HDHITTESTINFO
		{
			/// <summary>A POINT structure that contains the point to be hit test, in client coordinates.</summary>
			public Point pt;
			/// <summary>
			/// The variable that receives information about the results of a hit test. Two of these values can be combined, such as when the position is above
			/// and to the left of the client area.
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
			/// A pointer to an item string. If the text is being retrieved from the control, this member must be initialized to point to a character buffer. If
			/// this member is set to LPSTR_TEXTCALLBACK, the control will request text information for this item by sending an HDN_GETDISPINFO notification
			/// code. Note that although the header control allows a string of any length to be stored as item text, only the first 260 TCHARs are displayed.
			/// </summary>
			public StrPtrAuto pszText;
			/// <summary>A handle to the item bitmap.</summary>
			public IntPtr hbm = IntPtr.Zero;
			/// <summary>
			/// The length of the item string, in TCHARs. If the text is being retrieved from the control, this member must contain the number of TCHARs at the
			/// address specified by pszText.
			/// </summary>
			public uint cchTextMax;
			/// <summary>Flags that specify the item's format.</summary>
			public HeaderItemFormat fmt = 0;
			/// <summary>Application-defined item data.</summary>
			public IntPtr lParam = IntPtr.Zero;
			/// <summary>
			/// The zero-based index of an image within the image list. The specified image will be displayed in the header item in addition to any image
			/// specified in the hbm field. If iImage is set to I_IMAGECALLBACK, the control requests text information for this item by using an HDN_GETDISPINFO
			/// notification code. To clear the image, set this value to I_IMAGENONE.
			/// </summary>
			public int iImage;
			/// <summary>
			/// The order in which the item appears within the header control, from left to right. That is, the value for the far left item is 0. The value for
			/// the next item to the right is 1, and so on.
			/// </summary>
			public int iOrder;
			/// <summary>The type of filter specified by pvFilter.</summary>
			public HeaderItemFilterType type;
			/// <summary>
			/// The address of an application-defined data item. The data filter type is determined by setting the flag value of the member. Use the
			/// HDFT_ISSTRING flag to indicate a string and HDFT_ISNUMBER to indicate an integer. When the HDFT_ISSTRING flag is used pvFilter is a pointer to a
			/// HDTEXTFILTER structure.
			/// </summary>
			public IntPtr pvFilter = IntPtr.Zero;
			/// <summary>The state.</summary>
			public HeaderItemState state;

			/// <summary>Initializes a new instance of the <see cref="HDITEM"/> class.</summary>
			/// <param name="mask">The mask.</param>
			[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
			public HDITEM(HeaderItemMask mask = HeaderItemMask.HDI_ALL)
			{
				if (mask.IsFlagSet(HeaderItemMask.HDI_TEXT))
					pszText = new StrPtrAuto(cchTextMax = 1024);
			}

			/// <summary>Initializes a new instance of the <see cref="HDITEM"/> class.</summary>
			/// <param name="text">The text.</param>
			public HDITEM(string text = null)
			{
				Text = text;
			}

			/// <summary>Gets or sets the bitmap. Aligned to the <see cref="hbm"/> field.</summary>
			public Bitmap Bitmap
			{
				get => hbm == IntPtr.Zero ? null : Image.FromHbitmap(hbm);
				set { hbm = value?.GetHbitmap() ?? IntPtr.Zero; EnumExtensions.SetFlags(ref mask, HeaderItemMask.HDI_BITMAP); }
			}

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
							pvFilter = new SYSTEMTIME(dt).StructureToPtr(Marshal.AllocCoTaskMem, out int _);
							type = HeaderItemFilterType.HDFT_ISDATE;
							break;
						case string str:
							pvFilter = new HDTEXTFILTER(str).StructureToPtr(Marshal.AllocCoTaskMem, out int _);
							type = HeaderItemFilterType.HDFT_ISSTRING;
							break;
						case int i:
							pvFilter = new IntPtr(i);
							type = HeaderItemFilterType.HDFT_ISNUMBER;
							break;
						case SYSTEMTIME st:
							pvFilter = st.StructureToPtr(Marshal.AllocCoTaskMem, out int _);
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

			/// <summary>Gets or sets a value indicating whether this header requests a callback message to retrieve the text.
			/// <note>Setting this value to either true or false will remove any previously set value for the <see cref="Text"/> property or <see cref="pszText"/> field.</note></summary>
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
		/// Contains information used to set the size and position of a header control. HDLAYOUT is used with the HDM_LAYOUT message. This structure supersedes
		/// the HD_LAYOUT structure.
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

			/// <summary>Initializes a new instance of the <see cref="HDLAYOUT"/> class setting the prc member and allocating memory for the pwpos member.</summary>
			/// <param name="rc">The coordinates of the header.</param>
			public HDLAYOUT(RECT rc)
			{
				prc = rc.StructureToPtr(Marshal.AllocHGlobal, out int _);
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
					prc = value.StructureToPtr(Marshal.AllocHGlobal, out int _);
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

		/// <summary>Contains information about header control text filters.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775251")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct HDTEXTFILTER
		{
			/// <summary>A pointer to the buffer containing the filter.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszText;
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
			public IntPtr pszText = IntPtr.Zero;
			/// <summary>The size of the buffer that pszText points to.</summary>
			public int cchTextMax;
			/// <summary>
			/// The zero-based index of an image within the image list. The specified image will be displayed with the header item, but it does not take the
			/// place of the item's bitmap. If iImage is set to I_IMAGECALLBACK, the control requests image information for this item by using an HDN_GETDISPINFO
			/// notification code.
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
			/// A value specifying the index of the mouse button used to generate the notification message. This member can be one of the following values:
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
			/// An optional pointer to an HDITEM structure containing information about the item specified by iItem. The mask member of the HDITEM structure
			/// indicates which of its members are valid.
			/// </summary>
			public IntPtr pItem = IntPtr.Zero;
		}

		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, SetLastError = true)]
		public static extern IntPtr SendMessage(HandleRef hWnd, HeaderMessage message, [MarshalAs(UnmanagedType.SysInt)] int wParam, [In, Out] HDITEM item);

		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, SetLastError = true)]
		public static extern IntPtr SendMessage(HandleRef hWnd, HeaderMessage message, [MarshalAs(UnmanagedType.SysInt)] int wParam, [In, Out] HDLAYOUT layout);

		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, SetLastError = true)]
		public static extern IntPtr SendMessage(HandleRef hWnd, HeaderMessage message, [MarshalAs(UnmanagedType.SysInt)] int wParam, [In, Out] HDHITTESTINFO hittest);
	}
}