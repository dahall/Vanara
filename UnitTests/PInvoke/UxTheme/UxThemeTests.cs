using NUnit.Framework;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.UxTheme;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class UxThemeTests
	{
		private const int bufSz = 1024;
		private SafeThemeHandle hwt, hbt;

		[OneTimeSetUp]
		public void _Setup()
		{
			hwt = OpenThemeDataEx(new HandleRef(), "Window", OpenThemeDataOptions.None);
			Assert.That(hwt.IsInvalid, Is.False);
			hbt = OpenThemeDataEx(new HandleRef(), "Button", OpenThemeDataOptions.None);
			Assert.That(hbt.IsInvalid, Is.False);
		}

		[OneTimeTearDown]
		public void _TearDown()
		{
			Assert.That(() => hwt.Close(), Throws.Nothing);
			Assert.That(hwt.IsInvalid, Is.True);
			Assert.That(() => hbt.Close(), Throws.Nothing);
			Assert.That(hbt.IsInvalid, Is.True);
		}

		[Test]
		public void BeginBufferedAnimationTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void BeginBufferedPaintTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void BufferedPaintInitTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void BufferedPaintRenderAnimationTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void BufferedPaintStopAllAnimationsTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void BufferedPaintUnInitTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void DrawThemeBackgroundExTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void DrawThemeBackgroundTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void DrawThemeEdgeTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void DrawThemeIconTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void DrawThemeParentBackgroundExTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void DrawThemeParentBackgroundTest()
		{
			throw new NotImplementedException();
		}
		[Test]
		public void DrawThemeTextExTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void DrawThemeTextTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void EnableThemeDialogTextureTest()
		{
			var f = new Form() { Size = new Size(300, 300) };
			f.Shown += (s, e) =>
			{
				var hr = EnableThemeDialogTexture(new HandleRef(f, f.Handle), ThemeDialogTextureFlags.ETDT_ENABLEAEROWIZARDTAB);
				Assert.That(hr.Succeeded);
				///f.Close();
			};
			f.ShowDialog();
		}

		[Test]
		public void EndBufferedAnimationTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void EndBufferedPaintTest()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void GetCurrentThemeNameTest()
		{
			var sb = new StringBuilder(bufSz, bufSz);
			Assert.That(GetCurrentThemeName(sb, bufSz, null, 0, null, 0).Succeeded);
			Assert.That(sb, Has.Length.GreaterThan(0));

			var sb2 = new StringBuilder(bufSz, bufSz);
			var sb3 = new StringBuilder(bufSz, bufSz);
			Assert.That(GetCurrentThemeName(null, 0, sb2, bufSz, sb3, bufSz).Succeeded);
			Assert.That(sb2, Has.Length.GreaterThan(0));
			Assert.That(sb3, Has.Length.GreaterThan(0));
		}

		[Test]
		public void GetThemeAnimationPropertyTest()
		{
			// Can't test since not documented
			return;
			var buf = new SafeHGlobalHandle(bufSz);
			var hr = GetThemeAnimationProperty(hbt, 1, 2, TA_PROPERTY.TAP_TRANSFORMCOUNT, (IntPtr)buf, (uint)bufSz, out var sz);
			if (hr.Failed) TestContext.WriteLine(hr);
			Assert.That(hr.Succeeded);
			Assert.That(sz, Is.Not.Zero);
		}

		[Test]
		public void GetThemeAnimationTransformTest()
		{
			// Can't test since not documented
			return;
			var tran = new TA_TRANSFORM();
			var hr = GetThemeAnimationTransform(hbt, 1, 2, 0, ref tran, (uint)Marshal.SizeOf<TA_TRANSFORM>(), out var sz);
			if (hr.Failed) TestContext.WriteLine(hr);
			Assert.That(hr.Succeeded);
			Assert.That(sz, Is.Not.Zero);
		}

		[Test]
		public void GetThemeAppPropertiesTest()
		{
			ThemeAppProperties ap = 0;
			Assert.That(() => ap = GetThemeAppProperties(), Throws.Nothing);
			Assert.That(ap, Is.Not.Zero);
		}

		[Test]
		public void GetThemeBackgroundContentRectTest()
		{
			var rect = new RECT(0, 0, 400, 400);
			Assert.That(GetThemeBackgroundContentRect(hwt, Gdi32.SafeDCHandle.Null, 1, 0, ref rect, out var cntRect).Succeeded);
			Assert.That(cntRect, Is.Not.EqualTo(new RECT()));
			TestContext.WriteLine(cntRect);
		}

		[Test]
		public void GetThemeBackgroundExtentTest()
		{
			var rect = new RECT(0, 0, 400, 400);
			GetThemeBackgroundContentRect(hwt, Gdi32.SafeDCHandle.Null, 21, 1, ref rect, out var cntRect);
			Assert.That(GetThemeBackgroundExtent(hwt, Gdi32.SafeDCHandle.Null, 21, 1, ref cntRect, out var r).Succeeded);
			Assert.That(r.IsEmpty, Is.False);
		}

		[Test]
		public void GetThemeBackgroundRegionTest()
		{
			var rect = new RECT(0, 0, 400, 400);
			GetThemeBackgroundContentRect(hwt, Gdi32.SafeDCHandle.Null, 21, 1, ref rect, out var cntRect);
			Assert.That(GetThemeBackgroundRegion(hwt, Gdi32.SafeDCHandle.Null, 21, 1, ref cntRect, out var r).Succeeded);
			Assert.That(r, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(Gdi32.DeleteObject(r));
		}

		[TestCase(21, 1, 0)]
		[TestCase(21, 1, (int)ThemeProperty.TMT_DIBDATA)]
		[TestCase(21, 1, (int)ThemeProperty.TMT_GLYPHDIBDATA)]
		public void GetThemeBitmapTest(int p, int s, int id)
		{
			var hr = GetThemeBitmap(hwt, p, s, id, GBF.GBF_DIRECT, out var hbmp);
			if (hr.Failed) TestContext.WriteLine(hr);
			Assert.That(hr.Succeeded);
			Assert.That(hbmp, Is.Not.EqualTo(IntPtr.Zero));
			Windows.Forms.Tests.ImageListTests.ShowImage(Image.FromHbitmap(hbmp));
		}

		[Test]
		public void GetThemeBoolTest()
		{
			Assert.That(GetThemeBool(hwt, 1, 0, (int)ThemeProperty.TMT_TRANSPARENT, out var result).Succeeded);
			Assert.That(result, Is.True);
		}

		[Test]
		public void GetThemeColorTest()
		{
			var hr = GetThemeColor(hwt, 1, 0, (int)ThemeProperty.TMT_TEXTCOLOR, out var result);
			if (hr.Failed) TestContext.WriteLine(hr);
			Assert.That(hr.Succeeded);
			Assert.That(result, Is.EqualTo(new COLORREF(0,0,0)));

			hr = GetThemeColor(hwt, 1, 0, (int)ThemeProperty.TMT_FILLCOLOR, out result);
			if (hr.Failed) TestContext.WriteLine(hr);
			Assert.That(hr.Succeeded, Is.False);
		}

		[Test]
		public void GetThemeDocumentationPropertyTest()
		{
			var nm = new StringBuilder(bufSz, bufSz);
			GetCurrentThemeName(nm, bufSz, null, 0, null, 0);

			var sb = new StringBuilder(bufSz, bufSz);
			var hr = GetThemeDocumentationProperty(nm.ToString(), SZ_THDOCPROP_DISPLAYNAME, sb, bufSz);
			if (hr.Failed) TestContext.WriteLine(hr);
			Assert.That(hr.Succeeded);
		}

		[Test]
		public void GetThemeEnumValueTest()
		{
			var hr = GetThemeEnumValue(hwt, 1, 0, (int)ThemeProperty.TMT_SIZINGTYPE, out var result);
			if (hr.Failed) TestContext.WriteLine(hr);
			Assert.That(hr.Succeeded);
			Assert.That(Enum.IsDefined(typeof(SIZINGTYPE), result));
			Assert.That(result, Is.EqualTo(1));
		}

		[Test]
		public void GetThemeFilenameTest()
		{
			var sb = new StringBuilder(bufSz, bufSz);
			var hr = GetThemeFilename(hwt, 21, 1, (int)ThemeProperty.TMT_IMAGEFILE, sb, sb.Capacity);
			if (hr.Failed) TestContext.WriteLine(hr);
			// Can't test this as there are no properties that return a value.
			Assert.That(hr.Failed);
			//Assert.That(sb, Is.Not.Null.And.Length.GreaterThan(0));
		}

		[Test]
		public void GetThemeFontTest()
		{
			Assert.That(GetThemeFont(hbt, Gdi32.SafeDCHandle.Null, 6, 0, (int)ThemeProperty.TMT_FONT, out var result).Succeeded);
			Assert.That(result.lfHeight, Is.EqualTo(-16));
			Assert.That(() => System.Drawing.Font.FromLogFont(result), Throws.Nothing);
		}

		[Test]
		public void GetThemeIntListTest()
		{
			Assert.That(GetThemeIntList(hbt, 1, 0, (int)ThemeProperty.TMT_TRANSITIONDURATIONS, out var result).Succeeded);
			Assert.That(result.iValueCount, Is.EqualTo(37));
		}

		[Test]
		public void GetThemeIntTest()
		{
			using (var hat = OpenThemeDataEx(new HandleRef(), "AeroWizard", OpenThemeDataOptions.None))
			{
				Assert.That(GetThemeInt(hat, 1, 0, (int)ThemeProperty.TMT_TEXTGLOWSIZE, out var result).Succeeded);
				Assert.That(result, Is.EqualTo(12));
			}
		}
		[Test]
		public void GetThemeMarginsTest()
		{
			Assert.That(GetThemeMargins(hbt, Gdi32.SafeDCHandle.Null, 1, 0, (int)ThemeProperty.TMT_SIZINGMARGINS, null, out var result).Succeeded);
			Assert.That(result.cyBottomHeight, Is.GreaterThan(0));
		}

		[Test]
		public void GetThemeMetricTest()
		{
			Assert.That(GetThemeMetric(hbt, Gdi32.SafeDCHandle.Null, 1, 2, (int)ThemeProperty.TMT_IMAGECOUNT, out var result).Succeeded);
			Assert.That(result, Is.EqualTo(6));
		}

		[Test]
		public void GetThemePartSizeTest()
		{
			Assert.That(GetThemePartSize(hbt, Gdi32.SafeDCHandle.Null, 1, 2, null, THEMESIZE.TS_MIN, out var result).Succeeded);
			Assert.That(result.cx, Is.EqualTo(6));
		}

		[Test]
		public void GetThemePositionTest()
		{
			Assert.That(GetThemePosition(hbt, 1, 2, (int)ThemeProperty.TMT_MINSIZE, out var result).Succeeded);
			Assert.That(result.X, Is.EqualTo(10));
		}

		[Test]
		public void GetThemePropertyOriginTest()
		{
			Assert.That(GetThemePropertyOrigin(hbt, 1, 2, (int)ThemeProperty.TMT_MINSIZE, out var result).Succeeded);
			Assert.That(result, Is.EqualTo(PROPERTYORIGIN.PO_PART));
		}

		[Test]
		public void GetThemeRectTest()
		{
			Application.EnableVisualStyles();
			using (var h = OpenThemeData(new HandleRef(), "DWMWINDOW"))
			{
				Assert.That(h.IsInvalid, Is.False);
				var hr = GetThemeRect(h, 3, 1, (int)ThemeProperty.TMT_ATLASRECT, out var result);
				if (hr.Failed) TestContext.WriteLine(hr);
				Assert.That(hr.Succeeded);
				Assert.That(result.Width, Is.GreaterThan(0));
			}
		}

		[Test]
		public void GetThemeStreamTest()
		{
			Application.EnableVisualStyles();
			using (var h = OpenThemeData(new HandleRef(), "DWMWINDOW"))
			{
				Assert.That(h.IsInvalid, Is.False);
				using (var hInstance = Kernel32.LoadLibraryEx(@"C:\Windows\resources\themes\Aero\Aero.msstyles", dwFlags: Kernel32.LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
				{
					var hr = UxTheme.GetThemeStream(h, 0, 0, 213, out var themeStream, out var streamSize, hInstance);
					Assert.That(hr.Succeeded);
					Assert.That(streamSize, Is.GreaterThan(0));
					Assert.That(() => themeStream.ToArray<byte>((int)streamSize), Throws.Nothing);
				}
			}
		}

		[Test]
		public void GetThemeStringTest()
		{
			var sb = new StringBuilder(bufSz, bufSz);
			var hr = GetThemeString(hbt, 1, 0, (int)ThemeProperty.TMT_CSSNAME, sb, sb.Capacity);
			// Can't test this as there are no properties that return a value.
			Assert.That(hr.Failed);
			//TestContext.WriteLine(sb.ToString());
			//Assert.That(sb.ToString(), Has.Length.GreaterThan(0));
		}

		[Test]
		public void GetThemeSysBoolTest()
		{
			Assert.That(GetThemeSysBool(hwt, (int)ThemeProperty.TMT_FLATMENUS), Is.True);
		}

		[Test]
		public void GetThemeSysColorTest()
		{
			Assert.That(GetThemeSysColor(hwt, User32_Gdi.SystemColorIndex.COLOR_WINDOW), Is.EqualTo(new COLORREF(255, 255, 255)));
		}

		[Test]
		public void GetThemeSysColorBrushTest()
		{
			var hbr = GetThemeSysColorBrush(hwt, (int)User32_Gdi.SystemColorIndex.COLOR_WINDOW);
			Assert.That(hbr, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(Gdi32.DeleteObject(hbr));
		}

		[Test]
		public void GetThemeSysFontTest()
		{
			Assert.That(GetThemeSysFont(hwt, (int)ThemeProperty.TMT_CAPTIONFONT, out var lf).Succeeded);
			Assert.That(lf.lfHeight, Is.Not.Zero);
		}

		[Test]
		public void GetThemeSysIntTest()
		{
			Assert.That(GetThemeSysInt(hwt, (int)ThemeProperty.TMT_MINCOLORDEPTH, out var i).Succeeded);
			Assert.That(i, Is.Not.Zero);
		}

		[Test]
		public void GetThemeSysSizeTest()
		{
			Assert.That(GetThemeSysSize(hwt, (int)User32.SystemMetric.SM_CYSIZE), Is.Not.Zero);
		}

		[Test]
		public void GetThemeSysStringTest()
		{
			var sb = new StringBuilder(bufSz, bufSz);
			var hr = GetThemeSysString(hbt, (int)ThemeProperty.TMT_CSSNAME, sb, sb.Capacity);
			Assert.That(hr.Succeeded);
			TestContext.WriteLine(sb.ToString());
			Assert.That(sb, Has.Length.GreaterThan(0));
		}

		[Test]
		public void GetThemeTextExtentTest()
		{
			const string text = "ButtonText";
			var hr = GetThemeTextExtent(hbt, Gdi32.SafeDCHandle.ScreenCompatibleDCHandle, 1, 0, text, -1, DrawTextFlags.DT_SINGLELINE, null, out var ext);
			Assert.That(hr.Succeeded);
			Assert.That(ext.IsEmpty, Is.False);
		}

		[Test]
		public void GetThemeTextMetricsTest()
		{
			var hr = GetThemeTextMetrics(hbt, Gdi32.SafeDCHandle.ScreenCompatibleDCHandle, 1, 0, out var m);
			Assert.That(hr.Succeeded);
			Assert.That(m, Is.Not.Zero);
		}

		[Test]
		public void GetThemeTimingFunctionTest()
		{
			var buf = new SafeCoTaskMemHandle(100);
			var hr = GetThemeTimingFunction(hbt, 1, (IntPtr)buf, (uint)buf.Size, out var sz);
			// Can't test this as there are no properties that return a value.
			Assert.That(hr.Failed);
		}

		[Test]
		public void GetThemeTransitionDurationTest()
		{
			var hr = GetThemeTransitionDuration(hbt, 6, 2, 1, (int)ThemeProperty.TMT_TRANSITIONDURATIONS, out var u);
			Assert.That(hr.Succeeded);
			Assert.That(u, Is.Not.Zero);
		}

		[Test]
		public void GetSetWindowThemeTest()
		{
			var w = new NativeWindow();
			try
			{
				w.CreateHandle(new CreateParams { ClassName = "BUTTON", Style = 0x10000000 });
				var hr = SetWindowTheme(new HandleRef(w, w.Handle), "Start", null);
				Assert.That(hr.Succeeded);
				var htheme = GetWindowTheme(new HandleRef(w, w.Handle));
				Assert.That(htheme, Is.Not.EqualTo(IntPtr.Zero));
			}
			finally
			{
				w.DestroyHandle();
			}
		}

		[Test]
		public void HitTestThemeBackgroundTest()
		{
			var f = new Form() { Size = new Size(300, 300) };
			f.Shown += (s, e) =>
			{
				using (var htheme = OpenThemeData(new HandleRef(f, f.Handle), "Window"))
				{
					Assert.That(htheme, Is.Not.EqualTo(IntPtr.Zero));
					RECT r = f.ClientRectangle;
					var hr = HitTestThemeBackground(htheme, new Gdi32.SafeDCHandle(f.CreateGraphics()), 1, 1, HitTestOptions.HTTB_CAPTION, ref r, IntPtr.Zero, new Point(1, 1), out var code);
					Assert.That(hr.Succeeded);
				}
				f.Close();
			};
			f.ShowDialog();
		}

		[Test]
		public void IsAppThemedTest()
		{
			Assert.That(IsAppThemed());
		}

		[Test]
		public void IsCompositionActiveTest()
		{
			Assert.That(IsCompositionActive());
		}

		[Test]
		public void IsThemeActiveTest()
		{
			Assert.That(IsThemeActive());
		}

		[Test]
		public void IsThemeBackgroundPartiallyTransparentTest()
		{
			Assert.That(IsThemeBackgroundPartiallyTransparent(hbt, 6, 1), Is.True);
			Assert.That(IsThemeBackgroundPartiallyTransparent(hbt, 5, 0), Is.False);
		}

		[Test]
		public void IsThemeDialogTextureEnabledTest()
		{
			var f = new Form() { Size = new Size(300, 300) };
			f.Shown += (s, e) =>
			{
				using (var htheme = OpenThemeData(new HandleRef(f, f.Handle), "Window"))
				{
					Assert.That(htheme, Is.Not.EqualTo(IntPtr.Zero));
					Assert.That(IsThemeDialogTextureEnabled(new HandleRef(f, f.Handle)), Is.False);
				}
				f.Close();
			};
			f.ShowDialog();
		}

		[Test]
		public void IsThemePartDefinedTest()
		{
			Assert.That(IsThemePartDefined(hbt, 6, 1), Is.True);
			Assert.That(IsThemePartDefined(hbt, 10, 1), Is.False);
		}

		[Test]
		public void SetThemeAppPropertiesTest()
		{
			Assert.That(() => SetThemeAppProperties(ThemeAppProperties.STAP_ALLOW_NONCLIENT | ThemeAppProperties.STAP_ALLOW_CONTROLS), Throws.Nothing);
		}

		[Test]
		public void SetWindowThemeNonClientAttributesTest()
		{
			var f = new Form() { Size = new Size(300, 300) };
			f.Shown += (s, e) =>
			{
				Assert.That(() => SetWindowThemeNonClientAttributes(new HandleRef(f, f.Handle), WTNCA.WTNCA_NOSYSMENU), Throws.Nothing);
				f.Close();
			};
			f.ShowDialog();
		}
	}
}