using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke;

public static partial class User32
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public const int OBM_CLOSE = 32754;
	public const int OBM_UPARROW = 32753;
	public const int OBM_DNARROW = 32752;
	public const int OBM_RGARROW = 32751;
	public const int OBM_LFARROW = 32750;
	public const int OBM_REDUCE = 32749;
	public const int OBM_ZOOM = 32748;
	public const int OBM_RESTORE = 32747;
	public const int OBM_REDUCED = 32746;
	public const int OBM_ZOOMD = 32745;
	public const int OBM_RESTORED = 32744;
	public const int OBM_UPARROWD = 32743;
	public const int OBM_DNARROWD = 32742;
	public const int OBM_RGARROWD = 32741;
	public const int OBM_LFARROWD = 32740;
	public const int OBM_MNARROW = 32739;
	public const int OBM_COMBO = 32738;
	public const int OBM_UPARROWI = 32737;
	public const int OBM_DNARROWI = 32736;
	public const int OBM_RGARROWI = 32735;
	public const int OBM_LFARROWI = 32734;
	public const int OBM_OLD_CLOSE = 32767;
	public const int OBM_SIZE = 32766;
	public const int OBM_OLD_UPARROW = 32765;
	public const int OBM_OLD_DNARROW = 32764;
	public const int OBM_OLD_RGARROW = 32763;
	public const int OBM_OLD_LFARROW = 32762;
	public const int OBM_BTSIZE = 32761;
	public const int OBM_CHECK = 32760;
	public const int OBM_CHECKBOXES = 32759;
	public const int OBM_BTNCORNERS = 32758;
	public const int OBM_OLD_REDUCE = 32757;
	public const int OBM_OLD_ZOOM = 32756;
	public const int OBM_OLD_RESTORE = 32755;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>Specifies the load options for <see cref="LoadImage"/>.</summary>
	[Flags]
	public enum LoadImageOptions : uint
	{
		/// <summary>The default flag; it does nothing. All it means is "not LR_MONOCHROME".</summary>
		LR_DEFAULTCOLOR = 0x00000000,

		/// <summary>Loads the image in black and white.</summary>
		LR_MONOCHROME = 0x00000001,

		/// <summary>Undocumented</summary>
		LR_COLOR = 0x00000002,

		/// <summary>Loads the stand-alone image from the file specified by lpszName (icon, cursor, or bitmap file).</summary>
		LR_LOADFROMFILE = 0x00000010,

		/// <summary>
		/// Retrieves the color value of the first pixel in the image and replaces the corresponding entry in the color table with the
		/// default window color (COLOR_WINDOW). All pixels in the image that use that entry become the default window color. This value
		/// applies only to images that have corresponding color tables.
		/// <para>Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.</para>
		/// <para>
		/// If fuLoad includes both the LR_LOADTRANSPARENT and LR_LOADMAP3DCOLORS values, LR_LOADTRANSPARENT takes precedence. However,
		/// the color table entry is replaced with COLOR_3DFACE rather than COLOR_WINDOW.
		/// </para>
		/// </summary>
		LR_LOADTRANSPARENT = 0x00000020,

		/// <summary>
		/// Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are
		/// set to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource
		/// size. If the resource contains multiple images, the function uses the size of the first image.
		/// </summary>
		LR_DEFAULTSIZE = 0x00000040,

		/// <summary>Uses true VGA colors.</summary>
		LR_VGACOLOR = 0x00000080,

		/// <summary>
		/// Searches the color table for the image and replaces the following shades of gray with the corresponding 3-D color.
		/// <list type="bullet">
		/// <item>
		/// <description>Dk Gray, RGB(128,128,128) with COLOR_3DSHADOW</description>
		/// </item>
		/// <item>
		/// <description>Gray, RGB(192,192,192) with COLOR_3DFACE</description>
		/// </item>
		/// <item>
		/// <description>Lt Gray, RGB(223,223,223) with COLOR_3DLIGHT</description>
		/// </item>
		/// </list>
		/// <para>Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.</para>
		/// </summary>
		LR_LOADMAP3DCOLORS = 0x00001000,

		/// <summary>
		/// When the uType parameter specifies IMAGE_BITMAP, causes the function to return a DIB section bitmap rather than a compatible
		/// bitmap. This flag is useful for loading a bitmap without mapping it to the colors of the display device.
		/// </summary>
		LR_CREATEDIBSECTION = 0x00002000,

		/// <summary>
		/// Shares the image handle if the image is loaded multiple times. If LR_SHARED is not set, a second call to LoadImage for the
		/// same resource will load the image again and return a different handle.
		/// <para>When you use this flag, the system will destroy the resource when it is no longer needed.</para>
		/// <para>
		/// Do not use LR_SHARED for images that have non-standard sizes, that may change after loading, or that are loaded from a file.
		/// </para>
		/// <para>When loading a system icon or cursor, you must use LR_SHARED or the function will fail to load the resource.</para>
		/// <para>This function finds the first image in the cache with the requested resource name, regardless of the size requested.</para>
		/// </summary>
		LR_SHARED = 0x00008000
	}

	/// <summary>Specifies the type of image to be loaded by <see cref="LoadImage"/>.</summary>
	public enum LoadImageType : uint
	{
		/// <summary>Loads a bitmap.</summary>
		IMAGE_BITMAP = 0,

		/// <summary>Loads an icon.</summary>
		IMAGE_ICON = 1,

		/// <summary>Loads a cursor.</summary>
		IMAGE_CURSOR = 2,

		/// <summary>Loads an enhanced metafile.</summary>
		IMAGE_ENHMETAFILE = 3
	}

	/// <summary>Loads an icon, cursor, animated cursor, or bitmap.</summary>
	/// <param name="hinst">
	/// A handle to the module of either a DLL or executable (.exe) that contains the image to be loaded. For more information, see
	/// GetModuleHandle. Note that as of 32-bit Windows, an instance handle (HINSTANCE), such as the application instance handle exposed
	/// by system function call of WinMain, and a module handle (HMODULE) are the same thing.
	/// <para>To load an OEM image, set this parameter to NULL.</para>
	/// <para>To load a stand-alone resource (icon, cursor, or bitmap file)—for example, c:\myimage.bmp—set this parameter to NULL.</para>
	/// </param>
	/// <param name="lpszName">
	/// The image to be loaded. If the hinst parameter is non-NULL and the fuLoad parameter omits LR_LOADFROMFILE, lpszName specifies the
	/// image resource in the hinst module. If the image resource is to be loaded by name from the module, the lpszName parameter is a
	/// pointer to a null-terminated string that contains the name of the image resource. If the image resource is to be loaded by
	/// ordinal from the module, use the MAKEINTRESOURCE macro to convert the image ordinal into a form that can be passed to the
	/// LoadImage function. For more information, see the Remarks section below.
	/// <para>
	/// If the hinst parameter is NULL and the fuLoad parameter omits the LR_LOADFROMFILE value, the lpszName specifies the OEM image to load.
	/// </para>
	/// <para>
	/// To pass these constants to the LoadImage function, use the MAKEINTRESOURCE macro. For example, to load the OCR_NORMAL cursor,
	/// pass MAKEINTRESOURCE(OCR_NORMAL) as the lpszName parameter, NULL as the hinst parameter, and LR_SHARED as one of the flags to the
	/// fuLoad parameter.
	/// </para>
	/// <para>
	/// If the fuLoad parameter includes the LR_LOADFROMFILE value, lpszName is the name of the file that contains the stand-alone
	/// resource (icon, cursor, or bitmap file). Therefore, set hinst to NULL.
	/// </para>
	/// </param>
	/// <param name="uType">The type of image to be loaded. This parameter can be one of the following values.</param>
	/// <param name="cxDesired">
	/// The width, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CXICON or SM_CXCURSOR system metric value to set the width. If this parameter is zero and LR_DEFAULTSIZE is not used,
	/// the function uses the actual resource width.
	/// </param>
	/// <param name="cyDesired">
	/// The height, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CYICON or SM_CYCURSOR system metric value to set the height. If this parameter is zero and LR_DEFAULTSIZE is not
	/// used, the function uses the actual resource height.
	/// </param>
	/// <param name="fuLoad">Loading options.</param>
	/// <returns>
	/// If the function succeeds, the return value is the handle of the newly loaded image. If the function fails, the return value is
	/// NULL.To get extended error information, call GetLastError.
	/// </returns>
	[PInvokeData("WinUser.h", MSDNShortId = "ms648045")]
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[System.Security.SecurityCritical]
	public static extern IntPtr LoadImage([Optional] HINSTANCE hinst, SafeResourceId lpszName, LoadImageType uType, int cxDesired, int cyDesired, LoadImageOptions fuLoad);

	/// <summary>Loads a bitmap.</summary>
	/// <param name="hinst">
	/// A handle to the module of either a DLL or executable (.exe) that contains the image to be loaded. For more information, see
	/// GetModuleHandle. Note that as of 32-bit Windows, an instance handle (HINSTANCE), such as the application instance handle exposed
	/// by system function call of WinMain, and a module handle (HMODULE) are the same thing.
	/// <para>To load an OEM image, set this parameter to NULL.</para>
	/// <para>To load a stand-alone resource (icon, cursor, or bitmap file)—for example, c:\myimage.bmp—set this parameter to NULL.</para>
	/// </param>
	/// <param name="lpszName">
	/// The image to be loaded. If the hinst parameter is non-NULL and the fuLoad parameter omits LR_LOADFROMFILE, lpszName specifies the
	/// image resource in the hinst module. If the image resource is to be loaded by name from the module, the lpszName parameter is a
	/// pointer to a null-terminated string that contains the name of the image resource. If the image resource is to be loaded by
	/// ordinal from the module, use the MAKEINTRESOURCE macro to convert the image ordinal into a form that can be passed to the
	/// LoadImage function. For more information, see the Remarks section below.
	/// <para>
	/// If the hinst parameter is NULL and the fuLoad parameter omits the LR_LOADFROMFILE value, the lpszName specifies the OEM image to load.
	/// </para>
	/// <para>
	/// To pass these constants to the LoadImage function, use the MAKEINTRESOURCE macro. For example, to load the OCR_NORMAL cursor,
	/// pass MAKEINTRESOURCE(OCR_NORMAL) as the lpszName parameter, NULL as the hinst parameter, and LR_SHARED as one of the flags to the
	/// fuLoad parameter.
	/// </para>
	/// <para>
	/// If the fuLoad parameter includes the LR_LOADFROMFILE value, lpszName is the name of the file that contains the stand-alone
	/// resource (icon, cursor, or bitmap file). Therefore, set hinst to NULL.
	/// </para>
	/// </param>
	/// <param name="cxDesired">
	/// The width, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CXICON or SM_CXCURSOR system metric value to set the width. If this parameter is zero and LR_DEFAULTSIZE is not used,
	/// the function uses the actual resource width.
	/// </param>
	/// <param name="cyDesired">
	/// The height, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CYICON or SM_CYCURSOR system metric value to set the height. If this parameter is zero and LR_DEFAULTSIZE is not
	/// used, the function uses the actual resource height.
	/// </param>
	/// <param name="fuLoad">Loading options.</param>
	/// <returns>
	/// If the function succeeds, the return value is the handle of the newly loaded image. If the function fails, the return value is
	/// NULL.To get extended error information, call GetLastError.
	/// </returns>
	public static SafeHBITMAP LoadImage_Bitmap([Optional] HINSTANCE hinst, SafeResourceId lpszName, int cxDesired, int cyDesired, LoadImageOptions fuLoad) =>
		new(LoadImage(hinst, lpszName, LoadImageType.IMAGE_BITMAP, cxDesired, cyDesired, fuLoad), true);

	/// <summary>Loads a cursor or animated cursor.</summary>
	/// <param name="hinst">
	/// A handle to the module of either a DLL or executable (.exe) that contains the image to be loaded. For more information, see
	/// GetModuleHandle. Note that as of 32-bit Windows, an instance handle (HINSTANCE), such as the application instance handle exposed
	/// by system function call of WinMain, and a module handle (HMODULE) are the same thing.
	/// <para>To load an OEM image, set this parameter to NULL.</para>
	/// <para>To load a stand-alone resource (icon, cursor, or bitmap file)—for example, c:\myimage.bmp—set this parameter to NULL.</para>
	/// </param>
	/// <param name="lpszName">
	/// The image to be loaded. If the hinst parameter is non-NULL and the fuLoad parameter omits LR_LOADFROMFILE, lpszName specifies the
	/// image resource in the hinst module. If the image resource is to be loaded by name from the module, the lpszName parameter is a
	/// pointer to a null-terminated string that contains the name of the image resource. If the image resource is to be loaded by
	/// ordinal from the module, use the MAKEINTRESOURCE macro to convert the image ordinal into a form that can be passed to the
	/// LoadImage function. For more information, see the Remarks section below.
	/// <para>
	/// If the hinst parameter is NULL and the fuLoad parameter omits the LR_LOADFROMFILE value, the lpszName specifies the OEM image to load.
	/// </para>
	/// <para>
	/// To pass these constants to the LoadImage function, use the MAKEINTRESOURCE macro. For example, to load the OCR_NORMAL cursor,
	/// pass MAKEINTRESOURCE(OCR_NORMAL) as the lpszName parameter, NULL as the hinst parameter, and LR_SHARED as one of the flags to the
	/// fuLoad parameter.
	/// </para>
	/// <para>
	/// If the fuLoad parameter includes the LR_LOADFROMFILE value, lpszName is the name of the file that contains the stand-alone
	/// resource (icon, cursor, or bitmap file). Therefore, set hinst to NULL.
	/// </para>
	/// </param>
	/// <param name="cxDesired">
	/// The width, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CXICON or SM_CXCURSOR system metric value to set the width. If this parameter is zero and LR_DEFAULTSIZE is not used,
	/// the function uses the actual resource width.
	/// </param>
	/// <param name="cyDesired">
	/// The height, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CYICON or SM_CYCURSOR system metric value to set the height. If this parameter is zero and LR_DEFAULTSIZE is not
	/// used, the function uses the actual resource height.
	/// </param>
	/// <param name="fuLoad">Loading options.</param>
	/// <returns>
	/// If the function succeeds, the return value is the handle of the newly loaded image. If the function fails, the return value is
	/// NULL.To get extended error information, call GetLastError.
	/// </returns>
	public static SafeHCURSOR LoadImage_Cursor([Optional] HINSTANCE hinst, SafeResourceId lpszName, int cxDesired, int cyDesired, LoadImageOptions fuLoad) =>
		new(LoadImage(hinst, lpszName, LoadImageType.IMAGE_CURSOR, cxDesired, cyDesired, fuLoad), true);

	/// <summary>Loads an enhanced metafile.</summary>
	/// <param name="hinst">
	/// A handle to the module of either a DLL or executable (.exe) that contains the image to be loaded. For more information, see
	/// GetModuleHandle. Note that as of 32-bit Windows, an instance handle (HINSTANCE), such as the application instance handle exposed
	/// by system function call of WinMain, and a module handle (HMODULE) are the same thing.
	/// <para>To load an OEM image, set this parameter to NULL.</para>
	/// <para>To load a stand-alone resource (icon, cursor, or bitmap file)—for example, c:\myimage.bmp—set this parameter to NULL.</para>
	/// </param>
	/// <param name="lpszName">
	/// The image to be loaded. If the hinst parameter is non-NULL and the fuLoad parameter omits LR_LOADFROMFILE, lpszName specifies the
	/// image resource in the hinst module. If the image resource is to be loaded by name from the module, the lpszName parameter is a
	/// pointer to a null-terminated string that contains the name of the image resource. If the image resource is to be loaded by
	/// ordinal from the module, use the MAKEINTRESOURCE macro to convert the image ordinal into a form that can be passed to the
	/// LoadImage function. For more information, see the Remarks section below.
	/// <para>
	/// If the hinst parameter is NULL and the fuLoad parameter omits the LR_LOADFROMFILE value, the lpszName specifies the OEM image to load.
	/// </para>
	/// <para>
	/// To pass these constants to the LoadImage function, use the MAKEINTRESOURCE macro. For example, to load the OCR_NORMAL cursor,
	/// pass MAKEINTRESOURCE(OCR_NORMAL) as the lpszName parameter, NULL as the hinst parameter, and LR_SHARED as one of the flags to the
	/// fuLoad parameter.
	/// </para>
	/// <para>
	/// If the fuLoad parameter includes the LR_LOADFROMFILE value, lpszName is the name of the file that contains the stand-alone
	/// resource (icon, cursor, or bitmap file). Therefore, set hinst to NULL.
	/// </para>
	/// </param>
	/// <param name="cxDesired">
	/// The width, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CXICON or SM_CXCURSOR system metric value to set the width. If this parameter is zero and LR_DEFAULTSIZE is not used,
	/// the function uses the actual resource width.
	/// </param>
	/// <param name="cyDesired">
	/// The height, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CYICON or SM_CYCURSOR system metric value to set the height. If this parameter is zero and LR_DEFAULTSIZE is not
	/// used, the function uses the actual resource height.
	/// </param>
	/// <param name="fuLoad">Loading options.</param>
	/// <returns>
	/// If the function succeeds, the return value is the handle of the newly loaded image. If the function fails, the return value is
	/// NULL.To get extended error information, call GetLastError.
	/// </returns>
	public static SafeHENHMETAFILE LoadImage_EnhMetaFile([Optional] HINSTANCE hinst, SafeResourceId lpszName, int cxDesired, int cyDesired, LoadImageOptions fuLoad) =>
		new(LoadImage(hinst, lpszName, LoadImageType.IMAGE_ENHMETAFILE, cxDesired, cyDesired, fuLoad), true);

	/// <summary>Loads an icon.</summary>
	/// <param name="hinst">
	/// A handle to the module of either a DLL or executable (.exe) that contains the image to be loaded. For more information, see
	/// GetModuleHandle. Note that as of 32-bit Windows, an instance handle (HINSTANCE), such as the application instance handle exposed
	/// by system function call of WinMain, and a module handle (HMODULE) are the same thing.
	/// <para>To load an OEM image, set this parameter to NULL.</para>
	/// <para>To load a stand-alone resource (icon, cursor, or bitmap file)—for example, c:\myimage.bmp—set this parameter to NULL.</para>
	/// </param>
	/// <param name="lpszName">
	/// The image to be loaded. If the hinst parameter is non-NULL and the fuLoad parameter omits LR_LOADFROMFILE, lpszName specifies the
	/// image resource in the hinst module. If the image resource is to be loaded by name from the module, the lpszName parameter is a
	/// pointer to a null-terminated string that contains the name of the image resource. If the image resource is to be loaded by
	/// ordinal from the module, use the MAKEINTRESOURCE macro to convert the image ordinal into a form that can be passed to the
	/// LoadImage function. For more information, see the Remarks section below.
	/// <para>
	/// If the hinst parameter is NULL and the fuLoad parameter omits the LR_LOADFROMFILE value, the lpszName specifies the OEM image to load.
	/// </para>
	/// <para>
	/// To pass these constants to the LoadImage function, use the MAKEINTRESOURCE macro. For example, to load the OCR_NORMAL cursor,
	/// pass MAKEINTRESOURCE(OCR_NORMAL) as the lpszName parameter, NULL as the hinst parameter, and LR_SHARED as one of the flags to the
	/// fuLoad parameter.
	/// </para>
	/// <para>
	/// If the fuLoad parameter includes the LR_LOADFROMFILE value, lpszName is the name of the file that contains the stand-alone
	/// resource (icon, cursor, or bitmap file). Therefore, set hinst to NULL.
	/// </para>
	/// </param>
	/// <param name="cxDesired">
	/// The width, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CXICON or SM_CXCURSOR system metric value to set the width. If this parameter is zero and LR_DEFAULTSIZE is not used,
	/// the function uses the actual resource width.
	/// </param>
	/// <param name="cyDesired">
	/// The height, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function
	/// uses the SM_CYICON or SM_CYCURSOR system metric value to set the height. If this parameter is zero and LR_DEFAULTSIZE is not
	/// used, the function uses the actual resource height.
	/// </param>
	/// <param name="fuLoad">Loading options.</param>
	/// <returns>
	/// If the function succeeds, the return value is the handle of the newly loaded image. If the function fails, the return value is
	/// NULL.To get extended error information, call GetLastError.
	/// </returns>
	public static SafeHICON LoadImage_Icon([Optional] HINSTANCE hinst, SafeResourceId lpszName, int cxDesired, int cyDesired, LoadImageOptions fuLoad) =>
		new(LoadImage(hinst, lpszName, LoadImageType.IMAGE_ICON, cxDesired, cyDesired, fuLoad), true);

	/// <summary>
	/// Loads a string resource from the executable file associated with a specified module, copies the string into a buffer, and appends
	/// a terminating null character.
	/// </summary>
	/// <param name="hInstance">
	/// A handle to an instance of the module whose executable file contains the string resource. To get the handle to the application
	/// itself, call the GetModuleHandle function with NULL.
	/// </param>
	/// <param name="uID">The identifier of the string to be loaded.</param>
	/// <param name="lpBuffer">The buffer is to receive the string. Must be of sufficient length to hold a pointer (8 bytes).</param>
	/// <param name="nBufferMax">
	/// The size of the buffer, in characters. The string is truncated and null-terminated if it is longer than the number of characters
	/// specified. If this parameter is 0, then lpBuffer receives a read-only pointer to the resource itself.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is the number of characters copied into the buffer, not including the terminating null
	/// character, or zero if the string resource does not exist. To get extended error information, call GetLastError.
	/// </returns>
	[PInvokeData("WinUser.h", MSDNShortId = "ms647486")]
	[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
	[System.Security.SecurityCritical, SuppressAutoGen]
	public static extern int LoadString(HINSTANCE hInstance, int uID, StringBuilder lpBuffer, int nBufferMax);

	/// <summary>Loads a string resource from the executable file associated with a specified module.</summary>
	/// <param name="hInstance">
	/// A handle to an instance of the module whose executable file contains the string resource. To get the handle to the application
	/// itself, call the GetModuleHandle function with NULL.
	/// </param>
	/// <param name="uID">The identifier of the string to be loaded.</param>
	/// <returns>If the function succeeds, the return value is the full resource string.</returns>
	[PInvokeData("WinUser.h", MSDNShortId = "ms647486")]
	public static string? LoadString(HINSTANCE hInstance, int uID)
	{
		var l = LoadString(hInstance, uID, out var p);
		if (l == 0) Win32Error.ThrowLastError();
		return p;
	}

	[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
	[System.Security.SecurityCritical]
	private static extern int LoadString(HINSTANCE hInstance, int uID, out StrPtrAuto lpBuffer, int nBufferMax = 0);

	/// <summary/>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GRPICONDIR
	{
		/// <summary>Reserved (must be 0)</summary>
		public ushort idReserved;

		/// <summary>Resource type</summary>
		public ResourceType idType;

		/// <summary>Icon count</summary>
		public ushort idCount;
	}

	/// <summary>Represents an icon as stored in a resource</summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GRPICONDIRENTRY
	{
		/// <summary>Width, in pixels, of the image</summary>
		public byte bWidth;

		/// <summary>Height, in pixels, of the image</summary>
		public byte bHeight;

		/// <summary>Number of colors in image (0 if &gt;= 8bpp)</summary>
		public byte bColorCount;

		/// <summary>Reserved</summary>
		public byte bReserved;

		/// <summary>Color Planes</summary>
		public ushort wPlanes;

		/// <summary>Bits per pixel</summary>
		public ushort wBitCount;

		/// <summary>How many bytes in this resource?</summary>
		public uint dwBytesInRes;

		/// <summary>The ID</summary>
		public ushort nId;
	}
}