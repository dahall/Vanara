using System.Runtime.CompilerServices;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

/// <summary>Items from the Msvfw32.dll</summary>
public static partial class Msvfw32
{
	private const uint DRV_USER = 0x4000;
	private const uint ICM_RESERVED = ICM_RESERVED_LOW;
	private const uint ICM_RESERVED_HIGH = DRV_USER + 0x2000;
	private const uint ICM_RESERVED_LOW = DRV_USER + 0x1000;
	private const uint ICM_USER = DRV_USER + 0x0000;
	private const string Lib_Msvfw32 = "msvfw32.dll";

	/// <summary>Applicable flags for the function.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibBegin")]
	[Flags]
	public enum DDF : uint
	{
		/// <summary>
		/// Last buffered bitmap needs to be redrawn. If drawing fails with this value, a buffered image is not available and a new
		/// image needs to be specified before the display can be updated.
		/// </summary>
		DDF_UPDATE = 0x0002,

		/// <summary>Use the current DC handle and the palette currently associated with the DC.</summary>
		DDF_SAME_HDC = 0x0004,

		/// <summary>
		/// Use the current drawing parameters for DrawDibDraw. Use this value only if lpbi, dxDest, dyDest, dxSrc, and dySrc have not
		/// changed since using DrawDibDraw or DrawDibBegin. This flag supersedes the DDF_SAME_DIB and DDF_SAME_SIZE flags.
		/// </summary>
		DDF_SAME_DRAW = 0x0008,

		/// <summary>
		/// Current image is not drawn, but is decompressed. DDF_UPDATE can be used later to draw the image. This flag supersedes the
		/// DDF_PREROLL flag.
		/// </summary>
		DDF_DONTDRAW = 0x0010,

		/// <summary>
		/// Allows palette animation. If this value is present, DrawDib reserves as many entries as possible by setting PC_RESERVED in
		/// the palPalEntry array entries of the LOGPALETTE structure, and the palette can be animated by using the DrawDibChangePalette
		/// function. If your application uses the DrawDibBegin function with the DrawDibDraw function, set this value with DrawDibBegin
		/// rather than DrawDibDraw.
		/// </summary>
		DDF_ANIMATE = 0x0020,

		/// <summary>
		/// Causes DrawDib to try to use an off-screen buffer so DDF_UPDATE can be used. This disables decompression and drawing
		/// directly to the screen. If DrawDib is unable to create an off-screen buffer, it will decompress or draw directly to the
		/// screen. For more information, see the DDF_UPDATE and DDF_DONTDRAW values described for DrawDibDraw.
		/// </summary>
		DDF_BUFFER = 0x0040,

		/// <summary>
		/// Draws the image by using GDI. Prohibits DrawDib functions from decompressing, stretching, or dithering the image. This
		/// strips DrawDib of capabilities that differentiate it from the StretchDIBits function.
		/// </summary>
		DDF_JUSTDRAWIT = 0x0080,

		/// <summary>Not supported.</summary>
		DDF_FULLSCREEN = 0x0100,

		/// <summary>
		/// Realizes the palette used for drawing as a background task, leaving the current palette used for the display unchanged.
		/// (This value is mutually exclusive of DDF_SAME_HDC.)
		/// </summary>
		DDF_BACKGROUNDPAL = 0x0200,

		/// <summary>this is a partial frame update, hint</summary>
		DDF_NOTKEYFRAME = 0x0400,

		/// <summary>hurry up please!</summary>
		DDF_HURRYUP = 0x0800,

		/// <summary>
		/// Always dithers the DIB to a standard palette regardless of the palette of the DIB. If your application uses DrawDibBegin
		/// with DrawDibDraw, set this value with DrawDibBegin rather than DrawDibDraw.
		/// </summary>
		DDF_HALFTONE = 0x1000,
	}

	/// <summary>Flags used for compression.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_2")]
	[Flags]
	public enum ICCOMPRESSF : uint
	{
		/// <summary>Input data should be treated as a key frame.</summary>
		ICCOMPRESS_KEYFRAME = 0x00000001
	}

	/// <summary>Applicable flags.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_3")]
	[Flags]
	public enum ICCOMPRESSFRAMESF : uint
	{
		/// <summary>Padding is used with the frame.</summary>
		ICCOMPRESSFRAMES_PADDING = 1
	}

	/// <summary>Applicable flags.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_5")]
	[Flags]
	public enum ICDECOMPRESSF : uint
	{
		/// <summary>
		/// Tries to decompress at a faster rate. When an application uses this flag, the driver should buffer the decompressed data but
		/// not draw the image.
		/// </summary>
		ICDECOMPRESS_HURRYUP = 0x80000000,

		/// <summary>Screen is being updated or refreshed.</summary>
		ICDECOMPRESS_UPDATE = 0x40000000,

		/// <summary>Current frame precedes the point in the movie where playback starts and, therefore, will not be drawn.</summary>
		ICDECOMPRESS_PREROLL = 0x20000000,

		/// <summary>Current frame does not contain data and the decompressed image should be left the same.</summary>
		ICDECOMPRESS_NULLFRAME = 0x10000000,

		/// <summary>Current frame is not a key frame.</summary>
		ICDECOMPRESS_NOTKEYFRAME = 0x08000000,
	}

	/// <summary>Flags from the AVI file index.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_8")]
	[Flags]
	public enum ICDRAWF : uint
	{
		/// <summary>Determines if the decompressor can handle the decompression. The driver does not actually decompress the data.</summary>
		ICDRAW_QUERY = 0x00000001,

		/// <summary>Draws the decompressed data on the full screen.</summary>
		ICDRAW_FULLSCREEN = 0x00000002,

		/// <summary>Draws the decompressed data to a window or a DC.</summary>
		ICDRAW_HDC = 0x00000004,

		/// <summary>Application can animate the palette.</summary>
		ICDRAW_ANIMATE = 0x00000008,

		/// <summary>Drawing is a continuation of the previous frame.</summary>
		ICDRAW_CONTINUE = 0x00000010,

		/// <summary>DC is off-screen.</summary>
		ICDRAW_MEMORYDC = 0x00000020,

		/// <summary>Current frame is being updated rather than played.</summary>
		ICDRAW_UPDATING = 0x00000040,

		/// <summary>Renders but does not draw the data.</summary>
		ICDRAW_RENDER = 0x00000080,

		/// <summary>Buffers this data off-screen; it will need to be updated.</summary>
		ICDRAW_BUFFER = 0x00000100,

		/// <summary>Data is buffered and not drawn to the screen. Use this flag for fastest decompression.</summary>
		ICDRAW_HURRYUP = 0x80000000,

		/// <summary>Updates the screen based on data previously received. In this case, lpData should be ignored.</summary>
		ICDRAW_UPDATE = 0x40000000,

		/// <summary>
		/// Current frame of video occurs before playback should start. For example, if playback will begin on frame 10, and frame 0 is
		/// the nearest previous key frame, frames 0 through 9 are sent to the driver with this flag set. The driver needs this data to
		/// display frame 10 properly.
		/// </summary>
		ICDRAW_PREROLL = 0x20000000,

		/// <summary>Current frame does not contain any data, and the previous frame should be redrawn.</summary>
		ICDRAW_NULLFRAME = 0x10000000,

		/// <summary>Current frame is not a key frame.</summary>
		ICDRAW_NOTKEYFRAME = 0x08000000,
	}

	/// <summary>Error values returns by some IC* functions.</summary>
	[PInvokeData("vfw.h")]
	public enum ICERR
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		ICERR_OK = 0,
		ICERR_DONTDRAW = 1,
		ICERR_NEWPALETTE = 2,
		ICERR_GOTOKEYFRAME = 3,
		ICERR_STOPDRAWING = 4,
		ICERR_UNSUPPORTED = -1,
		ICERR_BADFORMAT = -2,
		ICERR_MEMORY = -3,
		ICERR_INTERNAL = -4,
		ICERR_BADFLAGS = -5,
		ICERR_BADPARAM = -6,
		ICERR_BADSIZE = -7,
		ICERR_BADHANDLE = -8,
		ICERR_CANTUPDATE = -9,
		ICERR_ABORT = -10,
		ICERR_ERROR = -100,
		ICERR_BADBITDEPTH = -200,
		ICERR_BADIMAGESIZE = -201,
		ICERR_CUSTOM = -400,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>Flags defining the contents of lParam in <see cref="ICInstall"/>.</summary>
	[Flags]
	public enum ICINSTALL : uint
	{
		/// <summary></summary>
		ICINSTALL_UNICODE = 0x8000,

		/// <summary>
		/// The lParam parameter contains the address of a compressor function. This function should be structured like the DriverProc
		/// entry point function used by compressors.
		/// </summary>
		ICINSTALL_FUNCTION = 0x0001,

		/// <summary>The lParam parameter contains the address of a null-terminated string that names the compressor to install.</summary>
		ICINSTALL_DRIVER = 0x0002,

		/// <summary>lParam is a HDRVR (driver handle)</summary>
		ICINSTALL_HDRV = 0x0004,

		/// <summary>lParam is a unicode driver name</summary>
		ICINSTALL_DRIVERW = 0x8002,
	}

	/// <summary>Message codes for <see cref="ICSendMessage(HIC, uint, IntPtr, IntPtr)"/>.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSendMessage")]
	public enum ICM_Message : uint
	{
		/// <summary>Get compressor state</summary>
		ICM_GETSTATE = ICM_RESERVED + 0,

		/// <summary>Set compressor state</summary>
		ICM_SETSTATE = ICM_RESERVED + 1,

		/// <summary>Query info about the compressor</summary>
		ICM_GETINFO = ICM_RESERVED + 2,

		/// <summary>show the configure dialog</summary>
		ICM_CONFIGURE = ICM_RESERVED + 10,

		/// <summary>show the about box</summary>
		ICM_ABOUT = ICM_RESERVED + 11,

		/// <summary>get error text TBD ;Internal</summary>
		ICM_GETERRORTEXT = ICM_RESERVED + 12,

		/// <summary>get a name for a format ;Internal</summary>
		ICM_GETFORMATNAME = ICM_RESERVED + 20,

		/// <summary>cycle through formats ;Internal</summary>
		ICM_ENUMFORMATS = ICM_RESERVED + 21,

		/// <summary>get the default value for quality</summary>
		ICM_GETDEFAULTQUALITY = ICM_RESERVED + 30,

		/// <summary>get the current value for quality</summary>
		ICM_GETQUALITY = ICM_RESERVED + 31,

		/// <summary>set the default value for quality</summary>
		ICM_SETQUALITY = ICM_RESERVED + 32,

		/// <summary>Tell the driver something</summary>
		ICM_SET = ICM_RESERVED + 40,

		/// <summary>Ask the driver something</summary>
		ICM_GET = ICM_RESERVED + 41,

		/// <summary>get compress format or size</summary>
		ICM_COMPRESS_GET_FORMAT = ICM_USER + 4,

		/// <summary>get output size</summary>
		ICM_COMPRESS_GET_SIZE = ICM_USER + 5,

		/// <summary>query support for compress</summary>
		ICM_COMPRESS_QUERY = ICM_USER + 6,

		/// <summary>begin a series of compress calls.</summary>
		ICM_COMPRESS_BEGIN = ICM_USER + 7,

		/// <summary>compress a frame</summary>
		ICM_COMPRESS = ICM_USER + 8,

		/// <summary>end of a series of compress calls.</summary>
		ICM_COMPRESS_END = ICM_USER + 9,

		/// <summary>
		/// <para>
		/// The <c>ICM_DECOMPRESS_GET_FORMAT</c> message requests the output format of the decompressed data from a video decompression
		/// driver. You can send this message explicitly or by using the <c>ICDecompressGetFormat</c> macro.
		/// </para>
		/// <para><c>lpbiInput</c> - Pointer to a <c>BITMAPINFO</c> structure containing the input format.</para>
		/// <para>
		/// <c>lpbiOutput</c> - Pointer to a <c>BITMAPINFO</c> structure to contain the output format. You can specify zero to request
		/// only the size of the output format, as in the <c>ICDecompressGetFormatSize</c> macro.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>If lpbiOutput is zero, returns the size of the structure.</para>
		/// <para>If lpbiOutput is nonzero, returns ICERR_OK if successful or an error otherwise.</para>
		/// </returns>
		/// <remarks>
		/// If lpbiOutput is nonzero, the driver should fill the <c>BITMAPINFO</c> structure with the default output format
		/// corresponding to the input format specified for lpbiInput. If the compressor can produce several formats, the default format
		/// should be the one that preserves the greatest amount of information.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/multimedia/icm-decompress-get-format
		ICM_DECOMPRESS_GET_FORMAT = ICM_USER + 10,

		/// <summary>query support for dempress</summary>
		ICM_DECOMPRESS_QUERY = ICM_USER + 11,

		/// <summary>start a series of decompress calls</summary>
		ICM_DECOMPRESS_BEGIN = ICM_USER + 12,

		/// <summary>decompress a frame</summary>
		ICM_DECOMPRESS = ICM_USER + 13,

		/// <summary>end a series of decompress calls</summary>
		ICM_DECOMPRESS_END = ICM_USER + 14,

		/// <summary>fill in the DIB color table</summary>
		ICM_DECOMPRESS_SET_PALETTE = ICM_USER + 29,

		/// <summary>fill in the DIB color table</summary>
		ICM_DECOMPRESS_GET_PALETTE = ICM_USER + 30,

		/// <summary>query support for dempress</summary>
		ICM_DRAW_QUERY = ICM_USER + 31,

		/// <summary>start a series of draw calls</summary>
		ICM_DRAW_BEGIN = ICM_USER + 15,

		/// <summary>get the palette needed for drawing</summary>
		ICM_DRAW_GET_PALETTE = ICM_USER + 16,

		/// <summary>update screen with current frame ;Internal</summary>
		ICM_DRAW_UPDATE = ICM_USER + 17,

		/// <summary>start decompress clock</summary>
		ICM_DRAW_START = ICM_USER + 18,

		/// <summary>stop decompress clock</summary>
		ICM_DRAW_STOP = ICM_USER + 19,

		/// <summary>decompress a frame to screen ;Internal</summary>
		ICM_DRAW_BITS = ICM_USER + 20,

		/// <summary>end a series of draw calls</summary>
		ICM_DRAW_END = ICM_USER + 21,

		/// <summary>get value of decompress clock</summary>
		ICM_DRAW_GETTIME = ICM_USER + 32,

		/// <summary>generalized "render" message</summary>
		ICM_DRAW = ICM_USER + 33,

		/// <summary>drawing window has moved or hidden</summary>
		ICM_DRAW_WINDOW = ICM_USER + 34,

		/// <summary>set correct value for decompress clock</summary>
		ICM_DRAW_SETTIME = ICM_USER + 35,

		/// <summary>realize palette for drawing</summary>
		ICM_DRAW_REALIZE = ICM_USER + 36,

		/// <summary>clear out buffered frames</summary>
		ICM_DRAW_FLUSH = ICM_USER + 37,

		/// <summary>draw undrawn things in queue</summary>
		ICM_DRAW_RENDERBUFFER = ICM_USER + 38,

		/// <summary>start of a play</summary>
		ICM_DRAW_START_PLAY = ICM_USER + 39,

		/// <summary>end of a play</summary>
		ICM_DRAW_STOP_PLAY = ICM_USER + 40,

		/// <summary>Like ICGetDisplayFormat</summary>
		ICM_DRAW_SUGGESTFORMAT = ICM_USER + 50,

		/// <summary>for animating palette</summary>
		ICM_DRAW_CHANGEPALETTE = ICM_USER + 51,

		/// <summary>send each frame time ;Internal</summary>
		ICM_DRAW_IDLE = ICM_USER + 52,

		/// <summary>ask about prebuffering</summary>
		ICM_GETBUFFERSWANTED = ICM_USER + 41,

		/// <summary>get the default value for key frames</summary>
		ICM_GETDEFAULTKEYFRAMERATE = ICM_USER + 42,

		/// <summary>start a series of decompress calls</summary>
		ICM_DECOMPRESSEX_BEGIN = ICM_USER + 60,

		/// <summary>start a series of decompress calls</summary>
		ICM_DECOMPRESSEX_QUERY = ICM_USER + 61,

		/// <summary>decompress a frame</summary>
		ICM_DECOMPRESSEX = ICM_USER + 62,

		/// <summary>end a series of decompress calls</summary>
		ICM_DECOMPRESSEX_END = ICM_USER + 63,

		/// <summary>tell about compress to come</summary>
		ICM_COMPRESS_FRAMES_INFO = ICM_USER + 70,

		/// <summary>compress a bunch of frames ;Internal</summary>
		ICM_COMPRESS_FRAMES = ICM_USER + 71,

		/// <summary>set status callback</summary>
		ICM_SET_STATUS_PROC = ICM_USER + 72,
	}

	/// <summary>Applicable flags.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompressorChoose")]
	[Flags]
	public enum ICMF_CHOOSE : uint
	{
		/// <summary>Displays a check box and edit box to enter the frequency of key frames.</summary>
		ICMF_CHOOSE_KEYFRAME = 0x0001,

		/// <summary>Displays a check box and edit box to enter the data rate for the movie.</summary>
		ICMF_CHOOSE_DATARATE = 0x0002,

		/// <summary>
		/// Displays a button to expand the dialog box to include a preview window. The preview window shows how frames of your movie
		/// will appear when compressed with the current settings.
		/// </summary>
		ICMF_CHOOSE_PREVIEW = 0x0004,

		/// <summary>
		/// All compressors should appear in the selection list. If this flag is not specified, only the compressors that can handle the
		/// input format appear in the selection list.
		/// </summary>
		ICMF_CHOOSE_ALLCOMPRESSORS = 0x0008,
	}

	/// <summary>Applicable flags.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_11")]
	public enum ICMF_COMPVARS
	{
		/// <summary>
		/// Data in this structure is valid and has been manually entered. Set this flag before you call any function if you fill this
		/// structure manually. Do not set this flag if you let ICCompressorChoose initialize this structure.
		/// </summary>
		ICMF_COMPVARS_VALID = 0x00000001
	}

	/// <summary>Applicable flags indicating why the driver is opened.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_0")]
	public enum ICMODE : ushort
	{
		/// <summary>Driver is opened to compress data.</summary>
		ICMODE_COMPRESS = 1,

		/// <summary>Driver is opened to decompress data.</summary>
		ICMODE_DECOMPRESS = 2,

		/// <summary></summary>
		ICMODE_FASTDECOMPRESS = 3,

		/// <summary>Driver is opened for informational purposes, rather than for compression.</summary>
		ICMODE_QUERY = 4,

		/// <summary></summary>
		ICMODE_FASTCOMPRESS = 5,

		/// <summary>Device driver is opened to decompress data directly to hardware.</summary>
		ICMODE_DRAW = 8,
	}

	/// <summary>Applicable flags.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_1")]
	[Flags]
	public enum VIDCF : uint
	{
		/// <summary>Driver supports quality values.</summary>
		VIDCF_QUALITY = 0x0001,

		/// <summary>Driver supports compressing to a frame size.</summary>
		VIDCF_CRUNCH = 0x0002,

		/// <summary>Driver supports inter-frame compression.</summary>
		VIDCF_TEMPORAL = 0x0004,

		/// <summary>
		/// Driver is requesting to compress all frames. For information about compressing all frames, see the ICM_COMPRESS_FRAMES_INFO message.
		/// </summary>
		VIDCF_COMPRESSFRAMES = 0x0008,

		/// <summary>Driver supports drawing.</summary>
		VIDCF_DRAW = 0x0010,

		/// <summary>
		/// Driver can perform temporal compression and maintains its own copy of the current frame. When compressing a stream of frame
		/// data, the driver doesn't need image data from the previous frame.
		/// </summary>
		VIDCF_FASTTEMPORALC = 0x0020,

		/// <summary>
		/// Driver can perform temporal decompression and maintains its own copy of the current frame. When decompressing a stream of
		/// frame data, the driver doesn't need image data from the previous frame.
		/// </summary>
		VIDCF_FASTTEMPORALD = 0x0080,
	}

	/// <summary>The <c>DrawDib</c> function changes parameters of a DrawDib DC or initializes a new DrawDib DC.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="hdc">Handle to a DC for drawing. This parameter is optional.</param>
	/// <param name="dxDst">Width, in <c>MM_TEXT</c> client units, of the destination rectangle.</param>
	/// <param name="dyDst">Height, in <c>MM_TEXT</c> client units, of the destination rectangle.</param>
	/// <param name="lpbi">
	/// Pointer to a BITMAPINFOHEADER structure containing the image format. The color table for the DIB follows the image format and
	/// the <c>biHeight</c> member must be a positive value.
	/// </param>
	/// <param name="dxSrc">Width, in pixels, of the source rectangle.</param>
	/// <param name="dySrc">Height, in pixels, of the source rectangle.</param>
	/// <param name="wFlags">
	/// <para>Applicable flags for the function. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DDF_ANIMATE</term>
	/// <term>
	/// Allows palette animation. If this value is present, DrawDib reserves as many entries as possible by setting PC_RESERVED in the
	/// palPalEntry array entries of the LOGPALETTE structure, and the palette can be animated by using the DrawDibChangePalette
	/// function. If your application uses the DrawDibBegin function with the DrawDibDraw function, set this value with DrawDibBegin
	/// rather than DrawDibDraw.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_BACKGROUNDPAL</term>
	/// <term>
	/// Realizes the palette used for drawing as a background task, leaving the current palette used for the display unchanged. (This
	/// value is mutually exclusive of DDF_SAME_HDC.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_BUFFER</term>
	/// <term>
	/// Causes DrawDib to try to use an off-screen buffer so DDF_UPDATE can be used. This disables decompression and drawing directly to
	/// the screen. If DrawDib is unable to create an off-screen buffer, it will decompress or draw directly to the screen. For more
	/// information, see the DDF_UPDATE and DDF_DONTDRAW values described for DrawDibDraw.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_DONTDRAW</term>
	/// <term>
	/// Current image is not drawn, but is decompressed. DDF_UPDATE can be used later to draw the image. This flag supersedes the
	/// DDF_PREROLL flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_FULLSCREEN</term>
	/// <term>Not supported.</term>
	/// </item>
	/// <item>
	/// <term>DDF_HALFTONE</term>
	/// <term>
	/// Always dithers the DIB to a standard palette regardless of the palette of the DIB. If your application uses DrawDibBegin with
	/// DrawDibDraw, set this value with DrawDibBegin rather than DrawDibDraw.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_JUSTDRAWIT</term>
	/// <term>
	/// Draws the image by using GDI. Prohibits DrawDib functions from decompressing, stretching, or dithering the image. This strips
	/// DrawDib of capabilities that differentiate it from the StretchDIBits function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_SAME_DRAW</term>
	/// <term>
	/// Use the current drawing parameters for DrawDibDraw. Use this value only if lpbi, dxDest, dyDest, dxSrc, and dySrc have not
	/// changed since using DrawDibDraw or DrawDibBegin. This flag supersedes the DDF_SAME_DIB and DDF_SAME_SIZE flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_SAME_HDC</term>
	/// <term>Use the current DC handle and the palette currently associated with the DC.</term>
	/// </item>
	/// <item>
	/// <term>DDF_UPDATE</term>
	/// <term>
	/// Last buffered bitmap needs to be redrawn. If drawing fails with this value, a buffered image is not available and a new image
	/// needs to be specified before the display can be updated.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function prepares to draw a DIB specified by lpbi to the DC. The image is stretched to the size specified by dxDest and
	/// dyDest. If dxDest and dyDest are set to −1, the DIB is drawn to a 1:1 scale without stretching.
	/// </para>
	/// <para>
	/// You can update the flags of a DrawDib DC by reissuing <c>DrawDibBegin</c>, specifying the new flags, and changing at least one
	/// of the following settings: dxDest, dyDest, lpbi, dxSrc, or dySrc.
	/// </para>
	/// <para>If the parameters of <c>DrawDibBegin</c> have not changed, subsequent calls to the function have no effect.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibbegin BOOL VFWAPI DrawDibBegin( HDRAWDIB hdd, HDC hdc, int
	// dxDst, int dyDst, LPBITMAPINFOHEADER lpbi, int dxSrc, int dySrc, UINT wFlags );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibBegin")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibBegin([In] HDRAWDIB hdd, [In, Optional] HDC hdc, int dxDst, int dyDst, in BITMAPINFOHEADER lpbi, int dxSrc, int dySrc, DDF wFlags);

