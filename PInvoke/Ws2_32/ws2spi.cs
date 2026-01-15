using System.Collections.Generic;
using System.ComponentModel;

namespace Vanara.PInvoke;

public static partial class Ws2_32
{
	/// <summary>
	/// The <c>NSPv2Cleanup</c> function notifies a namespace service provider version-2 (NSPv2) provider that a client session has terminated.
	/// </summary>
	/// <param name="lpProviderId">A pointer to the GUID of the namespace provider to be notified.</param>
	/// <param name="pvClientSessionArg">A pointer to the client session.</param>
	/// <returns>
	/// <para>
	/// The function should return <c>NO_ERROR</c> (zero) if the routine succeeds. It should return <c>SOCKET_ERROR</c> (that is, 1) if
	/// the routine fails and it must set the appropriate error code using WSASetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There is not enough memory available to perform this operation.</term>
	/// </item>
	/// <item>
	/// <term>WSAEACCES</term>
	/// <term>The calling routine does not have sufficient privileges to initialize the service.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more parameters were invalid, or missing, for this provider.</term>
	/// </item>
	/// <item>
	/// <term>WSAEOPNOTSUPP</term>
	/// <term>The operation is not supported. This error is returned if the namespace provider does not implement this function.</term>
	/// </item>
	/// <item>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// <term>Service is unknown. The service cannot be found in the specified namespace.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NSPv2Cleanup</c> function is used as part of the namespace service provider version-2 (NSPv2) architecture available on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>NSPv2Cleanup</c> function can only be used for operations on NS_EMAIL namespace providers.
	/// </para>
	/// <para>
	/// The NSPv2Startup function is called each time a new client process begins using namespace provider. Providers may use the client
	/// session argument pointed to by the ppvClientSessionArg parameter to store information about this session. If a value was
	/// specified for the client session argument in the call to the <c>NSPv2Startup</c> function, then this same client session
	/// argument can be passed in the pvClientSessionArg parameter to the <c>NSPv2Cleanup</c> function to notify namespace provider that
	/// the client session has terminated.
	/// </para>
	/// <para>
	/// The <c>NSPv2Cleanup</c> function is called when an application is finished using a Windows Sockets namespace service provider.
	/// The <c>NSPv2Cleanup</c> allows the namespace provider to free any of namespace provider resources that were allocated for the
	/// client session.
	/// </para>
	/// <para>
	/// The NSPv2Startup function must be called successfully before calling the <c>NSPv2Cleanup</c> function. It is permissible to make
	/// more than one <c>NSPv2Startup</c> call. However, for each <c>NSPv2Startup</c> call, a corresponding <c>NSPv2Cleanup</c> call
	/// must also be issued. Only the final <c>NSPv2Cleanup</c> for the service provider does the actual cleanup; the preceding calls
	/// decrement an internal reference count in the service provider.
	/// </para>
	/// <para>
	/// The NSPv2Startup, NSPv2ClientSessionRundown, and <c>NSPv2Cleanup</c> functions are optional, dependent on the requirements of
	/// the NSPv2 provider.
	/// </para>
	/// <para>
	/// If the <c>NSPv2Cleanup</c> function isn't implemented, then calls to that function should be intercepted by a stub function that
	/// returns WSAEOPNOTSUPP. The NSPv2 function pointer to the unimplemented <c>NSPv2Cleanup</c> function in the NSPV2_ROUTINE
	/// structure should point be to the stub function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nc-ws2spi-lpnspv2cleanup LPNSPV2CLEANUP Lpnspv2cleanup; INT
	// Lpnspv2cleanup( LPGUID lpProviderId, LPVOID pvClientSessionArg ) {...}
	[PInvokeData("ws2spi.h", MSDNShortId = "36064c0e-c83c-4819-a3e4-c89df50eb659")]
	public delegate WSRESULT LPNSPV2CLEANUP(in Guid lpProviderId, IntPtr pvClientSessionArg);

	/// <summary>
	/// The <c>NSPv2ClientSessionRundown</c> function notifies a namespace service provider version-2 (NSPv2) provider that the client
	/// session is terminating.
	/// </summary>
	/// <param name="lpProviderId">A pointer to the GUID of the specific namespace provider to notify.</param>
	/// <param name="pvClientSessionArg">A pointer to the client session that is terminating.</param>
	/// <returns>
	/// <para>
	/// The function should return <c>NO_ERROR</c> (zero) if the routine succeeds. It should return <c>SOCKET_ERROR</c> (that is, 1) if
	/// the routine fails and it must set the appropriate error code using WSASetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There is not enough memory available to perform this operation.</term>
	/// </item>
	/// <item>
	/// <term>WSAEACCES</term>
	/// <term>The calling routine does not have sufficient privileges to install the service.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more parameters were invalid, or missing, for this provider.</term>
	/// </item>
	/// <item>
	/// <term>WSAEOPNOTSUPP</term>
	/// <term>
	/// The operation is not supported. This error is returned if the namespace provider does not implement this function. This error
	/// can also be returned if the specified dwControlCode is an unrecognized command.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// <term>Service is unknown. The service cannot be found in the specified namespace.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NSPv2ClientSessionRundown</c> function is used as part of the namespace service provider version-2 (NSPv2) architecture
	/// available on Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>NSPv2ClientSessionRundown</c> function can only be used for operations on
	/// NS_EMAIL namespace providers.
	/// </para>
	/// <para>
	/// The NSPv2Startup function is called each time a new client process begins using namespace provider. Providers may use the client
	/// session argument pointed to by the ppvClientSessionArg parameter to store information about this session. If a value was
	/// specified for the client session argument in the call to the <c>NSPv2Startup</c> function, then this same client session
	/// argument is passed in the pvClientSessionArg parameter to the <c>NSPv2ClientSessionRundown</c> function.
	/// </para>
	/// <para>
	/// The NSPv2Startup, <c>NSPv2ClientSessionRundown</c>, and NSPv2Cleanup functions are optional, dependent on the requirements of
	/// the NSPv2 provider.
	/// </para>
	/// <para>
	/// If the <c>NSPv2ClientSessionRundown</c> function isn't implemented, then calls to that function should be intercepted by a stub
	/// function that returns WSAEOPNOTSUPP. The NSPv2 function pointer to the unimplemented <c>NSPv2ClientSessionRundown</c> function
	/// in the NSPV2_ROUTINE structure should point be to the stub function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nc-ws2spi-lpnspv2clientsessionrundown LPNSPV2CLIENTSESSIONRUNDOWN
	// Lpnspv2clientsessionrundown; void Lpnspv2clientsessionrundown( LPGUID lpProviderId, LPVOID pvClientSessionArg ) {...}
	[PInvokeData("ws2spi.h", MSDNShortId = "7379b502-129a-4dac-b7eb-e6fae8fb23f8")]
	public delegate void LPNSPV2CLIENTSESSIONRUNDOWN(in Guid lpProviderId, IntPtr pvClientSessionArg);

