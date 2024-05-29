using System.Collections;
using System.Collections.Generic;
using static Vanara.PInvoke.Ws2_32;
using DNS_STATUS = Vanara.PInvoke.Win32Error;
using IP4_ADDRESS = Vanara.PInvoke.Ws2_32.IN_ADDR;
using IP6_ADDRESS = Vanara.PInvoke.Ws2_32.IN6_ADDR;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from windns.h.</summary>
public static partial class DnsApi
{
	/// <summary>The <c>DNS_QUERY_COMPLETION_ROUTINE</c> callback is used to asynchronously return the results of a DNS query.</summary>
	/// <param name="pQueryContext">A pointer to a user context.</param>
	/// <param name="pQueryResults">A pointer to a DNS_QUERY_RESULT structure that contains the DNS query results from a call to DnsQueryEx.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nc-windns-dns_query_completion_routine DNS_QUERY_COMPLETION_ROUTINE
	// DnsQueryCompletionRoutine; void DnsQueryCompletionRoutine( PVOID pQueryContext, PDNS_QUERY_RESULT pQueryResults ) {...}
	[PInvokeData("windns.h", MSDNShortId = "35D78208-FFC1-48B0-8267-EE583DE2D783")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DNS_QUERY_COMPLETION_ROUTINE([In] IntPtr pQueryContext, ref DNS_QUERY_RESULT pQueryResults);

	/// <summary>
	/// <note type="important">Some information relates to a prerelease product which may be substantially modified before it's commercially
	/// released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</note>
	/// <para>
	/// DNS_QUERY_RAW_COMPLETION_ROUTINE is the function signature of an asynchronous callback function that you implement. The system calls
	/// your implementation with the results of a query that you initiated by calling DnsQueryRaw. The results contain both the parsed
	/// records and the raw result packet, to be passed on to later systems as desired. The result provides information about the server that
	/// provided the results.
	/// </para>
	/// <para>
	/// The system calls this callback on query completion if DnsQueryRaw returns DNS_REQUEST_PENDING; and it will indicate the results of
	/// the query if successful, or any failures or cancellations.
	/// </para>
	/// </summary>
	/// <param name="queryContext">
	/// <para>Type: _In_ <c>VOID*</c></para>
	/// <para>A pointer to the query context that was passed into DnsQueryRaw through the queryContext field of DNS_QUERY_RAW_REQUEST.</para>
	/// </param>
	/// <param name="queryResults">
	/// <para>Type: _Inout_ <c>DNS_QUERY_RAW_RESULT*</c></para>
	/// <para>
	/// A pointer to the results of the query. If this callback is made because of a query cancellation through DnsCancelQueryRaw, then the
	/// queryStatus field in queryResults will be set to <c>ERROR_CANCELLED</c>.
	/// </para>
	/// <para>If it's not NULL, then you must free the queryResults pointer by using DnsQueryRawResultFree.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/windns/nc-windns-dns_query_raw_completion_routine
	// DNS_QUERY_RAW_COMPLETION_ROUTINE DnsQueryRawCompletionRoutine; void DnsQueryRawCompletionRoutine( VOID *queryContext, DNS_QUERY_RAW_RESULT *queryResults ) {...}
	[PInvokeData("windns.h", MSDNShortId = "NC:windns.DNS_QUERY_RAW_COMPLETION_ROUTINE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void DNS_QUERY_RAW_COMPLETION_ROUTINE([In] IntPtr queryContext, [In, Out] IntPtr /*DNS_QUERY_RAW_RESULT*/ queryResults);

	/// <summary>Used to asynchronously return the results of a DNS-SD query.</summary>
	/// <param name="Status">A value that contains the status associated with this particular set of results.</param>
	/// <param name="pQueryContext">A pointer to the user context that was passed to DnsServiceBrowse.</param>
	/// <param name="pDnsRecord">
	/// A pointer to a DNS_RECORD structure that contains a list of records describing a discovered service on the network. If not
	/// <see langword="null"/>, then you are responsible for freeing the returned RR sets using DnsRecordListFree.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nc-windns-dns_service_browse_callback DNS_SERVICE_BROWSE_CALLBACK
	// DnsServiceBrowseCallback; void DnsServiceBrowseCallback( DWORD Status, PVOID pQueryContext, PDNS_RECORD pDnsRecord ) {...}
	[PInvokeData("windns.h")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DNS_SERVICE_BROWSE_CALLBACK(DNS_STATUS Status, [In] IntPtr pQueryContext, IntPtr pDnsRecord);

	/// <summary>Used to notify your application that service registration has completed.</summary>
	/// <param name="Status">A value that contains the status of the registration.</param>
	/// <param name="pQueryContext">A pointer to the user context that was passed to DnsServiceRegister.</param>
	/// <param name="pInstance">
	/// A pointer to a DNS_SERVICE_INSTANCE structure that describes the service that was registered. If not , then you are responsible
	/// for freeing the data using DnsServiceFreeInstance.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nc-windns-dns_service_register_complete DNS_SERVICE_REGISTER_COMPLETE
	// DnsServiceRegisterComplete; void DnsServiceRegisterComplete( DWORD Status, PVOID pQueryContext, PDNS_SERVICE_INSTANCE pInstance ) {...}
	[PInvokeData("windns.h")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DNS_SERVICE_REGISTER_COMPLETE(DNS_STATUS Status, [In] IntPtr pQueryContext, [In] IntPtr pInstance);

	/// <summary>Used to asynchronously return the results of a service resolve operation.</summary>
	/// <param name="Status">A value that contains the status associated with this particular set of results.</param>
	/// <param name="pQueryContext">A pointer to the user context that was passed to DnsServiceResolve.</param>
	/// <param name="pInstance">
	/// A pointer to a DNS_SERVICE_INSTANCE structure that contains detailed information about a service on the network. If not
	/// <see langword="null"/>, then you are responsible for freeing the data using DnsServiceFreeInstance.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nc-windns-dns_service_resolve_complete DNS_SERVICE_RESOLVE_COMPLETE
	// DnsServiceResolveComplete; void DnsServiceResolveComplete( DWORD Status, PVOID pQueryContext, PDNS_SERVICE_INSTANCE pInstance ) {...}
	[PInvokeData("windns.h")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DNS_SERVICE_RESOLVE_COMPLETE(DNS_STATUS Status, [In] IntPtr pQueryContext, [In] IntPtr pInstance);

	/// <summary>Used to asynchronously return the results of an mDNS query.</summary>
	/// <param name="pQueryContext">A pointer to the user context that was passed to DnsServiceBrowse.</param>
	/// <param name="pQueryHandle">A pointer to the MDNS_QUERY_HANDLE structure that was passed to DnsStartMulticastQuery.</param>
	/// <param name="pQueryResults">
	/// A pointer to a DNS_QUERY_RESULT structure that contains the query results. Your application is responsible for freeing the
	/// contained in this structure using DnsRecordListFree.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nc-windns-mdns_query_callback MDNS_QUERY_CALLBACK MdnsQueryCallback;
	// void MdnsQueryCallback( PVOID pQueryContext, PMDNS_QUERY_HANDLE pQueryHandle, PDNS_QUERY_RESULT pQueryResults ) {...}
	[PInvokeData("windns.h")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void MDNS_QUERY_CALLBACK(IntPtr pQueryContext, IntPtr pQueryHandle, IntPtr pQueryResults);

	/// <summary>Byte flip DNS header to\from host order.</summary>
	/// <param name="mBuf">The DNS_MESSAGE_BUFFER instance whose values are to be flipped.</param>
	[PInvokeData("windns.h")]
	public static void DNS_BYTE_FLIP_HEADER_COUNTS(ref DNS_MESSAGE_BUFFER mBuf)
	{
		INLINE_HTONS(ref mBuf.MessageHead.Xid);
		INLINE_HTONS(ref mBuf.MessageHead.QuestionCount);
		INLINE_HTONS(ref mBuf.MessageHead.AnswerCount);
		INLINE_HTONS(ref mBuf.MessageHead.NameServerCount);
		INLINE_HTONS(ref mBuf.MessageHead.AdditionalCount);

		static void INLINE_HTONS(ref ushort value) => value = (ushort)((value << 8) | (value >> 8));
	}

	/// <summary>
	/// <para>
	/// The <c>DnsAcquireContextHandle</c> function type acquires a context handle to a set of credentials. Like many DNS functions, the
	/// <c>DnsAcquireContextHandle</c> function type is implemented in multiple forms to facilitate different character encoding. Based
	/// on the character encoding involved, use one of the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>DnsAcquireContextHandle_A</c> (_A for ANSI encoding)</term>
	/// </item>
	/// <item>
	/// <term><c>DnsAcquireContextHandle_W</c> (_W for Unicode encoding)</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <param name="CredentialFlags">
	/// A flag that indicates the character encoding. Set to <c>TRUE</c> for Unicode, <c>FALSE</c> for ANSI.
	/// </param>
	/// <param name="Credentials">
	/// A pointer to a SEC_WINNT_AUTH_IDENTITY_W structure or a <c>SEC_WINNT_AUTH_IDENTITY_A</c> structure that contains the name,
	/// domain, and password of the account to be used in a secure dynamic update. If CredentialFlags is set to <c>TRUE</c>, Credentials
	/// points to a <c>SEC_WINNT_AUTH_IDENTITY_W</c> structure; otherwise, Credentials points to a <c>SEC_WINNT_AUTH_IDENTITY_A</c>
	/// structure. If not specified, the credentials of the calling service are used. This parameter is optional.
	/// </param>
	/// <param name="pContext">A pointer to a handle pointing to the returned credentials.</param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, returns the appropriate DNS-specific error code as defined
	/// in Winerror.h.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsacquirecontexthandle_w DNS_STATUS
	// DnsAcquireContextHandle_W( DWORD CredentialFlags, PVOID Credentials, PHANDLE pContext );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsAcquireContextHandle_W", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "9a820165-2f78-44f4-b49f-dc7a2b6fb4e5")]
	public static extern DNS_STATUS DnsAcquireContextHandle([MarshalAs(UnmanagedType.Bool)] bool CredentialFlags,
		[In, Optional] IntPtr Credentials, out SafeHDNSCONTEXT pContext);

	/// <summary>The <c>DnsCancelQuery</c> function can be used to cancel a pending query to the DNS namespace.</summary>
	/// <param name="pCancelHandle">
	/// A pointer to a DNS_QUERY_CANCEL structure used to cancel an asynchronous DNS query. The structure must have been returned in the
	/// pCancelHandle parameter of a previous call to DnsQueryEx.
	/// </param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, it returns the appropriate DNS-specific error code as
	/// defined in Winerror.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>DnsCancelQuery</c> does not wait for a query to complete before cancelling. Therefore, applications should track pending
	/// queries through their DNS_QUERY_COMPLETION_ROUTINE DNS callbacks.
	/// </para>
	/// <para>pCancelHandle is valid until the DNS_QUERY_COMPLETION_ROUTINE DNS callback is invoked and <c>DnsCancelQuery</c> completes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnscancelquery DNS_STATUS DnsCancelQuery( PDNS_QUERY_CANCEL
	// pCancelHandle );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "E5F422AA-D4E6-4F9F-A57C-608CE9317658")]
	public static extern DNS_STATUS DnsCancelQuery(ref DNS_QUERY_CANCEL pCancelHandle);

	/// <summary>
	/// <note type="important"> Some information relates to a prerelease product which may be substantially modified before it's commercially
	/// released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</note>
	/// <para>Cancels a query that was initiated by calling DnsQueryRaw.</para>
	/// <para>
	/// If the query completion callback (see DNS_QUERY_RAW_COMPLETION_ROUTINE) hasn't been called by the time DnsCancelQueryRaw returns,
	/// then the query completion callback will lead to the callback being made with a queryStatus of ERROR_CANCELLED in the queryResults parameter.
	/// </para>
	/// </summary>
	/// <param name="cancelHandle">
	/// <para>Type: _In_ <c>DNS_QUERY_RAW_CANCEL*</c></para>
	/// <para>The cancel handle that you obtained by calling DnsQueryRaw.</para>
	/// </param>
	/// <returns>A <c>DNS_STATUS</c> value indicating success or failure.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnscancelqueryraw
	// DNS_STATUS DnsCancelQueryRaw( DNS_QUERY_RAW_CANCEL *cancelHandle );
	[PInvokeData("windns.h", MSDNShortId = "NF:windns.DnsCancelQueryRaw")]
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	public static extern DNS_STATUS DnsCancelQueryRaw(in DNS_QUERY_RAW_CANCEL cancelHandle);

	/// <summary>
	/// The <c>DnsExtractRecordsFromMessage</c> function type extracts resource records (RR) from a DNS message, and stores those
	/// records in a DNS_RECORD structure. Like many DNS functions, the <c>DnsExtractRecordsFromMessage</c> function type is implemented
	/// in multiple forms to facilitate different character encoding.
	/// </summary>
	/// <param name="pDnsBuffer">A pointer to a DNS_MESSAGE_BUFFER structure that contains the DNS response message.</param>
	/// <param name="wMessageLength">The size, in bytes, of the message in pDnsBuffer.</param>
	/// <param name="ppRecord">
	/// A pointer to a DNS_RECORD structure that contains the list of extracted RRs. To free these records, use the DnsRecordListFree function.
	/// </param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, returns the appropriate DNS-specific error code as defined
	/// in Winerror.h.
	/// </returns>
	/// <remarks>
	/// The <c>DnsExtractRecordsFromMessage</c> function is designed to operate on messages in host byte order. As such, received
	/// messages should be converted from network byte order to host byte order before extraction, or before retransmission onto the
	/// network. Use the DNS_BYTE_FLIP_HEADER_COUNTS macro to change byte ordering.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsextractrecordsfrommessage_w DNS_STATUS
	// DnsExtractRecordsFromMessage_W( PDNS_MESSAGE_BUFFER pDnsBuffer, WORD wMessageLength, PDNS_RECORD *ppRecord );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsExtractRecordsFromMessage_W", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "0179bf3e-9243-4dd7-a2ab-e2f6f4bf4b82")]
	public static extern DNS_STATUS DnsExtractRecordsFromMessage([In] IntPtr pDnsBuffer, ushort wMessageLength,
		out SafeDnsRecordList ppRecord);

	/// <summary>The <c>DnsFree</c> function frees memory allocated for DNS records that was obtained using the DnsQuery function.</summary>
	/// <param name="pData">A pointer to the DNS data to be freed.</param>
	/// <param name="FreeType">
	/// A value that specifies the type of DNS data in pData. For more information and a list of values, see the DNS_FREE_TYPE enumeration.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsfree void DnsFree( _Frees_ptr_opt_ PVOID pData,
	// DNS_FREE_TYPE FreeType );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "32baa672-2106-4c4a-972a-f7f79996b613")]
	public static extern void DnsFree(IntPtr pData, DNS_FREE_TYPE FreeType);

	/// <summary>Frees an array of custom servers that was returned from <see cref="DnsGetApplicationSettings(out uint, out IntPtr, out DNS_APPLICATION_SETTINGS)"/>.</summary>
	/// <param name="pcServers">
	/// <para>Type: _Inout_ <c>DWORD*</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the number of servers present in the array pointed to by ppServers. This will be set
	/// to 0 after the function call.
	/// </para>
	/// </param>
	/// <param name="ppServers">
	/// <para>Type: _Inout_ <c>DNS_CUSTOM_SERVER**</c></para>
	/// <para>
	/// A pointer to an array of DNS_CUSTOM_SERVER that contains pcServers elements. This will be set to <c>NULL</c> after the function call.
	/// </para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// To avoid memory leaks, you must call <c>DnsFreeCustomServers</c> on the servers returned by DnsGetApplicationSettings via its
	/// pSettings parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsfreecustomservers
	// void DnsFreeCustomServers( DWORD *pcServers, DNS_CUSTOM_SERVER **ppServers );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "NF:windns.DnsFreeCustomServers", MinClient = PInvokeClient.Windows11)]
	public static extern void DnsFreeCustomServers(ref uint pcServers, ref IntPtr ppServers);

	/// <summary>
	/// The <c>DnsFreeProxyName</c> function frees memory allocated for the <c>proxyName</c> member of a DNS_PROXY_INFORMATION structure
	/// obtained using the DnsGetProxyInformation function.
	/// </summary>
	/// <param name="proxyName">A pointer to the <c>proxyName</c> string to be freed.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsfreeproxyname void DnsFreeProxyName( _Frees_ptr_opt_ PWSTR
	// proxyName );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "4c69d548-3bb5-4609-9fc5-3a829a285956")]
	public static extern void DnsFreeProxyName(IntPtr proxyName);

	/// <summary>Retrieves the per-application DNS settings.</summary>
	/// <param name="pcServers">
	/// <para>Type: _Out_ <c>DWORD*</c></para>
	/// <para>
	/// After the function call, this will point to the number of custom DNS servers that the application has configured. If there are
	/// no custom servers configured, or if the function fails, then this will be set to 0.
	/// </para>
	/// </param>
	/// <param name="ppDefaultServers">
	/// <para>Type: _Outptr_result_buffer_(*pcServers) <c>DNS_CUSTOM_SERVER**</c></para>
	/// <para>
	/// After the function call, this will point to the array of DNS custom servers that are configured for the application. If the
	/// application has no servers configured, or if the function fails, then this will be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pSettings">
	/// <para>Type: _Out_opt_ <c>DNS_APPLICATION_SETTINGS*</c></para>
	/// <para>A pointer to a DNS_APPLICATION_SETTINGS object, populated with the application settings.</para>
	/// </param>
	/// <returns>A <c>DWORD</c> containing <c>ERROR_SUCCESS</c> on success, or an error code on failure.</returns>
	/// <remarks>
	/// To avoid memory leaks, you must call DnsFreeCustomServers on the servers returned by <c>DnsGetApplicationSettings</c> via its
	/// pSettings parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsgetapplicationsettings
	// DWORD DnsGetApplicationSettings( DWORD *pcServers, DNS_CUSTOM_SERVER **ppDefaultServers, DNS_APPLICATION_SETTINGS *pSettings );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "NF:windns.DnsGetApplicationSettings", MinClient = PInvokeClient.Windows11)]
	public static extern DNS_STATUS DnsGetApplicationSettings(out uint pcServers, out IntPtr ppDefaultServers,
		out DNS_APPLICATION_SETTINGS pSettings);

	/// <summary>Retrieves the per-application DNS settings.</summary>
	/// <param name="ppDefaultServers">
	/// After the function call, this will point to the array of DNS custom servers that are configured for the application. If the
	/// application has no servers configured, or if the function fails, then this will be set to <c>NULL</c>.
	/// </param>
	/// <param name="pSettings">A pointer to a DNS_APPLICATION_SETTINGS object, populated with the application settings.</param>
	/// <returns>A <c>DWORD</c> containing <c>ERROR_SUCCESS</c> on success, or an error code on failure.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsgetapplicationsettings
	// DWORD DnsGetApplicationSettings( DWORD *pcServers, DNS_CUSTOM_SERVER **ppDefaultServers, DNS_APPLICATION_SETTINGS *pSettings );
	[PInvokeData("windns.h", MSDNShortId = "NF:windns.DnsGetApplicationSettings", MinClient = PInvokeClient.Windows11)]
	public static DNS_STATUS DnsGetApplicationSettings(out DNS_CUSTOM_SERVER[]? ppDefaultServers, out DNS_APPLICATION_SETTINGS pSettings)
	{
		var err = DnsGetApplicationSettings(out var c, out var p, out pSettings);
		if (err.Failed) { ppDefaultServers = null; return err; }
		try
		{
			ppDefaultServers = p.ToArray<DNS_CUSTOM_SERVER>((int)c);
		}
		finally
		{
			DnsFreeCustomServers(ref c, ref p);
		}
		return err;
	}

	/// <summary>Gets a list of cached domain names in the DNS client.</summary>
	/// <param name="ppCacheData">The cached data list.</param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, returns the appropriate DNS-specific error code as defined
	/// in Winerror.h.
	/// </returns>
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DnsGetCacheDataTable(out SafeDnsCacheDataTable ppCacheData);

	/// <summary>
	/// The <c>DnsGetProxyInformation</c> function returns the proxy information for a DNS server's name resolution policy table.
	/// </summary>
	/// <param name="hostName">A pointer to a string that represents the name of the DNS server whose proxy information is returned.</param>
	/// <param name="proxyInformation">A pointer to a DNS_PROXY_INFORMATION structure that contains the proxy information for hostName.</param>
	/// <param name="defaultProxyInformation">
	/// A pointer to a DNS_PROXY_INFORMATION structure that contains the default proxy information for hostName. This proxy information
	/// is for the wildcard DNS policy.
	/// </param>
	/// <param name="completionRoutine">Reserved. Do not use.</param>
	/// <param name="completionContext">Reserved. Do not use.</param>
	/// <returns>
	/// The <c>DnsGetProxyInformation</c> function returns the appropriate DNS-specific error code as defined in Winerror.h. The
	/// following are possible return values:
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsgetproxyinformation DWORD DnsGetProxyInformation( PCWSTR
	// hostName, DNS_PROXY_INFORMATION *proxyInformation, DNS_PROXY_INFORMATION *defaultProxyInformation, DNS_PROXY_COMPLETION_ROUTINE
	// completionRoutine, void *completionContext );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "fdc8eb09-e071-4f03-974a-2b11a657ab18")]
	public static extern DNS_STATUS DnsGetProxyInformation([MarshalAs(UnmanagedType.LPWStr)] string hostName,
		ref DNS_PROXY_INFORMATION proxyInformation, ref DNS_PROXY_INFORMATION defaultProxyInformation,
		IntPtr completionRoutine = default, IntPtr completionContext = default);

	/// <summary>
	/// The <c>DnsGetProxyInformation</c> function returns the proxy information for a DNS server's name resolution policy table.
	/// </summary>
	/// <param name="hostName">A pointer to a string that represents the name of the DNS server whose proxy information is returned.</param>
	/// <param name="proxyInformation">A pointer to a DNS_PROXY_INFORMATION structure that contains the proxy information for hostName.</param>
	/// <param name="defaultProxyInformation">
	/// A pointer to a DNS_PROXY_INFORMATION structure that contains the default proxy information for hostName. This proxy information
	/// is for the wildcard DNS policy.
	/// </param>
	/// <param name="completionRoutine">Reserved. Do not use.</param>
	/// <param name="completionContext">Reserved. Do not use.</param>
	/// <returns>
	/// The <c>DnsGetProxyInformation</c> function returns the appropriate DNS-specific error code as defined in Winerror.h. The
	/// following are possible return values:
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsgetproxyinformation DWORD DnsGetProxyInformation( PCWSTR
	// hostName, DNS_PROXY_INFORMATION *proxyInformation, DNS_PROXY_INFORMATION *defaultProxyInformation, DNS_PROXY_COMPLETION_ROUTINE
	// completionRoutine, void *completionContext );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "fdc8eb09-e071-4f03-974a-2b11a657ab18")]
	public static extern DNS_STATUS DnsGetProxyInformation([MarshalAs(UnmanagedType.LPWStr)] string hostName,
		ref DNS_PROXY_INFORMATION proxyInformation, IntPtr defaultProxyInformation = default,
		IntPtr completionRoutine = default, IntPtr completionContext = default);

	/// <summary>
	/// The <c>DnsModifyRecordsInSet</c> function adds, modifies or removes a Resource Record (RR) set that may have been previously
	/// registered with DNS servers.
	/// </summary>
	/// <param name="pAddRecords">A pointer to the DNS_RECORD structure that contains the RRs to be added to the RR set.</param>
	/// <param name="pDeleteRecords">A pointer to the DNS_RECORD structure that contains the RRs to be deleted from the RR set.</param>
	/// <param name="Options">
	/// A value that contains a bitmap of DNS Update Options. Options can be combined and all options override <c>DNS_UPDATE_SECURITY_USE_DEFAULT</c>.
	/// </param>
	/// <param name="hCredentials">
	/// A handle to the credentials of a specific account. Used when secure dynamic update is required. This parameter is optional.
	/// </param>
	/// <param name="pExtraList">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pReserved">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, it returns the appropriate DNS-specific error code as
	/// defined in Winerror.h.
	/// </returns>
	/// <remarks>
	/// <para>The <c>DnsModifyRecordsInSet</c> function type executes in the following steps.</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Records specified in pDeleteRecords are deleted. If pDeleteRecords is empty or does not contain records that exist in the
	/// current set, the <c>DnsModifyRecordsInSet</c> function goes to the next step.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Records specified in pAddRecords are added. If pAddRecords is empty, the operation completes without adding any records.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To add a new record, provide no records in pDeleteRecords, and provide the record to be added in pAddRecords. To modify a
	/// record, specify the record being modified in pDeleteRecords, then add the modified version of that record by placing it in
	/// pAddRecords. To delete records, specify only records to be deleted. Multiple records can be added or deleted in a single call to
	/// <c>DnsModifyRecordsInSet</c>; however, the value of the <c>pName</c> member in each DNS_RECORD must be the same or the call will
	/// fail. If a record specified in pAddRecords is already present, no change occurs.
	/// </para>
	/// <para>If no server list is specified, the default name server is queried.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsmodifyrecordsinset_a DNS_STATUS DnsModifyRecordsInSet_A(
	// PDNS_RECORD pAddRecords, PDNS_RECORD pDeleteRecords, DWORD Options, HANDLE hCredentials, PVOID pExtraList, PVOID pReserved );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsModifyRecordsInSet_W", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "4287b4e1-a7a2-4b73-b5bb-21bc639bae73")]
	public static extern DNS_STATUS DnsModifyRecordsInSet(in DNS_RECORD pAddRecords, in DNS_RECORD pDeleteRecords,
		DNS_UPDATE Options, [Optional] IntPtr hCredentials, [In, Out, Optional] IntPtr pExtraList, IntPtr pReserved = default);

	/// <summary>
	/// The <c>DnsModifyRecordsInSet</c> function adds, modifies or removes a Resource Record (RR) set that may have been previously
	/// registered with DNS servers.
	/// </summary>
	/// <param name="pAddRecords">A pointer to the DNS_RECORD structure that contains the RRs to be added to the RR set.</param>
	/// <param name="pDeleteRecords">A pointer to the DNS_RECORD structure that contains the RRs to be deleted from the RR set.</param>
	/// <param name="Options">
	/// A value that contains a bitmap of DNS Update Options. Options can be combined and all options override <c>DNS_UPDATE_SECURITY_USE_DEFAULT</c>.
	/// </param>
	/// <param name="hCredentials">
	/// A handle to the credentials of a specific account. Used when secure dynamic update is required. This parameter is optional.
	/// </param>
	/// <param name="pExtraList">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pReserved">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, it returns the appropriate DNS-specific error code as
	/// defined in Winerror.h.
	/// </returns>
	/// <remarks>
	/// <para>The <c>DnsModifyRecordsInSet</c> function type executes in the following steps.</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Records specified in pDeleteRecords are deleted. If pDeleteRecords is empty or does not contain records that exist in the
	/// current set, the <c>DnsModifyRecordsInSet</c> function goes to the next step.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Records specified in pAddRecords are added. If pAddRecords is empty, the operation completes without adding any records.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To add a new record, provide no records in pDeleteRecords, and provide the record to be added in pAddRecords. To modify a
	/// record, specify the record being modified in pDeleteRecords, then add the modified version of that record by placing it in
	/// pAddRecords. To delete records, specify only records to be deleted. Multiple records can be added or deleted in a single call to
	/// <c>DnsModifyRecordsInSet</c>; however, the value of the <c>pName</c> member in each DNS_RECORD must be the same or the call will
	/// fail. If a record specified in pAddRecords is already present, no change occurs.
	/// </para>
	/// <para>If no server list is specified, the default name server is queried.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsmodifyrecordsinset_a DNS_STATUS DnsModifyRecordsInSet_A(
	// PDNS_RECORD pAddRecords, PDNS_RECORD pDeleteRecords, DWORD Options, HANDLE hCredentials, PVOID pExtraList, PVOID pReserved );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsModifyRecordsInSet_W", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "4287b4e1-a7a2-4b73-b5bb-21bc639bae73")]
	public static extern DNS_STATUS DnsModifyRecordsInSet([In] IntPtr pAddRecords, [In] IntPtr pDeleteRecords,
		DNS_UPDATE Options, [Optional] IntPtr hCredentials, [In, Out, Optional] IntPtr pExtraList, IntPtr pReserved = default);

	/// <summary>The <c>DnsNameCompare</c> function compares two DNS names.</summary>
	/// <param name="pName1"/>
	/// <param name="pName2"/>
	/// <returns>Returns <c>TRUE</c> if the compared names are equivalent, <c>FALSE</c> if they are not.</returns>
	/// <remarks>
	/// <para>Name comparisons are not case sensitive, and trailing dots are ignored.</para>
	/// <para>
	/// As with other DNS comparison functions, the <c>DnsNameCompare</c> function deems different encoding as an immediate indication
	/// of differing values, and as such, the same names with different characters encoding will not be reported identically.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsnamecompare_w BOOL DnsNameCompare_W( PCWSTR pName1, PCWSTR
	// pName2 );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsNameCompare_W", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "4a1512b3-8273-4632-9426-daa36456bce3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DnsNameCompare(string pName1, string pName2);

	/// <summary>
	/// <para>
	/// The <c>DnsQuery</c> function type is the generic query interface to the DNS namespace, and provides application developers with
	/// a DNS query resolution interface.
	/// </para>
	/// <para>Windows 8: The DnsQueryEx function should be used if an application requires asynchronous querries to the DNS namespace.</para>
	/// </summary>
	/// <param name="pszName">A pointer to a string that represents the DNS name to query.</param>
	/// <param name="wType">
	/// A value that represents the Resource Record (RR)DNS Record Type that is queried. <c>wType</c> determines the format of data
	/// pointed to by <c>ppQueryResultsSet</c>. For example, if the value of <c>wType</c> is <c>DNS_TYPE_A</c>, the format of data
	/// pointed to by <c>ppQueryResultsSet</c> is DNS_A_DATA.
	/// </param>
	/// <param name="Options">
	/// A value that contains a bitmap of DNS Query Options to use in the DNS query. Options can be combined and all options override <c>DNS_QUERY_STANDARD</c>.
	/// </param>
	/// <param name="pExtra">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="ppQueryResults">
	/// Optional. A pointer to a pointer that points to the list of RRs that comprise the response. For more information, see the
	/// Remarks section.
	/// </param>
	/// <param name="pReserved">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, returns the appropriate DNS-specific error code as defined
	/// in Winerror.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Applications that call the <c>DnsQuery</c> function build a query using a fully qualified DNS name and Resource Record (RR)
	/// type, and set query options depending on the type of service desired. When the <c>DNS_QUERY_STANDARD</c> option is set, DNS uses
	/// the resolver cache, queries first with UDP, then retries with TCP if the response is truncated, and requests that the server to
	/// perform recursive resolution on behalf of the client to resolve the query.
	/// </para>
	/// <para>Applications must free returned RR sets with the DnsRecordListFree function.</para>
	/// <para>
	/// <c>Note</c> When calling one of the <c>DnsQuery</c> function types, be aware that a DNS server may return multiple records in
	/// response to a query. A computer that is multihomed, for example, will receive multiple A records for the same IP address. The
	/// caller must use as many of the returned records as necessary.
	/// </para>
	/// <para>
	/// Consider the following scenario, in which multiple returned records require additional activity on behalf of the application: A
	/// <c>DnsQuery_A</c> function call is made for a multihomed computer and the application finds that the address associated with the
	/// first A record is not responding. The application should then attempt to use other IP addresses specified in the (additional) A
	/// records returned from the <c>DnsQuery_A</c> function call.
	/// </para>
	/// <para>If the lpstrName parameter is set to <c>NULL</c>, the <c>DnsQuery</c> function fails with the error <c>INVALID_PARAMETER</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsquery_a DNS_STATUS DnsQuery_A( PCSTR pszName, WORD wType,
	// DWORD Options, PVOID pExtra, PDNS_RECORD *ppQueryResults, PVOID *pReserved );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "3d810b76-cea1-4904-9b5a-c2566b332c2c")]
	public static extern DNS_STATUS DnsQuery(string pszName, DNS_TYPE wType, DNS_QUERY_OPTIONS Options,
		[In, Out, Optional] IntPtr pExtra, out SafeDnsRecordList ppQueryResults, IntPtr pReserved = default);

	/// <summary>
	/// <para>
	/// The <c>DnsQuery</c> function type is the generic query interface to the DNS namespace, and provides application developers with
	/// a DNS query resolution interface.
	/// </para>
	/// <para>Windows 8: The DnsQueryEx function should be used if an application requires asynchronous querries to the DNS namespace.</para>
	/// </summary>
	/// <param name="pszName">A pointer to a string that represents the DNS name to query.</param>
	/// <param name="wType">
	/// A value that represents the Resource Record (RR)DNS Record Type that is queried. <c>wType</c> determines the format of data
	/// pointed to by <c>ppQueryResultsSet</c>. For example, if the value of <c>wType</c> is <c>DNS_TYPE_A</c>, the format of data
	/// pointed to by <c>ppQueryResultsSet</c> is DNS_A_DATA.
	/// </param>
	/// <param name="Options">
	/// A value that contains a bitmap of DNS Query Options to use in the DNS query. Options can be combined and all options override <c>DNS_QUERY_STANDARD</c>.
	/// </param>
	/// <param name="pExtra">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="ppQueryResults">
	/// Optional. A pointer to a pointer that points to the list of RRs that comprise the response. For more information, see the
	/// Remarks section.
	/// </param>
	/// <param name="pReserved">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, returns the appropriate DNS-specific error code as defined
	/// in Winerror.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Applications that call the <c>DnsQuery</c> function build a query using a fully qualified DNS name and Resource Record (RR)
	/// type, and set query options depending on the type of service desired. When the <c>DNS_QUERY_STANDARD</c> option is set, DNS uses
	/// the resolver cache, queries first with UDP, then retries with TCP if the response is truncated, and requests that the server to
	/// perform recursive resolution on behalf of the client to resolve the query.
	/// </para>
	/// <para>Applications must free returned RR sets with the DnsRecordListFree function.</para>
	/// <para>
	/// <c>Note</c> When calling one of the <c>DnsQuery</c> function types, be aware that a DNS server may return multiple records in
	/// response to a query. A computer that is multihomed, for example, will receive multiple A records for the same IP address. The
	/// caller must use as many of the returned records as necessary.
	/// </para>
	/// <para>
	/// Consider the following scenario, in which multiple returned records require additional activity on behalf of the application: A
	/// <c>DnsQuery_A</c> function call is made for a multihomed computer and the application finds that the address associated with the
	/// first A record is not responding. The application should then attempt to use other IP addresses specified in the (additional) A
	/// records returned from the <c>DnsQuery_A</c> function call.
	/// </para>
	/// <para>If the lpstrName parameter is set to <c>NULL</c>, the <c>DnsQuery</c> function fails with the error <c>INVALID_PARAMETER</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsquery_a DNS_STATUS DnsQuery_A( PCSTR pszName, WORD wType,
	// DWORD Options, PVOID pExtra, PDNS_RECORD *ppQueryResults, PVOID *pReserved );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "3d810b76-cea1-4904-9b5a-c2566b332c2c")]
	public static extern DNS_STATUS DnsQuery(string pszName, DNS_TYPE wType, DNS_QUERY_OPTIONS Options, [In, Out, Optional] IntPtr pExtra,
		IntPtr ppQueryResults = default, IntPtr pReserved = default);

	/// <summary>
	/// The <c>DnsQueryConfig</c> function enables application programmers to query for the configuration of the local computer or a
	/// specific adapter.
	/// </summary>
	/// <param name="Config">A DNS_CONFIG_TYPE value that specifies the configuration type of the information to be queried.</param>
	/// <param name="Flag">
	/// <para>
	/// A value that specifies whether to allocate memory for the configuration information. Set Flag to <c>DNS_CONFIG_FLAG_ALLOC</c> to
	/// allocate memory; otherwise, set it to 0.
	/// </para>
	/// <para><c>Note</c> Free the allocated memory with LocalFree.</para>
	/// </param>
	/// <param name="pwsAdapterName">A pointer to a string that represents the adapter name against which the query is run.</param>
	/// <param name="pReserved">Reserved for future use.</param>
	/// <param name="pBuffer">
	/// <para>
	/// A pointer to a buffer that receives the query response. The following table shows the data type of the buffer for each of the
	/// Config parameter values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Config parameter</term>
	/// <term>Data type of buffer</term>
	/// </listheader>
	/// <item>
	/// <term>DnsConfigPrimaryDomainName_W</term>
	/// <term>PWCHAR</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigPrimaryDomainName_A</term>
	/// <term>PCHAR</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigPrimaryDomainName_UTF8</term>
	/// <term>PCHAR</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigAdapterDomainName_W</term>
	/// <term>Not implemented</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigAdapterDomainName_A</term>
	/// <term>Not implemented</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigAdapterDomainName_UTF8</term>
	/// <term>Not implemented</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigDnsServerList</term>
	/// <term>IP4_ARRAY</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigSearchList</term>
	/// <term>Not implemented</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigAdapterInfo</term>
	/// <term>Not implemented</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigPrimaryHostNameRegistrationEnabled</term>
	/// <term>DWORD</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigAdapterHostNameRegistrationEnabled</term>
	/// <term>DWORD</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigAddressRegistrationMaxCount</term>
	/// <term>DWORD</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigHostName_W</term>
	/// <term>PWCHAR</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigHostName_A</term>
	/// <term>PCHAR</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigHostName_UTF8</term>
	/// <term>PCHAR</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigFullHostName_W</term>
	/// <term>PWCHAR</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigFullHostName_A</term>
	/// <term>PCHAR</term>
	/// </item>
	/// <item>
	/// <term>DnsConfigFullHostName_UTF8</term>
	/// <term>PCHAR</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pBufLen">
	/// The length of the buffer, in bytes. If the buffer provided is not sufficient, an error is returned and pBufferLength contains
	/// the minimum necessary buffer size. Ignored on input if Flag is set to <c>TRUE</c>.
	/// </param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, returns the appropriate DNS-specific error code as defined
	/// in Winerror.h.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsqueryconfig DNS_STATUS DnsQueryConfig( DNS_CONFIG_TYPE
	// Config, DWORD Flag, PCWSTR pwsAdapterName, PVOID pReserved, PVOID pBuffer, PDWORD pBufLen );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "83de7df8-7e89-42fe-b609-1dc173afc9df")]
	public static extern DNS_STATUS DnsQueryConfig(DNS_CONFIG_TYPE Config, DNS_CONFIG_FLAG Flag,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwsAdapterName, [In, Optional] IntPtr pReserved, IntPtr pBuffer,
		ref uint pBufLen);

	/// <summary>
	/// <para>
	/// The <c>DnsQueryEx</c> function is the asynchronous generic query interface to the DNS namespace, and provides application
	/// developers with a DNS query resolution interface.
	/// </para>
	/// <para>Like DnsQuery, <c>DnsQueryEx</c> can be used to make synchronous queries to the DNS namespace as well.</para>
	/// </summary>
	/// <param name="pQueryRequest">
	/// <para>A pointer to a DNS_QUERY_REQUEST structure that contains the query request information.</para>
	/// <para>
	/// <c>Note</c> By omitting the DNS_QUERY_COMPLETION_ROUTINE callback from the <c>pQueryCompleteCallback</c> member of this
	/// structure, <c>DnsQueryEx</c> is called synchronously.
	/// </para>
	/// </param>
	/// <param name="pQueryResults">
	/// <para>
	/// A pointer to a DNS_QUERY_RESULT structure that contains the results of the query. On input, the <c>version</c> member of
	/// pQueryResults must be <c>DNS_QUERY_REQUEST_VERSION1</c> and all other members should be <c>NULL</c>. On output, the remaining
	/// members will be filled as part of the query complete.
	/// </para>
	/// <para>
	/// <c>Note</c> For asynchronous queries, an application should not free this structure until the DNS_QUERY_COMPLETION_ROUTINE
	/// callback is invoked. When the query completes, the DNS_QUERY_RESULT structure contains a pointer to a list of DNS_RECORDS that
	/// should be freed using DnsRecordListFree.
	/// </para>
	/// </param>
	/// <param name="pCancelHandle">
	/// <para>A pointer to a DNS_QUERY_CANCEL structure that can be used to cancel a pending asynchronous query.</para>
	/// <para><c>Note</c> An application should not free this structure until the DNS_QUERY_COMPLETION_ROUTINE callback is invoked.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>DnsQueryEx</c> function has the following possible return values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The call was successful.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Either the pQueryRequest or pQueryRequest parameters are uninitialized or contain the wrong version.</term>
	/// </item>
	/// <item>
	/// <term>DNS RCODE</term>
	/// <term>The call resulted in an RCODE error.</term>
	/// </item>
	/// <item>
	/// <term>DNS_INFO_NO_RECORDS</term>
	/// <term>No records in the response.</term>
	/// </item>
	/// <item>
	/// <term>DNS_REQUEST_PENDING</term>
	/// <term>The query will be completed asynchronously.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a call to <c>DnsQueryEx</c> completes synchronously (i.e., the function return value is not <c>DNS_REQUEST_PENDING</c>), the
	/// <c>pQueryRecords</c> member of pQueryResults contains a pointer to a list of DNS_RECORDS and <c>DnsQueryEx</c> will return
	/// either error or success.
	/// </para>
	/// <para>The following conditions invoke a synchronous call to <c>DnsQueryEx</c> and do not utilize the DNS callback:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The DNS_QUERY_COMPLETION_ROUTINE callback is omitted from the <c>pQueryCompleteCallback</c> member of pQueryRequest.</term>
	/// </item>
	/// <item>
	/// <term>A query is for the local machine name and A or AAAA type Resource Records (RR).</term>
	/// </item>
	/// <item>
	/// <term>A call to <c>DnsQueryEx</c> queries an IPv4 or IPv6 address.</term>
	/// </item>
	/// <item>
	/// <term>A call to <c>DnsQueryEx</c> returns in error.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If a call to <c>DnsQueryEx</c> completes asynchronously, the results of the query are returned by the
	/// DNS_QUERY_COMPLETION_ROUTINE callback in pQueryRequest, the <c>QueryStatus</c> member of pQueryResults contains
	/// <c>DNS_REQUEST_PENDING</c>, and <c>DnsQueryEx</c> returns <c>DNS_REQUEST_PENDING</c>. Applications should track the
	/// pQueryResults structure that is passed into <c>DnsQueryEx</c> until the DNS callback succeeds. Applications can cancel an
	/// asynchronous query using the pCancelHandle handle returned by <c>DnsQueryEx</c>.
	/// </para>
	/// <para>
	/// pCancelHandle returned from an asynchronous call to <c>DnsQueryEx</c> and pQueryContext is valid until the
	/// DNS_QUERY_COMPLETION_ROUTINE DNS callback is invoked.
	/// </para>
	/// <para>
	/// <c>Note</c> Applications are notified of asynchronous <c>DnsQueryEx</c> completion through the DNS_QUERY_COMPLETION_ROUTINE
	/// callback within the same process context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsqueryex DNS_STATUS DnsQueryEx( PDNS_QUERY_REQUEST
	// pQueryRequest, PDNS_QUERY_RESULT pQueryResults, PDNS_QUERY_CANCEL pCancelHandle );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "22664B9A-5010-42E7-880B-8D5B16A9F2DC")]
	public static extern DNS_STATUS DnsQueryEx(in DNS_QUERY_REQUEST pQueryRequest, ref DNS_QUERY_RESULT pQueryResults,
		ref DNS_QUERY_CANCEL pCancelHandle);

	/// <summary>
	/// <para>
	/// The <c>DnsQueryEx</c> function is the asynchronous generic query interface to the DNS namespace, and provides application
	/// developers with a DNS query resolution interface.
	/// </para>
	/// <para>Like DnsQuery, <c>DnsQueryEx</c> can be used to make synchronous queries to the DNS namespace as well.</para>
	/// </summary>
	/// <param name="pQueryRequest">
	/// <para>A pointer to a DNS_QUERY_REQUEST structure that contains the query request information.</para>
	/// <para>
	/// <c>Note</c> By omitting the DNS_QUERY_COMPLETION_ROUTINE callback from the <c>pQueryCompleteCallback</c> member of this
	/// structure, <c>DnsQueryEx</c> is called synchronously.
	/// </para>
	/// </param>
	/// <param name="pQueryResults">
	/// <para>
	/// A pointer to a DNS_QUERY_RESULT structure that contains the results of the query. On input, the <c>version</c> member of
	/// pQueryResults must be <c>DNS_QUERY_REQUEST_VERSION1</c> and all other members should be <c>NULL</c>. On output, the remaining
	/// members will be filled as part of the query complete.
	/// </para>
	/// <para>
	/// <c>Note</c> For asynchronous queries, an application should not free this structure until the DNS_QUERY_COMPLETION_ROUTINE
	/// callback is invoked. When the query completes, the DNS_QUERY_RESULT structure contains a pointer to a list of DNS_RECORDS that
	/// should be freed using DnsRecordListFree.
	/// </para>
	/// </param>
	/// <param name="pCancelHandle">
	/// <para>A pointer to a DNS_QUERY_CANCEL structure that can be used to cancel a pending asynchronous query.</para>
	/// <para><c>Note</c> An application should not free this structure until the DNS_QUERY_COMPLETION_ROUTINE callback is invoked.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>DnsQueryEx</c> function has the following possible return values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The call was successful.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Either the pQueryRequest or pQueryRequest parameters are uninitialized or contain the wrong version.</term>
	/// </item>
	/// <item>
	/// <term>DNS RCODE</term>
	/// <term>The call resulted in an RCODE error.</term>
	/// </item>
	/// <item>
	/// <term>DNS_INFO_NO_RECORDS</term>
	/// <term>No records in the response.</term>
	/// </item>
	/// <item>
	/// <term>DNS_REQUEST_PENDING</term>
	/// <term>The query will be completed asynchronously.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a call to <c>DnsQueryEx</c> completes synchronously (i.e., the function return value is not <c>DNS_REQUEST_PENDING</c>), the
	/// <c>pQueryRecords</c> member of pQueryResults contains a pointer to a list of DNS_RECORDS and <c>DnsQueryEx</c> will return
	/// either error or success.
	/// </para>
	/// <para>The following conditions invoke a synchronous call to <c>DnsQueryEx</c> and do not utilize the DNS callback:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The DNS_QUERY_COMPLETION_ROUTINE callback is omitted from the <c>pQueryCompleteCallback</c> member of pQueryRequest.</term>
	/// </item>
	/// <item>
	/// <term>A query is for the local machine name and A or AAAA type Resource Records (RR).</term>
	/// </item>
	/// <item>
	/// <term>A call to <c>DnsQueryEx</c> queries an IPv4 or IPv6 address.</term>
	/// </item>
	/// <item>
	/// <term>A call to <c>DnsQueryEx</c> returns in error.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If a call to <c>DnsQueryEx</c> completes asynchronously, the results of the query are returned by the
	/// DNS_QUERY_COMPLETION_ROUTINE callback in pQueryRequest, the <c>QueryStatus</c> member of pQueryResults contains
	/// <c>DNS_REQUEST_PENDING</c>, and <c>DnsQueryEx</c> returns <c>DNS_REQUEST_PENDING</c>. Applications should track the
	/// pQueryResults structure that is passed into <c>DnsQueryEx</c> until the DNS callback succeeds. Applications can cancel an
	/// asynchronous query using the pCancelHandle handle returned by <c>DnsQueryEx</c>.
	/// </para>
	/// <para>
	/// pCancelHandle returned from an asynchronous call to <c>DnsQueryEx</c> and pQueryContext is valid until the
	/// DNS_QUERY_COMPLETION_ROUTINE DNS callback is invoked.
	/// </para>
	/// <para>
	/// <c>Note</c> Applications are notified of asynchronous <c>DnsQueryEx</c> completion through the DNS_QUERY_COMPLETION_ROUTINE
	/// callback within the same process context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsqueryex DNS_STATUS DnsQueryEx( PDNS_QUERY_REQUEST
	// pQueryRequest, PDNS_QUERY_RESULT pQueryResults, PDNS_QUERY_CANCEL pCancelHandle );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "22664B9A-5010-42E7-880B-8D5B16A9F2DC")]
	public static extern DNS_STATUS DnsQueryEx(in DNS_QUERY_REQUEST3 pQueryRequest, ref DNS_QUERY_RESULT pQueryResults,
		ref DNS_QUERY_CANCEL pCancelHandle);

	/// <summary>
	/// <note type="important">Some information relates to a prerelease product which may be substantially modified before it's commercially
	/// released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</note>
	/// <para>
	/// Enables you to perform a DNS query that accepts either a raw packet containing a DNS query, or a query name and type. You can augment
	/// the query with settings and configuration from the host system.
	/// </para>
	/// <list type="bullet">
	/// <item>You can apply new query options and custom servers to an already-formatted raw DNS query packet.</item>
	/// <item>
	/// Or you can instead provide a query name and type, and receive both the parsed records and raw result packet (allowing clients to
	/// interact with all information received from the server).
	/// </item>
	/// </list>
	/// <para>
	/// Queries are performed asynchronously; and results are passed to a DNS_QUERY_RAW_COMPLETION_ROUTINE asynchronous callback function
	/// that you implement. To cancel a query, call DnsCancelQueryRaw.
	/// </para>
	/// </summary>
	/// <param name="queryRequest">
	/// <para>Type: _In_ <c>DNS_QUERY_RAW_REQUEST*</c></para>
	/// <para>The query request.</para>
	/// </param>
	/// <param name="cancelHandle">
	/// <para>Type: _Inout_ <c>DNS_QUERY_RAW_CANCEL*</c></para>
	/// <para>Used to obtain a cancel handle, which you can pass to DnsCancelQueryRaw should you need to cancel the query.</para>
	/// </param>
	/// <returns>
	/// A <c>DNS_STATUS</c> value indicating success or failure. If <c>DNS_REQUEST_PENDING</c> is returned, then when the query completes,
	/// the system calls the DNS_QUERY_RAW_COMPLETION_ROUTINE implementation that you passed in the queryCompletionCallback member of
	/// queryRequest. That callback will received the results of the query if successful, or any failures or cancellations.
	/// </returns>
	/// <remarks>
	/// The structure of a raw packet is the wire representation of the DNS query and response as documented by RFC 1035. A 12-byte DNS
	/// header is followed by either a question section for the query, or by a variable number (can be 0) of records for the response. If TCP
	/// is used, then the raw packet must be prefixed with a 2-byte length field. You can use this API to apply host NRPT rules, or to
	/// perform encrypted DNS queries, among other things.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsqueryraw DNS_STATUS DnsQueryRaw( DNS_QUERY_RAW_REQUEST
	// *queryRequest, DNS_QUERY_RAW_CANCEL *cancelHandle );
	[PInvokeData("windns.h", MSDNShortId = "NF:windns.DnsQueryRaw")]
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	public static extern DNS_STATUS DnsQueryRaw(in DNS_QUERY_RAW_REQUEST queryRequest, ref DNS_QUERY_RAW_CANCEL cancelHandle);

	/// <summary>
	/// <note type="important">Some information relates to a prerelease product which may be substantially modified before it's commercially
	/// released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</note>
	/// <para>Frees the memory allocated to a DNS_QUERY_RAW_RESULT structure object. Also see DNS_QUERY_RAW_COMPLETION_ROUTINE.</para>
	/// </summary>
	/// <param name="queryResults">
	/// <para>Type: _In_ <c>DNS_QUERY_RAW_RESULT*</c></para>
	/// <para>The object whose memory should be freed.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsqueryrawresultfree
	// void DnsQueryRawResultFree( _Frees_ptr_opt_ DNS_QUERY_RAW_RESULT *queryResults );
	[PInvokeData("windns.h", MSDNShortId = "NF:windns.DnsQueryRawResultFree")]
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	public static extern void DnsQueryRawResultFree([In, Out] IntPtr queryResults);

	/// <summary>The <c>DnsRecordCompare</c> function compares two DNS resource records (RR).</summary>
	/// <param name="pRecord1">A pointer to a DNS_RECORD structure that contains the first DNS RR of the comparison pair.</param>
	/// <param name="pRecord2">A pointer to a DNS_RECORD structure that contains the second DNS RR of the comparison pair.</param>
	/// <returns>Returns <c>TRUE</c> if the compared records are equivalent, <c>FALSE</c> if they are not.</returns>
	/// <remarks>
	/// When comparing records, DNS RRs that are stored using different character encoding are treated by the <c>DnsRecordCompare</c>
	/// function as different, even if the records are otherwise equivalent.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordcompare BOOL DnsRecordCompare( PDNS_RECORD pRecord1,
	// PDNS_RECORD pRecord2 );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "c4449a23-d6d3-4f27-a963-a84144983e5e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DnsRecordCompare(in DNS_RECORD pRecord1, in DNS_RECORD pRecord2);

	/// <summary>The <c>DnsRecordCompare</c> function compares two DNS resource records (RR).</summary>
	/// <param name="pRecord1">A pointer to a DNS_RECORD structure that contains the first DNS RR of the comparison pair.</param>
	/// <param name="pRecord2">A pointer to a DNS_RECORD structure that contains the second DNS RR of the comparison pair.</param>
	/// <returns>Returns <c>TRUE</c> if the compared records are equivalent, <c>FALSE</c> if they are not.</returns>
	/// <remarks>
	/// When comparing records, DNS RRs that are stored using different character encoding are treated by the <c>DnsRecordCompare</c>
	/// function as different, even if the records are otherwise equivalent.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordcompare BOOL DnsRecordCompare( PDNS_RECORD pRecord1,
	// PDNS_RECORD pRecord2 );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "c4449a23-d6d3-4f27-a963-a84144983e5e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DnsRecordCompare([In] IntPtr pRecord1, [In] IntPtr pRecord2);

	/// <summary>
	/// The <c>DnsRecordCopyEx</c> function creates a copy of a specified resource record (RR). The <c>DnsRecordCopyEx</c> function is
	/// also capable of converting the character encoding during the copy operation.
	/// </summary>
	/// <param name="pRecord">A pointer to a DNS_RECORD structure that contains the RR to be copied.</param>
	/// <param name="CharSetIn">A DNS_CHARSET value that specifies the character encoding of the source RR.</param>
	/// <param name="CharSetOut">A DNS_CHARSET value that specifies the character encoding required of the destination record.</param>
	/// <returns>Successful execution returns a pointer to the (newly created) destination record. Otherwise, returns null.</returns>
	/// <remarks>The CharSetIn parameter is used only if the character encoding of the source RR is not specified in pRecord.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordcopyex PDNS_RECORD DnsRecordCopyEx( PDNS_RECORD
	// pRecord, DNS_CHARSET CharSetIn, DNS_CHARSET CharSetOut );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "b5a74799-75fc-4489-9efa-c15b2def2ae7")]
	public static extern IntPtr DnsRecordCopyEx(in DNS_RECORD pRecord, DNS_CHARSET CharSetIn, DNS_CHARSET CharSetOut);

	/// <summary>
	/// The <c>DnsRecordCopyEx</c> function creates a copy of a specified resource record (RR). The <c>DnsRecordCopyEx</c> function is
	/// also capable of converting the character encoding during the copy operation.
	/// </summary>
	/// <param name="pRecord">A pointer to a DNS_RECORD structure that contains the RR to be copied.</param>
	/// <param name="CharSetIn">A DNS_CHARSET value that specifies the character encoding of the source RR.</param>
	/// <param name="CharSetOut">A DNS_CHARSET value that specifies the character encoding required of the destination record.</param>
	/// <returns>Successful execution returns a pointer to the (newly created) destination record. Otherwise, returns null.</returns>
	/// <remarks>The CharSetIn parameter is used only if the character encoding of the source RR is not specified in pRecord.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordcopyex PDNS_RECORD DnsRecordCopyEx( PDNS_RECORD
	// pRecord, DNS_CHARSET CharSetIn, DNS_CHARSET CharSetOut );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "b5a74799-75fc-4489-9efa-c15b2def2ae7")]
	public static extern IntPtr DnsRecordCopyEx([In] IntPtr pRecord, DNS_CHARSET CharSetIn, DNS_CHARSET CharSetOut);

	/// <summary>The <c>DnsRecordListFree</c> function frees memory allocated for DNS records obtained using the DnsQuery function.</summary>
	/// <param name="p">A pointer to a DNS_RECORD structure that contains the list of DNS records to be freed.</param>
	/// <param name="t">
	/// A specifier of how the record list should be freed. The only type currently supported is a deep freeing of the entire record
	/// list. For more information and a list of values, see the DNS_FREE_TYPE enumeration.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// The <c>DnsRecordListFree</c> function can be used to free memory allocated from query results obtained using a DnsQuery function
	/// call; it cannot free memory allocated for DNS record lists created manually.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordlistfree void DnsRecordListFree( p, t );
	[PInvokeData("windns.h", MSDNShortId = "fc4c0cb4-646f-4946-8f07-b5a858f7064a")]
	public static void DnsRecordListFree(IntPtr p, DNS_FREE_TYPE t = DNS_FREE_TYPE.DnsFreeRecordList) => DnsFree(p, t);

	/// <summary>The <c>DnsRecordSetCompare</c> function compares two RR sets.</summary>
	/// <param name="pRR1">A pointer to a DNS_RECORD structure that contains the first DNS RR set of the comparison pair.</param>
	/// <param name="pRR2">A pointer to a DNS_RECORD structure that contains the second DNS resource record set of the comparison pair.</param>
	/// <param name="ppDiff1">
	/// A pointer to a DNS_RECORD pointer that contains the list of resource records built as a result of the arithmetic performed on
	/// them: <c>pRRSet1</c> minus <c>pRRSet2</c>.
	/// </param>
	/// <param name="ppDiff2">
	/// A pointer to a DNS_RECORD pointer that contains the list of resource records built as a result of the arithmetic performed on
	/// them: <c>pRRSet2</c> minus <c>pRRSet1</c>.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if the compared record sets are equivalent, <c>FALSE</c> if they are not.</returns>
	/// <remarks>
	/// When comparing record sets, DNS resource records that are stored using different character encoding are treated by the
	/// <c>DnsRecordSetCompare</c> function as equivalent. Contrast this to the DnsRecordCompare function, in which equivalent records
	/// with different encoding are not returned as equivalent records.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordsetcompare BOOL DnsRecordSetCompare( PDNS_RECORD
	// pRR1, PDNS_RECORD pRR2, PDNS_RECORD *ppDiff1, PDNS_RECORD *ppDiff2 );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "008cf2ba-ccb2-430a-85d9-68d424b6938f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DnsRecordSetCompare(in DNS_RECORD pRR1, in DNS_RECORD pRR2, out IntPtr ppDiff1, out IntPtr ppDiff2);

	/// <summary>The <c>DnsRecordSetCompare</c> function compares two RR sets.</summary>
	/// <param name="pRR1">A pointer to a DNS_RECORD structure that contains the first DNS RR set of the comparison pair.</param>
	/// <param name="pRR2">A pointer to a DNS_RECORD structure that contains the second DNS resource record set of the comparison pair.</param>
	/// <param name="ppDiff1">
	/// A pointer to a DNS_RECORD pointer that contains the list of resource records built as a result of the arithmetic performed on
	/// them: <c>pRRSet1</c> minus <c>pRRSet2</c>.
	/// </param>
	/// <param name="ppDiff2">
	/// A pointer to a DNS_RECORD pointer that contains the list of resource records built as a result of the arithmetic performed on
	/// them: <c>pRRSet2</c> minus <c>pRRSet1</c>.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if the compared record sets are equivalent, <c>FALSE</c> if they are not.</returns>
	/// <remarks>
	/// When comparing record sets, DNS resource records that are stored using different character encoding are treated by the
	/// <c>DnsRecordSetCompare</c> function as equivalent. Contrast this to the DnsRecordCompare function, in which equivalent records
	/// with different encoding are not returned as equivalent records.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordsetcompare BOOL DnsRecordSetCompare( PDNS_RECORD
	// pRR1, PDNS_RECORD pRR2, PDNS_RECORD *ppDiff1, PDNS_RECORD *ppDiff2 );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "008cf2ba-ccb2-430a-85d9-68d424b6938f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DnsRecordSetCompare([In] IntPtr pRR1, [In] IntPtr pRR2, out IntPtr ppDiff1, out IntPtr ppDiff2);

	/// <summary>
	/// The <c>DnsRecordSetCopyEx</c> function creates a copy of a specified resource record set. The <c>DnsRecordSetCopyEx</c> function
	/// is also capable of converting the character encoding during the copy operation.
	/// </summary>
	/// <param name="pRecordSet">A pointer to a DNS_RECORD structure that contains the resource record set to be copied.</param>
	/// <param name="CharSetIn">A DNS_CHARSET value that specifies the character encoding of the source resource record set.</param>
	/// <param name="CharSetOut">A DNS_CHARSET value that specifies the character encoding required of the destination record set.</param>
	/// <returns>Successful execution returns a pointer to the newly created destination record set. Otherwise, it returns null.</returns>
	/// <remarks>
	/// The CharSetIn parameter is used only if the character encoding of the source resource record set is not specified in pRecordSet.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordsetcopyex PDNS_RECORD DnsRecordSetCopyEx(
	// PDNS_RECORD pRecordSet, DNS_CHARSET CharSetIn, DNS_CHARSET CharSetOut );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "bdf9d6b4-b9d7-4886-8ea6-1e1f4dbcc99a")]
	public static extern IntPtr DnsRecordSetCopyEx(in DNS_RECORD pRecordSet, DNS_CHARSET CharSetIn, DNS_CHARSET CharSetOut);

	/// <summary>
	/// The <c>DnsRecordSetCopyEx</c> function creates a copy of a specified resource record set. The <c>DnsRecordSetCopyEx</c> function
	/// is also capable of converting the character encoding during the copy operation.
	/// </summary>
	/// <param name="pRecordSet">A pointer to a DNS_RECORD structure that contains the resource record set to be copied.</param>
	/// <param name="CharSetIn">A DNS_CHARSET value that specifies the character encoding of the source resource record set.</param>
	/// <param name="CharSetOut">A DNS_CHARSET value that specifies the character encoding required of the destination record set.</param>
	/// <returns>Successful execution returns a pointer to the newly created destination record set. Otherwise, it returns null.</returns>
	/// <remarks>
	/// The CharSetIn parameter is used only if the character encoding of the source resource record set is not specified in pRecordSet.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordsetcopyex PDNS_RECORD DnsRecordSetCopyEx(
	// PDNS_RECORD pRecordSet, DNS_CHARSET CharSetIn, DNS_CHARSET CharSetOut );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "bdf9d6b4-b9d7-4886-8ea6-1e1f4dbcc99a")]
	public static extern IntPtr DnsRecordSetCopyEx([In] IntPtr pRecordSet, DNS_CHARSET CharSetIn, DNS_CHARSET CharSetOut);

	/// <summary>The <c>DnsRecordSetDetach</c> function detaches the first record set from a specified list of DNS records.</summary>
	/// <param name="pRecordList">
	/// A pointer, on input, to a DNS_RECORD structure that contains the list prior to the detachment of the first DNS record in the
	/// list of DNS records. A pointer, on output to a <c>DNS_RECORD</c> structure that contains the list subsequent to the detachment
	/// of the DNS record.
	/// </param>
	/// <returns>On return, the <c>DnsRecordSetDetach</c> function points to the detached DNS record set.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordsetdetach PDNS_RECORD DnsRecordSetDetach(
	// PDNS_RECORD pRecordList );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "434dc11f-19a9-434f-a024-9cdbb560f24c")]
	public static extern IntPtr DnsRecordSetDetach(in DNS_RECORD pRecordList);

	/// <summary>The <c>DnsRecordSetDetach</c> function detaches the first record set from a specified list of DNS records.</summary>
	/// <param name="pRecordList">
	/// A pointer, on input, to a DNS_RECORD structure that contains the list prior to the detachment of the first DNS record in the
	/// list of DNS records. A pointer, on output to a <c>DNS_RECORD</c> structure that contains the list subsequent to the detachment
	/// of the DNS record.
	/// </param>
	/// <returns>On return, the <c>DnsRecordSetDetach</c> function points to the detached DNS record set.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsrecordsetdetach PDNS_RECORD DnsRecordSetDetach(
	// PDNS_RECORD pRecordList );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "434dc11f-19a9-434f-a024-9cdbb560f24c")]
	public static extern IntPtr DnsRecordSetDetach([In] IntPtr pRecordList);

	/// <summary>The <c>DnsReleaseContextHandle</c> function releases memory used to store the credentials of a specific account.</summary>
	/// <param name="hContext">The credentials handle of a specific account.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsreleasecontexthandle void DnsReleaseContextHandle( HANDLE
	// hContext );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "08a5fa73-4583-4e87-bddb-09bfbfe1b36f")]
	public static extern void DnsReleaseContextHandle(HDNSCONTEXT hContext);

	/// <summary>The <c>DnsReplaceRecordSet</c> function type replaces an existing resource record (RR) set.</summary>
	/// <param name="pReplaceSet">
	/// A pointer to a DNS_RECORD structure that contains the RR set that replaces the existing set. The specified RR set is replaced
	/// with the contents of pNewSet. To delete a RR set, specify the set in pNewSet, but set RDATA to <c>NULL</c>.
	/// </param>
	/// <param name="Options">
	/// A value that contains a bitmap of DNS Update Options. Options can be combined and all options override <c>DNS_UPDATE_SECURITY_USE_DEFAULT</c>.
	/// </param>
	/// <param name="hContext">
	/// The handle to the credentials of a specific account. Used when secure dynamic update is required. This parameter is optional.
	/// </param>
	/// <param name="pExtraInfo">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pReserved">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, returns the appropriate DNS-specific error code as defined
	/// in Winerror.h.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsreplacerecordseta DNS_STATUS DnsReplaceRecordSetA(
	// PDNS_RECORD pReplaceSet, DWORD Options, HANDLE hContext, PVOID pExtraInfo, PVOID pReserved );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsReplaceRecordSetW", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "7b99f440-72fa-4cf4-9267-98f436e99a50")]
	public static extern DNS_STATUS DnsReplaceRecordSet(in DNS_RECORD pReplaceSet, DNS_UPDATE Options, [Optional] HDNSCONTEXT hContext,
		IntPtr pExtraInfo = default, IntPtr pReserved = default);

	/// <summary>The <c>DnsReplaceRecordSet</c> function type replaces an existing resource record (RR) set.</summary>
	/// <param name="pReplaceSet">
	/// A pointer to a DNS_RECORD structure that contains the RR set that replaces the existing set. The specified RR set is replaced
	/// with the contents of pNewSet. To delete a RR set, specify the set in pNewSet, but set RDATA to <c>NULL</c>.
	/// </param>
	/// <param name="Options">
	/// A value that contains a bitmap of DNS Update Options. Options can be combined and all options override <c>DNS_UPDATE_SECURITY_USE_DEFAULT</c>.
	/// </param>
	/// <param name="hContext">
	/// The handle to the credentials of a specific account. Used when secure dynamic update is required. This parameter is optional.
	/// </param>
	/// <param name="pExtraInfo">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pReserved">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// Returns success confirmation upon successful completion. Otherwise, returns the appropriate DNS-specific error code as defined
	/// in Winerror.h.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsreplacerecordseta DNS_STATUS DnsReplaceRecordSetA(
	// PDNS_RECORD pReplaceSet, DWORD Options, HANDLE hContext, PVOID pExtraInfo, PVOID pReserved );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsReplaceRecordSetW", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "7b99f440-72fa-4cf4-9267-98f436e99a50")]
	public static extern DNS_STATUS DnsReplaceRecordSet([In] IntPtr pReplaceSet, DNS_UPDATE Options, [Optional] HDNSCONTEXT hContext,
		IntPtr pExtraInfo = default, IntPtr pReserved = default);

	/// <summary>Used to initiate a DNS-SD discovery for services running on the local network.</summary>
	/// <param name="pRequest">A pointer to a DNS_SERVICE_BROWSE_REQUEST structure that contains the browse request information.</param>
	/// <param name="pCancel">
	/// A pointer to a DNS_SERVICE_CANCEL structure that can be used to cancel a pending asynchronous browsing operation. This handle
	/// must remain valid until the query is canceled.
	/// </param>
	/// <returns>
	/// If successful, returns <c>DNS_REQUEST_PENDING</c>; otherwise, returns the appropriate DNS-specific error code as defined in .
	/// For extended error information, call GetLastError.
	/// </returns>
	/// <remarks>This function is asynchronous. As services are being discovered, the browse callback will be invoked for each result.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsservicebrowse DNS_STATUS DnsServiceBrowse(
	// PDNS_SERVICE_BROWSE_REQUEST pRequest, PDNS_SERVICE_CANCEL pCancel );
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsServiceBrowse(in DNS_SERVICE_BROWSE_REQUEST pRequest, out DNS_SERVICE_CANCEL pCancel);

	/// <summary>Used to cancel a running DNS-SD discovery query.</summary>
	/// <param name="pCancelHandle">
	/// A pointer to the DNS_SERVICE_CANCEL structure that was passed to the DnsServiceBrowse call that is to be cancelled.
	/// </param>
	/// <returns>
	/// If successful, returns <c>ERROR_SUCCESS</c>; otherwise, returns the appropriate DNS-specific error code as defined in . For
	/// extended error information, call GetLastError.
	/// </returns>
	/// <remarks>Canceling the query causes one further invocation of the browse callback, with status <c>ERROR_CANCELLED</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsservicebrowsecancel DNS_STATUS DnsServiceBrowseCancel(
	// PDNS_SERVICE_CANCEL pCancelHandle );
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsServiceBrowseCancel(in DNS_SERVICE_CANCEL pCancelHandle);

	/// <summary>Used to build a DNS_SERVICE_INSTANCE structure from data that describes it.</summary>
	/// <param name="pServiceName">A string that represents the name of the service.</param>
	/// <param name="pHostName">A string that represents the name of the host of the service.</param>
	/// <param name="pIp4">A pointer to an <c>IP4_ADDRESS</c> structure that represents the service-associated IPv4 address.</param>
	/// <param name="pIp6">A pointer to an IP6_ADDRESS structure that represents the service-associated IPv6 address.</param>
	/// <param name="wPort">A value that represents the port on which the service is running.</param>
	/// <param name="wPriority">A value that represents the service priority.</param>
	/// <param name="wWeight">A value that represents the service weight.</param>
	/// <param name="dwPropertiesCount">The number of properties—defines the number of elements in the arrays of the and parameters.</param>
	/// <param name="keys">A pointer to an array of string values that represent the property keys.</param>
	/// <param name="values">A pointer to an array of string values that represent the corresponding property values.</param>
	/// <returns>
	/// A pointer to a newly allocated DNS_SERVICE_INSTANCE structure, built from the passed-in parameters. Your application is
	/// responsible for freeing the associated memory by calling DnsServiceFreeInstance.
	/// </returns>
	/// <remarks>The <c>dwInterfaceIndex</c> field of the returned structure is set to 0.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsserviceconstructinstance PDNS_SERVICE_INSTANCE
	// DnsServiceConstructInstance( PCWSTR pServiceName, PCWSTR pHostName, PIP4_ADDRESS pIp4, PIP6_ADDRESS pIp6, WORD wPort, WORD
	// wPriority, WORD wWeight, DWORD dwPropertiesCount, PCWSTR *keys, PCWSTR *values );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern SafePDNS_SERVICE_INSTANCE DnsServiceConstructInstance([MarshalAs(UnmanagedType.LPWStr)] string pServiceName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pHostName, in IP4_ADDRESS pIp4, in IP6_ADDRESS pIp6, ushort wPort, [Optional] ushort wPriority,
		[Optional] ushort wWeight, [Optional] uint dwPropertiesCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? keys,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? values);

	/// <summary>Used to build a DNS_SERVICE_INSTANCE structure from data that describes it.</summary>
	/// <param name="pServiceName">A string that represents the name of the service.</param>
	/// <param name="pHostName">A string that represents the name of the host of the service.</param>
	/// <param name="pIp4">A pointer to an <c>IP4_ADDRESS</c> structure that represents the service-associated IPv4 address.</param>
	/// <param name="pIp6">A pointer to an IP6_ADDRESS structure that represents the service-associated IPv6 address.</param>
	/// <param name="wPort">A value that represents the port on which the service is running.</param>
	/// <param name="wPriority">A value that represents the service priority.</param>
	/// <param name="wWeight">A value that represents the service weight.</param>
	/// <param name="dwPropertiesCount">The number of properties—defines the number of elements in the arrays of the and parameters.</param>
	/// <param name="keys">A pointer to an array of string values that represent the property keys.</param>
	/// <param name="values">A pointer to an array of string values that represent the corresponding property values.</param>
	/// <returns>
	/// A pointer to a newly allocated DNS_SERVICE_INSTANCE structure, built from the passed-in parameters. Your application is
	/// responsible for freeing the associated memory by calling DnsServiceFreeInstance.
	/// </returns>
	/// <remarks>The <c>dwInterfaceIndex</c> field of the returned structure is set to 0.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsserviceconstructinstance PDNS_SERVICE_INSTANCE
	// DnsServiceConstructInstance( PCWSTR pServiceName, PCWSTR pHostName, PIP4_ADDRESS pIp4, PIP6_ADDRESS pIp6, WORD wPort, WORD
	// wPriority, WORD wWeight, DWORD dwPropertiesCount, PCWSTR *keys, PCWSTR *values );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern SafePDNS_SERVICE_INSTANCE DnsServiceConstructInstance([MarshalAs(UnmanagedType.LPWStr)] string pServiceName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pHostName, [In, Optional] IntPtr pIp4, [In, Optional] IntPtr pIp6, ushort wPort, [Optional] ushort wPriority,
		[Optional] ushort wWeight, [Optional] uint dwPropertiesCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? keys,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? values);

	/// <summary>Used to copy a DNS_SERVICE_INSTANCE structure.</summary>
	/// <param name="pOrig">A pointer to the DNS_SERVICE_INSTANCE structure that is to be copied.</param>
	/// <returns>
	/// A pointer to a newly allocated DNS_SERVICE_INSTANCE structure that's a copy of . Your application is responsible for freeing the
	/// associated memory by calling DnsServiceFreeInstance.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsservicecopyinstance PDNS_SERVICE_INSTANCE
	// DnsServiceCopyInstance( PDNS_SERVICE_INSTANCE pOrig );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern SafePDNS_SERVICE_INSTANCE DnsServiceCopyInstance(SafePDNS_SERVICE_INSTANCE pOrig);

	/// <summary>Used to remove a registered service.</summary>
	/// <param name="pRequest">A pointer to the DNS_SERVICE_REGISTER_REQUEST structure that was used to register the service.</param>
	/// <param name="pCancel">Must be <see langword="null"/>.</param>
	/// <returns>
	/// If successful, returns <c>DNS_REQUEST_PENDING</c>; otherwise, returns the appropriate DNS-specific error code as defined in
	/// <c>Winerror.h</c>. For extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// This function is asynchronous. The callback will be invoked when the deregistration is completed, with a copy of the
	/// DNS_SERVICE_INSTANCE structure that was passed to DnsServiceRegister when the service was registered.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsservicederegister DWORD DnsServiceDeRegister(
	// PDNS_SERVICE_REGISTER_REQUEST pRequest, PDNS_SERVICE_CANCEL pCancel );
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsServiceDeRegister(in DNS_SERVICE_REGISTER_REQUEST pRequest, in DNS_SERVICE_CANCEL pCancel);

	/// <summary>Used to remove a registered service.</summary>
	/// <param name="pRequest">A pointer to the DNS_SERVICE_REGISTER_REQUEST structure that was used to register the service.</param>
	/// <param name="pCancel">Must be <see langword="null"/>.</param>
	/// <returns>
	/// If successful, returns <c>DNS_REQUEST_PENDING</c>; otherwise, returns the appropriate DNS-specific error code as defined in
	/// <c>Winerror.h</c>. For extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// This function is asynchronous. The callback will be invoked when the deregistration is completed, with a copy of the
	/// DNS_SERVICE_INSTANCE structure that was passed to DnsServiceRegister when the service was registered.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsservicederegister DWORD DnsServiceDeRegister(
	// PDNS_SERVICE_REGISTER_REQUEST pRequest, PDNS_SERVICE_CANCEL pCancel );
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsServiceDeRegister(in DNS_SERVICE_REGISTER_REQUEST pRequest, [In, Optional] IntPtr pCancel);

	/// <summary>Used to free the resources associated with a DNS_SERVICE_INSTANCE structure.</summary>
	/// <param name="pInstance">A pointer to the DNS_SERVICE_INSTANCE structure that is to be freed.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsservicefreeinstance void DnsServiceFreeInstance(
	// PDNS_SERVICE_INSTANCE pInstance );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern void DnsServiceFreeInstance(IntPtr pInstance);

	/// <summary>Used to register a discoverable service on this device.</summary>
	/// <param name="pRequest">
	/// A pointer to a DNS_SERVICE_REGISTER_REQUEST structure that contains information about the service to be registered.
	/// </param>
	/// <param name="pCancel">
	/// An optional (it can be ) pointer to a DNS_SERVICE_CANCEL structure that can be used to cancel a pending asynchronous
	/// registration operation. If not , then this handle must remain valid until the registration is canceled.
	/// </param>
	/// <returns>
	/// If successful, returns <c>DNS_REQUEST_PENDING</c>; otherwise, returns the appropriate DNS-specific error code as defined in .
	/// For extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// This function is asynchronous. The registration callback will be called once the registration succeeds. To deregister the
	/// service, call DnsServiceDeRegister. The registration is tied to the lifetime of the calling process. If the process goes away,
	/// the service will be automatically deregistered.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsserviceregister DWORD DnsServiceRegister(
	// PDNS_SERVICE_REGISTER_REQUEST pRequest, PDNS_SERVICE_CANCEL pCancel );
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsServiceRegister(in DNS_SERVICE_REGISTER_REQUEST pRequest, out DNS_SERVICE_CANCEL pCancel);

	/// <summary>Used to cancel a pending registration operation.</summary>
	/// <param name="pCancelHandle">
	/// A pointer to the DNS_SERVICE_CANCEL structure that was passed to the DnsServiceRegister call that is to be cancelled.
	/// </param>
	/// <returns>
	/// If successful, returns <c>ERROR_SUCCESS</c>. Returns <c>ERROR_CANCELLED</c> if the operation was already cancelled, or
	/// <c>ERROR_INVALID_PARAMETER</c> if the handle is invalid.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsserviceregistercancel DWORD DnsServiceRegisterCancel(
	// PDNS_SERVICE_CANCEL pCancelHandle );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsServiceRegisterCancel(in DNS_SERVICE_CANCEL pCancelHandle);

	/// <summary>Used to obtain more information about a service advertised on the local network.</summary>
	/// <param name="pRequest">A pointer to a DNS_SERVICE_RESOLVE_REQUEST structure that contains the resolve request information.</param>
	/// <param name="pCancel">
	/// A pointer to a DNS_SERVICE_CANCEL structure that can be used to cancel a pending asynchronous resolve operation. This handle
	/// must remain valid until the query is canceled.
	/// </param>
	/// <returns>
	/// If successful, returns <c>DNS_REQUEST_PENDING</c>; otherwise, returns the appropriate DNS-specific error code as defined in .
	/// For extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// This function is asynchronous. Upon completion, the resolve callback will be invoked for each result. In contrast to
	/// DnsServiceBrowse—which returns the service name as a minimum— <c>DnsServiceResolve</c> can be used to retrieve additional
	/// information, such as hostname, IP address, and TEXT records.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsserviceresolve DNS_STATUS DnsServiceResolve(
	// PDNS_SERVICE_RESOLVE_REQUEST pRequest, PDNS_SERVICE_CANCEL pCancel );
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsServiceResolve(in DNS_SERVICE_RESOLVE_REQUEST pRequest, out DNS_SERVICE_CANCEL pCancel);

	/// <summary>Used to cancel a running DNS-SD resolve query.</summary>
	/// <param name="pCancelHandle">
	/// A pointer to the DNS_SERVICE_CANCEL structure that was passed to the DnsServiceResolve call that is to be cancelled.
	/// </param>
	/// <returns>
	/// If successful, returns <c>ERROR_SUCCESS</c>; otherwise, returns the appropriate DNS-specific error code as defined in . For
	/// extended error information, call GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsserviceresolvecancel DNS_STATUS DnsServiceResolveCancel(
	// PDNS_SERVICE_CANCEL pCancelHandle );
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsServiceResolveCancel(in DNS_SERVICE_CANCEL pCancelHandle);

	/// <summary>
	/// Configures per-application DNS settings. This includes the ability to set per-application DNS servers either as fallback to the
	/// system configured servers, or exclusively.
	/// </summary>
	/// <param name="cServers">
	/// <para>Type: _In_ <c>DWORD</c></para>
	/// <para>The number of custom DNS servers present in the pServers parameter.</para>
	/// </param>
	/// <param name="pServers">
	/// <para>Type: _In_reads_(cServers) <c>DNS_CUSTOM_SERVER*</c></para>
	/// <para>An array of DNS_CUSTOM_SERVER that contains cServers elements. If cServers is 0, then this must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pSettings">
	/// <para>Type: _In_opt_ <c>DNS_APPLICATION_SETTINGS*</c></para>
	/// <para>A pointer to a DNS_APPLICATION_SETTINGS object describing additional settings for custom DNS servers.</para>
	/// <para>
	/// If this is <c>NULL</c>, then the custom DNS servers passed to the API will be used as fallback to the system-configured ones.
	/// </para>
	/// <para>
	/// If this points to a DNS_APPLICATION_SETTINGS object that has the <c>DNS_APP_SETTINGS_EXCLUSIVE_SERVERS</c> flag set in its Flags
	/// member, then it means use the custom DNS servers exclusively.
	/// </para>
	/// </param>
	/// <returns>A <c>DWORD</c> containing <c>ERROR_SUCCESS</c> on success, or an error code on failure.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnssetapplicationsettings
	// DWORD DnsSetApplicationSettings( DWORD cServers, const DNS_CUSTOM_SERVER *pServers, const DNS_APPLICATION_SETTINGS *pSettings );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "NF:windns.DnsSetApplicationSettings", MinClient = PInvokeClient.Windows11)]
	public static extern DNS_STATUS DnsSetApplicationSettings(uint cServers,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DNS_CUSTOM_SERVER[]? pServers, in DNS_APPLICATION_SETTINGS pSettings);

	/// <summary>
	/// Configures per-application DNS settings. This includes the ability to set per-application DNS servers either as fallback to the
	/// system configured servers, or exclusively.
	/// </summary>
	/// <param name="cServers">
	/// <para>Type: _In_ <c>DWORD</c></para>
	/// <para>The number of custom DNS servers present in the pServers parameter.</para>
	/// </param>
	/// <param name="pServers">
	/// <para>Type: _In_reads_(cServers) <c>DNS_CUSTOM_SERVER*</c></para>
	/// <para>An array of DNS_CUSTOM_SERVER that contains cServers elements. If cServers is 0, then this must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pSettings">
	/// <para>Type: _In_opt_ <c>DNS_APPLICATION_SETTINGS*</c></para>
	/// <para>A pointer to a DNS_APPLICATION_SETTINGS object describing additional settings for custom DNS servers.</para>
	/// <para>
	/// If this is <c>NULL</c>, then the custom DNS servers passed to the API will be used as fallback to the system-configured ones.
	/// </para>
	/// <para>
	/// If this points to a DNS_APPLICATION_SETTINGS object that has the <c>DNS_APP_SETTINGS_EXCLUSIVE_SERVERS</c> flag set in its Flags
	/// member, then it means use the custom DNS servers exclusively.
	/// </para>
	/// </param>
	/// <returns>A <c>DWORD</c> containing <c>ERROR_SUCCESS</c> on success, or an error code on failure.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnssetapplicationsettings
	// DWORD DnsSetApplicationSettings( DWORD cServers, const DNS_CUSTOM_SERVER *pServers, const DNS_APPLICATION_SETTINGS *pSettings );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "NF:windns.DnsSetApplicationSettings", MinClient = PInvokeClient.Windows11)]
	public static extern DNS_STATUS DnsSetApplicationSettings(uint cServers,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DNS_CUSTOM_SERVER[]? pServers, [In, Optional] IntPtr pSettings);

	/// <summary>Used to register a discoverable service on this device.</summary>
	/// <param name="pQueryRequest">A pointer to an MDNS_QUERY_REQUEST structure that contains information about the query to be performed.</param>
	/// <param name="pHandle">
	/// A pointer to an MDNS_QUERY_HANDLE structure that will be populated with the necessary data. This structure is to be passed later
	/// to DnsStopMulticastQuery to stop the query.
	/// </param>
	/// <returns>
	/// If successful, returns <c>ERROR_SUCCESS</c>; otherwise, returns the appropriate DNS-specific error code as defined in . For
	/// extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// This function is asynchronous. The query runs indefinitely, until DnsStopMulticastQuery is called. For each response from the
	/// network, the query callback will be invoked with the appropriate status and results.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsstartmulticastquery DNS_STATUS DnsStartMulticastQuery(
	// PMDNS_QUERY_REQUEST pQueryRequest, PMDNS_QUERY_HANDLE pHandle );
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsStartMulticastQuery(in MDNS_QUERY_REQUEST pQueryRequest, out MDNS_QUERY_HANDLE pHandle);

	/// <summary>Used to stop a running DnsStartMulticastQuery operation.</summary>
	/// <param name="pHandle">
	/// A pointer to the MDNS_QUERY_HANDLE structure that was passed to the DnsStartMulticastQuery call that is to be stopped.
	/// </param>
	/// <returns>
	/// If successful, returns <c>ERROR_SUCCESS</c>; otherwise, returns the appropriate DNS-specific error code as defined in . For
	/// extended error information, call GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsstopmulticastquery DNS_STATUS DnsStopMulticastQuery(
	// PMDNS_QUERY_HANDLE pHandle );
	[DllImport(Lib.Dnsapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("windns.h")]
	public static extern DNS_STATUS DnsStopMulticastQuery(in MDNS_QUERY_HANDLE pHandle);

	/// <summary>The <c>DnsValidateName</c> function validates the status of a specified DNS name.</summary>
	/// <param name="pszName"/>
	/// <param name="Format"/>
	/// <returns>The <c>DnsValidateName</c> function has the following possible return values:</returns>
	/// <remarks>
	/// <para>
	/// To verify the status of the Computer Host (single label), use the <c>DnsValidateName</c> function type with
	/// <c>DnsNameHostnameLabel</c> in Format.
	/// </para>
	/// <para>
	/// The <c>DnsValidateName</c> function works in a progression when determining whether an error exists with a given DNS name, and
	/// returns upon finding its first error. Therefore, a DNS name that has multiple, different errors may be reported as having the
	/// first error, and could be corrected and resubmitted, only then to find the second error.
	/// </para>
	/// <para>The <c>DnsValidateName</c> function searches for errors as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>Returns <c>ERROR_INVALID_NAME</c> if the DNS name:</term>
	/// </item>
	/// <item>
	/// <term>
	/// Next, <c>DnsValidateName</c> returns <c>DNS_ERROR_NUMERIC_NAME</c> if the full DNS name consists of only numeric characters
	/// (0-9) or the first label of the DNS name consists of only numeric characters (0-9), unless Format is set to DnsNameDomainLabel
	/// or DnsNameDomain.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Then, <c>DnsValidateName</c> returns DNS_ERROR_NON_RFC_NAME if the DNS name:</term>
	/// </item>
	/// <item>
	/// <term>Next, <c>DnsValidateName</c> returns <c>DNS_ERROR_INVALID_NAME_CHAR</c> if the DNS name:</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> If <c>DnsValidateName</c> returns <c>DNS_ERROR_NON_RFC_NAME</c>, the error should be handled as a warning that not
	/// all DNS servers will accept the name. When this error is received, note that the DNS Server does accept the submitted name, if
	/// appropriately configured (default configuration accepts the name as submitted when <c>DNS_ERROR_NON_RFC_NAME</c> is returned),
	/// but other DNS server software may not. Windows DNS servers do handle <c>NON_RFC_NAMES</c>.If <c>DnsValidateName</c> returns any
	/// of the following errors, pszName should be handled as an invalid host name:
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsvalidatename_w DNS_STATUS DnsValidateName_W( PCWSTR
	// pszName, DNS_NAME_FORMAT Format );
	[DllImport(Lib.Dnsapi, SetLastError = false, EntryPoint = "DnsValidateName_W", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "efdbd217-6936-42c1-a1eb-8655a62513ee")]
	public static extern DNS_STATUS DnsValidateName([MarshalAs(UnmanagedType.LPWStr)] string pszName, DNS_NAME_FORMAT Format);

	/// <summary>The <c>DnsValidateServerStatus</c> function validates an IP address as a suitable DNS server.</summary>
	/// <param name="server">A pointer to a SOCKADDR that contains the DNS server IPv4 or IPv6 address to be examined.</param>
	/// <param name="queryName">
	/// A pointer to a Unicode string that represents the fully qualified domain name (FQDN) of the owner of the record set that is queried.
	/// </param>
	/// <param name="serverStatus">
	/// <para>A pointer to a DWORD that represents the query validation status.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>No errors. The call was successful.</term>
	/// </item>
	/// <item>
	/// <term>DNS_VALSVR_ERROR_INVALID_ADDR</term>
	/// <term>server IP address was invalid.</term>
	/// </item>
	/// <item>
	/// <term>DNS_VALSVR_ERROR_INVALID_NAME</term>
	/// <term>queryName FQDN was invalid.</term>
	/// </item>
	/// <item>
	/// <term>DNS_VALSVR_ERROR_UNREACHABLE</term>
	/// <term>DNS server was unreachable.</term>
	/// </item>
	/// <item>
	/// <term>DNS_VALSVR_ERROR_NO_RESPONSE</term>
	/// <term>Timeout waiting for the DNS server response.</term>
	/// </item>
	/// <item>
	/// <term>DNS_VALSVR_ERROR_NO_AUTH</term>
	/// <term>DNS server was not authoritative or queryName was not found.</term>
	/// </item>
	/// <item>
	/// <term>DNS_VALSVR_ERROR_REFUSED</term>
	/// <term>DNS server refused the query.</term>
	/// </item>
	/// <item>
	/// <term>DNS_VALSVR_ERROR_NO_TCP</term>
	/// <term>
	/// The TCP query did not return ERROR_SUCCESS after the validation system had already completed a successful query to the DNS
	/// server using UDP.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DNS_VALSVR_ERROR_UNKNOWN</term>
	/// <term>An unknown error occurred.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The <c>DnsValidateServerStatus</c> function has the following possible return values:</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnsvalidateserverstatus DNS_STATUS DnsValidateServerStatus(
	// PSOCKADDR server, PCWSTR queryName, PDWORD serverStatus );
	[DllImport(Lib.Dnsapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windns.h", MSDNShortId = "5b362d05-87b2-44dd-8198-bcb5ab5a64f6")]
	public static extern DNS_STATUS DnsValidateServerStatus([In] SOCKADDR server, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? queryName,
		out DnsServerStatus serverStatus);

	/// <summary>
	/// The <c>DnsWriteQuestionToBuffer</c> function type creates a DNS query message and stores it in a DNS_MESSAGE_BUFFER structure.
	/// </summary>
	/// <param name="pDnsBuffer">A pointer to a DNS_MESSAGE_BUFFER structure that contains a DNS query message stored in a buffer.</param>
	/// <param name="pdwBufferSize">
	/// The size, in bytes, of the buffer allocated to store pDnsBuffer. If the buffer size is insufficient to contain the message,
	/// <c>FALSE</c> is returned and pdwBufferSize contains the minimum required buffer size.
	/// </param>
	/// <param name="pszName">A pointer to a string that represents the name of the owner of the record set being queried.</param>
	/// <param name="wType">
	/// A value that represents the RR DNS Record Type. <c>wType</c> determines the format of <c>Data</c>. For example, if the value of
	/// <c>wType</c> is <c>DNS_TYPE_A</c>, the data type of <c>Data</c> is DNS_A_DATA.
	/// </param>
	/// <param name="Xid">A value that specifies the unique DNS query identifier.</param>
	/// <param name="fRecursionDesired">
	/// A BOOL that specifies whether recursive name query should be used by the DNS name server. Set to <c>TRUE</c> to request
	/// recursive name query, <c>FALSE</c> to request iterative name query.
	/// </param>
	/// <returns>Returns <c>TRUE</c> upon successful execution, otherwise <c>FALSE</c>.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windns/nf-windns-dnswritequestiontobuffer_w BOOL DnsWriteQuestionToBuffer_W(
	// PDNS_MESSAGE_BUFFER pDnsBuffer, PDWORD pdwBufferSize, PCWSTR pszName, WORD wType, WORD Xid, BOOL fRecursionDesired );
	[DllImport(Lib.Dnsapi, SetLastError = true, EntryPoint = "DnsWriteQuestionToBuffer_W", CharSet = CharSet.Unicode)]
	[PInvokeData("windns.h", MSDNShortId = "9aa853aa-d9b5-41e3-a82a-c25de199924d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DnsWriteQuestionToBuffer([In, Out] IntPtr pDnsBuffer, ref uint pdwBufferSize,
		[MarshalAs(UnmanagedType.LPWStr)] string pszName, DNS_TYPE wType, ushort Xid, [MarshalAs(UnmanagedType.Bool)] bool fRecursionDesired);

	/// <summary>Provides a handle to a DNS Context.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HDNSCONTEXT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HDNSCONTEXT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDNSCONTEXT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDNSCONTEXT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDNSCONTEXT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HDNSCONTEXT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HDNSCONTEXT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDNSCONTEXT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDNSCONTEXT(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HDNSCONTEXT h1, HDNSCONTEXT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HDNSCONTEXT h1, HDNSCONTEXT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HDNSCONTEXT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for a list of allocated <c>DNS_CACHE_ENTRY</c> values that is disposed using <see cref="DnsFree"/>.</summary>
	public class SafeDnsCacheDataTable : SafeHANDLE, IEnumerable<DNS_CACHE_ENTRY>
	{
		/// <summary>Initializes a new instance of the <see cref="SafeDnsCacheDataTable"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
		public SafeDnsCacheDataTable(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeDnsCacheDataTable"/> class.</summary>
		private SafeDnsCacheDataTable() : base() { }

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<DNS_CACHE_ENTRY> GetEnumerator() => handle.LinkedListToIEnum<DNS_CACHE_ENTRY>(r => r.pNext).GetEnumerator();

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle()
		{
			// From https://stackoverflow.com/questions/31889957/memory-leak-when-using-dnsgetcachedatatable
			var p = handle;
			while (p != IntPtr.Zero)
			{
				var s = p.ToStructure<DNS_CACHE_ENTRY>();
				DnsFree((IntPtr)s.pszName, DNS_FREE_TYPE.DnsFreeFlat);
				DnsFree(p, DNS_FREE_TYPE.DnsFreeFlat);
				p = s.pNext;
			}
			return true;
		}
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for a DNS record list that is disposed using <see cref="DnsRecordListFree"/>.</summary>
	public class SafeDnsRecordList : SafeHANDLE, IEnumerable<DNS_RECORD>
	{
		/// <summary>Initializes a new instance of the <see cref="SafeDnsRecordList"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeDnsRecordList(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeDnsRecordList"/> class.</summary>
		private SafeDnsRecordList() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeDnsRecordList"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator IntPtr(SafeDnsRecordList h) => h.handle;

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public IEnumerator<DNS_RECORD> GetEnumerator() => handle.LinkedListToIEnum<DNS_RECORD>(r => r.pNext).GetEnumerator();

		/// <summary>Gets a sequence of pointers to each of the records.</summary>
		/// <returns>Record pointers.</returns>
		public IEnumerable<IntPtr> GetRecordPointers()
		{
			var p = handle;
			while (p != IntPtr.Zero)
			{
				yield return p;
				p = p.ToStructure<DNS_RECORD>().pNext;
			}
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { DnsRecordListFree(handle); return true; }
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HDNSCONTEXT"/> that is disposed using <see cref="DnsReleaseContextHandle"/>.</summary>
	public class SafeHDNSCONTEXT : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHDNSCONTEXT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHDNSCONTEXT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHDNSCONTEXT"/> class.</summary>
		private SafeHDNSCONTEXT() : base() { }

		/// <summary>Performs an explicit conversion from <see cref="SafeHDNSCONTEXT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The resulting <see cref="IntPtr"/> instance from the conversion.</returns>
		public static explicit operator IntPtr(SafeHDNSCONTEXT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeHDNSCONTEXT"/> to <see cref="HDNSCONTEXT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDNSCONTEXT(SafeHDNSCONTEXT h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { DnsReleaseContextHandle(handle); return true; }
	}

	internal class DnsProxyStringMem : ISimpleMemoryMethods
	{
		private bool self = false;

		/// <inheritdoc/>
		bool ISimpleMemoryMethods.AllocZeroes => true;

		/// <inheritdoc/>
		bool ISimpleMemoryMethods.Lockable => false;

		/// <summary>Gets a handle to a memory allocation of the specified size.</summary>
		/// <param name="size">The size, in bytes, of memory to allocate.</param>
		/// <returns>A memory handle.</returns>
		public IntPtr AllocMem(int size) { self = true; return Marshal.AllocCoTaskMem(size); }

		/// <summary>Frees the memory associated with a handle.</summary>
		/// <param name="hMem">A memory handle.</param>
		public void FreeMem(IntPtr hMem) { if (self) Marshal.FreeCoTaskMem(hMem); else DnsFreeProxyName(hMem); }

		/// <summary>Locks the memory of a specified handle and gets a pointer to it.</summary>
		/// <param name="hMem">A memory handle.</param>
		/// <returns>A pointer to the locked memory.</returns>
		public IntPtr LockMem(IntPtr hMem) => hMem;

		/// <summary>Unlocks the memory of a specified handle.</summary>
		/// <param name="hMem">A memory handle.</param>
		public bool UnlockMem(IntPtr hMem) => false;
	}
}