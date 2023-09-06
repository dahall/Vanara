using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Msvfw32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class MultimediaTests
{
	static readonly uint ICTYPE_VIDEO = WinMm.MAKEFOURCC("vidc");

	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void ICLocateTest()
	{
		BITMAPINFOHEADER bi = new() { biSize = (uint)Marshal.SizeOf<BITMAPINFOHEADER>(), biWidth = 32, biHeight = 8, biPlanes = 1, biBitCount = 8,
			biCompression = BitmapCompressionMode.BI_RLE8, biXPelsPerMeter = 100000, biYPelsPerMeter = 100000 };
		BITMAPINFOHEADER bo = bi;
		SafeHIC hic;
		Assert.That(hic = ICLocate(ICTYPE_VIDEO, 0, bi, bo, ICMODE.ICMODE_DECOMPRESS), ResultIs.ValidHandle);
		Assert.That(() => hic.Dispose(), Throws.Nothing);
	}

	[Test]
	public void ICOpenTest()
	{
		SafeHIC hic;
		Assert.That(hic = ICOpen(ICTYPE_VIDEO, WinMm.MAKEFOURCC("cvid"), ICMODE.ICMODE_DECOMPRESS), ResultIs.ValidHandle);
		Assert.That(() => hic.Dispose(), Throws.Nothing);
	}

	[Test]
	public void ICInfoTest()
	{
		Assert.That(ICInfo(ICTYPE_VIDEO, WinMm.MAKEFOURCC("cvid"), out var info), ResultIs.Successful);
		Assert.That(info.dwSize, Is.GreaterThan(0));
		info.WriteValues();
	}

	[Test]
	public void ICAboutTest()
	{
		using var hic = ICOpen(ICTYPE_VIDEO, WinMm.MAKEFOURCC("cvid"), ICMODE.ICMODE_DECOMPRESS);
		Assert.That(hic, ResultIs.ValidHandle);
		Assert.That(ICAbout(hic, User32.GetDesktopWindow()), Is.EqualTo(ICERR.ICERR_OK));
	}

	[Test]
	public void ICCompressorChooseTest()
	{
		COMPVARS cv = new() { cbSize = Marshal.SizeOf<COMPVARS>() };
		Assert.That(ICCompressorChoose(default, ICMF_CHOOSE.ICMF_CHOOSE_ALLCOMPRESSORS, default, default, ref cv), ResultIs.Successful);
		cv.WriteValues();
		ICCompressorFree(cv);
	}

	[Test]
	public void ICGetInfoTest()
	{
		using var hic = ICOpen(ICTYPE_VIDEO, WinMm.MAKEFOURCC("cvid"), ICMODE.ICMODE_DECOMPRESS);
		Assert.That(hic, ResultIs.ValidHandle);
		ICINFO info = new() { dwSize = (uint)Marshal.SizeOf<ICINFO>() };
		Assert.That(ICGetInfo(hic, ref info, info.dwSize), Is.Not.EqualTo(IntPtr.Zero));
		info.WriteValues();
	}
}