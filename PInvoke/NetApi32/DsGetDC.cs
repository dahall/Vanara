using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke;

public static partial class NetApi32
{
	/// <summary>Enumeration supporting <see cref="DOMAIN_CONTROLLER_INFO.DomainControllerAddressType"/>.</summary>
	[PInvokeData("DsGetDC.h", MSDNShortId = "ms675912")]
	public enum DomainControllerAddressType
	{
		/// <summary>The address is a string IP address (for example, "\\157.55.94.74") of the domain controller.</summary>
		DS_INET_ADDRESS = 1,

		/// <summary>The address is a NetBIOS name, for example, "\\phoenix", of the domain controller.</summary>
		DS_NETBIOS_ADDRESS = 2
	}

	/// <summary>Enumeration supporting <see cref="DOMAIN_CONTROLLER_INFO.Flags"/>.</summary>
	[Flags]
	[PInvokeData("DsGetDC.h", MSDNShortId = "ms675912")]
	public enum DomainControllerType : uint
	{
		/// <summary>The domain controller is PDC of Domain.</summary>
		DS_PDC_FLAG = 0x00000001,

		/// <summary>The domain controller is a GC of forest.</summary>
		DS_GC_FLAG = 0x00000004,

		/// <summary>Server supports an LDAP server.</summary>
		DS_LDAP_FLAG = 0x00000008,

		/// <summary>The domain controller supports a DS and is a Domain Controller.</summary>
		DS_DS_FLAG = 0x00000010,

		/// <summary>The domain controller is running KDC service.</summary>
		DS_KDC_FLAG = 0x00000020,

		/// <summary>The domain controller is running time service.</summary>
		DS_TIMESERV_FLAG = 0x00000040,

		/// <summary>The domain controller is in closest site to client.</summary>
		DS_CLOSEST_FLAG = 0x00000080,

		/// <summary>The domain controller has a writable DS.</summary>
		DS_WRITABLE_FLAG = 0x00000100,

		/// <summary>The domain controller is running time service (and has clock hardware).</summary>
		DS_GOOD_TIMESERV_FLAG = 0x00000200,

		/// <summary>DomainName is non-domain NC serviced by the LDAP server.</summary>
		DS_NDNC_FLAG = 0x00000400,

		/// <summary>The domain controller has some secrets.</summary>
		DS_SELECT_SECRET_DOMAIN_6_FLAG = 0x00000800,

		/// <summary>The domain controller has all secrets.</summary>
		DS_FULL_SECRET_DOMAIN_6_FLAG = 0x00001000,

		/// <summary>The domain controller is running web service.</summary>
		DS_WS_FLAG = 0x00002000,

		/// <summary>The domain controller is running Win8 or later.</summary>
		DS_DS_8_FLAG = 0x00004000,

		/// <summary>The domain controller is running Win8.1 or later.</summary>
		DS_DS_9_FLAG = 0x00008000,

		/// <summary>The domain controller is running WinThreshold or later.</summary>
		DS_DS_10_FLAG = 0x00010000,

		/// <summary>Flags returned on ping.</summary>
		DS_PING_FLAGS = 0x000FFFFF,

		/// <summary>The DomainControllerName is a DNS name.</summary>
		DS_DNS_CONTROLLER_FLAG = 0x20000000,

		/// <summary>The DomainName is a DNS name.</summary>
		DS_DNS_DOMAIN_FLAG = 0x40000000,

		/// <summary>The DnsForestName is a DNS name.</summary>
		DS_DNS_FOREST_FLAG = 0x80000000,
	}

	/// <summary>
	/// A set of flags that specify more data about the domain trust. This can be zero or a combination of one or more of the following values.
	/// </summary>
	[PInvokeData("dsgetdc.h", MSDNShortId = "cd260fd1-dc38-4405-95ba-097a23faf668")]
	public enum DomainTrustFlag
	{
		/// <summary>
		/// The domain represented by this structure is a member of the same forest as the server specified in the ServerName parameter
		/// of the DsEnumerateDomainTrusts function.
		/// </summary>
		DS_DOMAIN_IN_FOREST = 0x0001,

		/// <summary>
		/// The domain represented by this structure is directly trusted by the domain that the server specified in the ServerName
		/// parameter of the DsEnumerateDomainTrusts function is a member of.
		/// </summary>
		DS_DOMAIN_DIRECT_OUTBOUND = 0x0002,

		/// <summary>
		/// The domain represented by this structure is the root of a tree and a member of the same forest as the server specified in the
		/// ServerName parameter of the DsEnumerateDomainTrusts function.
		/// </summary>
		DS_DOMAIN_TREE_ROOT = 0x0004,

		/// <summary>
		/// The domain represented by this structure is the primary domain of the server specified in the ServerName parameter of the
		/// DsEnumerateDomainTrusts function.
		/// </summary>
		DS_DOMAIN_PRIMARY = 0x0008,

		/// <summary>The domain represented by this structure is running in the Windows 2000 native mode.</summary>
		DS_DOMAIN_NATIVE_MODE = 0x0010,

		/// <summary>
		/// The domain represented by this structure directly trusts the domain that the server specified in the ServerName parameter of
		/// the DsEnumerateDomainTrusts function is a member of.
		/// </summary>
		DS_DOMAIN_DIRECT_INBOUND = 0x0020,
	}

	/// <summary>Flags supporting behavior of <see cref="DsGetDcName(string, string, in Guid, string, DsGetDcNameFlags, out SafeNetApiBuffer)"/>.</summary>
	[Flags]
	[PInvokeData("DsGetDC.h", MSDNShortId = "ms675983")]
	public enum DsGetDcNameFlags : uint
	{
		/// <summary>
		/// Forces cached domain controller data to be ignored. When the DS_FORCE_REDISCOVERY flag is not specified, DsGetDcName may
		/// return cached domain controller data. If this flag is specified, DsGetDcName will not use cached information (if any exists)
		/// but will instead perform a fresh domain controller discovery.
		/// <para>
		/// This flag should not be used under normal conditions, as using the cached domain controller information has better
		/// performance characteristics and helps to ensure that the same domain controller is used consistently by all applications.
		/// This flag should be used only after the application determines that the domain controller returned by DsGetDcName (when
		/// called without this flag) is not accessible. In that case, the application should repeat the DsGetDcName call with this flag
		/// to ensure that the unuseful cached information (if any) is ignored and a reachable domain controller is discovered.
		/// </para>
		/// </summary>
		DS_FORCE_REDISCOVERY = 0x1,

		/// <summary>Requires that the returned domain controller support directory services.</summary>
		DS_DIRECTORY_SERVICE_REQUIRED = 0x10,

		/// <summary>
		/// DsGetDcName attempts to find a domain controller that supports directory service functions. If a domain controller that
		/// supports directory services is not available, DsGetDcName returns the name of a non-directory service domain controller.
		/// However, DsGetDcName only returns a non-directory service domain controller after the attempt to find a directory service
		/// domain controller times out.
		/// </summary>
		DS_DIRECTORY_SERVICE_PREFERRED = 0x20,

		/// <summary>
		/// Requires that the returned domain controller be a global catalog server for the forest of domains with this domain as the
		/// root. If this flag is set and the DomainName parameter is not NULL, DomainName must specify a forest name. This flag cannot
		/// be combined with the DS_PDC_REQUIRED or DS_KDC_REQUIRED flags.
		/// </summary>
		DS_GC_SERVER_REQUIRED = 0x40,

		/// <summary>
		/// Requires that the returned domain controller be the primary domain controller for the domain. This flag cannot be combined
		/// with the DS_KDC_REQUIRED or DS_GC_SERVER_REQUIRED flags.
		/// </summary>
		DS_PDC_REQUIRED = 0x80,

		/// <summary>
		/// If the DS_FORCE_REDISCOVERY flag is not specified, this function uses cached domain controller data. If the cached data is
		/// more than 15 minutes old, the cache is refreshed by pinging the domain controller. If this flag is specified, this refresh is
		/// avoided even if the cached data is expired. This flag should be used if the DsGetDcName function is called periodically.
		/// </summary>
		DS_BACKGROUND_ONLY = 0x100,

		/// <summary>
		/// This parameter indicates that the domain controller must have an IP address. In that case, DsGetDcName will place the
		/// Internet protocol address of the domain controller in the DomainControllerAddress member of DomainControllerInfo.
		/// </summary>
		DS_IP_REQUIRED = 0x200,

		/// <summary>
		/// Requires that the returned domain controller be currently running the Kerberos Key Distribution Center service. This flag
		/// cannot be combined with the DS_PDC_REQUIRED or DS_GC_SERVER_REQUIRED flags.
		/// </summary>
		DS_KDC_REQUIRED = 0x400,

		/// <summary>Requires that the returned domain controller be currently running the Windows Time Service.</summary>
		DS_TIMESERV_REQUIRED = 0x800,

		/// <summary>Requires that the returned domain controller be writable; that is, host a writable copy of the directory service.</summary>
		DS_WRITABLE_REQUIRED = 0x1000,

		/// <summary>
		/// DsGetDcName attempts to find a domain controller that is a reliable time server. The Windows Time Service can be configured
		/// to declare one or more domain controllers as a reliable time server. For more information, see the Windows Time Service
		/// documentation. This flag is intended to be used only by the Windows Time Service.
		/// </summary>
		DS_GOOD_TIMESERV_PREFERRED = 0x2000,

		/// <summary>
		/// When called from a domain controller, specifies that the returned domain controller name should not be the current computer.
		/// If the current computer is not a domain controller, this flag is ignored. This flag can be used to obtain the name of another
		/// domain controller in the domain.
		/// </summary>
		DS_AVOID_SELF = 0x4000,

		/// <summary>
		/// Specifies that the server returned is an LDAP server. The server returned is not necessarily a domain controller. No other
		/// services are implied to be present at the server. The server returned does not necessarily have a writable config container
		/// nor a writable schema container. The server returned may not necessarily be used to create or modify security principles.
		/// This flag may be used with the DS_GC_SERVER_REQUIRED flag to return an LDAP server that also hosts a global catalog server.
		/// The returned global catalog server is not necessarily a domain controller. No other services are implied to be present at the
		/// server. If this flag is specified, the DS_PDC_REQUIRED, DS_TIMESERV_REQUIRED, DS_GOOD_TIMESERV_PREFERRED,
		/// DS_DIRECTORY_SERVICES_PREFERED, DS_DIRECTORY_SERVICES_REQUIRED, and DS_KDC_REQUIRED flags are ignored.
		/// </summary>
		DS_ONLY_LDAP_NEEDED = 0x8000,

