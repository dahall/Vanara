using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke.Tests
{
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
			using (var hEmf = GetEnhMetaFile(@"C:\Temp\test.emf"))
			{
				Assert.That(hEmf, ResultIs.ValidHandle);

				var hdr = GetEnhMetaFileHeader(hEmf);

				Assert.That(EnumEnhMetaFile(HDC.NULL, hEmf, Proc, default, default), ResultIs.Successful);
				Assert.That(count, Is.EqualTo(hdr.nRecords));
			}

			int Proc(HDC hdc, HGDIOBJ[] lpht, IntPtr lpmr, int nHandles, IntPtr data)
			{
				var rec = (ENHMETARECORD)lpmr;
				TestContext.WriteLine($"{++count}) {rec.iType} {string.Join(",", rec.dParm.Select(v => v.ToString()))}");
				return 1;
			}
		}

		[Test]
		public void EnumFontFamiliesExTest()
		{
			using (var hdc = SafeHDC.ScreenCompatibleDCHandle)
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
			using (var hdc = SafeHDC.ScreenCompatibleDCHandle)
			{
				var g = GetFontUnicodeRanges(hdc);
				Assert.That(g.cRanges, Is.GreaterThan(0));
				Assert.That(g.ranges.Length, Is.EqualTo((int)g.cRanges));
				g.WriteValues();
			}
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
			using (var mem = new SafeHGlobalHandle(Marshal.SizeOf<OUTLINETEXTMETRIC>() + 1024))
			{
				Assert.That(GetOutlineTextMetrics(hdc, mem.Size, mem), Is.GreaterThan(0));
				var otm = mem.ToStructure<OUTLINETEXTMETRIC>();
				otm.WriteValues();
				TestContext.WriteLine(mem.ToString(-1, otm.otmpFaceName.ToInt32(), CharSet.Auto));
				TestContext.WriteLine(mem.ToString(-1, otm.otmpFamilyName.ToInt32(), CharSet.Auto));
				TestContext.WriteLine(mem.ToString(-1, otm.otmpFullName.ToInt32(), CharSet.Auto));
				TestContext.WriteLine(mem.ToString(-1, otm.otmpStyleName.ToInt32(), CharSet.Auto));
			}
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
}