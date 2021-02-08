using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ShellContextMenuTests
	{
		[Test]
		public void CreateTest()
		{
			using var shi = ShellItem.Open(TestCaseSources.TempDir);
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
		public void TestRepeatFail()
		{
			for (int i = 0; i < 20; i++)
			{
				using ShellItem Item = ShellItem.Open(TestCaseSources.ImageFile);
				using ShellContextMenu ContextMenu = new ShellContextMenu(Item);
				TestContext.WriteLine(ContextMenu.ComInterface.GetType().Name);
			}
		}

		static void ShowMII(ShellContextMenu.MenuItemInfo mii, int c, int indent = 0)
		{
			TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) \"{mii.Text}\" (#{mii.Id}) - Type={mii.Type}; State={mii.State}; Verb={mii.Verb}; Tooltip={mii.HelpText}; IconLoc={mii.VerbIconLocation}");
			for (int j = 0; j < mii.SubMenus.Length; j++)
				ShowMII(mii.SubMenus[j], j, indent + 1);
		}
	}
}