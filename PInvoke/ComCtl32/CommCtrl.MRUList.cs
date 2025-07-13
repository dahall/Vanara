namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary>Used to determine whether an item is present in a most recently used (MRU) list.</summary>
	/// <param name="pString1">
	/// <para>Type: <b>LPCTSTR</b></para>
	/// <para>The first string.</para>
	/// </param>
	/// <param name="pString2">
	/// <para>Type: <b>LPCTSTR</b></para>
	/// <para>A second string to compare to the first.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>Returns 0 if the items are identical, a nonzero value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// This function can be optionally specified for use in the <c><b>MRUINFO</b></c> structure passed to <c><b>CreateMRUListW</b></c>. This
	/// is useful when the MRU list was created with the <b>MRU_BINARY</b> flag. When this function is not specified, standard string
	/// comparison functions are used.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/shell/mrucmpproc int CALLBACK MRUCMPPROC( LPCTSTR pString1, LPCTSTR pString2 );
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate int MRUCMPPROC([MarshalAs(UnmanagedType.LPTStr)] string pString1, [MarshalAs(UnmanagedType.LPTStr)] string pString2);

	/// <summary>Flags that control the behavior of the MRU list.</summary>
	[Flags]
	public enum MRU : uint
	{
		/// <summary>Data is stored in the registry as binary data rather than string data.</summary>
		MRU_BINARY = 0x00000001,

		/// <summary>
		/// Write changes to the version of the MRU stored in the registry only when a new item is added or the MRU list's resources are
		/// freed from memory. Note that the active version of the MRU in memory is updated immediately in response to any change in contents
		/// or ordering.
		/// </summary>
		MRU_CACHEWRITE = 0x00000002,
	}

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP with Service Pack 2 (SP2) and Windows Server 2003. It might be altered or unavailable
	/// in subsequent versions of Windows. ]
	/// </para>
	/// <para>Adds a string to the top of the most recently used (MRU) list.</para>
	/// </summary>
	/// <param name="hMRU">
	/// <para>Type: <b>HANDLE</b></para>
	/// <para>The handle of the MRU list.</para>
	/// </param>
	/// <param name="szString">
	/// <para>Type: <b>LPCTSTR</b></para>
	/// <para>
	/// A pointer to the data. This can be either a string or, if the MRU list was created with the <b>MRU_BINARY</b> flag, binary data. In
	/// the case of binary data, the first <b>DWORD</b> indicates its size.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>Returns a non-negative value if successful, -1 otherwise.</para>
	/// </returns>
	/// <remarks>
	/// This function is not included in a public header or library. It can be accessed through <c><b>GetProcAddress</b></c> or extracted
	/// from comctl32.dll by its ordinal, which is 401 for <b>AddMRUStringW</b>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/shell/addmrustring int AddMRUStringW( _In_ HANDLE hMRU, _In_ LPCTSTR szString );
	[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern int AddMRUStringW([In] HMRULIST hMRU, [In] string szString);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP with Service Pack 2 (SP2) and Windows Server 2003. It might be altered or unavailable
	/// in subsequent versions of Windows. ]
	/// </para>
	/// <para>Adds a string to the top of the most recently used (MRU) list.</para>
	/// </summary>
	/// <param name="hMRU">
	/// <para>Type: <b>HANDLE</b></para>
	/// <para>The handle of the MRU list.</para>
	/// </param>
	/// <param name="szString">
	/// <para>Type: <b>LPCTSTR</b></para>
	/// <para>
	/// A pointer to the data. This can be either a string or, if the MRU list was created with the <b>MRU_BINARY</b> flag, binary data. In
	/// the case of binary data, the first <b>DWORD</b> indicates its size.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>Returns a non-negative value if successful, -1 otherwise.</para>
	/// </returns>
	/// <remarks>
	/// This function is not included in a public header or library. It can be accessed through <c><b>GetProcAddress</b></c> or extracted
	/// from comctl32.dll by its ordinal, which is 401 for <b>AddMRUStringW</b>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/shell/addmrustring int AddMRUStringW( _In_ HANDLE hMRU, _In_ LPCTSTR szString );
	[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern int AddMRUStringW([In] HMRULIST hMRU, [In] IntPtr szString);

	/// <summary>Creates a new most recently used (MRU) list.</summary>
	/// <param name="lpmi">
	/// <para>Type: <b>LPMRUINFO</b></para>
	/// <para>A pointer to an <c><b>MRUINFO</b></c> structure defining the MRU list.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>Returns a handle to the new MRU list, or 0 in case of an error.</para>
	/// </returns>
	/// <remarks>
	/// This function is not included in a public header or library. It can be accessed through <c><b>GetProcAddress</b></c> or extracted
	/// from comctl32.dll by its ordinal, which is 400 for <b>CreateMRUListW</b>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/shell/createmrulist int CreateMRUListW( _In_LPMRUINFO lpmi );
	[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern HMRULIST CreateMRUListW(in MRUINFO lpmi);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP with Service Pack 2 (SP2) and Windows Server 2003. It might be altered or unavailable
	/// in subsequent versions of Windows. ]
	/// </para>
	/// <para>Enumerates the contents of the most recently used (MRU) list. Optionally retrieves an item from the enumeration.</para>
	/// </summary>
	/// <param name="hMRU">
	/// <para>Type: <b>HANDLE</b></para>
	/// <para>The handle of the MRU list, obtained when the list was created.</para>
	/// </param>
	/// <param name="nItem">
	/// <para>Type: <b>int</b></para>
	/// <para>The item to return. If this value is less than 0, the function returns the number of items in the MRU list.</para>
	/// </param>
	/// <param name="lpData">
	/// <para>Type: <b>void*</b></para>
	/// <para>A pointer to a buffer that receives the item requested in nItem. If nItem is less than 0, the contents of this buffer are unchanged.</para>
	/// </param>
	/// <param name="uLen">
	/// <para>Type: <b>UINT</b></para>
	/// <para>
	/// The size of the buffer, including the terminating null character. If the MRU list was created with the <b>MRU_BINARY</b> flag, this
	/// is the size in bytes. Otherwise, it is the size in characters.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Returns the number of items in the enumeration, if nItem is less than 0.</description>
	/// </item>
	/// <item>
	/// <description>Returns -1 if an error occurred.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Otherwise, returns the size of the string returned in lpData, including the terminating null character. If the MRU list was created
	/// with the <b>MRU_BINARY</b> flag, this is the size in bytes. Otherwise, it is the size in characters.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function is not included in a public header or library. It can be accessed through <c><b>GetProcAddress</b></c> or extracted
	/// from comctl32.dll by its ordinal, which is 403 for <b>EnumMRUListW</b>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/shell/enummrulist int EnumMRUListW( _In_HANDLE hMRU, _In_int nItem, _Out_void *lpData,
	// _In_UINT uLen );
	[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern int EnumMRUListW([In] HMRULIST hMRU, [In] int nItem, [Out, Optional] IntPtr lpData, [In, Optional] uint uLen);

	/// <summary>Frees the handle associated with the most recently used (MRU) list and writes cached data to the registry.</summary>
	/// <param name="hMRU">
	/// <para>Type: <b>HANDLE</b></para>
	/// <para>The handle of the MRU list to free.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>Returns a non-negative value if successful, -1 otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the MRU list was created using the <b>MRU_CACHEWRITE</b> flag, calling <b>FreeMRUList</b> causes any changes not yet written to
	/// the version of the MRU list stored in registry to be written at this time.
	/// </para>
	/// <para>This function is not included in a public header or library. It must be extracted from comctl32.dll by ordinal 152.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/shell/freemrulist int FreeMRUList( _In_HANDLE hMRU );
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	public static extern int FreeMRUList([In] HMRULIST hMRU);

	/// <summary>Contains information that defines a new most recently used (MRU) list. Used by <c><b>CreateMRUListW</b></c>.</summary>
	/// <remarks>This structure is not defined in a header file. You must define it yourself.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/shell/mruinfo typedef struct { DWORD cbSize; UINT uMax; UINT fFlags; HKEY hKey;
	// LPCTSTR lpszSubKey; MRUCMPPROC lpfnCompare; } _MRUINFO;
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MRUINFO
	{
		/// <summary>Size of the structure, in bytes.</summary>
		public uint cbSize;

		/// <summary>Maximum number of items in the MRU list.</summary>
		public uint uMax;

		/// <summary>Flags that control the behavior of the MRU list.</summary>
		public MRU fFlags;

		/// <summary>Handle to the registry key where the MRU list is stored.</summary>
		public HKEY hKey;

		/// <summary>Pointer to a null-terminated string that contains the subkey under which the MRU list is stored.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszSubKey;

		/// <summary>Pointer to a comparison function used to compare items in the MRU list.</summary>
		public MRUCMPPROC lpfnCompare;
	}
}