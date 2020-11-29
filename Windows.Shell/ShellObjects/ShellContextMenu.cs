// Credit due to Gong-Shell from which this was largely taken.
#if !NETCOREAPP3_1

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell
{
	/// <summary>Provides support for displaying the context menu of a shell item.</summary>
	/// <remarks>
	/// <para>Use this class to display a context menu for a shell item, either as a popup menu, or as a main menu.</para>
	/// <para>
	/// To display a popup menu, simply call <see cref="ShowContextMenu"/> with the parent control and the position at which the menu should
	/// be shown.
	/// </para>
	/// <para>
	/// To display a shell context menu in a Form's main menu, call the <see cref="Populate"/> method to populate the menu. In addition, you
	/// must intercept a number of special messages that will be sent to the menu's parent form. To do this, you must override <see
	/// cref="Form.WndProc"/> like so:
	/// </para>
	/// <code>
	///protected override void WndProc(ref Message m) {
	///if ((m_ContextMenu == null) || (!m_ContextMenu.HandleMenuMessage(ref m))) {
	///base.WndProc(ref m);
	///}
	///}
	/// </code>
	/// <para>Where m_ContextMenu is the <see cref="ShellContextMenu"/> being shown.</para>
	/// Standard menu commands can also be invoked from this class, for example <see cref="InvokeDelete"/> and <see cref="InvokeRename"/>.
	/// </remarks>
	public class ShellContextMenu : IDisposable
	{
		private const int m_CmdFirst = 0x8000;
		private readonly IContextMenu2 m_ComInterface2;
		private readonly IContextMenu3 m_ComInterface3;
		private readonly MessageWindow m_MessageWindow;
		private bool disposedValue;

		/// <summary>Initialises a new instance of the <see cref="ShellContextMenu"/> class.</summary>
		/// <param name="items">The items to which the context menu should refer.</param>
		public ShellContextMenu(params ShellItem[] items)
		{
			var pidls = new IntPtr[items.Length];
			ShellFolder parent = null;

			for (var n = 0; n < items.Length; ++n)
			{
				pidls[n] = ILFindLastID((IntPtr)items[n].PIDL);

				if (parent is null)
				{
					if (items[n] == ShellFolder.Desktop)
					{
						parent = ShellFolder.Desktop;
					}
					else
					{
						parent = items[n].Parent;
					}
				}
				else
				{
					if (items[n].Parent != parent)
					{
						throw new Exception("All shell items must have the same parent");
					}
				}
			}

			ComInterface = parent.IShellFolder.GetUIObjectOf<IContextMenu>(HWND.NULL, pidls);
			m_ComInterface2 = ComInterface as IContextMenu2;
			m_ComInterface3 = ComInterface as IContextMenu3;
			m_MessageWindow = new MessageWindow(this);
		}

		/// <summary>Finalizes an instance of the <see cref="ShellContextMenu"/> class.</summary>
		~ShellContextMenu()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: false);
		}

		/// <summary>Gets the underlying COM <see cref="IContextMenu"/> interface.</summary>
		public IContextMenu ComInterface { get; private set; }

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			System.GC.SuppressFinalize(this);
		}

		/// <summary>Gets the help text for a specified command.</summary>
		/// <param name="command">The menu command identifier offset.</param>
		/// <returns>The help text value if available; otherwise <see langword="null"/>.</returns>
		public string GetHelpTextForCommand(int command) => GetCommandString(command, GCS.GCS_HELPTEXTW);

		/// <summary>Gets the icon location for a specified command.</summary>
		/// <param name="command">The menu command identifier offset.</param>
		/// <returns>The icon location if available; otherwise <see langword="null"/>.</returns>
		public IconLocation GetIconLocationForCommand(int command) => IconLocation.TryParse(GetCommandString(command, GCS.GCS_VERBICONW), out var l) ? l : null;

		/// <summary>Gets the verb for a specified command.</summary>
		/// <param name="command">The menu command identifier offset.</param>
		/// <returns>The verb if available; otherwise <see langword="null"/>.</returns>
		public string GetVerbForCommand(int command) => GetCommandString(command, GCS.GCS_VERBW);

		/// <summary>Gets the information of all the menu items supported by the underlying interface.</summary>
		/// <value>The menu item information.</value>
		public MenuItemInfo[] GetItems(CMF menuOptions = CMF.CMF_EXTENDEDVERBS)
		{
			using var hmenu = CreatePopupMenu();
			ComInterface.QueryContextMenu(hmenu, 0, m_CmdFirst, int.MaxValue, menuOptions).ThrowIfFailed();
			return MenuItemInfo.GetMenuItems(hmenu, this);
		}

		/// <summary>Handles context menu messages when the <see cref="ShellContextMenu"/> is displayed on a Form's main menu bar.</summary>
		/// <remarks>
		/// <para>
		/// To display a shell context menu in a Form's main menu, call the <see cref="Populate"/> method to populate the menu with the
		/// shell item's menu items. In addition, you must intercept a number of special messages that will be sent to the menu's parent
		/// form. To do this, you must override <see cref="Form.WndProc"/> like so:
		/// </para>
		/// <code>
		///protected override void WndProc(ref Message m) {
		///if ((m_ContextMenu == null) || (!m_ContextMenu.HandleMenuMessage(ref m))) {
		///base.WndProc(ref m);
		///}
		///}
		/// </code>
		/// <para>Where m_ContextMenu is the <see cref="ShellContextMenu"/> being shown.</para>
		/// </remarks>
		/// <param name="m">The message to handle.</param>
		/// <returns>
		/// <see langword="true"/> if the message was a Shell Context Menu message, <see langword="false"/> if not. If the method returns
		/// false, then the message should be passed down to the base class's <see cref="Form.WndProc"/> method.
		/// </returns>
		public bool HandleMenuMessage(ref Message m)
		{
			try
			{
				if ((m.Msg == (int)WindowMessage.WM_COMMAND) && ((int)m.WParam >= m_CmdFirst))
				{
					InvokeCommand((int)m.WParam - m_CmdFirst);
					return true;
				}
				else
				{
					if (m_ComInterface3 != null)
					{
						m_ComInterface3.HandleMenuMsg2((uint)m.Msg, m.WParam, m.LParam, out IntPtr result);
						m.Result = result;
						return true;
					}
					else if (m_ComInterface2 != null)
					{
						m_ComInterface2.HandleMenuMsg((uint)m.Msg, m.WParam, m.LParam);
						m.Result = IntPtr.Zero;
						return true;
					}
				}
			}
			catch { }
			return false;
		}

		/// <summary>Invokes the command.</summary>
		/// <param name="verb">
		/// The address of a null-terminated string that specifies the language-independent name of the command to carry out. This member is
		/// typically a string when a command is being activated by an application. The system provides predefined constant values for the
		/// following command strings.
		/// <para>
		/// If a canonical verb exists and a menu handler does not implement the canonical verb, it must return a failure code to enable the
		/// next handler to be able to handle this verb.Failing to do this will break functionality in the system including ShellExecute.
		/// </para>
		/// <para>
		/// Alternatively, rather than a pointer, this parameter can be MAKEINTRESOURCE(offset) where offset is the menu-identifier offset
		/// of the command to carry out. Implementations can use the IS_INTRESOURCE macro to detect that this alternative is being employed.
		/// The Shell uses this alternative when the user chooses a menu command.
		/// </para>
		/// </param>
		/// <param name="show">A set of values to pass to the ShowWindow function if the command displays a window or starts an application.</param>
		/// <param name="parent">
		/// A handle to the window that is the owner of the shortcut menu. An extension can also use this handle as the owner of any message
		/// boxes or dialog boxes it displays. Callers must specify a legitimate HWND that can be used as the owner window for any UI that
		/// may be displayed. Failing to specify an HWND when calling from a UI thread (one with windows already created) will result in
		/// reentrancy and possible bugs in the implementation of this call.
		/// </param>
		/// <param name="location">If supplied, the point where the command is invoked.</param>
		/// <param name="allowAsync">
		/// The implementation can spin off a new thread or process to handle the call and does not need to block on completion of the
		/// function being invoked. For example, if the verb is "delete" the call may return before all of the items have been deleted.
		/// Since this is advisory, calling applications that specify this flag cannot guarantee that this request will be honored if they
		/// are not familiar with the implementation of the verb that they are invoking.
		/// </param>
		/// <param name="shiftDown">
		/// If <see langword="true"/>, the SHIFT key is pressed. Use this instead of polling the current state of the keyboard that may have
		/// changed since the verb was invoked.
		/// </param>
		/// <param name="ctrlDown">
		/// If <see langword="true"/>, the CTRL key is pressed. Use this instead of polling the current state of the keyboard that may have
		/// changed since the verb was invoked..
		/// </param>
		/// <param name="hotkey">An optional keyboard shortcut to assign to any application activated by the command.</param>
		/// <param name="logUsage">
		/// If <see langword="true"/>, indicates that the method might want to keep track of the item being invoked for features like the
		/// "Recent documents" menu.
		/// </param>
		/// <param name="noZoneChecks">
		/// Do not perform a zone check. This flag allows ShellExecuteEx to bypass zone checking put into place by IAttachmentExecute.
		/// </param>
		public void InvokeCommand(ResourceId verb, ShowWindowCommand show = ShowWindowCommand.SW_SHOWNORMAL, HWND parent = default,
			Point? location = default, bool allowAsync = false, bool shiftDown = false,
			bool ctrlDown = false, uint hotkey = 0, bool logUsage = false, bool noZoneChecks = false)
		{
			var invoke = new CMINVOKECOMMANDINFOEX
			{
				cbSize = (uint)Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX)),
				hwnd = parent,
				fMask = (parent.IsNull ? CMIC.CMIC_MASK_FLAG_NO_UI : 0) | (hotkey != 0 ? CMIC.CMIC_MASK_HOTKEY : 0),
				lpVerb = verb,
				nShow = show,
				dwHotKey = hotkey,
			};
			if (allowAsync) invoke.fMask |= CMIC.CMIC_MASK_ASYNCOK;
			if (shiftDown) invoke.fMask |= CMIC.CMIC_MASK_SHIFT_DOWN;
			if (ctrlDown) invoke.fMask |= CMIC.CMIC_MASK_CONTROL_DOWN;
			if (logUsage) invoke.fMask |= CMIC.CMIC_MASK_FLAG_LOG_USAGE;
			if (noZoneChecks) invoke.fMask |= CMIC.CMIC_MASK_NOZONECHECKS;
			if (location.HasValue)
			{
				invoke.ptInvoke = location.Value;
				invoke.fMask |= CMIC.CMIC_MASK_PTINVOKE;
			}
			if (!verb.IsIntResource)
			{
				invoke.lpVerbW = (string)verb;
				invoke.fMask |= CMIC.CMIC_MASK_UNICODE;
			}
			ComInterface.InvokeCommand(invoke);
		}

		/// <summary>Invokes the Copy command on the shell item(s).</summary>
		public void InvokeCopy() => InvokeVerb("copy");

		/// <summary>Invokes the Copy command on the shell item(s).</summary>
		public void InvokeCut() => InvokeVerb("cut");

		/// <summary>Invokes the Delete command on the shell item(s).</summary>
		public void InvokeDelete()
		{
			try
			{
				InvokeVerb("delete");
			}
			catch (COMException e)
			{
				// Ignore the exception raised when the user cancels a delete operation.
				if (e.ErrorCode != (HRESULT)(Win32Error)Win32Error.ERROR_CANCELLED &&
					e.ErrorCode != HRESULT.COPYENGINE_E_USER_CANCELLED)
				{
					throw;
				}
			}
		}

		/// <summary>Invokes the Paste command on the shell item(s).</summary>
		public void InvokePaste() => InvokeVerb("paste");

		/// <summary>Invokes the Rename command on the shell item.</summary>
		public void InvokeRename() => InvokeVerb("rename");

		/// <summary>Invokes the specified verb on the shell item(s).</summary>
		/// <param name="verb">The verb to invoke.</param>
		/// <param name="show">Flags that specify how to display any opened window.</param>
		/// <param name="parent">
		/// A handle to the window that is the owner of the shortcut menu. An extension can also use this handle as the owner of any message
		/// boxes or dialog boxes it displays. Callers must specify a legitimate HWND that can be used as the owner window for any UI that
		/// may be displayed. Failing to specify an HWND when calling from a UI thread (one with windows already created) will result in
		/// reentrancy and possible bugs in the implementation of this call.
		/// </param>
		public void InvokeVerb(string verb, [Optional] ShowWindowCommand show, [Optional] HWND parent) =>
			InvokeCommand(new SafeResourceId(verb), show, parent);

		/// <summary>Shows a context menu for a shell item.</summary>
		/// <param name="pos">The position on the screen that the menu should be displayed at.</param>
		/// <param name="menuOptions">The options that determine which items are requested from <see cref="IContextMenu"/>.</param>
		public void ShowContextMenu(Point pos, CMF menuOptions = CMF.CMF_EXTENDEDVERBS)
		{
			using var hmenu = CreatePopupMenu();
			ComInterface.QueryContextMenu(hmenu, 0, m_CmdFirst, int.MaxValue, menuOptions).ThrowIfFailed();
			var command = TrackPopupMenuEx(hmenu, TrackPopupMenuFlags.TPM_RETURNCMD, pos.X, pos.Y, m_MessageWindow.Handle);
			if (command > 0)
				InvokeCommand((int)command - m_CmdFirst);
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing">
		/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				Marshal.ReleaseComObject(ComInterface);
				ComInterface = null;
				disposedValue = true;
			}
		}

		private string GetCommandString(ResourceId command, GCS stringType)
		{
			using var mStr = new SafeCoTaskMemString(4096);
			try { ComInterface.GetCommandString(command, stringType, default, mStr, mStr.Size / 2U); }
			catch { return null; }
			return mStr.ToString();
		}

