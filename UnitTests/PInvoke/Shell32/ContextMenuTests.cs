using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ContextMenuTests
{
	[Test]
	public void QueryTest([Values] CMF cmf)
	{
		var pshi = SHCreateItemFromParsingName<IShellItem>(TestCaseSources.WordDoc);
		Assert.NotNull(pshi);
		var pcm = pshi!.BindToHandler<IContextMenu>(null, BHID.BHID_SFUIObject.Guid());
		using var hmenu = CreatePopupMenu();
		Assert.That(pcm.QueryContextMenu(hmenu, 0, 1, int.MaxValue, cmf), ResultIs.Successful);
		var miis = MenuItemInfo.GetMenuItems(hmenu);
		using var memstr = new SafeCoTaskMemString(1024, CharSet.Ansi);
		for (int i = 0; i < miis.Length; i++)
			ShowMII(miis[i], i);
		if (cmf == CMF.CMF_NORMAL)
		{
			var oid = miis.First(m => m.Verb == "properties").Id;
			var cix = new CMINVOKECOMMANDINFOEX((int)oid - 1);
			pcm.InvokeCommand(cix);
		}

		void ShowMII(MenuItemInfo mii, int c, int indent = 0)
		{
			mii.Verb = mii.Type == MenuItemType.MFT_STRING && pcm.GetCommandString((IntPtr)(int)(mii.Id - 1), GCS.GCS_VERBA, default, memstr, memstr.Size) == HRESULT.S_OK ? memstr.ToString() ?? "" : "";
			TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) {mii.Text} (#{mii.Id}) - Type={mii.Type}; State={mii.State}; Verb={mii.Verb}");
			for (int j = 0; j < mii.SubMenus.Length; j++)
				ShowMII(mii.SubMenus[j], j, indent + 1);
		}
	}

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
			Id = mii.wID;
			Text = mii.fType.IsFlagSet(MenuItemType.MFT_SEPARATOR) ? "-" : mii.fType.IsFlagSet(MenuItemType.MFT_STRING) ? strmem.ToString(-1, CharSet.Auto) ?? "" : "";
			Type = mii.fType;
			State = mii.fState;
			BitmapHandle = mii.hbmpItem;
			SubMenus = GetMenuItems(mii.hSubMenu);
		}

		public static MenuItemInfo[] GetMenuItems(HMENU hMenu)
		{
			if (hMenu.IsNull)
				return new MenuItemInfo[0];

			var SubMenus = new MenuItemInfo[GetMenuItemCount(hMenu)];
			for (uint i = 0; i < SubMenus.Length; i++)
				SubMenus[i] = new MenuItemInfo(hMenu, i);
			return SubMenus;
		}

		public uint Id { get; }
		public string Text { get; }
		public MenuItemType Type { get; }
		public MenuItemState State { get; }
		public MenuItemInfo[] SubMenus { get; }
		public HBITMAP BitmapHandle { get; }
		public string? Verb { get; internal set; }
	}

}