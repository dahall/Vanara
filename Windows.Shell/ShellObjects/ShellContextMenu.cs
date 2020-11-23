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
		public IContextMenu ComInterface { get; set; }

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			System.GC.SuppressFinalize(this);
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
		public void InvokeVerb(string verb, ShowWindowCommand show = ShowWindowCommand.SW_NORMAL)
		{
			var invoke = new CMINVOKECOMMANDINFOEX
			{
				cbSize = (uint)Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX)),
				lpVerb = new SafeResourceId(verb, CharSet.Ansi),
				nShow = show
			};
			ComInterface.InvokeCommand(invoke);
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

		private void InvokeCommand(int index)
		{
			var invoke = new CMINVOKECOMMANDINFOEX(index) { nShow = ShowWindowCommand.SW_SHOWNORMAL };
			m_ComInterface2.InvokeCommand(invoke);
		}

#if !NET5_0
		/// <summary>Populates a <see cref="Menu"/> with the context menu items for a shell item.</summary>
		/// <param name="menu">The menu to populate.</param>
		/// <param name="menuFlags">The flags to pass to <see cref="IContextMenu.QueryContextMenu"/>.</param>
		/// <remarks>
		/// If this method is being used to populate a Form's main menu then you need to call <see cref="HandleMenuMessage"/> in the Form's
		/// message handler.
		/// </remarks>
		public void Populate(Menu menu, CMF menuFlags = CMF.CMF_NORMAL)
		{
			RemoveShellMenuItems(menu);
			ComInterface.QueryContextMenu(menu.Handle, 0, m_CmdFirst, int.MaxValue, menuFlags);
		}

		/// <summary>Shows a context menu for a shell item.</summary>
		/// <param name="pos">The position on the screen that the menu should be displayed at.</param>
		public void ShowContextMenu(Point pos)
		{
			using var menu = new ContextMenu();
			Populate(menu);
			var command = TrackPopupMenuEx(menu.Handle, TrackPopupMenuFlags.TPM_RETURNCMD, pos.X, pos.Y, m_MessageWindow.Handle);
			if (command > 0)
			{
				InvokeCommand((int)command - m_CmdFirst);
			}
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

			var remove = new List<uint>();
			var count = GetMenuItemCount(menu.Handle);
			for (uint n = 0; n < count; ++n)
			{
				GetMenuItemInfo(menu.Handle, n, true, ref itemInfo);

				if (itemInfo.hSubMenu.IsNull)
				{
					// If the item has no submenu we can't get the tag, so check its ID to determine if it was added by the shell.
					if (itemInfo.wID >= m_CmdFirst) remove.Add(n);
				}
				else
				{
					GetMenuInfo(itemInfo.hSubMenu, ref menuInfo);
					if ((int)menuInfo.dwMenuData != tag) remove.Add(n);
				}
			}

			// Remove the unmanaged menu items.
			remove.Reverse();
			foreach (var position in remove)
			{
				DeleteMenu(menu.Handle, (uint)position, MenuFlags.MF_BYPOSITION);
			}
		}

		private void TagManagedMenuItems(Menu menu, int tag)
		{
			var info = new MENUINFO();
			info.cbSize = (uint)Marshal.SizeOf(info);
			info.fMask = MenuInfoMember.MIM_MENUDATA;
			info.dwMenuData = (UIntPtr)tag;

			foreach (MenuItem item in menu.MenuItems)
			{
				SetMenuInfo(item.Handle, info);
			}
		}
#endif

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