		/// <summary>
		/// Specifies that the DomainName parameter is a flat name. This flag cannot be combined with the DS_IS_DNS_NAME flag.
		/// </summary>
		DS_IS_FLAT_NAME = 0x10000,

		/// <summary>
		/// Specifies that the DomainName parameter is a DNS name. This flag cannot be combined with the DS_IS_FLAT_NAME flag.
		/// <para>
		/// Specify either DS_IS_DNS_NAME or DS_IS_FLAT_NAME. If neither flag is specified, DsGetDcName may take longer to find a domain
		/// controller because it may have to search for both the DNS-style and flat name.
		/// </para>
		/// </summary>
		DS_IS_DNS_NAME = 0x20000,

		/// <summary>
		/// When this flag is specified, DsGetDcName attempts to find a domain controller in the same site as the caller. If no such
		/// domain controller is found, it will find a domain controller that can provide topology information and call DsBindToISTG to
		/// obtain a bind handle, then call DsQuerySitesByCost over UDP to determine the "next closest site," and finally cache the name
		/// of the site found. If no domain controller is found in that site, then DsGetDcName falls back on the default method of
		/// locating a domain controller.
		/// <para>
		/// If this flag is used in conjunction with a non-NULL value in the input parameter SiteName, then ERROR_INVALID_FLAGS is thrown.
		/// </para>
		/// <para>
		/// Also, the kind of search employed with DS_TRY_NEXT_CLOSEST_SITE is site-specific, so this flag is ignored if it is used in
		/// conjunction with DS_PDC_REQUIRED. Finally, DS_TRY_NEXTCLOSEST_SITE is ignored when used in conjunction with
		/// DS_RETURN_FLAT_NAME because that uses NetBIOS to resolve the name, but the domain of the domain controller found won't
		/// necessarily match the domain to which the client is joined.
		/// </para>
		/// <note>Note This flag is Group Policy enabled. If you enable the "Next Closest Site" policy setting, Next Closest Site DC
		/// Location will be turned on for the machine across all available but un-configured network adapters. If you disable the policy
		/// setting, Next Closest Site DC Location will not be used by default for the machine across all available but un-configured
		/// network adapters. However, if a DC Locator call is made using the DS_TRY_NEXTCLOSEST_SITE flag explicitly, DsGetDcName honors
		/// the Next Closest Site behavior. If you do not configure this policy setting, Next Closest Site DC Location will be not be
		/// used by default for the machine across all available but un-configured network adapters. If the DS_TRY_NEXTCLOSEST_SITE flag
		/// is used explicitly, the Next Closest Site behavior will be used.</note>
		/// </summary>
		DS_TRY_NEXTCLOSEST_SITE = 0x40000,

		/// <summary>Requires that the returned domain controller be running Windows Server 2008 or later.</summary>
		DS_DIRECTORY_SERVICE_6_REQUIRED = 0x80000,

		/// <summary>Requires that the returned domain controller be currently running the Active Directory web service.</summary>
		DS_WEB_SERVICE_REQUIRED = 0x100000,

		/// <summary>Requires that the returned domain controller be running Windows Server 2012 or later.</summary>
		DS_DIRECTORY_SERVICE_8_REQUIRED = 0x200000,

		/// <summary>Requires that the returned domain controller be running Windows Server 2012 R2 or later.</summary>
		DS_DIRECTORY_SERVICE_9_REQUIRED = 0x400000,

		/// <summary>Requires that the returned domain controller be running Windows Server 2016 or later.</summary>
		DS_DIRECTORY_SERVICE_10_REQUIRED = 0x800000,

		/// <summary>
		/// Specifies that the names returned in the DomainControllerName and DomainName members of DomainControllerInfo should be DNS
		/// names. If a DNS name is not available, an error is returned. This flag cannot be specified with the DS_RETURN_FLAT_NAME flag.
		/// This flag implies the DS_IP_REQUIRED flag.
		/// </summary>
		DS_RETURN_DNS_NAME = 0x40000000,

		/// <summary>
		/// Specifies that the names returned in the DomainControllerName and DomainName members of DomainControllerInfo should be flat
		/// names. If a flat name is not available, an error is returned. This flag cannot be specified with the DS_RETURN_DNS_NAME flag.
		/// </summary>
		DS_RETURN_FLAT_NAME = 0x80000000,
	}

	/// <summary>Flags used by <c>DsGetDcOpen</c>.</summary>
	[PInvokeData("dsgetdc.h", MSDNShortId = "2811cc30-f367-4f1a-8f0c-ed0a77dad24c")]
	[Flags]
	public enum DsGetDcOpenOptions
	{
		/// <summary>Only site-specific domain controllers are enumerated.</summary>
		DS_ONLY_DO_SITE_NAME = 0x01,

		/// <summary>
		/// The DsGetDcNext function will return the ERROR_FILEMARK_DETECTED value after all of the site-specific domain controllers are
		/// retrieved. DsGetDcNext will then enumerate the second group, which contains all domain controllers in the domain, including
		/// the site-specific domain controllers contained in the first group.
		/// </summary>
		DS_NOTIFY_AFTER_SITE_RECORDS = 0x02,
	}

	/// <summary>Flags used by <c>DsGetForestTrustInformationW</c>.</summary>
	[PInvokeData("dsgetdc.h", MSDNShortId = "c94fdc5b-920b-4807-9cbf-3172ec1c7386")]
	[Flags]
	public enum DsGetForestTrustInformationFlags
	{
		/// <summary>
		/// If this flag is set, DsGetForestTrustInformationW will update the forest trust data of the trusted domain identified by the
		/// TrustedDomainNameparameter. In this case, the TrustedDomainName parameter cannot be NULL. The caller must have access to
		/// modify the trust data or ERROR_ACCESS_DENIED is returned.
		/// <para>This flag is only valid if ServerName specifies the primary domain controller of the domain.</para>
		/// </summary>
		DS_GFTI_UPDATE_TDO = 1
	}

	/// <summary>The <c>DsAddressToSiteNames</c> function obtains the site names corresponding to the specified addresses.</summary>
	/// <param name="ComputerName">
	/// Pointer to a null-terminated string that specifies the name of the remote server to process this function. This parameter must be
	/// the name of a domain controller. A non-domain controller can call this function by calling DsGetDcName to find the domain controller.
	/// </param>
	/// <param name="EntryCount">Contains the number of elements in the SocketAddresses array.</param>
	/// <param name="SocketAddresses">
	/// Contains an array of SOCKET_ADDRESS structures that contain the addresses to convert. Each address in this array must be of the
	/// type <c>AF_INET</c>. EntryCount contains the number of elements in this array.
	/// </param>
	/// <param name="SiteNames">
	/// Receives an array of null-terminated string pointers that contain the site names for the addresses. Each element in this array
	/// corresponds to the same element in the SocketAddresses array. An element is <c>NULL</c> if the corresponding address does not map
	/// to any known site or if the address entry is not of the proper form. The caller must free this array when it is no longer
	/// required by calling NetApiBufferFree.
	/// </param>
	/// <returns>
	/// Returns <c>NO_ERROR</c> if successful or a Win32 or RPC error otherwise. The following list lists possible error codes.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsaddresstositenamesa DSGETDCAPI DWORD
	// DsAddressToSiteNamesA( IN LPCSTR ComputerName, IN DWORD EntryCount, IN PSOCKET_ADDRESS SocketAddresses, OUT LPSTR **SiteNames );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "4d70dbee-be33-4d2a-a200-3696443fa853")]
	public static extern Win32Error DsAddressToSiteNames(string ComputerName, uint EntryCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SOCKET_ADDRESS[] SocketAddresses, out SafeNetApiBuffer SiteNames);

	/// <summary>The <c>DsAddressToSiteNamesEx</c> function obtains the site and subnet names corresponding to the addresses specified.</summary>
	/// <param name="ComputerName">
	/// Pointer to a null-terminated string that specifies the name of the remote server to process this function. This parameter must be
	/// the name of a domain controller. A non-domain controller can call this function by calling DsGetDcName to find the domain controller.
	/// </param>
	/// <param name="EntryCount">Contains the number of elements in the SocketAddresses array.</param>
	/// <param name="SocketAddresses">
	/// Contains an array of SOCKET_ADDRESS structures that contain the addresses to convert. Each address in this array must be of the
	/// type <c>AF_INET</c>. EntryCount contains the number of elements in this array.
	/// </param>
	/// <param name="SiteNames">
	/// Receives an array of null-terminated string pointers that contain the site names for the addresses. Each element in this array
	/// corresponds to the same element in the SocketAddresses array. An element is <c>NULL</c> if the corresponding address does not map
	/// to any known site or if the address entry is not of the proper form. The caller must free this array when it is no longer
	/// required by calling NetApiBufferFree.
	/// </param>
	/// <param name="SubnetNames">
	/// Receives an array of null-terminated string pointers that contain the subnet names used to perform the address to site name
	/// mappings. Each element in this array corresponds to the same element in the SocketAddresses array. An element is <c>NULL</c> if
	/// the corresponding address to site name mapping was not determined or if no subnet was used to perform the corresponding address
	/// to site mapping. The latter will be the case when there is exactly one site in the enterprise with no subnet objects mapped to
	/// it. The caller must free this array when it is no longer required by calling NetApiBufferFree.
	/// </param>
	/// <returns>Returns <c>NO_ERROR</c> if successful or a Win32 or RPC error otherwise. The following are possible error codes.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsaddresstositenamesexw
	// DSGETDCAPI DWORD DsAddressToSiteNamesExW( IN LPCWSTR ComputerName, IN DWORD EntryCount, IN PSOCKET_ADDRESS SocketAddresses, OUT LPWSTR **SiteNames, OUT LPWSTR **SubnetNames );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "60ac6195-6e43-46da-a1e6-74ec989cd0c4")]
	[SuppressAutoGen]
	public static extern Win32Error DsAddressToSiteNamesEx(string ComputerName, uint EntryCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SOCKET_ADDRESS[] SocketAddresses, out SafeNetApiBuffer SiteNames, out SafeNetApiBuffer SubnetNames);

