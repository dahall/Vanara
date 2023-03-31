using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Specifies the use of a color. Used by IVisualProperties methods.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/ne-shobjidl-vpcolorflags typedef enum VPCOLORFLAGS { VPCF_TEXT,
	// VPCF_BACKGROUND, VPCF_SORTCOLUMN, VPCF_SUBTEXT, VPCF_TEXTBACKGROUND } ;
	[PInvokeData("shobjidl.h", MSDNShortId = "NE:shobjidl.VPCOLORFLAGS")]
	public enum VPCOLORFLAGS
	{
		/// <summary>A text color.</summary>
		VPCF_TEXT = 1,

		/// <summary>A background color.</summary>
		VPCF_BACKGROUND,

		/// <summary>A sort-column color.</summary>
		VPCF_SORTCOLUMN,

		/// <summary>A subtext color.</summary>
		VPCF_SUBTEXT,

		/// <summary>Windows 7 and later. A text background color.</summary>
		VPCF_TEXTBACKGROUND,
	}

	/// <summary>Specifies watermark flags. Used by IVisualProperties::SetWatermark.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/ne-shobjidl-vpwatermarkflags typedef enum VPWATERMARKFLAGS {
	// VPWF_DEFAULT, VPWF_ALPHABLEND } ;
	[PInvokeData("shobjidl.h", MSDNShortId = "NE:shobjidl.VPWATERMARKFLAGS")]
	[Flags]
	public enum VPWATERMARKFLAGS
	{
		/// <summary>Default Windows XP behavior.</summary>
		VPWF_DEFAULT = 0,

		/// <summary>Alpha blend the respective bitmap; assumed 24-bit color + 8-bit alpha.</summary>
		VPWF_ALPHABLEND = 1,
	}

	/// <summary>Exposes methods that set and get visual properties.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-ivisualproperties
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IVisualProperties")]
	[ComImport, Guid("e693cf68-d967-4112-8763-99172aee5e5a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVisualProperties
	{
		/// <summary>Provides a bitmap to use as a watermark.</summary>
		/// <param name="hbmp">
		/// <para>Type: <c>HBITMAP</c></para>
		/// <para>A handle to the bitmap.</para>
		/// </param>
		/// <param name="vpwf">
		/// <para>Type: <c>VPWATERMARKFLAGS</c></para>
		/// <para>VPWATERMARKFLAGS flags that customize the watermark.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ivisualproperties-setwatermark HRESULT SetWatermark(
		// HBITMAP hbmp, VPWATERMARKFLAGS vpwf );
		void SetWatermark(HBITMAP hbmp, VPWATERMARKFLAGS vpwf);

		/// <summary>Sets the color, as specified.</summary>
		/// <param name="vpcf">
		/// <para>Type: <c>VPCOLORFLAGS</c></para>
		/// <para>The color flags. See VPCOLORFLAGS.</para>
		/// </param>
		/// <param name="cr">
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>A value of type COLORREF</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ivisualproperties-setcolor HRESULT SetColor(
		// VPCOLORFLAGS vpcf, COLORREF cr );
		void SetColor(VPCOLORFLAGS vpcf, COLORREF cr);

		/// <summary>Gets the color, as specified.</summary>
		/// <param name="vpcf">
		/// <para>Type: <c>VPCOLORFLAGS</c></para>
		/// <para>The color flags. See VPCOLORFLAGS</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>COLORREF*</c></para>
		/// <para>A pointer to a value of type COLORREF.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ivisualproperties-getcolor HRESULT GetColor(
		// VPCOLORFLAGS vpcf, COLORREF *pcr );
		COLORREF GetColor(VPCOLORFLAGS vpcf);

		/// <summary>Sets the specified item height.</summary>
		/// <param name="cyItemInPixels">
		/// <para>Type: <c>int</c></para>
		/// <para>The item height, in pixels.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ivisualproperties-setitemheight HRESULT
		// SetItemHeight( int cyItemInPixels );
		void SetItemHeight(int cyItemInPixels);

		/// <summary>Gets the item height.</summary>
		/// <returns>
		/// <para>Type: <c>int*</c></para>
		/// <para>A pointer to the item height, in pixels.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ivisualproperties-getitemheight HRESULT
		// GetItemHeight( int *cyItemInPixels );
		int GetItemHeight();

		/// <summary>Sets attributes of the font.</summary>
		/// <param name="plf">
		/// <para>Type: <c>const LOGFONTW*</c></para>
		/// <para>A pointer to a LOGFONT structure that contains the attributes to set.</para>
		/// </param>
		/// <param name="bRedraw">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the item should be redrawn after the new attributes are set; otherwise <c>FALSE</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ivisualproperties-setfont HRESULT SetFont( const
		// LOGFONTW *plf, BOOL bRedraw );
		void SetFont(in LOGFONT plf, [MarshalAs(UnmanagedType.Bool)] bool bRedraw);

		/// <summary>Gets the current attributes set on the font.</summary>
		/// <returns>
		/// <para>Type: <c>LOGFONTW*</c></para>
		/// <para>
		/// A pointer to a LOGFONT structure that, when this method returns successfully, receives the current attributes of the font.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ivisualproperties-getfont HRESULT GetFont( LOGFONTW
		// *plf );
		LOGFONT GetFont();

		/// <summary>Sets the specified theme.</summary>
		/// <param name="pszSubAppName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a Unicode string that contains the application name to use in place of the calling application's name. If this
		/// parameter is <c>NULL</c>, the calling application's name is used.
		/// </para>
		/// </param>
		/// <param name="pszSubIdList">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a Unicode string that contains a semicolon-separated list of CLSID names for use in place of the actual list
		/// passed by the window's class. If this parameter is <c>NULL</c>, the ID list from the calling class is used.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ivisualproperties-settheme HRESULT SetTheme( LPCWSTR
		// pszSubAppName, LPCWSTR pszSubIdList );
		void SetTheme([MarshalAs(UnmanagedType.LPWStr)] string pszSubAppName, [MarshalAs(UnmanagedType.LPWStr)] string pszSubIdList);
	}
}