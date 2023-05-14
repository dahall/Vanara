using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class User32
{
	/* Menu Commands
	 *
	WM_COMMAND
	WM_CONTEXTMENU
	WM_ENTERMENULOOP
	WM_EXITMENULOOP
	WM_GETTITLEBARINFOEX
	WM_MENUCOMMAND
	WM_MENUDRAG
	WM_MENUGETOBJECT
	WM_MENURBUTTONUP
	WM_NEXTMENU
	WM_UNINITMENUPOPUP
	*/

	/// <summary>Indicates how the GetMenuDefaultItem function should search for menu items.</summary>
	[PInvokeData("winuser.h")]
	public enum GetMenuDefaultItemFlags : uint
	{
		/// <summary>
		/// The function is to return a default item, even if it is disabled. By default, the function skips disabled or grayed items.
		/// </summary>
		GMDI_USEDISABLED = 0x0001,

		/// <summary>
		/// If the default item is one that opens a submenu, the function is to search recursively in the corresponding submenu. If the
		/// submenu has no default item, the return value identifies the item that opens the submenu. By default, the function returns
		/// the first default item on the specified menu, regardless of whether it is an item that opens a submenu.
		/// </summary>
		GMDI_GOINTOPOPUPS = 0x0002
	}

	/// <summary>Flags used by various menu functions.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum MenuFlags : uint
	{
		/// <summary>
		/// Indicates that the uPosition parameter gives the identifier of the menu item. The MF_BYCOMMAND flag is the default if neither
		/// the MF_BYCOMMAND nor MF_BYPOSITION flag is specified.
		/// </summary>
		MF_BYCOMMAND = 0x00000000,

		/// <summary>
		/// Indicates that the uPosition parameter gives the zero-based relative position of the new menu item. If uPosition is -1, the
		/// new menu item is appended to the end of the menu.
		/// </summary>
		MF_BYPOSITION = 0x00000400,

		/// <summary>
		/// Draws a horizontal dividing line. This flag is used only in a drop-down menu, submenu, or shortcut menu. The line cannot be
		/// grayed, disabled, or highlighted. The lpNewItem and uIDNewItem parameters are ignored.
		/// </summary>
		MF_SEPARATOR = 0x00000800,

		/// <summary>Enables the menu item so that it can be selected, and restores it from its grayed state.</summary>
		MF_ENABLED = 0x00000000,

		/// <summary>Disables the menu item and grays it so that it cannot be selected.</summary>
		MF_GRAYED = 0x00000001,

		/// <summary>Disables the menu item so that it cannot be selected, but the flag does not gray it.</summary>
		MF_DISABLED = 0x00000002,

		/// <summary>
		/// Does not place a check mark next to the item (default). If the application supplies check-mark bitmaps (see
		/// SetMenuItemBitmaps), this flag displays the clear bitmap next to the menu item.
		/// </summary>
		MF_UNCHECKED = 0x00000000,

		/// <summary>
		/// Places a check mark next to the menu item. If the application provides check-mark bitmaps (see SetMenuItemBitmaps, this flag
		/// displays the check-mark bitmap next to the menu item.
		/// </summary>
		MF_CHECKED = 0x00000008,

		/// <summary>Undocumented.</summary>
		MF_USECHECKBITMAPS = 0x00000200,

		/// <summary>Specifies that the menu item is a text string; the lpNewItem parameter is a pointer to the string.</summary>
		MF_STRING = 0x00000000,

		/// <summary>Uses a bitmap as the menu item. The lpNewItem parameter contains a handle to the bitmap.</summary>
		MF_BITMAP = 0x00000004,

		/// <summary>
		/// Specifies that the item is an owner-drawn item. Before the menu is displayed for the first time, the window that owns the
		/// menu receives a WM_MEASUREITEM message to retrieve the width and height of the menu item. The WM_DRAWITEM message is then
		/// sent to the window procedure of the owner window whenever the appearance of the menu item must be updated.
		/// </summary>
		MF_OWNERDRAW = 0x00000100,

		/// <summary>
		/// Specifies that the menu item opens a drop-down menu or submenu. The uIDNewItem parameter specifies a handle to the drop-down
		/// menu or submenu. This flag is used to add a menu name to a menu bar, or a menu item that opens a submenu to a drop-down menu,
		/// submenu, or shortcut menu.
		/// </summary>
		MF_POPUP = 0x00000010,

		/// <summary>
		/// Functions the same as the MF_MENUBREAK flag for a menu bar. For a drop-down menu, submenu, or shortcut menu, the new column
		/// is separated from the old column by a vertical line.
		/// </summary>
		MF_MENUBARBREAK = 0x00000020,

		/// <summary>
		/// Places the item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu) without
		/// separating columns.
		/// </summary>
		MF_MENUBREAK = 0x00000040,

		/// <summary>Removes highlighting from the menu item.</summary>
		MF_UNHILITE = 0x00000000,

		/// <summary>Highlights the menu item. If this flag is not specified, the highlighting is removed from the item.</summary>
		MF_HILITE = 0x00000080,

		/// <summary>Undocumented.</summary>
		MF_DEFAULT = 0x00001000,

		/// <summary>
		/// Item is contained in the window menu. The lParam parameter contains a handle to the menu associated with the message.
		/// </summary>
		MF_SYSMENU = 0x00002000,

		/// <summary>Indicates that the menu item has a vertical separator to its left.</summary>
		MF_HELP = 0x00004000,

		/// <summary>Indicates that the menu item has a vertical separator to its left.</summary>
		MF_RIGHTJUSTIFY = 0x00004000,

		/// <summary>Item is selected with the mouse.</summary>
		MF_MOUSESELECT = 0x00008000,

		/// <summary>Undocumented.</summary>
		MF_END = 0x00000080,
	}

	/// <summary>Indicates the members to be retrieved or set (except for MIM_APPLYTOSUBMENUS) in <see cref="MENUINFO.fMask"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "menuinfo.htm")]
	[Flags]
	public enum MenuInfoMember : uint
	{
		/// <summary>
		/// Settings apply to the menu and all of its submenus. SetMenuInfo uses this flag and GetMenuInfo ignores this flag
		/// </summary>
		MIM_APPLYTOSUBMENUS = 0x80000000,

		/// <summary>Retrieves or sets the hbrBack member.</summary>
		MIM_BACKGROUND = 0x00000002,

		/// <summary>Retrieves or sets the dwContextHelpID member.</summary>
		MIM_HELPID = 0x00000004,

		/// <summary>Retrieves or sets the cyMax member.</summary>
		MIM_MAXHEIGHT = 0x00000001,

		/// <summary>Retrieves or sets the dwMenuData member.</summary>
		MIM_MENUDATA = 0x00000008,

		/// <summary>Retrieves or sets the dwStyle member.</summary>
		MIM_STYLE = 0x00000010,
	}

	/// <summary>The menu style use by <see cref="MENUINFO.dwStyle"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "menuinfo.htm")]
	[Flags]
	public enum MenuInfoStyle : uint
	{
		/// <summary>Menu automatically ends when mouse is outside the menu for approximately 10 seconds.</summary>
		MNS_AUTODISMISS = 0x10000000,

		/// <summary>
		/// The same space is reserved for the check mark and the bitmap. If the check mark is drawn, the bitmap is not. All checkmarks
		/// and bitmaps are aligned. Used for menus where some items use checkmarks and some use bitmaps.
		/// </summary>
		MNS_CHECKORBMP = 0x04000000,

		/// <summary>Menu items are OLE drop targets or drag sources. Menu owner receives WM_MENUDRAG and WM_MENUGETOBJECT messages.</summary>
		MNS_DRAGDROP = 0x20000000,

		/// <summary>Menu is modeless; that is, there is no menu modal message loop while the menu is active.</summary>
		MNS_MODELESS = 0x40000000,

		/// <summary>
		/// No space is reserved to the left of an item for a check mark. The item can still be selected, but the check mark will not
		/// appear next to the item.
		/// </summary>
		MNS_NOCHECK = 0x80000000,

		/// <summary>
		/// Menu owner receives a WM_MENUCOMMAND message instead of a WM_COMMAND message when the user makes a selection. MNS_NOTIFYBYPOS
		/// is a menu header style and has no effect when applied to individual sub menus.
		/// </summary>
		MNS_NOTIFYBYPOS = 0x08000000,
	}

	/// <summary>Indicates the members to be retrieved or set in <see cref="MENUITEMINFO"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "menuiteminfo.htm")]
	[Flags]
	public enum MenuItemInfoMask : uint
	{
		/// <summary>Retrieves or sets the fState member.</summary>
		MIIM_STATE = 0x00000001,

		/// <summary>Retrieves or sets the wID member.</summary>
		MIIM_ID = 0x00000002,

		/// <summary>Retrieves or sets the hSubMenu member.</summary>
		MIIM_SUBMENU = 0x00000004,

		/// <summary>Retrieves or sets the hbmpChecked and hbmpUnchecked members.</summary>
		MIIM_CHECKMARKS = 0x00000008,

		/// <summary>
		/// Retrieves or sets the fType and dwTypeData members.
		/// <para>MIIM_TYPE is replaced by MIIM_BITMAP, MIIM_FTYPE, and MIIM_STRING.</para>
		/// </summary>
		MIIM_TYPE = 0x00000010,

		/// <summary>Retrieves or sets the dwItemData member.</summary>
		MIIM_DATA = 0x00000020,

		/// <summary>Retrieves or sets the dwTypeData member.</summary>
		MIIM_STRING = 0x00000040,

		/// <summary>Retrieves or sets the hbmpItem member.</summary>
		MIIM_BITMAP = 0x00000080,

		/// <summary>Retrieves or sets the fType member.</summary>
		MIIM_FTYPE = 0x00000100,
	}

	/// <summary>The menu item state.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "menuiteminfo.htm")]
	[Flags]
	public enum MenuItemState : uint
	{
		/// <summary>Disables the menu item and grays it so that it cannot be selected. This is equivalent to MFS_DISABLED.</summary>
		MFS_GRAYED = 0x00000003,

		/// <summary>Disables the menu item and grays it so that it cannot be selected. This is equivalent to MFS_GRAYED.</summary>
		MFS_DISABLED = MFS_GRAYED,

		/// <summary>Checks the menu item. For more information about selected menu items, see the hbmpChecked member.</summary>
		MFS_CHECKED = MenuFlags.MF_CHECKED,

		/// <summary>Highlights the menu item.</summary>
		MFS_HILITE = MenuFlags.MF_HILITE,

		/// <summary>Enables the menu item so that it can be selected. This is the default state.</summary>
		MFS_ENABLED = MenuFlags.MF_ENABLED,

		/// <summary>Unchecks the menu item. For more information about clear menu items, see the hbmpChecked member.</summary>
		MFS_UNCHECKED = MenuFlags.MF_UNCHECKED,

		/// <summary>Removes the highlight from the menu item. This is the default state.</summary>
		MFS_UNHILITE = MenuFlags.MF_UNHILITE,

		/// <summary>
		/// Specifies that the menu item is the default. A menu can contain only one default menu item, which is displayed in bold.
		/// </summary>
		MFS_DEFAULT = MenuFlags.MF_DEFAULT,
	}

	/// <summary>The menu item type.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "menuiteminfo.htm")]
	[Flags]
	public enum MenuItemType : uint
	{
		/// <summary>
		/// Displays the menu item using a text string. The dwTypeData member is the pointer to a null-terminated string, and the cch
		/// member is the length of the string.
		/// <para>MFT_STRING is replaced by MIIM_STRING.</para>
		/// </summary>
		MFT_STRING = MenuFlags.MF_STRING,

		/// <summary>
		/// Displays the menu item using a bitmap. The low-order word of the dwTypeData member is the bitmap handle, and the cch member
		/// is ignored.
		/// <para>MFT_BITMAP is replaced by MIIM_BITMAP and hbmpItem.</para>
		/// </summary>
		MFT_BITMAP = MenuFlags.MF_BITMAP,

		/// <summary>
		/// Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For
		/// a drop-down menu, submenu, or shortcut menu, a vertical line separates the new column from the old.
		/// </summary>
		MFT_MENUBARBREAK = MenuFlags.MF_MENUBARBREAK,

		/// <summary>
		/// Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For
		/// a drop-down menu, submenu, or shortcut menu, the columns are not separated by a vertical line.
		/// </summary>
		MFT_MENUBREAK = MenuFlags.MF_MENUBREAK,

		/// <summary>
		/// Assigns responsibility for drawing the menu item to the window that owns the menu. The window receives a WM_MEASUREITEM
		/// message before the menu is displayed for the first time, and a WM_DRAWITEM message whenever the appearance of the menu item
		/// must be updated. If this value is specified, the dwTypeData member contains an application-defined value.
		/// </summary>
		MFT_OWNERDRAW = MenuFlags.MF_OWNERDRAW,

		/// <summary>
		/// Displays selected menu items using a radio-button mark instead of a check mark if the hbmpChecked member is NULL.
		/// </summary>
		MFT_RADIOCHECK = 0x00000200,

		/// <summary>
		/// Specifies that the menu item is a separator. A menu item separator appears as a horizontal dividing line. The dwTypeData and
		/// cch members are ignored. This value is valid only in a drop-down menu, submenu, or shortcut menu.
		/// </summary>
		MFT_SEPARATOR = MenuFlags.MF_SEPARATOR,

		/// <summary>
		/// Specifies that menus cascade right-to-left (the default is left-to-right). This is used to support right-to-left languages,
		/// such as Arabic and Hebrew.
		/// </summary>
		MFT_RIGHTORDER = 0x00002000,

		/// <summary>
		/// Right-justifies the menu item and any subsequent items. This value is valid only if the menu item is in a menu bar.
		/// </summary>
		MFT_RIGHTJUSTIFY = MenuFlags.MF_RIGHTJUSTIFY,
	}

	/// <summary>The position of the mouse cursor with respect to the item indicated by MENUGETOBJECTINFO.uPos.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "menugetobjectinfo.htm")]
	public enum MNGOF
	{
		/// <summary>The mouse is on the bottom of the item indicated by uPos.</summary>
		MNGOF_BOTTOMGAP = 0x00000002,

		/// <summary>The mouse is on the top of the item indicated by uPos.</summary>
		MNGOF_TOPGAP = 0x00000001,
	}

	/// <summary>
	/// <para>
	/// Appends a new item to the end of the specified menu bar, drop-down menu, submenu, or shortcut menu. You can use this function to
	/// specify the content, appearance, and behavior of the menu item.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu bar, drop-down menu, submenu, or shortcut menu to be changed.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Controls the appearance and behavior of the new menu item. This parameter can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Uses a bitmap as the menu item. The lpNewItem parameter contains a handle to the bitmap.</term>
	/// </item>
	/// <item>
	/// <term>MF_CHECKED 0x00000008L</term>
	/// <term>
	/// Places a check mark next to the menu item. If the application provides check-mark bitmaps (see SetMenuItemBitmaps, this flag
	/// displays the check-mark bitmap next to the menu item.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_DISABLED 0x00000002L</term>
	/// <term>Disables the menu item so that it cannot be selected, but the flag does not gray it.</term>
	/// </item>
	/// <item>
	/// <term>MF_ENABLED 0x00000000L</term>
	/// <term>Enables the menu item so that it can be selected, and restores it from its grayed state.</term>
	/// </item>
	/// <item>
	/// <term>MF_GRAYED 0x00000001L</term>
	/// <term>Disables the menu item and grays it so that it cannot be selected.</term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBARBREAK 0x00000020L</term>
	/// <term>
	/// Functions the same as the MF_MENUBREAK flag for a menu bar. For a drop-down menu, submenu, or shortcut menu, the new column is
	/// separated from the old column by a vertical line.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBREAK 0x00000040L</term>
	/// <term>
	/// Places the item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu) without
	/// separating columns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Specifies that the item is an owner-drawn item. Before the menu is displayed for the first time, the window that owns the menu
	/// receives a WM_MEASUREITEM message to retrieve the width and height of the menu item. The WM_DRAWITEM message is then sent to the
	/// window procedure of the owner window whenever the appearance of the menu item must be updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_POPUP 0x00000010L</term>
	/// <term>
	/// Specifies that the menu item opens a drop-down menu or submenu. The uIDNewItem parameter specifies a handle to the drop-down menu
	/// or submenu. This flag is used to add a menu name to a menu bar, or a menu item that opens a submenu to a drop-down menu, submenu,
	/// or shortcut menu.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_SEPARATOR 0x00000800L</term>
	/// <term>
	/// Draws a horizontal dividing line. This flag is used only in a drop-down menu, submenu, or shortcut menu. The line cannot be
	/// grayed, disabled, or highlighted. The lpNewItem and uIDNewItem parameters are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Specifies that the menu item is a text string; the lpNewItem parameter is a pointer to the string.</term>
	/// </item>
	/// <item>
	/// <term>MF_UNCHECKED 0x00000000L</term>
	/// <term>
	/// Does not place a check mark next to the item (default). If the application supplies check-mark bitmaps (see SetMenuItemBitmaps),
	/// this flag displays the clear bitmap next to the menu item.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="uIDNewItem">
	/// <para>Type: <c>UINT_PTR</c></para>
	/// <para>
	/// The identifier of the new menu item or, if the uFlags parameter is set to <c>MF_POPUP</c>, a handle to the drop-down menu or submenu.
	/// </para>
	/// </param>
	/// <param name="lpNewItem">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The content of the new menu item. The interpretation of lpNewItem depends on whether the uFlags parameter includes the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Contains a bitmap handle.</term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Contains an application-supplied value that can be used to maintain additional data related to the menu item. The value is in the
	/// itemData member of the structure pointed to by the lParam parameter of the WM_MEASUREITEM or WM_DRAWITEM message sent when the
	/// menu is created or its appearance is updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Contains a pointer to a null-terminated string.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window.</para>
	/// <para>
	/// To get keyboard accelerators to work with bitmap or owner-drawn menu items, the owner of the menu must process the WM_MENUCHAR
	/// message. For more information, see Owner-Drawn Menus and the WM_MENUCHAR Message.
	/// </para>
	/// <para>The following groups of flags cannot be used together:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>MF_BITMAP</c>, <c>MF_STRING</c>, and <c>MF_OWNERDRAW</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_CHECKED</c> and <c>MF_UNCHECKED</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_DISABLED</c>, <c>MF_ENABLED</c>, and <c>MF_GRAYED</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_MENUBARBREAK</c> and <c>MF_MENUBREAK</c></term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Adding Lines and Graphs to a Menu.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-appendmenua BOOL AppendMenuA( HMENU hMenu, UINT uFlags,
	// UINT_PTR uIDNewItem, LPCSTR lpNewItem );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "appendmenu")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AppendMenu(HMENU hMenu, MenuFlags uFlags, IntPtr uIDNewItem, string lpNewItem);

	/// <summary>
	/// <para>
	/// Appends a new item to the end of the specified menu bar, drop-down menu, submenu, or shortcut menu. You can use this function to
	/// specify the content, appearance, and behavior of the menu item.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu bar, drop-down menu, submenu, or shortcut menu to be changed.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Controls the appearance and behavior of the new menu item. This parameter can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Uses a bitmap as the menu item. The lpNewItem parameter contains a handle to the bitmap.</term>
	/// </item>
	/// <item>
	/// <term>MF_CHECKED 0x00000008L</term>
	/// <term>
	/// Places a check mark next to the menu item. If the application provides check-mark bitmaps (see SetMenuItemBitmaps, this flag
	/// displays the check-mark bitmap next to the menu item.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_DISABLED 0x00000002L</term>
	/// <term>Disables the menu item so that it cannot be selected, but the flag does not gray it.</term>
	/// </item>
	/// <item>
	/// <term>MF_ENABLED 0x00000000L</term>
	/// <term>Enables the menu item so that it can be selected, and restores it from its grayed state.</term>
	/// </item>
	/// <item>
	/// <term>MF_GRAYED 0x00000001L</term>
	/// <term>Disables the menu item and grays it so that it cannot be selected.</term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBARBREAK 0x00000020L</term>
	/// <term>
	/// Functions the same as the MF_MENUBREAK flag for a menu bar. For a drop-down menu, submenu, or shortcut menu, the new column is
	/// separated from the old column by a vertical line.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBREAK 0x00000040L</term>
	/// <term>
	/// Places the item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu) without
	/// separating columns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Specifies that the item is an owner-drawn item. Before the menu is displayed for the first time, the window that owns the menu
	/// receives a WM_MEASUREITEM message to retrieve the width and height of the menu item. The WM_DRAWITEM message is then sent to the
	/// window procedure of the owner window whenever the appearance of the menu item must be updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_POPUP 0x00000010L</term>
	/// <term>
	/// Specifies that the menu item opens a drop-down menu or submenu. The uIDNewItem parameter specifies a handle to the drop-down menu
	/// or submenu. This flag is used to add a menu name to a menu bar, or a menu item that opens a submenu to a drop-down menu, submenu,
	/// or shortcut menu.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_SEPARATOR 0x00000800L</term>
	/// <term>
	/// Draws a horizontal dividing line. This flag is used only in a drop-down menu, submenu, or shortcut menu. The line cannot be
	/// grayed, disabled, or highlighted. The lpNewItem and uIDNewItem parameters are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Specifies that the menu item is a text string; the lpNewItem parameter is a pointer to the string.</term>
	/// </item>
	/// <item>
	/// <term>MF_UNCHECKED 0x00000000L</term>
	/// <term>
	/// Does not place a check mark next to the item (default). If the application supplies check-mark bitmaps (see SetMenuItemBitmaps),
	/// this flag displays the clear bitmap next to the menu item.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="uIDNewItem">
	/// <para>Type: <c>UINT_PTR</c></para>
	/// <para>
	/// The identifier of the new menu item or, if the uFlags parameter is set to <c>MF_POPUP</c>, a handle to the drop-down menu or submenu.
	/// </para>
	/// </param>
	/// <param name="lpNewItem">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The content of the new menu item. The interpretation of lpNewItem depends on whether the uFlags parameter includes the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Contains a bitmap handle.</term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Contains an application-supplied value that can be used to maintain additional data related to the menu item. The value is in the
	/// itemData member of the structure pointed to by the lParam parameter of the WM_MEASUREITEM or WM_DRAWITEM message sent when the
	/// menu is created or its appearance is updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Contains a pointer to a null-terminated string.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window.</para>
	/// <para>
	/// To get keyboard accelerators to work with bitmap or owner-drawn menu items, the owner of the menu must process the WM_MENUCHAR
	/// message. For more information, see Owner-Drawn Menus and the WM_MENUCHAR Message.
	/// </para>
	/// <para>The following groups of flags cannot be used together:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>MF_BITMAP</c>, <c>MF_STRING</c>, and <c>MF_OWNERDRAW</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_CHECKED</c> and <c>MF_UNCHECKED</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_DISABLED</c>, <c>MF_ENABLED</c>, and <c>MF_GRAYED</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_MENUBARBREAK</c> and <c>MF_MENUBREAK</c></term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Adding Lines and Graphs to a Menu.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-appendmenua BOOL AppendMenuA( HMENU hMenu, UINT uFlags,
	// UINT_PTR uIDNewItem, LPCSTR lpNewItem );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "appendmenu")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AppendMenu(HMENU hMenu, MenuFlags uFlags, IntPtr uIDNewItem, IntPtr lpNewItem);

	/// <summary>
	/// <para>
	/// [ <c>CheckMenuItem</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. Instead, use SetMenuItemInfo. ]
	/// </para>
	/// <para>Sets the state of the specified menu item's check-mark attribute to either selected or clear.</para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu of interest.</para>
	/// </param>
	/// <param name="uIDCheckItem">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item whose check-mark attribute is to be set, as determined by the uCheck parameter.</para>
	/// </param>
	/// <param name="uCheck">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The flags that control the interpretation of the uIDCheckItem parameter and the state of the menu item's check-mark attribute.
	/// This parameter can be a combination of either <c>MF_BYCOMMAND</c>, or <c>MF_BYPOSITION</c> and <c>MF_CHECKED</c> or <c>MF_UNCHECKED</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that the uIDCheckItem parameter gives the identifier of the menu item. The MF_BYCOMMAND flag is the default, if neither
	/// the MF_BYCOMMAND nor MF_BYPOSITION flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that the uIDCheckItem parameter gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// <item>
	/// <term>MF_CHECKED 0x00000008L</term>
	/// <term>Sets the check-mark attribute to the selected state.</term>
	/// </item>
	/// <item>
	/// <term>MF_UNCHECKED 0x00000000L</term>
	/// <term>Sets the check-mark attribute to the clear state.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The return value specifies the previous state of the menu item (either <c>MF_CHECKED</c> or <c>MF_UNCHECKED</c>). If the menu
	/// item does not exist, the return value is –1.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>An item in a menu bar cannot have a check mark.</para>
	/// <para>
	/// The uIDCheckItem parameter identifies a item that opens a submenu or a command item. For a item that opens a submenu, the
	/// uIDCheckItem parameter must specify the position of the item. For a command item, the uIDCheckItem parameter can specify either
	/// the item's position or its identifier.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Simulating Check Boxes in a Menu.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-checkmenuitem DWORD CheckMenuItem( HMENU hMenu, UINT
	// uIDCheckItem, UINT uCheck );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "checkmenuitem.htm")]
	public static extern uint CheckMenuItem(HMENU hMenu, uint uIDCheckItem, MenuFlags uCheck);

	/// <summary>
	/// <para>
	/// Checks a specified menu item and makes it a radio item. At the same time, the function clears all other menu items in the
	/// associated group and clears the radio-item type flag for those items.
	/// </para>
	/// </summary>
	/// <param name="hmenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu that contains the group of menu items.</para>
	/// </param>
	/// <param name="first">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The identifier or position of the first menu item in the group.</para>
	/// </param>
	/// <param name="last">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The identifier or position of the last menu item in the group.</para>
	/// </param>
	/// <param name="check">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The identifier or position of the menu item to check.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Indicates the meaning of idFirst, idLast, and idCheck. If this parameter is <c>MF_BYCOMMAND</c>, the other parameters specify
	/// menu item identifiers. If it is <c>MF_BYPOSITION</c>, the other parameters specify the menu item positions.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CheckMenuRadioItem</c> function sets the <c>MFT_RADIOCHECK</c> type flag and the <c>MFS_CHECKED</c> state for the item
	/// specified by idCheck and, at the same time, clears both flags for all other items in the group. The selected item is displayed
	/// using a bullet bitmap instead of a check-mark bitmap.
	/// </para>
	/// <para>For more information about menu item type and state flags, see the MENUITEMINFO structure.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Example of Example of Using Custom Checkmark Bitmaps.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-checkmenuradioitem BOOL CheckMenuRadioItem( HMENU hmenu,
	// UINT first, UINT last, UINT check, UINT flags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "checkmenuradioitem.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CheckMenuRadioItem(HMENU hmenu, uint first, uint last, uint check, MenuFlags flags);

	/// <summary>
	/// <para>
	/// Creates a menu. The menu is initially empty, but it can be filled with menu items by using the InsertMenuItem, AppendMenu, and
	/// InsertMenu functions.
	/// </para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>HMENU</c></para>
	/// <para>If the function succeeds, the return value is a handle to the newly created menu.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Resources associated with a menu that is assigned to a window are freed automatically. If the menu is not assigned to a window,
	/// an application must free system resources associated with the menu before closing. An application frees menu resources by calling
	/// the DestroyMenu function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createmenu HMENU CreateMenu( );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "createmenu.htm")]
	public static extern SafeHMENU CreateMenu();

	/// <summary>
	/// <para>
	/// Creates a drop-down menu, submenu, or shortcut menu. The menu is initially empty. You can insert or append menu items by using
	/// the InsertMenuItem function. You can also use the InsertMenu function to insert menu items and the AppendMenu function to append
	/// menu items.
	/// </para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>HMENU</c></para>
	/// <para>If the function succeeds, the return value is a handle to the newly created menu.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The application can add the new menu to an existing menu, or it can display a shortcut menu by calling the TrackPopupMenuEx or
	/// TrackPopupMenu functions.
	/// </para>
	/// <para>
	/// Resources associated with a menu that is assigned to a window are freed automatically. If the menu is not assigned to a window,
	/// an application must free system resources associated with the menu before closing. An application frees menu resources by calling
	/// the DestroyMenu function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Adding Lines and Graphs to a Menu.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createpopupmenu HMENU CreatePopupMenu( );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "createpopupmenu.htm")]
	public static extern SafeHMENU CreatePopupMenu();

	/// <summary>
	/// <para>
	/// Deletes an item from the specified menu. If the menu item opens a menu or submenu, this function destroys the handle to the menu
	/// or submenu and frees the memory used by the menu or submenu.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu to be changed.</para>
	/// </param>
	/// <param name="uPosition">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item to be deleted, as determined by the uFlags parameter.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Indicates how the uPosition parameter is interpreted. This parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that uPosition gives the identifier of the menu item. The MF_BYCOMMAND flag is the default flag if neither the
	/// MF_BYCOMMAND nor MF_BYPOSITION flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that uPosition gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Example of a Clipboard Viewer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-deletemenu BOOL DeleteMenu( HMENU hMenu, UINT uPosition,
	// UINT uFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "deletemenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteMenu(HMENU hMenu, uint uPosition, MenuFlags uFlags);

	/// <summary>
	/// <para>Destroys the specified menu and frees any memory that the menu occupies.</para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu to be destroyed.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before closing, an application must use the <c>DestroyMenu</c> function to destroy a menu not assigned to a window. A menu that
	/// is assigned to a window is automatically destroyed when the application closes.
	/// </para>
	/// <para><c>DestroyMenu</c> is recursive, that is, it will destroy the menu and all its submenus.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Displaying a Shortcut Menu.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-destroymenu BOOL DestroyMenu( HMENU hMenu );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "destroymenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DestroyMenu(HMENU hMenu);

	/// <summary>
	/// <para>
	/// Redraws the menu bar of the specified window. If the menu bar changes after the system has created the window, this function must
	/// be called to draw the changed menu bar.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window whose menu bar is to be redrawn.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawmenubar BOOL DrawMenuBar( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "drawmenubar.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawMenuBar(HWND hWnd);

	/// <summary>
	/// <para>Enables, disables, or grays the specified menu item.</para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu.</para>
	/// </param>
	/// <param name="uIDEnableItem">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The menu item to be enabled, disabled, or grayed, as determined by the uEnable parameter. This parameter specifies an item in a
	/// menu bar, menu, or submenu.
	/// </para>
	/// </param>
	/// <param name="uEnable">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Controls the interpretation of the uIDEnableItem parameter and indicate whether the menu item is enabled, disabled, or grayed.
	/// This parameter must be a combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that uIDEnableItem gives the identifier of the menu item. If neither the MF_BYCOMMAND nor MF_BYPOSITION flag is
	/// specified, the MF_BYCOMMAND flag is the default flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that uIDEnableItem gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// <item>
	/// <term>MF_DISABLED 0x00000002L</term>
	/// <term>Indicates that the menu item is disabled, but not grayed, so it cannot be selected.</term>
	/// </item>
	/// <item>
	/// <term>MF_ENABLED 0x00000000L</term>
	/// <term>Indicates that the menu item is enabled and restored from a grayed state so that it can be selected.</term>
	/// </item>
	/// <item>
	/// <term>MF_GRAYED 0x00000001L</term>
	/// <term>Indicates that the menu item is disabled and grayed so that it cannot be selected.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The return value specifies the previous state of the menu item (it is either <c>MF_DISABLED</c>, <c>MF_ENABLED</c>, or
	/// <c>MF_GRAYED</c>). If the menu item does not exist, the return value is -1.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application must use the <c>MF_BYPOSITION</c> flag to specify the correct menu handle. If the menu handle to the menu bar is
	/// specified, the top-level menu item (an item in the menu bar) is affected. To set the state of an item in a drop-down menu or
	/// submenu by position, an application must specify a handle to the drop-down menu or submenu.
	/// </para>
	/// <para>
	/// When an application specifies the <c>MF_BYCOMMAND</c> flag, the system checks all items that open submenus in the menu identified
	/// by the specified menu handle. Therefore, unless duplicate menu items are present, specifying the menu handle to the menu bar is sufficient.
	/// </para>
	/// <para>
	/// The InsertMenu, InsertMenuItem, LoadMenuIndirect, ModifyMenu, and SetMenuItemInfo functions can also set the state (enabled,
	/// disabled, or grayed) of a menu item.
	/// </para>
	/// <para>When you change a window menu, the menu bar is not immediately updated. To force the update, call DrawMenuBar.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enablemenuitem BOOL EnableMenuItem( HMENU hMenu, UINT
	// uIDEnableItem, UINT uEnable );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "enablemenuitem.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnableMenuItem(HMENU hMenu, uint uIDEnableItem, MenuFlags uEnable);

	/// <summary>
	/// <para>Ends the calling thread's active menu.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>If a platform does not support <c>EndMenu</c>, send the owner of the active menu a WM_CANCELMODE message.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-endmenu BOOL EndMenu( );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "endmenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EndMenu();

	/// <summary>
	/// <para>Retrieves a handle to the menu assigned to the specified window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window whose menu handle is to be retrieved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// The return value is a handle to the menu. If the specified window has no menu, the return value is <c>NULL</c>. If the window is
	/// a child window, the return value is undefined.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GetMenu</c> does not work on floating menu bars. Floating menu bars are custom controls that mimic standard menus; they are
	/// not menus. To get the handle on a floating menu bar, use the Active Accessibility APIs.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Adding Lines and Graphs to a Menu.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenu HMENU GetMenu( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenu.htm")]
	public static extern HMENU GetMenu(HWND hWnd);

	/// <summary>
	/// <para>Retrieves information about the specified menu bar.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window (menu bar) whose information is to be retrieved.</para>
	/// </param>
	/// <param name="idObject">
	/// <para>Type: <c>LONG</c></para>
	/// <para>The menu object. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OBJID_CLIENT ((LONG)0xFFFFFFFC)</term>
	/// <term>The popup menu associated with the window.</term>
	/// </item>
	/// <item>
	/// <term>OBJID_MENU ((LONG)0xFFFFFFFD)</term>
	/// <term>The menu bar associated with the window (see the GetMenu function).</term>
	/// </item>
	/// <item>
	/// <term>OBJID_SYSMENU ((LONG)0xFFFFFFFF)</term>
	/// <term>The system menu associated with the window (see the GetSystemMenu function).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="idItem">
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// The item for which to retrieve information. If this parameter is zero, the function retrieves information about the menu itself.
	/// If this parameter is 1, the function retrieves information about the first item on the menu, and so on.
	/// </para>
	/// </param>
	/// <param name="pmbi">
	/// <para>Type: <c>PMENUBARINFO</c></para>
	/// <para>
	/// A pointer to a MENUBARINFO structure that receives the information. Note that you must set the <c>cbSize</c> member to before
	/// calling this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenubarinfo BOOL GetMenuBarInfo( HWND hwnd, LONG
	// idObject, LONG idItem, PMENUBARINFO pmbi );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenubarinfo.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetMenuBarInfo(HWND hwnd, int idObject, int idItem, ref MENUBARINFO pmbi);

	/// <summary>
	/// <para>
	/// Retrieves the dimensions of the default check-mark bitmap. The system displays this bitmap next to selected menu items. Before
	/// calling the SetMenuItemBitmaps function to replace the default check-mark bitmap for a menu item, an application must determine
	/// the correct bitmap size by calling <c>GetMenuCheckMarkDimensions</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>GetMenuCheckMarkDimensions</c> function is included only for compatibility with 16-bit versions of Windows.
	/// Applications should use the GetSystemMetrics function with the <c>CXMENUCHECK</c> and <c>CYMENUCHECK</c> values to retrieve the
	/// bitmap dimensions.
	/// </para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// The return value specifies the height and width, in pixels, of the default check-mark bitmap. The high-order word contains the
	/// height; the low-order word contains the width.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenucheckmarkdimensions LONG
	// GetMenuCheckMarkDimensions( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenucheckmarkdimensions.htm")]
	public static extern int GetMenuCheckMarkDimensions();

	/// <summary>Retrieves the Help context identifier associated with the specified menu.</summary>
	/// <param name="Arg1">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu for which the Help context identifier is to be retrieved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns the Help context identifier if the menu has one, or zero otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenucontexthelpid DWORD GetMenuContextHelpId( HMENU
	// Arg1 );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "2b8d3e94-6860-4a75-8373-38afb641eb3b")]
	public static extern uint GetMenuContextHelpId(HMENU Arg1);

	/// <summary>
	/// <para>Determines the default menu item on the specified menu.</para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu for which to retrieve the default menu item.</para>
	/// </param>
	/// <param name="fByPos">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Indicates whether to retrieve the menu item's identifier or its position. If this parameter is <c>FALSE</c>, the identifier is
	/// returned. Otherwise, the position is returned.
	/// </para>
	/// </param>
	/// <param name="gmdiFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Indicates how the function should search for menu items. This parameter can be zero or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GMDI_GOINTOPOPUPS 0x0002L</term>
	/// <term>
	/// If the default item is one that opens a submenu, the function is to search recursively in the corresponding submenu. If the
	/// submenu has no default item, the return value identifies the item that opens the submenu. By default, the function returns the
	/// first default item on the specified menu, regardless of whether it is an item that opens a submenu.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GMDI_USEDISABLED 0x0001L</term>
	/// <term>The function is to return a default item, even if it is disabled. By default, the function skips disabled or grayed items.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>If the function succeeds, the return value is the identifier or position of the menu item.</para>
	/// <para>If the function fails, the return value is -1. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenudefaultitem UINT GetMenuDefaultItem( HMENU hMenu,
	// UINT fByPos, UINT gmdiFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenudefaultitem.htm")]
	public static extern uint GetMenuDefaultItem(HMENU hMenu, [MarshalAs(UnmanagedType.Bool)] bool fByPos, GetMenuDefaultItemFlags gmdiFlags);

	/// <summary>
	/// <para>Retrieves information about a specified menu.</para>
	/// </summary>
	/// <param name="hmenu">A handle on a menu.</param>
	/// <param name="lpcmi">
	/// A pointer to a MENUINFO structure containing information for the menu. Note that you must set the cbSize member to
	/// sizeof(MENUINFO) before calling this function.
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenuinfo BOOL GetMenuInfo( HMENU , LPMENUINFO );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenuinfo.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetMenuInfo(HMENU hmenu, ref MENUINFO lpcmi);

	/// <summary>
	/// <para>Determines the number of items in the specified menu.</para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu to be examined.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the function succeeds, the return value specifies the number of items in the menu.</para>
	/// <para>If the function fails, the return value is -1. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenuitemcount int GetMenuItemCount( HMENU hMenu );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenuitemcount.htm")]
	public static extern int GetMenuItemCount(HMENU hMenu);

	/// <summary>
	/// <para>Retrieves the menu item identifier of a menu item located at the specified position in a menu.</para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu that contains the item whose identifier is to be retrieved.</para>
	/// </param>
	/// <param name="nPos">
	/// <para>Type: <c>int</c></para>
	/// <para>The zero-based relative position of the menu item whose identifier is to be retrieved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The return value is the identifier of the specified menu item. If the menu item identifier is <c>NULL</c> or if the specified
	/// item opens a submenu, the return value is -1.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenuitemid UINT GetMenuItemID( HMENU hMenu, int nPos );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenuitemid.htm")]
	public static extern uint GetMenuItemID(HMENU hMenu, int nPos);

	/// <summary>
	/// <para>Retrieves information about a menu item.</para>
	/// </summary>
	/// <param name="hmenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu that contains the menu item.</para>
	/// </param>
	/// <param name="item">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The identifier or position of the menu item to get information about. The meaning of this parameter depends on the value of fByPosition.
	/// </para>
	/// </param>
	/// <param name="fByPosition">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The meaning of uItem. If this parameter is <c>FALSE</c>, uItem is a menu item identifier. Otherwise, it is a menu item position.
	/// See Accessing Menu Items Programmatically for more information.
	/// </para>
	/// </param>
	/// <param name="lpmii">
	/// <para>Type: <c>LPMENUITEMINFO</c></para>
	/// <para>
	/// A pointer to a MENUITEMINFO structure that specifies the information to retrieve and receives information about the menu item.
	/// Note that you must set the <c>cbSize</c> member to before calling this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To retrieve a menu item of type <c>MFT_STRING</c>, first find the size of the string by setting the <c>dwTypeData</c> member of
	/// MENUITEMINFO to <c>NULL</c> and then calling <c>GetMenuItemInfo</c>. The value of <c>cch</c>+1 is the size needed. Then allocate
	/// a buffer of this size, place the pointer to the buffer in <c>dwTypeData</c>, increment <c>cch</c> by one, and then call
	/// <c>GetMenuItemInfo</c> once again to fill the buffer with the string.
	/// </para>
	/// <para>
	/// If the retrieved menu item is of some other type, then <c>GetMenuItemInfo</c> sets the <c>dwTypeData</c> member to a value whose
	/// type is specified by the <c>fType</c><c>fType</c> member and sets <c>cch</c> to 0.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Example of Owner-Drawn Menu Items.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenuiteminfoa BOOL GetMenuItemInfoA( HMENU hmenu, UINT
	// item, BOOL fByPosition, LPMENUITEMINFOA lpmii );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenuiteminfo.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetMenuItemInfo(HMENU hmenu, uint item, [MarshalAs(UnmanagedType.Bool)] bool fByPosition, ref MENUITEMINFO lpmii);

	/// <summary>
	/// <para>Retrieves the bounding rectangle for the specified menu item.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window containing the menu.</para>
	/// <para>If this value is <c>NULL</c> and the hMenu parameter represents a popup menu, the function will find the menu window.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to a menu.</para>
	/// </param>
	/// <param name="uItem">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The zero-based position of the menu item.</para>
	/// </param>
	/// <param name="lprcItem">
	/// <para>Type: <c>LPRECT</c></para>
	/// <para>A pointer to a RECT structure that receives the bounding rectangle of the specified menu item expressed in screen coordinates.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In order for the returned rectangle to be meaningful, the menu must be popped up if a popup menu or attached to a window if a
	/// menu bar. Menu item positions are not determined until the menu is displayed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenuitemrect BOOL GetMenuItemRect( HWND hWnd, HMENU
	// hMenu, UINT uItem, LPRECT lprcItem );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenuitemrect.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetMenuItemRect([Optional] HWND hWnd, HMENU hMenu, uint uItem, out RECT lprcItem);

	/// <summary>
	/// <para>
	/// Retrieves the menu flags associated with the specified menu item. If the menu item opens a submenu, this function also returns
	/// the number of items in the submenu.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>GetMenuState</c> function has been superseded by the GetMenuItemInfo. You can still use <c>GetMenuState</c>,
	/// however, if you do not need any of the extended features of <c>GetMenuItemInfo</c>.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu that contains the menu item whose flags are to be retrieved.</para>
	/// </param>
	/// <param name="uId">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item for which the menu flags are to be retrieved, as determined by the uFlags parameter.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Indicates how the uId parameter is interpreted. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that the uId parameter gives the identifier of the menu item. The MF_BYCOMMAND flag is the default if neither the
	/// MF_BYCOMMAND nor MF_BYPOSITION flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that the uId parameter gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>If the specified item does not exist, the return value is -1.</para>
	/// <para>
	/// If the menu item opens a submenu, the low-order byte of the return value contains the menu flags associated with the item, and
	/// the high-order byte contains the number of items in the submenu opened by the item.
	/// </para>
	/// <para>
	/// Otherwise, the return value is a mask (Bitwise OR) of the menu flags. Following are the menu flags associated with the menu item.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MF_CHECKED 0x00000008L</term>
	/// <term>A check mark is placed next to the item (for drop-down menus, submenus, and shortcut menus only).</term>
	/// </item>
	/// <item>
	/// <term>MF_DISABLED 0x00000002L</term>
	/// <term>The item is disabled.</term>
	/// </item>
	/// <item>
	/// <term>MF_GRAYED 0x00000001L</term>
	/// <term>The item is disabled and grayed.</term>
	/// </item>
	/// <item>
	/// <term>MF_HILITE 0x00000080L</term>
	/// <term>The item is highlighted.</term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBARBREAK 0x00000020L</term>
	/// <term>
	/// This is the same as the MF_MENUBREAK flag, except for drop-down menus, submenus, and shortcut menus, where the new column is
	/// separated from the old column by a vertical line.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBREAK 0x00000040L</term>
	/// <term>
	/// The item is placed on a new line (for menu bars) or in a new column (for drop-down menus, submenus, and shortcut menus) without
	/// separating columns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>The item is owner-drawn.</term>
	/// </item>
	/// <item>
	/// <term>MF_POPUP 0x00000010L</term>
	/// <term>Menu item is a submenu.</term>
	/// </item>
	/// <item>
	/// <term>MF_SEPARATOR 0x00000800L</term>
	/// <term>There is a horizontal dividing line (for drop-down menus, submenus, and shortcut menus only).</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// It is possible to test an item for a flag value of <c>MF_ENABLED</c>, <c>MF_STRING</c>, <c>MF_UNCHECKED</c>, or
	/// <c>MF_UNHILITE</c>. However, since these values equate to zero you must use an expression to test for them.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Expression to test for the flag</term>
	/// </listheader>
	/// <item>
	/// <term>MF_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>MF_STRING</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>MF_UNCHECKED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>MF_UNHILITE</term>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Simulating Check Boxes in a Menu.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenustate UINT GetMenuState( HMENU hMenu, UINT uId,
	// UINT uFlags );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenustate.htm")]
	public static extern uint GetMenuState(HMENU hMenu, uint uId, MenuFlags uFlags);

	/// <summary>
	/// <para>Copies the text string of the specified menu item into the specified buffer.</para>
	/// <para>
	/// <c>Note</c> The <c>GetMenuString</c> function has been superseded. Use the GetMenuItemInfo function to retrieve the menu item text.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu.</para>
	/// </param>
	/// <param name="uIDItem">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item to be changed, as determined by the uFlag parameter.</para>
	/// </param>
	/// <param name="lpString">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// The buffer that receives the null-terminated string. If the string is as long or longer than lpString, the string is truncated
	/// and the terminating null character is added. If lpString is <c>NULL</c>, the function returns the length of the menu string.
	/// </para>
	/// </param>
	/// <param name="cchMax">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The maximum length, in characters, of the string to be copied. If the string is longer than the maximum specified in the
	/// nMaxCount parameter, the extra characters are truncated. If nMaxCount is 0, the function returns the length of the menu string.
	/// </para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Indicates how the uIDItem parameter is interpreted. This parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that uIDItem gives the identifier of the menu item. If neither the MF_BYCOMMAND nor MF_BYPOSITION flag is specified,
	/// the MF_BYCOMMAND flag is the default flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that uIDItem gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// If the function succeeds, the return value specifies the number of characters copied to the buffer, not including the terminating
	/// null character.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>If the specified item is not of type <c>MIIM_STRING</c> or <c>MFT_STRING</c>, then the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The nMaxCount parameter must be one larger than the number of characters in the text string to accommodate the terminating null character.
	/// </para>
	/// <para>If nMaxCount is 0, the function returns the length of the menu string.</para>
	/// <para>Security Warning</para>
	/// <para>
	/// The lpString parameter is a <c>TCHAR</c> buffer, and nMaxCount is the length of the menu string in characters. Sizing these
	/// parameters incorrectly can cause truncation of the string, leading to possible loss of data.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating User Editable Accelerators.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmenustringa int GetMenuStringA( HMENU hMenu, UINT
	// uIDItem, LPSTR lpString, int cchMax, UINT flags );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "getmenustring.htm")]
	public static extern int GetMenuString(HMENU hMenu, uint uIDItem, StringBuilder? lpString, int cchMax, MenuFlags flags);

	/// <summary>
	/// <para>Retrieves a handle to the drop-down menu or submenu activated by the specified menu item.</para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu.</para>
	/// </param>
	/// <param name="nPos">
	/// <para>Type: <c>int</c></para>
	/// <para>The zero-based relative position in the specified menu of an item that activates a drop-down menu or submenu.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// If the function succeeds, the return value is a handle to the drop-down menu or submenu activated by the menu item. If the menu
	/// item does not activate a drop-down menu or submenu, the return value is <c>NULL</c>.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getsubmenu HMENU GetSubMenu( HMENU hMenu, int nPos );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getsubmenu.htm")]
	public static extern HMENU GetSubMenu(HMENU hMenu, int nPos);

	/// <summary>
	/// <para>
	/// Enables the application to access the window menu (also known as the system menu or the control menu) for copying and modifying.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that will own a copy of the window menu.</para>
	/// </param>
	/// <param name="bRevert">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The action to be taken. If this parameter is <c>FALSE</c>, <c>GetSystemMenu</c> returns a handle to the copy of the window menu
	/// currently in use. The copy is initially identical to the window menu, but it can be modified. If this parameter is <c>TRUE</c>,
	/// <c>GetSystemMenu</c> resets the window menu back to the default state. The previous window menu, if any, is destroyed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// If the bRevert parameter is <c>FALSE</c>, the return value is a handle to a copy of the window menu. If the bRevert parameter is
	/// <c>TRUE</c>, the return value is <c>NULL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Any window that does not use the <c>GetSystemMenu</c> function to make its own copy of the window menu receives the standard
	/// window menu.
	/// </para>
	/// <para>
	/// The window menu initially contains items with various identifier values, such as <c>SC_CLOSE</c>, <c>SC_MOVE</c>, and <c>SC_SIZE</c>.
	/// </para>
	/// <para>Menu items on the window menu send WM_SYSCOMMAND messages.</para>
	/// <para>
	/// All predefined window menu items have identifier numbers greater than 0xF000. If an application adds commands to the window menu,
	/// it should use identifier numbers less than 0xF000.
	/// </para>
	/// <para>
	/// The system automatically grays items on the standard window menu, depending on the situation. The application can perform its own
	/// checking or graying by responding to the WM_INITMENU message that is sent before any menu is displayed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getsystemmenu HMENU GetSystemMenu( HWND hWnd, BOOL bRevert );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getsystemmenu.htm")]
	public static extern HMENU GetSystemMenu(HWND hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

	/// <summary>
	/// <para>Adds or removes highlighting from an item in a menu bar.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that contains the menu.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu bar that contains the item.</para>
	/// </param>
	/// <param name="uIDHiliteItem">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The menu item. This parameter is either the identifier of the menu item or the offset of the menu item in the menu bar, depending
	/// on the value of the uHilite parameter.
	/// </para>
	/// </param>
	/// <param name="uHilite">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Controls the interpretation of the uItemHilite parameter and indicates whether the menu item is highlighted. This parameter must
	/// be a combination of either <c>MF_BYCOMMAND</c> or <c>MF_BYPOSITION</c> and <c>MF_HILITE</c> or <c>MF_UNHILITE</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>Indicates that uItemHilite gives the identifier of the menu item.</term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that uItemHilite gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// <item>
	/// <term>MF_HILITE 0x00000080L</term>
	/// <term>Highlights the menu item. If this flag is not specified, the highlighting is removed from the item.</term>
	/// </item>
	/// <item>
	/// <term>MF_UNHILITE 0x00000000L</term>
	/// <term>Removes highlighting from the menu item.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the menu item is set to the specified highlight state, the return value is nonzero.</para>
	/// <para>If the menu item is not set to the specified highlight state, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>MF_HILITE</c> and <c>MF_UNHILITE</c> flags can be used only with the <c>HiliteMenuItem</c> function; they cannot be used
	/// with the ModifyMenu function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-hilitemenuitem BOOL HiliteMenuItem( HWND hWnd, HMENU
	// hMenu, UINT uIDHiliteItem, UINT uHilite );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "hilitemenuitem.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HiliteMenuItem(HWND hWnd, HMENU hMenu, uint uIDHiliteItem, MenuFlags uHilite);

	/// <summary>
	/// <para>Inserts a new menu item into a menu, moving other items down the menu.</para>
	/// <para>
	/// <c>Note</c> The <c>InsertMenu</c> function has been superseded by the InsertMenuItem function. You can still use
	/// <c>InsertMenu</c>, however, if you do not need any of the extended features of <c>InsertMenuItem</c>.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu to be changed.</para>
	/// </param>
	/// <param name="uPosition">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item before which the new menu item is to be inserted, as determined by the uFlags parameter.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Controls the interpretation of the uPosition parameter and the content, appearance, and behavior of the new menu item. This
	/// parameter must include one of the following required values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that the uPosition parameter gives the identifier of the menu item. The MF_BYCOMMAND flag is the default if neither the
	/// MF_BYCOMMAND nor MF_BYPOSITION flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>
	/// Indicates that the uPosition parameter gives the zero-based relative position of the new menu item. If uPosition is -1, the new
	/// menu item is appended to the end of the menu.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The parameter must also include at least one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Uses a bitmap as the menu item. The lpNewItem parameter contains a handle to the bitmap.</term>
	/// </item>
	/// <item>
	/// <term>MF_CHECKED 0x00000008L</term>
	/// <term>
	/// Places a check mark next to the menu item. If the application provides check-mark bitmaps (see SetMenuItemBitmaps), this flag
	/// displays the check-mark bitmap next to the menu item.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_DISABLED 0x00000002L</term>
	/// <term>Disables the menu item so that it cannot be selected, but does not gray it.</term>
	/// </item>
	/// <item>
	/// <term>MF_ENABLED 0x00000000L</term>
	/// <term>Enables the menu item so that it can be selected and restores it from its grayed state.</term>
	/// </item>
	/// <item>
	/// <term>MF_GRAYED 0x00000001L</term>
	/// <term>Disables the menu item and grays it so it cannot be selected.</term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBARBREAK 0x00000020L</term>
	/// <term>
	/// Functions the same as the MF_MENUBREAK flag for a menu bar. For a drop-down menu, submenu, or shortcut menu, the new column is
	/// separated from the old column by a vertical line.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBREAK 0x00000040L</term>
	/// <term>
	/// Places the item on a new line (for menu bars) or in a new column (for a drop-down menu, submenu, or shortcut menu) without
	/// separating columns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Specifies that the item is an owner-drawn item. Before the menu is displayed for the first time, the window that owns the menu
	/// receives a WM_MEASUREITEM message to retrieve the width and height of the menu item. The WM_DRAWITEM message is then sent to the
	/// window procedure of the owner window whenever the appearance of the menu item must be updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_POPUP 0x00000010L</term>
	/// <term>
	/// Specifies that the menu item opens a drop-down menu or submenu. The uIDNewItem parameter specifies a handle to the drop-down menu
	/// or submenu. This flag is used to add a menu name to a menu bar or a menu item that opens a submenu to a drop-down menu, submenu,
	/// or shortcut menu.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_SEPARATOR 0x00000800L</term>
	/// <term>
	/// Draws a horizontal dividing line. This flag is used only in a drop-down menu, submenu, or shortcut menu. The line cannot be
	/// grayed, disabled, or highlighted. The lpNewItem and uIDNewItem parameters are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Specifies that the menu item is a text string; the lpNewItem parameter is a pointer to the string.</term>
	/// </item>
	/// <item>
	/// <term>MF_UNCHECKED 0x00000000L</term>
	/// <term>
	/// Does not place a check mark next to the menu item (default). If the application supplies check-mark bitmaps (see the
	/// SetMenuItemBitmaps function), this flag displays the clear bitmap next to the menu item.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="uIDNewItem">
	/// <para>Type: <c>UINT_PTR</c></para>
	/// <para>
	/// The identifier of the new menu item or, if the uFlags parameter has the <c>MF_POPUP</c> flag set, a handle to the drop-down menu
	/// or submenu.
	/// </para>
	/// </param>
	/// <param name="lpNewItem">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The content of the new menu item. The interpretation of lpNewItem depends on whether the uFlags parameter includes the
	/// <c>MF_BITMAP</c>, <c>MF_OWNERDRAW</c>, or <c>MF_STRING</c> flag, as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Contains a bitmap handle.</term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Contains an application-supplied value that can be used to maintain additional data related to the menu item. The value is in the
	/// itemData member of the structure pointed to by the lParam parameter of the WM_MEASUREITEM or WM_DRAWITEM message sent when the
	/// menu item is created or its appearance is updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Contains a pointer to a null-terminated string (the default).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window.</para>
	/// <para>The following groups of flags cannot be used together:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>MF_BYCOMMAND</c> and <c>MF_BYPOSITION</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_DISABLED</c>, <c>MF_ENABLED</c>, and <c>MF_GRAYED</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_BITMAP</c>, <c>MF_STRING</c>, <c>MF_OWNERDRAW</c>, and <c>MF_SEPARATOR</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_MENUBARBREAK</c> and <c>MF_MENUBREAK</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_CHECKED</c> and <c>MF_UNCHECKED</c></term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-insertmenua BOOL InsertMenuA( HMENU hMenu, UINT uPosition,
	// UINT uFlags, UINT_PTR uIDNewItem, LPCSTR lpNewItem );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "insertmenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InsertMenu(HMENU hMenu, uint uPosition, MenuFlags uFlags, IntPtr uIDNewItem, IntPtr lpNewItem);

	/// <summary>
	/// <para>Inserts a new menu item into a menu, moving other items down the menu.</para>
	/// <para>
	/// <c>Note</c> The <c>InsertMenu</c> function has been superseded by the InsertMenuItem function. You can still use
	/// <c>InsertMenu</c>, however, if you do not need any of the extended features of <c>InsertMenuItem</c>.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu to be changed.</para>
	/// </param>
	/// <param name="uPosition">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item before which the new menu item is to be inserted, as determined by the uFlags parameter.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Controls the interpretation of the uPosition parameter and the content, appearance, and behavior of the new menu item. This
	/// parameter must include one of the following required values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that the uPosition parameter gives the identifier of the menu item. The MF_BYCOMMAND flag is the default if neither the
	/// MF_BYCOMMAND nor MF_BYPOSITION flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>
	/// Indicates that the uPosition parameter gives the zero-based relative position of the new menu item. If uPosition is -1, the new
	/// menu item is appended to the end of the menu.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The parameter must also include at least one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Uses a bitmap as the menu item. The lpNewItem parameter contains a handle to the bitmap.</term>
	/// </item>
	/// <item>
	/// <term>MF_CHECKED 0x00000008L</term>
	/// <term>
	/// Places a check mark next to the menu item. If the application provides check-mark bitmaps (see SetMenuItemBitmaps), this flag
	/// displays the check-mark bitmap next to the menu item.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_DISABLED 0x00000002L</term>
	/// <term>Disables the menu item so that it cannot be selected, but does not gray it.</term>
	/// </item>
	/// <item>
	/// <term>MF_ENABLED 0x00000000L</term>
	/// <term>Enables the menu item so that it can be selected and restores it from its grayed state.</term>
	/// </item>
	/// <item>
	/// <term>MF_GRAYED 0x00000001L</term>
	/// <term>Disables the menu item and grays it so it cannot be selected.</term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBARBREAK 0x00000020L</term>
	/// <term>
	/// Functions the same as the MF_MENUBREAK flag for a menu bar. For a drop-down menu, submenu, or shortcut menu, the new column is
	/// separated from the old column by a vertical line.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBREAK 0x00000040L</term>
	/// <term>
	/// Places the item on a new line (for menu bars) or in a new column (for a drop-down menu, submenu, or shortcut menu) without
	/// separating columns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Specifies that the item is an owner-drawn item. Before the menu is displayed for the first time, the window that owns the menu
	/// receives a WM_MEASUREITEM message to retrieve the width and height of the menu item. The WM_DRAWITEM message is then sent to the
	/// window procedure of the owner window whenever the appearance of the menu item must be updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_POPUP 0x00000010L</term>
	/// <term>
	/// Specifies that the menu item opens a drop-down menu or submenu. The uIDNewItem parameter specifies a handle to the drop-down menu
	/// or submenu. This flag is used to add a menu name to a menu bar or a menu item that opens a submenu to a drop-down menu, submenu,
	/// or shortcut menu.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_SEPARATOR 0x00000800L</term>
	/// <term>
	/// Draws a horizontal dividing line. This flag is used only in a drop-down menu, submenu, or shortcut menu. The line cannot be
	/// grayed, disabled, or highlighted. The lpNewItem and uIDNewItem parameters are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Specifies that the menu item is a text string; the lpNewItem parameter is a pointer to the string.</term>
	/// </item>
	/// <item>
	/// <term>MF_UNCHECKED 0x00000000L</term>
	/// <term>
	/// Does not place a check mark next to the menu item (default). If the application supplies check-mark bitmaps (see the
	/// SetMenuItemBitmaps function), this flag displays the clear bitmap next to the menu item.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="uIDNewItem">
	/// <para>Type: <c>UINT_PTR</c></para>
	/// <para>
	/// The identifier of the new menu item or, if the uFlags parameter has the <c>MF_POPUP</c> flag set, a handle to the drop-down menu
	/// or submenu.
	/// </para>
	/// </param>
	/// <param name="lpNewItem">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The content of the new menu item. The interpretation of lpNewItem depends on whether the uFlags parameter includes the
	/// <c>MF_BITMAP</c>, <c>MF_OWNERDRAW</c>, or <c>MF_STRING</c> flag, as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Contains a bitmap handle.</term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Contains an application-supplied value that can be used to maintain additional data related to the menu item. The value is in the
	/// itemData member of the structure pointed to by the lParam parameter of the WM_MEASUREITEM or WM_DRAWITEM message sent when the
	/// menu item is created or its appearance is updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Contains a pointer to a null-terminated string (the default).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window.</para>
	/// <para>The following groups of flags cannot be used together:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>MF_BYCOMMAND</c> and <c>MF_BYPOSITION</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_DISABLED</c>, <c>MF_ENABLED</c>, and <c>MF_GRAYED</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_BITMAP</c>, <c>MF_STRING</c>, <c>MF_OWNERDRAW</c>, and <c>MF_SEPARATOR</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_MENUBARBREAK</c> and <c>MF_MENUBREAK</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_CHECKED</c> and <c>MF_UNCHECKED</c></term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-insertmenua BOOL InsertMenuA( HMENU hMenu, UINT uPosition,
	// UINT uFlags, UINT_PTR uIDNewItem, LPCSTR lpNewItem );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "insertmenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InsertMenu(HMENU hMenu, uint uPosition, MenuFlags uFlags, IntPtr uIDNewItem, string lpNewItem);

	/// <summary>
	/// <para>Inserts a new menu item at the specified position in a menu.</para>
	/// </summary>
	/// <param name="hmenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu in which the new menu item is inserted.</para>
	/// </param>
	/// <param name="item">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The identifier or position of the menu item before which to insert the new item. The meaning of this parameter depends on the
	/// value of fByPosition.
	/// </para>
	/// </param>
	/// <param name="fByPosition">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Controls the meaning of uItem. If this parameter is <c>FALSE</c>, uItem is a menu item identifier. Otherwise, it is a menu item
	/// position. See Accessing Menu Items Programmatically for more information.
	/// </para>
	/// </param>
	/// <param name="lpmi">
	/// <para>Type: <c>LPCMENUITEMINFO</c></para>
	/// <para>A pointer to a MENUITEMINFO structure that contains information about the new menu item.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window.</para>
	/// <para>
	/// In order for keyboard accelerators to work with bitmap or owner-drawn menu items, the owner of the menu must process the
	/// WM_MENUCHAR message. See Owner-Drawn Menus and the WM_MENUCHAR Message for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Example of Menu-Item Bitmaps.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-insertmenuitema BOOL InsertMenuItemA( HMENU hmenu, UINT
	// item, BOOL fByPosition, LPCMENUITEMINFOA lpmi );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "insertmenuitem.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InsertMenuItem(HMENU hmenu, uint item, [MarshalAs(UnmanagedType.Bool)] bool fByPosition, ref MENUITEMINFO lpmi);

	/// <summary>
	/// <para>Determines whether a handle is a menu handle.</para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to be tested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the handle is a menu handle, the return value is nonzero.</para>
	/// <para>If the handle is not a menu handle, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-ismenu BOOL IsMenu( HMENU hMenu );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "ismenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsMenu(HMENU hMenu);

	/// <summary>
	/// <para>Loads the specified menu resource from the executable (.exe) file associated with an application instance.</para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module containing the menu resource to be loaded.</para>
	/// </param>
	/// <param name="lpMenuName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the menu resource. Alternatively, this parameter can consist of the resource identifier in the low-order word and
	/// zero in the high-order word. To create this value, use the MAKEINTRESOURCE macro.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HMENU</c></para>
	/// <para>If the function succeeds, the return value is a handle to the menu resource.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The DestroyMenu function is used, before an application closes, to destroy the menu and free memory that the loaded menu occupied.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Displaying a Shortcut Menu</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadmenua HMENU LoadMenuA( HINSTANCE hInstance, LPCSTR
	// lpMenuName );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "loadmenu.htm")]
	public static extern SafeHMENU LoadMenu(HINSTANCE hInstance, SafeResourceId lpMenuName);

	/// <summary>
	/// <para>Loads the specified menu template in memory.</para>
	/// </summary>
	/// <param name="lpMenuTemplate">
	/// <para>Type: <c>const MENUTEMPLATE*</c></para>
	/// <para>
	/// A pointer to a menu template or an extended menu template. A menu template consists of a MENUITEMTEMPLATEHEADER structure
	/// followed by one or more contiguous MENUITEMTEMPLATE structures. An extended menu template consists of a MENUEX_TEMPLATE_HEADER
	/// structure followed by one or more contiguous MENUEX_TEMPLATE_ITEM structures.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HMENU</c></para>
	/// <para>If the function succeeds, the return value is a handle to the menu.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For both the ANSI and the Unicode version of this function, the strings in the MENUITEMTEMPLATE structure must be Unicode strings.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadmenuindirecta HMENU LoadMenuIndirectA( CONST
	// MENUTEMPLATEA *lpMenuTemplate );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "loadmenuindirect.htm")]
	public static extern SafeHMENU LoadMenuIndirect(IntPtr lpMenuTemplate);

	/// <summary>
	/// <para>Determines which menu item, if any, is at the specified location.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window containing the menu. If this value is <c>NULL</c> and the hMenu parameter represents a popup menu, the
	/// function will find the menu window.
	/// </para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu containing the menu items to hit test.</para>
	/// </param>
	/// <param name="ptScreen">
	/// <para>Type: <c>POINT</c></para>
	/// <para>
	/// A structure that specifies the location to test. If hMenu specifies a menu bar, this parameter is in window coordinates.
	/// Otherwise, it is in client coordinates.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the zero-based position of the menu item at the specified location or -1 if no menu item is at the specified location.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-menuitemfrompoint int MenuItemFromPoint( HWND hWnd, HMENU
	// hMenu, POINT ptScreen );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "menuitemfrompoint.htm")]
	public static extern int MenuItemFromPoint([Optional] HWND hWnd, HMENU hMenu, POINT ptScreen);

	/// <summary>
	/// <para>Changes an existing menu item. This function is used to specify the content, appearance, and behavior of the menu item.</para>
	/// <para>
	/// <c>Note</c> The <c>ModifyMenu</c> function has been superseded by the SetMenuItemInfo function. You can still use
	/// <c>ModifyMenu</c>, however, if you do not need any of the extended features of <c>SetMenuItemInfo</c>.
	/// </para>
	/// </summary>
	/// <param name="hMnu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu to be changed.</para>
	/// </param>
	/// <param name="uPosition">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item to be changed, as determined by the uFlags parameter.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Controls the interpretation of the uPosition parameter and the content, appearance, and behavior of the menu item. This parameter
	/// must include one of the following required values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that the uPosition parameter gives the identifier of the menu item. The MF_BYCOMMAND flag is the default if neither the
	/// MF_BYCOMMAND nor MF_BYPOSITION flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that the uPosition parameter gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// </list>
	/// <para>The parameter must also include at least one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Uses a bitmap as the menu item. The lpNewItem parameter contains a handle to the bitmap.</term>
	/// </item>
	/// <item>
	/// <term>MF_CHECKED 0x00000008L</term>
	/// <term>
	/// Places a check mark next to the item. If your application provides check-mark bitmaps (see the SetMenuItemBitmaps function), this
	/// flag displays a selected bitmap next to the menu item.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_DISABLED 0x00000002L</term>
	/// <term>Disables the menu item so that it cannot be selected, but this flag does not gray it.</term>
	/// </item>
	/// <item>
	/// <term>MF_ENABLED 0x00000000L</term>
	/// <term>Enables the menu item so that it can be selected and restores it from its grayed state.</term>
	/// </item>
	/// <item>
	/// <term>MF_GRAYED 0x00000001L</term>
	/// <term>Disables the menu item and grays it so that it cannot be selected.</term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBARBREAK 0x00000020L</term>
	/// <term>
	/// Functions the same as the MF_MENUBREAK flag for a menu bar. For a drop-down menu, submenu, or shortcut menu, the new column is
	/// separated from the old column by a vertical line.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBREAK 0x00000040L</term>
	/// <term>
	/// Places the item on a new line (for menu bars) or in a new column (for a drop-down menu, submenu, or shortcut menu) without
	/// separating columns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Specifies that the item is an owner-drawn item. Before the menu is displayed for the first time, the window that owns the menu
	/// receives a WM_MEASUREITEM message to retrieve the width and height of the menu item. The WM_DRAWITEM message is then sent to the
	/// window procedure of the owner window whenever the appearance of the menu item must be updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_POPUP 0x00000010L</term>
	/// <term>
	/// Specifies that the menu item opens a drop-down menu or submenu. The uIDNewItem parameter specifies a handle to the drop-down menu
	/// or submenu. This flag is used to add a menu name to a menu bar or a menu item that opens a submenu to a drop-down menu, submenu,
	/// or shortcut menu.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_SEPARATOR 0x00000800L</term>
	/// <term>
	/// Draws a horizontal dividing line. This flag is used only in a drop-down menu, submenu, or shortcut menu. The line cannot be
	/// grayed, disabled, or highlighted. The lpNewItem and uIDNewItem parameters are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Specifies that the menu item is a text string; the lpNewItem parameter is a pointer to the string.</term>
	/// </item>
	/// <item>
	/// <term>MF_UNCHECKED 0x00000000L</term>
	/// <term>
	/// Does not place a check mark next to the item (the default). If your application supplies check-mark bitmaps (see the
	/// SetMenuItemBitmaps function), this flag displays a clear bitmap next to the menu item.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="uIDNewItem">
	/// <para>Type: <c>UINT_PTR</c></para>
	/// <para>
	/// The identifier of the modified menu item or, if the uFlags parameter has the <c>MF_POPUP</c> flag set, a handle to the drop-down
	/// menu or submenu.
	/// </para>
	/// </param>
	/// <param name="lpNewItem">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The contents of the changed menu item. The interpretation of this parameter depends on whether the uFlags parameter includes the
	/// <c>MF_BITMAP</c>, <c>MF_OWNERDRAW</c>, or <c>MF_STRING</c> flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>A bitmap handle.</term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// A value supplied by an application that is used to maintain additional data related to the menu item. The value is in the
	/// itemData member of the structure pointed to by the lParam parameter of the WM_MEASUREITEM or WM_DRAWITEM messages sent when the
	/// menu item is created or its appearance is updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>A pointer to a null-terminated string (the default).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <c>ModifyMenu</c> replaces a menu item that opens a drop-down menu or submenu, the function destroys the old drop-down menu or
	/// submenu and frees the memory used by it.
	/// </para>
	/// <para>
	/// In order for keyboard accelerators to work with bitmap or owner-drawn menu items, the owner of the menu must process the
	/// WM_MENUCHAR message. See Owner-Drawn Menus and the WM_MENUCHAR Message for more information.
	/// </para>
	/// <para>
	/// The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window. To change
	/// the attributes of existing menu items, it is much faster to use the CheckMenuItem and EnableMenuItem functions.
	/// </para>
	/// <para>The following groups of flags cannot be used together:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>MF_BYCOMMAND</c> and <c>MF_BYPOSITION</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_DISABLED</c>, <c>MF_ENABLED</c>, and <c>MF_GRAYED</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_BITMAP</c>, <c>MF_STRING</c>, <c>MF_OWNERDRAW</c>, and <c>MF_SEPARATOR</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_MENUBARBREAK</c> and <c>MF_MENUBREAK</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_CHECKED</c> and <c>MF_UNCHECKED</c></term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Setting Fonts for Menu-Item Text Strings.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-modifymenua BOOL ModifyMenuA( HMENU hMnu, UINT uPosition,
	// UINT uFlags, UINT_PTR uIDNewItem, LPCSTR lpNewItem );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "modifymenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ModifyMenu(HMENU hMnu, uint uPosition, MenuFlags uFlags, IntPtr uIDNewItem, IntPtr lpNewItem);

	/// <summary>
	/// <para>Changes an existing menu item. This function is used to specify the content, appearance, and behavior of the menu item.</para>
	/// <para>
	/// <c>Note</c> The <c>ModifyMenu</c> function has been superseded by the SetMenuItemInfo function. You can still use
	/// <c>ModifyMenu</c>, however, if you do not need any of the extended features of <c>SetMenuItemInfo</c>.
	/// </para>
	/// </summary>
	/// <param name="hMnu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu to be changed.</para>
	/// </param>
	/// <param name="uPosition">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item to be changed, as determined by the uFlags parameter.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Controls the interpretation of the uPosition parameter and the content, appearance, and behavior of the menu item. This parameter
	/// must include one of the following required values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that the uPosition parameter gives the identifier of the menu item. The MF_BYCOMMAND flag is the default if neither the
	/// MF_BYCOMMAND nor MF_BYPOSITION flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that the uPosition parameter gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// </list>
	/// <para>The parameter must also include at least one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>Uses a bitmap as the menu item. The lpNewItem parameter contains a handle to the bitmap.</term>
	/// </item>
	/// <item>
	/// <term>MF_CHECKED 0x00000008L</term>
	/// <term>
	/// Places a check mark next to the item. If your application provides check-mark bitmaps (see the SetMenuItemBitmaps function), this
	/// flag displays a selected bitmap next to the menu item.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_DISABLED 0x00000002L</term>
	/// <term>Disables the menu item so that it cannot be selected, but this flag does not gray it.</term>
	/// </item>
	/// <item>
	/// <term>MF_ENABLED 0x00000000L</term>
	/// <term>Enables the menu item so that it can be selected and restores it from its grayed state.</term>
	/// </item>
	/// <item>
	/// <term>MF_GRAYED 0x00000001L</term>
	/// <term>Disables the menu item and grays it so that it cannot be selected.</term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBARBREAK 0x00000020L</term>
	/// <term>
	/// Functions the same as the MF_MENUBREAK flag for a menu bar. For a drop-down menu, submenu, or shortcut menu, the new column is
	/// separated from the old column by a vertical line.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_MENUBREAK 0x00000040L</term>
	/// <term>
	/// Places the item on a new line (for menu bars) or in a new column (for a drop-down menu, submenu, or shortcut menu) without
	/// separating columns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// Specifies that the item is an owner-drawn item. Before the menu is displayed for the first time, the window that owns the menu
	/// receives a WM_MEASUREITEM message to retrieve the width and height of the menu item. The WM_DRAWITEM message is then sent to the
	/// window procedure of the owner window whenever the appearance of the menu item must be updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_POPUP 0x00000010L</term>
	/// <term>
	/// Specifies that the menu item opens a drop-down menu or submenu. The uIDNewItem parameter specifies a handle to the drop-down menu
	/// or submenu. This flag is used to add a menu name to a menu bar or a menu item that opens a submenu to a drop-down menu, submenu,
	/// or shortcut menu.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_SEPARATOR 0x00000800L</term>
	/// <term>
	/// Draws a horizontal dividing line. This flag is used only in a drop-down menu, submenu, or shortcut menu. The line cannot be
	/// grayed, disabled, or highlighted. The lpNewItem and uIDNewItem parameters are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>Specifies that the menu item is a text string; the lpNewItem parameter is a pointer to the string.</term>
	/// </item>
	/// <item>
	/// <term>MF_UNCHECKED 0x00000000L</term>
	/// <term>
	/// Does not place a check mark next to the item (the default). If your application supplies check-mark bitmaps (see the
	/// SetMenuItemBitmaps function), this flag displays a clear bitmap next to the menu item.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="uIDNewItem">
	/// <para>Type: <c>UINT_PTR</c></para>
	/// <para>
	/// The identifier of the modified menu item or, if the uFlags parameter has the <c>MF_POPUP</c> flag set, a handle to the drop-down
	/// menu or submenu.
	/// </para>
	/// </param>
	/// <param name="lpNewItem">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The contents of the changed menu item. The interpretation of this parameter depends on whether the uFlags parameter includes the
	/// <c>MF_BITMAP</c>, <c>MF_OWNERDRAW</c>, or <c>MF_STRING</c> flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BITMAP 0x00000004L</term>
	/// <term>A bitmap handle.</term>
	/// </item>
	/// <item>
	/// <term>MF_OWNERDRAW 0x00000100L</term>
	/// <term>
	/// A value supplied by an application that is used to maintain additional data related to the menu item. The value is in the
	/// itemData member of the structure pointed to by the lParam parameter of the WM_MEASUREITEM or WM_DRAWITEM messages sent when the
	/// menu item is created or its appearance is updated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_STRING 0x00000000L</term>
	/// <term>A pointer to a null-terminated string (the default).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <c>ModifyMenu</c> replaces a menu item that opens a drop-down menu or submenu, the function destroys the old drop-down menu or
	/// submenu and frees the memory used by it.
	/// </para>
	/// <para>
	/// In order for keyboard accelerators to work with bitmap or owner-drawn menu items, the owner of the menu must process the
	/// WM_MENUCHAR message. See Owner-Drawn Menus and the WM_MENUCHAR Message for more information.
	/// </para>
	/// <para>
	/// The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window. To change
	/// the attributes of existing menu items, it is much faster to use the CheckMenuItem and EnableMenuItem functions.
	/// </para>
	/// <para>The following groups of flags cannot be used together:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>MF_BYCOMMAND</c> and <c>MF_BYPOSITION</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_DISABLED</c>, <c>MF_ENABLED</c>, and <c>MF_GRAYED</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_BITMAP</c>, <c>MF_STRING</c>, <c>MF_OWNERDRAW</c>, and <c>MF_SEPARATOR</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_MENUBARBREAK</c> and <c>MF_MENUBREAK</c></term>
	/// </item>
	/// <item>
	/// <term><c>MF_CHECKED</c> and <c>MF_UNCHECKED</c></term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Setting Fonts for Menu-Item Text Strings.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-modifymenua BOOL ModifyMenuA( HMENU hMnu, UINT uPosition,
	// UINT uFlags, UINT_PTR uIDNewItem, LPCSTR lpNewItem );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "modifymenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ModifyMenu(HMENU hMnu, uint uPosition, MenuFlags uFlags, IntPtr uIDNewItem, string lpNewItem);

	/// <summary>
	/// <para>
	/// Deletes a menu item or detaches a submenu from the specified menu. If the menu item opens a drop-down menu or submenu,
	/// <c>RemoveMenu</c> does not destroy the menu or its handle, allowing the menu to be reused. Before this function is called, the
	/// GetSubMenu function should retrieve a handle to the drop-down menu or submenu.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu to be changed.</para>
	/// </param>
	/// <param name="uPosition">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item to be deleted, as determined by the uFlags parameter.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Indicates how the uPosition parameter is interpreted. This parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that uPosition gives the identifier of the menu item. If neither the MF_BYCOMMAND nor MF_BYPOSITION flag is specified,
	/// the MF_BYCOMMAND flag is the default flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that uPosition gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-removemenu BOOL RemoveMenu( HMENU hMenu, UINT uPosition,
	// UINT uFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "removemenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RemoveMenu(HMENU hMenu, uint uPosition, MenuFlags uFlags);

	/// <summary>
	/// <para>Assigns a new menu to the specified window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to which the menu is to be assigned.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the new menu. If this parameter is <c>NULL</c>, the window's current menu is removed.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The window is redrawn to reflect the menu change. A menu can be assigned to any window that is not a child window.</para>
	/// <para>
	/// The <c>SetMenu</c> function replaces the previous menu, if any, but it does not destroy it. An application should call the
	/// DestroyMenu function to accomplish this task.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setmenu BOOL SetMenu( HWND hWnd, HMENU hMenu );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setmenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetMenu(HWND hWnd, [Optional] HMENU hMenu);

	/// <summary>Associates a Help context identifier with a menu.</summary>
	/// <param name="arg1">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu with which to associate the Help context identifier.</para>
	/// </param>
	/// <param name="arg2">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The help context identifier.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns nonzero if successful, or zero otherwise.</para>
	/// <para>To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>All items in the menu share this identifier. Help context identifiers can't be attached to individual menu items.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setmenucontexthelpid
	// BOOL SetMenuContextHelpId( HMENU , DWORD );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "55d944db-d889-468a-991a-b9779c90b44f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetMenuContextHelpId(HMENU arg1, uint arg2);

	/// <summary>
	/// <para>Sets the default menu item for the specified menu.</para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu to set the default item for.</para>
	/// </param>
	/// <param name="uItem">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The identifier or position of the new default menu item or -1 for no default item. The meaning of this parameter depends on the
	/// value of fByPos.
	/// </para>
	/// </param>
	/// <param name="fByPos">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The meaning of uItem. If this parameter is <c>FALSE</c>, uItem is a menu item identifier. Otherwise, it is a menu item position.
	/// See About Menus for more information.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setmenudefaultitem BOOL SetMenuDefaultItem( HMENU hMenu,
	// UINT uItem, UINT fByPos );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setmenudefaultitem.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetMenuDefaultItem(HMENU hMenu, uint uItem, [MarshalAs(UnmanagedType.Bool)] bool fByPos);

	/// <summary>
	/// <para>Sets information for a specified menu.</para>
	/// </summary>
	/// <param name="hMenu">A handle to a menu.</param>
	/// <param name="lpcmi">A pointer to a MENUINFO structure for the menu.</param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setmenuinfo BOOL SetMenuInfo( HMENU , LPCMENUINFO );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setmenuinfo.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetMenuInfo(HMENU hMenu, in MENUINFO lpcmi);

	/// <summary>
	/// <para>
	/// Associates the specified bitmap with a menu item. Whether the menu item is selected or clear, the system displays the appropriate
	/// bitmap next to the menu item.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu containing the item to receive new check-mark bitmaps.</para>
	/// </param>
	/// <param name="uPosition">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The menu item to be changed, as determined by the uFlags parameter.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Specifies how the uPosition parameter is to be interpreted. The uFlags parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MF_BYCOMMAND 0x00000000L</term>
	/// <term>
	/// Indicates that uPosition gives the identifier of the menu item. If neither MF_BYCOMMAND nor MF_BYPOSITION is specified,
	/// MF_BYCOMMAND is the default flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MF_BYPOSITION 0x00000400L</term>
	/// <term>Indicates that uPosition gives the zero-based relative position of the menu item.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hBitmapUnchecked">
	/// <para>Type: <c>HBITMAP</c></para>
	/// <para>A handle to the bitmap displayed when the menu item is not selected.</para>
	/// </param>
	/// <param name="hBitmapChecked">
	/// <para>Type: <c>HBITMAP</c></para>
	/// <para>A handle to the bitmap displayed when the menu item is selected.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If either the hBitmapUnchecked or hBitmapChecked parameter is <c>NULL</c>, the system displays nothing next to the menu item for
	/// the corresponding check state. If both parameters are <c>NULL</c>, the system displays the default check-mark bitmap when the
	/// item is selected, and removes the bitmap when the item is not selected.
	/// </para>
	/// <para>When the menu is destroyed, these bitmaps are not destroyed; it is up to the application to destroy them.</para>
	/// <para>
	/// The selected and clear bitmaps should be monochrome. The system uses the Boolean AND operator to combine bitmaps with the menu so
	/// that the white part becomes transparent and the black part becomes the menu-item color. If you use color bitmaps, the results may
	/// be undesirable.
	/// </para>
	/// <para>Use the GetSystemMetrics function with the <c>CXMENUCHECK</c> and <c>CYMENUCHECK</c> values to retrieve the bitmap dimensions.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Simulating Check Boxes in a Menu.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setmenuitembitmaps BOOL SetMenuItemBitmaps( HMENU hMenu,
	// UINT uPosition, UINT uFlags, HBITMAP hBitmapUnchecked, HBITMAP hBitmapChecked );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setmenuitembitmaps.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetMenuItemBitmaps(HMENU hMenu, uint uPosition, MenuFlags uFlags, [Optional] HBITMAP hBitmapUnchecked, [Optional] HBITMAP hBitmapChecked);

	/// <summary>
	/// <para>Changes information about a menu item.</para>
	/// </summary>
	/// <param name="hmenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>A handle to the menu that contains the menu item.</para>
	/// </param>
	/// <param name="item">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The identifier or position of the menu item to change. The meaning of this parameter depends on the value of fByPosition.</para>
	/// </param>
	/// <param name="fByPositon">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The meaning of uItem. If this parameter is <c>FALSE</c>, uItem is a menu item identifier. Otherwise, it is a menu item position.
	/// See About Menus for more information.
	/// </para>
	/// </param>
	/// <param name="lpmii">
	/// <para>Type: <c>LPMENUITEMINFO</c></para>
	/// <para>
	/// A pointer to a MENUITEMINFO structure that contains information about the menu item and specifies which menu item attributes to change.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>The application must call the DrawMenuBar function whenever a menu changes, whether the menu is in a displayed window.</para>
	/// <para>
	/// In order for keyboard accelerators to work with bitmap or owner-drawn menu items, the owner of the menu must process the
	/// WM_MENUCHAR message. See Owner-Drawn Menus and the WM_MENUCHAR Message for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Example of Owner-Drawn Menu Items.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setmenuiteminfoa BOOL SetMenuItemInfoA( HMENU hmenu, UINT
	// item, BOOL fByPositon, LPCMENUITEMINFOA lpmii );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "setmenuiteminfo.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetMenuItemInfo(HMENU hmenu, uint item, [MarshalAs(UnmanagedType.Bool)] bool fByPositon, in MENUITEMINFO lpmii);

	/// <summary>
	/// <para>
	/// Displays a shortcut menu at the specified location and tracks the selection of items on the menu. The shortcut menu can appear
	/// anywhere on the screen.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to the shortcut menu to be displayed. The handle can be obtained by calling CreatePopupMenu to create a new shortcut
	/// menu, or by calling GetSubMenu to retrieve a handle to a submenu associated with an existing menu item.
	/// </para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Use zero of more of these flags to specify function options.</para>
	/// <para>Use one of the following flags to specify how the function positions the shortcut menu horizontally.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_CENTERALIGN 0x0004L</term>
	/// <term>Centers the shortcut menu horizontally relative to the coordinate specified by the x parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_LEFTALIGN 0x0000L</term>
	/// <term>Positions the shortcut menu so that its left side is aligned with the coordinate specified by the x parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_RIGHTALIGN 0x0008L</term>
	/// <term>Positions the shortcut menu so that its right side is aligned with the coordinate specified by the x parameter.</term>
	/// </item>
	/// </list>
	/// <para>Use one of the following flags to specify how the function positions the shortcut menu vertically.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_BOTTOMALIGN 0x0020L</term>
	/// <term>Positions the shortcut menu so that its bottom side is aligned with the coordinate specified by the y parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_TOPALIGN 0x0000L</term>
	/// <term>Positions the shortcut menu so that its top side is aligned with the coordinate specified by the y parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_VCENTERALIGN 0x0010L</term>
	/// <term>Centers the shortcut menu vertically relative to the coordinate specified by the y parameter.</term>
	/// </item>
	/// </list>
	/// <para>Use the following flags to control discovery of the user selection without having to set up a parent window for the menu.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_NONOTIFY 0x0080L</term>
	/// <term>The function does not send notification messages when the user clicks a menu item.</term>
	/// </item>
	/// <item>
	/// <term>TPM_RETURNCMD 0x0100L</term>
	/// <term>The function returns the menu item identifier of the user's selection in the return value.</term>
	/// </item>
	/// </list>
	/// <para>Use one of the following flags to specify which mouse button the shortcut menu tracks.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_LEFTBUTTON 0x0000L</term>
	/// <term>The user can select menu items with only the left mouse button.</term>
	/// </item>
	/// <item>
	/// <term>TPM_RIGHTBUTTON 0x0002L</term>
	/// <term>The user can select menu items with both the left and right mouse buttons.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Use any reasonable combination of the following flags to modify the animation of a menu. For example, by selecting a horizontal
	/// and a vertical flag, you can achieve diagonal animation.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_HORNEGANIMATION 0x0800L</term>
	/// <term>Animates the menu from right to left.</term>
	/// </item>
	/// <item>
	/// <term>TPM_HORPOSANIMATION 0x0400L</term>
	/// <term>Animates the menu from left to right.</term>
	/// </item>
	/// <item>
	/// <term>TPM_NOANIMATION 0x4000L</term>
	/// <term>Displays menu without animation.</term>
	/// </item>
	/// <item>
	/// <term>TPM_VERNEGANIMATION 0x2000L</term>
	/// <term>Animates the menu from bottom to top.</term>
	/// </item>
	/// <item>
	/// <term>TPM_VERPOSANIMATION 0x1000L</term>
	/// <term>Animates the menu from top to bottom.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For any animation to occur, the SystemParametersInfo function must set <c>SPI_SETMENUANIMATION</c>. Also, all the TPM_*ANIMATION
	/// flags, except <c>TPM_NOANIMATION</c>, are ignored if menu fade animation is on. For more information, see the
	/// <c>SPI_GETMENUFADE</c> flag in <c>SystemParametersInfo</c>.
	/// </para>
	/// <para>
	/// Use the <c>TPM_RECURSE</c> flag to display a menu when another menu is already displayed. This is intended to support context
	/// menus within a menu.
	/// </para>
	/// <para>For right-to-left text layout, use <c>TPM_LAYOUTRTL</c>. By default, the text layout is left-to-right.</para>
	/// </param>
	/// <param name="x">
	/// <para>Type: <c>int</c></para>
	/// <para>The horizontal location of the shortcut menu, in screen coordinates.</para>
	/// </param>
	/// <param name="y">
	/// <para>Type: <c>int</c></para>
	/// <para>The vertical location of the shortcut menu, in screen coordinates.</para>
	/// </param>
	/// <param name="nReserved">
	/// <para>Type: <c>int</c></para>
	/// <para>Reserved; must be zero.</para>
	/// </param>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window that owns the shortcut menu. This window receives all messages from the menu. The window does not receive
	/// a WM_COMMAND message from the menu until the function returns. If you specify TPM_NONOTIFY in the uFlags parameter, the function
	/// does not send messages to the window identified by hWnd. However, you must still pass a window handle in hWnd. It can be any
	/// window handle from your application.
	/// </para>
	/// </param>
	/// <param name="prcRect">
	/// <para>Type: <c>const RECT*</c></para>
	/// <para>Ignored.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If you specify <c>TPM_RETURNCMD</c> in the uFlags parameter, the return value is the menu-item identifier of the item that the
	/// user selected. If the user cancels the menu without making a selection, or if an error occurs, the return value is zero.
	/// </para>
	/// <para>
	/// If you do not specify <c>TPM_RETURNCMD</c> in the uFlags parameter, the return value is nonzero if the function succeeds and zero
	/// if it fails. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call GetSystemMetrics with <c>SM_MENUDROPALIGNMENT</c> to determine the correct horizontal alignment flag ( <c>TPM_LEFTALIGN</c>
	/// or <c>TPM_RIGHTALIGN</c>) and/or horizontal animation direction flag ( <c>TPM_HORPOSANIMATION</c> or <c>TPM_HORNEGANIMATION</c>)
	/// to pass to <c>TrackPopupMenu</c> or TrackPopupMenuEx. This is essential for creating an optimal user experience, especially when
	/// developing Microsoft Tablet PC applications.
	/// </para>
	/// <para>To specify an area of the screen that the menu should not overlap, use the TrackPopupMenuEx function</para>
	/// <para>
	/// To display a context menu for a notification icon, the current window must be the foreground window before the application calls
	/// <c>TrackPopupMenu</c> or TrackPopupMenuEx. Otherwise, the menu will not disappear when the user clicks outside of the menu or the
	/// window that created the menu (if it is visible). If the current window is a child window, you must set the (top-level) parent
	/// window as the foreground window.
	/// </para>
	/// <para>
	/// However, when the current window is the foreground window, the second time this menu is displayed, it appears and then
	/// immediately disappears. To correct this, you must force a task switch to the application that called <c>TrackPopupMenu</c>. This
	/// is done by posting a benign message to the window or thread, as shown in the following code sample:
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Displaying a Shortcut Menu.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-trackpopupmenu BOOL TrackPopupMenu( HMENU hMenu, UINT
	// uFlags, int x, int y, int nReserved, HWND hWnd, CONST RECT *prcRect );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "trackpopupmenu.htm")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TrackPopupMenu(HMENU hMenu, TrackPopupMenuFlags uFlags, int x, int y, [Optional] int nReserved, HWND hWnd, [Optional] PRECT prcRect);

	/// <summary>
	/// <para>
	/// Displays a shortcut menu at the specified location and tracks the selection of items on the shortcut menu. The shortcut menu can
	/// appear anywhere on the screen.
	/// </para>
	/// </summary>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to the shortcut menu to be displayed. This handle can be obtained by calling the CreatePopupMenu function to create a
	/// new shortcut menu or by calling the GetSubMenu function to retrieve a handle to a submenu associated with an existing menu item.
	/// </para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Specifies function options.</para>
	/// <para>Use one of the following flags to specify how the function positions the shortcut menu horizontally.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_CENTERALIGN 0x0004L</term>
	/// <term>Centers the shortcut menu horizontally relative to the coordinate specified by the x parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_LEFTALIGN 0x0000L</term>
	/// <term>Positions the shortcut menu so that its left side is aligned with the coordinate specified by the x parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_RIGHTALIGN 0x0008L</term>
	/// <term>Positions the shortcut menu so that its right side is aligned with the coordinate specified by the x parameter.</term>
	/// </item>
	/// </list>
	/// <para>Use one of the following flags to specify how the function positions the shortcut menu vertically.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_BOTTOMALIGN 0x0020L</term>
	/// <term>Positions the shortcut menu so that its bottom side is aligned with the coordinate specified by the y parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_TOPALIGN 0x0000L</term>
	/// <term>Positions the shortcut menu so that its top side is aligned with the coordinate specified by the y parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_VCENTERALIGN 0x0010L</term>
	/// <term>Centers the shortcut menu vertically relative to the coordinate specified by the y parameter.</term>
	/// </item>
	/// </list>
	/// <para>Use the following flags to control discovery of the user selection without having to set up a parent window for the menu.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_NONOTIFY 0x0080L</term>
	/// <term>The function does not send notification messages when the user clicks a menu item.</term>
	/// </item>
	/// <item>
	/// <term>TPM_RETURNCMD 0x0100L</term>
	/// <term>The function returns the menu item identifier of the user's selection in the return value.</term>
	/// </item>
	/// </list>
	/// <para>Use one of the following flags to specify which mouse button the shortcut menu tracks.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_LEFTBUTTON 0x0000L</term>
	/// <term>The user can select menu items with only the left mouse button.</term>
	/// </item>
	/// <item>
	/// <term>TPM_RIGHTBUTTON 0x0002L</term>
	/// <term>The user can select menu items with both the left and right mouse buttons.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Use any reasonable combination of the following flags to modify the animation of a menu. For example, by selecting a horizontal
	/// and a vertical flag, you can achieve diagonal animation.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_HORNEGANIMATION 0x0800L</term>
	/// <term>Animates the menu from right to left.</term>
	/// </item>
	/// <item>
	/// <term>TPM_HORPOSANIMATION 0x0400L</term>
	/// <term>Animates the menu from left to right.</term>
	/// </item>
	/// <item>
	/// <term>TPM_NOANIMATION 0x4000L</term>
	/// <term>Displays menu without animation.</term>
	/// </item>
	/// <item>
	/// <term>TPM_VERNEGANIMATION 0x2000L</term>
	/// <term>Animates the menu from bottom to top.</term>
	/// </item>
	/// <item>
	/// <term>TPM_VERPOSANIMATION 0x1000L</term>
	/// <term>Animates the menu from top to bottom.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For any animation to occur, the SystemParametersInfo function must set <c>SPI_SETMENUANIMATION</c>. Also, all the
	/// <c>TPM_*ANIMATION</c> flags, except <c>TPM_NOANIMATION</c>, are ignored if menu fade animation is on. For more information, see
	/// the <c>SPI_GETMENUFADE</c> flag in <c>SystemParametersInfo</c>.
	/// </para>
	/// <para>
	/// Use the <c>TPM_RECURSE</c> flag to display a menu when another menu is already displayed. This is intended to support context
	/// menus within a menu.
	/// </para>
	/// <para>Use one of the following flags to specify whether to accommodate horizontal or vertical alignment.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_HORIZONTAL 0x0000L</term>
	/// <term>
	/// If the menu cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to accommodate
	/// the requested horizontal alignment before the requested vertical alignment.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TPM_VERTICAL 0x0040L</term>
	/// <term>
	/// If the menu cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to accommodate
	/// the requested vertical alignment before the requested horizontal alignment.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The excluded rectangle is a portion of the screen that the menu should not overlap; it is specified by the lptpm parameter.</para>
	/// <para>For right-to-left text layout, use <c>TPM_LAYOUTRTL</c>. By default, the text layout is left-to-right.</para>
	/// </param>
	/// <param name="x">
	/// <para>Type: <c>int</c></para>
	/// <para>The horizontal location of the shortcut menu, in screen coordinates.</para>
	/// </param>
	/// <param name="y">
	/// <para>Type: <c>int</c></para>
	/// <para>The vertical location of the shortcut menu, in screen coordinates.</para>
	/// </param>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window that owns the shortcut menu. This window receives all messages from the menu. The window does not receive
	/// a WM_COMMAND message from the menu until the function returns. If you specify TPM_NONOTIFY in the fuFlags parameter, the function
	/// does not send messages to the window identified by hwnd. However, you must still pass a window handle in hwnd. It can be any
	/// window handle from your application.
	/// </para>
	/// </param>
	/// <param name="lptpm">
	/// <para>Type: <c>LPTPMPARAMS</c></para>
	/// <para>
	/// A pointer to a TPMPARAMS structure that specifies an area of the screen the menu should not overlap. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If you specify <c>TPM_RETURNCMD</c> in the fuFlags parameter, the return value is the menu-item identifier of the item that the
	/// user selected. If the user cancels the menu without making a selection, or if an error occurs, the return value is zero.
	/// </para>
	/// <para>
	/// If you do not specify <c>TPM_RETURNCMD</c> in the fuFlags parameter, the return value is nonzero if the function succeeds and
	/// zero if it fails. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call GetSystemMetrics with <c>SM_MENUDROPALIGNMENT</c> to determine the correct horizontal alignment flag ( <c>TPM_LEFTALIGN</c>
	/// or <c>TPM_RIGHTALIGN</c>) and/or horizontal animation direction flag ( <c>TPM_HORPOSANIMATION</c> or <c>TPM_HORNEGANIMATION</c>)
	/// to pass to TrackPopupMenu or <c>TrackPopupMenuEx</c>. This is essential for creating an optimal user experience, especially when
	/// developing Microsoft Tablet PC applications.
	/// </para>
	/// <para>
	/// To display a context menu for a notification icon, the current window must be the foreground window before the application calls
	/// TrackPopupMenu or <c>TrackPopupMenuEx</c>. Otherwise, the menu will not disappear when the user clicks outside of the menu or the
	/// window that created the menu (if it is visible). If the current window is a child window, you must set the (top-level) parent
	/// window as the foreground window.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-trackpopupmenuex BOOL TrackPopupMenuEx( HMENU hMenu, UINT
	// uFlags, int x, int y, HWND hwnd, LPTPMPARAMS lptpm );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "trackpopupmenuex.htm")]
	public static extern uint TrackPopupMenuEx(HMENU hMenu, TrackPopupMenuFlags uFlags, int x, int y, HWND hwnd, [In, Optional] TPMPARAMS lptpm);

	/// <summary>
	/// <para>Contains information about the menu to be activated.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmdinextmenu typedef struct tagMDINEXTMENU { HMENU
	// hmenuIn; HMENU hmenuNext; HWND hwndNext; } MDINEXTMENU, *PMDINEXTMENU, *LPMDINEXTMENU;
	[PInvokeData("winuser.h", MSDNShortId = "mdinextmenu.htm")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MDINEXTMENU
	{
		/// <summary>
		/// <para>Type: <c>HMENU</c></para>
		/// <para>A handle to the current menu.</para>
		/// </summary>
		public HMENU hmenuIn;

		/// <summary>
		/// <para>Type: <c>HMENU</c></para>
		/// <para>A handle to the menu to be activated.</para>
		/// </summary>
		public HMENU hmenuNext;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window to receive the menu notification messages.</para>
		/// </summary>
		public HWND hwndNext;
	}

	/// <summary>
	/// <para>Contains menu bar information.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmenubarinfo typedef struct tagMENUBARINFO { DWORD
	// cbSize; RECT rcBar; HMENU hMenu; HWND hwndMenu; BOOL fBarFocused : 1; BOOL fFocused : 1; } MENUBARINFO, *PMENUBARINFO, *LPMENUBARINFO;
	[PInvokeData("winuser.h", MSDNShortId = "menubarinfo.htm")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MENUBARINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of the structure, in bytes. The caller must set this to .</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The coordinates of the menu bar, popup menu, or menu item.</para>
		/// </summary>
		public RECT rcBar;

		/// <summary>
		/// <para>Type: <c>HMENU</c></para>
		/// <para>A handle to the menu bar or popup menu.</para>
		/// </summary>
		public HMENU hMenu;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the submenu.</para>
		/// </summary>
		public HWND hwndMenu;

		private uint uFlags;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the menu bar or popup menu has the focus, this member is <c>TRUE</c>. Otherwise, the member is <c>FALSE</c>.</para>
		/// </summary>
		public bool fBarFocused { get => BitHelper.GetBit(uFlags, 0); set => BitHelper.SetBit(ref uFlags, 0, value); }

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the menu item has the focus, this member is <c>TRUE</c>. Otherwise, the member is <c>FALSE</c>.</para>
		/// </summary>
		public bool fFocused { get => BitHelper.GetBit(uFlags, 1); set => BitHelper.SetBit(ref uFlags, 1, value); }
	}

	/// <summary>
	/// <para>
	/// Defines the header for an extended menu template. This structure definition is for explanation only; it is not present in any
	/// standard header file.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// An extended menu template consists of a <c>MENUEX_TEMPLATE_HEADER</c> structure followed by one or more contiguous
	/// <c>MENUEX_TEMPLATE_ITEM</c> structures. The <c>MENUEX_TEMPLATE_ITEM</c> structures, which are variable in length, are aligned on
	/// <c>DWORD</c> boundaries. To create a menu from an extended menu template in memory, use the <c>LoadMenuIndirect</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/menurc/menuex-template-header typedef struct { WORD wVersion; WORD wOffset; DWORD
	// dwHelpId; } MENUEX_TEMPLATE_HEADER;
	[PInvokeData("winuser.h", MSDNShortId = "df763349-7127-482e-8613-74e68addde5d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct MENUEX_TEMPLATE_HEADER
	{
		/// <summary>The template version number. This member must be 1 for extended menu templates.</summary>
		public ushort wVersion;

		/// <summary>
		/// The offset to the first MENUEX_TEMPLATE_ITEM structure, relative to the end of this structure member. If the first item
		/// definition immediately follows the dwHelpId member, this member should be 4.
		/// </summary>
		public ushort wOffset;

		/// <summary>The help identifier of menu bar.</summary>
		public uint dwHelpId;
	}

	/// <summary>
	/// <para>
	/// Defines a menu item in an extended menu template. This structure definition is for explanation only; it is not present in any
	/// standard header file.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// An extended menu template consists of a <c>MENUEX_TEMPLATE_HEADER</c> structure followed by one or more contiguous
	/// <c>MENUEX_TEMPLATE_ITEM</c> structures. The <c>MENUEX_TEMPLATE_ITEM</c> structures, which are variable in length, are aligned on
	/// <c>DWORD</c> boundaries. To create a menu from an extended menu template in memory, use the <c>LoadMenuIndirect</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/menurc/menuex-template-item typedef struct { DWORD dwHelpId; DWORD dwType; DWORD
	// dwState; DWORD menuId; WORD bResInfo; WCHAR szText; DWORD dwHelpId; } MENUEX_TEMPLATE_ITEM;
	[PInvokeData("winuser.h", MSDNShortId = "f6e2fd0a-16b8-48e3-8597-341085a7adbd")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct MENUEX_TEMPLATE_ITEM
	{
		/// <summary>
		/// The menu item type. This member can be a combination of the type (beginning with MFT) values listed with the MENUITEMINFO structure.
		/// </summary>
		public MenuItemType dwType;

		/// <summary>
		/// The menu item state. This member can be a combination of the state (beginning with MFS) values listed with the MENUITEMINFO structure.
		/// </summary>
		public MenuItemState dwState;

		/// <summary>
		/// The menu item identifier. This is an application-defined value that identifies the menu item. In an extended menu resource,
		/// items that open drop-down menus or submenus as well as command items can have identifiers.
		/// </summary>
		public uint menuId;

		/// <summary>
		/// Specifies whether the menu item is the last item in the menu bar, drop-down menu, submenu, or shortcut menu and whether it is
		/// an item that opens a drop-down menu or submenu. This member can be zero or more of these values. For 32-bit applications,
		/// this member is a word; for 16-bit applications, it is a byte.
		/// </summary>
		public ushort bResInfo;

		/// <summary>
		/// The menu item text. This member is a null-terminated Unicode string, aligned on a word boundary. The size of the menu item
		/// definition varies depending on the length of this string.
		/// </summary>
		public string szText;

		/// <summary>
		/// The help identifier for a drop-down menu or submenu. This member, which is included only for items that open drop-down menus
		/// or submenus, is located at the first DWORD boundary following the variable-length szText member.
		/// </summary>
		public uint dwHelpId;
	}

	/// <summary>
	/// <para>Contains information about the menu that the mouse cursor is on.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>MENUGETOBJECTINFO</c> structure is used only in drag-and-drop menus. When the WM_MENUGETOBJECT message is sent, lParam is
	/// a pointer to this structure.
	/// </para>
	/// <para>To create a drag-and-drop menu, call SetMenuInfo with <c>MNS_DRAGDROP</c> set.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmenugetobjectinfo typedef struct tagMENUGETOBJECTINFO {
	// DWORD dwFlags; UINT uPos; HMENU hmenu; PVOID riid; PVOID pvObj; } MENUGETOBJECTINFO, *PMENUGETOBJECTINFO;
	[PInvokeData("winuser.h", MSDNShortId = "menugetobjectinfo.htm")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MENUGETOBJECTINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The position of the mouse cursor with respect to the item indicated by <c>uPos</c>. It is a bitmask of the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MNGOF_BOTTOMGAP 0x00000002</term>
		/// <term>The mouse is on the bottom of the item indicated by uPos.</term>
		/// </item>
		/// <item>
		/// <term>MNGOF_TOPGAP 0x00000001</term>
		/// <term>The mouse is on the top of the item indicated by uPos.</term>
		/// </item>
		/// </list>
		/// <para>If neither MNGOF_BOTTOMGAP nor MNGOF_TOPGAP is set, then the mouse is directly on the item indicated by <c>uPos</c>.</para>
		/// </summary>
		public MNGOF dwFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The position of the item the mouse cursor is on.</para>
		/// </summary>
		public uint uPos;

		/// <summary>
		/// <para>Type: <c>HMENU</c></para>
		/// <para>A handle to the menu the mouse cursor is on.</para>
		/// </summary>
		public HMENU hmenu;

		/// <summary>
		/// <para>Type: <c>PVOID</c></para>
		/// <para>The identifier of the requested interface. Currently it can only be IDropTarget.</para>
		/// </summary>
		public IntPtr riid;

		/// <summary>
		/// <para>Type: <c>PVOID</c></para>
		/// <para>
		/// A pointer to the interface corresponding to the <c>riid</c> member. This pointer is to be returned by the application when
		/// processing the message.
		/// </para>
		/// </summary>
		public IntPtr pvObj;
	}

	/// <summary>
	/// <para>Contains information about a menu.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmenuinfo typedef struct tagMENUINFO { DWORD cbSize;
	// DWORD fMask; DWORD dwStyle; UINT cyMax; HBRUSH hbrBack; DWORD dwContextHelpID; ULONG_PTR dwMenuData; } MENUINFO, *LPMENUINFO;
	[PInvokeData("winuser.h", MSDNShortId = "menuinfo.htm")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MENUINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of the structure, in bytes. The caller must set this member to .</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Indicates the members to be retrieved or set (except for <c>MIM_APPLYTOSUBMENUS</c>). This member can be one or more of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIM_APPLYTOSUBMENUS 0x80000000</term>
		/// <term>Settings apply to the menu and all of its submenus. SetMenuInfo uses this flag and GetMenuInfo ignores this flag</term>
		/// </item>
		/// <item>
		/// <term>MIM_BACKGROUND 0x00000002</term>
		/// <term>Retrieves or sets the hbrBack member.</term>
		/// </item>
		/// <item>
		/// <term>MIM_HELPID 0x00000004</term>
		/// <term>Retrieves or sets the dwContextHelpID member.</term>
		/// </item>
		/// <item>
		/// <term>MIM_MAXHEIGHT 0x00000001</term>
		/// <term>Retrieves or sets the cyMax member.</term>
		/// </item>
		/// <item>
		/// <term>MIM_MENUDATA 0x00000008</term>
		/// <term>Retrieves or sets the dwMenuData member.</term>
		/// </item>
		/// <item>
		/// <term>MIM_STYLE 0x00000010</term>
		/// <term>Retrieves or sets the dwStyle member.</term>
		/// </item>
		/// </list>
		/// </summary>
		public MenuInfoMember fMask;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The menu style. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MNS_AUTODISMISS 0x10000000</term>
		/// <term>Menu automatically ends when mouse is outside the menu for approximately 10 seconds.</term>
		/// </item>
		/// <item>
		/// <term>MNS_CHECKORBMP 0x04000000</term>
		/// <term>
		/// The same space is reserved for the check mark and the bitmap. If the check mark is drawn, the bitmap is not. All checkmarks
		/// and bitmaps are aligned. Used for menus where some items use checkmarks and some use bitmaps.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MNS_DRAGDROP 0x20000000</term>
		/// <term>Menu items are OLE drop targets or drag sources. Menu owner receives WM_MENUDRAG and WM_MENUGETOBJECT messages.</term>
		/// </item>
		/// <item>
		/// <term>MNS_MODELESS 0x40000000</term>
		/// <term>Menu is modeless; that is, there is no menu modal message loop while the menu is active.</term>
		/// </item>
		/// <item>
		/// <term>MNS_NOCHECK 0x80000000</term>
		/// <term>
		/// No space is reserved to the left of an item for a check mark. The item can still be selected, but the check mark will not
		/// appear next to the item.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MNS_NOTIFYBYPOS 0x08000000</term>
		/// <term>
		/// Menu owner receives a WM_MENUCOMMAND message instead of a WM_COMMAND message when the user makes a selection. MNS_NOTIFYBYPOS
		/// is a menu header style and has no effect when applied to individual sub menus.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public MenuInfoStyle dwStyle;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The maximum height of the menu in pixels. When the menu items exceed the space available, scroll bars are automatically used.
		/// The default (0) is the screen height.
		/// </para>
		/// </summary>
		public uint cyMax;

		/// <summary>
		/// <para>Type: <c>HBRUSH</c></para>
		/// <para>A handle to the brush to be used for the menu's background.</para>
		/// </summary>
		public HBRUSH hbrBack;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The context help identifier. This is the same value used in the GetMenuContextHelpId and SetMenuContextHelpId functions.</para>
		/// </summary>
		public uint dwContextHelpID;

		/// <summary>
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>An application-defined value.</para>
		/// </summary>
		public IntPtr dwMenuData;
	}

	/// <summary>
	/// <para>Contains information about a menu item.</para>
	/// </summary>
	/// <remarks>
	/// <para>The <c>MENUITEMINFO</c> structure is used with the GetMenuItemInfo, InsertMenuItem, and SetMenuItemInfo functions.</para>
	/// <para>The menu can display items using text, bitmaps, or both.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmenuiteminfoa typedef struct tagMENUITEMINFOA { UINT
	// cbSize; UINT fMask; UINT fType; UINT fState; UINT wID; HMENU hSubMenu; HBITMAP hbmpChecked; HBITMAP hbmpUnchecked; ULONG_PTR
	// dwItemData; LPSTR dwTypeData; UINT cch; HBITMAP hbmpItem; } MENUITEMINFOA, *LPMENUITEMINFOA;
	[PInvokeData("winuser.h", MSDNShortId = "menuiteminfo.htm")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MENUITEMINFO
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the structure, in bytes. The caller must set this member to .</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Indicates the members to be retrieved or set. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIIM_BITMAP 0x00000080</term>
		/// <term>Retrieves or sets the hbmpItem member.</term>
		/// </item>
		/// <item>
		/// <term>MIIM_CHECKMARKS 0x00000008</term>
		/// <term>Retrieves or sets the hbmpChecked and hbmpUnchecked members.</term>
		/// </item>
		/// <item>
		/// <term>MIIM_DATA 0x00000020</term>
		/// <term>Retrieves or sets the dwItemData member.</term>
		/// </item>
		/// <item>
		/// <term>MIIM_FTYPE 0x00000100</term>
		/// <term>Retrieves or sets the fType member.</term>
		/// </item>
		/// <item>
		/// <term>MIIM_ID 0x00000002</term>
		/// <term>Retrieves or sets the wID member.</term>
		/// </item>
		/// <item>
		/// <term>MIIM_STATE 0x00000001</term>
		/// <term>Retrieves or sets the fState member.</term>
		/// </item>
		/// <item>
		/// <term>MIIM_STRING 0x00000040</term>
		/// <term>Retrieves or sets the dwTypeData member.</term>
		/// </item>
		/// <item>
		/// <term>MIIM_SUBMENU 0x00000004</term>
		/// <term>Retrieves or sets the hSubMenu member.</term>
		/// </item>
		/// <item>
		/// <term>MIIM_TYPE 0x00000010</term>
		/// <term>Retrieves or sets the fType and dwTypeData members. MIIM_TYPE is replaced by MIIM_BITMAP, MIIM_FTYPE, and MIIM_STRING.</term>
		/// </item>
		/// </list>
		/// </summary>
		public MenuItemInfoMask fMask;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The menu item type. This member can be one or more of the following values.</para>
		/// <para>
		/// The <c>MFT_BITMAP</c>, <c>MFT_SEPARATOR</c>, and <c>MFT_STRING</c> values cannot be combined with one another. Set
		/// <c>fMask</c> to <c>MIIM_TYPE</c> to use <c>fType</c>.
		/// </para>
		/// <para><c>fType</c> is used only if <c>fMask</c> has a value of <c>MIIM_FTYPE</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MFT_BITMAP 0x00000004L</term>
		/// <term>
		/// Displays the menu item using a bitmap. The low-order word of the dwTypeData member is the bitmap handle, and the cch member
		/// is ignored. MFT_BITMAP is replaced by MIIM_BITMAP and hbmpItem.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MFT_MENUBARBREAK 0x00000020L</term>
		/// <term>
		/// Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For
		/// a drop-down menu, submenu, or shortcut menu, a vertical line separates the new column from the old.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MFT_MENUBREAK 0x00000040L</term>
		/// <term>
		/// Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For
		/// a drop-down menu, submenu, or shortcut menu, the columns are not separated by a vertical line.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MFT_OWNERDRAW 0x00000100L</term>
		/// <term>
		/// Assigns responsibility for drawing the menu item to the window that owns the menu. The window receives a WM_MEASUREITEM
		/// message before the menu is displayed for the first time, and a WM_DRAWITEM message whenever the appearance of the menu item
		/// must be updated. If this value is specified, the dwTypeData member contains an application-defined value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MFT_RADIOCHECK 0x00000200L</term>
		/// <term>Displays selected menu items using a radio-button mark instead of a check mark if the hbmpChecked member is NULL.</term>
		/// </item>
		/// <item>
		/// <term>MFT_RIGHTJUSTIFY 0x00004000L</term>
		/// <term>Right-justifies the menu item and any subsequent items. This value is valid only if the menu item is in a menu bar.</term>
		/// </item>
		/// <item>
		/// <term>MFT_RIGHTORDER 0x00002000L</term>
		/// <term>
		/// Specifies that menus cascade right-to-left (the default is left-to-right). This is used to support right-to-left languages,
		/// such as Arabic and Hebrew.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MFT_SEPARATOR 0x00000800L</term>
		/// <term>
		/// Specifies that the menu item is a separator. A menu item separator appears as a horizontal dividing line. The dwTypeData and
		/// cch members are ignored. This value is valid only in a drop-down menu, submenu, or shortcut menu.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MFT_STRING 0x00000000L</term>
		/// <term>
		/// Displays the menu item using a text string. The dwTypeData member is the pointer to a null-terminated string, and the cch
		/// member is the length of the string. MFT_STRING is replaced by MIIM_STRING.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public MenuItemType fType;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The menu item state. This member can be one or more of these values. Set <c>fMask</c> to <c>MIIM_STATE</c> to use <c>fState</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MFS_CHECKED 0x00000008L</term>
		/// <term>Checks the menu item. For more information about selected menu items, see the hbmpChecked member.</term>
		/// </item>
		/// <item>
		/// <term>MFS_DEFAULT 0x00001000L</term>
		/// <term>
		/// Specifies that the menu item is the default. A menu can contain only one default menu item, which is displayed in bold.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MFS_DISABLED 0x00000003L</term>
		/// <term>Disables the menu item and grays it so that it cannot be selected. This is equivalent to MFS_GRAYED.</term>
		/// </item>
		/// <item>
		/// <term>MFS_ENABLED 0x00000000L</term>
		/// <term>Enables the menu item so that it can be selected. This is the default state.</term>
		/// </item>
		/// <item>
		/// <term>MFS_GRAYED 0x00000003L</term>
		/// <term>Disables the menu item and grays it so that it cannot be selected. This is equivalent to MFS_DISABLED.</term>
		/// </item>
		/// <item>
		/// <term>MFS_HILITE 0x00000080L</term>
		/// <term>Highlights the menu item.</term>
		/// </item>
		/// <item>
		/// <term>MFS_UNCHECKED 0x00000000L</term>
		/// <term>Unchecks the menu item. For more information about clear menu items, see the hbmpChecked member.</term>
		/// </item>
		/// <item>
		/// <term>MFS_UNHILITE 0x00000000L</term>
		/// <term>Removes the highlight from the menu item. This is the default state.</term>
		/// </item>
		/// </list>
		/// </summary>
		public MenuItemState fState;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>An application-defined value that identifies the menu item. Set <c>fMask</c> to <c>MIIM_ID</c> to use <c>wID</c>.</para>
		/// </summary>
		public uint wID;

		/// <summary>
		/// <para>Type: <c>HMENU</c></para>
		/// <para>
		/// A handle to the drop-down menu or submenu associated with the menu item. If the menu item is not an item that opens a
		/// drop-down menu or submenu, this member is <c>NULL</c>. Set <c>fMask</c> to <c>MIIM_SUBMENU</c> to use <c>hSubMenu</c>.
		/// </para>
		/// </summary>
		public HMENU hSubMenu;

		/// <summary>
		/// <para>Type: <c>HBITMAP</c></para>
		/// <para>
		/// A handle to the bitmap to display next to the item if it is selected. If this member is <c>NULL</c>, a default bitmap is
		/// used. If the <c>MFT_RADIOCHECK</c> type value is specified, the default bitmap is a bullet. Otherwise, it is a check mark.
		/// Set <c>fMask</c> to <c>MIIM_CHECKMARKS</c> to use <c>hbmpChecked</c>.
		/// </para>
		/// </summary>
		public HBITMAP hbmpChecked;

		/// <summary>
		/// <para>Type: <c>HBITMAP</c></para>
		/// <para>
		/// A handle to the bitmap to display next to the item if it is not selected. If this member is <c>NULL</c>, no bitmap is used.
		/// Set <c>fMask</c> to <c>MIIM_CHECKMARKS</c> to use <c>hbmpUnchecked</c>.
		/// </para>
		/// </summary>
		public HBITMAP hbmpUnchecked;

		/// <summary>
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>An application-defined value associated with the menu item. Set <c>fMask</c> to <c>MIIM_DATA</c> to use <c>dwItemData</c>.</para>
		/// </summary>
		public IntPtr dwItemData;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// The contents of the menu item. The meaning of this member depends on the value of <c>fType</c> and is used only if the
		/// <c>MIIM_TYPE</c> flag is set in the <c>fMask</c> member.
		/// </para>
		/// <para>
		/// To retrieve a menu item of type <c>MFT_STRING</c>, first find the size of the string by setting the <c>dwTypeData</c> member
		/// of <c>MENUITEMINFO</c> to <c>NULL</c> and then calling GetMenuItemInfo. The value of <c>cch</c>+1 is the size needed. Then
		/// allocate a buffer of this size, place the pointer to the buffer in <c>dwTypeData</c>, increment <c>cch</c>, and call
		/// <c>GetMenuItemInfo</c> once again to fill the buffer with the string. If the retrieved menu item is of some other type, then
		/// <c>GetMenuItemInfo</c> sets the <c>dwTypeData</c> member to a value whose type is specified by the <c>fType</c> member.
		/// </para>
		/// <para>
		/// When using with the SetMenuItemInfo function, this member should contain a value whose type is specified by the <c>fType</c> member.
		/// </para>
		/// <para><c>dwTypeData</c> is used only if the <c>MIIM_STRING</c> flag is set in the <c>fMask</c> member</para>
		/// </summary>
		public StrPtrAuto dwTypeData;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The length of the menu item text, in characters, when information is received about a menu item of the <c>MFT_STRING</c>
		/// type. However, <c>cch</c> is used only if the <c>MIIM_TYPE</c> flag is set in the <c>fMask</c> member and is zero otherwise.
		/// Also, <c>cch</c> is ignored when the content of a menu item is set by calling SetMenuItemInfo.
		/// </para>
		/// <para>
		/// Note that, before calling GetMenuItemInfo, the application must set <c>cch</c> to the length of the buffer pointed to by the
		/// <c>dwTypeData</c> member. If the retrieved menu item is of type <c>MFT_STRING</c> (as indicated by the <c>fType</c> member),
		/// then <c>GetMenuItemInfo</c> changes <c>cch</c> to the length of the menu item text. If the retrieved menu item is of some
		/// other type, <c>GetMenuItemInfo</c> sets the <c>cch</c> field to zero.
		/// </para>
		/// <para>The <c>cch</c> member is used when the <c>MIIM_STRING</c> flag is set in the <c>fMask</c> member.</para>
		/// </summary>
		public uint cch;

		/// <summary>
		/// <para>Type: <c>HBITMAP</c></para>
		/// <para>
		/// A handle to the bitmap to be displayed, or it can be one of the values in the following table. It is used when the
		/// <c>MIIM_BITMAP</c> flag is set in the <c>fMask</c> member.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HBMMENU_CALLBACK ((HBITMAP) -1)</term>
		/// <term>
		/// A bitmap that is drawn by the window that owns the menu. The application must process the WM_MEASUREITEM and WM_DRAWITEM messages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_CLOSE ((HBITMAP) 5)</term>
		/// <term>Close button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_CLOSE_D ((HBITMAP) 6)</term>
		/// <term>Disabled close button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_MINIMIZE ((HBITMAP) 3)</term>
		/// <term>Minimize button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_MINIMIZE_D ((HBITMAP) 7)</term>
		/// <term>Disabled minimize button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_RESTORE ((HBITMAP) 2)</term>
		/// <term>Restore button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_POPUP_CLOSE ((HBITMAP) 8)</term>
		/// <term>Close button for the submenu.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_POPUP_MAXIMIZE ((HBITMAP) 10)</term>
		/// <term>Maximize button for the submenu.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_POPUP_MINIMIZE ((HBITMAP) 11)</term>
		/// <term>Minimize button for the submenu.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_POPUP_RESTORE ((HBITMAP) 9)</term>
		/// <term>Restore button for the submenu.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_SYSTEM ((HBITMAP) 1)</term>
		/// <term>Windows icon or the icon of the window specified in dwItemData.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HBITMAP hbmpItem;

		/// <summary>Initializes a new instance of the <see cref="MENUITEMINFO"/> struct.</summary>
		/// <param name="id">An application-defined value that identifies the menu item.</param>
		/// <param name="type">The menu type.</param>
		/// <param name="state">The menu state.</param>
		/// <param name="subMenu">
		/// A handle to the drop-down menu or submenu associated with the menu item. If the menu item is not an item that opens a
		/// drop-down menu or submenu, this member is <see cref="HMENU.NULL"/>.
		/// </param>
		public MENUITEMINFO(uint id, MenuItemType type = MenuItemType.MFT_STRING, MenuItemState state = MenuItemState.MFS_ENABLED, HMENU subMenu = default) : this()
		{
			cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO));
			wID = id;
			fMask = MenuItemInfoMask.MIIM_ID;
			fType = type;
			if (type != 0) fMask |= MenuItemInfoMask.MIIM_TYPE;
			fState = state;
			if (state != 0) fMask |= MenuItemInfoMask.MIIM_STATE;
			hSubMenu = subMenu;
			if (subMenu != default) fMask |= MenuItemInfoMask.MIIM_SUBMENU;
		}
	}

	/// <summary>
	/// <para>Defines a menu item in a menu template.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-menuitemtemplate typedef struct MENUITEMTEMPLATE { WORD
	// mtOption; WORD mtID; WCHAR mtString[1]; } *PMENUITEMTEMPLATE;
	[PInvokeData("winuser.h", MSDNShortId = "menuitemtemplate.htm")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2, Size = 6)]
	public struct MENUITEMTEMPLATE
	{
		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// One or more of the following predefined menu options that control the appearance of the menu item as shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MF_CHECKED 0x00000008L</term>
		/// <term>Indicates that the menu item has a check mark next to it.</term>
		/// </item>
		/// <item>
		/// <term>MF_GRAYED 0x00000001L</term>
		/// <term>Indicates that the menu item is initially inactive and drawn with a gray effect.</term>
		/// </item>
		/// <item>
		/// <term>MF_HELP 0x00004000L</term>
		/// <term>Indicates that the menu item has a vertical separator to its left.</term>
		/// </item>
		/// <item>
		/// <term>MF_MENUBARBREAK 0x00000020L</term>
		/// <term>Indicates that the menu item is placed in a new column. The old and new columns are separated by a bar.</term>
		/// </item>
		/// <item>
		/// <term>MF_MENUBREAK 0x00000040L</term>
		/// <term>Indicates that the menu item is placed in a new column.</term>
		/// </item>
		/// <item>
		/// <term>MF_OWNERDRAW 0x00000100L</term>
		/// <term>
		/// Indicates that the owner window of the menu is responsible for drawing all visual aspects of the menu item, including
		/// highlighted, selected, and inactive states. This option is not valid for an item in a menu bar.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MF_POPUP 0x00000010L</term>
		/// <term>Indicates that the item is one that opens a drop-down menu or submenu.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ushort mtOption;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The menu item identifier of a command item; a command item sends a command message to its owner window. The
		/// <c>MENUITEMTEMPLATE</c> structure for an item that opens a drop-down menu or submenu does not contain the <c>mtID</c> member.
		/// </para>
		/// </summary>
		public ushort mtID;

		/// <summary>
		/// <para>Type: <c>WCHAR[1]</c></para>
		/// <para>The menu item.</para>
		/// </summary>
		public ushort mtString;
	}

	/// <summary>
	/// <para>Defines the header for a menu template. A complete menu template consists of a header and one or more menu item lists.</para>
	/// </summary>
	/// <remarks>
	/// <para>One or more MENUITEMTEMPLATE structures are combined to form the menu item list.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-menuitemtemplateheader typedef struct
	// MENUITEMTEMPLATEHEADER { WORD versionNumber; WORD offset; } *PMENUITEMTEMPLATEHEADER;
	[PInvokeData("winuser.h", MSDNShortId = "menuitemtemplateheader.htm")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2)]
	public struct MENUITEMTEMPLATEHEADER
	{
		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The version number. This member must be zero.</para>
		/// </summary>
		public ushort versionNumber;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The offset, in bytes, from the end of the header. The menu item list begins at this offset. Usually, this member is zero, and
		/// the menu item list follows immediately after the header.
		/// </para>
		/// </summary>
		public ushort offset;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HMENU"/> that is disposed using <see cref="DestroyMenu"/>.</summary>
	public class SafeHMENU : SafeHANDLE, IUserHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHMENU"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHMENU(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHMENU"/> class.</summary>
		private SafeHMENU() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHMENU"/> to <see cref="HMENU"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HMENU(SafeHMENU h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DestroyMenu(this);
	}

	/// <summary>
	/// <para>Contains extended parameters for the TrackPopupMenuEx function.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagtpmparams typedef struct tagTPMPARAMS { UINT cbSize;
	// RECT rcExclude; } TPMPARAMS;
	[PInvokeData("winuser.h", MSDNShortId = "tpmparams.htm")]
	[StructLayout(LayoutKind.Sequential)]
	public class TPMPARAMS
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of structure, in bytes.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The rectangle to be excluded when positioning the window, in screen coordinates.</para>
		/// </summary>
		public RECT rcExclude;

		/// <summary>
		/// Initializes a new instance of the <see cref="TPMPARAMS"/> class.
		/// </summary>
		/// <param name="rExclude">The rectangle to exclude.</param>
		public TPMPARAMS(RECT rExclude)
		{
			cbSize = (uint)Marshal.SizeOf(typeof(TPMPARAMS));
			rcExclude = rExclude;
		}
	}
}