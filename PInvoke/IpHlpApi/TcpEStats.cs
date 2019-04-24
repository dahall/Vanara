using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>
		/// The <c>TCP_BOOLEAN_OPTIONAL</c> enumeration defines the states that a caller can specify when updating a member in the read/write
		/// information for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>The <c>TCP_BOOLEAN_OPTIONAL</c> enumeration is defined on Windows Vista and later.</para>
		/// <para>
		/// The collection of extended statistics on a TCP connection are enabled and disabled using calls to the SetPerTcp6ConnectionEStats
		/// and SetPerTcpConnectionEStats functions where the type of extended statistics specified is one of values from the TCP_ESTATS_TYPE
		/// enumeration type. A value from the <c>TCP_BOOLEAN_OPTIONAL</c> enumeration is used to specify how a member in the
		/// TCP_ESTATS_BANDWIDTH_RW_v0 structure should be updated to enable or disable extended statistics on a TCP connection for bandwidth estimation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ne-tcpestats-_tcp_boolean_optional typedef enum
		// _TCP_BOOLEAN_OPTIONAL { TcpBoolOptDisabled, TcpBoolOptEnabled, TcpBoolOptUnchanged } TCP_BOOLEAN_OPTIONAL, *PTCP_BOOLEAN_OPTIONAL;
		[PInvokeData("tcpestats.h", MSDNShortId = "68f8f797-06fb-4286-88bc-220c54977575")]
		public enum TCP_BOOLEAN_OPTIONAL
		{
			/// <summary>The option should be disabled.</summary>
			TcpBoolOptDisabled = 0,

			/// <summary>The option should be enabled.</summary>
			TcpBoolOptEnabled,

			/// <summary>The option should be unchanged.</summary>
			TcpBoolOptUnchanged = -1
		}

		/// <summary>
		/// The <c>TCP_ESTATS_TYPE</c> enumeration defines the type of extended statistics for a TCP connection that is requested or being set.
		/// </summary>
		/// <remarks>
		/// <para>The <c>TCP_ESTATS_TYPE</c> enumeration is defined on Windows Vista and later.</para>
		/// <para>
		/// The GetPerTcp6ConnectionEStats and <c>GetPerTcp6ConnectionEStats</c> functions are designed to use TCP to diagnose performance
		/// problems in both the network and the application. If a network based application is performing poorly, TCP can determine if the
		/// bottleneck is in the sender, the receiver or the network itself. If the bottleneck is in the network, TCP can provide specific
		/// information about its nature.
		/// </para>
		/// <para>
		/// The GetPerTcp6ConnectionEStats and <c>GetPerTcp6ConnectionEStats</c> functions are used to retrieve extended statistics for a TCP
		/// connection based on the type of extended statistics specified using one of values from the <c>TCP_ESTATS_TYPE</c> enumeration
		/// type. The collection of extended statistics on a TCP connection are enabled and disabled using calls to the
		/// SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions where the type of extended statistics specified is one of
		/// values from the <c>TCP_ESTATS_TYPE</c> enumeration type.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ne-tcpestats-tcp_estats_type typedef enum {
		// TcpConnectionEstatsSynOpts, TcpConnectionEstatsData, TcpConnectionEstatsSndCong, TcpConnectionEstatsPath,
		// TcpConnectionEstatsSendBuff, TcpConnectionEstatsRec, TcpConnectionEstatsObsRec, TcpConnectionEstatsBandwidth,
		// TcpConnectionEstatsFineRtt, TcpConnectionEstatsMaximum } *PTCP_ESTATS_TYPE;
		[PInvokeData("tcpestats.h", MSDNShortId = "96f55528-e74a-4360-a7a2-54ba19c3a284")]
		public enum TCP_ESTATS_TYPE
		{
			/// <summary>
			/// This value specifies SYN exchange information for a TCP connection. Only read-only static information is available for this
			/// enumeration value.
			/// </summary>
			[CorrespondingType(typeof(TCP_ESTATS_SYN_OPTS_ROS_v0))]
			TcpConnectionEstatsSynOpts,

			/// <summary>
			/// This value specifies extended data transfer information for a TCP connection. Only read-only dynamic information and
			/// read/write information are available for this enumeration value.
			/// </summary>
			[CorrespondingType(typeof(TCP_ESTATS_DATA_RW_v0))]
			[CorrespondingType(typeof(TCP_ESTATS_DATA_ROD_v0))]
			TcpConnectionEstatsData,

			/// <summary>
			/// This value specifies sender congestion for a TCP connection. All three types of information (read-only static, read-only
			/// dynamic, and read/write information) are available for this enumeration value.
			/// </summary>
			[CorrespondingType(typeof(TCP_ESTATS_SND_CONG_RW_v0))]
			[CorrespondingType(typeof(TCP_ESTATS_SND_CONG_ROS_v0))]
			[CorrespondingType(typeof(TCP_ESTATS_SND_CONG_ROD_v0))]
			TcpConnectionEstatsSndCong,

			/// <summary>This value specifies extended path measurement information for a TCP connection. This information is used to infer segment reordering on the path from the local sender to the remote receiver. Only read-only dynamic information and read/write information are available for this enumeration value.</summary>
			[CorrespondingType(typeof(TCP_ESTATS_PATH_RW_v0))]
			[CorrespondingType(typeof(TCP_ESTATS_PATH_ROD_v0))]
			TcpConnectionEstatsPath,

			/// <summary>
			/// This value specifies extended output-queuing information for a TCP connection. Only read-only dynamic information and
			/// read/write information are available for this enumeration value.
			/// </summary>
			[CorrespondingType(typeof(TCP_ESTATS_SEND_BUFF_RW_v0))]
			[CorrespondingType(typeof(TCP_ESTATS_SEND_BUFF_ROD_v0))]
			TcpConnectionEstatsSendBuff,

			/// <summary>This value specifies extended local-receiver information for a TCP connection. Only read-only dynamic information and read/write information are available for this enumeration value.</summary>
			[CorrespondingType(typeof(TCP_ESTATS_REC_RW_v0))]
			[CorrespondingType(typeof(TCP_ESTATS_REC_ROD_v0))]
			TcpConnectionEstatsRec,

			/// <summary>
			/// This value specifies extended remote-receiver information for a TCP connection. Only read-only dynamic information and
			/// read/write information are available for this enumeration value.
			/// </summary>
			[CorrespondingType(typeof(TCP_ESTATS_OBS_REC_RW_v0))]
			[CorrespondingType(typeof(TCP_ESTATS_OBS_REC_ROD_v0))]
			TcpConnectionEstatsObsRec,

			/// <summary>This value specifies bandwidth estimation statistics for a TCP connection on bandwidth. Only read-only dynamic information and read/write information are available for this enumeration value.</summary>
			[CorrespondingType(typeof(TCP_ESTATS_BANDWIDTH_RW_v0))]
			[CorrespondingType(typeof(TCP_ESTATS_BANDWIDTH_ROD_v0))]
			TcpConnectionEstatsBandwidth,

			/// <summary>
			/// This value specifies fine-grained round-trip time (RTT) estimation statistics for a TCP connection. Only read-only dynamic
			/// information and read/write information are available for this enumeration value.
			/// </summary>
			[CorrespondingType(typeof(TCP_ESTATS_FINE_RTT_RW_v0))]
			[CorrespondingType(typeof(TCP_ESTATS_FINE_RTT_ROD_v0))]
			TcpConnectionEstatsFineRtt,
		}

		/// <summary>The <c>TCP_SOFT_ERROR</c> enumeration defines the reason for non-fatal or soft errors recorded on a TCP connection.</summary>
		/// <remarks>
		/// <para>The <c>TCP_SOFT_ERROR</c> enumeration is defined on Windows Vista and later.</para>
		/// <para>
		/// The values in this enumeration are defined in the IETF draft RFC on the TCP Extended Statistics MIB. For more information, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ne-tcpestats-__unnamed_enum_1 typedef enum { TcpErrorNone,
		// TcpErrorBelowDataWindow, TcpErrorAboveDataWindow, TcpErrorBelowAckWindow, TcpErrorAboveAckWindow, TcpErrorBelowTsWindow,
		// TcpErrorAboveTsWindow, TcpErrorDataChecksumError, TcpErrorDataLengthError, TcpErrorMaxSoftError } *PTCP_SOFT_ERROR;
		[PInvokeData("tcpestats.h", MSDNShortId = "dd179e9b-86e6-48e8-bb4b-05d69b9794b2")]
		public enum TCP_SOFT_ERROR
		{
			/// <summary>No soft errors have occurred.</summary>
			TcpErrorNone = 0,

			/// <summary>
			/// All data in the segment is below the send unacknowledged (SND.UNA) sequence number. This soft error is normal for keep-alives
			/// and zero window probes.
			/// </summary>
			TcpErrorBelowDataWindow,

			/// <summary>
			/// Some data in the segment is above send window (SND.WND) size. This soft error indicates an implementation bug or possible attack.
			/// </summary>
			TcpErrorAboveDataWindow,

			/// <summary>
			/// An ACK was received below the SND.UNA sequence number. This soft error indicates that the return path is reordering ACKs.
			/// </summary>
			TcpErrorBelowAckWindow,

			/// <summary>
			/// An ACK was received for data that we have not sent. This soft error indicates an implementation bug or possible attack.
			/// </summary>
			TcpErrorAboveAckWindow,

			/// <summary>
			/// The Time-stamp Echo Reply (TSecr) on the segment is older than the current TS.Recent (a time-stamp to be echoed in TSecr
			/// whenever a segment is sent). This error is applicable to TCP connections that use the TCP Timestamps option (TSopt) defined
			/// by the IETF in RFC 1323. For more information, see http://www.ietf.org/rfc/rfc1323.txt. This soft error is normal for the
			/// rare case where the Protect Against Wrapped Sequences numbers (PAWS) mechanism detects data reordered by the network.
			/// </summary>
			TcpErrorBelowTsWindow,

			/// <summary>
			/// The TSecr on the segment is newer than the current TS.Recent. This soft error indicates an implementation bug or possible attack.
			/// </summary>
			TcpErrorAboveTsWindow,

			/// <summary>
			/// An incorrect TCP checksum was received. Note that this value is intrinsically fragile, because the header fields used to
			/// identify the connection may have been corrupted.
			/// </summary>
			TcpErrorDataChecksumError,

			/// <summary>
			/// A data length error occurred. This value is not defined in the IETF draft RFC on the TCP Extended Statistics MIB.
			/// </summary>
			TcpErrorDataLengthError,

			/// <summary>
			/// The maximum possible value for the TCP_SOFT_ERROR_STATE enumeration type. This is not a legal value for the reason for a soft
			/// error for a TCP connection.
			/// </summary>
			TcpErrorMaxSoftError,
		}

		/// <summary>
		/// The <c>TCP_ESTATS_BANDWIDTH_ROD_v0</c> structure contains read-only dynamic information for extended TCP statistics on bandwidth
		/// estimation for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_BANDWIDTH_ROD_v0</c> structure is used as part of the TCP extended statistics feature available on Windows
		/// Vista and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_BANDWIDTH_ROD_v0</c> is defined as version 0 of the structure for read-only dynamic information for extended
		/// TCP statistics on bandwidth estimation for a TCP connection. This information is available after the connection has been established.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_BANDWIDTH_ROD_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsBandwidth</c> is passed in the EstatsType parameter. Extended TCP
		/// statistics need to be enabled to retrieve this structure.
		/// </para>
		/// <para>
		/// The members of this structure are not defined in the IETF RFC on the TCP Extended Statistics MIB. For more information on this
		/// RFC, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_bandwidth_rod_v0 typedef struct
		// _TCP_ESTATS_BANDWIDTH_ROD_v0 { ULONG64 OutboundBandwidth; ULONG64 InboundBandwidth; ULONG64 OutboundInstability; ULONG64
		// InboundInstability; BOOLEAN OutboundBandwidthPeaked; BOOLEAN InboundBandwidthPeaked; } TCP_ESTATS_BANDWIDTH_ROD_v0, *PTCP_ESTATS_BANDWIDTH_ROD_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "330d06a2-9966-4e2b-b1bd-44c0f1b9416d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_BANDWIDTH_ROD_v0
		{
			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>The computed outbound bandwidth estimate, in bits per second, for the network path for the TCP connection.</para>
			/// </summary>
			public ulong OutboundBandwidth;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>The computed inbound bandwidth estimate, in bits per second, for the network path for the TCP connection.</para>
			/// </summary>
			public ulong InboundBandwidth;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>
			/// A measure, in bits per second, of the instability of the outbound bandwidth estimate for the network path for the TCP connection.
			/// </para>
			/// </summary>
			public ulong OutboundInstability;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>
			/// A measure, in bits per second, of the instability of the inbound bandwidth estimate for the network path for the TCP connection.
			/// </para>
			/// </summary>
			public ulong InboundInstability;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>
			/// A boolean value that indicates if the computed outbound bandwidth estimate for the network path for the TCP connection has
			/// reached its peak value.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool OutboundBandwidthPeaked;

			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>
			/// A boolean value that indicates if the computed inbound bandwidth estimate for the network path for the TCP connection has
			/// reached its peak value.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool InboundBandwidthPeaked;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_BANDWIDTH_RW_v0</c> structure contains read/write configuration information for extended TCP statistics on
		/// bandwidth estimation for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_BANDWIDTH_RW_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_BANDWIDTH_RW_v0</c> is defined as version 0 of the structure for read/write configuration information on
		/// bandwidth estimation for a TCP connection.
		/// </para>
		/// <para>
		/// Extended TCP statistics on bandwidth estimation for a TCP connection are enabled and disabled using this structure and the
		/// SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsBandwidth</c> is passed in the
		/// EstatsType parameter.
		/// </para>
		/// <para>
		/// The Offset parameter passed to the SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions is currently unused and
		/// must be set to 0. Consequently, the <c>TCP_ESTATS_BANDWIDTH_RW_v0</c> structure pointed to by the Rw parameter when the
		/// EstatsType parameter is set to <c>TcpConnectionEstatsBandwidth</c> must have both the <c>EnableCollectionOutbound</c> and
		/// <c>EnableCollectionInbound</c> structure members set to the preferred values in a single call to the
		/// <c>SetPerTcp6ConnectionEStats</c> and <c>SetPerTcpConnectionEStats</c> functions.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_BANDWIDTH_RW_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsBandwidth</c> is passed in the EstatsType parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_bandwidth_rw_v0 typedef struct
		// _TCP_ESTATS_BANDWIDTH_RW_v0 { TCP_BOOLEAN_OPTIONAL EnableCollectionOutbound; TCP_BOOLEAN_OPTIONAL EnableCollectionInbound; }
		// TCP_ESTATS_BANDWIDTH_RW_v0, *PTCP_ESTATS_BANDWIDTH_RW_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "a9bf5ad3-a8db-4194-8e47-5a7409391f4c")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_BANDWIDTH_RW_v0
		{
			/// <summary>
			/// <para>A value that indicates if extended statistics on a TCP connection should be collected for outbound bandwidth estimation.</para>
			/// <para>
			/// If this member is set to <c>TcpBoolOptEnabled</c>, extended statistics on the TCP connection for outbound bandwidth
			/// estimation are enabled. If this member is set to <c>TcpBoolOptDisabled</c>, extended statistics on the TCP connection for
			/// outbound bandwidth estimation are disabled. If this member is set to <c>TcpBoolOptUnchanged</c>, extended statistics on the
			/// TCP connection for outbound bandwidth estimation are left unchanged.
			/// </para>
			/// <para>The default state for this member when not set is disabled.</para>
			/// </summary>
			public TCP_BOOLEAN_OPTIONAL EnableCollectionOutbound;

			/// <summary>
			/// <para>A value that indicates if extended statistics on a TCP connection should be collected for inbound bandwidth estimation.</para>
			/// <para>
			/// If this member is set to <c>TcpBoolOptEnabled</c>, extended statistics on the TCP connection for inbound bandwidth estimation
			/// are enabled. If this member is set to <c>TcpBoolOptDisabled</c>, extended statistics on the TCP connection for inbound
			/// bandwidth estimation are disabled. If this member is set to <c>TcpBoolOptUnchanged</c>, extended statistics on the TCP
			/// connection for inbound bandwidth estimation are unchanged.
			/// </para>
			/// <para>The default state for this member when not set is disabled.</para>
			/// </summary>
			public TCP_BOOLEAN_OPTIONAL EnableCollectionInbound;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_DATA_ROD_v0</c> structure contains read-only dynamic information for extended TCP statistics on data transfer
		/// for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_DATA_ROD_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_DATA_ROD_v0</c> is defined as version 0 of the structure for read-only dynamic information for extended TCP
		/// statistics on data transfer for a TCP connection. This information is available after the connection has been established.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_DATA_ROD_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or GetPerTcpConnectionEStats
		/// functions when <c>TcpConnectionEstatsData</c> is passed in the EstatsType parameter. Extended TCP statistics need to be enabled
		/// to retrieve this structure.
		/// </para>
		/// <para>
		/// The members of this structure are defined in the IETF RFC on the TCP Extended Statistics MIB. For more information, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// <para>
		/// The following is the mapping of the members in the <c>TCP_ESTATS_DATA_ROD_v0</c> structure to the entries defined in RFC 4898 for
		/// extended TCP statistics:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DataBytesOut</term>
		/// <term>tcpEStatsPerfDataOctetsOut</term>
		/// </item>
		/// <item>
		/// <term>DataSegsOut</term>
		/// <term>tcpEStatsPerfDataSegsOut</term>
		/// </item>
		/// <item>
		/// <term>DataBytesIn</term>
		/// <term>tcpEStatsPerfDataOctetsIn</term>
		/// </item>
		/// <item>
		/// <term>DataSegsIn</term>
		/// <term>tcpEStatsPerfDataSegsIn</term>
		/// </item>
		/// <item>
		/// <term>SegsOut</term>
		/// <term>tcpEStatsPerfSegsOut</term>
		/// </item>
		/// <item>
		/// <term>SegsIn</term>
		/// <term>tcpEStatsPerfSegsIn</term>
		/// </item>
		/// <item>
		/// <term>SoftErrors</term>
		/// <term>tcpEStatsStackSoftErrors</term>
		/// </item>
		/// <item>
		/// <term>SoftErrorReason</term>
		/// <term>tcpEStatsStackSoftErrorReason</term>
		/// </item>
		/// <item>
		/// <term>SndUna</term>
		/// <term>tcpEStatsAppSndUna</term>
		/// </item>
		/// <item>
		/// <term>SndNxt</term>
		/// <term>tcpEStatsAppSndNxt</term>
		/// </item>
		/// <item>
		/// <term>SndMax</term>
		/// <term>tcpEStatsAppSndMax</term>
		/// </item>
		/// <item>
		/// <term>ThruBytesAcked</term>
		/// <term>tcpEStatsAppThruOctetsAcked</term>
		/// </item>
		/// <item>
		/// <term>RcvNxt</term>
		/// <term>tcpEStatsAppRcvNxt</term>
		/// </item>
		/// <item>
		/// <term>ThruBytesReceived</term>
		/// <term>tcpEStatsAppThruOctetsReceived</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_data_rod_v0 typedef struct
		// _TCP_ESTATS_DATA_ROD_v0 { ULONG64 DataBytesOut; ULONG64 DataSegsOut; ULONG64 DataBytesIn; ULONG64 DataSegsIn; ULONG64 SegsOut;
		// ULONG64 SegsIn; ULONG SoftErrors; ULONG SoftErrorReason; ULONG SndUna; ULONG SndNxt; ULONG SndMax; ULONG64 ThruBytesAcked; ULONG
		// RcvNxt; ULONG64 ThruBytesReceived; } TCP_ESTATS_DATA_ROD_v0, *PTCP_ESTATS_DATA_ROD_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "1e896660-10dd-471a-b4ae-116caa7a9d48")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_DATA_ROD_v0
		{
			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>
			/// The number of octets of data contained in transmitted segments, including retransmitted data. Note that this does not include
			/// TCP headers.
			/// </para>
			/// </summary>
			public ulong DataBytesOut;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>The number of segments sent containing a positive length data segment.</para>
			/// </summary>
			public ulong DataSegsOut;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>
			/// The number of octets contained in received data segments, including retransmitted data. Note that this does not include TCP headers.
			/// </para>
			/// </summary>
			public ulong DataBytesIn;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>The number of segments received containing a positive length data segment.</para>
			/// </summary>
			public ulong DataSegsIn;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>The total number of segments sent.</para>
			/// </summary>
			public ulong SegsOut;

			/// <summary>
			/// <para>Type: <c></c></para>
			/// <para>The total number of segments received.</para>
			/// </summary>
			public ulong SegsIn;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of segments that fail various consistency tests during TCP input processing. Soft errors might cause the segment
			/// to be discarded but some do not. Some of these soft errors cause the generation of a TCP acknowledgment, while others are
			/// silently discarded.
			/// </para>
			/// </summary>
			public uint SoftErrors;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// A value that identifies which consistency test most recently failed during TCP input processing. This object is set every
			/// time the <c>SoftErrors</c> member is incremented.
			/// </para>
			/// </summary>
			public uint SoftErrorReason;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The value of the oldest unacknowledged sequence number. Note that this member is a TCP state variable.</para>
			/// </summary>
			public uint SndUna;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The next sequence number to be sent. Note that this member is not monotonic (and thus not a counter), because TCP sometimes
			/// retransmits lost data by pulling the member back to the missing data.
			/// </para>
			/// </summary>
			public uint SndNxt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The farthest forward (right most or largest) sequence number to be sent. Note that this will be equal to the <c>SndNxt</c>
			/// member except when the <c>SndNxt</c> member is pulled back during recovery.
			/// </para>
			/// </summary>
			public uint SndMax;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>
			/// The number of octets for which cumulative acknowledgments have been received. Note that this will be the sum of changes to
			/// the <c>SndNxt</c> member.
			/// </para>
			/// </summary>
			public ulong ThruBytesAcked;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The next sequence number to be received. Note that this member is not monotonic (and thus not a counter), because TCP
			/// sometimes retransmits lost data by pulling the member back to the missing data.
			/// </para>
			/// </summary>
			public uint RcvNxt;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>
			/// The number of octets for which cumulative acknowledgments have been sent. Note that this will be the sum of changes to the
			/// <c>RcvNxt</c> member.
			/// </para>
			/// </summary>
			public ulong ThruBytesReceived;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_DATA_RW_v0</c> structure contains read/write configuration information for extended TCP statistics on data
		/// transfer for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_DATA_RW_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_DATA_RW_v0</c> is defined as version 0 of the structure for read/write configuration information on extended
		/// data transfer for a TCP connection.
		/// </para>
		/// <para>
		/// Extended TCP statistics on extended data transfer information for a TCP connection are enabled and disabled using this structure
		/// and the SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsData</c> is passed in the
		/// EstatsType parameter.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_DATA_RW_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or GetPerTcpConnectionEStats
		/// functions when <c>TcpConnectionEstatsData</c> is passed in the EstatsType parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_data_rw_v0 typedef struct
		// _TCP_ESTATS_DATA_RW_v0 { BOOLEAN EnableCollection; } TCP_ESTATS_DATA_RW_v0, *PTCP_ESTATS_DATA_RW_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "823cea66-f719-40f6-82bd-572623188446")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_DATA_RW_v0
		{
			/// <summary>
			/// <para>A value that indicates if extended statistics on a TCP connection should be collected for data transfer information.</para>
			/// <para>
			/// If this member is set to <c>TRUE</c>, extended statistics on the TCP connection are enabled. If this member is set to
			/// <c>FALSE</c>, extended statistics on the TCP connection are disabled.
			/// </para>
			/// <para>The default state for this member when not set is disabled.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool EnableCollection;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_FINE_RTT_ROD_v0</c> structure contains read-only dynamic information for extended TCP statistics on
		/// fine-grained round-trip time (RTT) estimation for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_FINE_RTT_ROD_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_FINE_RTT_ROD_v0</c> is defined as version 0 of the structure for read-only dynamic information for extended TCP
		/// statistics on fine-grained round-trip time estimation for a TCP connection. This information is available after the connection
		/// has been established.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_FINE_RTT_ROD_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsFineRtt</c> is passed in the EstatsType parameter. Extended TCP
		/// statistics need to be enabled to retrieve this structure.
		/// </para>
		/// <para>
		/// The TCP retransmission timer is discussed in detail in the IETF RFC 2988 on Computing TCP's Retransmission Timer For more
		/// information, see http://www.ietf.org/rfc/rfc2988.txt.
		/// </para>
		/// <para>
		/// The members of this structure are not defined in the IETF RFC on the TCP Extended Statistics MIB. However, there are members in
		/// the TCP_ESTATS_PATH_ROD_v0 structure that provide similar time measurements in milliseconds. For more information, see the
		/// <c>TCP_ESTATS_PATH_ROD_v0</c> structure and http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_fine_rtt_rod_v0 typedef struct
		// _TCP_ESTATS_FINE_RTT_ROD_v0 { ULONG RttVar; ULONG MaxRtt; ULONG MinRtt; ULONG SumRtt; } TCP_ESTATS_FINE_RTT_ROD_v0, *PTCP_ESTATS_FINE_RTT_ROD_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "e33cd21f-1ec8-4715-a5e1-431a8a7e61df")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_FINE_RTT_ROD_v0
		{
			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The round trip time variation, in microseconds, used in receive window auto-tuning when the TCP extended statistics feature
			/// is enabled.
			/// </para>
			/// </summary>
			public uint RttVar;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum sampled round trip time, in microseconds.</para>
			/// </summary>
			public uint MaxRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The minimum sampled round trip time, in microseconds.</para>
			/// </summary>
			public uint MinRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// A smoothed value round trip time, in microseconds, computed from all sampled round trip times. The smoothing is a weighted
			/// additive function that uses the <c>RttVar</c> member.
			/// </para>
			/// </summary>
			public uint SumRtt;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_FINE_RTT_RW_v0</c> structure contains read/write configuration information for extended TCP statistics on
		/// fine-grained round-trip time (RTT) estimation statistics for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_FINE_RTT_RW_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_FINE_RTT_RW_v0</c> is defined as version 0 of the structure for read/write configuration information on
		/// fine-grained round-trip time estimation statistics for a TCP connection.
		/// </para>
		/// <para>
		/// Extended TCP statistics on extended path measurement information for a TCP connection are enabled and disabled using this
		/// structure and the SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsFineRtt</c> is
		/// passed in the EstatsType parameter.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_FINE_RTT_RW_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsFineRtt</c> is passed in the EstatsType parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_fine_rtt_rw_v0 typedef struct
		// _TCP_ESTATS_FINE_RTT_RW_v0 { BOOLEAN EnableCollection; } TCP_ESTATS_FINE_RTT_RW_v0, *PTCP_ESTATS_FINE_RTT_RW_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "35834c9a-2896-4c11-aef7-c55af7f6fef3")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_FINE_RTT_RW_v0
		{
			/// <summary>
			/// <para>
			/// A value that indicates if extended statistics on a TCP connection should be collected for fine-grained RTT estimation statistics.
			/// </para>
			/// <para>
			/// If this member is set to <c>TRUE</c>, extended statistics on the TCP connection are enabled. If this member is set to
			/// <c>FALSE</c>, extended statistics on the TCP connection are disabled.
			/// </para>
			/// <para>The default state for this member when not set is disabled.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool EnableCollection;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_OBS_REC_ROD_v0</c> structure contains read-only dynamic information for extended TCP statistics observed on the
		/// remote receiver for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_OBS_REC_ROD_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_OBS_REC_ROD_v0</c> is defined as version 0 of the structure for read-only dynamic information for extended TCP
		/// statistics on the local receiver for a TCP connection. This information is available after the connection has been established.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_OBS_REC_ROD_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsObsRec</c> is passed in the EstatsType parameter. Extended TCP
		/// statistics need to be enabled to retrieve this structure.
		/// </para>
		/// <para>
		/// The members of this structure are defined in the IETF RFC on the TCP Extended Statistics MIB. For more information, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// <para>
		/// The following is the mapping of the members in the <c>TCP_ESTATS_OBS_REC_ROD_v0</c> structure to the entries defined in RFC 4898
		/// for extended TCP statistics:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CurRwinRcvd</term>
		/// <term>tcpEStatsPerfCurRwinRcvd</term>
		/// </item>
		/// <item>
		/// <term>MaxRwinRcvd</term>
		/// <term>tcpEStatsPerfMaxRwinRcvd</term>
		/// </item>
		/// <item>
		/// <term>MinRwinRcvd</term>
		/// <term>No mapping to this member.</term>
		/// </item>
		/// <item>
		/// <term>WinScaleRcvd</term>
		/// <term>tcpEStatsStackWinScaleRcvd</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_obs_rec_rod_v0 typedef struct
		// _TCP_ESTATS_OBS_REC_ROD_v0 { ULONG CurRwinRcvd; ULONG MaxRwinRcvd; ULONG MinRwinRcvd; UCHAR WinScaleRcvd; }
		// TCP_ESTATS_OBS_REC_ROD_v0, *PTCP_ESTATS_OBS_REC_ROD_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "f790e107-0db3-4691-98fc-378518b04a8a")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_OBS_REC_ROD_v0
		{
			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The most recent window advertisement, in bytes, received from the remote receiver.</para>
			/// </summary>
			public uint CurRwinRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum window advertisement, in bytes, received from the remote receiver.</para>
			/// </summary>
			public uint MaxRwinRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The minimum window advertisement, in bytes, received from the remote receiver.</para>
			/// </summary>
			public uint MinRwinRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The value of the received window scale option if one was received from the remote receiver; otherwise, a value of -1.
			/// </para>
			/// <para>
			/// Note that if both the <c>WinScaleSent</c> member of the TCP_ESTATS_REC_ROD_v0 structure and the <c>WinScaleRcvd</c> member
			/// are not -1, then Snd.Wind.Scale will be the same as this value and used to scale receiver window announcements from the
			/// remote host to the local host.
			/// </para>
			/// </summary>
			public byte WinScaleRcvd;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_OBS_REC_RW_v0</c> structure contains read/write configuration information for extended TCP statistics observed
		/// on the remote receiver for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_OBS_REC_RW_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_OBS_REC_RW_v0</c> is defined as version 0 of the structure for read/write configuration information observed on
		/// the remote receiver for a TCP connection.
		/// </para>
		/// <para>
		/// Extended TCP statistics on remote-receiver information for a TCP connection are enabled and disabled using this structure and the
		/// SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsObsRec</c> is passed in the
		/// EstatsType parameter.
		/// </para>
		/// <para>
		/// The TCP_ESTATS_REC_RW_v0 structure is retrieved by calls to the GetPerTcp6ConnectionEStats or GetPerTcpConnectionEStats functions
		/// when <c>TcpConnectionEstatsObsRec</c> is passed in the EstatsType parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_obs_rec_rw_v0 typedef struct
		// _TCP_ESTATS_OBS_REC_RW_v0 { BOOLEAN EnableCollection; } TCP_ESTATS_OBS_REC_RW_v0, *PTCP_ESTATS_OBS_REC_RW_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "91c2d5d9-3198-42a7-abf7-077281b491f2")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_OBS_REC_RW_v0
		{
			/// <summary>
			/// <para>A value that indicates if extended statistics on a TCP connection should be collected for remote-receiver information.</para>
			/// <para>
			/// If this member is set to <c>TRUE</c>, extended statistics on the TCP connection are enabled. If this member is set to
			/// <c>FALSE</c>, extended statistics on the TCP connection are disabled.
			/// </para>
			/// <para>The default state for this member when not set is disabled.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool EnableCollection;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_PATH_ROD_v0</c> structure contains read-only dynamic information for extended TCP statistics on network path
		/// measurement for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_PATH_ROD_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_PATH_ROD_v0</c> is defined as version 0 of the structure for read-only dynamic information on network path
		/// measurement for a TCP connection. This information is available after the connection has been established.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_PATH_ROD_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or GetPerTcpConnectionEStats
		/// functions when <c>TcpConnectionEstatsPath</c> is passed in the EstatsType parameter. Extended TCP statistics need to be enabled
		/// to retrieve this structure.
		/// </para>
		/// <para>
		/// The path MTU discovery and maximum segment size are discussed in detail in the IETF RFC 1191 on Path MTU discovery. For more
		/// information, see http://www.ietf.org/rfc/rfc1191.txt.
		/// </para>
		/// <para>
		/// TCP congestion control and congestion control algorithms are discussed in detail in the IETF RFC 2581 on TCP Congestion Control.
		/// For more information, see http://www.ietf.org/rfc/rfc2581.txt.
		/// </para>
		/// <para>
		/// SACK and an extension to the SACK option are discussed in detail in the IETF RFC 2883 on An Extension to the Selective
		/// Acknowledgment (SACK) Option for TCP. For more information, see http://www.ietf.org/rfc/rfc2883.txt.
		/// </para>
		/// <para>
		/// The TCP retransmission timer (RTO) and the smoothed round-trip-time (RTT) are discussed in detail in the IETF RFC 2988 on
		/// Computing TCP's Retransmission Timer. For more information, see http://www.ietf.org/rfc/rfc2988.txt.
		/// </para>
		/// <para>
		/// Explicit Congestion Notification in IP is discussed in detail in the IETF RFC 2581 on The Addition of Explicit Congestion
		/// Notification (ECN) to IP. For more information, see http://www.ietf.org/rfc/rfc3168.txt.
		/// </para>
		/// <para>
		/// The members of this structure are defined in the IETF RFC on the TCP Extended Statistics MIB. For more information, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// <para>
		/// The following is the mapping of the members in the <c>TCP_ESTATS_PATH_ROD_v0</c> structure to the entries defined in RFC 4898 for
		/// extended TCP statistics:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>FastRetran</term>
		/// <term>tcpEStatsStackFastRetran</term>
		/// </item>
		/// <item>
		/// <term>Timeouts</term>
		/// <term>tcpEStatsPerfTimeouts</term>
		/// </item>
		/// <item>
		/// <term>SubsequentTimeouts</term>
		/// <term>tcpEStatsStackSubsequentTimeouts</term>
		/// </item>
		/// <item>
		/// <term>CurTimeoutCount</term>
		/// <term>tcpEStatsStackCurTimeoutCount</term>
		/// </item>
		/// <item>
		/// <term>AbruptTimeouts</term>
		/// <term>tcpEStatsStackAbruptTimeouts</term>
		/// </item>
		/// <item>
		/// <term>PktsRetrans</term>
		/// <term>tcpEStatsPerfSegsRetrans</term>
		/// </item>
		/// <item>
		/// <term>BytesRetrans</term>
		/// <term>tcpEStatsPerfOctetsRetrans</term>
		/// </item>
		/// <item>
		/// <term>DupAcksIn</term>
		/// <term>tcpEStatsStackDupAcksIn</term>
		/// </item>
		/// <item>
		/// <term>SacksRcvd</term>
		/// <term>tcpEStatsStackSACKsRcvd</term>
		/// </item>
		/// <item>
		/// <term>SackBlocksRcvd</term>
		/// <term>tcpEStatsStackSACKBlocksRcvd</term>
		/// </item>
		/// <item>
		/// <term>CongSignals</term>
		/// <term>tcpEStatsPerfCongSignals</term>
		/// </item>
		/// <item>
		/// <term>PreCongSumCwnd</term>
		/// <term>tcpEStatsPathPreCongSumCwnd</term>
		/// </item>
		/// <item>
		/// <term>PreCongSumRtt</term>
		/// <term>tcpEStatsPathPreCongSumRTT</term>
		/// </item>
		/// <item>
		/// <term>PostCongSumRtt</term>
		/// <term>tcpEStatsPathPostCongSumRTT</term>
		/// </item>
		/// <item>
		/// <term>PostCongCountRtt</term>
		/// <term>tcpEStatsPathPostCongCountRTT</term>
		/// </item>
		/// <item>
		/// <term>EcnSignals</term>
		/// <term>tcpEStatsPathECNsignals</term>
		/// </item>
		/// <item>
		/// <term>EceRcvd</term>
		/// <term>tcpEStatsPathCERcvd</term>
		/// </item>
		/// <item>
		/// <term>SendStall</term>
		/// <term>tcpEStatsStackSendStall</term>
		/// </item>
		/// <item>
		/// <term>QuenchRcvd</term>
		/// <term>No mapping to this member.</term>
		/// </item>
		/// <item>
		/// <term>RetranThresh</term>
		/// <term>tcpEStatsPathRetranThresh</term>
		/// </item>
		/// <item>
		/// <term>SndDupAckEpisodes</term>
		/// <term>tcpEStatsPathDupAckEpisodes</term>
		/// </item>
		/// <item>
		/// <term>SumBytesReordered</term>
		/// <term>tcpEStatsPathSumOctetsReordered</term>
		/// </item>
		/// <item>
		/// <term>NonRecovDa</term>
		/// <term>tcpEStatsPathNonRecovDA</term>
		/// </item>
		/// <item>
		/// <term>NonRecovDaEpisodes</term>
		/// <term>tcpEStatsPathNonRecovDAEpisodes</term>
		/// </item>
		/// <item>
		/// <term>AckAfterFr</term>
		/// <term>No mapping to this member.</term>
		/// </item>
		/// <item>
		/// <term>DsackDups</term>
		/// <term>tcpEStatsStackDSACKDups</term>
		/// </item>
		/// <item>
		/// <term>SampleRtt</term>
		/// <term>tcpEStatsPathSampleRTT</term>
		/// </item>
		/// <item>
		/// <term>SmoothedRtt</term>
		/// <term>tcpEStatsPerfSmoothedRTT</term>
		/// </item>
		/// <item>
		/// <term>RttVar</term>
		/// <term>tcpEStatsPathRTTVar</term>
		/// </item>
		/// <item>
		/// <term>MaxRtt</term>
		/// <term>tcpEStatsPathMaxRTT</term>
		/// </item>
		/// <item>
		/// <term>MinRtt</term>
		/// <term>tcpEStatsPathMinRTT</term>
		/// </item>
		/// <item>
		/// <term>SumRtt</term>
		/// <term>tcpEStatsPathSumRTT</term>
		/// </item>
		/// <item>
		/// <term>CountRtt</term>
		/// <term>tcpEStatsPathCountRTT</term>
		/// </item>
		/// <item>
		/// <term>CurRto</term>
		/// <term>tcpEStatsPerfCurRTO</term>
		/// </item>
		/// <item>
		/// <term>MaxRto</term>
		/// <term>tcpEStatsPathMaxRTO</term>
		/// </item>
		/// <item>
		/// <term>MinRto</term>
		/// <term>tcpEStatsPathMinRTO</term>
		/// </item>
		/// <item>
		/// <term>CurMss</term>
		/// <term>tcpEStatsPerfCurMSS</term>
		/// </item>
		/// <item>
		/// <term>MaxMss</term>
		/// <term>tcpEStatsStackMaxMSS</term>
		/// </item>
		/// <item>
		/// <term>MinMss</term>
		/// <term>tcpEStatsStackMinMSS</term>
		/// </item>
		/// <item>
		/// <term>SpuriousRtoDetections</term>
		/// <term>tcpEStatsStackSpuriousRtoDetected</term>
		/// </item>
		/// </list>
		/// <para>
		/// The TCP_ESTATS_FINE_RTT_ROD_v0 structure has members that provide similar data to the <c>RttVar</c>, <c>MaxRtt</c>,
		/// <c>MinRtt</c>, and <c>SumRtt</c> members of the <c>TCP_ESTATS_PATH_ROD_v0</c> structure. However, the time is reported in
		/// microseconds for the similar members of the <c>TCP_ESTATS_FINE_RTT_ROD_v0</c> structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_path_rod_v0 typedef struct
		// _TCP_ESTATS_PATH_ROD_v0 { ULONG FastRetran; ULONG Timeouts; ULONG SubsequentTimeouts; ULONG CurTimeoutCount; ULONG AbruptTimeouts;
		// ULONG PktsRetrans; ULONG BytesRetrans; ULONG DupAcksIn; ULONG SacksRcvd; ULONG SackBlocksRcvd; ULONG CongSignals; ULONG
		// PreCongSumCwnd; ULONG PreCongSumRtt; ULONG PostCongSumRtt; ULONG PostCongCountRtt; ULONG EcnSignals; ULONG EceRcvd; ULONG
		// SendStall; ULONG QuenchRcvd; ULONG RetranThresh; ULONG SndDupAckEpisodes; ULONG SumBytesReordered; ULONG NonRecovDa; ULONG
		// NonRecovDaEpisodes; ULONG AckAfterFr; ULONG DsackDups; ULONG SampleRtt; ULONG SmoothedRtt; ULONG RttVar; ULONG MaxRtt; ULONG
		// MinRtt; ULONG SumRtt; ULONG CountRtt; ULONG CurRto; ULONG MaxRto; ULONG MinRto; ULONG CurMss; ULONG MaxMss; ULONG MinMss; ULONG
		// SpuriousRtoDetections; } TCP_ESTATS_PATH_ROD_v0, *PTCP_ESTATS_PATH_ROD_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "35ed2a10-caac-4004-80ac-f62c3880f5de")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_PATH_ROD_v0
		{
			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of invocations of the Fast Retransmit algorithm.</para>
			/// </summary>
			public uint FastRetran;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of times the retransmit timeout has expired when the retransmission timer back-off multiplier is equal to one.
			/// </para>
			/// </summary>
			public uint Timeouts;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of times the retransmit timeout has expired after the retransmission timer has been doubled.</para>
			/// <para>For more information, see section 5.5 of RFC 2988 discussed in the Remarks below.</para>
			/// </summary>
			public uint SubsequentTimeouts;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The current number of times the retransmit timeout has expired without receiving an acknowledgment for new data.</para>
			/// <para>
			/// The <c>CurTimeoutCount</c> member is reset to zero when new data is acknowledged and incremented for each invocation of
			/// Section 5.5 of RFC 2988.
			/// </para>
			/// </summary>
			public uint CurTimeoutCount;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of timeouts that occurred without any immediately preceding duplicate acknowledgments or other indications of
			/// congestion. Abrupt timeouts indicate that the path lost an entire window of data or acknowledgments.
			/// </para>
			/// <para>
			/// Timeouts that are preceded by duplicate acknowledgments or other congestion signals (Explicit Congestion Notification, for
			/// example) are not counted as abrupt, and might have been avoided by a more sophisticated Fast Retransmit algorithm.
			/// </para>
			/// </summary>
			public uint AbruptTimeouts;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of segments transmitted containing at least some retransmitted data.</para>
			/// </summary>
			public uint PktsRetrans;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of bytes retransmitted.</para>
			/// </summary>
			public uint BytesRetrans;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of duplicate ACKs received.</para>
			/// </summary>
			public uint DupAcksIn;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of Selective Acknowledgment (SACK) options received.</para>
			/// </summary>
			public uint SacksRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of SACK blocks received (within SACK options).</para>
			/// </summary>
			public uint SackBlocksRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of multiplicative downward congestion window adjustments due to all forms of congestion signals, including Fast
			/// Retransmit, Explicit Congestion Notification (ECN), and timeouts. This member summarizes all events that invoke the
			/// Multiplicative Decrease (MD) portion of Additive Increase Multiplicative Decrease (AIMD) congestion control, and as such is
			/// the best indicator of how a congestion windows is being affected by congestion.
			/// </para>
			/// <para>
			/// Note that retransmission timeouts multiplicatively reduce the window implicitly by setting the slow start threshold size, and
			/// are included in the value stored in the <c>CongSignals</c> member. In order to minimize spurious congestion indications due
			/// to out-of-order segments, the <c>CongSignals</c> member is incremented in association with the Fast Retransmit algorithm.
			/// </para>
			/// </summary>
			public uint CongSignals;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The sum of the values of the congestion window, in bytes, captured each time a congestion signal is received.</para>
			/// <para>
			/// This member is updated each time the <c>CongSignals</c> member is incremented, such that the change in the
			/// <c>PreCongSumCwnd</c> member divided by the change in the <c>CongSignals</c> member is the average window (over some
			/// interval) just prior to a congestion signal.
			/// </para>
			/// </summary>
			public uint PreCongSumCwnd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The sum, in milliseconds, of the last sample of the network round-trip-time (RTT) prior to the received congestion signals.
			/// The last sample of the RTT is stored in the <c>SampleRtt</c> member.
			/// </para>
			/// <para>
			/// The <c>PreCongSumRtt</c> member is updated each time the <c>CongSignals</c> member is incremented, such that the change in
			/// the <c>PreCongSumRtt</c> divided by the change in the <c>CongSignals</c> member is the average RTT (over some interval) just
			/// prior to a congestion signal.
			/// </para>
			/// </summary>
			public uint PreCongSumRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The sum, in milliseconds, of the first sample of the network RTT (stored in the <c>SampleRtt</c> member) following each
			/// congestion signal.
			/// </para>
			/// <para>
			/// The change in the <c>PostCongSumRtt</c> member divided by the change in the <c>PostCongCountRtt</c> member is the average RTT
			/// (over some interval) just after a congestion signal.
			/// </para>
			/// </summary>
			public uint PostCongSumRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of RTT samples, in bytes, included in the <c>PostCongSumRtt</c> member.</para>
			/// <para>
			/// The change in the <c>PostCongSumRtt</c> member divided by the change in the <c>PostCongCountRtt</c> member is the average RTT
			/// (over some interval) just after a congestion signal.
			/// </para>
			/// </summary>
			public uint PostCongCountRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of congestion signals delivered to the TCP sender via ECN.</para>
			/// <para>This is typically the number of segments bearing Echo Congestion</para>
			/// <para>Experienced (ECE) bits, but also includes segments failing the ECN nonce check or other explicit congestion signals.</para>
			/// </summary>
			public uint EcnSignals;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of segments received with IP headers bearing Congestion Experienced (CE) markings.</para>
			/// </summary>
			public uint EceRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of interface stalls or other sender local resource limitations that are treated as congestion signals.</para>
			/// </summary>
			public uint SendStall;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>Reserved for future use. This member is always set to zero.</para>
			/// </summary>
			public uint QuenchRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of duplicate acknowledgments required to trigger Fast Retransmit.</para>
			/// <para>Note that although this is constant in traditional Reno TCP implementations, it is adaptive in many newer TCP implementations.</para>
			/// </summary>
			public uint RetranThresh;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of Duplicate Acks Sent when prior Ack was not duplicate. This is the number of times that a contiguous series of
			/// duplicate acknowledgments have been sent.
			/// </para>
			/// <para>
			/// This is an indication of the number of data segments lost or reordered on the path from the remote TCP endpoint to the near
			/// TCP endpoint.
			/// </para>
			/// </summary>
			public uint SndDupAckEpisodes;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The sum of the amounts SND.UNA advances on the acknowledgment which ends a dup-ack episode without a retransmission.</para>
			/// <para>
			/// Note the change in the <c>SumBytesReordered</c> member divided by the change in the <c>NonRecovDaEpisodes</c> member is an
			/// estimate of the average reordering distance, over some interval.
			/// </para>
			/// </summary>
			public uint SumBytesReordered;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of duplicate acks (or SACKS) that did not trigger a Fast Retransmit because ACK advanced prior to the number of
			/// duplicate acknowledgments reaching the <c>RetranThresh</c>.
			/// </para>
			/// <para>
			/// Note that the change in the <c>NonRecovDa</c> member divided by the change in the <c>NonRecovDaEpisodes</c> member is an
			/// estimate of the average reordering distance in segments over some interval.
			/// </para>
			/// </summary>
			public uint NonRecovDa;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of duplicate acknowledgment episodes that did not trigger a Fast Retransmit because ACK advanced prior to the
			/// number of duplicate acknowledgments reaching the <c>RetranThresh</c>.
			/// </para>
			/// </summary>
			public uint NonRecovDaEpisodes;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>Reserved for future use. This member is always set to zero.</para>
			/// </summary>
			public uint AckAfterFr;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of duplicate segments reported to the local host by D-SACK blocks.</para>
			/// </summary>
			public uint DsackDups;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The most recent raw network round trip time measurement, in milliseconds, used in calculation of the retransmission timer (RTO).
			/// </para>
			/// </summary>
			public uint SampleRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The smoothed round trip time, in milliseconds, used in calculation of the RTO.</para>
			/// </summary>
			public uint SmoothedRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The round trip time variation, in milliseconds, used in calculation of the RTO.</para>
			/// </summary>
			public uint RttVar;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum sampled round trip time in milliseconds.</para>
			/// </summary>
			public uint MaxRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The minimum sampled round trip time in milliseconds.</para>
			/// </summary>
			public uint MinRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The sum of all sampled round trip times in milliseconds.</para>
			/// <para>
			/// Note that the change in the <c>SumRtt</c> member divided by the change in the <c>CountRtt</c> member is the mean RTT,
			/// uniformly averaged over an enter interval.
			/// </para>
			/// </summary>
			public uint SumRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of round trip time samples included in the <c>SumRtt</c> member.</para>
			/// </summary>
			public uint CountRtt;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The current value, in milliseconds, of the retransmit timer.</para>
			/// </summary>
			public uint CurRto;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum value, in milliseconds, of the retransmit timer.</para>
			/// </summary>
			public uint MaxRto;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The minimum value, in milliseconds, of the retransmit timer.</para>
			/// </summary>
			public uint MinRto;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The current maximum segment size (MSS), in bytes.</para>
			/// </summary>
			public uint CurMss;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum MSS, in bytes.</para>
			/// </summary>
			public uint MaxMss;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The minimum MSS, in bytes.</para>
			/// </summary>
			public uint MinMss;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of acknowledgments reporting segments that have already been retransmitted due to a Retransmission Timeout.</para>
			/// </summary>
			public uint SpuriousRtoDetections;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_PATH_RW_v0</c> structure contains read/write configuration information for extended TCP statistics on path
		/// measurement for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_PATH_RW_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_PATH_RW_v0</c> is defined as version 0 of the structure for read/write configuration information on extended
		/// path measurement for a TCP connection. This information is used to infer segment reordering on the path from the local sender to
		/// the remote receiver.
		/// </para>
		/// <para>
		/// Extended TCP statistics on extended path measurement information for a TCP connection are enabled and disabled using this
		/// structure and the SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsPath</c> is
		/// passed in the EstatsType parameter.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_PATH_RW_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or GetPerTcpConnectionEStats
		/// functions when <c>TcpConnectionEstatsPath</c> is passed in the EstatsType parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-tcp_estats_path_rw_v0 typedef struct
		// _TCP_ESTATS_PATH_RW_v0 { BOOLEAN EnableCollection; } TCP_ESTATS_PATH_RW_v0, *PTCP_ESTATS_PATH_RW_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "460ad710-06aa-490a-9bac-5a8c731687e9")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_PATH_RW_v0
		{
			/// <summary>
			/// <para>A value that indicates if extended statistics on a TCP connection should be collected for path measurement information.</para>
			/// <para>
			/// If this member is set to <c>TRUE</c>, extended statistics on the TCP connection are enabled. If this member is set to
			/// <c>FALSE</c>, extended statistics on the TCP connection are disabled.
			/// </para>
			/// <para>The default state for this member when not set is disabled.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool EnableCollection;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_REC_ROD_v0</c> structure contains read-only dynamic information for extended TCP statistics on the local
		/// receiver for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_REC_ROD_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_REC_ROD_v0</c> is defined as version 0 of the structure for read-only dynamic information for extended TCP
		/// statistics on the local receiver for a TCP connection. This information is available after the connection has been established.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_REC_ROD_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or GetPerTcpConnectionEStats
		/// functions when <c>TcpConnectionEstatsRec</c> is passed in the EstatsType parameter. Extended TCP statistics need to be enabled to
		/// retrieve this structure.
		/// </para>
		/// <para>
		/// TCP congestion control and congestion control algorithms are discussed in detail in the IETF RFC 2581 on TCP Congestion Control.
		/// For more information, see http://www.ietf.org/rfc/rfc2581.txt.
		/// </para>
		/// <para>
		/// Explicit Congestion Notification in IP is discussed in detail in the IETF RFC 2581 on The Addition of Explicit Congestion
		/// Notification (ECN) to IP. For more information, see http://www.ietf.org/rfc/rfc3168.txt.
		/// </para>
		/// <para>
		/// The members of this structure are defined in the IETF RFC on the TCP Extended Statistics MIB. For more information, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// <para>
		/// The following is the mapping of the members in the <c>TCP_ESTATS_REC_ROD_v0</c> structure to the entries defined in RFC 4898 for
		/// extended TCP statistics:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CurRwinSent</term>
		/// <term>tcpEStatsPerfCurRwinSent</term>
		/// </item>
		/// <item>
		/// <term>MaxRwinSent</term>
		/// <term>tcpEStatsPerfMaxRwinSent</term>
		/// </item>
		/// <item>
		/// <term>MinRwinSent</term>
		/// <term>No mapping to this member.</term>
		/// </item>
		/// <item>
		/// <term>LimRwin</term>
		/// <term>tcpEStatsTuneLimRwin</term>
		/// </item>
		/// <item>
		/// <term>DupAckEpisodes</term>
		/// <term>tcpEStatsPathDupAckEpisodes</term>
		/// </item>
		/// <item>
		/// <term>DupAcksOut</term>
		/// <term>tcpEStatsPathDupAcksOut</term>
		/// </item>
		/// <item>
		/// <term>CeRcvd</term>
		/// <term>tcpEStatsPathCERcvd</term>
		/// </item>
		/// <item>
		/// <term>EcnSent</term>
		/// <term>No mapping to this member.</term>
		/// </item>
		/// <item>
		/// <term>EcnNoncesRcvd</term>
		/// <term>No mapping to this member.</term>
		/// </item>
		/// <item>
		/// <term>CurReasmQueue</term>
		/// <term>tcpEStatsStackCurReasmQueue</term>
		/// </item>
		/// <item>
		/// <term>MaxReasmQueue</term>
		/// <term>tcpEStatsStackMaxReasmQueue</term>
		/// </item>
		/// <item>
		/// <term>CurAppRQueue</term>
		/// <term>tcpEStatsAppCurAppRQueue</term>
		/// </item>
		/// <item>
		/// <term>MaxAppRQueue</term>
		/// <term>tcpEStatsAppMaxAppRQueue</term>
		/// </item>
		/// <item>
		/// <term>WinScaleSent</term>
		/// <term>tcpEStatsStackWinScaleSent</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_rec_rod_v0 typedef struct
		// _TCP_ESTATS_REC_ROD_v0 { ULONG CurRwinSent; ULONG MaxRwinSent; ULONG MinRwinSent; ULONG LimRwin; ULONG DupAckEpisodes; ULONG
		// DupAcksOut; ULONG CeRcvd; ULONG EcnSent; ULONG EcnNoncesRcvd; ULONG CurReasmQueue; ULONG MaxReasmQueue; SIZE_T CurAppRQueue;
		// SIZE_T MaxAppRQueue; UCHAR WinScaleSent; } TCP_ESTATS_REC_ROD_v0, *PTCP_ESTATS_REC_ROD_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "1481f108-1ea3-4952-9131-8b15e373d83e")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_REC_ROD_v0
		{
			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The most recent window advertisement, in bytes, that has been sent.</para>
			/// </summary>
			public uint CurRwinSent;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum window advertisement, in bytes, that has been sent.</para>
			/// </summary>
			public uint MaxRwinSent;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The minimum window advertisement, in bytes, that has been sent.</para>
			/// </summary>
			public uint MinRwinSent;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum window advertisement, in bytes, that may be sent.</para>
			/// </summary>
			public uint LimRwin;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of Duplicate Acks Sent when prior Ack was not duplicate. This is the number of times that a contiguous series of
			/// duplicate acknowledgments have been sent.
			/// </para>
			/// <para>
			/// This is an indication of the number of data segments lost or reordered on the path from the remote TCP endpoint to the near
			/// TCP endpoint.
			/// </para>
			/// </summary>
			public uint DupAckEpisodes;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of duplicate ACKs sent.</para>
			/// <para>
			/// The ratio of the change in the <c>DupAcksOut</c> member to the change in the <c>DupAckEpisodes</c> member is an indication of
			/// reorder or recovery distance over some interval.
			/// </para>
			/// </summary>
			public uint DupAcksOut;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of segments received with IP headers bearing Congestion Experienced (CE) markings.</para>
			/// </summary>
			public uint CeRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>Reserved for future use. This member is always set to zero.</para>
			/// </summary>
			public uint EcnSent;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>Reserved for future use. This member is always set to zero.</para>
			/// </summary>
			public uint EcnNoncesRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The current number of bytes of sequence space spanned by the reassembly queue.</para>
			/// <para>
			/// This is generally the difference between rcv.nxt and the sequence number of the right most edge of the reassembly queue.
			/// </para>
			/// </summary>
			public uint CurReasmQueue;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum number of bytes of sequence space spanned by the reassembly queue.</para>
			/// <para>This is the maximum value of the <c>CurReasmQueue</c> member.</para>
			/// </summary>
			public uint MaxReasmQueue;

			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>The current number of bytes of application data that has been acknowledged by TCP but not yet delivered to the application.</para>
			/// </summary>
			public SizeT CurAppRQueue;

			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>The maximum number of bytes of application data that has been acknowledged by TCP but not yet delivered to the application.</para>
			/// </summary>
			public SizeT MaxAppRQueue;

			/// <summary>
			/// <para>Type: <c>UCHAR</c></para>
			/// <para>The value of the transmitted window scale option if one was sent; otherwise, a value of -1.</para>
			/// <para>
			/// Note that if both the <c>WinScaleSent</c> member and the <c>WinScaleRcvd</c> member of the TCP_ESTATS_OBS_REC_ROD_v0
			/// structure are not -1, then Rcv.Wind.Scale will be the same as this value and used to scale receiver window announcements from
			/// the local host to the remote host.
			/// </para>
			/// </summary>
			public byte WinScaleSent;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_REC_RW_v0</c> structure contains read/write configuration information for extended TCP statistics on the local
		/// receiver for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_REC_RW_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_REC_RW_v0</c> is defined as version 0 of the structure for read/write configuration information on the local
		/// receiver for a TCP connection.
		/// </para>
		/// <para>
		/// Extended TCP statistics on local-receiver information for a TCP connection are enabled and disabled using this structure and the
		/// SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsRec</c> is passed in the EstatsType parameter.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_REC_RW_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or GetPerTcpConnectionEStats
		/// functions when <c>TcpConnectionEstatsRec</c> is passed in the EstatsType parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_rec_rw_v0 typedef struct
		// _TCP_ESTATS_REC_RW_v0 { BOOLEAN EnableCollection; } TCP_ESTATS_REC_RW_v0, *PTCP_ESTATS_REC_RW_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "e780ae7b-30c6-4890-8a8b-9e0b2739c176")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_REC_RW_v0
		{
			/// <summary>
			/// <para>A value that indicates if extended statistics on a TCP connection should be collected for local-receiver information.</para>
			/// <para>
			/// If this member is set to <c>TRUE</c>, extended statistics on the TCP connection are enabled. If this member is set to
			/// <c>FALSE</c>, extended statistics on the TCP connection are disabled.
			/// </para>
			/// <para>The default state for this member when not set is disabled.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool EnableCollection;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_SEND_BUFF_ROD_v0</c> structure contains read-only dynamic information for extended TCP statistics on output
		/// queuing for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_SEND_BUFF_ROD_v0</c> structure is used as part of the TCP extended statistics feature available on Windows
		/// Vista and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SEND_BUFF_ROD_v0</c> is defined as version 0 of the structure for read-only dynamic information for extended
		/// TCP statistics on output queuing for a TCP connection. This information is available after the connection has been established.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SEND_BUFF_ROD_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsSendBuff</c> is passed in the EstatsType parameter. Extended TCP
		/// statistics need to be enabled to retrieve this structure.
		/// </para>
		/// <para>
		/// The members of this structure are defined in the IETF RFC on the TCP Extended Statistics MIB. For more information, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// <para>
		/// The following is the mapping of the members in the <c>TCP_ESTATS_SEND_BUFF_ROD_v0</c> structure to the entries defined in RFC
		/// 4898 for extended TCP statistics:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CurRetxQueue</term>
		/// <term>tcpEStatsStackCurRetxQueue</term>
		/// </item>
		/// <item>
		/// <term>MaxRetxQueue</term>
		/// <term>tcpEStatsStackMaxRetxQueue</term>
		/// </item>
		/// <item>
		/// <term>CurAppWQueue</term>
		/// <term>tcpEStatsAppCurAppWQueue</term>
		/// </item>
		/// <item>
		/// <term>MaxAppWQueue</term>
		/// <term>tcpEStatsAppMaxAppWQueue</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_send_buff_rod_v0 typedef struct
		// _TCP_ESTATS_SEND_BUFF_ROD_v0 { SIZE_T CurRetxQueue; SIZE_T MaxRetxQueue; SIZE_T CurAppWQueue; SIZE_T MaxAppWQueue; }
		// TCP_ESTATS_SEND_BUFF_ROD_v0, *PTCP_ESTATS_SEND_BUFF_ROD_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "7cda7378-95e4-4f1d-88b3-27974fedec83")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_SEND_BUFF_ROD_v0
		{
			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>The current number of bytes of data occupying the retransmit queue.</para>
			/// </summary>
			public SizeT CurRetxQueue;

			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>The maximum number of bytes of data occupying the retransmit queue.</para>
			/// </summary>
			public SizeT MaxRetxQueue;

			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>
			/// The current number of bytes of application data buffered by TCP, pending the first transmission (to the left of SND.NXT or SndMax).
			/// </para>
			/// <para>
			/// This data will generally be transmitted (and SND.NXT advanced to the left) as soon as there is an available congestion window
			/// or receiver window. This is the amount of data readily available for transmission, without scheduling the application. TCP
			/// performance may suffer if there is insufficient queued write data.
			/// </para>
			/// </summary>
			public SizeT CurAppWQueue;

			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>The maximum number of bytes of application data buffered by TCP, pending the first transmission.</para>
			/// <para>
			/// This is the maximum value of the <c>CurAppWQueue</c> member. The <c>MaxAppWQueue</c> and <c>CurAppWQueue</c> members can be
			/// used to determine if insufficient queued data is steady state (suggesting insufficient queue space) or transient (suggesting
			/// insufficient application performance or excessive CPU load or scheduler latency).
			/// </para>
			/// </summary>
			public SizeT MaxAppWQueue;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_SEND_BUFF_RW_v0</c> structure contains read/write configuration information for extended TCP statistics on
		/// output queuing for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_SEND_BUFF_RW_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SEND_BUFF_RW_v0</c> is defined as version 0 of the structure for read/write configuration information on output
		/// queuing for a TCP connection.
		/// </para>
		/// <para>
		/// Extended TCP statistics on output queuing for a TCP connection are enabled and disabled using this structure and the
		/// SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsSendBuff</c> is passed in the
		/// EstatsType parameter.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SEND_BUFF_RW_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsSendBuff</c> is passed in the EstatsType parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_send_buff_rw_v0 typedef struct
		// _TCP_ESTATS_SEND_BUFF_RW_v0 { BOOLEAN EnableCollection; } TCP_ESTATS_SEND_BUFF_RW_v0, *PTCP_ESTATS_SEND_BUFF_RW_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "1bc88d95-24d2-4ca3-9f4a-298d5c08f4de")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_SEND_BUFF_RW_v0
		{
			/// <summary>
			/// <para>A value that indicates if extended statistics on a TCP connection should be collected on output queuing.</para>
			/// <para>
			/// If this member is set to <c>TRUE</c>, extended statistics on the TCP connection are enabled. If this member is set to
			/// <c>FALSE</c>, extended statistics on the TCP connection are disabled.
			/// </para>
			/// <para>The default state for this member when not set is disabled.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool EnableCollection;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_SND_CONG_ROD_v0</c> structure contains read-only dynamic information for extended TCP statistics on sender
		/// congestion related data for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_SND_CONG_ROD_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SND_CONG_ROD_v0</c> is defined as version 0 of the structure for read-only dynamic information on sender
		/// congestion related data for a TCP connection. This information is available after the connection has been established.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SND_CONG_ROD_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsSndCong</c> is passed in the EstatsType parameter. Extended TCP
		/// statistics need to be enabled to retrieve this structure.
		/// </para>
		/// <para>
		/// TCP congestion control and congestion control algorithms are discussed in detail in the IETF RFC on TCP Congestion Control. For
		/// more information, see http://www.ietf.org/rfc/rfc2581.txt.
		/// </para>
		/// <para>
		/// The members of this structure are defined in the IETF RFC on the TCP Extended Statistics MIB. For more information, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// <para>
		/// The following is the mapping of the members in the <c>TCP_ESTATS_SND_CONG_ROD_v0</c> structure to the entries defined in RFC 4898
		/// for extended TCP statistics:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SndLimTransRwin</term>
		/// <term>tcpEStatsPerfSndLimTransRwin</term>
		/// </item>
		/// <item>
		/// <term>SndLimTimeRwin</term>
		/// <term>tcpEStatsPerfSndLimTimeRwin</term>
		/// </item>
		/// <item>
		/// <term>SndLimBytesRwin</term>
		/// <term>No mapping to this member.</term>
		/// </item>
		/// <item>
		/// <term>SndLimTransCwnd</term>
		/// <term>tcpEStatsPerfSndLimTransCwnd</term>
		/// </item>
		/// <item>
		/// <term>SndLimTimeCwnd</term>
		/// <term>tcpEStatsPerfSndLimTimeCwnd</term>
		/// </item>
		/// <item>
		/// <term>SndLimBytesCwnd</term>
		/// <term>No mapping to this member.</term>
		/// </item>
		/// <item>
		/// <term>SndLimTransSnd</term>
		/// <term>tcpEStatsPerfSndLimTransSnd</term>
		/// </item>
		/// <item>
		/// <term>SndLimTimeSnd</term>
		/// <term>tcpEStatsPerfSndLimTimeSnd</term>
		/// </item>
		/// <item>
		/// <term>SndLimBytesSnd</term>
		/// <term>No mapping to this member.</term>
		/// </item>
		/// <item>
		/// <term>SlowStart</term>
		/// <term>tcpEStatsStackSlowStart</term>
		/// </item>
		/// <item>
		/// <term>CongAvoid</term>
		/// <term>tcpEStatsStackCongAvoid</term>
		/// </item>
		/// <item>
		/// <term>OtherReductions</term>
		/// <term>tcpEStatsStackOtherReductions</term>
		/// </item>
		/// <item>
		/// <term>CurCwnd</term>
		/// <term>tcpEStatsPerfCurCwnd</term>
		/// </item>
		/// <item>
		/// <term>MaxSsCwnd</term>
		/// <term>tcpEStatsStackMaxSsCwnd</term>
		/// </item>
		/// <item>
		/// <term>MaxCaCwnd</term>
		/// <term>tcpEStatsStackMaxCaCwnd</term>
		/// </item>
		/// <item>
		/// <term>CurSsthresh</term>
		/// <term>tcpEStatsPerfCurSsthresh</term>
		/// </item>
		/// <item>
		/// <term>MaxSsthresh</term>
		/// <term>tcpEStatsStackMaxSsthresh</term>
		/// </item>
		/// <item>
		/// <term>MinSsthresh</term>
		/// <term>tcpEStatsStackMinSsthresh</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_snd_cong_rod_v0 typedef struct
		// _TCP_ESTATS_SND_CONG_ROD_v0 { ULONG SndLimTransRwin; ULONG SndLimTimeRwin; SIZE_T SndLimBytesRwin; ULONG SndLimTransCwnd; ULONG
		// SndLimTimeCwnd; SIZE_T SndLimBytesCwnd; ULONG SndLimTransSnd; ULONG SndLimTimeSnd; SIZE_T SndLimBytesSnd; ULONG SlowStart; ULONG
		// CongAvoid; ULONG OtherReductions; ULONG CurCwnd; ULONG MaxSsCwnd; ULONG MaxCaCwnd; ULONG CurSsthresh; ULONG MaxSsthresh; ULONG
		// MinSsthresh; } TCP_ESTATS_SND_CONG_ROD_v0, *PTCP_ESTATS_SND_CONG_ROD_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "5eb2d1c6-d4ba-4038-b598-ead517679ae7")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_SND_CONG_ROD_v0
		{
			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of transitions into the "Receiver Limited" state from either the "Congestion Limited" or "Sender Limited" states.
			/// This state is entered whenever TCP transmission stops because the sender has filled the announced receiver window.
			/// </para>
			/// </summary>
			public uint SndLimTransRwin;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The cumulative time, in milliseconds, spent in the "Receiver Limited" state where TCP transmission stops because the sender
			/// has filled the announced receiver window.
			/// </para>
			/// </summary>
			public uint SndLimTimeRwin;

			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>The total number of bytes sent in the "Receiver Limited" state.</para>
			/// </summary>
			public SizeT SndLimBytesRwin;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of transitions into the "Congestion Limited" state from either the "Receiver Limited" or "Sender Limited" states.
			/// This state is entered whenever TCP transmission stops because the sender has reached some limit defined by TCP congestion
			/// control (the congestion window, for example) or other algorithms (retransmission timeouts) designed to control network traffic.
			/// </para>
			/// </summary>
			public uint SndLimTransCwnd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The cumulative time, in milliseconds, spent in the "Congestion Limited" state. When there is a retransmission timeout, it is
			/// counted in this member and not the cumulative time for some other state.
			/// </para>
			/// </summary>
			public uint SndLimTimeCwnd;

			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>The total number of bytes sent in the "Congestion Limited" state.</para>
			/// </summary>
			public SizeT SndLimBytesCwnd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of transitions into the "Sender Limited" state from either the "Receiver Limited" or "Congestion Limited" states.
			/// This state is entered whenever TCP transmission stops due to some sender limit such as running out of application data or
			/// other resources and the Karn algorithm. When TCP stops sending data for any reason, which cannot be classified as "Receiver
			/// Limited" or "Congestion Limited", it is treated as "Sender Limited".
			/// </para>
			/// </summary>
			public uint SndLimTransSnd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The cumulative time, in milliseconds, spent in the "Sender Limited" state.</para>
			/// </summary>
			public uint SndLimTimeSnd;

			/// <summary>
			/// <para>Type: <c>SIZE_T</c></para>
			/// <para>The total number of bytes sent in the "Sender Limited" state.</para>
			/// </summary>
			public SizeT SndLimBytesSnd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of times the congestion window has been increased by the "Slow Start" algorithm.</para>
			/// </summary>
			public uint SlowStart;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of times the congestion window has been increased by the "Congestion Avoidance" algorithm.</para>
			/// </summary>
			public uint CongAvoid;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of congestion window reductions made as a result of anything other than congestion control algorithms other than
			/// "Slow Start" and "Congestion Avoidance" algorithms.
			/// </para>
			/// </summary>
			public uint OtherReductions;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The size, in bytes, of the current congestion window.</para>
			/// </summary>
			public uint CurCwnd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum size, in bytes, of the congestion window size used during "Slow Start."</para>
			/// </summary>
			public uint MaxSsCwnd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum size, in bytes, of the congestion window used during "Congestion Avoidance."</para>
			/// </summary>
			public uint MaxCaCwnd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The current size, in bytes, of the slow start threshold.</para>
			/// </summary>
			public uint CurSsthresh;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum size, in bytes, of the slow start threshold, excluding the initial value.</para>
			/// </summary>
			public uint MaxSsthresh;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The minimum size, in bytes, of the slow start threshold.</para>
			/// </summary>
			public uint MinSsthresh;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_SND_CONG_ROS_v0</c> structure contains read-only static information for extended TCP statistics on the maximum
		/// congestion window for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_SND_CONG_ROS_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SND_CONG_ROS_v0</c> is defined as version 0 of the structure for read-only dynamic information on basic sender
		/// congestion data for a TCP connection. This information is available after the connection has been established.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SND_CONG_ROS_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsSndCong</c> is passed in the EstatsType parameter. Extended TCP
		/// statistics need to be enabled to retrieve this structure.
		/// </para>
		/// <para>
		/// TCP congestion control and congestion control algorithms are discussed in detail in the IETF RFC on TCP Congestion Control. For
		/// more information, see http://www.ietf.org/rfc/rfc2581.txt.
		/// </para>
		/// <para>
		/// The members of this structure are defined in the IETF RFC on the TCP Extended Statistics MIB. For more information, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// <para>
		/// The following is the mapping of the members in the <c>TCP_ESTATS_SND_CONG_ROS_v0</c> structure to the entries defined in RFC 4898
		/// for extended TCP statistics:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>LimCwnd</term>
		/// <term>tcpEStatsTuneLimCwnd</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_snd_cong_ros_v0 typedef struct
		// _TCP_ESTATS_SND_CONG_ROS_v0 { ULONG LimCwnd; } TCP_ESTATS_SND_CONG_ROS_v0, *PTCP_ESTATS_SND_CONG_ROS_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "4c92af92-ed51-4548-873f-b25207ea46dc")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_SND_CONG_ROS_v0
		{
			/// <summary>The maximum size, in bytes, of the congestion window that may be used.</summary>
			public uint LimCwnd;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_SND_CONG_RW_v0</c> structure contains read/write configuration information for extended TCP statistics on
		/// sender congestion for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_SND_CONG_RW_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SND_CONG_RW_v0</c> is defined as version 0 of the structure for read/write configuration information on sender
		/// congestion for a TCP connection.
		/// </para>
		/// <para>
		/// Extended TCP statistics on sender congestion for a TCP connection are enabled and disabled using this structure and the
		/// SetPerTcp6ConnectionEStats and SetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsSndCongs</c> is passed in the
		/// EstatsType parameter.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SND_CONG_RW_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsSndCong</c> is passed in the EstatsType parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-tcp_estats_snd_cong_rw_v0 typedef struct
		// _TCP_ESTATS_SND_CONG_RW_v0 { BOOLEAN EnableCollection; } TCP_ESTATS_SND_CONG_RW_v0, *PTCP_ESTATS_SND_CONG_RW_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "7fc7fb6a-4486-450f-b60e-8cf07b33c79a")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_SND_CONG_RW_v0
		{
			/// <summary>
			/// <para>A value that indicates if extended statistics on a TCP connection should be collected for sender congestion.</para>
			/// <para>
			/// If this member is set to <c>TRUE</c>, extended statistics on the TCP connection are enabled. If this member is set to
			/// <c>FALSE</c>, extended statistics on the TCP connection are disabled.
			/// </para>
			/// <para>The default state for this member when not set is disabled.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool EnableCollection;
		}

		/// <summary>
		/// The <c>TCP_ESTATS_SYN_OPTS_ROS_v0</c> structure contains read-only static information for extended TCP statistics on SYN exchange
		/// for a TCP connection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>TCP_ESTATS_SYN_OPTS_ROS_v0</c> structure is used as part of the TCP extended statistics feature available on Windows Vista
		/// and later.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SYN_OPTS_ROS_v0</c> is defined as version 0 of the structure for read-only static information on SYN exchange
		/// for a TCP connection. The TCP protocol does not permit the members of this structure to change after the SYN exchange. This
		/// information is available after the SYN exchange has completed.
		/// </para>
		/// <para>
		/// The <c>TCP_ESTATS_SYN_OPTS_ROS_v0</c> structure is retrieved by calls to the GetPerTcp6ConnectionEStats or
		/// GetPerTcpConnectionEStats functions when <c>TcpConnectionEstatsSynOpts</c> is passed in the EstatsType parameter. Extended TCP
		/// statistics do not need to be enabled to retrieve this structure.
		/// </para>
		/// <para>
		/// The MSS in the <c>MssRcvd</c> and <c>MssSent</c> members is the maximum data in a single TCP datagram. The MSS can be a very
		/// large value.
		/// </para>
		/// <para>
		/// The members of this structure are defined in the IETF RFC on the TCP Extended Statistics MIB. For more information, see http://www.ietf.org/rfc/rfc4898.txt.
		/// </para>
		/// <para>
		/// The following is the mapping of the members in the <c>TCP_ESTATS_SYN_OPTS_ROS_v0</c> structure to the entries defined in RFC 4898
		/// for extended TCP statistics:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ActiveOpen</term>
		/// <term>tcpEStatsStackActiveOpen</term>
		/// </item>
		/// <item>
		/// <term>MssRcvd</term>
		/// <term>tcpEStatsStackMSSRcvd</term>
		/// </item>
		/// <item>
		/// <term>MssSent</term>
		/// <term>tcpEStatsStackMSSSent</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tcpestats/ns-tcpestats-_tcp_estats_syn_opts_ros_v0 typedef struct
		// _TCP_ESTATS_SYN_OPTS_ROS_v0 { BOOLEAN ActiveOpen; ULONG MssRcvd; ULONG MssSent; } TCP_ESTATS_SYN_OPTS_ROS_v0, *PTCP_ESTATS_SYN_OPTS_ROS_v0;
		[PInvokeData("tcpestats.h", MSDNShortId = "e183b23c-ce87-4818-b6d6-2305a3aa345d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TCP_ESTATS_SYN_OPTS_ROS_v0
		{
			/// <summary>
			/// <para>Type: <c>BOOLEAN</c></para>
			/// <para>A value that indicates if the TCP connection was an active open.</para>
			/// <para>
			/// If the local connection traversed the SYN-SENT state, then this member is set to <c>TRUE</c>. Otherwise, this member is set
			/// to <c>FALSE</c>.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool ActiveOpen;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The value received in an Maximum Segment Size (MSS) option during the SYN exchange, or zero if no MSS option was received.</para>
			/// <para>This value is the maximum data in a single TCP datagram that the remote host can receive.</para>
			/// </summary>
			public uint MssRcvd;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The value sent in an MSS option during the SYN exchange, or zero if no MSS option was sent.</para>
			/// </summary>
			public uint MssSent;
		}
	}
}