	/// <summary>
	/// <para>
	/// The <c>DsDeregisterDnsHostRecords</c> function deletes DNS entries, except for type A records registered by a domain controller.
	/// Only an administrator, account operator, or server operator may call this function.
	/// </para>
	/// </summary>
	/// <param name="ServerName">
	/// <para>
	/// The null-terminated string that specifies the name of the remote domain controller. Can be set to <c>NULL</c> if the calling
	/// application is running on the domain controller being updated.
	/// </para>
	/// </param>
	/// <param name="DnsDomainName">
	/// <para>
	/// The null-terminated string that specifies the DNS domain name of the domain occupied by the domain controller. It is unnecessary
	/// for this to be a domain hosted by this domain controller. If <c>NULL</c>, the DnsHostName with the leftmost label removed is specified.
	/// </para>
	/// </param>
	/// <param name="DomainGuid">
	/// <para>Pointer to the Domain GUID of the domain. If <c>NULL</c>, GUID specific names are not removed.</para>
	/// </param>
	/// <param name="DsaGuid">
	/// <para>
	/// Pointer to the GUID of the <c>NTDS-DSA</c> object to be deleted. If <c>NULL</c>, <c>NTDS-DSA</c> specific names are not removed.
	/// </para>
	/// </param>
	/// <param name="DnsHostName">
	/// <para>
	/// Pointer to the null-terminated string that specifies the DNS host name of the domain controller whose DNS records are being deleted.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>This function returns DSGETDCAPI DWORD.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function deregisters SRV and CNAME records only. It leaves type A records intact. Deletion of site specific records, for
	/// example, _ldap.tcp.&lt;SiteName&gt;._sites.dc._msdcs.&lt;DnsDomainName&gt;, is attempted for every site (&lt;SiteName&gt; in this
	/// example) in the enterprise of the domain controller on which the function is executed. Therefore, this function call could create
	/// a time-consuming run and may generate significant network traffic for enterprises with many sites.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsderegisterdnshostrecordsa DSGETDCAPI DWORD
	// DsDeregisterDnsHostRecordsA( LPSTR ServerName, LPSTR DnsDomainName, GUID *DomainGuid, GUID *DsaGuid, LPSTR DnsHostName );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "18ab6455-dab2-42d9-b68e-a8f0ad2d8091")]
	public static extern Win32Error DsDeregisterDnsHostRecords([Optional] string? ServerName, [Optional] string? DnsDomainName, in Guid DomainGuid, in Guid DsaGuid, string DnsHostName);

	/// <summary>
	/// <para>
	/// The <c>DsDeregisterDnsHostRecords</c> function deletes DNS entries, except for type A records registered by a domain controller.
	/// Only an administrator, account operator, or server operator may call this function.
	/// </para>
	/// </summary>
	/// <param name="ServerName">
	/// <para>
	/// The null-terminated string that specifies the name of the remote domain controller. Can be set to <c>NULL</c> if the calling
	/// application is running on the domain controller being updated.
	/// </para>
	/// </param>
	/// <param name="DnsDomainName">
	/// <para>
	/// The null-terminated string that specifies the DNS domain name of the domain occupied by the domain controller. It is unnecessary
	/// for this to be a domain hosted by this domain controller. If <c>NULL</c>, the DnsHostName with the leftmost label removed is specified.
	/// </para>
	/// </param>
	/// <param name="DomainGuid">
	/// <para>Pointer to the Domain GUID of the domain. If <c>NULL</c>, GUID specific names are not removed.</para>
	/// </param>
	/// <param name="DsaGuid">
	/// <para>
	/// Pointer to the GUID of the <c>NTDS-DSA</c> object to be deleted. If <c>NULL</c>, <c>NTDS-DSA</c> specific names are not removed.
	/// </para>
	/// </param>
	/// <param name="DnsHostName">
	/// <para>
	/// Pointer to the null-terminated string that specifies the DNS host name of the domain controller whose DNS records are being deleted.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>This function returns DSGETDCAPI DWORD.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function deregisters SRV and CNAME records only. It leaves type A records intact. Deletion of site specific records, for
	/// example, _ldap.tcp.&lt;SiteName&gt;._sites.dc._msdcs.&lt;DnsDomainName&gt;, is attempted for every site (&lt;SiteName&gt; in this
	/// example) in the enterprise of the domain controller on which the function is executed. Therefore, this function call could create
	/// a time-consuming run and may generate significant network traffic for enterprises with many sites.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsderegisterdnshostrecordsa DSGETDCAPI DWORD
	// DsDeregisterDnsHostRecordsA( LPSTR ServerName, LPSTR DnsDomainName, GUID *DomainGuid, GUID *DsaGuid, LPSTR DnsHostName );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "18ab6455-dab2-42d9-b68e-a8f0ad2d8091")]
	public static extern Win32Error DsDeregisterDnsHostRecords([Optional] string? ServerName, [Optional] string? DnsDomainName, IntPtr DomainGuid, [Optional] IntPtr DsaGuid, string DnsHostName);

	/// <summary>The <c>DsEnumerateDomainTrusts</c> function obtains domain trust data for a specified domain.</summary>
	/// <param name="ServerName"><para>
	/// Pointer to a null-terminated string that specifies the name of a computer in the domain to obtain the trust information for. If
	/// this parameter is <c>NULL</c>, the name of the local computer is used. The caller must be an authenticated user in this domain.
	/// </para>
	/// <para>
	/// If this computer is a domain controller, this function returns the trust data immediately. If this computer is not a domain
	/// controller, this function obtains the trust data from cached data if the cached data is not expired. If the cached data is
	/// expired, this function obtains the trust data from a domain controller in the domain that this computer is a member of and
	/// updates the cache. The cached data automatically expires after five minutes.
	/// </para></param>
	/// <param name="Flags"><para>
	/// Contains a set of flags that determines which domain trusts to enumerate. This can be zero or a combination of one or more of the
	/// following values.
	/// </para>
	/// <para>DS_DOMAIN_DIRECT_INBOUND</para>
	/// <para>Enumerate domains that directly trust the domain which has ServerName as a member.</para>
	/// <para>DS_DOMAIN_DIRECT_OUTBOUND</para>
	/// <para>Enumerate domains directly trusted by the domain which has ServerName as a member.</para>
	/// <para>DS_DOMAIN_IN_FOREST</para>
	/// <para>Enumerate domains that are a member of the same forest which has ServerName as a member.</para>
	/// <para>DS_DOMAIN_NATIVE_MODE</para>
	/// <para>Enumerate domains where the primary domain is running in Windows 2000 native mode.</para>
	/// <para>DS_DOMAIN_PRIMARY</para>
	/// <para>Enumerate domains that are the primary domain of the domain which has ServerName as a member.</para>
	/// <para>DS_DOMAIN_TREE_ROOT</para>
	/// <para>Enumerate domains that are at the root of the forest which has ServerName as a member.</para></param>
	/// <param name="Domains">Pointer to a <c>PDS_DOMAIN_TRUSTS</c> value that receives an array of DS_DOMAIN_TRUSTS structures. Each structure in this array
	/// contains trust data about a domain. The caller must free this memory when it is no longer required by calling NetApiBufferFree.</param>
	/// <param name="DomainCount">Pointer to a <c>ULONG</c> value that receives the number of elements returned in the Domains array.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 error code otherwise. Possible error codes include those listed in the
	/// following list.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsenumeratedomaintrustsa DSGETDCAPI DWORD
	// DsEnumerateDomainTrustsA( LPSTR ServerName, ULONG Flags, PDS_DOMAIN_TRUSTSA *Domains, PULONG DomainCount );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "6c3b788f-ee53-4637-acdb-04316e8464fe")]
	public static extern Win32Error DsEnumerateDomainTrusts([Optional] string? ServerName, [Optional] DomainTrustFlag Flags, out SafeNetApiBuffer Domains, out uint DomainCount);

	/// <summary>
	/// <para>The <c>DsGetDcClose</c> function closes a domain controller enumeration operation.</para>
	/// </summary>
	/// <param name="GetDcContextHandle">
	/// <para>Contains the domain controller enumeration context handle provided by the DsGetDcOpen function.</para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>When this function is called, GetDcContextHandle is invalid and cannot be used.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetdcclosew DSGETDCAPI VOID DsGetDcCloseW( IN HANDLE
	// GetDcContextHandle );
	[DllImport(Lib.NetApi32, SetLastError = false, EntryPoint = "DsGetDcCloseW")]
	[PInvokeData("dsgetdc.h", MSDNShortId = "d193e4cd-ad66-4d93-b912-348f17e93a6f")]
	public static extern void DsGetDcClose(HANDLE GetDcContextHandle);

