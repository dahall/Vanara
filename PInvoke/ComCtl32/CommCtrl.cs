using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

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
		public const int INFOTIPSIZE = 1024;
		public const int NM_FIRST = 0;

		[PInvokeData("Commctrl.h")]
		public static readonly IntPtr LPSTR_TEXTCALLBACK = (IntPtr)(-1);

		/// <summary>Defines the prototype for the callback function used by <c>RemoveWindowSubclass</c> and <c>SetWindowSubclass</c>.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle to the subclassed window.</para>
		/// </param>
		/// <param name="uMsg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message being passed.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Additional message information. The contents of this parameter depend on the value of uMsg.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Additional message information. The contents of this parameter depend on the value of uMsg.</para>
		/// </param>
		/// <param name="uIdSubclass">
		/// <para>Type: <c>UINT_PTR</c></para>
		/// <para>The subclass ID.</para>
		/// </param>
		/// <param name="dwRefData">
		/// <para>Type: <c>DWORD_PTR</c></para>
		/// <para>
		/// The reference data provided to the <c>SetWindowSubclass</c> function. This can be used to associate the subclass instance with a
		/// "this" pointer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>The return value is the result of the message processing and depends on the message sent.</para>
		/// </returns>
		// typedef LRESULT ( CALLBACK *SUBCLASSPROC)( HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam, UINT_PTR uIdSubclass, DWORD_PTR
		// dwRefData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb776774(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb776774")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate IntPtr SUBCLASSPROC(HWND hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, [MarshalAs(UnmanagedType.SysUInt)] uint uIdSubclass, IntPtr dwRefData);

		/// <summary>
		/// The set of bit flags that indicate which common control classes will be loaded from the DLL when calling <see cref="InitCommonControlsEx(in INITCOMMONCONTROLSEX)"/>.
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
			/// Load one of the intrinsic User32 control classes. The user controls include button, edit, static, listbox, combobox, and
			/// scroll bar.
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
			/// Load animate control, header, hot key, list-view, progress bar, status bar, tab, tooltip, toolbar, trackbar, tree-view, and
			/// up-down control classes.
			/// </summary>
			ICC_WIN95_CLASSES = 0X000000FF
		}

		/// <summary>Notification codes for CommCtrl.h</summary>
		public enum CommonControlNotification
		{
			/// <summary>
			/// Notifies a control's parent window that the control could not complete an operation because there was not enough memory
			/// available. This notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_OUTOFMEMORY = NM_FIRST - 1,

			/// <summary>
			/// Sent by a control when the user clicks with the left mouse button. This notification code is sent in the form of a WM_NOTIFY message.
			/// </summary>
			NM_CLICK = NM_FIRST - 2,

			/// <summary>
			/// Sent by a control when the user double-clicks with the left mouse button. This notification code is sent in the form of a
			/// WM_NOTIFY message.
			/// </summary>
			NM_DBLCLK = NM_FIRST - 3,

			/// <summary>
			/// Notifies a control's parent window that the control has the input focus and that the user has pressed the ENTER key. This
			/// notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_RETURN = NM_FIRST - 4,

			/// <summary>
			/// Sent by a control when the user clicks with the right mouse button. This notification code is sent in the form of a WM_NOTIFY message.
			/// </summary>
			NM_RCLICK = NM_FIRST - 5,

			/// <summary>
			/// Sent by a control when the user double-clicks with the right mouse button. This notification code is sent in the form of a
			/// WM_NOTIFY message.
			/// </summary>
			NM_RDBLCLK = NM_FIRST - 6,

			/// <summary>
			/// Notifies a control's parent window that the control has received the input focus. This notification code is sent in the form
			/// of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_SETFOCUS = NM_FIRST - 7,

			/// <summary>
			/// Notifies a control's parent window that the control has lost the input focus. This notification code is sent in the form of a
			/// WM_NOTIFY message.
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
			/// A pointer to a custom draw-related structure that contains information about the drawing operation. The following list
			/// specifies the controls and their associated structures.
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
			/// The value your application can return depends on the current drawing stage. The dwDrawStage member of the associated
			/// NMCUSTOMDRAW structure holds a value that specifies the drawing stage.
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
			/// Unless otherwise specified, return zero to allow the control to process the hover normally, or nonzero to prevent the hover
			/// from being processed.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			NM_HOVER = NM_FIRST - 13,

			/// <summary>
			/// Sent by a rebar control when the control receives a WM_NCHITTEST message. This notification code is sent in the form of a
			/// WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>
			/// A pointer to a NMMOUSE structure that contains information about the notification code. The pt member contains the mouse
			/// coordinates of the hit test message.
			/// </description>
			/// </item>
			/// <item>
			/// <term>Return value</term>
			/// <description>
			/// Unless otherwise specified, return zero to allow the control to perform default processing of the hit test message, or return
			/// one of the HT* values documented under WM_NCHITTEST to override the default hit test processing.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			NM_NCHITTEST = NM_FIRST - 14,

			/// <summary>
			/// Sent by a control when the control has the keyboard focus and the user presses a key. This notification code is sent in the
			/// form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>
			/// A pointer to an NMKEY structure that contains additional information about the key that caused the notification code.
			/// </description>
			/// </item>
			/// <item>
			/// <term>Return value</term>
			/// <description>Return nonzero to prevent the control from processing the key, or zero otherwise.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_KEYDOWN = NM_FIRST - 15,

			/// <summary>
			/// Notifies a control's parent window that the control is releasing mouse capture. This notification code is sent in the form of
			/// a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMHDR structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_RELEASEDCAPTURE = NM_FIRST - 16,

			/// <summary>
			/// Notifies a control's parent window that the control is setting the cursor in response to a WM_SETCURSOR message. This
			/// notification code is sent in the form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMMOUSE structure that contains additional information about this notification.</description>
			/// </item>
			/// <item>
			/// <term>Return value</term>
			/// <description>
			/// Return zero to enable the control to set the cursor or nonzero to prevent the control from setting the cursor.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			NM_SETCURSOR = NM_FIRST - 17,

			/// <summary>
			/// The NM_CHAR notification code is sent by a control when a character key is processed. This notification code is sent in the
			/// form of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>
			/// A pointer to an NMCHAR structure that contains additional information about the character that caused the notification code.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			NM_CHAR = NM_FIRST - 18,

			/// <summary>
			/// Notifies a control's parent window that the control has created a tooltip control. This notification code is sent in the form
			/// of a WM_NOTIFY message.
			/// <list>
			/// <item>
			/// <term>lParam</term>
			/// <description>A pointer to an NMTOOLTIPSCREATED structure that contains additional information about this notification.</description>
			/// </item>
			/// </list>
			/// </summary>
			NM_TOOLTIPSCREATED = NM_FIRST - 19,

			/// <summary>
			/// Notifies a control's parent window that the left mouse button has been pressed. This notification code is sent in the form of
			/// a WM_NOTIFY message.
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
			/// Sent by a tree-view control to its parent window that the state image is changing. This notification code is sent in the form
			/// of a WM_NOTIFY message.
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
			/// The item is marked. The meaning of this is determined by the implementation. <note>This flag does not work correctly for
			/// owner-drawn list-view controls that have the LVS_SHOWSELALWAYS style. For these controls, you can determine whether an item
			/// is selected by using LVM_GETITEMSTATE (or
			/// ListView_GetItemState) and checking for the LVIS_SELECTED flag.</note>
			/// </summary>
			CDIS_MARKED = 0x0080,

			/// <summary>The item is in an indeterminate state.</summary>
			CDIS_INDETERMINATE = 0x0100,

			/// <summary>
			/// Version 6.0.The item is showing its keyboard cues. <note>Comctl32 version 6 is not redistributable. operating systems. To use
			/// Comctl32.dll version 6, specify it in the manifest. For more information on manifests, see Enabling Visual Styles.</note>
			/// </summary>
			CDIS_SHOWKEYBOARDCUES = 0x0200,

			/// <summary>
			/// The item is part of a control that is currently under the mouse pointer ("hot"), but the item is not "hot" itself. The
			/// meaning of this is determined by the implementation.
			/// </summary>
			CDIS_NEARHOT = 0x0400,

			/// <summary>
			/// The item is part of a splitbutton that is currently under the mouse pointer ("hot"), but the item is not "hot" itself. The
			/// meaning of this is determined by the implementation.
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
			/// The control will draw itself. It will not send any additional NM_CUSTOMDRAW notification codes for this paint cycle. This
			/// occurs when the dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_PREPAINT.
			/// </summary>
			CDRF_DODEFAULT = 0x00000000,

			/// <summary>
			/// The application specified a new font for the item; the control will use the new font. For more information about changing
			/// fonts, see Changing fonts and colors. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_ITEMPREPAINT.
			/// </summary>
			CDRF_NEWFONT = 0x00000002,

			/// <summary>
			/// The application drew the item manually. The control will not draw the item. This occurs when the dwDrawStage of the
			/// NMCUSTOMDRAW structure equals CDDS_ITEMPREPAINT.
			/// </summary>
			CDRF_SKIPDEFAULT = 0x00000004,

			/// <summary>Windows Vista and later. The control will draw the background.</summary>
			CDRF_DOERASE = 0x00000008,

			/// <summary>
			/// The control will notify the parent after painting an item. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure
			/// equals CDDS_PREPAINT.
			/// </summary>
			CDRF_NOTIFYPOSTPAINT = 0x00000010,

			/// <summary>
			/// The control will notify the parent of any item-related drawing operations. It will send NM_CUSTOMDRAW notification codes
			/// before and after drawing items. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure equals CDDS_PREPAINT.
			/// </summary>
			CDRF_NOTIFYITEMDRAW = 0x00000020,

			/// <summary>
			/// Internet Explorer 4.0 and later. The control will notify the parent of any item-related drawing operations. It will send
			/// NM_CUSTOMDRAW notification codes before and after drawing items. This occurs when the dwDrawStage of the NMCUSTOMDRAW
			/// structure equals CDDS_PREPAINT. This flag is identical to CDRF_NOTIFYITEMDRAW and its use is context-dependent.
			/// </summary>
			CDRF_NOTIFYSUBITEMDRAW = 0x00000020,

			/// <summary>
			/// The control will notify the parent after erasing an item. This occurs when the dwDrawStage of the NMCUSTOMDRAW structure
			/// equals CDDS_PREPAINT.
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
			/// Flag combined with CDDS_ITEMPREPAINT or CDDS_ITEMPOSTPAINT if a subitem is being drawn. This will only be set if
			/// CDRF_NOTIFYITEMDRAW is returned from CDDS_PREPAINT.
			/// </summary>
			CDDS_SUBITEM = 0x00020000,
		}

		/// <summary>Flags that indicate why the hot item has changed.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760456")]
		[Flags]
		public enum HotItemChangeFlags
		{
			/// <summary>
			/// The change in the hot item resulted from an event that could not be determined. This will most often be due to a change in
			/// focus or the TB_SETHOTITEM message.
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

			/// <summary>
			/// Modifies the other reason flags. If this flag is set, there is no previous hot item and idOld does not contain valid information.
			/// </summary>
			HICF_ENTERING = 0x00000010,

			/// <summary>
			/// Modifies the other reason flags. If this flag is set, there is no new hot item and idNew does not contain valid information.
			/// </summary>
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

		/// <summary>The desired metric.</summary>
		public enum LI_METRIC
		{
			/// <summary>Corresponds to SM_CXSMICON, the recommended pixel width of a small icon.</summary>
			LIM_SMALL,

			/// <summary>Corresponds toSM_CXICON, the default pixel width of an icon.</summary>
			LIM_LARGE,
		}

		/// <summary>
		/// Posts messages when the mouse pointer leaves a window or hovers over a window for a specified amount of time. This function calls
		/// TrackMouseEvent if it exists, otherwise it emulates it.
		/// </summary>
		/// <param name="lpEventTrack">
		/// <para>Type: <c>LPTRACKMOUSEEVENT</c></para>
		/// <para>A pointer to a <c>TRACKMOUSEEVENT</c> structure that contains tracking information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero .</para>
		/// <para>If the function fails, return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI TrackMouseEvent( _Inout_ LPTRACKMOUSEEVENT lpEventTrack); https://msdn.microsoft.com/en-us/library/windows/desktop/ms646266(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("CommCtrl.h", MSDNShortId = "ms646266")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool _TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

		/// <summary>
		/// Calls the next handler in a window's subclass chain. The last handler in the subclass chain calls the original window procedure
		/// for the window.
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window being subclassed.</para>
		/// </param>
		/// <param name="uMsg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A value of type unsigned <c>int</c> that specifies a window message.</para>
		/// </param>
		/// <param name="WPARAM">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Specifies additional message information. The contents of this parameter depend on the value of the window message.</para>
		/// </param>
		/// <param name="LPARAM">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>
		/// Specifies additional message information. The contents of this parameter depend on the value of the window message. Note: On
		/// 64-bit versions of Windows LPARAM is a 64-bit value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>The returned value is specific to the message sent. This value should be ignored.</para>
		/// </returns>
		// LRESULT DefSubclassProc( _In_ HWND hWnd, _In_ UINT uMsg, _In_ WPARAM WPARAM, _In_ LPARAM LPARAM); https://msdn.microsoft.com/en-us/library/windows/desktop/bb776403(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb776403")]
		public static extern IntPtr DefSubclassProc(HWND hWnd, uint uMsg, IntPtr WPARAM, IntPtr LPARAM);

		/// <summary>Draws text that has a shadow.</summary>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC.</para>
		/// </param>
		/// <param name="pszText">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>A pointer to a string that contains the text to be drawn.</para>
		/// </param>
		/// <param name="cch">
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>A <c>UINT</c> that specifies the number of characters in the string that is to be drawn.</para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>const <c>RECT</c>*</c></para>
		/// <para>A pointer to a <c>RECT</c> structure that contains, in logical coordinates, the rectangle in which the text is to be drawn.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>A <c>DWORD</c> that specifies how the text is to be drawn. See Format Values for possible parameter values.</para>
		/// </param>
		/// <param name="crText">
		/// <para>Type: <c><c>COLORREF</c></c></para>
		/// <para>A <c>COLORREF</c> structure that contains the color of the text.</para>
		/// </param>
		/// <param name="crShadow">
		/// <para>Type: <c><c>COLORREF</c></c></para>
		/// <para>A <c>COLORREF</c> structure that contains the color of the text shadow.</para>
		/// </param>
		/// <param name="ixOffset">
		/// <para>Type: <c>int</c></para>
		/// <para>A value of type <c>int</c> that specifies the x-coordinate of where the text should begin.</para>
		/// </param>
		/// <param name="iyOffset">
		/// <para>Type: <c>int</c></para>
		/// <para>A value of type <c>int</c> that specifies the y-coordinate of where the text should begin.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>Returns the height of the text in logical units if the function succeeds, otherwise returns zero.</para>
		/// </returns>
		// int DrawShadowText( HDC hdc, LPCWSTR pszText, UINT cch, const RECT *pRect, DWORD dwFlags, COLORREF crText, COLORREF crShadow, int
		// ixOffset, int iyOffset); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775639(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775639")]
		public static extern int DrawShadowText(HDC hdc, string pszText, uint cch, in RECT pRect, uint dwFlags, COLORREF crText, COLORREF crShadow, int ixOffset, int iyOffset);

		/// <summary>Calculates the dimensions of a rectangle in the client area that contains all the specified controls.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>A handle to the window that has the client area to check.</para>
		/// </param>
		/// <param name="lprc">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>A pointer to a <c>RECT</c> structure that receives the dimensions of the rectangle.</para>
		/// </param>
		/// <param name="lpInfo">
		/// <para>Type: <c>const <c>INT</c>*</c></para>
		/// <para>
		/// A pointer to a null-terminated array of integers that identify controls in the client area. Each control requires a pair of
		/// consecutive elements. The first element of the pair must be nonzero and the second element of the pair must be the control
		/// identifier. The first pair represents the menu and is ignored. The last element must be zero to identify the end of the array.
		/// </para>
		/// </param>
		/// <returns>No return value.</returns>
		// void GetEffectiveClientRect( HWND hWnd, LPRECT lprc, _In_ const INT *lpInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775674(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775674")]
		public static extern void GetEffectiveClientRect(HWND hWnd, out RECT lprc, IntPtr lpInfo);

		/// <summary>Calculates the dimensions of a rectangle in the client area that contains all the specified controls.</summary>
		/// <param name="hWnd">A handle to the window that has the client area to check.</param>
		/// <param name="controlIdentifiers">An array of integers that identify the control identifiers in the client area.</param>
		/// <returns>The dimensions of the rectangle.</returns>
		// void GetEffectiveClientRect( HWND hWnd, LPRECT lprc, _In_ const INT *lpInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775674(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775674")]
		public static RECT GetEffectiveClientRect(HWND hWnd, int[] controlIdentifiers)
		{
			var lpInfo = new int[(controlIdentifiers.Length + 2) * 2];
			for (var i = 0; i < controlIdentifiers.Length; i++)
			{
				lpInfo[(i + 1) * 2] = 1;
				lpInfo[((i + 1) * 2) + 1] = controlIdentifiers[i];
			}
			var ptr = InteropServices.SafeCoTaskMemHandle.CreateFromList(lpInfo);
			GetEffectiveClientRect(hWnd, out var rect, (IntPtr)ptr);
			return rect;
		}

		/// <summary>Gets the language currently in use by the common controls for a particular process.</summary>
		/// <returns>
		/// <para>Type: <c><c>LANGID</c></c></para>
		/// <para>
		/// Returns the language identifier of the language an application has specified for the common controls by calling
		/// <c>InitMUILanguage</c>. <c>GetMUILanguage</c> returns the value for the process from which it is called. If
		/// <c>InitMUILanguage</c> has not been called or was not called from the same process, <c>GetMUILanguage</c> returns the
		/// language-neutral LANGID, <c>MAKELANGID</c>(LANG_NEUTRAL, SUBLANG_NEUTRAL).
		/// </para>
		/// </returns>
		// LANGID GetMUILanguage(void); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775676(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775676")]
		public static extern ushort GetMUILanguage();

		/// <summary>Retrieves the reference data for the specified window subclass callback.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the window being subclassed.</para>
		/// </param>
		/// <param name="pfnSubclass">
		/// <para>Type: <c><c>SUBCLASSPROC</c></c></para>
		/// <para>A pointer to a window procedure. This pointer and the subclass ID uniquely identify this subclass callback.</para>
		/// </param>
		/// <param name="uIdSubclass">
		/// <para>Type: <c>UINT_PTR</c></para>
		/// <para>
		/// <c>UINT_PTR</c> subclass ID. This ID and the callback pointer uniquely identify this subclass callback. Note: On 64-bit versions
		/// of Windows this is a 64-bit value.
		/// </para>
		/// </param>
		/// <param name="pdwRefData">
		/// <para>Type: <c>DWORD_PTR*</c></para>
		/// <para>
		/// A pointer to a <c>DWORD</c> which will return the reference data. Note: On 64-bit versions of Windows, pointers are 64-bit values.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The subclass callback was successfully installed.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The subclass callback was not installed.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL GetWindowSubclass( _In_ HWND hWnd, _In_ SUBCLASSPROC pfnSubclass, _In_ UINT_PTR uIdSubclass, _Out_ DWORD_PTR *pdwRefData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb776430(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb776430")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowSubclass(HWND hWnd, SUBCLASSPROC pfnSubclass, [MarshalAs(UnmanagedType.SysUInt)] uint uIdSubclass, out IntPtr pdwRefData);

		/// <summary>
		/// Ensures that the common control DLL (Comctl32.dll) is loaded, and registers specific common control classes from the DLL. An
		/// application must call this function before creating a common control.
		/// </summary>
		/// <param name="icc">
		/// A pointer to an INITCOMMONCONTROLSEX structure that contains information specifying which control classes will be registered.
		/// </param>
		/// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775697")]
		[DllImport(Lib.ComCtl32, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitCommonControlsEx(in INITCOMMONCONTROLSEX icc);

		/// <summary>
		/// Ensures that the common control DLL (Comctl32.dll) is loaded, and registers specific common control classes from the DLL. An
		/// application must call this function before creating a common control.
		/// </summary>
		/// <param name="ccc">The <see cref="CommonControlClass"/> value to assign to the dwICC field in <see cref="INITCOMMONCONTROLSEX"/>.</param>
		/// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775697")]
		public static bool InitCommonControlsEx(CommonControlClass ccc) => InitCommonControlsEx(new INITCOMMONCONTROLSEX(ccc));

		/// <summary>
		/// Enables an application to specify a language to be used with the common controls that is different from the system language.
		/// </summary>
		/// <param name="uiLang">
		/// <para>Type: <c><c>LANGID</c></c></para>
		/// <para>The language identifier of the language to be used by the common controls.</para>
		/// </param>
		/// <returns>None</returns>
		// VOID InitMUILanguage( LANGID uiLang); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775699(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775699")]
		public static extern void InitMUILanguage(ushort uiLang);

		/// <summary>Loads a specified icon resource with a client-specified system metric.</summary>
		/// <param name="hinst">
		/// <para>Type: <c><c>HINSTANCE</c></c></para>
		/// <para>
		/// A handle to the module of either a DLL or executable (.exe) file that contains the icon to be loaded. For more information, see <c>GetModuleHandle</c>.
		/// </para>
		/// <para>To load a predefined icon or a standalone icon file, set this parameter to <c>NULL</c>.</para>
		/// </param>
		/// <param name="pszName">
		/// <para>Type: <c><c>PCWSTR</c></c></para>
		/// <para>
		/// A pointer to a null-terminated, Unicode buffer that contains location information about the icon to load. It is interpreted as follows:
		/// </para>
		/// <para>If hinst is <c>NULL</c>, pszName can specify one of two things.</para>
		/// <para>If hinst is non-null, pszName can specify one of two things.</para>
		/// </param>
		/// <param name="lims">
		/// <para>Type: <c>int</c></para>
		/// <para>The desired metric. One of the following values:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LIM_SMALL</term>
		/// <term>Corresponds to SM_CXSMICON, the recommended pixel width of a small icon.</term>
		/// </item>
		/// <item>
		/// <term>LIM_LARGE</term>
		/// <term>Corresponds toSM_CXICON, the default pixel width of an icon.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="phico">
		/// <para>Type: <c><c>HICON</c>*</c></para>
		/// <para>When this function returns, contains a pointer to the handle of the loaded icon.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>Returns S_OK if successful, otherwise an error, including the following value.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The contents of the buffer pointed to by pszName do not fit any of the expected interpretations.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT LoadIconMetric( _In_ HINSTANCE hinst, _In_ PCWSTR pszName, _In_ int lims, _Out_ HICON *phico); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775701(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775701")]
		public static extern HRESULT LoadIconMetric(HINSTANCE hinst, string pszName, LI_METRIC lims, out SafeHICON phico);

		/// <summary>
		/// Loads an icon. If the icon is not a standard size, this function scales down a larger image instead of scaling up a smaller image.
		/// </summary>
		/// <param name="hinst">
		/// <para>Type: <c><c>HINSTANCE</c></c></para>
		/// <para>
		/// A handle to the module of either a DLL or executable (.exe) file that contains the icon to be loaded. For more information, see <c>GetModuleHandle</c>.
		/// </para>
		/// <para>To load a predefined icon or a standalone icon file, set this parameter to <c>NULL</c>.</para>
		/// </param>
		/// <param name="pszName">
		/// <para>Type: <c><c>PCWSTR</c></c></para>
		/// <para>A pointer to a null-terminated, Unicode buffer that contains location information about the icon to load.</para>
		/// <para>
		/// If hinst is non- <c>NULL</c>, pszName specifies the icon resource either by name or ordinal. This ordinal must be packaged by
		/// using the <c>MAKEINTRESOURCE</c> macro.
		/// </para>
		/// <para>
		/// If hinst is <c>NULL</c>, pszName specifies either the name of a standalone icon (.ico) file or the identifier of a predefined
		/// icon to load. The following identifiers are recognized. To pass these constants to the <c>LoadIconWithScaleDown</c> function, use
		/// the <c>MAKEINTRESOURCE</c> macro. For example, to load the IDI_ERROR icon, pass as the pszName parameter and <c>NULL</c> as the
		/// hinst parameter.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IDI_APPLICATION</term>
		/// <term>Default application icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_ASTERISK</term>
		/// <term>Same as IDI_INFORMATION.</term>
		/// </item>
		/// <item>
		/// <term>IDI_ERROR</term>
		/// <term>Hand-shaped icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_EXCLAMATION</term>
		/// <term>Same as IDI_WARNING.</term>
		/// </item>
		/// <item>
		/// <term>IDI_HAND</term>
		/// <term>Same as IDI_ERROR.</term>
		/// </item>
		/// <item>
		/// <term>IDI_INFORMATION</term>
		/// <term>Asterisk icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_QUESTION</term>
		/// <term>Question mark icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_WARNING</term>
		/// <term>Exclamation point icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_WINLOGO</term>
		/// <term>Windows logo icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_SHIELD</term>
		/// <term>Security Shield icon.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="cx">
		/// <para>Type: <c>int</c></para>
		/// <para>The desired width, in pixels, of the icon.</para>
		/// </param>
		/// <param name="cy">
		/// <para>Type: <c>int</c></para>
		/// <para>The desired height, in pixels, of the icon.</para>
		/// </param>
		/// <param name="phico">
		/// <para>Type: <c><c>HICON</c>*</c></para>
		/// <para>When this function returns, contains a pointer to the handle of the loaded icon.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>Returns S_OK if successful, or an error value otherwise, including the following:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The contents of the buffer pointed to by pszName do not fit any of the expected interpretations.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT WINAPI LoadIconWithScaleDown( _In_ HINSTANCE hinst, _In_ PCWSTR pszName, _In_ int cx, _In_ int cy, _Out_ HICON *phico); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775703(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775703")]
		public static extern HRESULT LoadIconWithScaleDown(HINSTANCE hinst, string pszName, int cx, int cy, out IntPtr phico);

		/// <summary>Removes a subclass callback from a window.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the window being subclassed.</para>
		/// </param>
		/// <param name="pfnSubclass">
		/// <para>Type: <c><c>SUBCLASSPROC</c></c></para>
		/// <para>
		/// A pointer to a window procedure. This pointer and the subclass ID uniquely identify this subclass callback. For the callback
		/// function prototype, see <c>SUBCLASSPROC</c>.
		/// </para>
		/// </param>
		/// <param name="uIdSubclass">
		/// <para>Type: <c>UINT_PTR</c></para>
		/// <para>
		/// The <c>UINT_PTR</c> subclass ID. This ID and the callback pointer uniquely identify this subclass callback. Note: On 64-bit
		/// versions of Windows this is a 64-bit value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the subclass callback was successfully removed; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// BOOL RemoveWindowSubclass( _In_ HWND hWnd, _In_ SUBCLASSPROC pfnSubclass, _In_ UINT_PTR uIdSubclass); https://msdn.microsoft.com/en-us/library/windows/desktop/bb762094(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb762094")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RemoveWindowSubclass(HWND hWnd, SUBCLASSPROC pfnSubclass, [MarshalAs(UnmanagedType.SysUInt)] uint uIdSubclass);

		/// <summary>Installs or updates a window subclass callback.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the window being subclassed.</para>
		/// </param>
		/// <param name="pfnSubclass">
		/// <para>Type: <c><c>SUBCLASSPROC</c></c></para>
		/// <para>
		/// A pointer to a window procedure. This pointer and the subclass ID uniquely identify this subclass callback. For the callback
		/// function prototype, see <c>SUBCLASSPROC</c>.
		/// </para>
		/// </param>
		/// <param name="uIdSubclass">
		/// <para>Type: <c>UINT_PTR</c></para>
		/// <para>
		/// The subclass ID. This ID together with the subclass procedure uniquely identify a subclass. To remove a subclass, pass the
		/// subclass procedure and this value to the <c>RemoveWindowSubclass</c> function. This value is passed to the subclass procedure in
		/// the uIdSubclass parameter.
		/// </para>
		/// </param>
		/// <param name="dwRefData">
		/// <para>Type: <c>DWORD_PTR</c></para>
		/// <para>
		/// <c>DWORD_PTR</c> to reference data. The meaning of this value is determined by the calling application. This value is passed to
		/// the subclass procedure in the dwRefData parameter. A different dwRefData is associated with each combination of window handle,
		/// subclass procedure and uIdSubclass.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the subclass callback was successfully installed; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// BOOL SetWindowSubclass( _In_ HWND hWnd, _In_ SUBCLASSPROC pfnSubclass, _In_ UINT_PTR uIdSubclass, _In_ DWORD_PTR dwRefData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb762102(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb762102")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetWindowSubclass(HWND hWnd, SUBCLASSPROC pfnSubclass, [MarshalAs(UnmanagedType.SysUInt)] uint uIdSubclass, IntPtr dwRefData);

		/// <summary>
		/// <para>
		/// [ <c>ShowHideMenuCtl</c> is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// Sets or removes the specified menu item's check mark attribute and shows or hides the corresponding control. The function adds a
		/// check mark to the specified menu item if it does not have one and then displays the corresponding control. If the menu item
		/// already has a check mark, the function removes the check mark and hides the corresponding control.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>A handle to the window that contains the menu and controls.</para>
		/// </param>
		/// <param name="uFlags">
		/// <para>Type: <c><c>UINT_PTR</c></c></para>
		/// <para>The identifier of the menu item to receive or lose a check mark.</para>
		/// </param>
		/// <param name="lpInfo">
		/// <para>Type: <c><c>LPINT</c></c></para>
		/// <para>
		/// A pointer to an array that contains pairs of values. The second value in the first pair must be the handle to the application's
		/// main menu. Each subsequent pair consists of a menu item identifier and a control window identifier. The function searches the
		/// array for a value that matches uFlags and, if the value is found, checks or unchecks the menu item and shows or hides the
		/// corresponding control.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </returns>
		// BOOL ShowHideMenuCtl( HWND hWnd, UINT_PTR uFlags, LPINT lpInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775731(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775731")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowHideMenuCtl(HWND hWnd, [MarshalAs(UnmanagedType.SysUInt)] uint uFlags, [In, MarshalAs(UnmanagedType.LPArray)] int[] lpInfo);

		/// <summary>Contains information for the drawing of buttons in a toolbar or rebar.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct COLORSCHEME
		{
			/// <summary>The size of this structure, in bytes.</summary>
			public uint dwSize;

			/// <summary>
			/// The COLORREF value that represents the highlight color of the buttons. Use CLR_DEFAULT for the default highlight color.
			/// </summary>
			public COLORREF clrBtnHighlight;

			/// <summary>The COLORREF value that represents the shadow color of the buttons. Use CLR_DEFAULT for the default shadow color.</summary>
			public COLORREF clrBtnShadow;
		}

		/// <summary>
		/// Carries information used to load common control classes from the dynamic-link library (DLL). This structure is used with the
		/// <see cref="InitCommonControlsEx(in INITCOMMONCONTROLSEX)"/> function.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775507")]
		[StructLayout(LayoutKind.Sequential)]
		public struct INITCOMMONCONTROLSEX
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public int dwSize;

			/// <summary>
			/// The set of bit flags that indicate which common control classes will be loaded from the DLL when calling
			/// <see cref="InitCommonControlsEx(in INITCOMMONCONTROLSEX)"/>.
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

		/// <summary>Contains information used with character notification messages.</summary>
		// typedef struct tagNMCHAR { NMHDR hdr; UINT ch; DWORD dwItemPrev; DWORD dwItemNext;} NMCHAR, *LPNMCHAR; https://msdn.microsoft.com/en-us/library/windows/desktop/bb775508(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775508")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMCHAR
		{
			/// <summary>
			/// <para>Type: <c><c>NMHDR</c></c></para>
			/// <para>An <c>NMHDR</c> structure that contains additional information about this notification.</para>
			/// </summary>
			public NMHDR hdr;

			/// <summary>
			/// <para>Type: <c><c>UINT</c></c></para>
			/// <para>The character that is being processed.</para>
			/// </summary>
			public uint ch;

			/// <summary>
			/// <para>Type: <c><c>DWORD</c></c></para>
			/// <para>A 32-bit value that is determined by the control that is sending the notification.</para>
			/// </summary>
			public uint dwItemPrev;

			/// <summary>
			/// <para>Type: <c><c>DWORD</c></c></para>
			/// <para>A 32-bit value that is determined by the control that is sending the notification.</para>
			/// </summary>
			public uint dwItemNext;
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
			public HDC hdc;

			/// <summary>
			/// The RECT structure that describes the bounding rectangle of the area being drawn. This member is initialized only by the
			/// CDDS_ITEMPREPAINT notification. Version 5.80. This member is also initialized by the CDDS_PREPAINT notification.
			/// </summary>
			public RECT rc;

			/// <summary>
			/// The item number. What is contained in this member will depend on the type of control that is sending the notification. See
			/// the NM_CUSTOMDRAW notification reference for the specific control to determine what, if anything, is contained in this member.
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

		/// <summary>Contains information used with custom text notification.</summary>
		// typedef struct tagNMCUSTOMTEXT { NMHDR hdr; HDC hDC; LPCWSTR lpString; int nCount; LPRECT lpRect; UINT uFormat; BOOL fLink;} NMCUSTOMTEXT,
		// *LPNMCUSTOMTEXT; https://msdn.microsoft.com/en-us/library/windows/desktop/bb775512(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775512")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NMCUSTOMTEXT
		{
			/// <summary>
			/// <para>Type: <c><c>NMHDR</c></c></para>
			/// <para>An <c>NMHDR</c> structure that contains additional information about this notification.</para>
			/// </summary>
			public NMHDR hdr;

			/// <summary>
			/// <para>Type: <c><c>HDC</c></c></para>
			/// <para>The device context to draw to.</para>
			/// </summary>
			public HDC hDC;

			/// <summary>
			/// <para>Type: <c><c>LPCWSTR</c></c></para>
			/// <para>The string to draw.</para>
			/// </summary>
			public string lpString;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Length of lpString.</para>
			/// </summary>
			public int nCount;

			/// <summary>
			/// <para>Type: <c>LPRECT</c></para>
			/// <para>The rect to draw in.</para>
			/// </summary>
			public IntPtr lpRect;

			/// <summary>
			/// <para>Type: <c><c>UINT</c></c></para>
			/// <para>
			/// One or more of the DT_* flags. For more information, see the description of the uFormat parameter of the <c>DrawText</c>
			/// function. This may be <c>NULL</c>.
			/// </para>
			/// </summary>
			public uint uFormat;

			/// <summary>
			/// <para>Type: <c><c>BOOL</c></c></para>
			/// <para>Whether the text is a link.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fLink;
		}

		/// <summary>Contains information used with key notification messages.</summary>
		// typedef struct tagNMKEY { NMHDR hdr; UINT nVKey; UINT uFlags;} NMKEY, *LPNMKEY; https://msdn.microsoft.com/en-us/library/windows/desktop/bb775516(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775516")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMKEY
		{
			/// <summary>
			/// <para>Type: <c><c>NMHDR</c></c></para>
			/// <para>An <c>NMHDR</c> structure that contains additional information about this notification.</para>
			/// </summary>
			public NMHDR hdr;

			/// <summary>
			/// <para>Type: <c><c>UINT</c></c></para>
			/// <para>A virtual key code of the key that caused the event.</para>
			/// </summary>
			public uint nVKey;

			/// <summary>
			/// <para>Type: <c><c>UINT</c></c></para>
			/// <para>
			/// Flags associated with the key. These are the same flags that are passed in the high word of the lParam parameter of the
			/// <c>WM_KEYDOWN</c> message.
			/// </para>
			/// </summary>
			public uint uFlags;
		}

		/// <summary>Contains information used with mouse notification messages.</summary>
		// typedef struct tagNMMOUSE { NMHDR hdr; DWORD_PTR dwItemSpec; DWORD_PTR dwItemData; POINT pt; LPARAM dwHitInfo;} NMMOUSE,
		// *LPNMMOUSE; https://msdn.microsoft.com/en-us/library/windows/desktop/bb775518(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775518")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMMOUSE
		{
			/// <summary>
			/// <para>Type: <c><c>NMHDR</c></c></para>
			/// <para>An <c>NMHDR</c> structure that contains additional information about this notification.</para>
			/// </summary>
			public NMHDR hdr;

			/// <summary>
			/// <para>Type: <c><c>DWORD_PTR</c></c></para>
			/// <para>A control-specific item identifier.</para>
			/// </summary>
			public IntPtr dwItemSpec;

			/// <summary>
			/// <para>Type: <c><c>DWORD_PTR</c></c></para>
			/// <para>A control-specific item data.</para>
			/// </summary>
			public IntPtr dwItemData;

			/// <summary>
			/// <para>Type: <c><c>POINT</c></c></para>
			/// <para>A <c>POINT</c> structure that contains the client coordinates of the mouse when the click occurred.</para>
			/// </summary>
			public System.Drawing.Point pt;

			/// <summary>
			/// <para>Type: <c><c>LPARAM</c></c></para>
			/// <para>Carries information about where on the item or control the cursor is pointing.</para>
			/// </summary>
			public IntPtr dwHitInfo;
		}

		/// <summary>Contains information used with the TBN_GETOBJECT, TCN_GETOBJECT, and PSN_GETOBJECT notification codes.</summary>
		// typedef struct tagNMOBJECTNOTIFY { NMHDR hdr; int iItem; IID *piid; IUnknown *pObject; HRESULT hResult;} NMOBJECTNOTIFY,
		// *LPNMOBJECTNOTIFY; https://msdn.microsoft.com/en-us/library/windows/desktop/bb775520(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775520")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMOBJECTNOTIFY
		{
			/// <summary>
			/// <para>Type: <c><c>NMHDR</c></c></para>
			/// <para>An <c>NMHDR</c> structure that contains additional information about this notification.</para>
			/// </summary>
			public NMHDR hdr;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// A control-specific item identifier. This value will comply to item identification standards for the control sending the
			/// notification. However, this member is not used with the PSN_GETOBJECT notification code.
			/// </para>
			/// </summary>
			public int iItem;

			/// <summary>
			/// <para>Type: <c>IID*</c></para>
			/// <para>A pointer to an interface identifier of the requested object.</para>
			/// </summary>
			public IntPtr piid;

			/// <summary>
			/// <para>Type: <c><c>IUnknown</c>*</c></para>
			/// <para>
			/// A pointer to an object provided by the window processing the notification code. The application processing the notification
			/// code sets this member.
			/// </para>
			/// </summary>
			public IntPtr pObject;

			/// <summary>
			/// <para>Type: <c><c>HRESULT</c></c></para>
			/// <para>COM success or failure flags. The application processing the notification code sets this member.</para>
			/// </summary>
			public HRESULT hResult;

			/// <summary>Undocumented</summary>
			public uint dwFlags;
		}

		/// <summary>Contains information used with NM_TOOLTIPSCREATED notification codes.</summary>
		// typedef struct tagNMTOOLTIPSCREATED { NMHDR hdr; HWND hwndToolTips;} NMTOOLTIPSCREATED, *LPNMTOOLTIPSCREATED; https://msdn.microsoft.com/en-us/library/windows/desktop/bb775522(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775522")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMTOOLTIPSCREATED
		{
			/// <summary>
			/// <para>Type: <c><c>NMHDR</c></c></para>
			/// <para>An <c>NMHDR</c> structure that contains additional information about this notification.</para>
			/// </summary>
			public NMHDR hdr;

			/// <summary>
			/// <para>Type: <c><c>HWND</c></c></para>
			/// <para>The window handle to the tooltip control created.</para>
			/// </summary>
			public HWND hwndToolTips;
		}
	}
}