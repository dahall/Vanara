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
		/// <para>The <c>TCP_CONNECTION_OFFLOAD_STATE</c> enumeration defines the possible TCP offload states for a TCP connection.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>TCP_CONNECTION_OFFLOAD_STATE</c> enumeration is defined on Windows Server 2003 and later.</para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>TCP_CONNECTION_OFFLOAD_STATE</c> enumeration is defined in the Tcpmib.h header file not in the Iprtrmib.h
		/// header file. Note that the Tcpmib.h header file is automatically included in Iprtrmib.h which is automatically included in the
		/// Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ne-tcpmib-tcp_connection_offload_state typedef enum
		// TCP_CONNECTION_OFFLOAD_STATE { TcpConnectionOffloadStateInHost , TcpConnectionOffloadStateOffloading ,
		// TcpConnectionOffloadStateOffloaded , TcpConnectionOffloadStateUploading , TcpConnectionOffloadStateMax } *PTCP_CONNECTION_OFFLOAD_STATE;
		[PInvokeData("tcpmib.h", MSDNShortId = "cef633e7-1577-4f10-bd14-8d8e85aa78e6")]
		public enum TCP_CONNECTION_OFFLOAD_STATE
		{
			/// <summary>The TCP connection is currently owned by the network stack on the local computer, and is not offloaded</summary>
			TcpConnectionOffloadStateInHost = 0,

			/// <summary>The TCP connection is in the process of being offloaded, but the offload has not been completed.</summary>
			TcpConnectionOffloadStateOffloading,

			/// <summary>The TCP connection is offloaded to the network interface controller.</summary>
			TcpConnectionOffloadStateOffloaded,

			/// <summary>
			/// The TCP connection is in the process of being uploaded back to the network stack on the local computer, but the
			/// reinstate-to-host process has not completed.
			/// </summary>
			TcpConnectionOffloadStateUploading,

			/// <summary>
			/// The maximum possible value for the TCP_CONNECTION_OFFLOAD_STATE enumeration type. This is not a legal value for the possible
			/// TCP connection offload state.
			/// </summary>
			TcpConnectionOffloadStateMax,
		}

		/// <summary>The TCP_RTO_ALGORITHM enumerates different TCP retransmission time-out algorithms.</summary>
		[PInvokeData("tcpmib.h", MSDNShortId = "cc669306")]
		public enum TCP_RTO_ALGORITHM
		{
			/// <summary>Other.</summary>
			TcpRtoAlgorithmOther = 1,

			/// <summary>Constant time-out.</summary>
			TcpRtoAlgorithmConstant = 2,

			/// <summary>MIL-STD-1778. See [RFC4022].</summary>
			TcpRtoAlgorithmRsre = 3,

			/// <summary>Van Jacobson's algorithm. See [RFC1144].</summary>
			TcpRtoAlgorithmVanj = 4,

			/// <summary>Other.</summary>
			MIB_TCP_RTO_OTHER = 1,

			/// <summary>Constant time-out.</summary>
			MIB_TCP_RTO_CONSTANT = 2,

			/// <summary>MIL-STD-1778. See [RFC4022].</summary>
			MIB_TCP_RTO_RSRE = 3,

			/// <summary>Van Jacobson's algorithm. See [RFC1144].</summary>
			MIB_TCP_RTO_VANJ = 4,
		}

		/// <summary>
		/// <para>The <c>MIB_TCP6ROW</c> structure contains information that describes an IPv6 TCP connection.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>MIB_TCP6ROW</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetTcp6Table function retrieves the IPv6 TCP connection table on the local computer and returns this information in a
		/// MIB_TCP6TABLE structure.
		/// </para>
		/// <para>An array of <c>MIB_TCP6ROW</c> structures are contained in the <c>MIB_TCP6TABLE</c> structure.</para>
		/// <para>
		/// The <c>State</c> member indicates the state of the TCP entry in a TCP state diagram. A TCP connection progresses through a series
		/// of states during its lifetime. The states are: LISTEN, SYN-SENT, SYN-RECEIVED, ESTABLISHED, FIN-WAIT-1, FIN-WAIT-2, CLOSE-WAIT,
		/// CLOSING, LAST-ACK, TIME-WAIT, and the fictional state CLOSED. The CLOSED state is fictional because it represents the state when
		/// there is no Transmission Control Block, and therefore, no connection. The TCP protocol is described in RFC 793. For more
		/// information, see http://www.ietf.org/rfc/rfc793.txt.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c>, and <c>dwRemotePort</c> members are in network byte order. In order to use the <c>dwLocalPort</c> or
		/// <c>dwRemotePort</c> members, the ntohs or inet_ntoa functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The <c>dwLocalScopeId</c>, and <c>dwRemoteScopeId</c> members are in network byte order. In order to use the
		/// <c>dwLocalScopeId</c> or <c>dwRemoteScopeId</c> members, the ntohl or inet_ntoa functions in Windows Sockets or similar functions
		/// may be needed.
		/// </para>
		/// <para>
		/// The <c>LocalAddr</c> and <c>RemoteAddr</c> members are stored in in6_addr structures. The RtlIpv6AddressToString or
		/// RtlIpv6AddressToStringEx functions may be used to convert the IPv6 address in the <c>LocalAddr</c> or <c>RemoteAddr</c> members
		/// to a string without loading the Windows Sockets DLL.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the TCP connection table for IPv6 and prints the state of each connection represented as a
		/// <c>MIB_TCP6ROW</c> structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcp6row typedef struct _MIB_TCP6ROW {
		// MIB_TCP_STATE State; IN6_ADDR LocalAddr; DWORD dwLocalScopeId; DWORD dwLocalPort; IN6_ADDR RemoteAddr; DWORD dwRemoteScopeId;
		// DWORD dwRemotePort; } MIB_TCP6ROW, *PMIB_TCP6ROW;
		[PInvokeData("tcpmib.h", MSDNShortId = "b3e9eda5-5e86-4790-8b1b-ca9bae44b502")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct MIB_TCP6ROW
		{
			/// <summary>
			/// <para>Type: <c>MIB_TCP_STATE</c></para>
			/// <para>
			/// The state of the TCP connection. This member can be one of the values from the <c>MIB_TCP_STATE</c> enumeration type defined
			/// in the Tcpmib.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSED 1</term>
			/// <term>The TCP connection is in the CLOSED state that represents no connection state at all.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LISTEN 2</term>
			/// <term>The TCP connection is in the LISTEN state waiting for a connection request from any remote TCP and port.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_SENT 3</term>
			/// <term>
			/// The TCP connection is in the SYN-SENT state waiting for a matching connection request after having sent a connection request
			/// (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_RCVD 4</term>
			/// <term>
			/// The TCP connection is in the SYN-RECEIVED state waiting for a confirming connection request acknowledgment after having both
			/// received and sent a connection request (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_ESTAB 5</term>
			/// <term>
			/// The TCP connection is in the ESTABLISHED state that represents an open connection, data received can be delivered to the
			/// user. This is the normal state for the data transfer phase of the TCP connection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT1 6</term>
			/// <term>
			/// The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP, or an acknowledgment
			/// of the connection termination request previously sent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT2 7</term>
			/// <term>The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSE_WAIT 8</term>
			/// <term>The TCP connection is in the CLOSE-WAIT state waiting for a connection termination request from the local user.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSING 9</term>
			/// <term>
			/// The TCP connection is in the CLOSING state waiting for a connection termination request acknowledgment from the remote TCP.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LAST_ACK 10</term>
			/// <term>
			/// The TCP connection is in the LAST-ACK state waiting for an acknowledgment of the connection termination request previously
			/// sent to the remote TCP (which includes an acknowledgment of its connection termination request).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_TIME_WAIT 11</term>
			/// <term>
			/// The TCP connection is in the TIME-WAIT state waiting for enough time to pass to be sure the remote TCP received the
			/// acknowledgment of its connection termination request.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_DELETE_TCB 12</term>
			/// <term>
			/// The TCP connection is in the delete TCB state that represents the deletion of the Transmission Control Block (TCB), a data
			/// structure used to maintain information on each TCP entry.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIB_TCP_STATE dwState;

			/// <summary>
			/// <para>Type: <c>IN6_ADDR</c></para>
			/// <para>
			/// The local IPv6 address for the TCP connection on the local computer. A value of zero indicates the listener can accept a
			/// connection on any interface.
			/// </para>
			/// </summary>
			public IN6_ADDR LocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The local scope ID for the TCP connection on the local computer.</para>
			/// </summary>
			public uint dwLocalScopeId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The local port number in network byte order for the TCP connection on the local computer.</para>
			/// <para>
			/// The maximum size of an IP port number is 16 bits, so only the lower 16 bits should be used. The upper 16 bits may contain
			/// uninitialized data.
			/// </para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>IN6_ADDR</c></para>
			/// <para>
			/// The IPv6 address for the TCP connection on the remote computer. When the <c>State</c> member is <c>MIB_TCP_STATE_LISTEN</c>,
			/// this value has no meaning.
			/// </para>
			/// </summary>
			public IN6_ADDR RemoteAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The remote scope ID for the TCP connection on the remote computer. When the <c>State</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// </summary>
			public uint dwRemoteScopeId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The remote port number in network byte order for the TCP connection on the remote computer. When the <c>State</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// <para>
			/// The maximum size of an IP port number is 16 bits, so only the lower 16 bits should be used. The upper 16 bits may contain
			/// uninitialized data.
			/// </para>
			/// </summary>
			public uint dwRemotePort;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_TCP6ROW_OWNER_MODULE</c> structure contains information that describes an IPv6 TCP connection bound to a specific
		/// process ID (PID) with ownership data.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MIB_TCP6TABLE_OWNER_MODULE structure is returned by a call to GetExtendedTcpTable with the TableClass parameter set to a
		/// <c>TCP_TABLE_OWNER_MODULE_LISTENER</c>, <c>TCP_TABLE_OWNER_MODULE_CONNECTIONS</c>, or <c>TCP_TABLE_OWNER_MODULE_ALL</c> from the
		/// TCP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET6</c>. The <c>MIB_TCP6TABLE_OWNER_MODULE</c> structure
		/// contains an array of <c>MIB_TCP6ROW_OWNER_MODULE</c> structures.
		/// </para>
		/// <para>
		/// The <c>dwState</c> member indicates the state of the TCP entry in a TCP state diagram. A TCP connection progresses through a
		/// series of states during its lifetime. The states are: LISTEN, SYN-SENT, SYN-RECEIVED, ESTABLISHED, FIN-WAIT-1, FIN-WAIT-2,
		/// CLOSE-WAIT, CLOSING, LAST-ACK, TIME-WAIT, and the fictional state CLOSED. The CLOSED state is fictional because it represents the
		/// state when there is no Transmission Control Block, and therefore, no connection. The TCP protocol is described in RFC 793. For
		/// more information, see http://www.ietf.org/rfc/rfc793.txt.
		/// </para>
		/// <para>
		/// The <c>ucLocalAddr</c> and <c>ucRemoteAddr</c> members are stored in a character array in network byte order. The
		/// RtlIpv6AddressToString or RtlIpv6AddressToStringEx functions may be used to convert the IPv6 address in the <c>ucLocalAddr</c> or
		/// <c>ucRemoteAddr</c> members to a string without loading the Windows Sockets DLL.
		/// </para>
		/// <para>
		/// The <c>dwLocalScopeId</c>, and <c>dwRemoteScopeId</c> members are in network byte order. In order to use the
		/// <c>dwLocalScopeId</c> or <c>dwRemoteScopeId</c> members, the ntohl or inet_ntoa functions in Windows Sockets or similar functions
		/// may be needed.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c> and <c>dwRemotePort</c> members are in network byte order. In order to use the <c>dwLocalPort</c> or
		/// <c>dwRemotePort</c> members, the ntohs or inet_ntoa functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcp6row_owner_module typedef struct
		// _MIB_TCP6ROW_OWNER_MODULE { UCHAR ucLocalAddr[16]; DWORD dwLocalScopeId; DWORD dwLocalPort; UCHAR ucRemoteAddr[16]; DWORD
		// dwRemoteScopeId; DWORD dwRemotePort; DWORD dwState; DWORD dwOwningPid; LARGE_INTEGER liCreateTimestamp; ULONGLONG
		// OwningModuleInfo[TCPIP_OWNING_MODULE_SIZE]; } MIB_TCP6ROW_OWNER_MODULE, *PMIB_TCP6ROW_OWNER_MODULE;
		[PInvokeData("tcpmib.h", MSDNShortId = "24f2041c-0a8c-4f2c-8585-ebbb0cad394f")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCP6ROW_OWNER_MODULE
		{
			/// <summary>
			/// <para>Type: <c>UCHAR[16]</c></para>
			/// <para>
			/// The IPv6 address for the local endpoint of the TCP connection on the local computer. A value of zero indicates the listener
			/// can accept a connection on any interface.
			/// </para>
			/// </summary>
			public IN6_ADDR ucLocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The scope ID in network byte order for the local IPv6 address.</para>
			/// </summary>
			public uint dwLocalScopeId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The port number in network byte order for the local endpoint of the TCP connection on the local computer.</para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>UCHAR[16]</c></para>
			/// <para>
			/// The IPv6 address of the remote endpoint of the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// </summary>
			public IN6_ADDR ucRemoteAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The scope ID in network byte order for the remote IPv6 address.</para>
			/// </summary>
			public uint dwRemoteScopeId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The port number in network byte order for the remote endpoint of the TCP connection on the remote computer.</para>
			/// </summary>
			public uint dwRemotePort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The state of the TCP connection. This member can be one of the values from the <c>MIB_TCP_STATE</c> enumeration defined in
			/// the Tcpmib.h header file. Note that the Tcpmib.h header file is automatically included in Iprtrmib.h, which is automatically
			/// included in the Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never be used directly.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSED 1</term>
			/// <term>The TCP connection is in the CLOSED state that represents no connection state at all.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LISTEN 2</term>
			/// <term>The TCP connection is in the LISTEN state waiting for a connection request from any remote TCP and port.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_SENT 3</term>
			/// <term>
			/// The TCP connection is in the SYN-SENT state waiting for a matching connection request after having sent a connection request
			/// (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_RCVD 4</term>
			/// <term>
			/// The TCP connection is in the SYN-RECEIVED state waiting for a confirming connection request acknowledgment after having both
			/// received and sent a connection request (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_ESTAB 5</term>
			/// <term>
			/// The TCP connection is in the ESTABLISHED state that represents an open connection, data received can be delivered to the
			/// user. This is the normal state for the data transfer phase of the TCP connection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT1 6</term>
			/// <term>
			/// The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP, or an acknowledgment
			/// of the connection termination request previously sent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT2 7</term>
			/// <term>The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSE_WAIT 8</term>
			/// <term>The TCP connection is in the CLOSE-WAIT state waiting for a connection termination request from the local user.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSING 9</term>
			/// <term>
			/// The TCP connection is in the CLOSING state waiting for a connection termination request acknowledgment from the remote TCP.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LAST_ACK 10</term>
			/// <term>
			/// The TCP connection is in the LAST-ACK state waiting for an acknowledgment of the connection termination request previously
			/// sent to the remote TCP (which includes an acknowledgment of its connection termination request).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_TIME_WAIT 11</term>
			/// <term>
			/// The TCP connection is in the TIME-WAIT state waiting for enough time to pass to be sure the remote TCP received the
			/// acknowledgment of its connection termination request.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_DELETE_TCB 12</term>
			/// <term>
			/// The TCP connection is in the delete TCB state that represents the deletion of the Transmission Control Block (TCB), a data
			/// structure used to maintain information on each TCP entry.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIB_TCP_STATE dwState;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The PID of the local process that issued a context bind for this TCP connection.</para>
			/// </summary>
			public uint dwOwningPid;

			/// <summary>
			/// <para>Type: <c>LARGE_INTEGER</c></para>
			/// <para>A FILETIME structure that indicates when the context bind operation that created this TCP connection occurred.</para>
			/// <para>NOTE: The Microsoft documentation suggests this is a SYSTEMTIME structure. This is incorrect.</para>
			/// </summary>
			public FILETIME liCreateTimestamp;

			/// <summary>
			/// <para>Type: <c>ULONGLONG[TCPIP_OWNING_MODULE_SIZE]</c></para>
			/// <para>An array of opaque data that contains ownership information.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TCPIP_OWNING_MODULE_SIZE)]
			public ulong[] OwningModuleInfo;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_TCP6ROW_OWNER_PID</c> structure contains information that describes an IPv6 TCP connection associated with a specific
		/// process ID (PID).
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MIB_TCP6TABLE_OWNER_PID structure is returned by a call to GetExtendedTcpTable with the TableClass parameter set to
		/// <c>TCP_TABLE_OWNER_PID_LISTENER</c>, <c>TCP_TABLE_OWNER_PID_CONNECTIONS</c>, or <c>TCP_TABLE_OWNER_PID_ALL</c> from the
		/// TCP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET6</c>. The <c>MIB_TCP6TABLE_OWNER_PID</c> structure contains
		/// an array of <c>MIB_TCP6ROW_OWNER_PID</c> structures.
		/// </para>
		/// <para>
		/// The <c>dwState</c> member indicates the state of the TCP entry in a TCP state diagram. A TCP connection progresses through a
		/// series of states during its lifetime. The states are: LISTEN, SYN-SENT, SYN-RECEIVED, ESTABLISHED, FIN-WAIT-1, FIN-WAIT-2,
		/// CLOSE-WAIT, CLOSING, LAST-ACK, TIME-WAIT, and the fictional state CLOSED. The CLOSED state is fictional because it represents the
		/// state when there is no Transmission Control Block, and therefore, no connection. The TCP protocol is described in RFC 793. For
		/// more information, see http://www.ietf.org/rfc/rfc793.txt.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c>, and <c>dwRemotePort</c> members are in network byte order. In order to use the <c>dwLocalPort</c> or
		/// <c>dwRemotePort</c> members, the ntohs or inet_ntoa functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The <c>dwLocalScopeId</c>, and <c>dwRemoteScopeId</c> members are in network byte order. In order to use the
		/// <c>dwLocalScopeId</c> or <c>dwRemoteScopeId</c> members, the ntohl or inet_ntoa functions in Windows Sockets or similar functions
		/// may be needed.
		/// </para>
		/// <para>
		/// The <c>ucLocalAddr</c> and <c>ucRemoteAddr</c> members are stored in a character array in network byte order. The
		/// RtlIpv6AddressToString or RtlIpv6AddressToStringEx functions may be used to convert the IPv6 address in the <c>ucLocalAddr</c> or
		/// <c>ucRemoteAddr</c> members to a string without loading the Windows Sockets DLL.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcp6row_owner_pid typedef struct
		// _MIB_TCP6ROW_OWNER_PID { UCHAR ucLocalAddr[16]; DWORD dwLocalScopeId; DWORD dwLocalPort; UCHAR ucRemoteAddr[16]; DWORD
		// dwRemoteScopeId; DWORD dwRemotePort; DWORD dwState; DWORD dwOwningPid; } MIB_TCP6ROW_OWNER_PID, *PMIB_TCP6ROW_OWNER_PID;
		[PInvokeData("tcpmib.h", MSDNShortId = "d0c9c783-c095-487e-a007-8a10700f9fea")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCP6ROW_OWNER_PID
		{
			/// <summary>
			/// <para>Type: <c>UCHAR[16]</c></para>
			/// <para>
			/// The IPv6 address for the local endpoint of the TCP connection on the local computer. A value of zero indicates the listener
			/// can accept a connection on any interface.
			/// </para>
			/// </summary>
			public IN6_ADDR ucLocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The scope ID in network byte order for the local IPv6 address.</para>
			/// </summary>
			public uint dwLocalScopeId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The port number in network byte order for the local endpoint of the TCP connection on the local computer.</para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>UCHAR[16]</c></para>
			/// <para>
			/// The IPv6 address of the remote endpoint of the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// </summary>
			public IN6_ADDR ucRemoteAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The scope ID in network byte order for the remote IPv6 address.</para>
			/// </summary>
			public uint dwRemoteScopeId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The port number in network byte order for the remote endpoint of the TCP connection on the remote computer.</para>
			/// </summary>
			public uint dwRemotePort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The state of the TCP connection. This member can be one of the values from the <c>MIB_TCP_STATE</c> enumeration defined in
			/// the Tcpmib.h header file. Note that the Tcpmib.h header file is automatically included in Iprtrmib.h, which is automatically
			/// included in the Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never be used directly.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSED 1</term>
			/// <term>The TCP connection is in the CLOSED state that represents no connection state at all.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LISTEN 2</term>
			/// <term>The TCP connection is in the LISTEN state waiting for a connection request from any remote TCP and port.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_SENT 3</term>
			/// <term>
			/// The TCP connection is in the SYN-SENT state waiting for a matching connection request after having sent a connection request
			/// (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_RCVD 4</term>
			/// <term>
			/// The TCP connection is in the SYN-RECEIVED state waiting for a confirming connection request acknowledgment after having both
			/// received and sent a connection request (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_ESTAB 5</term>
			/// <term>
			/// The TCP connection is in the ESTABLISHED state that represents an open connection, data received can be delivered to the
			/// user. This is the normal state for the data transfer phase of the TCP connection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT1 6</term>
			/// <term>
			/// The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP, or an acknowledgment
			/// of the connection termination request previously sent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT2 7</term>
			/// <term>The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSE_WAIT 8</term>
			/// <term>The TCP connection is in the CLOSE-WAIT state waiting for a connection termination request from the local user.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSING 9</term>
			/// <term>
			/// The TCP connection is in the CLOSING state waiting for a connection termination request acknowledgment from the remote TCP.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LAST_ACK 10</term>
			/// <term>
			/// The TCP connection is in the LAST-ACK state waiting for an acknowledgment of the connection termination request previously
			/// sent to the remote TCP (which includes an acknowledgment of its connection termination request).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_TIME_WAIT 11</term>
			/// <term>
			/// The TCP connection is in the TIME-WAIT state waiting for enough time to pass to be sure the remote TCP received the
			/// acknowledgment of its connection termination request.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_DELETE_TCB 12</term>
			/// <term>
			/// The TCP connection is in the delete TCB state that represents the deletion of the Transmission Control Block (TCB), a data
			/// structure used to maintain information on each TCP entry.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIB_TCP_STATE dwState;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The PID of the local process that issued a context bind for this TCP connection.</para>
			/// </summary>
			public uint dwOwningPid;
		}

		/// <summary>The <c>MIB_TCP6ROW2</c> structure contains information that describes an IPv6 TCP connection.</summary>
		/// <remarks>
		/// <para>The <c>MIB_TCP6ROW2</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetTcp6Table2function retrieves the IPv6 TCP connection table on the local computer and returns this information in a
		/// MIB_TCP6TABLE2 structure.
		/// </para>
		/// <para>An array of <c>MIB_TCP6ROW2</c> structures are contained in the <c>MIB_TCP6TABLE2</c> structure.</para>
		/// <para>
		/// The <c>State</c> member indicates the state of the TCP entry in a TCP state diagram. A TCP connection progresses through a series
		/// of states during its lifetime. The states are: LISTEN, SYN-SENT, SYN-RECEIVED, ESTABLISHED, FIN-WAIT-1, FIN-WAIT-2, CLOSE-WAIT,
		/// CLOSING, LAST-ACK, TIME-WAIT, and the fictional state CLOSED. The CLOSED state is fictional because it represents the state when
		/// there is no Transmission Control Block, and therefore, no connection. The TCP protocol is described in RFC 793. For more
		/// information, see http://www.ietf.org/rfc/rfc793.txt.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c>, and <c>dwRemotePort</c> members are in network byte order. In order to use the <c>dwLocalPort</c> or
		/// <c>dwRemotePort</c> members, the ntohs or inet_ntoa functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The <c>dwLocalScopeId</c>, and <c>dwRemoteScopeId</c> members are in network byte order. In order to use the
		/// <c>dwLocalScopeId</c> or <c>dwRemoteScopeId</c> members, the ntohl or inet_ntoa functions in Windows Sockets or similar functions
		/// may be needed.
		/// </para>
		/// <para>
		/// The <c>LocalAddr</c> and <c>RemoteAddr</c> members are stored in in6_addr structures. The RtlIpv6AddressToString or
		/// RtlIpv6AddressToStringEx functions may be used to convert the IPv6 address in the <c>LocalAddr</c> or <c>RemoteAddr</c> members
		/// to a string without loading the Windows Sockets DLL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcp6row2 typedef struct _MIB_TCP6ROW2 { IN6_ADDR
		// LocalAddr; DWORD dwLocalScopeId; DWORD dwLocalPort; IN6_ADDR RemoteAddr; DWORD dwRemoteScopeId; DWORD dwRemotePort; MIB_TCP_STATE
		// State; DWORD dwOwningPid; TCP_CONNECTION_OFFLOAD_STATE dwOffloadState; } MIB_TCP6ROW2, *PMIB_TCP6ROW2;
		[PInvokeData("tcpmib.h", MSDNShortId = "bbec3397-0317-40f7-926f-2ec48cf5386d")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct MIB_TCP6ROW2
		{
			/// <summary>
			/// <para>Type: <c>IN6_ADDR</c></para>
			/// <para>
			/// The local IPv6 address for the TCP connection on the local computer. A value of zero indicates the listener can accept a
			/// connection on any interface.
			/// </para>
			/// </summary>
			public IN6_ADDR LocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The local scope ID for the TCP connection on the local computer.</para>
			/// </summary>
			public uint dwLocalScopeId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The local port number in network byte order for the TCP connection on the local computer.</para>
			/// <para>
			/// The maximum size of an IP port number is 16 bits, so only the lower 16 bits should be used. The upper 16 bits may contain
			/// uninitialized data.
			/// </para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>IN6_ADDR</c></para>
			/// <para>
			/// The IPv6 address for the TCP connection on the remote computer. When the <c>State</c> member is <c>MIB_TCP_STATE_LISTEN</c>,
			/// this value has no meaning.
			/// </para>
			/// </summary>
			public IN6_ADDR RemoteAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The remote scope ID for the TCP connection on the remote computer. When the <c>State</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// </summary>
			public uint dwRemoteScopeId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The remote port number in network byte order for the TCP connection on the remote computer. When the <c>State</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// <para>
			/// The maximum size of an IP port number is 16 bits, so only the lower 16 bits should be used. The upper 16 bits may contain
			/// uninitialized data.
			/// </para>
			/// </summary>
			public uint dwRemotePort;

			/// <summary>
			/// <para>Type: <c>MIB_TCP_STATE</c></para>
			/// <para>
			/// The state of the TCP connection. This member can be one of the values from the <c>MIB_TCP_STATE</c> enumeration type defined
			/// in the Tcpmib.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSED 1</term>
			/// <term>The TCP connection is in the CLOSED state that represents no connection state at all.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LISTEN 2</term>
			/// <term>The TCP connection is in the LISTEN state waiting for a connection request from any remote TCP and port.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_SENT 3</term>
			/// <term>
			/// The TCP connection is in the SYN-SENT state waiting for a matching connection request after having sent a connection request
			/// (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_RCVD 4</term>
			/// <term>
			/// The TCP connection is in the SYN-RECEIVED state waiting for a confirming connection request acknowledgment after having both
			/// received and sent a connection request (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_ESTAB 5</term>
			/// <term>
			/// The TCP connection is in the ESTABLISHED state that represents an open connection, data received can be delivered to the
			/// user. This is the normal state for the data transfer phase of the TCP connection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT1 6</term>
			/// <term>
			/// The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP, or an acknowledgment
			/// of the connection termination request previously sent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT2 7</term>
			/// <term>The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSE_WAIT 8</term>
			/// <term>The TCP connection is in the CLOSE-WAIT state waiting for a connection termination request from the local user.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSING 9</term>
			/// <term>
			/// The TCP connection is in the CLOSING state waiting for a connection termination request acknowledgment from the remote TCP.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LAST_ACK 10</term>
			/// <term>
			/// The TCP connection is in the LAST-ACK state waiting for an acknowledgment of the connection termination request previously
			/// sent to the remote TCP (which includes an acknowledgment of its connection termination request).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_TIME_WAIT 11</term>
			/// <term>
			/// The TCP connection is in the TIME-WAIT state waiting for enough time to pass to be sure the remote TCP received the
			/// acknowledgment of its connection termination request.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_DELETE_TCB 12</term>
			/// <term>
			/// The TCP connection is in the delete TCB state that represents the deletion of the Transmission Control Block (TCB), a data
			/// structure used to maintain information on each TCP entry.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIB_TCP_STATE State;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The PID of the process that issued a context bind for this TCP connection.</para>
			/// </summary>
			public uint dwOwningPid;

			/// <summary>
			/// <para>Type: <c>TCP_CONNECTION_OFFLOAD_STATE</c></para>
			/// <para>
			/// The offload state for this TCP connection. This parameter can be one of the enumeration values for the
			/// TCP_CONNECTION_OFFLOAD_STATE defined in the Tcpmib.h header.
			/// </para>
			/// </summary>
			public TCP_CONNECTION_OFFLOAD_STATE dwOffloadState;
		}

		/// <summary>
		/// <para>The <c>MIB_TCPROW</c> structure contains information that descibes an IPv4 TCP connection.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The GetTcpTable function retrieves the IPv4 TCP connection table on the local computer and returns this information in a
		/// MIB_TCPTABLE structure.
		/// </para>
		/// <para>
		/// An array of <c>MIB_TCPROW</c> structures are contained in the <c>MIB_TCPTABLE</c> structure. The <c>MIB_TCPROW</c> structure is
		/// also used by the SetTcpEntry function.
		/// </para>
		/// <para>
		/// The <c>dwState</c> member indicates the state of the TCP entry in a TCP state diagram. A TCP connection progresses through a
		/// series of states during its lifetime. The states are: LISTEN, SYN-SENT, SYN-RECEIVED, ESTABLISHED, FIN-WAIT-1, FIN-WAIT-2,
		/// CLOSE-WAIT, CLOSING, LAST-ACK, TIME-WAIT, and the fictional state CLOSED. The CLOSED state is fictional because it represents the
		/// state when there is no Transmission Control Block, and therefore, no connection. The TCP protocol is described in RFC 793. For
		/// more information, see http://www.ietf.org/rfc/rfc793.txt.
		/// </para>
		/// <para>
		/// The <c>dwLocalAddr</c> and <c>dwRemoteAddr</c> members are stored as a <c>DWORD</c> in the same format as the in_addr structure.
		/// In order to use the <c>dwLocalAddr</c> or <c>dwRemoteAddr</c> members, the ntohl or inet_ntoa functions in Windows Sockets or
		/// similar functions may be needed. On Windows Vista and later, the RtlIpv4AddressToString or RtlIpv4AddressToStringEx functions may
		/// be used to convert the IPv4 address in the <c>dwLocalAddr</c> or <c>dwRemoteAddr</c> members to a string without loading the
		/// Windows Sockets DLL.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c>, and <c>dwRemotePort</c> members are in network byte order. In order to use the <c>dwLocalPort</c> or
		/// <c>dwRemotePort</c> members, the ntohs or inet_ntoa functions in Windows Sockets or similar functions may be needed.
		/// </para>
		/// <para>
		/// The <c>MIB_TCPROW</c> structure changed slightly on Windows Vista and later. On Windows Vista and later, the <c>dwState</c>
		/// member is replaced by a union that contains the following members.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DWORD dwState</term>
		/// <term>The state of the TCP connection.</term>
		/// </item>
		/// <item>
		/// <term>MIB_TCP_STATE State</term>
		/// <term>
		/// The state of the TCP connection. This member can be one of the values from the MIB_TCP_STATE enumeration type defined in the
		/// Tcpmib.h header file. The possible values are the same as those defined for the dwState member.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// In the Windows SDK, the version of the structure for use on Windows Vista and later is defined as <c>MIB_TCPROW_LH</c>. In the
		/// Windows SDK, the version of this structure to be used on earlier systems including Windows 2000 and later is defined as
		/// <c>MIB_TCPROW_W2K</c>. When compiling an application if the target platform is Windows Vista and later (, , or ), the
		/// <c>MIB_TCPROW_LH</c> structure is typedefed to the <c>MIB_TCPROW</c> structure. When compiling an application if the target
		/// platform is not Windows Vista and later, the <c>MIB_TCPROW_W2K</c> structure is typedefed to the <c>MIB_TCPROW</c> structure.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed. This structure is defined
		/// in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h header file is automatically included in
		/// Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never
		/// be used directly.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the TCP connection table and prints the state of each connection represented as a
		/// <c>MIB_TCPROW</c> structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcprow_lh typedef struct
		// _MIB_TCPROW_LH { union { DWORD dwState; MIB_TCP_STATE State; }; DWORD dwLocalAddr; DWORD dwLocalPort; DWORD dwRemoteAddr; DWORD
		// dwRemotePort; } MIB_TCPROW_LH, *PMIB_TCPROW_LH;
		[PInvokeData("tcpmib.h", MSDNShortId = "36364854-caa8-4652-be8e-f741b36d9fd7")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPROW
		{
			/// <summary>The state of the TCP connection.</summary>
			public MIB_TCP_STATE dwState;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The local IPv4 address for the TCP connection on the local computer. A value of zero indicates the listener can accept a
			/// connection on any interface.
			/// </para>
			/// </summary>
			public uint dwLocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The local port number in network byte order for the TCP connection on the local computer.</para>
			/// <para>
			/// The maximum size of an IP port number is 16 bits, so only the lower 16 bits should be used. The upper 16 bits may contain
			/// uninitialized data.
			/// </para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The IPv4 address for the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// </summary>
			public uint dwRemoteAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The remote port number in network byte order for the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this member has no meaning.
			/// </para>
			/// <para>
			/// The maximum size of an IP port number is 16 bits, so only the lower 16 bits should be used. The upper 16 bits may contain
			/// uninitialized data.
			/// </para>
			/// </summary>
			public uint dwRemotePort;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_TCPROW_OWNER_MODULE</c> structure contains information that describes an IPv4 TCP connection with ownership data, IPv4
		/// addresses, ports used by the TCP connection, and the specific process ID (PID) associated with connection.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>MIB_TCPROW_OWNER_MODULE</c> structure is returned by a call to GetExtendedTcpTable with the TableClass parameter set to
		/// <c>TCP_TABLE_OWNER_MODULE_LISTENER</c>, <c>TCP_TABLE_OWNER_MODULE_CONNECTIONS</c>, or <c>TCP_TABLE_OWNER_MODULE_ALL</c> from the
		/// TCP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET4</c>.
		/// </para>
		/// <para>
		/// The <c>dwState</c> member indicates the state of the TCP entry in a TCP state diagram. A TCP connection progresses through a
		/// series of states during its lifetime. The states are: LISTEN, SYN-SENT, SYN-RECEIVED, ESTABLISHED, FIN-WAIT-1, FIN-WAIT-2,
		/// CLOSE-WAIT, CLOSING, LAST-ACK, TIME-WAIT, and the fictional state CLOSED. The CLOSED state is fictional because it represents the
		/// state when there is no Transmission Control Block, and therefore, no connection. The TCP protocol is described in RFC 793. For
		/// more information, see http://www.ietf.org/rfc/rfc793.txt.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c>, and <c>dwRemotePort</c> members are in network byte order. In order to use the <c>dwLocalPort</c> or
		/// <c>dwRemotePort</c> members, the ntohs or inet_ntoa functions in Windows Sockets or similar functions may be needed. The
		/// <c>dwLocalAddr</c> and <c>dwRemoteAddr</c> members are stored as a <c>DWORD</c> in the same format as the in_addr structure. In
		/// order to use the <c>dwLocalAddr</c> or <c>dwRemoteAddr</c> members, the ntohl or <c>inet_ntoa</c> functions in Windows Sockets or
		/// similar functions may be needed. On Windows Vista and later, the RtlIpv4AddressToString or RtlIpv4AddressToStringEx functions may
		/// be used to convert the IPv4 address in the <c>dwLocalAddr</c> or <c>dwRemoteAddr</c> members to a string without loading the
		/// Windows Sockets DLL.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed. This structure is defined
		/// in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h header file is automatically included in
		/// Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never
		/// be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcprow_owner_module typedef struct
		// _MIB_TCPROW_OWNER_MODULE { DWORD dwState; DWORD dwLocalAddr; DWORD dwLocalPort; DWORD dwRemoteAddr; DWORD dwRemotePort; DWORD
		// dwOwningPid; LARGE_INTEGER liCreateTimestamp; ULONGLONG OwningModuleInfo[TCPIP_OWNING_MODULE_SIZE]; } MIB_TCPROW_OWNER_MODULE, *PMIB_TCPROW_OWNER_MODULE;
		[PInvokeData("tcpmib.h", MSDNShortId = "5fc1e95a-4ab1-4a15-aedc-47cfd811c035")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPROW_OWNER_MODULE
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>dwState</para>
			/// <para>
			/// <c>Type: <c>DWORD</c></c> The state of the TCP connection. This member can be one of the values defined in the Iprtrmib.h
			/// header file.
			/// </para>
			/// <para>
			/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed. This member can be one
			/// of the values from the <c>MIB_TCP_STATE</c> enumeration defined in the Tcpmib.h header file, not in the Iprtrmib.h header
			/// file. Note that the Tcpmib.h header file is automatically included in Iprtrmib.h, which is automatically included in the
			/// Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never be used directly.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSED 1</term>
			/// <term>The TCP connection is in the CLOSED state that represents no connection state at all.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LISTEN 2</term>
			/// <term>The TCP connection is in the LISTEN state waiting for a connection request from any remote TCP and port.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_SENT 3</term>
			/// <term>
			/// The TCP connection is in the SYN-SENT state waiting for a matching connection request after having sent a connection request
			/// (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_RCVD 4</term>
			/// <term>
			/// The TCP connection is in the SYN-RECEIVED state waiting for a confirming connection request acknowledgment after having both
			/// received and sent a connection request (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_ESTAB 5</term>
			/// <term>
			/// The TCP connection is in the ESTABLISHED state that represents an open connection, data received can be delivered to the
			/// user. This is the normal state for the data transfer phase of the TCP connection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT1 6</term>
			/// <term>
			/// The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP, or an acknowledgment
			/// of the connection termination request previously sent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT2 7</term>
			/// <term>The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSE_WAIT 8</term>
			/// <term>The TCP connection is in the CLOSE-WAIT state waiting for a connection termination request from the local user.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSING 9</term>
			/// <term>
			/// The TCP connection is in the CLOSING state waiting for a connection termination request acknowledgment from the remote TCP.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LAST_ACK 10</term>
			/// <term>
			/// The TCP connection is in the LAST-ACK state waiting for an acknowledgment of the connection termination request previously
			/// sent to the remote TCP (which includes an acknowledgment of its connection termination request).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_TIME_WAIT 11</term>
			/// <term>
			/// The TCP connection is in the TIME-WAIT state waiting for enough time to pass to be sure the remote TCP received the
			/// acknowledgment of its connection termination request.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_DELETE_TCB 12</term>
			/// <term>
			/// The TCP connection is in the delete TCB state that represents the deletion of the Transmission Control Block (TCB), a data
			/// structure used to maintain information on each TCP entry.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIB_TCP_STATE dwState;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The local IPv4 address for the TCP connection on the local computer. A value of zero indicates the listener can accept a
			/// connection on any interface.
			/// </para>
			/// </summary>
			public IN_ADDR dwLocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The local port number in network byte order for the TCP connection on the local computer.</para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The IPv4 address for the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// </summary>
			public IN_ADDR dwRemoteAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The remote port number in network byte order for the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this member has no meaning.
			/// </para>
			/// </summary>
			public uint dwRemotePort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The PID of the process that issued a context bind for this TCP connection.</para>
			/// </summary>
			public uint dwOwningPid;

			/// <summary>
			/// <para>Type: <c>LARGE_INTEGER</c></para>
			/// <para>A FILETIME structure that indicates when the context bind operation that created this TCP link occurred.</para>
			/// <para>NOTE: The Microsoft documentation suggests this is a SYSTEMTIME structure. This is incorrect.</para>
			/// </summary>
			public FILETIME liCreateTimestamp;

			/// <summary>
			/// <para>Type: <c>ULONGLONG[TCPIP_OWNING_MODULE_SIZE]</c></para>
			/// <para>An array of opaque data that contains ownership information.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TCPIP_OWNING_MODULE_SIZE)]
			public ulong[] OwningModuleInfo;
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_TCPROW_OWNER_PID</c> structure contains information that describes an IPv4 TCP connection with IPv4 addresses, ports
		/// used by the TCP connection, and the specific process ID (PID) associated with connection.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>MIB_TCPROW_OWNER_PID</c> structure is returned by a call to GetExtendedTcpTable with the TableClass parameter set to
		/// <c>TCP_TABLE_OWNER_PID_LISTENER</c>, <c>TCP_TABLE_OWNER_PID_CONNECTIONS</c>, or <c>TCP_TABLE_OWNER_PID_ALL</c> from the
		/// TCP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET4</c>.
		/// </para>
		/// <para>
		/// The <c>dwState</c> member indicates the state of the TCP entry in a TCP state diagram. A TCP connection progresses through a
		/// series of states during its lifetime. The states are: LISTEN, SYN-SENT, SYN-RECEIVED, ESTABLISHED, FIN-WAIT-1, FIN-WAIT-2,
		/// CLOSE-WAIT, CLOSING, LAST-ACK, TIME-WAIT, and the fictional state CLOSED. The CLOSED state is fictional because it represents the
		/// state when there is no Transmission Control Block, and therefore, no connection. The TCP protocol is described in RFC 793. For
		/// more information, see http://www.ietf.org/rfc/rfc793.txt.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c>, and <c>dwRemotePort</c> members are in network byte order. In order to use the <c>dwLocalPort</c> or
		/// <c>dwRemotePort</c> members, the ntohs or inet_ntoa functions in Windows Sockets or similar functions may be needed. The
		/// <c>dwLocalAddr</c> and <c>dwRemoteAddr</c> members are stored as a <c>DWORD</c> in the same format as the in_addr structure. In
		/// order to use the <c>dwLocalAddr</c> or <c>dwRemoteAddr</c> members, the ntohl or <c>inet_ntoa</c> functions in Windows Sockets or
		/// similar functions may be needed. On Windows Vista and later, the RtlIpv4AddressToString or RtlIpv4AddressToStringEx functions may
		/// be used to convert the IPv4 address in the <c>dwLocalAddr</c> or <c>dwRemoteAddr</c> members to a string without loading the
		/// Windows Sockets DLL.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed. This structure is defined
		/// in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h header file is automatically included in
		/// Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never
		/// be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcprow_owner_pid typedef struct
		// _MIB_TCPROW_OWNER_PID { DWORD dwState; DWORD dwLocalAddr; DWORD dwLocalPort; DWORD dwRemoteAddr; DWORD dwRemotePort; DWORD
		// dwOwningPid; } MIB_TCPROW_OWNER_PID, *PMIB_TCPROW_OWNER_PID;
		[PInvokeData("tcpmib.h", MSDNShortId = "220b69a4-b372-4eff-8d5a-eca0d39b8af9")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPROW_OWNER_PID
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The state of the TCP connection. This member can be one of the values defined in the Iprtrmib.h header file.</para>
			/// <para>
			/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed. This member can be one
			/// of the values from the <c>MIB_TCP_STATE</c> enumeration defined in the Tcpmib.h header file, not in the Iprtrmib.h header
			/// file. Note that the Tcpmib.h header file is automatically included in Iprtrmib.h, which is automatically included in the
			/// Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never be used directly.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSED 1</term>
			/// <term>The TCP connection is in the CLOSED state that represents no connection state at all.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LISTEN 2</term>
			/// <term>The TCP connection is in the LISTEN state waiting for a connection request from any remote TCP and port.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_SENT 3</term>
			/// <term>
			/// The TCP connection is in the SYN-SENT state waiting for a matching connection request after having sent a connection request
			/// (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_RCVD 4</term>
			/// <term>
			/// The TCP connection is in the SYN-RECEIVED state waiting for a confirming connection request acknowledgment after having both
			/// received and sent a connection request (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_ESTAB 5</term>
			/// <term>
			/// The TCP connection is in the ESTABLISHED state that represents an open connection, data received can be delivered to the
			/// user. This is the normal state for the data transfer phase of the TCP connection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT1 6</term>
			/// <term>
			/// The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP, or an acknowledgment
			/// of the connection termination request previously sent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT2 7</term>
			/// <term>The TCP connection is FIN-WAIT-2 state waiting for a connection termination request from the remote TCP.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSE_WAIT 8</term>
			/// <term>The TCP connection is in the CLOSE-WAIT state waiting for a connection termination request from the local user.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSING 9</term>
			/// <term>
			/// The TCP connection is in the CLOSING state waiting for a connection termination request acknowledgment from the remote TCP.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LAST_ACK 10</term>
			/// <term>
			/// The TCP connection is in the LAST-ACK state waiting for an acknowledgment of the connection termination request previously
			/// sent to the remote TCP (which includes an acknowledgment of its connection termination request).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_TIME_WAIT 11</term>
			/// <term>
			/// The TCP connection is in the TIME-WAIT state waiting for enough time to pass to be sure the remote TCP received the
			/// acknowledgment of its connection termination request.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_DELETE_TCB 12</term>
			/// <term>
			/// The TCP connection is in the delete TCB state that represents the deletion of the Transmission Control Block (TCB), a data
			/// structure used to maintain information on each TCP entry.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIB_TCP_STATE dwState;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The local IPv4 address for the TCP connection on the local computer. A value of zero indicates the listener can accept a
			/// connection on any interface.
			/// </para>
			/// </summary>
			public IN_ADDR dwLocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The local port number in network byte order for the TCP connection on the local computer.</para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The IPv4 address for the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// </summary>
			public IN_ADDR dwRemoteAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The remote port number in network byte order for the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this member has no meaning.
			/// </para>
			/// </summary>
			public uint dwRemotePort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The PID of the process that issued a context bind for this TCP connection.</para>
			/// </summary>
			public uint dwOwningPid;
		}

		/// <summary>
		/// <para>The <c>MIB_TCPROW2</c> structure contains information that describes an IPv4 TCP connection.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The GetTcpTable2 function retrieves the IPv4 TCP connection table on the local computer and returns this information in a
		/// MIB_TCPTABLE2 structure.
		/// </para>
		/// <para>An array of <c>MIB_TCPROW2</c> structures are contained in the <c>MIB_TCPTABLE2</c> structure.</para>
		/// <para>
		/// The <c>dwState</c> member indicates the state of the TCP entry in a TCP state diagram. A TCP connection progresses through a
		/// series of states during its lifetime. The states are: LISTEN, SYN-SENT, SYN-RECEIVED, ESTABLISHED, FIN-WAIT-1, FIN-WAIT-2,
		/// CLOSE-WAIT, CLOSING, LAST-ACK, TIME-WAIT, and the fictional state CLOSED. The CLOSED state is fictional because it represents the
		/// state when there is no Transmission Control Block, and therefore, no connection. The TCP protocol is described in RFC 793. For
		/// more information, see http://www.ietf.org/rfc/rfc793.txt.
		/// </para>
		/// <para>
		/// The <c>dwLocalPort</c>, and <c>dwRemotePort</c> members are in network byte order. In order to use the <c>dwLocalPort</c> or
		/// <c>dwRemotePort</c> members, the ntohs or inet_ntoa functions in Windows Sockets or similar functions may be needed. The
		/// <c>dwLocalAddr</c> and <c>dwRemoteAddr</c> members are stored as a <c>DWORD</c> in the same format as the in_addr structure. In
		/// order to use the <c>dwLocalAddr</c> or <c>dwRemoteAddr</c> members, the ntohl or <c>inet_ntoa</c> functions in Windows Sockets or
		/// similar functions may be needed. On Windows Vista and later, the RtlIpv4AddressToString or RtlIpv4AddressToStringEx functions may
		/// be used to convert the IPv4 address in the <c>dwLocalAddr</c> or <c>dwRemoteAddr</c> members to a string without loading the
		/// Windows Sockets DLL.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the TCP connection table for IPv4 and prints the state of each connection represented as a
		/// <c>MIB_TCPROW2</c> structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcprow2 typedef struct _MIB_TCPROW2 {
		// DWORD dwState; DWORD dwLocalAddr; DWORD dwLocalPort; DWORD dwRemoteAddr; DWORD dwRemotePort; DWORD dwOwningPid;
		// TCP_CONNECTION_OFFLOAD_STATE dwOffloadState; } MIB_TCPROW2, *PMIB_TCPROW2;
		[PInvokeData("tcpmib.h", MSDNShortId = "cff343cd-fe85-4e60-87bd-c1e9833cea38")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPROW2
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The state of the TCP connection. This member can be one of the values defined in the Iprtrmib.h header file.</para>
			/// <para>
			/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed. This member can be one
			/// of the values from the <c>MIB_TCP_STATE</c> enumeration defined in the Tcpmib.h header file, not in the Iprtrmib.h header
			/// file. Note that the Tcpmib.h header file is automatically included in Iprtrmib.h, which is automatically included in the
			/// Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never be used directly.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSED 1</term>
			/// <term>The TCP connection is in the CLOSED state that represents no connection state at all.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LISTEN 2</term>
			/// <term>The TCP connection is in the LISTEN state waiting for a connection request from any remote TCP and port.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_SENT 3</term>
			/// <term>
			/// The TCP connection is in the SYN-SENT state waiting for a matching connection request after having sent a connection request
			/// (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_SYN_RCVD 4</term>
			/// <term>
			/// The TCP connection is in the SYN-RECEIVED state waiting for a confirming connection request acknowledgment after having both
			/// received and sent a connection request (SYN packet).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_ESTAB 5</term>
			/// <term>
			/// The TCP connection is in the ESTABLISHED state that represents an open connection, data received can be delivered to the
			/// user. This is the normal state for the data transfer phase of the TCP connection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT1 6</term>
			/// <term>
			/// The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP, or an acknowledgment
			/// of the connection termination request previously sent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_FIN_WAIT2 7</term>
			/// <term>The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSE_WAIT 8</term>
			/// <term>The TCP connection is in the CLOSE-WAIT state waiting for a connection termination request from the local user.</term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_CLOSING 9</term>
			/// <term>
			/// The TCP connection is in the CLOSING state waiting for a connection termination request acknowledgment from the remote TCP.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_LAST_ACK 10</term>
			/// <term>
			/// The TCP connection is in the LAST-ACK state waiting for an acknowledgment of the connection termination request previously
			/// sent to the remote TCP (which includes an acknowledgment of its connection termination request).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_TIME_WAIT 11</term>
			/// <term>
			/// The TCP connection is in the TIME-WAIT state waiting for enough time to pass to be sure the remote TCP received the
			/// acknowledgment of its connection termination request.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIB_TCP_STATE_DELETE_TCB 12</term>
			/// <term>
			/// The TCP connection is in the delete TCB state that represents the deletion of the Transmission Control Block (TCB), a data
			/// structure used to maintain information on each TCP entry.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIB_TCP_STATE dwState;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The local IPv4 address for the TCP connection on the local computer. A value of zero indicates the listener can accept a
			/// connection on any interface.
			/// </para>
			/// </summary>
			public IN_ADDR dwLocalAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The local port number in network byte order for the TCP connection on the local computer.</para>
			/// <para>
			/// The maximum size of an IP port number is 16 bits, so only the lower 16 bits should be used. The upper 16 bits may contain
			/// uninitialized data.
			/// </para>
			/// </summary>
			public uint dwLocalPort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The IPv4 address for the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this value has no meaning.
			/// </para>
			/// </summary>
			public IN_ADDR dwRemoteAddr;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The remote port number in network byte order for the TCP connection on the remote computer. When the <c>dwState</c> member is
			/// <c>MIB_TCP_STATE_LISTEN</c>, this member has no meaning.
			/// </para>
			/// <para>
			/// The maximum size of an IP port number is 16 bits, so only the lower 16 bits should be used. The upper 16 bits may contain
			/// uninitialized data.
			/// </para>
			/// </summary>
			public uint dwRemotePort;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The PID of the process that issued a context bind for this TCP connection.</para>
			/// </summary>
			public uint dwOwningPid;

			/// <summary>
			/// <para>Type: <c>TCP_CONNECTION_OFFLOAD_STATE</c></para>
			/// <para>
			/// The offload state for this TCP connection. This parameter can be one of the enumeration values for the
			/// TCP_CONNECTION_OFFLOAD_STATE defined in the Tcpmib.h header.
			/// </para>
			/// </summary>
			public TCP_CONNECTION_OFFLOAD_STATE dwOffloadState;
		}

		/// <summary>
		/// <para>The <c>MIB_TCPSTATS</c> structure contains statistics for the TCP protocol running on the local computer.</para>
		/// </summary>
		/// <remarks>
		/// <para>The GetTcpStatistics function returns a pointer to a <c>MIB_TCPSTATS</c> structure.</para>
		/// <para>
		/// The <c>MIB_TCPSTATS</c> structure changed slightly on Windows Vista and later. On Windows Vista and later, the
		/// <c>dwRtoAlgorithm</c> member is replaced by a union that contains the following members.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DWORD dwRtoAlgorithm</term>
		/// <term>The retransmission time-out (RTO) algorithm in use.</term>
		/// </item>
		/// <item>
		/// <term>TCP_RTO_ALGORITHM RtoAlgorithm</term>
		/// <term>
		/// The retransmission time-out (RTO) algorithm in use. This member can be one of the values from the TCP_RTO_ALGORITHM enumeration
		/// type defined in the Tcpmib.h header file. The possible values are the same as those defined for the dwRtoAlgorithm member.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// In the Windows SDK, the version of the structure for use on Windows Vista and later is defined as <c>MIB_TCPSTATS_LH</c>. In the
		/// Windows SDK, the version of this structure to be used on earlier systems including Windows 2000 and later is defined as
		/// <c>MIB_TCPSTATS_W2K</c>. When compiling an application if the target platform is Windows Vista and later (, , or ), the
		/// <c>MIB_TCPSTATS_LH</c> structure is typedefed to the <c>MIB_TCPSTATS</c> structure. When compiling an application if the target
		/// platform is not Windows Vista and later, the <c>MIB_TCPSTATS_W2K</c> structure is typedefed to the <c>MIB_TCPSTATS</c> structure.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcpstats_lh typedef struct
		// _MIB_TCPSTATS_LH { union { DWORD dwRtoAlgorithm; TCP_RTO_ALGORITHM RtoAlgorithm; }; DWORD dwRtoMin; DWORD dwRtoMax; DWORD
		// dwMaxConn; DWORD dwActiveOpens; DWORD dwPassiveOpens; DWORD dwAttemptFails; DWORD dwEstabResets; DWORD dwCurrEstab; DWORD
		// dwInSegs; DWORD dwOutSegs; DWORD dwRetransSegs; DWORD dwInErrs; DWORD dwOutRsts; DWORD dwNumConns; } MIB_TCPSTATS_LH, *PMIB_TCPSTATS_LH;
		[PInvokeData("tcpmib.h", MSDNShortId = "08d85d02-62a0-479d-bf56-5dad452436f3")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPSTATS
		{
			/// <summary>
			/// The retransmission time-out (RTO) algorithm in use. This member can be one of the values from the TCP_RTO_ALGORITHM
			/// enumeration type defined in the Tcpmib.h header file. The possible values are the same as those defined for the
			/// dwRtoAlgorithm member.
			/// </summary>
			public TCP_RTO_ALGORITHM RtoAlgorithm;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The minimum RTO value in milliseconds.</para>
			/// </summary>
			public uint dwRtoMin;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum RTO value in milliseconds.</para>
			/// </summary>
			public uint dwRtoMax;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum number of connections. If this member is -1, the maximum number of connections is variable.</para>
			/// </summary>
			public uint dwMaxConn;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of active opens. In an active open, the client is initiating a connection with the server.</para>
			/// </summary>
			public uint dwActiveOpens;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of passive opens. In a passive open, the server is listening for a connection request from a client.</para>
			/// </summary>
			public uint dwPassiveOpens;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of failed connection attempts.</para>
			/// </summary>
			public uint dwAttemptFails;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of established connections that were reset.</para>
			/// </summary>
			public uint dwEstabResets;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of currently established connections.</para>
			/// </summary>
			public uint dwCurrEstab;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of segments received.</para>
			/// </summary>
			public uint dwInSegs;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of segments transmitted. This number does not include retransmitted segments.</para>
			/// </summary>
			public uint dwOutSegs;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of segments retransmitted.</para>
			/// </summary>
			public uint dwRetransSegs;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of errors received.</para>
			/// </summary>
			public uint dwInErrs;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of segments transmitted with the reset flag set.</para>
			/// </summary>
			public uint dwOutRsts;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of connections that are currently present in the system. This total number includes connections in all states
			/// except listening connections.
			/// </para>
			/// </summary>
			public uint dwNumConns;
		}

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>
		/// The <c>MIB_TCPSTATS2</c> structure contains statistics for the TCP protocol running on the local computer. This structure is
		/// different from MIB_TCPSTATS structure in that it uses 64-bit counters, rather than 32-bit counters.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The GetTcpStatisticsEx2 function returns a pointer to a <c>MIB_TCPSTATS2</c> structure.</para>
		/// <para>
		/// This structure is defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h header file is
		/// automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h
		/// header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcpstats2 typedef struct
		// _MIB_TCPSTATS2 { TCP_RTO_ALGORITHM RtoAlgorithm; DWORD dwRtoMin; DWORD dwRtoMax; DWORD dwMaxConn; DWORD dwActiveOpens; DWORD
		// dwPassiveOpens; DWORD dwAttemptFails; DWORD dwEstabResets; DWORD dwCurrEstab; DWORD64 dw64InSegs; DWORD64 dw64OutSegs; DWORD
		// dwRetransSegs; DWORD dwInErrs; DWORD dwOutRsts; DWORD dwNumConns; } MIB_TCPSTATS2, *PMIB_TCPSTATS2;
		[PInvokeData("tcpmib.h", MSDNShortId = "A32AA866-406B-4BE0-A4F1-5EBC9DFD646D")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPSTATS2
		{
			/// <summary>
			/// The retransmission time-out (RTO) algorithm in use. This member can be one of the values from the TCP_RTO_ALGORITHM
			/// enumeration type defined in the Tcpmib.h header file. The possible values are the same as those defined for the
			/// dwRtoAlgorithm member.
			/// </summary>
			public TCP_RTO_ALGORITHM RtoAlgorithm;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The minimum RTO value in milliseconds.</para>
			/// </summary>
			public uint dwRtoMin;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum RTO value in milliseconds.</para>
			/// </summary>
			public uint dwRtoMax;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum number of connections. If this member is -1, the maximum number of connections is variable.</para>
			/// </summary>
			public uint dwMaxConn;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of active opens. In an active open, the client is initiating a connection with the server.</para>
			/// </summary>
			public uint dwActiveOpens;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of passive opens. In a passive open, the server is listening for a connection request from a client.</para>
			/// </summary>
			public uint dwPassiveOpens;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of failed connection attempts.</para>
			/// </summary>
			public uint dwAttemptFails;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of established connections that were reset.</para>
			/// </summary>
			public uint dwEstabResets;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of currently established connections.</para>
			/// </summary>
			public uint dwCurrEstab;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of segments received.</para>
			/// </summary>
			public ulong dw64InSegs;

			/// <summary>
			/// <para>Type: <c>DWORD64</c></para>
			/// <para>The number of segments transmitted. This number does not include retransmitted segments.</para>
			/// </summary>
			public ulong dw64OutSegs;

			/// <summary>
			/// <para>Type: <c>DWORD64</c></para>
			/// <para>The number of segments retransmitted.</para>
			/// </summary>
			public uint dwRetransSegs;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of errors received.</para>
			/// </summary>
			public uint dwInErrs;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of segments transmitted with the reset flag set.</para>
			/// </summary>
			public uint dwOutRsts;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of connections that are currently present in the system. This total number includes connections in all states
			/// except listening connections.
			/// </para>
			/// </summary>
			public uint dwNumConns;
		}

		/// <summary>The <c>MIB_TCP6TABLE</c> structure contains a table of TCP connections for IPv6 on the local computer.</summary>
		[PInvokeData("tcpmib.h", MSDNShortId = "aa814506")]
		[CorrespondingType(typeof(MIB_TCP6ROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCP6TABLE : SafeElementArray<MIB_TCP6ROW, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_TCP6TABLE"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_TCP6TABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>A value that specifies the number of TCP connections in the array.</summary>
			public uint dwNumEntries => Count;

			/// <summary>An array of <c>MIB_TCP6ROW</c> structures containing TCP connection entries.</summary>
			public MIB_TCP6ROW[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_TCP6TABLE"/> to <see cref="System.IntPtr"/>.</summary>
			/// <param name="table">The MIB_TCP6TABLE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_TCP6TABLE table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_TCP6TABLE_OWNER_MODULE</c> structure contains a table of process IDs (PIDs) and the IPv6 TCP links context bound to
		/// these PIDs with any available ownership data.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>MIB_TCP6TABLE_OWNER_MODULE</c> structure is returned by a call to GetExtendedTcpTable with the TableClass parameter set to
		/// a <c>TCP_TABLE_OWNER_MODULE_LISTENER</c>, <c>TCP_TABLE_OWNER_MODULE_CONNECTIONS</c>, or <c>TCP_TABLE_OWNER_MODULE_ALL</c> from
		/// the TCP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET6</c>.
		/// </para>
		/// <para>
		/// The <c>MIB_TCP6TABLE_OWNER_MODULE</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the
		/// first MIB_TCP6ROW_OWNER_MODULE array entry in the <c>table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_TCP6ROW_OWNER_MODULE</c> array entries in the <c>table</c> member. Any access to a <c>MIB_TCP6ROW_OWNER_MODULE</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcp6table_owner_module typedef struct
		// _MIB_TCP6TABLE_OWNER_MODULE { DWORD dwNumEntries; MIB_TCP6ROW_OWNER_MODULE table[ANY_SIZE]; } MIB_TCP6TABLE_OWNER_MODULE, *PMIB_TCP6TABLE_OWNER_MODULE;
		[PInvokeData("tcpmib.h", MSDNShortId = "aa52531c-1d4e-44f9-8638-1528beb491f3")]
		[CorrespondingType(typeof(MIB_TCP6ROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCP6TABLE_OWNER_MODULE : SafeElementArray<MIB_TCP6ROW_OWNER_MODULE, ulong, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_TCP6TABLE_OWNER_MODULE"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_TCP6TABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of MIB_TCP6ROW_OWNER_MODULE elements in the <c>table</c>.</para>
			/// </summary>
			public uint dwNumEntries => (uint)Count;

			/// <summary>
			/// <para>Array of MIB_TCP6ROW_OWNER_MODULE structures returned by a call to GetExtendedTcpTable.</para>
			/// </summary>
			public MIB_TCP6ROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_TCP6TABLE_OWNER_MODULE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_TCP6TABLE_OWNER_MODULE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_TCP6TABLE_OWNER_MODULE table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_TCP6TABLE_OWNER_PID</c> structure contains a table of process IDs (PIDs) and the IPv6 TCP links that are context bound
		/// to these PIDs.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>MIB_TCP6TABLE_OWNER_PID</c> structure is returned by a call to GetExtendedTcpTable with the TableClass parameter set to
		/// <c>TCP_TABLE_OWNER_PID_LISTENER</c>, <c>TCP_TABLE_OWNER_PID_CONNECTIONS</c>, or <c>TCP_TABLE_OWNER_PID_ALL</c> from the
		/// TCP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET6</c>.
		/// </para>
		/// <para>
		/// The <c>MIB_TCP6TABLE_OWNER_PID</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the
		/// first MIB_TCP6ROW_OWNER_PID array entry in the <c>table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_TCP6ROW_OWNER_PID</c> array entries in the <c>table</c> member. Any access to a <c>MIB_TCP6ROW_OWNER_PID</c> array entry
		/// should assume padding may exist.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcp6table_owner_pid typedef struct
		// _MIB_TCP6TABLE_OWNER_PID { DWORD dwNumEntries; MIB_TCP6ROW_OWNER_PID table[ANY_SIZE]; } MIB_TCP6TABLE_OWNER_PID, *PMIB_TCP6TABLE_OWNER_PID;
		[PInvokeData("tcpmib.h", MSDNShortId = "93629d1d-e5f2-4ae8-b585-17e39ae4986d")]
		[CorrespondingType(typeof(MIB_TCP6ROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCP6TABLE_OWNER_PID : SafeElementArray<MIB_TCP6ROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_TCP6TABLE_OWNER_PID"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_TCP6TABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of MIB_TCP6ROW_OWNER_PID elements in the <c>table</c>.</para>
			/// </summary>
			public uint dwNumEntries => Count;

			/// <summary>
			/// <para>Array of MIB_TCP6ROW_OWNER_PID structures returned by a call to GetExtendedTcpTable.</para>
			/// </summary>
			public MIB_TCP6ROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_TCP6TABLE_OWNER_PID"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_TCP6TABLE_OWNER_PID instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_TCP6TABLE_OWNER_PID table) => table.DangerousGetHandle();
		}

		/// <summary>The <c>MIB_TCP6TABLE2</c> structure contains a table of IPv6 TCP connections on the local computer.</summary>
		/// <remarks>
		/// <para>The <c>MIB_TCP6TABLE2</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetTcp6Table2function retrieves the IPv6 TCP connection table on the local computer and returns this information in a
		/// <c>MIB_TCP6TABLE2</c> structure.
		/// </para>
		/// <para>An array of MIB_TCP6ROW2 structures are contained in the <c>MIB_TCP6TABLE2</c> structure.</para>
		/// <para>
		/// The <c>MIB_TCP6TABLE2</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the first
		/// MIB_TCP6ROW2 array entry in the <c>table</c> member. Padding for alignment may also be present between the <c>MIB_TCP6ROW2</c>
		/// array entries in the <c>table</c> member. Any access to a <c>MIB_TCP6ROW2</c> array entry should assume padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcp6table2 typedef struct _MIB_TCP6TABLE2 { DWORD
		// dwNumEntries; MIB_TCP6ROW2 table[ANY_SIZE]; } MIB_TCP6TABLE2, *PMIB_TCP6TABLE2;
		[PInvokeData("tcpmib.h", MSDNShortId = "3cb8568e-ce31-4ed1-aa9e-abcb826c0cea")]
		[CorrespondingType(typeof(MIB_TCP6ROW2))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCP6TABLE2 : SafeElementArray<MIB_TCP6ROW2, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_TCP6TABLE2"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_TCP6TABLE2(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>A value that specifies the number of TCP connections in the array.</summary>
			public uint dwNumEntries => Count;

			/// <summary>An array of MIB_TCP6ROW2 structures containing TCP connection entries.</summary>
			public MIB_TCP6ROW2[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_TCP6TABLE2"/> to <see cref="System.IntPtr"/>.</summary>
			/// <param name="table">The MIB_TCP6TABLE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_TCP6TABLE2 table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>The <c>MIB_TCPTABLE</c> structure contains a table of TCP connections for IPv4 on the local computer.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The GetTcpTable function retrieves the IPv4 TCP connection table on the local computer and returns this information in a
		/// <c>MIB_TCPTABLE</c> structure. An array of MIB_TCPROW structures are contained in the <c>MIB_TCPTABLE</c> structure.
		/// </para>
		/// <para>
		/// The <c>MIB_TCPTABLE</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the first
		/// MIB_TCPROW array entry in the <c>table</c> member. Padding for alignment may also be present between the <c>MIB_TCPROW</c> array
		/// entries in the <c>table</c> member. Any access to a <c>MIB_TCPROW</c> array entry should assume padding may exist.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the TCP connection table for IPv4 as a <c>MIB_TCPTABLE</c> structure and prints the state of each
		/// connection represented as a MIB_TCPROW structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcptable typedef struct _MIB_TCPTABLE
		// { DWORD dwNumEntries; MIB_TCPROW table[ANY_SIZE]; } MIB_TCPTABLE, *PMIB_TCPTABLE;
		[PInvokeData("tcpmib.h", MSDNShortId = "a8ed8ac2-a72f-4099-ac99-a8b0b77b7b84")]
		[CorrespondingType(typeof(MIB_TCPROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE : SafeElementArray<MIB_TCPROW, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_TCPTABLE"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_TCPTABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of entries in the table.</para>
			/// </summary>
			public uint dwNumEntries => Count;

			/// <summary>
			/// <para>A pointer to a table of TCP connections implemented as an array of MIB_TCPROW structures.</para>
			/// </summary>
			public MIB_TCPROW[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_TCPTABLE"/> to <see cref="System.IntPtr"/>.</summary>
			/// <param name="table">The MIB_TCPTABLE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_TCPTABLE table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_TCPTABLE_OWNER_MODULE</c> structure contains a table of process IDs (PIDs) and the IPv4 TCP links context bound to the
		/// PIDs, and any available ownership data.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This table is specifically returned by a call to GetExtendedTcpTable with the TableClass parameter set to a
		/// <c>TCP_TABLE_OWNER_MODULE_*</c> value from the TCP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET4</c>.
		/// </para>
		/// <para>
		/// The <c>MIB_TCPTABLE_OWNER_MODULE</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the
		/// first MIB_TCPROW_OWNER_MODULE array entry in the <c>table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_TCPROW_OWNER_MODULE</c> array entries in the <c>table</c> member. Any access to a <c>MIB_TCPROW_OWNER_MODULE</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcptable_owner_module typedef struct
		// _MIB_TCPTABLE_OWNER_MODULE { DWORD dwNumEntries; MIB_TCPROW_OWNER_MODULE table[ANY_SIZE]; } MIB_TCPTABLE_OWNER_MODULE, *PMIB_TCPTABLE_OWNER_MODULE;
		[PInvokeData("tcpmib.h", MSDNShortId = "d44c9d82-906b-43ea-8edd-cf973864668d")]
		[CorrespondingType(typeof(MIB_TCPROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE_OWNER_MODULE : SafeElementArray<MIB_TCPROW_OWNER_MODULE, ulong, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_TCPTABLE_OWNER_MODULE"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_TCPTABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of MIB_TCPROW_OWNER_MODULE elements in the <c>table</c>.</para>
			/// </summary>
			public uint dwNumEntries => (uint)Count;

			/// <summary>
			/// <para>Array of MIB_TCPROW_OWNER_MODULE structures returned by a call to GetExtendedTcpTable.</para>
			/// </summary>
			public MIB_TCPROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_TCPTABLE_OWNER_MODULE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_TCPTABLE_OWNER_MODULE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_TCPTABLE_OWNER_MODULE table) => table.DangerousGetHandle();
		}

		/// <summary>
		/// <para>
		/// The <c>MIB_TCPTABLE_OWNER_PID</c> structure contains a table of process IDs (PIDs) and the IPv4 TCP links that are context bound
		/// to these PIDs.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This table is specifically returned by a call to GetExtendedTcpTable with the TableClass parameter set to a
		/// <c>TCP_TABLE_OWNER_PID_*</c> value from the TCP_TABLE_CLASS enumeration and the ulAf parameter set to <c>AF_INET4</c>.
		/// </para>
		/// <para>
		/// The <c>MIB_TCPTABLE_OWNER_PID</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the
		/// first MIB_TCPROW_OWNER_PID array entry in the <c>table</c> member. Padding for alignment may also be present between the
		/// <c>MIB_TCPROW_OWNER_PID</c> array entries in the <c>table</c> member. Any access to a <c>MIB_TCPROW_OWNER_PID</c> array entry
		/// should assume padding may exist.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed. This structure is defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h
		/// header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcptable_owner_pid typedef struct
		// _MIB_TCPTABLE_OWNER_PID { DWORD dwNumEntries; MIB_TCPROW_OWNER_PID table[ANY_SIZE]; } MIB_TCPTABLE_OWNER_PID, *PMIB_TCPTABLE_OWNER_PID;
		[PInvokeData("tcpmib.h", MSDNShortId = "ef39b832-1f22-468a-8734-c7d9bd3ac965")]
		[CorrespondingType(typeof(MIB_TCPROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE_OWNER_PID : SafeElementArray<MIB_TCPROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_TCPTABLE_OWNER_PID"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_TCPTABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>The number of MIB_TCPROW_OWNER_PID elements in the <c>table</c>.</para>
			/// </summary>
			public uint dwNumEntries => Count;

			/// <summary>
			/// <para>Array of MIB_TCPROW_OWNER_PID structures returned by a call to GetExtendedTcpTable.</para>
			/// </summary>
			public MIB_TCPROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_TCPTABLE_OWNER_PID"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The MIB_TCPTABLE_OWNER_PID instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_TCPTABLE_OWNER_PID table) => table.DangerousGetHandle();
		}

		/// <summary>The <c>MIB_TCPTABLE2</c> structure contains a table of IPv4 TCP connections on the local computer.</summary>
		/// <remarks>
		/// <para>
		/// The GetTcpTable2function retrieves the IPv4 TCP connection table on the local computer and returns this information in a
		/// <c>MIB_TCPTABLE2</c> structure. An array of MIB_TCPROW2 structures are contained in the <c>MIB_TCPTABLE2</c> structure.
		/// </para>
		/// <para>
		/// The <c>MIB_TCPTABLE2</c> structure may contain padding for alignment between the <c>dwNumEntries</c> member and the first
		/// MIB_TCPROW2 array entry in the <c>table</c> member. Padding for alignment may also be present between the <c>MIB_TCPROW2</c>
		/// array entries in the <c>table</c> member. Any access to a <c>MIB_TCPROW2</c> array entry should assume padding may exist.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the TCP connection table for IPv4 as a <c>MIB_TCPTABLE2</c> structure prints the state of each
		/// connection represented as a MIB_TCPROW2 structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpmib/ns-tcpmib-_mib_tcptable2 typedef struct _MIB_TCPTABLE2 { DWORD
		// dwNumEntries; MIB_TCPROW2 table[ANY_SIZE]; } MIB_TCPTABLE2, *PMIB_TCPTABLE2;
		[PInvokeData("tcpmib.h", MSDNShortId = "e07de994-0bd5-4d18-9012-8ff191dd6939")]
		[CorrespondingType(typeof(MIB_TCPROW2))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE2 : SafeElementArray<MIB_TCPROW2, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_TCPTABLE2"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public MIB_TCPTABLE2(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>The number of entries in the table.</summary>
			public uint dwNumEntries => Count;

			/// <summary>
			/// <para>A pointer to a table of TCP connections implemented as an array of MIB_TCPROW2 structures.</para>
			/// </summary>
			public MIB_TCPROW2[] table { get => Elements; set => Elements = value; }

			/// <summary>Performs an implicit conversion from <see cref="MIB_TCPTABLE2"/> to <see cref="System.IntPtr"/>.</summary>
			/// <param name="table">The MIB_TCPTABLE instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(MIB_TCPTABLE2 table) => table.DangerousGetHandle();
		}
	}
}