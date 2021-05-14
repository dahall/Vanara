#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke
{
	/// <summary>Items from the Msvfw32.dll</summary>
	public static partial class Msvfw32
	{
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
		public static extern bool DrawDibDraw([In] HDRAWDIB hdd, [In] HDC hdc, int xDst, int yDst, int dxDst, int dyDst, [In, Optional] IntPtr lpbi, [In, Optional] IntPtr lpBits, int xSrc, int ySrc, int dxSrc, int dySrc, DDF wFlags);

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
		public static bool DrawDibUpdate([In] HDRAWDIB hdd, [In] HDC hdc, int x, int y) => DrawDibDraw(hdd, hdc, x, y, 0, 0, default, default, 0, 0, 0, 0, DDF.DDF_UPDATE);

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

		/// <summary>Provides a handle to a DrawDib DC.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HDRAWDIB : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HDRAWDIB"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HDRAWDIB(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HDRAWDIB"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HDRAWDIB NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HDRAWDIB"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HDRAWDIB h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDRAWDIB"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HDRAWDIB(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HDRAWDIB h1, HDRAWDIB h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HDRAWDIB h1, HDRAWDIB h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HDRAWDIB h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HDRAWDIB"/> that is disposed using <see cref="DrawDibClose"/>.</summary>
		public class SafeHDRAWDIB : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHDRAWDIB"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHDRAWDIB(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHDRAWDIB"/> class.</summary>
			private SafeHDRAWDIB() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHDRAWDIB"/> to <see cref="HDRAWDIB"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HDRAWDIB(SafeHDRAWDIB h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DrawDibClose(handle);
		}

		/*
		ICAbout
		ICClose
		ICCompress
		ICCompressBegin
		ICCompressEnd
		ICCompressGetFormat
		ICCompressGetFormatSize
		ICCompressGetSize
		ICCompressorChoose
		ICCompressorFree
		ICCompressQuery
		ICConfigure
		ICDecompress
		ICDecompressBegin
		ICDecompressEnd
		ICDecompressEx
		ICDecompressExBegin
		ICDecompressExEnd
		ICDecompressExQuery
		ICDecompressGetFormat
		ICDecompressGetFormatSize
		ICDecompressGetPalette
		ICDecompressOpen
		ICDecompressQuery
		ICDecompressSetPalette
		ICDraw
		ICDrawBegin
		ICDrawChangePalette
		ICDrawEnd
		ICDrawFlush
		ICDrawGetTime
		ICDrawOpen
		ICDrawQuery
		ICDrawRealize
		ICDrawRenderBuffer
		ICDrawSetTime
		ICDrawStart
		ICDrawStartPlay
		ICDrawStop
		ICDrawStopPlay
		ICDrawSuggestFormat
		ICDrawWindow
		ICGetBuffersWanted
		ICGetDefaultKeyFrameRate
		ICGetDefaultQuality
		ICGetDisplayFormat
		ICGetInfo
		ICGetState
		ICGetStateSize
		ICImageCompress
		ICImageDecompress
		ICInfo
		ICInstall
		ICLocate
		ICOpen
		ICOpenFunction
		ICQueryAbout
		ICQueryConfigure
		ICRemove
		ICSendMessage
		ICSeqCompressFrame
		ICSeqCompressFrameEnd
		ICSeqCompressFrameStart
		ICSetState
		ICSetStatusProc
		*/
	}
}