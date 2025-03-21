﻿using NUnit.Framework;
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
		Vanara.InteropServices.SafeNativeArray<uint> ajBits = new(100);
		ajBits[0] = 0xff; ajBits[2] = 0xc; ajBits[3] = 0xf0; ajBits[4] = 0x0f;

		var bisize = Marshal.SizeOf(typeof(BITMAPINFOHEADER)) + 256 * Marshal.SizeOf(typeof(uint));
		using SafeBITMAPINFO pbi = new(default, bisize);

		using var hdcScreen = GetDC();
		Assert.That(hdcScreen, ResultIs.ValidHandle);

		var hbmp = CreateCompatibleBitmap(hdcScreen, 16, 16);
		Assert.That(hbmp, ResultIs.ValidHandle);

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

		/* null bitmap info - crashes XP*/
		//SetLastError(Win32Error.ERROR_SUCCESS);
		//Assert.That(GetDIBits(hdcScreen, default, 0, 15, default, default, DIBColorMode.DIB_RGB_COLORS) == 0);
		//Assert.That(GetLastError() == Win32Error.ERROR_INVALID_PARAMETER);

		/* bad bmi colours (uUsage) */
		SetLastError(0);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, (DIBColorMode)100), ResultIs.Value(0));
		Assert.That(pbi.bmiHeader.biWidth == 0);
		Assert.That(pbi.bmiHeader.biHeight == 0);
		Assert.That(pbi.bmiHeader.biBitCount == 0);
		Assert.That(pbi.bmiHeader.biSizeImage == 0);

		SetLastError(Win32Error.ERROR_SUCCESS);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Not.Value(0));

		var ScreenBpp = GetDeviceCaps(hdcScreen, DeviceCap.BITSPIXEL);
		Assert.That(pbi.bmiHeader.biWidth == 16);
		Assert.That(pbi.bmiHeader.biHeight == 16);
		Assert.That(pbi.bmiHeader.biBitCount == ScreenBpp);
		Assert.That(pbi.bmiHeader.biSizeImage == (16 * 16) * (ScreenBpp / 8));

		//pbi.Zero();
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(pbi.bmiHeader.biSize, Is.EqualTo(Marshal.SizeOf(typeof(BITMAPINFOHEADER))));
		//Assert.That(pbch.bcWidth, Is.EqualTo(16));
		//Assert.That(pbch.bcHeight, Is.EqualTo(16));
		//Assert.That(pbch.bcPlanes, Is.EqualTo(1));
		//ok_int(pbch.bcBitCount, ScreenBpp > 16 ? 24 : ScreenBpp); // fails on XP with screenbpp == 16

		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));

		pbi.Zero();
		pbi.HeaderSize = Marshal.SizeOf(typeof(BITMAPV5HEADER)) + 4;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 15, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		var pbV5Header = pbi.GetHeader<BITMAPV5HEADER>();
		Assert.That(pbV5Header.bV5RedMask, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5GreenMask, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5BlueMask, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5AlphaMask, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5CSType, Is.EqualTo(0));
		// CIEXYZTRIPLE bV5Endpoints;
		Assert.That(pbV5Header.bV5GammaRed, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5GammaGreen, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5GammaBlue, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5Intent, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5ProfileData, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5ProfileSize, Is.EqualTo(0));
		Assert.That(pbV5Header.bV5Reserved, Is.EqualTo(0));

		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 234, 43, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));

		hbmp.Dispose();

		Assert.That(hbmp = CreateBitmap(13, 7, 1, 1, ajBits), ResultIs.ValidHandle);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(pbi.bmiHeader.biWidth, Is.EqualTo(13));
		Assert.That(pbi.bmiHeader.biHeight, Is.EqualTo(7));
		Assert.That(pbi.bmiHeader.biBitCount, Is.EqualTo(1));
		Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(28));

		/* Test with values set, except biSizeImage */
		var h = pbi.bmiHeader;
		h.biSizeImage = 0;
		pbi.bmiHeader = h;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(28));

		h = pbi.bmiHeader;
		h.biWidth = 17;
		h.biHeight = 3;
		h.biSizeImage = 0;
		pbi.bmiHeader = h;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(12));
		Assert.That(pbi.bmiHeader.biWidth, Is.EqualTo(17));
		Assert.That(pbi.bmiHeader.biHeight, Is.EqualTo(3));

		h = pbi.bmiHeader;
		h.biBitCount = 4;
		h.biSizeImage = 1;
		pbi.bmiHeader = h;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(36));
		Assert.That(pbi.bmiHeader.biBitCount, Is.EqualTo(4));

		h = pbi.bmiHeader;
		h.biBitCount = 8;
		h.biSizeImage = 1000;
		pbi.bmiHeader = h;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(60));
		Assert.That(pbi.bmiHeader.biBitCount, Is.EqualTo(8));

		Assert.That(SetBitmapDimensionEx(hbmp, 110, 220, out _), ResultIs.Successful);
		pbi.Zero();
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(pbi.bmiHeader.biXPelsPerMeter, Is.EqualTo(0));
		Assert.That(pbi.bmiHeader.biYPelsPerMeter, Is.EqualTo(0));

		pbi.Zero();
		h = pbi.bmiHeader;
		h.biWidth = 12;
		pbi.bmiHeader = h;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(pbi.bmiHeader.biWidth, Is.EqualTo(13));
		Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(28));

		pbi.Zero();
		h = pbi.bmiHeader;
		h.biSizeImage = 123;
		pbi.bmiHeader = h;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));

		pbi.Zero();
		h = pbi.bmiHeader;
		h.biCompression = BitmapCompressionMode.BI_RGB;
		pbi.bmiHeader = h;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));

		//pbi.Zero();
		//pbi.bmiHeader.biBitCount = 5;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//pbi.bmiHeader.biBitCount = 1;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//pbi.bmiHeader.biBitCount = 8;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//pbi.bmiHeader.biBitCount = 32;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//Assert.That(pbi.bmiHeader.biWidth, Is.EqualTo(0));
		//Assert.That(pbi.bmiHeader.biHeight, Is.EqualTo(0));
		//Assert.That(pbi.bmiHeader.biPlanes, Is.EqualTo(0));
		//Assert.That(pbi.bmiHeader.biBitCount, Is.EqualTo(32));
		//Assert.That(pbi.bmiHeader.biCompression, Is.EqualTo(0));
		//Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(0));

		h = pbi.bmiHeader;
		h.biWidth = 4;
		h.biHeight = 4;
		h.biPlanes = 3;
		h.biBitCount = 32;
		h.biCompression = BitmapCompressionMode.BI_RGB;
		pbi.bmiHeader = h;
		Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(64));
		Assert.That(pbi.bmiHeader.biPlanes, Is.EqualTo(1));
		//pbi.bmiHeader.biWidth;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//pbi.bmiHeader.biWidth = 2;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(32));
		//pbi.bmiHeader.biWidth = -3;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//pbi.bmiHeader.biWidth = 4;
		//pbi.bmiHeader.biHeight;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//pbi.bmiHeader.biHeight = -4;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//pbi.bmiHeader.biBitCount = 31;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//pbi.bmiHeader.biBitCount = 16;
		//pbi.bmiHeader.biPlanes = 23;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(pbi.bmiHeader.biPlanes, Is.EqualTo(1));
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

		//pbi.bmiHeader.biCompression = BI_JPEG;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//pbi.bmiHeader.biCompression = BI_PNG;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 5, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//pbi.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
		//pbi.bmiHeader.biWidth = 4;
		//pbi.bmiHeader.biHeight = 4;
		//pbi.bmiHeader.biPlanes = 1;
		//pbi.bmiHeader.biBitCount = 32;
		//pbi.bmiHeader.biCompression = BI_RGB;
		//pbi.bmiHeader.biSizeImage;
		//pbi.bmiHeader.biXPelsPerMeter;
		//pbi.bmiHeader.biYPelsPerMeter;
		//pbi.bmiHeader.biClrUsed;
		//pbi.bmiHeader.biClrImportant;
		//cjSizeImage = ((pbi.bmiHeader.biWidth * pbi.bmiHeader.biBitCount + 31) / 32) * 4 * pbi.bmiHeader.biHeight;
		//pvBits = HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, 512);
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(4));
		//Assert.That(pbi.bmiHeader.biSize, Is.EqualTo(Marshal.SizeOf(typeof(BITMAPINFOHEADER))));
		//Assert.That(pbi.bmiHeader.biWidth, Is.EqualTo(4));
		//Assert.That(pbi.bmiHeader.biHeight, Is.EqualTo(4));
		//Assert.That(pbi.bmiHeader.biPlanes, Is.EqualTo(1));
		//Assert.That(pbi.bmiHeader.biBitCount, Is.EqualTo(32));
		//Assert.That(pbi.bmiHeader.biCompression, Is.EqualTo(BI_RGB));
		//Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(64));
		//Assert.That(pbi.bmiHeader.biXPelsPerMeter, Is.EqualTo(0));
		//Assert.That(pbi.bmiHeader.biYPelsPerMeter, Is.EqualTo(0));
		//Assert.That(pbi.bmiHeader.biClrUsed, Is.EqualTo(0));
		//Assert.That(pbi.bmiHeader.biClrImportant, Is.EqualTo(0));

		//pbi.bmiHeader.biBitCount;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, (IntPtr)(IntPtr) - 1, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(GetDIBits(default, hbmp, 0, 4, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//pbi.bmiHeader.biBitCount = 24;
		//pbi.bmiHeader.biWidth = 3;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(4));

		//pbi.bmiHeader.biBitCount = 24;
		//pbi.bmiHeader.biWidth = 3;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(4));

		//pbi.bmiHeader.biBitCount = 17;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//pbi.Zero();
		//pbi.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
		//pbi.bmiHeader.biBitCount = 5;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 4, pvBits, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//DeleteObject(hbmp);
		//HeapFree(GetProcessHeap(), 0, pvBits);

		//hbmp = CreateBitmap(3, 5, 1, 4, default);
		//Assert.That(hbmp != 0, "failed to create bitmap\n");
		//pbi.Zero();
		//pbi.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(1));
		//Assert.That(pbi.bmiHeader.biWidth, Is.EqualTo(3));
		//Assert.That(pbi.bmiHeader.biHeight, Is.EqualTo(5));
		//Assert.That(pbi.bmiHeader.biBitCount, Is.EqualTo(4));
		//Assert.That(pbi.bmiHeader.biSizeImage, Is.EqualTo(20));

		//pbi.bmiHeader.biSizeImage;
		//Assert.That(GetDIBits(hdcScreen, hbmp, 0, 0, default, pbi, DIBColorMode.DIB_RGB_COLORS), ResultIs.Value(0));

		//cjSizeImage = ((pbi.bmiHeader.biWidth * pbi.bmiHeader.biBitCount + 31) / 32) * 4 * pbi.bmiHeader.biHeight;
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