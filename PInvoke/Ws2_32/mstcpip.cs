#pragma warning disable IDE1006 // Naming Styles


namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from ws2_32.h.</summary>
public static partial class Ws2_32
{
	public static readonly uint SIO_ABSORB_RTRALERT = _WSAIOW(IOC_VENDOR, 5);
	public static readonly uint SIO_ACQUIRE_PORT_RESERVATION = _WSAIOW(IOC_VENDOR, 100);
	public static readonly uint SIO_APPLY_TRANSPORT_SETTING = _WSAIOW(IOC_VENDOR, 19);
	public static readonly uint SIO_ASSOCIATE_PORT_RESERVATION = _WSAIOW(IOC_VENDOR, 102);
	public static readonly uint SIO_CPU_AFFINITY = _WSAIOW(IOC_VENDOR, 21);
	public static readonly uint SIO_DELETE_PEER_TARGET_NAME = _WSAIOW(IOC_VENDOR, 203);
	public static readonly uint SIO_GET_TX_TIMESTAMP = _WSAIOW(IOC_VENDOR, 234);
	public static readonly uint SIO_INDEX_ADD_MCAST = _WSAIOW(IOC_VENDOR, 10);
	public static readonly uint SIO_INDEX_BIND = _WSAIOW(IOC_VENDOR, 8);
	public static readonly uint SIO_INDEX_DEL_MCAST = _WSAIOW(IOC_VENDOR, 11);
	public static readonly uint SIO_INDEX_MCASTIF = _WSAIOW(IOC_VENDOR, 9);
	public static readonly uint SIO_KEEPALIVE_VALS = _WSAIOW(IOC_VENDOR, 4);
	public static readonly uint SIO_LIMIT_BROADCASTS = _WSAIOW(IOC_VENDOR, 7);
	public static readonly uint SIO_LOOPBACK_FAST_PATH = _WSAIOW(IOC_VENDOR, 16);
	public static readonly uint SIO_PRIORITY_HINT = SIO_SET_PRIORITY_HINT;
	public static readonly uint SIO_QUERY_RSS_SCALABILITY_INFO = _WSAIOR(IOC_VENDOR, 210);
	public static readonly uint SIO_QUERY_SECURITY = _WSAIORW(IOC_VENDOR, 201);
	public static readonly uint SIO_QUERY_TRANSPORT_SETTING = _WSAIOW(IOC_VENDOR, 20);
	public static readonly uint SIO_QUERY_WFP_ALE_ENDPOINT_HANDLE = _WSAIOR(IOC_VENDOR, 205);
	public static readonly uint SIO_QUERY_WFP_CONNECTION_REDIRECT_CONTEXT = _WSAIOW(IOC_VENDOR, 221);
	public static readonly uint SIO_QUERY_WFP_CONNECTION_REDIRECT_RECORDS = _WSAIOW(IOC_VENDOR, 220);
	public static readonly uint SIO_RCVALL = _WSAIOW(IOC_VENDOR, 1);
	public static readonly uint SIO_RCVALL_IF = _WSAIOW(IOC_VENDOR, 14);
	public static readonly uint SIO_RCVALL_IGMPMCAST = _WSAIOW(IOC_VENDOR, 3);
	public static readonly uint SIO_RCVALL_MCAST = _WSAIOW(IOC_VENDOR, 2);
	public static readonly uint SIO_RCVALL_MCAST_IF = _WSAIOW(IOC_VENDOR, 13);
	public static readonly uint SIO_RELEASE_PORT_RESERVATION = _WSAIOW(IOC_VENDOR, 101);
	public static readonly uint SIO_SET_PEER_TARGET_NAME = _WSAIOW(IOC_VENDOR, 202);
	public static readonly uint SIO_SET_PRIORITY_HINT = _WSAIOW(IOC_VENDOR, 24);
	public static readonly uint SIO_SET_SECURITY = _WSAIOW(IOC_VENDOR, 200);
	public static readonly uint SIO_SET_WFP_CONNECTION_REDIRECT_RECORDS = _WSAIOW(IOC_VENDOR, 222);
	public static readonly uint SIO_SOCKET_USAGE_NOTIFICATION = _WSAIOW(IOC_VENDOR, 204);
	public static readonly uint SIO_TCP_INFO = _WSAIORW(IOC_VENDOR, 39);
	public static readonly uint SIO_TCP_INITIAL_RTO = _WSAIOW(IOC_VENDOR, 17);
	public static readonly uint SIO_TCP_SET_ACK_FREQUENCY = _WSAIOW(IOC_VENDOR, 23);
	public static readonly uint SIO_TCP_SET_ICW = _WSAIOW(IOC_VENDOR, 22);
	public static readonly uint SIO_TIMESTAMPING = _WSAIOW(IOC_VENDOR, 235);
	public static readonly uint SIO_UCAST_IF = _WSAIOW(IOC_VENDOR, 6);

