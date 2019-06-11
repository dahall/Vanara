using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>Specifies how the output image should be prepared.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "9a080f60-0bce-46b6-b8a8-f534ff83a0a8")]
		public enum CA_FLAGS : ushort
		{
			/// <summary>Specifies that the negative of the original image should be displayed.</summary>
			CA_NEGATIVE = 0x0001,

			/// <summary>
			/// Specifies that a logarithmic function should be applied to the final density of the output colors. This will increase the
			/// color contrast when the luminance is low.
			/// </summary>
			CA_LOG_FILTER = 0x0002,
		}

		/// <summary>The type of standard light source under which the image is viewed.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "9a080f60-0bce-46b6-b8a8-f534ff83a0a8")]
		public enum ILLUMINANT : ushort
		{
			/// <summary>Device's default. Standard used by output devices.</summary>
			ILLUMINANT_DEVICE_DEFAULT = 0,

			/// <summary>Tungsten lamp.</summary>
			ILLUMINANT_A = 1,

			/// <summary>Noon sunlight.</summary>
			ILLUMINANT_B = 2,

			/// <summary>NTSC daylight.</summary>
			ILLUMINANT_C = 3,

			/// <summary>Normal print.</summary>
			ILLUMINANT_D50 = 4,

			/// <summary>Bond paper print.</summary>
			ILLUMINANT_D55 = 5,

			/// <summary>Standard daylight. Standard for CRTs and pictures.</summary>
			ILLUMINANT_D65 = 6,

			/// <summary>Northern daylight.</summary>
			ILLUMINANT_D75 = 7,

			/// <summary>Cool white lamp.</summary>
			ILLUMINANT_F2 = 8,

			/// <summary>Same as ILLUMINANT_A.</summary>
			ILLUMINANT_TUNGSTEN = ILLUMINANT_A,

			/// <summary>Same as ILLUMINANT_C.</summary>
			ILLUMINANT_DAYLIGHT = ILLUMINANT_C,

			/// <summary>Same as ILLUMINANT_F2.</summary>
			ILLUMINANT_FLUORESCENT = ILLUMINANT_F2,

			/// <summary>Same as ILLUMINANT_C.</summary>
			ILLUMINANT_NTSC = ILLUMINANT_C,
		}

		/// <summary>The alpha intensity value for the palette entry.</summary>
		[PInvokeData("wingdi.h")]
		public enum PC : byte
		{
			/// <summary>
			/// Specifies that the low-order word of the logical palette entry designates a hardware palette index. This flag allows the
			/// application to show the contents of the display device palette.
			/// </summary>
			PC_EXPLICIT = 0x2,

			/// <summary>
			/// Specifies that the color be placed in an unused entry in the system palette instead of being matched to an existing color in
			/// the system palette. If there are no unused entries in the system palette, the color is matched normally. Once this color is
			/// in the system palette, colors in other logical palettes can be matched to this color.
			/// </summary>
			PC_NOCOLLAPSE = 0x4,

			/// <summary>
			/// Specifies that the logical palette entry be used for palette animation. This flag prevents other windows from matching colors
			/// to the palette entry since the color frequently changes. If an unused system-palette entry is available, the color is placed
			/// in that entry. Otherwise, the color is not available for animation.
			/// </summary>
			PC_RESERVED = 0x1,
		}

		/// <summary>The current state of the system (physical) palette.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "0a9e7906-2f81-4fda-b03d-86feb0755327")]
		public enum SYSPAL
		{
			/// <summary>The given device context is invalid or does not support a color palette.</summary>
			SYSPAL_ERROR = 0,

			/// <summary>The system palette contains static colors that will not change when an application realizes its logical palette.</summary>
			SYSPAL_STATIC = 1,

			/// <summary>The system palette contains no static colors except black and white.</summary>
			SYSPAL_NOSTATIC = 2,

			/// <summary>The system palette contains no static colors.</summary>
			SYSPAL_NOSTATIC256 = 3,
		}

		/// <summary>The <c>AnimatePalette</c> function replaces entries in the specified logical palette.</summary>
		/// <param name="hPal">A handle to the logical palette.</param>
		/// <param name="iStartIndex">The first logical palette entry to be replaced.</param>
		/// <param name="cEntries">The number of entries to be replaced.</param>
		/// <param name="ppe">A pointer to the first member in an array of PALETTEENTRY structures used to replace the current entries.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </para>
		/// <para>
		/// The <c>AnimatePalette</c> function only changes entries with the PC_RESERVED flag set in the corresponding <c>palPalEntry</c>
		/// member of the LOGPALETTE structure.
		/// </para>
		/// <para>If the given palette is associated with the active window, the colors in the palette are replaced immediately.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-animatepalette BOOL AnimatePalette( HPALETTE hPal, UINT
		// iStartIndex, UINT cEntries, const PALETTEENTRY *ppe );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "65dd45e2-39a4-4a94-bd14-b0c8e4a609a3")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AnimatePalette(HPALETTE hPal, uint iStartIndex, uint cEntries, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] PALETTEENTRY[] ppe);

		/// <summary>The <c>CreateHalftonePalette</c> function creates a halftone palette for the specified device context (DC).</summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to a logical halftone palette.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application should create a halftone palette when the stretching mode of a device context is set to HALFTONE. The logical
		/// halftone palette returned by <c>CreateHalftonePalette</c> should then be selected and realized into the device context before the
		/// StretchBlt or StretchDIBits function is called.
		/// </para>
		/// <para>When you no longer need the palette, call the DeleteObject function to delete it.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createhalftonepalette HPALETTE CreateHalftonePalette( HDC
		// hdc );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "ba9dfa0c-98df-4922-acba-d00e9b4b0fb0")]
		public static extern SafeHPALETTE CreateHalftonePalette(HDC hdc);

		/// <summary>The <c>CreatePalette</c> function creates a logical palette.</summary>
		/// <param name="plpal">A pointer to a LOGPALETTE structure that contains information about the colors in the logical palette.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to a logical palette.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </para>
		/// <para>
		/// Once an application creates a logical palette, it can select that palette into a device context by calling the SelectPalette
		/// function. A palette selected into a device context can be realized by calling the RealizePalette function.
		/// </para>
		/// <para>When you no longer need the palette, call the DeleteObject function to delete it.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createpalette HPALETTE CreatePalette( const LOGPALETTE
		// *plpal );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "f3462198-9360-4b77-ac62-9fe21ec666be")]
		public static extern SafeHPALETTE CreatePalette([In] LOGPALETTE plpal);

		/// <summary>The <c>GetColorAdjustment</c> function retrieves the color adjustment values for the specified device context (DC).</summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="lpca">A pointer to a COLORADJUSTMENT structure that receives the color adjustment values.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getcoloradjustment BOOL GetColorAdjustment( HDC hdc,
		// LPCOLORADJUSTMENT lpca );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "405c0d0d-9433-4f4a-9957-5c42a0fb3a07")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetColorAdjustment(HDC hdc, ref COLORADJUSTMENT lpca);

		/// <summary>
		/// The <c>GetNearestColor</c> function retrieves a color value identifying a color from the system palette that will be displayed
		/// when the specified color value is used.
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="color">A color value that identifies a requested color. To create a COLORREF color value, use the RGB macro.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value identifies a color from the system palette that corresponds to the given color value.
		/// </para>
		/// <para>If the function fails, the return value is CLR_INVALID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getnearestcolor COLORREF GetNearestColor( HDC hdc, COLORREF
		// color );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "89e4e19b-47be-442e-8eb4-c867bb78f36a")]
		public static extern COLORREF GetNearestColor(HDC hdc, COLORREF color);

		/// <summary>
		/// The <c>GetNearestPaletteIndex</c> function retrieves the index for the entry in the specified logical palette most closely
		/// matching a specified color value.
		/// </summary>
		/// <returns>
		/// <para>If the function succeeds, the return value is the index of an entry in a logical palette.</para>
		/// <para>If the function fails, the return value is CLR_INVALID.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the <c>GetDeviceCaps</c> function and
		/// specifying the RASTERCAPS constant.
		/// </para>
		/// <para>If the given logical palette contains entries with the PC_EXPLICIT flag set, the return value is undefined.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/dd144903(v%3dvs.85) UINT GetNearestPaletteIndex( _In_ HPALETTE hpal, _In_
		// COLORREF crColor );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Wingdi.h")]
		public static extern uint GetNearestPaletteIndex(HPALETTE hpal, COLORREF crColor);

		/// <summary>The <c>GetPaletteEntries</c> function retrieves a specified range of palette entries from the given logical palette.</summary>
		/// <param name="hpal">A handle to the logical palette.</param>
		/// <param name="iStart">The first entry in the logical palette to be retrieved.</param>
		/// <param name="cEntries">The number of entries in the logical palette to be retrieved.</param>
		/// <param name="pPalEntries">
		/// A pointer to an array of PALETTEENTRY structures to receive the palette entries. The array must contain at least as many
		/// structures as specified by the nEntries parameter.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds and the handle to the logical palette is a valid pointer (not <c>NULL</c>), the return value is the
		/// number of entries retrieved from the logical palette. If the function succeeds and handle to the logical palette is <c>NULL</c>,
		/// the return value is the number of entries in the given palette.
		/// </para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </para>
		/// <para>
		/// If the nEntries parameter specifies more entries than exist in the palette, the remaining members of the PALETTEENTRY structure
		/// are not altered.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getpaletteentries UINT GetPaletteEntries( HPALETTE hpal,
		// UINT iStart, UINT cEntries, LPPALETTEENTRY pPalEntries );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "5e72e881-32e1-458e-a09e-91fa13abe178")]
		public static extern uint GetPaletteEntries(HPALETTE hpal, uint iStart, uint cEntries, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] PALETTEENTRY[] pPalEntries);

		/// <summary>
		/// The <c>GetSystemPaletteEntries</c> function retrieves a range of palette entries from the system palette that is associated with
		/// the specified device context (DC).
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="iStart">The first entry to be retrieved from the system palette.</param>
		/// <param name="cEntries">The number of entries to be retrieved from the system palette.</param>
		/// <param name="pPalEntries">
		/// A pointer to an array of PALETTEENTRY structures to receive the palette entries. The array must contain at least as many
		/// structures as specified by the nEntries parameter. If this parameter is <c>NULL</c>, the function returns the total number of
		/// entries in the palette.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the number of entries retrieved from the palette.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getsystempaletteentries UINT GetSystemPaletteEntries( HDC
		// hdc, UINT iStart, UINT cEntries, LPPALETTEENTRY pPalEntries );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "67bb0adf-ae7f-48d5-bc62-82ece45aeee6")]
		public static extern uint GetSystemPaletteEntries(HDC hdc, uint iStart, uint cEntries, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] PALETTEENTRY[] pPalEntries);

		/// <summary>
		/// The <c>GetSystemPaletteUse</c> function retrieves the current state of the system (physical) palette for the specified device
		/// context (DC).
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the current state of the system palette. This parameter can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SYSPAL_NOSTATIC</term>
		/// <term>The system palette contains no static colors except black and white.</term>
		/// </item>
		/// <item>
		/// <term>SYSPAL_STATIC</term>
		/// <term>The system palette contains static colors that will not change when an application realizes its logical palette.</term>
		/// </item>
		/// <item>
		/// <term>SYSPAL_ERROR</term>
		/// <term>The given device context is invalid or does not support a color palette.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// By default, the system palette contains 20 static colors that are not changed when an application realizes its logical palette.
		/// An application can gain access to most of these colors by calling the SetSystemPaletteUse function.
		/// </para>
		/// <para>The device context identified by the hdc parameter must represent a device that supports color palettes.</para>
		/// <para>
		/// An application can determine whether a device supports color palettes by calling the GetDeviceCaps function and specifying the
		/// RASTERCAPS constant.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getsystempaletteuse UINT GetSystemPaletteUse( HDC hdc );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "0a9e7906-2f81-4fda-b03d-86feb0755327")]
		public static extern SYSPAL GetSystemPaletteUse(HDC hdc);

		/// <summary>The <c>RealizePalette</c> function maps palette entries from the current logical palette to the system palette.</summary>
		/// <param name="hdc">A handle to the device context into which a logical palette has been selected.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the number of entries in the logical palette mapped to the system palette.</para>
		/// <para>If the function fails, the return value is GDI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </para>
		/// <para>
		/// The <c>RealizePalette</c> function modifies the palette for the device associated with the specified device context. If the
		/// device context is a memory DC, the color table for the bitmap selected into the DC is modified. If the device context is a
		/// display DC, the physical palette for that device is modified.
		/// </para>
		/// <para>
		/// A logical palette is a buffer between color-intensive applications and the system, allowing these applications to use as many
		/// colors as needed without interfering with colors displayed by other windows.
		/// </para>
		/// <para>
		/// When an application's window has the focus and it calls the <c>RealizePalette</c> function, the system attempts to realize as
		/// many of the requested colors as possible. The same is also true for applications with inactive windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-realizepalette UINT RealizePalette( HDC hdc );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "1c744ad2-09bc-455f-bc3c-9a2583b57a30")]
		public static extern uint RealizePalette(HDC hdc);

		/// <summary>The <c>ResizePalette</c> function increases or decreases the size of a logical palette based on the specified value.</summary>
		/// <param name="hpal">A handle to the palette to be changed.</param>
		/// <param name="n">
		/// <para>The number of entries in the palette after it has been resized.</para>
		/// <para>The number of entries is limited to 1024.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </para>
		/// <para>
		/// If an application calls <c>ResizePalette</c> to reduce the size of the palette, the entries remaining in the resized palette are
		/// unchanged. If the application calls <c>ResizePalette</c> to enlarge the palette, the additional palette entries are set to black
		/// (the red, green, and blue values are all 0) and their flags are set to zero.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-resizepalette BOOL ResizePalette( HPALETTE hpal, UINT n );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "77178869-cbfb-4b91-a5b0-7d0404e7534f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ResizePalette(HPALETTE hpal, uint n);

		/// <summary>The <c>SelectPalette</c> function selects the specified logical palette into a device context.</summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="hPal">A handle to the logical palette to be selected.</param>
		/// <param name="bForceBkgd">
		/// <para>
		/// Specifies whether the logical palette is forced to be a background palette. If this value is <c>TRUE</c>, the RealizePalette
		/// function causes the logical palette to be mapped to the colors already in the physical palette in the best possible way. This is
		/// always done, even if the window for which the palette is realized belongs to a thread without active focus.
		/// </para>
		/// <para>
		/// If this value is <c>FALSE</c>, RealizePalette causes the logical palette to be copied into the device palette when the
		/// application is in the foreground. (If the hdc parameter is a memory device context, this parameter is ignored.)
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the device context's previous logical palette.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </para>
		/// <para>
		/// An application can select a logical palette into more than one device context only if device contexts are compatible. Otherwise
		/// <c>SelectPalette</c> fails. To create a device context that is compatible with another device context, call CreateCompatibleDC
		/// with the first device context as the parameter. If a logical palette is selected into more than one device context, changes to
		/// the logical palette will affect all device contexts for which it is selected.
		/// </para>
		/// <para>
		/// An application might call the <c>SelectPalette</c> function with the bForceBackground parameter set to <c>TRUE</c> if the child
		/// windows of a top-level window each realize their own palettes. However, only the child window that needs to realize its palette
		/// must set bForceBackground to <c>TRUE</c>; other child windows must set this value to <c>FALSE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-selectpalette HPALETTE SelectPalette( HDC hdc, HPALETTE
		// hPal, BOOL bForceBkgd );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "1fc3356f-6fa3-444f-b224-b953acd2394b")]
		public static extern HPALETTE SelectPalette(HDC hdc, HPALETTE hPal, [MarshalAs(UnmanagedType.Bool)] bool bForceBkgd);

		/// <summary>
		/// The <c>SetColorAdjustment</c> function sets the color adjustment values for a device context (DC) using the specified values.
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="lpca">A pointer to a COLORADJUSTMENT structure containing the color adjustment values.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// The color adjustment values are used to adjust the input color of the source bitmap for calls to the StretchBlt and StretchDIBits
		/// functions when HALFTONE mode is set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-setcoloradjustment BOOL SetColorAdjustment( HDC hdc, const
		// COLORADJUSTMENT *lpca );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "292d6cdc-cafa-438a-9392-a9c22e7d44a5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetColorAdjustment(HDC hdc, in COLORADJUSTMENT lpca);

		/// <summary>
		/// The <c>SetPaletteEntries</c> function sets RGB (red, green, blue) color values and flags in a range of entries in a logical palette.
		/// </summary>
		/// <param name="hpal">A handle to the logical palette.</param>
		/// <param name="iStart">The first logical-palette entry to be set.</param>
		/// <param name="cEntries">The number of logical-palette entries to be set.</param>
		/// <param name="pPalEntries">
		/// A pointer to the first member of an array of PALETTEENTRY structures containing the RGB values and flags.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the number of entries that were set in the logical palette.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </para>
		/// <para>
		/// Even if a logical palette has been selected and realized, changes to the palette do not affect the physical palette in the
		/// surface. RealizePalette must be called again to set the new logical palette into the surface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-setpaletteentries UINT SetPaletteEntries( HPALETTE hpal,
		// UINT iStart, UINT cEntries, const PALETTEENTRY *pPalEntries );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "df38f482-75ba-4800-8b26-92204c63255e")]
		public static extern uint SetPaletteEntries(HPALETTE hpal, uint iStart, uint cEntries, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] PALETTEENTRY[] pPalEntries);

		/// <summary>
		/// The <c>SetSystemPaletteUse</c> function allows an application to specify whether the system palette contains 2 or 20 static
		/// colors. The default system palette contains 20 static colors. (Static colors cannot be changed when an application realizes a
		/// logical palette.)
		/// </summary>
		/// <param name="hdc">A handle to the device context. This device context must refer to a device that supports color palettes.</param>
		/// <param name="use">
		/// <para>The new use of the system palette. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SYSPAL_NOSTATIC</term>
		/// <term>The system palette contains two static colors (black and white).</term>
		/// </item>
		/// <item>
		/// <term>SYSPAL_NOSTATIC256</term>
		/// <term>The system palette contains no static colors.</term>
		/// </item>
		/// <item>
		/// <term>SYSPAL_STATIC</term>
		/// <term>The system palette contains static colors that will not change when an application realizes its logical palette.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the previous system palette. It can be either SYSPAL_NOSTATIC, SYSPAL_NOSTATIC256,
		/// or SYSPAL_STATIC.
		/// </para>
		/// <para>If the function fails, the return value is SYSPAL_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </para>
		/// <para>
		/// When an application window moves to the foreground and the SYSPAL_NOSTATIC value is set, the application must call the
		/// GetSysColor function to save the current system colors setting. It must also call SetSysColors to set reasonable values using
		/// only black and white. When the application returns to the background or terminates, the previous system colors must be restored.
		/// </para>
		/// <para>If the function returns SYSPAL_ERROR, the specified device context is invalid or does not support color palettes.</para>
		/// <para>An application must call this function only when its window is maximized and has the input focus.</para>
		/// <para>
		/// If an application calls <c>SetSystemPaletteUse</c> with uUsage set to SYSPAL_NOSTATIC, the system continues to set aside two
		/// entries in the system palette for pure white and pure black, respectively.
		/// </para>
		/// <para>After calling this function with uUsage set to SYSPAL_NOSTATIC, an application must take the following steps:</para>
		/// <list type="number">
		/// <item>
		/// <term>Realize the logical palette.</term>
		/// </item>
		/// <item>
		/// <term>Call the GetSysColor function to save the current system-color settings.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the SetSysColors function to set the system colors to reasonable values using black and white. For example, adjacent or
		/// overlapping items (such as window frames and borders) should be set to black and white, respectively.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Send the WM_SYSCOLORCHANGE message to other top-level windows to allow them to be redrawn with the new system colors.</term>
		/// </item>
		/// </list>
		/// <para>When the application's window loses focus or closes, the application must perform the following steps:</para>
		/// <list type="number">
		/// <item>
		/// <term>Call <c>SetSystemPaletteUse</c> with the uUsage parameter set to SYSPAL_STATIC.</term>
		/// </item>
		/// <item>
		/// <term>Realize the logical palette.</term>
		/// </item>
		/// <item>
		/// <term>Restore the system colors to their previous values.</term>
		/// </item>
		/// <item>
		/// <term>Send the WM_SYSCOLORCHANGE message.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-setsystempaletteuse UINT SetSystemPaletteUse( HDC hdc, UINT
		// use );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "6ff245d3-1bcc-4778-a595-c1eb16531ad3")]
		public static extern SYSPAL SetSystemPaletteUse(HDC hdc, SYSPAL use);

		/// <summary>
		/// The <c>UnrealizeObject</c> function resets the origin of a brush or resets a logical palette. If the hgdiobj parameter is a
		/// handle to a brush, <c>UnrealizeObject</c> directs the system to reset the origin of the brush the next time it is selected. If
		/// the hgdiobj parameter is a handle to a logical palette, <c>UnrealizeObject</c> directs the system to realize the palette as
		/// though it had not previously been realized. The next time the application calls the RealizePalette function for the specified
		/// palette, the system completely remaps the logical palette to the system palette.
		/// </summary>
		/// <param name="h">A handle to the logical palette to be reset.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>UnrealizeObject</c> function should not be used with stock objects. For example, the default palette, obtained by calling
		/// GetStockObject (DEFAULT_PALETTE), is a stock object.
		/// </para>
		/// <para>A palette identified by hgdiobj can be the currently selected palette of a device context.</para>
		/// <para>
		/// If hgdiobj is a brush, <c>UnrealizeObject</c> does nothing, and the function returns <c>TRUE</c>. Use SetBrushOrgEx to set the
		/// origin of a brush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-unrealizeobject BOOL UnrealizeObject( HGDIOBJ h );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "b84cd0b3-fdf1-4f12-bc45-308032d6d698")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnrealizeObject(HGDIOBJ h);

		/// <summary>
		/// The <c>UpdateColors</c> function updates the client area of the specified device context by remapping the current colors in the
		/// client area to the currently realized logical palette.
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and specifying
		/// the RASTERCAPS constant.
		/// </para>
		/// <para>
		/// An inactive window with a realized logical palette may call <c>UpdateColors</c> as an alternative to redrawing its client area
		/// when the system palette changes.
		/// </para>
		/// <para>
		/// The <c>UpdateColors</c> function typically updates a client area faster than redrawing the area. However, because
		/// <c>UpdateColors</c> performs the color translation based on the color of each pixel before the system palette changed, each call
		/// to this function results in the loss of some color accuracy.
		/// </para>
		/// <para>This function must be called soon after a WM_PALETTECHANGED message is received.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-updatecolors BOOL UpdateColors( HDC hdc );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "61dfd579-3fc9-4e0a-bfd9-d04c6f918fd8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UpdateColors(HDC hdc);

		/// <summary>
		/// The <c>COLORADJUSTMENT</c> structure defines the color adjustment values used by the StretchBlt and StretchDIBits functions when
		/// the stretch mode is HALFTONE. You can set the color adjustment values by calling the SetColorAdjustment function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-coloradjustment typedef struct tagCOLORADJUSTMENT { WORD
		// caSize; WORD caFlags; WORD caIlluminantIndex; WORD caRedGamma; WORD caGreenGamma; WORD caBlueGamma; WORD caReferenceBlack; WORD
		// caReferenceWhite; SHORT caContrast; SHORT caBrightness; SHORT caColorfulness; SHORT caRedGreenTint; } COLORADJUSTMENT,
		// *PCOLORADJUSTMENT, *LPCOLORADJUSTMENT;
		[PInvokeData("wingdi.h", MSDNShortId = "9a080f60-0bce-46b6-b8a8-f534ff83a0a8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct COLORADJUSTMENT
		{
			/// <summary>The size, in bytes, of the structure.</summary>
			public ushort caSize;

			/// <summary>
			/// <para>
			/// Specifies how the output image should be prepared. This member may be set to <c>NULL</c> or any combination of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CA_NEGATIVE</term>
			/// <term>Specifies that the negative of the original image should be displayed.</term>
			/// </item>
			/// <item>
			/// <term>CA_LOG_FILTER</term>
			/// <term>
			/// Specifies that a logarithmic function should be applied to the final density of the output colors. This will increase the
			/// color contrast when the luminance is low.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public CA_FLAGS caFlags;

			/// <summary>
			/// <para>
			/// The type of standard light source under which the image is viewed. This member may be set to one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ILLUMINANT_DEVICE_DEFAULT</term>
			/// <term>Device's default. Standard used by output devices.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_A</term>
			/// <term>Tungsten lamp.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_B</term>
			/// <term>Noon sunlight.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_C</term>
			/// <term>NTSC daylight.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_D50</term>
			/// <term>Normal print.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_D55</term>
			/// <term>Bond paper print.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_D65</term>
			/// <term>Standard daylight. Standard for CRTs and pictures.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_D75</term>
			/// <term>Northern daylight.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_F2</term>
			/// <term>Cool white lamp.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_TUNGSTEN</term>
			/// <term>Same as ILLUMINANT_A.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_DAYLIGHT</term>
			/// <term>Same as ILLUMINANT_C.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_FLUORESCENT</term>
			/// <term>Same as ILLUMINANT_F2.</term>
			/// </item>
			/// <item>
			/// <term>ILLUMINANT_NTSC</term>
			/// <term>Same as ILLUMINANT_C.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ILLUMINANT caIlluminantIndex;

			/// <summary>
			/// Specifies the n power gamma-correction value for the red primary of the source colors. The value must be in the range from
			/// 2500 to 65,000. A value of 10,000 means no gamma correction.
			/// </summary>
			public ushort caRedGamma;

			/// <summary>
			/// Specifies the n power gamma-correction value for the green primary of the source colors. The value must be in the range from
			/// 2500 to 65,000. A value of 10,000 means no gamma correction.
			/// </summary>
			public ushort caGreenGamma;

			/// <summary>
			/// Specifies the n power gamma-correction value for the blue primary of the source colors. The value must be in the range from
			/// 2500 to 65,000. A value of 10,000 means no gamma correction.
			/// </summary>
			public ushort caBlueGamma;

			/// <summary>
			/// The black reference for the source colors. Any colors that are darker than this are treated as black. The value must be in
			/// the range from 0 to 4000.
			/// </summary>
			public ushort caReferenceBlack;

			/// <summary>
			/// The white reference for the source colors. Any colors that are lighter than this are treated as white. The value must be in
			/// the range from 6000 to 10,000.
			/// </summary>
			public ushort caReferenceWhite;

			/// <summary>
			/// The amount of contrast to be applied to the source object. The value must be in the range from -100 to 100. A value of 0
			/// means no contrast adjustment.
			/// </summary>
			public short caContrast;

			/// <summary>
			/// The amount of brightness to be applied to the source object. The value must be in the range from -100 to 100. A value of 0
			/// means no brightness adjustment.
			/// </summary>
			public short caBrightness;

			/// <summary>
			/// The amount of colorfulness to be applied to the source object. The value must be in the range from -100 to 100. A value of 0
			/// means no colorfulness adjustment.
			/// </summary>
			public short caColorfulness;

			/// <summary>
			/// The amount of red or green tint adjustment to be applied to the source object. The value must be in the range from -100 to
			/// 100. Positive numbers adjust toward red and negative numbers adjust toward green. Zero means no tint adjustment.
			/// </summary>
			public short caRedGreenTint;
		}

		/// <summary>Specifies the color and usage of an entry in a logical palette.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-tagpaletteentry typedef struct tagPALETTEENTRY { BYTE peRed;
		// BYTE peGreen; BYTE peBlue; BYTE peFlags; } PALETTEENTRY, *PPALETTEENTRY, *LPPALETTEENTRY;
		[PInvokeData("wingdi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PALETTEENTRY
		{
			/// <summary>
			/// <para>Type: <c>BYTE</c></para>
			/// <para>The red intensity value for the palette entry.</para>
			/// </summary>
			public byte peRed;

			/// <summary>
			/// <para>Type: <c>BYTE</c></para>
			/// <para>The green intensity value for the palette entry.</para>
			/// </summary>
			public byte peGreen;

			/// <summary>
			/// <para>Type: <c>BYTE</c></para>
			/// <para>The blue intensity value for the palette entry.</para>
			/// </summary>
			public byte peBlue;

			/// <summary>
			/// <para>Type: <c>BYTE</c></para>
			/// <para>
			/// The alpha intensity value for the palette entry. Note that as of DirectX 8, this member is treated differently than
			/// documented for Windows.
			/// </para>
			/// </summary>
			public PC peFlags;
		}

		/// <summary>The <c>LOGPALETTE</c> structure defines a logical palette.</summary>
		/// <remarks>
		/// The colors in the palette-entry table should appear in order of importance because entries earlier in the logical palette are
		/// most likely to be placed in the system palette.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-taglogpalette typedef struct tagLOGPALETTE { WORD
		// palVersion; WORD palNumEntries; PALETTEENTRY palPalEntry[1]; } LOGPALETTE, *PLOGPALETTE, *NPLOGPALETTE, *LPLOGPALETTE;
		[PInvokeData("wingdi.h", MSDNShortId = "99d70a0e-ac61-4a88-a500-66443e7882ad")]
		[StructLayout(LayoutKind.Sequential)]
		public class LOGPALETTE : IDisposable
		{
			/// <summary>The version number of the system.</summary>
			public ushort palVersion;

			/// <summary>The number of entries in the logical palette.</summary>
			public ushort palNumEntries;

			private IntPtr _palPalEntry;

			/// <summary>Specifies an array of PALETTEENTRY structures that define the color and usage of each entry in the logical palette.</summary>
			public PALETTEENTRY[] palPalEntry
			{
				get => _palPalEntry.ToArray<PALETTEENTRY>(palNumEntries);
				set { Marshal.FreeHGlobal(_palPalEntry); value.MarshalToPtr(Marshal.AllocHGlobal, out _); }
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose() => Marshal.FreeHGlobal(_palPalEntry);
		}
	}
}