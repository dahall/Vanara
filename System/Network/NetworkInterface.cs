using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using static Vanara.PInvoke.IpHlpApi;

namespace Vanara.Extensions
{
	/// <summary>The interface access type.</summary>
	public enum NetworkInterfaceAccessType
	{
		/// <summary>
		/// Specifies the loopback access type. This access type indicates that the interface loops back transmit data as receive data.
		/// </summary>
		Loopback = 1,

		/// <summary>
		/// Specifies the LAN access type, which includes Ethernet. This access type indicates that the interface provides native support for
		/// multicast or broadcast services.
		/// </summary>
		Broadcast,

		/// <summary>Specifies point-to-point access that supports CoNDIS and WAN, except for non-broadcast multi-access (NBMA) interfaces.</summary>
		PointToPoint,

		/// <summary>
		/// Specifies point-to-multipoint access that supports non-broadcast multi-access (NBMA) media, including the "RAS Internal"
		/// interface, and native (non-LANE) ATM.
		/// </summary>
		PointToMultiPoint,
	}

	/// <summary>Specifies the NDIS network interface administrative status, as described in RFC 2863.</summary>
	/// <remarks>For more information on RFC 2863, see "The Interfaces Group MIB".</remarks>
	public enum NetworkInterfaceAdministrativeStatus
	{
		/// <summary>
		/// Specifies that the interface is initialized and enabled, but the interface is not necessarily ready to transmit and receive
		/// network data because that depends on the operational status of the interface. For more information about the operational status
		/// of an interface, see OID_GEN_OPERATIONAL_STATUS.
		/// </summary>
		Up = 1,

		/// <summary>Specifies that the interface is down, and this interface cannot be used to transmit or receive network data.</summary>
		Down,

		/// <summary>Specifies that the interface is in a test mode, and no network data can be transmitted or received.</summary>
		Testing,
	}

	/// <summary>Specifies the NDIS network interface connection type.</summary>
	public enum NetworkInterfaceConnectionType : uint
	{
		/// <summary>
		/// Specifies the dedicated connection type. The connection comes up automatically when media sense is TRUE. For example, an Ethernet
		/// connection is dedicated.
		/// </summary>
		Dedicated = 1,

		/// <summary>
		/// Specifies the passive connection type. The other end must bring up the connection to the local station. For example, the RAS
		/// interface is passive.
		/// </summary>
		Passive,

		/// <summary>
		/// Specifies the demand-dial connection type. A demand-dial connection comes up in response to a local action--for example, sending
		/// a packet.
		/// </summary>
		Demand,
	}

	/// <summary>Specifies the NDIS network interface direction type.</summary>
	public enum NetworkInterfaceDirectionType
	{
		/// <summary>
		/// Indicates the send and receive direction type. This direction type indicates that the NDIS network interface can send and receive data.
		/// </summary>
		SendReceive,

		/// <summary>
		/// Indicates the send only direction type. This direction type indicates that the NDIS network interface can only send data.
		/// </summary>
		SendOnly,

		/// <summary>
		/// Indicates the receive only direction type. This direction type indicates that the NDIS network interface can only receive data.
		/// </summary>
		ReceiveOnly,
	}

	/// <summary>The NDIS media type of a network interface.</summary>
	public enum NetworkInterfaceMediaType
	{
		/// <summary>Specifies an Ethernet (802.3) network.</summary>
		Ethernet802_3,

		/// <summary>Specifies a Token Ring (802.5) network. <note type="note">Not supported in Windows 8 or later.</note></summary>
		TokenRing,

		/// <summary>
		/// Specifies a Fiber Distributed Data Interface (FDDI) network. <note type="note">Not supported in Windows Vista/Windows Server 2008
		/// or later.</note>
		/// </summary>
		Fddi,

		/// <summary>
		/// Specifies a wide area network. This type covers various forms of point-to-point and WAN NICs, as well as variant address/header
		/// formats that must be negotiated between the protocol driver and the underlying driver after the binding is established.
		/// </summary>
		Wan,

		/// <summary>Specifies a LocalTalk network.</summary>
		LocalTalk,

		/// <summary>Specifies an Ethernet network for which the drivers use the DIX Ethernet header format.</summary>
		Dix,

