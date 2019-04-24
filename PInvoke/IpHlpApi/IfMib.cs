using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>
		/// <para>The <c>MIB_IFROW</c> structure stores information about a particular interface.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>dwSpeed</c> member of the <c>MIB_IFROW</c> structure will be incorrect for very high-speed network interfaces (10 Gbit/s
		/// network adapter, for example) since the maximum value that can be store in a DWORD is 4,294,967,295. Applications should use the
		/// MIB_IF_ROW2 structure returned by the GetIfEntry2 and GetIfTable2functions or the IP_ADAPTER_ADDRESSES structure returned by the
		/// GetAdaptersAddressesfunction for determining the speed for very high-speed network interfaces.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>MIB_IFROW</c> structure is defined in the Ifmib.h header file not in the Iprtrmib.h header file. Note that
		/// the Ifmib.h header file is automatically included in Iprtrmib.h which is automatically included in the Iphlpapi.h header file.
		/// The Ifmib.h and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifmib/ns-ifmib-_mib_ifrow typedef struct _MIB_IFROW { WCHAR
		// wszName[MAX_INTERFACE_NAME_LEN]; IF_INDEX dwIndex; IFTYPE dwType; DWORD dwMtu; DWORD dwSpeed; DWORD dwPhysAddrLen; UCHAR
		// bPhysAddr[MAXLEN_PHYSADDR]; DWORD dwAdminStatus; INTERNAL_IF_OPER_STATUS dwOperStatus; DWORD dwLastChange; DWORD dwInOctets; DWORD
		// dwInUcastPkts; DWORD dwInNUcastPkts; DWORD dwInDiscards; DWORD dwInErrors; DWORD dwInUnknownProtos; DWORD dwOutOctets; DWORD
		// dwOutUcastPkts; DWORD dwOutNUcastPkts; DWORD dwOutDiscards; DWORD dwOutErrors; DWORD dwOutQLen; DWORD dwDescrLen; UCHAR
		// bDescr[MAXLEN_IFDESCR]; } MIB_IFROW, *PMIB_IFROW;
		[PInvokeData("ifmib.h", MSDNShortId = "b08631e9-6036-4377-b2f2-4ea899acb787")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct MIB_IFROW
		{
			/// <summary>
			/// <para>Type: <c>WCHAR[MAX_INTERFACE_NAME_LEN]</c></para>
			/// <para>A pointer to a Unicode string that contains the name of the interface.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_INTERFACE_NAME_LEN)]
			public string wszName;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The index that identifies the interface. This index value may change when a network adapter is disabled and then enabled, and
			/// should not be considered persistent.
			/// </para>
			/// </summary>
			public uint dwIndex;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The interface type as defined by the Internet Assigned Names Authority (IANA). For more information, see
			/// http://www.iana.org/assignments/ianaiftype-mib. Possible values for the interface type are listed in the Ipifcons.h header file.
			/// </para>
			/// <para>The table below lists common values for the interface type although many other values are possible.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IF_TYPE_OTHER 1</term>
			/// <term>Some other type of network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_ETHERNET_CSMACD 6</term>
			/// <term>An Ethernet network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_ISO88025_TOKENRING 9</term>
			/// <term>A token ring network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_FDDI 15</term>
			/// <term>A Fiber Distributed Data Interface (FDDI) network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_PPP 23</term>
			/// <term>A PPP network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_SOFTWARE_LOOPBACK 24</term>
			/// <term>A software loopback network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_ATM 37</term>
			/// <term>An ATM network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_IEEE80211 71</term>
			/// <term>An IEEE 802.11 wireless network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_TUNNEL 131</term>
			/// <term>A tunnel type encapsulation network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_IEEE1394 144</term>
			/// <term>An IEEE 1394 (Firewire) high performance serial bus network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_IEEE80216_WMAN 237</term>
			/// <term>A mobile broadband interface for WiMax devices.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_WWANPP 243</term>
			/// <term>A mobile broadband interface for GSM-based devices.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_WWANPP2 244</term>
			/// <term>An mobile broadband interface for CDMA-based devices.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwType;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The Maximum Transmission Unit (MTU) size in bytes.</para>
			/// </summary>
			public uint dwMtu;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The speed of the interface in bits per second.</para>
			/// </summary>
			public uint dwSpeed;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The length, in bytes, of the physical address specified by the <c>bPhysAddr</c> member.</para>
			/// </summary>
			public uint dwPhysAddrLen;

			/// <summary>
			/// <para>Type: <c>BYTE[MAXLEN_PHYSADDR]</c></para>
			/// <para>The physical address of the adapter for this interface.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXLEN_PHYSADDR)]
			public byte[] bPhysAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The interface is administratively enabled or disabled.</para>
			/// </summary>
			public uint dwAdminStatus;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The operational status of the interface. This member can be one of the following values defined in the
			/// INTERNAL_IF_OPER_STATUS enumeration defined in the Ipifcons.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IF_OPER_STATUS_NON_OPERATIONAL</term>
			/// <term>LAN adapter has been disabled, for example because of an address conflict.</term>
			/// </item>
			/// <item>
			/// <term>IF_OPER_STATUS_UNREACHABLE</term>
			/// <term>WAN adapter that is not connected.</term>
			/// </item>
			/// <item>
			/// <term>IF_OPER_STATUS_DISCONNECTED</term>
			/// <term>For LAN adapters: network cable disconnected. For WAN adapters: no carrier.</term>
			/// </item>
			/// <item>
			/// <term>IF_OPER_STATUS_CONNECTING</term>
			/// <term>WAN adapter that is in the process of connecting.</term>
			/// </item>
			/// <item>
			/// <term>IF_OPER_STATUS_CONNECTED</term>
			/// <term>WAN adapter that is connected to a remote peer.</term>
			/// </item>
			/// <item>
			/// <term>IF_OPER_STATUS_OPERATIONAL</term>
			/// <term>Default status for LAN adapters</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwOperStatus;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The length of time, in hundredths of seconds (10^-2 sec), starting from the last computer restart, when the interface entered
			/// its current operational state. This value rolls over after 2^32 hundredths of a second.
			/// </para>
			/// <para>
			/// The <c>dwLastChange</c> member is not currently supported by NDIS. On Windows Vista and later, NDIS returns zero for this
			/// member. On earlier versions of Windows, an arbitrary value is returned in this member for the interfaces supported by NDIS.
			/// For interfaces supported by other interface providers, they might return an appropriate value.
			/// </para>
			/// </summary>
			public uint dwLastChange;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of octets of data received through this interface.</para>
			/// </summary>
			public uint dwInOctets;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of unicast packets received through this interface.</para>
			/// </summary>
			public uint dwInUcastPkts;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of non-unicast packets received through this interface. Broadcast and multicast packets are included.</para>
			/// </summary>
			public uint dwInNUcastPkts;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of incoming packets that were discarded even though they did not have errors.</para>
			/// </summary>
			public uint dwInDiscards;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of incoming packets that were discarded because of errors.</para>
			/// </summary>
			public uint dwInErrors;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of incoming packets that were discarded because the protocol was unknown.</para>
			/// </summary>
			public uint dwInUnknownProtos;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of octets of data sent through this interface.</para>
			/// </summary>
			public uint dwOutOctets;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of unicast packets sent through this interface.</para>
			/// </summary>
			public uint dwOutUcastPkts;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of non-unicast packets sent through this interface. Broadcast and multicast packets are included.</para>
			/// </summary>
			public uint dwOutNUcastPkts;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of outgoing packets that were discarded even though they did not have errors.</para>
			/// </summary>
			public uint dwOutDiscards;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of outgoing packets that were discarded because of errors.</para>
			/// </summary>
			public uint dwOutErrors;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The transmit queue length. This field is not currently used.</para>
			/// </summary>
			public uint dwOutQLen;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The length, in bytes, of the <c>bDescr</c> member.</para>
			/// </summary>
			public uint dwDescrLen;

			/// <summary>
			/// <para>Type: <c>BYTE[MAXLEN_IFDESCR]</c></para>
			/// <para>A description of the interface.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXLEN_IFDESCR)]
			public byte[] bDescr;

			/// <summary>Initializes a new instance of the <see cref="MIB_IFROW"/> struct.</summary>
			/// <param name="ifIndex">
			/// The index that identifies the interface. This index value may change when a network adapter is disabled and then enabled, and
			/// should not be considered persistent.
			/// </param>
			public MIB_IFROW(uint ifIndex) : this()
			{
				dwIndex = ifIndex;
			}
		}

		/// <summary>
		/// <para>The <c>MIB_IFTABLE</c> structure contains a table of interface entries.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The GetIfTable function enumerates the interface entries on a local system and returns this information in a <c>MIB_IFTABLE</c> structure.
		/// </para>
		/// <para>
		/// The <c>MIB_IFTABLE</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the first MIB_IFROW
		/// array entry in the <c>table</c> member. Padding for alignment may also be present between the <c>MIB_IFROW</c> array entries in
		/// the <c>table</c> member. Any access to a <c>MIB_IFROW</c> array entry should assume padding may exist.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>MIB_IFTABLE</c> structure is defined in the Ifmib.h header file not in the Iprtrmib.h header file. Note
		/// that the Ifmib.h header file is automatically included in Ipmib.h header file. This file is automatically included in the
		/// Iprtrmib.h header file which is automatically included in the Iphlpapi.h header file. The Ifmib.h header file should never be
		/// used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/ifmib/ns-ifmib-_mib_iftable typedef struct _MIB_IFTABLE {
		// DWORD dwNumEntries; MIB_IFROW table[ANY_SIZE]; } MIB_IFTABLE, *PMIB_IFTABLE;
		[PInvokeData("ifmib.h", MSDNShortId = "7c3ca3d0-b6fe-4e1c-858f-82ffb26622e7")]
		[CorrespondingType(typeof(MIB_IFROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_IFTABLE : SafeElementArray<MIB_IFROW, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_IFTABLE"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_IFTABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of interface entries in the array.</para>
			/// </summary>
			public uint dwNumEntries => Count;

			/// <summary>
			/// <para>An array of MIB_IFROW structures containing interface entries.</para>
			/// </summary>
			public MIB_IFROW[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_IFTABLE"/> to <see cref="System.IntPtr"/>.</summary>
			/// <param name="table">The MIB_IFTABLE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_IFTABLE table) => table.DangerousGetHandle();
		}
	}
}