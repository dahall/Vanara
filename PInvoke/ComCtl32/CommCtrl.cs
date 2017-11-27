using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

// ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>The default color.</summary>
		public const uint CLR_DEFAULT = 0xFF000000;

		/// <summary>No color.</summary>
		public const uint CLR_NONE = 0xFFFFFFFF;

		public const int I_IMAGECALLBACK = -1;
		public const int I_IMAGENONE = -2;
		public const int NM_FIRST = 0;

		[PInvokeData("Commctrl.h")]
		public static readonly IntPtr LPSTR_TEXTCALLBACK = (IntPtr)(-1);

		/// <summary>
		/// The set of bit flags that indicate which common control classes will be loaded from the DLL when calling <see cref="InitCommonControlsEx(ref INITCOMMONCONTROLSEX)"/>.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775507")]
		[Flags]
		public enum CommonControlClass
		{
			/// <summary>Load animate control class.</summary>
			ICC_ANIMATE_CLASS = 0X00000080,

			/// <summary>Load toolbar, status bar, trackbar, and tooltip control classes.</summary>
			ICC_BAR_CLASSES = 0X00000004,

			/// <summary>Load rebar control class.</summary>
			ICC_COOL_CLASSES = 0X00000400,

			/// <summary>Load date and time picker control class.</summary>
			ICC_DATE_CLASSES = 0X00000100,

			/// <summary>Load hot key control class.</summary>
			ICC_HOTKEY_CLASS = 0X00000040,

			/// <summary>Load IP address class.</summary>
			ICC_INTERNET_CLASSES = 0X00000800,

			/// <summary>Load a hyperlink control class.</summary>
			ICC_LINK_CLASS = 0X00008000,

			/// <summary>Load list-view and header control classes.</summary>
			ICC_LISTVIEW_CLASSES = 0X00000001,

			/// <summary>Load a native font control class.</summary>
			ICC_NATIVEFNTCTL_CLASS = 0x00002000,

			/// <summary>Load pager control class.</summary>
			ICC_PAGESCROLLER_CLASS = 0X00001000,

			/// <summary>Load progress bar control class.</summary>
			ICC_PROGRESS_CLASS = 0X00000020,

			/// <summary>
			/// Load one of the intrinsic User32 control classes. The user controls include button, edit, static, listbox, combobox, and scroll bar.
			/// </summary>
			ICC_STANDARD_CLASSES = 0X00004000,

			/// <summary>Load tab and tooltip control classes.</summary>
			ICC_TAB_CLASSES = 0X00000008,

			/// <summary>Load tree-view and tooltip control classes.</summary>
			ICC_TREEVIEW_CLASSES = 0X00000002,

			/// <summary>Load up-down control class.</summary>
			ICC_UPDOWN_CLASS = 0X00000010,

			/// <summary>Load ComboBoxEx class.</summary>
			ICC_USEREX_CLASSES = 0X00000200,

			/// <summary>
			/// Load animate control, header, hot key, list-view, progress bar, status bar, tab, tooltip, toolbar, trackbar, tree-view, and up-down control classes.
			/// </summary>
			ICC_WIN95_CLASSES = 0X000000FF
		}

		/// <summary>Notification codes for CommCtrl.h</summary>
		public enum CommonControlNotification
		{
			/// <summary>
			/// Notifies a control's parent window that the control could not complete an operation because there was not enough memory available. This
			/// notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_OUTOFMEMORY = NM_FIRST - 1,

			/// <summary>Sent by a control when the user clicks with the left mouse button. This notification code is sent in the form of a WM_NOTIFY message.</summary>
			NM_CLICK = NM_FIRST - 2,

			/// <summary>
			/// Sent by a control when the user double-clicks with the left mouse button. This notification code is sent in the form of a WM_NOTIFY message.
			/// </summary>
			NM_DBLCLK = NM_FIRST - 3,

			/// <summary>
			/// Notifies a control's parent window that the control has the input focus and that the user has pressed the ENTER key. This notification code is
			/// sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_RETURN = NM_FIRST - 4,

			/// <summary>Sent by a control when the user clicks with the right mouse button. This notification code is sent in the form of a WM_NOTIFY message.</summary>
			NM_RCLICK = NM_FIRST - 5,

			/// <summary>
			/// Sent by a control when the user double-clicks with the right mouse button. This notification code is sent in the form of a WM_NOTIFY message.
			/// </summary>
			NM_RDBLCLK = NM_FIRST - 6,

			/// <summary>
			/// Notifies a control's parent window that the control has received the input focus. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_SETFOCUS = NM_FIRST - 7,

			/// <summary>
			/// Notifies a control's parent window that the control has lost the input focus. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_KILLFOCUS = NM_FIRST - 8,

			/// <summary>
			/// Notifies a control's parent window about custom drawing operations. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>
			/// A pointer to a custom draw-related structure that contains information about the drawing operation. The following list specifies the controls and
			/// their associated structures.
			/// <list type="table">
			/// <listheader>
			/// <term>Control</term>
			/// <term>Custom Draw Structure</term>
			/// </listheader>
			/// <item>
			/// <term>Rebar, trackbar, and header</term>
			/// <term>NMCUSTOMDRAW</term>
			/// </item>
			/// <item>
			/// <term>List view</term>
			/// <term>NMLVCUSTOMDRAW</term>
			/// </item>
			/// <item>
			/// <term>Tooltip</term>
			/// <term>NMTTCUSTOMDRAW</term>
			/// </item>
			/// <item>
			/// <term>Tree view</term>
			/// <term>NMTVCUSTOMDRAW</term>
			/// </item>
			/// <item>
			/// <term>Toolbar</term>
			/// <term>NMTBCUSTOMDRAW</term>
			/// </item>
			/// </list>
			/// </description>
			/// </item>
			/// </list>
			/// <item>
			/// <term>Return value</term>
			/// <description>
			/// The value your application can return depends on the current drawing stage. The dwDrawStage member of the associated NMCUSTOMDRAW structure holds
			/// a value that specifies the drawing stage.
			/// </description>
			/// </item>
			/// </summary>
			NM_CUSTOMDRAW = NM_FIRST - 12,

			/// <summary>
			/// Sent by a control when the mouse hovers over an item. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// <item>
			/// <term>Return value</term>
			/// <description>
			/// Unless otherwise specified, return zero to allow the control to process the hover normally, or nonzero to prevent the hover from being processed.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			NM_HOVER = NM_FIRST - 13,

			/// <summary>
			/// Sent by a rebar control when the control receives a WM_NCHITTEST message. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>
			/// A pointer to a NMMOUSE structure that contains information about the notification code. The pt member contains the mouse coordinates of the hit
			/// test message.
			/// </description>
			/// </item>
			/// <item>
			/// <term>Return value</term>
			/// <description>
			/// Unless otherwise specified, return zero to allow the control to perform default processing of the hit test message, or return one of the HT*
			/// values documented under WM_NCHITTEST to override the default hit test processing.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			NM_NCHITTEST = NM_FIRST - 14,

			/// <summary>
			/// Sent by a control when the control has the keyboard focus and the user presses a key. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMKEY structure that contains additional information about the key that caused the notification code.</description>
			/// </item>
			/// <item>
			/// <term>Return value</term>
			/// <description>Return nonzero to prevent the control from processing the key, or zero otherwise.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_KEYDOWN = NM_FIRST - 15,

			/// <summary>
			/// Notifies a control's parent window that the control is releasing mouse capture. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_RELEASEDCAPTURE = NM_FIRST - 16,

			/// <summary>
			/// Notifies a control's parent window that the control is setting the cursor in response to a WM_SETCURSOR message. This notification code is sent
			/// in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMMOUSE structure that contains additional information about this notification.</description>
			/// </item>
			/// <item>
			/// <term>Return value</term>
			/// <description>Return zero to enable the control to set the cursor or nonzero to prevent the control from setting the cursor.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_SETCURSOR = NM_FIRST - 17,

			/// <summary>
			/// The NM_CHAR notification code is sent by a control when a character key is processed. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMCHAR structure that contains additional information about the character that caused the notification code.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_CHAR = NM_FIRST - 18,

			/// <summary>
			/// Notifies a control's parent window that the control has created a tooltip control. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMTOOLTIPSCREATED structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_TOOLTIPSCREATED = NM_FIRST - 19,

			/// <summary>
			/// Notifies a control's parent window that the left mouse button has been pressed. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_LDOWN = NM_FIRST - 20,

			/// <summary>This notification code is not supported.</summary>
			NM_RDOWN = NM_FIRST - 21,

			/// <summary>
			/// Notifies a control's parent window that the theme has changed. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_THEMECHANGED = NM_FIRST - 22,

			/// <summary>
			/// Sent by a list-view control when the control has changed a font. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_FONTCHANGED = NM_FIRST - 23,

			/// <summary>
			/// Notifies a control's parent window about custom text operations. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMCUSTOMTEXT structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_CUSTOMTEXT = NM_FIRST - 24,

			/// <summary>
			/// Sent by a tree-view control to its parent window that the state image is changing. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMTVSTATEIMAGECHANGING structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_TVSTATEIMAGECHANGING = NM_FIRST - 24,
		}

		/// <summary>The current item state.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775483")]
		[Flags]
		public enum CustomDrawItemState
		{
			/// <summary>The item is selected.</summary>
			CDIS_SELECTED = 0x0001,

			/// <summary>The item is grayed.</summary>
			CDIS_GRAYED = 0x0002,

			/// <summary>The item is disabled.</summary>
			CDIS_DISABLED = 0x0004,

			/// <summary>The item is in focus.</summary>
			CDIS_CHECKED = 0x0008,

			/// <summary>The item is in focus.</summary>
			CDIS_FOCUS = 0x0010,

			/// <summary>The item is in its default state.</summary>
			CDIS_DEFAULT = 0x0020,

			/// <summary>The item is currently under the pointer ("hot").</summary>
			CDIS_HOT = 0x0040,

			/// <summary>
			/// The item is marked. The meaning of this is determined by the implementation. <note>This flag does not work correctly for owner-drawn list-view
			/// controls that have the LVS_SHOWSELALWAYS style. For these controls, you can determine whether an item is selected by using LVM_GETITEMSTATE (or
			/// ListView_GetItemState) and checking for the LVIS_SELECTED flag.</note>
			/// </summary>
			CDIS_MARKED = 0x0080,

			/// <summary>The item is in an indeterminate state.</summary>
			CDIS_INDETERMINATE = 0x0100,

			/// <summary>
			/// Version 6.0.The item is showing its keyboard cues. <note>Comctl32 version 6 is not redistributable. operating systems. To use Comctl32.dll
			/// version 6, specify it in the manifest. For more information on manifests, see Enabling Visual Styles.</note>
			/// </summary>
			CDIS_SHOWKEYBOARDCUES = 0x0200,

			/// <summary>
			/// The item is part of a control that is currently under the mouse pointer ("hot"), but the item is not "hot" itself. The meaning of this is
			/// determined by the implementation.
			/// </summary>
			CDIS_NEARHOT = 0x0400,

			/// <summary>
			/// The item is part of a splitbutton that is currently under the mouse pointer ("hot"), but the item is not "hot" itself. The meaning of this is
			/// determined by the implementation.
			/// </summary>
			CDIS_OTHERSIDEHOT = 0x0800,

			/// <summary>The item is currently the drop target of a drag-and-drop operation.</summary>
			CDIS_DROPHILITED = 0x1000,
		}

		/// <summary>These constants are used as return values by a control in response to an NM_CUSTOMDRAW notification code.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775489")]
		[Flags]
		public enum CustomDrawResponse
		{
			/// <summary>
			/// The control will draw itself. It will not send any additional NM_CUSTOMDRAW notification codes for this paint cycle. This occurs when the
			/// dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_PREPAINT.
			/// </summary>
			CDRF_DODEFAULT = 0x00000000,

			/// <summary>
			/// The application specified a new font for the item; the control will use the new font. For more information about changing fonts, see Changing
			/// fonts and colors. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_ITEMPREPAINT.
			/// </summary>
			CDRF_NEWFONT = 0x00000002,

			/// <summary>
			/// The application drew the item manually. The control will not draw the item. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_ITEMPREPAINT.
			/// </summary>
			CDRF_SKIPDEFAULT = 0x00000004,

			/// <summary>Windows Vista and later. The control will draw the background.</summary>
			CDRF_DOERASE = 0x00000008,

			/// <summary>
			/// The control will notify the parent after painting an item. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_PREPAINT.
			/// </summary>
			CDRF_NOTIFYPOSTPAINT = 0x00000010,

			/// <summary>
			/// The control will notify the parent of any item-related drawing operations. It will send NM_CUSTOMDRAW notification codes before and after drawing
			/// items. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_PREPAINT.
			/// </summary>
			CDRF_NOTIFYITEMDRAW = 0x00000020,

			/// <summary>
			/// Internet Explorer 4.0 and later. The control will notify the parent of any item-related drawing operations. It will send NM_CUSTOMDRAW
			/// notification codes before and after drawing items. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_PREPAINT. This flag
			/// is identical to CDRF_NOTIFYITEMDRAW and its use is context-dependent.
			/// </summary>
			CDRF_NOTIFYSUBITEMDRAW = 0x00000020,

			/// <summary>
			/// The control will notify the parent after erasing an item. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_PREPAINT.
			/// </summary>
			CDRF_NOTIFYPOSTERASE = 0x00000040,

			/// <summary>Windows Vista and later. The control will not draw the focus rectangle.</summary>
			CDRF_SKIPPOSTPAINT = 0x00000100,
		}

		/// <summary>The current drawing stage.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775483")]
		[Flags]
		public enum CustomDrawStage
		{
			/// <summary>Before the painting cycle begins.</summary>
			CDDS_PREPAINT = 0x00000001,

			/// <summary>After the painting cycle is complete.</summary>
			CDDS_POSTPAINT = 0x00000002,

			/// <summary>Before the erasing cycle begins.</summary>
			CDDS_PREERASE = 0x00000003,

			/// <summary>After the erasing cycle is complete.</summary>
			CDDS_POSTERASE = 0x00000004,

			/// <summary>Indicates that the dwItemSpec, uItemState, and lItemlParam members are valid.</summary>
			CDDS_ITEM = 0x00010000,

			/// <summary>Before an item is drawn.</summary>
			CDDS_ITEMPREPAINT = (CDDS_ITEM | CDDS_PREPAINT),

			/// <summary>After an item has been drawn.</summary>
			CDDS_ITEMPOSTPAINT = (CDDS_ITEM | CDDS_POSTPAINT),

			/// <summary>Before an item is erased.</summary>
			CDDS_ITEMPREERASE = (CDDS_ITEM | CDDS_PREERASE),

			/// <summary>After an item has been erased.</summary>
			CDDS_ITEMPOSTERASE = (CDDS_ITEM | CDDS_POSTERASE),

			/// <summary>
			/// Flag combined with CDDS_ITEMPREPAINT or CDDS_ITEMPOSTPAINT if a subitem is being drawn. This will only be set if CDRF_NOTIFYITEMDRAW is returned
			/// from CDDS_PREPAINT.
			/// </summary>
			CDDS_SUBITEM = 0x00020000,
		}

		/// <summary>Flags that indicate why the hot item has changed.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760456")]
		[Flags]
		public enum HotItemChangeFlags
		{
			/// <summary>
			/// The change in the hot item resulted from an event that could not be determined. This will most often be due to a change in focus or the
			/// TB_SETHOTITEM message.
			/// </summary>
			HICF_OTHER = 0x00000000,

			/// <summary>The change in the hot item resulted from a mouse event.</summary>
			HICF_MOUSE = 0x00000001,

			/// <summary>The change in the hot item was caused by an arrow key.</summary>
			HICF_ARROWKEYS = 0x00000002,

			/// <summary>The change in the hot item was caused by a shortcut key.</summary>
			HICF_ACCELERATOR = 0x00000004,

			/// <summary>Modifies HICF_ACCELERATOR. If this flag is set, more than one item has the same shortcut key character.</summary>
			HICF_DUPACCEL = 0x00000008,

			/// <summary>Modifies the other reason flags. If this flag is set, there is no previous hot item and idOld does not contain valid information.</summary>
			HICF_ENTERING = 0x00000010,

			/// <summary>Modifies the other reason flags. If this flag is set, there is no new hot item and idNew does not contain valid information.</summary>
			HICF_LEAVING = 0x00000020,

			/// <summary>The change in the hot item resulted from the user entering the shortcut key for an item that was already hot.</summary>
			HICF_RESELECT = 0x00000040,

			/// <summary>The change in the hot item resulted from a left-click mouse event.</summary>
			HICF_LMOUSE = 0x00000080,

			/// <summary>Version 5.80. Causes the button to switch states.</summary>
			HICF_TOGGLEDROPDOWN = 0x00000100,
		}

		[Flags]
		public enum HOTKEYF : byte
		{
			/// <summary>SHIFT key</summary>
			HOTKEYF_SHIFT = 0x01,

			/// <summary>CTRL key</summary>
			HOTKEYF_CONTROL = 0x02,

			/// <summary>ALT key</summary>
			HOTKEYF_ALT = 0x04,

			/// <summary>Extended key</summary>
			HOTKEYF_EXT = 0x08,
		}

		/// <summary>
		/// Ensures that the common control DLL (Comctl32.dll) is loaded, and registers specific common control classes from the DLL. An application must call
		/// this function before creating a common control.
		/// </summary>
		/// <param name="icc">A pointer to an INITCOMMONCONTROLSEX structure that contains information specifying which control classes will be registered.</param>
		/// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775697")]
		[DllImport(Lib.ComCtl32, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitCommonControlsEx(ref INITCOMMONCONTROLSEX icc);

		/// <summary>
		/// Ensures that the common control DLL (Comctl32.dll) is loaded, and registers specific common control classes from the DLL. An application must call
		/// this function before creating a common control.
		/// </summary>
		/// <param name="ccc">The <see cref="CommonControlClass"/> value to assign to the dwICC field in <see cref="INITCOMMONCONTROLSEX"/>.</param>
		/// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775697")]
		public static bool InitCommonControlsEx(CommonControlClass ccc)
		{
			var icc = new INITCOMMONCONTROLSEX(ccc);
			return InitCommonControlsEx(ref icc);
		}

		/// <summary>Contains information for the drawing of buttons in a toolbar or rebar.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct COLORSCHEME
		{
			/// <summary>The size of this structure, in bytes.</summary>
			public uint dwSize;

			/// <summary>The COLORREF value that represents the highlight color of the buttons. Use CLR_DEFAULT for the default highlight color.</summary>
			public uint clrBtnHighlight;

			/// <summary>The COLORREF value that represents the shadow color of the buttons. Use CLR_DEFAULT for the default shadow color.</summary>
			public uint clrBtnShadow;
		}

		/// <summary>
		/// Carries information used to load common control classes from the dynamic-link library (DLL). This structure is used with the <see
		/// cref="InitCommonControlsEx(ref INITCOMMONCONTROLSEX)"/> function.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775507")]
		[StructLayout(LayoutKind.Sequential)]
		public struct INITCOMMONCONTROLSEX
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public int dwSize;

			/// <summary>
			/// The set of bit flags that indicate which common control classes will be loaded from the DLL when calling <see cref="InitCommonControlsEx(ref INITCOMMONCONTROLSEX)"/>.
			/// </summary>
			public CommonControlClass dwICC;

			/// <summary>Initializes a new instance of the <see cref="INITCOMMONCONTROLSEX"/> class and sets the dwICC field.</summary>
			/// <param name="ccc">The <see cref="CommonControlClass"/> value to assign to the dwICC field.</param>
			public INITCOMMONCONTROLSEX(CommonControlClass ccc)
			{
				dwICC = ccc;
				dwSize = Marshal.SizeOf(typeof(INITCOMMONCONTROLSEX));
			}
		}

		/// <summary>Contains information specific to an NM_CUSTOMDRAW notification code.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775483")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMCUSTOMDRAW
		{
			/// <summary>An NMHDR structure that contains information about this notification code.</summary>
			public NMHDR hdr;

			/// <summary>The current drawing stage.</summary>
			public CustomDrawStage dwDrawStage;

			/// <summary>A handle to the control's device context. Use this HDC to perform any GDI functions.</summary>
			public IntPtr hdc;

			/// <summary>
			/// The RECT structure that describes the bounding rectangle of the area being drawn. This member is initialized only by the CDDS_ITEMPREPAINT
			/// notification. Version 5.80. This member is also initialized by the CDDS_PREPAINT notification.
			/// </summary>
			public RECT rc;

			/// <summary>
			/// The item number. What is contained in this member will depend on the type of control that is sending the notification. See the NM_CUSTOMDRAW
			/// notification reference for the specific control to determine what, if anything, is contained in this member.
			/// </summary>
			public IntPtr dwItemSpec;

			/// <summary>The current item state.</summary>
			public CustomDrawItemState uItemState;

			/// <summary>Application-defined item data.</summary>
			public IntPtr lItemlParam;
		}

		/// <summary>Contains information about the two rectangles of a split button. Sent with the NM_GETCUSTOMSPLITRECT notification.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775510")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMCUSTOMSPLITRECTINFO
		{
			/// <summary>An NMHDR structure that contains information about the notification.</summary>
			public NMHDR hdr;

			/// <summary>A RECT structure that describes the client area the button occupies.</summary>
			public RECT rcClient;

			/// <summary>A RECT structure that describes the rectangle that does not contain the drop-down arrow.</summary>
			public RECT rcButton;

			/// <summary>A RECT structure that describes the rectangle that contains the drop-down arrow.</summary>
			public RECT rcSplit;
		}
	}
}