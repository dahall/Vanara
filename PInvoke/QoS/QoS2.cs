using System.Threading;
using QOS_FLOWID = System.UInt32;

namespace Vanara.PInvoke;

/// <summary>Items from Qwave.dll.</summary>
public static partial class Qwave
{
	/// <summary>
	/// If you are unsure what bandwidth value you need but expect to use very little use QOS_OUTGOING_DEFAULT_MINIMUM_BANDWIDTH. The system
	/// will allocate you a small amount of bandwidth for your operations.
	/// </summary>
	public const ulong QOS_OUTGOING_DEFAULT_MINIMUM_BANDWIDTH = 0xFFFFFFFF;

	/// <summary>Flags used by <see cref="QOSAddSocketToFlow"/>.</summary>
	[PInvokeData("qos2.h")]
	public enum QOS_FLOW_TYPE
	{
		/// <summary>
		/// If specified, the QoS subsystem will not gather data about the network path for this flow. As a result, functions which rely on
		/// bandwidth estimation techniques will not be available. For example, this would block QOSQueryFlow with an Operation value of
		/// QOSQueryFlowFundamentals and QOSNotifyFlow with an Operation value of QOSNotifyCongested, QOSNotifyUncongested, and QOSNotifyAvailable.
		/// </summary>
		QOS_NON_ADAPTIVE_FLOW = 0x00000002
	}

