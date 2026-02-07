#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Vanara.PInvoke;

/// <summary>A COM-based API that merges classic and IP telephony.</summary>
public static partial class TAPI3
{
	public static readonly Guid CLSID_FilePlaybackTerminal = new("{0CB9914C-79CD-47DC-ADB0-327F47CEFB20}");

	public static readonly Guid CLSID_FileRecordingTerminal = new("{521F3D06-C3D0-4511-8617-86B9A783DA77}");

	public static readonly Guid CLSID_HandsetTerminal = new("{AAF578EB-DC70-11D0-8ED3-00C04FB6809F}");

	public static readonly Guid CLSID_HeadsetTerminal = new("{AAF578ED-DC70-11D0-8ED3-00C04FB6809F}");

	public static readonly Guid CLSID_MediaStreamTerminal = new("{E2F7AEF7-4971-11D1-A671-006097C9A2E8}");

	public static readonly Guid CLSID_MicrophoneTerminal = new("{AAF578EF-DC70-11D0-8ED3-00C04FB6809F}");

	public static readonly Guid CLSID_SpeakerphoneTerminal = new("{AAF578EE-DC70-11D0-8ED3-00C04FB6809F}");

	public static readonly Guid CLSID_SpeakersTerminal = new("{AAF578F0-DC70-11D0-8ED3-00C04FB6809F}");

	public static readonly Guid CLSID_VideoInputTerminal = new("{AAF578EC-DC70-11D0-8ED3-00C04FB6809F}");

	public static readonly Guid CLSID_VideoWindowTerm = new("{F7438990-D6EB-11D0-82A6-00AA00B5CA1B}");

	public static readonly Guid TAPIPROTOCOL_H323 = new("{831CE2D7-83B5-11d1-BB5C-00C04FB6809F}");

	public static readonly Guid TAPIPROTOCOL_Multicast = new("{831CE2D8-83B5-11d1-BB5C-00C04FB6809F}");

	public static readonly Guid TAPIPROTOCOL_PSTN = new("{831CE2D6-83B5-11d1-BB5C-00C04FB6809F}");

	/// <summary>
	/// The <b>ACDGROUP_EVENT</b> enum describes ACD group events. The <c>ITACDGroupEvent::get_Event</c> method returns a member of this enum
	/// to indicate the type of ACD group event that occurred.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3/ne-tapi3-acdgroup_event typedef enum ACDGROUP_EVENT { ACDGE_NEW_GROUP = 0,
	// ACDGE_GROUP_REMOVED } ;
	[PInvokeData("tapi3.h", MSDNShortId = "NE:tapi3.ACDGROUP_EVENT")]
	public enum ACDGROUP_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A new ACD group has been added.</para>
		/// </summary>
		ACDGE_NEW_GROUP,

