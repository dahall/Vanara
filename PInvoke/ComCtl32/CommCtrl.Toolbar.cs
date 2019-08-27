using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>Window class name for the Toolbar control.</summary>
		public const string TOOLBARCLASSNAME = "ToolbarWindow32";

		private const int TBN_FIRST = -700;

		/// <summary>Options for CreateMappedBitmap.</summary>
		public enum CMB
		{
			/// <summary>No flags</summary>
			CMB_NONE = 0,

			/// <summary>Uses a bitmap as a mask.</summary>
			CMB_MASKED = 2
		}

		/// <summary>
		/// The value your application can return depends on the current drawing stage. The <c>dwDrawStage</c> member of the associated
		/// <c>NMCUSTOMDRAW</c> structure holds a value that specifies the drawing stage. You must return one of the following values.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760492")]
		public enum TBCDRF
		{
			/// <summary>Version 4.71. Do not draw button edges. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
			TBCDRF_NOEDGES = 0x00010000,

			/// <summary>
			/// Version 4.71. Use the clrHighlightHotTrack member of the NMTBCUSTOMDRAW structure to draw the background of hot-tracked
			/// items. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.
			/// </summary>
			TBCDRF_HILITEHOTTRACK = 0x00020000,

			/// <summary>Version 4.71. Do not offset the button when pressed. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
			TBCDRF_NOOFFSET = 0x00040000,

			/// <summary>Do not draw default highlight of items that have the TBSTATE_MARKED. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
			TBCDRF_NOMARK = 0x00080000,

			/// <summary>Version 4.71. Do not draw etched effect for disabled items. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
			TBCDRF_NOETCHEDEFFECT = 0x00100000,

			/// <summary>Version 5.00. Blend the button 50 percent with the background. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
			TBCDRF_BLENDICON = 0x00200000,

			/// <summary>Version 5.00. Do not draw button background. This occurs when dwDrawStage equals CDDS_ITEMPREPAINT.</summary>
			TBCDRF_NOBACKGROUND = 0x00400000,

			/// <summary>Version 6.00, Windows Vista only. Use custom draw colors to render text regardless of visual style.</summary>
			TBCDRF_USECDCOLORS = 0x00800000,
		}

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

		public enum ToolbarMessage
		{
			TB_ENABLEBUTTON = WindowMessage.WM_USER + 1,
			TB_CHECKBUTTON = WindowMessage.WM_USER + 2,
			TB_PRESSBUTTON = WindowMessage.WM_USER + 3,
			TB_HIDEBUTTON = WindowMessage.WM_USER + 4,
			TB_INDETERMINATE = WindowMessage.WM_USER + 5,
			TB_MARKBUTTON = WindowMessage.WM_USER + 6,
			TB_ISBUTTONENABLED = WindowMessage.WM_USER + 9,
			TB_ISBUTTONCHECKED = WindowMessage.WM_USER + 10,
			TB_ISBUTTONPRESSED = WindowMessage.WM_USER + 11,
			TB_ISBUTTONHIDDEN = WindowMessage.WM_USER + 12,
			TB_ISBUTTONINDETERMINATE = WindowMessage.WM_USER + 13,
			TB_ISBUTTONHIGHLIGHTED = WindowMessage.WM_USER + 14,
			TB_SETSTATE = WindowMessage.WM_USER + 17,
			TB_GETSTATE = WindowMessage.WM_USER + 18,
			TB_ADDBITMAP = WindowMessage.WM_USER + 19,
			TB_ADDBUTTONSA = WindowMessage.WM_USER + 20,
			TB_INSERTBUTTONA = WindowMessage.WM_USER + 21,
			TB_DELETEBUTTON = WindowMessage.WM_USER + 22,
			TB_GETBUTTON = WindowMessage.WM_USER + 23,
			TB_BUTTONCOUNT = WindowMessage.WM_USER + 24,
			TB_COMMANDTOINDEX = WindowMessage.WM_USER + 25,
			TB_SAVERESTOREA = WindowMessage.WM_USER + 26,
			TB_SAVERESTOREW = WindowMessage.WM_USER + 76,
			TB_CUSTOMIZE = WindowMessage.WM_USER + 27,
			TB_ADDSTRINGA = WindowMessage.WM_USER + 28,
			TB_ADDSTRINGW = WindowMessage.WM_USER + 77,
			TB_GETITEMRECT = WindowMessage.WM_USER + 29,
			TB_BUTTONSTRUCTSIZE = WindowMessage.WM_USER + 30,
			TB_SETBUTTONSIZE = WindowMessage.WM_USER + 31,
			TB_SETBITMAPSIZE = WindowMessage.WM_USER + 32,
			TB_AUTOSIZE = WindowMessage.WM_USER + 33,
			TB_GETTOOLTIPS = WindowMessage.WM_USER + 35,
			TB_SETTOOLTIPS = WindowMessage.WM_USER + 36,
			TB_SETPARENT = WindowMessage.WM_USER + 37,
			TB_SETROWS = WindowMessage.WM_USER + 39,
			TB_GETROWS = WindowMessage.WM_USER + 40,
			TB_GETBITMAPFLAGS = WindowMessage.WM_USER + 41,
			TB_SETCMDID = WindowMessage.WM_USER + 42,
			TB_CHANGEBITMAP = WindowMessage.WM_USER + 43,
			TB_GETBITMAP = WindowMessage.WM_USER + 44,
			TB_GETBUTTONTEXTA = WindowMessage.WM_USER + 45,
			TB_GETBUTTONTEXTW = WindowMessage.WM_USER + 75,
			TB_REPLACEBITMAP = WindowMessage.WM_USER + 46,
			TB_SETINDENT = WindowMessage.WM_USER + 47,
			TB_SETIMAGELIST = WindowMessage.WM_USER + 48,
			TB_GETIMAGELIST = WindowMessage.WM_USER + 49,
			TB_LOADIMAGES = WindowMessage.WM_USER + 50,
			TB_GETRECT = WindowMessage.WM_USER + 51,
			TB_SETHOTIMAGELIST = WindowMessage.WM_USER + 52,
			TB_GETHOTIMAGELIST = WindowMessage.WM_USER + 53,
			TB_SETDISABLEDIMAGELIST = WindowMessage.WM_USER + 54,
			TB_GETDISABLEDIMAGELIST = WindowMessage.WM_USER + 55,
			TB_SETSTYLE = WindowMessage.WM_USER + 56,
			TB_GETSTYLE = WindowMessage.WM_USER + 57,
			TB_GETBUTTONSIZE = WindowMessage.WM_USER + 58,
			TB_SETBUTTONWIDTH = WindowMessage.WM_USER + 59,
			TB_SETMAXTEXTROWS = WindowMessage.WM_USER + 60,
			TB_GETTEXTROWS = WindowMessage.WM_USER + 61,
			TB_GETOBJECT = WindowMessage.WM_USER + 62,
			TB_GETBUTTONINFOW = WindowMessage.WM_USER + 63,
			TB_SETBUTTONINFOW = WindowMessage.WM_USER + 64,
			TB_GETBUTTONINFOA = WindowMessage.WM_USER + 65,
			TB_SETBUTTONINFOA = WindowMessage.WM_USER + 66,
			TB_INSERTBUTTONW = WindowMessage.WM_USER + 67,
			TB_ADDBUTTONSW = WindowMessage.WM_USER + 68,
			TB_HITTEST = WindowMessage.WM_USER + 69,
			TB_SETDRAWTEXTFLAGS = WindowMessage.WM_USER + 70,
			TB_GETHOTITEM = WindowMessage.WM_USER + 71,
			TB_SETHOTITEM = WindowMessage.WM_USER + 72,
			TB_SETANCHORHIGHLIGHT = WindowMessage.WM_USER + 73,
			TB_GETANCHORHIGHLIGHT = WindowMessage.WM_USER + 74,
			TB_MAPACCELERATORA = WindowMessage.WM_USER + 78,
			TB_GETINSERTMARK = WindowMessage.WM_USER + 79,
			TB_SETINSERTMARK = WindowMessage.WM_USER + 80,
			TB_INSERTMARKHITTEST = WindowMessage.WM_USER + 81,
			TB_MOVEBUTTON = WindowMessage.WM_USER + 82,
			TB_GETMAXSIZE = WindowMessage.WM_USER + 83,
			TB_SETEXTENDEDSTYLE = WindowMessage.WM_USER + 84,
			TB_GETEXTENDEDSTYLE = WindowMessage.WM_USER + 85,
			TB_GETPADDING = WindowMessage.WM_USER + 86,
			TB_SETPADDING = WindowMessage.WM_USER + 87,
			TB_SETINSERTMARKCOLOR = WindowMessage.WM_USER + 88,
			TB_GETINSERTMARKCOLOR = WindowMessage.WM_USER + 89,
			TB_MAPACCELERATORW = WindowMessage.WM_USER + 90,
			TB_GETSTRINGW = WindowMessage.WM_USER + 91,
			TB_GETSTRINGA = WindowMessage.WM_USER + 92,
			TB_SETBOUNDINGSIZE = WindowMessage.WM_USER + 93,
			TB_SETHOTITEM2 = WindowMessage.WM_USER + 94,
			TB_HASACCELERATOR = WindowMessage.WM_USER + 95,
			TB_SETLISTGAP = WindowMessage.WM_USER + 96,
			TB_GETIMAGELISTCOUNT = WindowMessage.WM_USER + 98,
			TB_GETIDEALSIZE = WindowMessage.WM_USER + 99,
			TB_GETMETRICS = WindowMessage.WM_USER + 101,
			TB_SETMETRICS = WindowMessage.WM_USER + 102,
			TB_GETITEMDROPDOWNRECT = WindowMessage.WM_USER + 103,
			TB_SETPRESSEDIMAGELIST = WindowMessage.WM_USER + 104,
			TB_GETPRESSEDIMAGELIST = WindowMessage.WM_USER + 105,
		}

		public enum ToolbarNotification
		{
			TBN_GETBUTTONINFOA = TBN_FIRST - 0,
			TBN_BEGINDRAG = TBN_FIRST - 1,
			TBN_ENDDRAG = TBN_FIRST - 2,
			TBN_BEGINADJUST = TBN_FIRST - 3,
			TBN_ENDADJUST = TBN_FIRST - 4,
			TBN_RESET = TBN_FIRST - 5,
			TBN_QUERYINSERT = TBN_FIRST - 6,
			TBN_QUERYDELETE = TBN_FIRST - 7,
			TBN_TOOLBARCHANGE = TBN_FIRST - 8,
			TBN_CUSTHELP = TBN_FIRST - 9,
			TBN_DROPDOWN = TBN_FIRST - 10,
			TBN_GETOBJECT = TBN_FIRST - 12,
			TBN_HOTITEMCHANGE = TBN_FIRST - 13,
			TBN_DRAGOUT = TBN_FIRST - 14,
			TBN_DELETINGBUTTON = TBN_FIRST - 15,
			TBN_GETDISPINFOA = TBN_FIRST - 16,
			TBN_GETDISPINFOW = TBN_FIRST - 17,
			TBN_GETINFOTIPA = TBN_FIRST - 18,
			TBN_GETINFOTIPW = TBN_FIRST - 19,
			TBN_GETBUTTONINFOW = TBN_FIRST - 20,
			TBN_RESTORE = TBN_FIRST - 21,
			TBN_SAVE = TBN_FIRST - 22,
			TBN_INITCUSTOMIZE = TBN_FIRST - 23,
			TBN_WRAPHOTITEM = TBN_FIRST - 24,
			TBN_DUPACCELERATOR = TBN_FIRST - 25,
			TBN_WRAPACCELERATOR = TBN_FIRST - 26,
			TBN_DRAGOVER = TBN_FIRST - 27,
			TBN_MAPACCELERATOR = TBN_FIRST - 28,
		}

		[Flags]
		public enum ToolbarStyle : ushort
		{
			/// <summary>
			/// Allows users to change a toolbar button's position by dragging it while holding down the ALT key. If this style is not
			/// specified, the user must hold down the SHIFT key while dragging a button. Note that the CCS_ADJUSTABLE style must be
			/// specified to enable toolbar buttons to be dragged.
			/// </summary>
			TBSTYLE_ALTDRAG = 0x0400,

			/// <summary>Equivalent to BTNS_AUTOSIZE. Use TBSTYLE_AUTOSIZE for version 4.72 and earlier.</summary>
			TBSTYLE_AUTOSIZE = 0x0010,

			/// <summary>Equivalent to BTNS_BUTTON. Use TBSTYLE_BUTTON for version 4.72 and earlier.</summary>
			TBSTYLE_BUTTON = 0x0000,

			/// <summary>Equivalent to BTNS_CHECK. Use TBSTYLE_CHECK for version 4.72 and earlier.</summary>
			TBSTYLE_CHECK = 0x0002,

			/// <summary>Equivalent to BTNS_CHECKGROUP. Use TBSTYLE_CHECKGROUP for version 4.72 and earlier.</summary>
			TBSTYLE_CHECKGROUP = (TBSTYLE_GROUP | TBSTYLE_CHECK),

			/// <summary>Version 4.70. Generates NM_CUSTOMDRAW notification codes when the toolbar processes WM_ERASEBKGND messages.</summary>
			TBSTYLE_CUSTOMERASE = 0x2000,

			/// <summary>Equivalent to BTNS_DROPDOWN. Use TBSTYLE_DROPDOWN for version 4.72 and earlier.</summary>
			TBSTYLE_DROPDOWN = 0x0008,

			/// <summary>
			/// Version 4.70. Creates a flat toolbar. In a flat toolbar, both the toolbar and the buttons are transparent and hot-tracking is
			/// enabled. Button text appears under button bitmaps. To prevent repainting problems, this style should be set before the
			/// toolbar control becomes visible.
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
			/// Version 4.71. Creates a transparent toolbar. In a transparent toolbar, the toolbar is transparent but the buttons are not.
			/// Button text appears under button bitmaps. To prevent repainting problems, this style should be set before the toolbar control
			/// becomes visible.
			/// </summary>
			TBSTYLE_TRANSPARENT = 0x8000,

			/// <summary>
			/// Creates a toolbar that can have multiple lines of buttons. Toolbar buttons can "wrap" to the next line when the toolbar
			/// becomes too narrow to include all buttons on the same line. When the toolbar is wrapped, the break will occur on either the
			/// rightmost separator or the rightmost button if there are no separators on the bar. This style must be set to display a
			/// vertical toolbar control when the toolbar is part of a vertical rebar control. This style cannot be combined with CCS_VERT.
			/// </summary>
			TBSTYLE_WRAPABLE = 0x0200,
		}

		/// <summary>This section lists the extended styles supported by toolbar controls.</summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb760430(v=vs.85).aspx
		[PInvokeData("CommCtrl.h", MSDNShortId = "bb760430")]
		[Flags]
		public enum ToolbarStyleEx
		{
			/// <summary>
			/// Version 4.71. This style allows buttons to have a separate dropdown arrow. Buttons that have the BTNS_DROPDOWN style will be
			/// drawn with a dropdown arrow in a separate section, to the right of the button. If the arrow is clicked, only the arrow
			/// portion of the button will depress, and the toolbar control will send a TBN_DROPDOWN notification code to prompt the
			/// application to display the dropdown menu. If the main part of the button is clicked, the toolbar control sends a WM_COMMAND
			/// message with the button's ID. The application normally responds by launching the first command on the menu. There are many
			/// situations where you may want to have only some of the dropdown buttons on a toolbar with separated arrows. To do so, set the
			/// TBSTYLE_EX_DRAWDDARROWS extended style. Give those buttons that will not have separated arrows the BTNS_WHOLEDROPDOWN style.
			/// Buttons with this style will have an arrow displayed next to the image. However, the arrow will not be separate and when any
			/// part of the button is clicked, the toolbar control will send a TBN_DROPDOWN notification code. To prevent repainting
			/// problems, this style should be set before the toolbar control becomes visible.
			/// </summary>
			TBSTYLE_EX_DRAWDDARROWS = 0x00000001,

			/// <summary>
			/// Version 5.81. This style allows you to set text for all buttons, but only display it for those buttons with the BTNS_SHOWTEXT
			/// button style. The TBSTYLE_LIST style must also be set. Normally, when a button does not display text, your application must
			/// handle TBN_GETINFOTIP or TTN_GETDISPINFO to display a tooltip. With the TBSTYLE_EX_MIXEDBUTTONS extended style, text that is
			/// set but not displayed on a button will automatically be used as the button's tooltip text. Your application only needs to
			/// handle TBN_GETINFOTIP or or TTN_GETDISPINFO if it needs more flexibility in specifying the tooltip text.
			/// </summary>
			TBSTYLE_EX_MIXEDBUTTONS = 0x00000008,

			/// <summary>
			/// Version 5.81. This style hides partially clipped buttons. The most common use of this style is for toolbars that are part of
			/// a rebar control. If an adjacent band covers part of a button, the button will not be displayed. However, if the rebar band
			/// has the RBBS_USECHEVRON style, the button will be displayed on the chevron's dropdown menu.
			/// </summary>
			TBSTYLE_EX_HIDECLIPPEDBUTTONS = 0x00000010,

			/// <summary>
			/// Version 5.82. Intended for internal use; not recommended for use in applications. This style gives the toolbar a vertical
			/// orientation and organizes the toolbar buttons into columns. The buttons flow down vertically until a button has exceeded the
			/// bounding height of the toolbar (see TB_SETBOUNDINGSIZE), and then a new column is created. The toolbar flows the buttons in
			/// this manner until all buttons are positioned. To use this style, the TBSTYLE_EX_VERTICAL style must also be set.
			/// </summary>
			TBSTYLE_EX_MULTICOLUMN = 0x00000002,

			/// <summary>
			/// Version 5.82. Intended for internal use; not recommended for use in applications. This style gives the toolbar a vertical
			/// orientation. Toolbar buttons flow from top to bottom instead of horizontally.
			/// </summary>
			TBSTYLE_EX_VERTICAL = 0x00000004,

			/// <summary>
			/// Version 6. This style requires the toolbar to be double buffered. Double buffering is a mechanism that detects when the
			/// toolbar has changed.
			/// </summary>
			TBSTYLE_EX_DOUBLEBUFFER = 0x00000080,
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
		/// <para>
		/// Returns the handle to the bitmap if successful, or <c>NULL</c> otherwise. To retrieve extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// HBITMAP CreateMappedBitmap( HINSTANCE hInstance, INT_PTR idBitmap, UINT wFlags, _In_ LPCOLORMAP lpColorMap, int iNumMaps); https://msdn.microsoft.com/en-us/library/windows/desktop/bb787467(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb787467")]
		public static extern IntPtr CreateMappedBitmap(HINSTANCE hInstance, SafeResourceId idBitmap, CMB wFlags, in COLORMAP lpColorMap, int iNumMaps);

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

		/// <summary>
		/// Contains and receives display information for a toolbar item. This structure is used with the TBN_GETDISPINFO notification code.
		/// </summary>
		// typedef struct { NMHDR hdr; DWORD dwMask; int idCommand; DWORD_PTR lParam; int iImage; LPTSTR pszText; int cchText;} NMTBDISPINFO,
		// *LPNMTBDISPINFO; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760452(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760452")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NMTBDISPINFO
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
			public uint dwMask;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// Command identifier of the item for which display information is being requested. This member is filled in by the control
			/// before it sends the notification code.
			/// </para>
			/// </summary>
			public int idCommand;

			/// <summary>
			/// <para>Type: <c><c>DWORD_PTR</c></c></para>
			/// <para>
			/// Application-defined value associated with the item for which display information is being requested. This member is filled in
			/// by the control before sending the notification code.
			/// </para>
			/// </summary>
			public IntPtr lParam;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Image index for the item.</para>
			/// </summary>
			public int iImage;

			/// <summary>
			/// <para>Type: <c><c>LPTSTR</c></c></para>
			/// <para>Pointer to a character buffer that receives the item's text.</para>
			/// </summary>
			public string pszText;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Size of the <c>pszText</c> buffer, in characters.</para>
			/// </summary>
			public int cchText;
		}

		/// <summary>
		/// Contains and receives infotip information for a toolbar item. This structure is used with the TBN_GETINFOTIP notification code.
		/// </summary>
		// typedef struct tagNMTBGETINFOTIP { NMHDR hdr; LPTSTR pszText; int cchTextMax; int iItem; LPARAM lParam;} NMTBGETINFOTIP,
		// *LPNMTBGETINFOTIP; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760454(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760454")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NMTBGETINFOTIP
		{
			/// <summary>
			/// <para>Type: <c><c>NMHDR</c></c></para>
			/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
			/// </summary>
			public NMHDR hdr;

			/// <summary>
			/// <para>Type: <c><c>LPTSTR</c></c></para>
			/// <para>Address of a character buffer that receives the infotip text.</para>
			/// </summary>
			public string pszText;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// Size of the buffer, in characters, at <c>pszText</c>. In most cases, the buffer will be INFOTIPSIZE characters in size, but
			/// you should always make sure that your application does not copy more than <c>cchTextMax</c> characters to the buffer at <c>pszText</c>.
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
			/// The application-defined value associated with the item for which infotip information is being requested. This member is
			/// filled in by the control before sending the notification code.
			/// </para>
			/// </summary>
			public IntPtr lParam;
		}

		/// <summary>Contains information used with the TBN_HOTITEMCHANGE notification code.</summary>
		// typedef struct tagNMTBHOTITEM { NMHDR hdr; int idOld; int idNew; DWORD dwFlags;} NMTBHOTITEM, *LPNMTBHOTITEM; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760456(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760456")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMTBHOTITEM
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
			/// <term>
			/// Modifies the other reason flags. If this flag is set, there is no previous hot item and idOld does not contain valid information.
			/// </term>
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
			/// The change in the hot item resulted from an event that could not be determined. This will most often be due to a change in
			/// focus or the TB_SETHOTITEM message.
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
			public uint dwFlags;           // HICF_*
		}

		/// <summary>
		/// Allows applications to extract the information that was placed in <c>NMTBSAVE</c> when the toolbar state was saved. This
		/// structure is passed to applications when they receive a TBN_RESTORE notification code.
		/// </summary>
		// typedef struct tagNMTBRESTORE { NMHDR nmhdr; DWORD *pData; DWORD *pCurrent; UINT cbData; int iItem; int cButtons; int
		// cbBytesPerRecord; TBBUTTON tbButton;} NMTBRESTORE, *LPNMTBRESTORE; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760458(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760458")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMTBRESTORE
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
			/// alternating with application-defined blocks. Applications may also place a block of global data at the start of <c>pData</c>.
			/// The format and length of the application-defined blocks are determined by the application.
			/// </para>
			/// </summary>
			public IntPtr pData;

			/// <summary>
			/// <para>Type: <c><c>DWORD</c>*</c></para>
			/// <para>
			/// Pointer to the current block of application-defined data. After extracting the data, the application must advance
			/// <c>pCurrent</c> to the end of the block, so it is pointing to the next block of Shell-defined data.
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
			/// Value of -1 indicates that the restore is starting, and <c>pCurrent</c> will point to the start of the data stream.
			/// Otherwise, it is the zero-based button index, and <c>pCurrent</c> will point to the current button's data.
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
			/// Number of bytes needed to hold the data for each button. When the restore starts, <c>cbBytesPerRecord</c> will be set to the
			/// size of the Shell-defined data structure. You need to increment it by the size of the structure that holds the
			/// application-defined data.
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
		public struct NMTBSAVE
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
			/// information for each button, alternating with blocks defined by the application. Applications may also choose to place a
			/// block of global data at the start of <c>pData</c>. The format and length of the application-defined blocks are determined by
			/// the application. When the save starts, the Shell will pass the amount of memory it needs in <c>cbData</c>, but no memory will
			/// be allocated. You must allocate enough memory for <c>pData</c> to hold your data, plus the Shell's.
			/// </para>
			/// </summary>
			public IntPtr pData;

			/// <summary>
			/// <para>Type: <c><c>DWORD</c>*</c></para>
			/// <para>
			/// A pointer to the start of the unused portion of the data stream. You should load your data here, and then advance
			/// <c>pCurrent</c> to the start of the remaining unused portion. The Shell will then load the information for the next button,
			/// advance <c>pCurrent</c>, and so on.
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
			/// This parameter is usually the zero-based index of the button currently being saved. It is set to -1 to indicate that a save
			/// is starting.
			/// </para>
			/// </summary>
			public int iItem;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// An estimate of the number of buttons. Because it is based on the size of the data stream, it may be incorrect. The client
			/// should update it as appropriate.
			/// </para>
			/// </summary>
			public int cButtons;

			/// <summary>
			/// <para>Type: <c><c>TBBUTTON</c></c></para>
			/// <para>A <c>TBBUTTON</c> structure that contains information about the button currently being saved.</para>
			/// </summary>
			public TBBUTTON tbButton;
		}

		/// <summary>Contains information used to process toolbar notification codes. This structure supersedes the <c>TBNOTIFY</c> structure.</summary>
		// typedef struct tagNMTOOLBAR { NMHDR hdr; int iItem; TBBUTTON tbButton; int cchText; LPTSTR pszText; RECT rcButton;} NMTOOLBAR,
		// *LPNMTOOLBAR; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760473(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760473")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NMTOOLBAR
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
			/// <c>TBBUTTON</c> structure that contains information about the toolbar button associated with the notification code. This
			/// member only contains valid information with the TBN_QUERYINSERT and TBN_QUERYDELETE notification codes.
			/// </para>
			/// </summary>
			public TBBUTTON tbButton;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Count of characters in the button text.</para>
			/// </summary>
			public int cchText;

			/// <summary>
			/// <para>Type: <c><c>LPTSTR</c></c></para>
			/// <para>Address of a character buffer that contains the button text.</para>
			/// </summary>
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
			/// Handle to the module instance with the executable file that contains a bitmap resource. To use bitmap handles instead of
			/// resource IDs, set this member to <c>NULL</c>.
			/// </para>
			/// <para>
			/// You can add the system-defined button bitmaps to the list by specifying HINST_COMMCTRL as the <c>hInst</c> member and one of
			/// the following values as the <c>nID</c> member.
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
			/// If <c>hInst</c> is <c>NULL</c>, set this member to the bitmap handle of the bitmap with the button images. Otherwise, set it
			/// to the resource identifier of the bitmap with the button images.
			/// </para>
			/// </summary>
			public IntPtr nID;
		}

		/// <summary>Contains information about a button in a toolbar.</summary>
		// typedef struct { int iBitmap; int idCommand; BYTE fsState; BYTE fsStyle;#ifdef _WIN64 BYTE bReserved[6];#else #if defined(_WIN32)
		// BYTE bReserved[2];#endif #endif DWORD_PTR dwData; INT_PTR iString;} TBBUTTON, *PTBBUTTON, *LPTBBUTTON; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760476(v=vs.85).aspx
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
		// typedef struct { UINT cbSize; DWORD dwMask; int idCommand; int iImage; BYTE fsState; BYTE fsStyle; WORD cx; DWORD_PTR lParam;
		// LPTSTR pszText; int cchText;} TBBUTTONINFO, *LPTBBUTTONINFO; https://msdn.microsoft.com/en-us/library/windows/desktop/bb760478(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760478")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
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
			/// Set of flags that indicate which members contain valid information. This member must be filled in prior to sending the
			/// associated message. This can be one or more of the following values.
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
			public uint dwMask;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Command identifier of the button.</para>
			/// </summary>
			public int idCommand;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// Image index of the button. Set this member to I_IMAGECALLBACK, and the toolbar will send the TBN_GETDISPINFO notification
			/// code to retrieve the image index when it is needed.
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
			public byte fsState;

			/// <summary>
			/// <para>Type: <c><c>BYTE</c></c></para>
			/// <para>Style flags of the button. This can be one or more of the values listed in Toolbar Control and Button Styles.</para>
			/// </summary>
			public byte fsStyle;

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
			/// <para>Type: <c><c>LPTSTR</c></c></para>
			/// <para>Address of a character buffer that contains or receives the button text.</para>
			/// </summary>
			public string pszText;

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
			public uint dwFlags;
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
			public uint dwMask;

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
			/// <para>
			/// Module instance handle to the bitmap resource being replaced. Set this member to <c>NULL</c> to instead use a bitmap handle.
			/// </para>
			/// </summary>
			public HINSTANCE hInstOld;

			/// <summary>
			/// <para>Type: <c><c>UINT_PTR</c></c></para>
			/// <para>
			/// If <c>hInstOld</c> is <c>NULL</c>, set this member to the bitmap handle of the bitmap that is being replaced. Otherwise, set
			/// it to the resource identifier of the bitmap being replaced.
			/// </para>
			/// </summary>
			public IntPtr nIDOld;

			/// <summary>
			/// <para>Type: <c><c>HINSTANCE</c></c></para>
			/// <para>
			/// Module instance handle that contains the new bitmap resource. Set this member to <c>NULL</c> to instead use a bitmap handle.
			/// </para>
			/// </summary>
			public HINSTANCE hInstNew;

			/// <summary>
			/// <para>Type: <c><c>UINT_PTR</c></c></para>
			/// <para>
			/// If <c>hInstNew</c> is <c>NULL</c>, set this member to the bitmap handle of the bitmap with the new button images. Otherwise,
			/// set it to the resource identifier of the bitmap with the new button images.
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
		/// Specifies the location in the registry where the <c>TB_SAVERESTORE</c> message stores and retrieves information about the state
		/// of a toolbar.
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
			public string pszSubKey;

			/// <summary>
			/// <para>Type: <c><c>LPCTSTR</c></c></para>
			/// <para>Value name.</para>
			/// </summary>
			public string pszValueName;
		}
	}
}