using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.UxTheme;

namespace Vanara.Windows.Forms
{
	public class VisualTheme : IDisposable
	{
		private readonly SafeThemeHandle hTheme;

		public VisualTheme(string classList) : this(null, classList) { }

		public VisualTheme(IntPtr handle)
		{
			hTheme = new SafeThemeHandle(handle, false);
		}

		public VisualTheme(IWin32Window window, string classList, OpenThemeDataOptions opt = OpenThemeDataOptions.None)
		{
			var ptr = OpenThemeDataEx(new HandleRef(window, window?.Handle ?? IntPtr.Zero), classList, opt);
			hTheme = new SafeThemeHandle(ptr);
			if (hTheme.IsInvalid)
				throw new Win32Exception();
		}

		public void Dispose() { hTheme?.Dispose(); }

		public void DrawBackground(IDeviceContext graphics, int partId, int stateId, Rectangle bounds, Rectangle clipRect)
		{
			var b = new RECT(bounds);
			var o = new DrawThemeBackgroundOptions(clipRect); // {OmitBorder = true, OmitContent = true};
			using (var hdc = new SafeDCHandle(graphics))
				DrawThemeBackgroundEx(hTheme, hdc, partId, stateId, ref b, o);
		}

		public void DrawParentBackground(IWin32Window childWindow, IDeviceContext graphics, Rectangle? bounds = null)
		{
			using (var hdc = new SafeDCHandle(graphics))
				DrawThemeParentBackground(new HandleRef(childWindow, childWindow.Handle), hdc, bounds);
		}

		public void DrawText(IDeviceContext graphics, int partId, int stateId, Rectangle bounds, string text, TextFormatFlags fmt = TextFormatFlags.Default, DrawThemeTextOptions? options = null, Font font = null)
		{
			var b = new RECT(bounds);
			var dt = options ?? DrawThemeTextOptions.Default; //new DrawThemeTextOptions(true) {AntiAliasedAlpha = true, BorderSize = 10, BorderColor = Color.Red, ApplyOverlay = true, ShadowType = TextShadowType.Continuous, ShadowColor = Color.White, ShadowOffset = new Point(2, 2), GlowSize = 18, TextColor = Color.White, Callback = DrawTextCallback };
			using (var hdc = new SafeDCHandle(graphics))
				using (new SafeDCObjectHandle(hdc, font?.ToHfont() ?? IntPtr.Zero))
					DrawThemeTextEx(hTheme, hdc, partId, stateId, text, text.Length, (DrawTextFlags)fmt, ref b, ref dt);
		}

		public Rectangle? GetBackgroundContentRect(IDeviceContext graphics, int partId, int stateId, Rectangle bounds)
		{
			RECT b = new RECT(bounds);
			using (var hdc = new SafeDCHandle(graphics))
			{
				RECT rc;
				if (0 == GetThemeBackgroundContentRect(hTheme, hdc, partId, stateId, ref b, out rc)) return rc;
			}
			return null;
		}

		public Bitmap GetBitmap(IDeviceContext graphics, int partId, int stateId, int propId)
		{
			using (var hdc = new SafeDCHandle(graphics))
			{
				IntPtr hBmp;
				if (0 == GetThemeBitmap(hTheme, hdc, partId, stateId, propId, 0, out hBmp)) return Image.FromHbitmap(hBmp);
			}
			return null;
		}

		public bool? GetBool(int partId, int stateId, int propId)
		{
			bool b;
			if (0 == GetThemeBool(hTheme, partId, stateId, propId, out b)) return b;
			return null;
		}

		public Color? GetColor(int partId, int stateId, int propId)
		{
			int cr;
			if (0 == GetThemeColor(hTheme, partId, stateId, propId, out cr)) return ColorTranslator.FromWin32(cr);
			return null;
		}

		public int? GetEnumValue(int partId, int stateId, int propId)
		{
			int i;
			if (0 == GetThemeEnumValue(hTheme, partId, stateId, propId, out i)) return i;
			return null;
		}

		public string GetFilename(int partId, int stateId, int propId)
		{
			const int sbLen = 1024;
			var sb = new StringBuilder(sbLen);
			if (0 == GetThemeFilename(hTheme, partId, stateId, propId, ref sb, sbLen)) return sb.ToString();
			return null;
		}

