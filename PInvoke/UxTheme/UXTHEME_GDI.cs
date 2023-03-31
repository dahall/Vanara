using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class UxTheme
{
	/// <summary>Retrieves the value of a font property.</summary>
	/// <param name="hTheme">Handle to a window's specified theme data. Use OpenThemeData to create an HTHEME.</param>
	/// <param name="hdc">HDC. This parameter may be set to NULL.</param>
	/// <param name="iPartId">Value of type int that specifies the part that contains the font property. See Parts and States.</param>
	/// <param name="iStateId">Value of type int that specifies the state of the part. See Parts and States.</param>
	/// <param name="iPropId">
	/// Value of type int that specifies the property to retrieve. For a list of possible values, see Property Identifiers.
	/// </param>
	/// <param name="pFont">Pointer to a LOGFONT structure that receives the font property value.</param>
	/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb759745(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("uxtheme.h", MSDNShortId = "bb759745")]
	public static extern HRESULT GetThemeFont(SafeHTHEME hTheme, HDC hdc, int iPartId, int iStateId, int iPropId, out LOGFONT pFont);

	/// <summary>Retrieves the LOGFONT of a system font.</summary>
	/// <param name="hTheme">Handle to theme data.</param>
	/// <param name="iFontId">Value of type int that specifies a system font.</param>
	/// <param name="pFont">Pointer to a LOGFONT structure that receives the font information from this function.</param>
	/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb759783(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("uxtheme.h", MSDNShortId = "bb759783")]
	public static extern HRESULT GetThemeSysFont(SafeHTHEME hTheme, int iFontId, out LOGFONT pFont);
}