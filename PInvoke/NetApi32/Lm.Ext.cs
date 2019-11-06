using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke
{
	public static partial class NetApi32
	{
		/// <summary>The <c>DsAddressToSiteNamesEx</c> function obtains the site and subnet names corresponding to the addresses specified.</summary>
		/// <param name="ComputerName">
		/// String that specifies the name of the remote server to process this function. This parameter must be the name of a domain
		/// controller. A non-domain controller can call this function by calling DsGetDcName to find the domain controller.
		/// </param>
		/// <param name="SocketAddresses">
		/// Contains an array of SOCKET_ADDRESS structures that contain the addresses to convert. Each address in this array must be of the
		/// type <c>AF_INET</c>.
		/// </param>
		/// <returns>
		/// Returns a list that contains the supplied <c>SOCKET_ADDRESS</c> structure with its corresponding site name and subnet name. An
		/// value is <see langword="null"/> if the corresponding address does not map to any known site or subnet or if the address entry is
		/// not of the proper form.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsaddresstositenamesexa DSGETDCAPI DWORD
		// DsAddressToSiteNamesExA( IN LPCSTR ComputerName, IN DWORD EntryCount, IN PSOCKET_ADDRESS SocketAddresses, OUT LPSTR **SiteNames,
		// OUT LPSTR **SubnetNames );
		[PInvokeData("dsgetdc.h", MSDNShortId = "60ac6195-6e43-46da-a1e6-74ec989cd0c4")]
		public static IEnumerable<(SOCKET_ADDRESS address, string site, string subnet)> DsAddressToSiteNamesEx(string ComputerName, SOCKET_ADDRESS[] SocketAddresses)
		{
			DsAddressToSiteNamesEx(ComputerName, (uint)(SocketAddresses?.Length ?? 0), SocketAddresses, out var sites, out var subnets).ThrowIfFailed();
			return from addr in SocketAddresses
				   from site in sites.ToStringEnum(SocketAddresses.Length)
				   from sub in subnets.ToStringEnum(SocketAddresses.Length)
				   select (addr, site, sub);
		}

		/// <summary>The <c>DsEnumerateDomainTrusts</c> function obtains domain trust data for a specified domain.</summary>
		/// <param name="ServerName">
		/// <para>
		/// A string that specifies the name of a computer in the domain to obtain the trust information for. If this parameter is
		/// <see langword="null"/>, the name of the local computer is used. The caller must be an authenticated user in this domain.
		/// </para>
		/// <para>
		/// If this computer is a domain controller, this function returns the trust data immediately. If this computer is not a domain
		/// controller, this function obtains the trust data from cached data if the cached data is not expired. If the cached data is
		/// expired, this function obtains the trust data from a domain controller in the domain that this computer is a member of and
		/// updates the cache. The cached data automatically expires after five minutes.
		/// </para>
		/// </param>
		/// <param name="Flags">
		/// <para>
		/// Contains a set of flags that determines which domain trusts to enumerate. This can be a combination of one or more of the
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
		/// <para>Enumerate domains that are at the root of the forest which has ServerName as a member.</para>
		/// </param>
		/// <returns>An enumeration of DS_DOMAIN_TRUSTS structures. Each structure in this array contains trust data about a domain.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsenumeratedomaintrustsa DSGETDCAPI DWORD
		// DsEnumerateDomainTrustsA( LPSTR ServerName, ULONG Flags, PDS_DOMAIN_TRUSTSA *Domains, PULONG DomainCount );
		[PInvokeData("dsgetdc.h", MSDNShortId = "6c3b788f-ee53-4637-acdb-04316e8464fe")]
		public static IEnumerable<DS_DOMAIN_TRUSTS> DsEnumerateDomainTrusts(DomainTrustFlag Flags, string ServerName = null)
		{
			DsEnumerateDomainTrusts(ServerName, Flags, out var buf, out var cnt).ThrowIfFailed();
			return buf.ToIEnum<DS_DOMAIN_TRUSTS>((int)cnt);
		}

		/// <summary>The <c>DsGetDcOpen</c> function opens a new domain controller enumeration operation.</summary>
		/// <param name="DnsName">
		/// A string that contains the domain naming system (DNS) name of the domain to enumerate the domain controllers for. This parameter
		/// cannot be <see langword="null"/>.
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
		/// <param name="SiteName">A string that contains the name of site the client is in. This parameter is optional and may be <see langword="null"/>.</param>
		/// <param name="DomainGuid">
		/// An optional <c>GUID</c> value that contains the identifier of the domain specified by DnsName. This identifier is used to handle
		/// the case of a renamed domain. If this value is specified and the domain specified in DnsName is renamed, this function attempts
		/// to enumerate domain controllers in the domain that contains the specified identifier. This parameter is optional and may be <see langword="null"/>.
		/// </param>
		/// <param name="DnsForestName">
		/// A string that contains the name of the forest that contains the DnsName domain. This value is used in conjunction with
		/// DomainGuidto enumerate the domain controllers if the domain has been renamed. This parameter is optional and may be <see langword="null"/>.
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
		/// <returns>An enumeration of domain controllers paired with the socket address data for the domain controller.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetdcopena DSGETDCAPI DWORD DsGetDcOpenA( IN LPCSTR
		// DnsName, IN ULONG OptionFlags, IN LPCSTR SiteName, IN GUID *DomainGuid, IN LPCSTR DnsForestName, IN ULONG DcFlags, OUT PHANDLE
		// RetGetDcContext );
		[PInvokeData("dsgetdc.h", MSDNShortId = "2811cc30-f367-4f1a-8f0c-ed0a77dad24c")]
		public static IEnumerable<(string dnsHostName, SOCKET_ADDRESS[] sockets)> DsGetDcEnum(string DnsName, [Optional] DsGetDcOpenOptions OptionFlags, [Optional] DsGetDcNameFlags DcFlags, [Optional] string SiteName, [Optional] Guid? DomainGuid, [Optional] string DnsForestName)
		{
			SafeDCEnumHandle h;
			if (DomainGuid.HasValue)
				DsGetDcOpen(DnsName, OptionFlags, SiteName, DomainGuid.Value, DnsForestName, DcFlags, out h).ThrowIfFailed();
			else
				DsGetDcOpen(DnsName, OptionFlags, SiteName, IntPtr.Zero, DnsForestName, DcFlags, out h).ThrowIfFailed();
			using (h)
			{
				while (true)
				{
					var err = DsGetDcNext(h, out var addrCnt, out var addr, out var host);
					if (err.Succeeded)
						yield return (host.ToString(), addr.ToArray<SOCKET_ADDRESS>((int)addrCnt));
					else if (err == Win32Error.ERROR_NO_MORE_ITEMS)
						break;
					else if (err == Win32Error.ERROR_FILEMARK_DETECTED)
						continue;
					else
						err.ThrowIfFailed();
				}
			}
		}

		/// <summary>
		/// The <c>DsGetDcName</c> function returns the name of a domain controller in a specified domain. This function accepts additional
		/// domain controller selection criteria to indicate preference for a domain controller with particular characteristics.
		/// </summary>
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
		/// If this flag is set and the DomainName parameter is not <see langword="null"/>, DomainName must specify a forest name. This flag
		/// cannot be combined with the <c>DS_PDC_REQUIRED</c> or <c>DS_KDC_REQUIRED</c> flags.
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
		/// <param name="ComputerName">
		/// A string that specifies the name of the server to process this function. Typically, this parameter is <see langword="null"/>,
		/// which indicates that the local computer is used.
		/// </param>
		/// <param name="DomainName">
		/// <para>
		/// A string that specifies the name of the domain or application partition to query. This name can either be a DNS style name, for
		/// example, fabrikam.com, or a flat-style name, for example, Fabrikam. If a DNS style name is specified, the name may be specified
		/// with or without a trailing period.
		/// </para>
		/// <para>
		/// If the Flags parameter contains the <c>DS_GC_SERVER_REQUIRED</c> flag, DomainName must be the name of the forest. In this case,
		/// <c>DsGetDcName</c> fails if DomainName specifies a name that is not the forest root.
		/// </para>
		/// <para>
		/// If the Flags parameter contains the <c>DS_GC_SERVER_REQUIRED</c> flag and DomainName is <see langword="null"/>,
		/// <c>DsGetDcName</c> attempts to find a global catalog in the forest of the computer identified by ComputerName, which is the local
		/// computer if ComputerName is <see langword="null"/>.
		/// </para>
		/// <para>
		/// If DomainName is <see langword="null"/> and the Flags parameter does not contain the <c>DS_GC_SERVER_REQUIRED</c> flag,
		/// ComputerName is set to the default domain name of the primary domain of the computer identified by ComputerName.
		/// </para>
		/// </param>
		/// <param name="DomainGuid">
		/// An optional Guid value that specifies the <c>GUID</c> of the domain queried. If DomainGuid is not <see langword="null"/> and the
		/// domain specified by DomainName or ComputerName cannot be found, <c>DsGetDcName</c> attempts to locate a domain controller in the
		/// domain having the GUID specified by DomainGuid.
		/// </param>
		/// <param name="SiteName">
		/// A string that specifies the name of the site where the returned domain controller should physically exist. If this parameter is
		/// <see langword="null"/>, <c>DsGetDcName</c> attempts to return a domain controller in the site closest to the site of the computer
		/// specified by ComputerName. This parameter should be <see langword="null"/>, by default.
		/// </param>
		/// <returns>A DOMAIN_CONTROLLER_INFO structure that contains data about the domain controller selected.</returns>
		/// <remarks>
		/// <para>
		/// The <c>DsGetDcName</c> function is sent to the Netlogon service on the remote computer specified by ComputerName. If ComputerName
		/// is <see langword="null"/>, the function is processed on the local computer.
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
		[PInvokeData("dsgetdc.h", MSDNShortId = "da8b2983-5e45-40b0-b552-c9b3a1d8ae94")]
		public static DOMAIN_CONTROLLER_INFO DsGetDcName(DsGetDcNameFlags Flags, [Optional] string ComputerName, [Optional] string DomainName, [Optional] Guid? DomainGuid, [Optional] string SiteName)
		{
			SafeNetApiBuffer buf;
			if (DomainGuid.HasValue)
				DsGetDcName(ComputerName, DomainName, DomainGuid.Value, SiteName, Flags, out buf).ThrowIfFailed();
			else
				DsGetDcName(ComputerName, DomainName, IntPtr.Zero, SiteName, Flags, out buf).ThrowIfFailed();
			return buf.ToStructure<DOMAIN_CONTROLLER_INFO>();
		}

		/// <summary>The <c>DsGetDcSiteCoverage</c> function returns the site names of all sites covered by a domain controller.</summary>
		/// <param name="ServerName">A string value that specifies the name of the remote domain controller.</param>
		/// <returns>An array of strings containing the site names.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetdcsitecoveragea
		[PInvokeData("dsgetdc.h", MSDNShortId = "e0f757d9-36b6-40f8-a1db-fb5b9862b46a")]
		public static IEnumerable<string> DsGetDcSiteCoverage(string ServerName = null)
		{
			DsGetDcSiteCoverage(ServerName, out var c, out var b).ThrowIfFailed();
			return b.ToStringEnum((int)c);
		}

		/// <summary>The <c>DsGetForestTrustInformationW</c> function obtains forest trust data for a specified domain.</summary>
		/// <param name="ServerName">
		/// Contains the name of the domain controller that <c>DsGetForestTrustInformation</c> is connected to remotely. The caller must be
		/// an authenticated user on this server. If this parameter is <see langword="null"/>, the local server is used.
		/// </param>
		/// <param name="TrustedDomainName">
		/// <para>
		/// Contains the NETBIOS or DNS name of the trusted domain that the forest trust data is to be retrieved for. This domain must have
		/// the <c>TRUST_ATTRIBUTE_FOREST_TRANSITIVE</c> trust attribute. For more information, see TRUSTED_DOMAIN_INFORMATION_EX.
		/// </para>
		/// <para>If this parameter is <see langword="null"/>, the forest trust data for the domain hosted by ServerName is retrieved.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Contains a set of flags that modify the behavior of this function. This can be zero or the following value.</para>
		/// <para>DS_GFTI_UPDATE_TDO</para>
		/// <para>
		/// If this flag is set, <c>DsGetForestTrustInformationW</c> will update the forest trust data of the trusted domain identified by
		/// the TrustedDomainNameparameter. In this case, the TrustedDomainName parameter cannot be <see langword="null"/>. The caller must
		/// have access to modify the trust data or <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>This flag is only valid if ServerName specifies the primary domain controller of the domain.</para>
		/// </param>
		/// <returns>
		/// The forest trust data that describes the namespaces claimed by the domain specified by TrustedDomainName. The <c>Time</c> member
		/// of all returned records will be zero.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetforesttrustinformationw
		[PInvokeData("dsgetdc.h", MSDNShortId = "c94fdc5b-920b-4807-9cbf-3172ec1c7386")]
		public static AdvApi32.LsaForestTrustInformation DsGetForestTrustInformation([Optional] string ServerName, [Optional] string TrustedDomainName, DsGetForestTrustInformationFlags Flags = 0)
		{
			DsGetForestTrustInformationW(ServerName, TrustedDomainName, Flags, out var b).ThrowIfFailed();
			return AdvApi32.LsaForestTrustInformation.FromBuffer(b.DangerousGetHandle());
		}

		/// <summary>
		/// The <c>DsMergeForestTrustInformationW</c> function merges the changes from a new forest trust data structure with an old forest
		/// trust data structure.
		/// </summary>
		/// <param name="DomainName">A string that specifies the trusted domain to update.</param>
		/// <param name="NewForestTrustInfo">
		/// A <c>LsaForestTrustInformation</c> instance that contains the new forest trust data to be merged. The <c>Flags</c> and
		/// <c>Time</c> members of the entries are ignored.
		/// </param>
		/// <param name="OldForestTrustInfo">
		/// A <c>LsaForestTrustInformation</c> instance that contains the old forest trust data to be merged. This parameter may be
		/// <see langword="null"/> if no records exist.
		/// </param>
		/// <returns>Returns <c>NO_ERROR</c> if successful or a Windows error code otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsmergeforesttrustinformationw
		[PInvokeData("dsgetdc.h", MSDNShortId = "f42e16d0-62b2-49c4-b182-d1e744afe58c")]
		public static AdvApi32.LsaForestTrustInformation DsMergeForestTrustInformation(string DomainName, [In] AdvApi32.LsaForestTrustInformation NewForestTrustInfo, [In, Optional] AdvApi32.LsaForestTrustInformation OldForestTrustInfo)
		{
			SafeNetApiBuffer buf;
			if (OldForestTrustInfo is null)
				DsMergeForestTrustInformationW(DomainName, NewForestTrustInfo.DangerousGetLSA_FOREST_TRUST_INFORMATION(), IntPtr.Zero, out buf).ThrowIfFailed();
			else
				DsMergeForestTrustInformationW(DomainName, NewForestTrustInfo.DangerousGetLSA_FOREST_TRUST_INFORMATION(), OldForestTrustInfo.DangerousGetLSA_FOREST_TRUST_INFORMATION(), out buf).ThrowIfFailed();
			return AdvApi32.LsaForestTrustInformation.FromBuffer(buf.DangerousGetHandle());
		}

		/// <summary>
		/// The <c>DsRoleGetPrimaryDomainInformation</c> function retrieves state data for the computer. This data includes the state of the
		/// directory service installation and domain data.
		/// </summary>
		/// <param name="lpServer">
		/// Pointer to null-terminated Unicode string that contains the name of the computer on which to call the function. If this
		/// parameter is <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="InfoLevel">
		/// Contains one of the DSROLE_PRIMARY_DOMAIN_INFO_LEVEL values that specify the type of data to retrieve. This parameter also
		/// determines the format of the data supplied in Buffer.
		/// </param>
		/// <returns>
		/// <para>The requested data. The format of this data depends on the value of the InfoLevel parameter.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/nf-dsrole-dsrolegetprimarydomaininformation DWORD
		// DsRoleGetPrimaryDomainInformation( IN LPCWSTR lpServer, IN DSROLE_PRIMARY_DOMAIN_INFO_LEVEL InfoLevel, OUT PBYTE *Buffer );
		[PInvokeData("dsrole.h", MSDNShortId = "d54876e3-a622-4b44-a597-db0f710f7758")]
		public static T DsRoleGetPrimaryDomainInformation<T>([Optional] string lpServer, DSROLE_PRIMARY_DOMAIN_INFO_LEVEL InfoLevel) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet(InfoLevel, typeof(T))) throw new ArgumentException("Type mismatch", nameof(InfoLevel));
			DsRoleGetPrimaryDomainInformation(lpServer, InfoLevel, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>
		/// Lists all connections made to a shared resource on the server or all connections established from a particular computer. If there
		/// is more than one user using this connection, then it is possible to get more than one structure for the same connection, but with
		/// a different user name.
		/// </summary>
		/// <param name="servername">
		/// <para>
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
		/// </param>
		/// <param name="qualifier">
		/// <para>
		/// A string that specifies a share name or computer name for the connections of interest. If it is a share name, then all the
		/// connections made to that share name are listed. If it is a computer name (for example, it starts with two backslash characters),
		/// then <c>NetConnectionEnum</c> lists all connections made from that computer to the server specified.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return connection identifiers. The bufptr parameter is a pointer to an array of CONNECTION_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return connection identifiers and connection information. The bufptr parameter is a pointer to an array of CONNECTION_INFO_1 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>A sequence of the requested type.</returns>
		/// <remarks>
		/// <para>
		/// Administrator, Server or Print Operator, or Power User group membership is required to successfully execute the
		/// <c>NetConnectionEnum</c> function.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to list the connections made to a shared resource with a call to the
		/// <c>NetConnectionEnum</c> function. The sample calls <c>NetConnectionEnum</c>, specifying information level 1 (CONNECTION_INFO_1).
		/// If there are entries to return, it prints the values of the <c>coni1_username</c> and <c>coni1_netname</c> members. If there are
		/// no entries to return, the sample prints an appropriate message. Finally, the code sample frees the memory allocated for the
		/// information buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netconnectionenum NET_API_STATUS NET_API_FUNCTION
		// NetConnectionEnum( LMSTR servername, LMSTR qualifier, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD
		// totalentries, LPDWORD resume_handle );
		[PInvokeData("lmshare.h", MSDNShortId = "935ac6e9-78e0-42ae-a454-0a14b03ddc21")]
		public static IEnumerable<T> NetConnectionEnum<T>([Optional] string servername, string qualifier, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = 0U;
			NetConnectionEnum(servername, qualifier, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>
		/// Enumerates the Distributed File System (DFS) namespaces hosted on a server or DFS links of a namespace hosted by a server.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="DfsName">
		/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of the DFS root or link.</para>
		/// <para>
		/// When you specify information level 200 (DFS_INFO_200), this parameter is the name of a domain. When you specify information level
		/// 300 (DFS_INFO_300), this parameter is the name of a server.
		/// </para>
		/// <para>For all other levels, the string can be in one of the following four forms:</para>
		/// <para>ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; Dfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The string can also be of the following forms:</para>
		/// <para>DomainName&lt;i&gt;DomainName\DomDfsName</para>
		/// <para>or</para>
		/// <para>DomainName&lt;i&gt;DomDfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS root; DomDfsName is the name of the DFS namespace; and
		/// link_path is a DFS link.
		/// </para>
		/// <para>You can precede the string with backslashes (\), but they are not required. This parameter is required.</para>
		/// </param>
		/// <param name="Level">
		/// <para>Specifies the information level of the request. This parameter can be one of the following values.</para>
		/// <para>1</para>
		/// <para>Return the name of the DFS root and all links under the root. The Buffer parameter points to an array of DFS_INFO_1 structures.</para>
		/// <para>2</para>
		/// <para>
		/// Return the name, comment, status, and the number of targets for the DFS root and all links under the root. The Buffer parameter
		/// points to an array of DFS_INFO_2 structures.
		/// </para>
		/// <para>3</para>
		/// <para>
		/// Return the name, comment, status, number of targets, and information about each target for the DFS root and all links under the
		/// root. The Buffer parameter points to an array of DFS_INFO_3 structures.
		/// </para>
		/// <para>4</para>
		/// <para>
		/// Return the name, comment, status, <c>GUID</c>, time-out, number of targets, and information about each target for the DFS root
		/// and all links under the root. The Buffer parameter points to an array of DFS_INFO_4 structures.
		/// </para>
		/// <para>5</para>
		/// <para>
		/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, and number of targets for a DFS root and all links
		/// under the root. The Buffer parameter points to an array of DFS_INFO_5 structures.
		/// </para>
		/// <para>6</para>
		/// <para>
		/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information for a root or link, and a
		/// list of DFS targets. The Buffer parameter points to an array of DFS_INFO_6 structures.
		/// </para>
		/// <para>8</para>
		/// <para>
		/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, number of targets, and link reparse point security
		/// descriptors for a DFS root and all links under the root. The Buffer parameter points to an array of DFS_INFO_8 structures.
		/// </para>
		/// <para>9</para>
		/// <para>
		/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information, link reparse point
		/// security descriptors, and a list of DFS targets for a root or link. The Buffer parameter points to an array of DFS_INFO_9 structures.
		/// </para>
		/// <para>200</para>
		/// <para>
		/// Return the list of domain-based DFS namespaces in the domain. The Buffer parameter points to an array of DFS_INFO_200 structures.
		/// </para>
		/// <para>300</para>
		/// <para>
		/// Return the stand-alone and domain-based DFS namespaces hosted by a server. The Buffer parameter points to an array of
		/// DFS_INFO_300 structures.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
		/// <para>If no more entries are available to be enumerated, the return value is <c>ERROR_NO_MORE_ITEMS</c>.</para>
		/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>No special group membership is required for using the <c>NetDfsEnum</c> function.</para>
		/// <para>
		/// Call the <c>NetDfsEnum</c> function with the ResumeHandle parameter set to zero to begin the enumeration. To continue the
		/// enumeration operation, call this function with the ResumeHandle returned by the previous call to <c>NetDfsEnum</c>. If this
		/// function does not return <c>ERROR_NO_MORE_ITEMS</c>, subsequent calls to this API will return the remaining links. Once
		/// <c>ERROR_NO_MORE_ITEMS</c> is returned, all available DFS links have been retrieved.
		/// </para>
		/// <para>
		/// The <c>NetDfsEnum</c> function allocates the memory required for the information structure buffer. If you specify an amount in
		/// the PrefMaxLen parameter, it restricts the memory that the function returns. However, the actual size of the memory that the
		/// <c>NetDfsEnum</c> function allocates can be greater than the amount you specify. For additional information see Network
		/// Management Function Buffer Lengths.
		/// </para>
		/// <para>
		/// Due to the possibility of concurrent updates to the DFS namespace, the caller should not assume completeness or uniqueness of the
		/// results returned when resuming an enumeration operation.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to list the DFS links in a named DFS root with a call to the <c>NetDfsEnum</c>
		/// function. The sample calls <c>NetDfsEnum</c>, specifying information level 3 ( DFS_INFO_3). The sample code loops through the
		/// entries and prints the retrieved data and the status of each host server referenced by the DFS link. Finally, the sample frees
		/// the memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmdfs.h", MSDNShortId = "c05a8d78-41f4-4c19-a25e-ef4885869584")]
		public static IEnumerable<T> NetDfsEnum<T>(string DfsName, uint Level = uint.MaxValue) where T : struct
		{
			if (Level == uint.MaxValue) Level = (uint)GetLevelFromStructure<T>();
			var h = 0U;
			NetDfsEnum(DfsName, Level, MAX_PREFERRED_LENGTH, out var buf, out var cnt, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>Retrieves information about a Distributed File System (DFS) root or link from the cache maintained by the DFS client.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="DfsEntryPath">
		/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.</para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// <para>This parameter is required.</para>
		/// </param>
		/// <param name="ServerName">
		/// Pointer to a string that specifies the name of the DFS root target or link target server. This parameter is optional.
		/// </param>
		/// <param name="ShareName">
		/// Pointer to a string that specifies the name of the share corresponding to the DFS root target or link target. This parameter is optional.
		/// </param>
		/// <param name="Level">
		/// <para>Specifies the information level of the request. This parameter can be one of the following values.</para>
		/// <para>1</para>
		/// <para>Return the DFS root or DFS link name. The Buffer parameter points to a DFS_INFO_1 structure.</para>
		/// <para>2</para>
		/// <para>
		/// Return the DFS root or DFS link name, status, and the number of DFS targets. The Buffer parameter points to a DFS_INFO_2 structure.
		/// </para>
		/// <para>3</para>
		/// <para>Return the DFS root or DFS link name, status, and target information. The Buffer parameter points to a DFS_INFO_3 structure.</para>
		/// <para>4</para>
		/// <para>
		/// Return the DFS root or DFS link name, status, <c>GUID</c>, time-out, and target information. The Buffer parameter points to a
		/// DFS_INFO_4 structure.
		/// </para>
		/// </param>
		/// <returns>The requested information.</returns>
		/// <remarks>No special group membership is required for using the <c>NetDfsGetClientInfo</c> function.</remarks>
		[PInvokeData("lmdfs.h", MSDNShortId = "065ec002-cb90-4d78-a70c-6ac37f71994f")]
		public static T NetDfsGetClientInfo<T>(string DfsEntryPath, [Optional] string ServerName, [Optional] string ShareName, uint Level = uint.MaxValue) where T : struct
		{
			if (Level == uint.MaxValue) Level = (uint)GetLevelFromStructure<T>();
			NetDfsGetClientInfo(DfsEntryPath, ServerName, ShareName, Level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>
		/// Retrieves the security descriptor of the container object for the domain-based DFS namespaces in the specified Active Directory domain.
		/// </summary>
		/// <param name="DomainName">Pointer to a string that specifies the Active Directory domain name.</param>
		/// <param name="SecurityInformation">
		/// SECURITY_INFORMATION structure that contains bit flags that indicate the type of security information to retrieve.
		/// </param>
		/// <returns>SECURITY_DESCRIPTOR that contains the security items requested in the SecurityInformation parameter.</returns>
		/// <remarks>
		/// The security descriptor is retrieved from the "CN=DFS-Configuration,CN=System,DC=domain" object in Active Directory from the
		/// primary domain controller (PDC) of the domain specified in the DomainName parameter, where domain is the distinguished name of
		/// the domain specified in the DomainName parameter.
		/// </remarks>
		[PInvokeData("lmdfs.h", MSDNShortId = "88e988db-1418-49d5-8cac-1ea6144474a5")]
		public static AdvApi32.SafePSECURITY_DESCRIPTOR NetDfsGetFtContainerSecurity(string DomainName, SECURITY_INFORMATION SecurityInformation)
		{
			NetDfsGetFtContainerSecurity(DomainName, SecurityInformation, out var buf, out var len).ThrowIfFailed();
			return new AdvApi32.SafePSECURITY_DESCRIPTOR(buf.ToIEnum<byte>((int)len).ToArray());
		}

		/// <summary>Retrieves information about a specified Distributed File System (DFS) root or link in a DFS namespace.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="DfsEntryPath">
		/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.</para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// <para>This parameter is required.</para>
		/// </param>
		/// <param name="ServerName">This parameter is currently ignored and should be <c>NULL</c>.</param>
		/// <param name="ShareName">This parameter is currently ignored and should be <c>NULL</c>.</param>
		/// <param name="Level">
		/// <para>Specifies the information level of the request. This parameter can be one of the following values.</para>
		/// <para>1</para>
		/// <para>Return the DFS root or DFS link name. The Buffer parameter points to a DFS_INFO_1 structure.</para>
		/// <para>2</para>
		/// <para>
		/// Return the DFS root or DFS link name, status, and the number of DFS targets. The Buffer parameter points to a DFS_INFO_2 structure.
		/// </para>
		/// <para>3</para>
		/// <para>Return the DFS root or DFS link name, status, and target information. The Buffer parameter points to a DFS_INFO_3 structure.</para>
		/// <para>4</para>
		/// <para>
		/// Return the DFS root or DFS link name, status, GUID, time-out, and target information. The Buffer parameter points to a DFS_INFO_4 structure.
		/// </para>
		/// <para>5</para>
		/// <para>
		/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, and number of targets for a DFS root and all links
		/// under the root. The Buffer parameter points to an array of DFS_INFO_5 structures.
		/// </para>
		/// <para>6</para>
		/// <para>
		/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information for a root or link, and a
		/// list of DFS targets. The Buffer parameter points to an array of DFS_INFO_6 structures.
		/// </para>
		/// <para>7</para>
		/// <para>Return the version number <c>GUID</c> of the DFS metadata. The Buffer parameter points to an array of DFS_INFO_7 structures.</para>
		/// <para>8</para>
		/// <para>
		/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, number of targets, and link reparse point security
		/// descriptors for a DFS root and all links under the root. The Buffer parameter points to an array of DFS_INFO_8 structures.
		/// </para>
		/// <para>9</para>
		/// <para>
		/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information, link reparse point
		/// security descriptors, and a list of DFS targets for a root or link. The Buffer parameter points to an array of DFS_INFO_9 structures.
		/// </para>
		/// <para>50</para>
		/// <para>
		/// Return the DFS metadata version and capabilities of an existing DFS namespace. The Buffer parameter points to a DFS_INFO_50 structure.
		/// </para>
		/// <para>100</para>
		/// <para>Return a comment about the DFS root or DFS link. The Buffer parameter points to a DFS_INFO_100 structure.</para>
		/// <para>150</para>
		/// <para>Return the security descriptor for the DFS link's reparse point. The Buffer parameter points to a DFS_INFO_150 structure.</para>
		/// <para>
		/// <c>Note</c> This value is natively supported only if the DFS link resides on a server that is running Windows Server 2008 or later.
		/// </para>
		/// </param>
		/// <returns>The requested information structures. The format of this data depends on the value of the Level parameter.</returns>
		/// <remarks>
		/// <para>No special group membership is required for using the <c>NetDfsGetInfo</c> function.</para>
		/// <para>
		/// An application calling the <c>NetDfsGetInfo</c> function may indirectly cause the local DFS Namespace server servicing the
		/// function call to perform a full synchronization of the related namespace metadata from the PDC emulator master for that domain.
		/// This full synchronization could happen even when root scalability mode is configured for that namespace. In order to avoid this
		/// side-effect, if the intent is to only retrieve the physical UNC pathname used by a specific DFSN client machine corresponding a
		/// given DFS namespace path, then one alternative is to use the WDK API ZwQueryInformationFile, passing
		/// <c>FileNetworkPhysicalNameInformation</c> as the FileInformationClass parameter and passing the address of a caller-allocated
		/// FILE_NETWORK_PHYSICAL_NAME_INFORMATION structure as the FileInformation parameter. Please see the WDK for more information on
		/// calling WDK APIs.
		/// </para>
		/// </remarks>
		[PInvokeData("lmdfs.h", MSDNShortId = "bbb2f24d-1c49-4016-a16b-60fde4a78193")]
		public static T NetDfsGetInfo<T>(string DfsEntryPath, [Optional] string ServerName, [Optional] string ShareName, uint Level = uint.MaxValue) where T : struct
		{
			if (Level == uint.MaxValue) Level = (uint)GetLevelFromStructure<T>();
			NetDfsGetInfo(DfsEntryPath, ServerName, ShareName, Level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>Retrieves the security descriptor for the root object of the specified DFS namespace.</summary>
		/// <param name="DfsEntryPath">
		/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS namespace root.</para>
		/// <para>The string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace and Dfsname is the name of the
		/// DFS namespace.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsName</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace and DomDfsName is the name of the DFS namespace.
		/// </para>
		/// </param>
		/// <param name="SecurityInformation">
		/// SECURITY_INFORMATION structure that contains bit flags that indicate the type of security information to retrieve from the root object.
		/// </param>
		/// <returns>A list of SECURITY_DESCRIPTOR structures that contain the security items requested in the SecurityInformation parameter.</returns>
		/// <remarks>
		/// <para>
		/// For domain-based DFS namespaces, the security descriptor is retrieved from the
		/// "CN=DomDfsName,CN=DFS-Configuration,CN=System,DC=domain" object in Active Directory from the primary domain controller (PDC) of
		/// the domain that hosts the DFS namespace, where DomDfsName is the name of the domain-based DFS namespace and &lt;domain&gt; is the
		/// distinguished name of the Active Directory domain that hosts the namespace.
		/// </para>
		/// <para>
		/// For stand-alone roots, the security descriptor is retrieved from the object specified by the
		/// <c>HKLM</c>&lt;b&gt;Software&lt;b&gt;Microsoft&lt;b&gt;Dfs&lt;b&gt;Standalone&lt;b&gt;&lt;root-name&gt; registry entry.
		/// </para>
		/// </remarks>
		[PInvokeData("lmdfs.h", MSDNShortId = "a6db7c82-c2ec-464a-8c05-2360622880b4")]
		public static AdvApi32.SafePSECURITY_DESCRIPTOR NetDfsGetSecurity(string DfsEntryPath, SECURITY_INFORMATION SecurityInformation)
		{
			NetDfsGetSecurity(DfsEntryPath, SecurityInformation, out var buf, out var len).ThrowIfFailed();
			return new AdvApi32.SafePSECURITY_DESCRIPTOR(buf.ToIEnum<byte>((int)len).ToArray());
		}

		/// <summary>Retrieves the security descriptor for the container object of the specified stand-alone DFS namespace.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="MachineName">Pointer to a string that specifies the name of the server that hosts the stand-alone DFS namespace.</param>
		/// <param name="SecurityInformation">
		/// SECURITY_INFORMATION structure that contains bit flags that indicate the type of security information to retrieve.
		/// </param>
		/// <returns>A list of SECURITY_DESCRIPTOR structures that contain the security items requested in the SecurityInformation parameter.</returns>
		/// <remarks>
		/// The security descriptor is retrieved from the object specified by the
		/// <c>HKLM</c>&lt;b&gt;Software&lt;b&gt;Microsoft&lt;b&gt;Dfs&lt;b&gt;Standalone key in the registry of the server specified in the
		/// MachineName parameter.
		/// </remarks>
		[PInvokeData("lmdfs.h", MSDNShortId = "63ad610e-c66f-4fad-b3b6-2ee15e90a723")]
		public static AdvApi32.SafePSECURITY_DESCRIPTOR NetDfsGetStdContainerSecurity<T>(string MachineName, SECURITY_INFORMATION SecurityInformation)
		{
			NetDfsGetStdContainerSecurity(MachineName, SecurityInformation, out var buf, out var len).ThrowIfFailed();
			return new AdvApi32.SafePSECURITY_DESCRIPTOR(buf.ToIEnum<byte>((int)len).ToArray());
		}

		/// <summary>Modifies information about a Distributed File System (DFS) root or link in the cache maintained by the DFS client.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="DfsEntryPath">
		/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.</para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// <para>This parameter is required.</para>
		/// </param>
		/// <param name="ServerName">
		/// Pointer to a string that specifies the DFS link target server name. This parameter is optional. For more information, see the
		/// Remarks section.
		/// </param>
		/// <param name="ShareName">
		/// Pointer to a string that specifies the DFS link target share name. This parameter is optional. For additional information, see
		/// the following Remarks section.
		/// </param>
		/// <param name="Buffer">
		/// The information to be set. The format of this information depends on the value of the Level parameter. For more information, see
		/// Network Management Function Buffers.
		/// </param>
		/// <param name="Level">
		/// <para>Specifies the information level of the request. This parameter can be one of the following values.</para>
		/// <para>101</para>
		/// <para>Set the local DFS link's storage status. The Buffer parameter points to a DFS_INFO_101 structure.</para>
		/// <para>102</para>
		/// <para>
		/// Set the local DFS link time-out. The Buffer parameter points to a DFS_INFO_102 structure. For more information, see the following
		/// Remarks section.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The caller must have Administrator privilege on the DFS server. For more information about calling functions that require
		/// administrator privileges, see Running with Special Privileges.
		/// </para>
		/// <para>
		/// Setting the time-out to zero may not immediately delete the local cached copy of the DFS link, because threads may be referencing
		/// the entry.
		/// </para>
		/// <para>Because there is only one time-out on a DFS link, the ServerName and ShareName parameters are ignored for level 102.</para>
		/// <para>
		/// The <c>DFS_STORAGE_STATE_ONLINE</c> and <c>DFS_STORAGE_STATE_OFFLINE</c> bits will be ignored. The
		/// <c>DFS_STORAGE_STATE_ACTIVE</c> bit is valid only if no files are open to the active computer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmdfs.h", MSDNShortId = "4c95dffb-a092-45ad-9a3f-37d3abbf4427")]
		public static void NetDfsSetClientInfo<T>(string DfsEntryPath, [Optional] string ServerName, string ShareName, in T Buffer, uint Level = uint.MaxValue) where T : struct
		{
			var mem = SafeHGlobalHandle.CreateFromStructure(Buffer);
			if (Level == uint.MaxValue) Level = (uint)GetLevelFromStructure<T>();
			NetDfsSetClientInfo(ServerName, ServerName, ShareName, Level, (IntPtr)mem).ThrowIfFailed();
		}

		/// <summary>Sets or modifies information about a specific Distributed File System (DFS) root, root target, link, or link target.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="DfsEntryPath">
		/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.</para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// </param>
		/// <param name="ServerName">
		/// Pointer to a string that specifies the DFS link target server name. This parameter is optional. For more information, see the
		/// Remarks section.
		/// </param>
		/// <param name="ShareName">
		/// Pointer to a string that specifies the DFS link target share name. This may also be a share name with a path relative to the
		/// share. For example, "share1\mydir1\mydir2". This parameter is optional. For more information, see the Remarks section.
		/// </param>
		/// <param name="Buffer">
		/// The data. The format of this data depends on the value of the Level parameter. For more information, see Network Management
		/// Function Buffers.
		/// </param>
		/// <param name="Level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <para>100</para>
		/// <para>
		/// Set the comment associated with the DFS root or link specified in the DfsEntryPath parameter. The Buffer parameter points to a
		/// DFS_INFO_100 structure.
		/// </para>
		/// <para>101</para>
		/// <para>
		/// Set the storage state associated with the DFS root or link specified in the DfsEntryPath parameter. The Buffer parameter points
		/// to a DFS_INFO_101 structure.
		/// </para>
		/// <para>102</para>
		/// <para>
		/// Set the time-out value associated with the DFS root or link specified in the DfsEntryPath parameter. The Buffer parameter points
		/// to a DFS_INFO_102 structure.
		/// </para>
		/// <para>103</para>
		/// <para>
		/// Set the property flags for the DFS root or link specified in the DfsEntryPath parameter. The Buffer parameter points to a
		/// DFS_INFO_103 structure.
		/// </para>
		/// <para>104</para>
		/// <para>
		/// Set the target priority rank and class for the root target or link target specified in the DfsEntryPath parameter. The Buffer
		/// parameter points to a DFS_INFO_104 structure.
		/// </para>
		/// <para>105</para>
		/// <para>
		/// Set the comment, state, and time-out information, as well as property flags, for the DFS root or link specified in the
		/// DfsEntryPath parameter. The Buffer parameter points to a DFS_INFO_105 structure.
		/// </para>
		/// <para>106</para>
		/// <para>
		/// Set the target state and priority for the root target or link target specified in the DfsEntryPath parameter. This information
		/// cannot be set for a DFS namespace root or link, only for a root target or link target. The Buffer parameter points to a
		/// DFS_INFO_106 structure.
		/// </para>
		/// <para>107</para>
		/// <para>
		/// Set the comment, state, time-out information, and property flags for the DFS root or link specified in the DfsEntryPath
		/// parameter. For DFS links, you can also set the security descriptor for the link's reparse point. The Buffer parameter points to a
		/// DFS_INFO_107 structure.
		/// </para>
		/// <para>150</para>
		/// <para>Set the security descriptor for a DFS link's reparse point. The Buffer parameter points to a DFS_INFO_150 structure.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The caller must have Administrator privilege on the DFS server. For more information about calling functions that require
		/// administrator privileges, see Running with Special Privileges.
		/// </para>
		/// <para>
		/// If you specify both the ServerName and ShareName parameters, the <c>NetDfsSetInfo</c> function sets or modifies information
		/// specific to that root target or link target. If the parameters are <c>NULL</c>, the function sets or modifies information that is
		/// specific to the DFS namespace root or the DFS link instead of a specific DFS root target or link target.
		/// </para>
		/// <para>
		/// Because only one comment and one time-out can be set for a DFS root or link, the ServerName and ShareName parameters are ignored
		/// for information levels 100 and 102. These parameters are required for level 101.
		/// </para>
		/// <para>
		/// For information level 101, the <c>DFS_VOLUME_STATE_RESYNCHRONIZE</c> and <c>DFS_VOLUME_STATE_STANDBY</c> state values can be set
		/// as follows for a specific domain-based DFS root when there is more than one DFS root target for the DFS namespace:
		/// </para>
		/// <para>
		/// The DfsEntryPath parameter specifies the domain-based DFS namespace, and the ServerName and ShareName parameters taken together
		/// specify the DFS root target on which the set-information operation is to be performed.
		/// </para>
		/// </remarks>
		[PInvokeData("lmdfs.h", MSDNShortId = "5526afa7-82bc-47c7-99d6-44e41ef772b1")]
		public static void NetDfsSetInfo<T>(string DfsEntryPath, [Optional] string ServerName, string ShareName, in T Buffer, uint Level = uint.MaxValue) where T : struct
		{
			var mem = SafeHGlobalHandle.CreateFromStructure(Buffer);
			if (Level == uint.MaxValue) Level = (uint)GetLevelFromStructure<T>();
			NetDfsSetInfo(ServerName, ServerName, ShareName, Level, (IntPtr)mem).ThrowIfFailed();
		}

		/// <summary>The <c>NetEnumerateComputerNames</c> function enumerates names for the specified computer.</summary>
		/// <param name="Server">
		/// A pointer to a constant string that specifies the name of the computer on which to execute this function. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="NameType">
		/// <para>
		/// The type of the name queried. This member can be one of the following values defined in the <c>NET_COMPUTER_NAME_TYPE</c>
		/// enumeration defined in the Lmjoin.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NetPrimaryComputerName</term>
		/// <term>The primary computer name.</term>
		/// </item>
		/// <item>
		/// <term>NetAlternateComputerNames</term>
		/// <term>Alternate computer names.</term>
		/// </item>
		/// <item>
		/// <term>NetAllComputerNames</term>
		/// <term>All computer names.</term>
		/// </item>
		/// <item>
		/// <term>NetComputerNameTypeMax</term>
		/// <term>Indicates the end of the range that specifies the possible values for the type of name to be queried.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// If the function call is successful, this parameter will return the computer names that match the computer type name specified in
		/// the NameType parameter.
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetEnumerateComputerNames</c> function is supported on Windows Vista and later.</para>
		/// <para>The <c>NetEnumerateComputerNames</c> function is used to request the names a computer currently has configured.</para>
		/// <para>
		/// The <c>NetEnumerateComputerNames</c> function requires that the caller is a member of the Administrators local group on the
		/// target computer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmjoin/nf-lmjoin-netenumeratecomputernames NET_API_STATUS NET_API_FUNCTION
		// NetEnumerateComputerNames( LPCWSTR Server, NET_COMPUTER_NAME_TYPE NameType, ULONG Reserved, PDWORD EntryCount, LPWSTR
		// **ComputerNames );
		[PInvokeData("lmjoin.h", MSDNShortId = "c657ae33-404e-4c36-a956-5fbcfa540be7")]
		public static IEnumerable<string> NetEnumerateComputerNames([Optional] string Server, NET_COMPUTER_NAME_TYPE NameType = NET_COMPUTER_NAME_TYPE.NetAllComputerNames)
		{
			NetEnumerateComputerNames(Server, NameType, 0, out var c, out var buf).ThrowIfFailed();
			return buf.ToStringEnum((int)c);
		}

		/// <summary>Returns information about some or all open files on a server, depending on the parameters specified.</summary>
		/// <typeparam name="T">The expected return type of the enumerated element.</typeparam>
		/// <param name="servername">
		/// <para>
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
		/// </param>
		/// <param name="basepath">
		/// <para>
		/// A string that specifies a qualifier for the returned information. If this parameter is <see langword="null"/>, all open resources
		/// are enumerated. If this parameter is not <see langword="null"/>, the function enumerates only resources that have the value of
		/// the basepath parameter as a prefix. (A prefix is the portion of a path that comes before a backslash.)
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
		/// </param>
		/// <param name="username">
		/// <para>
		/// A string that specifies the name of the user or the name of the connection. If the string begins with two backslashes ("\"), then
		/// it indicates the name of the connection, for example, "\127.0.0.1" or "\ClientName". The part of the connection name after the
		/// backslashes is the same as the client name in the session information structure returned by the NetSessionEnum function. If the
		/// string does not begin with two backslashes, then it indicates the name of the user. If this parameter is not
		/// <see langword="null"/>, its value serves as a qualifier for the enumeration. The files returned are limited to those that have
		/// user names or connection names that match the qualifier. If this parameter is <see langword="null"/>, no user-name qualifier is used.
		/// </para>
		/// <para>
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This parameter is a pointer to a string that
		/// specifies the name of the user. If this parameter is not <see langword="null"/>, its value serves as a qualifier for the
		/// enumeration. The files returned are limited to those that have user names matching the qualifier. If this parameter is
		/// <see langword="null"/>, no user-name qualifier is used.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>2</term>
		/// <term>Return the file identification number. The return value is an array of FILE_INFO_2 structures.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Return information about the file. The return value is an array of FILE_INFO_3 structures.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>An enumeration of files. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>Only members of the Administrators or Server Operators local group can successfully execute the <c>NetFileEnum</c> function.</para>
		/// <para>You can call the NetFileGetInfo function to retrieve information about a particular opening of a server resource.</para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling <c>NetFileEnum</c>. For more information, see IADsResource and IADsFileServiceOperations.
		/// </para>
		/// </remarks>
		[PInvokeData("lmshare.h", MSDNShortId = "1375b337-efb0-4be1-94f7-473456a825b5")]
		public static IEnumerable<T> NetFileEnum<T>([Optional] string servername, [Optional] string basepath, [Optional] string username, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = IntPtr.Zero;
			NetFileEnum(servername, basepath, username, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>Retrieves information about a particular opening of a server resource.</summary>
		/// <typeparam name="T">The expected return type associated with the <paramref name="level"/>.</typeparam>
		/// <param name="servername">
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="fileid">
		/// Specifies the file identifier of the open resource for which to return information. The value of this parameter must have been
		/// returned in a previous enumeration call. For more information, see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>2</term>
		/// <term>Return the file identification number. The bufptr parameter is a pointer to a FILE_INFO_2 structure.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return the file identification number and other information about the file. The bufptr parameter is a pointer to a FILE_INFO_3 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The format of this structure depends on the value of the <paramref name="level"/> parameter.</returns>
		/// <remarks>
		/// <para>
		/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetFileGetInfo</c> function.
		/// </para>
		/// <para>You can call the NetFileEnum function to retrieve information about multiple files open on a server.</para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling <c>NetFileGetInfo</c>. For more information, see IADsResource and IADsFileServiceOperations.
		/// </para>
		/// </remarks>
		[PInvokeData("lmshare.h", MSDNShortId = "d50c05e7-7ddd-4a7d-96f6-51878e52373c")]
		public static T NetFileGetInfo<T>([Optional] string servername, uint fileid, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetFileGetInfo(servername, fileid, level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>
		/// The <c>NetGetJoinableOUs</c> function retrieves a list of organizational units (OUs) in which a computer account can be created.
		/// </summary>
		/// <param name="lpDomain">A string that specifies the name of the domain for which to retrieve the list of OUs that can be joined.</param>
		/// <param name="lpServer">
		/// A string that specifies the DNS or NetBIOS name of the computer on which to call the function. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="lpAccount">
		/// A string that specifies the account name to use when connecting to the domain controller. The string must specify either a domain
		/// NetBIOS name and user account (for example, "REDMOND\user") or the user principal name (UPN) of the user in the form of an
		/// Internet-style login name (for example, "someone@example.com"). If this parameter is <see langword="null"/>, the caller's context
		/// is used.
		/// </param>
		/// <param name="lpPassword">
		/// If the lpAccount parameter specifies an account name, this parameter must point to the password to use when connecting to the
		/// domain controller. Otherwise, this parameter must be <see langword="null"/>.
		/// </param>
		/// <returns>The list of joinable OUs.</returns>
		/// <remarks>
		/// <para>No special group membership is required to successfully execute the <c>NetGetJoinableOUs</c> function.</para>
		/// <para>For more information about organizational units, see Managing Users in the Active Directory documentation.</para>
		/// </remarks>
		[PInvokeData("lmjoin.h", MSDNShortId = "1faa912b-c56d-431c-95d5-d36790b0d467")]
		public static IEnumerable<string> NetGetJoinableOUs(string lpDomain, [Optional] string lpServer, [Optional] string lpAccount, [Optional] string lpPassword)
		{
			NetGetJoinableOUs(lpServer, lpDomain, lpAccount, lpPassword, out var cnt, out var buf).ThrowIfFailed();
			return buf.ToStringEnum((int)cnt);
		}

		/// <summary>
		/// The <c>NetGroupAdd</c> function creates a global group in the security database, which is the security accounts manager (SAM)
		/// database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="buf">
		/// The data. The format of this data depends on the value of the level parameter. For more information, see Network Management
		/// Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Specifies a global group name. The buf parameter contains a pointer to a GROUP_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Specifies a global group name and a comment. The buf parameter contains a pointer to a GROUP_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies detailed information about the global group. The buf parameter contains a pointer to a GROUP_INFO_2 structure. Note
		/// that on Windows XP and later, it is recommended that you use GROUP_INFO_3 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies detailed information about the global group. The buf parameter contains a pointer to a GROUP_INFO_3 structure. Windows
		/// 2000: This level is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the user container is used to perform the access check for this function. The caller must be able to
		/// create child objects of the group class. Typically, callers must also have write access to the entire object for calls to this
		/// function to succeed.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "fbf90758-79fd-4959-b6d0-ad3872e77242")]
		public static void NetGroupAdd<T>([In, Optional] string servername, in T buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetGroupAdd(servername, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>
		/// <para>
		/// The <c>NetGroupEnum</c> function retrieves information about each global group in the security database, which is the security
		/// accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </para>
		/// <para>
		/// The NetQueryDisplayInformation function provides an efficient mechanism for enumerating global groups. When possible, it is
		/// recommended that you use <c>NetQueryDisplayInformation</c> instead of the <c>NetGroupEnum</c> function.
		/// </para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the global group name. The bufptr parameter points to an array of GROUP_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return the global group name and a comment. The bufptr parameter points to an array of GROUP_INFO_1 structures.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return detailed information about the global group. The bufptr parameter points to an array of GROUP_INFO_2 structures. Note that
		/// on Windows XP and later, it is recommended that you use GROUP_INFO_3 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return detailed information about the global group. The bufptr parameter points to an array of GROUP_INFO_3 structures. Windows
		/// 2000: This level is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The global group information structure. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The function only returns information to which the caller has Read access. The caller must have List Contents access to the
		/// Domain object, and Enumerate Entire SAM Domain access on the SAM Server object located in the System container.
		/// </para>
		/// <para>
		/// To determine the exact total number of groups, you must enumerate the entire tree, which can be a costly operation. To enumerate
		/// the entire tree, use the resume_handle parameter to continue the enumeration for consecutive calls, and use the entriesread
		/// parameter to accumulate the total number of groups. If your application is communicating with a domain controller, you should
		/// consider using the ADSI LDAP Provider to retrieve this type of data more efficiently. The ADSI LDAP Provider implements a set of
		/// ADSI objects that support various ADSI interfaces. For more information, see ADSI Service Providers.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "3f8fabce-94cb-41f5-9af1-04585ac3f16e")]
		public static IEnumerable<T> NetGroupEnum<T>([Optional] string servername, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = IntPtr.Zero;
			NetGroupEnum(servername, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>
		/// The <c>NetGroupGetInfo</c> function retrieves information about a particular global group in the security database, which is the
		/// security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the global group for which to retrieve information. For more information,
		/// see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the global group name. The bufptr parameter points to a GROUP_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return the global group name and a comment. The bufptr parameter points to a GROUP_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return detailed information about the global group. The bufptr parameter points to a GROUP_INFO_2 structure. Note that on Windows
		/// XP and later, it is recommended that you use GROUP_INFO_3 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return detailed information about the global group. The bufptr parameter points to a GROUP_INFO_3 structure. Windows 2000: This
		/// level is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The global group information structure. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the Group object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "f9957c15-9a49-4b53-ae31-efd6a03417a6")]
		public static T NetGroupGetInfo<T>([Optional] string servername, string groupname, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetGroupGetInfo(servername, groupname, level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>
		/// The <c>NetGroupGetUsers</c> function retrieves a list of the members in a particular global group in the security database, which
		/// is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// A pointer to a constant string that specifies the name of the global group whose members are to be listed. For more information,
		/// see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the global group's member names. The bufptr parameter points to an array of GROUP_USERS_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return the global group's member names and attributes. The bufptr parameter points to an array of GROUP_USERS_INFO_1 structures.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The information structure.</returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the Group object is used to perform the access check for this function.</para>
		/// <para>
		/// To grant one user membership in an existing global group, you can call the NetGroupAddUser function. To remove a user from a
		/// global group, call the NetGroupDelUser function. For information about replacing the membership of a global group, see NetGroupSetUsers.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "a9bcb806-f44c-4db2-9644-06687b31405d")]
		public static IEnumerable<T> NetGroupGetUsers<T>([Optional] string servername, string groupname, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = IntPtr.Zero;
			NetGroupGetUsers(servername, groupname, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>
		/// The <c>NetGroupSetInfo</c> function sets the parameters of a global group in the security database, which is the security
		/// accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the global group for which to set information. For more information, see
		/// the following Remarks section.
		/// </param>
		/// <param name="buf">
		/// The data. The format of this data depends on the value of the level parameter. For more information, see Network Management
		/// Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Specifies a global group name. The buf parameter points to a GROUP_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Specifies a global group name and a comment. The buf parameter points to a GROUP_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies detailed information about the global group. The buf parameter points to a GROUP_INFO_2 structure. Note that on Windows
		/// XP and later, it is recommended that you use GROUP_INFO_3 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies detailed information about the global group. The buf parameter points to a GROUP_INFO_3 structure. Windows 2000: This
		/// level is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1002</term>
		/// <term>Specifies a comment only about the global group. The buf parameter points to a GROUP_INFO_1002 structure.</term>
		/// </item>
		/// <item>
		/// <term>1005</term>
		/// <term>Specifies global group attributes. The buf parameter points to a GROUP_INFO_1005 structure.</term>
		/// </item>
		/// </list>
		/// <para>For more information, see the following Remarks section.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the Group object is used to perform the access check for this function. Typically, callers must have
		/// write access to the entire object for calls to this function to succeed.
		/// </para>
		/// <para>
		/// The correct way to set the new name of a global group is to call the <c>NetGroupSetInfo</c> function, using a GROUP_INFO_0
		/// structure. Specify the new value in the <c>grpi0_name</c> member. If you use a GROUP_INFO_1 structure and specify the value in
		/// the <c>grpi1_name</c> member, the new name value is ignored.
		/// </para>
		/// <para>
		/// If the <c>NetGroupSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the first
		/// member of the group information structure that is invalid. (A group information structure begins with GROUP_INFO_ and its format
		/// is specified by the level parameter.) The following table lists the values that can be returned in the parm_err parameter and the
		/// corresponding structure member that is in error. (The prefix grpi*_ indicates that the member can begin with multiple prefixes,
		/// for example, grpi1_ or grpi2_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>GROUP_NAME_PARMNUM</term>
		/// <term>grpi*_name</term>
		/// </item>
		/// <item>
		/// <term>GROUP_COMMENT_PARMNUM</term>
		/// <term>grpi*_comment</term>
		/// </item>
		/// <item>
		/// <term>GROUP_ATTRIBUTES_PARMNUM</term>
		/// <term>grpi*_attributes</term>
		/// </item>
		/// </list>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "8c235f9a-095e-4108-9b93-008ffe9bc776")]
		public static void NetGroupSetInfo<T>([Optional] string servername, string groupname, in T buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetGroupSetInfo(servername, groupname, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>
		/// The <c>NetGroupSetUsers</c> function sets the membership for the specified global group. Each user you specify is enrolled as a
		/// member of the global group. Users you do not specify, but who are currently members of the global group, will have their
		/// membership revoked.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// A pointer to a constant string that specifies the name of the global group of interest. For more information, see the Remarks section.
		/// </param>
		/// <param name="buf">The data. For more information, see Network Management Function Buffers.</param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The buf parameter points to an array of GROUP_USERS_INFO_0 structures that specify user names.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// The buf parameter points to an array of GROUP_USERS_INFO_1 structures that specifies user names and the attributes of the group.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the Group object is used to perform the access check for this function.</para>
		/// <para>
		/// You can replace the global group membership with an entirely new list of members by calling the <c>NetGroupSetUsers</c> function.
		/// The typical sequence of steps to perform this follows.
		/// </para>
		/// <para><c>To replace the global group membership</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Call the NetGroupGetUsers function to retrieve the current membership list.</term>
		/// </item>
		/// <item>
		/// <term>Modify the returned membership list to reflect the new membership.</term>
		/// </item>
		/// <item>
		/// <term>Call the <c>NetGroupSetUsers</c> function to replace the old membership list with the new membership list.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To grant one user membership in an existing global group, you can call the NetGroupAddUser function. To remove a user from a
		/// global group, call the NetGroupDelUser function.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "4221f5c8-a71c-4368-9be4-9562063b6cfd")]
		public static void NetGroupSetUsers<T>([Optional] string servername, string groupname, T[] buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			using (var mem = SafeHGlobalHandle.CreateFromList(buf))
				NetGroupSetUsers(servername, groupname, level, (IntPtr)mem, (uint)buf.Length).ThrowIfFailed();
		}

		/// <summary>
		/// The <c>NetLocalGroupAdd</c> function creates a local group in the security database, which is the security accounts manager (SAM)
		/// database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="buf">
		/// The local group information structure. The format of this data depends on the value of the level parameter. For more information,
		/// see Network Management Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>A local group name. The buf parameter points to a LOCALGROUP_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>A local group name and a comment to associate with the group. The buf parameter points to a LOCALGROUP_INFO_1 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the user container is used to perform the access check for this function. The caller must be able to
		/// create child objects of the group class.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If the <c>NetLocalGroupAdd</c> function returns <c>ERROR_INVALID_PARAMETER</c> and a <c>NULL</c> pointer was not passed in
		/// parm_err parameter, on return the parm_err parameter indicates the first member of the local group information structure that is
		/// invalid. The format of the local group information structure is specified in the level parameter. A pointer to the local group
		/// information structure is passed in buf parameter. The following table lists the values that can be returned in the parm_err
		/// parameter and the corresponding structure member that is in error.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>LOCALGROUP_NAME_PARMNUM</term>
		/// <term>
		/// If the level parameter was 0, the lgrpi0_name member of the LOCALGROUP_INFO_0 structure was invalid. If the level parameter was
		/// 1, the lgrpi1_name member of the LOCALGROUP_INFO_1 structure was invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LOCALGROUP_COMMENT_PARMNUM</term>
		/// <term>If the level parameter was 1, the lgrpi1_comment member of the LOCALGROUP_INFO_1 structure was invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// When making requests to a domain controller and Active Directory, you may be able to call certain Active Directory Service
		/// Interface (ADSI) methods to achieve the same results as the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "5028c1bc-8fed-4f02-8e69-d0d122b08d9f")]
		public static void NetLocalGroupAdd<T>([Optional] string servername, in T buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetLocalGroupAdd(servername, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>
		/// The <c>NetLocalGroupAddMembers</c> function adds membership of one or more existing user accounts or global group accounts to an
		/// existing local group. The function does not change the membership status of users or global groups that are currently members of
		/// the local group.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group to which the specified users or global groups will be
		/// added. For more information, see the following Remarks section.
		/// </param>
		/// <param name="buf">
		/// The data for the new local group members. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the security identifier (SID) of the new local group member. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies the domain and name of the new local group member. The buf parameter points to an array of LOCALGROUP_MEMBERS_INFO_3 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "3b2d3e4a-742e-4e67-8b28-3cd6d7e6a857")]
		public static void NetLocalGroupAddMembers<T>([Optional] string servername, string groupname, T[] buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			using (var mem = SafeHGlobalHandle.CreateFromList(buf))
				NetLocalGroupAddMembers(servername, groupname, level, (IntPtr)mem, (uint)buf.Length).ThrowIfFailed();
		}

		/// <summary>
		/// The <c>NetLocalGroupDelMembers</c> function removes one or more members from an existing local group. Local group members can be
		/// users or global groups.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group from which the specified users or global groups will be
		/// removed. For more information, see the following Remarks section.
		/// </param>
		/// <param name="buf">
		/// The members to be removed. The format of this data depends on the value of the level parameter. For more information, see Network
		/// Management Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the security identifier (SID) of a local group member to remove. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies the domain and name of a local group member to remove. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_3 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "85ae796b-c94a-46a8-9fa8-6c612db38671")]
		public static void NetLocalGroupDelMembers<T>([Optional] string servername, string groupname, T[] buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			using (var mem = SafeHGlobalHandle.CreateFromList(buf))
				NetLocalGroupDelMembers(servername, groupname, level, (IntPtr)mem, (uint)buf.Length).ThrowIfFailed();
		}

		/// <summary>The <c>NetLocalGroupEnum</c> function returns information about each local group account on the specified server.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return local group names. The bufptr parameter points to an array of LOCALGROUP_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return local group names and the comment associated with each group. The bufptr parameter points to an array of LOCALGROUP_INFO_1 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The information structure. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The function only returns information to which the caller has Read access. The caller must have List Contents access to the
		/// Domain object, and Enumerate Entire SAM Domain access on the SAM Server object located in the System container.
		/// </para>
		/// <para>
		/// To determine the exact total number of local groups, you must enumerate the entire tree, which can be a costly operation. To
		/// enumerate the entire tree, use the resumehandle parameter to continue the enumeration for consecutive calls, and use the
		/// entriesread parameter to accumulate the total number of local groups. If your application is communicating with a domain
		/// controller, you should consider using the ADSI LDAP Provider to retrieve this type of data more efficiently. The ADSI LDAP
		/// Provider implements a set of ADSI objects that support various ADSI interfaces. For more information, see ADSI Service Providers.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "fc27d7f1-bfbe-46d7-a154-f04eb9249248")]
		public static IEnumerable<T> NetLocalGroupEnum<T>([Optional] string servername, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = IntPtr.Zero;
			NetLocalGroupEnum(servername, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>The <c>NetLocalGroupGetInfo</c> function retrieves information about a particular local group account on a server.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group account for which the information will be retrieved. For
		/// more information, see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>Return the comment associated with the local group. The bufptr parameter points to a LOCALGROUP_INFO_1 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The return information structure.</returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "ee2f0be9-8d52-439b-ab65-f9e11a2872c5")]
		public static T NetLocalGroupGetInfo<T>([Optional] string servername, string groupname, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetLocalGroupGetInfo(servername, groupname, level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>
		/// The <c>NetLocalGroupGetMembers</c> function retrieves a list of the members of a particular local group in the security database,
		/// which is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory. Local group
		/// members can be users or global groups.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="localgroupname">
		/// Pointer to a constant string that specifies the name of the local group whose members are to be listed. For more information, see
		/// the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the security identifier (SID) associated with the local group member. The bufptr parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return the SID and account information associated with the local group member. The bufptr parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_1 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return the SID, account information, and the domain name associated with the local group member. The bufptr parameter points to
		/// an array of LOCALGROUP_MEMBERS_INFO_2 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return the account and domain names of the local group member. The bufptr parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_3 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The return information structures. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If this function returns <c>ERROR_MORE_DATA</c>, then it must be repeatedly called until <c>ERROR_SUCCESS</c> or
		/// <c>NERR_success</c> is returned. Failure to do so can result in an RPC connection leak.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "35770b32-dae9-46f5-84e3-1c31ca22f708")]
		public static IEnumerable<T> NetLocalGroupGetMembers<T>([Optional] string servername, string localgroupname, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = IntPtr.Zero;
			NetLocalGroupGetMembers(servername, localgroupname, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>
		/// The <c>NetLocalGroupSetInfo</c> function changes the name of an existing local group. The function also associates a comment with
		/// a local group.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group account to modify. For more information, see the
		/// following Remarks section.
		/// </param>
		/// <param name="buf">
		/// The local group information. The format of this data depends on the value of the level parameter. For more information, see
		/// Network Management Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the local group name. The buf parameter points to a LOCALGROUP_INFO_0 structure. Use this level to change the name of
		/// an existing local group.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies the local group name and a comment to associate with the group. The buf parameter points to a LOCALGROUP_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1002</term>
		/// <term>Specifies a comment to associate with the local group. The buf parameter points to a LOCALGROUP_INFO_1002 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the LocalGroup object is used to perform the access check for this function. Typically, callers must
		/// have write access to the entire object for calls to this function to succeed.
		/// </para>
		/// <para>
		/// To specify the new name of an existing local group, call <c>NetLocalGroupSetInfo</c> with LOCALGROUP_INFO_0 and specify a value
		/// using the <c>lgrpi0_name</c> member. If you call the <c>NetLocalGroupSetInfo</c> function with LOCALGROUP_INFO_1 and specify a
		/// new value using the <c>lgrpi1_name</c> member, that value will be ignored.
		/// </para>
		/// <para>
		/// If the <c>NetLocalGroupSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the
		/// first member of the local group information structure that is invalid. (A local group information structure begins with
		/// LOCALGROUP_INFO_ and its format is specified by the level parameter.) The following table lists the values that can be returned
		/// in the parm_err parameter and the corresponding structure member that is in error. (The prefix lgrpi*_ indicates that the member
		/// can begin with multiple prefixes, for example, lgrpi0_ or lgrpi1_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>LOCALGROUP_NAME_PARMNUM</term>
		/// <term>lgrpi*_name</term>
		/// </item>
		/// <item>
		/// <term>LOCALGROUP_COMMENT_PARMNUM</term>
		/// <term>lgrpi*_comment</term>
		/// </item>
		/// </list>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "c1d2a68b-0910-4815-9547-0f0f3c983164")]
		public static void NetLocalGroupSetInfo<T>([Optional] string servername, string groupname, in T buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetLocalGroupSetInfo(servername, groupname, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>
		/// The <c>NetLocalGroupSetMembers</c> function sets the membership for the specified local group. Each user or global group
		/// specified is made a member of the local group. Users or global groups that are not specified but who are currently members of the
		/// local group will have their membership revoked.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group in which the specified users or global groups should be
		/// granted membership. For more information, see the following Remarks section.
		/// </param>
		/// <param name="buf">
		/// The member information. The format of this data depends on the value of the level parameter. For more information, see Network
		/// Management Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the security identifier (SID) associated with a local group member. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies the account and domain names of the local group member. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_3 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// You can replace the local group membership with an entirely new list of members by calling the <c>NetLocalGroupSetMembers</c>
		/// function. The typical sequence of steps to perform this follows.
		/// </para>
		/// <para><c>To replace the local group membership</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Call the NetLocalGroupGetMembers function to retrieve the current membership list.</term>
		/// </item>
		/// <item>
		/// <term>Modify the returned membership list to reflect the new membership.</term>
		/// </item>
		/// <item>
		/// <term>Call the <c>NetLocalGroupSetMembers</c> function to replace the old membership list with the new membership list.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To add one or more existing user accounts or global group accounts to an existing local group, you can call the
		/// NetLocalGroupAddMembers function. To remove one or more members from an existing local group, call the NetLocalGroupDelMembers function.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "4dce1e10-b74d-4d69-ac5a-12e7d9d84e5c")]
		public static void NetLocalGroupSetMembers<T>([Optional] string servername, string groupname, T[] buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			using (var mem = SafeHGlobalHandle.CreateFromList(buf))
				NetLocalGroupSetMembers(servername, groupname, level, (IntPtr)mem, (uint)buf.Length).ThrowIfFailed();
		}

		/// <summary>
		/// <para>[ <c>NetScheduleJobEnum</c> is no longer available for use as of Windows 8. Instead, use the Task Scheduler 2.0 Interfaces.</para>
		/// <para>]</para>
		/// <para>
		/// The <c>NetScheduleJobEnum</c> function lists the jobs queued on a specified computer. This function requires that the schedule
		/// service be started.
		/// </para>
		/// </summary>
		/// <param name="Servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <returns>The data. The return information is an array of AT_ENUM structures.</returns>
		/// <remarks>
		/// <para>
		/// Normally only members of the local Administrators group on the computer where the schedule job is being enumerated can
		/// successfully execute this function. If the server name passed in the string pointed to by the Servername parameter is a remote
		/// server, then only members of the local Administrators group on the server can successfully execute this function.
		/// </para>
		/// <para>
		/// If the following registry value has the least significant bit set (for example, 0x00000001), then users belonging to the Server
		/// Operators group can also successfully execute this function.
		/// </para>
		/// <para><c>HKLM\System\CurrentControlSet\Control\Lsa\SubmitControl</c></para>
		/// <para>
		/// Each entry returned contains an AT_ENUM structure. The value of the <c>JobId</c> member can be used when calling functions that
		/// require a job identifier parameter, such as the NetScheduleJobDel function.
		/// </para>
		/// </remarks>
		[PInvokeData("lmat.h", MSDNShortId = "e3384414-6a15-4979-bed4-6f94f046474a")]
		public static IEnumerable<AT_ENUM> NetScheduleJobEnum([Optional] string Servername)
		{
			var h = 0U;
			NetScheduleJobEnum(Servername, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<AT_ENUM>((int)cnt);
		}

		/// <summary>
		/// <para>[ <c>NetScheduleJobGetInfo</c> is no longer available for use as of Windows 8. Instead, use the Task Scheduler 2.0 Interfaces.</para>
		/// <para>]</para>
		/// <para>
		/// The <c>NetScheduleJobGetInfo</c> function retrieves information about a particular job queued on a specified computer. This
		/// function requires that the schedule service be started.
		/// </para>
		/// </summary>
		/// <param name="Servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="JobId">A value that indicates the identifier of the job for which to retrieve information.</param>
		/// <returns>The AT_INFO structure describing the specified job.</returns>
		/// <remarks>
		/// <para>
		/// Normally only members of the local Administrators group on the computer where the schedule job is being enumerated can
		/// successfully execute this function. If the server name passed in the string pointed to by the Servername parameter is a remote
		/// server, then only members of the local Administrators group on the server can successfully execute this function.
		/// </para>
		/// <para>
		/// If the following registry value has the least significant bit set (for example, 0x00000001), then users belonging to the Server
		/// Operators group can also successfully execute this function.
		/// </para>
		/// <para><c>HKLM\System\CurrentControlSet\Control\Lsa\SubmitControl</c></para>
		/// </remarks>
		[PInvokeData("lmat.h", MSDNShortId = "44589715-edab-4737-9e49-6f491fd44c28")]
		public static AT_INFO NetScheduleJobGetInfo([Optional] string Servername, uint JobId)
		{
			NetScheduleJobGetInfo(Servername, JobId, out var buf).ThrowIfFailed();
			return buf.ToStructure<AT_INFO>();
		}

		/// <summary>
		/// The <c>NetServerDiskEnum</c> function retrieves a list of disk drives on a server. The function returns an array of
		/// three-character strings (a drive letter, a colon, and a terminating null character).
		/// </summary>
		/// <param name="servername">
		/// A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <see langword="null"/>, the local computer is used.
		/// </param>
		/// <returns>A sequence of strings (a drive letter followed by a colon).</returns>
		/// <remarks>
		/// <para>
		/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetServerDiskEnum</c> function
		/// on a remote computer.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same results you can achieve by calling the network management server functions. For more information, see the
		/// IADsComputer interface reference.
		/// </para>
		/// </remarks>
		[PInvokeData("lmserver.h", MSDNShortId = "56c981f4-7a1d-4465-bd7b-5996222c4210")]
		public static IEnumerable<string> NetServerDiskEnum([Optional] string servername)
		{
			var h = 0U;
			NetServerDiskEnum(servername, 0, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			var ptr = buf.DangerousGetHandle();
			var chSz = StringHelper.GetCharSize();
			for (var i = 0; i < cnt; i++)
			{
				yield return StringHelper.GetString(ptr);
				ptr = ptr.Offset(3 * chSz);
			}
		}

		/// <summary>The NetServerEnum function lists all servers of the specified type that are visible in a domain.</summary>
		/// <typeparam name="T">The type of the structure to have filled in for each server. This must be SERVER_INFO_100 or SERVER_INFO_101.</typeparam>
		/// <param name="netServerEnumFilter">A value that filters the server entries to return from the enumeration.</param>
		/// <param name="domain">
		/// A string that specifies the name of the domain for which a list of servers is to be returned. The domain name must be a NetBIOS
		/// domain name (for example, Microsoft). The NetServerEnum function does not support DNS-style names (for example, microsoft.com).
		/// If this parameter is NULL, the primary domain is implied.
		/// </param>
		/// <param name="level">
		/// The information level of the data requested. If this value is 0, then the method will extract all digits to form the level (e.g.
		/// SERVER_INFO_101 produces 101).
		/// </param>
		/// <returns>A managed array of the requested type.</returns>
		public static IEnumerable<T> NetServerEnum<T>(NetServerEnumFilter netServerEnumFilter = NetServerEnumFilter.SV_TYPE_WORKSTATION | NetServerEnumFilter.SV_TYPE_SERVER, string domain = null, int level = 0) where T : struct, INetServerInfo
		{
			if (level == 0) level = GetLevelFromStructure<T>();
			if (level != 100 && level != 101)
				throw new ArgumentOutOfRangeException(nameof(level), @"Only SERVER_INFO_100 or SERVER_INFO_101 are supported as valid structures.");
			var resumeHandle = IntPtr.Zero;
			NetServerEnum(null, (uint)level, out var bufptr, MAX_PREFERRED_LENGTH, out var entriesRead, out var totalEntries, netServerEnumFilter, domain, resumeHandle).ThrowIfFailed();
			return bufptr.ToIEnum<T>((int)entriesRead);
		}

		/// <summary>The NetServerGetInfo function retrieves current configuration information for the specified server.</summary>
		/// <typeparam name="T">
		/// The type of the structure to have filled in for each server. This must be SERVER_INFO_100, SERVER_INFO_101, or SERVER_INFO_102.
		/// </typeparam>
		/// <param name="serverName">
		/// A string that specifies the name of the remote server on which the function is to execute. If this parameter is NULL, the local
		/// computer is used.
		/// </param>
		/// <param name="level">
		/// The information level of the data requested. If this value is 0, then the method will extract all digits to form the level (e.g.
		/// SERVER_INFO_101 produces 101).
		/// </param>
		/// <returns>The requested type with returned information about the server.</returns>
		public static T NetServerGetInfo<T>([Optional] string serverName, int level = 0) where T : struct, INetServerInfo
		{
			if (level == 0) level = GetLevelFromStructure<T>();
			if (level != 100 && level != 101 && level != 102)
				throw new ArgumentOutOfRangeException(nameof(level), @"Only SERVER_INFO_100, SERVER_INFO_101, or SERVER_INFO_102 are supported as valid structures.");
			NetServerGetInfo(serverName, level, out var ptr).ThrowIfFailed();
			return ptr.DangerousGetHandle().ToStructure<T>();
		}

		/// <summary>
		/// The <c>NetServerTransportEnum</c> function supplies information about transport protocols that are managed by the server.
		/// </summary>
		/// <param name="servername">
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return information about the transport protocol, including name, address, and location on the network. The bufptr parameter
		/// points to an array of SERVER_TRANSPORT_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return information about the transport protocol, including name, address, network location, and domain. The bufptr parameter
		/// points to an array of SERVER_TRANSPORT_INFO_1 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data sequence. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// Only Authenticated Users can successfully call this function. <c>Windows XP/2000:</c> No special group membership is required to
		/// successfully execute this function.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about transport protocols that are managed by the server,
		/// using a call to the <c>NetServerTransportEnum</c> function. The sample calls <c>NetServerTransportEnum</c>, specifying
		/// information level 0 ( SERVER_TRANSPORT_INFO_0). The sample prints the name of each transport protocol and the total number
		/// enumerated. Finally, the code sample frees the memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmserver.h", MSDNShortId = "db42ac44-d70d-4b89-882a-6ac83fd611fd")]
		public static IEnumerable<T> NetServerTransportEnum<T>([Optional] string servername, int level = -1) where T : struct
		{
			if (level == -1) level = GetLevelFromStructure<T>();
			var h = 0U;
			NetServerTransportEnum(servername, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>Provides information about sessions established on a server.</summary>
		/// <typeparam name="T">The expected element return type associated with the <paramref name="level"/>.</typeparam>
		/// <param name="servername">
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="UncClientName">
		/// A string that specifies the name of the computer session for which information is to be returned. If this parameter is
		/// <see langword="null"/>, <c>NetSessionEnum</c> returns information for all computer sessions on the server.
		/// </param>
		/// <param name="username">
		/// A string that specifies the name of the user for which information is to be returned. If this parameter is
		/// <see langword="null"/>, <c>NetSessionEnum</c> returns information for all users.
		/// </param>
		/// <param name="level">
		/// <para>
		/// Specifies the information level of the data. This parameter can be <see cref="uint.MaxValue"/> one of the following values. If
		/// omitted or <see cref="uint.MaxValue"/>, this value will be extracted from the last digits of the name of <typeparamref name="T"/>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the name of the computer that established the session. The return value is an array of SESSION_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return the name of the computer, name of the user, and open files, pipes, and devices on the computer. The bufptr parameter
		/// points to an array of SESSION_INFO_1 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// In addition to the information indicated for level 1, return the type of client and how the user established the session. The
		/// return value is an array of SESSION_INFO_2 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>
		/// Return the name of the computer, name of the user, and active and idle times for the session. The return value is an array of
		/// SESSION_INFO_10 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>502</term>
		/// <term>
		/// Return the name of the computer; name of the user; open files, pipes, and devices on the computer; and the name of the transport
		/// the client is using. The return value is an array of SESSION_INFO_502 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>This resulting list of sessions. The format of this data depends on the value of the <paramref name="level"/> parameter.</returns>
		/// <remarks>
		/// <para>
		/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetSessionEnum</c> function at
		/// level 1 or level 2. No special group membership is required for level 0 or level 10 calls.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management session functions. For more information, see
		/// IADsSession and IADsFileServiceOperations.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about current sessions using a call to the
		/// <c>NetSessionEnum</c> function. The sample calls <c>NetSessionEnum</c>, specifying information level 10 ( SESSION_INFO_10). The
		/// sample loops through the entries and prints the retrieved information. Finally, the code prints the total number of sessions
		/// enumerated and frees the memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmshare.h", MSDNShortId = "5923a8cc-bf7a-4ffa-b089-fd7f26ee42d2")]
		public static IEnumerable<T> NetSessionEnum<T>([Optional] string servername, [Optional] string UncClientName, [Optional] string username, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = 0U;
			NetSessionEnum(servername, UncClientName, username, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>Retrieves information about a session established between a particular server and workstation.</summary>
		/// <typeparam name="T">The expected return type associated with the <paramref name="level"/>.</typeparam>
		/// <param name="servername">
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="UncClientName">
		/// A string that specifies the name of the computer session for which information is to be returned. This parameter is required and
		/// cannot be <see langword="null"/>. For more information, see NetSessionEnum.
		/// </param>
		/// <param name="username">
		/// A string that specifies the name of the user whose session information is to be returned. This parameter is required and cannot
		/// be <see langword="null"/>.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the name of the computer that established the session. The return value is a SESSION_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return the name of the computer, name of the user, and open files, pipes, and devices on the computer. The return value is a
		/// SESSION_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// In addition to the information indicated for level 1, return the type of client and how the user established the session. The
		/// return value is a SESSION_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>
		/// Return the name of the computer; name of the user; and active and idle times for the session. The return value is a
		/// SESSION_INFO_10 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetSessionGetInfo</c> function
		/// at level 1 or level 2. No special group membership is required for level 0 or level 10 calls.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management session functions. For more information, see
		/// IADsSession and IADsFileServiceOperations.
		/// </para>
		/// <para>
		/// If you call this function at information level 1 or 2 on a member server or workstation, all authenticated users can view the information.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about a session using a call to the <c>NetSessionGetInfo</c>
		/// function. The sample calls <c>NetSessionGetInfo</c>, specifying information level 10 ( SESSION_INFO_10). If the call succeeds,
		/// the code prints information about the session. Finally, the sample frees the memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmshare.h", MSDNShortId = "d44fb8d8-2b64-4268-8603-7784e2c5f2d5")]
		public static T NetSessionGetInfo<T>([Optional] string servername, string UncClientName, string username, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetSessionGetInfo(servername, UncClientName, username, level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>Shares a server resource.</summary>
		/// <typeparam name="T">The data structure used to describe the share.</typeparam>
		/// <param name="servername">
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="buf">Value that specifies the data. The format of this data depends on the value of the level parameter.</param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies information about the shared resource, including the name of the resource, type and permissions, and number of
		/// connections. The buf parameter points to a SHARE_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>502</term>
		/// <term>
		/// Specifies information about the shared resource, including the name of the resource, type and permissions, number of connections,
		/// and other pertinent information. The buf parameter points to a SHARE_INFO_502 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>503</term>
		/// <term>
		/// Specifies information about the shared resource, including the name of the resource, type and permissions, number of connections,
		/// and other pertinent information. The buf parameter points to a SHARE_INFO_503 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
		/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
		/// </para>
		/// <para>
		/// Only members of the Administrators, System Operators, or Power Users local group can add file shares with a call to the
		/// <c>NetShareAdd</c> function. The Print Operator can add printer shares.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
		/// </para>
		/// <para>
		/// If 503 is specified for the level parameter, the remote server specified in the <c>shi503_servername</c> member of the
		/// SHARE_INFO_503 structure must have been bound to a transport protocol using the NetServerTransportAddEx function. In the call to
		/// <c>NetServerTransportAddEx</c>, either 2 or 3 must have been specified for the level parameter, and the <c>SVTI2_SCOPED_NAME</c>
		/// flag must have been specified in the SERVER_TRANSPORT_INFO_2 structure for the transport protocol.
		/// </para>
		/// </remarks>
		[PInvokeData("lmshare.h", MSDNShortId = "8b51c155-24e8-4d39-b818-eb2d1bb0ee8b")]
		public static void NetShareAdd<T>([Optional] string servername, in T buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetShareAdd(servername, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>
		/// <para>Retrieves information about each shared resource on a server.</para>
		/// <para>
		/// You can also use the WNetEnumResource function to retrieve resource information. However, <c>WNetEnumResource</c> does not
		/// enumerate hidden shares or users connected to a share.
		/// </para>
		/// </summary>
		/// <typeparam name="T">The expected element return type associated with the <paramref name="level"/>.</typeparam>
		/// <param name="servername">
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return share names. The return value is an array of SHARE_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return information about shared resources, including the name and type of the resource, and a comment associated with the
		/// resource. The return value is an array of SHARE_INFO_1 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return information about shared resources, including name of the resource, type and permissions, password, and number of
		/// connections. The return value is an array of SHARE_INFO_2 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>502</term>
		/// <term>
		/// Return information about shared resources, including name of the resource, type and permissions, number of connections, and other
		/// pertinent information. The return value is an array of SHARE_INFO_502 structures. Shares from different scopes are not returned.
		/// For more information about scoping, see the Remarks section of the documentation for the NetServerTransportAddEx function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>503</term>
		/// <term>
		/// Return information about shared resources, including the name of the resource, type and permissions, number of connections, and
		/// other pertinent information. The return value is an array of SHARE_INFO_503 structures. Shares from all scopes are returned. If
		/// the shi503_servername member of this structure is "*", there is no configured server name and the NetShareEnum function
		/// enumerates shares for all the unscoped names. Windows Server 2003 and Windows XP: This information level is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the <paramref name="level"/> parameter.</returns>
		/// <remarks>
		/// <para>
		/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
		/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
		/// </para>
		/// <para>
		/// For interactive users (users who are logged on locally to the machine), no special group membership is required to execute the
		/// <c>NetShareEnum</c> function. For non-interactive users, Administrator, Power User, Print Operator, or Server Operator group
		/// membership is required to successfully execute the <c>NetShareEnum</c> function at levels 2, 502, and 503. No special group
		/// membership is required for level 0 or level 1 calls.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> For all users, Administrator, Power User, Print Operator, or Server Operator group
		/// membership is required to successfully execute the <c>NetShareEnum</c> function at levels 2 and 502.
		/// </para>
		/// <para>
		/// To retrieve a value that indicates whether a share is the root volume in a DFS tree structure, you must call the NetShareGetInfo
		/// function and specify information level 1005.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
		/// </para>
		/// </remarks>
		[PInvokeData("lmshare.h", MSDNShortId = "9114c54d-3905-4d40-9162-b3ea605f6fcb")]
		public static IEnumerable<T> NetShareEnum<T>([Optional] string servername, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = 0U;
			NetShareEnum(servername, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>Retrieves information about a particular shared resource on a server.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="netname">A string that specifies the name of the share for which to return information.</param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the share name. The return value is a SHARE_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return information about the shared resource, including the name and type of the resource, and a comment associated with the
		/// resource. The return value is a SHARE_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return information about the shared resource, including name of the resource, type and permissions, password, and number of
		/// connections. The return value is a SHARE_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>501</term>
		/// <term>
		/// Return the name and type of the resource, and a comment associated with the resource. The return value is a SHARE_INFO_501 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>502</term>
		/// <term>
		/// Return information about the shared resource, including name of the resource, type and permissions, number of connections, and
		/// other pertinent information. The return value is a SHARE_INFO_502 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>503</term>
		/// <term>
		/// Specifies information about the shared resource, including the name of the resource, type and permissions, number of connections,
		/// and other pertinent information. The return value is a SHARE_INFO_503 structure. If the shi503_servername member of this
		/// structure is "*", there is no configured server name. Windows Server 2003 and Windows XP: This information level is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1005</term>
		/// <term>
		/// Return a value that indicates whether the share is the root volume in a Dfs tree structure. The return value is a SHARE_INFO_1005 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the <paramref name="level"/> parameter.</returns>
		/// <remarks>
		/// <para>
		/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
		/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
		/// </para>
		/// <para>
		/// For interactive users (users who are logged on locally to the machine), no special group membership is required to execute the
		/// <c>NetShareGetInfo</c> function. For non-interactive users, Administrator, Power User, Print Operator, or Server Operator group
		/// membership is required to successfully execute the NetShareEnum function at levels 2, 502, and 503. No special group membership
		/// is required for level 0 or level 1 calls.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> For all users, Administrator, Power User, Print Operator, or Server Operator group
		/// membership is required to successfully execute the <c>NetShareGetInfo</c> function at levels 2 and 502.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
		/// </para>
		/// <para>
		/// If 503 is specified for the level parameter, the remote server specified in the <c>shi503_servername</c> member of the
		/// SHARE_INFO_503 structure must have been bound to a transport protocol using the NetServerTransportAddEx function. In the call to
		/// <c>NetServerTransportAddEx</c>, either 2 or 3 must have been specified for the level parameter, and the <c>SVTI2_SCOPED_NAME</c>
		/// flag must have been specified in the SERVER_TRANSPORT_INFO_2 structure for the transport protocol.
		/// </para>
		/// </remarks>
		[PInvokeData("lmshare.h", MSDNShortId = "672ea208-4048-4d2f-9606-ee3e2133765b")]
		public static T NetShareGetInfo<T>([Optional] string servername, string netname, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetShareGetInfo(servername, netname, level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>Sets the parameters of a shared resource.</summary>
		/// <typeparam name="T">The type of the data being set.</typeparam>
		/// <param name="servername">
		/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="netname">Pointer to a string that specifies the name of the share to set information on.</param>
		/// <param name="buf">The buf.</param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies information about the shared resource, including the name and type of the resource, and a comment associated with the
		/// resource. The buf parameter points to a SHARE_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies information about the shared resource, including the name of the resource, type and permissions, password, and number
		/// of connections. The buf parameter points to a SHARE_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>502</term>
		/// <term>
		/// Specifies information about the shared resource, including the name and type of the resource, required permissions, number of
		/// connections, and other pertinent information. The buf parameter points to a SHARE_INFO_502 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>503</term>
		/// <term>
		/// Specifies the name of the shared resource. The buf parameter points to a SHARE_INFO_503 structure. All members of this structure
		/// except shi503_servername are ignored by the NetShareSetInfo function. Windows Server 2003 and Windows XP: This information level
		/// is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1004</term>
		/// <term>Specifies a comment associated with the shared resource. The buf parameter points to a SHARE_INFO_1004 structure.</term>
		/// </item>
		/// <item>
		/// <term>1005</term>
		/// <term>Specifies a set of flags describing the shared resource. The buf parameter points to a SHARE_INFO_1005 structure.</term>
		/// </item>
		/// <item>
		/// <term>1006</term>
		/// <term>
		/// Specifies the maximum number of concurrent connections that the shared resource can accommodate. The buf parameter points to a
		/// SHARE_INFO_1006 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1501</term>
		/// <term>Specifies the SECURITY_DESCRIPTOR associated with the specified share. The buf parameter points to a SHARE_INFO_1501 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
		/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
		/// </para>
		/// <para>
		/// Only members of the Administrators or Power Users local group, or those with Print or Server Operator group membership, can
		/// successfully execute the <c>NetShareSetInfo</c> function. The Print Operator can set information only about Printer shares.
		/// </para>
		/// <para>
		/// If the <c>NetShareSetInfo</c> function returns <c>ERROR_INVALID_PARAMETER</c>, you can use the parm_err parameter to indicate the
		/// first member of the share information structure that is not valid. (A share information structure begins with <c>SHARE_INFO_</c>
		/// and its format is specified by the level parameter.) The following table lists the values that can be returned in the parm_err
		/// parameter and the corresponding structure member that is in error. (The prefix <c>shi*</c> indicates that the member can begin
		/// with multiple prefixes, for example, shi2 or <c>shi502_</c>.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>SHARE_NETNAME_PARMNUM</term>
		/// <term>shi*_netname</term>
		/// </item>
		/// <item>
		/// <term>SHARE_TYPE_PARMNUM</term>
		/// <term>shi*_type</term>
		/// </item>
		/// <item>
		/// <term>SHARE_REMARK_PARMNUM</term>
		/// <term>shi*_remark</term>
		/// </item>
		/// <item>
		/// <term>SHARE_PERMISSIONS_PARMNUM</term>
		/// <term>shi*_permissions</term>
		/// </item>
		/// <item>
		/// <term>SHARE_MAX_USES_PARMNUM</term>
		/// <term>shi*_max_uses</term>
		/// </item>
		/// <item>
		/// <term>SHARE_CURRENT_USES_PARMNUM</term>
		/// <term>shi*_current_uses</term>
		/// </item>
		/// <item>
		/// <term>SHARE_PATH_PARMNUM</term>
		/// <term>shi*_path</term>
		/// </item>
		/// <item>
		/// <term>SHARE_PASSWD_PARMNUM</term>
		/// <term>shi*_passwd</term>
		/// </item>
		/// <item>
		/// <term>SHARE_FILE_SD_PARMNUM</term>
		/// <term>shi*_security_descriptor</term>
		/// </item>
		/// </list>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
		/// </para>
		/// <para>
		/// If 503 is specified for the level parameter, the remote server specified in the <c>shi503_servername</c> member of the
		/// SHARE_INFO_503 structure must have been bound to a transport protocol using the NetServerTransportAddEx function. In the call to
		/// <c>NetServerTransportAddEx</c>, either 2 or 3 must have been specified for the level parameter, and the <c>SVTI2_SCOPED_NAME</c>
		/// flag must have been specified in the SERVER_TRANSPORT_INFO_2 structure for the transport protocol.
		/// </para>
		/// </remarks>
		[PInvokeData("lmshare.h", MSDNShortId = "216b0b78-87da-4734-ad07-5ad1c9edf494")]
		public static void NetShareSetInfo<T>([Optional] string servername, string netname, in T buf, uint level = uint.MaxValue) where T : struct
		{
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var err = NetShareSetInfo(servername, netname, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>
		/// The <c>NetUseAdd</c> function establishes a connection between the local computer and a remote server. You can specify a local
		/// drive letter or a printer device to connect. If you do not specify a local drive letter or printer device, the function
		/// authenticates the client with the server for future connections.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// <para>
		/// The UNC name of the computer on which to execute this function. If this parameter is <c>NULL</c>, then the local computer is
		/// used. If the UncServerName parameter specified is a remote computer, then the remote computer must support remote RPC calls using
		/// the legacy Remote Access Protocol mechanism.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </param>
		/// <param name="buf">The data. The format of this data depends on the value of the Level parameter.</param>
		/// <param name="LevelFlags">
		/// <para>A value that specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
		/// status and type. The Buf parameter is a pointer to a USE_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
		/// status and type, and a user name and domain name. The Buf parameter is a pointer to a USE_INFO_2 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>You can also use the WNetAddConnection2 and WNetAddConnection3 functions to redirect a local device to a network resource.</para>
		/// <para>
		/// No special group membership is required to call the <c>NetUseAdd</c> function. This function cannot be executed on a remote
		/// server except in cases of downlevel compatibility.
		/// </para>
		/// <para>
		/// This function applies only to the Server Message Block (LAN Manager Workstation) client. The <c>NetUseAdd</c> function does not
		/// support Distributed File System (DFS) shares. To add a share using a different network provider (WebDAV or a DFS share, for
		/// example), use the WNetAddConnection2 or WNetAddConnection3 function.
		/// </para>
		/// <para>
		/// If the <c>NetUseAdd</c> function returns ERROR_INVALID_PARAMETER, you can use the ParmError parameter to indicate the first
		/// member of the information structure that is invalid. (The information structure begins with USE_INFO_ and its format is specified
		/// by the Level parameter.) The following table lists the values that can be returned in the ParmError parameter and the
		/// corresponding structure member that is in error. (The prefix ui*_ indicates that the member can begin with multiple prefixes, for
		/// example, ui1_ or ui2_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant</term>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>USE_LOCAL_PARMNUM</term>
		/// <term>1</term>
		/// <term>ui*_local</term>
		/// </item>
		/// <item>
		/// <term>USE_REMOTE_PARMNUM</term>
		/// <term>2</term>
		/// <term>ui*_remote</term>
		/// </item>
		/// <item>
		/// <term>USE_PASSWORD_PARMNUM</term>
		/// <term>3</term>
		/// <term>ui*_password</term>
		/// </item>
		/// <item>
		/// <term>USE_ASGTYPE_PARMNUM</term>
		/// <term>4</term>
		/// <term>ui*_asg_type</term>
		/// </item>
		/// <item>
		/// <term>USE_USERNAME_PARMNUM</term>
		/// <term>5</term>
		/// <term>ui*_username</term>
		/// </item>
		/// <item>
		/// <term>USE_DOMAINNAME_PARMNUM</term>
		/// <term>6</term>
		/// <term>ui*_domainname</term>
		/// </item>
		/// </list>
		/// </remarks>
		[PInvokeData("lmuse.h", MSDNShortId = "22550c17-003a-4f59-80f0-58fa3e286844")]
		public static void NetUseAdd<T>([Optional] string servername, in T buf, uint LevelFlags = uint.MaxValue) where T : struct
		{
			if (LevelFlags == uint.MaxValue) LevelFlags = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetUseAdd(servername, LevelFlags, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>
		/// <para>The <c>NetUseEnum</c> function lists all current connections between the local computer and resources on remote servers.</para>
		/// <para>You can also use the WNetOpenEnum and the WNetEnumResource functions to enumerate network resources or connections.</para>
		/// </summary>
		/// <typeparam name="T">The expected element return type associated with the <paramref name="LevelFlags"/>.</typeparam>
		/// <param name="UncServerName">
		/// <para>
		/// The UNC name of the computer on which to execute this function. If this is parameter is <c>NULL</c>, then the local computer is
		/// used. If the UncServerName parameter specified is a remote computer, then the remote computer must support remote RPC calls using
		/// the legacy Remote Access Protocol mechanism.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </param>
		/// <param name="LevelFlags">
		/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies a local device name and the share name of a remote resource. The BufPtr parameter points to an array of USE_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies information about the connection between a local device and a shared resource, including connection status and type.
		/// The BufPtr parameter points to an array of USE_INFO_1 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
		/// status, connection type, user name, and domain name. The BufPtr parameter points to an array of USE_INFO_2 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The information structures. The format of this data depends on the value of the Level parameter.</returns>
		/// <remarks>
		/// <para>
		/// No special group membership is required to call the <c>NetUseEnum</c> function. This function cannot be executed on a remote
		/// server except in cases of downlevel compatibility using the legacy Remote Access Protocol.
		/// </para>
		/// <para>To retrieve information about one network connection, you can call the NetUseGetInfo function.</para>
		/// <para>
		/// This function applies only to the Server Message Block (LAN Manager Workstation) client. The <c>NetUseEnum</c> function does not
		/// support Distributed File System (DFS) shares. To enumerate shares using a different network provider (WebDAV or a DFS share, for
		/// example), use the WNetOpenEnum, WNetEnumResource, and WNetCloseEnum functions.
		/// </para>
		/// </remarks>
		[PInvokeData("lmuse.h", MSDNShortId = "fb527f85-baea-48e8-b837-967870834ec5")]
		public static IEnumerable<T> NetUseEnum<T>([Optional] string UncServerName, uint LevelFlags = uint.MaxValue) where T : struct
		{
			if (LevelFlags == uint.MaxValue) LevelFlags = (uint)GetLevelFromStructure<T>();
			var h = 0U;
			NetUseEnum(UncServerName, LevelFlags, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>
		/// <para>The <c>NetUseGetInfo</c> function retrieves information about a connection to a shared resource.</para>
		/// <para>You can also use the WNetGetConnection function to retrieve the name of a network resource associated with a local device.</para>
		/// </summary>
		/// <param name="UncServerName">
		/// <para>
		/// The UNC name of computer on which to execute this function. If this is parameter is <c>NULL</c>, then the local computer is used.
		/// If the UncServerName parameter specified is a remote computer, then the remote computer must support remote RPC calls using the
		/// legacy Remote Access Protocol mechanism.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </param>
		/// <param name="UseName">
		/// <para>A pointer to a string that specifies the name of the connection for which to return information.</para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </param>
		/// <param name="LevelFlags">
		/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies a local device name and the share name of a remote resource. The BufPtr parameter is a pointer to a USE_INFO_0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies information about the connection between a local device and a shared resource, including connection status and type.
		/// The BufPtr parameter is a pointer to a USE_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
		/// status, connection type, user name, and domain name. The BufPtr parameter is a pointer to a USE_INFO_2 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the Level parameter.</returns>
		/// <remarks>
		/// <para>
		/// No special group membership is required to call the <c>NetUseGetInfo</c> function. This function cannot be executed on a remote
		/// server except in cases of downlevel compatibility.
		/// </para>
		/// <para>
		/// To list all current connections between the local computer and resources on remote servers, you can call the NetUseEnum function.
		/// </para>
		/// <para>
		/// This function applies only to the Server Message Block (LAN Manager Workstation) client. The <c>NetUseGetInfo</c> function does
		/// not support Distributed File System (DFS) shares. To retrieve information for a share using a different network provider (WebDAV
		/// or a DFS share, for example), use the WNetGetConnection function.
		/// </para>
		/// </remarks>
		[PInvokeData("lmuse.h", MSDNShortId = "257875db-5ed9-4569-8dbb-5dcc7a6af95c")]
		public static T NetUseGetInfo<T>([Optional] string UncServerName, string UseName, uint LevelFlags = uint.MaxValue) where T : struct
		{
			if (LevelFlags == uint.MaxValue) LevelFlags = (uint)GetLevelFromStructure<T>();
			NetUseGetInfo(UncServerName, UseName, LevelFlags, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>The <c>NetUserAdd</c> function adds a user account and assigns a password and privilege level.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// <para>
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </param>
		/// <param name="buf">
		/// The data. The format of this data depends on the value of the level parameter. For more information, see Network Management
		/// Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies information about the user account. The buf parameter points to a USER_INFO_1 structure. When you specify this level,
		/// the call initializes certain attributes to their default values. For more information, see the following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies level one information and additional attributes about the user account. The buf parameter points to a USER_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies level two information and additional attributes about the user account. This level is valid only on servers. The buf
		/// parameter points to a USER_INFO_3 structure. Note that it is recommended that you use USER_INFO_4 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>
		/// Specifies level two information and additional attributes about the user account. This level is valid only on servers. The buf
		/// parameter points to a USER_INFO_4 structure. Windows 2000: This level is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the user container is used to perform the access check for this function. The caller must be able to
		/// create child objects of the user class.
		/// </para>
		/// <para>
		/// Server users must use a system in which the server creates a system account for the new user. The creation of this account is
		/// controlled by several parameters in the server's LanMan.ini file.
		/// </para>
		/// <para>
		/// If the newly added user already exists as a system user, the <c>usri1_home_dir</c> member of the USER_INFO_1 structure is ignored.
		/// </para>
		/// <para>
		/// When you call the <c>NetUserAdd</c> function and specify information level 1, the call initializes the additional members in the
		/// USER_INFO_2, USER_INFO_3, and USER_INFO_4 structures to their default values. You can change the default values by making
		/// subsequent calls to the NetUserSetInfo function. The default values supplied are listed following. (The prefix usriX indicates
		/// that the member can begin with multiple prefixes, for example, usri2_ or usri4_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Default Value</term>
		/// </listheader>
		/// <item>
		/// <term>usriX_auth_flags</term>
		/// <term>None (0)</term>
		/// </item>
		/// <item>
		/// <term>usriX_full_name</term>
		/// <term>None (null string)</term>
		/// </item>
		/// <item>
		/// <term>usriX_usr_comment</term>
		/// <term>None (null string)</term>
		/// </item>
		/// <item>
		/// <term>usriX_parms</term>
		/// <term>None (null string)</term>
		/// </item>
		/// <item>
		/// <term>usriX_workstations</term>
		/// <term>All (null string)</term>
		/// </item>
		/// <item>
		/// <term>usriX_acct_expires</term>
		/// <term>Never (TIMEQ_FOREVER)</term>
		/// </item>
		/// <item>
		/// <term>usriX_max_storage</term>
		/// <term>Unlimited (USER_MAXSTORAGE_UNLIMITED)</term>
		/// </item>
		/// <item>
		/// <term>usriX_logon_hours</term>
		/// <term>Logon allowed at any time (each element 0xFF; all bits set to 1)</term>
		/// </item>
		/// <item>
		/// <term>usriX_logon_server</term>
		/// <term>Any domain controller (\\*)</term>
		/// </item>
		/// <item>
		/// <term>usriX_country_code</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>usriX_code_page</term>
		/// <term>0</term>
		/// </item>
		/// </list>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to add a user account and assign a privilege level using a call to the
		/// <c>NetUserAdd</c> function. The code sample fills in the members of the USER_INFO_1 structure and calls <c>NetUserAdd</c>,
		/// specifying information level 1.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "b5ca5f76-d40b-4abf-925a-0de54fc476e4")]
		public static void NetUserAdd<T>([Optional] string servername, in T buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetUserAdd(servername, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>The <c>NetUserEnum</c> function retrieves information about all user accounts on a server.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="filter">
		/// <para>
		/// A value that specifies the user account types to be included in the enumeration. A value of zero indicates that all normal user,
		/// trust data, and machine account data should be included.
		/// </para>
		/// <para>This parameter can also be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILTER_TEMP_DUPLICATE_ACCOUNT</term>
		/// <term>
		/// Enumerates account data for users whose primary account is in another domain. This account type provides user access to this
		/// domain, but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILTER_NORMAL_ACCOUNT</term>
		/// <term>Enumerates normal user account data. This account type is associated with a typical user.</term>
		/// </item>
		/// <item>
		/// <term>FILTER_INTERDOMAIN_TRUST_ACCOUNT</term>
		/// <term>
		/// Enumerates interdomain trust account data. This account type is associated with a trust account for a domain that trusts other domains.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILTER_WORKSTATION_TRUST_ACCOUNT</term>
		/// <term>
		/// Enumerates workstation or member server trust account data. This account type is associated with a machine account for a computer
		/// that is a member of the domain.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILTER_SERVER_TRUST_ACCOUNT</term>
		/// <term>
		/// Enumerates member server machine account data. This account type is associated with a computer account for a backup domain
		/// controller that is a member of the domain.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return user account names. The bufptr parameter points to an array of USER_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return detailed information about user accounts. The bufptr parameter points to an array of USER_INFO_1 structures.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return detailed information about user accounts, including authorization levels and logon information. The bufptr parameter
		/// points to an array of USER_INFO_2 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return detailed information about user accounts, including authorization levels, logon information, RIDs for the user and the
		/// primary group, and profile information. The bufptr parameter points to an array of USER_INFO_3 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>Return user and account names and comments. The bufptr parameter points to an array of USER_INFO_10 structures.</term>
		/// </item>
		/// <item>
		/// <term>11</term>
		/// <term>Return detailed information about user accounts. The bufptr parameter points to an array of USER_INFO_11 structures.</term>
		/// </item>
		/// <item>
		/// <term>20</term>
		/// <term>
		/// Return the user's name and identifier and various account attributes. The bufptr parameter points to an array of USER_INFO_20
		/// structures. Note that on Windows XP and later, it is recommended that you use USER_INFO_23 instead.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// The <c>NetUserEnum</c> function retrieves information about all user accounts on a specified remote server or the local computer.
		/// </para>
		/// <para>
		/// The NetQueryDisplayInformation function can be used to quickly enumerate user, computer, or global group account information for
		/// display in user interfaces .
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call the <c>NetUserEnum</c> function on a domain controller that is running Active Directory, access is allowed or denied
		/// based on the access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of
		/// the "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or
		/// workstation, all authenticated users can view the information. For information about anonymous access and restricting anonymous
		/// access on these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs,
		/// and access tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The <c>NetUserEnum</c> function only returns information to which the caller has Read access. The caller must have List Contents
		/// access to the Domain object, and Enumerate Entire SAM Domain access on the SAM Server object located in the System container.
		/// </para>
		/// <para>
		/// The LsaEnumerateTrustedDomains or LsaEnumerateTrustedDomainsEx function can be used to retrieve the names and SIDs of domains
		/// trusted by a Local Security Authority (LSA) policy object.
		/// </para>
		/// <para>
		/// The <c>NetUserEnum</c> function does not return all system users. It returns only those users who have been added with a call to
		/// the NetUserAdd function. There is no guarantee that the list of users will be returned in sorted order.
		/// </para>
		/// <para>
		/// If you call the <c>NetUserEnum</c> function and specify information level 1, 2, or 3, for the level parameter, the password
		/// member of each structure retrieved is set to <c>NULL</c> to maintain password security.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// The <c>NetUserEnum</c> function does not support a level parameter of 4 and the USER_INFO_4 structure. The NetUserGetInfo
		/// function supports a level parameter of 4 and the <c>USER_INFO_4</c> structure.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about the user accounts on a server with a call to the
		/// <c>NetUserEnum</c> function. The sample calls <c>NetUserEnum</c>, specifying information level 0 (USER_INFO_0) to enumerate only
		/// global user accounts. If the call succeeds, the code loops through the entries and prints the name of each user account. Finally,
		/// the code sample frees the memory allocated for the information buffer and prints a total of the users enumerated.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "b26ef3c0-934a-4840-8c06-4eaff5c9ff86")]
		public static IEnumerable<T> NetUserEnum<T>([Optional] string servername, UserEnumFilter filter = 0, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = 0U;
			NetUserEnum(servername, level, filter, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>The <c>NetUserGetGroups</c> function retrieves a list of global groups to which a specified user belongs.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user to search for in each group account. For more information, see
		/// the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the names of the global groups to which the user belongs. The bufptr parameter points to an array of GROUP_USERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return the names of the global groups to which the user belongs with attributes. The bufptr parameter points to an array of
		/// GROUP_USERS_INFO_1 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data.</returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
		/// <para>
		/// To retrieve a list of the local groups to which a user belongs, you can call the NetUserGetLocalGroups function. Network groups
		/// are separate and distinct from Windows NT system groups.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve a list of global groups to which a user belongs with a call to the
		/// <c>NetUserGetGroups</c> function. The sample calls <c>NetUserGetGroups</c>, specifying information level 0 ( GROUP_USERS_INFO_0).
		/// The code loops through the entries and prints the name of the global groups in which the user has membership. The sample also
		/// prints the total number of entries that are available and the number of entries actually enumerated if they do not match.
		/// Finally, the code sample frees the memory allocated for the buffer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "ecf1a94c-5dda-4f49-81bd-93e551e089f1")]
		public static IEnumerable<T> NetUserGetGroups<T>([Optional] string servername, string username, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetUserGetGroups(servername, username, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>The <c>NetUserGetInfo</c> function retrieves information about a particular user account on a server.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user account for which to return information. For more information,
		/// see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the user account name. The bufptr parameter points to a USER_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return detailed information about the user account. The bufptr parameter points to a USER_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return detailed information and additional attributes about the user account. The bufptr parameter points to a USER_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return detailed information and additional attributes about the user account. This level is valid only on servers. The bufptr
		/// parameter points to a USER_INFO_3 structure. Note that it is recommended that you use USER_INFO_4 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>
		/// Return detailed information and additional attributes about the user account. This level is valid only on servers. The bufptr
		/// parameter points to a USER_INFO_4 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>Return user and account names and comments. The bufptr parameter points to a USER_INFO_10 structure.</term>
		/// </item>
		/// <item>
		/// <term>11</term>
		/// <term>Return detailed information about the user account. The bufptr parameter points to a USER_INFO_11 structure.</term>
		/// </item>
		/// <item>
		/// <term>20</term>
		/// <term>
		/// Return the user's name and identifier and various account attributes. The bufptr parameter points to a USER_INFO_20 structure.
		/// Note that on Windows XP and later, it is recommended that you use USER_INFO_23 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>23</term>
		/// <term>Return the user's name and identifier and various account attributes. The bufptr parameter points to a USER_INFO_23 structure.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Return user account information for accounts which are connected to an Internet identity. The bufptr parameter points to a
		/// USER_INFO_24 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If the information level specified in the level parameter is set to 24, the servername parameter specified must resolve to the
		/// local computer. If the servername resolves to a remote computer or to a domain controller, the <c>NetUserGetInfo</c> function
		/// will fail.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about a particular user account with a call to the
		/// <c>NetUserGetInfo</c> function. The sample calls <c>NetUserGetInfo</c>, specifying various information levels . If the call
		/// succeeds, the code prints information about the user account. Finally, the sample frees the memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "5bd13bed-938a-4273-840e-99fca99f7139")]
		public static T NetUserGetInfo<T>([Optional] string servername, string username, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetUserGetInfo(servername, username, level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>The <c>NetUserGetLocalGroups</c> function retrieves a list of local groups to which a specified user belongs.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user for which to return local group membership information. If the
		/// string is of the form DomainName&lt;i&gt;UserName the user name is expected to be found on that domain. If the string is of the
		/// form UserName, the user name is expected to be found on the server specified by the servername parameter. For more information,
		/// see the Remarks section.
		/// </param>
		/// <param name="flags">
		/// A bitmask of flags that affect the operation. Currently, only the value defined is <c>LG_INCLUDE_INDIRECT</c>. If this bit is
		/// set, the function also returns the names of the local groups in which the user is indirectly a member (that is, the user has
		/// membership in a global group that is itself a member of one or more local groups).
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the names of the local groups to which the user belongs. The bufptr parameter points to an array of
		/// LOCALGROUP_USERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the Domain object is used to perform the access check for this function. The caller must have Read
		/// Property permission on the Domain object.
		/// </para>
		/// <para>To retrieve a list of global groups to which a specified user belongs, you can call the NetUserGetGroups function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve a list of the local groups to which a user belongs with a call to the
		/// <c>NetUserGetLocalGroups</c> function. The sample calls <c>NetUserGetLocalGroups</c>, specifying information level 0
		/// (LOCALGROUP_USERS_INFO_0). The sample loops through the entries and prints the name of each local group in which the user has
		/// membership. If all available entries are not enumerated, it also prints the number of entries actually enumerated and the total
		/// number of entries available. Finally, the code sample frees the memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "cc5c1c15-cad7-4103-a2c9-1a8adf742703")]
		public static IEnumerable<T> NetUserGetLocalGroups<T>([Optional] string servername, string username, GetLocalGroupFlags flags = 0, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetUserGetLocalGroups(servername, username, level, flags, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>
		/// The <c>NetUserModalsGet</c> function retrieves global information for all users and global groups in the security database, which
		/// is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used. For more information, see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return global password parameters. The bufptr parameter points to a USER_MODALS_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return logon server and domain controller information. The bufptr parameter points to a USER_MODALS_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return domain name and identifier. The bufptr parameter points to a USER_MODALS_INFO_2 structure. For more information, see the
		/// following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Return lockout information. The bufptr parameter points to a USER_MODALS_INFO_3 structure.</term>
		/// </item>
		/// </list>
		/// <para>A null session logon can call <c>NetUserModalsGet</c> anonymously at information levels 0 and 3.</para>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user modal functions. For more information, see IADsDomain.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the Domain object is used to perform the access check for this function.</para>
		/// <para>
		/// To retrieve the security identifier (SID) of the domain to which the computer belongs, call the <c>NetUserModalsGet</c> function
		/// specifying a USER_MODALS_INFO_2 structure and <c>NULL</c> in the servername parameter. If the computer isn't a member of a
		/// domain, the function returns a <c>NULL</c> pointer.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve global information for all users and global groups with a call to the
		/// <c>NetUserModalsGet</c> function. The sample calls <c>NetUserModalsGet</c>, specifying information level 0 (USER_MODALS_INFO_0).
		/// If the call succeeds, the sample prints global password information. Finally, the code sample frees the memory allocated for the
		/// information buffer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "5bb18144-82a6-4e9b-8321-c06a667bdd03")]
		public static T NetUserModalsGet<T>([Optional] string servername, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetUserModalsGet(servername, level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>
		/// The <c>NetUserModalsSet</c> function sets global information for all users and global groups in the security database, which is
		/// the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="buf">
		/// The data. The format of this data depends on the value of the level parameter. For more information, see Network Management
		/// Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Specifies global password parameters. The buf parameter points to a USER_MODALS_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Specifies logon server and domain controller information. The buf parameter points to a USER_MODALS_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Specifies the domain name and identifier. The buf parameter points to a USER_MODALS_INFO_2 structure.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Specifies lockout information. The buf parameter points to a USER_MODALS_INFO_3 structure.</term>
		/// </item>
		/// <item>
		/// <term>1001</term>
		/// <term>Specifies the minimum allowable password length. The buf parameter points to a USER_MODALS_INFO_1001 structure.</term>
		/// </item>
		/// <item>
		/// <term>1002</term>
		/// <term>Specifies the maximum allowable password age. The buf parameter points to a USER_MODALS_INFO_1002 structure.</term>
		/// </item>
		/// <item>
		/// <term>1003</term>
		/// <term>Specifies the minimum allowable password age. The buf parameter points to a USER_MODALS_INFO_1003 structure.</term>
		/// </item>
		/// <item>
		/// <term>1004</term>
		/// <term>Specifies forced logoff information. The buf parameter points to a USER_MODALS_INFO_1004 structure.</term>
		/// </item>
		/// <item>
		/// <term>1005</term>
		/// <term>Specifies the length of the password history. The buf parameter points to a USER_MODALS_INFO_1005 structure.</term>
		/// </item>
		/// <item>
		/// <term>1006</term>
		/// <term>Specifies the role of the logon server. The buf parameter points to a USER_MODALS_INFO_1006 structure.</term>
		/// </item>
		/// <item>
		/// <term>1007</term>
		/// <term>Specifies domain controller information. The buf parameter points to a USER_MODALS_INFO_1007 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user modal functions. For more information, see IADsDomain.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the Domain object is used to perform the access check for this function. Typically, callers must have
		/// write access to the entire object for calls to this function to succeed.
		/// </para>
		/// <para>
		/// If the <c>NetUserModalsSet</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the first
		/// member of the information structure that is invalid. (The information structure begins with USER_MODALS_INFO_ and its format is
		/// specified by the level parameter.) The following table lists the values that can be returned in the parm_err parameter and the
		/// corresponding structure member that is in error. (The prefix usrmod*_ indicates that the member can begin with multiple prefixes,
		/// for example, usrmod2_ or usrmod1002_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>MODALS_MIN_PASSWD_LEN_PARMNUM</term>
		/// <term>usrmod*_min_passwd_len</term>
		/// </item>
		/// <item>
		/// <term>MODALS_MAX_PASSWD_AGE_PARMNUM</term>
		/// <term>usrmod*_max_passwd_age</term>
		/// </item>
		/// <item>
		/// <term>MODALS_MIN_PASSWD_AGE_PARMNUM</term>
		/// <term>usrmod*_min_passwd_age</term>
		/// </item>
		/// <item>
		/// <term>MODALS_FORCE_LOGOFF_PARMNUM</term>
		/// <term>usrmod*_force_logoff</term>
		/// </item>
		/// <item>
		/// <term>MODALS_PASSWD_HIST_LEN_PARMNUM</term>
		/// <term>usrmod*_password_hist_len</term>
		/// </item>
		/// <item>
		/// <term>MODALS_ROLE_PARMNUM</term>
		/// <term>usrmod*_role</term>
		/// </item>
		/// <item>
		/// <term>MODALS_PRIMARY_PARMNUM</term>
		/// <term>usrmod*_primary</term>
		/// </item>
		/// <item>
		/// <term>MODALS_DOMAIN_NAME_PARMNUM</term>
		/// <term>usrmod*_domain_name</term>
		/// </item>
		/// <item>
		/// <term>MODALS_DOMAIN_ID_PARMNUM</term>
		/// <term>usrmod*_domain_id</term>
		/// </item>
		/// <item>
		/// <term>MODALS_LOCKOUT_DURATION_PARMNUM</term>
		/// <term>usrmod*_lockout_duration</term>
		/// </item>
		/// <item>
		/// <term>MODALS_LOCKOUT_OBSERVATION_WINDOW_PARMNUM</term>
		/// <term>usrmod*_lockout_observation_window</term>
		/// </item>
		/// <item>
		/// <term>MODALS_LOCKOUT_THRESHOLD_PARMNUM</term>
		/// <term>usrmod*_lockout_threshold</term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to set the global information for all users and global groups with a call to the
		/// <c>NetUserModalsSet</c> function. The sample fills in the members of the USER_MODALS_INFO_0 structure and calls
		/// <c>NetUserModalsSet</c>, specifying information level 0.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "9884e076-ee6a-4aca-abe6-a79754667759")]
		public static void NetUserModalsSet<T>([Optional] string servername, in T buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetUserModalsSet(servername, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>The <c>NetUserSetGroups</c> function sets global group memberships for a specified user account.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user for which to set global group memberships. For more
		/// information, see the Remarks section.
		/// </param>
		/// <param name="buf">The data. For more information, see Network Management Function Buffers.</param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The buf parameter points to an array of GROUP_USERS_INFO_0 structures that specifies global group names.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>The buf parameter points to an array of GROUP_USERS_INFO_1 structures that specifies global group names with attributes.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
		/// <para>To grant a user membership in one existing global group, you can call the NetGroupAddUser function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to set global group memberships for a user account with a call to the
		/// <c>NetUserSetGroups</c> function. The code sample fills in the <c>grui0_name</c> member of the GROUP_USERS_INFO_0 structure and
		/// calls <c>NetUserSetGroups</c>, specifying information level 0.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "7042c43a-09d1-4179-8074-eb055dc279a6")]
		public static void NetUserSetGroups<T>([Optional] string servername, string username, T[] buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			using (var mem = SafeHGlobalHandle.CreateFromList(buf))
				NetUserSetGroups(servername, username, level, (IntPtr)mem, (uint)buf.Length).ThrowIfFailed();
		}

		/// <summary>The <c>NetUserSetInfo</c> function sets the parameters of a user account.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user account for which to set information. For more information,
		/// see the following Remarks section.
		/// </param>
		/// <param name="buf">
		/// The data. The format of this data depends on the value of the level parameter. For more information, see Network Management
		/// Function Buffers.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the user account name. The buf parameter points to a USER_INFO_0 structure. Use this structure to specify a new group
		/// name. For more information, see the following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Specifies detailed information about the user account. The buf parameter points to a USER_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies level one information and additional attributes about the user account. The buf parameter points to a USER_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies level two information and additional attributes about the user account. This level is valid only on servers. The buf
		/// parameter points to a USER_INFO_3 structure. Note that it is recommended that you use USER_INFO_4 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>
		/// Specifies level two information and additional attributes about the user account. This level is valid only on servers. The buf
		/// parameter points to a USER_INFO_4 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>21</term>
		/// <term>Specifies a one-way encrypted LAN Manager 2.x-compatible password. The buf parameter points to a USER_INFO_21 structure.</term>
		/// </item>
		/// <item>
		/// <term>22</term>
		/// <term>Specifies detailed information about the user account. The buf parameter points to a USER_INFO_22 structure.</term>
		/// </item>
		/// <item>
		/// <term>1003</term>
		/// <term>Specifies a user password. The buf parameter points to a USER_INFO_1003 structure.</term>
		/// </item>
		/// <item>
		/// <term>1005</term>
		/// <term>Specifies a user privilege level. The buf parameter points to a USER_INFO_1005 structure.</term>
		/// </item>
		/// <item>
		/// <term>1006</term>
		/// <term>Specifies the path of the home directory for the user. The buf parameter points to a USER_INFO_1006 structure.</term>
		/// </item>
		/// <item>
		/// <term>1007</term>
		/// <term>Specifies a comment to associate with the user account. The buf parameter points to a USER_INFO_1007 structure.</term>
		/// </item>
		/// <item>
		/// <term>1008</term>
		/// <term>Specifies user account attributes. The buf parameter points to a USER_INFO_1008 structure.</term>
		/// </item>
		/// <item>
		/// <term>1009</term>
		/// <term>Specifies the path for the user's logon script file. The buf parameter points to a USER_INFO_1009 structure.</term>
		/// </item>
		/// <item>
		/// <term>1010</term>
		/// <term>Specifies the user's operator privileges. The buf parameter points to a USER_INFO_1010 structure.</term>
		/// </item>
		/// <item>
		/// <term>1011</term>
		/// <term>Specifies the full name of the user. The buf parameter points to a USER_INFO_1011 structure.</term>
		/// </item>
		/// <item>
		/// <term>1012</term>
		/// <term>Specifies a comment to associate with the user. The buf parameter points to a USER_INFO_1012 structure.</term>
		/// </item>
		/// <item>
		/// <term>1014</term>
		/// <term>Specifies the names of workstations from which the user can log on. The buf parameter points to a USER_INFO_1014 structure.</term>
		/// </item>
		/// <item>
		/// <term>1017</term>
		/// <term>Specifies when the user account expires. The buf parameter points to a USER_INFO_1017 structure.</term>
		/// </item>
		/// <item>
		/// <term>1020</term>
		/// <term>Specifies the times during which the user can log on. The buf parameter points to a USER_INFO_1020 structure.</term>
		/// </item>
		/// <item>
		/// <term>1024</term>
		/// <term>Specifies the user's country/region code. The buf parameter points to a USER_INFO_1024 structure.</term>
		/// </item>
		/// <item>
		/// <term>1051</term>
		/// <term>
		/// Specifies the relative identifier of a global group that represents the enrolled user. The buf parameter points to a
		/// USER_INFO_1051 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1052</term>
		/// <term>Specifies the path to a network user's profile. The buf parameter points to a USER_INFO_1052 structure.</term>
		/// </item>
		/// <item>
		/// <term>1053</term>
		/// <term>Specifies the drive letter assigned to the user's home directory. The buf parameter points to a USER_INFO_1053 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
		/// <para>
		/// Only users or applications having administrative privileges can call the <c>NetUserSetInfo</c> function to change a user's
		/// password. When an administrator calls <c>NetUserSetInfo</c>, the only restriction applied is that the new password length must be
		/// consistent with system modals. A user or application that knows a user's current password can call the NetUserChangePassword
		/// function to change the password. For more information about calling functions that require administrator privileges, see Running
		/// with Special Privileges.
		/// </para>
		/// <para>
		/// Members of the Administrators local group can set any modifiable user account elements. All users can set the
		/// <c>usri2_country_code</c> member of the USER_INFO_2 structure (and the <c>usri1024_country_code</c> member of the USER_INFO_1024
		/// structure) for their own accounts.
		/// </para>
		/// <para>
		/// A member of the Account Operator's local group cannot set details for an Administrators class account, give an existing account
		/// Administrator privilege, or change the operator privilege of any account. If you attempt to change the privilege level or disable
		/// the last account with Administrator privilege in the security database, (the security accounts manager (SAM) database or, in the
		/// case of domain controllers, the Active Directory), the <c>NetUserSetInfo</c> function fails and returns NERR_LastAdmin.
		/// </para>
		/// <para>To set the following user account control flags, the following privileges and control access rights are required.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Account control flag</term>
		/// <term>Privilege or right required</term>
		/// </listheader>
		/// <item>
		/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
		/// <term>SeEnableDelegationPrivilege privilege, which is granted to Administrators by default.</term>
		/// </item>
		/// <item>
		/// <term>UF_TRUSTED_FOR_DELEGATION</term>
		/// <term>SeEnableDelegationPrivilege.</term>
		/// </item>
		/// <item>
		/// <term>UF_PASSWD_NOTREQD</term>
		/// <term>"Update password not required" control access right on the Domain object, which is granted to authenticated users by default.</term>
		/// </item>
		/// <item>
		/// <term>UF_DONT_EXPIRE_PASSWD</term>
		/// <term>"Unexpire password" control access right on the Domain object, which is granted to authenticated users by default.</term>
		/// </item>
		/// <item>
		/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
		/// <term>
		/// "Enable per user reversibly encrypted password" control access right on the Domain object, which is granted to authenticated
		/// users by default.
		/// </term>
		/// </item>
		/// <item>
		/// <term>UF_SERVER_TRUST_ACCOUNT</term>
		/// <term>"Add/remove replica in domain" control access right on the Domain object, which is granted to Administrators by default.</term>
		/// </item>
		/// </list>
		/// <para>For a list of privilege constants, see Authorization Constants.</para>
		/// <para>
		/// The correct way to specify the new name for an account is to call <c>NetUserSetInfo</c> with USER_INFO_0 and to specify the new
		/// value using the <c>usri0_name</c> member. If you call <c>NetUserSetInfo</c> with other information levels and specify a value
		/// using a <c>usriX_name</c> member, the value is ignored.
		/// </para>
		/// <para>
		/// Note that calls to <c>NetUserSetInfo</c> can change the home directory only for user accounts that the network server creates.
		/// </para>
		/// <para>
		/// If the <c>NetUserSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the first
		/// member of the user information structure that is invalid. (A user information structure begins with USER_INFO_ and its format is
		/// specified by the level parameter.) The following table lists the values that can be returned in the parm_err parameter and the
		/// corresponding structure member that is in error. (The prefix usri*_ indicates that the member can begin with multiple prefixes,
		/// for example, usri10_ or usri1003_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>USER_NAME_PARMNUM</term>
		/// <term>usri*_name</term>
		/// </item>
		/// <item>
		/// <term>USER_PASSWORD_PARMNUM</term>
		/// <term>usri*_password</term>
		/// </item>
		/// <item>
		/// <term>USER_PASSWORD_AGE_PARMNUM</term>
		/// <term>usri*_password_age</term>
		/// </item>
		/// <item>
		/// <term>USER_PRIV_PARMNUM</term>
		/// <term>usri*_priv</term>
		/// </item>
		/// <item>
		/// <term>USER_HOME_DIR_PARMNUM</term>
		/// <term>usri*_home_dir</term>
		/// </item>
		/// <item>
		/// <term>USER_COMMENT_PARMNUM</term>
		/// <term>usri*_comment</term>
		/// </item>
		/// <item>
		/// <term>USER_FLAGS_PARMNUM</term>
		/// <term>usri*_flags</term>
		/// </item>
		/// <item>
		/// <term>USER_SCRIPT_PATH_PARMNUM</term>
		/// <term>usri*_script_path</term>
		/// </item>
		/// <item>
		/// <term>USER_AUTH_FLAGS_PARMNUM</term>
		/// <term>usri*_auth_flags</term>
		/// </item>
		/// <item>
		/// <term>USER_FULL_NAME_PARMNUM</term>
		/// <term>usri*_full_name</term>
		/// </item>
		/// <item>
		/// <term>USER_USR_COMMENT_PARMNUM</term>
		/// <term>usri*_usr_comment</term>
		/// </item>
		/// <item>
		/// <term>USER_PARMS_PARMNUM</term>
		/// <term>usri*_parms</term>
		/// </item>
		/// <item>
		/// <term>USER_WORKSTATIONS_PARMNUM</term>
		/// <term>usri*_workstations</term>
		/// </item>
		/// <item>
		/// <term>USER_LAST_LOGON_PARMNUM</term>
		/// <term>usri*_last_logon</term>
		/// </item>
		/// <item>
		/// <term>USER_LAST_LOGOFF_PARMNUM</term>
		/// <term>usri*_last_logoff</term>
		/// </item>
		/// <item>
		/// <term>USER_ACCT_EXPIRES_PARMNUM</term>
		/// <term>usri*_acct_expires</term>
		/// </item>
		/// <item>
		/// <term>USER_MAX_STORAGE_PARMNUM</term>
		/// <term>usri*_max_storage</term>
		/// </item>
		/// <item>
		/// <term>USER_UNITS_PER_WEEK_PARMNUM</term>
		/// <term>usri*_units_per_week</term>
		/// </item>
		/// <item>
		/// <term>USER_LOGON_HOURS_PARMNUM</term>
		/// <term>usri*_logon_hours</term>
		/// </item>
		/// <item>
		/// <term>USER_PAD_PW_COUNT_PARMNUM</term>
		/// <term>usri*_bad_pw_count</term>
		/// </item>
		/// <item>
		/// <term>USER_NUM_LOGONS_PARMNUM</term>
		/// <term>usri*_num_logons</term>
		/// </item>
		/// <item>
		/// <term>USER_LOGON_SERVER_PARMNUM</term>
		/// <term>usri*_logon_server</term>
		/// </item>
		/// <item>
		/// <term>USER_COUNTRY_CODE_PARMNUM</term>
		/// <term>usri*_country_code</term>
		/// </item>
		/// <item>
		/// <term>USER_CODE_PAGE_PARMNUM</term>
		/// <term>usri*_code_page</term>
		/// </item>
		/// <item>
		/// <term>USER_PRIMARY_GROUP_PARMNUM</term>
		/// <term>usri*_primary_group_id</term>
		/// </item>
		/// <item>
		/// <term>USER_PROFILE_PARMNUM</term>
		/// <term>usri*_profile</term>
		/// </item>
		/// <item>
		/// <term>USER_HOME_DIR_DRIVE_PARMNUM</term>
		/// <term>usri*_home_dir_drive</term>
		/// </item>
		/// </list>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// The <c>NetUserSetInfo</c> function does not control how the password parameters are secured when sent over the network to a
		/// remote server to change a user password. Any encryption of these parameters is handled by the Remote Procedure Call (RPC)
		/// mechanism supported by the network redirector that provides the network transport. Encryption is also controlled by the security
		/// mechanisms supported by the local computer and the security mechanisms supported by remote network server specified in the
		/// servername parameter. For more details on security when the Microsoft network redirector is used and the remote network server is
		/// running Microsoft Windows, see the protocol documentation for MS-RPCE and MS-SAMR.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to disable a user account with a call to the <c>NetUserSetInfo</c> function. The code
		/// sample fills in the <c>usri1008_flags</c> member of the USER_INFO_1008 structure, specifying the value UF_ACCOUNTDISABLE. Then
		/// the sample calls <c>NetUserSetInfo</c>, specifying information level 0.
		/// </para>
		/// </remarks>
		[PInvokeData("lmaccess.h", MSDNShortId = "ffe49d4b-e7e8-4982-8087-59bb7534b257")]
		public static void NetUserSetInfo<T>([Optional] string servername, string username, in T buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetUserSetInfo(servername, username, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>The <c>NetWkstaGetInfo</c> function returns information about the configuration of a workstation.</summary>
		/// <typeparam name="T">The type of structure to get.</typeparam>
		/// <param name="servername">
		/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>100</term>
		/// <term>
		/// Return information about the workstation environment, including platform-specific information, the name of the domain and the
		/// local computer, and information concerning the operating system. The bufptr parameter points to a WKSTA_INFO_100 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>101</term>
		/// <term>
		/// In addition to level 100 information, return the path to the LANMAN directory. The bufptr parameter points to a WKSTA_INFO_101 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>102</term>
		/// <term>
		/// In addition to level 101 information, return the number of users who are logged on to the local computer. The bufptr parameter
		/// points to a WKSTA_INFO_102 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> If you call this function on a domain controller that is running Active Directory,
		/// access is allowed or denied based on the ACL for the securable object. To enable anonymous access, the user Anonymous must be a
		/// member of the "Pre-Windows 2000 compatible access" group. This is because anonymous tokens do not include the Everyone group SID
		/// by default. If you call this function on a member server or workstation, all authenticated users can view the information.
		/// Anonymous access is also permitted if the EveryoneIncludesAnonymous policy setting allows anonymous access. Anonymous access is
		/// always permitted for level 100. If you call this function at level 101, authenticated users can view the information. Members of
		/// the Administrators, and the Server, System and Print Operator local groups can view information at levels 102 and 502. For more
		/// information about restricting anonymous access, see Security Requirements for the Network Management Functions. For more
		/// information on ACLs, ACEs, and access tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// <c>Windows 2000:</c> If you call this function on a domain controller that is running Active Directory, access is allowed or
		/// denied based on the access control list (ACL) for the securable object. The default ACL permits all authenticated users and
		/// members of the " Pre-Windows 2000 compatible access" group to view the information. By default, the "Pre-Windows 2000 compatible
		/// access" group includes Everyone as a member. This enables anonymous access to the information if the system allows anonymous
		/// access. If you call this function on a member server or workstation, all authenticated users can view the information. Anonymous
		/// access is also permitted if the RestrictAnonymous policy setting allows anonymous access.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0400 or later. For more information,see
		/// Using the Windows Headers.
		/// </para>
		/// </remarks>
		[PInvokeData("lmwksta.h", MSDNShortId = "08777069-1afd-4482-8090-c65ef0bec1ea")]
		public static T NetWkstaGetInfo<T>(string servername, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetWkstaGetInfo(servername, level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>
		/// The <c>NetWkstaSetInfo</c> function configures a workstation with information that remains in effect after the system has been reinitialized.
		/// </summary>
		/// <typeparam name="T">The type of the data to set.</typeparam>
		/// <param name="servername">
		/// A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="buffer">The data. The format of this data depends on the value of the level parameter.</param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>100</term>
		/// <term>
		/// Windows NT: Specifies information about a workstation environment, including platform-specific information, the names of the
		/// domain and the local computer, and information concerning the operating system. The buffer parameter points to a WKSTA_INFO_100
		/// structure. The wk100_computername and wk100_langroup fields of this structure cannot be set by calling this function. To set
		/// these values, call SetComputerName/SetComputerNameEx or NetJoinDomain, respectively.
		/// </term>
		/// </item>
		/// <item>
		/// <term>101</term>
		/// <term>
		/// Windows NT: In addition to level 100 information, specifies the path to the LANMAN directory. The buffer parameter points to a
		/// WKSTA_INFO_101 structure. The wk101_computername and wk101_langroup fields of this structure cannot be set by calling this
		/// function. To set these values, call SetComputerName/SetComputerNameEx or NetJoinDomain, respectively.
		/// </term>
		/// </item>
		/// <item>
		/// <term>102</term>
		/// <term>
		/// Windows NT: In addition to level 101 information, specifies the number of users who are logged on to the local computer. The
		/// buffer parameter points to a WKSTA_INFO_102 structure. The wk102_computername and wk102_langroup fields of this structure cannot
		/// be set by calling this function. To set these values, call SetComputerName/SetComputerNameEx or NetJoinDomain, respectively.
		/// </term>
		/// </item>
		/// <item>
		/// <term>502</term>
		/// <term>
		/// Windows NT: The buffer parameter points to a WKSTA_INFO_502 structure that contains information about the workstation environment.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Do not set levels 1010-1013, 1018, 1023, 1027, 1028, 1032, 1033, 1035, or 1041-1062.</para>
		/// </param>
		/// <remarks>
		/// <para>Only members of the Administrators group can successfully execute the <c>NetWkstaSetInfo</c> function on a remote server.</para>
		/// <para>
		/// The <c>NetWkstaSetInfo</c> function calls the workstation service on the local system or a remote system. Only a limited number
		/// of members of the WKSTA_INFO_502 structure can actually be changed using the <c>NetWkstaSetInfo</c> function. No errors are
		/// returned if a member is set that is ignored by the workstation service. The workstation service is primarily configured using
		/// settings in the registry.
		/// </para>
		/// <para>
		/// The NetWkstaUserSetInfo function can be used instead of the <c>NetWkstaSetInfo</c> function to set configuration information on
		/// the local system. The <c>NetWkstaUserSetInfo</c> function calls the Local Security Authority (LSA).
		/// </para>
		/// <para>
		/// If the <c>NetWkstaSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the first
		/// member of the workstation information structure that is invalid. (A workstation information structure begins with WKSTA_INFO_ and
		/// its format is specified by the level parameter.) The following table lists the values that can be returned in the parm_err
		/// parameter and the corresponding structure member that is in error. (The prefix wki*_ indicates that the member can begin with
		/// multiple prefixes, for example, wki100_ or wki402_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>WKSTA_PLATFORM_ID_PARMNUM</term>
		/// <term>wki*_platform_id</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_COMPUTERNAME_PARMNUM</term>
		/// <term>wki*_computername</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LANGROUP_PARMNUM</term>
		/// <term>wki*_langroup</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_VER_MAJOR_PARMNUM</term>
		/// <term>wki*_ver_major</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_VER_MINOR_PARMNUM</term>
		/// <term>wki*_ver_minor</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LOGGED_ON_USERS_PARMNUM</term>
		/// <term>wki*_logged_on_users</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LANROOT_PARMNUM</term>
		/// <term>wki*_lanroot</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LOGON_DOMAIN_PARMNUM</term>
		/// <term>wki*_logon_domain</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LOGON_SERVER_PARMNUM</term>
		/// <term>wki*_logon_server</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_CHARWAIT_PARMNUM</term>
		/// <term>wki*_char_wait</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_CHARTIME_PARMNUM</term>
		/// <term>wki*_collection_time</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_CHARCOUNT_PARMNUM</term>
		/// <term>wki*_maximum_collection_count</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_KEEPCONN_PARMNUM</term>
		/// <term>wki*_keep_conn</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_KEEPSEARCH_PARMNUM</term>
		/// <term>wki*_keep_search</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_MAXCMDS_PARMNUM</term>
		/// <term>wki*_max_cmds</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMWORKBUF_PARMNUM</term>
		/// <term>wki*_num_work_buf</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_MAXWRKCACHE_PARMNUM</term>
		/// <term>wki*_max_wrk_cache</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_SESSTIMEOUT_PARMNUM</term>
		/// <term>wki*_sess_timeout</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_SIZERROR_PARMNUM</term>
		/// <term>wki*_siz_error</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMALERTS_PARMNUM</term>
		/// <term>wki*_num_alerts</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMSERVICES_PARMNUM</term>
		/// <term>wki*_num_services</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_ERRLOGSZ_PARMNUM</term>
		/// <term>wki*_errlog_sz</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_PRINTBUFTIME_PARMNUM</term>
		/// <term>wki*_print_buf_time</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMCHARBUF_PARMNU</term>
		/// <term>wki*_num_char_buf</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_SIZCHARBUF_PARMNUM</term>
		/// <term>wki*_siz_char_buf</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_WRKHEURISTICS_PARMNUM</term>
		/// <term>wki*_wrk_heuristics</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_MAILSLOTS_PARMNUM</term>
		/// <term>wki*_mailslots</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_MAXTHREADS_PARMNUM</term>
		/// <term>wki*_max_threads</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_SIZWORKBUF_PARMNUM</term>
		/// <term>wki*_siz_work_buf</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMDGRAMBUF_PARMNUM</term>
		/// <term>wki*_num_dgram_buf</term>
		/// </item>
		/// </list>
		/// <para>
		/// The workstation service parameter settings are stored in the registry, not in the LanMan.ini file used prveiously by LAN Manager.
		/// The <c>NetWkstaSetInfo</c> function does not change the values in the LanMan.ini file. When the workstation service is stopped
		/// and restarted, workstation parameters are reset to the default values specified in the registry (unless they are overwritten by
		/// command-line parameters). Values set by previous calls to <c>NetWkstaSetInfo</c> can be overwritten when workstation parameters
		/// are reset.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to set the session time-out value associated with a workstation using a call to the
		/// <c>NetServerSetInfo</c> function. (The session time-out is the number of seconds the server waits before disconnecting an
		/// inactive session.) The code specifies information level 502 (WKSTA_INFO_502).
		/// </para>
		/// </remarks>
		[PInvokeData("lmwksta.h", MSDNShortId = "d746b6c9-5ef1-4174-a84f-44e4e50200cd")]
		public static void NetWkstaSetInfo<T>(string servername, in T buffer, uint level = uint.MaxValue) where T : struct
		{
			var mem = SafeHGlobalHandle.CreateFromStructure(buffer);
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var err = NetWkstaSetInfo(servername, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		/// <summary>
		/// The <c>NetWkstaUserEnum</c> function lists information about all users currently logged on to the workstation. This list includes
		/// interactive, service and batch logons.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="servername">
		/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the names of users currently logged on to the workstation. The bufptr parameter points to an array of WKSTA_USER_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return the names of the current users and the domains accessed by the workstation. The bufptr parameter points to an array of
		/// WKSTA_USER_INFO_1 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data enumeration. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// Note that since the <c>NetWkstaUserEnum</c> function lists entries for service and batch logons, as well as for interactive
		/// logons, the function can return entries for users who have logged off a workstation. This can occur, for example, when a user
		/// calls a service that impersonates the user. In this instance, <c>NetWkstaUserEnum</c> returns an entry for the user until the
		/// service stops impersonating the user.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> If you call this function on a domain controller that is running Active Directory,
		/// access is allowed or denied based on the ACL for the securable object. To enable anonymous access, the user Anonymous must be a
		/// member of the "Pre-Windows 2000 compatible access" group. This is because anonymous tokens do not include the Everyone group SID
		/// by default. If you call this function on a member server or workstation, all authenticated users can view the information.
		/// Anonymous access is also permitted if the RestrictAnonymous policy setting permits anonymous access. If the RestrictAnonymous
		/// policy setting does not permit anonymous access, only an administrator can successfully execute the function. Members of the
		/// Administrators, and the Server, System and Print Operator local groups can also view information. For more information about
		/// restricting anonymous access, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs,
		/// and access tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// <c>Windows 2000:</c> If you call this function on a domain controller that is running Active Directory, access is allowed or
		/// denied based on the access control list (ACL) for the securable object. The default ACL permits all authenticated users and
		/// members of the " Pre-Windows 2000 compatible access" group to view the information. By default, the "Pre-Windows 2000 compatible
		/// access" group includes Everyone as a member. This enables anonymous access to the information if the system allows anonymous
		/// access. If you call this function on a member server or workstation, all authenticated users can view the information. Anonymous
		/// access is also permitted if the RestrictAnonymous policy setting allows anonymous access.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0400 or later. For more information,see
		/// Using the Windows Headers.
		/// </para>
		/// </remarks>
		[PInvokeData("lmwksta.h", MSDNShortId = "42eaeb70-3ce8-4eae-b20b-4729db90a7ef")]
		public static IEnumerable<T> NetWkstaUserEnum<T>([Optional] string servername, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var h = 0U;
			NetWkstaUserEnum(servername, level, out var buf, MAX_PREFERRED_LENGTH, out var cnt, out var _, ref h).ThrowIfFailed();
			return buf.ToIEnum<T>((int)cnt);
		}

		/// <summary>
		/// The <c>NetWkstaUserGetInfo</c> function returns information about the currently logged-on user. This function must be called in
		/// the context of the logged-on user.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the name of the user currently logged on to the workstation. The bufptr parameter points to a WKSTA_USER_INFO_0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return information about the workstation, including the name of the current user and the domains accessed by the workstation. The
		/// bufptr parameter points to a WKSTA_USER_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1101</term>
		/// <term>Return domains browsed by the workstation. The bufptr parameter points to a WKSTA_USER_INFO_1101 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The data. The format of this data depends on the value of the bufptr parameter.</returns>
		/// <remarks>
		/// <para>The <c>NetWkstaUserGetInfo</c> function only works locally.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about the currently logged-on user using a call to the
		/// <c>NetWkstaUserGetInfo</c> function. The sample calls <c>NetWkstaUserGetInfo</c>, specifying information level 1 (
		/// WKSTA_USER_INFO_1). If the call succeeds, the sample prints information about the logged-on user. Finally, the sample frees the
		/// memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		[PInvokeData("lmwksta.h", MSDNShortId = "25ec7a49-fd26-4105-823b-a257a57f724e")]
		public static T NetWkstaUserGetInfo<T>(uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			NetWkstaUserGetInfo(null, level, out var buf).ThrowIfFailed();
			return buf.ToStructure<T>();
		}

		/// <summary>
		/// The <c>NetWkstaUserSetInfo</c> function sets the user-specific information about the configuration elements for a workstation.
		/// </summary>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies information about the workstation, including the name of the current user and the domains accessed by the workstation.
		/// The buf parameter points to a WKSTA_USER_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1101</term>
		/// <term>Specifies domains browsed by the workstation. The buf parameter points to a WKSTA_USER_INFO_1101 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The level parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the function parameters is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetWkstaUserSetInfo</c> function only works locally. Administrator group membership is required.</para>
		/// <para>
		/// Domain names in the <c>wkui1101_oth_domains</c> member of the WKSTA_USER_INFO_1101 structure are separated by spaces. An empty
		/// list is valid. A <c>NULL</c> pointer means to leave the member unmodified. The <c>wkui1101_oth_domains</c> member cannot be set
		/// with MS-DOS. When setting this element, <c>NetWkstaUserSetInfo</c> rejects the request if the name list was invalid or if a name
		/// could not be added to one or more of the network adapters managed by the system.
		/// </para>
		/// <para>
		/// If the <c>NetWkstaUserSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the
		/// member of the workstation user information structure that is invalid. (A workstation user information structure begins with
		/// WKSTA_USER_INFO_ and its format is specified by the level parameter.) The following table lists the value that can be returned in
		/// the parm_err parameter and the corresponding structure member that is in error. (The prefix wkui*_ indicates that the member can
		/// begin with multiple prefixes, for example, wkui0_ or wkui1_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>WKSTA_OTH_DOMAINS_PARMNUM</term>
		/// <term>wkui*_oth_domains</term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to set user-specific information for a workstation using a call to the
		/// <c>NetWkstaUserSetInfo</c> function, specifying information level 1101 ( WKSTA_USER_INFO_1101).
		/// </para>
		/// </remarks>
		[PInvokeData("lmwksta.h", MSDNShortId = "d48667a3-5ae9-4a7d-9af6-14f08835940d")]
		public static void NetWkstaUserSetInfo<T>(in T buf, uint level = uint.MaxValue) where T : struct
		{
			if (level == uint.MaxValue) level = (uint)GetLevelFromStructure<T>();
			var mem = SafeHGlobalHandle.CreateFromStructure(buf);
			var err = NetWkstaSetInfo(null, level, (IntPtr)mem, out var perr);
			if (err.Succeeded) return;
			if (err != Win32Error.ERROR_INVALID_PARAMETER) err.ThrowIfFailed();
			throw err.GetException($"Invalid parameter. Index: {perr}");
		}

		private static int GetLevelFromStructure<T>()
		{
			var m = System.Text.RegularExpressions.Regex.Match(typeof(T).Name, @"(\d+)$");
			var i = 0;
			if (m.Success)
				int.TryParse(m.Value, out i);
			return i;
		}
	}
}