using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>
		/// The <c>EnumICMProfilesProcCallback</c> callback is an application-defined callback function that processes color profile data
		/// from <c>EnumICMProfiles</c> .
		/// </summary>
		/// <param name="lpszFilename">Pointer to the file name of the color profile.</param>
		/// <param name="lParam">Data supplied by the application that is passed to the callback function by the EnumICMProfiles function.</param>
		/// <returns>
		/// This function must return a positive value to continue enumeration, or zero to stop enumeration. It may not return a negative value.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-icmenumprocw ICMENUMPROCW Icmenumprocw; int Icmenumprocw(
		// LPWSTR Arg1, LPARAM Arg2 ) {...}
		[PInvokeData("wingdi.h", MSDNShortId = "6e8f4ce5-c546-4e6a-8f35-4a22d60b6754")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		public delegate int EnumICMProfilesProcCallback(string lpszFilename, IntPtr lParam);

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

		/// <summary>Constants used for <see cref="ColorMatchToTarget"/>.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "eb922411-0808-4404-bdaf-bf29d0cad379")]
		public enum CS
		{
			/// <summary>
			/// Map the colors to the target device's color gamut. This enables color proofing. All subsequent draw commands to the DC will
			/// render colors as they would appear on the target device.
			/// </summary>
			CS_ENABLE = 0x00000001,

			/// <summary>Disable color proofing.</summary>
			CS_DISABLE = 0x00000002,

			/// <summary>If color management is enabled for the target profile, disable it and delete the concatenated transform.</summary>
			CS_DELETE_TRANSFORM = 0x00000003,
		}

		/// <summary>Turns on and off image color management.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "40d70c1f-c580-43c4-b44b-6c9388e138fb")]
		public enum ICM
		{
			/// <summary>Turns off color management. Turns on old-style color correction of halftones.</summary>
			ICM_OFF = 1,

			/// <summary>Turns on color management. Turns off old-style color correction of halftones.</summary>
			ICM_ON = 2,

			/// <summary>Queries the current state of color management.</summary>
			ICM_QUERY = 3,

			/// <summary>
			/// Turns off color management inside DC. Under Windows 2000, also turns off old-style color correction of halftones. Not
			/// supported under Windows 95.
			/// </summary>
			ICM_DONE_OUTSIDEDC = 4,
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

		/// <summary>Color space type.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "b08aec07-6ac0-47be-8dc9-d604d94dedde")]
		public enum LCSCSTYPE : uint
		{
			/// <summary>
			/// Color values are calibrated RGB values. The values are translated using the endpoints specified by the lcsEndpoints member
			/// before being passed to the device.
			/// </summary>
			LCS_CALIBRATED_RGB = 0,

			/// <summary>Color values are values are sRGB values.</summary>
			LCS_sRGB = 0x73524742,

			/// <summary>Color values are Windows default color space color values.</summary>
			LCS_WINDOWS_COLOR_SPACE = 0x57696e20,
		}

		/// <summary>The gamut mapping method.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "b08aec07-6ac0-47be-8dc9-d604d94dedde")]
		[Flags]
		public enum LCSGAMUTMATCH : uint
		{
			/// <summary>Maintain saturation. Used for business charts and other situations in which undithered colors are required.</summary>
			LCS_GM_BUSINESS = 0x00000001,

			/// <summary>Maintain colorimetric match. Used for graphic designs and named colors.</summary>
			LCS_GM_GRAPHICS = 0x00000002,

			/// <summary>Maintain contrast. Used for photographs and natural images.</summary>
			LCS_GM_IMAGES = 0x00000004,

			/// <summary>Maintain the white point. Match the colors to their nearest color in the destination gamut.</summary>
			LCS_GM_ABS_COLORIMETRIC = 0x00000008,
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

		/// <summary>
		/// The <c>CheckColorsInGamut</c> function determines whether a specified set of RGB triples lies in the output gamut of a specified
		/// device. The RGB triples are interpreted in the input logical color space.
		/// </summary>
		/// <param name="hdc">Handle to the device context whose output gamut to be checked.</param>
		/// <param name="lpRGBTriple">Pointer to an array of RGB triples to check.</param>
		/// <param name="dlpBuffer">
		/// Pointer to the buffer in which the results are to be placed. This buffer must be at least as large as nCount bytes.
		/// </param>
		/// <param name="nCount">The number of elements in the array of triples.</param>
		/// <returns>
		/// <para>If this function succeeds, the return value is a nonzero value.</para>
		/// <para>If this function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The function places the test results in the buffer pointed to by lpBuffer. Each byte in the buffer corresponds to an RGB triple,
		/// and has an unsigned value between CM_IN_GAMUT (= 0) and CM_OUT_OF_GAMUT (= 255). The value 0 denotes that the color is in gamut,
		/// while a nonzero value denotes that it is out of gamut. For any integer n such that 0 &lt; n &lt; 255, a result value of n + 1
		/// indicates that the corresponding color is at least as far out of gamut as would be indicated by a result value of n, as specified
		/// by the ICC Profile Format Specification. For more information on the ICC Profile Format Specification, see the sources listed in
		/// Further Information.
		/// </para>
		/// <para>
		/// Note that for this function to succeed, WCS must be enabled for the device context handle that is passed in through the hDC
		/// parameter. WCS can be enabled for a device context handle by calling the SetICMMode function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-checkcolorsingamut BOOL CheckColorsInGamut( HDC hdc,
		// LPRGBTRIPLE lpRGBTriple, LPVOID dlpBuffer, DWORD nCount );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "87bee1a6-e3dd-4d0b-ad8a-9584833d9463")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckColorsInGamut(HDC hdc, [In] RGBTRIPLE[] lpRGBTriple, IntPtr dlpBuffer, uint nCount);

		/// <summary>
		/// The <c>ColorCorrectPalette</c> function corrects the entries of a palette using the WCS 1.0 parameters in the specified device context.
		/// </summary>
		/// <param name="hdc">Specifies a device context whose WCS parameters to use.</param>
		/// <param name="hPal">Specifies the handle to the palette to be color corrected.</param>
		/// <param name="deFirst">Specifies the first entry in the palette to be color corrected.</param>
		/// <param name="num">Specifies the number of entries to color correct.</param>
		/// <returns>
		/// <para>If this function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If this function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-colorcorrectpalette BOOL ColorCorrectPalette( HDC hdc,
		// HPALETTE hPal, DWORD deFirst, DWORD num );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "e7680521-fb1e-4292-945f-867964dac1ab")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ColorCorrectPalette(HDC hdc, HPALETTE hPal, uint deFirst, uint num);

		/// <summary>The <c>ColorMatchToTarget</c> function enables you to preview colors as they would appear on the target device.</summary>
		/// <param name="hdc">Specifies the device context for previewing, generally the screen.</param>
		/// <param name="hdcTarget">Specifies the target device context, generally a printer.</param>
		/// <param name="action">
		/// <para>A constant that can have one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CS_ENABLE</term>
		/// <term>
		/// Map the colors to the target device's color gamut. This enables color proofing. All subsequent draw commands to the DC will
		/// render colors as they would appear on the target device.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CS_DISABLE</term>
		/// <term>Disable color proofing.</term>
		/// </item>
		/// <item>
		/// <term>CS_DELETE_TRANSFORM</term>
		/// <term>If color management is enabled for the target profile, disable it and delete the concatenated transform.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If this function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ColorMatchToTarget</c> can be used to proof the colors of a color output device on another color output device. Setting the
		/// uiAction parameter to CS_ENABLE causes all subsequent drawing commands to the DC to render colors as they would appear on the
		/// target device. If uiAction is set to CS_DISABLE, proofing is turned off. However, the current color transform is not deleted from
		/// the DC. It is just inactive.
		/// </para>
		/// <para>
		/// When <c>ColorMatchToTarget</c> is called, the color transform for the target device is performed first, and then the transform to
		/// the preview device is applied to the results of the first transform. This is used primarily for checking gamut mapping
		/// conditions. Before using this function, you must enable WCS for both device contexts.
		/// </para>
		/// <para>
		/// This function cannot be cascaded. While color mapping to the target is enabled by setting uiAction to CS_ENABLE, application
		/// changes to the color space or gamut mapping method are ignored. Those changes then take effect when color mapping to the target
		/// is disabled.
		/// </para>
		/// <para>
		/// <c>Note</c> A memory leak will not occur if an application does not delete a transform using CS_DELETE_TRANSFORM. The transform
		/// will be deleted when either the device context (DC) is closed, or when the application color space is deleted. However if the
		/// transform is not going to be used again, or if the application will not be performing any more color matching on the DC, it
		/// should explicitly delete the transform to free the memory it occupies.
		/// </para>
		/// <para>
		/// The uiAction parameter should only be set to CS_DELETE_TRANSFORM if color management is enabled before the
		/// <c>ColorMatchToTarget</c> function is called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-colormatchtotarget BOOL ColorMatchToTarget( HDC hdc, HDC
		// hdcTarget, DWORD action );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "eb922411-0808-4404-bdaf-bf29d0cad379")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ColorMatchToTarget(HDC hdc, HDC hdcTarget, CS action);

		/// <summary>The <c>CreateColorSpace</c> function creates a logical color space.</summary>
		/// <param name="lplcs">Pointer to the LOGCOLORSPACE data structure.</param>
		/// <returns>
		/// <para>If this function succeeds, the return value is a handle that identifies a color space.</para>
		/// <para>If this function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>When the color space is no longer needed, use <c>DeleteColorSpace</c> to delete it.</para>
		/// <para>
		/// <c>Windows 95/98/Me:</c><c>CreateColorSpaceW</c> is supported by the Microsoft Layer for Unicode. To use this, you must add
		/// certain files to your application, as outlined in Microsoft Layer for Unicode on Windows 95/98/Me Systems.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createcolorspacea HCOLORSPACE CreateColorSpaceA(
		// LPLOGCOLORSPACEA lplcs );
		[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wingdi.h", MSDNShortId = "c3fc798c-4bb9-4010-87d4-edc0005b7698")]
		public static extern SafeHCOLORSPACE CreateColorSpace(in LOGCOLORSPACE lplcs);

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

		/// <summary>The <c>DeleteColorSpace</c> function removes and destroys a specified color space.</summary>
		/// <param name="hcs">Specifies the handle to a color space to delete.</param>
		/// <returns>
		/// <para>If this function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If this function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deletecolorspace BOOL DeleteColorSpace( HCOLORSPACE hcs );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "5b241224-2994-4533-9629-d2a4b129ce86")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteColorSpace(HCOLORSPACE hcs);

		/// <summary>
		/// The <c>EnumICMProfiles</c> function enumerates the different output color profiles that the system supports for a given device context.
		/// </summary>
		/// <param name="hdc">Specifies the device context.</param>
		/// <param name="proc">Specifies the procedure instance address of a callback function defined by the application. (See EnumICMProfilesProcCallback.)</param>
		/// <param name="param">Data supplied by the application that is passed to the callback function along with the color profile information.</param>
		/// <returns>
		/// This function returns zero if the application interrupted the enumeration. The return value is -1 if there are no color profiles
		/// to enumerate. Otherwise, the return value is the last value returned by the callback function.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>EnumICMProfiles</c> function returns a list of profiles that are associated with a device context (DC), and whose settings
		/// match those of the DC. It is possible for a device context to contain device profiles that are not associated with particular
		/// hardware devices, or device profiles that do not match the settings of the DC. The sRGB profile is an example. The SetICMProfile
		/// function is used to associate these types of profiles with a DC. The GetICMProfile function can be used to retrieve a profile
		/// that is not enumerated by the <c>EnumICMProfiles</c> function.
		/// </para>
		/// <para>
		/// <c>Windows 95/98/Me:</c><c>EnumICMProfilesW</c> is supported by the Microsoft Layer for Unicode. To use this, you must add
		/// certain files to your application, as outlined in Microsoft Layer for Unicode on Windows 95/98/Me Systems.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumicmprofilesw int EnumICMProfilesW( HDC hdc, ICMENUMPROCW
		// proc, LPARAM param );
		[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wingdi.h", MSDNShortId = "a93e6239-b6c7-4e37-9f06-03790a3ed53f")]
		public static extern int EnumICMProfiles(HDC hdc, EnumICMProfilesProcCallback proc, [Optional] IntPtr param);

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

		/// <summary>The <c>GetColorSpace</c> function retrieves the handle to the input color space from a specified device context.</summary>
		/// <param name="hdc">Specifies a device context that is to have its input color space handle retrieved.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the current input color space handle.</para>
		/// <para>If this function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <c>GetColorSpace</c> obtains the handle to the input color space regardless of whether color management is enabled for the device context.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcolorspace HCOLORSPACE GetColorSpace( HDC hdc );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "6d092755-2c7a-46a7-9127-df72c26c3ae9")]
		public static extern HCOLORSPACE GetColorSpace(HDC hdc);

		/// <summary>The <c>GetDeviceGammaRamp</c> function gets the gamma ramp on direct color display boards having drivers that support downloadable gamma ramps in hardware.</summary>
		/// <param name="hdc">Specifies the device context of the direct color display board in question.</param>
		/// <param name="lpRamp">Points to a buffer where the function can place the current gamma ramp of the color display board. The gamma ramp is specified in three arrays of 256 <c>WORD</c> elements each, which contain the mapping between RGB values in the frame buffer and digital-analog-converter (DAC) values. The sequence of the arrays is red, green, blue.</param>
		/// <returns>
		/// <para>If this function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If this function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>Direct color display modes do not use color lookup tables and are usually 16, 24, or 32 bit. Not all direct color video boards support loadable gamma ramps. <c>GetDeviceGammaRamp</c> succeeds only for devices with drivers that support downloadable gamma ramps in hardware.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdevicegammaramp
		// BOOL GetDeviceGammaRamp( HDC hdc, LPVOID lpRamp );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "c32600a9-545e-4bbf-a3c1-21878f5106b0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetDeviceGammaRamp(HDC hdc, IntPtr lpRamp);

		/// <summary>
		/// The <c>GetICMProfile</c> function retrieves the file name of the current output color profile for a specified device context.
		/// </summary>
		/// <param name="hdc">Specifies a device context from which to retrieve the color profile.</param>
		/// <param name="pBufSize">
		/// Pointer to a <c>DWORD</c> that contains the size of the buffer pointed to by lpszFilename. For the ANSI version of this function,
		/// the size is in bytes. For the Unicode version, the size is in WCHARs. If this function is successful, on return this parameter
		/// contains the size of the buffer actually used. However, if the buffer is not large enough, this function returns <c>FALSE</c>. In
		/// this case, the <c>GetLastError()</c> function returns ERROR_INSUFFICIENT_BUFFER and the <c>DWORD</c> pointed to by this parameter
		/// contains the size needed for the lpszFilename buffer.
		/// </param>
		/// <param name="pszFilename">Points to the buffer that receives the path name of the profile.</param>
		/// <returns>
		/// <para>
		/// If this function succeeds, the return value is <c>TRUE</c>. It also returns <c>TRUE</c> if the lpszFilename parameter is
		/// <c>NULL</c> and the size required for the buffer is copied into lpcbName.
		/// </para>
		/// <para>If this function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetICMProfile</c> obtains the file name of the current output profile regardless of whether or not color management is enabled
		/// for the device context.
		/// </para>
		/// <para>
		/// Given a device context, <c>GetICMProfile</c> will output, through the parameter lpszFilename, the path name of the file
		/// containing the color profile currently being used by the device context. It will also output, through the parameter lpcbName, the
		/// length of the string containing the path name.
		/// </para>
		/// <para>
		/// It is possible that the profile name returned by <c>GetICMProfile</c> will not be in the list of profiles returned by
		/// EnumICMProfiles. The <c>EnumICMProfiles</c> function returns all color space profiles that are associated with a device context
		/// (DC) whose settings match that of the DC. If the SetICMProfile function is used to set the current profile, a profile may be
		/// associated with the DC that does not match its settings. For instance, the <c>SetICMProfile</c> function can be used to associate
		/// the device-independent sRGB profile with a DC. This profile will be used as the current WCS profile for that DC, and calls to
		/// <c>GetICMProfile</c> will return its file name. However, the profile will not appear in the list of profiles that is returned
		/// from <c>EnumICMProfiles</c>.
		/// </para>
		/// <para>
		/// If this function is called before any calls to the <c>SetICMProfile</c> function, it can be used to get the default profile for a
		/// device context.
		/// </para>
		/// <para>
		/// <c>Windows 95/98/Me:</c><c>GetICMProfileW</c> is supported by the Microsoft Layer for Unicode. To use this, you must add certain
		/// files to your application, as outlined in Microsoft Layer for Unicode on Windows 95/98/Me Systems.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-geticmprofilea BOOL GetICMProfileA( HDC hdc, LPDWORD pBufSize,
		// LPSTR pszFilename );
		[DllImport(Lib.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("wingdi.h", MSDNShortId = "1e16771a-80c5-47bb-9c98-14169d4dd773")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetICMProfile(HDC hdc, ref uint pBufSize, StringBuilder pszFilename);

		/// <summary>The <c>GetLogColorSpace</c> function retrieves the color space definition identified by a specified handle.</summary>
		/// <param name="hColorSpace">Specifies the handle to a color space.</param>
		/// <param name="lpBuffer">Points to a buffer to receive the LOGCOLORSPACE structure.</param>
		/// <param name="nSize">Specifies the maximum size of the buffer.</param>
		/// <returns>
		/// <para>If this function succeeds, the return value is TRUE.</para>
		/// <para>If this function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <c>Windows 95/98/Me:</c><c>GetLogColorSpaceW</c> is supported by the Microsoft Layer for Unicode. To use this, you must add
		/// certain files to your application, as outlined in Microsoft Layer for Unicode on Windows 95/98/Me Systems.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getlogcolorspacea BOOL GetLogColorSpaceA( HCOLORSPACE
		// hColorSpace, LPLOGCOLORSPACEA lpBuffer, DWORD nSize );
		[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wingdi.h", MSDNShortId = "01862a48-8c2f-4b29-b928-2800c02218a2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetLogColorSpace(HCOLORSPACE hColorSpace, ref LOGCOLORSPACE lpBuffer, uint nSize);

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

		/// <summary>The <c>SetColorSpace</c> function defines the input color space for a given device context.</summary>
		/// <param name="hdc">Specifies the handle to a device context.</param>
		/// <param name="hcs">Identifies handle to the color space to set.</param>
		/// <returns>
		/// <para>If this function succeeds, the return value is a handle to the hColorSpace being replaced.</para>
		/// <para>If this function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setcolorspace HCOLORSPACE SetColorSpace( HDC hdc, HCOLORSPACE
		// hcs );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "037c864f-f8ec-4467-9236-74ea4493d743")]
		public static extern HCOLORSPACE SetColorSpace(HDC hdc, HCOLORSPACE hcs);

		/// <summary>
		/// The <c>SetDeviceGammaRamp</c> function sets the gamma ramp on direct color display boards having drivers that support
		/// downloadable gamma ramps in hardware.
		/// </summary>
		/// <param name="hdc">Specifies the device context of the direct color display board in question.</param>
		/// <param name="lpRamp">
		/// Pointer to a buffer containing the gamma ramp to be set. The gamma ramp is specified in three arrays of 256 <c>WORD</c> elements
		/// each, which contain the mapping between RGB values in the frame buffer and digital-analog-converter (DAC ) values. The sequence
		/// of the arrays is red, green, blue. The RGB values must be stored in the most significant bits of each WORD to increase DAC independence.
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If this function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// Direct color display modes do not use color lookup tables and are usually 16, 24, or 32 bit. Not all direct color video boards
		/// support loadable gamma ramps. <c>SetDeviceGammaRamp</c> succeeds only for devices with drivers that support downloadable gamma
		/// ramps in hardware.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdevicegammaramp
		// BOOL SetDeviceGammaRamp( HDC hdc, LPVOID lpRamp );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "8e4cc9a4-f292-47a1-a12a-43a479326ca7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDeviceGammaRamp(HDC hdc, IntPtr lpRamp);

		/// <summary>
		/// The <c>SetICMMode</c> function causes Image Color Management to be enabled, disabled, or queried on a given device context (DC).
		/// </summary>
		/// <param name="hdc">Identifies handle to the device context.</param>
		/// <param name="mode">
		/// <para>Turns on and off image color management. This parameter can take one of the following constant values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ICM_ON</term>
		/// <term>Turns on color management. Turns off old-style color correction of halftones.</term>
		/// </item>
		/// <item>
		/// <term>ICM_OFF</term>
		/// <term>Turns off color management. Turns on old-style color correction of halftones.</term>
		/// </item>
		/// <item>
		/// <term>ICM_QUERY</term>
		/// <term>Queries the current state of color management.</term>
		/// </item>
		/// <item>
		/// <term>ICM_DONE_OUTSIDEDC</term>
		/// <term>
		/// Turns off color management inside DC. Under Windows 2000, also turns off old-style color correction of halftones. Not supported
		/// under Windows 95.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, the return value is a nonzero value.</para>
		/// <para>If this function fails, the return value is zero.</para>
		/// <para>
		/// If ICM_QUERY is specified and the function succeeds, the nonzero value returned is ICM_ON or ICM_OFF to indicate the current mode.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>If the system cannot find an ICC color profile to match the state of the device, <c>SetICMMode</c> fails and returns zero.</para>
		/// <para>
		/// Once WCS is enabled for a device context (DC), colors passed into the DC using most Win32 API functions are color matched. The
		/// primary exceptions are <c>BitBlt</c> and <c>StretchBlt</c>. The assumption is that when performing a bit block transfer (blit)
		/// from one DC to another, the two DCs are already compatible and need no color correction. If this is not the case, color
		/// correction may be performed. Specifically, if a device independent bitmap (DIB) is used as the source for a blit, and the blit is
		/// performed into a DC that has WCS enabled, color matching will be performed. If this is not what you want, turn WCS off for the
		/// destination DC by calling <c>SetICMMode</c> before calling <c>BitBlt</c> or <c>StretchBlt</c>.
		/// </para>
		/// <para>
		/// If the <c>CreateCompatibleDC</c> function is used to create a bitmap in a DC, it is possible for the bitmap to be color matched
		/// twice, once when it is created and once when a blit is performed. The reason is that a bitmap in a DC created by the
		/// <c>CreateCompatibleDC</c> function acquires the current brush, pens, and palette of the source DC. However, WCS will be disabled
		/// by default for the new DC. If WCS is later enabled for the new DC by using the <c>SetICMMode</c> function, a color correction
		/// will be done. To prevent double color corrections through the use of the <c>CreateCompatibleDC</c> function, use the
		/// <c>SetICMMode</c> function to turn WCS off for the source DC before the <c>CreateCompatibleDC</c> function is called.
		/// </para>
		/// <para>
		/// When a compatible DC is created from a printer's DC (see <c>CreateCompatibleDC</c> ), the default is for color matching to always
		/// be performed if it is enabled for the printer's DC. The default color profile for the printer is used when a blit is performed
		/// into the printer's DC using <c>SetDIBitsToDevice</c> or <c>StretchDIBits</c>. If this is not what you want, turn WCS off for the
		/// printer's DC by calling <c>SetICMMode</c> before calling <c>SetDIBitsToDevice</c> or <c>StretchDIBits</c>.
		/// </para>
		/// <para>
		/// Also, when printing to a printer's DC with WCS turned on, the <c>SetICMMode</c> function needs to be called after every call to
		/// the <c>StartPage</c> function to turn back on WCS. The <c>StartPage</c> function calls the <c>RestoreDC</c> and <c>SaveDC</c>
		/// functions, which result in WCS being turned off for the printer's DC.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-seticmmode int SetICMMode( HDC hdc, int mode );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "40d70c1f-c580-43c4-b44b-6c9388e138fb")]
		public static extern int SetICMMode(HDC hdc, ICM mode);

		/// <summary>
		/// The <c>SetICMProfile</c> function sets a specified color profile as the output profile for a specified device context (DC).
		/// </summary>
		/// <param name="hdc">Specifies a device context in which to set the color profile.</param>
		/// <param name="lpFileName">Specifies the path name of the color profile to be set.</param>
		/// <returns>
		/// <para>If this function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If this function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>SetICMProfile</c> associates a color profile with a device context. It becomes the output profile for that device context. The
		/// color profile does not have to be associated with any particular device. Device-independent profiles such as sRGB can also be
		/// used. If the color profile is not associated with a hardware device, it will be returned by GetICMProfile, but not by EnumICMProfiles.
		/// </para>
		/// <para>
		/// Note that under Windows 95 or later, the PostScript device driver for printers assumes a CMYK color model. Therefore, all
		/// PostScript printers must use a CMYK color profile. Windows 2000 does not have this limitation.
		/// </para>
		/// <para><c>SetICMProfile</c> supports only RGB profiles in compatible DCs.</para>
		/// <para>
		/// <c>Windows 95/98/Me:</c><c>SetICMProfileW</c> is supported by the Microsoft Layer for Unicode. To use this, you must add certain
		/// files to your application, as outlined in Microsoft Layer for Unicode on Windows 95/98/Me Systems.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-seticmprofilew BOOL SetICMProfileW( HDC hdc, LPWSTR lpFileName );
		[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wingdi.h", MSDNShortId = "c95f6536-9377-4766-9eb6-004a41bcf6c5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetICMProfile(HDC hdc, string lpFileName);

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

		/// <summary>The <c>CIEXYZ</c> structure contains the x,y, and z coordinates of a specific color in a specified color space.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-ciexyz typedef struct tagCIEXYZ { FXPT2DOT30 ciexyzX;
		// FXPT2DOT30 ciexyzY; FXPT2DOT30 ciexyzZ; } CIEXYZ;
		[PInvokeData("wingdi.h", MSDNShortId = "3735c143-8eb3-4b91-a81e-5bc6bda1dfaa")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CIEXYZ
		{
			/// <summary>The x coordinate in fix point (2.30).</summary>
			public int ciexyzX;

			/// <summary>The y coordinate in fix point (2.30).</summary>
			public int ciexyzY;

			/// <summary>The z coordinate in fix point (2.30).</summary>
			public int ciexyzZ;
		}

		/// <summary>
		/// The <c>CIEXYZTRIPLE</c> structure contains the x,y, and z coordinates of the three colors that correspond to the red, green, and
		/// blue endpoints for a specified logical color space.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-ciexyztriple typedef struct tagICEXYZTRIPLE { CIEXYZ
		// ciexyzRed; CIEXYZ ciexyzGreen; CIEXYZ ciexyzBlue; } CIEXYZTRIPLE;
		[PInvokeData("wingdi.h", MSDNShortId = "cf4473b0-7e54-42d1-a013-2442a540daee")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CIEXYZTRIPLE
		{
			/// <summary>The xyz coordinates of red endpoint.</summary>
			public CIEXYZ ciexyzRed;

			/// <summary>The xyz coordinates of green endpoint.</summary>
			public CIEXYZ ciexyzGreen;

			/// <summary>The xyz coordinates of blue endpoint.</summary>
			public CIEXYZ ciexyzBlue;
		}

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

		/// <summary>The <c>LOGCOLORSPACE</c> structure contains information that defines a logical color space.</summary>
		/// <remarks>
		/// <para>Like palettes, but unlike pens and brushes, a pointer must be passed when creating a LogColorSpace.</para>
		/// <para>
		/// If the <c>lcsCSType</c> member is set to LCS_sRGB or LCS_WINDOWS_COLOR_SPACE, the other members of this structure are ignored,
		/// and WCS uses the sRGB color space. The <c>lcsEndpoints,</c><c>lcsGammaRed, lcsGammaGreen,</c> and <c>lcsGammaBlue</c> members are
		/// used to describe the logical color space. The <c>lcsEndpoints</c> member is a <c>CIEXYZTRIPLE</c> that contains the x, y, and z
		/// values of the color space's RGB endpoint.
		/// </para>
		/// <para>
		/// The required DWORD bit format for the <c>lcsGammaRed</c>, <c>lcsGammaGreen</c>, and <c>lcsGammaBlue</c> is an 8.8 fixed point
		/// interger left-shifted by 8 bits. This means 8 interger bits are followed by 8 fraction bits. Taking the bit shift into account,
		/// the required format of the 32-bit DWORD is:
		/// </para>
		/// <para>00000000nnnnnnnnffffffff00000000</para>
		/// <para>
		/// Whenever the <c>lcsFilename</c> member contains a file name and the <c>lcsCSType</c> member is set to LCS_CALIBRATED_RGB, WCS
		/// ignores the other members of this structure. It uses the color space in the file as the color space to which this
		/// <c>LOGCOLORSPACE</c> structure refers.
		/// </para>
		/// <para>The relation between tri-stimulus values X,Y,Z and chromaticity values x,y,z is as follows:</para>
		/// <para>x = X/(X+Y+Z)</para>
		/// <para>y = Y/(X+Y+Z)</para>
		/// <para>z = Z/(X+Y+Z)</para>
		/// <para>
		/// If the lcsCSType member is set to LCS_sRGB or LCS_WINDOWS_COLOR_SPACE, the other members of this structure are ignored, and ICM
		/// uses the sRGB color space. Appliations should still initialize the rest of the structure since CreateProfileFromLogColorSpace
		/// ignores lcsCSType member and uses lcsEndpoints, lcsGammaRed, lcsGammaGreen, lcsGammaBlue members to create a profile, which may
		/// not be initialized in case of LCS_sRGB or LCS_WINDOWS_COLOR_SPACE color spaces.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-logcolorspacea typedef struct tagLOGCOLORSPACEA { DWORD
		// lcsSignature; DWORD lcsVersion; DWORD lcsSize; LCSCSTYPE lcsCSType; LCSGAMUTMATCH lcsIntent; CIEXYZTRIPLE lcsEndpoints; DWORD
		// lcsGammaRed; DWORD lcsGammaGreen; DWORD lcsGammaBlue; CHAR lcsFilename[MAX_PATH]; } LOGCOLORSPACEA, *LPLOGCOLORSPACEA;
		[PInvokeData("wingdi.h", MSDNShortId = "b08aec07-6ac0-47be-8dc9-d604d94dedde")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LOGCOLORSPACE
		{
			private const uint LCS_SIGNATURE = 0x50534f43;

			/// <summary>Color space signature. At present, this member should always be set to LCS_SIGNATURE.</summary>
			public uint lcsSignature;

			/// <summary>Version number; must be 0x400.</summary>
			public uint lcsVersion;

			/// <summary>Size of this structure, in bytes.</summary>
			public uint lcsSize;

			/// <summary>
			/// <para>Color space type. The member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>LCS_CALIBRATED_RGB</term>
			/// <term>
			/// Color values are calibrated RGB values. The values are translated using the endpoints specified by the lcsEndpoints member
			/// before being passed to the device.
			/// </term>
			/// </item>
			/// <item>
			/// <term>LCS_sRGB</term>
			/// <term>Color values are values are sRGB values.</term>
			/// </item>
			/// <item>
			/// <term>LCS_WINDOWS_COLOR_SPACE</term>
			/// <term>Color values are Windows default color space color values.</term>
			/// </item>
			/// </list>
			/// <para>If LCS_CALIBRATED_RGB is not specified, the <c>lcsEndpoints</c> member is ignored.</para>
			/// </summary>
			public LCSCSTYPE lcsCSType;

			/// <summary>
			/// <para>The gamut mapping method. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Intent</term>
			/// <term>ICC Name</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>LCS_GM_ABS_COLORIMETRIC</term>
			/// <term>Match</term>
			/// <term>Absolute Colorimetric</term>
			/// <term>Maintain the white point. Match the colors to their nearest color in the destination gamut.</term>
			/// </item>
			/// <item>
			/// <term>LCS_GM_BUSINESS</term>
			/// <term>Graphic</term>
			/// <term>Saturation</term>
			/// <term>Maintain saturation. Used for business charts and other situations in which undithered colors are required.</term>
			/// </item>
			/// <item>
			/// <term>LCS_GM_GRAPHICS</term>
			/// <term>Proof</term>
			/// <term>Relative Colorimetric</term>
			/// <term>Maintain colorimetric match. Used for graphic designs and named colors.</term>
			/// </item>
			/// <item>
			/// <term>LCS_GM_IMAGES</term>
			/// <term>Picture</term>
			/// <term>Perceptual</term>
			/// <term>Maintain contrast. Used for photographs and natural images.</term>
			/// </item>
			/// </list>
			/// </summary>
			public LCSGAMUTMATCH lcsIntent;

			/// <summary>Red, green, blue endpoints.</summary>
			public CIEXYZTRIPLE lcsEndpoints;

			/// <summary>Scale of the red coordinate.</summary>
			public uint lcsGammaRed;

			/// <summary>Scale of the green coordinate.</summary>
			public uint lcsGammaGreen;

			/// <summary>Scale of the blue coordinate.</summary>
			public uint lcsGammaBlue;

			/// <summary>
			/// A null-terminated string that names a color profile file. This member is typically set to zero, but may be used to set the
			/// color space to be exactly as specified by the color profile. This is useful for devices that input color values for a
			/// specific printer, or when using an installable image color matcher. If a color profile is specified, all other members of
			/// this structure should be set to reasonable values, even if the values are not completely accurate.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string lcsFilename;

			/// <summary>The default structure with size and default fields preset.</summary>
			public static readonly LOGCOLORSPACE Default = new LOGCOLORSPACE { lcsSignature = LCS_SIGNATURE, lcsVersion = 0x400, lcsSize = (uint)Marshal.SizeOf(typeof(LOGCOLORSPACE)) };
		}

		/// <summary>
		/// The <c>RGBTRIPLE</c> structure describes a color consisting of relative intensities of red, green, and blue. The
		/// <c>bmciColors</c> member of the BITMAPCOREINFO structure consists of an array of <c>RGBTRIPLE</c> structures.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-rgbtriple typedef struct tagRGBTRIPLE { BYTE rgbtBlue; BYTE
		// rgbtGreen; BYTE rgbtRed; } RGBTRIPLE, *PRGBTRIPLE, *NPRGBTRIPLE, *LPRGBTRIPLE;
		[PInvokeData("wingdi.h", MSDNShortId = "bc1467a5-0027-4f22-bfc9-1deab562c573")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RGBTRIPLE
		{
			/// <summary>The intensity of blue in the color.</summary>
			public byte rgbtBlue;

			/// <summary>The intensity of green in the color.</summary>
			public byte rgbtGreen;

			/// <summary>The intensity of red in the color.</summary>
			public byte rgbtRed;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCOLORSPACE"/> that is disposed using <see cref="DeleteColorSpace"/>.</summary>
		public class SafeHCOLORSPACE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHCOLORSPACE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHCOLORSPACE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHCOLORSPACE"/> class.</summary>
			private SafeHCOLORSPACE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHCOLORSPACE"/> to <see cref="HCOLORSPACE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCOLORSPACE(SafeHCOLORSPACE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DeleteColorSpace(handle);
		}
	}
}