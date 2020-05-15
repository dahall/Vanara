using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>This function is called when an interface notification is received from <see cref="NotifyRouteChange2"/>.</summary>
		/// <param name="CallerContext">
		/// The CallerContext parameter that is passed to the NotifyRouteChange2 function when it is registering the driver for change notifications.
		/// </param>
		/// <param name="Row">
		/// A pointer to the MIB_IPFORWARD_ROW2 entry for the IP route entry that was changed. This parameter is a NULL pointer when the
		/// MIB_NOTIFICATION_TYPE value that is passed in the NotificationType parameter to the callback function is set to
		/// MibInitialNotification. This situation can occur only if the InitialNotification parameter that is passed to NotifyRouteChange2
		/// was set to TRUE when registering the driver for change notifications.
		/// </param>
		/// <param name="NotificationType">
		/// The notification type. This member can be one of the values from the MIB_NOTIFICATION_TYPE enumeration type.
		/// </param>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void PIPFORWARD_CHANGE_CALLBACK([In] IntPtr CallerContext, [In, Optional] ref MIB_IPFORWARD_ROW2 Row, [In] MIB_NOTIFICATION_TYPE NotificationType);

		/// <summary>This function is called when an interface notification is received from <see cref="NotifyIpInterfaceChange"/>.</summary>
		/// <param name="CallerContext">
		/// The CallerContext parameter that is passed to the NotifyIpInterfaceChange function when it is registering the driver for change notifications.
		/// </param>
		/// <param name="Row">
		/// A pointer to the MIB_IPINTERFACE_ROW entry for the interface that was changed. This parameter is a NULL pointer when the
		/// MIB_NOTIFICATION_TYPE value that is passed in the NotificationType parameter to the callback function is set to
		/// MibInitialNotification. This situation can occur only if the InitialNotification parameter that is passed to
		/// NotifyIpInterfaceChange was set to TRUE when registering the driver for change notifications.
		/// </param>
		/// <param name="NotificationType">
		/// The notification type. This member can be one of the values from the MIB_NOTIFICATION_TYPE enumeration type.
		/// </param>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void PIPINTERFACE_CHANGE_CALLBACK(IntPtr CallerContext, IntPtr Row, MIB_NOTIFICATION_TYPE NotificationType);

		/// <summary>Called if NotifyStableUnicastIpAddressTable returns ERROR_IO_PENDING, which indicates that the I/O request is pending.</summary>
		/// <param name="CallerContext">
		/// The CallerContext parameter that is passed to the NotifyStableUnicastIpAddressTable function when it is registering the driver
		/// for notifications.
		/// </param>
		/// <param name="AddressTable">
		/// A pointer to a MIB_UNICASTIPADDRESS_TABLE structure that contains the stable unicast IP address table on the local computer.
		/// </param>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void PSTABLE_UNICAST_IPADDRESS_TABLE_CALLBACK([In] IntPtr CallerContext, [In] IntPtr AddressTable);

		/// <summary>Function is called when a Teredo port change notification is received.</summary>
		/// <param name="CallerContext">
		/// The CallerContext parameter that is passed to the NotifyTeredoPortChange function when it is registering the driver for change notifications.
		/// </param>
		/// <param name="Port">
		/// The UDP port number that the Teredo client currently uses. This parameter is zero when the MIB_NOTIFICATION_TYPE value that is
		/// passed in the NotificationType parameter to the callback function is set to MibInitialNotification. This situation can occur only
		/// if the InitialNotification parameter that is passed to NotifyTeredoPortChange was set to TRUE when registering the driver for
		/// change notifications.
		/// </param>
		/// <param name="NotificationType">
		/// The notification type. This member can be one of the values from the MIB_NOTIFICATION_TYPE enumeration type.
		/// </param>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void PTEREDO_PORT_CHANGE_CALLBACK([In] IntPtr CallerContext, [In] ushort Port, MIB_NOTIFICATION_TYPE NotificationType);

		/// <summary>This function is called when a unicast IP address notification is received.</summary>
		/// <param name="CallerContext">
		/// The CallerContext parameter that is passed to the NotifyUnicastIpAddressChange function when it is registering the driver for
		/// change notifications.
		/// </param>
		/// <param name="Row">
		/// A pointer to the MIB_UNICASTIPADDRESS_ROW entry for the unicast IP address that was changed. This parameter is a NULL pointer
		/// when the MIB_NOTIFICATION_TYPE value that is passed in the NotificationType parameter to the callback function is set to
		/// MibInitialNotification. This situation can occur only if the InitialNotification parameter that is passed to
		/// NotifyUnicastIpAddressChange was set to TRUE when registering the driver for change notifications.
		/// </param>
		/// <param name="NotificationType">
		/// The notification type. This member can be one of the values from the MIB_NOTIFICATION_TYPE enumeration type.
		/// </param>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void PUNICAST_IPADDRESS_CHANGE_CALLBACK([In] IntPtr CallerContext, [In, Optional] IntPtr Row, [In] MIB_NOTIFICATION_TYPE NotificationType);

		/// <summary>A set of flags that provide information about an interface.</summary>
		[PInvokeData("netioapi.h")]
		[Flags]
		public enum InterfaceAndOperStatusFlags : byte
		{
			/// <summary>Set if the network interface is for hardware.</summary>
			HardwareInterface = 1 << 0,

			/// <summary>Set if the network interface is for a filter module.</summary>
			FilterInterface = 1 << 1,

			/// <summary>Set if a connector is present on the network interface. This value is set if there is a physical network adapter.</summary>
			ConnectorPresent = 1 << 2,

			/// <summary>
			/// Set if the default port for the network interface is not authenticated. If a network interface is not authenticated by the
			/// target, then the network interface is not in an operational mode. Although this applies to both wired and wireless network
			/// connections, authentication is more common for wireless network connections.
			/// </summary>
			NotAuthenticated = 1 << 3,

			/// <summary>
			/// Set if the network interface is not in a media-connected state. If a network cable is unplugged for a wired network, this
			/// would be set. For a wireless network, this is set for the network adapter that is not connected to a network.
			/// </summary>
			NotMediaConnected = 1 << 4,

			/// <summary>
			/// Set if the network stack for the network interface is in the paused or pausing state. This does not mean that the computer is
			/// in a hibernated state.
			/// </summary>
			Paused = 1 << 5,

			/// <summary>Set if the network interface is in a low power state.</summary>
			LowPower = 1 << 6,

			/// <summary>
			/// Set if the network interface is an endpoint device and not a true network interface that connects to a network. This can be
			/// set by devices such as smart phones which use networking infrastructure to communicate to the PC but do not provide
			/// connectivity to an external network. It is mandatory for these types of devices to set this flag.
			/// </summary>
			EndPointInterface = 1 << 7
		}

		/// <summary>The level of interface information to retrieve.</summary>
		[PInvokeData("netioapi.h")]
		public enum MIB_IF_ENTRY_LEVEL
		{
			/// <summary>
			/// The values of statistics and state returned in members of the MIB_IF_ROW2 structure pointed to by the Row parameter are
			/// returned from the top of the filter stack.
			/// </summary>
			MibIfEntryNormal = 0,

			/// <summary>
			/// The values of state (without statistics) returned in members of the MIB_IF_ROW2 structure pointed to by the Row parameter
			/// are returned from the top of the filter stack.
			/// </summary>
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

		/// <summary>
		/// The MIB_NOTIFICATION_TYPE enumeration type defines the notification type that is passed to a callback function when a
		/// notification occurs.
		/// </summary>
		// typedef enum _MIB_NOTIFICATION_TYPE { MibParameterNotification = 0, MibAddInstance = 1, MibDeleteInstance = 2,
		// MibInitialNotification = 3} MIB_NOTIFICATION_TYPE, *PMIB_NOTIFICATION_TYPE; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559286(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559286")]
		public enum MIB_NOTIFICATION_TYPE
		{
			/// <summary>A parameter was changed.</summary>
			MibParameterNotification,

			/// <summary>A new MIB instance was added.</summary>
			MibAddInstance,

			/// <summary>An existing MIB instance was deleted.</summary>
			MibDeleteInstance,

			/// <summary>
			/// A notification that is invoked immediately after registration for change notification completes. This initial notification
			/// does not indicate that a change occurred to a MIB instance. The purpose of this initial notification type is to provide
			/// confirmation that the callback function is properly registered.
			/// </summary>
			MibInitialNotification,
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

		/// <summary>
		/// <para>The NL_LINK_LOCAL_ADDRESS_BEHAVIOR enumeration type defines the link local address behavior.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-_nl_link_local_address_behavior typedef enum
		// _NL_LINK_LOCAL_ADDRESS_BEHAVIOR { LinkLocalAlwaysOff , LinkLocalDelayed , LinkLocalAlwaysOn , LinkLocalUnchanged } NL_LINK_LOCAL_ADDRESS_BEHAVIOR;
		[PInvokeData("nldef.h", MSDNShortId = "d3010b6a-445b-44eb-8ebb-101664f3f835")]
		public enum NL_LINK_LOCAL_ADDRESS_BEHAVIOR
		{
			/// <summary>A link local IP address should never be used.</summary>
			LinkLocalAlwaysOff = 0,

			/// <summary>
			/// A link local IP address should be used only if no other address is available. This setting is the default setting for an IPv4 interface.
			/// </summary>
			LinkLocalDelayed,

			/// <summary>A link local IP address should always be used. This setting is the default setting for an IPv6 interface.</summary>
			LinkLocalAlwaysOn,

			/// <summary>When the properties of an IP interface are being set, the value for link local address behavior should be unchanged.</summary>
			LinkLocalUnchanged = -1,
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
		/// <para>The NL_ROUTER_DISCOVERY_BEHAVIOR enumeration type defines the router discovery behavior, as described in RFC 2461.</para>
		/// </summary>
		/// <remarks>
		/// <para>For more information about RFC 2461, see the Neighbor Discovery for IP Version 6 (IPv6) memo by the Network Working Group.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-_nl_router_discovery_behavior typedef enum
		// _NL_ROUTER_DISCOVERY_BEHAVIOR { RouterDiscoveryDisabled , RouterDiscoveryEnabled , RouterDiscoveryDhcp , RouterDiscoveryUnchanged
		// } NL_ROUTER_DISCOVERY_BEHAVIOR;
		[PInvokeData("nldef.h", MSDNShortId = "d3a0d872-c90a-4eb5-9011-c5913b9912c6")]
		public enum NL_ROUTER_DISCOVERY_BEHAVIOR
		{
			/// <summary>Router discovery is disabled.</summary>
			RouterDiscoveryDisabled = 0,

			/// <summary>Router discovery is enabled. This setting is the default value for IPv6.</summary>
			RouterDiscoveryEnabled,

			/// <summary>Router discovery is configured based on DHCP. This setting is the default value for IPv4.</summary>
			RouterDiscoveryDhcp,

			/// <summary>When the properties of an IP interface are being set, the value for router discovery should be unchanged.</summary>
			RouterDiscoveryUnchanged = -1,
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
		/// <para>The <c>ConvertInterfaceAliasToLuid</c> function is available on Windows Vista and later.</para>
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
		/// <para>The <c>ConvertInterfaceGuidToLuid</c> function is available on Windows Vista and later.</para>
		/// <para>
		/// The <c>ConvertInterfaceGuidToLuid</c> function is protocol independent and works with network interfaces for both the IPv6 and
		/// IPv4 protocol.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertinterfaceguidtoluid _NETIOAPI_SUCCESS_
		// NETIOAPI_API ConvertInterfaceGuidToLuid( CONST GUID *InterfaceGuid, PNET_LUID InterfaceLuid );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "cae669dc-899b-4485-b70a-5f58207a07df")]
		public static extern Win32Error ConvertInterfaceGuidToLuid(in Guid InterfaceGuid, out NET_LUID InterfaceLuid);

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
		/// <para>The <c>ConvertInterfaceIndexToLuid</c> function is available on Windows Vista and later.</para>
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
		/// <para>The <c>ConvertInterfaceLuidToAlias</c> function is available on Windows Vista and later.</para>
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
		public static extern Win32Error ConvertInterfaceLuidToAlias(in NET_LUID InterfaceLuid, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder InterfaceAlias, SizeT Length);

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
		/// <para>The <c>ConvertInterfaceLuidToGuid</c> function is available on Windows Vista and later.</para>
		/// <para>
		/// The <c>ConvertInterfaceLuidToGuid</c> function is protocol independent and works with network interfaces for both the IPv6 and
		/// IPv4 protocol.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertinterfaceluidtoguid _NETIOAPI_SUCCESS_
		// NETIOAPI_API ConvertInterfaceLuidToGuid( CONST NET_LUID *InterfaceLuid, GUID *InterfaceGuid );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "9d5bd1e9-0bf1-405a-8726-8e2c9ba4e022")]
		public static extern Win32Error ConvertInterfaceLuidToGuid(in NET_LUID InterfaceLuid, out Guid InterfaceGuid);

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
		public static extern Win32Error ConvertInterfaceLuidToIndex(in NET_LUID InterfaceLuid, out uint InterfaceIndex);

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
		/// <para>The <c>ConvertInterfaceLuidToNameA</c> function is available on Windows Vista and later.</para>
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
		public static extern Win32Error ConvertInterfaceLuidToName(in NET_LUID InterfaceLuid, StringBuilder InterfaceName, SizeT Length);

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
		/// <para>The <c>ConvertInterfaceNameToLuidA</c> function is available on Windows Vista and later.</para>
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
		/// <para>The <c>ConvertIpv4MaskToLength</c> function is available on Windows Vista and later.</para>
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
		/// <para>The <c>ConvertLengthToIpv4Mask</c> function is available on Windows Vista and later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-convertlengthtoipv4mask NETIOAPI_API
		// ConvertLengthToIpv4Mask( ULONG MaskLength, PULONG Mask );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "5d986301-368e-4984-9f90-e2af1f87cbea")]
		public static extern Win32Error ConvertLengthToIpv4Mask(uint MaskLength, out uint Mask);

		/// <summary>
		/// <para>The <c>CreateAnycastIpAddressEntry</c> function adds a new anycast IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>A pointer to a MIB_ANYCASTIPADDRESS_ROW structure entry for an anycast IP address entry.</para>
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
		/// in the Address member of the MIB_ANYCASTIPADDRESS_ROW pointed to by the Row parameter. This error is also returned if no IPv6
		/// stack is on the local computer and an IPv6 address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OBJECT_ALREADY_EXISTS</term>
		/// <term>
		/// The object already exists. This error is returned if the Address member of the MIB_ANYCASTIPADDRESS_ROW pointed to by the Row
		/// parameter is a duplicate of an existing anycast IP address on the interface specified by the InterfaceLuid or InterfaceIndex
		/// member of the MIB_ANYCASTIPADDRESS_ROW.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CreateAnycastIpAddressEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>CreateAnycastIpAddressEntry</c> function is used to add a new anycast IP address entry on a local computer.</para>
		/// <para>
		/// The <c>Address</c> member in the MIB_ANYCASTIPADDRESS_ROW structure pointed to by the Row parameter must be initialized to a
		/// valid unicast IPv4 or IPv6 address and family. In addition, at least one of the following members in the
		/// <c>MIB_ANYCASTIPADDRESS_ROW</c> structure pointed to the Row parameter must be initialized to the interface: the
		/// <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// The <c>ScopeId</c> member of the MIB_ANYCASTIPADDRESS_ROW structure pointed to by the Row is ignored when the
		/// <c>CreateAnycastIpAddressEntry</c> function is called. The <c>ScopeId</c> member is automatically determined by the interface on
		/// which the address is added.
		/// </para>
		/// <para>
		/// The <c>CreateAnycastIpAddressEntry</c> function will fail if the anycast IP address passed in the <c>Address</c> member of the
		/// MIB_ANYCASTIPADDRESS_ROW pointed to by the Row parameter is a duplicate of an existing anycast IP address on the interface.
		/// </para>
		/// <para>
		/// The <c>CreateAnycastIpAddressEntry</c> function can only be called by a user logged on as a member of the Administrators group.
		/// If <c>CreateAnycastIpAddressEntry</c> is called by a user that is not a member of the Administrators group, the function call
		/// will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on
		/// Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of the
		/// Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a
		/// user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-createanycastipaddressentry _NETIOAPI_SUCCESS_
		// NETIOAPI_API CreateAnycastIpAddressEntry( CONST MIB_ANYCASTIPADDRESS_ROW *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "30393132-0fad-4687-b9e3-7b5cf47fbb96")]
		public static extern Win32Error CreateAnycastIpAddressEntry(ref MIB_ANYCASTIPADDRESS_ROW Row);

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
		/// SortedAddressPairCount parameters NULL, or the DestinationAddressCount was greater than 500. This error is also returned if the
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
		public static extern Win32Error CreateSortedAddressPairs([Optional] IntPtr SourceAddressList, uint SourceAddressCount, [In] SOCKADDR_IN6[] DestinationAddressList, uint DestinationAddressCount, uint AddressSortOptions, out SafeMibTableHandle SortedAddressPairList, out uint SortedAddressPairCount);

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
		public static SOCKADDR_IN6_PAIR_NATIVE[] CreateSortedAddressPairs(SOCKADDR_IN6[] DestinationAddressList)
		{
			CreateSortedAddressPairs(IntPtr.Zero, 0, DestinationAddressList, (uint)DestinationAddressList.Length, 0, out var pairs, out var cnt).ThrowIfFailed();
			return Array.ConvertAll(pairs.ToArray<SOCKADDR_IN6_PAIR>((int)cnt), up => (SOCKADDR_IN6_PAIR_NATIVE)up);
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
		/// structure. These errors include the following: if the ValidLifetime member is less than the PreferredLifetime member, if the
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
		/// <para>The <c>DeleteUnicastIpAddressEntry</c> function deletes an existing unicast IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_UNICASTIPADDRESS_ROW structure entry for an existing unicast IP address entry to delete from the local computer.
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
		/// Address member of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter was not set to a valid unicast IPv4 or IPv6
		/// address, or both the InterfaceLuid or InterfaceIndex members of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter were unspecified.
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
		/// in the Address member MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter. This error is also returned if no IPv6 stack is
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
		/// <para>The <c>DeleteUnicastIpAddressEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>DeleteUnicastIpAddressEntry</c> function is used to delete an existing MIB_UNICASTIPADDRESS_ROW structure entry on the
		/// local computer.
		/// </para>
		/// <para>
		/// On input, the <c>Address</c> member in the MIB_UNICASTIPADDRESS_ROW structure pointed to by the Row parameter must be set to a
		/// valid unicast IPv4 or IPv6 address and family. In addition, at least one of the following members in the
		/// <c>MIB_UNICASTIPADDRESS_ROW</c> structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>If the function is successful, the existing IP address represented by the Row parameter was deleted.</para>
		/// <para>
		/// The GetUnicastIpAddressTable function can be called to enumerate the unicast IP address entries on a local computer. The
		/// GetUnicastIpAddressEntry function can be called to retrieve a specific existing unicast IP address entry.
		/// </para>
		/// <para>
		/// The <c>DeleteUnicastIpAddressEntry</c> function can only be called by a user logged on as a member of the Administrators group.
		/// If <c>DeleteUnicastIpAddressEntry</c> is called by a user that is not a member of the Administrators group, the function call
		/// will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on
		/// Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of the
		/// Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a
		/// user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-deleteunicastipaddressentry _NETIOAPI_SUCCESS_
		// NETIOAPI_API DeleteUnicastIpAddressEntry( CONST MIB_UNICASTIPADDRESS_ROW *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "a630397a-ef4a-40c2-b2e7-3e85cd9e8029")]
		public static extern Win32Error DeleteUnicastIpAddressEntry(ref MIB_UNICASTIPADDRESS_ROW Row);

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
		/// <para>The <c>FlushIpPathTable</c> function flushes the IP path table on the local computer.</para>
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
		/// The address family is unspecified. When this parameter is specified, this function flushes the IP path table containing both IPv4
		/// and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function flushes the IP path table
		/// containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function flushes the IP path table
		/// containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
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
		/// <para>The <c>FlushIpPathTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>FlushIpPathTable</c> function flushes or deletes the IP path entries on a local system. The Family parameter can be used
		/// to limit the IP path entries to delete to a particular IP address family. If IP path entries for both IPv4 and IPv6 should be
		/// deleted, set the Family parameter to <c>AF_UNSPEC</c>.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// The <c>FlushIpPathTable</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>FlushIpPathTable</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista and
		/// later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-flushippathtable _NETIOAPI_SUCCESS_ NETIOAPI_API
		// FlushIpPathTable( ADDRESS_FAMILY Family );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "3b28e0cd-9cab-41ca-b58c-7632768318c2")]
		public static extern Win32Error FlushIpPathTable(ADDRESS_FAMILY Family);

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
		/// The <c>GetAnycastIpAddressEntry</c> function retrieves information for an existing anycast IP address entry on the local computer.
		/// </para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_ANYCASTIPADDRESS_ROW structure entry for an anycast IP address entry. On successful return, this structure
		/// will be updated with the properties for an existing anycast IP address.
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
		/// the InterfaceLuid or InterfaceIndex member of the MIB_ANYCASTIPADDRESS_ROW pointed to by the Row parameter is not a value on the
		/// local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if a NULL pointer is passed in the Row parameter, the Address member of the
		/// MIB_ANYCASTIPADDRESS_ROW pointed to by the Row parameter is not set to a valid anycast IPv4 or IPv6 address, or both the
		/// InterfaceLuid or InterfaceIndex members of the MIB_ANYCASTIPADDRESS_ROW pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned if the network interface specified by the InterfaceLuid or InterfaceIndex member of the
		/// MIB_ANYCASTIPADDRESS_ROW structure pointed to by the Row parameter does not match the IP address and address family specified in
		/// the Address member in the MIB_ANYCASTIPADDRESS_ROW structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address is specified
		/// in the Address member of the MIB_UNICASTIPADDRESS_ROW structure pointed to by the Row parameter. This error is returned if no
		/// IPv6 stack is on the local computer and an IPv6 address is specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetAnycastIpAddressEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>GetAnycastIpAddressEntry</c> function is used to retrieve an existing MIB_ANYCASTIPADDRESS_ROW structure entry.</para>
		/// <para>
		/// On input, the <c>Address</c> member in the MIB_ANYCASTIPADDRESS_ROW structure pointed to by the Row parameter must be initialized
		/// to a valid anycast IPv4 or IPv6 address and family. In addition, at least one of the following members in the
		/// <c>MIB_ANYCASTIPADDRESS_ROW</c> structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetAnycastIpAddressEntry</c> retrieves the other properties for the anycast IP address
		/// and fills out the MIB_ANYCASTIPADDRESS_ROW structure pointed to by the Row parameter.
		/// </para>
		/// <para>The GetAnycastIpAddressTable function can be called to enumerate the anycast IP address entries on a local computer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getanycastipaddressentry _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetAnycastIpAddressEntry( PMIB_ANYCASTIPADDRESS_ROW Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "d60828ed-e1fd-4e57-92be-08a189c27fe5")]
		public static extern Win32Error GetAnycastIpAddressEntry(ref MIB_ANYCASTIPADDRESS_ROW Row);

		/// <summary>
		/// <para>The <c>GetAnycastIpAddressTable</c> function retrieves the anycast IP address table on the local computer.</para>
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
		/// The address family is unspecified. When this parameter is specified, this function returns the anycast IP address table
		/// containing both IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns the anycast IP
		/// address table containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns the anycast IP
		/// address table containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>A pointer to a MIB_ANYCASTIPADDRESS_TABLE structure that contains a table of anycast IP address entries on the local computer.</para>
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
		/// <term>No anycast IP address entries as specified in the Family parameter were found.</term>
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
		/// <para>The <c>GetAnycastIpAddressTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetAnycastIpAddressTable</c> function enumerates the anycast IP addresses on a local system and returns this information
		/// in a MIB_ANYCASTIPADDRESS_TABLE structure.
		/// </para>
		/// <para>
		/// The anycast IP address entries are returned in a MIB_ANYCASTIPADDRESS_TABLE structure in the buffer pointed to by the Table
		/// parameter. The <c>MIB_ANYCASTIPADDRESS_TABLE</c> structure contains an anycast IP address entry count and an array of
		/// MIB_ANYCASTIPADDRESS_ROW structures for each anycast IP address entry. When these returned structures are no longer required,
		/// free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// Note that the returned MIB_ANYCASTIPADDRESS_TABLE structure pointed to by the Table parameter may contain padding for alignment
		/// between the <c>NumEntries</c> member and the first MIB_ANYCASTIPADDRESS_ROW array entry in the <c>Table</c> member of the
		/// <c>MIB_ANYCASTIPADDRESS_TABLE</c> structure. Padding for alignment may also be present between the
		/// <c>MIB_ANYCASTIPADDRESS_ROW</c> array entries. Any access to a <c>MIB_ANYCASTIPADDRESS_ROW</c> array entry should assume padding
		/// may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getanycastipaddresstable _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetAnycastIpAddressTable( ADDRESS_FAMILY Family, PMIB_ANYCASTIPADDRESS_TABLE *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "4eccae59-00be-4f9c-bb62-a507d7dad2e0")]
		public static extern Win32Error GetAnycastIpAddressTable(ADDRESS_FAMILY Family, out MIB_ANYCASTIPADDRESS_TABLE Table);

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
		public static extern Win32Error GetBestRoute2(in NET_LUID InterfaceLuid, uint InterfaceIndex, in SOCKADDR_INET SourceAddress, in SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

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
		public static extern Win32Error GetBestRoute2([Optional] IntPtr InterfaceLuid, uint InterfaceIndex, in SOCKADDR_INET SourceAddress, in SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

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
		public static extern Win32Error GetBestRoute2([Optional] IntPtr InterfaceLuid, uint InterfaceIndex, [Optional] IntPtr SourceAddress, in SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

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
		/// <para>
		/// The <c>GetIfStackTable</c> function retrieves a table of network interface stack row entries that specify the relationship of the
		/// network interfaces on an interface stack.
		/// </para>
		/// </summary>
		/// <param name="Table">
		/// <para>A pointer to a buffer that receives the table of interface stack row entries in a MIB_IFSTACK_TABLE structure.</para>
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
		/// <term>An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Table parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory resources are available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>No interface stack entries were found.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIfStackTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetIfStackTable</c> function enumerates the physical and logical network interfaces on an interface stack on a local
		/// system and returns this information in a MIB_IFSTACK_TABLE structure.
		/// </para>
		/// <para>
		/// Interface stack entries are returned in a MIB_IFSTACK_TABLE structure in the buffer pointed to by the Table parameter. The
		/// <c>MIB_IFSTACK_TABLE</c> structure contains an interface stack entry count and an array of MIB_IFSTACK_ROW structures for each
		/// interface stack entry.
		/// </para>
		/// <para>
		/// The relationship between the interfaces in the interface stack is that the interface with index in the
		/// <c>HigherLayerInterfaceIndex</c> member of the MIB_IFSTACK_ROW structure is immediately above the interface with index in the
		/// <c>LowerLayerInterfaceIndex</c> member of the <c>MIB_IFSTACK_ROW</c> structure.
		/// </para>
		/// <para>
		/// Memory is allocated by the <c>GetIfStackTable</c> function for the MIB_IFSTACK_TABLE structure and the MIB_IFSTACK_ROW entries in
		/// this structure. When these returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>
		/// Note that the returned MIB_IFSTACK_TABLE structure pointed to by the Table parameter may contain padding for alignment between
		/// the <c>NumEntries</c> member and the first MIB_IFSTACK_ROW array entry in the <c>Table</c> member of the <c>MIB_IFSTACK_TABLE</c>
		/// structure. Padding for alignment may also be present between the <c>MIB_IFSTACK_ROW</c> array entries. Any access to a
		/// <c>MIB_IFSTACK_ROW</c> array entry should assume padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getifstacktable _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIfStackTable( PMIB_IFSTACK_TABLE *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "c1b0f091-2aef-447e-9866-a886838a6267")]
		public static extern Win32Error GetIfStackTable(out MIB_IFSTACK_TABLE Table);

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
		public static extern Win32Error GetIfTable2(out MIB_IF_TABLE2 Table);

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
		public static extern Win32Error GetIfTable2Ex(MIB_IF_TABLE_LEVEL Level, out MIB_IF_TABLE2 Table);

		/// <summary>
		/// <para>
		/// The <c>GetInvertedIfStackTable</c> function retrieves a table of inverted network interface stack row entries that specify the
		/// relationship of the network interfaces on an interface stack.
		/// </para>
		/// </summary>
		/// <param name="Table">
		/// <para>A pointer to a buffer that receives the table of inverted interface stack row entries in a MIB_INVERTEDIFSTACK_TABLE structure.</para>
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
		/// <term>An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Table parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory resources are available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>No interface stack entries were found.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetInvertedIfStackTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetInvertedIfStackTable</c> function enumerates the physical and logical network interfaces on an interface stack on a
		/// local system and returns this information in an inverted form in the MIB_INVERTEDIFSTACK_TABLE structure.
		/// </para>
		/// <para>
		/// Interface stack entries are returned in a MIB_INVERTEDIFSTACK_TABLE structure in the buffer pointed to by the Table parameter.
		/// The <c>MIB_INVERTEDIFSTACK_TABLE</c> structure contains an interface stack entry count and an array of MIB_INVERTEDIFSTACK_ROW
		/// structures for each interface stack entry.
		/// </para>
		/// <para>
		/// The relationship between the interfaces in the interface stack is that the interface with index in the
		/// <c>HigherLayerInterfaceIndex</c> member of the MIB_INVERTEDIFSTACK_ROW structure is immediately above the interface with index in
		/// the <c>LowerLayerInterfaceIndex</c> member of the <c>MIB_INVERTEDIFSTACK_ROW</c> structure.
		/// </para>
		/// <para>
		/// Memory is allocated by the <c>GetInvertedIfStackTable</c> function for the MIB_INVERTEDIFSTACK_TABLE structure and the
		/// MIB_INVERTEDIFSTACK_ROW entries in this structure. When these returned structures are no longer required, free the memory by
		/// calling the FreeMibTable.
		/// </para>
		/// <para>
		/// Note that the returned MIB_INVERTEDIFSTACK_TABLE structure pointed to by the Table parameter may contain padding for alignment
		/// between the <c>NumEntries</c> member and the first MIB_INVERTEDIFSTACK_ROW array entry in the <c>Table</c> member of the
		/// <c>MIB_INVERTEDIFSTACK_TABLE</c> structure. Padding for alignment may also be present between the <c>MIB_INVERTEDIFSTACK_ROW</c>
		/// array entries. Any access to a <c>MIB_INVERTEDIFSTACK_ROW</c> array entry should assume padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getinvertedifstacktable _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetInvertedIfStackTable( PMIB_INVERTEDIFSTACK_TABLE *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "d1808ded-2798-46cc-8021-fdbcd3da60ea")]
		public static extern Win32Error GetInvertedIfStackTable(out MIB_INVERTEDIFSTACK_TABLE Table);

		/// <summary>
		/// <para>The <c>GetIpForwardEntry2</c> function retrieves information for an IP route entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPFORWARD_ROW2 structure entry for an IP route entry. On successful return, this structure will be updated
		/// with the properties for the IP route entry.
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
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// DestinationPrefix member of the MIB_IPFORWARD_ROW2 pointed to by the Row parameter was not specified, the NextHop member of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Row parameter was not specified, or both the InterfaceLuid or InterfaceIndex members of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned if the network interface specified by the InterfaceLuid or InterfaceIndex member of the
		/// MIB_IPFORWARD_ROW2 structure pointed to by the Row parameter does not match the IP address prefix and address family specified in
		/// the DestinationPrefix member in the MIB_IPFORWARD_ROW2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and AF_INET was specified in the
		/// address family in the DestinationPrefix member of the MIB_IPFORWARD_ROW2 pointed to by the Row parameter. This error is also
		/// returned if no IPv6 stack is on the local computer and AF_INET6 was specified for the address family in the DestinationPrefix member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpForwardEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>GetIpForwardEntry2</c> function is used to retrieve a MIB_IPFORWARD_ROW2 structure entry.</para>
		/// <para>
		/// On input, the <c>DestinationPrefix</c> member in the MIB_IPFORWARD_ROW2 structure pointed to by the Row parameter must be
		/// initialized to a valid IPv4 or IPv6 address prefix and family. On input, the <c>NextHop</c> member in the
		/// <c>MIB_IPFORWARD_ROW2</c> structure pointed to by the Row parameter must be initialized to a valid IPv4 or IPv6 address and
		/// family. In addition, at least one of the following members in the <c>MIB_IPFORWARD_ROW2</c> structure pointed to the Row
		/// parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetIpForwardEntry2</c> retrieves the other properties for the IP route entry and fills
		/// out the MIB_IPFORWARD_ROW2 structure pointed to by the Row parameter.
		/// </para>
		/// <para>
		/// The route metric offset specified in the <c>Metric</c> member of the MIB_IPFORWARD_ROW2 structure pointed to by Row parameter
		/// represents only part of the complete route metric. The complete metric is a combination of this route metric added to the
		/// interface metric specified in the <c>Metric</c> member of the MIB_IPINTERFACE_ROW structure of the associated interface. An
		/// application can retrieve the interface metric by calling the GetIpInterfaceEntry function.
		/// </para>
		/// <para>The GetIpForwardTable2 function can be called to enumerate the IP route entries on a local computer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getipforwardentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpForwardEntry2( PMIB_IPFORWARD_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "53d5009a-d205-40ce-88e5-fe37e72b5a50")]
		public static extern Win32Error GetIpForwardEntry2(ref MIB_IPFORWARD_ROW2 Row);

		/// <summary>
		/// <para>The <c>GetIpForwardTable2</c> function retrieves the IP route entries on the local computer.</para>
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
		/// The address family is unspecified. When this parameter is specified, this function returns the IP routing table containing both
		/// IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns the IP routing
		/// table containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns the IP routing
		/// table containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>A pointer to a MIB_IPFORWARD_TABLE2 structure that contains a table of IP route entries on the local computer.</para>
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
		/// <term>No IP route entries as specified in the Family parameter were found.</term>
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
		/// <para>The <c>GetIpForwardTable2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetIpForwardTable2</c> function enumerates the IP route entries on a local system and returns this information in a
		/// MIB_IPFORWARD_TABLE2 structure.
		/// </para>
		/// <para>
		/// The IP route entries are returned in a MIB_IPFORWARD_TABLE2 structure in the buffer pointed to by the Table parameter. The
		/// <c>MIB_IPFORWARD_TABLE2</c> structure contains an IP route entry count and an array of MIB_IPFORWARD_ROW2 structures for each IP
		/// route entry. When these returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// Note that the returned MIB_IPFORWARD_TABLE2 structure pointed to by the Table parameter may contain padding for alignment between
		/// the <c>NumEntries</c> member and the first MIB_IPFORWARD_ROW2 array entry in the <c>Table</c> member of the
		/// <c>MIB_IPFORWARD_TABLE2</c> structure. Padding for alignment may also be present between the <c>MIB_IPFORWARD_ROW2</c> array
		/// entries. Any access to a <c>MIB_IPFORWARD_ROW2</c> array entry should assume padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getipforwardtable2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpForwardTable2( ADDRESS_FAMILY Family, PMIB_IPFORWARD_TABLE2 *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "14412ef1-d970-419d-abfa-389f6ceb638d")]
		public static extern Win32Error GetIpForwardTable2(ADDRESS_FAMILY Family, out MIB_IPFORWARD_TABLE2 Table);

		/// <summary>
		/// <para>The <c>GetIpInterfaceEntry</c> function retrieves IP information for the specified interface on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPINTERFACE_ROW structure that, on successful return, receives information for an interface on the local
		/// computer. On input, the <c>InterfaceLuid</c> or <c>InterfaceIndex</c> member of the <c>MIB_IPINTERFACE_ROW</c> must be set to the
		/// interface for which to retrieve information.
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
		/// the InterfaceLuid or InterfaceIndex member of the MIB_IPINTERFACE_ROW pointed to by the Row parameter was not a value on the
		/// local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Family member of the MIB_IPINTERFACE_ROW pointed to by the Row parameter was not specified as AF_INET or AF_INET6, or both the
		/// InterfaceLuid or InterfaceIndex members of the MIB_IPINTERFACE_ROW pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned if the network interface specified by the InterfaceLuid or InterfaceIndex member of the
		/// MIB_IPINTERFACE_ROW structure pointed to by the Row parameter does not match the IP address family specified in the Family member
		/// in the MIB_IPINTERFACE_ROW structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpInterfaceEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// On input, the <c>Family</c> member in the MIB_IPINTERFACE_ROW structure pointed to by the Row parameter must be initialized to
		/// either <c>AF_INET</c> or <c>AF_INET6</c>. In addition on input, at least one of the following members in the
		/// <c>MIB_IPINTERFACE_ROW</c> structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// On output, the <c>InterfaceLuid</c> member of the MIB_IPINTERFACE_ROW structure pointed to by the Row parameter is filled in if
		/// the <c>InterfaceIndex</c> was specified. The other members of <c>MIB_IPINTERFACE_ROW</c> structure pointed to by the Row
		/// parameter are also filled in.
		/// </para>
		/// <para>
		/// The InitializeIpInterfaceEntry function must be used to initialize the fields of a MIB_IPINTERFACE_ROW structure entry with
		/// default values. An application can then change the fields in the <c>MIB_IPINTERFACE_ROW</c> entry it wishes to modify, and then
		/// call the SetIpInterfaceEntry function.
		/// </para>
		/// <para>
		/// Unprivileged simultaneous access to multiple networks of different security requirements creates a security hole and allows an
		/// unprivileged application to accidentally relay data between the two networks. A typical example is simultaneous access to a
		/// virtual private network (VPN) and the Internet. Windows Server 2003 and Windows XP use a weak host model, where RAS prevents such
		/// simultaneous access by increasing the route metric of all default routes over other interfaces. Thus all traffic is routed
		/// through the VPN interface, disrupting other network connectivity.
		/// </para>
		/// <para>
		/// On Windows Vista and later, a strong host model is used by default. If a source IP address is specified in the route lookup using
		/// GetBestRoute2 or GetBestRoute, the route lookup is restricted to the interface of the source IP address. The route metric
		/// modification by RAS has no effect as the list of potential routes does not even have the route for the VPN interface thereby
		/// allowing traffic to the Internet. The <c>DisableDefaultRoutes</c> member of the MIB_IPINTERFACE_ROW can be used to disable using
		/// the default route on an interface. This member can be used as a security measure by VPN clients to restrict split tunneling when
		/// split tunneling is not required by the VPN client. A VPN client can call the SetIpInterfaceEntry function to set the
		/// <c>DisableDefaultRoutes</c> member to <c>TRUE</c> when required. A VPN client can query the current state of the
		/// <c>DisableDefaultRoutes</c> member by calling the <c>GetIpInterfaceEntry</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getipinterfaceentry _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpInterfaceEntry( PMIB_IPINTERFACE_ROW Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "604e33fd-ab12-4861-a083-544045f46ef4")]
		public static extern Win32Error GetIpInterfaceEntry(ref MIB_IPINTERFACE_ROW Row);

		/// <summary>
		/// <para>The <c>GetIpInterfaceTable</c> function retrieves the IP interface entries on the local computer.</para>
		/// </summary>
		/// <param name="Family">
		/// <para>The address family of IP interfaces to retrieve.</para>
		/// <para>
		/// Possible values for the address family are listed in the Winsock2.h header file. Note that the values for the AF_ address family
		/// and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>
		/// On Windows Vista and later as well as on the Windows SDK, the organization of header files has changed and possible values for
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
		/// The address family is unspecified. When this parameter is specified, the GetIpInterfaceTable function returns the IP interface
		/// table containing both IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>The Internet Protocol version 4 (IPv4) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>The Internet Protocol version 6 (IPv6) address family.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>A pointer to a buffer that receives the table of IP interface entries in a MIB_IPINTERFACE_TABLE structure.</para>
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
		/// <term>No IP interface entries as specified in the Family parameter were found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The function is not supported. This error is returned when the IP transport specified in the Address parameter is not configured
		/// on the local computer. This error is also returned on versions of Windows where this function is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpInterfaceTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetIpInterfaceTable</c> function enumerates the IP interfaces on a local system and returns this information in an
		/// MIB_IPINTERFACE_TABLE structure.
		/// </para>
		/// <para>
		/// IP interface entries are returned in a MIB_IPINTERFACE_TABLE structure in the buffer pointed to by the Table parameter. The
		/// <c>MIB_IPINTERFACE_TABLE</c> structure contains an IP interface entry count and an array of MIB_IPINTERFACE_ROW structures for
		/// each IP interface entry. When these returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c> or <c>AF_INET6</c>.</para>
		/// <para>
		/// Note that the returned MIB_IPINTERFACE_TABLE structure pointed to by the Table parameter may contain padding for alignment
		/// between the <c>NumEntries</c> member and the first MIB_IPINTERFACE_ROW array entry in the <c>Table</c> member of the
		/// <c>MIB_IPINTERFACE_TABLE</c> structure. Padding for alignment may also be present between the <c>MIB_IPINTERFACE_ROW</c> array
		/// entries. Any access to a <c>MIB_IPINTERFACE_ROW</c> array entry should assume padding may exist.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the IP interface table, then prints the values of a few members of the IP interface entries in
		/// the table.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getipinterfacetable _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpInterfaceTable( ADDRESS_FAMILY Family, PMIB_IPINTERFACE_TABLE *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "09f2bbff-3281-41ae-878f-61c5afa20ec5")]
		public static extern Win32Error GetIpInterfaceTable(ADDRESS_FAMILY Family, out MIB_IPINTERFACE_TABLE Table);

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
		/// <para>
		/// The <c>GetIpNetworkConnectionBandwidthEstimates</c> function retrieves historical bandwidth estimates for a network connection on
		/// the specified interface.
		/// </para>
		/// </summary>
		/// <param name="InterfaceIndex">
		/// <para>The local index value for the network interface.</para>
		/// <para>
		/// This index value may change when a network adapter is disabled and then enabled, or under other circumstances, and should not be
		/// considered persistent.
		/// </para>
		/// </param>
		/// <param name="AddressFamily">
		/// <para>
		/// The address family. Possible values for the address family are listed in the Ws2def.h header file. Note that the values for the
		/// AF_ address family and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either
		/// constant can be used.
		/// </para>
		/// <para>Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly.</para>
		/// <para>
		/// The values currently supported are <c>AF_INET</c> or <c>AF_INET6</c>, which are the Internet address family formats for IPv4 and IPv6.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>The Internet Protocol version 4 (IPv4) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>The Internet Protocol version 6 (IPv6) address family.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="BandwidthEstimates">
		/// <para>
		/// A pointer to a buffer that returns the historical bandwidth estimates maintained for the point of attachment to which the
		/// interface is currently connected.
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
		/// The system cannot find the file specified. This error is returned if the interface index specified by the InterfaceIndex
		/// parameter was not a value on the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the BandwidthEstimates
		/// parameter or the AddressFamily parameter was not specified as AF_INET or AF_INET6.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned if the network interface specified by the InterfaceIndex parameter does not match the
		/// IP address family specified in the AddressFamily parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpNetworkConnectionBandwidthEstimates</c> function is defined on Windows 8 and later.</para>
		/// <para>
		/// On input, the AddressFamily parameter must be initialized to either <c>AF_INET</c> or <c>AF_INET6</c>. In addition on input, the
		/// InterfaceIndex parameter must be initialized with the specified interface index.
		/// </para>
		/// <para>
		/// On output, the MIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES structure pointed to by the BandwidthEstimates parameter is filled
		/// in if the AddressFamily and InterfaceIndex parameters were specified.
		/// </para>
		/// <para>
		/// The <c>GetIpNetworkConnectionBandwidthEstimates</c> function returns historical estimates of available bandwidth at the point of
		/// attachment (the first hop) for use by an application. The estimates are intended as a guide to tune performance parameters and
		/// the application should maintain thresholds and differentiate behavior for low and high bandwidth situations.
		/// </para>
		/// <para>
		/// It is possible that the true available bandwidth changes over time as more bandwidth is consumed by devices competing on the same
		/// network. So applications should be prepared to handle cases where the available bandwidth drops below historical limits reported
		/// by the <c>GetIpNetworkConnectionBandwidthEstimates</c> function.
		/// </para>
		/// <para>
		/// It is possible that the TCP/IP stack has not built up any estimates for the given interface, in a particular or both directions.
		/// In this case the estimate returned will be zero. The application should be prepared to handle such cases by picking reasonable
		/// defaults and fine tuning if required.
		/// </para>
		/// <para>
		/// The Netioapi.h header file is automatically included by the Iphlpapi.h header file. The Netioapi.h header file should never be
		/// used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getipnetworkconnectionbandwidthestimates
		// _NETIOAPI_SUCCESS_ NETIOAPI_API GetIpNetworkConnectionBandwidthEstimates( NET_IFINDEX InterfaceIndex, ADDRESS_FAMILY
		// AddressFamily, PMIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES BandwidthEstimates );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "FE60AF0D-15B0-4223-8AE1-3E65483A1C5F")]
		public static extern Win32Error GetIpNetworkConnectionBandwidthEstimates(uint InterfaceIndex, ADDRESS_FAMILY AddressFamily, out MIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES BandwidthEstimates);

		/// <summary>
		/// <para>The <c>GetIpPathEntry</c> function retrieves information for a IP path entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPPATH_ROW structure entry for a IP path entry. On successful return, this structure will be updated with the
		/// properties for IP path entry.
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
		/// the InterfaceLuid or InterfaceIndex member of the MIB_IPPATH_ROW pointed to by the Row parameter is not a value on the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if a NULL pointer is passed in the Row parameter, the si_family member in the
		/// Destination member of the MIB_IPPATH_ROW pointed to by the Row parameter is not set to AF_INET or AF_INET6, or both the
		/// InterfaceLuid or InterfaceIndex members of the MIB_IPPATH_ROW pointed to by the Row parameter are unspecified. This error is also
		/// returned if the si_family member in the Source member of the MIB_IPPATH_ROW pointed to by the Row parameter did not match the
		/// destination IP address family and the si_family for the source IP address is not specified as AF_UNSPEC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned if the network interface specified by the InterfaceLuid or InterfaceIndex member of the
		/// MIB_IPPATH_ROW structure pointed to by the Row parameter does not match the IP address and address family specified in the
		/// Destination member in the MIB_IPPATH_ROW structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address is specified
		/// in the Source and Destination members of the MIB_IPPATH_ROW pointed to by the Row parameter. This error is also returned if no
		/// IPv6 stack is on the local computer and an IPv6 address is specified in the Source and Destination members.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpPathEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>GetIpPathEntry</c> function is used to retrieve a MIB_IPPATH_ROW structure entry.</para>
		/// <para>
		/// On input, the <c>Destination</c> member in the MIB_IPPATH_ROW structure pointed to by the Row parameter must be initialized to a
		/// valid IPv4 or IPv6 address and family. The address family specified in <c>Source</c> member in the <c>MIB_IPPATH_ROW</c>
		/// structure must also either match the destination IP address family specified in the <c>Destination</c> member or the address
		/// family in the <c>Source</c> member must be specified as <c>AF_UNSPEC</c>. In addition , at least one of the following members in
		/// the <c>MIB_IPPATH_ROW</c> structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetIpPathEntry</c> retrieves the other properties for the IP path entry and fills out
		/// the MIB_IPPATH_ROW structure pointed to by the Row parameter.
		/// </para>
		/// <para>The GetIpPathTable function can be called to enumerate the IP path entries on a local computer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getippathentry _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpPathEntry( PMIB_IPPATH_ROW Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "8ad43a1d-428a-41cc-bba8-5eec7f87c11f")]
		public static extern Win32Error GetIpPathEntry(ref MIB_IPPATH_ROW Row);

		/// <summary>
		/// <para>The <c>GetIpPathTable</c> function retrieves the IP path table on the local computer.</para>
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
		/// The address family is unspecified. When this parameter is specified, this function returns the IP path table containing both IPv4
		/// and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns the IP path table
		/// containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns the IP path table
		/// containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>A pointer to a MIB_IPPATH_TABLE structure that contains a table of IP path entries on the local computer.</para>
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
		/// <term>No IP path entries as specified in the Family parameter were found.</term>
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
		/// <para>The <c>GetIpPathTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetIpPathTable</c> function enumerates the IP path entries on a local system and returns this information in a
		/// MIB_IPPATH_TABLE structure.
		/// </para>
		/// <para>
		/// The IP path entries are returned in a MIB_IPPATH_TABLE structure in the buffer pointed to by the Table parameter. The
		/// <c>MIB_IPPATH_TABLE</c> structure contains an IP path entry count and an array of MIB_IPPATH_ROW structures for each IP path
		/// entry. When these returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// Note that the returned MIB_IPPATH_TABLE structure pointed to by the Table parameter may contain padding for alignment between the
		/// <c>NumEntries</c> member and the first MIB_IPPATH_ROW array entry in the <c>Table</c> member of the <c>MIB_IPPATH_TABLE</c>
		/// structure. Padding for alignment may also be present between the <c>MIB_IPPATH_ROW</c> array entries. Any access to a
		/// <c>MIB_IPPATH_ROW</c> array entry should assume padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getippathtable _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpPathTable( ADDRESS_FAMILY Family, PMIB_IPPATH_TABLE *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "e03816a4-0b86-4e0b-a45e-8148c8ba5472")]
		public static extern Win32Error GetIpPathTable(ADDRESS_FAMILY Family, out MIB_IPPATH_TABLE Table);

		/// <summary>
		/// <para>
		/// The <c>GetMulticastIpAddressEntry</c> function retrieves information for an existing multicast IP address entry on the local computer.
		/// </para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_MULTICASTIPADDRESS_ROW structure entry for a multicast IP address entry. On successful return, this structure
		/// will be updated with the properties for an existing multicast IP address.
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
		/// the InterfaceLuid or InterfaceIndex member of the MIB_MULTICASTIPADDRESS_ROW pointed to by the Row parameter is not a value on
		/// the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if a NULL pointer is passed in the Row parameter, the Address member of the
		/// MIB_MULTICASTIPADDRESS_ROW pointed to by the Row parameter is not set to a valid multicast IPv4 or IPv6 address, or both the
		/// InterfaceLuid or InterfaceIndex members of the MIB_MULTICASTIPADDRESS_ROW pointed to by the Row parameter are unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned if the network interface specified by the InterfaceLuid or InterfaceIndex member of the
		/// MIB_MULTICASTIPADDRESS_ROW structure pointed to by the Row parameter does not match the IP address and address family specified
		/// in the Address member in the MIB_MULTICASTIPADDRESS_ROW structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address is specified
		/// in the Address member MIB_MULTICASTIPADDRESS_ROW pointed to by the Row parameter. This error is also returned if no IPv6 stack is
		/// on the local computer and an IPv6 address is specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetMulticastIpAddressEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>GetMulticastIpAddressEntry</c> function is used to retrieve an existing MIB_MULTICASTIPADDRESS_ROW structure entry.</para>
		/// <para>
		/// On input, the <c>Address</c> member in the MIB_MULTICASTIPADDRESS_ROW structure pointed to by the Row parameter must be
		/// initialized to a valid multicast IPv4 or IPv6 address and family. In addition, at least one of the following members in the
		/// <c>MIB_MULTICASTIPADDRESS_ROW</c> structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetMulticastIpAddressEntry</c> retrieves the other properties for the multicast IP
		/// address and fills out the MIB_MULTICASTIPADDRESS_ROW structure pointed to by the Row parameter.
		/// </para>
		/// <para>The GetMulticastIpAddressTable function can be called to enumerate the multicast IP address entries on a local computer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getmulticastipaddressentry _NETIOAPI_SUCCESS_
		// NETIOAPI_API GetMulticastIpAddressEntry( PMIB_MULTICASTIPADDRESS_ROW Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "dc6401b6-7692-44a5-b2f0-4e729b996765")]
		public static extern Win32Error GetMulticastIpAddressEntry(ref MIB_MULTICASTIPADDRESS_ROW Row);

		/// <summary>
		/// <para>The <c>GetMulticastIpAddressTable</c> function retrieves the multicast IP address table on the local computer.</para>
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
		/// The address family is unspecified. When this parameter is specified, this function returns the multicast IP address table
		/// containing both IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns the multicast IP
		/// address table containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns the multicast IP
		/// address table containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>
		/// A pointer to a MIB_MULTICASTIPADDRESS_TABLE structure that contains a table of anycast IP address entries on the local computer.
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
		/// <term>No anycast IP address entries as specified in the Family parameter were found.</term>
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
		/// <para>The <c>GetMulticastIpAddressTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetMulticastIpAddressTable</c> function enumerates the multicast IP addresses on a local system and returns this
		/// information in a MIB_MULTICASTIPADDRESS_TABLE structure.
		/// </para>
		/// <para>
		/// The multicast IP address entries are returned in a MIB_MULTICASTIPADDRESS_TABLE structure in the buffer pointed to by the Table
		/// parameter. The <c>MIB_MULTICASTIPADDRESS_TABLE</c> structure contains a multicast IP address entry count and an array of
		/// MIB_MULTICASTIPADDRESS_ROW structures for each multicast IP address entry. When these returned structures are no longer required,
		/// free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// Note that the returned MIB_MULTICASTIPADDRESS_TABLE structure pointed to by the Table parameter may contain padding for alignment
		/// between the <c>NumEntries</c> member and the first MIB_MULTICASTIPADDRESS_ROW array entry in the <c>Table</c> member of the
		/// <c>MIB_MULTICASTIPADDRESS_TABLE</c> structure. Padding for alignment may also be present between the
		/// <c>MIB_MULTICASTIPADDRESS_ROW</c> array entries. Any access to a <c>MIB_MULTICASTIPADDRESS_ROW</c> array entry should assume
		/// padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getmulticastipaddresstable _NETIOAPI_SUCCESS_
		// NETIOAPI_API GetMulticastIpAddressTable( ADDRESS_FAMILY Family, PMIB_MULTICASTIPADDRESS_TABLE *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "0958e92e-12ed-42e0-aa04-b8c4544f6642")]
		public static extern Win32Error GetMulticastIpAddressTable(ADDRESS_FAMILY Family, out MIB_MULTICASTIPADDRESS_TABLE Table);

		/// <summary>
		/// <para>The <c>GetTeredoPort</c> function retrieves the dynamic UDP port number used by the Teredo client on the local computer.</para>
		/// </summary>
		/// <param name="Port">
		/// <para>
		/// A pointer to the UDP port number. On successful return, this parameter will be filled with the port number used by the Teredo client.
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
		/// <term>An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Port parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_READY</term>
		/// <term>The device is not ready. This error is returned if the Teredo client is not started on the local computer.</term>
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
		/// <para>The <c>GetTeredoPort</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetTeredoPort</c> function retrieves the current UDP port number used by the Teredo client for the Teredo service port.
		/// The Teredo port is dynamic and can change any time the Teredo client is restarted on the local computer. An application can
		/// register to be notified when the Teredo service port changes by calling the NotifyTeredoPortChange function.
		/// </para>
		/// <para>
		/// The Teredo client also uses static UDP port 3544 for listening to multicast traffic sent on multicast IPv4 address 224.0.0.253 as
		/// defined in RFC 4380. For more information, see http://www.ietf.org/rfc/rfc4380.txt.
		/// </para>
		/// <para>
		/// The <c>GetTeredoPort</c> function is used primarily by firewall applications in order to configure the appropriate exceptions to
		/// allow incoming and outgoing Teredo traffic.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getteredoport _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetTeredoPort( USHORT *Port );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "59d3764d-e560-4474-a73e-ab50bbddbf07")]
		public static extern Win32Error GetTeredoPort(out ushort Port);

		/// <summary>
		/// <para>
		/// The <c>GetUnicastIpAddressEntry</c> function retrieves information for an existing unicast IP address entry on the local computer.
		/// </para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_UNICASTIPADDRESS_ROW structure entry for a unicast IP address entry. On successful return, this structure will
		/// be updated with the properties for an existing unicast IP address.
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
		/// the InterfaceLuid or InterfaceIndex member of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter is not a value on the
		/// local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if a NULL pointer is passed in the Row parameter, the Address member of the
		/// MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter is not set to a valid unicast IPv4 or IPv6 address, or both the
		/// InterfaceLuid and InterfaceIndex members of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter are unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned if the network interface specified by the InterfaceLuid or InterfaceIndex member of the
		/// MIB_UNICASTIPADDRESS_ROW structure pointed to by the Row parameter does not match the IP address specified in the Address member
		/// in the MIB_UNICASTIPADDRESS_ROW structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address is specified
		/// in the Address member of the MIB_UNICASTIPADDRESS_ROW structure pointed to by the Row parameter. This error is also returned if
		/// no IPv6 stack is on the local computer and an IPv6 address is specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetUnicastIpAddressEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetUnicastIpAddressEntry</c> function is normally used to retrieve an existing MIB_UNICASTIPADDRESS_ROW structure entry to
		/// be modified. An application can then change the members in the <c>MIB_UNICASTIPADDRESS_ROW</c> entry it wishes to modify, and
		/// then call the SetUnicastIpAddressEntry function.
		/// </para>
		/// <para>
		/// On input, the <c>Address</c> member in the MIB_UNICASTIPADDRESS_ROW structure pointed to by the Row parameter must be initialized
		/// to a valid unicast IPv4 or IPv6 address. The <c>si_family</c> member of the <c>SOCKADDR_INET</c> structure in the <c>Address</c>
		/// member must be initialized to either <c>AF_INET</c> or <c>AF_INET6</c> and the related <c>Ipv4</c> or <c>Ipv6</c> member of the
		/// <c>SOCKADDR_INET</c> structure must be set to a valid unicast IP address. In addition, at least one of the following members in
		/// the <c>MIB_UNICASTIPADDRESS_ROW</c> structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetUnicastIpAddressEntry</c> retrieves the other properties for the unicast IP address
		/// and fills out the MIB_UNICASTIPADDRESS_ROW structure pointed to by the Row parameter.
		/// </para>
		/// <para>The GetUnicastIpAddressTable function can be called to enumerate the unicast IP address entries on a local computer.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves a unicast IP address entry specified on the command line and prints some values from the
		/// retrieved MIB_UNICASTIPADDRESS_ROW structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getunicastipaddressentry _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetUnicastIpAddressEntry( PMIB_UNICASTIPADDRESS_ROW Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "d5475c09-05dd-41d7-80ff-63c52d78468c")]
		public static extern Win32Error GetUnicastIpAddressEntry(ref MIB_UNICASTIPADDRESS_ROW Row);

		/// <summary>
		/// <para>The <c>GetUnicastIpAddressTable</c> function retrieves the unicast IP address table on the local computer.</para>
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
		/// The address family is unspecified. When this parameter is specified, this function returns the unicast IP address table
		/// containing both IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns the unicast IP
		/// address table containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns the unicast IP
		/// address table containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>A pointer to a MIB_UNICASTIPADDRESS_TABLE structure that contains a table of unicast IP address entries on the local computer.</para>
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
		/// <term>Element not found. This error is returned if no unicast IP address entries as specified in the Family parameter were found.</term>
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
		/// <para>The <c>GetUnicastIpAddressTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetUnicastIpAddressTable</c> function enumerates the unicast IP addresses on a local system and returns this information
		/// in an MIB_UNICASTIPADDRESS_TABLE structure.
		/// </para>
		/// <para>
		/// The unicast IP address entries are returned in a MIB_UNICASTIPADDRESS_TABLE structure in the buffer pointed to by the Table
		/// parameter. The <c>MIB_UNICASTIPADDRESS_TABLE</c> structure contains a unicast IP address entry count and an array of
		/// MIB_UNICASTIPADDRESS_ROW structures for each unicast IP address entry. When these returned structures are no longer required,
		/// free the memory by calling the <c>FreeMibTable</c>.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// Note that the returned MIB_UNICASTIPADDRESS_TABLE structure pointed to by the Table parameter may contain padding for alignment
		/// between the <c>NumEntries</c> member and the first MIB_UNICASTIPADDRESS_ROW array entry in the <c>Table</c> member of the
		/// <c>MIB_UNICASTIPADDRESS_TABLE</c> structure. Padding for alignment may also be present between the
		/// <c>MIB_UNICASTIPADDRESS_ROW</c> array entries. Any access to a <c>MIB_UNICASTIPADDRESS_ROW</c> array entry should assume padding
		/// may exist.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves a unicast IP address table and prints some values from each of the retrieved
		/// MIB_UNICASTIPADDRESS_ROW structures.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getunicastipaddresstable _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetUnicastIpAddressTable( ADDRESS_FAMILY Family, PMIB_UNICASTIPADDRESS_TABLE *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "bdafc4a4-5f3c-4dd5-ba9b-4f6045a82652")]
		public static extern Win32Error GetUnicastIpAddressTable(ADDRESS_FAMILY Family, out MIB_UNICASTIPADDRESS_TABLE Table);

		/// <summary>
		/// <para>The <c>if_indextoname</c> function converts the local index for a network interface to the ANSI interface name.</para>
		/// </summary>
		/// <param name="InterfaceIndex">
		/// <para>The local index for a network interface.</para>
		/// </param>
		/// <param name="InterfaceName">
		/// <para>
		/// A pointer to a buffer to hold the <c>NULL</c>-terminated ANSI string containing the interface name when the function returns
		/// successfully. The length, in bytes, of the buffer pointed to by this parameter must be equal to or greater than <c>IF_NAMESIZE</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>if_indextoname</c> returns a pointer to <c>NULL</c>-terminated ANSI string containing the interface name. On
		/// failure, a <c>NULL</c> pointer is returned.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>if_indextoname</c> function is available on Windows Vista and later.</para>
		/// <para>
		/// The <c>if_indextoname</c> function maps an interface index into its corresponding name. This function is designed as part of
		/// basic socket extensions for IPv6 as described by the IETF in RFC 2553. For more information, see http://www.ietf.org/rfc/rfc2553.txt.
		/// </para>
		/// <para>
		/// The <c>if_indextoname</c> function is implemented for portability of applications with Unix environments, but the
		/// ConvertInterface functions are preferred. The <c>if_indextoname</c> function can be replaced by a call to the
		/// ConvertInterfaceIndexToLuid function to convert an interface index to a NET_LUID followed by a call to the
		/// ConvertInterfaceLuidToNameA to convert the NET_LUID to the ANSI interface name.
		/// </para>
		/// <para>If the <c>if_indextoname</c> fails and returns a <c>NULL</c> pointer, it is not possible to determine an error code.</para>
		/// <para>
		/// The length, in bytes, of the buffer pointed to by the InterfaceName parameter must be equal or greater than <c>IF_NAMESIZE</c>, a
		/// value declared in the Netioapi.h header file equal to <c>NDIS_IF_MAX_STRING_SIZE</c>. The maximum length of an interface name,
		/// <c>NDIS_IF_MAX_STRING_SIZE</c>, without the terminating <c>NULL</c> is declared in the Ntddndis.h header file. The
		/// <c>NDIS_IF_MAX_STRING_SIZE</c> is defined to be the <c>IF_MAX_STRING_SIZE</c> constant defined in the Ifdef.h header file. The
		/// Ntddndis.h and Ifdef.h header files are automatically included in the Netioapi.h header file which is automatically included by
		/// the Iphlpapi.h header file. The Ntddndis.h, Ifdef.h, and Netioapi.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-if_indextoname NETIOAPI_API_ if_indextoname( NET_IFINDEX
		// InterfaceIndex, PCHAR InterfaceName );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "0da31819-3ee7-4474-9e68-f5a18d4a135a")]
		public static extern IntPtr if_indextoname(uint InterfaceIndex, [MarshalAs(UnmanagedType.LPStr)] StringBuilder InterfaceName);

		/// <summary>
		/// The <c>if_nametoindex</c> function converts the ANSI interface name for a network interface to the local index for the interface.
		/// </summary>
		/// <param name="InterfaceName">A pointer to a <c>NULL</c>-terminated ANSI string containing the interface name.</param>
		/// <returns>On success, <c>if_nametoindex</c> returns the local interface index. On failure, zero is returned.</returns>
		// NET_IFINDEX WINAPI if_nametoindex( _In_ PCSTR InterfaceName); https://msdn.microsoft.com/en-us/library/windows/desktop/bb408409(v=vs.85).aspx
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Netioapi.h", MSDNShortId = "bb408409")]
		public static extern uint if_nametoindex([In, MarshalAs(UnmanagedType.LPStr)] string InterfaceName);

		/// <summary>
		/// <para>
		/// The <c>InitializeIpForwardEntry</c> function initializes a <c>MIB_IPFORWARD_ROW2</c> structure with default values for an IP
		/// route entry on the local computer.
		/// </para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// On entry, a pointer to a MIB_IPFORWARD_ROW2 structure entry for an IP route entry. On return, the <c>MIB_IPFORWARD_ROW2</c>
		/// structure pointed to by this parameter is initialized with default values for an IP route entry.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InitializeIpForwardEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>InitializeIpForwardEntry</c> function must be used to initialize the members of a MIB_IPFORWARD_ROW2 structure entry with
		/// default values for an IP route entry for later use with the CreateIpForwardEntry2 function.
		/// </para>
		/// <para>On input, <c>InitializeIpForwardEntry</c> must be passed a new MIB_IPFORWARD_ROW2 structure to initialize.</para>
		/// <para>
		/// On output, the <c>ValidLifetime</c> and <c>PreferredLifetime</c> members of the MIB_IPFORWARD_ROW2 structure pointed to by Row
		/// parameter will be initialized to infinite and the <c>Loopback</c>, <c>AutoconfigureAddress</c>, <c>Publish</c>, and
		/// <c>Immortal</c> members will be initialized to <c>TRUE</c>. In addition, the <c>SitePrefixLength</c>, <c>Metric</c>, and
		/// <c>Protocol</c> members are set to an illegal value and other fields are initialized to zero.
		/// </para>
		/// <para>
		/// After calling <c>InitializeIpForwardEntry</c>, an application can then change the members in the MIB_IPFORWARD_ROW2 entry it
		/// wishes to modify, and then call the CreateIpForwardEntry2 to add the new IP route entry to the local computer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-initializeipforwardentry VOID NETIOAPI_API_
		// InitializeIpForwardEntry( PMIB_IPFORWARD_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "1968c4e5-4b28-4387-a918-3326bc80bb3e")]
		public static extern void InitializeIpForwardEntry(out MIB_IPFORWARD_ROW2 Row);

		/// <summary>
		/// The <c>InitializeIpInterfaceEntry</c> function initializes the members of an <c>MIB_IPINTERFACE_ROW</c> structure entry with
		/// default values.
		/// </summary>
		/// <param name="Row">
		/// A pointer to a <c>MIB_IPINTERFACE_ROW</c> structure to initialize. On successful return, the fields in this parameter are
		/// initialized with default information for an interface on the local computer.
		/// </param>
		/// <returns>
		/// <para><c>InitializeIpInterfaceEntry</c> returns STATUS_SUCCESS if the function succeeds.</para>
		/// <para>If the function fails, <c>InitializeIpInterfaceEntry</c> returns one of the following error codes:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// VOID NETIOAPI_API_ InitializeIpInterfaceEntry( _Inout_ PMIB_IPINTERFACE_ROW Row); https://msdn.microsoft.com/en-us/library/windows/hardware/ff554883(v=vs.85).aspx
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Netioapi.h", MSDNShortId = "ff554883")]
		public static extern void InitializeIpInterfaceEntry(out MIB_IPINTERFACE_ROW Row);

		/// <summary>
		/// <para>
		/// The <c>InitializeUnicastIpAddressEntry</c> function initializes a <c>MIB_UNICASTIPADDRESS_ROW</c> structure with default values
		/// for a unicast IP address entry on the local computer.
		/// </para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// On entry, a pointer to a MIB_UNICASTIPADDRESS_ROW structure entry for a unicast IP address entry. On return, the
		/// <c>MIB_UNICASTIPADDRESS_ROW</c> structure pointed to by this parameter is initialized with default values for a unicast IP address.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InitializeUnicastIpAddressEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>InitializeUnicastIpAddressEntry</c> function must be used to initialize the members of a MIB_UNICASTIPADDRESS_ROW
		/// structure entry with default values for a unicast IP address for later use with the CreateUnicastIpAddressEntry function.
		/// </para>
		/// <para>On input, <c>InitializeUnicastIpAddressEntry</c> must be passed a new MIB_UNICASTIPADDRESS_ROW structure to initialize.</para>
		/// <para>
		/// On output, the <c>PrefixOrigin</c> member of the MIB_UNICASTIPADDRESS_ROW structure pointed to by Row parameter the will be
		/// initialized to <c>IpPrefixOriginUnchanged</c>, the <c>SuffixOrigin</c> member will be initialized to
		/// <c>IpSuffixOriginUnchanged</c>, and the <c>OnLinkPrefixLength</c> member will be initialized to an illegal value. In addition,
		/// the <c>PreferredLifetime</c> and <c>ValidLifetime</c> members are set to infinite, the <c>SkipAsSource</c> member is set to
		/// <c>FALSE</c>, and other fields are initialized to zero.
		/// </para>
		/// <para>
		/// After calling <c>InitializeUnicastIpAddressEntry</c>, an application can then change the members in the MIB_UNICASTIPADDRESS_ROW
		/// entry it wishes to modify, and then call the CreateUnicastIpAddressEntry to add the new unicast IP address to the local computer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-initializeunicastipaddressentry VOID NETIOAPI_API_
		// InitializeUnicastIpAddressEntry( PMIB_UNICASTIPADDRESS_ROW Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "8cbdd972-060a-4e18-9490-450df21936ea")]
		public static extern void InitializeUnicastIpAddressEntry(out MIB_UNICASTIPADDRESS_ROW Row);

		/// <summary>
		/// <para>
		/// The <c>NotifyIpInterfaceChange</c> function registers to be notified for changes to all IP interfaces, IPv4 interfaces, or IPv6
		/// interfaces on a local computer.
		/// </para>
		/// </summary>
		/// <param name="Family">
		/// <para>The address family on which to register for change notifications.</para>
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
		/// The address family is unspecified. When this parameter is specified, this function registers for both IPv4 and IPv6 change notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function register for only IPv4
		/// change notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function registers for only IPv6
		/// change notifications.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Callback">
		/// <para>
		/// A pointer to the function to call when a change occurs. This function will be invoked when an interface notification is received.
		/// </para>
		/// </param>
		/// <param name="CallerContext">
		/// <para>A user context passed to the callback function specified in the Callback parameter when an interface notification is received.</para>
		/// </param>
		/// <param name="InitialNotification">
		/// <para>
		/// A value that indicates whether the callback should be invoked immediately after registration for change notification completes.
		/// This initial notification does not indicate a change occurred to an IP interface. The purpose of this parameter to provide
		/// confirmation that the callback is registered.
		/// </para>
		/// </param>
		/// <param name="NotificationHandle">
		/// <para>
		/// A pointer used to return a handle that can be later used to deregister the change notification. On success, a notification handle
		/// is returned in this parameter. If an error occurs, <c>NULL</c> is returned.
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
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>An internal error occurred where an invalid handle was encountered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the Family parameter was not either AF_INET, AF_INET6,
		/// or AF_UNSPEC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NotifyIpInterfaceChange</c> function is defined on Windows Vista and later.</para>
		/// <para>The Family parameter must be set to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// The invocation of the callback function specified in the Callback parameter is serialized. The callback function should be
		/// defined as a function of type <c>VOID</c>. The parameters passed to the callback function include the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID CallerContext</term>
		/// <term>The CallerContext parameter passed to the NotifyIpInterfaceChange function when registering for notifications.</term>
		/// </item>
		/// <item>
		/// <term>IN PMIB_IPINTERFACE_ROW Row OPTIONAL</term>
		/// <term>
		/// A pointer to the MIB_IPINTERFACE_ROW entry for the interface that was changed. This parameter is a NULL pointer when the
		/// MIB_NOTIFICATION_TYPE value passed in the NotificationType parameter to the callback function is set to MibInitialNotification.
		/// This can only occur if the InitialNotification parameter passed to NotifyIpInterfaceChange was set to TRUE when registering for notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN MIB_NOTIFICATION_TYPE NotificationType</term>
		/// <term>
		/// The notification type. This member can be one of the values from the MIB_NOTIFICATION_TYPE enumeration type defined in the
		/// Netioapi.h header file.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the Callback parameter must be implemented in the same process as the application calling the
		/// <c>NotifyIpInterfaceChange</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before
		/// calling the <c>NotifyIpInterfaceChange</c> function to register for change notifications.
		/// </para>
		/// <para>
		/// When the callback function is received when a change occurs and the Row parameter is not <c>NULL</c>, the pointer to the
		/// MIB_IPINTERFACE_ROW structure passed in the Row parameter contains incomplete data. The information returned in the
		/// <c>MIB_IPINTERFACE_ROW</c> structure is only enough information that an application can call the GetIpInterfaceEntry function to
		/// query complete information on the IP interface that changed. When the callback function is received, an application should
		/// allocate a <c>MIB_IPINTERFACE_ROW</c> structure and initialize it with the <c>Family</c>, <c>InterfaceLuid</c> and
		/// <c>InterfaceIndex</c> members in the <c>MIB_IPINTERFACE_ROW</c> structure pointed to by the Row parameter received. A pointer to
		/// this newly initialized <c>MIB_IPINTERFACE_ROW</c> structure should be passed to the <c>GetIpInterfaceEntry</c> function to
		/// retrieve complete information on the IP interface that was changed.
		/// </para>
		/// <para>
		/// The memory pointed to by the Row parameter used in the callback indications is managed by the operating system. An application
		/// that receives a notification should never attempt to free the memory pointed to by the Row parameter.
		/// </para>
		/// <para>
		/// To deregister for change notifications, call the CancelMibChangeNotify2 function passing the NotificationHandle parameter
		/// returned by <c>NotifyIpInterfaceChange</c>.
		/// </para>
		/// <para>
		/// An application cannot make a call to the CancelMibChangeNotify2 function from the context of the thread which is currently
		/// executing the notification callback function for the same NotificationHandle parameter. Otherwise, the thread executing that
		/// callback will result in deadlock. So the <c>CancelMibChangeNotify2</c> function must not be called directly as part of the
		/// notification callback routine. In a more general situation, a thread that executes the <c>CancelMibChangeNotify2</c> function
		/// cannot own a resource on which the thread that executes a notification callback operation would wait because it would result in a
		/// similar deadlock. The <c>CancelMibChangeNotify2</c> function should be called from a different thread, on which the thread that
		/// receives the notification callback doesn’t have dependencies on.
		/// </para>
		/// <para>
		/// Once the <c>NotifyIpInterfaceChange</c> function is called to register for change notifications, these notifications will
		/// continue to be sent until the application deregisters for change notifications or the application terminates. If the application
		/// terminates, the system will automatically deregister any registration for change notifications. It is still recommended that an
		/// application explicitly deregister for change notifications before it terminates.
		/// </para>
		/// <para>Any registration for change notifications does not persist across a system shut down or reboot.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-notifyipinterfacechange _NETIOAPI_SUCCESS_ NETIOAPI_API
		// NotifyIpInterfaceChange( ADDRESS_FAMILY Family, PIPINTERFACE_CHANGE_CALLBACK Callback, PVOID CallerContext, BOOLEAN
		// InitialNotification, HANDLE *NotificationHandle );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "745128cf-7737-4f95-9712-26e0f6ae39b4")]
		public static extern Win32Error NotifyIpInterfaceChange(ADDRESS_FAMILY Family, PIPINTERFACE_CHANGE_CALLBACK Callback, [Optional] IntPtr CallerContext, [MarshalAs(UnmanagedType.U1)] bool InitialNotification, out IntPtr NotificationHandle);

		/// <summary>
		/// <para>The <c>NotifyRouteChange2</c> function registers to be notified for changes to IP route entries on a local computer.</para>
		/// </summary>
		/// <param name="AddressFamily">
		/// <para>The address family on which to register for change notifications.</para>
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
		/// <term>AF_INET</term>
		/// <term>Register for only IPv4 route change notifications.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>Register for only IPv6 route change notifications.</term>
		/// </item>
		/// <item>
		/// <term>AF_UNSPEC</term>
		/// <term>Register for both IPv4 and IPv6 route change notifications.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Callback">
		/// <para>
		/// A pointer to the function to call when a change occurs. This function will be invoked when an IP route notification is received.
		/// </para>
		/// </param>
		/// <param name="CallerContext">
		/// <para>A user context passed to the callback function specified in the Callback parameter when an interface notification is received.</para>
		/// </param>
		/// <param name="InitialNotification">
		/// <para>
		/// A value that indicates whether the callback should be invoked immediately after registration for change notification completes.
		/// This initial notification does not indicate a change occurred to an IP route entry. The purpose of this parameter to provide
		/// confirmation that the callback is registered.
		/// </para>
		/// </param>
		/// <param name="NotificationHandle">
		/// <para>
		/// A pointer used to return a handle that can be later used to deregister the change notification. On success, a notification handle
		/// is returned in this parameter. If an error occurs, <c>NULL</c> is returned.
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
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>An internal error occurred where an invalid handle was encountered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the Family parameter was not either AF_INET, AF_INET6,
		/// or AF_UNSPEC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NotifyRouteChange2</c> function is defined on Windows Vista and later.</para>
		/// <para>The Family parameter must be set to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// The invocation of the callback function specified in the Callback parameter is serialized. The callback function should be
		/// defined as a function of type <c>VOID</c>. The parameters passed to the callback function include the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID CallerContext</term>
		/// <term>The CallerContext parameter passed to the NotifyRouteChange2 function when registering for notifications.</term>
		/// </item>
		/// <item>
		/// <term>IN PMIB_IPFORWARD_ROW2 Row OPTIONAL</term>
		/// <term>
		/// A pointer to the MIB_IPFORWARD_ROW2 entry for the IP route entry that was changed. This parameter is a NULL pointer when the
		/// MIB_NOTIFICATION_TYPE value passed in the NotificationType parameter to the callback function is set to MibInitialNotification.
		/// This can only occur if the InitialNotification parameter passed to NotifyRouteChange2 was set to TRUE when registering for notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN MIB_NOTIFICATION_TYPE NotificationType</term>
		/// <term>
		/// The notification type. This member can be one of the values from the MIB_NOTIFICATION_TYPE enumeration type defined in the
		/// Netioapi.h header file.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the Callback parameter must be implemented in the same process as the application calling the
		/// <c>NotifyRouteChange2</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before calling
		/// the <c>NotifyRouteChange2</c> function to register for change notifications.
		/// </para>
		/// <para>
		/// When the callback function is received when a change occurs and the Row parameter is not <c>NULL</c>, the pointer to the
		/// MIB_IPFORWARD_ROW2 structure passed in the Row parameter contains incomplete data. The information returned in the
		/// <c>MIB_IPFORWARD_ROW2</c> structure is only enough information that an application can call the GetIpForwardEntry2 function to
		/// query complete information on the IP route that changed. When the callback function is received, an application should allocate a
		/// <c>MIB_IPFORWARD_ROW2</c> structure and initialize it with the <c>DestinationPrefix</c>, <c>NextHop</c>, <c>InterfaceLuid</c> and
		/// <c>InterfaceIndex</c> members in the <c>MIB_IPFORWARD_ROW2</c> structure pointed to by the Row parameter received. A pointer to
		/// this newly initialized <c>MIB_IPFORWARD_ROW2</c> structure should be passed to the <c>GetIpForwardEntry2</c> function to retrieve
		/// complete information on the IP route that was changed.
		/// </para>
		/// <para>
		/// The memory pointed to by the Row parameter used in the callback indications is managed by the operating system. An application
		/// that receives a notification should never attempt to free the memory pointed to by the Row parameter.
		/// </para>
		/// <para>
		/// Once the <c>NotifyRouteChange2</c> function is called to register for change notifications, these notifications will continue to
		/// be sent until the application deregisters for change notifications or the application terminates. If the application terminates,
		/// the system will automatically deregister any registration for change notifications. It is still recommended that an application
		/// explicitly deregister for change notifications before it terminates.
		/// </para>
		/// <para>Any registration for change notifications does not persist if the system is shutdown or rebooted.</para>
		/// <para>
		/// To deregister for change notifications, call the CancelMibChangeNotify2 function passing the NotificationHandle parameter
		/// returned by <c>NotifyRouteChange2</c>.
		/// </para>
		/// <para>
		/// An application cannot make a call to the CancelMibChangeNotify2 function from the context of the thread which is currently
		/// executing the notification callback function for the same NotificationHandle parameter. Otherwise, the thread executing that
		/// callback will result in deadlock. So the <c>CancelMibChangeNotify2</c> function must not be called directly as part of the
		/// notification callback routine. In a more general situation, a thread that executes the <c>CancelMibChangeNotify2</c> function
		/// cannot own a resource on which the thread that executes a notification callback operation would wait because it would result in a
		/// similar deadlock. The <c>CancelMibChangeNotify2</c> function should be called from a different thread, on which the thread that
		/// receives the notification callback doesn’t have dependencies on.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-notifyroutechange2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// NotifyRouteChange2( ADDRESS_FAMILY AddressFamily, PIPFORWARD_CHANGE_CALLBACK Callback, PVOID CallerContext, BOOLEAN
		// InitialNotification, HANDLE *NotificationHandle );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "f104dc0c-b3e0-4f22-ac5f-5dbf967be31b")]
		public static extern Win32Error NotifyRouteChange2(ADDRESS_FAMILY AddressFamily, PIPFORWARD_CHANGE_CALLBACK Callback, [Optional] IntPtr CallerContext, [MarshalAs(UnmanagedType.U1)] bool InitialNotification, out IntPtr NotificationHandle);

		/// <summary>
		/// <para>The <c>NotifyStableUnicastIpAddressTable</c> function retrieves the stable unicast IP address table on a local computer.</para>
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
		/// The address family is unspecified. When this parameter is specified, the function retrieves the stable unicast IP address table
		/// containing both IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, the function retrieves the stable
		/// unicast IP address table containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, the function retrieves the stable
		/// unicast IP address table containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>
		/// A pointer to a MIB_UNICASTIPADDRESS_TABLE structure. When <c>NotifyStableUnicastIpAddressTable</c> is successful, this parameter
		/// returns the stable unicast IP address table on the local computer.
		/// </para>
		/// <para>
		/// When <c>NotifyStableUnicastIpAddressTable</c> returns <c>ERROR_IO_PENDING</c> indicating that the I/O request is pending, then
		/// the stable unicast IP address table is returned to the function in the CallerCallback parameter.
		/// </para>
		/// </param>
		/// <param name="CallerCallback">
		/// <para>
		/// A pointer to the function to call with the stable unicast IP address table. This function will be invoked if
		/// <c>NotifyStableUnicastIpAddressTable</c> returns <c>ERROR_IO_PENDING</c>, indicating that the I/O request is pending.
		/// </para>
		/// </param>
		/// <param name="CallerContext">
		/// <para>
		/// A user context passed to the callback function specified in the CallerCallback parameter when the stable unicast IP address table
		/// is available.
		/// </para>
		/// </param>
		/// <param name="NotificationHandle">
		/// <para>
		/// A pointer used to return a handle that can be used to cancel the request to retrieve the stable unicast IP address table. This
		/// parameter is returned if the return value from <c>NotifyStableUnicastIpAddressTable</c> is <c>ERROR_IO_PENDING</c> indicating
		/// that the I/O request is pending.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds immediately, the return value is NO_ERROR and the stable unicast IP table is returned in the Table parameter.
		/// </para>
		/// <para>
		/// If the I/O request is pending, the function returns <c>ERROR_IO_PENDING</c> and the function pointed to by the CallerCallback
		/// parameter is called when the I/O request has completed with the stable unicast IP address table.
		/// </para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>An internal error occurred where an invalid handle was encountered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the Table parameter was a NULL pointer, the
		/// NotificationHandle parameter was a NULL pointer, or the Family parameter was not either AF_INET, AF_INET6, or AF_UNSPEC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NotifyStableUnicastIpAddressTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// If the <c>NotifyStableUnicastIpAddressTable</c> function succeeds immediately, the return value is NO_ERROR and the stable
		/// unicast IP table is returned in the Table parameter. The calling application should free the memory pointed to by the Table
		/// parameter using the FreeMibTable function when the MIB_UNICASTIPADDRESS_TABLE information is no longer needed.
		/// </para>
		/// <para>
		/// All unicast IP addresses except dial-on-demand addresses are considered stable only if they are in the preferred state. For a
		/// normal unicast IP address entry, this would correspond to a DadState member of the MIB_UNICASTIPADDRESS_ROW for the IP address
		/// set to <c>IpDadStatePreferred</c>. Every dial-on-demand address defines its own stability metric. Currently the only
		/// dial-on-demand address considered by this function is the unicast IP address used by the Teredo client on the local computer.
		/// </para>
		/// <para>The Family parameter must be set to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// When <c>NotifyStableUnicastIpAddressTable</c> is successful and returns NO_ERROR, the Table parameter returns the stable unicast
		/// IP address table on the local computer.
		/// </para>
		/// <para>
		/// When <c>NotifyStableUnicastIpAddressTable</c> returns <c>ERROR_IO_PENDING</c> indicating that the I/O request is pending, then
		/// the stable unicast IP address table is returned to the function in the CallerCallback parameter.
		/// </para>
		/// <para>The <c>NotifyStableUnicastIpAddressTable</c> function is used primarily by applications that use the Teredo client.</para>
		/// <para>
		/// If the unicast IP address used by Teredo is available on the local computer but not in the stable (qualified) state,
		/// <c>NotifyStableUnicastIpAddressTable</c> returns ERROR_IO_PENDING and the stable unicast IP address table is eventually returned
		/// by calling the function in the CallerCallback parameter. If the Teredo address is not available or is in the stable state and the
		/// other unicast IP addresses are in a stable state, then the function in the CallerCallback parameter will never be invoked.
		/// </para>
		/// <para>
		/// The callback function specified in the CallerCallback parameter should be defined as a function of type <c>VOID</c>. The
		/// parameters passed to the callback function include the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID CallerContext</term>
		/// <term>The CallerContext parameter passed to the NotifyStableUnicastIpAddressTable function when registering for notifications.</term>
		/// </item>
		/// <item>
		/// <term>IN PMIB_UNICASTIPADDRESS_TABLE AddressTable</term>
		/// <term>A pointer to a MIB_UNICASTIPADDRESS_TABLE containing the stable unicast IP address table on the local computer.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the CallerCallback parameter must be implemented in the same process as the application
		/// calling the <c>NotifyStableUnicastIpAddressTable</c> function. If the callback function is in a separate DLL, then the DLL should
		/// be loaded before calling the <c>NotifyStableUnicastIpAddressTable</c> function to register for change notifications.
		/// </para>
		/// <para>
		/// The memory pointed to by the AddressTable parameter used in a callback indication is allocated by the operating system. An
		/// application that receives a notification should free the memory pointed to by the AddressTable parameter using the FreeMibTable
		/// function when the MIB_UNICASTIPADDRESS_TABLE information is no longer needed.
		/// </para>
		/// <para>
		/// Once the <c>NotifyStableUnicastIpAddressTable</c> function is called to register for change notifications, these notifications
		/// will continue to be sent until the application deregisters for change notifications or the application terminates. If the
		/// application terminates, the system will automatically deregister any registration for change notifications. It is still
		/// recommended that an application explicitly deregister any change notifications before it terminates.
		/// </para>
		/// <para>Any registration for change notifications does not persist if the system is shutdown or rebooted.</para>
		/// <para>
		/// To deregister for change notifications, call the CancelMibChangeNotify2 function passing the NotificationHandle parameter
		/// returned by <c>NotifyStableUnicastIpAddressTable</c>.
		/// </para>
		/// <para>
		/// An application cannot make a call to the CancelMibChangeNotify2 function from the context of the thread which is currently
		/// executing the notification callback function for the same NotificationHandle parameter. Otherwise, the thread executing that
		/// callback will result in deadlock. So the <c>CancelMibChangeNotify2</c> function must not be called directly as part of the
		/// notification callback routine. In a more general situation, a thread that executes the <c>CancelMibChangeNotify2</c> function
		/// cannot own a resource on which the thread that executes a notification callback operation would wait because it would result in a
		/// similar deadlock. The <c>CancelMibChangeNotify2</c> function should be called from a different thread, on which the thread that
		/// receives the notification callback doesn’t have dependencies on.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-notifystableunicastipaddresstable _NETIOAPI_SUCCESS_
		// NETIOAPI_API NotifyStableUnicastIpAddressTable( ADDRESS_FAMILY Family, PMIB_UNICASTIPADDRESS_TABLE *Table,
		// PSTABLE_UNICAST_IPADDRESS_TABLE_CALLBACK CallerCallback, PVOID CallerContext, HANDLE *NotificationHandle );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "80d10088-79ef-41fd-add7-994d2a780ddb")]
		public static extern Win32Error NotifyStableUnicastIpAddressTable(ADDRESS_FAMILY Family, out IntPtr Table, PSTABLE_UNICAST_IPADDRESS_TABLE_CALLBACK CallerCallback, [Optional] IntPtr CallerContext, out IntPtr NotificationHandle);

		/// <summary>
		/// <para>
		/// The <c>NotifyTeredoPortChange</c> function registers to be notified for changes to the UDP port number used by the Teredo client
		/// for the Teredo service port on a local computer.
		/// </para>
		/// </summary>
		/// <param name="Callback">
		/// <para>
		/// A pointer to the function to call when a Teredo client port change occurs. This function will be invoked when a Teredo port
		/// change notification is received.
		/// </para>
		/// </param>
		/// <param name="CallerContext">
		/// <para>
		/// A user context passed to the callback function specified in the Callback parameter when a Teredo port change notification is received.
		/// </para>
		/// </param>
		/// <param name="InitialNotification">
		/// <para>
		/// A value that indicates whether the callback should be invoked immediately after registration for change notification completes.
		/// This initial notification does not indicate a change occurred to the Teredo client port. The purpose of this parameter to provide
		/// confirmation that the callback is registered.
		/// </para>
		/// </param>
		/// <param name="NotificationHandle">
		/// <para>
		/// A pointer used to return a handle that can be later used to deregister the change notification. On success, a notification handle
		/// is returned in this parameter. If an error occurs, <c>NULL</c> is returned.
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
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>An internal error occurred where an invalid handle was encountered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function. This error is returned if the Callback parameter is a NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NotifyTeredoPortChange</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetTeredoPort function can be used to retrieve the initial UDP port number used by the Teredo client for the Teredo service port.
		/// </para>
		/// <para>
		/// The Teredo port is dynamic and can change any time the Teredo client is restarted on the local computer. An application can
		/// register to be notified when the Teredo service port changes by calling the <c>NotifyTeredoPortChange</c> function.
		/// </para>
		/// <para>
		/// The invocation of the callback function specified in the Callback parameter is serialized. The callback function should be
		/// defined as a function of type <c>VOID</c>. The parameters passed to the callback function include the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID CallerContext</term>
		/// <term>The CallerContext parameter passed to the NotifyTeredoPortChange function when registering for notifications.</term>
		/// </item>
		/// <item>
		/// <term>IN USHORT Port</term>
		/// <term>
		/// The UDP port number currently used by the Teredo client. This parameter is zero when the MIB_NOTIFICATION_TYPE value passed in
		/// the NotificationType parameter to the callback function is set to MibInitialNotification. This can only occur if the
		/// InitialNotification parameter passed to NotifyTeredoPortChange was set to TRUE when registering for notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN MIB_NOTIFICATION_TYPE NotificationType</term>
		/// <term>
		/// The notification type. This member can be one of the values from the MIB_NOTIFICATION_TYPE enumeration type defined in the
		/// Netioapi.h header file.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the Callback parameter must be implemented in the same process as the application calling the
		/// <c>NotifyTeredoPortChange</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before
		/// calling the <c>NotifyTeredoPortChange</c> function to register for change notifications.
		/// </para>
		/// <para>
		/// Once the <c>NotifyTeredoPortChange</c> function is called to register for change notifications, these notifications will continue
		/// to be sent until the application deregisters for change notifications or the application terminates. If the application
		/// terminates, the system will automatically deregister any registration for change notifications. It is still recommended that an
		/// application explicitly deregister for change notifications before it terminates.
		/// </para>
		/// <para>Any registration for change notifications does not persist across a system shut down or reboot.</para>
		/// <para>
		/// To deregister for change notifications, call the CancelMibChangeNotify2 function passing the NotificationHandle parameter
		/// returned by <c>NotifyTeredoPortChange</c>.
		/// </para>
		/// <para>
		/// An application cannot make a call to the CancelMibChangeNotify2 function from the context of the thread which is currently
		/// executing the notification callback function for the same NotificationHandle parameter. Otherwise, the thread executing that
		/// callback will result in deadlock. So the <c>CancelMibChangeNotify2</c> function must not be called directly as part of the
		/// notification callback routine. In a more general situation, a thread that executes the <c>CancelMibChangeNotify2</c> function
		/// cannot own a resource on which the thread that executes a notification callback operation would wait because it would result in a
		/// similar deadlock. The <c>CancelMibChangeNotify2</c> function should be called from a different thread, on which the thread that
		/// receives the notification callback doesn’t have dependencies on.
		/// </para>
		/// <para>
		/// The Teredo client also uses static UDP port 3544 for listening to multicast traffic sent on multicast IPv4 address 224.0.0.253 as
		/// defined in RFC 4380. For more information, see http://www.ietf.org/rfc/rfc4380.txt.
		/// </para>
		/// <para>
		/// The <c>NotifyTeredoPortChange</c> function is used primarily by firewall applications in order to configure the appropriate
		/// exceptions to allow incoming and outgoing Teredo traffic.
		/// </para>
		/// <para>The NotifyStableUnicastIpAddressTable function is used primarily by applications that use the Teredo client.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-notifyteredoportchange _NETIOAPI_SUCCESS_ NETIOAPI_API
		// NotifyTeredoPortChange( PTEREDO_PORT_CHANGE_CALLBACK Callback, PVOID CallerContext, BOOLEAN InitialNotification, HANDLE
		// *NotificationHandle );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "c0c23531-7629-41c9-acf2-9d2f5e98e02c")]
		public static extern Win32Error NotifyTeredoPortChange(PTEREDO_PORT_CHANGE_CALLBACK Callback, [Optional] IntPtr CallerContext, [MarshalAs(UnmanagedType.U1)] bool InitialNotification, out IntPtr NotificationHandle);

		/// <summary>
		/// <para>
		/// The <c>NotifyUnicastIpAddressChange</c> function registers to be notified for changes to all unicast IP interfaces, unicast IPv4
		/// addresses, or unicast IPv6 addresses on a local computer.
		/// </para>
		/// </summary>
		/// <param name="Family">
		/// <para>The address family on which to register for change notifications.</para>
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
		/// <term>AF_INET</term>
		/// <term>Register for only unicast IPv4 address change notifications.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>Register for only unicast IPv6 address change notifications.</term>
		/// </item>
		/// <item>
		/// <term>AF_UNSPEC</term>
		/// <term>Register for both unicast IPv4 and IPv6 address change notifications.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Callback">
		/// <para>
		/// A pointer to the function to call when a change occurs. This function will be invoked when a unicast IP address notification is received.
		/// </para>
		/// </param>
		/// <param name="CallerContext">
		/// <para>A user context passed to the callback function specified in the Callback parameter when an interface notification is received.</para>
		/// </param>
		/// <param name="InitialNotification">
		/// <para>
		/// A value that indicates whether the callback should be invoked immediately after registration for change notification completes.
		/// This initial notification does not indicate a change occurred to a unicast IP address. The purpose of this parameter to provide
		/// confirmation that the callback is registered.
		/// </para>
		/// </param>
		/// <param name="NotificationHandle">
		/// <para>
		/// A pointer used to return a handle that can be later used to deregister the change notification. On success, a notification handle
		/// is returned in this parameter. If an error occurs, <c>NULL</c> is returned.
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
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>An internal error occurred where an invalid handle was encountered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the Family parameter was not either AF_INET, AF_INET6,
		/// or AF_UNSPEC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NotifyUnicastIpAddressChange</c> function is defined on Windows Vista and later.</para>
		/// <para>The Family parameter must be set to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// The invocation of the callback function specified in the Callback parameter is serialized. The callback function should be
		/// defined as a function of type <c>VOID</c>. The parameters passed to the callback function include the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID CallerContext</term>
		/// <term>The CallerContext parameter passed to the NotifyUnicastIpAddressChange function when registering for notifications.</term>
		/// </item>
		/// <item>
		/// <term>IN PMIB_UNICASTIPADDRESS_ROW Row OPTIONAL</term>
		/// <term>
		/// A pointer to the MIB_UNICASTIPADDRESS_ROW entry for the unicast IP address that was changed. This parameter is a NULL pointer
		/// when the MIB_NOTIFICATION_TYPE value passed in the NotificationType parameter to the callback function is set to
		/// MibInitialNotification. This can only occur if the InitialNotification parameter passed to NotifyUnicastIpAddressChange was set
		/// to TRUE when registering for notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN MIB_NOTIFICATION_TYPE NotificationType</term>
		/// <term>
		/// The notification type. This member can be one of the values from the MIB_NOTIFICATION_TYPE enumeration type defined in the
		/// Netioapi.h header file.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the Callback parameter must be implemented in the same process as the application calling the
		/// <c>NotifyUnicastIpAddressChange</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before
		/// calling the <c>NotifyUnicastIpAddressChange</c> function to register for change notifications.
		/// </para>
		/// <para>
		/// When the callback function is received when a change occurs and the Row parameter is not <c>NULL</c>, the pointer to the
		/// MIB_UNICASTIPADDRESS_ROW structure passed in the Row parameter contains incomplete data. The information returned in the
		/// <c>MIB_UNICASTIPADDRESS_ROW</c> structure is only enough information that an application can call the GetUnicastIpAddressEntry
		/// function to query complete information on the IP address that changed. When the callback function is received, an application
		/// should allocate a <c>MIB_UNICASTIPADDRESS_ROW</c> structure and initialize it with the <c>Address</c>, <c>InterfaceLuid</c> and
		/// <c>InterfaceIndex</c> members in the <c>MIB_UNICASTIPADDRESS_ROW</c> structure pointed to by the Row parameter received. A
		/// pointer to this newly initialized <c>MIB_UNICASTIPADDRESS_ROW</c> structure should be passed to the
		/// <c>GetUnicastIpAddressEntry</c> function to retrieve complete information on the unicast IP address that was changed.
		/// </para>
		/// <para>
		/// The memory pointed to by the Row parameter used in the callback indications is managed by the operating system. An application
		/// that receives a notification should never attempt to free the memory pointed to by the Row parameter.
		/// </para>
		/// <para>
		/// Once the <c>NotifyUnicastIpAddressChange</c> function is called to register for change notifications, these notifications will
		/// continue to be sent until the application deregisters for change notifications or the application terminates. If the application
		/// terminates, the system will automatically deregister any registration for change notifications. It is still recommended that an
		/// application explicitly deregister for change notifications before it terminates.
		/// </para>
		/// <para>Any registration for change notifications does not persist if the system is shutdown or rebooted.</para>
		/// <para>
		/// To deregister for change notifications, call the CancelMibChangeNotify2 function passing the NotificationHandle parameter
		/// returned by <c>NotifyUnicastIpAddressChange</c>.
		/// </para>
		/// <para>
		/// An application cannot make a call to the CancelMibChangeNotify2 function from the context of the thread which is currently
		/// executing the notification callback function for the same NotificationHandle parameter. Otherwise, the thread executing that
		/// callback will result in deadlock. So the <c>CancelMibChangeNotify2</c> function must not be called directly as part of the
		/// notification callback routine. In a more general situation, a thread that executes the <c>CancelMibChangeNotify2</c> function
		/// cannot own a resource on which the thread that executes a notification callback operation would wait because it would result in a
		/// similar deadlock. The <c>CancelMibChangeNotify2</c> function should be called from a different thread, on which the thread that
		/// receives the notification callback doesn’t have dependencies on.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-notifyunicastipaddresschange _NETIOAPI_SUCCESS_
		// NETIOAPI_API NotifyUnicastIpAddressChange( ADDRESS_FAMILY Family, PUNICAST_IPADDRESS_CHANGE_CALLBACK Callback, PVOID
		// CallerContext, BOOLEAN InitialNotification, HANDLE *NotificationHandle );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "56945aa2-ca1e-44b3-9765-d862978a9dbe")]
		public static extern Win32Error NotifyUnicastIpAddressChange(ADDRESS_FAMILY Family, PUNICAST_IPADDRESS_CHANGE_CALLBACK Callback, [Optional] IntPtr CallerContext, [MarshalAs(UnmanagedType.U1)] bool InitialNotification, out IntPtr NotificationHandle);

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
		public static extern Win32Error ResolveIpNetEntry2(ref MIB_IPNET_ROW2 Row, IntPtr SourceAddress = default);

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
		public static extern Win32Error ResolveIpNetEntry2(ref MIB_IPNET_ROW2 Row, in SOCKADDR_INET SourceAddress);

		/// <summary>
		/// <para>Reserved for future use. Do not use this function.</para>
		/// </summary>
		/// <param name="CompartmentId">
		/// <para>Reserved.</para>
		/// </param>
		/// <returns>
		/// <para>None</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-setcurrentthreadcompartmentid _NETIOAPI_SUCCESS_
		// NETIOAPI_API SetCurrentThreadCompartmentId( NET_IF_COMPARTMENT_ID CompartmentId );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "15c634b5-c621-430d-99d7-c55ad8b6864e")]
		public static extern Win32Error SetCurrentThreadCompartmentId(uint CompartmentId);

		/// <summary>
		/// <para>The <c>SetIpForwardEntry2</c> function sets the properties of an IP route entry on the local computer.</para>
		/// </summary>
		/// <param name="Route">
		/// <para>
		/// A pointer to a MIB_IPFORWARD_ROW2 structure entry for an IP route entry. The <c>DestinationPrefix</c> member of the
		/// <c>MIB_IPFORWARD_ROW2</c> must be set to a valid IP destination prefix, the <c>NextHop</c> member of the
		/// <c>MIB_IPFORWARD_ROW2</c> must be set to a valid IP address family and IP address, and the <c>InterfaceLuid</c> or the
		/// <c>InterfaceIndex</c> member of the <c>MIB_IPFORWARD_ROW2</c> must be specified.
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
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Route parameter, the
		/// DestinationPrefix member of the MIB_IPFORWARD_ROW2 pointed to by the Route parameter was not specified, the NextHop member of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Route parameter was not specified, or both the InterfaceLuid or InterfaceIndex members of
		/// the MIB_IPFORWARD_ROW2 pointed to by the Route parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPFORWARD_ROW2 pointed to by the Route parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SetIpForwardEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>SetIpForwardEntry2</c> function is used to set the properties for an existing IP route entry on a local computer.</para>
		/// <para>
		/// The <c>DestinationPrefix</c> member in the MIB_IPFORWARD_ROW2 structure pointed to by the Route parameter must be initialized to
		/// a valid IP address prefix and family. The <c>NextHop</c> member in the <c>MIB_IPFORWARD_ROW2</c> structure pointed to by the
		/// Route parameter must be initialized to a valid IP address and family. In addition, at least one of the following members in the
		/// <c>MIB_IPFORWARD_ROW2</c> structure pointed to the Route parameter must be initialized to the interface: the <c>InterfaceLuid</c>
		/// or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// The route metric offset specified in the <c>Metric</c> member of the MIB_IPFORWARD_ROW2 structure pointed to by Route parameter
		/// represents only part of the complete route metric. The complete metric is a combination of this route metric offset added to the
		/// interface metric specified in the <c>Metric</c> member of the MIB_IPINTERFACE_ROW structure of the associated interface. An
		/// application can retrieve the interface metric by calling the GetIpInterfaceEntry function.
		/// </para>
		/// <para>
		/// The <c>Age</c> and <c>Origin</c> members of the MIB_IPFORWARD_ROW2 structure pointed to by the Row are ignored when the
		/// <c>SetIpForwardEntry2</c> function is called. These members are set by the network stack and cannot be changed using the
		/// <c>SetIpForwardEntry2</c> function.
		/// </para>
		/// <para>
		/// The <c>SetIpForwardEntry2</c> function will fail if the <c>DestinationPrefix</c> and <c>NextHop</c> members of the
		/// MIB_IPFORWARD_ROW2 pointed to by the Route parameter do not match an IP route entry on the interface specified.
		/// </para>
		/// <para>
		/// The <c>SetIpForwardEntry2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetIpForwardEntry2</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>SetIpForwardEntry2</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an
		/// application that contains this function is executed by a user logged on as a member of the Administrators group other than the
		/// built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-setipforwardentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// SetIpForwardEntry2( CONST MIB_IPFORWARD_ROW2 *Route );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "e11aab0b-6d6c-4e90-a60a-f7d68c09751b")]
		public static extern Win32Error SetIpForwardEntry2(in MIB_IPFORWARD_ROW2 Route);

		/// <summary>
		/// <para>The <c>SetIpInterfaceEntry</c> function sets the properties of an IP interface on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPINTERFACE_ROW structure entry for an interface. On input, the <c>Family</c> member of the
		/// <c>MIB_IPINTERFACE_ROW</c> must be set to <c>AF_INET6</c> or <c>AF_INET</c> and the <c>InterfaceLuid</c> or the
		/// <c>InterfaceIndex</c> member of the <c>MIB_IPINTERFACE_ROW</c> must be specified. On a successful return, the
		/// <c>InterfaceLuid</c> member of the <c>MIB_IPINTERFACE_ROW</c> is filled in if <c>InterfaceIndex</c> member of the
		/// <c>MIB_IPINTERFACE_ROW</c> entry was specified.
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
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned if the network interface LUID or interface index specified by
		/// the InterfaceLuid or InterfaceIndex member of the MIB_IPINTERFACE_ROW pointed to by the Row parameter was not a value on the
		/// local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Family member of the MIB_IPINTERFACE_ROW pointed to by the Row parameter was not specified as AF_INET or AF_INET6, or both the
		/// InterfaceLuid or InterfaceIndex members of the MIB_IPINTERFACE_ROW pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPINTERFACE_ROW pointed to by the Row parameter does not match the IP address family specified
		/// in the Family member in the MIB_IPINTERFACE_ROW structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SetIpInterfaceEntry</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>SetIpInterfaceEntry</c> function can is used to modify an existing IP interface entry.</para>
		/// <para>
		/// On input, the <c>Family</c> member in the MIB_IPINTERFACE_ROW structure pointed to by the Row parameter must be initialized to
		/// either <c>AF_INET</c> or <c>AF_INET6</c>. In addition on input, at least one of the following members in the
		/// <c>MIB_IPINTERFACE_ROW</c> structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// On output, the <c>InterfaceLuid</c> member of the MIB_IPINTERFACE_ROW structure pointed to by the Row parameter is filled in if
		/// the <c>InterfaceIndex</c> was specified.
		/// </para>
		/// <para>
		/// The <c>MaxReassemblySize</c>, <c>MinRouterAdvertisementInterval</c>, <c>MaxRouterAdvertisementInterval</c>, <c>Connected</c>,
		/// <c>SupportsWakeUpPatterns</c>, <c>SupportsNeighborDiscovery</c>, <c>SupportsRouterDiscovery</c>, <c>ReachableTime</c>,
		/// <c>TransmitOffload</c>, and <c>ReceiveOffload</c> members of the MIB_IPINTERFACE_ROW structure pointed to by the Row are ignored
		/// when the <c>SetIpInterfaceEntry</c> function is called. These members are set by the network stack and cannot be changed using
		/// the <c>SetIpInterfaceEntry</c> function.
		/// </para>
		/// <para>
		/// An application would typically call the GetIpInterfaceTable function to retrieve the IP interface entries on the local computer
		/// or call the GetIpInterfaceEntry function to retrieve just the IP interface entry to modify. The MIB_IPINTERFACE_ROW structure for
		/// the specific IP interface entry could then be modified and a pointer to this structure passed to the <c>SetIpInterfaceEntry</c>
		/// function in the Row parameter. However for IPv4, an application must not try to modify the <c>SitePrefixLength</c> member of the
		/// <c>MIB_IPINTERFACE_ROW</c> structure. For IPv4, the <c>SitePrefixLength</c> member must be set to 0.
		/// </para>
		/// <para>
		/// Another possible method to modify an existing IP interface entry is to use InitializeIpInterfaceEntry function to initialize the
		/// fields of a MIB_IPINTERFACE_ROW structure entry with default values. Then set the <c>Family</c> member and either the
		/// <c>InterfaceIndex</c> or <c>InterfaceLuid</c> members in the <c>MIB_IPINTERFACE_ROW</c> structure pointed to by the Row parameter
		/// to match the IP interface to change. An application can then change the fields in the <c>MIB_IPINTERFACE_ROW</c> entry it wishes
		/// to modify, and then call the <c>SetIpInterfaceEntry</c> function. However for IPv4, an application must not try to modify the
		/// <c>SitePrefixLength</c> member of the <c>MIB_IPINTERFACE_ROW</c> structure. For IPv4, the <c>SitePrefixLength</c> member must be
		/// set to 0. Caution must be used with this approach because the only way to determine all of the fields being changed would be to
		/// compare the fields in the <c>MIB_IPINTERFACE_ROW</c> of the specific IP interface entry with fields set by the
		/// <c>InitializeIpInterfaceEntry</c> function when a <c>MIB_IPINTERFACE_ROW</c> is initialized to default values.
		/// </para>
		/// <para>
		/// Unprivileged simultaneous access to multiple networks of different security requirements creates a security hole and allows an
		/// unprivileged application to accidentally relay data between the two networks. A typical example is simultaneous access to a
		/// virtual private network (VPN) and the Internet. Windows Server 2003 and Windows XP use a weak host model, where RAS prevents such
		/// simultaneous access by increasing the route metric of all default routes over other interfaces. Thus all traffic is routed
		/// through the VPN interface, disrupting other network connectivity.
		/// </para>
		/// <para>
		/// On Windows Vista and later, a strong host model is used by default. If a source IP address is specified in the route lookup using
		/// GetBestRoute2 or GetBestRoute, the route lookup is restricted to the interface of the source IP address. The route metric
		/// modification by RAS has no effect as the list of potential routes does not even have the route for the VPN interface thereby
		/// allowing traffic to the Internet. The <c>DisableDefaultRoutes</c> member of the MIB_IPINTERFACE_ROW can be used to disable using
		/// the default route on an interface. This member can be used as a security measure by VPN clients to restrict split tunneling when
		/// split tunneling is not required by the VPN client. A VPN client can call the <c>SetIpInterfaceEntry</c> function to set the
		/// <c>DisableDefaultRoutes</c> member to <c>TRUE</c> when required. A VPN client can query the current state of the
		/// <c>DisableDefaultRoutes</c> member by calling the GetIpInterfaceEntry function.
		/// </para>
		/// <para>The</para>
		/// <para>
		/// The <c>SetIpInterfaceEntry</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetIpInterfaceEntry</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista and
		/// later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-setipinterfaceentry _NETIOAPI_SUCCESS_ NETIOAPI_API
		// SetIpInterfaceEntry( PMIB_IPINTERFACE_ROW Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "8e6d2c14-29c3-47a7-9eb8-0989df9da68c")]
		public static extern Win32Error SetIpInterfaceEntry(in MIB_IPINTERFACE_ROW Row);

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
		public static extern Win32Error SetIpNetEntry2(in MIB_IPNET_ROW2 Row);

		/// <summary>
		/// <para>Reserved for future use. Do not use this function.</para>
		/// </summary>
		/// <param name="NetworkGuid">
		/// <para>Reserved.</para>
		/// </param>
		/// <param name="CompartmentId">
		/// <para>Reserved.</para>
		/// </param>
		/// <param name="NetworkName">
		/// <para>Reserved.</para>
		/// </param>
		/// <returns>
		/// <para>None</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-setnetworkinformation _NETIOAPI_SUCCESS_ NETIOAPI_API
		// SetNetworkInformation( CONST NET_IF_NETWORK_GUID *NetworkGuid, NET_IF_COMPARTMENT_ID CompartmentId, CONST WCHAR *NetworkName );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "e196e978-2eb7-4b22-af3b-e14736c5ac94")]
		public static extern Win32Error SetNetworkInformation(in Guid NetworkGuid, uint CompartmentId, [MarshalAs(UnmanagedType.LPWStr)] string NetworkName);

		/// <summary>
		/// <para>Reserved for future use. Do not use this function.</para>
		/// </summary>
		/// <param name="SessionId">
		/// <para>Reserved.</para>
		/// </param>
		/// <param name="CompartmentId">
		/// <para>Reserved.</para>
		/// </param>
		/// <returns>
		/// <para>None</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-setsessioncompartmentid _NETIOAPI_SUCCESS_ NETIOAPI_API
		// SetSessionCompartmentId( ULONG SessionId, NET_IF_COMPARTMENT_ID CompartmentId );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "d8192a40-0122-44cd-87a8-3999204322b4")]
		public static extern Win32Error SetSessionCompartmentId(uint SessionId, uint CompartmentId);

		/// <summary>
		/// <para>The SetUnicastIpAddressEntry function sets the properties of an existing unicast IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>A pointer to a MIB_UNICASTIPADDRESS_ROW structure entry for an existing unicast IP address entry.</para>
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
		/// address, or both the InterfaceLuid or InterfaceIndex members of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter were
		/// unspecified. This error is also returned for other errors in the values set for members in the MIB_UNICASTIPADDRESS_ROW
		/// structure. These errors include the following: if the ValidLifetime member is less than the PreferredLifetime member, if the
		/// PrefixOrigin member is set to IpPrefixOriginUnchanged and the SuffixOrigin is the not set to IpSuffixOriginUnchanged, if the
		/// PrefixOrigin member is not set to IpPrefixOriginUnchanged and the SuffixOrigin is set to IpSuffixOriginUnchanged, if the
		/// PrefixOrigin member is not set to a value from the NL_PREFIX_ORIGIN enumeration, if the SuffixOrigin member is not set to a value
		/// from the NL_SUFFIX_ORIGIN enumeration, or if the OnLinkPrefixLength member is set to a value greater than the IP address length,
		/// in bits (32 for an unicast IPv4 address or 128 for an unicast IPv6 address).
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
		/// in the Address member MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter or no IPv6 stack is on the local computer and an
		/// IPv6 address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The SetUnicastIpAddressEntry function is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetUnicastIpAddressEntry function is normally used to retrieve an existing MIB_UNICASTIPADDRESS_ROW structure entry to be
		/// modified. An application can then change the members in the <c>MIB_UNICASTIPADDRESS_ROW</c> entry it wishes to modify, and then
		/// call the SetUnicastIpAddressEntry function.
		/// </para>
		/// <para>
		/// An application may call the InitializeUnicastIpAddressEntry function to initialize the members of a MIB_UNICASTIPADDRESS_ROW
		/// structure entry with default values before making changes. However, the application would normally save either the
		/// <c>InterfaceLuid</c> or <c>InterfaceIndex</c> member before calling <c>InitializeUnicastIpAddressEntry</c> and restore one of
		/// these members after the call.
		/// </para>
		/// <para>
		/// The <c>Address</c> member in the MIB_UNICASTIPADDRESS_ROW structure pointed to by the Row parameter must be initialized to a
		/// valid unicast IPv4 or IPv6 address and family. In addition, at least one of the following members in the
		/// <c>MIB_UNICASTIPADDRESS_ROW</c> structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// If the <c>OnLinkPrefixLength</c> member of the MIB_UNICASTIPADDRESS_ROW pointed to by the Row parameter is set to 255, then
		/// SetUnicastIpAddressEntry will set the unicast IP address properties so that the <c>OnLinkPrefixLength</c> member is equal to the
		/// length of the IP address. So for a unicast IPv4 address, the <c>OnLinkPrefixLength</c> is set to 32 and the
		/// <c>OnLinkPrefixLength</c> is set to 128 for a unicast IPv6 address. If this would result in the incorrect subnet mask for an IPv4
		/// address or the incorrect link prefix for an IPv6 address, then the application should set this member to the correct value before
		/// calling <c>SetUnicastIpAddressEntry</c>.
		/// </para>
		/// <para>
		/// The <c>DadState</c>, <c>ScopeId</c>, and <c>CreationTimeStamp</c> members of the MIB_UNICASTIPADDRESS_ROW structure pointed to by
		/// the Row are ignored when the SetUnicastIpAddressEntry function is called. These members are set by the network stack and cannot
		/// be changed using the <c>SetUnicastIpAddressEntry</c> function. The <c>ScopeId</c> member is automatically determined by the
		/// interface on which the address was added.
		/// </para>
		/// <para>
		/// The SetUnicastIpAddressEntry function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetUnicastIpAddressEntry</c> is called by a user that is not a member of the Administrators group, the function call will fail
		/// and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The SetUnicastIpAddressEntry function can also fail because of user account control (UAC) on Windows Vista and later. If an
		/// application that contains this function is executed by a user logged on as a member of the Administrators group other than the
		/// built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-setunicastipaddressentry _NETIOAPI_SUCCESS_ NETIOAPI_API
		// SetUnicastIpAddressEntry( CONST MIB_UNICASTIPADDRESS_ROW *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "906a3895-2e42-4bed-90a3-7c10487d76cb")]
		public static extern Win32Error SetUnicastIpAddressEntry(in MIB_UNICASTIPADDRESS_ROW Row);

		/// <summary>
		/// <para>The <c>IP_ADDRESS_PREFIX</c> structure stores an IP address prefix.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>IP_ADDRESS_PREFIX</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>IP_ADDRESS_PREFIX</c> structure is the data type of the <c>DestinationPrefix</c> member in the MIB_IPFORWARD_ROW2
		/// structure. A number of functions use the <c>MIB_IPFORWARD_ROW2</c> structure including CreateIpForwardEntry2,
		/// DeleteIpForwardEntry2, GetBestRoute2, GetIpForwardEntry2, GetIpForwardTable2, InitializeIpForwardEntry, NotifyRouteChange2, and SetIpForwardEntry2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_ip_address_prefix typedef struct _IP_ADDRESS_PREFIX {
		// SOCKADDR_INET Prefix; UINT8 PrefixLength; } IP_ADDRESS_PREFIX, *PIP_ADDRESS_PREFIX;
		[PInvokeData("netioapi.h", MSDNShortId = "3a6598d8-77e4-46f7-9397-124157508207")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct IP_ADDRESS_PREFIX : IEquatable<IP_ADDRESS_PREFIX>
		{
			/// <summary>
			/// <para>The prefix or network part of IP the address represented as an IP address.</para>
			/// <para>The SOCKADDR_INET union is defined in the Ws2ipdef.h header.</para>
			/// </summary>
			public SOCKADDR_INET Prefix;

			/// <summary>
			/// The length, in bits, of the prefix or network part of the IP address. For a unicast IPv4 address, any value greater than 32
			/// is an illegal value. For a unicast IPv6 address, any value greater than 128 is an illegal value. A value of 255 is commonly
			/// used to represent an illegal value.
			/// </summary>
			public byte PrefixLength;

			/// <summary>Initializes a new instance of the <see cref="IP_ADDRESS_PREFIX"/> struct.</summary>
			/// <param name="prefix">The prefix or network part of IP the address represented as an IP address.</param>
			/// <param name="prefixLength">The length, in bits, of the prefix or network part of the IP address.</param>
			public IP_ADDRESS_PREFIX(SOCKADDR_INET prefix, byte prefixLength)
			{
				Prefix = prefix;
				PrefixLength = prefixLength;
			}

			/// <summary>Determines whether the specified value is equal to this instance.</summary>
			/// <param name="other">The value to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified value is equal to this instance; otherwise, <see langword="false"/>.</returns>
			public bool Equals(IP_ADDRESS_PREFIX other) => Prefix.Equals(other.Prefix) && PrefixLength == other.PrefixLength;
		}

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
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct MIB_ANYCASTIPADDRESS_ROW : IEquatable<MIB_ANYCASTIPADDRESS_ROW>
		{
			/// <summary>The anycast IP address. This member can be an IPv6 address or an IPv4 address.</summary>
			public SOCKADDR_INET Address;

			/// <summary>The locally unique identifier (LUID) for the network interface associated with this IP address.</summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// The local index value for the network interface associated with this IP address. This index value may change when a network
			/// adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// The scope ID of the anycast IP address. This member is applicable only to an IPv6 address. This member cannot be set. It is
			/// automatically determined by the interface on which the address was added.
			/// </summary>
			public SCOPE_ID ScopeId;

			/// <summary>Initializes a new instance of the <see cref="MIB_ANYCASTIPADDRESS_ROW"/> struct.</summary>
			/// <param name="ipv4">The ipv4 address.</param>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_ANYCASTIPADDRESS_ROW(SOCKADDR_IN ipv4, NET_LUID interfaceLuid) : this()
			{
				Address.Ipv4 = ipv4;
				InterfaceLuid = interfaceLuid;
			}

			/// <summary>Initializes a new instance of the <see cref="MIB_ANYCASTIPADDRESS_ROW"/> struct.</summary>
			/// <param name="ipv4">The ipv4 address.</param>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_ANYCASTIPADDRESS_ROW(SOCKADDR_IN ipv4, uint interfaceIndex) : this()
			{
				Address.Ipv4 = ipv4;
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>Initializes a new instance of the <see cref="MIB_ANYCASTIPADDRESS_ROW"/> struct.</summary>
			/// <param name="ipv6">The ipv6 address.</param>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_ANYCASTIPADDRESS_ROW(SOCKADDR_IN6 ipv6, NET_LUID interfaceLuid) : this()
			{
				Address.Ipv6 = ipv6;
				InterfaceLuid = interfaceLuid;
			}

			/// <summary>Initializes a new instance of the <see cref="MIB_ANYCASTIPADDRESS_ROW"/> struct.</summary>
			/// <param name="ipv6">The ipv6 address.</param>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_ANYCASTIPADDRESS_ROW(SOCKADDR_IN6 ipv6, uint interfaceIndex) : this()
			{
				Address.Ipv6 = ipv6;
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>Determines whether the specified value is equal to this instance.</summary>
			/// <param name="other">The value to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified value is equal to this instance; otherwise, <see langword="false"/>.</returns>
			public bool Equals(MIB_ANYCASTIPADDRESS_ROW other) => Address.Equals(other.Address) && (InterfaceLuid.Value == other.InterfaceLuid.Value || InterfaceIndex == other.InterfaceIndex);
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
			public MIB_IF_ROW2(uint interfaceIndex) : this() => InterfaceIndex = interfaceIndex;

			/// <summary>Initializes a new instance of the <see cref="MIB_IF_ROW2"/> struct.</summary>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_IF_ROW2(NET_LUID interfaceLuid) : this() => InterfaceLuid = interfaceLuid;
		}

		/// <summary>The MIB_IFSTACK_ROW structure represents the relationship between two network interfaces.</summary>
		// typedef struct _MIB_IFSTACK_ROW { NET_IFINDEX HigherLayerInterfaceIndex; NET_IFINDEX LowerLayerInterfaceIndex;} MIB_IFSTACK_ROW,
		// *PMIB_IFSTACK_ROW; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559207(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559207")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_IFSTACK_ROW
		{
			/// <summary>The network interface index for the interface that is higher in the interface stack table.</summary>
			public uint HigherLayerInterfaceIndex;

			/// <summary>The network interface index for the interface that is lower in the interface stack table.</summary>
			public uint LowerLayerInterfaceIndex;
		}

		/// <summary>The MIB_INVERTEDIFSTACK_ROW structure represents the relationship between two network interfaces.</summary>
		// typedef struct _MIB_INVERTEDIFSTACK_ROW { NET_IFINDEX LowerLayerInterfaceIndex; NET_IFINDEX HigherLayerInterfaceIndex;}
		// MIB_INVERTEDIFSTACK_ROW, *PMIB_INVERTEDIFSTACK_ROW; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559234(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559234")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_INVERTEDIFSTACK_ROW
		{
			/// <summary>The network interface index for the interface that is lower in the interface stack table.</summary>
			public uint LowerLayerInterfaceIndex;

			/// <summary>The network interface index for the interface that is higher in the interface stack table.</summary>
			public uint HigherLayerInterfaceIndex;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES</c> structure contains read-only information for the bandwidth estimates
		/// computed by the TCP/IP stack for a network connection.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>MIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES</c> structure provides bandwidth estimates computed by the TCP/IP stack for
		/// a network connection. These bandwidth estimates are for the point of attachment of the host system to the underlying IP network.
		/// </para>
		/// <para>
		/// The <c>MIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES</c> structure is used with the GetIpNetworkConnectionBandwidthEstimates
		/// function to return bandwidth estimates obtained for the point of attachment to the IP network. It is possible to have asymmetric
		/// deployments and network conditions where the estimates observed inbound and outbound differ from each other.
		/// </para>
		/// <para>
		/// The <c>MIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES</c> structure is defined in the Netioapi.h header file which is
		/// automatically included in the Iphlpapi.h header file. The Netioapi.h header file should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_mib_ip_network_connection_bandwidth_estimates typedef
		// struct _MIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES { NL_BANDWIDTH_INFORMATION InboundBandwidthInformation;
		// NL_BANDWIDTH_INFORMATION OutboundBandwidthInformation; } MIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES, *PMIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES;
		[PInvokeData("netioapi.h", MSDNShortId = "E3109F71-E103-4586-9274-B83C4DC22382")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_IP_NETWORK_CONNECTION_BANDWIDTH_ESTIMATES
		{
			/// <summary>
			/// <para>Bandwidth estimates for the data being received by the host from the IP network.</para>
			/// </summary>
			public NL_BANDWIDTH_INFORMATION InboundBandwidthInformation;

			/// <summary>
			/// <para>Bandwidth estimates for the data being sent from the host to the IP network.</para>
			/// </summary>
			public NL_BANDWIDTH_INFORMATION OutboundBandwidthInformation;
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
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct MIB_IPFORWARD_ROW2 : IEquatable<MIB_IPFORWARD_ROW2>
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
			/// IPv4 address of 0.0.0.0 for an IPv4 route entry or an IPv6 address of 0::0 for an IPv6 route entry.
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
			public MIB_IPFORWARD_PROTO Protocol;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that specifies if the route is a loopback route (the gateway is on the local host).</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool Loopback;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that specifies if the IP address is auto-configured.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool AutoconfigureAddress;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that specifies if the route is published.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool Publish;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that specifies if the route is immortal.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool Immortal;

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

			/// <summary>Initializes a new instance of the <see cref="MIB_IPFORWARD_ROW2"/> struct.</summary>
			/// <param name="destinationPrefix">The destination prefix.</param>
			/// <param name="nextHop">The next hop.</param>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_IPFORWARD_ROW2(IP_ADDRESS_PREFIX destinationPrefix, SOCKADDR_INET nextHop, NET_LUID interfaceLuid) : this()
			{
				InitializeIpForwardEntry(out this);
				DestinationPrefix = destinationPrefix;
				NextHop = nextHop;
				InterfaceLuid = interfaceLuid;
			}

			/// <summary>Initializes a new instance of the <see cref="MIB_IPFORWARD_ROW2"/> struct.</summary>
			/// <param name="destinationPrefix">The destination prefix.</param>
			/// <param name="nextHop">The next hop.</param>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_IPFORWARD_ROW2(IP_ADDRESS_PREFIX destinationPrefix, SOCKADDR_INET nextHop, uint interfaceIndex) : this()
			{
				InitializeIpForwardEntry(out this);
				DestinationPrefix = destinationPrefix;
				NextHop = nextHop;
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>Determines whether the specified value is equal to this instance.</summary>
			/// <param name="other">The value to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified value is equal to this instance; otherwise, <see langword="false"/>.</returns>
			public bool Equals(MIB_IPFORWARD_ROW2 other) => DestinationPrefix.Equals(other.DestinationPrefix) && NextHop.Equals(other.NextHop) && (InterfaceLuid.Value == other.InterfaceLuid.Value || InterfaceIndex == other.InterfaceIndex);
		}

		/// <summary>
		/// The MIB_IPINTERFACE_ROW structure stores interface management information for a particular IP address family on a network interface.
		/// </summary>
		// typedef struct _MIB_IPINTERFACE_ROW { ADDRESS_FAMILY Family; NET_LUID InterfaceLuid; NET_IFINDEX InterfaceIndex; ULONG
		// MaxReassemblySize; ULONG64 InterfaceIdentifier; ULONG MinRouterAdvertisementInterval; ULONG MaxRouterAdvertisementInterval;
		// BOOLEAN AdvertisingEnabled; BOOLEAN ForwardingEnabled; BOOLEAN WeakHostSend; BOOLEAN WeakHostReceive; BOOLEAN UseAutomaticMetric;
		// BOOLEAN UseNeighborUnreachabilityDetection; BOOLEAN ManagedAddressConfigurationSupported; BOOLEAN
		// OtherStatefulConfigurationSupported; BOOLEAN AdvertiseDefaultRoute; NL_ROUTER_DISCOVERY_BEHAVIOR RouterDiscoveryBehavior; ULONG
		// DadTransmits; ULONG BaseReachableTime; ULONG RetransmitTime; ULONG PathMtuDiscoveryTimeout; NL_LINK_LOCAL_ADDRESS_BEHAVIOR
		// LinkLocalAddressBehavior; ULONG LinkLocalAddressTimeout; ULONG ZoneIndices[ScopeLevelCount]; ULONG SitePrefixLength; ULONG Metric;
		// ULONG NlMtu; BOOLEAN Connected; BOOLEAN SupportsWakeUpPatterns; BOOLEAN SupportsNeighborDiscovery; BOOLEAN
		// SupportsRouterDiscovery; ULONG ReachableTime; NL_INTERFACE_OFFLOAD_ROD TransmitOffload; NL_INTERFACE_OFFLOAD_ROD ReceiveOffload;
		// BOOLEAN DisableDefaultRoutes;} MIB_IPINTERFACE_ROW, *PMIB_IPINTERFACE_ROW; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559254(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559254")]
		[StructLayout(LayoutKind.Sequential)]//, Pack = 8)]
		public struct MIB_IPINTERFACE_ROW : IEquatable<MIB_IPINTERFACE_ROW>
		{
			//[MarshalAs(UnmanagedType.ByValArray, SizeConst = 168)] public byte[] bytes;
			/// <summary>
			/// <para>
			/// The address family. Possible values for the address family are listed in the Winsock2.h header file. Note that the values for
			/// the AF_ address family and PF_ protocol family constants are identical (for example, AF_INET and PF_INET), so you can use
			/// either constant.
			/// </para>
			/// <para>
			/// On Windows Vista and later versions of the Windows operating systems, possible values for this member are defined in the
			/// Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Netioapi.h and you should never use
			/// Ws2def.h directly.
			/// </para>
			/// <para>The following values are currently supported:</para>
			/// </summary>
			public ADDRESS_FAMILY Family;

			/// <summary>The locally unique identifier (LUID) for the network interface.</summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// The local index value for the network interface. This index value might change when a network adapter is disabled and then
			/// enabled, or under other circumstances, and should not be considered persistent.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// The maximum reassembly size, in bytes, of a fragmented IP packet. This member is currently set to zero and reserved for
			/// future use.
			/// </summary>
			public uint MaxReassemblySize;

			/// <summary>Reserved for future use. This member is currently set to zero.</summary>
			public ulong InterfaceIdentifier;

			/// <summary>
			/// The minimum router advertisement interval, in milliseconds, on this IP interface. This member defaults to 200 for IPv6. This
			/// member is applicable only if the <c>AdvertisingEnabled</c> member is set to <c>TRUE</c>.
			/// </summary>
			public uint MinRouterAdvertisementInterval;

			/// <summary>
			/// The maximum router advertisement interval, in milliseconds, on this IP interface. This member defaults to 600 for IPv6. This
			/// member is applicable only if the <c>AdvertisingEnabled</c> member is set to <c>TRUE</c>.
			/// </summary>
			public uint MaxRouterAdvertisementInterval;

			/// <summary>
			/// A value that indicates if router advertising is enabled on this IP interface. The default for IPv6 is that router
			/// advertisement is enabled only if the interface is configured to act as a router. The default for IPv4 is that router
			/// advertisement is disabled.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool AdvertisingEnabled;

			/// <summary>A value that indicates if IP forwarding is enabled on this IP interface.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool ForwardingEnabled;

			/// <summary>A value that indicates if weak host send mode is enabled on this IP interface.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool WeakHostSend;

			/// <summary>A value that indicates if weak host receive mode is enabled on this IP interface.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool WeakHostReceive;

			/// <summary>A value that indicates if the IP interface uses automatic metric.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool UseAutomaticMetric;

			/// <summary>A value that indicates if neighbor unreachability detection is enabled on this IP interface.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool UseNeighborUnreachabilityDetection;

			/// <summary>A value that indicates if the IP interface supports managed address configuration by using DHCP.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool ManagedAddressConfigurationSupported;

			/// <summary>A value that indicates if the IP interface supports other stateful configuration (for example, route configuration).</summary>
			[MarshalAs(UnmanagedType.U1)] public bool OtherStatefulConfigurationSupported;

			/// <summary>
			/// A value that indicates if the IP interface advertises the default route. This member is applicable only if the
			/// <c>AdvertisingEnabled</c> member is set to <c>TRUE</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool AdvertiseDefaultRoute;

			/// <summary>An <c>NL_ROUTER_DISCOVERY_BEHAVIOR</c> router discovery behavior type.</summary>
			public NL_ROUTER_DISCOVERY_BEHAVIOR RouterDiscoveryBehavior;

			/// <summary>
			/// The number of consecutive messages that are sent while the driver performs duplicate address detection on a tentative IP
			/// unicast address. A value of zero indicates that duplicate address detection is not performed on tentative IP addresses. A
			/// value of one indicates a single transmission with no follow up retransmissions. For IPv4, the default value for this member
			/// is 3. For IPv6, the default value for this member is 1. For IPv6, these messages are sent as IPv6 Neighbor Solicitation (NS)
			/// requests. This member is defined as DupAddrDetectTransmits in RFC 2462. For more information, see IPv6 "Stateless Address Auto-configuration".
			/// </summary>
			public uint DadTransmits;

			/// <summary>
			/// The base for random reachable time, in milliseconds. The member is described in RFC 2461. For more information, see "Neighbor
			/// Discovery for IP Version 6 (IPv6)".
			/// </summary>
			public uint BaseReachableTime;

			/// <summary>
			/// The IPv6 Neighbor Solicitation (NS) time-out, in milliseconds. The member is described in RFC 2461. For more information, see
			/// "Neighbor Discovery for IP Version 6 (IPv6)".
			/// </summary>
			public uint RetransmitTime;

			/// <summary>The path MTU discovery time-out, in milliseconds.</summary>
			public uint PathMtuDiscoveryTimeout;

			/// <summary>A <c>NL_LINK_LOCAL_ADDRESS_BEHAVIOR</c> link local address behavior type.</summary>
			public NL_LINK_LOCAL_ADDRESS_BEHAVIOR LinkLocalAddressBehavior;

			/// <summary>The link local IP address time-out, in milliseconds.</summary>
			public uint LinkLocalAddressTimeout;

			/// <summary>An array that specifies the zone part of scope IDs.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] public uint[] ZoneIndices;

			/// <summary>
			/// The site prefix length, in bits, of the IP interface address. The length, in bits, of the site prefix or network part of the
			/// IP interface address. For an IPv4 address, any value that is greater than 32 is an illegal value. For an IPv6 address, any
			/// value that is greater than 128 is an illegal value. A value of 255 is typically used to represent an illegal value.
			/// </summary>
			public uint SitePrefixLength;

			/// <summary>
			/// The interface metric. Note that the actual route metric that is used to compute the route preference is the summation of the
			/// route metric offset that is specified in the <c>Metric</c> member of the <c>MIB_IPFORWARD_ROW2</c> structure and the
			/// interface metric that is specified in this member.
			/// </summary>
			public uint Metric;

			/// <summary>The network layer MTU size, in bytes.</summary>
			public uint NlMtu;

			/// <summary>A value that indicates if the interface is connected to a network access point.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool Connected;

			/// <summary>A value that specifies if the network interface supports Wake on LAN.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool SupportsWakeUpPatterns;

			/// <summary>A value that specifies if the IP interface support neighbor discovery.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool SupportsNeighborDiscovery;

			/// <summary>A value that specifies if the IP interface support neighbor discovery.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool SupportsRouterDiscovery;

			/// <summary>
			/// The base for random reachable time, in milliseconds. The member is described in RFC 2461. For more information, see Neighbor
			/// Discovery for IP Version 6 (IPv6).
			/// </summary>
			public uint ReachableTime;

			/// <summary>
			/// A set of flags that indicate the transmit offload capabilities for the IP interface. The NL_INTERFACE_OFFLOAD_ROD structure
			/// is defined in the Nldef.h header file.
			/// </summary>
			public NL_INTERFACE_OFFLOAD_ROD TransmitOffload;

			/// <summary>
			/// A set of flags that indicate the receive offload capabilities for the IP interface. The NL_INTERFACE_OFFLOAD_ROD structure is
			/// defined in the Nldef.h header file.
			/// </summary>
			public NL_INTERFACE_OFFLOAD_ROD ReceiveOffload;

			/// <summary>
			/// A value that indicates if using default route on the interface should be disabled. VPN clients can use this member to
			/// restrict split tunneling.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool DisableDefaultRoutes;

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_IPINTERFACE_ROW"/> struct.
			/// </summary>
			/// <param name="family">The family.</param>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_IPINTERFACE_ROW(ADDRESS_FAMILY family, NET_LUID interfaceLuid) : this()
			{
				InitializeIpInterfaceEntry(out this);
				Family = family;
				InterfaceLuid = interfaceLuid;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_IPINTERFACE_ROW"/> struct.
			/// </summary>
			/// <param name="family">The family.</param>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_IPINTERFACE_ROW(ADDRESS_FAMILY family, uint interfaceIndex) : this()
			{
				InitializeIpInterfaceEntry(out this);
				Family = family;
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>Determines whether the specified value is equal to this instance.</summary>
			/// <param name="other">The value to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified value is equal to this instance; otherwise, <see langword="false"/>.</returns>
			public bool Equals(MIB_IPINTERFACE_ROW other) => Family.Equals(other.Family) && (InterfaceLuid.Value == other.InterfaceLuid.Value || InterfaceIndex == other.InterfaceIndex);
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

			/// <summary>Initializes a new instance of the <see cref="MIB_IPNET_ROW2"/> struct.</summary>
			/// <param name="ipV4">The neighbor IP address.</param>
			/// <param name="ifLuid">The locally unique identifier (LUID) for the network interface associated with this IP address.</param>
			/// <param name="macAddr">The physical hardware address of the adapter for the network interface associated with this IP address.</param>
			public MIB_IPNET_ROW2(SOCKADDR_IN ipV4, NET_LUID ifLuid, byte[] macAddr = null) : this(ipV4, macAddr) => InterfaceLuid = ifLuid;

			/// <summary>Initializes a new instance of the <see cref="MIB_IPNET_ROW2"/> struct.</summary>
			/// <param name="ipV4">The neighbor IP address.</param>
			/// <param name="ifIdx">
			/// The local index value for the network interface associated with this IP address. This index value may change when a network
			/// adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </param>
			/// <param name="macAddr">The physical hardware address of the adapter for the network interface associated with this IP address.</param>
			public MIB_IPNET_ROW2(SOCKADDR_IN ipV4, uint ifIdx, byte[] macAddr = null) : this(ipV4, macAddr) => InterfaceIndex = ifIdx;

			/// <summary>Initializes a new instance of the <see cref="MIB_IPNET_ROW2"/> struct.</summary>
			/// <param name="ipV6">The neighbor IP address.</param>
			/// <param name="ifLuid">The locally unique identifier (LUID) for the network interface associated with this IP address.</param>
			/// <param name="macAddr">The physical hardware address of the adapter for the network interface associated with this IP address.</param>
			public MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, NET_LUID ifLuid, byte[] macAddr = null) : this(ipV6, macAddr) => InterfaceLuid = ifLuid;

			/// <summary>Initializes a new instance of the <see cref="MIB_IPNET_ROW2"/> struct.</summary>
			/// <param name="ipV6">The neighbor IP address.</param>
			/// <param name="ifIdx">
			/// The local index value for the network interface associated with this IP address. This index value may change when a network
			/// adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </param>
			/// <param name="macAddr">The physical hardware address of the adapter for the network interface associated with this IP address.</param>
			public MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, uint ifIdx, byte[] macAddr = null) : this(ipV6, macAddr) => InterfaceIndex = ifIdx;

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
			public override string ToString() => $"{Address}; MAC:{PhysicalAddressToString(PhysicalAddress)}; If:{(InterfaceIndex != 0 ? InterfaceIndex.ToString() : InterfaceLuid.ToString())}";
		}

		/// <summary>
		/// <para>The <c>MIB_IPPATH_ROW</c> structure stores information about an IP path entry.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_IPPATH_ROW</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetIpPathTable function enumerates the IP path entries on a local system and returns this information in a MIB_IPPATH_TABLE
		/// structure as an array of <c>MIB_IPPATH_ROW</c> entries.
		/// </para>
		/// <para>The GetIpPathEntry function retrieves a single IP path entry and returns this information in a MIB_IPPATH_TABLE structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_mib_ippath_row typedef struct _MIB_IPPATH_ROW {
		// SOCKADDR_INET Source; SOCKADDR_INET Destination; NET_LUID InterfaceLuid; NET_IFINDEX InterfaceIndex; SOCKADDR_INET CurrentNextHop;
		// ULONG PathMtu; ULONG RttMean; ULONG RttDeviation; union { ULONG LastReachable; ULONG LastUnreachable; }; BOOLEAN IsReachable;
		// ULONG64 LinkTransmitSpeed; ULONG64 LinkReceiveSpeed; } MIB_IPPATH_ROW, *PMIB_IPPATH_ROW;
		[PInvokeData("netioapi.h", MSDNShortId = "0cfef3cb-bb96-4250-864b-2468a46ba277")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct MIB_IPPATH_ROW
		{
			/// <summary>
			/// <para>Type: <c>SOCKADDR_INET</c></para>
			/// <para>The source IP address for this IP path entry.</para>
			/// </summary>
			public SOCKADDR_INET Source;

			/// <summary>
			/// <para>Type: <c>SOCKADDR_INET</c></para>
			/// <para>The destination IP address for this IP path entry.</para>
			/// </summary>
			public SOCKADDR_INET Destination;

			/// <summary>
			/// <para>Type: <c>NET_LUID</c></para>
			/// <para>The locally unique identifier (LUID) for the network interface associated with this IP path entry.</para>
			/// </summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// <para>Type: <c>NET_IFINDEX</c></para>
			/// <para>
			/// The local index value for the network interface associated with this IP path entry. This index value may change when a
			/// network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </para>
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// <para>Type: <c>SOCKADDR_INET</c></para>
			/// <para>The current IP address of the next system or gateway en route. This member can change over the lifetime of a path.</para>
			/// </summary>
			public SOCKADDR_INET CurrentNextHop;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum transmission unit (MTU) size, in bytes, to the destination IP address for this IP path entry.</para>
			/// </summary>
			public uint PathMtu;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The estimated mean round-trip time (RTT), in milliseconds, to the destination IP address for this IP path entry.</para>
			/// </summary>
			public uint RttMean;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The estimated mean deviation for the round-trip time (RTT), in milliseconds, to the destination IP address for this IP path entry.
			/// </para>
			/// </summary>
			public uint RttDeviation;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The time, in milliseconds, that a node assumes that the destination IP address is reachable after having received OR
			/// unreachable after not having received a reachability confirmation.
			/// </para>
			/// </summary>
			public uint LastReachableOrUnreachable;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that indicates if the destination IP address is reachable for this IP path entry.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool IsReachable;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>The estimated speed in bits per second of the transmit link to the destination IP address for this IP path entry.</para>
			/// </summary>
			public ulong LinkTransmitSpeed;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>The estimated speed in bits per second of the receive link from the destination IP address for this IP path entry.</para>
			/// </summary>
			public ulong LinkReceiveSpeed;
		}

		/// <summary>The MIB_MULTICASTIPADDRESS_ROW structure stores information about a multicast IP address.</summary>
		// typedef struct _MIB_MULTICASTIPADDRESS_ROW { SOCKADDR_INET Address; NET_IFINDEX InterfaceIndex; NET_LUID InterfaceLuid; SCOPE_ID
		// ScopeId;} MIB_MULTICASTIPADDRESS_ROW, *PMIB_MULTICASTIPADDRESS_ROW; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559277(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559277")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct MIB_MULTICASTIPADDRESS_ROW : IEquatable<MIB_MULTICASTIPADDRESS_ROW>
		{
			/// <summary>The multicast IP address. This member can be an IPv6 address or an IPv4 address.</summary>
			public SOCKADDR_INET Address;

			/// <summary>
			/// The local index value for the network interface that is associated with this IP address. This index value might change when a
			/// network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>The locally unique identifier (LUID) for the network interface that is associated with this IP address.</summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// The scope ID of the multicast IP address. This member is applicable only to an IPv6 address. Your driver cannot set this
			/// member. This member is automatically determined by the interface that the address was added on.
			/// </summary>
			public SCOPE_ID ScopeId;

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_MULTICASTIPADDRESS_ROW"/> struct.
			/// </summary>
			/// <param name="ipv4">The ipv4.</param>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_MULTICASTIPADDRESS_ROW(SOCKADDR_IN ipv4, NET_LUID interfaceLuid) : this()
			{
				Address.Ipv4 = ipv4;
				InterfaceLuid = interfaceLuid;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_MULTICASTIPADDRESS_ROW"/> struct.
			/// </summary>
			/// <param name="ipv4">The ipv4.</param>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_MULTICASTIPADDRESS_ROW(SOCKADDR_IN ipv4, uint interfaceIndex) : this()
			{
				Address.Ipv4 = ipv4;
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_MULTICASTIPADDRESS_ROW"/> struct.
			/// </summary>
			/// <param name="ipv6">The ipv6.</param>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_MULTICASTIPADDRESS_ROW(SOCKADDR_IN6 ipv6, NET_LUID interfaceLuid) : this()
			{
				Address.Ipv6 = ipv6;
				InterfaceLuid = interfaceLuid;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_MULTICASTIPADDRESS_ROW"/> struct.
			/// </summary>
			/// <param name="ipv6">The ipv6.</param>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_MULTICASTIPADDRESS_ROW(SOCKADDR_IN6 ipv6, uint interfaceIndex) : this()
			{
				Address.Ipv6 = ipv6;
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>Determines whether the specified value is equal to this instance.</summary>
			/// <param name="other">The value to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified value is equal to this instance; otherwise, <see langword="false"/>.</returns>
			public bool Equals(MIB_MULTICASTIPADDRESS_ROW other) => Address.Equals(other.Address) && (InterfaceLuid.Value == other.InterfaceLuid.Value || InterfaceIndex == other.InterfaceIndex);
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
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct MIB_UNICASTIPADDRESS_ROW : IEquatable<MIB_UNICASTIPADDRESS_ROW>
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

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_UNICASTIPADDRESS_ROW"/> struct.
			/// </summary>
			/// <param name="ipv4">The ipv4.</param>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_UNICASTIPADDRESS_ROW(SOCKADDR_IN ipv4, NET_LUID interfaceLuid) : this()
			{
				InitializeUnicastIpAddressEntry(out this);
				Address.Ipv4 = ipv4;
				InterfaceLuid = interfaceLuid;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_UNICASTIPADDRESS_ROW"/> struct.
			/// </summary>
			/// <param name="ipv4">The ipv4.</param>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_UNICASTIPADDRESS_ROW(SOCKADDR_IN ipv4, uint interfaceIndex) : this()
			{
				InitializeUnicastIpAddressEntry(out this);
				Address.Ipv4 = ipv4;
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_UNICASTIPADDRESS_ROW"/> struct.
			/// </summary>
			/// <param name="ipv6">The ipv6.</param>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_UNICASTIPADDRESS_ROW(SOCKADDR_IN6 ipv6, NET_LUID interfaceLuid) : this()
			{
				InitializeUnicastIpAddressEntry(out this);
				Address.Ipv6 = ipv6;
				InterfaceLuid = interfaceLuid;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="MIB_UNICASTIPADDRESS_ROW"/> struct.
			/// </summary>
			/// <param name="ipv6">The ipv6.</param>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_UNICASTIPADDRESS_ROW(SOCKADDR_IN6 ipv6, uint interfaceIndex) : this()
			{
				InitializeUnicastIpAddressEntry(out this);
				Address.Ipv6 = ipv6;
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>Determines whether the specified value is equal to this instance.</summary>
			/// <param name="other">The value to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified value is equal to this instance; otherwise, <see langword="false"/>.</returns>
			public bool Equals(MIB_UNICASTIPADDRESS_ROW other) => Address.Equals(other.Address) && (InterfaceLuid.Value == other.InterfaceLuid.Value || InterfaceIndex == other.InterfaceIndex);
		}

		/// <summary>
		/// <para>
		/// The <c>NL_BANDWIDTH_INFORMATION</c> structure contains read-only information on the available bandwidth estimates and associated
		/// variance as determined by the TCP/IP stack.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>NL_BANDWIDTH_INFORMATION</c> structure is defined in the Nldef.h header file which is automatically included by the
		/// Iptypes.h header file which is automatically included in the Iphlpapi.h header file. The Nldef.h and Iptypes.h header files
		/// should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ns-nldef-_nl_bandwidth_information typedef struct
		// _NL_BANDWIDTH_INFORMATION { ULONG64 Bandwidth; ULONG64 Instability; BOOLEAN BandwidthPeaked; } NL_BANDWIDTH_INFORMATION, *PNL_BANDWIDTH_INFORMATION;
		[PInvokeData("nldef.h", MSDNShortId = "F5D7238A-EAE0-4D60-A0A4-D839F738EF48")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct NL_BANDWIDTH_INFORMATION
		{
			/// <summary>
			/// <para>The estimated maximum available bandwidth, in bits per second.</para>
			/// </summary>
			public ulong Bandwidth;

			/// <summary>
			/// <para>A measure of the variation based on recent bandwidth samples, in bits per second.</para>
			/// </summary>
			public ulong Instability;

			/// <summary>
			/// <para>
			/// A value that indicates if the bandwidth estimate in the <c>Bandwidth</c> member has peaked and reached its maximum value for
			/// the given network conditions.
			/// </para>
			/// <para>
			/// The TCP/IP stack uses a heuristic to set this variable. Until this variable is set, there is no guarantee that the true
			/// available maximum bandwidth is not higher than the estimated bandwidth in the <c>Bandwidth</c> member. However, it is safe to
			/// assume that maximum available bandwidth is not lower than the estimate reported in the <c>Bandwidth</c> member.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool BandwidthPeaked;
		}

		/// <summary>
		/// <para>
		/// The <c>NL_INTERFACE_OFFLOAD_ROD</c> structure specifies a set of flags that indicate the offload capabilities for an IP interface.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>NL_INTERFACE_OFFLOAD_ROD</c> structure is defined on Windows Vista and later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ns-nldef-_nl_interface_offload_rod typedef struct
		// _NL_INTERFACE_OFFLOAD_ROD { BOOLEAN NlChecksumSupported : 1; BOOLEAN NlOptionsSupported : 1; BOOLEAN TlDatagramChecksumSupported :
		// 1; BOOLEAN TlStreamChecksumSupported : 1; BOOLEAN TlStreamOptionsSupported : 1; BOOLEAN FastPathCompatible : 1; BOOLEAN
		// TlLargeSendOffloadSupported : 1; BOOLEAN TlGiantSendOffloadSupported : 1; } NL_INTERFACE_OFFLOAD_ROD, *PNL_INTERFACE_OFFLOAD_ROD;
		[PInvokeData("nldef.h", MSDNShortId = "764c7f5a-00df-461d-99ee-07f9e1f77ec7")]
		[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
		public struct NL_INTERFACE_OFFLOAD_ROD
		{
			/// <summary>The flags.</summary>
			public SupportedFlags Flags;

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => Flags.ToString();

			/// <summary>The flags.</summary>
			public enum SupportedFlags : byte
			{
				/// <summary>
				/// <para>The network adapter for this network interface supports the offload of IP checksum calculations.</para>
				/// </summary>
				NlChecksumSupported = 1 << 0,

				/// <summary>
				/// <para>
				/// The network adapter for this network interface supports the offload of IP checksum calculations for IPv4 packets with IP options.
				/// </para>
				/// </summary>
				NlOptionsSupported = 1 << 1,

				/// <summary>
				/// <para>The network adapter for this network interface supports the offload of UDP checksum calculations.</para>
				/// </summary>
				TlDatagramChecksumSupported = 1 << 2,

				/// <summary>
				/// <para>The network adapter for this network interface supports the offload of TCP checksum calculations.</para>
				/// </summary>
				TlStreamChecksumSupported = 1 << 3,

				/// <summary>
				/// <para>
				/// The network adapter for this network interface supports the offload of TCP checksum calculations for IPv4 packets
				/// containing IP options.
				/// </para>
				/// </summary>
				TlStreamOptionsSupported = 1 << 4,

				/// <summary/>
				FastPathCompatible = 1 << 5,

				/// <summary>
				/// <para>
				/// The network adapter for this network interface supports TCP Large Send Offload Version 1. With this capability, TCP can
				/// pass a buffer to be transmitted that is bigger than the maximum transmission unit (MTU) supported by the medium. Version
				/// 1 allows TCP to pass a buffer up to 64K to be transmitted.
				/// </para>
				/// </summary>
				TlLargeSendOffloadSupported = 1 << 6,

				/// <summary>
				/// <para>
				/// The network adapter for this network interface supports TCP Large Send Offload Version 2. With this capability, TCP can
				/// pass a buffer to be transmitted that is bigger than the maximum transmission unit (MTU) supported by the medium. Version
				/// 2 allows TCP to pass a buffer up to 256K to be transmitted.
				/// </para>
				/// </summary>
				TlGiantSendOffloadSupported = 1 << 7,
			}
		}

		/// <summary>The MIB_ANYCASTIPADDRESS_TABLE structure contains a table of anycast IP address entries.</summary>
		// typedef struct _MIB_ANYCASTIPADDRESS_TABLE { ULONG NumEntries; MIB_ANYCASTIPADDRESS_ROW Table[ANY_SIZE];}
		// MIB_ANYCASTIPADDRESS_TABLE, *PMIB_ANYCASTIPADDRESS_TABLE; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559193(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559193")]
		[CorrespondingType(typeof(MIB_ANYCASTIPADDRESS_ROW)), DefaultProperty(nameof(Table))]
		public class MIB_ANYCASTIPADDRESS_TABLE : SafeMibEntryBase<MIB_ANYCASTIPADDRESS_ROW>
		{
		}

		/// <summary>The MIB_IF_TABLE2 structure contains a table of logical and physical interface entries.</summary>
		// https://msdn.microsoft.com/en-us/library/windows/hardware/ff559224(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559224")]
		[CorrespondingType(typeof(MIB_IF_ROW2)), DefaultProperty(nameof(Table))]
		public class MIB_IF_TABLE2 : SafeMibEntryBase<MIB_IF_ROW2>
		{
		}

		/// <summary>
		/// The MIB_IFSTACK_TABLE structure contains a table of network interface stack row entries. This table specifies the relationship of
		/// the network interfaces on an interface stack.
		/// </summary>
		// typedef struct _MIB_IFSTACK_TABLE { ULONG NumEntries; MIB_IFSTACK_ROW Table[ANY_SIZE];} MIB_IFSTACK_TABLE, *PMIB_IFSTACK_TABLE; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559210(v=vs.85).aspx
		[CorrespondingType(typeof(MIB_IFSTACK_ROW)), DefaultProperty(nameof(Table))]
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559210")]
		public class MIB_IFSTACK_TABLE : SafeMibEntryBase<MIB_IFSTACK_ROW>
		{
		}

		/// <summary>
		/// The MIB_INVERTEDIFSTACK_TABLE structure contains a table of inverted network interface stack row entries. This table specifies
		/// the relationship of the network interfaces on an interface stack in reverse order.
		/// </summary>
		// typedef struct _MIB_INVERTEDIFSTACK_TABLE { ULONG NumEntries; MIB_INVERTEDIFSTACK_ROW Table[ANY_SIZE];} MIB_INVERTEDIFSTACK_TABLE,
		// *PMIB_INVERTEDIFSTACK_TABLE; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559240(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559240")]
		[CorrespondingType(typeof(MIB_INVERTEDIFSTACK_ROW)), DefaultProperty(nameof(Table))]
		public class MIB_INVERTEDIFSTACK_TABLE : SafeMibEntryBase<MIB_INVERTEDIFSTACK_ROW>
		{
		}

		/// <summary>The MIB_IPFORWARD_TABLE2 structure contains a table of IP route entries.</summary>
		// typedef struct _MIB_IPFORWARD_TABLE2 { ULONG NumEntries; MIB_IPFORWARD_ROW2 Table[ANY_SIZE];} MIB_IPFORWARD_TABLE2,
		// *PMIB_IPFORWARD_TABLE2; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559252(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559252")]
		[CorrespondingType(typeof(MIB_IPFORWARD_ROW2)), DefaultProperty(nameof(Table))]
		public class MIB_IPFORWARD_TABLE2 : SafeMibEntryBase<MIB_IPFORWARD_ROW2>
		{
		}

		/// <summary>The MIB_IPINTERFACE_TABLE structure contains a table of IP interface entries.</summary>
		// typedef struct _MIB_IPINTERFACE_TABLE { ULONG NumEntries; MIB_IPINTERFACE_ROW Table[ANY_SIZE];} MIB_IPINTERFACE_TABLE,
		// *PMIB_IPINTERFACE_TABLE; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559260(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559260")]
		[CorrespondingType(typeof(MIB_IPINTERFACE_ROW)), DefaultProperty(nameof(Table))]
		public class MIB_IPINTERFACE_TABLE : SafeMibEntryBase<MIB_IPINTERFACE_ROW>
		{
		}

		/// <summary>The MIB_IPNET_TABLE2 structure contains a table of neighbor IP address entries.</summary>
		// typedef struct _MIB_IPNET_TABLE2 { ULONG NumEntries; MIB_IPNET_ROW2 Table[ANY_SIZE];} MIB_IPNET_TABLE2, *PMIB_IPNET_TABLE2; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559267(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559267")]
		[CorrespondingType(typeof(MIB_IPNET_ROW2)), DefaultProperty(nameof(Table))]
		public class MIB_IPNET_TABLE2 : SafeMibEntryBase<MIB_IPNET_ROW2>
		{
		}

		/// <summary>The MIB_IPPATH_TABLE structure contains a table of IP path entries.</summary>
		// typedef struct _MIB_IPPATH_TABLE { ULONG NumEntries; MIB_IPPATH_ROW Table[ANY_SIZE];} MIB_IPPATH_TABLE, *PMIB_IPPATH_TABLE; https://msdn.microsoft.com/en-us/library/windows/hardware/ff559273(v=vs.85).aspx
		[PInvokeData("Netioapi.h", MSDNShortId = "ff559273")]
		[CorrespondingType(typeof(MIB_IPPATH_ROW)), DefaultProperty(nameof(Table))]
		public class MIB_IPPATH_TABLE : SafeMibEntryBase<MIB_IPPATH_ROW>
		{
		}

		/// <summary>
		/// <para>The <c>MIB_MULTICASTIPADDRESS_TABLE</c> structure contains a table of multicast IP address entries.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_MULTICASTIPADDRESS_TABLE</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetMulticastIpAddressTable function enumerates the multicast IP addresses on a local system and returns this information in
		/// an <c>MIB_MULTICASTIPADDRESS_TABLE</c> structure.
		/// </para>
		/// <para>
		/// The <c>MIB_MULTICASTIPADDRESS_TABLE</c> structure may contain padding for alignment between the <c>NumEntries</c> member and the
		/// first MIB_MULTICASTIPADDRESS_ROW array entry in the <c>Table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_MULTICASTIPADDRESS_ROW</c> array entries in the <c>Table</c> member. Any access to a <c>MIB_MULTICASTIPADDRESS_ROW</c>
		/// array entry should assume padding may exist.
		/// </para>
		/// <para>
		/// Note that the Netioapi.h header file is automatically included in the Iphlpapi.h header file. The Netioapi.h header file should
		/// never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_mib_multicastipaddress_table typedef struct
		// _MIB_MULTICASTIPADDRESS_TABLE { ULONG NumEntries; MIB_MULTICASTIPADDRESS_ROW Table[ANY_SIZE]; } MIB_MULTICASTIPADDRESS_TABLE, *PMIB_MULTICASTIPADDRESS_TABLE;
		[PInvokeData("netioapi.h", MSDNShortId = "7ae1ec12-aa67-40ff-9641-410099685234")]
		[CorrespondingType(typeof(MIB_MULTICASTIPADDRESS_ROW)), DefaultProperty(nameof(Table))]
		public class MIB_MULTICASTIPADDRESS_TABLE : SafeMibEntryBase<MIB_MULTICASTIPADDRESS_ROW>
		{
		}

		/// <summary>
		/// <para>The <c>MIB_UNICASTIPADDRESS_TABLE</c> structure contains a table of unicast IP address entries.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_UNICASTIPADDRESS_TABLE</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetUnicastIpAddressTable function enumerates the unicast IP addresses on a local system and returns this information in an
		/// <c>MIB_UNICASTIPADDRESS_TABLE</c> structure.
		/// </para>
		/// <para>
		/// The <c>MIB_UNICASTIPADDRESS_TABLE</c> structure may contain padding for alignment between the <c>NumEntries</c> member and the
		/// first MIB_UNICASTIPADDRESS_ROW array entry in the <c>Table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_UNICASTIPADDRESS_ROW</c> array entries in the <c>Table</c> member. Any access to a <c>MIB_UNICASTIPADDRESS_ROW</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves a unicast IP address table and prints some values from each of the retrieved
		/// MIB_UNICASTIPADDRESS_ROW structures.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/ns-netioapi-_mib_unicastipaddress_table typedef struct
		// _MIB_UNICASTIPADDRESS_TABLE { ULONG NumEntries; MIB_UNICASTIPADDRESS_ROW Table[ANY_SIZE]; } MIB_UNICASTIPADDRESS_TABLE, *PMIB_UNICASTIPADDRESS_TABLE;
		[PInvokeData("netioapi.h", MSDNShortId = "b064494c-d0d5-4570-b255-4cc95412fd3a")]
		[CorrespondingType(typeof(MIB_UNICASTIPADDRESS_ROW)), DefaultProperty(nameof(Table))]
		public class MIB_UNICASTIPADDRESS_TABLE : SafeMibEntryBase<MIB_UNICASTIPADDRESS_ROW>
		{
		}

		/// <summary>Base class for all structures that support a variable length array of structures with a count in the first field.</summary>
		/// <typeparam name="T">Type of the structure array.</typeparam>
		public abstract class SafeMibEntryBase<T> : SafeMibTableHandle, IEnumerable<T> where T : struct
		{
			/// <summary>Gets the number of interface entries in the array.</summary>
			public virtual uint NumEntries => IsInvalid ? 0 : handle.ToStructure<uint>();

			/// <summary>Gets the array of <typeparamref name="T"/> structures containing interface entries.</summary>
			public virtual T[] Table => ToArray<T>((int)NumEntries, Marshal.SizeOf(typeof(ulong)));

#if ALLOWSPAN
			/// <summary>Gets the <see cref="Span{T}"/> containing interface entries.</summary>
			public virtual ReadOnlySpan<T> TableAsSpan => AsReadOnlySpan<T>((int)NumEntries, Marshal.SizeOf(typeof(ulong)));
#endif

			/// <summary>Gets the enumerator.</summary>
			public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>) Table).GetEnumerator();

			/// <summary>Gets the enumerator.</summary>
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		/// <summary>SafeHandle for all objects that must be freed with FreeMibTable.</summary>
		/// <seealso cref="Vanara.InteropServices.GenericSafeHandle"/>
		public class SafeMibTableHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeMibTableHandle"/> class.</summary>
			public SafeMibTableHandle() : this(IntPtr.Zero)
			{
			}

			/// <summary>Initializes a new instance of the <see cref="SafeMibTableHandle"/> class.</summary>
			/// <param name="bufferPtr">The buffer PTR.</param>
			/// <param name="own">if set to <c>true</c> [own].</param>
			public SafeMibTableHandle(IntPtr bufferPtr, bool own = true) : base(bufferPtr, h => { FreeMibTable(h); return true; }, own)
			{
			}

#if ALLOWSPAN
			/// <summary>Exposes a <see cref="ReadOnlySpan{T}"/> from the pointer.</summary>
			/// <typeparam name="T">The structure type of the array.</typeparam>
			/// <param name="length">The number of span elements.</param>
			/// <param name="prefixBytes">The number of bytes to skip before processing the array.</param>
			public ReadOnlySpan<T> AsReadOnlySpan<T>(int length, int prefixBytes = 0) => IsInvalid ? null : handle.AsReadOnlySpan<T>(length, prefixBytes);
#endif

			/// <summary>Extracts the array from the pointer.</summary>
			/// <typeparam name="T">The structure type of the array.</typeparam>
			/// <param name="count">The number of items.</param>
			/// <param name="prefixBytes">The number of bytes to skip before processing the array.</param>
			public T[] ToArray<T>(int count, int prefixBytes = 0) => IsInvalid ? null : handle.ToArray<T>(count, prefixBytes);
		}
	}
}