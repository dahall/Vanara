using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>Default application icon.</summary>
		public static readonly ResourceId IDI_APPLICATION = Macros.MAKEINTRESOURCE(32512);

		/// <summary>Hand-shaped icon. Same as IDI_ERROR.</summary>
		public static readonly ResourceId IDI_HAND        = Macros.MAKEINTRESOURCE(32513);

		/// <summary>Question mark icon.</summary>
		public static readonly ResourceId IDI_QUESTION    = Macros.MAKEINTRESOURCE(32514);

		/// <summary>Exclamation point icon. Same as IDI_WARNING.</summary>
		public static readonly ResourceId IDI_EXCLAMATION = Macros.MAKEINTRESOURCE(32515);

		/// <summary>Asterisk icon. Same as IDI_INFORMATION.</summary>
		public static readonly ResourceId IDI_ASTERISK    = Macros.MAKEINTRESOURCE(32516);

		/// <summary>Default application icon. Windows 2000: Windows logo icon.</summary>
		public static readonly ResourceId IDI_WINLOGO     = Macros.MAKEINTRESOURCE(32517);

		/// <summary>Security Shield icon.</summary>
		public static readonly ResourceId IDI_SHIELD      = Macros.MAKEINTRESOURCE(32518);

		/// <summary>Exclamation point icon.</summary>
		public static readonly ResourceId IDI_WARNING = IDI_EXCLAMATION;

		/// <summary>Hand-shaped icon.</summary>
		public static readonly ResourceId IDI_ERROR = IDI_HAND;

		/// <summary>Asterisk icon.</summary>
		public static readonly ResourceId IDI_INFORMATION = IDI_ASTERISK;

		/// <summary>Flags used by <see cref="DrawIconEx"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "drawiconex")]
		[Flags]
		public enum DrawIconExFlags
		{
			/// <summary>Draws the icon or cursor using the mask.</summary>
			DI_MASK = 0x0001,

			/// <summary>Draws the icon or cursor using the image.</summary>
			DI_IMAGE = 0x0002,

			/// <summary>Combination of DI_IMAGE and DI_MASK.</summary>
			DI_NORMAL = 0x0003,

			/// <summary>This flag is ignored.</summary>
			DI_COMPAT = 0x0004,

			/// <summary>
			/// Draws the icon or cursor using the width and height specified by the system metric values for icons, if the cxWidth and
			/// cyWidth parameters are set to zero. If this flag is not specified and cxWidth and cyWidth are set to zero, the function uses
			/// the actual resource size.
			/// </summary>
			DI_DEFAULTSIZE = 0x0008,

			/// <summary>Draws the icon as an unmirrored icon. By default, the icon is drawn as a mirrored icon if hdc is mirrored.</summary>
			DI_NOMIRROR = 0x0010,
		}

		/// <summary>
		/// <para>Copies the specified icon from another module to the current module.</para>
		/// </summary>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>A handle to the icon to be copied.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>If the function succeeds, the return value is a handle to the duplicate icon.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CopyIcon</c> function enables an application or DLL to get its own handle to an icon owned by another module. If the other
		/// module is freed, the application icon will still be able to use the icon.
		/// </para>
		/// <para>Before closing, an application must call the DestroyIcon function to free any system resources associated with the icon.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-copyicon HICON CopyIcon( HICON hIcon );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "copyicon")]
		public static extern SafeHICON CopyIcon(HICON hIcon);

		/// <summary>
		/// Creates a new cursor and copies the attributes of the specified image to the new one. If necessary, the function stretches the
		/// bits to fit the desired size of the new image.
		/// </summary>
		/// <param name="h">
		/// <para>A handle to the image to be copied.</para>
		/// </param>
		/// <param name="desiredSize">
		/// The desired size, in pixels, of the image. If this is Size.Empty, then the returned image will have the same size as the original hImage.
		/// </param>
		/// <param name="options">
		/// <para>This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LR_COPYDELETEORG 0x00000008</term>
		/// <term>Deletes the original image after creating the copy.</term>
		/// </item>
		/// <item>
		/// <term>LR_COPYFROMRESOURCE 0x00004000</term>
		/// <term>
		/// Tries to reload an icon or cursor resource from the original resource file rather than simply copying the current image. This is
		/// useful for creating a different-sized copy when the resource file contains multiple sizes of the resource. Without this flag,
		/// CopyImage stretches the original image to the new size. If this flag is set, CopyImage uses the size in the resource file closest
		/// to the desired size. This will succeed only if hImage was loaded by LoadIcon or LoadCursor, or by LoadImage with the LR_SHARED flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_COPYRETURNORG 0x00000004</term>
		/// <term>
		/// Returns the original hImage if it satisfies the criteria for the copy—that is, correct dimensions and color depth—in which case
		/// the LR_COPYDELETEORG flag is ignored. If this flag is not specified, a new object is always created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_CREATEDIBSECTION 0x00002000</term>
		/// <term>
		/// If this is set and a new bitmap is created, the bitmap is created as a DIB section. Otherwise, the bitmap image is created as a
		/// device-dependent bitmap. This flag is only valid if uType is IMAGE_BITMAP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_DEFAULTSIZE 0x00000040</term>
		/// <term>
		/// Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are set
		/// to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource size.
		/// If the resource contains multiple images, the function uses the size of the first image.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_MONOCHROME 0x00000001</term>
		/// <term>Creates a new monochrome image.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>The return value is a safe handle to the newly created image.</para>
		/// </returns>
		public static SafeHICON CopyIcon(HICON h, SIZE desiredSize = default, CopyImageOptions options = 0)
		{
			var hret = CopyImage(h.DangerousGetHandle(), LoadImageType.IMAGE_ICON, desiredSize.Width, desiredSize.Height, options);
			if (hret == HANDLE.NULL) Win32Error.ThrowLastError();
			return new SafeHICON(hret.DangerousGetHandle(), true);
		}

		/// <summary>
		/// <para>Creates an icon that has the specified size, colors, and bit patterns.</para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>A handle to the instance of the module creating the icon.</para>
		/// </param>
		/// <param name="nWidth">
		/// <para>Type: <c>int</c></para>
		/// <para>The width, in pixels, of the icon.</para>
		/// </param>
		/// <param name="nHeight">
		/// <para>Type: <c>int</c></para>
		/// <para>The height, in pixels, of the icon.</para>
		/// </param>
		/// <param name="cPlanes">
		/// <para>Type: <c>BYTE</c></para>
		/// <para>The number of planes in the XOR bitmask of the icon.</para>
		/// </param>
		/// <param name="cBitsPixel">
		/// <para>Type: <c>BYTE</c></para>
		/// <para>The number of bits-per-pixel in the XOR bitmask of the icon.</para>
		/// </param>
		/// <param name="lpbANDbits">
		/// <para>Type: <c>const BYTE*</c></para>
		/// <para>An array of bytes that contains the bit values for the AND bitmask of the icon. This bitmask describes a monochrome bitmap.</para>
		/// </param>
		/// <param name="lpbXORbits">
		/// <para>Type: <c>const BYTE*</c></para>
		/// <para>
		/// An array of bytes that contains the bit values for the XOR bitmask of the icon. This bitmask describes a monochrome or
		/// device-dependent color bitmap.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>If the function succeeds, the return value is a handle to an icon.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The nWidth and nHeight parameters must specify a width and height supported by the current display driver, because the system
		/// cannot create icons of other sizes. To determine the width and height supported by the display driver, use the GetSystemMetrics
		/// function, specifying the <c>SM_CXICON</c> or <c>SM_CYICON</c> value.
		/// </para>
		/// <para><c>CreateIcon</c> applies the following truth table to the AND and XOR bitmasks.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>AND bitmask</term>
		/// <term>XOR bitmask</term>
		/// <term>Display</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>0</term>
		/// <term>Black</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>1</term>
		/// <term>White</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>0</term>
		/// <term>Screen</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>1</term>
		/// <term>Reverse screen</term>
		/// </item>
		/// </list>
		/// <para>When you are finished using the icon, destroy it using the DestroyIcon function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating an Icon.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createicon HICON CreateIcon( HINSTANCE hInstance, int
		// nWidth, int nHeight, BYTE cPlanes, BYTE cBitsPixel, CONST BYTE *lpbANDbits, CONST BYTE *lpbXORbits );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "createicon")]
		public static extern SafeHICON CreateIcon(HINSTANCE hInstance, int nWidth, int nHeight, byte cPlanes, byte cBitsPixel, [In] byte[] lpbANDbits, [In] byte[] lpbXORbits);

		/// <summary>
		/// <para>Creates an icon or cursor from resource bits describing the icon.</para>
		/// <para>To specify a desired height or width, use the CreateIconFromResourceEx function.</para>
		/// </summary>
		/// <param name="presbits">
		/// <para>Type: <c>PBYTE</c></para>
		/// <para>
		/// The buffer containing the icon or cursor resource bits. These bits are typically loaded by calls to the
		/// LookupIconIdFromDirectory, LookupIconIdFromDirectoryEx, and LoadResource functions.
		/// </para>
		/// </param>
		/// <param name="dwResSize">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the set of bits pointed to by the presbits parameter.</para>
		/// </param>
		/// <param name="fIcon">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether an icon or a cursor is to be created. If this parameter is <c>TRUE</c>, an icon is to be created. If it is
		/// <c>FALSE</c>, a cursor is to be created.
		/// </para>
		/// </param>
		/// <param name="dwVer">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The version number of the icon or cursor format for the resource bits pointed to by the presbits parameter. The value must be
		/// greater than or equal to 0x00020000 and less than or equal to 0x00030000. This parameter is generally set to 0x00030000.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>If the function succeeds, the return value is a handle to the icon or cursor.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CreateIconFromResource</c>, CreateIconFromResourceEx, CreateIconIndirect, GetIconInfo, LookupIconIdFromDirectory, and
		/// LookupIconIdFromDirectoryEx functions allow shell applications and icon browsers to examine and use resources throughout the system.
		/// </para>
		/// <para>The <c>CreateIconFromResource</c> function calls CreateIconFromResourceEx passing as flags.</para>
		/// <para>When you are finished using the icon, destroy it using the DestroyIcon function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createiconfromresource HICON CreateIconFromResource( PBYTE
		// presbits, DWORD dwResSize, BOOL fIcon, DWORD dwVer );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "createiconfromresource")]
		public static extern SafeHICON CreateIconFromResource([In] byte[] presbits, uint dwResSize, [MarshalAs(UnmanagedType.Bool)] bool fIcon, uint dwVer);

		/// <summary>
		/// <para>Creates an icon or cursor from resource bits describing the icon.</para>
		/// </summary>
		/// <param name="presbits">
		/// <para>Type: <c>PBYTE</c></para>
		/// <para>
		/// The icon or cursor resource bits. These bits are typically loaded by calls to the LookupIconIdFromDirectoryEx and LoadResource functions.
		/// </para>
		/// </param>
		/// <param name="dwResSize">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the set of bits pointed to by the pbIconBits parameter.</para>
		/// </param>
		/// <param name="fIcon">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether an icon or a cursor is to be created. If this parameter is <c>TRUE</c>, an icon is to be created. If it is
		/// <c>FALSE</c>, a cursor is to be created.
		/// </para>
		/// </param>
		/// <param name="dwVer">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The version number of the icon or cursor format for the resource bits pointed to by the pbIconBits parameter. The value must be
		/// greater than or equal to 0x00020000 and less than or equal to 0x00030000. This parameter is generally set to 0x00030000.
		/// </para>
		/// </param>
		/// <param name="cxDesired">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The desired width, in pixels, of the icon or cursor. If this parameter is zero, the function uses the <c>SM_CXICON</c> or
		/// <c>SM_CXCURSOR</c> system metric value to set the width.
		/// </para>
		/// </param>
		/// <param name="cyDesired">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The desired height, in pixels, of the icon or cursor. If this parameter is zero, the function uses the <c>SM_CYICON</c> or
		/// <c>SM_CYCURSOR</c> system metric value to set the height.
		/// </para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LR_DEFAULTCOLOR 0x00000000</term>
		/// <term>Uses the default color format.</term>
		/// </item>
		/// <item>
		/// <term>LR_DEFAULTSIZE 0x00000040</term>
		/// <term>
		/// Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are set
		/// to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource size.
		/// If the resource contains multiple images, the function uses the size of the first image.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_MONOCHROME 0x00000001</term>
		/// <term>Creates a monochrome icon or cursor.</term>
		/// </item>
		/// <item>
		/// <term>LR_SHARED 0x00008000</term>
		/// <term>
		/// Shares the icon or cursor handle if the icon or cursor is created multiple times. If LR_SHARED is not set, a second call to
		/// CreateIconFromResourceEx for the same resource will create the icon or cursor again and return a different handle. When you use
		/// this flag, the system will destroy the resource when it is no longer needed. Do not use LR_SHARED for icons or cursors that have
		/// non-standard sizes, that may change after loading, or that are loaded from a file. When loading a system icon or cursor, you must
		/// use LR_SHARED or the function will fail to load the resource.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>If the function succeeds, the return value is a handle to the icon or cursor.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The CreateIconFromResource, <c>CreateIconFromResourceEx</c>, CreateIconIndirect, GetIconInfo, and LookupIconIdFromDirectoryEx
		/// functions allow shell applications and icon browsers to examine and use resources throughout the system.
		/// </para>
		/// <para>You should call DestroyIcon for icons created with <c>CreateIconFromResourceEx</c>.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Sharing Icon Resources.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createiconfromresourceex HICON CreateIconFromResourceEx(
		// PBYTE presbits, DWORD dwResSize, BOOL fIcon, DWORD dwVer, int cxDesired, int cyDesired, UINT Flags );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "createiconfromresourceex")]
		public static extern SafeHICON CreateIconFromResourceEx([In] byte[] presbits, uint dwResSize, [MarshalAs(UnmanagedType.Bool)] bool fIcon, uint dwVer, int cxDesired, int cyDesired, LoadImageOptions Flags);

		/// <summary>
		/// <para>Creates an icon or cursor from an ICONINFO structure.</para>
		/// </summary>
		/// <param name="piconinfo">
		/// <para>Type: <c>PICONINFO</c></para>
		/// <para>A pointer to an ICONINFO structure the function uses to create the icon or cursor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>If the function succeeds, the return value is a handle to the icon or cursor that is created.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system copies the bitmaps in the ICONINFO structure before creating the icon or cursor. Because the system may temporarily
		/// select the bitmaps in a device context, the <c>hbmMask</c> and <c>hbmColor</c> members of the <c>ICONINFO</c> structure should
		/// not already be selected into a device context. The application must continue to manage the original bitmaps and delete them when
		/// they are no longer necessary.
		/// </para>
		/// <para>When you are finished using the icon, destroy it using the DestroyIcon function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createiconindirect HICON CreateIconIndirect( PICONINFO
		// piconinfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "createiconindirect")]
		public static extern SafeHICON CreateIconIndirect([In] ICONINFO piconinfo);

		/// <summary>
		/// <para>Destroys an icon and frees any memory the icon occupied.</para>
		/// </summary>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>A handle to the icon to be destroyed. The icon must not be in use.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// It is only necessary to call <c>DestroyIcon</c> for icons and cursors created with the following functions:
		/// CreateIconFromResourceEx (if called without the <c>LR_SHARED</c> flag), CreateIconIndirect, and CopyIcon. Do not use this
		/// function to destroy a shared icon. A shared icon is valid as long as the module from which it was loaded remains in memory. The
		/// following functions obtain a shared icon.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>LoadIcon</term>
		/// </item>
		/// <item>
		/// <term>LoadImage (if you use the <c>LR_SHARED</c> flag)</term>
		/// </item>
		/// <item>
		/// <term>CopyImage (if you use the <c>LR_COPYRETURNORG</c> flag and the hImage parameter is a shared icon)</term>
		/// </item>
		/// <item>
		/// <term>CreateIconFromResource</term>
		/// </item>
		/// <item>
		/// <term>CreateIconFromResourceEx (if you use the <c>LR_SHARED</c> flag)</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-destroyicon BOOL DestroyIcon( HICON hIcon );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "destroyicon")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyIcon(HICON hIcon);

		/// <summary>
		/// <para>Draws an icon or cursor into the specified device context.</para>
		/// <para>To specify additional drawing options, use the DrawIconEx function.</para>
		/// </summary>
		/// <param name="hDC">
		/// <para>Type: <c>HDC</c></para>
		/// <para>A handle to the device context into which the icon or cursor will be drawn.</para>
		/// </param>
		/// <param name="X">
		/// <para>Type: <c>int</c></para>
		/// <para>The logical x-coordinate of the upper-left corner of the icon.</para>
		/// </param>
		/// <param name="Y">
		/// <para>Type: <c>int</c></para>
		/// <para>The logical y-coordinate of the upper-left corner of the icon.</para>
		/// </param>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>A handle to the icon to be drawn.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>DrawIcon</c> places the icon's upper-left corner at the location specified by the X and Y parameters. The location is subject
		/// to the current mapping mode of the device context.
		/// </para>
		/// <para>
		/// <c>DrawIcon</c> draws the icon or cursor using the width and height specified by the system metric values for icons; for more
		/// information, see GetSystemMetrics.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Displaying an Icon.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawicon BOOL DrawIcon( HDC hDC, int X, int Y, HICON hIcon );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "drawicon")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DrawIcon(HDC hDC, int X, int Y, HICON hIcon);

		/// <summary>
		/// <para>
		/// Draws an icon or cursor into the specified device context, performing the specified raster operations, and stretching or
		/// compressing the icon or cursor as specified.
		/// </para>
		/// </summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>A handle to the device context into which the icon or cursor will be drawn.</para>
		/// </param>
		/// <param name="xLeft">
		/// <para>Type: <c>int</c></para>
		/// <para>The logical x-coordinate of the upper-left corner of the icon or cursor.</para>
		/// </param>
		/// <param name="yTop">
		/// <para>Type: <c>int</c></para>
		/// <para>The logical y-coordinate of the upper-left corner of the icon or cursor.</para>
		/// </param>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>A handle to the icon or cursor to be drawn. This parameter can identify an animated cursor.</para>
		/// </param>
		/// <param name="cxWidth">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The logical width of the icon or cursor. If this parameter is zero and the diFlags parameter is <c>DI_DEFAULTSIZE</c>, the
		/// function uses the <c>SM_CXICON</c> system metric value to set the width. If this parameter is zero and <c>DI_DEFAULTSIZE</c> is
		/// not used, the function uses the actual resource width.
		/// </para>
		/// </param>
		/// <param name="cyWidth">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The logical height of the icon or cursor. If this parameter is zero and the diFlags parameter is <c>DI_DEFAULTSIZE</c>, the
		/// function uses the <c>SM_CYICON</c> system metric value to set the width. If this parameter is zero and <c>DI_DEFAULTSIZE</c> is
		/// not used, the function uses the actual resource height.
		/// </para>
		/// </param>
		/// <param name="istepIfAniCur">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The index of the frame to draw, if hIcon identifies an animated cursor. This parameter is ignored if hIcon does not identify an
		/// animated cursor.
		/// </para>
		/// </param>
		/// <param name="hbrFlickerFreeDraw">
		/// <para>Type: <c>HBRUSH</c></para>
		/// <para>
		/// A handle to a brush that the system uses for flicker-free drawing. If hbrFlickerFreeDraw is a valid brush handle, the system
		/// creates an offscreen bitmap using the specified brush for the background color, draws the icon or cursor into the bitmap, and
		/// then copies the bitmap into the device context identified by hdc. If hbrFlickerFreeDraw is <c>NULL</c>, the system draws the icon
		/// or cursor directly into the device context.
		/// </para>
		/// </param>
		/// <param name="diFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The drawing flags. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DI_COMPAT 0x0004</term>
		/// <term>This flag is ignored.</term>
		/// </item>
		/// <item>
		/// <term>DI_DEFAULTSIZE 0x0008</term>
		/// <term>
		/// Draws the icon or cursor using the width and height specified by the system metric values for icons, if the cxWidth and cyWidth
		/// parameters are set to zero. If this flag is not specified and cxWidth and cyWidth are set to zero, the function uses the actual
		/// resource size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DI_IMAGE 0x0002</term>
		/// <term>Draws the icon or cursor using the image.</term>
		/// </item>
		/// <item>
		/// <term>DI_MASK 0x0001</term>
		/// <term>Draws the icon or cursor using the mask.</term>
		/// </item>
		/// <item>
		/// <term>DI_NOMIRROR 0x0010</term>
		/// <term>Draws the icon as an unmirrored icon. By default, the icon is drawn as a mirrored icon if hdc is mirrored.</term>
		/// </item>
		/// <item>
		/// <term>DI_NORMAL 0x0003</term>
		/// <term>Combination of DI_IMAGE and DI_MASK.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>DrawIconEx</c> function places the icon's upper-left corner at the location specified by the xLeft and yTop parameters.
		/// The location is subject to the current mapping mode of the device context.
		/// </para>
		/// <para>To duplicate , call <c>DrawIconEx</c> as follows:</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawiconex BOOL DrawIconEx( HDC hdc, int xLeft, int yTop,
		// HICON hIcon, int cxWidth, int cyWidth, UINT istepIfAniCur, HBRUSH hbrFlickerFreeDraw, UINT diFlags );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "drawiconex")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DrawIconEx(HDC hdc, int xLeft, int yTop, HICON hIcon, int cxWidth, int cyWidth, uint istepIfAniCur, HBRUSH hbrFlickerFreeDraw, DrawIconExFlags diFlags);

		/// <summary>
		/// <para>Retrieves information about the specified icon or cursor.</para>
		/// </summary>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// A handle to the icon or cursor. To retrieve information about a standard icon or cursor, specify one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IDC_APPSTARTING MAKEINTRESOURCE(32650)</term>
		/// <term>Standard arrow and small hourglass cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_ARROW MAKEINTRESOURCE(32512)</term>
		/// <term>Standard arrow cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_CROSS MAKEINTRESOURCE(32515)</term>
		/// <term>Crosshair cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_HAND MAKEINTRESOURCE(32649)</term>
		/// <term>Hand cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_HELP MAKEINTRESOURCE(32651)</term>
		/// <term>Arrow and question mark cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_IBEAM MAKEINTRESOURCE(32513)</term>
		/// <term>I-beam cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_NO MAKEINTRESOURCE(32648)</term>
		/// <term>Slashed circle cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZEALL MAKEINTRESOURCE(32646)</term>
		/// <term>Four-pointed arrow cursor pointing north, south, east, and west.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENESW MAKEINTRESOURCE(32643)</term>
		/// <term>Double-pointed arrow cursor pointing northeast and southwest.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENS MAKEINTRESOURCE(32645)</term>
		/// <term>Double-pointed arrow cursor pointing north and south.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENWSE MAKEINTRESOURCE(32642)</term>
		/// <term>Double-pointed arrow cursor pointing northwest and southeast.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZEWE MAKEINTRESOURCE(32644)</term>
		/// <term>Double-pointed arrow cursor pointing west and east.</term>
		/// </item>
		/// <item>
		/// <term>IDC_UPARROW MAKEINTRESOURCE(32516)</term>
		/// <term>Vertical arrow cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_WAIT MAKEINTRESOURCE(32514)</term>
		/// <term>Hourglass cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDI_APPLICATION MAKEINTRESOURCE(32512)</term>
		/// <term>Application icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_ASTERISK MAKEINTRESOURCE(32516)</term>
		/// <term>Asterisk icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_EXCLAMATION MAKEINTRESOURCE(32515)</term>
		/// <term>Exclamation point icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_HAND MAKEINTRESOURCE(32513)</term>
		/// <term>Stop sign icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_QUESTION MAKEINTRESOURCE(32514)</term>
		/// <term>Question-mark icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_WINLOGO MAKEINTRESOURCE(32517)</term>
		/// <term>Application icon. Windows 2000: Windows logo icon.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="piconinfo">
		/// <para>Type: <c>PICONINFO</c></para>
		/// <para>A pointer to an ICONINFO structure. The function fills in the structure's members.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If the function succeeds, the return value is nonzero and the function fills in the members of the specified ICONINFO structure.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetIconInfo</c> creates bitmaps for the <c>hbmMask</c> and <c>hbmCol</c> or members of ICONINFO. The calling application must
		/// manage these bitmaps and delete them when they are no longer necessary.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>This API does not participate in DPI virtualization. The output returned is not affected by the DPI of the calling thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-geticoninfo BOOL GetIconInfo( HICON hIcon, PICONINFO
		// piconinfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "geticoninfo")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetIconInfo(HICON hIcon, [In, Out] ICONINFO piconinfo);

		/// <summary>
		/// <para>
		/// Retrieves information about the specified icon or cursor. <c>GetIconInfoEx</c> extends GetIconInfo by using the newer ICONINFOEX structure.
		/// </para>
		/// </summary>
		/// <param name="hicon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// A handle to the icon or cursor. To retrieve information about a standard icon or cursor, specify one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IDC_APPSTARTING MAKEINTRESOURCE(32650)</term>
		/// <term>Standard arrow and small hourglass cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_ARROW MAKEINTRESOURCE(32512)</term>
		/// <term>Standard arrow cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_CROSS MAKEINTRESOURCE(32515)</term>
		/// <term>Crosshair cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_HAND MAKEINTRESOURCE(32649)</term>
		/// <term>Hand cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_HELP MAKEINTRESOURCE(32651)</term>
		/// <term>Arrow and question mark cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_IBEAM MAKEINTRESOURCE(32513)</term>
		/// <term>I-beam cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_NO MAKEINTRESOURCE(32648)</term>
		/// <term>Slashed circle cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZEALL MAKEINTRESOURCE(32646)</term>
		/// <term>Four-pointed arrow cursor pointing north, south, east, and west.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENESW MAKEINTRESOURCE(32643)</term>
		/// <term>Double-pointed arrow cursor pointing northeast and southwest.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENS MAKEINTRESOURCE(32645)</term>
		/// <term>Double-pointed arrow cursor pointing north and south.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENWSE MAKEINTRESOURCE(32642)</term>
		/// <term>Double-pointed arrow cursor pointing northwest and southeast.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZEWE MAKEINTRESOURCE(32644)</term>
		/// <term>Double-pointed arrow cursor pointing west and east.</term>
		/// </item>
		/// <item>
		/// <term>IDC_UPARROW MAKEINTRESOURCE(32516)</term>
		/// <term>Vertical arrow cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDC_WAIT MAKEINTRESOURCE(32514)</term>
		/// <term>Hourglass cursor.</term>
		/// </item>
		/// <item>
		/// <term>IDI_APPLICATION MAKEINTRESOURCE(32512)</term>
		/// <term>Application icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_ASTERISK MAKEINTRESOURCE(32516)</term>
		/// <term>Asterisk icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_EXCLAMATION MAKEINTRESOURCE(32515)</term>
		/// <term>Exclamation point icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_HAND MAKEINTRESOURCE(32513)</term>
		/// <term>Stop sign icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_QUESTION MAKEINTRESOURCE(32514)</term>
		/// <term>Question-mark icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_WINLOGO MAKEINTRESOURCE(32517)</term>
		/// <term>Application icon. Windows 2000: Windows logo icon.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="piconinfo">
		/// <para>Type: <c>PICONINFOEX</c></para>
		/// <para>When this method returns, contains a pointer to an ICONINFOEX structure. The function fills in the structure's members.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> indicates success, <c>FALSE</c> indicates failure.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetIconInfoEx</c> creates bitmaps for the <c>hbmMask</c> and <c>hbmCol</c> or members of ICONINFOEX. The calling application
		/// must manage these bitmaps and delete them when they are no longer necessary.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>This API does not participate in DPI virtualization. The output returned is not affected by the DPI of the calling thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-geticoninfoexa BOOL GetIconInfoExA( HICON hicon,
		// PICONINFOEXA piconinfo );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "geticoninfoex")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetIconInfoEx(HICON hicon, ref ICONINFOEX piconinfo);

		/// <summary>Gets the size of an icon from its handle.</summary>
		/// <param name="hIcon">The icon handle.</param>
		/// <returns>The size of the icon in pixels.</returns>
		public static SIZE GetSize(this HICON hIcon)
		{
			using ICONINFO info = new();
			Win32Error.ThrowLastErrorIfFalse(GetIconInfo(hIcon, info));
			if (!info.hbmColor.IsNull)
			{
				var bmp = GetObject<BITMAP>(info.hbmColor);
				return new(bmp.bmWidth, bmp.bmHeight);
			}
			if (!info.hbmMask.IsNull)
			{
				var bmp = GetObject<BITMAP>(info.hbmMask);
				return new(bmp.bmWidth, bmp.bmHeight / 2);
			}
			return SIZE.Empty;
		}

		/// <summary>
		/// <para>Loads the specified icon resource from the executable (.exe) file associated with an application instance.</para>
		/// <para><c>Note</c> This function has been superseded by the LoadImage function.</para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// A handle to an instance of the module whose executable file contains the icon to be loaded. This parameter must be <c>NULL</c>
		/// when a standard icon is being loaded.
		/// </para>
		/// </param>
		/// <param name="lpIconName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the icon resource to be loaded. Alternatively, this parameter can contain the resource identifier in the low-order
		/// word and zero in the high-order word. Use the MAKEINTRESOURCE macro to create this value.
		/// </para>
		/// <para>
		/// To use one of the predefined icons, set the hInstance parameter to <c>NULL</c> and the lpIconName parameter to one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IDI_APPLICATION MAKEINTRESOURCE(32512)</term>
		/// <term>Default application icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_ASTERISK MAKEINTRESOURCE(32516)</term>
		/// <term>Asterisk icon. Same as IDI_INFORMATION.</term>
		/// </item>
		/// <item>
		/// <term>IDI_ERROR MAKEINTRESOURCE(32513)</term>
		/// <term>Hand-shaped icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_EXCLAMATION MAKEINTRESOURCE(32515)</term>
		/// <term>Exclamation point icon. Same as IDI_WARNING.</term>
		/// </item>
		/// <item>
		/// <term>IDI_HAND MAKEINTRESOURCE(32513)</term>
		/// <term>Hand-shaped icon. Same as IDI_ERROR.</term>
		/// </item>
		/// <item>
		/// <term>IDI_INFORMATION MAKEINTRESOURCE(32516)</term>
		/// <term>Asterisk icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_QUESTION MAKEINTRESOURCE(32514)</term>
		/// <term>Question mark icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_SHIELD MAKEINTRESOURCE(32518)</term>
		/// <term>Security Shield icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_WARNING MAKEINTRESOURCE(32515)</term>
		/// <term>Exclamation point icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_WINLOGO MAKEINTRESOURCE(32517)</term>
		/// <term>Default application icon. Windows 2000: Windows logo icon.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>If the function succeeds, the return value is a handle to the newly loaded icon.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>LoadIcon</c> loads the icon resource only if it has not been loaded; otherwise, it retrieves a handle to the existing
		/// resource. The function searches the icon resource for the icon most appropriate for the current display. The icon resource can be
		/// a color or monochrome bitmap.
		/// </para>
		/// <para>
		/// <c>LoadIcon</c> can only load an icon whose size conforms to the <c>SM_CXICON</c> and <c>SM_CYICON</c> system metric values. Use
		/// the LoadImage function to load icons of other sizes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadicona HICON LoadIconA( HINSTANCE hInstance, LPCSTR
		// lpIconName );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "loadicon")]
		public static extern SafeHICON LoadIcon(HINSTANCE hInstance, string lpIconName);

		/// <summary>
		/// <para>Loads the specified icon resource from the executable (.exe) file associated with an application instance.</para>
		/// <para><c>Note</c> This function has been superseded by the LoadImage function.</para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// A handle to an instance of the module whose executable file contains the icon to be loaded. This parameter must be <c>NULL</c>
		/// when a standard icon is being loaded.
		/// </para>
		/// </param>
		/// <param name="lpIconName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the icon resource to be loaded. Alternatively, this parameter can contain the resource identifier in the low-order
		/// word and zero in the high-order word. Use the MAKEINTRESOURCE macro to create this value.
		/// </para>
		/// <para>
		/// To use one of the predefined icons, set the hInstance parameter to <c>NULL</c> and the lpIconName parameter to one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IDI_APPLICATION MAKEINTRESOURCE(32512)</term>
		/// <term>Default application icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_ASTERISK MAKEINTRESOURCE(32516)</term>
		/// <term>Asterisk icon. Same as IDI_INFORMATION.</term>
		/// </item>
		/// <item>
		/// <term>IDI_ERROR MAKEINTRESOURCE(32513)</term>
		/// <term>Hand-shaped icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_EXCLAMATION MAKEINTRESOURCE(32515)</term>
		/// <term>Exclamation point icon. Same as IDI_WARNING.</term>
		/// </item>
		/// <item>
		/// <term>IDI_HAND MAKEINTRESOURCE(32513)</term>
		/// <term>Hand-shaped icon. Same as IDI_ERROR.</term>
		/// </item>
		/// <item>
		/// <term>IDI_INFORMATION MAKEINTRESOURCE(32516)</term>
		/// <term>Asterisk icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_QUESTION MAKEINTRESOURCE(32514)</term>
		/// <term>Question mark icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_SHIELD MAKEINTRESOURCE(32518)</term>
		/// <term>Security Shield icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_WARNING MAKEINTRESOURCE(32515)</term>
		/// <term>Exclamation point icon.</term>
		/// </item>
		/// <item>
		/// <term>IDI_WINLOGO MAKEINTRESOURCE(32517)</term>
		/// <term>Default application icon. Windows 2000: Windows logo icon.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>If the function succeeds, the return value is a handle to the newly loaded icon.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>LoadIcon</c> loads the icon resource only if it has not been loaded; otherwise, it retrieves a handle to the existing
		/// resource. The function searches the icon resource for the icon most appropriate for the current display. The icon resource can be
		/// a color or monochrome bitmap.
		/// </para>
		/// <para>
		/// <c>LoadIcon</c> can only load an icon whose size conforms to the <c>SM_CXICON</c> and <c>SM_CYICON</c> system metric values. Use
		/// the LoadImage function to load icons of other sizes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadicona HICON LoadIconA( HINSTANCE hInstance, LPCSTR
		// lpIconName );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "loadicon")]
		public static extern SafeHICON LoadIcon(HINSTANCE hInstance, ResourceId lpIconName);

		/// <summary>
		/// <para>Searches through icon or cursor data for the icon or cursor that best fits the current display device.</para>
		/// <para>To specify a desired height or width, use the LookupIconIdFromDirectoryEx function.</para>
		/// </summary>
		/// <param name="presbits">
		/// <para>Type: <c>PBYTE</c></para>
		/// <para>
		/// The icon or cursor directory data. Because this function does not validate the resource data, it causes a general protection (GP)
		/// fault or returns an undefined value if presbits is not pointing to valid resource data.
		/// </para>
		/// </param>
		/// <param name="fIcon">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether an icon or a cursor is sought. If this parameter is <c>TRUE</c>, the function is searching for an icon; if the
		/// parameter is <c>FALSE</c>, the function is searching for a cursor.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// If the function succeeds, the return value is an integer resource identifier for the icon or cursor that best fits the current
		/// display device.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A resource file of type <c>RT_GROUP_ICON</c> ( <c>RT_GROUP_CURSOR</c> indicates cursors) contains icon (or cursor) data in
		/// several device-dependent and device-independent formats. <c>LookupIconIdFromDirectory</c> searches the resource file for the icon
		/// (or cursor) that best fits the current display device and returns its integer identifier. The FindResource and FindResourceEx
		/// functions use the MAKEINTRESOURCE macro with this identifier to locate the resource in the module.
		/// </para>
		/// <para>
		/// The icon directory is loaded from a resource file with resource type <c>RT_GROUP_ICON</c> (or <c>RT_GROUP_CURSOR</c> for
		/// cursors), and an integer resource name for the specific icon to be loaded. <c>LookupIconIdFromDirectory</c> returns an integer
		/// identifier that is the resource name of the icon that best fits the current display device.
		/// </para>
		/// <para>
		/// The LoadIcon, LoadCursor, and LoadImage functions use this function to search the specified resource data for the icon or cursor
		/// that best fits the current display device.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-lookupiconidfromdirectory int LookupIconIdFromDirectory(
		// PBYTE presbits, BOOL fIcon );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "lookupiconidfromdirectory")]
		public static extern int LookupIconIdFromDirectory([In] byte[] presbits, [MarshalAs(UnmanagedType.Bool)] bool fIcon);

		/// <summary>
		/// <para>Searches through icon or cursor data for the icon or cursor that best fits the current display device.</para>
		/// </summary>
		/// <param name="presbits">
		/// <para>Type: <c>PBYTE</c></para>
		/// <para>
		/// The icon or cursor directory data. Because this function does not validate the resource data, it causes a general protection (GP)
		/// fault or returns an undefined value if presbits is not pointing to valid resource data.
		/// </para>
		/// </param>
		/// <param name="fIcon">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether an icon or a cursor is sought. If this parameter is <c>TRUE</c>, the function is searching for an icon; if the
		/// parameter is <c>FALSE</c>, the function is searching for a cursor.
		/// </para>
		/// </param>
		/// <param name="cxDesired">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The desired width, in pixels, of the icon. If this parameter is zero, the function uses the <c>SM_CXICON</c> or
		/// <c>SM_CXCURSOR</c> system metric value.
		/// </para>
		/// </param>
		/// <param name="cyDesired">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The desired height, in pixels, of the icon. If this parameter is zero, the function uses the <c>SM_CYICON</c> or
		/// <c>SM_CYCURSOR</c> system metric value.
		/// </para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LR_DEFAULTCOLOR 0x00000000</term>
		/// <term>Uses the default color format.</term>
		/// </item>
		/// <item>
		/// <term>LR_MONOCHROME 0x00000001</term>
		/// <term>Creates a monochrome icon or cursor.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// If the function succeeds, the return value is an integer resource identifier for the icon or cursor that best fits the current
		/// display device.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A resource file of type <c>RT_GROUP_ICON</c> ( <c>RT_GROUP_CURSOR</c> indicates cursors) contains icon (or cursor) data in
		/// several device-dependent and device-independent formats. <c>LookupIconIdFromDirectoryEx</c> searches the resource file for the
		/// icon (or cursor) that best fits the current display device and returns its integer identifier. The FindResource and
		/// FindResourceEx functions use the MAKEINTRESOURCE macro with this identifier to locate the resource in the module.
		/// </para>
		/// <para>
		/// The icon directory is loaded from a resource file with resource type <c>RT_GROUP_ICON</c> (or <c>RT_GROUP_CURSOR</c> for
		/// cursors), and an integer resource name for the specific icon to be loaded. <c>LookupIconIdFromDirectoryEx</c> returns an integer
		/// identifier that is the resource name of the icon that best fits the current display device.
		/// </para>
		/// <para>
		/// The LoadIcon, LoadImage, and LoadCursor functions use this function to search the specified resource data for the icon or cursor
		/// that best fits the current display device.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Sharing Icon Resources.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-lookupiconidfromdirectoryex int
		// LookupIconIdFromDirectoryEx( PBYTE presbits, BOOL fIcon, int cxDesired, int cyDesired, UINT Flags );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "lookupiconidfromdirectoryex")]
		public static extern int LookupIconIdFromDirectoryEx([In] byte[] presbits, [MarshalAs(UnmanagedType.Bool)] bool fIcon, int cxDesired, int cyDesired, LoadImageOptions Flags);

		/// <summary>
		/// <para>[This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.]</para>
		/// <para>Creates an array of handles to icons that are extracted from a specified file.</para>
		/// </summary>
		/// <param name="szFileName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The path and name of the file from which the icon(s) are to be extracted.</para>
		/// </param>
		/// <param name="nIconIndex">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The zero-based index of the first icon to extract. For example, if this value is zero, the function extracts the first icon in
		/// the specified file.
		/// </para>
		/// </param>
		/// <param name="cxIcon">
		/// <para>Type: <c>int</c></para>
		/// <para>The horizontal icon size wanted. See Remarks.</para>
		/// </param>
		/// <param name="cyIcon">
		/// <para>Type: <c>int</c></para>
		/// <para>The vertical icon size wanted. See Remarks.</para>
		/// </param>
		/// <param name="phicon">
		/// <para>Type: <c>HICON*</c></para>
		/// <para>A pointer to the returned array of icon handles.</para>
		/// </param>
		/// <param name="piconid">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer to a returned resource identifier for the icon that best fits the current display device. The returned identifier is
		/// 0xFFFFFFFF if the identifier is not available for this format. The returned identifier is 0 if the identifier cannot otherwise be obtained.
		/// </para>
		/// </param>
		/// <param name="nIcons">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of icons to extract from the file. This parameter is only valid when extracting from .exe and .dll files.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Specifies flags that control this function. These flags are the LR_* flags used by the LoadImage function.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If the phiconparameter is <c>NULL</c> and this function succeeds, then the return value is the number of icons in the file. If
		/// the function fails then the return value is 0.
		/// </para>
		/// <para>
		/// If the phicon parameter is not <c>NULL</c> and the function succeeds, then the return value is the number of icons extracted.
		/// Otherwise, the return value is 0xFFFFFFFF if the file is not found.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function extracts from executable (.exe), DLL (.dll), icon (.ico), cursor (.cur), animated cursor (.ani), and bitmap (.bmp)
		/// files. Extractions from Windows 3.x 16-bit executables (.exe or .dll) are also supported.
		/// </para>
		/// <para>
		/// The cxIcon and cyIcon parameters specify the size of the icons to extract. Two sizes can be extracted by putting the first size
		/// in the LOWORD of the parameter and the second size in the HIWORD. For example, for both the cxIcon and cyIcon parameters would
		/// extract both 24 and 48 size icons.
		/// </para>
		/// <para>You must destroy all icons extracted by <c>PrivateExtractIcons</c> by calling the DestroyIcon function.</para>
		/// <para>
		/// This function was not included in the SDK headers and libraries until Windows XP Service Pack 1 (SP1) and Windows Server 2003. If
		/// you do not have a header file and import library for this function, you can call the function using LoadLibrary and GetProcAddress.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-privateextracticonsa UINT PrivateExtractIconsA( LPCSTR
		// szFileName, int nIconIndex, int cxIcon, int cyIcon, HICON *phicon, UINT *piconid, UINT nIcons, UINT flags );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "privateextracticons")]
		public static extern uint PrivateExtractIcons(string szFileName, int nIconIndex, int cxIcon, int cyIcon,
			[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] SafeHICON[] phicon, out uint piconid, uint nIcons, LoadImageOptions flags);