		/// <summary>Specifies an ARCNET network. <note type="note">Not supported in Windows Vista/Windows Server 2008 or later.</note></summary>
		ArcnetRaw,

		/// <summary>Specifies an ARCNET (878.2) network. <note type="note">Not supported in Windows Vista/Windows Server 2008 or later.</note></summary>
		Arcnet878_2,

		/// <summary>
		/// Specifies an ATM network. Connection-oriented client protocol drivers can bind themselves to an underlying miniport driver that
		/// returns this value. Otherwise, legacy protocol drivers bind themselves to the system-supplied LanE intermediate driver, which
		/// reports its medium type as either of 802_3 or 802_5, depending on how the LanE driver is configured by the network administrator.
		/// </summary>
		Atm,

		/// <summary>
		/// Specifies a wireless network. NDIS 5.X miniport drivers that support wireless LAN (WLAN) or wireless WAN (WWAN) packets declare
		/// their medium as 802_3 and emulate Ethernet to higher-level NDIS drivers. <note type="note">Starting with Windows 7, this media
		/// type is supported and can be used for Mobile Broadband.</note>
		/// </summary>
		Wireless,

		/// <summary>Specifies an infrared (IrDA) network.</summary>
		IrDA,

		/// <summary>Specifies a broadcast PC network.</summary>
		Broadcast,

		/// <summary>Specifies a wide area network in a connection-oriented environment.</summary>
		CoWAN,

		/// <summary>
		/// Specifies an IEEE 1394 (fire wire) network. <note type="note">Not supported in Windows Vista/Windows Server 2008 or later.</note>
		/// </summary>
		Ieee1394,

		/// <summary>Specifies an InfiniBand network.</summary>
		InfiniBand,

		/// <summary>Specifies a tunnel network.</summary>
		Tunnel,

		/// <summary>Specifies a native IEEE 802.11 network.</summary>
		Native802_11,

		/// <summary>Specifies an NDIS loopback network.</summary>
		Loopback,

		/// <summary>Specifies a WiMAX network.</summary>
		WiMAX,

		/// <summary>Specifies a generic medium that is capable of sending and receiving raw IP packets.</summary>
		IP,
	}

	/// <summary>The NDIS physical medium type.</summary>
	public enum NetworkInterfacePhysicalMedium
	{
		/// <summary>
		/// The physical medium is none of the below values. For example, a one-way satellite feed is an unspecified physical medium.
		/// </summary>
		Unspecified = 0,

		/// <summary>Packets are transferred over a wireless LAN network through a miniport driver that conforms to the 802.11 interface.</summary>
		WirelessLan = 1,

		/// <summary>Packets are transferred over a DOCSIS-based cable network.</summary>
		CableModem = 2,

		/// <summary>Packets are transferred over standard phone lines. This includes HomePNA media, for example.</summary>
		PhoneLine = 3,

		/// <summary>Packets are transferred over wiring that is connected to a power distribution system.</summary>
		PowerLine = 4,

		/// <summary>
		/// Packets are transferred over a Digital Subscriber Line (DSL) network. This includes ADSL, UADSL (G.Lite), and SDSL, for example.
		/// </summary>
		DSL = 5,

		/// <summary>Packets are transferred over a Fibre Channel interconnect.</summary>
		FibreChannel = 6,

		/// <summary>Packets are transferred over an IEEE 1394 bus.</summary>
		Ieee1394 = 7,

		/// <summary>
		/// Packets are transferred over a Wireless WAN link. This includes mobile broadband devices that support CDPD, CDMA, GSM, and GPRS,
		/// for example.
		/// </summary>
		WirelessWan = 8,

		/// <summary>
		/// Packets are transferred over a wireless LAN network through a miniport driver that conforms to the Native 802.11 interface. <note
		/// type="note">The Native 802.11 interface is supported in NDIS 6.0 and later versions.</note>
		/// </summary>
		Native802_11 = 9,

		/// <summary>
		/// Packets are transferred over a Bluetooth network. Bluetooth is a short-range wireless technology that uses the 2.4 GHz spectrum.
		/// </summary>
		Bluetooth = 10,

		/// <summary>Packets are transferred over an Infiniband interconnect.</summary>
		InfiniBand = 11,

		/// <summary>Packets are transferred over a WiMax network.</summary>
		WiMAX = 12,

