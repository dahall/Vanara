using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>
		/// <para>
		/// The <c>MIB_UDP6ROW</c> structure contains an entry from the User Datagram Protocol (UDP) listener table for IPv6 on the local computer.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_UDP6ROW</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetUdp6Table function retrieves the UDP listener table for IPv6 on the local computer and returns this information in a
		/// MIB_UDP6TABLE structure.
		/// </para>
		/// <para>An array of <c>MIB_UDP6ROW</c> structures are contained in the <c>MIB_UDP6TABLE</c> structure.</para>
		/// <para>
		/// The <c>dwLocalAddr</c> member is stored in an in6_addr structure. The RtlIpv6AddressToString or RtlIpv6AddressToStringEx
		/// functions may be used to convert the IPv6 address in the <c>dwLocalAddr</c> member to a string without loading the Windows
		/// Sockets DLL.
		/// </para>
		/// <para>
		/// The <c>dwLocalScopeId</c> and <c>dwLocalPort</c> members are in network byte order. In order to use the <c>dwLocalScopeId</c> and
		/// <c>dwLocalPort</c> members, the ntohs or inet_ntoa functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The MIB_UDP6TABLE structure contains the UDP listener table for IPv6 on the local computer. The name is based on the definition
		/// of this table in RFC 2454 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc2454.txt. This table
		/// contains UDP endpoints for IPv6 that have been bound to an address. It should be noted that an application can create a UDP
		/// socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets using
		/// this socket (functioning as a listener).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udp6row typedef struct _MIB_UDP6ROW {
		// IN6_ADDR dwLocalAddr; DWORD dwLocalScopeId; DWORD dwLocalPort; } MIB_UDP6ROW, *PMIB_UDP6ROW;
		[PInvokeData("udpmib.h", MSDNShortId = "c2cc4f77-8557-4206-9e46-aadf065eb8df")]
		[StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
		public struct MIB_UDP6ROW
		{
			/// <summary>
			/// <para>
			/// The IPv6 address of the UDP endpoint on the local computer. This member is stored in a character array in network byte order.
			/// </para>
			/// <para>
			/// A value of zero indicates a UDP listener willing to accept datagrams for any IP interface associated with the local computer.
			/// </para>
			/// </summary>
			public IN6_ADDR dwLocalAddr;

			/// <summary>
			/// <para>
			/// The scope ID for the IPv6 address of the UDP endpoint on the local computer. This member is stored in network byte order.
			/// </para>
			/// </summary>
			public uint dwLocalScopeId;

			/// <summary>
			/// <para>The port number of the UDP endpoint on the local computer. This member is stored in network byte order.</para>
			/// </summary>
			public uint dwLocalPort;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_UDP6ROW_OWNER_MODULE</c> structure contains an entry from the User Datagram Protocol (UDP) listener table for IPv6 on
		/// the local computer. This entry also also includes any available ownership data and the process ID (PID) that issued the call to
		/// the bind function for the UDP endpoint.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MIB_UDP6TABLE_OWNER_MODULE structure is returned by a call to GetExtendedUdpTable with the TableClass parameter set to a
		/// <c>UDP_TABLE_OWNER_MODULE</c> from the UDP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET6</c>. The
		/// <c>MIB_UDP6TABLE_OWNER_MODULE</c> structure contains an array of <c>MIB_UDP6ROW_OWNER_MODULE</c> structures.
		/// </para>
		/// <para>
		/// The <c>ucLocalAddr</c> member is stored in a character array in network byte order. On Windows Vista and later, the
		/// RtlIpv6AddressToString or RtlIpv6AddressToStringEx functions may be used to convert the IPv6 address in the <c>ucLocalAddr</c>
		/// member to a string without loading the Windows Sockets DLL.
		/// </para>
		/// <para>
		/// The <c>dwLocalScopeId</c> member is in network byte order. In order to use the <c>dwLocalScopeId</c> member, the ntohl or
		/// inet_ntoa functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c> member are in network byte order. In order to use the <c>dwLocalPort</c> member, the ntohs or inet_ntoa
		/// functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The MIB_UDP6TABLE_OWNER_MODULE structure contains the UDP listener table for IPv6 on the local computer. The name is based on the
		/// definition of this table in RFC 2454 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc2454.txt. This
		/// table contains UDP endpoints for IPv6 that have been bound to an address. It should be noted that an application can create a UDP
		/// socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets using
		/// this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udp6row_owner_module typedef struct
		// _MIB_UDP6ROW_OWNER_MODULE { UCHAR ucLocalAddr[16]; DWORD dwLocalScopeId; DWORD dwLocalPort; DWORD dwOwningPid; LARGE_INTEGER
		// liCreateTimestamp; union { struct { int SpecificPortBind : 1; }; int dwFlags; }; ULONGLONG
		// OwningModuleInfo[TCPIP_OWNING_MODULE_SIZE]; } MIB_UDP6ROW_OWNER_MODULE, *PMIB_UDP6ROW_OWNER_MODULE;
		[PInvokeData("udpmib.h", MSDNShortId = "dcc80b3c-d4d5-44f4-9c7f-df6be2e21889")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct MIB_UDP6ROW_OWNER_MODULE
		{
			/// <summary>
			/// <para>Type: <c>UCHAR[16]</c></para>
			/// <para>
			/// The IPv6 address of the UDP endpoint on the local computer. This member is stored in a character array in network byte order.
			/// </para>
			/// <para>
			/// A value of zero indicates a UDP listener willing to accept datagrams for any IP interface associated with the local computer.
			/// </para>
			/// </summary>
			public IN6_ADDR ucLocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The scope ID for the IPv6 address of the UDP endpoint on the local computer.</para>
			/// </summary>
			public uint dwLocalScopeId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The port number for the local UDP endpoint.</para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The PID of the process that issued a context bind for this endpoint. If this value is set to 0, the information for this
			/// endpoint is unavailable.
			/// </para>
			/// </summary>
			public uint dwOwningPid;

			private uint padding;

			/// <summary>
			/// <para>Type: <c>LARGE_INTEGER</c></para>
			/// <para>A FILETIME structure that indicates when the context bind operation that created this endpoint occurred.</para>
			/// <para>NOTE: The Microsoft documentation suggests this is a SYSTEMTIME structure. This is incorrect.</para>
			/// </summary>
			public FILETIME liCreateTimestamp;

			/// <summary/>
			public int SpecificPortBind;

			/// <summary>
			/// <para>Type: <c>ULONGLONG[TCPIP_OWNING_MODULE_SIZE]</c></para>
			/// <para>An array of opaque data that contains ownership information.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TCPIP_OWNING_MODULE_SIZE)]
			public ulong[] OwningModuleInfo;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_UDP6ROW_OWNER_PID</c> structure contains an entry from the User Datagram Protocol (UDP) listener table for IPv6 on the
		/// local computer. The entry also includes the process ID (PID) that issued the call to the bind function for the UDP endpoint.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MIB_UDP6TABLE_OWNER_PID structure is returned by a call to GetExtendedUdpTable with the TableClass parameter set to a
		/// <c>UDP_TABLE_OWNER_PID</c> from the UDP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET6</c>. The
		/// <c>MIB_UDP6TABLE_OWNER_PID</c> structure contains an array of <c>MIB_UDP6ROW_OWNER_PID</c> structures.
		/// </para>
		/// <para>
		/// The <c>ucLocalAddr</c> member is stored in a character array in network byte order. On Windows Vista and later, the
		/// RtlIpv6AddressToString or RtlIpv6AddressToStringEx functions may be used to convert the IPv6 address in the <c>ucLocalAddr</c>
		/// member to a string without loading the Windows Sockets DLL.
		/// </para>
		/// <para>
		/// The <c>dwLocalScopeId</c> member is in network byte order. In order to use the <c>dwLocalScopeId</c> member, the ntohl or
		/// inet_ntoa functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c> member are in network byte order. In order to use the <c>dwLocalPort</c> member, the ntohs or inet_ntoa
		/// functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The MIB_UDP6TABLE_OWNER_PID structure contains the UDP listener table for IPv6 on the local computer. The name is based on the
		/// definition of this table in RFC 2454 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc2454.txt. This
		/// table contains UDP endpoints for IPv6 that have been bound to an address. It should be noted that an application can create a UDP
		/// socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets using
		/// this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udp6row_owner_pid typedef struct
		// _MIB_UDP6ROW_OWNER_PID { UCHAR ucLocalAddr[16]; DWORD dwLocalScopeId; DWORD dwLocalPort; DWORD dwOwningPid; }
		// MIB_UDP6ROW_OWNER_PID, *PMIB_UDP6ROW_OWNER_PID;
		[PInvokeData("udpmib.h", MSDNShortId = "d3d02485-381b-4058-b4b9-0a2c9c365f43")]
		[StructLayout(LayoutKind.Sequential, Size = 28, Pack = 4)]
		public struct MIB_UDP6ROW_OWNER_PID
		{
			/// <summary>
			/// <para>The IPv6 address for the local UDP endpoint. This member is stored in a character array in network byte order.</para>
			/// <para>
			/// A value of zero indicates a UDP listener willing to accept datagrams for any IP interface associated with the local computer.
			/// </para>
			/// </summary>
			public IN6_ADDR ucLocalAddr;

			/// <summary>
			/// <para>
			/// The scope ID for the IPv6 address of the UDP endpoint on the local computer. This member is stored in network byte order.
			/// </para>
			/// </summary>
			public uint dwLocalScopeId;

			/// <summary>
			/// <para>The port number of the UDP endpoint on the local computer. This member is stored in network byte order.</para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>
			/// The PID of the process that issued a context bind for this endpoint. If this value is set to 0, the information for this
			/// endpoint is unavailable.
			/// </para>
			/// </summary>
			public uint dwOwningPid;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_UDPROW</c> structure contains an entry from the User Datagram Protocol (UDP) listener table for IPv4 on the local computer.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The GetUdpTable function retrieves the IPv4 UDP listener table on the local computer and returns this information in a
		/// MIB_UDPTABLE structure.
		/// </para>
		/// <para>An array of <c>MIB_UDPROW</c> structures are contained in the <c>MIB_UDPTABLE</c> structure.</para>
		/// <para>
		/// The <c>dwLocalAddr</c> member is stored as a <c>DWORD</c> in the same format as the in_addr structure. In order to use the
		/// <c>dwLocalAddr</c> member, the ntohl or inet_ntoa functions in Windows Sockets or similar functions may be needed. On Windows
		/// Vista and later, the RtlIpv4AddressToString or RtlIpv4AddressToStringEx functions may be used to convert the IPv4 address in the
		/// <c>dwLocalAddr</c> member to a string without loading the Windows Sockets DLL.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c> member is in network byte order. In order to use the <c>dwLocalPort</c> member, the ntohs or inet_ntoa
		/// functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The MIB_UDPTABLE structure contains the UDP listener table for IPv4 on the local computer. The name is based on the definition of
		/// this table in RFC 1213 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc1213.txt. This table contains
		/// UDP endpoints for IPv4 that have been bound to an address. It should be noted that an application can create a UDP socket and
		/// bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets using this socket
		/// (functioning as a listener).
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udprow typedef struct _MIB_UDPROW {
		// DWORD dwLocalAddr; DWORD dwLocalPort; } MIB_UDPROW, *PMIB_UDPROW;
		[PInvokeData("udpmib.h", MSDNShortId = "db366802-962f-4e83-838e-1e2f51beab92")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct MIB_UDPROW
		{
			/// <summary>
			/// <para>The IPv4 address of the UDP endpoint on the local computer.</para>
			/// <para>
			/// A value of zero indicates a UDP listener willing to accept datagrams for any IP interface associated with the local computer.
			/// </para>
			/// </summary>
			public IN_ADDR dwLocalAddr;

			/// <summary>
			/// <para>The port number of the UDP endpoint on the local computer. This member is stored in network byte order.</para>
			/// </summary>
			public uint dwLocalPort;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_UDPROW_OWNER_MODULE</c> structure contains an entry from the IPv4 User Datagram Protocol (UDP) listener table on the
		/// local computer. This entry also also includes any available ownership data and the process ID (PID) that issued the call to the
		/// bind function for the UDP endpoint.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MIB_UDPTABLE_OWNER_MODULE structure is returned by a call to GetExtendedUdpTable with the TableClass parameter set to
		/// <c>UDP_TABLE_OWNER_MODULE</c> from the UDP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET</c>. The
		/// <c>MIB_UDPTABLE_OWNER_MODULE</c> structure contains an array of <c>MIB_UDPROW_OWNER_MODULE</c> structures.
		/// </para>
		/// <para>
		/// The <c>dwLocalAddr</c> member is stored as a <c>DWORD</c> in the same format as the in_addr structure. In order to use the
		/// <c>dwLocalAddr</c> member, the ntohl or inet_ntoa functions in Windows Sockets or similar functions may be needed. On Windows
		/// Vista and later, the RtlIpv4AddressToString or RtlIpv4AddressToStringEx functions may be used to convert the IPv4 address in the
		/// <c>dwLocalAddr</c> member to a string without loading the Windows Sockets DLL.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c> member is in network byte order. In order to use the <c>dwLocalPort</c> member, the ntohs or inet_ntoa
		/// functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The MIB_UDPTABLE_OWNER_MODULE structure contains the UDP listener table for IPv4 on the local computer. The name is based on the
		/// definition of this table in RFC 1213 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc1213.txt. This
		/// table contains UDP endpoints for IPv4 that have been bound to an address. It should be noted that an application can create a UDP
		/// socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets using
		/// this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udprow_owner_module typedef struct
		// _MIB_UDPROW_OWNER_MODULE { DWORD dwLocalAddr; DWORD dwLocalPort; DWORD dwOwningPid; LARGE_INTEGER liCreateTimestamp; union {
		// struct { int SpecificPortBind : 1; }; int dwFlags; }; ULONGLONG OwningModuleInfo[TCPIP_OWNING_MODULE_SIZE]; }
		// MIB_UDPROW_OWNER_MODULE, *PMIB_UDPROW_OWNER_MODULE;
		[PInvokeData("udpmib.h", MSDNShortId = "9ae304e0-4653-4757-a823-d4ccf68627bf")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct MIB_UDPROW_OWNER_MODULE
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The IPv4 address of the UDP endpoint on the local computer.</para>
			/// <para>
			/// A value of zero indicates a UDP listener willing to accept datagrams for any IP interface associated with the local computer.
			/// </para>
			/// </summary>
			public IN_ADDR dwLocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The port number of the UDP endpoint on the local computer. This member is stored in network byte order.</para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The PID of the process that issued the call to the bind function for the UDP endpoint. This member is set to 0 when the PID
			/// is unavailable.
			/// </para>
			/// </summary>
			public uint dwOwningPid;

			private uint padding;

			/// <summary>
			/// <para>Type: <c>LARGE_INTEGER</c></para>
			/// <para>A FILETIME structure that indicates when the call to the bind function for the UDP endpoint occurred.</para>
			/// <para>NOTE: The Microsoft documentation suggests this is a SYSTEMTIME structure. This is incorrect.</para>
			/// </summary>
			public FILETIME liCreateTimestamp;

			/// <summary>Undocumented.</summary>
			public int SpecificPortBind;

			/// <summary>
			/// <para>Type: <c>ULONGLONG[TCPIP_OWNING_MODULE_SIZE]</c></para>
			/// <para>An array of opaque data that contains ownership information.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TCPIP_OWNING_MODULE_SIZE)]
			public ulong[] OwningModuleInfo;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_UDPROW_OWNER_PID</c> structure contains an entry from the User Datagram Protocol (UDP) listener table for IPv4 on the
		/// local computer. The entry also includes the process ID (PID) that issued the call to the bind function for the UDP endpoint.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MIB_UDPTABLE_OWNER_PID structure is returned by a call to GetExtendedUdpTable with the TableClass parameter set to
		/// <c>UDP_TABLE_OWNER_PID</c> and the ulAf parameter set to <c>AF_INET</c>. The <c>MIB_UDPTABLE_OWNER_PID</c> structure contains an
		/// array of <c>MIB_UDPROW_OWNER_PID</c> structures.
		/// </para>
		/// <para>
		/// The <c>dwLocalAddr</c> member is stored as a <c>DWORD</c> in the same format as the in_addr structure. In order to use the
		/// <c>dwLocalAddr</c> member, the ntohl or inet_ntoa functions in Windows Sockets or similar functions may be needed. On Windows
		/// Vista and later, the RtlIpv4AddressToString or RtlIpv4AddressToStringEx functions may be used to convert the IPv4 address in the
		/// <c>dwLocalAddr</c> member to a string without loading the Windows Sockets DLL.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c> member is in network byte order. In order to use the <c>dwLocalPort</c> member, the ntohs or inet_ntoa
		/// functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The MIB_UDPTABLE_OWNER_PID structure contains the UDP listener table for IPv4 on the local computer. The name is based on the
		/// definition of this table in RFC 1213 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc1213.txt. This
		/// table contains UDP endpoints for IPv4 that have been bound to an address. It should be noted that an application can create a UDP
		/// socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets using
		/// this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udprow_owner_pid typedef struct
		// _MIB_UDPROW_OWNER_PID { DWORD dwLocalAddr; DWORD dwLocalPort; DWORD dwOwningPid; } MIB_UDPROW_OWNER_PID, *PMIB_UDPROW_OWNER_PID;
		[PInvokeData("udpmib.h", MSDNShortId = "b914b6eb-adf9-4a61-ae8f-05d3ff90ce90")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct MIB_UDPROW_OWNER_PID
		{
			/// <summary>
			/// <para>The IPv4 address of the UDP endpoint on the local computer.</para>
			/// <para>
			/// A value of zero indicates a UDP listener willing to accept datagrams for any IP interface associated with the local computer.
			/// </para>
			/// </summary>
			public IN_ADDR dwLocalAddr;

			/// <summary>
			/// <para>The port number of the UDP endpoint on the local computer. This member is stored in network byte order.</para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>
			/// The PID of the process that issued the call to the bind function for the UDP endpoint. This member is set to 0 when the PID
			/// is unavailable.
			/// </para>
			/// </summary>
			public uint dwOwningPid;
		}

		/// <summary>
		/// The <c>MIB_UDPSTATS</c> structure contains statistics for the User Datagram Protocol (UDP) running on the local computer.
		/// </summary>
		/// <remarks>
		/// <para>The GetUdpStatistics function returns a pointer to a <c>MIB_UDPSTATS</c> structure.</para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/udpmib/ns-udpmib-_mib_udpstats typedef struct _MIB_UDPSTATS { DWORD
		// dwInDatagrams; DWORD dwNoPorts; DWORD dwInErrors; DWORD dwOutDatagrams; DWORD dwNumAddrs; } MIB_UDPSTATS, *PMIB_UDPSTATS;
		[PInvokeData("udpmib.h", MSDNShortId = "128bae44-59a2-4e37-a588-a18805b9e340")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDPSTATS
		{
			/// <summary>The number of datagrams received.</summary>
			public uint dwInDatagrams;

			/// <summary>The number of datagrams received that were discarded because the port specified was invalid.</summary>
			public uint dwNoPorts;

			/// <summary>
			/// The number of erroneous datagrams received. This number does not include the value contained by the <c>dwNoPorts</c> member.
			/// </summary>
			public uint dwInErrors;

			/// <summary>The number of datagrams transmitted.</summary>
			public uint dwOutDatagrams;

			/// <summary>The number of entries in the UDP listener table.</summary>
			public uint dwNumAddrs;
		}

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>
		/// The <c>MIB_UDPSTATS2</c> structure contains statistics for the User Datagram Protocol (UDP) running on the local computer. This
		/// structure is different from MIB_UDPSTATS structure in that it uses 64-bit counters, rather than 32-bit counters.
		/// </para>
		/// </summary>
		/// <remarks>The GetUdpStatisticsEx2 function returns a pointer to a <c>MIB_UDPSTATS2</c> structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/udpmib/ns-udpmib-mib_udpstats2 typedef struct _MIB_UDPSTATS2 { DWORD64
		// dw64InDatagrams; DWORD dwNoPorts; DWORD dwInErrors; DWORD64 dw64OutDatagrams; DWORD dwNumAddrs; } MIB_UDPSTATS2, *PMIB_UDPSTATS2;
		[PInvokeData("udpmib.h", MSDNShortId = "A225E0E7-54FB-4655-9A45-F3EF6DA1FF4E")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDPSTATS2
		{
			/// <summary>The number of datagrams received.</summary>
			public ulong dw64InDatagrams;

			/// <summary>The number of datagrams received that were discarded because the port specified was invalid.</summary>
			public uint dwNoPorts;

			/// <summary>
			/// The number of erroneous datagrams received. This number does not include the value contained by the <c>dwNoPorts</c> member.
			/// </summary>
			public uint dwInErrors;

			/// <summary>The number of datagrams transmitted.</summary>
			public ulong dw64OutDatagrams;

			/// <summary>The number of entries in the UDP listener table.</summary>
			public uint dwNumAddrs;
		}

		/// <summary>
		/// <para>The <c>MIB_UDP6TABLE</c> structure contains the User Datagram Protocol (UDP) listener table for IPv6 on the local computer.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The GetUdp6Table function enumerates the UDP endpoints for IPv6 that have been bound to an address on the local computer and
		/// returns this information in a <c>MIB_UDP6TABLE</c> structure.
		/// </para>
		/// <para>
		/// This table includes the local IPv6 address, scope ID, and port information for sending and receiving UDP datagrams on the local
		/// computer. An array of MIB_UDP6ROW structures are contained in the <c>MIB_UDP6TABLE</c> structure.
		/// </para>
		/// <para>
		/// The <c>MIB_UDP6TABLE</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the first
		/// MIB_UDP6ROW array entry in the <c>table</c> member. Padding for alignment may also be present between the <c>MIB_UDP6ROW</c>
		/// array entries in the <c>table</c> member. Any access to a <c>MIB_UDP6ROW</c> array entry should assume padding may exist.
		/// </para>
		/// <para>
		/// The <c>MIB_UDP6TABLE</c> structure contains the UDP listener table for IPv6 on the local computer. The name is based on the
		/// definition of this table in RFC 2454 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc2454.txt. This
		/// table contains UDP endpoints for IPv6 that have been bound to an address. It should be noted that an application can create a UDP
		/// socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets using
		/// this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// The MIB_UDP6TABLE_OWNER_MODULE structure is an enhanced version of the MIB_UDP6TABLE_OWNER_PID structure that includes any
		/// available ownership data for each UDP endpoint in the table. The <c>MIB_UDP6TABLE_OWNER_PID</c> is an enhanced version of the
		/// <c>MIB_UDP6TABLE</c> that includes the process ID (PID) that issued the call to the bind function for each UDP endpoint in the table.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udp6table typedef struct
		// _MIB_UDP6TABLE { DWORD dwNumEntries; MIB_UDP6ROW table[ANY_SIZE]; } MIB_UDP6TABLE, *PMIB_UDP6TABLE;
		[PInvokeData("udpmib.h", MSDNShortId = "49da9a1f-f244-464e-96b2-944a286445d4")]
		[CorrespondingType(typeof(MIB_UDP6ROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDP6TABLE : SafeElementArray<MIB_UDP6ROW, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_UDP6TABLE"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_UDP6TABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of entries in the table.</para>
			/// </summary>
			public uint dwNumEntries => Count;

			/// <summary>
			/// <para>A pointer to an array of MIB_UDP6ROW structures.</para>
			/// </summary>
			public MIB_UDP6ROW[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_UDP6TABLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_UDP6TABLE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_UDP6TABLE table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_UDP6TABLE_OWNER_MODULE</c> structure contains the User Datagram Protocol (UDP) listener table for IPv6 on the local
		/// computer. The table also includes any available ownership data and the process ID (PID) that issued the call to the bind function
		/// for each UDP endpoint.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>MIB_UDP6TABLE_OWNER_MODULE</c> structure is returned by a call to GetExtendedUdpTable with the TableClass parameter set to
		/// a <c>UDP_TABLE_OWNER_MODULE</c> from the UDP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET6</c>. The
		/// <c>MIB_UDP6TABLE_OWNER_MODULE</c> structure contains an array of MIB_UDP6ROW_OWNER_MODULE structures.
		/// </para>
		/// <para>
		/// The <c>MIB_UDP6TABLE_OWNER_MODULE</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the
		/// first MIB_UDP6ROW_OWNER_MODULE array entry in the <c>table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_UDP6ROW_OWNER_MODULE</c> array entries in the <c>table</c> member. Any access to a <c>MIB_UDP6ROW_OWNER_MODULE</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// <para>
		/// The <c>MIB_UDP6TABLE_OWNER_MODULE</c> structure contains the UDP listener table for IPv6 on the local computer. The name is based
		/// on the definition of this table in RFC 2454 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc2454.txt.
		/// This table contains UDP endpoints for IPv6 that have been bound to an address. It should be noted that an application can create
		/// a UDP socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets
		/// using this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// The <c>MIB_UDP6TABLE_OWNER_MODULE</c> structure is an enhanced version of the MIB_UDP6TABLE_OWNER_PID structure that includes any
		/// available ownership data for each UDP endpoint in the table. The <c>MIB_UDP6TABLE_OWNER_PID</c> is an enhanced version of the
		/// MIB_UDP6TABLE that includes the process ID (PID) that issued the call to the bind function for each UDP endpoint in the table.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udp6table_owner_module typedef struct
		// _MIB_UDP6TABLE_OWNER_MODULE { DWORD dwNumEntries; MIB_UDP6ROW_OWNER_MODULE table[ANY_SIZE]; } MIB_UDP6TABLE_OWNER_MODULE, *PMIB_UDP6TABLE_OWNER_MODULE;
		[PInvokeData("udpmib.h", MSDNShortId = "11bf2d6d-b9bc-4a4d-b7b0-6f7d61eb3756")]
		[CorrespondingType(typeof(MIB_UDP6ROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDP6TABLE_OWNER_MODULE : SafeElementArray<MIB_UDP6ROW_OWNER_MODULE, ulong, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_UDP6TABLE_OWNER_MODULE"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_UDP6TABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of MIB_UDP6ROW_OWNER_MODULE elements in <c>table</c>.</para>
			/// </summary>
			public uint dwNumEntries => (uint)Count;

			/// <summary>
			/// <para>An array of MIB_UDP6ROW_OWNER_MODULE structures returned by a call to GetExtendedUdpTable.</para>
			/// </summary>
			public MIB_UDP6ROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_UDP6TABLE_OWNER_MODULE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_UDP6TABLE_OWNER_MODULE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_UDP6TABLE_OWNER_MODULE table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_UDP6TABLE_OWNER_PID</c> structure contains the User Datagram Protocol (UDP) listener table for IPv6 on the local
		/// computer. The table also includes the process ID (PID) that issued the call to the bind function for each UDP endpoint.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>MIB_UDP6TABLE_OWNER_PID</c> structure is returned by a call to GetExtendedUdpTable with the TableClass parameter set to a
		/// <c>UDP_TABLE_OWNER_PID</c> from the UDP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET6</c>. The
		/// <c>MIB_UDP6TABLE_OWNER_PID</c> structure contains an array of MIB_UDP6ROW_OWNER_PID structures.
		/// </para>
		/// <para>
		/// The <c>MIB_UDP6TABLE_OWNER_PID</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the
		/// first MIB_UDP6ROW_OWNER_PID array entry in the <c>table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_UDP6ROW_OWNER_PID</c> array entries in the <c>table</c> member. Any access to a <c>MIB_UDP6ROW_OWNER_PID</c> array entry
		/// should assume padding may exist.
		/// </para>
		/// <para>
		/// The <c>MIB_UDP6TABLE_OWNER_PID</c> structure contains the UDP listener table for IPv6 on the local computer. The name is based on
		/// the definition of this table in RFC 2454 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc2454.txt.
		/// This table contains UDP endpoints for IPv6 that have been bound to an address. It should be noted that an application can create
		/// a UDP socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets
		/// using this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// The MIB_UDP6TABLE_OWNER_MODULE structure is an enhanced version of the <c>MIB_UDP6TABLE_OWNER_PID</c> structure that includes any
		/// available ownership data for each UDP endpoint in the table. The <c>MIB_UDP6TABLE_OWNER_PID</c> is an enhanced version of the
		/// MIB_UDP6TABLE that includes the process ID (PID) that issued the call to the bind function for each UDP endpoint in the table.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udp6table_owner_pid typedef struct
		// _MIB_UDP6TABLE_OWNER_PID { DWORD dwNumEntries; MIB_UDP6ROW_OWNER_PID table[ANY_SIZE]; } MIB_UDP6TABLE_OWNER_PID, *PMIB_UDP6TABLE_OWNER_PID;
		[PInvokeData("udpmib.h", MSDNShortId = "6c8d1cb9-209b-47a0-b41c-6b4098a4a81e")]
		[CorrespondingType(typeof(MIB_UDP6ROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDP6TABLE_OWNER_PID : SafeElementArray<MIB_UDP6ROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_UDP6TABLE_OWNER_PID"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_UDP6TABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>The number of MIB_UDP6ROW_OWNER_PID elements in <c>table</c>.</summary>
			public uint dwNumEntries => Count;

			/// <summary>An array of MIB_UDP6ROW_OWNER_PID structures returned by a call to GetExtendedUdpTable.</summary>
			public MIB_UDP6ROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_UDP6TABLE_OWNER_PID"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_UDP6TABLE_OWNER_PID instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_UDP6TABLE_OWNER_PID table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>The <c>MIB_UDPTABLE</c> structure contains the User Datagram Protocol (UDP) listener table for IPv4 on the local computer.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The GetUdpTable function enumerates the table of UDP endpoints for IPv4 that have been bound to an address on the local computer
		/// and returns this information in a <c>MIB_UDPTABLE</c> structure.
		/// </para>
		/// <para>
		/// This table includes the local IPv4 address and port information for sending and receiving UDP datagrams on the local computer. An
		/// array of MIB_UDPROW structures are contained in the <c>MIB_UDPTABLE</c> structure.
		/// </para>
		/// <para>
		/// The <c>MIB_UDPTABLE</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the first
		/// MIB_UDPROW array entry in the <c>table</c> member. Padding for alignment may also be present between the <c>MIB_UDPROW</c> array
		/// entries in the <c>table</c> member. Any access to a <c>MIB_UDPROW</c> array entry should assume padding may exist.
		/// </para>
		/// <para>
		/// The <c>MIB_UDPTABLE</c> structure contains the UDP listener table for IPv4 on the local computer. The name is based on the
		/// definition of this table in RFC 1213 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc1213.txt. This
		/// table contains UDP endpoints for IPv4 that have been bound to an address. It should be noted that an application can create a UDP
		/// socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets using
		/// this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// The MIB_UDPTABLE_OWNER_MODULE structure is an enhanced version of the MIB_UDPTABLE_OWNER_PID structure that includes any
		/// available ownership data for each UDP endpoint in the table. The <c>MIB_UDPTABLE_OWNER_PID</c> is an enhanced version of the
		/// <c>MIB_UDPTABLE</c> that includes the process ID (PID) that issued the call to the bind function for each UDP endpoint in the table.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udptable typedef struct _MIB_UDPTABLE
		// { DWORD dwNumEntries; MIB_UDPROW table[ANY_SIZE]; } MIB_UDPTABLE, *PMIB_UDPTABLE;
		[PInvokeData("udpmib.h", MSDNShortId = "83608d38-e352-483a-b284-2f9cb444e64f")]
		[CorrespondingType(typeof(MIB_UDPROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDPTABLE : SafeElementArray<MIB_UDPROW, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_UDPTABLE"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_UDPTABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of entries in the table.</para>
			/// </summary>
			public uint dwNumEntries => Count;

			/// <summary>
			/// <para>A pointer to an array of MIB_UDPROW structures.</para>
			/// </summary>
			public MIB_UDPROW[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_UDPTABLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_UDPTABLE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_UDPTABLE table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_UDPTABLE_OWNER_MODULE</c> structure contains the User Datagram Protocol (UDP) listener table for IPv4 on the local
		/// computer. The table also includes any available ownership data and the process ID (PID) that issued the call to the bind function
		/// for each UDP endpoint.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>MIB_UDPTABLE_OWNER_MODULE</c> structure is returned by a call to GetExtendedUdpTable with the TableClass parameter set to
		/// <c>UDP_TABLE_OWNER_MODULE</c> from the UDP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET4</c>. The
		/// <c>MIB_UDPTABLE_OWNER_MODULE</c> structure contains an array of MIB_UDPROW_OWNER_MODULE structures.
		/// </para>
		/// <para>
		/// The <c>MIB_UDPTABLE_OWNER_MODULE</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the
		/// first MIB_UDPROW_OWNER_MODULE array entry in the <c>table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_UDPROW_OWNER_MODULE</c> array entries in the <c>table</c> member. Any access to a <c>MIB_UDPROW_OWNER_MODULE</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// <para>
		/// The <c>MIB_UDPTABLE_OWNER_MODULE</c> structure contains the UDP listener table for IPv4 on the local computer. The name is based
		/// on the definition of this table in RFC 1213 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc1213.txt.
		/// This table contains UDP endpoints for IPv4 that have been bound to an address. It should be noted that an application can create
		/// a UDP socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets
		/// using this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// The <c>MIB_UDPTABLE_OWNER_MODULE</c> structure is an enhanced version of the MIB_UDPTABLE_OWNER_PID structure that includes any
		/// available ownership data for each UDP endpoint in the table. The <c>MIB_UDPTABLE_OWNER_PID</c> is an enhanced version of the
		/// MIB_UDPTABLE that includes the process ID (PID) that issued the call to the bind function for each UDP endpoint in the table.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udptable_owner_module typedef struct
		// _MIB_UDPTABLE_OWNER_MODULE { DWORD dwNumEntries; MIB_UDPROW_OWNER_MODULE table[ANY_SIZE]; } MIB_UDPTABLE_OWNER_MODULE, *PMIB_UDPTABLE_OWNER_MODULE;
		[PInvokeData("udpmib.h", MSDNShortId = "909749d7-a6be-4b3a-b432-79a5aa6e3f4c")]
		[CorrespondingType(typeof(MIB_UDPROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDPTABLE_OWNER_MODULE : SafeElementArray<MIB_UDPROW_OWNER_MODULE, ulong, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_UDPTABLE_OWNER_MODULE"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_UDPTABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of MIB_UDPROW_OWNER_MODULE elements in <c>table</c>.</para>
			/// </summary>
			public uint dwNumEntries => (uint)Count;

			/// <summary>
			/// <para>An array of MIB_UDPROW_OWNER_MODULE structures returned by a call to GetExtendedUdpTable.</para>
			/// </summary>
			public MIB_UDPROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_UDPTABLE_OWNER_MODULE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_UDPTABLE_OWNER_MODULE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_UDPTABLE_OWNER_MODULE table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_UDPTABLE_OWNER_PID</c> structure contains the User Datagram Protocol (UDP) listener table for IPv4 on the local
		/// computer. The table also includes the process ID (PID) that issued the call to the bind function for each UDP endpoint.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>MIB_UDPTABLE_OWNER_PID</c> structure is returned by a call to GetExtendedUdpTable with the TableClass parameter set to
		/// <c>UDP_TABLE_OWNER_PID</c> from the UDP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET4</c>. The
		/// <c>MIB_UDPTABLE_OWNER_PID</c> structure contains an array of MIB_UDPROW_OWNER_PID structures.
		/// </para>
		/// <para>
		/// The <c>MIB_UDPTABLE_OWNER_PID</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the
		/// first MIB_UDPROW_OWNER_PID array entry in the <c>table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_UDPROW_OWNER_PID</c> array entries in the <c>table</c> member. Any access to a <c>MIB_UDPROW_OWNER_PID</c> array entry
		/// should assume padding may exist.
		/// </para>
		/// <para>
		/// The <c>MIB_UDPTABLE_OWNER_PID</c> structure contains the UDP listener table for IPv4 on the local computer. The name is based on
		/// the definition of this table in RFC 1213 published by the IETF. For more information, see http://www.ietf.org/rfc/rfc1213.txt.
		/// This table contains UDP endpoints for IPv4 that have been bound to an address. It should be noted that an application can create
		/// a UDP socket and bind it to an address for the sole purpose of sending a UDP datagram, with no intention of receiving packets
		/// using this socket (functioning as a listener).
		/// </para>
		/// <para>
		/// The MIB_UDPTABLE_OWNER_MODULE structure is an enhanced version of the <c>MIB_UDPTABLE_OWNER_PID</c> structure that includes any
		/// available ownership data for each UDP endpoint in the table. The <c>MIB_UDPTABLE_OWNER_PID</c> is an enhanced version of the
		/// MIB_UDPTABLE that includes the process ID (PID) that issued the call to the bind function for each UDP endpoint in the table.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Udpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/udpmib/ns-udpmib-_mib_udptable_owner_pid typedef struct
		// _MIB_UDPTABLE_OWNER_PID { DWORD dwNumEntries; MIB_UDPROW_OWNER_PID table[ANY_SIZE]; } MIB_UDPTABLE_OWNER_PID, *PMIB_UDPTABLE_OWNER_PID;
		[PInvokeData("udpmib.h", MSDNShortId = "7c51a1e4-1e07-4fb1-8db3-e48229f12aca")]
		[CorrespondingType(typeof(MIB_UDPROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDPTABLE_OWNER_PID : SafeElementArray<MIB_UDPROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_UDPTABLE_OWNER_PID"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_UDPTABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of MIB_UDPROW_OWNER_PID elements in <c>table</c>.</para>
			/// </summary>
			public uint dwNumEntries => Count;

			/// <summary>
			/// <para>An array of MIB_UDPROW_OWNER_PID structures returned by a call to GetExtendedUdpTable.</para>
			/// </summary>
			public MIB_UDPROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_UDPTABLE_OWNER_PID"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_UDPTABLE_OWNER_PID instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_UDPTABLE_OWNER_PID table) => table.DangerousGetHandle();
		}
	}
}