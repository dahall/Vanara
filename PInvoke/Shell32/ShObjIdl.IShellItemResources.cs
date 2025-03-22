namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes resource enumeration methods.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ienumresources
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IEnumResources")]
	[ComImport, Guid("2dd81fe3-a83c-4da9-a330-47249d345ba1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumResources : Vanara.Collections.ICOMEnum<SHELL_ITEM_RESOURCE>
	{
		/// <summary>Gets the next SHELL_ITEM_RESOURCE structure.</summary>
		/// <param name="celt">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of resources requested. Currently, must be 1.</para>
		/// </param>
		/// <param name="psir">
		/// <para>Type: <c>SHELL_ITEM_RESOURCE*</c></para>
		/// <para>Receives a pointer to a SHELL_ITEM_RESOURCE structure.</para>
		/// </param>
		/// <param name="pceltFetched">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>A pointer to the number of resources retrieved. Currently, not used.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/fr-fr/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumresources-next HRESULT Next( ULONG
		// celt, SHELL_ITEM_RESOURCE *psir, ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SHELL_ITEM_RESOURCE[] psir, out uint pceltFetched);

		/// <summary>Skips a specified number of resources.</summary>
		/// <param name="celt">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of resources to skip.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumresources-skip HRESULT Skip( ULONG
		// celt );
		void Skip(uint celt);

		/// <summary>Resets the enumeration index to 0.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumresources-reset HRESULT Reset();
		void Reset();

		/// <summary>Clones a resource enumerator.</summary>
		/// <returns>
		/// <para>Type: <c>IEnumResources**</c></para>
		/// <para>Contains the address of an IEnumResources interface pointer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumresources-clone HRESULT Clone(
		// IEnumResources **ppenumr );
		IEnumResources Clone();
	}

	/// <summary>Exposes methods to manipulate and query Shell item resources.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellitemresources
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellItemResources")]
	[ComImport, Guid("ff5693be-2ce0-4d48-b5c5-40817d1acdb9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellItemResources
	{
		/// <summary>Gets resource attributes.</summary>
		/// <returns>
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer to resource attributes. The following are attribute values.</para>
		/// <para>FILE_ATTRIBUTE_READONLY</para>
		/// <para>Value is 0x00000001.</para>
		/// <para>FILE_ATTRIBUTE_HIDDEN</para>
		/// <para>Value is 0x00000002.</para>
		/// <para>FILE_ATTRIBUTE_SYSTEM</para>
		/// <para>Value is 0x00000004.</para>
		/// <para>FILE_ATTRIBUTE_DIRECTORY</para>
		/// <para>Value is 0x00000010.</para>
		/// <para>FILE_ATTRIBUTE_ARCHIVE</para>
		/// <para>Value is 0x00000020.</para>
		/// <para>FILE_ATTRIBUTE_ENCRYPTED</para>
		/// <para>Value is 0x00000040.</para>
		/// <para>FILE_ATTRIBUTE_NORMAL</para>
		/// <para>Value is 0x00000080.</para>
		/// <para>FILE_ATTRIBUTE_TEMPORARY</para>
		/// <para>Value is 0x00000100.</para>
		/// <para>FILE_ATTRIBUTE_SPARSE_FILE</para>
		/// <para>Value is 0x00000200.</para>
		/// <para>FILE_ATTRIBUTE_REPARSE_POINT</para>
		/// <para>Value is 0x00000400.</para>
		/// <para>FILE_ATTRIBUTE_COMPRESSED</para>
		/// <para>Value is 0x00000800.</para>
		/// <para>FILE_ATTRIBUTE_OFFLINE</para>
		/// <para>Value is 0x00001000.</para>
		/// <para>FILE_ATTRIBUTE_CONTENT_INDEXED</para>
		/// <para>Value is 0x00002000.</para>
		/// <para>FILE_ATTRIBUTE_VALID_FLAGS</para>
		/// <para>Value is 0x00001ff7.</para>
		/// <para>FILE_ATTRIBUTE_VALID_SET_FLAGS</para>
		/// <para>Value is 0x000011a7.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-getattributes HRESULT
		// GetAttributes( DWORD *pdwAttributes );
		FileFlagsAndAttributes GetAttributes();

		/// <summary>Gets the source size.</summary>
		/// <returns>
		/// <para>Type: <c>ULONGLONG*</c></para>
		/// <para>A pointer to the source size.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-getsize HRESULT
		// GetSize( ULONGLONG *pullSize );
		ulong GetSize();

		/// <summary>Gets file times.</summary>
		/// <param name="pftCreation">The filetime.</param>
		/// <param name="pftWrite">The filetime.</param>
		/// <param name="pftAccess">The filetime.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-gettimes HRESULT
		// GetTimes( FILETIME *pftCreation, FILETIME *pftWrite, FILETIME *pftAccess );
		void GetTimes(out FILETIME pftCreation, out FILETIME pftWrite, out FILETIME pftAccess);

		/// <summary>Sets file times.</summary>
		/// <param name="pftCreation">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>A pointer to a creation date and time as a FILETIME structure.</para>
		/// </param>
		/// <param name="pftWrite">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>A pointer to a write date and time as a FILETIME structure.</para>
		/// </param>
		/// <param name="pftAccess">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>A pointer to an access date and time as a FILETIME structure.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-settimes HRESULT
		// SetTimes( const FILETIME *pftCreation, const FILETIME *pftWrite, const FILETIME *pftAccess );
		void SetTimes([In, Optional] IntPtr pftCreation, [In, Optional] IntPtr pftWrite, [In, Optional] IntPtr pftAccess);

		/// <summary>Gets a resource description.</summary>
		/// <param name="pcsir">
		/// <para>Type: <c>const SHELL_ITEM_RESOURCE*</c></para>
		/// <para>A pointer to a SHELL_ITEM_RESOURCE resource.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>A pointer to a resource description as a Unicode string.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-getresourcedescription
		// HRESULT GetResourceDescription( const SHELL_ITEM_RESOURCE *pcsir, LPWSTR *ppszDescription );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetResourceDescription(in SHELL_ITEM_RESOURCE pcsir);

		/// <summary>Gets a resource enumerator object.</summary>
		/// <returns>
		/// <para>Type: <c>IEnumResources**</c></para>
		/// <para>The address of an IEnumResources interface pointer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-enumresources HRESULT
		// EnumResources( IEnumResources **ppenumr );
		IEnumResources EnumResources();

		/// <summary>Retrieves whether an item supports a specified resource.</summary>
		/// <param name="pcsir">The shell item resource.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-supportsresource
		// HRESULT SupportsResource( const SHELL_ITEM_RESOURCE *pcsir );
		void SupportsResource(in SHELL_ITEM_RESOURCE pcsir);

		/// <summary>Opens a specified resource.</summary>
		/// <param name="pcsir">
		/// <para>Type: <c>const SHELL_ITEM_RESOURCE*</c></para>
		/// <para>A pointer to a SHELL_ITEM_RESOURCE resource.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to a desired IID.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>The address of a pointer to a resource.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-openresource HRESULT
		// OpenResource( const SHELL_ITEM_RESOURCE *pcsir, REFIID riid, void **ppv );
		void OpenResource(in SHELL_ITEM_RESOURCE pcsir, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppv);

		/// <summary>Creates a specified resource.</summary>
		/// <param name="pcsir">
		/// <para>Type: <c>const SHELL_ITEM_RESOURCE*</c></para>
		/// <para>A pointer to an SHELL_ITEM_RESOURCE resource.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to a desired IID.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>The address of a pointer to the resource.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-createresource HRESULT
		// CreateResource( const SHELL_ITEM_RESOURCE *pcsir, REFIID riid, void **ppv );
		void CreateResource(in SHELL_ITEM_RESOURCE pcsir, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppv);

		/// <summary>Marks for delete.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemresources-markfordelete HRESULT MarkForDelete();
		void MarkForDelete();
	}

	/// <summary>Sets file times.</summary>
	/// <param name="psir">The IShellItemResources instance.</param>
	/// <param name="ftCreation">An optional creation date and time.</param>
	/// <param name="ftWrite">An optional write date and time.</param>
	/// <param name="ftAccess">An optional access date and time.</param>
	public static void SetTimes(this IShellItemResources psir, DateTime? ftCreation, DateTime? ftWrite, DateTime? ftAccess) =>
		psir.SetTimes((SafeCoTaskMemStruct<FILETIME>)ftCreation?.ToFileTimeStruct(), (SafeCoTaskMemStruct<FILETIME>)ftWrite?.ToFileTimeStruct(), (SafeCoTaskMemStruct<FILETIME>)ftAccess?.ToFileTimeStruct());

	/// <summary>Defines Shell item resource.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ns-shobjidl_core-shell_item_resource typedef struct
	// SHELL_ITEM_RESOURCE { GUID guidType; WCHAR szName[260]; } SHELL_ITEM_RESOURCE;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NS:shobjidl_core.SHELL_ITEM_RESOURCE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHELL_ITEM_RESOURCE
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>The <c>GUID</c> that identifies the item.</para>
		/// </summary>
		public Guid guidType;

		/// <summary>
		/// <para>Type: <c>WCHAR[MAX_PATH]</c></para>
		/// <para>The item name. A null-terminated Unicode buffer of size MAX_LENGTH characters.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szName;
	}
}