#if !NET5_0
		/// <summary>Populates a <see cref="Menu"/> with the context menu items for a shell item.</summary>
		/// <param name="menu">The menu to populate.</param>
		/// <param name="menuOptions">The flags to pass to <see cref="IContextMenu.QueryContextMenu"/>.</param>
		/// <remarks>
		/// If this method is being used to populate a Form's main menu then you need to call <see cref="HandleMenuMessage"/> in the Form's
		/// message handler.
		/// </remarks>
		public void Populate(Menu menu, CMF menuOptions = CMF.CMF_NORMAL)
		{
			RemoveShellMenuItems(menu);
			ComInterface.QueryContextMenu(menu.Handle, 0, m_CmdFirst, int.MaxValue, menuOptions);
		}

		private void RemoveShellMenuItems(Menu menu)
		{
			const int tag = 0xAB;

			var menuInfo = new MENUINFO();
			menuInfo.cbSize = (uint)Marshal.SizeOf(menuInfo);
			menuInfo.fMask = MenuInfoMember.MIM_MENUDATA;

			var itemInfo = new MENUITEMINFO();
			itemInfo.cbSize = (uint)Marshal.SizeOf(itemInfo);
			itemInfo.fMask = MenuItemInfoMask.MIIM_ID | MenuItemInfoMask.MIIM_SUBMENU;

			// First, tag the managed menu items with an arbitary value (0xAB).
			TagManagedMenuItems(menu, tag);

			var remove = new Stack<uint>();
			var count = GetMenuItemCount(menu.Handle);
			for (uint n = 0; n < count; ++n)
			{
				GetMenuItemInfo(menu.Handle, n, true, ref itemInfo);

				if (itemInfo.hSubMenu.IsNull)
				{
					// If the item has no submenu we can't get the tag, so check its ID to determine if it was added by the shell.
					if (itemInfo.wID >= m_CmdFirst) remove.Push(n);
				}
				else
				{
					GetMenuInfo(itemInfo.hSubMenu, ref menuInfo);
					if ((int)menuInfo.dwMenuData != tag) remove.Push(n);
				}
			}

			// Remove the unmanaged menu items.
			while (remove.Count > 0)
				DeleteMenu(menu.Handle, remove.Pop(), MenuFlags.MF_BYPOSITION);
		}

		private void TagManagedMenuItems(Menu menu, int tag)
		{
			var info = new MENUINFO
			{
				cbSize = (uint)Marshal.SizeOf(typeof(MENUINFO)),
				fMask = MenuInfoMember.MIM_MENUDATA,
				dwMenuData = (UIntPtr)tag
			};

			foreach (Menu item in menu.MenuItems)
			{
				SetMenuInfo(item.Handle, info);
			}
		}

