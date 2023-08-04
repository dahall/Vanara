using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ShellFileOperationsTests
{
	[Test]
	public void CopyItemTest()
	{
		ShellFileOperations.Copy(new ShellItem(TestCaseSources.LargeFile), ShellFolder.Desktop);
		var dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Path.GetFileName(TestCaseSources.LargeFile));
		Assert.That(File.Exists(dest), Is.True);
		File.Delete(dest);
	}

	[Test]
	public void CopyItemsTest()
	{
		var l = Directory.EnumerateFiles(KNOWNFOLDERID.FOLDERID_Downloads.FullPath(), "h*.zip").Select(s => new ShellItem(s)).ToList();
		ShellFileOperations.Copy(l, ShellFolder.Desktop);
		foreach (var i in l)
		{
			var fn = Path.Combine(ShellFolder.Desktop.FileSystemPath, i.Name);
			Assert.That(File.Exists(fn), Is.True);
			File.Delete(fn);
		}
	}

	[Test]
	public void CopyWithProgressTest()
	{
		// Setup hidden copy op with progress handler
		bool progressShown = false;
		using var op = new ShellFileOperations();
		op.Options = ShellFileOperations.OperationFlags.AddUndoRecord | ShellFileOperations.OperationFlags.NoConfirmMkDir | ShellFileOperations.OperationFlags.Silent;
		op.UpdateProgress += Op_UpdateProgress;

		// Run the operation
		using var shi = new ShellItem(TestCaseSources.LargeFile);
		op.QueueCopyOperation(shi, ShellFolder.Desktop);
		op.PerformOperations();

		// Asert and clean
		Assert.IsTrue(progressShown);
		var dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Path.GetFileName(TestCaseSources.LargeFile));
		File.Delete(dest);

		void Op_UpdateProgress(object sender, System.ComponentModel.ProgressChangedEventArgs args)
		{
			Debug.WriteLine($"{args.UserState}: {args.ProgressPercentage}%");
			progressShown = true;
		}
	}

	[Test]
	public void MoveItemTest()
	{
		// Delete item to Recycle Bin
		using var tmp = new TempFile();
		Assert.That(() => ShellFileOperations.Delete(tmp.FullName), Throws.Nothing);

		// Find deleted item
		using var bin = new ShellFolder(KNOWNFOLDERID.FOLDERID_RecycleBinFolder);
		var item = bin.FirstOrDefault(si => si.Name == tmp.FullName);
		Assert.NotNull(item);

		// Restore item
		using var dest = new ShellFolder(Path.GetDirectoryName(tmp.FullName));
		Assert.That(() => ShellFileOperations.Move(item, dest, null, ShellFileOperations.OperationFlags.NoConfirmation), Throws.Nothing);
		Assert.IsTrue(File.Exists(tmp.FullName));
	}

	[Test]
	public void MoveItemTest2()
	{
		var tmp = new TempFile();
		var winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

		using ShellFileOperations Operation = new ShellFileOperations
		{
			Options = ShellFileOperations.OperationFlags.AddUndoRecord | ShellFileOperations.OperationFlags.NoConfirmMkDir | ShellFileOperations.OperationFlags.Silent
		};
		Operation.UpdateProgress += Operation_UpdateProgress;
		Operation.PostMoveItem += Operation_PostMoveItem;

		using (var fld = new ShellFolder(winDir))
		using (var item = new ShellItem(tmp.FullName))
			Assert.That(() => Operation.QueueMoveOperation(item, fld), Throws.Nothing);
		Assert.That(() => Operation.PerformOperations(), Throws.Nothing);

		var destFile = Path.Combine(winDir, Path.GetFileName(tmp.FullName));
		Assert.IsTrue(File.Exists(destFile));
		File.Delete(destFile);

		Operation.PostMoveItem -= Operation_PostMoveItem;
		Operation.UpdateProgress -= Operation_UpdateProgress;

		static void Operation_PostMoveItem(object sender, ShellFileOperations.ShellFileOpEventArgs e) => Debug.WriteLine($"Post move ({e.DestItem?.Name})...");
		static void Operation_UpdateProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e) => Debug.WriteLine($"Progress: {e.ProgressPercentage}% of {e.UserState}");
	}

	[Test]
	public void MultOpsTest()
	{
		const string newLargeFile = "MuchLongerNameForTheFile.bin";
		using (var op = new ShellFileOperations())
		{
			op.Options |= ShellFileOperations.OperationFlags.NoMinimizeBox;
			var shi = new ShellItem(TestCaseSources.LargeFile);
			op.PostCopyItem += HandleEvent;
			op.QueueCopyOperation(shi, ShellFolder.Desktop);
			var dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Path.GetFileName(TestCaseSources.LargeFile));
			shi = new ShellItem(dest);
			op.QueueMoveOperation(shi, new ShellFolder(KNOWNFOLDERID.FOLDERID_Documents));
			op.PostMoveItem += HandleEvent;
			dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.GetFileName(TestCaseSources.LargeFile));
			shi = new ShellItem(dest);
			op.QueueRenameOperation(shi, newLargeFile);
			op.PostRenameItem += HandleEvent;
			dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), newLargeFile);
			shi = new ShellItem(dest);
			op.QueueDeleteOperation(shi);
			op.PostDeleteItem += HandleEvent;
			op.PerformOperations();
		}

		static void HandleEvent(object sender, ShellFileOperations.ShellFileOpEventArgs args)
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
			var fn = Path.Combine(ShellFolder.Desktop.FileSystemPath, file);
			Assert.That(File.Exists(fn), Is.True);
			File.Delete(fn);
		}

		static void HandleEvent(object sender, ShellFileOperations.ShellFileOpEventArgs args)
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
			op.QueueNewItemOperation(ShellFolder.Desktop, fn, template: Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Custom Office Templates\blank.dotx"));
			op.QueueApplyPropertiesOperation(new ShellItem(fp), p);
			op.PerformOperations();
		}
		Assert.That(new ShellItem(fp).Properties[PROPERTYKEY.System.Author], Is.EquivalentTo(authors));
		File.Delete(fp);

		static void HandleEvent(object sender, ShellFileOperations.ShellFileOpEventArgs args)
		{
			Debug.WriteLine(args);
			Assert.That(args.Result.Succeeded, Is.True);
		}
	}

	[Test]
	public void OpDialogTest()
	{
		var dlg = new ShellFileOperationDialog();
		dlg.AllowUndo = true;
		dlg.CurrentItem = new ShellItem(TestCaseSources.LargeFile);
		dlg.Destination = new ShellFolder(KNOWNFOLDERID.FOLDERID_Desktop);
		dlg.Mode = ShellFileOperationDialog.OperationMode.Indeterminate;
		dlg.Operation = ShellFileOperationDialog.OperationType.CopyMoving;
		dlg.ShowPauseButton = true;
		dlg.Source = new ShellFolder(Path.GetDirectoryName(TestCaseSources.LargeFile));
		dlg.Start();
		dlg.ProgressDialogSizeMaxValue = new FileInfo(TestCaseSources.LargeFile).Length;
		dlg.ProgressDialogItemsMaxValue = 1;
		for (var i = 0; i < 100; i += 5)
		{
			dlg.ProgressBarValue = i;
			dlg.ProgressDialogSizeValue = dlg.ProgressDialogSizeMaxValue * i / 100;
			TestContext.WriteLine($"El:{dlg.ElapsedTime}, Rem:{dlg.RemainingTime}");
			Thread.Sleep(500);
		}
		dlg.Stop();
	}
}