	/// <summary>
	/// The NSPv2LookupServiceBegin function initiates a client query of a namespace version-2 service provider that is constrained by
	/// the information contained within a WSAQUERYSET2 structure.
	/// </summary>
	/// <param name="lpProviderId">A pointer to the identifier for the namespace service provider to query.</param>
	/// <param name="lpqsRestrictions">A pointer to the search criteria. See Remarks.</param>
	/// <param name="dwControlFlags">
	/// <para>
	/// A set of flags that affect the search. This parameter can be a combination of the following values defined in the Winsock2.h
	/// header file.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LUP_DEEP 0x0001</term>
	/// <term>Queries down the hierarchy of a provider as opposed to just the first level.</term>
	/// </item>
	/// <item>
	/// <term>LUP_CONTAINERS 0x0002</term>
	/// <term>Returns containers only.</term>
	/// </item>
	/// <item>
	/// <term>LUP_NOCONTAINERS 0x0004</term>
	/// <term>Returns no containers.</term>
	/// </item>
	/// <item>
	/// <term>LUP_NEAREST 0x0008</term>
	/// <term>If possible, returns results in the order of distance. The measure of distance is provider specific.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_NAME 0x0010</term>
	/// <term>Retrieves the name as **lpszServiceInstanceName**.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_TYPE 0x0020</term>
	/// <term>Retrieves the type as **lpServiceClassId**.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_VERSION 0x0040</term>
	/// <term>Retrieves the version as **lpVersion**.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_COMMENT 0x0080</term>
	/// <term>Retrieves the comment as **lpszComment**.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_ADDR 0x0100</term>
	/// <term>Retrieves the addresses as **lpcsaBuffer**.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_BLOB 0x0200</term>
	/// <term>Retrieves the private data as **lpBlob**.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_ALIASES 0x0400</term>
	/// <term>
	/// Any available alias information is to be returned in successive calls to NSPv2LookupServiceNextEx, and each alias returned will
	/// have the **RESULT_IS_ALIAS** flag set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_QUERY_STRING 0x0800</term>
	/// <term>Retrieves the query string as **lpszQueryString**.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_ALL 0x0ff0</term>
	/// <term>Retrieves information including the name, type, version, comment, address, blob, aliases, and query string.</term>
	/// </item>
	/// <item>
	/// <term>LUP_FLUSHCACHE 0x1000</term>
	/// <term>If the provider has cached information, ignore the cache and query the namespace itself.</term>
	/// </item>
	/// <item>
	/// <term>LUP_FLUSHPREVIOUS 0x2000</term>
	/// <term>
	/// Used as a value for the dwControlFlags parameter in NSPv2LookupServiceNextEx. Setting this flag instructs the provider to
	/// discard the last result set, which was too large for the supplied buffer, and move on to the next result set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LUP_NON_AUTHORITATIVE 0x4000</term>
	/// <term>Indicates that the namespace provider should included non-authoritative results for names.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RES_RESERVICE 0x8000</term>
	/// <term>
	/// Indicates whether prime response is in the remote or local part of CSADDR_INFO structure. The other part must be usable in
	/// either case. This option applies only to service instance requests.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LUP_SECURE 0x8000</term>
	/// <term>Indicates that the namespace provider should use a secure query. This option only applies to name query requests.</term>
	/// </item>
	/// <item>
	/// <term>LUP_RETURN_PREFERRED_NAMES 0x10000</term>
	/// <term>Indicates that the namespace provider should return only preferred names.</term>
	/// </item>
	/// <item>
	/// <term>LUP_ADDRCONFIG 0x100000</term>
	/// <term>Indicates that the namespace provider should return the address configuration.</term>
	/// </item>
	/// <item>
	/// <term>LUP_DUAL_ADDR 0x200000</term>
	/// <term>
	/// Indicates that the namespace provider should return the dual addresses. This option only applies to dual-mode sockets (IPv6 and
	/// IPv4 mapped addresses).
	/// </term>
	/// </item>
	/// <item>
	/// <term>LUP_DISABLE_IDN_ENCODING 0x800000</term>
	/// <term>
	/// Indicates that the namespace provider should disable automatic International Domain Names encoding. This value is supported on
	/// Windows 8 and Windows Server 2012
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpvClientSessionArg">A pointer to the client session.</param>
	/// <param name="lphLookup">
	/// A pointer to the handle to be used in subsequent calls to NSPv2LookupServiceNextEx in order to retrieve the results set.
	/// </param>
	/// <returns>
	/// <para>
	/// The function should return <c>NO_ERROR</c> (zero) if the routine succeeds. It should return <c>SOCKET_ERROR</c> (that is, 1) if
	/// the routine fails and it must set the appropriate error code using WSASetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more parameters were invalid, or missing, for this provider.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_DATA</term>
	/// <term>The name was found in the database, but it does not have the correct associated data that is resolved for.</term>
	/// </item>
	/// <item>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// <term>The service is unknown. The service cannot be found in the specified namespace.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There is not enough memory available to perform this operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The NSPv2LookupServiceBegin function is used as part of the namespace service provider version-2 (NSPv2) architecture available
	/// on Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the NSPv2LookupServiceBegin function can only be used for operations on NS_EMAIL
	/// namespace providers.
	/// </para>
	/// <para>
	/// The NSPv2LookupServiceBegin function only returns a handle, which should be used by subsequent calls to NSPv2LookupServiceNextEx
	/// to get the actual results. Because this operation cannot be canceled, it should be implemented to execute quickly. While it is
	/// acceptable to initiate a network query, this function should not require a response to return successfully.
	/// </para>
	/// <para>
	/// The NSPv2Startup function is called each time a new client process begins using namespace provider. Providers may use the client
	/// session argument pointed to by the ppvClientSessionArg parameter to store information about this session. If a value was
	/// specified for the client session argument in the call to the <c>NSPv2Startup</c> function, then this same client session
	/// argument is passed in the lpvClientSessionArg parameter to the NSPv2LookupServiceBegin function.
	/// </para>
	/// <para>
	/// If <c>LUP_CONTAINERS</c> is specified in a call, avoid all other restriction values. If any are supplied, the name service
	/// provider must decide if it can support this restriction over the containers. If not, it should return an error.
	/// </para>
	/// <para>
	/// Some name service providers may have other means of finding containers. For example, containers can all be of some well-known
	/// type, or of a set of well-known types, and therefore a query restriction could be created for finding them. No matter what other
	/// means the name service provider has for locating containers, <c>LUP_CONTAINERS</c> and <c>LUP_NOCONTAINERS</c> take precedence.
	/// Therefore, if a query restriction is given that includes containers, specifying <c>LUP_NOCONTAINERS</c> will prevent the
	/// container items from being returned. Similarly, no matter what the query restriction, if <c>LUP_CONTAINERS</c> is given, only
	/// containers should be returned. If a namespace does not support containers and <c>LUP_CONTAINERS</c> is specified, it should
	/// return WSANO_DATA.
	/// </para>
	/// <para>The preferred method of obtaining the containers within another container, is the call:</para>
	/// <para>
	/// followed by the requisite number of NSPv2LookupServiceNextEx calls. This will return all containers contained immediately within
	/// the starting context; that is, it is not a deep query. With this, one can map the address space structure by walking the
	/// hierarchy, perhaps enumerating the content of selected containers. Subsequent uses of NSPv2LookupServiceBegin use the containers
	/// returned from a previous call.
	/// </para>
	/// <para>Forming Queries</para>
	/// <para>
	/// The WSAQUERYSET2 structure is used as an input parameter to NSPv2LookupServiceBegin to qualify the query. The following table
	/// lists **WSAQUERYSET2** member names and describes how the **WSAQUERYSET2** is used to construct a query. Members labeled as
	/// optional and dependent on the requirements of the NSPv2 provider may be supplied as a **NULL** pointer when unused as a search
	/// criteria by the namespace provider. For more information, see Query-Related Data Structures.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>WSAQUERYSET2 member name</term>
	/// <term>Query interpretation</term>
	/// </listheader>
	/// <item>
	/// <term>**dwSize**</term>
	/// <term>Will be set to sizeof(WSAQUERYSET2). This is a versioning mechanism.</term>
	/// </item>
	/// <item>
	/// <term>**lpszServiceInstanceName**</term>
	/// <term>
	/// A string that contains the service name. The semantics for wildcarding within the string are not defined, but can be supported
	/// by certain namespace providers. This member is optional, dependent on the requirements of the NSPv2 service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**lpVersion**</term>
	/// <term>
	/// The desired version number that provides version comparison semantics (that is, version must match exactly, or version must be
	/// not less than the value supplied). This member is optional, dependent on the requirements of the NSPv2 service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**lpszComment**</term>
	/// <term>This member is ignored for queries.</term>
	/// </item>
	/// <item>
	/// <term>**dwNameSpace**</term>
	/// <term>The identifier of a single namespace in which to constrain the search, or **NS_ALL** to include all namespaces.</term>
	/// </item>
	/// <item>
	/// <term>**lpNSProviderId**</term>
	/// <term>
	/// The GUID of a specific namespace provider that limits the query to this provider only. This member is optional, dependent on the
	/// requirements of the NSPv2 service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**lpszContext**</term>
	/// <term>
	/// The starting point of the query in a hierarchical namespace. This member is optional, dependent on the requirements of the NSPv2
	/// service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**dwNumberOfProtocols**</term>
	/// <term>The size, in bytes, of the number of entries in the protocol constraint array. This member can be zero.</term>
	/// </item>
	/// <item>
	/// <term>**lpafpProtocols**</term>
	/// <term>
	/// An array of AFPROTOCOLS structures. Only services that use these protocols will be returned. It is permissable for the value
	/// **AF_UNSPEC** to appear as a protocol family value, signifying a wildcard. Namespace providers may supply information about any
	/// service that uses the corresponding protocol, regardless of address family. This member is optional, dependent on the
	/// requirements of the NSPv2 service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**lpszQueryString**</term>
	/// <term>
	/// Some namespaces (such as whois++) support rich SQL-like queries contained in a simple text string. This parameter is used to
	/// specify that string.This member is optional, dependent on the requirements of the NSPv2 service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**dwNumberOfCsAddrs**</term>
	/// <term>This member is ignored for queries.</term>
	/// </item>
	/// <item>
	/// <term>**lpcsaBuffer**</term>
	/// <term>This member is ignored for queries.</term>
	/// </item>
	/// <item>
	/// <term>**dwOutputFlags**</term>
	/// <term>This member is ignored for queries.</term>
	/// </item>
	/// <item>
	/// <term>**lpBlob**</term>
	/// <term>A pointer to a provider-specific entity. This member is optional, dependent on the requirements of the NSPv2 service provider.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nc-ws2spi-lpnspv2lookupservicebegin LPNSPV2LOOKUPSERVICEBEGIN
	// Lpnspv2lookupservicebegin; INT Lpnspv2lookupservicebegin( LPGUID lpProviderId, LPWSAQUERYSET2W lpqsRestrictions, DWORD
	// dwControlFlags, LPVOID lpvClientSessionArg, LPHANDLE lphLookup ) {...}
	[PInvokeData("ws2spi.h", MSDNShortId = "5664b85d-8432-4068-aa97-caa57d9377ac")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	public delegate WSRESULT LPNSPV2LOOKUPSERVICEBEGIN(in Guid lpProviderId, in WSAQUERYSET2W lpqsRestrictions, uint dwControlFlags, IntPtr lpvClientSessionArg, out HANDLE lphLookup);

	/// <summary>
	/// The <c>NSPv2LookupServiceEnd</c> function is called to free the handle after previous calls to NSPv2LookupServiceBegin and NSPv2LookupServiceNextEx.
	/// </summary>
	/// <param name="hLookup">The handle obtained previously by a call to NSPv2LookupServiceBegin.</param>
	/// <returns>
	/// <para>
	/// The function should return <c>NO_ERROR</c> (zero) if the routine succeeds. It should return <c>SOCKET_ERROR</c> (that is, 1) if
	/// the routine fails and it must set the appropriate error code using WSASetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSA_INVALID_HANDLE</term>
	/// <term>The handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There is not enough memory available to perform this operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NSPv2LookupServiceEnd</c> function is used as part of the namespace service provider version-2 (NSPv2) architecture
	/// available on Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>NSPv2LookupServiceEnd</c> function can only be used for operations on NS_EMAIL
	/// namespace providers.
	/// </para>
	/// <para>
	/// It is possible to receive an NSPv2LookupServiceBegin function call on another thread while processing an
	/// NSPv2LookupServiceNextEx. This indicates that the client has canceled the request and the provider should close the handle and
	/// return from the <c>NSPv2LookupServiceNextEx</c> function call as well, setting the last error to <c>WSA_E_CANCELLED</c>.
	/// </para>
	/// <para>
	/// In Windows Sockets 2, conflicting error codes are defined for <c>WSAECANCELLED</c> and WSA_E_CANCELLED. The error code
	/// <c>WSAECANCELLED</c> will be removed in a future version and only WSA_E_CANCELLED will remain. Namespace Providers should use
	/// the WSA_E_CANCELLED error code to maintain compatibility with the widest possible range of applications.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nc-ws2spi-lpnspv2lookupserviceend LPNSPV2LOOKUPSERVICEEND
	// Lpnspv2lookupserviceend; INT Lpnspv2lookupserviceend( HANDLE hLookup ) {...}
	[PInvokeData("ws2spi.h", MSDNShortId = "5f2b56c5-3a8e-4bf9-8f28-d2a06543227b")]
	public delegate WSRESULT LPNSPV2LOOKUPSERVICEEND(HANDLE hLookup);

	/// <summary>
	/// The <c>NSPv2LookupServiceNextEx</c> function is called after obtaining a handle from a previous call to NSPv2LookupServiceBegin
	/// in order to retrieve the requested information from a namespace version-2 service provider.
	/// </summary>
	/// <param name="hAsyncCall">A handle returned from the previous call to NSPv2LookupServiceBegin used for asynchronous calls.</param>
	/// <param name="hLookup">A handle returned from the previous call to NSPv2LookupServiceBegin.</param>
	/// <param name="dwControlFlags">
	/// The flags used to control the next operation. Currently, only <c>LUP_FLUSHPREVIOUS</c> is defined as a means to handle a result
	/// set that is too large. If an application cannot supply a large enough buffer, setting <c>LUP_FLUSHPREVIOUS</c> instructs the
	/// provider to discard the last result set, which was too large, and move to the next set for this call.
	/// </param>
	/// <param name="lpdwBufferLength">
	/// The size, in bytes, on input, that is contained in the buffer pointed to by lpqsResults. On output, if the function fails and
	/// the error is WSAEFAULT, then it contains the minimum size, in bytes to pass for the lpqsResults to retrieve the record.
	/// </param>
	/// <param name="lpqsResults">A pointer to a memory block that will contain, on return, one result set in a WSAQUERYSET2 structure.</param>
	/// <returns>
	/// <para>
	/// The function should return <c>NO_ERROR</c> (zero) if the routine succeeds. It should return <c>SOCKET_ERROR</c> (that is, 1) if
	/// the routine fails and it must set the appropriate error code using WSASetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSA_E_CANCELLED</term>
	/// <term>
	/// A call to NSPv2LookupServiceEnd was made while this call was still processing. The call has been canceled. The data in the
	/// lpqsResults buffer is undefined. In Windows Sockets 2, conflicting error codes are defined for WSAECANCELLED (10103) and
	/// WSA_E_CANCELLED (10111).The error code WSAECANCELLED will be removed in a future version and only WSA_E_CANCELLED will remain.
	/// Namespace providers should use the WSA_E_CANCELLED error code to maintain compatibility with the widest possible range of applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSA_E_NO_MORE</term>
	/// <term>
	/// There is no more data available. In Windows Sockets 2, conflicting error codes are defined for WSAENOMORE (10102) and
	/// WSA_E_NO_MORE (10110).The error code WSAENOMORE will be removed in a future version and only WSA_E_NO_MORE will remain.
	/// Namespace providers should use the WSA_E_NO_MORE error code to maintain compatibility with the widest possible range of applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The lpqsResults buffer was too small to contain a WSAQUERYSET set.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more parameters are invalid, or missing, for this provider.</term>
	/// </item>
	/// <item>
	/// <term>WSA_INVALID_HANDLE</term>
	/// <term>The specified lookup handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_DATA</term>
	/// <term>The name was found in the database, but no data, matching the given restrictions, was located.</term>
	/// </item>
	/// <item>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// <term>The service is unknown. The service cannot be found in the specified namespace.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There is not enough memory available to perform this operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NSPv2LookupServiceNextEx</c> function is used as part of the namespace service provider version-2 (NSPv2) architecture
	/// available on Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>NSPv2LookupServiceNextEx</c> function can only be used for operations on
	/// NS_EMAIL namespace providers.
	/// </para>
	/// <para>
	/// The provider will pass a WSAQUERYSET2 structure in the lpqsResults buffer. The client should call the
	/// <c>NSPv2LookupServiceNextEx</c> function until it returns <c>WSA_E_NOMORE</c>, indicating that all the <c>WSAQUERYSET2</c>
	/// structures have been returned.
	/// </para>
	/// <para>
	/// The dwControlFlags specified in this function and the ones specified at the time of NSPv2LookupServiceBegin are handled as
	/// "restrictions" for the purpose of combination. The restrictions are combined between the ones at <c>NSPv2LookupServiceBegin</c>
	/// time and the ones at <c>NSPv2LookupServiceNextEx</c> time. Therefore, the flags at <c>NSPv2LookupServiceNextEx</c> can never
	/// increase the amount of data returned beyond what was requested at <c>NSPv2LookupServiceBegin</c>, although it is not an error to
	/// specify more or less flags. The flags specified at a given <c>NSPv2LookupServiceNextEx</c> apply only to that call.
	/// </para>
	/// <para>
	/// The dwControlFlags <c>LUP_FLUSHPREVIOUS</c> and <c>LUP_RES_SERVICE</c> are exceptions to the combined restrictions rule (because
	/// they are behavior flags instead of "restriction" flags). If either flag is used in <c>NSPv2LookupServiceNextEx</c>, they have
	/// their defined effect regardless of the setting of the same flags at NSPv2LookupServiceBegin.
	/// </para>
	/// <para>
	/// For example, if <c>LUP_RETURN_VERSION</c> is specified at NSPv2LookupServiceBegin, the service provider retrieves records
	/// including the version. If <c>LUP_RETURN_VERSION</c> is not specified at <c>NSPv2LookupServiceNextEx</c>, the returned
	/// information does not include the version, even though it was available. No error is generated.
	/// </para>
	/// <para>
	/// Also for example, if <c>LUP_RETURN_BLOB</c> is not specified at NSPv2LookupServiceBegin, but is specified at
	/// <c>NSPv2LookupServiceNextEx</c>, the returned information does not include the private data. No error is generated.
	/// </para>
	/// <para>
	/// The <c>NSPv2LookupServiceNextEx</c> function is typically called at least twice. The first time to get the size of the needed
	/// buffer to receive the WSAQUERYSET2 pointed to by the lpqsResults parameter, and the second time to get the actual query result
	/// set. On the first call, the NSPv2 provider should return the size necessary for the <c>WSAQUERYSET2</c> results.
	/// </para>
	/// <para>
	/// The WSAQUERYSET2 structure pointed to by the lpqsResults parameter that is returned is only useful in the same process context,
	/// since several of the members in the <c>WSAQUERYSET2</c> structure contains pointers to the actual data returned. If the query
	/// result needs to be passed to another process (using RPC, for example), then it will be necessary to serialize and marshal the
	/// data returned in the <c>WSAQUERYSET2</c> structure pointed to by the lpqsResults parameter including the data pointed to by
	/// members in the <c>WSAQUERYSET2</c> structure. The data needs to be serialized in a form that can be passed across process
	/// boundaries. Just passing a copy of the <c>WSAQUERYSET2</c> structure is insufficient, since only pointers to data will be passed
	/// and the actual data will be unavailable to other processes.
	/// </para>
	/// <para>Query Results</para>
	/// <para>
	/// The following table lists WSAQUERYSET2 and describes how query results are represented in the **WSAQUERYSET2** structure. For
	/// more information, see Query-Related Data Structures.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>WSAQUERYSET2 member name</term>
	/// <term>Result interpretation</term>
	/// </listheader>
	/// <item>
	/// <term>**dwSize**</term>
	/// <term>The size, in bytes, of WSAQUERYSET2 structure. This is used as a versioning mechanism.</term>
	/// </item>
	/// <item>
	/// <term>**lpszServiceInstanceName**</term>
	/// <term>A string that contains the service name.</term>
	/// </item>
	/// <item>
	/// <term>**lpVersion**</term>
	/// <term>References version number of the particular service instance.</term>
	/// </item>
	/// <item>
	/// <term>**lpszComment**</term>
	/// <term>
	/// A comment string supplied by service instance. This member is optional, dependent on the requirements of the NSPv2 service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**dwNameSpace**</term>
	/// <term>The namespace identifier in which the name or service instance was found.</term>
	/// </item>
	/// <item>
	/// <term>**lpNSProviderId**</term>
	/// <term>The specific namespace provider that supplied this query result.</term>
	/// </item>
	/// <item>
	/// <term>**lpszContext**</term>
	/// <term>The context point in a hierarchical namespace at which the service is located.</term>
	/// </item>
	/// <item>
	/// <term>**dwNumberOfProtocols**</term>
	/// <term>This member is undefined for results.</term>
	/// </item>
	/// <item>
	/// <term>**lpafpProtocols**</term>
	/// <term>This member is undefined for results. All needed protocol information is in the CSADDR_INFO structures.</term>
	/// </item>
	/// <item>
	/// <term>**lpszQueryString**</term>
	/// <term>
	/// When dwControlFlags includes **LUP_RETURN_QUERY_STRING**, this member returns the unparsed remainder of the
	/// **lpszServiceInstanceName** specified in the original query. For example, in a namespace that identifies services by
	/// hierarchical names that specify a host name and a file path within that host, the address returned might be the host address and
	/// the unparsed remainder might be the file path. If the **lpszServiceInstanceName** is fully parsed and
	/// **LUP_RETURN_QUERY_STRING** is used, this member is null or points to a zero-length string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**dwNumberOfCsAddrs**</term>
	/// <term>The number of elements in the array of CSADDR_INFO structures.</term>
	/// </item>
	/// <item>
	/// <term>**lpcsaBuffer**</term>
	/// <term>A pointer to an array of CSADDR_INFO structures, with one complete transport address contained within each element.</term>
	/// </item>
	/// <item>
	/// <term>**dwOutputFlags**</term>
	/// <term>The **RESULT_IS_ALIAS** flag indicates this is an alias result.</term>
	/// </item>
	/// <item>
	/// <term>**lpBlob**</term>
	/// <term>A pointer to a provider-specific entity. This member is optional, dependent on the requirements of the NSPv2 service provider.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nc-ws2spi-lpnspv2lookupservicenextex LPNSPV2LOOKUPSERVICENEXTEX
	// Lpnspv2lookupservicenextex; void Lpnspv2lookupservicenextex( HANDLE hAsyncCall, HANDLE hLookup, DWORD dwControlFlags, LPDWORD
	// lpdwBufferLength, LPWSAQUERYSET2W lpqsResults ) {...}
	[PInvokeData("ws2spi.h", MSDNShortId = "957fe544-9a3f-47f4-a98c-0624747650f4")]
	public delegate void LPNSPV2LOOKUPSERVICENEXTEX(HANDLE hAsyncCall, HANDLE hLookup, uint dwControlFlags, ref uint lpdwBufferLength, [Out] IntPtr lpqsResults);

	/// <summary>
	/// The <c>NSPv2SetServiceEx</c> function registers or deregisters a name or service instance within a namespace of a namespace
	/// service provider version-2 (NSPv2) provider.
	/// </summary>
	/// <param name="hAsyncCall">A handle returned from the previous call to NSPv2LookupServiceBegin used for asynchronous calls.</param>
	/// <param name="lpProviderId">A pointer to the GUID of the specific namespace provider in which the name or service is registered.</param>
	/// <param name="lpqsRegInfo">The property information to be updated upon registration.</param>
	/// <param name="essOperation">
	/// <para>The type of operation requested.</para>
	/// <para>
	/// This parameter can be one of the values from the <c>WSAESETSERVICEOP</c> enumeration type defined in the Winsock2.h header file.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RNRSERVICE_REGISTER 0</term>
	/// <term>
	/// Register the service. For the Service Advertising Protocol (SAP) namespace used within a NetWare environment, this means sending
	/// a periodic broadcast. This is an NOP for the Domain Name System (DNS) namespace. For persistent data stores this means updating
	/// the address information.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RNRSERVICE_DEREGISTER 1</term>
	/// <term>
	/// Deregister the service. For the SAP namespace, this means stop sending the periodic broadcast. This is a NOP for the DNS
	/// namespace. For persistent data stores this means deleting address information.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RNRSERVICE_DELETE 2</term>
	/// <term>
	/// Delete the service from dynamic name and persistent spaces. For services represented by multiple CSADDR_INFO structures (using
	/// the SERVICE_MULTIPLE flag), only the supplied address will be deleted, and this must match exactly the corresponding
	/// **CSADDR_INFO** structure supplied when the service was registered.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwControlFlags">
	/// <para>A set of flags that controls the operation requested.</para>
	/// <para>The possible values for this parameter are defined in the Winsock2.h header file.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_MULTIPLE 0x00000001</term>
	/// <term>
	/// Control the scope of the operation. When this value is set, the action is only performed on the given address set. A register
	/// operation does not invalidate existing addresses and a deregister operation only invalidates the given set of addresses. When
	/// this value is absent, service addresses are managed as a group. A register or deregister invalidates all existing addresses
	/// before adding the given address set.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpvClientSessionArg">A pointer to the client session.</param>
	/// <returns>
	/// <para>
	/// The function should return <c>NO_ERROR</c> (zero) if the routine succeeds. It should return <c>SOCKET_ERROR</c> (that is, 1) if
	/// the routine fails and it must set the appropriate error code using WSASetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There is not enough memory available to perform this operation.</term>
	/// </item>
	/// <item>
	/// <term>WSAEACCES</term>
	/// <term>The calling routine does not have sufficient privileges to install the service.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more parameters were invalid, or missing, for this provider.</term>
	/// </item>
	/// <item>
	/// <term>WSAEOPNOTSUPP</term>
	/// <term>
	/// The operation is not supported. This error is returned if the namespace provider does not implement this function. This error
	/// can also be returned if the specified dwControlCode is an unrecognized command.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// <term>Service is unknown. The service cannot be found in the specified namespace.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NSPv2SetServiceEx</c> function is used as part of the namespace service provider version-2 (NSPv2) architecture available
	/// on Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>NSPv2SetServiceEx</c> function can only be used for operations on NS_EMAIL
	/// namespace providers.
	/// </para>
	/// <para>
	/// The NSPv2Startup function is called each time a new client process begins using namespace provider. Providers may use the client
	/// session argument pointed to by the ppvClientSessionArg parameter to store information about this session. This client session
	/// argument can be passed to the <c>NSPv2SetServiceEx</c> function in the lpvClientSessionArg parameter.
	/// </para>
	/// <para>
	/// The <c>NSPv2SetServiceEx</c> function is optional, dependent on the requirements of the NSPv2 provider. If the
	/// <c>NSPv2SetServiceEx</c> function isn't implemented, then the NSPv2 function pointer can be to a stub function that always
	/// returns <c>NO_ERROR</c>.
	/// </para>
	/// <para>The following table lists the possible combination of values for essOperation and dwControlFlags parameters.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>essOperation</term>
	/// <term>dwControlFlags</term>
	/// <term>Service already exists</term>
	/// <term>Service does not exist</term>
	/// </listheader>
	/// <item>
	/// <term>**RNRSERVICE_REGISTER**</term>
	/// <term>None</term>
	/// <term>Overwrites the object. Uses only addresses specified. Object is REGISTERED.</term>
	/// <term>Creates a new object. Uses only addresses specified. Object is REGISTERED.</term>
	/// </item>
	/// <item>
	/// <term>**RNRSERVICE_REGISTER**</term>
	/// <term>**SERVICE_MULTIPLE**</term>
	/// <term>Updates object. Adds new addresses to existing set. Object is REGISTERED.</term>
	/// <term>Creates a new object. Uses all addresses specified. Object is REGISTERED.</term>
	/// </item>
	/// <item>
	/// <term>**RNRSERVICE_DEREGISTER**</term>
	/// <term>None</term>
	/// <term>Removes all addresses, but does not remove object from namespace. Object is DEREGISTERED.</term>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// </item>
	/// <item>
	/// <term>**RNRSERVICE_DEREGISTER**</term>
	/// <term>**SERVICE_MULTIPLE**</term>
	/// <term>
	/// Updates object. Removes only addresses that are specified. Only mark object as DEREGISTERED if no addresses are present. Does
	/// not remove from the namespace.
	/// </term>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// </item>
	/// <item>
	/// <term>**RNRSERVICE_DELETE**</term>
	/// <term>None</term>
	/// <term>Removes object from the namespace.</term>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// </item>
	/// <item>
	/// <term>**RNRSERVICE_DELETE**</term>
	/// <term>**SERVICE_MULTIPLE**</term>
	/// <term>Removes only addresses that are specified. Only removes object from the namespace if no addresses remain.</term>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// </item>
	/// </list>
	/// <para>
	/// When the dwControlFlags parameter is set to <c>SERVICE_MULTIPLE</c>, this enables an application to manage its addresses
	/// independently. This is useful when the application must manage its protocols individually or when the service resides on more
	/// than one computer. For example, when a service uses more than one protocol, one listening socket may abort, but the other
	/// sockets remain operational. In this example, the service could deregister the aborted address without affecting the other addresses.
	/// </para>
	/// <para>
	/// When using <c>SERVICE_MULTIPLE</c>, an application must not let old addresses remain in the object. This can happen if the
	/// application aborts without issuing a <c>RNRSERVICE_DEREGISTER</c> request. When a service registers, it should store its
	/// addresses. On its next call, the service should explicitly deregister these old addresses before registering new addresses.
	/// </para>
	/// <para>
	/// If the <c>NSPv2SetServiceEx</c> function isn't implemented, then calls to that function should be intercepted by a stub function
	/// that returns WSAEOPNOTSUPP. The NSPv2 function pointer to the unimplemented <c>NSPv2SetServiceEx</c> function in the
	/// NSPV2_ROUTINE structure should point be to the stub function.
	/// </para>
	/// <para>Service Properties</para>
	/// <para>
	/// The following table lists WSAQUERYSET2 member names and describes how service property data is represented. Members labeled as
	/// optional and dependent on the requirements of the NSPv2 provider may be supplied as a **NULL** pointer when unused by the
	/// namespace provider.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>WSAQUERYSET2 member name</term>
	/// <term>Service property description</term>
	/// </listheader>
	/// <item>
	/// <term>**dwSize**</term>
	/// <term>Set to the sizeof(WSAQUERYSET2). This is a versioning mechanism.</term>
	/// </item>
	/// <item>
	/// <term>**lpszServiceInstanceName**</term>
	/// <term>A string that contains the service instance name.</term>
	/// </item>
	/// <item>
	/// <term>**lpVersion**</term>
	/// <term>The service instance version number. This member is optional, dependent on the requirements of the NSPv2 service provider.</term>
	/// </item>
	/// <item>
	/// <term>**lpszComment**</term>
	/// <term>A comment string. This member is optional, dependent on the requirements of the NSPv2 service provider.</term>
	/// </item>
	/// <item>
	/// <term>**dwNameSpace**</term>
	/// <term>The namespace identifier. This member is optional, dependent on the requirements of the NSPv2 service provider.</term>
	/// </item>
	/// <item>
	/// <term>**lpNSProviderId**</term>
	/// <term>
	/// The provider identifier. Note that the namespace provider identifier is also passed in the lpProviderId parameter. This member
	/// is optional, dependent on the requirements of the NSPv2 service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**lpszContext**</term>
	/// <term>
	/// The starting point of the query in a hierarchical namespace. This member is optional, dependent on the requirements of the NSPv2
	/// service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**dwNumberOfProtocols**</term>
	/// <term>
	/// The size, in bytes, of the number of entries in the protocol constraint array. This member can be zero.This member is optional,
	/// dependent on the requirements of the NSPv2 service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**lpafpProtocols**</term>
	/// <term>An array of AFPROTOCOLS structures. This member is optional, dependent on the requirements of the NSPv2 service provider.</term>
	/// </item>
	/// <item>
	/// <term>**lpszQueryString**</term>
	/// <term>
	/// Some namespaces (such as whois++) support rich SQL-like queries contained in a simple text string. This parameter is used to
	/// specify that string.This member is optional, dependent on the requirements of the NSPv2 service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>**dwNumberOfCsAddrs**</term>
	/// <term>The number of elements in the array of CSADDR_INFO structures referenced by lpcsaBuffer.</term>
	/// </item>
	/// <item>
	/// <term>**lpcsaBuffer**</term>
	/// <term>A pointer to an array of CSADDR_INFO structures that contain the address or addresses that the service is listening on.</term>
	/// </item>
	/// <item>
	/// <term>**dwOutputFlags**</term>
	/// <term>This member is optional, dependent on the requirements of the NSPv2 service provider.</term>
	/// </item>
	/// <item>
	/// <term>**lpBlob**</term>
	/// <term>
	/// A pointer to a provider-specific entity. This member is required for the NS_EMAIL namespace. This member is optional, dependent
	/// on the requirements for other NSPv2 service providers.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// **Note** It is acceptable for the **iProtocol** member of the CSADDR_INFO structure to contain the manifest constant
	///   **IPROTOCOL_ANY**, indicating a wildcard value. The namespace provider should substitute an acceptable value for the given
	///   address family and socket type.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nc-ws2spi-lpnspv2setserviceex LPNSPV2SETSERVICEEX Lpnspv2setserviceex;
	// void Lpnspv2setserviceex( HANDLE hAsyncCall, LPGUID lpProviderId, LPWSAQUERYSET2W lpqsRegInfo, WSAESETSERVICEOP essOperation,
	// DWORD dwControlFlags, LPVOID lpvClientSessionArg ) {...}
	[PInvokeData("ws2spi.h", MSDNShortId = "596fe0bd-ec11-44f3-bffe-333758171ea6")]
	public delegate void LPNSPV2SETSERVICEEX(HANDLE hAsyncCall, in Guid lpProviderId, in WSAQUERYSET2W lpqsRegInfo, WSAESETSERVICEOP essOperation,
		ServiceInstallFlags dwControlFlags, [In] IntPtr lpvClientSessionArg);

	/// <summary>
	/// The <c>NSPv2Startup</c> function notifies a namespace service provider version-2 (NSPv2) provider that a new client process is
	/// to begin using the provider.
	/// </summary>
	/// <param name="lpProviderId">A pointer to the GUID of the specific namespace provider to notify.</param>
	/// <param name="ppvClientSessionArg"/>
	/// <returns>
	/// <para>
	/// The function should return <c>NO_ERROR</c> (zero) if the routine succeeds. It should return <c>SOCKET_ERROR</c> (that is, 1) if
	/// the routine fails and it must set the appropriate error code using WSASetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There is not enough memory available to perform this operation.</term>
	/// </item>
	/// <item>
	/// <term>WSAEACCES</term>
	/// <term>The calling routine does not have sufficient privileges to initialize the service.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more parameters were invalid, or missing, for this provider.</term>
	/// </item>
	/// <item>
	/// <term>WSAEOPNOTSUPP</term>
	/// <term>The operation is not supported. This error is returned if the namespace provider does not implement this function.</term>
	/// </item>
	/// <item>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// <term>Service is unknown. The service cannot be found in the specified namespace.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NSPv2Startup</c> function is used as part of the namespace service provider version-2 (NSPv2) architecture available on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>NSPv2Startup</c> function can only be used for operations on NS_EMAIL namespace providers.
	/// </para>
	/// <para>
	/// The <c>NSPv2Startup</c> function is called each time a new client process begins using namespace provider. Providers may use the
	/// client session argument pointed to by the ppvClientSessionArg parameter to store information about this session. The value in
	/// the ppvClientSessionArg parameter will be passed to subsequent NSPv2 function calls in the same session. The client session
	/// argument may <c>NULL</c>, if the namespace provider does not require this information.
	/// </para>
	/// <para>
	/// The <c>NSPv2Startup</c> function is called when a new client session initializes. The <c>NSPv2Startup</c> and NSPv2Cleanup
	/// functions must be called as pairs.
	/// </para>
	/// <para>
	/// The <c>NSPv2Startup</c> function must be called successfully before calling the NSPv2Cleanup function. It is permissible to make
	/// more than one <c>NSPv2Startup</c> call. However, for each <c>NSPv2Startup</c> call, a corresponding <c>NSPv2Cleanup</c> call
	/// must also be issued. Only the final <c>NSPv2Cleanup</c> for the service provider does the actual cleanup; the preceding calls
	/// decrement an internal reference count in the namespace service provider.
	/// </para>
	/// <para>
	/// The <c>NSPv2Startup</c>, NSPv2ClientSessionRundown, and NSPv2Cleanup functions are optional, dependent on the requirements of
	/// the NSPv2 provider.
	/// </para>
	/// <para>
	/// If the <c>NSPv2Startup</c> function isn't implemented, then calls to that function should be intercepted by a stub function that
	/// returns WSAEOPNOTSUPP. The NSPv2 function pointer to the unimplemented <c>NSPv2Startup</c> function in the NSPV2_ROUTINE
	/// structure should point be to the stub function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nc-ws2spi-lpnspv2startup LPNSPV2STARTUP Lpnspv2startup; INT
	// Lpnspv2startup( LPGUID lpProviderId, LPVOID *ppvClientSessionArg ) {...}
	[PInvokeData("ws2spi.h", MSDNShortId = "93224e66-9c94-4b5c-af11-ae988b74bc03")]
	public delegate WSRESULT LPNSPV2STARTUP(in Guid lpProviderId, out IntPtr ppvClientSessionArg);

	/// <summary>The WSC_PROVIDER_AUDIT_INFO structure is not currently used.</summary>
	/// <remarks>The WSC_PROVIDER_AUDIT_INFO structure is not currently used.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/ne-ws2spi-wsc_provider_info_type typedef enum _WSC_PROVIDER_INFO_TYPE {
	// ProviderInfoLspCategories, ProviderInfoAudit } WSC_PROVIDER_INFO_TYPE;
	[PInvokeData("ws2spi.h", MSDNShortId = "7f93a660-6f53-4e3c-a938-54a13b34258d")]
	public enum WSC_PROVIDER_INFO_TYPE
	{
		/// <summary>
		/// The LSP category information for a protocol entry in a layered protocol. The information class should point to a DWORD value
		/// containing the appropriate LSP category flags implemented by LSP.
		/// </summary>
		ProviderInfoLspCategories,

		/// <summary>
		/// The LSP class information for audit information for the LSP entry. The information class should point to a
		/// WSC_PROVIDER_AUDIT_INFO structure containing an audit record for the LSP.
		/// </summary>
		ProviderInfoAudit,
	}

	/// <summary>
	/// The <c>WPUCompleteOverlappedRequest</c> function performs overlapped I/O completion notification for overlapped I/O operations.
	/// </summary>
	/// <param name="s">The service provider socket created by WPUCreateSocketHandle.</param>
	/// <param name="lpOverlapped">
	/// A pointer to a WSAOVERLAPPED structure associated with the overlapped I/O operation whose completion is to be notified.
	/// </param>
	/// <param name="dwError">The completion status of the overlapped I/O operation whose completion is to be notified.</param>
	/// <param name="cbTransferred">
	/// The number of bytes transferred to or from client buffers (the direction of the transfer depends on the send or receive nature
	/// of the overlapped I/O operation whose completion is to be notified).
	/// </param>
	/// <param name="lpErrno">A pointer to the error code resulting from execution of this function.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WPUCompleteOverlappedRequest</c> returns zero and notifies completion of the overlapped I/O operation
	/// according to the mechanism selected by the client (signals an event found in the WSAOVERLAPPED structure referenced by
	/// lpOverlapped and/or queues a completion status report to the completion port associated with the socket if a completion port is
	/// associated). Otherwise, <c>WPUCompleteOverlappedRequest</c> returns SOCKET_ERROR, and a specific error code is available in lpErrno.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The socket passed in the s parameter is not a socket created by WPUCreateSocketHandle.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WPUCompleteOverlappedRequest</c> function performs overlapped I/O completion notification for overlapped I/O operations
	/// where the client-specified completion mechanism is something other than user mode–asynchronous procedure call (APC). This
	/// function can only be used for socket handles created by WPUCreateSocketHandle.
	/// </para>
	/// <para>
	/// **Note** This function is different from other functions with the "WPU" prefix in that it is not accessed through the upcall
	/// table. Instead, it is exported directly by Ws2_32.dll. Service providers that need to call this function should link with
	/// WS2_32.lib or use appropriate operating system functions such as LoadLibrary and GetProcAddress to retrieve the function pointer.
	/// </para>
	/// <para>
	/// The function **WPUCompleteOverlappedRequest** is used by service providers that do not implement Installable File System (IFS)
	/// functionality directly for the socket handles they expose. It performs completion notification for any overlapped I/O request
	/// for which the specified completion notification is other than a user-mode APC. **WPUCompleteOverlappedRequest** is supported
	/// only for the socket handles created by WPUCreateSocketHandle and not for sockets created by a service provider directly.
	/// </para>
	/// <para>
	/// If the client selects a user-mode APC as the notification method, the service provider should use WPUQueueApc or another
	/// appropriate operating system function to perform the completion notification. If user-mode APC is not selected by the client, a
	/// service provider that does not implement IFS functionality directly cannot determine whether or not the client has associated a
	/// completion port with the socket handle. Thus, it cannot determine whether the completion notification method should be queuing a
	/// completion status record to a completion port or signaling an event found in the WSAOVERLAPPED structure. The Windows Socket 2
	/// architecture keeps track of any completion port association with a socket created by WPUCreateSocketHandle and can make a
	/// correct decision between completion port-based notification or event-based notification.
	/// </para>
	/// <para>
	/// When <c>WPUCompleteOverlappedRequest</c> queues a completion indication, it sets the <c>InternalHigh</c> member of the
	/// WSAOVERLAPPED structure to the count of bytes transferred. Then, it sets the <c>Internal</c> member to some OS-dependent value
	/// other than the special value WSS_OPERATION_IN_PROGRESS. There may be some slight delay after <c>WPUCompleteOverlappedRequest</c>
	/// returns before these values appear, since processing may occur asynchronously. However, the <c>InternalHigh</c> value (byte
	/// count) is guaranteed to be set by the time <c>Internal</c> is set.
	/// </para>
	/// <para>
	/// <c>WPUCompleteOverlappedRequest</c> works as stated (performs the completion notification as requested by the client) whether or
	/// not the socket handle has been associated with a completion port.
	/// </para>
	/// <para><c>Interaction with WSPGetOverlappedResult</c></para>
	/// <para>
	/// The behavior of <c>WPUCompleteOverlappedRequest</c> places some constraints on how a service provider implements
	/// WSPGetOverlappedResult since only the <c>Offset</c> and <c>OffsetHigh</c> members of the WSAOVERLAPPED structure are exclusively
	/// controlled by the service provider, yet three values (byte count, flags, and error) must be retrieved from the structure by
	/// <c>WSPGetOverlappedResult</c>. A service provider may accomplish this any way it chooses as long as it interacts with the
	/// behavior of <c>WPUCompleteOverlappedRequest</c> properly. However, a typical implementation is as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>At the start of overlapped processing, the service provider sets <c>Internal</c> to WSS_OPERATION_IN_PROGRESS.</term>
	/// </item>
	/// <item>
	/// <term>
	/// When the I/O operation has been completed, the provider sets <c>OffsetHigh</c> to the Windows Socket 2 error code resulting from
	/// the operation, sets <c>Offset</c> to the flags resulting from the I/O operation, and calls <c>WPUCompleteOverlappedRequest</c>,
	/// passing the transfer byte count as one of the parameters. <c>WPUCompleteOverlappedRequest</c> eventually sets
	/// <c>InternalHigh</c> to the transfer byte count, then sets <c>Internal</c> to a value other than WSS_OPERATION_IN_PROGRESS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// When WSPGetOverlappedResult is called, the service provider checks <c>Internal</c>. If it is WSS_OPERATION_IN_PROGRESS, the
	/// provider waits on the event handle in the <c>hEvent</c> member or returns an error, based on the setting of the FWAIT flag of
	/// <c>WSPGetOverlappedResult</c>. If not in progress, or after completion of waiting, the provider returns the values from
	/// <c>InternalHigh</c>, <c>OffsetHigh</c>, and <c>Offset</c> as the transfer count, operation result error code, and flags respectively.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wpucompleteoverlappedrequest int
	// WPUCompleteOverlappedRequest( SOCKET s, LPWSAOVERLAPPED lpOverlapped, DWORD dwError, DWORD cbTransferred, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "b0e5015f-d23f-46da-91b1-f646111f70f9")]
	public static extern WSRESULT WPUCompleteOverlappedRequest(SOCKET s, ref WSAOVERLAPPED lpOverlapped, uint dwError, uint cbTransferred, out int lpErrno);

	/// <summary>
	/// The <c>WSAAdvertiseProvider</c> function makes a specific namespace version-2 provider available for all eligible clients.
	/// </summary>
	/// <param name="puuidProviderId">A pointer to the provider ID of the namespace provider to be advertised.</param>
	/// <param name="pNSPv2Routine">
	/// A pointer to a <c>NSPV2_ROUTINE</c> structure with the namespace service provider version-2 entry points supported by the provider.
	/// </param>
	/// <returns>
	/// <para>If no error occurs, WSAProviderCompleteAsyncCall returns zero.</para>
	/// <para>
	/// If the function fails, the return value is SOCKET_ERROR. To get extended error information, call WSAGetLastError, which returns
	/// one of the following extended error values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There was insufficient memory to perform the operation.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>An internal error occurred.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>
	/// A parameter was not valid. This error is returned if the puuidProviderId or pNSPv2Routine parameters were **NULL**. This error
	/// is also returned if the NSPv2LookupServiceBegin, NSPv2LookupServiceNextEx, or NSPv2LookupServiceEnd members of the NSPV2_ROUTINE
	/// structure pointed to by the pNSPv2Routine parameter are NULL. A namespace version-2 provider must at least support name
	/// resolution which this minimum set of functions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINVALIDPROVIDER</term>
	/// <term>The namespace provider could not be found for the specified puuidProviderId parameter.</term>
	/// </item>
	/// <item>
	/// <term>WSANOTINITIALISED</term>
	/// <term>
	/// The Ws2_32.dll has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSAAdvertiseProvider</c> function is used as part of the namespace service provider version-2 (NSPv2) architecture
	/// available on Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>WSAAdvertiseProvider</c> function can only be used for operations on NS_EMAIL
	/// namespace providers.
	/// </para>
	/// <para>
	/// The <c>WSAAdvertiseProvider</c> function advertises an instance of a NSPv2 provider for clients to find. If the instance to be
	/// advertised is an instance of an application-type provider (a namespace provider where the <c>dwProvideType</c> member of the
	/// NAPI_PROVIDER_INSTALLATION_BLOB structure is <c>ProviderType_Application</c>), the advertised provider instance will be visible
	/// to all the client processes running under the same user and in the same session as the caller of <c>WSAAdvertiseProvider</c>.
	/// </para>
	/// <para>
	/// In general, NSPv2 providers are implemented in processes other than the calling applications. NSPv2 providers are not activated
	/// as a result of client activity. Each provider hosting application decides when to make a specific provider available or
	/// unavailable by calling the <c>WSAAdvertiseProvider</c> and WSAUnadvertiseProvider functions. The client activity only results in
	/// attempts to contact the provider, when available (when the namespace provider is advertised).
	/// </para>
	/// <para>
	/// The <c>WSAAdvertiseProvider</c> function is called by any application that wants to make a specific provider available for all
	/// eligible clients (currently all the applications running with the same credentials as the hosting application, and in the same
	/// user session).
	/// </para>
	/// <para>
	/// A process can implement and advertise multiple providers at the same time. Windows Sockets will manage the namespace providers
	/// by dispatching calls to the correct one. It will also hide RPC interface details and translates cross-process calls into
	/// in-process calls. So that the NSPv2 provider has only to implement a table of entry point functions similar to the NSP_ROUTINE
	/// structure used by an NSPv1 provider. A NSPv2 provider does not have to worry about RPC specific requirements (data marshalling
	/// and serialization, for example).
	/// </para>
	/// <para>
	/// The <c>WSAAdvertiseProvider</c> caller passes a pointer to an NSPV2_ROUTINE structure in the pNSPv2Routine parameter with the
	/// NSPv2 entry points supported by the provider.
	/// </para>
	/// <para>The WSAUnadvertiseProvider function makes a specific namespace provider no longer available for clients.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wsaadvertiseprovider INT WSAAPI WSAAdvertiseProvider( const
	// GUID *puuidProviderId, const LPCNSPV2_ROUTINE pNSPv2Routine );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "574ebfa4-d7f2-43c2-b1ec-35ce3db9151f")]
	public static extern WSRESULT WSAAdvertiseProvider(in Guid puuidProviderId, in NSPV2_ROUTINE pNSPv2Routine);

	/// <summary>
	/// The <c>WSAProviderCompleteAsyncCall</c> function notifies a client when an asynchronous call to a namespace version-2 provider
	/// is completed.
	/// </summary>
	/// <param name="hAsyncCall">
	/// The handle passed to the asynchronous call being completed. This handle is passed by the client to the namespace version-2
	/// provider in the asynchronous function call.
	/// </param>
	/// <param name="iRetCode">The return code for the asynchronous call to the namespace version-2 provider.</param>
	/// <returns>
	/// <para>If no error occurs, <c>WSAProviderCompleteAsyncCall</c> returns zero.</para>
	/// <para>
	/// If the function fails, the return value is SOCKET_ERROR. To get extended error information, call WSAGetLastError, which returns
	/// one of the following extended error values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There was insufficient memory to perform the operation.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>An internal error occurred.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>A parameter was not valid. This error is returned if the hAsyncCall parameter was **NULL**.</term>
	/// </item>
	/// <item>
	/// <term>WSANOTINITIALISED</term>
	/// <term>
	/// The Ws2_32.dll has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSAProviderCompleteAsyncCall</c> function is used as part of the namespace service provider version-2 (NSPv2)
	/// architecture available on Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the WSAUnadvertiseProvider function can only be used for operations on NS_EMAIL
	/// namespace providers. Asynchronous calls to NSPv2 providers are not supported on Windows Vista and Windows Server 2008. So the
	/// <c>WSAProviderCompleteAsyncCall</c> is not currently applicable. This function is planned for use in later versions of Windows
	/// when asynchronous calls to namespace providers are supported.
	/// </para>
	/// <para>
	/// In general, NSPv2 providers are implemented in processes other than the calling applications. NSPv2 providers are not activated
	/// as result of client activity. Each provider hosting application decides when to make a specific provider available or
	/// unavailable by calling the WSAAdvertiseProvider and WSAUnadvertiseProvider functions. The client activity only results in
	/// attempts to contact the provider, when available (when the namespace provider is advertised).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wsaprovidercompleteasynccall INT WSAAPI
	// WSAProviderCompleteAsyncCall( HANDLE hAsyncCall, INT iRetCode );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "2bbc20ae-ad6d-47f6-8ca9-dd5559236fbe")]
	public static extern WSRESULT WSAProviderCompleteAsyncCall(HANDLE hAsyncCall, int iRetCode);

	/// <summary>
	/// The <c>WSAUnadvertiseProvider</c> function makes a specific namespace version-2 provider no longer available for clients.
	/// </summary>
	/// <param name="puuidProviderId">A pointer to the provider ID of the namespace provider.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSAUnadvertiseProvider</c> returns zero. Otherwise, it returns <c>SOCKET_ERROR</c>, and a specific error
	/// code is available by calling WSAGetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>A parameter was not valid. This error is returned if the puuidProviderId parameter was **NULL**.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSAUnadvertiseProvider</c> function is used as part of the namespace service provider version-2 (NSPv2) architecture
	/// available on Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>WSAUnadvertiseProvider</c> function can only be used for operations on NS_EMAIL
	/// namespace providers.
	/// </para>
	/// <para>
	/// In general, NSPv2 providers are implemented in processes other than the calling applications. NSPv2 providers are not activated
	/// as result of client activity. Each provider hosting application decides when to make a specific provider available or
	/// unavailable by calling the WSAAdvertiseProvider and <c>WSAUnadvertiseProvider</c> functions. The client activity only results in
	/// attempts to contact the provider, when available (when the namespace provider is advertised).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wsaunadvertiseprovider INT WSAAPI WSAUnadvertiseProvider(
	// const GUID *puuidProviderId );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "5975b496-53a7-4f8a-8efc-27ef447596c2")]
	public static extern WSRESULT WSAUnadvertiseProvider(in Guid puuidProviderId);

	/// <summary>
	/// The <c>WSCDeinstallProvider</c> function removes the specified transport provider from the system configuration database.
	/// </summary>
	/// <param name="lpProviderId">
	/// A pointer to a globally unique identifier (GUID) for the provider. This value is stored within each WSAProtocol_Info structure.
	/// </param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCDeinstallProvider</c> returns zero. Otherwise, it returns <c>SOCKET_ERROR</c>, and a specific error
	/// code is available in lpErrno.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The lpProviderId parameter does not specify a valid provider.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The lpErrno parameter is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
	/// administrative privileges required to write to the Windows Sockets registry, or a failure occurred when opening a catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSCDeinstallProvider</c> function removes the common Windows Sockets 2 configuration information for the specified
	/// provider. After this routine completes successfully, the configuration information stored in the registry will be changed.
	/// However, any Ws2_32.dll instances currently in memory will not be able to recognize this change.
	/// </para>
	/// <para>
	/// On success, <c>WSCDeinstallProvider</c> will attempt to alert all interested applications that have registered for notification
	/// of the change by calling WSAProviderConfigChange.
	/// </para>
	/// <para>
	/// The <c>WSCDeinstallProvider</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCDeinstallProvider</c> is called by a user that is not a member of the Administrators group, the function call will fail
	/// and <c>WSANO_RECOVERY</c> is returned in the lpErrno parameter.
	/// </para>
	/// <para>
	/// For computers running Windows Vista or Windows Server 2008, this function can also fail because of user account control (UAC).
	/// If an application that contains this function is executed by a user logged on as a member of the Administrators group other than
	/// the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// <para>
	/// The caller of this function must remove any additional files or service provider–specific configuration information that is
	/// needed to completely uninstall the service provider.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscdeinstallprovider int WSCDeinstallProvider( LPGUID
	// lpProviderId, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "9a2afd11-1944-491f-9c92-9dbac6b3b28e")]
	public static extern WSRESULT WSCDeinstallProvider(in Guid lpProviderId, out int lpErrno);

	/// <summary>
	/// The <c>WSCDeinstallProvider32</c> function removes the specified 32-bit transport provider from the system configuration database.
	/// </summary>
	/// <param name="lpProviderId">
	/// A pointer to a globally unique identifier (GUID) for the provider. This value is stored within each WSAProtocol_Info structure.
	/// </param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCDeinstallProvider32</c> returns zero. Otherwise, it returns <c>SOCKET_ERROR</c>, and a specific error
	/// code is available in lpErrno.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The lpProviderId parameter does not specify a valid provider.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The lpErrno parameter is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
	/// administrative privileges required to write to the Windows Sockets registry, or a failure occurred when opening a catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCDeinstallProvider32</c> is a strictly 32-bit version of WSCDeinstallProvider. On a 64-bit computer, all calls not
	/// specifically 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that
	/// execute on a 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve
	/// compatibility. The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// The <c>WSCDeinstallProvider32</c> function removes the common Windows Sockets 2 configuration information for the specified
	/// 32-bit provider. After this routine completes successfully, the configuration information stored in the registry will be
	/// changed. However, any Ws2_32.dll instances currently in memory will not be able to recognize this change.
	/// </para>
	/// <para>
	/// On success, <c>WSCDeinstallProvider32</c> will attempt to alert all interested applications that have registered for
	/// notification of the change by calling WSAProviderConfigChange.
	/// </para>
	/// <para>
	/// The <c>WSCDeinstallProvider32</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCDeinstallProvider32</c> is called by a user that is not a member of the Administrators group, the function call will fail
	/// and <c>WSANO_RECOVERY</c> is returned in the lpErrno parameter.
	/// </para>
	/// <para>
	/// For computers running Windows Vista or Windows Server 2008, this function can also fail because of user account control (UAC).
	/// If an application that contains this function is executed by a user logged on as a member of the Administrators group other than
	/// the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// <para>
	/// The caller of this function must remove any additional files or service provider–specific configuration information that is
	/// needed to completely uninstall the service provider.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscdeinstallprovider32 int WSCDeinstallProvider32( LPGUID
	// lpProviderId, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "3de74059-dbfb-49b9-830b-7b2f81f8b68c")]
	public static extern WSRESULT WSCDeinstallProvider32(in Guid lpProviderId, out int lpErrno);

	/// <summary>
	/// The <c>WSCEnableNSProvider</c> function changes the state of a given namespace provider. It is intended to give the end-user the
	/// ability to change the state of the namespace providers.
	/// </summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the namespace provider.</param>
	/// <param name="fEnable">
	/// A Boolean value that, if <c>TRUE</c>, the provider is set to the active state. If <c>FALSE</c>, the provider is disabled and
	/// will not be available for query operations or service registration.
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>WSCEnableNSProvider</c> function returns <c>NO_ERROR</c> (zero). Otherwise, it returns
	/// <c>SOCKET_ERROR</c> if the function fails, and you must retrieve the appropriate error code using the WSAGetLastError function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The lpProviderId parameter points to memory that is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The specified namespace provider identifier is invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSCEnableNSProvider</c> function is intended to be used to change the state of the namespace providers. An independent
	/// software vendor (ISV) should not normally de-activate another ISV namespace provider in order to activate its own. The choice
	/// should be left to the user.
	/// </para>
	/// <para>
	/// The <c>WSCEnableNSProvider</c> function does not affect applications that are already running. Newly installed namespace
	/// providers will not be visible to applications nor will the changes in a namespace provider's activation state be visible.
	/// Applications launched after the call to <c>WSCEnableNSProvider</c> will see the changes.
	/// </para>
	/// <para>
	/// The <c>WSCEnableNSProvider</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCEnableNSProvider</c> is called by a user that is not a member of the Administrators group, the function call will fail.
	/// </para>
	/// <para>
	/// For computers running Windows Vista or Windows Server 2008, this function can also fail because of user account control (UAC).
	/// If an application that contains this function is executed by a user logged on as a member of the Administrators group other than
	/// the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscenablensprovider INT WSCEnableNSProvider( LPGUID
	// lpProviderId, BOOL fEnable );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "2dff5af6-3011-4e3f-b812-fffaca8fa2d9")]
	public static extern WSRESULT WSCEnableNSProvider(in Guid lpProviderId, [MarshalAs(UnmanagedType.Bool)] bool fEnable);

	/// <summary>
	/// The <c>WSCEnableNSProvider32</c> function enables or disables a specified 32-bit namespace provider. It is intended to give the
	/// end-user the ability to change the state of the namespace providers.
	/// </summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the namespace provider.</param>
	/// <param name="fEnable">
	/// A Boolean value that, if <c>TRUE</c>, the namespace provider is set to the active state. If <c>FALSE</c>, the namespace provider
	/// is disabled and will not be available for query operations or service registration.
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>WSCEnableNSProvider32</c> function returns <c>NO_ERROR</c> (zero). Otherwise, it returns
	/// <c>SOCKET_ERROR</c> if the function fails, and you must retrieve the appropriate error code using the WSAGetLastError function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The lpProviderId parameter points to memory that is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The specified namespace provider identifier is invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSCEnableNSProvider32</c> function is intended to be used to change the state of the namespace providers. An independent
	/// software vendor (ISV) should not normally de-activate another ISV's namespace provider in order to activate its own. The choice
	/// should be left to the user.
	/// </para>
	/// <para>
	/// <c>WSCEnableNSProvider32</c> is a strictly 32-bit version of WSCEnableNSProvider. On a 64-bit computer, all calls not
	/// specifically 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that
	/// execute on a 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve
	/// compatibility. The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// The namespace configuration functions do not affect applications that are already running. Newly installed namespace providers
	/// will not be visible to applications nor will the changes in a namespace provider's activation state. Applications launched after
	/// the call to <c>WSCEnableNSProvider32</c> will see the changes.
	/// </para>
	/// <para>
	/// The <c>WSCEnableNSProvider32</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCEnableNSProvider32</c> is called by a user that is not a member of the Administrators group, the function call will fail.
	/// </para>
	/// <para>
	/// For computers running on Windows Vista or Windows Server 2008, this function can also fail because of user account control
	/// (UAC). If an application that contains this function is executed by a user logged on as a member of the Administrators group
	/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscenablensprovider32 INT WSCEnableNSProvider32( LPGUID
	// lpProviderId, BOOL fEnable );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "5ab4f8bd-d32d-4962-aac7-2d92847d0e03")]
	public static extern WSRESULT WSCEnableNSProvider32(in Guid lpProviderId, [MarshalAs(UnmanagedType.Bool)] bool fEnable);

	/// <summary>The <c>WSCEnumNameSpaceProviders32</c> function returns information on available 32-bit namespace providers.</summary>
	/// <param name="lpdwBufferLength">
	/// On input, the number of bytes contained in the buffer pointed to by lpnspBuffer. On output (if the function fails, and the error
	/// is WSAEFAULT), the minimum number of bytes to allocate for the lpnspBuffer buffer to allow it to retrieve all the requested
	/// information. The buffer passed to <c>WSCEnumNameSpaceProviders32</c> must be sufficient to hold all of the namespace information.
	/// </param>
	/// <param name="lpnspBuffer">
	/// A buffer that is filled with WSANAMESPACE_INFOW structures. The returned structures are located consecutively at the head of the
	/// buffer. Variable sized information referenced by pointers in the structures point to locations within the buffer located between
	/// the end of the fixed sized structures and the end of the buffer. The number of structures filled in is the return value of <c>WSCEnumNameSpaceProviders32</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// The <c>WSCEnumNameSpaceProviders32</c> function returns the number of WSANAMESPACE_INFOW structures copied into lpnspBuffer.
	/// Otherwise, the value SOCKET_ERROR is returned, and a specific error number can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The lpnspBuffer parameter was a **NULL** pointer or the buffer length, lpdwBufferLength, was too small to receive all the
	/// relevant WSANAMESPACE_INFOW structures and associated information. When this error is returned, the buffer length required is
	/// returned in the lpdwBufferLength parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSANOTINITIALISED</term>
	/// <term>
	/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There was insufficient memory to perform the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCEnumNameSpaceProviders32</c> is a strictly 32-bit version of WSAEnumNameSpaceProviders. On a 64-bit computer, all calls
	/// not specifically 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes
	/// that execute on a 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and
	/// preserve compatibility. The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// The 32-bit SPI function is equivalent to the native API function (WSAEnumNameSpaceProviders) because there is no concept of a
	/// "hidden" namespace provider.
	/// </para>
	/// <para>The <c>WSCEnumNameSpaceProviders32</c> function is a Unicode only function and returns WSANAMESPACE_INFOEXW structures.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscenumnamespaceproviders32 INT WSAAPI
	// WSCEnumNameSpaceProviders32( LPDWORD lpdwBufferLength, LPWSANAMESPACE_INFOW lpnspBuffer );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("ws2spi.h", MSDNShortId = "792737d9-231d-4524-b1a6-b9904951d5b4")]
	public static extern WSRESULT WSCEnumNameSpaceProviders32(ref uint lpdwBufferLength, [In, Out] IntPtr lpnspBuffer);

	/// <summary>The <c>WSCEnumNameSpaceProvidersEx32</c> function retrieves information on available 32-bit namespace providers.</summary>
	/// <param name="lpdwBufferLength">
	/// On input, the number of bytes contained in the buffer pointed to by lpnspBuffer. On output (if the function fails, and the error
	/// is WSAEFAULT), the minimum number of bytes to allocate for the lpnspBuffer buffer to allow it to retrieve all the requested
	/// information. The buffer passed to <c>WSCEnumNameSpaceProvidersEx32</c> must be sufficient to hold all of the namespace information.
	/// </param>
	/// <param name="lpnspBuffer">
	/// A buffer that is filled with WSANAMESPACE_INFOEXW structures. The returned structures are located consecutively at the head of
	/// the buffer. Variable sized information referenced by pointers in the structures point to locations within the buffer located
	/// between the end of the fixed sized structures and the end of the buffer. The number of structures filled in is the return value
	/// of <c>WSCEnumNameSpaceProvidersEx32</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// The <c>WSCEnumNameSpaceProvidersEx32</c> function returns the number of WSANAMESPACE_INFOEXW structures copied into lpnspBuffer.
	/// Otherwise, the value SOCKET_ERROR is returned, and a specific error number can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The buffer length was too small to receive all the relevant WSANAMESPACE_INFOEXW structures and associated information or the
	/// lpnspBuffer parameter was a **NULL** pointer. When this error is returned, the buffer length required is returned in the
	/// lpdwBufferLength parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSANOTINITIALISED</term>
	/// <term>
	/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>There was insufficient memory to perform the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCEnumNameSpaceProvidersEx32</c> is a strictly 32-bit version of WSAEnumNameSpaceProvidersEx. On a 64-bit computer, all
	/// calls not specifically 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog.
	/// Processes that execute on a 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog
	/// and preserve compatibility. The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// Currently, the only namespace included with Windows that uses information in the <c>ProviderSpecific</c> member of the
	/// WSANAMESPACE_INFOEXW structure are namespace providers for the NS_EMAIL namespace. The format of the <c>ProviderSpecific</c>
	/// member for an NS_EMAIL namespace provider is a NAPI_PROVIDER_INSTALLATION_BLOB structure.
	/// </para>
	/// <para>
	/// The 32-bit SPI function is equivalent to the native API function (WSAEnumNameSpaceProvidersEx) because there is no concept of a
	/// "hidden" namespace provider.
	/// </para>
	/// <para>
	/// The provider-specific data blob associated with namespace entry passed in the lpProviderInfo parameter to the
	/// WSCInstallNameSpaceEx32 function can be queried using <c>WSCEnumNameSpaceProvidersEx32</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscenumnamespaceprovidersex32 INT WSAAPI
	// WSCEnumNameSpaceProvidersEx32( LPDWORD lpdwBufferLength, LPWSANAMESPACE_INFOEXW lpnspBuffer );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("ws2spi.h", MSDNShortId = "544120b2-7575-4deb-8429-2bd4582eceef")]
	public static extern WSRESULT WSCEnumNameSpaceProvidersEx32(ref uint lpdwBufferLength, [In, Out] IntPtr lpnspBuffer);

	/// <summary>
	/// The <c>WSCEnumProtocols</c> function retrieves information about available transport protocols and this overload appropriately calls
	/// either the 32 or 64-bit function.
	/// </summary>
	/// <param name="lpiProtocols">
	/// A list of iProtocol values. This parameter is optional; if lpiProtocols is NULL, information on all available protocols is returned.
	/// Otherwise, information is retrieved only for those protocols listed in the array.
	/// </param>
	/// <returns>A sequence of WSAPROTOCOL_INFOW structures.</returns>
	/// <remarks>
	/// <para>
	/// The <c>WSCEnumProtocols</c> function is used to discover information about the collection of transport protocols installed on the
	/// local computer. This function differs from its API counterpart (WSAEnumProtocols) in that WSAPROTOCOL_INFOW structures for all
	/// installed protocols are returned. This includes protocols that the service provider has set the <c>PFL_HIDDEN</c> flag in the
	/// <c>dwProviderFlags</c> member of the <c>WSAPROTOCOL_INFOW</c> structure to indicate to the Ws2_32.dll that this protocol should not
	/// be returned in the result buffer generated by <c>WSAEnumProtocols</c> function. In addition, the <c>WSCEnumProtocols</c> also returns
	/// data for <c>WSAPROTOCOL_INFOW</c> structures that have a chain length of zero ( a dummy LSP provider). The <c>WSAEnumProtocols</c>
	/// only returns information on base protocols and protocol chains that lack the <c>PFL_HIDDEN</c> flag and don't have a protocol chain
	/// length of zero.
	/// </para>
	/// <para>
	/// **Note** Layered Service Providers are deprecated. Starting with Windows 8 and Windows Server 2012, use Windows Filtering Platform.
	/// </para>
	/// <para>
	/// The lpiProtocols parameter can be used as a filter to constrain the amount of information provided. Typically, a null pointer is
	/// supplied so the function will return information on all available transport protocols.
	/// </para>
	/// <para>
	/// A WSAPROTOCOL_INFOW structure is provided in the buffer pointed to by lpProtocolBuffer for each requested protocol. If the supplied
	/// buffer is not large enough (as indicated by the input value of lpdwBufferLength), the value pointed to by lpdwBufferLength will be
	/// updated to indicate the required buffer size. The Windows Sockets SPI client should then obtain a large enough buffer and call this
	/// function again. The <c>WSCEnumProtocols</c> function cannot enumerate over multiple calls; the passed-in buffer must be large enough
	/// to hold all expected entries in order for the function to succeed. This reduces the complexity of the function and should not pose a
	/// problem because the number of protocols loaded on a local computer is typically small.
	/// </para>
	/// <para>
	/// The order in which the WSAPROTOCOL_INFOW structures appear in the buffer coincides with the order in which the protocol entries were
	/// registered by the service provider with the WS2_32.dll, or with any subsequent reordering that may have occurred through the Windows
	/// Sockets applet supplied for establishing default transport providers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscenumprotocols int WSCEnumProtocols( LPINT lpiProtocols,
	// LPWSAPROTOCOL_INFOW lpProtocolBuffer, LPDWORD lpdwBufferLength, LPINT lpErrno );
	[PInvokeData("ws2spi.h", MSDNShortId = "c2e5332f-3327-4624-96b4-8e321795961d")]
	public static IEnumerable<WSAPROTOCOL_INFO> WSCEnumProtocols(params int[]? lpiProtocols)
	{
		if (lpiProtocols?.Length == 0)
			lpiProtocols = null;
		WSCEnumProtocolsFunc f = IntPtr.Size == 8 ? WSCEnumProtocols : WSCEnumProtocols32;
		uint bufLen = 16384;
		using var mem = new SafeHGlobalHandle((int)bufLen);
		var res = f(lpiProtocols, mem, ref bufLen, out var err);
		if (res == SOCKET_ERROR)
		{
			if (err != WSRESULT.WSAENOBUFS)
				throw new Win32Exception(err);
			else
			{
				mem.Size = (int)bufLen;
				res = f(lpiProtocols, mem, ref bufLen, out err);
				if (res == SOCKET_ERROR)
					throw new Win32Exception(err);
			}
		}
		return mem.ToEnumerable<WSAPROTOCOL_INFO>((int)res);
	}

	private delegate WSRESULT WSCEnumProtocolsFunc(int[]? lpiProtocols, IntPtr lpProtocolBuffer, ref uint lpdwBufferLength, out int lpErrno);

	/// <summary>The <c>WSCEnumProtocols</c> function retrieves information about available transport protocols.</summary>
	/// <param name="lpiProtocols">
	/// A <c>NULL</c>-terminated array of iProtocol values. This parameter is optional; if lpiProtocols is NULL, information on all
	/// available protocols is returned. Otherwise, information is retrieved only for those protocols listed in the array.
	/// </param>
	/// <param name="lpProtocolBuffer">A pointer to a buffer that is filled with WSAPROTOCOL_INFOW structures.</param>
	/// <param name="lpdwBufferLength">
	/// On input, size of the lpProtocolBuffer buffer passed to <c>WSCEnumProtocols</c>, in bytes. On output, the minimum buffer size,
	/// in bytes, that can be passed to <c>WSCEnumProtocols</c> to retrieve all the requested information.
	/// </param>
	/// <param name="lpErrno">A pointer to the error code.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCEnumProtocols</c> returns the number of protocols to be reported on. Otherwise, a value of
	/// SOCKET_ERROR is returned and a specific error code is available in lpErrno.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One of more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>Indicates that one of the specified parameters was invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOBUFS</term>
	/// <term>
	/// Buffer length was too small to receive all the relevant WSAProtocol_Info structures and associated information. Pass in a buffer
	/// at least as large as the value returned in lpdwBufferLength.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSCEnumProtocols</c> function is used to discover information about the collection of transport protocols installed on
	/// the local computer. This function differs from its API counterpart (WSAEnumProtocols) in that WSAPROTOCOL_INFOW structures for
	/// all installed protocols are returned. This includes protocols that the service provider has set the <c>PFL_HIDDEN</c> flag in
	/// the <c>dwProviderFlags</c> member of the <c>WSAPROTOCOL_INFOW</c> structure to indicate to the Ws2_32.dll that this protocol
	/// should not be returned in the result buffer generated by <c>WSAEnumProtocols</c> function. In addition, the
	/// <c>WSCEnumProtocols</c> also returns data for <c>WSAPROTOCOL_INFOW</c> structures that have a chain length of zero ( a dummy LSP
	/// provider). The <c>WSAEnumProtocols</c> only returns information on base protocols and protocol chains that lack the
	/// <c>PFL_HIDDEN</c> flag and don't have a protocol chain length of zero.
	/// </para>
	/// <para>
	/// **Note** Layered Service Providers are deprecated. Starting with Windows 8 and Windows Server 2012, use Windows Filtering Platform.
	/// </para>
	/// <para>
	/// The lpiProtocols parameter can be used as a filter to constrain the amount of information provided. Typically, a null pointer is
	/// supplied so the function will return information on all available transport protocols.
	/// </para>
	/// <para>
	/// A WSAPROTOCOL_INFOW structure is provided in the buffer pointed to by lpProtocolBuffer for each requested protocol. If the
	/// supplied buffer is not large enough (as indicated by the input value of lpdwBufferLength), the value pointed to by
	/// lpdwBufferLength will be updated to indicate the required buffer size. The Windows Sockets SPI client should then obtain a large
	/// enough buffer and call this function again. The <c>WSCEnumProtocols</c> function cannot enumerate over multiple calls; the
	/// passed-in buffer must be large enough to hold all expected entries in order for the function to succeed. This reduces the
	/// complexity of the function and should not pose a problem because the number of protocols loaded on a local computer is typically small.
	/// </para>
	/// <para>
	/// The order in which the WSAPROTOCOL_INFOW structures appear in the buffer coincides with the order in which the protocol entries
	/// were registered by the service provider with the WS2_32.dll, or with any subsequent reordering that may have occurred through
	/// the Windows Sockets applet supplied for establishing default transport providers.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example demonstrates the use of the <c>WSCEnumProtocols</c> function to retrieve an array of WSAPROTOCOL_INFOW
	/// structures for protocols installed on the local computer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscenumprotocols int WSCEnumProtocols( LPINT lpiProtocols,
	// LPWSAPROTOCOL_INFOW lpProtocolBuffer, LPDWORD lpdwBufferLength, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("ws2spi.h", MSDNShortId = "c2e5332f-3327-4624-96b4-8e321795961d")]
	public static extern WSRESULT WSCEnumProtocols([In, Optional, MarshalAs(UnmanagedType.LPArray)] int[]? lpiProtocols, IntPtr lpProtocolBuffer, ref uint lpdwBufferLength, out int lpErrno);

	/// <summary>The <c>WSCEnumProtocols32</c> function retrieves information about available transport protocols.</summary>
	/// <param name="lpiProtocols">
	/// Null-terminated array of iProtocol values. This parameter is optional; if lpiProtocols is null, information on all available
	/// protocols is returned. Otherwise, information is retrieved only for those protocols listed in the array.
	/// </param>
	/// <param name="lpProtocolBuffer">Buffer that is filled with WSAPROTOCOL_INFOW structures.</param>
	/// <param name="lpdwBufferLength">
	/// On input, size of the lpProtocolBuffer buffer passed to WSCEnumProtocols, in bytes. On output, the minimum buffer size, in
	/// bytes, that can be passed to <c>WSCEnumProtocols</c> to retrieve all the requested information.
	/// </param>
	/// <param name="lpErrno">Pointer to the error code.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCEnumProtocols32</c> returns the number of protocols to be reported on. Otherwise, a value of
	/// SOCKET_ERROR is returned and a specific error code is available in lpErrno.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One of more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>Indicates that one of the specified parameters was invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOBUFS</term>
	/// <term>
	/// Buffer length was too small to receive all the relevant WSAProtocol_Info structures and associated information. Pass in a buffer
	/// at least as large as the value returned in lpdwBufferLength.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCEnumProtocols32</c> is a strictly 32-bit version of WSCEnumProtocols. On a 64-bit computer, all calls not specifically
	/// 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that execute on a
	/// 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve compatibility.
	/// The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// This function is used to discover information about the collection of transport protocols installed on the local computer. This
	/// function differs from its API counterpart (WSAEnumProtocols) in that WSAPROTOCOL_INFOW structures for all installed protocols
	/// are returned. This includes protocols that the service provider has set the <c>PFL_HIDDEN</c> flag in the <c>dwProviderFlags</c>
	/// member of the <c>WSAPROTOCOL_INFOW</c> structure to indicate to the Ws2_32.dll that this protocol should not be returned in the
	/// result buffer generated by <c>WSAEnumProtocols</c> function. In addition, the <c>WSCEnumProtocols32</c> also returns data for
	/// <c>WSAPROTOCOL_INFOW</c> structures that have a chain length of zero ( a dummy LSP provider). The <c>WSAEnumProtocols</c> only
	/// returns information on base protocols and protocol chains that lack the <c>PFL_HIDDEN</c> flag and don't have a protocol chain
	/// length of zero.
	/// </para>
	/// <para>
	/// **Note** Layered Service Providers are deprecated. Starting with Windows 8 and Windows Server 2012, use Windows Filtering Platform.
	/// </para>
	/// <para>
	/// The lpiProtocols parameter can be used as a filter to constrain the amount of information provided. Typically, a NULL pointer is
	/// supplied so the function will return information on all available transport protocols.
	/// </para>
	/// <para>
	/// A WSAPROTOCOL_INFOW structure is provided in the buffer pointed to by lpProtocolBuffer for each requested protocol. If the
	/// supplied buffer is not large enough (as indicated by the input value of lpdwBufferLength), the value pointed to by
	/// lpdwBufferLength will be updated to indicate the required buffer size. The Windows Sockets SPI client should then obtain a large
	/// enough buffer and call this function again. The <c>WSCEnumProtocols32</c> function cannot enumerate over multiple calls; the
	/// passed-in buffer must be large enough to hold all expected entries in order for the function to succeed. This reduces the
	/// complexity of the function and should not pose a problem because the number of protocols loaded on a computer is typically small.
	/// </para>
	/// <para>
	/// The order in which the WSAPROTOCOL_INFOW structures appear in the buffer coincides with the order in which the protocol entries
	/// were registered by the service provider with the WS2_32.dll, or with any subsequent reordering that may have occurred through
	/// the Windows Sockets applet supplied for establishing default transport providers.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example demonstrates the use of the <c>WSCEnumProtocols32</c> function for use on 64-bit platforms to retrieve an
	/// array of WSAPROTOCOL_INFOW structures for protocols installed on the local computer in the 32-bit catalog.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscenumprotocols32 int WSCEnumProtocols32( LPINT
	// lpiProtocols, LPWSAPROTOCOL_INFOW lpProtocolBuffer, LPDWORD lpdwBufferLength, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "f46042f6-0b14-4a14-abc1-4e40c34b1599")]
	public static extern WSRESULT WSCEnumProtocols32([In, Optional, MarshalAs(UnmanagedType.LPArray)] int[]? lpiProtocols, IntPtr lpProtocolBuffer, ref uint lpdwBufferLength, out int lpErrno);

	/// <summary>
	/// <para>
	/// A pointer to a Unicode string that contains the load path to the executable image for the application. This string observes the
	/// usual rules for path resolution and can contain embedded environment strings (such as %SystemRoot%).
	/// </para>
	/// <para>The length, in characters, of the Path parameter. This length does not include the terminating <c>NULL</c>.</para>
	/// <para>
	/// A pointer to a Unicode string which represents the command line arguments used when starting the application specified in the
	/// Path parameter. The Extra parameter is used to distinguish between multiple, distinct instances of an application when launched
	/// with a consistent command line. This is to support different application categorizations for different instances of Svchost.exe
	/// or Rundll32.exe. If only the Path parameter is required and no command line arguments are needed to further distinguish between
	/// instances of an application, then the Extra parameter should be set to <c>NULL</c>.
	/// </para>
	/// <para>The length, in characters, of the Extra parameter. This length does not include the terminating <c>NULL</c>.</para>
	/// <para>
	/// A pointer to a DWORD value of permitted LSP categories which are permitted for all instances of this application. The
	/// application is identified by the combination of the values of the Path and Extra parameters.
	/// </para>
	/// <para>A pointer to the error code if the function fails.</para>
	/// </summary>
	/// <param name="Path">
	/// A pointer to a Unicode string that contains the load path to the executable image for the application. This string observes the
	/// usual rules for path resolution and can contain embedded environment strings (such as %SystemRoot%).
	/// </param>
	/// <param name="PathLength">The length, in characters, of the Path parameter. This length does not include the terminating <c>NULL</c>.</param>
	/// <param name="Extra">
	/// A pointer to a Unicode string which represents the command line arguments used when starting the application specified in the
	/// Path parameter. The Extra parameter is used to distinguish between multiple, distinct instances of an application when launched
	/// with a consistent command line. This is to support different application categorizations for different instances of Svchost.exe
	/// or Rundll32.exe. If only the Path parameter is required and no command line arguments are needed to further distinguish between
	/// instances of an application, then the Extra parameter should be set to <c>NULL</c>.
	/// </param>
	/// <param name="ExtraLength">The length, in characters, of the Extra parameter. This length does not include the terminating <c>NULL</c>.</param>
	/// <param name="pPermittedLspCategories">
	/// A pointer to a DWORD value of permitted LSP categories which are permitted for all instances of this application. The
	/// application is identified by the combination of the values of the Path and Extra parameters.
	/// </param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCGetApplicationCategory</c> returns <c>ERROR_SUCCESS</c> (zero). Otherwise, it returns
	/// <c>SOCKET_ERROR</c>, and a specific error code is returned in the lpErrno parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSASERVICE_NOT_FOUND</term>
	/// <term>
	/// The service could not be found based on the Path and Extra parameters. The error can also be returned if the application you are
	/// querying does not exist in the registry. In this case, the error indicates that the application is not currently categorized.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
	/// administrative privileges required to access the Winsock registry, or a failure occurred when opening a Winsock catalog entry or
	/// an application ID entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCGetApplicationCategory</c> is used to retrieve the LSP category flags associated with an application instance.
	/// Applications can determine which LSP behaviors are acceptable within the application's context. Therefore, by specifying
	/// permitted LSP categories, an application can permit only those layered service providers which implement acceptable behaviors to
	/// be loaded.
	/// </para>
	/// <para>
	/// The Extra parameter is required when the command line is used to distinguish between different instances of an application or
	/// service hosted within the same executable. Each instance can have different application categorization needs. Svchost.exe and
	/// Rundll32.exe are two examples where the command line is required to differentiate between different process instances. For
	/// SvcHost.exe, the <c>-k &lt;svcinstance&gt;</c> switch defines the process instance.
	/// </para>
	/// <para>
	/// For services, using the Service Name is not sufficient, since the Winsock Catalog is global to a given process, and a process
	/// may host several services.
	/// </para>
	/// <para>
	/// Window sockets determine an application's identity and retrieves the permitted LSP categories during the first call to
	/// WSAStartup. This will be the set of permitted LSP categories for the duration of the application instance. Subsequent changes to
	/// the permitted LSP categories for a given application identity will not be picked up until the next instance of the application.
	/// The permitted LSP categories are not mutable during the lifetime of the application instance.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions,
	/// while relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered
	/// protocol or layered service provider would be a security layer that adds protocol to the connection establishment process in
	/// order to perform authentication and to establish a mutually agreed upon encryption scheme. Such a security protocol would
	/// generally require the services of an underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to
	/// a protocol such as TCP or SPX which is capable of performing data communications with a remote endpoint. The term layered
	/// protocol is used to describe a protocol that cannot stand alone.
	/// </para>
	/// <para>
	/// During LSP initialization, the LSP must provide pointers to a number of Winsock SPI functions. These functions will be called
	/// during normal processing by the layer directly above the LSP (either another LSP or Ws2_32.DLL).
	/// </para>
	/// <para>
	/// An LSP that implements an installable file system (IFS) can selectively choose to provide pointers to functions which are
	/// implemented by itself, or pass back the pointers provided by the layer directly below the LSP. Non-IFS LSPs, because they
	/// provide their own handles, must implement all of the Winsock SPI functions. This is because each SPI will require the LSP to map
	/// all of the socket handles it created to the socket handle of the lower provider (either another LSP or the base protocol).
	/// </para>
	/// <para>However, all LSPs perform their specific work by doing extra processing on only a subset of the Winsock SPI functions.</para>
	/// <para>
	/// It is possible to define LSP categories based upon the subset of SPI functions an LSP implements and the nature of the extra
	/// processing performed for each of those functions.
	/// </para>
	/// <para>
	/// By classifying LSPs, as well as classifying applications which use Winsock sockets, it becomes possible to selectively determine
	/// if an LSP should be involved in a given process at runtime.
	/// </para>
	/// <para>
	/// On Windows Vista and later, an LSP can be classified based on how it interacts with Windows Sockets calls and data. An LSP
	/// category is an identifiable group of behaviors on a subset of Winsock SPI functions. For example, an HTTP content filter would
	/// be categorized as a data inspector (the LSP_INSPECTOR category). The LSP_INSPECTOR category will inspect (but not alter)
	/// parameters to data transfer SPI functions. An application can query for the category of an LSP and choose to not load the LSP
	/// based on the LSP category and the application's set of permitted LSP categories.
	/// </para>
	/// <para>The following table lists categories that an LSP can be classified into.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>LSP Category</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>**LSP_CRYPTO_COMPRESS**</term>
	/// <term>The LSP is a cryptography or data compression provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_FIREWALL**</term>
	/// <term>The LSP is a firewall provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_LOCAL_CACHE**</term>
	/// <term>The LSP is a local cache provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INBOUND_MODIFY**</term>
	/// <term>The LSP modifies inbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INSPECTOR**</term>
	/// <term>The LSP inspects or filters data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_OUTBOUND_MODIFY**</term>
	/// <term>The LSP modifies outbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_PROXY**</term>
	/// <term>The LSP acts as a proxy and redirects packets.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_REDIRECTOR**</term>
	/// <term>The LSP is a network redirector.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_SYSTEM**</term>
	/// <term>The LSP is acceptable for use in services and system processes.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An LSP may belong to more than one category. For example, a firewall/security LSP could belong to both the inspector (
	/// <c>LSP_INSPECTOR</c>) and firewall ( <c>LSP_FIREWALL</c>) categories.
	/// </para>
	/// <para>
	/// If an LSP does not have a category set, it is considered to be in the All Other category. This LSP category will not be loaded
	/// in services or system processes (for example, lsass, winlogon, and many svchost processes).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscgetapplicationcategory int WSCGetApplicationCategory(
	// LPCWSTR Path, DWORD PathLength, LPCWSTR Extra, DWORD ExtraLength, DWORD *pPermittedLspCategories, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "c4e149ce-dff9-401a-8488-23676992c04d")]
	public static extern WSRESULT WSCGetApplicationCategory([MarshalAs(UnmanagedType.LPWStr)] string Path, uint PathLength, [MarshalAs(UnmanagedType.LPWStr)] string? Extra,
		uint ExtraLength, out uint pPermittedLspCategories, out int lpErrno);

	/// <summary>
	/// The **WSCGetProviderInfo** function retrieves the data associated with an information class for a layered service provider (LSP).
	/// </summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the provider.</param>
	/// <param name="InfoType">The information class that is requested for this LSP protocol entry.</param>
	/// <param name="Info">
	/// A pointer to a buffer to receive the information class data for the requested LSP protocol entry. If this parameter is <c>NULL</c>,
	/// then <c>WSCGetProviderInfo</c> returns failure and the size required for this buffer is returned in the <c>InfoSize</c> parameter.
	/// </param>
	/// <param name="InfoSize">
	/// The size, in bytes, of the buffer pointed to by the <c>Info</c> parameter. If the Info parameter is <c>NULL</c>, then
	/// <c>WSCGetProviderInfo</c> returns failure and the <c>InfoSize</c> parameter will receive the size of the required buffer.
	/// </param>
	/// <param name="Flags">The flags used to modify the behavior of the <c>WSCGetProviderInfo</c> function call.</param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCGetProviderInfo</c> returns <c>ERROR_SUCCESS</c> (zero). Otherwise, it returns <c>SOCKET_ERROR</c>, and a
	/// specific error code is returned in the <c>lpErrno</c> parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Error code</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_CALL_NOT_IMPLEMENTED</c></description>
	/// <description>
	/// The call is not implemented. This error is returned if **ProviderInfoAudit** is specified in the <c>InfoType</c> parameter.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAEFAULT</c></description>
	/// <description>One or more of the arguments is not in a valid part of the user address space.</description>
	/// </item>
	/// <item>
	/// <description><c>WSAEINVAL</c></description>
	/// <description>One or more of the arguments are invalid.</description>
	/// </item>
	/// <item>
	/// <description><c>WSAEINVALIDPROVIDER</c></description>
	/// <description>The protocol entry could not be found for the specified <c>lpProviderId</c>.</description>
	/// </item>
	/// <item>
	/// <description><c>WSANO_RECOVERY</c></description>
	/// <description>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
	/// administrative privileges required to access the Winsock registry, or a failure occurred when opening a Winsock catalog entry.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSA_NOT_ENOUGH_MEMORY</c></description>
	/// <description>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCGetProviderInfo</c> is used to retrieve information class data for a layered service provider. When the <c>InfoType</c>
	/// parameter is set to <c>ProviderInfoLspCategories</c>, on success <c>WSCGetProviderInfo</c> returns with the <c>Info</c> parameter set
	/// with appropriate LSP category flags implemented by the LSP.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions, while
	/// relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered protocol or
	/// layered service provider would be a security layer that adds protocol to the connection establishment process in order to perform
	/// authentication and to establish a mutually agreed upon encryption scheme. Such a security protocol would generally require the
	/// services of an underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to a protocol such as TCP or
	/// SPX which is capable of performing data communications with a remote endpoint. The term layered protocol is used to describe a
	/// protocol that cannot stand alone. A protocol chain would then be defined as one or more layered protocols strung together and
	/// anchored by a base protocol. A base protocol has the <c>ChainLen</c> member of the WSAProtocol_Info structure set to
	/// <c>BASE_PROTOCOL</c> which is defined to be 1. A layered protocol has the <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c>
	/// structure set to <c>LAYERED_PROTOCOL</c> which is defined to be zero. A protocol chain has the <c>ChainLen</c> member of the
	/// <c>WSAPROTOCOL_INFO</c> structure set to greater than 1.
	/// </para>
	/// <para>
	/// During LSP initialization, the LSP must provide pointers to a number of Winsock SPI functions. These functions will be called during
	/// normal processing by the layer directly above the LSP (either another LSP or Ws2_32.DLL).
	/// </para>
	/// <para>
	/// An LSP that implements an installable file system (IFS) can selectively choose to provide pointers to functions which are implemented
	/// by itself, or pass back the pointers provided by the layer directly below the LSP. Non-IFS LSPs, because they provide their own
	/// handles, must implement all of the Winsock SPI functions. This is because each SPI will require the LSP to map all of the socket
	/// handles it created to the socket handle of the lower provider (either another LSP or the base protocol).
	/// </para>
	/// <para>However, all LSPs perform their specific work by doing extra processing on only a subset of the Winsock SPI functions.</para>
	/// <para>
	/// It is possible to define LSP categories based upon the subset of SPI functions an LSP implements and the nature of the extra
	/// processing performed for each of those functions.
	/// </para>
	/// <para>
	/// By classifying LSPs, as well as classifying applications which use Winsock sockets, it becomes possible to selectively determine if
	/// an LSP should be involved in a given process at runtime.
	/// </para>
	/// <para>
	/// On WindowsÂ Vista and later, an LSP can be classified based on how it interacts with Windows Sockets calls and data. An LSP category
	/// is an identifiable group of behaviors on a subset of Winsock SPI functions. For example, an HTTP content filter would be categorized
	/// as a data inspector (the LSP_INSPECTOR category). The LSP_INSPECTOR category will inspect (but not alter) parameters to data transfer
	/// SPI functions. An application can query for the category of an LSP and choose to not load the LSP based on the LSP category and the
	/// application's set of permitted LSP categories.
	/// </para>
	/// <para>The following table lists categories into which an LSP can be classified.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>LSP Category</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>**LSP_CRYPTO_COMPRESS**</description>
	/// <description>The LSP is a cryptography or data compression provider.</description>
	/// </item>
	/// <item>
	/// <description>**LSP_FIREWALL**</description>
	/// <description>The LSP is a firewall provider.</description>
	/// </item>
	/// <item>
	/// <description>**LSP_LOCAL_CACHE**</description>
	/// <description>The LSP is a local cache provider.</description>
	/// </item>
	/// <item>
	/// <description>**LSP_INBOUND_MODIFY**</description>
	/// <description>The LSP modifies inbound data.</description>
	/// </item>
	/// <item>
	/// <description>**LSP_INSPECTOR**</description>
	/// <description>The LSP inspects or filters data.</description>
	/// </item>
	/// <item>
	/// <description>**LSP_OUTBOUND_MODIFY**</description>
	/// <description>The LSP modifies outbound data.</description>
	/// </item>
	/// <item>
	/// <description>**LSP_PROXY**</description>
	/// <description>The LSP acts as a proxy and redirects packets.</description>
	/// </item>
	/// <item>
	/// <description>**LSP_REDIRECTOR**</description>
	/// <description>The LSP is a network redirector.</description>
	/// </item>
	/// <item>
	/// <description>**LSP_SYSTEM**</description>
	/// <description>The LSP is acceptable for use in services and system processes.</description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>
	/// An LSP may belong to more than one category. For example, a firewall/security LSP could belong to both the inspector (
	/// <c>LSP_INSPECTOR</c>) and firewall ( <c>LSP_FIREWALL</c>) categories.
	/// </para>
	/// <para>
	/// If an LSP does not have a category set, it is considered to be in the All Other category. This LSP category will not be loaded in
	/// services or system processes (for example, lsass, winlogon, and many svchost processes).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscgetproviderinfo
	// int WSCGetProviderInfo( [in] LPGUID lpProviderId, [in] WSC_PROVIDER_INFO_TYPE InfoType, [out] PBYTE Info, [in, out] size_t *InfoSize, [in] DWORD Flags, [out] LPINT lpErrno );
	[PInvokeData("ws2spi.h", MSDNShortId = "NF:ws2spi.WSCGetProviderInfo")]
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	public static extern WSRESULT WSCGetProviderInfo(in Guid lpProviderId, WSC_PROVIDER_INFO_TYPE InfoType, [Out] IntPtr Info, ref SIZE_T InfoSize, uint Flags, out int lpErrno);

	/// <summary>The **WSCGetProviderInfo32** function retrieves the data associated with an information class for a 32-bit layered service provider (LSP).</summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the provider.</param>
	/// <param name="InfoType">The information class that is requested for this LSP protocol entry.</param>
	/// <param name="Info">
	/// A pointer to a buffer to receive the information class data for the requested LSP protocol entry. If this parameter is
	/// <c>NULL</c>, then <c>WSCGetProviderInfo32</c> returns failure and the size required for this buffer is returned in the InfoSize parameter.
	/// </param>
	/// <param name="InfoSize">
	/// The size, in bytes, of the buffer pointed to by the Info parameter. If the Info parameter is <c>NULL</c>, then
	/// <c>WSCGetProviderInfo32</c> returns failure and the InfoSize parameter will receive the size of the required buffer.
	/// </param>
	/// <param name="Flags">The flags used to modify the behavior of the <c>WSCGetProviderInfo32</c> function call.</param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCGetProviderInfo32</c> returns <c>ERROR_SUCCESS</c> (zero). Otherwise, it returns <c>SOCKET_ERROR</c>,
	/// and a specific error code is returned in the lpErrno parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>The call is not implemented. This error is returned if **ProviderInfoAudit** is specified in the InfoType parameter.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVALIDPROVIDER</term>
	/// <term>The protocol entry could not be found for the specified lpProviderId.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
	/// administrative privileges required to access the Winsock registry, or a failure occurred when opening a Winsock catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCGetProviderInfo32</c> is a strictly 32-bit version of WSCGetProviderInfo. On a 64-bit computer, all calls not specifically
	/// 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that execute on a
	/// 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve compatibility.
	/// The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// <c>WSCGetProviderInfo32</c> is used to retrieve information class data for a protocol entry on a 32-bit layered service
	/// provider. When the InfoType parameter is set to <c>ProviderInfoLspCategories</c>, on success <c>WSCGetProviderInfo32</c> returns
	/// with the Info parameter set with appropriate LSP category flags implemented by 32-bit LSP.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions,
	/// while relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered
	/// protocol or layered service provider would be a security layer that adds protocol to the connection establishment process in
	/// order to perform authentication and to establish a mutually agreed upon encryption scheme. Such a security protocol would
	/// generally require the services of an underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to
	/// a protocol such as TCP or SPX which is capable of performing data communications with a remote endpoint. The term layered
	/// protocol is used to describe a protocol that cannot stand alone. A protocol chain would then be defined as one or more layered
	/// protocols strung together and anchored by a base protocol. A base protocol has the <c>ChainLen</c> member of the
	/// WSAProtocol_Info structure set to <c>BASE_PROTOCOL</c> which is defined to be 1. A layered protocol has the <c>ChainLen</c>
	/// member of the <c>WSAPROTOCOL_INFO</c> structure set to <c>LAYERED_PROTOCOL</c> which is defined to be zero. A protocol chain has
	/// the <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c> structure set to greater than 1.
	/// </para>
	/// <para>
	/// During LSP initialization, the LSP must provide pointers to a number of Winsock SPI functions. These functions will be called
	/// during normal processing by the layer directly above the LSP (either another LSP or Ws2_32.DLL).
	/// </para>
	/// <para>
	/// An LSP that implements an installable file system (IFS) can selectively choose to provide pointers to functions which are
	/// implemented by itself, or pass back the pointers provided by the layer directly below the LSP. Non-IFS LSPs, because they
	/// provide their own handles, must implement all of the Winsock SPI functions. This is because each SPI will require the LSP to map
	/// all of the socket handles it created to the socket handle of the lower provider (either another LSP or the base protocol).
	/// </para>
	/// <para>However, all LSPs perform their specific work by doing extra processing on only a subset of the Winsock SPI functions.</para>
	/// <para>
	/// It is possible to define LSP categories based upon the subset of SPI functions an LSP implements and the nature of the extra
	/// processing performed for each of those functions.
	/// </para>
	/// <para>
	/// By classifying LSPs, as well as classifying applications which use Winsock sockets, it becomes possible to selectively determine
	/// if an LSP should be involved in a given process at runtime.
	/// </para>
	/// <para>
	/// On Windows Vista and later, an LSP can be classified based on how it interacts with Windows Sockets calls and data. An LSP
	/// category is an identifiable group of behaviors on a subset of Winsock SPI functions. For example, an HTTP content filter would
	/// be categorized as a data inspector (the <c>LSP_INSPECTOR</c> category). The <c>LSP_INSPECTOR</c> category will inspect, but not
	/// alter, parameters to data transfer SPI functions. An application can query for the category of an LSP and choose to not load the
	/// LSP based on the LSP category and the application's set of permitted LSP categories.
	/// </para>
	/// <para>The following table lists categories into which an LSP can be classified.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>LSP Category</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>**LSP_CRYPTO_COMPRESS**</term>
	/// <term>The LSP is a cryptography or data compression provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_FIREWALL**</term>
	/// <term>The LSP is a firewall provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_LOCAL_CACHE**</term>
	/// <term>The LSP is a local cache provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INBOUND_MODIFY**</term>
	/// <term>The LSP modifies inbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INSPECTOR**</term>
	/// <term>The LSP inspects or filters data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_OUTBOUND_MODIFY**</term>
	/// <term>The LSP modifies outbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_PROXY**</term>
	/// <term>The LSP acts as a proxy and redirects packets.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_REDIRECTOR**</term>
	/// <term>The LSP is a network redirector.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_SYSTEM**</term>
	/// <term>The LSP is acceptable for use in services and system processes.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An LSP may belong to more than one category. For example, a firewall/security LSP could belong to both the inspector (
	/// <c>LSP_INSPECTOR</c>) and firewall ( <c>LSP_FIREWALL</c>) categories.
	/// </para>
	/// <para>
	/// If an LSP does not have a category set, it is considered to be in the All Other category. This LSP category will not be loaded
	/// in services or system processes (for example, lsass, winlogon, and many svchost processes).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscgetproviderinfo32 int WSCGetProviderInfo32( LPGUID
	// lpProviderId, WSC_PROVIDER_INFO_TYPE InfoType, PBYTE Info, size_t *InfoSize, DWORD Flags, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "91686b38-3cde-4979-8bf6-45e805dd37ff")]
	public static extern WSRESULT WSCGetProviderInfo32(in Guid lpProviderId, WSC_PROVIDER_INFO_TYPE InfoType, [Out] IntPtr Info, ref SIZE_T InfoSize, uint Flags, out int lpErrno);

	/// <summary>The <c>WSCGetProviderPath</c> function retrieves the DLL path for the specified provider.</summary>
	/// <param name="lpProviderId">
	/// A pointer to a globally unique identifier (GUID) for the provider. This value is obtained by using WSCEnumProtocols.
	/// </param>
	/// <param name="lpszProviderDllPath">
	/// A pointer to a buffer into which the provider DLL's path string is returned. The path is a null-terminated string and any
	/// embedded environment strings, such as %SystemRoot%, have not been expanded.
	/// </param>
	/// <param name="lpProviderDllPathLen">The size, in characters, of the buffer pointed to by the lpszProviderDllPath parameter.</param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCGetProviderPath</c> returns zero. Otherwise, it returns SOCKET_ERROR. The specific error code is
	/// available in lpErrno.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The lpProviderId parameter does not specify a valid provider.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The lpszProviderDllPath or lpErrno parameter is not in a valid part of the user address space, or lpProviderDllPathLen is too small.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The <c>WSCGetProviderPath</c> function retrieves the DLL path for the specified provider. The DLL path can contain embedded
	/// environment strings, such as %SystemRoot%, and thus should be expanded prior to being used with the Windows LoadLibrary
	/// function. For more information, see <c>LoadLibrary</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscgetproviderpath int WSCGetProviderPath( LPGUID
	// lpProviderId, WCHAR *lpszProviderDllPath, LPINT lpProviderDllPathLen, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "fe60c8c4-e2d0-48cc-9fdf-e58e408fb1b3")]
	public static extern WSRESULT WSCGetProviderPath(in Guid lpProviderId, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszProviderDllPath, ref int lpProviderDllPathLen, out int lpErrno);

	/// <summary>The <c>WSCGetProviderPath32</c> function retrieves the DLL path for the specified 32-bit provider.</summary>
	/// <param name="lpProviderId">Locally unique identifier of the provider. This value is obtained by using WSCEnumProtocols32.</param>
	/// <param name="lpszProviderDllPath">
	/// Pointer to a buffer into which the provider DLL's path string is returned. The path is a null-terminated string and any embedded
	/// environment strings, such as %SystemRoot%, have not been expanded.
	/// </param>
	/// <param name="lpProviderDllPathLen">Size of the buffer pointed to by the lpszProviderDllPath parameter, in characters.</param>
	/// <param name="lpErrno">Pointer to the error code.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCGetProviderPath32</c> returns zero. Otherwise, it returns SOCKET_ERROR. The specific error code is
	/// available in lpErrno.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The lpProviderId parameter does not specify a valid provider.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The lpszProviderDllPath or lpErrno parameter is not in a valid part of the user address space, or lpProviderDllPathLen is too small.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCGetProviderPath32</c> is a strictly 32-bit version of WSCGetProviderPath. On a 64-bit computer, all calls not specifically
	/// 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that execute on a
	/// 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve compatibility.
	/// The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// The <c>WSCGetProviderPath32</c> function retrieves the DLL path for the specified provider. The DLL path can contain embedded
	/// environment strings, such as %SystemRoot%, and thus should be expanded prior to being used with the Windows LoadLibrary
	/// function. For more information, see <c>LoadLibrary</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscgetproviderpath32 int WSCGetProviderPath32( LPGUID
	// lpProviderId, WCHAR *lpszProviderDllPath, LPINT lpProviderDllPathLen, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "fd4ef7da-344d-4825-93b2-f0cd5622aeac")]
	public static extern WSRESULT WSCGetProviderPath32(in Guid lpProviderId, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszProviderDllPath, ref int lpProviderDllPathLen, out int lpErrno);

	/// <summary>
	/// The <c>WSCInstallNameSpace</c> function installs a namespace provider. For providers that are able to support multiple
	/// namespaces, this function must be called for each namespace supported, and a unique provider identifier must be supplied each time.
	/// </summary>
	/// <param name="lpszIdentifier">
	/// A pointer to a string that identifies the provider associated with the globally unique identifier (GUID) passed in the
	/// lpProviderId parameter.
	/// </param>
	/// <param name="lpszPathName">
	/// A pointer to a Unicode string that contains the load path to the provider DLL. This string observes the usual rules for path
	/// resolution and can contain embedded environment strings (such as %SystemRoot%). Such environment strings are expanded when the
	/// Ws2_32.dll must subsequently load the provider DLL on behalf of an application. After any embedded environment strings are
	/// expanded, the Ws2_32.dll passes the resulting string to the LoadLibrary function which loads the provider into memory. For more
	/// information, see <c>LoadLibrary</c>.
	/// </param>
	/// <param name="dwNameSpace">The namespace supported by this provider.</param>
	/// <param name="dwVersion">The version number of the provider.</param>
	/// <param name="lpProviderId">A pointer to a GUID for the provider. This GUID should be generated by Uuidgen.exe.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>WSCInstallNameSpace</c> function returns <c>NO_ERROR</c> (zero). Otherwise, it returns
	/// <c>SOCKET_ERROR</c> if the function fails, and you must retrieve the appropriate error code using the WSAGetLastError function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEACCES</term>
	/// <term>The calling routine does not have sufficient privileges to install a namespace.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the provider is
	/// already installed, the user lacks the administrative privileges required to write to the Winsock registry, or a failure occurred
	/// when creating or installing a catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The namespace–configuration functions do not affect applications that are already running. Newly installed namespace providers
	/// will not be visible to applications nor will the changes in a namespace provider's activation state. Applications launched after
	/// the call to <c>WSCInstallNameSpace</c> will see the changes.
	/// </para>
	/// <para>
	/// The <c>WSCInstallNameSpace</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCInstallNameSpace</c> is called by a user that is not a member of the Administrators group, the function call will fail.
	/// For computers running on Windows Vista or Windows Server 2008, this function can also fail because of user account control
	/// (UAC). If an application that contains this function is executed by a user logged on as a member of the Administrators group
	/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscinstallnamespace INT WSCInstallNameSpace( PWSTR
	// lpszIdentifier, PWSTR lpszPathName, DWORD dwNameSpace, DWORD dwVersion, LPGUID lpProviderId );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "f17f6174-879e-45e7-a250-975d1ee24fe0")]
	public static extern WSRESULT WSCInstallNameSpace([MarshalAs(UnmanagedType.LPWStr)] string lpszIdentifier, [MarshalAs(UnmanagedType.LPWStr)] string lpszPathName, uint dwNameSpace, uint dwVersion, in Guid lpProviderId);

	/// <summary>
	/// The <c>WSCInstallNameSpace32</c> function installs a specified 32-bit namespace provider. For providers that are able to support
	/// multiple namespaces, this function must be called for each namespace supported, and a unique provider identifier must be
	/// supplied each time.
	/// </summary>
	/// <param name="lpszIdentifier">
	/// A pointer to a string that identifies the provider associated with the globally unique identifier (GUID) passed in the
	/// lpProviderId parameter.
	/// </param>
	/// <param name="lpszPathName">
	/// A pointer to a string that contains the path to the provider's DLL image. The string observes the usual rules for path
	/// resolution: this path can contain embedded environment strings (such as %SystemRoot%). Such environment strings are expanded
	/// whenever the WS2_32.DLL must subsequently load the provider DLL on behalf of an application. After any embedded environment
	/// strings are expanded, the Ws2_32.dll passes the resulting string into the LoadLibrary function to load the provider into memory.
	/// For more information, see <c>LoadLibrary</c>.
	/// </param>
	/// <param name="dwNameSpace">A descriptor that specifies the namespace supported by this provider.</param>
	/// <param name="dwVersion">A descriptor that specifies the version number of the provider.</param>
	/// <param name="lpProviderId">A unique identifier for this provider. This GUID should be generated by Uuidgen.exe.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>WSCInstallNameSpace32</c> function returns NO_ERROR (zero). Otherwise, it returns SOCKET_ERROR if the
	/// function fails, and you must retrieve the appropriate error code using the WSAGetLastError function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEACCES</term>
	/// <term>The calling routine does not have sufficient privileges to install a namespace.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the provider is
	/// already installed, the user lacks the administrative privileges required to write to the Winsock registry, or a failure occurred
	/// when creating or installing a catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCInstallNameSpace32</c> is a strictly 32-bit version of WSCInstallNameSpace. On a 64-bit computer, all calls not
	/// specifically 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that
	/// execute on a 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve
	/// compatibility. The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// The namespace configuration functions do not affect applications that are already running. Newly installed namespace providers
	/// will not be visible to applications nor will the changes in a namespace provider's activation state. Applications launched after
	/// the call to <c>WSCInstallNameSpace32</c> will recognize the changes.
	/// </para>
	/// <para>
	/// The <c>WSCInstallNameSpace32</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCInstallNameSpace32</c> is called by a user that is not a member of the Administrators group, the function call will fail.
	/// For computers running Windows Vista or Windows Server 2008, this function can also fail because of user account control (UAC).
	/// If an application that contains this function is executed by a user logged on as a member of the Administrators group other than
	/// the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator ( <c>RunAs administrator</c>) for this
	/// function to succeed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscinstallnamespace32 INT WSCInstallNameSpace32( PWSTR
	// lpszIdentifier, PWSTR lpszPathName, DWORD dwNameSpace, DWORD dwVersion, LPGUID lpProviderId );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "b107fbe6-bbfb-45be-8419-4d85d3c4e80c")]
	public static extern WSRESULT WSCInstallNameSpace32([MarshalAs(UnmanagedType.LPWStr)] string lpszIdentifier, [MarshalAs(UnmanagedType.LPWStr)] string lpszPathName, uint dwNameSpace, uint dwVersion, in Guid lpProviderId);

	/// <summary>
	/// The <c>WSCInstallNameSpaceEx</c> function installs a namespace provider. For providers that are able to support multiple
	/// namespaces, this function must be called for each namespace supported, and a unique provider identifier must be supplied each time.
	/// </summary>
	/// <param name="lpszIdentifier">
	/// A pointer to a string that identifies the provider associated with the globally unique identifier (GUID) passed in the
	/// lpProviderId parameter.
	/// </param>
	/// <param name="lpszPathName">
	/// A pointer to a Unicode string that contains the load path to the provider DLL. This string observes the usual rules for path
	/// resolution and can contain embedded environment strings (such as %SystemRoot%). Such environment strings are expanded when the
	/// Ws2_32.dll must subsequently load the provider DLL on behalf of an application. After any embedded environment strings are
	/// expanded, the Ws2_32.dll passes the resulting string to the LoadLibrary function which loads the provider into memory. For more
	/// information, see <c>LoadLibrary</c>.
	/// </param>
	/// <param name="dwNameSpace">The namespace supported by this provider.</param>
	/// <param name="dwVersion">The version number of the provider.</param>
	/// <param name="lpProviderId">A pointer to a GUID for the provider. This GUID should be generated by Uuidgen.exe.</param>
	/// <param name="lpProviderSpecific">A provider-specific data blob associated with namespace entry.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>WSCInstallNameSpaceEx</c> function returns <c>NO_ERROR</c> (zero). Otherwise, it returns
	/// <c>SOCKET_ERROR</c> if the function fails, and you must retrieve the appropriate error code using the WSAGetLastError function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEACCES</term>
	/// <term>The calling routine does not have sufficient privileges to install a namespace.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the provider is
	/// already installed, the user lacks the administrative privileges required to write to the Winsock registry, or a failure occurred
	/// when creating or installing a catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The namespace–configuration functions do not affect applications that are already running. Newly installed name-space providers
	/// will not be visible to applications nor will the changes in a name-space provider's activation state. Applications launched
	/// after the call to <c>WSCInstallNameSpaceEx</c> will see the changes.
	/// </para>
	/// <para>
	/// The provider-specific data blob associated with namespace entry passed in the lpProviderInfo parameter can be queried using the
	/// WSAEnumNameSpaceProvidersEx function.
	/// </para>
	/// <para>
	/// Currently, the only namespace provider included with Windows that uses the lpProviderInfo parameter is the NS_EMAIL provider.
	/// The format of the buffer pointed to by the lpProviderInfo parameter for an NS_EMAIL namespace provider is a
	/// NAPI_PROVIDER_INSTALLATION_BLOB structure.
	/// </para>
	/// <para>
	/// The <c>WSCInstallNameSpaceEx</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCInstallNameSpaceEx</c> is called by a user that is not a member of the Administrators group, the function call will fail.
	/// For computers running on Windows Vista or Windows Server 2008, this function can also fail because of user account control
	/// (UAC). If an application that contains this function is executed by a user logged on as a member of the Administrators group
	/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscinstallnamespaceex INT WSCInstallNameSpaceEx( PWSTR
	// lpszIdentifier, PWSTR lpszPathName, DWORD dwNameSpace, DWORD dwVersion, LPGUID lpProviderId, LPBLOB lpProviderSpecific );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "13dde602-c958-4312-a16f-a393dd6fb829")]
	public static extern WSRESULT WSCInstallNameSpaceEx([MarshalAs(UnmanagedType.LPWStr)] string lpszIdentifier, [MarshalAs(UnmanagedType.LPWStr)] string lpszPathName, uint dwNameSpace, uint dwVersion, in Guid lpProviderId, in BLOB lpProviderSpecific);

	/// <summary>
	/// <para>
	/// The <c>WSCInstallNameSpaceEx32</c> function installs a specified 32-bit namespace provider. For providers that are able to
	/// support multiple names spaces, this function must be called for each namespace supported, and a unique provider identifier must
	/// be supplied each time.
	/// </para>
	/// <para>
	/// **Note** This call is a strictly 32-bit version of WSCInstallNameSpaceEx32 for use on 64-bit platforms. It is provided to allow
	/// 64-bit processes to access the 32-bit catalogs.
	/// </para>
	/// </summary>
	/// <param name="lpszIdentifier">
	/// A pointer to a string that identifies the provider associated with the globally unique identifier (GUID) passed in the
	/// lpProviderId parameter.
	/// </param>
	/// <param name="lpszPathName">
	/// A pointer to a Unicode string that contains the load path to the provider DLL. This string observes the usual rules for path
	/// resolution and can contain embedded environment strings (such as %SystemRoot%). Such environment strings are expanded when the
	/// Ws2_32.dll must subsequently load the provider DLL on behalf of an application. After any embedded environment strings are
	/// expanded, the Ws2_32.dll passes the resulting string to the LoadLibrary function which loads the provider into memory. For more
	/// information, see <c>LoadLibrary</c>.
	/// </param>
	/// <param name="dwNameSpace">The namespace supported by this provider.</param>
	/// <param name="dwVersion">The version number of the provider.</param>
	/// <param name="lpProviderId">A pointer to a GUID for the provider. This GUID should be generated by Uuidgen.exe.</param>
	/// <param name="lpProviderSpecific">A provider-specific data blob associated with namespace entry.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>WSCInstallNameSpaceEx32</c> function returns <c>NO_ERROR</c> (zero). Otherwise, it returns
	/// <c>SOCKET_ERROR</c> if the function fails, and you must retrieve the appropriate error code using the WSAGetLastError function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEACCES</term>
	/// <term>The calling routine does not have sufficient privileges to install a namespace.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the provider is
	/// already installed, the user lacks the administrative privileges required to write to the Winsock registry, or a failure occurred
	/// when creating or installing a catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCInstallNameSpaceEx32</c> is a strictly 32-bit version of WSCInstallNameSpaceEx. On a 64-bit computer, all calls not
	/// specifically 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that
	/// execute on a 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve
	/// compatibility. The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// The namespace–configuration functions do not affect applications that are already running. Newly installed name-space providers
	/// will not be visible to applications nor will the changes in a name-space provider's activation state. Applications launched
	/// after the call to <c>WSCInstallNameSpaceEx32</c> will see the changes.
	/// </para>
	/// <para>
	/// The provider-specific data blob associated with namespace entry passed in the lpProviderInfo parameter can be queried using
	/// WSCEnumNameSpaceProvidersEx32 function.
	/// </para>
	/// <para>
	/// Currently, the only namespace provider included with Windows that uses the lpProviderInfo parameter is the NS_EMAIL provider.
	/// The format of the buffer pointed to by the lpProviderInfo parameter for an NS_EMAIL namespace provider is a
	/// NAPI_PROVIDER_INSTALLATION_BLOB structure.
	/// </para>
	/// <para>
	/// The <c>WSCInstallNameSpaceEx32</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCInstallNameSpaceEx32</c> is called by a user that is not a member of the Administrators group, the function call will
	/// fail. For computers running on Windows Vista or Windows Server 2008, this function can also fail because of user account control
	/// (UAC). If an application that contains this function is executed by a user logged on as a member of the Administrators group
	/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscinstallnamespaceex32 INT WSCInstallNameSpaceEx32( PWSTR
	// lpszIdentifier, PWSTR lpszPathName, DWORD dwNameSpace, DWORD dwVersion, LPGUID lpProviderId, LPBLOB lpProviderSpecific );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "222ebfcc-8854-4224-b464-28098c84b750")]
	public static extern WSRESULT WSCInstallNameSpaceEx32([MarshalAs(UnmanagedType.LPWStr)] string lpszIdentifier, [MarshalAs(UnmanagedType.LPWStr)] string lpszPathName, uint dwNameSpace, uint dwVersion, in Guid lpProviderId, in BLOB lpProviderSpecific);

	/// <summary>
	/// <para>A pointer to a globally unique identifier (GUID) for the provider.</para>
	/// <para>
	/// A pointer to a Unicode string that contains the load path to the provider DLL. This string observes the usual rules for path
	/// resolution and can contain embedded environment strings (such as %SystemRoot%). Such environment strings are expanded when the
	/// Ws2_32.dll must subsequently load the provider DLL on behalf of an application. After any embedded environment strings are
	/// expanded, the Ws2_32.dll passes the resulting string to the LoadLibrary function which loads the provider into memory. For more
	/// information, see <c>LoadLibrary</c>.
	/// </para>
	/// <para>
	/// A pointer to an array of WSAProtocol_Info structures. Each structure defines a protocol, address family, and socket type
	/// supported by the provider.
	/// </para>
	/// <para>The number of entries in the lpProtocolInfoList array.</para>
	/// <para>A pointer to the error code if the function fails.</para>
	/// </summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the provider.</param>
	/// <param name="lpszProviderDllPath">
	/// A pointer to a Unicode string that contains the load path to the provider DLL. This string observes the usual rules for path
	/// resolution and can contain embedded environment strings (such as %SystemRoot%). Such environment strings are expanded when the
	/// Ws2_32.dll must subsequently load the provider DLL on behalf of an application. After any embedded environment strings are
	/// expanded, the Ws2_32.dll passes the resulting string to the LoadLibrary function which loads the provider into memory. For more
	/// information, see <c>LoadLibrary</c>.
	/// </param>
	/// <param name="lpProtocolInfoList">
	/// A pointer to an array of WSAProtocol_Info structures. Each structure defines a protocol, address family, and socket type
	/// supported by the provider.
	/// </param>
	/// <param name="dwNumberOfEntries">The number of entries in the lpProtocolInfoList array.</param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If <c>WSCInstallProvider</c> succeeds, it returns zero. Otherwise, it returns <c>SOCKET_ERROR</c>, and a specific error code is
	/// returned in the lpErrno parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOBUFS</term>
	/// <term>Memory cannot be allocated for buffers.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the provider is
	/// already installed, the user lacks the administrative privileges required to write to the Winsock registry, or a failure occurred
	/// when creating or installing a catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCInstallProvider</c> is used to install a single transport service provider. This routine creates the necessary common
	/// Windows Sockets 2 configuration information for the specified provider. It is applicable to base protocols, layered protocols,
	/// and protocol chains. If a layered service provider is being installed, then WSCInstallProviderAndChains should be used.
	/// <c>WSCInstallProviderAndChains</c> can install a layered protocol and one or more protocol chains with a single function call.
	/// To accomplish the same work using <c>WSCInstallProvider</c> would require multiple function calls.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions
	/// while relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered
	/// protocol would be a security layer that adds a protocol to the connection establishment process in order to perform
	/// authentication and to establish a mutually agreed upon encryption scheme. Such a security protocol would generally require the
	/// services of an underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to a protocol such as
	/// TCP or SPX which is capable of performing data communications with a remote endpoint. The term layered protocol is used to
	/// describe a protocol that cannot stand alone. A protocol chain would then be defined as one or more layered protocols strung
	/// together and anchored by a base protocol. A base protocol has the <c>ChainLen</c> member of the WSAProtocol_Info structure set
	/// to <c>BASE_PROTOCOL</c> which is defined to be 1. A layered protocol has the <c>ChainLen</c> member of the
	/// <c>WSAPROTOCOL_INFO</c> structure set to <c>LAYERED_PROTOCOL</c> which is defined to be zero. A protocol chain has the
	/// <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c> structure set to greater than 1.
	/// </para>
	/// <para>
	/// The lpProtocolInfoList parameter contains a list of protocol entries to install. Callers of <c>WSCInstallProvider</c> are
	/// responsible for setting up the proper protocol entries. The lpProtocolInfoList parameter must not be <c>NULL</c>.
	/// </para>
	/// <para>
	/// Upon successful completion of this call, any subsequent calls to WSAEnumProtocols or WSCEnumProtocols will return the
	/// newly-created protocol entries. Be aware that in Windows environments, only instances of Ws_32.dll created by calling WSAStartup
	/// after the successful completion of <c>WSCInstallProvider</c> will include the new entries when <c>WSAEnumProtocols</c> and
	/// <c>WSCEnumProtocols</c> returns.
	/// </para>
	/// <para>
	/// On success, <c>WSCInstallProvider</c> will attempt to alert all interested applications that have registered for notification of
	/// the change by calling WSAProviderConfigChange.
	/// </para>
	/// <para>
	/// The <c>WSCInstallProvider</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCInstallProvider</c> is called by a user that is not a member of the Administrators group, the function call will fail and
	/// WSANO_RECOVERY is returned in the lpErrno parameter. For computers running Windows Vista or Windows Server 2008, this function
	/// can also fail because of user account control (UAC). If an application that contains this function is executed by a user logged
	/// on as a member of the Administrators group other than the built-in Administrator, this call will fail unless the application has
	/// been marked in the manifest file with a <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on
	/// Windows Vista or Windows Server 2008 lacks this manifest file, a user logged on as a member of the Administrators group other
	/// than the built-in Administrator must then be executing the application in an enhanced shell as the built-in Administrator (
	/// <c>RunAs administrator</c>) for this function to succeed.
	/// </para>
	/// <para>Any file installation or service provider-specific configuration must be performed by the caller.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscinstallprovider int WSCInstallProvider( LPGUID
	// lpProviderId, const WCHAR *lpszProviderDllPath, const LPWSAPROTOCOL_INFOW lpProtocolInfoList, DWORD dwNumberOfEntries, LPINT
	// lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "c0736018-2bcf-4281-aa73-3e1ff9eac92e")]
	public static extern WSRESULT WSCInstallProvider(in Guid lpProviderId, [MarshalAs(UnmanagedType.LPWStr)] string lpszProviderDllPath,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] WSAPROTOCOL_INFOW[] lpProtocolInfoList, uint dwNumberOfEntries, out int lpErrno);

	/// <summary>
	/// <para>[**WSCInstallProvider64_32** is no longer available for use as of Windows Vista. Instead, use WSCInstallProvider or WSCInstallProviderAndChains.]</para>
	/// <para>
	/// The <c>WSCInstallProvider64_32</c> function installs the specified transport service provider into the 32-bit and 64-bit system
	/// configuration databases on a 64-bit computer.
	/// </para>
	/// </summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the provider.</param>
	/// <param name="lpszProviderDllPath">
	/// A pointer to a Unicode string that contains the load path to the provider 64-bit DLL. This string observes the usual rules for
	/// path resolution and can contain embedded environment strings (such as %SystemRoot%). Such environment strings are expanded when
	/// the Ws2_32.dll must subsequently load the provider DLL on behalf of an application. After any embedded environment strings are
	/// expanded, the Ws2_32.dll passes the resulting string to the LoadLibrary function which loads the provider into memory. For more
	/// information, see <c>LoadLibrary</c>.
	/// </param>
	/// <param name="lpProtocolInfoList">
	/// A pointer to an array of WSAProtocol_Info structures. Each structure defines a protocol, address family, and socket type
	/// supported by the provider.
	/// </param>
	/// <param name="dwNumberOfEntries">The number of entries in the lpProtocolInfoList array.</param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If <c>WSCInstallProvider64_32</c> succeeds, it returns zero. Otherwise, it returns <c>SOCKET_ERROR</c>, and a specific error
	/// code is returned in the lpErrno parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOBUFS</term>
	/// <term>Memory could not be allocated for buffers.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the provider is
	/// already installed, the user lacks the administrative privileges required to write to the Winsock registry, or a failure occurred
	/// when creating or installing a catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCInstallProvider64_32</c> is a basic version of the WSCInstallProviderAndChains64_32 function that only installs a single
	/// transport service provider. <c>WSCInstallProvider64_32</c> can be used to install a base protocol, a layered protocol, or a
	/// protocol chain. If a layered service provider is being installed, then <c>WSCInstallProviderAndChains64_32</c> should be used
	/// because this function allows a layered protocol and one or more protocol chains to be installed with a single function call. To
	/// accomplish the same work using <c>WSCInstallProvider64_32</c> would require multiple function calls to install each service
	/// provider component.
	/// </para>
	/// <para>
	/// Windows Sockets (Winsock) 2 accommodates the notion of a layered protocol. A layered protocol is one that implements only higher
	/// level communications functions while relying on an underlying transport stack for the actual exchange of data with a remote
	/// endpoint. An example of a layered protocol would be a security layer that adds a protocol to the connection establishment
	/// process to perform authentication and to establish a mutually agreed upon encryption scheme. Such a security protocol would
	/// generally require the services of an underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to
	/// a protocol such as TCP or SPX which is fully capable of performing data communications with a remote endpoint. The term layered
	/// protocol is used to describe a protocol that cannot stand alone. A protocol chain would then be defined as one or more layered
	/// protocols strung together and anchored by a base protocol. A base protocol has the <c>ChainLen</c> member of the
	/// WSAProtocol_Info structure set to <c>BASE_PROTOCOL</c> which is defined to be 1. A layered protocol has the <c>ChainLen</c>
	/// member of the <c>WSAPROTOCOL_INFO</c> structure set to <c>LAYERED_PROTOCOL</c> which is defined to be zero. A protocol chain has
	/// the <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c> structure set to greater than 1.
	/// </para>
	/// <para>
	/// <c>WSCInstallProvider64_32</c> is the 64-bit version of WSCInstallProvider that installs the provider into both the 32-bit and
	/// 64-bit catalogs on 64-bit platforms. That is, on 64-bit platforms, two Winsock catalogs are maintained, and both 32-bit and
	/// 64-bit processes are able to load the transport provider installed with this function. On 64-bit platforms,
	/// <c>WSCInstallProvider</c> installs only to the 64-bit Winsock catalog.
	/// </para>
	/// <para>
	/// On a 64-bit computer, all calls not specifically designed for 32-bit (for example, all functions that do not end in "32")
	/// operate on the native 64-bit catalog. Processes that execute on a 64-bit computer must use <c>WSCInstallProvider64_32</c> to
	/// operate on both the 32-bit catalog as well as the 64-bit catalog, preserving compatibility. The definitions and semantics of the
	/// specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// This routine creates the necessary common Winsock 2 configuration information for the specified provider. It is applicable to
	/// base protocols, layered protocols, and protocol chains.
	/// </para>
	/// <para>
	/// The lpProtocolInfoList parameter contains a list of protocol entries to install. Callers of <c>WSCInstallProvider64_32</c> are
	/// responsible for setting up the proper protocol entries. The lpProtocolInfoList parameter must not be <c>NULL</c>.
	/// </para>
	/// <para>
	/// After this routine completes successfully, the protocol information provided in lpProtocolInfoList will be returned by
	/// WSAEnumProtocols, WSCEnumProtocols, or WSCEnumProtocols32. Be aware that in Windows, only instances of the Ws2_32.dll created by
	/// calling WSAStartup after a successful completion of this function will include the new entries in <c>WSAEnumProtocols</c>,
	/// <c>WSCEnumProtocols</c>, and <c>WSCEnumProtocols32</c>.
	/// </para>
	/// <para>
	/// On success, <c>WSCInstallProvider64_32</c> will attempt to alert all interested applications that have registered for
	/// notification of the change by calling WSAProviderConfigChange.
	/// </para>
	/// <para>
	/// The <c>WSCInstallProvider64_32</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCInstallProvider64_32</c> is called by a user that is not a member of the Administrators group, the function call will fail
	/// and WSANO_RECOVERY is returned in the lpErrno parameter. For computers running Windows Vista or Windows Server 2008, this
	/// function can also fail because of user account control (UAC). If an application that contains this function is executed by a
	/// user logged on as a member of the Administrators group other than the built-in Administrator, this call will fail unless the
	/// application has been marked in the manifest file with a <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If
	/// the application on Windows Vista or Windows Server 2008 lacks this manifest file, a user logged on as a member of the
	/// Administrators group other than the built-in Administrator must then be executing the application in an enhanced shell as the
	/// built-in Administrator ( <c>RunAs administrator</c>) for this function to succeed.
	/// </para>
	/// <para>Any file installation or service provider-specific configuration must be performed by the calling application.</para>
	/// <para>
	/// If the WSCInstallProvider or WSCInstallProviderAndChains function is used, the function must be called once to install the
	/// provider in the 32-bit catalog and once to install the provider in the 64-bit catalog on a 64-bit platform.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscinstallprovider64_32 int WSCInstallProvider64_32( LPGUID
	// lpProviderId, const WCHAR *lpszProviderDllPath, const LPWSAPROTOCOL_INFOW lpProtocolInfoList, DWORD dwNumberOfEntries, LPINT
	// lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "50d3a5d1-18f2-439e-a16c-6f31becb1e65")]
	public static extern WSRESULT WSCInstallProvider64_32(in Guid lpProviderId, [MarshalAs(UnmanagedType.LPWStr)] string lpszProviderDllPath,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] WSAPROTOCOL_INFOW[] lpProtocolInfoList, uint dwNumberOfEntries, out int lpErrno);

	/// <summary>
	/// The WSCInstallProviderAndChains64_32 function installs the specified transport provider and its specific protocol chains into both
	/// the 32-bit and 64-bit Winsock 2 system configuration databases on a 64-bit computer. This function ensures that the protocol chains
	/// are ordered at the beginning of the transport provider configuration information, making a separate call to WSCWriteProviderOrder unnecessary.
	/// </summary>
	/// <param name="lpProviderId">A pointer to a provider-specific, globally unique identifier (GUID).</param>
	/// <param name="lpszProviderDllPath">
	/// A pointer to a Unicode string containing the load path to the provider's DLL. This string observes the usual rules for path
	/// resolution and can contain embedded environment strings (%SystemRoot%, for example). Such environment strings are expanded whenever
	/// Ws2_32.dll subsequently loads the provider DLL on behalf of an application. After any embedded environment strings are expanded,
	/// Ws2_32.dll passes the resulting string into the LoadLibrary function to load the provider into memory. For more information, see <c>LoadLibrary</c>.
	/// </param>
	/// <param name="lpszLspName">A pointer to a Unicode string that contains the name of the socket provider.</param>
	/// <param name="dwServiceFlags">
	/// <para>The service flags for the type of "dummy" catalog entry to be created.</para>
	/// <para>
	/// A dummy entry is a WSAProtocol_Info structure with the <c>ChainLen</c> member set to 0. The actual LSP catalog entry will reference
	/// the ID of this dummy entry in its <c>ProtocolChain</c> member.
	/// </para>
	/// <para>The possible flags that can be set for this parameter are as follows:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>XP1_IFS_HANDLES</term>
	/// <term>
	/// The catalog entry is for an Installable File System (IFS) LSP, which returns IFS-specific socket handles. These handles are returned
	/// directly to the calling application. An IFS LSP cannot intercept the completion of Winsock calls, and does not have to have all
	/// Winsock functions implemented or available on it.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpProtocolInfoList">
	/// A pointer to an array of WSAProtocol_Info structures. Each structure defines a protocol, address family, and socket type supported by
	/// the provider. The members of the <c>WSAPROTOCOL_INFO</c> structure that are examined are <c>iProtocol</c>, <c>iAddressFamily</c>, and <c>iSocketType</c>.
	/// </param>
	/// <param name="dwNumberOfEntries">The number of entries in the lpProtocolInfoList array.</param>
	/// <param name="lpdwCatalogEntryId">
	/// Receives a pointer to the newly-installed "dummy" entry for the transport provider in the Winsock 2 system configuration database.
	/// This ID is used to install the catalog entries for the LSP.
	/// </param>
	/// <param name="lpErrno">A pointer that receives an error code generated by the call if the function fails.</param>
	/// <returns>
	/// <para>
	/// If <c>WSCInstallProviderAndChains</c> succeeds, it returns zero. Otherwise, it returns <c>SOCKET_ERROR</c>, and a specific error code
	/// is returned in the lpErrno parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>
	/// One or more of the arguments are invalid. This error is returned for the following conditions: the lpProviderId parameter is
	/// **NULL**, the lpszProviderDllPath parameter is invalid or the path length is too large (**MAX_PATH** was exceeded), the lpszLspName
	/// parameter is invalid or the name length is too large (**WSAPROTOCOL_LEN** is exceeded), the lpProtocolInfoList is set to a
	/// non-**NULL** and the dwNumberOfEntries parameter is zero, a duplicate provider ID or the layered service provider name already exist
	/// in the catalog, or a match cannot be found for the specified protocol, address family, and socket type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A provider installation is already in progress.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVALIDPROCTABLE</term>
	/// <term>The provider is missing required functionality.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOBUFS</term>
	/// <term>Memory cannot be allocated for buffers.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the provider is already
	/// installed, the lpProtocolInfoList parameter was **NULL** and there was no base provider found, the maximum protocol chain length
	/// (**MAX_PROTOCOL_CHAIN**) was reached, the user lacks the administrative privileges required to write to the Winsock registry, or a
	/// failure occurred when creating or installing a catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCInstallProviderAndChains</c> is an enhanced version of the basic WSCInstallProvider function used to install a single transport
	/// service provider. If a layered service provider is being installed, then <c>WSCInstallProviderAndChains</c> should be used.
	/// <c>WSCInstallProviderAndChains</c> can install a layered protocol and one or more protocol chains with a single function call. To
	/// accomplish the same work using <c>WSCInstallProvider</c> would require multiple function calls.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions while
	/// relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered protocol
	/// would be a security layer that adds a protocol to the connection establishment process in order to perform authentication and to
	/// establish a mutually agreed upon encryption scheme. Such a security protocol would generally require the services of an underlying
	/// reliable transport protocol such as TCP or SPX. The term base protocol refers to a protocol such as TCP or SPX which is capable of
	/// performing data communications with a remote endpoint. The term layered protocol is used to describe a protocol that cannot stand
	/// alone. A protocol chain would then be defined as one or more layered protocols strung together and anchored by a base protocol. A
	/// base protocol has the <c>ChainLen</c> member of the WSAProtocol_Info structure set to <c>BASE_PROTOCOL</c> which is defined to be 1.
	/// A layered protocol has the <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c> structure set to <c>LAYERED_PROTOCOL</c> which is
	/// defined to be zero. A protocol chain has the <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c> structure set to greater than 1.
	/// </para>
	/// <para>
	/// If lpProtocolInfoList is set to <c>NULL</c>, this function creates protocol chains where the provider is layered over the base
	/// protocol for each unique protocol type as defined by the address family, socket type, and protocol. This eliminates the creation of
	/// any inaccessible duplicate provider entries.
	/// </para>
	/// <para>
	/// If lpProtocolInfoList is set to a non- <c>NULL</c> value, this function creates protocol chains by obtaining the top-most entry in
	/// the configuration information that matches the address family, socket type, and protocol from each element in the provided array.
	/// Again, only the address family, socket type, and protocol are considered; all other members and duplicates are ignored.
	/// </para>
	/// <para>
	/// Upon successful completion of this call, any subsequent calls to WSAEnumProtocols or WSCEnumProtocols will return the newly-created
	/// protocol chain entries. Be aware that in Windows environments, only instances of Ws_32.dll created by calling WSAStartup after the
	/// successful completion of <c>WSCInstallProviderAndChains</c> will include the new entries when <c>WSAEnumProtocols</c> and
	/// <c>WSCEnumProtocols</c> returns.
	/// </para>
	/// <para>
	/// On success, <c>WSCInstallProviderAndChains</c> will attempt to alert all interested applications that have registered for
	/// notification of the change by calling WSAProviderConfigChange.
	/// </para>
	/// <para>
	/// The <c>WSCInstallProviderAndChains</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCInstallProviderAndChains</c> is called by a user that is not a member of the Administrators group, the function call will fail
	/// and WSANO_RECOVERY is returned in the lpErrno parameter. For computers running Windows Vista or Windows Server 2008, this function
	/// can also fail because of user account control (UAC). If an application that contains this function is executed by a user logged on as
	/// a member of the Administrators group other than the built-in Administrator, this call will fail unless the application has been
	/// marked in the manifest file with a <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows
	/// Vista or Windows Server 2008 lacks this manifest file, a user logged on as a member of the Administrators group other than the
	/// built-in Administrator must then be executing the application in an enhanced shell as the built-in Administrator ( <c>RunAs
	/// administrator</c>) for this function to succeed.
	/// </para>
	/// <para>Any file installation or provider-specific configuration must be performed by the calling application.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscinstallproviderandchains int WSCInstallProviderAndChains(
	// LPGUID lpProviderId, const PWSTR lpszProviderDllPath, const PWSTR lpszLspName, DWORD dwServiceFlags, LPWSAPROTOCOL_INFOW
	// lpProtocolInfoList, DWORD dwNumberOfEntries, LPDWORD lpdwCatalogEntryId, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "592f48b4-5826-449f-b5cc-b0990679fe9f")]
	public static extern WSRESULT WSCInstallProviderAndChains64_32(in Guid lpProviderId, [MarshalAs(UnmanagedType.LPWStr)] string lpszProviderDllPath,
		[MarshalAs(UnmanagedType.LPWStr)] string lpszLspName, XP1 dwServiceFlags, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] WSAPROTOCOL_INFOW[]? lpProtocolInfoList,
		uint dwNumberOfEntries, out uint lpdwCatalogEntryId, out int lpErrno);

	/// <summary>The **WSCSetApplicationCategory** function sets the permitted layered service provider (LSP) categories associated with an application.</summary>
	/// <param name="Path">
	/// A pointer to a Unicode string that contains the load path to the executable image for the application. This string observes the
	/// usual rules for path resolution and can contain embedded environment strings (such as %SystemRoot%).
	/// </param>
	/// <param name="PathLength">The length, in characters, of the Path parameter. This length does not include the terminating <c>NULL</c>.</param>
	/// <param name="Extra">
	/// A pointer to a Unicode string which represents the command line arguments used when starting the application specified in the
	/// Path parameter. The Extra parameter is used to distinguish between multiple, distinct instances of an application when launched
	/// with a consistent command line. This is to support different application categorizations for different instances of Svchost.exe
	/// or Rundll32.exe. If only the Path parameter is required and no command line arguments are needed to further distinguish between
	/// instances of an application, then the Extra parameter should be set to <c>NULL</c>.
	/// </param>
	/// <param name="ExtraLength">The length, in characters, of the Extra parameter. This length does not include the terminating <c>NULL</c>.</param>
	/// <param name="PermittedLspCategories">
	/// A DWORD value of the LSP categories which are permitted for all instances of this application. The application is identified by
	/// the combination of the values of the Path and Extra parameters.
	/// </param>
	/// <param name="pPrevPermLspCat">
	/// A pointer to receive the previous set of permitted LSP categories which were permitted for all instances of this application.
	/// This parameter is optional can be <c>NULL</c>.
	/// </param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCSetApplicationCategory</c> returns <c>ERROR_SUCCESS</c> (zero). Otherwise, it returns
	/// <c>SOCKET_ERROR</c>, and a specific error code is returned in the lpErrno parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
	/// administrative privileges required to access the Winsock registry, or a failure occurred when opening a Winsock catalog entry or
	/// an application ID entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCSetApplicationCategory</c> is used to set the LSP category flags associated with an application instance. Applications can
	/// determine which LSP behaviors are acceptable within the application's context. Therefore, through specifying permitted LSP
	/// categories, an application can permit only those layered service providers which implement acceptable behaviors to be loaded.
	/// </para>
	/// <para>
	/// The Extra parameter is required when the command line is used to distinguish between different instances of an application or
	/// service hosted within the same executable. Each instance can have different application categorization needs. Svchost.exe and
	/// Rundll32.exe are two examples where the command line is required to differentiate between different process instances. For
	/// SvcHost.exe, the <c>-k &lt;svcinstance&gt;</c> switch defines the process instance.
	/// </para>
	/// <para>
	/// For services, using the Service Name is not sufficient, because the Winsock Catalog is global to a given process, and a process
	/// may host several services.
	/// </para>
	/// <para>
	/// If the <c>WSCSetApplicationCategory</c> function is called on the same application (the same fullpath, EXE name, and parameters)
	/// multiple times, then the categories are ORed together. For example if you categorized "c:\foo.exe -param" with LSP_SYSTEM and
	/// then called the <c>WSCSetApplicationCategory</c> function again with LSP_REDIRECTOR, the resulting entry for htis application
	/// contains LSP_SYSTEM | LSP_REDIRECTOR. This behavior is designed to support a single executable file that hosts multiple
	/// applications in a single EXE (the Windows system services svchost.exe, for example).
	/// </para>
	/// <para>
	/// Window sockets determine an application's identity and retrieves the permitted LSP categories during the first call to
	/// WSAStartup. This will be the set of permitted LSP categories for the duration of the application instance. Subsequent changes to
	/// the permitted LSP categories for a given application identity will not be picked up until the next instance of the application.
	/// The permitted LSP categories is not mutable during the lifetime of the application instance.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions,
	/// while relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered
	/// protocol or layered service provider would be a security layer that adds protocol to the connection establishment process in
	/// order to perform authentication and to establish a mutually agreed upon encryption scheme. Such a security protocol would
	/// generally require the services of an underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to
	/// a protocol such as TCP or SPX which is capable of performing data communications with a remote endpoint. The term layered
	/// protocol is used to describe a protocol that cannot stand alone.
	/// </para>
	/// <para>
	/// During LSP initialization, the LSP must provide pointers to a number of Winsock SPI functions. These functions will be called
	/// during normal processing by the layer directly above the LSP (either another LSP or Ws2_32.dll).
	/// </para>
	/// <para>
	/// An LSP that implements an installable file system (IFS) can selectively choose to provide pointers to functions which are
	/// implemented by itself, or pass back the pointers provided by the layer directly below the LSP. Non-IFS LSPs, because they
	/// provide their own handles, must implement all of the Winsock SPI functions. This is because each SPI will require the LSP to map
	/// all of the socket handles it created to the socket handle of the lower provider (either another LSP or the base protocol).
	/// </para>
	/// <para>However, all LSPs perform their specific work by doing extra processing on only a subset of the Winsock SPI functions.</para>
	/// <para>
	/// It is possible to define LSP categories based upon the subset of SPI functions an LSP implements and the nature of the extra
	/// processing performed for each of those functions.
	/// </para>
	/// <para>
	/// By classifying LSPs, as well as classifying applications which use Winsock sockets, it becomes possible to selectively determine
	/// if an LSP should be involved in a given process at runtime.
	/// </para>
	/// <para>
	/// On Windows Vista and later, an LSP can be classified based on how it interacts with Windows Sockets calls and data. An LSP
	/// category is an identifiable group of behaviors on a subset of Winsock SPI functions. For example, an HTTP content filter would
	/// be categorized as a data inspector (the <c>LSP_INSPECTOR</c> category). The <c>LSP_INSPECTOR</c> category will inspect (but not
	/// alter) parameters to data transfer SPI functions. An application can query for the category of an LSP and choose to not load the
	/// LSP based on the LSP category and the application's set of permitted LSP categories.
	/// </para>
	/// <para>The following table lists categories into which an LSP can be classified.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>LSP Category</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>**LSP_CRYPTO_COMPRESS**</term>
	/// <term>The LSP is a cryptography or data compression provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_FIREWALL**</term>
	/// <term>The LSP is a firewall provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_LOCAL_CACHE**</term>
	/// <term>The LSP is a local cache provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INBOUND_MODIFY**</term>
	/// <term>The LSP modifies inbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INSPECTOR**</term>
	/// <term>The LSP inspects or filters data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_OUTBOUND_MODIFY**</term>
	/// <term>The LSP modifies outbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_PROXY**</term>
	/// <term>The LSP acts as a proxy and redirects packets.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_REDIRECTOR**</term>
	/// <term>The LSP is a network redirector.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_SYSTEM**</term>
	/// <term>The LSP is acceptable for use in services and system processes.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An LSP may belong to more than one category. For example, a firewall/security LSP could belong to both the inspector (
	/// <c>LSP_INSPECTOR</c>) and firewall ( <c>LSP_FIREWALL</c>) categories.
	/// </para>
	/// <para>
	/// If an LSP does not have a category set, it is considered to be in the All Other category. This LSP category will not be loaded
	/// in services or system processes (for example, lsass, winlogon, and many svchost processes).
	/// </para>
	/// <para>
	/// The <c>WSCSetApplicationCategory</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCSetApplicationCategory</c> is called by a user that is not a member of the Administrators group, the function call will
	/// fail and <c>WSANO_RECOVERY</c> is returned in the lpErrno parameter. This function can also fail because of user account control
	/// (UAC). If an application that contains this function is executed by a user logged on as a member of the Administrators group
	/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// <para>Any file installation or service provider-specific configuration must be performed by the caller.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscsetapplicationcategory int WSCSetApplicationCategory(
	// LPCWSTR Path, DWORD PathLength, LPCWSTR Extra, DWORD ExtraLength, DWORD PermittedLspCategories, DWORD *pPrevPermLspCat, LPINT
	// lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "266c9424-f6ab-4630-843d-bc0833d74e4f")]
	public static extern WSRESULT WSCSetApplicationCategory([MarshalAs(UnmanagedType.LPWStr)] string Path, uint PathLength, [MarshalAs(UnmanagedType.LPWStr)] string Extra,
		uint ExtraLength, uint PermittedLspCategories, out uint pPrevPermLspCat, out int lpErrno);

	/// <summary>The **WSCSetProviderInfo** function sets the data value for the specified information class for a layered service provider (LSP).</summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the provider.</param>
	/// <param name="InfoType">The information class to be set for this LSP protocol entry.</param>
	/// <param name="Info">A pointer to a buffer that contains the information class data to set for the LSP protocol entry.</param>
	/// <param name="InfoSize">The size, in bytes, of the buffer pointed to by the Info parameter.</param>
	/// <param name="Flags">The flags used to modify the behavior of the <c>WSCSetProviderInfo</c> function call.</param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCSetProviderInfo</c> returns <c>ERROR_SUCCESS</c> (zero). Otherwise, it returns <c>SOCKET_ERROR</c>,
	/// and a specific error code is returned in the lpErrno parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>The call is not implemented. This error is returned if **ProviderInfoAudit** is specified in the InfoType parameter.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
	/// administrative privileges required to write to the Winsock registry, or a failure occurred when opening a Winsock catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCSetProviderInfo</c> is used to set the information class data for a layered service provider. When the InfoType parameter
	/// is set to <c>ProviderInfoLspCategories</c>, on success <c>WSCSetProviderInfo</c> sets appropriate LSP category flags implemented
	/// by the provider based on the value passed in the Info parameter.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions,
	/// while relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered
	/// protocol or layered service provider would be a security layer that adds protocol to the connection establishment process in
	/// order to perform authentication and to establish a mutually agreed upon encryption scheme. Such a security protocol would
	/// generally require the services of an underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to
	/// a protocol such as TCP or SPX which is capable of performing data communications with a remote endpoint. The term layered
	/// protocol is used to describe a protocol that cannot stand alone. A protocol chain would then be defined as one or more layered
	/// protocols strung together and anchored by a base protocol. A base protocol has the <c>ChainLen</c> member of the
	/// WSAPROTOCOL_INFO structure set to <c>BASE_PROTOCOL</c> which is defined to be 1. A layered protocol has the <c>ChainLen</c>
	/// member of the <c>WSAPROTOCOL_INFO</c> structure set to <c>LAYERED_PROTOCOL</c> which is defined to be zero. A protocol chain has
	/// the <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c> structure set to greater than 1.
	/// </para>
	/// <para>
	/// During LSP initialization, the LSP must provide pointers to a number of Winsock SPI functions. These functions will be called
	/// during normal processing by the layer directly above the LSP (either another LSP or Ws2_32.dll).
	/// </para>
	/// <para>
	/// An LSP that implements an installable file system (IFS) can selectively choose to provide pointers to functions which are
	/// implemented by itself, or pass back the pointers provided by the layer directly below the LSP. Non-IFS LSPs, because they
	/// provide their own handles, must implement all of the Winsock SPI functions. This is because each SPI will require the LSP to map
	/// all of the socket handles it created to the socket handle of the lower provider (either another LSP or the base protocol).
	/// </para>
	/// <para>However, all LSPs perform their specific work by doing extra processing on only a subset of the Winsock SPI functions.</para>
	/// <para>
	/// It is possible to define LSP categories based upon the subset of SPI functions an LSP implements and the nature of the extra
	/// processing performed for each of those functions.
	/// </para>
	/// <para>
	/// By classifying LSPs, as well as classifying applications which use Winsock sockets, it becomes possible to selectively determine
	/// if an LSP should be involved in a given process at runtime.
	/// </para>
	/// <para>
	/// On Windows Vista and later, an LSP can be classified based on how it interacts with Windows Sockets calls and data. An LSP
	/// category is an identifiable group of behaviors on a subset of Winsock SPI functions. For example, an HTTP content filter would
	/// be categorized as a data inspector (the <c>LSP_INSPECTOR</c> category). The <c>LSP_INSPECTOR</c> category will inspect, but not
	/// alter, parameters to data transfer SPI functions. An application can query for the category of an LSP and choose to not load the
	/// LSP based on the LSP category and the application's set of permitted LSP categories.
	/// </para>
	/// <para>The following table lists categories into which an LSP can be classified.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>LSP Category</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>**LSP_CRYPTO_COMPRESS**</term>
	/// <term>The LSP is a cryptography or data compression provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_FIREWALL**</term>
	/// <term>The LSP is a firewall provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_LOCAL_CACHE**</term>
	/// <term>The LSP is a local cache provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INBOUND_MODIFY**</term>
	/// <term>The LSP modifies inbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INSPECTOR**</term>
	/// <term>The LSP inspects or filters data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_OUTBOUND_MODIFY**</term>
	/// <term>The LSP modifies outbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_PROXY**</term>
	/// <term>The LSP acts as a proxy and redirects packets.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_REDIRECTOR**</term>
	/// <term>The LSP is a network redirector.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_SYSTEM**</term>
	/// <term>The LSP is acceptable for use in services and system processes.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An LSP may belong to more than one category. For example, firewall/security LSP could belong to both the inspector
	/// (**LSP_INSPECTOR**) and firewall (**LSP_FIREWALL**) categories.
	/// </para>
	/// <para>
	/// If an LSP does not have category set, it is considered to be in the All Other category. This LSP category will not be loaded in
	/// services or system processes (for example, lsass, winlogon, and many svchost processes).
	/// </para>
	/// <para>
	/// The <c>WSCSetProviderInfo</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCSetProviderInfo</c> is called by a user that is not a member of the Administrators group, the function call will fail and
	/// <c>WSANO_RECOVERY</c> is returned in the lpErrno parameter. This function can also fail because of user account control (UAC).
	/// If an application that contains this function is executed by a user logged on as a member of the Administrators group other than
	/// the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// <para>
	/// **Note** The TDI feature is deprecated and will be removed in future versions of Microsoft Windows. Depending on how you use
	/// TDI, use either the Winsock Kernel (WSK) or Windows Filtering Platform (WFP). For more information about WFP and WSK, see
	/// Windows Filtering Platform and Winsock Kernel. For a Windows Core Networking blog entry about WSK and TDI, see Introduction to
	/// Winsock Kernel (WSK).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscsetproviderinfo int WSCSetProviderInfo( LPGUID
	// lpProviderId, WSC_PROVIDER_INFO_TYPE InfoType, PBYTE Info, size_t InfoSize, DWORD Flags, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "10eed3e6-d5a0-4ba4-964e-3d924a231afb")]
	public static extern WSRESULT WSCSetProviderInfo(in Guid lpProviderId, WSC_PROVIDER_INFO_TYPE InfoType, IntPtr Info, SIZE_T InfoSize, uint Flags, out int lpErrno);

	/// <summary>The **WSCSetProviderInfo32** function sets the data value for specified information class for a layered service provider (LSP).</summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the provider.</param>
	/// <param name="InfoType">The information class to be set for this LSP protocol entry.</param>
	/// <param name="Info">A pointer to a buffer that contains the information class data to set for the LSP protocol entry.</param>
	/// <param name="InfoSize">The size, in bytes, of the buffer pointed to by the Info parameter.</param>
	/// <param name="Flags">The flags used to modify the behavior of the <c>WSCSetProviderInfo32</c> function call.</param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCSetProviderInfo32</c> returns <c>ERROR_SUCCESS</c> (zero). Otherwise, it returns <c>SOCKET_ERROR</c>,
	/// and a specific error code is returned in the lpErrno parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>The call is not implemented. This error is returned if **ProviderInfoAudit** is specified in the InfoType parameter.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>
	/// A nonrecoverable error occurred. This error is returned under several conditions including the following: the user lacks the
	/// administrative privileges required to write to the Winsock registry, or a failure occurred when opening a Winsock catalog entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCSetProviderInfo32</c> is a strictly 32-bit version of WSCSetProviderInfo. On a 64-bit computer, all calls not specifically
	/// 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that execute on a
	/// 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve compatibility.
	/// The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// <c>WSCSetProviderInfo32</c> is used to set the information class data for a 32-bit layered service provider. When the InfoType
	/// parameter is set to <c>ProviderInfoLspCategories</c>, on success <c>WSCSetProviderInfo32</c> sets appropriate LSP category flags
	/// implemented by the provider based on the value passed in the Info parameter.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions,
	/// while relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered
	/// protocol or layered service provider would be a security layer that adds protocol to the connection establishment process in
	/// order to perform authentication and to establish a mutually agreed upon encryption scheme. Such a security protocol would
	/// generally require the services of an underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to
	/// a protocol such as TCP or SPX which is capable of performing data communications with a remote endpoint. The term layered
	/// protocol is used to describe a protocol that cannot stand alone. A protocol chain would then be defined as one or more layered
	/// protocols strung together and anchored by a base protocol. A base protocol has the <c>ChainLen</c> member of the
	/// WSAProtocol_Info structure set to <c>BASE_PROTOCOL</c> which is defined to be 1. A layered protocol has the <c>ChainLen</c>
	/// member of the <c>WSAPROTOCOL_INFO</c> structure set to <c>LAYERED_PROTOCOL</c> which is defined to be zero. A protocol chain has
	/// the <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c> structure set to greater than 1.
	/// </para>
	/// <para>
	/// During LSP initialization, the LSP must provide pointers to a number of Winsock SPI functions. These functions will be called
	/// during normal processing by the layer directly above the LSP (either another LSP or Ws2_32.dll).
	/// </para>
	/// <para>
	/// An LSP that implements an installable file system (IFS) can selectively choose to provide pointers to functions which are
	/// implemented by itself, or pass back the pointers provided by the layer directly below the LSP. Non-IFS LSPs, because they
	/// provide their own handles, must implement all of the Winsock SPI functions. This is because each SPI will require the LSP to map
	/// all of the socket handles it created to the socket handle of the lower provider (either another LSP or the base protocol).
	/// </para>
	/// <para>However, all LSPs perform their specific work by doing extra processing on only a subset of the Winsock SPI functions.</para>
	/// <para>
	/// It is possible to define LSP categories based upon the subset of SPI functions an LSP implements and the nature of the extra
	/// processing performed for each of those functions.
	/// </para>
	/// <para>
	/// By classifying LSPs, as well as classifying applications which use Winsock sockets, it becomes possible to selectively determine
	/// if an LSP should be involved in a given process at runtime.
	/// </para>
	/// <para>
	/// On Windows Vista and later, an LSP can be classified based on how it interacts with Windows Sockets calls and data. An LSP
	/// category is an identifiable group of behaviors on a subset of Winsock SPI functions. For example, an HTTP content filter would
	/// be categorized as a data inspector (the <c>LSP_INSPECTOR</c> category). The <c>LSP_INSPECTOR</c> category will inspect, but not
	/// alter, parameters to data transfer SPI functions. An application can query for the category of an LSP and choose to not load the
	/// LSP based on the LSP category and the application's set of permitted LSP categories.
	/// </para>
	/// <para>The following table lists categories into which an LSP can be classified.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>LSP Category</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>**LSP_CRYPTO_COMPRESS**</term>
	/// <term>The LSP is a cryptography or data compression provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_FIREWALL**</term>
	/// <term>The LSP is a firewall provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_LOCAL_CACHE**</term>
	/// <term>The LSP is a local cache provider.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INBOUND_MODIFY**</term>
	/// <term>The LSP modifies inbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_INSPECTOR**</term>
	/// <term>The LSP inspects or filters data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_OUTBOUND_MODIFY**</term>
	/// <term>The LSP modifies outbound data.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_PROXY**</term>
	/// <term>The LSP acts as a proxy and redirects packets.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_REDIRECTOR**</term>
	/// <term>The LSP is a network redirector.</term>
	/// </item>
	/// <item>
	/// <term>**LSP_SYSTEM**</term>
	/// <term>The LSP is acceptable for use in services and system processes.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An LSP may belong to more than one category. For example, firewall/security LSP could belong to both the inspector (
	/// <c>LSP_INSPECTOR</c>) and firewall ( <c>LSP_FIREWALL</c>) categories.
	/// </para>
	/// <para>
	/// If an LSP does not have category set, it is considered to be in the All Other category. This LSP category will not be loaded in
	/// services or system processes (for example, lsass, winlogon, and many svchost processes).
	/// </para>
	/// <para>
	/// The <c>WSCSetProviderInfo32</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCSetProviderInfo32</c> is called by a user that is not a member of the Administrators group, the function call will fail
	/// and <c>WSANO_RECOVERY</c> is returned in the lpErrno parameter. This function can also fail because of user account control
	/// (UAC). If an application that contains this function is executed by a user logged on as a member of the Administrators group
	/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscsetproviderinfo32 int WSCSetProviderInfo32( LPGUID
	// lpProviderId, WSC_PROVIDER_INFO_TYPE InfoType, PBYTE Info, size_t InfoSize, DWORD Flags, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "adb2737f-5327-4306-bd57-f165f339f911")]
	public static extern WSRESULT WSCSetProviderInfo32(in Guid lpProviderId, WSC_PROVIDER_INFO_TYPE InfoType, IntPtr Info, SIZE_T InfoSize, uint Flags, out int lpErrno);

	/// <summary>The <c>WSCUnInstallNameSpace</c> function uninstalls the indicated name-space provider.</summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the name-space provider to be uninstalled.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCUnInstallNameSpace</c> returns <c>NO_ERROR</c> (zero). Otherwise, it returns <c>SOCKET_ERROR</c> if
	/// the function fails, and you must retrieve the appropriate error code using the WSAGetLastError function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The lpProviderId parameter points to memory that is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The specified namespace–provider identifier is invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The namespace configuration functions do not affect applications that are already running. Newly installed name-space providers
	/// will not be visible to applications nor will the changes in a name-space provider's activation state. Applications launched
	/// after the call to <c>WSCUnInstallNameSpace</c> will see the changes.
	/// </para>
	/// <para>
	/// On success, <c>WSCUnInstallNameSpace</c> will attempt to alert all interested applications that have registered for notification
	/// of the change by calling WSAProviderConfigChange.
	/// </para>
	/// <para>
	/// The <c>WSCUnInstallNameSpace</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCUnInstallNameSpace</c> is called by a user that is not a member of the Administrators group, the function call will fail
	/// and <c>WSANO_RECOVERY</c> is returned in the lpErrno parameter.
	/// </para>
	/// <para>
	/// For computers running on Windows Vista or Windows Server 2008, this function can also fail because of user account control
	/// (UAC). If an application that contains this function is executed by a user logged on as a member of the Administrators group
	/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// <para>
	/// The caller of this function must remove any additional files or service provider–specific configuration information that is
	/// required to completely uninstall the service provider.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscuninstallnamespace INT WSCUnInstallNameSpace( LPGUID
	// lpProviderId );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "5267f986-99fc-4e53-9fbb-3850bb9d24cf")]
	public static extern WSRESULT WSCUnInstallNameSpace(in Guid lpProviderId);

	/// <summary>The <c>WSCUnInstallNameSpace32</c> function uninstalls a specific 32-bit namespace provider.</summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the name-space provider to be uninstalled.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCUnInstallNameSpace32</c> returns <c>NO_ERROR</c> (zero). Otherwise, it returns <c>SOCKET_ERROR</c> if
	/// the function fails, and you must retrieve the appropriate error code using the WSAGetLastError function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The lpProviderId parameter points to memory that is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The specified namespace–provider identifier is invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSASYSCALLFAILURE</term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSA_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Insufficient memory was available. This error is returned when there is insufficient memory to allocate a new catalog entry.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCUnInstallNameSpace32</c> is a strictly 32-bit version of WSCUnInstallNameSpace. On a 64-bit computer, all calls not
	/// specifically 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that
	/// execute on a 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve
	/// compatibility. The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// The namespace configuration functions do not affect applications that are already running. Newly installed name-space providers
	/// will not be visible to applications nor will the changes in a name-space provider's activation state. Applications launched
	/// after the call to <c>WSCUnInstallNameSpace32</c> will recognize the changes.
	/// </para>
	/// <para>
	/// On success, <c>WSCUnInstallNameSpace32</c> will attempt to alert all interested applications that have registered for
	/// notification of the change by calling WSAProviderConfigChange.
	/// </para>
	/// <para>
	/// The <c>WSCUnInstallNameSpace32</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCUnInstallNameSpace32</c> is called by a user that is not a member of the Administrators group, the function call will fail
	/// and <c>WSANO_RECOVERY</c> is returned in the lpErrno parameter.
	/// </para>
	/// <para>
	/// For computers running on Windows Vista or Windows Server 2008, this function can also fail because of user account control
	/// (UAC). If an application that contains this function is executed by a user logged on as a member of the Administrators group
	/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// <para>
	/// The caller of this function must remove any additional files or service provider–specific configuration information that is
	/// required to completely uninstall the service provider.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscuninstallnamespace32 INT WSCUnInstallNameSpace32( LPGUID
	// lpProviderId );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "a2a08159-6ac0-493d-8f9f-d19aa199a65f")]
	public static extern WSRESULT WSCUnInstallNameSpace32(in Guid lpProviderId);

	/// <summary>The <c>WSCUpdateProvider</c> function modifies the specified transport provider in the system configuration database.</summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the provider.</param>
	/// <param name="lpszProviderDllPath">
	/// A pointer to a Unicode string that contains the load path to the provider 64-bit DLL. This string observes the usual rules for
	/// path resolution and can contain embedded environment strings (such as %SystemRoot%). Such environment strings are expanded when
	/// the Ws2_32.dll must subsequently load the provider DLL on behalf of an application. After any embedded environment strings are
	/// expanded, the Ws2_32.dll passes the resulting string to the LoadLibrary function which loads the provider into memory. For more
	/// information, see <c>LoadLibrary</c>.
	/// </param>
	/// <param name="lpProtocolInfoList">
	/// A pointer to an array of WSAProtocol_Info structures. Each structure specifies or modifies a protocol, address family, and
	/// socket type supported by the provider.
	/// </param>
	/// <param name="dwNumberOfEntries">The number of entries in the lpProtocolInfoList array.</param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCUpdateProvider</c> returns zero. Otherwise, it returns <c>SOCKET_ERROR</c>, and a specific error code
	/// is returned in the lpErrno parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments are not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
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
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSCUpdateProvider</c> function modifies Windows Sockets 2 configuration information for the specified provider. It is
	/// applicable to base protocols, layered protocols, and protocol chains.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions,
	/// while relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered
	/// protocol would be a security layer that adds protocol to the connection establishment process in order to perform authentication
	/// and to establish a mutually agreed upon encryption scheme. Such a security protocol would generally require the services of an
	/// underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to a protocol such as TCP or SPX which
	/// is capable of performing data communications with a remote endpoint. The term layered protocol is used to describe a protocol
	/// that cannot stand alone. A protocol chain would then be defined as one or more layered protocols strung together and anchored by
	/// a base protocol. A base protocol has the <c>ChainLen</c> member of the WSAProtocol_Info structure set to <c>BASE_PROTOCOL</c>
	/// which is defined to be 1. A layered protocol has the <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c> structure set to
	/// <c>LAYERED_PROTOCOL</c> which is defined to be zero. A protocol chain has the <c>ChainLen</c> member of the
	/// <c>WSAPROTOCOL_INFO</c> structure set to greater than 1.
	/// </para>
	/// <para>
	/// On success, <c>WSCUpdateProvider</c> will attempt to alert all interested applications that have registered for notification of
	/// the change by calling WSAProviderConfigChange.
	/// </para>
	/// <para>
	/// The <c>WSCUpdateProvider</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCUpdateProvider</c> is called by a user that is not a member of the Administrators group, the function call will fail.
	/// </para>
	/// <para>
	/// For computers running on Windows Vista or Windows Server 2008, this function can also fail because of user account control
	/// (UAC). If an application that contains this function is executed by a user logged on as a member of the Administrators group
	/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
	/// </para>
	/// <para>Any file installation or service provider-specific configuration must be performed by the caller.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscupdateprovider int WSCUpdateProvider( LPGUID lpProviderId,
	// const WCHAR *lpszProviderDllPath, const LPWSAPROTOCOL_INFOW lpProtocolInfoList, DWORD dwNumberOfEntries, LPINT lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "7777a2ff-2ece-4f28-88af-87fc96fdda9f")]
	public static extern WSRESULT WSCUpdateProvider(in Guid lpProviderId, [MarshalAs(UnmanagedType.LPWStr)] string lpszProviderDllPath,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] WSAPROTOCOL_INFOW[] lpProtocolInfoList, uint dwNumberOfEntries, out int lpErrno);

	/// <summary>
	/// The <c>WSCUpdateProvider32</c> function modifies the specified 32-bit transport provider in the system configuration database.
	/// </summary>
	/// <param name="lpProviderId">A pointer to a globally unique identifier (GUID) for the provider.</param>
	/// <param name="lpszProviderDllPath">
	/// A pointer to a Unicode string that contains the load path to the provider 64-bit DLL. This string observes the usual rules for
	/// path resolution and can contain embedded environment strings (such as %SystemRoot%). Such environment strings are expanded when
	/// the Ws2_32.dll must subsequently load the provider DLL on behalf of an application. After any embedded environment strings are
	/// expanded, the Ws2_32.dll passes the resulting string to the LoadLibrary function which loads the provider into memory. For more
	/// information, see <c>LoadLibrary</c>.
	/// </param>
	/// <param name="lpProtocolInfoList">
	/// A pointer to an array of WSAProtocol_Info structures. Each structure specifies or modifies a protocol, address family, and
	/// socket type supported by the provider.
	/// </param>
	/// <param name="dwNumberOfEntries">The number of entries in the lpProtocolInfoList array.</param>
	/// <param name="lpErrno">A pointer to the error code if the function fails.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSCUpdateProvider32</c> returns zero. Otherwise, it returns SOCKET_ERROR, and a specific error code is
	/// available in lpErrno.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>One or more of the arguments is not in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>One or more of the arguments are invalid.</term>
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
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WSCUpdateProvider32</c> is a strictly 32-bit version of WSCUpdateProvider. On a 64-bit computer, all calls not specifically
	/// 32-bit (for example, all functions that do not end in "32") operate on the native 64-bit catalog. Processes that execute on a
	/// 64-bit computer must use the specific 32-bit function calls to operate on a strictly 32-bit catalog and preserve compatibility.
	/// The definitions and semantics of the specific 32-bit calls are the same as their native counterparts.
	/// </para>
	/// <para>
	/// This function modifies Windows Sockets 2 configuration information for the specified 32-bit provider. It is applicable to base
	/// protocols, layered protocols, and protocol chains.
	/// </para>
	/// <para>
	/// Winsock 2 accommodates layered protocols. A layered protocol is one that implements only higher level communications functions,
	/// while relying on an underlying transport stack for the actual exchange of data with a remote endpoint. An example of a layered
	/// protocol would be a security layer that adds protocol to the connection establishment process in order to perform authentication
	/// and to establish a mutually agreed upon encryption scheme. Such a security protocol would generally require the services of an
	/// underlying reliable transport protocol such as TCP or SPX. The term base protocol refers to a protocol such as TCP or SPX which
	/// is capable of performing data communications with a remote endpoint. The term layered protocol is used to describe a protocol
	/// that cannot stand alone. A protocol chain would then be defined as one or more layered protocols strung together and anchored by
	/// a base protocol. A base protocol has the <c>ChainLen</c> member of the WSAProtocol_Info structure set to <c>BASE_PROTOCOL</c>
	/// which is defined to be 1. A layered protocol has the <c>ChainLen</c> member of the <c>WSAPROTOCOL_INFO</c> structure set to
	/// <c>LAYERED_PROTOCOL</c> which is defined to be zero. A protocol chain has the <c>ChainLen</c> member of the
	/// <c>WSAPROTOCOL_INFO</c> structure set to greater than 1.
	/// </para>
	/// <para>
	/// On success, <c>WSCUpdateProvider32</c> will attempt to alert all interested applications that have registered for notification
	/// of the change by calling WSAProviderConfigChange.
	/// </para>
	/// <para>
	/// The <c>WSCUpdateProvider32</c> function can only be called by a user logged on as a member of the Administrators group. If
	/// <c>WSCUpdateProvider32</c> is called by a user that is not a member of the Administrators group, the function call will fail.
	/// </para>
	/// <para>
	/// For computers running Windows Vista or Windows Server 2008, this function can also fail because of user account control (UAC).
	/// If an application that contains this function is executed by a user logged on as a member of the Administrators group other than
	/// the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
	/// <c>requestedExecutionLevel</c> set to <c>requireAdministrator</c>. If the application on Windows Vista or Windows Server 2008
	/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
	/// then be executing the application in an enhanced shell as the built-in Administrator ( <c>RunAs administrator</c>) for this
	/// function to succeed.
	/// </para>
	/// <para>Any file installation or service provider-specific configuration must be performed by the caller.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/nf-ws2spi-wscupdateprovider32 int WSCUpdateProvider32( LPGUID
	// lpProviderId, const WCHAR *lpszProviderDllPath, const LPWSAPROTOCOL_INFOW lpProtocolInfoList, DWORD dwNumberOfEntries, LPINT
	// lpErrno );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ws2spi.h", MSDNShortId = "803ef58a-853b-491c-bed1-e02275fef258")]
	public static extern WSRESULT WSCUpdateProvider32(in Guid lpProviderId, [MarshalAs(UnmanagedType.LPWStr)] string lpszProviderDllPath,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] WSAPROTOCOL_INFOW[] lpProtocolInfoList, uint dwNumberOfEntries, out int lpErrno);

	/// <summary>
	/// The <c>AFPROTOCOLS</c> structure supplies a list of protocols to which application programmers can constrain queries. The
	/// <c>AFPROTOCOLS</c> structure is used for query purposes only.
	/// </summary>
	/// <remarks>
	/// The members of the <c>AFPROTOCOLS</c> structure are a functional pair, and only have meaning when used together, as protocol
	/// values have meaning only within the context of an address family.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-afprotocols typedef struct _AFPROTOCOLS { INT
	// iAddressFamily; INT iProtocol; } AFPROTOCOLS, *PAFPROTOCOLS, *LPAFPROTOCOLS;
	[PInvokeData("winsock2.h", MSDNShortId = "ffd43aa1-bbc4-46f1-ad77-26c48f9ac0b7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AFPROTOCOLS
	{
		/// <summary>Address family to which the query is to be constrained.</summary>
		public int iAddressFamily;

		/// <summary>Protocol to which the query is to be constrained.</summary>
		public int iProtocol;
	}

	/// <summary>The <c>BLOB</c> structure, derived from Binary Large Object, contains information about a block of data.</summary>
	/// <remarks>
	/// <para>The structure name <c>BLOB</c> comes from the acronym BLOB, which stands for Binary Large Object.</para>
	/// <para>This structure does not describe the nature of the data pointed to by <c>pBlobData</c>.</para>
	/// <para>
	/// <c>Note</c> Windows Sockets defines a similar <c>BLOB</c> structure in Wtypes.h. Using both header files in the same source code
	/// file creates redefinition–compile time errors.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/nspapi/ns-nspapi-blob typedef struct _BLOB { ULONG cbSize; #if ... BYTE
	// *pBlobData; #else BYTE *pBlobData; #endif } BLOB, *LPBLOB;
	[PInvokeData("nspapi.h", MSDNShortId = "eb1ff7d1-79db-478f-9f3e-48507d333c76")]
	[StructLayout(LayoutKind.Sequential)]
	public struct BLOB
	{
		/// <summary>Size of the block of data pointed to by <c>pBlobData</c>, in bytes.</summary>
		public uint cbSize;

		/// <summary>Pointer to a block of data.</summary>
		public IntPtr pBlobData;
	}

	/// <summary>
	/// The <c>NSPV2_ROUTINE</c> structure contains information on the functions implemented by a namespace service provider version-2
	/// (NSPv2) provider.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>NSPV2_ROUTINE</c> structure is used as part of the namespace service provider version-2 (NSPv2) architecture available on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>NSPV2_ROUTINE</c> structure can only be used for operations on NS_EMAIL
	/// namespace providers.
	/// </para>
	/// <para>
	/// The WSAAdvertiseProvider function advertises an instance of a NSPv2 provider for clients to find. The
	/// <c>WSAAdvertiseProvider</c> caller passes a pointer to an <c>NSPV2_ROUTINE</c> structure in the pNSPv2Routine parameter with the
	/// NSPv2 entry points supported by the provider.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2spi/ns-ws2spi-nspv2_routine typedef struct _NSPV2_ROUTINE { DWORD cbSize;
	// DWORD dwMajorVersion; DWORD dwMinorVersion; LPNSPV2STARTUP NSPv2Startup; LPNSPV2CLEANUP NSPv2Cleanup; LPNSPV2LOOKUPSERVICEBEGIN
	// NSPv2LookupServiceBegin; LPNSPV2LOOKUPSERVICENEXTEX NSPv2LookupServiceNextEx; LPNSPV2LOOKUPSERVICEEND NSPv2LookupServiceEnd;
	// LPNSPV2SETSERVICEEX NSPv2SetServiceEx; LPNSPV2CLIENTSESSIONRUNDOWN NSPv2ClientSessionRundown; } NSPV2_ROUTINE, *PNSPV2_ROUTINE, *LPNSPV2_ROUTINE;
	[PInvokeData("ws2spi.h", MSDNShortId = "22a4ee47-030b-4aee-b9b1-c9e33b3e4fce")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NSPV2_ROUTINE
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the structure.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The major version of the service provider specification supported by this provider.</para>
		/// </summary>
		public uint dwMajorVersion;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The minor version of the service provider specification supported by this provider.</para>
		/// </summary>
		public uint dwMinorVersion;

		/// <summary>
		/// <para>Type: ** LPNSPV2STARTUP**</para>
		/// <para>A pointer to the NSPv2Startup function for this NSPv2 provider.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPNSPV2STARTUP NSPv2Startup;

		/// <summary>
		/// <para>Type: <c>LPNSPV2CLEANUP</c></para>
		/// <para>A pointer to the NSPv2Cleanup function for this NSPv2 provider.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPNSPV2CLEANUP NSPv2Cleanup;

		/// <summary>
		/// <para>Type: <c>LPNSPV2LOOKUPSERVICEBEGIN</c></para>
		/// <para>A pointer to the NSPv2LookupServiceBegin function for this NSPv2 provider.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPNSPV2LOOKUPSERVICEBEGIN NSPv2LookupServiceBegin;

		/// <summary>
		/// <para>Type: <c>LPNSPV2LOOKUPSERVICENEXTEX</c></para>
		/// <para>A pointer to the NSPv2LookupServiceNextEx function for this NSPv2 provider.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPNSPV2LOOKUPSERVICENEXTEX NSPv2LookupServiceNextEx;

		/// <summary>
		/// <para>Type: <c>LPNSPV2LOOKUPSERVICEEND</c></para>
		/// <para>A pointer to the NSPv2LookupServiceEnd function for this NSPv2 provider.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPNSPV2LOOKUPSERVICEEND NSPv2LookupServiceEnd;

		/// <summary>
		/// <para>Type: <c>LPNSPV2SETSERVICEEX</c></para>
		/// <para>A pointer to the NSPv2SetServiceEx function for this NSPv2 provider.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPNSPV2SETSERVICEEX NSPv2SetServiceEx;

		/// <summary>
		/// <para>Type: <c>LPNSPV2CLIENTSESSIONRUNDOWN</c></para>
		/// <para>A pointer to the NSPv2ClientSessionRundown function for this NSPv2 provider.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPNSPV2CLIENTSESSIONRUNDOWN NSPv2ClientSessionRundown;
	}

	public partial struct WSAEVENT
	{
		/// <summary>Represents an invalid event handle.</summary>
		public static WSAEVENT WSA_INVALID_EVENT => new(IntPtr.Zero);
	}

	/// <summary>The <c>WSANAMESPACE_INFOEX</c> structure contains all registration information for a namespace provider.</summary>
	/// <remarks>
	/// <para>
	/// The <c>WSANAMESPACE_INFOEX</c> structure is an enhanced version of the WSANAMESPACE_INFO structure that is used by the
	/// WSAEnumNameSpaceProvidersEx and the WSCEnumNameSpaceProvidersEx32 functions to return information on available namespace
	/// providers. The <c>WSANAMESPACE_INFOEX</c> structure contains the provider-specific data blob associated with the namespace entry
	/// passed in the lpProviderInfo parameter to the WSCInstallNameSpaceEx and WSCInstallNameSpaceEx32 functions.
	/// </para>
	/// <para>
	/// Currently, the only namespace included with Windows that uses information in the <c>ProviderSpecific</c> member of the
	/// <c>WSANAMESPACE_INFOEX</c> structure are namespace providers for the NS_EMAIL namespace. The format of the
	/// <c>ProviderSpecific</c> member for an NS_EMAIL namespace provider is a NAPI_PROVIDER_INSTALLATION_BLOB structure.
	/// </para>
	/// <para>
	/// When UNICODE or _UNICODE is defined, <c>WSANAMESPACE_INFOEX</c> is defined to <c>WSANAMESPACE_INFOEXW</c>, the Unicode version
	/// of this structure and the <c>lpszIdentifier</c> string member is defined to the <c>PWSTR</c> data type.
	/// </para>
	/// <para>
	/// When UNICODE or _UNICODE is not defined, <c>WSANAMESPACE_INFOEX</c> is defined to <c>WSANAMESPACE_INFOEXA</c>, the ANSI version
	/// of this structure and the <c>lpszIdentifier</c> string member is defined to the <c>PSTR</c> data type.
	/// </para>
	/// <para>The WSCEnumNameSpaceProvidersEx32 function is a Unicode only function and returns <c>WSANAMESPACE_INFOEXW</c> structures.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsanamespace_infoexw typedef struct _WSANAMESPACE_INFOEXW
	// { GUID NSProviderId; DWORD dwNameSpace; BOOL fActive; DWORD dwVersion; PWSTR lpszIdentifier; BLOB ProviderSpecific; }
	// WSANAMESPACE_INFOEXW, *PWSANAMESPACE_INFOEXW, *LPWSANAMESPACE_INFOEXW;
	[PInvokeData("winsock2.h", MSDNShortId = "3f4a8916-9db9-4b65-982f-4cb4ec2205ed")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WSANAMESPACE_INFOEXW
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>A unique GUID for this namespace provider.</para>
		/// </summary>
		public Guid NSProviderId;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The namespace supported by this provider.</para>
		/// <para>
		/// Possible values for the <c>dwNameSpace</c> member are listed in the Winsock2.h include file. Several namespace providers are
		/// included with Windows Vista and later. Other namespace providers can be installed, so the following possible values are only
		/// those commonly available. Many other values are possible.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NS_BTH</term>
		/// <term>The Bluetooth namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_DNS</term>
		/// <term>The domain name system (DNS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_EMAIL</term>
		/// <term>The email namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_NLA</term>
		/// <term>The network location awareness (NLA) namespace. This namespace identifier is supported on Windows XP and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_NTDS</term>
		/// <term>The Windows NT directory service (NTDS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPNAME</term>
		/// <term>
		/// The peer-to-peer name space for a specific peer name. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPCLOUD</term>
		/// <term>
		/// The peer-to-peer name space for a collection of peer names. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public NS dwNameSpace;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If <c>TRUE</c>, indicates that this namespace provider is active. If <c>FALSE</c>, the namespace provider is inactive and is
		/// not accessible for queries, even if the query specifically references this namespace provider.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fActive;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The version number of the namespace provider.</para>
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>A display string that identifies the namespace provider.</para>
		/// </summary>
		public PWSTR lpszIdentifier;

		/// <summary>
		/// <para>Type: <c>BLOB</c></para>
		/// <para>A provider-specific data blob associated with namespace entry.</para>
		/// </summary>
		public BLOB ProviderSpecific;
	}

	/// <summary>The <c>WSANAMESPACE_INFO</c> structure contains all registration information for a namespace provider.</summary>
	/// <remarks>
	/// <para>
	/// The <c>WSANAMESPACE_INFO</c> structure is used by the WSAEnumNameSpaceProvidersand WSCEnumNameSpaceProviders32 functions to
	/// return information on available namespace providers. The <c>WSANAMESPACE_INFO</c> structure contains the provider-specific
	/// information on the namespace entry passed to the WSCInstallNameSpace and WSCInstallNameSpace32 functions when the namespace
	/// provider was installed.
	/// </para>
	/// <para>
	/// When UNICODE or _UNICODE is defined, <c>WSANAMESPACE_INFO</c> is defined to <c>WSANAMESPACE_INFOW</c>, the Unicode version of
	/// this data structure and the <c>lpszIdentifier</c> string member is defined to the <c>PWSTR</c> data type.
	/// </para>
	/// <para>
	/// When UNICODE or _UNICODE is not defined, <c>WSANAMESPACE_INFO</c> is defined to <c>WSANAMESPACE_INFOA</c>, the ANSI version of
	/// this data structure and the <c>lpszIdentifier</c> string member is defined to the <c>PSTR</c> data type.
	/// </para>
	/// <para>
	/// On Windows Vista and later, WSANAMESPACE_INFOEX, an enhanced version of the <c>WSANAMESPACE_INFO</c> structure, is returned by
	/// calls to the WSAEnumNameSpaceProvidersEx and WSCEnumNameSpaceProvidersEx32 functions
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsanamespace_infow typedef struct _WSANAMESPACE_INFOW {
	// GUID NSProviderId; DWORD dwNameSpace; BOOL fActive; DWORD dwVersion; PWSTR lpszIdentifier; } WSANAMESPACE_INFOW,
	// *PWSANAMESPACE_INFOW, *LPWSANAMESPACE_INFOW;
	[PInvokeData("winsock2.h", MSDNShortId = "a5c76657-df62-471a-95e9-8017cad47b00")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WSANAMESPACE_INFOW
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>A unique GUID for this namespace provider.</para>
		/// </summary>
		public Guid NSProviderId;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The namespace supported by this provider.</para>
		/// <para>
		/// Possible values for the <c>dwNameSpace</c> member are listed in the Winsock2.h include file. Several namespace providers are
		/// included with Windows Vista and later. Other namespace providers can be installed, so the following possible values are only
		/// those commonly available. Many other values are possible.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NS_BTH</term>
		/// <term>The Bluetooth namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_DNS</term>
		/// <term>The domain name system (DNS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_EMAIL</term>
		/// <term>The email namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_NLA</term>
		/// <term>The network location awareness (NLA) namespace. This namespace identifier is supported on Windows XP and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_NTDS</term>
		/// <term>The Windows NT directory service (NTDS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPNAME</term>
		/// <term>
		/// The peer-to-peer name space for a specific peer name. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPCLOUD</term>
		/// <term>
		/// The peer-to-peer name space for a collection of peer names. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public NS dwNameSpace;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If <c>TRUE</c>, indicates that this namespace provider is active. If <c>FALSE</c>, the namespace provider is inactive and is
		/// not accessible for queries, even if the query specifically references this namespace provider.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fActive;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The version number of the namespace provider.</para>
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>A display string that identifies the namespace provider.</para>
		/// </summary>
		public PWSTR lpszIdentifier;
	}

	/// <summary>
	/// The <c>WSAOVERLAPPED</c> structure provides a communication medium between the initiation of an overlapped I/O operation and its
	/// subsequent completion. The <c>WSAOVERLAPPED</c> structure is compatible with the Windows OVERLAPPED structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsaoverlapped typedef struct _WSAOVERLAPPED { DWORD
	// Internal; DWORD InternalHigh; DWORD Offset; DWORD OffsetHigh; WSAEVENT hEvent; } WSAOVERLAPPED, *LPWSAOVERLAPPED;
	[PInvokeData("winsock2.h", MSDNShortId = "91004241-e0ea-4bda-a0f5-71688ac83038")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WSAOVERLAPPED
	{
		/// <summary>
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>
		/// Reserved for internal use. The Internal member is used internally by the entity that implements overlapped I/O. For service
		/// providers that create sockets as installable file system (IFS) handles, this parameter is used by the underlying operating
		/// system. Other service providers (non-IFS providers) are free to use this parameter as necessary.
		/// </para>
		/// </summary>
		public uint Internal;

		/// <summary>
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>
		/// Reserved. Used internally by the entity that implements overlapped I/O. For service providers that create sockets as IFS
		/// handles, this parameter is used by the underlying operating system. NonIFS providers are free to use this parameter as necessary.
		/// </para>
		/// </summary>
		public uint InternalHigh;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved for use by service providers.</para>
		/// </summary>
		public uint Offset;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved for use by service providers.</para>
		/// </summary>
		public uint OffsetHigh;

		/// <summary>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>
		/// If an overlapped I/O operation is issued without an I/O completion routine (the operation's lpCompletionRoutine parameter is
		/// set to null), then this parameter should either contain a valid handle to a WSAEVENT object or be null. If the
		/// lpCompletionRoutine parameter of the call is non-null then applications are free to use this parameter as necessary.
		/// </para>
		/// </summary>
		public WSAEVENT hEvent;
	}

	/// <summary>
	/// The <c>WSAPROTOCOL_INFOW</c> structure is used to store or retrieve complete information for a given protocol. The protocol name
	/// is represented as an array of Unicode characters.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsaprotocol_infow typedef struct _WSAPROTOCOL_INFOW {
	// DWORD dwServiceFlags1; DWORD dwServiceFlags2; DWORD dwServiceFlags3; DWORD dwServiceFlags4; DWORD dwProviderFlags; GUID
	// ProviderId; DWORD dwCatalogEntryId; WSAPROTOCOLCHAIN ProtocolChain; int iVersion; int iAddressFamily; int iMaxSockAddr; int
	// iMinSockAddr; int iSocketType; int iProtocol; int iProtocolMaxOffset; int iNetworkByteOrder; int iSecurityScheme; DWORD
	// dwMessageSize; DWORD dwProviderReserved; WCHAR szProtocol[WSAPROTOCOL_LEN + 1]; } WSAPROTOCOL_INFOW, *LPWSAPROTOCOL_INFOW;
	[PInvokeData("winsock2.h", MSDNShortId = "be5f3e81-1442-43c7-9e4e-9eb2b2a05132")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WSAPROTOCOL_INFOW
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A bitmask that describes the services provided by the protocol. The possible values for this member are defined in the
		/// Winsock2.h header file.
		/// </para>
		/// <para>The following values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>XP1_CONNECTIONLESS 0x00000001</term>
		/// <term>Provides connectionless (datagram) service. If not set, the protocol supports connection-oriented data transfer.</term>
		/// </item>
		/// <item>
		/// <term>XP1_GUARANTEED_DELIVERY 0x00000002</term>
		/// <term>Guarantees that all data sent will reach the intended destination.</term>
		/// </item>
		/// <item>
		/// <term>XP1_GUARANTEED_ORDER 0x00000004</term>
		/// <term>
		/// Guarantees that data only arrives in the order in which it was sent and that it is not duplicated. This characteristic does
		/// not necessarily mean that the data is always delivered, but that any data that is delivered is delivered in the order in
		/// which it was sent.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XP1_MESSAGE_ORIENTED 0x00000008</term>
		/// <term>Honors message boundaries—as opposed to a stream-oriented protocol where there is no concept of message boundaries.</term>
		/// </item>
		/// <item>
		/// <term>XP1_PSEUDO_STREAM 0x00000010</term>
		/// <term>
		/// A message-oriented protocol, but message boundaries are ignored for all receipts. This is convenient when an application
		/// does not desire message framing to be done by the protocol.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XP1_GRACEFUL_CLOSE 0x00000020</term>
		/// <term>Supports two-phase (graceful) close. If not set, only abortive closes are performed.</term>
		/// </item>
		/// <item>
		/// <term>XP1_EXPEDITED_DATA 0x00000040</term>
		/// <term>Supports expedited (urgent) data.</term>
		/// </item>
		/// <item>
		/// <term>XP1_CONNECT_DATA 0x00000080</term>
		/// <term>Supports connect data.</term>
		/// </item>
		/// <item>
		/// <term>XP1_DISCONNECT_DATA 0x00000100</term>
		/// <term>Supports disconnect data.</term>
		/// </item>
		/// <item>
		/// <term>XP1_SUPPORT_BROADCAST 0x00000200</term>
		/// <term>Supports a broadcast mechanism.</term>
		/// </item>
		/// <item>
		/// <term>XP1_SUPPORT_MULTIPOINT 0x00000400</term>
		/// <term>Supports a multipoint or multicast mechanism. Control and data plane attributes are indicated below.</term>
		/// </item>
		/// <item>
		/// <term>XP1_MULTIPOINT_CONTROL_PLANE 0x00000800</term>
		/// <term>Indicates whether the control plane is rooted (value = 1) or nonrooted (value = 0).</term>
		/// </item>
		/// <item>
		/// <term>XP1_MULTIPOINT_DATA_PLANE 0x00001000</term>
		/// <term>Indicates whether the data plane is rooted (value = 1) or nonrooted (value = 0).</term>
		/// </item>
		/// <item>
		/// <term>XP1_QOS_SUPPORTED 0x00002000</term>
		/// <term>Supports quality of service requests.</term>
		/// </item>
		/// <item>
		/// <term>XP1_INTERRUPT</term>
		/// <term>Bit is reserved.</term>
		/// </item>
		/// <item>
		/// <term>XP1_UNI_SEND 0x00008000</term>
		/// <term>Protocol is unidirectional in the send direction.</term>
		/// </item>
		/// <item>
		/// <term>XP1_UNI_RECV 0x00010000</term>
		/// <term>Protocol is unidirectional in the recv direction.</term>
		/// </item>
		/// <item>
		/// <term>XP1_IFS_HANDLES 0x00020000</term>
		/// <term>Socket descriptors returned by the provider are operating system Installable File System (IFS) handles.</term>
		/// </item>
		/// <item>
		/// <term>XP1_PARTIAL_MESSAGE 0x00040000</term>
		/// <term>The MSG_PARTIAL flag is supported in WSASend and WSASendTo.</term>
		/// </item>
		/// <item>
		/// <term>XP1_SAN_SUPPORT_SDP 0x00080000</term>
		/// <term>The protocol provides support for SAN. This value is supported on Windows 7 and Windows Server 2008 R2.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> Only one of XP1_UNI_SEND or XP1_UNI_RECV values may be set. If a protocol can be unidirectional in either
		/// direction, two <c>WSAPROTOCOL_INFOW</c> structures should be used. When neither bit is set, the protocol is considered to be bidirectional.
		/// </para>
		/// </summary>
		public XP1 dwServiceFlags1;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved for additional protocol-attribute definitions.</para>
		/// </summary>
		public uint dwServiceFlags2;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved for additional protocol-attribute definitions.</para>
		/// </summary>
		public uint dwServiceFlags3;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved for additional protocol-attribute definitions.</para>
		/// </summary>
		public uint dwServiceFlags4;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of flags that provides information on how this protocol is represented in the Winsock catalog. The possible values for
		/// this member are defined in the Winsock2.h header file.
		/// </para>
		/// <para>The following values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PFL_MULTIPLE_PROTO_ENTRIES 0x00000001</term>
		/// <term>
		/// Indicates that this is one of two or more entries for a single protocol (from a given provider) which is capable of
		/// implementing multiple behaviors. An example of this is SPX which, on the receiving side, can behave either as a
		/// message-oriented or a stream-oriented protocol.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PFL_RECOMMENDED_PROTO_ENTRY 0x00000002</term>
		/// <term>
		/// Indicates that this is the recommended or most frequently used entry for a protocol that is capable of implementing multiple behaviors.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PFL_HIDDEN 0x00000004</term>
		/// <term>
		/// Set by a provider to indicate to the Ws2_32.dll that this protocol should not be returned in the result buffer generated by
		/// WSAEnumProtocols. Obviously, a Windows Sockets 2 application should never see an entry with this bit set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PFL_MATCHES_PROTOCOL_ZERO 0x00000008</term>
		/// <term>Indicates that a value of zero in the protocol parameter of socket or WSASocket matches this protocol entry.</term>
		/// </item>
		/// <item>
		/// <term>PFL_NETWORKDIRECT_PROVIDER 0x00000010</term>
		/// <term>
		/// Set by a provider to indicate support for network direct access. This value is supported on Windows 7 and Windows Server
		/// 2008 R2.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PFL dwProviderFlags;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>
		/// A globally unique identifier (GUID) assigned to the provider by the service provider vendor. This value is useful for
		/// instances where more than one service provider is able to implement a particular protocol. An application can use the
		/// <c>ProviderId</c> member to distinguish between providers that might otherwise be indistinguishable.
		/// </para>
		/// </summary>
		public Guid ProviderId;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A unique identifier assigned by the WS2_32.DLL for each WSAPROTOCOL_INFO structure.</para>
		/// </summary>
		public uint dwCatalogEntryId;

		/// <summary>
		/// <para>Type: <c>WSAPROTOCOLCHAIN</c></para>
		/// <para>
		/// The WSAPROTOCOLCHAIN structure associated with the protocol. If the length of the chain is 0, this WSAPROTOCOL_INFO entry
		/// represents a layered protocol which has Windows Sockets 2 SPI as both its top and bottom edges. If the length of the chain
		/// equals 1, this entry represents a base protocol whose Catalog Entry identifier is in the <c>dwCatalogEntryId</c> member of
		/// the <c>WSAPROTOCOL_INFO</c> structure. If the length of the chain is larger than 1, this entry represents a protocol chain
		/// which consists of one or more layered protocols on top of a base protocol. The corresponding Catalog Entry identifiers are
		/// in the ProtocolChain.ChainEntries array starting with the layered protocol at the top (the zero element in the
		/// ProtocolChain.ChainEntries array) and ending with the base protocol. Refer to the Windows Sockets 2 Service Provider
		/// Interface specification for more information on protocol chains.
		/// </para>
		/// </summary>
		public WSAPROTOCOLCHAIN ProtocolChain;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The protocol version identifier.</para>
		/// </summary>
		public int iVersion;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// A value to pass as the address family parameter to the socket or WSASocket function in order to open a socket for this
		/// protocol. This value also uniquely defines the structure of a protocol address for a sockaddr used by the protocol.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the possible values for the address family are defined in the
		/// Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// On versions of the Platform SDK for Windows Server 2003 and older, the possible values for the address family are defined in
		/// the Winsock2.h header file.
		/// </para>
		/// <para>
		/// The values currently supported are AF_INET or AF_INET6, which are the Internet address family formats for IPv4 and IPv6.
		/// Other options for address family (AF_NETBIOS for use with NetBIOS, for example) are supported if a Windows Sockets service
		/// provider for the address family is installed. Note that the values for the AF_ address family and PF_ protocol family
		/// constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The table below lists common values for address family although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>iAddressFamily</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>The Internet Protocol version 4 (IPv4) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_IPX 6</term>
		/// <term>
		/// The IPX/SPX address family. This address family is only supported if the NWLink IPX/SPX NetBIOS Compatible Transport
		/// protocol is installed. This address family is not supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_APPLETALK 16</term>
		/// <term>
		/// The AppleTalk address family. This address family is only supported if the AppleTalk protocol is installed. This address
		/// family is not supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_NETBIOS 17</term>
		/// <term>
		/// The NetBIOS address family. This address family is only supported if the Windows Sockets provider for NetBIOS is installed.
		/// The Windows Sockets provider for NetBIOS is supported on 32-bit versions of Windows. This provider is installed by default
		/// on 32-bit versions of Windows. The Windows Sockets provider for NetBIOS is not supported on 64-bit versions of windows
		/// including Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003, or Windows XP. The Windows Sockets provider
		/// for NetBIOS only supports sockets where the type parameter is set to SOCK_DGRAM. The Windows Sockets provider for NetBIOS is
		/// not directly related to the NetBIOS programming interface. The NetBIOS programming interface is not supported on Windows
		/// Vista, Windows Server 2008, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>The Internet Protocol version 6 (IPv6) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_IRDA 26</term>
		/// <term>
		/// The Infrared Data Association (IrDA) address family. This address family is only supported if the computer has an infrared
		/// port and driver installed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_BTH 32</term>
		/// <term>
		/// The Bluetooth address family. This address family is supported on Windows XP with SP2 or later if the computer has a
		/// Bluetooth adapter and driver installed.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public int iAddressFamily;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The maximum address length, in bytes.</para>
		/// </summary>
		public int iMaxSockAddr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The minimum address length, in bytes.</para>
		/// </summary>
		public int iMinSockAddr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// A value to pass as the socket type parameter to the socket or WSASocket function in order to open a socket for this
		/// protocol. Possible values for the socket type are defined in the Winsock2.h header file.
		/// </para>
		/// <para>The following table lists the possible values for the <c>iSocketType</c> member supported for Windows Sockets 2:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>iSocketType</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SOCK_STREAM 1</term>
		/// <term>
		/// A socket type that provides sequenced, reliable, two-way, connection-based byte streams with an OOB data transmission
		/// mechanism. This socket type uses the Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_DGRAM 2</term>
		/// <term>
		/// A socket type that supports datagrams, which are connectionless, unreliable buffers of a fixed (typically small) maximum
		/// length. This socket type uses the User Datagram Protocol (UDP) for the Internet address family (AF_INET or AF_INET6).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RAW 3</term>
		/// <term>
		/// A socket type that provides a raw socket that allows an application to manipulate the next upper-layer protocol header. To
		/// manipulate the IPv4 header, the IP_HDRINCL socket option must be set on the socket. To manipulate the IPv6 header, the
		/// IPV6_HDRINCL socket option must be set on the socket.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RDM 4</term>
		/// <term>
		/// A socket type that provides a reliable message datagram. An example of this type is the Pragmatic General Multicast (PGM)
		/// multicast protocol implementation in Windows, often referred to as reliable multicast programming. This value is only
		/// supported if the Reliable Multicast Protocol is installed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_SEQPACKET 5</term>
		/// <term>A socket type that provides a pseudo-stream packet based on datagrams.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SOCK iSocketType;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// A value to pass as the protocol parameter to the socket or WSASocket function in order to open a socket for this protocol.
		/// The possible options for the <c>iProtocol</c> member are specific to the address family and socket type specified.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, this member can be one of the values from the <c>IPPROTO</c>
		/// enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in
		/// Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// On versions of the Platform SDK for Windows Server 2003 and earlier, the possible values for the <c>iProtocol</c> member are
		/// defined in the Winsock2.h and Wsrm.h header files.
		/// </para>
		/// <para>The table below lists common values for the <c>iProtocol</c> although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>iProtocol</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IPPROTO_ICMP 1</term>
		/// <term>The Internet Control Message Protocol (ICMP). This value is supported on Windows XP and later.</term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_IGMP 2</term>
		/// <term>The Internet Group Management Protocol (IGMP). This value is supported on Windows XP and later.</term>
		/// </item>
		/// <item>
		/// <term>BTHPROTO_RFCOMM 3</term>
		/// <term>
		/// The Bluetooth Radio Frequency Communications (Bluetooth RFCOMM) protocol. This value is supported on Windows XP with SP2 or later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_TCP 6</term>
		/// <term>The Transmission Control Protocol (TCP).</term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_UDP 17</term>
		/// <term>The User Datagram Protocol (UDP).</term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_ICMPV6 58</term>
		/// <term>The Internet Control Message Protocol Version 6 (ICMPv6). This value is supported on Windows XP and later.</term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_RM 113</term>
		/// <term>
		/// The PGM protocol for reliable multicast. On the Windows SDK released for Windows Vista and later, this protocol is also
		/// called IPPROTO_PGM. This value is only supported if the Reliable Multicast Protocol is installed.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IPPROTO iProtocol;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The maximum value that may be added to <c>iProtocol</c> member when supplying a value for the protocol parameter to socket
		/// and WSASocket. Not all protocols allow a range of values. When this is the case <c>iProtocolMaxOffset</c> is zero.
		/// </para>
		/// </summary>
		public int iProtocolMaxOffset;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Currently these values are manifest constants (BIGENDIAN and LITTLEENDIAN) that indicate either big-endian or little-endian
		/// with the values 0 and 1 respectively.
		/// </para>
		/// </summary>
		public int iNetworkByteOrder;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The type of security scheme employed (if any). A value of SECURITY_PROTOCOL_NONE (0) is used for protocols that do not
		/// incorporate security provisions.
		/// </para>
		/// </summary>
		public int iSecurityScheme;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The maximum message size, in bytes, supported by the protocol. This is the maximum size that can be sent from any of the
		/// host's local interfaces. For protocols that do not support message framing, the actual maximum that can be sent to a given
		/// address may be less. There is no standard provision to determine the maximum inbound message size. The following special
		/// values are defined.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The protocol is stream-oriented and hence the concept of message size is not relevant.</term>
		/// </item>
		/// <item>
		/// <term>0x1</term>
		/// <term>
		/// The maximum outbound (send) message size is dependent on the underlying network MTU (maximum sized transmission unit) and
		/// hence cannot be known until after a socket is bound. Applications should use getsockopt to retrieve the value of
		/// SO_MAX_MSG_SIZE after the socket has been bound to a local address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>0xFFFFFFFF</term>
		/// <term>The protocol is message-oriented, but there is no maximum limit to the size of messages that may be transmitted.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwMessageSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved for use by service providers.</para>
		/// </summary>
		public uint dwProviderReserved;

		/// <summary>
		/// <para>Type: <c>WCHAR[WSAPROTOCOL_LEN+1]</c></para>
		/// <para>
		/// An array of Unicode characters that contains a human-readable name identifying the protocol, for example "MSAFD Tcpip
		/// [UDP/IP]". The maximum number of characters allowed is WSAPROTOCOL_LEN, which is defined to be 255.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string szProtocol;
	}

	/// <summary>
	/// The <c>WSAQUERYSET2</c> structure provides relevant information about a given service, including service class ID, service name
	/// , applicable namespace identifier and protocol information, as well as a set of transport addresses at which the service listens.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>WSAQUERYSET2</c> structure is used as part of the namespace service provider version-2 (NSPv2) architecture available on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// On Windows Vista and Windows Server 2008, the <c>WSAQUERYSET2</c> structure can only be used for operations on NS_EMAIL
	/// namespace providers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsaqueryset2w typedef struct _WSAQuerySet2W { DWORD
	// dwSize; PWSTR lpszServiceInstanceName; LPWSAVERSION lpVersion; PWSTR lpszComment; DWORD dwNameSpace; LPGUID lpNSProviderId;
	// PWSTR lpszContext; DWORD dwNumberOfProtocols; LPAFPROTOCOLS lpafpProtocols; PWSTR lpszQueryString; DWORD dwNumberOfCsAddrs;
	// LPCSADDR_INFO lpcsaBuffer; DWORD dwOutputFlags; LPBLOB lpBlob; } WSAQUERYSET2W, *PWSAQUERYSET2W, *LPWSAQUERYSET2W;
	[PInvokeData("winsock2.h", MSDNShortId = "ffe71de0-3561-481f-b81f-835c6c3a3ee4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WSAQUERYSET2W
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The size, in bytes, of the <c>WSAQUERYSET2</c> structure. This member is used as a versioning mechanism since the size of
		/// the <c>WSAQUERYSET2</c> structure may change on later versions of Windows.
		/// </para>
		/// </summary>
		public uint dwSize;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to an optional <c>NULL</c>-terminated string that contains service name. The semantics for using wildcards within
		/// the string are not defined, but can be supported by certain namespace providers.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string? lpszServiceInstanceName;

		/// <summary>
		/// <para>Type: <c>LPWSAVERSION</c></para>
		/// <para>
		/// A pointer to an optional desired version number of the namespace provider. This member provides version comparison semantics
		/// (that is, the version requested must match exactly, or version must be not less than the value supplied).
		/// </para>
		/// </summary>
		public IntPtr lpVersion;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>This member is ignored for queries.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string lpszComment;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A namespace identifier that determines which namespace providers are queried. Passing a specific namespace identifier will
		/// result in only namespace providers that support the specified namespace being queried. Specifying <c>NS_ALL</c> will result
		/// in all installed and active namespace providers being queried.
		/// </para>
		/// <para>
		/// Options for the <c>dwNameSpace</c> member are listed in the Winsock2.h include file. Several new namespace providers are
		/// included with Windows Vista and later. Other namespace providers can be installed, so the following possible values are only
		/// those commonly available. Many other values are possible.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NS_ALL</term>
		/// <term>All installed and active namespaces.</term>
		/// </item>
		/// <item>
		/// <term>NS_BTH</term>
		/// <term>The Bluetooth namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_DNS</term>
		/// <term>The domain name system (DNS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_EMAIL</term>
		/// <term>The email namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_NLA</term>
		/// <term>The network location awareness (NLA) namespace. This namespace identifier is supported on Windows XP and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPNAME</term>
		/// <term>
		/// The peer-to-peer name space for a specific peer name. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPCLOUD</term>
		/// <term>
		/// The peer-to-peer name space for a collection of peer names. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public NS dwNameSpace;

		/// <summary>
		/// <para>Type: <c>LPGUID</c></para>
		/// <para>
		/// A pointer to an optional GUID of a specific namespace provider to query in the case where multiple namespace providers are
		/// registered under a single namespace such as <c>NS_DNS</c>. Passing the GUID for a specific namespace provider will result in
		/// only the specified namespace provider being queried. The WSAEnumNameSpaceProviders and WSAEnumNameSpaceProvidersEx functions
		/// can be called to retrieve the GUID for a namespace provider.
		/// </para>
		/// </summary>
		public GuidPtr lpNSProviderId;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>A pointer to an optional starting point of the query in a hierarchical namespace.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string? lpszContext;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the protocol constraint array. This member can be zero.</para>
		/// </summary>
		public uint dwNumberOfProtocols;

		/// <summary>
		/// <para>Type: <c>LPAFPROTOCOLS</c></para>
		/// <para>A pointer to an optional array of AFPROTOCOLS structures. Only services that utilize these protocols will be returned.</para>
		/// </summary>
		public IntPtr lpafpProtocols;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to an optional <c>NULL</c>-terminated query string. Some namespaces, such as Whois++, support enriched SQL-like
		/// queries that are contained in a simple text string. This parameter is used to specify that string.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string? lpszQueryString;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>This member is ignored for queries.</para>
		/// </summary>
		public uint dwNumberOfCsAddrs;

		/// <summary>
		/// <para>Type: <c>LPCSADDR_INFO</c></para>
		/// <para>This member is ignored for queries.</para>
		/// </summary>
		public IntPtr lpcsaBuffer;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>This member is ignored for queries.</para>
		/// </summary>
		public uint dwOutputFlags;

		/// <summary>
		/// <para>Type: <c>LPBLOB</c></para>
		/// <para>
		/// An optional pointer to data that is used to query or set provider-specific namespace information. The format of this
		/// information is specific to the namespace provider.
		/// </para>
		/// </summary>
		public IntPtr lpBlob;
	}

	/// <summary>The <c>WSAVERSION</c> structure provides version comparison in Windows Sockets.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsaversion typedef struct _WSAVersion { DWORD dwVersion;
	// WSAECOMPARATOR ecHow; } WSAVERSION, *PWSAVERSION, *LPWSAVERSION;
	[PInvokeData("winsock2.h", MSDNShortId = "27af3b20-9460-466d-bc58-5e31e08bb6c8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WSAVERSION
	{
		/// <summary>Version of Windows Sockets.</summary>
		public uint dwVersion;

		/// <summary>WSAECOMPARATOR enumeration, used in the comparison.</summary>
		public WSAECOMPARATOR ecHow;
	}
}