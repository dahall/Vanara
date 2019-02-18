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
		/// If this flag is set and the DomainName parameter is not <see langword="null"/>, DomainName must specify a forest name. This flag cannot be
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
		/// <param name="ComputerName">
		/// A string that specifies the name of the server to process this function. Typically, this parameter is
		/// <see langword="null"/>, which indicates that the local computer is used.
		/// </param>
		/// <param name="DomainName">
		/// <para>
		/// A string that specifies the name of the domain or application partition to query. This name can either
		/// be a DNS style name, for example, fabrikam.com, or a flat-style name, for example, Fabrikam. If a DNS style name is specified,
		/// the name may be specified with or without a trailing period.
		/// </para>
		/// <para>
		/// If the Flags parameter contains the <c>DS_GC_SERVER_REQUIRED</c> flag, DomainName must be the name of the forest. In this case,
		/// <c>DsGetDcName</c> fails if DomainName specifies a name that is not the forest root.
		/// </para>
		/// <para>
		/// If the Flags parameter contains the <c>DS_GC_SERVER_REQUIRED</c> flag and DomainName is <see langword="null"/>, <c>DsGetDcName</c> attempts
		/// to find a global catalog in the forest of the computer identified by ComputerName, which is the local computer if ComputerName is <see langword="null"/>.
		/// </para>
		/// <para>
		/// If DomainName is <see langword="null"/> and the Flags parameter does not contain the <c>DS_GC_SERVER_REQUIRED</c> flag, ComputerName is set
		/// to the default domain name of the primary domain of the computer identified by ComputerName.
		/// </para>
		/// </param>
		/// <param name="DomainGuid">
		/// An optional Guid value that specifies the <c>GUID</c> of the domain queried. If DomainGuid is not <see langword="null"/> and the domain
		/// specified by DomainName or ComputerName cannot be found, <c>DsGetDcName</c> attempts to locate a domain controller in the domain
		/// having the GUID specified by DomainGuid.
		/// </param>
		/// <param name="SiteName">
		/// A string that specifies the name of the site where the returned domain controller should physically
		/// exist. If this parameter is <see langword="null"/>, <c>DsGetDcName</c> attempts to return a domain controller in the site closest to the
		/// site of the computer specified by ComputerName. This parameter should be <see langword="null"/>, by default.
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

		/// <summary>The <c>DsGetDcOpen</c> function opens a new domain controller enumeration operation.</summary>
		/// <param name="DnsName">
		/// A string that contains the domain naming system (DNS) name of the domain to enumerate the domain
		/// controllers for. This parameter cannot be <see langword="null"/>.
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
		/// A string that contains the name of site the client is in. This parameter is optional and may be <see langword="null"/>.
		/// </param>
		/// <param name="DomainGuid">
		/// An optional <c>GUID</c> value that contains the identifier of the domain specified by DnsName. This identifier is used to handle
		/// the case of a renamed domain. If this value is specified and the domain specified in DnsName is renamed, this function attempts
		/// to enumerate domain controllers in the domain that contains the specified identifier. This parameter is optional and may be <see langword="null"/>.
		/// </param>
		/// <param name="DnsForestName">
		/// A string that contains the name of the forest that contains the DnsName domain. This value is used in
		/// conjunction with DomainGuidto enumerate the domain controllers if the domain has been renamed. This parameter is optional and may
		/// be <see langword="null"/>.
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsgetdc/nf-dsgetdc-dsgetdcopena
		// DSGETDCAPI DWORD DsGetDcOpenA( IN LPCSTR DnsName, IN ULONG OptionFlags, IN LPCSTR SiteName, IN GUID *DomainGuid, IN LPCSTR DnsForestName, IN ULONG DcFlags, OUT PHANDLE RetGetDcContext );
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
		/// the TrustedDomainNameparameter. In this case, the TrustedDomainName parameter cannot be <see langword="null"/>. The caller must have access
		/// to modify the trust data or <c>ERROR_ACCESS_DENIED</c> is returned.
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
		/// The <c>DsMergeForestTrustInformationW</c> function merges the changes from a new forest trust data structure with an old forest trust data structure.
		/// </summary>
		/// <param name="DomainName">A string that specifies the trusted domain to update.</param>
		/// <param name="NewForestTrustInfo">A <c>LsaForestTrustInformation</c> instance that contains the new forest trust data to be merged. The <c>Flags</c> and <c>Time</c> members of the entries are ignored.</param>
		/// <param name="OldForestTrustInfo">A <c>LsaForestTrustInformation</c> instance that contains the old forest trust data to be merged. This parameter may be <see langword="null"/> if no records exist.</param>
		/// <param name="MergedForestTrustInfo">A <c>LsaForestTrustInformation</c> instance with the merged forest trust data.</param>
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
		/// Pointer to null-terminated Unicode string that contains the name of the computer on which to call the function. If this parameter
		/// is <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="InfoLevel">
		/// Contains one of the DSROLE_PRIMARY_DOMAIN_INFO_LEVEL values that specify the type of data to retrieve. This parameter also
		/// determines the format of the data supplied in Buffer.
		/// </param>
		/// <param name="Buffer">
		/// <para>
		/// Pointer to the address of a buffer that receives the requested data. The format of this data depends on the value of the
		/// InfoLevel parameter.
		/// </para>
		/// <para>The caller must free this memory when it is no longer required by calling DsRoleFreeMemory.</para>
		/// </param>
		/// <returns>
		/// <para>If the function is successful, the return value is <c>ERROR_SUCCESS</c>.</para>
		/// <para>If the function fails, the return value can be one of the following values.</para>
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
		/// The <c>NetServerDiskEnum</c> function retrieves a list of disk drives on a server. The function returns an array of
		/// three-character strings (a drive letter, a colon, and a terminating null character).
		/// </summary>
		/// <param name="servername">A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <see langword="null"/>, the local computer is used.</param>
		/// <param name="bufptr">An array of strings (a drive letter followed by a colon).</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>ERROR_ACCESS_DENIED</term>
		///     <term>The user does not have access to the requested information.</term>
		///   </item>
		///   <item>
		///     <term>ERROR_INVALID_LEVEL</term>
		///     <term>The value specified for the level parameter is invalid.</term>
		///   </item>
		///   <item>
		///     <term>ERROR_MORE_DATA</term>
		///     <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		///   </item>
		///   <item>
		///     <term>ERROR_NOT_ENOUGH_MEMORY</term>
		///     <term>Insufficient memory is available.</term>
		///   </item>
		///   <item>
		///     <term>ERROR_NOT_SUPPORTED</term>
		///     <term>
		/// The request is not supported. This error is returned if a remote server was specified in servername parameter, the remote server
		/// only supports remote RPC calls using the legacy Remote Access Protocol mechanism, and this request is not supported.
		/// </term>
		///   </item>
		/// </list>
		/// </returns>
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
		/// <param name="servername">A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <see langword="null"/>, the local computer is used.</param>
		/// <param name="level"><para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>0</term>
		///     <term>
		/// Return information about the transport protocol, including name, address, and location on the network. The bufptr parameter
		/// points to an array of SERVER_TRANSPORT_INFO_0 structures.
		/// </term>
		///   </item>
		///   <item>
		///     <term>1</term>
		///     <term>
		/// Return information about the transport protocol, including name, address, network location, and domain. The bufptr parameter
		/// points to an array of SERVER_TRANSPORT_INFO_1 structures.
		/// </term>
		///   </item>
		/// </list></param>
		/// <param name="bufptr">Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer is
		/// allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer even if the
		/// function fails with ERROR_MORE_DATA.</param>
		/// <param name="prefmaxlen">Specifies the preferred maximum length of returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function allocates
		/// the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number of bytes
		/// that the function returns. If the buffer size is insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more
		/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.</param>
		/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">Pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
		/// Note that applications should consider this value only as a hint.</param>
		/// <param name="resume_handle">The resume handle.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>ERROR_INVALID_LEVEL</term>
		///     <term>The value specified for the level parameter is invalid.</term>
		///   </item>
		///   <item>
		///     <term>ERROR_MORE_DATA</term>
		///     <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		///   </item>
		///   <item>
		///     <term>ERROR_NOT_ENOUGH_MEMORY</term>
		///     <term>Insufficient memory is available.</term>
		///   </item>
		///   <item>
		///     <term>NERR_BufTooSmall</term>
		///     <term>The supplied buffer is too small.</term>
		///   </item>
		/// </list>
		/// </returns>
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

		/// <summary>
		/// The <c>NetGetJoinableOUs</c> function retrieves a list of organizational units (OUs) in which a computer account can be created.
		/// </summary>
		/// <param name="lpDomain">A string that specifies the name of the domain for which to retrieve the list of OUs that can be joined.</param>
		/// <param name="lpServer">A string that specifies the DNS or NetBIOS name of the computer on which to call the function. If this
		/// parameter is <see langword="null"/>, the local computer is used.</param>
		/// <param name="lpAccount">A string that specifies the account name to use when connecting to the domain controller. The string must
		/// specify either a domain NetBIOS name and user account (for example, "REDMOND\user") or the user principal name (UPN) of the user
		/// in the form of an Internet-style login name (for example, "someone@example.com"). If this parameter is <see langword="null"/>, the caller's
		/// context is used.</param>
		/// <param name="lpPassword">If the lpAccount parameter specifies an account name, this parameter must point to the password to use when connecting to the
		/// domain controller. Otherwise, this parameter must be <see langword="null"/>.</param>
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
		/// Lists all connections made to a shared resource on the server or all connections established from a particular computer. If there
		/// is more than one user using this connection, then it is possible to get more than one structure for the same connection, but with
		/// a different user name.
		/// </summary>
		/// <param name="servername"><para>
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <see langword="null"/>, the local computer is used.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para></param>
		/// <param name="qualifier"><para>
		/// A string that specifies a share name or computer name for the connections of interest. If it is a share name, then all
		/// the connections made to that share name are listed. If it is a computer name (for example, it starts with two backslash
		/// characters), then <c>NetConnectionEnum</c> lists all connections made from that computer to the server specified.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para></param>
		/// <param name="level"><para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>0</term>
		///     <term>Return connection identifiers. The bufptr parameter is a pointer to an array of CONNECTION_INFO_0 structures.</term>
		///   </item>
		///   <item>
		///     <term>1</term>
		///     <term>
		/// Return connection identifiers and connection information. The bufptr parameter is a pointer to an array of CONNECTION_INFO_1 structures.
		/// </term>
		///   </item>
		/// </list></param>
		/// <param name="bufptr"><para>
		/// Pointer to the address of the buffer that receives the information. The format of this data depends on the value of the level parameter.
		/// </para>
		/// <para>
		/// This buffer is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer
		/// even if the function fails with <c>ERROR_MORE_DATA</c>.
		/// </para></param>
		/// <param name="prefmaxlen">Specifies the preferred maximum length of returned data, in bytes. If you specify <c>MAX_PREFERRED_LENGTH</c>, the function
		/// allocates the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number
		/// of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
		/// <c>ERROR_MORE_DATA</c>. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.</param>
		/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">Pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
		/// Note that applications should consider this value only as a hint.</param>
		/// <param name="resume_handle">Pointer to a value that contains a resume handle which is used to continue an existing connection search. The handle should be
		/// zero on the first call and left unchanged for subsequent calls. If this parameter is <see langword="null"/>, then no resume handle is stored.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
		/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
		/// </returns>
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

		/// <summary>Returns information about some or all open files on a server, depending on the parameters specified.</summary>
		/// <typeparam name="T">The expected return type of the enumerated element.</typeparam>
		/// <param name="servername"><para>
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <see langword="null"/>, the local computer is used.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para></param>
		/// <param name="basepath"><para>
		/// A string that specifies a qualifier for the returned information. If this parameter is <see langword="null"/>, all open resources
		/// are enumerated. If this parameter is not <see langword="null"/>, the function enumerates only resources that have the value of the basepath
		/// parameter as a prefix. (A prefix is the portion of a path that comes before a backslash.)
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para></param>
		/// <param name="username"><para>
		/// A string that specifies the name of the user or the name of the connection. If the string begins with two backslashes
		/// ("\"), then it indicates the name of the connection, for example, "\127.0.0.1" or "\ClientName". The part of the connection name
		/// after the backslashes is the same as the client name in the session information structure returned by the NetSessionEnum
		/// function. If the string does not begin with two backslashes, then it indicates the name of the user. If this parameter is not
		/// <see langword="null"/>, its value serves as a qualifier for the enumeration. The files returned are limited to those that have user names or
		/// connection names that match the qualifier. If this parameter is <see langword="null"/>, no user-name qualifier is used.
		/// </para>
		/// <para>
		///   <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This parameter is a pointer to a string that
		/// specifies the name of the user. If this parameter is not <see langword="null"/>, its value serves as a qualifier for the enumeration. The
		/// files returned are limited to those that have user names matching the qualifier. If this parameter is <see langword="null"/>, no user-name
		/// qualifier is used.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para></param>
		/// <param name="level"><para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>2</term>
		///     <term>Return the file identification number. The return value is an array of FILE_INFO_2 structures.</term>
		///   </item>
		///   <item>
		///     <term>3</term>
		///     <term>Return information about the file. The return value is an array of FILE_INFO_3 structures.</term>
		///   </item>
		/// </list></param>
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
		/// <param name="servername">A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <see langword="null" />, the local computer is used.</param>
		/// <param name="fileid">Specifies the file identifier of the open resource for which to return information. The value of this parameter must have been
		/// returned in a previous enumeration call. For more information, see the following Remarks section.</param>
		/// <param name="level"><para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>2</term>
		///     <term>Return the file identification number. The bufptr parameter is a pointer to a FILE_INFO_2 structure.</term>
		///   </item>
		///   <item>
		///     <term>3</term>
		///     <term>
		/// Return the file identification number and other information about the file. The bufptr parameter is a pointer to a FILE_INFO_3 structure.
		/// </term>
		///   </item>
		/// </list></param>
		/// <returns>The format of this structure depends on the value of the <paramref name="level" /> parameter.</returns>
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
		/// Specifies the information level of the data. This parameter can be <see cref="UInt32.MaxValue"/> one of the following values. If
		/// omitted or <see cref="UInt32.MaxValue"/>, this value will be extracted from the last digits of the name of <typeparamref name="T"/>.
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
		/// <param name="servername">A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <see langword="null" />, the local computer is used.</param>
		/// <param name="UncClientName">A string that specifies the name of the computer session for which information is to be returned. This parameter is
		/// required and cannot be <see langword="null" />. For more information, see NetSessionEnum.</param>
		/// <param name="username">A string that specifies the name of the user whose session information is to be returned. This parameter is required
		/// and cannot be <see langword="null" />.</param>
		/// <param name="level"><para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>0</term>
		///     <term>Return the name of the computer that established the session. The return value is a SESSION_INFO_0 structure.</term>
		///   </item>
		///   <item>
		///     <term>1</term>
		///     <term>
		/// Return the name of the computer, name of the user, and open files, pipes, and devices on the computer. The return value is a SESSION_INFO_1 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>2</term>
		///     <term>
		/// In addition to the information indicated for level 1, return the type of client and how the user established the session. The return value is a SESSION_INFO_2 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>10</term>
		///     <term>
		/// Return the name of the computer; name of the user; and active and idle times for the session. The return value is a
		/// SESSION_INFO_10 structure.
		/// </term>
		///   </item>
		/// </list></param>
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
		/// <param name="servername">A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <see langword="null" />, the local computer is used.</param>
		/// <param name="buf">Value that specifies the data. The format of this data depends on the value of the level parameter.</param>
		/// <param name="level"><para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>2</term>
		///     <term>
		/// Specifies information about the shared resource, including the name of the resource, type and permissions, and number of
		/// connections. The buf parameter points to a SHARE_INFO_2 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>502</term>
		///     <term>
		/// Specifies information about the shared resource, including the name of the resource, type and permissions, number of connections,
		/// and other pertinent information. The buf parameter points to a SHARE_INFO_502 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>503</term>
		///     <term>
		/// Specifies information about the shared resource, including the name of the resource, type and permissions, number of connections,
		/// and other pertinent information. The buf parameter points to a SHARE_INFO_503 structure.
		/// </term>
		///   </item>
		/// </list></param>
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
		/// <param name="servername"><para>
		/// The UNC name of the computer on which to execute this function. If this parameter is <c>NULL</c>, then the local computer is
		/// used. If the UncServerName parameter specified is a remote computer, then the remote computer must support remote RPC calls using
		/// the legacy Remote Access Protocol mechanism.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para></param>
		/// <param name="buf">The data. The format of this data depends on the value of the Level parameter.</param>
		/// <param name="LevelFlags"><para>A value that specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>1</term>
		///     <term>
		/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
		/// status and type. The Buf parameter is a pointer to a USE_INFO_1 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>2</term>
		///     <term>
		/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
		/// status and type, and a user name and domain name. The Buf parameter is a pointer to a USE_INFO_2 structure.
		/// </term>
		///   </item>
		/// </list></param>
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
		///   <listheader>
		///     <term>Constant</term>
		///     <term>Value</term>
		///     <term>Member</term>
		///   </listheader>
		///   <item>
		///     <term>USE_LOCAL_PARMNUM</term>
		///     <term>1</term>
		///     <term>ui*_local</term>
		///   </item>
		///   <item>
		///     <term>USE_REMOTE_PARMNUM</term>
		///     <term>2</term>
		///     <term>ui*_remote</term>
		///   </item>
		///   <item>
		///     <term>USE_PASSWORD_PARMNUM</term>
		///     <term>3</term>
		///     <term>ui*_password</term>
		///   </item>
		///   <item>
		///     <term>USE_ASGTYPE_PARMNUM</term>
		///     <term>4</term>
		///     <term>ui*_asg_type</term>
		///   </item>
		///   <item>
		///     <term>USE_USERNAME_PARMNUM</term>
		///     <term>5</term>
		///     <term>ui*_username</term>
		///   </item>
		///   <item>
		///     <term>USE_DOMAINNAME_PARMNUM</term>
		///     <term>6</term>
		///     <term>ui*_domainname</term>
		///   </item>
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
		/// <typeparam name="T">The expected element return type associated with the <paramref name="level" />.</typeparam>
		/// <param name="UncServerName"><para>
		/// The UNC name of the computer on which to execute this function. If this is parameter is <c>NULL</c>, then the local computer is
		/// used. If the UncServerName parameter specified is a remote computer, then the remote computer must support remote RPC calls using
		/// the legacy Remote Access Protocol mechanism.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para></param>
		/// <param name="LevelFlags"><para>The information level of the data requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>0</term>
		///     <term>
		/// Specifies a local device name and the share name of a remote resource. The BufPtr parameter points to an array of USE_INFO_0 structures.
		/// </term>
		///   </item>
		///   <item>
		///     <term>1</term>
		///     <term>
		/// Specifies information about the connection between a local device and a shared resource, including connection status and type.
		/// The BufPtr parameter points to an array of USE_INFO_1 structures.
		/// </term>
		///   </item>
		///   <item>
		///     <term>2</term>
		///     <term>
		/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
		/// status, connection type, user name, and domain name. The BufPtr parameter points to an array of USE_INFO_2 structures.
		/// </term>
		///   </item>
		/// </list></param>
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
		/// <param name="bufptr">
		/// A pointer to the buffer that receives the data. The format of this data depends on the value of the Level parameter. This buffer
		/// is allocated by the system and must be freed using the NetApiBufferFree function. For more information, see Network Management
		/// Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
		/// </returns>
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

		/// <summary>The <c>NetWkstaGetInfo</c> function returns information about the configuration of a workstation.</summary>
		/// <typeparam name="T">The type of structure to get.</typeparam>
		/// <param name="servername">Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.</param>
		/// <param name="level"><para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>100</term>
		///     <term>
		/// Return information about the workstation environment, including platform-specific information, the name of the domain and the
		/// local computer, and information concerning the operating system. The bufptr parameter points to a WKSTA_INFO_100 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>101</term>
		///     <term>
		/// In addition to level 100 information, return the path to the LANMAN directory. The bufptr parameter points to a WKSTA_INFO_101 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>102</term>
		///     <term>
		/// In addition to level 101 information, return the number of users who are logged on to the local computer. The bufptr parameter
		/// points to a WKSTA_INFO_102 structure.
		/// </term>
		///   </item>
		/// </list></param>
		/// <returns>The data. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		///   <c>Windows Server 2003 and Windows XP:</c> If you call this function on a domain controller that is running Active Directory,
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
		///   <c>Windows 2000:</c> If you call this function on a domain controller that is running Active Directory, access is allowed or
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
		/// <param name="servername">A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.</param>
		/// <param name="buffer">The data. The format of this data depends on the value of the level parameter.</param>
		/// <param name="level"><para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>100</term>
		///     <term>
		/// Windows NT: Specifies information about a workstation environment, including platform-specific information, the names of the
		/// domain and the local computer, and information concerning the operating system. The buffer parameter points to a WKSTA_INFO_100
		/// structure. The wk100_computername and wk100_langroup fields of this structure cannot be set by calling this function. To set
		/// these values, call SetComputerName/SetComputerNameEx or NetJoinDomain, respectively.
		/// </term>
		///   </item>
		///   <item>
		///     <term>101</term>
		///     <term>
		/// Windows NT: In addition to level 100 information, specifies the path to the LANMAN directory. The buffer parameter points to a
		/// WKSTA_INFO_101 structure. The wk101_computername and wk101_langroup fields of this structure cannot be set by calling this
		/// function. To set these values, call SetComputerName/SetComputerNameEx or NetJoinDomain, respectively.
		/// </term>
		///   </item>
		///   <item>
		///     <term>102</term>
		///     <term>
		/// Windows NT: In addition to level 101 information, specifies the number of users who are logged on to the local computer. The
		/// buffer parameter points to a WKSTA_INFO_102 structure. The wk102_computername and wk102_langroup fields of this structure cannot
		/// be set by calling this function. To set these values, call SetComputerName/SetComputerNameEx or NetJoinDomain, respectively.
		/// </term>
		///   </item>
		///   <item>
		///     <term>502</term>
		///     <term>
		/// Windows NT: The buffer parameter points to a WKSTA_INFO_502 structure that contains information about the workstation environment.
		/// </term>
		///   </item>
		/// </list>
		/// <para>Do not set levels 1010-1013, 1018, 1023, 1027, 1028, 1032, 1033, 1035, or 1041-1062.</para></param>
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
		///   <listheader>
		///     <term>Value</term>
		///     <term>Member</term>
		///   </listheader>
		///   <item>
		///     <term>WKSTA_PLATFORM_ID_PARMNUM</term>
		///     <term>wki*_platform_id</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_COMPUTERNAME_PARMNUM</term>
		///     <term>wki*_computername</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_LANGROUP_PARMNUM</term>
		///     <term>wki*_langroup</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_VER_MAJOR_PARMNUM</term>
		///     <term>wki*_ver_major</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_VER_MINOR_PARMNUM</term>
		///     <term>wki*_ver_minor</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_LOGGED_ON_USERS_PARMNUM</term>
		///     <term>wki*_logged_on_users</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_LANROOT_PARMNUM</term>
		///     <term>wki*_lanroot</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_LOGON_DOMAIN_PARMNUM</term>
		///     <term>wki*_logon_domain</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_LOGON_SERVER_PARMNUM</term>
		///     <term>wki*_logon_server</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_CHARWAIT_PARMNUM</term>
		///     <term>wki*_char_wait</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_CHARTIME_PARMNUM</term>
		///     <term>wki*_collection_time</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_CHARCOUNT_PARMNUM</term>
		///     <term>wki*_maximum_collection_count</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_KEEPCONN_PARMNUM</term>
		///     <term>wki*_keep_conn</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_KEEPSEARCH_PARMNUM</term>
		///     <term>wki*_keep_search</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_MAXCMDS_PARMNUM</term>
		///     <term>wki*_max_cmds</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_NUMWORKBUF_PARMNUM</term>
		///     <term>wki*_num_work_buf</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_MAXWRKCACHE_PARMNUM</term>
		///     <term>wki*_max_wrk_cache</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_SESSTIMEOUT_PARMNUM</term>
		///     <term>wki*_sess_timeout</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_SIZERROR_PARMNUM</term>
		///     <term>wki*_siz_error</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_NUMALERTS_PARMNUM</term>
		///     <term>wki*_num_alerts</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_NUMSERVICES_PARMNUM</term>
		///     <term>wki*_num_services</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_ERRLOGSZ_PARMNUM</term>
		///     <term>wki*_errlog_sz</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_PRINTBUFTIME_PARMNUM</term>
		///     <term>wki*_print_buf_time</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_NUMCHARBUF_PARMNU</term>
		///     <term>wki*_num_char_buf</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_SIZCHARBUF_PARMNUM</term>
		///     <term>wki*_siz_char_buf</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_WRKHEURISTICS_PARMNUM</term>
		///     <term>wki*_wrk_heuristics</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_MAILSLOTS_PARMNUM</term>
		///     <term>wki*_mailslots</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_MAXTHREADS_PARMNUM</term>
		///     <term>wki*_max_threads</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_SIZWORKBUF_PARMNUM</term>
		///     <term>wki*_siz_work_buf</term>
		///   </item>
		///   <item>
		///     <term>WKSTA_NUMDGRAMBUF_PARMNUM</term>
		///     <term>wki*_num_dgram_buf</term>
		///   </item>
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
		/// <param name="servername">Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.</param>
		/// <param name="level"><para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>0</term>
		///     <term>
		/// Return the names of users currently logged on to the workstation. The bufptr parameter points to an array of WKSTA_USER_INFO_0 structures.
		/// </term>
		///   </item>
		///   <item>
		///     <term>1</term>
		///     <term>
		/// Return the names of the current users and the domains accessed by the workstation. The bufptr parameter points to an array of
		/// WKSTA_USER_INFO_1 structures.
		/// </term>
		///   </item>
		/// </list></param>
		/// <returns>The data enumeration. The format of this data depends on the value of the level parameter.</returns>
		/// <remarks>
		/// <para>
		/// Note that since the <c>NetWkstaUserEnum</c> function lists entries for service and batch logons, as well as for interactive
		/// logons, the function can return entries for users who have logged off a workstation. This can occur, for example, when a user
		/// calls a service that impersonates the user. In this instance, <c>NetWkstaUserEnum</c> returns an entry for the user until the
		/// service stops impersonating the user.
		/// </para>
		/// <para>
		///   <c>Windows Server 2003 and Windows XP:</c> If you call this function on a domain controller that is running Active Directory,
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
		///   <c>Windows 2000:</c> If you call this function on a domain controller that is running Active Directory, access is allowed or
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
		/// <param name="level"><para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>0</term>
		///     <term>
		/// Return the name of the user currently logged on to the workstation. The bufptr parameter points to a WKSTA_USER_INFO_0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>1</term>
		///     <term>
		/// Return information about the workstation, including the name of the current user and the domains accessed by the workstation. The
		/// bufptr parameter points to a WKSTA_USER_INFO_1 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>1101</term>
		///     <term>Return domains browsed by the workstation. The bufptr parameter points to a WKSTA_USER_INFO_1101 structure.</term>
		///   </item>
		/// </list></param>
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
		/// <param name="reserved">This parameter must be set to zero.</param>
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
		/// <param name="parm_err">
		/// Pointer to a value that receives the index of the first parameter that causes the ERROR_INVALID_PARAMETER error. If this
		/// parameter is <c>NULL</c>, the index is not returned on error.
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