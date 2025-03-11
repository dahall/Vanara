namespace Vanara.PInvoke;

public static partial class Crypt32
{
	/// <summary/>
	public const uint CERT_SYSTEM_STORE_LOCATION_MASK = 0x00FF0000;

	/// <summary>
	/// Enables CertOpenStore to open a store relative to a user-specified HKEY instead of one of the predefined HKEY constants. For
	/// example, HKEY_CURRENT_USER can be replaced with a user-specified HKEY. When CERT_SYSTEM_STORE_RELOCATE_FLAG is set, the pvPara
	/// parameter passed to CertOpenStore points to a CERT_SYSTEM_STORE_RELOCATE_PARA structure instead of pointing to the store name as
	/// a null-terminated Unicode or ASCII string.
	/// </summary>
	public const uint CERT_SYSTEM_STORE_RELOCATE_FLAG = 0x80000000;

	private const int CERT_SYSTEM_STORE_LOCATION_SHIFT = 16;

	/// <summary>
	/// The <c>CertEnumPhysicalStoreCallback</c> callback function formats and presents information on each physical store found by a
	/// call to CertEnumPhysicalStore.
	/// </summary>
	/// <param name="pvSystemStore"/>
	/// <param name="dwFlags">
	/// <para>Specifies the location of the system store. The following flag values are defined:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_SERVICE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_SERVICES</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_USERS</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE</term>
	/// </item>
	/// </list>
	/// <para>In addition, CERT_SYSTEM_STORE_RELOCATE_FLAG or CERT_PHYSICAL_STORE_PREDEFINED_ENUM_FLAG can be combined using a bitwise-</para>
	/// <para>OR</para>
	/// <para>
	/// operation with any of the high-word location flags. The CERT_PHYSICAL_STORE_PREDEFINED_ENUM_FLAG constant is set if the physical
	/// store is predefined rather than registered.
	/// </para>
	/// </param>
	/// <param name="pwszStoreName">Name of the physical store.</param>
	/// <param name="pStoreInfo">A pointer to a CERT_PHYSICAL_STORE_INFO structure containing information about the store.</param>
	/// <param name="pvReserved"/>
	/// <param name="pvArg"/>
	/// <returns>Returns <c>TRUE</c> if the function succeeds, <c>FALSE</c> if it fails.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pfn_cert_enum_physical_store PFN_CERT_ENUM_PHYSICAL_STORE
	// PfnCertEnumPhysicalStore; BOOL PfnCertEnumPhysicalStore( const void *pvSystemStore, DWORD dwFlags, LPCWSTR pwszStoreName,
	// PCERT_PHYSICAL_STORE_INFO pStoreInfo, void *pvReserved, void *pvArg ) {...}
	[PInvokeData("wincrypt.h", MSDNShortId = "0651730a-39f2-4598-a81c-d05e6d282e6c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool CertEnumPhysicalStoreCallback(IntPtr pvSystemStore, CertSystemStore dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pwszStoreName, in CERT_PHYSICAL_STORE_INFO pStoreInfo, IntPtr pvReserved, IntPtr pvArg);

	/// <summary>
	/// The <c>CertEnumSystemStoreCallback</c> callback function formats and presents information on each system store found by a call
	/// to CertEnumSystemStore.
	/// </summary>
	/// <param name="pvSystemStore">
	/// A pointer to information on the system store found by a call to CertEnumSystemStore. Where appropriate, this argument will
	/// contain a leading computer name or service name prefix.
	/// </param>
	/// <param name="dwFlags">Flag used to call for an alteration of the presentation.</param>
	/// <param name="pStoreInfo">A pointer to a CERT_SYSTEM_STORE_INFO structure that contains information about the store.</param>
	/// <param name="pvReserved">Reserved for future use.</param>
	/// <param name="pvArg">A pointer to information passed to the callback function in the pvArg passed to CertEnumSystemStore.</param>
	/// <returns>If the function succeeds, the function returns TRUE. To stop the enumeration, the function must return FALSE.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pfn_cert_enum_system_store PFN_CERT_ENUM_SYSTEM_STORE
	// PfnCertEnumSystemStore; BOOL PfnCertEnumSystemStore( const void *pvSystemStore, DWORD dwFlags, PCERT_SYSTEM_STORE_INFO
	// pStoreInfo, void *pvReserved, void *pvArg ) {...}
	[PInvokeData("wincrypt.h", MSDNShortId = "f070a9bd-be0b-49d0-9cab-a5d6f05d4e22")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool CertEnumSystemStoreCallback(IntPtr pvSystemStore, uint dwFlags, in CERT_SYSTEM_STORE_INFO pStoreInfo, [Optional] IntPtr pvReserved, [Optional] IntPtr pvArg);

	/// <summary>
	/// The <c>CertEnumSystemStoreLocationCallback</c> callback function formats and presents information on each system store location
	/// found by a call to CertEnumSystemStoreLocation.
	/// </summary>
	/// <param name="pwszStoreLocation">String that contains information on the store location found.</param>
	/// <param name="dwFlags">Flag used to call for an alteration of the presentation.</param>
	/// <param name="pvReserved"/>
	/// <param name="pvArg"/>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pfn_cert_enum_system_store_location
	// PFN_CERT_ENUM_SYSTEM_STORE_LOCATION PfnCertEnumSystemStoreLocation; BOOL PfnCertEnumSystemStoreLocation( LPCWSTR
	// pwszStoreLocation, DWORD dwFlags, void *pvReserved, void *pvArg ) {...}
	[PInvokeData("wincrypt.h", MSDNShortId = "a5f1badd-3e68-4e0f-9a42-1b1876c9cb56")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool CertEnumSystemStoreLocationCallback([MarshalAs(UnmanagedType.LPWStr)] string pwszStoreLocation, uint dwFlags, IntPtr pvReserved, IntPtr pvArg);

	/// <summary>
	/// The <c>PFN_CERT_CREATE_CONTEXT_SORT_FUNC</c> callback function is called for each sorted context entry when a context is
	/// created. This function pointer is passed in the <c>pfnSort</c> member of the CERT_CREATE_CONTEXT_PARA structure.
	/// </summary>
	/// <param name="cbTotalEncoded">The total number of bytes of the encoded entries.</param>
	/// <param name="cbRemainEncoded">The number of bytes remaining to be encoded.</param>
	/// <param name="cEntry">The current number of sorted entries.</param>
	/// <param name="pvSort"/>
	/// <returns>
	/// Return <c>TRUE</c> to continue the sort or <c>FALSE</c> to stop the sort. If <c>FALSE</c> is returned, CertCreateContext will
	/// fail and set the last error code to <c>ERROR_CANCELLED</c>.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pfn_cert_create_context_sort_func
	// PFN_CERT_CREATE_CONTEXT_SORT_FUNC PfnCertCreateContextSortFunc; BOOL PfnCertCreateContextSortFunc( DWORD cbTotalEncoded, DWORD
	// cbRemainEncoded, DWORD cEntry, void *pvSort ) {...}
	[PInvokeData("wincrypt.h", MSDNShortId = "5ad79970-d076-4e97-bf56-d6aad4b46eaa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PFN_CERT_CREATE_CONTEXT_SORT_FUNC(uint cbTotalEncoded, uint cbRemainEncoded, uint cEntry, IntPtr pvSort);

	/// <summary>Delegate to allocate memory.</summary>
	/// <param name="cbSize">Size of the memory to allocate.</param>
	/// <returns>A pointer to the allocated memory.</returns>
	[PInvokeData("wincrypt.h")]
	public delegate IntPtr PFN_CRYPT_ALLOC(SizeT cbSize);

	/// <summary>Delegate to free memory.</summary>
	/// <param name="pv">The pointer to the memory to free.</param>
	[PInvokeData("wincrypt.h")]
	public delegate void PFN_CRYPT_FREE(IntPtr pv);

	/// <summary>Flags for <see cref="CertCloseStore"/>.</summary>
	[Flags]
	public enum CertCloseStoreFlags
	{
		/// <summary>
		/// Forces the freeing of memory for all contexts associated with the store. This flag can be safely used only when the store is
		/// opened in a function and neither the store handle nor any of its contexts are passed to any called functions. For details,
		/// see Remarks.
		/// </summary>
		CERT_CLOSE_STORE_FORCE_FLAG = 0x00000001,

		/// <summary>
		/// Checks for nonfreed certificate, CRL, and CTL contexts. A returned error code indicates that one or more store elements is
		/// still in use. This flag should only be used as a diagnostic tool in the development of applications.
		/// </summary>
		CERT_CLOSE_STORE_CHECK_FLAG = 0x00000002
	}

	/// <summary>Flags for CertCreateContext.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "0911054b-a47a-4046-b121-a236fc4b018b")]
	[Flags]
	public enum CertCreateContextFlags : uint
	{
		/// <summary>The created context points directly to the content pointed to by pbEncoded instead of an allocated copy.</summary>
		CERT_CREATE_CONTEXT_NOCOPY_FLAG = 0x1,

		/// <summary>
		/// The function creates a context with sorted entries. Currently, this flag only applies to a CTL context.
		/// <para>
		/// For CTLs, the cCTLEntry member of the returned CTL_INFO structure is always zero. CertFindSubjectInSortedCTL and
		/// CertEnumSubjectInSortedCTL must be called to find or enumerate the CTL entries.
		/// </para>
		/// </summary>
		CERT_CREATE_CONTEXT_SORTED_FLAG = 0x2,

		/// <summary>
		/// By default, when a CTL context is created, a HCRYTPMSG handle to its SignedData message is created. This flag can be set to
		/// improve performance by not creating this handle. This flag can only be used when dwContextType is CERT_STORE_CTL_CONTEXT.
		/// </summary>
		CERT_CREATE_CONTEXT_NO_HCRYPTMSG_FLAG = 0x4,

		/// <summary>
		/// By default, when a CTL context is created, its entries are decoded. When this flag is set, the entries are not decoded and
		/// performance is improved. This flag can only be used when dwContextType is CERT_STORE_CTL_CONTEXT.
		/// </summary>
		CERT_CREATE_CONTEXT_NO_ENTRY_FLAG = 0x8
	}

	/// <summary>Physical Store Information flags.</summary>
	[Flags]
	public enum CertPhysicalStoreFlags : uint
	{
		/// <summary>Enables addition to a context to the store.</summary>
		CERT_PHYSICAL_STORE_ADD_ENABLE_FLAG = 0x1,

		/// <summary>
		/// Set by the CertRegisterPhysicalStore function. By default, all system stores located in the registry have an implicit
		/// SystemRegistry physical store that is opened. To disable the opening of this store, the SystemRegistry physical store that
		/// corresponds to the System store must be registered by setting CERT_PHYSICAL_STORE_OPEN_DISABLE_FLAG or by registering a
		/// physical store named ".Default" with CertRegisterPhysicalStore.
		/// </summary>
		CERT_PHYSICAL_STORE_OPEN_DISABLE_FLAG = 0x2,

		/// <summary>Disables remote opening of the physical store.</summary>
		CERT_PHYSICAL_STORE_REMOTE_OPEN_DISABLE_FLAG = 0x4,

		/// <summary>Places the string \\ComputerName in front of other provider types.</summary>
		CERT_PHYSICAL_STORE_INSERT_COMPUTER_NAME_ENABLE_FLAG = 0x8,
	}

	/// <summary>Specifies the action to take if the certificate, CRL, or CTL already exists in the store.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "2726cd34-51ba-4f68-9a3c-7cd505eb32a1")]
	public enum CertStoreAdd
	{
		/// <summary>
		/// If the certificate, CRL, or CTL is new, it is created and persisted to the store. The operation fails if an identical
		/// certificate, CRL, or CTL already exists in the store. The last error code is set to CRYPT_E_EXISTS.
		/// </summary>
		CERT_STORE_ADD_NEW = 1,

		/// <summary>
		/// If the certificate, CRL, or CTL is new, it is added to the store. If an identical certificate, CRL, or CTL already exists,
		/// the existing element is used. If ppvContext is not NULL, the existing context is duplicated. The function only adds
		/// properties that do not already exist. The SHA-1 and MD5 hash properties are not copied.
		/// </summary>
		CERT_STORE_ADD_USE_EXISTING = 2,

		/// <summary>
		/// If an identical certificate, CRL, or CTL already exists in the store, the existing certificate, CRL, or CTL context is
		/// deleted before creating and adding the new context.
		/// </summary>
		CERT_STORE_ADD_REPLACE_EXISTING = 3,

		/// <summary>
		/// No check is made to determine whether an identical certificate, CRL, or CTL already exists. A new element is always created.
		/// This can lead to duplicates in the store. To determine whether the element already exists in the store, call
		/// CertGetCRLFromStore or CertGetSubjectCertificateFromStore.
		/// </summary>
		CERT_STORE_ADD_ALWAYS = 4,

		/// <summary>
		/// If a matching certificate exists in the store, the existing context is deleted before creating and adding the new context.
		/// The new added context inherits properties from the existing certificate.
		/// </summary>
		CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES = 5,

		/// <summary>
		/// If a matching CRL or CTL or a link to a matching CRL or CTL exists, the function compares the NotBefore times on the CRL or
		/// CTL. If the existing CRL or CTL has a NotBefore time less than the NotBefore time on the new element, the old element or
		/// link is replaced just as with CERT_STORE_ADD_REPLACE_EXISTING. If the existing element has a NotBefore time greater than or
		/// equal to the NotBefore time on the element to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code.
		/// <para>
		/// If a matching CRL or CTL or a link to a matching CRL or CTL is not found in the store, a new element is added to the store.
		/// </para>
		/// </summary>
		CERT_STORE_ADD_NEWER = 6,

		/// <summary>
		/// The action is the same as for CERT_STORE_ADD_NEWER. However, if an older CRL or CTL is replaced, the properties of the older
		/// element are incorporated into the replacement.
		/// </summary>
		CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES = 7,
	}

	/// <summary>Specifics the contexts that can be added.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "2726cd34-51ba-4f68-9a3c-7cd505eb32a1")]
	public enum CertStoreContextFlags : uint
	{
		/// <summary>Adds any context.</summary>
		CERT_STORE_ALL_CONTEXT_FLAG = 0xFFFFFFFF,

		/// <summary>Adds only a certificate context.</summary>
		CERT_STORE_CERTIFICATE_CONTEXT_FLAG = 1 << CertStoreContextType.CERT_STORE_CERTIFICATE_CONTEXT,

		/// <summary>Adds only a CRL context.</summary>
		CERT_STORE_CRL_CONTEXT_FLAG = 1 << CertStoreContextType.CERT_STORE_CRL_CONTEXT,

		/// <summary>Adds only a CTL context.</summary>
		CERT_STORE_CTL_CONTEXT_FLAG = 1 << CertStoreContextType.CERT_STORE_CTL_CONTEXT,
	}

	/// <summary>The context type of the added serialized element.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "2726cd34-51ba-4f68-9a3c-7cd505eb32a1")]
	public enum CertStoreContextType : int
	{
		/// <summary>Certificates</summary>
		CERT_STORE_CERTIFICATE_CONTEXT = 1,

		/// <summary>CRLs</summary>
		CERT_STORE_CRL_CONTEXT = 2,

		/// <summary>CTLs</summary>
		CERT_STORE_CTL_CONTEXT = 3
	}

	/// <summary>Flags for <c>CertControlStore</c>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "04cd9349-50c1-44b4-b080-631a24a80d70")]
	[Flags]
	public enum CertStoreControlFlags
	{
		/// <summary>
		/// Forces the contents of the cache memory store to be copied to permanent storage even if the cache has not been changed.
		/// </summary>
		CERT_STORE_CTRL_COMMIT_FORCE_FLAG = 0x1,

		/// <summary>Inhibits the copying of the contents of the cache memory store to permanent storage even when the store is closed.</summary>
		CERT_STORE_CTRL_COMMIT_CLEAR_FLAG = 0x2,

		/// <summary>
		/// Inhibits a duplicate handle of the event HANDLE. If this flag is set, CertControlStore with CERT_STORE_CTRL_CANCEL_NOTIFY
		/// passed must be called for this event HANDLE before closing the hCertStore handle.
		/// </summary>
		CERT_STORE_CTRL_INHIBIT_DUPLICATE_HANDLE_FLAG = 0x1,
	}

	/// <summary>Control action to be taken by <c>CertControlStore</c>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "04cd9349-50c1-44b4-b080-631a24a80d70")]
	public enum CertStoreControlType
	{
		/// <summary>The cached store is resynchronized and made to match the persisted store.</summary>
		CERT_STORE_CTRL_RESYNC = 1,

		/// <summary>
		/// A signal is returned in the space pointed to by pvCtrlPara to indicate that the current contents of the cached store differ
		/// from the store's persisted state.
		/// </summary>
		CERT_STORE_CTRL_NOTIFY_CHANGE = 2,

		/// <summary>
		/// Any changes made to the cached store are copied to persisted storage. If no changes were made since the cached store was
		/// opened or since the last commit, the call is ignored. The call is also ignored if the store provider is a provider that
		/// automatically persists changes immediately.
		/// </summary>
		CERT_STORE_CTRL_COMMIT = 3,

		/// <summary>
		/// At the start of every enumeration or find store call, a check is made to determine whether a change has been made in the
		/// store. If the store has changed, a re-synchronization is done. This check is only done on first enumeration or find calls,
		/// when the pPrevContext is NULL. The pvCtrPara member is not used and must be set to NULL.
		/// </summary>
		CERT_STORE_CTRL_AUTO_RESYNC = 4,

		/// <summary>
		/// Cancels notification signaling of the event HANDLE passed in a previous CERT_STORE_CTRL_NOTIFY_CHANGE or
		/// CERT_STORE_CTRL_RESYNC. The pvCtrlPara parameter points to the event HANDLE to be canceled.
		/// </summary>
		CERT_STORE_CTRL_CANCEL_NOTIFY = 5,
	}

	/// <summary>Controls a variety of general characteristics of the certificate store opened.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "4edccbfe-c0a8-442b-b6b7-51ef598e7c90")]
	[Flags]
	public enum CertStoreFlags : uint
	{
		/// <summary>
		/// Use the thread's SE_BACKUP_NAME and SE_RESTORE_NAME privileges to open registry or file-based system stores. If the thread
		/// does not have these privileges, this function must fail with an access denied error.
		/// </summary>
		CERT_STORE_BACKUP_RESTORE_FLAG = 0x00000800,

		/// <summary>
		/// A new store is created if one did not exist. The function fails if the store already exists.
		/// <para>
		/// If neither CERT_STORE_OPEN_EXISTING_FLAG nor CERT_STORE_CREATE_NEW_FLAG is set, a store is opened if it exists or is created
		/// and opened if it did not already exist.
		/// </para>
		/// </summary>
		CERT_STORE_CREATE_NEW_FLAG = 0x00002000,

		/// <summary>
		/// Defer closing of the store's provider until all certificates, CRLs, or CTLs obtained from the store are no longer in use.
		/// The store is actually closed when the last certificate, CRL, or CTL obtained from the store is freed. Any changes made to
		/// properties of these certificates, CRLs, and CTLs, even after the call to CertCloseStore, are persisted.
		/// <para>
		/// If this flag is not set and certificates, CRLs, or CTLs obtained from the store are still in use, any changes to the
		/// properties of those certificates, CRLs, and CTLs will not be persisted.
		/// </para>
		/// <para>If this function is called with CERT_CLOSE_STORE_FORCE_FLAG, CERT_STORE_DEFER_CLOSE_UNTIL_LAST_FREE_FLAG is ignored.</para>
		/// <para>
		/// When this flag is set and a non-NULL hCryptProv parameter value is passed, that provider will continue to be used even after
		/// the call to this function.
		/// </para>
		/// </summary>
		CERT_STORE_DEFER_CLOSE_UNTIL_LAST_FREE_FLAG = 0x00000004,

		/// <summary>
		/// The store is deleted instead of being opened. This function returns NULL for both success and failure of the deletion. To
		/// determine the success of the deletion, call GetLastError, which returns zero if the store was deleted and a nonzero value if
		/// it was not deleted.
		/// </summary>
		CERT_STORE_DELETE_FLAG = 0x00000010,

		/// <summary>
		/// Normally, an enumeration of all certificates in the store will ignore any certificate with the CERT_ARCHIVED_PROP_ID
		/// property set. If this flag is set, an enumeration of the certificates in the store will contain all of the certificates in
		/// the store, including those that have the CERT_ARCHIVED_PROP_ID property.
		/// </summary>
		CERT_STORE_ENUM_ARCHIVED_FLAG = 0x00000200,

		/// <summary/>
		CERT_STORE_MANIFOLD_FLAG = 0x00000100,

		/// <summary>
		/// Open the store with the maximum set of allowed permissions. If this flag is specified, registry stores are first opened with
		/// write access and if that fails, they are reopened with read-only access.
		/// </summary>
		CERT_STORE_MAXIMUM_ALLOWED_FLAG = 0x00001000,

		/// <summary>
		/// This flag is not used when the hCryptProv parameter is NULL. This flag is only valid when a non-NULL CSP handle is passed as
		/// the hCryptProv parameter. Setting this flag prevents the automatic release of a nondefault CSP when the certificate store is closed.
		/// </summary>
		CERT_STORE_NO_CRYPT_RELEASE_FLAG = 0x00000001,

		/// <summary>Only open an existing store. If the store does not exist, the function fails.</summary>
		CERT_STORE_OPEN_EXISTING_FLAG = 0x00004000,

		/// <summary>
		/// Open the store in read-only mode. Any attempt to change the contents of the store will result in an error. When this flag is
		/// set and a registry based store provider is being used, the registry subkeys are opened by using RegOpenKey with
		/// KEY_READ_ACCESS. Otherwise, the registry subkeys are created by using RegCreateKey with KEY_ALL_ACCESS.
		/// </summary>
		CERT_STORE_READONLY_FLAG = 0x00008000,

		/// <summary>
		/// If this flag is supported, the provider sets the store's CERT_STORE_LOCALIZED_NAME_PROP_ID property. The localized name can
		/// be retrieved by calling the CertGetStoreProperty function with dwPropID set to CERT_STORE_LOCALIZED_NAME_PROP_ID. This flag
		/// is supported for providers of types CERT_STORE_PROV_FILENAME, CERT_STORE_PROV_SYSTEM, CERT_STORE_PROV_SYSTEM_REGISTRY, and CERT_STORE_PROV_PHYSICAL_W.
		/// </summary>
		CERT_STORE_SET_LOCALIZED_NAME_FLAG = 0x00000002,

		/// <summary>
		/// When opening a store multiple times, you can set this flag to ensure efficient memory usage by reusing the memory for the
		/// encoded parts of a certificate, CRL, or CTL context across the opened instances of the stores.
		/// </summary>
		CERT_STORE_SHARE_CONTEXT_FLAG = 0x00000080,

		/// <summary/>
		CERT_STORE_SHARE_STORE_FLAG = 0x00000040,

		/// <summary/>
		CERT_STORE_UNSAFE_PHYSICAL_FLAG = 0x00000020,

		/// <summary>
		/// Lists of key identifiers exist within CurrentUser and LocalMachine. These key identifiers have properties much like the
		/// properties of certificates. If the CERT_STORE_UPDATE_KEYID_FLAG is set, then for every key identifier in the store's
		/// location that has a CERT_KEY_PROV_INFO_PROP_ID property, that property is automatically updated from the key identifier
		/// property CERT_KEY_PROV_INFO_PROP_ID or the CERT_KEY_IDENTIFIER_PROP_ID of the certificate related to that key identifier.
		/// </summary>
		CERT_STORE_UPDATE_KEYID_FLAG = 0x00000400,

		/// <summary>
		/// When set, pvPara must contain a pointer to a CERT_SYSTEM_STORE_RELOCATE_PARA structure rather than a string. The structure
		/// indicates both the name of the store and its location in the registry.
		/// </summary>
		CERT_SYSTEM_STORE_RELOCATE_FLAG = 0x80000000,

		/// <summary>
		/// By default, when the CurrentUser "Root" store is opened, any SystemRegistry roots not on the protected root list are deleted
		/// from the cache before this function returns. When this flag is set, this default is overridden and all of the roots in the
		/// SystemRegistry are returned and no check of the protected root list is made.
		/// </summary>
		CERT_SYSTEM_STORE_UNPROTECTED_FLAG = 0x40000000,

		/// <summary/>
		CERT_SYSTEM_STORE_DEFER_READ_FLAG = 0x20000000,

		/// <summary>
		/// pvPara contains a handle to a registry key on a remote computer. To access a registry key on a remote computer, security
		/// permissions on the remote computer must be set to allow access. For more information, see Remarks.
		/// </summary>
		CERT_REGISTRY_STORE_REMOTE_FLAG = 0x10000,

		/// <summary>
		/// The CERT_STORE_PROV_REG provider saves certificates, CRLs, and CTLs in a single serialized store subkey instead of
		/// performing the default save operation. The default is that each certificate, CRL, or CTL is saved as a separate registry
		/// subkey under the appropriate subkey.
		/// <para>
		/// This flag is mainly used for stores downloaded from the group policy template (GPT), such as the CurrentUserGroupPolicy and
		/// LocalMachineGroupPolicy stores.
		/// </para>
		/// <para>
		/// When CERT_REGISTRY_STORE_SERIALIZED_FLAG is set, store additions, deletions, or property changes are not persisted until
		/// there is a call to either CertCloseStore or CertControlStore using CERT_STORE_CTRL_COMMIT.
		/// </para>
		/// </summary>
		CERT_REGISTRY_STORE_SERIALIZED_FLAG = 0x20000,

		/// <summary>
		/// Setting this flag commits any additions to the store or any changes made to properties of contexts in the store to the file
		/// store either when CertCloseStore is called or when CertControlStore is called with CERT_STORE_CONTROL_COMMIT.
		/// <para>
		/// CertOpenStore fails with E_INVALIDARG if both CERT_FILE_STORE_COMMIT_ENABLE and CERT_STORE_READONLY_FLAG are set in dwFlags.
		/// </para>
		/// </summary>
		CERT_FILE_STORE_COMMIT_ENABLE_FLAG = 0x10000,

		/// <summary>
		/// To provide integrity required by some applications, digitally sign all LDAP traffic to and from an LDAP server by using the
		/// Kerberos authentication protocol.
		/// </summary>
		CERT_LDAP_STORE_SIGN_FLAG = 0x10000,

		/// <summary>
		/// Performs an A-Record-only DNS lookup on the URL named in the pvPara parameter. This prevents false DNS queries from being
		/// generated when resolving URL host names. Use this flag when passing a host name as opposed to a domain name for the pvPara parameter.
		/// </summary>
		CERT_LDAP_STORE_AREC_EXCLUSIVE_FLAG = 0x20000,

		/// <summary>
		/// Use this flag to use an existing LDAP session. When this flag is specified, the pvPara parameter is the address of a
		/// CERT_LDAP_STORE_OPENED_PARA structure that contains information about the LDAP session to use.
		/// </summary>
		CERT_LDAP_STORE_OPENED_FLAG = 0x40000,

		/// <summary>
		/// Use this flag with the CERT_LDAP_STORE_OPENED_FLAG flag to cause the LDAP session to be unbound when the store is closed.
		/// The system will unbind the LDAP session by using the ldap_unbind function when the store is closed.
		/// </summary>
		CERT_LDAP_STORE_UNBIND_FLAG = 0x80000,

		/// <summary>Stores at the registry location <c>HKEY_CURRENT_USER\Software\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_CURRENT_USER = CertSystemStore.CERT_SYSTEM_STORE_CURRENT_USER,

		/// <summary>Stores at the registry location <c>HKEY_LOCAL_MACHINE\Software\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_LOCAL_MACHINE = CertSystemStore.CERT_SYSTEM_STORE_LOCAL_MACHINE,

		/// <summary>Stores at the registry location <c>HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Services\ServiceName\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_CURRENT_SERVICE = CertSystemStore.CERT_SYSTEM_STORE_CURRENT_SERVICE,

		/// <summary>
		/// Stores at the registry location
		/// <c>HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Services\ServiceName\SystemCertificates</c> and with keys starting
		/// with [ServiceName].
		/// </summary>
		CERT_SYSTEM_STORE_SERVICES = CertSystemStore.CERT_SYSTEM_STORE_SERVICES,

		/// <summary>
		/// Stores at the registry location <c>HKEY_USERS\UserName\Software\Microsoft\SystemCertificates</c> and with keys starting with [userid].
		/// </summary>
		CERT_SYSTEM_STORE_USERS = CertSystemStore.CERT_SYSTEM_STORE_USERS,

		/// <summary>Stores at the registry location <c>HKEY_CURRENT_USER\Software\Policy\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY = CertSystemStore.CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY,

		/// <summary>Stores at the registry location <c>HKEY_LOCAL_MACHINE\Software\Policy\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY = CertSystemStore.CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY,

		/// <summary>
		/// CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE contains certificates shared across domains in the enterprise and downloaded from
		/// the global enterprise directory. To synchronize the client's enterprise store, the enterprise directory is polled every
		/// eight hours and certificates are downloaded automatically in the background.
		/// </summary>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE = CertSystemStore.CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE,

		/// <summary/>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_WCOS = CertSystemStore.CERT_SYSTEM_STORE_LOCAL_MACHINE_WCOS,
	}

	/// <summary>Specifies how to save the certificate store.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "5cc818d7-b079-4962-aabc-fc512d4e92ac")]
	public enum CertStoreSaveAs : uint
	{
		/// <summary>
		/// The certificate store can be saved as a serialized store containing properties in addition to encoded certificates,
		/// certificate revocation lists (CRLs), and certificate trust lists (CTLs). The dwEncodingType parameter is ignored. <note>The
		/// CERT_KEY_CONTEXT_PROP_ID property and the related CERT_KEY_PROV_HANDLE_PROP_ID and CERT_KEY_SPEC_PROP_ID values are not
		/// saved to a serialized store.</note>
		/// </summary>
		CERT_STORE_SAVE_AS_STORE = 1,

		/// <summary>
		/// The certificate store can be saved as a PKCS #7 signed message that does not include additional properties. The
		/// dwEncodingType parameter specifies the message encoding type.
		/// </summary>
		CERT_STORE_SAVE_AS_PKCS7 = 2,

		/// <summary>
		/// The certificate store can be saved as a PKCS #12 signed message that does not include additional properties. The
		/// dwEncodingType parameter specifies the message encoding type.
		/// </summary>
		CERT_STORE_SAVE_AS_PKCS12 = 3,
	}

	/// <summary>Specifies where and how to save the certificate store.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "5cc818d7-b079-4962-aabc-fc512d4e92ac")]
	public enum CertStoreSaveTo : uint
	{
		/// <summary>
		/// The function saves the certificate store to a file. The pvSaveToPara parameter contains a handle to a file previously
		/// obtained by using the CreateFile function. The file must be opened with write permission. After a successful save operation,
		/// the file pointer is positioned after the last write operation.
		/// </summary>
		CERT_STORE_SAVE_TO_FILE = 1,

		/// <summary>
		/// The function saves the certificate store to a memory BLOB. The pvSaveToPara parameter contains a pointer to a CERT_BLOB
		/// structure. Before use, the CERT_BLOB's pbData and cbData members must be initialized. Upon return, cbData is updated with
		/// the actual length. For a length-only calculation, pbData must be set to NULL. If pbData is non-NULL and cbData is not large
		/// enough, the function returns zero with a last error code of ERROR_MORE_DATA.
		/// </summary>
		CERT_STORE_SAVE_TO_MEMORY = 2,

		/// <summary>
		/// The function saves the certificate store to a file. The pvSaveToPara parameter contains a pointer to a null-terminated ANSI
		/// string that contains the path and file name of the file to save to. The function opens the file, saves to it, and closes it.
		/// </summary>
		CERT_STORE_SAVE_TO_FILENAME_A = 3,

		/// <summary>
		/// The function saves the certificate store to a file. The pvSaveToPara parameter contains a pointer to a null-terminated
		/// Unicode string that contains the path and file name of the file to save to. The function opens the file, saves to it, and
		/// closes it.
		/// </summary>
		CERT_STORE_SAVE_TO_FILENAME_W = 4,

		/// <summary>
		/// The function saves the certificate store to a file. The pvSaveToPara parameter contains a pointer to a null-terminated
		/// Unicode string that contains the path and file name of the file to save to. The function opens the file, saves to it, and
		/// closes it.
		/// </summary>
		CERT_STORE_SAVE_TO_FILENAME = CERT_STORE_SAVE_TO_FILENAME_W
	}

	/// <summary>
	/// A system store is a collection that consists of one or more physical sibling stores. For each system store, there are predefined
	/// physical sibling stores. After opening a system store such as MY at CERT_SYSTEM_STORE_CURRENT_USER, the store provider calls
	/// CertOpenStore to open each of the physical stores in the system store collection. In the open process, each of these physical
	/// stores is added to the system store collection using CertAddStoreToCollection. All certificates in those physical stores are
	/// available through the logical system store collection.
	/// </summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "fd9cb23b-e4a3-41cb-8f0a-30f4e813c6ac")]
	public enum CertSystemStore : uint
	{
		/// <summary>Stores at the registry location <c>HKEY_CURRENT_USER\Software\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_CURRENT_USER = CertSystemStoreId.CERT_SYSTEM_STORE_CURRENT_USER_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,

		/// <summary>Stores at the registry location <c>HKEY_LOCAL_MACHINE\Software\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_LOCAL_MACHINE = CertSystemStoreId.CERT_SYSTEM_STORE_LOCAL_MACHINE_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,

		/// <summary>Stores at the registry location <c>HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Services\ServiceName\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_CURRENT_SERVICE = CertSystemStoreId.CERT_SYSTEM_STORE_CURRENT_SERVICE_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,

		/// <summary>
		/// Stores at the registry location
		/// <c>HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Services\ServiceName\SystemCertificates</c> and with keys starting
		/// with [ServiceName].
		/// </summary>
		CERT_SYSTEM_STORE_SERVICES = CertSystemStoreId.CERT_SYSTEM_STORE_SERVICES_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,

		/// <summary>
		/// Stores at the registry location <c>HKEY_USERS\UserName\Software\Microsoft\SystemCertificates</c> and with keys starting with [userid].
		/// </summary>
		CERT_SYSTEM_STORE_USERS = CertSystemStoreId.CERT_SYSTEM_STORE_USERS_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,

		/// <summary>Stores at the registry location <c>HKEY_CURRENT_USER\Software\Policy\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY = CertSystemStoreId.CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,

		/// <summary>Stores at the registry location <c>HKEY_LOCAL_MACHINE\Software\Policy\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY = CertSystemStoreId.CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,

		/// <summary>
		/// CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE contains certificates shared across domains in the enterprise and downloaded from
		/// the global enterprise directory. To synchronize the client's enterprise store, the enterprise directory is polled every
		/// eight hours and certificates are downloaded automatically in the background.
		/// </summary>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE = CertSystemStoreId.CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,

		/// <summary/>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_WCOS = CertSystemStoreId.CERT_SYSTEM_STORE_LOCAL_MACHINE_WCOS_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
	}

	/// <summary>Values used by <see cref="CertSystemStore"/>.</summary>
	public enum CertSystemStoreId : uint
	{
		/// <summary>Stores at the registry location <c>HKEY_CURRENT_USER\Software\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_CURRENT_USER_ID = 1,

		/// <summary>Stores at the registry location <c>HKEY_LOCAL_MACHINE\Software\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_ID = 2,

		/// <summary>Stores at the registry location <c>HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Services\ServiceName\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_CURRENT_SERVICE_ID = 4,

		/// <summary>
		/// Stores at the registry location
		/// <c>HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Services\ServiceName\SystemCertificates</c> and with keys starting
		/// with [ServiceName].
		/// </summary>
		CERT_SYSTEM_STORE_SERVICES_ID = 5,

		/// <summary>
		/// Stores at the registry location <c>HKEY_USERS\UserName\Software\Microsoft\SystemCertificates</c> and with keys starting with [userid].
		/// </summary>
		CERT_SYSTEM_STORE_USERS_ID = 6,

		/// <summary>Stores at the registry location <c>HKEY_CURRENT_USER\Software\Policy\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY_ID = 7,

		/// <summary>Stores at the registry location <c>HKEY_LOCAL_MACHINE\Software\Policy\Microsoft\SystemCertificates</c>.</summary>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY_ID = 8,

		/// <summary>
		/// CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE contains certificates shared across domains in the enterprise and downloaded from
		/// the global enterprise directory. To synchronize the client's enterprise store, the enterprise directory is polled every
		/// eight hours and certificates are downloaded automatically in the background.
		/// </summary>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE_ID = 9,

		/// <summary/>
		CERT_SYSTEM_STORE_LOCAL_MACHINE_WCOS_ID = 10,
	}

	/// <summary>Specifies the type of subject to be searched for in the CTL.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "e0c81531-e649-45bb-bafe-bced00c7b16a")]
	public enum CtlCertSubject
	{
		/// <summary>Default subject type.</summary>
		CTL_DEFAULT_SUBJECT_TYPE = 0,

		/// <term>
		/// pvSubject data type: Pointer to a CERT_CONTEXT structure. The CTL's SubjectAlgorithm is examined to determine the
		/// representation of the subject's identity. Initially, only SHA1 and MD5 hashes are supported as values for SubjectAlgorithm.
		/// The appropriate hash property is obtained from the CERT_CONTEXT structure.
		/// </term>
		CTL_ANY_SUBJECT_TYPE = 1,

		/// <term>
		/// pvSubject data type: Pointer to a CTL_ANY_SUBJECT_INFO structure. The SubjectAlgorithm member of this structure must match
		/// the algorithm type of the CTL, and the SubjectIdentifier member must match one of the CTL entries.
		/// </term>
		CTL_CERT_SUBJECT_TYPE = 2,
	}

	/// <summary>
	/// The <c>CertAddSerializedElementToStore</c> function adds a serialized certificate, certificate revocation list (CRL), or
	/// certificate trust list (CTL) element to the store. The serialized element contains the encoded certificate, CRL, or CTL and its
	/// extended properties. Extended properties are associated with a certificate and are not part of a certificate as issued by a
	/// certification authority. Extended properties are not available on a certificate when it is used on a non-Microsoft platform.
	/// </summary>
	/// <param name="hCertStore">
	/// The handle of a certificate store where the created certificate will be stored. If hCertStore is <c>NULL</c>, the function
	/// creates a copy of a certificate, CRL, or CTL context with its extended properties, but the certificate, CRL, or CTL is not
	/// persisted in any store.
	/// </param>
	/// <param name="pbElement">
	/// A pointer to a buffer that contains the certificate, CRL, or CTL information to be serialized and added to the certificate store.
	/// </param>
	/// <param name="cbElement">The size, in bytes, of the pbElement buffer.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action to take if the certificate, CRL, or CTL already exists in the store. Currently defined disposition values
	/// are shown in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>
	/// If the certificate, CRL, or CTL is new, it is created and persisted to the store. The operation fails if an identical
	/// certificate, CRL, or CTL already exists in the store. The last error code is set to CRYPT_E_EXISTS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If the certificate, CRL, or CTL is new, it is added to the store. If an identical certificate, CRL, or CTL already exists, the
	/// existing element is used. If ppvContext is not NULL, the existing context is duplicated. The function only adds properties that
	/// do not already exist. The SHA-1 and MD5 hash properties are not copied.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If an identical certificate, CRL, or CTL already exists in the store, the existing certificate, CRL, or CTL context is deleted
	/// before creating and adding the new context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_ALWAYS</term>
	/// <term>
	/// No check is made to determine whether an identical certificate, CRL, or CTL already exists. A new element is always created.
	/// This can lead to duplicates in the store. To determine whether the element already exists in the store, call CertGetCRLFromStore
	/// or CertGetSubjectCertificateFromStore.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER</term>
	/// <term>
	/// If a matching CRL or CTL or a link to a matching CRL or CTL exists, the function compares the NotBefore times on the CRL or CTL.
	/// If the existing CRL or CTL has a NotBefore time less than the NotBefore time on the new element, the old element or link is
	/// replaced just as with CERT_STORE_ADD_REPLACE_EXISTING. If the existing element has a NotBefore time greater than or equal to the
	/// NotBefore time on the element to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching
	/// CRL or CTL or a link to a matching CRL or CTL is not found in the store, a new element is added to the store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
	/// <term>
	/// The action is the same as for CERT_STORE_ADD_NEWER. However, if an older CRL or CTL is replaced, the properties of the older
	/// element are incorporated into the replacement.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching certificate exists in the store, the existing context is deleted before creating and adding the new context. The
	/// new added context inherits properties from the existing certificate.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="dwContextTypeFlags">
	/// <para>
	/// Specifics the contexts that can be added. For example, to add either a certificate, CRL, or CTL, set dwContextTypeFlags to
	/// <c>CERT_STORE_CERTIFICATE_CONTEXT_FLAG</c> or <c>CERT_STORE_CRL_CONTEXT_FLAG</c>.
	/// </para>
	/// <para>Currently defined context type flags are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ALL_CONTEXT_FLAG</term>
	/// <term>Adds any context.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CERTIFICATE_CONTEXT_FLAG</term>
	/// <term>Adds only a certificate context.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CRL_CONTEXT_FLAG</term>
	/// <term>Adds only a CRL context.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTL_CONTEXT_FLAG</term>
	/// <term>Adds only a CTL context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwContextType">
	/// <para>
	/// A pointer to the context type of the added serialized element. This is an optional parameter and can be <c>NULL</c>, which
	/// indicates that the calling application does not require the context type.
	/// </para>
	/// <para>Currently defined context types are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_CERTIFICATE_CONTEXT</term>
	/// <term>Certificates</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CRL_CONTEXT</term>
	/// <term>CRLs</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTL_CONTEXT</term>
	/// <term>CTLs</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppvContext">
	/// <para>
	/// A pointer to a pointer to the decoded certificate, CRL, or CTL context. This is an optional parameter and can be <c>NULL</c>,
	/// which indicates that the calling application does not require the context of the added or existing certificate, CRL, or CTL.
	/// </para>
	/// <para>
	/// If ppvContext is not <c>NULL</c>, it must be the address of a pointer to a CERT_CONTEXT, CRL_CONTEXT, or CTL_CONTEXT. When the
	/// application is finished with the context, the context must be freed by using CertFreeCertificateContext for a certificate,
	/// CertFreeCRLContext for a CRL, or CertFreeCTLContext for a CTL.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>If the dwAddDisposition parameter is set to CERT_STORE_ADD_NEW, the certificate, CRL, or CTL already exists in the store.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>A disposition value that is not valid was specified in the dwAddDisposition parameter.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddserializedelementtostore BOOL
	// CertAddSerializedElementToStore( HCERTSTORE hCertStore, const BYTE *pbElement, DWORD cbElement, DWORD dwAddDisposition, DWORD
	// dwFlags, DWORD dwContextTypeFlags, DWORD *pdwContextType, const void **ppvContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2726cd34-51ba-4f68-9a3c-7cd505eb32a1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddSerializedElementToStore([Optional] HCERTSTORE hCertStore, [In] IntPtr pbElement, uint cbElement,
		CertStoreAdd dwAddDisposition, [Optional] uint dwFlags, CertStoreContextFlags dwContextTypeFlags, out CertStoreContextType pdwContextType, out IntPtr ppvContext);

	/// <summary>
	/// The <c>CertAddSerializedElementToStore</c> function adds a serialized certificate, certificate revocation list (CRL), or
	/// certificate trust list (CTL) element to the store. The serialized element contains the encoded certificate, CRL, or CTL and its
	/// extended properties. Extended properties are associated with a certificate and are not part of a certificate as issued by a
	/// certification authority. Extended properties are not available on a certificate when it is used on a non-Microsoft platform.
	/// </summary>
	/// <param name="hCertStore">
	/// The handle of a certificate store where the created certificate will be stored. If hCertStore is <c>NULL</c>, the function
	/// creates a copy of a certificate, CRL, or CTL context with its extended properties, but the certificate, CRL, or CTL is not
	/// persisted in any store.
	/// </param>
	/// <param name="pbElement">
	/// A pointer to a buffer that contains the certificate, CRL, or CTL information to be serialized and added to the certificate store.
	/// </param>
	/// <param name="cbElement">The size, in bytes, of the pbElement buffer.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action to take if the certificate, CRL, or CTL already exists in the store. Currently defined disposition values
	/// are shown in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>
	/// If the certificate, CRL, or CTL is new, it is created and persisted to the store. The operation fails if an identical
	/// certificate, CRL, or CTL already exists in the store. The last error code is set to CRYPT_E_EXISTS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If the certificate, CRL, or CTL is new, it is added to the store. If an identical certificate, CRL, or CTL already exists, the
	/// existing element is used. If ppvContext is not NULL, the existing context is duplicated. The function only adds properties that
	/// do not already exist. The SHA-1 and MD5 hash properties are not copied.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If an identical certificate, CRL, or CTL already exists in the store, the existing certificate, CRL, or CTL context is deleted
	/// before creating and adding the new context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_ALWAYS</term>
	/// <term>
	/// No check is made to determine whether an identical certificate, CRL, or CTL already exists. A new element is always created.
	/// This can lead to duplicates in the store. To determine whether the element already exists in the store, call CertGetCRLFromStore
	/// or CertGetSubjectCertificateFromStore.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER</term>
	/// <term>
	/// If a matching CRL or CTL or a link to a matching CRL or CTL exists, the function compares the NotBefore times on the CRL or CTL.
	/// If the existing CRL or CTL has a NotBefore time less than the NotBefore time on the new element, the old element or link is
	/// replaced just as with CERT_STORE_ADD_REPLACE_EXISTING. If the existing element has a NotBefore time greater than or equal to the
	/// NotBefore time on the element to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching
	/// CRL or CTL or a link to a matching CRL or CTL is not found in the store, a new element is added to the store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
	/// <term>
	/// The action is the same as for CERT_STORE_ADD_NEWER. However, if an older CRL or CTL is replaced, the properties of the older
	/// element are incorporated into the replacement.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching certificate exists in the store, the existing context is deleted before creating and adding the new context. The
	/// new added context inherits properties from the existing certificate.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="dwContextTypeFlags">
	/// <para>
	/// Specifics the contexts that can be added. For example, to add either a certificate, CRL, or CTL, set dwContextTypeFlags to
	/// <c>CERT_STORE_CERTIFICATE_CONTEXT_FLAG</c> or <c>CERT_STORE_CRL_CONTEXT_FLAG</c>.
	/// </para>
	/// <para>Currently defined context type flags are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ALL_CONTEXT_FLAG</term>
	/// <term>Adds any context.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CERTIFICATE_CONTEXT_FLAG</term>
	/// <term>Adds only a certificate context.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CRL_CONTEXT_FLAG</term>
	/// <term>Adds only a CRL context.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTL_CONTEXT_FLAG</term>
	/// <term>Adds only a CTL context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwContextType">
	/// <para>
	/// A pointer to the context type of the added serialized element. This is an optional parameter and can be <c>NULL</c>, which
	/// indicates that the calling application does not require the context type.
	/// </para>
	/// <para>Currently defined context types are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_CERTIFICATE_CONTEXT</term>
	/// <term>Certificates</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CRL_CONTEXT</term>
	/// <term>CRLs</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTL_CONTEXT</term>
	/// <term>CTLs</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppvContext">
	/// <para>
	/// A pointer to a pointer to the decoded certificate, CRL, or CTL context. This is an optional parameter and can be <c>NULL</c>,
	/// which indicates that the calling application does not require the context of the added or existing certificate, CRL, or CTL.
	/// </para>
	/// <para>
	/// If ppvContext is not <c>NULL</c>, it must be the address of a pointer to a CERT_CONTEXT, CRL_CONTEXT, or CTL_CONTEXT. When the
	/// application is finished with the context, the context must be freed by using CertFreeCertificateContext for a certificate,
	/// CertFreeCRLContext for a CRL, or CertFreeCTLContext for a CTL.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>If the dwAddDisposition parameter is set to CERT_STORE_ADD_NEW, the certificate, CRL, or CTL already exists in the store.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>A disposition value that is not valid was specified in the dwAddDisposition parameter.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddserializedelementtostore BOOL
	// CertAddSerializedElementToStore( HCERTSTORE hCertStore, const BYTE *pbElement, DWORD cbElement, DWORD dwAddDisposition, DWORD
	// dwFlags, DWORD dwContextTypeFlags, DWORD *pdwContextType, const void **ppvContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2726cd34-51ba-4f68-9a3c-7cd505eb32a1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddSerializedElementToStore([Optional] HCERTSTORE hCertStore, [In] IntPtr pbElement, uint cbElement,
		CertStoreAdd dwAddDisposition, [Optional] uint dwFlags, CertStoreContextFlags dwContextTypeFlags, IntPtr pdwContextType = default, IntPtr ppvContext = default);

	/// <summary>
	/// The <c>CertAddStoreToCollection</c> function adds a sibling certificate store to a collection certificate store. When a
	/// certificate store has been added to a collection store, all of the certificates, certificate revocation lists (CRLs), and
	/// certificate trust lists (CTLs) in the store that has been added to the collection store can be retrieved by using find or
	/// enumerate function calls that use the collection store.
	/// </summary>
	/// <param name="hCollectionStore">Handle of a certificate store.</param>
	/// <param name="hSiblingStore">Handle of a sibling store to be added to the collection store. For more information, see Remarks.</param>
	/// <param name="dwUpdateFlags">
	/// Indicates whether certificates, CRLs, and CTLs can be added to the new sibling store member of the collection store. To enable
	/// addition, set dwUpdateFlag to CERT_PHYSICAL_STORE_ADD_ENABLE_FLAG. To disable additions, set dwUpdateFlag to zero.
	/// </param>
	/// <param name="dwPriority">
	/// Sets a priority level of the new store in the collection, with zero being the lowest priority. If zero is passed for this
	/// parameter, the specified store is appended as the last store in the collection. The priority levels of the stores in a
	/// collection determine the order in which the stores are enumerated, and the search order of the stores when attempting to
	/// retrieve a certificate, CRL, or CTL. Priority levels also determine to which store of a collection a new certificate, CRL, or
	/// CTL is added. For more information, see Remarks.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero and a new store is added to the collection of stores.</para>
	/// <para>If the function fails, it returns zero and the store was not added.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A collection store has the same <c>HCERTSTORE</c> handle as a single store; thus, almost all functions that apply to any
	/// certificate store also apply to any collection store. Enumeration and search processes span all of the stores in a collection
	/// store; however, functions such as CertAddCertificateLinkToStore that add links to stores cannot be used with collection stores.
	/// </para>
	/// <para>
	/// When a certificate, CRL, or CTL is added to a collection store, the list of sibling stores in the collection is searched in
	/// priority order to find the first store that allows adding. Adding is enabled if CERT_PHYSICAL_STORE_ADD_ENABLE_FLAG was set in
	/// the <c>CertAddStoreToCollection</c> call. With any function that adds elements to a store, if a store that allows adding does
	/// not return success, the addition function continues on to the next store without providing notification.
	/// </para>
	/// <para>
	/// When a collection store and its sibling stores are closed with CertCloseStore using CERT_CLOSE_STORE_FORCE_FLAG, the collection
	/// store must be closed before its sibling stores. If CERT_CLOSE_STORE_FORCE_FLAG is not used, the stores can be closed in any order.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows adding a sibling certificate store to a collection certificate store. For a full example including
	/// the complete context for this example, see Example C Program: Collection and Sibling Certificate Store Operations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddstoretocollection BOOL CertAddStoreToCollection(
	// HCERTSTORE hCollectionStore, HCERTSTORE hSiblingStore, DWORD dwUpdateFlags, DWORD dwPriority );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ea848d74-c3ec-4166-90ea-121b33f7f318")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddStoreToCollection(HCERTSTORE hCollectionStore, HCERTSTORE hSiblingStore, CertPhysicalStoreFlags dwUpdateFlags, uint dwPriority);

	/// <summary>
	/// The <c>CertCloseStore</c> function closes a certificate store handle and reduces the reference count on the store. There needs
	/// to be a corresponding call to <c>CertCloseStore</c> for each successful call to the CertOpenStore or CertDuplicateStore functions.
	/// </summary>
	/// <param name="hCertStore">Handle of the certificate store to be closed.</param>
	/// <param name="dwFlags">
	/// <para>
	/// Typically, this parameter uses the default value zero. The default is to close the store with memory remaining allocated for
	/// contexts that have not been freed. In this case, no check is made to determine whether memory for contexts remains allocated.
	/// </para>
	/// <para>
	/// Set flags can force the freeing of memory for all of a store's certificate, certificate revocation list (CRL), and certificate
	/// trust list (CTL) contexts when the store is closed. Flags can also be set that check whether all of the store's certificate,
	/// CRL, and CTL contexts have been freed. The following values are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CLOSE_STORE_CHECK_FLAG</term>
	/// <term>
	/// Checks for nonfreed certificate, CRL, and CTL contexts. A returned error code indicates that one or more store elements is still
	/// in use. This flag should only be used as a diagnostic tool in the development of applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CLOSE_STORE_FORCE_FLAG</term>
	/// <term>
	/// Forces the freeing of memory for all contexts associated with the store. This flag can be safely used only when the store is
	/// opened in a function and neither the store handle nor any of its contexts are passed to any called functions. For details, see Remarks.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>
	/// If CERT_CLOSE_STORE_CHECK_FLAG is not set or if it is set and all contexts associated with the store have been freed, the return
	/// value is <c>TRUE</c>.
	/// </para>
	/// <para>
	/// If CERT_CLOSE_STORE_CHECK_FLAG is set and memory for one or more contexts associated with the store remains allocated, the
	/// return value is <c>FALSE</c>. The store is always closed even when the function returns <c>FALSE</c>. For details, see Remarks.
	/// </para>
	/// <para>
	/// GetLastError is set to CRYPT_E_PENDING_CLOSE if memory for contexts associated with the store remains allocated. Any existing
	/// value returned by <c>GetLastError</c> is preserved unless CERT_CLOSE_STORE_CHECK_FLAG is set.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// While a certificate store is open, contexts from that store can be retrieved or duplicated. When a context is retrieved or
	/// duplicated, its reference count is incremented. When a context is freed by passing it to a search or enumeration function as a
	/// previous context or by using CertFreeCertificateContext, CertFreeCRLContext, or CertFreeCTLContext, its reference count is
	/// decremented. When a context's reference count reaches zero, memory allocated for that context is automatically freed. When the
	/// memory allocated for a context has been freed, any pointers to that context become not valid.
	/// </para>
	/// <para>
	/// By default, memory used to store contexts with reference count greater than zero is not freed when a certificate store is
	/// closed. References to those contexts remain valid; however, this can cause memory leaks. Also, any changes made to the
	/// properties of a context after the store has been closed are not persisted.
	/// </para>
	/// <para>
	/// To force the freeing of memory for all contexts associated with a store, set CERT_CLOSE_STORE_FORCE_FLAG. With this flag set,
	/// memory for all contexts associated with the store is freed and all pointers to certificate, CRL, or CTL contexts associated with
	/// the store become not valid. This flag should only be set when the store is opened in a function and neither the store handle nor
	/// any of its contexts were ever passed to any called functions.
	/// </para>
	/// <para>
	/// The status of reference counts on contexts associated with a store can be checked when the store is closed by using
	/// CERT_CLOSE_STORE_CHECK_FLAG. When this flag is set, and all certificate, CRL, or CTL contexts have not been released, the
	/// function returns <c>FALSE</c> and GetLastError returns CRYPT_E_PENDING_CLOSE. Note that the store is still closed when
	/// <c>FALSE</c> is returned and the memory for any active contexts is not freed.
	/// </para>
	/// <para>If CERT_STORE_NO_CRYPT_RELEASE_FLAG was not set when the store was opened, closing a store releases its CSP handle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certclosestore BOOL CertCloseStore( HCERTSTORE
	// hCertStore, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a93fdd65-359e-4046-910d-347c3af01280")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertCloseStore(HCERTSTORE hCertStore, CertCloseStoreFlags dwFlags);

	/// <summary>
	/// <para>
	/// The <c>CertControlStore</c> function allows an application to be notified when there is a difference between the contents of a
	/// cached store in use and the contents of that store as it is persisted to storage. Differences can occur as another process makes
	/// a change that affects the store as it is persisted.
	/// </para>
	/// <para>
	/// The <c>CertControlStore</c> function can be used to synchronize a cached store, if necessary, and provides a means to commit
	/// changes made in the cached store to persisted storage.
	/// </para>
	/// </summary>
	/// <param name="hCertStore">Handle of the certificate store.</param>
	/// <param name="dwFlags">
	/// <para>If the dwCtrlType parameter is set to CERT_STORE_CTRL_COMMIT, this parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_CTRL_COMMIT_FORCE_FLAG</term>
	/// <term>Forces the contents of the cache memory store to be copied to permanent storage even if the cache has not been changed.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTRL_COMMIT_CLEAR_FLAG</term>
	/// <term>Inhibits the copying of the contents of the cache memory store to permanent storage even when the store is closed.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTRL_INHIBIT_DUPLICATE_HANDLE_FLAG</term>
	/// <term>
	/// Inhibits a duplicate handle of the event HANDLE. If this flag is set, CertControlStore with CERT_STORE_CTRL_CANCEL_NOTIFY passed
	/// must be called for this event HANDLE before closing the hCertStore handle.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If dwCtrlType is set to CERT_STORE_CTRL_NOTIFY_CHANGE or CERT_STORE_CTRL_RESYNC, the dwFlags parameter is not used and must be
	/// set to zero.
	/// </para>
	/// </param>
	/// <param name="dwCtrlType">
	/// <para>
	/// Control action to be taken by <c>CertControlStore</c>. The interpretations of pvCtrlPara and dwFlags depend on the value of
	/// dwCtrlType. Currently, the following actions are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_CTRL_RESYNC</term>
	/// <term>The cached store is resynchronized and made to match the persisted store.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTRL_NOTIFY_CHANGE</term>
	/// <term>
	/// A signal is returned in the space pointed to by pvCtrlPara to indicate that the current contents of the cached store differ from
	/// the store's persisted state.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTRL_COMMIT</term>
	/// <term>
	/// Any changes made to the cached store are copied to persisted storage. If no changes were made since the cached store was opened
	/// or since the last commit, the call is ignored. The call is also ignored if the store provider is a provider that automatically
	/// persists changes immediately.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTRL_AUTO_RESYNC</term>
	/// <term>
	/// At the start of every enumeration or find store call, a check is made to determine whether a change has been made in the store.
	/// If the store has changed, a re-synchronization is done. This check is only done on first enumeration or find calls, when the
	/// pPrevContext is NULL. The pvCtrPara member is not used and must be set to NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTRL_CANCEL_NOTIFY</term>
	/// <term>
	/// Cancels notification signaling of the event HANDLE passed in a previous CERT_STORE_CTRL_NOTIFY_CHANGE or CERT_STORE_CTRL_RESYNC.
	/// The pvCtrlPara parameter points to the event HANDLE to be canceled.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvCtrlPara">
	/// <para>
	/// If dwCtrlType is CERT_STORE_NOTIFY_CHANGE, pvCtrlPara is set to the address of a handle where the system signals the
	/// notification change event when a change from the persisted state of the store is detected. The handle must be initialized with a
	/// call to the function CreateEvent. The pvCtrlPara parameter can be set to <c>NULL</c> for registry-based stores. If pvCtrlPara is
	/// <c>NULL</c>, an internal notification change event is created and registered to be signaled. Using the internal notification
	/// change event allows resynchronization operations only if the store was changed.
	/// </para>
	/// <para>
	/// If dwCtrlType is CERT_STORE_CTRL_RESYNC, set pvCtrlPara to the address of the event handle to be signaled on the next change in
	/// the persisted store. Typically, this address is the address of the event handle passed with CERT_STORE_CTRL_NOTIFY_CHANGE during
	/// initialization. The event handle passed is rearmed. If pvCtrlPara is set to <c>NULL</c>, no event is rearmed.
	/// </para>
	/// <para>If dwCtrlType CERT_STORE_CTRL_COMMIT, pvCtrlPara is not used and must be set to <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// <para>
	/// If dwCtrlType is CERT_STORE_NOTIFY_CHANGE, the function returns nonzero if a handle for the event signal was successfully set
	/// up. The function returns zero if the event handle was not set up.
	/// </para>
	/// <para>
	/// If dwCtrlType is CERT_STORE_CTRL_RESYNC, the function returns nonzero if the resynchronization succeeded. The function returns
	/// zero if the resynchronization failed.
	/// </para>
	/// <para>
	/// If dwCtrlType is CERT_STORE_CTRL_COMMIT, the function returns nonzero to indicate the successful completion of the commit to
	/// persisted storage. The function returns zero if the commit failed.
	/// </para>
	/// <para>
	/// Some providers might not support specific control types. In these cases, <c>CertControlStore</c> returns zero and GetLastError
	/// is set to the ERROR_NOT_SUPPORTED code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Resynchronization of a store can be done at any time. It need not follow a signaled notification change event.</para>
	/// <para>CERT_STORE_CTRL_NOTIFY_CHANGE is supported on registry-based store providers by using the RegNotifyChangeKeyValue function.</para>
	/// <para>
	/// <c>CertControlStore</c> using CERT_STORE_CTRL_NOTIFY_CHANGE is called once for each event handle to be passed with
	/// CERT_STORE_CTRL_RESYNC. These calls using CERT_STORE_CTRL_NOTIFY_CHANGE must be made after each event is created and not after
	/// an event has been signaled.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows allowing an application to be notified when there is a difference between the contents of a cached
	/// store in use and the contents of that store as it is persisted to storage. For the full example including the complete context
	/// for this example, see Example C Program: Setting and Getting Certificate Store Properties.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcontrolstore BOOL CertControlStore( HCERTSTORE
	// hCertStore, DWORD dwFlags, DWORD dwCtrlType, void const *pvCtrlPara );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "04cd9349-50c1-44b4-b080-631a24a80d70")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertControlStore(HCERTSTORE hCertStore, CertStoreControlFlags dwFlags, CertStoreControlType dwCtrlType, [In, Optional] IntPtr pvCtrlPara);

	/// <summary>
	/// The <c>CertCreateContext</c> function creates the specified context from the encoded bytes. The context created does not include
	/// any extended properties.
	/// </summary>
	/// <param name="dwContextType">
	/// <para>Specifies the contexts that can be created. For example, to create a certificate context, set dwContextType to CERT_STORE_CERTIFICATE_CONTEXT.</para>
	/// <para>Currently defined context type flags are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_CERTIFICATE_CONTEXT</term>
	/// <term>Certificate context.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CRL_CONTEXT</term>
	/// <term>CRL context.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTL_CONTEXT</term>
	/// <term>CTL context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type used. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional
	/// encoding types may be added in the future. For either current encoding type, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="pbEncoded">A pointer to a buffer that contains the existing encoded context content to be copied.</param>
	/// <param name="cbEncoded">The size, in bytes, of the pbEncoded buffer.</param>
	/// <param name="dwFlags">
	/// <para>The following flag values are defined and can be combined by using a bitwise- <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CREATE_CONTEXT_NOCOPY_FLAG</term>
	/// <term>The created context points directly to the content pointed to by pbEncoded instead of an allocated copy.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CREATE_CONTEXT_SORTED_FLAG</term>
	/// <term>
	/// The function creates a context with sorted entries. Currently, this flag only applies to a CTL context. For CTLs, the cCTLEntry
	/// member of the returned CTL_INFO structure is always zero. CertFindSubjectInSortedCTL and CertEnumSubjectInSortedCTL must be
	/// called to find or enumerate the CTL entries.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CREATE_CONTEXT_NO_HCRYPTMSG_FLAG</term>
	/// <term>
	/// By default, when a CTL context is created, a HCRYTPMSG handle to its SignedData message is created. This flag can be set to
	/// improve performance by not creating this handle. This flag can only be used when dwContextType is CERT_STORE_CTL_CONTEXT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CREATE_CONTEXT_NO_ENTRY_FLAG</term>
	/// <term>
	/// By default, when a CTL context is created, its entries are decoded. When this flag is set, the entries are not decoded and
	/// performance is improved. This flag can only be used when dwContextType is CERT_STORE_CTL_CONTEXT.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCreatePara">
	/// <para>A pointer to a CERT_CREATE_CONTEXT_PARA structure.</para>
	/// <para>
	/// If pCreatePara and its <c>pfnFree</c> member are both non- <c>NULL</c>, the <c>pfnFree</c> member is used to free the memory
	/// specified by the <c>pvFree</c> member. If the <c>pvFree</c> member is <c>NULL</c>, the <c>pfnFree</c> member is used to free the
	/// pbEncoded pointer.
	/// </para>
	/// <para>If pCreatePara or its <c>pfnFree</c> member is <c>NULL</c>, no attempt is made to free pbEncoded.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a pointer to the newly created context. The <c>pvFree</c> member of pCreatePara
	/// must be called to free the created context.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. For extended error information, call GetLastError.</para>
	/// <para>
	/// If GetLastError returns <c>ERROR_CANCELLED</c>, this means that the PFN_CERT_CREATE_CONTEXT_SORT_FUNC callback function returned
	/// <c>FALSE</c> to stop the sort.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcreatecontext const void * CertCreateContext( DWORD
	// dwContextType, DWORD dwEncodingType, const BYTE *pbEncoded, DWORD cbEncoded, DWORD dwFlags, PCERT_CREATE_CONTEXT_PARA pCreatePara );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "0911054b-a47a-4046-b121-a236fc4b018b")]
	public static extern IntPtr CertCreateContext(CertStoreContextType dwContextType, CertEncodingType dwEncodingType, [In] IntPtr pbEncoded, uint cbEncoded,
		CertCreateContextFlags dwFlags, in CERT_CREATE_CONTEXT_PARA pCreatePara);

	/// <summary>The <c>CertDuplicateStore</c> function duplicates a store handle by incrementing the store's reference count.</summary>
	/// <param name="hCertStore">A handle of the certificate store for which the reference count is being incremented.</param>
	/// <returns>
	/// Currently, a copy is not made of the handle, and the returned handle is the same as the handle that was input. If <c>NULL</c> is
	/// passed in, the called function will raise an access violation exception.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certduplicatestore HCERTSTORE CertDuplicateStore(
	// HCERTSTORE hCertStore );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "628efd30-6e07-4748-82ac-5cdc723be451")]
	public static extern HCERTSTORE CertDuplicateStore(HCERTSTORE hCertStore);

	/// <summary>
	/// The <c>CertEnumPhysicalStore</c> function retrieves the physical stores on a computer. The function calls the provided callback
	/// function for each physical store found.
	/// </summary>
	/// <param name="pvSystemStore">
	/// If CERT_SYSTEM_STORE_RELOCATE_FLAG is set in dwFlags, pvSystemStore points to a CERT_SYSTEM_STORE_RELOCATE_PARA structure that
	/// indicates both the name and the location of the system store to be enumerated. Otherwise, pvSystemStore is a pointer to a
	/// Unicode string that names the system store whose physical stores are to be enumerated. For information about prefixing a
	/// ServiceName or ComputerName to the system store name, see CertRegisterSystemStore.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Specifies the location of the system store. The following flag values are defined:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_SERVICE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_SERVICES</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_USERS</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE</term>
	/// </item>
	/// </list>
	/// <para>In addition, CERT_SYSTEM_STORE_RELOCATE_FLAG or CERT_PHYSICAL_STORE_PREDEFINED_ENUM_FLAG can be combined using a bitwise-</para>
	/// <para>OR</para>
	/// <para>operation with any of the high-word location flags.</para>
	/// </param>
	/// <param name="pvArg">
	/// A pointer to a <c>void</c> that allows the application to declare, define, and initialize a structure to hold any information to
	/// be passed to the callback enumeration function.
	/// </param>
	/// <param name="pfnEnum">
	/// A pointer to the callback function used to show the details for each physical store. This callback function determines the
	/// content and format for the presentation of information on each physical store. The application must provide the
	/// CertEnumPhysicalStoreCallback callback function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds and another physical store was found, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the system store location only supports system stores and does not support physical stores, the function returns <c>FALSE</c>
	/// and GetLastError returns the ERROR_NOT_SUPPORTED code.
	/// </para>
	/// <para>
	/// If the function fails and another physical store was not found, the return value is <c>FALSE</c>. For extended error
	/// information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>CertEnumPhysicalStore</c>, an application must declare and define the <c>ENUM_ARG</c> structure and an enumeration
	/// callback function.
	/// </para>
	/// <para>Examples</para>
	/// <para>See Example C Program: Listing System and Physical Stores.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumphysicalstore BOOL CertEnumPhysicalStore( const
	// void *pvSystemStore, DWORD dwFlags, void *pvArg, PFN_CERT_ENUM_PHYSICAL_STORE pfnEnum );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5804d565-5129-4e6d-8b3d-9bd938807740")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertEnumPhysicalStore([MarshalAs(UnmanagedType.LPWStr)] string pvSystemStore, CertSystemStore dwFlags, [In, Optional] IntPtr pvArg, CertEnumPhysicalStoreCallback pfnEnum);

	/// <summary>
	/// The <c>CertEnumPhysicalStore</c> function retrieves the physical stores on a computer. The function calls the provided callback
	/// function for each physical store found.
	/// </summary>
	/// <param name="pvSystemStore">
	/// If CERT_SYSTEM_STORE_RELOCATE_FLAG is set in dwFlags, pvSystemStore points to a CERT_SYSTEM_STORE_RELOCATE_PARA structure that
	/// indicates both the name and the location of the system store to be enumerated. Otherwise, pvSystemStore is a pointer to a
	/// Unicode string that names the system store whose physical stores are to be enumerated. For information about prefixing a
	/// ServiceName or ComputerName to the system store name, see CertRegisterSystemStore.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Specifies the location of the system store. The following flag values are defined:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_SERVICE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_SERVICES</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_USERS</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE</term>
	/// </item>
	/// </list>
	/// <para>In addition, CERT_SYSTEM_STORE_RELOCATE_FLAG or CERT_PHYSICAL_STORE_PREDEFINED_ENUM_FLAG can be combined using a bitwise-</para>
	/// <para>OR</para>
	/// <para>operation with any of the high-word location flags.</para>
	/// </param>
	/// <param name="pvArg">
	/// A pointer to a <c>void</c> that allows the application to declare, define, and initialize a structure to hold any information to
	/// be passed to the callback enumeration function.
	/// </param>
	/// <param name="pfnEnum">
	/// A pointer to the callback function used to show the details for each physical store. This callback function determines the
	/// content and format for the presentation of information on each physical store. The application must provide the
	/// CertEnumPhysicalStoreCallback callback function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds and another physical store was found, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the system store location only supports system stores and does not support physical stores, the function returns <c>FALSE</c>
	/// and GetLastError returns the ERROR_NOT_SUPPORTED code.
	/// </para>
	/// <para>
	/// If the function fails and another physical store was not found, the return value is <c>FALSE</c>. For extended error
	/// information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>CertEnumPhysicalStore</c>, an application must declare and define the <c>ENUM_ARG</c> structure and an enumeration
	/// callback function.
	/// </para>
	/// <para>Examples</para>
	/// <para>See Example C Program: Listing System and Physical Stores.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumphysicalstore BOOL CertEnumPhysicalStore( const
	// void *pvSystemStore, DWORD dwFlags, void *pvArg, PFN_CERT_ENUM_PHYSICAL_STORE pfnEnum );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5804d565-5129-4e6d-8b3d-9bd938807740")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertEnumPhysicalStore(in CERT_SYSTEM_STORE_RELOCATE_PARA pvSystemStore, CertSystemStore dwFlags, [In, Optional] IntPtr pvArg, CertEnumPhysicalStoreCallback pfnEnum);

	/// <summary>
	/// The <c>CertEnumSubjectInSortedCTL</c> function retrieves the first or next TrustedSubject in a sorted certificate trust list
	/// (CTL). A sorted CTL is a CTL created with the CERT_CREATE_CONTEXT_SORTED_FLAG set. Used in a loop, this function can retrieve in
	/// sequence all TrustedSubjects in a sorted CTL.
	/// </summary>
	/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure to be searched.</param>
	/// <param name="ppvNextSubject">
	/// A pointer to the address of the last TrustedSubject found. To start the enumeration, ppvNextSubject must point to a pointer set
	/// to <c>NULL</c>. Upon return, the pointer addressed by ppvNextSubject is updated to point to the next TrustedSubject in the
	/// encoded sequence.
	/// </param>
	/// <param name="pSubjectIdentifier">
	/// A pointer to a CRYPT_DER_BLOB structure, uniquely identifying a TrustedSubject. The information in this structure can be a hash
	/// or any unique byte sequence.
	/// </param>
	/// <param name="pEncodedAttributes">
	/// A pointer to a CRYPT_DER_BLOB structure containing a byte count and a pointer to the TrustedSubject's encoded attributes.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>TRUE</c>, with ppvNextSubject updated to point to the next TrustedSubject in
	/// the encoded sequence.
	/// </para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. The return value is <c>FALSE</c> if there are no more subjects or there
	/// is an argument that is not valid.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>pbData</c> members of CRYPT_DER_BLOB structures point directly to the encoded bytes. The <c>CRYPT_DER_BLOB</c>
	/// structures, themselves, must be allocated and freed by the application, but the memory addressed by the <c>pbData</c> members of
	/// these structures is not allocated by the application and must not be freed by the application.
	/// </para>
	/// <para>If the CTL is not sorted with the CERT_CREATE_CONTEXT_SORTED_FLAG flag set, an error results.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumsubjectinsortedctl BOOL
	// CertEnumSubjectInSortedCTL( PCCTL_CONTEXT pCtlContext, void **ppvNextSubject, PCRYPT_DER_BLOB pSubjectIdentifier, PCRYPT_DER_BLOB
	// pEncodedAttributes );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b37cff03-5e9c-4e6c-b46e-d3f02dbf8783")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertEnumSubjectInSortedCTL([In] PCCTL_CONTEXT pCtlContext, ref IntPtr ppvNextSubject, out CRYPTOAPI_BLOB pSubjectIdentifier, out CRYPTOAPI_BLOB pEncodedAttributes);

	/// <summary>
	/// The <c>CertEnumSystemStore</c> function retrieves the system stores available. The function calls the provided callback function
	/// for each system store found.
	/// </summary>
	/// <param name="dwFlags">
	/// <para>Specifies the location of the system store. This parameter can be one of the following flags:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_SERVICE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_SERVICES</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_USERS</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE</term>
	/// </item>
	/// </list>
	/// <para>In addition, the CERT_SYSTEM_STORE_RELOCATE_FLAG can be combined, by using a bitwise-</para>
	/// <para>OR</para>
	/// <para>operation, with any of the high-word location flags.</para>
	/// </param>
	/// <param name="pvSystemStoreLocationPara">
	/// <para>
	/// If CERT_SYSTEM_STORE_RELOCATE_FLAG is set in the dwFlags parameter, pvSystemStoreLocationPara points to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure that indicates both the name and the location of the system store. Otherwise,
	/// pvSystemStoreLocationPara is a pointer to a Unicode string that names the system store.
	/// </para>
	/// <para>
	/// For CERT_SYSTEM_STORE_LOCAL_MACHINE or CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY, pvSystemStoreLocationPara can optionally be
	/// set to a Unicode computer name for enumerating local computer stores on a remote computer, for example "\computer_name" or
	/// "computer_name". The leading backslashes (\) are optional in the computer_name.
	/// </para>
	/// <para>
	/// For CERT_SYSTEM_STORE_SERVICES or CERT_SYSTEM_STORE_USERS, if pvSystemStoreLocationPara is <c>NULL</c>, the function enumerates
	/// both the service/user names and the stores for each service/user name. Otherwise, pvSystemStoreLocationPara is a Unicode string
	/// that contains a remote computer name and, if available, a service/user name, for example, "service_name", "\computer_name", or "computer_name".
	/// </para>
	/// <para>
	/// If only the computer_name is specified, it must have either the leading backslashes (\) or a trailing backslash (). Otherwise,
	/// it is interpreted as the service_name or user_name.
	/// </para>
	/// </param>
	/// <param name="pvArg">
	/// A pointer to a <c>void</c> that allows the application to declare, define, and initialize a structure to hold any information to
	/// be passed to the callback enumeration function.
	/// </param>
	/// <param name="pfnEnum">
	/// A pointer to the callback function used to show the details for each system store. This callback function determines the content
	/// and format for the presentation of information on each system store. The application must provide the
	/// CertEnumSystemStoreCallback callback function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>CertEnumSystemStore</c>, the application must declare and define the <c>ENUM_ARG</c> structure and the
	/// CertEnumSystemStoreCallback callback function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Listing System and Physical Stores.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumsystemstore BOOL CertEnumSystemStore( DWORD
	// dwFlags, void *pvSystemStoreLocationPara, void *pvArg, PFN_CERT_ENUM_SYSTEM_STORE pfnEnum );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "fd9cb23b-e4a3-41cb-8f0a-30f4e813c6ac")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertEnumSystemStore(CertSystemStore dwFlags, in CERT_SYSTEM_STORE_RELOCATE_PARA pvSystemStoreLocationPara, [In, Optional] IntPtr pvArg, CertEnumSystemStoreCallback pfnEnum);

	/// <summary>
	/// The <c>CertEnumSystemStore</c> function retrieves the system stores available. The function calls the provided callback function
	/// for each system store found.
	/// </summary>
	/// <param name="dwFlags">
	/// <para>Specifies the location of the system store. This parameter can be one of the following flags:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_SERVICE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_SERVICES</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_USERS</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE</term>
	/// </item>
	/// </list>
	/// <para>In addition, the CERT_SYSTEM_STORE_RELOCATE_FLAG can be combined, by using a bitwise-</para>
	/// <para>OR</para>
	/// <para>operation, with any of the high-word location flags.</para>
	/// </param>
	/// <param name="pvSystemStoreLocationPara">
	/// <para>
	/// If CERT_SYSTEM_STORE_RELOCATE_FLAG is set in the dwFlags parameter, pvSystemStoreLocationPara points to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure that indicates both the name and the location of the system store. Otherwise,
	/// pvSystemStoreLocationPara is a pointer to a Unicode string that names the system store.
	/// </para>
	/// <para>
	/// For CERT_SYSTEM_STORE_LOCAL_MACHINE or CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY, pvSystemStoreLocationPara can optionally be
	/// set to a Unicode computer name for enumerating local computer stores on a remote computer, for example "\computer_name" or
	/// "computer_name". The leading backslashes (\) are optional in the computer_name.
	/// </para>
	/// <para>
	/// For CERT_SYSTEM_STORE_SERVICES or CERT_SYSTEM_STORE_USERS, if pvSystemStoreLocationPara is <c>NULL</c>, the function enumerates
	/// both the service/user names and the stores for each service/user name. Otherwise, pvSystemStoreLocationPara is a Unicode string
	/// that contains a remote computer name and, if available, a service/user name, for example, "service_name", "\computer_name", or "computer_name".
	/// </para>
	/// <para>
	/// If only the computer_name is specified, it must have either the leading backslashes (\) or a trailing backslash (). Otherwise,
	/// it is interpreted as the service_name or user_name.
	/// </para>
	/// </param>
	/// <param name="pvArg">
	/// A pointer to a <c>void</c> that allows the application to declare, define, and initialize a structure to hold any information to
	/// be passed to the callback enumeration function.
	/// </param>
	/// <param name="pfnEnum">
	/// A pointer to the callback function used to show the details for each system store. This callback function determines the content
	/// and format for the presentation of information on each system store. The application must provide the
	/// CertEnumSystemStoreCallback callback function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>CertEnumSystemStore</c>, the application must declare and define the <c>ENUM_ARG</c> structure and the
	/// CertEnumSystemStoreCallback callback function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Listing System and Physical Stores.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumsystemstore BOOL CertEnumSystemStore( DWORD
	// dwFlags, void *pvSystemStoreLocationPara, void *pvArg, PFN_CERT_ENUM_SYSTEM_STORE pfnEnum );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "fd9cb23b-e4a3-41cb-8f0a-30f4e813c6ac")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertEnumSystemStore(CertSystemStore dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string? pvSystemStoreLocationPara, [In, Optional] IntPtr pvArg, CertEnumSystemStoreCallback pfnEnum);

	/// <summary>
	/// The <c>CertEnumSystemStoreLocation</c> function retrieves all of the system store locations. The function calls the provided
	/// callback function for each system store location found.
	/// </summary>
	/// <param name="dwFlags">Reserved for future use; must be zero.</param>
	/// <param name="pvArg">
	/// A pointer to a <c>void</c> that allows the application to declare, define, and initialize a structure to hold any information to
	/// be passed to the callback enumeration function.
	/// </param>
	/// <param name="pfnEnum">
	/// A pointer to the callback function used to show the details for each store location. This callback function determines the
	/// content and format for the presentation of information on each store location. For the signature and parameters of the callback
	/// function, see CertEnumSystemStoreLocationCallback.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>CertEnumSystemStoreLocation</c>, an application must declare and define the <c>ENUM_ARG</c> structure and an
	/// enumeration callback function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Listing System and Physical Stores.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumsystemstorelocation BOOL
	// CertEnumSystemStoreLocation( DWORD dwFlags, void *pvArg, PFN_CERT_ENUM_SYSTEM_STORE_LOCATION pfnEnum );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "86408e6f-0732-4cb4-85cd-840b9d98b973")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertEnumSystemStoreLocation([Optional] uint dwFlags, [In, Optional] IntPtr pvArg, CertEnumSystemStoreLocationCallback pfnEnum);

	/// <summary>
	/// The <c>CertFindSubjectInCTL</c> function attempts to find the specified subject in a certificate trust list (CTL). A subject can
	/// be identified either by the certificate's whole context or by any unique identifier of the certificate's subject such as the
	/// SHA1 hash of the certificate's issuer and serial number.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type used. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional
	/// encoding types may be added in the future. For either current encoding type, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="dwSubjectType">
	/// <para>Specifies the type of subject to be searched for in the CTL. May be <c>NULL</c> for a default search.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CTL_CERT_SUBJECT_TYPE</term>
	/// <term>
	/// pvSubject data type: Pointer to a CERT_CONTEXT structure. The CTL's SubjectAlgorithm is examined to determine the representation
	/// of the subject's identity. Initially, only SHA1 and MD5 hashes are supported as values for SubjectAlgorithm. The appropriate
	/// hash property is obtained from the CERT_CONTEXT structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTL_ANY_SUBJECT_TYPE</term>
	/// <term>
	/// pvSubject data type: Pointer to a CTL_ANY_SUBJECT_INFO structure. The SubjectAlgorithm member of this structure must match the
	/// algorithm type of the CTL, and the SubjectIdentifier member must match one of the CTL entries.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The certificate's hash or the <c>SubjectIdentifier</c> member of the CTL_ANY_SUBJECT_INFO structure is used as the key in
	/// searching the subject entries. A binary memory comparison is done between the key and the entry's SubjectIdentifier.
	/// </para>
	/// <para>If dwSubjectType is set to either preceding value, dwEncodingType is not used.</para>
	/// </param>
	/// <param name="pvSubject">Pointer used in conjunction with the dwSubjectType parameter.</param>
	/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure being searched.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the entry, if it is found.</para>
	/// <para>
	/// If the function fails, the return value is <c>NULL</c>. For extended error information, call GetLastError. Some possible error
	/// codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>The subject was not found in the CTL.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The dwSubjectType parameter was not either CTL_CERT_SUBJECT_TYPE or CTL_ANY_SUBJECT_TYPE.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The CTL's SubjectAlgorithm member did not map to either SHA1 or MD5.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The certificate's hash or the <c>SubjectIdentifier</c> member of the CTL_ANY_SUBJECT_INFO structure is used as the key in
	/// searching the subject entries. A binary memory comparison is done between the key and the entry's <c>SubjectIdentifier</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindsubjectinctl PCTL_ENTRY CertFindSubjectInCTL(
	// DWORD dwEncodingType, DWORD dwSubjectType, void *pvSubject, PCCTL_CONTEXT pCtlContext, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e0c81531-e649-45bb-bafe-bced00c7b16a")]
	public static extern IntPtr CertFindSubjectInCTL(CertEncodingType dwEncodingType, CtlCertSubject dwSubjectType, [In] IntPtr pvSubject, [In] PCCTL_CONTEXT pCtlContext, uint dwFlags = 0);

	/// <summary>
	/// The <c>CertFindSubjectInSortedCTL</c> function attempts to find the specified subject in a sorted certificate trust list (CTL).
	/// A subject can be identified either by the certificate's whole context or by any unique identifier of the certificate's subject,
	/// such as the SHA1 hash of the certificate's issuer and serial number.
	/// </summary>
	/// <param name="pSubjectIdentifier">
	/// A pointer to a CRYPT_DATA_BLOB structure uniquely identifying the subject. The information in this structure can be a hash or
	/// any unique byte sequence.
	/// </param>
	/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure to be searched.</param>
	/// <param name="dwFlags">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="pEncodedAttributes">
	/// A pointer to a CRYPT_DER_BLOB structure containing a byte count and a pointer to the subject's encoded attributes.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds and the subject identifier exists in the CTL, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails and does not locate a matching subject identifier, the return value is <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindsubjectinsortedctl BOOL
	// CertFindSubjectInSortedCTL( PCRYPT_DATA_BLOB pSubjectIdentifier, PCCTL_CONTEXT pCtlContext, DWORD dwFlags, void *pvReserved,
	// PCRYPT_DER_BLOB pEncodedAttributes );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "027e89e6-3de0-440d-be70-2281778f9a1e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertFindSubjectInSortedCTL(in CRYPTOAPI_BLOB pSubjectIdentifier, [In] PCCTL_CONTEXT pCtlContext, [Optional] uint dwFlags, [Optional] IntPtr pvReserved, out CRYPTOAPI_BLOB pEncodedAttributes);

	/// <summary>The <c>CertGetStoreProperty</c> function retrieves a store property.</summary>
	/// <param name="hCertStore">A handle of an open certificate store.</param>
	/// <param name="dwPropId">
	/// <para>
	/// Indicates one of a range of store properties. There is one predefined store property, CERT_STORE_LOCALIZED_NAME_PROP_ID, the
	/// localized name of the store.
	/// </para>
	/// <para>
	/// User defined properties must be outside the current range of values for predefined context properties. Currently, user defined
	/// dwPropId values begin at 4,096.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>
	/// A pointer to a buffer that receives the data as determined by dwPropId. For CERT_STORE_LOCALIZED_NAME_PROP_ID, this is the
	/// localized name of the store, and pvData points to a null-terminated Unicode wide-character string. For other dwPropIds, pvData
	/// points to an array of bytes.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the pvData buffer. When the function returns, the
	/// <c>DWORD</c> value contains the number of bytes stored in the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero.</para>
	/// <para>
	/// If the store property is found, the function returns nonzero, pvData points to the property, and pcbData points to the length of
	/// the string. If the store property is not found, the function returns zero and GetLastError returns CRYPT_E_NOT_FOUND.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Store property identifiers are properties applicable to an entire store. They are not properties on an individual certificate,
	/// certificate revocation list (CRL), or certificate trust list (CTL) context. Currently, no store properties are persisted.
	/// </para>
	/// <para>To find the localized name of a store, you can also use the CryptFindLocalizedName function.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows querying a store for its local name property. Similar code can be used to retrieve other store
	/// properties. For a complete example that uses this function, see Example C Program: Setting and Getting Certificate Store Properties.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetstoreproperty BOOL CertGetStoreProperty(
	// HCERTSTORE hCertStore, DWORD dwPropId, void *pvData, DWORD *pcbData );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "0df4f18b-3b0f-498e-90a5-74d686af83e0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertGetStoreProperty(HCERTSTORE hCertStore, uint dwPropId, [Optional] IntPtr pvData, ref uint pcbData);

	/// <summary>
	/// The <c>CertOpenStore</c> function opens a certificate store by using a specified store provider type. While this function can
	/// open a certificate store for most purposes, CertOpenSystemStore is recommended to open the most common certificate stores.
	/// <c>CertOpenStore</c> is required for more complex options and special cases.
	/// </summary>
	/// <param name="lpszStoreProvider">
	/// <para>A pointer to a null-terminated ANSI string that contains the store provider type.</para>
	/// <para>
	/// The following values represent the predefined store types. The store provider type determines the contents of the pvPara
	/// parameter and the use and meaning of the high word of the dwFlags parameter. Additional store providers can be installed or
	/// registered by using the CryptInstallOIDFunctionAddress or CryptRegisterOIDFunction function. For more information about adding
	/// store providers, see Extending CertOpenStore Functionality.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_PROV_COLLECTION sz_CERT_STORE_PROV_COLLECTION</term>
	/// <term>
	/// Opens a store that will be a collection of other stores. Stores are added to or removed from the collection by using
	/// CertAddStoreToCollection and CertRemoveStoreFromCollection. When a store is added to a collection, all certificates, CRLs, and
	/// CTLs in that store become available to searches or enumerations of the collection store. The high word of dwFlags is set to
	/// zero. pvPara value: The pvPara parameter must be NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_FILE</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs read from a specified open file. This provider expects the file to
	/// contain only a serialized store and not either PKCS #7 signed messages or a single encoded certificate. The file pointer must be
	/// positioned at the beginning of the serialized store information. After the data in the serialized store has been loaded into the
	/// certificate store, the file pointer is positioned at the beginning of any data that can follow the serialized store data in the
	/// file. If CERT_FILE_STORE_COMMIT_ENABLE is set in dwFlags, the file handle is duplicated and the store is always committed as a
	/// serialized store. The file is not closed when the store is closed. pvPara value: The pvPara parameter must contain a pointer to
	/// the handle of a file opened by using CreateFile.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_FILENAME_A</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a file. The provider opens the file and first attempts to read the
	/// file as a serialized store, then as a PKCS #7 signed message, and finally as a single encoded certificate. The dwEncodingType
	/// parameter must contain the encoding types to be used with both messages and certificates. If the file contains an X.509 encoded
	/// certificate, the open operation fails and a call to the GetLastError function will return ERROR_ACCESS_DENIED. If the
	/// CERT_FILE_STORE_COMMIT_ENABLE flag is set in dwFlags, the dwCreationDisposition value passed to CreateFile is as follows: If
	/// dwFlags includes CERT_FILE_STORE_COMMIT_ENABLE, the file is committed as either a PKCS #7 or a serialized store depending on the
	/// file type opened. If the file was empty or if the file name has either a .p7c or .spc extension, the file is committed as a PKCS
	/// #7. Otherwise, the file is committed as a serialized store. pvPara value: The pvPara parameter must contain a pointer to
	/// null-terminated ANSI string that contains the name of an existing, unopened file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_FILENAME(_W) sz_CERT_STORE_PROV_FILENAME(_W)</term>
	/// <term>
	/// Same as CERT_STORE_PROV_FILENAME_A. pvPara value: The pvPara parameter must contain a pointer to null-terminated Unicode string
	/// that contains the name of an existing, unopened file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_LDAP(_W) sz_CERT_STORE_PROV_LDAP(_W)</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from the results of an LDAP query. To perform write operations on the
	/// store, the query string must specify a BASE query with no filter and a single attribute. pvPara value: If the dwFlags parameter
	/// contains CERT_LDAP_STORE_OPENED_FLAG, set pvPara to the address of a CERT_LDAP_STORE_OPENED_PARA structure that specifies the
	/// established LDAP session to use. Otherwise, set pvPara to point to a null-terminated Unicode string that contains the LDAP query
	/// string. For more information about LDAP query strings, see LDAP Dialect.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_MEMORY sz_CERT_STORE_PROV_MEMORY</term>
	/// <term>
	/// Creates a certificate store in cached memory. No certificates, certificate revocation lists (CRLs), or certificate trust lists
	/// (CTLs) are initially loaded into the store. Typically used to create a temporary store. Any addition of certificates, CRLs, or
	/// CTLs or changes in properties of certificates, CRLs, or CTLs in a memory store are not automatically saved. They can be saved to
	/// a file or to a memory BLOB by using CertSaveStore. pvPara value: The pvPara parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_MSG</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from the specified cryptographic message. The dwEncodingType parameter
	/// must contain the encoding types used with both messages and certificates. pvPara value: The pvPara parameter contains an
	/// HCRYPTMSG handle of the encoded message, returned by a call to CryptMsgOpenToDecode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_PHYSICAL(_W) sz_CERT_STORE_PROV_PHYSICAL(_W)</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a specified physical store that is a member of a logical system
	/// store. Two names are separated with an intervening backslash (), for example "Root.Default". Here, "Root" is the name of the
	/// system store and ".Default" is the name of the physical store. The system and physical store names cannot contain any
	/// backslashes. The high word of dwFlags indicates the system store location, usually CERT_SYSTEM_STORE_CURRENT_USER. For more
	/// information, see dwFlags later in this topic and see System Store Locations. Some physical store locations can be opened
	/// remotely. pvPara value: The pvPara parameter points to a null-terminated Unicode string that contains both the system store name
	/// and physical names.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_PKCS7 sz_CERT_STORE_PROV_PKCS7</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from an encoded PKCS #7 signed message. The dwEncodingType parameter
	/// must specify the encoding types to be used with both messages and certificates. pvPara value: The pvPara parameter points to a
	/// CRYPT_DATA_BLOB structure that represents the encoded message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_PKCS12 sz_CERT_STORE_PROV_PKCS12</term>
	/// <term>
	/// Initializes the store with the contents of a PKCS #12 packet. If the PKCS #12 packet is protected with a NULL or empty password,
	/// this function will succeed in opening the store. Beginning with Windows 8 and Windows Server 2012, if the password embedded in
	/// the PFX packet was protected to an Active Directory (AD) principal and the current user, as a member of that principal, has
	/// permission to decrypt the password, this function will succeed in opening the store. For more information, see the pvPara
	/// parameter and the PKCS12_PROTECT_TO_DOMAIN_SIDS flag of the PFXExportCertStoreEx function. You can protect PFX passwords to an
	/// AD principal beginning in Windows 8 and Windows Server 2012. pvPara value: The pvPara parameter points to a CRYPT_DATA_BLOB
	/// structure that represents the PKCS #12 packet.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_REG</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a registry subkey. This provider opens or creates the registry
	/// subkeys Certificates, CRLs, and CTLs under the key passed in pvPara. The input key is not closed by the provider. Before
	/// returning, the provider opens its own copy of the key passed in pvPara. If CERT_STORE_READONLY_FLAG is set in the low word of
	/// dwFlags, registry subkeys are opened by using the RegOpenKey with KEY_READ_ACCESS. Otherwise, registry subkeys are created by
	/// using RegCreateKey with KEY_ALL_ACCESS. Any changes to the contents of the opened store are immediately persisted to the
	/// registry. However, if CERT_STORE_READONLY_FLAG is set in the low word of dwFlags, any attempt to add to the contents of the
	/// store or to change a context's property results in an error with GetLastError returning the E_ACCESSDENIED code. pvPara value:
	/// The pvPara parameter contains the handle of an open registry key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SERIALIZED sz_CERT_STORE_PROV_SERIALIZED</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a memory location that contains a serialized store. pvPara value:
	/// The pvPara parameter points to a CRYPT_DATA_BLOB structure that contains the serialized memory BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SMART_CARD(_W) sz_CERT_STORE_PROV_SMART_CARD(_W)</term>
	/// <term>Not currently used.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SYSTEM_A</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from the specified system store. The system store is a logical,
	/// collection store that consists of one or more physical stores. A physical store associated with a system store is registered
	/// with the CertRegisterPhysicalStore function. After the system store is opened, all of the physical stores that are associated
	/// with it are also opened by calls to CertOpenStore and are added to the system store collection by using the
	/// CertAddStoreToCollection function. The high word of dwFlags indicates the system store location, usually set to
	/// CERT_SYSTEM_STORE_CURRENT_USER. For details about registry locations, see dwFlags later in this topic and System Store
	/// Locations. Some system store locations can be opened remotely; for more information, see System Store Locations. pvPara value:
	/// The pvPara parameter points to a null-terminated ANSI string that contains a system store name, such as "My" or "Root".
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SYSTEM(_W) sz_CERT_STORE_PROV_SYSTEM(_W)</term>
	/// <term>
	/// Same as CERT_STORE_PROV_SYSTEM_A. pvPara value: The pvPara parameter points to a null-terminated Unicode string that contains a
	/// system store name, such as "My" or "Root".
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SYSTEM_REGISTRY_A</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a physical registry store. The physical store is not opened as a
	/// collection store. Enumerations and searches go through only the certificates, CRLs, and CTLs in that one physical store. The
	/// high word of dwFlags indicates the system store location, usually set to CERT_SYSTEM_STORE_CURRENT_USER. For more information,
	/// see dwFlags later in this topic. Some system store locations can be open remotely; for more information, see System Store
	/// Locations. pvPara value: The pvPara parameter points to a null-terminated ANSI string that contains a system store name, such as
	/// "My" or "Root".
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SYSTEM_REGISTRY(_W) sz_CERT_STORE_PROV_SYSTEM_REGISTRY(_W)</term>
	/// <term>
	/// Same as CERT_STORE_PROV_SYSTEM_REGISTRY_A. pvPara value: The pvPara parameter points to a null-terminated Unicode string that
	/// contains a system store name, such as "My" or "Root".
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the certificate encoding type and message encoding type. Encoding is used only when the dwSaveAs parameter of the
	/// CertSaveStore function contains <c>CERT_STORE_SAVE_AS_PKCS7</c>. Otherwise, the dwMsgAndCertEncodingType parameter is not used.
	/// </para>
	/// <para>
	/// This parameter is only applicable when the <c>CERT_STORE_PROV_MSG</c>, <c>CERT_STORE_PROV_PKCS7</c>, or
	/// <c>CERT_STORE_PROV_FILENAME</c> provider type is specified in the lpszStoreProvider parameter. For all other provider types,
	/// this parameter is unused and should be set to zero.
	/// </para>
	/// <para>This parameter can be a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS #7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> A handle to a cryptographic provider. Passing <c>NULL</c> for this parameter causes
	/// an appropriate, default provider to be used. Using the default provider is recommended. The default or specified cryptographic
	/// provider is used for all store functions that verify the signature of a subject certificate or CRL.This parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>These values consist of high-word and low-word values combined by using a bitwise- <c>OR</c> operation.</para>
	/// <para>
	/// The low-word portion of dwFlags controls a variety of general characteristics of the certificate store opened. This portion can
	/// be used with all store provider types. The low-word portion of dwFlags can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_BACKUP_RESTORE_FLAG</term>
	/// <term>
	/// Use the thread's SE_BACKUP_NAME and SE_RESTORE_NAME privileges to open registry or file-based system stores. If the thread does
	/// not have these privileges, this function must fail with an access denied error.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CREATE_NEW_FLAG</term>
	/// <term>
	/// A new store is created if one did not exist. The function fails if the store already exists. If neither
	/// CERT_STORE_OPEN_EXISTING_FLAG nor CERT_STORE_CREATE_NEW_FLAG is set, a store is opened if it exists or is created and opened if
	/// it did not already exist.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_DEFER_CLOSE_UNTIL_LAST_FREE_FLAG</term>
	/// <term>
	/// Defer closing of the store's provider until all certificates, CRLs, or CTLs obtained from the store are no longer in use. The
	/// store is actually closed when the last certificate, CRL, or CTL obtained from the store is freed. Any changes made to properties
	/// of these certificates, CRLs, and CTLs, even after the call to CertCloseStore, are persisted. If this flag is not set and
	/// certificates, CRLs, or CTLs obtained from the store are still in use, any changes to the properties of those certificates, CRLs,
	/// and CTLs will not be persisted. If this function is called with CERT_CLOSE_STORE_FORCE_FLAG,
	/// CERT_STORE_DEFER_CLOSE_UNTIL_LAST_FREE_FLAG is ignored. When this flag is set and a non-NULL hCryptProv parameter value is
	/// passed, that provider will continue to be used even after the call to this function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_DELETE_FLAG</term>
	/// <term>
	/// The store is deleted instead of being opened. This function returns NULL for both success and failure of the deletion. To
	/// determine the success of the deletion, call GetLastError, which returns zero if the store was deleted and a nonzero value if it
	/// was not deleted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ENUM_ARCHIVED_FLAG</term>
	/// <term>
	/// Normally, an enumeration of all certificates in the store will ignore any certificate with the CERT_ARCHIVED_PROP_ID property
	/// set. If this flag is set, an enumeration of the certificates in the store will contain all of the certificates in the store,
	/// including those that have the CERT_ARCHIVED_PROP_ID property.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_MAXIMUM_ALLOWED_FLAG</term>
	/// <term>
	/// Open the store with the maximum set of allowed permissions. If this flag is specified, registry stores are first opened with
	/// write access and if that fails, they are reopened with read-only access.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_NO_CRYPT_RELEASE_FLAG</term>
	/// <term>
	/// This flag is not used when the hCryptProv parameter is NULL. This flag is only valid when a non-NULL CSP handle is passed as the
	/// hCryptProv parameter. Setting this flag prevents the automatic release of a nondefault CSP when the certificate store is closed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_OPEN_EXISTING_FLAG</term>
	/// <term>Only open an existing store. If the store does not exist, the function fails.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_READONLY_FLAG</term>
	/// <term>
	/// Open the store in read-only mode. Any attempt to change the contents of the store will result in an error. When this flag is set
	/// and a registry based store provider is being used, the registry subkeys are opened by using RegOpenKey with KEY_READ_ACCESS.
	/// Otherwise, the registry subkeys are created by using RegCreateKey with KEY_ALL_ACCESS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SET_LOCALIZED_NAME_FLAG</term>
	/// <term>
	/// If this flag is supported, the provider sets the store's CERT_STORE_LOCALIZED_NAME_PROP_ID property. The localized name can be
	/// retrieved by calling the CertGetStoreProperty function with dwPropID set to CERT_STORE_LOCALIZED_NAME_PROP_ID. This flag is
	/// supported for providers of types CERT_STORE_PROV_FILENAME, CERT_STORE_PROV_SYSTEM, CERT_STORE_PROV_SYSTEM_REGISTRY, and CERT_STORE_PROV_PHYSICAL_W.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SHARE_CONTEXT_FLAG</term>
	/// <term>
	/// When opening a store multiple times, you can set this flag to ensure efficient memory usage by reusing the memory for the
	/// encoded parts of a certificate, CRL, or CTL context across the opened instances of the stores.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_UPDATE_KEYID_FLAG</term>
	/// <term>
	/// Lists of key identifiers exist within CurrentUser and LocalMachine. These key identifiers have properties much like the
	/// properties of certificates. If the CERT_STORE_UPDATE_KEYID_FLAG is set, then for every key identifier in the store's location
	/// that has a CERT_KEY_PROV_INFO_PROP_ID property, that property is automatically updated from the key identifier property
	/// CERT_KEY_PROV_INFO_PROP_ID or the CERT_KEY_IDENTIFIER_PROP_ID of the certificate related to that key identifier.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>CERT_STORE_PROV_SYSTEM</c>, <c>CERT_STORE_PROV_SYSTEM_REGISTRY</c>, and <c>CERT_STORE_PROV_PHYSICAL</c> provider types
	/// use the following high words of dwFlags to specify system store registry locations:
	/// </para>
	/// <para>CERT_SYSTEM_STORE_CURRENT_SERVICE</para>
	/// <para>CERT_SYSTEM_STORE_CURRENT_USER</para>
	/// <para>CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY</para>
	/// <para>CERT_SYSTEM_STORE_LOCAL_MACHINE</para>
	/// <para>CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE</para>
	/// <para>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</para>
	/// <para>CERT_SYSTEM_STORE_SERVICES</para>
	/// <para>CERT_SYSTEM_STORE_USERS</para>
	/// <para>
	/// By default, a system store location is opened relative to the <c>HKEY_CURRENT_USER</c>, <c>HKEY_LOCAL_MACHINE</c>, or
	/// <c>HKEY_USERS</c> predefined registry key. For more information, see System Store Locations.
	/// </para>
	/// <para>The following high-word flags override this default behavior.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// When set, pvPara must contain a pointer to a CERT_SYSTEM_STORE_RELOCATE_PARA structure rather than a string. The structure
	/// indicates both the name of the store and its location in the registry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_UNPROTECTED_FLAG</term>
	/// <term>
	/// By default, when the CurrentUser "Root" store is opened, any SystemRegistry roots not on the protected root list are deleted
	/// from the cache before this function returns. When this flag is set, this default is overridden and all of the roots in the
	/// SystemRegistry are returned and no check of the protected root list is made.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The <c>CERT_STORE_PROV_REGISTRY</c> provider uses the following high-word flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_REGISTRY_STORE_REMOTE_FLAG</term>
	/// <term>
	/// pvPara contains a handle to a registry key on a remote computer. To access a registry key on a remote computer, security
	/// permissions on the remote computer must be set to allow access. For more information, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_REGISTRY_STORE_SERIALIZED_FLAG</term>
	/// <term>
	/// The CERT_STORE_PROV_REG provider saves certificates, CRLs, and CTLs in a single serialized store subkey instead of performing
	/// the default save operation. The default is that each certificate, CRL, or CTL is saved as a separate registry subkey under the
	/// appropriate subkey. This flag is mainly used for stores downloaded from the group policy template (GPT), such as the
	/// CurrentUserGroupPolicy and LocalMachineGroupPolicy stores. When CERT_REGISTRY_STORE_SERIALIZED_FLAG is set, store additions,
	/// deletions, or property changes are not persisted until there is a call to either CertCloseStore or CertControlStore using CERT_STORE_CTRL_COMMIT.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The <c>CERT_STORE_PROV_FILE</c> and <c>CERT_STORE_PROV_FILENAME</c> provider types use the following high-word flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_FILE_STORE_COMMIT_ENABLE</term>
	/// <term>
	/// Setting this flag commits any additions to the store or any changes made to properties of contexts in the store to the file
	/// store either when CertCloseStore is called or when CertControlStore is called with CERT_STORE_CONTROL_COMMIT. CertOpenStore
	/// fails with E_INVALIDARG if both CERT_FILE_STORE_COMMIT_ENABLE and CERT_STORE_READONLY_FLAG are set in dwFlags.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The <c>CERT_STORE_PROV_LDAP</c> provider type uses the following high-word flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_LDAP_STORE_AREC_EXCLUSIVE_FLAG</term>
	/// <term>
	/// Performs an A-Record-only DNS lookup on the URL named in the pvPara parameter. This prevents false DNS queries from being
	/// generated when resolving URL host names. Use this flag when passing a host name as opposed to a domain name for the pvPara parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_LDAP_STORE_OPENED_FLAG</term>
	/// <term>
	/// Use this flag to use an existing LDAP session. When this flag is specified, the pvPara parameter is the address of a
	/// CERT_LDAP_STORE_OPENED_PARA structure that contains information about the LDAP session to use.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_LDAP_STORE_SIGN_FLAG</term>
	/// <term>
	/// To provide integrity required by some applications, digitally sign all LDAP traffic to and from an LDAP server by using the
	/// Kerberos authentication protocol.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_LDAP_STORE_UNBIND_FLAG</term>
	/// <term>
	/// Use this flag with the CERT_LDAP_STORE_OPENED_FLAG flag to cause the LDAP session to be unbound when the store is closed. The
	/// system will unbind the LDAP session by using the ldap_unbind function when the store is closed.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvPara">
	/// A 32-bit value that can contain additional information for this function. The contents of this parameter depends on the value of
	/// the lpszStoreProvider and other parameters.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the function returns a handle to the certificate store. When you have finished using the store,
	/// release the handle by calling the CertCloseStore function.
	/// </para>
	/// <para>If the function fails, it returns <c>NULL</c>. For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> CreateFile, ReadFile, or registry errors might be propagated and their error codes returned. <c>CertOpenStore</c>
	/// has a single error code of its own, the ERROR_FILE_NOT_FOUND code, which indicates that the function was unable to find the
	/// provider specified by the lpszStoreProvider parameter.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A system store is a collection that consists of one or more physical sibling stores. For each system store, there are predefined
	/// physical sibling stores. After opening a system store such as "My" at CERT_SYSTEM_STORE_CURRENT_USER, <c>CertOpenStore</c> is
	/// called to open all of the physical stores in the system store collection. Each of these physical stores is added to the system
	/// store collection by using the CertAddStoreToCollection function. All certificates, CRLs, and CTLs in those physical stores are
	/// available through the logical system store collection.
	/// </para>
	/// <para>
	/// <c>Note</c> The order of the certificate context may not be preserved within the store. To access a specific certificate you
	/// must iterate across the certificates in the store.
	/// </para>
	/// <para>The following system store locations can be opened remotely:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_SERVICES</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_USERS</term>
	/// </item>
	/// </list>
	/// <para>
	/// System store locations are opened remotely by prefixing the store name in the string passed to pvPara with the computer name.
	/// Examples of remote system store names are:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ComputerName\CA</term>
	/// </item>
	/// <item>
	/// <term>\\ComputerName\CA</term>
	/// </item>
	/// <item>
	/// <term>ComputerName\ServiceName\Trust</term>
	/// </item>
	/// <item>
	/// <term>\\ComputerName\ServiceName\Trust</term>
	/// </item>
	/// </list>
	/// <para>For more information about system stores, see System Store Locations.</para>
	/// <para>For more information about the stores that are automatically migrated, see Certificate Store Migration.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows opening several certificate stores of different store provider types. The example uses the
	/// <c>CreateMyDACL</c> function, defined in the Creating a DACL topic, to ensure the open file is created with a proper DACL. For
	/// more examples of opening other store provider types, see Example C Code for Opening Certificate Stores.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certopenstore HCERTSTORE CertOpenStore( LPCSTR
	// lpszStoreProvider, DWORD dwEncodingType, HCRYPTPROV_LEGACY hCryptProv, DWORD dwFlags, const void *pvPara );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "4edccbfe-c0a8-442b-b6b7-51ef598e7c90")]
	public static extern SafeHCERTSTORE CertOpenStore([In] SafeOID lpszStoreProvider, CertEncodingType dwEncodingType, [Optional] HCRYPTPROV hCryptProv, CertStoreFlags dwFlags, [Optional] IntPtr pvPara);

	/// <summary>
	/// The <c>CertOpenStore</c> function opens a certificate store by using a specified store provider type. While this function can
	/// open a certificate store for most purposes, CertOpenSystemStore is recommended to open the most common certificate stores.
	/// <c>CertOpenStore</c> is required for more complex options and special cases.
	/// </summary>
	/// <param name="lpszStoreProvider">
	/// <para>A pointer to a null-terminated ANSI string that contains the store provider type.</para>
	/// <para>
	/// The following values represent the predefined store types. The store provider type determines the contents of the pvPara
	/// parameter and the use and meaning of the high word of the dwFlags parameter. Additional store providers can be installed or
	/// registered by using the CryptInstallOIDFunctionAddress or CryptRegisterOIDFunction function. For more information about adding
	/// store providers, see Extending CertOpenStore Functionality.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_PROV_COLLECTION sz_CERT_STORE_PROV_COLLECTION</term>
	/// <term>
	/// Opens a store that will be a collection of other stores. Stores are added to or removed from the collection by using
	/// CertAddStoreToCollection and CertRemoveStoreFromCollection. When a store is added to a collection, all certificates, CRLs, and
	/// CTLs in that store become available to searches or enumerations of the collection store. The high word of dwFlags is set to
	/// zero. pvPara value: The pvPara parameter must be NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_FILE</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs read from a specified open file. This provider expects the file to
	/// contain only a serialized store and not either PKCS #7 signed messages or a single encoded certificate. The file pointer must be
	/// positioned at the beginning of the serialized store information. After the data in the serialized store has been loaded into the
	/// certificate store, the file pointer is positioned at the beginning of any data that can follow the serialized store data in the
	/// file. If CERT_FILE_STORE_COMMIT_ENABLE is set in dwFlags, the file handle is duplicated and the store is always committed as a
	/// serialized store. The file is not closed when the store is closed. pvPara value: The pvPara parameter must contain a pointer to
	/// the handle of a file opened by using CreateFile.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_FILENAME_A</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a file. The provider opens the file and first attempts to read the
	/// file as a serialized store, then as a PKCS #7 signed message, and finally as a single encoded certificate. The dwEncodingType
	/// parameter must contain the encoding types to be used with both messages and certificates. If the file contains an X.509 encoded
	/// certificate, the open operation fails and a call to the GetLastError function will return ERROR_ACCESS_DENIED. If the
	/// CERT_FILE_STORE_COMMIT_ENABLE flag is set in dwFlags, the dwCreationDisposition value passed to CreateFile is as follows: If
	/// dwFlags includes CERT_FILE_STORE_COMMIT_ENABLE, the file is committed as either a PKCS #7 or a serialized store depending on the
	/// file type opened. If the file was empty or if the file name has either a .p7c or .spc extension, the file is committed as a PKCS
	/// #7. Otherwise, the file is committed as a serialized store. pvPara value: The pvPara parameter must contain a pointer to
	/// null-terminated ANSI string that contains the name of an existing, unopened file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_FILENAME(_W) sz_CERT_STORE_PROV_FILENAME(_W)</term>
	/// <term>
	/// Same as CERT_STORE_PROV_FILENAME_A. pvPara value: The pvPara parameter must contain a pointer to null-terminated Unicode string
	/// that contains the name of an existing, unopened file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_LDAP(_W) sz_CERT_STORE_PROV_LDAP(_W)</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from the results of an LDAP query. To perform write operations on the
	/// store, the query string must specify a BASE query with no filter and a single attribute. pvPara value: If the dwFlags parameter
	/// contains CERT_LDAP_STORE_OPENED_FLAG, set pvPara to the address of a CERT_LDAP_STORE_OPENED_PARA structure that specifies the
	/// established LDAP session to use. Otherwise, set pvPara to point to a null-terminated Unicode string that contains the LDAP query
	/// string. For more information about LDAP query strings, see LDAP Dialect.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_MEMORY sz_CERT_STORE_PROV_MEMORY</term>
	/// <term>
	/// Creates a certificate store in cached memory. No certificates, certificate revocation lists (CRLs), or certificate trust lists
	/// (CTLs) are initially loaded into the store. Typically used to create a temporary store. Any addition of certificates, CRLs, or
	/// CTLs or changes in properties of certificates, CRLs, or CTLs in a memory store are not automatically saved. They can be saved to
	/// a file or to a memory BLOB by using CertSaveStore. pvPara value: The pvPara parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_MSG</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from the specified cryptographic message. The dwEncodingType parameter
	/// must contain the encoding types used with both messages and certificates. pvPara value: The pvPara parameter contains an
	/// HCRYPTMSG handle of the encoded message, returned by a call to CryptMsgOpenToDecode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_PHYSICAL(_W) sz_CERT_STORE_PROV_PHYSICAL(_W)</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a specified physical store that is a member of a logical system
	/// store. Two names are separated with an intervening backslash (), for example "Root.Default". Here, "Root" is the name of the
	/// system store and ".Default" is the name of the physical store. The system and physical store names cannot contain any
	/// backslashes. The high word of dwFlags indicates the system store location, usually CERT_SYSTEM_STORE_CURRENT_USER. For more
	/// information, see dwFlags later in this topic and see System Store Locations. Some physical store locations can be opened
	/// remotely. pvPara value: The pvPara parameter points to a null-terminated Unicode string that contains both the system store name
	/// and physical names.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_PKCS7 sz_CERT_STORE_PROV_PKCS7</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from an encoded PKCS #7 signed message. The dwEncodingType parameter
	/// must specify the encoding types to be used with both messages and certificates. pvPara value: The pvPara parameter points to a
	/// CRYPT_DATA_BLOB structure that represents the encoded message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_PKCS12 sz_CERT_STORE_PROV_PKCS12</term>
	/// <term>
	/// Initializes the store with the contents of a PKCS #12 packet. If the PKCS #12 packet is protected with a NULL or empty password,
	/// this function will succeed in opening the store. Beginning with Windows 8 and Windows Server 2012, if the password embedded in
	/// the PFX packet was protected to an Active Directory (AD) principal and the current user, as a member of that principal, has
	/// permission to decrypt the password, this function will succeed in opening the store. For more information, see the pvPara
	/// parameter and the PKCS12_PROTECT_TO_DOMAIN_SIDS flag of the PFXExportCertStoreEx function. You can protect PFX passwords to an
	/// AD principal beginning in Windows 8 and Windows Server 2012. pvPara value: The pvPara parameter points to a CRYPT_DATA_BLOB
	/// structure that represents the PKCS #12 packet.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_REG</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a registry subkey. This provider opens or creates the registry
	/// subkeys Certificates, CRLs, and CTLs under the key passed in pvPara. The input key is not closed by the provider. Before
	/// returning, the provider opens its own copy of the key passed in pvPara. If CERT_STORE_READONLY_FLAG is set in the low word of
	/// dwFlags, registry subkeys are opened by using the RegOpenKey with KEY_READ_ACCESS. Otherwise, registry subkeys are created by
	/// using RegCreateKey with KEY_ALL_ACCESS. Any changes to the contents of the opened store are immediately persisted to the
	/// registry. However, if CERT_STORE_READONLY_FLAG is set in the low word of dwFlags, any attempt to add to the contents of the
	/// store or to change a context's property results in an error with GetLastError returning the E_ACCESSDENIED code. pvPara value:
	/// The pvPara parameter contains the handle of an open registry key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SERIALIZED sz_CERT_STORE_PROV_SERIALIZED</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a memory location that contains a serialized store. pvPara value:
	/// The pvPara parameter points to a CRYPT_DATA_BLOB structure that contains the serialized memory BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SMART_CARD(_W) sz_CERT_STORE_PROV_SMART_CARD(_W)</term>
	/// <term>Not currently used.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SYSTEM_A</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from the specified system store. The system store is a logical,
	/// collection store that consists of one or more physical stores. A physical store associated with a system store is registered
	/// with the CertRegisterPhysicalStore function. After the system store is opened, all of the physical stores that are associated
	/// with it are also opened by calls to CertOpenStore and are added to the system store collection by using the
	/// CertAddStoreToCollection function. The high word of dwFlags indicates the system store location, usually set to
	/// CERT_SYSTEM_STORE_CURRENT_USER. For details about registry locations, see dwFlags later in this topic and System Store
	/// Locations. Some system store locations can be opened remotely; for more information, see System Store Locations. pvPara value:
	/// The pvPara parameter points to a null-terminated ANSI string that contains a system store name, such as "My" or "Root".
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SYSTEM(_W) sz_CERT_STORE_PROV_SYSTEM(_W)</term>
	/// <term>
	/// Same as CERT_STORE_PROV_SYSTEM_A. pvPara value: The pvPara parameter points to a null-terminated Unicode string that contains a
	/// system store name, such as "My" or "Root".
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SYSTEM_REGISTRY_A</term>
	/// <term>
	/// Initializes the store with certificates, CRLs, and CTLs from a physical registry store. The physical store is not opened as a
	/// collection store. Enumerations and searches go through only the certificates, CRLs, and CTLs in that one physical store. The
	/// high word of dwFlags indicates the system store location, usually set to CERT_SYSTEM_STORE_CURRENT_USER. For more information,
	/// see dwFlags later in this topic. Some system store locations can be open remotely; for more information, see System Store
	/// Locations. pvPara value: The pvPara parameter points to a null-terminated ANSI string that contains a system store name, such as
	/// "My" or "Root".
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_PROV_SYSTEM_REGISTRY(_W) sz_CERT_STORE_PROV_SYSTEM_REGISTRY(_W)</term>
	/// <term>
	/// Same as CERT_STORE_PROV_SYSTEM_REGISTRY_A. pvPara value: The pvPara parameter points to a null-terminated Unicode string that
	/// contains a system store name, such as "My" or "Root".
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the certificate encoding type and message encoding type. Encoding is used only when the dwSaveAs parameter of the
	/// CertSaveStore function contains <c>CERT_STORE_SAVE_AS_PKCS7</c>. Otherwise, the dwMsgAndCertEncodingType parameter is not used.
	/// </para>
	/// <para>
	/// This parameter is only applicable when the <c>CERT_STORE_PROV_MSG</c>, <c>CERT_STORE_PROV_PKCS7</c>, or
	/// <c>CERT_STORE_PROV_FILENAME</c> provider type is specified in the lpszStoreProvider parameter. For all other provider types,
	/// this parameter is unused and should be set to zero.
	/// </para>
	/// <para>This parameter can be a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS #7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> A handle to a cryptographic provider. Passing <c>NULL</c> for this parameter causes
	/// an appropriate, default provider to be used. Using the default provider is recommended. The default or specified cryptographic
	/// provider is used for all store functions that verify the signature of a subject certificate or CRL.This parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>These values consist of high-word and low-word values combined by using a bitwise- <c>OR</c> operation.</para>
	/// <para>
	/// The low-word portion of dwFlags controls a variety of general characteristics of the certificate store opened. This portion can
	/// be used with all store provider types. The low-word portion of dwFlags can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_BACKUP_RESTORE_FLAG</term>
	/// <term>
	/// Use the thread's SE_BACKUP_NAME and SE_RESTORE_NAME privileges to open registry or file-based system stores. If the thread does
	/// not have these privileges, this function must fail with an access denied error.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CREATE_NEW_FLAG</term>
	/// <term>
	/// A new store is created if one did not exist. The function fails if the store already exists. If neither
	/// CERT_STORE_OPEN_EXISTING_FLAG nor CERT_STORE_CREATE_NEW_FLAG is set, a store is opened if it exists or is created and opened if
	/// it did not already exist.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_DEFER_CLOSE_UNTIL_LAST_FREE_FLAG</term>
	/// <term>
	/// Defer closing of the store's provider until all certificates, CRLs, or CTLs obtained from the store are no longer in use. The
	/// store is actually closed when the last certificate, CRL, or CTL obtained from the store is freed. Any changes made to properties
	/// of these certificates, CRLs, and CTLs, even after the call to CertCloseStore, are persisted. If this flag is not set and
	/// certificates, CRLs, or CTLs obtained from the store are still in use, any changes to the properties of those certificates, CRLs,
	/// and CTLs will not be persisted. If this function is called with CERT_CLOSE_STORE_FORCE_FLAG,
	/// CERT_STORE_DEFER_CLOSE_UNTIL_LAST_FREE_FLAG is ignored. When this flag is set and a non-NULL hCryptProv parameter value is
	/// passed, that provider will continue to be used even after the call to this function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_DELETE_FLAG</term>
	/// <term>
	/// The store is deleted instead of being opened. This function returns NULL for both success and failure of the deletion. To
	/// determine the success of the deletion, call GetLastError, which returns zero if the store was deleted and a nonzero value if it
	/// was not deleted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ENUM_ARCHIVED_FLAG</term>
	/// <term>
	/// Normally, an enumeration of all certificates in the store will ignore any certificate with the CERT_ARCHIVED_PROP_ID property
	/// set. If this flag is set, an enumeration of the certificates in the store will contain all of the certificates in the store,
	/// including those that have the CERT_ARCHIVED_PROP_ID property.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_MAXIMUM_ALLOWED_FLAG</term>
	/// <term>
	/// Open the store with the maximum set of allowed permissions. If this flag is specified, registry stores are first opened with
	/// write access and if that fails, they are reopened with read-only access.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_NO_CRYPT_RELEASE_FLAG</term>
	/// <term>
	/// This flag is not used when the hCryptProv parameter is NULL. This flag is only valid when a non-NULL CSP handle is passed as the
	/// hCryptProv parameter. Setting this flag prevents the automatic release of a nondefault CSP when the certificate store is closed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_OPEN_EXISTING_FLAG</term>
	/// <term>Only open an existing store. If the store does not exist, the function fails.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_READONLY_FLAG</term>
	/// <term>
	/// Open the store in read-only mode. Any attempt to change the contents of the store will result in an error. When this flag is set
	/// and a registry based store provider is being used, the registry subkeys are opened by using RegOpenKey with KEY_READ_ACCESS.
	/// Otherwise, the registry subkeys are created by using RegCreateKey with KEY_ALL_ACCESS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SET_LOCALIZED_NAME_FLAG</term>
	/// <term>
	/// If this flag is supported, the provider sets the store's CERT_STORE_LOCALIZED_NAME_PROP_ID property. The localized name can be
	/// retrieved by calling the CertGetStoreProperty function with dwPropID set to CERT_STORE_LOCALIZED_NAME_PROP_ID. This flag is
	/// supported for providers of types CERT_STORE_PROV_FILENAME, CERT_STORE_PROV_SYSTEM, CERT_STORE_PROV_SYSTEM_REGISTRY, and CERT_STORE_PROV_PHYSICAL_W.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SHARE_CONTEXT_FLAG</term>
	/// <term>
	/// When opening a store multiple times, you can set this flag to ensure efficient memory usage by reusing the memory for the
	/// encoded parts of a certificate, CRL, or CTL context across the opened instances of the stores.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_UPDATE_KEYID_FLAG</term>
	/// <term>
	/// Lists of key identifiers exist within CurrentUser and LocalMachine. These key identifiers have properties much like the
	/// properties of certificates. If the CERT_STORE_UPDATE_KEYID_FLAG is set, then for every key identifier in the store's location
	/// that has a CERT_KEY_PROV_INFO_PROP_ID property, that property is automatically updated from the key identifier property
	/// CERT_KEY_PROV_INFO_PROP_ID or the CERT_KEY_IDENTIFIER_PROP_ID of the certificate related to that key identifier.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>CERT_STORE_PROV_SYSTEM</c>, <c>CERT_STORE_PROV_SYSTEM_REGISTRY</c>, and <c>CERT_STORE_PROV_PHYSICAL</c> provider types
	/// use the following high words of dwFlags to specify system store registry locations:
	/// </para>
	/// <para>CERT_SYSTEM_STORE_CURRENT_SERVICE</para>
	/// <para>CERT_SYSTEM_STORE_CURRENT_USER</para>
	/// <para>CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY</para>
	/// <para>CERT_SYSTEM_STORE_LOCAL_MACHINE</para>
	/// <para>CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE</para>
	/// <para>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</para>
	/// <para>CERT_SYSTEM_STORE_SERVICES</para>
	/// <para>CERT_SYSTEM_STORE_USERS</para>
	/// <para>
	/// By default, a system store location is opened relative to the <c>HKEY_CURRENT_USER</c>, <c>HKEY_LOCAL_MACHINE</c>, or
	/// <c>HKEY_USERS</c> predefined registry key. For more information, see System Store Locations.
	/// </para>
	/// <para>The following high-word flags override this default behavior.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// When set, pvPara must contain a pointer to a CERT_SYSTEM_STORE_RELOCATE_PARA structure rather than a string. The structure
	/// indicates both the name of the store and its location in the registry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_UNPROTECTED_FLAG</term>
	/// <term>
	/// By default, when the CurrentUser "Root" store is opened, any SystemRegistry roots not on the protected root list are deleted
	/// from the cache before this function returns. When this flag is set, this default is overridden and all of the roots in the
	/// SystemRegistry are returned and no check of the protected root list is made.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The <c>CERT_STORE_PROV_REGISTRY</c> provider uses the following high-word flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_REGISTRY_STORE_REMOTE_FLAG</term>
	/// <term>
	/// pvPara contains a handle to a registry key on a remote computer. To access a registry key on a remote computer, security
	/// permissions on the remote computer must be set to allow access. For more information, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_REGISTRY_STORE_SERIALIZED_FLAG</term>
	/// <term>
	/// The CERT_STORE_PROV_REG provider saves certificates, CRLs, and CTLs in a single serialized store subkey instead of performing
	/// the default save operation. The default is that each certificate, CRL, or CTL is saved as a separate registry subkey under the
	/// appropriate subkey. This flag is mainly used for stores downloaded from the group policy template (GPT), such as the
	/// CurrentUserGroupPolicy and LocalMachineGroupPolicy stores. When CERT_REGISTRY_STORE_SERIALIZED_FLAG is set, store additions,
	/// deletions, or property changes are not persisted until there is a call to either CertCloseStore or CertControlStore using CERT_STORE_CTRL_COMMIT.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The <c>CERT_STORE_PROV_FILE</c> and <c>CERT_STORE_PROV_FILENAME</c> provider types use the following high-word flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_FILE_STORE_COMMIT_ENABLE</term>
	/// <term>
	/// Setting this flag commits any additions to the store or any changes made to properties of contexts in the store to the file
	/// store either when CertCloseStore is called or when CertControlStore is called with CERT_STORE_CONTROL_COMMIT. CertOpenStore
	/// fails with E_INVALIDARG if both CERT_FILE_STORE_COMMIT_ENABLE and CERT_STORE_READONLY_FLAG are set in dwFlags.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The <c>CERT_STORE_PROV_LDAP</c> provider type uses the following high-word flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_LDAP_STORE_AREC_EXCLUSIVE_FLAG</term>
	/// <term>
	/// Performs an A-Record-only DNS lookup on the URL named in the pvPara parameter. This prevents false DNS queries from being
	/// generated when resolving URL host names. Use this flag when passing a host name as opposed to a domain name for the pvPara parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_LDAP_STORE_OPENED_FLAG</term>
	/// <term>
	/// Use this flag to use an existing LDAP session. When this flag is specified, the pvPara parameter is the address of a
	/// CERT_LDAP_STORE_OPENED_PARA structure that contains information about the LDAP session to use.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_LDAP_STORE_SIGN_FLAG</term>
	/// <term>
	/// To provide integrity required by some applications, digitally sign all LDAP traffic to and from an LDAP server by using the
	/// Kerberos authentication protocol.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_LDAP_STORE_UNBIND_FLAG</term>
	/// <term>
	/// Use this flag with the CERT_LDAP_STORE_OPENED_FLAG flag to cause the LDAP session to be unbound when the store is closed. The
	/// system will unbind the LDAP session by using the ldap_unbind function when the store is closed.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvPara">
	/// A 32-bit value that can contain additional information for this function. The contents of this parameter depends on the value of
	/// the lpszStoreProvider and other parameters.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the function returns a handle to the certificate store. When you have finished using the store,
	/// release the handle by calling the CertCloseStore function.
	/// </para>
	/// <para>If the function fails, it returns <c>NULL</c>. For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> CreateFile, ReadFile, or registry errors might be propagated and their error codes returned. <c>CertOpenStore</c>
	/// has a single error code of its own, the ERROR_FILE_NOT_FOUND code, which indicates that the function was unable to find the
	/// provider specified by the lpszStoreProvider parameter.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A system store is a collection that consists of one or more physical sibling stores. For each system store, there are predefined
	/// physical sibling stores. After opening a system store such as "My" at CERT_SYSTEM_STORE_CURRENT_USER, <c>CertOpenStore</c> is
	/// called to open all of the physical stores in the system store collection. Each of these physical stores is added to the system
	/// store collection by using the CertAddStoreToCollection function. All certificates, CRLs, and CTLs in those physical stores are
	/// available through the logical system store collection.
	/// </para>
	/// <para>
	/// <c>Note</c> The order of the certificate context may not be preserved within the store. To access a specific certificate you
	/// must iterate across the certificates in the store.
	/// </para>
	/// <para>The following system store locations can be opened remotely:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_SERVICES</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_USERS</term>
	/// </item>
	/// </list>
	/// <para>
	/// System store locations are opened remotely by prefixing the store name in the string passed to pvPara with the computer name.
	/// Examples of remote system store names are:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ComputerName\CA</term>
	/// </item>
	/// <item>
	/// <term>\\ComputerName\CA</term>
	/// </item>
	/// <item>
	/// <term>ComputerName\ServiceName\Trust</term>
	/// </item>
	/// <item>
	/// <term>\\ComputerName\ServiceName\Trust</term>
	/// </item>
	/// </list>
	/// <para>For more information about system stores, see System Store Locations.</para>
	/// <para>For more information about the stores that are automatically migrated, see Certificate Store Migration.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows opening several certificate stores of different store provider types. The example uses the
	/// <c>CreateMyDACL</c> function, defined in the Creating a DACL topic, to ensure the open file is created with a proper DACL. For
	/// more examples of opening other store provider types, see Example C Code for Opening Certificate Stores.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certopenstore HCERTSTORE CertOpenStore( LPCSTR
	// lpszStoreProvider, DWORD dwEncodingType, HCRYPTPROV_LEGACY hCryptProv, DWORD dwFlags, const void *pvPara );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "4edccbfe-c0a8-442b-b6b7-51ef598e7c90")]
	public static extern SafeHCERTSTORE CertOpenStore([In] SafeOID lpszStoreProvider, CertEncodingType dwEncodingType, [Optional] HCRYPTPROV hCryptProv, CertStoreFlags dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string? pvPara);

	/// <summary>
	/// The <c>CertOpenSystemStore</c> function is a simplified function that opens the most common system certificate store. To open
	/// certificate stores with more complex requirements, such as file-based or memory-based stores, use CertOpenStore.
	/// </summary>
	/// <param name="hProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> A handle of a cryptographic service provider (CSP). Set hProv to <c>NULL</c> to use
	/// the default CSP. If hProv is not <c>NULL</c>, it must be a CSP handle created by using the CryptAcquireContext function.This
	/// parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// </param>
	/// <param name="szSubsystemProtocol">
	/// <para>
	/// A string that names a system store. If the system store name provided in this parameter is not the name of an existing system
	/// store, a new system store will be created and used. CertEnumSystemStore can be used to list the names of existing system stores.
	/// Some example system stores are listed in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CA</term>
	/// <term>Certification authority certificates.</term>
	/// </item>
	/// <item>
	/// <term>MY</term>
	/// <term>A certificate store that holds certificates with associated private keys.</term>
	/// </item>
	/// <item>
	/// <term>ROOT</term>
	/// <term>Root certificates.</term>
	/// </item>
	/// <item>
	/// <term>SPC</term>
	/// <term>Software Publisher Certificate.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns a handle to the certificate store.</para>
	/// <para>If the function fails, it returns <c>NULL</c>. For extended error information, call GetLastError.</para>
	/// <para><c>Note</c> Errors from the called function CertOpenStore are propagated to this function.</para>
	/// </returns>
	/// <remarks>
	/// <para>Only current user certificates are accessible using this method, not the local machine store.</para>
	/// <para>After the system store is opened, all the standard certificate store functions can be used to manipulate the certificates.</para>
	/// <para>After use, the store should be closed by using CertCloseStore.</para>
	/// <para>For more information about the stores that are automatically migrated, see Certificate Store Migration.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows a simplified method for opening the most common system certificate stores. For another example that
	/// uses this function, see Example C Program: Certificate Store Operations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certopensystemstorea HCERTSTORE CertOpenSystemStoreA(
	// HCRYPTPROV_LEGACY hProv, LPCSTR szSubsystemProtocol );
	[DllImport(Lib.Crypt32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "23699439-1a6c-4907-93fa-651024856be7")]
	public static extern SafeHCERTSTORE CertOpenSystemStore([Optional] IntPtr hProv, string szSubsystemProtocol);

	/// <summary>The <c>CertRegisterPhysicalStore</c> function adds a physical store to a registry system store collection.</summary>
	/// <param name="pvSystemStore">
	/// The system store collection to which the physical store is added. This parameter points either to a <c>null</c>-terminated
	/// Unicode string or to a CERT_SYSTEM_STORE_RELOCATE_PARA structure. For information about using the structure and on adding a
	/// ServiceName or ComputerName before the system store name string, see CertRegisterSystemStore.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The high word of the dwFlags parameter specifies the location of the system store. For information about defined high-word flags
	/// and appending ServiceName, UserNames, and ComputerNames to the end of the system store name, see CertRegisterSystemStore.
	/// </para>
	/// <para>The following low-word flags are also defined and can be combined with high-word flags using a bitwise- <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// The system store is not in its default registry location and the pvSystemStore parameter must be a pointer to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CREATE_NEW_FLAG</term>
	/// <term>The function fails if the physical store already exists in the store location.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pwszStoreName">
	/// A pointer to a Unicode string that names the physical store to be added to the system store collection. To remove a physical
	/// store from the system store collection, call the CertUnregisterPhysicalStore function.
	/// </param>
	/// <param name="pStoreInfo">
	/// A pointer to a CERT_PHYSICAL_STORE_INFO structure that provides basic information about the physical store.
	/// </param>
	/// <param name="pvReserved">Reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certregisterphysicalstore BOOL CertRegisterPhysicalStore(
	// const void *pvSystemStore, DWORD dwFlags, LPCWSTR pwszStoreName, PCERT_PHYSICAL_STORE_INFO pStoreInfo, void *pvReserved );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e301c76d-cacd-441a-b925-754b07e4bfa9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertRegisterPhysicalStore([MarshalAs(UnmanagedType.LPWStr)] string pvSystemStore, uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pwszStoreName, in CERT_PHYSICAL_STORE_INFO pStoreInfo, IntPtr pvReserved = default);

	/// <summary>The <c>CertRegisterPhysicalStore</c> function adds a physical store to a registry system store collection.</summary>
	/// <param name="pvSystemStore">
	/// The system store collection to which the physical store is added. This parameter points either to a <c>null</c>-terminated
	/// Unicode string or to a CERT_SYSTEM_STORE_RELOCATE_PARA structure. For information about using the structure and on adding a
	/// ServiceName or ComputerName before the system store name string, see CertRegisterSystemStore.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The high word of the dwFlags parameter specifies the location of the system store. For information about defined high-word flags
	/// and appending ServiceName, UserNames, and ComputerNames to the end of the system store name, see CertRegisterSystemStore.
	/// </para>
	/// <para>The following low-word flags are also defined and can be combined with high-word flags using a bitwise- <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// The system store is not in its default registry location and the pvSystemStore parameter must be a pointer to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CREATE_NEW_FLAG</term>
	/// <term>The function fails if the physical store already exists in the store location.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pwszStoreName">
	/// A pointer to a Unicode string that names the physical store to be added to the system store collection. To remove a physical
	/// store from the system store collection, call the CertUnregisterPhysicalStore function.
	/// </param>
	/// <param name="pStoreInfo">
	/// A pointer to a CERT_PHYSICAL_STORE_INFO structure that provides basic information about the physical store.
	/// </param>
	/// <param name="pvReserved">Reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certregisterphysicalstore BOOL CertRegisterPhysicalStore(
	// const void *pvSystemStore, DWORD dwFlags, LPCWSTR pwszStoreName, PCERT_PHYSICAL_STORE_INFO pStoreInfo, void *pvReserved );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e301c76d-cacd-441a-b925-754b07e4bfa9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertRegisterPhysicalStore(in CERT_SYSTEM_STORE_RELOCATE_PARA pvSystemStore, uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pwszStoreName, in CERT_PHYSICAL_STORE_INFO pStoreInfo, IntPtr pvReserved = default);

	/// <summary>The <c>CertRegisterSystemStore</c> function registers a system store.</summary>
	/// <param name="pvSystemStore">
	/// <para>
	/// Identifies the system store to be registered. If CERT_SYSTEM_STORE_RELOCATE_FLAG is set in the dwFlags parameter, pvSystemStore
	/// points to a CERT_SYSTEM_STORE_RELOCATE_PARA structure. Otherwise, it points to a <c>null</c>-terminated Unicode string that
	/// names the system store.
	/// </para>
	/// <para>
	/// With appropriate settings in dwFlags, the identified store can be a system store on a remote local computer. Stores on remote
	/// computers can be registered with the computer name as a prefix to the name of the system store. For example, a remote local
	/// computer store can be registered with pvSystemStore pointing to the string "\ComputerName\Trust" or "ComputerName\Trust".
	/// </para>
	/// <para>Leading "\" backslashes are optional before a ComputerName.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>The high word of the dwFlags parameter is used to specify the location of the system store.</para>
	/// <para>The following high-word values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_SERVICE</term>
	/// <term>pvSystemStore can be a system store name that is prefixed with the ServiceName.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER</term>
	/// <term>pvSystemStore can be a system store name that is prefixed with the UserName.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
	/// <term>pvSystemStore can be a system store that is on a remote computer.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
	/// <term>pvSystemStore is a group policy store and can be on a remote computer.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_SERVICES</term>
	/// <term>pvSystemStore must be a system store name prefixed with the ServiceName.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_USERS</term>
	/// <term>pvSystemStore must be a system store name that is prefixed with the UserName.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Stores on remote computers can be registered for CERT_SYSTEM_STORE_LOCAL_MACHINE, CERT_SYSTEM_STORE_SERVICES,
	/// CERT_SYSTEM_STORE_USERS, or CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY.
	/// </para>
	/// <para>
	/// The following low-word values are also defined and can be combined using a bitwise- <c>OR</c> operation with high-word values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// The system store is not in its default register location and pvSystemStore must be a pointer to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CREATE_NEW_FLAG</term>
	/// <term>The function fails if the system store already exists in the store location.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pStoreInfo">Reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pvReserved">Reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>To unregister a system store that has been registered by this function, call CertUnregisterSystemStore.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows adding a system store to a registry system store collection. For an example that includes the
	/// complete context for this example, see Example C Program: Listing System and Physical Stores.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certregistersystemstore BOOL CertRegisterSystemStore(
	// const void *pvSystemStore, DWORD dwFlags, PCERT_SYSTEM_STORE_INFO pStoreInfo, void *pvReserved );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b6f72826-92ab-4e21-8db9-eb053663148b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertRegisterSystemStore([MarshalAs(UnmanagedType.LPWStr)] string pvSystemStore, uint dwFlags, in CERT_SYSTEM_STORE_INFO pStoreInfo, IntPtr pvReserved = default);

	/// <summary>The <c>CertRegisterSystemStore</c> function registers a system store.</summary>
	/// <param name="pvSystemStore">
	/// <para>
	/// Identifies the system store to be registered. If CERT_SYSTEM_STORE_RELOCATE_FLAG is set in the dwFlags parameter, pvSystemStore
	/// points to a CERT_SYSTEM_STORE_RELOCATE_PARA structure. Otherwise, it points to a <c>null</c>-terminated Unicode string that
	/// names the system store.
	/// </para>
	/// <para>
	/// With appropriate settings in dwFlags, the identified store can be a system store on a remote local computer. Stores on remote
	/// computers can be registered with the computer name as a prefix to the name of the system store. For example, a remote local
	/// computer store can be registered with pvSystemStore pointing to the string "\ComputerName\Trust" or "ComputerName\Trust".
	/// </para>
	/// <para>Leading "\" backslashes are optional before a ComputerName.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>The high word of the dwFlags parameter is used to specify the location of the system store.</para>
	/// <para>The following high-word values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_SERVICE</term>
	/// <term>pvSystemStore can be a system store name that is prefixed with the ServiceName.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_CURRENT_USER</term>
	/// <term>pvSystemStore can be a system store name that is prefixed with the UserName.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
	/// <term>pvSystemStore can be a system store that is on a remote computer.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
	/// <term>pvSystemStore is a group policy store and can be on a remote computer.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_SERVICES</term>
	/// <term>pvSystemStore must be a system store name prefixed with the ServiceName.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_USERS</term>
	/// <term>pvSystemStore must be a system store name that is prefixed with the UserName.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Stores on remote computers can be registered for CERT_SYSTEM_STORE_LOCAL_MACHINE, CERT_SYSTEM_STORE_SERVICES,
	/// CERT_SYSTEM_STORE_USERS, or CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY.
	/// </para>
	/// <para>
	/// The following low-word values are also defined and can be combined using a bitwise- <c>OR</c> operation with high-word values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// The system store is not in its default register location and pvSystemStore must be a pointer to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CREATE_NEW_FLAG</term>
	/// <term>The function fails if the system store already exists in the store location.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pStoreInfo">Reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pvReserved">Reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>To unregister a system store that has been registered by this function, call CertUnregisterSystemStore.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows adding a system store to a registry system store collection. For an example that includes the
	/// complete context for this example, see Example C Program: Listing System and Physical Stores.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certregistersystemstore BOOL CertRegisterSystemStore(
	// const void *pvSystemStore, DWORD dwFlags, PCERT_SYSTEM_STORE_INFO pStoreInfo, void *pvReserved );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b6f72826-92ab-4e21-8db9-eb053663148b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertRegisterSystemStore(in CERT_SYSTEM_STORE_RELOCATE_PARA pvSystemStore, uint dwFlags, in CERT_SYSTEM_STORE_INFO pStoreInfo, IntPtr pvReserved = default);

	/// <summary>The <c>CertRemoveStoreFromCollection</c> function removes a sibling certificate store from a collection store.</summary>
	/// <param name="hCollectionStore">A handle of the collection certificate store.</param>
	/// <param name="hSiblingStore">Handle of the sibling certificate store to be removed from the collection store.</param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certremovestorefromcollection void
	// CertRemoveStoreFromCollection( HCERTSTORE hCollectionStore, HCERTSTORE hSiblingStore );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e1564848-8b39-4ea9-9148-142ceaaaed15")]
	public static extern void CertRemoveStoreFromCollection(HCERTSTORE hCollectionStore, HCERTSTORE hSiblingStore);

	/// <summary>The <c>CertSaveStore</c> function saves the certificate store to a file or to a memory BLOB.</summary>
	/// <param name="hCertStore">The handle of the certificate store to be saved.</param>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the certificate encoding type and message encoding type. Encoding is used only when dwSaveAs contains
	/// <c>CERT_STORE_SAVE_AS_PKCS7</c>. Otherwise, the dwMsgAndCertEncodingType parameter is not used.
	/// </para>
	/// <para>This parameter can be a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS 7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwSaveAs">
	/// <para>Specifies how to save the certificate store.</para>
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_SAVE_AS_PKCS7 2</term>
	/// <term>
	/// The certificate store can be saved as a PKCS #7 signed message that does not include additional properties. The dwEncodingType
	/// parameter specifies the message encoding type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SAVE_AS_STORE 1</term>
	/// <term>
	/// The certificate store can be saved as a serialized store containing properties in addition to encoded certificates, certificate
	/// revocation lists (CRLs), and certificate trust lists (CTLs). The dwEncodingType parameter is ignored.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwSaveTo">
	/// <para>
	/// Specifies where and how to save the certificate store. The contents of this parameter determines the format of the pvSaveToPara parameter.
	/// </para>
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_SAVE_TO_FILE 1</term>
	/// <term>
	/// The function saves the certificate store to a file. The pvSaveToPara parameter contains a handle to a file previously obtained
	/// by using the CreateFile function. The file must be opened with write permission. After a successful save operation, the file
	/// pointer is positioned after the last write operation.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SAVE_TO_FILENAME 4</term>
	/// <term>
	/// The function saves the certificate store to a file. The pvSaveToPara parameter contains a pointer to a null-terminated Unicode
	/// string that contains the path and file name of the file to save to. The function opens the file, saves to it, and closes it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SAVE_TO_FILENAME_A 3</term>
	/// <term>
	/// The function saves the certificate store to a file. The pvSaveToPara parameter contains a pointer to a null-terminated ANSI
	/// string that contains the path and file name of the file to save to. The function opens the file, saves to it, and closes it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SAVE_TO_FILENAME_W 4</term>
	/// <term>
	/// The function saves the certificate store to a file. The pvSaveToPara parameter contains a pointer to a null-terminated Unicode
	/// string that contains the path and file name of the file to save to. The function opens the file, saves to it, and closes it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SAVE_TO_MEMORY 2</term>
	/// <term>
	/// The function saves the certificate store to a memory BLOB. The pvSaveToPara parameter contains a pointer to a CERT_BLOB
	/// structure. Before use, the CERT_BLOB's pbData and cbData members must be initialized. Upon return, cbData is updated with the
	/// actual length. For a length-only calculation, pbData must be set to NULL. If pbData is non-NULL and cbData is not large enough,
	/// the function returns zero with a last error code of ERROR_MORE_DATA.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvSaveToPara">
	/// A pointer that represents where the store should be saved to. The contents of this parameter depends on the value of the
	/// dwSaveTo parameter.
	/// </param>
	/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// <para>
	/// Note that CreateFile or WriteFile errors can be propagated to this function. One possible error code is
	/// <c>CRYPT_E_FILE_ERROR</c> which indicates that an error occurred while writing to the file.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certsavestore BOOL CertSaveStore( HCERTSTORE hCertStore,
	// DWORD dwEncodingType, DWORD dwSaveAs, DWORD dwSaveTo, void *pvSaveToPara, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5cc818d7-b079-4962-aabc-fc512d4e92ac")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertSaveStore(HCERTSTORE hCertStore, CertEncodingType dwEncodingType, CertStoreSaveAs dwSaveAs, CertStoreSaveTo dwSaveTo, IntPtr pvSaveToPara, uint dwFlags = 0);

	/// <summary>The <c>CertSetStoreProperty</c> function sets a store property.</summary>
	/// <param name="hCertStore">Handle for the certificate store.</param>
	/// <param name="dwPropId">
	/// Indicates one of a range of store properties. Values for user-defined properties must be outside the current range of predefined
	/// context property values. Currently, user-defined dwPropId values begin at 4,096. There is one predefined store property,
	/// CERT_STORE_LOCALIZED_NAME_PROP_ID, the localized name of the store.
	/// </param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="pvData">
	/// <para>
	/// The type definition for pvData depends on the dwPropId value. If dwPropId is CERT_STORE_LOCALIZED_NAME_PROP_ID, pvData points to
	/// a CRYPT_DATA_BLOB structure. The <c>pbData</c> member of that structure is a pointer to a <c>null</c>-terminated Unicode
	/// character string. The <c>cbData</c> member of that structure is a <c>DWORD</c> value holding the length of the string.
	/// </para>
	/// <para>For user-defined dwPropId values, pvData is a pointer to an encoded CRYPT_DATA_BLOB.</para>
	/// <para>If a value already exists for the selected property, the old value is replaced.</para>
	/// <para>Calling this function with pvData set to <c>NULL</c> deletes a property.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Store property identifiers are properties applicable to an entire store. They are not properties for an individual certificate,
	/// CRL, or CTL context. Currently, no store properties are persisted.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows setting the localized name property of an open certificate store.</para>
	/// <para>For another example that uses this function, see Example C Program: Setting and Getting Certificate Store Properties.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certsetstoreproperty BOOL CertSetStoreProperty(
	// HCERTSTORE hCertStore, DWORD dwPropId, DWORD dwFlags, const void *pvData );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e043486d-9a6e-46c0-b258-6f8d463bf6fe")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertSetStoreProperty(HCERTSTORE hCertStore, uint dwPropId, [Optional] uint dwFlags, [Optional] IntPtr pvData);

	/// <summary>
	/// The <c>CertUnregisterPhysicalStore</c> function removes a physical store from a specified system store collection.
	/// <c>CertUnregisterPhysicalStore</c> can also be used to delete the physical store.
	/// </summary>
	/// <param name="pvSystemStore">
	/// A pointer to an identifier of the system store collection from which the physical store is to be removed. It is either to a
	/// null-terminated Unicode string or to a CERT_SYSTEM_STORE_RELOCATE_PARA structure. For information about using the structure and
	/// on appending a ServiceName or ComputerName to the end of the system store name string, see CertRegisterSystemStore.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The high word of the dwFlags parameter specifies the location of the system store. For information about defined high-word flags
	/// and on appending ServiceName, UserNames, and ComputerNames to the end of the system store name, see CertRegisterSystemStore.
	/// </para>
	/// <para>
	/// The following low-word values are also defined. They can be combined using bitwise- <c>OR</c> operations with high-word values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// The system store is not in its default registry location and pvSystemStore must be a pointer to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_DELETE_FLAG</term>
	/// <term>The physical store is first removed from the system store collection and is then deleted.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pwszStoreName">Null-terminated Unicode string that contains the name of the physical store.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certunregisterphysicalstore BOOL
	// CertUnregisterPhysicalStore( const void *pvSystemStore, DWORD dwFlags, LPCWSTR pwszStoreName );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "06480a2f-5a94-4cf5-9774-ceb9499e1d44")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertUnregisterPhysicalStore([MarshalAs(UnmanagedType.LPWStr)] string pvSystemStore, CertStoreFlags dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pwszStoreName);

	/// <summary>
	/// The <c>CertUnregisterPhysicalStore</c> function removes a physical store from a specified system store collection.
	/// <c>CertUnregisterPhysicalStore</c> can also be used to delete the physical store.
	/// </summary>
	/// <param name="pvSystemStore">
	/// A pointer to an identifier of the system store collection from which the physical store is to be removed. It is either to a
	/// null-terminated Unicode string or to a CERT_SYSTEM_STORE_RELOCATE_PARA structure. For information about using the structure and
	/// on appending a ServiceName or ComputerName to the end of the system store name string, see CertRegisterSystemStore.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The high word of the dwFlags parameter specifies the location of the system store. For information about defined high-word flags
	/// and on appending ServiceName, UserNames, and ComputerNames to the end of the system store name, see CertRegisterSystemStore.
	/// </para>
	/// <para>
	/// The following low-word values are also defined. They can be combined using bitwise- <c>OR</c> operations with high-word values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// The system store is not in its default registry location and pvSystemStore must be a pointer to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_DELETE_FLAG</term>
	/// <term>The physical store is first removed from the system store collection and is then deleted.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pwszStoreName">Null-terminated Unicode string that contains the name of the physical store.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certunregisterphysicalstore BOOL
	// CertUnregisterPhysicalStore( const void *pvSystemStore, DWORD dwFlags, LPCWSTR pwszStoreName );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "06480a2f-5a94-4cf5-9774-ceb9499e1d44")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertUnregisterPhysicalStore(in CERT_SYSTEM_STORE_RELOCATE_PARA pvSystemStore, CertStoreFlags dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pwszStoreName);

	/// <summary>The <c>CertUnregisterSystemStore</c> function unregisters a specified system store.</summary>
	/// <param name="pvSystemStore">
	/// Identifies the system store to be unregistered. It points either to a null-terminated Unicode string or to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure. For information about using the structure and on appending a ServiceName or
	/// ComputerName to the end of the system store name string, see CertRegisterSystemStore.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The high word of the dwFlags parameter specifies the location of the system store. For information about defined high-word flags
	/// and on appending ServiceName, UserNames, and ComputerNames to the end of the system store name, see CertRegisterSystemStore.
	/// </para>
	/// <para>The following low-word values are also defined and can be combined with high-word values using a bitwise- <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// The system store is not in its default registry location and pvSystemStore must be a pointer to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_DELETE_FLAG</term>
	/// <term>The system store is deleted after it has been unregistered.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certunregistersystemstore BOOL CertUnregisterSystemStore(
	// const void *pvSystemStore, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "958e4185-4c37-450c-abfc-91b95593227e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertUnregisterSystemStore([MarshalAs(UnmanagedType.LPWStr)] string pvSystemStore, uint dwFlags);

	/// <summary>The <c>CertUnregisterSystemStore</c> function unregisters a specified system store.</summary>
	/// <param name="pvSystemStore">
	/// Identifies the system store to be unregistered. It points either to a null-terminated Unicode string or to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure. For information about using the structure and on appending a ServiceName or
	/// ComputerName to the end of the system store name string, see CertRegisterSystemStore.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The high word of the dwFlags parameter specifies the location of the system store. For information about defined high-word flags
	/// and on appending ServiceName, UserNames, and ComputerNames to the end of the system store name, see CertRegisterSystemStore.
	/// </para>
	/// <para>The following low-word values are also defined and can be combined with high-word values using a bitwise- <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
	/// <term>
	/// The system store is not in its default registry location and pvSystemStore must be a pointer to a
	/// CERT_SYSTEM_STORE_RELOCATE_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_DELETE_FLAG</term>
	/// <term>The system store is deleted after it has been unregistered.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certunregistersystemstore BOOL CertUnregisterSystemStore(
	// const void *pvSystemStore, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "958e4185-4c37-450c-abfc-91b95593227e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertUnregisterSystemStore(in CERT_SYSTEM_STORE_RELOCATE_PARA pvSystemStore, uint dwFlags);

	/// <summary>
	/// The <c>CERT_CREATE_CONTEXT_PARA</c> structure defines additional values that can be used when calling the CertCreateContext function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_create_context_para typedef struct
	// _CERT_CREATE_CONTEXT_PARA { DWORD cbSize; PFN_CRYPT_FREE pfnFree; void *pvFree; PFN_CERT_CREATE_CONTEXT_SORT_FUNC pfnSort; void
	// *pvSort; } CERT_CREATE_CONTEXT_PARA, *PCERT_CREATE_CONTEXT_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "1486cb60-56f0-4ce4-b283-6f92dcbbea26")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_CREATE_CONTEXT_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// A pointer to the function that frees the pbEncoded parameter of the CertCreateContext function. The <c>pfnFree</c> function
		/// is called when the context created by <c>CertCreateContext</c> is freed. This value can be <c>NULL</c>, in which case the
		/// pbEncoded parameter of the <c>CertCreateContext</c> function is not freed.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFN_CRYPT_FREE pfnFree;

		/// <summary>
		/// The address of the memory that gets freed by the <c>pfnFree</c> function. If <c>pvFree</c> is <c>NULL</c>, then the
		/// pbEncoded parameter of the CertCreateContext function is freed.
		/// </summary>
		public IntPtr pvFree;

		/// <summary>
		/// <para>A PFN_CERT_CREATE_CONTEXT_SORT_FUNC function pointer that will be called for each sorted context entry.</para>
		/// <para>
		/// This member is only present for a <c>CERT_STORE_CTL_CONTEXT</c> when the <c>CERT_CREATE_CONTEXT_SORTED_FLAG</c> flag is set
		/// in the dwFlags parameter of the CertCreateContext function. You must verify that this member is present before trying to
		/// access it by examining the <c>cbSize</c> member of this structure.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFN_CERT_CREATE_CONTEXT_SORT_FUNC pfnSort;

		/// <summary>
		/// <para>
		/// An application-defined value that will be passed in the pvSort parameter of the PFN_CERT_CREATE_CONTEXT_SORT_FUNC callback function.
		/// </para>
		/// <para>
		/// This member is only present for a <c>CERT_STORE_CTL_CONTEXT</c> when the <c>CERT_CREATE_CONTEXT_SORTED_FLAG</c> flag is set
		/// in the dwFlags parameter of the CertCreateContext function. You must verify that this member is present before trying to
		/// access it by examining the <c>cbSize</c> member of this structure.
		/// </para>
		/// </summary>
		public IntPtr pvSort;
	}

	/// <summary>
	/// The <c>CERT_PHYSICAL_STORE_INFO</c> structure contains information on physical certificate stores. Some members of these
	/// structures are passed directly to system calls of CertOpenStore to open the physical store.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_physical_store_info typedef struct
	// _CERT_PHYSICAL_STORE_INFO { DWORD cbSize; LPSTR pszOpenStoreProvider; DWORD dwOpenEncodingType; DWORD dwOpenFlags;
	// CRYPT_DATA_BLOB OpenParameters; DWORD dwFlags; DWORD dwPriority; } CERT_PHYSICAL_STORE_INFO, *PCERT_PHYSICAL_STORE_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "ad86f388-27af-442a-a76f-f386f66296ac")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_PHYSICAL_STORE_INFO
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// A pointer to a string that names a certificate store provider type. This string is passed in a system call to CertOpenStore
		/// and determines the provider type of a certificate store to be opened. For the names of predefined certificate store types,
		/// see <c>CertOpenStore</c>.
		/// </para>
		/// <para>
		/// In addition to predefined certificate store provider types, new store provider types can be installed and registered with
		/// CryptInstallOIDFunctionAddress or CryptRegisterOIDFunction. For more information, see CertOpenStore.
		/// </para>
		/// </summary>
		public StrPtrAnsi pszOpenStoreProvider;

		/// <summary>
		/// <para>
		/// This member is applicable only when CERT_STORE_PROV_MSG, CERT_STORE_PROV_PKCS7, or CERT_STORE_PROV_FILENAME is passed in
		/// lpszStoreProvider. Otherwise, this member is not used.
		/// </para>
		/// <para>
		/// It is always acceptable to specify both the certificate and message encoding types by combining them with a bitwise-
		/// <c>OR</c> operation as shown in the following example:
		/// </para>
		/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>X509_ASN_ENCODING</term>
		/// </item>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertEncodingType dwOpenEncodingType;

		/// <summary>
		/// If a system store is opened with the SERVICES or USERS store location, the <c>dwOpenFlags</c> store location is set to
		/// CERT_SYSTEM_STORE_USERS or CERT_SYSTEM_STORE_SERVICES.
		/// </summary>
		public CertSystemStore dwOpenFlags;

		/// <summary>
		/// A CRYPT_DATA_BLOB that contains data to be passed to the pvPara parameter of the CertOpenStore function. The data type
		/// depends on the provider specified. For detailed information about the type and content to be passed, see descriptions of
		/// available providers in <c>CertOpenStore</c>.
		/// </summary>
		public CRYPTOAPI_BLOB OpenParameters;

		/// <summary>
		/// <para>The following <c>dwFlags</c> values for CERT_PHYSICAL_STORE_INFO are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_PHYSICAL_STORE_ADD_ENABLE_FLAG</term>
		/// <term>Enables addition to a context to the store.</term>
		/// </item>
		/// <item>
		/// <term>CERT_PHYSICAL_STORE_OPEN_DISABLE_FLAG</term>
		/// <term>
		/// Set by the CertRegisterPhysicalStore function. By default, all system stores located in the registry have an implicit
		/// SystemRegistry physical store that is opened. To disable the opening of this store, the SystemRegistry physical store that
		/// corresponds to the System store must be registered by setting CERT_PHYSICAL_STORE_OPEN_DISABLE_FLAG or by registering a
		/// physical store named ".Default" with CertRegisterPhysicalStore.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_PHYSICAL_STORE_REMOTE_OPEN_DISABLE_FLAG</term>
		/// <term>Disables remote opening of the physical store.</term>
		/// </item>
		/// <item>
		/// <term>CERT_PHYSICAL_STORE_INSERT_COMPUTER_NAME_ENABLE_FLAG</term>
		/// <term>Places the string \\ComputerName in front of other provider types.</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_RELOCATE_FLAG</term>
		/// <term>
		/// Enables CertOpenStore to open a store relative to a user-specified HKEY instead of one of the predefined HKEY constants. For
		/// example, HKEY_CURRENT_USER can be replaced with a user-specified HKEY. When CERT_SYSTEM_STORE_RELOCATE_FLAG is set, the
		/// pvPara parameter passed to CertOpenStore points to a CERT_SYSTEM_STORE_RELOCATE_PARA structure instead of pointing to the
		/// store name as a null-terminated Unicode or ASCII string.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CertPhysicalStoreFlags dwFlags;

		/// <summary>
		/// When a system store is opened, its physical stores are ordered according to their <c>dwPriority</c> settings. A higher
		/// <c>dwPriority</c> indicates higher priority. The <c>dwPriority</c> member is passed to CertAddStoreToCollection.
		/// </summary>
		public uint dwPriority;
	}

	/// <summary>
	/// The <c>CERT_SYSTEM_STORE_INFO</c> structure contains information used by functions that work with system stores. Currently, no
	/// essential information is contained in this structure.
	/// </summary>
	/// <remarks>Currently, no system store information is persisted.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_system_store_info typedef struct
	// _CERT_SYSTEM_STORE_INFO { DWORD cbSize; } CERT_SYSTEM_STORE_INFO, *PCERT_SYSTEM_STORE_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "9c17ebd9-423b-4063-bdc3-6be70ceb8623")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_SYSTEM_STORE_INFO
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;
	}

	/// <summary>
	/// The <c>CERT_SYSTEM_STORE_RELOCATE_PARA</c> structure contains data to be passed to CertOpenStore when that function's dwFlags
	/// parameter is set to CERT_SYSTEM_STORE_RELOCATE_FLAG. It allows the application to specify not only the name of the store to be
	/// opened, but also registry hKey information indicating a registry location other than the default location.
	/// </summary>
	/// <remarks>
	/// The relocate capability is used to access system stores persisted in the Group Policy Template (GPT). For example, the Group
	/// Policy Editor's MMC snap-in extension for managing group policy trust lists and certificates uses the GPT's base HKEY to call CertOpenStore.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_system_store_relocate_para typedef struct
	// _CERT_SYSTEM_STORE_RELOCATE_PARA { union { HKEY hKeyBase; void *pvBase; } DUMMYUNIONNAME; union { void *pvSystemStore; LPCSTR
	// pszSystemStore; LPCWSTR pwszSystemStore; } DUMMYUNIONNAME2; } CERT_SYSTEM_STORE_RELOCATE_PARA, *PCERT_SYSTEM_STORE_RELOCATE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "3bcb9b64-b9cf-48b2-bfd1-0836b3d221af")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_SYSTEM_STORE_RELOCATE_PARA
	{
		/// <summary>A pointer to a void to allow the system store location's base to be passed in a number of different forms.</summary>
		public IntPtr pvBase;

		/// <summary>A pointer to a void to allow the name of the system store to be passed in various forms.</summary>
		public IntPtr pvSystemStore;
	}

	public partial class SafeHCERTSTORE
	{
		/// <summary>
		/// Typically, this property uses the default value zero. The default is to close the store with memory remaining allocated for
		/// contexts that have not been freed. In this case, no check is made to determine whether memory for contexts remains allocated.
		/// <para>
		/// Set flags can force the freeing of memory for all of a store's certificate, certificate revocation list (CRL), and
		/// certificate trust list (CTL) contexts when the store is closed. Flags can also be set that check whether all of the store's
		/// certificate, CRL, and CTL contexts have been freed.The following values are defined.
		/// </para>
		/// </summary>
		public CertCloseStoreFlags Flag { get; set; } = 0;
	}

	/// <summary>Certificate Store Provider constants.</summary>
	public static class CertStoreProvider
	{
		/// <summary/>
		public const int CERT_STORE_PROV_MSG = 1;
		/// <summary/>
		public const int CERT_STORE_PROV_MEMORY = 2;
		/// <summary/>
		public const int CERT_STORE_PROV_FILE = 3;
		/// <summary/>
		public const int CERT_STORE_PROV_REG = 4;
		/// <summary/>
		public const int CERT_STORE_PROV_PKCS7 = 5;
		/// <summary/>
		public const int CERT_STORE_PROV_SERIALIZED = 6;
		/// <summary/>
		public const int CERT_STORE_PROV_FILENAME = 8;
		/// <summary/>
		public const int CERT_STORE_PROV_SYSTEM = 10;
		/// <summary/>
		public const int CERT_STORE_PROV_COLLECTION = 11;
		/// <summary/>
		public const int CERT_STORE_PROV_SYSTEM_REGISTRY = 13;
		/// <summary/>
		public const int CERT_STORE_PROV_PHYSICAL = 14;
		/// <summary/>
		public const int CERT_STORE_PROV_SMART_CARD = 15;
		/// <summary/>
		public const int CERT_STORE_PROV_LDAP = 16;
		/// <summary/>
		public const int CERT_STORE_PROV_PKCS12 = 17;
		/// <summary/>
		public const string sz_CERT_STORE_PROV_MEMORY = "Memory";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_FILENAME = "File";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_SYSTEM = "System";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_PKCS7 = "PKCS7";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_PKCS12 = "PKCS12";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_SERIALIZED = "Serialized";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_COLLECTION = "Collection";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_SYSTEM_REGISTRY = "SystemRegistry";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_PHYSICAL = "Physical";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_SMART_CARD = "SmartCard";
		/// <summary/>
		public const string sz_CERT_STORE_PROV_LDAP = "Ldap";
	}
}