	/// <summary>The <c>DrawDibChangePalette</c> function sets the palette entries used for drawing DIBs.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="iStart">Starting palette entry number.</param>
	/// <param name="iLen">Number of palette entries.</param>
	/// <param name="lppe">Pointer to an array of palette entries.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function changes the physical palette only if the current DrawDib palette is realized by calling the DrawDibRealize function.
	/// </para>
	/// <para>
	/// If the color table is not changed, the next call to the DrawDibDraw function that does not specify DDF_SAME_DRAW calls the
	/// DrawDibBegin function implicitly.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibchangepalette BOOL VFWAPI DrawDibChangePalette( HDRAWDIB
	// hdd, int iStart, int iLen, LPPALETTEENTRY lppe );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibChangePalette")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibChangePalette([In] HDRAWDIB hdd, int iStart, int iLen, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] PALETTEENTRY[] lppe);

	/// <summary>The <c>DrawDibClose</c> function closes a DrawDib DC and frees the resources DrawDib allocated for it.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibclose BOOL VFWAPI DrawDibClose( HDRAWDIB hdd );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibClose")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibClose(HDRAWDIB hdd);

	/// <summary>The <c>DrawDibDraw</c> function draws a DIB to the screen.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="hdc">Handle to the DC.</param>
	/// <param name="xDst">The x-coordinate, in <c>MM_TEXT</c> client coordinates, of the upper left corner of the destination rectangle.</param>
	/// <param name="yDst">The y-coordinate, in <c>MM_TEXT</c> client coordinates, of the upper left corner of the destination rectangle.</param>
	/// <param name="dxDst">
	/// Width, in <c>MM_TEXT</c> client coordinates, of the destination rectangle. If dxDst is −1, the width of the bitmap is used.
	/// </param>
	/// <param name="dyDst">
	/// Height, in <c>MM_TEXT</c> client coordinates, of the destination rectangle. If dyDst is −1, the height of the bitmap is used.
	/// </param>
	/// <param name="lpbi">
	/// Pointer to the BITMAPINFOHEADER structure containing the image format. The color table for the DIB within
	/// <c>BITMAPINFOHEADER</c> follows the format and the <c>biHeight</c> member must be a positive value; <c>DrawDibDraw</c> will not
	/// draw inverted DIBs.
	/// </param>
	/// <param name="lpBits">Pointer to the buffer that contains the bitmap bits.</param>
	/// <param name="xSrc">
	/// The x-coordinate, in pixels, of the upper left corner of the source rectangle. The coordinates (0,0) represent the upper left
	/// corner of the bitmap.
	/// </param>
	/// <param name="ySrc">
	/// The y-coordinate, in pixels, of the upper left corner of the source rectangle. The coordinates (0,0) represent the upper left
	/// corner of the bitmap.
	/// </param>
	/// <param name="dxSrc">Width, in pixels, of the source rectangle.</param>
	/// <param name="dySrc">Height, in pixels, of the source rectangle.</param>
	/// <param name="wFlags">
	/// <para>Applicable flags for drawing. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DDF_BACKGROUNDPAL</term>
	/// <term>
	/// Realizes the palette used for drawing in the background, leaving the actual palette used for display unchanged. This value is
	/// valid only if DDF_SAME_HDC is not set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_DONTDRAW</term>
	/// <term>Current image is decompressed but not drawn. This flag supersedes the DDF_PREROLL flag.</term>
	/// </item>
	/// <item>
	/// <term>DDF_FULLSCREEN</term>
	/// <term>Not supported.</term>
	/// </item>
	/// <item>
	/// <term>DDF_HALFTONE</term>
	/// <term>
	/// Always dithers the DIB to a standard palette regardless of the palette of the DIB. If your application uses the DrawDibBegin
	/// function, set this value in DrawDibBegin rather than in DrawDibDraw.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_HURRYUP</term>
	/// <term>
	/// Data does not have to be drawn (that is, it can be dropped) and DDF_UPDATE will not be used to recall this information. DrawDib
	/// checks this value only if it is required to build the next frame; otherwise, the value is ignored.This value is usually used to
	/// synchronize video and audio. When synchronizing data, applications should send the image with this value in case the driver
	/// needs to buffer the frame to decompress subsequent frames.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_NOTKEYFRAME</term>
	/// <term>DIB data is not a key frame.</term>
	/// </item>
	/// <item>
	/// <term>DDF_SAME_HDC</term>
	/// <term>Use the current DC handle and the palette currently associated with the DC.</term>
	/// </item>
	/// <item>
	/// <term>DDF_SAME_DRAW</term>
	/// <term>
	/// Use the current drawing parameters for DrawDibDraw. Use this value only if lpbi, dxDst, dyDst, dxSrc, and dySrc have not changed
	/// since using DrawDibDraw or DrawDibBegin. DrawDibDraw typically checks the parameters, and if they have changed, DrawDibBegin
	/// prepares the DrawDib DC for drawing. This flag supersedes the DDF_SAME_DIB and DDF_SAME_SIZE flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_UPDATE</term>
	/// <term>
	/// Last buffered bitmap is to be redrawn. If drawing fails with this value, a buffered image is not available and a new image needs
	/// to be specified before the display can be updated.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// <c>DDF_DONTDRAW</c> causes <c>DrawDibDraw</c> to decompress but not display an image. A subsequent call to <c>DrawDibDraw</c>
	/// specifying <c>DDF_UPDATE</c> displays the image.
	/// </para>
	/// <para>
	/// If the DrawDib DC does not have an off-screen buffer specified, specifying <c>DDF_DONTDRAW</c> causes the frame to be drawn to
	/// the screen immediately. Subsequent calls to <c>DrawDibDraw</c> specifying <c>DDF_UPDATE</c> fail.
	/// </para>
	/// <para>
	/// Although they are set at different times, <c>DDF_UPDATE</c> and <c>DDF_DONTDRAW</c> can be used together to create composite
	/// images off-screen. When the off-screen image is complete, you can display the image by calling <c>DrawDibDraw</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibdraw BOOL VFWAPI DrawDibDraw( HDRAWDIB hdd, HDC hdc, int
	// xDst, int yDst, int dxDst, int dyDst, LPBITMAPINFOHEADER lpbi, LPVOID lpBits, int xSrc, int ySrc, int dxSrc, int dySrc, UINT
	// wFlags );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibDraw")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibDraw([In] HDRAWDIB hdd, [In] HDC hdc, int xDst, int yDst, int dxDst, int dyDst, in BITMAPINFOHEADER lpbi, [In, Optional] IntPtr lpBits, int xSrc, int ySrc, int dxSrc, int dySrc, DDF wFlags);

	/// <summary>The <c>DrawDibDraw</c> function draws a DIB to the screen.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="hdc">Handle to the DC.</param>
	/// <param name="xDst">The x-coordinate, in <c>MM_TEXT</c> client coordinates, of the upper left corner of the destination rectangle.</param>
	/// <param name="yDst">The y-coordinate, in <c>MM_TEXT</c> client coordinates, of the upper left corner of the destination rectangle.</param>
	/// <param name="dxDst">
	/// Width, in <c>MM_TEXT</c> client coordinates, of the destination rectangle. If dxDst is −1, the width of the bitmap is used.
	/// </param>
	/// <param name="dyDst">
	/// Height, in <c>MM_TEXT</c> client coordinates, of the destination rectangle. If dyDst is −1, the height of the bitmap is used.
	/// </param>
	/// <param name="lpbi">
	/// Pointer to the BITMAPINFOHEADER structure containing the image format. The color table for the DIB within
	/// <c>BITMAPINFOHEADER</c> follows the format and the <c>biHeight</c> member must be a positive value; <c>DrawDibDraw</c> will not
	/// draw inverted DIBs.
	/// </param>
	/// <param name="lpBits">Pointer to the buffer that contains the bitmap bits.</param>
	/// <param name="xSrc">
	/// The x-coordinate, in pixels, of the upper left corner of the source rectangle. The coordinates (0,0) represent the upper left
	/// corner of the bitmap.
	/// </param>
	/// <param name="ySrc">
	/// The y-coordinate, in pixels, of the upper left corner of the source rectangle. The coordinates (0,0) represent the upper left
	/// corner of the bitmap.
	/// </param>
	/// <param name="dxSrc">Width, in pixels, of the source rectangle.</param>
	/// <param name="dySrc">Height, in pixels, of the source rectangle.</param>
	/// <param name="wFlags">
	/// <para>Applicable flags for drawing. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DDF_BACKGROUNDPAL</term>
	/// <term>
	/// Realizes the palette used for drawing in the background, leaving the actual palette used for display unchanged. This value is
	/// valid only if DDF_SAME_HDC is not set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_DONTDRAW</term>
	/// <term>Current image is decompressed but not drawn. This flag supersedes the DDF_PREROLL flag.</term>
	/// </item>
	/// <item>
	/// <term>DDF_FULLSCREEN</term>
	/// <term>Not supported.</term>
	/// </item>
	/// <item>
	/// <term>DDF_HALFTONE</term>
	/// <term>
	/// Always dithers the DIB to a standard palette regardless of the palette of the DIB. If your application uses the DrawDibBegin
	/// function, set this value in DrawDibBegin rather than in DrawDibDraw.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_HURRYUP</term>
	/// <term>
	/// Data does not have to be drawn (that is, it can be dropped) and DDF_UPDATE will not be used to recall this information. DrawDib
	/// checks this value only if it is required to build the next frame; otherwise, the value is ignored.This value is usually used to
	/// synchronize video and audio. When synchronizing data, applications should send the image with this value in case the driver
	/// needs to buffer the frame to decompress subsequent frames.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_NOTKEYFRAME</term>
	/// <term>DIB data is not a key frame.</term>
	/// </item>
	/// <item>
	/// <term>DDF_SAME_HDC</term>
	/// <term>Use the current DC handle and the palette currently associated with the DC.</term>
	/// </item>
	/// <item>
	/// <term>DDF_SAME_DRAW</term>
	/// <term>
	/// Use the current drawing parameters for DrawDibDraw. Use this value only if lpbi, dxDst, dyDst, dxSrc, and dySrc have not changed
	/// since using DrawDibDraw or DrawDibBegin. DrawDibDraw typically checks the parameters, and if they have changed, DrawDibBegin
	/// prepares the DrawDib DC for drawing. This flag supersedes the DDF_SAME_DIB and DDF_SAME_SIZE flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DDF_UPDATE</term>
	/// <term>
	/// Last buffered bitmap is to be redrawn. If drawing fails with this value, a buffered image is not available and a new image needs
	/// to be specified before the display can be updated.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// <c>DDF_DONTDRAW</c> causes <c>DrawDibDraw</c> to decompress but not display an image. A subsequent call to <c>DrawDibDraw</c>
	/// specifying <c>DDF_UPDATE</c> displays the image.
	/// </para>
	/// <para>
	/// If the DrawDib DC does not have an off-screen buffer specified, specifying <c>DDF_DONTDRAW</c> causes the frame to be drawn to
	/// the screen immediately. Subsequent calls to <c>DrawDibDraw</c> specifying <c>DDF_UPDATE</c> fail.
	/// </para>
	/// <para>
	/// Although they are set at different times, <c>DDF_UPDATE</c> and <c>DDF_DONTDRAW</c> can be used together to create composite
	/// images off-screen. When the off-screen image is complete, you can display the image by calling <c>DrawDibDraw</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibdraw BOOL VFWAPI DrawDibDraw( HDRAWDIB hdd, HDC hdc, int
	// xDst, int yDst, int dxDst, int dyDst, LPBITMAPINFOHEADER lpbi, LPVOID lpBits, int xSrc, int ySrc, int dxSrc, int dySrc, UINT
	// wFlags );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibDraw")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibDraw([In] HDRAWDIB hdd, [In] HDC hdc, int xDst, int yDst, [Optional] int dxDst, [Optional] int dyDst, [In, Optional] IntPtr lpbi, [In, Optional] IntPtr lpBits, [Optional] int xSrc, [Optional] int ySrc, [Optional] int dxSrc, [Optional] int dySrc, DDF wFlags);

	/// <summary>
	/// The <c>DrawDibEnd</c> function clears the flags and other settings of a DrawDib DC that are set by the DrawDibBegin or
	/// DrawDibDraw functions.
	/// </summary>
	/// <param name="hdd">Handle to the DrawDib DC to free.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibend BOOL VFWAPI DrawDibEnd( HDRAWDIB hdd );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibEnd")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibEnd([In] HDRAWDIB hdd);

	/// <summary>The <c>DrawDibGetBuffer</c> function retrieves the location of the buffer used by DrawDib for decompression.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="lpbi">
	/// Pointer to a BITMAPINFO structure. This structure is made up of a BITMAPINFOHEADER structure and a 256-entry table defining the
	/// colors used by the bitmap.
	/// </param>
	/// <param name="dwSize">Size, in bytes, of the BITMAPINFO structure pointed to by lpbi</param>
	/// <param name="dwFlags">Reserved; must be zero.</param>
	/// <returns>
	/// Returns the address of the buffer or <c>NULL</c> if no buffer is used. if lpbr is not <c>NULL</c>, it is filled with a copy of
	/// the BITMAPINFO structure describing the buffer.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibgetbuffer LPVOID VFWAPI DrawDibGetBuffer( HDRAWDIB hdd,
	// LPBITMAPINFOHEADER lpbi, DWORD dwSize, DWORD dwFlags );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibGetBuffer")]
	public static extern IntPtr DrawDibGetBuffer([In] HDRAWDIB hdd, out BITMAPINFOHEADER lpbi, uint dwSize, uint dwFlags = 0);

	/// <summary>The <c>DrawDibGetPalette</c> function retrieves the palette used by a DrawDib DC.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <returns>Returns a handle to the palette if successful or <c>NULL</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function assumes the DrawDib DC contains a valid palette entry, implying that a call to this function must follow calls to
	/// the DrawDibDraw or DrawDibBegin functions.
	/// </para>
	/// <para>
	/// You should rarely need to call this function because you can realize the correct palette in response to a window message by
	/// using the DrawDibRealize function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibgetpalette HPALETTE VFWAPI DrawDibGetPalette( HDRAWDIB hdd );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibGetPalette")]
	public static extern SafeHPALETTE DrawDibGetPalette([In] HDRAWDIB hdd);

	/// <summary>The <c>DrawDibOpen</c> function opens the DrawDib library for use and creates a DrawDib DC for drawing.</summary>
	/// <returns>Returns a handle to a DrawDib DC if successful or <c>NULL</c> otherwise.</returns>
	/// <remarks>
	/// When drawing multiple DIBs simultaneously, create a DrawDib DC for each of the images that will be simultaneously on-screen.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibopen HDRAWDIB VFWAPI DrawDibOpen();
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibOpen")]
	public static extern SafeHDRAWDIB DrawDibOpen();

	/// <summary>The <c>DrawDibProfileDisplay</c> function determines settings for the display system when using DrawDib functions.</summary>
	/// <param name="lpbi">
	/// Pointer to a BITMAPINFOHEADER structure that contains bitmap information. You can also specify <c>NULL</c> to verify that the
	/// profile information is current. If the profile information is not current, DrawDib will rerun the profile tests to obtain a
	/// current set of information. When you call <c>DrawDibProfileDisplay</c> with this parameter set to <c>NULL</c>, the return value
	/// is meaningless.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a value that indicates the fastest drawing and stretching capabilities of the display system. This value can be zero if
	/// the bitmap format is not supported or one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PD_CAN_DRAW_DIB</term>
	/// <term>DrawDib can draw images using this format. Stretching might or might not also be supported.</term>
	/// </item>
	/// <item>
	/// <term>PD_CAN_STRETCHDIB</term>
	/// <term>DrawDib can stretch and draw images using this format.</term>
	/// </item>
	/// <item>
	/// <term>PD_STRETCHDIB_1_1_OK</term>
	/// <term>StretchDIBits draws unstretched images using this format faster than an alternative method.</term>
	/// </item>
	/// <item>
	/// <term>PD_STRETCHDIB_1_2_OK</term>
	/// <term>StretchDIBits draws stretched images (in a 1:2 ratio) using this format faster than an alternative method.</term>
	/// </item>
	/// <item>
	/// <term>PD_STRETCHDIB_1_N_OK</term>
	/// <term>StretchDIBits draws stretched images (in a 1:N ratio) using this format faster than an alternative method.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibprofiledisplay LRESULT VFWAPI DrawDibProfileDisplay(
	// LPBITMAPINFOHEADER lpbi );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibProfileDisplay")]
	public static extern IntPtr DrawDibProfileDisplay(in BITMAPINFOHEADER lpbi);

	/// <summary>The <c>DrawDibProfileDisplay</c> function determines settings for the display system when using DrawDib functions.</summary>
	/// <param name="lpbi">
	/// Pointer to a BITMAPINFOHEADER structure that contains bitmap information. You can also specify <c>NULL</c> to verify that the
	/// profile information is current. If the profile information is not current, DrawDib will rerun the profile tests to obtain a
	/// current set of information. When you call <c>DrawDibProfileDisplay</c> with this parameter set to <c>NULL</c>, the return value
	/// is meaningless.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a value that indicates the fastest drawing and stretching capabilities of the display system. This value can be zero if
	/// the bitmap format is not supported or one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PD_CAN_DRAW_DIB</term>
	/// <term>DrawDib can draw images using this format. Stretching might or might not also be supported.</term>
	/// </item>
	/// <item>
	/// <term>PD_CAN_STRETCHDIB</term>
	/// <term>DrawDib can stretch and draw images using this format.</term>
	/// </item>
	/// <item>
	/// <term>PD_STRETCHDIB_1_1_OK</term>
	/// <term>StretchDIBits draws unstretched images using this format faster than an alternative method.</term>
	/// </item>
	/// <item>
	/// <term>PD_STRETCHDIB_1_2_OK</term>
	/// <term>StretchDIBits draws stretched images (in a 1:2 ratio) using this format faster than an alternative method.</term>
	/// </item>
	/// <item>
	/// <term>PD_STRETCHDIB_1_N_OK</term>
	/// <term>StretchDIBits draws stretched images (in a 1:N ratio) using this format faster than an alternative method.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibprofiledisplay LRESULT VFWAPI DrawDibProfileDisplay(
	// LPBITMAPINFOHEADER lpbi );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibProfileDisplay")]
	public static extern IntPtr DrawDibProfileDisplay([In, Optional] IntPtr lpbi);

	/// <summary>The <c>DrawDibRealize</c> function realizes the palette of the DrawDib DC for use with the specified DC.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="hdc">Handle to the DC containing the palette.</param>
	/// <param name="fBackground">
	/// Background palette flag. If this value is nonzero, the palette is a background palette. If this value is zero and the DC is
	/// attached to a window, the logical palette becomes the foreground palette when the window has the input focus. (A DC is attached
	/// to a window when the window class style is CS_OWNDC or when the DC is obtained by using the GetDC function.)
	/// </param>
	/// <returns>
	/// Returns the number of entries in the logical palette mapped to different values in the system palette. If an error occurs or no
	/// colors were updated, it returns zero.
	/// </returns>
	/// <remarks>
	/// To select the palette of the DrawDib DC as a background palette, use the DrawDibDraw function and specify the DDF_BACKGROUNDPAL flag.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibrealize UINT VFWAPI DrawDibRealize( HDRAWDIB hdd, HDC hdc,
	// BOOL fBackground );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibRealize")]
	public static extern uint DrawDibRealize([In] HDRAWDIB hdd, [In] HDC hdc, [MarshalAs(UnmanagedType.Bool)] bool fBackground);

	/// <summary>The <c>DrawDibSetPalette</c> function sets the palette used for drawing DIBs.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="hpal">Handle to the palette. Specify <c>NULL</c> to use the default palette.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibsetpalette BOOL VFWAPI DrawDibSetPalette( HDRAWDIB hdd,
	// HPALETTE hpal );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibSetPalette")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibSetPalette([In] HDRAWDIB hdd, [In, Optional] HPALETTE hpal);

	/// <summary>The <c>DrawDibStart</c> function prepares a DrawDib DC for streaming playback.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="rate">Playback rate, in microseconds per frame.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibstart BOOL VFWAPI DrawDibStart( HDRAWDIB hdd, DWORD rate );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibStart")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibStart([In] HDRAWDIB hdd, uint rate);

	/// <summary>The <c>DrawDibStop</c> function frees the resources used by a DrawDib DC for streaming playback.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibstop BOOL VFWAPI DrawDibStop( HDRAWDIB hdd );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibStop")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibStop([In] HDRAWDIB hdd);