	/// <summary>
	/// The CONTROL_CHANNEL_TRIGGER_STATUS enumeration specifies the status from a query for the <c>REAL_TIME_NOTIFICATION_CAPABILITY</c>
	/// transport setting for a TCP socket that is used with ControlChannelTrigger to receive background network notifications in a
	/// Windows Store app.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The CONTROL_CHANNEL_TRIGGER_STATUS structure is supported on Windows 8, and Windows Server 2012, and later versions of the
	/// operating system.
	/// </para>
	/// <para>
	/// A CONTROL_CHANNEL_TRIGGER_STATUS enumeration value is returned as output from the SIO_QUERY_TRANSPORT_SETTING IOCTL to a query
	/// the <c>REAL_TIME_NOTIFICATION_CAPABILITY</c> transport setting for a TCP socket that is used with ControlChannelTrigger to
	/// receive background network notifications in a Windows Store app.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ne-mstcpip-control_channel_trigger_status typedef enum {
	// CONTROL_CHANNEL_TRIGGER_STATUS_INVALID = 0, CONTROL_CHANNEL_TRIGGER_STATUS_SOFTWARE_SLOT_ALLOCATED = 1,
	// CONTROL_CHANNEL_TRIGGER_STATUS_HARDWARE_SLOT_ALLOCATED = 2, CONTROL_CHANNEL_TRIGGER_STATUS_POLICY_ERROR = 3,
	// CONTROL_CHANNEL_TRIGGER_STATUS_SYSTEM_ERROR = 4, CONTROL_CHANNEL_TRIGGER_STATUS_TRANSPORT_DISCONNECTED = 5,
	// CONTROL_CHANNEL_TRIGGER_STATUS_SERVICE_UNAVAILABLE = 6 } CONTROL_CHANNEL_TRIGGER_STATUS, *PCONTROL_CHANNEL_TRIGGER_STATUS;
	[PInvokeData("mstcpip.h", MSDNShortId = "NE:mstcpip.__unnamed_enum_0")]
	public enum CONTROL_CHANNEL_TRIGGER_STATUS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Status is invalid.</para>
		/// </summary>
		CONTROL_CHANNEL_TRIGGER_STATUS_INVALID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>A software slot was allocated for the</para>
		/// <para>ControlChannelTrigger</para>
		/// <para>.</para>
		/// </summary>
		CONTROL_CHANNEL_TRIGGER_STATUS_SOFTWARE_SLOT_ALLOCATED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>A hardware slot was allocated for the</para>
		/// <para>ControlChannelTrigger</para>
		/// <para>.</para>
		/// </summary>
		CONTROL_CHANNEL_TRIGGER_STATUS_HARDWARE_SLOT_ALLOCATED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>A status policy error.</para>
		/// </summary>
		CONTROL_CHANNEL_TRIGGER_STATUS_POLICY_ERROR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>A status system error.</para>
		/// </summary>
		CONTROL_CHANNEL_TRIGGER_STATUS_SYSTEM_ERROR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The TCP transport is disconnected.</para>
		/// </summary>
		CONTROL_CHANNEL_TRIGGER_STATUS_TRANSPORT_DISCONNECTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Service is unavailable.</para>
		/// </summary>
		CONTROL_CHANNEL_TRIGGER_STATUS_SERVICE_UNAVAILABLE,
	}

	/// <summary>The set of possible security flags for the connection defined in the <c>Mstcpip.h</c> header file.</summary>
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._SOCKET_SECURITY_QUERY_INFO")]
	[Flags]
	public enum SOCKET_INFO_CONNECTION : uint
	{
		/// <summary>If present, traffic is being secured by a security protocol. If absent, the traffic is flowing in the clear.</summary>
		SOCKET_INFO_CONNECTION_SECURED = 0x1,

		/// <summary>
		/// If present, the connection traffic is being encrypted. The <c>SOCKET_INFO_CONNECTION_SECURED</c> flag is always set when this
		/// flag is present.
		/// </summary>
		SOCKET_INFO_CONNECTION_ENCRYPTED = 0x2,

		/// <summary/>
		SOCKET_INFO_CONNECTION_IMPERSONATED = 0x4,
	}

	/// <summary>
	/// The <c>SOCKET_SECURITY_PROTOCOL</c> enumeration indicates the type of security protocol to be used on a socket to secure network traffic.
	/// </summary>
	/// <remarks>
	/// <para>This enumeration is supported on Windows Vista and later.</para>
	/// <para>
	/// Currently, the only type of security protocol that is supported is IPsec. So specifying an enumeration value of
	/// <c>SOCKET_SECURITY_PROTOCOL_DEFAULT</c> has the same effect as specifying <c>SOCKET_SECURITY_PROTOCOL_IPSEC</c>.
	/// </para>
	/// <para>
	/// The <c>SOCKET_SECURITY_PROTOCOL</c> enumeration is used in the SOCKET_PEER_TARGET_NAME, SOCKET_SECURITY_QUERY_INFO,
	/// SOCKET_SECURITY_QUERY_TEMPLATE, SOCKET_SECURITY_SETTINGS, and SOCKET_SECURITY_SETTINGS_IPSEC structures to indicate the type of
	/// security protocol to be used on a socket in the <c>SecurityProtocol</c> member. These structures are used by the
	/// WSAQuerySocketSecurity, WSASetSocketPeerTargetName, and WSASetSocketSecurity functions.
	/// </para>
	/// <para>
	/// In addition to identifying the security protocol, this type is also used to decide how to interpret a pointer passed to some of
	/// the secure socket functions. This is analogous to how the <c>sa_family</c> member of the sockaddr type is used to interpret a
	/// pointer as either <c>sockaddr_in</c> or <c>sockaddr_in6</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ne-mstcpip-socket_security_protocol typedef enum
	// _SOCKET_SECURITY_PROTOCOL { SOCKET_SECURITY_PROTOCOL_DEFAULT, SOCKET_SECURITY_PROTOCOL_IPSEC, SOCKET_SECURITY_PROTOCOL_IPSEC2,
	// SOCKET_SECURITY_PROTOCOL_INVALID } SOCKET_SECURITY_PROTOCOL;
	[PInvokeData("mstcpip.h", MSDNShortId = "NE:mstcpip._SOCKET_SECURITY_PROTOCOL")]
	public enum SOCKET_SECURITY_PROTOCOL
	{
		/// <summary>The default system security will be used.</summary>
		SOCKET_SECURITY_PROTOCOL_DEFAULT,

		/// <summary>IPsec will be used.</summary>
		SOCKET_SECURITY_PROTOCOL_IPSEC,

		/// <summary/>
		SOCKET_SECURITY_PROTOCOL_IPSEC2,

		/// <summary>
		/// <para>The maximum possible value for the</para>
		/// <para>SOCKET_SECURITY_PROTOCOL</para>
		/// <para>enumeration type. This is not a legal value.</para>
		/// </summary>
		SOCKET_SECURITY_PROTOCOL_INVALID,
	}

	/// <summary>A set of flags that allow applications to set specific security requirements on a socket.</summary>
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._SOCKET_SECURITY_SETTINGS")]
	[Flags]
	public enum SOCKET_SETTINGS : uint
	{
		/// <summary>
		/// Indicates that guaranteed encryption of traffic is required. This flag should be set if the default policy prefers methods of
		/// protection that do not use encryption. If this flag is set and encryption is not possible for any reason, no packets will be
		/// sent and a connection will not be established.
		/// </summary>
		SOCKET_SETTINGS_GUARANTEE_ENCRYPTION = 0x1,

		/// <summary>
		/// Indicates that clear text connections are allowed. If this flag is set, some or all of the sent packets will be sent in clear
		/// text, especially if security with the peer could not be negotiated.
		/// </summary>
		SOCKET_SETTINGS_ALLOW_INSECURE = 0x2,
	}

	/// <summary>Flags for IPsec security settings.</summary>
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._SOCKET_SECURITY_SETTINGS_IPSEC")]
	[Flags]
	public enum SOCKET_SETTINGS_IPSEC : uint
	{
		/// <summary>
		/// When this flag is set, IPsec filter instantiation is omitted for the socket. This flag should be set when an application
		/// knows that IPsec filters and policy already exist for its traffic. Applications running on a domain with IPsec policy in
		/// place can also set this flag.
		/// </summary>
		SOCKET_SETTINGS_IPSEC_SKIP_FILTER_INSTANTIATION = 0x1,

		/// <summary/>
		SOCKET_SETTINGS_IPSEC_OPTIONAL_PEER_NAME_VERIFICATION = 0x2,

		/// <summary/>
		SOCKET_SETTINGS_IPSEC_ALLOW_FIRST_INBOUND_PKT_UNENCRYPTED = 0x4,

		/// <summary/>
		SOCKET_SETTINGS_IPSEC_PEER_NAME_IS_RAW_FORMAT = 0x8,
	}

	/// <summary>The Windows Sockets <c>SOCKET_USAGE_TYPE</c> enumeration is used to specified the usage type for the socket.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ne-mstcpip-socket_usage_type typedef enum _SOCKET_USAGE_TYPE {
	// SYSTEM_CRITICAL_SOCKET = 1 } SOCKET_USAGE_TYPE;
	[PInvokeData("mstcpip.h", MSDNShortId = "NE:mstcpip._SOCKET_USAGE_TYPE")]
	public enum SOCKET_USAGE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The usage type is critical to the system.</para>
		/// </summary>
		SYSTEM_CRITICAL_SOCKET = 1,
	}

	/// <summary>
	/// The Windows Sockets <c>TCPSTATE</c> enumeration indicates the possible states of a Transmission Control Protocol (TCP) connection.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A TCP connection progresses from one state to another in response to events. The events are the user calls OPEN, SEND, RECEIVE,
	/// CLOSE, ABORT, and STATUS; the incoming segments, particularly those containing the SYN, ACK, RST and FIN flags; and timeouts.
	/// </para>
	/// <para>For more information about TCP connection states, see RFC 793.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ne-mstcpip-tcpstate typedef enum _TCPSTATE { TCPSTATE_CLOSED,
	// TCPSTATE_LISTEN, TCPSTATE_SYN_SENT, TCPSTATE_SYN_RCVD, TCPSTATE_ESTABLISHED, TCPSTATE_FIN_WAIT_1, TCPSTATE_FIN_WAIT_2,
	// TCPSTATE_CLOSE_WAIT, TCPSTATE_CLOSING, TCPSTATE_LAST_ACK, TCPSTATE_TIME_WAIT, TCPSTATE_MAX } TCPSTATE;
	[PInvokeData("mstcpip.h", MSDNShortId = "NE:mstcpip._TCPSTATE")]
	public enum TCPSTATE
	{
		/// <summary>
		/// <para>
		/// The TCP connection has no connection state at all. This state represents the state when there is no Transmission Control
		/// Block (TCB), and therefore,
		/// </para>
		/// <para>no connection.</para>
		/// </summary>
		TCPSTATE_CLOSED,

		/// <summary>
		/// <para>The TCP connection is waiting for a connection request from any remote</para>
		/// <para>TCP and port.</para>
		/// </summary>
		TCPSTATE_LISTEN,

		/// <summary>
		/// <para>-The TCP connection is waiting for a matching connection request</para>
		/// <para>after sending a connection request.</para>
		/// </summary>
		TCPSTATE_SYN_SENT,

		/// <summary>
		/// <para>The TCP connection is waiting for an acknowledgment that confirms the connection</para>
		/// <para>request after both receiving and sending a</para>
		/// <para>connection request.</para>
		/// </summary>
		TCPSTATE_SYN_RCVD,

		/// <summary>
		/// <para>The TCP connection is an open connection, so the data received can be</para>
		/// <para>delivered to the user. This state is normal state for the data transfer phase</para>
		/// <para>of the connection.</para>
		/// </summary>
		TCPSTATE_ESTABLISHED,

		/// <summary>
		/// <para>The TCP connection is waiting for a request to end the connection</para>
		/// <para>from the remote TCP, or an acknowledgment of the previously sent request to end the connection.</para>
		/// </summary>
		TCPSTATE_FIN_WAIT_1,

		/// <summary>
		/// <para>The TCP connection is waiting for a request to end the connection</para>
		/// <para>from the remote TCP.</para>
		/// </summary>
		TCPSTATE_FIN_WAIT_2,

		/// <summary>
		/// <para>The TCP connection is waiting for a request to end the connection</para>
		/// <para>from the local user.</para>
		/// </summary>
		TCPSTATE_CLOSE_WAIT,

		/// <summary>The TCP connection is waiting for an acknowledgment of the request to end the connection from the remote TCP.</summary>
		TCPSTATE_CLOSING,

		/// <summary>
		/// The TCP connection is waiting for an acknowledgment of the request to end the connection that was previously sent to the
		/// remote TCP, which includes an acknowledgment of its request to end the connection.
		/// </summary>
		TCPSTATE_LAST_ACK,

		/// <summary>
		/// <para>The TCP connection is waiting for enough time to pass to be sure</para>
		/// <para>the remote TCP received the acknowledgment of its request to end the connection.</para>
		/// </summary>
		TCPSTATE_TIME_WAIT,

		/// <summary>
		/// <para>The maximum value of the</para>
		/// <para>TCPSTATE</para>
		/// <para>enumeration.</para>
		/// </summary>
		TCPSTATE_MAX,
	}

	/// <summary>Enable/disable timestamp reception for rx/tx direction.</summary>
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._TIMESTAMPING_CONFIG")]
	[Flags]
	public enum TIMESTAMPING_FLAG : uint
	{
		/// <summary/>
		TIMESTAMPING_FLAG_RX = 0x1,

		/// <summary/>
		TIMESTAMPING_FLAG_TX = 0x2,
	}

	/// <summary>
	/// The <c>ASSOCIATE_NAMERES_CONTEXT_INPUT</c> structure contains the transport setting ID and handle to a fully qualified domain name.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Generally speaking, you can use <c>ASSOCIATE_NAMERES_CONTEXT_INPUT</c> to enforce policy based on Fully Qualified Domain Name
	/// (FQDN), rather than just IP address. you can do so by retrieving a handle to a FQDN with a call to GetAddrInfoEx, using the
	/// addinfoex4 structure. From there, you can use the handle in <c>ASSOCIATE_NAMERES_CONTEXT_INPUT</c> in a call to WSAIoctl, using
	/// the <c>SIO_APPLY_TRANSPORT_SETTING</c> ioctl.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code describes making a call to GetAddrInfoEx with a addinfoex4 structure to retrieve the handle to a FQDN. the
	/// sample then call WSAIoctl with the <c>ASSOCIATE_NAMERES_CONTEXT_INPUT</c> structure.
	/// </para>
	/// <para>
	/// <code language="cpp"><![CDATA[// 
	/// // Connect to a server using its IPv4 addresses 
	/// // 
	/// 
	/// VOID 
	/// ConnectServer( 
	///     PCWSTR server) 
	/// { 
	///     int iResult; 
	///     PADDRINFOEX4 pResult = NULL; 
	///     ADDRINFOEX3 hints = { 0 }; 
	///     PADDRINFOEX4 pCur = NULL; 
	///     WSADATA wsaData; 
	///     SOCKET connectSocket = INVALID_SOCKET; 
	///     ULONG bytesReturned = 0; 
	///     ASSOCIATE_NAMERES_CONTEXT_INPUT input = { 0 }; 
	///     SOCKADDR_IN clientService; 
	///     wchar_t ipstringbuffer[46]; 
	///     String string; 
	///     DWORD dwRetval; 
	///     //  
	///     //  Initialize Winsock 
	///     // 
	///     iResult = WSAStartup( 
	///         MAKEWORD(2, 2),  
	///         &wsaData); 
	///     if (iResult != 0) { 
	///         printf("WSAStartup failed: %d\n", iResult); 
	///         goto Exit; 
	///     } 
	/// 
	///     //  
	///     // Create a SOCKET for connection 
	///     // 
	///     connectSocket = socket( 
	///         AF_UNSPEC,  
	///         SOCK_STREAM,  
	///         IPPROTO_TCP); 
	///     if (connectSocket == INVALID_SOCKET)  
	///     { 
	///         printf("socket failed: %d\n", WSAGetLastError()); 
	///         goto Exit; 
	///     } 
	/// 
	///     // 
	///     // Do name resolution 
	///     // 
	/// 
	///     hints.ai_family = AF_INET; 
	///     hints.ai_socktype = SOCK_STREAM; 
	///     hints.ai_flags = AI_EXTENDED | AI_FQDN | AI_CANONNAME | AI_RESOLUTION_HANDLE; 
	///     hints.ai_version = ADDRINFOEX_VERSION_4; 
	/// 
	///     dwRetval = GetAddrInfoExW( 
	///         server, 
	///         NULL, 
	///         NS_DNS, 
	///         NULL, 
	///         (const ADDRINFOEXW*)&hints, 
	///         (PADDRINFOEXW*)&pResult, 
	///         NULL, 
	///         NULL, 
	///         NULL, NULL); 
	///     if (dwRetval != 0) { 
	///         printf("GetAddrInfoEx failed with error: %d\n", dwRetval); 
	///         goto Exit; 
	///     } 
	///     input.TransportSettingId.Guid = ASSOCIATE_NAMERES_CONTEXT; 
	///     input.Handle = pResult->ai_resolutionhandle; 
	/// 
	///     // 
	///     // Associate socket with the handle 
	///     // 
	/// 
	///     if (WSAIoctl( 
	///             connectSocket, 
	///             SIO_APPLY_TRANSPORT_SETTING, 
	///             (VOID *)&input, 
	///             sizeof(input), 
	///             NULL, 
	///             0, 
	///             &bytesReturned, 
	///             NULL, 
	///             NULL) == SOCKET_ERROR) 
	///     if (iResult != 0){ 
	///         printf("WSAIoctl failed: %d\n", WSAGetLastError()); 
	///         goto Exit; 
	///     }     
	/// 
	///     // 
	///     // Connect to server 
	///     // 
	/// 
	///     pCur = pResult; 
	///     while (pCur != NULL) 
	///     { 
	///         if (pCur->ai_addr->sa_family == AF_INET) 
	///         { 
	///             clientService = *(const sockaddr_in*)pCur->ai_addr; 
	///             clientService.sin_port = htons(80); 
	///             if (connect( 
	///                 connectSocket, 
	///                 (const SOCKADDR *)&clientService, 
	///                 sizeof(clientService)) == SOCKET_ERROR) 
	///             { 
	///                 printf("connect failed: %d\n", WSAGetLastError()); 
	///                 goto Exit; 
	///             } 
	///         } 
	///         pCur = pCur->ai_next; 
	///     } 
	/// 
	/// Exit: 
	/// 
	///     if (connectSocket != INVALID_SOCKET) 
	///     { 
	///         closesocket(connectSocket); 
	///     } 
	///     if (pResult) 
	///     { 
	///         FreeAddrInfoExW((ADDRINFOEXW*)pResult); 
	///     } 
	///     WSACleanup(); 
	///     return; 
	/// }]]></code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-associate_nameres_context_input typedef struct
	// _ASSOCIATE_NAMERES_CONTEXT_INPUT { TRANSPORT_SETTING_ID TransportSettingId; UINT64 Handle; } ASSOCIATE_NAMERES_CONTEXT_INPUT, *PASSOCIATE_NAMERES_CONTEXT_INPUT;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._ASSOCIATE_NAMERES_CONTEXT_INPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ASSOCIATE_NAMERES_CONTEXT_INPUT
	{
		/// <summary>The transport setting ID.</summary>
		public TRANSPORT_SETTING_ID TransportSettingId;

		/// <summary>Handle to a fully qualified domain name.</summary>
		public ulong Handle;
	}

	/// <summary>
	/// The <c>INET_PORT_RANGE</c> structure provides input data used by the SIO_ACQUIRE_PORT_RESERVATION IOCTL to acquire a runtime
	/// reservation for a block of TCP or UDP ports.
	/// </summary>
	/// <remarks>
	/// <para>The <c>INET_PORT_RANGE</c> structure is supported on Windows Vista and later.</para>
	/// <para>
	/// The <c>INET_PORT_RANGE</c> structure is the datatype passed in the input buffer to the SIO_ACQUIRE_PORT_RESERVATION IOCTL. This
	/// IOCTL is used to acquire a runtime reservation for a block of TCP or UDP ports.
	/// </para>
	/// <para>The <c>INET_PORT_RANGE</c> structure is typedefed to the <c>INET_PORT_RESERVATION</c> structure.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-inet_port_range typedef struct _INET_PORT_RANGE { USHORT
	// StartPort; USHORT NumberOfPorts; } INET_PORT_RANGE, *PINET_PORT_RANGE, INET_PORT_RESERVATION, *PINET_PORT_RESERVATION;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._INET_PORT_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct INET_PORT_RANGE
	{
		/// <summary>
		/// The starting TCP or UDP port number. If this parameter is set to zero, the system will choose a starting TCP or UDP port number.
		/// </summary>
		public ushort StartPort;

		/// <summary>The number of TCP or UDP port numbers to reserve.</summary>
		public ushort NumberOfPorts;
	}

	/// <summary>
	/// The <c>INET_PORT_RESERVATION_INSTANCE</c> structure contains a port reservation and a token for a block of TCP or UDP ports.
	/// </summary>
	/// <remarks>
	/// <para>The <c>INET_PORT_RESERVATION_INSTANCE</c> structure is supported on Windows Vista and later.</para>
	/// <para>
	/// The <c>INET_PORT_RESERVATION_INSTANCE</c> structure is returned by the SIO_ACQUIRE_PORT_RESERVATION IOCTL when acquiring a
	/// runtime reservation for a block of TCP or UDP ports.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-inet_port_reservation_instance typedef struct {
	// INET_PORT_RESERVATION Reservation; INET_PORT_RESERVATION_TOKEN Token; } INET_PORT_RESERVATION_INSTANCE, *PINET_PORT_RESERVATION_INSTANCE;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip.__unnamed_struct_2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct INET_PORT_RESERVATION_INSTANCE
	{
		/// <summary>
		/// <para>A runtime port reservation for a block of TCP or UDP ports.</para>
		/// <para>The INET_PORT_RESERVATION structure is typedefed to the INET_PORT_RANGE structure.</para>
		/// </summary>
		public INET_PORT_RANGE Reservation;

		/// <summary>A port reservation token for a block of TCP or UDP ports.</summary>
		public INET_PORT_RESERVATION_TOKEN Token;
	}

	/// <summary>The <c>INET_PORT_RESERVATION_TOKEN</c> structure contains a port reservation token for a block of TCP or UDP ports.</summary>
	/// <remarks>
	/// <para>The <c>INET_PORT_RESERVATION_TOKEN</c> structure is supported on Windows Vista and later.</para>
	/// <para>
	/// The <c>INET_PORT_RESERVATION_TOKEN</c> structure is used by the SIO_ACQUIRE_PORT_RESERVATION , SIO_ASSOCIATE_PORT_RESERVATION,
	/// and SIO_RELEASE_PORT_RESERVATION Ioctl for TCP or UDP port reservations. The <c>INET_PORT_RESERVATION_TOKEN</c> structure is also
	/// equivalent to the ULONG64 Token parameter used by the CreatePersistentTcpPortReservation, CreatePersistentUdpPortReservation,
	/// DeletePersistentTcpPortReservation, DeletePersistentUdpPortReservation, LookupPersistentTcpPortReservation, and
	/// LookupPersistentUdpPortReservation functions in IP Helper.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-inet_port_reservation_token typedef struct { ULONG64 Token;
	// } INET_PORT_RESERVATION_TOKEN, *PINET_PORT_RESERVATION_TOKEN;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip.__unnamed_struct_1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct INET_PORT_RESERVATION_TOKEN
	{
		/// <summary>A port reservation token for a block of TCP or UDP ports.</summary>
		public ulong Token;
	}

	/// <summary>
	/// The <c>REAL_TIME_NOTIFICATION_SETTING_INPUT</c> structure provides input settings to apply for the
	/// <c>REAL_TIME_NOTIFICATION_CAPABILITY</c> transport setting for a TCP socket that is used with ControlChannelTrigger to receive
	/// background network notifications in a Windows Store app.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>REAL_TIME_NOTIFICATION_SETTING_INPUT</c> structure is supported on Windows 8, and Windows Server 2012, and later versions
	/// of the operating system.
	/// </para>
	/// <para>
	/// If the TRANSPORT_SETTING_ID in the <c>lpvInBuffer</c> parameter passed to the SIO_APPLY_TRANSPORT_SETTING IOCTL has the
	/// <c>Guid</c> member set to <c>REAL_TIME_NOTIFICATION_CAPABILITY</c>, then this is a request to query the real time notification
	/// settings for the TCP socket used with ControlChannelTrigger to receive background network notifications in a Windows Store app.
	/// The <c>lpvInBuffer</c> parameter should point to a <c>REAL_TIME_NOTIFICATION_SETTING_INPUT</c> structure used as input to the
	/// <c>SIO_APPLY_TRANSPORT_SETTING</c> IOCTL to apply the transport setting.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-real_time_notification_setting_input typedef struct
	// _REAL_TIME_NOTIFICATION_SETTING_INPUT { TRANSPORT_SETTING_ID TransportSettingId; GUID BrokerEventGuid; }
	// REAL_TIME_NOTIFICATION_SETTING_INPUT, *PREAL_TIME_NOTIFICATION_SETTING_INPUT;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._REAL_TIME_NOTIFICATION_SETTING_INPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct REAL_TIME_NOTIFICATION_SETTING_INPUT
	{
		/// <summary>The transport setting ID.</summary>
		public TRANSPORT_SETTING_ID TransportSettingId;

		/// <summary>The realtime notification broker event GUID for this transport ID.</summary>
		public Guid BrokerEventGuid;
	}

	/// <summary>
	/// The REAL_TIME_NOTIFICATION_SETTING_OUTPUT structure provides the output settings from a query for the
	/// <c>REAL_TIME_NOTIFICATION_CAPABILITY</c> transport setting for a TCP socket that is used with ControlChannelTrigger to receive
	/// background network notifications in a Windows Store app.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The REAL_TIME_NOTIFICATION_SETTING_OUTPUT structure is supported on Windows 8, and Windows Server 2012, and later versions of the
	/// operating system.
	/// </para>
	/// <para>
	/// If the TRANSPORT_SETTING_ID in the <c>lpvInBuffer</c> parameter passed to the SIO_QUERY_TRANSPORT_SETTING IOCTL has the
	/// <c>Guid</c> member set to <c>REAL_TIME_NOTIFICATION_CAPABILITY</c>, then this is a request to query the real time notification
	/// settings for the TCP socket used with ControlChannelTrigger to receive background network notifications in a Windows Store app.
	/// If the WSAIoctl or LPWSPIoctl call is successful, this IOCTL returns a REAL_TIME_NOTIFICATION_SETTING_OUTPUT structure with the
	/// current status.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-real_time_notification_setting_output typedef struct
	// _REAL_TIME_NOTIFICATION_SETTING_OUTPUT { CONTROL_CHANNEL_TRIGGER_STATUS ChannelStatus; } REAL_TIME_NOTIFICATION_SETTING_OUTPUT, *PREAL_TIME_NOTIFICATION_SETTING_OUTPUT;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._REAL_TIME_NOTIFICATION_SETTING_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct REAL_TIME_NOTIFICATION_SETTING_OUTPUT
	{
		/// <summary>The channel status for a socket that is used with the ControlChannelTrigger.</summary>
		public CONTROL_CHANNEL_TRIGGER_STATUS ChannelStatus;
	}

	/// <summary>
	/// The <c>SOCKET_PEER_TARGET_NAME</c> structure contains the IP address and name for a peer target and the type of security protocol
	/// to be used on a socket.
	/// </summary>
	/// <remarks>
	/// <para>The <c>SOCKET_PEER_TARGET_NAME</c> structure is supported on Windows Vista and later.</para>
	/// <para>
	/// The <c>SOCKET_PEER_TARGET_NAME</c> structure is used by the WSASetSocketPeerTargetName function to specify the peer target name
	/// that corresponds to a peer IP address. This target name is meant to be specified by client applications to securely identify the
	/// peer that should be authenticated.
	/// </para>
	/// <para>
	/// Currently, the only type of security protocol that is supported is IPsec. So specifying an enumeration value of
	/// <c>SOCKET_SECURITY_PROTOCOL_DEFAULT</c> has the same effect as specifying <c>SOCKET_SECURITY_PROTOCOL_IPSEC</c> in the
	/// <c>SecurityProtocol</c> member.
	/// </para>
	/// <para>
	/// The implementation of IPsec on Windows Vista and Windows Server 2008 only supports computer-to-computer and user-to-computer
	/// authentication. As a result, the peer target name specified in the <c>AllStrings</c> member of the <c>SOCKET_PEER_TARGET_NAME</c>
	/// structure should refer to the peer computer principal.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-socket_peer_target_name typedef struct
	// _SOCKET_PEER_TARGET_NAME { SOCKET_SECURITY_PROTOCOL SecurityProtocol; SOCKADDR_STORAGE PeerAddress; ULONG PeerTargetNameStringLen;
	// wchar_t AllStrings[0]; } SOCKET_PEER_TARGET_NAME;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._SOCKET_PEER_TARGET_NAME")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SOCKET_PEER_TARGET_NAME
	{
		/// <summary>A SOCKET_SECURITY_PROTOCOL value that identifies the type of protocol used to secure the traffic on the socket.</summary>
		public SOCKET_SECURITY_PROTOCOL SecurityProtocol;

		/// <summary>The IP address of the peer for the socket.</summary>
		public SOCKADDR_STORAGE PeerAddress;

		/// <summary>The length, in bytes, of the peer target name in the <c>AllStrings</c> member.</summary>
		public uint PeerTargetNameStringLen;

		/// <summary>The peer target name for the socket.</summary>
		[MarshalAs(UnmanagedType.LPWStr, SizeConst = 0)]
		public string AllStrings;
	}

	/// <summary>
	/// The <c>SOCKET_SECURITY_QUERY_INFO</c> structure contains security information returned by the WSAQuerySocketSecurity function.
	/// </summary>
	/// <remarks>
	/// <para>The <c>SOCKET_SECURITY_QUERY_INFO</c> structure is supported on Windows Vista and later.</para>
	/// <para>
	/// The <c>SOCKET_SECURITY_QUERY_INFO</c> structure is used by the WSAQuerySocketSecurity function to return information about the
	/// security applied to a connection on a socket.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-socket_security_query_info typedef struct
	// _SOCKET_SECURITY_QUERY_INFO { SOCKET_SECURITY_PROTOCOL SecurityProtocol; ULONG Flags; UINT64 PeerApplicationAccessTokenHandle;
	// UINT64 PeerMachineAccessTokenHandle; } SOCKET_SECURITY_QUERY_INFO;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._SOCKET_SECURITY_QUERY_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SOCKET_SECURITY_QUERY_INFO
	{
		/// <summary>A SOCKET_SECURITY_PROTOCOL value that identifies the protocol used to secure the traffic.</summary>
		public SOCKET_SECURITY_PROTOCOL SecurityProtocol;

		/// <summary>
		/// <para>The set of possible security flags for the connection defined in the <c>Mstcpip.h</c> header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SOCKET_INFO_CONNECTION_SECURED</c> 0x00000001</term>
		/// <term>If present, traffic is being secured by a security protocol. If absent, the traffic is flowing in the clear.</term>
		/// </item>
		/// <item>
		/// <term><c>SOCKET_INFO_CONNECTION_ENCRYPTED</c> 0x00000002</term>
		/// <term>
		/// If present, the connection traffic is being encrypted. The <c>SOCKET_INFO_CONNECTION_SECURED</c> flag is always set when this
		/// flag is present.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SOCKET_INFO_CONNECTION Flags;

		/// <summary>
		/// A handle to the access token that represents the account under which the peer application is running. After using the token
		/// for access checks, the application should close the handle using the CloseHandle function.
		/// </summary>
		public ulong PeerApplicationAccessTokenHandle;

		/// <summary>
		/// A handle to the access token for the peer computer's account during the course of the application. After using the token for
		/// access checks, the application should close the handle using the CloseHandle function.
		/// </summary>
		public ulong PeerMachineAccessTokenHandle;
	}

	/// <summary>
	/// The <c>SOCKET_SECURITY_QUERY_TEMPLATE</c> structure contains the security template used by the WSAQuerySocketSecurity function.
	/// </summary>
	/// <remarks>
	/// <para>The <c>SOCKET_SECURITY_QUERY_TEMPLATE</c> structure is supported on Windows Vista and later.</para>
	/// <para>
	/// The <c>SOCKET_SECURITY_QUERY_TEMPLATE</c> structure is used by the WSAQuerySocketSecurity function to specify the type of query
	/// information to return for a socket. The <c>SOCKET_SECURITY_QUERY_TEMPLATE</c> structure passed to the
	/// <c>WSAQuerySocketSecurity</c> function may contain zeros for all members to request default security information.
	/// </para>
	/// <para>
	/// If the <c>SOCKET_SECURITY_QUERY_TEMPLATE</c> structure is specified with the <c>PeerTokenAccessMask</c> member not specified (set
	/// to zero), then the WSAQuerySocketSecurity function will not return the <c>PeerApplicationAccessTokenHandle</c> and
	/// <c>PeerMachineAccessTokenHandle</c> members in the SOCKET_SECURITY_QUERY_INFO structure.
	/// </para>
	/// <para>
	/// Currently, the only type of security protocol that is supported is IPsec. So specifying an enumeration value of
	/// <c>SOCKET_SECURITY_PROTOCOL_DEFAULT</c> for the <c>SecurityProtocol</c> member has the same effect as specifying <c>SOCKET_SECURITY_PROTOCOL_IPSEC</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-socket_security_query_template typedef struct
	// _SOCKET_SECURITY_QUERY_TEMPLATE { SOCKET_SECURITY_PROTOCOL SecurityProtocol; SOCKADDR_STORAGE PeerAddress; ULONG
	// PeerTokenAccessMask; } SOCKET_SECURITY_QUERY_TEMPLATE;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._SOCKET_SECURITY_QUERY_TEMPLATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SOCKET_SECURITY_QUERY_TEMPLATE
	{
		/// <summary>A SOCKET_SECURITY_PROTOCOL value that identifies the protocol used to secure the traffic.</summary>
		public SOCKET_SECURITY_PROTOCOL SecurityProtocol;

		/// <summary>
		/// The IP address of the peer for which security information is being queried. For connection-oriented sockets (protocol of
		/// <c>IPPROTO_TCP</c>), the connected socket uniquely identifies a peer. In this case, this parameter is ignored.
		/// </summary>
		public SOCKADDR_STORAGE PeerAddress;

		/// <summary>
		/// The access mask used for opening the peer user application and computer token handles that are returned as part of the query information.
		/// </summary>
		public uint PeerTokenAccessMask;
	}

	/// <summary>The <c>SOCKET_SECURITY_SETTINGS</c> structure specifies generic security requirements for a socket.</summary>
	/// <remarks>
	/// <para>The <c>SOCKET_SECURITY_SETTINGS</c> structure is supported on Windows Vista and later.</para>
	/// <para>
	/// The <c>SOCKET_SECURITY_SETTINGS</c> structure is used by the WSASetSocketSecurity function to enable and apply security on a socket.
	/// </para>
	/// <para>
	/// Security settings not addressed in this structure are derived from the system default policy or the administratively configured
	/// policy. It is recommended that most applications specify a value of <c>SOCKET_SECURITY_PROTOCOL_DEFAULT</c> for the
	/// SOCKET_SECURITY_PROTOCOL enumeration in the <c>SecurityProtocol</c> member. This makes the application neutral to security
	/// protocols and allows easier deployments among different systems.
	/// </para>
	/// <para>
	/// Advanced applications can specify a security protocol and associated settings by casting them to the
	/// <c>SOCKET_SECURITY_SETTINGS</c> type.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-socket_security_settings typedef struct
	// _SOCKET_SECURITY_SETTINGS { SOCKET_SECURITY_PROTOCOL SecurityProtocol; ULONG SecurityFlags; } SOCKET_SECURITY_SETTINGS;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._SOCKET_SECURITY_SETTINGS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SOCKET_SECURITY_SETTINGS
	{
		/// <summary>A SOCKET_SECURITY_PROTOCOL value that identifies the type of security protocol to be used on the socket.</summary>
		public SOCKET_SECURITY_PROTOCOL SecurityProtocol;

		/// <summary>
		/// <para>
		/// A set of flags that allow applications to set specific security requirements on a socket. The possible values are defined in
		/// the <c>Mstcpip.h</c> header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SOCKET_SETTINGS_GUARANTEE_ENCRYPTION</c> 0x00000001</term>
		/// <term>
		/// Indicates that guaranteed encryption of traffic is required. This flag should be set if the default policy prefers methods of
		/// protection that do not use encryption. If this flag is set and encryption is not possible for any reason, no packets will be
		/// sent and a connection will not be established.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SOCKET_SETTINGS_ALLOW_INSECURE</c> 0x00000002</term>
		/// <term>
		/// Indicates that clear text connections are allowed. If this flag is set, some or all of the sent packets will be sent in clear
		/// text, especially if security with the peer could not be negotiated.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SOCKET_SETTINGS SecurityFlags;
	}

	/// <summary>
	/// The <c>SOCKET_SECURITY_SETTINGS_IPSEC</c> structure specifies various security requirements and settings that are specific to IPsec.
	/// </summary>
	/// <remarks>
	/// <para>The <c>SOCKET_SECURITY_SETTINGS_IPSEC</c> structure is supported on Windows Vista and later.</para>
	/// <para>
	/// The <c>SOCKET_SECURITY_SETTINGS_IPSEC</c> structure is meant to be used by an advanced application that requires more flexibility
	/// and wishes to customize IPSec policy for their traffic. The pointer to the <c>SOCKET_SECURITY_SETTINGS_IPSEC</c> structure needs
	/// to cast to the SOCKET_SECURITY_SETTINGS structure type when calling the WSASetSocketSecurity function to enable and apply
	/// security on a socket.
	/// </para>
	/// <para>
	/// The <c>SecurityProtocol</c> member of the <c>SOCKET_SECURITY_SETTINGS_IPSEC</c> structure must be set to
	/// <c>SOCKET_SECURITY_PROTOCOL_IPSEC</c>, not <c>SOCKET_SECURITY_PROTOCOL_DEFAULT</c>.
	/// </para>
	/// <para>
	/// To simplify Internet Protocol security (IPsec) deployment, Windows Vista and later support an enhanced version of the Internet
	/// Key Exchange (IKE) protocol known as Authenticated Internet Protocol (AuthIP). AuthIP provides simplified IPsec policy
	/// configuration and maintenance in many configurations and additional flexibility for IPsec peer authentication.
	/// </para>
	/// <para>
	/// There is a possibility that some of the IPsec settings specified in the <c>SOCKET_SECURITY_SETTINGS_IPSEC</c> structure may end
	/// up being different from the actual settings applied to the network traffic on a socket. For example, this could happen when an
	/// application specifies custom main mode or quick mode policy, but a different policy with a higher priority (a domain policy, for
	/// example) specifies conflicting settings for the same traffic. To be aware of such conflicts, an application can use the Windows
	/// Filtering Platform API to query the policy being applied and subscribe for notifications.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-socket_security_settings_ipsec typedef struct
	// _SOCKET_SECURITY_SETTINGS_IPSEC { SOCKET_SECURITY_PROTOCOL SecurityProtocol; ULONG SecurityFlags; ULONG IpsecFlags; GUID
	// AuthipMMPolicyKey; GUID AuthipQMPolicyKey; GUID Reserved; UINT64 Reserved2; ULONG UserNameStringLen; ULONG DomainNameStringLen;
	// ULONG PasswordStringLen; wchar_t AllStrings[0]; } SOCKET_SECURITY_SETTINGS_IPSEC;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._SOCKET_SECURITY_SETTINGS_IPSEC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SOCKET_SECURITY_SETTINGS_IPSEC
	{
		/// <summary>
		/// <para>Type: <c>SOCKET_SECURITY_PROTOCOL</c></para>
		/// <para>
		/// A SOCKET_SECURITY_PROTOCOL value that identifies the type of security protocol to be used on the socket. This member must be
		/// set to <c>SOCKET_SECURITY_PROTOCOL_IPSEC</c>.
		/// </para>
		/// </summary>
		public SOCKET_SECURITY_PROTOCOL SecurityProtocol;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>
		/// A set of flags that allow applications to set specific security requirements on a socket. The possible values are defined in
		/// the <c>Mstcpip.h</c> header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SOCKET_SETTINGS_GUARANTEE_ENCRYPTION</c> 0x00000001</term>
		/// <term>
		/// Indicates that guaranteed encryption of traffic is required. This flag should be set if the default policy prefers methods of
		/// protection that do not use encryption. If this flag is set and encryption is not possible for any reason, no packets will be
		/// sent and a connection will not be established.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SOCKET_SETTINGS_ALLOW_INSECURE</c> 0x00000002</term>
		/// <term>
		/// Indicates that clear text connections are allowed. If this flag is set, some or all of the sent packets will be sent in clear
		/// text, especially if security with the peer could not be negotiated.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SOCKET_SETTINGS SecurityFlags;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Flags for IPsec security settings. The possible values are defined in the <c>Mstcpip.h</c> header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SOCKET_SETTINGS_IPSEC_SKIP_FILTER_INSTANTIATION</c> 0x00000001</term>
		/// <term>
		/// When this flag is set, IPsec filter instantiation is omitted for the socket. This flag should be set when an application
		/// knows that IPsec filters and policy already exist for its traffic. Applications running on a domain with IPsec policy in
		/// place can also set this flag.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SOCKET_SETTINGS_IPSEC IpsecFlags;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>
		/// The GUID for the Windows Filtering Platform key of the AuthIP main mode provider context. If an application wishes to use a
		/// custom main mode policy, it should first use the FwpmProviderContextAdd0 function to add the corresponding provider context
		/// and specify the returned key in this member. This field is ignored for a GUID of zero.
		/// </para>
		/// </summary>
		public Guid AuthipMMPolicyKey;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>
		/// The Windows Filtering Platform key of the AuthIp quick mode provider context. If an application wishes to use a custom quick
		/// mode policy, it should first use the FwpmProviderContextAdd0 function to add the corresponding provider context and specify
		/// the returned key in this field. This field is ignored for a GUID of zero.
		/// </para>
		/// </summary>
		public Guid AuthipQMPolicyKey;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>Reserved for future use.</para>
		/// </summary>
		public Guid Reserved;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Reserved for future use.</para>
		/// </summary>
		public ulong Reserved2;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The length, in bytes, of the user name in the <c>AllStrings</c> member.</para>
		/// </summary>
		public uint UserNameStringLen;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The length, in bytes, of the domain name in the <c>AllStrings</c> member.</para>
		/// </summary>
		public uint DomainNameStringLen;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The length, in bytes, of the password in the <c>AllStrings</c> member.</para>
		/// </summary>
		public uint PasswordStringLen;

		/// <summary>
		/// <para>Type: <c>wchar_t[]</c></para>
		/// <para>A string that contains the user name, the domain name, and the password concatenated in this order.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr, SizeConst = 0)]
		public string AllStrings;
	}

	/// <summary>Contains the Transmission Control Protocol (TCP) statistics that were collected for a socket.</summary>
	/// <remarks>
	/// To get an instance of this structure, call the WSAIoctl or LPWSPIoctl function with the SIO_TCP_INFO control code. Specify 0 for
	/// the lpvInBuffer field to retrieve the v0 version of this structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-tcp_info_v0 typedef struct _TCP_INFO_v0 { TCPSTATE State;
	// ULONG Mss; ULONG64 ConnectionTimeMs; BOOLEAN TimestampsEnabled; ULONG RttUs; ULONG MinRttUs; ULONG BytesInFlight; ULONG Cwnd;
	// ULONG SndWnd; ULONG RcvWnd; ULONG RcvBuf; ULONG64 BytesOut; ULONG64 BytesIn; ULONG BytesReordered; ULONG BytesRetrans; ULONG
	// FastRetrans; ULONG DupAcksIn; ULONG TimeoutEpisodes; UCHAR SynRetrans; } TCP_INFO_v0, *PTCP_INFO_v0;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._TCP_INFO_v0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TCP_INFO_v0
	{
		/// <summary>A value from the TCPSTATE enumeration that indicates the state of the TCP connection.</summary>
		public TCPSTATE State;

		/// <summary>The current maximum segment size (MSS) for the connection, in bytes.</summary>
		public uint Mss;

		/// <summary>The lifetime of the connection, in milliseconds.</summary>
		public ulong ConnectionTimeMs;

		/// <summary><c>TRUE</c> if TCP time stamps are turned on for the connection; otherwise <c>FALSE</c>.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool TimestampsEnabled;

		/// <summary>The current estimated round-trip time for the connection, in microseconds.</summary>
		public uint RttUs;

		/// <summary>The minimum sampled round trip time, in microseconds.</summary>
		public uint MinRttUs;

		/// <summary>The current number of sent bytes that are unacknowledged.</summary>
		public uint BytesInFlight;

		/// <summary>The size of the current congestion window, in bytes.</summary>
		public uint Cwnd;

		/// <summary>The size of the send window (SND.WND in RFC 793), in bytes.</summary>
		public uint SndWnd;

		/// <summary>The size of the receive window (RCV.WND in RFC 793), in bytes.</summary>
		public uint RcvWnd;

		/// <summary>
		/// The size of the current receive buffer, in bytes. The size of the receive buffer changes dynamically when autotuning is
		/// turned on for the receive window.
		/// </summary>
		public uint RcvBuf;

		/// <summary>The total number of bytes sent.</summary>
		public ulong BytesOut;

		/// <summary>The total number of bytes received.</summary>
		public ulong BytesIn;

		/// <summary>The total number of bytes reordered.</summary>
		public uint BytesReordered;

		/// <summary>The total number of bytes retransmitted.</summary>
		public uint BytesRetrans;

		/// <summary>The number of calls of the Fast Retransmit algorithm.</summary>
		public uint FastRetrans;

		/// <summary>The total number of duplicate acknowledgments received.</summary>
		public uint DupAcksIn;

		/// <summary>The total number of retransmission timeout episodes. Each episode can consist of multiple timeouts.</summary>
		public uint TimeoutEpisodes;

		/// <summary>The total number of retransmitted synchronize control flags (SYNs).</summary>
		public byte SynRetrans;
	}

	/// <summary>
	/// Contains the Transmission Control Protocol (TCP) statistics that were collected for a socket. Version 1.0 of this structure
	/// provides additional fields.
	/// </summary>
	/// <remarks>
	/// To get an instance of this structure, call the WSAIoctl or LPWSPIoctl function with the SIO_TCP_INFO control code. Specify 1 for
	/// the lpvInBuffer field to retrieve the v1 version of this structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-tcp_info_v1 typedef struct _TCP_INFO_v1 { TCPSTATE State;
	// ULONG Mss; ULONG64 ConnectionTimeMs; BOOLEAN TimestampsEnabled; ULONG RttUs; ULONG MinRttUs; ULONG BytesInFlight; ULONG Cwnd;
	// ULONG SndWnd; ULONG RcvWnd; ULONG RcvBuf; ULONG64 BytesOut; ULONG64 BytesIn; ULONG BytesReordered; ULONG BytesRetrans; ULONG
	// FastRetrans; ULONG DupAcksIn; ULONG TimeoutEpisodes; UCHAR SynRetrans; ULONG SndLimTransRwin; ULONG SndLimTimeRwin; ULONG64
	// SndLimBytesRwin; ULONG SndLimTransCwnd; ULONG SndLimTimeCwnd; ULONG64 SndLimBytesCwnd; ULONG SndLimTransSnd; ULONG SndLimTimeSnd;
	// ULONG64 SndLimBytesSnd; } TCP_INFO_v1, *PTCP_INFO_v1;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._TCP_INFO_v1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TCP_INFO_v1
	{
		/// <summary>Contains the Transmission Control Protocol (TCP) statistics that were collected for a socket.</summary>
		public TCPSTATE State;

		/// <summary>The current maximum segment size (MSS) for the connection, in bytes.</summary>
		public uint Mss;

		/// <summary>The lifetime of the connection, in milliseconds.</summary>
		public ulong ConnectionTimeMs;

		/// <summary><c>TRUE</c> if TCP time stamps are turned on for the connection; otherwise <c>FALSE</c>.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool TimestampsEnabled;

		/// <summary>The current estimated round-trip time for the connection, in microseconds.</summary>
		public uint RttUs;

		/// <summary>The minimum sampled round trip time, in microseconds.</summary>
		public uint MinRttUs;

		/// <summary>The current number of sent bytes that are unacknowledged.</summary>
		public uint BytesInFlight;

		/// <summary>The size of the current congestion window, in bytes.</summary>
		public uint Cwnd;

		/// <summary>The size of the send window (SND.WND in RFC 793), in bytes.</summary>
		public uint SndWnd;

		/// <summary>The size of the receive window (RCV.WND in RFC 793), in bytes.</summary>
		public uint RcvWnd;

		/// <summary>
		/// The size of the current receive buffer, in bytes. The size of the receive buffer changes dynamically when autotuning is
		/// turned on for the receive window.
		/// </summary>
		public uint RcvBuf;

		/// <summary>The total number of bytes sent.</summary>
		public ulong BytesOut;

		/// <summary>The total number of bytes received.</summary>
		public ulong BytesIn;

		/// <summary>The total number of bytes reordered.</summary>
		public uint BytesReordered;

		/// <summary>The total number of bytes retransmitted.</summary>
		public uint BytesRetrans;

		/// <summary>The number of calls of the Fast Retransmit algorithm.</summary>
		public uint FastRetrans;

		/// <summary>The total number of duplicate acknowledgments received.</summary>
		public uint DupAcksIn;

		/// <summary>The total number of retransmission timeout episodes. Each episode can consist of multiple timeouts.</summary>
		public uint TimeoutEpisodes;

		/// <summary>The total number of retransmitted synchronize control flags (SYNs).</summary>
		public byte SynRetrans;

		/// <summary>
		/// The number of transitions into the "Receiver Limited" state from either the "Congestion Limited" or "Sender Limited" states.
		/// </summary>
		public uint SndLimTransRwin;

		/// <summary>
		/// The cumulative time, in milliseconds, spent in the "Receiver Limited" state where TCP transmission stops because the sender
		/// has filled the announced receiver window.
		/// </summary>
		public uint SndLimTimeRwin;

		/// <summary>The total number of bytes sent in the "Receiver Limited" state.</summary>
		public ulong SndLimBytesRwin;

		/// <summary>
		/// The number of transitions into the "Congestion Limited" state from either the "Receiver Limited" or "Sender Limited" states.
		/// </summary>
		public uint SndLimTransCwnd;

		/// <summary>
		/// The cumulative time, in milliseconds, spent in the "Congestion Limited" state. When there is a retransmission timeout, it is
		/// counted in this member and not the cumulative time for some other state.
		/// </summary>
		public uint SndLimTimeCwnd;

		/// <summary>The total number of bytes sent in the "Congestion Limited" state.</summary>
		public ulong SndLimBytesCwnd;

		/// <summary>
		/// The number of transitions into the "Sender Limited" state from either the "Receiver Limited" or "Congestion Limited" states.
		/// </summary>
		public uint SndLimTransSnd;

		/// <summary>The cumulative time, in milliseconds, spent in the "Sender Limited" state.</summary>
		public uint SndLimTimeSnd;

		/// <summary>The total number of bytes sent in the "Sender Limited" state.</summary>
		public ulong SndLimBytesSnd;
	}

	/// <summary>
	/// The TCP_INITIAL_RTO_PARAMETERS structure specifies data used by the SIO_TCP_INITIAL_RTO IOCTL to configure initial
	/// re-transmission timeout (RTO) parameters to be used on the socket.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The TCP_INITIAL_RTO_PARAMETERS structure allows an application to configure the initial round trip time (RTT) used to compute the
	/// retransmission timeout. The application can also configure the number of re-transmissions that will be attempted before the
	/// connection attempt fails.
	/// </para>
	/// <para>
	/// An application should supply the RTT of choice in milliseconds and the maximum number of retransmissions in this structure. The
	/// Windows TCP/IP stack will honor these parameters for the subsequent connection attempt. The retransmission behavior for TCP is
	/// documented in IETF RFC 793 and 2988.
	/// </para>
	/// <para>
	/// An application may use the unspecified defines, <c>TCP_INITIAL_RTO_UNSPECIFIED_RTT</c> and
	/// <c>TCP_INITIAL_RTO_UNSPECIFIED_MAX_SYN_RETRANSMISSIONS</c> when supplying values for one of these fields. This allows the system
	/// to pick up administrator configured settings for the parameter left unspecified.
	/// </para>
	/// <para>
	/// An application can choose system defaults for any of these fields and supply those values using the default defines,
	/// <c>TCP_INITIAL_RTO_DEFAULT_RTT</c> and <c>TCP_INITIAL_RTO_DEFAULT_MAX_SYN_RETRANSMISSIONS</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-tcp_initial_rto_parameters typedef struct
	// _TCP_INITIAL_RTO_PARAMETERS { USHORT Rtt; UCHAR MaxSynRetransmissions; } TCP_INITIAL_RTO_PARAMETERS, *PTCP_INITIAL_RTO_PARAMETERS;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._TCP_INITIAL_RTO_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TCP_INITIAL_RTO_PARAMETERS
	{
		/// <summary>Supplies the initial RTT in milliseconds.</summary>
		public ushort Rtt;

		/// <summary>Supplies the number of retransmissions attempted before the connection setup fails.</summary>
		public byte MaxSynRetransmissions;
	}

	/// <summary>Argument structure for SIO_KEEPALIVE_VALS</summary>
	[PInvokeData("mstcpip.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct tcp_keepalive
	{
		/// <summary>
		/// Determines if TCP keep-alive is enabled or disabled. If the onoff member is set to a nonzero value, TCP keep-alive is enabled
		/// and the other members in the structure are used.
		/// </summary>
		public BOOL onoff;

		/// <summary>Specifies the timeout, in milliseconds, with no activity until the first keep-alive packet is sent.</summary>
		public uint keepalivetime;

		/// <summary>
		/// Specifies the interval, in milliseconds, between when successive keep-alive packets are sent if no acknowledgement is received.
		/// </summary>
		public uint keepaliveinterval;
	}

	/// <summary>
	/// Describes the input structure used by the SIO_TIMESTAMPING configuration IOCTL to configure timestamp reception for a datagram socket.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mstcpip/ns-mstcpip-timestamping_config typedef struct _TIMESTAMPING_CONFIG {
	// ULONG Flags; USHORT TxTimestampsBuffered; } TIMESTAMPING_CONFIG, *PTIMESTAMPING_CONFIG;
	[PInvokeData("mstcpip.h", MSDNShortId = "NS:mstcpip._TIMESTAMPING_CONFIG")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TIMESTAMPING_CONFIG
	{
		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Enable/disable timestamp reception for rx/tx direction.</para>
		/// <para>
		/// Use the values <c>TIMESTAMPING_FLAG_RX</c> (0x1) and <c>TIMESTAMPING_FLAG_TX</c> (0x2) (both defined in <c>mstcpip.h</c> ).
		/// Specify a value to enable timestamp reception for that direction; and omit a value to disable timestamp reception for that direction.
		/// </para>
		/// </summary>
		public TIMESTAMPING_FLAG Flags;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>
		/// Determines how many tx timestamps may be buffered. When the count of tx timestamps that have been buffered reaches a value
		/// equal to TxTimestampsBuffered, and a new tx timestamp has been generated, the new timestamp will be discarded.
		/// </para>
		/// </summary>
		public ushort TxTimestampsBuffered;
	}

	/// <summary>
	/// The <c>TRANSPORT_SETTING_ID</c> structure specifies the transport setting ID used by the SIO_APPLY_TRANSPORT_SETTING and
	/// SIO_QUERY_TRANSPORT_SETTING IOCTLs to apply or query the transport setting for a socket.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The only transport setting defined for Windows 8 and Windows Server 2012 is for the <c>REAL_TIME_NOTIFICATION_CAPABILITY</c>
	/// capability on a TCP socket. For Windows 10 and Windows Server 2016, there is another transport setting defined as <c>ASSOCIATE_NAMERES_CONTEXT</c>.
	/// </para>
	/// <para>
	/// The <c>TRANSPORT_SETTING_ID</c> structure is passed as input to the SIO_APPLY_TRANSPORT_SETTING and SIO_QUERY_TRANSPORT_SETTING
	/// IOCTLs. The <c>Guid</c> member determines what transport setting is applied or queried.
	/// </para>
	/// <para>The only transport setting currently defines is for the <c>REAL_TIME_NOTIFICATION_CAPABILITY</c> capability on a TCP socket.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/transportsettingcommon/ns-transportsettingcommon-transport_setting_id typedef
	// struct TRANSPORT_SETTING_ID { GUID Guid; } TRANSPORT_SETTING_ID, *PTRANSPORT_SETTING_ID;
	[PInvokeData("transportsettingcommon.h", MSDNShortId = "NS:transportsettingcommon.TRANSPORT_SETTING_ID")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TRANSPORT_SETTING_ID
	{
		/// <summary>The transport setting ID.</summary>
		public Guid Guid;
	}
}