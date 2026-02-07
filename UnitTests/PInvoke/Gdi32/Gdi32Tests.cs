using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class Gdi32Tests
{
	// TODO: [Test]
	public void AlphaBlendTest()
	{
		throw new NotImplementedException();
	}

	// TODO: [Test]
	public void BitBltTest()
	{
		throw new NotImplementedException();
	}

	// TODO: [Test]
	public void CreateCompatibleDCTest()
	{
		throw new NotImplementedException();
	}

	[Test]
	public void CreateFontTest()
	{
		Assert.That(CreateFont(), ResultIs.ValidHandle);
	}

	[Test]
	public void CreatePaletteTest()
	{
		LOGPALETTE lp = new() { palVersion = 0x300, palNumEntries = 32, palPalEntry = new PALETTEENTRY[32] };
		Array.Fill(lp.palPalEntry, new PALETTEENTRY() { peFlags = PC.PC_NOCOLLAPSE });
		SafeHPALETTE hp = CreatePalette(lp);
		Assert.That(hp, ResultIs.ValidHandle);
		Assert.That(GetPaletteEntries(hp), Is.EqualTo(32));
		var pes = new PALETTEENTRY[32];
		Assert.That(GetPaletteEntries(hp, 0, 32, pes), Is.EqualTo(32));
		Assert.That(pes.All(pe => pe.peFlags == PC.PC_NOCOLLAPSE), Is.True);
	}

	// TODO: [Test]
	public void DeleteDCTest()
	{
		throw new NotImplementedException();
	}

	// TODO: [Test]
	public void DeleteObjectTest()
	{
		throw new NotImplementedException();
	}

	[Test]
	public void EnumEnhMetaFileTest()
	{
		var count = 0;
		using var hEmf = GetEnhMetaFile(@"C:\Temp\test.emf");
		Assert.That(hEmf, ResultIs.ValidHandle);

		var hdr = GetEnhMetaFileHeader(hEmf);

		Assert.That(EnumEnhMetaFile(HDC.NULL, hEmf, Proc, default, default), ResultIs.Successful);
		Assert.That(count, Is.EqualTo(hdr.nRecords));

		int Proc(HDC hdc, HGDIOBJ[] lpht, ENHMETARECORD lpmr, int nHandles, IntPtr data)
		{
			TestContext.WriteLine($"{++count}) {lpmr.iType} {string.Join(",", lpmr.dParm.Select(v => v.ToString()))}");
			return 1;
		}
	}

	[Test]
	public void EnumFontFamiliesExTest()
	{
		using var hdc = SafeHDC.ScreenCompatibleDCHandle;
		Assert.That(EnumFontFamiliesEx(hdc), Has.Count.GreaterThan(0));
	}

	// TODO: [Test]
	public void GdiFlushTest()
	{
		throw new NotImplementedException();
	}

	[Test]
	public void GetFontUnicodeRangesTest()
	{
		using var hdc = SafeHDC.ScreenCompatibleDCHandle;
		var g = GetFontUnicodeRanges(hdc);
		Assert.That(g.cRanges, Is.GreaterThan(0));
		Assert.That(g.ranges.Length, Is.EqualTo((int)g.cRanges));
		g.WriteValues();
	}

	[Test]
	public void GetGlyphOutlineTest()
	{
		using (var hdc = SafeHDC.ScreenCompatibleDCHandle)
		using (var hfont = CreateFont(13, pszFaceName: "Arial"))
		using (hdc.SelectObject(hfont))
		{
			Assert.That(GetGlyphOutline(hdc, '&', GGO.GGO_GRAY8_BITMAP, out var metrics, 0, default, MAT2.IdentityMatrix), Is.Not.EqualTo(GDI_ERROR));
			metrics.WriteValues();
		}
	}

	// TODO: [Test]
	public void GetObjectTest()
	{
		throw new NotImplementedException();
	}

	// TODO: [Test]
	public void GetObjectTest1()
	{
		throw new NotImplementedException();
	}

	[Test]
	public void GetOutlineTextMetricsTest()
	{
		using (var hdc = SafeHDC.ScreenCompatibleDCHandle)
		using (var hfont = CreateFont(13, pszFaceName: "Arial"))
		using (hdc.SelectObject(hfont))
		{
			Assert.That(GetOutlineTextMetrics(hdc, out SafeCoTaskMemStruct<OUTLINETEXTMETRIC> otm), Is.GreaterThan(0));
			ref var otmRef = ref otm.AsRef();
			otmRef.WriteValues();
			TestContext.WriteLine(otm.GetStringAtOffset(otmRef.otmpFaceName, CharSet.Auto));
			TestContext.WriteLine(otm.GetStringAtOffset(otmRef.otmpFullName, CharSet.Auto));
			TestContext.WriteLine(otm.GetStringAtOffset(otmRef.otmpStyleName, CharSet.Auto));
		}
	}

	[Test]
	public void GetTextCharsetInfoTest()
	{
		using var hdc = SafeHDC.ScreenCompatibleDCHandle;
		var cs = GetTextCharsetInfo(hdc, out var fs);
		Assert.That(cs, Is.Not.EqualTo(CharacterSetUint.DEFAULT_CHARSET));
		fs.WriteValues();
	}

	[Test]
	public void PolyTextOutTest()
	{
		using (var hdc = SafeHDC.ScreenCompatibleDCHandle)
		using (var hfont = CreateFont(48, pszFaceName: "Arial"))
		using (hdc.SelectObject(hfont))
		{
			POLYTEXT[] pts =
			[
				new(10, 10, "Hello,"),
				new(10, 70, "World!", ETO.ETO_CLIPPED, new(0, 0, 100, 20), new SafeNativeArray<int>([20, 15, 15, 15, 15, 10])),
			];
			Assert.That(PolyTextOut(hdc, pts), ResultIs.Successful);
		}
	}

	[Test]
	public void TranslateCharsetInfoTest()
	{
		var acp = Kernel32.GetACP();
		Assert.That(TranslateCharsetInfo((IntPtr)acp, out var csi, TCI.TCI_SRCCODEPAGE), ResultIs.Successful);
		csi.WriteValues();

		Assert.That(TranslateCharsetInfo((IntPtr)csi.ciCharset, out csi, TCI.TCI_SRCCHARSET), ResultIs.Successful);
		csi.WriteValues();

		Assert.That(TranslateCharsetInfo((IntPtr)(int)(uint)Kernel32.GetThreadLocale(), out csi, TCI.TCI_SRCLOCALE), ResultIs.Successful);
		csi.WriteValues();

		FONTSIGNATURE fs = default;
		using (var hdc = SafeHDC.ScreenCompatibleDCHandle)
			GetTextCharsetInfo(hdc, out fs);
		Assert.That(TranslateCharsetInfo(fs.fsCsb, out csi, TCI.TCI_SRCFONTSIG), ResultIs.Successful);
		csi.WriteValues();
	}

	// TODO: [Test]
	public void SelectObjectTest()
	{
		throw new NotImplementedException();
	}

	// TODO: [Test]
	public void SetBkModeTest()
	{
		throw new NotImplementedException();
	}

	// TODO: [Test]
	public void SetLayoutTest()
	{
		throw new NotImplementedException();
	}

	// TODO: [Test]
	public void TransparentBltTest()
	{
		throw new NotImplementedException();
	}
}