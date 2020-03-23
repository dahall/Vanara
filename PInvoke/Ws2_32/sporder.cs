using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Functions, structures and constants from ws2_32.h.</summary>
	public static partial class Ws2_32
	{
		/// <summary>
		/// The <c>WSCWriteNameSpaceOrder</c> function changes the order of available Windows Sockets (Winsock) 2 namespace providers. The
		/// order of the namespace providers determines the priority of the namespace when enumerated or queried for name resolution.
		/// </summary>
		/// <param name="lpProviderId">
		/// An array of <c>NSProviderId</c> elements as found in the WSANAMESPACE_INFOstructure. The order of the <c>NSProviderId</c>
		/// elements is the new priority ordering for the namespace providers.
		/// </param>
		/// <param name="dwNumberOfEntries">The number of elements in the <c>NSProviderId</c> array.</param>
		/// <returns>
		/// <para>
		/// The function returns <c>ERROR_SUCCESS</c> (zero) if the routine is successful. Otherwise, it returns a specific error code.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The NSProviderId array is not fully contained within process address space.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>One or more of the arguments are input parameters were invalid, no action was taken.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>
		/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
		/// administrative privileges required to write to the Winsock registry or another application is currently writing to the namespace
		/// provider catalog.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSASYSCALLFAILURE</term>
		/// <term>A system call that should never fail has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>The function is called by another thread or process.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory was available to perform the operation.</term>
		/// </item>
		/// <item>
		/// <term>(other)</term>
		/// <term>The function may return any registry error code.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Namespace providers are installed using the WSCInstallNameSpace function. The order in which namespace providers are initially
		/// installed governs the default order in which they are enumerated through WSAEnumNameSpaceProviders. More importantly, this order
		/// also governs the order in which namespace providers are considered when a client requests name resolution. The order of
		/// namespace providers can be changed using the <c>WSCWriteNameSpaceOrder</c> function. On 64-bit platforms, the
		/// WSCWriteNameSpaceOrder32 function is provided to allow 64-bit processes to change the order of namespace providers in the 32-bit
		/// namespace provider catalog. On 64-bit platforms, namespace providers are installed in the 32-bit namespace provider catalog
		/// using the WSCInstallNameSpace32 function.
		/// </para>
		/// <para>
		/// The current namespace provider catalog is stored in the registry under the following registry key:
		/// <c>HKEY_LOCAL_MACHINE</c>&lt;b&gt;SYSTEM&lt;b&gt;Current Control Set&lt;b&gt;Services&lt;b&gt;Winsock2&lt;b&gt;Parameters&lt;b&gt;NameSpace_Catalog5
		/// </para>
		/// <para>
		/// A client request for name resolution uses the WSALookupServiceBegin, WSALookupServiceNext, and WSALookupServiceEnd routines. The
		/// <c>dwNameSpace</c> member of the WSAQUERYSET structure passed to <c>WSALookupServiceBegin</c> is set to the identifier of a
		/// single namespace (NS_DNS, for example) in which to constrain the search, or <c>NS_ALL</c> to include all namespaces. If multiple
		/// namespace providers support a specific namespace ( <c>NS_DNS</c>, for example), then the results from all namespace providers
		/// that match the requested <c>dwNameSpace</c> are returned unless the <c>lpNSProviderId</c> member is set to a specific namespace
		/// provider. The results from all namespace providers is returned if NS_ALL is specified for the <c>dwNameSpace</c> member. The
		/// order that the results are returned is dependent on the namespace provider order in the catalog.
		/// </para>
		/// <para>
		/// The Windows SDK includes an application called SpOrder.exe that allows the catalog of installed namespace providers to be
		/// displayed. Windows Sockets 2 includes the ws2_32.dll that exports the <c>WSCWriteNameSpaceOrder</c> function for reordering
		/// namespace providers in the catalog. This interface can be imported by linking with WS2_32.lib. For computers running on Windows
		/// XP with Service Pack 2 (SP2) and Windows Server 2003 with Service Pack 1 (SP1) and later, the <c>netsh.exe winsock show
		/// catalog</c> command will display both the protocol and namespace providers installed on the system.
		/// </para>
		/// <para>
		/// <c>WSCWriteNameSpaceOrder</c> can only be called by a user logged on as a member of the Administrators group. If
		/// <c>WSCWriteNameSpaceOrder</c> is called by a user that is not a member of the Administrators group, the function call will fail
		/// and <c>WSANO_RECOVERY</c> is returned in the lpErrno parameter.
		/// </para>
		/// <para>
		/// For computers running on Windows Vista and Windows Vista, this function can also fail because of user account control (UAC). If
		/// an application that contains this function is executed by a user logged on as a member of the Administrators group other than
		/// the Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista and Windows Vista lacks
		/// this setting in the manifest file used to build the executable file, a user logged on as a member of the Administrators group
		/// other than the Administrator must then be executing the application in an enhanced shell as the Administrator ( <c>RunAs
		/// administrator</c>) for this function to succeed.
		/// </para>
		/// <para>The following list describes scenarios in which the <c>WSCWriteNameSpaceOrder</c> function could fail:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The dwNumberOfEntries parameter is not equal to the number of registered namespace providers.</term>
		/// </item>
		/// <item>
		/// <term>The <c>NSProviderId</c> array contains an invalid namespace provider identifier.</term>
		/// </item>
		/// <item>
		/// <term>The <c>NSProviderId</c> array does not contain all valid namespace provider identifiers exactly one time.</term>
		/// </item>
		/// <item>
		/// <term>The function cannot access the registry (for example, insufficient user permissions).</term>
		/// </item>
		/// <item>
		/// <term>Another process (or thread) is currently calling the function.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sporder/nf-sporder-wscwritenamespaceorder int WSCWriteNameSpaceOrder( IN
		// LPGUID lpProviderId, IN DWORD dwNumberOfEntries );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sporder.h", MSDNShortId = "00a06104-570f-4cd5-9520-bc73516ac7a5")]
		public static extern int WSCWriteNameSpaceOrder([In, MarshalAs(UnmanagedType.LPArray)] Guid[] lpProviderId, [In] uint dwNumberOfEntries);

		/// <summary>
		/// The <c>WSCWriteNameSpaceOrder32</c> function changes the order of available Windows Sockets (Winsock) 2 namespace providers in a
		/// 32-bit catalog. The order of the namespace providers determines the priority of the namespace when enumerated or queried for
		/// name resolution.
		/// </summary>
		/// <param name="lpProviderId">
		/// An array of <c>NSProviderId</c> elements as found in the WSANAMESPACE_INFOstructure. The order of the <c>NSProviderId</c>
		/// elements is the new priority ordering for the namespace providers.
		/// </param>
		/// <param name="dwNumberOfEntries">The number of elements in the <c>NSProviderId</c> array.</param>
		/// <returns>
		/// <para>
		/// The function returns <c>ERROR_SUCCESS</c> (zero) if the routine is successful. Otherwise, it returns a specific error code.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The NSProviderId array is not fully contained within process address space.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>Input parameters were invalid, no action was taken.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>
		/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the Winsock registry
		/// could not be opened, the user lacks the administrative privileges required to write to the Winsock registry, or another
		/// application is currently writing to the namespace provider catalog.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSASYSCALLFAILURE</term>
		/// <term>A system call that should never fail has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>The function is called by another thread or process.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory was available to perform the operation.</term>
		/// </item>
		/// <item>
		/// <term>(other)</term>
		/// <term>The function may return any registry error code.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Namespace providers are installed on 64-bit platforms in a 32-bit namespace provider catalog using the WSCInstallNameSpace32
		/// function. The order in which namespace providers in a 32-bit catalog are initially installed governs the default order in which
		/// they are enumerated through WSCEnumNameSpaceProviders32. More importantly, this order also governs the order in which namespace
		/// providers are considered when a client requests name resolution. On 64-bit platforms, the <c>WSCWriteNameSpaceOrder32</c>
		/// function is provided to allow 64-bit processes to change the order of namespace providers in the 32-bit namespace provider
		/// catalog. The order of namespace providers in the native catalog can be changed using the WSCWriteNameSpaceOrder function.
		/// </para>
		/// <para>
		/// The current namespace provider catalog is stored in the registry under the following registry key:
		/// <c>HKEY_LOCAL_MACHINE</c>&lt;b&gt;SYSTEM&lt;b&gt;Current Control Set&lt;b&gt;Services&lt;b&gt;Winsock2&lt;b&gt;Parameters&lt;b&gt;NameSpace_Catalog5
		/// </para>
		/// <para>
		/// A client request for name resolution uses the WSALookupServiceBegin, WSALookupServiceNext, and WSALookupServiceEnd routines. The
		/// <c>dwNameSpace</c> member of the WSAQUERYSET structure passed to <c>WSALookupServiceBegin</c> is set to the identifier of a
		/// single namespace ( <c>NS_DNS</c>, for example) in which to constrain the search, or <c>NS_ALL</c> to include all namespaces. If
		/// multiple namespace providers support a specific namespace (for example, <c>NS_DNS</c>), then the results from all namespace
		/// providers that match the requested <c>dwNameSpace</c> are returned unless the <c>lpNSProviderId</c> member is set to a specific
		/// namespace provider. The results from all namespace providers is returned if <c>NS_ALL</c> is specified for the
		/// <c>dwNameSpace</c> member. The order that the results are returned depends on the namespace provider order in the catalog.
		/// </para>
		/// <para>
		/// The Windows SDK includes an application called SpOrder.exe that allows the catalog of installed namespace providers to be
		/// displayed. Winsock 2 includes the ws2_32.DLL on 64-bit platforms that exports the <c>WSCWriteNameSpaceOrder32</c> function for
		/// reordering namespace providers in the 32-bit namespace provider catalog. This interface can be imported by linking with
		/// WS2_32.lib. For computers running on Windows XP with Service Pack 2 (SP2) and Windows Server 2003 with Service Pack 1 (SP1) and
		/// later, the <c>netsh.exe winsock show catalog</c> command will display both the protocol and namespace providers installed. The
		/// native 64-bit catalog is displayed first followed by the 32-bit provider catalogs (denoted with a 32 after their name).
		/// </para>
		/// <para>
		/// <c>WSCWriteNameSpaceOrder32</c> can only be called by a user logged on as a member of the Administrators group. If
		/// <c>WSCWriteNameSpaceOrder32</c> is called by a user that is not a member of the Administrators group, the function call will
		/// fail and <c>WSANO_RECOVERY</c> is returned in the lpErrno parameter.
		/// </para>
		/// <para>
		/// For computers running on Windows Vista and Windows Vista, this function can also fail because of user account control (UAC). If
		/// an application that contains this function is executed by a user logged on as a member of the Administrators group other than
		/// the Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista and Windows Vista lacks
		/// this setting in the manifest file used to build the executable file, a user logged on as a member of the Administrators group
		/// other than the Administrator must then be executing the application in an enhanced shell as the Administrator ( <c>RunAs
		/// administrator</c>) for this function to succeed.
		/// </para>
		/// <para>The following list describes scenarios in which the <c>WSCWriteNameSpaceOrder32</c> function could fail:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The dwNumberOfEntries parameter is not equal to the number of registered namespace providers.</term>
		/// </item>
		/// <item>
		/// <term>The <c>NSProviderId</c> array contains an invalid namespace provider identifier.</term>
		/// </item>
		/// <item>
		/// <term>The <c>NSProviderId</c> array does not contain all valid namespace provider identifiers exactly one time.</term>
		/// </item>
		/// <item>
		/// <term>The function is not able to access the registry for some reason (insufficient user permissions, for example).</term>
		/// </item>
		/// <item>
		/// <term>Another process, or thread, is currently calling the function.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sporder/nf-sporder-wscwritenamespaceorder32 int WSCWriteNameSpaceOrder32( IN
		// LPGUID lpProviderId, IN DWORD dwNumberOfEntries );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sporder.h", MSDNShortId = "a5b15d28-8137-42bf-8f2a-7c6b5a8a63c2")]
		public static extern int WSCWriteNameSpaceOrder32([In, MarshalAs(UnmanagedType.LPArray)] Guid[] lpProviderId, [In] uint dwNumberOfEntries);

		/// <summary>
		/// The <c>WSCWriteProviderOrder</c> function is used to reorder the available transport providers. The order of the protocols
		/// determines the priority of a protocol when being enumerated or selected for use.
		/// </summary>
		/// <param name="lpwdCatalogEntryId">
		/// A pointer to an array of <c>CatalogEntryId</c> elements found in the WSAPROTOCOL_INFO structure. The order of the
		/// <c>CatalogEntryId</c> elements is the new priority ordering for the protocols.
		/// </param>
		/// <param name="dwNumberOfEntries">The number of elements in the lpwdCatalogEntryId array.</param>
		/// <returns>
		/// <para>
		/// The function returns <c>ERROR_SUCCESS</c> (zero) if the routine is successful. Otherwise, it returns a specific error code.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>One or more of the arguments are invalid, no action was taken.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>
		/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
		/// administrative privileges required to write to the Winsock registry, or a failure occurred when opening or writing a catalog entry.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
		/// </term>
		/// </item>
		/// <item>
		/// <term>(other)</term>
		/// <term>The routine may return any registry error code.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The order in which transport service providers are initially installed governs the order in which they are enumerated through
		/// WSCEnumProtocols at the service provider interface, or through WSAEnumProtocols at the application interface. More importantly,
		/// this order also governs the order in which protocols and service providers are considered when a client requests creation of a
		/// socket based on its address family, type, and protocol identifier.
		/// </para>
		/// <para>
		/// Windows Sockets 2 includes an application called Sporder.exe that allows the catalog of installed protocols to be reordered
		/// interactively after protocols have already been installed. Windows Sockets 2 also includes an auxiliary DLL, Sporder.dll that
		/// exports this procedural interface for reordering protocols. This interface can be imported by linking with Sporder.lib.
		/// </para>
		/// <para>The following are scenarios in which the <c>WSCWriteProviderOrder</c> function could fail:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The dwNumberOfEntries parameter is not equal to the number of registered service providers.</term>
		/// </item>
		/// <item>
		/// <term>The lpwdCatalogEntryId contains an invalid catalog identifier.</term>
		/// </item>
		/// <item>
		/// <term>The lpwdCatalogEntryId does not contain all valid catalog identifiers exactly one time.</term>
		/// </item>
		/// <item>
		/// <term>The routine is not able to access the registry for some reason (for example, inadequate user permissions).</term>
		/// </item>
		/// <item>
		/// <term>Another process (or thread) is currently calling the function.</term>
		/// </item>
		/// </list>
		/// <para>
		/// On success, <c>WSCWriteProviderOrder</c> will attempt to alert all interested applications that have registered for notification
		/// of the change by calling WSAProviderConfigChange.
		/// </para>
		/// <para>
		/// The <c>WSCWriteProviderOrder</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>WSCWriteProviderOrder</c> is called by a user that is not a member of the Administrators group, the function call will fail
		/// and WSANO_RECOVERY is returned. For computers running on Windows Vista or Windows Server 2008, this function can also fail
		/// because of user account control (UAC). If an application that contains this function is executed by a user logged on as a member
		/// of the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in
		/// the manifest file with a <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista
		/// or Windows Server 2008 lacks this manifest file, a user logged on as a member of the Administrators group other than the
		/// built-in Administrator must then be executing the application in an enhanced shell as the built-in Administrator ( <c>RunAs
		/// administrator</c>) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sporder/nf-sporder-wscwriteproviderorder int WSCWriteProviderOrder( IN LPDWORD
		// lpwdCatalogEntryId, IN DWORD dwNumberOfEntries );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sporder.h", MSDNShortId = "459a2fc9-fa05-4ebc-8cc7-3f4915b4b800")]
		public static extern int WSCWriteProviderOrder([In, MarshalAs(UnmanagedType.LPArray)] uint[] lpwdCatalogEntryId, [In] uint dwNumberOfEntries);

		/// <summary>
		/// <para>
		/// The <c>WSCWriteProviderOrder32</c> function is used to reorder the available 32-bit transport providers. The order of the
		/// protocols determines the priority of a protocol when being enumerated or selected for use.
		/// </para>
		/// <para>
		/// <c>Note</c> This call is a strictly 32-bit version of WSCWriteProviderOrder for use on 64-bit platforms. It is provided to allow
		/// 64-bit processes to modify the 32-bit catalogs.
		/// </para>
		/// </summary>
		/// <param name="lpwdCatalogEntryId">
		/// A pointer to an array of <c>CatalogEntryId</c> elements found in the WSAPROTOCOL_INFO structure. The order of the
		/// <c>CatalogEntryId</c> elements is the new priority ordering for the protocols.
		/// </param>
		/// <param name="dwNumberOfEntries">The number of elements in the lpwdCatalogEntryId array.</param>
		/// <returns>
		/// <para>
		/// The function returns <c>ERROR_SUCCESS</c> (zero) if the routine is successful. Otherwise, it returns a specific error code.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>One or more of the arguments are invalid, no action was taken.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>
		/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
		/// administrative privileges required to write to the Winsock registry, or a failure occurred when opening or writing a catalog entry.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
		/// </term>
		/// </item>
		/// <item>
		/// <term>(other)</term>
		/// <term>The routine may return any registry error code.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSCWriteProviderOrder32</c> function is a strictly 32-bit version of the WSCWriteProviderOrder function. On a 64-bit
		/// computer, all calls not specifically 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit
		/// catalog. Processes that execute on a 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit
		/// catalog and preserve compatibility. The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
		/// </para>
		/// <para>
		/// The order in which transport service providers are initially installed governs the order in which they are enumerated through
		/// WSCEnumProtocols32 at the service provider interface, or through WSAEnumProtocols at the application interface. More
		/// importantly, this order also governs the order in which protocols and service providers are considered when a client requests
		/// creation of a socket based on its address family, type, and protocol identifier.
		/// </para>
		/// <para>
		/// Windows Sockets 2 includes an application called Sporder.exe that allows the catalog of installed protocols to be reordered
		/// interactively after protocols have already been installed. Windows Sockets 2 also includes an auxiliary DLL, Sporder.dll that
		/// exports this procedural interface for reordering protocols. This interface can be imported by linking with Sporder.lib.
		/// </para>
		/// <para>The following are scenarios in which the <c>WSCWriteProviderOrder32</c> function could fail:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The dwNumberOfEntries parameter is not equal to the number of registered service providers.</term>
		/// </item>
		/// <item>
		/// <term>The lpwdCatalogEntryId contains an invalid catalog identifier.</term>
		/// </item>
		/// <item>
		/// <term>The lpwdCatalogEntryId does not contain all valid catalog identifiers exactly one time.</term>
		/// </item>
		/// <item>
		/// <term>The routine is not able to access the registry for some reason (for example, inadequate user permissions).</term>
		/// </item>
		/// <item>
		/// <term>Another process (or thread) is currently calling the function.</term>
		/// </item>
		/// </list>
		/// <para>
		/// On success, <c>WSCWriteProviderOrder32</c> will attempt to alert all interested applications that have registered for
		/// notification of the change by calling WSAProviderConfigChange.
		/// </para>
		/// <para>
		/// The <c>WSCWriteProviderOrder32</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>WSCWriteProviderOrder32</c> is called by a user that is not a member of the Administrators group, the function call will fail
		/// and WSANO_RECOVERY is returned. For computers running on Windows Vista or Windows Server 2008, this function can also fail
		/// because of user account control (UAC). If an application that contains this function is executed by a user logged on as a member
		/// of the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in
		/// the manifest file with a <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista
		/// or Windows Server 2008 lacks this manifest file, a user logged on as a member of the Administrators group other than the
		/// built-in Administrator must then be executing the application in an enhanced shell as the built-in Administrator ( <c>RunAs
		/// administrator</c>) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sporder/nf-sporder-wscwriteproviderorder32 int WSCWriteProviderOrder32( IN
		// LPDWORD lpwdCatalogEntryId, IN DWORD dwNumberOfEntries );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sporder.h", MSDNShortId = "03ce09b4-d80e-480d-9219-d226df055f18")]
		public static extern int WSCWriteProviderOrder32([In, MarshalAs(UnmanagedType.LPArray)] uint[] lpwdCatalogEntryId, [In] uint dwNumberOfEntries);
	}
}