	/// <summary>
	/// The <c>DrawDibTime</c> function retrieves timing information about the drawing operation and is used during debug operations.
	/// </summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="lpddtime">Pointer to a DRAWDIBTIME structure.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>This function is present only in the debug version of the Microsoft Windows Software Development Kit (SDK) libraries.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibtime BOOL VFWAPI DrawDibTime( HDRAWDIB hdd, LPDRAWDIBTIME
	// lpddtime );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibTime")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DrawDibTime([In] HDRAWDIB hdd, out DRAWDIBTIME lpddtime);

	/// <summary>The <c>DrawDibUpdate</c> macro draws the last frame in the DrawDib off-screen buffer.</summary>
	/// <param name="hdd">Handle to a DrawDib DC.</param>
	/// <param name="hdc">Handle of the DC.</param>
	/// <param name="x">The x-coordinate, in MM_TEXT client coordinates, of the upper left corner of the destination rectangle.</param>
	/// <param name="y">The y-coordinate, in MM_TEXT client coordinates, of the upper left corner of the destination rectangle.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>The <c>DrawDibUpdate</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define DrawDibUpdate( hdd, hdc, x, y) \ DrawDibDraw( hdd, hdc, x, y, 0, 0, NULL, NULL, 0, 0, \ 0, 0, DDF_UPDATE)</code>
	/// </para>
	/// <para>This macro can be used to refresh an image or a portion of an image displayed by your application.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-drawdibupdate void DrawDibUpdate( hdd, hdc, x, y );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.DrawDibUpdate")]
	public static bool DrawDibUpdate([In] HDRAWDIB hdd, [In] HDC hdc, int x, int y) => DrawDibDraw(hdd, hdc, x, y, wFlags: DDF.DDF_UPDATE);

	/// <summary>
	/// The <c>GetOpenFileNamePreview</c> function selects a file by using the Open dialog box. The dialog box also allows the user to
	/// preview the currently specified AVI file. This function augments the capability found in the GetOpenFileName function.
	/// </summary>
	/// <param name="lpofn">
	/// Pointer to an <c>OPENFILENAME</c> structure used to initialize the dialog box. On return, the structure contains information
	/// about the user's file selection.
	/// </param>
	/// <returns>Returns a handle to the selected file.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines GetOpenFileNamePreview as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-getopenfilenamepreviewa BOOL VFWAPI GetOpenFileNamePreviewA(
	// LPOPENFILENAMEA lpofn );
	[DllImport(Lib_Msvfw32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.GetOpenFileNamePreviewA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetOpenFileNamePreview(ref ComDlg32.OPENFILENAME lpofn);

	/// <summary>
	/// The <c>GetSaveFileNamePreview</c> function selects a file by using the Save As dialog box. The dialog box also allows the user
	/// to preview the currently specified file. This function augments the capability found in the GetSaveFileName function.
	/// </summary>
	/// <param name="lpofn">
	/// Pointer to an <c>OPENFILENAME</c> structure used to initialize the dialog box. On return, the structure contains information
	/// about the user's file selection.
	/// </param>
	/// <returns>Returns a handle to the selected file.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines GetSaveFileNamePreview as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-getsavefilenamepreviewa BOOL VFWAPI GetSaveFileNamePreviewA(
	// LPOPENFILENAMEA lpofn );
	[DllImport(Lib_Msvfw32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.GetSaveFileNamePreviewA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetSaveFileNamePreview(ref ComDlg32.OPENFILENAME lpofn);

	/// <summary>
	/// The <c>ICAbout</c> macro notifies a video compression driver to display its About dialog box. You can use this macro or
	/// explicitly call the ICM_ABOUT message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <param name="hwnd">
	/// <para>Handle of the parent window of the displayed dialog box.</para>
	/// <para>
	/// You can also determine if a driver has an About dialog box by specifying -1 in this parameter, as in the ICQueryAbout macro. The
	/// driver returns ICERR_OK if it has an About dialog box or ICERR_UNSUPPORTED otherwise.
	/// </para>
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icabout void ICAbout( hic, hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICAbout")]
	public static ICERR ICAbout(HIC hic, HWND hwnd) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_ABOUT, (IntPtr)hwnd).ToInt32();

	/// <summary>The <c>ICClose</c> function closes a compressor or decompressor.</summary>
	/// <param name="hic">Handle to a compressor or decompressor.</param>
	/// <returns>Returns ICERR_OK if successful or an error otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icclose LRESULT VFWAPI ICClose( HIC hic );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICClose")]
	public static extern IntPtr ICClose(HIC hic);

	/// <summary>The <c>ICCompress</c> function compresses a single video image.</summary>
	/// <param name="hic">Handle to the compressor to use.</param>
	/// <param name="dwFlags">
	/// <para>Compression flag. The following value is defined:</para>
	/// <para>ICCOMPRESS_KEYFRAME</para>
	/// <para>Compressor should make this frame a key frame.</para>
	/// </param>
	/// <param name="lpbiOutput">Pointer to a BITMAPINFOHEADER structure containing the output format.</param>
	/// <param name="lpData">Pointer to an output buffer large enough to contain a compressed frame.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFOHEADER structure containing the input format.</param>
	/// <param name="lpBits">Pointer to the input buffer.</param>
	/// <param name="lpckid">Reserved; do not use.</param>
	/// <param name="lpdwFlags">
	/// <para>Pointer to the return flags used in the AVI index. The following value is defined:</para>
	/// <para>AVIIF_KEYFRAME</para>
	/// <para>Current frame is a key frame.</para>
	/// </param>
	/// <param name="lFrameNum">Frame number.</param>
	/// <param name="dwFrameSize">
	/// <para>
	/// Requested frame size, in bytes. Specify a nonzero value if the compressor supports a suggested frame size, as indicated by the
	/// presence of the <c>VIDCF_CRUNCH</c> flag returned by the ICGetInfo function. If this flag is not set or a data rate for the
	/// frame is not specified, specify zero for this parameter.
	/// </para>
	/// <para>
	/// A compressor might have to sacrifice image quality or make some other trade-off to obtain the size goal specified in this parameter.
	/// </para>
	/// </param>
	/// <param name="dwQuality">
	/// Requested quality value for the frame. Specify a nonzero value if the compressor supports a suggested quality value, as
	/// indicated by the presence of the <c>VIDCF_QUALITY</c> flag returned by ICGetInfo. Otherwise, specify zero for this parameter.
	/// </param>
	/// <param name="lpbiPrev">Pointer to a BITMAPINFOHEADER structure containing the format of the previous frame.</param>
	/// <param name="lpPrev">
	/// Pointer to the uncompressed image of the previous frame. This parameter is not used for fast temporal compression. Specify
	/// <c>NULL</c> for this parameter when compressing a key frame, if the compressor does not support temporal compression, or if the
	/// compressor does not require an external buffer to store the format and data of the previous image.
	/// </param>
	/// <returns>Returns <c>ICERR_OK</c> if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// You can obtain the required by size of the output buffer by sending the ICM_COMPRESS_GET_SIZE message (or by using the
	/// ICCompressGetSize macro).
	/// </para>
	/// <para>
	/// The compressor sets the contents of lpdwFlags to <c>AVIIF_KEYFRAME</c> when it creates a key frame. If your application creates
	/// AVI files, it should save the information returned for lpckid and lpdwFlags in the file.
	/// </para>
	/// <para>
	/// Compressors use lpbiPrev and lpPrev to perform temporal compression and require an external buffer to store the format and data
	/// of the previous frame. Specify <c>NULL</c> for lpbiPrev and lpPrev when compressing a key frame, when performing fast
	/// compression, or if the compressor has its own buffer to store the format and data of the previous image. Specify non-
	/// <c>NULL</c> values for these parameters if ICGetInfo returns the <c>VIDCF_TEMPORAL</c> flag, the compressor is performing normal
	/// compression, and the frame to compress is not a key frame.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompress DWORD VFWAPIV ICCompress( HIC hic, DWORD dwFlags,
	// LPBITMAPINFOHEADER lpbiOutput, LPVOID lpData, LPBITMAPINFOHEADER lpbiInput, LPVOID lpBits, LPDWORD lpckid, LPDWORD lpdwFlags,
	// LONG lFrameNum, DWORD dwFrameSize, DWORD dwQuality, LPBITMAPINFOHEADER lpbiPrev, LPVOID lpPrev );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompress")]
	public static extern ICERR ICCompress([In] HIC hic, ICCOMPRESSF dwFlags, in BITMAPINFOHEADER lpbiOutput, [Out] IntPtr lpData,
		in BITMAPINFOHEADER lpbiInput, [In] IntPtr lpBits, [Out, Optional] IntPtr lpckid, out AviFil32.AVIIF lpdwFlags, int lFrameNum, uint dwFrameSize,
		uint dwQuality, in BITMAPINFOHEADER lpbiPrev, [In, Optional] IntPtr lpPrev);

	/// <summary>The <c>ICCompress</c> function compresses a single video image.</summary>
	/// <param name="hic">Handle to the compressor to use.</param>
	/// <param name="dwFlags">
	/// <para>Compression flag. The following value is defined:</para>
	/// <para>ICCOMPRESS_KEYFRAME</para>
	/// <para>Compressor should make this frame a key frame.</para>
	/// </param>
	/// <param name="lpbiOutput">Pointer to a BITMAPINFOHEADER structure containing the output format.</param>
	/// <param name="lpData">Pointer to an output buffer large enough to contain a compressed frame.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFOHEADER structure containing the input format.</param>
	/// <param name="lpBits">Pointer to the input buffer.</param>
	/// <param name="lpckid">Reserved; do not use.</param>
	/// <param name="lpdwFlags">
	/// <para>Pointer to the return flags used in the AVI index. The following value is defined:</para>
	/// <para>AVIIF_KEYFRAME</para>
	/// <para>Current frame is a key frame.</para>
	/// </param>
	/// <param name="lFrameNum">Frame number.</param>
	/// <param name="dwFrameSize">
	/// <para>
	/// Requested frame size, in bytes. Specify a nonzero value if the compressor supports a suggested frame size, as indicated by the
	/// presence of the <c>VIDCF_CRUNCH</c> flag returned by the ICGetInfo function. If this flag is not set or a data rate for the
	/// frame is not specified, specify zero for this parameter.
	/// </para>
	/// <para>
	/// A compressor might have to sacrifice image quality or make some other trade-off to obtain the size goal specified in this parameter.
	/// </para>
	/// </param>
	/// <param name="dwQuality">
	/// Requested quality value for the frame. Specify a nonzero value if the compressor supports a suggested quality value, as
	/// indicated by the presence of the <c>VIDCF_QUALITY</c> flag returned by ICGetInfo. Otherwise, specify zero for this parameter.
	/// </param>
	/// <param name="lpbiPrev">Pointer to a BITMAPINFOHEADER structure containing the format of the previous frame.</param>
	/// <param name="lpPrev">
	/// Pointer to the uncompressed image of the previous frame. This parameter is not used for fast temporal compression. Specify
	/// <c>NULL</c> for this parameter when compressing a key frame, if the compressor does not support temporal compression, or if the
	/// compressor does not require an external buffer to store the format and data of the previous image.
	/// </param>
	/// <returns>Returns <c>ICERR_OK</c> if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// You can obtain the required by size of the output buffer by sending the ICM_COMPRESS_GET_SIZE message (or by using the
	/// ICCompressGetSize macro).
	/// </para>
	/// <para>
	/// The compressor sets the contents of lpdwFlags to <c>AVIIF_KEYFRAME</c> when it creates a key frame. If your application creates
	/// AVI files, it should save the information returned for lpckid and lpdwFlags in the file.
	/// </para>
	/// <para>
	/// Compressors use lpbiPrev and lpPrev to perform temporal compression and require an external buffer to store the format and data
	/// of the previous frame. Specify <c>NULL</c> for lpbiPrev and lpPrev when compressing a key frame, when performing fast
	/// compression, or if the compressor has its own buffer to store the format and data of the previous image. Specify non-
	/// <c>NULL</c> values for these parameters if ICGetInfo returns the <c>VIDCF_TEMPORAL</c> flag, the compressor is performing normal
	/// compression, and the frame to compress is not a key frame.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompress DWORD VFWAPIV ICCompress( HIC hic, DWORD dwFlags,
	// LPBITMAPINFOHEADER lpbiOutput, LPVOID lpData, LPBITMAPINFOHEADER lpbiInput, LPVOID lpBits, LPDWORD lpckid, LPDWORD lpdwFlags,
	// LONG lFrameNum, DWORD dwFrameSize, DWORD dwQuality, LPBITMAPINFOHEADER lpbiPrev, LPVOID lpPrev );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompress")]
	public static extern ICERR ICCompress([In] HIC hic, ICCOMPRESSF dwFlags, in BITMAPINFOHEADER lpbiOutput, [Out] IntPtr lpData,
		in BITMAPINFOHEADER lpbiInput, [In] IntPtr lpBits, [Out, Optional] IntPtr lpckid, out AviFil32.AVIIF lpdwFlags, int lFrameNum, uint dwFrameSize,
		uint dwQuality, [In, Optional] IntPtr lpbiPrev, [In, Optional] IntPtr lpPrev);

	/// <summary>
	/// The ICCompressBegin macro notifies a video compression driver to prepare to compress data. You can use this macro or explicitly
	/// call the ICM_COMPRESS_BEGIN message.
	/// </summary>
	/// <param name="hic">Handle to a compressor.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFO structure containing the input format.</param>
	/// <param name="lpbiOutput">Pointer to a BITMAPINFO structure containing the output format.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The driver should allocate and initialize any tables or memory that it needs for compressing the data formats when it receives
	/// the ICM_COMPRESS message.
	/// </para>
	/// <para>
	/// VCM saves the settings of the most recent <c>ICCompressBegin</c> macro. The <c>ICCompressBegin</c> and <c>ICCompressEnd</c>
	/// messages do not nest. If your driver receives <c>ICM_COMPRESS_BEGIN</c> before compression is stopped with
	/// <c>ICM_COMPRESS_END</c>, it should restart compression with new parameters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompressbegin void ICCompressBegin( hic, lpbiInput, lpbiOutput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompressBegin")]
	public static ICERR ICCompressBegin(HIC hic, in BITMAPINFO lpbiInput, in BITMAPINFO lpbiOutput) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_COMPRESS_BEGIN, lpbiInput, lpbiOutput).ToInt32();

	/// <summary>
	/// The <c>ICCompressEnd</c> macro notifies a video compression driver to end compression and free resources allocated for
	/// compression. You can use this macro or explicitly call the ICM_COMPRESS_END message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// VCM saves the settings of the most recent <c>ICCompressBegin</c> macro. <c>ICCompressBegin</c> and <c>ICCompressEnd</c> do not
	/// nest. If your driver receives the <c>ICM_COMPRESS_BEGIN</c> message before compression is stopped with the
	/// <c>ICM_COMPRESS_END</c> message, it should restart compression with new parameters.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompressend void ICCompressEnd( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompressEnd")]
	public static ICERR ICCompressEnd(HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_COMPRESS_END).ToInt32();

	/// <summary>
	/// The <c>ICCompressGetFormat</c> macro requests the output format of the compressed data from a video compression driver. You can
	/// use this macro or explicitly call the ICM_COMPRESS_GET_FORMAT message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFO structure containing the input format.</param>
	/// <param name="lpbiOutput">Pointer to a BITMAPINFO structure containing the output format.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// If lpbiOutput is nonzero, the driver should fill the <c>BITMAPINFO</c> structure with the default output format corresponding to
	/// the input format specified for lpbiInput. If the compressor can produce several formats, the default format should be the one
	/// that preserves the greatest amount of information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompressgetformat void ICCompressGetFormat( hic, lpbiInput,
	// lpbiOutput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompressGetFormat")]
	public static ICERR ICCompressGetFormat(HIC hic, in BITMAPINFO lpbiInput, in BITMAPINFO lpbiOutput)
	{
		using var dw1 = SafeCoTaskMemHandle.CreateFromStructure(lpbiInput);
		using var dw2 = SafeCoTaskMemHandle.CreateFromStructure(lpbiOutput);
		return (ICERR)ICSendMessage(hic, ICM_Message.ICM_COMPRESS_GET_FORMAT, dw1, dw2).ToInt32();
	}

	/// <summary>
	/// The <c>ICCompressGetFormatSize</c> macro requests the size of the output format of the compressed data from a video compression
	/// driver. You can use this macro or explicitly call the ICM_COMPRESS_GET_FORMAT message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <param name="lpbi">Pointer to a <c>BITMAPINFO</c> structure containing the input format.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompressgetformatsize void ICCompressGetFormatSize( hic, lpbi );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompressGetFormatSize")]
	public static int ICCompressGetFormatSize(HIC hic, in BITMAPINFO lpbi)
	{
		using var dw1 = SafeCoTaskMemHandle.CreateFromStructure(lpbi);
		return ICSendMessage(hic, ICM_Message.ICM_COMPRESS_GET_FORMAT, dw1).ToInt32();
	}

	/// <summary>
	/// The <c>ICCompressGetSize</c> macro requests that the video compression driver supply the maximum size of one frame of data when
	/// compressed into the specified output format. You can use this macro or explicitly call the ICM_COMPRESS_GET_SIZE message.
	/// </summary>
	/// <param name="hic">Handle to a compressor.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFO structure containing the input format.</param>
	/// <param name="lpbiOutput">Pointer to a BITMAPINFO structure containing the output format.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Typically, applications send this message to determine how large a buffer to allocate for the compressed frame.</para>
	/// <para>The driver should calculate the size of the largest possible frame based on the input and output formats.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompressgetsize void ICCompressGetSize( hic, lpbiInput,
	// lpbiOutput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompressGetSize")]
	public static int ICCompressGetSize(HIC hic, in BITMAPINFO lpbiInput, in BITMAPINFO lpbiOutput)
	{
		using var dw1 = SafeCoTaskMemHandle.CreateFromStructure(lpbiInput);
		using var dw2 = SafeCoTaskMemHandle.CreateFromStructure(lpbiOutput);
		return ICSendMessage(hic, ICM_Message.ICM_COMPRESS_GET_SIZE, dw1, dw2).ToInt32();
	}

	/// <summary>
	/// The <c>ICCompressorChoose</c> function displays a dialog box in which a user can select a compressor. This function can display
	/// all registered compressors or list only the compressors that support a specific format.
	/// </summary>
	/// <param name="hwnd">Handle to a parent window for the dialog box.</param>
	/// <param name="uiFlags">
	/// <para>Applicable flags. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICMF_CHOOSE_ALLCOMPRESSORS</term>
	/// <term>
	/// All compressors should appear in the selection list. If this flag is not specified, only the compressors that can handle the
	/// input format appear in the selection list.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICMF_CHOOSE_DATARATE</term>
	/// <term>Displays a check box and edit box to enter the data rate for the movie.</term>
	/// </item>
	/// <item>
	/// <term>ICMF_CHOOSE_KEYFRAME</term>
	/// <term>Displays a check box and edit box to enter the frequency of key frames.</term>
	/// </item>
	/// <item>
	/// <term>ICMF_CHOOSE_PREVIEW</term>
	/// <term>
	/// Displays a button to expand the dialog box to include a preview window. The preview window shows how frames of your movie will
	/// appear when compressed with the current settings.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvIn">
	/// Uncompressed data input format. Only compressors that support the specified data input format are included in the compressor
	/// list. This parameter is optional.
	/// </param>
	/// <param name="lpData">
	/// Pointer to an AVI stream interface to use in the preview window. You must specify a video stream. This parameter is optional.
	/// </param>
	/// <param name="pc">Pointer to a COMPVARS structure. The information returned initializes the structure for use with other functions.</param>
	/// <param name="lpszTitle">Pointer to a null-terminated string containing a title for the dialog box. This parameter is optional.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if the user chooses a compressor and presses OK. Returns <c>FALSE</c> on error or if the user presses CANCEL.
	/// </returns>
	/// <remarks>
	/// Before using this function, set the <c>cbSize</c> member of the COMPVARS structure to the size of the structure. Initialize the
	/// rest of the structure to zeros unless you want to specify some valid defaults for the dialog box. If specifying defaults, set
	/// the dwFlags member to ICMF_COMPVARS_VALID and initialize the other members of the structure. For more information about
	/// initializing the structure, see the ICSeqCompressFrameStart function and <c>COMPVARS</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompressorchoose BOOL VFWAPI ICCompressorChoose( HWND hwnd, UINT
	// uiFlags, LPVOID pvIn, LPVOID lpData, PCOMPVARS pc, StrPtrAnsi lpszTitle );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompressorChoose")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ICCompressorChoose([In, Optional] HWND hwnd, ICMF_CHOOSE uiFlags, [In, Optional] IntPtr pvIn, [In, Optional] IntPtr lpData,
		ref COMPVARS pc, [Optional, MarshalAs(UnmanagedType.LPStr)] string? lpszTitle);

	/// <summary>The <c>ICCompressorFree</c> function frees the resources in the COMPVARS structure used by other VCM functions.</summary>
	/// <param name="pc">Pointer to the COMPVARS structure containing the resources to be freed.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// Use this function to release the resources in the COMPVARS structure after using the ICCompressorChoose,
	/// ICSeqCompressFrameStart, ICSeqCompressFrame, and ICSeqCompressFrameEnd functions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompressorfree void VFWAPI ICCompressorFree( PCOMPVARS pc );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompressorFree")]
	public static extern void ICCompressorFree(in COMPVARS pc);

	/// <summary>
	/// The <c>ICCompressQuery</c> macro queries a video compression driver to determine if it supports a specific input format or if it
	/// can compress a specific input format to a specific output format. You can use this macro or explicitly call the
	/// ICM_COMPRESS_QUERY message.
	/// </summary>
	/// <param name="hic">Handle to a compressor.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFO structure containing the input format.</param>
	/// <param name="lpbiOutput">
	/// Pointer to a BITMAPINFO structure containing the output format. You can specify zero for this parameter to indicate any output
	/// format is acceptable.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// When a driver receives this message, it should examine the BITMAPINFO structure associated with lpbiInput to determine if it can
	/// compress the input format.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iccompressquery void ICCompressQuery( hic, lpbiInput, lpbiOutput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICCompressQuery")]
	public static ICERR ICCompressQuery(HIC hic, in BITMAPINFO lpbiInput, in BITMAPINFO lpbiOutput)
	{
		using var dw1 = SafeCoTaskMemHandle.CreateFromStructure(lpbiInput);
		using var dw2 = SafeCoTaskMemHandle.CreateFromStructure(lpbiOutput);
		return (ICERR)ICSendMessage(hic, ICM_Message.ICM_COMPRESS_QUERY, dw1, dw2).ToInt32();
	}

	/// <summary>
	/// The <c>ICConfigure</c> macro notifies a video compression driver to display its configuration dialog box. You can use this macro
	/// or explicitly send the ICM_CONFIGURE message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <param name="hwnd">Handle of the parent window of the displayed dialog box.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// The ICM_CONFIGURE message is different from the DRV_CONFIGURE message used for hardware configuration. The dialog box for this
	/// message should let the user set and edit the internal state referenced by the ICGetState and ICSetState macros. For example,
	/// this dialog box can let the user change parameters affecting the quality level and other similar compression options.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icconfigure void ICConfigure( hic, hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICConfigure")]
	public static ICERR ICConfigure(HIC hic, HWND hwnd) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_CONFIGURE, (IntPtr)hwnd).ToInt32();

	/// <summary>The <c>ICDecompress</c> function decompresses a single video frame.</summary>
	/// <param name="hic">Handle to the decompressor to use.</param>
	/// <param name="dwFlags">
	/// <para>Applicable decompression flags. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICDECOMPRESS_HURRYUP</term>
	/// <term>
	/// Tries to decompress at a faster rate. When an application uses this flag, the driver should buffer the decompressed data but not
	/// draw the image.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_NOTKEYFRAME</term>
	/// <term>Current frame is not a key frame.</term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_NULLFRAME</term>
	/// <term>Current frame does not contain data and the decompressed image should be left the same.</term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_PREROLL</term>
	/// <term>Current frame precedes the point in the movie where playback starts and, therefore, will not be drawn.</term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_UPDATE</term>
	/// <term>Screen is being updated or refreshed.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpbiFormat">Pointer to a BITMAPINFOHEADER structure containing the format of the compressed data.</param>
	/// <param name="lpData">Pointer to the input data.</param>
	/// <param name="lpbi">Pointer to a BITMAPINFOHEADER structure containing the output format.</param>
	/// <param name="lpBits">Pointer to a buffer that is large enough to contain the decompressed data.</param>
	/// <returns>Returns ICERR_OK if successful or an error otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompress DWORD VFWAPIV ICDecompress( HIC hic, DWORD dwFlags,
	// LPBITMAPINFOHEADER lpbiFormat, LPVOID lpData, LPBITMAPINFOHEADER lpbi, LPVOID lpBits );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompress")]
	public static extern ICERR ICDecompress([In] HIC hic, ICDECOMPRESSF dwFlags, in BITMAPINFOHEADER lpbiFormat, [In] IntPtr lpData, in BITMAPINFOHEADER lpbi, [Out] IntPtr lpBits);

	/// <summary>
	/// The <c>ICDecompressBegin</c> macro notifies a video decompression driver to prepare to decompress data. You can use this macro
	/// or explicitly call the ICM_DECOMPRESS_BEGIN message.
	/// </summary>
	/// <param name="hic">Handle to a decompressor.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFO structure containing the input format.</param>
	/// <param name="lpbiOutput">Pointer to a BITMAPINFO structure containing the output format.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// When the driver receives this message, it should allocate buffers and do any time-consuming operations so that it can process
	/// ICM_DECOMPRESS messages efficiently.
	/// </para>
	/// <para>
	/// The <c>ICDecompressBegin</c> and ICDecompressEnd macros do not nest. If your driver receives ICM_DECOMPRESS_BEGIN before
	/// decompression is stopped with ICM_DECOMPRESS_END, it should restart decompression with new parameters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressbegin void ICDecompressBegin( hic, lpbiInput,
	// lpbiOutput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressBegin")]
	public static ICERR ICDecompressBegin([In] HIC hic, in BITMAPINFOHEADER lpbiInput, in BITMAPINFOHEADER lpbiOutput) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESS_BEGIN, lpbiInput, lpbiOutput).ToInt32();

