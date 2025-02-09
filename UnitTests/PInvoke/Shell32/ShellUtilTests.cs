using Microsoft.Win32;
using NUnit.Framework;
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
		IShellItem? shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.SmallFile)!, Throws.Nothing);
		try
		{
			Assert.That(shi, Is.Not.Null);
			Assert.That(GetPathFromShellItem(shi!), Is.EqualTo(TestCaseSources.SmallFile));
		}
		finally
		{
			Marshal.ReleaseComObject(shi!);
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
		IShellItem? shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.WordDoc), Throws.Nothing);
		try
		{
			var pi = GetParentAndItem(shi!);
			pi.GetParentAndItem(out _, out var psf, out var pChild);
			uint sz = 32;
			Assert.That(LoadIconFromExtractIcon(psf, pChild, ref sz, out var hIcon), ResultIs.Successful);
			Assert.That(!hIcon.IsInvalid);
			Assert.That(sz, Is.EqualTo(32));
			hIcon.Dispose();
		}
		finally
		{
			Marshal.ReleaseComObject(shi!);
		}
	}

	[Test]
	public void LoadImageFromExtractImageTest()
	{
		IShellItem? shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.WordDoc), Throws.Nothing);
		try
		{
			var pi = GetParentAndItem(shi!);
			pi.GetParentAndItem(out _, out var psf, out var pChild);
			uint sz = 32;
			Assert.That(LoadImageFromExtractImage(psf, pChild, ref sz, out var hBmp), ResultIs.Successful);
			Assert.That(!hBmp.IsInvalid);
			Assert.That(sz, Is.EqualTo(32));
			hBmp.Dispose();
		}
		finally
		{
			Marshal.ReleaseComObject(shi!);
		}
	}

	public static readonly int[] sizes = { 16, 32, 48, 96, 256 };
	public static readonly SIIGBF[] flagOp = { SIIGBF.SIIGBF_INCACHEONLY, 0 };

	[Test]
	public void LoadImageFromImageFactoryTest()
	{
		var t = new System.Diagnostics.Stopwatch();
		Assert.That(SHParseDisplayName(TestCaseSources.LargeFile, default, out var pChild, 0, out _), ResultIs.Successful);
		foreach (var w in sizes)
		{
			ClearIconCache();
			foreach (var f in flagOp)
			{
				SIZE sz = new(w, w);
				t.Restart();
				try
				{
					HRESULT hr1 = LoadImageFromImageFactory(pChild, ref sz, f, out var hBmp);
					var ticks = t.ElapsedMilliseconds;

					HRESULT hr2 = LoadImageFromImageFactory(pChild, ref sz, f, out hBmp);
					var ticks2 = t.ElapsedMilliseconds - ticks;

					TestContext.Write($"1\t{ticks}\t{w}\t{f}\t{hr1}");
					TestContext.Write($"2\t{ticks2}\t{w}\t{f}\t{hr2}");
				}
				catch (Exception ex)
				{
					TestContext.WriteLine(ex.Message);
				}
			}
		}
	}

	private static void ClearIconCache() => Assert.That(SystemVolumeCache.CreateInitializedInstance().Purge(), ResultIs.Successful);

	[Test]
	public void LoadImageFromThumbnailProviderTest()
	{
		IShellItem? shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.LargeFile), Throws.Nothing);
		try
		{
			uint sz = 32;
			Assert.That(LoadImageFromThumbnailProvider(shi!, ref sz, out var hBmp), ResultIs.Successful);
			Assert.That(!hBmp.IsInvalid);
			Assert.That(sz, Is.EqualTo(32));
			hBmp.Dispose();
		}
		finally
		{
			Marshal.ReleaseComObject(shi!);
		}
	}

	[Test]
	public void LoadImageFromThumbnailProviderTest2()
	{
		IShellItem? shi = null;
		Assert.That(() => shi = GetShellItemForPath(TestCaseSources.LargeFile), Throws.Nothing);
		try
		{
			var pi = GetParentAndItem(shi!);
			pi.GetParentAndItem(out _, out var psf, out var pChild);
			uint sz = 32;
			Assert.That(LoadImageFromThumbnailProvider(psf, pChild, ref sz, out var hBmp), ResultIs.Successful);
			Assert.That(!hBmp.IsInvalid);
			Assert.That(sz, Is.EqualTo(32));
			hBmp.Dispose();
		}
		finally
		{
			Marshal.ReleaseComObject(shi!);
		}
	}

	[Test]
	public void LoadIconFromSystemImageListTest()
	{
		uint sz = 32;
		Assert.That(LoadIconFromSystemImageList(2, ref sz, out var hIcon), ResultIs.Successful);
		Assert.That(!hIcon.IsInvalid);
		Assert.That(sz, Is.EqualTo(32));
		hIcon.Dispose();
	}
}