using System.Collections.Generic;
using System.Linq;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>
	/// The <c>EnumObjectsProc</c> function is an application-defined callback function used with the EnumObjects function. It is used to
	/// process the object data. The <c>GOBJENUMPROC</c> type defines a pointer to this callback function. <c>EnumObjectsProc</c> is a
	/// placeholder for the application-defined function name.
	/// </summary>
	/// <param name="Arg1"/>
	/// <param name="Arg2"/>
	/// <returns>
	/// To continue enumeration, the callback function must return a nonzero value. This value is user-defined.
	/// <para>To stop enumeration, the callback function must return zero.</para>
	/// </returns>
	/// <remarks>An application must register this function by passing its address to the EnumObjects function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-gobjenumproc GOBJENUMPROC Gobjenumproc; int Gobjenumproc(
	// LPVOID Arg1, LPARAM Arg2 ) {...}
	[PInvokeData("wingdi.h", MSDNShortId = "05a0f329-add9-4e92-9a9a-e2cf0ba5a1c3")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate int EnumObjectsProc(IntPtr Arg1, IntPtr Arg2);

	/// <summary>Values used by the <see cref="GetDeviceCaps"/> function.</summary>
	public enum DeviceCap
	{
		/// <summary>Device driver version</summary>
		DRIVERVERSION = 0,

		/// <summary>Device classification</summary>
		TECHNOLOGY = 2,

		/// <summary>Horizontal size in millimeters</summary>
		HORZSIZE = 4,

		/// <summary>Vertical size in millimeters</summary>
		VERTSIZE = 6,

		/// <summary>Horizontal width in pixels</summary>
		HORZRES = 8,

		/// <summary>Vertical height in pixels</summary>
		VERTRES = 10,

		/// <summary>Number of bits per pixel</summary>
		BITSPIXEL = 12,

		/// <summary>Number of planes</summary>
		PLANES = 14,

		/// <summary>Number of brushes the device has</summary>
		NUMBRUSHES = 16,

		/// <summary>Number of pens the device has</summary>
		NUMPENS = 18,

		/// <summary>Number of markers the device has</summary>
		NUMMARKERS = 20,

		/// <summary>Number of fonts the device has</summary>
		NUMFONTS = 22,

		/// <summary>Number of colors the device supports</summary>
		NUMCOLORS = 24,

		/// <summary>Size required for device descriptor</summary>
		PDEVICESIZE = 26,

		/// <summary>Curve capabilities</summary>
		CURVECAPS = 28,

		/// <summary>Line capabilities</summary>
		LINECAPS = 30,

		/// <summary>Polygonal capabilities</summary>
		POLYGONALCAPS = 32,

		/// <summary>Text capabilities</summary>
		TEXTCAPS = 34,

		/// <summary>Clipping capabilities</summary>
		CLIPCAPS = 36,

		/// <summary>Bitblt capabilities</summary>
		RASTERCAPS = 38,

		/// <summary>Length of the X leg</summary>
		ASPECTX = 40,

		/// <summary>Length of the Y leg</summary>
		ASPECTY = 42,

		/// <summary>Length of the hypotenuse</summary>
		ASPECTXY = 44,

		/// <summary>Shading and Blending caps</summary>
		SHADEBLENDCAPS = 45,

		/// <summary>Logical pixels inch in X</summary>
		LOGPIXELSX = 88,

		/// <summary>Logical pixels inch in Y</summary>
		LOGPIXELSY = 90,

		/// <summary>Number of entries in physical palette</summary>
		SIZEPALETTE = 104,

		/// <summary>Number of reserved entries in palette</summary>
		NUMRESERVED = 106,

		/// <summary>Actual color resolution</summary>
		COLORRES = 108,

		// Printing related DeviceCaps. These replace the appropriate Escapes
		/// <summary>Physical Width in device units</summary>
		PHYSICALWIDTH = 110,

		/// <summary>Physical Height in device units</summary>
		PHYSICALHEIGHT = 111,

		/// <summary>Physical Printable Area x margin</summary>
		PHYSICALOFFSETX = 112,

		/// <summary>Physical Printable Area y margin</summary>
		PHYSICALOFFSETY = 113,

		/// <summary>Scaling factor x</summary>
		SCALINGFACTORX = 114,

		/// <summary>Scaling factor y</summary>
		SCALINGFACTORY = 115,

		/// <summary>Current vertical refresh rate of the display device (for displays only) in Hz</summary>
		VREFRESH = 116,

		/// <summary>Vertical height of entire desktop in pixels</summary>
		DESKTOPVERTRES = 117,

		/// <summary>Horizontal width of entire desktop in pixels</summary>
		DESKTOPHORZRES = 118,

		/// <summary>Preferred blt alignment</summary>
		BLTALIGNMENT = 119
	}

	/// <summary>Object Definitions for EnumObjects</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "2a7b60b2-9a68-4c56-9376-c1b780488535")]
	public enum ObjType
	{
		/// <summary/>
		[CorrespondingType(typeof(LOGPEN))]
		[CorrespondingType(typeof(EXTLOGPEN))]
		OBJ_PEN = 1,

		/// <summary/>
		[CorrespondingType(typeof(LOGBRUSH))]
		OBJ_BRUSH = 2,

		/// <summary/>
		OBJ_DC = 3,

		/// <summary/>
		OBJ_METADC = 4,

		/// <summary/>
		[CorrespondingType(typeof(ushort))]
		OBJ_PAL = 5,

		/// <summary/>
		[CorrespondingType(typeof(LOGFONT))]
		OBJ_FONT = 6,

		/// <summary/>
		[CorrespondingType(typeof(BITMAP))]
		[CorrespondingType(typeof(DIBSECTION))]
		OBJ_BITMAP = 7,

		/// <summary/>
		OBJ_REGION = 8,

		/// <summary/>
		OBJ_METAFILE = 9,

		/// <summary/>
		OBJ_MEMDC = 10,

		/// <summary/>
		OBJ_EXTPEN = 11,

		/// <summary/>
		OBJ_ENHMETADC = 12,

		/// <summary/>
		OBJ_ENHMETAFILE = 13,

		/// <summary/>
		OBJ_COLORSPACE = 14,
	}

	/// <summary>Stock object type.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "b14ddc05-7e7b-4fc6-b7e3-efe892df7e21")]
	public enum StockObjectType
	{
		/// <summary>Windows fixed-pitch (monospace) system font.</summary>
		[CorrespondingType(typeof(HFONT))]
		ANSI_FIXED_FONT = 11,

		/// <summary>Windows variable-pitch (proportional space) system font.</summary>
		[CorrespondingType(typeof(HFONT))]
		ANSI_VAR_FONT = 12,

		/// <summary>Black brush.</summary>
		[CorrespondingType(typeof(HBRUSH))]
		BLACK_BRUSH = 4,

		/// <summary>Black pen.</summary>
		[CorrespondingType(typeof(HPEN))]
		BLACK_PEN = 7,

		/// <summary>
		/// Solid color brush. The default color is white. The color can be changed by using the SetDCBrushColor function. For more
		/// information, see the Remarks section.
		/// </summary>
		[CorrespondingType(typeof(HBRUSH))]
		DC_BRUSH = 18,

		/// <summary>
		/// Solid pen color. The default color is white. The color can be changed by using the SetDCPenColor function. For more
		/// information, see the Remarks section.
		/// </summary>
		[CorrespondingType(typeof(HPEN))]
		DC_PEN = 19,

		/// <summary>
		/// Default font for user interface objects such as menus and dialog boxes. It is not recommended that you use DEFAULT_GUI_FONT
		/// or SYSTEM_FONT to obtain the font used by dialogs and windows; for more information, see the remarks section. The default
		/// font is Tahoma.
		/// </summary>
		[CorrespondingType(typeof(HFONT))]
		DEFAULT_GUI_FONT = 17,

		/// <summary>Default palette. This palette consists of the static colors in the system palette.</summary>
		[CorrespondingType(typeof(HPALETTE))]
		DEFAULT_PALETTE = 15,

		/// <summary>Device-dependent font.</summary>
		[CorrespondingType(typeof(HFONT))]
		DEVICE_DEFAULT_FONT = 14,

		/// <summary>Dark gray brush.</summary>
		[CorrespondingType(typeof(HBRUSH))]
		DKGRAY_BRUSH = 3,

		/// <summary>Gray brush.</summary>
		[CorrespondingType(typeof(HBRUSH))]
		GRAY_BRUSH = 2,

		/// <summary>Hollow brush (equivalent to NULL_BRUSH).</summary>
		[CorrespondingType(typeof(HBRUSH))]
		HOLLOW_BRUSH = NULL_BRUSH,

		/// <summary>Light gray brush.</summary>
		[CorrespondingType(typeof(HBRUSH))]
		LTGRAY_BRUSH = 1,

		/// <summary>Null brush (equivalent to HOLLOW_BRUSH).</summary>
		[CorrespondingType(typeof(HBRUSH))]
		NULL_BRUSH = 5,

		/// <summary>Null pen. The null pen draws nothing.</summary>
		[CorrespondingType(typeof(HPEN))]
		NULL_PEN = 8,

		/// <summary>Original equipment manufacturer (OEM) dependent fixed-pitch (monospace) font.</summary>
		[CorrespondingType(typeof(HFONT))]
		OEM_FIXED_FONT = 10,

		/// <summary>
		/// Fixed-pitch (monospace) system font. This stock object is provided only for compatibility with 16-bit Windows versions
		/// earlier than 3.0.
		/// </summary>
		[CorrespondingType(typeof(HFONT))]
		SYSTEM_FIXED_FONT = 16,

		/// <summary>
		/// System font. By default, the system uses the system font to draw menus, dialog box controls, and text. It is not recommended
		/// that you use DEFAULT_GUI_FONT or SYSTEM_FONT to obtain the font used by dialogs and windows; for more information, see the
		/// remarks section. The default system font is Tahoma.
		/// </summary>
		[CorrespondingType(typeof(HFONT))]
		SYSTEM_FONT = 13,

		/// <summary>White brush.</summary>
		[CorrespondingType(typeof(HBRUSH))]
		WHITE_BRUSH = 0,

		/// <summary>White pen.</summary>
		[CorrespondingType(typeof(HPEN))]
		WHITE_PEN = 6,
	}

	/// <summary>The <c>CancelDC</c> function cancels any pending operation on the specified device context (DC).</summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CancelDC</c> function is used by multithreaded applications to cancel lengthy drawing operations. If thread A initiates a
	/// lengthy drawing operation, thread B may cancel that operation by calling this function.
	/// </para>
	/// <para>
	/// If an operation is canceled, the affected thread returns an error and the result of its drawing operation is undefined. The
	/// results are also undefined if no drawing operation was in progress when the function was called.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-canceldc BOOL CancelDC( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "1dcb3dfe-0ab0-4bf5-ac2f-7a9c11712eef")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CancelDC([In, AddAsMember] HDC hdc);

	/// <summary>The CreateCompatibleDC function creates a memory device context (DC) compatible with the specified device.</summary>
	/// <param name="hDC">
	/// A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is the handle to a memory DC.
	/// <para>If the function fails, the return value is NULL.</para>
	/// </returns>
	/// <remarks>
	/// A memory DC exists only in memory. When the memory DC is created, its display surface is exactly one monochrome pixel wide and
	/// one monochrome pixel high. Before an application can use a memory DC for drawing operations, it must select a bitmap of the
	/// correct width and height into the DC. To select a bitmap into a DC, use the CreateCompatibleBitmap function, specifying the
	/// height, width, and color organization required.
	/// <para>
	/// When a memory DC is created, all attributes are set to normal default values. The memory DC can be used as a normal DC. You can
	/// set the attributes; obtain the current settings of its attributes; and select pens, brushes, and regions.
	/// </para>
	/// <para>
	/// The CreateCompatibleDC function can only be used with devices that support raster operations. An application can determine
	/// whether a device supports these operations by calling the GetDeviceCaps function.
	/// </para>
	/// <para>
	/// When you no longer need the memory DC, call the DeleteDC function. We recommend that you call DeleteDC to delete the DC. However,
	/// you can also call DeleteObject with the HDC to delete the DC.
	/// </para>
	/// <para>
	/// If hdc is NULL, the thread that calls CreateCompatibleDC owns the HDC that is created. When this thread is destroyed, the HDC is
	/// no longer valid. Thus, if you create the HDC and pass it to another thread, then exit the first thread, the second thread will
	/// not be able to use the HDC.
	/// </para>
	/// <para>
	/// ICM: If the DC that is passed to this function is enabled for Image Color Management (ICM), the DC created by the function is
	/// ICM-enabled. The source and destination color spaces are specified in the DC.
	/// </para>
	/// </remarks>
	[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
	[PInvokeData("Wingdi.h", MSDNShortId = "dd183489")]
	[return: AddAsCtor]
	public static extern SafeHDC CreateCompatibleDC([Optional] HDC hDC);

	/// <summary>The <c>CreateDC</c> function creates a device context (DC) for a device using the specified name.</summary>
	/// <param name="pwszDriver">
	/// A pointer to a null-terminated character string that specifies either DISPLAY or the name of a specific display device. For
	/// printing, we recommend that you pass <c>NULL</c> to lpszDriver because GDI ignores lpszDriver for printer devices.
	/// </param>
	/// <param name="pwszDevice">
	/// <para>
	/// A pointer to a null-terminated character string that specifies the name of the specific output device being used, as shown by the
	/// Print Manager (for example, Epson FX-80). It is not the printer model name. The lpszDevice parameter must be used.
	/// </para>
	/// <para>To obtain valid names for displays, call EnumDisplayDevices.</para>
	/// <para>
	/// If lpszDriver is DISPLAY or the device name of a specific display device, then lpszDevice must be <c>NULL</c> or that same device
	/// name. If lpszDevice is <c>NULL</c>, then a DC is created for the primary display device.
	/// </para>
	/// <para>If there are multiple monitors on the system, calling will create a DC covering all the monitors.</para>
	/// </param>
	/// <param name="pszPort">
	/// This parameter is ignored and should be set to <c>NULL</c>. It is provided only for compatibility with 16-bit Windows.
	/// </param>
	/// <param name="pdm">
	/// <para>
	/// A pointer to a DEVMODE structure containing device-specific initialization data for the device driver. The DocumentProperties
	/// function retrieves this structure filled in for a specified device. The pdm parameter must be <c>NULL</c> if the device driver is
	/// to use the default initialization (if any) specified by the user.
	/// </para>
	/// <para>If lpszDriver is DISPLAY, pdm must be <c>NULL</c>; GDI then uses the display device's current DEVMODE.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the handle to a DC for the specified device.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note that the handle to the DC can only be used by a single thread at any one time.</para>
	/// <para>For parameters lpszDriver and lpszDevice, call EnumDisplayDevices to obtain valid names for displays.</para>
	/// <para>When you no longer need the DC, call the DeleteDC function.</para>
	/// <para>
	/// If lpszDriver or lpszDevice is DISPLAY, the thread that calls <c>CreateDC</c> owns the <c>HDC</c> that is created. When this
	/// thread is destroyed, the <c>HDC</c> is no longer valid. Thus, if you create the <c>HDC</c> and pass it to another thread, then
	/// exit the first thread, the second thread will not be able to use the <c>HDC</c>.
	/// </para>
	/// <para>
	/// When you call <c>CreateDC</c> to create the <c>HDC</c> for a display device, you must pass to pdm either <c>NULL</c> or a pointer
	/// to DEVMODE that matches the current <c>DEVMODE</c> of the display device that lpszDevice specifies. We recommend to pass
	/// <c>NULL</c> and not to try to exactly match the <c>DEVMODE</c> for the current display device.
	/// </para>
	/// <para>
	/// When you call <c>CreateDC</c> to create the <c>HDC</c> for a printer device, the printer driver validates the DEVMODE. If the
	/// printer driver determines that the <c>DEVMODE</c> is invalid (that is, printer driver can’t convert or consume the DEVMODE), the
	/// printer driver provides a default <c>DEVMODE</c> to create the HDC for the printer device.
	/// </para>
	/// <para>
	/// <c>ICM:</c> To enable ICM, set the <c>dmICMMethod</c> member of the DEVMODE structure (pointed to by the pInitData parameter) to
	/// the appropriate value.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Capturing an Image.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdca HDC CreateDCA( LPCSTR pwszDriver, LPCSTR pwszDevice,
	// LPCSTR pszPort, const DEVMODEA *pdm );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "6fc443c8-da97-4196-a9ed-179a4e583849")]
	[return: AddAsCtor]
	public static extern SafeHDC CreateDC([Optional] string? pwszDriver, [Optional] string? pwszDevice, [Optional] string? pszPort, ref DEVMODE pdm);

	/// <summary>The <c>CreateDC</c> function creates a device context (DC) for a device using the specified name.</summary>
	/// <param name="pwszDriver">
	/// A pointer to a null-terminated character string that specifies either DISPLAY or the name of a specific display device. For
	/// printing, we recommend that you pass <c>NULL</c> to lpszDriver because GDI ignores lpszDriver for printer devices.
	/// </param>
	/// <param name="pwszDevice">
	/// <para>
	/// A pointer to a null-terminated character string that specifies the name of the specific output device being used, as shown by the
	/// Print Manager (for example, Epson FX-80). It is not the printer model name. The lpszDevice parameter must be used.
	/// </para>
	/// <para>To obtain valid names for displays, call EnumDisplayDevices.</para>
	/// <para>
	/// If lpszDriver is DISPLAY or the device name of a specific display device, then lpszDevice must be <c>NULL</c> or that same device
	/// name. If lpszDevice is <c>NULL</c>, then a DC is created for the primary display device.
	/// </para>
	/// <para>If there are multiple monitors on the system, calling will create a DC covering all the monitors.</para>
	/// </param>
	/// <param name="pszPort">
	/// This parameter is ignored and should be set to <c>NULL</c>. It is provided only for compatibility with 16-bit Windows.
	/// </param>
	/// <param name="pdm">
	/// <para>
	/// A pointer to a DEVMODE structure containing device-specific initialization data for the device driver. The DocumentProperties
	/// function retrieves this structure filled in for a specified device. The pdm parameter must be <c>NULL</c> if the device driver is
	/// to use the default initialization (if any) specified by the user.
	/// </para>
	/// <para>If lpszDriver is DISPLAY, pdm must be <c>NULL</c>; GDI then uses the display device's current DEVMODE.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the handle to a DC for the specified device.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note that the handle to the DC can only be used by a single thread at any one time.</para>
	/// <para>For parameters lpszDriver and lpszDevice, call EnumDisplayDevices to obtain valid names for displays.</para>
	/// <para>When you no longer need the DC, call the DeleteDC function.</para>
	/// <para>
	/// If lpszDriver or lpszDevice is DISPLAY, the thread that calls <c>CreateDC</c> owns the <c>HDC</c> that is created. When this
	/// thread is destroyed, the <c>HDC</c> is no longer valid. Thus, if you create the <c>HDC</c> and pass it to another thread, then
	/// exit the first thread, the second thread will not be able to use the <c>HDC</c>.
	/// </para>
	/// <para>
	/// When you call <c>CreateDC</c> to create the <c>HDC</c> for a display device, you must pass to pdm either <c>NULL</c> or a pointer
	/// to DEVMODE that matches the current <c>DEVMODE</c> of the display device that lpszDevice specifies. We recommend to pass
	/// <c>NULL</c> and not to try to exactly match the <c>DEVMODE</c> for the current display device.
	/// </para>
	/// <para>
	/// When you call <c>CreateDC</c> to create the <c>HDC</c> for a printer device, the printer driver validates the DEVMODE. If the
	/// printer driver determines that the <c>DEVMODE</c> is invalid (that is, printer driver can’t convert or consume the DEVMODE), the
	/// printer driver provides a default <c>DEVMODE</c> to create the HDC for the printer device.
	/// </para>
	/// <para>
	/// <c>ICM:</c> To enable ICM, set the <c>dmICMMethod</c> member of the DEVMODE structure (pointed to by the pInitData parameter) to
	/// the appropriate value.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Capturing an Image.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdca HDC CreateDCA( LPCSTR pwszDriver, LPCSTR pwszDevice,
	// LPCSTR pszPort, const DEVMODEA *pdm );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "6fc443c8-da97-4196-a9ed-179a4e583849")]
	[return: AddAsCtor]
	public static extern SafeHDC CreateDC([Optional] string? pwszDriver, [Optional] string? pwszDevice, [Optional] string? pszPort, [Optional, Ignore] IntPtr pdm);

	/// <summary>
	/// The <c>CreateIC</c> function creates an information context for the specified device. The information context provides a fast way
	/// to get information about the device without creating a device context (DC). However, GDI drawing functions cannot accept a handle
	/// to an information context.
	/// </summary>
	/// <param name="pszDriver">
	/// A pointer to a null-terminated character string that specifies the name of the device driver (for example, Epson).
	/// </param>
	/// <param name="pszDevice">
	/// A pointer to a null-terminated character string that specifies the name of the specific output device being used, as shown by the
	/// Print Manager (for example, Epson FX-80). It is not the printer model name. The lpszDevice parameter must be used.
	/// </param>
	/// <param name="pszPort">
	/// This parameter is ignored and should be set to <c>NULL</c>. It is provided only for compatibility with 16-bit Windows.
	/// </param>
	/// <param name="pdm">
	/// A pointer to a DEVMODE structure containing device-specific initialization data for the device driver. The DocumentProperties
	/// function retrieves this structure filled in for a specified device. The lpdvmInit parameter must be <c>NULL</c> if the device
	/// driver is to use the default initialization (if any) specified by the user.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the handle to an information context.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>When you no longer need the information DC, call the DeleteDC function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createica HDC CreateICA( LPCSTR pszDriver, LPCSTR pszDevice,
	// LPCSTR pszPort, const DEVMODEA *pdm );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "dcb08ce7-9ded-497c-936c-48d3026a0004")]
	[return: AddAsCtor]
	public static extern SafeHDC CreateIC([Optional] string? pszDriver, [Optional] string? pszDevice, [Optional] string? pszPort, ref DEVMODE pdm);

	/// <summary>
	/// The <c>CreateIC</c> function creates an information context for the specified device. The information context provides a fast way
	/// to get information about the device without creating a device context (DC). However, GDI drawing functions cannot accept a handle
	/// to an information context.
	/// </summary>
	/// <param name="pszDriver">
	/// A pointer to a null-terminated character string that specifies the name of the device driver (for example, Epson).
	/// </param>
	/// <param name="pszDevice">
	/// A pointer to a null-terminated character string that specifies the name of the specific output device being used, as shown by the
	/// Print Manager (for example, Epson FX-80). It is not the printer model name. The lpszDevice parameter must be used.
	/// </param>
	/// <param name="pszPort">
	/// This parameter is ignored and should be set to <c>NULL</c>. It is provided only for compatibility with 16-bit Windows.
	/// </param>
	/// <param name="pdm">
	/// A pointer to a DEVMODE structure containing device-specific initialization data for the device driver. The DocumentProperties
	/// function retrieves this structure filled in for a specified device. The lpdvmInit parameter must be <c>NULL</c> if the device
	/// driver is to use the default initialization (if any) specified by the user.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the handle to an information context.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>When you no longer need the information DC, call the DeleteDC function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createica HDC CreateICA( LPCSTR pszDriver, LPCSTR pszDevice,
	// LPCSTR pszPort, const DEVMODEA *pdm );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "dcb08ce7-9ded-497c-936c-48d3026a0004")]
	[return: AddAsCtor]
	public static extern SafeHDC CreateIC([Optional] string? pszDriver, [Optional] string? pszDevice, [Optional] string? pszPort, [Optional, Ignore] IntPtr pdm);

	/// <summary>The DeleteDC function deletes the specified device context (DC).</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
	/// <remarks>
	/// An application must not delete a DC whose handle was obtained by calling the GetDC function. Instead, it must call the ReleaseDC
	/// function to free the DC.
	/// </remarks>
	[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[System.Security.SecurityCritical]
	[PInvokeData("Wingdi.h", MSDNShortId = "dd183533")]
	public static extern bool DeleteDC(HDC hdc);

	/// <summary>
	/// The DeleteObject function deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated
	/// with the object. After the object is deleted, the specified handle is no longer valid.
	/// </summary>
	/// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently selected into a DC,
	/// the return value is zero.
	/// </returns>
	/// <remarks>
	/// Do not delete a drawing object (pen or brush) while it is still selected into a DC.
	/// <para>When a pattern brush is deleted, the bitmap associated with the brush is not deleted. The bitmap must be deleted independently.</para>
	/// </remarks>
	[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("Wingdi.h", MSDNShortId = "dd183539")]
	public static extern bool DeleteObject(HGDIOBJ hObject);

	// TODO: DeviceCapabilities from winspool.drv ??

	/// <summary>
	/// The <c>DrawEscape</c> function provides drawing capabilities of the specified video display that are not directly available
	/// through the graphics device interface (GDI).
	/// </summary>
	/// <param name="hdc">A handle to the DC for the specified video display.</param>
	/// <param name="iEscape">The escape function to be performed.</param>
	/// <param name="cjIn">The number of bytes of data pointed to by the lpszInData parameter.</param>
	/// <param name="lpIn">A pointer to the input structure required for the specified escape.</param>
	/// <returns>
	/// <para>
	/// If the function is successful, the return value is greater than zero except for the QUERYESCSUPPORT draw escape, which checks for
	/// implementation only.
	/// </para>
	/// <para>If the escape is not implemented, the return value is zero.</para>
	/// <para>If an error occurred, the return value is less than zero.</para>
	/// </returns>
	/// <remarks>
	/// When an application calls the <c>DrawEscape</c> function, the data identified by cbInput and lpszInData is passed directly to the
	/// specified display driver.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-drawescape int DrawEscape( HDC hdc, int iEscape, int cjIn,
	// LPCSTR lpIn );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "306eec06-6d29-43bc-aff0-a267efa52ccd")]
	public static extern int DrawEscape([In, AddAsMember] HDC hdc, EscapeFunction iEscape, int cjIn, [MarshalAs(UnmanagedType.LPStr)] string lpIn);

	/// <summary>
	/// The <c>EnumObjects</c> function enumerates the pens or brushes available for the specified device context (DC). This function
	/// calls the application-defined callback function once for each available object, supplying data describing that object.
	/// <c>EnumObjects</c> continues calling the callback function until the callback function returns zero or until all of the objects
	/// have been enumerated.
	/// </summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="nType">The object type. This parameter can be OBJ_BRUSH or OBJ_PEN.</param>
	/// <param name="lpFunc">
	/// A pointer to the application-defined callback function. For more information about the callback function, see the EnumObjectsProc function.
	/// </param>
	/// <param name="lParam">
	/// A pointer to the application-defined data. The data is passed to the callback function along with the object information.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the last value returned by the callback function. Its meaning is user-defined.</para>
	/// <para>
	/// If the objects cannot be enumerated (for example, there are too many objects), the function returns zero without calling the
	/// callback function.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumobjects int EnumObjects( HDC hdc, int nType, GOBJENUMPROC
	// lpFunc, LPARAM lParam );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2a7b60b2-9a68-4c56-9376-c1b780488535")]
	public static extern int EnumObjects(HDC hdc, ObjType nType, EnumObjectsProc lpFunc, [Optional] IntPtr lParam);

	/// <summary>
	/// The <c>EnumObjects</c> function enumerates the pens or brushes available for the specified device context (DC).
	/// </summary>
	/// <typeparam name="T">The type of the object to enumerate. Currently, only <see cref="LOGBRUSH"/> and <see cref="LOGPEN"/> are supported.</typeparam>
	/// <param name="hdc">A handle to the DC.</param>
	/// <returns>An enumeration of the object handles for the <paramref name="hdc"/>.</returns>
	/// <exception cref="ArgumentException">The supplied type cannot be enumerated by this function.</exception>
	[PInvokeData("wingdi.h", MSDNShortId = "2a7b60b2-9a68-4c56-9376-c1b780488535")]
	public static IEnumerable<T> EnumObjects<T>([In, AddAsMember] HDC hdc) where T : struct
	{
		ObjType ev = typeof(T) switch
		{
			var t when t == typeof(LOGBRUSH) => ObjType.OBJ_BRUSH,
			var t when t == typeof(LOGPEN) => ObjType.OBJ_PEN,
			_ => 0
		};
		if (ev == 0)
			throw new ArgumentException($"The supplied type cannot be enumerated by this function.");
		List<T> l = [];
		_ = EnumObjects(hdc, ev, (a1, _) => { l.Add(a1.ToStructure<T>()); return 1; });
		return l;
	}

	/// <summary>
	/// The <c>GetCurrentObject</c> function retrieves a handle to an object of the specified type that has been selected into the
	/// specified device context (DC).
	/// </summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="type">
	/// <para>The object type to be queried. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OBJ_BITMAP</term>
	/// <term>Returns the current selected bitmap.</term>
	/// </item>
	/// <item>
	/// <term>OBJ_BRUSH</term>
	/// <term>Returns the current selected brush.</term>
	/// </item>
	/// <item>
	/// <term>OBJ_COLORSPACE</term>
	/// <term>Returns the current color space.</term>
	/// </item>
	/// <item>
	/// <term>OBJ_FONT</term>
	/// <term>Returns the current selected font.</term>
	/// </item>
	/// <item>
	/// <term>OBJ_PAL</term>
	/// <term>Returns the current selected palette.</term>
	/// </item>
	/// <item>
	/// <term>OBJ_PEN</term>
	/// <term>Returns the current selected pen.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the specified object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can use the <c>GetCurrentObject</c> and GetObject functions to retrieve descriptions of the graphic objects
	/// currently selected into the specified DC.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving Graphic-Object Attributes and Selecting New Graphic Objects.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcurrentobject HGDIOBJ GetCurrentObject( HDC hdc, UINT type );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d7e2310c-6a9e-4195-824c-1a83382a5c5b")]
	public static extern HGDIOBJ GetCurrentObject([In, AddAsMember] HDC hdc, ObjType type);

	/// <summary>The <c>GetDCBrushColor</c> function retrieves the current brush color for the specified device context (DC).</summary>
	/// <param name="hdc">A handle to the DC whose brush color is to be returned.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the COLORREF value for the current DC brush color.</para>
	/// <para>If the function fails, the return value is CLR_INVALID.</para>
	/// </returns>
	/// <remarks>
	/// <para>For information on setting the brush color, see SetDCBrushColor.</para>
	/// <para><c>ICM:</c> Color management is performed if ICM is enabled.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdcbrushcolor COLORREF GetDCBrushColor( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "98844fb1-7ad8-4fbd-be59-9a19065253da")]
	public static extern COLORREF GetDCBrushColor([In, AddAsMember] HDC hdc);

	/// <summary>
	/// The <c>GetDCOrgEx</c> function retrieves the final translation origin for a specified device context (DC). The final translation
	/// origin specifies an offset that the system uses to translate device coordinates into client coordinates (for coordinates in an
	/// application's window).
	/// </summary>
	/// <param name="hdc">A handle to the DC whose final translation origin is to be retrieved.</param>
	/// <param name="lppt">A pointer to a POINT structure that receives the final translation origin, in device coordinates.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>The final translation origin is relative to the physical origin of the screen.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdcorgex BOOL GetDCOrgEx( HDC hdc, LPPOINT lppt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "795c6a69-7146-4d1a-abf9-ce1d740ca946")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetDCOrgEx([In, AddAsMember] HDC hdc, out POINT lppt);

	/// <summary>The <c>GetDCPenColor</c> function retrieves the current pen color for the specified device context (DC).</summary>
	/// <param name="hdc">A handle to the DC whose brush color is to be returned.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a COLORREF value for the current DC pen color.</para>
	/// <para>If the function fails, the return value is CLR_INVALID.</para>
	/// </returns>
	/// <remarks>
	/// <para>For information on setting the pen color, see SetDCPenColor.</para>
	/// <para><c>ICM:</c> Color management is performed if ICM is enabled.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdcpencolor COLORREF GetDCPenColor( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3a1d579f-fbc6-4021-a37e-0184b2cc7d5d")]
	public static extern COLORREF GetDCPenColor([In, AddAsMember] HDC hdc);

	/// <summary>The GetDeviceCaps function retrieves device-specific information for the specified device.</summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="index">The item to be returned.</param>
	/// <returns>
	/// The return value specifies the value of the desired item. When nIndex is BITSPIXEL and the device has 15bpp or 16bpp, the return
	/// value is 16.
	/// </returns>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/dd144877(v=vs.85).aspx
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Wingdi.h", MSDNShortId = "dd144877")]
	public static extern int GetDeviceCaps([In, AddAsMember] HDC hdc, DeviceCap index);

	/// <summary>The <c>GetLayout</c> function returns the layout of a device context (DC).</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns the layout flags for the current device context.</para>
	/// <para>If the function fails, it returns GDI_ERROR. For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// The layout specifies the order in which text and graphics are revealed in a window or device context. The default is left to
	/// right. The <c>GetLayout</c> function tells you if the default has been changed through a call to SetLayout. For more information,
	/// see "Window Layout and Mirroring" in Window Features.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getlayout DWORD GetLayout( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2bbc0bef-55e5-4f11-a195-d379e95e44bf")]
	public static extern DCLayout GetLayout([In, AddAsMember] HDC hdc);

	/// <summary>The GetObject function retrieves information for the specified graphics object.</summary>
	/// <param name="hgdiobj">
	/// A handle to the graphics object of interest. This can be a handle to one of the following: a logical bitmap, a brush, a font, a
	/// palette, a pen, or a device independent bitmap created by calling the CreateDIBSection function.
	/// </param>
	/// <param name="cbBuffer">The number of bytes of information to be written to the buffer.</param>
	/// <param name="lpvObject">
	/// A pointer to a buffer that receives the information about the specified graphics object. If the <paramref name="lpvObject"/>
	/// parameter is NULL, the function return value is the number of bytes required to store the information it writes to the buffer for
	/// the specified graphics object.
	/// </param>
	/// <returns>
	/// If the function succeeds, and <paramref name="lpvObject"/> is a valid pointer, the return value is the number of bytes stored
	/// into the buffer.
	/// <para>
	/// If the function succeeds, and <paramref name="lpvObject"/> is NULL, the return value is the number of bytes required to hold the
	/// information the function would store into the buffer.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The buffer pointed to by the <paramref name="lpvObject"/> parameter must be sufficiently large to receive the information about
	/// the graphics object. Depending on the graphics object, the function uses a BITMAP, DIBSECTION, EXTLOGPEN, LOGBRUSH, LOGFONT, or
	/// LOGPEN structure, or a count of table entries (for a logical palette).
	/// <para>
	/// If <paramref name="hgdiobj"/> is a handle to a bitmap created by calling CreateDIBSection, and the specified buffer is large
	/// enough, the GetObject function returns a DIBSECTION structure. In addition, the bmBits member of the BITMAP structure contained
	/// within the DIBSECTION will contain a pointer to the bitmap's bit values.
	/// </para>
	/// <para>
	/// If <paramref name="hgdiobj"/> is a handle to a bitmap created by any other means, GetObject returns only the width, height, and
	/// color format information of the bitmap. You can obtain the bitmap's bit values by calling the GetDIBits or GetBitmapBits function.
	/// </para>
	/// <para>
	/// If <paramref name="hgdiobj"/> is a handle to a logical palette, GetObject retrieves a 2-byte integer that specifies the number of
	/// entries in the palette. The function does not retrieve the LOGPALETTE structure defining the palette. To retrieve information
	/// about palette entries, an application can call the GetPaletteEntries function.
	/// </para>
	/// <para>
	/// If <paramref name="hgdiobj"/> is a handle to a font, the LOGFONT that is returned is the LOGFONT used to create the font. If
	/// Windows had to make some interpolation of the font because the precise LOGFONT could not be represented, the interpolation will
	/// not be reflected in the LOGFONT. For example, if you ask for a vertical version of a font that doesn't support vertical painting,
	/// the LOGFONT indicates the font is vertical, but Windows will paint it horizontally.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getobject
	// int GetObject( HANDLE h, int c, LPVOID pv );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "555ab876-d990-426d-915c-f98df82a10aa")]
	public static extern int GetObject([In] HGDIOBJ hgdiobj, int cbBuffer, IntPtr lpvObject);

	/// <summary>The GetObject function retrieves information for the specified graphics object.</summary>
	/// <typeparam name="T">The output structure type.</typeparam>
	/// <param name="hgdiobj">
	/// A handle to the graphics object of interest. This can be a handle to one of the following: a logical bitmap, a brush, a font, a
	/// palette, a pen, or a device independent bitmap created by calling the CreateDIBSection function.
	/// </param>
	/// <returns>The output structure holding the information for the graphics object.</returns>
	[PInvokeData("Wingdi.h", MSDNShortId = "dd144904")]
	public static T GetObject<T>(IGraphicsObjectHandle hgdiobj) where T : struct
	{
		var ot = GetObjectType(hgdiobj.DangerousGetHandle());
		if (CorrespondingTypeAttribute.CanGet<T, ObjType>(out var otl) && otl == ot)
		{
			using var ptr = GetObject(hgdiobj, Marshal.SizeOf<T>());
			return ot switch
			{
				ObjType.OBJ_BITMAP when typeof(T) == typeof(BITMAP) && ptr.Size >= Marshal.SizeOf<BITMAP>() => ptr.ToStructure<T>(),
				ObjType.OBJ_BITMAP when typeof(T) == typeof(DIBSECTION) && ptr.Size == Marshal.SizeOf<DIBSECTION>() => ptr.ToStructure<T>(),
				_ => ptr.ToStructure<T>(),
			};
		}
		throw new ArgumentException($"The specified type ({typeof(T).Name}) cannot be retrieved from an object of type {ot}.");
	}

	/// <summary>The GetObject function retrieves information for the specified graphics object.</summary>
	/// <param name="hgdiobj">
	/// A handle to the graphics object of interest. This can be a handle to one of the following: a logical bitmap, a brush, a font, a
	/// palette, a pen, or a device independent bitmap created by calling the CreateDIBSection function.
	/// </param>
	/// <param name="bufferSize">Size of the buffer. If this value is 0, then the size is requested.</param>
	/// <returns>Allocated memory holding the information for the graphics object.</returns>
	[PInvokeData("Wingdi.h", MSDNShortId = "dd144904")]
	public static ISafeMemoryHandle GetObject(IGraphicsObjectHandle hgdiobj, int bufferSize = 0)
	{
		if (bufferSize == 0)
		{
			bufferSize = GetObject(hgdiobj.DangerousGetHandle(), 0, IntPtr.Zero);
			if (bufferSize == 0) Win32Error.ThrowLastError();
		}
		var ptr = new SafeHGlobalHandle(bufferSize);
		var sz = GetObject(hgdiobj.DangerousGetHandle(), ptr.Size, ptr);
		if (sz == 0) Win32Error.ThrowLastError();
		ptr.Size = sz;
		return ptr;
	}

	/// <summary>The <c>GetObjectType</c> retrieves the type of the specified object.</summary>
	/// <param name="h">A handle to the graphics object.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value identifies the object. This value can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OBJ_BITMAP</term>
	/// <term>Bitmap</term>
	/// </item>
	/// <item>
	/// <term>OBJ_BRUSH</term>
	/// <term>Brush</term>
	/// </item>
	/// <item>
	/// <term>OBJ_COLORSPACE</term>
	/// <term>Color space</term>
	/// </item>
	/// <item>
	/// <term>OBJ_DC</term>
	/// <term>Device context</term>
	/// </item>
	/// <item>
	/// <term>OBJ_ENHMETADC</term>
	/// <term>Enhanced metafile DC</term>
	/// </item>
	/// <item>
	/// <term>OBJ_ENHMETAFILE</term>
	/// <term>Enhanced metafile</term>
	/// </item>
	/// <item>
	/// <term>OBJ_EXTPEN</term>
	/// <term>Extended pen</term>
	/// </item>
	/// <item>
	/// <term>OBJ_FONT</term>
	/// <term>Font</term>
	/// </item>
	/// <item>
	/// <term>OBJ_MEMDC</term>
	/// <term>Memory DC</term>
	/// </item>
	/// <item>
	/// <term>OBJ_METAFILE</term>
	/// <term>Metafile</term>
	/// </item>
	/// <item>
	/// <term>OBJ_METADC</term>
	/// <term>Metafile DC</term>
	/// </item>
	/// <item>
	/// <term>OBJ_PAL</term>
	/// <term>Palette</term>
	/// </item>
	/// <item>
	/// <term>OBJ_PEN</term>
	/// <term>Pen</term>
	/// </item>
	/// <item>
	/// <term>OBJ_REGION</term>
	/// <term>Region</term>
	/// </item>
	/// </list>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getobjecttype DWORD GetObjectType( HGDIOBJ h );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "334a2c95-3bf4-44dc-abce-df3a3a2d37a8")]
	public static extern ObjType GetObjectType([In, AddAsMember] HGDIOBJ h);

	/// <summary>The <c>GetStockObject</c> function retrieves a handle to one of the stock pens, brushes, fonts, or palettes.</summary>
	/// <param name="i">
	/// <para>The type of stock object. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BLACK_BRUSH</term>
	/// <term>Black brush.</term>
	/// </item>
	/// <item>
	/// <term>DKGRAY_BRUSH</term>
	/// <term>Dark gray brush.</term>
	/// </item>
	/// <item>
	/// <term>DC_BRUSH</term>
	/// <term>
	/// Solid color brush. The default color is white. The color can be changed by using the SetDCBrushColor function. For more
	/// information, see the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GRAY_BRUSH</term>
	/// <term>Gray brush.</term>
	/// </item>
	/// <item>
	/// <term>HOLLOW_BRUSH</term>
	/// <term>Hollow brush (equivalent to NULL_BRUSH).</term>
	/// </item>
	/// <item>
	/// <term>LTGRAY_BRUSH</term>
	/// <term>Light gray brush.</term>
	/// </item>
	/// <item>
	/// <term>NULL_BRUSH</term>
	/// <term>Null brush (equivalent to HOLLOW_BRUSH).</term>
	/// </item>
	/// <item>
	/// <term>WHITE_BRUSH</term>
	/// <term>White brush.</term>
	/// </item>
	/// <item>
	/// <term>BLACK_PEN</term>
	/// <term>Black pen.</term>
	/// </item>
	/// <item>
	/// <term>DC_PEN</term>
	/// <term>
	/// Solid pen color. The default color is white. The color can be changed by using the SetDCPenColor function. For more information,
	/// see the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NULL_PEN</term>
	/// <term>Null pen. The null pen draws nothing.</term>
	/// </item>
	/// <item>
	/// <term>WHITE_PEN</term>
	/// <term>White pen.</term>
	/// </item>
	/// <item>
	/// <term>ANSI_FIXED_FONT</term>
	/// <term>Windows fixed-pitch (monospace) system font.</term>
	/// </item>
	/// <item>
	/// <term>ANSI_VAR_FONT</term>
	/// <term>Windows variable-pitch (proportional space) system font.</term>
	/// </item>
	/// <item>
	/// <term>DEVICE_DEFAULT_FONT</term>
	/// <term>Device-dependent font.</term>
	/// </item>
	/// <item>
	/// <term>DEFAULT_GUI_FONT</term>
	/// <term>
	/// Default font for user interface objects such as menus and dialog boxes. It is not recommended that you use DEFAULT_GUI_FONT or
	/// SYSTEM_FONT to obtain the font used by dialogs and windows; for more information, see the remarks section. The default font is Tahoma.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OEM_FIXED_FONT</term>
	/// <term>Original equipment manufacturer (OEM) dependent fixed-pitch (monospace) font.</term>
	/// </item>
	/// <item>
	/// <term>SYSTEM_FONT</term>
	/// <term>
	/// System font. By default, the system uses the system font to draw menus, dialog box controls, and text. It is not recommended that
	/// you use DEFAULT_GUI_FONT or SYSTEM_FONT to obtain the font used by dialogs and windows; for more information, see the remarks
	/// section. The default system font is Tahoma.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SYSTEM_FIXED_FONT</term>
	/// <term>
	/// Fixed-pitch (monospace) system font. This stock object is provided only for compatibility with 16-bit Windows versions earlier
	/// than 3.0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DEFAULT_PALETTE</term>
	/// <term>Default palette. This palette consists of the static colors in the system palette.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the requested logical object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// It is not recommended that you employ this method to obtain the current font used by dialogs and windows. Instead, use the
	/// SystemParametersInfo function with the SPI_GETNONCLIENTMETRICS parameter to retrieve the current font. SystemParametersInfo will
	/// take into account the current theme and provides font information for captions, menus, and message dialogs.
	/// </para>
	/// <para>
	/// Use the DKGRAY_BRUSH, GRAY_BRUSH, and LTGRAY_BRUSH stock objects only in windows with the CS_HREDRAW and CS_VREDRAW styles. Using
	/// a gray stock brush in any other style of window can lead to misalignment of brush patterns after a window is moved or sized. The
	/// origins of stock brushes cannot be adjusted.
	/// </para>
	/// <para>The HOLLOW_BRUSH and NULL_BRUSH stock objects are equivalent.</para>
	/// <para>It is not necessary (but it is not harmful) to delete stock objects by calling DeleteObject.</para>
	/// <para>
	/// Both DC_BRUSH and DC_PEN can be used interchangeably with other stock objects like BLACK_BRUSH and BLACK_PEN. For information on
	/// retrieving the current pen or brush color, see GetDCBrushColor and GetDCPenColor. See Setting the Pen or Brush Color for an
	/// example of setting colors. The <c>GetStockObject</c> function with an argument of DC_BRUSH or DC_PEN can be used interchangeably
	/// with the SetDCPenColor and SetDCBrushColor functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Setting the Pen or Brush Color.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getstockobject HGDIOBJ GetStockObject( int i );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b14ddc05-7e7b-4fc6-b7e3-efe892df7e21")]
	public static extern HGDIOBJ GetStockObject(StockObjectType i);

	/// <summary>The <c>ResetDC</c> function updates the specified printer or plotter device context (DC) using the specified information.</summary>
	/// <param name="hdc">A handle to the DC to update.</param>
	/// <param name="lpdm">A pointer to a DEVMODE structure containing information about the new DC.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the original DC.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application will typically use the <c>ResetDC</c> function when a window receives a WM_DEVMODECHANGE message. <c>ResetDC</c>
	/// can also be used to change the paper orientation or paper bins while printing a document.
	/// </para>
	/// <para>
	/// The <c>ResetDC</c> function cannot be used to change the driver name, device name, or the output port. When the user changes the
	/// port connection or device name, the application must delete the original DC and create a new DC with the new information.
	/// </para>
	/// <para>
	/// An application can pass an information DC to the <c>ResetDC</c> function. In that situation, <c>ResetDC</c> will always return a
	/// printer DC.
	/// </para>
	/// <para>
	/// <c>ICM:</c> The color profile of the DC specified by the hdc parameter will be reset based on the information contained in the
	/// <c>lpInitData</c> member of the DEVMODE structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-resetdca HDC ResetDCA( HDC hdc, const DEVMODEA *lpdm );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "3f77db51-90d1-4a87-812b-1e129ae8fde9")]
	public static extern HDC ResetDC([In, AddAsMember] HDC hdc, ref DEVMODE lpdm);

	/// <summary>
	/// The <c>RestoreDC</c> function restores a device context (DC) to the specified state. The DC is restored by popping state
	/// information off a stack created by earlier calls to the SaveDC function.
	/// </summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="nSavedDC">
	/// The saved state to be restored. If this parameter is positive, nSavedDC represents a specific instance of the state to be
	/// restored. If this parameter is negative, nSavedDC represents an instance relative to the current state. For example, -1 restores
	/// the most recently saved state.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// Each DC maintains a stack of saved states. The SaveDC function pushes the current state of the DC onto its stack of saved states.
	/// That state can be restored only to the same DC from which it was created. After a state is restored, the saved state is destroyed
	/// and cannot be reused. Furthermore, any states saved after the restored state was created are also destroyed and cannot be used.
	/// In other words, the <c>RestoreDC</c> function pops the restored state (and any subsequent states) from the state information stack.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-restoredc BOOL RestoreDC( HDC hdc, int nSavedDC );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "7043edbb-b3ea-4946-a2ba-cae356b04d1d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RestoreDC([In, AddAsMember] HDC hdc, int nSavedDC);

	/// <summary>
	/// The <c>SaveDC</c> function saves the current state of the specified device context (DC) by copying data describing selected
	/// objects and graphic modes (such as the bitmap, brush, palette, font, pen, region, drawing mode, and mapping mode) to a context stack.
	/// </summary>
	/// <param name="hdc">A handle to the DC whose state is to be saved.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value identifies the saved state.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SaveDC</c> function can be used any number of times to save any number of instances of the DC state.</para>
	/// <para>A saved state can be restored by using the RestoreDC function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-savedc int SaveDC( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "f438cd7f-436f-436c-b32e-67f5558740cb")]
	public static extern int SaveDC([In, AddAsMember] HDC hdc);

	/// <summary>
	/// The <b>SelectObject</b> function selects an object into the specified device context (DC). The new object replaces the previous
	/// object of the same type.
	/// </summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="h">
	/// <para>A handle to the object to be selected. The specified object must have been created by using one of the following functions.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Object</description>
	/// <description>Functions</description>
	/// </listheader>
	/// <item>
	/// <description><b>Bitmap</b></description>
	/// <description>
	/// <c>CreateBitmap</c>, <c>CreateBitmapIndirect</c>, <c>CreateCompatibleBitmap</c>, <c>CreateDIBitmap</c>, <c>CreateDIBSection</c>
	/// Bitmaps can only be selected into memory DC's. A single bitmap cannot be selected into more than one DC at the same time.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>Brush</b></description>
	/// <description>
	/// <c>CreateBrushIndirect</c>, <c>CreateDIBPatternBrush</c>, <c>CreateDIBPatternBrushPt</c>, <c>CreateHatchBrush</c>,
	/// <c>CreatePatternBrush</c>, <c>CreateSolidBrush</c>
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>Font</b></description>
	/// <description><c>CreateFont</c>, <c>CreateFontIndirect</c></description>
	/// </item>
	/// <item>
	/// <description><b>Pen</b></description>
	/// <description><c>CreatePen</c>, <c>CreatePenIndirect</c></description>
	/// </item>
	/// <item>
	/// <description><b>Region</b></description>
	/// <description>
	/// <c>CombineRgn</c>, <c>CreateEllipticRgn</c>, <c>CreateEllipticRgnIndirect</c>, <c>CreatePolygonRgn</c>, <c>CreateRectRgn</c>, <c>CreateRectRgnIndirect</c>
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the selected object is not a region and the function succeeds, the return value is a handle to the object being replaced. If the
	/// selected object is a region and the function succeeds, the return value is one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description>SIMPLEREGION</description>
	/// <description>Region consists of a single rectangle.</description>
	/// </item>
	/// <item>
	/// <description>COMPLEXREGION</description>
	/// <description>Region consists of more than one rectangle.</description>
	/// </item>
	/// <item>
	/// <description>NULLREGION</description>
	/// <description>Region is empty.</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>If an error occurs and the selected object is not a region, the return value is <b>NULL</b>. Otherwise, it is HGDI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function returns the previously selected object of the specified type. An application should always replace a new object with
	/// the original, default object after it has finished drawing with the new object.
	/// </para>
	/// <para>An application cannot select a single bitmap into more than one DC at a time.</para>
	/// <para><b>ICM:</b> If the object being selected is a brush or a pen, color management is performed.</para>
	/// <para>Examples</para>
	/// <para>For an example, see <c>Setting the Pen or Brush Color</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-selectobject
	// HGDIOBJ SelectObject( [in] HDC hdc, [in] HGDIOBJ h );
	[PInvokeData("wingdi.h", MSDNShortId = "NF:wingdi.SelectObject")]
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	public static extern HGDIOBJ SelectObject([In] HDC hdc, [In] HGDIOBJ h);

	/// <summary>
	/// <c>SetDCPenColor</c> function sets the current device context (DC) pen color to the specified color value. If the device cannot
	/// represent the specified color value, the color is set to the nearest physical color.
	/// </summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="color">The new pen color.</param>
	/// <returns>
	/// If the function succeeds, the return value specifies the previous DC pen color as a COLORREF value. If the function fails, the
	/// return value is CLR_INVALID.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The function returns the previous DC_PEN color, even if the stock pen DC_PEN is not selected in the DC; however, this will not be
	/// used in drawing operations until the stock DC_PEN is selected in the DC.
	/// </para>
	/// <para>
	/// The GetStockObject function with an argument of DC_BRUSH or DC_PEN can be used interchangeably with the <c>SetDCPenColor</c> and
	/// SetDCBrushColor functions.
	/// </para>
	/// <para><c>ICM:</c> Color management is performed if ICM is enabled.</para>
	/// <para>Examples</para>
	/// <para>For an example of setting colors, see Setting the Pen or Brush Color.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdcpencolor COLORREF SetDCPenColor( HDC hdc, COLORREF color );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "057608eb-7209-4714-bf02-660a13d59016")]
	public static extern COLORREF SetDCPenColor([In, AddAsMember] HDC hdc, COLORREF color);

	/// <summary>The SetLayout function changes the layout of a device context (DC).</summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="dwLayout">The DC layout.</param>
	/// <returns>If the function succeeds, it returns the previous layout of the DC. If the function fails, it returns GDI_ERROR.</returns>
	/// <remarks>
	/// The layout specifies the order in which text and graphics are revealed in a window or a device context. The default is left to
	/// right. The SetLayout function changes this to be right to left, which is the standard in Arabic and Hebrew cultures.
	/// </remarks>
	[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
	[PInvokeData("Wingdi.h", MSDNShortId = "dd162979")]
	public static extern DCLayout SetLayout([In, AddAsMember] HDC hdc, DCLayout dwLayout);
}