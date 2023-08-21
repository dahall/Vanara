using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ShellDataTests
{
	[Test]
	public void FromFolderTest()
	{
		// Create empty table
		var timer = Stopwatch.StartNew();
		var shData = new ShellDataTable(new ShellFolder(KNOWNFOLDERID.FOLDERID_Documents), FolderItemFilter.NonFolders | FolderItemFilter.Folders | FolderItemFilter.IncludeHidden);
		TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** Init complete **");

		// Get list of default and slow columns to fetch
		var cols = new List<DataColumn>();
		cols.AddRange(shData.Columns.Cast<DataColumn>().Where(c => ((SHCOLSTATE)c.ExtendedProperties["ColState"]!).IsFlagSet(SHCOLSTATE.SHCOLSTATE_ONBYDEFAULT)));
		cols.AddRange(shData.Columns.Cast<DataColumn>().Where(c => (bool)c.ExtendedProperties["Slow"]! && c.ColumnName.StartsWith("System.Document.")));
		TestContext.WriteLine(string.Join("\t", cols));

		// Populate table
		shData.RowChanged += ShData_RowChanged;
		shData.AllFastRowsAdded += (s, e) => TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** Fast items complete **");
		shData.TableLoaded += (s, e) => TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** All done **");
		var ct = new CancellationTokenSource();
		shData.PopulateTableAsync(cols, ct.Token).Wait(TimeSpan.FromSeconds(30));

		timer.Stop();

		void ShData_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			if (e.Action == DataRowAction.Add)
				TestContext.WriteLine($"{timer.ElapsedMilliseconds,5}\t+\t" + GetItems());
			else if (e.Action == DataRowAction.Commit)
				TestContext.WriteLine($"{timer.ElapsedMilliseconds,5}\t*\t" + GetItems());

			string GetItems() => string.Join("\t", cols.Select(c => GetColVal(e.Row[c])));
		}
	}

	[Test]
	public void FromItemsTest()
	{
		// Create empty table
		var timer = Stopwatch.StartNew();
		var items = new[] { ShellItem.Open(TestCaseSources.SmallFile), ShellItem.Open(TestCaseSources.TempDir), ShellItem.Open(TestCaseSources.BmpFile), ShellItem.Open(TestCaseSources.DummyFile), ShellItem.Open(TestCaseSources.LargeFile) };
		var shData = new ShellDataTable(items);
		TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** Init complete **");

		// Get list of default and slow columns to fetch
		var cols = shData.Columns.Cast<DataColumn>().Take(20).ToList();
		TestContext.WriteLine("\t\t" + string.Join("\t", cols));

		// Populate table
		shData.RowChanged += ShData_RowChanged;
		shData.AllFastRowsAdded += (s, e) => TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** Fast items complete **");
		shData.TableLoaded += (s, e) => TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** All done **");
		var ct = new CancellationTokenSource();
		shData.PopulateTableAsync(cols, ct.Token).Wait(TimeSpan.FromSeconds(30));

		timer.Stop();

		void ShData_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			if (e.Action == DataRowAction.Add)
				TestContext.WriteLine($"{timer.ElapsedMilliseconds,5}\t+\t" + GetItems());
			else if (e.Action == DataRowAction.Commit)
				TestContext.WriteLine($"{timer.ElapsedMilliseconds,5}\t*\t" + GetItems());

			string GetItems() => string.Join("\t", cols.Select(c => GetColVal(e.Row[c])));
		}
	}

	[Test]
	public void ShellItemDataTest()
	{
		const int cnt = 5;
		var obj = new ShellDataObject(new ShellFolder(TestCaseSources.TempDir).EnumerateChildren(FolderItemFilter.NonFolders).Take(cnt));

		Assert.IsTrue(obj.ContainsFileDropList());
		Assert.IsTrue(obj.ContainsShellIdList());
		Assert.That(obj.GetData(ShellClipboardFormat.CFSTR_SHELLIDLIST, false), Has.Exactly(cnt).Items);
	}

	[Test]
	public void GetDataTest()
	{
		var obj = new ShellDataObject(new[] { new ShellItem(TestCaseSources.WordDoc) });

		Assert.IsTrue(obj.GetDataPresent(ShellClipboardFormat.CFSTR_FILEDESCRIPTORW));
		var fd = obj.GetData(ShellClipboardFormat.CFSTR_FILEDESCRIPTORW, true);
		Assert.IsTrue(fd is ShellFileDescriptor[]);
		Assert.That((ShellFileDescriptor[])fd, Has.Exactly(1).Items);
		Assert.That(((ShellFileDescriptor[])fd)[0].Info.Name, Is.EqualTo(System.IO.Path.GetFileName(TestCaseSources.WordDoc)));

		Assert.IsTrue(obj.GetDataPresent(ShellClipboardFormat.CFSTR_FILECONTENTS));
		var fc = obj.GetData(ShellClipboardFormat.CFSTR_FILECONTENTS, true);
		Assert.IsTrue(fc is System.IO.Stream[]);
		Assert.That((System.IO.Stream[])fc, Has.Exactly(1).Items);
		Assert.That(((System.IO.Stream[])fc)[0].Length, Is.EqualTo(new System.IO.FileInfo(TestCaseSources.WordDoc).Length));
	}

	[TestCase("<a href=\"http://www.contoso.com\">Contoso</a>")]
	[TestCase("<html><body><a href=\"http://www.contoso.com\">Contoso</a></body></html>")]
	public void FormatHtmlForClipboardTest(string snippet)
	{
		var bytes = FormatHtmlForClipboard(snippet);
		string str = Encoding.UTF8.GetString(bytes);
		TestContext.WriteLine(str);

		var extr = GetHtmlFromClipboard(bytes);
		Assert.That(snippet, Is.EqualTo(extr));
	}

	[Test]
	public void GetProps()
	{
		var obj = new ShellDataObject();

		Assert.That(obj.Culture, Is.EqualTo(System.Globalization.CultureInfo.CurrentCulture));
		var cult = new System.Globalization.CultureInfo("fr");
		Assert.That(() => obj.Culture = cult, Throws.Nothing);
		Assert.That(obj.Culture, Is.EqualTo(cult));

		Assert.That(obj.InDragLoop, Is.False);
		Assert.That(() => obj.InDragLoop = true, Throws.Nothing);
		Assert.That(obj.InDragLoop, Is.True);

		Assert.That(obj.PreferredDropEffect, Is.EqualTo(System.Windows.Forms.DragDropEffects.None));
		var de = System.Windows.Forms.DragDropEffects.Copy;
		Assert.That(() => obj.PreferredDropEffect = de, Throws.Nothing);
		Assert.That(obj.PreferredDropEffect, Is.EqualTo(de));

		Assert.That(obj.TargetClsid, Is.EqualTo(default(Guid)));
		var cl = Guid.NewGuid();
		Assert.That(() => obj.TargetClsid = cl, Throws.Nothing);
		Assert.That(obj.TargetClsid, Is.EqualTo(cl));
	}

	private static string GetColVal(object? o) => o switch
	{
		null => string.Empty,
		DBNull _ => string.Empty,
		string[] a => string.Join(",", a),
		_ => o.ToString() ?? string.Empty,
	};
}