	/// <summary>The <c>QOS_FLOWRATE_REASON</c> enumeration indicates the reason for a change in a flow's bandwidth.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ne-qos2-qos_flowrate_reason typedef enum _QOS_FLOWRATE_REASON {
	// QOSFlowRateNotApplicable = 0, QOSFlowRateContentChange = 1, QOSFlowRateCongestion = 2, QOSFlowRateHigherContentEncoding = 3,
	// QOSFlowRateUserCaused = 4 } QOS_FLOWRATE_REASON, *PQOS_FLOWRATE_REASON;
	[PInvokeData("qos2.h", MSDNShortId = "NE:qos2._QOS_FLOWRATE_REASON")]
	public enum QOS_FLOWRATE_REASON
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Indicates that there has not been a change in the flow.</para>
		/// </summary>
		QOSFlowRateNotApplicable,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates that the content of a flow has changed.</para>
		/// </summary>
		QOSFlowRateContentChange,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Indicates that the flow has changed due to congestion.</para>
		/// </summary>
		QOSFlowRateCongestion,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// </summary>
		QOSFlowRateHigherContentEncoding,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Indicates that the user has caused the flow to change.</para>
		/// </summary>
		QOSFlowRateUserCaused,
	}

	/// <summary>
	/// The <c>QOS_NOTIFY_FLOW</c> enumeration specifies the circumstances that must be present for the QOSNotifyFlow function to send a notification.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ne-qos2-qos_notify_flow typedef enum _QOS_NOTIFY_FLOW { QOSNotifyCongested =
	// 0, QOSNotifyUncongested = 1, QOSNotifyAvailable = 2 } QOS_NOTIFY_FLOW, *PQOS_NOTIFY_FLOW;
	[PInvokeData("qos2.h", MSDNShortId = "NE:qos2._QOS_NOTIFY_FLOW")]
	public enum QOS_NOTIFY_FLOW
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Notifications will be sent when congestion is detected. If the flow is currently congested, a notification may be sent immediately.
		/// </para>
		/// </summary>
		QOSNotifyCongested,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Notifications will be sent when the flow is not congested. If the flow is currently uncongested, a notification may be sent immediately.
		/// </para>
		/// </summary>
		QOSNotifyUncongested,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Notifications will be sent when the flow's available capacity is sufficient to allow upgrading its bandwidth to a specified capacity.
		/// </para>
		/// </summary>
		QOSNotifyAvailable,
	}

	/// <summary>The <c>QOS_QUERY_FLOW</c> enumeration indicates the type of information a QOSQueryFlow function will request.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ne-qos2-qos_query_flow typedef enum _QOS_QUERY_FLOW {
	// QOSQueryFlowFundamentals = 0, QOSQueryPacketPriority = 1, QOSQueryOutgoingRate = 2 } QOS_QUERY_FLOW, *PQOS_QUERY_FLOW;
	[PInvokeData("qos2.h", MSDNShortId = "NE:qos2._QOS_QUERY_FLOW")]
	public enum QOS_QUERY_FLOW
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Indicates an information request for the flow fundamentals. This information includes bottleneck bandwidth, available bandwidth,
		/// and the average Round Trip Time (RTT)
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(QOS_FLOW_FUNDAMENTALS))]
		QOSQueryFlowFundamentals,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates a request for information detailing the QoS priority being added to flow packets.</para>
		/// </summary>
		[CorrespondingType(typeof(QOS_PACKET_PRIORITY))]
		QOSQueryPacketPriority,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Indicates a request for the flow rate specified during the creation of an agreement with the QoS subsystem via the</para>
		/// <para>QOSSetFlow</para>
		/// <para>function.</para>
		/// </summary>
		[CorrespondingType(typeof(ulong))]
		QOSQueryOutgoingRate,
	}

	/// <summary>Flags used by <see cref="QOSQueryFlow(HQOS, QOS_FLOWID, QOS_QUERY_FLOW, ref QOS_FLOWID, IntPtr, QOS_QUERYFLOW, IntPtr)"/>.</summary>
	[PInvokeData("qos2.h")]
	public enum QOS_QUERYFLOW
	{
		/// <summary>
		/// The QOS subsystem will only return fresh, not cached, data. If fresh data is unavailable, it will try to obtain such data, at the
		/// expense of possibly taking more time. If this is not possible, the call will fail with the error code ERROR_RETRY.
		/// <para>This flag is only applicable when the Operation parameter is set to QOSQueryFlowFundamentals.</para>
		/// </summary>
		QOS_QUERYFLOW_FRESH = 0x00000001
	}

	/// <summary>The <c>QOS_SET_FLOW</c> enumeration indicates what is being changed about a flow.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ne-qos2-qos_set_flow typedef enum _QOS_SET_FLOW { QOSSetTrafficType = 0,
	// QOSSetOutgoingRate = 1, QOSSetOutgoingDSCPValue = 2 } QOS_SET_FLOW, *PQOS_SET_FLOW;
	[PInvokeData("qos2.h", MSDNShortId = "NE:qos2._QOS_SET_FLOW")]
	public enum QOS_SET_FLOW
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Indicates that the traffic type of the flow will change.</para>
		/// </summary>
		QOSSetTrafficType,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates that the flow rate will change.</para>
		/// </summary>
		QOSSetOutgoingRate,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Windows 7, Windows Server 2008 R2, and later: Indicates that the outgoing DSCP value will change.</para>
		/// <para>
		/// <c>Note</c> This setting requires the calling application be a member of the Administrators or the Network Configuration
		/// Operators group.
		/// </para>
		/// </summary>
		QOSSetOutgoingDSCPValue,
	}

	/// <summary>The <c>QOS_SHAPING</c> enumeration defines the shaping behavior of a flow.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ne-qos2-qos_shaping typedef enum _QOS_SHAPING { QOSShapeOnly = 0,
	// QOSShapeAndMark = 1, QOSUseNonConformantMarkings = 2 } QOS_SHAPING, *PQOS_SHAPING;
	[PInvokeData("qos2.h", MSDNShortId = "NE:qos2._QOS_SHAPING")]
	public enum QOS_SHAPING
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Indicates that the Windows packet scheduler (Pacer) will be used to enforce the requested flow rate. Data packets that exceed the
		/// rate are delayed until appropriate in order to maintain the specified flow rate. If the network supports prioritization, packets
		/// will always receive conformant priority values when QOSShapeFlow is specified.
		/// </para>
		/// </summary>
		QOSShapeOnly,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Indicates that the Windows Scheduler will be used to enforce the requested flow rate. Data packets exceeding the rate are delayed
		/// accordingly. Packets receive conformant priority values.
		/// </para>
		/// </summary>
		QOSShapeAndMark,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Indicates that the flow rate requested will not be enforced. Data packets that would exceed the flow rate will receive a priority
		/// that indicates they are non-conformant. This may lead to lost and reordered packets.
		/// </para>
		/// </summary>
		QOSUseNonConformantMarkings,
	}

	/// <summary>
	/// The <c>QOS_TRAFFIC_TYPE</c> enumeration defines the various traffic types. Each flow has a single traffic type. This allows the QOS
	/// subsystem to apply user-specified policies to each type.
	/// </summary>
	/// <remarks>
	/// <para>802.1p tags are added to sent traffic only when the following conditions are met:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>QOSAddSocketToFlow is called without the QOS_NON_ADAPTIVE_FLOW flag</term>
	/// </item>
	/// <item>
	/// <term>The destination host is on the local link and not across a router</term>
	/// </item>
	/// <item>
	/// <term>The qWAVE subsystem has determined that 802.1p tagged packets are not discarded by a network element on the end-to-end path</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ne-qos2-qos_traffic_type typedef enum _QOS_TRAFFIC_TYPE {
	// QOSTrafficTypeBestEffort = 0, QOSTrafficTypeBackground = 1, QOSTrafficTypeExcellentEffort = 2, QOSTrafficTypeAudioVideo = 3,
	// QOSTrafficTypeVoice = 4, QOSTrafficTypeControl = 5 } QOS_TRAFFIC_TYPE, *PQOS_TRAFFIC_TYPE;
	[PInvokeData("qos2.h", MSDNShortId = "NE:qos2._QOS_TRAFFIC_TYPE")]
	public enum QOS_TRAFFIC_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Flow traffic has the same network priority as regular traffic not associated with QOS.</para>
		/// <para>
		/// This traffic type is the same as not specifying priority, and as a result, the DSCP mark and 802.1p tag are not added to sent traffic.
		/// </para>
		/// </summary>
		QOSTrafficTypeBestEffort,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Flow traffic has a network priority lower than that of</para>
		/// <para>QOSTrafficTypeBestEffort</para>
		/// <para>. This traffic type could be used for traffic of an application doing data backup.</para>
		/// <para>Sent traffic will contain a DSCP mark with a value of 0x08 and an 802.1p tag with a value of 2.</para>
		/// </summary>
		QOSTrafficTypeBackground,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Flow traffic has a network priority higher than</para>
		/// <para>QOSTrafficTypeBestEffort</para>
		/// <para>, yet lower than</para>
		/// <para>QOSTrafficTypeAudioVideo</para>
		/// <para>. This traffic type should be used for data traffic that is more important than normal end-user scenarios, such as email.</para>
		/// <para>Sent traffic will contain a DSCP mark with value of 0x28 and 802.1p tag with a value of 5.</para>
		/// </summary>
		QOSTrafficTypeExcellentEffort,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Flow traffic has a network priority higher than</para>
		/// <para>QOSTrafficTypeExcellentEffort</para>
		/// <para>, yet lower than</para>
		/// <para>QOSTrafficTypeVoice</para>
		/// <para>. This traffic type should be used for A/V streaming scenarios such as MPEG2 streaming.</para>
		/// <para>Sent traffic will contain a DSCP mark with a value of 0x28 and an 802.1p tag with a value of 5.</para>
		/// </summary>
		QOSTrafficTypeAudioVideo,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Flow traffic has a network priority higher than</para>
		/// <para>QOSTrafficTypeAudioVideo</para>
		/// <para>, yet lower than</para>
		/// <para>QOSTrafficTypeControl</para>
		/// <para>. This traffic type should be used for realtime voice streams such as VOIP.</para>
		/// <para>Sent traffic will contain a DSCP mark with a value of 0x38 and an 802.1p tag with a value of 7.</para>
		/// </summary>
		QOSTrafficTypeVoice,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>
		/// Flow traffic has the highest network priority. This traffic type should only be used for the most critical of data. For example,
		/// it may be used for data carrying user inputs.
		/// </para>
		/// <para>Sent traffic will contain a DSCP mark with a value of 0x38 and an 802.1p tag with a value of 7.</para>
		/// </summary>
		QOSTrafficTypeControl,
	}

	/// <summary>API to calculate the impact of IP and protocol header overhead on a data rate.</summary>
	/// <param name="af">
	/// Address family used to create the socket. Please review the socket and WSASocket documentation. This should be AF_INET or AF_INET6
	/// </param>
	/// <param name="protocol">
	/// Protocol type used to create the socket. Please review the socket and WSASocket documentation. This should be IPPROTO_TCP or IPPROTO_UDP
	/// </param>
	/// <param name="targetDataPacketSize">This is the expected packet size of your data stream.</param>
	/// <param name="dataRate">Your dataRate in bits/s.</param>
	/// <returns>
	/// This call will return the data rate, in bits/s, augmented by the overhead on each packet given the address family and the protocol
	/// you've created your socket with.
	/// </returns>
	/// <remarks>
	/// Note on targetDataPacketSize:
	/// <para>
	/// If you're using a TCP socket on IPv4 and will be making large sends then you would expect the data packet size to be 1460 bytes:
	/// Ethernet has an MTU of 1500 bytes and that the overhead of an IPv4 header is typically 20 bytes while a TCP header is also 20 bytes.
	/// </para>
	/// <para>
	/// If you're using a UDP socket and your packet size varies, you may wish to pass in a reasonnable minimal value. This would adjust your
	/// rate for the worst case.
	/// </para>
	/// <para>The value 0 is an invalid parameter which will result in a division by 0.</para>
	/// </remarks>
	[PInvokeData("qos2.h")]
	public static ulong QOS_ADD_OVERHEAD(ADDRESS_FAMILY af, IPPROTO protocol, uint targetDataPacketSize, ulong dataRate)
	{
		// Calculate the header overhead
		ulong overhead = (ulong)QOS_HEADER_OVERHEAD(af, protocol);

		// Convert overhead and dataRate to bits
		overhead *= 8;
		targetDataPacketSize *= 8;

		// The adjustment is:
		//
		// (dataRate ) returnRate = dataRate + (-------------------- * overhead ) (targetDataPacketSize )
		//
		// For each packet we expect to see go out, we need to add the overhead
		return dataRate + dataRate * overhead / targetDataPacketSize;
	}

	/// <summary>API to calculate the impact of IP and protocol header overhead on a data rate.</summary>
	/// <param name="af">
	/// Address family used to create the socket. Please review the socket and WSASocket documentation. This should be AF_INET or AF_INET6
	/// </param>
	/// <param name="protocol">
	/// Protocol type used to create the socket. Please review the socket and WSASocket documentation. This should be IPPROTO_TCP or IPPROTO_UDP
	/// </param>
	/// <param name="targetDataPacketSize">This is the expected packet size of your data stream.</param>
	/// <param name="dataRate">Your dataRate in bits/s.</param>
	/// <returns>
	/// This call will return the data rate, in bits/s, reduced by the overhead on each packet given the address family and the protocol
	/// you've created your socket with.
	/// </returns>
	/// <remarks>
	/// Note on targetDataPacketSize:
	/// <para>
	/// If you're using a TCP socket on IPv4 and will be making large sends then you would expect the data packet size to be 1460 bytes:
	/// Ethernet has an MTU of 1500 bytes and that the overhead of an IPv4 header is typically 20 bytes while a TCP header is also 20 bytes.
	/// </para>
	/// <para>
	/// If you're using a UDP socket and your packet size varies, you may wish to pass in a reasonnable minimal value. This would adjust your
	/// rate for the worst case.
	/// </para>
	/// </remarks>
	[PInvokeData("qos2.h")]
	public static ulong QOS_SUBTRACT_OVERHEAD(ADDRESS_FAMILY af, IPPROTO protocol, uint targetDataPacketSize, ulong dataRate)
	{
		// Calculate the header overhead
		ulong overhead = (ulong)QOS_HEADER_OVERHEAD(af, protocol);

		// Convert overhead and dataRate to bits
		overhead *= 8;
		targetDataPacketSize *= 8;

		// The adjustment is:
		//
		// (dataRate ) returnRate = dataRate - (------------------------------- * overhead ) (targetDataPacketSize + overhead )
		//
		// For each packet we expect to see go out, we need to add the overhead
		return dataRate - dataRate * overhead / (targetDataPacketSize + overhead);
	}

	/// <summary>The <c>QOSAddSocketToFlow</c> function adds a new flow for traffic.</summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="Socket">Identifies the socket that the application will use to flow traffic.</param>
	/// <param name="DestAddr">
	/// <para>
	/// Pointer to a sockaddr structure that contains the destination IP address to which the application will send traffic. The sockaddr
	/// structure must specify a destination port.
	/// </para>
	/// <para><note type="note">
	/// <para>
	/// <c>DestAddr</c> is optional if the socket is already connected. If this parameter is specified, the remote IP address and port must
	/// match those used in the socket's connect call.
	/// </para>
	/// <para>
	/// If the socket is not connected, this parameter must be specified. If the socket is already connected, this parameter does not need to
	/// be specified. In this case, if the parameter is still specified, the destination host and port must match what was specified during
	/// the socket connect call.
	/// </para>
	/// <para>
	/// Since, under TCP, the socket connect call can be delayed, <c>QOSAddSocketToFlow</c> can be called before a connection is established,
	/// passing in the remote system's IP address and port number in the <c>DestAddr</c> parameter.
	/// </para>
	/// </note>
	/// </para>
	/// </param>
	/// <param name="TrafficType">A QOS_TRAFFIC_TYPE constant that specifies the type of traffic for which this flow will be used.</param>
	/// <param name="Flags">
	/// <para>Optional flag values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>QOS_NON_ADAPTIVE_FLOW</c></term>
	/// <term>
	/// If specified, the QoS subsystem will not gather data about the network path for this flow. As a result, functions which rely on
	/// bandwidth estimation techniques will not be available. For example, this would block QOSQueryFlow with an <c>Operation</c> value of
	/// <c>QOSQueryFlowFundamentals</c> and QOSNotifyFlow with an <c>Operation</c> value of <c>QOSNotifyCongested</c>,
	/// <c>QOSNotifyUncongested</c>, and <c>QOSNotifyAvailable</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="FlowId">
	/// <para>
	/// Pointer to a buffer that receives a flow identifier. On input, this value must be 0. On output, the buffer contains a flow identifier
	/// if the call succeeds.
	/// </para>
	/// <para>If a socket is being added to an existing flow, this parameter will be the identifier of that flow.</para>
	/// <para>
	/// An application can make use of this parameter if multiple sockets used can share the same QoS flow properties. The QoS subsystem,
	/// then does not have to incur the overhead of provisioning new flows for subsequent sockets with the same properties. Note that only
	/// non-adaptive flows can have multiple sockets attached to an existing flow.
	/// </para>
	/// <para>A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_CONNECTION_REFUSED</c></term>
	/// <term>The remote system refused the network connection.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>FlowId</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>A memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>The request is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The use of IPv4/v6 mixed addresses is not supported in qWAVE. The address specified by the <c>DestAddr</c> parameter must be either
	/// IPv4 or IPv6.
	/// </para>
	/// <para>
	/// If there is a requirement for network experiments over a specific network interface, the socket must be bound to that particular
	/// interface. Otherwise the most appropriate interface for the experiment, as indicated by the network stack, is assigned by the qWAVE subsystem.
	/// </para>
	/// <para>
	/// Network traffic associated with this flow is not affected by making this call alone. For example, packet prioritization does not
	/// occur immediately.
	/// </para>
	/// <para>
	/// There are two categories of applications that use this function: adaptive and non-adaptive. An adaptive application makes use of
	/// notifications and information in the QOS_FLOW_FUNDAMENTALS structure for adapting to network changes such as congestion. The qWAVE
	/// service uses Link Layer Topology Discovery (LLTD) QoS extensions for adaptive flows which can be present on the destination device.
	/// </para>
	/// <para>
	/// After calling this function adaptive A/V applications should call the QOSSetFlow function with an <c>Operation</c> value of
	/// <c>QOSSetFlowRate</c> to affect network traffic.
	/// </para>
	/// <para>
	/// A non-adaptive application either does not adapt to changing network characteristics or is sending traffic to an endpoint that does
	/// not support adaptive capabilities as indicated by ERROR_NOT_SUPPORTED.
	/// </para>
	/// <para>
	/// Non-adaptive applications, or adaptive applications making non-adaptive flows, should call this function with the
	/// <c>QOS_NON_ADAPTIVE_FLOW</c> flag. After calling this function A/V applications should call the QOSSetFlow function with a
	/// <c>Operation</c>. <c>QOSSetFlow</c> does not need to be called unless shaping is desired.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code illustrates the use of <c>QOSAddSocketFromFlow</c>. The QOSCreateHandle function is also shown to provide
	/// information on initialization of parameters used by <c>QOSAddSocketFromFlow</c>.
	/// </para>
	/// <para>See the Windows SDK for a complete sample code listing. SDK folder: Samples\NetDs\GQos\Qos2</para>
	/// <para>The Winsock2.h header file must be included to use WSAGetLastError and other Winsock functions.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosaddsockettoflow ExternC BOOL QOSAddSocketToFlow( [in] HANDLE
	// QOSHandle, [in] SOCKET Socket, [in, optional] PSOCKADDR DestAddr, [in] QOS_TRAFFIC_TYPE TrafficType, [in, optional] DWORD Flags, [in,
	// out] PQOS_FLOWID FlowId );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSAddSocketToFlow")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSAddSocketToFlow([In] HQOS QOSHandle, [In] SOCKET Socket, [In] SOCKADDR DestAddr,
		[In] QOS_TRAFFIC_TYPE TrafficType, [In, Optional] QOS_FLOW_TYPE Flags, ref QOS_FLOWID FlowId);

	/// <summary>The <c>QOSAddSocketToFlow</c> function adds a new flow for traffic.</summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="Socket">Identifies the socket that the application will use to flow traffic.</param>
	/// <param name="DestAddr">
	/// <para>
	/// Pointer to a sockaddr structure that contains the destination IP address to which the application will send traffic. The sockaddr
	/// structure must specify a destination port.
	/// </para>
	/// <para><note type="note">
	/// <para>
	/// <c>DestAddr</c> is optional if the socket is already connected. If this parameter is specified, the remote IP address and port must
	/// match those used in the socket's connect call.
	/// </para>
	/// <para>
	/// If the socket is not connected, this parameter must be specified. If the socket is already connected, this parameter does not need to
	/// be specified. In this case, if the parameter is still specified, the destination host and port must match what was specified during
	/// the socket connect call.
	/// </para>
	/// <para>
	/// Since, under TCP, the socket connect call can be delayed, <c>QOSAddSocketToFlow</c> can be called before a connection is established,
	/// passing in the remote system's IP address and port number in the <c>DestAddr</c> parameter.
	/// </para>
	/// </note>
	/// </para>
	/// </param>
	/// <param name="TrafficType">A QOS_TRAFFIC_TYPE constant that specifies the type of traffic for which this flow will be used.</param>
	/// <param name="Flags">
	/// <para>Optional flag values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>QOS_NON_ADAPTIVE_FLOW</c></term>
	/// <term>
	/// If specified, the QoS subsystem will not gather data about the network path for this flow. As a result, functions which rely on
	/// bandwidth estimation techniques will not be available. For example, this would block QOSQueryFlow with an <c>Operation</c> value of
	/// <c>QOSQueryFlowFundamentals</c> and QOSNotifyFlow with an <c>Operation</c> value of <c>QOSNotifyCongested</c>,
	/// <c>QOSNotifyUncongested</c>, and <c>QOSNotifyAvailable</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="FlowId">
	/// <para>
	/// Pointer to a buffer that receives a flow identifier. On input, this value must be 0. On output, the buffer contains a flow identifier
	/// if the call succeeds.
	/// </para>
	/// <para>If a socket is being added to an existing flow, this parameter will be the identifier of that flow.</para>
	/// <para>
	/// An application can make use of this parameter if multiple sockets used can share the same QoS flow properties. The QoS subsystem,
	/// then does not have to incur the overhead of provisioning new flows for subsequent sockets with the same properties. Note that only
	/// non-adaptive flows can have multiple sockets attached to an existing flow.
	/// </para>
	/// <para>A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_CONNECTION_REFUSED</c></term>
	/// <term>The remote system refused the network connection.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>FlowId</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>A memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>The request is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The use of IPv4/v6 mixed addresses is not supported in qWAVE. The address specified by the <c>DestAddr</c> parameter must be either
	/// IPv4 or IPv6.
	/// </para>
	/// <para>
	/// If there is a requirement for network experiments over a specific network interface, the socket must be bound to that particular
	/// interface. Otherwise the most appropriate interface for the experiment, as indicated by the network stack, is assigned by the qWAVE subsystem.
	/// </para>
	/// <para>
	/// Network traffic associated with this flow is not affected by making this call alone. For example, packet prioritization does not
	/// occur immediately.
	/// </para>
	/// <para>
	/// There are two categories of applications that use this function: adaptive and non-adaptive. An adaptive application makes use of
	/// notifications and information in the QOS_FLOW_FUNDAMENTALS structure for adapting to network changes such as congestion. The qWAVE
	/// service uses Link Layer Topology Discovery (LLTD) QoS extensions for adaptive flows which can be present on the destination device.
	/// </para>
	/// <para>
	/// After calling this function adaptive A/V applications should call the QOSSetFlow function with an <c>Operation</c> value of
	/// <c>QOSSetFlowRate</c> to affect network traffic.
	/// </para>
	/// <para>
	/// A non-adaptive application either does not adapt to changing network characteristics or is sending traffic to an endpoint that does
	/// not support adaptive capabilities as indicated by ERROR_NOT_SUPPORTED.
	/// </para>
	/// <para>
	/// Non-adaptive applications, or adaptive applications making non-adaptive flows, should call this function with the
	/// <c>QOS_NON_ADAPTIVE_FLOW</c> flag. After calling this function A/V applications should call the QOSSetFlow function with a
	/// <c>Operation</c>. <c>QOSSetFlow</c> does not need to be called unless shaping is desired.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code illustrates the use of <c>QOSAddSocketFromFlow</c>. The QOSCreateHandle function is also shown to provide
	/// information on initialization of parameters used by <c>QOSAddSocketFromFlow</c>.
	/// </para>
	/// <para>See the Windows SDK for a complete sample code listing. SDK folder: Samples\NetDs\GQos\Qos2</para>
	/// <para>The Winsock2.h header file must be included to use WSAGetLastError and other Winsock functions.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosaddsockettoflow ExternC BOOL QOSAddSocketToFlow( [in] HANDLE
	// QOSHandle, [in] SOCKET Socket, [in, optional] PSOCKADDR DestAddr, [in] QOS_TRAFFIC_TYPE TrafficType, [in, optional] DWORD Flags, [in,
	// out] PQOS_FLOWID FlowId );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSAddSocketToFlow")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSAddSocketToFlow([In] HQOS QOSHandle, [In] SOCKET Socket, [In, Optional] IntPtr DestAddr,
		[In] QOS_TRAFFIC_TYPE TrafficType, [In, Optional] QOS_FLOW_TYPE Flags, ref QOS_FLOWID FlowId);

	/// <summary>The <c>QOSCancel</c> function cancels a pending overlapped operation, like QOSSetFlow.</summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="Overlapped">Pointer to the OVERLAPPED structure used in the operation to be canceled.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>Overlapped</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>A memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function would never be called with a <c>NULL</c><c>Overlapped</c> parameter.</para>
	/// <para>
	/// Successfully canceled operations complete normal completion mechanisms and return <c>ERROR_OPERATION_ABORTED</c> as their completion
	/// return code.
	/// </para>
	/// <para>
	/// Closing a handle with the QOSCloseHandle will automatically abort all pending operations issued with that handle. If the handle is
	/// closed while a <c>QOSCancel</c> is still in progress, the call will complete with <c>ERROR_OPERATION_ABORTED</c> as the return code.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qoscancel ExternC BOOL QOSCancel( [in] HANDLE QOSHandle, [in]
	// LPOVERLAPPED Overlapped );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSCancel")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSCancel([In] HQOS QOSHandle, in NativeOverlapped Overlapped);

	/// <summary>The <c>QOSCloseHandle</c> function closes a handle returned by the QOSCreateHandle function.</summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// All flows added on the handle being closed are immediately removed from the system. Any traffic going out of a socket used to create
	/// these flows will no longer be marked with priority values. Any pending operations on these flows are immediately completed with <c>ERROR_ABORTED</c>.
	/// </para>
	/// <para>
	/// If any clients were being tracked through the handle being closed by a previous call to the QOSStartTrackingClient function,
	/// <c>QOSCloseHandle</c> indicates that the application is no longer using the client endpoint.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following "CleanUpQos" function illustrates the use of QOSRemoveSocketFromFlow and <c>QOSCloseHandle</c>:</para>
	/// <para>See the Windows SDK for a complete sample code listing. SDK folder: Samples\NetDs\GQos\Qos2</para>
	/// <para>The Winsock2.h header file must be included to use Winsock defined identifiers or functions.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosclosehandle ExternC BOOL QOSCloseHandle( [in] HANDLE QOSHandle );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSCloseHandle")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSCloseHandle([In] HQOS QOSHandle);

	/// <summary>
	/// <para>
	/// This function initializes the QOS subsystem and the <c>QOSHandle</c> parameter. The <c>QOSHandle</c> parameter is used when calling
	/// other QOS functions. <c>QOSCreateHandle</c> must be called before any other functions.
	/// </para>
	/// <para>QOSCloseHandle closes handles created by this function.</para>
	/// </summary>
	/// <param name="Version">
	/// Pointer to a QOS_VERSION structure that indicates the version of QOS being used. The <c>MajorVersion</c> member must be set to 1, and
	/// the <c>MinorVersion</c> member must be set to 0.
	/// </param>
	/// <param name="QOSHandle">Pointer to a variable that receives a QOS handle. This handle is used when calling other QOS functions.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_GEN_FAILURE</c></term>
	/// <term>
	/// Internal logic error. Initialization failed. For example, if the host goes into sleep or standby mode, all existing handles and flows
	/// are rendered invalid.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Indicates that a memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_RESOURCE_DISABLED</c></term>
	/// <term>
	/// A resource required by the service is unavailable. This error may be returned if the user has not enabled the firewall exception for
	/// the qWAVE service.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_SERVICE_DEPENDENCY_FAIL</c></term>
	/// <term>One of the dependencies of this service is unavailable. The qWAVE service could not be started.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Every process intending to use qWAVE must first call <c>QOSCreateHandle</c>. The handle returned can be used for performing
	/// overlapped I/O. For example, this handle can be associated with an I/O completion port (IOCP) to receive overlapped completion
	/// notifications. This function can be called multiple times to obtain multiple handles although a single handle is sufficient for most applications.
	/// </para>
	/// <para>
	/// If a machine enters a power save mode that interrupts connectivity such as sleep or standby, existing and active network experiments
	/// such as QOSStartTrackingClient must be reinitiated. This recreation of the flow mirrors the cleanup and creation activities also
	/// necessary for existing sockets. A new handle must be created, and the flow must be recreated and readmitted.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code illustrates function use and required parameter initializations. Actual values will vary depending on QoS version.
	/// </para>
	/// <para>Winsock.h must be included to use the WSAGetLastError function.</para>
	/// <para>See the Windows SDK for a complete sample code listing. SDK folder: Samples\NetDs\GQos\Qos2</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qoscreatehandle ExternC BOOL QOSCreateHandle( [in] PQOS_VERSION
	// Version, [out] PHANDLE QOSHandle );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSCreateHandle")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSCreateHandle(in QOS_VERSION Version, out HQOS QOSHandle);

	/// <summary>
	/// <para>
	/// This function initializes the QOS subsystem and the <c>QOSHandle</c> parameter. The <c>QOSHandle</c> parameter is used when calling
	/// other QOS functions. <c>QOSCreateHandle</c> must be called before any other functions.
	/// </para>
	/// <para>QOSCloseHandle closes handles created by this function.</para>
	/// </summary>
	/// <param name="QOSHandle">Pointer to a variable that receives a safe QOS handle. This handle is used when calling other QOS functions.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_GEN_FAILURE</c></term>
	/// <term>
	/// Internal logic error. Initialization failed. For example, if the host goes into sleep or standby mode, all existing handles and flows
	/// are rendered invalid.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Indicates that a memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_RESOURCE_DISABLED</c></term>
	/// <term>
	/// A resource required by the service is unavailable. This error may be returned if the user has not enabled the firewall exception for
	/// the qWAVE service.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_SERVICE_DEPENDENCY_FAIL</c></term>
	/// <term>One of the dependencies of this service is unavailable. The qWAVE service could not be started.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Every process intending to use qWAVE must first call <c>QOSCreateHandle</c>. The handle returned can be used for performing
	/// overlapped I/O. For example, this handle can be associated with an I/O completion port (IOCP) to receive overlapped completion
	/// notifications. This function can be called multiple times to obtain multiple handles although a single handle is sufficient for most applications.
	/// </para>
	/// <para>
	/// If a machine enters a power save mode that interrupts connectivity such as sleep or standby, existing and active network experiments
	/// such as QOSStartTrackingClient must be reinitiated. This recreation of the flow mirrors the cleanup and creation activities also
	/// necessary for existing sockets. A new handle must be created, and the flow must be recreated and readmitted.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code illustrates function use and required parameter initializations. Actual values will vary depending on QoS version.
	/// </para>
	/// <para>Winsock.h must be included to use the WSAGetLastError function.</para>
	/// <para>See the Windows SDK for a complete sample code listing. SDK folder: Samples\NetDs\GQos\Qos2</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qoscreatehandle ExternC BOOL QOSCreateHandle( [in] PQOS_VERSION
	// Version, [out] PHANDLE QOSHandle );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSCreateHandle")]
	public static bool QOSCreateHandle(out SafeHQOS QOSHandle)
	{
		bool ret = QOSCreateHandle(new QOS_VERSION() { MajorVersion = 1 }, out HQOS h);
		QOSHandle = new((IntPtr)h, ret);
		return ret;
	}

	/// <summary>The <c>QOSEnumerateFlows</c> function enumerates all existing flows.</summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="Size">
	/// <para>Indicates the size of the <c>Buffer</c> parameter, in bytes.</para>
	/// <para>On function return, if successful, this parameter will specify the number of bytes copied into <c>Buffer</c>.</para>
	/// <para>
	/// If this call fails with <c>ERROR_INSUFFICIENT_BUFFER</c>, this parameter will indicate the minimum required <c>Buffer</c> size in
	/// order to successfully complete this operation.
	/// </para>
	/// </param>
	/// <param name="Buffer">Pointer to an array of <c>QOS_FlowId</c> flow identifiers. A <c>QOS_FlowId</c> is an unsigned 32-bit integer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// Buffer is too small. On output, <c>Size</c> will contain the minimum required buffer size. This function should then be called again
	/// with a buffer of the indicated size.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>DestAddr</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Indicates that a memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Successfully calling this function requires administrative privileges</para>
	/// <para>
	/// Calling the <c>QOSEnumerateFlows</c> function retrieves a list of <c>QOS_FlowId</c> s currently active on the QOS subsystem. These
	/// <c>QOS_FlowId</c> s could then be used to call the QOSQueryFlow function in order to gain more information on individual flows.
	/// </para>
	/// <para>
	/// This function has call-twice semantics. First call to get the <c>Buffer</c> size, then call again (with an appropriately sized
	/// <c>Buffer</c> if the first call failed with <c>ERROR_INSUFFICIENT_BUFFER</c>) to retrieve the list of flows. The second call may fail
	/// again with <c>ERROR_INSUFFICIENT_BUFFER</c> if new flows ere added since the first call.
	/// </para>
	/// <para>Flows from another process cannot be modified.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosenumerateflows ExternC BOOL QOSEnumerateFlows( [in] HANDLE
	// QOSHandle, [in, out] PULONG Size, [out] PVOID Buffer );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSEnumerateFlows")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSEnumerateFlows([In] HQOS QOSHandle, ref uint Size, [Out] IntPtr Buffer);

	/// <summary>The <c>QOSEnumerateFlows</c> function enumerates all existing flows.</summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <returns>An array of <c>QOS_FLOWID</c> flow identifiers expressed as <see cref="uint"/>.</returns>
	/// <remarks>
	/// <para>Successfully calling this function requires administrative privileges</para>
	/// <para>
	/// Calling the <c>QOSEnumerateFlows</c> function retrieves a list of <c>QOS_FlowId</c> s currently active on the QOS subsystem. These
	/// <c>QOS_FlowId</c> s could then be used to call the QOSQueryFlow function in order to gain more information on individual flows.
	/// </para>
	/// <para>Flows from another process cannot be modified.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosenumerateflows ExternC BOOL QOSEnumerateFlows( [in] HANDLE
	// QOSHandle, [in, out] PULONG Size, [out] PVOID Buffer );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSEnumerateFlows")]
	public static QOS_FLOWID[] QOSEnumerateFlows([In] HQOS QOSHandle)
	{
		uint sz = 256;
		using SafeCoTaskMemHandle mem = new(sz);

		while (true)
		{
			if (!QOSEnumerateFlows(QOSHandle, ref sz, mem))
			{
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
				mem.Size = sz;
			}
			else
			{
				return mem.ToArray<QOS_FLOWID>((int)sz / sizeof(uint));
			}
		}
	}

	/// <summary>
	/// The <c>QOSNotifyFlow</c> function registers the calling application to receive a notification about changes in network
	/// characteristics, such as congestion. Notifications may also be sent when a desired throughput is able to be achieved.
	/// </summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="FlowId">
	/// Specifies the flow identifier from which the application wishes to receive notifications. A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.
	/// </param>
	/// <param name="Operation">A QOS_NOTIFY_FLOW value that indicates what the type of notification being requested.</param>
	/// <param name="Size">
	/// <para>Indicates the size of the <c>Buffer</c> parameter, in bytes.</para>
	/// <para>On function return, if successful, this parameter will specify the number of bytes copied into <c>Buffer</c>.</para>
	/// <para>
	/// If this call fails with <c>ERROR_INSUFFICIENT_BUFFER</c>, this parameter will indicate the minimum required <c>Buffer</c> size in
	/// order to successfully complete this operation.
	/// </para>
	/// </param>
	/// <param name="Buffer">
	/// Pointer to a UINT64 that indicates the bandwidth at which point a notification will be sent. This parameter is only used if the
	/// <c>Operation</c> parameter is set to <c>QOSNotifyAvailable</c>. For the <c>QOSNotifyCongested</c> and <c>QOSNotifyUncongested</c>
	/// options, this parameter must be set to <c>NULL</c> on input.
	/// </param>
	/// <param name="Flags">Reserved for future use. This parameter must be set to 0.</param>
	/// <param name="Overlapped">
	/// Pointer to an OVERLAPPED structure used for asynchronous output. This must be se to <c>NULL</c> if this function is not being called asynchronously.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, a return value of nonzero is sent when the conditions set by the <c>Operation</c> parameter are met.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_ACCESS_DISABLED_BY_POLICY</c></term>
	/// <term>
	/// The QoS subsystem is currently configured by policy to not allow this operation on the network path between this host and the
	/// destination host. For example, the default policy prevents qWAVE experiments from running to off-link destinations.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>Indicates that notification request was successfully received. Results will be returned during overlapped completion.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>FlowId</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Indicates that a memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>Invalid <c>FlowId</c> specified.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>
	/// The operation being performed requires information that the QoS subsystem does not have. Obtaining this information on this network
	/// is currently not supported. For example, bandwidth estimations cannot be obtained on a network path where the destination host is off-link.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>The QOS subsystem has determined that the operation requested could not be completed on the network path specified.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_UNEXP_NET_ERR</c></term>
	/// <term>The network connection with the remote host failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ALREADY_EXISTS</c></term>
	/// <term>There is already a request for notifications of the same type pending on this flow.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>This function may be called asynchronously.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosnotifyflow ExternC BOOL QOSNotifyFlow( [in] HANDLE QOSHandle, [in]
	// QOS_FLOWID FlowId, [in] QOS_NOTIFY_FLOW Operation, [in, out, optional] PULONG Size, [in, out] PVOID Buffer, DWORD Flags, [out,
	// optional] LPOVERLAPPED Overlapped );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSNotifyFlow")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSNotifyFlow([In] HQOS QOSHandle, [In] QOS_FLOWID FlowId, [In] QOS_NOTIFY_FLOW Operation, ref uint Size,
		[In, Out, Optional] IntPtr Buffer, [Optional] uint Flags, ref NativeOverlapped Overlapped);

	/// <summary>
	/// The <c>QOSNotifyFlow</c> function registers the calling application to receive a notification about changes in network
	/// characteristics, such as congestion. Notifications may also be sent when a desired throughput is able to be achieved.
	/// </summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="FlowId">
	/// Specifies the flow identifier from which the application wishes to receive notifications. A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.
	/// </param>
	/// <param name="Operation">A QOS_NOTIFY_FLOW value that indicates what the type of notification being requested.</param>
	/// <param name="Size">
	/// <para>Indicates the size of the <c>Buffer</c> parameter, in bytes.</para>
	/// <para>On function return, if successful, this parameter will specify the number of bytes copied into <c>Buffer</c>.</para>
	/// <para>
	/// If this call fails with <c>ERROR_INSUFFICIENT_BUFFER</c>, this parameter will indicate the minimum required <c>Buffer</c> size in
	/// order to successfully complete this operation.
	/// </para>
	/// </param>
	/// <param name="Buffer">
	/// Pointer to a UINT64 that indicates the bandwidth at which point a notification will be sent. This parameter is only used if the
	/// <c>Operation</c> parameter is set to <c>QOSNotifyAvailable</c>. For the <c>QOSNotifyCongested</c> and <c>QOSNotifyUncongested</c>
	/// options, this parameter must be set to <c>NULL</c> on input.
	/// </param>
	/// <param name="Flags">Reserved for future use. This parameter must be set to 0.</param>
	/// <param name="Overlapped">
	/// Pointer to an OVERLAPPED structure used for asynchronous output. This must be se to <c>NULL</c> if this function is not being called asynchronously.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, a return value of nonzero is sent when the conditions set by the <c>Operation</c> parameter are met.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_ACCESS_DISABLED_BY_POLICY</c></term>
	/// <term>
	/// The QoS subsystem is currently configured by policy to not allow this operation on the network path between this host and the
	/// destination host. For example, the default policy prevents qWAVE experiments from running to off-link destinations.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>Indicates that notification request was successfully received. Results will be returned during overlapped completion.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>FlowId</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Indicates that a memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>Invalid <c>FlowId</c> specified.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>
	/// The operation being performed requires information that the QoS subsystem does not have. Obtaining this information on this network
	/// is currently not supported. For example, bandwidth estimations cannot be obtained on a network path where the destination host is off-link.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>The QOS subsystem has determined that the operation requested could not be completed on the network path specified.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_UNEXP_NET_ERR</c></term>
	/// <term>The network connection with the remote host failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ALREADY_EXISTS</c></term>
	/// <term>There is already a request for notifications of the same type pending on this flow.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>This function may be called asynchronously.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosnotifyflow ExternC BOOL QOSNotifyFlow( [in] HANDLE QOSHandle, [in]
	// QOS_FLOWID FlowId, [in] QOS_NOTIFY_FLOW Operation, [in, out, optional] PULONG Size, [in, out] PVOID Buffer, DWORD Flags, [out,
	// optional] LPOVERLAPPED Overlapped );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSNotifyFlow")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSNotifyFlow([In] HQOS QOSHandle, [In] QOS_FLOWID FlowId, [In] QOS_NOTIFY_FLOW Operation, ref uint Size,
		[In, Out, Optional] IntPtr Buffer, [Optional] uint Flags, [Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>QOSQueryFlow</c> function requests information about a specific flow added to the QoS subsystem. This function may be called asynchronously.
	/// </summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="FlowId">Specifies a flow identifier. A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.</param>
	/// <param name="Operation">
	/// <para>Specifies which type of flow information is being queried. This parameter specifies what structure the <c>Buffer</c> will contain.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>QOSQueryFlowFundamentals</c></term>
	/// <term><c>Buffer</c> will contain a QOS_FLOW_FUNDAMENTALS structure.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSQueryPacketPriority</c></term>
	/// <term><c>Buffer</c> will contain a QOS_PACKET_PRIORITY structure.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSQueryOutgoingRate</c></term>
	/// <term>
	/// <c>Buffer</c> will contain a <c>UINT64</c> value that indicates the flow rate specified when requesting the contract, in bits per second.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Size">
	/// <para>Indicates the size of the <c>Buffer</c> parameter, in bytes.</para>
	/// <para>On function return, if successful, this parameter will specify the number of bytes copied into <c>Buffer</c>.</para>
	/// <para>
	/// If this call fails with <c>ERROR_INSUFFICIENT_BUFFER</c>, this parameter will indicate the minimum required <c>Buffer</c> size in
	/// order to successfully complete this operation.
	/// </para>
	/// </param>
	/// <param name="Buffer">Pointer to the structure specified by the value of the <c>Operation</c> parameter.</param>
	/// <param name="Flags">
	/// <para>Flags pertaining to the data being returned.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>QOS_QUERYFLOW_FRESH</c></term>
	/// <term>
	/// The QOS subsystem will only return fresh, not cached, data. If fresh data is unavailable, it will try to obtain such data, at the
	/// expense of possibly taking more time. If this is not possible, the call will fail with the error code <c>ERROR_RETRY</c>. This flag
	/// is only applicable when the <c>Operation</c> parameter is set to <c>QOSQueryFlowFundamentals</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Overlapped">
	/// Pointer to an OVERLAPPED structure used for asynchronous output. This must be set to <c>NULL</c> if this function is not being called asynchronously.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_ACCESS_DISABLED_BY_POLICY</c></term>
	/// <term>
	/// The QoS subsystem is currently configured by policy to not allow this operation on the network path between this host and the
	/// destination host. For example, the default policy prevents qWAVE experiments from running to off-link destinations.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_TIMEOUT</c></term>
	/// <term>The request to the QOS subsystem timed out before enough useful information could be gathered.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The buffer length as specified by the <c>Size</c> parameter is not sufficient for the queried data. The <c>Size</c> parameter now
	/// contains the minimum required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>FlowId</c> parameter or <c>Buffer</c> size is insufficient.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>Invalid <c>FlowId</c> specified.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Indicates that a memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>
	/// The operation being performed requires information that the QoS subsystem does not have. Obtaining this information on this network
	/// is currently not supported. For example, bandwidth estimations cannot be obtained on a network path where the destination host is off-link.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>Indicates that the update flow request was successfully initiated.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_DATA</c></term>
	/// <term>The is no valid data to be returned.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_RETRY</c></term>
	/// <term>
	/// There is currently insufficient data about networking conditions to answer the query. This is typically a transient state where qWAVE
	/// has erred on the side of caution as it awaits more data before ascertaining the state of the network.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosqueryflow ExternC BOOL QOSQueryFlow( [in] HANDLE QOSHandle, [in]
	// QOS_FLOWID FlowId, [in] QOS_QUERY_FLOW Operation, [in, out] PULONG Size, [out] PVOID Buffer, [in, optional] DWORD Flags, [out,
	// optional] LPOVERLAPPED Overlapped );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSQueryFlow")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSQueryFlow([In] HQOS QOSHandle, [In] QOS_FLOWID FlowId, [In] QOS_QUERY_FLOW Operation, ref uint Size,
		[Out] IntPtr Buffer, [In, Optional] QOS_QUERYFLOW Flags, out NativeOverlapped Overlapped);

	/// <summary>
	/// The <c>QOSQueryFlow</c> function requests information about a specific flow added to the QoS subsystem. This function may be called asynchronously.
	/// </summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="FlowId">Specifies a flow identifier. A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.</param>
	/// <param name="Operation">
	/// <para>Specifies which type of flow information is being queried. This parameter specifies what structure the <c>Buffer</c> will contain.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>QOSQueryFlowFundamentals</c></term>
	/// <term><c>Buffer</c> will contain a QOS_FLOW_FUNDAMENTALS structure.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSQueryPacketPriority</c></term>
	/// <term><c>Buffer</c> will contain a QOS_PACKET_PRIORITY structure.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSQueryOutgoingRate</c></term>
	/// <term>
	/// <c>Buffer</c> will contain a <c>UINT64</c> value that indicates the flow rate specified when requesting the contract, in bits per second.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Size">
	/// <para>Indicates the size of the <c>Buffer</c> parameter, in bytes.</para>
	/// <para>On function return, if successful, this parameter will specify the number of bytes copied into <c>Buffer</c>.</para>
	/// <para>
	/// If this call fails with <c>ERROR_INSUFFICIENT_BUFFER</c>, this parameter will indicate the minimum required <c>Buffer</c> size in
	/// order to successfully complete this operation.
	/// </para>
	/// </param>
	/// <param name="Buffer">Pointer to the structure specified by the value of the <c>Operation</c> parameter.</param>
	/// <param name="Flags">
	/// <para>Flags pertaining to the data being returned.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>QOS_QUERYFLOW_FRESH</c></term>
	/// <term>
	/// The QOS subsystem will only return fresh, not cached, data. If fresh data is unavailable, it will try to obtain such data, at the
	/// expense of possibly taking more time. If this is not possible, the call will fail with the error code <c>ERROR_RETRY</c>. This flag
	/// is only applicable when the <c>Operation</c> parameter is set to <c>QOSQueryFlowFundamentals</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Overlapped">
	/// Pointer to an OVERLAPPED structure used for asynchronous output. This must be set to <c>NULL</c> if this function is not being called asynchronously.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_ACCESS_DISABLED_BY_POLICY</c></term>
	/// <term>
	/// The QoS subsystem is currently configured by policy to not allow this operation on the network path between this host and the
	/// destination host. For example, the default policy prevents qWAVE experiments from running to off-link destinations.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_TIMEOUT</c></term>
	/// <term>The request to the QOS subsystem timed out before enough useful information could be gathered.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The buffer length as specified by the <c>Size</c> parameter is not sufficient for the queried data. The <c>Size</c> parameter now
	/// contains the minimum required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>FlowId</c> parameter or <c>Buffer</c> size is insufficient.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>Invalid <c>FlowId</c> specified.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Indicates that a memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>
	/// The operation being performed requires information that the QoS subsystem does not have. Obtaining this information on this network
	/// is currently not supported. For example, bandwidth estimations cannot be obtained on a network path where the destination host is off-link.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>Indicates that the update flow request was successfully initiated.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_DATA</c></term>
	/// <term>The is no valid data to be returned.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_RETRY</c></term>
	/// <term>
	/// There is currently insufficient data about networking conditions to answer the query. This is typically a transient state where qWAVE
	/// has erred on the side of caution as it awaits more data before ascertaining the state of the network.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosqueryflow ExternC BOOL QOSQueryFlow( [in] HANDLE QOSHandle, [in]
	// QOS_FLOWID FlowId, [in] QOS_QUERY_FLOW Operation, [in, out] PULONG Size, [out] PVOID Buffer, [in, optional] DWORD Flags, [out,
	// optional] LPOVERLAPPED Overlapped );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSQueryFlow")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSQueryFlow([In] HQOS QOSHandle, [In] QOS_FLOWID FlowId, [In] QOS_QUERY_FLOW Operation, ref uint Size,
		[Out] IntPtr Buffer, [In, Optional] QOS_QUERYFLOW Flags, [Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>QOSQueryFlow</c> function requests information about a specific flow added to the QoS subsystem. This function may be called asynchronously.
	/// </summary>
	/// <typeparam name="TOut">The type of the out.</typeparam>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="FlowId">Specifies a flow identifier. A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.</param>
	/// <param name="Operation">
	/// <para>Specifies which type of flow information is being queried. This parameter specifies what structure the <c>Buffer</c> will contain.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>QOSQueryFlowFundamentals</c></term>
	/// <term><c>Buffer</c> will contain a QOS_FLOW_FUNDAMENTALS structure.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSQueryPacketPriority</c></term>
	/// <term><c>Buffer</c> will contain a QOS_PACKET_PRIORITY structure.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSQueryOutgoingRate</c></term>
	/// <term>
	/// <c>Buffer</c> will contain a <c>UINT64</c> value that indicates the flow rate specified when requesting the contract, in bits per second.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="fresh">
	/// If set to <see langword="true"/> the QOS subsystem will only return fresh, not cached, data. If fresh data is unavailable, it will
	/// try to obtain such data, at the expense of possibly taking more time. If this is not possible, the call will fail with the error code
	/// <c>ERROR_RETRY</c>. This flag is only applicable when the <c>Operation</c> parameter is set to <c>QOSQueryFlowFundamentals</c>.
	/// </param>
	/// <returns>The structure specified by the value of the <c>Operation</c> parameter and <typeparamref name="TOut"/>.</returns>
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSQueryFlow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static TOut QOSQueryFlow<TOut>([In] HQOS QOSHandle, [In] QOS_FLOWID FlowId, [In] QOS_QUERY_FLOW Operation, bool fresh = false) where TOut : struct
	{
		if (!CorrespondingTypeAttribute.CanGet(Operation, typeof(TOut)))
			throw new InvalidCastException();
		using var mem = new SafeCoTaskMemStruct<TOut>();
		uint sz = mem.Size;
		Win32Error.ThrowLastErrorIfFalse(QOSQueryFlow(QOSHandle, FlowId, Operation, ref sz, mem, fresh ? QOS_QUERYFLOW.QOS_QUERYFLOW_FRESH : 0, IntPtr.Zero));
		return mem.Value;
	}

	/// <summary>
	/// The <c>QOSRemoveSocketFromFlow</c> function notifies the QOS subsystem that a previously added flow has been terminated by the
	/// application, and that the subsystem must update its internal information accordingly.
	/// </summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="Socket">
	/// <para>Socket to be removed from the flow.</para>
	/// <para>
	/// Only flows created with the <c>QOS_NON_ADAPTIVE_FLOW</c> flag may have multiple sockets added to the same flow. By passing the
	/// <c>Socket</c> parameter in this call, each socket can be removed individually. If the <c>Socket</c> parameter is not passed, the
	/// entire flow will be destroyed. If only one socket was attached to the flow, passing this socket as a parameter to this function and
	/// passing <c>NULL</c> as a socket are equivalent calls.
	/// </para>
	/// </param>
	/// <param name="FlowId">A flow identifier. A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.</param>
	/// <param name="Flags">Reserved for future use. This parameter must be set to 0.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The <c>FlowId</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>A memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient system resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_OPERATION_ABORTED</c></term>
	/// <term>The request was blocked.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Calling the QOSCloseHandle function immediately aborts all pending operations and flows added by that handle. If a handle is closed
	/// while a <c>QOSRemoveSocketFromFlow</c> call is still progress, the call will complete with <c>ERROR_OPERATION_ABORTED</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code snippet demonstrates the use of <c>QOSRemoveSocketFromFlow</c>, QOSStopTrackingClient, and <c>QOSCloseHandle</c>
	/// in an application function used for "cleaning up" QoS resources. See QOSCreateHandle function for information on initialization of parameters.
	/// </para>
	/// <para>See the Windows SDK for a complete sample code listing. SDK folder: Samples\NetDs\GQos\Qos2</para>
	/// <para><c>Note</c> The winsock2.h header file must be included to use WSAGetLastError and other Winsock functions.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosremovesocketfromflow ExternC BOOL QOSRemoveSocketFromFlow( [in]
	// HANDLE QOSHandle, [in, optional] SOCKET Socket, [in] QOS_FLOWID FlowId, DWORD Flags );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSRemoveSocketFromFlow")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSRemoveSocketFromFlow([In] HQOS QOSHandle, [In, Optional] SOCKET Socket, [In] QOS_FLOWID FlowId, [Optional] uint Flags);

	/// <summary>
	/// The <c>QOSSetFlow</c> function is called by an application to request the QOS subsystem to prioritize the application's packets and
	/// change the flow traffic. This function is also used to notify the QoS subsystem of a flow change: for example, if the flow rate is
	/// changed in order to account for network congestion, or if the QoS priority value requires adjustment for transferring or streaming
	/// different types of content over a single persistent socket connection.
	/// </summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="FlowId">A flow identifier. A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.</param>
	/// <param name="Operation">
	/// <para>
	/// A QOS_SET_FLOW enumerated type that identifies what will be changed in the flow. This parameter specifies what structure the
	/// <c>Buffer</c> will contain.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>QOSSetTrafficType</c> 0</term>
	/// <term>The traffic type of the flow will be changed. The <c>Buffer</c> will contain a pointer to a QOS_TRAFFIC_TYPE constant.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSSetOutgoingRate</c> 1</term>
	/// <term>The flow rate will be changed. The <c>Buffer</c> will contain a pointer to a QOS_FLOWRATE_OUTGOING structure.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSSetOutgoingDSCPValue</c> 2</term>
	/// <term>
	/// Windows 7, Windows Server 2008 R2, and later: The outgoing DSCP value will be changed. The <c>Buffer</c> will contain a pointer to a
	/// <c>DWORD</c> value that defines the arbitrary DSCP value.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Size">The size of the <c>Buffer</c> parameter, in bytes.</param>
	/// <param name="Buffer">Pointer to the structure specified by the value of the <c>Operation</c> parameter.</param>
	/// <param name="Flags">Reserved for future use. This parameter must be set to 0.</param>
	/// <param name="Overlapped">
	/// Pointer to an OVERLAPPED structure used for asynchronous output. This must be set to <c>NULL</c> if this function is not being called asynchronously.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_ACCESS_DISABLED_BY_POLICY</c></term>
	/// <term>
	/// The QoS subsystem is currently configured by policy to not allow this operation on the network path between this host and the
	/// destination host. For example, the default policy prevents qWAVE experiments from running to off-link destinations.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>The update flow request was successfully received. Results will be returned during overlapped completion.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ACCESS_DENIED</c></term>
	/// <term>The calling application does not have sufficient privileges for the requested operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>FlowId</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NETWORK_BUSY</c></term>
	/// <term>The requested flow properties were not available on this path.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The <c>FlowId</c> parameter specified cannot be found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>A memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>
	/// The operation being performed requires information that the QoS subsystem does not have. Obtaining this information on this network
	/// is currently not supported. For example, bandwidth estimations cannot be obtained on a network path where the destination host is off-link.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_RETRY</c></term>
	/// <term>
	/// There is currently insufficient data about networking conditions to answer the query. This is typically a transient state where qWAVE
	/// has erred on the side of caution as it awaits more data before ascertaining the state of the network.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_UNEXP_NET_ERR</c></term>
	/// <term>The network connection with the remote host failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If QOSStartTrackingClient has not already been called, calling <c>QOSSetFlow</c> will cause the QOS subsystem to perform the following.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Discover whether the end-to-end network path supports prioritization.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Track end-to-end network characteristics by way of network experiments. These experiments do not place any noteworthy stress on the network.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>QOSSetFlow</c> returns <c>ERROR_NETWORK_BUSY</c> there is insufficient bandwidth for the specified flow rate and network
	/// priority cannot be granted. The application can still transmit a data stream but the flow will not receive priority marking. Ideally
	/// an application would not attempt to stream at the requested rate if there is insufficient bandwidth. If <c>ERROR_NETWORK_BUSY</c> is
	/// returned the following safe strategy is available:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Query the QoS subsystem with QOSNotifyFlow in order to determine the current available bandwidth and begin to stream at the received
	/// lower rate with priority if the network supports it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Request notification with QOSNotifyFlow for when the originally desired amount of bandwidth is available. When notification is
	/// received call <c>QOSSetFlow</c> with the new bandwidth request and send at the new rate again with prioritization if supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para>This function may optionally be called asynchronously.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following code snippet demonstrates the use of QOSSetFlow in an application. Input parameters <c>QOSHandle</c>, <c>FlowId</c>,
	/// <c>FlowId</c>, <c>QOSSetOutgoingRate</c>, and <c>sizeof</c>( <c>QoSOutgoingFlowrate</c>) must be previously initialized by other QoS
	/// functions and calculations within the application.
	/// </para>
	/// <para>Other QoS function examples that show initialization of parameters include QOSCreateHandle, QOSAddSocketToFlow, and QOSQueryFlow.</para>
	/// <para>See the Windows SDK for a complete sample code listing. SDK folder: Samples\NetDs\GQos\Qos2</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qossetflow ExternC BOOL QOSSetFlow( [in] HANDLE QOSHandle, [in]
	// QOS_FLOWID FlowId, [in] QOS_SET_FLOW Operation, [in] ULONG Size, [in] PVOID Buffer, DWORD Flags, [out, optional] LPOVERLAPPED
	// Overlapped );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSSetFlow")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSSetFlow([In] HQOS QOSHandle, [In] QOS_FLOWID FlowId, [In] QOS_SET_FLOW Operation, uint Size, [In] IntPtr Buffer,
		[Optional] uint Flags, out NativeOverlapped Overlapped);

	/// <summary>
	/// The <c>QOSSetFlow</c> function is called by an application to request the QOS subsystem to prioritize the application's packets and
	/// change the flow traffic. This function is also used to notify the QoS subsystem of a flow change: for example, if the flow rate is
	/// changed in order to account for network congestion, or if the QoS priority value requires adjustment for transferring or streaming
	/// different types of content over a single persistent socket connection.
	/// </summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="FlowId">A flow identifier. A <c>QOS_FLOWID</c> is an unsigned 32-bit integer.</param>
	/// <param name="Operation">
	/// <para>
	/// A QOS_SET_FLOW enumerated type that identifies what will be changed in the flow. This parameter specifies what structure the
	/// <c>Buffer</c> will contain.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>QOSSetTrafficType</c> 0</term>
	/// <term>The traffic type of the flow will be changed. The <c>Buffer</c> will contain a pointer to a QOS_TRAFFIC_TYPE constant.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSSetOutgoingRate</c> 1</term>
	/// <term>The flow rate will be changed. The <c>Buffer</c> will contain a pointer to a QOS_FLOWRATE_OUTGOING structure.</term>
	/// </item>
	/// <item>
	/// <term><c>QOSSetOutgoingDSCPValue</c> 2</term>
	/// <term>
	/// Windows 7, Windows Server 2008 R2, and later: The outgoing DSCP value will be changed. The <c>Buffer</c> will contain a pointer to a
	/// <c>DWORD</c> value that defines the arbitrary DSCP value.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Size">The size of the <c>Buffer</c> parameter, in bytes.</param>
	/// <param name="Buffer">Pointer to the structure specified by the value of the <c>Operation</c> parameter.</param>
	/// <param name="Flags">Reserved for future use. This parameter must be set to 0.</param>
	/// <param name="Overlapped">
	/// Pointer to an OVERLAPPED structure used for asynchronous output. This must be set to <c>NULL</c> if this function is not being called asynchronously.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_ACCESS_DISABLED_BY_POLICY</c></term>
	/// <term>
	/// The QoS subsystem is currently configured by policy to not allow this operation on the network path between this host and the
	/// destination host. For example, the default policy prevents qWAVE experiments from running to off-link destinations.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>The update flow request was successfully received. Results will be returned during overlapped completion.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ACCESS_DENIED</c></term>
	/// <term>The calling application does not have sufficient privileges for the requested operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>FlowId</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NETWORK_BUSY</c></term>
	/// <term>The requested flow properties were not available on this path.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The <c>FlowId</c> parameter specified cannot be found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>A memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>
	/// The operation being performed requires information that the QoS subsystem does not have. Obtaining this information on this network
	/// is currently not supported. For example, bandwidth estimations cannot be obtained on a network path where the destination host is off-link.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_RETRY</c></term>
	/// <term>
	/// There is currently insufficient data about networking conditions to answer the query. This is typically a transient state where qWAVE
	/// has erred on the side of caution as it awaits more data before ascertaining the state of the network.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_UNEXP_NET_ERR</c></term>
	/// <term>The network connection with the remote host failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If QOSStartTrackingClient has not already been called, calling <c>QOSSetFlow</c> will cause the QOS subsystem to perform the following.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Discover whether the end-to-end network path supports prioritization.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Track end-to-end network characteristics by way of network experiments. These experiments do not place any noteworthy stress on the network.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>QOSSetFlow</c> returns <c>ERROR_NETWORK_BUSY</c> there is insufficient bandwidth for the specified flow rate and network
	/// priority cannot be granted. The application can still transmit a data stream but the flow will not receive priority marking. Ideally
	/// an application would not attempt to stream at the requested rate if there is insufficient bandwidth. If <c>ERROR_NETWORK_BUSY</c> is
	/// returned the following safe strategy is available:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Query the QoS subsystem with QOSNotifyFlow in order to determine the current available bandwidth and begin to stream at the received
	/// lower rate with priority if the network supports it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Request notification with QOSNotifyFlow for when the originally desired amount of bandwidth is available. When notification is
	/// received call <c>QOSSetFlow</c> with the new bandwidth request and send at the new rate again with prioritization if supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para>This function may optionally be called asynchronously.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following code snippet demonstrates the use of QOSSetFlow in an application. Input parameters <c>QOSHandle</c>, <c>FlowId</c>,
	/// <c>FlowId</c>, <c>QOSSetOutgoingRate</c>, and <c>sizeof</c>( <c>QoSOutgoingFlowrate</c>) must be previously initialized by other QoS
	/// functions and calculations within the application.
	/// </para>
	/// <para>Other QoS function examples that show initialization of parameters include QOSCreateHandle, QOSAddSocketToFlow, and QOSQueryFlow.</para>
	/// <para>See the Windows SDK for a complete sample code listing. SDK folder: Samples\NetDs\GQos\Qos2</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qossetflow ExternC BOOL QOSSetFlow( [in] HANDLE QOSHandle, [in]
	// QOS_FLOWID FlowId, [in] QOS_SET_FLOW Operation, [in] ULONG Size, [in] PVOID Buffer, DWORD Flags, [out, optional] LPOVERLAPPED
	// Overlapped );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSSetFlow")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSSetFlow([In] HQOS QOSHandle, [In] QOS_FLOWID FlowId, [In] QOS_SET_FLOW Operation, uint Size, [In] IntPtr Buffer,
		[Optional] uint Flags, [Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>QOSStartTrackingClient</c> function notifies the QOS subsystem of the existence of a new client. Calling this function
	/// increases the likelihood that the QOS subsystem will have gathered sufficient information on the network path to assist when calling
	/// QOSSetFlow to set the flow.
	/// </summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="DestAddr">
	/// A pointer to a sockaddr structure that contains the IP address of the client device. Clients are identified by their IP address and
	/// address family. Any port number specified in the sockaddr structure will be ignored.
	/// </param>
	/// <param name="Flags">Reserved for future use. Must be set to 0.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>DestAddr</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Indicates that a memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDED</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>The request is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HOST_UNREACHABLE</c></term>
	/// <term>The network location cannot be reached.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// On receipt of a <c>QOSStartTrackingClient</c> call the QoS subsystem begins gathering information about the client such as the QoS
	/// capabilities and available bandwidth on the end-to-end path.
	/// </para>
	/// <para>
	/// An application should call this function as soon as it becomes aware of a client device that may need QoS flow. For example this
	/// function should be called when a media player device first connects to a media server application.
	/// </para>
	/// <para>
	/// Network experiments performed by <c>QOSStartTrackingClient</c> do not introduce noteworthy load on the network even if no stream is
	/// started for a long period of time. The qWAVE service dynamically adjusts experiment traffic based on QoS subsystem activity.
	/// </para>
	/// <para>Link Layer Topology Discovery (LLTD) must be implemented on the sink PC or device for this function to work.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following code illustrates function use, handling a common exception, and required parameter initializations. Actual parameter
	/// values can vary depending on QoS version. The Winsock2.h header file must be included to use Winsock defined identifiers or functions.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosstarttrackingclient ExternC BOOL QOSStartTrackingClient( [in]
	// HANDLE QOSHandle, [in] PSOCKADDR DestAddr, DWORD Flags );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSStartTrackingClient")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSStartTrackingClient([In] HQOS QOSHandle, [In] SOCKADDR DestAddr, [Optional] uint Flags);

	/// <summary>
	/// The <c>QOSStopTrackingClient</c> function notifies the QoS subsystem to stop tracking a client that has previously used the
	/// QOSStartTrackingClient function. If a flow is currently in progress, this function will not affect it.
	/// </summary>
	/// <param name="QOSHandle">Handle to the QOS subsystem returned by QOSCreateHandle.</param>
	/// <param name="DestAddr">
	/// Pointer to a sockaddr structure that contains the IP address of the client device. Clients are identified by their IP address and
	/// address family. A port number is not required and will be ignored.
	/// </param>
	/// <param name="Flags">Reserved for future use.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is 0. To get extended error information, call <c>GetLastError</c>. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>QOSHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>DestAddr</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Indicates that a memory allocation failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are insufficient resources to carry out the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_DEVICE</c></term>
	/// <term>The request could not be performed because of an I/O device error.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_REINITIALIZATION_NEEDER</c></term>
	/// <term>
	/// The indicated device requires reinitialization due to hardware errors. The application should clean up and call QOSCreateHandle again.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ADAP_HDW_ERR</c></term>
	/// <term>A network adapter hardware error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The Winsock2.h header file must be included to use Winsock defined identifiers or functions.</para>
	/// <para>Examples</para>
	/// <para>The following code shows this function called in an application setting. See QOSStartTrackingClient for parameter information.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/nf-qos2-qosstoptrackingclient ExternC BOOL QOSStopTrackingClient( [in] HANDLE
	// QOSHandle, [in] PSOCKADDR DestAddr, DWORD Flags );
	[PInvokeData("qos2.h", MSDNShortId = "NF:qos2.QOSStopTrackingClient")]
	[DllImport(Lib_Qwave, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QOSStopTrackingClient([In] HQOS QOSHandle, [In] SOCKADDR DestAddr, [Optional] uint Flags);

	private static int QOS_HEADER_OVERHEAD(ADDRESS_FAMILY af, IPPROTO protocol) =>
			(af == ADDRESS_FAMILY.AF_INET ? 20 : 40) + (protocol == IPPROTO.IPPROTO_TCP ? 20 : 8);

	/// <summary>Provides a handle to a QOS session.</summary>
	[PInvokeData("qos2.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HQOS : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HQOS"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HQOS(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HQOS"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HQOS NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HQOS h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HQOS"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HQOS h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HQOS"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HQOS(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HQOS h1, HQOS h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HQOS h1, HQOS h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HQOS h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>The <c>QOS_FLOW_FUNDAMENTALS</c> structure contains basic information about a flow.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ns-qos2-qos_flow_fundamentals typedef struct _QOS_FLOW_FUNDAMENTALS { BOOL
	// BottleneckBandwidthSet; UINT64 BottleneckBandwidth; BOOL AvailableBandwidthSet; UINT64 AvailableBandwidth; BOOL RTTSet; UINT32 RTT; }
	// QOS_FLOW_FUNDAMENTALS, *PQOS_FLOW_FUNDAMENTALS;
	[PInvokeData("qos2.h", MSDNShortId = "NS:qos2._QOS_FLOW_FUNDAMENTALS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_FLOW_FUNDAMENTALS
	{
		/// <summary>This Boolean value is set to <c>TRUE</c> if the <c>BottleneckBandwidth</c> field contains a value.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool BottleneckBandwidthSet;

		/// <summary>Indicates the maximum end-to-end link capacity between the source and sink device, in bits.</summary>
		public ulong BottleneckBandwidth;

		/// <summary>Set to <c>TRUE</c> if the <c>AvailableBandwidth</c> field contains a value.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AvailableBandwidthSet;

		/// <summary>
		/// Indicates how much bandwidth is available for submitting traffic on the end-to-end network path between the source and sink
		/// device, in bits.
		/// </summary>
		public ulong AvailableBandwidth;

		/// <summary>Set to <c>TRUE</c> if the <c>RTT</c> field contains a value.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool RTTSet;

		/// <summary>Measures the round-trip time between the source and sink device, in microseconds.</summary>
		public uint RTT;
	}

	/// <summary>The <c>QOS_FLOWRATE_OUTGOING</c> structure is used to set flow rate information in the QOSSetFlow function.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ns-qos2-qos_flowrate_outgoing typedef struct _QOS_FLOWRATE_OUTGOING { UINT64
	// Bandwidth; QOS_SHAPING ShapingBehavior; QOS_FLOWRATE_REASON Reason; } QOS_FLOWRATE_OUTGOING, *PQOS_FLOWRATE_OUTGOING;
	[PInvokeData("qos2.h", MSDNShortId = "NS:qos2._QOS_FLOWRATE_OUTGOING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_FLOWRATE_OUTGOING
	{
		/// <summary>
		/// <para>The rate at which data should be sent, in units of bits per second.</para>
		/// <para>
		/// <c>Note</c> Traffic on the network is measured at the IP level, and not at the application level. The rate that is specified
		/// should account for the IP and protocol headers.
		/// </para>
		/// </summary>
		public ulong Bandwidth;

		/// <summary>A QOS_SHAPING constant that defines the shaping behavior of the flow.</summary>
		public QOS_SHAPING ShapingBehavior;

		/// <summary>A QOS_FLOWRATE_REASON constant that indicates the reason for a flow rate change.</summary>
		public QOS_FLOWRATE_REASON Reason;
	}

	/// <summary>The <c>QOS_PACKET_PRIORITY</c> structure that indicates the priority of the flow traffic.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ns-qos2-qos_packet_priority typedef struct _QOS_PACKET_PRIORITY { ULONG
	// ConformantDSCPValue; ULONG NonConformantDSCPValue; ULONG ConformantL2Value; ULONG NonConformantL2Value; } QOS_PACKET_PRIORITY, *PQOS_PACKET_PRIORITY;
	[PInvokeData("qos2.h", MSDNShortId = "NS:qos2._QOS_PACKET_PRIORITY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_PACKET_PRIORITY
	{
		/// <summary>Differential Services Code Point (DSCP) mark used for flow traffic that conforms to the specified flow rate.</summary>
		public uint ConformantDSCPValue;

		/// <summary>
		/// DSCP marking used for flow traffic that exceeds the specified flow rate. Non-conformant DSCP values are only applicable only if
		/// QOS_SHAPING has a value of <c>QOSUseNonConformantMarkings</c>.
		/// </summary>
		public uint NonConformantDSCPValue;

		/// <summary>
		/// Layer-2 (L2) tag used for flow traffic that conforms to the specified flow rate. L2 tags will not be added to packets if the
		/// end-to-end path between source and sink does not support them.
		/// </summary>
		public uint ConformantL2Value;

		/// <summary>
		/// L2 tag used for flow traffic that exceeds the specified flow rate. Non-conformant L2 values are only applicable if QOS_SHAPING
		/// has a value of <c>QOSUseNonConformantMarkings</c>.
		/// </summary>
		public uint NonConformantL2Value;
	}

	/// <summary>The <c>QOS_VERSION</c> structure indicates the version of the QOS protocol.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos2/ns-qos2-qos_version typedef struct _QOS_VERSION { USHORT MajorVersion; USHORT
	// MinorVersion; } QOS_VERSION, *PQOS_VERSION;
	[PInvokeData("qos2.h", MSDNShortId = "NS:qos2._QOS_VERSION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_VERSION
	{
		/// <summary>Major version of the QOS protocol.</summary>
		public ushort MajorVersion;

		/// <summary>Minor version of the QOS protocol.</summary>
		public ushort MinorVersion;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HQOS"/> that is disposed using <see cref="QOSCloseHandle"/>.</summary>
	public class SafeHQOS : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHQOS"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHQOS(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHQOS"/> class.</summary>
		private SafeHQOS() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHQOS"/> to <see cref="HQOS"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HQOS(SafeHQOS h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => QOSCloseHandle(handle);
	}
}