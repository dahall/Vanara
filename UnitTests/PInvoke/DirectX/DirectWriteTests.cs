using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Vanara.PInvoke.Dwrite;
using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke.Tests;

public class DirectWriteTests : GenericComTester<IDWriteFactory>
{
	private const string fontDir = @"C:\Temp\Fonts";

	[Test]
	public void CreateFontFaceTest()
	{
		var ldr = new FontLoader();
		var pList = Directory.EnumerateFiles(fontDir).Take(1).Select(f => Instance.CreateFontFileReference(f)).ToArray();
		try
		{
			pList[0].Analyze(out var sup, out var ft, out var fc, out var fcn);
			TestContext.WriteLine($"Supported={sup}; FileType={ft}; FaceType={fc}; FaceCnt={fcn}");
			var pFF = ComReleaserFactory.Create(Instance.CreateFontFace(fc, (uint)pList.Length, pList, 0, DWRITE_FONT_SIMULATIONS.DWRITE_FONT_SIMULATIONS_NONE));
			Assert.That(pFF.Item.GetType(), Is.EqualTo(fc));
			var ff = new IDWriteFontFile[pList.Length];
			var fflen = (uint)ff.Length;
			Assert.That(() => pFF.Item.GetFiles(ref fflen, ff), Throws.Nothing);
			ff.WriteValues();
			TestContext.WriteLine($"Index in font files: {pFF.Item.GetIndex()}");
			TestContext.WriteLine($"Simulations: {pFF.Item.GetSimulations()}");
			Assert.That(pFF.Item.IsSymbolFont(), Is.False);
			Assert.That(() => { pFF.Item.GetMetrics(out var faceMetrics); faceMetrics.WriteValues(); }, Throws.Nothing);
			var glCnt = (int)pFF.Item.GetGlyphCount();
			Assert.That(glCnt, Is.GreaterThan(0));
			glCnt = Math.Min(3, glCnt);
			var glm = new DWRITE_GLYPH_METRICS[glCnt];
			var glidx = Enumerable.Range(0, glCnt).Select(i => (ushort)i).ToArray();
			Assert.That(() => pFF.Item.GetDesignGlyphMetrics(glidx, (uint)glCnt, glm), Throws.Nothing);
			glm.WriteValues();
			Assert.That(() =>
			{
				var tag = DWRITE_FONT_FEATURE_TAG.DWRITE_FONT_FEATURE_TAG_DEFAULT;
				pFF.Item.TryGetFontTable((uint)tag, out var tableData, out var tableSize, out var tableCtx, out var tableExists);
				TestContext.WriteLine($"Table: {tag} = Sz:{tableSize}, {tableExists}");
				pFF.Item.ReleaseFontTable(tableCtx);
			}, Throws.Nothing);
			var rParams = Instance.CreateRenderingParams();
			pFF.Item.GetRecommendedRenderingMode(9f, 72f, DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL, rParams).WriteValues();
			var hMon = User32.MonitorFromPoint(POINT.Empty, User32.MonitorFlags.MONITOR_DEFAULTTOPRIMARY);
			rParams = Instance.CreateMonitorRenderingParams(hMon);
			pFF.Item.GetRecommendedRenderingMode(9f, 72f, DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL, rParams).WriteValues();
			rParams = Instance.CreateCustomRenderingParams(2.2f, 1f, 1f, DWRITE_PIXEL_GEOMETRY.DWRITE_PIXEL_GEOMETRY_BGR, DWRITE_RENDERING_MODE.DWRITE_RENDERING_MODE_ALIASED);
			pFF.Item.GetRecommendedRenderingMode(9f, 72f, DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL, rParams).WriteValues();
			pFF.Item.GetGdiCompatibleMetrics(9f, 72f).WriteValues();
			Assert.That(() => pFF.Item.GetGdiCompatibleGlyphMetrics(9f, 72f, default, true, glidx, (uint)glCnt, glm), Throws.Nothing);
			glm.WriteValues();
		}
		finally
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}

	[Test]
	public void CreateTextFormatTest()
	{
		using var pTF = ComReleaserFactory.Create(Instance.CreateTextFormat("Arial", default, DWRITE_FONT_WEIGHT.DWRITE_FONT_WEIGHT_NORMAL, DWRITE_FONT_STYLE.DWRITE_FONT_STYLE_NORMAL, DWRITE_FONT_STRETCH.DWRITE_FONT_STRETCH_NORMAL, 11f, "en-us"));
		Assert.That(pTF.Item.GetFontSize(), Is.GreaterThan(0f));
		Assert.That(() => pTF.Item.SetTextAlignment(DWRITE_TEXT_ALIGNMENT.DWRITE_TEXT_ALIGNMENT_CENTER), Throws.Nothing);
		var sb = new StringBuilder(20);
		Assert.That(() => pTF.Item.GetLocaleName(sb, (uint)sb.Capacity), Throws.Nothing);
		Assert.That(sb.ToString(), Is.EqualTo("en-us"));
	}

	[Test]
	public void CreateTypographyTest()
	{
		using var pTyp = ComReleaserFactory.Create(Instance.CreateTypography());
		var cnt = pTyp.Item.GetFontFeatureCount();
		if (cnt > 0)
			pTyp.Item.GetFontFeature(0).WriteValues();
	}