	/// <summary>
	/// The <c>ICDecompressEnd</c> macro notifies a video decompression driver to end decompression and free resources allocated for
	/// decompression. You can use this macro or explicitly call the ICM_DECOMPRESS_END message.
	/// </summary>
	/// <param name="hic">Handle to a decompressor.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The driver should free any resources allocated for the ICM_DECOMPRESS_BEGIN message.</para>
	/// <para>
	/// The ICDecompressBegin and <c>ICDecompressEnd</c> macros do not nest. If your driver receives ICM_DECOMPRESS_BEGIN before
	/// decompression is stopped with ICM_DECOMPRESS_END, it should restart decompression with new parameters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressend void ICDecompressEnd( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressEnd")]
	public static ICERR ICDecompressEnd([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESS_END).ToInt32();

	/// <summary>The <c>ICDecompressEx</c> function decompresses a single video frame.</summary>
	/// <param name="hic">Handle to the decompressor.</param>
	/// <param name="dwFlags">
	/// <para>Decompression flags. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICDECOMPRESS_HURRYUP</term>
	/// <term>
	/// Tries to decompress at a faster rate. When an application uses this flag, the driver should buffer the decompressed data but not
	/// draw the image.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_NOTKEYFRAME</term>
	/// <term>Current frame is not a key frame.</term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_NULLFRAME</term>
	/// <term>Current frame does not contain data and the decompressed image should be left the same.</term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_PREROLL</term>
	/// <term>Current frame precedes the point in the movie where playback starts and, therefore, will not be drawn.</term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_UPDATE</term>
	/// <term>Screen is being updated or refreshed.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpbiSrc">Pointer to a BITMAPINFOHEADER structure containing the format of the compressed data.</param>
	/// <param name="lpSrc">Pointer to the input data.</param>
	/// <param name="xSrc">The x-coordinate of the source rectangle for the DIB specified by lpbiSrc.</param>
	/// <param name="ySrc">The y-coordinate of the source rectangle for the DIB specified by lpbiSrc.</param>
	/// <param name="dxSrc">Width of the source rectangle.</param>
	/// <param name="dySrc">Height of the source rectangle.</param>
	/// <param name="lpbiDst">Pointer to a BITMAPINFOHEADER structure containing the output format.</param>
	/// <param name="lpDst">Pointer to a buffer that is large enough to contain the decompressed data.</param>
	/// <param name="xDst">The x-coordinate of the destination rectangle for the DIB specified by lpbiDst.</param>
	/// <param name="yDst">The y-coordinate of the destination rectangle for the DIB specified by lpbiDst.</param>
	/// <param name="dxDst">Width of the destination rectangle.</param>
	/// <param name="dyDst">Height of the destination rectangle.</param>
	/// <returns>Returns <c>ICERR_OK</c> if successful or an error otherwise.</returns>
	/// <remarks>
	/// Typically, applications use the <c>ICDECOMPRESS_PREROLL</c> flag to seek to a key frame in a compressed stream. The flag is sent
	/// with the key frame and with subsequent frames required to decompress the desired frame.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressex LRESULT VFWAPI_INLINE ICDecompressEx( HIC hic, DWORD
	// dwFlags, LPBITMAPINFOHEADER lpbiSrc, LPVOID lpSrc, int xSrc, int ySrc, int dxSrc, int dySrc, LPBITMAPINFOHEADER lpbiDst, LPVOID
	// lpDst, int xDst, int yDst, int dxDst, int dyDst );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressEx")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ICERR ICDecompressEx([In] HIC hic, ICDECOMPRESSF dwFlags, in BITMAPINFOHEADER lpbiSrc, [In] IntPtr lpSrc, int xSrc, int ySrc,
		int dxSrc, int dySrc, in BITMAPINFOHEADER lpbiDst, [Out] IntPtr lpDst, int xDst, int yDst, int dxDst, int dyDst)
	{
		unsafe
		{
			fixed (void* pIn = &lpbiSrc, pOut = &lpbiDst)
			{
				ICDECOMPRESSEX ic = new()
				{
					dwFlags = dwFlags,
					lpbiSrc = (IntPtr)pIn,
					lpSrc = lpSrc,
					xSrc = xSrc,
					ySrc = ySrc,
					dxSrc = dxSrc,
					dySrc = dySrc,
					lpbiDst = (IntPtr)pOut,
					lpDst = lpDst,
					xDst = xDst,
					yDst = yDst,
					dxDst = dxDst,
					dyDst = dyDst
				};

				// note that ICM swaps round the length and pointer length in lparam2, pointer in lparam1
				return (ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESSEX, (IntPtr)(void*)&ic, (IntPtr)Marshal.SizeOf(ic)).ToInt32();
			}
		}
	}

