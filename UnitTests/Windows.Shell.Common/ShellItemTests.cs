using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
[TestFixture, SingleThreaded]
public class ShellItemTests
{
	internal const string badTestDoc = @"C:\Temp\BadTest.doc";
	internal static readonly string testDoc = TestCaseSources.WordDoc;
	internal static readonly string testLinkDoc = TestCaseSources.WordDocLink;

	[Test]
	public void EqualityTest()
	{
		using var i = new ShellItem(testDoc);
		using var l = new ShellLink(testLinkDoc);
		using ShellItem lt = l.Target;
		Assert.That(i == lt, Is.True);
		Assert.That(i != lt, Is.False);
		Assert.That(i.Equals(lt), Is.True);
		Assert.That(i.CompareTo(lt), Is.Zero);
		Assert.That(i.CompareTo(l), Is.Not.Zero);
		Assert.That(((IComparable<ShellItem>)i).CompareTo(lt), Is.Zero);
		Assert.That(((IComparable<ShellItem>)i).CompareTo(l), Is.Not.Zero);
		Assert.That(i.Equals(lt.IShellItem), Is.True);
		Assert.That(i.Equals(lt.Name), Is.False);
		Assert.That(i.Equals((object?)null), Is.False);
		//Assert.That(i.Equals((IShellItem?)null), Is.False);
		//Assert.That(i.Equals((ShellItem?)null), Is.False);
		Assert.That(i!.GetHashCode(), Is.EqualTo(lt.GetHashCode()));
	}

	[Test]
	public void GetAttrTest() => Assert.That(() =>
								   {
									   using var i = new ShellItem(testDoc);
									   Assert.That(i.Attributes, Is.Not.Zero);
									   Assert.That(i.FileInfo?.FullName, Is.EqualTo(testDoc));
									   Assert.That(i.IsFileSystem, Is.True);
									   Assert.That(i.IsFolder, Is.False);
									   Assert.That(i.IsLink, Is.False);
									   Assert.That(i.IShellItem, Is.Not.Null);
									   Assert.That(i.Name, Is.EqualTo(Path.GetFileName(testDoc)));
									   Assert.That(i.ParsingName, Is.EqualTo(testDoc));
									   Assert.That(i.Name, Is.EqualTo(i.ToString()));
									   Assert.That(i.ToolTipText, Is.Not.Null);
								   }, Throws.Nothing);

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
		PropSys.IPropertyStore ps = i.GetHandler<PropSys.IPropertyStore>(BHID.BHID_PropertyStore);
		Assert.That(ps, Is.Not.Null.And.InstanceOf<PropSys.IPropertyStore>());
		Marshal.ReleaseComObject(ps);
		ps = i.GetHandler<PropSys.IPropertyStore>();
		Assert.That(ps, Is.Not.Null.And.InstanceOf<PropSys.IPropertyStore>());
		Marshal.ReleaseComObject(ps);
		IExtractIconW ei = i.GetHandler<IExtractIconW>();
		Assert.That(ei, Is.Not.Null.And.InstanceOf<IExtractIconW>());
		//Assert.That(() => i.GetHandler<IExtractIcon>(), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[Test]
	public void GetHandlerTest2()
	{
		using var shellItem = new ShellItem(TestCaseSources.LargeFile);
		if (!shellItem.IsFolder)
			TestContext.WriteLine(shellItem.Properties[PROPERTYKEY.System.MIMEType]);

		using ComStream stream = shellItem.GetStream(STGM.STGM_READ | STGM.STGM_SIMPLE);
		TestContext.WriteLine(((FormattableString)$"{shellItem.FileSystemPath} ({stream.Length:B3})").ToString(ByteSizeFormatter.Instance));
	}

	[Test]
	public void GetImageTest()
	{
		using (var i = new ShellItem(testDoc))
		{
			var sz = new SIZE(32, 32);
			SafeHBITMAP bmp = i.GetImage(sz, ShellItemGetImageOptions.IconOnly);
			Assert.That(bmp.IsInvalid, Is.False);
			var bmi = GetObject<BITMAP>(bmp);
			Assert.That(new SIZE(bmi.bmWidth, bmi.bmHeight), Is.EqualTo(sz));
		}
		using (var i = new ShellItem(TestCaseSources.LargeFile))
		{
			var sz = new Size(1024, 1024);
			SafeHBITMAP bmp = i.GetImage(sz, ShellItemGetImageOptions.ThumbnailOnly | ShellItemGetImageOptions.ScaleUp);
			Assert.That(bmp.IsInvalid, Is.False);
			var bmi = GetObject<BITMAP>(bmp);
			SIZE newSz = new(bmi.bmWidth, bmi.bmHeight);
			Assert.That(newSz, Has.Property("Width").EqualTo(sz.Width).Or.Property("Height").EqualTo(sz.Height));
		}
	}