	/// <summary>
	/// The <c>DsGetDcName</c> function returns the name of a domain controller in a specified domain. This function accepts additional
	/// domain controller selection criteria to indicate preference for a domain controller with particular characteristics.
	/// </summary>
	/// <param name="ComputerName">
	/// Pointer to a null-terminated string that specifies the name of the server to process this function. Typically, this parameter is
	/// <c>NULL</c>, which indicates that the local computer is used.
	/// </param>
	/// <param name="DomainName">
	/// <para>
	/// Pointer to a null-terminated string that specifies the name of the domain or application partition to query. This name can either
	/// be a DNS style name, for example, fabrikam.com, or a flat-style name, for example, Fabrikam. If a DNS style name is specified,
	/// the name may be specified with or without a trailing period.
	/// </para>
	/// <para>
	/// If the Flags parameter contains the <c>DS_GC_SERVER_REQUIRED</c> flag, DomainName must be the name of the forest. In this case,
	/// <c>DsGetDcName</c> fails if DomainName specifies a name that is not the forest root.
	/// </para>
	/// <para>
	/// If the Flags parameter contains the <c>DS_GC_SERVER_REQUIRED</c> flag and DomainName is <c>NULL</c>, <c>DsGetDcName</c> attempts
	/// to find a global catalog in the forest of the computer identified by ComputerName, which is the local computer if ComputerName is <c>NULL</c>.
	/// </para>
	/// <para>
	/// If DomainName is <c>NULL</c> and the Flags parameter does not contain the <c>DS_GC_SERVER_REQUIRED</c> flag, ComputerName is set
	/// to the default domain name of the primary domain of the computer identified by ComputerName.
	/// </para>
	/// </param>
	/// <param name="DomainGuid">
	/// Pointer to a GUID structure that specifies the <c>GUID</c> of the domain queried. If DomainGuid is not <c>NULL</c> and the domain
	/// specified by DomainName or ComputerName cannot be found, <c>DsGetDcName</c> attempts to locate a domain controller in the domain
	/// having the GUID specified by DomainGuid.
	/// </param>
	/// <param name="SiteName">
	/// Pointer to a null-terminated string that specifies the name of the site where the returned domain controller should physically
	/// exist. If this parameter is <c>NULL</c>, <c>DsGetDcName</c> attempts to return a domain controller in the site closest to the
	/// site of the computer specified by ComputerName. This parameter should be <c>NULL</c>, by default.
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// Contains a set of flags that provide additional data used to process the request. This parameter can be a combination of the
	/// following values.
	/// </para>
	/// <para>DS_AVOID_SELF</para>
	/// <para>
	/// When called from a domain controller, specifies that the returned domain controller name should not be the current computer. If
	/// the current computer is not a domain controller, this flag is ignored. This flag can be used to obtain the name of another domain
	/// controller in the domain.
	/// </para>
	/// <para>DS_BACKGROUND_ONLY</para>
	/// <para>
	/// If the <c>DS_FORCE_REDISCOVERY</c> flag is not specified, this function uses cached domain controller data. If the cached data is
	/// more than 15 minutes old, the cache is refreshed by pinging the domain controller. If this flag is specified, this refresh is
	/// avoided even if the cached data is expired. This flag should be used if the <c>DsGetDcName</c> function is called periodically.
	/// </para>
	/// <para>DS_DIRECTORY_SERVICE_PREFERRED</para>
	/// <para>
	/// <c>DsGetDcName</c> attempts to find a domain controller that supports directory service functions. If a domain controller that
	/// supports directory services is not available, <c>DsGetDcName</c> returns the name of a non-directory service domain controller.
	/// However, <c>DsGetDcName</c> only returns a non-directory service domain controller after the attempt to find a directory service
	/// domain controller times out.
	/// </para>
	/// <para>DS_DIRECTORY_SERVICE_REQUIRED</para>
	/// <para>Requires that the returned domain controller support directory services.</para>
	/// <para>DS_DIRECTORY_SERVICE_6_REQUIRED</para>
	/// <para>Requires that the returned domain controller be running Windows Server 2008 or later.</para>
	/// <para>DS_DIRECTORY_SERVICE_8_REQUIRED</para>
	/// <para>Requires that the returned domain controller be running Windows Server 2012 or later.</para>
	/// <para>DS_FORCE_REDISCOVERY</para>
	/// <para>
	/// Forces cached domain controller data to be ignored. When the <c>DS_FORCE_REDISCOVERY</c> flag is not specified,
	/// <c>DsGetDcName</c> may return cached domain controller data. If this flag is specified, <c>DsGetDcName</c> will not use cached
	/// information (if any exists) but will instead perform a fresh domain controller discovery.
	/// </para>
	/// <para>
	/// This flag should not be used under normal conditions, as using the cached domain controller information has better performance
	/// characteristics and helps to ensure that the same domain controller is used consistently by all applications. This flag should be
	/// used only after the application determines that the domain controller returned by <c>DsGetDcName</c> (when called without this
	/// flag) is not accessible. In that case, the application should repeat the <c>DsGetDcName</c> call with this flag to ensure that
	/// the unuseful cached information (if any) is ignored and a reachable domain controller is discovered.
	/// </para>
	/// <para>DS_GC_SERVER_REQUIRED</para>
	/// <para>
	/// Requires that the returned domain controller be a global catalog server for the forest of domains with this domain as the root.
	/// If this flag is set and the DomainName parameter is not <c>NULL</c>, DomainName must specify a forest name. This flag cannot be
	/// combined with the <c>DS_PDC_REQUIRED</c> or <c>DS_KDC_REQUIRED</c> flags.
	/// </para>
	/// <para>DS_GOOD_TIMESERV_PREFERRED</para>
	/// <para>
	/// <c>DsGetDcName</c> attempts to find a domain controller that is a reliable time server. The Windows Time Service can be
	/// configured to declare one or more domain controllers as a reliable time server. For more information, see the Windows Time
	/// Service documentation. This flag is intended to be used only by the Windows Time Service.
	/// </para>
	/// <para>DS_IP_REQUIRED</para>
	/// <para>
	/// This parameter indicates that the domain controller must have an IP address. In that case, <c>DsGetDcName</c> will place the
	/// Internet protocol address of the domain controller in the <c>DomainControllerAddress</c> member of DomainControllerInfo.
	/// </para>
	/// <para>DS_IS_DNS_NAME</para>
	/// <para>Specifies that the DomainName parameter is a DNS name. This flag cannot be combined with the <c>DS_IS_FLAT_NAME</c> flag.</para>
	/// <para>
	/// Specify either <c>DS_IS_DNS_NAME</c> or <c>DS_IS_FLAT_NAME</c>. If neither flag is specified, <c>DsGetDcName</c> may take longer
	/// to find a domain controller because it may have to search for both the DNS-style and flat name.
	/// </para>
	/// <para>DS_IS_FLAT_NAME</para>
	/// <para>Specifies that the DomainName parameter is a flat name. This flag cannot be combined with the <c>DS_IS_DNS_NAME</c> flag.</para>
	/// <para>DS_KDC_REQUIRED</para>
	/// <para>
	/// Requires that the returned domain controller be currently running the Kerberos Key Distribution Center service. This flag cannot
	/// be combined with the <c>DS_PDC_REQUIRED</c> or <c>DS_GC_SERVER_REQUIRED</c> flags.
	/// </para>
	/// <para>DS_ONLY_LDAP_NEEDED</para>
	/// <para>
	/// Specifies that the server returned is an LDAP server. The server returned is not necessarily a domain controller. No other
	/// services are implied to be present at the server. The server returned does not necessarily have a writable <c>config</c>
	/// container nor a writable <c>schema</c> container. The server returned may not necessarily be used to create or modify security
	/// principles. This flag may be used with the <c>DS_GC_SERVER_REQUIRED</c> flag to return an LDAP server that also hosts a global
	/// catalog server. The returned global catalog server is not necessarily a domain controller. No other services are implied to be
	/// present at the server. If this flag is specified, the <c>DS_PDC_REQUIRED</c>, <c>DS_TIMESERV_REQUIRED</c>,
	/// <c>DS_GOOD_TIMESERV_PREFERRED</c>, <c>DS_DIRECTORY_SERVICES_PREFERED</c>, <c>DS_DIRECTORY_SERVICES_REQUIRED</c>, and
	/// <c>DS_KDC_REQUIRED</c> flags are ignored.
	/// </para>
	/// <para>DS_PDC_REQUIRED</para>
	/// <para>
	/// Requires that the returned domain controller be the primary domain controller for the domain. This flag cannot be combined with
	/// the <c>DS_KDC_REQUIRED</c> or <c>DS_GC_SERVER_REQUIRED</c> flags.
	/// </para>
	/// <para>DS_RETURN_DNS_NAME</para>
	/// <para>
	/// Specifies that the names returned in the <c>DomainControllerName</c> and <c>DomainName</c> members of DomainControllerInfo should
	/// be DNS names. If a DNS name is not available, an error is returned. This flag cannot be specified with the
	/// <c>DS_RETURN_FLAT_NAME</c> flag. This flag implies the <c>DS_IP_REQUIRED</c> flag.
	/// </para>
	/// <para>DS_RETURN_FLAT_NAME</para>
	/// <para>
	/// Specifies that the names returned in the <c>DomainControllerName</c> and <c>DomainName</c> members of DomainControllerInfo should
	/// be flat names. If a flat name is not available, an error is returned. This flag cannot be specified with the
	/// <c>DS_RETURN_DNS_NAME</c> flag.
	/// </para>
	/// <para>DS_TIMESERV_REQUIRED</para>
	/// <para>Requires that the returned domain controller be currently running the Windows Time Service.</para>
	/// <para>DS_TRY_NEXTCLOSEST_SITE</para>
	/// <para>
	/// When this flag is specified, <c>DsGetDcName</c> attempts to find a domain controller in the same site as the caller. If no such
	/// domain controller is found, it will find a domain controller that can provide topology information and call DsBindToISTG to
	/// obtain a bind handle, then call DsQuerySitesByCost over UDP to determine the "next closest site," and finally cache the name of
	/// the site found. If no domain controller is found in that site, then <c>DsGetDcName</c> falls back on the default method of
	/// locating a domain controller.
	/// </para>
	/// <para>
	/// If this flag is used in conjunction with a non-NULL value in the input parameter SiteName, then <c>ERROR_INVALID_FLAGS</c> is thrown.
	/// </para>
	/// <para>
	/// Also, the kind of search employed with <c>DS_TRY_NEXT_CLOSEST_SITE</c> is site-specific, so this flag is ignored if it is used in
	/// conjunction with <c>DS_PDC_REQUIRED</c>. Finally, <c>DS_TRY_NEXTCLOSEST_SITE</c> is ignored when used in conjunction with
	/// <c>DS_RETURN_FLAT_NAME</c> because that uses NetBIOS to resolve the name, but the domain of the domain controller found won't
	/// necessarily match the domain to which the client is joined.
	/// </para>
	/// <para>
	/// <c>Note</c> This flag is Group Policy enabled. If you enable the "Next Closest Site" policy setting, Next Closest Site DC
	/// Location will be turned on for the machine across all available but un-configured network adapters. If you disable the policy
	/// setting, Next Closest Site DC Location will not be used by default for the machine across all available but un-configured network
	/// adapters. However, if a DC Locator call is made using the <c>DS_TRY_NEXTCLOSEST_SITE</c> flag explicitly, <c>DsGetDcName</c>
	/// honors the Next Closest Site behavior. If you do not configure this policy setting, Next Closest Site DC Location will be not be
	/// used by default for the machine across all available but un-configured network adapters. If the <c>DS_TRY_NEXTCLOSEST_SITE</c>
	/// flag is used explicitly, the Next Closest Site behavior will be used.
	/// </para>
	/// <para>DS_WRITABLE_REQUIRED</para>
	/// <para>Requires that the returned domain controller be writable; that is, host a writable copy of the directory service.</para>
	/// <para>DS_WEB_SERVICE_REQUIRED</para>
	/// <para>Requires that the returned domain controller be currently running the Active Directory web service.</para>
	/// </param>
	/// <param name="DomainControllerInfo">
	/// Pointer to a <c>PDOMAIN_CONTROLLER_INFO</c> value that receives a pointer to a DOMAIN_CONTROLLER_INFO structure that contains
	/// data about the domain controller selected. This structure is allocated by <c>DsGetDcName</c>. The caller must free the structure
	/// using the NetApiBufferFree function when it is no longer required.
	/// </param>
	/// <returns>
	/// <para>If the function returns domain controller data, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DsGetDcName</c> function is sent to the Netlogon service on the remote computer specified by ComputerName. If ComputerName
	/// is <c>NULL</c>, the function is processed on the local computer.
	/// </para>
	/// <para>
	/// <c>DsGetDcName</c> does not verify that the domain controller name returned is the name of an actual domain controller or global
	/// catalog. If mutual authentication is required, the caller must perform the authentication.
	/// </para>
	/// <para>
	/// <c>DsGetDcName</c> does not require any particular access to the specified domain. By default, this function does not ensure that
	/// the returned domain controller is currently available. Instead, the caller should attempt to use the returned domain controller.
	/// If the domain controller is not available, the caller should call the <c>DsGetDcName</c> function again, specifying the
	/// <c>DS_FORCE_REDISCOVERY</c> flag.
	/// </para>
	/// <para>Response Time</para>
	/// <para>When using <c>DsGetDcName</c> be aware of the following timing details:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <c>DsGetDcName</c> makes network calls and can take from a few seconds up to one minute, depending on network traffic, topology,
	/// DC load, and so on.
	/// </term>
	/// </item>
	/// <item>
	/// <term>It is NOT recommended to call <c>DsGetDcName</c> from a UI or other timing critical thread.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The DC Locator does use optimized logic to provide the DC information as quickly as possible. It also uses cached information at
	/// the site to contact the closest DC.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Notes on Domain Controller Stickiness</para>
	/// <para>
	/// In Active Directory Domain Services, the domain controller locator function is designed so that once a client finds a preferred
	/// domain controller, the client will not look for another unless that domain controller stops responding or the client is
	/// restarted. This is referred to as "Domain Controller Stickiness." Because workstations typically operate for months without a
	/// problem or restart, one unintended consequence of this behavior is that if a particular domain controller goes down for
	/// maintenance, all of the clients that were connected to it shift their connections to another domain controller. But when the
	/// domain controller comes back up, no clients ever reconnect to it because the clients do not restart very often. This can cause
	/// load-balancing problems.
	/// </para>
	/// <para>
	/// Previously, the most common solution to this problem was to deploy a script on each client machine that periodically called
	/// <c>DsGetDcName</c> using the flag. This was a somewhat cumbersome solution, so Windows Server 2008 and Windows Vista introduced a
	/// new mechanism that caused issues with domain controller stickiness.
	/// </para>
	/// <para>
	/// Whenever <c>DsGetDcName</c> retrieves a domain controller name from its cache, it checks to see if this cached entry is expired,
	/// and if so, discards that domain controller name and tries to rediscover a domain controller name. The life span of a cached entry
	/// is controlled by the value in the following registry keys
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE</c>&lt;b&gt;SYSTEM&lt;b&gt;CurrentControlSet&lt;b&gt;Services&lt;b&gt;Netlogon&lt;b&gt;Parameters&lt;b&gt;ForceRediscoveryInterval</para>
	/// <para>and</para>
	/// <para><c>HKEY_LOCAL_MACHINE</c>&lt;b&gt;Software&lt;b&gt;Policies&lt;b&gt;Microsoft&lt;b&gt;Netlogon&lt;b&gt;Parameters&lt;b&gt;ForceRediscoveryInterval</para>
	/// <para>
	/// The values in these registry keys are of type <c>REG_DWORD</c>. They specify the length in seconds before <c>DsGetDcName</c>
	/// should try to rediscover the domain controller name. The default value is 43200 seconds (12 hours). If the value of the
	/// <c>ForceRediscoveryInterval</c> registry entry is set to 0, the client always performs rediscovery. If the value is set to
	/// 4294967295, the cache never expires, and the cached domain controller continues to be used. We recommend that you do not set the
	/// <c>ForceRediscoveryInterval</c> registry entry to a value that is less than 3600 seconds (60 minutes).
	/// </para>
	/// <para>
	/// <c>Note</c> The registry settings of <c>ForceRediscoveryInterval</c> are group policy enabled. If you disable the policy setting,
	/// Force Rediscovery will used by default for the machine at every 12 hour interval. If you do not configure this policy setting,
	/// Force Rediscovery will used by default for the machine at every 12 hour interval, unless the local machine setting in the
	/// registry is a different value.
	/// </para>
	/// <para>
	/// Note that if the <c>DS_BACKGROUND_ONLY</c> flag is specified, <c>DsGetDcName</c> will never try to rediscover the domain
	/// controller name, since the point of that flag is to force <c>DsGetDcName</c> to use the cached domain controller name even if it
	/// is expired.
	/// </para>
	/// <para>ETW Tracing in DsGetDcName</para>
	/// <para>To turn on ETW Tracing for <c>DsGetDcName</c>, create the following registry key:</para>
	/// <para><c>HKEY_LOCAL_MACHINE</c>&lt;b&gt;System&lt;b&gt;CurrentControlSet&lt;b&gt;Services&lt;b&gt;DCLocator&lt;b&gt;Tracing</para>
	/// <para>The key will have a structure as follows:</para>
	/// <para>
	/// ProcessName must be the full name including extension of the process that you want to get trace information for. PID is only
	/// required when multiple processes with the same name exist. If it is defined, then only the process with that PID will be enabled
	/// for tracing. It is not possible to trace only 2 out of 3 (or more) processes with the same name. You can enable one instance or
	/// all instances (when multiple instances with the same process name exist and PID is not specified, all instances will be enabled
	/// for tracing).
	/// </para>
	/// <para>
	/// For example, this would trace all instances of App1.exe and App2.exe, but only the instance of App3.exe that has a PID of 999:
	/// </para>
	/// <para>Run the following command to start the tracing session:</para>
	/// <para><c>tracelog.exe -start &lt;sessionname&gt; -guid #cfaa5446-c6c4-4f5c-866f-31c9b55b962d -f &lt;filename&gt; -flag &lt;traceFlags&gt;</c></para>
	/// <para>
	/// sessionname is the name given for the trace session. The guid for the DCLocator tracing provider is
	/// "cfaa5446-c6c4-4f5c-866f-31c9b55b962d". filename is the name of the log file to which the events are written. traceFlags is one
	/// or more of the following flags which signify which areas to trace:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Hex Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DCLOCATOR_MISC</term>
	/// <term>0x00000002</term>
	/// <term>Miscellaneous debugging</term>
	/// </item>
	/// <item>
	/// <term>DCLOCATOR_MAILSLOT</term>
	/// <term>0x00000010</term>
	/// <term>Mailslot messages</term>
	/// </item>
	/// <item>
	/// <term>DCLOCATOR_SITE</term>
	/// <term>0x00000020</term>
	/// <term>Sites</term>
	/// </item>
	/// <item>
	/// <term>DCLOCATOR_CRITICAL</term>
	/// <term>0x00000100</term>
	/// <term>Important errors</term>
	/// </item>
	/// <item>
	/// <term>DCLOCATOR_SESSION_SETUP</term>
	/// <term>0x00000200</term>
	/// <term>Trusted Domain Maintenance</term>
	/// </item>
	/// <item>
	/// <term>DCLOCATOR_DNS</term>
	/// <term>0x00004000</term>
	/// <term>Name Registration</term>
	/// </item>
	/// <item>
	/// <term>DCLOCATOR_DNS_MORE</term>
	/// <term>0x00020000</term>
	/// <term>Verbose Name Registration</term>
	/// </item>
	/// <item>
	/// <term>DCLOCATOR_MAILBOX_TEXT</term>
	/// <term>0x02000000</term>
	/// <term>Verbose Mailbox Messages</term>
	/// </item>
	/// <item>
	/// <term>DCLOCATOR_SITE_MORE</term>
	/// <term>0x08000000</term>
	/// <term>Verbose sites</term>
	/// </item>
	/// </list>
	/// <para>Run the following command to stop the trace session:</para>
	/// <para><c>tracelog.exe -stop &lt;sessionname&gt;</c></para>
	/// <para>sessionname is the same name as the name you used when starting the session.</para>
	/// <para>
	/// <c>Note</c> The registry key for the process being traced must be present in the registry at the time the trace session is
	/// started. When the session starts, the process will verify whether or not it should be generating trace messages (based on the
	/// presence or absence of a registry key for that process name and optional PID). The process checks the registry only at the start
	/// of the session. Any changes in the registry occurring after that will not have any effect on tracing.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetdcnamea
	// DSGETDCAPI DWORD DsGetDcNameA( IN LPCSTR ComputerName, IN LPCSTR DomainName, IN GUID *DomainGuid, IN LPCSTR SiteName, IN ULONG Flags, OUT PDOMAIN_CONTROLLER_INFOA *DomainControllerInfo );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "da8b2983-5e45-40b0-b552-c9b3a1d8ae94")]
	public static extern Win32Error DsGetDcName([Optional] string? ComputerName, [Optional] string? DomainName, in Guid DomainGuid,
		[Optional] string? SiteName, DsGetDcNameFlags Flags, out SafeNetApiBuffer DomainControllerInfo);

