using NUnit.Framework;
using System.Threading;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ShellContextMenuTests
{
	[Test]
	public void CreateTest()
	{
		//using var shi = ShellItem.Open(TestCaseSources.TempDir);
		using var shi = ShellItem.Open(@"C:\Windows");
		using var menu = new ShellContextMenu(shi);
		var items = menu.GetItems(CMF.CMF_EXTENDEDVERBS | CMF.CMF_EXPLORE | CMF.CMF_CANRENAME | CMF.CMF_ITEMMENU);
		for (var i = 0; i < items.Length; i++)
			ShowMII(items[i], i);
	}

	[Test]
	public void CreateTest2()
	{
		using var shi = ShellItem.Open(TestCaseSources.ImageFile);
		using var shi2 = ShellItem.Open(TestCaseSources.Image2File);
		using var menu = new ShellContextMenu(shi, shi2);
		var items = menu.GetItems(CMF.CMF_EXTENDEDVERBS | CMF.CMF_EXPLORE | CMF.CMF_CANRENAME | CMF.CMF_ITEMMENU);
		for (var i = 0; i < items.Length; i++)
			ShowMII(items[i], i);
	}

	[Test]
	public void CreateTest3()
	{
		using var shi = ShellItem.Open(TestCaseSources.WordDoc);
		var items = shi.ContextMenu.GetItems(CMF.CMF_EXTENDEDVERBS);
		shi.ContextMenu.InvokeVerb(items[0].Verb!);
		Thread.Sleep(2000);
		Assert.That(!Vanara.PInvoke.User32.FindWindow(null, "Microsoft Word").IsNull);
	}

	[Test]
	public void ShowTest()
	{
		using var shi = ShellItem.Open(@"C:\Windows");
		shi.ContextMenu.ShowContextMenu(new(100,100), onMenuItemClicked: (m, i, w) => TestContext.WriteLine($"Clicked {i}"));
	}

	[Test]
	public void TestRepeatFail()
	{
		for (int i = 0; i < 20; i++)
		{
			using ShellItem Item = ShellItem.Open(TestCaseSources.ImageFile);
			using ShellContextMenu ContextMenu = new(Item);
			TestContext.WriteLine(ContextMenu.ComInterface.GetType().Name);
		}
	}

	[Test]
	public void InvokeVerbTest()
	{
		using var shi = ShellItem.Open(TestCaseSources.ImageFile);
		shi.ContextMenu.InvokeVerb("open");
	}

	[Test]
	public void InvokeVerbTest2()
	{
		using var shi = ShellItem.Open(TestCaseSources.TempDir);
		Assert.That(shi.IsFolder);
		shi.ContextMenu.InvokeVerb("Powershell");
	}

	static void ShowMII(ShellContextMenu.MenuItemInfo mii, int c, int indent = 0)
	{
		TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) \"{mii.Text}\" (#{mii.Id}) - Type={mii.Type}; State={mii.State}; Verb={mii.Verb}; Tooltip={mii.HelpText}; IconLoc={mii.VerbIconLocation}");
		for (int j = 0; j < mii.SubMenus.Length; j++)
			ShowMII(mii.SubMenus[j], j, indent + 1);
	}
}