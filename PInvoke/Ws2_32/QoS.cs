namespace Vanara.PInvoke;

public static partial class Ws2_32
{
	/// <summary>
	/// Define a value that can be used for the PeakBandwidth, which will map into positive infinity when the FLOWSPEC is converted into
	/// IntServ floating point format. We can't use (-1) because that value was previously defined to mean "select the default".
	/// </summary>
	public const uint POSITIVE_INFINITY_RATE = 0xFFFFFFFE;

	/// <summary>
	/// This value can be used in the FLOWSPEC structure to instruct the Rsvp Service provider to derive the appropriate default value for
	/// the parameter. Note that not all values in the FLOWSPEC structure can be defaults. In the ReceivingFlowspec, all parameters can be
	/// defaulted except the ServiceType. In the SendingFlowspec, the MaxSduSize and MinimumPolicedSize can be defaulted. Other defaults may
	/// be possible. Refer to the appropriate documentation.
	/// </summary>
	public const uint QOS_NOT_SPECIFIED = 0xFFFFFFFF;

	/// <summary>To turn off traffic control, 'OR' ( | ) this flag with the ServiceType field in the FLOWSPEC</summary>
	public const uint SERVICE_NO_TRAFFIC_CONTROL = 0x81000000;

	/// <summary>Specifies the level of service to negotiate for the flow.</summary>
	[PInvokeData("qos.h", MSDNShortId = "268e0d3a-2b04-40fd-91eb-f1780236b3e4")]
	public enum SERVICETYPE : uint
	{
		/// <summary>
		/// Indicates that no traffic will be transmitted in the specified direction. On duplex-capable media, this value signals
		/// underlying software to set up unidirectional connections only. This service type is not valid for the TC API.
		/// </summary>
		SERVICETYPE_NOTRAFFIC = 0x00000000,

		/// <summary>
		/// Results in no action taken by the RSVP SP. Traffic control does create a BESTEFFORT flow, however, and traffic on the flow
		/// will be handled by traffic control similarly to other BESTEFFORT traffic.
		/// </summary>
		SERVICETYPE_BESTEFFORT = 0x00000001,

		/// <summary>
		/// Provides an end-to-end QOS that closely approximates transmission quality provided by best-effort service, as expected under
		/// unloaded conditions from the associated network components along the data path.
		/// <para>Applications that use SERVICETYPE_CONTROLLEDLOAD may therefore assume the following:</para>
		/// <list type="bullet">
		/// <item>
		/// The network will deliver a very high percentage of transmitted packets to its intended receivers. In other words, packet loss
		/// will closely approximate the basic packet error rate of the transmission medium.
		/// </item>
		/// <item>
		/// Transmission delay for a very high percentage of the delivered packets will not greatly exceed the minimum transit delay
		/// experienced by any successfully delivered packet.
		/// </item>
		/// </list>
		/// </summary>
		SERVICETYPE_CONTROLLEDLOAD = 0x00000002,

		/// <summary>
		/// Guarantees that datagrams will arrive within the guaranteed delivery time and will not be discarded due to queue overflows,
		/// provided the flow's traffic stays within its specified traffic parameters. This service is intended for applications that
		/// need a firm guarantee that a datagram will arrive no later than a certain time after it was transmitted by its source.
		/// </summary>
		SERVICETYPE_GUARANTEED = 0x00000003,

		/// <summary>Used to notify network changes.</summary>
		SERVICETYPE_NETWORK_UNAVAILABLE = 0x00000004,

		/// <summary>Specifies that all service types are supported for a flow. Can be used on sender side only.</summary>
		SERVICETYPE_GENERAL_INFORMATION = 0x00000005,

		/// <summary>
		/// Indicates that the quality of service in the transmission using this ServiceType value is not changed. SERVICETYPE_NOCHANGE
		/// can be used when requesting a change in the quality of service for one direction only, or when requesting a change only
		/// within the ProviderSpecific parameters of a QOS specification, and not in the SendingFlowspec or ReceivingFlowspec.
		/// </summary>
		SERVICETYPE_NOCHANGE = 0x00000006,

		/// <summary>Used to indicate nonconforming traffic.</summary>
		SERVICETYPE_NONCONFORMING = 0x00000009,

		/// <summary>
		/// Used only for transmission of control packets (such as RSVP signaling messages). This ServiceType has the highest priority.
		/// </summary>
		SERVICETYPE_NETWORK_CONTROL = 0x0000000A,