	/// <summary>
	/// The DsGetDcName function returns the name of a domain controller in a specified domain. This function accepts additional domain
	/// controller selection criteria to indicate preference for a domain controller with particular characteristics.
	/// </summary>
	/// <param name="ComputerName">
	/// Pointer to a null-terminated string that specifies the name of the server to process this function. Typically, this parameter is
	/// NULL, which indicates that the local computer is used.
	/// </param>
	/// <param name="DomainName">
	/// Pointer to a null-terminated string that specifies the name of the domain or application partition to query. This name can either
	/// be a DNS style name, for example, fabrikam.com, or a flat-style name, for example, Fabrikam. If a DNS style name is specified,
	/// the name may be specified with or without a trailing period.
	/// <para>
	/// If the Flags parameter contains the DS_GC_SERVER_REQUIRED flag, DomainName must be the name of the forest. In this case,
	/// DsGetDcName fails if DomainName specifies a name that is not the forest root.
	/// </para>
	/// <para>
	/// If the Flags parameter contains the DS_GC_SERVER_REQUIRED flag and DomainName is NULL, DsGetDcName attempts to find a global
	/// catalog in the forest of the computer identified by ComputerName, which is the local computer if ComputerName is NULL.
	/// </para>
	/// <para>
	/// If DomainName is NULL and the Flags parameter does not contain the DS_GC_SERVER_REQUIRED flag, ComputerName is set to the default
	/// domain name of the primary domain of the computer identified by ComputerName.
	/// </para>
	/// </param>
	/// <param name="DomainGuid">
	/// Pointer to a GUID structure that specifies the GUID of the domain queried. If DomainGuid is not NULL and the domain specified by
	/// DomainName or ComputerName cannot be found, DsGetDcName attempts to locate a domain controller in the domain having the GUID
	/// specified by DomainGuid.
	/// </param>
	/// <param name="SiteName">
	/// Pointer to a null-terminated string that specifies the name of the site where the returned domain controller should physically
	/// exist. If this parameter is NULL, DsGetDcName attempts to return a domain controller in the site closest to the site of the
	/// computer specified by ComputerName. This parameter should be NULL, by default.
	/// </param>
	/// <param name="Flags">
	/// Contains a set of flags that provide additional data used to process the request. This parameter can be a combination of the
	/// following values.
	/// </param>
	/// <param name="DomainControllerInfo">
	/// Pointer to a PDOMAIN_CONTROLLER_INFO value that receives a pointer to a DOMAIN_CONTROLLER_INFO structure that contains data about
	/// the domain controller selected. This structure is allocated by DsGetDcName. The caller must free the structure using the
	/// NetApiBufferFree function when it is no longer required.
	/// </param>
	/// <returns>
	/// If the function returns domain controller data, the return value is ERROR_SUCCESS.
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// </returns>
	[DllImport(Lib.NetApi32, CharSet = CharSet.Auto)]
	[PInvokeData("DsGetDC.h", MSDNShortId = "ms675983")]
	public static extern Win32Error DsGetDcName([Optional] string? ComputerName, [Optional] string? DomainName, [Optional] GuidPtr DomainGuid,
		[Optional] string? SiteName, DsGetDcNameFlags Flags, out SafeNetApiBuffer DomainControllerInfo);

