using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture, SingleThreaded]
	public class ShellItemTests
	{
		internal const string badTestDoc = @"C:\Temp\BadTest.doc";
		internal static readonly string testDoc = PInvoke.Tests.TestCaseSources.WordDoc;
		internal static readonly string testLinkDoc = PInvoke.Tests.TestCaseSources.WordDocLink;

		[Test]
		public void EqualityTest()
		{
			using var i = new ShellItem(testDoc);
			using var l = new ShellLink(testLinkDoc);
			using var lt = l.Target;
			Assert.That(i == lt, Is.True);
			Assert.That(i != lt, Is.False);
			Assert.That(i.Equals(lt), Is.True);
			Assert.That(i.CompareTo(lt), Is.Zero);
			Assert.That(i.CompareTo(l), Is.Not.Zero);
			Assert.That(((IComparable<ShellItem>)i).CompareTo(lt), Is.Zero);
			Assert.That(((IComparable<ShellItem>)i).CompareTo(l), Is.Not.Zero);
			Assert.That(i.Equals(lt.IShellItem), Is.True);
			Assert.That(i.Equals(lt.Name), Is.False);
			Assert.That(i.Equals((object)null), Is.False);
			Assert.That(i.Equals((IShellItem)null), Is.False);
			Assert.That(i.Equals((ShellItem)null), Is.False);
			Assert.That(i.GetHashCode(), Is.EqualTo(lt.GetHashCode()));
		}

		[Test]
		public void GetAttrTest()
		{
			Assert.That(() =>
			  {
				  using var i = new ShellItem(testDoc);
				  Assert.That(i.Attributes, Is.Not.Zero);
				  Assert.That(i.FileInfo.FullName, Is.EqualTo(testDoc));
				  Assert.That(i.IsFileSystem, Is.True);
				  Assert.That(i.IsFolder, Is.False);
				  Assert.That(i.IsLink, Is.False);
				  Assert.That(i.IShellItem, Is.Not.Null);
				  Assert.That(i.Name, Is.EqualTo(System.IO.Path.GetFileName(testDoc)));
				  Assert.That(i.ParsingName, Is.EqualTo(testDoc));
				  Assert.That(i.Name, Is.EqualTo(i.ToString()));
				  Assert.That(i.ToolTipText, Is.Not.Null);
			  }, Throws.Nothing);
		}

		[Test]
		public void GetDisplayNameTest()
		{
			using var i = new ShellItem(testDoc);
			Assert.That(i.GetDisplayName(ShellItemDisplayString.FileSysPath), Is.EqualTo(testDoc).IgnoreCase);
			foreach (ShellItemDisplayString e in Enum.GetValues(typeof(ShellItemDisplayString)))
				Assert.That(() => TestContext.WriteLine($"{e}={i.GetDisplayName(e)}"), Throws.Nothing);
			Assert.That(i.GetDisplayName((ShellItemDisplayString)0x8fffffff), Is.EqualTo(i.GetDisplayName(0)));
		}

		[Test]
		public void GetHandlerTest()
		{
			using var i = new ShellItem(testDoc);
			var ps = i.GetHandler<PropSys.IPropertyStore>(BHID.BHID_PropertyStore);
			Assert.That(ps, Is.Not.Null.And.InstanceOf<PropSys.IPropertyStore>());
			System.Runtime.InteropServices.Marshal.ReleaseComObject(ps);
			ps = i.GetHandler<PropSys.IPropertyStore>();
			Assert.That(ps, Is.Not.Null.And.InstanceOf<PropSys.IPropertyStore>());
			System.Runtime.InteropServices.Marshal.ReleaseComObject(ps);
			var ei = i.GetHandler<IExtractIcon>();
			Assert.That(ei, Is.Not.Null.And.InstanceOf<IExtractIcon>());
			//Assert.That(() => i.GetHandler<IExtractIcon>(), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void GetHandlerTest2()
		{
			using var shellItem = new ShellItem(PInvoke.Tests.TestCaseSources.LargeFile);
			if (!shellItem.IsFolder)
				TestContext.WriteLine(shellItem.Properties[PROPERTYKEY.System.MIMEType]);

			using var stream = shellItem.GetStream(STGM.STGM_READ | STGM.STGM_SIMPLE);
			TestContext.WriteLine(((FormattableString)$"{shellItem.FileSystemPath} ({stream.Length:B3})").ToString(ByteSizeFormatter.Instance));
		}

		[Test]
		public void GetImageTest()
		{
			using (var i = new ShellItem(testDoc))
			{
				var sz = new Size(32, 32);
				var bmp = i.GetImage(sz, ShellItemGetImageOptions.IconOnly);
				Assert.That(bmp, Is.Not.Null);
				Assert.That(bmp.Size, Is.EqualTo(sz));
			}
			using (var i = new ShellItem(PInvoke.Tests.TestCaseSources.ImageFile))
			{
				var sz = new Size(1024, 1024);
				var bmp = i.GetImage(sz, ShellItemGetImageOptions.ThumbnailOnly | ShellItemGetImageOptions.ScaleUp);
				Assert.That(bmp.Size, Is.EqualTo(sz));
			}
		}

		[Test]
		public void GetImageTest2()
		{
			var f = new ShellFolder(KNOWNFOLDERID.FOLDERID_AppsFolder);
			foreach (var i in f.EnumerateChildren(FolderItemFilter.NonFolders | FolderItemFilter.Folders))
				Assert.That(() => i.GetImage(new Size(32, 32), ShellItemGetImageOptions.BiggerSizeOk), Throws.Nothing);
		}

		[Test]
		public void GetParentTest()
		{
			Assert.That(() =>
			  {
				  using var i = new ShellItem(testDoc);
				  using var p = new ShellItem(System.IO.Path.GetDirectoryName(testDoc));
				  Assert.That(i.Parent == p, Is.True);
				  Assert.That(ShellFolder.Desktop.Parent, Is.Null);
			  }, Throws.Nothing);
		}

		[Test]
		public void GetPIDLTest()
		{
			Assert.That(() =>
			  {
				  using var i = new ShellItem(testDoc);
				  using var p = new PIDL(testDoc);
				  Assert.That(i.PIDL.Equals(p), Is.True);
			  }, Throws.Nothing);
		}

		[Test]
		public void GetPropDescListTest()
		{
			Assert.That(() =>
			  {
				  using var i = new ShellItem(testDoc);
				  using var pdl = i.GetPropertyDescriptionList();
				  Assert.That(pdl.Count, Is.GreaterThan(0));
				  foreach (var d in pdl)
				  {
					  Assert.That(d.TypeFlags, Is.Not.Zero);
					  Debug.WriteLine($"Property '{d.DisplayName}' is of type '{d.PropertyType?.Name}'");
				  }
			  }, Throws.Nothing);
		}

		[Test]
		public void GetPropTest()
		{
			using var i = new ShellItem(testDoc);
			Assert.That(i.Properties.Count, Is.GreaterThan(0));
			Assert.That(i.Properties[PROPERTYKEY.System.Author], Has.Member("TestAuthor"));
			Assert.That(i.Properties[PROPERTYKEY.System.ItemTypeText], Does.StartWith("Microsoft Word"));
			Assert.That(i.Properties[PROPERTYKEY.System.DateAccessed], Is.TypeOf<FILETIME>());
			Assert.That(i.Properties[new PROPERTYKEY()], Is.Null);
			Assert.That(i.Properties[new PROPERTYKEY(Guid.NewGuid(), 2)], Is.Null);

			Assert.That(i.Properties["System.Author"], Has.Member("TestAuthor"));
			Assert.That(i.Properties["DocAuthor"], Has.Member("TestAuthor"));
			Assert.That(() => i.Properties[null], Throws.Exception);
			Assert.That(() => i.Properties["Arthur"], Throws.Exception);

			Assert.That(i.Properties.GetProperty<string>(PROPERTYKEY.System.ApplicationName), Is.InstanceOf<string>().And.StartWith("Microsoft"));
			Assert.That(() => i.Properties.GetProperty<int>(PROPERTYKEY.System.ApplicationName), Throws.Exception);
		}

		[Test]
		public void GetToolTipTest()
		{
			using var i = new ShellItem(testDoc);
			foreach (ShellItemToolTipOptions e in Enum.GetValues(typeof(ShellItemToolTipOptions)))
			{
				Assert.That(() =>
				{
					var s = i.GetToolTip(e);
					Debug.WriteLine($"{e}={s}");
				}, Throws.Nothing);
			}
		}

		[Test]
		public void InvokeVerbTest()
		{
			using var i = new ShellItem(testDoc);
			Assert.That(() => i.InvokeVerb("ViewProtected"), Throws.Nothing);
		}

		[Test]
		public void ShellItemTest1()
		{
			Assert.That(() =>
			{
				using var i = new ShellItem(testDoc);
				Assert.That(i.FileSystemPath, Is.EqualTo(testDoc));
				i.Update();
			}, Throws.Nothing);
			Assert.That(() => new ShellItem((string)null), Throws.ArgumentNullException);
			Assert.That(() => new ShellItem(badTestDoc), Throws.InstanceOf<System.IO.FileNotFoundException>());
		}

		[Test]
		public void ShellItemTest2()
		{
			Assert.That(() =>
			{
				using var i = new ShellItem(KNOWNFOLDERID.FOLDERID_Documents.PIDL());
				Assert.That(i.FileSystemPath, Is.EqualTo(KNOWNFOLDERID.FOLDERID_Documents.FullPath()));
			}, Throws.Nothing);
			Assert.That(() => new ShellItem(PIDL.Null), Throws.Exception);
		}

		[Test]
		public void ToUriTest()
		{
			using var i = new ShellItem(testDoc);
			var testDocUri = new Uri(testDoc);
			Assert.That(testDocUri, Is.EqualTo(i.ToUri()));

			using var f = new ShellFolder(KNOWNFOLDERID.FOLDERID_ControlPanelFolder);
			Assert.That(f.ToUri().ToString(), Is.EqualTo("shell:::" + KNOWNFOLDERID.FOLDERID_ControlPanelFolder.Guid().ToString("B")));

			using var d = new ShellItem(Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Documents\debug.log"));
			Assert.That(d.ToUri().ToString(), Is.EqualTo("shell:::{f42ee2d3-909f-4907-8871-4c22fc0bf756}/debug.log"));

			using var td = new ShellItem(d.ToUri().ToString());
			td.FileSystemPath.WriteValues();
		}
	}
}