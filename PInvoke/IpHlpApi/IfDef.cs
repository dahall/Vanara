using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>The primary compartment.</summary>
		public const uint NET_IF_COMPARTMENT_ID_PRIMARY = 1;

		/// <summary>The unspecified compartment.</summary>
		public const uint NET_IF_COMPARTMENT_ID_UNSPECIFIED = 0;

		/// <summary>Datalink Interface Administrative State. Indicates whether the interface has been administratively enabled.</summary>
		[PInvokeData("ifdef.h")]
		public enum IF_ADMINISTRATIVE_STATE
		{
			/// <summary>If disabled.</summary>
			IF_ADMINISTRATIVE_DISABLED,

			/// <summary>If enabled.</summary>
			IF_ADMINISTRATIVE_ENABLED,

			/// <summary>If dial on demand.</summary>
			IF_ADMINISTRATIVE_DEMANDDIAL,
		}

		/// <summary>The IF_OPER_STATUS enumeration specifies the operational status of an interface.</summary>
		[PInvokeData("ifdef.h")]
		public enum IF_OPER_STATUS : uint
		{
			/// <summary>The interface is up and operational. The interface is able to pass packets.</summary>
			IfOperStatusUp = 1,

			/// <summary>The interface is not down and not operational. The interface is unable to pass packets.</summary>
			IfOperStatusDown,

			/// <summary>The interface is being tested.</summary>
			IfOperStatusTesting,

			/// <summary>The interface status is unknown.</summary>
			IfOperStatusUnknown,

			/// <summary>
			/// The interface is not in a condition to pass packets. The interface is not up, but is in a pending state, waiting for some
			/// external event. This state identifies the situation where the interface is waiting for events to place it in the up state.
			/// </summary>
			IfOperStatusDormant,

			/// <summary>
			/// This state is a refinement on the down state which indicates that the interface is down specifically because some component
			/// (for example, a hardware component) is not present in the system.
			/// </summary>
			IfOperStatusNotPresent,

			/// <summary>
			/// This state is a refinement on the down state. The interface is operational, but a networking layer below the interface is not operational.
			/// </summary>
			IfOperStatusLowerLayerDown,
		}

		/// <summary>The NET_IF_ACCESS_TYPE enumeration type specifies the NDIS network interface access type.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_access_type typedef enum _NET_IF_ACCESS_TYPE {
		// NET_IF_ACCESS_LOOPBACK , NET_IF_ACCESS_BROADCAST , NET_IF_ACCESS_POINT_TO_POINT , NET_IF_ACCESS_POINT_TO_MULTI_POINT ,
		// NET_IF_ACCESS_MAXIMUM } NET_IF_ACCESS_TYPE, *PNET_IF_ACCESS_TYPE;
		[PInvokeData("ifdef.h", MSDNShortId = "0f8c0866-5ecb-4632-b3bf-cadeee74ce5f")]
		public enum NET_IF_ACCESS_TYPE
		{
			/// <summary>
			/// Specifies the loopback access type. This access type indicates that the interface loops back transmit data as receive data.
			/// </summary>
			NET_IF_ACCESS_LOOPBACK = 1,

			/// <summary>
			/// Specifies the LAN access type, which includes Ethernet. This access type indicates that the interface provides native support
			/// for multicast or broadcast services.
			/// </summary>
			NET_IF_ACCESS_BROADCAST,

			/// <summary>Specifies point-to-point access that supports CoNDIS and WAN, except for non-broadcast multi-access (NBMA) interfaces.</summary>
			NET_IF_ACCESS_POINT_TO_POINT,

			/// <summary>
			/// Specifies point-to-multipoint access that supports non-broadcast multi-access (NBMA) media, including the "RAS Internal"
			/// interface, and native (non-LANE) ATM.
			/// </summary>
			NET_IF_ACCESS_POINT_TO_MULTI_POINT,

			/// <summary>A maximum value for testing purposes.</summary>
			NET_IF_ACCESS_MAXIMUM,
		}

		/// <summary>
		/// The NET_IF_ADMIN_STATUS enumeration type specifies the NDIS network interface administrative status, as described in RFC 2863.
		/// </summary>
		/// <remarks>For more information on RFC 2863, see "The Interfaces Group MIB".</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_admin_status typedef enum _NET_IF_ADMIN_STATUS {
		// NET_IF_ADMIN_STATUS_UP , NET_IF_ADMIN_STATUS_DOWN , NET_IF_ADMIN_STATUS_TESTING } NET_IF_ADMIN_STATUS, *PNET_IF_ADMIN_STATUS;
		[PInvokeData("ifdef.h", MSDNShortId = "9f6978a9-a779-49c6-b642-c411fa764972")]
		public enum NET_IF_ADMIN_STATUS
		{
			/// <summary>
			/// Specifies that the interface is initialized and enabled, but the interface is not necessarily ready to transmit and receive
			/// network data because that depends on the operational status of the interface. For more information about the operational
			/// status of an interface, see OID_GEN_OPERATIONAL_STATUS.
			/// </summary>
			NET_IF_ADMIN_STATUS_UP = 1,

			/// <summary>Specifies that the interface is down, and this interface cannot be used to transmit or receive network data.</summary>
			NET_IF_ADMIN_STATUS_DOWN,

			/// <summary>Specifies that the interface is in a test mode, and no network data can be transmitted or received.</summary>
			NET_IF_ADMIN_STATUS_TESTING,
		}

		/// <summary>The NET_IF_CONNECTION_TYPE enumeration type specifies the NDIS network interface connection type.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_connection_type typedef enum _NET_IF_CONNECTION_TYPE {
		// NET_IF_CONNECTION_DEDICATED , NET_IF_CONNECTION_PASSIVE , NET_IF_CONNECTION_DEMAND , NET_IF_CONNECTION_MAXIMUM }
		// NET_IF_CONNECTION_TYPE, *PNET_IF_CONNECTION_TYPE;
		[PInvokeData("ifdef.h", MSDNShortId = "af1ffcf2-65cf-4d80-b702-a843b6d19fdc")]
		public enum NET_IF_CONNECTION_TYPE : uint
		{
			/// <summary>
			/// Specifies the dedicated connection type. The connection comes up automatically when media sense is TRUE. For example, an
			/// Ethernet connection is dedicated.
			/// </summary>
			NET_IF_CONNECTION_DEDICATED = 1,

			/// <summary>
			/// Specifies the passive connection type. The other end must bring up the connection to the local station. For example, the RAS
			/// interface is passive.
			/// </summary>
			NET_IF_CONNECTION_PASSIVE,

			/// <summary>
			/// Specifies the demand-dial connection type. A demand-dial connection comes up in response to a local action--for example,
			/// sending a packet.
			/// </summary>
			NET_IF_CONNECTION_DEMAND,

			/// <summary>A maximum value for testing purposes.</summary>
			NET_IF_CONNECTION_MAXIMUM,
		}

		/// <summary>The NET_IF_ACCESS_TYPE enumeration type specifies the NDIS network interface direction type.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_direction_type typedef enum _NET_IF_DIRECTION_TYPE {
		// NET_IF_DIRECTION_SENDRECEIVE , NET_IF_DIRECTION_SENDONLY , NET_IF_DIRECTION_RECEIVEONLY , NET_IF_DIRECTION_MAXIMUM }
		// NET_IF_DIRECTION_TYPE, *PNET_IF_DIRECTION_TYPE;
		[PInvokeData("ifdef.h", MSDNShortId = "e9f80162-5a1c-44c8-af31-a0c0f986edc2")]
		public enum NET_IF_DIRECTION_TYPE
		{
			/// <summary>
			/// Indicates the send and receive direction type. This direction type indicates that the NDIS network interface can send and
			/// receive data.
			/// </summary>
			NET_IF_DIRECTION_SENDRECEIVE,

			/// <summary>
			/// Indicates the send only direction type. This direction type indicates that the NDIS network interface can only send data.
			/// </summary>
			NET_IF_DIRECTION_SENDONLY,

			/// <summary>
			/// Indicates the receive only direction type. This direction type indicates that the NDIS network interface can only receive data.
			/// </summary>
			NET_IF_DIRECTION_RECEIVEONLY,

			/// <summary>A maximum value for testing purposes.</summary>
			NET_IF_DIRECTION_MAXIMUM,
		}

		/// <summary>The NET_IF_MEDIA_CONNECT_STATE enumeration type specifies the NDIS network interface connection state.</summary>
		/// <remarks>
		/// The NDIS_MEDIA_CONNECT_STATE enumeration type, used to describe NDIS interface providers in the OID_GEN_MEDIA_CONNECT_STATUS_EX
		/// OID, is equivalent to this enumeration.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_media_connect_state typedef enum
		// _NET_IF_MEDIA_CONNECT_STATE { MediaConnectStateUnknown , MediaConnectStateConnected , MediaConnectStateDisconnected }
		// NET_IF_MEDIA_CONNECT_STATE, *PNET_IF_MEDIA_CONNECT_STATE;
		[PInvokeData("ifdef.h", MSDNShortId = "5af5e050-4b2b-45a9-8549-3a3818d7b06f")]
		public enum NET_IF_MEDIA_CONNECT_STATE
		{
			/// <summary>The connection state of the interface is unknown.</summary>
			MediaConnectStateUnknown,

			/// <summary>The interface is connected to the network.</summary>
			MediaConnectStateConnected,

			/// <summary>The interface is not connected to the network.</summary>
			MediaConnectStateDisconnected,
		}

		/// <summary>The NET_IF_MEDIA_DUPLEX_STATE enumeration type specifies the NDIS network interface duplex state.</summary>
		/// <remarks>
		/// The NDIS_MEDIA_DUPLEX_STATE, enumeration type, used to describe NDIS interface providers in the OID_GEN_MEDIA_DUPLEX_STATE, OID,
		/// is equivalent to this enumeration.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_media_duplex_state typedef enum
		// _NET_IF_MEDIA_DUPLEX_STATE { MediaDuplexStateUnknown, MediaDuplexStateHalf, MediaDuplexStateFull } NET_IF_MEDIA_DUPLEX_STATE, *PNET_IF_MEDIA_DUPLEX_STATE;
		[PInvokeData("ifdef.h", MSDNShortId = "0bd49b84-0b73-4628-bd86-65b599f791df")]
		public enum NET_IF_MEDIA_DUPLEX_STATE
		{
			/// <summary>The duplex state of the miniport adapter is unknown.</summary>
			MediaDuplexStateUnknown,

			/// <summary>The miniport adapter can transmit or receive but not both simultaneously.</summary>
			MediaDuplexStateHalf,

			/// <summary>The miniport adapter can transmit and receive simultaneously.</summary>
			MediaDuplexStateFull
		}

		/// <summary>The IF_OPER_STATUS enumeration specifies the operational status of an interface.</summary>
		[PInvokeData("ifdef.h")]
		public enum NET_IF_OPER_STATUS : uint
		{
			/// <summary>The interface is up and operational. The interface is able to pass packets.</summary>
			NET_IF_OPER_STATUS_UP = 1,

			/// <summary>The interface is not down and not operational. The interface is unable to pass packets.</summary>
			NET_IF_OPER_STATUS_DOWN,

			/// <summary>The interface is being tested.</summary>
			NET_IF_OPER_STATUS_TESTING,

			/// <summary>The interface status is unknown.</summary>
			NET_IF_OPER_STATUS_UNKNOWN,

			/// <summary>
			/// The interface is not in a condition to pass packets. The interface is not up, but is in a pending state, waiting for some
			/// external event. This state identifies the situation where the interface is waiting for events to place it in the up state.
			/// </summary>
			NET_IF_OPER_STATUS_DORMANT,

			/// <summary>
			/// This state is a refinement on the down state which indicates that the interface is down specifically because some component
			/// (for example, a hardware component) is not present in the system.
			/// </summary>
			NET_IF_OPER_STATUS_NOT_PRESENT,

			/// <summary>
			/// This state is a refinement on the down state. The interface is operational, but a networking layer below the interface is not operational.
			/// </summary>
			NET_IF_OPER_STATUS_LOWER_LAYER_DOWN,
		}

		/// <summary>
		/// 
		/// </summary>
		public enum NET_IF_RCV_ADDRESS_TYPE
		{
			/// <summary>
			/// The net if RCV address type other
			/// </summary>
			NET_IF_RCV_ADDRESS_TYPE_OTHER = 1,
			/// <summary>
			/// The net if RCV address type volatile
			/// </summary>
			NET_IF_RCV_ADDRESS_TYPE_VOLATILE = 2,
			/// <summary>
			/// The net if RCV address type non volatile
			/// </summary>
			NET_IF_RCV_ADDRESS_TYPE_NON_VOLATILE = 3
		}

		/// <summary>
		/// The TUNNEL_TYPE enumeration type defines the encapsulation method used by a tunnel, as described by the Internet Assigned Names
		/// Authority (IANA).
		/// </summary>
		[PInvokeData("ifdef.h")]
		public enum TUNNEL_TYPE : uint
		{
			/// <summary>Indicates that a tunnel is not specified.</summary>
			TUNNEL_TYPE_NONE = 0,

			/// <summary>Indicates that none of the following tunnel types is specified.</summary>
			TUNNEL_TYPE_OTHER = 1,

			/// <summary>
			/// A packet is encapsulated directly within a normal IP header, with no intermediate header, and unicast to the remote tunnel endpoint.
			/// </summary>
			TUNNEL_TYPE_DIRECT = 2,

			/// <summary>
			/// An IPv6 packet is encapsulated directly within an IPv4 header, with no intermediate header, and unicast to the destination
			/// determined by the 6to4 protocol.
			/// </summary>
			TUNNEL_TYPE_6TO4 = 11,

			/// <summary>
			/// An IPv6 packet is encapsulated directly within an IPv4 header, with no intermediate header, and unicast to the destination
			/// determined by the ISATAP protocol.
			/// </summary>
			TUNNEL_TYPE_ISATAP = 13,

			/// <summary>Teredo encapsulation.</summary>
			TUNNEL_TYPE_TEREDO = 14,

			/// <summary>
			/// Specifies that the tunnel uses IP over Hypertext Transfer Protocol Secure (HTTPS). This tunnel type is supported in Windows 7
			/// and later versions of the Windows operating system.
			/// </summary>
			TUNNEL_TYPE_IPHTTPS = 15
		}

		/// <summary>The <c>IF_COUNTED_STRING</c> structure specifies a counted string for NDIS interfaces.</summary>
		/// <remarks>
		/// <para>The <c>IF_COUNTED_STRING</c> structure is the data type for various NDIS string structures, such as <c>NDIS_IF_COUNTED_STRING</c>.</para>
		/// <para>If the string is NULL-terminated, the <c>Length</c> member must not include the terminating NULL character.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ns-ifdef-_if_counted_string_lh typedef struct _IF_COUNTED_STRING_LH {
		// USHORT Length; WCHAR String[IF_MAX_STRING_SIZE + 1]; } IF_COUNTED_STRING_LH, *PIF_COUNTED_STRING_LH;
		[PInvokeData("ifdef.h", MSDNShortId = "44B59154-C5CA-42F0-A972-021833E29D81")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IF_COUNTED_STRING
		{
			/// <summary>A USHORT value that contains the length, in bytes, of the string.</summary>
			public ushort Length;

			/// <summary>A WCHAR buffer that contains the string. The string does not need to be null-terminated.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
			public string String;
		}

		/// <summary/>
		[PInvokeData("ifdef.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IF_PHYSICAL_ADDRESS
		{
			/// <summary>A USHORT value that contains the length, in bytes, of the string.</summary>
			public ushort Length;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string Address;
		}

		/// <summary>
		/// The NDIS_INTERFACE_INFORMATION structure provides information about a network interface for the OID_GEN_INTERFACE_INFO OID.
		/// </summary>
		/// <remarks>
		/// <para>
		/// NDIS interface providers populate an NDIS_INTERFACE_INFORMATION structure in response to a query of the OID_GEN_INTERFACE_INFO
		/// OID. This structure contains information that changes during the lifetime of the interface.
		/// </para>
		/// <para>To register as an interface provider, an NDIS driver calls the NdisIfRegisterProvider function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ns-ifdef-_ndis_interface_information typedef struct
		// _NDIS_INTERFACE_INFORMATION { NET_IF_OPER_STATUS ifOperStatus; ULONG ifOperStatusFlags; NET_IF_MEDIA_CONNECT_STATE
		// MediaConnectState; NET_IF_MEDIA_DUPLEX_STATE MediaDuplexState; ULONG ifMtu; BOOLEAN ifPromiscuousMode; BOOLEAN
		// ifDeviceWakeUpEnable; ULONG64 XmitLinkSpeed; ULONG64 RcvLinkSpeed; ULONG64 ifLastChange; ULONG64 ifCounterDiscontinuityTime;
		// ULONG64 ifInUnknownProtos; ULONG64 ifInDiscards; ULONG64 ifInErrors; ULONG64 ifHCInOctets; ULONG64 ifHCInUcastPkts; ULONG64
		// ifHCInMulticastPkts; ULONG64 ifHCInBroadcastPkts; ULONG64 ifHCOutOctets; ULONG64 ifHCOutUcastPkts; ULONG64 ifHCOutMulticastPkts;
		// ULONG64 ifHCOutBroadcastPkts; ULONG64 ifOutErrors; ULONG64 ifOutDiscards; ULONG64 ifHCInUcastOctets; ULONG64
		// ifHCInMulticastOctets; ULONG64 ifHCInBroadcastOctets; ULONG64 ifHCOutUcastOctets; ULONG64 ifHCOutMulticastOctets; ULONG64
		// ifHCOutBroadcastOctets; NET_IF_COMPARTMENT_ID CompartmentId; ULONG SupportedStatistics; } NDIS_INTERFACE_INFORMATION, *PNDIS_INTERFACE_INFORMATION;
		[PInvokeData("ifdef.h", MSDNShortId = "9bfcd319-faff-4bae-8653-511154c19863")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NDIS_INTERFACE_INFORMATION
		{
			/// <summary>
			/// The operational status of the interface. This status is the same as the value that the OID_GEN_OPERATIONAL_STATUS OID returns.
			/// </summary>
			public NET_IF_OPER_STATUS ifOperStatus;

			/// <summary>
			/// The operational status flags of the interface. This field is reserved for the NDIS proxy interface provider. Other interface
			/// providers should set this member to zero.
			/// </summary>
			public uint ifOperStatusFlags;

			/// <summary>The NET_IF_MEDIA_CONNECT_STATE connection state type.</summary>
			public NET_IF_MEDIA_CONNECT_STATE MediaConnectState;

			/// <summary>
			/// The media duplex state of the interface. This state is the same as the value that the OID_GEN_MEDIA_DUPLEX_STATE OID returns.
			/// </summary>
			public NET_IF_MEDIA_DUPLEX_STATE MediaDuplexState;

			/// <summary>
			/// The maximum transmission unit (MTU) of the interface. This MTU is the same as the value that the OID_GEN_MAXIMUM_FRAME_SIZE
			/// OID returns.
			/// </summary>
			public uint ifMtu;

			/// <summary>
			/// A Boolean value that is <c>TRUE</c> if the interface is in promiscuous mode or <c>FALSE</c> if it is not. This value is the
			/// same as the value that OID_GEN_PROMISCUOUS_MODE OID query returns.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool ifPromiscuousMode;

			/// <summary>
			/// A Boolean value that is <c>TRUE</c> if the interface supports wake-on-LAN capability and the capability is enabled, or
			/// <c>FALSE</c> if it does not.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool ifDeviceWakeUpEnable;

			/// <summary>
			/// The transmit link speed, in bytes per second, of the interface. This speed is the same as the value that an
			/// OID_GEN_XMIT_LINK_SPEED OID query returns.
			/// </summary>
			public ulong XmitLinkSpeed;

			/// <summary>
			/// The receive link speed, in bytes per second, of the interface. This speed is the same as the value that an
			/// OID_GEN_RCV_LINK_SPEED OID query returns.
			/// </summary>
			public ulong RcvLinkSpeed;

			/// <summary>
			/// The time that the interface entered its current operational state. This time is the same as the value that an
			/// OID_GEN_LAST_CHANGE OID query returns.
			/// </summary>
			public ulong ifLastChange;

			/// <summary>
			/// The time of the last discontinuity of the interface's counters. This time is the same as the value that an
			/// OID_GEN_DISCONTINUITY_TIME OID query returns.
			/// </summary>
			public ulong ifCounterDiscontinuityTime;

			/// <summary>
			/// The number of packets that were received through the interface and that were discarded because of an unknown or unsupported
			/// protocol. This number is the same as the value that an OID_GEN_UNKNOWN_PROTOS OID query returns.
			/// </summary>
			public ulong ifInUnknownProtos;

			/// <summary>
			/// The number of inbound packets that were discarded even though no errors had been detected to prevent them from being
			/// deliverable to a higher-layer protocol. This number is the same as the value that an OID_GEN_RCV_DISCARDS OID query returns.
			/// </summary>
			public ulong ifInDiscards;

			/// <summary>
			/// The number of inbound packets that contained errors that prevented them from being deliverable to a higher layer protocol.
			/// This number is the same as the value that an OID_GEN_RCV_ERROR OID query returns.
			/// </summary>
			public ulong ifInErrors;

			/// <summary>
			/// The total number of bytes that are received on this interface. This number is the same as the value that an OID_GEN_BYTES_RCV
			/// OID returns.
			/// </summary>
			public ulong ifHCInOctets;

			/// <summary>
			/// The number of directed packets that are received without errors on the interface. This number is the same as the value that
			/// an OID_GEN_DIRECTED_FRAMES_RCV OID query returns.
			/// </summary>
			public ulong ifHCInUcastPkts;

			/// <summary>
			/// The number of multicast/functional packets that are received without errors on the interface. This number is the same as the
			/// value that an OID_GEN_MULTICAST_FRAMES_RCV OID query returns.
			/// </summary>
			public ulong ifHCInMulticastPkts;

			/// <summary>
			/// The number of broadcast packets that are received without errors on the interface. This number is the same as the value that
			/// an OID_GEN_BROADCAST_FRAMES_RCV OID query returns.
			/// </summary>
			public ulong ifHCInBroadcastPkts;

			/// <summary>
			/// The number of bytes that are transmitted without errors on the interface. This number is the same as the value that an
			/// OID_GEN_BYTES_XMIT OID query returns.
			/// </summary>
			public ulong ifHCOutOctets;

			/// <summary>
			/// The number of directed packets that are transmitted without errors on the interface. This number is the same as the value
			/// that an OID_GEN_DIRECTED_FRAMES_XMIT OID query returns.
			/// </summary>
			public ulong ifHCOutUcastPkts;

			/// <summary>
			/// The number of multicast/functional packets that are transmitted without errors on the interface. This number is the same as
			/// the value that an OID_GEN_MULTICAST_FRAMES_XMIT OID query returns.
			/// </summary>
			public ulong ifHCOutMulticastPkts;

			/// <summary>
			/// The number of broadcast packets that are transmitted without errors on the interface. This number is the same as the value
			/// that an OID_GEN_BROADCAST_FRAMES_XMIT OID query returns.
			/// </summary>
			public ulong ifHCOutBroadcastPkts;

			/// <summary>
			/// The number of packets that the interface fails to transmit. This number is the same as the value that an OID_GEN_XMIT_ERROR
			/// OID query returns.
			/// </summary>
			public ulong ifOutErrors;

			/// <summary>
			/// The number of packets that the interface discards. This number is the same as the value that an OID_GEN_XMIT_DISCARDS OID
			/// query returns.
			/// </summary>
			public ulong ifOutDiscards;

			/// <summary>
			/// The number of bytes in directed packets that are received without errors. This count is the same value that
			/// OID_GEN_DIRECTED_BYTES_RCV returns.
			/// </summary>
			public ulong ifHCInUcastOctets;

			/// <summary>
			/// The number of bytes in multicast/functional packets that are received without errors. This count is the same value that
			/// OID_GEN_MULTICAST_BYTES_RCV returns.
			/// </summary>
			public ulong ifHCInMulticastOctets;

			/// <summary>
			/// The number of bytes in broadcast packets that are received without errors. This count is the same value that
			/// OID_GEN_BROADCAST_BYTES_RCV returns.
			/// </summary>
			public ulong ifHCInBroadcastOctets;

			/// <summary>
			/// The number of bytes in directed packets that are transmitted without errors. This count is the same value that
			/// OID_GEN_DIRECTED_BYTES_XMIT returns.
			/// </summary>
			public ulong ifHCOutUcastOctets;

			/// <summary>
			/// The number of bytes in multicast/functional packets that are transmitted without errors. This count is the same value that
			/// OID_GEN_MULTICAST_BYTES_XMIT returns.
			/// </summary>
			public ulong ifHCOutMulticastOctets;

			/// <summary>
			/// The number of bytes in broadcast packets that are transmitted without errors. This count is the same value that
			/// OID_GEN_BROADCAST_BYTES_XMIT returns.
			/// </summary>
			public ulong ifHCOutBroadcastOctets;

			/// <summary>
			/// The compartment that the interface belongs to, if the interface provider can provide the ID of the compartment to which the
			/// interface belongs. Otherwise, it should return NET_IF_COMPARTMENT_ID_UNSPECIFIED. If the interface provider returns
			/// NET_IF_COMPARTMENT_ID_UNSPECIFIED for the compartment ID, NDIS will return the right compartment ID for this interface.
			/// </summary>
			public uint CompartmentId;

			/// <summary>
			/// The supported statistics. For more information, see the <c>SupportedStatistics</c> member of the
			/// NDIS_MINIPORT_ADAPTER_GENERAL_ATTRIBUTES structure.
			/// </summary>
			public uint SupportedStatistics;
		}

		/// <summary/>
		[PInvokeData("ifdef.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NET_IF_ALIAS
		{
			/// <summary/>
			public ushort ifAliasLength;
			/// <summary/>
			public ushort ifAliasOffset;
		}

		/// <summary/>
		[PInvokeData("ifdef.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NET_IF_RCV_ADDRESS
		{
			/// <summary/>
			public NET_IF_RCV_ADDRESS_TYPE ifRcvAddressType;
			/// <summary/>
			public ushort ifRcvAddressLength;
			/// <summary/>
			public ushort ifRcvAddressOffset;
		}

		/// <summary>
		/// A <c>NET_LUID</c> union can be accessed as a 64-bit value that identifies an NDIS network interface or as a structure that
		/// contains the associated interface index and type.
		/// </summary>
		/// <returns></returns>
		// union NET_LUID { ULONG64 Value; struct { ULONG64 Reserved :24; ULONG64 NetLuidIndex :24; ULONG64 IfType :16; } Info;}; https://msdn.microsoft.com/en-us/library/windows/hardware/ff568747(v=vs.85).aspx
		[PInvokeData("Ifdef.h", MSDNShortId = "ff568747")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NET_LUID
		{
			/// <summary>The complete NET_LUID 64 bit value that includes an index and interface type.</summary>
			public ulong Value;

			/// <summary>Initializes a new instance of the <see cref="NET_LUID"/> struct.</summary>
			/// <param name="index">
			/// A 24-bit index that NDIS allocates when an interface provider calls the NdisIfAllocateNetLuidIndex function. This index is
			/// used to distinguish between multiple interfaces that have the same interface type. Therefore, this value is unique within the
			/// local computer.
			/// </param>
			/// <param name="type">
			/// A 16-bit value that specifies an Internet Assigned Numbers Authority (IANA) interface type. For example,
			/// IF_TYPE_ETHERNET_CSMACD (6) is the value for IfType that is assigned to any Ethernet-like interface. For a list of interface
			/// types, see NDIS Interface Types.
			/// </param>
			public NET_LUID(uint index, IFTYPE type) => Value = (index << 24) | ((ulong)type << 48);

			/// <summary>
			/// A 24-bit index that NDIS allocates when an interface provider calls the NdisIfAllocateNetLuidIndex function. This index is
			/// used to distinguish between multiple interfaces that have the same interface type. Therefore, this value is unique within the
			/// local computer.
			/// </summary>
			public uint NetLuidIndex
			{
				get => (uint)((Value & 0x0000FFFFFF000000) >> 24);
				set => Value = (value << 24) | Value;
			}

			/// <summary>
			/// A 16-bit value that specifies an Internet Assigned Numbers Authority (IANA) interface type. For example,
			/// IF_TYPE_ETHERNET_CSMACD (6) is the value for IfType that is assigned to any Ethernet-like interface. For a list of interface
			/// types, see NDIS Interface Types.
			/// </summary>
			public IFTYPE IfType
			{
				get => (IFTYPE)((Value & 0xFFFF000000000000) >> 48);
				set => Value = ((ulong)value << 48) | Value;
			}

			/// <inheritdoc/>
			public override string ToString() => $"{NetLuidIndex}:{IfType}";
		}

		/// <summary/>
		[PInvokeData("Ifdef.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NET_PHYSICAL_LOCATION
		{
			/// <summary/>
			public uint BusNumber;
			/// <summary/>
			public uint SlotNumber;
			/// <summary/>
			public uint FunctionNumber;
		}
	}
}