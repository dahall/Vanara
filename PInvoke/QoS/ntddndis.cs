namespace Vanara.PInvoke;

/// <summary>Items from Qwave.dll.</summary>
public static partial class Qwave
{
	/// <summary>Specifies the protocol type that sends this object identifier.</summary>
	[PInvokeData("ntddndis.h")]
	public enum NDIS_PROTOCOL_ID : ushort
	{
		/// <summary>Default protocol</summary>
		NDIS_PROTOCOL_ID_DEFAULT = 0x00,

		/// <summary>TCP/IP protocol</summary>
		NDIS_PROTOCOL_ID_TCP_IP = 0x02,

		/// <summary>TCP/IP v6 protocol</summary>
		NDIS_PROTOCOL_ID_IP6 = 0x03,

		/// <summary>Netware IPX protocol</summary>
		NDIS_PROTOCOL_ID_IPX = 0x06,

		/// <summary>NetBIOS protocol</summary>
		NDIS_PROTOCOL_ID_NBF = 0x07,
	}

	/// <summary>
	/// <para>
	/// The <c>NETWORK_ADDRESS</c> structure describes the network-layer addresses that help define NETWORK_ADDRESS_LIST. The
	/// <c>AddressCount</c> member of <c>NETWORK_ADDRESS_LIST</c> contains an array of network-layer addresses, all of which are of type <c>NETWORK_ADDRESS</c>.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// A bound instance is the binding between the calling transport and a driver set up by a call to NdisOpenAdapter. Miniport and other
	/// layered drivers use compatible <c>NETWORK_ADDRESS_LIST</c> and <c>NETWORK_ADDRESS</c> structures to set the list of network-layer
	/// addresses on a bound interface.
	/// </para>
	/// <para>
	/// A protocol can set <c>AddressCount</c> to a nonzero value. This notifies a miniport driver or other layered driver to change the list
	/// of network-layer addresses on a bound interface. In this case, the <c>AddressType</c> member in <c>NETWORK_ADDRESS_LIST</c> is not
	/// valid and the <c>AddressType</c> members in <c>NETWORK_ADDRESS</c> structures are valid.
	/// </para>
	/// <para>
	/// If a protocol sets <c>AddressCount</c> to zero, the <c>AddressType</c> member in <c>NETWORK_ADDRESS_LIST</c> is valid and the
	/// <c>AddressType</c> members in <c>NETWORK_ADDRESS</c> structures are not valid.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/embedded/ms905285(v=msdn.10)
	[PInvokeData("ntddndis.h")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<NETWORK_ADDRESS>), nameof(AddressLength))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct NETWORK_ADDRESS
	{
		/// <summary>The address length</summary>
		public ushort AddressLength;

		/// <summary>The address type</summary>
		public ushort AddressType;

		/// <summary>The address</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] Address;
	}

	/// <summary>
	/// <para>
	/// Miniport and other layered drivers use compatible <c>NETWORK_ADDRESS_LIST</c> and NETWORK_ADDRESS structures to set the list of
	/// network-layer addresses on a bound interface.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// A bound instance is the binding between the calling transport and a driver set up by a call to NdisOpenAdapter. Miniport and other
	/// layered drivers use compatible <c>NETWORK_ADDRESS_LIST</c> and <c>NETWORK_ADDRESS</c> structures to set the list of network-layer
	/// addresses on a bound interface.
	/// </para>
	/// <para>
	/// A protocol can set <c>AddressCount</c> to a nonzero value. This notifies a miniport driver or other layered driver to change the list
	/// of network-layer addresses on a bound interface. In this case, the <c>AddressType</c> member in <c>NETWORK_ADDRESS_LIST</c> is not
	/// valid and the <c>AddressType</c> members in <c>NETWORK_ADDRESS</c> structures are valid.
	/// </para>
	/// <para>
	/// If a protocol sets <c>AddressCount</c> to zero, the <c>AddressType</c> member in <c>NETWORK_ADDRESS_LIST</c> is valid and the
	/// <c>AddressType</c> members in <c>NETWORK_ADDRESS</c> structures are not valid.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/embedded/ms905288(v=msdn.10)
	[PInvokeData("ntddndis.h")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<NETWORK_ADDRESS_LIST>), nameof(AddressCount))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct NETWORK_ADDRESS_LIST
	{
		/// <summary>Specifies the number of network-layer addresses listed in the array in the Address member.</summary>
		public int AddressCount;

		/// <summary>
		/// Specifies the protocol type that sends this object identifier. This member is only valid if the AddressCount member is set to
		/// zero. The AddressCount member is set to zero to notify a miniport or other layered driver to clear the list of network-layer
		/// addresses on a bound interface.
		/// </summary>
		public NDIS_PROTOCOL_ID AddressType;

		/// <summary>Array of network-layer addresses of type NETWORK_ADDRESS.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public NETWORK_ADDRESS[] Address;     // actually AddressCount elements long
	}
}