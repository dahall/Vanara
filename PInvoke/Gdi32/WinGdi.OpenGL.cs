using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>A set of bit flags that specify properties of the pixel buffer.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "1480dea3-ae74-4e8b-b4de-fca8de5d8395")]
	[Flags]
	public enum PFD_FLAGS : uint
	{
		/// <summary>The buffer is double-buffered. This flag and PFD_SUPPORT_GDI are mutually exclusive in the current generic implementation.</summary>
		PFD_DOUBLEBUFFER = 0x00000001,

		/// <summary>The buffer is stereoscopic. This flag is not supported in the current generic implementation.</summary>
		PFD_STEREO = 0x00000002,

		/// <summary>The buffer can draw to a window or device surface.</summary>
		PFD_DRAW_TO_WINDOW = 0x00000004,

		/// <summary>The buffer can draw to a memory bitmap.</summary>
		PFD_DRAW_TO_BITMAP = 0x00000008,

		/// <summary>
		/// The buffer supports GDI drawing. This flag and PFD_DOUBLEBUFFER are mutually exclusive in the current generic implementation.
		/// </summary>
		PFD_SUPPORT_GDI = 0x00000010,

		/// <summary>The buffer supports OpenGL drawing.</summary>
		PFD_SUPPORT_OPENGL = 0x00000020,

		/// <summary>
		/// The pixel format is supported by the GDI software implementation, which is also known as the generic implementation. If this
		/// bit is clear, the pixel format is supported by a device driver or hardware.
		/// </summary>
		PFD_GENERIC_FORMAT = 0x00000040,

		/// <summary>
		/// The buffer uses RGBA pixels on a palette-managed device. A logical palette is required to achieve the best results for this
		/// pixel type. Colors in the palette should be specified according to the values of the cRedBits, cRedShift, cGreenBits,
		/// cGreenShift, cBluebits, and cBlueShift members. The palette should be created and realized in the device context before
		/// calling wglMakeCurrent.
		/// </summary>
		PFD_NEED_PALETTE = 0x00000080,

		/// <summary>
		/// Defined in the pixel format descriptors of hardware that supports one hardware palette in 256-color mode only. For such
		/// systems to use hardware acceleration, the hardware palette must be in a fixed order (for example, 3-3-2) when in RGBA mode or
		/// must match the logical palette when in color-index mode.When this flag is set, you must call SetSystemPaletteUse in your
		/// program to force a one-to-one mapping of the logical palette and the system palette. If your OpenGL hardware supports
		/// multiple hardware palettes and the device driver can allocate spare hardware palettes for OpenGL, this flag is typically clear.
		/// <para>This flag is not set in the generic pixel formats.</para>
		/// </summary>
		PFD_NEED_SYSTEM_PALETTE = 0x00000100,

		/// <summary>
		/// Specifies the content of the back buffer in the double-buffered main color plane following a buffer swap. Swapping the color
		/// buffers causes the exchange of the back buffer's content with the front buffer's content. Following the swap, the back
		/// buffer's content contains the front buffer's content before the swap. PFD_SWAP_EXCHANGE is a hint only and might not be
		/// provided by a driver.
		/// </summary>
		PFD_SWAP_EXCHANGE = 0x00000200,

		/// <summary>
		/// Specifies the content of the back buffer in the double-buffered main color plane following a buffer swap. Swapping the color
		/// buffers causes the content of the back buffer to be copied to the front buffer. The content of the back buffer is not
		/// affected by the swap. PFD_SWAP_COPY is a hint only and might not be provided by a driver.
		/// </summary>
		PFD_SWAP_COPY = 0x00000400,

		/// <summary>
		/// Indicates whether a device can swap individual layer planes with pixel formats that include double-buffered overlay or
		/// underlay planes. Otherwise all layer planes are swapped together as a group. When this flag is set, wglSwapLayerBuffers is supported.
		/// </summary>
		PFD_SWAP_LAYER_BUFFERS = 0x00000800,

		/// <summary>
		/// The pixel format is supported by a device driver that accelerates the generic implementation. If this flag is clear and the
		/// PFD_GENERIC_FORMAT flag is set, the pixel format is supported by the generic implementation only.
		/// </summary>
		PFD_GENERIC_ACCELERATED = 0x00001000,

		/// <summary>The PFD support directdraw</summary>
		PFD_SUPPORT_DIRECTDRAW = 0x00002000,

		/// <summary>The PFD direc t3 d accelerated</summary>
		PFD_DIRECT3D_ACCELERATED = 0x00004000,

		/// <summary>The PFD support composition</summary>
		PFD_SUPPORT_COMPOSITION = 0x00008000,

		/// <summary>
		/// The requested pixel format can either have or not have a depth buffer. To select a pixel format without a depth buffer, you
		/// must specify this flag. The requested pixel format can be with or without a depth buffer. Otherwise, only pixel formats with
		/// a depth buffer are considered.
		/// </summary>
		PFD_DEPTH_DONTCARE = 0x20000000,

		/// <summary>The requested pixel format can be either single- or double-buffered.</summary>
		PFD_DOUBLEBUFFER_DONTCARE = 0x40000000,

		/// <summary>The requested pixel format can be either monoscopic or stereoscopic.</summary>
		PFD_STEREO_DONTCARE = 0x80000000,
	}

	/// <summary>The plane layer.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "1480dea3-ae74-4e8b-b4de-fca8de5d8395")]
	public enum PFD_LAYER : sbyte
	{
		/// <summary>The layer is the main plane.</summary>
		PFD_MAIN_PLANE = 0,

		/// <summary>The layer is the overlay plane.</summary>
		PFD_OVERLAY_PLANE = 1,

		/// <summary>The layer is the underlay plane.</summary>
		PFD_UNDERLAY_PLANE = -1
	}

	/// <summary>Specifies the type of pixel data.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "1480dea3-ae74-4e8b-b4de-fca8de5d8395")]
	public enum PFD_TYPE : byte
	{
		/// <summary>RGBA pixels. Each pixel has four components in this order: red, green, blue, and alpha.</summary>
		PFD_TYPE_RGBA = 0,

		/// <summary>Color-index pixels. Each pixel uses a color-index value.</summary>
		PFD_TYPE_COLORINDEX = 1,
	}

	/// <summary>
	/// The <c>ChoosePixelFormat</c> function attempts to match an appropriate pixel format supported by a device context to a given
	/// pixel format specification.
	/// </summary>
	/// <param name="hdc">
	/// Specifies the device context that the function examines to determine the best match for the pixel format descriptor pointed to by ppfd.
	/// </param>
	/// <param name="ppfd">
	/// <para>
	/// Pointer to a PIXELFORMATDESCRIPTOR structure that specifies the requested pixel format. In this context, the members of the
	/// <c>PIXELFORMATDESCRIPTOR</c> structure that ppfd points to are used as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>nSize</term>
	/// <term>Specifies the size of the PIXELFORMATDESCRIPTOR data structure. Set this member to .</term>
	/// </listheader>
	/// <item>
	/// <term>nVersion</term>
	/// <term>Specifies the version number of the PIXELFORMATDESCRIPTOR data structure. Set this member to 1.</term>
	/// </item>
	/// <item>
	/// <term>dwFlags</term>
	/// <term>
	/// A set of bit flags that specify properties of the pixel buffer. You can combine the following bit flag constants by using
	/// bitwise-OR. If any of the following flags are set, the ChoosePixelFormat function attempts to match pixel formats that also have
	/// that flag or flags set. Otherwise, ChoosePixelFormat ignores that flag in the pixel formats: PFD_DRAW_TO_WINDOW,
	/// PFD_DRAW_TO_BITMAP, PFD_SUPPORT_GDI, PFD_SUPPORT_OPENGL If any of the following flags are set, ChoosePixelFormat attempts to
	/// match pixel formats that also have that flag or flags set. Otherwise, it attempts to match pixel formats without that flag set:
	/// PFD_DOUBLEBUFFER PFD_STEREO If the following flag is set, the function ignores the PFD_DOUBLEBUFFER flag in the pixel formats:
	/// PFD_DOUBLEBUFFER_DONTCARE If the following flag is set, the function ignores the PFD_STEREO flag in the pixel formats: PFD_STEREO_DONTCARE
	/// </term>
	/// </item>
	/// <item>
	/// <term>iPixelType</term>
	/// <term>Specifies the type of pixel format for the function to consider: PFD_TYPE_RGBA, PFD_TYPE_COLORINDEX</term>
	/// </item>
	/// <item>
	/// <term>cColorBits</term>
	/// <term>Zero or greater.</term>
	/// </item>
	/// <item>
	/// <term>cRedBits</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cRedShift</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cGreenBits</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cGreenShift</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cBlueBits</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cBlueShift</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cAlphaBits</term>
	/// <term>Zero or greater.</term>
	/// </item>
	/// <item>
	/// <term>cAlphaShift</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cAccumBits</term>
	/// <term>Zero or greater.</term>
	/// </item>
	/// <item>
	/// <term>cAccumRedBits</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cAccumGreenBits</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cAccumBlueBits</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cAccumAlphaBits</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>cDepthBits</term>
	/// <term>Zero or greater.</term>
	/// </item>
	/// <item>
	/// <term>cStencilBits</term>
	/// <term>Zero or greater.</term>
	/// </item>
	/// <item>
	/// <term>cAuxBuffers</term>
	/// <term>Zero or greater.</term>
	/// </item>
	/// <item>
	/// <term>iLayerType</term>
	/// <term>Specifies one of the following layer type values: PFD_MAIN_PLANE, PFD_OVERLAY_PLANE, PFD_UNDERLAY_PLANE</term>
	/// </item>
	/// <item>
	/// <term>bReserved</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>dwLayerMask</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>dwVisibleMask</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>dwDamageMask</term>
	/// <term>Not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a pixel format index (one-based) that is the closest match to the given pixel
	/// format descriptor.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You must ensure that the pixel format matched by the <c>ChoosePixelFormat</c> function satisfies your requirements. For example,
	/// if you request a pixel format with a 24-bit RGB color buffer but the device context offers only 8-bit RGB color buffers, the
	/// function returns a pixel format with an 8-bit RGB color buffer.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code sample shows how to use <c>ChoosePixelFormat</c> to match a specified pixel format.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-choosepixelformat int ChoosePixelFormat( HDC hdc, const
	// PIXELFORMATDESCRIPTOR *ppfd );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "17bd0a2c-5257-4ae3-80f4-a5ad536169fb")]
	public static extern int ChoosePixelFormat(HDC hdc, in PIXELFORMATDESCRIPTOR ppfd);

	/// <summary>
	/// The <c>DescribePixelFormat</c> function obtains information about the pixel format identified by iPixelFormat of the device
	/// associated with hdc. The function sets the members of the PIXELFORMATDESCRIPTOR structure pointed to by ppfd with that pixel
	/// format data.
	/// </summary>
	/// <param name="hdc">Specifies the device context.</param>
	/// <param name="iPixelFormat">
	/// Index that specifies the pixel format. The pixel formats that a device context supports are identified by positive one-based
	/// integer indexes.
	/// </param>
	/// <param name="nBytes">
	/// The size, in bytes, of the structure pointed to by ppfd. The <c>DescribePixelFormat</c> function stores no more than nBytes bytes
	/// of data to that structure. Set this value to <c>sizeof</c>( <c>PIXELFORMATDESCRIPTOR</c>).
	/// </param>
	/// <param name="ppfd">
	/// Pointer to a <c>PIXELFORMATDESCRIPTOR</c> structure whose members the function sets with pixel format data. The function stores
	/// the number of bytes copied to the structure in the structure's <c>nSize</c> member. If, upon entry, ppfd is <c>NULL</c>, the
	/// function writes no data to the structure. This is useful when you only want to obtain the maximum pixel format index of a device context.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the maximum pixel format index of the device context. In addition, the function
	/// sets the members of the <c>PIXELFORMATDESCRIPTOR</c> structure pointed to by ppfd according to the specified pixel format.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-describepixelformat int DescribePixelFormat( HDC hdc, int
	// iPixelFormat, UINT nBytes, LPPIXELFORMATDESCRIPTOR ppfd );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9692a30d-c7d4-40c7-a265-72c4ebabd5f2")]
	public static extern int DescribePixelFormat(HDC hdc, int iPixelFormat, uint nBytes, ref PIXELFORMATDESCRIPTOR ppfd);

	/// <summary>The <c>GetEnhMetaFilePixelFormat</c> function retrieves pixel format information for an enhanced metafile.</summary>
	/// <param name="hemf">Identifies the enhanced metafile.</param>
	/// <param name="cbBuffer">Specifies the size, in bytes, of the buffer into which the pixel format information is copied.</param>
	/// <param name="ppfd">
	/// Pointer to a PIXELFORMATDESCRIPTOR structure that contains the logical pixel format specification. The metafile uses this
	/// structure to record the logical pixel format specification.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds and finds a pixel format, the return value is the size of the metafile's pixel format.</para>
	/// <para>If no pixel format is present, the return value is zero.</para>
	/// <para>If an error occurs and the function fails, the return value is GDI_ERROR. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When an enhanced metafile specifies a pixel format in its <c>ENHMETAHEADER</c> structure and the pixel format fits in the buffer,
	/// the pixel format information is copied into ppfd. When cbBuffer is too small to contain the pixel format of the metafile, the
	/// pixel format is not copied to the buffer. In either case, the function returns the size of the metafile's pixel format.
	/// </para>
	/// <para>For information on metafile recording and other operations, see Enhanced Metafile Operations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getenhmetafilepixelformat UINT GetEnhMetaFilePixelFormat(
	// HENHMETAFILE hemf, UINT cbBuffer, PIXELFORMATDESCRIPTOR *ppfd );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "80209210-5caa-44a9-a791-991b257d8d28")]
	public static extern uint GetEnhMetaFilePixelFormat(HENHMETAFILE hemf, uint cbBuffer, ref PIXELFORMATDESCRIPTOR ppfd);

	/// <summary>
	/// The <c>GetPixelFormat</c> function obtains the index of the currently selected pixel format of the specified device context.
	/// </summary>
	/// <param name="hdc">Specifies the device context of the currently selected pixel format index returned by the function.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the currently selected pixel format index of the specified device context. This is
	/// a positive, one-based index value.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getpixelformat
	// int GetPixelFormat( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "e9a65f3a-6932-462f-b342-a993d222fae8")]
	public static extern int GetPixelFormat(HDC hdc);

	/// <summary>
	/// The <c>SetPixelFormat</c> function sets the pixel format of the specified device context to the format specified by the
	/// iPixelFormat index.
	/// </summary>
	/// <param name="hdc">Specifies the device context whose pixel format the function attempts to set.</param>
	/// <param name="format">
	/// Index that identifies the pixel format to set. The various pixel formats supported by a device context are identified by
	/// one-based indexes.
	/// </param>
	/// <param name="ppfd">
	/// Pointer to a PIXELFORMATDESCRIPTOR structure that contains the logical pixel format specification. The system's metafile
	/// component uses this structure to record the logical pixel format specification. The structure has no other effect upon the
	/// behavior of the <c>SetPixelFormat</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If hdc references a window, calling the <c>SetPixelFormat</c> function also changes the pixel format of the window. Setting the
	/// pixel format of a window more than once can lead to significant complications for the Window Manager and for multithread
	/// applications, so it is not allowed. An application can only set the pixel format of a window one time. Once a window's pixel
	/// format is set, it cannot be changed.
	/// </para>
	/// <para>
	/// You should select a pixel format in the device context before calling the wglCreateContext function. The <c>wglCreateContext</c>
	/// function creates a rendering context for drawing on the device in the selected pixel format of the device context.
	/// </para>
	/// <para>
	/// An OpenGL window has its own pixel format. Because of this, only device contexts retrieved for the client area of an OpenGL
	/// window are allowed to draw into the window. As a result, an OpenGL window should be created with the WS_CLIPCHILDREN and
	/// WS_CLIPSIBLINGS styles. Additionally, the window class attribute should not include the CS_PARENTDC style.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows <c>SetPixelFormat</c> usage.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-setpixelformat BOOL SetPixelFormat( HDC hdc, int format,
	// const PIXELFORMATDESCRIPTOR *ppfd );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "f8d74078-a7e7-4d95-857a-f51d5d70598e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetPixelFormat(HDC hdc, int format, ref PIXELFORMATDESCRIPTOR ppfd);

	/// <summary>
	/// The <c>SwapBuffers</c> function exchanges the front and back buffers if the current pixel format for the window referenced by the
	/// specified device context includes a back buffer.
	/// </summary>
	/// <param name="Arg1">
	/// Specifies a device context. If the current pixel format for the window referenced by this device context includes a back buffer,
	/// the function exchanges the front and back buffers.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the current pixel format for the window referenced by the device context does not include a back buffer, this call has no
	/// effect and the content of the back buffer is undefined when the function returns.
	/// </para>
	/// <para>
	/// With multithread applications, flush the drawing commands in any other threads drawing to the same window before calling <c>SwapBuffers</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-swapbuffers BOOL SwapBuffers( HDC Arg1 );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2c9728e4-c5be-4b14-a6f7-2899c792ec3d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SwapBuffers(HDC Arg1);

	/// <summary>The <c>PIXELFORMATDESCRIPTOR</c> structure describes the pixel format of a drawing surface.</summary>
	/// <remarks>
	/// Please notice carefully, as documented above, that certain pixel format properties are not supported in the current generic
	/// implementation. The generic implementation is the Microsoft GDI software implementation of OpenGL. Hardware manufacturers may
	/// enhance parts of OpenGL, and may support some pixel format properties not supported by the generic implementation.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-tagpixelformatdescriptor typedef struct
	// tagPIXELFORMATDESCRIPTOR { WORD nSize; WORD nVersion; DWORD dwFlags; BYTE iPixelType; BYTE cColorBits; BYTE cRedBits; BYTE
	// cRedShift; BYTE cGreenBits; BYTE cGreenShift; BYTE cBlueBits; BYTE cBlueShift; BYTE cAlphaBits; BYTE cAlphaShift; BYTE cAccumBits;
	// BYTE cAccumRedBits; BYTE cAccumGreenBits; BYTE cAccumBlueBits; BYTE cAccumAlphaBits; BYTE cDepthBits; BYTE cStencilBits; BYTE
	// cAuxBuffers; BYTE iLayerType; BYTE bReserved; DWORD dwLayerMask; DWORD dwVisibleMask; DWORD dwDamageMask; } PIXELFORMATDESCRIPTOR,
	// *PPIXELFORMATDESCRIPTOR, *LPPIXELFORMATDESCRIPTOR;
	[PInvokeData("wingdi.h", MSDNShortId = "1480dea3-ae74-4e8b-b4de-fca8de5d8395")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PIXELFORMATDESCRIPTOR
	{
		/// <summary>Specifies the size of this data structure. This value should be set to <c>sizeof</c>( <c>PIXELFORMATDESCRIPTOR</c>).</summary>
		public ushort nSize;

		/// <summary>Specifies the version of this data structure. This value should be set to 1.</summary>
		public ushort nVersion;

		/// <summary>
		/// <para>
		/// A set of bit flags that specify properties of the pixel buffer. The properties are generally not mutually exclusive; you can
		/// set any combination of bit flags, with the exceptions noted. The following bit flag constants are defined.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PFD_DRAW_TO_WINDOW</term>
		/// <term>The buffer can draw to a window or device surface.</term>
		/// </item>
		/// <item>
		/// <term>PFD_DRAW_TO_BITMAP</term>
		/// <term>The buffer can draw to a memory bitmap.</term>
		/// </item>
		/// <item>
		/// <term>PFD_SUPPORT_GDI</term>
		/// <term>The buffer supports GDI drawing. This flag and PFD_DOUBLEBUFFER are mutually exclusive in the current generic implementation.</term>
		/// </item>
		/// <item>
		/// <term>PFD_SUPPORT_OPENGL</term>
		/// <term>The buffer supports OpenGL drawing.</term>
		/// </item>
		/// <item>
		/// <term>PFD_GENERIC_ACCELERATED</term>
		/// <term>
		/// The pixel format is supported by a device driver that accelerates the generic implementation. If this flag is clear and the
		/// PFD_GENERIC_FORMAT flag is set, the pixel format is supported by the generic implementation only.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PFD_GENERIC_FORMAT</term>
		/// <term>
		/// The pixel format is supported by the GDI software implementation, which is also known as the generic implementation. If this
		/// bit is clear, the pixel format is supported by a device driver or hardware.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PFD_NEED_PALETTE</term>
		/// <term>
		/// The buffer uses RGBA pixels on a palette-managed device. A logical palette is required to achieve the best results for this
		/// pixel type. Colors in the palette should be specified according to the values of the cRedBits, cRedShift, cGreenBits,
		/// cGreenShift, cBluebits, and cBlueShift members. The palette should be created and realized in the device context before
		/// calling wglMakeCurrent.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PFD_NEED_SYSTEM_PALETTE</term>
		/// <term>
		/// Defined in the pixel format descriptors of hardware that supports one hardware palette in 256-color mode only. For such
		/// systems to use hardware acceleration, the hardware palette must be in a fixed order (for example, 3-3-2) when in RGBA mode or
		/// must match the logical palette when in color-index mode.When this flag is set, you must call SetSystemPaletteUse in your
		/// program to force a one-to-one mapping of the logical palette and the system palette. If your OpenGL hardware supports
		/// multiple hardware palettes and the device driver can allocate spare hardware palettes for OpenGL, this flag is typically
		/// clear. This flag is not set in the generic pixel formats.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PFD_DOUBLEBUFFER</term>
		/// <term>The buffer is double-buffered. This flag and PFD_SUPPORT_GDI are mutually exclusive in the current generic implementation.</term>
		/// </item>
		/// <item>
		/// <term>PFD_STEREO</term>
		/// <term>The buffer is stereoscopic. This flag is not supported in the current generic implementation.</term>
		/// </item>
		/// <item>
		/// <term>PFD_SWAP_LAYER_BUFFERS</term>
		/// <term>
		/// Indicates whether a device can swap individual layer planes with pixel formats that include double-buffered overlay or
		/// underlay planes. Otherwise all layer planes are swapped together as a group. When this flag is set, wglSwapLayerBuffers is supported.
		/// </term>
		/// </item>
		/// </list>
		/// <para>You can specify the following bit flags when calling ChoosePixelFormat.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PFD_DEPTH_DONTCARE</term>
		/// <term>
		/// The requested pixel format can either have or not have a depth buffer. To select a pixel format without a depth buffer, you
		/// must specify this flag. The requested pixel format can be with or without a depth buffer. Otherwise, only pixel formats with
		/// a depth buffer are considered.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PFD_DOUBLEBUFFER_DONTCARE</term>
		/// <term>The requested pixel format can be either single- or double-buffered.</term>
		/// </item>
		/// <item>
		/// <term>PFD_STEREO_DONTCARE</term>
		/// <term>The requested pixel format can be either monoscopic or stereoscopic.</term>
		/// </item>
		/// </list>
		/// <para>
		/// With the <c>glAddSwapHintRectWIN</c> extension function, two new flags are included for the <c>PIXELFORMATDESCRIPTOR</c>
		/// pixel format structure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PFD_SWAP_COPY</term>
		/// <term>
		/// Specifies the content of the back buffer in the double-buffered main color plane following a buffer swap. Swapping the color
		/// buffers causes the content of the back buffer to be copied to the front buffer. The content of the back buffer is not
		/// affected by the swap. PFD_SWAP_COPY is a hint only and might not be provided by a driver.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PFD_SWAP_EXCHANGE</term>
		/// <term>
		/// Specifies the content of the back buffer in the double-buffered main color plane following a buffer swap. Swapping the color
		/// buffers causes the exchange of the back buffer's content with the front buffer's content. Following the swap, the back
		/// buffer's content contains the front buffer's content before the swap. PFD_SWAP_EXCHANGE is a hint only and might not be
		/// provided by a driver.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PFD_FLAGS dwFlags;

		/// <summary>
		/// <para>Specifies the type of pixel data. The following types are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PFD_TYPE_RGBA</term>
		/// <term>RGBA pixels. Each pixel has four components in this order: red, green, blue, and alpha.</term>
		/// </item>
		/// <item>
		/// <term>PFD_TYPE_COLORINDEX</term>
		/// <term>Color-index pixels. Each pixel uses a color-index value.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PFD_TYPE iPixelType;

		/// <summary>
		/// Specifies the number of color bitplanes in each color buffer. For RGBA pixel types, it is the size of the color buffer,
		/// excluding the alpha bitplanes. For color-index pixels, it is the size of the color-index buffer.
		/// </summary>
		public byte cColorBits;

		/// <summary>Specifies the number of red bitplanes in each RGBA color buffer.</summary>
		public byte cRedBits;

		/// <summary>Specifies the shift count for red bitplanes in each RGBA color buffer.</summary>
		public byte cRedShift;

		/// <summary>Specifies the number of green bitplanes in each RGBA color buffer.</summary>
		public byte cGreenBits;

		/// <summary>Specifies the shift count for green bitplanes in each RGBA color buffer.</summary>
		public byte cGreenShift;

		/// <summary>Specifies the number of blue bitplanes in each RGBA color buffer.</summary>
		public byte cBlueBits;

		/// <summary>Specifies the shift count for blue bitplanes in each RGBA color buffer.</summary>
		public byte cBlueShift;

		/// <summary>Specifies the number of alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.</summary>
		public byte cAlphaBits;

		/// <summary>Specifies the shift count for alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.</summary>
		public byte cAlphaShift;

		/// <summary>Specifies the total number of bitplanes in the accumulation buffer.</summary>
		public byte cAccumBits;

		/// <summary>Specifies the number of red bitplanes in the accumulation buffer.</summary>
		public byte cAccumRedBits;

		/// <summary>Specifies the number of green bitplanes in the accumulation buffer.</summary>
		public byte cAccumGreenBits;

		/// <summary>Specifies the number of blue bitplanes in the accumulation buffer.</summary>
		public byte cAccumBlueBits;

		/// <summary>Specifies the number of alpha bitplanes in the accumulation buffer.</summary>
		public byte cAccumAlphaBits;

		/// <summary>Specifies the depth of the depth (z-axis) buffer.</summary>
		public byte cDepthBits;

		/// <summary>Specifies the depth of the stencil buffer.</summary>
		public byte cStencilBits;

		/// <summary>Specifies the number of auxiliary buffers. Auxiliary buffers are not supported.</summary>
		public byte cAuxBuffers;

		/// <summary>Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.</summary>
		public byte iLayerType;

		/// <summary>
		/// Specifies the number of overlay and underlay planes. Bits 0 through 3 specify up to 15 overlay planes and bits 4 through 7
		/// specify up to 15 underlay planes.
		/// </summary>
		public byte bReserved;

		/// <summary>Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.</summary>
		public PFD_LAYER dwLayerMask;

		/// <summary>
		/// Specifies the transparent color or index of an underlay plane. When the pixel type is RGBA, <c>dwVisibleMask</c> is a
		/// transparent RGB color value. When the pixel type is color index, it is a transparent index value.
		/// </summary>
		public uint dwVisibleMask;

		/// <summary>Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.</summary>
		public uint dwDamageMask;
	}
}