	[Test]
	public void GetImageTest2()
	{
		var f = new ShellFolder(KNOWNFOLDERID.FOLDERID_AppsFolder);
		foreach (ShellItem i in f.EnumerateChildren(FolderItemFilter.NonFolders | FolderItemFilter.Folders))
			Assert.That(() => i.GetImage(new Size(32, 32), ShellItemGetImageOptions.BiggerSizeOk), Throws.Nothing);
	}

	[Test]
	public void GetParentTest() => Assert.That(() =>
									 {
										 using var i = new ShellItem(testDoc);
										 using var p = new ShellItem(Path.GetDirectoryName(testDoc)!);
										 Assert.That(i.Parent == p, Is.True);
										 Assert.That(ShellFolder.Desktop.Parent, Is.Null);
									 }, Throws.Nothing);

	[Test]
	public void GetPIDLTest() => Assert.That(() =>
								   {
									   using var i = new ShellItem(testDoc);
									   using var p = new PIDL(testDoc);
									   Assert.That(i.PIDL.Equals(p), Is.True);
								   }, Throws.Nothing);

	[Test]
	public void GetPropDescListTest() => Assert.That(() =>
										   {
											   using var i = new ShellItem(testDoc);
											   using PropertyDescriptionList pdl = i.GetPropertyDescriptionList();
											   Assert.That(pdl.Count, Is.GreaterThan(0));
											   foreach (PropertyDescription d in pdl)
											   {
												   Assert.That(d.TypeFlags, Is.Not.Zero);
												   Debug.WriteLine($"Property '{d.DisplayName}' is of type '{d.PropertyType?.Name}'");
											   }
										   }, Throws.Nothing);