		public Font GetFont(IDeviceContext graphics, int partId, int stateId, int propId)
		{
			using (var hdc = new SafeDCHandle(graphics))
			{
				LOGFONT f;
				if (0 == GetThemeFont(hTheme, hdc, partId, stateId, propId, out f)) return f.ToFont();
			}
			return null;
		}

		public int? GetInt(int partId, int stateId, int propId)
		{
			int i;
			if (0 == GetThemeInt(hTheme, partId, stateId, propId, out i)) return i;
			return null;
		}

		public int? GetSysInt(int propId)
		{
			int i;
			if (0 == GetThemeSysInt(hTheme, propId, out i)) return i;
			return null;
		}

		public int[] GetIntList(int partId, int stateId, int propId) => GetThemeIntList(hTheme, partId, stateId, propId);

		public Padding? GetMargins(IDeviceContext graphics, int partId, int stateId, int propId)
		{
			using (var hdc = new SafeDCHandle(graphics))
			{
				RECT rc;
				if (0 == GetThemeMargins(hTheme, hdc, partId, stateId, propId, IntPtr.Zero, out rc))
					return new Padding(rc.left, rc.top, rc.right, rc.bottom);
			}
			return null;
		}

		public int? GetMetric(IDeviceContext graphics, int partId, int stateId, int propId)
		{
			using (var hdc = new SafeDCHandle(graphics))
			{
				int i;
				if (0 == GetThemeMetric(hTheme, hdc, partId, stateId, propId, out i)) return i;
			}
			return null;
		}

		private enum PropertyType
		{
			Enum = 200,
			String = 201,
			Int = 202,
			SysInt = 198,
			Metric = 199,
			Bool = 203,
			Color = 204,
			Margins = 205,
			FileName = 206,
			Size = 207,
			Position = 208,
			Rect = 209,
			Font = 210,
			IntList = 211,
			HBitmap = 212,
			DiskStream = 213,
			Stream = 214
		}

		private static PropertyType LookupGetType(int propId)
		{
			if ((propId >= 4001 && propId <= 4015))
				return PropertyType.Enum;
			if ((propId >= 401 && propId <= 402) || (propId >= 600 && propId <= 608) || (propId >= 1401 && propId <= 1404) ||
			    (propId >= 3201 && propId <= 3202) || propId == 8001)
				return PropertyType.String;
			if (propId == 403 || (propId >= 1201 && propId <= 1210) || (propId >= 1801 && propId <= 1810) || propId == 5006)
				return PropertyType.Int;
			if (propId >= 2401 && propId <= 2434 && propId != 2431)
				return PropertyType.Metric;
			if (propId == 1301)
				return PropertyType.SysInt;
			if (propId == 1001 || (propId >= 2201 && propId <= 2220) || propId == 5001 || propId == 7001)
				return PropertyType.Bool;
			if ((propId >= 1601 && propId <= 1631) || (propId >= 2001 && propId <= 2010) || propId == 2431 ||
			    (propId >= 3801 && propId <= 3827) || propId == 5003)
				return PropertyType.Color;
			if ((propId >= 3601 && propId <= 3603))
				return PropertyType.Margins;
			if ((propId >= 3001 && propId <= 3010))
				return PropertyType.FileName;
			if ((propId >= 0 && propId <= 2))
				return PropertyType.Size;
			if ((propId >= 3401 && propId <= 3411))
				return PropertyType.Position;
			if (propId == 5002 || propId == 5004 || propId == 5005 || propId == 8002)
				return PropertyType.Rect;
			if ((propId >= 801 && propId <= 809) || propId == 2601)
				return PropertyType.Font;
			if (propId == 6000)
				return PropertyType.IntList;
			if ( /*propId == 2 ||*/ propId == 8)
				return PropertyType.HBitmap;
			if (propId == 8000 || propId == (int)PropertyType.DiskStream)
				return PropertyType.DiskStream;
			if (propId == (int)PropertyType.Stream)
				return PropertyType.Stream;
			throw new ArgumentOutOfRangeException(nameof(propId), $"Unmapped theme property: {propId}");
		}