	/// <summary>
	/// <para>The <c>DsGetDcNext</c> function retrieves the next domain controller in a domain controller enumeration operation.</para>
	/// </summary>
	/// <param name="GetDcContextHandle">
	/// <para>Contains the domain controller enumeration context handle provided by the DsGetDcOpen function.</para>
	/// </param>
	/// <param name="SockAddressCount">
	/// <para>
	/// Pointer to a <c>ULONG</c> value that receives the number of elements in the SockAddresses array. If this parameter is
	/// <c>NULL</c>, socket addresses are not retrieved.
	/// </para>
	/// </param>
	/// <param name="SockAddresses">
	/// <para>
	/// Pointer to an array of SOCKET_ADDRESS structures that receives the socket address data for the domain controller.
	/// SockAddressCount receives the number of elements in this array.
	/// </para>
	/// <para>
	/// All returned addresses will be of type <c>AF_INET</c> or <c>AF_INET6</c>. The <c>sin_port</c> member contains the port from the
	/// server record. A port of 0 indicates no port is available from DNS.
	/// </para>
	/// <para>The caller must free this memory when it is no longer required by calling LocalFree.</para>
	/// <para>This parameter is ignored if SockAddressCount is <c>NULL</c>.</para>
	/// </param>
	/// <param name="DnsHostName">
	/// <para>
	/// Pointer to a string pointer that receives the DNS name of the domain controller. This parameter receives <c>NULL</c> if no host
	/// name is known. The caller must free this memory when it is no longer required by calling NetApiBufferFree.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error otherwise. Possible error values include the following.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To reset the enumeration, close the current enumeration by calling DsGetDcClose and then reopen the enumeration by calling
	/// DsGetDcOpen again.
	/// </para>
	/// <para>
	/// The DC returned by <c>DsGetDcNext</c> will not be a Read-only DC (RODC) because those DCs only register site-specific and CName
	/// records, and both <c>DsGetDcNext</c> and DsGetDcOpen look for DNS SRV records.
	/// </para>
	/// <para>The following procedure shows how to get a complete DC list from a computer running Windows Server 2008.</para>
	/// <para><c>To obtain a complete list of domain controllers</c></para>
	/// <list type="number">
	/// <item>
	/// <term>Use DsGetDcName to get a domain controller name.</term>
	/// </item>
	/// <item>
	/// <term>Use DsBind to connect to that domain controller.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Call DsGetDomainControllerInfo with InfoLevel 3 ( <c>DS_DOMAIN_CONTROLLER_INFO_3</c>) to get the complete list, including RODCs.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/Dsgetdc/nf-dsgetdc-dsgetdcnexta DSGETDCAPI DWORD DsGetDcNextA( IN HANDLE
	// GetDcContextHandle, OUT PULONG SockAddressCount, OUT LPSOCKET_ADDRESS *SockAddresses, OUT LPSTR *DnsHostName );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "2906772f-4391-411b-b0a9-5a20ebb6c0ee")]
	public static extern Win32Error DsGetDcNext(SafeDCEnumHandle GetDcContextHandle, out uint SockAddressCount,
		out SafeLocalHandle SockAddresses, out SafeNetApiBuffer DnsHostName);

	/// <summary>
	/// <para>The <c>DsGetDcOpen</c> function opens a new domain controller enumeration operation.</para>
	/// </summary>
	/// <param name="DnsName">
	/// <para>
	/// Pointer to a null-terminated string that contains the domain naming system (DNS) name of the domain to enumerate the domain
	/// controllers for. This parameter cannot be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="OptionFlags">
	/// <para>
	/// Contains a set of flags that modify the behavior of the function. This can be zero or a combination of one or more of the
	/// following values.
	/// </para>
	/// <para>DS_ONLY_DO_SITE_NAME</para>
	/// <para>Only site-specific domain controllers are enumerated.</para>
	/// <para>DS_NOTIFY_AFTER_SITE_RECORDS</para>
	/// <para>
	/// The DsGetDcNext function will return the <c>ERROR_FILEMARK_DETECTED</c> value after all of the site-specific domain controllers
	/// are retrieved. <c>DsGetDcNext</c> will then enumerate the second group, which contains all domain controllers in the domain,
	/// including the site-specific domain controllers contained in the first group.
	/// </para>
	/// </param>
	/// <param name="SiteName">
	/// <para>
	/// Pointer to a null-terminated string that contains the name of site the client is in. This parameter is optional and may be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="DomainGuid">
	/// <para>
	/// Pointer to a <c>GUID</c> value that contains the identifier of the domain specified by DnsName. This identifier is used to handle
	/// the case of a renamed domain. If this value is specified and the domain specified in DnsName is renamed, this function attempts
	/// to enumerate domain controllers in the domain that contains the specified identifier. This parameter is optional and may be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="DnsForestName">
	/// <para>
	/// Pointer to a null-terminated string that contains the name of the forest that contains the DnsName domain. This value is used in
	/// conjunction with DomainGuidto enumerate the domain controllers if the domain has been renamed. This parameter is optional and may
	/// be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="DcFlags">
	/// <para>
	/// Contains a set of flags that identify the type of domain controllers to enumerate. This can be zero or a combination of one or
	/// more of the following values.
	/// </para>
	/// <para>DS_FORCE_REDISCOVERY</para>
	/// <para>
	/// Forces cached domain controller data to be ignored. When this flag is not specified, <c>DsGetDcOpen</c> obtains the domain
	/// controller enumeration from cached domain controller data.
	/// </para>
	/// <para>DS_GC_SERVER_REQUIRED</para>
	/// <para>
	/// Requires that the enumerated domain controllers be global catalog servers for the forest of domains with this domain as the root.
	/// This flag cannot be combined with the <c>DS_PDC_REQUIRED</c> flag.
	/// </para>
	/// <para>DS_KDC_REQUIRED</para>
	/// <para>
	/// Requires that the enumerated domain controllers currently be running the Kerberos Key Distribution Center service. This flag
	/// cannot be combined with the <c>DS_PDC_REQUIRED</c> or <c>DS_GC_SERVER_REQUIRED</c> flags.
	/// </para>
	/// <para>DS_ONLY_LDAP_NEEDED</para>
	/// <para>
	/// Specifies that the enumerated servers are LDAP servers. The servers are not necessarily domain controllers. No other services are
	/// implied to be present at each enumerated server. The servers do not necessarily have a writable <c>config</c> container nor a
	/// writable <c>schema</c> container. The servers may not necessarily be used to create or modify security principles. This flag may
	/// be used with the <c>DS_GC_SERVER_REQUIRED</c> flag to enumerate LDAP servers that also host a global catalog server. In that
	/// case, the enumerated global catalog servers are not necessarily domain controllers and other services are implied to be present
	/// at each server. If this flag is specified, the <c>DS_PDC_REQUIRED</c>, <c>DS_TIMESERV_REQUIRED</c>,
	/// <c>DS_GOOD_TIMESERV_PREFERRED</c>, <c>DS_DIRECTORY_SERVICES_PREFERED</c>, <c>DS_DIRECTORY_SERVICES_REQUIRED</c>, and
	/// <c>DS_KDC_REQUIRED</c> flags are ignored.
	/// </para>
	/// <para>DS_PDC_REQUIRED</para>
	/// <para>
	/// Requires that the enumerated domain controllers be the primary domain controllers for the domain. This flag cannot be combined
	/// with the <c>DS_GC_SERVER_REQUIRED</c> flag.
	/// </para>
	/// </param>
	/// <param name="RetGetDcContext">
	/// <para>
	/// Pointer to a <c>HANDLE</c> value that receives the domain controller enumeration context handle. This handle is used with the
	/// DsGetDcNext function to identify the domain controller enumeration operation. This handle is passed to DsGetDcClose to close the
	/// domain controller enumeration operation.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error otherwise. Possible error values include the following.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetdcopena DSGETDCAPI DWORD DsGetDcOpenA( IN LPCSTR
	// DnsName, IN ULONG OptionFlags, IN LPCSTR SiteName, IN GUID *DomainGuid, IN LPCSTR DnsForestName, IN ULONG DcFlags, OUT PHANDLE
	// RetGetDcContext );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "2811cc30-f367-4f1a-8f0c-ed0a77dad24c")]
	public static extern Win32Error DsGetDcOpen(string DnsName, DsGetDcOpenOptions OptionFlags, [Optional] string? SiteName, in Guid DomainGuid,
		[Optional] string? DnsForestName, DsGetDcNameFlags DcFlags, out SafeDCEnumHandle RetGetDcContext);