	[Test]
	public void GetPropTest()
	{
		using (var i = new ShellItem(testDoc))
		{
			Assert.That(i.Properties.Count, Is.GreaterThan(0));
			Assert.That(i.Properties[PROPERTYKEY.System.Author], Has.Member("TestAuthor"));
			Assert.That(i.Properties[PROPERTYKEY.System.ItemTypeText], Does.StartWith("Microsoft Word"));
			Assert.That(i.Properties[PROPERTYKEY.System.DateAccessed], Is.TypeOf<FILETIME>());
			Assert.That((ulong)i.Properties[PROPERTYKEY.System.FileFRN]!, Is.GreaterThan((ulong)0));
			Assert.That(i.Properties[new PROPERTYKEY()], Is.Null);
			Assert.That(i.Properties[new PROPERTYKEY(Guid.NewGuid(), 2)], Is.Null);

			Assert.That(i.Properties["System.Author"], Has.Member("TestAuthor"));
			Assert.That(i.Properties["DocAuthor"], Has.Member("TestAuthor"));
			Assert.That(() => i.Properties[null], Throws.Exception);
			Assert.That(() => i.Properties["Arthur"], Throws.Exception);

			Assert.That(i.Properties.GetProperty<string>(PROPERTYKEY.System.ApplicationName), Is.InstanceOf<string>().And.StartWith("Microsoft"));
			Assert.That(() => i.Properties.GetProperty<int>(PROPERTYKEY.System.ApplicationName), Throws.Exception);
		}

		// Test to ensure file handle was released
		Assert.That(() => { using var fs = new FileStream(testDoc, FileMode.Open, FileAccess.Read, FileShare.None); fs.Close(); }, Throws.Nothing);
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
	public void ImagesTest()
	{
		using var imageFile = new ShellItem(@"C:\Temp\icon2.ico");
		var list = new List<(Size sz, ShellItemGetImageOptions opt)>();
		for (var i = 16; i <= 256; i += 16)
		{
			var sz = new Size(i, i);
			list.AddRange(Enum.GetValues(typeof(ShellItemGetImageOptions)).OfType<ShellItemGetImageOptions>().Where(o => o != ShellItemGetImageOptions.MemoryOnly).Select(o => (sz, o)));
		}
		var handles = new List<SafeHBITMAP>();
		for (var i = 0; i < list.Count; i++)
		{
			try
			{
				handles.Add(imageFile.Images.GetImageAsync(list[i].sz, list[i].opt).Result);
				Assert.That(handles[i], ResultIs.ValidHandle);
			}
			catch (AggregateException) when (list[i].opt == ShellItemGetImageOptions.ThumbnailOnly)
			{
				handles.Add(CreateBitmap(1, 1, 1, 1, null));
			}
		}
		//new ImageViewer(handles.Select(h => Image.FromHbitmap(h.DangerousGetHandle())).Prepend(Image.FromFile(TestCaseSources.ImageFile))).ShowDialog();
		// TODO: Fix this test
		//new ImageViewer(handles.Select((h, idx) => ((Image)HToBitmap(h), $"{list[idx].opt} {list[idx].sz}"))).ShowDialog();
		foreach (SafeHBITMAP h in handles) h.Dispose();
	}

	[Test]
	public void InvokeVerbTest()
	{
		using var i = new ShellItem(testDoc);
		var verb = i.Verbs.First();
		TestContext.WriteLine(string.Join(", ", i.Verbs));
		Assert.That(() => i.InvokeVerb(verb), Throws.Nothing);
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
		Assert.That(() => new ShellItem((string?)null), Throws.ArgumentNullException);
		Assert.That(() => new ShellItem(badTestDoc), Throws.InstanceOf<FileNotFoundException>());
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

		var fn = Directory.EnumerateFiles(Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Documents")).First();
		using var d = new ShellItem(fn);
		Assert.That(d.ToUri().ToString(), Is.EqualTo(@"file:///" + fn.Replace('\\', '/')));

		using var td = new ShellItem(d.ToUri().ToString());
		td.FileSystemPath!.WriteValues();
	}

	/*
	private static Bitmap? HToBitmap(in HBITMAP hbmp)
	{
		const System.Drawing.Imaging.PixelFormat fmt = System.Drawing.Imaging.PixelFormat.Format32bppArgb;

		// If hbmp is NULL handle, return null
		if (hbmp.IsNull) return null;

		// Create resulting bitmap from DIB info or bail if not 32bit
		(ushort bpp, int width, int height, int scanBytes, IntPtr bits, bool isdib) = GetInfo(hbmp);
		if (bpp != Image.GetPixelFormatSize(fmt) || height == 0 || !isdib)
			return Image.FromHbitmap((IntPtr)hbmp);

		//var bytes = dib.dsBm.bmBits.ToByteArray((int)dib.dsBmih.biSizeImage);

		// Read first byte of first and last scan lines
		//var byte0 = unchecked((uint)Marshal.ReadInt32(dib.dsBm.bmBits));
		//var byten = unchecked((uint)Marshal.ReadInt32(dib.dsBm.bmBits, (int)dib.dsBmih.biSizeImage - dib.dsBm.bmWidthBytes));

		//// Load bitmap into DC to look at pixels
		//using (var dc = CreateCompatibleDC())
		//using (dc.SelectObject(hbmp))
		//{
		//	uint pix0 = GetPixel(dc, 0, 0);
		//	uint pixn = GetPixel(dc, 0, Math.Abs(dib.dsBmih.biHeight) - 1);
		//	// If first byte and first pixel are the same,
		//	if (pix0 == byte0)
		//	{

		//	}
		//}

		//var bounds = new Rectangle(0, 0, width, Math.Abs(height));
		var bmp = new Bitmap(width, height, scanBytes, fmt, bits);
		bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
		return bmp;
		//using var bitmap = new Bitmap(bounds.Width, bounds.Height, dib.dsBm.bmWidthBytes, fmt, dib.dsBm.bmBits);

		//// Create resulting 
		//var alpha = new Bitmap(bounds.Width, bounds.Height, fmt);
		//var bdata = bitmap.LockBits(bounds, System.Drawing.Imaging.ImageLockMode.ReadOnly, fmt);
		//var adata = alpha.LockBits(bounds, System.Drawing.Imaging.ImageLockMode.WriteOnly, fmt);
		//var bottomUp = dib.dsBmih.biHeight > 0;
		//try
		//{
		//	using var bstr = new SafeNativeArray<RGBQUAD>(bdata.Scan0, (int)dib.dsBmih.biSizeImage, false);
		//	using var astr = new SafeNativeArray<RGBQUAD>(adata.Scan0, (int)dib.dsBmih.biSizeImage, false);
		//	// Copy all semi-transparent bits
		//	for (int i = 0; i < bstr.Count; i++)
		//	{
		//		var rgbquad = bottomUp ? bstr[bstr.Count - 1 - i] : bstr[i];
		//		// If pixel is fully transparent, skip pixel
		//		if (!rgbquad.IsTransparent)
		//			astr[i] = rgbquad;
		//	}
		//}
		//finally
		//{
		//	alpha.UnlockBits(adata);
		//	bitmap.UnlockBits(bdata);
		//}
		//return alpha;

		static (ushort bpp, int width, int height, int scanBytes, IntPtr bits, bool isdib) GetInfo(in HBITMAP hbmp)
		{
			var dibSz = Marshal.SizeOf(typeof(DIBSECTION));
			using ISafeMemoryHandle mem = GetObject(hbmp, dibSz);
			if (mem.Size == dibSz)
			{
				DIBSECTION dib = mem.ToStructure<DIBSECTION>();
				return (dib.dsBm.bmBitsPixel, dib.dsBmih.biWidth, dib.dsBmih.biHeight, dib.dsBm.bmWidthBytes, dib.dsBm.bmBits, true);
			}
			else
			{
				BITMAP bmp = mem.ToStructure<BITMAP>();
				return (bmp.bmBitsPixel, bmp.bmWidth, bmp.bmHeight, bmp.bmWidthBytes, bmp.bmBits, false);
			}
		}
	}
	*/
}