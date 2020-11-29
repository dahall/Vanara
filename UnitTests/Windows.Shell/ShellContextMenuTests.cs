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
			using var menu = new ShellContextMenu(new ShellItem(TestCaseSources.WordDoc));
			var items = menu.GetItems();
			for (var i = 0; i < items.Length; i++)
				ShowMII(items[i], i);

			static void ShowMII(ShellContextMenu.MenuItemInfo mii, int c, int indent = 0)
			{
				TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) \"{mii.Text}\" (#{mii.Id}) - Type={mii.Type}; State={mii.State}; Verb={mii.Verb}; Tooltip={mii.HelpText}; IconLoc={mii.VerbIconLocation}");
				for (int j = 0; j < mii.SubMenus.Length; j++)
					ShowMII(mii.SubMenus[j], j, indent + 1);
			}
		}
	}
}