using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke
{
	public static partial class UxTheme
	{
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern int GetThemeFont(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, int iPropId, out LOGFONT pFont);

		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern int GetThemeSysFont(SafeThemeHandle hTheme, int iFontId, out LOGFONT pFont);
	}
}