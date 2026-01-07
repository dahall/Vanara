#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary/>
	public const int SP_APPABORT = (-2);

	/// <summary/>
	public const int SP_ERROR = (-1);

	/// <summary/>
	public const int SP_NOTREPORTED = 0x4000;

	/// <summary/>
	public const int SP_OUTOFDISK = (-4);

	/// <summary/>
	public const int SP_OUTOFMEMORY = (-5);

	/// <summary/>
	public const int SP_USERABORT = (-3);

	/// <summary>
	/// The <c>AbortProc</c> function is an application-defined callback function used with the SetAbortProc function. It is called when
	/// a print job is to be canceled during spooling. The <c>ABORTPROC</c> type defines a pointer to this callback function.
	/// <c>AbortProc</c> is a placeholder for the application-defined function name.
	/// </summary>
	/// <param name="hdc">A handle to the device context for the print job.</param>
	/// <param name="iError">
	/// Specifies whether an error has occurred. This parameter is zero if no error has occurred; it is SP_OUTOFDISK if Print Manager is
	/// currently out of disk space and more disk space will become available if the application waits.
	/// </param>
	/// <returns>The callback function should return <c>TRUE</c> to continue the print job or <c>FALSE</c> to cancel the print job.</returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>
	/// If the iError parameter is SP_OUTOFDISK, the application need not cancel the print job. If it does not cancel the job, it must
	/// yield to Print Manager by calling the PeekMessage or GetMessage function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-abortproc ABORTPROC Abortproc; BOOL Abortproc( HDC Arg1, int
	// Arg2 ) {...}
	[PInvokeData("wingdi.h", MSDNShortId = "3728a491-28ff-49ec-9131-ed6238b2be3d")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool AbortProc(HDC hdc, int iError);

	/// <summary>Specifies additional information about the print job.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "329bf0d9-399b-4f64-a029-361ef7558aeb")]
	public enum DI
	{
		/// <summary>Applications that use banding should set this flag for optimal performance during printing.</summary>
		DI_APPBANDING = 0x00000001,

		/// <summary>The application will use raster operations that involve reading from the destination surface.</summary>
		DI_ROPS_READ_DESTINATION = 0x00000002
	}

	/// <summary>The escape function to be performed.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "5ca74f61-75dd-4a8c-9f0f-9c1b4719c75f")]
	public enum EscapeFunction
	{
		NEWFRAME = 1,
		ABORTDOC = 2,
		NEXTBAND = 3,
		SETCOLORTABLE = 4,
		GETCOLORTABLE = 5,
		FLUSHOUTPUT = 6,
		DRAFTMODE = 7,

		/// <summary>Determines whether a particular escape is implemented by the device driver.</summary>
		QUERYESCSUPPORT = 8,

		SETABORTPROC = 9,
		STARTDOC = 10,
		ENDDOC = 11,
		GETPHYSPAGESIZE = 12,
		GETPRINTINGOFFSET = 13,
		GETSCALINGFACTOR = 14,
		MFCOMMENT = 15,
		GETPENWIDTH = 16,
		SETCOPYCOUNT = 17,
		SELECTPAPERSOURCE = 18,
		DEVICEDATA = 19,

		/// <summary>
		/// The PASSTHROUGH printer escape function sends data directly to a printer driver.
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>PASSTHROUGH</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The number of bytes of data to which the lpszInData parameter points.</description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>
		/// A pointer to the input structure required for the specified escape. The first word in the buffer contains the number of
		/// bytes of input data. The remaining bytes of the buffer contain the data itself.
		/// </description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>
		/// The number of bytes of data to which the lpszOutData parameter points. For this printer escape function, the value of this
		/// parameter is 0.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>
		/// A pointer to the structure that receives output from this escape. For this printer escape function, the value of the
		/// parameter is NULL.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(null, CorrespondingAction.Get)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.Set)]
		PASSTHROUGH = 19,

		/// <summary>
		/// The GETTECHNOLOGY printer escape function identifies the type of printer driver.
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>GETTECHNOLOGY</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The number of bytes of data to which the lpszInData parameter points.</description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>A pointer to the input structure required for the specified escape.</description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>The number of bytes of data to which the lpszOutData parameter points.</description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>
		/// A pointer to the structure that receives output from this escape. This parameter must not be NULL if ExtEscape is called as
		/// a query function. If no data is to be returned in this structure, set cbOutput to 0.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.GetSet)]
		GETTECHNOLOGY = 20,

		SETLINECAP = 21,
		SETLINEJOIN = 22,
		SETMITERLIMIT = 23,
		BANDINFO = 24,

		/// <summary>
		/// The DRAWPATTERNRECT printer escape creates a white, gray scale, or solid black rectangle by using the pattern and rule
		/// capabilities of Page Control Language (PCL) on Hewlett-Packard LaserJet or LaserJet-compatible printers. A gray scale is a
		/// gray pattern that contains a specific mixture of black and white pixels.
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>DRAWPATTERNRECT</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The number of bytes of data to which the lpszInData parameter points.
		/// <para>Set this value to <c>sizeof(DRAWPATRECT)</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>A pointer to a DRAWPATTERNRECT structure that describes the rectangle.</description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>The number of bytes of data to which the lpszOutData parameter points.
		/// <para>For this escape, the value of this parameter is 0.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>A pointer to the structure that will receive output from this escape.
		/// <para>For this printer escape function, the value of the parameter is NULL.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(null, CorrespondingAction.Get)]
		[CorrespondingType(typeof(DRAWPATRECT), CorrespondingAction.Set)]
		DRAWPATTERNRECT = 25,

		GETVECTORPENSIZE = 26,
		GETVECTORBRUSHSIZE = 27,
		ENABLEDUPLEX = 28,
		GETSETPAPERBINS = 29,
		GETSETPRINTORIENT = 30,
		ENUMPAPERBINS = 31,
		SETDIBSCALING = 32,
		EPSPRINTING = 33,
		ENUMPAPERMETRICS = 34,
		GETSETPAPERMETRICS = 35,

		/// <summary>
		/// The POSTSCRIPT_DATA printer escape function sends data directly to a printer driver.
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>POSTSCRIPT_DATA</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The number of bytes of data to which the lpszInData parameter points.</description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>
		/// A pointer to the input structure required for the specified escape. The first word in the buffer contains the number of
		/// bytes of input data. The remaining bytes of the buffer contain the data itself.
		/// </description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>
		/// The number of bytes of data to which the lpszOutData parameter points. For this printer escape function, the value of this
		/// parameter is 0.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>
		/// A pointer to the structure that receives output from this escape. For this printer escape function, the value of the
		/// parameter is NULL.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(null, CorrespondingAction.Get)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.Set)]
		POSTSCRIPT_DATA = 37,

		POSTSCRIPT_IGNORE = 38,
		MOUSETRAILS = 39,
		GETDEVICEUNITS = 42,
		GETEXTENDEDTEXTMETRICS = 256,
		GETEXTENTTABLE = 257,
		GETPAIRKERNTABLE = 258,
		GETTRACKKERNTABLE = 259,
		EXTTEXTOUT = 512,
		GETFACENAME = 513,
		DOWNLOADFACE = 514,
		ENABLERELATIVEWIDTHS = 768,
		ENABLEPAIRKERNING = 769,
		SETKERNTRACK = 770,
		SETALLJUSTVALUES = 771,
		SETCHARSET = 772,
		STRETCHBLT = 2048,
		METAFILE_DRIVER = 2049,
		GETSETSCREENPARAMS = 3072,
		QUERYDIBSUPPORT = 3073,
		BEGIN_PATH = 4096,
		CLIP_TO_PATH = 4097,
		END_PATH = 4098,
		EXT_DEVICE_CAPS = 4099,
		RESTORE_CTM = 4100,
		SAVE_CTM = 4101,
		SET_ARC_DIRECTION = 4102,
		SET_BACKGROUND_COLOR = 4103,
		SET_POLY_MODE = 4104,
		SET_SCREEN_ANGLE = 4105,
		SET_SPREAD = 4106,
		TRANSFORM_CTM = 4107,
		SET_CLIP_BOX = 4108,
		SET_BOUNDS = 4109,
		SET_MIRROR_MODE = 4110,
		OPENCHANNEL = 4110,
		DOWNLOADHEADER = 4111,
		CLOSECHANNEL = 4112,

		/// <summary>
		/// The POSTSCRIPT_PASSTHROUGH printer escape function sends data directly to a PostScript printer driver.
		/// <para>
		/// A PostScript driver supports this escape function when in PostScript-centric mode or in compatibility mode, but not in
		/// GDI-centric mode.
		/// </para>
		/// <para>To set the PostScript driver's mode, call the POSTSCRIPT_IDENTIFY escape function.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>POSTSCRIPT_PASSTHROUGH</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The number of bytes of data to which the lpszInData parameter points.</description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>
		/// A pointer to the input structure required for the specified escape. The first word in the buffer contains the number of
		/// bytes of input data. The remaining bytes of the buffer contain the data itself.
		/// </description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>
		/// The number of bytes of data to which the lpszOutData parameter points. For this printer escape function, the value of this
		/// parameter is 0.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>
		/// A pointer to the structure that receives output from this escape. For this printer escape function, the value of the
		/// parameter is NULL.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(null, CorrespondingAction.Get)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.Set)]
		POSTSCRIPT_PASSTHROUGH = 4115,

		ENCAPSULATED_POSTSCRIPT = 4116,

		/// <summary>
		/// The POSTSCRIPT_IDENTIFY printer escape function sets a PostScript driver to GDI-centric mode or PostScript-centric mode.
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>POSTSCRIPT_IDENTIFY</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The number of bytes of data to which the lpszInData parameter points.
		/// <para>For this escape, set this value to <c>sizeof(DWORD)</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>A pointer to the input structure required for the specified escape.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>PSIDENT_GDICENTRIC</description>
		/// <description>
		/// <para>
		/// GDI-centric mode. Specify this value if the PostScript driver supports the PASSTHROUGH printer escape function, but not the
		/// POSTSCRIPT_PASSTHROUGH printer escape function.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>PSIDENT_PSCENTRIC</description>
		/// <description>
		/// <para>
		/// PostScript-centric mode. Specify this value if the PostScript driver supports the POSTSCRIPT_PASSTHROUGH printer escape
		/// function, but not the PASSTHROUGH printer escape function.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>
		/// The number of bytes of data to which the lpszOutData parameter points. For this printer escape function, the value of this
		/// parameter is 0.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>
		/// A pointer to the structure that receives output from this escape. For this printer escape function, the value of the
		/// parameter is NULL.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(null, CorrespondingAction.Get)]
		[CorrespondingType(typeof(PSIDENT), CorrespondingAction.Set)]
		POSTSCRIPT_IDENTIFY = 4117,

		/// <summary>
		/// The POSTSCRIPT_INJECTION printer escape function inserts a block of raw data at a specified point in a PostScript job stream.
		/// <para>
		/// A PostScript driver supports this escape function in GDI-centric mode or PostScript-centric mode support, but not in
		/// compatibility mode.
		/// </para>
		/// <para>To set the PostScript driver's mode, call the POSTSCRIPT_IDENTIFY escape function.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>POSTSCRIPT_INJECTION</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The number of bytes of data to which the lpszInData parameter points.
		/// <para>Set this parameter to <c>sizeof(PSINJECTDATA)</c> plus the size of the raw data to inject.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>A pointer to the buffer that contains a PSINJECTDATA structure followed by the raw data to inject.</description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>
		/// The number of bytes of data to which the lpszOutData parameter points. For this printer escape function, the value of this
		/// parameter is 0.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>
		/// A pointer to the structure that receives output from this escape. For this printer escape function, the value of the
		/// parameter is NULL.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(null, CorrespondingAction.Get)]
		[CorrespondingType(typeof(PSINJECTDATA), CorrespondingAction.Set)]
		POSTSCRIPT_INJECTION = 4118,

		/// <summary>
		/// The CHECKJPEGFORMAT printer escape function determines whether a printer supports printing a JPEG image.
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>CHECKJPEGFORMAT</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The size, in bytes, of the JPEG image buffer pointed to by the lpInData parameter.</description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>A pointer to a buffer that contains the JPEG image.</description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>The number of bytes of data pointed to by the lpOutData parameter.
		/// <para>For this escape, set this value to <c>sizeof(DWORD)</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>
		/// A pointer to the DWORD variable that receives the output from this escape. This parameter must not be NULL.
		/// <para>If the printer supports the image type, this value is set to 1. Otherwise, it is set to zero.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		[CorrespondingType(typeof(byte[]), CorrespondingAction.Set)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.Set)]
		CHECKJPEGFORMAT = 4119,

		/// <summary>
		/// The CHECKJPEGFORMAT printer escape function determines whether a printer supports printing a PNG image.
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>CHECKPNGFORMAT</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The size, in bytes, of the PNG image buffer pointed to by the lpInData parameter.</description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>A pointer to a buffer that contains the PNG image.</description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>The number of bytes of data pointed to by the lpOutData parameter.
		/// <para>For this escape, set this value to <c>sizeof(DWORD)</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>
		/// A pointer to the DWORD variable that receives the output from this escape. This parameter must not be NULL.
		/// <para>If the printer supports the image type, this value is set to 1. Otherwise, it is set to zero.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		[CorrespondingType(typeof(byte[]), CorrespondingAction.Set)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.Set)]
		CHECKPNGFORMAT = 4120,

		/// <summary>
		/// The GET_PS_FEATURESETTING printer escape function retrieves information about a specified feature setting for a PostScript driver.
		/// <para>
		/// This escape function is supported only if the PostScript driver is in PostScript-centric mode or in GDI-centric mode. To set
		/// the PostScript driver mode, call the POSTSCRIPT_IDENTIFY escape function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <description>hdc</description>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <description>iEscape</description>
		/// <description><c>DRAWPATTERNRECT</c></description>
		/// </item>
		/// <item>
		/// <description>cjInput</description>
		/// <description>The number of bytes of data to which the lpszInData parameter points.
		/// <para>Set this value to <c>sizeof(INT)</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>lpInData</description>
		/// <description>A pointer to the INT variable that contains a feature setting value from the following table.
		/// <para>
		/// Windows XP and later versions of Windows support the private use of this parameter. For private use, you can use the numbers
		/// in the range from FEATURESETTING_PRIVATE_BEGIN to FEATURESETTING_PRIVATE_END. Private parties that intend to use numbers in
		/// this range should contact Microsoft first to avoid conflicts with other applications.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>FEATURESETTING_CUSTPAPER</description>
		/// <description>
		/// <para>Retrieves the custom paper parameters.</para>
		/// <para>Set cbOutput to sizeof ( PSFEATURE_CUSTPAPER ) and lpszOutData to point to a PSFEATURE_CUSTPAPER structure.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>FEATURESETTING_MIRROR</description>
		/// <description>
		/// <para>Retrieves the mirrored output setting.</para>
		/// <para>Set cbOutput to sizeof ( BOOL ) and lpszOutData to point to a BOOL variable.</para>
		/// <para>If mirrored output is selected, the value returned in lpszOutData is TRUE.</para>
		/// <para>If mirrored output is not selected, the value returned in lpszOutData is FALSE</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>FEATURESETTING_NEGATIVE</description>
		/// <description>
		/// <para>Retrieves the negative output setting.</para>
		/// <para>Set cbOutput to sizeof ( BOOL ) and lpszOutData to point to a BOOL variable.</para>
		/// <para>
		/// When the function returns, the lpszOutData variable is TRUE if "Negative Output: Yes" is selected; otherwise, it is FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>FEATURESETTING_NUP</description>
		/// <description>
		/// <para>Retrieves the N-Up setting of the page layout.</para>
		/// <para>Set cbOutput to sizeof ( BOOL ) and lpszOutData to point to a BOOL variable.</para>
		/// <para>If an N-Up page layout is not being used, the lpszOutData variable returns FALSE.</para>
		/// <para>
		/// If an N-Up page layout is being used, the lpszOutData variable returns TRUE. However, the variable does not indicate the
		/// format of the N-Up page layout or its semantics.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>FEATURESETTING_OUTPUT</description>
		/// <description>
		/// <para>Retrieves information about PostScript driver output options.</para>
		/// <para>Set cbOutput to sizeof ( PSFEATURE_OUTPUT ) and lpszOutData to point to a PSFEATURE_OUTPUT structure.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>FEATURESETTING_PROTOCOL</description>
		/// <description>
		/// <para>Retrieves the output protocol setting.</para>
		/// <para>Sets cbOutput to sizeof( INT ) and lpszOutData to point to an INT variable.</para>
		/// <para>When the function returns, the lpszOutData variable is set to one of the following output protocol values:</para>
		/// <para>PSPROTOCOL_ASCII PSPROTOCOL_BCP PSPROTOCOL_TBCP PSPROTOCOL_BINARY</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>FEATURESETTING_PSLEVEL</description>
		/// <description>
		/// <para>Retrieves the PostScript language level.</para>
		/// <para>Set cbOutput to sizeof ( INT ) and lpszOutData to point to an INT variable.</para>
		/// <para>
		/// When the function returns, the lpszOutData variable is set to 1, 2, 3, or higher to indicate the PostScript language level.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </description>
		/// </item>
		/// <item>
		/// <description>cjOutput</description>
		/// <description>The number of bytes of data to which the lpszOutData parameter points.</description>
		/// </item>
		/// <item>
		/// <description>lpOutData</description>
		/// <description>
		/// A pointer to the structure that receives output from this escape. This parameter must not be NULL if ExtEscape is called as
		/// a query function. If no data is to be returned in this structure, set cbOutput to 0.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
		[CorrespondingType(typeof(PSFEATURE_OUTPUT), CorrespondingAction.Get)]
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		[CorrespondingType(typeof(PSFEATURE_CUSTPAPER), CorrespondingAction.Get)]
		[CorrespondingType(typeof(FEATURESETTING), CorrespondingAction.Set)]
		GET_PS_FEATURESETTING = 4121,

		GDIPLUS_TS_QUERYVER = 4122,
		GDIPLUS_TS_RECORD = 4123,

		/// <summary>
		/// The SPCLPASSTHROUGH2 printer escape function allows applications that print to PostScript devices using EPSPRINTING to
		/// include private PostScript procedures and other resources at the document-level save context.
		/// <para>
		/// This escape is supported only for backward compatibility with Adobe Acrobat. Other applications should not use this obsolete escape.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>hdc</term>
		/// <description>A handle to the printer device context.</description>
		/// </item>
		/// <item>
		/// <term>iEscape</term>
		/// <description><c>SPCLPASSTHROUGH2</c></description>
		/// </item>
		/// <item>
		/// <term>cjInput</term>
		/// <description>The number of bytes of data to which the lpszInData parameter points.</description>
		/// </item>
		/// <item>
		/// <term>lpInData</term>
		/// <description>A pointer to the input structure required for the specified escape.</description>
		/// </item>
		/// <item>
		/// <term>cjOutput</term>
		/// <description>
		/// The number of bytes of data to which the lpszOutData parameter points. For this printer escape function, the value of this
		/// parameter is 0.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lpOutData</term>
		/// <description>
		/// A pointer to the structure that receives output from this escape. For this printer escape function, the value of the
		/// parameter is NULL.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(null, CorrespondingAction.Get)]
		[CorrespondingType(typeof(byte[]), CorrespondingAction.Set)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.Set)]
		SPCLPASSTHROUGH2 = 4568,
	}

	/// <summary>Values for the GET_PS_FEATURESETTING escape.</summary>
	[PInvokeData("wingdi.h")]
	public enum FEATURESETTING
	{
		/// <summary>
		/// <para>Retrieves the N-Up setting of the page layout.</para>
		/// <para>Set cbOutput to sizeof ( BOOL ) and lpszOutData to point to a <see cref="BOOL"/> variable.</para>
		/// <para>If an N-Up page layout is not being used, the lpszOutData variable returns FALSE.</para>
		/// <para>
		/// If an N-Up page layout is being used, the lpszOutData variable returns TRUE. However, the variable does not indicate the format
		/// of the N-Up page layout or its semantics.
		/// </para>
		/// </summary>
		FEATURESETTING_NUP = 0,

		/// <summary>
		/// <para>Retrieves information about PostScript driver output options.</para>
		/// <para>Set cbOutput to sizeof ( PSFEATURE_OUTPUT ) and lpszOutData to point to a <see cref="PSFEATURE_OUTPUT"/> structure.</para>
		/// </summary>
		FEATURESETTING_OUTPUT = 1,

		/// <summary>
		/// <para>Retrieves the PostScript language level.</para>
		/// <para>Set cbOutput to sizeof ( INT ) and lpszOutData to point to an INT variable.</para>
		/// <para>When the function returns, the lpszOutData variable is set to 1, 2, 3, or higher to indicate the PostScript language level.</para>
		/// </summary>
		FEATURESETTING_PSLEVEL = 2,

		/// <summary>
		/// <para>Retrieves the custom paper parameters.</para>
		/// <para>Set cbOutput to sizeof ( PSFEATURE_CUSTPAPER ) and lpszOutData to point to a <see cref="PSFEATURE_CUSTPAPER"/> structure.</para>
		/// </summary>
		FEATURESETTING_CUSTPAPER = 3,

		/// <summary>
		/// <para>Retrieves the mirrored output setting.</para>
		/// <para>Set cbOutput to sizeof ( BOOL ) and lpszOutData to point to a <see cref="BOOL"/> variable.</para>
		/// <para>If mirrored output is selected, the value returned in lpszOutData is TRUE.</para>
		/// <para>If mirrored output is not selected, the value returned in lpszOutData is FALSE</para>
		/// </summary>
		FEATURESETTING_MIRROR = 4,

		/// <summary>
		/// <para>Retrieves the negative output setting.</para>
		/// <para>Set cbOutput to sizeof ( BOOL ) and lpszOutData to point to a <see cref="BOOL"/> variable.</para>
		/// <para>When the function returns, the lpszOutData variable is TRUE if "Negative Output: Yes" is selected; otherwise, it is FALSE.</para>
		/// </summary>
		FEATURESETTING_NEGATIVE = 5,

		/// <summary>
		/// <para>Retrieves the output protocol setting.</para>
		/// <para>Sets cbOutput to sizeof( INT ) and lpszOutData to point to an INT variable.</para>
		/// <para>When the function returns, the lpszOutData variable is set to one of the following output protocol values:</para>
		/// <para>PSPROTOCOL_ASCII PSPROTOCOL_BCP PSPROTOCOL_TBCP PSPROTOCOL_BINARY</para>
		/// </summary>
		FEATURESETTING_PROTOCOL = 6,

		/// <summary>
		/// Windows XP and later versions of Windows support the private use of this parameter. For private use, you can use the numbers in
		/// the range from FEATURESETTING_PRIVATE_BEGIN to FEATURESETTING_PRIVATE_END. Private parties that intend to use numbers in this
		/// range should contact Microsoft first to avoid conflicts with other applications.
		/// </summary>
		FEATURESETTING_PRIVATE_BEGIN = 0x1000,

		/// <summary>
		/// Windows XP and later versions of Windows support the private use of this parameter. For private use, you can use the numbers in
		/// the range from FEATURESETTING_PRIVATE_BEGIN to FEATURESETTING_PRIVATE_END. Private parties that intend to use numbers in this
		/// range should contact Microsoft first to avoid conflicts with other applications.
		/// </summary>
		FEATURESETTING_PRIVATE_END = 0x1FFF,
	}

	/// <summary>Values for the POSTSCRIPT_IDENTIFY escape.</summary>
	[PInvokeData("wingdi.h")]
	public enum PSIDENT
	{
		/// <summary>
		/// GDI-centric mode. Specify this value if the PostScript driver supports the PASSTHROUGH printer escape function, but not the
		/// POSTSCRIPT_PASSTHROUGH printer escape function.
		/// </summary>
		PSIDENT_GDICENTRIC = 0,

		/// <summary>
		/// PostScript-centric mode. Specify this value if the PostScript driver supports the POSTSCRIPT_PASSTHROUGH printer escape function,
		/// but not the PASSTHROUGH printer escape function.
		/// </summary>
		PSIDENT_PSCENTRIC = 1,
	}

	/// <summary>Specifies where to inject the raw data in the PostScript output.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "f42c8f69-7fe9-4740-b295-32ef2a5b714c")]
	public enum PSINJECT : ushort
	{
		/// <summary>Before the first byte of job stream.</summary>
		PSINJECT_BEGINSTREAM = 1,

		/// <summary>Before %!PS-Adobe.</summary>
		PSINJECT_PSADOBE = 2,

		/// <summary>Replaces driver's %%Pages (atend).</summary>
		PSINJECT_PAGESATEND = 3,

		/// <summary>Replaces driver's %%Pages nnn.</summary>
		PSINJECT_PAGES = 4,

		/// <summary>After %%DocumentNeededResources.</summary>
		PSINJECT_DOCNEEDEDRES = 5,

		/// <summary>After %%DocumentSuppliedResources.</summary>
		PSINJECT_DOCSUPPLIEDRES = 6,

		/// <summary>Replaces driver's %%PageOrder.</summary>
		PSINJECT_PAGEORDER = 7,

		/// <summary>Replaces driver's %%Orientation.</summary>
		PSINJECT_ORIENTATION = 8,

		/// <summary>Replaces driver's %%BoundingBox.</summary>
		PSINJECT_BOUNDINGBOX = 9,

		/// <summary>Replaces driver's %%DocumentProcessColors &lt;color&gt;.</summary>
		PSINJECT_DOCUMENTPROCESSCOLORS = 10,

		/// <summary>Before %%EndComments.</summary>
		PSINJECT_COMMENTS = 11,

		/// <summary>After %%BeginDefaults.</summary>
		PSINJECT_BEGINDEFAULTS = 12,

		/// <summary>Before %%EndDefaults.</summary>
		PSINJECT_ENDDEFAULTS = 13,

		/// <summary>After %%BeginProlog.</summary>
		PSINJECT_BEGINPROLOG = 14,

		/// <summary>Before %%EndProlog.</summary>
		PSINJECT_ENDPROLOG = 15,

		/// <summary>After %%BeginSetup.</summary>
		PSINJECT_BEGINSETUP = 16,

		/// <summary>TBefore %%EndSetup.</summary>
		PSINJECT_ENDSETUP = 17,

		/// <summary>After %%Trailer</summary>
		PSINJECT_TRAILER = 18,

		/// <summary>After %%EOF</summary>
		PSINJECT_EOF = 19,

		/// <summary>After the last byte of job stream</summary>
		PSINJECT_ENDSTREAM = 20,

		/// <summary>Replaces driver's %%DocumentProcessColors (atend)</summary>
		PSINJECT_DOCUMENTPROCESSCOLORSATEND = 21,

		/// <summary>Replaces driver's %%Page</summary>
		PSINJECT_PAGENUMBER = 100,

		/// <summary>After %%BeginPageSetup</summary>
		PSINJECT_BEGINPAGESETUP = 101,

		/// <summary>Before %%EndPageSetup</summary>
		PSINJECT_ENDPAGESETUP = 102,

		/// <summary>After %%PageTrailer</summary>
		PSINJECT_PAGETRAILER = 103,

		/// <summary>Replace driver's %%PlateColor: &lt;color&gt;</summary>
		PSINJECT_PLATECOLOR = 104,

		/// <summary>Before showpage operator</summary>
		PSINJECT_SHOWPAGE = 105,

		/// <summary>Replaces driver's %%PageBoundingBox</summary>
		PSINJECT_PAGEBBOX = 106,

		/// <summary>Before %%EndPageComments</summary>
		PSINJECT_ENDPAGECOMMENTS = 107,

		/// <summary>Before save operator</summary>
		PSINJECT_VMSAVE = 200,

		/// <summary>After restore operator</summary>
		PSINJECT_VMRESTORE = 201,

		/// <summary/>
		PSINJECT_DLFONT = unchecked((ushort)0xdddddddd),
	}

	/// <summary>
	/// The <c>AbortDoc</c> function stops the current print job and erases everything drawn since the last call to the StartDoc function.
	/// </summary>
	/// <param name="hdc">Handle to the device context for the print job.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is greater than zero.</para>
	/// <para>If the function fails, the return value is SP_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>
	/// Applications should call the <c>AbortDoc</c> function to stop a print job if an error occurs, or to stop a print job after the
	/// user cancels that job. To end a successful print job, an application should call the EndDoc function.
	/// </para>
	/// <para>
	/// If Print Manager was used to start the print job, calling <c>AbortDoc</c> erases the entire spool job, so that the printer
	/// receives nothing. If Print Manager was not used to start the print job, the data may already have been sent to the printer. In
	/// this case, the printer driver resets the printer (when possible) and ends the print job.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-abortdoc int AbortDoc( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "4ecc371c-34fa-4073-96fe-0de03b84d7e3")]
	public static extern int AbortDoc([In, AddAsMember] HDC hdc);

	/// <summary>The <c>EndDoc</c> function ends a print job.</summary>
	/// <param name="hdc">Handle to the device context for the print job.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is greater than zero.</para>
	/// <para>If the function fails, the return value is less than or equal to zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>Applications should call <c>EndDoc</c> immediately after finishing a print job.</para>
	/// <para>Examples</para>
	/// <para>For a sample program that uses this function, see How To: Print Using the GDI Print API.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enddoc int EndDoc( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "bf63ea0f-cc73-4943-9c84-52b3b77e141c")]
	public static extern int EndDoc([In, AddAsMember] HDC hdc);

	/// <summary>
	/// The <c>EndPage</c> function notifies the device that the application has finished writing to a page. This function is typically
	/// used to direct the device driver to advance to a new page.
	/// </summary>
	/// <param name="hdc">A handle to the device context for the print job.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is greater than zero.</para>
	/// <para>If the function fails, the return value is less than or equal to zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>
	/// Use the ResetDC function to change the device mode, if necessary, after calling the <c>EndPage</c> function. Note that a call to
	/// <c>ResetDC</c> resets all device context attributes back to default values. Neither <c>EndPage</c> nor StartPage resets the
	/// device context attributes. Device context attributes remain constant across subsequent pages. You do not need to re-select
	/// objects and set up the mapping mode again before printing the next page; however, doing so will produce the same results and
	/// reduce code differences between versions of Windows.
	/// </para>
	/// <para>
	/// When a page in a spooled file exceeds approximately 350 MB, it may fail to print and not send an error message. For example,
	/// this can occur when printing large EMF files. The page size limit depends on many factors including the amount of virtual memory
	/// available, the amount of memory allocated by calling processes, and the amount of fragmentation in the process heap.
	/// </para>
	/// <para>Examples</para>
	/// <para>For a sample program that uses this function, see How To: Print Using the GDI Print API.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-endpage int EndPage( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "33e6d005-f00d-4b87-bf7c-fc79c1d05514")]
	public static extern int EndPage([In, AddAsMember] HDC hdc);

	/// <summary>
	/// The <c>Escape</c> function enables an application to access the system-defined device capabilities that are not available
	/// through GDI. Escape calls made by an application are translated and sent to the driver.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="iEscape">
	/// The escape function to be performed. This parameter must be one of the predefined escape values listed in Remarks. Use the
	/// ExtEscape function if your application defines a private escape value.
	/// </param>
	/// <param name="cjIn">The number of bytes of data pointed to by the lpvInData parameter. This can be 0.</param>
	/// <param name="pvIn">A pointer to the input structure required for the specified escape.</param>
	/// <param name="pvOut">
	/// A pointer to the structure that receives output from this escape. This parameter should be <c>NULL</c> if no data is returned.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is greater than zero, except with the QUERYESCSUPPORT printer escape, which checks
	/// for implementation only. If the escape is not implemented, the return value is zero.
	/// </para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>The effect of passing 0 for cbInput will depend on the value of nEscape and on the driver that is handling the escape.</para>
	/// <para>Of the original printer escapes, only the following can be used.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Escape</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>QUERYESCSUPPORT</term>
	/// <term>Determines whether a particular escape is implemented by the device driver.</term>
	/// </item>
	/// <item>
	/// <term>PASSTHROUGH</term>
	/// <term>Allows the application to send data directly to a printer.</term>
	/// </item>
	/// </list>
	/// <para>For information about printer escapes, see ExtEscape.</para>
	/// <para>Use the StartPage function to prepare the printer driver to receive data.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-escape int Escape( HDC hdc, int iEscape, int cjIn, LPCSTR
	// pvIn, LPVOID pvOut );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "ba21b680-78a8-45a2-94e1-01b377b74787")]
	public static extern int Escape([In, AddAsMember] HDC hdc, EscapeFunction iEscape, int cjIn, [In, SizeDef(nameof(cjIn))] IntPtr pvIn, [Out, Optional] IntPtr pvOut);

	/// <summary>
	/// The <c>ExtEscape</c> function enables an application to access device capabilities that are not available through GDI.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="iEscape">
	/// <para>The escape function to be performed. It can be one of the following or it can be an application-defined escape function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CHECKJPEGFORMAT</term>
	/// <term>Checks whether the printer supports a JPEG image.</term>
	/// </item>
	/// <item>
	/// <term>CHECKPNGFORMAT</term>
	/// <term>Checks whether the printer supports a PNG image.</term>
	/// </item>
	/// <item>
	/// <term>DRAWPATTERNRECT</term>
	/// <term>Draws a white, gray-scale, or black rectangle.</term>
	/// </item>
	/// <item>
	/// <term>GET_PS_FEATURESETTING</term>
	/// <term>Gets information on a specified feature setting for a PostScript driver.</term>
	/// </item>
	/// <item>
	/// <term>GETTECHNOLOGY</term>
	/// <term>Reports on whether or not the driver is a Postscript driver.</term>
	/// </item>
	/// <item>
	/// <term>PASSTHROUGH</term>
	/// <term>Allows the application to send data directly to a printer. Supported in compatibility mode and GDI-centric mode.</term>
	/// </item>
	/// <item>
	/// <term>POSTSCRIPT_DATA</term>
	/// <term>Allows the application to send data directly to a printer. Supported only in compatibility mode.</term>
	/// </item>
	/// <item>
	/// <term>POSTSCRIPT_IDENTIFY</term>
	/// <term>Sets a PostScript driver to GDI-centric or PostScript-centric mode.</term>
	/// </item>
	/// <item>
	/// <term>POSTSCRIPT_INJECTION</term>
	/// <term>Inserts a block of raw data in a PostScript job stream.</term>
	/// </item>
	/// <item>
	/// <term>POSTSCRIPT_PASSTHROUGH</term>
	/// <term>Sends data directly to a PostScript printer driver. Supported in compatibility mode and PostScript-centric mode.</term>
	/// </item>
	/// <item>
	/// <term>QUERYESCSUPPORT</term>
	/// <term>Determines whether a particular escape is implemented by the device driver.</term>
	/// </item>
	/// <item>
	/// <term>SPCLPASSTHROUGH2</term>
	/// <term>Enables applications to include private procedures and other resources at the document level-save context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="cjInput">The number of bytes of data pointed to by the lpszInData parameter.</param>
	/// <param name="lpInData">A pointer to the input structure required for the specified escape. See also Remarks.</param>
	/// <param name="cjOutput">The number of bytes of data pointed to by the lpszOutData parameter.</param>
	/// <param name="lpOutData">
	/// A pointer to the structure that receives output from this escape. This parameter must not be <c>NULL</c> if <c>ExtEscape</c> is
	/// called as a query function. If no data is to be returned in this structure, set cbOutput to 0. See also Remarks.
	/// </param>
	/// <returns>
	/// The return value specifies the outcome of the function. It is greater than zero if the function is successful, except for the
	/// QUERYESCSUPPORT printer escape, which checks for implementation only. The return value is zero if the escape is not implemented.
	/// A return value less than zero indicates an error.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>Use this function to pass a driver-defined escape value to a device.</para>
	/// <para>
	/// Use the Escape function to pass one of the system-defined escape values to a device, unless the escape is one of the defined
	/// escapes in nEscape. <c>ExtEscape</c> might not work properly with the system-defined escapes. In particular, escapes in which
	/// lpszInData is a pointer to a structure that contains a member that is a pointer will fail.
	/// </para>
	/// <para>
	/// Note, that the behavior described in this article is the expected behavior, but it is up to the driver to comply with this model.
	/// </para>
	/// <para>
	/// The variables referenced by lpszInData and lpszOutData should not be the same or overlap. If the input and the output buffer
	/// size variables overlap, they may not contain the correct values after the call returns. For the best results, lpszInData and
	/// lpszOutData should refer to different variables.
	/// </para>
	/// <para>The CHECKJPEGFORMAT printer escape function determines whether a printer supports printing a JPEG image.</para>
	/// <para>
	/// Before using the CHECKJPEGFORMAT printer escape function, call the QUERYESCSUPPORT printer escape function to determine whether
	/// the driver supports <c>CHECKJPEGFORMAT</c>. For sample code that demonstrates the use of <c>CHECKJPEGFORMAT</c>, see Testing a
	/// Printer for JPEG or PNG Support.
	/// </para>
	/// <para>The CHECKPNGFORMAT printer escape function determines whether a printer supports printing a PNG image.</para>
	/// <para>
	/// Before using the CHECKJPEGFORMAT printer escape function, call the QUERYESCSUPPORT printer escape function to determine whether
	/// the driver supports <c>CHECKJPEGFORMAT</c>. For sample code, see Testing a Printer for JPEG or PNG Support.
	/// </para>
	/// <para>
	/// The DRAWPATTERNRECT printer escape creates a white, gray scale, or solid black rectangle by using the pattern and rule
	/// capabilities of Page Control Language (PCL) on Hewlett-Packard LaserJet or LaserJet-compatible printers. A gray scale is a gray
	/// pattern that contains a specific mixture of black and white pixels.
	/// </para>
	/// <para>
	/// An application should use the QUERYESCSUPPORT escape to determine whether the printer is capable of drawing patterns and rules
	/// before using the DRAWPATTERNRECT escape.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Rules drawn with DRAWPATTERNRECT are not subject to clipping regions in the device context.</term>
	/// </item>
	/// <item>
	/// <term>Applications should not try to erase patterns and rules created with DRAWPATTERNRECT by placing opaque objects over them.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the printer supports white rules, these can be used to erase patterns created by DRAWPATTERNRECT. If the printer does not
	/// support white rules, there is no method for erasing these patterns.
	/// </para>
	/// <para>
	/// If an application cannot use the DRAWPATTERNRECT escape and the device is a printer, it should generally use the PatBlt function
	/// instead. Note that if <c>PatBlt</c> is used to print a black rectangle, the application should use the BLACKNESS raster
	/// operator. If the device is a plotter, however, the application should use the Rectangle function.
	/// </para>
	/// <para>
	/// The GET_PS_FEATURESETTING printer escape function retrieves information about a specified feature setting for a PostScript driver.
	/// </para>
	/// <para>
	/// This escape function is supported only if the PostScript driver is in PostScript-centric mode or in GDI-centric mode. To set the
	/// PostScript driver mode, call the POSTSCRIPT_IDENTIFY escape function.
	/// </para>
	/// <para>To perform this operation, call the <c>ExtEscape</c> function with the following parameters.</para>
	/// <para>
	/// The GET_PS_FEATURESETTING printer escape function is valid if called any time after calling the CreateDC function and before
	/// calling the DeleteDC function.
	/// </para>
	/// <para>The GETTECHNOLOGY printer escape function identifies the type of printer driver.</para>
	/// <para>For non-XPSDrv printers, this escape reports whether the driver is a Postscript driver.</para>
	/// <para>
	/// For XPSDrv printers, this escape reports whether the driver is the Microsoft XPS Document Converter (MXDC). If it is, the escape
	/// returns the zero-terminated string "http://schemas.microsoft.com/xps/2005/06"
	/// </para>
	/// <para>
	/// The PASSTHROUGH printer escape function sends data directly to a printer driver. To perform this operation, call the
	/// <c>ExtEscape</c> function with the following parameters.
	/// </para>
	/// <para>
	/// The <c>PASSTHROUGH</c> printer escape function is supported by PostScript drivers in GDI-centric mode or compatibility mode, but
	/// not in PostScript-centric mode. Drivers in PostScript-centric mode can use the POSTSCRIPT_PASSTHROUGH escape function. To set a
	/// PostScript driver mode, call the POSTSCRIPT_IDENTIFY escape function.
	/// </para>
	/// <para>
	/// For PASSTHROUGH data sent by EPSPRINTING or PostScript-centric applications, the PostScript driver will not make any
	/// modifications. For PASSTHROUGH data sent by other applications, if the PostScript driver is using BCP (Binary Communication
	/// Protocol) or TBCP (Tagged Binary Communication Protocol) output protocol, the driver does the appropriate BCP or TBCP quoting on
	/// special characters, as described in "Adobe Serial and Parallel Communications Protocols Specification." This means that the
	/// application should send either ASCII or pure binary PASSTHROUGH data.
	/// </para>
	/// <para>
	/// The POSTSCRIPT_DATA printer escape function sends data directly to a printer driver. To perform this operation, call the
	/// <c>ExtEscape</c> function with the following parameters.
	/// </para>
	/// <para>
	/// The POSTSCRIPT_DATA function is identical to the PASSTHROUGH escape function except that it is supported by PostScript drivers
	/// in compatibility mode only. It is not supported by PostScript drivers in PostScript-centric mode or in GDI-centric mode.
	/// </para>
	/// <para>
	/// Drivers in PostScript-centric mode can use the POSTSCRIPT_PASSTHROUGH escape function, and drivers in GDI-centric mode can use
	/// the PASSTHROUGH escape function. To set a PostScript driver's mode, call the POSTSCRIPT_IDENTIFY escape function.
	/// </para>
	/// <para>The POSTSCRIPT_IDENTIFY printer escape function sets a PostScript driver to GDI-centric mode or PostScript-centric mode.</para>
	/// <para>
	/// To put the driver in GDI-centric or PostScript-centric modes, first call the QUERYESCSUPPORT printer escape function to
	/// determine whether the driver supports the POSTSCRIPT_IDENTIFY printer escape function. If so, you can assume the driver is
	/// PSCRIPT 5.0. Then, before you call any other printer escape function, you must call <c>POSTSCRIPT_IDENTIFY</c> and specify
	/// either <c>PSIDENT_GDICENTRIC</c> or <c>PSIDENT_PSCENTRIC</c>. You must call the <c>QUERYESCSUPPORT</c> and
	/// <c>POSTSCRIPT_IDENTIFY</c> printer escape functions before calling any other printer escape function.
	/// </para>
	/// <para>
	/// <c>Note</c> After the PostScript driver is set to GDI-centric mode or PostScript-centric mode, you will not be allowed to call
	/// the POSTSCRIPT_IDENTIFY printer escape function anymore.
	/// </para>
	/// <para>
	/// If you do not use the POSTSCRIPT_IDENTIFY printer escape function, the PostScript driver is in compatibility mode and provides
	/// identical support for the PASSTHROUGH, POSTSCRIPT_PASSTHROUGH, and POSTSCRIPT_DATA printer escape functions.
	/// </para>
	/// <para>
	/// For PostScript drivers that support the POSTSCRIPT_PASSTHROUGH, PASSTHROUGH, and <c>POSTSCRIPT_PASSTHROUGH</c> printer escape
	/// functions are identical.
	/// </para>
	/// <para>
	/// In PostScript-centric mode, the application is responsible for all PostScript output that marks the paper using the
	/// POSTSCRIPT_PASSTHROUGH escape function. GDI functions are not allowed. The driver is responsible for the overall document
	/// structure and printer control settings. The application can use the POSTSCRIPT_INJECTION printer escape function to inject a
	/// block of raw data (including DSC comments) into the job stream at specific places.
	/// </para>
	/// <para>
	/// The POSTSCRIPT_INJECTION printer escape function inserts a block of raw data at a specified point in a PostScript job stream.
	/// </para>
	/// <para>
	/// A PostScript driver supports this escape function in GDI-centric mode or PostScript-centric mode support, but not in
	/// compatibility mode.
	/// </para>
	/// <para>To set the PostScript driver's mode, call the POSTSCRIPT_IDENTIFY escape function.</para>
	/// <para>To perform this operation, call the <c>ExtEscape</c> function with the following parameters.</para>
	/// <para>
	/// The driver internally caches the injection data and emits it at appropriate points in the output. The cached information is
	/// flushed when it is no longer needed. At the latest, it is flushed after the EndDoc call.
	/// </para>
	/// <para>
	/// In GDI-centric mode, the application can only inject valid DSC block data by using the POSTSCRIPT_INJECTION printer escape
	/// function. A valid DSC block must satisfy all of the following conditions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>It consists of an integral sequence of "lines."</term>
	/// </item>
	/// <item>
	/// <term>Each "line" must begin with "%%".</term>
	/// </item>
	/// <item>
	/// <term>
	/// Each "line" except the last line must end with &lt;CR&gt;, &lt;LF&gt;, or &lt;CR&gt;&lt;LF&gt; except for the last line. If the
	/// last line does not end with &lt;CR&gt;, &lt;LF&gt;, or &lt;CR&gt;&lt;LF&gt;, the driver appends &lt;CR&gt;&lt;LF&gt; after the
	/// last byte of the injection data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Each "line" must be 255 bytes or less including the "%%" but not counting the &lt;CR&gt;/&lt;LF&gt; line termination.</term>
	/// </item>
	/// </list>
	/// <para>The POSTSCRIPT_PASSTHROUGH printer escape function sends data directly to a PostScript printer driver.</para>
	/// <para>
	/// A PostScript driver supports this escape function when in PostScript-centric mode or in compatibility mode, but not in
	/// GDI-centric mode.
	/// </para>
	/// <para>To set the PostScript driver's mode, call the POSTSCRIPT_IDENTIFY escape function.</para>
	/// <para>The QUERYESCSUPPORT printer escape function checks the implementation of a printer escape function.</para>
	/// <para>
	/// The SPCLPASSTHROUGH2 printer escape function allows applications that print to PostScript devices using EPSPRINTING to include
	/// private PostScript procedures and other resources at the document-level save context.
	/// </para>
	/// <para>
	/// This escape is supported only for backward compatibility with Adobe Acrobat. Other applications should not use this obsolete escape.
	/// </para>
	/// <para>
	/// The application must call this escape before calling StartDoc so that the driver will cache the data for insertion at the
	/// correct point in the PostScript stream. If this escape is supported, the driver will also allow escape <c>DOWNLOADFACE</c> calls
	/// prior to <c>StartDoc</c>. The driver internally caches the data to be inserted and the data required by any escape
	/// <c>DOWNLOADFACE</c> calls prior to <c>StartDoc</c> and emits them all immediately before %%EndProlog. The sequence of
	/// SPCLPASSTHROUGH2 and <c>DOWNLOADFACE</c> calls will be preserved in the order their data is passed in, that is, a later call
	/// results in data output after an earlier call's data. The driver will consider fonts downloaded by pre- <c>StartDoc</c> escape
	/// <c>DOWNLOADFACE</c> calls as unavailable for removal during the scope of the job.
	/// </para>
	/// <para>
	/// This escape is not recorded in EMF files by the operating system, therefore applications must ensure that EMF recording is
	/// turned off for those jobs using the escape.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Sizing a JPEG or PNG Image.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-extescape int ExtEscape( HDC hdc, int iEscape, int cjInput,
	// LPCSTR lpInData, int cjOutput, LPSTR lpOutData );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "5ca74f61-75dd-4a8c-9f0f-9c1b4719c75f")]
	public static extern int ExtEscape([In, AddAsMember] HDC hdc, EscapeFunction iEscape, [Optional] int cjInput, [In, Optional] IntPtr lpInData, [Optional] int cjOutput, [Out, Optional] IntPtr lpOutData);

	/// <summary>The <c>ExtEscape</c> function enables an application to access device capabilities that are not available through GDI.</summary>
	/// <typeparam name="TIn">The type of the input structure.</typeparam>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="iEscape">
	/// The escape function to be performed. It can be one of the following or it can be an application-defined escape function.
	/// </param>
	/// <param name="lpInData">The input structure required for the specified escape.</param>
	/// <returns>
	/// The return value specifies the outcome of the function. It is greater than zero if the function is successful, except for the
	/// QUERYESCSUPPORT printer escape, which checks for implementation only. The return value is zero if the escape is not implemented. A
	/// return value less than zero indicates an error.
	/// </returns>
	/// <remarks>
	/// <note type="note">
	/// This is a blocking or synchronous function and might not return immediately. How quickly this function returns depends on
	/// run-time factors such as network status, print server configuration, and printer driver implementation—factors that are difficult to
	/// predict when writing an application. Calling this function from a thread that manages interaction with the user interface could make
	/// the application appear to be unresponsive.
	/// </note>
	/// <para>Use this function to pass a driver-defined escape value to a device.</para>
	/// </remarks>
	public static int ExtEscape<TIn>([In, AddAsMember] HDC hdc, EscapeFunction iEscape, in TIn lpInData)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(lpInData);
		return ExtEscape(hdc, iEscape, mem.Size, mem, 0, default);
	}

	/// <summary>The <c>ExtEscape</c> function enables an application to access device capabilities that are not available through GDI.</summary>
	/// <typeparam name="TIn">The type of the input structure.</typeparam>
	/// <typeparam name="TOut">The type of the output structure.</typeparam>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="iEscape">
	/// The escape function to be performed. It can be one of the following or it can be an application-defined escape function.
	/// </param>
	/// <param name="lpInData">The input structure required for the specified escape.</param>
	/// <param name="lpOutData">The structure that receives output from this escape.</param>
	/// <returns>
	/// The return value specifies the outcome of the function. It is greater than zero if the function is successful, except for the
	/// QUERYESCSUPPORT printer escape, which checks for implementation only. The return value is zero if the escape is not implemented. A
	/// return value less than zero indicates an error.
	/// </returns>
	/// <remarks>
	/// <note type="note">
	/// This is a blocking or synchronous function and might not return immediately. How quickly this function returns depends on
	/// run-time factors such as network status, print server configuration, and printer driver implementation—factors that are difficult to
	/// predict when writing an application. Calling this function from a thread that manages interaction with the user interface could make
	/// the application appear to be unresponsive.
	/// </note>
	/// <para>Use this function to pass a driver-defined escape value to a device.</para>
	/// </remarks>
	public static int ExtEscape<TIn, TOut>([In, AddAsMember] HDC hdc, EscapeFunction iEscape, in TIn lpInData, out TOut lpOutData) where TOut : struct
	{
		using var inMem = SafeCoTaskMemHandle.CreateFromStructure(lpInData);
		using SafeCoTaskMemStruct<TOut> outMem = new();
		int ret = ExtEscape(hdc, iEscape, inMem.Size, inMem, outMem.Size, outMem);
		lpOutData = outMem.Value;
		return ret;
	}

	/// <summary>The <c>ExtEscape</c> function enables an application to access device capabilities that are not available through GDI.</summary>
	/// <typeparam name="TOut">The type of the output structure.</typeparam>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="iEscape">
	/// The escape function to be performed. It can be one of the following or it can be an application-defined escape function.
	/// </param>
	/// <param name="lpOutData">The structure that receives output from this escape.</param>
	/// <param name="ignoreIn">This value is ignored and only exists to allow for the method definition to not conflict.</param>
	/// <returns>
	/// The return value specifies the outcome of the function. It is greater than zero if the function is successful, except for the
	/// QUERYESCSUPPORT printer escape, which checks for implementation only. The return value is zero if the escape is not implemented. A
	/// return value less than zero indicates an error.
	/// </returns>
	/// <remarks>
	/// <note type="note">
	/// This is a blocking or synchronous function and might not return immediately. How quickly this function returns depends on
	/// run-time factors such as network status, print server configuration, and printer driver implementation—factors that are difficult to
	/// predict when writing an application. Calling this function from a thread that manages interaction with the user interface could make
	/// the application appear to be unresponsive.
	/// </note>
	/// <para>Use this function to pass a driver-defined escape value to a device.</para>
	/// </remarks>
	public static int ExtEscape<TOut>([In, AddAsMember] HDC hdc, EscapeFunction iEscape, out TOut lpOutData, bool ignoreIn = true) where TOut : struct
	{
		using SafeCoTaskMemStruct<TOut> outMem = new();
		int ret = ExtEscape(hdc, iEscape, 0, default, outMem.Size, outMem);
		lpOutData = outMem.Value;
		return ret;
	}

	/// <summary>
	/// Helper method that determines whether the specified escape function is supported by the device context using a call to
	/// <c>ExtEscape</c> with the QUERYESCSUPPORT function.
	/// </summary>
	/// <remarks>
	/// Use this method to verify support for a particular escape function before attempting to use it with the device context. This can help
	/// prevent errors when working with device-specific features.
	/// </remarks>
	/// <param name="hdc">The handle to the device context to query for escape function support.</param>
	/// <param name="escape">The escape function to check for support in the device context.</param>
	/// <returns>true if the specified escape function is supported; otherwise, false.</returns>
	public static bool QueryEscapeSupport([In, AddAsMember] HDC hdc, EscapeFunction escape) => ExtEscape(hdc, EscapeFunction.QUERYESCSUPPORT, escape) != 0;

	/// <summary>
	/// The <c>SetAbortProc</c> function sets the application-defined abort function that allows a print job to be canceled during spooling.
	/// </summary>
	/// <param name="hdc">Handle to the device context for the print job.</param>
	/// <param name="proc">
	/// Pointer to the application-defined abort function. For more information about the callback function, see the AbortProc callback function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is greater than zero.</para>
	/// <para>If the function fails, the return value is SP_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see How to Collect Print Job Information from the User.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setabortproc int SetAbortProc( HDC hdc, ABORTPROC proc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "5b6333fc-f1c3-4c76-906c-0fd13bb73953")]
	public static extern int SetAbortProc([In, AddAsMember] HDC hdc, AbortProc proc);

	/// <summary>The <c>StartDoc</c> function starts a print job.</summary>
	/// <param name="hdc">A handle to the device context for the print job.</param>
	/// <param name="lpdi">A pointer to a DOCINFO structure containing the name of the document file and the name of the output file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is greater than zero. This value is the print job identifier for the document.</para>
	/// <para>If the function fails, the return value is less than or equal to zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>
	/// Applications should call the <c>StartDoc</c> function immediately before beginning a print job. Using this function ensures that
	/// multipage documents are not interspersed with other print jobs.
	/// </para>
	/// <para>
	/// Applications can use the value returned by <c>StartDoc</c> to retrieve or set the priority of a print job. Call the GetJob or
	/// SetJob function and supply this value as one of the required arguments.
	/// </para>
	/// <para>Examples</para>
	/// <para>For a sample program that uses this function, see How To: Print Using the GDI Print API.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-startdoca int StartDocA( HDC hdc, const DOCINFOA *lpdi );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "53143463-b9fc-4378-aea9-da6c73a7cd03")]
	public static extern int StartDoc([In, AddAsMember] HDC hdc, in DOCINFO lpdi);

	/// <summary>The <c>StartPage</c> function prepares the printer driver to accept data.</summary>
	/// <param name="hdc">A handle to the device context for the print job.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is greater than zero.</para>
	/// <para>If the function fails, the return value is less than or equal to zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>
	/// The system disables the ResetDC function between calls to the <c>StartPage</c> and EndPage functions. This means that you cannot
	/// change the device mode except at page boundaries. After calling <c>EndPage</c>, you can call <c>ResetDC</c> to change the device
	/// mode, if necessary. Note that a call to <c>ResetDC</c> resets all device context attributes back to default values.
	/// </para>
	/// <para>
	/// Neither EndPage nor <c>StartPage</c> resets the device context attributes. Device context attributes remain constant across
	/// subsequent pages. You do not need to re-select objects and set up the mapping mode again before printing the next page; however,
	/// doing so will produce the same results and reduce code differences between versions of Windows.
	/// </para>
	/// <para>Examples</para>
	/// <para>For a sample program that uses this function, see How To: Print Using the GDI Print API.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-startpage int StartPage( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b2bc0593-5eaf-40af-aa38-fbdfa1ea5f76")]
	public static extern int StartPage([In, AddAsMember] HDC hdc);

	/// <summary>
	/// The <c>DOCINFO</c> structure contains the input and output file names and other information used by the StartDoc function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-docinfoa typedef struct _DOCINFOA { int cbSize; LPCSTR
	// lpszDocName; LPCSTR lpszOutput; LPCSTR lpszDatatype; DWORD fwType; } DOCINFOA, *LPDOCINFOA;
	[PInvokeData("wingdi.h", MSDNShortId = "329bf0d9-399b-4f64-a029-361ef7558aeb")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DOCINFO(string docName)
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public int cbSize = Marshal.SizeOf<DOCINFO>();

		/// <summary>Pointer to a null-terminated string that specifies the name of the document.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszDocName = docName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of an output file. If this pointer is <c>NULL</c>, the output
		/// will be sent to the device identified by the device context handle that was passed to the StartDoc function.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpszOutput;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the type of data used to record the print job. The legal values for this
		/// member can be found by calling EnumPrintProcessorDatatypes and can include such values as raw, emf, or XPS_PASS. This member
		/// can be <c>NULL</c>. Note that the requested data type might be ignored.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpszDatatype;

		/// <summary>
		/// <para>Specifies additional information about the print job. This member must be zero or one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DI_APPBANDING</term>
		/// <term>Applications that use banding should set this flag for optimal performance during printing.</term>
		/// </item>
		/// <item>
		/// <term>DI_ROPS_READ_DESTINATION</term>
		/// <term>The application will use raster operations that involve reading from the destination surface.</term>
		/// </item>
		/// </list>
		/// </summary>
		public DI fwType;
	}

	/// <summary>The <c>DRAWPATRECT</c> structure defines a rectangle to be created.</summary>
	/// <remarks>This structure is used with the DRAWPATTERNRECT printer escape.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-drawpatrect typedef struct _DRAWPATRECT { POINT ptPosition;
	// POINT ptSize; WORD wStyle; WORD wPattern; } DRAWPATRECT, *PDRAWPATRECT;
	[PInvokeData("wingdi.h", MSDNShortId = "8b374a0e-8ad0-40d4-a082-e90aff6336ba")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRAWPATRECT
	{
		/// <summary>The upper-left corner of the rectangle, in logical units.</summary>
		public POINT ptPosition;

		/// <summary>The lower-right corner of the rectangle, in logical units.</summary>
		public POINT ptSize;

		/// <summary>
		/// <para>The style of the rectangle. It can be one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Black rectangle.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>White rectangle.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Gray rectangle. Used with wPattern.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ushort wStyle;

		/// <summary>
		/// Amount of grayness of the rectangle, as a percentage (0-100). A value of 0 means a white rectangle and 100 means a black
		/// rectangle. This is only used when <c>wStyle</c> is 2.
		/// </summary>
		public ushort wPattern;
	}

	/// <summary>
	/// The <c>PSFEATURE_CUSTPAPER</c> structure contains information about a custom paper size for a PostScript driver. This structure
	/// is used with the GET_PS_FEATURESETTING printer escape function.
	/// </summary>
	/// <remarks>
	/// For the semantics of the <c>lOrientation</c>, <c>lWidth</c>, <c>lHeight</c>, <c>lWidthOffset</c>, and <c>lHeightOffset</c>
	/// members, please refer to "Custom Page Size Parameters" in "PostScript Printer Description File Format Specification" v.4.3.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-psfeature_custpaper typedef struct _PSFEATURE_CUSTPAPER {
	// LONG lOrientation; LONG lWidth; LONG lHeight; LONG lWidthOffset; LONG lHeightOffset; } PSFEATURE_CUSTPAPER, *PPSFEATURE_CUSTPAPER;
	[PInvokeData("wingdi.h", MSDNShortId = "3858154c-425f-4333-a637-6d977caf7290")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSFEATURE_CUSTPAPER
	{
		/// <summary>
		/// Indicates the custom paper orientation. This member can be 0 to 3 if custom page size is selected. Otherwise, it is 1 and
		/// all other structure members are zero
		/// </summary>
		public int lOrientation;

		/// <summary>Custom page width, in points.</summary>
		public int lWidth;

		/// <summary>Custom page height, in points.</summary>
		public int lHeight;

		/// <summary>Custom page width offset, in points.</summary>
		public int lWidthOffset;

		/// <summary>Custom page height offset, in points.</summary>
		public int lHeightOffset;
	}

	/// <summary>
	/// The <c>PSFEATURE_OUTPUT</c> structure contains information about PostScript driver output options. This structure is used with
	/// the GET_PS_FEATURESETTING printer escape function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-psfeature_output typedef struct _PSFEATURE_OUTPUT { BOOL
	// bPageIndependent; BOOL bSetPageDevice; } PSFEATURE_OUTPUT, *PPSFEATURE_OUTPUT;
	[PInvokeData("wingdi.h", MSDNShortId = "4ff96d45-e70e-4d80-9bab-dd1d67aee8f3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSFEATURE_OUTPUT
	{
		/// <summary><c>TRUE</c> if PostScript output is page-independent or <c>FALSE</c> if PostScript output is page-dependent.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bPageIndependent;

		/// <summary>
		/// <c>TRUE</c> if printer feature code (setpagedevice's) is included or <c>FALSE</c> if all printer feature code is suppressed.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bSetPageDevice;
	}

	/// <summary>
	/// The <c>PSINJECTDATA</c> structure is a header for the input buffer used with the POSTSCRIPT_INJECTION printer escape function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-psinjectdata typedef struct _PSINJECTDATA { DWORD DataBytes;
	// WORD InjectionPoint; WORD PageNumber; } PSINJECTDATA, *PPSINJECTDATA;
	[PInvokeData("wingdi.h", MSDNShortId = "f42c8f69-7fe9-4740-b295-32ef2a5b714c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSINJECTDATA
	{
		/// <summary>
		/// The number of bytes of raw data to be injected. The raw data begins immediately following this structure. This size does not
		/// include the size of the <c>PSINJECTDATA</c> structure.
		/// </summary>
		public uint DataBytes;

		/// <summary>
		/// <para>Specifies where to inject the raw data in the PostScript output. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PSINJECT_BEGINSTREAM</term>
		/// <term>Before the first byte of job stream.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_PSADOBE</term>
		/// <term>Before %!PS-Adobe.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_PAGESATEND</term>
		/// <term>Replaces driver's %%Pages (atend).</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_PAGES</term>
		/// <term>Replaces driver's %%Pages nnn.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_DOCNEEDEDRES</term>
		/// <term>After %%DocumentNeededResources.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_DOCSUPPLIEDRES</term>
		/// <term>After %%DocumentSuppliedResources.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_PAGEORDER</term>
		/// <term>Replaces driver's %%PageOrder.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_ORIENTATION</term>
		/// <term>Replaces driver's %%Orientation.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_BOUNDINGBOX</term>
		/// <term>Replaces driver's %%BoundingBox.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_DOCUMENTPROCESSCOLORS</term>
		/// <term>Replaces driver's %%DocumentProcessColors &lt;color&gt;.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_COMMENTS</term>
		/// <term>Before %%EndComments.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_BEGINDEFAULTS</term>
		/// <term>After %%BeginDefaults.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_ENDDEFAULTS</term>
		/// <term>Before %%EndDefaults.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_BEGINPROLOG</term>
		/// <term>After %%BeginProlog.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_ENDPROLOG</term>
		/// <term>Before %%EndProlog.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_BEGINSETUP</term>
		/// <term>After %%BeginSetup.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_ENDSETUP</term>
		/// <term>Before %%EndSetup.</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_TRAILER</term>
		/// <term>After %%Trailer</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_EOF</term>
		/// <term>After %%EOF</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_ENDSTREAM</term>
		/// <term>After the last byte of job stream</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_DOCUMENTPROCESSCOLORSATEND</term>
		/// <term>Replaces driver's %%DocumentProcessColors (atend)</term>
		/// </item>
		/// <item>
		/// <term>Page level injection points</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_PAGENUMBER</term>
		/// <term>Replaces driver's %%Page</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_BEGINPAGESETUP</term>
		/// <term>After %%BeginPageSetup</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_ENDPAGESETUP</term>
		/// <term>Before %%EndPageSetup</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_PAGETRAILER</term>
		/// <term>After %%PageTrailer</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_PLATECOLOR</term>
		/// <term>Replace driver's %%PlateColor: &lt;color&gt;</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_SHOWPAGE</term>
		/// <term>Before showpage operator</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_PAGEBBOX</term>
		/// <term>Replaces driver's %%PageBoundingBox</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_ENDPAGECOMMENTS</term>
		/// <term>Before %%EndPageComments</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_VMSAVE</term>
		/// <term>Before save operator</term>
		/// </item>
		/// <item>
		/// <term>PSINJECT_VMRESTORE</term>
		/// <term>After restore operator</term>
		/// </item>
		/// </list>
		/// </summary>
		public PSINJECT InjectionPoint;

		/// <summary>
		/// The page number (starting from 1) to which the injection data is applied. Specify zero to apply the injection data to all
		/// pages. This member is meaningful only for page level injection points starting from PSINJECT_PAGENUMBER. For other injection
		/// points, set <c>PageNumber</c> to zero.
		/// </summary>
		public ushort PageNumber;
	}
}