		/// <summary>Packets are transferred over an ultra wide band network.</summary>
		UWB = 13,

		/// <summary>Packets are transferred over an Ethernet (802.3) network.</summary>
		Ethernet802_3 = 14,

		/// <summary>Packets are transferred over a Token Ring (802.5) network.</summary>
		TokenRing = 15,

		/// <summary>Packets are transferred over an infrared (IrDA) network.</summary>
		IrDA = 16,

		/// <summary>Packets are transferred over a wired WAN network.</summary>
		WiredWAN = 17,

		/// <summary>Packets are transferred over a wide area network in a connection-oriented environment.</summary>
		WiredCoWAN = 18,

		/// <summary>Packets are transferred over a network that is not described by other possible values.</summary>
		Other = 19,
	}

	public static class NetworkInterfaceExt
	{
		private static Dictionary<int, MIB_IF_ROW2> adapters = new Dictionary<int, MIB_IF_ROW2>();

		/// <summary>Gets the interface access type.</summary>
		public static NetworkInterfaceAccessType GetAccessType(this IPInterfaceProperties ifprop) => (NetworkInterfaceAccessType)GetIfEntry(ifprop.GetIPv4Properties().Index).AccessType;

		/// <summary>Gets the administrative status for the interface as defined in RFC 2863. For more information, see http://www.ietf.org/rfc/rfc2863.txt.</summary>
		public static NetworkInterfaceAdministrativeStatus GetAdminStatus(this IPInterfaceProperties ifprop) => (NetworkInterfaceAdministrativeStatus)GetIfEntry(ifprop.GetIPv4Properties().Index).AdminStatus;

		/// <summary>Gets the NDIS network interface connection type.</summary>
		public static NetworkInterfaceConnectionType GetConnectionType(this IPInterfaceProperties ifprop) => (NetworkInterfaceConnectionType)GetIfEntry(ifprop.GetIPv4Properties().Index).ConnectionType;

		/// <summary>Gets the interface direction type.</summary>
		public static NetworkInterfaceDirectionType GetDirectionType(this IPInterfaceProperties ifprop) => (NetworkInterfaceDirectionType)GetIfEntry(ifprop.GetIPv4Properties().Index).DirectionType;

		/// <summary>Gets the GUID for the network interface.</summary>
		public static Guid GetGuid(this IPInterfaceProperties ifprop) => GetIfEntry(ifprop.GetIPv4Properties().Index).InterfaceGuid;

		/// <summary>Gets the speed in bits per second of the transmit link and receive link.</summary>
		public static void GetLinkSpeeds(this NetworkInterface intf, out ulong transmitSpeed, out ulong receiveSpeed)
		{
			var e = GetIfEntry(intf.GetIPProperties().GetIPv4Properties().Index);
			transmitSpeed = e.TransmitLinkSpeed;
			receiveSpeed = e.ReceiveLinkSpeed;
		}

		/// <summary>Gets the NDIS media type for the interface.</summary>
		public static NetworkInterfaceMediaType GetMediaType(this IPInterfaceProperties ifprop) => (NetworkInterfaceMediaType)GetIfEntry(ifprop.GetIPv4Properties().Index).MediaType;

		/// <summary>Gets the permanent physical hardware address of the adapter for this network interface.</summary>
		public static PhysicalAddress GetPermanentPhysicalAddress(this NetworkInterface intf)
		{
			var e = GetIfEntry(intf.GetIPProperties().GetIPv4Properties().Index);
			var newAddr = new byte[e.physicalAddressLength];
			Array.Copy(e.PermanentPhysicalAddress, newAddr, e.physicalAddressLength);
			return new PhysicalAddress(newAddr);
		}

		/// <summary>Gets the NDIS physical medium type.</summary>
		public static NetworkInterfacePhysicalMedium GetPhysicalMediumType(this IPInterfaceProperties ifprop) => (NetworkInterfacePhysicalMedium)GetIfEntry(ifprop.GetIPv4Properties().Index).PhysicalMediumType;

		private static MIB_IF_ROW2 GetIfEntry(int index)
		{
			if (adapters.TryGetValue(index, out var row)) return row;
			row = new MIB_IF_ROW2((uint)index);
			GetIfEntry2(ref row).ThrowIfFailed();
			adapters.Add(index, row);
			return row;
		}
	}
}