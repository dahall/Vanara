using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Flags used by <see cref="IExtractIconW.GetIconLocation(GetIconLocationFlags, StringBuilder, int, out int, out GetIconLocationResultFlags)"/>.</summary>
	[Flags]
	public enum GetIconLocationFlags : uint
	{
		/// <summary>
		/// Set this flag to determine whether the icon should be extracted asynchronously. If the icon can be extracted rapidly, this
		/// flag is usually ignored. If extraction will take more time, GetIconLocation should return E_PENDING. See the Remarks for
		/// further discussion.
		/// </summary>
		GIL_ASYNC = 0x0020,

		/// <summary>
		/// Retrieve information about the fallback icon. Fallback icons are usually used while the desired icon is extracted and added
		/// to the cache.
		/// </summary>
		GIL_DEFAULTICON = 0x0040,

		/// <summary>The icon is displayed in a Shell folder.</summary>
		GIL_FORSHELL = 0x0002,

		/// <summary>
		/// The icon indicates a shortcut. However, the icon extractor should not apply the shortcut overlay; that will be done later.
		/// Shortcut icons are state-independent.
		/// </summary>
		GIL_FORSHORTCUT = 0x0080,

		/// <summary>
		/// The icon is in the open state if both open-state and closed-state images are available. If this flag is not specified, the
		/// icon is in the normal or closed state. This flag is typically used for folder objects.
		/// </summary>
		GIL_OPENICON = 0x0001,

		/// <summary>Explicitly return either GIL_SHIELD or GIL_FORCENOSHIELD in pwFlags. Do not block if GIL_ASYNC is set.</summary>
		GIL_CHECKSHIELD = 0x0200
	}

	/// <summary>
	/// Flags returned by <see cref="IExtractIconW.GetIconLocation(GetIconLocationFlags, StringBuilder, int, out int, out GetIconLocationResultFlags)"/>.
	/// </summary>
	[Flags]
	public enum GetIconLocationResultFlags : uint
	{
		/// <summary>The calling application should create a document icon using the specified icon.</summary>
		GIL_SIMULATEDOC = 0x0001,

		/// <summary>
		/// Each object of this class has its own icon. This flag is used internally by the Shell to handle cases like Setup.exe, where
		/// objects with identical names can have different icons. Typical implementations of IExtractIcon do not require this flag.
		/// </summary>
		GIL_PERINSTANCE = 0x0002,

		/// <summary>
		/// All objects of this class have the same icon. This flag is used internally by the Shell. Typical implementations of
		/// IExtractIcon do not require this flag because the flag implies that an icon handler is not required to resolve the icon on a
		/// per-object basis. The recommended method for implementing per-class icons is to register a DefaultIcon for the class.
		/// </summary>
		GIL_PERCLASS = 0x0004,

		/// <summary>
		/// The location is not a file name/index pair. The values in pszIconFile and piIndex cannot be passed to ExtractIcon or
		/// ExtractIconEx. When this flag is omitted, the value returned in pszIconFile is a fully-qualified path name to either a .ico
		/// file or to a file that can contain icons. Also, the value returned in piIndex is an index into that file that identifies
		/// which of its icons to use. Therefore, when the GIL_NOTFILENAME flag is omitted, these values can be passed to ExtractIcon or ExtractIconEx.
		/// </summary>
		GIL_NOTFILENAME = 0x0008,

		/// <summary>The physical image bits for this icon are not cached by the calling application.</summary>
		GIL_DONTCACHE = 0x0010,

		/// <summary>Undocumented, but appears to indicate thumbnails are available.</summary>
		GIL_HASTHUMBNAIL = 0x0020,

		/// <summary>Windows Vista only. The calling application must stamp the icon with the UAC shield.</summary>
		GIL_SHIELD = 0x0200, //Windows Vista only

		/// <summary>Windows Vista only. The calling application must not stamp the icon with the UAC shield.</summary>
		GIL_FORCENOSHIELD = 0x0400, //Windows Vista only

		/// <summary>Undocumented, but appears to indicate the folder is encrypted.</summary>
		GIL_ENCRYPTED = 0x0800,

		/// <summary>Undocumented, but appears to indicate a compressed folder.</summary>
		GIL_COMPRESSED = 0x1000,
	}

	/// <summary>Exposes methods that allow a client to retrieve the icon that is associated with one of the objects in a folder.</summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761854(v=vs.85).aspx
	[PInvokeData("Shlobj_core.h", MSDNShortId = "bb761854")]
	[ComImport, Guid("000214eb-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IExtractIconA
	{
		/// <summary>Gets the location and index of an icon.</summary>
		/// <param name="uFlags">One or more of the following values. This parameter can also be NULL.use GIL_ Consts</param>
		/// <param name="szIconFile">
		/// A pointer to a buffer that receives the icon location. The icon location is a null-terminated string that identifies the
		/// file that contains the icon.
		/// </param>
		/// <param name="cchMax">The size of the buffer, in characters, pointed to by pszIconFile.</param>
		/// <param name="piIndex">A pointer to an int that receives the index of the icon in the file pointed to by pszIconFile.</param>
		/// <param name="pwFlags">A pointer to a UINT value that receives zero or a combination of the following value</param>
		/// <returns>
		/// Returns S_OK if the function returned a valid location, or S_FALSE if the Shell should use a default icon. If the GIL_ASYNC
		/// flag is set in uFlags, the method can return E_PENDING to indicate that icon extraction will be time-consuming.
		/// </returns>
		[PreserveSig]
		HRESULT GetIconLocation(GetIconLocationFlags uFlags, [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 2)] StringBuilder szIconFile, int cchMax, out int piIndex, out GetIconLocationResultFlags pwFlags);

		/// <summary>Extracts an icon image from the specified location.</summary>
		/// <param name="pszFile">A pointer to a null-terminated string that specifies the icon location.</param>
		/// <param name="nIconIndex">The index of the icon in the file pointed to by pszFile.</param>
		/// <param name="phiconLarge">
		/// A pointer to an HICON value that receives the handle to the large icon. This parameter may be NULL.
		/// </param>
		/// <param name="phiconSmall">
		/// A pointer to an HICON value that receives the handle to the small icon. This parameter may be NULL.
		/// </param>
		/// <param name="nIconSize">
		/// The desired size of the icon, in pixels. The low word contains the size of the large icon, and the high word contains the
		/// size of the small icon. The size specified can be the width or height. The width of an icon always equals its height.
		/// </param>
		/// <returns>Returns S_OK if the function extracted the icon, or S_FALSE if the calling application should extract the icon.</returns>
		[PreserveSig]
		unsafe HRESULT Extract([MarshalAs(UnmanagedType.LPStr)] string pszFile, uint nIconIndex, [Optional] HICON* phiconLarge, [Optional] HICON* phiconSmall, uint nIconSize);
	}

	/// <summary>Exposes methods that allow a client to retrieve the icon that is associated with one of the objects in a folder.</summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761854(v=vs.85).aspx
	[PInvokeData("Shlobj_core.h", MSDNShortId = "bb761854")]
	[ComImport, Guid("000214fa-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IExtractIconW
	{
		/// <summary>Gets the location and index of an icon.</summary>
		/// <param name="uFlags">One or more of the following values. This parameter can also be NULL.use GIL_ Consts</param>
		/// <param name="szIconFile">
		/// A pointer to a buffer that receives the icon location. The icon location is a null-terminated string that identifies the
		/// file that contains the icon.
		/// </param>
		/// <param name="cchMax">The size of the buffer, in characters, pointed to by pszIconFile.</param>
		/// <param name="piIndex">A pointer to an int that receives the index of the icon in the file pointed to by pszIconFile.</param>
		/// <param name="pwFlags">A pointer to a UINT value that receives zero or a combination of the following value</param>
		/// <returns>
		/// Returns S_OK if the function returned a valid location, or S_FALSE if the Shell should use a default icon. If the GIL_ASYNC
		/// flag is set in uFlags, the method can return E_PENDING to indicate that icon extraction will be time-consuming.
		/// </returns>
		[PreserveSig]
		HRESULT GetIconLocation(GetIconLocationFlags uFlags, [MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 2)] StringBuilder szIconFile, int cchMax, out int piIndex, out GetIconLocationResultFlags pwFlags);

		/// <summary>Extracts an icon image from the specified location.</summary>
		/// <param name="pszFile">A pointer to a null-terminated string that specifies the icon location.</param>
		/// <param name="nIconIndex">The index of the icon in the file pointed to by pszFile.</param>
		/// <param name="phiconLarge">
		/// A pointer to an HICON value that receives the handle to the large icon. This parameter may be NULL.
		/// </param>
		/// <param name="phiconSmall">
		/// A pointer to an HICON value that receives the handle to the small icon. This parameter may be NULL.
		/// </param>
		/// <param name="nIconSize">
		/// The desired size of the icon, in pixels. The low word contains the size of the large icon, and the high word contains the
		/// size of the small icon. The size specified can be the width or height. The width of an icon always equals its height.
		/// </param>
		/// <returns>Returns S_OK if the function extracted the icon, or S_FALSE if the calling application should extract the icon.</returns>
		[PreserveSig]
		unsafe HRESULT Extract([MarshalAs(UnmanagedType.LPWStr)] string pszFile, uint nIconIndex, [Optional] HICON* phiconLarge, [Optional] HICON* phiconSmall, uint nIconSize);
	}

	/// <summary>Extracts an icon image from the specified location.</summary>
	/// <param name="exIcon">The <see cref="IExtractIconA"/> instance.</param>
	/// <param name="pszFile">A pointer to a null-terminated string that specifies the icon location.</param>
	/// <param name="nIconIndex">The index of the icon in the file pointed to by pszFile.</param>
	/// <param name="nIconSize">
	/// The desired size of the icon, in pixels. The size specified can be the width or height. The width of an icon always equals
	/// its height.
	/// </param>
	/// <param name="phicon">A pointer to an HICON value that receives the handle to the icon. This parameter may be NULL.</param>
	/// <returns>Returns S_OK if the function extracted the icon, or S_FALSE if the calling application should extract the icon.</returns>
	public static HRESULT Extract(this IExtractIconA exIcon, string pszFile, uint nIconIndex, ushort nIconSize, out SafeHICON phicon)
	{
		if (exIcon is null) throw new ArgumentNullException(nameof(exIcon));
		var sz = nIconSize > 16 ? Macros.MAKELONG(nIconSize, 0) : Macros.MAKELONG(0, nIconSize);
		unsafe
		{
			HICON h1 = default;
			var hr = nIconSize > 16 ? exIcon.Extract(pszFile, nIconIndex, &h1, null, sz) : exIcon.Extract(pszFile, nIconIndex, null, &h1, sz);
			phicon = h1 == default ? SafeHICON.Null : new SafeHICON((IntPtr)h1);
			return hr;
		}
	}

	/// <summary>Extracts an icon image from the specified location.</summary>
	/// <param name="exIcon">The <see cref="IExtractIconA"/> instance.</param>
	/// <param name="pszFile">A pointer to a null-terminated string that specifies the icon location.</param>
	/// <param name="nIconIndex">The index of the icon in the file pointed to by pszFile.</param>
	/// <param name="nIconSizeLarge">
	/// The desired size of the large icon, in pixels. The size specified can be the width or height. The width of an icon always equals
	/// its height.
	/// </param>
	/// <param name="phiconLarge">A pointer to an HICON value that receives the handle to the large icon. This parameter may be NULL.</param>
	/// <param name="nIconSizeSmall">
	/// The desired size of the small icon, in pixels. The size specified can be the width or height. The width of an icon always equals
	/// its height.
	/// </param>
	/// <param name="phiconSmall">A pointer to an HICON value that receives the handle to the small icon. This parameter may be NULL.</param>
	/// <returns>Returns S_OK if the function extracted the icon, or S_FALSE if the calling application should extract the icon.</returns>
	public static HRESULT Extract(this IExtractIconA exIcon, string pszFile, uint nIconIndex, ushort nIconSizeLarge, out SafeHICON phiconLarge, ushort nIconSizeSmall, out SafeHICON phiconSmall)
	{
		if (exIcon is null) throw new ArgumentNullException(nameof(exIcon));
		var sz = Macros.MAKELONG(nIconSizeLarge, nIconSizeSmall);
		unsafe
		{
			HICON h1 = default, h2 = default;
			var hr = exIcon.Extract(pszFile, nIconIndex, nIconSizeLarge == 0 ? null : &h1, nIconSizeSmall == 0 ? null : &h2, sz);
			phiconLarge = h1 == default ? SafeHICON.Null : new SafeHICON((IntPtr)h1);
			phiconSmall = h2 == default ? SafeHICON.Null : new SafeHICON((IntPtr)h2);
			return hr;
		}
	}

	/// <summary>Extracts an icon image from the specified location.</summary>
	/// <param name="exIcon">The <see cref="IExtractIconW"/> instance.</param>
	/// <param name="pszFile">A pointer to a null-terminated string that specifies the icon location.</param>
	/// <param name="nIconIndex">The index of the icon in the file pointed to by pszFile.</param>
	/// <param name="nIconSize">
	/// The desired size of the icon, in pixels. The size specified can be the width or height. The width of an icon always equals
	/// its height.
	/// </param>
	/// <param name="phicon">A pointer to an HICON value that receives the handle to the icon. This parameter may be NULL.</param>
	/// <returns>Returns S_OK if the function extracted the icon, or S_FALSE if the calling application should extract the icon.</returns>
	public static HRESULT Extract(this IExtractIconW exIcon, string pszFile, uint nIconIndex, ushort nIconSize, out SafeHICON phicon)
	{
		if (exIcon is null) throw new ArgumentNullException(nameof(exIcon));
		var sz = nIconSize > 16 ? Macros.MAKELONG(nIconSize, 0) : Macros.MAKELONG(0, nIconSize);
		unsafe
		{
			HICON h1 = default;
			var hr = nIconSize > 16 ? exIcon.Extract(pszFile, nIconIndex, &h1, null, sz) : exIcon.Extract(pszFile, nIconIndex, null, &h1, sz);
			phicon = h1 == default ? SafeHICON.Null : new SafeHICON((IntPtr)h1);
			return hr;
		}
	}

	/// <summary>Extracts an icon image from the specified location.</summary>
	/// <param name="exIcon">The <see cref="IExtractIconW"/> instance.</param>
	/// <param name="pszFile">A pointer to a null-terminated string that specifies the icon location.</param>
	/// <param name="nIconIndex">The index of the icon in the file pointed to by pszFile.</param>
	/// <param name="nIconSizeLarge">
	/// The desired size of the large icon, in pixels. The size specified can be the width or height. The width of an icon always equals
	/// its height.
	/// </param>
	/// <param name="phiconLarge">A pointer to an HICON value that receives the handle to the large icon. This parameter may be NULL.</param>
	/// <param name="nIconSizeSmall">
	/// The desired size of the small icon, in pixels. The size specified can be the width or height. The width of an icon always equals
	/// its height.
	/// </param>
	/// <param name="phiconSmall">A pointer to an HICON value that receives the handle to the small icon. This parameter may be NULL.</param>
	/// <returns>Returns S_OK if the function extracted the icon, or S_FALSE if the calling application should extract the icon.</returns>
	public static HRESULT Extract(this IExtractIconW exIcon, string pszFile, uint nIconIndex, ushort nIconSizeLarge, out SafeHICON phiconLarge, ushort nIconSizeSmall, out SafeHICON phiconSmall)
	{
		if (exIcon is null) throw new ArgumentNullException(nameof(exIcon));
		var sz = Macros.MAKELONG(nIconSizeLarge, nIconSizeSmall);
		unsafe
		{
			HICON h1 = default, h2 = default;
			var hr = exIcon.Extract(pszFile, nIconIndex, nIconSizeLarge == 0 ? null : &h1, nIconSizeSmall == 0 ? null : &h2, sz);
			phiconLarge = h1 == default ? SafeHICON.Null : new SafeHICON((IntPtr)h1);
			phiconSmall = h2 == default ? SafeHICON.Null : new SafeHICON((IntPtr)h2);
			return hr;
		}
	}
}