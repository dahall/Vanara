using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.Shell32.ShellUtil;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class ShellUtilTests
{
	[Test]
	public void GetKnownFolderFromGuidTest()
	{
		const KNOWNFOLDERID id = KNOWNFOLDERID.FOLDERID_Desktop;
		Assert.That(GetKnownFolderFromGuid(id.Guid()), Is.EqualTo(id));
	}

	[Test]
	public void GetKnownFolderFromPathTest()
	{
		const KNOWNFOLDERID id = KNOWNFOLDERID.FOLDERID_Desktop;
		Assert.That(GetKnownFolderFromPath(id.FullPath()), Is.EqualTo(id));
	}

	[Test]
	public void GetPathForKnownFolderTest()
	{
		const KNOWNFOLDERID id = KNOWNFOLDERID.FOLDERID_Desktop;
		Assert.That(GetPathForKnownFolder(id.Guid()), Is.EqualTo(id.FullPath()));
	}

	[Test]
	public void GetPathFromShellItemTest()
	{
		IShellItem shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.SmallFile), Throws.Nothing);
		try
		{
			Assert.NotNull(shi);
			Assert.AreEqual(GetPathFromShellItem(shi), TestCaseSources.SmallFile);
		}
		finally
		{
			Marshal.ReleaseComObject(shi);
		}
	}

	[Test]
	public void SHILPixelConvTest()
	{
		Assert.That(SHILToPixels(SHIL.SHIL_SMALL), Is.EqualTo(16));
		Assert.That(SHILToPixels(SHIL.SHIL_LARGE), Is.EqualTo(32));
		Assert.That(SHILToPixels(SHIL.SHIL_EXTRALARGE), Is.EqualTo(48));
		Assert.That(SHILToPixels(SHIL.SHIL_JUMBO), Is.EqualTo(256));

		Assert.That(PixelsToSHIL(16), Is.EqualTo(SHIL.SHIL_SMALL).Or.EqualTo(SHIL.SHIL_SYSSMALL));
		Assert.That(PixelsToSHIL(32), Is.EqualTo(SHIL.SHIL_LARGE));
		Assert.That(PixelsToSHIL(48), Is.EqualTo(SHIL.SHIL_EXTRALARGE));
		Assert.That(PixelsToSHIL(256), Is.EqualTo(SHIL.SHIL_JUMBO));
	}

	[Test]
	public void LoadIconFromExtractIconTest()
	{
		IShellItem shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.WordDoc), Throws.Nothing);
		try
		{
			var pi = GetParentAndItem(shi);
			pi.GetParentAndItem(out _, out var psf, out var pChild);
			uint sz = 32;
			Assert.That(LoadIconFromExtractIcon(psf, pChild, ref sz, out var hIcon), ResultIs.Successful);
			Assert.IsFalse(hIcon.IsInvalid);
			Assert.That(sz, Is.EqualTo(32));
			hIcon.Dispose();
		}
		finally
		{
			Marshal.ReleaseComObject(shi);
		}
	}

	[Test]
	public void LoadImageFromExtractImageTest()
	{
		IShellItem shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.ImageFile), Throws.Nothing);
		try
		{
			var pi = GetParentAndItem(shi);
			pi.GetParentAndItem(out _, out var psf, out var pChild);
			uint sz = 32;
			Assert.That(LoadImageFromExtractImage(psf, pChild, ref sz, out var hBmp), ResultIs.Successful);
			Assert.IsFalse(hBmp.IsInvalid);
			Assert.That(sz, Is.EqualTo(32));
			hBmp.Dispose();
		}
		finally
		{
			Marshal.ReleaseComObject(shi);
		}
	}

	[Test]
	public void LoadImageFromThumbnailProviderTest()
	{
		IShellItem shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.LargeFile), Throws.Nothing);
		try
		{
			uint sz = 32;
			Assert.That(LoadImageFromThumbnailProvider(shi, ref sz, out var hBmp), ResultIs.Successful);
			Assert.IsFalse(hBmp.IsInvalid);
			Assert.That(sz, Is.EqualTo(32));
			hBmp.Dispose();
		}
		finally
		{
			Marshal.ReleaseComObject(shi);
		}
	}

	[Test]
	public void LoadImageFromThumbnailProviderTest2()
	{
		IShellItem shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.LargeFile), Throws.Nothing);
		try
		{
			var pi = GetParentAndItem(shi);
			pi.GetParentAndItem(out _, out var psf, out var pChild);
			uint sz = 32;
			Assert.That(LoadImageFromThumbnailProvider(psf, pChild, ref sz, out var hBmp), ResultIs.Successful);
			Assert.IsFalse(hBmp.IsInvalid);
			Assert.That(sz, Is.EqualTo(32));
			hBmp.Dispose();
		}
		finally
		{
			Marshal.ReleaseComObject(shi);
		}
	}

	[Test]
	public void LoadIconFromSystemImageListTest()
	{
		uint sz = 32;
		Assert.That(LoadIconFromSystemImageList(2, ref sz, out var hIcon), ResultIs.Successful);
		Assert.IsFalse(hIcon.IsInvalid);
		Assert.That(sz, Is.EqualTo(32));
		hIcon.Dispose();
	}
}