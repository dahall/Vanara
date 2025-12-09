using NUnit.Framework;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class BitmapTests
{
	[Test]
	public void CreateDIBitmapTest()
	{
		var bits = new byte[128 * 4];
		byte[] rlebits = { 2, 0, 0, 0, 2, 1, 0, 1 };

		using SafeReleaseHDC hdc = GetDC();

		BITMAPINFO bmi = new();
		bmi.bmiHeader.biSize = (uint)Marshal.SizeOf<BITMAPINFOHEADER>();
		bmi.bmiHeader.biWidth = 2;
		bmi.bmiHeader.biHeight = 2;
		bmi.bmiHeader.biPlanes = 1;
		bmi.bmiHeader.biBitCount = 16;
		bmi.bmiHeader.biCompression = BitmapCompressionMode.BI_RGB;
		bmi.bmiHeader.biSizeImage = 0;
		bmi.bmiHeader.biXPelsPerMeter = 1;
		bmi.bmiHeader.biYPelsPerMeter = 1;
		bmi.bmiHeader.biClrUsed = 0;
		bmi.bmiHeader.biClrImportant = 0;

		SafeHBITMAP hbmp = CreateDIBitmap(hdc, bmi.bmiHeader, CBM.CBM_INIT, bits, bmi, DIBColorMode.DIB_RGB_COLORS);
		Assert.That(hbmp, ResultIs.ValidHandle);

		BITMAP bitmap = GetObject<BITMAP>(hbmp);
		Assert.That(bitmap.bmType == 0);
		Assert.That(bitmap.bmWidth == 2);
		Assert.That(bitmap.bmHeight == 2);
		Assert.That(bitmap.bmWidthBytes, Is.EqualTo(8));
		Assert.That(bitmap.bmPlanes == 1);
		Assert.That(bitmap.bmBitsPixel == GetDeviceCaps(hdc, DeviceCap.BITSPIXEL));
		Assert.That(bitmap.bmBits == IntPtr.Zero);

		bmi.bmiHeader.biCompression = BitmapCompressionMode.BI_RLE8;
		bmi.bmiHeader.biBitCount = 8;
		bmi.bmiHeader.biSizeImage = 8;
		bmi.bmiHeader.biClrUsed = 1;
		Assert.That(hbmp = CreateDIBitmap(hdc, bmi.bmiHeader, CBM.CBM_INIT, rlebits, new SafeBITMAPINFO(bmi), DIBColorMode.DIB_PAL_COLORS), ResultIs.ValidHandle);

		bitmap = GetObject<BITMAP>(hbmp);
		Assert.That(bitmap.bmType == 0);
		Assert.That(bitmap.bmWidth == 2);
		Assert.That(bitmap.bmHeight == 2);
		Assert.That(bitmap.bmWidthBytes, Is.EqualTo(8));
		Assert.That(bitmap.bmPlanes == 1);
		Assert.That(bitmap.bmBitsPixel == GetDeviceCaps(hdc, DeviceCap.BITSPIXEL));
		Assert.That(bitmap.bmBits == IntPtr.Zero);
	}

	[Test]
	public void CreateDIBitmapTest2()
	{
		BITMAPINFO bmi = new()
		{
			bmiHeader = new(4, 4, 8)
			{
				biXPelsPerMeter = 1,
				biYPelsPerMeter = 1,
				biClrUsed = 1,
			},
			bmiColors = new RGBQUAD[1]
		};
		BITMAPINFO bmiBroken = new()
		{
			bmiHeader = new(-2, -4, 42)
			{
				biPlanes = 55,
				biXPelsPerMeter = 1,
				biYPelsPerMeter = 1,
				biClrUsed = 1,
			},
			bmiColors = new RGBQUAD[1]
		};
		byte[] ajBits = new byte[10];

		using var hdc = CreateCompatibleDC();
		Assert.That(hdc, ResultIs.ValidHandle);

		var hbmp = CreateDIBitmap(hdc, bmi.bmiHeader, CBM.CBM_INIT, ajBits, bmi, DIBColorMode.DIB_PAL_COLORS);
		Assert.That(hbmp, ResultIs.ValidHandle);

		hbmp = CreateDIBitmap(hdc, bmi.bmiHeader, CBM.CBM_INIT, default, bmi, DIBColorMode.DIB_PAL_COLORS);
		Assert.That(hbmp, ResultIs.ValidHandle);

		hbmp = CreateDIBitmap(hdc, bmi.bmiHeader, CBM.CBM_INIT, default, SafeBITMAPINFO.Null, DIBColorMode.DIB_PAL_COLORS);
		Assert.That(hbmp, ResultIs.ValidHandle);

		//hbmp = CreateDIBitmap(hdc, bmi.bmiHeader, 0, (IntPtr)0xc0000000, bmi, DIBColorMode.DIB_PAL_COLORS);
		//Assert.That(hbmp, ResultIs.ValidHandle);

		hbmp = CreateDIBitmap(default, bmi.bmiHeader, CBM.CBM_INIT, default, bmi, DIBColorMode.DIB_PAL_COLORS);
		Assert.That(hbmp, ResultIs.ValidHandle);

		hbmp = CreateDIBitmap(hdc, bmi.bmiHeader, CBM.CBM_INIT, default, bmiBroken, DIBColorMode.DIB_PAL_COLORS);
		Assert.That(hbmp, ResultIs.ValidHandle);

		hbmp = CreateDIBitmap(default, default, (CBM)2, default, bmi, 0);
		Assert.That(hbmp, ResultIs.ValidHandle);
	}

	[Test]
	public void GetDIBitsTest()
	{
		using SafeBITMAPINFO pbi = new(default(BITMAPINFOHEADER), 1024 * Marshal.SizeOf<RGBQUAD>());
		ref BITMAPINFOHEADER h = ref pbi.bmiHeaderAsRef;

		using var hdcScreen = GetDC();
		Assert.That(hdcScreen, ResultIs.ValidHandle);

		var hbmp = CreateCompatibleBitmap(hdcScreen, 16, 16);
		Assert.That(hbmp, ResultIs.ValidHandle);

		// Confirm failures
		SetLastError(Win32Error.ERROR_SUCCESS);
		Assert.That(GetDIBits(default, default, 0, 0, default, SafeBITMAPINFO.Null, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		SetLastError(Win32Error.ERROR_SUCCESS);
		Assert.That(GetDIBits((HDC)(IntPtr)2345, default, 0, 0, default, SafeBITMAPINFO.Null, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		SetLastError(Win32Error.ERROR_SUCCESS);
		Assert.That(GetDIBits((HDC)(IntPtr)2345, hbmp, 0, 0, IntPtr.Zero, SafeBITMAPINFO.Null, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		SetLastError(Win32Error.ERROR_SUCCESS);
		Assert.That(GetDIBits((HDC)(IntPtr)2345, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		SetLastError(Win32Error.ERROR_SUCCESS);
		pbi.Zero();
		Assert.That(GetDIBits(default, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		SetLastError(Win32Error.ERROR_SUCCESS);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, default, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		SetLastError(Win32Error.ERROR_SUCCESS);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Not.Value(0));

		/* bad bmi colours (uUsage) */
		SetLastError(0);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, (DIBColorMode)100), ResultIs.Value(0));
		Assert.That(h.biWidth, Is.Zero);
		Assert.That(h.biHeight, Is.Zero);
		Assert.That(h.biBitCount, Is.Zero);
		Assert.That(h.biSizeImage, Is.Zero);

		SetLastError(Win32Error.ERROR_SUCCESS);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Not.Value(0));

		var ScreenBpp = GetDeviceCaps(hdcScreen, DeviceCap.BITSPIXEL);
		Assert.That(h.biWidth, Is.EqualTo(16));
		Assert.That(h.biHeight, Is.EqualTo(16));
		Assert.That(h.biBitCount, Is.EqualTo(ScreenBpp));
		Assert.That(h.biSizeImage, Is.EqualTo((16 * 16) * (ScreenBpp / 8)));

		//pbi.Zero();
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(h.biSize, Is.EqualTo(Marshal.SizeOf(typeof(BITMAPINFOHEADER))));
		//Assert.That(pbch.bcWidth, Is.EqualTo(16));
		//Assert.That(pbch.bcHeight, Is.EqualTo(16));
		//Assert.That(pbch.bcPlanes, Is.EqualTo(1));
		//ok_int(pbch.bcBitCount, ScreenBpp > 16 ? 24 : ScreenBpp); // fails on XP with screenbpp == 16

		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));

		pbi.Zero();
		pbi.HeaderSize = Marshal.SizeOf(typeof(BITMAPV5HEADER)) + 4;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		ref BITMAPV5HEADER pbV5Header = ref pbi.GetHeaderAsRef<BITMAPV5HEADER>();
		Assert.That(pbV5Header.bV5RedMask, Is.Zero);
		Assert.That(pbV5Header.bV5GreenMask, Is.Zero);
		Assert.That(pbV5Header.bV5BlueMask, Is.Zero);
		Assert.That(pbV5Header.bV5AlphaMask, Is.Zero);
		Assert.That(pbV5Header.bV5CSType, Is.Zero);
		// CIEXYZTRIPLE bV5Endpoints;
		Assert.That(pbV5Header.bV5GammaRed, Is.Zero);
		Assert.That(pbV5Header.bV5GammaGreen, Is.Zero);
		Assert.That(pbV5Header.bV5GammaBlue, Is.Zero);
		Assert.That(pbV5Header.bV5Intent, Is.Zero);
		Assert.That(pbV5Header.bV5ProfileData, Is.Zero);
		Assert.That(pbV5Header.bV5ProfileSize, Is.Zero);
		Assert.That(pbV5Header.bV5Reserved, Is.Zero);

		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 234, 43, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));

		hbmp.Dispose();

		SafeNativeArray<uint> ajBits = new(100) { [0] = 0xff, [2] = 0xc, [3] = 0xf0, [4] = 0x0f };
		Assert.That(hbmp = CreateBitmap(13, 7, 1, 1, ajBits), ResultIs.ValidHandle);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(h.biWidth, Is.EqualTo(13));
		Assert.That(h.biHeight, Is.EqualTo(7));
		Assert.That(h.biBitCount, Is.EqualTo(1));
		Assert.That(h.biSizeImage, Is.EqualTo(28));

		/* Test with values set, except biSizeImage */
		h.biSizeImage = 0;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(h.biSizeImage, Is.EqualTo(28));

		h.biWidth = 17;
		h.biHeight = 3;
		h.biSizeImage = 0;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(h.biSizeImage, Is.EqualTo(12));
		Assert.That(h.biWidth, Is.EqualTo(17));
		Assert.That(h.biHeight, Is.EqualTo(3));

		h.biBitCount = 4;
		h.biSizeImage = 1;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(h.biSizeImage, Is.EqualTo(36));
		Assert.That(h.biBitCount, Is.EqualTo(4));

		h.biBitCount = 8;
		h.biSizeImage = 1000;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(h.biSizeImage, Is.EqualTo(60));
		Assert.That(h.biBitCount, Is.EqualTo(8));

		Assert.That(SetBitmapDimensionEx(hbmp, h.biWidth * 2, h.biHeight * 2, out _), ResultIs.Successful);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(h.biXPelsPerMeter, Is.Zero);
		Assert.That(h.biYPelsPerMeter, Is.Zero);

		pbi.Zero();
		h.biWidth = 12;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(h.biWidth, Is.EqualTo(13));
		Assert.That(h.biSizeImage, Is.EqualTo(28));

		pbi.Zero();
		h.biSizeImage = 123;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));

		pbi.Zero();
		h.biCompression = BitmapCompressionMode.BI_RGB;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));

		//pbi.Zero();
		//h.biBitCount = 5;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//h.biBitCount = 1;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//h.biBitCount = 8;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//h.biBitCount = 32;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//Assert.That(h.biWidth, Is.Zero);
		//Assert.That(h.biHeight, Is.Zero);
		//Assert.That(h.biPlanes, Is.Zero);
		//Assert.That(h.biBitCount, Is.EqualTo(32));
		//Assert.That(h.biCompression, Is.Zero);
		//Assert.That(h.biSizeImage, Is.Zero);

		h.biWidth = 4;
		h.biHeight = 4;
		h.biPlanes = 3;
		h.biBitCount = 32;
		h.biCompression = BitmapCompressionMode.BI_RGB;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(h.biSizeImage, Is.EqualTo(64));
		Assert.That(h.biPlanes, Is.EqualTo(1));
		//h.biWidth;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//h.biWidth = 2;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(h.biSizeImage, Is.EqualTo(32));
		//h.biWidth = -3;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//h.biWidth = 4;
		//h.biHeight;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//h.biHeight = -4;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//h.biBitCount = 31;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//h.biBitCount = 16;
		//h.biPlanes = 23;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(h.biPlanes, Is.EqualTo(1));
		//SetLastError(0xdeadbabe);
		//Assert.That(GetDIBits((HDC)0xff00ff00, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//ok_err(0x57);
		//SetLastError(0xdeadbabe);
		//Assert.That(GetDIBits(hdcScreen, (HBITMAP)0xff00ff00, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//ok_err(0xdeadbabe);
		//SetLastError(0xdeadbabe);
		//Assert.That(GetDIBits((HDC)0xff00ff00, (HBITMAP)0xff00ff00, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//ok_err(0x57);
		//SetLastError(0xdeadbabe);
		//Assert.That(GetDIBits(default, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//ok_err(0x57);

		//h.biCompression = BI_JPEG;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//h.biCompression = BI_PNG;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//h.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
		//h.biWidth = 4;
		//h.biHeight = 4;
		//h.biPlanes = 1;
		//h.biBitCount = 32;
		//h.biCompression = BI_RGB;
		//h.biSizeImage;
		//h.biXPelsPerMeter;
		//h.biYPelsPerMeter;
		//h.biClrUsed;
		//h.biClrImportant;
		//cjSizeImage = ((h.biWidth * h.biBitCount + 31) / 32) * 4 * h.biHeight;
		//pvBits = HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, 512);
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(4));
		//Assert.That(h.biSize, Is.EqualTo(Marshal.SizeOf(typeof(BITMAPINFOHEADER))));
		//Assert.That(h.biWidth, Is.EqualTo(4));
		//Assert.That(h.biHeight, Is.EqualTo(4));
		//Assert.That(h.biPlanes, Is.EqualTo(1));
		//Assert.That(h.biBitCount, Is.EqualTo(32));
		//Assert.That(h.biCompression, Is.EqualTo(BI_RGB));
		//Assert.That(h.biSizeImage, Is.EqualTo(64));
		//Assert.That(h.biXPelsPerMeter, Is.Zero);
		//Assert.That(h.biYPelsPerMeter, Is.Zero);
		//Assert.That(h.biClrUsed, Is.Zero);
		//Assert.That(h.biClrImportant, Is.Zero);

		//h.biBitCount;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, (IntPtr)(IntPtr) - 1, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(GetDIBits(default, hbmp, 0, 4, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//h.biBitCount = 24;
		//h.biWidth = 3;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(4));

		//h.biBitCount = 24;
		//h.biWidth = 3;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(4));

		//h.biBitCount = 17;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//pbi.Zero();
		//h.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
		//h.biBitCount = 5;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//DeleteObject(hbmp);
		//HeapFree(GetProcessHeap(), 0, pvBits);

		//hbmp = CreateBitmap(3, 5, 1, 4, default);
		//Assert.That(hbmp != 0, "failed to create bitmap\n");
		//pbi.Zero();
		//h.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(h.biWidth, Is.EqualTo(3));
		//Assert.That(h.biHeight, Is.EqualTo(5));
		//Assert.That(h.biBitCount, Is.EqualTo(4));
		//Assert.That(h.biSizeImage, Is.EqualTo(20));

		//h.biSizeImage;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//cjSizeImage = ((h.biWidth * h.biBitCount + 31) / 32) * 4 * h.biHeight;
		//ok_int(cjSizeImage, 20);
		//pvBits = HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, cjSizeImage);

		//hdcMem = CreateCompatibleDC(0);
		//Assert.That(hdcMem != 0, "CreateCompatibleDC failed, skipping tests\n");
		//if (hdcMem is null) return;
		//Assert.That(GetDIBits(hdcMem, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//Assert.That(GetDIBits(hdcMem, ghbmpDIB4, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(4));

		//HeapFree(GetProcessHeap(), 0, pvBits);
	}
}