using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Shell32;
using Vanara.InteropServices;

namespace Vanara.Windows.Forms.Controls
{
	/// <summary>
	/// A <see cref="ContextMenuStrip"/> derived class that supports <see cref="IContextMenu"/>.
	/// </summary>
	/// <seealso cref="System.Windows.Forms.ContextMenuStrip" />
	/// <seealso cref="Vanara.PInvoke.Shell32.IContextMenu" />
#pragma warning disable CS0618 // Type or member is obsolete
	[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch), DefaultEvent("Opening"), Description("Context menu strip supporting IContextMenu.")]
#pragma warning restore CS0618 // Type or member is obsolete
	class ShellContextMenu : ContextMenu, IContextMenu
	{
		/// <summary>Initializes a new instance of the <see cref="ShellContextMenu"/> class.</summary>
		/// <param name="menuItems">The menu items.</param>
		public ShellContextMenu(MenuItem[] menuItems) : base(menuItems)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="ShellContextMenu"/> class.</summary>
		public ShellContextMenu() : base()
		{
		}

		HRESULT IContextMenu.QueryContextMenu(HMENU hmenu, uint indexMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags)
		{
			throw new NotImplementedException();
			//if (!uFlags.IsFlagSet(CMF.CMF_DEFAULTONLY) && base.MenuItems.Count > 0)
			//{
			//	var cmdId = idCmdFirst;
			//	var idx = indexMenu;
			//	using var str = new SafeCoTaskMemString(512, CharSet.Auto);
			//	var info = new MENUITEMINFO(0) { dwTypeData = (IntPtr)str };
			//	foreach (var menuItem in base.MenuItems.OfType<MenuItem>().Where(i => i.Visible))
			//	{
			//		info.cch = (uint)str.Capacity;
			//		info.fMask = (MenuItemInfoMask)0x1ffU;
			//		GetMenuItemInfo(Handle, (uint)menuItem.Index, true, ref info);
			//		info.wID = cmdId++;
			//		InsertMenuItem(hmenu, idx++, true, ref info);
			//	}
			//	return HRESULT.Make(false, HRESULT.FacilityCode.FACILITY_NULL, cmdId - idCmdFirst + 1);
			//}
			//return HRESULT.Make(false, HRESULT.FacilityCode.FACILITY_NULL, 0);
		}

		void IContextMenu.InvokeCommand(in CMINVOKECOMMANDINFOEX pici)
		{
			throw new NotImplementedException();
		}

		void IContextMenu.GetCommandString(IntPtr idCmd, GCS uType, IntPtr pReserved, IntPtr pszName, uint cchMax)
		{
			throw new NotImplementedException();
		}
	}
}
