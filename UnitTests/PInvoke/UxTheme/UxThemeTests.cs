using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.Extensions;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class UxThemeTests
	{
		[Test()]
		public void CloseThemeDataTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DrawThemeBackgroundTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DrawThemeBackgroundExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DrawThemeIconTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DrawThemeParentBackgroundTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DrawThemeParentBackgroundExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DrawThemeTextTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DrawThemeTextExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeBackgroundContentRectTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeBitmapTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeBoolTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeColorTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeEnumValueTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeFilenameTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeIntTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeIntListTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeMarginsTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeMetricTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemePartSizeTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemePositionTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemePropertyOriginTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeRectTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeStreamTest()
		{
			const int WP_MINCAPTION = 3;
			const int MNCS_ACTIVE = 1;
			const int TMT_ATLASRECT = 8002;

			Application.EnableVisualStyles();
			var w = new NativeWindow();
			var cp = new CreateParams();
			w.CreateHandle(cp);

			using (var h = UxTheme.OpenThemeData(new HandleRef(w, w.Handle), "DWMWINDOW"))
			{
				if (!h.IsInvalid)
				{
					UxTheme.GetThemeRect(h, WP_MINCAPTION, MNCS_ACTIVE, TMT_ATLASRECT, out var rect);
					using (var hInstance = Kernel32.LoadLibraryEx(@"C:\Windows\resources\themes\Aero\Aero.msstyles", dwFlags: Kernel32.LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
					{
						var hr = UxTheme.GetThemeStream(h, WP_MINCAPTION, MNCS_ACTIVE, TMT_ATLASRECT, out var themeStream, out var streamSize, hInstance);
						byte[] bytes = hr.Succeeded ? themeStream.ToArray<byte>((int)streamSize) : new byte[0];
					}
				}
			}

			w.DestroyHandle();
		}

		[Test()]
		public void GetThemeStringTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeSysIntTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeTextExtentTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeTransitionDurationTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void IsThemeBackgroundPartiallyTransparentTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void IsThemePartDefinedTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void OpenThemeDataTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void OpenThemeDataExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowThemeTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowThemeAttributeTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowThemeAttributeTest1()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void BeginBufferedAnimationTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void BeginBufferedPaintTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void BufferedPaintInitTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void BufferedPaintRenderAnimationTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void BufferedPaintStopAllAnimationsTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void BufferedPaintUnInitTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void EndBufferedAnimationTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void EndBufferedPaintTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeFontTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetThemeSysFontTest()
		{
			throw new NotImplementedException();
		}
	}
}