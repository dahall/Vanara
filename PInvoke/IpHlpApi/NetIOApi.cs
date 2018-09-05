using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		[PInvokeData("netioapi.h")]
		public enum MIB_IF_ENTRY_LEVEL
		{
			MibIfEntryNormal = 0,
			MibIfEntryNormalWithoutStatistics = 2
		}

		/// <summary>
		/// <para>The MIB_IF_TABLE_LEVEL enumeration type defines the level of interface information to retrieve.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MIB_IF_TABLE_LEVEL enumeration type is used with the GetIfTable2Ex function to specify the level of interface information to retrieve.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ne-netioapi-_mib_if_table_level typedef enum _MIB_IF_TABLE_LEVEL {
		// MibIfTableNormal , MibIfTableRaw , MibIfTableNormalWithoutStatistics } MIB_IF_TABLE_LEVEL, *PMIB_IF_TABLE_LEVEL;
		[PInvokeData("netioapi.h", MSDNShortId = "ffbde22e-9851-4acd-b820-b71f2788b4d2")]
		public enum MIB_IF_TABLE_LEVEL
		{
			/// <summary>
			/// The values of statistics and state that are returned in members of the MIB_IF_ROW2 structure in the MIB_IF_TABLE2 structure
			/// that the Table parameter points to in the GetIfTable2Ex function are returned from the top of the filter stack.
			/// </summary>
			MibIfTableNormal,

			/// <summary>
			/// The values of statistics and state that are returned in members of the MIB_IF_ROW2 structure in the MIB_IF_TABLE2 structure
			/// that the Table parameter points to in the GetIfTable2Ex function are returned directly for the interface that is being queried.
			/// </summary>
			MibIfTableRaw,

			/// <summary>The values returned are the same as for the MibIfTableNormal value, but without the statistics.</summary>
			MibIfTableNormalWithoutStatistics,
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("netioapi.h", MSDNShortId = "164dbd93-4464-40f9-989a-17597102b1d8")]
		[Flags]
		public enum MIB_IPNET_ROW2_FLAGS : uint
		{
			/// <summary>Undocumented.</summary>
			IsRouther = 1,

			/// <summary>Undocumented.</summary>
			IsUnreachable = 2
		}

		/// <summary>The NL_DAD_STATE enumeration type defines the duplicate address detection (DAD) state.</summary>
		// typedef enum { NldsInvalid, NldsTentative, NldsDuplicate, NldsDeprecated, NldsPreferred, IpDadStateInvalid = 0,
		// IpDadStateTentative, IpDadStateDuplicate, IpDadStateDeprecated, IpDadStatePreferred} NL_DAD_STATE; https://msdn.microsoft.com/en-us/library/windows/hardware/ff568758(v=vs.85).aspx
		[PInvokeData("Nldef.h", MSDNShortId = "ff568758")]
		public enum NL_DAD_STATE
		{
			/// <summary>The DAD state is invalid.</summary>
			IpDadStateInvalid,

			/// <summary>The DAD state is tentative.</summary>
			IpDadStateTentative,

			/// <summary>A duplicate IP address has been detected.</summary>
			IpDadStateDuplicate,

			/// <summary>The IP address has been deprecated.</summary>
			IpDadStateDeprecated,

			/// <summary>The IP address is the preferred address.</summary>
			IpDadStatePreferred,
		}

		/// <summary>The NL_PREFIX_ORIGIN enumeration type defines the origin of the prefix or network part of the IP address.</summary>
		// typedef enum { IpPrefixOriginOther = 0, IpPrefixOriginManual, IpPrefixOriginWellKnown, IpPrefixOriginDhcp,
		// IpPrefixOriginRouterAdvertisement, IpPrefixOriginUnchanged = 1 &lt;&lt; 4} NL_PREFIX_ORIGIN; https://msdn.microsoft.com/en-us/library/windows/hardware/ff568762(v=vs.85).aspx
		[PInvokeData("Nldef.h", MSDNShortId = "ff568762")]
		public enum NL_PREFIX_ORIGIN
		{
			/// <summary>
			/// The IP address prefix was configured by using a source other than those that are defined in this enumeration. This value
			/// applies to an IPv6 or IPv4 address.
			/// </summary>
			IpPrefixOriginOther = 0,

			/// <summary>The IP address prefix was configured manually. This value applies to an IPv6 or IPv4 address.</summary>
			IpPrefixOriginManual,

			/// <summary>
			/// The IP address prefix was configured by using a well-known address. This value applies to an IPv6 link-local address or an
			/// IPv6 loopback address.
			/// </summary>
			IpPrefixOriginWellKnown,

			/// <summary>
			/// The IP address prefix was configured by using DHCP. This value applies to an IPv4 address configured by using DHCP or an IPv6
			/// address configured by using DHCPv6.
			/// </summary>
			IpPrefixOriginDhcp,

			/// <summary>
			/// The IP address prefix was configured by using router advertisement. This value applies to an anonymous IPv6 address that was
			/// generated after receiving a router advertisement.
			/// </summary>
			IpPrefixOriginRouterAdvertisement,

			/// <summary>
			/// The IP address prefix should be unchanged. This value is used when setting the properties for a unicast IP interface when the
			/// value for the IP prefix origin should be unchanged.
			/// </summary>
			IpPrefixOriginUnchanged = 1 << 4,
		}

		/// <summary>
		/// <para>
		/// The <c>IP_SUFFIX_ORIGIN</c> enumeration specifies the origin of an IPv4 or IPv6 address suffix, and is used with the
		/// IP_ADAPTER_UNICAST_ADDRESS structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>IP_SUFFIX_ORIGIN</c> enumeration is used in the <c>SuffixOrigin</c> member of the IP_ADAPTER_UNICAST_ADDRESS structure.</para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>IP_SUFFIX_ORIGIN</c> enumeration is defined in the Nldef.h header file which is automatically included by
		/// the Iptypes.h header file. In order to use the <c>IP_SUFFIX_ORIGIN</c> enumeration, the Winsock2.h header file must be included
		/// before the Iptypes.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-nl_suffix_origin typedef enum NL_SUFFIX_ORIGIN { NlsoOther ,
		// NlsoManual , NlsoWellKnown , NlsoDhcp , NlsoLinkLayerAddress , NlsoRandom , IpSuffixOriginOther , IpSuffixOriginManual ,
		// IpSuffixOriginWellKnown , IpSuffixOriginDhcp , IpSuffixOriginLinkLayerAddress , IpSuffixOriginRandom , IpSuffixOriginUnchanged } ;
		[PInvokeData("nldef.h", MSDNShortId = "0ffeae3d-cfc4-472e-87f8-ae6d584fb869")]
		public enum NL_SUFFIX_ORIGIN
		{
			/// <summary>The IP address suffix was provided by a source other than those defined in this enumeration.</summary>
			IpSuffixOriginOther = 0,

			/// <summary>The IP address suffix was manually specified.</summary>
			IpSuffixOriginManual,

			/// <summary>The IP address suffix is from a well-known source.</summary>
			IpSuffixOriginWellKnown,

			/// <summary>The IP address suffix was provided by DHCP settings.</summary>
			IpSuffixOriginDhcp,

			/// <summary>The IP address suffix was obtained from the link-layer address.</summary>
			IpSuffixOriginLinkLayerAddress,

			/// <summary>The IP address suffix was obtained from a random source.</summary>
			IpSuffixOriginRandom,

			/// <summary>
			/// The IP address suffix should be unchanged. This value is used when setting the properties for a unicast IP interface when the
			/// value for the IP suffix origin should be left unchanged.
			/// </summary>
			IpSuffixOriginUnchanged = 1 << 4,
		}

		/// <summary>
		/// The <c>CancelMibChangeNotify2</c> function deregisters a driver change notification for IP interface changes, IP address changes,
		/// IP route changes, and requests to retrieve the stable Unicast IP address table.
		/// </summary>
		/// <param name="NotificationHandle">
		/// The handle that is returned from a notification registration or retrieval function to indicate which notification to cancel.
		/// </param>
		/// <returns>
		/// <para><c>CancelMibChangeNotify2</c> returns STATUS_SUCCESS if the function succeeds.</para>
		/// <para>If the function fails, <c>CancelMibChangeNotify2</c> returns one of the following error codes:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. CancelMibChangeNotify2 returns this error if the NotificationHandle parameter
		/// was a NULL pointer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// NETIOAPI_API CancelMibChangeNotify2( _In_ HANDLE NotificationHandle); https://msdn.microsoft.com/en-us/library/windows/hardware/ff544864(v=vs.85).aspx
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Netioapi.h", MSDNShortId = "ff544864")]
		public static extern Win32Error CancelMibChangeNotify2([In] IntPtr NotificationHandle);

		/// <summary>
		/// <para>
		/// The <c>ConvertInterfaceAliasToLuid</c> function converts an interface alias name for a network interface to the locally unique
		/// identifier (LUID) for the interface.
		/// </para>
		/// </summary>
		/// <param name="InterfaceAlias">
		/// <para>A pointer to a <c>NULL</c>-terminated Unicode string containing the alias name of the network interface.</para>
		/// </param>
		/// <param name="InterfaceLuid">
		/// <para>A pointer to the NET_LUID for this interface.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>ConvertInterfaceAliasToLuid</c> returns NO_ERROR. Any nonzero return value indicates failure and a <c>NULL</c> is
		/// returned in the InterfaceLuid parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters was invalid. This error is returned if either the InterfaceAlias or InterfaceLuid parameter was NULL or if
		/// the InterfaceAlias parameter was invalid.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ConvertInterfaceAliasToLuid</c> function is available on Windows Vistaand later.</para>
		/// <para>
		/// The <c>ConvertInterfaceAliasToLuid</c> function is protocol independent and works with network interfaces for both the IPv6 and
		/// IPv4 protocol.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertinterfacealiastoluid _NETIOAPI_SUCCESS_
		// NETIOAPI_API ConvertInterfaceAliasToLuid( CONST WCHAR *InterfaceAlias, PNET_LUID InterfaceLuid );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "7fa80938-d475-4ace-b463-a53aac26e88b")]
		public static extern Win32Error ConvertInterfaceAliasToLuid([MarshalAs(UnmanagedType.LPWStr)] string InterfaceAlias, out NET_LUID InterfaceLuid);

		/// <summary>
		/// <para>
		/// The <c>ConvertInterfaceGuidToLuid</c> function converts a globally unique identifier (GUID) for a network interface to the
		/// locally unique identifier (LUID) for the interface.
		/// </para>
		/// </summary>
		/// <param name="InterfaceGuid">
		/// <para>A pointer to a GUID for a network interface.</para>
		/// </param>
		/// <param name="InterfaceLuid">
		/// <para>A pointer to the NET_LUID for this interface.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>ConvertInterfaceGuidToLuid</c> returns NO_ERROR. Any nonzero return value indicates failure and a <c>NULL</c> is
		/// returned in the InterfaceLuid parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters was invalid. This error is returned if either the InterfaceAlias or InterfaceLuid parameter was NULL or if
		/// the InterfaceGuid parameter was invalid.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ConvertInterfaceGuidToLuid</c> function is available on Windows Vistaand later.</para>
		/// <para>
		/// The <c>ConvertInterfaceGuidToLuid</c> function is protocol independent and works with network interfaces for both the IPv6 and
		/// IPv4 protocol.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertinterfaceguidtoluid _NETIOAPI_SUCCESS_
		// NETIOAPI_API ConvertInterfaceGuidToLuid( CONST GUID *InterfaceGuid, PNET_LUID InterfaceLuid );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "cae669dc-899b-4485-b70a-5f58207a07df")]
		public static extern Win32Error ConvertInterfaceGuidToLuid([MarshalAs(UnmanagedType.LPStruct)] Guid InterfaceGuid, out NET_LUID InterfaceLuid);

		/// <summary>
		/// <para>
		/// The <c>ConvertInterfaceIndexToLuid</c> function converts a local index for a network interface to the locally unique identifier
		/// (LUID) for the interface.
		/// </para>
		/// </summary>
		/// <param name="InterfaceIndex">
		/// <para>The local index value for a network interface.</para>
		/// </param>
		/// <param name="InterfaceLuid">
		/// <para>A pointer to the NET_LUID for this interface.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>ConvertInterfaceIndexToLuid</c> returns NO_ERROR. Any nonzero return value indicates failure and a <c>NULL</c> is
		/// returned in the InterfaceLuid parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned if the network interface specified by the InterfaceIndex
		/// parameter was not a value on the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters was invalid. This error is returned if the InterfaceLuid parameter was NULL or if the InterfaceIndex
		/// parameter was invalid.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ConvertInterfaceIndexToLuid</c> function is available on Windows Vistaand later.</para>
		/// <para>
		/// The <c>ConvertInterfaceIndexToLuid</c> function is protocol independent and works with network interfaces for both the IPv6 and
		/// IPv4 protocol.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertinterfaceindextoluid _NETIOAPI_SUCCESS_
		// NETIOAPI_API ConvertInterfaceIndexToLuid( NET_IFINDEX InterfaceIndex, PNET_LUID InterfaceLuid );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "c757228c-93f1-4545-8921-9d048bca580c")]
		public static extern Win32Error ConvertInterfaceIndexToLuid(uint InterfaceIndex, out NET_LUID InterfaceLuid);

		/// <summary>
		/// <para>
		/// The <c>ConvertInterfaceLuidToAlias</c> function converts a locally unique identifier (LUID) for a network interface to an
		/// interface alias.
		/// </para>
		/// </summary>
		/// <param name="InterfaceLuid">
		/// <para>A pointer to a NET_LUID for a network interface.</para>
		/// </param>
		/// <param name="InterfaceAlias">
		/// <para>
		/// A pointer to a buffer to hold the <c>NULL</c>-terminated Unicode string containing the alias name of the network interface when
		/// the function returns successfully.
		/// </para>
		/// </param>
		/// <param name="Length">
		/// <para>
		/// The length, in characters, of the buffer pointed to by the InterfaceAlias parameter. This value must be large enough to
		/// accommodate the alias name of the network interface and the terminating <c>NULL</c> character. The maximum required length is
		/// <c>NDIS_IF_MAX_STRING_SIZE</c> + 1.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>On success, <c>ConvertInterfaceLuidToAlias</c> returns NO_ERROR. Any nonzero return value indicates failure.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters was invalid. This error is returned if either the InterfaceLuid or InterfaceAlias parameter was NULL or if
		/// the InterfaceLuid parameter was invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// Not enough storage is available to process this command. This error is returned if the size of the buffer pointed to by the
		/// InterfaceAlias parameter was not large enough as specified in the Length parameter to hold the alias name.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ConvertInterfaceLuidToAlias</c> function is available on Windows Vistaand later.</para>
		/// <para>
		/// The <c>ConvertInterfaceLuidToAlias</c> function is protocol independent and works with network interfaces for both the IPv6 and
		/// IPv4 protocol.
		/// </para>
		/// <para>
		/// The maximum length of the alias name for a network interface, <c>NDIS_IF_MAX_STRING_SIZE</c>, without the terminating <c>NULL</c>
		/// is declared in the Ntddndis.h header file. The <c>NDIS_IF_MAX_STRING_SIZE</c> is defined to be the <c>IF_MAX_STRING_SIZE</c>
		/// constant defined in the Ifdef.h header file. The Ntddndis.h and Ifdef.h header files are automatically included in the Netioapi.h
		/// header file which is automatically included by the IpHlpApi.h header file. The Ntddndis.h, Ifdef.h, and Netioapi.h header files
		/// should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertinterfaceluidtoalias _NETIOAPI_SUCCESS_
		// NETIOAPI_API ConvertInterfaceLuidToAlias( CONST NET_LUID *InterfaceLuid, PWSTR InterfaceAlias, SIZE_T Length );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "86a821c1-e04b-4bc3-846d-767c55008aed")]
		public static extern Win32Error ConvertInterfaceLuidToAlias([MarshalAs(UnmanagedType.LPStruct)] NET_LUID InterfaceLuid, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder InterfaceAlias, SizeT Length);

		/// <summary>
		/// <para>
		/// The <c>ConvertInterfaceLuidToGuid</c> function converts a locally unique identifier (LUID) for a network interface to a globally
		/// unique identifier (GUID) for the interface.
		/// </para>
		/// </summary>
		/// <param name="InterfaceLuid">
		/// <para>A pointer to a NET_LUID for a network interface.</para>
		/// </param>
		/// <param name="InterfaceGuid">
		/// <para>A pointer to the <c>GUID</c> for this interface.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>ConvertInterfaceLuidToGuid</c> returns NO_ERROR. Any nonzero return value indicates failure and a <c>NULL</c> is
		/// returned in the InterfaceGuid parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters was invalid. This error is returned if either the InterfaceLuid or InterfaceGuid parameter was NULL or if
		/// the InterfaceLuid parameter was invalid.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ConvertInterfaceLuidToGuid</c> function is available on Windows Vistaand later.</para>
		/// <para>
		/// The <c>ConvertInterfaceLuidToGuid</c> function is protocol independent and works with network interfaces for both the IPv6 and
		/// IPv4 protocol.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertinterfaceluidtoguid _NETIOAPI_SUCCESS_
		// NETIOAPI_API ConvertInterfaceLuidToGuid( CONST NET_LUID *InterfaceLuid, GUID *InterfaceGuid );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "9d5bd1e9-0bf1-405a-8726-8e2c9ba4e022")]
		public static extern Win32Error ConvertInterfaceLuidToGuid([MarshalAs(UnmanagedType.LPStruct)] NET_LUID InterfaceLuid, out Guid InterfaceGuid);

		/// <summary>
		/// The <c>ConvertInterfaceLuidToIndex</c> function converts a locally unique identifier (LUID) for a network interface to the local
		/// index for the interface.
		/// </summary>
		/// <param name="InterfaceLuid">A pointer to a NET_LUID for a network interface.</param>
		/// <param name="InterfaceIndex">The local index value for the interface.</param>
		/// <returns>
		/// <para>
		/// On success, <c>ConvertInterfaceLuidToIndex</c> returns NO_ERROR. Any nonzero return value indicates failure and a
		/// <c>NET_IFINDEX_UNSPECIFIED</c> is returned in the InterfaceIndex parameter.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters was invalid. This error is returned if either the InterfaceLuid or InterfaceIndex parameter was NULL or if
		/// the InterfaceLuid parameter was invalid.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// NETIO_STATUS WINAPI ConvertInterfaceLuidToIndex( _In_ const NET_LUID *InterfaceLuid, _Out_ PNET_IFINDEX InterfaceIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365835(v=vs.85).aspx
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Netioapi.h", MSDNShortId = "aa365835")]
		public static extern Win32Error ConvertInterfaceLuidToIndex([In, MarshalAs(UnmanagedType.LPStruct)] NET_LUID InterfaceLuid, out uint InterfaceIndex);

		/// <summary>
		/// <para>
		/// The <c>ConvertInterfaceLuidToNameA</c> function converts a locally unique identifier (LUID) for a network interface to the ANSI
		/// interface name.
		/// </para>
		/// </summary>
		/// <param name="InterfaceLuid">
		/// <para>A pointer to a NET_LUID for a network interface.</para>
		/// </param>
		/// <param name="InterfaceName">
		/// <para>
		/// A pointer to a buffer to hold the <c>NULL</c>-terminated ANSI string containing the interface name when the function returns successfully.
		/// </para>
		/// </param>
		/// <param name="Length">
		/// <para>
		/// The length, in bytes, of the buffer pointed to by the InterfaceName parameter. This value must be large enough to accommodate the
		/// interface name and the terminating null character. The maximum required length is <c>NDIS_IF_MAX_STRING_SIZE</c> + 1.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>ConvertInterfaceLuidToNameA</c> returns <c>NETIO_ERROR_SUCCESS</c>. Any nonzero return value indicates failure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters was invalid. This error is returned if either the InterfaceLuid or the InterfaceName parameter was NULL or
		/// if the InterfaceLuid parameter was invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// Not enough storage is available to process this command. This error is returned if the size of the buffer pointed to by
		/// InterfaceName parameter was not large enough as specified in the Length parameter to hold the interface name.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ConvertInterfaceLuidToNameA</c> function is available on Windows Vistaand later.</para>
		/// <para>
		/// The <c>ConvertInterfaceLuidToNameA</c> function is protocol independent and works with network interfaces for both the IPv6 and
		/// IPv4 protocol. The <c>ConvertInterfaceLuidToNameA</c> converts a network interface LUID to an ANSI interface name.
		/// </para>
		/// <para>The ConvertInterfaceLuidToNameW converts a network interface LUID to a Unicode interface name.</para>
		/// <para>
		/// The maximum length of an interface name, <c>NDIS_IF_MAX_STRING_SIZE</c>, without the terminating <c>NULL</c> is declared in the
		/// Ntddndis.h header file. The <c>NDIS_IF_MAX_STRING_SIZE</c> is defined to be the <c>IF_MAX_STRING_SIZE</c> constant defined in the
		/// Ifdef.h header file. The Ntddndis.h and Ifdef.h header files are automatically included in the Netioapi.h header file which is
		/// automatically included by the IpHlpApi.h header file. The Ntddndis.h, Ifdef.h, and Netioapi.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertinterfaceluidtonamea _NETIOAPI_SUCCESS_
		// NETIOAPI_API ConvertInterfaceLuidToNameA( CONST NET_LUID *InterfaceLuid, PSTR InterfaceName, SIZE_T Length );
		[DllImport(Lib.IpHlpApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("netioapi.h", MSDNShortId = "c65f7b3c-55f4-40f8-9a7a-19d1066deca4")]
		public static extern Win32Error ConvertInterfaceLuidToName([In, MarshalAs(UnmanagedType.LPStruct)] NET_LUID InterfaceLuid, StringBuilder InterfaceName, SizeT Length);

		/// <summary>
		/// <para>
		/// The <c>ConvertInterfaceNameToLuidA</c> function converts an ANSI network interface name to the locally unique identifier (LUID)
		/// for the interface.
		/// </para>
		/// </summary>
		/// <param name="InterfaceName">
		/// <para>A pointer to a <c>NULL</c>-terminated ANSI string containing the network interface name.</para>
		/// </param>
		/// <param name="InterfaceLuid">
		/// <para>A pointer to the NET_LUID for this interface.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>ConvertInterfaceNameToLuidA</c> returns <c>NETIO_ERROR_SUCCESS</c>. Any nonzero return value indicates failure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BUFFER_OVERFLOW</term>
		/// <term>
		/// The length of the ANSI interface name was invalid. This error is returned if the InterfaceName parameter exceeded the maximum
		/// allowed string length for this parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_NAME</term>
		/// <term>The interface name was invalid. This error is returned if the InterfaceName parameter contained an invalid name.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameters was invalid. This error is returned if the InterfaceLuid parameter was NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ConvertInterfaceNameToLuidA</c> function is available on Windows Vistaand later.</para>
		/// <para>
		/// The <c>ConvertInterfaceNameToLuidA</c> function is protocol independent and works with network interfaces for both the IPv6 and
		/// IPv4 protocol. The <c>ConvertInterfaceNameToLuidA</c> converts an ANSI interface name to a LUID.
		/// </para>
		/// <para>The ConvertInterfaceNameToLuidW converts a Unicode interface name to a LUID.</para>
		/// <para>
		/// The maximum length of an interface name, <c>NDIS_IF_MAX_STRING_SIZE</c>, without the terminating <c>NULL</c> is declared in the
		/// Ntddndis.h header file. The <c>NDIS_IF_MAX_STRING_SIZE</c> is defined to be the <c>IF_MAX_STRING_SIZE</c> constant defined in the
		/// Ifdef.h header file. The Ntddndis.h and Ifdef.h header files are automatically included in the Netioapi.h header file which is
		/// automatically included by the IpHlpApi.h header file. The Ntddndis.h, Ifdef.h, and Netioapi.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertinterfacenametoluida _NETIOAPI_SUCCESS_
		// NETIOAPI_API ConvertInterfaceNameToLuidA( CONST CHAR *InterfaceName, NET_LUID *InterfaceLuid );
		[DllImport(Lib.IpHlpApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("netioapi.h", MSDNShortId = "daceabf9-ff43-4206-9f8f-f3924de9c5a5")]
		public static extern Win32Error ConvertInterfaceNameToLuid(string InterfaceName, out NET_LUID InterfaceLuid);

		/// <summary>
		/// <para>The <c>ConvertIpv4MaskToLength</c> function converts an IPv4 subnet mask to an IPv4 prefix length.</para>
		/// </summary>
		/// <param name="Mask">
		/// <para>The IPv4 subnet mask.</para>
		/// </param>
		/// <param name="MaskLength">
		/// <para>A pointer to a <c>UINT8</c> value to hold the IPv4 prefix length, in bits, when the function returns successfully.</para>
		/// </param>
		/// <returns>
		/// <para>On success, <c>ConvertIpv4MaskToLength</c> returns <c>NO_ERROR</c>. Any nonzero return value indicates failure.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameters was invalid. This error is returned if the Mask parameter was invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ConvertIpv4MaskToLength</c> function is available on Windows Vistaand later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertipv4masktolength NETIOAPI_API
		// ConvertIpv4MaskToLength( ULONG Mask, PUINT8 MaskLength );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "63a3c558-24e0-41ef-9417-a3b6b2075977")]
		public static extern Win32Error ConvertIpv4MaskToLength(uint Mask, out byte MaskLength);

		/// <summary>
		/// <para>The <c>ConvertLengthToIpv4Mask</c> function converts an IPv4 prefix length to an IPv4 subnet mask.</para>
		/// </summary>
		/// <param name="MaskLength">
		/// <para>The IPv4 prefix length, in bits.</para>
		/// </param>
		/// <param name="Mask">
		/// <para>A pointer to a <c>LONG</c> value to hold the IPv4 subnet mask when the function returns successfully.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>ConvertLengthToIpv4Mask</c> returns <c>NO_ERROR</c>. Any nonzero return value indicates failure and the Mask
		/// parameter is set to <c>INADDR_NONE</c> defined in the Ws2def.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameters was invalid. This error is returned if the MaskLength parameter was invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ConvertLengthToIpv4Mask</c> function is available on Windows Vistaand later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertlengthtoipv4mask NETIOAPI_API
		// ConvertLengthToIpv4Mask( ULONG MaskLength, PULONG Mask );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "5d986301-368e-4984-9f90-e2af1f87cbea")]
		public static extern Win32Error ConvertLengthToIpv4Mask(uint MaskLength, out uint Mask);

		/// <summary>
		/// <para>The <c>CreateIpForwardEntry2</c> function creates a new IP route entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>A pointer to a MIB_IPFORWARD_ROW2 structure entry for an IP route entry.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// DestinationPrefix member of the MIB_IPFORWARD_ROW2 pointed to by the Row parameter was not specified, the NextHop member of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Row parameter was not specified, or both the InterfaceLuid or InterfaceIndex members of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Row parameter were unspecified. This error is also returned if the PreferredLifetime member
		/// specified in the MIB_IPFORWARD_ROW2 is greater than the ValidLifetime member or if the SitePrefixLength in the MIB_IPFORWARD_ROW2
		/// is greater than the prefix length specified in the DestinationPrefix.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the interface specified does not support routes. This error is also
		/// returned if no IPv4 stack is on the local computer and AF_INET was specified in the address family in the DestinationPrefix
		/// member of the MIB_IPFORWARD_ROW2 pointed to by the Row parameter. This error is also returned if no IPv6 stack is on the local
		/// computer and AF_INET6 was specified for the address family in the DestinationPrefix member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OBJECT_ALREADY_EXISTS</term>
		/// <term>
		/// The object already exists. This error is returned if the DestinationPrefix member of the MIB_IPFORWARD_ROW2 pointed to by the Row
		/// parameter is a duplicate of an existing IP route entry on the interface specified by the InterfaceLuid or InterfaceIndex member
		/// of the MIB_IPFORWARD_ROW2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CreateIpForwardEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>CreateIpForwardEntry2</c> function is used to add a new neighbor IP address entry on a local computer. The
		/// InitializeIpForwardEntry function should be used to initialize the members of a MIB_IPFORWARD_ROW2 structure entry with default
		/// values. An application can then change the members in the <c>MIB_IPFORWARD_ROW2</c> entry it wishes to modify, and then call the
		/// <c>CreateIpForwardEntry2</c> function.
		/// </para>
		/// <para>
		/// The <c>DestinationPrefix</c> member in the MIB_IPFORWARD_ROW2 structure pointed to by the Row parameter must be initialized to a
		/// valid IPv4 or IPv6 address prefix. The <c>NextHop</c> member in the <c>MIB_IPFORWARD_ROW2</c> structure pointed to by the Row
		/// parameter must be initialized to a valid IPv4 or IPv6 address and family. In addition, at least one of the following members in
		/// the <c>MIB_IPFORWARD_ROW2</c> structure pointed to the Row parameter must be initialized to the interface: the
		/// <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// The route metric offset specified in the <c>Metric</c> member of the MIB_IPFORWARD_ROW2 structure pointed to by Row parameter
		/// represents only part of the complete route metric. The complete metric is a combination of this route metric offset added to the
		/// interface metric specified in the <c>Metric</c> member of the MIB_IPINTERFACE_ROW structure of the associated interface. An
		/// application can retrieve the interface metric by calling the GetIpInterfaceEntry function.
		/// </para>
		/// <para>
		/// The <c>Age</c> and <c>Origin</c> members of the MIB_IPFORWARD_ROW2 structure pointed to by the Row are ignored when the
		/// <c>CreateIpForwardEntry2</c> function is called. These members are set by the network stack and cannot be set using the
		/// <c>CreateIpForwardEntry2</c> function.
		/// </para>
		/// <para>
		/// The <c>CreateIpForwardEntry2</c> function will fail if the <c>DestinationPrefix</c> and <c>NextHop</c> members of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Row parameter are a duplicate of an existing IP route entry on the interface specified in
		/// the <c>InterfaceLuid</c> or <c>InterfaceIndex</c> members.
		/// </para>
		/// <para>
		/// The <c>CreateIpForwardEntry2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>CreateIpForwardEntry2</c> is called by a user that is not a member of the Administrators group, the function call will fail
		/// and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista
		/// and later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-createipforwardentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// CreateIpForwardEntry2( CONST MIB_IPFORWARD_ROW2 *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "d2d065d3-daad-4167-8b87-4229199ee76a")]
		public static extern Win32Error CreateIpForwardEntry2(ref MIB_IPFORWARD_ROW2 Row);

		/// <summary>
		/// <para>The <c>CreateIpNetEntry2</c> function creates a new neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid unicast, anycast, or multicast IPv4
		/// or IPv6 address, the PhysicalAddress and PhysicalAddressLength members of the MIB_IPNET_ROW2 pointed to by the Row parameter were
		/// not set to a valid physical address, or both the InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the
		/// Row parameter were unspecified. This error is also returned if a loopback address was passed in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter. This error is also returned if no IPv6 stack is on
		/// the local computer and an IPv6 address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OBJECT_ALREADY_EXISTS</term>
		/// <term>
		/// The object already exists. This error is returned if the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter is
		/// a duplicate of an existing neighbor IP address on the interface specified by the InterfaceLuid or InterfaceIndex member of the MIB_IPNET_ROW2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CreateIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>CreateIpNetEntry2</c> function is used to add a new neighbor IP address entry on a local computer.</para>
		/// <para>
		/// The <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a valid unicast,
		/// anycast, or multicast IPv4 or IPv6 address and family. The <c>PhysicalAddress</c> and <c>PhysicalAddressLength</c> members in the
		/// <c>MIB_IPNET_ROW2</c> structure pointed to by the Row parameter must be initialized to a valid physical address. In addition, at
		/// least one of the following members in the <c>MIB_IPNET_ROW2</c> structure pointed to the Row parameter must be initialized to the
		/// interface: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// The <c>CreateIpNetEntry2</c> function will fail if the IP address passed in the <c>Address</c> member of the MIB_IPNET_ROW2
		/// pointed to by the Row parameter is a duplicate of an existing neighbor IP address on the interface.
		/// </para>
		/// <para>
		/// The <c>CreateIpNetEntry2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>CreateIpNetEntry2</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista and
		/// later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-createipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// CreateIpNetEntry2( CONST MIB_IPNET_ROW2 *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "ca92b9f8-ec3c-4889-b649-f606c3920f92")]
		public static extern Win32Error CreateIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// <para>
		/// The <c>CreateSortedAddressPairs</c> function takes a supplied list of potential IP destination addresses, pairs the destination
		/// addresses with the host machine's local IP addresses, and sorts the pairs according to which address pair is best suited for
		/// communication between the two peers.
		/// </para>
		/// </summary>
		/// <param name="SourceAddressList">
		/// <para>Must be <c>NULL</c>. Reserved for future use.</para>
		/// </param>
		/// <param name="SourceAddressCount">
		/// <para>Must be 0. Reserved for future use.</para>
		/// </param>
		/// <param name="DestinationAddressList">
		/// <para>
		/// A pointer to an array of SOCKADDR_IN6 structures that contain a list of potential IPv6 destination addresses. Any IPv4 addresses
		/// must be represented in the IPv4-mapped IPv6 address format which enables an IPv6 only application to communicate with an IPv4 node.
		/// </para>
		/// </param>
		/// <param name="DestinationAddressCount">
		/// <para>The number of destination addresses pointed to by the DestinationAddressList parameter.</para>
		/// </param>
		/// <param name="AddressSortOptions">
		/// <para>Reserved for future use.</para>
		/// </param>
		/// <param name="SortedAddressPairList">
		/// <para>
		/// A pointer to store an array of SOCKADDR_IN6_PAIR structures that contain a list of pairs of IPv6 addresses sorted in the
		/// preferred order of communication, if the function call is successful.
		/// </para>
		/// </param>
		/// <param name="SortedAddressPairCount">
		/// <para>
		/// A pointer to store the number of address pairs pointed to by the SortedAddressPairList parameter, if the function call is successful.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the DestinationAddressList, SortedAddressPairList, or
		/// SortedAddressPairCount parameters NULL, or the DestinationAddressCount was greated than 500. This error is also returned if the
		/// SourceAddressList is not NULL or the SourceAddressPairCount parameter is not zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough storage is available to process this command.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv6 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CreateSortedAddressPairs</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>CreateSortedAddressPairs</c> function takes a list of source and destination IPv6 addresses, and returns a list of pairs
		/// of addresses in sorted order. The list is sorted by which address pair is best suited for communication between the source and
		/// destination address.
		/// </para>
		/// <para>
		/// The list of source addresses pointed to by the SourceAddressList is currently reserved for future and must be a <c>NULL</c>
		/// pointer. The SourceAddressCount is currently reserved for future and must be zero. The <c>CreateSortedAddressPairs</c> function
		/// currently uses all of the host machine's local addresses for the source address list.
		/// </para>
		/// <para>
		/// The list of destination addresses is pointed to by the DestinationAddressList parameter. The list of destination addresses is an
		/// array of SOCKADDR_IN6 structures. Any IPv4 addresses must be represented in the IPv4-mapped IPv6 address format which enables an
		/// IPv6 only application to communicate with an IPv4 node. For more information on the IPv4-mapped IPv6 address format, see
		/// Dual-Stack Sockets. The DestinationAddressCount parameter contains the number of destination addresses pointed to by the
		/// DestinationAddressList parameter. The <c>CreateSortedAddressPairs</c> function supports a maximum of 500 destination addresses.
		/// </para>
		/// <para>
		/// If the <c>CreateSortedAddressPairs</c> function is successful, the SortedAddressPairList parameter points to an array of
		/// SOCKADDR_IN6_PAIR structures that contain the sorted address pairs. When this returned list is no longer required, free the
		/// memory used by the list by calling the FreeMibTable function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-createsortedaddresspairs _NETIOAPI_SUCCESS_ NETIOAPI_API
		// CreateSortedAddressPairs( const PSOCKADDR_IN6 SourceAddressList, ULONG SourceAddressCount, const PSOCKADDR_IN6
		// DestinationAddressList, ULONG DestinationAddressCount, ULONG AddressSortOptions, PSOCKADDR_IN6_PAIR *SortedAddressPairList, ULONG
		// *SortedAddressPairCount );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "cdc90d63-15a4-4278-afc3-dbf9ad6ba698")]
		public static extern Win32Error CreateSortedAddressPairs(IntPtr SourceAddressList, uint SourceAddressCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] SOCKADDR_IN6[] DestinationAddressList, uint DestinationAddressCount, uint AddressSortOptions, out SafeMibTableHandle SortedAddressPairList, out uint SortedAddressPairCount);

		/// <summary>
		/// The <c>CreateSortedAddressPairs</c> function takes a supplied list of potential IP destination addresses, pairs the destination
		/// addresses with the host machine's local IP addresses, and sorts the pairs according to which address pair is best suited for
		/// communication between the two peers.
		/// </summary>
		/// <param name="DestinationAddressList">
		/// An array of SOCKADDR_IN6 structures that contain a list of potential IPv6 destination addresses. Any IPv4 addresses must be
		/// represented in the IPv4-mapped IPv6 address format which enables an IPv6 only application to communicate with an IPv4 node.
		/// </param>
		/// <returns>An array of SOCKADDR_IN6_PAIR structures that contain the sorted address pairs.</returns>
		public static SOCKADDR_IN6_PAIR[] CreateSortedAddressPairs(SOCKADDR_IN6[] DestinationAddressList)
		{
			CreateSortedAddressPairs(IntPtr.Zero, 0, DestinationAddressList, (uint)DestinationAddressList.Length, 0, out SafeMibTableHandle pairs, out uint cnt).ThrowIfFailed();
			return pairs.ToArray<SOCKADDR_IN6_PAIR>((int)cnt);
		}

		/// <summary>
		/// <para>The <c>CreateUnicastIpAddressEntry</c> function adds a new unicast IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>A pointer to a MIB_UNICASTIPADDRESS_ROW structure entry for a unicast IP address entry.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter was not set to a valid unicast IPv4 or IPv6
		/// address, or both the InterfaceLuid and InterfaceIndex members of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter
		/// were unspecified. This error is also returned for other errors in the values set for members in the MIB_UNICASTIPADDRESS_ROW
		/// structure. These errors include the following: if the ValidLifetime member is less than than the PreferredLifetime member, if the
		/// PrefixOrigin member is set to IpPrefixOriginUnchanged and the SuffixOrigin is the not set to IpSuffixOriginUnchanged, if the
		/// PrefixOrigin member is not set to IpPrefixOriginUnchanged and the SuffixOrigin is set to IpSuffixOriginUnchanged, if the
		/// PrefixOrigin member is not set to a value from the NL_PREFIX_ORIGIN enumeration, if the SuffixOrigin member is not set to a value
		/// from the NL_SUFFIX_ORIGIN enumeration, or if the OnLinkPrefixLength member is set to a value greater than the IP address length,
		/// in bits (32 for a unicast IPv4 address or 128 for a unicast IPv6 address).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter. This error is also returned if no IPv6
		/// stack is on the local computer and an IPv6 address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OBJECT_ALREADY_EXISTS</term>
		/// <term>
		/// The object already exists. This error is returned if the Address member of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row
		/// parameter is a duplicate of an existing unicast IP address on the interface specified by the InterfaceLuid or InterfaceIndex
		/// member of the MIB_UNICASTIPADDRESS_ROW.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CreateUnicastIpAddressEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>CreateUnicastIpAddressEntry</c> function is used to add a new unicast IP address entry on a local computer. The unicast IP
		/// address added by the <c>CreateUnicastIpAddressEntry</c> function is not persistent. The IP address exists only as long as the
		/// adapter object exists. Restarting the computer destroys the IP address, as does manually resetting the network interface card
		/// (NIC). Also, certain PnP events may destroy the address.
		/// </para>
		/// <para>
		/// To create an IPv4 address that persists, the EnableStatic method of the Win32_NetworkAdapterConfiguration Class in the Windows
		/// Management Instrumentation (WMI) controls may be used. The netsh command can also be used to create a persistent IPv4 or IPv6 address.
		/// </para>
		/// <para>For more information, please see the documentation on Netsh.exe in the Windows Sockets documentation.</para>
		/// <para>
		/// The InitializeUnicastIpAddressEntry function should be used to initialize the members of a MIB_UNICASTIPADDRESS_ROW structure
		/// entry with default values. An application can then change the members in the <c>MIB_UNICASTIPADDRESS_ROW</c> entry it wishes to
		/// modify, and then call the <c>CreateUnicastIpAddressEntry</c> function.
		/// </para>
		/// <para>
		/// The <c>Address</c> member in the MIB_UNICASTIPADDRESS_ROW structure pointed to by the Row parameter must be initialized to a
		/// valid unicast IPv4 or IPv6 address. The <c>si_family</c> member of the <c>SOCKADDR_INET</c> structure in the <c>Address</c>
		/// member must be initialized to either <c>AF_INET</c> or <c>AF_INET6</c> and the related <c>Ipv4</c> or <c>Ipv6</c> member of the
		/// <c>SOCKADDR_INET</c> structure must be set to a valid unicast IP address. In addition, at least one of the following members in
		/// the <c>MIB_UNICASTIPADDRESS_ROW</c> structure pointed to the Row parameter must be initialized to the interface: the
		/// <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// If the <c>OnLinkPrefixLength</c> member of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter is set to 255, then
		/// <c>CreateUnicastIpAddressEntry</c> will add the new unicast IP address with the <c>OnLinkPrefixLength</c> member set equal to the
		/// length of the IP address. So for a unicast IPv4 address, the <c>OnLinkPrefixLength</c> is set to 32 and the
		/// <c>OnLinkPrefixLength</c> is set to 128 for a unicast IPv6 address. If this would result in the incorrect subnet mask for an IPv4
		/// address or the incorrect link prefix for an IPv6 address, then the application should set this member to the correct value before
		/// calling <c>CreateUnicastIpAddressEntry</c>.
		/// </para>
		/// <para>
		/// If a unicast IP address is created with the <c>OnLinkPrefixLength</c> member set incorrectly, then the IP address may be changed
		/// by calling SetUnicastIpAddressEntry with the <c>OnLinkPrefixLength</c> member set to the correct value.
		/// </para>
		/// <para>
		/// The <c>DadState</c>, <c>ScopeId</c>, and <c>CreationTimeStamp</c> members of the MIB_UNICASTIPADDRESS_ROW structure pointed to by
		/// the Row are ignored when the <c>CreateUnicastIpAddressEntry</c> function is called. These members are set by the network stack.
		/// The <c>ScopeId</c> member is automatically determined by the interface on which the address is added. Beginning in Windows 10, if
		/// <c>DadState</c> is set to <c>IpDadStatePreferred</c> in the <c>MIB_UNICASTIPADDRESS_ROW</c> structure when calling
		/// <c>CreateUnicastIpAddressEntry</c>, the stack will set the initial DAD state of the address to “preferred” instead of “tentative”
		/// and will do optimistic DAD for the address.
		/// </para>
		/// <para>
		/// The <c>CreateUnicastIpAddressEntry</c> function will fail if the unicast IP address passed in the <c>Address</c> member of the
		/// MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter is a duplicate of an existing unicast IP address on the interface. Note
		/// that a loopback IP address can only be added to a loopback interface using the <c>CreateUnicastIpAddressEntry</c> function.
		/// </para>
		/// <para>
		/// The unicast IP address passed in the <c>Address</c> member of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter is not
		/// usable immediately. The IP address is usable after the duplicate address detection process has completed successfully. It can
		/// take several seconds for the duplicate address detection process to complete since IP packets need to be sent and potential
		/// responses must be awaited. For IPv6, the duplicate address detection process typically takes about a second. For IPv4, the
		/// duplicate address detection process typically takes about three seconds.
		/// </para>
		/// <para>
		/// If an application that needs to know when an IP address is usable after a call to the <c>CreateUnicastIpAddressEntry</c>
		/// function, there are two methods that can be used. One method uses polling and the GetUnicastIpAddressEntry function. The second
		/// method calls one of the notification functions, NotifyAddrChange, NotifyIpInterfaceChange, or NotifyUnicastIpAddressChange to set
		/// up an asynchronous notification for when an address changes.
		/// </para>
		/// <para>
		/// The following method describes how to use the GetUnicastIpAddressEntry and polling. After the call to the
		/// <c>CreateUnicastIpAddressEntry</c> function returns successfully, pause for one to three seconds (depending on whether an IPv6 or
		/// IPv4 address is being created) to allow time for the successful completion of the duplication address detection process. Then
		/// call the <c>GetUnicastIpAddressEntry</c> function to retrieve the updated MIB_UNICASTIPADDRESS_ROW structure and examine the
		/// value of the <c>DadState</c> member. If the value of the <c>DadState</c> member is set to <c>IpDadStatePreferred</c>, the IP
		/// address is now usable. If the value of the <c>DadState</c> member is set to <c>IpDadStateTentative</c>, then duplicate address
		/// detection has not yet completed. In this case, call the <c>GetUnicastIpAddressEntry</c> function again every half a second while
		/// the <c>DadState</c> member is still set to <c>IpDadStateTentative</c>. If the value of the <c>DadState</c> member returns with
		/// some value other than <c>IpDadStatePreferred</c> or <c>IpDadStateTentative</c>, duplicate address detection has failed and the IP
		/// address is not usable.
		/// </para>
		/// <para>
		/// The following method describes how to use an appropriate notification function. After the call to the
		/// <c>CreateUnicastIpAddressEntry</c> function returns successfully, call the NotifyUnicastIpAddressChange function to register to
		/// be notified of changes to either IPv6 or IPv4 unicast IP addresses, depending on the type of IP address being created. When a
		/// notification is received for the IP address being created, call the GetUnicastIpAddressEntry function to retrieve the
		/// <c>DadState</c> member. If the value of the <c>DadState</c> member is set to <c>IpDadStatePreferred</c>, the IP address is now
		/// usable. If the value of the <c>DadState</c> member is set to <c>IpDadStateTentative</c>, then duplicate address detection has not
		/// yet completed and the application needs to wait for future notifications. If the value of the <c>DadState</c> member returns with
		/// some value other than <c>IpDadStatePreferred</c> or <c>IpDadStateTentative</c>, duplicate address detection has failed and the IP
		/// address is not usable.
		/// </para>
		/// <para>
		/// If during the duplicate address detection process the media is disconnected and then reconnected, the duplicate address detection
		/// process is restarted. So it is possible for the time to complete the process to increase beyond the typical 1 second value for
		/// IPv6 or 3 second value for IPv4.
		/// </para>
		/// <para>
		/// The <c>CreateUnicastIpAddressEntry</c> function can only be called by a user logged on as a member of the Administrators group.
		/// If <c>CreateUnicastIpAddressEntry</c> is called by a user that is not a member of the Administrators group, the function call
		/// will fail and ERROR_ACCESS_DENIED is returned. This function can also fail because of user account control (UAC) on Windows Vista
		/// and later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example demonstrates how to use the <c>CreateUnicastIpAddressEntry</c> function to add a new unicast IP address
		/// entry on the local computer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-createunicastipaddressentry _NETIOAPI_SUCCESS_
		// NETIOAPI_API CreateUnicastIpAddressEntry( CONST MIB_UNICASTIPADDRESS_ROW *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "8afca4e9-a4c4-4f93-bb4d-25e2eea71ae0")]
		public static extern Win32Error CreateUnicastIpAddressEntry(ref MIB_UNICASTIPADDRESS_ROW Row);

		/// <summary>
		/// <para>The <c>DeleteAnycastIpAddressEntry</c> function deletes an existing anycast IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_ANYCASTIPADDRESS_ROW structure entry for an existing anycast IP address entry to delete from the local computer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_ANYCASTIPADDRESS_ROW pointed to by the Row parameter was not set to a valid unicast IPv4 or IPv6
		/// address, or both the InterfaceLuid or InterfaceIndex members of the MIB_ANYCASTIPADDRESS_ROW pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_ANYCASTIPADDRESS_ROW pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member MIB_ANYCASTIPADDRESS_ROW pointed to by the Row parameter. This error is also returned if no IPv6 stack is
		/// on the local computer and an IPv6 address was specified in the Address member .
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DeleteAnycastIpAddressEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>DeleteAnycastIpAddressEntry</c> function is used to delete an existing MIB_ANYCASTIPADDRESS_ROW structure entry on the
		/// local computer.
		/// </para>
		/// <para>
		/// On input, the <c>Address</c> member in the MIB_ANYCASTIPADDRESS_ROW structure pointed to by the Row parameter must be set to a
		/// valid unicast IPv4 or IPv6 address and family. In addition, at least one of the following members in the
		/// <c>MIB_ANYCASTIPADDRESS_ROW</c> structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>If the function is successful, the existing IP address represented by the Row parameter was deleted.</para>
		/// <para>
		/// The GetAnycastIpAddressTable function can be called to enumerate the anycast IP address entries on a local computer. The
		/// GetAnycastIpAddressEntry function can be called to retrieve a specific existing anycast IP address entry.
		/// </para>
		/// <para>
		/// The <c>DeleteAnycastIpAddressEntry</c> function can only be called by a user logged on as a member of the Administrators group.
		/// If <c>DeleteAnycastIpAddressEntry</c> is called by a user that is not a member of the Administrators group, the function call
		/// will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on
		/// Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of the
		/// Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a
		/// user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-deleteanycastipaddressentry _NETIOAPI_SUCCESS_
		// NETIOAPI_API DeleteAnycastIpAddressEntry( CONST MIB_ANYCASTIPADDRESS_ROW *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "3d6b7c5c-97a8-4a1d-a4cd-7ccf1f585305")]
		public static extern Win32Error DeleteAnycastIpAddressEntry(ref MIB_ANYCASTIPADDRESS_ROW Row);

		/// <summary>
		/// <para>The <c>DeleteIpForwardEntry2</c> function deletes an IP route entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>A pointer to a MIB_IPFORWARD_ROW2 structure entry for an IP route entry. On successful return, this entry will be deleted.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// DestinationPrefix member of the MIB_IPFORWARD_ROW2 pointed to by the Row parameter was not specified, the NextHop member of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Row parameter was not specified, or both the InterfaceLuid or InterfaceIndex members of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPFORWARD_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPFORWARD_ROW2 pointed to by the Row parameter. This error is also returned if no IPv6 stack is
		/// on the local computer and an IPv6 address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DeleteIpForwardEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>DeleteIpForwardEntry2</c> function is used to delete a MIB_IPFORWARD_ROW2 structure entry.</para>
		/// <para>
		/// On input, the <c>DestinationPrefix</c> member in the MIB_IPFORWARD_ROW2 structure pointed to by the Row parameter must be
		/// initialized to a valid IPv4 or IPv6 address prefix and family. On input, the <c>NextHop</c> member in the
		/// <c>MIB_IPFORWARD_ROW2</c> structure pointed to by the Row parameter must be initialized to a valid IPv4 or IPv6 address and
		/// family. In addition, at least one of the following members in the <c>MIB_IPFORWARD_ROW2</c> structure pointed to the Row
		/// parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>On output when the call is successful, <c>DeleteIpForwardEntry2</c> deletes the IP route entry.</para>
		/// <para>
		/// The <c>DeleteIpForwardEntry2</c> function will fail if the <c>DestinationPrefix</c> and <c>NextHop</c> members of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Row parameter do not match an existing IP route entry on the interface specified in the
		/// <c>InterfaceLuid</c> or <c>InterfaceIndex</c> members.
		/// </para>
		/// <para>The GetIpForwardTable2 function can be called to enumerate the IP route entries on a local computer.</para>
		/// <para>
		/// The <c>DeleteIpForwardEntry2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>DeleteIpForwardEntry2</c> is called by a user that is not a member of the Administrators group, the function call will fail
		/// and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista
		/// and later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-deleteipforwardentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// DeleteIpForwardEntry2( CONST MIB_IPFORWARD_ROW2 *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "68d5a5a5-21cf-4337-8a35-7f847f5e2138")]
		public static extern Win32Error DeleteIpForwardEntry2(ref MIB_IPFORWARD_ROW2 Row);

		/// <summary>
		/// <para>The <c>DeleteIpNetEntry2</c> function deletes a neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this entry will be deleted.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid neighbor IPv4 or IPv6 address, or
		/// both the InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter. This error is also returned if no IPv6 stack is on
		/// the local computer and an IPv6 address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DeleteIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>DeleteIpNetEntry2</c> function is used to delete a MIB_IPNET_ROW2 structure entry.</para>
		/// <para>
		/// On input, the <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a
		/// valid neighbor IPv4 or IPv6 address and family. In addition, at least one of the following members in the <c>MIB_IPNET_ROW2</c>
		/// structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>On output when the call is successful, <c>DeleteIpNetEntry2</c> deletes the neighbor IP address.</para>
		/// <para>The GetIpNetTable2 function can be called to enumerate the neighbor IP address entries on a local computer.</para>
		/// <para>
		/// The <c>DeleteIpNetEntry2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>DeleteIpNetEntry2</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista and
		/// later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-deleteipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// DeleteIpNetEntry2( CONST MIB_IPNET_ROW2 *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "85bace04-6c95-4cf2-a212-764de292aed6")]
		public static extern Win32Error DeleteIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// <para>The <c>FlushIpNetTable2</c> function flushes the IP neighbor table on the local computer.</para>
		/// </summary>
		/// <param name="Family">
		/// <para>The address family to flush.</para>
		/// <para>
		/// Possible values for the address family are listed in the Winsock2.h header file. Note that the values for the AF_ address family
		/// and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and possible values for
		/// this member are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h,
		/// and should never be used directly.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c>, <c>AF_INET6</c>, and <c>AF_UNSPEC</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_UNSPEC 0</term>
		/// <term>
		/// The address family is unspecified. When this parameter is specified, this function flushes the neighbor IP address table
		/// containing both IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function flushes the neighbor IP
		/// address table containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function flushes the neighbor IP
		/// address table containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="InterfaceIndex">
		/// <para>
		/// The interface index. If the index is specified, flush the neighbor IP address entries on a specific interface, otherwise flush
		/// the neighbor IP address entries on all the interfaces. To ignore the interface, set this parameter to zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the Family parameter was not specified as AF_INET,
		/// AF_INET6, or AF_UNSPEC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and AF_INET was specified in the
		/// Family parameter. This error is also returned if no IPv6 stack is on the local computer and AF_INET6 was specified in the Family
		/// parameter. This error is also returned on versions of Windows where this function is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>FlushIpNetTable2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>FlushIpNetTable2</c> function flushes or deletes the neighbor IP addresses on a local system. The Family parameter can be
		/// used to limit neighbor IP addresses to delete to a particular IP address family. If neighbor IP addresses for both IPv4 and IPv6
		/// should be deleted, set the Family parameter to <c>AF_UNSPEC</c>. The InterfaceIndex parameter can be used to limit neighbor IP
		/// addresses to delete to a particular interface. If neighbor IP addresses for all interfaces should be deleted, set the
		/// InterfaceIndex parameter to zero.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// The <c>FlushIpNetTable2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>FlushIpNetTable2</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista and
		/// later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-flushipnettable2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// FlushIpNetTable2( ADDRESS_FAMILY Family, NET_IFINDEX InterfaceIndex );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "6ebfca41-acc3-450c-a3c5-881b8c3fca5e")]
		public static extern Win32Error FlushIpNetTable2(ADDRESS_FAMILY Family, uint InterfaceIndex);

		/// <summary>
		/// <para>
		/// The <c>FreeMibTable</c> function frees the buffer allocated by the functions that return tables of network interfaces, addresses,
		/// and routes (GetIfTable2 and GetAnycastIpAddressTable, for example).
		/// </para>
		/// </summary>
		/// <param name="Memory">
		/// <para>A pointer to the buffer to free.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>FreeMibTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>FreeMibTable</c> function is used to free the internal buffers used by various functions to retrieve tables of interfaces,
		/// addresses, and routes. When these tables are no longer needed, then <c>FreeMibTable</c> should be called to release the memory
		/// used by these tables.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-freemibtable VOID NETIOAPI_API_ FreeMibTable( PVOID
		// Memory );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "31c8cdc4-73c7-4e82-8226-c90320046199")]
		public static extern void FreeMibTable(IntPtr Memory);

		/// <summary>
		/// <para>
		/// The <c>GetBestRoute2</c> function retrieves the IP route entry on the local computer for the best route to the specified
		/// destination IP address.
		/// </para>
		/// </summary>
		/// <param name="InterfaceLuid">
		/// <para>The locally unique identifier (LUID) to specify the network interface associated with an IP route entry.</para>
		/// </param>
		/// <param name="InterfaceIndex">
		/// <para>
		/// The local index value to specify the network interface associated with an IP route entry. This index value may change when a
		/// network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>The source IP address. This parameter may be omitted and passed as a <c>NULL</c> pointer.</para>
		/// </param>
		/// <param name="DestinationAddress">
		/// <para>The destination IP address.</para>
		/// </param>
		/// <param name="AddressSortOptions">
		/// <para>A set of options that affect how IP addresses are sorted. This parameter is not currently used.</para>
		/// </param>
		/// <param name="BestRoute">
		/// <para>A pointer to the MIB_IPFORWARD_ROW2 for the best route from the source IP address to the destination IP address.</para>
		/// </param>
		/// <param name="BestSourceAddress">
		/// <para>A pointer to the best source IP address.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the DestinationAddress,
		/// BestSourceAddress, or the BestRoute parameter. This error is also returned if the DestinationAddress parameter does not specify
		/// an IPv4 or IPv6 address and family.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address and family was
		/// specified in the DestinationAddress parameter. This error is also returned if no IPv6 stack is on the local computer and an IPv6
		/// address and family was specified in the DestinationAddress parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetBestRoute2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetBestRoute2</c> function is used to retrieve a MIB_IPFORWARD_ROW2 structure entry for the best route from a source IP
		/// address to a destination IP address.
		/// </para>
		/// <para>
		/// On input, the DestinationAddress parameter must be initialized to a valid IPv4 or IPv6 address and family. On input, the
		/// SourceAddress parameter may be initialized to the preferred IPv4 or IPv6 address and family. In addition, at least one of the
		/// following parameters must be initialized: the InterfaceLuid or InterfaceIndex.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetBestRoute2</c> retrieves and MIB_IPFORWARD_ROW2 structure for the best route from
		/// the source IP address the destination IP address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getbestroute2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetBestRoute2( NET_LUID *InterfaceLuid, NET_IFINDEX InterfaceIndex, CONST SOCKADDR_INET *SourceAddress, CONST SOCKADDR_INET
		// *DestinationAddress, ULONG AddressSortOptions, PMIB_IPFORWARD_ROW2 BestRoute, SOCKADDR_INET *BestSourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "7bc16824-c98f-4cd5-a589-e198b48b637c")]
		public static extern Win32Error GetBestRoute2(ref NET_LUID InterfaceLuid, uint InterfaceIndex, ref SOCKADDR_INET SourceAddress, ref SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

		/// <summary>
		/// <para>
		/// The <c>GetBestRoute2</c> function retrieves the IP route entry on the local computer for the best route to the specified
		/// destination IP address.
		/// </para>
		/// </summary>
		/// <param name="InterfaceLuid">
		/// <para>The locally unique identifier (LUID) to specify the network interface associated with an IP route entry.</para>
		/// </param>
		/// <param name="InterfaceIndex">
		/// <para>
		/// The local index value to specify the network interface associated with an IP route entry. This index value may change when a
		/// network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>The source IP address. This parameter may be omitted and passed as a <c>NULL</c> pointer.</para>
		/// </param>
		/// <param name="DestinationAddress">
		/// <para>The destination IP address.</para>
		/// </param>
		/// <param name="AddressSortOptions">
		/// <para>A set of options that affect how IP addresses are sorted. This parameter is not currently used.</para>
		/// </param>
		/// <param name="BestRoute">
		/// <para>A pointer to the MIB_IPFORWARD_ROW2 for the best route from the source IP address to the destination IP address.</para>
		/// </param>
		/// <param name="BestSourceAddress">
		/// <para>A pointer to the best source IP address.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the DestinationAddress,
		/// BestSourceAddress, or the BestRoute parameter. This error is also returned if the DestinationAddress parameter does not specify
		/// an IPv4 or IPv6 address and family.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address and family was
		/// specified in the DestinationAddress parameter. This error is also returned if no IPv6 stack is on the local computer and an IPv6
		/// address and family was specified in the DestinationAddress parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetBestRoute2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetBestRoute2</c> function is used to retrieve a MIB_IPFORWARD_ROW2 structure entry for the best route from a source IP
		/// address to a destination IP address.
		/// </para>
		/// <para>
		/// On input, the DestinationAddress parameter must be initialized to a valid IPv4 or IPv6 address and family. On input, the
		/// SourceAddress parameter may be initialized to the preferred IPv4 or IPv6 address and family. In addition, at least one of the
		/// following parameters must be initialized: the InterfaceLuid or InterfaceIndex.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetBestRoute2</c> retrieves and MIB_IPFORWARD_ROW2 structure for the best route from
		/// the source IP address the destination IP address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getbestroute2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetBestRoute2( NET_LUID *InterfaceLuid, NET_IFINDEX InterfaceIndex, CONST SOCKADDR_INET *SourceAddress, CONST SOCKADDR_INET
		// *DestinationAddress, ULONG AddressSortOptions, PMIB_IPFORWARD_ROW2 BestRoute, SOCKADDR_INET *BestSourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "7bc16824-c98f-4cd5-a589-e198b48b637c")]
		public static extern Win32Error GetBestRoute2(IntPtr InterfaceLuid, uint InterfaceIndex, ref SOCKADDR_INET SourceAddress, ref SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

		/// <summary>
		/// <para>
		/// The <c>GetBestRoute2</c> function retrieves the IP route entry on the local computer for the best route to the specified
		/// destination IP address.
		/// </para>
		/// </summary>
		/// <param name="InterfaceLuid">
		/// <para>The locally unique identifier (LUID) to specify the network interface associated with an IP route entry.</para>
		/// </param>
		/// <param name="InterfaceIndex">
		/// <para>
		/// The local index value to specify the network interface associated with an IP route entry. This index value may change when a
		/// network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>The source IP address. This parameter may be omitted and passed as a <c>NULL</c> pointer.</para>
		/// </param>
		/// <param name="DestinationAddress">
		/// <para>The destination IP address.</para>
		/// </param>
		/// <param name="AddressSortOptions">
		/// <para>A set of options that affect how IP addresses are sorted. This parameter is not currently used.</para>
		/// </param>
		/// <param name="BestRoute">
		/// <para>A pointer to the MIB_IPFORWARD_ROW2 for the best route from the source IP address to the destination IP address.</para>
		/// </param>
		/// <param name="BestSourceAddress">
		/// <para>A pointer to the best source IP address.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the DestinationAddress,
		/// BestSourceAddress, or the BestRoute parameter. This error is also returned if the DestinationAddress parameter does not specify
		/// an IPv4 or IPv6 address and family.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address and family was
		/// specified in the DestinationAddress parameter. This error is also returned if no IPv6 stack is on the local computer and an IPv6
		/// address and family was specified in the DestinationAddress parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetBestRoute2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetBestRoute2</c> function is used to retrieve a MIB_IPFORWARD_ROW2 structure entry for the best route from a source IP
		/// address to a destination IP address.
		/// </para>
		/// <para>
		/// On input, the DestinationAddress parameter must be initialized to a valid IPv4 or IPv6 address and family. On input, the
		/// SourceAddress parameter may be initialized to the preferred IPv4 or IPv6 address and family. In addition, at least one of the
		/// following parameters must be initialized: the InterfaceLuid or InterfaceIndex.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetBestRoute2</c> retrieves and MIB_IPFORWARD_ROW2 structure for the best route from
		/// the source IP address the destination IP address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getbestroute2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetBestRoute2( NET_LUID *InterfaceLuid, NET_IFINDEX InterfaceIndex, CONST SOCKADDR_INET *SourceAddress, CONST SOCKADDR_INET
		// *DestinationAddress, ULONG AddressSortOptions, PMIB_IPFORWARD_ROW2 BestRoute, SOCKADDR_INET *BestSourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "7bc16824-c98f-4cd5-a589-e198b48b637c")]
		public static extern Win32Error GetBestRoute2(IntPtr InterfaceLuid, uint InterfaceIndex, IntPtr SourceAddress, ref SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

		/// <summary>
		/// <para>The <c>GetIfEntry2</c> function retrieves information for the specified interface on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IF_ROW2 structure that, on successful return, receives information for an interface on the local computer. On
		/// input, the <c>InterfaceLuid</c> or the <c>InterfaceIndex</c> member of the <c>MIB_IF_ROW2</c> must be set to the interface for
		/// which to retrieve information.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned if the network interface LUID or interface index specified by
		/// the InterfaceLuid or InterfaceIndex member of the MIB_IF_ROW2 pointed to by the Row parameter was not a value on the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL parameter is passed in the Row parameter. This
		/// error is also returned if the both the InterfaceLuid and InterfaceIndex member of the MIB_IF_ROW2 pointed to by the Row parameter
		/// are unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIfEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// On input, at least one of the following members in the MIB_IF_ROW2 structure passed in the Row parameter must be initialized:
		/// <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>On output, the remaining fields of the MIB_IF_ROW2 structure pointed to by the Row parameter are filled in.</para>
		/// <para>Note that the Netioapi.h header file is automatically included in IpHlpApi.h header file, and should never be used directly.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves a interface entry specified on the command line and prints some values from the retrieved
		/// MIB_IF_ROW2 structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getifentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API GetIfEntry2(
		// PMIB_IF_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "da787dae-5e89-4bf2-a9b6-90e727995414")]
		public static extern Win32Error GetIfEntry2(ref MIB_IF_ROW2 Row);

		/// <summary>
		/// <para>
		/// The <c>GetIfEntry2Ex</c> function retrieves the specified level of information for the specified interface on the local computer.
		/// </para>
		/// </summary>
		/// <param name="Level">
		/// <para>
		/// The level of interface information to retrieve. This parameter can be one of the values from the <c>MIB_IF_ENTRY_LEVEL</c>
		/// enumeration type defined in the Netioapi.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MibIfEntryNormal 0</term>
		/// <term>
		/// The values of statistics and state returned in members of the MIB_IF_ROW2 structure pointed to by the Row parameter are returned
		/// from the top of the filter stack.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MibIfEntryNormalWithoutStatistics 2</term>
		/// <term>
		/// The values of state (without statistics) returned in members of the MIB_IF_ROW2 structure pointed to by the Row parameter are
		/// returned from the top of the filter stack.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IF_ROW2 structure that, on successful return, receives information for an interface on the local computer. On
		/// input, the <c>InterfaceLuid</c> or the <c>InterfaceIndex</c> member of the <c>MIB_IF_ROW2</c> must be set to the interface for
		/// which to retrieve information.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned if the network interface LUID or interface index specified by
		/// the InterfaceLuid or InterfaceIndex member of the MIB_IF_ROW2 pointed to by the Row parameter was not a value on the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL parameter is passed in the Row parameter. This
		/// error is also returned if the both the InterfaceLuid and InterfaceIndex member of the MIB_IF_ROW2 pointed to by the Row parameter
		/// are unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIfEntry2Ex</c> function retrieves information for a specified interface on a local system and returns this information
		/// in a pointer to a MIB_IF_ROW2 structure. <c>GetIfEntry2Ex</c> is an enhanced version of the GetIfEntry2 function that allows
		/// selecting the level of interface information to retrieve.
		/// </para>
		/// <para>
		/// On input, at least one of the following members in the MIB_IF_ROW2 structure passed in the Row parameter must be initialized:
		/// <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>On output, the remaining fields of the MIB_IF_ROW2 structure pointed to by the Row parameter are filled in.</para>
		/// <para>Note that the Netioapi.h header file is automatically included in IpHlpApi.h header file, and should never be used directly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getifentry2ex _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIfEntry2Ex( MIB_IF_ENTRY_LEVEL Level, PMIB_IF_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "98C25986-1B38-4878-B578-3D30394F49E4")]
		public static extern Win32Error GetIfEntry2Ex(MIB_IF_ENTRY_LEVEL Level, ref MIB_IF_ROW2 Row);

		/// <summary>
		/// <para>The <c>GetIfTable2</c> function retrieves the MIB-II interface table.</para>
		/// </summary>
		/// <param name="Table">
		/// <para>A pointer to a buffer that receives the table of interfaces in a MIB_IF_TABLE2 structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory resources are available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIfTable2</c> function enumerates the logical and physical interfaces on a local system and returns this information in
		/// a MIB_IF_TABLE2 structure. <c>GetIfTable2</c> is an enhanced version of the <c>GetIfTable</c> function.
		/// </para>
		/// <para>
		/// A similar GetIfTable2Ex function can be used to specify the level of interfaces to return. Calling the <c>GetIfTable2Ex</c>
		/// function with the Level parameter set to <c>MibIfTableNormal</c> retrieves the same results as calling the <c>GetIfTable2</c> function.
		/// </para>
		/// <para>
		/// Interfaces are returned in a MIB_IF_TABLE2 structure in the buffer pointed to by the Table parameter. The <c>MIB_IF_TABLE2</c>
		/// structure contains an interface count and an array of MIB_IF_ROW2 structures for each interface. Memory is allocated by the
		/// <c>GetIfTable2</c> function for the <c>MIB_IF_TABLE2</c> structure and the <c>MIB_IF_ROW2</c> entries in this structure. When
		/// these returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>
		/// Note that the returned MIB_IF_TABLE2 structure pointed to by the Table parameter may contain padding for alignment between the
		/// <c>NumEntries</c> member and the first MIB_IF_ROW2 array entry in the <c>Table</c> member of the <c>MIB_IF_TABLE2</c> structure.
		/// Padding for alignment may also be present between the <c>MIB_IF_ROW2</c> array entries. Any access to a <c>MIB_IF_ROW2</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getiftable2 _NETIOAPI_SUCCESS_ NETIOAPI_API GetIfTable2(
		// PMIB_IF_TABLE2 *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "0153c41c-b02b-4832-87b3-88dc3a9f4ff1")]
		public static extern Win32Error GetIfTable2(out MIB_IF_TABLE2 pIfTable);

		/// <summary>
		/// <para>The <c>GetIfTable2Ex</c> function retrieves the MIB-II interface table.</para>
		/// </summary>
		/// <param name="Level">
		/// <para>
		/// The level of interface information to retrieve. This parameter can be one of the values from the <c>MIB_IF_TABLE_LEVEL</c>
		/// enumeration type defined in the Netioapi.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MibIfTableNormal</term>
		/// <term>
		/// The values of statistics and state returned in members of the MIB_IF_ROW2 structure in the MIB_IF_TABLE2 structure pointed to by
		/// the Table parameter are returned from the top of the filter stack when this parameter is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MibIfTableRaw</term>
		/// <term>
		/// The values of statistics and state returned in members of the MIB_IF_ROW2 structure in the MIB_IF_TABLE2 structure pointed to by
		/// the Table parameter are returned directly for the interface being queried.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>A pointer to a buffer that receives the table of interfaces in a MIB_IF_TABLE2 structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function. This error is returned if an illegal value was passed in the Level parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory resources are available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIfTable2Ex</c> function enumerates the logical and physical interfaces on a local system and returns this information
		/// in a MIB_IF_TABLE2 structure. <c>GetIfTable2Ex</c> is an enhanced version of the <c>GetIfTable</c> function that allows selecting
		/// the level of interface information to retrieve.
		/// </para>
		/// <para>
		/// A similar GetIfTable2 function can also be used to retrieve interfaces. but does not allow specifying the level of interfaces to
		/// return. Calling the <c>GetIfTable2Ex</c> function with the Level parameter set to <c>MibIfTableNormal</c> retrieves the same
		/// results as calling the <c>GetIfTable2</c> function.
		/// </para>
		/// <para>
		/// Interfaces are returned in a MIB_IF_TABLE2 structure in the buffer pointed to by the Table parameter. The <c>MIB_IF_TABLE2</c>
		/// structure contains an interface count and an array of MIB_IF_ROW2 structures for each interface. Memory is allocated by the
		/// GetIfTable2 function for the <c>MIB_IF_TABLE2</c> structure and the <c>MIB_IF_ROW2</c> entries in this structure. When these
		/// returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>
		/// All interfaces including NDIS intermediate driver interfaces and NDIS filter driver interfaces are returned for either of the
		/// possible values for the Level parameter. The setting for the Level parameter affects how statistics and state members of the
		/// MIB_IF_ROW2 structure in the MIB_IF_TABLE2 structure pointed to by the Table parameter for the interface are returned. For
		/// example, a network interface card (NIC) will have a NDIS miniport driver. An NDIS intermediate driver can be installed to
		/// interface between upper-level protocol drivers and NDIS miniport drivers. An NDIS filter driver (LWF) can be attached on top of
		/// the NDIS intermediate driver. Assume that the NIC reports the MediaConnectState member of the <c>MIB_IF_ROW2</c> structure as
		/// <c>MediaConnectStateConnected</c> but NDIS filter driver modifies the state and reports the state as
		/// <c>MediaConnectStateDisconnected</c>. When the interface information is queried with Level parameter set to
		/// <c>MibIfTableNormal</c>, the state at the top of the filter stack, that is <c>MediaConnectStateDisconnected</c> is reported. When
		/// the interface is queried with the Level parameter set to <c>MibIfTableRaw</c>, the state at the interface level directly, that is
		/// <c>MediaConnectStateConnected</c> is returned.
		/// </para>
		/// <para>
		/// Note that the returned MIB_IF_TABLE2 structure pointed to by the Table parameter may contain padding for alignment between the
		/// <c>NumEntries</c> member and the first MIB_IF_ROW2 array entry in the <c>Table</c> member of the <c>MIB_IF_TABLE2</c> structure.
		/// Padding for alignment may also be present between the <c>MIB_IF_ROW2</c> array entries. Any access to a <c>MIB_IF_ROW2</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getiftable2ex _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIfTable2Ex( MIB_IF_TABLE_LEVEL Level, PMIB_IF_TABLE2 *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "d8663894-50b1-4ca2-a1f4-6ca0970795a7")]
		public static extern Win32Error GetIfTable2Ex(MIB_IF_TABLE_LEVEL Level, out MIB_IF_TABLE2 pIfTable);

		/// <summary>
		/// <para>The <c>GetIpNetEntry2</c> function retrieves information for a neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this structure will be
		/// updated with the properties for neighbor IP address.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned if the network interface LUID or interface index specified by
		/// the InterfaceLuid or InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not a value on the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid neighbor IPv4 or IPv6 address, or
		/// both the InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned if the network interface specified by the InterfaceLuid or InterfaceIndex member of the
		/// MIB_IPNET_ROW2 structure pointed to by the Row parameter does not match the neighbor IP address and address family specified in
		/// the Address member in the MIB_IPNET_ROW2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 structure pointed to by the Row parameter. This error is also returned if no IPv6
		/// stack is on the local computer and an IPv6 address was specified in the Address member of the MIB_IPNET_ROW2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>GetIpNetEntry2</c> function is used to retrieve a MIB_IPNET_ROW2 structure entry.</para>
		/// <para>
		/// On input, the <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a
		/// valid neighbor IPv4 or IPv6 address and family. In addition, at least one of the following members in the <c>MIB_IPNET_ROW2</c>
		/// structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetIpNetEntry2</c> retrieves the other properties for the neighbor IP address and fills
		/// out the MIB_IPNET_ROW2 structure pointed to by the Row parameter.
		/// </para>
		/// <para>The GetIpNetTable2 function can be called to enumerate the neighbor IP address entries on a local computer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpNetEntry2( PMIB_IPNET_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "c77e01da-2d5a-4c74-b581-62fa6ee52c9e")]
		public static extern Win32Error GetIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// <para>The <c>GetIpNetTable2</c> function retrieves the IP neighbor table on the local computer.</para>
		/// </summary>
		/// <param name="Family">
		/// <para>The address family to retrieve.</para>
		/// <para>
		/// Possible values for the address family are listed in the Winsock2.h header file. Note that the values for the AF_ address family
		/// and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and possible values for
		/// this member are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h,
		/// and should never be used directly.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c>, <c>AF_INET6</c>, and <c>AF_UNSPEC</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_UNSPEC 0</term>
		/// <term>
		/// The address family is unspecified. When this parameter is specified, this function returns the neighbor IP address table
		/// containing both IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns the neighbor IP
		/// address table containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns the neighbor IP
		/// address table containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>A pointer to a MIB_IPNET_TABLE2 structure that contains a table of neighbor IP address entries on the local computer.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR or ERROR_NOT_FOUND.</para>
		/// <para>If the function fails or returns no data, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Table parameter or the
		/// Family parameter was not specified as AF_INET, AF_INET6, or AF_UNSPEC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory resources are available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// No neighbor IP address entries as specified in the Family parameter were found. This return value indicates that the call to the
		/// GetIpNetTable2 function succeeded, but there was no data to return. This can occur when AF_INET is specified in the Family
		/// parameter and there are no ARP entries to return.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and AF_INET was specified in the
		/// Family parameter. This error is also returned if no IPv6 stack is on the local computer and AF_INET6 was specified in the Family
		/// parameter. This error is also returned on versions of Windows where this function is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpNetTable2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetIpNetTable2</c> function enumerates the neighbor IP addresses on a local system and returns this information in a
		/// MIB_IPNET_TABLE2 structure.
		/// </para>
		/// <para>
		/// The neighbor IP address entries are returned in a MIB_IPNET_TABLE2 structure in the buffer pointed to by the Table parameter. The
		/// <c>MIB_IPNET_TABLE2</c> structure contains a neighbor IP address entry count and an array of MIB_IPNET_ROW2 structures for each
		/// neighbor IP address entry. When these returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// Note that the returned MIB_IPNET_TABLE2 structure pointed to by the Table parameter may contain padding for alignment between the
		/// <c>NumEntries</c> member and the first MIB_IPNET_ROW2 array entry in the <c>Table</c> member of the <c>MIB_IPNET_TABLE2</c>
		/// structure. Padding for alignment may also be present between the <c>MIB_IPNET_ROW2</c> array entries. Any access to a
		/// <c>MIB_IPNET_ROW2</c> array entry should assume padding may exist.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the IP neighbor table, then prints the values for IP neighbor row entries in the table.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getipnettable2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpNetTable2( ADDRESS_FAMILY Family, PMIB_IPNET_TABLE2 *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "6c45d735-9a07-41ca-8d8a-919f32c98a3c")]
		public static extern Win32Error GetIpNetTable2(ADDRESS_FAMILY Family, out MIB_IPNET_TABLE2 Table);

		/// <summary>
		/// <para>The <c>ResolveIpNetEntry2</c> function resolves the physical address for a neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this structure will be
		/// updated with the properties for neighbor IP address.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>
		/// A pointer to a an optional source IP address used to select the interface to send the requests on for the neighbor IP address entry.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_NET_NAME</term>
		/// <term>The network name cannot be found. This error is returned if the network with the neighbor IP address is unreachable.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid IPv4 or IPv6 address, or both the
		/// InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the Row parameter were unspecified. This error is
		/// also returned if a loopback address was passed in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter or no IPv6 stack is on the local computer and an IPv6
		/// address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ResolveIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>ResolveIpNetEntry2</c> function is used to resolve the physical address for a neighbor IP address entry on a local
		/// computer. This function flushes any existing neighbor entry that matches the IP address on the interface and then resolves the
		/// physical address (MAC) address by sending ARP requests for an IPv4 address or neighbor solicitation requests for an IPv6 address.
		/// If the SourceAddress parameter is specified, the <c>ResolveIpNetEntry2</c> function will select the interface with this source IP
		/// address to send the requests on. If the SourceAddress parameter is not specified (NULL was passed in this parameter), the
		/// <c>ResolveIpNetEntry2</c> function will automatically select the best interface to send the requests on.
		/// </para>
		/// <para>
		/// The <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a valid IPv4 or
		/// IPv6 address and family. In addition, at least one of the following members in the <c>MIB_IPNET_ROW2</c> structure pointed to the
		/// Row parameter must be initialized to the interface: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// If the IP address passed in the <c>Address</c> member of the MIB_IPNET_ROW2 pointed to by the Row parameter is a duplicate of an
		/// existing neighbor IP address on the interface, the <c>ResolveIpNetEntry2</c> function will flush the existing entry before
		/// resolving the IP address.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>ResolveIpNetEntry2</c> retrieves the other properties for the neighbor IP address and
		/// fills out the MIB_IPNET_ROW2 structure pointed to by the Row parameter. The <c>PhysicalAddress</c> and
		/// <c>PhysicalAddressLength</c> members in the <c>MIB_IPNET_ROW2</c> structure pointed to by the Row parameter will be initialized
		/// to a valid physical address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-resolveipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// ResolveIpNetEntry2( PMIB_IPNET_ROW2 Row, CONST SOCKADDR_INET *SourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "37f9dc58-362d-413e-a593-4dda52fb7d8b")]
		public static extern Win32Error ResolveIpNetEntry2(ref MIB_IPNET_ROW2 Row, IntPtr SourceAddress = default(IntPtr));

		/// <summary>
		/// <para>The <c>ResolveIpNetEntry2</c> function resolves the physical address for a neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this structure will be
		/// updated with the properties for neighbor IP address.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>
		/// A pointer to a an optional source IP address used to select the interface to send the requests on for the neighbor IP address entry.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_NET_NAME</term>
		/// <term>The network name cannot be found. This error is returned if the network with the neighbor IP address is unreachable.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid IPv4 or IPv6 address, or both the
		/// InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the Row parameter were unspecified. This error is
		/// also returned if a loopback address was passed in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter or no IPv6 stack is on the local computer and an IPv6
		/// address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ResolveIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>ResolveIpNetEntry2</c> function is used to resolve the physical address for a neighbor IP address entry on a local
		/// computer. This function flushes any existing neighbor entry that matches the IP address on the interface and then resolves the
		/// physical address (MAC) address by sending ARP requests for an IPv4 address or neighbor solicitation requests for an IPv6 address.
		/// If the SourceAddress parameter is specified, the <c>ResolveIpNetEntry2</c> function will select the interface with this source IP
		/// address to send the requests on. If the SourceAddress parameter is not specified (NULL was passed in this parameter), the
		/// <c>ResolveIpNetEntry2</c> function will automatically select the best interface to send the requests on.
		/// </para>
		/// <para>
		/// The <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a valid IPv4 or
		/// IPv6 address and family. In addition, at least one of the following members in the <c>MIB_IPNET_ROW2</c> structure pointed to the
		/// Row parameter must be initialized to the interface: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// If the IP address passed in the <c>Address</c> member of the MIB_IPNET_ROW2 pointed to by the Row parameter is a duplicate of an
		/// existing neighbor IP address on the interface, the <c>ResolveIpNetEntry2</c> function will flush the existing entry before
		/// resolving the IP address.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>ResolveIpNetEntry2</c> retrieves the other properties for the neighbor IP address and
		/// fills out the MIB_IPNET_ROW2 structure pointed to by the Row parameter. The <c>PhysicalAddress</c> and
		/// <c>PhysicalAddressLength</c> members in the <c>MIB_IPNET_ROW2</c> structure pointed to by the Row parameter will be initialized
		/// to a valid physical address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-resolveipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// ResolveIpNetEntry2( PMIB_IPNET_ROW2 Row, CONST SOCKADDR_INET *SourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "37f9dc58-362d-413e-a593-4dda52fb7d8b")]
		public static extern Win32Error ResolveIpNetEntry2(ref MIB_IPNET_ROW2 Row, ref SOCKADDR_INET SourceAddress);

		/// <summary>
		/// <para>The <c>SetIpNetEntry2</c> function sets the physical address of an existing neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid unicast, anycast, or multicast IPv4
		/// or IPv6 address, the PhysicalAddress and PhysicalAddressLength members of the MIB_IPNET_ROW2 pointed to by the Row parameter were
		/// not set to a valid physical address, or both the InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the
		/// Row parameter were unspecified. This error is also returned if a loopback address was passed in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter or no IPv6 stack is on the local computer and an IPv6
		/// address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SetIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>SetIpNetEntry2</c> function is used to set the physical address for an existing neighbor IP address entry on a local computer.
		/// </para>
		/// <para>
		/// The <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a valid unicast,
		/// anycast, or multicast IPv4 or IPv6 address and family. The <c>PhysicalAddress</c> and <c>PhysicalAddressLength</c> members in the
		/// <c>MIB_IPNET_ROW2</c> structure pointed to by the Row parameter must be initialized to a valid physical address. In addition, at
		/// least one of the following members in the <c>MIB_IPNET_ROW2</c> structure pointed to the Row parameter must be initialized to the
		/// interface: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// The <c>SetIpNetEntry2</c> function will fail if the IP address passed in the <c>Address</c> member of the MIB_IPNET_ROW2 pointed
		/// to by the Row parameter is not an existing neighbor IP address on the interface specified.
		/// </para>
		/// <para>
		/// The <c>SetIpNetEntry2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetIpNetEntry2</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>SetIpNetEntry2</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an
		/// application that contains this function is executed by a user logged on as a member of the Administrators group other than the
		/// built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-setipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// SetIpNetEntry2( PMIB_IPNET_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "4f423700-f721-44a9-ade3-ea5b5b86e394")]
		public static extern Win32Error SetIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// <para>The <c>MIB_ANYCASTIPADDRESS_ROW</c> structure stores information about an anycast IP address.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_ANYCASTIPADDRESS_ROW</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// Note that the Netioapi.h header file is automatically included in the Iphlpapi.h header file. The Netioapi.h header file should
		/// never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_mib_anycastipaddress_row typedef struct
		// _MIB_ANYCASTIPADDRESS_ROW { SOCKADDR_INET Address; NET_LUID InterfaceLuid; NET_IFINDEX InterfaceIndex; SCOPE_ID ScopeId; }
		// MIB_ANYCASTIPADDRESS_ROW, *PMIB_ANYCASTIPADDRESS_ROW;
		[PInvokeData("netioapi.h", MSDNShortId = "bdbe43b8-88aa-48af-aa6b-c88c4e8e404e")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_ANYCASTIPADDRESS_ROW
		{
			/// <summary>
			/// <para>The anycast IP address. This member can be an IPv6 address or an IPv4 address.</para>
			/// </summary>
			public SOCKADDR_INET Address;

			/// <summary>
			/// <para>The locally unique identifier (LUID) for the network interface associated with this IP address.</para>
			/// </summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// <para>
			/// The local index value for the network interface associated with this IP address. This index value may change when a network
			/// adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </para>
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// <para>
			/// The scope ID of the anycast IP address. This member is applicable only to an IPv6 address. This member cannot be set. It is
			/// automatically determined by the interface on which the address was added.
			/// </para>
			/// </summary>
			public SCOPE_ID ScopeId;
		}

		/// <summary>
		/// <para>The <c>MIB_IF_ROW2</c> structure stores information about a particular interface.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_IF_ROW2</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The values for the <c>Type</c> field are defined in the Ipifcons.h header file. Only the possible values listed in the
		/// description of the <c>Type</c> member are currently supported.
		/// </para>
		/// <para>
		/// Note that the Netioapi.h header file is automatically included in the Iphlpapi.h header file. The Netioapi.h header file should
		/// never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_mib_if_row2 typedef struct _MIB_IF_ROW2 { NET_LUID
		// InterfaceLuid; NET_IFINDEX InterfaceIndex; GUID InterfaceGuid; WCHAR Alias[IF_MAX_STRING_SIZE + 1]; WCHAR
		// Description[IF_MAX_STRING_SIZE + 1]; ULONG PhysicalAddressLength; UCHAR PhysicalAddress[IF_MAX_PHYS_ADDRESS_LENGTH]; UCHAR
		// PermanentPhysicalAddress[IF_MAX_PHYS_ADDRESS_LENGTH]; ULONG Mtu; IFTYPE Type; TUNNEL_TYPE TunnelType; NDIS_MEDIUM MediaType;
		// NDIS_PHYSICAL_MEDIUM PhysicalMediumType; NET_IF_ACCESS_TYPE AccessType; NET_IF_DIRECTION_TYPE DirectionType; struct { BOOLEAN
		// HardwareInterface : 1; BOOLEAN FilterInterface : 1; BOOLEAN ConnectorPresent : 1; BOOLEAN NotAuthenticated : 1; BOOLEAN
		// NotMediaConnected : 1; BOOLEAN Paused : 1; BOOLEAN LowPower : 1; BOOLEAN EndPointInterface : 1; } InterfaceAndOperStatusFlags;
		// IF_OPER_STATUS OperStatus; NET_IF_ADMIN_STATUS AdminStatus; NET_IF_MEDIA_CONNECT_STATE MediaConnectState; NET_IF_NETWORK_GUID
		// NetworkGuid; NET_IF_CONNECTION_TYPE ConnectionType; ULONG64 TransmitLinkSpeed; ULONG64 ReceiveLinkSpeed; ULONG64 InOctets; ULONG64
		// InUcastPkts; ULONG64 InNUcastPkts; ULONG64 InDiscards; ULONG64 InErrors; ULONG64 InUnknownProtos; ULONG64 InUcastOctets; ULONG64
		// InMulticastOctets; ULONG64 InBroadcastOctets; ULONG64 OutOctets; ULONG64 OutUcastPkts; ULONG64 OutNUcastPkts; ULONG64 OutDiscards;
		// ULONG64 OutErrors; ULONG64 OutUcastOctets; ULONG64 OutMulticastOctets; ULONG64 OutBroadcastOctets; ULONG64 OutQLen; } MIB_IF_ROW2, *PMIB_IF_ROW2;
		[PInvokeData("netioapi.h", MSDNShortId = "e8bb79f9-e7e9-470b-8883-36d08061661b")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct MIB_IF_ROW2
		{
			/// <summary>The locally unique identifier (LUID) for the network interface.</summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// The index that identifies the network interface. This index value may change when a network adapter is disabled and then
			/// enabled, and should not be considered persistent.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>The GUID for the network interface.</summary>
			public Guid InterfaceGuid;

			/// <summary>A NULL-terminated Unicode string that contains the alias name of the network interface.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = IF_MAX_STRING_SIZE + 1)]
			public string Alias;

			/// <summary>A NULL-terminated Unicode string that contains a description of the network interface.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = IF_MAX_STRING_SIZE + 1)]
			public string Description;

			/// <summary>The length, in bytes, of the physical hardware address specified by the PhysicalAddress member.</summary>
			public uint physicalAddressLength;

			/// <summary>The physical hardware address of the adapter for this network interface.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = IF_MAX_PHYS_ADDRESS_LENGTH)]
			public byte[] PhysicalAddress;

			/// <summary>The permanent physical hardware address of the adapter for this network interface.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = IF_MAX_PHYS_ADDRESS_LENGTH)]
			public byte[] PermanentPhysicalAddress;

			/// <summary>The maximum transmission unit (MTU) size, in bytes, for this network interface.</summary>
			public uint Mtu;

			/// <summary>
			/// The interface type as defined by the Internet Assigned Names Authority (IANA). For more information, see
			/// http://www.iana.org/assignments/ianaiftype-mib. Possible values for the interface type are listed in the Ipifcons.h header file.
			/// </summary>
			public IFTYPE Type;

			/// <summary>
			/// The encapsulation method used by a tunnel if the Type member is IF_TYPE_TUNNEL. The tunnel type is defined by the Internet
			/// Assigned Names Authority (IANA). For more information, see http://www.iana.org/assignments/ianaiftype-mib. This member can be
			/// one of the values from the TUNNEL_TYPE enumeration type defined in the Ifdef.h header file.
			/// </summary>
			public TUNNEL_TYPE TunnelType;

			/// <summary>
			/// The NDIS media type for the interface. This member can be one of the values from the NDIS_MEDIUM enumeration type defined in
			/// the Ntddndis.h header file.
			/// </summary>
			public NDIS_MEDIUM MediaType;

			/// <summary>
			/// The NDIS physical medium type. This member can be one of the values from the NDIS_PHYSICAL_MEDIUM enumeration type defined in
			/// the Ntddndis.h header file.
			/// </summary>
			public NDIS_PHYSICAL_MEDIUM PhysicalMediumType;

			/// <summary>
			/// The interface access type. This member can be one of the values from the NET_IF_ACCESS_TYPE enumeration type defined in the
			/// Ifdef.h header file.
			/// </summary>
			public NET_IF_ACCESS_TYPE AccessType;

			/// <summary>
			/// The interface direction type. This member can be one of the values from the NET_IF_DIRECTION_TYPE enumeration type defined in
			/// the Ifdef.h header file.
			/// </summary>
			public NET_IF_DIRECTION_TYPE DirectionType;

			/// <summary>
			/// A set of flags that provide information about the interface. These flags are combined with a bitwise OR operation. If none of
			/// the flags applies, then this member is set to zero.
			/// </summary>
			public InterfaceAndOperStatusFlags InterfaceAndOperStatusFlags;

			/// <summary>
			/// The operational status for the interface as defined in RFC 2863 as IfOperStatus. For more information, see
			/// http://www.ietf.org/rfc/rfc2863.txt. This member can be one of the values from the IF_OPER_STATUS enumeration type defined in
			/// the Ifdef.h header file.
			/// </summary>
			public IF_OPER_STATUS OperStatus;

			/// <summary>
			/// The administrative status for the interface as defined in RFC 2863. For more information, see
			/// http://www.ietf.org/rfc/rfc2863.txt. This member can be one of the values from the NET_IF_ADMIN_STATUS enumeration type
			/// defined in the Ifdef.h header file.
			/// </summary>
			public NET_IF_ADMIN_STATUS AdminStatus;

			/// <summary>
			/// The connection state of the interface. This member can be one of the values from the NET_IF_MEDIA_CONNECT_STATE enumeration
			/// type defined in the Ifdef.h header file.
			/// </summary>
			public NET_IF_MEDIA_CONNECT_STATE MediaConnectState;

			/// <summary>The GUID that is associated with the network that the interface belongs to.</summary>
			public Guid NetworkGuid;

			/// <summary>
			/// The NDIS network interface connection type. This member can be one of the values from the NET_IF_CONNECTION_TYPE enumeration
			/// type defined in the Ifdef.h header file.
			/// </summary>
			public NET_IF_CONNECTION_TYPE ConnectionType;

			/// <summary>The speed in bits per second of the transmit link.</summary>
			public ulong TransmitLinkSpeed;

			/// <summary>The speed in bits per second of the receive link.</summary>
			public ulong ReceiveLinkSpeed;

			/// <summary>
			/// The number of octets of data received without errors through this interface. This value includes octets in unicast,
			/// broadcast, and multicast packets.
			/// </summary>
			public ulong InOctets;

			/// <summary>The number of unicast packets received without errors through this interface.</summary>
			public ulong InUcastPkts;

			/// <summary>
			/// The number of non-unicast packets received without errors through this interface. This value includes broadcast and multicast packets.
			/// </summary>
			public ulong InNUcastPkts;

			/// <summary>
			/// The number of inbound packets which were chosen to be discarded even though no errors were detected to prevent the packets
			/// from being deliverable to a higher-layer protocol.
			/// </summary>
			public ulong InDiscards;

			/// <summary>The number of incoming packets that were discarded because of errors.</summary>
			public ulong InErrors;

			/// <summary>The number of incoming packets that were discarded because the protocol was unknown.</summary>
			public ulong InUnknownProtos;

			/// <summary>The number of octets of data received without errors in unicast packets through this interface.</summary>
			public ulong InUcastOctets;

			/// <summary>The number of octets of data received without errors in multicast packets through this interface.</summary>
			public ulong InMulticastOctets;

			/// <summary>The number of octets of data received without errors in broadcast packets through this interface.</summary>
			public ulong InBroadcastOctets;

			/// <summary>
			/// The number of octets of data transmitted without errors through this interface. This value includes octets in unicast,
			/// broadcast, and multicast packets.
			/// </summary>
			public ulong OutOctets;

			/// <summary>The number of unicast packets transmitted without errors through this interface.</summary>
			public ulong OutUcastPkts;

			/// <summary>
			/// The number of non-unicast packets transmitted without errors through this interface. This value includes broadcast and
			/// multicast packets.
			/// </summary>
			public ulong OutNUcastPkts;

			/// <summary>The number of outgoing packets that were discarded even though they did not have errors.</summary>
			public ulong OutDiscards;

			/// <summary>The number of outgoing packets that were discarded because of errors.</summary>
			public ulong OutErrors;

			/// <summary>The number of octets of data transmitted without errors in unicast packets through this interface.</summary>
			public ulong OutUcastOctets;

			/// <summary>The number of octets of data transmitted without errors in multicast packets through this interface.</summary>
			public ulong OutMulticastOctets;

			/// <summary>The number of octets of data transmitted without errors in broadcast packets through this interface.</summary>
			public ulong OutBroadcastOctets;

			/// <summary>The transmit queue length. This field is not currently used.</summary>
			public ulong OutQLen;

			/// <summary>Initializes a new instance of the <see cref="MIB_IF_ROW2"/> struct.</summary>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_IF_ROW2(uint interfaceIndex) : this()
			{
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>Initializes a new instance of the <see cref="MIB_IF_ROW2"/> struct.</summary>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_IF_ROW2(NET_LUID interfaceLuid) : this()
			{
				InterfaceLuid = interfaceLuid;
			}
		}

		/// <summary>
		/// <para>The <c>MIB_IPFORWARD_ROW2</c> structure stores information about an IP route entry.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_IPFORWARD_ROW2</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetIpForwardTable2</c> function enumerates the IP route entries on a local system and returns this information in a
		/// MIB_IPFORWARD_TABLE2 structure as an array of <c>MIB_IPFORWARD_ROW2</c> entries.
		/// </para>
		/// <para>
		/// The <c>GetIpForwardEntry2</c> function retrieves a single IP route entry and returns this information in a
		/// <c>MIB_IPFORWARD_ROW2</c> structure.
		/// </para>
		/// <para>
		/// An entry with the <c>Prefix</c> and the <c>PrefixLength</c> members of the IP_ADDRESS_PREFIX set to zero in the
		/// <c>DestinationPrefix</c> member in the <c>MIB_IPFORWARD_ROW2</c> structure is considered a default route. The
		/// MIB_IPFORWARD_TABLE2 may contain multiple <c>MIB_IPFORWARD_ROW2</c> entries with the <c>Prefix</c> and the <c>PrefixLength</c>
		/// members of the <c>IP_ADDRESS_PREFIX</c> set to zero in the <c>DestinationPrefix</c> member when there are multiple network
		/// adapters installed.
		/// </para>
		/// <para>
		/// The <c>Metric</c> member of a <c>MIB_IPFORWARD_ROW2</c> entry is a value that is assigned to an IP route for a particular network
		/// interface that identifies the cost that is associated with using that route. For example, the metric can be valued in terms of
		/// link speed, hop count, or time delay. Automatic metric is a feature on Windows XP and later that automatically configures the
		/// metric for the local routes that are based on link speed. The automatic metric feature is enabled by default (the
		/// <c>UseAutomaticMetric</c> member of the MIB_IPINTERFACE_ROW structure is set to <c>TRUE</c>) on Windows XP and later. It can also
		/// be manually configured to assign a specific metric to an IP route.
		/// </para>
		/// <para>
		/// The route metric specified in the <c>Metric</c> member of the <c>MIB_IPFORWARD_ROW2</c> structure represents just the route
		/// metric offset. The complete metric is a combination of this route metric offset added to the interface metric specified in the
		/// <c>Metric</c> member of the MIB_IPINTERFACE_ROW structure of the associated interface. An application can retrieve the interface
		/// metric by calling the GetIpInterfaceEntry function.
		/// </para>
		/// <para>
		/// Note that the Netioapi.h header file is automatically included in the Iphlpapi.h header file. The Netioapi.h header file should
		/// never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_mib_ipforward_row2 typedef struct _MIB_IPFORWARD_ROW2 {
		// NET_LUID InterfaceLuid; NET_IFINDEX InterfaceIndex; IP_ADDRESS_PREFIX DestinationPrefix; SOCKADDR_INET NextHop; UCHAR
		// SitePrefixLength; ULONG ValidLifetime; ULONG PreferredLifetime; ULONG Metric; NL_ROUTE_PROTOCOL Protocol; BOOLEAN Loopback;
		// BOOLEAN AutoconfigureAddress; BOOLEAN Publish; BOOLEAN Immortal; ULONG Age; NL_ROUTE_ORIGIN Origin; } MIB_IPFORWARD_ROW2, *PMIB_IPFORWARD_ROW2;
		[PInvokeData("netioapi.h", MSDNShortId = "3678315d-b6ab-48c8-8522-a57deb63f8c9")]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct MIB_IPFORWARD_ROW2
		{
			/// <summary>
			/// <para>Type: <c>NET_LUID</c></para>
			/// <para>The locally unique identifier (LUID) for the network interface associated with this IP route entry.</para>
			/// </summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// <para>Type: <c>NET_IFINDEX</c></para>
			/// <para>
			/// The local index value for the network interface associated with this IP route entry. This index value may change when a
			/// network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </para>
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// <para>Type: <c>IP_ADDRESS_PREFIX</c></para>
			/// <para>The IP address prefix for the destination IP address for this route.</para>
			/// </summary>
			public IP_ADDRESS_PREFIX DestinationPrefix;

			/// <summary>
			/// <para>Type: <c>SOCKADDR_INET</c></para>
			/// <para>
			/// For a remote route, the IP address of the next system or gateway en route. If the route is to a local loopback address or an
			/// IP address on the local link, the next hop is unspecified (all zeros). For a local loopback route, this member should be an
			/// IPv4 address of 0.0.0.0 for an IPv4 route entry or an IPv6 address address of 0::0 for an IPv6 route entry.
			/// </para>
			/// </summary>
			public SOCKADDR_INET NextHop;

			/// <summary>
			/// <para>Type: <c>UCHAR</c></para>
			/// <para>
			/// The length, in bits, of the site prefix or network part of the IP address for this route. For an IPv4 route entry, any value
			/// greater than 32 is an illegal value. For an IPv6 route entry, any value greater than 128 is an illegal value. A value of 255
			/// is commonly used to represent an illegal value.
			/// </para>
			/// </summary>
			public byte SitePrefixLength;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum time, in seconds, that the IP route entry is valid. A value of 0xffffffff is considered to be infinite.</para>
			/// </summary>
			public uint ValidLifetime;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The preferred time, in seconds, that the IP route entry is valid. A value of 0xffffffff is considered to be infinite.</para>
			/// </summary>
			public uint PreferredLifetime;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The route metric offset value for this IP route entry. Note the actual route metric used to compute the route preference is
			/// the summation of interface metric specified in the <c>Metric</c> member of the MIB_IPINTERFACE_ROW structure and the route
			/// metric offset specified in this member. The semantics of this metric are determined by the routing protocol specified in the
			/// <c>Protocol</c> member. If this metric is not used, its value should be set to -1. This value is documented in RFC 4292. For
			/// more information, see http://www.ietf.org/rfc/rfc4292.txt.
			/// </para>
			/// </summary>
			public uint Metric;

			/// <summary>
			/// <para>Type: <c>NL_ROUTE_PROTOCOL</c></para>
			/// <para>
			/// The routing mechanism how this IP route was added. This member can be one of the values from the <c>NL_ROUTE_PROTOCOL</c>
			/// enumeration type defined in the Nldef.h header file. The member is described in RFC 4292. For more information, see http://www.ietf.org/rfc/rfc4292.txt.
			/// </para>
			/// <para>
			/// Note that the Nldef.h header is automatically included by the Ipmib.h header file which is automatically included by the
			/// Iprtrmib.h header. The Iphlpapi.h header automatically includes the Iprtrmib.h header file. The Iprtrmib.h, Ipmib.h, and
			/// Nldef.h header files should never be used directly.
			/// </para>
			/// <para>The following list shows the possible values for this member.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MIB_IPPROTO_OTHER 1</term>
			/// <term>The routing mechanism was not specified.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_LOCAL 2</term>
			/// <term>A local interface.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_NETMGMT 3</term>
			/// <term>
			/// A static route. This value is used to identify route information for IP routing set through network management such as the
			/// Dynamic Host Configuration Protocol (DCHP), the Simple Network Management Protocol (SNMP), or by calls to the
			/// CreateIpForwardEntry2, DeleteIpForwardEntry2, or SetIpForwardEntry2 functions.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_ICMP 4</term>
			/// <term>The result of an ICMP redirect.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_EGP 5</term>
			/// <term>The Exterior Gateway Protocol (EGP), a dynamic routing protocol.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_GGP 6</term>
			/// <term>The Gateway-to-Gateway Protocol (GGP), a dynamic routing protocol.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_HELLO 7</term>
			/// <term>
			/// The Hellospeak protocol, a dynamic routing protocol. This is a historical entry no longer in use and was an early routing
			/// protocol used by the original ARPANET routers that ran special software called the Fuzzball routing protocol, sometimes
			/// called Hellospeak, as described in RFC 891 and RFC 1305. For more information, see http://www.ietf.org/rfc/rfc891.txt and http://www.ietf.org/rfc/rfc1305.txt.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_RIP 8</term>
			/// <term>The Berkeley Routing Information Protocol (RIP) or RIP-II, a dynamic routing protocol.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_IS_IS 9</term>
			/// <term>
			/// The Intermediate System-to-Intermediate System (IS-IS) protocol, a dynamic routing protocol. The IS-IS protocol was developed
			/// for use in the Open Systems Interconnection (OSI) protocol suite.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_ES_IS 10</term>
			/// <term>
			/// The End System-to-Intermediate System (ES-IS) protocol, a dynamic routing protocol. The ES-IS protocol was developed for use
			/// in the Open Systems Interconnection (OSI) protocol suite.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_CISCO 11</term>
			/// <term>The Cisco Interior Gateway Routing Protocol (IGRP), a dynamic routing protocol.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_BBN 12</term>
			/// <term>
			/// The Bolt, Beranek, and Newman (BBN) Interior Gateway Protocol (IGP) that used the Shortest Path First (SPF) algorithm. This
			/// was an early dynamic routing protocol.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_OSPF 13</term>
			/// <term>The Open Shortest Path First (OSPF) protocol, a dynamic routing protocol.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_BGP 14</term>
			/// <term>The Border Gateway Protocol (BGP), a dynamic routing protocol.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_NT_AUTOSTATIC 10002</term>
			/// <term>A Windows specific entry added originally by a routing protocol, but which is now static.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_NT_STATIC 10006</term>
			/// <term>A Windows specific entry added as a static route from the routing user interface or a routing command.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IPPROTO_NT_STATIC_NON_DOD 10007</term>
			/// <term>
			/// A Windows specific entry added as an static route from the routing user interface or a routing command, except these routes
			/// do not cause Dial On Demand (DOD).
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIB_IPPROTOCOL Protocol;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that specifies if the route is a loopback route (the gateway is on the local host).</para>
			/// </summary>
			public byte Loopback;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that specifies if the IP address is autoconfigured.</para>
			/// </summary>
			public byte AutoconfigureAddress;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that specifies if the route is published.</para>
			/// </summary>
			public byte Publish;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that specifies if the route is immortal.</para>
			/// </summary>
			public byte Immortal;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of seconds since the route was added or modified in the network routing table.</para>
			/// </summary>
			public uint Age;

			/// <summary>
			/// <para>Type: <c>NL_ROUTE_ORIGIN</c></para>
			/// <para>
			/// The origin of the route. This member can be one of the values from the <c>NL_ROUTE_ORIGIN</c> enumeration type defined in the
			/// Nldef.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NlroManual 0</term>
			/// <term>A result of manual configuration.</term>
			/// </item>
			/// <item>
			/// <term>NlroWellKnown 1</term>
			/// <term>A well-known route.</term>
			/// </item>
			/// <item>
			/// <term>NlroDHCP 2</term>
			/// <term>A result of DHCP configuration.</term>
			/// </item>
			/// <item>
			/// <term>NlroRouterAdvertisement 3</term>
			/// <term>The result of router advertisement.</term>
			/// </item>
			/// <item>
			/// <term>Nlro6to4 4</term>
			/// <term>A result of 6to4 tunneling.</term>
			/// </item>
			/// </list>
			/// </summary>
			public NL_ROUTE_ORIGIN Origin;
		}

		/// <summary>
		/// <para>The <c>MIB_IPNET_ROW2</c> structure stores information about a neighbor IP address.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_IPNET_ROW2</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetIpNetTable2</c> function enumerates the neighbor IP addresses on a local system and returns this information in an
		/// MIB_IPNET_TABLE2 structure.
		/// </para>
		/// <para>
		/// For IPv4, this includes addresses determined used the Address Resolution Protocol (ARP). For IPv6, this includes addresses
		/// determined using the Neighbor Discovery (ND) protocol for IPv6 as specified in RFC 2461. For more information, see http://www.ietf.org/rfc/rfc2461.txt.
		/// </para>
		/// <para>
		/// The GetIpNetEntry2 function retrieves a single neighbor IP address and returns this information in a <c>MIB_IPNET_ROW2</c> structure.
		/// </para>
		/// <para>
		/// Note that the Netioapi.h header file is automatically included in the Iphlpapi.h header file. The Netioapi.h header file should
		/// never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_mib_ipnet_row2 typedef struct _MIB_IPNET_ROW2 {
		// SOCKADDR_INET Address; NET_IFINDEX InterfaceIndex; NET_LUID InterfaceLuid; UCHAR PhysicalAddress[IF_MAX_PHYS_ADDRESS_LENGTH];
		// ULONG PhysicalAddressLength; NL_NEIGHBOR_STATE State; union { struct { BOOLEAN IsRouter : 1; BOOLEAN IsUnreachable : 1; }; UCHAR
		// Flags; }; union { ULONG LastReachable; ULONG LastUnreachable; } ReachabilityTime; } MIB_IPNET_ROW2, *PMIB_IPNET_ROW2;
		[PInvokeData("netioapi.h", MSDNShortId = "164dbd93-4464-40f9-989a-17597102b1d8")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct MIB_IPNET_ROW2
		{
			/// <summary>
			/// <para>Type: <c>SOCKADDR_INET</c></para>
			/// <para>The neighbor IP address. This member can be an IPv6 address or an IPv4 address.</para>
			/// </summary>
			public SOCKADDR_INET Address;

			/// <summary>
			/// <para>Type: <c>NET_IFINDEX</c></para>
			/// <para>
			/// The local index value for the network interface associated with this IP address. This index value may change when a network
			/// adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </para>
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// <para>Type: <c>NET_LUID</c></para>
			/// <para>The locally unique identifier (LUID) for the network interface associated with this IP address.</para>
			/// </summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// <para>Type: <c>UCHAR[IF_MAX_PHYS_ADDRESS_LENGTH]</c></para>
			/// <para>The physical hardware address of the adapter for the network interface associated with this IP address.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = IF_MAX_PHYS_ADDRESS_LENGTH)]
			public byte[] PhysicalAddress;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The length, in bytes, of the physical hardware address specified by the <c>PhysicalAddress</c> member. The maximum value
			/// supported is 32 bytes.
			/// </para>
			/// </summary>
			public uint PhysicalAddressLength;

			/// <summary>
			/// <para>Type: <c>NL_NEIGHBOR_STATE</c></para>
			/// <para>
			/// The state of a network neighbor IP address as defined in RFC 2461, section 7.3.2. For more information, see
			/// http://www.ietf.org/rfc/rfc2461.txt. This member can be one of the values from the <c>NL_NEIGHBOR_STATE</c> enumeration type
			/// defined in the Nldef.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NlnsUnreachable</term>
			/// <term>The IP address is unreachable.</term>
			/// </item>
			/// <item>
			/// <term>NlnsIncomplete</term>
			/// <term>
			/// Address resolution is in progress and the link-layer address of the neighbor has not yet been determined. Specifically for
			/// IPv6, a Neighbor Solicitation has been sent to the solicited-node multicast IP address of the target, but the corresponding
			/// neighbor advertisement has not yet been received.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NlnsProbe</term>
			/// <term>
			/// The neighbor is no longer known to be reachable, and probes are being sent to verify reachability. For IPv6, a reachability
			/// confirmation is actively being sought by retransmitting unicast Neighbor Solicitation probes at regular intervals until a
			/// reachability confirmation is received.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NlnsDelay</term>
			/// <term>
			/// The neighbor is no longer known to be reachable, and traffic has recently been sent to the neighbor. Rather than probe the
			/// neighbor immediately, however, delay sending probes for a short while in order to give upper layer protocols a chance to
			/// provide reachability confirmation. For IPv6, more time has elapsed than is specified in the ReachabilityTime.ReachableTime
			/// member since the last positive confirmation was received that the forward path was functioning properly and a packet was
			/// sent. If no reachability confirmation is received within a period of time (used to delay the first probe) of entering the
			/// NlnsDelay state, then a neighbor solicitation is sent and the State member is changed to NlnsProbe.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NlnsStale</term>
			/// <term>
			/// The neighbor is no longer known to be reachable but until traffic is sent to the neighbor, no attempt should be made to
			/// verify its reachability. For IPv6, more time has elapsed than is specified in the ReachabilityTime.ReachableTime member since
			/// the last positive confirmation was received that the forward path was functioning properly. While the State is NlnsStale, no
			/// action takes place until a packet is sent. The NlnsStale state is entered upon receiving an unsolicited neighbor discovery
			/// message that updates the cached IP address. Receipt of such a message does not confirm reachability, and entering the
			/// NlnsStale state insures reachability is verified quickly if the entry is actually being used. However, reachability is not
			/// actually verified until the entry is actually used.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NlnsReachable</term>
			/// <term>
			/// The neighbor is known to have been reachable recently (within tens of seconds ago). For IPv6, a positive confirmation was
			/// received within the time specified in the ReachabilityTime.ReachableTime member that the forward path to the neighbor was
			/// functioning properly. While the State is NlnsReachable, no special action takes place as packets are sent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NlnsPermanent</term>
			/// <term>The IP address is a permanent address.</term>
			/// </item>
			/// <item>
			/// <term>NlnsMaximum</term>
			/// <term>The maximum possible value for the NL_NEIGHBOR_STATE enumeration type. This is not a legal value for the State member.</term>
			/// </item>
			/// </list>
			/// </summary>
			public NL_NEIGHBOR_STATE State;

			/// <summary>Undocumented.</summary>
			public MIB_IPNET_ROW2_FLAGS Flags;

			/// <summary>
			/// <para>
			/// <c>Type: <c>ULONG</c></c> The time, in milliseconds, that a node assumes a neighbor is reachable after having received a
			/// reachability confirmation or is unreachable after not having received a reachability confirmation.
			/// </para>
			/// </summary>
			public uint ReachabilityTime;

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_IPNET_ROW2"/> struct.
			/// </summary>
			/// <param name="ipV4">The neighbor IP address.</param>
			/// <param name="ifLuid">The locally unique identifier (LUID) for the network interface associated with this IP address.</param>
			/// <param name="macAddr">The physical hardware address of the adapter for the network interface associated with this IP address.</param>
			public MIB_IPNET_ROW2(SOCKADDR_IN ipV4, NET_LUID ifLuid, byte[] macAddr = null) : this(ipV4, macAddr)
			{
				InterfaceLuid = ifLuid;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_IPNET_ROW2" /> struct.
			/// </summary>
			/// <param name="ipV4">The neighbor IP address.</param>
			/// <param name="ifIdx">The local index value for the network interface associated with this IP address. This index value may change when a network
			/// adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.</param>
			/// <param name="macAddr">The physical hardware address of the adapter for the network interface associated with this IP address.</param>
			public MIB_IPNET_ROW2(SOCKADDR_IN ipV4, uint ifIdx, byte[] macAddr = null) : this(ipV4, macAddr)
			{
				InterfaceIndex = ifIdx;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_IPNET_ROW2"/> struct.
			/// </summary>
			/// <param name="ipV6">The neighbor IP address.</param>
			/// <param name="ifLuid">The locally unique identifier (LUID) for the network interface associated with this IP address.</param>
			/// <param name="macAddr">The physical hardware address of the adapter for the network interface associated with this IP address.</param>
			public MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, NET_LUID ifLuid, byte[] macAddr = null) : this(ipV6, macAddr)
			{
				InterfaceLuid = ifLuid;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_IPNET_ROW2"/> struct.
			/// </summary>
			/// <param name="ipV6">The neighbor IP address.</param>
			/// <param name="ifIdx">The local index value for the network interface associated with this IP address. This index value may change when a network
			/// adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.</param>
			/// <param name="macAddr">The physical hardware address of the adapter for the network interface associated with this IP address.</param>
			public MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, uint ifIdx, byte[] macAddr = null) : this(ipV6, macAddr)
			{
				InterfaceIndex = ifIdx;
			}

			private MIB_IPNET_ROW2(SOCKADDR_IN ipV4, byte[] macAddr) : this()
			{
				Address.Ipv4 = ipV4;
				SetMac(macAddr);
			}

			private MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, byte[] macAddr) : this()
			{
				Address.Ipv6 = ipV6;
				SetMac(macAddr);
			}

			private void SetMac(byte[] macAddr)
			{
				if (macAddr == null)
				{
					return;
				}

				PhysicalAddressLength = IF_MAX_PHYS_ADDRESS_LENGTH;
				PhysicalAddress = new byte[IF_MAX_PHYS_ADDRESS_LENGTH];
				Array.Copy(macAddr, PhysicalAddress, 6);
			}

			/// <inheritdoc/>
			public override string ToString()
			{
				return $"{Address}; MAC:{PhysicalAddressToString(PhysicalAddress)}; If:{(InterfaceIndex != 0 ? InterfaceIndex.ToString() : InterfaceLuid.ToString())}";
			}
		}

		/// <summary>
		/// <para>The <c>MIB_UNICASTIPADDRESS_ROW</c> structure stores information about a unicast IP address.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_UNICASTIPADDRESS_ROW</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>SkipAsSource</c> member of the <c>MIB_UNICASTIPADDRESS_ROW</c> structure affects the operation of the getaddrinfo,
		/// GetAddrInfoW, and GetAddrInfoEx functions in Windows sockets. If the pNodeName parameter passed to the <c>getaddrinfo</c> or
		/// <c>GetAddrInfoW</c> functions or the pName parameter passed to the <c>GetAddrInfoEx</c> function points to a computer name, all
		/// permanent addresses for the computer that can be used as a source address are returned. On Windows Vista and later, these
		/// addresses would include all unicast IP addresses returned by the GetUnicastIpAddressTable or GetUnicastIpAddressEntry functions
		/// in which the <c>SkipAsSource</c> member is set to false in the <c>MIB_UNICASTIPADDRESS_ROW</c> structure.
		/// </para>
		/// <para>
		/// If the pNodeName or pName parameter refers to a cluster virtual server name, only virtual server addresses are returned. On
		/// Windows Vista and later, these addresses would include all unicast IP addresses returned by the GetUnicastIpAddressTable or
		/// GetUnicastIpAddressEntry functions in which the <c>SkipAsSource</c> member is set to true in the <c>MIB_UNICASTIPADDRESS_ROW</c>
		/// structure. See Windows Clustering for more information about clustering.
		/// </para>
		/// <para>
		/// Windows 7 with Service Pack 1 (SP1) and Windows Server 2008 R2 with Service Pack 1 (SP1) add support to Netsh.exe for setting the
		/// SkipAsSource attribute on an IP address. This hotfix also changes the behavior such that if the <c>SkipAsSource</c> member in the
		/// <c>MIB_UNICASTIPADDRESS_ROW</c> structure is set to false, the IP address will be registered in DNS. If the <c>SkipAsSource</c>
		/// member is set to true, the IP address is not registered in DNS.
		/// </para>
		/// <para>
		/// A hotfix is available for Windows 7 and Windows Server 2008 R2 that adds support to Netsh.exe for setting the SkipAsSource
		/// attribute on an IP address. This hotfix also changes the behavior such that if the <c>SkipAsSource</c> member in the
		/// <c>MIB_UNICASTIPADDRESS_ROW</c> structure is set to false, the IP address will be registered in DNS. If the <c>SkipAsSource</c>
		/// member is set to true, the IP address is not registered in DNS. For more information, see Knowledge Base (KB) 2386184.
		/// </para>
		/// <para>
		/// A similar hotfix is also available for Windows Vista with Service Pack 2 (SP2) and Windows Server 2008 with Service Pack 2 (SP2)
		/// that adds support to Netsh.exe for setting the SkipAsSource attribute on an IP address. This hotfix also changes behavior such
		/// that if the <c>SkipAsSource</c> member in the <c>MIB_UNICASTIPADDRESS_ROW</c> structure is set to false, the IP address will be
		/// registered in DNS. If the <c>SkipAsSource</c> member is set to true, the IP address is not registered in DNS. For more
		/// information, see Knowledge Base (KB) 975808.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves a unicast IP address table and prints some values from each of the retrieved
		/// <c>MIB_UNICASTIPADDRESS_ROW</c> structures.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_mib_unicastipaddress_row typedef struct
		// _MIB_UNICASTIPADDRESS_ROW { SOCKADDR_INET Address; NET_LUID InterfaceLuid; NET_IFINDEX InterfaceIndex; NL_PREFIX_ORIGIN
		// PrefixOrigin; NL_SUFFIX_ORIGIN SuffixOrigin; ULONG ValidLifetime; ULONG PreferredLifetime; UINT8 OnLinkPrefixLength; BOOLEAN
		// SkipAsSource; NL_DAD_STATE DadState; SCOPE_ID ScopeId; LARGE_INTEGER CreationTimeStamp; } MIB_UNICASTIPADDRESS_ROW, *PMIB_UNICASTIPADDRESS_ROW;
		[PInvokeData("netioapi.h", MSDNShortId = "f329bafd-9e83-4754-a9a9-e7e111229c90")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
		public struct MIB_UNICASTIPADDRESS_ROW
		{
			/// <summary>
			/// <para>Type: <c>SOCKADDR_INET</c></para>
			/// <para>The unicast IP address. This member can be an IPv6 address or an IPv4 address.</para>
			/// </summary>
			public SOCKADDR_INET Address;

			/// <summary>
			/// <para>Type: <c>NET_LUID</c></para>
			/// <para>The locally unique identifier (LUID) for the network interface associated with this IP address.</para>
			/// </summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// <para>Type: <c>NET_IFINDEX</c></para>
			/// <para>
			/// The local index value for the network interface associated with this IP address. This index value may change when a network
			/// adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </para>
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// <para>Type: <c>NL_PREFIX_ORIGIN</c></para>
			/// <para>
			/// The origin of the prefix or network part of IP the address. This member can be one of the values from the
			/// <c>NL_PREFIX_ORIGIN</c> enumeration type defined in the Nldef.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IpPrefixOriginOther 0</term>
			/// <term>
			/// The IP address prefix was configured using a source other than those defined in this enumeration. This value is applicable to
			/// an IPv6 or IPv4 address.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IpPrefixOriginManual 1</term>
			/// <term>The IP address prefix was configured manually. This value is applicable to an IPv6 or IPv4 address.</term>
			/// </item>
			/// <item>
			/// <term>IpPrefixOriginWellKnown 2</term>
			/// <term>
			/// The IP address prefix was configured using a well-known address. This value is applicable to an IPv6 link-local address or an
			/// IPv6 loopback address.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IpPrefixOriginDhcp 3</term>
			/// <term>
			/// The IP address prefix was configured using DHCP. This value is applicable to an IPv4 address configured using DHCP or an IPv6
			/// address configured using DHCPv6.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IpPrefixOriginRouterAdvertisement 4</term>
			/// <term>
			/// The IP address prefix was configured using router advertisement. This value is applicable to an anonymous IPv6 address that
			/// was generated after receiving a router advertisement.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IpPrefixOriginUnchanged 16</term>
			/// <term>
			/// The IP address prefix should be unchanged. This value is used when setting the properties for a unicast IP interface when the
			/// value for the IP prefix origin should be unchanged.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public NL_PREFIX_ORIGIN PrefixOrigin;

			/// <summary>
			/// <para>Type: <c>NL_SUFFIX_ORIGIN</c></para>
			/// <para>
			/// The origin of the suffix or host part of IP the address. This member can be one of the values from the
			/// <c>NL_SUFFIX_ORIGIN</c> enumeration type defined in the Nldef.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IpSuffixOriginOther 0</term>
			/// <term>
			/// The IP address suffix was configured using a source other than those defined in this enumeration. This value is applicable to
			/// an IPv6 or IPv4 address.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IpSuffixOriginManual 1</term>
			/// <term>The IP address suffix was configured manually. This value is applicable to an IPv6 or IPv4 address.</term>
			/// </item>
			/// <item>
			/// <term>IpSuffixOriginWellKnown 2</term>
			/// <term>
			/// The IP address suffix was configured using a well-known address. This value is applicable to an IPv6 link-local address or an
			/// IPv6 loopback address.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IpSuffixOriginDhcp 3</term>
			/// <term>
			/// The IP address suffix was configured using DHCP. This value is applicable to an IPv4 address configured using DHCP or an IPv6
			/// address configured using DHCPv6.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IpSuffixOriginLinkLayerAddress 4</term>
			/// <term>
			/// The IP address suffix was the link local address. This value is applicable to an IPv6 link-local address or an IPv6 address
			/// where the network part was generated based on a router advertisement and the host part was based on the MAC hardware address.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IpSuffixOriginRandom 5</term>
			/// <term>
			/// The IP address suffix was generated randomly. This value is applicable to an anonymous IPv6 address where the host part of
			/// the address was generated randomly from the MAC hardware address after receiving a router advertisement.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IpSuffixOriginUnchanged 16</term>
			/// <term>
			/// The IP address suffix should be unchanged. This value is used when setting the properties for a unicast IP interface when the
			/// value for the IP suffix origin should be unchanged.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public NL_SUFFIX_ORIGIN SuffixOrigin;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum time, in seconds, that the IP address is valid. A value of 0xffffffff is considered to be infinite.</para>
			/// </summary>
			public uint ValidLifetime;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The preferred time, in seconds, that the IP address is valid. A value of 0xffffffff is considered to be infinite.</para>
			/// </summary>
			public uint PreferredLifetime;

			/// <summary>
			/// <para>Type: <c>UINT8</c></para>
			/// <para>
			/// The length, in bits, of the prefix or network part of the IP address. For a unicast IPv4 address, any value greater than 32
			/// is an illegal value. For a unicast IPv6 address, any value greater than 128 is an illegal value. A value of 255 is commonly
			/// used to represent an illegal value.
			/// </para>
			/// </summary>
			public byte OnLinkPrefixLength;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>This member specifies if the address can be used as an IP source address.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool SkipAsSource;

			/// <summary>
			/// <para>Type: <c>NL_DAD_STATE</c></para>
			/// <para>
			/// The duplicate Address detection (DAD) state. Duplicate address detection is applicable to both IPv6 and IPv4 addresses. This
			/// member can be one of the values from the <c>NL_DAD_STATE</c> enumeration type defined in the Nldef.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IpDadStateInvalid 0</term>
			/// <term>The DAD state is invalid.</term>
			/// </item>
			/// <item>
			/// <term>IpDadStateTentative 1</term>
			/// <term>The DAD state is tentative.</term>
			/// </item>
			/// <item>
			/// <term>IpDadStateDuplicate 2</term>
			/// <term>A duplicate IP address has been detected.</term>
			/// </item>
			/// <item>
			/// <term>IpDadStateDeprecated 3</term>
			/// <term>The IP address has been deprecated.</term>
			/// </item>
			/// <item>
			/// <term>IpDadStatePreferred 4</term>
			/// <term>The IP address is the preferred address.</term>
			/// </item>
			/// </list>
			/// </summary>
			public NL_DAD_STATE DadState;

			/// <summary>
			/// <para>Type: <c>SCOPE_ID</c></para>
			/// <para>
			/// The scope ID of the IP address. This member is applicable only to an IPv6 address. This member cannot be set. It is
			/// automatically determined by the interface on which the address was added.
			/// </para>
			/// </summary>
			public SCOPE_ID ScopeId;

			/// <summary>
			/// <para>Type: <c>LARGE_INTEGER</c></para>
			/// <para>The time stamp when the IP address was created.</para>
			/// </summary>
			public long CreationTimeStamp;
		}

		[PInvokeData("ws2def.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SCOPE_ID
		{
			public uint Value;

			public uint Zone
			{
				get => BitHelper.GetBits(Value, 0, 28);
				set => BitHelper.SetBits(ref Value, 0, 28, value);
			}

			public byte Level
			{
				get => (byte)BitHelper.GetBits(Value, 28, 4);
				set => BitHelper.SetBits(ref Value, 28, 4, value);
			}
		}

		/// <summary>The MIB_IF_TABLE2 structure contains a table of logical and physical interface entries.</summary>
		// https://msdn.microsoft.com/en-us/library/windows/hardware/ff559224(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559224")]
		[CorrespondingType(typeof(MIB_IF_ROW2)), DefaultProperty(nameof(Elements))]
		public class MIB_IF_TABLE2 : SafeMibTableHandle, IEnumerable<MIB_IF_ROW2>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_IF_TABLE2"/> class.</summary>
			public MIB_IF_TABLE2() : base() { }

			/// <summary>Gets the array of MIB_IF_ROW2 structures containing interface entries.</summary>
			/// <value>An array of MIB_IF_ROW2 structures containing interface entries.</value>
			public MIB_IF_ROW2[] Elements => handle.ToArray<MIB_IF_ROW2>((int)NumEntries, Marshal.SizeOf(typeof(ulong)));

			/// <summary>Gets the number of interface entries in the array.</summary>
			/// <value>The number of interface entries in the array.</value>
			public uint NumEntries => IsInvalid ? 0 : handle.ToStructure<uint>();

			/// <summary>Gets the enumerator.</summary>
			public IEnumerator<MIB_IF_ROW2> GetEnumerator()
			{
				return ((IEnumerable<MIB_IF_ROW2>)Elements).GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		/// <summary>The MIB_IPNET_TABLE2 structure contains a table of neighbor IP address entries.</summary>
		// typedef struct _MIB_IPNET_TABLE2 { ULONG NumEntries; MIB_IPNET_ROW2 Table[ANY_SIZE];} MIB_IPNET_TABLE2, *PMIB_IPNET_TABLE2;
		// https://msdn.microsoft.com/en-us/library/windows/hardware/ff559267(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559267")]
		[CorrespondingType(typeof(MIB_IPNET_ROW2)), DefaultProperty(nameof(Elements))]
		public class MIB_IPNET_TABLE2 : SafeMibTableHandle, IEnumerable<MIB_IPNET_ROW2>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_IPNET_TABLE2"/> class.</summary>
			public MIB_IPNET_TABLE2() : base() { }

			/// <summary>Gets the array of MIB_IF_ROW2 structures containing interface entries.</summary>
			/// <value>An array of MIB_IF_ROW2 structures containing interface entries.</value>
			public MIB_IPNET_ROW2[] Elements => handle.ToArray<MIB_IPNET_ROW2>((int)NumEntries, Marshal.SizeOf(typeof(ulong)));

			/// <summary>Gets the number of interface entries in the array.</summary>
			/// <value>The number of interface entries in the array.</value>
			public uint NumEntries => IsInvalid ? 0 : handle.ToStructure<uint>();

			public IEnumerator<MIB_IPNET_ROW2> GetEnumerator() => ((IEnumerable<MIB_IPNET_ROW2>)Elements).GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		public class SafeMibTableHandle : GenericSafeHandle
		{
			public SafeMibTableHandle() : this(IntPtr.Zero)
			{
			}

			public SafeMibTableHandle(IntPtr bufferPtr, bool own = true) : base(bufferPtr, h => { FreeMibTable(h); return true; }, own)
			{
			}

			public T[] ToArray<T>(int count)
			{
				return IsInvalid ? null : handle.ToArray<T>(count);
			}
		}
	}
}