using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>
		/// <para>
		/// The <c>IP_ADAPTER_INDEX_MAP</c> structure stores the interface index associated with a network adapter with IPv4 enabled together
		/// with the name of the network adapter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>IP_ADAPTER_INDEX_MAP</c> structure is specific to network adapters with IPv4 enabled.</para>
		/// <para>
		/// An adapter index may change when the adapter is disabled and then enabled, or under other circumstances, and should not be
		/// considered persistent.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the <c>Name</c> member of the <c>IP_ADAPTER_INDEX_MAP</c> structure may be a Unicode string of the
		/// GUID for the network interface (the string begins with the '{' character).
		/// </para>
		/// <para>
		/// This structure is defined in the Ipexport.h header file which is automatically included in the Iphlpapi.h header file. The
		/// Ipexport.h header file should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ipexport/ns-ipexport-_ip_adapter_index_map typedef struct
		// _IP_ADAPTER_INDEX_MAP { ULONG Index; WCHAR Name[MAX_ADAPTER_NAME]; } IP_ADAPTER_INDEX_MAP, *PIP_ADAPTER_INDEX_MAP;
		[PInvokeData("ipexport.h", MSDNShortId = "83d95ef3-13a4-4124-84cd-3016e9fb4446")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IP_ADAPTER_INDEX_MAP
		{
			/// <summary>
			/// <para>The interface index associated with the network adapter.</para>
			/// </summary>
			public uint Index;

			/// <summary>
			/// <para>A pointer to a Unicode string that contains the name of the adapter.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ADAPTER_NAME)]
			public string Name;

			/// <inheritdoc/>
			public override string ToString() => Name;
		}

		/// <summary>The <c>IP_OPTION_INFORMATION</c> structure describes the options to be included in the header of an IP packet.</summary>
		/// <remarks>
		/// <para>
		/// The <c>IP_OPTION_INFORMATION</c> structure is used to describe the options to be included in the header of an IP packet. On a
		/// 64-bit platform, the IP_OPTION_INFORMATION32 structure should be used.
		/// </para>
		/// <para>The values in the <c>TTL</c>, <c>TOS</c> and <c>Flags</c> members are carried in specific fields in the IP header.</para>
		/// <para>The bytes in the <c>OptionsData</c> member are carried in the options area that follows the standard IP header.</para>
		/// <para>
		/// With the exception of source route options for IPv4, the options data must be in the format to be transmitted on the wire as
		/// specified in RFC 791. An IPv4 source route option should contain the full route, first hop through final destination, in the
		/// route data. The first hop is pulled out of the data and the option is reformatted accordingly. Otherwise, the route option should
		/// be formatted as specified in RFC 791.
		/// </para>
		/// <para>For use with IPv6, the options data must be in the format to be transmitted on the wire as specified in RFC 2460.</para>
		/// <para>
		/// The <c>IP_OPTION_INFORMATION</c> structure is a member of the ICMP_ECHO_REPLY structure used by the IcmpSendEcho, IcmpSendEcho2,
		/// and Icmp6SendEcho2 functions.
		/// </para>
		/// <para>
		/// This structure is defined in the Ipexport.h header file which is automatically included in the Iphlpapi.h header file. The
		/// Ipexport.h header file should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ipexport/ns-ipexport-ip_option_information typedef struct
		// ip_option_information { UCHAR Ttl; UCHAR Tos; UCHAR Flags; UCHAR OptionsSize; PUCHAR OptionsData; } IP_OPTION_INFORMATION, *PIP_OPTION_INFORMATION;
		[PInvokeData("ipexport.h", MSDNShortId = "4341d0a4-65d8-4677-b208-2cde5ff36f14")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_OPTION_INFORMATION
		{
			/// <summary>
			/// <para>Type: <c>UCHAR</c></para>
			/// <para>The Time to Live field in an IPv4 packet header. This is the Hop Limit field in an IPv6 header.</para>
			/// </summary>
			public byte Ttl;

			/// <summary>
			/// <para>Type: <c>UCHAR</c></para>
			/// <para>The type of service field in an IPv4 header. This member is currently silently ignored.</para>
			/// </summary>
			public byte Tos;

			/// <summary>
			/// <para>Type: <c>UCHAR</c></para>
			/// <para>
			/// The Flags field. In IPv4, this is the Flags field in the IPv4 header. In IPv6, this field is represented by options headers.
			/// </para>
			/// <para>
			/// For IPv4, the possible values for the <c>Flags</c> member are a combination of the following values defined in the Ipexport.h
			/// header file:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IP_FLAG_REVERSE 0x01</term>
			/// <term>
			/// This value causes the IP packet to add in an IP routing header with the source. This value is only applicable on Windows
			/// Vistaand later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IP_FLAG_DF 0x02</term>
			/// <term>This value indicates that the packet should not be fragmented.</term>
			/// </item>
			/// </list>
			/// </summary>
			public byte Flags;

			/// <summary>
			/// <para>Type: <c>UCHAR</c></para>
			/// <para>The size, in bytes, of IP options data.</para>
			/// </summary>
			public byte OptionsSize;

			/// <summary>
			/// <para>Type: <c>PUCHAR</c></para>
			/// <para>A pointer to options data.</para>
			/// </summary>
			public IntPtr OptionsData;
		}

		/// <summary>
		/// The <c>IP_ADAPTER_ORDER_MAP</c> structure stores an array of information about adapters and their relative priority on the local computer.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This structure is returned by the GetAdapterOrderMap function, and is used as a tie breaker for otherwise equal interfaces during
		/// network operations. The GetAdapterOrderMap function should not be called directly; use the GetAdaptersInfo function instead.
		/// </para>
		/// <para>
		/// The <c>IP_ADAPTER_ORDER_MAP</c> structure contains at least one <c>AdapterOrder</c> member even if the <c>NumAdapters</c> member
		/// of the <c>IP_ADAPTER_ORDER_MAP</c> structure indicates no network adapters. When the <c>NumAdapters</c> member of the
		/// <c>IP_ADAPTER_ORDER_MAP</c> structure is zero, the value of the single <c>AdapterOrder</c> member is undefined.
		/// </para>
		/// <para>
		/// This structure is defined in the Ipexport.h header file which is automatically included in the Iphlpapi.h header file. The
		/// Ipexport.h header file should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ipexport/ns-ipexport-_ip_adapter_order_map typedef struct
		// _IP_ADAPTER_ORDER_MAP { ULONG NumAdapters; ULONG AdapterOrder[1]; } IP_ADAPTER_ORDER_MAP, *PIP_ADAPTER_ORDER_MAP;
		[PInvokeData("ipexport.h", MSDNShortId = "0bbd008e-67d4-4557-bff7-f0404a8878ff")]
		[CorrespondingType(typeof(uint))]
		[DefaultProperty(nameof(AdapterOrder))]
		public class IP_ADAPTER_ORDER_MAP : SafeElementArray<uint, uint, LocalMemoryMethods>
		{
			private IP_ADAPTER_ORDER_MAP() : base() { }

			/// <summary>Initializes a new instance of the <see cref="IP_ADAPTER_ORDER_MAP"/> class.</summary>
			/// <param name="byteSize">Size of the byte.</param>
			public IP_ADAPTER_ORDER_MAP(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// An array of adapter indexes on the local computer, provided in the order specified in the <c>Adapters and Bindings</c> dialog
			/// box for <c>Network Connections</c>.
			/// </summary>
			/// <value>The <see cref="System.UInt32"/>.</value>
			/// <returns></returns>
			public uint[] AdapterOrder { get => Elements; set => Elements = value; }

			/// <summary>The number of network adapters in the <c>AdapterOrder</c> member.</summary>
			public uint NumAdapters => Count;
		}

		/// <summary>
		/// <para>
		/// The <c>IP_INTERFACE_INFO</c> structure contains a list of the network interface adapters with IPv4 enabled on the local system.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IP_INTERFACE_INFO</c> structure is specific to network adapters with IPv4 enabled. The <c>IP_INTERFACE_INFO</c> structure
		/// contains the number of network adapters with IPv4 enabled on the local system and an array of IP_ADAPTER_INDEX_MAP structures
		/// with information on each network adapter with IPv4 enabled. The <c>IP_INTERFACE_INFO</c> structure contains at least one
		/// <c>IP_ADAPTER_INDEX_MAP</c> structure even if the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure indicates
		/// that no network adapters with IPv4 are enabled. When the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure is
		/// zero, the value of the members of the single <c>IP_ADAPTER_INDEX_MAP</c> structure returned in the <c>IP_INTERFACE_INFO</c>
		/// structure is undefined.
		/// </para>
		/// <para>The <c>IP_INTERFACE_INFO</c> structure can't be used to return information about the loopback interface.</para>
		/// <para>
		/// On Windows Vista and later, the <c>Name</c> member of the IP_ADAPTER_INDEX_MAP structure in the <c>IP_INTERFACE_INFO</c>
		/// structure may be a Unicode string of the GUID for the network interface (the string begins with the '{' character).
		/// </para>
		/// <para>
		/// This structure is defined in the Ipexport.h header file which is automatically included in the Iphlpapi.h header file. The
		/// Ipexport.h header file should never be used directly.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the list of network adapters with IPv4 enabled on the local system and prints various properties
		/// of the first adapter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ipexport/ns-ipexport-_ip_interface_info typedef struct _IP_INTERFACE_INFO {
		// LONG NumAdapters; IP_ADAPTER_INDEX_MAP Adapter[1]; } IP_INTERFACE_INFO, *PIP_INTERFACE_INFO;
		[PInvokeData("ipexport.h", MSDNShortId = "287a4574-0a0f-4f20-932b-22bb6f40401d")]
		[CorrespondingType(typeof(IP_ADAPTER_INDEX_MAP))]
		[DefaultProperty(nameof(Adapter))]
		public class IP_INTERFACE_INFO : SafeElementArray<IP_ADAPTER_INDEX_MAP, int, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="IP_INTERFACE_INFO"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public IP_INTERFACE_INFO(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>
			/// An array of IP_ADAPTER_INDEX_MAP structures. Each structure maps an adapter index to that adapter's name. The adapter index
			/// may change when an adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </para>
			/// </summary>
			public IP_ADAPTER_INDEX_MAP[] Adapter { get => Elements; set => Elements = value; }

			/// <summary>
			/// <para>The number of adapters listed in the array pointed to by the <c>Adapter</c> member.</para>
			/// </summary>
			public int NumAdapters => Count;

			/// <summary>Performs an implicit conversion from <see cref="IP_INTERFACE_INFO"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="iii">The IP_INTERFACE_INFO instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(IP_INTERFACE_INFO iii) => iii.DangerousGetHandle();
		}

		/// <summary>
		/// <para>The <c>IP_UNIDIRECTIONAL_ADAPTER_ADDRESS</c> structure stores the IPv4 addresses associated with a unidirectional adapter.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IP_UNIDIRECTIONAL_ADAPTER_ADDRESS</c> structure is retrieved by the GetUnidirectionalAdapterInfofunction. A unidirectional
		/// adapter is an adapter that can receive IPv4 datagrams, but can't transmit them.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ipexport/ns-ipexport-_ip_unidirectional_adapter_address typedef struct
		// _IP_UNIDIRECTIONAL_ADAPTER_ADDRESS { ULONG NumAdapters; IPAddr Address[1]; } IP_UNIDIRECTIONAL_ADAPTER_ADDRESS, *PIP_UNIDIRECTIONAL_ADAPTER_ADDRESS;
		[PInvokeData("ipexport.h", MSDNShortId = "225b93ae-e34f-4e5b-a699-1fdd342265c6")]
		[CorrespondingType(typeof(IN_ADDR))]
		[DefaultProperty(nameof(Address))]
		public class IP_UNIDIRECTIONAL_ADAPTER_ADDRESS : SafeElementArray<IN_ADDR, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="IP_UNIDIRECTIONAL_ADAPTER_ADDRESS"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public IP_UNIDIRECTIONAL_ADAPTER_ADDRESS(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>
			/// An array of variables of type IPAddr. Each element of the array specifies an IPv4 address associated with this unidirectional adapter.
			/// </para>
			/// </summary>
			public IN_ADDR[] Address { get => Elements; set => Elements = value; }

			/// <summary>
			/// <para>The number of IPv4 addresses pointed to by the <c>Address</c> member.</para>
			/// </summary>
			public uint NumAdapters => Count;

			/// <summary>Performs an implicit conversion from <see cref="IP_UNIDIRECTIONAL_ADAPTER_ADDRESS"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The IP_UNIDIRECTIONAL_ADAPTER_ADDRESS instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(IP_UNIDIRECTIONAL_ADAPTER_ADDRESS table) => table.DangerousGetHandle();
		}
	}
}