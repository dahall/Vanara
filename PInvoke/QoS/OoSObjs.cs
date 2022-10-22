namespace Vanara.PInvoke;

/// <summary>Items from Qwave.dll.</summary>
public static partial class Qwave
{
	private const int QOS_MAX_OBJECT_STRING_LENGTH = 256;

	/// <summary>
	/// The <c>QOS_DIFFSERV</c> traffic control object is used to specify filters for the packet scheduler when it operates in Differentiated
	/// Services Mode.
	/// </summary>
	/// <remarks>
	/// The <c>QOS_DIFFSERV</c> object is used to specify the set of Diffserv rules that apply to the specified flow, all of which are
	/// specified in the <c>DiffservRule</c> member. Each Diffserv rule has an InboundDSField value, which signifies the DSCP on the Inbound
	/// packet. The Diffserv Rules also have OutboundDSCP and UserPriority values for conforming and nonconforming packets. These indicate
	/// the DSCP and 802.1p values that go out on the forwarded packet. Note that the DSCP or UserPriority mapping based on ServiceType or
	/// <c>QOS_DS_CLASS</c> or <c>QOS_TRAFFIC_CLASS</c> is not used in this mode.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qosobjs/ns-qosobjs-qos_diffserv typedef struct _QOS_DIFFSERV { QOS_OBJECT_HDR
	// ObjectHdr; ULONG DSFieldCount; UCHAR DiffservRule[1]; } QOS_DIFFSERV, *LPQOS_DIFFSERV;
	[PInvokeData("qosobjs.h", MSDNShortId = "NS:qosobjs._QOS_DIFFSERV")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<QOS_DIFFSERV>), nameof(DSFieldCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_DIFFSERV : IQoSObjectHdr
	{
		/// <summary>The QOS object <c>QOS_OBJECT_HDR</c>. The object type for this traffic control object should be QOS_OBJECT_DIFFSERV.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>Number of Diffserv Rules in this object.</summary>
		public uint DSFieldCount;

		/// <summary>Array of QOS_DIFFSERV_RULE structures.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] DiffservRule;
	}

	/// <summary>
	/// The <c>QOS_DIFFSERV_RULE</c> structure is used in conjunction with the traffic control object QOS_DIFFSERV to provide Diffserv rules
	/// for a given flow.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qosobjs/ns-qosobjs-qos_diffserv_rule typedef struct _QOS_DIFFSERV_RULE { UCHAR
	// InboundDSField; UCHAR ConformingOutboundDSField; UCHAR NonConformingOutboundDSField; UCHAR ConformingUserPriority; UCHAR
	// NonConformingUserPriority; } QOS_DIFFSERV_RULE, *LPQOS_DIFFSERV_RULE;
	[PInvokeData("qosobjs.h", MSDNShortId = "NS:qosobjs._QOS_DIFFSERV_RULE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_DIFFSERV_RULE
	{
		/// <summary>
		/// <para>
		/// Diffserv code point (DSCP) on the inbound packet. <c>InboundDSField</c> must be unique for the interface, otherwise the flow
		/// addition will fail.
		/// </para>
		/// <para>Valid range is 0x00 - 0x3F.</para>
		/// </summary>
		public byte InboundDSField;

		/// <summary>
		/// <para>
		/// Diffserv code point (DSCP) marked on all conforming packets on the flow. This member can be used to remark the packet before it
		/// is forwarded.
		/// </para>
		/// <para>Valid range is 0x00 - 0x3F.</para>
		/// </summary>
		public byte ConformingOutboundDSField;

		/// <summary>
		/// <para>
		/// Diffserv code point (DSCP) marked on all nonconforming packets on the flow. This member can be used to remark the packet before
		/// it is forwarded.
		/// </para>
		/// <para>Valid range is 0x00 - 0x3F.</para>
		/// </summary>
		public byte NonConformingOutboundDSField;

		/// <summary>
		/// <para>
		/// UserPriority value marked on all conforming packets on the flow. This member can be used to remark the packet before it is forwarded.
		/// </para>
		/// <para>Valid range is 0-7</para>
		/// </summary>
		public byte ConformingUserPriority;

		/// <summary>
		/// <para>
		/// UserPriority value marked on all nonconforming packets on the flow. This member can be used to remark the packet before it is forwarded.
		/// </para>
		/// <para>Valid range is 0-7</para>
		/// </summary>
		public byte NonConformingUserPriority;
	}

	/// <summary>
	/// The traffic control object <c>QOS_DS_CLASS</c> enables application developers to override the default Diffserv code point (DSCP)
	/// value for the IP packets associated with a given flow. By default, the DSCP value is derived from the flow's ServiceType.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qosobjs/ns-qosobjs-qos_ds_class typedef struct _QOS_DS_CLASS { QOS_OBJECT_HDR
	// ObjectHdr; ULONG DSField; } QOS_DS_CLASS, *LPQOS_DS_CLASS;
	[PInvokeData("qosobjs.h", MSDNShortId = "NS:qosobjs._QOS_DS_CLASS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_DS_CLASS : IQoSObjectHdr
	{
		/// <summary>The QOS object QOS_OBJECT_HDR. The object type for this traffic control object should be <c>QOS_OBJECT_DS_CLASS</c>.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>
		/// <para>
		/// User priority value for the flow. The valid range is 0x00 through 0x3F. The following settings are chosen (by default) when the
		/// <c>QOS_DS_CLASS</c> traffic control object is not used.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>ServiceTypeBestEffort, ServiceTypeQualitative</term>
		/// </item>
		/// <item>
		/// <term>0x18</term>
		/// <term>ServiceTypeControlledLoad</term>
		/// </item>
		/// <item>
		/// <term>0x28</term>
		/// <term>ServiceTypeGuaranteed</term>
		/// </item>
		/// <item>
		/// <term>0x30</term>
		/// <term>ServiceTypeNetworkControl</term>
		/// </item>
		/// <item>
		/// <term>0x00</term>
		/// <term>Non-conformant traffic</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint DSField;
	}

	/// <summary>The <c>QOS_FRIENDLY_NAME</c> traffic control object associates a friendly name with flow.</summary>
	/// <remarks>
	/// Programmers are encouraged to use the <c>QOS_FRIENDLY_NAME</c> traffic control object to associate flows with their applications.
	/// This approach enables management applications to identify and associate enumerated flows with corresponding applications.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qosobjs/ns-qosobjs-qos_friendly_name typedef struct _QOS_FRIENDLY_NAME {
	// QOS_OBJECT_HDR ObjectHdr; WCHAR FriendlyName[QOS_MAX_OBJECT_STRING_LENGTH]; } QOS_FRIENDLY_NAME, *LPQOS_FRIENDLY_NAME;
	[PInvokeData("qosobjs.h", MSDNShortId = "NS:qosobjs._QOS_FRIENDLY_NAME")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct QOS_FRIENDLY_NAME : IQoSObjectHdr
	{
		/// <summary>The QOS object QOS_OBJECT_HDR. The object type for this traffic control object should be <c>QOS_OBJECT_FRIENDLY_NAME</c>.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>Name to be associated with the flow.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = QOS_MAX_OBJECT_STRING_LENGTH)]
		public string FriendlyName;
	}

	/// <summary>
	/// The <c>QOS_TCP_TRAFFIC</c> structure is used to indicate that IP Precedence and UserPriority mappings for a given flow must be set to
	/// system defaults for TCP traffic.
	/// </summary>
	/// <remarks>
	/// When the <c>QOS_TCP_TRAFFIC</c> object is passed, the <c>DSField</c> mapping and <c>UserPriorityMapping</c> of <c>ServiceType</c> are
	/// ignored, as are QOS_OBJECT_DS_CLASS and QOS_OBJECT_TRAFFIC_CLASS.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qosobjs/ns-qosobjs-qos_tcp_traffic typedef struct _QOS_TCP_TRAFFIC {
	// QOS_OBJECT_HDR ObjectHdr; } QOS_TCP_TRAFFIC, *LPQOS_TCP_TRAFFIC;
	[PInvokeData("qosobjs.h", MSDNShortId = "NS:qosobjs._QOS_TCP_TRAFFIC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_TCP_TRAFFIC : IQoSObjectHdr
	{
		/// <summary>A QOS object header.</summary>
		public QOS_OBJECT_HDR ObjectHdr;
	}

	/// <summary>
	/// <para>
	/// The traffic control object <c>QOS_TRAFFIC_CLASS</c> is used to override the default UserPriority value ascribed to packets that
	/// classify the traffic of a given flow.
	/// </para>
	/// <para>
	/// By default, the UserPriority value of a flow is derived from the ServiceType (see: FLOWSPEC). Therefore, it is often necessary to
	/// override the default UserPriority because packets can be tagged in their Layer 2 headers (such as an 802.1p header) to specify their
	/// priority to Layer-2 devices. Using <c>QOS_TRAFFIC_CLASS</c> enables application developers to override the default UserPriority setting.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>Traffic Control:</c> The following <c>ServiceType</c> enumeration values are invalid when specifically working with Traffic Control.
	/// </para>
	/// <list/>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qosobjs/ns-qosobjs-qos_traffic_class typedef struct _QOS_TRAFFIC_CLASS {
	// QOS_OBJECT_HDR ObjectHdr; ULONG TrafficClass; } QOS_TRAFFIC_CLASS, *LPQOS_TRAFFIC_CLASS;
	[PInvokeData("qosobjs.h", MSDNShortId = "NS:qosobjs._QOS_TRAFFIC_CLASS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_TRAFFIC_CLASS : IQoSObjectHdr
	{
		/// <summary>The QOS object QOS_OBJECT_HDR. The object type for this traffic control object should be <c>QOS_OBJECT_TRAFFIC_CLASS</c>.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>
		/// <para>
		/// User priority value of the flow. The valid range is zero through seven. The following settings are chosen (by default) when the
		/// <c>QOS_TRAFFIC_CLASS</c> traffic control object is not used.
		/// </para>
		/// <para>
		/// <c>Note</c> This parameter specifies an 802.1 TrafficClass parameter which has been provided to the host by a layer 2 network in
		/// an 802.1 extended RSVP RESV message. If this object is obtained from the network, hosts will stamp the MAC headers of
		/// corresponding transmitted packets, with the value in the object. Otherwise, hosts can select a value based on the standard
		/// Intserv mapping of ServiceType to 802.1 TrafficClass.
		/// </para>
		/// <para>SERVICETYPE_BESTEFFORT (0x00000001)</para>
		/// <para>SERVICETYPE_CONTROLLEDLOAD (0x00000002)</para>
		/// <para>SERVICETYPE_GUARANTEED (0x00000003)</para>
		/// <para>SERVICETYPE_NONCONFORMING (0x00000009)</para>
		/// <para>SERVICETYPE_NETWORK_CONTROL (0x0000000A)</para>
		/// <para>SERVICETYPE_QUALITATIVE (0x0000000D)</para>
		/// </summary>
		public uint TrafficClass;
	}
}