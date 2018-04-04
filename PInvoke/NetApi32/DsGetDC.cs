using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class NetApi32
	{
		/// <summary>
		/// The DsGetDcName function returns the name of a domain controller in a specified domain. This function accepts additional domain controller selection
		/// criteria to indicate preference for a domain controller with particular characteristics.
		/// </summary>
		/// <param name="ComputerName">
		/// Pointer to a null-terminated string that specifies the name of the server to process this function. Typically, this parameter is NULL, which
		/// indicates that the local computer is used.
		/// </param>
		/// <param name="DomainName">
		/// Pointer to a null-terminated string that specifies the name of the domain or application partition to query. This name can either be a DNS style
		/// name, for example, fabrikam.com, or a flat-style name, for example, Fabrikam. If a DNS style name is specified, the name may be specified with or
		/// without a trailing period.
		/// <para>
		/// If the Flags parameter contains the DS_GC_SERVER_REQUIRED flag, DomainName must be the name of the forest. In this case, DsGetDcName fails if
		/// DomainName specifies a name that is not the forest root.
		/// </para>
		/// <para>
		/// If the Flags parameter contains the DS_GC_SERVER_REQUIRED flag and DomainName is NULL, DsGetDcName attempts to find a global catalog in the forest of
		/// the computer identified by ComputerName, which is the local computer if ComputerName is NULL.
		/// </para>
		/// <para>
		/// If DomainName is NULL and the Flags parameter does not contain the DS_GC_SERVER_REQUIRED flag, ComputerName is set to the default domain name of the
		/// primary domain of the computer identified by ComputerName.
		/// </para>
		/// </param>
		/// <param name="DomainGuid">
		/// Pointer to a GUID structure that specifies the GUID of the domain queried. If DomainGuid is not NULL and the domain specified by DomainName or
		/// ComputerName cannot be found, DsGetDcName attempts to locate a domain controller in the domain having the GUID specified by DomainGuid.
		/// </param>
		/// <param name="SiteName">
		/// Pointer to a null-terminated string that specifies the name of the site where the returned domain controller should physically exist. If this
		/// parameter is NULL, DsGetDcName attempts to return a domain controller in the site closest to the site of the computer specified by ComputerName. This
		/// parameter should be NULL, by default.
		/// </param>
		/// <param name="Flags">
		/// Contains a set of flags that provide additional data used to process the request. This parameter can be a combination of the following values.
		/// </param>
		/// <param name="DomainControllerInfo">
		/// Pointer to a PDOMAIN_CONTROLLER_INFO value that receives a pointer to a DOMAIN_CONTROLLER_INFO structure that contains data about the domain
		/// controller selected. This structure is allocated by DsGetDcName. The caller must free the structure using the NetApiBufferFree function when it is no
		/// longer required.
		/// </param>
		/// <returns>
		/// If the function returns domain controller data, the return value is ERROR_SUCCESS.
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// </returns>
		[DllImport(Lib.NetApi32, CharSet = CharSet.Auto)]
		[PInvokeData("DsGetDC.h", MSDNShortId = "ms675983")]
		public static extern Win32Error DsGetDcName(string ComputerName, string DomainName, IntPtr DomainGuid,
			string SiteName, DsGetDcNameFlags Flags, out SafeNetApiBuffer DomainControllerInfo);

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

		/// <summary>Flags supporting behavior of <see cref="DsGetDcName"/>.</summary>
		[Flags]
		[PInvokeData("DsGetDC.h", MSDNShortId = "ms675983")]
		public enum DsGetDcNameFlags : uint
		{
			/// <summary>
			/// Forces cached domain controller data to be ignored. When the DS_FORCE_REDISCOVERY flag is not specified, DsGetDcName may return cached domain
			/// controller data. If this flag is specified, DsGetDcName will not use cached information (if any exists) but will instead perform a fresh domain
			/// controller discovery.
			/// <para>
			/// This flag should not be used under normal conditions, as using the cached domain controller information has better performance characteristics
			/// and helps to ensure that the same domain controller is used consistently by all applications. This flag should be used only after the application
			/// determines that the domain controller returned by DsGetDcName (when called without this flag) is not accessible. In that case, the application
			/// should repeat the DsGetDcName call with this flag to ensure that the unuseful cached information (if any) is ignored and a reachable domain
			/// controller is discovered.
			/// </para>
			/// </summary>
			DS_FORCE_REDISCOVERY = 0x1,

			/// <summary>Requires that the returned domain controller support directory services.</summary>
			DS_DIRECTORY_SERVICE_REQUIRED = 0x10,

			/// <summary>
			/// DsGetDcName attempts to find a domain controller that supports directory service functions. If a domain controller that supports directory
			/// services is not available, DsGetDcName returns the name of a non-directory service domain controller. However, DsGetDcName only returns a
			/// non-directory service domain controller after the attempt to find a directory service domain controller times out.
			/// </summary>
			DS_DIRECTORY_SERVICE_PREFERRED = 0x20,

			/// <summary>
			/// Requires that the returned domain controller be a global catalog server for the forest of domains with this domain as the root. If this flag is
			/// set and the DomainName parameter is not NULL, DomainName must specify a forest name. This flag cannot be combined with the DS_PDC_REQUIRED or
			/// DS_KDC_REQUIRED flags.
			/// </summary>
			DS_GC_SERVER_REQUIRED = 0x40,

			/// <summary>
			/// Requires that the returned domain controller be the primary domain controller for the domain. This flag cannot be combined with the
			/// DS_KDC_REQUIRED or DS_GC_SERVER_REQUIRED flags.
			/// </summary>
			DS_PDC_REQUIRED = 0x80,

			/// <summary>
			/// If the DS_FORCE_REDISCOVERY flag is not specified, this function uses cached domain controller data. If the cached data is more than 15 minutes
			/// old, the cache is refreshed by pinging the domain controller. If this flag is specified, this refresh is avoided even if the cached data is
			/// expired. This flag should be used if the DsGetDcName function is called periodically.
			/// </summary>
			DS_BACKGROUND_ONLY = 0x100,

			/// <summary>
			/// This parameter indicates that the domain controller must have an IP address. In that case, DsGetDcName will place the Internet protocol address
			/// of the domain controller in the DomainControllerAddress member of DomainControllerInfo.
			/// </summary>
			DS_IP_REQUIRED = 0x200,

			/// <summary>
			/// Requires that the returned domain controller be currently running the Kerberos Key Distribution Center service. This flag cannot be combined with
			/// the DS_PDC_REQUIRED or DS_GC_SERVER_REQUIRED flags.
			/// </summary>
			DS_KDC_REQUIRED = 0x400,

			/// <summary>Requires that the returned domain controller be currently running the Windows Time Service.</summary>
			DS_TIMESERV_REQUIRED = 0x800,

			/// <summary>Requires that the returned domain controller be writable; that is, host a writable copy of the directory service.</summary>
			DS_WRITABLE_REQUIRED = 0x1000,

			/// <summary>
			/// DsGetDcName attempts to find a domain controller that is a reliable time server. The Windows Time Service can be configured to declare one or
			/// more domain controllers as a reliable time server. For more information, see the Windows Time Service documentation. This flag is intended to be
			/// used only by the Windows Time Service.
			/// </summary>
			DS_GOOD_TIMESERV_PREFERRED = 0x2000,

			/// <summary>
			/// When called from a domain controller, specifies that the returned domain controller name should not be the current computer. If the current
			/// computer is not a domain controller, this flag is ignored. This flag can be used to obtain the name of another domain controller in the domain.
			/// </summary>
			DS_AVOID_SELF = 0x4000,

			/// <summary>
			/// Specifies that the server returned is an LDAP server. The server returned is not necessarily a domain controller. No other services are implied
			/// to be present at the server. The server returned does not necessarily have a writable config container nor a writable schema container. The
			/// server returned may not necessarily be used to create or modify security principles. This flag may be used with the DS_GC_SERVER_REQUIRED flag to
			/// return an LDAP server that also hosts a global catalog server. The returned global catalog server is not necessarily a domain controller. No
			/// other services are implied to be present at the server. If this flag is specified, the DS_PDC_REQUIRED, DS_TIMESERV_REQUIRED,
			/// DS_GOOD_TIMESERV_PREFERRED, DS_DIRECTORY_SERVICES_PREFERED, DS_DIRECTORY_SERVICES_REQUIRED, and DS_KDC_REQUIRED flags are ignored.
			/// </summary>
			DS_ONLY_LDAP_NEEDED = 0x8000,

			/// <summary>Specifies that the DomainName parameter is a flat name. This flag cannot be combined with the DS_IS_DNS_NAME flag.</summary>
			DS_IS_FLAT_NAME = 0x10000,

			/// <summary>
			/// Specifies that the DomainName parameter is a DNS name. This flag cannot be combined with the DS_IS_FLAT_NAME flag.
			/// <para>
			/// Specify either DS_IS_DNS_NAME or DS_IS_FLAT_NAME. If neither flag is specified, DsGetDcName may take longer to find a domain controller because
			/// it may have to search for both the DNS-style and flat name.
			/// </para>
			/// </summary>
			DS_IS_DNS_NAME = 0x20000,

			/// <summary>
			/// When this flag is specified, DsGetDcName attempts to find a domain controller in the same site as the caller. If no such domain controller is
			/// found, it will find a domain controller that can provide topology information and call DsBindToISTG to obtain a bind handle, then call
			/// DsQuerySitesByCost over UDP to determine the "next closest site," and finally cache the name of the site found. If no domain controller is found
			/// in that site, then DsGetDcName falls back on the default method of locating a domain controller.
			/// <para>If this flag is used in conjunction with a non-NULL value in the input parameter SiteName, then ERROR_INVALID_FLAGS is thrown.</para>
			/// <para>
			/// Also, the kind of search employed with DS_TRY_NEXT_CLOSEST_SITE is site-specific, so this flag is ignored if it is used in conjunction with
			/// DS_PDC_REQUIRED. Finally, DS_TRY_NEXTCLOSEST_SITE is ignored when used in conjunction with DS_RETURN_FLAT_NAME because that uses NetBIOS to
			/// resolve the name, but the domain of the domain controller found won't necessarily match the domain to which the client is joined.
			/// </para>
			/// <note>Note This flag is Group Policy enabled. If you enable the "Next Closest Site" policy setting, Next Closest Site DC Location will be turned
			/// on for the machine across all available but un-configured network adapters. If you disable the policy setting, Next Closest Site DC Location will
			/// not be used by default for the machine across all available but un-configured network adapters. However, if a DC Locator call is made using the
			/// DS_TRY_NEXTCLOSEST_SITE flag explicitly, DsGetDcName honors the Next Closest Site behavior. If you do not configure this policy setting, Next
			/// Closest Site DC Location will be not be used by default for the machine across all available but un-configured network adapters. If the
			/// DS_TRY_NEXTCLOSEST_SITE flag is used explicitly, the Next Closest Site behavior will be used.</note>
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
			/// Specifies that the names returned in the DomainControllerName and DomainName members of DomainControllerInfo should be DNS names. If a DNS name
			/// is not available, an error is returned. This flag cannot be specified with the DS_RETURN_FLAT_NAME flag. This flag implies the DS_IP_REQUIRED flag.
			/// </summary>
			DS_RETURN_DNS_NAME = 0x40000000,

			/// <summary>
			/// Specifies that the names returned in the DomainControllerName and DomainName members of DomainControllerInfo should be flat names. If a flat name
			/// is not available, an error is returned. This flag cannot be specified with the DS_RETURN_DNS_NAME flag.
			/// </summary>
			DS_RETURN_FLAT_NAME = 0x80000000,
		}

		/// <summary>The DOMAIN_CONTROLLER_INFO structure is used with the DsGetDcName function to receive data about a domain controller.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("DsGetDC.h", MSDNShortId = "ms675912")]
		public struct DOMAIN_CONTROLLER_INFO
		{
			/// <summary>
			/// Pointer to a null-terminated string that specifies the computer name of the discovered domain controller. The returned computer name is prefixed
			/// with "\\". The DNS-style name, for example, "\\phoenix.fabrikam.com", is returned, if available. If the DNS-style name is not available, the
			/// flat-style name (for example, "\\phoenix") is returned. This example would apply if the domain is a Windows NT 4.0 domain or if the domain does
			/// not support the IP family of protocols.
			/// </summary>
			public string DomainControllerName;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the address of the discovered domain controller. The address is prefixed with "\\". This
			/// string is one of the types defined by the DomainControllerAddressType member.
			/// </summary>
			public string DomainControllerAddress;

			/// <summary>Indicates the type of string that is contained in the DomainControllerAddress member.</summary>
			public DomainControllerAddressType DomainControllerAddressType;

			/// <summary>
			/// The GUID of the domain. This member is zero if the domain controller does not have a Domain GUID; for example, the domain controller is not a
			/// Windows 2000 domain controller.
			/// </summary>
			public Guid DomainGuid;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the name of the domain. The DNS-style name, for example, "fabrikam.com", is returned if
			/// available. Otherwise, the flat-style name, for example, "fabrikam", is returned. This name may be different than the requested domain name if the
			/// domain has been renamed.
			/// </summary>
			public string DomainName;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the name of the domain at the root of the DS tree. The DNS-style name, for example,
			/// "fabrikam.com", is returned if available. Otherwise, the flat-style name, for example, "fabrikam" is returned.
			/// </summary>
			public string DnsForestName;

			/// <summary>Contains a set of flags that describe the domain controller. This can be zero or a combination of one or more of the following values.</summary>
			public DomainControllerType Flags;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the name of the site where the domain controller is located. This member may be NULL if the
			/// domain controller is not in a site; for example, the domain controller is a Windows NT 4.0 domain controller.
			/// </summary>
			public string DcSiteName;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the name of the site that the computer belongs to. The computer is specified in the
			/// ComputerName parameter passed to DsGetDcName. This member may be NULL if the site that contains the computer cannot be found; for example, if the
			/// DS administrator has not associated the subnet that the computer is in with a valid site.
			/// </summary>
			public string ClientSiteName;
		}
	}
}