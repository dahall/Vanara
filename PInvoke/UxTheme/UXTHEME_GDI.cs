using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke
{
	public static partial class UxTheme
	{
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT GetThemeFont(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, int iPropId, out LOGFONT pFont);

		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT GetThemeSysFont(SafeThemeHandle hTheme, int iFontId, out LOGFONT pFont);
	}
}