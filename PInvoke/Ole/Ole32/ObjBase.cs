using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// Determines the concurrency model used for incoming calls to objects created by this thread. This concurrency model can be either apartment-threaded
		/// or multithreaded.
		/// </summary>
		[Flags]
		[PInvokeData("Objbase.h", MSDNShortId = "ms678505")]
		public enum COINIT
		{
			/// <summary>Initializes the thread for apartment-threaded object concurrency (see Remarks).</summary>
			COINIT_APARTMENTTHREADED = 0x2,

			/// <summary>Initializes the thread for multithreaded object concurrency (see Remarks).</summary>
			COINIT_MULTITHREADED = 0x0,

			/// <summary>Disables DDE for OLE1 support.</summary>
			COINIT_DISABLE_OLE1DDE = 0x4,

			/// <summary>Increase memory usage in an attempt to increase performance.</summary>
			COINIT_SPEED_OVER_MEMORY = 0x8
		}

		/// <summary>
		/// The STGFMT enumeration values specify the format of a storage object and are used in the StgCreateStorageEx and StgOpenStorageEx functions in the stgfmt parameter. This value, in combination with the value in the riid parameter, is used to determine the file format and the interface implementation to use.
		/// </summary>
		[PInvokeData("Objbase.h", MSDNShortId = "aa380330")]
		public enum STGFMT
		{
			/// <summary>Indicates that the file must be a compound file.</summary>
			STGFMT_STORAGE = 0,
			/// <summary>Undocumented.</summary>
			STGFMT_NATIVE = 1,
			/// <summary>Indicates that the file must not be a compound file. This element is only valid when using the StgCreateStorageEx or StgOpenStorageEx functions to access the NTFS file system implementation of the IPropertySetStorage interface. Therefore, these functions return an error if the riid parameter does not specify the IPropertySetStorage interface, or if the specified file is not located on an NTFS file system volume.</summary>
			STGFMT_FILE = 3,
			/// <summary>Indicates that the system will determine the file type and use the appropriate structured storage or property set implementation. This value cannot be used with the StgCreateStorageEx function.</summary>
			STGFMT_ANY = 4,
			/// <summary>Indicates that the file must be a compound file, and is similar to the STGFMT_STORAGE flag, but indicates that the compound-file form of the compound-file implementation must be used. For more information, see Compound File Implementation Limits.</summary>
			STGFMT_DOCFILE = 5
		}

		/// <summary>
		/// Initializes the COM library for use by the calling thread, sets the thread's concurrency model, and creates a new apartment for the thread if one is required.
		/// <para>
		/// You should call Windows::Foundation::Initialize to initialize the thread instead of CoInitializeEx if you want to use the Windows Runtime APIs or if
		/// you want to use both COM and Windows Runtime components. Windows::Foundation::Initialize is sufficient to use for COM components.
		/// </para>
		/// </summary>
		/// <param name="pvReserved">This parameter is reserved and must be NULL.</param>
		/// <param name="coInit">
		/// The concurrency model and initialization options for the thread. Values for this parameter are taken from the COINIT enumeration. Any combination of
		/// values from COINIT can be used, except that the COINIT_APARTMENTTHREADED and COINIT_MULTITHREADED flags cannot both be set. The default is COINIT_MULTITHREADED.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader><term>Return code</term><term>Description</term></listheader>
		/// <item><term>S_OK</term><defintion>The COM library was initialized successfully on this thread.</defintion></item>
		/// <item><term>S_FALSE</term><defintion>The COM library is already initialized on this thread.</defintion></item>
		/// <item><term>RPC_E_CHANGED_MODE</term><defintion>A previous call to CoInitializeEx specified the concurrency model for this thread as multithreaded apartment (MTA). This could also indicate that a change from neutral-threaded apartment to single-threaded apartment has occurred.</defintion></item>
		/// </list>
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms695279")]
		public static extern HRESULT CoInitializeEx(IntPtr pvReserved, COINIT coInit);

		/// <summary>Registers security and sets the default security values for the process.</summary>
		/// <param name="pSecDesc">
		/// The access permissions that a server will use to receive calls. This parameter is used by COM only when a server calls <c>CoInitializeSecurity</c>.
		/// Its value is a pointer to one of three types: an AppID, an <c>IAccessControl</c> object, or a <c>SECURITY_DESCRIPTOR</c>, in absolute format. See the
		/// Remarks section for more information.
		/// </param>
		/// <param name="cAuthSvc">
		/// The count of entries in the asAuthSvc parameter. This parameter is used by COM only when a server calls <c>CoInitializeSecurity</c>. If this
		/// parameter is 0, no authentication services will be registered and the server cannot receive secure calls. A value of -1 tells COM to choose which
		/// authentication services to register, and if this is the case, the asAuthSvc parameter must be <c>NULL</c>. However, Schannel will never be chosen as
		/// an authentication service by the server if this parameter is -1.
		/// </param>
		/// <param name="asAuthSvc">
		/// An array of authentication services that a server is willing to use to receive a call. This parameter is used by COM only when a server calls
		/// <c>CoInitializeSecurity</c>. For more information, see <c>SOLE_AUTHENTICATION_SERVICE</c>.
		/// </param>
		/// <param name="pReserved1">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <param name="dwAuthnLevel">
		/// The default authentication level for the process. Both servers and clients use this parameter when they call <c>CoInitializeSecurity</c>. COM will
		/// fail calls that arrive with a lower authentication level. By default, all proxies will use at least this authentication level. This value should
		/// contain one of the authentication level constants. By default, all calls to <c>IUnknown</c> are made at this level.
		/// </param>
		/// <param name="dwImpLevel">
		/// <para>
		/// The default impersonation level for proxies. The value of this parameter is used only when the process is a client. It should be a value from the
		/// impersonation level constants, except for RPC_C_IMP_LEVEL_DEFAULT, which is not for use with <c>CoInitializeSecurity</c>.
		/// </para>
		/// <para>
		/// Outgoing calls from the client always use the impersonation level as specified. (It is not negotiated.) Incoming calls to the client can be at any
		/// impersonation level. By default, all <c>IUnknown</c> calls are made with this impersonation level, so even security-aware applications should set
		/// this level carefully. To determine which impersonation levels each authentication service supports, see the description of the authentication
		/// services in COM and Security Packages. For more information about impersonation levels, see Impersonation.
		/// </para>
		/// </param>
		/// <param name="pAuthList">
		/// A pointer to <c>SOLE_AUTHENTICATION_LIST</c>, which is an array of <c>SOLE_AUTHENTICATION_INFO</c> structures. This list indicates the information
		/// for each authentication service that a client can use to call a server. This parameter is used by COM only when a client calls <c>CoInitializeSecurity</c>.
		/// </param>
		/// <param name="dwCapabilities">
		/// Additional capabilities of the client or server, specified by setting one or more <c>EOLE_AUTHENTICATION_CAPABILITIES</c> values. Some of these value
		/// cannot be used simultaneously, and some cannot be set when particular authentication services are being used. For more information about these flags,
		/// see the Remarks section.
		/// </param>
		/// <param name="pReserved3">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This function can return the standard return value E_INVALIDARG, as well as the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Indicates success.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_TOO_LATE</term>
		/// <term>CoInitializeSecurity has already been called.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_NO_GOOD_SECURITY_PACKAGES</term>
		/// <term>
		/// The asAuthSvc parameter was not NULL, and none of the authentication services in the list could be registered. Check the results saved in asAuthSvc
		/// for authentication service–specific error codes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_OUT_OF_MEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT CoInitializeSecurity( _In_opt_ PSECURITY_DESCRIPTOR pSecDesc, _In_ LONG cAuthSvc, _In_opt_ SOLE_AUTHENTICATION_SERVICE *asAuthSvc, _In_opt_ void *pReserved1, _In_ DWORD dwAuthnLevel, _In_ DWORD dwImpLevel, _In_opt_ void *pAuthList, _In_ DWORD dwCapabilities, _In_opt_ void *pReserved3);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms693736(v=vs.85).aspx
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms693736")]
		public static extern HRESULT CoInitializeSecurity(IntPtr secDesc, int cAuthSvc, IntPtr asAuthSvc, IntPtr pReserved1, uint dwAuthnLevel, uint dwImpLevel, IntPtr pAuthList, uint dwCapabilities, IntPtr pReserved3);

		/// <summary>
		/// Closes the COM library on the current thread, unloads all DLLs loaded by the thread, frees any other resources that the thread maintains, and forces
		/// all RPC connections on the thread to close.
		/// </summary>
		[DllImport(Lib.Ole32, ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms688715")]
		public static extern void CoUninitialize();

		/// <summary>Returns a pointer to an implementation of IBindCtx (a bind context object). This object stores information about a particular moniker-binding operation.</summary>
		/// <param name="reserved">This parameter is reserved and must be 0.</param>
		/// <param name="ppbc">Address of an IBindCtx* pointer variable that receives the interface pointer to the new bind context object. When the function is successful, the caller is responsible for calling Release on the bind context. A NULL value for the bind context indicates that an error occurred.</param>
		/// <returns>This function can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms678542")]
		public static extern HRESULT CreateBindCtx(uint reserved, out IBindCtx ppbc);

		/// <summary>The StgCreateStorageEx function creates a new storage object using a provided implementation for the IStorage or IPropertySetStorage interfaces. To open an existing file, use the StgOpenStorageEx function instead.
		/// <para>Applications written for Windows 2000, Windows Server 2003 and Windows XP must use StgCreateStorageEx rather than StgCreateDocfile to take advantage of the enhanced Windows 2000 and Windows XP Structured Storage features.</para></summary>
		/// <param name="pwcsName">A pointer to the path of the file to create. It is passed uninterpreted to the file system. This can be a relative name or NULL. If NULL, a temporary file is allocated with a unique name. If non-NULL, the string size must not exceed MAX_PATH characters.
		/// <para>Windows 2000:  Unlike the CreateFile function, you cannot exceed the MAX_PATH limit by using the "\\?\" prefix.</para></param>
		/// <param name="grfMode">A value that specifies the access mode to use when opening the new storage object. For more information, see STGM Constants. If the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion takes place when the commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is required when a file is overwritten or converted in the transacted mode.</param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">A value that depends on the value of the stgfmt parameter.
		/// <list type="table">
		/// <listheader><term>Parameter Values</term><term>Meaning</term></listheader>
		/// <item><term>STGFMT_DOCFILE</term><description>0, or FILE_FLAG_NO_BUFFERING.For more information, see CreateFile.If the sector size of the file, specified in pStgOptions, is not an integer multiple of the underlying disk's physical sector size, this operation will fail.</description></item>
		/// <item><term>All other values of stgfmt</term><description>Must be 0.</description></item>
		/// </list></param>
		/// <param name="pStgOptions">The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. If the stgfmt parameter is set to STGFMT_DOCFILE, pStgOptions points to the STGOPTIONS structure, which specifies features of the storage object, such as the sector size. This parameter may be NULL, which creates a storage object with a default sector size of 512 bytes. If non-NULL, the ulSectorSize member must be set to either 512 or 4096. If set to 4096, STGM_SIMPLE may not be specified in the grfMode parameter. The usVersion member must be set before calling StgCreateStorageEx. For more information, see STGOPTIONS.</param>
		/// <param name="pSecurityDescriptor">Enables the ACLs to be set when the file is created. If not NULL, needs to be a pointer to the SECURITY_ATTRIBUTES structure. See CreateFile for information on how to set ACLs on files.
		/// <para>Windows Server 2003, Windows 2000 Server, Windows XP and Windows 2000 Professional:  Value must be NULL.</para></param>
		/// <param name="riid">A value that specifies the interface identifier (IID) of the interface pointer to return. This IID may be for the IStorage interface or the IPropertySetStorage interface.</param>
		/// <param name="ppObjectOpen">A pointer to an interface pointer variable that receives a pointer for an interface on the new storage object; contains NULL if operation failed.</param>
		/// <returns>This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error Handling Strategies and Handling Unknown Errors.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380328")]
		public static extern HRESULT StgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode,
			STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, [In] IntPtr pStgOptions, IntPtr pSecurityDescriptor, [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>The StgCreateStorageEx function creates a new storage object using a provided implementation for the IStorage or IPropertySetStorage interfaces. To open an existing file, use the StgOpenStorageEx function instead.
		/// <para>Applications written for Windows 2000, Windows Server 2003 and Windows XP must use StgCreateStorageEx rather than StgCreateDocfile to take advantage of the enhanced Windows 2000 and Windows XP Structured Storage features.</para></summary>
		/// <param name="pwcsName">A pointer to the path of the file to create. It is passed uninterpreted to the file system. This can be a relative name or NULL. If NULL, a temporary file is allocated with a unique name. If non-NULL, the string size must not exceed MAX_PATH characters.
		/// <para>Windows 2000:  Unlike the CreateFile function, you cannot exceed the MAX_PATH limit by using the "\\?\" prefix.</para></param>
		/// <param name="grfMode">A value that specifies the access mode to use when opening the new storage object. For more information, see STGM Constants. If the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion takes place when the commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is required when a file is overwritten or converted in the transacted mode.</param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">A value that depends on the value of the stgfmt parameter.
		/// <list type="table">
		/// <listheader><term>Parameter Values</term><term>Meaning</term></listheader>
		/// <item><term>STGFMT_DOCFILE</term><description>0, or FILE_FLAG_NO_BUFFERING.For more information, see CreateFile.If the sector size of the file, specified in pStgOptions, is not an integer multiple of the underlying disk's physical sector size, this operation will fail.</description></item>
		/// <item><term>All other values of stgfmt</term><description>Must be 0.</description></item>
		/// </list></param>
		/// <param name="pStgOptions">The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. If the stgfmt parameter is set to STGFMT_DOCFILE, pStgOptions points to the STGOPTIONS structure, which specifies features of the storage object, such as the sector size. This parameter may be NULL, which creates a storage object with a default sector size of 512 bytes. If non-NULL, the ulSectorSize member must be set to either 512 or 4096. If set to 4096, STGM_SIMPLE may not be specified in the grfMode parameter. The usVersion member must be set before calling StgCreateStorageEx. For more information, see STGOPTIONS.</param>
		/// <param name="pSecurityDescriptor">Enables the ACLs to be set when the file is created. If not NULL, needs to be a pointer to the SECURITY_ATTRIBUTES structure. See CreateFile for information on how to set ACLs on files.
		/// <para>Windows Server 2003, Windows 2000 Server, Windows XP and Windows 2000 Professional:  Value must be NULL.</para></param>
		/// <param name="riid">A value that specifies the interface identifier (IID) of the interface pointer to return. This IID may be for the IStorage interface or the IPropertySetStorage interface.</param>
		/// <param name="ppObjectOpen">A pointer to an interface pointer variable that receives a pointer for an interface on the new storage object; contains NULL if operation failed.</param>
		/// <returns>This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error Handling Strategies and Handling Unknown Errors.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380328")]
		public static extern HRESULT StgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode,
			STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, [In] ref STGOPTIONS pStgOptions, IntPtr pSecurityDescriptor, [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>The StgIsStorageFile function indicates whether a particular disk file contains a storage object.</summary>
		/// <param name="pwcsName">Pointer to the null-terminated Unicode string name of the disk file to be examined. The pwcsName parameter is passed uninterpreted to the underlying file system.</param>
		/// <returns>
		/// <list>
		/// <item><term>S_OK</term><description>Indicates that the file contains a storage object.</description></item>
		/// <item><term>S_FALSE</term><description>Indicates that the file does not contain a storage object.</description></item>
		/// <item><term>STG_E_FILENOTFOUND</term><description>Indicates that the file was not found.</description></item>
		/// </list>
		/// <para>StgIsStorageFile function can also return any file system errors or system errors wrapped in an HRESULT. See Error Handling Strategies and Handling Unknown Errors</para></returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380334")]
		public static extern HRESULT StgIsStorageFile([MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

		/// <summary>The StgOpenStorage function opens an existing root storage object in the file system. Use this function to open compound files. Do not use it to open directories, files, or summary catalogs. Nested storage objects can only be opened using their parent IStorage::OpenStorage method.
		/// <note type="note">Applications should use the new function, StgOpenStorageEx, instead of StgOpenStorage, to take advantage of the enhanced and Windows Structured Storage features. This function, StgOpenStorage, still exists for compatibility with applications running on Windows 2000.</note></summary>
		/// <param name="pwcsName">A pointer to the path of the null-terminated Unicode string file that contains the storage object to open. This parameter is ignored if the pstgPriority parameter is not NULL.</param>
		/// <param name="pstgPriority">A pointer to the IStorage interface that should be NULL. If not NULL, this parameter is used as described below in the Remarks section. After StgOpenStorage returns, the storage object specified in pStgPriority may have been released and should no longer be used.</param>
		/// <param name="grfMode">Specifies the access mode to use to open the storage object.</param>
		/// <param name="snbExclude">If not NULL, pointer to a block of elements in the storage to be excluded as the storage object is opened. The exclusion occurs regardless of whether a snapshot copy happens on the open. Can be NULL.</param>
		/// <param name="reserved">Indicates reserved for future use; must be zero.</param>
		/// <param name="ppstgOpen">A pointer to a IStorage* pointer variable that receives the interface pointer to the opened storage.</param>
		/// <returns>The StgOpenStorage function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error Handling Strategies and Handling Unknown Errors.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380341")]
		public static extern HRESULT StgOpenStorage([MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
			IStorage pstgPriority, STGM grfMode, [In] SNB snbExclude, uint reserved, out IStorage ppstgOpen);

		/// <summary>STGs the open storage ex.</summary>
		/// <param name="pwcsName">A pointer to the path of the null-terminated Unicode string file that contains the storage object. This string size cannot exceed MAX_PATH characters.
		/// <para>Windows Server 2003 and Windows XP/2000:  Unlike the CreateFile function, the MAX_PATH limit cannot be exceeded by using the "\\?\" prefix.</para></param>
		/// <param name="grfMode">A value that specifies the access mode to open the new storage object. For more information, see STGM Constants. If the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion occurs when the commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is required when a file is overwritten or converted in transacted mode.
		/// <para>If the storage object is opened in direct mode(STGM_DIRECT) with access to either STGM_WRITE or STGM_READWRITE, the sharing mode must be STGM_SHARE_EXCLUSIVE unless the STGM_DIRECT_SWMR mode is specified.For more information, see the Remarks section.If the storage object is opened in direct mode with access to STGM_READ, the sharing mode must be either STGM_SHARE_EXCLUSIVE or STGM_SHARE_DENY_WRITE, unless STGM_PRIORITY or STGM_DIRECT_SWMR is specified.For more information, see the Remarks section.</para>
		/// <para>The mode in which a file is opened can affect implementation performance.For more information, see Compound File Implementation Limits.</para></param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">A value that depends upon the value of the stgfmt parameter. STGFMT_DOCFILE must be zero (0) or FILE_FLAG_NO_BUFFERING. For more information about this value, see CreateFile. If the sector size of the file, specified in pStgOptions, is not an integer multiple of the physical sector size of the underlying disk, then this operation will fail. All other values of stgfmt must be zero.</param>
		/// <param name="pStgOptions">A pointer to an STGOPTIONS structure that contains data about the storage object opened. The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. The usVersion member must be set before calling StgOpenStorageEx. For more information, see the STGOPTIONS structure.</param>
		/// <param name="reserved2">Reserved; must be zero.</param>
		/// <param name="riid">A value that specifies the GUID of the interface pointer to return. Can also be the header-specified value for IID_IStorage to obtain the IStorage interface or for IID_IPropertySetStorage to obtain the IPropertySetStorage interface.</param>
		/// <param name="ppObjectOpen">The address of an interface pointer variable that receives a pointer for an interface on the storage object opened; contains NULL if operation failed.</param>
		/// <returns>This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error Handling Strategies and Handling Unknown Errors.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380342")]
		public static extern HRESULT StgOpenStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt,
			FileFlagsAndAttributes grfAttrs, ref STGOPTIONS pStgOptions, IntPtr reserved2, [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>
		/// The STGOPTIONS structure specifies features of the storage object, such as sector size, in the StgCreateStorageEx and StgOpenStorageEx functions.
		/// </summary>
		[PInvokeData("Objbase.h", MSDNShortId = "aa380344")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct STGOPTIONS
		{
			/// <summary>Specifies the version of the STGOPTIONS structure. It is set to STGOPTIONS_VERSION.
			/// <note>When usVersion is set to 1, the ulSectorSize member can be set.This is useful when creating a large-sector documentation file.However, when usVersion is set to 1, the pwcsTemplateFile member cannot be used.</note>
			/// <para>In Windows 2000 and later:  STGOPTIONS_VERSION can be set to 1 for version 1.</para>
			/// <para>In Windows XP and later:  STGOPTIONS_VERSION can be set to 2 for version 2.</para>
			/// <para>For operating systems prior to Windows 2000:  STGOPTIONS_VERSION will be set to 0 for version 0.</para></summary>
			public ushort usVersion;
			/// <summary>Reserved for future use; must be zero.</summary>
			public ushort reserved;
			/// <summary>Specifies the sector size of the storage object. The default is 512 bytes.</summary>
			public uint ulSectorSize;
			/// <summary>Specifies the name of a file whose Encrypted File System (EFS) metadata will be transferred to a newly created Structured Storage file. This member is valid only when STGFMT_DOCFILE is used with StgCreateStorageEx.
			/// <para>In Windows XP and later:  The pwcsTemplateFile member is only valid if version 2 or later is specified in the usVersion member.</para></summary>
			public string pwcsTemplateFile;
		}
	}
}