		/// <summary>An ACD group has been removed.</summary>
		ACDGE_GROUP_REMOVED,
	}

	/// <summary>
	/// The <b>ACDQUEUE_EVENT</b> enum describes ACD queue events. The <c>ITQueueEvent::get_Event</c> method returns a member of this enum to
	/// indicate the type of ACD queue event that occurred.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3/ne-tapi3-acdqueue_event typedef enum ACDQUEUE_EVENT { ACDQE_NEW_QUEUE = 0,
	// ACDQE_QUEUE_REMOVED } ;
	[PInvokeData("tapi3.h", MSDNShortId = "NE:tapi3.ACDQUEUE_EVENT")]
	public enum ACDQUEUE_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A new ACD queue has been added.</para>
		/// </summary>
		ACDQE_NEW_QUEUE,

		/// <summary>An ACD queue has been removed.</summary>
		ACDQE_QUEUE_REMOVED,
	}

	/// <summary>
	/// A member of the <b>ADDRESS_CAPABILITY</b> enum is used by the <c>ITAddressCapabilities::get_AddressCapability</c> method to indicate
	/// the address capability required.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-address_capability typedef enum ADDRESS_CAPABILITY {
	// AC_ADDRESSTYPES = 0, AC_BEARERMODES, AC_MAXACTIVECALLS, AC_MAXONHOLDCALLS, AC_MAXONHOLDPENDINGCALLS, AC_MAXNUMCONFERENCE,
	// AC_MAXNUMTRANSCONF, AC_MONITORDIGITSUPPORT, AC_GENERATEDIGITSUPPORT, AC_GENERATETONEMODES, AC_GENERATETONEMAXNUMFREQ,
	// AC_MONITORTONEMAXNUMFREQ, AC_MONITORTONEMAXNUMENTRIES, AC_DEVCAPFLAGS, AC_ANSWERMODES, AC_LINEFEATURES, AC_SETTABLEDEVSTATUS,
	// AC_PARKSUPPORT, AC_CALLERIDSUPPORT, AC_CALLEDIDSUPPORT, AC_CONNECTEDIDSUPPORT, AC_REDIRECTIONIDSUPPORT, AC_REDIRECTINGIDSUPPORT,
	// AC_ADDRESSCAPFLAGS, AC_CALLFEATURES1, AC_CALLFEATURES2, AC_REMOVEFROMCONFCAPS, AC_REMOVEFROMCONFSTATE, AC_TRANSFERMODES,
	// AC_ADDRESSFEATURES, AC_PREDICTIVEAUTOTRANSFERSTATES, AC_MAXCALLDATASIZE, AC_LINEID, AC_ADDRESSID, AC_FORWARDMODES,
	// AC_MAXFORWARDENTRIES, AC_MAXSPECIFICENTRIES, AC_MINFWDNUMRINGS, AC_MAXFWDNUMRINGS, AC_MAXCALLCOMPLETIONS, AC_CALLCOMPLETIONCONDITIONS,
	// AC_CALLCOMPLETIONMODES, AC_PERMANENTDEVICEID, AC_GATHERDIGITSMINTIMEOUT, AC_GATHERDIGITSMAXTIMEOUT, AC_GENERATEDIGITMINDURATION,
	// AC_GENERATEDIGITMAXDURATION, AC_GENERATEDIGITDEFAULTDURATION } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.ADDRESS_CAPABILITY")]
	public enum ADDRESS_CAPABILITY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>An address may support more than one</para>
		/// <para>address type</para>
		/// <para>, but please note that one may be used during</para>
		/// <para>ITAddress::CreateCall</para>
		/// <para>.</para>
		/// </summary>
		AC_ADDRESSTYPES,

		/// <summary>
		/// <para>Bearer modes</para>
		/// <para>.</para>
		/// </summary>
		AC_BEARERMODES,

		/// <summary>
		/// The maximum number of (minimum bandwidth) calls that can be active (connected) on the line at any one time. The actual number of
		/// active calls can be lower if higher bandwidth calls are established on the line.
		/// </summary>
		AC_MAXACTIVECALLS,

		/// <summary>Maximum number of calls that can be on hold at once.</summary>
		AC_MAXONHOLDCALLS,

		/// <summary>Maximum number of calls that can be simultaneously pending transfer or conference.</summary>
		AC_MAXONHOLDPENDINGCALLS,

		/// <summary>Contains the maximum number of parties that can join a single conference call on this address.</summary>
		AC_MAXNUMCONFERENCE,

		/// <summary>
		/// <para>
		/// Specifies the number of parties (including "self") that can be added in a conference call that is initiated as a generic
		/// consultation call using
		/// </para>
		/// <para>ITBasicCallControl::Transfer</para>
		/// <para>and</para>
		/// <para>ITBasicCallControl::Finish</para>
		/// <para>(FM_ASCONFERENCE).</para>
		/// </summary>
		AC_MAXNUMTRANSCONF,

		/// <summary>
		/// <para>Specifies digit modes detectable on this address using the</para>
		/// <para>LINEDIGITMODE_</para>
		/// <para>flags. If no flag is set, digit monitoring is not supported.</para>
		/// </summary>
		AC_MONITORDIGITSUPPORT,

		/// <summary>
		/// <para>Specifies digit modes that can be generated on this address using a subset of the</para>
		/// <para>LINEDIGITMODE_</para>
		/// <para>
		/// flags: LINEDIGITMODE_PULSE indicates digits can be generated as pulse/rotary tones, and LINEDIGITMODE_DTMF indicates digits can
		///        be generated as DTMF tones. If no flag is set, digit generation is not supported.
		/// </para>
		/// </summary>
		AC_GENERATEDIGITSUPPORT,

		/// <summary>
		/// <para>Specifies the different kinds of tones that can be generated on this line, of type</para>
		/// <para>LINETONEMODE_</para>
		/// <para>.</para>
		/// </summary>
		AC_GENERATETONEMODES,

		/// <summary>Contains the maximum number of frequencies that can be specified in describing a general tone.</summary>
		AC_GENERATETONEMAXNUMFREQ,

		/// <summary>
		/// Contains the maximum number of frequencies that can be specified when monitoring a general tone. A value of 0 indicates that tone
		/// monitor is not available.
		/// </summary>
		AC_MONITORTONEMAXNUMFREQ,

		/// <summary>Contains the maximum number of entries that can be specified in a tone list.</summary>
		AC_MONITORTONEMAXNUMENTRIES,

		/// <summary>
		/// <para>Device capability flags</para>
		/// <para>.</para>
		/// </summary>
		AC_DEVCAPFLAGS,

		/// <summary>
		/// <para>Answer modes</para>
		/// <para>.</para>
		/// </summary>
		AC_ANSWERMODES,

		/// <summary>
		/// <para>Specifies the features available for this line using the</para>
		/// <para>LINEFEATURE_ constants</para>
		/// <para>
		/// . Invoking a supported feature requires the line to be in the proper state and the underlying line device to be opened in a
		/// compatible mode. A zero in a bit position indicates that the corresponding feature is never available. A one indicates that the
		/// corresponding feature may be available if the line is in the appropriate state for the operation to be meaningful. This member
		/// allows an application to discover which line features can be (and which can never be) supported by the device.
		/// </para>
		/// </summary>
		AC_LINEFEATURES,

		/// <summary>
		/// <para>Indicates</para>
		/// <para>LINEDEVSTATUS_</para>
		/// <para>values that can be modified.</para>
		/// </summary>
		AC_SETTABLEDEVSTATUS,

		/// <summary>
		/// <para>Indicates whether park is supported using the</para>
		/// <para>LINEPARKMODE_</para>
		/// <para>flags.</para>
		/// </summary>
		AC_PARKSUPPORT,

		/// <summary>
		/// <para>Identifies support for caller number identification using the</para>
		/// <para>LINECALLPARTYID_</para>
		/// <para>flags.</para>
		/// </summary>
		AC_CALLERIDSUPPORT,

		/// <summary>
		/// <para>Identifies support for called number identification using the</para>
		/// <para>LINECALLPARTYID_</para>
		/// <para>flags.</para>
		/// </summary>
		AC_CALLEDIDSUPPORT,

		/// <summary>
		/// <para>Indicates whether connected ID is supported using the</para>
		/// <para>LINECALLPARTYID_</para>
		/// <para>flags.</para>
		/// </summary>
		AC_CONNECTEDIDSUPPORT,

		/// <summary>
		/// <para>Indicates whether redirection ID is supported using the</para>
		/// <para>LINECALLPARTYID_</para>
		/// <para>flags.</para>
		/// </summary>
		AC_REDIRECTIONIDSUPPORT,

		/// <summary>
		/// <para>Indicates whether redirecting ID is supported using the</para>
		/// <para>LINECALLPARTYID_</para>
		/// <para>flags.</para>
		/// </summary>
		AC_REDIRECTINGIDSUPPORT,

		/// <summary>
		/// <para>The address</para>
		/// <para>capability flags</para>
		/// <para>
		/// describe various Boolean address capabilities. For example, LINEADDRCAPFLAGS_FWDNUMRINGS indicates whether the number of rings
		/// for a no-answer can be specified when forwarding on a no-answer.
		/// </para>
		/// </summary>
		AC_ADDRESSCAPFLAGS,

		/// <summary>
		/// <para>Call feature set one</para>
		/// <para>.</para>
		/// </summary>
		AC_CALLFEATURES1,

		/// <summary>
		/// <para>Supplemental call features</para>
		/// <para>for conferencing, transferring, and parking calls.</para>
		/// </summary>
		AC_CALLFEATURES2,

		/// <summary>
		/// <para>Specifies the address's capabilities for removing calls from a conference call. This member uses the</para>
		/// <para>LINEREMOVEFROMCONF_ constants</para>
		/// <para>.</para>
		/// </summary>
		AC_REMOVEFROMCONFCAPS,

		/// <summary>
		/// <para>Uses the</para>
		/// <para>LINECALLSTATE_ constants</para>
		/// <para>to specify the state of the call after it has been removed from a conference call.</para>
		/// </summary>
		AC_REMOVEFROMCONFSTATE,

		/// <summary>
		/// <para>Transfer modes</para>
		/// <para>.</para>
		/// </summary>
		AC_TRANSFERMODES,

		/// <summary>
		/// <para>The</para>
		/// <para>line address features</para>
		/// <para>
		/// describe operations that can be invoked on an address. For example, if LINEADDRFEATURE_FORWARD is set, the address can be forwarded.
		/// </para>
		/// </summary>
		AC_ADDRESSFEATURES,

		/// <summary>
		/// <para>
		/// The call state or states upon which a call made by a predictive dialer can be set to automatically transfer the call to another
		/// address; one or more of the
		/// </para>
		/// <para>LINECALLSTATE_ constants</para>
		/// <para>. The value 0 indicates automatic transfer based on call state is unavailable.</para>
		/// </summary>
		AC_PREDICTIVEAUTOTRANSFERSTATES,

		/// <summary>Maximum data block size allowed.</summary>
		AC_MAXCALLDATASIZE,

		/// <summary>
		/// <para>Returns the device identifier of the line device with which this address is associated. TAPI 2.1 cross-reference:</para>
		/// <para>LINEADDRESSCAPS</para>
		/// <para>.</para>
		/// </summary>
		AC_LINEID,

		/// <summary>
		/// Address identifier. An address identifier is permanently associated with an address; the identifier remains constant across
		/// operating system upgrades.
		/// </summary>
		AC_ADDRESSID,

		/// <summary>
		/// <para>Forwarding modes</para>
		/// <para>.</para>
		/// </summary>
		AC_FORWARDMODES,

		/// <summary>The maximum number of different forwarding entries that can be supported by the current address.</summary>
		AC_MAXFORWARDENTRIES,

		/// <summary>
		/// <para>Specifies the maximum number of entries that can be set using</para>
		/// <para>ITForwardInformation::SetForwardType</para>
		/// <para>
		/// that can contain forwarding instructions based on a specific caller (selective call forwarding). This member is zero if selective
		/// call forwarding is not supported.
		/// </para>
		/// </summary>
		AC_MAXSPECIFICENTRIES,

		/// <summary>Specifies the minimum number of rings that can be set to determine when a call is officially considered "no answer."</summary>
		AC_MINFWDNUMRINGS,

		/// <summary>Specifies the maximum number of rings that can be set to determine when a call is officially considered "no answer."</summary>
		AC_MAXFWDNUMRINGS,

		/// <summary>
		/// The maximum number of concurrent call completion requests that can be outstanding on this address. Zero implies that call
		/// completion is not available.
		/// </summary>
		AC_MAXCALLCOMPLETIONS,

		/// <summary>
		/// <para>Call completion conditions</para>
		/// <para>.</para>
		/// </summary>
		AC_CALLCOMPLETIONCONDITIONS,

		/// <summary>
		/// <para>Call completion modes</para>
		/// <para>.</para>
		/// </summary>
		AC_CALLCOMPLETIONMODES,

		/// <summary>
		/// The permanent identifier by which the line device is known in the system's configuration. This value does not change as lines are
		/// added and removed from the system. It can therefore be used to link line-specific information in the registry or other files in a
		/// way that is not affected by changes in other lines. If a line has more than one address, all addresses will have the same
		/// permanent device identifier. TSP writers should note that this value must be preserved across operating system upgrades.
		/// </summary>
		AC_PERMANENTDEVICEID,

		/// <summary/>
		AC_GATHERDIGITSMINTIMEOUT,

		/// <summary/>
		AC_GATHERDIGITSMAXTIMEOUT,

		/// <summary/>
		AC_GENERATEDIGITMINDURATION,

		/// <summary/>
		AC_GENERATEDIGITMAXDURATION,

		/// <summary/>
		AC_GENERATEDIGITDEFAULTDURATION,
	}

	/// <summary>The <b>ADDRESS_CAPABILITY_STRING</b> enum is used to check on address capabilities which are described by strings.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-address_capability_string typedef enum
	// ADDRESS_CAPABILITY_STRING { ACS_PROTOCOL = 0, ACS_ADDRESSDEVICESPECIFIC, ACS_LINEDEVICESPECIFIC, ACS_PROVIDERSPECIFIC,
	// ACS_SWITCHSPECIFIC, ACS_PERMANENTDEVICEGUID } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.ADDRESS_CAPABILITY_STRING")]
	public enum ADDRESS_CAPABILITY_STRING
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Describes a protocol-specific capability. The value is returned as a GUID in string format. For possible values, see</para>
		/// <para>TAPIPROTOCOL_</para>
		/// <para>. A TSP may define additional values. Corresponds to the</para>
		/// <para>ProtocolGuid</para>
		/// <para>member of TAPI 2's</para>
		/// <para>LINEDEVCAPS</para>
		/// <para>structure.</para>
		/// </summary>
		ACS_PROTOCOL,

		/// <summary>
		/// <para>
		/// Describes an address device-specific capability. The value is TSP dependent and can be a structure, a string, or some other type.
		/// An application should use the
		/// </para>
		/// <para>BSTR</para>
		/// <para>
		/// pointer received from Tapi3.dll as a pointer to an array of bytes (a buffer), and then interpret the buffer according to TSP
		/// specifications. Corresponds to the
		/// </para>
		/// <para>dwDevSpecific</para>
		/// <para>and</para>
		/// <para>dwDevSpecificSize</para>
		/// <para>members of TAPI 2's</para>
		/// <para>LINEADDRESSCAPS</para>
		/// <para>structure.</para>
		/// </summary>
		ACS_ADDRESSDEVICESPECIFIC,

		/// <summary>
		/// <para>
		/// Describes a line device-specific capability. The value is TSP dependent and can be a structure, a string, or some other type. An
		/// application should use the
		/// </para>
		/// <para>BSTR</para>
		/// <para>
		/// pointer received from Tapi3.dll as a pointer to an array of bytes (a buffer), and then interpret the buffer according to TSP
		/// specifications. Corresponds to the
		/// </para>
		/// <para>dwDevSpecific</para>
		/// <para>and</para>
		/// <para>dwDevSpecificSize</para>
		/// <para>members of TAPI 2's</para>
		/// <para>LINEDEVCAPS</para>
		/// <para>structure.</para>
		/// </summary>
		ACS_LINEDEVICESPECIFIC,

		/// <summary>
		/// <para>Describes a provider-specific capability. The value is a plain string. It can be used with regular</para>
		/// <para>BSTR</para>
		/// <para>functions for operations such as printing and concatenating. A specific TSP might included embedded</para>
		/// <para>NULL</para>
		/// <para>characters inside these strings. If so, an application should take care when printing the value. If the embedded</para>
		/// <para>NULL</para>
		/// <para>characters are not replaced with blanks, the strings will appear truncated when printed. Corresponds to the</para>
		/// <para>dwProviderInfoSize</para>
		/// <para>and</para>
		/// <para>dwProviderInfoOffset</para>
		/// <para>members of TAPI 2's</para>
		/// <para>LINEDEVCAPS</para>
		/// <para>structure.</para>
		/// </summary>
		ACS_PROVIDERSPECIFIC,

		/// <summary>
		/// <para>Describes a switch-specific capability. The value is a plain string. It can be used with regular</para>
		/// <para>BSTR</para>
		/// <para>functions for operations such as printing and concatenating. A specific TSP might included embedded</para>
		/// <para>NULL</para>
		/// <para>characters inside these strings. If so, an application should take care when printing the value. If the embedded</para>
		/// <para>NULL</para>
		/// <para>characters are not replaced with blanks, the strings will appear truncated when printed. Corresponds to the</para>
		/// <para>dwSwitchInfoSize</para>
		/// <para>and</para>
		/// <para>dwSwitchInfoOffset</para>
		/// <para>members of TAPI 2's</para>
		/// <para>LINEDEVCAPS</para>
		/// <para>structure.</para>
		/// </summary>
		ACS_SWITCHSPECIFIC,

		/// <summary>
		/// <para>
		/// Describes the GUID of a permanent device. The value is returned as a GUID in string format. This identifier must remain stable
		/// throughout, including operating system upgrades. Corresponds to the
		/// </para>
		/// <para>PermanentLineGuid</para>
		/// <para>member of TAPI 2's</para>
		/// <para>LINEDEVCAPS</para>
		/// <para>structure.</para>
		/// </summary>
		ACS_PERMANENTDEVICEGUID,
	}

	/// <summary>
	/// The <b>ADDRESS_EVENT</b> enum describes address events. The <c>ITAddressEvent::get_Event</c> method returns a member of this enum to
	/// indicate the type of address event that occurred.
	/// </summary>
	/// <remarks>
	/// Certain events on PnP devices will not be received until after the first time static terminals are enumerated using
	/// <c>ITTerminalSupport::EnumerateStaticTerminals</c> or <c>ITTerminalSupport::get_StaticTerminals</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-address_event typedef enum ADDRESS_EVENT { AE_STATE = 0,
	// AE_CAPSCHANGE, AE_RINGING, AE_CONFIGCHANGE, AE_FORWARD, AE_NEWTERMINAL, AE_REMOVETERMINAL, AE_MSGWAITON, AE_MSGWAITOFF, AE_LASTITEM } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.ADDRESS_EVENT")]
	public enum ADDRESS_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The address state has changed. See</para>
		/// <para>ITAddress::get_State</para>
		/// <para>.</para>
		/// </summary>
		AE_STATE,

		/// <summary>
		/// <para>Address capabilities have changed. See</para>
		/// <para>capability flags</para>
		/// <para>.</para>
		/// </summary>
		AE_CAPSCHANGE,

		/// <summary>There is ringing on the address.</summary>
		AE_RINGING,

		/// <summary>The address configuration has changed.</summary>
		AE_CONFIGCHANGE,

		/// <summary>
		/// <para>Forwarding has changed. See</para>
		/// <para>ITAddress::get_CurrentForwardInfo</para>
		/// <para>.</para>
		/// </summary>
		AE_FORWARD,

		/// <summary>
		/// A new terminal has been added. The application should respond by selecting the terminal if it is going to be used on an active call.
		/// </summary>
		AE_NEWTERMINAL,

		/// <summary>
		/// A terminal has been removed. The application should respond by unselecting the terminal if it is currently selected to an active call.
		/// </summary>
		AE_REMOVETERMINAL,

		/// <summary>The message waiting indicator has been turned on. This applies only to phone addresses.</summary>
		AE_MSGWAITON,

		/// <summary>The message waiting indicator has been turned off. This applies only to phone addresses.</summary>
		AE_MSGWAITOFF,
	}

	/// <summary>The <b>ADDRESS_STATE</b> enum is used by the <c>ITAddress::get_State</c> method to check the address state.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-address_state typedef enum ADDRESS_STATE { AS_INSERVICE = 0,
	// AS_OUTOFSERVICE } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.ADDRESS_STATE")]
	public enum ADDRESS_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Normal state; the address can be used.</para>
		/// </summary>
		AS_INSERVICE,

		/// <summary>The address is temporarily out of service, but may go back into service at some time.</summary>
		AS_OUTOFSERVICE,
	}

	/// <summary>
	/// The <b>AGENT_EVENT</b> enum describes agent events. The <c>ITAgentEvent::get_Event</c> method returns a member of this enum to
	/// indicate the type of agent event that occurred.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3/ne-tapi3-agent_event typedef enum AGENT_EVENT { AE_NOT_READY = 0, AE_READY,
	// AE_BUSY_ACD, AE_BUSY_INCOMING, AE_BUSY_OUTGOING, AE_UNKNOWN } ;
	[PInvokeData("tapi3.h", MSDNShortId = "NE:tapi3.AGENT_EVENT")]
	public enum AGENT_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The agent is unable to handle calls.</para>
		/// </summary>
		AE_NOT_READY,

		/// <summary>The agent is able to handle calls.</summary>
		AE_READY,

		/// <summary>The agent is active handling an ACD call.</summary>
		AE_BUSY_ACD,

		/// <summary>The agent is active handling an incoming non-ACD call.</summary>
		AE_BUSY_INCOMING,

		/// <summary>The agent is active handling an outgoing non-ACD call.</summary>
		AE_BUSY_OUTGOING,

		/// <summary>Unknown state.</summary>
		AE_UNKNOWN,
	}

	/// <summary>
	/// The <b>AGENT_SESSION_EVENT</b> enum describes agent session events. The <c>ITAgentSessionEvent::get_Event</c> method returns a member
	/// of this enum to indicate the type of agent session event that occurred.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3cc/ne-tapi3cc-agent_session_event typedef enum AGENT_SESSION_EVENT {
	// ASE_NEW_SESSION = 0, ASE_NOT_READY, ASE_READY, ASE_BUSY, ASE_WRAPUP, ASE_END } ;
	[PInvokeData("tapi3cc.h", MSDNShortId = "NE:tapi3cc.AGENT_SESSION_EVENT")]
	public enum AGENT_SESSION_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A new agent session has been created.</para>
		/// </summary>
		ASE_NEW_SESSION,

		/// <summary>The agent is unable to handle calls for this session.</summary>
		ASE_NOT_READY,

		/// <summary>The agent is able to handle calls for this session.</summary>
		ASE_READY,

		/// <summary>The agent is active in this session handling an ACD call.</summary>
		ASE_BUSY,

		/// <summary>The agent is active in this session handling the wrap-up of an ACD call.</summary>
		ASE_WRAPUP,

		/// <summary>The session has completed.</summary>
		ASE_END,
	}

	/// <summary>
	/// This <b>AGENT_SESSION_STATE</b> enum defines the agent session indicators used by the <c>ITAgentSession::get_State</c> and the
	/// <c>ITAgentSession::put_State</c> methods.
	/// </summary>
	/// <remarks>
	/// <para>Following is a table of all valid AgentSession state transitions.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>From state</description>
	/// <description>To state</description>
	/// </listheader>
	/// <item>
	/// <description>ASST_NOT_READY</description>
	/// <description>ASST_READY ASST_SESSION_ENDED</description>
	/// </item>
	/// <item>
	/// <description>ASST_READY</description>
	/// <description>ASST_BUSY_ON_CALL ASST_NOT_READY ASST_SESSION_ENDED</description>
	/// </item>
	/// <item>
	/// <description>ASST_BUSY_ON_CALL</description>
	/// <description>ASST_BUSY_WRAPUP ASST_READY ASST_NOT_READY ASST_SESSION_ENDED</description>
	/// </item>
	/// <item>
	/// <description>ASST_BUSY_WRAPUP</description>
	/// <description>ASST_READY ASST_NOT_READY ASST_SESSION_ENDED</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3/ne-tapi3-agent_session_state typedef enum AGENT_SESSION_STATE {
	// ASST_NOT_READY = 0, ASST_READY, ASST_BUSY_ON_CALL, ASST_BUSY_WRAPUP, ASST_SESSION_ENDED } ;
	[PInvokeData("tapi3.h", MSDNShortId = "NE:tapi3.AGENT_SESSION_STATE")]
	public enum AGENT_SESSION_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The agent is unable to handle calls for this session.</para>
		/// </summary>
		ASST_NOT_READY,

		/// <summary>The agent is able to handle calls for this session.</summary>
		ASST_READY,

		/// <summary>The agent is active in this session handling an ACD call.</summary>
		ASST_BUSY_ON_CALL,

		/// <summary>The agent is active in this session handling the wrap-up of an ACD call.</summary>
		ASST_BUSY_WRAPUP,

		/// <summary>The session has completed.</summary>
		ASST_SESSION_ENDED,
	}

	/// <summary>
	/// The <b>AGENT_STATE</b> enum is used by the <c>ITAgent::put_State</c> and <c>ITAgent::get_State</c> methods to describe the agent state.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3/ne-tapi3-agent_state typedef enum AGENT_STATE { AS_NOT_READY = 0, AS_READY,
	// AS_BUSY_ACD, AS_BUSY_INCOMING, AS_BUSY_OUTGOING, AS_UNKNOWN } ;
	[PInvokeData("tapi3.h", MSDNShortId = "NE:tapi3.AGENT_STATE")]
	public enum AGENT_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Agent is not ready</para>
		/// </summary>
		AS_NOT_READY,

		/// <summary>Agent is ready</summary>
		AS_READY,

		/// <summary>Agent is busy with an ACD call.</summary>
		AS_BUSY_ACD,

		/// <summary>Agent has a call incoming.</summary>
		AS_BUSY_INCOMING,

		/// <summary>Agent has a call that is outgoing.</summary>
		AS_BUSY_OUTGOING,

		/// <summary>Agent state unknown.</summary>
		AS_UNKNOWN,
	}

	/// <summary>
	/// The <b>AGENTHANDLER_EVENT</b> enum describes agent handler events. The <c>ITAgentHandlerEvent::get_Event</c> method returns a member
	/// of this enum to indicate the type of agent handler event that occurred.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3/ne-tapi3-agenthandler_event typedef enum AGENTHANDLER_EVENT {
	// AHE_NEW_AGENTHANDLER = 0, AHE_AGENTHANDLER_REMOVED } ;
	[PInvokeData("tapi3.h", MSDNShortId = "NE:tapi3.AGENTHANDLER_EVENT")]
	public enum AGENTHANDLER_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A new AgentHandler object has been added.</para>
		/// </summary>
		AHE_NEW_AGENTHANDLER,

		/// <summary>An AgentHandler object has been removed.</summary>
		AHE_AGENTHANDLER_REMOVED,
	}

	/// <summary>
	/// The <b>CALL_MEDIA_EVENT</b> enum describes call media events. The <c>ITCallMediaEvent::get_Event</c> method returns a member of this
	/// enum to indicate the type of call media event that occurred.
	/// </summary>
	/// <remarks>Due to latency, stream events may continue for a few seconds after a stream or related call session has been torn down.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-call_media_event typedef enum CALL_MEDIA_EVENT { CME_NEW_STREAM
	// = 0, CME_STREAM_FAIL, CME_TERMINAL_FAIL, CME_STREAM_NOT_USED, CME_STREAM_ACTIVE, CME_STREAM_INACTIVE, CME_LASTITEM } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALL_MEDIA_EVENT")]
	public enum CALL_MEDIA_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A new media stream has been created.</para>
		/// </summary>
		CME_NEW_STREAM,

		/// <summary>A media stream or stream request has failed.</summary>
		CME_STREAM_FAIL,

		/// <summary>A terminal has failed.</summary>
		CME_TERMINAL_FAIL,

		/// <summary>The media stream has not been used.</summary>
		CME_STREAM_NOT_USED,

		/// <summary>The media stream is active.</summary>
		CME_STREAM_ACTIVE,

		/// <summary>The media stream is not active.</summary>
		CME_STREAM_INACTIVE,
	}

	/// <summary>
	/// The <b>CALL_MEDIA_EVENT_CAUSE</b> enum is used by <c>ITCallMediaEvent::get_Cause</c> method to return a description of what caused a
	/// media event, such as a device timeout.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-call_media_event_cause typedef enum CALL_MEDIA_EVENT_CAUSE {
	// CMC_UNKNOWN = 0, CMC_BAD_DEVICE, CMC_CONNECT_FAIL, CMC_LOCAL_REQUEST, CMC_REMOTE_REQUEST, CMC_MEDIA_TIMEOUT, CMC_MEDIA_RECOVERED,
	// CMC_QUALITY_OF_SERVICE } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALL_MEDIA_EVENT_CAUSE")]
	public enum CALL_MEDIA_EVENT_CAUSE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Call media is unknown.</para>
		/// </summary>
		CMC_UNKNOWN,

		/// <summary>Device source or renderer is not functioning.</summary>
		CMC_BAD_DEVICE,

		/// <summary>Could not connect to media device.</summary>
		CMC_CONNECT_FAIL,

		/// <summary>A local request has been received.</summary>
		CMC_LOCAL_REQUEST,

		/// <summary>A remote request has been received.</summary>
		CMC_REMOTE_REQUEST,

		/// <summary>The media device timed out.</summary>
		CMC_MEDIA_TIMEOUT,

		/// <summary>Media processing has resumed after an interruption.</summary>
		CMC_MEDIA_RECOVERED,

		/// <summary/>
		CMC_QUALITY_OF_SERVICE,
	}

	/// <summary>
	/// The <b>CALL_NOTIFICATION_EVENT</b> enum describes call notification events. The <c>ITCallNotificationEvent::get_Event</c> method
	/// returns a member of this enum to indicate the type of call notification event that occurred.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-call_notification_event typedef enum CALL_NOTIFICATION_EVENT {
	// CNE_OWNER = 0, CNE_MONITOR, CNE_LASTITEM } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALL_NOTIFICATION_EVENT")]
	public enum CALL_NOTIFICATION_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The current application owns the call on which the event occurred.</para>
		/// </summary>
		CNE_OWNER,

		/// <summary>The current application is monitoring the call on which the event occurred.</summary>
		CNE_MONITOR,
	}

	/// <summary>
	/// A <b>CALL_PRIVILEGE</b> member is returned by the <c>ITCallInfo::get_Privilege</c> method, and indicates when the current application
	/// owns or is monitoring the current call.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-call_privilege typedef enum CALL_PRIVILEGE { CP_OWNER = 0,
	// CP_MONITOR } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALL_PRIVILEGE")]
	public enum CALL_PRIVILEGE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The application is the owner of the call.</para>
		/// </summary>
		CP_OWNER,

		/// <summary>The application is a monitor of the call.</summary>
		CP_MONITOR,
	}

	/// <summary>The <b>CALL_STATE</b> enum is used by the <c>ITCallInfo::get_CallState</c> and <c>ITCallStateEvent::get_State</c> methods.</summary>
	/// <remarks>
	/// <para>Following is a table of all valid call state transitions.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>From state</description>
	/// <description>To state</description>
	/// </listheader>
	/// <item>
	/// <description>CS_IDLE</description>
	/// <description>INPROGRESS CONNECTED DISCONNECTED OFFERING HOLD</description>
	/// </item>
	/// <item>
	/// <description>CS_INPROGRESS</description>
	/// <description>CONNECTED DISCONNECTED HOLD</description>
	/// </item>
	/// <item>
	/// <description>CS_CONNECTED</description>
	/// <description>HOLD DISCONNECTED</description>
	/// </item>
	/// <item>
	/// <description>CS_DISCONNECTED</description>
	/// <description>Nothing—call should be freed</description>
	/// </item>
	/// <item>
	/// <description>CS_OFFERING</description>
	/// <description>CONNECTED DISCONNECTED HOLD</description>
	/// </item>
	/// <item>
	/// <description>CS_HOLD</description>
	/// <description>CONNECTED DISCONNECTED</description>
	/// </item>
	/// <item>
	/// <description>CS_QUEUED</description>
	/// <description>CONNECTED DISCONNECTED HOLD</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-call_state typedef enum CALL_STATE { CS_IDLE = 0,
	// CS_INPROGRESS, CS_CONNECTED, CS_DISCONNECTED, CS_OFFERING, CS_HOLD, CS_QUEUED, CS_LASTITEM = CS_QUEUED } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALL_STATE")]
	public enum CALL_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The call has been created, but</para>
		/// <para>Connect</para>
		/// <para>
		/// has not been called yet. A call can never transition into the idle state. This is the initial state for both incoming and
		/// outgoing calls.
		/// </para>
		/// </summary>
		CS_IDLE,

		/// <summary>
		/// <para>Connect</para>
		/// <para>
		/// has been called, and the service provider is working on making a connection. This state is valid only on outgoing calls. This
		/// message is optional, because a service provider may have a call transition directly to the connected state.
		/// </para>
		/// </summary>
		CS_INPROGRESS,

		/// <summary>Call has been connected to the remote end and communication can take place.</summary>
		CS_CONNECTED,

		/// <summary>
		/// Call has been disconnected. There are several causes for disconnection. See the table of valid call state transitions below.
		/// </summary>
		CS_DISCONNECTED,

		/// <summary>
		/// <para>
		/// A new call has appeared, and is being offered to an application. If the application has owner privileges on the call, it can
		/// either call
		/// </para>
		/// <para>Answer</para>
		/// <para>or</para>
		/// <para>Disconnect</para>
		/// <para>while the call is in the offering state. Current call privilege can be determined by calling</para>
		/// <para>ITCallInfo::get_Privilege</para>
		/// <para>.</para>
		/// </summary>
		CS_OFFERING,

		/// <summary>The call is in the hold state.</summary>
		CS_HOLD,

		/// <summary>The call is queued.</summary>
		CS_QUEUED,
	}

	/// <summary>The <b>CALL_STATE_EVENT_CAUSE</b> enum is returned by the <c>ITCallStateEvent::get_Cause</c> method.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-call_state_event_cause typedef enum CALL_STATE_EVENT_CAUSE {
	// CEC_NONE = 0, CEC_DISCONNECT_NORMAL, CEC_DISCONNECT_BUSY, CEC_DISCONNECT_BADADDRESS, CEC_DISCONNECT_NOANSWER,
	// CEC_DISCONNECT_CANCELLED, CEC_DISCONNECT_REJECTED, CEC_DISCONNECT_FAILED, CEC_DISCONNECT_BLOCKED } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALL_STATE_EVENT_CAUSE")]
	public enum CALL_STATE_EVENT_CAUSE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No call event has occurred.</para>
		/// </summary>
		CEC_NONE,

		/// <summary>The call was disconnected as part of the normal life cycle of the call (that is, the call was over, so it was disconnected).</summary>
		CEC_DISCONNECT_NORMAL,

		/// <summary>An outgoing call failed to connect because the remote end was busy.</summary>
		CEC_DISCONNECT_BUSY,

		/// <summary>An outgoing call failed because the destination address was bad.</summary>
		CEC_DISCONNECT_BADADDRESS,

		/// <summary>An outgoing call failed because the remote end was not answered.</summary>
		CEC_DISCONNECT_NOANSWER,

		/// <summary>An outgoing call failed because the caller disconnected.</summary>
		CEC_DISCONNECT_CANCELLED,

		/// <summary>The outgoing call was rejected by the remote end.</summary>
		CEC_DISCONNECT_REJECTED,

		/// <summary>The call failed to connect for some other reason.</summary>
		CEC_DISCONNECT_FAILED,

		/// <summary/>
		CEC_DISCONNECT_BLOCKED,
	}

	/// <summary>
	/// The <b>CALLHUB_EVENT</b> enum describes CallHub events. The <c>ITCallHubEvent::get_Event</c> method returns a member of this enum to
	/// indicate the type of CallHub event that occurred.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-callhub_event typedef enum CALLHUB_EVENT { CHE_CALLJOIN = 0,
	// CHE_CALLLEAVE, CHE_CALLHUBNEW, CHE_CALLHUBIDLE, CHE_LASTITEM } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALLHUB_EVENT")]
	public enum CALLHUB_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A new call has joined the CallHub.</para>
		/// </summary>
		CHE_CALLJOIN,

		/// <summary>A call has left the CallHub.</summary>
		CHE_CALLLEAVE,

		/// <summary>A new CallHub has appeared.</summary>
		CHE_CALLHUBNEW,

		/// <summary>A CallHub has gone idle.</summary>
		CHE_CALLHUBIDLE,
	}

	/// <summary>The <b>CALLHUB_STATE</b> enum is a state indicator returned by the <c>ITCallHub::get_State</c> method.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-callhub_state typedef enum CALLHUB_STATE { CHS_ACTIVE = 0,
	// CHS_IDLE } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALLHUB_STATE")]
	public enum CALLHUB_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The CallHub is active. There is at least one call that is not in the CS_DISCONNECTED state.</para>
		/// </summary>
		CHS_ACTIVE,

		/// <summary>All calls associated with this CallHub are in the CS_DISCONNECTED state.</summary>
		CHS_IDLE,
	}

	/// <summary>
	/// <para>
	/// The <b>CALLINFO_BUFFER</b> enum indicates the type of buffer accessed by the <c>ITCallInfo::GetCallInfoBuffer</c> method or the
	/// <c>ITCallInfo::SetCallInfoBuffer</c> method.
	/// </para>
	/// <para>
	/// The <c>ITCallInfo::get_CallInfoBuffer</c> and <c>ITCallInfo::put_CallInfoBuffer</c> methods are provided for Automation client
	/// applications, such as those written in Visual Basic.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-callinfo_buffer typedef enum CALLINFO_BUFFER { CIB_USERUSERINFO
	// = 0, CIB_DEVSPECIFICBUFFER, CIB_CALLDATABUFFER, CIB_CHARGINGINFOBUFFER, CIB_HIGHLEVELCOMPATIBILITYBUFFER,
	// CIB_LOWLEVELCOMPATIBILITYBUFFER } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALLINFO_BUFFER")]
	public enum CALLINFO_BUFFER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// The user-user information buffer allows an application to send information to the remote party on a call or receive information
		/// from that party.
		/// </para>
		/// </summary>
		CIB_USERUSERINFO,

		/// <summary>
		/// The device-specific buffer allows an application to communicate with a TSP concerning device-specific capabilities. The precise
		/// nature of these capabilities depends on the implementation of the service provider.
		/// </summary>
		CIB_DEVSPECIFICBUFFER,

		/// <summary>
		/// The call data buffer allows an application to communicate with a TSP concerning a specific call. The precise nature of this
		/// information depends on the implementation of the service provider.
		/// </summary>
		CIB_CALLDATABUFFER,

		/// <summary>The charging information buffer's format is specified by other standards (ISDN Q.931).</summary>
		CIB_CHARGINGINFOBUFFER,

		/// <summary>The high-level compatibility buffer's format is specified by other standards (ISDN Q.931).</summary>
		CIB_HIGHLEVELCOMPATIBILITYBUFFER,

		/// <summary>The low-level compatibility buffer's format is specified by other standards (ISDN Q.931).</summary>
		CIB_LOWLEVELCOMPATIBILITYBUFFER,
	}

	/// <summary>The <b>CALLINFO_LONG</b> enum is used by <c>ITCallInfo</c> methods that set and get call information of type <b>LONG</b>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-callinfo_long typedef enum CALLINFO_LONG {
	// CIL_MEDIATYPESAVAILABLE = 0, CIL_BEARERMODE, CIL_CALLERIDADDRESSTYPE, CIL_CALLEDIDADDRESSTYPE, CIL_CONNECTEDIDADDRESSTYPE,
	// CIL_REDIRECTIONIDADDRESSTYPE, CIL_REDIRECTINGIDADDRESSTYPE, CIL_ORIGIN, CIL_REASON, CIL_APPSPECIFIC, CIL_CALLPARAMSFLAGS,
	// CIL_CALLTREATMENT, CIL_MINRATE, CIL_MAXRATE, CIL_COUNTRYCODE, CIL_CALLID, CIL_RELATEDCALLID, CIL_COMPLETIONID, CIL_NUMBEROFOWNERS,
	// CIL_NUMBEROFMONITORS, CIL_TRUNK, CIL_RATE, CIL_GENERATEDIGITDURATION, CIL_MONITORDIGITMODES, CIL_MONITORMEDIAMODES } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALLINFO_LONG")]
	public enum CALLINFO_LONG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The</para>
		/// <para>media types</para>
		/// <para>available on the call.</para>
		/// </summary>
		CIL_MEDIATYPESAVAILABLE,

		/// <summary>
		/// <para>The bearer mode of a call is described by the</para>
		/// <para>LINEBEARERMODE_ Constants</para>
		/// <para>.</para>
		/// </summary>
		CIL_BEARERMODE,

		/// <summary>
		/// <para>The</para>
		/// <para>address type</para>
		/// <para>of the caller.</para>
		/// </summary>
		CIL_CALLERIDADDRESSTYPE,

		/// <summary>
		/// <para>The</para>
		/// <para>address type</para>
		/// <para>of the called party.</para>
		/// </summary>
		CIL_CALLEDIDADDRESSTYPE,

		/// <summary>
		/// <para>The</para>
		/// <para>address type</para>
		/// <para>of the connected party.</para>
		/// </summary>
		CIL_CONNECTEDIDADDRESSTYPE,

		/// <summary>
		/// <para>The</para>
		/// <para>address type</para>
		/// <para>of the destination to which a call has been redirected.</para>
		/// </summary>
		CIL_REDIRECTIONIDADDRESSTYPE,

		/// <summary>
		/// <para>The</para>
		/// <para>address type</para>
		/// <para>of the location that redirected the call.</para>
		/// </summary>
		CIL_REDIRECTINGIDADDRESSTYPE,

		/// <summary>
		/// <para>The origin of a call is described by the</para>
		/// <para>LINECALLORIGIN_ Constants</para>
		/// <para>, such as LINECALLORIGIN_EXTERNAL.</para>
		/// </summary>
		CIL_ORIGIN,

		/// <summary>
		/// <para>The reason for a call is described by the</para>
		/// <para>LINECALLREASON_ Constants</para>
		/// <para>, such as LINECALLREASON_FWDUNCOND.</para>
		/// </summary>
		CIL_REASON,

		/// <summary>
		/// Application-specific information is used to pass information between applications in a multi-application environment. The
		/// information is not interpreted by the API implementation or the service provider. Only applications with owner privileges for the
		/// call can set it.
		/// </summary>
		CIL_APPSPECIFIC,

		/// <summary>
		/// <para>Call parameter flags are described by</para>
		/// <para>LINECALLPARAMFLAGS_ Constants</para>
		/// <para>, such as LINECALLPARAMFLAGS_BLOCKID. These flags are normally set during the creation of an outgoing call.</para>
		/// </summary>
		CIL_CALLPARAMSFLAGS,

		/// <summary>
		/// <para>Call treatment identifies how a call that is on hold or unanswered gets handled, and is described by</para>
		/// <para>LINECALLTREATMENT_ Constants</para>
		/// <para>, such as LINECALLTREATMENT_MUSIC.</para>
		/// </summary>
		CIL_CALLTREATMENT,

		/// <summary>The minimum rate for a call's data stream in bps (bits per second).</summary>
		CIL_MINRATE,

		/// <summary>The maximum rate for a call's data stream in bps (bits per second).</summary>
		CIL_MAXRATE,

		/// <summary>Country or region code.</summary>
		CIL_COUNTRYCODE,

		/// <summary>Call identifier. Some service providers assign a unique code to each call.</summary>
		CIL_CALLID,

		/// <summary>Call identifier for a call related to the current call, such as on a conference.</summary>
		CIL_RELATEDCALLID,

		/// <summary>
		/// Completion identifier. The completion identifier is used to identify individual completion requests in progress. A completion
		/// identifier becomes invalid and can be reused after the request completion or after an outstanding request is canceled.
		/// </summary>
		CIL_COMPLETIONID,

		/// <summary>The number of applications having owner privileges for the current call.</summary>
		CIL_NUMBEROFOWNERS,

		/// <summary>The number of applications having monitor privileges for the current call.</summary>
		CIL_NUMBEROFMONITORS,

		/// <summary>The trunk identifier for the current call.</summary>
		CIL_TRUNK,

		/// <summary>The current rate for a call's data stream in bps (bits per second).</summary>
		CIL_RATE,

		/// <summary/>
		CIL_GENERATEDIGITDURATION,

		/// <summary/>
		CIL_MONITORDIGITMODES,

		/// <summary/>
		CIL_MONITORMEDIAMODES,
	}

	/// <summary>
	/// The <b>CALLINFO_STRING</b> enum is used by <c>ITCallInfo</c> methods that set and get call information involving the use of strings.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-callinfo_string typedef enum CALLINFO_STRING { CIS_CALLERIDNAME
	// = 0, CIS_CALLERIDNUMBER, CIS_CALLEDIDNAME, CIS_CALLEDIDNUMBER, CIS_CONNECTEDIDNAME, CIS_CONNECTEDIDNUMBER, CIS_REDIRECTIONIDNAME,
	// CIS_REDIRECTIONIDNUMBER, CIS_REDIRECTINGIDNAME, CIS_REDIRECTINGIDNUMBER, CIS_CALLEDPARTYFRIENDLYNAME, CIS_COMMENT,
	// CIS_DISPLAYABLEADDRESS, CIS_CALLINGPARTYID } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALLINFO_STRING")]
	public enum CALLINFO_STRING
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The name of the caller.</para>
		/// </summary>
		CIS_CALLERIDNAME,

		/// <summary>The number of the caller.</summary>
		CIS_CALLERIDNUMBER,

		/// <summary>The name of the called location.</summary>
		CIS_CALLEDIDNAME,

		/// <summary>The number of the called location.</summary>
		CIS_CALLEDIDNUMBER,

		/// <summary>The name of the connected location.</summary>
		CIS_CONNECTEDIDNAME,

		/// <summary>The number of the connected location.</summary>
		CIS_CONNECTEDIDNUMBER,

		/// <summary>The name of the location to which a call has been redirected.</summary>
		CIS_REDIRECTIONIDNAME,

		/// <summary>The number of the location to which a call has been redirected.</summary>
		CIS_REDIRECTIONIDNUMBER,

		/// <summary>The name of the location that redirected the call.</summary>
		CIS_REDIRECTINGIDNAME,

		/// <summary>The number of the location that redirected the call.</summary>
		CIS_REDIRECTINGIDNUMBER,

		/// <summary>The called party friendly name.</summary>
		CIS_CALLEDPARTYFRIENDLYNAME,

		/// <summary>
		/// A comment about the call provided by the application that originated the call. The call state must be CS_IDLE when setting the comment.
		/// </summary>
		CIS_COMMENT,

		/// <summary>A displayable version of the called or calling address.</summary>
		CIS_DISPLAYABLEADDRESS,

		/// <summary>The identifier of the calling party.</summary>
		CIS_CALLINGPARTYID,
	}

	/// <summary>
	/// <para>
	/// The <b>CALLINFOCHANGE_CAUSE</b> enum is used by the <c>ITCallInfoChangeEvent::get_Cause</c> method to return a description of the
	/// type of call information that has changed.
	/// </para>
	/// <para>
	/// You can retrieve specific information about the change by using the TAPI 3 <c>ITCallInfo</c> interface. TAPI 2 applications use
	/// <c>lineGetCallInfo</c> or <c>lineGetCallStatus</c>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-callinfochange_cause typedef enum CALLINFOCHANGE_CAUSE {
	// CIC_OTHER = 0, CIC_DEVSPECIFIC, CIC_BEARERMODE, CIC_RATE, CIC_APPSPECIFIC, CIC_CALLID, CIC_RELATEDCALLID, CIC_ORIGIN, CIC_REASON,
	// CIC_COMPLETIONID, CIC_NUMOWNERINCR, CIC_NUMOWNERDECR, CIC_NUMMONITORS, CIC_TRUNK, CIC_CALLERID, CIC_CALLEDID, CIC_CONNECTEDID,
	// CIC_REDIRECTIONID, CIC_REDIRECTINGID, CIC_USERUSERINFO, CIC_HIGHLEVELCOMP, CIC_LOWLEVELCOMP, CIC_CHARGINGINFO, CIC_TREATMENT,
	// CIC_CALLDATA, CIC_PRIVILEGE, CIC_MEDIATYPE, CIC_LASTITEM } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.CALLINFOCHANGE_CAUSE")]
	public enum CALLINFOCHANGE_CAUSE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Unspecified call information has changed.</para>
		/// </summary>
		CIC_OTHER,

		/// <summary>Call information specific to a device has changed.</summary>
		CIC_DEVSPECIFIC,

		/// <summary>The bearer mode for the call has changed.</summary>
		CIC_BEARERMODE,

		/// <summary>The rate has changed.</summary>
		CIC_RATE,

		/// <summary>
		/// Call information specific to an application has changed. Application-specific information is used to pass information between
		/// applications in a multi-application environment. The information is not interpreted by the API implementation or the service
		/// provider. Only applications with owner privileges for the call can set it
		/// </summary>
		CIC_APPSPECIFIC,

		/// <summary>The call identifier has changed.</summary>
		CIC_CALLID,

		/// <summary>The related call identifier has changed.</summary>
		CIC_RELATEDCALLID,

		/// <summary>The call origin has changed.</summary>
		CIC_ORIGIN,

		/// <summary>The call reason has changed.</summary>
		CIC_REASON,

		/// <summary>The completion identifier has changed.</summary>
		CIC_COMPLETIONID,

		/// <summary>The number of owners has increased.</summary>
		CIC_NUMOWNERINCR,

		/// <summary>The number of owners has decreased.</summary>
		CIC_NUMOWNERDECR,

		/// <summary>The number of call monitors has changed.</summary>
		CIC_NUMMONITORS,

		/// <summary>Trunk used on call has changed.</summary>
		CIC_TRUNK,

		/// <summary>The caller identifier has changed.</summary>
		CIC_CALLERID,

		/// <summary>The called identifier has changed.</summary>
		CIC_CALLEDID,

		/// <summary>The connected identifier has changed.</summary>
		CIC_CONNECTEDID,

		/// <summary>The redirection identifier has changed.</summary>
		CIC_REDIRECTIONID,

		/// <summary>The redirecting identifier has changed.</summary>
		CIC_REDIRECTINGID,

		/// <summary>The user-user information buffer has changed.</summary>
		CIC_USERUSERINFO,

		/// <summary>The high-level compatibility information has changed (ISDN Q.931).</summary>
		CIC_HIGHLEVELCOMP,

		/// <summary>The low-level compatibility information has changed (ISDN Q.931).</summary>
		CIC_LOWLEVELCOMP,

		/// <summary>The call's charging information has changed.</summary>
		CIC_CHARGINGINFO,

		/// <summary>Treatment of calls on hold has changed.</summary>
		CIC_TREATMENT,

		/// <summary>The call data buffer has changed.</summary>
		CIC_CALLDATA,

		/// <summary>
		/// <para>Call privilege</para>
		/// <para>has changed.</para>
		/// </summary>
		CIC_PRIVILEGE,

		/// <summary>
		/// <para>The call</para>
		/// <para>media type</para>
		/// <para>has changed.</para>
		/// </summary>
		CIC_MEDIATYPE,
	}

	/// <summary>The <b>DISCONNECT_CODE</b> enum is used by the <c>ITBasicCallControl::Disconnect</c> method.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-disconnect_code typedef enum DISCONNECT_CODE { DC_NORMAL = 0,
	// DC_NOANSWER, DC_REJECTED } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.DISCONNECT_CODE")]
	public enum DISCONNECT_CODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The call is being disconnected as part of the normal cycle of the call.</para>
		/// </summary>
		DC_NORMAL,

		/// <summary>
		/// <para>
		/// The call is being disconnected because it has not been answered. (For example, an application may set a certain amount of time
		/// for the user to answer the call. If the user does not answer, the application can call
		/// </para>
		/// <para>Disconnect</para>
		/// <para>with the NOANSWER code.)</para>
		/// </summary>
		DC_NOANSWER,

		/// <summary>The user rejected the offered call.</summary>
		DC_REJECTED,
	}

	/// <summary>
	/// The <b>FINISH_MODE</b> enum is used by applications to indicate the type of call finish required. Operations that the TAPI DLL
	/// performs vary depending on whether a call transfer is being completed or a call is being added to a conference.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-finish_mode typedef enum FINISH_MODE { FM_ASTRANSFER = 0,
	// FM_ASCONFERENCE } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.FINISH_MODE")]
	public enum FINISH_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A call transfer is being finished.</para>
		/// </summary>
		FM_ASTRANSFER,

		/// <summary>A call is being added to a conference call.</summary>
		FM_ASCONFERENCE,
	}

	/// <summary>The <b>FT_STATE_EVENT_CAUSE</b> enum indicates the type of file terminal event.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-ft_state_event_cause typedef enum FT_STATE_EVENT_CAUSE {
	// FTEC_NORMAL = 0, FTEC_END_OF_FILE, FTEC_READ_ERROR, FTEC_WRITE_ERROR } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.FT_STATE_EVENT_CAUSE")]
	public enum FT_STATE_EVENT_CAUSE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>State change in response to a normal API call.</para>
		/// </summary>
		FTEC_NORMAL,

		/// <summary>Storage EOF reached on playback.</summary>
		FTEC_END_OF_FILE,

		/// <summary>Storage read error on playback.</summary>
		FTEC_READ_ERROR,

		/// <summary>Storage write error on the record.</summary>
		FTEC_WRITE_ERROR,
	}

	/// <summary>
	/// The <b>FULLDUPLEX_SUPPORT</b> enum is used by applications interacting with legacy TSPs to indicate whether a specified terminal
	/// supports full duplex operations. This enum is returned by the <c>ITLegacyWaveSupport::IsFullDuplex</c> method.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-fullduplex_support typedef enum FULLDUPLEX_SUPPORT {
	// FDS_SUPPORTED = 0, FDS_NOTSUPPORTED, FDS_UNKNOWN } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.FULLDUPLEX_SUPPORT")]
	public enum FULLDUPLEX_SUPPORT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Full duplex supported.</para>
		/// </summary>
		FDS_SUPPORTED,

		/// <summary>Full duplex not supported.</summary>
		FDS_NOTSUPPORTED,

		/// <summary>The TSP cannot determine whether the device is full duplex.</summary>
		FDS_UNKNOWN,
	}

	[Flags]
	public enum LINEADDRESSTYPE
	{
		/// <summary>Phone number address type.</summary>
		LINEADDRESSTYPE_PHONENUMBER = 1,
		/// <summary>SDP address type.</summary>
		LINEADDRESSTYPE_SDP = 2,
		/// <summary>Email name address type.</summary>
		LINEADDRESSTYPE_EMAILNAME = 4,
		/// <summary>Domain name address type.</summary>
		LINEADDRESSTYPE_DOMAINNAME = 8,
		/// <summary>IP address type.</summary>
		LINEADDRESSTYPE_IPADDRESS = 16,
	}

	[Flags]
	public enum LINEDIGITMODE
	{
		/// <summary>Pulse/rotary dialing.</summary>
		LINEDIGITMODE_PULSE = 1,
		/// <summary>DTMF dialing.</summary>
		LINEDIGITMODE_DTMF = 2,
		/// <summary>DTMF end.</summary>
		LINEDIGITMODE_DTMFEND = 4,
	}

	/// <summary>The <b>PHONE_BUTTON_FUNCTION</b> enum provides detailed information on a button's function.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phone_button_function typedef enum PHONE_BUTTON_FUNCTION {
	// PBF_UNKNOWN = 0, PBF_CONFERENCE, PBF_TRANSFER, PBF_DROP, PBF_HOLD, PBF_RECALL, PBF_DISCONNECT, PBF_CONNECT, PBF_MSGWAITON,
	// PBF_MSGWAITOFF, PBF_SELECTRING, PBF_ABBREVDIAL, PBF_FORWARD, PBF_PICKUP, PBF_RINGAGAIN, PBF_PARK, PBF_REJECT, PBF_REDIRECT, PBF_MUTE,
	// PBF_VOLUMEUP, PBF_VOLUMEDOWN, PBF_SPEAKERON, PBF_SPEAKEROFF, PBF_FLASH, PBF_DATAON, PBF_DATAOFF, PBF_DONOTDISTURB, PBF_INTERCOM,
	// PBF_BRIDGEDAPP, PBF_BUSY, PBF_CALLAPP, PBF_DATETIME, PBF_DIRECTORY, PBF_COVER, PBF_CALLID, PBF_LASTNUM, PBF_NIGHTSRV, PBF_SENDCALLS,
	// PBF_MSGINDICATOR, PBF_REPDIAL, PBF_SETREPDIAL, PBF_SYSTEMSPEED, PBF_STATIONSPEED, PBF_CAMPON, PBF_SAVEREPEAT, PBF_QUEUECALL, PBF_NONE,
	// PBF_SEND } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONE_BUTTON_FUNCTION")]
	public enum PHONE_BUTTON_FUNCTION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A "dummy" function assignment that indicates that the exact function of the button is unknown or has not been assigned.</para>
		/// </summary>
		PBF_UNKNOWN,

		/// <summary>Initiates a conference call or adds a call to a conference call.</summary>
		PBF_CONFERENCE,

		/// <summary>Initiates a call transfer or completes the transfer of a call.</summary>
		PBF_TRANSFER,

		/// <summary>Drops the active call.</summary>
		PBF_DROP,

		/// <summary>Places the active call on hold.</summary>
		PBF_HOLD,

		/// <summary>Takes a call off hold.</summary>
		PBF_RECALL,

		/// <summary>Disconnects a call, such as after initiating a transfer.</summary>
		PBF_DISCONNECT,

		/// <summary>Reconnects a call that is on consultation hold.</summary>
		PBF_CONNECT,

		/// <summary>Turns on a message waiting lamp.</summary>
		PBF_MSGWAITON,

		/// <summary>Turns off a message waiting lamp.</summary>
		PBF_MSGWAITOFF,

		/// <summary>Allows the user to select the ring pattern of the phone.</summary>
		PBF_SELECTRING,

		/// <summary>Indicates that the number to be dialed will be a short, abbreviated number consisting of one digit or a few digits.</summary>
		PBF_ABBREVDIAL,

		/// <summary>Initiates or changes call forwarding to this phone.</summary>
		PBF_FORWARD,

		/// <summary>Picks up a call ringing on another phone.</summary>
		PBF_PICKUP,

		/// <summary>Initiates a request to be notified if a call cannot be completed normally because of a busy signal or no answer.</summary>
		PBF_RINGAGAIN,

		/// <summary>Parks the active call on another phone, placing it on hold there.</summary>
		PBF_PARK,

		/// <summary>Rejects an incoming call before the call has been answered.</summary>
		PBF_REJECT,

		/// <summary>Redirects an incoming call to another extension before the call has been answered.</summary>
		PBF_REDIRECT,

		/// <summary>Mutes the phone's microphone device.</summary>
		PBF_MUTE,

		/// <summary>Increases the volume of audio through the phone's handset speaker or speakerphone.</summary>
		PBF_VOLUMEUP,

		/// <summary>Decreases the volume of audio through the phone's handset speaker or speakerphone.</summary>
		PBF_VOLUMEDOWN,

		/// <summary>Turns the phone's external speaker on.</summary>
		PBF_SPEAKERON,

		/// <summary>Turns the phone's external speaker off.</summary>
		PBF_SPEAKEROFF,

		/// <summary>
		/// Generates the equivalent of an onhook/offhook sequence. A flash typically indicates that any digits typed next are to be
		/// understood as commands to the switch. On many switches, places an active call on consultation hold.
		/// </summary>
		PBF_FLASH,

		/// <summary>Indicates that the next call is a data call.</summary>
		PBF_DATAON,

		/// <summary>Indicates that the next call is not a data call.</summary>
		PBF_DATAOFF,

		/// <summary>
		/// Places the phone in "do not disturb" mode; incoming calls receive a busy signal or are forwarded to an operator or voicemail system.
		/// </summary>
		PBF_DONOTDISTURB,

		/// <summary>Connects to the intercom to broadcast a page.</summary>
		PBF_INTERCOM,

		/// <summary>Selects a particular appearance of a bridged address.</summary>
		PBF_BRIDGEDAPP,

		/// <summary>Makes the phone appear "busy" to incoming calls.</summary>
		PBF_BUSY,

		/// <summary>Selects a particular call appearance.</summary>
		PBF_CALLAPP,

		/// <summary>Causes the phone to display the current date and time; this information would be sent by the switch.</summary>
		PBF_DATETIME,

		/// <summary>Calls up directory service from the switch.</summary>
		PBF_DIRECTORY,

		/// <summary>Forwards all calls destined for this phone to another phone used for coverage.</summary>
		PBF_COVER,

		/// <summary>Requests display of the caller ID on the phone's display.</summary>
		PBF_CALLID,

		/// <summary>Redials the last number dialed.</summary>
		PBF_LASTNUM,

		/// <summary>Places the phone in the mode it is configured for during night hours.</summary>
		PBF_NIGHTSRV,

		/// <summary>
		/// <para>Sends all calls to another phone used for coverage; same as the</para>
		/// <para>PHONEBUTTONFUNCTION_COVER constant</para>
		/// <para>.</para>
		/// </summary>
		PBF_SENDCALLS,

		/// <summary>Controls the message indicator lamp.</summary>
		PBF_MSGINDICATOR,

		/// <summary>Repertory dialing—the number to be dialed is provided as a shorthand following the pressing of this button.</summary>
		PBF_REPDIAL,

		/// <summary>Programs the shorthand-to-phone number mappings accessible by means of repertory dialing (the "REPDIAL" button).</summary>
		PBF_SETREPDIAL,

		/// <summary>
		/// The number to be dialed is provided as a shorthand following the pressing of this button. The mappings for system speed dialing
		/// are configured inside the switch.
		/// </summary>
		PBF_SYSTEMSPEED,

		/// <summary>
		/// The number to be dialed is provided as a shorthand following pressing of this button. The mappings for station speed dialing are
		/// specific to this station (phone).
		/// </summary>
		PBF_STATIONSPEED,

		/// <summary>
		/// Camps on an extension that returns a busy indication. When the remote station returns to idle, the phone will be rung with a
		/// distinctive pattern. Picking up the local phone reinitiates the call.
		/// </summary>
		PBF_CAMPON,

		/// <summary>
		/// When pressed while a call or call attempt is active, it will remember that call's number or command. When pressed while no call
		/// is active (such as during dial tone), it repeats the most recently saved command.
		/// </summary>
		PBF_SAVEREPEAT,

		/// <summary>
		/// Queues a call to an outside number after it encounters a trunk-busy indication. When a trunk becomes available later, the phone
		/// will be rung with a distinctive pattern. Picking up the local phone reinitiates the call.
		/// </summary>
		PBF_QUEUECALL,

		/// <summary>A "dummy" function assignment that indicates that the button does not have a function.</summary>
		PBF_NONE,

		/// <summary>Sends a request for a communications session.</summary>
		PBF_SEND,
	}

	/// <summary>The <b>PHONE_BUTTON_MODE</b> enum describes the mode of a phone button.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phone_button_mode typedef enum PHONE_BUTTON_MODE { PBM_DUMMY =
	// 0, PBM_CALL, PBM_FEATURE, PBM_KEYPAD, PBM_LOCAL, PBM_DISPLAY } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONE_BUTTON_MODE")]
	public enum PHONE_BUTTON_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Dummy button.</para>
		/// </summary>
		PBM_DUMMY,

		/// <summary>Call button.</summary>
		PBM_CALL,

		/// <summary>Feature button.</summary>
		PBM_FEATURE,

		/// <summary>Keypad button.</summary>
		PBM_KEYPAD,

		/// <summary>Local function button, such as mute or volume control.</summary>
		PBM_LOCAL,

		/// <summary>Display button.</summary>
		PBM_DISPLAY,
	}

	/// <summary>The <b>PHONE_BUTTON_STATE</b> enum describes the state of a phone button.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phone_button_state typedef enum PHONE_BUTTON_STATE { PBS_UP =
	// 0x1, PBS_DOWN = 0x2, PBS_UNKNOWN = 0x4, PBS_UNAVAIL = 0x8 } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONE_BUTTON_STATE")]
	[Flags]
	public enum PHONE_BUTTON_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>State of the button is up.</para>
		/// </summary>
		PBS_UP = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>State of the button is down.</para>
		/// </summary>
		PBS_DOWN = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>State of the button is not known.</para>
		/// </summary>
		PBS_UNKNOWN = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>State of the button is not available.</para>
		/// </summary>
		PBS_UNAVAIL = 0x8,
	}

	/// <summary>The <b>PHONE_EVENT</b> enum indicates a type of phone event.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phone_event typedef enum PHONE_EVENT { PE_DISPLAY = 0,
	// PE_LAMPMODE, PE_RINGMODE, PE_RINGVOLUME, PE_HOOKSWITCH, PE_CAPSCHANGE, PE_BUTTON, PE_CLOSE, PE_NUMBERGATHERED, PE_DIALING, PE_ANSWER,
	// PE_DISCONNECT, PE_LASTITEM } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONE_EVENT")]
	public enum PHONE_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Phone display has changed.</para>
		/// </summary>
		PE_DISPLAY,

		/// <summary>Lamp mode has changed.</summary>
		PE_LAMPMODE,

		/// <summary>Ringing mode has changed.</summary>
		PE_RINGMODE,

		/// <summary>Ringing volume has changed.</summary>
		PE_RINGVOLUME,

		/// <summary>Hookswitch status has changed.</summary>
		PE_HOOKSWITCH,

		/// <summary>Phone capabilities have changed.</summary>
		PE_CAPSCHANGE,

		/// <summary>The phone button has changed.</summary>
		PE_BUTTON,

		/// <summary>The phone has been closed.</summary>
		PE_CLOSE,

		/// <summary>A dialed number has been gathered by the phone.</summary>
		PE_NUMBERGATHERED,

		/// <summary>The phone is dialing.</summary>
		PE_DIALING,

		/// <summary>The phone has been answered.</summary>
		PE_ANSWER,

		/// <summary>The phone has been disconnected.</summary>
		PE_DISCONNECT,
	}

	/// <summary>The <b>PHONE_HOOK_SWITCH_DEVICE</b> enum is used to indicate the types of switch hooks on a phone device.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phone_hook_switch_device typedef enum PHONE_HOOK_SWITCH_DEVICE
	// { PHSD_HANDSET = 0x1, PHSD_SPEAKERPHONE = 0x2, PHSD_HEADSET = 0x4 } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONE_HOOK_SWITCH_DEVICE")]
	[Flags]
	public enum PHONE_HOOK_SWITCH_DEVICE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The handset's hookswitch.</para>
		/// </summary>
		PHSD_HANDSET = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The speakerphone's hookswitch.</para>
		/// </summary>
		PHSD_SPEAKERPHONE = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The headset's hookswitch.</para>
		/// </summary>
		PHSD_HEADSET = 4,
	}

	/// <summary>The <b>PHONE_HOOK_SWITCH_STATE</b> enum provides indicators of the phone hookswitch status.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phone_hook_switch_state typedef enum PHONE_HOOK_SWITCH_STATE {
	// PHSS_ONHOOK = 0x1, PHSS_OFFHOOK_MIC_ONLY = 0x2, PHSS_OFFHOOK_SPEAKER_ONLY = 0x4, PHSS_OFFHOOK = 0x8 } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONE_HOOK_SWITCH_STATE")]
	[Flags]
	public enum PHONE_HOOK_SWITCH_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Indicates that the phone is onhook.</para>
		/// </summary>
		PHSS_ONHOOK = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Indicates that only the phone's microphone is offhook.</para>
		/// </summary>
		PHSS_OFFHOOK_MIC_ONLY = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Indicates that only the phone's speaker is offhook.</para>
		/// </summary>
		PHSS_OFFHOOK_SPEAKER_ONLY = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Indicates that the phone is offhook.</para>
		/// </summary>
		PHSS_OFFHOOK = 0x8,
	}

	/// <summary>The <b>PHONE_LAMP_MODE</b> enum provides indicators of a phone lamp's status.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phone_lamp_mode typedef enum PHONE_LAMP_MODE { LM_DUMMY = 0x1,
	// LM_OFF = 0x2, LM_STEADY = 0x4, LM_WINK = 0x8, LM_FLASH = 0x10, LM_FLUTTER = 0x20, LM_BROKENFLUTTER = 0x40, LM_UNKNOWN = 0x80 } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONE_LAMP_MODE")]
	[Flags]
	public enum PHONE_LAMP_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The lamp identifier has no corresponding lamp.</para>
		/// </summary>
		LM_DUMMY = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The lamp is off.</para>
		/// </summary>
		LM_OFF = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The lamp is on steadily.</para>
		/// </summary>
		LM_STEADY = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The lamp is winking, which means on and off at a normal rate.</para>
		/// </summary>
		LM_WINK = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The lamp is flashing, which means a slow on and off.</para>
		/// </summary>
		LM_FLASH = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>The lamp is fluttering, which means a fast on and off.</para>
		/// </summary>
		LM_FLUTTER = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>The lamp is flashing, which means superposition of a flash and flutter.</para>
		/// </summary>
		LM_BROKENFLUTTER = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>The lamp mode is not known.</para>
		/// </summary>
		LM_UNKNOWN = 0x80,
	}

	/// <summary>The <b>PHONE_PRIVILEGE</b> enum indicates the application's privilege status with respect to the current phone device.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phone_privilege typedef enum PHONE_PRIVILEGE { PP_OWNER = 0,
	// PP_MONITOR } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONE_PRIVILEGE")]
	public enum PHONE_PRIVILEGE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The application has owner privileges for the current phone session.</para>
		/// </summary>
		PP_OWNER,

		/// <summary>The application has monitor privileges for the current phone session.</summary>
		PP_MONITOR,
	}

	/// <summary>The <b>PHONE_TONE</b> enum identifies a phone tone.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phone_tone typedef enum PHONE_TONE { PT_KEYPADZERO = 0,
	// PT_KEYPADONE, PT_KEYPADTWO, PT_KEYPADTHREE, PT_KEYPADFOUR, PT_KEYPADFIVE, PT_KEYPADSIX, PT_KEYPADSEVEN, PT_KEYPADEIGHT, PT_KEYPADNINE,
	// PT_KEYPADSTAR, PT_KEYPADPOUND, PT_KEYPADA, PT_KEYPADB, PT_KEYPADC, PT_KEYPADD, PT_NORMALDIALTONE, PT_EXTERNALDIALTONE, PT_BUSY,
	// PT_RINGBACK, PT_ERRORTONE, PT_SILENCE } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONE_TONE")]
	public enum PHONE_TONE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Zero.</para>
		/// </summary>
		PT_KEYPADZERO,

		/// <summary>One.</summary>
		PT_KEYPADONE,

		/// <summary>Two.</summary>
		PT_KEYPADTWO,

		/// <summary>Three.</summary>
		PT_KEYPADTHREE,

		/// <summary>Four.</summary>
		PT_KEYPADFOUR,

		/// <summary>Five.</summary>
		PT_KEYPADFIVE,

		/// <summary>Six.</summary>
		PT_KEYPADSIX,

		/// <summary>Seven.</summary>
		PT_KEYPADSEVEN,

		/// <summary>Eight.</summary>
		PT_KEYPADEIGHT,

		/// <summary>Nine.</summary>
		PT_KEYPADNINE,

		/// <summary>Star key.</summary>
		PT_KEYPADSTAR,

		/// <summary>Pound sign key.</summary>
		PT_KEYPADPOUND,

		/// <summary>Supplemental A.</summary>
		PT_KEYPADA,

		/// <summary>Supplemental B.</summary>
		PT_KEYPADB,

		/// <summary>Supplemental C.</summary>
		PT_KEYPADC,

		/// <summary>Supplemental D.</summary>
		PT_KEYPADD,

		/// <summary>Normal dial tone.</summary>
		PT_NORMALDIALTONE,

		/// <summary>External dial tone.</summary>
		PT_EXTERNALDIALTONE,

		/// <summary>Busy signal tone.</summary>
		PT_BUSY,

		/// <summary>Ringback tone.</summary>
		PT_RINGBACK,

		/// <summary>Error tone.</summary>
		PT_ERRORTONE,

		/// <summary>No tone.</summary>
		PT_SILENCE,
	}

	/// <summary>The <b>PHONECAPS_BUFFER</b> enum is used by methods that set or get phone capabilities described by a buffer.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phonecaps_buffer typedef enum PHONECAPS_BUFFER {
	// PCB_DEVSPECIFICBUFFER = 0 } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONECAPS_BUFFER")]
	public enum PHONECAPS_BUFFER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Device-specific phone capabilities.</para>
		/// </summary>
		PCB_DEVSPECIFICBUFFER,
	}

	/// <summary>The <b>PHONECAPS_LONG</b> enum is used by methods that set or get phone capabilities described by a long value.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phonecaps_long typedef enum PHONECAPS_LONG { PCL_HOOKSWITCHES =
	// 0, PCL_HANDSETHOOKSWITCHMODES, PCL_HEADSETHOOKSWITCHMODES, PCL_SPEAKERPHONEHOOKSWITCHMODES, PCL_DISPLAYNUMROWS, PCL_DISPLAYNUMCOLUMNS,
	// PCL_NUMRINGMODES, PCL_NUMBUTTONLAMPS, PCL_GENERICPHONE } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONECAPS_LONG")]
	public enum PHONECAPS_LONG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies the hookswitch devices available using one or more members of the</para>
		/// <para>PHONE_HOOK_SWITCH_DEVICE</para>
		/// <para>enum.</para>
		/// </summary>
		PCL_HOOKSWITCHES,

		/// <summary>Specifies the handset hook switch modes.</summary>
		PCL_HANDSETHOOKSWITCHMODES,

		/// <summary>Specifies the headset hook switch modes.</summary>
		PCL_HEADSETHOOKSWITCHMODES,

		/// <summary>Specifies the speakerphone hook switch modes.</summary>
		PCL_SPEAKERPHONEHOOKSWITCHMODES,

		/// <summary>Specifies the number of rows in a phone display device.</summary>
		PCL_DISPLAYNUMROWS,

		/// <summary>Specifies the number of columns in a phone display device.</summary>
		PCL_DISPLAYNUMCOLUMNS,

		/// <summary>
		/// <para>Specifies the number of ring modes.</para>
		/// <para>
		/// If a USB phone returns zero for this value, the phone typically does not have a ringer device. The ringing sound plays on the
		/// default audio device for the system; for example, on sound card speakers.
		/// </para>
		/// </summary>
		PCL_NUMRINGMODES,

		/// <summary>Specifies the number of button lamps.</summary>
		PCL_NUMBUTTONLAMPS,

		/// <summary>
		/// <para>Specifies whether the phone is generic: a value of one indicates it is, a value of zero indicates it is not.</para>
		/// <para>
		/// A generic phone is a phone device that declares itself as available on all addresses that support audio terminals. For example, a
		/// USB phone is generic, because it is not tied to a specific TAPI address.
		/// </para>
		/// </summary>
		PCL_GENERICPHONE,
	}

	/// <summary>The <b>PHONECAPS_STRING</b> enum is used by methods that set or get phone capabilities described by a string.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-phonecaps_string typedef enum PHONECAPS_STRING { PCS_PHONENAME
	// = 0, PCS_PHONEINFO, PCS_PROVIDERINFO } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.PHONECAPS_STRING")]
	public enum PHONECAPS_STRING
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Name of the phone.</para>
		/// </summary>
		PCS_PHONENAME,

		/// <summary>Phone information string.</summary>
		PCS_PHONEINFO,

		/// <summary>Phone provider string.</summary>
		PCS_PROVIDERINFO,
	}

	/// <summary>
	/// The <b>QOS_EVENT</b> enum describes quality of service (QOS) events. The <c>ITQOSEvent::get_Event</c> method returns a member of this
	/// enum to indicate the type of QOS event that occurred.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-qos_event?redirectedfrom=MSDN typedef enum QOS_EVENT { QE_NOQOS
	// = 1, QE_ADMISSIONFAILURE = 2, QE_POLICYFAILURE = 3, QE_GENERICERROR = 4, QE_LASTITEM } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.QOS_EVENT")]
	public enum QOS_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>QOS is not available.</para>
		/// </summary>
		QE_NOQOS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The QOS request could not be met.</para>
		/// </summary>
		QE_ADMISSIONFAILURE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The type of QOS requested is not supported.</para>
		/// </summary>
		QE_POLICYFAILURE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Unspecified QOS error.</para>
		/// </summary>
		QE_GENERICERROR,
	}

	/// <summary>
	/// The <b>QOS_SERVICE_LEVEL</b> enum is used by the <c>ITBasicCallControl::SetQOS</c> method to indicate quality of service requirements
	/// for a call.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-qos_service_level typedef enum QOS_SERVICE_LEVEL { QSL_NEEDED =
	// 1, QSL_IF_AVAILABLE = 2, QSL_BEST_EFFORT = 3 } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.QOS_SERVICE_LEVEL")]
	public enum QOS_SERVICE_LEVEL
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Quality of service level required.</para>
		/// </summary>
		QSL_NEEDED = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Quality of service level desired if available.</para>
		/// </summary>
		QSL_IF_AVAILABLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Quality of service level desired is "best effort."</para>
		/// </summary>
		QSL_BEST_EFFORT,
	}

	/// <summary>
	/// The <b>TAPI_EVENT</b> enumeration is used to notify an application that a change has occurred in the TAPI object. The
	/// <c>ITTAPIEventNotification::Event</c> method implementation uses members of this enumeration to indicate the type of object
	/// associated with the <b>IDispatch</b> pointer passed by TAPI.
	/// </summary>
	/// <remarks>
	/// Call the <c>ITTAPI::put_EventFilter</c> method and set the event filter mask to enable receiving events. If
	/// <b>ITTAPI::put_EventFilter</b> is not called, the application cannot receive events.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-tapi_event typedef enum TAPI_EVENT { TE_TAPIOBJECT = 0x1,
	// TE_ADDRESS = 0x2, TE_CALLNOTIFICATION = 0x4, TE_CALLSTATE = 0x8, TE_CALLMEDIA = 0x10, TE_CALLHUB = 0x20, TE_CALLINFOCHANGE = 0x40,
	// TE_PRIVATE = 0x80, TE_REQUEST = 0x100, TE_AGENT = 0x200, TE_AGENTSESSION = 0x400, TE_QOSEVENT = 0x800, TE_AGENTHANDLER = 0x1000,
	// TE_ACDGROUP = 0x2000, TE_QUEUE = 0x4000, TE_DIGITEVENT = 0x8000, TE_GENERATEEVENT = 0x10000, TE_ASRTERMINAL = 0x20000, TE_TTSTERMINAL
	// = 0x40000, TE_FILETERMINAL = 0x80000, TE_TONETERMINAL = 0x100000, TE_PHONEEVENT = 0x200000, TE_TONEEVENT = 0x400000, TE_GATHERDIGITS =
	// 0x800000, TE_ADDRESSDEVSPECIFIC = 0x1000000, TE_PHONEDEVSPECIFIC = 0x2000000 } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.TAPI_EVENT")]
	[Flags]
	public enum TAPI_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Change is in TAPI object itself. For more information, see</para>
		/// <para>ITTAPIObjectEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_TAPIOBJECT = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>An Address object has changed. For more information, see</para>
		/// <para>ITAddressEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_ADDRESS = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>
		/// A new communications session has appeared on the address and the TAPI DLL has created a new call object. This could be a result
		/// from an incoming session, a session handed off by another application, or a session being parked on the address. For more
		/// information, see
		/// </para>
		/// <para>ITCallNotificationEvent</para>
		/// <para>and</para>
		/// <para>ITTAPI::RegisterCallNotifications</para>
		/// <para>.</para>
		/// </summary>
		TE_CALLNOTIFICATION = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The Call state has changed. For more information, see</para>
		/// <para>ITCallStateEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_CALLSTATE = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The media associated with a call has changed. For more information, see</para>
		/// <para>ITCallMediaEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_CALLMEDIA = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>A CallHub object has changed. For more information, see</para>
		/// <para>ITCallHubEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_CALLHUB = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>The call information has changed.</para>
		/// <para>For more information, see</para>
		/// <para>ITCallInfoChangeEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_CALLINFOCHANGE = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>
		/// A provider-specific private object has changed. The precise type of object referenced is implementation dependent. For more
		/// information, see
		/// </para>
		/// <para>Provider-Specific Interfaces</para>
		/// <para>.</para>
		/// </summary>
		TE_PRIVATE = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>A Request object has changed. For more information, see</para>
		/// <para>ITRequestEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_REQUEST = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// <para>An Agent object has changed. For more information, see</para>
		/// <para>ITAgentEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_AGENT = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400</para>
		/// <para>An AgentSession object has changed. For more information, see</para>
		/// <para>ITAgentSessionEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_AGENTSESSION = 0x400,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800</para>
		/// <para>A QOS event has occurred. For more information, see</para>
		/// <para>ITQOSEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_QOSEVENT = 0x800,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000</para>
		/// <para>An AgentHandler object has changed. For more information, see</para>
		/// <para>ITAgentHandlerEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_AGENTHANDLER = 0x1000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2000</para>
		/// <para>An ACDGroup object has changed. For more information, see</para>
		/// <para>ITACDGroupEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_ACDGROUP = 0x2000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4000</para>
		/// <para>A Queue object has changed. For more information, see</para>
		/// <para>ITQueueEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_QUEUE = 0x4000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8000</para>
		/// <para>A digit event has occurred. For more information, see</para>
		/// <para>ITDigitDetectionEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_DIGITEVENT = 0x8000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10000</para>
		/// <para>A digit generation event has occurred. For more information, see</para>
		/// <para>ITDigitGenerationEvent</para>
		/// <para>.</para>
		/// </summary>
		TE_GENERATEEVENT = 0x10000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000</para>
		/// <para>An Automatic Speech Recognition terminal event has occurred. Valid only for computers running on Windows XP and later.</para>
		/// </summary>
		TE_ASRTERMINAL = 0x20000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000</para>
		/// <para>An event has occurred on a TTS terminal. For more information, see</para>
		/// <para>ITTTSTerminalEvent</para>
		/// <para>. Valid only for computers running on Windows XP and later.</para>
		/// </summary>
		TE_TTSTERMINAL = 0x40000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000</para>
		/// <para>An event has occurred on a file terminal. For more information, see</para>
		/// <para>ITFileTerminalEvent</para>
		/// <para>. Valid only for computers running on Windows XP and later.</para>
		/// </summary>
		TE_FILETERMINAL = 0x80000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100000</para>
		/// <para>An event has occurred on a tone terminal. For more information, see</para>
		/// <para>ITToneTerminalEvent</para>
		/// <para>. Valid only for computers running on Windows XP and later.</para>
		/// </summary>
		TE_TONETERMINAL = 0x100000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200000</para>
		/// <para>A Phone object has changed. For more information, see</para>
		/// <para>ITPhoneEvent</para>
		/// <para>. Valid only for computers running on Windows XP and later.</para>
		/// </summary>
		TE_PHONEEVENT = 0x200000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400000</para>
		/// <para>A tone event has been fired. Detection of in-band tones will be enabled or disabled. For more information, see</para>
		/// <para>ITToneDetectionEvent</para>
		/// <para>. Valid only for computers running on Windows XP and later.</para>
		/// </summary>
		TE_TONEEVENT = 0x400000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800000</para>
		/// <para>A gather digits event has been fired. Digits will be gathered on the current call. For more information, see</para>
		/// <para>ITDigitsGatheredEvent</para>
		/// <para>. Valid only for computers running on Windows XP and later.</para>
		/// </summary>
		TE_GATHERDIGITS = 0x800000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000000</para>
		/// <para>An address device-specific event has occurred. For more information, see</para>
		/// <para>ITAddressDeviceSpecificEvent</para>
		/// <para>. Valid only for computers running on Windows XP and later.</para>
		/// </summary>
		TE_ADDRESSDEVSPECIFIC = 0x1000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2000000</para>
		/// <para>A phone device-specific event has occurred. For more information, see</para>
		/// <para>ITPhoneDeviceSpecificEvent</para>
		/// <para>. Valid only for computers running on Windows XP and later.</para>
		/// </summary>
		TE_PHONEDEVSPECIFIC = 0x2000000,
	}

	/// <summary>
	/// The <b>TAPI_GATHERTERM</b> enum is used to describe the reasons why the TAPI Server terminated the gathering of digits on the call.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-tapi_gatherterm typedef enum TAPI_GATHERTERM { TGT_BUFFERFULL =
	// 0x1, TGT_TERMDIGIT = 0x2, TGT_FIRSTTIMEOUT = 0x4, TGT_INTERTIMEOUT = 0x8, TGT_CANCEL = 0x10 } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.TAPI_GATHERTERM")]
	[Flags]
	public enum TAPI_GATHERTERM
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The requested number of digits has been gathered. The buffer is full.</para>
		/// </summary>
		TGT_BUFFERFULL = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>One of the termination digits matched a received digit. The matched termination digit is the last digit in the buffer.</para>
		/// </summary>
		TGT_TERMDIGIT = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The first digit timeout expired. The buffer contains no digits.</para>
		/// </summary>
		TGT_FIRSTTIMEOUT = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The interdigit timeout expired. The buffer contains at least one digit.</para>
		/// </summary>
		TGT_INTERTIMEOUT = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The request was canceled by this application, by another application, or because the call terminated.</para>
		/// </summary>
		TGT_CANCEL = 0x10,
	}

	/// <summary>The <b>TAPI_TONEMODE</b> enum is used to describe the different selections that are used when generating line tones.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-tapi_tonemode typedef enum TAPI_TONEMODE { TTM_RINGBACK = 0x2,
	// TTM_BUSY = 0x4, TTM_BEEP = 0x8, TTM_BILLING = 0x10 } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.TAPI_TONEMODE")]
	[Flags]
	public enum TAPI_TONEMODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The tone is a ringback tone. Exact definition is service-provider defined.</para>
		/// </summary>
		TTM_RINGBACK = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The tone is a busy tone. Exact definition is service-provider defined.</para>
		/// </summary>
		TTM_BUSY = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The tone is a beep, such as that used to announce the beginning of a recording. Exact definition is service-provider defined.</para>
		/// </summary>
		TTM_BEEP = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The tone is a billing information tone, such as a credit card prompt tone. Exact definition is service-provider defined.</para>
		/// </summary>
		TTM_BILLING = 0x10,
	}

	/// <summary></summary>
	[Flags]
	public enum TAPIMEDIATYPE : uint
	{
		TAPIMEDIATYPE_AUDIO	=	0x8,
		
		TAPIMEDIATYPE_VIDEO	=	0x8000,
		
		TAPIMEDIATYPE_DATAMODEM	=	0x10,
		
		TAPIMEDIATYPE_G3FAX	=	0x20,
		
		TAPIMEDIATYPE_MULTITRACK	=	0x10000,
	}
	/// <summary>
	/// The <b>TAPIOBJECT_EVENT</b> enum describes TAPI object events. The <c>ITTAPIObjectEvent::get_Event</c> method returns a member of
	/// this enum to indicate the type of TAPI object event that occurred.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-tapiobject_event typedef enum TAPIOBJECT_EVENT {
	// TE_ADDRESSCREATE = 0, TE_ADDRESSREMOVE, TE_REINIT, TE_TRANSLATECHANGE, TE_ADDRESSCLOSE, TE_PHONECREATE, TE_PHONEREMOVE } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.TAPIOBJECT_EVENT")]
	public enum TAPIOBJECT_EVENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A new address has been created.</para>
		/// </summary>
		TE_ADDRESSCREATE,

		/// <summary>An address has been moved.</summary>
		TE_ADDRESSREMOVE,

		/// <summary>The TAPI object has been reinitialized</summary>
		TE_REINIT,

		/// <summary>A translation change has occurred.</summary>
		TE_TRANSLATECHANGE,

		/// <summary>Address has been closed.</summary>
		TE_ADDRESSCLOSE,

		/// <summary/>
		TE_PHONECREATE,

		/// <summary/>
		TE_PHONEREMOVE,
	}

	/// <summary>
	/// The <b>TERMINAL_DIRECTION</b> enumeration is used to describe the direction of the media stream with respect to the local computer or
	/// the directional capabilities of a terminal.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-terminal_direction typedef enum TERMINAL_DIRECTION { TD_CAPTURE
	// = 0, TD_RENDER, TD_BIDIRECTIONAL, TD_MULTITRACK_MIXED, TD_NONE } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.TERMINAL_DIRECTION")]
	public enum TERMINAL_DIRECTION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// The stream is captured on the local computer, and the data is sent out to the remote end of the connection. When applied to a
		/// terminal, this means it can originate a stream.
		/// </para>
		/// </summary>
		TD_CAPTURE,

		/// <summary>
		/// The stream is arriving from the remote end of the connection. When applied to a terminal, this means it can render a stream.
		/// </summary>
		TD_RENDER,

		/// <summary>The terminal can handle either capture or render streams.</summary>
		TD_BIDIRECTIONAL,

		/// <summary>
		/// <para>Different tracks on the multi-track terminal may travel in different directions. For example, one track may specify</para>
		/// <para>TD_RENDER</para>
		/// <para>and another may specify</para>
		/// <para>TD_CAPTURE</para>
		/// <para>.</para>
		/// </summary>
		TD_MULTITRACK_MIXED,

		/// <summary>The terminal direction is unknown or not initialized.</summary>
		TD_NONE,
	}

	/// <summary>Die <b>TERMINAL_MEDIA_STATE</b> Enumeration gibt den Zustand eines Dateiterminals an.</summary>
	// https://learn.microsoft.com/de-de/windows/win32/api/tapi3if/ne-tapi3if-terminal_media_state typedef enum TERMINAL_MEDIA_STATE {
	// TMS_IDLE = 0, TMS_ACTIVE, TMS_PAUSED, TMS_LASTITEM = TMS_PAUSED } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.TERMINAL_MEDIA_STATE")]
	public enum TERMINAL_MEDIA_STATE
	{
		/// <summary>
		/// <para>Wert:</para>
		/// <para>0</para>
		/// <para>Das Dateiterminal befindet sich im Leerlauf.</para>
		/// </summary>
		TMS_IDLE,

		/// <summary>Das Dateiterminal ist aktiv.</summary>
		TMS_ACTIVE,

		/// <summary>Das Dateiterminal wird angehalten.</summary>
		TMS_PAUSED,
	}

	/// <summary>
	/// The <b>TERMINAL_STATE</b> enum describes the current state of a terminal device. This enum is returned by the
	/// <c>ITTerminal::get_State</c> method.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-terminal_state typedef enum TERMINAL_STATE { TS_INUSE = 0,
	// TS_NOTINUSE } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.TERMINAL_STATE")]
	public enum TERMINAL_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The terminal is currently in use.</para>
		/// </summary>
		TS_INUSE,

		/// <summary>The terminal is not currently in use.</summary>
		TS_NOTINUSE,
	}

	/// <summary>
	/// The <b>TERMINAL_TYPE</b> enum describes the type of the terminal. This enum is returned by the <c>ITTerminal::get_TerminalType</c> method.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ne-tapi3if-terminal_type typedef enum TERMINAL_TYPE { TT_STATIC = 0,
	// TT_DYNAMIC } ;
	[PInvokeData("tapi3if.h", MSDNShortId = "NE:tapi3if.TERMINAL_TYPE")]
	public enum TERMINAL_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A static terminal is a terminal that cannot be created and usually refers to hardware device. TAPI enumerates these terminals.</para>
		/// </summary>
		TT_STATIC,

		/// <summary>
		/// <para>A terminal type that can be created. The application must call</para>
		/// <para>ITTerminalSupport::CreateTerminal</para>
		/// <para>to use this type of terminal.</para>
		/// </summary>
		TT_DYNAMIC,
	}

	/// <summary>The <b>TAPI_CUSTOMTONE</b> structure contains the parameters that define a custom tone.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ns-tapi3if-tapi_customtone typedef struct TAPI_CUSTOMTONE { DWORD
	// dwFrequency; DWORD dwCadenceOn; DWORD dwCadenceOff; DWORD dwVolume; } TAPI_CUSTOMTONE, *LPTAPI_CUSTOMTONE;
	[PInvokeData("tapi3if.h", MSDNShortId = "NS:tapi3if.TAPI_CUSTOMTONE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TAPI_CUSTOMTONE
	{
		/// <summary>The frequency, in hertz, of the tone.</summary>
		public uint dwFrequency;

		/// <summary>The "on" duration, in milliseconds, of the cadence of a custom tone.</summary>
		public uint dwCadenceOn;

		/// <summary>The "off" duration, in milliseconds, of the cadence of a custom tone.</summary>
		public uint dwCadenceOff;

		/// <summary>The volume level at which to generate the tone.</summary>
		public uint dwVolume;
	}

	/// <summary>The <b>TAPI_DETECTTONE</b> structure describes a tone to be monitored. This is used as an entry in an array.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/ns-tapi3if-tapi_detecttone typedef struct TAPI_DETECTTONE { DWORD
	// dwAppSpecific; DWORD dwDuration; DWORD dwFrequency1; DWORD dwFrequency2; DWORD dwFrequency3; } TAPI_DETECTTONE, *LPTAPI_DETECTTONE;
	[PInvokeData("tapi3if.h", MSDNShortId = "NS:tapi3if.TAPI_DETECTTONE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TAPI_DETECTTONE
	{
		/// <summary>
		/// Used by the application for tagging the tone. When this tone is detected, the value of the <b>dwAppSpecific</b> member is passed
		/// back to the application.
		/// </summary>
		public uint dwAppSpecific;

		/// <summary>The duration, in milliseconds, during which the tone should be present before a detection is made.</summary>
		public uint dwDuration;

		/// <summary>The frequency, in hertz, of a component of the tone.</summary>
		public uint dwFrequency1;

		/// <summary>The frequency, in hertz, of a component of the tone.</summary>
		public uint dwFrequency2;

		/// <summary>
		/// The frequency, in hertz, of a component of the tone. If fewer than three frequencies are needed in the tone, a value of zero
		/// should be used for the unused frequencies. A tone with all three frequencies set to zero is interpreted as silence and can be
		/// used for silence detection.
		/// </summary>
		public uint dwFrequency3;
	}
}