using System;
using NUnit.Framework;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using System.IO;
using Vanara.InteropServices;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ShellItemTests
	{
		internal const string badTestDoc = @"C:\Temp\BadTest.doc";
		internal const string testDoc = @"C:\Temp\Test.docx";
		internal const string testLinkDoc = @"C:\Temp\Test.lnk";

		[Test]
		public void ShellItemTest1()
		{
			Assert.That(() =>
			{
				using (var i = new ShellItem(testDoc))
				{
					Assert.That(i.FileSystemPath, Is.EqualTo(testDoc));
					i.Update();
				}
			}, Throws.Nothing);
			Assert.That(() => new ShellItem((string)null), Throws.Exception);
			Assert.That(() => new ShellItem(badTestDoc), Throws.Nothing);
		}

		[Test]
		public void ShellItemTest2()
		{
			Assert.That(() =>
			{
				using (var i = new ShellItem(KNOWNFOLDERID.FOLDERID_Documents.PIDL()))
					Assert.That(i.FileSystemPath, Is.EqualTo(KNOWNFOLDERID.FOLDERID_Documents.FullPath()));
			}, Throws.Nothing);
			Assert.That(() => new ShellItem(PIDL.Null), Throws.Exception);
		}

		[Test]
		public void EqualityTest()
		{
			using (var i = new ShellItem(testDoc))
			using (var l = new ShellLink(testLinkDoc))
			using (var lt = l.Target)
			{
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
		}

		[Test]
		public void GetAttrTest()
		{
			Assert.That(() =>
			{
				using (var i = new ShellItem(testDoc))
				{
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
				}
			}, Throws.Nothing);
		}

		[Test]
		public void GetDisplayNameTest()
		{
			using (var i = new ShellItem(testDoc))
			{
				foreach (ShellItemDisplayString e in Enum.GetValues(typeof(ShellItemDisplayString)))
				{
					Assert.That(() =>
					{
						var s = i.GetDisplayName(e);
						Debug.WriteLine($"{e}={s}");
					}, Throws.Nothing);
				}
				Assert.That(i.GetDisplayName((ShellItemDisplayString)0x8fffffff), Is.EqualTo(i.GetDisplayName(0)));
			}
		}

		[Test]
		public void GetParentTest()
		{
			Assert.That(() =>
			{
				using (var i = new ShellItem(testDoc))
				using (var p = new ShellItem(System.IO.Path.GetDirectoryName(testDoc)))
				{
					Assert.That(i.Parent == p, Is.True);
					Assert.That(ShellFolder.Desktop.Parent, Is.Null);
				}
			}, Throws.Nothing);
		}

		[Test]
		public void GetPIDLTest()
		{
			Assert.That(() =>
			{
				using (var i = new ShellItem(testDoc))
				using (var p = new PIDL(testDoc))
					Assert.That(i.PIDL.Equals(p), Is.True);
			}, Throws.Nothing);
		}

		[Test]
		public void GetPropTest()
		{
			using (var i = new ShellItem(testDoc))
			{
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

				Assert.That(i.Properties.GetProperty<string>(PROPERTYKEY.System.Company), Is.InstanceOf<string>().And.StartWith("Microsoft"));
				Assert.That(() => i.Properties.GetProperty<int>(PROPERTYKEY.System.Company), Throws.Exception);
			}
		}

		[Test]
		public void GetPropDescListTest()
		{
			Assert.That(() =>
			{
				using (var i = new ShellItem(testDoc))
				{
					Assert.That(() => i.GetPropertyDescriptionList(PROPERTYKEY.System.Category), Throws.Exception);
					using (var pdl = i.GetPropertyDescriptionList(PROPERTYKEY.System.PropList.FullDetails))
					{
						Assert.That(pdl.Count, Is.GreaterThan(0));
						foreach (var d in pdl)
						{
							Assert.That(d.TypeFlags, Is.Not.Zero);
							Debug.WriteLine($"Property '{d.DisplayName}' is of type '{d.PropertyType}'");
						}
					}
				}
			}, Throws.Nothing);
		}

		[Test]
		public void GetToolTipTest()
		{
			using (var i = new ShellItem(testDoc))
			{
				foreach (ShellItemToolTipOptions e in Enum.GetValues(typeof(ShellItemToolTipOptions)))
				{
					Assert.That(() =>
					{
						var s = i.GetToolTip(e);
						Debug.WriteLine($"{e}={s}");
					}, Throws.Nothing);
				}
			}
		}

		[Test]
		public void GetHandlerTest()
		{
			using (var i = new ShellItem(testDoc))
			{
				var ps = i.GetHandler<PropSys.IPropertyStore>(BHID.BHID_PropertyStore);
				Assert.That(ps, Is.Not.Null.And.InstanceOf<PropSys.IPropertyStore>());
				System.Runtime.InteropServices.Marshal.ReleaseComObject(ps);
				ps = i.GetHandler<PropSys.IPropertyStore>();
				Assert.That(ps, Is.Not.Null.And.InstanceOf<PropSys.IPropertyStore>());
				System.Runtime.InteropServices.Marshal.ReleaseComObject(ps);
				Assert.That(() => i.GetHandler<IExtractIcon>(), Throws.TypeOf<ArgumentOutOfRangeException>());
			}
		}

		[Test]
		public void GetHandlerTest2()
		{
			using (var shellItem = new ShellItem(@"C:\Temp\Holes.mp4"))
			{
				if (!shellItem.IsFolder)
					TestContext.WriteLine(shellItem.Properties[PROPERTYKEY.System.MIMEType]);

				using (var stream = shellItem.GetStream())
					TestContext.WriteLine(((FormattableString)$"{shellItem.FileSystemPath} ({stream.Length:B3})").ToString(ByteSizeFormatter.Instance));
			}
		}

		[Test]
		public void GetImageTest()
		{
			using (var i = new ShellItem(testDoc))
			{
				var sz = new System.Drawing.Size(32, 32);
				var bmp = i.GetImage(sz, ShellItemGetImageOptions.IconOnly);
				Assert.That(bmp, Is.Not.Null);
				Assert.That(bmp.Size, Is.EqualTo(sz));
			}
			using (var i = new ShellItem(@"C:\Temp\IDA256.png"))
			{
				var sz = new System.Drawing.Size(1024, 1024);
				var bmp = i.GetImage(sz, ShellItemGetImageOptions.ThumbnailOnly | ShellItemGetImageOptions.ScaleUp);
				Assert.That(bmp.Size, Is.EqualTo(sz));
			}
		}
	}
}