	/// <summary>
	/// <para>The <c>DsGetDcOpen</c> function opens a new domain controller enumeration operation.</para>
	/// </summary>
	/// <param name="DnsName">
	/// <para>
	/// Pointer to a null-terminated string that contains the domain naming system (DNS) name of the domain to enumerate the domain
	/// controllers for. This parameter cannot be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="OptionFlags">
	/// <para>
	/// Contains a set of flags that modify the behavior of the function. This can be zero or a combination of one or more of the
	/// following values.
	/// </para>
	/// <para>DS_ONLY_DO_SITE_NAME</para>
	/// <para>Only site-specific domain controllers are enumerated.</para>
	/// <para>DS_NOTIFY_AFTER_SITE_RECORDS</para>
	/// <para>
	/// The DsGetDcNext function will return the <c>ERROR_FILEMARK_DETECTED</c> value after all of the site-specific domain controllers
	/// are retrieved. <c>DsGetDcNext</c> will then enumerate the second group, which contains all domain controllers in the domain,
	/// including the site-specific domain controllers contained in the first group.
	/// </para>
	/// </param>
	/// <param name="SiteName">
	/// <para>
	/// Pointer to a null-terminated string that contains the name of site the client is in. This parameter is optional and may be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="DomainGuid">
	/// <para>
	/// Pointer to a <c>GUID</c> value that contains the identifier of the domain specified by DnsName. This identifier is used to handle
	/// the case of a renamed domain. If this value is specified and the domain specified in DnsName is renamed, this function attempts
	/// to enumerate domain controllers in the domain that contains the specified identifier. This parameter is optional and may be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="DnsForestName">
	/// <para>
	/// Pointer to a null-terminated string that contains the name of the forest that contains the DnsName domain. This value is used in
	/// conjunction with DomainGuidto enumerate the domain controllers if the domain has been renamed. This parameter is optional and may
	/// be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="DcFlags">
	/// <para>
	/// Contains a set of flags that identify the type of domain controllers to enumerate. This can be zero or a combination of one or
	/// more of the following values.
	/// </para>
	/// <para>DS_FORCE_REDISCOVERY</para>
	/// <para>
	/// Forces cached domain controller data to be ignored. When this flag is not specified, <c>DsGetDcOpen</c> obtains the domain
	/// controller enumeration from cached domain controller data.
	/// </para>
	/// <para>DS_GC_SERVER_REQUIRED</para>
	/// <para>
	/// Requires that the enumerated domain controllers be global catalog servers for the forest of domains with this domain as the root.
	/// This flag cannot be combined with the <c>DS_PDC_REQUIRED</c> flag.
	/// </para>
	/// <para>DS_KDC_REQUIRED</para>
	/// <para>
	/// Requires that the enumerated domain controllers currently be running the Kerberos Key Distribution Center service. This flag
	/// cannot be combined with the <c>DS_PDC_REQUIRED</c> or <c>DS_GC_SERVER_REQUIRED</c> flags.
	/// </para>
	/// <para>DS_ONLY_LDAP_NEEDED</para>
	/// <para>
	/// Specifies that the enumerated servers are LDAP servers. The servers are not necessarily domain controllers. No other services are
	/// implied to be present at each enumerated server. The servers do not necessarily have a writable <c>config</c> container nor a
	/// writable <c>schema</c> container. The servers may not necessarily be used to create or modify security principles. This flag may
	/// be used with the <c>DS_GC_SERVER_REQUIRED</c> flag to enumerate LDAP servers that also host a global catalog server. In that
	/// case, the enumerated global catalog servers are not necessarily domain controllers and other services are implied to be present
	/// at each server. If this flag is specified, the <c>DS_PDC_REQUIRED</c>, <c>DS_TIMESERV_REQUIRED</c>,
	/// <c>DS_GOOD_TIMESERV_PREFERRED</c>, <c>DS_DIRECTORY_SERVICES_PREFERED</c>, <c>DS_DIRECTORY_SERVICES_REQUIRED</c>, and
	/// <c>DS_KDC_REQUIRED</c> flags are ignored.
	/// </para>
	/// <para>DS_PDC_REQUIRED</para>
	/// <para>
	/// Requires that the enumerated domain controllers be the primary domain controllers for the domain. This flag cannot be combined
	/// with the <c>DS_GC_SERVER_REQUIRED</c> flag.
	/// </para>
	/// </param>
	/// <param name="RetGetDcContext">
	/// <para>
	/// Pointer to a <c>HANDLE</c> value that receives the domain controller enumeration context handle. This handle is used with the
	/// DsGetDcNext function to identify the domain controller enumeration operation. This handle is passed to DsGetDcClose to close the
	/// domain controller enumeration operation.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error otherwise. Possible error values include the following.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetdcopena DSGETDCAPI DWORD DsGetDcOpenA( IN LPCSTR
	// DnsName, IN ULONG OptionFlags, IN LPCSTR SiteName, IN GUID *DomainGuid, IN LPCSTR DnsForestName, IN ULONG DcFlags, OUT PHANDLE
	// RetGetDcContext );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "2811cc30-f367-4f1a-8f0c-ed0a77dad24c")]
	public static extern Win32Error DsGetDcOpen(string DnsName, DsGetDcOpenOptions OptionFlags, [Optional] string? SiteName,
		[Optional] GuidPtr DomainGuid, [Optional] string? DnsForestName, DsGetDcNameFlags DcFlags, out SafeDCEnumHandle RetGetDcContext);

	/// <summary>
	/// <para>The <c>DsGetDcSiteCoverage</c> function returns the site names of all sites covered by a domain controller.</para>
	/// </summary>
	/// <param name="ServerName">
	/// <para>The null-terminated string value that specifies the name of the remote domain controller.</para>
	/// </param>
	/// <param name="EntryCount">
	/// <para>Pointer to a <c>ULONG</c> value that receives the number of sites covered by the domain controller.</para>
	/// </param>
	/// <param name="SiteNames">
	/// <para>
	/// Pointer to an array of pointers to null-terminated strings that receives the site names. To free the returned buffer, call the
	/// NetApiBufferFree function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>This function returns DSGETDCAPI DWORD.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetdcsitecoveragew DSGETDCAPI DWORD
	// DsGetDcSiteCoverageW( IN LPCWSTR ServerName, OUT PULONG EntryCount, OUT LPWSTR **SiteNames );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "e0f757d9-36b6-40f8-a1db-fb5b9862b46a")]
	public static extern Win32Error DsGetDcSiteCoverage([Optional] string? ServerName, out uint EntryCount, out SafeNetApiBuffer SiteNames);

	/// <summary>
	/// <para>The <c>DsGetForestTrustInformationW</c> function obtains forest trust data for a specified domain.</para>
	/// </summary>
	/// <param name="ServerName">
	/// <para>
	/// Contains the name of the domain controller that <c>DsGetForestTrustInformationW</c> is connected to remotely. The caller must be
	/// an authenticated user on this server. If this parameter is <c>NULL</c>, the local server is used.
	/// </para>
	/// </param>
	/// <param name="TrustedDomainName">
	/// <para>
	/// Contains the NETBIOS or DNS name of the trusted domain that the forest trust data is to be retrieved for. This domain must have
	/// the <c>TRUST_ATTRIBUTE_FOREST_TRANSITIVE</c> trust attribute. For more information, see TRUSTED_DOMAIN_INFORMATION_EX.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, the forest trust data for the domain hosted by ServerName is retrieved.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Contains a set of flags that modify the behavior of this function. This can be zero or the following value.</para>
	/// <para>DS_GFTI_UPDATE_TDO</para>
	/// <para>
	/// If this flag is set, <c>DsGetForestTrustInformationW</c> will update the forest trust data of the trusted domain identified by
	/// the TrustedDomainNameparameter. In this case, the TrustedDomainName parameter cannot be <c>NULL</c>. The caller must have access
	/// to modify the trust data or <c>ERROR_ACCESS_DENIED</c> is returned.
	/// </para>
	/// <para>This flag is only valid if ServerName specifies the primary domain controller of the domain.</para>
	/// </param>
	/// <param name="ForestTrustInfo">
	/// <para>
	/// Pointer to an LSA_FOREST_TRUST_INFORMATION structure pointer that receives the forest trust data that describes the namespaces
	/// claimed by the domain specified by TrustedDomainName. The <c>Time</c> member of all returned records will be zero.
	/// </para>
	/// <para>The caller must free this structure when it is no longer required by calling NetApiBufferFree.</para>
	/// </param>
	/// <returns>
	/// <para>Returns <c>NO_ERROR</c> if successful or a Win32 error code otherwise. Possible error codes include the following.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetforesttrustinformationw DSGETDCAPI DWORD
	// DsGetForestTrustInformationW( IN LPCWSTR ServerName, IN LPCWSTR TrustedDomainName, IN DWORD Flags, OUT
	// PLSA_FOREST_TRUST_INFORMATION *ForestTrustInfo );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "c94fdc5b-920b-4807-9cbf-3172ec1c7386")]
	public static extern Win32Error DsGetForestTrustInformationW([Optional] string? ServerName, [Optional] string? TrustedDomainName,
		DsGetForestTrustInformationFlags Flags, out SafeNetApiBuffer ForestTrustInfo);