	/// <summary>The <c>ICDecompressExBegin</c> function prepares a decompressor for decompressing data.</summary>
	/// <param name="hic">Handle to the decompressor to use.</param>
	/// <param name="dwFlags">
	/// <para>Decompression flags. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICDECOMPRESS_HURRYUP</term>
	/// <term>
	/// Tries to decompress at a faster rate. When an application uses this flag, the driver should buffer the decompressed data but not
	/// draw the image.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_NOTKEYFRAME</term>
	/// <term>Current frame is not a key frame.</term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_NULLFRAME</term>
	/// <term>Current frame does not contain data and the decompressed image should be left the same.</term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_PREROLL</term>
	/// <term>Current frame precedes the point in the movie where playback starts and, therefore, will not be drawn.</term>
	/// </item>
	/// <item>
	/// <term>ICDECOMPRESS_UPDATE</term>
	/// <term>Screen is being updated or refreshed.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpbiSrc">Pointer to a BITMAPINFOHEADER structure containing the format of the compressed data.</param>
	/// <param name="lpSrc">Pointer to the input data.</param>
	/// <param name="xSrc">The x-coordinate of the source rectangle for the DIB specified by lpbiSrc.</param>
	/// <param name="ySrc">The y-coordinate of the source rectangle for the DIB specified by lpbiSrc.</param>
	/// <param name="dxSrc">Width of the source rectangle.</param>
	/// <param name="dySrc">Height of the source rectangle.</param>
	/// <param name="lpbiDst">Pointer to a BITMAPINFOHEADER structure containing the output format.</param>
	/// <param name="lpDst">Pointer to a buffer that is large enough to contain the decompressed data.</param>
	/// <param name="xDst">The x-coordinate of the destination rectangle for the DIB specified by lpbiDst.</param>
	/// <param name="yDst">The y-coordinate of the destination rectangle for the DIB specified by lpbiDst.</param>
	/// <param name="dxDst">Width of the destination rectangle.</param>
	/// <param name="dyDst">Height of the destination rectangle.</param>
	/// <returns>Returns <c>ICERR_OK</c> if successful or an error otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressexbegin LRESULT VFWAPI_INLINE ICDecompressExBegin( HIC
	// hic, DWORD dwFlags, LPBITMAPINFOHEADER lpbiSrc, LPVOID lpSrc, int xSrc, int ySrc, int dxSrc, int dySrc, LPBITMAPINFOHEADER
	// lpbiDst, LPVOID lpDst, int xDst, int yDst, int dxDst, int dyDst );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressExBegin")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ICERR ICDecompressExBegin([In] HIC hic, ICDECOMPRESSF dwFlags, in BITMAPINFOHEADER lpbiSrc, [In] IntPtr lpSrc, int xSrc, int ySrc,
		int dxSrc, int dySrc, in BITMAPINFOHEADER lpbiDst, [Out] IntPtr lpDst, int xDst, int yDst, int dxDst, int dyDst)
	{
		unsafe
		{
			fixed (void* pIn = &lpbiSrc, pOut = &lpbiDst)
			{
				ICDECOMPRESSEX ic = new()
				{
					dwFlags = dwFlags,
					lpbiSrc = (IntPtr)pIn,
					lpSrc = lpSrc,
					xSrc = xSrc,
					ySrc = ySrc,
					dxSrc = dxSrc,
					dySrc = dySrc,
					lpbiDst = (IntPtr)pOut,
					lpDst = lpDst,
					xDst = xDst,
					yDst = yDst,
					dxDst = dxDst,
					dyDst = dyDst
				};

				// note that ICM swaps round the length and pointer length in lparam2, pointer in lparam1
				return (ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESSEX_BEGIN, (IntPtr)(void*)&ic, (IntPtr)Marshal.SizeOf(ic)).ToInt32();
			}
		}
	}

	/// <summary>
	/// The <c>ICDecompressExEnd</c> macro notifies a video decompression driver to end decompression and free resources allocated for
	/// decompression. You can use this macro or explicitly call the ICM_DECOMPRESSEX_END message.
	/// </summary>
	/// <param name="hic">Handle to a decompressor.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The driver frees any resources allocated for the ICM_DECOMPRESSEX_BEGIN message.</para>
	/// <para>
	/// ICM_DECOMPRESSEX_BEGIN and ICM_DECOMPRESSEX_END do not nest. If your driver receives ICM_DECOMPRESSEX_BEGIN before decompression
	/// is stopped with <c>ICM_DECOMPRESSEX_END</c>, it should restart decompression with new parameters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressexend void ICDecompressExEnd( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressExEnd")]
	public static ICERR ICDecompressExEnd([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESSEX_END).ToInt32();

	/// <summary>The <c>ICDecompressExQuery</c> function determines if a decompressor can decompress data with a specific format.</summary>
	/// <param name="hic">Handle to the decompressor to use.</param>
	/// <param name="lpbiSrc">Pointer to a BITMAPINFOHEADER structure containing the format of the compressed data to decompress.</param>
	/// <param name="xSrc">The x-coordinate of the source rectangle for the DIB specified by lpbiSrc.</param>
	/// <param name="ySrc">The y-coordinate of the source rectangle for the DIB specified by lpbiSrc.</param>
	/// <param name="dxSrc">Width of the source rectangle.</param>
	/// <param name="dySrc">Height of the source rectangle.</param>
	/// <param name="lpbiDst">
	/// Pointer to a BITMAPINFOHEADER structure containing the output format. If the value of this parameter is <c>NULL</c>, the
	/// function determines whether the input format is supported and this parameter is ignored.
	/// </param>
	/// <param name="lpDst">Pointer to a buffer that is large enough to contain the decompressed data.</param>
	/// <param name="xDst">The x-coordinate of the destination rectangle for the DIB specified by lpbiDst.</param>
	/// <param name="yDst">The y-coordinate of the destination rectangle for the DIB specified by lpbiDst.</param>
	/// <param name="dxDst">Width of the destination rectangle.</param>
	/// <param name="dyDst">Height of the destination rectangle.</param>
	/// <returns>Returns <c>ICERR_OK</c> if successful or an error otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressexquery LRESULT VFWAPI_INLINE ICDecompressExQuery( HIC
	// hic, DWORD dwFlags, LPBITMAPINFOHEADER lpbiSrc, LPVOID lpSrc, int xSrc, int ySrc, int dxSrc, int dySrc, LPBITMAPINFOHEADER
	// lpbiDst, LPVOID lpDst, int xDst, int yDst, int dxDst, int dyDst );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressExQuery")]
	public static ICERR ICDecompressExQuery([In] HIC hic, in BITMAPINFOHEADER lpbiSrc, int xSrc, int ySrc,
		int dxSrc, int dySrc, [In] BITMAPINFOHEADER? lpbiDst, [Out] IntPtr lpDst, int xDst, int yDst, int dxDst, int dyDst)
	{
		unsafe
		{
			var biDst = lpbiDst.GetValueOrDefault();
			fixed (void* pIn = &lpbiSrc)
			{
				ICDECOMPRESSEX ic = new()
				{
					dwFlags = 0,
					lpbiSrc = (IntPtr)pIn,
					lpSrc = IntPtr.Zero,
					xSrc = xSrc,
					ySrc = ySrc,
					dxSrc = dxSrc,
					dySrc = dySrc,
					lpbiDst = lpbiDst.HasValue ? (IntPtr)(void*)&biDst: IntPtr.Zero,
					lpDst = lpDst,
					xDst = xDst,
					yDst = yDst,
					dxDst = dxDst,
					dyDst = dyDst
				};

				// note that ICM swaps round the length and pointer length in lparam2, pointer in lparam1
				return (ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESSEX_QUERY, (IntPtr)(void*)&ic, (IntPtr)Marshal.SizeOf(ic)).ToInt32();
			}
		}
	}

	/// <summary>
	/// The <c>ICDecompressGetFormat</c> macro requests the output format of the decompressed data from a video decompression driver.
	/// You can use this macro or explicitly call the ICM_DECOMPRESS_GET_FORMAT message.
	/// </summary>
	/// <param name="hic">Handle to a decompressor.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFO structure containing the input format.</param>
	/// <param name="lpbiOutput">
	/// Pointer to a BITMAPINFO structure to contain the output format. You can specify zero to request only the size of the output
	/// format, as in the ICDecompressGetFormatSize macro.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// If lpbiOutput is nonzero, the driver should fill the BITMAPINFO structure with the default output format corresponding to the
	/// input format specified for lpbiInput. If the compressor can produce several formats, the default format should be the one that
	/// preserves the greatest amount of information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressgetformat void ICDecompressGetFormat( hic, lpbiInput,
	// lpbiOutput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressGetFormat")]
	public static ICERR ICDecompressGetFormat([In] HIC hic, in BITMAPINFO lpbiInput, in BITMAPINFO lpbiOutput) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESS_GET_FORMAT, lpbiInput, lpbiOutput).ToInt32();

	/// <summary>
	/// The <c>ICDecompressGetFormatSize</c> macro requests the size of the output format of the decompressed data from a video
	/// decompression driver. You can use this macro or explicitly call the ICM_DECOMPRESS_GET_FORMAT message.
	/// </summary>
	/// <param name="hic">Handle to a decompressor.</param>
	/// <param name="lpbi">Pointer to a BITMAPINFO structure containing the input format.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressgetformatsize void ICDecompressGetFormatSize( hic, lpbi );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressGetFormatSize")]
	public static int ICDecompressGetFormatSize([In] HIC hic, in BITMAPINFO lpbi)
	{
		using var pIn = SafeCoTaskMemHandle.CreateFromStructure(lpbi);
		return ICSendMessage(hic, ICM_Message.ICM_DECOMPRESS_GET_FORMAT, pIn).ToInt32();
	}

	/// <summary>
	/// The <c>ICDecompressGetPalette</c> macro requests that the video decompression driver supply the color table of the output
	/// BITMAPINFOHEADER structure. You can use this macro or explicitly call the ICM_DECOMPRESS_GET_PALETTE message.
	/// </summary>
	/// <param name="hic">Handle to a decompressor.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFOHEADER structure containing the input format.</param>
	/// <param name="lpbiOutput">
	/// Pointer to a BITMAPINFOHEADER structure to contain the color table. The space reserved for the color table is always at least
	/// 256 colors. You can specify zero for this parameter to return only the size of the color table.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// If lpbiOutput is nonzero, the driver sets the <c>biClrUsed</c> member of BITMAPINFOHEADER to the number of colors in the color
	/// table. The driver fills the <c>bmiColors</c> members of BITMAPINFO with the actual colors.
	/// </para>
	/// <para>The driver should support this message only if it uses a palette other than the one specified in the input format.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressgetpalette void ICDecompressGetPalette( hic, lpbiInput,
	// lpbiOutput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressGetPalette")]
	public static ICERR ICDecompressGetPalette([In] HIC hic, in BITMAPINFOHEADER lpbiInput, in BITMAPINFOHEADER lpbiOutput) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESS_GET_PALETTE, lpbiInput, lpbiOutput).ToInt32();

	/// <summary>The <c>ICDecompressOpen</c> macro opens a decompressor that is compatible with the specified formats.</summary>
	/// <param name="fccType">
	/// Four-character code indicating the type of compressor to open. For video streams, the value of this parameter is "VIDC" or ICTYPE_VIDEO.
	/// </param>
	/// <param name="fccHandler">
	/// Four-character code indicating the preferred stream handler to use. Typically, this information is stored in the stream header
	/// in an AVI file.
	/// </param>
	/// <param name="lpbiIn">
	/// Pointer to a structure defining the input format. A decompressor handle is not returned unless it can decompress this format.
	/// For bitmaps, this parameter refers to a BITMAPINFOHEADER structure.
	/// </param>
	/// <param name="lpbiOut">
	/// <para>
	/// Pointer to a structure defining an optional decompression format. You can also specify zero to use the default output format
	/// associated with the input format.
	/// </para>
	/// <para>
	/// If this parameter is nonzero, a compressor handle is not returned unless it can create this output format. For bitmaps, this
	/// parameter refers to a BITMAPINFOHEADER structure.
	/// </para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The <c>ICDecompressOpen</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define ICDecompressOpen(fccType, fccHandler, lpbiIn, lpbiOut) \ ICLocate(fccType, fccHandler, lpbiIn, lpbiOut, ICMODE_DECOMPRESS);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressopen void ICDecompressOpen( fccType, fccHandler,
	// lpbiIn, lpbiOut );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressOpen")]
	public static SafeHIC ICDecompressOpen(uint fccType, [Optional] uint fccHandler, in BITMAPINFOHEADER lpbiIn, in BITMAPINFOHEADER lpbiOut) =>
		ICLocate(fccType, fccHandler, lpbiIn, lpbiOut, ICMODE.ICMODE_DECOMPRESS);

	/// <summary>The <c>ICDecompressOpen</c> macro opens a decompressor that is compatible with the specified formats.</summary>
	/// <param name="fccType">
	/// Four-character code indicating the type of compressor to open. For video streams, the value of this parameter is "VIDC" or ICTYPE_VIDEO.
	/// </param>
	/// <param name="fccHandler">
	/// Four-character code indicating the preferred stream handler to use. Typically, this information is stored in the stream header
	/// in an AVI file.
	/// </param>
	/// <param name="lpbiIn">
	/// Pointer to a structure defining the input format. A decompressor handle is not returned unless it can decompress this format.
	/// For bitmaps, this parameter refers to a BITMAPINFOHEADER structure.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The <c>ICDecompressOpen</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define ICDecompressOpen(fccType, fccHandler, lpbiIn, lpbiOut) \ ICLocate(fccType, fccHandler, lpbiIn, lpbiOut, ICMODE_DECOMPRESS);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressopen void ICDecompressOpen( fccType, fccHandler,
	// lpbiIn, lpbiOut );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressOpen")]
	public static SafeHIC ICDecompressOpen(uint fccType, [Optional] uint fccHandler, in BITMAPINFOHEADER lpbiIn) =>
		ICLocate(fccType, fccHandler, lpbiIn, IntPtr.Zero, ICMODE.ICMODE_DECOMPRESS);

	/// <summary>
	/// The <c>ICDecompressQuery</c> macro queries a video decompression driver to determine if it supports a specific input format or
	/// if it can decompress a specific input format to a specific output format. You can use this macro or explicitly call the
	/// ICM_DECOMPRESS_QUERY message.
	/// </summary>
	/// <param name="hic">Handle to a decompressor.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFO structure containing the input format.</param>
	/// <param name="lpbiOutput">
	/// Pointer to a BITMAPINFO structure containing the output format. You can specify zero for this parameter to indicate any output
	/// format is acceptable.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompressquery void ICDecompressQuery( hic, lpbiInput,
	// lpbiOutput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressQuery")]
	public static ICERR ICDecompressQuery([In] HIC hic, in BITMAPINFO lpbiInput, in BITMAPINFO lpbiOutput) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESS_QUERY, lpbiInput, lpbiOutput).ToInt32();

	/// <summary>
	/// The <c>ICDecompressSetPalette</c> macro specifies a palette for a video decompression driver to use if it is decompressing to a
	/// format that uses a palette. You can use this macro or explicitly call the ICM_DECOMPRESS_SET_PALETTE message.
	/// </summary>
	/// <param name="hic">Handle to a decompressor.</param>
	/// <param name="lpbiPalette">
	/// Pointer to a BITMAPINFOHEADER structure whose color table contains the colors that should be used if possible. You can specify
	/// zero to use the default set of output colors.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// This macro should not affect decompression already in progress; rather, colors passed using this message should be returned in
	/// response to future ICDecompressGetFormat and ICDecompressGetPalette macros. Colors are sent back to the decompression driver in
	/// a future ICDecompressBegin macro.
	/// </para>
	/// <para>
	/// This macro is used primarily when a driver decompresses images to the screen and another application that uses a palette is in
	/// the foreground, forcing the decompression driver to adapt to a foreign set of colors.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdecompresssetpalette void ICDecompressSetPalette( hic,
	// lpbiPalette );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDecompressSetPalette")]
	public static ICERR ICDecompressSetPalette([In] HIC hic, [In, Optional] SafeBITMAPINFO? lpbiPalette) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_DECOMPRESS_SET_PALETTE, lpbiPalette).ToInt32();

	/// <summary>The <c>ICDraw</c> function decompresses an image for drawing.</summary>
	/// <param name="hic">Handle to an decompressor.</param>
	/// <param name="dwFlags">
	/// <para>Decompression flags. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICDRAW_HURRYUP</term>
	/// <term>Data is buffered and not drawn to the screen. Use this flag for fastest decompression.</term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_NOTKEYFRAME</term>
	/// <term>Current frame is not a key frame.</term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_NULLFRAME</term>
	/// <term>Current frame does not contain any data and the previous frame should be redrawn.</term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_PREROLL</term>
	/// <term>
	/// Current frame of video occurs before playback should start. For example, if playback will begin on frame 10, and frame 0 is the
	/// nearest previous key frame, frames 0 through 9 are sent to the driver with the ICDRAW_PREROLL flag set. The driver needs this
	/// data to display frame 10 properly.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_UPDATE</term>
	/// <term>Updates the screen based on previously received data. Set lpData to NULL when this flag is used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpFormat">Pointer to a BITMAPINFOHEADER structure containing the input format of the data.</param>
	/// <param name="lpData">Pointer to the input data.</param>
	/// <param name="cbData">Size of the input data, in bytes.</param>
	/// <param name="lTime">
	/// Time, in samples, to draw this frame. The units for video data are frames. For a definition of the playback rate, see the
	/// <c>dwRate</c> and <c>dwScale</c> members of the ICDRAWBEGIN structure.
	/// </param>
	/// <returns>Returns <c>ICERR_OK</c> if successful or an error otherwise.</returns>
	/// <remarks>
	/// You can initiate drawing the frames by sending the ICM_DRAW_START message (or by using the ICDrawStart macro). The application
	/// should be sure to buffer the required number of frames before drawing is started. Send the <c>KM_GETBUFFERSWANTED</c> message
	/// (or use the ICGetBuffersWanted macro) to obtain this value.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdraw DWORD VFWAPIV ICDraw( HIC hic, DWORD dwFlags, LPVOID
	// lpFormat, LPVOID lpData, DWORD cbData, LONG lTime );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDraw")]
	public static extern ICERR ICDraw([In] HIC hic, ICDRAWF dwFlags, in BITMAPINFOHEADER lpFormat, [In, Optional] IntPtr lpData, uint cbData, int lTime);

	/// <summary>The <c>ICDrawBegin</c> function initializes the renderer and prepares the drawing destination for drawing.</summary>
	/// <param name="hic">Handle to the decompressor to use.</param>
	/// <param name="dwFlags">
	/// <para>Decompression flags. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICDRAW_ANIMATE</term>
	/// <term>Application can animate the palette.</term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_CONTINUE</term>
	/// <term>Drawing is a continuation of the previous frame.</term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_FULLSCREEN</term>
	/// <term>Draws the decompressed data on the full screen.</term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_HDC</term>
	/// <term>Draws the decompressed data to a window or a DC.</term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_MEMORYDC</term>
	/// <term>DC is off-screen.</term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_QUERY</term>
	/// <term>Determines if the decompressor can decompress the data. The driver does not decompress the data.</term>
	/// </item>
	/// <item>
	/// <term>ICDRAW_UPDATING</term>
	/// <term>Current frame is being updated rather than played.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hpal">Handle to the palette used for drawing.</param>
	/// <param name="hwnd">Handle to the window used for drawing.</param>
	/// <param name="hdc">DC used for drawing.</param>
	/// <param name="xDst">The x-coordinate of the upper right corner of the destination rectangle.</param>
	/// <param name="yDst">The y-coordinate of the upper right corner of the destination rectangle.</param>
	/// <param name="dxDst">Width of the destination rectangle.</param>
	/// <param name="dyDst">Height of the destination rectangle.</param>
	/// <param name="lpbi">Pointer to a BITMAPINFOHEADER structure containing the format of the input data to be decompressed.</param>
	/// <param name="xSrc">The x-coordinate of the upper right corner of the source rectangle.</param>
	/// <param name="ySrc">The y-coordinate of the upper right corner of the source rectangle.</param>
	/// <param name="dxSrc">Width of the source rectangle.</param>
	/// <param name="dySrc">Height of the source rectangle.</param>
	/// <param name="dwRate">Frame rate numerator. The frame rate, in frames per second, is obtained by dividing dwRate by dwScale.</param>
	/// <param name="dwScale">Frame rate denominator. The frame rate, in frames per second, is obtained by dividing dwRate by dwScale.</param>
	/// <returns>Returns ICERR_OK if the renderer can decompress the data or <c>ICERR_UNSUPPORTED</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The <c>ICDRAW_HDC</c> and <c>ICDRAW_FULLSCREEN</c> flags are mutually exclusive. If an application sets the ICDRAW_HDC flag in
	/// dwFlags, the decompressor uses hwnd, hdc, and the parameters defining the destination rectangle (xDst, yDst, dxDst, and dyDst).
	/// Your application should set these parameters to the size of the destination rectangle. Specify destination rectangle values
	/// relative to the current window or DC.
	/// </para>
	/// <para>
	/// If an application sets the <c>ICDRAW_FULLSCREEN</c> flag in dwFlags, the hwnd and hdc parameters are not used and should be set
	/// to <c>NULL</c>. Also, the destination rectangle is not used and its parameters can be set to zero.
	/// </para>
	/// <para>
	/// The source rectangle is relative to the full video frame. The portion of the video frame specified by the source rectangle is
	/// stretched or shrunk to fit the destination rectangle.
	/// </para>
	/// <para>
	/// The dwRate and dwScale parameters specify the decompression rate. The integer value specified for dwRate divided by the integer
	/// value specified for dwScale defines the frame rate in frames per second. This value is used by the renderer when it is
	/// responsible for timing frames during playback.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawbegin DWORD VFWAPIV ICDrawBegin( HIC hic, DWORD dwFlags,
	// HPALETTE hpal, HWND hwnd, HDC hdc, int xDst, int yDst, int dxDst, int dyDst, LPBITMAPINFOHEADER lpbi, int xSrc, int ySrc, int
	// dxSrc, int dySrc, DWORD dwRate, DWORD dwScale );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawBegin")]
	public static extern ICERR ICDrawBegin([In] HIC hic, ICDRAWF dwFlags, [In, Optional] HPALETTE hpal, [In, Optional] HWND hwnd,
		[In, Optional] HDC hdc, int xDst, int yDst, int dxDst, int dyDst, in BITMAPINFOHEADER lpbi, int xSrc, int ySrc,
		int dxSrc, int dySrc, uint dwRate, uint dwScale);

	/// <summary>
	/// The <c>ICDrawChangePalette</c> macro notifies a rendering driver that the movie palette is changing. You can use this macro or
	/// explicitly call the ICM_DRAW_CHANGEPALETTE message.
	/// </summary>
	/// <param name="hic">Handle to a rendering driver.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFO structure containing the new format and optional color table.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// This message should be supported by installable rendering handlers that draw DIBs with an internal structure that includes a palette.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawchangepalette void ICDrawChangePalette( hic, lpbiInput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawChangePalette")]
	public static ICERR ICDrawChangePalette([In] HIC hic, in BITMAPINFO lpbiInput) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_CHANGEPALETTE, lpbiInput).ToInt32();

	/// <summary>
	/// The <c>ICDrawEnd</c> macro notifies a rendering driver to decompress the current image to the screen and to release resources
	/// allocated for decompression and drawing. You can use this macro or explicitly call the ICM_DRAW_END message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// The ICM_DRAW_BEGIN and ICM_DRAW_END messages do not nest. If your driver receives <c>ICM_DRAW_BEGIN</c> before decompression is
	/// stopped with <c>ICM_DRAW_END</c>, it should restart decompression with new parameters.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawend void ICDrawEnd( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawEnd")]
	public static ICERR ICDrawEnd([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_END).ToInt32();

	/// <summary>
	/// The <c>ICDrawFlush</c> macro notifies a rendering driver to render the contents of any image buffers that are waiting to be
	/// drawn. You can use this macro or explicitly call the ICM_DRAW_FLUSH message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <returns>None</returns>
	/// <remarks>This message is used only by hardware that performs its own asynchronous decompression, timing, and drawing.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawflush void ICDrawFlush( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawFlush")]
	public static ICERR ICDrawFlush([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_FLUSH).ToInt32();

	/// <summary>
	/// The <c>ICDrawGetTime</c> macro requests a rendering driver that controls the timing of drawing frames to return the current
	/// value of its internal clock. You can use this macro or explicitly call the ICM_DRAW_GETTIME message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <param name="lplTime">Address to contain the current time. The return value should be specified in samples.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// This message is generally supported by hardware that performs its own asynchronous decompression, timing, and drawing. The
	/// message can also be sent if the hardware is being used as the synchronization master.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawgettime void ICDrawGetTime( hic, lplTime );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawGetTime")]
	public static ICERR ICDrawGetTime([In] HIC hic, out int lplTime)
	{
		unsafe
		{
			int val = 0;
			var ret = (ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_GETTIME, (IntPtr)(void*)&val).ToInt32();
			lplTime = val;
			return ret;
		}
	}

	/// <summary>The <c>ICDrawOpen</c> macro opens a driver that can draw images with the specified format.</summary>
	/// <param name="fccType">
	/// Four-character code indicating the type of driver to open. For video streams, the value of this parameter is "VIDC" or ICTYPE_VIDEO.
	/// </param>
	/// <param name="fccHandler">
	/// Four-character code indicating the preferred stream handler to use. Typically, this information is stored in the stream header
	/// in an AVI file.
	/// </param>
	/// <param name="lpbiIn">
	/// Pointer to the structure defining the input format. A driver handle will not be returned unless it can decompress this format.
	/// For images, this parameter refers to a BITMAPINFOHEADER structure.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The <c>ICDrawOpen</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define ICDrawOpen(fccType, fccHandler, lpbiIn) \ ICLocate(fccType, fccHandler, lpbiIn, NULL, ICMODE_DRAW);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawopen void ICDrawOpen( fccType, fccHandler, lpbiIn );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawOpen")]
	public static SafeHIC ICDrawOpen(uint fccType, [Optional] uint fccHandler, in BITMAPINFOHEADER lpbiIn) => ICLocate(fccType, fccHandler, lpbiIn, IntPtr.Zero, ICMODE.ICMODE_DRAW);

	/// <summary>
	/// The <c>ICDrawQuery</c> macro queries a rendering driver to determine if it can render data in a specific format. You can use
	/// this macro or explicitly call the ICM_DRAW_QUERY message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <param name="lpbiInput">Pointer to a BITMAPINFO structure containing the input format.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// This macro differs from the ICDrawBegin macro in that it queries the driver in a general sense. <c>ICDrawBegin</c> determines if
	/// the driver can draw the data using the specified format under specific conditions, such as stretching the image.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawquery void ICDrawQuery( hic, lpbiInput );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawQuery")]
	public static ICERR ICDrawQuery([In] HIC hic, [In, Optional] SafeBITMAPINFO? lpbiInput) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_QUERY, lpbiInput).ToInt32();

	/// <summary>
	/// The <c>ICDrawRealize</c> macro notifies a rendering driver to realize its drawing palette while drawing. You can use this macro
	/// or explicitly call the ICM_DRAW_REALIZE message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <param name="hdc">Handle of the DC used to realize the palette.</param>
	/// <param name="fBackground">
	/// Background flag. Specify <c>TRUE</c> to realize the palette as a background task or <c>FALSE</c> to realize the palette in the foreground.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>Drivers need to respond to this message only if the drawing palette is different from the decompressed palette.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawrealize void ICDrawRealize( hic, hdc, fBackground );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawRealize")]
	public static ICERR ICDrawRealize([In] HIC hic, HDC hdc, bool fBackground) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_REALIZE, (IntPtr)hdc, new IntPtr(fBackground ? 1 : 0)).ToInt32();

	/// <summary>
	/// The <c>ICDrawRenderBuffer</c> macro notifies a rendering driver to draw the frames that have been passed to it. You can use this
	/// macro or explicitly call the ICM_DRAW_RENDERBUFFER message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Use this message with hardware that performs its own asynchronous decompression, timing, and drawing.</para>
	/// <para>
	/// This message is typically used to perform a seek operation when the driver must be specifically instructed to display each video
	/// frame passed to it rather than playing a sequence of video frames.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawrenderbuffer void ICDrawRenderBuffer( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawRenderBuffer")]
	public static ICERR ICDrawRenderBuffer([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_RENDERBUFFER).ToInt32();

	/// <summary>
	/// The <c>ICDrawSetTime</c> macro provides synchronization information to a rendering driver that handles the timing of drawing
	/// frames. The synchronization information is the sample number of the frame to draw. You can use this macro or explicitly call the
	/// ICM_DRAW_SETTIME message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <param name="lTime">Sample number of the frame to render.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Typically, the driver compares the specified value with the frame number associated with the time of its internal clock and
	/// attempts to synchronize the two if the difference is significant.
	/// </para>
	/// <para>
	/// Use this message when the hardware performs its own asynchronous decompression, timing, and drawing, and the hardware relies on
	/// an external synchronization signal (the hardware is not being used as the synchronization master).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawsettime void ICDrawSetTime( hic, lTime );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawSetTime")]
	public static ICERR ICDrawSetTime([In] HIC hic, int lTime) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_SETTIME, (IntPtr)lTime).ToInt32();

	/// <summary>
	/// The <c>ICDrawStart</c> macro notifies a rendering driver to start its internal clock for the timing of drawing frames. You can
	/// use this macro or explicitly call the ICM_DRAW_START message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>This message is used by hardware that performs its own asynchronous decompression, timing, and drawing.</para>
	/// <para>When the driver receives this message, it should start rendering data at the rate specified with the ICM_DRAW_BEGIN message.</para>
	/// <para>
	/// The <c>ICDrawStart</c> and ICDrawStop macros do not nest. If your driver receives <c>ICDrawStart</c> before rendering is stopped
	/// with <c>ICDrawStop</c>, it should restart rendering with new parameters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawstart void ICDrawStart( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawStart")]
	public static ICERR ICDrawStart([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_START).ToInt32();

	/// <summary>
	/// The <c>ICDrawStartPlay</c> macro provides the start and end times of a play operation to a rendering driver. You can use this
	/// macro or explicitly call the ICM_DRAW_START_PLAY message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <param name="lFrom">Start time.</param>
	/// <param name="lTo">End time.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>This message precedes any frame data sent to the rendering driver.</para>
	/// <para>
	/// Units for lFrom and lTo are specified with the ICM_DRAW_BEGIN message. For video data this is normally a frame number. For more
	/// information about the playback rate, see the <c>dwRate</c> and <c>dwScale</c> members of the ICDRAWBEGIN structure.
	/// </para>
	/// <para>If the end time is less than the start time, the playback direction is reversed.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawstartplay void ICDrawStartPlay( hic, lFrom, lTo );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawStartPlay")]
	public static ICERR ICDrawStartPlay([In] HIC hic, int lFrom, int lTo) =>
		(ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_START_PLAY, (IntPtr)lFrom, (IntPtr)lTo).ToInt32();

	/// <summary>
	/// The <c>ICDrawStop</c> macro notifies a rendering driver to stop its internal clock for the timing of drawing frames. You can use
	/// this macro or explicitly call the ICM_DRAW_STOP message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <returns>None</returns>
	/// <remarks>This macro is used by hardware that performs its own asynchronous decompression, timing, and drawing.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawstop void ICDrawStop( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawStop")]
	public static ICERR ICDrawStop([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_STOP).ToInt32();

	/// <summary>
	/// The <c>ICDrawStopPlay</c> macro notifies a rendering driver when a play operation is complete. You can use this macro or
	/// explicitly call the ICM_DRAW_STOP_PLAY message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <returns>None</returns>
	/// <remarks>Use this message when the play operation is complete. Use the ICDrawStop macro to end timing.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawstopplay void ICDrawStopPlay( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawStopPlay")]
	public static ICERR ICDrawStopPlay([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_STOP_PLAY).ToInt32();

	/// <summary>The <c>ICDrawSuggestFormat</c> function notifies the drawing handler to suggest the input data format.</summary>
	/// <param name="hic">Handle to the driver to use.</param>
	/// <param name="lpbiIn">
	/// Pointer to a structure containing the format of the compressed data. For bitmaps, this is a BITMAPINFOHEADER structure.
	/// </param>
	/// <param name="lpbiOut">
	/// Pointer to a structure to return the suggested format. The drawing handler can receive and draw data from this format. For
	/// bitmaps, this is a BITMAPINFOHEADER structure.
	/// </param>
	/// <param name="dxSrc">Width of the source rectangle.</param>
	/// <param name="dySrc">Height of the source rectangle.</param>
	/// <param name="dxDst">Width of the destination rectangle.</param>
	/// <param name="dyDst">Height of the destination rectangle.</param>
	/// <param name="hicDecomp">Decompressor that can use the format of data in lpbiIn.</param>
	/// <returns>Returns <c>ICERR_OK</c> if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// Applications can use this function to determine alternative input formats that a drawing handler can decompress and if the
	/// drawing handler can stretch data. If the drawing handler cannot stretch data as requested, the application might have to stretch
	/// the data.
	/// </para>
	/// <para>
	/// If the drawing handler cannot decompress a format provided by an application, use the ICDecompress, ICDecompressEx, j,
	/// ICDecompressExQuery, and ICDecompressOpen functions to obtain alternate formats.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawsuggestformat LRESULT VFWAPI_INLINE ICDrawSuggestFormat( HIC
	// hic, LPBITMAPINFOHEADER lpbiIn, LPBITMAPINFOHEADER lpbiOut, int dxSrc, int dySrc, int dxDst, int dyDst, HIC hicDecomp );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawSuggestFormat")]
	public static IntPtr ICDrawSuggestFormat([In] HIC hic, [In] IntPtr lpbiIn, [Out] IntPtr lpbiOut, int dxSrc, int dySrc, int dxDst, int dyDst, [In] HIC hicDecomp) =>
		ICSendMessage(hic, ICM_Message.ICM_DRAW_SUGGESTFORMAT, new ICDRAWSUGGEST()
		{
			lpbiIn = lpbiIn,
			lpbiSuggest = lpbiOut,
			dxSrc = dxSrc,
			dySrc = dySrc,
			dxDst = dxDst,
			dyDst = dyDst,
			hicDecompressor = hicDecomp
		});

	/// <summary>
	/// The <c>ICDrawWindow</c> macro notifies a rendering driver that the window specified for the ICM_DRAW_BEGIN message needs to be
	/// redrawn. The window has moved or become temporarily obscured. You can use this macro or explicitly call the ICM_DRAW_WINDOW message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <param name="prc">
	/// Pointer to the destination rectangle in screen coordinates. If this parameter points to an empty rectangle, drawing should be
	/// turned off.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>This message is supported by hardware that performs its own asynchronous decompression, timing, and drawing.</para>
	/// <para>
	/// Video-overlay drivers use this message to draw when the window is obscured or moved. When a window specified for ICM_DRAW_BEGIN
	/// is completely hidden by other windows, the destination rectangle is empty. Drivers should turn off video-overlay hardware when
	/// this condition occurs.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icdrawwindow void ICDrawWindow( hic, prc );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICDrawWindow")]
	public static ICERR ICDrawWindow([In] HIC hic, in RECT prc) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_DRAW_STOP_PLAY, prc).ToInt32();

	/// <summary>
	/// The <c>ICGetBuffersWanted</c> macro queries a driver for the number of buffers to allocate. You can use this macro or explicitly
	/// call the ICM_GETBUFFERSWANTED message.
	/// </summary>
	/// <param name="hic">Handle to a driver.</param>
	/// <param name="lpdwBuffers">Address to contain the number of samples the driver needs to efficiently render the data.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// This message is used by drivers that use hardware to render data and want to ensure a minimal time lag caused by waiting for
	/// buffers to arrive. For example, if a driver controls a video decompression board that can hold 10 frames of video, it could
	/// return 10 for this message. This instructs applications to try to stay 10 frames ahead of the frame it currently needs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icgetbufferswanted void ICGetBuffersWanted( hic, lpdwBuffers );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICGetBuffersWanted")]
	public static ICERR ICGetBuffersWanted([In] HIC hic, out uint lpdwBuffers) => ICSendGetMessage(hic, ICM_Message.ICM_GETBUFFERSWANTED, out lpdwBuffers);

	/// <summary>
	/// The <c>ICGetDefaultKeyFrameRate</c> macro queries a video compression driver for its default (or preferred) key-frame spacing.
	/// You can use this macro or explicitly call the ICM_GETDEFAULTKEYFRAMERATE message.
	/// </summary>
	/// <param name="hic">Handle to a compressor.</param>
	/// <param name="dwICValue">Address to contain the preferred key-frame spacing.</param>
	/// <returns>None</returns>
	/// <remarks>The <c>ICGetDefaultKeyFrameRate</c> macro returns the default key frame rate.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icgetdefaultkeyframerate void ICGetDefaultKeyFrameRate( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICGetDefaultKeyFrameRate")]
	public static ICERR ICGetDefaultKeyFrameRate([In] HIC hic, out uint dwICValue) => ICSendGetMessage(hic, ICM_Message.ICM_GETDEFAULTKEYFRAMERATE, out dwICValue);

	/// <summary>
	/// The <c>ICGetDefaultQuality</c> macro queries a video compression driver to provide its default quality setting. You can use this
	/// macro or explicitly call the ICM_GETDEFAULTQUALITY message.
	/// </summary>
	/// <param name="hic">Handle to a compressor.</param>
	/// <param name="dwICValue">Address to contain the default quality value. Quality values range from 0 to 10,000.</param>
	/// <returns>None</returns>
	/// <remarks>The <c>ICGetDefaultQuality</c> macro returns the default quality value.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icgetdefaultquality void ICGetDefaultQuality( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICGetDefaultQuality")]
	public static ICERR ICGetDefaultQuality([In] HIC hic, out uint dwICValue) => ICSendGetMessage(hic, ICM_Message.ICM_GETDEFAULTKEYFRAMERATE, out dwICValue);

	/// <summary>
	/// The <c>ICGetDisplayFormat</c> function determines the best format available for displaying a compressed image. The function also
	/// opens a compressor if a handle of an open compressor is not specified.
	/// </summary>
	/// <param name="hic">Handle to the compressor to use. Specify <c>NULL</c> to have VCM select and open an appropriate compressor.</param>
	/// <param name="lpbiIn">Pointer to BITMAPINFOHEADER structure containing the compressed format.</param>
	/// <param name="lpbiOut">
	/// Pointer to a buffer to return the decompressed format. The buffer should be large enough for a BITMAPINFOHEADER structure and
	/// 256 color entries.
	/// </param>
	/// <param name="BitDepth">Preferred bit depth, if nonzero.</param>
	/// <param name="dx">Width multiplier to stretch the image. If this parameter is zero, that dimension is not stretched.</param>
	/// <param name="dy">Height multiplier to stretch the image. If this parameter is zero, that dimension is not stretched.</param>
	/// <returns>Returns a handle to a decompressor if successful or zero otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icgetdisplayformat HIC VFWAPI ICGetDisplayFormat( HIC hic,
	// LPBITMAPINFOHEADER lpbiIn, LPBITMAPINFOHEADER lpbiOut, int BitDepth, int dx, int dy );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICGetDisplayFormat")]
	public static extern SafeHIC ICGetDisplayFormat(HIC hic, in BITMAPINFOHEADER lpbiIn, IntPtr lpbiOut, [Optional] int BitDepth, [Optional] int dx, [Optional] int dy);

	/// <summary>The <c>ICGetInfo</c> function obtains information about a compressor.</summary>
	/// <param name="hic">Handle to a compressor.</param>
	/// <param name="picinfo">Pointer to the ICINFO structure to return information about the compressor.</param>
	/// <param name="cb">Size, in bytes, of the structure pointed to by lpicinfo.</param>
	/// <returns>Returns the number of bytes copied into the structure or zero if an error occurs.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icgetinfo LRESULT VFWAPI ICGetInfo( HIC hic, ICINFO *picinfo, DWORD
	// cb );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICGetInfo")]
	public static extern IntPtr ICGetInfo(HIC hic, ref ICINFO picinfo, uint cb);

	/// <summary>
	/// The <c>ICGetState</c> macro queries a video compression driver to return its current configuration in a block of memory. You can
	/// use this macro or explicitly call the ICM_GETSTATE message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <param name="pv">
	/// Pointer to a block of memory to contain the current configuration information. You can specify <c>NULL</c> for this parameter to
	/// determine the amount of memory required for the configuration information, as in ICGetStateSize.
	/// </param>
	/// <param name="cb">Size, in bytes, of the block of memory.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The ICGetStateSize macro returns the number of bytes used by the state data.</para>
	/// <para>The structure used to represent configuration information is driver specific and is defined by the driver.</para>
	/// <para>Use ICGetStateSize before calling the <c>ICGetState</c> macro to determine the size of buffer to allocate for the call.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icgetstate void ICGetState( hic, pv, cb );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICGetState")]
	public static ICERR ICGetState([In] HIC hic, [Optional] IntPtr pv, uint cb) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_GETSTATE, pv, new IntPtr((int)cb)).ToInt32();

	/// <summary>
	/// The <c>ICGetStateSize</c> macro queries a video compression driver to determine the amount of memory required to retrieve the
	/// configuration information. You can use this macro or explicitly call the ICM_GETSTATE message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <param name="size">The size, in bytes, of the buffer needed to hold state.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The structure used to represent configuration information is driver specific and is defined by the driver.</para>
	/// <para>Use <c>ICGetStateSize</c> before calling the ICGetState macro to determine the size of buffer to allocate for the call.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icgetstatesize void ICGetStateSize( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICGetStateSize")]
	public static ICERR ICGetStateSize([In] HIC hic, out uint size)
	{
		unsafe
		{
			uint dw = default;
			var ret = (ICERR)ICSendMessage(hic, ICM_Message.ICM_GETSTATE, IntPtr.Zero, (IntPtr)(void*)&dw).ToInt32();
			size = dw;
			return ret;
		}
	}

	/// <summary>
	/// The <c>ICImageCompress</c> function compresses an image to a given size. This function does not require initialization functions.
	/// </summary>
	/// <param name="hic">
	/// Handle to a compressor opened with the ICOpen function. Specify <c>NULL</c> to have VCM select an appropriate compressor for the
	/// compression format. An application can have the user select the compressor by using the ICCompressorChoose function, which opens
	/// the selected compressor and returns a handle of the compressor in this parameter.
	/// </param>
	/// <param name="uiFlags">Reserved; must be zero.</param>
	/// <param name="lpbiIn">Pointer to the BITMAPINFO structure containing the input data format.</param>
	/// <param name="lpBits">Pointer to input data bits to compress. The data bits exclude header and format information.</param>
	/// <param name="lpbiOut">
	/// Pointer to the BITMAPINFO structure containing the compressed output format. Specify <c>NULL</c> to have the compressor use an
	/// appropriate format.
	/// </param>
	/// <param name="lQuality">Quality value used by the compressor. Values range from 0 to 10,000.</param>
	/// <param name="plSize">
	/// Maximum size desired for the compressed image. The compressor might not be able to compress the data to fit within this size.
	/// When the function returns, this parameter points to the size of the compressed image. Image sizes are specified in bytes.
	/// </param>
	/// <returns>Returns a handle to a compressed DIB. The image data follows the format header.</returns>
	/// <remarks>
	/// To obtain the format information from the BITMAPINFOHEADER structure, use the GlobalLock function to lock the data. Use the
	/// GlobalFree function to free the DIB when you are finished.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icimagecompress HANDLE VFWAPI ICImageCompress( HIC hic, UINT
	// uiFlags, LPBITMAPINFO lpbiIn, LPVOID lpBits, LPBITMAPINFO lpbiOut, LONG lQuality, LONG *plSize );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICImageCompress")]
	public static extern SafeMoveableHGlobalHandle ICImageCompress([In] HIC hic, [Optional] uint uiFlags, in BITMAPINFO lpbiIn, [In] IntPtr lpBits, [In, Optional] IntPtr lpbiOut, int lQuality, ref int plSize);

	/// <summary>
	/// The <c>ICImageCompress</c> function compresses an image to a given size. This function does not require initialization functions.
	/// </summary>
	/// <param name="hic">
	/// Handle to a compressor opened with the ICOpen function. Specify <c>NULL</c> to have VCM select an appropriate compressor for the
	/// compression format. An application can have the user select the compressor by using the ICCompressorChoose function, which opens
	/// the selected compressor and returns a handle of the compressor in this parameter.
	/// </param>
	/// <param name="uiFlags">Reserved; must be zero.</param>
	/// <param name="lpbiIn">Pointer to the BITMAPINFO structure containing the input data format.</param>
	/// <param name="lpBits">Pointer to input data bits to compress. The data bits exclude header and format information.</param>
	/// <param name="lpbiOut">
	/// Pointer to the BITMAPINFO structure containing the compressed output format. Specify <c>NULL</c> to have the compressor use an
	/// appropriate format.
	/// </param>
	/// <param name="lQuality">Quality value used by the compressor. Values range from 0 to 10,000.</param>
	/// <param name="plSize">
	/// Maximum size desired for the compressed image. The compressor might not be able to compress the data to fit within this size.
	/// When the function returns, this parameter points to the size of the compressed image. Image sizes are specified in bytes.
	/// </param>
	/// <returns>Returns a handle to a compressed DIB. The image data follows the format header.</returns>
	/// <remarks>
	/// To obtain the format information from the BITMAPINFOHEADER structure, use the GlobalLock function to lock the data. Use the
	/// GlobalFree function to free the DIB when you are finished.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icimagecompress HANDLE VFWAPI ICImageCompress( HIC hic, UINT
	// uiFlags, LPBITMAPINFO lpbiIn, LPVOID lpBits, LPBITMAPINFO lpbiOut, LONG lQuality, LONG *plSize );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICImageCompress")]
	public static extern SafeMoveableHGlobalHandle ICImageCompress([In] HIC hic, [Optional] uint uiFlags, [In] IntPtr lpbiIn, [In] IntPtr lpBits, [In, Optional] IntPtr lpbiOut, int lQuality, ref int plSize);

	/// <summary>The <c>ICImageDecompress</c> function decompresses an image without using initialization functions.</summary>
	/// <param name="hic">
	/// Handle to a decompressor opened with the ICOpen function. Specify <c>NULL</c> to have VCM select an appropriate decompressor for
	/// the compressed image.
	/// </param>
	/// <param name="uiFlags">Reserved; must be zero.</param>
	/// <param name="lpbiIn">Compressed input data format.</param>
	/// <param name="lpBits">Pointer to input data bits to compress. The data bits exclude header and format information.</param>
	/// <param name="lpbiOut">Decompressed output format. Specify <c>NULL</c> to let decompressor use an appropriate format.</param>
	/// <returns>
	/// Returns a handle to an uncompressed DIB in the CF_DIB format if successful or <c>NULL</c> otherwise. Image data follows the
	/// format header.
	/// </returns>
	/// <remarks>
	/// To obtain the format information from the <c>LPBITMAPINFOHEADER</c> structure, use the <c>GlobalLock</c> function to lock the
	/// data. Use the <c>GlobalFree</c> function to free the DIB when you are finished.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icimagedecompress HANDLE VFWAPI ICImageDecompress( HIC hic, UINT
	// uiFlags, LPBITMAPINFO lpbiIn, LPVOID lpBits, LPBITMAPINFO lpbiOut );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICImageDecompress")]
	public static extern SafeMoveableHGlobalHandle ICImageDecompress([In] HIC hic, [Optional] uint uiFlags, in BITMAPINFO lpbiIn, [In] IntPtr lpBits, [In, Optional] IntPtr lpbiOut);

	/// <summary>The <c>ICImageDecompress</c> function decompresses an image without using initialization functions.</summary>
	/// <param name="hic">
	/// Handle to a decompressor opened with the ICOpen function. Specify <c>NULL</c> to have VCM select an appropriate decompressor for
	/// the compressed image.
	/// </param>
	/// <param name="uiFlags">Reserved; must be zero.</param>
	/// <param name="lpbiIn">Compressed input data format.</param>
	/// <param name="lpBits">Pointer to input data bits to compress. The data bits exclude header and format information.</param>
	/// <param name="lpbiOut">Decompressed output format. Specify <c>NULL</c> to let decompressor use an appropriate format.</param>
	/// <returns>
	/// Returns a handle to an uncompressed DIB in the CF_DIB format if successful or <c>NULL</c> otherwise. Image data follows the
	/// format header.
	/// </returns>
	/// <remarks>
	/// To obtain the format information from the <c>LPBITMAPINFOHEADER</c> structure, use the <c>GlobalLock</c> function to lock the
	/// data. Use the <c>GlobalFree</c> function to free the DIB when you are finished.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icimagedecompress HANDLE VFWAPI ICImageDecompress( HIC hic, UINT
	// uiFlags, LPBITMAPINFO lpbiIn, LPVOID lpBits, LPBITMAPINFO lpbiOut );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICImageDecompress")]
	public static extern SafeMoveableHGlobalHandle ICImageDecompress([In] HIC hic, [Optional] uint uiFlags, [In] IntPtr lpbiIn, [In] IntPtr lpBits, [In, Optional] IntPtr lpbiOut);

	/// <summary>
	/// The <c>ICInfo</c> function retrieves information about specific installed compressors or enumerates the installed compressors.
	/// </summary>
	/// <param name="fccType">Four-character code indicating the type of compressor. Specify zero to match all compressor types.</param>
	/// <param name="fccHandler">
	/// Four-character code identifying a specific compressor or a number between zero and the number of installed compressors of the
	/// type specified by fccType.
	/// </param>
	/// <param name="lpicinfo">Pointer to a ICINFO structure to return information about the compressor.</param>
	/// <returns>Returns <c>TRUE</c> if successful or an error otherwise.</returns>
	/// <remarks>
	/// To enumerate the compressors or decompressors, specify an integer for fccHandler. This function returns information for integers
	/// between zero and the number of installed compressors or decompressors of the type specified for fccType.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icinfo BOOL VFWAPI ICInfo( DWORD fccType, DWORD fccHandler, ICINFO
	// *lpicinfo );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICInfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ICInfo(uint fccType, uint fccHandler, out ICINFO lpicinfo);

	/// <summary>The <c>ICInstall</c> function installs a new compressor or decompressor.</summary>
	/// <param name="fccType">
	/// Four-character code indicating the type of data used by the compressor or decompressor. Specify "VIDC" for a video compressor or decompressor.
	/// </param>
	/// <param name="fccHandler">Four-character code identifying a specific compressor or decompressor.</param>
	/// <param name="lParam">
	/// Pointer to a null-terminated string containing the name of the compressor or decompressor, or the address of a function used for
	/// compression or decompression. The contents of this parameter are defined by the flags set for wFlags.
	/// </param>
	/// <param name="szDesc">Reserved; do not use.</param>
	/// <param name="wFlags">
	/// <para>Flags defining the contents of lParam. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICINSTALL_DRIVER</term>
	/// <term>The lParam parameter contains the address of a null-terminated string that names the compressor to install.</term>
	/// </item>
	/// <item>
	/// <term>ICINSTALL_FUNCTION</term>
	/// <term>
	/// The lParam parameter contains the address of a compressor function. This function should be structured like the DriverProc entry
	/// point function used by compressors.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns ICERR_OK if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>Applications must open an installed compressor or decompressor before using it.</para>
	/// <para>
	/// If your application installs a function as a compressor or decompressor, it should remove the function with the ICRemove
	/// function before it terminates. This prevents other applications from trying to access the function when it is not available.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icinstall BOOL VFWAPI ICInstall( DWORD fccType, DWORD fccHandler,
	// LPARAM lParam, StrPtrAnsi szDesc, UINT wFlags );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICInstall")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ICInstall(uint fccType, uint fccHandler, [In] IntPtr lParam, [Optional, MarshalAs(UnmanagedType.LPStr)] string? szDesc, ICINSTALL wFlags);

	/// <summary>
	/// The <c>ICLocate</c> function finds a compressor or decompressor that can handle images with the specified formats, or finds a
	/// driver that can decompress an image with a specified format directly to hardware.
	/// </summary>
	/// <param name="fccType">
	/// Four-character code indicating the type of compressor or decompressor to open. For video streams, the value of this parameter is 'VIDC'.
	/// </param>
	/// <param name="fccHandler">
	/// Preferred handler of the specified type. Typically, the handler type is stored in the stream header in an AVI file. Specify
	/// <c>NULL</c> if your application can use any handler type or it does not know the handler type to use.
	/// </param>
	/// <param name="lpbiIn">
	/// Pointer to a BITMAPINFOHEADER structure defining the input format. A compressor handle is not returned unless it supports this format.
	/// </param>
	/// <param name="lpbiOut">
	/// <para>
	/// Pointer to a BITMAPINFOHEADER structure defining an optional decompressed format. You can also specify zero to use the default
	/// output format associated with the input format.
	/// </para>
	/// <para>If this parameter is nonzero, a compressor handle is not returned unless it can create this output format.</para>
	/// </param>
	/// <param name="wFlags">
	/// <para>Flags that describe the search criteria for a compressor or decompressor. The following values are defined:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICMODE_COMPRESS</term>
	/// <term>Finds a compressor that can compress an image with a format defined by lpbiIn to the format defined by lpbiOut.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_DECOMPRESS</term>
	/// <term>Finds a decompressor that can decompress an image with a format defined by lpbiIn to the format defined by lpbiOut.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_DRAW</term>
	/// <term>Finds a decompressor that can decompress an image with a format defined by lpbiIn and draw it directly to hardware.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_FASTCOMPRESS</term>
	/// <term>
	/// Has the same meaning as ICMODE_COMPRESS except the compressor is used for a real-time operation and emphasizes speed over quality.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICMODE_FASTDECOMPRESS</term>
	/// <term>
	/// Has the same meaning as ICMODE_DECOMPRESS except the decompressor is used for a real-time operation and emphasizes speed over quality.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns a handle to a compressor or decompressor if successful or zero otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iclocate HIC VFWAPI ICLocate( DWORD fccType, DWORD fccHandler,
	// LPBITMAPINFOHEADER lpbiIn, LPBITMAPINFOHEADER lpbiOut, WORD wFlags );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICLocate")]
	public static extern SafeHIC ICLocate(uint fccType, [Optional] uint fccHandler, in BITMAPINFOHEADER lpbiIn, in BITMAPINFOHEADER lpbiOut, ICMODE wFlags);

	/// <summary>
	/// The <c>ICLocate</c> function finds a compressor or decompressor that can handle images with the specified formats, or finds a
	/// driver that can decompress an image with a specified format directly to hardware.
	/// </summary>
	/// <param name="fccType">
	/// Four-character code indicating the type of compressor or decompressor to open. For video streams, the value of this parameter is 'VIDC'.
	/// </param>
	/// <param name="fccHandler">
	/// Preferred handler of the specified type. Typically, the handler type is stored in the stream header in an AVI file. Specify
	/// <c>NULL</c> if your application can use any handler type or it does not know the handler type to use.
	/// </param>
	/// <param name="lpbiIn">
	/// Pointer to a BITMAPINFOHEADER structure defining the input format. A compressor handle is not returned unless it supports this format.
	/// </param>
	/// <param name="lpbiOut">
	/// <para>
	/// Pointer to a BITMAPINFOHEADER structure defining an optional decompressed format. You can also specify zero to use the default
	/// output format associated with the input format.
	/// </para>
	/// <para>If this parameter is nonzero, a compressor handle is not returned unless it can create this output format.</para>
	/// </param>
	/// <param name="wFlags">
	/// <para>Flags that describe the search criteria for a compressor or decompressor. The following values are defined:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICMODE_COMPRESS</term>
	/// <term>Finds a compressor that can compress an image with a format defined by lpbiIn to the format defined by lpbiOut.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_DECOMPRESS</term>
	/// <term>Finds a decompressor that can decompress an image with a format defined by lpbiIn to the format defined by lpbiOut.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_DRAW</term>
	/// <term>Finds a decompressor that can decompress an image with a format defined by lpbiIn and draw it directly to hardware.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_FASTCOMPRESS</term>
	/// <term>
	/// Has the same meaning as ICMODE_COMPRESS except the compressor is used for a real-time operation and emphasizes speed over quality.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICMODE_FASTDECOMPRESS</term>
	/// <term>
	/// Has the same meaning as ICMODE_DECOMPRESS except the decompressor is used for a real-time operation and emphasizes speed over quality.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns a handle to a compressor or decompressor if successful or zero otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iclocate HIC VFWAPI ICLocate( DWORD fccType, DWORD fccHandler,
	// LPBITMAPINFOHEADER lpbiIn, LPBITMAPINFOHEADER lpbiOut, WORD wFlags );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICLocate")]
	public static extern SafeHIC ICLocate(uint fccType, [Optional] uint fccHandler, in BITMAPINFOHEADER lpbiIn, [In, Optional] IntPtr lpbiOut, ICMODE wFlags);

	/// <summary>The <c>ICOpen</c> function opens a compressor or decompressor.</summary>
	/// <param name="fccType">
	/// Four-character code indicating the type of compressor or decompressor to open. For video streams, the value of this parameter is "VIDC".
	/// </param>
	/// <param name="fccHandler">
	/// Preferred handler of the specified type. Typically, the handler type is stored in the stream header in an AVI file.
	/// </param>
	/// <param name="wMode">
	/// <para>Flag defining the use of the compressor or decompressor. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICMODE_COMPRESS</term>
	/// <term>Compressor will perform normal compression.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_DECOMPRESS</term>
	/// <term>Decompressor will perform normal decompression.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_DRAW</term>
	/// <term>Decompressor will decompress and draw the data directly to hardware.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_FASTCOMPRESS</term>
	/// <term>Compressor will perform fast (real-time) compression.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_FASTDECOMPRESS</term>
	/// <term>Decompressor will perform fast (real-time) decompression.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_QUERY</term>
	/// <term>Queries the compressor or decompressor for information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns a handle to a compressor or decompressor if successful or zero otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icopen HIC VFWAPI ICOpen( DWORD fccType, DWORD fccHandler, UINT
	// wMode );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICOpen")]
	public static extern SafeHIC ICOpen(uint fccType, uint fccHandler, ICMODE wMode);

	/// <summary>The <c>ICOpenFunction</c> function opens a compressor or decompressor defined as a function.</summary>
	/// <param name="fccType">Type of compressor to open. For video, the value of this parameter is ICTYPE_VIDEO.</param>
	/// <param name="fccHandler">Preferred handler of the specified type. Typically, this comes from the stream header in an AVI file.</param>
	/// <param name="wMode">
	/// <para>Flag to define the use of the compressor or decompressor. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICMODE_COMPRESS</term>
	/// <term>Compressor will perform normal compression.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_DECOMPRESS</term>
	/// <term>Decompressor will perform normal decompression.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_DRAW</term>
	/// <term>Decompressor will decompress and draw the data directly to hardware.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_FASTCOMPRESS</term>
	/// <term>Compressor will perform fast (real-time) compression.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_FASTDECOMPRESS</term>
	/// <term>Decompressor will perform fast (real-time) decompression.</term>
	/// </item>
	/// <item>
	/// <term>ICMODE_QUERY</term>
	/// <term>Queries the compressor or decompressor for information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpfnHandler">Pointer to the function used as the compressor or decompressor.</param>
	/// <returns>Returns a handle to a compressor or decompressor if successful or zero otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icopenfunction HIC VFWAPI ICOpenFunction( DWORD fccType, DWORD
	// fccHandler, UINT wMode, FARPROC lpfnHandler );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICOpenFunction")]
	public static extern SafeHIC ICOpenFunction(uint fccType, uint fccHandler, ICMODE wMode, [In] IntPtr lpfnHandler);

	/// <summary>
	/// The <c>ICQueryAbout</c> macro queries a video compression driver to determine if it has an About dialog box. You can use this
	/// macro or explicitly call the ICM_ABOUT message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icqueryabout void ICQueryAbout( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICQueryAbout")]
	public static ICERR ICQueryAbout([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_ABOUT, new IntPtr(-1), (IntPtr)1).ToInt32();

	/// <summary>
	/// The <c>ICQueryAbout</c> macro queries a video compression driver to determine if it has an About dialog box. You can use this
	/// macro or explicitly call the ICM_ABOUT message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <param name="hwnd">Handle to the parent window of the displayed dialog box.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icqueryabout void ICQueryAbout( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICQueryAbout")]
	public static ICERR ICQueryAbout([In] HIC hic, [In] HWND hwnd) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_ABOUT, (IntPtr)hwnd, IntPtr.Zero).ToInt32();

	/// <summary>
	/// The <c>ICQueryConfigure</c> macro queries a video compression driver to determine if it has a configuration dialog box. You can
	/// use this macro or explicitly send the ICM_CONFIGURE message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// This message is different from the DRV_CONFIGURE message used for hardware configuration. The dialog box for this message should
	/// let the user set and edit the internal state referenced by the ICM_GETSTATE and ICM_SETSTATE messages. For example, this dialog
	/// box can let the user change parameters affecting the quality level and other similar compression options.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icqueryconfigure void ICQueryConfigure( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICQueryConfigure")]
	public static ICERR ICQueryConfigure([In] HIC hic) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_CONFIGURE, new IntPtr(-1), (IntPtr)1).ToInt32();

	/// <summary>
	/// The <c>ICQueryConfigure</c> macro queries a video compression driver to determine if it has a configuration dialog box. You can
	/// use this macro or explicitly send the ICM_CONFIGURE message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <param name="hwnd">Handle to the parent window of the displayed dialog box.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// This message is different from the DRV_CONFIGURE message used for hardware configuration. The dialog box for this message should
	/// let the user set and edit the internal state referenced by the ICM_GETSTATE and ICM_SETSTATE messages. For example, this dialog
	/// box can let the user change parameters affecting the quality level and other similar compression options.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icqueryconfigure void ICQueryConfigure( hic );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICQueryConfigure")]
	public static ICERR ICQueryConfigure([In] HIC hic, [In] HWND hwnd) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_CONFIGURE, (IntPtr)hwnd, (IntPtr)1).ToInt32();

	/// <summary>The <c>ICRemove</c> function removes an installed compressor.</summary>
	/// <param name="fccType">
	/// Four-character code indicating the type of data used by the compressor or decompressor. Specify "VIDC" for a video compressor or decompressor.
	/// </param>
	/// <param name="fccHandler">
	/// Four-character code identifying a specific compressor or a number between zero and the number of installed compressors of the
	/// type specified by fccType.
	/// </param>
	/// <param name="wFlags">Reserved; do not use.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icremove BOOL VFWAPI ICRemove( DWORD fccType, DWORD fccHandler,
	// UINT wFlags );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICRemove")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ICRemove(uint fccType, uint fccHandler, uint wFlags = 0);

	/// <summary>The <c>ICSendMessage</c> function sends a message to a compressor.</summary>
	/// <param name="hic">Handle to the compressor to receive the message.</param>
	/// <param name="msg">Message to send.</param>
	/// <param name="dw1">Additional message-specific information.</param>
	/// <param name="dw2">Additional message-specific information.</param>
	/// <returns>Returns a message-specific result.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icsendmessage LRESULT VFWAPI ICSendMessage( HIC hic, UINT msg,
	// DWORD_PTR dw1, DWORD_PTR dw2 );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSendMessage")]
	public static extern IntPtr ICSendMessage(HIC hic, uint msg, IntPtr dw1 = default, IntPtr dw2 = default);

	/// <summary>The <c>ICSendMessage</c> function sends a message to a compressor.</summary>
	/// <param name="hic">Handle to the compressor to receive the message.</param>
	/// <param name="msg">Message to send.</param>
	/// <param name="dw1">Additional message-specific information.</param>
	/// <param name="dw2">Additional message-specific information.</param>
	/// <returns>Returns a message-specific result.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icsendmessage LRESULT VFWAPI ICSendMessage( HIC hic, UINT msg,
	// DWORD_PTR dw1, DWORD_PTR dw2 );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSendMessage")]
	public static extern IntPtr ICSendMessage(HIC hic, ICM_Message msg, IntPtr dw1 = default, IntPtr dw2 = default);

	/// <summary>The <c>ICSendMessage</c> function sends a message to a compressor.</summary>
	/// <param name="hic">Handle to the compressor to receive the message.</param>
	/// <param name="msg">Message to send.</param>
	/// <param name="lpbiInput">Additional message-specific information.</param>
	/// <param name="lpbiOutput">Additional message-specific information.</param>
	/// <returns>Returns a message-specific result.</returns>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSendMessage")]
	public static IntPtr ICSendMessage(HIC hic, ICM_Message msg, in BITMAPINFOHEADER lpbiInput, in BITMAPINFOHEADER lpbiOutput)
	{
		unsafe
		{
			fixed (void* pIn = &lpbiInput, pOut = &lpbiOutput)
			{
				return ICSendMessage(hic, msg, (IntPtr)pIn, (IntPtr)pOut);
			}
		}
	}

	/// <summary>The <c>ICSendMessage</c> function sends a message to a compressor.</summary>
	/// <typeparam name="T">The type of the structure to pass into <paramref name="lpbiInput"/>.</typeparam>
	/// <param name="hic">Handle to the compressor to receive the message.</param>
	/// <param name="msg">Message to send.</param>
	/// <param name="lpbiInput">Additional message-specific information.</param>
	/// <returns>Returns a message-specific result.</returns>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSendMessage")]
	public static IntPtr ICSendMessage<T>(HIC hic, ICM_Message msg, in T lpbiInput) where T : struct
	{
		using var mem = new SafeCoTaskMemStruct<T>(lpbiInput);
		return ICSendMessage(hic, msg, mem, (IntPtr)(int)mem.Size);
	}

	/// <summary>The <c>ICSeqCompressFrame</c> function compresses one frame in a sequence of frames.</summary>
	/// <param name="pc">Pointer to a COMPVARS structure initialized with information about the compression.</param>
	/// <param name="uiFlags">Reserved; must be zero.</param>
	/// <param name="lpBits">Pointer to the data bits to compress. (The data bits exclude header or format information.)</param>
	/// <param name="pfKey">Returns whether or not the frame was compressed into a key frame.</param>
	/// <param name="plSize">
	/// Maximum size desired for the compressed image. The compressor might not be able to compress the data to fit within this size.
	/// When the function returns, the parameter points to the size of the compressed image. Images sizes are specified in bytes.
	/// </param>
	/// <returns>Returns the address of the compressed bits if successful or <c>NULL</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function uses a COMPVARS structure to provide settings for the specified compressor and intersperses key frames at the rate
	/// specified by the ICSeqCompressorFrameStart function. You can specify values for the data rate for the sequence and the key-frame
	/// frequency by using the appropriate members of <c>COMPVARS</c>.
	/// </para>
	/// <para>Use this function instead of the ICCompress function to compress a video sequence.</para>
	/// <para>
	/// You can allow the user to specify a compressor and initialize a COMPVARS structure by using the ICCompressorChoose function. Or,
	/// you can initialize a <c>COMPVARS</c> structure manually.
	/// </para>
	/// <para>
	/// Use the ICSeqCompressFrameStart, <c>ICSeqCompressFrame</c>, and ICSeqCompressFrameEnd functions to compress a sequence of frames
	/// to a specified data rate and number of key frames. Use <c>ICSeqCompressFrame</c> once for each frame to be compressed.
	/// </para>
	/// <para>When finished with compression, use the ICCompressorFree function to release the resources specified by COMPVARS.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icseqcompressframe LPVOID VFWAPI ICSeqCompressFrame( PCOMPVARS pc,
	// UINT uiFlags, LPVOID lpBits, BOOL *pfKey, LONG *plSize );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSeqCompressFrame")]
	public static extern IntPtr ICSeqCompressFrame(in COMPVARS pc, [Optional] uint uiFlags, [In] IntPtr lpBits, [MarshalAs(UnmanagedType.Bool)] out bool pfKey, ref int plSize);

	/// <summary>
	/// The <c>ICSeqCompressFrameEnd</c> function ends sequence compression that was initiated by using the ICSeqCompressFrameStart and
	/// ICSeqCompressFrame functions.
	/// </summary>
	/// <param name="pc">Pointer to a COMPVARS structure used during sequence compression.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>When finished with compression, use the ICCompressorFree function to release the resources specified by COMPVARS.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icseqcompressframeend void VFWAPI ICSeqCompressFrameEnd( PCOMPVARS
	// pc );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSeqCompressFrameEnd")]
	public static extern void ICSeqCompressFrameEnd(in COMPVARS pc);

	/// <summary>
	/// The <c>ICSeqCompressFrameStart</c> function initializes resources for compressing a sequence of frames using the
	/// ICSeqCompressFrame function.
	/// </summary>
	/// <param name="pc">Pointer to a COMPVARS structure initialized with information for compression.</param>
	/// <param name="lpbiIn">Format of the data to be compressed.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function uses a COMPVARS structure to provide settings for the specified compressor and intersperses key frames at the rate
	/// specified by the <c>lKey</c> member of <c>COMPVARS</c>. You can specify values for the data rate for the sequence and the
	/// key-frame frequency by using the appropriate members of <c>COMPVARS</c>.
	/// </para>
	/// <para>
	/// Use the <c>ICSeqCompressFrameStart</c>, ICSeqCompressFrame, and ICSeqCompressFrameEnd functions to compress a sequence of frames
	/// to a specified data rate and number of key frames.
	/// </para>
	/// <para>When finished with compression, use the ICCompressorFree function to release the resources specified in COMPVARS.</para>
	/// <para>
	/// COMPVARS needs to be initialized before you use this function. You can initialize the structure manually or you can allow the
	/// user to specify a compressor and initialize a <c>COMPVARS</c> structure by using the ICCompressorChoose function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icseqcompressframestart BOOL VFWAPI ICSeqCompressFrameStart(
	// PCOMPVARS pc, LPBITMAPINFO lpbiIn );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSeqCompressFrameStart")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ICSeqCompressFrameStart(in COMPVARS pc, [In] IntPtr lpbiIn);

	/// <summary>
	/// The <c>ICSeqCompressFrameStart</c> function initializes resources for compressing a sequence of frames using the
	/// ICSeqCompressFrame function.
	/// </summary>
	/// <param name="pc">Pointer to a COMPVARS structure initialized with information for compression.</param>
	/// <param name="lpbiIn">Format of the data to be compressed.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function uses a COMPVARS structure to provide settings for the specified compressor and intersperses key frames at the rate
	/// specified by the <c>lKey</c> member of <c>COMPVARS</c>. You can specify values for the data rate for the sequence and the
	/// key-frame frequency by using the appropriate members of <c>COMPVARS</c>.
	/// </para>
	/// <para>
	/// Use the <c>ICSeqCompressFrameStart</c>, ICSeqCompressFrame, and ICSeqCompressFrameEnd functions to compress a sequence of frames
	/// to a specified data rate and number of key frames.
	/// </para>
	/// <para>When finished with compression, use the ICCompressorFree function to release the resources specified in COMPVARS.</para>
	/// <para>
	/// COMPVARS needs to be initialized before you use this function. You can initialize the structure manually or you can allow the
	/// user to specify a compressor and initialize a <c>COMPVARS</c> structure by using the ICCompressorChoose function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icseqcompressframestart BOOL VFWAPI ICSeqCompressFrameStart(
	// PCOMPVARS pc, LPBITMAPINFO lpbiIn );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSeqCompressFrameStart")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ICSeqCompressFrameStart(in COMPVARS pc, in BITMAPINFO lpbiIn);

	/// <summary>
	/// The <c>ICSetState</c> macro notifies a video compression driver to set the state of the compressor. You can use this macro or
	/// explicitly call the ICM_SETSTATE message.
	/// </summary>
	/// <param name="hic">Handle of the compressor.</param>
	/// <param name="pv">
	/// Pointer to a block of memory containing configuration data. You can specify <c>NULL</c> for this parameter to reset the
	/// compressor to its default state.
	/// </param>
	/// <param name="cb">Size, in bytes, of the block of memory.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// The information used by this message is private and specific to a given compressor. Client applications should use this message
	/// only to restore information previously obtained with the ICGetState and ICConfigure macros and should use the <c>ICConfigure</c>
	/// macro to adjust the configuration of a video compression driver.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icsetstate void ICSetState( hic, pv, cb );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSetState")]
	public static ICERR ICSetState([In] HIC hic, [In] IntPtr pv, uint cb) => (ICERR)ICSendMessage(hic, ICM_Message.ICM_SETSTATE, pv, new IntPtr((int)cb)).ToInt32();

	/// <summary>
	/// The <c>ICSetStatusProc</c> function sends the address of a status callback function to a compressor. The compressor calls this
	/// function during lengthy operations.
	/// </summary>
	/// <param name="hic">Handle to the compressor.</param>
	/// <param name="dwFlags">Applicable flags. Set to zero.</param>
	/// <param name="lParam">Constant specified with the status callback address.</param>
	/// <param name="fpfnStatus">
	/// Pointer to the status callback function. Specify <c>NULL</c> to indicate no status callbacks should be sent.
	/// </param>
	/// <returns>Returns ICERR_OK if successful or <c>FALSE</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-icsetstatusproc LRESULT VFWAPI_INLINE ICSetStatusProc( HIC hic,
	// DWORD dwFlags, LRESULT lParam, LONG(* )(LPARAM,UINT,LONG) fpfnStatus );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSetStatusProc")]
	public static IntPtr ICSetStatusProc([In] HIC hic, [Optional] uint dwFlags, [In] IntPtr lParam, [Optional] Func<IntPtr, uint, int, int> fpfnStatus) =>
		ICSendMessage(hic, ICM_Message.ICM_SET_STATUS_PROC, new ICSETSTATUSPROC() { dwFlags = dwFlags, lParam = lParam, Status = fpfnStatus });

	/// <summary>
	/// The <c>StretchDIB</c> function copies a device independent bitmap from one memory location to another and resizes the image to
	/// fit the destination rectangle.
	/// </summary>
	/// <param name="biDst">Pointer to a BITMAPINFOHEADER structure that describes the destination bitmap.</param>
	/// <param name="lpDst">Pointer to the memory buffer that will receive the copied pixel bits.</param>
	/// <param name="DstX">X coordinate of the destination rectangle's origin.</param>
	/// <param name="DstY">Y coordinate of the destination rectangle's origin.</param>
	/// <param name="DstXE">Width, in pixels, of the destination rectangle.</param>
	/// <param name="DstYE">Height, in pixels, of the destination rectangle.</param>
	/// <param name="biSrc">Pointer to a BITMAPINFOHEADER structure that describes the source bitmap.</param>
	/// <param name="lpSrc">Pointer to the source bitmap data.</param>
	/// <param name="SrcX">X coordinate of the source rectangle's origin.</param>
	/// <param name="SrcY">Y coordinate of the source rectangle's origin.</param>
	/// <param name="SrcXE">Width, in pixels, of the source rectangle.</param>
	/// <param name="SrcYE">Height, in pixels, of the source rectangle.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The size of the destination buffer must be large enough to accommodate any alignment bytes at the end of each pixel row.</para>
	/// <para>
	/// This function does nothing if biSrc and biDst have different values for biBitCount or if the value for biSrc. biBitCount does
	/// not equal 8, 16, or 24.
	/// </para>
	/// <para>
	/// This function performs no dithering or other smoothing. Pixel values are merely dropped or duplicated on a line-by-line,
	/// column-by-column basis.
	/// </para>
	/// <para>
	/// This function does not do any special processing based on pixel encoding except for calculating the number of bits per pixel. In
	/// particular this function will not generate correct results when pixels are encoded in groups of more than 1 pixel, as in the
	/// case of a YUV format where U and V are decimated and so are not represented equally in each pixel.
	/// </para>
	/// <para>Before including Vfw.h, you must add the following line to your code:</para>
	/// <para>
	/// <code> #define DRAWDIB_INCLUDE_STRETCHDIB</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-stretchdib void StretchDIB( LPBITMAPINFOHEADER biDst, LPVOID lpDst,
	// int DstX, int DstY, int DstXE, int DstYE, LPBITMAPINFOHEADER biSrc, LPVOID lpSrc, int SrcX, int SrcY, int SrcXE, int SrcYE );
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.StretchDIB")]
	public static extern void StretchDIB(in BITMAPINFOHEADER biDst, [Out] IntPtr lpDst, int DstX, int DstY, int DstXE, int DstYE, in BITMAPINFOHEADER biSrc, [In] IntPtr lpSrc, int SrcX, int SrcY, int SrcXE, int SrcYE);

	internal static ICERR ICSendGetMessage<T>(HIC hic, ICM_Message msg, out T val) where T : unmanaged
	{
		unsafe
		{
			T dw = default;
			var ret = (ICERR)ICSendMessage(hic, msg, (IntPtr)(void*)&dw).ToInt32();
			val = dw;
			return ret;
		}
	}

	/// <summary>The <c>ICSendMessage</c> function sends a message to a compressor.</summary>
	/// <param name="hic">Handle to the compressor to receive the message.</param>
	/// <param name="msg">Message to send.</param>
	/// <param name="lpbiInput">Additional message-specific information.</param>
	/// <param name="lpbiOutput">Additional message-specific information.</param>
	/// <returns>Returns a message-specific result.</returns>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.ICSendMessage")]
	internal static IntPtr ICSendMessage(HIC hic, ICM_Message msg, [In] SafeBITMAPINFO? lpbiInput, [In, Optional] SafeBITMAPINFO? lpbiOutput) =>
		ICSendMessage(hic, msg, lpbiInput ?? SafeBITMAPINFO.Null, lpbiOutput ?? SafeBITMAPINFO.Null);

	/// <summary>
	/// The <c>COMPVARS</c> structure describes compressor settings for functions such as ICCompressorChoose, ICSeqCompressFrame, and ICCompressorFree.
	/// </summary>
	/// <remarks>
	/// You can let ICCompressorChoose fill the contents of this structure or you can do it manually. If you manually fill the
	/// structure, you must provide information for the following members: <c>cbSize</c>, <c>hic</c>, <c>lpbiOut</c>, <c>lKey</c>, and
	/// <c>lQ</c>. Also, you must set the <c>ICMF_COMPVARS_VALID</c> flag in the <c>dwFlags</c> member.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-compvars typedef struct { LONG cbSize; DWORD dwFlags; HIC hic;
	// DWORD fccType; DWORD fccHandler; LPBITMAPINFO lpbiIn; LPBITMAPINFO lpbiOut; LPVOID lpBitsOut; LPVOID lpBitsPrev; LONG lFrame;
	// LONG lKey; LONG lDataRate; LONG lQ; LONG lKeyCount; LPVOID lpState; LONG cbState; } COMPVARS, *PCOMPVARS;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_11")]
	[StructLayout(LayoutKind.Sequential)]
	public struct COMPVARS
	{
		/// <summary>
		/// Size, in bytes, of this structure. This member must be set to validate the structure before calling any function using this structure.
		/// </summary>
		public int cbSize;

		/// <summary>
		/// <para>Applicable flags. The following value is defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ICMF_COMPVARS_VALID</term>
		/// <term>
		/// Data in this structure is valid and has been manually entered. Set this flag before you call any function if you fill this
		/// structure manually. Do not set this flag if you let ICCompressorChoose initialize this structure.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ICMF_COMPVARS dwFlags;

		/// <summary>
		/// Handle to the compressor to use. You can open a compressor and obtain a handle of it by using the ICOpen function. You can
		/// also choose a compressor by using ICCompressorChoose. <c>ICCompressorChoose</c> opens the chosen compressor and returns the
		/// handle of the compressor in this member. You can close the compressor by using ICCompressorFree.
		/// </summary>
		public HIC hic;

		/// <summary>Type of compressor used. Currently only <c>ICTYPE_VIDEO</c> (VIDC) is supported. This member can be set to zero.</summary>
		public uint fccType;

		/// <summary>
		/// Four-character code of the compressor. Specify <c>NULL</c> to indicate the data is not to be recompressed. Specify "DIB" to
		/// indicate the data is an uncompressed, full frame. You can use this member to specify which compressor is selected by default
		/// when the dialog box is displayed.
		/// </summary>
		public uint fccHandler;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr lpbiIn;

		/// <summary>
		/// Pointer to a BITMAPINFO structure containing the image output format. You can specify a specific format to use or you can
		/// specify <c>NULL</c> to use the default compressor associated with the input format. You can also set the image output format
		/// by using ICCompressorChoose.
		/// </summary>
		public IntPtr lpbiOut;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr lpBitsOut;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr lpBitsPrev;

		/// <summary>Reserved; do not use.</summary>
		public int lFrame;

		/// <summary>
		/// Key-frame rate. Specify an integer to indicate the frequency that key frames are to occur in the compressed sequence or zero
		/// to not use key frames. You can also let ICCompressorChoose set the key-frame rate selected in the dialog box. The
		/// ICSeqCompressFrameStart function uses the value of this member for making key frames.
		/// </summary>
		public int lKey;

		/// <summary>
		/// Data rate, in kilobytes per second. ICCompressorChoose copies the selected data rate from the dialog box to this member.
		/// </summary>
		public int lDataRate;

		/// <summary>
		/// Quality setting. Specify a quality setting of 1 to 10,000 or specify <c>ICQUALITY_DEFAULT</c> to use the default quality
		/// setting. You can also let ICCompressorChoose set the quality value selected in the dialog box. ICSeqCompressFrameStart uses
		/// the value of this member as its quality setting.
		/// </summary>
		public int lQ;

		/// <summary>Reserved; do not use.</summary>
		public int lKeyCount;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr lpState;

		/// <summary>Reserved; do not use.</summary>
		public int cbState;
	}

	/// <summary>
	/// The <c>DRAWDIBTIME</c> structure contains elapsed timing information for performing a set of DrawDib operations. The DrawDibTime
	/// function resets the count and the elapsed time value for each operation each time it is called.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-drawdibtime typedef struct { LONG timeCount; LONG timeDraw; LONG
	// timeDecompress; LONG timeDither; LONG timeStretch; LONG timeBlt; LONG timeSetDIBits; } DRAWDIBTIME, *LPDRAWDIBTIME;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_12")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRAWDIBTIME
	{
		/// <summary>
		/// <para>Number of times the following operations have been performed since DrawDibTime was last called:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Draw a bitmap on the screen.</term>
		/// </item>
		/// <item>
		/// <term>Decompress a bitmap.</term>
		/// </item>
		/// <item>
		/// <term>Dither a bitmap.</term>
		/// </item>
		/// <item>
		/// <term>Stretch a bitmap.</term>
		/// </item>
		/// <item>
		/// <term>Transfer bitmap data by using the BitBlt function.</term>
		/// </item>
		/// <item>
		/// <term>Transfer bitmap data by using the SetDIBits function.</term>
		/// </item>
		/// </list>
		/// </summary>
		public int timeCount;

		/// <summary>Time to draw bitmaps.</summary>
		public int timeDraw;

		/// <summary>Time to decompress bitmaps.</summary>
		public int timeDecompress;

		/// <summary>Time to dither bitmaps.</summary>
		public int timeDither;

		/// <summary>Time to stretch bitmaps.</summary>
		public int timeStretch;

		/// <summary>Time to transfer bitmaps by using the BitBlt function.</summary>
		public int timeBlt;

		/// <summary>Time to transfer bitmaps by using the SetDIBits function.</summary>
		public int timeSetDIBits;
	}

	/// <summary>The <c>ICCOMPRESS</c> structure contains compression parameters used with the ICM_COMPRESS message.</summary>
	/// <remarks>
	/// Drivers that perform temporal compression use data from the previous frame (found in the <c>lpbiPrev</c> and <c>lpPrev</c>
	/// members) to prune redundant data from the current frame.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-iccompress typedef struct { DWORD dwFlags; LPBITMAPINFOHEADER
	// lpbiOutput; LPVOID lpOutput; LPBITMAPINFOHEADER lpbiInput; LPVOID lpInput; LPDWORD lpckid; LPDWORD lpdwFlags; LONG lFrameNum;
	// DWORD dwFrameSize; DWORD dwQuality; LPBITMAPINFOHEADER lpbiPrev; LPVOID lpPrev; } ICCOMPRESS;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ICCOMPRESS
	{
		/// <summary>
		/// <para>Flags used for compression. The following value is defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ICCOMPRESS_KEYFRAME</term>
		/// <term>Input data should be treated as a key frame.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ICCOMPRESSF dwFlags;

		/// <summary>
		/// Pointer to a BITMAPINFOHEADER structure containing the output (compressed) format. The <c>biSizeImage</c> member must
		/// contain the size of the compressed data.
		/// </summary>
		public IntPtr lpbiOutput;

		/// <summary>Pointer to the buffer where the driver should write the compressed data.</summary>
		public IntPtr lpOutput;

		/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input (uncompressed) format.</summary>
		public IntPtr lpbiInput;

		/// <summary>Pointer to the buffer containing input data.</summary>
		public IntPtr lpInput;

		/// <summary>
		/// Address to contain the chunk identifier for data in the AVI file. If the value of this member is not <c>NULL</c>, the driver
		/// should specify a two-character code for the chunk identifier corresponding to the chunk identifier used in the AVI file.
		/// </summary>
		public uint lpckid;

		/// <summary>
		/// Address to contain flags for the AVI index. If the returned frame is a key frame, the driver should set the
		/// <c>AVIIF_KEYFRAME</c> flag.
		/// </summary>
		public uint lpdwFlags;

		/// <summary>Number of the frame to compress.</summary>
		public int lFrameNum;

		/// <summary>
		/// Desired maximum size, in bytes, for compressing this frame. The size value is used for compression methods that can make
		/// tradeoffs between compressed image size and image quality. Specify zero for this member to use the default setting.
		/// </summary>
		public uint dwFrameSize;

		/// <summary>Quality setting.</summary>
		public uint dwQuality;

		/// <summary>
		/// Pointer to a BITMAPINFOHEADER structure containing the format of the previous frame, which is typically the same as the
		/// input format.
		/// </summary>
		public IntPtr lpbiPrev;

		/// <summary>Pointer to the buffer containing input data of the previous frame.</summary>
		public IntPtr lpPrev;
	}

	/// <summary>The <c>ICCOMPRESSFRAMES</c> structure contains compression parameters used with the ICM_COMPRESS_FRAMES_INFO message.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-iccompressframes typedef struct { DWORD dwFlags; LPBITMAPINFOHEADER
	// lpbiOutput; LPARAM lOutput; LPBITMAPINFOHEADER lpbiInput; LPARAM lInput; LONG lStartFrame; LONG lFrameCount; LONG lQuality; LONG
	// lDataRate; LONG lKeyRate; DWORD dwRate; DWORD dwScale; DWORD dwOverheadPerFrame; DWORD dwReserved2; LONG( )(LPARAM lInput,LONG
	// lFrame,LPVOID lpBits,LONG len) *GetData; LONG( )(LPARAM lOutput,LONG lFrame,LPVOID lpBits,LONG len) *PutData; } ICCOMPRESSFRAMES;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ICCOMPRESSFRAMES
	{
		/// <summary>
		/// Applicable flags. The following value is defined: <c>ICCOMPRESSFRAMES_PADDING</c>. If this value is used, padding is used
		/// with the frame.
		/// </summary>
		public ICCOMPRESSFRAMESF dwFlags;

		/// <summary>Pointer to a BITMAPINFOHEADER structure containing the output format.</summary>
		public IntPtr lpbiOutput;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr lOutput;

		/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input format.</summary>
		public IntPtr lpbiInput;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr lInput;

		/// <summary>Number of the first frame to compress.</summary>
		public int lStartFrame;

		/// <summary>Number of frames to compress.</summary>
		public int lFrameCount;

		/// <summary>Quality setting.</summary>
		public int lQuality;

		/// <summary>Maximum data rate, in bytes per second.</summary>
		public int lDataRate;

		/// <summary>Maximum number of frames between consecutive key frames.</summary>
		public int lKeyRate;

		/// <summary>
		/// Compression rate in an integer format. To obtain the rate in frames per second, divide this value by the value in <c>dwScale</c>.
		/// </summary>
		public uint dwRate;

		/// <summary>Value used to scale <c>dwRate</c> to frames per second.</summary>
		public uint dwScale;

		/// <summary>Reserved; do not use.</summary>
		public uint dwOverheadPerFrame;

		/// <summary>Reserved; do not use.</summary>
		public uint dwReserved2;
	}

	/// <summary>The <c>ICDECOMPRESS</c> structure contains decompression parameters used with the ICM_DECOMPRESS message.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdecompress typedef struct { DWORD dwFlags; LPBITMAPINFOHEADER
	// lpbiInput; LPVOID lpInput; LPBITMAPINFOHEADER lpbiOutput; LPVOID lpOutput; DWORD ckid; } ICDECOMPRESS;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_5")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ICDECOMPRESS
	{
		/// <summary>
		/// <para>Applicable flags. The following values are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ICDECOMPRESS_HURRYUP</term>
		/// <term>
		/// Tries to decompress at a faster rate. When an application uses this flag, the driver should buffer the decompressed data but
		/// not draw the image.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ICDECOMPRESS_NOTKEYFRAME</term>
		/// <term>Current frame is not a key frame.</term>
		/// </item>
		/// <item>
		/// <term>ICDECOMPRESS_NULLFRAME</term>
		/// <term>Current frame does not contain data and the decompressed image should be left the same.</term>
		/// </item>
		/// <item>
		/// <term>ICDECOMPRESS_PREROLL</term>
		/// <term>Current frame precedes the point in the movie where playback starts and, therefore, will not be drawn.</term>
		/// </item>
		/// <item>
		/// <term>ICDECOMPRESS_UPDATE</term>
		/// <term>Screen is being updated or refreshed.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ICDECOMPRESSF dwFlags;

		/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input format.</summary>
		public IntPtr lpbiInput;

		/// <summary>Pointer to a buffer containing the input data.</summary>
		public IntPtr lpInput;

		/// <summary>Pointer to a BITMAPINFOHEADER structure containing the output format.</summary>
		public IntPtr lpbiOutput;

		/// <summary>Pointer to a buffer where the driver should write the decompressed image.</summary>
		public IntPtr lpOutput;

		/// <summary>Chunk identifier from the AVI file.</summary>
		public uint ckid;
	}

	/// <summary>The <c>ICDECOMPRESSEX</c> structure contains decompression parameters used with the ICM_DECOMPRESSEX message</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdecompressex typedef struct { DWORD dwFlags; LPBITMAPINFOHEADER
	// lpbiSrc; LPVOID lpSrc; LPBITMAPINFOHEADER lpbiDst; LPVOID lpDst; int xDst; int yDst; int dxDst; int dyDst; int xSrc; int ySrc;
	// int dxSrc; int dySrc; } ICDECOMPRESSEX;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ICDECOMPRESSEX
	{
		/// <summary>
		/// <para>Applicable flags. The following values are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ICDECOMPRESS_HURRYUP</term>
		/// <term>
		/// Tries to decompress at a faster rate. When an application uses this flag, the driver should buffer the decompressed data but
		/// not draw the image.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ICDECOMPRESS_NOTKEYFRAME</term>
		/// <term>Current frame is not a key frame.</term>
		/// </item>
		/// <item>
		/// <term>ICDECOMPRESS_NULLFRAME</term>
		/// <term>Current frame does not contain data and the decompressed image should be left the same.</term>
		/// </item>
		/// <item>
		/// <term>ICDECOMPRESS_PREROLL</term>
		/// <term>Current frame precedes the point in the movie where playback starts and, therefore, will not be drawn.</term>
		/// </item>
		/// <item>
		/// <term>ICDECOMPRESS_UPDATE</term>
		/// <term>Screen is being updated or refreshed.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ICDECOMPRESSF dwFlags;

		/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input format.</summary>
		public IntPtr lpbiSrc;

		/// <summary>Pointer to a buffer containing the input data.</summary>
		public IntPtr lpSrc;

		/// <summary>Pointer to a BITMAPINFOHEADER structure containing the output format.</summary>
		public IntPtr lpbiDst;

		/// <summary>Pointer to a buffer where the driver should write the decompressed image.</summary>
		public IntPtr lpDst;

		/// <summary>The x-coordinate of the destination rectangle within the DIB specified by <c>lpbiDst</c>.</summary>
		public int xDst;

		/// <summary>The y-coordinate of the destination rectangle within the DIB specified by <c>lpbiDst</c>.</summary>
		public int yDst;

		/// <summary>Width of the destination rectangle.</summary>
		public int dxDst;

		/// <summary>Height of the destination rectangle.</summary>
		public int dyDst;

		/// <summary>The x-coordinate of the source rectangle within the DIB specified by <c>lpbiSrc</c>.</summary>
		public int xSrc;

		/// <summary>The y-coordinate of the source rectangle within the DIB specified by <c>lpbiSrc</c>.</summary>
		public int ySrc;

		/// <summary>Width of the source rectangle.</summary>
		public int dxSrc;

		/// <summary>Height of the source rectangle.</summary>
		public int dySrc;
	}

	/// <summary>
	/// The <c>ICDRAW</c> structure contains parameters for drawing video data to the screen. This structure is used with the ICM_DRAW message.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdraw typedef struct { DWORD dwFlags; LPVOID lpFormat; LPVOID
	// lpData; DWORD cbData; LONG lTime; } ICDRAW;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_8")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ICDRAW
	{
		/// <summary>
		/// <para>Flags from the AVI file index. The following values are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ICDRAW_HURRYUP</term>
		/// <term>Data is buffered and not drawn to the screen. Use this flag for fastest decompression.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_NOTKEYFRAME</term>
		/// <term>Current frame is not a key frame.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_NULLFRAME</term>
		/// <term>Current frame does not contain any data, and the previous frame should be redrawn.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_PREROLL</term>
		/// <term>
		/// Current frame of video occurs before playback should start. For example, if playback will begin on frame 10, and frame 0 is
		/// the nearest previous key frame, frames 0 through 9 are sent to the driver with this flag set. The driver needs this data to
		/// display frame 10 properly.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_UPDATE</term>
		/// <term>Updates the screen based on data previously received. In this case, lpData should be ignored.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ICDRAWF dwFlags;

		/// <summary>Pointer to a structure containing the data format. For video streams, this is a BITMAPINFOHEADER structure.</summary>
		public IntPtr lpFormat;

		/// <summary>Pointer to the data to render.</summary>
		public IntPtr lpData;

		/// <summary>Number of data bytes to render.</summary>
		public uint cbData;

		/// <summary>Time, in samples, when this data should be drawn. For video data this is normally a frame number.</summary>
		public int lTime;
	}

	/// <summary>The <c>ICDRAWBEGIN</c> structure contains decompression parameters used with the ICM_DRAW_BEGIN message.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdrawbegin typedef struct { DWORD dwFlags; HPALETTE hpal; HWND
	// hwnd; HDC hdc; int xDst; int yDst; int dxDst; int dyDst; LPBITMAPINFOHEADER lpbi; int xSrc; int ySrc; int dxSrc; int dySrc; DWORD
	// dwRate; DWORD dwScale; } ICDRAWBEGIN;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ICDRAWBEGIN
	{
		/// <summary>
		/// <para>Applicable flags. The following values are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ICDRAW_ANIMATE</term>
		/// <term>Application can animate the palette.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_BUFFER</term>
		/// <term>Buffers this data off-screen; it will need to be updated.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_CONTINUE</term>
		/// <term>Drawing is a continuation of the previous frame.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_FULLSCREEN</term>
		/// <term>Draws the decompressed data on the full screen.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_HDC</term>
		/// <term>Draws the decompressed data to a window or a DC.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_MEMORYDC</term>
		/// <term>DC is off-screen.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_QUERY</term>
		/// <term>Determines if the decompressor can handle the decompression. The driver does not actually decompress the data.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_RENDER</term>
		/// <term>Renders but does not draw the data.</term>
		/// </item>
		/// <item>
		/// <term>ICDRAW_UPDATING</term>
		/// <term>Current frame is being updated rather than played.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ICDRAWF dwFlags;

		/// <summary>Handle to the palette used for drawing.</summary>
		public HPALETTE hpal;

		/// <summary>Handle to the window used for drawing.</summary>
		public HWND hwnd;

		/// <summary>Handle to the DC used for drawing. Specify <c>NULL</c> to use a DC associated with the specified window.</summary>
		public HDC hdc;

		/// <summary>The x-coordinate of the destination rectangle.</summary>
		public int xDst;

		/// <summary>The y-coordinate of the destination rectangle.</summary>
		public int yDst;

		/// <summary>Width of the destination rectangle.</summary>
		public int dxDst;

		/// <summary>Height of the destination rectangle.</summary>
		public int dyDst;

		/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input format.</summary>
		public IntPtr lpbi;

		/// <summary>The x-coordinate of the source rectangle.</summary>
		public int xSrc;

		/// <summary>The y-coordinate of the source rectangle.</summary>
		public int ySrc;

		/// <summary>Width of the source rectangle.</summary>
		public int dxSrc;

		/// <summary>Height of the source rectangle.</summary>
		public int dySrc;

		/// <summary>
		/// Decompression rate in an integer format. To obtain the rate in frames per second, divide this value by the value in <c>dwScale</c>.
		/// </summary>
		public uint dwRate;

		/// <summary>Value used to scale <c>dwRate</c> to frames per second.</summary>
		public uint dwScale;
	}

	/// <summary>
	/// The <c>ICDRAWSUGGEST</c> structure contains compression parameters used with the ICM_DRAW_SUGGESTFORMAT message to suggest an
	/// appropriate input format.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdrawsuggest typedef struct { LPBITMAPINFOHEADER lpbiIn;
	// LPBITMAPINFOHEADER lpbiSuggest; int dxSrc; int dySrc; int dxDst; int dyDst; HIC hicDecompressor; } ICDRAWSUGGEST;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ICDRAWSUGGEST
	{
		/// <summary>Pointer to the structure containing the compressed input format.</summary>
		public IntPtr lpbiIn;

		/// <summary>Pointer to a buffer to return a compatible input format for the renderer.</summary>
		public IntPtr lpbiSuggest;

		/// <summary>Width of the source rectangle.</summary>
		public int dxSrc;

		/// <summary>Height of the source rectangle.</summary>
		public int dySrc;

		/// <summary>Width of the destination rectangle.</summary>
		public int dxDst;

		/// <summary>Height of the destination rectangle.</summary>
		public int dyDst;

		/// <summary>Handle to a decompressor that supports the format of data described in <c>lpbiIn</c>.</summary>
		public HIC hicDecompressor;
	}

	/// <summary>
	/// The <c>ICINFO</c> structure contains compression parameters supplied by a video compression driver. The driver fills or updates
	/// the structure when it receives the ICM_GETINFO message.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icinfo typedef struct { DWORD dwSize; DWORD fccType; DWORD
	// fccHandler; DWORD dwFlags; DWORD dwVersion; DWORD dwVersionICM; WCHAR szName[16]; WCHAR szDescription[128]; WCHAR szDriver[128];
	// } ICINFO;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ICINFO
	{
		/// <summary>Size, in bytes, of the <c>ICINFO</c> structure.</summary>
		public uint dwSize;

		/// <summary>
		/// Four-character code indicating the type of stream being compressed or decompressed. Specify "VIDC" for video streams.
		/// </summary>
		public uint fccType;

		/// <summary>A four-character code identifying a specific compressor.</summary>
		public uint fccHandler;

		/// <summary>
		/// <para>Applicable flags. Zero or more of the following flags can be set:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>VIDCF_COMPRESSFRAMES</term>
		/// <term>
		/// Driver is requesting to compress all frames. For information about compressing all frames, see the ICM_COMPRESS_FRAMES_INFO message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VIDCF_CRUNCH</term>
		/// <term>Driver supports compressing to a frame size.</term>
		/// </item>
		/// <item>
		/// <term>VIDCF_DRAW</term>
		/// <term>Driver supports drawing.</term>
		/// </item>
		/// <item>
		/// <term>VIDCF_FASTTEMPORALC</term>
		/// <term>
		/// Driver can perform temporal compression and maintains its own copy of the current frame. When compressing a stream of frame
		/// data, the driver doesn't need image data from the previous frame.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VIDCF_FASTTEMPORALD</term>
		/// <term>
		/// Driver can perform temporal decompression and maintains its own copy of the current frame. When decompressing a stream of
		/// frame data, the driver doesn't need image data from the previous frame.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VIDCF_QUALITY</term>
		/// <term>Driver supports quality values.</term>
		/// </item>
		/// <item>
		/// <term>VIDCF_TEMPORAL</term>
		/// <term>Driver supports inter-frame compression.</term>
		/// </item>
		/// </list>
		/// </summary>
		public VIDCF dwFlags;

		/// <summary>Version number of the driver.</summary>
		public uint dwVersion;

		/// <summary>Version of VCM supported by the driver. This member should be set to ICVERSION.</summary>
		public uint dwVersionICM;

		/// <summary>
		/// Short version of the compressor name. The name in the null-terminated string should be suitable for use in list boxes.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string szName;

		/// <summary>Long version of the compressor name.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string szDescription;

		/// <summary>Name of the module containing VCM compression driver. Normally, a driver does not need to fill this out.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string szDriver;
	}

	/// <summary>
	/// The <c>ICOPEN</c> structure contains information about the data stream being compressed or decompressed, the version number of
	/// the driver, and how the driver is used.
	/// </summary>
	/// <remarks>
	/// This structure is passed to video capture drivers when they are opened. This allows a single installable driver to function as
	/// either an installable compressor or a video capture device. By examining the <c>fccType</c> member of the <c>ICOPEN</c>
	/// structure, the driver can determine its function. For example, a <c>fccType</c> value of "VIDC" indicates that it is opened as
	/// an installable video compressor.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icopen typedef struct { DWORD dwSize; DWORD fccType; DWORD
	// fccHandler; DWORD dwVersion; DWORD dwFlags; LRESULT dwError; LPVOID pV1Reserved; LPVOID pV2Reserved; DWORD dnDevNode; } ICOPEN;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_0")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct ICOPEN
	{
		/// <summary>Size, in bytes, of the structure.</summary>
		public uint dwSize;

		/// <summary>
		/// Four-character code indicating the type of stream being compressed or decompressed. Specify "VIDC" for video streams.
		/// </summary>
		public uint fccType;

		/// <summary>Four-character code identifying a specific compressor.</summary>
		public uint fccHandler;

		/// <summary>Version of the installable driver interface used to open the driver.</summary>
		public uint dwVersion;

		/// <summary>
		/// <para>Applicable flags indicating why the driver is opened. The following values are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ICMODE_COMPRESS</term>
		/// <term>Driver is opened to compress data.</term>
		/// </item>
		/// <item>
		/// <term>ICMODE_DECOMPRESS</term>
		/// <term>Driver is opened to decompress data.</term>
		/// </item>
		/// <item>
		/// <term>ICMODE_DRAW</term>
		/// <term>Device driver is opened to decompress data directly to hardware.</term>
		/// </item>
		/// <item>
		/// <term>ICMODE_QUERY</term>
		/// <term>Driver is opened for informational purposes, rather than for compression.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ICMODE dwFlags;

		private readonly ushort dwFlagsPadding;

		/// <summary/>
		public IntPtr dwError;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr pV1Reserved;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr pV2Reserved;

		/// <summary>Device node for plug and play devices.</summary>
		public uint dnDevNode;
	}

	/// <summary>The <c>ICSETSTATUSPROC</c> structure contains status information used with the ICM_SET_STATUS_PROC message.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icsetstatusproc typedef struct { DWORD dwFlags; LPARAM lParam;
	// LONG( )(LPARAM lParam,UINT message,LONG l) *Status; } ICSETSTATUSPROC;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ICSETSTATUSPROC
	{
		/// <summary>Reserved; set to zero.</summary>
		public uint dwFlags;

		/// <summary>Parameter that contains a constant to pass to the status procedure.</summary>
		public IntPtr lParam;

		/// <summary/>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public Func<IntPtr, uint, int, int> Status;
	}
}