		public object GetObject(IDeviceContext graphics, int partId, int stateId, int propId)
		{
			object o = null;
			var t = LookupGetType(propId);
			try
			{
				switch (t)
				{
					case PropertyType.Enum:
						o = GetEnumValue(partId, stateId, propId);
						break;
					case PropertyType.String:
						o = GetString(partId, stateId, propId);
						break;
					case PropertyType.Int:
						o = GetInt(partId, stateId, propId);
						break;
					case PropertyType.Metric:
						o = GetMetric(graphics, partId, stateId, propId);
						break;
					case PropertyType.SysInt:
						o = GetSysInt(propId);
						break;
					case PropertyType.Bool:
						o = GetBool(partId, stateId, propId);
						break;
					case PropertyType.Color:
						o = GetColor(partId, stateId, propId);
						break;
					case PropertyType.Margins:
						o = GetMargins(graphics, partId, stateId, propId);
						break;
					case PropertyType.FileName:
						o = GetFilename(partId, stateId, propId);
						break;
					case PropertyType.Size:
						o = GetPartSize(graphics, partId, stateId, null, (ThemeSize)propId);
						break;
					case PropertyType.Position:
						o = GetPosition(partId, stateId, propId);
						break;
					case PropertyType.Rect:
						o = GetRect(partId, stateId, propId);
						break;
					case PropertyType.Font:
						o = GetFont(graphics, partId, stateId, propId);
						break;
					case PropertyType.IntList:
						o = GetIntList(partId, stateId, propId);
						break;
					case PropertyType.HBitmap:
						o = GetBitmap(graphics, partId, stateId, propId);
						break;
					case PropertyType.Stream:
						o = GetStream(partId, stateId, propId);
						break;
				}
			}
			catch (Exception ex)
			{
				o = ex;
				System.Diagnostics.Debug.WriteLine($"Failed to get {t} for {partId}:{stateId}:{propId}.");
			}
			return o;
		}

		public Size? GetPartSize(IDeviceContext graphics, int partId, int stateId, Rectangle? destRect, ThemeSize themeSize)
		{
			using (var hdc = new SafeDCHandle(graphics))
			{
				Size sz;
				if (0 != GetThemePartSize(hTheme, hdc, partId, stateId, destRect, themeSize, out sz))
					return null;
				return sz;
			}
		}

		public Point? GetPosition(int partId, int stateId, int propId)
		{
			Point i;
			if (0 == GetThemePosition(hTheme, partId, stateId, propId, out i)) return i;
			return null;
		}

		public int GetPropertyOrigin(int partId, int stateId, int propId)
		{
			ThemePropertyOrigin po;
			GetThemePropertyOrigin(hTheme, partId, stateId, propId, out po);
			return (int)po;
		}

		public Rectangle? GetRect(int partId, int stateId, int propId)
		{
			RECT rc;
			if (0 == GetThemeRect(hTheme, partId, stateId, propId, out rc)) return rc;
			return null;
		}

		public byte[] GetDiskStream(SafeLibraryHandle hInst, int partId, int stateId, int propId)
		{
			byte[] bytes;
			int bLen;
			var r = GetThemeStream(hTheme, partId, stateId, propId, out bytes, out bLen, hInst);
			if (r == 0) return bytes;
			if ((uint)r != 0x80070490) throw new InvalidOperationException("Bad GetThemeStream");
			return null;
		}

		public byte[] GetStream(int partId, int stateId, int propId)
		{
			byte[] bytes;
			int bLen;
			var r = GetThemeStream(hTheme, partId, stateId, propId, out bytes, out bLen, IntPtr.Zero);
			if (r == 0) return bytes;
			if ((uint)r != 0x80070490) throw new InvalidOperationException("Bad GetThemeStream");
			return null;
		}

		public string GetString(int partId, int stateId, int propId)
		{
			const int sbLen = 1024;
			var sb = new StringBuilder(sbLen);
			if (0 == GetThemeString(hTheme, partId, stateId, propId, ref sb, sbLen))
				return sb.ToString();
			return null;
		}

		public int GetTransitionDuration(int partId, int fromStateId, int toStateId, int propId)
		{
			int dur;
			GetThemeTransitionDuration(hTheme, partId, fromStateId, toStateId, propId, out dur);
			return dur;
		}

		public bool IsBackgroundPartiallyTransparent(int partId, int stateId) => IsThemeBackgroundPartiallyTransparent(hTheme, partId, stateId);

		public bool IsDefined(int partId, int stateId) => IsThemePartDefined(hTheme, partId, stateId);
	}
}