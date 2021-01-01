using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>The owner-draw required drawing action.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagDRAWITEMSTRUCT")]
		[Flags]
		public enum ODA : uint
		{
			/// <summary>The entire control needs to be drawn.</summary>
			ODA_DRAWENTIRE = 0x0001,

			/// <summary>The selection status has changed. The itemState member should be checked to determine the new selection state.</summary>
			ODA_SELECT = 0x0002,

			/// <summary>
			/// The control has lost or gained the keyboard focus. The itemState member should be checked to determine whether the control
			/// has the focus.
			/// </summary>
			ODA_FOCUS = 0x0004,
		}

		/// <summary>The visual state of the item after the current drawing action takes place.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagDRAWITEMSTRUCT")]
		[Flags]
		public enum ODS : uint
		{
			/// <summary>The menu item's status is selected.</summary>
			ODS_SELECTED = 0x0001,

			/// <summary>The item is to be grayed. This bit is used only in a menu.</summary>
			ODS_GRAYED = 0x0002,

			/// <summary>The item is to be drawn as disabled.</summary>
			ODS_DISABLED = 0x0004,

			/// <summary>The menu item is to be checked. This bit is used only in a menu.</summary>
			ODS_CHECKED = 0x0008,

			/// <summary>The item has the keyboard focus.</summary>
			ODS_FOCUS = 0x0010,

			/// <summary>The item is the default item.</summary>
			ODS_DEFAULT = 0x0020,

			/// <summary>The drawing takes place in the selection field (edit control) of an owner-drawn combo box.</summary>
			ODS_COMBOBOXEDIT = 0x1000,

			/// <summary>The item is being hot-tracked, that is, the item will be highlighted when the mouse is on the item.</summary>
			ODS_HOTLIGHT = 0x0040,

			/// <summary>The item is inactive and the window associated with the menu is inactive.</summary>
			ODS_INACTIVE = 0x0080,

			/// <summary>The control is drawn without the keyboard accelerator cues.</summary>
			ODS_NOACCEL = 0x0100,

			/// <summary>The control is drawn without focus indicator cues.</summary>
			ODS_NOFOCUSRECT = 0x0200,
		}

		/// <summary>The owner-draw control type.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagDRAWITEMSTRUCT")]
		public enum ODT
		{
			/// <summary>Owner-drawn menu item</summary>
			ODT_MENU = 1,

			/// <summary>Owner-drawn list box</summary>
			ODT_LISTBOX = 2,

			/// <summary>Owner-drawn combo box</summary>
			ODT_COMBOBOX = 3,

			/// <summary>Owner-drawn button</summary>
			ODT_BUTTON = 4,

			/// <summary>Owner-drawn static control</summary>
			ODT_STATIC = 5,

			/// <summary>Owner-drawn header</summary>
			ODT_HEADER = 100,

			/// <summary>Tab control</summary>
			ODT_TAB = 101,

			/// <summary>List-view control</summary>
			ODT_LISTVIEW = 102,
		}

		/// <summary>
		/// <para>Supplies the identifiers and application-supplied data for two items in a sorted, owner-drawn list box or combo box.</para>
		/// <para>
		/// Whenever an application adds a new item to an owner-drawn list box or combo box created with the CBS_SORT or LBS_SORT style, the
		/// system sends the owner a WM_COMPAREITEM message. The lParam parameter of the message contains a long pointer to a
		/// <c>COMPAREITEMSTRUCT</c> structure. Upon receiving the message, the owner compares the two items and returns a value indicating
		/// which item sorts before the other.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/ko-kr/windows/win32/api/winuser/ns-winuser-compareitemstruct typedef struct tagCOMPAREITEMSTRUCT {
		// UINT CtlType; UINT CtlID; HWND hwndItem; UINT itemID1; ULONG_PTR itemData1; UINT itemID2; ULONG_PTR itemData2; DWORD dwLocaleId;
		// } COMPAREITEMSTRUCT, *PCOMPAREITEMSTRUCT, *LPCOMPAREITEMSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagCOMPAREITEMSTRUCT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct COMPAREITEMSTRUCT
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>An ODT_LISTBOX (owner-drawn list box) or ODT_COMBOBOX (an owner-drawn combo box).</para>
			/// </summary>
			public ODT CtlType;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The identifier of the list box or combo box.</para>
			/// </summary>
			public uint CtlID;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the control.</para>
			/// </summary>
			public HWND hwndItem;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// The index of the first item in the list box or combo box being compared. This member will be –1 if the item has not been
			/// inserted or when searching for a potential item in the list box or combo box.
			/// </para>
			/// </summary>
			public uint itemID1;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>
			/// Application-supplied data for the first item being compared. (This value was passed as the lParam parameter of the message
			/// that added the item to the list box or combo box.)
			/// </para>
			/// </summary>
			public IntPtr itemData1;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The index of the second item in the list box or combo box being compared.</para>
			/// </summary>
			public uint itemID2;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>
			/// Application-supplied data for the second item being compared. This value was passed as the lParam parameter of the message
			/// that added the item to the list box or combo box. This member will be –1 if the item has not been inserted or when searching
			/// for a potential item in the list box or combo box.
			/// </para>
			/// </summary>
			public IntPtr itemData2;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The locale identifier. To create a locale identifier, use the MAKELCID macro.</para>
			/// </summary>
			public LCID dwLocaleId;
		}

		/// <summary>
		/// <para>
		/// Describes a deleted list box or combo box item. The lParam parameter of a WM_DELETEITEM message contains a pointer to this
		/// structure. When an item is removed from a list box or combo box or when a list box or combo box is destroyed, the system sends
		/// the <c>WM_DELETEITEM</c> message to the owner for each deleted item.
		/// </para>
		/// <para>
		/// The system sends a WM_DELETEITEM message only for items deleted from an owner-drawn list box (with the LBS_OWNERDRAWFIXED or
		/// LBS_OWNERDRAWVARIABLE style) or owner-drawn combo box (with the CBS_OWNERDRAWFIXED or CBS_OWNERDRAWVARIABLE style).
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-deleteitemstruct typedef struct tagDELETEITEMSTRUCT { UINT
		// CtlType; UINT CtlID; UINT itemID; HWND hwndItem; ULONG_PTR itemData; } DELETEITEMSTRUCT, *PDELETEITEMSTRUCT, *LPDELETEITEMSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagDELETEITEMSTRUCT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DELETEITEMSTRUCT
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>Specifies whether the item was deleted from a list box or a combo box. One of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ODT_LISTBOX</term>
			/// <term>A list box.</term>
			/// </item>
			/// <item>
			/// <term>ODT_COMBOBOX</term>
			/// <term>A combo box.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ODT CtlType;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The identifier of the list box or combo box.</para>
			/// </summary>
			public uint CtlID;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The index of the item in the list box or combo box being removed.</para>
			/// </summary>
			public uint itemID;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the control.</para>
			/// </summary>
			public HWND hwndItem;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>
			/// Application-defined data for the item. This value is passed to the control in the lParam parameter of the message that adds
			/// the item to the list box or combo box.
			/// </para>
			/// </summary>
			public IntPtr itemData;
		}

		/// <summary>
		/// Provides information that the owner window uses to determine how to paint an owner-drawn control or menu item. The owner window
		/// of the owner-drawn control or menu item receives a pointer to this structure as the lParam parameter of the WM_DRAWITEM message.
		/// </summary>
		/// <remarks>Some control types, such as status bars, do not set the value of <c>CtlType</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-drawitemstruct typedef struct tagDRAWITEMSTRUCT { UINT
		// CtlType; UINT CtlID; UINT itemID; UINT itemAction; UINT itemState; HWND hwndItem; HDC hDC; RECT rcItem; ULONG_PTR itemData; }
		// DRAWITEMSTRUCT, *PDRAWITEMSTRUCT, *LPDRAWITEMSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagDRAWITEMSTRUCT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DRAWITEMSTRUCT
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The control type. This member can be one of the following values. See Remarks.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ODT_BUTTON</term>
			/// <term>Owner-drawn button</term>
			/// </item>
			/// <item>
			/// <term>ODT_COMBOBOX</term>
			/// <term>Owner-drawn combo box</term>
			/// </item>
			/// <item>
			/// <term>ODT_LISTBOX</term>
			/// <term>Owner-drawn list box</term>
			/// </item>
			/// <item>
			/// <term>ODT_LISTVIEW</term>
			/// <term>List-view control</term>
			/// </item>
			/// <item>
			/// <term>ODT_MENU</term>
			/// <term>Owner-drawn menu item</term>
			/// </item>
			/// <item>
			/// <term>ODT_STATIC</term>
			/// <term>Owner-drawn static control</term>
			/// </item>
			/// <item>
			/// <term>ODT_TAB</term>
			/// <term>Tab control</term>
			/// </item>
			/// </list>
			/// </summary>
			public ODT CtlType;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The identifier of the combo box, list box, button, or static control. This member is not used for a menu item.</para>
			/// </summary>
			public uint CtlID;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// The menu item identifier for a menu item or the index of the item in a list box or combo box. For an empty list box or combo
			/// box, this member can be
			/// <code>-1</code>
			/// . This allows the application to draw only the focus rectangle at the coordinates specified by the <c>rcItem</c> member even
			/// though there are no items in the control. This indicates to the user whether the list box or combo box has the focus. How
			/// the bits are set in the <c>itemAction</c> member determines whether the rectangle is to be drawn as though the list box or
			/// combo box has the focus.
			/// </para>
			/// </summary>
			public uint itemID;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The required drawing action. This member can be one or more of the values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ODA_DRAWENTIRE</term>
			/// <term>The entire control needs to be drawn.</term>
			/// </item>
			/// <item>
			/// <term>ODA_FOCUS</term>
			/// <term>
			/// The control has lost or gained the keyboard focus. The itemState member should be checked to determine whether the control
			/// has the focus.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ODA_SELECT</term>
			/// <term>The selection status has changed. The itemState member should be checked to determine the new selection state.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ODA itemAction;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// The visual state of the item after the current drawing action takes place. This member can be a combination of the values
			/// shown in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ODS_CHECKED</term>
			/// <term>The menu item is to be checked. This bit is used only in a menu.</term>
			/// </item>
			/// <item>
			/// <term>ODS_COMBOBOXEDIT</term>
			/// <term>The drawing takes place in the selection field (edit control) of an owner-drawn combo box.</term>
			/// </item>
			/// <item>
			/// <term>ODS_DEFAULT</term>
			/// <term>The item is the default item.</term>
			/// </item>
			/// <item>
			/// <term>ODS_DISABLED</term>
			/// <term>The item is to be drawn as disabled.</term>
			/// </item>
			/// <item>
			/// <term>ODS_FOCUS</term>
			/// <term>The item has the keyboard focus.</term>
			/// </item>
			/// <item>
			/// <term>ODS_GRAYED</term>
			/// <term>The item is to be grayed. This bit is used only in a menu.</term>
			/// </item>
			/// <item>
			/// <term>ODS_HOTLIGHT</term>
			/// <term>The item is being hot-tracked, that is, the item will be highlighted when the mouse is on the item.</term>
			/// </item>
			/// <item>
			/// <term>ODS_INACTIVE</term>
			/// <term>The item is inactive and the window associated with the menu is inactive.</term>
			/// </item>
			/// <item>
			/// <term>ODS_NOACCEL</term>
			/// <term>The control is drawn without the keyboard accelerator cues.</term>
			/// </item>
			/// <item>
			/// <term>ODS_NOFOCUSRECT</term>
			/// <term>The control is drawn without focus indicator cues.</term>
			/// </item>
			/// <item>
			/// <term>ODS_SELECTED</term>
			/// <term>The menu item's status is selected.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ODS itemState;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// A handle to the control for combo boxes, list boxes, buttons, and static controls. For menus, this member is a handle to the
			/// menu that contains the item.
			/// </para>
			/// </summary>
			public HWND hwndItem;

			/// <summary>
			/// <para>Type: <c>HDC</c></para>
			/// <para>A handle to a device context; this device context must be used when performing drawing operations on the control.</para>
			/// </summary>
			public HDC hDC;

			/// <summary>
			/// <para>Type: <c>RECT</c></para>
			/// <para>
			/// A rectangle that defines the boundaries of the control to be drawn. This rectangle is in the device context specified by the
			/// <c>hDC</c> member. The system automatically clips anything that the owner window draws in the device context for combo
			/// boxes, list boxes, and buttons, but does not clip menu items. When drawing menu items, the owner window must not draw
			/// outside the boundaries of the rectangle defined by the <c>rcItem</c> member.
			/// </para>
			/// </summary>
			public RECT rcItem;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>
			/// The application-defined value associated with the menu item. For a control, this parameter specifies the value last assigned
			/// to the list box or combo box by the LB_SETITEMDATA or CB_SETITEMDATA message. If the list box or combo box has the
			/// LBS_HASSTRINGS or CBS_HASSTRINGS style, this value is initially zero. Otherwise, this value is initially the value that was
			/// passed to the list box or combo box in the lParam parameter of one of the following messages:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>CB_ADDSTRING</term>
			/// </item>
			/// <item>
			/// <term>CB_INSERTSTRING</term>
			/// </item>
			/// <item>
			/// <term>LB_ADDSTRING</term>
			/// </item>
			/// <item>
			/// <term>LB_INSERTSTRING</term>
			/// </item>
			/// </list>
			/// <para>If</para>
			/// <para>CtlType</para>
			/// <para>is</para>
			/// <para>ODT_BUTTON</para>
			/// <para>or</para>
			/// <para>ODT_STATIC</para>
			/// <para>,</para>
			/// <para>itemData</para>
			/// <para>is zero.</para>
			/// </summary>
			public IntPtr itemData;
		}

		/// <summary>
		/// Informs the system of the dimensions of an owner-drawn control or menu item. This allows the system to process user interaction
		/// with the control correctly.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The owner window of an owner-drawn control receives a pointer to the <c>MEASUREITEMSTRUCT</c> structure as the lParam parameter
		/// of a WM_MEASUREITEM message. The owner-drawn control sends this message to its owner window when the control is created. The
		/// owner then fills in the appropriate members in the structure for the control and returns. This structure is common to all
		/// owner-drawn controls except the owner-drawn button control whose size is predetermined by its window.
		/// </para>
		/// <para>
		/// If an application does not fill the appropriate members of <c>MEASUREITEMSTRUCT</c>, the control or menu item may not be drawn properly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-measureitemstruct typedef struct tagMEASUREITEMSTRUCT {
		// UINT CtlType; UINT CtlID; UINT itemID; UINT itemWidth; UINT itemHeight; ULONG_PTR itemData; } MEASUREITEMSTRUCT,
		// *PMEASUREITEMSTRUCT, *LPMEASUREITEMSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagMEASUREITEMSTRUCT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MEASUREITEMSTRUCT
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The control type. This member can be one of the values shown in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ODT_COMBOBOX</term>
			/// <term>Owner-drawn combo box</term>
			/// </item>
			/// <item>
			/// <term>ODT_LISTBOX</term>
			/// <term>Owner-drawn list box</term>
			/// </item>
			/// <item>
			/// <term>ODT_LISTVIEW</term>
			/// <term>Owner-draw list-view control</term>
			/// </item>
			/// <item>
			/// <term>ODT_MENU</term>
			/// <term>Owner-drawn menu</term>
			/// </item>
			/// </list>
			/// </summary>
			public ODT CtlType;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The identifier of the combo box or list box. This member is not used for a menu.</para>
			/// </summary>
			public uint CtlID;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// The identifier for a menu item or the position of a list box or combo box item. This value is specified for a list box only
			/// if it has the LBS_OWNERDRAWVARIABLE style; this value is specified for a combo box only if it has the CBS_OWNERDRAWVARIABLE style.
			/// </para>
			/// </summary>
			public uint itemID;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// The width, in pixels, of a menu item. Before returning from the message, the owner of the owner-drawn menu item must fill
			/// this member.
			/// </para>
			/// </summary>
			public uint itemWidth;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// The height, in pixels, of an individual item in a list box or a menu. Before returning from the message, the owner of the
			/// owner-drawn combo box, list box, or menu item must fill out this member.
			/// </para>
			/// </summary>
			public uint itemHeight;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>
			/// The application-defined value associated with the menu item. For a control, this member specifies the value last assigned to
			/// the list box or combo box by the LB_SETITEMDATA or CB_SETITEMDATA message. If the list box or combo box has the
			/// LB_HASSTRINGS or CB_HASSTRINGS style, this value is initially zero. Otherwise, this value is initially the value passed to
			/// the list box or combo box in the lParam parameter of one of the following messages:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>CB_ADDSTRING</term>
			/// </item>
			/// <item>
			/// <term>CB_INSERTSTRING</term>
			/// </item>
			/// <item>
			/// <term>LB_ADDSTRING</term>
			/// </item>
			/// <item>
			/// <term>LB_INSERTSTRING</term>
			/// </item>
			/// </list>
			/// </summary>
			public IntPtr itemData;
		}
	}
}