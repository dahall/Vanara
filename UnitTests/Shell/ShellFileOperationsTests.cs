using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Vanara.Windows.Shell;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace UnitTests
{
	[TestFixture]
	public class ShellFileOperationsTests
	{
		[Test]
		public void CopyItemTest()
		{
			ShellFileOperations.Copy(new ShellItem(@"C:\Users\dahall\Downloads\lubuntu-16.04.2-desktop-amd64.iso"), ShellFolder.Desktop);
			Assert.That(File.Exists(@"C:\Users\dahall\Desktop\lubuntu-16.04.2-desktop-amd64.iso"), Is.True);
			File.Delete(@"C:\Users\dahall\Desktop\lubuntu-16.04.2-desktop-amd64.iso");
		}

		[Test]
		public void CopyItemsTest()
		{
			var l = Directory.EnumerateFiles(@"C:\Users\dahall\Downloads", "h*.zip").Select(s => new ShellItem(s)).ToList();
			ShellFileOperations.Copy(l, ShellFolder.Desktop);
			foreach (var i in l)
			{
				var fn = Path.Combine(@"C:\Users\dahall\Desktop", i.Name);
				Assert.That(File.Exists(fn), Is.True);
				File.Delete(fn);
			}
		}

		[Test]
		public void MultOpsTest()
		{
			using (var op = new ShellFileOperations())
			{
				op.Options |= ShellFileOperations.OperationFlags.NoMinimizeBox;
				var shi = new ShellItem(@"C:\Users\dahall\Downloads\lubuntu-16.04.2-desktop-amd64.iso");
				op.PostCopyItem += HandleEvent;
				op.QueueCopyOperation(shi, ShellFolder.Desktop);
				shi = new ShellItem(@"C:\Users\dahall\Desktop\lubuntu-16.04.2-desktop-amd64.iso");
				op.QueueMoveOperation(shi, new ShellFolder(KNOWNFOLDERID.FOLDERID_Documents));
				op.PostMoveItem += HandleEvent;
				shi = new ShellItem(@"C:\Users\dahall\Documents\lubuntu-16.04.2-desktop-amd64.iso");
				op.QueueRenameOperation(shi, "MuchLongerNameForTheFile.iso");
				op.PostRenameItem += HandleEvent;
				shi = new ShellItem(@"C:\Users\dahall\Documents\MuchLongerNameForTheFile.iso");
				op.QueueDeleteOperation(shi);
				op.PostDeleteItem += HandleEvent;
				op.PerformOperations();
			}

			void HandleEvent(object sender, ShellFileOperations.ShellFileOpEventArgs args)
			{
				Debug.WriteLine(args);
				Assert.That(args.Result.Succeeded, Is.True);
			}
		}

		[Test]
		public void NewItemTest()
		{
			var files = new[] { "test.docx", "test.txt", "test.xlsx" };
			using (var op = new ShellFileOperations())
			{
				foreach (var file in files)
					op.QueueNewItemOperation(ShellFolder.Desktop, file);
				op.PostNewItem += HandleEvent;
				op.PerformOperations();
			}
			foreach (var file in files)
			{
				var fn = Path.Combine(@"C:\Users\dahall\Desktop", file);
				Assert.That(File.Exists(fn), Is.True);
				File.Delete(fn);
			}

			void HandleEvent(object sender, ShellFileOperations.ShellFileOpEventArgs args)
			{
				Debug.WriteLine(args);
				Assert.That(args.Result.Succeeded, Is.True);
			}
		}

		[Test]
		public void SetPropsTest2()
		{
			const string fn = "test.docx";
			var fp = Path.Combine(ShellFolder.Desktop.FileSystemPath, fn);
			var authors = new[] { "David" };
			using (var p = new ShellItemPropertyUpdates { { PROPERTYKEY.System.Author, authors } })
			using (var op = new ShellFileOperations())
			{
				op.PostNewItem += HandleEvent;
				op.QueueNewItemOperation(ShellFolder.Desktop, fn, template: @"C:\Users\dahall\Documents\Custom Office Templates\blank.dotx");
				op.QueueApplyPropertiesOperation(new ShellItem(fp), p);
				op.PerformOperations();
			}
			Assert.That(new ShellItem(fp).Properties[PROPERTYKEY.System.Author], Is.EquivalentTo(authors));
			File.Delete(fp);

			void HandleEvent(object sender, ShellFileOperations.ShellFileOpEventArgs args)
			{
				Debug.WriteLine(args);
				Assert.That(args.Result.Succeeded, Is.True);
			}
		}
	}
}
