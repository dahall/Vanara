using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary>Window class name for the Toolbar control.</summary>
	public const string TOOLBARCLASSNAME = "ToolbarWindow32";

	/// <summary/>
	public static readonly IntPtr HINST_COMMCTRL = new(-1);

	private const int TBN_FIRST = -700;

	/// <summary>Options for CreateMappedBitmap.</summary>
	[PInvokeData("Commctrl.h")]
	public enum CMB
	{
		/// <summary>No flags</summary>
		CMB_NONE = 0,

		/// <summary>Uses a bitmap as a mask.</summary>
		CMB_MASKED = 2
	}

	/// <summary>Flags that indicate why the hot item has changed in NMTBHOTITEM.</summary>
	[PInvokeData("Commctrl.h")]
	[Flags]
	public enum HICF : uint
	{
		/// <summary>The change in the hot item was caused by a shortcut key.</summary>
		HICF_ACCELERATOR = 0x00000004,

		/// <summary>The change in the hot item was caused by an arrow key.</summary>
		HICF_ARROWKEYS = 0x00000002,

		/// <summary>Modifies HICF_ACCELERATOR. If this flag is set, more than one item has the same shortcut key character.</summary>
		HICF_DUPACCEL = 0x00000008,

		/// <summary>
		/// Modifies the other reason flags. If this flag is set, there is no previous hot item and idOld does not contain valid information.
		/// </summary>
		HICF_ENTERING = 0x00000010,

		/// <summary>Modifies the other reason flags. If this flag is set, there is no new hot item and idNew does not contain valid information.</summary>
		HICF_LEAVING = 0x00000020,

		/// <summary>The change in the hot item resulted from a left-click mouse event.</summary>
		HICF_LMOUSE = 0x00000080,

		/// <summary>The change in the hot item resulted from a mouse event.</summary>
		HICF_MOUSE = 0x00000001,

		/// <summary>
		/// The change in the hot item resulted from an event that could not be determined. This will most often be due to a change in focus
		/// or the TB_SETHOTITEM message.
		/// </summary>
		HICF_OTHER = 0x00000000,

		/// <summary>The change in the hot item resulted from the user entering the shortcut key for an item that was already hot.</summary>
		HICF_RESELECT = 0x00000040,

		/// <summary>Version 5.80. Causes the button to switch states.</summary>
		HICF_TOGGLEDROPDOWN = 0x00000100,
	}

	/// <summary>Index values for IDB_HIST_LARGE_COLOR and IDB_HIST_SMALL_COLOR</summary>
	[PInvokeData("Commctrl.h")]
	public enum HIST
	{
		/// <summary>Move back.</summary>
		HIST_BACK = 0,

		/// <summary>Move forward.</summary>
		HIST_FORWARD = 1,

		/// <summary>Open favorites folder.</summary>
		HIST_FAVORITES = 2,

		/// <summary>Add to favorites.</summary>
		HIST_ADDTOFAVORITES = 3,

		/// <summary>View tree.</summary>
		HIST_VIEWTREE = 4,
	}

	/// <summary>Identifier of a system-defined button image list. Used by TB_LOADIMAGES.</summary>
	[PInvokeData("Commctrl.h")]
	public enum IDB
	{
		/// <summary>Standard bitmaps in small size.</summary>
		IDB_STD_SMALL_COLOR = 0,

		/// <summary>Standard bitmaps in large size.</summary>
		IDB_STD_LARGE_COLOR = 1,

		/// <summary>View bitmaps in small size.</summary>
		IDB_VIEW_SMALL_COLOR = 4,

		/// <summary>View bitmaps in large size.</summary>
		IDB_VIEW_LARGE_COLOR = 5,

		/// <summary>Windows Explorer bitmaps in small size.</summary>
		IDB_HIST_SMALL_COLOR = 8,

		/// <summary>Windows Explorer bitmaps in large size.</summary>
		IDB_HIST_LARGE_COLOR = 9,

		/// <summary>Windows Explorer travel buttons and favorites bitmaps in normal state.</summary>
		IDB_HIST_NORMAL = 12,

		/// <summary>Windows Explorer travel buttons and favorites bitmaps in hot state.</summary>
		IDB_HIST_HOT = 13,

		/// <summary>Windows Explorer travel buttons and favorites bitmaps in disabled state.</summary>
		IDB_HIST_DISABLED = 14,

		/// <summary>Windows Explorer travel buttons and favorites bitmaps in pressed state.</summary>
		IDB_HIST_PRESSED = 15,
	}

	/// <summary>Index values for IDB_STD_LARGE_COLOR and IDB_STD_SMALL_COLOR</summary>
	[PInvokeData("Commctrl.h")]
	public enum STD
	{
		/// <summary>Cut operation.</summary>
		STD_CUT = 0,

		/// <summary>Copy operation.</summary>
		STD_COPY = 1,

		/// <summary>Paste operation.</summary>
		STD_PASTE = 2,

		/// <summary>Undo operation.</summary>
		STD_UNDO = 3,

		/// <summary>Redo operation.</summary>
		STD_REDOW = 4,

		/// <summary>Delete operation.</summary>
		STD_DELETE = 5,

		/// <summary>New file operation.</summary>
		STD_FILENEW = 6,

		/// <summary>Open file operation.</summary>
		STD_FILEOPEN = 7,

		/// <summary>Save file operation.</summary>
		STD_FILESAVE = 8,

		/// <summary>Print preview operation.</summary>
		STD_PRINTPRE = 9,

		/// <summary>Properties operation.</summary>
		STD_PROPERTIES = 10,

		/// <summary>Help operation.</summary>
		STD_HELP = 11,

		/// <summary>Find operation.</summary>
		STD_FIND = 12,

		/// <summary>Replace operation.</summary>
		STD_REPLACE = 13,

		/// <summary>Print operation.</summary>
		STD_PRINT = 14,
	}

	/// <summary>Flags for TB_GETBITMAPFLAGS.</summary>
	[PInvokeData("Commctrl.h")]
	[Flags]
	public enum TBBF : ushort
	{
		/// <summary>Applications should use small bitmaps (16 x 16)</summary>
		TBBF_SMALL = 0x0000,

		/// <summary>Applications should use large bitmaps (24 x 24)</summary>
		TBBF_LARGE = 0x0001,
	}

	/// <summary>
	/// The value your application can return depends on the current drawing stage. The <c>dwDrawStage</c> member of the associated
	/// <c>NMCUSTOMDRAW</c> structure holds a value that specifies the drawing stage. You must return one of the following values.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760492")]
	[Flags]
	public enum TBCDRF : uint
	{
		/// <summary>
		/// The control will draw itself. It will not send any additional NM_CUSTOMDRAW notification codes for this paint cycle. This occurs
		/// when dwDrawStage equals CDDS_PREPAINT.
		/// </summary>
		CDRF_DODEFAULT = 0x00000000,

		/// <summary>
		/// Your application specified a new font for the item; the control will use the new font. For more information on changing fonts,
		/// see Changing fonts and colors. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.
		/// </summary>
		CDRF_NEWFONT = 0x00000002,

		/// <summary>
		/// Your application drew the item manually. The control will not draw the item. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.
		/// </summary>
		CDRF_SKIPDEFAULT = 0x00000004,

		/// <summary>The control will notify the parent after painting an item. This occurs when dwDrawStage equals CDDS_PREPAINT.</summary>
		CDRF_NOTIFYPOSTPAINT = 0x00000010,

		/// <summary>
		/// The control will notify the parent of any item-related drawing operations. It will send NM_CUSTOMDRAW notification codes before
		/// and after drawing items. This occurs when dwDrawStage equals CDDS_PREPAINT.
		/// </summary>
		CDRF_NOTIFYITEMDRAW = 0x00000020,

		/// <summary>
		/// Version 4.71. The control will notify the parent when a list-view subitem is being drawn. This occurs when dwDrawStage equals CDDS_PREPAINT.
		/// </summary>
		CDRF_NOTIFYSUBITEMDRAW = 0x00000020,

		/// <summary>The control will notify the parent after erasing an item. This occurs when dwDrawStage equals CDDS_PREPAINT.</summary>
		CDRF_NOTIFYPOSTERASE = 0x00000040,

		/// <summary>Version 5.00. Blend the button 50 percent with the background. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
		TBCDRF_BLENDICON = 0x00200000,

		/// <summary>
		/// Version 4.71. Use the clrHighlightHotTrack member of the NMTBCUSTOMDRAW structure to draw the background of hot-tracked items.
		/// This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.
		/// </summary>
		TBCDRF_HILITEHOTTRACK = 0x00020000,

		/// <summary>Version 5.00. Do not draw button background. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
		TBCDRF_NOBACKGROUND = 0x00400000,

		/// <summary>Version 4.71. Do not draw button edges. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
		TBCDRF_NOEDGES = 0x00010000,

		/// <summary>Version 4.71. Do not draw etched effect for disabled items. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
		TBCDRF_NOETCHEDEFFECT = 0x00100000,

		/// <summary>Do not draw default highlight of items that have the TBSTATE_MARKED. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
		TBCDRF_NOMARK = 0x00080000,

		/// <summary>Version 4.71. Do not offset the button when pressed. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
		TBCDRF_NOOFFSET = 0x00040000,

		/// <summary>Version 6.00, Windows Vista only. Use custom draw colors to render text regardless of visual style.</summary>
		TBCDRF_USECDCOLORS = 0x00800000,
	}

	/// <summary>Return value from TBN_DROPDOWN.</summary>
	[PInvokeData("Commctrl.h")]
	public enum TBDDRET
	{
		/// <summary>The drop-down was handled.</summary>
		TBDDRET_DEFAULT = 0,

		/// <summary>The drop-down was not handled.</summary>
		TBDDRET_NODEFAULT = 1,

		/// <summary>The drop-down was handled, but treat the button like a regular button.</summary>
		TBDDRET_TREATPRESSED = 2,
	}

	/// <summary>Flags used by TBBUTTONINFO.</summary>
	[PInvokeData("Commctrl.h")]
	[Flags]
	public enum TBIF : uint
	{
		/// <summary>Version 5.80. The wParam sent with a TB_GETBUTTONINFO or TB_SETBUTTONINFO message is an index, not an identifier.</summary>
		TBIF_BYINDEX = 0x80000000,

		/// <summary>The idCommand member contains valid information or is being requested.</summary>
		TBIF_COMMAND = 0x00000020,

		/// <summary>The iImage member contains valid information or is being requested.</summary>
		TBIF_IMAGE = 0x00000001,

		/// <summary>The lParam member contains valid information or is being requested.</summary>
		TBIF_LPARAM = 0x00000010,

		/// <summary>The cx member contains valid information or is being requested.</summary>
		TBIF_SIZE = 0x00000040,

		/// <summary>The fsState member contains valid information or is being requested.</summary>
		TBIF_STATE = 0x00000004,

		/// <summary>The fsStyle member contains valid information or is being requested.</summary>
		TBIF_STYLE = 0x00000008,

		/// <summary>The pszText member contains valid information or is being requested.</summary>
		TBIF_TEXT = 0x00000002,
	}

	/// <summary>Defines where the insertion mark is in relation to iButton in TBINSERTMARK.</summary>
	[PInvokeData("Commctrl.h")]
	[Flags]
	public enum TBIMHT : uint
	{
		/// <summary>The insertion mark is to the right of the specified button.</summary>
		TBIMHT_AFTER = 0x00000001,

		/// <summary>The insertion mark is on the background of the toolbar. This flag is only used with the TB_INSERTMARKHITTEST message.</summary>
		TBIMHT_BACKGROUND = 0x00000002,
	}

	/// <summary>Mask that determines the metric to retrieve in TBMETRICS.</summary>
	[PInvokeData("Commctrl.h")]
	[Flags]
	public enum TBMF : uint
	{
		/// <summary>Retrieve the cxPad and cyPad values.</summary>
		TBMF_PAD = 0x00000001,

		/// <summary>Retrieve the cxBarPad and cyBarPad values.</summary>
		TBMF_BARPAD = 0x00000002,

		/// <summary>Retrieve the cxButtonSpacing and cyButtonSpacing values.</summary>
		TBMF_BUTTONSPACING = 0x00000004,
	}

	/// <summary>Set of flags that indicate which members of NMTBDISPINFO are being requested.</summary>
	[PInvokeData("Commctrl.h")]
	[Flags]
	public enum TBNF : uint
	{
		/// <summary>The item's image index is being requested. The image index must be placed in the iImage member.</summary>
		TBNF_IMAGE = 0x00000001,

		/// <summary>Not currently implemented.</summary>
		TBNF_TEXT = 0x00000002,

		/// <summary>
		/// Set this flag when processing TBN_GETDISPINFO; the toolbar control will retain the supplied information and not request it again.
		/// </summary>
		TBNF_DI_SETITEM = 0x10000000,
	}

	/// <summary>State values used by TB_GETSTATE and TB_SETSTATE.</summary>
	[PInvokeData("Commctrl.h")]
	[Flags]
	public enum TBSTATE : byte
	{
		/// <summary>The button has the TBSTYLE_CHECK style and is being clicked.</summary>
		TBSTATE_CHECKED = 0x01,

		/// <summary>Version 4.70. The button's text is cut off and an ellipsis is displayed.</summary>
		TBSTATE_ELLIPSES = 0x40,

		/// <summary>The button accepts user input. A button that does not have this state is grayed.</summary>
		TBSTATE_ENABLED = 0x04,

		/// <summary>The button is not visible and cannot receive user input.</summary>
		TBSTATE_HIDDEN = 0x08,

		/// <summary>The button is grayed.</summary>
		TBSTATE_INDETERMINATE = 0x10,

		/// <summary>Version 4.71. The button is marked. The interpretation of a marked item is dependent upon the application.</summary>
		TBSTATE_MARKED = 0x80,

		/// <summary>The button is being clicked.</summary>
		TBSTATE_PRESSED = 0x02,

		/// <summary>The button is followed by a line break. The button must also have the TBSTATE_ENABLED state.</summary>
		TBSTATE_WRAP = 0x20,
	}

	/// <summary>Toolbar Control Messages</summary>
	[PInvokeData("Commctrl.h")]
	public enum ToolbarMessage : uint
	{
		/// <summary>
		/// Checks or unchecks a given button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button to check.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is a <c>BOOL</c> that indicates whether to check or uncheck the specified button. If <c>TRUE</c>, the check is
		/// added. If <c>FALSE</c>, the check is removed.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>When a button is checked, it is displayed in the pressed state.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-checkbutton
		[MsgParams(typeof(int), typeof(uint), LResultType = typeof(BOOL))]
		TB_CHECKBUTTON = WM_USER + 2,

		/// <summary>
		/// Presses or releases the specified button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button to press or release.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is a <c>BOOL</c> that indicates whether to press or release the specified button. If <c>TRUE</c>, the button is
		/// pressed. If <c>FALSE</c>, the button is released.
		/// </para>
		/// <para>The <c>HIWORD</c> must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-pressbutton
		[MsgParams(typeof(int), typeof(uint), LResultType = typeof(BOOL))]
		TB_PRESSBUTTON = WM_USER + 3,

		/// <summary>
		/// Hides or shows the specified button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button to hide or show.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is a <c>BOOL</c> that indicates whether to hide or show the specified button. If <c>TRUE</c>, the button is
		/// hidden. If <c>FALSE</c>, the button is shown.
		/// </para>
		/// <para>The <c>HIWORD</c> must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-hidebutton
		[MsgParams(typeof(int), typeof(uint), LResultType = typeof(BOOL))]
		TB_HIDEBUTTON = WM_USER + 4,

		/// <summary>
		/// Sets or clears the indeterminate state of the specified button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button whose indeterminate state is to be set or cleared.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is a <c>BOOL</c> that indicates whether to set or clear the indeterminate state. If <c>TRUE</c>, the
		/// indeterminate state is set. If <c>FALSE</c>, the state is cleared.
		/// </para>
		/// <para>The <c>HIWORD</c> must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-indeterminate
		[MsgParams(typeof(int), typeof(uint), LResultType = typeof(BOOL))]
		TB_INDETERMINATE = WM_USER + 5,

		/// <summary>
		/// Sets the highlight state of a given button in a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier for a toolbar button.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> is a <c>BOOL</c> that indicates the new highlight state. If <c>TRUE</c>, the button is highlighted. If
		/// <c>FALSE</c>, the button is set to its default state.
		/// </para>
		/// <para>The <c>HIWORD</c> must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-markbutton
		[MsgParams(typeof(int), typeof(uint), LResultType = typeof(BOOL))]
		TB_MARKBUTTON = WM_USER + 6,

		/// <summary>
		/// Determines whether the specified button in a toolbar is enabled.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if the button is enabled, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-isbuttonenabled
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TB_ISBUTTONENABLED = WM_USER + 9,

		/// <summary>
		/// Determines whether the specified button in a toolbar is checked.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if the button is checked, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-isbuttonchecked
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TB_ISBUTTONCHECKED = WM_USER + 10,

		/// <summary>
		/// Determines whether the specified button in a toolbar is pressed.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if the button is pressed, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-isbuttonpressed
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TB_ISBUTTONPRESSED = WM_USER + 11,

		/// <summary>
		/// Determines whether the specified button in a toolbar is hidden.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if the button is hidden, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-isbuttonhidden
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TB_ISBUTTONHIDDEN = WM_USER + 12,

		/// <summary>
		/// Determines whether the specified button in a toolbar is indeterminate.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if the button is indeterminate, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-isbuttonindeterminate
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TB_ISBUTTONINDETERMINATE = WM_USER + 13,

		/// <summary>
		/// Checks the highlight state of a toolbar button.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier for a toolbar button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if the button is highlighted, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-isbuttonhighlighted
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TB_ISBUTTONHIGHLIGHTED = WM_USER + 14,

		/// <summary>
		/// Sets the state for the specified button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>The <c>LOWORD</c> is a combination of values listed in Toolbar Button States. The <c>HIWORD</c> must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setstate
		[MsgParams(typeof(int), typeof(uint), LResultType = typeof(BOOL))]
		TB_SETSTATE = WM_USER + 17,

		/// <summary>
		/// Retrieves information about the state of the specified button in a toolbar, such as whether it is enabled, pressed, or checked.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button for which to retrieve information.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the button state information if successful, or -1 otherwise. The button state information can be a combination of the
		/// values listed in <c>Toolbar Button States</c>.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getstate
		[MsgParams(typeof(int), null, LResultType = typeof(TBSTATE))]
		TB_GETSTATE = WM_USER + 18,

		/// <summary>
		/// Adds one or more images to the list of button images available for a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Number of button images in the bitmap. If lParam specifies a system-defined bitmap, this parameter is ignored.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TBADDBITMAP</c> structure that contains the identifier of a bitmap resource and the handle to the module instance
		/// with the executable file that contains the bitmap resource.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the first new image if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// If the toolbar was created using the <c>CreateWindowEx</c> function, you must send the <c>TB_BUTTONSTRUCTSIZE</c> message to the
		/// toolbar before sending <c>TB_ADDBITMAP</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-addbitmap
		[MsgParams(typeof(int), typeof(TBADDBITMAP?))]
		TB_ADDBITMAP = WM_USER + 19,

		/// <summary>
		/// Adds one or more buttons to a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Number of buttons to add.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an array of <c>TBBUTTON</c> structures that contain information about the buttons to add. There must be the same
		/// number of elements in the array as buttons specified by wParam.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the toolbar was created using the <c>CreateWindowEx</c> function, you must send the <c>TB_BUTTONSTRUCTSIZE</c> message to the
		/// toolbar before sending <c>TB_ADDBUTTONS</c>.
		/// </para>
		/// <para>See <c>TB_SETIMAGELIST</c> for a discussion of how to assign bitmaps to toolbar buttons from one or more image lists.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-addbuttons
		[MsgParams(typeof(int), typeof(TBBUTTON[]), LResultType = typeof(BOOL))]
		TB_ADDBUTTONSA = WM_USER + 20,

		/// <summary>
		/// Inserts a button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of a button. The message inserts the new button to the left of this button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>TBBUTTON</c> structure containing information about the button to insert.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-insertbutton
		[MsgParams(typeof(int), typeof(TBBUTTON?), LResultType = typeof(BOOL))]
		TB_INSERTBUTTONA = WM_USER + 21,

		/// <summary>
		/// Deletes a button from the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the button to delete.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-deletebutton
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TB_DELETEBUTTON = WM_USER + 22,

		/// <summary>
		/// Retrieves information about the specified button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the button for which to retrieve information.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to the <c>TBBUTTON</c> structure that receives the button information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getbutton
		[MsgParams(typeof(int), typeof(TBBUTTON?), LResultType = typeof(BOOL))]
		TB_GETBUTTON = WM_USER + 23,

		/// <summary>
		/// Retrieves a count of the buttons currently in the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the count of the buttons.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-buttoncount
		[MsgParams()]
		TB_BUTTONCOUNT = WM_USER + 24,

		/// <summary>
		/// Retrieves the zero-based index for the button associated with the specified command identifier.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier associated with the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the zero-based index for the button or -1 if the specified command identifier is invalid.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-commandtoindex
		[MsgParams(typeof(int), null)]
		TB_COMMANDTOINDEX = WM_USER + 25,

		/// <summary>
		/// Send this message to initiate saving or restoring a toolbar state.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Save or restore flag. If this parameter is <c>TRUE</c>, the information is saved. If it is <c>FALSE</c>, the information is restored.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TBSAVEPARAMS</c> structure that specifies the registry key, subkey, and value name for the toolbar state information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// For version 4.72 and earlier, to use this message to save or restore a toolbar, the parent window of the toolbar control must
		/// implement a handler for the TBN_GETBUTTONINFO notification code. The toolbar issues this notification to retrieve information
		/// about each button as it is restored.
		/// </para>
		/// <para>
		/// Version 5.80 includes a new save/restore option. At the beginning of the process, and as each button is saved or restored, your
		/// application will receive a TBN_SAVE or TBN_RESTORE notification. To use this option, you must implement notification handlers to
		/// provide the Shell with the bitmap and state information it needs to successfully save or restore the toolbar state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-saverestore
		[MsgParams(typeof(BOOL), typeof(TBSAVEPARAMS?), LResultType = null)]
		TB_SAVERESTOREA = WM_USER + 26,

		/// <summary>
		/// Send this message to initiate saving or restoring a toolbar state.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Save or restore flag. If this parameter is <c>TRUE</c>, the information is saved. If it is <c>FALSE</c>, the information is restored.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TBSAVEPARAMS</c> structure that specifies the registry key, subkey, and value name for the toolbar state information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// For version 4.72 and earlier, to use this message to save or restore a toolbar, the parent window of the toolbar control must
		/// implement a handler for the TBN_GETBUTTONINFO notification code. The toolbar issues this notification to retrieve information
		/// about each button as it is restored.
		/// </para>
		/// <para>
		/// Version 5.80 includes a new save/restore option. At the beginning of the process, and as each button is saved or restored, your
		/// application will receive a TBN_SAVE or TBN_RESTORE notification. To use this option, you must implement notification handlers to
		/// provide the Shell with the bitmap and state information it needs to successfully save or restore the toolbar state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-saverestore
		[MsgParams(typeof(BOOL), typeof(TBSAVEPARAMS?), LResultType = null)]
		TB_SAVERESTOREW = WM_USER + 76,

		/// <summary>
		/// Displays the <c>Customize Toolbar</c> dialog box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The toolbar must handle the TBN_QUERYINSERT and TBN_QUERYDELETE notifications for the <c>Customize Toolbar</c> dialog box to
		/// appear. If the toolbar does not handle those notifications, <c>TB_CUSTOMIZE</c> has no effect.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-customize
		[MsgParams(LResultType = null)]
		TB_CUSTOMIZE = WM_USER + 27,

		/// <summary>
		/// Adds a new string to the toolbar's string pool.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Handle to the module instance with an executable file that contains the string resource. If lParam instead points to a character
		/// array with one or more strings, set this parameter to <c>NULL</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Resource identifier for the string resource, or a pointer to a TCHAR array. See Remarks.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the first new string if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If wParam is <c>NULL</c>, lParam points to a character array with one or more null-terminated strings. The last string in the
		/// array must be terminated with two null characters.
		/// </para>
		/// <para>
		/// If wParam is the HINSTANCE of the application or of another module containing a string resource, lParam is the resource
		/// identifier of the string. Each item in the string must begin with an arbitrary separator character, and the string must end with
		/// two such characters. For example, the text for three buttons might appear in the string table as "/New/Open/Save//". The message
		/// returns the index of "New" in the toolbar's string pool, and the other items are in consecutive positions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-addstring
		[MsgParams(typeof(HINSTANCE), typeof(ResourceId))]
		TB_ADDSTRINGA = WM_USER + 28,

		/// <summary>
		/// Adds a new string to the toolbar's string pool.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Handle to the module instance with an executable file that contains the string resource. If lParam instead points to a character
		/// array with one or more strings, set this parameter to <c>NULL</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Resource identifier for the string resource, or a pointer to a TCHAR array. See Remarks.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the first new string if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If wParam is <c>NULL</c>, lParam points to a character array with one or more null-terminated strings. The last string in the
		/// array must be terminated with two null characters.
		/// </para>
		/// <para>
		/// If wParam is the HINSTANCE of the application or of another module containing a string resource, lParam is the resource
		/// identifier of the string. Each item in the string must begin with an arbitrary separator character, and the string must end with
		/// two such characters. For example, the text for three buttons might appear in the string table as "/New/Open/Save//". The message
		/// returns the index of "New" in the toolbar's string pool, and the other items are in consecutive positions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-addstring
		[MsgParams(typeof(HINSTANCE), typeof(ResourceId))]
		TB_ADDSTRINGW = WM_USER + 77,

		/// <summary>
		/// Retrieves the bounding rectangle of a button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the button for which to retrieve information.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>RECT</c> structure that receives the client coordinates of the bounding rectangle.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// This message does not retrieve the bounding rectangle for buttons whose state is set to the <c>TBSTATE_HIDDEN</c> value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getitemrect
		[MsgParams(typeof(int), typeof(RECT?), LResultType = typeof(BOOL))]
		TB_GETITEMRECT = WM_USER + 29,

		/// <summary>
		/// Specifies the size of the <c>TBBUTTON</c> structure.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Size, in bytes, of the <c>TBBUTTON</c> structure.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>The system uses the size to determine which version of the common control dynamic-link library (DLL) is being used.</para>
		/// <para>
		/// If an application uses the <c>CreateWindowEx</c> function to create the toolbar, the application must send this message to the
		/// toolbar before sending the <c>TB_ADDBITMAP</c> or <c>TB_ADDBUTTONS</c> message. The <c>CreateToolbarEx</c> function automatically
		/// sends <c>TB_BUTTONSTRUCTSIZE</c>, and the size of the <c>TBBUTTON</c> structure is a parameter of the function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-buttonstructsize
		[MsgParams(typeof(int), null, LResultType = null)]
		TB_BUTTONSTRUCTSIZE = WM_USER + 30,

		/// <summary>
		/// Sets the size of buttons on a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the width, in pixels, of the buttons. The <c>HIWORD</c> specifies the height, in pixels, of the buttons.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para><c>TB_SETBUTTONSIZE</c> should generally be called after adding buttons.</para>
		/// <para>
		/// Use <c>TB_SETBUTTONWIDTH</c> to set the maximum and minimum allowed widths for buttons before they are added. Use
		/// <c>TB_SETBUTTONSIZE</c> to set the actual size of buttons.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setbuttonsize
		[MsgParams(null, typeof(SIZES), LResultType = typeof(BOOL))]
		TB_SETBUTTONSIZE = WM_USER + 31,

		/// <summary>
		/// Sets the size of the bitmapped images to be added to a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the width, in pixels, of the bitmapped images. The <c>HIWORD</c> specifies the height, in pixels, of
		/// the bitmapped images.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The size can be set only before adding any bitmaps to the toolbar. If an application does not explicitly set the bitmap size, the
		/// size defaults to 16 by 15 pixels.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setbitmapsize
		[MsgParams(null, typeof(SIZES), LResultType = typeof(BOOL))]
		TB_SETBITMAPSIZE = WM_USER + 32,

		/// <summary>
		/// Causes a toolbar to be resized.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// An application sends the <c>TB_AUTOSIZE</c> message after causing the size of a toolbar to change either by setting the button or
		/// bitmap size or by adding strings for the first time.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-autosize
		[MsgParams(LResultType = null)]
		TB_AUTOSIZE = WM_USER + 33,

		/// <summary>
		/// Retrieves the handle to the tooltip control, if any, associated with the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the tooltip control, or <c>NULL</c> if the toolbar has no associated tooltip.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-gettooltips
		[MsgParams(LResultType = typeof(HWND))]
		TB_GETTOOLTIPS = WM_USER + 35,

		/// <summary>
		/// Associates a tooltip control with a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the tooltip control.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// Any buttons added to a toolbar before sending the <c>TB_SETTOOLTIPS</c> message will not be registered with the tooltip control.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-settooltips
		[MsgParams(typeof(HWND), null, LResultType = null)]
		TB_SETTOOLTIPS = WM_USER + 36,

		/// <summary>
		/// Sets the window to which the toolbar control sends notification messages.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the window to receive notification messages.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is a handle to the previous notification window, or <c>NULL</c> if there is no previous notification window.</para>
		/// </summary>
		/// <remarks>
		/// The <c>TB_SETPARENT</c> message does not change the parent window that was specified when the control was created. Calling the
		/// <c>GetParent</c> function for a toolbar control will return the actual parent window, not the window specified in
		/// <c>TB_SETPARENT</c>. To change the control's parent window, call the <c>SetParent</c> function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setparent
		[MsgParams(typeof(HWND), null, LResultType = typeof(HWND))]
		TB_SETPARENT = WM_USER + 37,

		/// <summary>
		/// Sets the number of rows of buttons in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the number of rows requested. The minimum number of rows is one, and the maximum number of rows is
		/// equal to the number of buttons in the toolbar.
		/// </para>
		/// <para>
		/// The <c>HIWORD</c> is a <c>BOOL</c> that indicates whether to create more rows than requested when the system cannot create the
		/// number of rows specified by wParam. If <c>TRUE</c>, the system creates more rows. If <c>FALSE</c>, the system creates fewer rows.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>RECT</c> structure that receives the bounding rectangle of the toolbar after the rows are set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// Because the system does not break up button groups when setting the number of rows, the resulting number of rows might differ
		/// from the number requested.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setrows
		[MsgParams(typeof(uint), typeof(RECT?), LResultType = null)]
		TB_SETROWS = WM_USER + 39,

		/// <summary>
		/// Retrieves the number of rows of buttons in a toolbar with the <c>TBSTYLE_WRAPABLE</c> style.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the number of rows.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getrows
		[MsgParams(LResultType = typeof(ushort))]
		TB_GETROWS = WM_USER + 40,

		/// <summary>
		/// Retrieves the flags that describe the type of bitmap to be used.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>DWORD</c> value that describes the type of bitmap that should be used. If this return value has the TBBF_LARGE flag
		/// set, applications should use large bitmaps (24 x 24); otherwise, applications should use small bitmaps (16 x 16). All other bits
		/// are reserved.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The value returned by <c>TB_GETBITMAPFLAGS</c> is only advisory. The toolbar control recommends large or small bitmaps based upon
		/// whether the user has chosen large or small fonts.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getbitmapflags
		[MsgParams(LResultType = typeof(TBBF))]
		TB_GETBITMAPFLAGS = WM_USER + 41,

		/// <summary>
		/// Sets the command identifier of a toolbar button.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the button whose command identifier is to be set.</para>
		/// <para><em>lParam</em></para>
		/// <para>Command identifier.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setcmdid
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(BOOL))]
		TB_SETCMDID = WM_USER + 42,

		/// <summary>
		/// Changes the bitmap for a button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button that is to receive a new bitmap.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Zero-based index of an image in the toolbar's image list. The system displays the specified image in the button. Set this
		/// parameter to <see cref="I_IMAGECALLBACK"/>, and the toolbar will send the <c>TBN_GETDISPINFO</c> notification to retrieve the
		/// image index when it is needed.
		/// </para>
		/// <para>
		/// Version 5.81. Set this parameter to <see cref="I_IMAGENONE"/> to indicate that the button does not have an image. The button
		/// layout will not include any space for a bitmap, only text.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-changebitmap
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(BOOL))]
		TB_CHANGEBITMAP = WM_USER + 43,

		/// <summary>
		/// Retrieves the index of the bitmap associated with a button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button whose bitmap index is to be retrieved.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the bitmap if successful, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getbitmap
		[MsgParams(typeof(int), null)]
		TB_GETBITMAP = WM_USER + 44,

		/// <summary>
		/// Retrieves the display text of a button on a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button whose text is to be retrieved.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a buffer that receives the button text.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the length, in characters, of the string pointed to by lParam. The length does not include the terminating null
		/// character. If unsuccessful, the return value is -1.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <c>Security Warning:</c> Using this message incorrectly might compromise the security of your program. This message does not
		/// provide a way for you to know the size of the buffer. If you use this message, first call the message passing <c>NULL</c> in the
		/// lParam, this returns the number of characters, excluding <c>NULL</c> that are required. Then call the message a second time to
		/// retrieve the string. You should review the Security Considerations: Microsoft Windows Controls before continuing.
		/// </para>
		/// <para>The returned string corresponds to the text that is currently displayed by the button.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getbuttontext
		[MsgParams(typeof(int), typeof(StrPtrAnsi))]
		TB_GETBUTTONTEXTA = WM_USER + 45,

		/// <summary>
		/// Retrieves the display text of a button on a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button whose text is to be retrieved.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a buffer that receives the button text.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the length, in characters, of the string pointed to by lParam. The length does not include the terminating null
		/// character. If unsuccessful, the return value is -1.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <c>Security Warning:</c> Using this message incorrectly might compromise the security of your program. This message does not
		/// provide a way for you to know the size of the buffer. If you use this message, first call the message passing <c>NULL</c> in the
		/// lParam, this returns the number of characters, excluding <c>NULL</c> that are required. Then call the message a second time to
		/// retrieve the string. You should review the Security Considerations: Microsoft Windows Controls before continuing.
		/// </para>
		/// <para>The returned string corresponds to the text that is currently displayed by the button.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getbuttontext
		[MsgParams(typeof(int), typeof(StrPtrUni))]
		TB_GETBUTTONTEXTW = WM_USER + 75,

		/// <summary>
		/// Replaces an existing bitmap with a new bitmap.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>TBREPLACEBITMAP</c> structure that contains the information of the bitmap to be replaced and the new bitmap.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-replacebitmap
		[MsgParams(null, typeof(TBREPLACEBITMAP?), LResultType = typeof(BOOL))]
		TB_REPLACEBITMAP = WM_USER + 46,

		/// <summary>
		/// Sets the indentation for the first button in a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Value specifying the indentation, in pixels.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setindent
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TB_SETINDENT = WM_USER + 47,

		/// <summary>
		/// Sets the image list that the toolbar uses to display buttons that are in their default state.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Version 5.80. The index of the list. If you use only one image list, or an earlier version of the common controls, set wParam to
		/// zero. See Remarks for details on using multiple image lists.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the image list to set. If this parameter is <c>NULL</c>, no images are displayed in the buttons.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the image list previously used to display buttons in their default state, or <c>NULL</c> if no image list
		/// was previously set.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <para>Note</para>
		/// <para>Your application is responsible for freeing the image list after the toolbar is destroyed.</para>
		/// </para>
		/// <para>
		/// The <c>TB_SETIMAGELIST</c> message cannot be combined with <c>TB_ADDBITMAP</c>. It also cannot be used with toolbars created with
		/// <c>CreateToolbarEx</c>, which calls <c>TB_ADDBITMAP</c> internally. When you create a toolbar with <c>CreateToolbarEx</c> or use
		/// <c>TB_ADDBITMAP</c> to add images, the toolbar manages the image list internally. Attempting to modify it with
		/// <c>TB_SETIMAGELIST</c> has unpredictable consequences.
		/// </para>
		/// <para>
		/// With version 5.80 or later of the common controls, button images need not come from the same image list. To use multiple image
		/// lists for your toolbar button images:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Enable multiple image lists by sending the toolbar control a <c>CCM_SETVERSION</c> message with wParam (the version number) set
		/// to 5.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each image list you want to use, send the toolbar control a <c>TB_SETIMAGELIST</c> message. Set wParam to an
		/// application-defined wParam value that will be used to identify the list. Set lParam to the list's HIMAGELIST handle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each button, set the <c>iBitmap</c> member of the button's <c>TBBUTTON</c> structure to MAKELONG(iIndex, iImageID). The
		/// iImageID value is the ID of the appropriate image list that was defined in step two. The iIndex value is the index of the
		/// particular image within that list.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Add the buttons by sending the toolbar control a <c>TB_ADDBUTTONS</c> message.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The following code fragment illustrates how to add five buttons to a toolbar, with images from three different image lists.
		/// Support for multiple image lists is enabled with a <c>CCM_SETVERSION</c> message. The image lists are then set and assigned IDs
		/// of 0-2. The buttons are assigned images from the image lists as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Button 0 is from image list zero (ahim[0]) with index of 1.</term>
		/// </item>
		/// <item>
		/// <term>Button 1 is from image list one (ahim[1]) with an index of 1.</term>
		/// </item>
		/// <item>
		/// <term>Button 2 is from image list two (ahim[2]) with an index of 1.</term>
		/// </item>
		/// <item>
		/// <term>Button 3 is from image list zero (ahim[0]) with an index of 2.</term>
		/// </item>
		/// <item>
		/// <term>Button 4 is from image list one (ahim[1]) with an index of 3.</term>
		/// </item>
		/// </list>
		/// <para>Finally, the buttons are added to the toolbar control with a <c>TB_ADDBUTTONS</c> message.</para>
		/// <para>
		/// <code>//Enable multiple image lists SendMessage(hwndTB, CCM_SETVERSION, (WPARAM) 5, 0); //Set the image lists and assign them IDs of 0-2 SendMessage(hwndTB, TB_SETIMAGELIST, 0, (LPARAM)ahiml[0]); SendMessage(hwndTB, TB_SETIMAGELIST, 1, (LPARAM)ahiml[1]); SendMessage(hwndTB, TB_SETIMAGELIST, 2, (LPARAM)ahiml[2]); // Create the five buttons TBBUTTON rgtb[5]; //... initialize the TBBUTTON structures as usual ... //Assign images to each button rgtb[0].iBitmap = MAKELONG(1, 0); rgtb[1].iBitmap = MAKELONG(1, 1); rgtb[2].iBitmap = MAKELONG(1, 2); rgtb[3].iBitmap = MAKELONG(2, 0); rgtb[4].iBitmap = MAKELONG(3, 1); // Add the five buttons to the toolbar control SendMessage(hwndTB, TB_ADDBUTTONS, 5, (LPARAM)(&amp;rgtb);</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setimagelist
		[MsgParams(typeof(int), typeof(HIMAGELIST), LResultType = typeof(HIMAGELIST))]
		TB_SETIMAGELIST = WM_USER + 48,

		/// <summary>
		/// Retrieves the image list that a toolbar control uses to display buttons in their default state. A toolbar control uses this image
		/// list to display buttons when they are not hot or disabled.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the image list, or <c>NULL</c> if no image list is set.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getimagelist
		[MsgParams(LResultType = typeof(HIMAGELIST))]
		TB_GETIMAGELIST = WM_USER + 49,

		/// <summary>
		/// Loads system-defined button images into a toolbar control's image list.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Identifier of a system-defined button image list. This parameter can be set to one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IDB_HIST_LARGE_COLOR</c></term>
		/// <term>Windows Explorer bitmaps in large size.</term>
		/// </item>
		/// <item>
		/// <term><c>IDB_HIST_SMALL_COLOR</c></term>
		/// <term>Windows Explorer bitmaps in small size.</term>
		/// </item>
		/// <item>
		/// <term><c>IDB_STD_LARGE_COLOR</c></term>
		/// <term>Standard bitmaps in large size.</term>
		/// </item>
		/// <item>
		/// <term><c>IDB_STD_SMALL_COLOR</c></term>
		/// <term>Standard bitmaps in small size.</term>
		/// </item>
		/// <item>
		/// <term><c>IDB_VIEW_LARGE_COLOR</c></term>
		/// <term>View bitmaps in large size.</term>
		/// </item>
		/// <item>
		/// <term><c>IDB_VIEW_SMALL_COLOR</c></term>
		/// <term>View bitmaps in small size.</term>
		/// </item>
		/// <item>
		/// <term><c>IDB_HIST_NORMAL</c></term>
		/// <term>Windows Explorer travel buttons and favorites bitmaps in normal state.</term>
		/// </item>
		/// <item>
		/// <term><c>IDB_HIST_HOT</c></term>
		/// <term>Windows Explorer travel buttons and favorites bitmaps in hot state.</term>
		/// </item>
		/// <item>
		/// <term><c>IDB_HIST_DISABLED</c></term>
		/// <term>Windows Explorer travel buttons and favorites bitmaps in disabled state.</term>
		/// </item>
		/// <item>
		/// <term><c>IDB_HIST_PRESSED</c></term>
		/// <term>Windows Explorer travel buttons and favorites bitmaps in pressed state.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Instance handle. This parameter must be set to HINST_COMMCTRL.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The count of images in the image list. Returns zero if the toolbar has no image list or if the existing image list is empty.</para>
		/// </summary>
		/// <remarks>
		/// You must use the proper image index values when you prepare <c>TBBUTTON</c> structures prior to sending the <c>TB_ADDBUTTONS</c>
		/// message. For a list of image index values for these preset bitmaps, see Toolbar Standard Button Image Index Values.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-loadimages
		[MsgParams(typeof(IDB), typeof(HINSTANCE))]
		TB_LOADIMAGES = WM_USER + 50,

		/// <summary>
		/// Retrieves the bounding rectangle for a specified toolbar button.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>RECT</c> structure that will receive the bounding rectangle information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// This message does not retrieve the bounding rectangle for buttons whose state is set to the <c>TBSTATE_HIDDEN</c> value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getrect
		[MsgParams(typeof(int), typeof(RECT?), LResultType = typeof(BOOL))]
		TB_GETRECT = WM_USER + 51,

		/// <summary>
		/// Sets the image list that the toolbar control will use to display hot buttons.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the image list that will be set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the image list previously used to display hot buttons, or <c>NULL</c> if no image list was previously set.
		/// </para>
		/// </summary>
		/// <remarks>
		/// A button is hot when the cursor is over it. Toolbar controls must have the <c>TBSTYLE_FLAT</c> or <c>TBSTYLE_LIST</c> style to
		/// have hot items.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-sethotimagelist
		[MsgParams(null, typeof(HIMAGELIST), LResultType = typeof(HIMAGELIST))]
		TB_SETHOTIMAGELIST = WM_USER + 52,

		/// <summary>
		/// Retrieves the image list that a toolbar control uses to display hot buttons.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the image list that the control uses to display hot buttons, or <c>NULL</c> if no hot image list is set.
		/// </para>
		/// </summary>
		/// <remarks>
		/// A button is hot when the cursor is over it. Toolbar controls must have the <c>TBSTYLE_FLAT</c> or <c>TBSTYLE_LIST</c> style to
		/// have hot items.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-gethotimagelist
		[MsgParams(LResultType = typeof(HIMAGELIST))]
		TB_GETHOTIMAGELIST = WM_USER + 53,

		/// <summary>
		/// Sets the image list that the toolbar control will use to display disabled buttons.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the image list that will be set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the image list previously used to display disabled buttons, or <c>NULL</c> if no image list was previously set.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setdisabledimagelist
		[MsgParams(null, typeof(HIMAGELIST), LResultType = typeof(HIMAGELIST))]
		TB_SETDISABLEDIMAGELIST = WM_USER + 54,

		/// <summary>
		/// Retrieves the image list that a toolbar control uses to display inactive buttons.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the inactive image list, or <c>NULL</c> if no inactive image list is set.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getdisabledimagelist
		[MsgParams(LResultType = typeof(HIMAGELIST))]
		TB_GETDISABLEDIMAGELIST = WM_USER + 55,

		/// <summary>
		/// Sets the style for a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Value specifying the styles to be set for the control. This value can be a combination of toolbar control styles.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setstyle
		[MsgParams(null, typeof(ToolbarStyle), LResultType = null)]
		TB_SETSTYLE = WM_USER + 56,

		/// <summary>
		/// Retrieves the styles currently in use for a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>DWORD</c> value that is a combination of toolbar control styles.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getstyle
		[MsgParams(LResultType = typeof(ToolbarStyle))]
		TB_GETSTYLE = WM_USER + 57,

		/// <summary>
		/// Retrieves the current width and height of toolbar buttons, in pixels.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>DWORD</c> value that contains the width and height values in the low word and high word, respectively.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getbuttonsize
		[MsgParams(LResultType = typeof(SIZES))]
		TB_GETBUTTONSIZE = WM_USER + 58,

		/// <summary>
		/// Sets the minimum and maximum button widths in the toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>The <c>LOWORD</c> specifies the minimum button width, in pixels. Toolbar buttons will never be narrower than this value.</para>
		/// <para>
		/// The <c>HIWORD</c> specifies the maximum button width, in pixels. If button text is too wide, the control displays it with
		/// ellipsis points.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// Use <c>TB_SETBUTTONWIDTH</c> to set the maximum and minimum allowed widths for buttons before they are added. Use
		/// <c>TB_SETBUTTONSIZE</c> to set the actual size of buttons.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setbuttonwidth
		[MsgParams(null, typeof(SIZES), LResultType = typeof(BOOL))]
		TB_SETBUTTONWIDTH = WM_USER + 59,

		/// <summary>
		/// Sets the maximum number of text rows displayed on a toolbar button.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Maximum number of rows of text that can be displayed.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// To cause text to wrap, you must set the maximum button width by sending a <c>TB_SETBUTTONWIDTH</c> message. The text wraps at a
		/// word break; line breaks ("\n") in the text are ignored. Text in TBSTYLE_LIST toolbars is always shown on a single line.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setmaxtextrows
		[MsgParams(typeof(int), null, LResultType = typeof(BOOL))]
		TB_SETMAXTEXTROWS = WM_USER + 60,

		/// <summary>
		/// Retrieves the maximum number of text rows that can be displayed on a toolbar button.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns an INT value representing the maximum number of text rows that the control will display for a button.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-gettextrows
		[MsgParams()]
		TB_GETTEXTROWS = WM_USER + 61,

		/// <summary>
		/// Retrieves the <c>IDropTarget</c> for a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Identifier of the interface being requested. This value must point to <c>IID_IDropTarget</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>Address that receives the interface pointer. If an error occurs, a <c>NULL</c> pointer is placed in this address.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns an <c>HRESULT</c> value indicating success or failure of the operation.</para>
		/// </summary>
		/// <remarks>The toolbar's <c>IDropTarget</c> is used by the toolbar when objects are dragged over or dropped onto it.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getobject
		[MsgParams(typeof(Guid?), typeof(IntPtr), LResultType = typeof(HRESULT))]
		TB_GETOBJECT = WM_USER + 62,

		/// <summary>
		/// Retrieves extended information for a button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TBBUTTONINFO</c> structure that receives the button information. The <c>cbSize</c> and <c>dwMask</c> members of
		/// this structure must be filled in prior to sending this message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the zero-based index of the button, or -1 if an error occurs.</para>
		/// </summary>
		/// <remarks>
		/// When you use <c>TB_ADDBUTTONS</c> or <c>TB_INSERTBUTTON</c> to place buttons on the toolbar, the button text is commonly
		/// specified by its string pool index. <c>TB_GETBUTTONINFO</c> will not retrieve this string. To use <c>TB_GETBUTTONINFO</c> to
		/// retrieve button text, you must first set the text string with <c>TB_SETBUTTONINFO</c>. Once you have set the button text with
		/// <c>TB_SETBUTTONINFO</c>, you can no longer use the string pool index.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getbuttoninfo
		[MsgParams(typeof(int), typeof(TBBUTTONINFO?))]
		TB_GETBUTTONINFOW = WM_USER + 63,

		/// <summary>
		/// Sets the information for an existing button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Button identifier.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TBBUTTONINFO</c> structure that contains the new button information. The <c>cbSize</c> and <c>dwMask</c> members
		/// of this structure must be filled in prior to sending this message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// Text is commonly assigned to buttons when they are added to a toolbar by specifying the index of a string in the toolbar's string
		/// pool. If you use a <c>TB_SETBUTTONINFO</c> to assign new text to a button, it will permanently override the text from the string
		/// pool. You can change the text by calling <c>TB_SETBUTTONINFO</c> again, but you cannot reassign the string from the string pool.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setbuttoninfo
		[MsgParams(typeof(int), typeof(TBBUTTONINFO?), LResultType = typeof(BOOL))]
		TB_SETBUTTONINFOW = WM_USER + 64,

		/// <summary>
		/// Retrieves extended information for a button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Command identifier of the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TBBUTTONINFO</c> structure that receives the button information. The <c>cbSize</c> and <c>dwMask</c> members of
		/// this structure must be filled in prior to sending this message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the zero-based index of the button, or -1 if an error occurs.</para>
		/// </summary>
		/// <remarks>
		/// When you use <c>TB_ADDBUTTONS</c> or <c>TB_INSERTBUTTON</c> to place buttons on the toolbar, the button text is commonly
		/// specified by its string pool index. <c>TB_GETBUTTONINFO</c> will not retrieve this string. To use <c>TB_GETBUTTONINFO</c> to
		/// retrieve button text, you must first set the text string with <c>TB_SETBUTTONINFO</c>. Once you have set the button text with
		/// <c>TB_SETBUTTONINFO</c>, you can no longer use the string pool index.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getbuttoninfo
		[MsgParams(typeof(int), typeof(TBBUTTONINFO?))]
		TB_GETBUTTONINFOA = WM_USER + 65,

		/// <summary>
		/// Sets the information for an existing button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Button identifier.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TBBUTTONINFO</c> structure that contains the new button information. The <c>cbSize</c> and <c>dwMask</c> members
		/// of this structure must be filled in prior to sending this message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// Text is commonly assigned to buttons when they are added to a toolbar by specifying the index of a string in the toolbar's string
		/// pool. If you use a <c>TB_SETBUTTONINFO</c> to assign new text to a button, it will permanently override the text from the string
		/// pool. You can change the text by calling <c>TB_SETBUTTONINFO</c> again, but you cannot reassign the string from the string pool.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setbuttoninfo
		[MsgParams(typeof(int), typeof(TBBUTTONINFO?), LResultType = typeof(BOOL))]
		TB_SETBUTTONINFOA = WM_USER + 66,

		/// <summary>
		/// Inserts a button in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of a button. The message inserts the new button to the left of this button.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>TBBUTTON</c> structure containing information about the button to insert.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-insertbutton
		[MsgParams(typeof(int), typeof(TBBUTTON?), LResultType = typeof(BOOL))]
		TB_INSERTBUTTONW = WM_USER + 67,

		/// <summary>
		/// Adds one or more buttons to a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Number of buttons to add.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an array of <c>TBBUTTON</c> structures that contain information about the buttons to add. There must be the same
		/// number of elements in the array as buttons specified by wParam.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the toolbar was created using the <c>CreateWindowEx</c> function, you must send the <c>TB_BUTTONSTRUCTSIZE</c> message to the
		/// toolbar before sending <c>TB_ADDBUTTONS</c>.
		/// </para>
		/// <para>See <c>TB_SETIMAGELIST</c> for a discussion of how to assign bitmaps to toolbar buttons from one or more image lists.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-addbuttons
		[MsgParams(typeof(int), typeof(TBBUTTON[]), LResultType = typeof(BOOL))]
		TB_ADDBUTTONSW = WM_USER + 68,

		/// <summary>
		/// Determines where a point lies in a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>POINT</c> structure that contains the x-coordinate of the hit test in the <c>x</c> member and the y-coordinate of
		/// the hit test in the <c>y</c> member. The coordinates are relative to the toolbar's client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns an integer value. If the return value is zero or a positive value, it is the zero-based index of the nonseparator item in
		/// which the point lies. If the return value is negative, the point does not lie within a button. The absolute value of the return
		/// value is the index of a separator item or the nearest nonseparator item.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-hittest
		[MsgParams(null, typeof(POINT?))]
		TB_HITTEST = WM_USER + 69,

		/// <summary>
		/// Sets the text drawing flags for the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// One or more of the DT_ flags, specified in <c>DrawText</c>, that indicate which bits in lParam will be used when drawing the text.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// One or more of the DT_ flags, specified in <c>DrawText</c>, that indicate how the button text will be drawn. This value will be
		/// passed to the <c>DrawText</c> function when the button text is drawn.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous text drawing flags.</para>
		/// </summary>
		/// <remarks>
		/// The wParam parameter allows you to specify which flags will be used when drawing the text, even if these flags are turned off.
		/// For example, if you do not want the DT_CENTER flag used when drawing text, you would add the DT_CENTER flag to wParam and not
		/// specify the DT_CENTER flag in lParam. This prevents the control from passing the DT_CENTER flag to the <c>DrawText</c> function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setdrawtextflags
		[MsgParams(typeof(DrawTextFlags), typeof(DrawTextFlags), LResultType = typeof(DrawTextFlags))]
		TB_SETDRAWTEXTFLAGS = WM_USER + 70,

		/// <summary>
		/// Retrieves the index of the hot item in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the index of the hot item, or -1 if no hot item is set. Toolbar controls that do not have the <c>TBSTYLE_FLAT</c> style
		/// do not have hot items.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-gethotitem
		[MsgParams()]
		TB_GETHOTITEM = WM_USER + 71,

		/// <summary>
		/// Sets the hot item in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the item that will be made hot. If this value is -1, none of the items will be hot.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the previous hot item, or -1 if there was no hot item.</para>
		/// </summary>
		/// <remarks>The behavior of this message is not defined for toolbars that do not have the <c>TBSTYLE_FLAT</c> style.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-sethotitem
		[MsgParams(typeof(int), null)]
		TB_SETHOTITEM = WM_USER + 72,

		/// <summary>
		/// Sets the anchor highlight setting for a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// <c>BOOL</c> value that specifies if anchor highlighting is enabled or disabled. If this value is nonzero, anchor highlighting
		/// will be enabled. If this value is zero, anchor highlighting will be disabled.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the previous anchor highlight setting. If this value is nonzero, anchor highlighting was enabled. If this value is zero,
		/// anchor highlighting was disabled.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Anchor highlighting in a toolbar means that the last highlighted item will remain highlighted until another item is highlighted.
		/// This occurs even if the cursor leaves the toolbar control.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setanchorhighlight
		[MsgParams(typeof(BOOL), null, LResultType = typeof(BOOL))]
		TB_SETANCHORHIGHLIGHT = WM_USER + 73,

		/// <summary>
		/// Retrieves the anchor highlight setting for a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a Boolean value that indicates if anchor highlighting is set. If this value is nonzero, anchor highlighting is enabled.
		/// If this value is zero, it is disabled.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getanchorhighlight
		[MsgParams(LResultType = typeof(BOOL))]
		TB_GETANCHORHIGHLIGHT = WM_USER + 74,

		/// <summary>
		/// Determines the ID of the button that corresponds to the specified accelerator character.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The accelerator character.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>UINT</c>. On return, if successful, this parameter will hold the id of the button that has wParam as its
		/// accelerator character.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a nonzero value if one of the buttons has wParam as its accelerator character, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-mapaccelerator
		[MsgParams(typeof(char), typeof(uint?), LResultType = typeof(BOOL))]
		TB_MAPACCELERATORA = WM_USER + 78,

		/// <summary>
		/// Retrieves the current insertion mark for the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>TBINSERTMARK</c> structure that receives the insertion mark.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Always returns <c>TRUE</c>.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getinsertmark
		[MsgParams(null, typeof(TBINSERTMARK?), LResultType = typeof(BOOL))]
		TB_GETINSERTMARK = WM_USER + 79,

		/// <summary>
		/// Sets the current insertion mark for the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>TBINSERTMARK</c> structure that contains the insertion mark.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value for this message is not used.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setinsertmark
		[MsgParams(null, typeof(TBINSERTMARK?), LResultType = null)]
		TB_SETINSERTMARK = WM_USER + 80,

		/// <summary>
		/// Retrieves the insertion mark information for a point in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Pointer to a <c>POINT</c> structure that contains the hit test coordinates, relative to the client area of the toolbar.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>TBINSERTMARK</c> structure that receives the insertion mark information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if the point is an insertion mark, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-insertmarkhittest
		[MsgParams(typeof(POINT?), typeof(TBINSERTMARK?), LResultType = typeof(BOOL))]
		TB_INSERTMARKHITTEST = WM_USER + 81,

		/// <summary>
		/// Moves a button from one index to another.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the button to be moved.</para>
		/// <para><em>lParam</em></para>
		/// <para>Zero-based index where the button will be moved.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-movebutton
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(BOOL))]
		TB_MOVEBUTTON = WM_USER + 82,

		/// <summary>
		/// Retrieves the total size of all of the visible buttons and separators in the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>SIZE</c> structure that receives the size of the items.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getmaxsize
		[MsgParams(null, typeof(SIZE?), LResultType = typeof(BOOL))]
		TB_GETMAXSIZE = WM_USER + 83,

		/// <summary>
		/// Sets the extended styles for a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Value specifying the new extended styles. This parameter can be a combination of extended styles.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>DWORD</c> that represents the previous extended styles. This value can be a combination of extended styles.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setextendedstyle
		[MsgParams(null, typeof(ToolbarStyleEx), LResultType = typeof(ToolbarStyleEx))]
		TB_SETEXTENDEDSTYLE = WM_USER + 84,

		/// <summary>
		/// Retrieves the extended styles for a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>DWORD</c> that represents the styles currently in use for the toolbar control. This value can be a combination of
		/// extended styles.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getextendedstyle
		[MsgParams(LResultType = typeof(ToolbarStyleEx))]
		TB_GETEXTENDEDSTYLE = WM_USER + 85,

		/// <summary>
		/// Retrieves the padding for a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>DWORD</c> value that contains the horizontal padding in the low word and the vertical padding in the high word, in pixels.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getpadding
		[MsgParams(LResultType = typeof(uint))]
		TB_GETPADDING = WM_USER + 86,

		/// <summary>
		/// Sets the padding for a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>The <c>LOWORD</c> specifies the horizontal padding, in pixels. The <c>HIWORD</c> specifies the vertical padding, in pixels.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns a <c>DWORD</c> value that contains the previous horizontal padding in the <c>LOWORD</c> and the previous vertical padding
		/// in the <c>HIWORD</c>, in pixels.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The padding values are used to create a blank area between the edge of the button and the button's image and/or text. Where and
		/// how much padding is actually applied depends on the type of the button and whether it has an image. The horizontal padding is
		/// applied to both the right and left of the button, and the vertical padding is applied to both the top and bottom of the button.
		/// Padding is only applied to buttons that have the <c>TBSTYLE_AUTOSIZE</c> style.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setpadding
		[MsgParams(null, typeof(uint), LResultType = typeof(uint))]
		TB_SETPADDING = WM_USER + 87,

		/// <summary>
		/// Sets the color used to draw the insertion mark for the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para><c>COLORREF</c> value that contains the new insertion mark color.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>COLORREF</c> value that contains the previous insertion mark color.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setinsertmarkcolor
		[MsgParams(null, typeof(COLORREF), LResultType = typeof(COLORREF))]
		TB_SETINSERTMARKCOLOR = WM_USER + 88,

		/// <summary>
		/// Retrieves the color used to draw the insertion mark for the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>COLORREF</c> value that contains the current insertion mark color.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getinsertmarkcolor
		[MsgParams(LResultType = typeof(COLORREF))]
		TB_GETINSERTMARKCOLOR = WM_USER + 89,

		/// <summary>
		/// Determines the ID of the button that corresponds to the specified accelerator character.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The accelerator character.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>UINT</c>. On return, if successful, this parameter will hold the id of the button that has wParam as its
		/// accelerator character.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a nonzero value if one of the buttons has wParam as its accelerator character, or zero otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-mapaccelerator
		[MsgParams(typeof(char), typeof(uint?), LResultType = typeof(BOOL))]
		TB_MAPACCELERATORW = WM_USER + 90,

		/// <summary>
		/// Retrieves a string from a toolbar's string pool.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> specifies the length of the lParam buffer, in bytes. The <c>HIWORD</c> specifies the index of the string.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a buffer used to return the string.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the string length if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// This message returns the specified string from the toolbar's string pool. It does not necessarily correspond to the text string
		/// currently being displayed by a button. To retrieve a button's current text string, send the toolbar a <c>TB_GETBUTTONTEXT</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getstring
		[MsgParams(typeof(uint), typeof(StrPtrUni))]
		TB_GETSTRINGW = WM_USER + 91,

		/// <summary>
		/// Retrieves a string from a toolbar's string pool.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> specifies the length of the lParam buffer, in bytes. The <c>HIWORD</c> specifies the index of the string.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a buffer used to return the string.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the string length if successful, or -1 otherwise.</para>
		/// </summary>
		/// <remarks>
		/// This message returns the specified string from the toolbar's string pool. It does not necessarily correspond to the text string
		/// currently being displayed by a button. To retrieve a button's current text string, send the toolbar a <c>TB_GETBUTTONTEXT</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getstring
		[MsgParams(typeof(uint), typeof(StrPtrAnsi))]
		TB_GETSTRINGA = WM_USER + 92,

		/// <summary>
		/// <para>
		/// [Intended for internal use; not recommended for use in applications. This message may not be supported in future versions of Windows.]
		/// </para>
		/// <para>Sets the bounding size for a multi-column toolbar control.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>SIZE</c> structure whose <c>cy</c> member contains the bounding height. The <c>cx</c> member (the width) is ignored.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// </summary>
		/// <remarks>
		/// The bounding size controls how buttons are organized into columns. If the toolbar control does not have the
		/// <c>TBSTYLE_EX_MULTICOLUMN</c> style, this message has no effect.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setboundingsize
		[MsgParams(null, typeof(SIZE?), LResultType = null)]
		TB_SETBOUNDINGSIZE = WM_USER + 93,

		/// <summary>
		/// Sets the hot item in a toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the item that will be made hot. If this value is -1, none of the items will be hot.</para>
		/// <para><em>lParam</em></para>
		/// <para>A combination of HICF\_xxx flags. See</para>
		/// <para>**NMTBHOTITEM**</para>
		/// <para>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index of the previous hot item, or -1 if there was no hot item.</para>
		/// </summary>
		/// <remarks>The behavior of this message is not defined for toolbars that do not have the <c>TBSTYLE_FLAT</c> style.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-sethotitem2
		[MsgParams(typeof(int), typeof(HICF))]
		TB_SETHOTITEM2 = WM_USER + 94,

		/// <summary>
		/// <para>
		/// [Intended for internal use; not recommended for use in applications. This message may not be supported in future versions of Windows.]
		/// </para>
		/// <para>Retrieves a count of toolbar buttons that have the specified accelerator character.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A <c>WCHAR</c> representing the input accelerator character to test.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>int</c> that receives the number of buttons that have the accelerator character.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// </summary>
		/// <remarks>
		/// First, the system queries all toolbar buttons for matching accelerators. If no matches are found, the system sends the
		/// TBN_MAPACCELERATOR notification to the parent window, requesting the index of the button that has the specified accelerator
		/// character. If the parent provides an index, the count is set to 1.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-hasaccelerator
		[MsgParams(typeof(char), typeof(int?), LResultType = null)]
		TB_HASACCELERATOR = WM_USER + 95,

		/// <summary>
		/// Sets the distance between the toolbar buttons on a specific toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The gap, in pixels, between buttons on the toolbar.</para>
		/// <para><em>lParam</em></para>
		/// <para>Ignored.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// The gap between buttons only applies to the toolbar control window that receives this message. Receipt of this message triggers a
		/// repaint of the toolbar, if the toolbar is currently visible.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setlistgap
		[MsgParams(typeof(int), null, LResultType = null)]
		TB_SETLISTGAP = WM_USER + 96,

		/// <summary>
		/// Gets the number of image lists associated with the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the number of image lists.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getimagelistcount
		[MsgParams()]
		TB_GETIMAGELISTCOUNT = WM_USER + 98,

		/// <summary>
		/// Gets the ideal size of the toolbar.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A **BOOL** that indicates whether to retrieve the ideal height or width of the toolbar. Use **TRUE** to retrieve the ideal
		/// height, **FALSE** to retrieve the ideal width.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>SIZE</c> structure that receives the height or width at which all buttons would be displayed. If wParam is
		/// <c>TRUE</c>, only the <c>cy</c> member (height) is valid. If wParam is <c>FALSE</c>, only the <c>cx</c> member (width) is valid.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getidealsize
		[MsgParams(typeof(BOOL), typeof(SIZE?), LResultType = typeof(BOOL))]
		TB_GETIDEALSIZE = WM_USER + 99,

		/// <summary>
		/// Retrieves the metrics of a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>TBMETRICS</c> structure that receives the toolbar metrics.</para>
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
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getmetrics
		[MsgParams(null, typeof(TBMETRICS?), LResultType = null)]
		TB_GETMETRICS = WM_USER + 101,

		/// <summary>
		/// Sets the metrics of a toolbar control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para><c>TBMETRICS</c> structure that contains the toolbar metrics to set.</para>
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
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setmetrics
		[MsgParams(null, typeof(TBMETRICS?), LResultType = null)]
		TB_SETMETRICS = WM_USER + 102,

		/// <summary>
		/// Gets the bounding rectangle of the dropdown window for a toolbar item with style <c>BTNS_DROPDOWN</c>.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the toolbar control item for which to retrieve the bounding rectangle.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a</para>
		/// <para>**RECT**</para>
		/// <para>
		/// structure to receive the bounding rectangle information. The message sender is responsible for allocating this structure. The
		/// coordinates returned in the **RECT** structure are expressed as client coordinates.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Always returns nonzero.</para>
		/// </summary>
		/// <remarks>The item must have the <c>BTNS_DROPDOWN</c> style.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getitemdropdownrect
		[MsgParams(typeof(int), typeof(RECT?), LResultType = typeof(BOOL))]
		TB_GETITEMDROPDOWNRECT = WM_USER + 103,

		/// <summary>
		/// Sets the image list that the toolbar uses to display buttons that are in a pressed state.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The index of the image list. If you use only one image list, set this parameter to zero. See Remarks for details on using
		/// multiple image lists.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the image list to set. If this parameter is <c>NULL</c>, no images are displayed in the buttons.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the image list previously used to display buttons in their pressed state, or <c>NULL</c> if no such image
		/// list was previously set.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <para>Note</para>
		/// <para>Your application is responsible for freeing the image list after the toolbar is destroyed.</para>
		/// </para>
		/// <para>
		/// The <c>TB_SETPRESSEDIMAGELIST</c> message cannot be combined with <c>TB_ADDBITMAP</c>. It also cannot be used with toolbars
		/// created with <c>CreateToolbarEx</c>, which calls <c>TB_ADDBITMAP</c> internally. When you create a toolbar with
		/// <c>CreateToolbarEx</c> or use <c>TB_ADDBITMAP</c> to add images, the toolbar manages the image list internally. Attempting to
		/// modify it with <c>TB_SETPRESSEDIMAGELIST</c> has unpredictable consequences.
		/// </para>
		/// <para>Button images need not come from the same image list. To use multiple image lists for your toolbar button images:</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Enable multiple image lists by sending the toolbar control a <c>CCM_SETVERSION</c> message with wParam (the version number) set
		/// to 5.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each image list you want to use, send the toolbar control a <c>TB_SETPRESSEDIMAGELIST</c> message. Set wParam to an
		/// application-defined wParam value that will be used to identify the list. Set lParam to the list's HIMAGELIST handle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each button, set the <c>iBitmap</c> member of the button's <c>TBBUTTON</c> structure to MAKELONG(iIndex, iImageID). The
		/// iImageID value is the ID of the appropriate image list that was defined in step two. The iIndex value is the index of the
		/// particular image within that list.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Add the buttons by sending the toolbar control a <c>TB_ADDBUTTONS</c> message.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The following code fragment illustrates how to add five buttons to a toolbar, with images from three different image lists.
		/// Support for multiple image lists is enabled with a <c>CCM_SETVERSION</c> message. The image lists are then set and assigned IDs
		/// of 0-2. The buttons are assigned images from the image lists as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Button 0 is from image list zero (ahim[0]) with index of 1.</term>
		/// </item>
		/// <item>
		/// <term>Button 1 is from image list one (ahim[1]) with an index of 1.</term>
		/// </item>
		/// <item>
		/// <term>Button 2 is from image list two (ahim[2]) with an index of 1.</term>
		/// </item>
		/// <item>
		/// <term>Button 3 is from image list zero (ahim[0]) with an index of 2.</term>
		/// </item>
		/// <item>
		/// <term>Button 4 is from image list one (ahim[1]) with an index of 3.</term>
		/// </item>
		/// </list>
		/// <para>Finally, the buttons are added to the toolbar control with a <c>TB_ADDBUTTONS</c> message.</para>
		/// <para>
		/// <code>// Enable multiple image lists SendMessage(hwndTB, CCM_SETVERSION, (WPARAM) 5, 0); //Set the image lists and assign them IDs of 0-2 SendMessage(hwndTB, TB_SETPRESSEDIMAGELIST, 0, (LPARAM)ahiml[0]); SendMessage(hwndTB, TB_SETPRESSEDIMAGELIST, 1, (LPARAM)ahiml[1]); SendMessage(hwndTB, TB_SETPRESSEDIMAGELIST, 2, (LPARAM)ahiml[2]); // Create the five buttons TBBUTTON rgtb[5]; //... initialize the TBBUTTON structures as usual ... //Assign images to each button rgtb[0].iBitmap = MAKELONG(1, 0); rgtb[1].iBitmap = MAKELONG(1, 1); rgtb[2].iBitmap = MAKELONG(1, 2); rgtb[3].iBitmap = MAKELONG(2, 0); rgtb[4].iBitmap = MAKELONG(3, 1); // Add the five buttons to the toolbar control SendMessage(hwndTB, TB_ADDBUTTONS, 5, (LPARAM)(&amp;rgtb);</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-setpressedimagelist
		[MsgParams(typeof(int), typeof(HIMAGELIST), LResultType = typeof(HIMAGELIST))]
		TB_SETPRESSEDIMAGELIST = WM_USER + 104,

		/// <summary>
		/// Gets the image list that a toolbar control uses to display buttons in a pressed state.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the image list, or <c>NULL</c> if no image list is set.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tb-getpressedimagelist
		[MsgParams(LResultType = typeof(HIMAGELIST))]
		TB_GETPRESSEDIMAGELIST = WM_USER + 105,
	}

	/// <summary>Toolbar Control Notifications</summary>
	[PInvokeData("Commctrl.h")]
	public enum ToolbarNotification
	{
		/// <summary>
		/// <para>
		/// Retrieves toolbar customization information and notifies the toolbar's parent window of any changes being made to the toolbar.
		/// This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_GETBUTTONINFO lpnmtb = (LPNMTOOLBAR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTOOLBAR</c> structure. The <c>iItem</c> member specifies a zero-based index that provides a count of the
		/// buttons the Customize Toolbar dialog box displays as both available and present on the toolbar. The <c>pszText</c> member
		/// specifies the address of the current button text, and <c>cchText</c> specifies its length in characters. The application should
		/// fill the structure with information about the button.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if button information was copied to the specified structure, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The toolbar control allocates a buffer, and the receiver (parent window) must copy the text into that buffer. The <c>cchText</c>
		/// member contains the length of the buffer allocated by the toolbar when TBN_GETBUTTONINFO is sent to the parent window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-getbuttoninfo
		[CorrespondingType(typeof(NMTOOLBAR))]
		TBN_GETBUTTONINFOA = TBN_FIRST - 0,

		/// <summary>
		/// <para>
		/// Notifies a toolbar's parent window that the user has begun dragging a button in a toolbar. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_BEGINDRAG lpnmtb = (LPNMTOOLBAR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTOOLBAR</c> structure. The <c>iItem</c> member contains the command identifier of the button being dragged.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-begindrag
		[CorrespondingType(typeof(NMTOOLBAR))]
		TBN_BEGINDRAG = TBN_FIRST - 1,

		/// <summary>
		/// <para>
		/// Notifies the toolbar's parent window that the user has stopped dragging a button in a toolbar. This notification code is sent in
		/// the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_ENDDRAG lpnmtb = (LPNMTOOLBAR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTOOLBAR</c> structure. The <c>iItem</c> member contains the command identifier of the button being dragged.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-enddrag
		[CorrespondingType(typeof(NMTOOLBAR))]
		TBN_ENDDRAG = TBN_FIRST - 2,

		/// <summary>
		/// <para>
		/// Notifies a toolbar's parent window that the user has begun customizing a toolbar. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_BEGINADJUST lpnmhdr = (LPNMHDR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMHDR</c> structure that contains information about the notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-beginadjust
		[CorrespondingType(typeof(NMHDR))]
		TBN_BEGINADJUST = TBN_FIRST - 3,

		/// <summary>
		/// <para>
		/// Notifies a toolbar's parent window that the user has stopped customizing a toolbar. This notification code is sent in the form of
		/// a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_ENDADJUST lpnmhdr = (LPNMHDR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMHDR</c> structure that contains information about the notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-endadjust
		[CorrespondingType(typeof(NMHDR))]
		TBN_ENDADJUST = TBN_FIRST - 4,

		/// <summary>
		/// <para>
		/// Notifies the toolbar's parent window that the user has reset the content of the Customize Toolbar dialog box. This notification
		/// code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_RESET lpnmhdr = (LPNMHDR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMHDR</c> structure that contains information about the notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return TBNRF_ENDCUSTOMIZE to close the Customize Toolbar dialog box. All other return values are ignored.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-reset
		[CorrespondingType(typeof(NMHDR))]
		TBN_RESET = TBN_FIRST - 5,

		/// <summary>
		/// <para>
		/// Notifies the toolbar's parent window whether a button may be inserted to the left of the specified button while the user is
		/// customizing a toolbar. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_QUERYINSERT lpnmtb = (LPNMTOOLBAR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTOOLBAR</c> structure. The <c>iItem</c> member contains the zero-based index of the button to be inserted.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Return <c>TRUE</c> to allow a button to be inserted in front of the given button, or <c>FALSE</c> to prevent the button from
		/// being inserted.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-queryinsert
		[CorrespondingType(typeof(NMTOOLBAR))]
		TBN_QUERYINSERT = TBN_FIRST - 6,

		/// <summary>
		/// <para>
		/// Notifies the toolbar's parent window whether a button may be deleted from a toolbar while the user is customizing the toolbar.
		/// This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_QUERYDELETE lpnmtb = (LPNMTOOLBAR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTOOLBAR</c> structure. The <c>iItem</c> member contains the zero-based index of the button to be deleted.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> to allow the button to be deleted, or <c>FALSE</c> to prevent the button from being deleted.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-querydelete
		[CorrespondingType(typeof(NMTOOLBAR))]
		TBN_QUERYDELETE = TBN_FIRST - 7,

		/// <summary>
		/// <para>
		/// Notifies the toolbar's parent window that the user has customized a toolbar. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_TOOLBARCHANGE lpnmhdr = (LPNMHDR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMHDR</c> structure that contains information about the notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-toolbarchange
		[CorrespondingType(typeof(NMHDR))]
		TBN_TOOLBARCHANGE = TBN_FIRST - 8,

		/// <summary>
		/// <para>
		/// Notifies a toolbar's parent window that the user has chosen the Help button in the Customize Toolbar dialog box. This
		/// notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_CUSTHELP lpnmhdr = (LPNMHDR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMHDR</c> structure that contains information about the notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-custhelp
		[CorrespondingType(typeof(NMHDR))]
		TBN_CUSTHELP = TBN_FIRST - 9,

		/// <summary>
		/// <para>
		/// Sent by a toolbar control when the user clicks a dropdown button. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_DROPDOWN lpnmtb = (LPNMTOOLBAR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTOOLBAR</c> structure that contains information about this notification code. For this notification code, only
		/// the <c>hdr</c> and <c>iItem</c> members of this structure are valid.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>TBDDRET_DEFAULT</c></term>
		/// <term>The drop-down was handled.</term>
		/// </item>
		/// <item>
		/// <term><c>TBDDRET_NODEFAULT</c></term>
		/// <term>The drop-down was not handled.</term>
		/// </item>
		/// <item>
		/// <term><c>TBDDRET_TREATPRESSED</c></term>
		/// <term>The drop-down was handled, but treat the button like a regular button.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// Dropdown buttons can be plain ( <c>BTNS_DROPDOWN</c> style), display an arrow next to the button image (
		/// <c>BTNS_WHOLEDROPDOWN</c> style), or display an arrow that is separated from the image ( <c>TBSTYLE_EX_DRAWDDARROWS</c> style).
		/// If a separated arrow is used, TBN_DROPDOWN is sent only if the user clicks the arrow portion of the button. If the user clicks
		/// the main part of the button, a <c>WM_COMMAND</c> message with button's ID is sent, just as with a standard button. For the other
		/// two styles of dropdown button, TBN_DROPDOWN is sent when the user clicks any part of the button.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-dropdown
		[CorrespondingType(typeof(NMTOOLBAR))]
		TBN_DROPDOWN = TBN_FIRST - 10,

		/// <summary>
		/// <para>
		/// Sent by a toolbar control that uses the <c>TBSTYLE_REGISTERDROP</c> style to request a drop target object when the pointer passes
		/// over one of its buttons. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_GETOBJECT lpnmon = (LPNMOBJECTNOTIFY) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMOBJECTNOTIFY</c> structure that contains information about the button that the pointer passed over and
		/// receives data the application provides in response to this notification code.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The application processing this notification code must return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To provide an object, an application must set values in some members of the <c>NMOBJECTNOTIFY</c> structure at lParam. The
		/// <c>pObject</c> member must be set to a valid object pointer, and the <c>hResult</c> member must be set to a success flag. To
		/// comply with Component Object Model (COM) standards, always increment the object's reference count when providing an object pointer.
		/// </para>
		/// <para>
		/// If an application does not provide an object, it must set <c>pObject</c> to <c>NULL</c> and <c>hResult</c> to a failure flag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-getobject
		[CorrespondingType(typeof(NMOBJECTNOTIFY))]
		TBN_GETOBJECT = TBN_FIRST - 12,

		/// <summary>
		/// <para>
		/// Sent by a toolbar control when the hot (highlighted) item changes. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_HOTITEMCHANGE lpnmhi = (LPNMTBHOTITEM) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTBHOTITEM</c> structure that contains information about this notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return zero to allow the item to be highlighted, or nonzero to prevent the item from being highlighted.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-hotitemchange
		[CorrespondingType(typeof(NMTBHOTITEM))]
		TBN_HOTITEMCHANGE = TBN_FIRST - 13,

		/// <summary>
		/// <para>
		/// Sent by a toolbar control when the user clicks a button and then moves the cursor off the button. This notification code is sent
		/// in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_DRAGOUT lpnmtb = (LPNMTOOLBAR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTOOLBAR</c> structure that contains information about this notification code. For this notification code, only
		/// the <c>hdr</c> and <c>iItem</c> members of this structure are valid. The <c>iItem</c> member of this structure contains the
		/// command identifier of the button being dragged.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		/// <remarks>
		/// This notification code allows an application to implement drag-and-drop functionality for toolbar buttons. When processing this
		/// notification code, the application will begin the drag-and-drop operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-dragout
		[CorrespondingType(typeof(NMTOOLBAR))]
		TBN_DRAGOUT = TBN_FIRST - 14,

		/// <summary>
		/// <para>
		/// Sent by a toolbar control when a button is about to be deleted. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code> TBN_DELETINGBUTTON lpnmtb = (LPNMTOOLBAR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTOOLBAR</c> structure that contains information about the button being deleted. For this notification code,
		/// only the <c>hdr</c> and <c>iItem</c> members of this structure are valid. The <c>iItem</c> member of this structure contains the
		/// command identifier of the button being deleted.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-deletingbutton
		[CorrespondingType(typeof(NMTOOLBAR))]
		TBN_DELETINGBUTTON = TBN_FIRST - 15,

		/// <summary>
		/// <para>Retrieves display information for a toolbar item. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.</para>
		/// <para>
		/// <code>TBN_GETDISPINFO lptbdi = (LPNMTBDISPINFO) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTBDISPINFO</c> structure. The <c>idCommand</c> member specifies the item's command identifier, the
		/// <c>lParam</c> member contains the item's application-defined data, and the <c>dwMask</c> member specifies what information is
		/// being requested.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored by the control.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-getdispinfo
		[CorrespondingType(typeof(NMTBDISPINFO))]
		TBN_GETDISPINFOA = TBN_FIRST - 16,

		/// <summary>
		/// <para>Retrieves display information for a toolbar item. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.</para>
		/// <para>
		/// <code>TBN_GETDISPINFO lptbdi = (LPNMTBDISPINFO) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTBDISPINFO</c> structure. The <c>idCommand</c> member specifies the item's command identifier, the
		/// <c>lParam</c> member contains the item's application-defined data, and the <c>dwMask</c> member specifies what information is
		/// being requested.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored by the control.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-getdispinfo
		[CorrespondingType(typeof(NMTBDISPINFO))]
		TBN_GETDISPINFOW = TBN_FIRST - 17,

		/// <summary>
		/// <para>Retrieves infotip information for a toolbar item. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.</para>
		/// <para>
		/// <code>TBN_GETINFOTIP lptbgit = (LPNMTBGETINFOTIP) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTBGETINFOTIP</c> structure that contains item information and receives infotip information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored by the control.</para>
		/// </summary>
		/// <remarks>
		/// The infotip support in the toolbar allows the toolbar to display tooltips for items that are as large as INFOTIPSIZE characters.
		/// If this notification code is not processed, the toolbar will use the item's text for the infotip.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-getinfotip
		[CorrespondingType(typeof(NMTBGETINFOTIP))]
		TBN_GETINFOTIPA = TBN_FIRST - 18,

		/// <summary>
		/// <para>Retrieves infotip information for a toolbar item. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.</para>
		/// <para>
		/// <code>TBN_GETINFOTIP lptbgit = (LPNMTBGETINFOTIP) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTBGETINFOTIP</c> structure that contains item information and receives infotip information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored by the control.</para>
		/// </summary>
		/// <remarks>
		/// The infotip support in the toolbar allows the toolbar to display tooltips for items that are as large as INFOTIPSIZE characters.
		/// If this notification code is not processed, the toolbar will use the item's text for the infotip.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-getinfotip
		[CorrespondingType(typeof(NMTBGETINFOTIP))]
		TBN_GETINFOTIPW = TBN_FIRST - 19,

		/// <summary>
		/// <para>
		/// Retrieves toolbar customization information and notifies the toolbar's parent window of any changes being made to the toolbar.
		/// This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_GETBUTTONINFO lpnmtb = (LPNMTOOLBAR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMTOOLBAR</c> structure. The <c>iItem</c> member specifies a zero-based index that provides a count of the
		/// buttons the Customize Toolbar dialog box displays as both available and present on the toolbar. The <c>pszText</c> member
		/// specifies the address of the current button text, and <c>cchText</c> specifies its length in characters. The application should
		/// fill the structure with information about the button.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if button information was copied to the specified structure, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The toolbar control allocates a buffer, and the receiver (parent window) must copy the text into that buffer. The <c>cchText</c>
		/// member contains the length of the buffer allocated by the toolbar when TBN_GETBUTTONINFO is sent to the parent window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-getbuttoninfo
		[CorrespondingType(typeof(NMTOOLBAR))]
		TBN_GETBUTTONINFOW = TBN_FIRST - 20,

		/// <summary>
		/// <para>
		/// Notifies a toolbar's parent window that a toolbar is in the process of being restored. This notification code is sent in the form
		/// of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_RESTORE lpnmtb = (LPNMTBRESTORE) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTBRESTORE</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The application should return zero in response to the first <c>TBN_RESTORE</c> notification code received at the start of the
		/// restore process to continue restoring the button information. If the application returns a nonzero value, the restore process is canceled.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The application will receive this notification code once at the start of the restore process and once for each button. This
		/// notification code gives you an opportunity to extract the information from the data stream that you saved previously. If you
		/// haven't saved any information, ignore the notification code. See Toolbar Customization for a more detailed discussion of how to
		/// handle <c>TBN_RESTORE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-restore
		[CorrespondingType(typeof(NMTBRESTORE))]
		TBN_RESTORE = TBN_FIRST - 21,

		/// <summary>
		/// <para>
		/// Notifies a toolbar's parent window that a toolbar is in the process of being saved. This notification code is sent in the form of
		/// a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_SAVE lpnmtb = (LPNMTBSAVE) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMTBSAVE</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// The application will receive this notification code once at the start of the save process and once for each button. This
		/// notification code gives you an opportunity to add your own information to that saved by the Shell. If you do not wish to add
		/// information, ignore the notification code. See Toolbar Customization for a more detailed discussion of how to handle TBN_SAVE.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-save
		[CorrespondingType(typeof(NMTBSAVE))]
		TBN_SAVE = TBN_FIRST - 22,

		/// <summary>
		/// <para>
		/// Notifies a toolbar's parent window that customizing has started. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_INITCUSTOMIZE lpnmhdr = (LPNMHDR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to the toolbar's <c>NMHDR</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns TBNRF_HIDEHELP to suppress the Help button.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-initcustomize
		[CorrespondingType(typeof(NMHDR))]
		TBN_INITCUSTOMIZE = TBN_FIRST - 23,

		/// <summary>
		/// <para>
		/// Notifies an application with two or more toolbars that the hot item is about to change. This notification code is sent in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_WRAPHOTITEM lpnmtb = (NMTBWRAPHOTITEM) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a structure that contains the old hot item ( <c>iStart</c>) and whether the new hot item is before it ( <c>iDir</c>
		/// = -1) or after it ( <c>iDir</c> = 1), as well as a reason why the hot item is changing.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para><c>TRUE</c> if the application is handling the hot item change itself; otherwise <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>NMTBWRAPHOTITEM</c> structure must be defined by the application as follows:</para>
		/// <para>
		/// <code>typedef struct tagNMTBWRAPHOTITEM { NMHDR hdr; int iStart; int iDir; UINT nReason; // HICF_* flags } NMTBWRAPHOTITEM, *LPNMTBWRAPHOTITEM;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-wraphotitem
		[CorrespondingType(typeof(NMTBWRAPHOTITEM))]
		TBN_WRAPHOTITEM = TBN_FIRST - 24,

		/// <summary>
		/// <para>
		/// Ascertains whether an accelerator key can be used on two or more active toolbars. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_DUPACCELERATOR lpnmtb = (NMTBDUPACCELERATOR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a structure that provides an accelerator and that receives a value specifying whether multiple toolbars respond to
		/// the same character.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, otherwise <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>The application must declare the <c>NMTBDUPACCELERATOR</c> structure as follows:</para>
		/// <para>
		/// <code>typedef struct tagNMTBDUPACCELERATOR { NMHDR hdr; UINT ch; // The accelerator. BOOL fDup; // TRUE if multiple toolbars respond to the accelerator. } NMTBDUPACCELERATOR, *LPNMTBDUPACCELERATOR;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-dupaccelerator
		[CorrespondingType(typeof(NMTBDUPACCELERATOR))]
		TBN_DUPACCELERATOR = TBN_FIRST - 25,

		/// <summary>
		/// <para>
		/// Requests the index of the button in one or more toolbars corresponding to the specified accelerator character. This notification
		/// code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_WRAPACCELERATOR lpnmtb = (NMTBWRAPACCELERATOR) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a structure that contains the accelerator key character, and that receives the index of the corresponding button.
		/// The index is -1 if the accelerator does not correspond to a command.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para><c>TRUE</c> if an index is returned, otherwise <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>Applications with one or more toolbars may receive this notification code.</para>
		/// <para>The <c>NMTBWRAPACCELERATOR</c> structure must be defined by the application as follows:</para>
		/// <para>
		/// <code>typedef struct tagNMTBWRAPACCELERATOR { NMHDR hdr; UINT ch; int iButton; } NMTBWRAPACCELERATOR, *LPNMTBWRAPACCELERATOR;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-wrapaccelerator
		[CorrespondingType(typeof(NMTBWRAPACCELERATOR))]
		TBN_WRAPACCELERATOR = TBN_FIRST - 26,

		/// <summary>
		/// <para>
		/// Ascertains whether a <c>TB_MARKBUTTON</c> message should be sent for a button that is being dragged over. This notification code
		/// is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_DRAGOVER lpnmtb = (NMTBHOTITEM*) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to an <c>NMTBHOTITEM</c> structure that specifies which item is being dragged over.</para>
		/// <para><strong>Returns</strong></para>
		/// <para><c>FALSE</c> if the toolbar should send a TB_MARKBUTTON message; otherwise <c>TRUE</c>.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-dragover
		[CorrespondingType(typeof(NMTBHOTITEM))]
		TBN_DRAGOVER = TBN_FIRST - 27,

		/// <summary>
		/// <para>
		/// Requests the index of the button in the toolbar corresponding to the specified accelerator character. This notification code is
		/// sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para>
		/// <code>TBN_MAPACCELERATOR lpnmtb = (NMCHAR*) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to an <c>NMCHAR</c> structure that contains the accelerator key character and that receives the index of the
		/// corresponding button. The <c>dwItemNext</c> field is -1 if the accelerator does not correspond to a command.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>TRUE if <c>NMCHAR.dwItemNext</c> is set to a value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/tbn-mapaccelerator
		[CorrespondingType(typeof(NMCHAR))]
		TBN_MAPACCELERATOR = TBN_FIRST - 28,
	}

	/// <summary>Toolbar Control and Button Styles</summary>
	[PInvokeData("CommCtrl.h")]
	[Flags]
	public enum ToolbarStyle : ushort
	{
		/// <summary>
		/// Allows users to change a toolbar button's position by dragging it while holding down the ALT key. If this style is not specified,
		/// the user must hold down the SHIFT key while dragging a button. Note that the CCS_ADJUSTABLE style must be specified to enable
		/// toolbar buttons to be dragged.
		/// </summary>
		TBSTYLE_ALTDRAG = 0x0400,

		/// <summary>Equivalent to BTNS_AUTOSIZE. Use TBSTYLE_AUTOSIZE for version 4.72 and earlier.</summary>
		TBSTYLE_AUTOSIZE = 0x0010,

		/// <summary>Equivalent to BTNS_BUTTON. Use TBSTYLE_BUTTON for version 4.72 and earlier.</summary>
		TBSTYLE_BUTTON = 0x0000,

		/// <summary>Equivalent to BTNS_CHECK. Use TBSTYLE_CHECK for version 4.72 and earlier.</summary>
		TBSTYLE_CHECK = 0x0002,

		/// <summary>Equivalent to BTNS_CHECKGROUP. Use TBSTYLE_CHECKGROUP for version 4.72 and earlier.</summary>
		TBSTYLE_CHECKGROUP = TBSTYLE_GROUP | TBSTYLE_CHECK,

		/// <summary>Version 4.70. Generates NM_CUSTOMDRAW notification codes when the toolbar processes WM_ERASEBKGND messages.</summary>
		TBSTYLE_CUSTOMERASE = 0x2000,

		/// <summary>Equivalent to BTNS_DROPDOWN. Use TBSTYLE_DROPDOWN for version 4.72 and earlier.</summary>
		TBSTYLE_DROPDOWN = 0x0008,

		/// <summary>
		/// Version 4.70. Creates a flat toolbar. In a flat toolbar, both the toolbar and the buttons are transparent and hot-tracking is
		/// enabled. Button text appears under button bitmaps. To prevent repainting problems, this style should be set before the toolbar
		/// control becomes visible.
		/// </summary>
		TBSTYLE_FLAT = 0x0800,

		/// <summary>Equivalent to BTNS_GROUP. Use TBSTYLE_GROUP for version 4.72 and earlier.</summary>
		TBSTYLE_GROUP = 0x0004,

		/// <summary>
		/// Version 4.70. Creates a flat toolbar with button text to the right of the bitmap. Otherwise, this style is identical to
		/// TBSTYLE_FLAT. To prevent repainting problems, this style should be set before the toolbar control becomes visible.
		/// </summary>
		TBSTYLE_LIST = 0x1000,

		/// <summary>Equivalent to BTNS_NOPREFIX. Use TBSTYLE_NOPREFIX for version 4.72 and earlier.</summary>
		TBSTYLE_NOPREFIX = 0x0020,

		/// <summary>
		/// Version 4.71. Generates TBN_GETOBJECT notification codes to request drop target objects when the cursor passes over toolbar buttons.
		/// </summary>
		TBSTYLE_REGISTERDROP = 0x4000,

		/// <summary>Equivalent to BTNS_SEP. Use TBSTYLE_SEP for version 4.72 and earlier.</summary>
		TBSTYLE_SEP = 0x0001,

		/// <summary>Creates a tooltip control that an application can use to display descriptive text for the buttons in the toolbar.</summary>
		TBSTYLE_TOOLTIPS = 0x0100,

		/// <summary>
		/// Version 4.71. Creates a transparent toolbar. In a transparent toolbar, the toolbar is transparent but the buttons are not. Button
		/// text appears under button bitmaps. To prevent repainting problems, this style should be set before the toolbar control becomes visible.
		/// </summary>
		TBSTYLE_TRANSPARENT = 0x8000,

		/// <summary>
		/// Creates a toolbar that can have multiple lines of buttons. Toolbar buttons can "wrap" to the next line when the toolbar becomes
		/// too narrow to include all buttons on the same line. When the toolbar is wrapped, the break will occur on either the rightmost
		/// separator or the rightmost button if there are no separators on the bar. This style must be set to display a vertical toolbar
		/// control when the toolbar is part of a vertical rebar control. This style cannot be combined with CCS_VERT.
		/// </summary>
		TBSTYLE_WRAPABLE = 0x0200,

		/// <summary>
		/// Version 5.80. Creates a standard button. Use the equivalent style flag, TBSTYLE_BUTTON, for version 4.72 and earlier. This flag
		/// is defined as 0, and should be used to signify that no other flags are set.
		/// </summary>
		BTNS_BUTTON = TBSTYLE_BUTTON,

		/// <summary>
		/// Version 5.80. Creates a separator, providing a small gap between button groups. A button that has this style does not receive
		/// user input. Use the equivalent style flag, TBSTYLE_SEP, for version 4.72 and earlier.
		/// </summary>
		BTNS_SEP = TBSTYLE_SEP,

		/// <summary>
		/// Version 5.80. Creates a dual-state push button that toggles between the pressed and nonpressed states each time the user clicks
		/// it. The button has a different background color when it is in the pressed state. Use the equivalent style flag, TBSTYLE_CHECK,
		/// for version 4.72 and earlier.
		/// </summary>
		BTNS_CHECK = TBSTYLE_CHECK,

		/// <summary>
		/// Version 5.80. When combined with BTNS_CHECK, creates a button that stays pressed until another button in the group is pressed.
		/// Use the equivalent style flag, TBSTYLE_GROUP, for version 4.72 and earlier.
		/// </summary>
		BTNS_GROUP = TBSTYLE_GROUP,

		/// <summary>
		/// Version 5.80. Creates a button that stays pressed until another button in the group is pressed, similar to option buttons (also
		/// known as radio buttons). It is equivalent to combining BTNS_CHECK and BTNS_GROUP. Use the equivalent style flag,
		/// TBSTYLE_CHECKGROUP, for version 4.72 and earlier.
		/// </summary>
		BTNS_CHECKGROUP = TBSTYLE_CHECKGROUP,

		/// <summary>
		/// Version 5.80. Creates a drop-down style button that can display a list when the button is clicked. Instead of the WM_COMMAND
		/// message used for normal buttons, drop-down buttons send a TBN_DROPDOWN notification code. An application can then have the
		/// notification handler display a list of options. Use the equivalent style flag, TBSTYLE_DROPDOWN, for version 4.72 and earlier.
		/// <para>
		/// If the toolbar has the TBSTYLE_EX_DRAWDDARROWS extended style, drop-down buttons will have a drop-down arrow displayed in a
		/// separate section to their right. If the arrow is clicked, a TBN_DROPDOWN notification code will be sent. If the associated button
		/// is clicked, a WM_COMMAND message will be sent.
		/// </para>
		/// </summary>
		BTNS_DROPDOWN = TBSTYLE_DROPDOWN,

		/// <summary>
		/// Version 5.80. Specifies that the toolbar control should not assign the standard width to the button. Instead, the button's width
		/// will be calculated based on the width of the text plus the image of the button. Use the equivalent style flag, TBSTYLE_AUTOSIZE,
		/// for version 4.72 and earlier.
		/// </summary>
		BTNS_AUTOSIZE = TBSTYLE_AUTOSIZE,

		/// <summary>
		/// Version 5.80. Specifies that the button text will not have an accelerator prefix associated with it. Use the equivalent style
		/// flag, TBSTYLE_NOPREFIX, for version 4.72 and earlier.
		/// </summary>
		BTNS_NOPREFIX = TBSTYLE_NOPREFIX,

		/// <summary>
		/// Version 5.81. Specifies that button text should be displayed. All buttons can have text, but only those buttons with the
		/// BTNS_SHOWTEXT button style will display it. This button style must be used with the TBSTYLE_LIST style and the
		/// TBSTYLE_EX_MIXEDBUTTONS extended style. If you set text for buttons that do not have the BTNS_SHOWTEXT style, the toolbar control
		/// will automatically display it as a tooltip when the cursor hovers over the button. This feature allows your application to avoid
		/// handling the TBN_GETINFOTIP or TTN_GETDISPINFO notification code for the toolbar.
		/// </summary>
		BTNS_SHOWTEXT = 0x0040,

		/// <summary>
		/// Version 5.80. Specifies that the button will have a drop-down arrow, but not as a separate section. Buttons with this style
		/// behave the same, regardless of whether the TBSTYLE_EX_DRAWDDARROWS extended style is set.
		/// </summary>
		BTNS_WHOLEDROPDOWN = 0x0080,
	}

	/// <summary>This section lists the extended styles supported by toolbar controls.</summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb760430(v=vs.85).aspx
	[PInvokeData("CommCtrl.h", MSDNShortId = "bb760430")]
	[Flags]
	public enum ToolbarStyleEx
	{
		/// <summary>
		/// Version 4.71. This style allows buttons to have a separate dropdown arrow. Buttons that have the BTNS_DROPDOWN style will be
		/// drawn with a dropdown arrow in a separate section, to the right of the button. If the arrow is clicked, only the arrow portion of
		/// the button will depress, and the toolbar control will send a TBN_DROPDOWN notification code to prompt the application to display
		/// the dropdown menu. If the main part of the button is clicked, the toolbar control sends a WM_COMMAND message with the button's
		/// ID. The application normally responds by launching the first command on the menu. There are many situations where you may want to
		/// have only some of the dropdown buttons on a toolbar with separated arrows. To do so, set the TBSTYLE_EX_DRAWDDARROWS extended
		/// style. Give those buttons that will not have separated arrows the BTNS_WHOLEDROPDOWN style. Buttons with this style will have an
		/// arrow displayed next to the image. However, the arrow will not be separate and when any part of the button is clicked, the
		/// toolbar control will send a TBN_DROPDOWN notification code. To prevent repainting problems, this style should be set before the
		/// toolbar control becomes visible.
		/// </summary>
		TBSTYLE_EX_DRAWDDARROWS = 0x00000001,

		/// <summary>
		/// Version 5.81. This style allows you to set text for all buttons, but only display it for those buttons with the BTNS_SHOWTEXT
		/// button style. The TBSTYLE_LIST style must also be set. Normally, when a button does not display text, your application must
		/// handle TBN_GETINFOTIP or TTN_GETDISPINFO to display a tooltip. With the TBSTYLE_EX_MIXEDBUTTONS extended style, text that is set
		/// but not displayed on a button will automatically be used as the button's tooltip text. Your application only needs to handle
		/// TBN_GETINFOTIP or or TTN_GETDISPINFO if it needs more flexibility in specifying the tooltip text.
		/// </summary>
		TBSTYLE_EX_MIXEDBUTTONS = 0x00000008,

		/// <summary>
		/// Version 5.81. This style hides partially clipped buttons. The most common use of this style is for toolbars that are part of a
		/// rebar control. If an adjacent band covers part of a button, the button will not be displayed. However, if the rebar band has the
		/// RBBS_USECHEVRON style, the button will be displayed on the chevron's dropdown menu.
		/// </summary>
		TBSTYLE_EX_HIDECLIPPEDBUTTONS = 0x00000010,

		/// <summary>
		/// Version 5.82. Intended for internal use; not recommended for use in applications. This style gives the toolbar a vertical
		/// orientation and organizes the toolbar buttons into columns. The buttons flow down vertically until a button has exceeded the
		/// bounding height of the toolbar (see TB_SETBOUNDINGSIZE), and then a new column is created. The toolbar flows the buttons in this
		/// manner until all buttons are positioned. To use this style, the TBSTYLE_EX_VERTICAL style must also be set.
		/// </summary>
		TBSTYLE_EX_MULTICOLUMN = 0x00000002,

		/// <summary>
		/// Version 5.82. Intended for internal use; not recommended for use in applications. This style gives the toolbar a vertical
		/// orientation. Toolbar buttons flow from top to bottom instead of horizontally.
		/// </summary>
		TBSTYLE_EX_VERTICAL = 0x00000004,

		/// <summary>
		/// Version 6. This style requires the toolbar to be double buffered. Double buffering is a mechanism that detects when the toolbar
		/// has changed.
		/// </summary>
		TBSTYLE_EX_DOUBLEBUFFER = 0x00000080,
	}

	/// <summary>Index values for IDB_VIEW_LARGE_COLOR and IDB_VIEW_SMALL_COLOR</summary>
	[PInvokeData("Commctrl.h")]
	public enum VIEW
	{
		/// <summary>Large icons view.</summary>
		VIEW_LARGEICONS = 0,

		/// <summary>Small icons view.</summary>
		VIEW_SMALLICONS = 1,

		/// <summary>List view.</summary>
		VIEW_LIST = 2,

		/// <summary>Details view.</summary>
		VIEW_DETAILS = 3,

		/// <summary>Sort by name.</summary>
		VIEW_SORTNAME = 4,

		/// <summary>Sort by size.</summary>
		VIEW_SORTSIZE = 5,

		/// <summary>Sort by date.</summary>
		VIEW_SORTDATE = 6,

		/// <summary>Sort by type.</summary>
		VIEW_SORTTYPE = 7,

		/// <summary>Go to parent folder.</summary>
		VIEW_PARENTFOLDER = 8,

		/// <summary>Connect to network drive.</summary>
		VIEW_NETCONNECT = 9,

		/// <summary>Disconnect to network drive.</summary>
		VIEW_NETDISCONNECT = 10,

		/// <summary>New folder.</summary>
		VIEW_NEWFOLDER = 11,

		/// <summary>View menu.</summary>
		VIEW_VIEWMENU = 12,
	}

	/// <summary>Creates a bitmap for use in a toolbar.</summary>
	/// <param name="hInstance">
	/// <para>Type: <c><c>HINSTANCE</c></c></para>
	/// <para>Handle to the module instance with the executable file that contains the bitmap resource.</para>
	/// </param>
	/// <param name="idBitmap">
	/// <para>Type: <c><c>INT_PTR</c></c></para>
	/// <para>Resource identifier of the bitmap resource.</para>
	/// </param>
	/// <param name="wFlags">
	/// <para>Type: <c><c>UINT</c></c></para>
	/// <para>Bitmap flag. This parameter can be zero or the following value:</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMB_MASKED</term>
	/// <term>Uses a bitmap as a mask.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpColorMap">
	/// <para>Type: <c>LPCOLORMAP</c></para>
	/// <para>
	/// Pointer to a <c>COLORMAP</c> structure that contains the color information needed to map the bitmaps. If this parameter is
	/// <c>NULL</c>, the function uses the default color map.
	/// </para>
	/// </param>
	/// <param name="iNumMaps">
	/// <para>Type: <c>int</c></para>
	/// <para>Number of color maps pointed to by lpColorMap.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HBITMAP</c></c></para>
	/// <para>Returns the handle to the bitmap if successful, or <c>NULL</c> otherwise. To retrieve extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HBITMAP CreateMappedBitmap( HINSTANCE hInstance, INT_PTR idBitmap, UINT wFlags, _In_ LPCOLORMAP lpColorMap, int iNumMaps); https://msdn.microsoft.com/en-us/library/windows/desktop/bb787467(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Commctrl.h", MSDNShortId = "bb787467")]
	public static extern IntPtr CreateMappedBitmap(HINSTANCE hInstance, SafeResourceId idBitmap, CMB wFlags, in COLORMAP lpColorMap, int iNumMaps);

	/// <summary>Retrieves the display text of a button on a toolbar.</summary>
	/// <param name="hwnd">The handle to the toolbar.</param>
	/// <param name="btnCmdId">Command identifier of the button whose text is to be retrieved.</param>
	/// <returns>The button text.</returns>
	public static string ToolBar_GetButtonText(HWND hwnd, int btnCmdId)
	{
		ToolbarMessage tbm = Marshal.SystemDefaultCharSize == 2 ? ToolbarMessage.TB_GETBUTTONTEXTW : ToolbarMessage.TB_GETBUTTONTEXTA;
		int len = SendMessage(hwnd, tbm, btnCmdId, IntPtr.Zero).ToInt32();
		if (len == 0)
			return string.Empty;
		using SafeCoTaskMemString buf = new(len + 1, tbm == ToolbarMessage.TB_GETBUTTONTEXTW ? CharSet.Unicode : CharSet.Ansi);
		len = SendMessage(hwnd, tbm, btnCmdId, (IntPtr)buf).ToInt32();
		if (len == -1) Win32Error.ThrowLastError();
		return buf.ToString()!;
	}

	/// <summary>Contains information used by the <c>CreateMappedBitmap</c> function to map the colors of the bitmap.</summary>
	// typedef struct _COLORMAP { COLORREF from; COLORREF to;} COLORMAP, *LPCOLORMAP; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760448(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760448")]
	public struct COLORMAP
	{
		/// <summary>
		/// <para>Type: <c><c>COLORREF</c></c></para>
		/// <para>Color to map from.</para>
		/// </summary>
		public COLORREF from;

		/// <summary>
		/// <para>Type: <c><c>COLORREF</c></c></para>
		/// <para>Color to map to.</para>
		/// </summary>
		public COLORREF to;
	}

	/// <summary>Contains information specific to an NM_CUSTOMDRAW notification code sent by a toolbar control.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-nmtbcustomdraw typedef struct _NMTBCUSTOMDRAW { NMCUSTOMDRAW
	// nmcd; HBRUSH hbrMonoDither; HBRUSH hbrLines; HPEN hpenLines; COLORREF clrText; COLORREF clrMark; COLORREF clrTextHighlight; COLORREF
	// clrBtnFace; COLORREF clrBtnHighlight; COLORREF clrHighlightHotTrack; RECT rcText; int nStringBkMode; int nHLStringBkMode; int
	// iListGap; } NMTBCUSTOMDRAW, *LPNMTBCUSTOMDRAW;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl._NMTBCUSTOMDRAW")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMTBCUSTOMDRAW : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMCUSTOMDRAW</c></para>
		/// <para>
		/// NMCUSTOMDRAW structure that contains general custom draw information. The <c>uItemState</c> member of this structure can be
		/// modified so that a toolbar item will be drawn in the specified state without actually changing the item's state.
		/// </para>
		/// </summary>
		public NMCUSTOMDRAW nmcd;

		/// <summary>
		/// <para>Type: <c>HBRUSH</c></para>
		/// <para>
		/// HBRUSH that the control will use when drawing the background of marked or dithered items. This member is ignored if TBCDRF_NOMARK
		/// is returned from the NM_CUSTOMDRAW notification code.
		/// </para>
		/// </summary>
		public HBRUSH hbrMonoDither;

		/// <summary>
		/// <para>Type: <c>HBRUSH</c></para>
		/// <para>HBRUSH that the control will use when drawing lines on the buttons.</para>
		/// </summary>
		public HBRUSH hbrLines;

		/// <summary>
		/// <para>Type: <c>HPEN</c></para>
		/// <para>HPEN that the control will use when drawing lines on the buttons.</para>
		/// </summary>
		public HPEN hpenLines;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>COLORREF that represents the color that the control will use when drawing text on normal items.</para>
		/// </summary>
		public COLORREF clrText;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para><c>COLORREF</c> that represents the background color that the control will use when drawing text on marked items.</para>
		/// </summary>
		public COLORREF clrMark;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para><c>COLORREF</c> that represents the color that the control will use when drawing text on highlighted items.</para>
		/// </summary>
		public COLORREF clrTextHighlight;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para><c>COLORREF</c> that represents the face color that the control will use when drawing buttons.</para>
		/// </summary>
		public COLORREF clrBtnFace;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>
		/// <c>COLORREF</c> that represents the face color that the control will use when drawing highlighted items. An item is highlighted
		/// if it has the TBSTATE_MARKED style and is contained in a toolbar that has the TBSTYLE_FLAT style.
		/// </para>
		/// </summary>
		public COLORREF clrBtnHighlight;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>
		/// <c>COLORREF</c> that represents the background color that the control will use when drawing text on hot tracked items. This
		/// member is ignored if TBCDRF_HILITEHOTTRACK is not returned from the NM_CUSTOMDRAW notification code.
		/// </para>
		/// </summary>
		public COLORREF clrHighlightHotTrack;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>
		/// RECT structure that, on entry, contains the rectangle of the item's text. The <c>right</c> and <c>bottom</c> members of this
		/// structure can be modified to change the width and height, respectively, of the text rectangle of the item.
		/// </para>
		/// </summary>
		public RECT rcText;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Background mode that the control will use when drawing the text of a nonhighlighted item. This can be either the TRANSPARENT or
		/// OPAQUE value.
		/// </para>
		/// </summary>
		public BackgroundMode nStringBkMode;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Background mode that the control will use when drawing the text of a highlighted item. This can be either the TRANSPARENT or
		/// OPAQUE value.
		/// </para>
		/// </summary>
		public BackgroundMode nHLStringBkMode;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Version 6.0 Specifies the distance between the toolbar button image and the text, in logical pixels, for toolbars that have
		/// TBSTYLE_LIST style set.
		/// </para>
		/// <para>
		/// Note that Comctl32.dll version 6 is not redistributable but it is included in Windows or later. To use Comctl32.dll version 6,
		/// specify it in a manifest. For more information on manifests, see Enabling Visual Styles.
		/// </para>
		/// </summary>
		public int iListGap;
	}

	/// <summary>
	/// Contains and receives display information for a toolbar item. This structure is used with the TBN_GETDISPINFO notification code.
	/// </summary>
	// typedef struct { NMHDR hdr; DWORD dwMask; int idCommand; DWORD_PTR lParam; int iImage; StrPtrAuto pszText; int cchText;} NMTBDISPINFO,
	// *LPNMTBDISPINFO; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760452(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760452")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NMTBDISPINFO : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>
		/// Set of flags that indicate which members of this structure are being requested. This can be one or more of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TBNF_IMAGE</term>
		/// <term>The item's image index is being requested. The image index must be placed in the iImage member.</term>
		/// </item>
		/// <item>
		/// <term>TBNF_TEXT</term>
		/// <term>Not currently implemented.</term>
		/// </item>
		/// <item>
		/// <term>TBNF_DI_SETITEM</term>
		/// <term>
		/// Set this flag when processing TBN_GETDISPINFO; the toolbar control will retain the supplied information and not request it again.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public TBNF dwMask;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Command identifier of the item for which display information is being requested. This member is filled in by the control before
		/// it sends the notification code.
		/// </para>
		/// </summary>
		public int idCommand;

		/// <summary>
		/// <para>Type: <c><c>DWORD_PTR</c></c></para>
		/// <para>
		/// Application-defined value associated with the item for which display information is being requested. This member is filled in by
		/// the control before sending the notification code.
		/// </para>
		/// </summary>
		public IntPtr lParam;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Image index for the item.</para>
		/// </summary>
		public int iImage;

		/// <summary>
		/// <para>Type: <c><c>StrPtrAuto</c></c></para>
		/// <para>Pointer to a character buffer that receives the item's text.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszText;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Size of the <c>pszText</c> buffer, in characters.</para>
		/// </summary>
		public int cchText;
	}

	/// <summary>
	/// A structure that provides an accelerator and that receives a value specifying whether multiple toolbars respond to the same character.
	/// </summary>
	/// <seealso cref="INotificationInfo"/>
	[PInvokeData("Commctrl.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct NMTBDUPACCELERATOR : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>The accelerator.</summary>
		public char ch;

		/// <summary>TRUE if multiple toolbars respond to the accelerator.</summary>
		public BOOL fDup;
	}

	/// <summary>
	/// Contains and receives infotip information for a toolbar item. This structure is used with the TBN_GETINFOTIP notification code.
	/// </summary>
	// typedef struct tagNMTBGETINFOTIP { NMHDR hdr; StrPtrAuto pszText; int cchTextMax; int iItem; LPARAM lParam;} NMTBGETINFOTIP,
	// *LPNMTBGETINFOTIP; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760454(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760454")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NMTBGETINFOTIP : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c><c>StrPtrAuto</c></c></para>
		/// <para>Address of a character buffer that receives the infotip text.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszText;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Size of the buffer, in characters, at <c>pszText</c>. In most cases, the buffer will be INFOTIPSIZE characters in size, but you
		/// should always make sure that your application does not copy more than <c>cchTextMax</c> characters to the buffer at <c>pszText</c>.
		/// </para>
		/// </summary>
		public int cchTextMax;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The command identifier of the item for which infotip information is being requested. This member is filled in by the control
		/// before sending the notification code.
		/// </para>
		/// </summary>
		public int iItem;

		/// <summary>
		/// <para>Type: <c><c>LPARAM</c></c></para>
		/// <para>
		/// The application-defined value associated with the item for which infotip information is being requested. This member is filled in
		/// by the control before sending the notification code.
		/// </para>
		/// </summary>
		public IntPtr lParam;
	}

	/// <summary>Contains information used with the TBN_HOTITEMCHANGE notification code.</summary>
	// typedef struct tagNMTBHOTITEM { NMHDR hdr; int idOld; int idNew; DWORD dwFlags;} NMTBHOTITEM, *LPNMTBHOTITEM; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760456(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760456")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMTBHOTITEM : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Command identifier of the previously highlighted item.</para>
		/// </summary>
		public int idOld;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Command identifier of the item about to be highlighted.</para>
		/// </summary>
		public int idNew;

		/// <summary>
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>Flags that indicate why the hot item has changed. This can be one or more of the following values:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HICF_ACCELERATOR</term>
		/// <term>The change in the hot item was caused by a shortcut key.</term>
		/// </item>
		/// <item>
		/// <term>HICF_ARROWKEYS</term>
		/// <term>The change in the hot item was caused by an arrow key.</term>
		/// </item>
		/// <item>
		/// <term>HICF_DUPACCEL</term>
		/// <term>Modifies HICF_ACCELERATOR. If this flag is set, more than one item has the same shortcut key character.</term>
		/// </item>
		/// <item>
		/// <term>HICF_ENTERING</term>
		/// <term>Modifies the other reason flags. If this flag is set, there is no previous hot item and idOld does not contain valid information.</term>
		/// </item>
		/// <item>
		/// <term>HICF_LEAVING</term>
		/// <term>Modifies the other reason flags. If this flag is set, there is no new hot item and idNew does not contain valid information.</term>
		/// </item>
		/// <item>
		/// <term>HICF_LMOUSE</term>
		/// <term>The change in the hot item resulted from a left-click mouse event.</term>
		/// </item>
		/// <item>
		/// <term>HICF_MOUSE</term>
		/// <term>The change in the hot item resulted from a mouse event.</term>
		/// </item>
		/// <item>
		/// <term>HICF_OTHER</term>
		/// <term>
		/// The change in the hot item resulted from an event that could not be determined. This will most often be due to a change in focus
		/// or the TB_SETHOTITEM message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HICF_RESELECT</term>
		/// <term>The change in the hot item resulted from the user entering the shortcut key for an item that was already hot.</term>
		/// </item>
		/// <item>
		/// <term>HICF_TOGGLEDROPDOWN</term>
		/// <term>Version 5.80. Causes the button to switch states.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public HICF dwFlags;           // HICF_*
	}

	/// <summary>
	/// Allows applications to extract the information that was placed in <c>NMTBSAVE</c> when the toolbar state was saved. This structure is
	/// passed to applications when they receive a TBN_RESTORE notification code.
	/// </summary>
	// typedef struct tagNMTBRESTORE { NMHDR nmhdr; DWORD *pData; DWORD *pCurrent; UINT cbData; int iItem; int cButtons; int
	// cbBytesPerRecord; TBBUTTON tbButton;} NMTBRESTORE, *LPNMTBRESTORE; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760458(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760458")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMTBRESTORE : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c><c>DWORD</c>*</c></para>
		/// <para>
		/// Pointer to the data stream with the stored save information. It contains Shell-defined blocks of information for each button,
		/// alternating with application-defined blocks. Applications may also place a block of global data at the start of <c>pData</c>. The
		/// format and length of the application-defined blocks are determined by the application.
		/// </para>
		/// </summary>
		public IntPtr pData;

		/// <summary>
		/// <para>Type: <c><c>DWORD</c>*</c></para>
		/// <para>
		/// Pointer to the current block of application-defined data. After extracting the data, the application must advance <c>pCurrent</c>
		/// to the end of the block, so it is pointing to the next block of Shell-defined data.
		/// </para>
		/// </summary>
		public IntPtr pCurrent;

		/// <summary>
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>Size of <c>pData</c>.</para>
		/// </summary>
		public uint cbData;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Value of -1 indicates that the restore is starting, and <c>pCurrent</c> will point to the start of the data stream. Otherwise, it
		/// is the zero-based button index, and <c>pCurrent</c> will point to the current button's data.
		/// </para>
		/// </summary>
		public int iItem;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Estimate of the number of buttons. Because the estimate is based on the size of the data stream, it might be incorrect. The
		/// client should update it as appropriate.
		/// </para>
		/// </summary>
		public int cButtons;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Number of bytes needed to hold the data for each button. When the restore starts, <c>cbBytesPerRecord</c> will be set to the size
		/// of the Shell-defined data structure. You need to increment it by the size of the structure that holds the application-defined data.
		/// </para>
		/// </summary>
		public int cbBytesPerRecord;

		/// <summary>
		/// <para>Type: <c><c>TBBUTTON</c></c></para>
		/// <para>
		/// <c>TBBUTTON</c> structure that contains information about the button currently being restored. Applications must modify this
		/// structure as necessary before returning.
		/// </para>
		/// </summary>
		public TBBUTTON tbButton;
	}

	/// <summary>
	/// This structure is passed to applications when they receive a TBN_SAVE notification code. It contains information about the button
	/// currently being saved. Applications can modify the values of the members to save additional information.
	/// </summary>
	// typedef struct tagNMTBSAVE { NMHDR hdr; DWORD *pData; DWORD *pCurrent; UINT cbData; int iItem; int cButtons; TBBUTTON tbButton;} NMTBSAVE,
	// *LPNMTBSAVE; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760471(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760471")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMTBSAVE : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para>An <c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c><c>DWORD</c>*</c></para>
		/// <para>
		/// A pointer to the data stream used to store the save information. When complete, it will contain blocks of Shell-defined
		/// information for each button, alternating with blocks defined by the application. Applications may also choose to place a block of
		/// global data at the start of <c>pData</c>. The format and length of the application-defined blocks are determined by the
		/// application. When the save starts, the Shell will pass the amount of memory it needs in <c>cbData</c>, but no memory will be
		/// allocated. You must allocate enough memory for <c>pData</c> to hold your data, plus the Shell's.
		/// </para>
		/// </summary>
		public IntPtr pData;

		/// <summary>
		/// <para>Type: <c><c>DWORD</c>*</c></para>
		/// <para>
		/// A pointer to the start of the unused portion of the data stream. You should load your data here, and then advance <c>pCurrent</c>
		/// to the start of the remaining unused portion. The Shell will then load the information for the next button, advance
		/// <c>pCurrent</c>, and so on.
		/// </para>
		/// </summary>
		public IntPtr pCurrent;

		/// <summary>
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>
		/// The size of the data stream. When the save starts, <c>cbData</c> will be set to the amount of data needed by the Shell. You
		/// should change it to the total amount allocated.
		/// </para>
		/// </summary>
		public uint cbData;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// This parameter is usually the zero-based index of the button currently being saved. It is set to -1 to indicate that a save is starting.
		/// </para>
		/// </summary>
		public int iItem;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// An estimate of the number of buttons. Because it is based on the size of the data stream, it may be incorrect. The client should
		/// update it as appropriate.
		/// </para>
		/// </summary>
		public int cButtons;

		/// <summary>
		/// <para>Type: <c><c>TBBUTTON</c></c></para>
		/// <para>A <c>TBBUTTON</c> structure that contains information about the button currently being saved.</para>
		/// </summary>
		public TBBUTTON tbButton;
	}

	/// <summary>Structure from <c>TBN_WRAPACCELERATOR</c>.</summary>
	[PInvokeData("Commctrl.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct NMTBWRAPACCELERATOR : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>The accelerator.</summary>
		public char ch;

		/// <summary>The index of the corresponding button.</summary>
		public int iButton;
	}

	/// <summary>
	/// Notifies an application with two or more toolbars that the hot item is about to change. This notification code is sent in the form of
	/// a <c>WM_NOTIFY</c> message.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/controls/tbn-wraphotitem
	[PInvokeData("Commctrl.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMTBWRAPHOTITEM : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>The old hot item.</summary>
		public int iStart;

		/// <summary>Whether the new hot item is before <c>iStart</c> (iDir = -1) or after <c>iStart</c> (iDir = 1).</summary>
		public int iDir;

		/// <summary>A reason why the hot item is changing.</summary>
		public HICF nReason;
	}

	/// <summary>Contains information used to process toolbar notification codes. This structure supersedes the <c>TBNOTIFY</c> structure.</summary>
	// typedef struct tagNMTOOLBAR { NMHDR hdr; int iItem; TBBUTTON tbButton; int cchText; StrPtrAuto pszText; RECT rcButton;} NMTOOLBAR,
	// *LPNMTOOLBAR; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760473(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760473")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NMTOOLBAR : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Command identifier of the button associated with the notification code.</para>
		/// </summary>
		public int iItem;

		/// <summary>
		/// <para>Type: <c><c>TBBUTTON</c></c></para>
		/// <para>
		/// <c>TBBUTTON</c> structure that contains information about the toolbar button associated with the notification code. This member
		/// only contains valid information with the TBN_QUERYINSERT and TBN_QUERYDELETE notification codes.
		/// </para>
		/// </summary>
		public TBBUTTON tbButton;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Count of characters in the button text.</para>
		/// </summary>
		public int cchText;

		/// <summary>
		/// <para>Type: <c><c>StrPtrAuto</c></c></para>
		/// <para>Address of a character buffer that contains the button text.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszText;

		/// <summary>
		/// <para>Type: <c><c>RECT</c></c></para>
		/// <para>Version 5.80. A <c>RECT</c> structure that defines the area covered by the button.</para>
		/// </summary>
		public RECT rcButton;
	}

	/// <summary>Adds a bitmap that contains button images to a toolbar.</summary>
	// typedef struct { HINSTANCE hInst; UINT_PTR nID;} TBADDBITMAP, *LPTBADDBITMAP; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760475(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760475")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TBADDBITMAP
	{
		/// <summary>
		/// <para>Type: <c><c>HINSTANCE</c></c></para>
		/// <para>
		/// Handle to the module instance with the executable file that contains a bitmap resource. To use bitmap handles instead of resource
		/// IDs, set this member to <c>NULL</c>.
		/// </para>
		/// <para>
		/// You can add the system-defined button bitmaps to the list by specifying HINST_COMMCTRL as the <c>hInst</c> member and one of the
		/// following values as the <c>nID</c> member.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IDB_STD_LARGE_COLOR</term>
		/// <term>Large, color standard bitmaps.</term>
		/// </item>
		/// <item>
		/// <term>IDB_STD_SMALL_COLOR</term>
		/// <term>Small, color standard bitmaps.</term>
		/// </item>
		/// <item>
		/// <term>IDB_VIEW_LARGE_COLOR</term>
		/// <term>Small large, color view bitmaps.</term>
		/// </item>
		/// <item>
		/// <term>IDB_VIEW_SMALL_COLOR</term>
		/// <term>Small, color view bitmaps.</term>
		/// </item>
		/// <item>
		/// <term>IDB_HIST_NORMAL</term>
		/// <term>Windows Explorer travel buttons and favorites bitmaps in normal state.</term>
		/// </item>
		/// <item>
		/// <term>IDB_HIST_HOT</term>
		/// <term>Windows Explorer travel buttons and favorites bitmaps in hot state.</term>
		/// </item>
		/// <item>
		/// <term>IDB_HIST_DISABLED</term>
		/// <term>Windows Explorer travel buttons and favorites bitmaps in disabled state.</term>
		/// </item>
		/// <item>
		/// <term>IDB_HIST_PRESSED</term>
		/// <term>Windows Explorer travel buttons and favorites bitmaps in pressed state.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public HINSTANCE hInst;

		/// <summary>
		/// <para>Type: <c><c>UINT_PTR</c></c></para>
		/// <para>
		/// If <c>hInst</c> is <c>NULL</c>, set this member to the bitmap handle of the bitmap with the button images. Otherwise, set it to
		/// the resource identifier of the bitmap with the button images.
		/// </para>
		/// </summary>
		public IntPtr nID;
	}

	/// <summary>Contains information about a button in a toolbar.</summary>
	// typedef struct { int iBitmap; int idCommand; BYTE fsState; BYTE fsStyle;#ifdef _WIN64 BYTE bReserved[6];#else #if defined(_WIN32) BYTE
	// bReserved[2];#endif #endif DWORD_PTR dwData; INT_PTR iString;} TBBUTTON, *PTBBUTTON, *LPTBBUTTON; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760476(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760476")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TBBUTTON
	{
		/// <summary>
		/// Zero-based index of the button image. Set this member to I_IMAGECALLBACK, and the toolbar will send the TBN_GETDISPINFO
		/// notification code to retrieve the image index when it is needed.
		/// <para>
		/// Version 5.81. Set this member to I_IMAGENONE to indicate that the button does not have an image.The button layout will not
		/// include any space for a bitmap, only text.
		/// </para>
		/// <para>
		/// If the button is a separator, that is, if fsStyle is set to BTNS_SEP, iBitmap determines the width of the separator, in
		/// pixels.For information on selecting button images from image lists, see TB_SETIMAGELIST message.
		/// </para>
		/// </summary>
		public int iBitmap;

		/// <summary>
		/// Command identifier associated with the button. This identifier is used in a WM_COMMAND message when the button is chosen.
		/// </summary>
		public int idCommand;

		// Funky holder to make preprocessor directives work
		private TBBUTTON_U union;

		/// <summary>Button state flags.</summary>
		public TBSTATE fsState { get => union.fsState; set => union.fsState = value; }

		/// <summary>Button style.</summary>
		public ToolbarStyle fsStyle { get => union.fsStyle; set => union.fsStyle = value; }

		/// <summary>Application-defined value.</summary>
		public IntPtr dwData;

		/// <summary>Zero-based index of the button string, or a pointer to a string buffer that contains text for the button.</summary>
		public IntPtr iString;

		[StructLayout(LayoutKind.Explicit, Pack = 1)]
		private struct TBBUTTON_U
		{
			[FieldOffset(0)] private readonly IntPtr bReserved;
			[FieldOffset(0)] public TBSTATE fsState;
			[FieldOffset(1)] public ToolbarStyle fsStyle;
		}
	}

	/// <summary>Contains or receives information for a specific button in a toolbar.</summary>
	// typedef struct { UINT cbSize; DWORD dwMask; int idCommand; int iImage; BYTE fsState; BYTE fsStyle; WORD cx; DWORD_PTR lParam; StrPtrAuto
	// pszText; int cchText;} TBBUTTONINFO, *LPTBBUTTONINFO; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760478(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760478")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TBBUTTONINFO
	{
		/// <summary>
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>Size of the structure, in bytes. This member must be filled in prior to sending the associated message.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>
		/// Set of flags that indicate which members contain valid information. This member must be filled in prior to sending the associated
		/// message. This can be one or more of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TBIF_BYINDEX</term>
		/// <term>Version 5.80. The wParam sent with a TB_GETBUTTONINFO or TB_SETBUTTONINFO message is an index, not an identifier.</term>
		/// </item>
		/// <item>
		/// <term>TBIF_COMMAND</term>
		/// <term>The idCommand member contains valid information or is being requested.</term>
		/// </item>
		/// <item>
		/// <term>TBIF_IMAGE</term>
		/// <term>The iImage member contains valid information or is being requested.</term>
		/// </item>
		/// <item>
		/// <term>TBIF_LPARAM</term>
		/// <term>The lParam member contains valid information or is being requested.</term>
		/// </item>
		/// <item>
		/// <term>TBIF_SIZE</term>
		/// <term>The cx member contains valid information or is being requested.</term>
		/// </item>
		/// <item>
		/// <term>TBIF_STATE</term>
		/// <term>The fsState member contains valid information or is being requested.</term>
		/// </item>
		/// <item>
		/// <term>TBIF_STYLE</term>
		/// <term>The fsStyle member contains valid information or is being requested.</term>
		/// </item>
		/// <item>
		/// <term>TBIF_TEXT</term>
		/// <term>The pszText member contains valid information or is being requested.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public TBIF dwMask;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Command identifier of the button.</para>
		/// </summary>
		public int idCommand;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Image index of the button. Set this member to I_IMAGECALLBACK, and the toolbar will send the TBN_GETDISPINFO notification code to
		/// retrieve the image index when it is needed.
		/// </para>
		/// <para>
		/// Version 5.81. Set this member to I_IMAGENONE to indicate that the button does not have an image. The button layout will not
		/// include any space for a bitmap, only text.
		/// </para>
		/// </summary>
		public int iImage;

		/// <summary>
		/// <para>Type: <c><c>BYTE</c></c></para>
		/// <para>State flags of the button. This can be one or more of the values listed in Toolbar Button States.</para>
		/// </summary>
		public TBSTATE fsState;

		/// <summary>
		/// <para>Type: <c><c>BYTE</c></c></para>
		/// <para>Style flags of the button. This can be one or more of the values listed in Toolbar Control and Button Styles.</para>
		/// </summary>
		public ToolbarStyle fsStyle { get => (ToolbarStyle)_fsStyle; set => _fsStyle = (byte)((ushort)value & 0x00FF); }

		private byte _fsStyle;

		/// <summary>
		/// <para>Type: <c><c>WORD</c></c></para>
		/// <para>Width of the button, in pixels.</para>
		/// </summary>
		public ushort cx;

		/// <summary>
		/// <para>Type: <c><c>DWORD_PTR</c></c></para>
		/// <para>Application-defined value associated with the button.</para>
		/// </summary>
		public IntPtr lParam;

		/// <summary>
		/// <para>Type: <c><c>StrPtrAuto</c></c></para>
		/// <para>Address of a character buffer that contains or receives the button text.</para>
		/// </summary>
		public IntPtr pszText;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Size of the buffer at <c>pszText</c>. If the button information is being set, this member is ignored.</para>
		/// </summary>
		public int cchText;
	}

	/// <summary>Contains information on the insertion mark in a toolbar control.</summary>
	// typedef struct { int iButton; DWORD dwFlags;} TBINSERTMARK, *LPTBINSERTMARK; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760480(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760480")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TBINSERTMARK
	{
		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Zero-based index of the insertion mark. If this member is -1, there is no insertion mark.</para>
		/// </summary>
		public int iButton;

		/// <summary>
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>Defines where the insertion mark is in relation to <c>iButton</c>. This can be one of the following values:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The insertion mark is to the left of the specified button.</term>
		/// </item>
		/// <item>
		/// <term>TBIMHT_AFTER</term>
		/// <term>The insertion mark is to the right of the specified button.</term>
		/// </item>
		/// <item>
		/// <term>TBIMHT_BACKGROUND</term>
		/// <term>The insertion mark is on the background of the toolbar. This flag is only used with the TB_INSERTMARKHITTEST message.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public TBIMHT dwFlags;
	}

	/// <summary>Defines the metrics of a toolbar that are used to shrink or expand toolbar items.</summary>
	// typedef struct { UINT cbSize; DWORD dwMask; int cxPad; int cyPad; int cxBarPad; int cyBarPad; int cxButtonSpacing; int
	// cyButtonSpacing;} TBMETRICS,
	// *LPTBMETRICS; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760482(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760482")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TBMETRICS
	{
		/// <summary>
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>Size of the <c>TBMETRICS</c> structure.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>Mask that determines the metric to retrieve. It can be any combination of the following:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TBMF_PAD</term>
		/// <term>Retrieve the cxPad and cyPad values.</term>
		/// </item>
		/// <item>
		/// <term>TBMF_BARPAD</term>
		/// <term>Retrieve the cxBarPad and cyBarPad values.</term>
		/// </item>
		/// <item>
		/// <term>TBMF_BUTTONSPACING</term>
		/// <term>Retrieve the cxButtonSpacing and cyButtonSpacing values.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public TBMF dwMask;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Width of the padding inside the toolbar buttons, between the content and the edge of the button.</para>
		/// </summary>
		public int cxPad;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Height of the padding inside the toolbar buttons, between the content and the edge of the button.</para>
		/// </summary>
		public int cyPad;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Width of the toolbar. Not used.</para>
		/// </summary>
		public int cxBarPad;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Height of the toolbar. Not used.</para>
		/// </summary>
		public int cyBarPad;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Width of the space between toolbar buttons.</para>
		/// </summary>
		public int cxButtonSpacing;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Height of the space between toolbar buttons.</para>
		/// </summary>
		public int cyButtonSpacing;
	}

	/// <summary>Used with the <c>TB_REPLACEBITMAP</c> message to replace one toolbar bitmap with another.</summary>
	// typedef struct { HINSTANCE hInstOld; UINT_PTR nIDOld; HINSTANCE hInstNew; UINT_PTR nIDNew; int nButtons;} TBREPLACEBITMAP,
	// *LPTBREPLACEBITMAP; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760484(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760484")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TBREPLACEBITMAP
	{
		/// <summary>
		/// <para>Type: <c><c>HINSTANCE</c></c></para>
		/// <para>Module instance handle to the bitmap resource being replaced. Set this member to <c>NULL</c> to instead use a bitmap handle.</para>
		/// </summary>
		public HINSTANCE hInstOld;

		/// <summary>
		/// <para>Type: <c><c>UINT_PTR</c></c></para>
		/// <para>
		/// If <c>hInstOld</c> is <c>NULL</c>, set this member to the bitmap handle of the bitmap that is being replaced. Otherwise, set it
		/// to the resource identifier of the bitmap being replaced.
		/// </para>
		/// </summary>
		public IntPtr nIDOld;

		/// <summary>
		/// <para>Type: <c><c>HINSTANCE</c></c></para>
		/// <para>Module instance handle that contains the new bitmap resource. Set this member to <c>NULL</c> to instead use a bitmap handle.</para>
		/// </summary>
		public HINSTANCE hInstNew;

		/// <summary>
		/// <para>Type: <c><c>UINT_PTR</c></c></para>
		/// <para>
		/// If <c>hInstNew</c> is <c>NULL</c>, set this member to the bitmap handle of the bitmap with the new button images. Otherwise, set
		/// it to the resource identifier of the bitmap with the new button images.
		/// </para>
		/// </summary>
		public IntPtr nIDNew;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Number of button images contained in the new bitmap. The number of new images should be the same as the number of replaced images.
		/// </para>
		/// </summary>
		public int nButtons;
	}

	/// <summary>
	/// Specifies the location in the registry where the <c>TB_SAVERESTORE</c> message stores and retrieves information about the state of a toolbar.
	/// </summary>
	// typedef struct { HKEY hkr; LPCTSTR pszSubKey; LPCTSTR pszValueName;} TBSAVEPARAMS; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760486(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760486")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TBSAVEPARAMS
	{
		/// <summary>
		/// <para>Type: <c><c>HKEY</c></c></para>
		/// <para>Handle to the registry key.</para>
		/// </summary>
		public HKEY hkr;

		/// <summary>
		/// <para>Type: <c><c>LPCTSTR</c></c></para>
		/// <para>Subkey name.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszSubKey;

		/// <summary>
		/// <para>Type: <c><c>LPCTSTR</c></c></para>
		/// <para>Value name.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszValueName;
	}
}