		/// <summary>
		/// Indicates that the application requires better than BESTEFFORT transmission, but cannot quantify its transmission
		/// requirements. Applications that use SERVICETYPE_QUALITATIVE can supply an application identifier policy object. The
		/// application identification policy object enables policy servers on the network to identify the application, and accordingly,
		/// assign an appropriate quality of service to the request. For more information on application identification, consult the IETF
		/// Internet Draft draft-ietf-rap-rsvp-appid-00.txt, or the Microsoft white paper on Application Identification. Traffic control
		/// treats flows of this type with the same priority as BESTEFFORT traffic on the local computer. However, application
		/// programmers can get boosted priority for such flows by modifying the Layer 2 settings on the associated flow using the
		/// QOS_TRAFFIC_CLASS QOS object.
		/// </summary>
		SERVICETYPE_QUALITATIVE = 0x0000000D,

		/// <summary>Indicates that traffic control should not be invoked in the specified direction.</summary>
		SERVICE_NO_TRAFFIC_CONTROL = 0x81000000,

		/// <summary>Suppresses RSVP signaling in the specified direction.</summary>
		SERVICE_NO_QOS_SIGNALING = 0x40000000
	}

	/// <summary>
	/// <para>
	/// The <c>FLOWSPEC</c> structure provides quality of service parameters to the RSVP SP. This allows QOS-aware applications to
	/// invoke, modify, or remove QOS settings for a given flow. Some members of <c>FLOWSPEC</c> can be set to default values. See
	/// Remarks for more information.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Many members of the <c>FLOWSPEC</c> structure can be set to default values by setting the member to QOS_NOT_SPECIFIED. Note that
	/// the members that can be set to default values differ depending on whether the <c>FLOWSPEC</c> is a receiving <c>FLOWSPEC</c> or a
	/// sending <c>FLOWSPEC</c>.
	/// </para>
	/// <para>There are a handful of considerations you should keep in mind when using <c>FLOWSPEC</c> with traffic control:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <c>TokenRate</c> can be QOS_NOT_SPECIFIED for SERVICETYPE_NETWORKCONTROL, SERVICETYPE_QUALITATIVE, and SERVICETYPE_BESTEFFORT.
	/// <c>TokenRate</c> must be valid for all other <c>ServiceType</c> values.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If <c>PeakBandwidth</c> is specified, it must be greater than or equal to <c>TokenRate</c>.</term>
	/// </item>
	/// </list>
	/// <para>Many settings can be defaulted in a receiving <c>FLOWSPEC</c> except <c>ServiceType</c>, with the following considerations:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>For a Controlled Load Service receiver, the default values are derived from the sender <c>TSPEC</c>.</term>
	/// </item>
	/// <item>
	/// <term>For a Guaranteed Service receiver, <c>ServiceType</c> and <c>TokenRate</c> must be specified.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The following list specifies the values that are applied when a receiving <c>FLOWSPEC</c> sets the corresponding values to default:
	/// </para>
	/// <para>When the value of the <c>ServiceType</c> is set to SERVICETYPE_GUARANTEED, the following also applies:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The RATE value in <c>RSPEC</c> is set to the value of TokenRate.</term>
	/// </item>
	/// <item>
	/// <term>The DELAYSLACKTERM value in <c>RSPEC</c> is set to DelayVariation, which is set to zero if DelayVariation is set to QOS_NOT_SPECIFIED.</term>
	/// </item>
	/// <item>
	/// <term>
	/// For receivers requesting SERVICETYPE_GUARANTEED, the receiving TokenRate must be specified. This contrasts with a
	/// SERVICETYPE_CONTROLLEDLOAD receiver, for which TokenRate may be set to QOS_NOT_SPECIFIED.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// In a sending <c>FLOWSPEC</c>, everything can be defaulted except <c>ServiceType</c> and <c>TokenRate</c>. The following list
	/// specifies the values that are applied when a sending <c>FLOWSPEC</c> sets the corresponding values to default:
	/// </para>
	/// <para>
	/// <c>Traffic Control:</c> The following <c>ServiceType</c> s are invalid when specifically working with Traffic Control. If you are
	/// unsure whether you are working directly with Traffic Control (and thereby need to be concerned about whether the following
	/// <c>ServiceType</c> s are applicable in your situation), you probably are not:
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/qos/ns-qos-_flowspec typedef struct _flowspec { ULONG TokenRate; ULONG
	// TokenBucketSize; ULONG PeakBandwidth; ULONG Latency; ULONG DelayVariation; SERVICETYPE ServiceType; ULONG MaxSduSize; ULONG
	// MinimumPolicedSize; } FLOWSPEC, *PFLOWSPEC, *LPFLOWSPEC;
	[PInvokeData("qos.h", MSDNShortId = "268e0d3a-2b04-40fd-91eb-f1780236b3e4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct FLOWSPEC
	{
		/// <summary>Represents a FLOWSPEC with all unspecified values.</summary>
		public static readonly FLOWSPEC NotSpecified = new() { DelayVariation = QOS_NOT_SPECIFIED, Latency = QOS_NOT_SPECIFIED, MaxSduSize = QOS_NOT_SPECIFIED,
			MinimumPolicedSize = QOS_NOT_SPECIFIED, PeakBandwidth = QOS_NOT_SPECIFIED, TokenBucketSize = QOS_NOT_SPECIFIED, TokenRate = QOS_NOT_SPECIFIED,
			ServiceType = SERVICETYPE.SERVICETYPE_BESTEFFORT };

		/// <summary>
		/// <para>
		/// Specifies the permitted rate at which data can be transmitted over the life of the flow. The <c>TokenRate</c> member is
		/// similar to other token bucket models seen in such WAN technologies as Frame Relay, in which the token is analogous to a
		/// credit. If such tokens are not used immediately, they accrue to allow data transmission up to a certain periodic limit (
		/// <c>PeakBandwidth</c>, in the case of Windows 2000 quality of service). Accrual of credits is limited, however, to a specified
		/// amount ( <c>TokenBucketSize</c>). Limiting total credits (tokens) avoids situations where, for example, flows that are
		/// inactive for some time flood the available bandwidth with their large amount of accrued tokens. Because flows may accrue
		/// transmission credits over time (at their <c>TokenRate</c> value) only up to the maximum of their <c>TokenBucketSize</c>, and
		/// because they are limited in burst transmissions to their <c>PeakBandwidth</c>, traffic control and network-device resource
		/// integrity are maintained. Traffic control is maintained because flows cannot send too much data at once, and network-device
		/// resource integrity is maintained because such devices are spared high traffic bursts.
		/// </para>
		/// <para>
		/// With this model, applications can transmit data only when sufficient credits are available. If sufficient credits are not
		/// available, the application must either wait or discard the traffic (based on the value of QOS_SD_MODE). Therefore, it is
		/// important that applications base their <c>TokenRate</c> requests on reasonable expectations for transmission requirements.
		/// For example, in video applications, <c>TokenRate</c> is typically set to the average bit rate from peak to peak.
		/// </para>
		/// <para>
		/// If <c>TokenRate</c> is set to QOS_NOT_SPECIFIED on the receiver only, the maximum transmission unit (MTU) is used for
		/// <c>TokenRate</c>, and limits on the transmission rate (the token bucket model) will not be put into effect. Thus,
		/// <c>TokenRate</c> is expressed in bytes per second.
		/// </para>
		/// <para>
		/// The <c>TokenRate</c> member cannot be set to zero. Nor can it be set as a default (that is, set to QOS_NOT_SPECIFIED) in a
		/// sending <c>FLOWSPEC</c>.
		/// </para>
		/// </summary>
		public uint TokenRate;

		/// <summary>
		/// <para>
		/// The maximum amount of credits a given direction of a flow can accrue, regardless of time, in bytes. In video applications,
		/// <c>TokenBucketSize</c> will likely be the largest average frame size. In constant rate applications, <c>TokenBucketSize</c>
		/// should be set to allow for small variations.
		/// </para>
		/// </summary>
		public uint TokenBucketSize;

		/// <summary>
		/// <para>
		/// The upper limit on time-based transmission permission for a given flow, in bytes per second. The <c>PeakBandwidth</c> member
		/// restricts flows that may have accrued a significant amount of transmission credits, or tokens from overburdening network
		/// resources with one-time or cyclical data bursts, by enforcing a per-second data transmission ceiling. Some intermediate
		/// systems can take advantage of this information, resulting in more efficient resource allocation.
		/// </para>
		/// </summary>
		public uint PeakBandwidth;

		/// <summary>
		/// <para>
		/// Maximum acceptable delay between transmission of a bit by the sender and its receipt by one or more intended receivers, in
		/// microseconds. The precise interpretation of this number depends on the level of guarantee specified in the QOS request.
		/// </para>
		/// </summary>
		public uint Latency;

		/// <summary>
		/// <para>
		/// Difference between the maximum and minimum possible delay a packet will experience, in microseconds. Applications use
		/// <c>DelayVariation</c> to determine the amount of buffer space needed at the receiving end of the flow. This buffer space
		/// information can be used to restore the original data transmission pattern.
		/// </para>
		/// </summary>
		public uint DelayVariation;

		/// <summary>
		/// <para>
		/// Specifies the level of service to negotiate for the flow. The <c>ServiceType</c> member can be one of the following defined
		/// service types.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICETYPE_NOTRAFFIC</term>
		/// <term>
		/// Indicates that no traffic will be transmitted in the specified direction. On duplex-capable media, this value signals
		/// underlying software to set up unidirectional connections only. This service type is not valid for the TC API.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICETYPE_BESTEFFORT</term>
		/// <term>
		/// Results in no action taken by the RSVP SP. Traffic control does create a BESTEFFORT flow, however, and traffic on the flow
		/// will be handled by traffic control similarly to other BESTEFFORT traffic.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICETYPE_CONTROLLEDLOAD</term>
		/// <term>
		/// Provides an end-to-end QOS that closely approximates transmission quality provided by best-effort service, as expected under
		/// unloaded conditions from the associated network components along the data path. Applications that use
		/// SERVICETYPE_CONTROLLEDLOAD may therefore assume the following:
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICETYPE_GUARANTEED</term>
		/// <term>
		/// Guarantees that datagrams will arrive within the guaranteed delivery time and will not be discarded due to queue overflows,
		/// provided the flow's traffic stays within its specified traffic parameters. This service is intended for applications that
		/// need a firm guarantee that a datagram will arrive no later than a certain time after it was transmitted by its source.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICETYPE_QUALITATIVE</term>
		/// <term>
		/// Indicates that the application requires better than BESTEFFORT transmission, but cannot quantify its transmission
		/// requirements. Applications that use SERVICETYPE_QUALITATIVE can supply an application identifier policy object. The
		/// application identification policy object enables policy servers on the network to identify the application, and accordingly,
		/// assign an appropriate quality of service to the request. For more information on application identification, consult the IETF
		/// Internet Draft draft-ietf-rap-rsvp-appid-00.txt, or the Microsoft white paper on Application Identification. Traffic control
		/// treats flows of this type with the same priority as BESTEFFORT traffic on the local computer. However, application
		/// programmers can get boosted priority for such flows by modifying the Layer 2 settings on the associated flow using the
		/// QOS_TRAFFIC_CLASS QOS object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICETYPE_NETWORK_UNAVAILBLE</term>
		/// <term>Used to notify network changes.</term>
		/// </item>
		/// <item>
		/// <term>SERVICETYPE_NETWORK_CONTROL</term>
		/// <term>
		/// Used only for transmission of control packets (such as RSVP signaling messages). This ServiceType has the highest priority.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICETYPE_GENERAL_INFORMATION</term>
		/// <term>Specifies that all service types are supported for a flow. Can be used on sender side only.</term>
		/// </item>
		/// <item>
		/// <term>SERVICETYPE_NOCHANGE</term>
		/// <term>
		/// Indicates that the quality of service in the transmission using this ServiceType value is not changed. SERVICETYPE_NOCHANGE
		/// can be used when requesting a change in the quality of service for one direction only, or when requesting a change only
		/// within the ProviderSpecific parameters of a QOS specification, and not in the SendingFlowspec or ReceivingFlowspec.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICETYPE_NONCONFORMING</term>
		/// <term>Used to indicate nonconforming traffic.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_NO_TRAFFIC_CONTROL</term>
		/// <term>Indicates that traffic control should not be invoked in the specified direction.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_NO_QOS_SIGNALING</term>
		/// <term>Suppresses RSVP signaling in the specified direction.</term>
		/// </item>
		/// </list>
		/// <para>The following list identifies the relative priority of <c>ServiceType</c> settings:</para>
		/// <para>SERVICETYPE_NETWORK_CONTROL</para>
		/// <para>SERVICETYPE_GUARANTEED</para>
		/// <para>SERVICETYPE_CONTROLLED_LOAD</para>
		/// <para>SERVICETYPE_BESTEFFORT</para>
		/// <para>SERVICETYPE_QUALITATIVE</para>
		/// <para>Non-conforming traffic</para>
		/// <para>
		/// For a simple example, if a given network device were resource-bounded and had to choose among transmitting a packet from one
		/// of the above <c>ServiceType</c> settings, it would first send a packet of SERVICETYPE_NETWORKCONTROL, and if there were no
		/// packets of that <c>ServiceType</c> requiring transmission it would send a packet of <c>ServiceType</c>
		/// SERVICETYPE_GUARANTEED, and so on.
		/// </para>
		/// </summary>
		public SERVICETYPE ServiceType;

		/// <summary>
		/// <para>Specifies the maximum packet size permitted or used in the traffic flow, in bytes.</para>
		/// </summary>
		public uint MaxSduSize;

		/// <summary>
		/// <para>
		/// Specifies the minimum packet size for which the requested quality of service will be provided, in bytes. Packets smaller than
		/// this size are treated by traffic control as <c>MinimumPolicedSize</c>. When using the <c>FLOWSPEC</c> structure in
		/// association with RSVP, the value of <c>MinimumPolicedSize</c> cannot be zero; however, if you are using the <c>FLOWSPEC</c>
		/// structure specifically with the TC API, you can set <c>MinimumPolicedSize</c> to zero.
		/// </para>
		/// </summary>
		public uint MinimumPolicedSize;
	}
}