#if WPF && !NET20 && !NETSTANDARD2_0 && !NETCOREAPP2_0 && !NETCOREAPP2_1
		/// <summary>Creates a <see cref="System.Windows.Media.Imaging.BitmapSource"/> from an <see cref="HICON"/>.</summary>
		/// <param name="hIcon">The HICON value.</param>
		/// <returns>The BitmapSource instance. If <paramref name="hIcon"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
		public static System.Windows.Media.Imaging.BitmapSource ToBitmapSource(this in HICON hIcon)
		{
			// If hIcon is NULL handle, return null
			if (hIcon.IsNull) return null;
			try
			{
				return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon((IntPtr)hIcon, System.Windows.Int32Rect.Empty,
					System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
			}
			catch (System.ComponentModel.Win32Exception)
			{
				return null;
			}
		}
#endif

		/// <summary>Creates a <see cref="SafeHBITMAP"/> from this HICON instance.</summary>
		/// <returns>A bitmap handle.</returns>
		public static SafeHBITMAP ToHBITMAP(this HICON hIcon)
		{
			if (hIcon.IsNull) return null;
			using var icoInfo = new ICONINFO();
			Win32Error.ThrowLastErrorIfFalse(GetIconInfo(hIcon, icoInfo));
			return new SafeHBITMAP((IntPtr)CopyImage((IntPtr)icoInfo.hbmColor, LoadImageType.IMAGE_BITMAP, 0, 0, CopyImageOptions.LR_CREATEDIBSECTION), true);
		}

		/// <summary>
		/// <para>Contains information about an icon or a cursor. Extends ICONINFO. Used by GetIconInfoEx.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-_iconinfoexa typedef struct _ICONINFOEXA { DWORD cbSize;
		// BOOL fIcon; DWORD xHotspot; DWORD yHotspot; HBITMAP hbmMask; HBITMAP hbmColor; WORD wResID; CHAR szModName[MAX_PATH]; CHAR
		// szResName[MAX_PATH]; } ICONINFOEXA, *PICONINFOEXA;
		[PInvokeData("winuser.h", MSDNShortId = "iconinfoex")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ICONINFOEX
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The size, in bytes, of this structure.</para>
			/// </summary>
			public uint cbSize;

			/// <summary/>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fIcon;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot spot is always in the center of the icon,
			/// and this member is ignored.
			/// </para>
			/// </summary>
			public uint xHotspot;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot spot is always in the center of the
			/// icon, and this member is ignored.
			/// </para>
			/// </summary>
			public uint yHotspot;

			/// <summary>
			/// <para>Type: <c>HBITMAP</c></para>
			/// <para>
			/// The icon bitmask bitmap. If this structure defines a black and white icon, this bitmask is formatted so that the upper half
			/// is the icon AND bitmask and the lower half is the icon XOR bitmask. Under this condition, the height should be an even
			/// multiple of two. If this structure defines a color icon, this mask only defines the AND bitmask of the icon.
			/// </para>
			/// </summary>
			public HBITMAP hbmMask;

			/// <summary>
			/// <para>Type: <c>HBITMAP</c></para>
			/// <para>
			/// A handle to the icon color bitmap. This member can be optional if this structure defines a black and white icon. The AND
			/// bitmask of <c>hbmMask</c> is applied with the <c>SRCAND</c> flag to the destination; subsequently, the color bitmap is
			/// applied (using XOR) to the destination by using the <c>SRCINVERT</c> flag.
			/// </para>
			/// </summary>
			public HBITMAP hbmColor;

			/// <summary>
			/// <para>Type: <c>WORD</c></para>
			/// <para>
			/// The icon or cursor resource bits. These bits are typically loaded by calls to the LookupIconIdFromDirectoryEx and
			/// LoadResource functions.
			/// </para>
			/// </summary>
			public ushort wResID;

			/// <summary>
			/// <para>Type: <c>TCHAR[MAX_PATH]</c></para>
			/// <para>The fully qualified path of the module.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szModName;

			/// <summary>
			/// <para>Type: <c>TCHAR[MAX_PATH]</c></para>
			/// <para>The fully qualified path of the resource.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szResName;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a Windows that disposes a created HICON instance at disposal using DestroyIcon.</summary>
		public class SafeHICON : SafeHANDLE, IUserHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHICON"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHICON(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			private SafeHICON() : base()
			{
			}

			/// <summary>Gets the size of this icon in pixels.</summary>
			public SIZE Size => GetSize(handle);

			/// <summary>Performs an implicit conversion from <see cref="SafeHICON"/> to <see cref="HICON"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HICON(SafeHICON h) => h.handle;

#if WPF && !NET20 && !NETSTANDARD2_0 && !NETCOREAPP2_0 && !NETCOREAPP2_1
			/// <summary>Creates a <see cref="System.Windows.Media.Imaging.BitmapSource"/> from an <see cref="SafeHICON"/>.</summary>
			/// <returns>The BitmapSource instance. If this is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
			public System.Windows.Media.Imaging.BitmapSource ToBitmapSource() => ((HICON)this).ToBitmapSource();
#endif

			/// <summary>Creates a <see cref="SafeHBITMAP"/> from this HICON instance.</summary>
			/// <returns>A bitmap handle.</returns>
			public SafeHBITMAP ToHBITMAP() => ((HICON)this).ToHBITMAP();

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DestroyIcon(this);
		}
	}
}