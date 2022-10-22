using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Usp10;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class Usp10Tests
	{
		private const string str = "Hello, world!\u064A\u064F\u0633\u0627\u0648\u0650\u064A How are you?";
		private SafeHDC dc;
		private SafeHFONT fnt;
		private SafeSCRIPT_CACHE sc;

		[OneTimeSetUp]
		public void _Setup()
		{
			sc = new SafeSCRIPT_CACHE();
			dc = CreateCompatibleDC();
			fnt = CreateFont(20, iQuality: OutputQuality.PROOF_QUALITY, iPitchAndFamily: PitchAndFamily.DEFAULT_PITCH | PitchAndFamily.FF_ROMAN, pszFaceName: "Times New Roman");
			dc.SelectObject(fnt);
		}

		[OneTimeTearDown]
		public void _TearDown()
		{
			fnt.Dispose();
			dc.Dispose();
			sc.Dispose();
		}

		[Test]
		public void SafeSCRIPT_CACHETest()
		{
			SafeSCRIPT_CACHE lsc = new();
			Assert.That(lsc.IsInvalid, Is.True);
			Assert.That(ScriptCacheGetHeight(dc, lsc, out _), ResultIs.Successful);
			Assert.That(lsc.IsInvalid, Is.False);
			lsc.Dispose();
			Assert.That(lsc.IsInvalid, Is.True);
		}

		[Test]
		public void ScriptBreakTest()
		{
			SCRIPT_LOGATTR[] array = new SCRIPT_LOGATTR[str.Length];
			Assert.That(ScriptBreak(str, str.Length, new(), array), ResultIs.Successful);
			Assert.That(array.Select(i => i.fWordStop), Has.Some.True);
			foreach (SCRIPT_LOGATTR la in array)
			{
				la.WriteValues();
			}
		}

		[Test]
		public void ScriptCacheGetHeightTest()
		{
			Assert.That(ScriptCacheGetHeight(dc, sc, out int h), ResultIs.Successful);
			Assert.That(h, Is.GreaterThan(0));
		}

		[Test]
		public void ScriptGetCMapTest()
		{
			ushort[] gl = new ushort[str.Length];
			Assert.That(ScriptGetCMap(dc, sc, str, str.Length, 0, gl), ResultIs.Successful);
			Assert.That(gl[str.Length - 1], Is.Not.Zero);
			gl.WriteValues();
		}

		[Test]
		public void ScriptGetFontAlternateGlyphsTest()
		{
			const int max = 50;
			ushort[] pItems = new ushort[max];
			Assert.That(ScriptGetFontAlternateGlyphs(dc, sc, default, "DFLT", "latn", "afrc", 7961, max, pItems, out int c), ResultIs.Successful);
			foreach (ushort i in pItems.Take(c))
			{
				i.WriteValues();
			}
		}

		[Test]
		public void ScriptGetFontFeatureTagsTest()
		{
			const int max = 50;
			OPENTYPE_TAG[] pItems = new OPENTYPE_TAG[max];
			Assert.That(ScriptGetFontFeatureTags(dc, sc, default, "DFLT", "latn", max, pItems, out int c), ResultIs.Successful);
			foreach (OPENTYPE_TAG i in pItems.Take(c))
			{
				i.WriteValues();
			}
		}

		[Test]
		public void ScriptGetFontLanguageTagsTest()
		{
			const int max = 50;
			OPENTYPE_TAG[] pItems = new OPENTYPE_TAG[max];
			Assert.That(ScriptGetFontLanguageTags(dc, sc, default, "DFLT", max, pItems, out int c), ResultIs.Successful);
			foreach (OPENTYPE_TAG i in pItems.Take(c))
			{
				i.WriteValues();
			}
		}

		[Test]
		public void ScriptGetFontPropertiesTest()
		{
			var fp = SCRIPT_FONTPROPERTIES.Default;
			Assert.That(ScriptGetFontProperties(dc, sc, ref fp), ResultIs.Successful);
			Assert.That(fp.cBytes, Is.GreaterThan(0));
			fp.WriteValues();
		}

		[Test]
		public void ScriptGetFontScriptTagsTest()
		{
			const int max = 50;
			OPENTYPE_TAG[] pItems = new OPENTYPE_TAG[max];
			Assert.That(ScriptGetFontScriptTags(dc, sc, default, max, pItems, out int c), ResultIs.Successful);
			foreach (OPENTYPE_TAG i in pItems.Take(c))
			{
				i.WriteValues();
			}
		}

		[Test]
		public void ScriptGetGlyphABCWidthTest()
		{
			Assert.That(ScriptGetGlyphABCWidth(dc, sc, 7961, out var abc), ResultIs.Successful);
			abc.WriteValues();
		}

		[Test]
		public void ScriptGetPropertiesTest()
		{
			Assert.That(ScriptGetProperties(out SCRIPT_PROPERTIES[] sp), ResultIs.Successful);
			sp.WriteValues();
		}

		[Test]
		public void ScriptIsComplexTest() => Assert.That(ScriptIsComplex(str, str.Length, SIC.SIC_COMPLEX), ResultIs.Successful);

		[Test]
		public void ScriptItemizeTest()
		{
			const int max = 50;
			Assert.That(ScriptGetProperties(out SCRIPT_PROPERTIES[] sp), ResultIs.Successful);
			SCRIPT_ITEM[] pItems = new SCRIPT_ITEM[max];
			Assert.That(ScriptItemize(str, str.Length, pItems.Length, default, default, pItems, out int cItems), ResultIs.Successful);
			Assert.That(pItems.Take(cItems).Select(i => i.a.eScript).Select(s => sp[s].fComplex), Has.Some.True);
			foreach (SCRIPT_ITEM i in pItems.Take(cItems))
			{
				i.WriteValues();
			}
		}

		[Test]
		public void ScriptItemizeTest2()
		{
			const int max = 50;
			Assert.That(ScriptGetProperties(out SCRIPT_PROPERTIES[] sp), ResultIs.Successful);

			Assert.That(ScriptRecordDigitSubstitution(LCID.LOCALE_CUSTOM_DEFAULT, out SCRIPT_DIGITSUBSTITUTE sub), ResultIs.Successful);
			sub.WriteValues();

			Assert.That(ScriptApplyDigitSubstitution(sub, out SCRIPT_CONTROL sc, out SCRIPT_STATE ss), ResultIs.Successful);
			sc.WriteValues();
			ss.WriteValues();

			SCRIPT_ITEM[] pItems = new SCRIPT_ITEM[max];
			Assert.That(ScriptItemize(str, str.Length, pItems.Length, sc, ss, pItems, out int cItems), ResultIs.Successful);
			Assert.That(pItems.Take(cItems).Select(i => i.a.eScript).Select(s => sp[s].fComplex), Has.Some.True);
			foreach (SCRIPT_ITEM i in pItems.Take(cItems))
			{
				i.WriteValues();
			}
		}

		[Test]
		public void ScriptShapeTest()
		{
			var max = (int)Math.Round(str.Length * 1.5m + 16);
			var sa = new SCRIPT_ANALYSIS();
			var glfs = new ushort[max];
			var log = new ushort[str.Length];
			var sva = new SCRIPT_VISATTR[max];
			Assert.That(ScriptShape(dc, sc, str, str.Length, max, ref sa, glfs, log, sva, out var c), ResultIs.Successful);
			c.WriteValues();
			sa.WriteValues();
			Array.Resize(ref glfs, c);
			glfs.WriteValues();
			log.WriteValues();
			Array.Resize(ref sva, c);
			sva.WriteValues();
		}

		[Test]
		public void ScriptStringAnalyseTest()
		{
			using SafeSCRIPT_STRING_ANALYSIS ssa = ScriptStringAnalyse(dc, str, SSA.SSA_FALLBACK | SSA.SSA_GLYPHS | SSA.SSA_LINK);
			Assert.That(ssa.IsInvalid, Is.False);
			Assert.That(ssa.Size.HasValue, Is.True);
			Assert.That(ssa.OutChars, Is.EqualTo(33));
			ssa.WriteValues();
			Assert.That(ssa.Out(POINT.Empty), ResultIs.Successful);
			Assert.That(ssa.CPtoX(5, true), Is.GreaterThan(0));
			Assert.That(ssa.XtoCP(ssa.Size.Value.Width).cp, Is.GreaterThan(30));
		}
	}
}