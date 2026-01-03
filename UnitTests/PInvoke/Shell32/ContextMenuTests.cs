using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ContextMenuTests
{
	const uint m_CmdFirst = 1;

	private static IEnumerable<TestCaseData> CreateSources()
	{
		var shi = TestCaseSources.ImageFile;
		(string? f, string[] i)[] items =
		[
			(null, []), // Desktop
			(null, [TestCaseSources.TempDir]), // Folder
			(null, [shi]), // Single file
			(null, [shi, TestCaseSources.Image2File]), // Multiple files, same parent
			(null, [shi, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "notepad.exe")]), // Multiple files, different parents
			(TestCaseSources.TempDir, []), // Folder as parent
			(TestCaseSources.TempDir, [TestCaseSources.TempDir]), // Folder
			(TestCaseSources.TempDir, [shi]), // Single file
			(TestCaseSources.TempDir, [shi, TestCaseSources.Image2File]), // Multiple files, same parent
			(@"C:\", [shi, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "notepad.exe")]), // Multiple files, different parents
		];
		foreach ((string? f, string[] i) s in items)
		{
			foreach (var e in Enum.GetValues<CMF>())
			{
				yield return new TestCaseData(e, s.f is null ? null : MakeFolder(s.f!), Array.ConvertAll(s.i, i => SHCreateItemFromParsingName<IShellItem>(i)))
					.SetArgDisplayNames(e.ToString(), s.f is null ? "null" : System.IO.Path.GetFileName(s.f), $"[{string.Join(",", s.i.Select(i => System.IO.Path.GetFileName(i)))}]");
			}
		}

		static IShellFolder MakeFolder(string path)
		{
			SHCreateItemHandlerFromParsingName(path, out IShellFolder? ppv, BHID.BHID_SFObject).ThrowIfFailed();
			return ppv!;
		}
	}

	[Test]
	public void SHCreateDefaultContextMenuTest([Values] CMF cmf)
	{
		Assert.That(SHParseDisplayName(TestCaseSources.ImageFile, default, out var pidlChild, 0, out _), ResultIs.Successful);
		Assert.That(SHParseDisplayName(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "notepad.exe"), default, out var pidlChild2, 0, out _), ResultIs.Successful);
		Assert.That(SHParseDisplayName(System.IO.Path.GetPathRoot(TestCaseSources.TempDir)!, default, out var pidlFolder, 0, out _), ResultIs.Successful);
		Assert.That(SHBindToObject(null, pidlFolder, null, out IShellFolder? pshf), ResultIs.Successful);
		//Assert.That(SHGetDesktopFolder(out IShellFolder? pContainingFolder), ResultIs.Successful);

		Assert.That(SHCreateDefaultContextMenu(new DEFCONTEXTMENU(pshf!, [pidlChild, pidlChild2], null, out _), out IContextMenu3? pcm), ResultIs.Successful);
		Assert.That(pcm, Is.Not.Null);

		using var hmenu = CreatePopupMenu();
		HRESULT hr;
		Assert.That(hr = pcm!.QueryContextMenu(hmenu, 0, m_CmdFirst, 0x7FFF, cmf), ResultIs.Successful);
		TestContext.WriteLine($"Menu items: {hr.Code}");
		Assert.That(hr.Code, Is.GreaterThan(0));
		var miis = MenuItemInfo.GetMenuItems(hmenu, pcm);
		for (int i = 0; i < miis.Length; i++)
			ShowMII(miis[i], i);
	}

	[TestCaseSource(nameof(CreateSources))]
	public void SHCreateDefaultContextMenuTest2(CMF cmf, IShellFolder? folder, IShellItem[] items)
	{
		var pcm = SHCreateDefaultContextMenuEx(folder, out _, items);
		Assert.That(pcm, Is.Not.Null);

		using var hmenu = CreatePopupMenu();
		HRESULT hr;
		Assert.That(hr = pcm!.QueryContextMenu(hmenu, 0, m_CmdFirst, 0x7FFF, cmf), ResultIs.Successful);
		TestContext.WriteLine($"Menu items: {hr.Code}");
		Assert.That(hr.Code, Is.GreaterThan(0));
		var miis = MenuItemInfo.GetMenuItems(hmenu, pcm);
		for (int i = 0; i < miis.Length; i++)
			ShowMII(miis[i], i);
	}

	[Test]
	public void QueryFolderTest([Values] CMF cmf)
	{
		var pshi = SHCreateItemFromParsingName<IShellItem>(TestCaseSources.TempDir);
		Assert.That(pshi, Is.Not.Null);
		var pshf = pshi!.BindToHandler<IShellFolder>(null, BHID.BHID_SFObject);
		Assert.That(pshi, Is.Not.Null);
		var pcm = pshf.CreateViewObject<IContextMenu>(HWND.NULL)!;
		using var hmenu = CreatePopupMenu();
		HRESULT hr;
		Assert.That(hr = pcm.QueryContextMenu(hmenu, 0, m_CmdFirst, 0x7FFF, cmf), ResultIs.Successful);
		TestContext.WriteLine($"Menu items: {hr.Code}");
		Assert.That(hr.Code, Is.GreaterThan(0));
		var miis = MenuItemInfo.GetMenuItems(hmenu, pcm);
		for (int i = 0; i < miis.Length; i++)
			ShowMII(miis[i], i);
		if (cmf == CMF.CMF_NORMAL)
		{
			CMINVOKECOMMANDINFOEX cix = new(new SafeResourceId("properties"), useUnicode: true);
			Assert.That(pcm.InvokeCommand(cix), ResultIs.Successful);
		}
	}

	[Test]
	public void QueryItemTest([Values] CMF cmf)
	{
		const uint mStartId = 1;
		var pshi = SHCreateItemFromParsingName<IShellItem>(TestCaseSources.ImageFile);
		Assert.That(pshi, Is.Not.Null);
		var pcm = pshi!.BindToHandler<IContextMenu>(null, BHID.BHID_SFUIObject);
		using var hmenu = CreatePopupMenu();
		HRESULT hr;
		Assert.That(hr = pcm.QueryContextMenu(hmenu, 0, mStartId, 0x7FFF, cmf), ResultIs.Successful);
		TestContext.WriteLine($"Menu items: {hr.Code}");
		Assert.That(hr.Code, Is.GreaterThan(0));
		var miis = MenuItemInfo.GetMenuItems(hmenu, pcm);
		for (int i = 0; i < miis.Length; i++)
			ShowMII(miis[i], i);
		if (cmf == CMF.CMF_NORMAL)
		{
			CMINVOKECOMMANDINFOEX cix = new(new SafeResourceId("properties"), useUnicode: true);
			Assert.That(pcm.InvokeCommand(cix), ResultIs.Successful);
		}
	}

	[Test]
	public void QueryItemsTest([Values] CMF cmf)
	{
		const uint mStartId = 1;
		IShellItem pshi = SHCreateItemFromParsingName<IShellItem>(TestCaseSources.ImageFile)!;
		Assert.That(pshi, Is.Not.Null);
		IShellItem pshi2 = SHCreateItemFromParsingName<IShellItem>(TestCaseSources.Image2File)!;
		Assert.That(pshi2, Is.Not.Null);

		var pidls = Array.ConvertAll([pshi, pshi2], si => { SHGetIDListFromObject(si!, out var pidl).ThrowIfFailed(); return pidl; });
		var parent = PIDL.FindCommonParent(pidls);
		var relPidls = Array.ConvertAll(pidls, p => p.GetRelativeTo(parent));
		var parentFolder = SHBindToObject<IShellFolder>(null, parent, null);
		var pcm = parentFolder!.GetUIObjectOf<IContextMenu>(HWND.NULL, relPidls);

		using var hmenu = CreatePopupMenu();
		HRESULT hr;
		Assert.That(hr = pcm.QueryContextMenu(hmenu, 0, mStartId, 0x7FFF, cmf), ResultIs.Successful);
		TestContext.WriteLine($"Menu items: {hr.Code}");
		Assert.That(hr.Code, Is.GreaterThan(0));
		var miis = MenuItemInfo.GetMenuItems(hmenu, pcm);
		for (int i = 0; i < miis.Length; i++)
			ShowMII(miis[i], i);
		if (cmf == CMF.CMF_NORMAL)
		{
			CMINVOKECOMMANDINFOEX cix = new(new SafeResourceId("properties"), useUnicode: true);
			Assert.That(pcm.InvokeCommand(cix), ResultIs.Successful);
		}
	}

	[Test]
	public void QueryItems2Test([Values] CMF cmf)
	{
		const uint mStartId = 1;
		IShellItem pshi = SHCreateItemFromParsingName<IShellItem>(TestCaseSources.ImageFile)!;
		Assert.That(pshi, Is.Not.Null);
		IShellItem pshi2 = SHCreateItemFromParsingName<IShellItem>("C:\\Windows\\notepad.exe")!;
		Assert.That(pshi2, Is.Not.Null);

		var pidls = Array.ConvertAll([pshi, pshi2], si => { SHGetIDListFromObject(si!, out var pidl).ThrowIfFailed(); return pidl; });
		var parent = PIDL.FindCommonParent(pidls);
		var relPidls = Array.ConvertAll(pidls, p => p.GetRelativeTo(parent));
		var parentFolder = SHBindToObject<IShellFolder>(null, parent, null);
		var pcm = parentFolder!.GetUIObjectOf<IContextMenu>(HWND.NULL, relPidls);

		using var hmenu = CreatePopupMenu();
		HRESULT hr;
		Assert.That(hr = pcm.QueryContextMenu(hmenu, 0, mStartId, 0x7FFF, cmf), ResultIs.Successful);
		TestContext.WriteLine($"Menu items: {hr.Code}");
		Assert.That(hr.Code, Is.GreaterThan(0));
		var miis = MenuItemInfo.GetMenuItems(hmenu, pcm);
		for (int i = 0; i < miis.Length; i++)
			ShowMII(miis[i], i);
		if (cmf == CMF.CMF_NORMAL)
		{
			CMINVOKECOMMANDINFOEX cix = new(new SafeResourceId("properties"), useUnicode: true);
			Assert.That(pcm.InvokeCommand(cix), ResultIs.Successful);
		}
	}

	static void ShowMII(MenuItemInfo mii, int c, int indent = 0)
	{
		if (mii.Text is "" or "-")
			TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) \"{mii.Text}\" (#{mii.Id}) - Type={mii.Type}; State={mii.State}");
		else
			TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) \"{mii.Text}\" (#{mii.Id}) - Type={mii.Type}; State={mii.State}; Verb={mii.Verb}; Tooltip={mii.HelpText}; IconLoc={mii.VerbIconLocation}");
		for (int j = 0; j < mii.SubMenus.Length; j++)
			ShowMII(mii.SubMenus[j], j, indent + 1);
	}

	public class MenuItemInfo
	{
		internal MenuItemInfo(HMENU hMenu, int idx, IContextMenu? cm)
		{
			// Get the string length
			MENUITEMINFO miis = new(MenuItemInfoMask.MIIM_STRING);
			GetMenuItemInfo(hMenu, (uint)Math.Abs(idx), idx >= 0, ref miis);
			using SafeCoTaskMemString strmem = new((int)miis.cch + 1, CharSet.Auto);

			// Get all the details
			MENUITEMINFO mii = new(MenuItemInfoMask.MIIM_ID | MenuItemInfoMask.MIIM_SUBMENU | MenuItemInfoMask.MIIM_FTYPE | (miis.cch == 0 ? 0 : MenuItemInfoMask.MIIM_STRING) | MenuItemInfoMask.MIIM_STATE | MenuItemInfoMask.MIIM_BITMAP)
			{
				dwTypeData = (IntPtr)strmem,
				cch = (uint)strmem.Capacity
			};
			Win32Error.ThrowLastErrorIfFalse(GetMenuItemInfo(hMenu, (uint)Math.Abs(idx), idx >= 0, ref mii));
			Id = unchecked((int)mii.wID);
			Text = mii.fType.IsFlagSet(MenuItemType.MFT_SEPARATOR) ? "-" : mii.fType.IsFlagSet(MenuItemType.MFT_STRING) ? mii.dwTypeData.ToString() ?? "" : "";
			Type = mii.fType;
			State = mii.fState;
			BitmapHandle = mii.hbmpItem;
			if (cm is not null && !mii.fType.IsFlagSet(MenuItemType.MFT_SEPARATOR))
			{
				uint id = mii.wID - m_CmdFirst;
				Verb = cm.GetCommandString(id, GCS.GCS_VERBW, out var mStr).Succeeded ? mStr : null;
				HelpText = cm.GetCommandString(id, GCS.GCS_HELPTEXTW, out mStr).Succeeded ? mStr : null;
				VerbIconLocation = cm.GetCommandString(id, GCS.GCS_VERBICONW, out mStr).Succeeded ? mStr : null;
			}
			SubMenus = GetMenuItems(mii.hSubMenu, cm);
		}

		public static MenuItemInfo[] GetMenuItems(HMENU hMenu, IContextMenu? cm)
		{
			var SubMenus = new MenuItemInfo[hMenu.IsNull ? 0 : GetMenuItemCount(hMenu)];
			for (int i = 0; i < SubMenus.Length; i++)
				SubMenus[i] = new(hMenu, i, cm);
			return SubMenus;
		}

		public int Id { get; }
		public string Text { get; }
		public MenuItemType Type { get; }
		public MenuItemState State { get; }
		public MenuItemInfo[] SubMenus { get; }
		public HBITMAP BitmapHandle { get; }
		public string? Verb { get; internal set; }
		public string? HelpText { get; internal set; }
		public string? VerbIconLocation { get; internal set; }
	}

}