#endif

		/// <summary>Provides information about a single menu entry discovered in a native menu.</summary>
		public class MenuItemInfo
		{
			internal MenuItemInfo(HMENU hMenu, uint idx)
			{
				using var strmem = new SafeHGlobalHandle(512);
				var mii = new MENUITEMINFO
				{
					cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO)),
					fMask = MenuItemInfoMask.MIIM_ID | MenuItemInfoMask.MIIM_SUBMENU | MenuItemInfoMask.MIIM_FTYPE | MenuItemInfoMask.MIIM_STRING | MenuItemInfoMask.MIIM_STATE | MenuItemInfoMask.MIIM_BITMAP,
					fType = MenuItemType.MFT_STRING,
					dwTypeData = (IntPtr)strmem,
					cch = strmem.Size / (uint)StringHelper.GetCharSize()
				};
				Win32Error.ThrowLastErrorIfFalse(GetMenuItemInfo(hMenu, idx, true, ref mii));
				Id = unchecked((int)mii.wID);
				Text = mii.fType.IsFlagSet(MenuItemType.MFT_SEPARATOR) ? "-" : mii.fType.IsFlagSet(MenuItemType.MFT_STRING) ? strmem.ToString(-1, CharSet.Auto) : "";
				Type = mii.fType;
				State = mii.fState;
				BitmapHandle = mii.hbmpItem;
				SubMenus = GetMenuItems(mii.hSubMenu);
			}

			/// <summary>
			/// <para>A handle to the bitmap to be displayed, or it can be one of the values in the following table.</para>
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
			public HBITMAP BitmapHandle { get; }

			/// <summary>Gets the help text (tool tip) associated with the menu.</summary>
			public string HelpText { get; internal set; }

			/// <summary>Gets the icon location associated with the menu's image.</summary>
			public IconLocation IconLocation { get; internal set; }

			/// <summary>An application-defined value that identifies the menu item.</summary>
			public int Id { get; }

			/// <summary>The menu item state. This member can be one or more of the <see cref="MenuItemState"/> values.</summary>
			public MenuItemState State { get; }

			/// <summary>
			/// The submenu items associated with the menu item. If the menu item is not an item that opens a drop-down menu or submenu,
			/// this member has no values.
			/// </summary>
			public MenuItemInfo[] SubMenus { get; }

			/// <summary>The contents of the menu item. The meaning of this member depends on the value of <see cref="MenuItemInfo.Type"/>.</summary>
			public string Text { get; }

			/// <summary>
			/// <para>The menu item type. This member can be one or more of the <see cref="MenuItemType"/> values.</para>
			/// <para>The <c>MFT_BITMAP</c>, <c>MFT_SEPARATOR</c>, and <c>MFT_STRING</c> values cannot be combined with one another.</para>
			/// </summary>
			public MenuItemType Type { get; }

			/// <summary>Gets the verb associated with the menu.</summary>
			public string Verb { get; internal set; }

			/// <summary>Recursively gets the information for all menu item entries supplied by the provided native menu.</summary>
			/// <param name="hMenu">The handle to the created native menu.</param>
			/// <returns>An array of <see cref="MenuItemInfo"/> instances with information about the entries in <paramref name="hMenu"/>.</returns>
			public static MenuItemInfo[] GetMenuItems(HMENU hMenu) => GetMenuItems(hMenu, null);

			internal static MenuItemInfo[] GetMenuItems(HMENU hMenu, ShellContextMenu scm)
			{
				if (hMenu.IsNull)
					return new MenuItemInfo[0];

				var SubMenus = new MenuItemInfo[GetMenuItemCount(hMenu)];
				for (uint i = 0; i < SubMenus.Length; i++)
				{
					SubMenus[i] = new MenuItemInfo(hMenu, i);
					if (scm != null)
					{
						SubMenus[i].Verb = scm.GetVerbForCommand(SubMenus[i].Id);
						SubMenus[i].HelpText = scm.GetHelpTextForCommand(SubMenus[i].Id);
						SubMenus[i].IconLocation = scm.GetIconLocationForCommand(SubMenus[i].Id);
					}
				}
				return SubMenus;
			}
		}

		private class MessageWindow : Control
		{
			private readonly ShellContextMenu m_Parent;

			public MessageWindow(ShellContextMenu parent) => m_Parent = parent;

			protected override void WndProc(ref Message m)
			{
				if (!m_Parent.HandleMenuMessage(ref m))
				{
					base.WndProc(ref m);
				}
			}
		}
	}
}

#endif