	[Test]
	public void EnumFontsTest()
	{
		Instance.GetSystemFontCollection(out var coll);
		using var pColl = ComReleaserFactory.Create(coll);
		EnumFonts(pColl.Item);
	}

	[Test]
	public void FontFileLoaderTest()
	{
		var loader = new FileLoader();
		Assert.That(() => Instance.RegisterFontFileLoader(loader), Throws.Nothing);
		try
		{
		}
		finally
		{
			Assert.That(() => Instance.UnregisterFontFileLoader(loader), Throws.Nothing);
		}
	}

	[Test]
	public void GetGdiInteropTest() => Assert.That(() =>
	{
		using var p = ComReleaserFactory.Create(Instance.GetGdiInterop());
	}, Throws.Nothing);

	[Test]
	public void LoadCustomFontsTest()
	{
		var loader = new FontLoader();
		Instance.RegisterFontCollectionLoader(loader);
		try
		{
			using var pDir = new SafeCoTaskMemString(fontDir);
			using var pColl = ComReleaserFactory.Create(Instance.CreateCustomFontCollection(loader, pDir, pDir.Size));
			EnumFonts(pColl.Item);
		}
		finally
		{
			Instance.UnregisterFontCollectionLoader(loader);
		}
	}

	[Test]
	public void StructTest()
	{
		foreach (var ss in TestHelper.GetNestedStructSizes(typeof(Dwrite)))
			TestContext.WriteLine(ss);
	}

	protected override IDWriteFactory InitInstance() => DWriteCreateFactory<IDWriteFactory>();

	private static void EnumFonts(IDWriteFontCollection coll)
	{
		var count = coll.GetFontFamilyCount();
		var locale = System.Globalization.CultureInfo.CurrentCulture.Name;
		for (var i = 0U; i < count; i++)
		{
			try
			{
				using var pFontFam = ComReleaserFactory.Create(coll.GetFontFamily(i));
				using var piFamNames = ComReleaserFactory.Create(pFontFam.Item.GetFamilyNames());
				DWriteLocalizedStrings pFamNames = new(piFamNames.Item);
				if (pFamNames.ContainsKey(locale))
					TestContext.WriteLine(pFamNames[locale]);
			}
			catch (Exception ex)
			{
				TestContext.WriteLine("ERROR: " + ex.Message);
			}
		}
	}

	[ComVisible(true)]
	public class FileLoader : IDWriteFontFileLoader
	{
		public HRESULT CreateStreamFromKey([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, out IDWriteFontFileStream fontFileStream)
		{
			fontFileStream = new FileStream(Directory.EnumerateFiles(fontDir).First());
			return default;
		}
	}

	[ComVisible(true)]
	public class FileStream(string path) : IDWriteFontFileStream, IDisposable
	{
		private readonly FileInfo fi = new(path);
		private readonly SafeHGlobalHandle mem = new(File.ReadAllBytes(path));

		public void Dispose()
		{
			((IDisposable)mem).Dispose();
			GC.SuppressFinalize(this);
		}

		public HRESULT GetFileSize(out ulong fileSize)
		{
			fileSize = (ulong)fi.Length;
			return default;
		}

		public HRESULT GetLastWriteTime(out System.Runtime.InteropServices.ComTypes.FILETIME lastWriteTime)
		{
			lastWriteTime = fi.LastWriteTime.ToFileTimeStruct();
			return default;
		}

		public HRESULT ReadFileFragment(out IntPtr fragmentStart, ulong fileOffset, ulong fragmentSize, [Out] out IntPtr fragmentContext)
		{
			fragmentContext = default;
			if (fileOffset + fragmentSize >= (ulong)fi.Length)
			{
				fragmentStart = default;
				return HRESULT.E_FAIL;
			}
			fragmentStart = ((IntPtr)mem).Offset((long)fileOffset);
			return default;
		}

		public void ReleaseFileFragment([In] IntPtr fragmentContext)
		{
		}
	}

	[ComVisible(true)]
	public class FontEnumerator(IDWriteFactory fact, string path) : IDWriteFontFileEnumerator
	{
		private readonly IEnumerator<string> enumerator = Directory.EnumerateFiles(path).GetEnumerator();

		public HRESULT GetCurrentFontFile(out IDWriteFontFile? fontFile)
		{
			try { fontFile = fact.CreateFontFileReference(enumerator.Current); }
			catch (COMException ex) { fontFile = null; return ex.HResult; }
			return default;
		}

		public HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasCurrentFile)
		{ hasCurrentFile = enumerator.MoveNext(); return HRESULT.S_OK; }
	}

	[ComVisible(true)]
	public class FontLoader : IDWriteFontCollectionLoader
	{
		public HRESULT CreateEnumeratorFromKey([In] IDWriteFactory factory, IntPtr collectionKey, uint collectionKeySize, out IDWriteFontFileEnumerator? fontFileEnumerator)
		{
			fontFileEnumerator = null;
			if (factory is null || collectionKey == default)
				return HRESULT.E_INVALIDARG;

			fontFileEnumerator = new FontEnumerator(factory, StringHelper.GetString(collectionKey, CharSet.Unicode, collectionKeySize)!);

			return HRESULT.S_OK;
		}
	}
}