	/// <summary>
	/// <para>
	/// The <c>DsGetSiteName</c> function returns the name of the site where a computer resides. For a domain controller (DC), the name
	/// of the site is the location of the configured DC. For a member workstation or member server, the name specifies the workstation
	/// site as configured in the domain of the computer.
	/// </para>
	/// </summary>
	/// <param name="ComputerName">
	/// <para>
	/// Pointer to a null-terminated string that specifies the name of the server to send this function. A <c>NULL</c> implies the local computer.
	/// </para>
	/// </param>
	/// <param name="SiteName">
	/// <para>
	/// Pointer to a variable that receives a pointer to a null-terminated string specifying the site location of this computer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function returns account information, the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DsGetSiteName</c> function does not require any particular access to the specified domain. The function is sent to the
	/// "NetLogon" service on the computer specified by ComputerName.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetsitenamea DSGETDCAPI DWORD DsGetSiteNameA( IN LPCSTR
	// ComputerName, OUT LPSTR *SiteName );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "2dfffd9a-af4f-4a93-8b3c-966e4f7c455f")]
	public static extern Win32Error DsGetSiteName([Optional] string? ComputerName,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NetApiBufferUnicodeStringMarshaler))] out string SiteName);

	/// <summary>
	/// <para>
	/// The <c>DsMergeForestTrustInformationW</c> function merges the changes from a new forest trust data structure with an old forest
	/// trust data structure.
	/// </para>
	/// </summary>
	/// <param name="DomainName">
	/// <para>Pointer to a null-terminated Unicode string that specifies the trusted domain to update.</para>
	/// </param>
	/// <param name="NewForestTrustInfo">
	/// <para>
	/// Pointer to an <c>LSA_FOREST_TRUST_INFORMATION</c> structure that contains the new forest trust data to be merged. The
	/// <c>Flags</c> and <c>Time</c> members of the entries are ignored.
	/// </para>
	/// </param>
	/// <param name="OldForestTrustInfo">
	/// <para>
	/// Pointer to an <c>LSA_FOREST_TRUST_INFORMATION</c> structure that contains the old forest trust data to be merged. This parameter
	/// may be <c>NULL</c> if no records exist.
	/// </para>
	/// </param>
	/// <param name="MergedForestTrustInfo">
	/// <para>Pointer to an <c>LSA_FOREST_TRUST_INFORMATION</c> structure pointer that receives the merged forest trust data.</para>
	/// <para>The caller must free this structure when it is no longer required by calling NetApiBufferFree.</para>
	/// </param>
	/// <returns>
	/// <para>Returns <c>NO_ERROR</c> if successful or a Windows error code otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsmergeforesttrustinformationw DSGETDCAPI DWORD
	// DsMergeForestTrustInformationW( IN LPCWSTR DomainName, IN PLSA_FOREST_TRUST_INFORMATION NewForestTrustInfo, IN
	// PLSA_FOREST_TRUST_INFORMATION OldForestTrustInfo, OUT PLSA_FOREST_TRUST_INFORMATION *MergedForestTrustInfo );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "f42e16d0-62b2-49c4-b182-d1e744afe58c")]
	public static extern Win32Error DsMergeForestTrustInformationW(string DomainName, in LSA_FOREST_TRUST_INFORMATION NewForestTrustInfo,
		in LSA_FOREST_TRUST_INFORMATION OldForestTrustInfo, out SafeNetApiBuffer MergedForestTrustInfo);

	/// <summary>
	/// <para>
	/// The <c>DsMergeForestTrustInformationW</c> function merges the changes from a new forest trust data structure with an old forest
	/// trust data structure.
	/// </para>
	/// </summary>
	/// <param name="DomainName">
	/// <para>Pointer to a null-terminated Unicode string that specifies the trusted domain to update.</para>
	/// </param>
	/// <param name="NewForestTrustInfo">
	/// <para>
	/// Pointer to an <c>LSA_FOREST_TRUST_INFORMATION</c> structure that contains the new forest trust data to be merged. The
	/// <c>Flags</c> and <c>Time</c> members of the entries are ignored.
	/// </para>
	/// </param>
	/// <param name="OldForestTrustInfo">
	/// <para>
	/// Pointer to an <c>LSA_FOREST_TRUST_INFORMATION</c> structure that contains the old forest trust data to be merged. This parameter
	/// may be <c>NULL</c> if no records exist.
	/// </para>
	/// </param>
	/// <param name="MergedForestTrustInfo">
	/// <para>Pointer to an <c>LSA_FOREST_TRUST_INFORMATION</c> structure pointer that receives the merged forest trust data.</para>
	/// <para>The caller must free this structure when it is no longer required by calling NetApiBufferFree.</para>
	/// </param>
	/// <returns>
	/// <para>Returns <c>NO_ERROR</c> if successful or a Windows error code otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsmergeforesttrustinformationw DSGETDCAPI DWORD
	// DsMergeForestTrustInformationW( IN LPCWSTR DomainName, IN PLSA_FOREST_TRUST_INFORMATION NewForestTrustInfo, IN
	// PLSA_FOREST_TRUST_INFORMATION OldForestTrustInfo, OUT PLSA_FOREST_TRUST_INFORMATION *MergedForestTrustInfo );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "f42e16d0-62b2-49c4-b182-d1e744afe58c")]
	public static extern Win32Error DsMergeForestTrustInformationW(string DomainName, in LSA_FOREST_TRUST_INFORMATION NewForestTrustInfo,
		[Optional] IntPtr OldForestTrustInfo, out SafeNetApiBuffer MergedForestTrustInfo);

	/// <summary>
	/// <para>
	/// The <c>DsValidateSubnetName</c> function validates a subnet name in the form xxx.xxx.xxx.xxx/YY. The Xxx.xxx.xxx.xxx portion must
	/// be a valid IP address. Yy must be the number of leftmost significant bits included in the mask. All bits of the IP address that
	/// are not covered by the mask must be specified as zero.
	/// </para>
	/// </summary>
	/// <param name="SubnetName">
	/// <para>Pointer to a null-terminated string that specifies the name of the subnet to validate.</para>
	/// </param>
	/// <returns>
	/// <para>If the function returns account information, the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, the return value is the following error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsvalidatesubnetnamew DSGETDCAPI DWORD
	// DsValidateSubnetNameW( IN LPCWSTR SubnetName );
	[DllImport(Lib.NetApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("dsgetdc.h", MSDNShortId = "bed49e08-4cb7-439c-bfb7-815263ec7568")]
	public static extern Win32Error DsValidateSubnetName(string SubnetName);

	/// <summary>The DOMAIN_CONTROLLER_INFO structure is used with the DsGetDcName function to receive data about a domain controller.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[PInvokeData("DsGetDC.h", MSDNShortId = "ms675912")]
	public struct DOMAIN_CONTROLLER_INFO
	{
		/// <summary>
		/// Pointer to a null-terminated string that specifies the computer name of the discovered domain controller. The returned
		/// computer name is prefixed with "\\". The DNS-style name, for example, "\\phoenix.fabrikam.com", is returned, if available. If
		/// the DNS-style name is not available, the flat-style name (for example, "\\phoenix") is returned. This example would apply if
		/// the domain is a Windows NT 4.0 domain or if the domain does not support the IP family of protocols.
		/// </summary>
		public string DomainControllerName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the address of the discovered domain controller. The address is prefixed
		/// with "\\". This string is one of the types defined by the DomainControllerAddressType member.
		/// </summary>
		public string DomainControllerAddress;

		/// <summary>Indicates the type of string that is contained in the DomainControllerAddress member.</summary>
		public DomainControllerAddressType DomainControllerAddressType;

		/// <summary>
		/// The GUID of the domain. This member is zero if the domain controller does not have a Domain GUID; for example, the domain
		/// controller is not a Windows 2000 domain controller.
		/// </summary>
		public Guid DomainGuid;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the domain. The DNS-style name, for example, "fabrikam.com",
		/// is returned if available. Otherwise, the flat-style name, for example, "fabrikam", is returned. This name may be different
		/// than the requested domain name if the domain has been renamed.
		/// </summary>
		public string DomainName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the domain at the root of the DS tree. The DNS-style name, for
		/// example, "fabrikam.com", is returned if available. Otherwise, the flat-style name, for example, "fabrikam" is returned.
		/// </summary>
		public string DnsForestName;

		/// <summary>
		/// Contains a set of flags that describe the domain controller. This can be zero or a combination of one or more of the
		/// following values.
		/// </summary>
		public DomainControllerType Flags;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the site where the domain controller is located. This member
		/// may be NULL if the domain controller is not in a site; for example, the domain controller is a Windows NT 4.0 domain controller.
		/// </summary>
		public string? DcSiteName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the site that the computer belongs to. The computer is
		/// specified in the ComputerName parameter passed to DsGetDcName. This member may be NULL if the site that contains the computer
		/// cannot be found; for example, if the DS administrator has not associated the subnet that the computer is in with a valid site.
		/// </summary>
		public string? ClientSiteName;
	}

	/// <summary>
	/// <para>The <c>DS_DOMAIN_TRUSTS</c> structure is used with the DsEnumerateDomainTrusts function to contain trust data for a domain.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/ns-dsgetdc-_ds_domain_trustsa typedef struct _DS_DOMAIN_TRUSTSA {
	// LPSTR NetbiosDomainName; LPSTR DnsDomainName; ULONG Flags; ULONG ParentIndex; ULONG TrustType; ULONG TrustAttributes; PSID
	// DomainSid; GUID DomainGuid; } DS_DOMAIN_TRUSTSA, *PDS_DOMAIN_TRUSTSA;
	[PInvokeData("dsgetdc.h", MSDNShortId = "cd260fd1-dc38-4405-95ba-097a23faf668")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DS_DOMAIN_TRUSTS
	{
		/// <summary>
		/// <para>Pointer to a null-terminated string that contains the NetBIOS name of the domain.</para>
		/// </summary>
		public string NetbiosDomainName;

		/// <summary>
		/// <para>Pointer to a null-terminated string that contains the DNS name of the domain. This member may be <c>NULL</c>.</para>
		/// </summary>
		public string? DnsDomainName;

		/// <summary>
		/// <para>
		/// Contains a set of flags that specify more data about the domain trust. This can be zero or a combination of one or more of
		/// the following values.
		/// </para>
		/// <para>DS_DOMAIN_IN_FOREST (1 (0x1))</para>
		/// <para>
		/// The domain represented by this structure is a member of the same forest as the server specified in the ServerName parameter
		/// of the DsEnumerateDomainTrusts function.
		/// </para>
		/// <para>DS_DOMAIN_DIRECT_OUTBOUND (2 (0x2))</para>
		/// <para>
		/// The domain represented by this structure is directly trusted by the domain that the server specified in the ServerName
		/// parameter of the DsEnumerateDomainTrusts function is a member of.
		/// </para>
		/// <para>DS_DOMAIN_TREE_ROOT (4 (0x4))</para>
		/// <para>
		/// The domain represented by this structure is the root of a tree and a member of the same forest as the server specified in the
		/// ServerName parameter of the DsEnumerateDomainTrusts function.
		/// </para>
		/// <para>DS_DOMAIN_PRIMARY (8 (0x8))</para>
		/// <para>
		/// The domain represented by this structure is the primary domain of the server specified in the ServerName parameter of the
		/// DsEnumerateDomainTrusts function.
		/// </para>
		/// <para>DS_DOMAIN_NATIVE_MODE (16 (0x10))</para>
		/// <para>The domain represented by this structure is running in the Windows 2000 native mode.</para>
		/// <para>DS_DOMAIN_DIRECT_INBOUND (32 (0x20))</para>
		/// <para>
		/// The domain represented by this structure directly trusts the domain that the server specified in the ServerName parameter of
		/// the DsEnumerateDomainTrusts function is a member of.
		/// </para>
		/// </summary>
		public DomainTrustFlag Flags;

		/// <summary>
		/// <para>
		/// Contains the index in the Domains array returned by the DsEnumerateDomainTrusts function that corresponds to the parent
		/// domain of the domain represented by this structure. This member is only valid if the all of the following conditions are met:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The <c>DS_DOMAIN_IN_FOREST</c> flag was specified in the Flags parameter of the DsEnumerateDomainTrusts function.</term>
		/// </item>
		/// <item>
		/// <term>The <c>Flags</c> member of this structure does not contain the <c>DS_DOMAIN_TREE_ROOT</c> flag.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint ParentIndex;

		/// <summary>
		/// <para>
		/// Contains a value that indicates the type of trust represented by this structure. Possible values for this member are
		/// documented in the <c>TrustType</c> member of the TRUSTED_DOMAIN_INFORMATION_EX structure.
		/// </para>
		/// </summary>
		public TrustType TrustType;

		/// <summary>
		/// <para>
		/// Contains a value that indicates the attributes of the trust represented by this structure. Possible values for this member
		/// are documented in the <c>TrustAttribute</c> member of the TRUSTED_DOMAIN_INFORMATION_EX structure.
		/// </para>
		/// </summary>
		public TrustAttributes TrustAttributes;

		/// <summary>
		/// <para>Contains the security identifier of the domain represented by this structure.</para>
		/// </summary>
		public IntPtr DomainSid;

		/// <summary>
		/// <para>Contains the GUID of the domain represented by this structure.</para>
		/// </summary>
		public Guid DomainGuid;
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to a domain controller enumeration handle that is released at disposal using DsGetDcClose.
	/// </summary>
	[AutoSafeHandle("{ DsGetDcClose(handle); return true; }")]
	public partial class SafeDCEnumHandle { }
}