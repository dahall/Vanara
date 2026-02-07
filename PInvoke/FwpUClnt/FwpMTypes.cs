#pragma warning disable IDE1006 // Naming Styles

using System.Collections.Generic;
using System.Linq;
using Vanara.Extensions.Reflection;

namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>The DL_ADDRESS_TYPE enumerated type specifies the type of datalink layer address.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/netiodef/ne-netiodef-dl_address_type typedef enum { DlUnicast, DlMulticast,
	// DlBroadcast } DL_ADDRESS_TYPE, *PDL_ADDRESS_TYPE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:netiodef.__unnamed_enum_0")]
	public enum DL_ADDRESS_TYPE
	{
		/// <summary>Specifies a unicast datalink layer address.</summary>
		DlUnicast,

		/// <summary>Specifies a multicast datalink layer address.</summary>
		DlMulticast,

		/// <summary>Specifies a broadcast datalink layer address.</summary>
		DlBroadcast,
	}

	/// <summary>Action type</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_ACTION0_")]
	[Flags]
	public enum FWP_ACTION_TYPE : uint
	{
		/// <summary>Block the traffic.</summary>
		FWP_ACTION_BLOCK = 0x00000001 | FWP_ACTION_FLAG_TERMINATING,

		/// <summary>Permit the traffic.</summary>
		FWP_ACTION_PERMIT = 0x00000002 | FWP_ACTION_FLAG_TERMINATING,

		/// <summary>Invoke a callout that always returns block or permit.</summary>
		FWP_ACTION_CALLOUT_TERMINATING = 0x00000003 | FWP_ACTION_FLAG_CALLOUT | FWP_ACTION_FLAG_TERMINATING,

		/// <summary>Invoke a callout that never returns block or permit.</summary>
		FWP_ACTION_CALLOUT_INSPECTION = 0x00000004 | FWP_ACTION_FLAG_CALLOUT | FWP_ACTION_FLAG_NON_TERMINATING,

		/// <summary>Invoke a callout that may return block or permit.</summary>
		FWP_ACTION_CALLOUT_UNKNOWN = 0x00000005 | FWP_ACTION_FLAG_CALLOUT,

		/// <summary/>
		FWP_ACTION_CONTINUE = 0x00000006 | FWP_ACTION_FLAG_NON_TERMINATING,

		/// <summary/>
		FWP_ACTION_NONE = 0x00000007,

		/// <summary/>
		FWP_ACTION_NONE_NO_MATCH = 0x00000008,

		/// <summary/>
		FWP_ACTION_FLAG_TERMINATING = 0x00001000,

		/// <summary/>
		FWP_ACTION_FLAG_NON_TERMINATING = 0x00002000,

		/// <summary/>
		FWP_ACTION_FLAG_CALLOUT = 0x00004000,
	}

	/// <summary>TBD</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_network_connection_policy_setting_type typedef enum
	// FWP_NETWORK_CONNECTION_POLICY_SETTING_TYPE_ { FWP_NETWORK_CONNECTION_POLICY_SOURCE_ADDRESS,
	// FWP_NETWORK_CONNECTION_POLICY_NEXT_HOP_INTERFACE, FWP_NETWORK_CONNECTION_POLICY_NEXT_HOP, FWP_NETWORK_CONNECTION_POLICY_MAX } FWP_NETWORK_CONNECTION_POLICY_SETTING_TYPE;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_NETWORK_CONNECTION_POLICY_SETTING_TYPE_")]
	public enum FWP_NETWORK_CONNECTION_POLICY_SETTING_TYPE
	{
		/// <summary>TBD</summary>
		FWP_NETWORK_CONNECTION_POLICY_SOURCE_ADDRESS = 0,

		/// <summary>TBD</summary>
		FWP_NETWORK_CONNECTION_POLICY_NEXT_HOP_INTERFACE,

		/// <summary>TBD</summary>
		FWP_NETWORK_CONNECTION_POLICY_NEXT_HOP,

		/// <summary>TBD</summary>
		FWP_NETWORK_CONNECTION_POLICY_MAX,
	}

	/// <summary>
	/// The <c>FWPM_APPC_NETWORK_CAPABILITY_TYPE</c> enumeration specifies the type of app container network capability that is associated
	/// with the object or traffic in question.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_appc_network_capability_type typedef enum
	// FWPM_APPC_NETWORK_CAPABILITY_TYPE_ { FWPM_APPC_NETWORK_CAPABILITY_INTERNET_CLIENT = 0,
	// FWPM_APPC_NETWORK_CAPABILITY_INTERNET_CLIENT_SERVER, FWPM_APPC_NETWORK_CAPABILITY_INTERNET_PRIVATE_NETWORK } FWPM_APPC_NETWORK_CAPABILITY_TYPE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_APPC_NETWORK_CAPABILITY_TYPE_")]
	public enum FWPM_APPC_NETWORK_CAPABILITY_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Allows the app container to make network requests to servers on the Internet. It acts as a client.</para>
		/// </summary>
		FWPM_APPC_NETWORK_CAPABILITY_INTERNET_CLIENT,

		/// <summary>
		/// Allows the app container to make requests and to receive requests to and from the Internet. It acts as a client and also as a server.
		/// </summary>
		FWPM_APPC_NETWORK_CAPABILITY_INTERNET_CLIENT_SERVER,

		/// <summary>
		/// Allows the app container to make requests and to receive requests to and from private networks (such as a home network, work
		/// network, or the corporate domain network of the computer). It acts as a client and also as a server.
		/// </summary>
		FWPM_APPC_NETWORK_CAPABILITY_INTERNET_PRIVATE_NETWORK,
	}

	/// <summary>Flags for FWPM_CALLOUT0</summary>
	[PInvokeData("fwpmtypes.h")]
	[Flags]
	public enum FWPM_CALLOUT_FLAG : uint
	{
		/// <summary>The callout is persistent across reboots. As a result, it can be referenced by boot-time and other persistent filters.</summary>
		FWPM_CALLOUT_FLAG_PERSISTENT = 0x00010000,

		/// <summary>
		/// The callout needs access to the provider context stored in the filter invoking the callout. If this flag is set, the provider
		/// context will be copied from the FWPM_FILTER0 structure to the FWPS_FILTER0 structure. The FWPS_FILTER0 structure is documented in
		/// the WDK.
		/// </summary>
		FWPM_CALLOUT_FLAG_USES_PROVIDER_CONTEXT = 0x00020000,

		/// <summary>
		/// The callout is currently registered in the kernel. This flag must not be set when adding new callouts. It is used only in
		/// querying the state of existing callouts.
		/// </summary>
		FWPM_CALLOUT_FLAG_REGISTERED = 0x00040000,
	}

	/// <summary>The <c>FWPM_CHANGE_TYPE</c> enumerated type is used when dispatching change notifications to subscribers.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_change_type typedef enum FWPM_CHANGE_TYPE_ {
	// FWPM_CHANGE_ADD = 1, FWPM_CHANGE_DELETE, FWPM_CHANGE_TYPE_MAX } FWPM_CHANGE_TYPE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_CHANGE_TYPE_")]
	public enum FWPM_CHANGE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Specifies an add change notification.</para>
		/// </summary>
		FWPM_CHANGE_ADD = 1,

		/// <summary>Specifies a delete change notification.</summary>
		FWPM_CHANGE_DELETE,

		/// <summary>Maximum value for testing purposes.</summary>
		FWPM_CHANGE_TYPE_MAX,
	}

	/// <summary>Flags for <c>FWPM_CONNECTION_ENUM_TEMPLATE0</c>.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CONNECTION_ENUM_TEMPLATE0_")]
	[Flags]
	public enum FWPM_CONNECTION_ENUM_FLAG : uint
	{
		/// <summary>
		/// If set, the IPsec driver will be queried for the current bytes transferred via this connection (allowing monitoring tools to
		/// collect accurate data without requiring that querying capabilities remain constantly on).
		/// </summary>
		FWPM_CONNECTION_ENUM_FLAG_QUERY_BYTES_TRANSFERRED = 0x00000001
	}

	/// <summary>The <c>FWPM_CONNECTION_EVENT_TYPE</c> enumeration specifies the type of connection object change event.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_connection_event_type typedef enum
	// FWPM_CONNECTION_EVENT_TYPE_ { FWPM_CONNECTION_EVENT_ADD = 0, FWPM_CONNECTION_EVENT_DELETE, FWPM_CONNECTION_EVENT_MAX } FWPM_CONNECTION_EVENT_TYPE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_CONNECTION_EVENT_TYPE_")]
	public enum FWPM_CONNECTION_EVENT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A new connection object was added.</para>
		/// </summary>
		FWPM_CONNECTION_EVENT_ADD,

		/// <summary>A connection object was deleted.</summary>
		FWPM_CONNECTION_EVENT_DELETE,

		/// <summary>Maximum value for testing purposes.</summary>
		FWPM_CONNECTION_EVENT_MAX,
	}

	/// <summary>The <c>FWPM_ENGINE_OPTION</c> enumerated type specifies configurable options for the filter engine.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_engine_option typedef enum FWPM_ENGINE_OPTION_ {
	// FWPM_ENGINE_COLLECT_NET_EVENTS = 0, FWPM_ENGINE_NET_EVENT_MATCH_ANY_KEYWORDS, FWPM_ENGINE_NAME_CACHE,
	// FWPM_ENGINE_MONITOR_IPSEC_CONNECTIONS, FWPM_ENGINE_PACKET_QUEUING, FWPM_ENGINE_TXN_WATCHDOG_TIMEOUT_IN_MSEC, FWPM_ENGINE_OPTION_MAX } FWPM_ENGINE_OPTION;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_ENGINE_OPTION_")]
	public enum FWPM_ENGINE_OPTION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The filter engine will collect WFP network events.</para>
		/// </summary>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.GetSet)]
		FWPM_ENGINE_COLLECT_NET_EVENTS,

		/// <summary>The filter engine will collect WFP network events that match any supplied key words.</summary>
		[CorrespondingType(typeof(FWPM_NET_EVENT_KEYWORD), CorrespondingAction.GetSet)]
		FWPM_ENGINE_NET_EVENT_MATCH_ANY_KEYWORDS,

		/// <summary>
		/// <para>Reserved for internal use.</para>
		/// <para><c>Note</c> Available only in Windows Server 2008 R2, Windows 7, and later.</para>
		/// </summary>
		FWPM_ENGINE_NAME_CACHE,

		/// <summary>
		/// <para>Enables the connection monitoring feature and starts logging creation and deletion events (and notifying any subscribers).</para>
		/// <para>
		/// If the ETW operational log is already enabled, FwpmEngineGetOption0 will return showing the option as enabled.
		/// FwpmEngineSetOption0 can be used set the value (but fails with FWP_E_STILL_ON ERROR when attempting to disable it).
		/// </para>
		/// <para><c>Note</c> Available only in Windows 8 and Windows Server 2012.</para>
		/// </summary>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.GetSet)]
		FWPM_ENGINE_MONITOR_IPSEC_CONNECTIONS,

		/// <summary>
		/// <para>
		/// Enables inbound or forward packet queuing independently. When enabled, the system is able to evenly distribute CPU load to
		/// multiple CPUs for site-to-site IPsec tunnel scenarios.
		/// </para>
		/// <para><c>Note</c> Available only in Windows 8 and Windows Server 2012.</para>
		/// </summary>
		[CorrespondingType(typeof(FWPM_ENGINE_OPTION_PACKET_QUEUE), CorrespondingAction.GetSet)]
		FWPM_ENGINE_PACKET_QUEUING,

		/// <summary>
		/// <para>Transactions lasting longer than this time (in milliseconds) will trigger a</para>
		/// <para>watchdog event.</para>
		/// <para><c>Note</c> Available only in Windows 8 and Windows Server 2012.</para>
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		FWPM_ENGINE_TXN_WATCHDOG_TIMEOUT_IN_MSEC,

		/// <summary>Maximum value for testing purposes.</summary>
		FWPM_ENGINE_OPTION_MAX,
	}

	/// <summary>Values get or set through <c>FWP_VALUE0</c>.</summary>
	[Flags]
	public enum FWPM_ENGINE_OPTION_PACKET_QUEUE : uint
	{
		/// <summary>Do not enable packet queuing.</summary>
		FWPM_ENGINE_OPTION_PACKET_QUEUE_NONE = 0x00000000,

		/// <summary>Enable inbound packet queuing.</summary>
		FWPM_ENGINE_OPTION_PACKET_QUEUE_INBOUND = 0x00000001,

		/// <summary>Enable outbound packet queuing.</summary>
		FWPM_ENGINE_OPTION_PACKET_QUEUE_FORWARD = 0x00000002,

		/// <summary/>
		FWPM_ENGINE_OPTION_PACKET_BATCH_INBOUND = 0x00000004,
	}

	/// <summary>The <c>FWPM_FIELD_TYPE</c> enumerated type provides additional information about how the field's data should be interpreted.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_field_type typedef enum FWPM_FIELD_TYPE_ {
	// FWPM_FIELD_RAW_DATA = 0, FWPM_FIELD_IP_ADDRESS, FWPM_FIELD_FLAGS, FWPM_FIELD_TYPE_MAX } FWPM_FIELD_TYPE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_FIELD_TYPE_")]
	public enum FWPM_FIELD_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Value contains raw data.</para>
		/// </summary>
		FWPM_FIELD_RAW_DATA,

		/// <summary>Value contains an IP address.</summary>
		FWPM_FIELD_IP_ADDRESS,

		/// <summary>
		/// <para>Value contains flags.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		FWPM_FIELD_FLAGS,

		/// <summary>Maximum value for testing purposes.</summary>
		FWPM_FIELD_TYPE_MAX,
	}

	/// <summary>Flags for <c>FWPM_FILTER0</c>.</summary>
	[PInvokeData("fwpmtypes.h")]
	[Flags]
	public enum FWPM_FILTER_FLAG : uint
	{
		/// <summary>Default.</summary>
		FWPM_FILTER_FLAG_NONE = 0x00000000,

		/// <summary>Filter is persistent, that is, it survives across BFE stop/start.</summary>
		FWPM_FILTER_FLAG_PERSISTENT = 0x00000001,

		/// <summary>Filter is enforced at boot-time, even before BFE starts.</summary>
		FWPM_FILTER_FLAG_BOOTTIME = 0x00000002,

		/// <summary>Filter references a provider context.</summary>
		FWPM_FILTER_FLAG_HAS_PROVIDER_CONTEXT = 0x00000004,

		/// <summary>Clear filter action right.</summary>
		FWPM_FILTER_FLAG_CLEAR_ACTION_RIGHT = 0x00000008,

		/// <summary>If the callout is not registered, the filter is treated as a permit filter.</summary>
		FWPM_FILTER_FLAG_PERMIT_IF_CALLOUT_UNREGISTERED = 0x00000010,

		/// <summary>
		/// Filter is disabled. A provider's filters are disabled when the BFE starts if the provider has no associated Windows service name,
		/// or if the associated service is not set to auto-start.
		/// </summary>
		FWPM_FILTER_FLAG_DISABLED = 0x00000020,

		/// <summary>Filter is indexed to help enable faster lookup during classification.</summary>
		FWPM_FILTER_FLAG_INDEXED = 0x00000040,

		/// <summary/>
		FWPM_FILTER_FLAG_HAS_SECURITY_REALM_PROVIDER_CONTEXT = 0x00000080,

		/// <summary/>
		FWPM_FILTER_FLAG_SYSTEMOS_ONLY = 0x00000100,

		/// <summary/>
		FWPM_FILTER_FLAG_GAMEOS_ONLY = 0x00000200,

		/// <summary/>
		FWPM_FILTER_FLAG_SILENT_MODE = 0x00000400,

		/// <summary/>
		FWPM_FILTER_FLAG_IPSEC_NO_ACQUIRE_INITIATE = 0x00000800,

		/// <summary/>
		FWPM_FILTER_FLAG_RESERVED0 = 0x00001000,

		/// <summary/>
		FWPM_FILTER_FLAG_RESERVED1 = 0x00002000,
	}

	/// <summary>Flags for <c>FWPM_LAYER0</c>.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_LAYER0_")]
	[Flags]
	public enum FWPM_LAYER_FLAG : uint
	{
		/// <summary>Layer classified in kernel-mode.</summary>
		FWPM_LAYER_FLAG_KERNEL = 0x00000001,

		/// <summary>Layer built-in. Cannot be deleted.</summary>
		FWPM_LAYER_FLAG_BUILTIN = 0x00000002,

		/// <summary>Layer optimized for classification rather than enumeration.</summary>
		FWPM_LAYER_FLAG_CLASSIFY_MOSTLY = 0x00000004,

		/// <summary>Layer is buffered.</summary>
		FWPM_LAYER_FLAG_BUFFERED = 0x00000008,
	}

	/// <summary>Flags indicating which of the following members are set. Unused fields must be zero-initialized.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_HEADER0_")]
	[Flags]
	public enum FWPM_NET_EVENT_FLAG : uint
	{
		/// <summary>The <c>ipProtocol</c> member is set.</summary>
		FWPM_NET_EVENT_FLAG_IP_PROTOCOL_SET = 0x00000001,

		/// <summary>
		/// Either the <c>localAddrV4</c> member or the <c>localAddrV6</c> member is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </summary>
		FWPM_NET_EVENT_FLAG_LOCAL_ADDR_SET = 0x00000002,

		/// <summary>
		/// Either the <c>remoteAddrV4</c> member of the <c>remoteAddrV6</c> field is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </summary>
		FWPM_NET_EVENT_FLAG_REMOTE_ADDR_SET = 0x00000004,

		/// <summary>The <c>localPort</c> member is set.</summary>
		FWPM_NET_EVENT_FLAG_LOCAL_PORT_SET = 0x00000008,

		/// <summary>The <c>remotePort</c> member is set.</summary>
		FWPM_NET_EVENT_FLAG_REMOTE_PORT_SET = 0x00000010,

		/// <summary>The <c>appId</c> member is set.</summary>
		FWPM_NET_EVENT_FLAG_APP_ID_SET = 0x00000020,

		/// <summary>The <c>userId</c> member is set.</summary>
		FWPM_NET_EVENT_FLAG_USER_ID_SET = 0x00000040,

		/// <summary>The <c>scopeId</c> member is set.</summary>
		FWPM_NET_EVENT_FLAG_SCOPE_ID_SET = 0x00000080,

		/// <summary>The <c>ipVersion</c> member is set.</summary>
		FWPM_NET_EVENT_FLAG_IP_VERSION_SET = 0x00000100,

		/// <summary/>
		FWPM_NET_EVENT_FLAG_REAUTH_REASON_SET = 0x00000200,

		/// <summary/>
		FWPM_NET_EVENT_FLAG_PACKAGE_ID_SET = 0x00000400,

		/// <summary/>
		FWPM_NET_EVENT_FLAG_ENTERPRISE_ID_SET = 0x00000800,

		/// <summary/>
		FWPM_NET_EVENT_FLAG_POLICY_FLAGS_SET = 0x00001000,

		/// <summary/>
		FWPM_NET_EVENT_FLAG_EFFECTIVE_NAME_SET = 0x00002000,
	}

	/// <summary>Flags for the failure event.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_IKEEXT_EM_FAILURE0_")]
	[Flags]
	public enum FWPM_NET_EVENT_IKEEXT_EM_FAILURE_FLAG : uint
	{
		/// <summary>Indicates that multiple IKE EM failure events have been reported.</summary>
		FWPM_NET_EVENT_IKEEXT_EM_FAILURE_FLAG_MULTIPLE = 0x00000001,

		/// <summary>Indicates that the failure was benign or expected.</summary>
		FWPM_NET_EVENT_IKEEXT_EM_FAILURE_FLAG_BENIGN = 0x00000002,
	}

	/// <summary>Flags for the failure event.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_IKEEXT_MM_FAILURE0_")]
	[Flags]
	public enum FWPM_NET_EVENT_IKEEXT_MM_FAILURE_FLAG : uint
	{
		/// <summary>Indicates that the failure was benign or expected.</summary>
		FWPM_NET_EVENT_IKEEXT_MM_FAILURE_FLAG_BENIGN = 0x00000001,

		/// <summary>Indicates that multiple failure events have been reported.</summary>
		FWPM_NET_EVENT_IKEEXT_MM_FAILURE_FLAG_MULTIPLE = 0x00000002,
	}

	/// <summary>Flags get or set through <see cref="FWP_VALUE0"/>.</summary>
	[PInvokeData("fwpmtypes.h")]
	[Flags]
	public enum FWPM_NET_EVENT_KEYWORD : uint
	{
		/// <summary>Collect inbound multicast network events.</summary>
		FWPM_NET_EVENT_KEYWORD_INBOUND_MCAST = 0x00000001,

		/// <summary>Collect inbound broadcast network events.</summary>
		FWPM_NET_EVENT_KEYWORD_INBOUND_BCAST = 0x00000002,

		/// <summary/>
		FWPM_NET_EVENT_KEYWORD_CAPABILITY_DROP = 0x00000004,

		/// <summary/>
		FWPM_NET_EVENT_KEYWORD_CAPABILITY_ALLOW = 0x00000008,

		/// <summary/>
		FWPM_NET_EVENT_KEYWORD_CLASSIFY_ALLOW = 0x00000010,

		/// <summary/>
		FWPM_NET_EVENT_KEYWORD_PORT_SCANNING_DROP = 0x00000020,
	}

	/// <summary>The <c>FWPM_NET_EVENT_TYPE</c> enumerated type specifies the type of net event.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_net_event_type typedef enum FWPM_NET_EVENT_TYPE_ {
	// FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE = 0, FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE, FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE,
	// FWPM_NET_EVENT_TYPE_CLASSIFY_DROP, FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP, FWPM_NET_EVENT_TYPE_IPSEC_DOSP_DROP,
	// FWPM_NET_EVENT_TYPE_CLASSIFY_ALLOW, FWPM_NET_EVENT_TYPE_CAPABILITY_DROP, FWPM_NET_EVENT_TYPE_CAPABILITY_ALLOW,
	// FWPM_NET_EVENT_TYPE_CLASSIFY_DROP_MAC, FWPM_NET_EVENT_TYPE_LPM_PACKET_ARRIVAL, FWPM_NET_EVENT_TYPE_MAX } FWPM_NET_EVENT_TYPE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_NET_EVENT_TYPE_")]
	public enum FWPM_NET_EVENT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>An IKE/AuthIP main mode failure has occurred.</para>
		/// </summary>
		FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE,

		/// <summary>An IKE/AuthIP quick mode failure has occurred.</summary>
		FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE,

		/// <summary>An AuthIP extended mode failure has occurred.</summary>
		FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE,

		/// <summary>A drop event has occurred.</summary>
		FWPM_NET_EVENT_TYPE_CLASSIFY_DROP,

		/// <summary>An IPsec kernel drop event has occurred.</summary>
		FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP,

		/// <summary>
		/// <para>An IPsec DoS Protection drop event has occurred.</para>
		/// <para><c>Note</c> Available only in Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		FWPM_NET_EVENT_TYPE_IPSEC_DOSP_DROP,

		/// <summary>
		/// <para>An allow event has occurred.</para>
		/// <para><c>Note</c> Available only in Windows 8 and Windows Server 2012.</para>
		/// </summary>
		FWPM_NET_EVENT_TYPE_CLASSIFY_ALLOW,

		/// <summary>
		/// <para>An app container network capability drop event has occurred.</para>
		/// <para><c>Note</c> Available only in Windows 8 and Windows Server 2012.</para>
		/// </summary>
		FWPM_NET_EVENT_TYPE_CAPABILITY_DROP,

		/// <summary>
		/// <para>An app container network capability allow event has occurred.</para>
		/// <para><c>Note</c> Available only in Windows 8 and Windows Server 2012.</para>
		/// </summary>
		FWPM_NET_EVENT_TYPE_CAPABILITY_ALLOW,

		/// <summary>
		/// <para>A MAC layer drop event has occurred.</para>
		/// <para><c>Note</c> Available only in Windows 8 and Windows Server 2012.</para>
		/// </summary>
		FWPM_NET_EVENT_TYPE_CLASSIFY_DROP_MAC,

		/// <summary/>
		FWPM_NET_EVENT_TYPE_LPM_PACKET_ARRIVAL,

		/// <summary>Maximum value for testing purposes.</summary>
		FWPM_NET_EVENT_TYPE_MAX,
	}

	/// <summary>Flags for <see cref="FWPM_PROVIDER_CONTEXT2"/></summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_CONTEXT1_")]
	[Flags]
	public enum FWPM_PROVIDER_CONTEXT_FLAG : uint
	{
		/// <summary>The object is persistent, that is, it survives across BFE stop/start.</summary>
		FWPM_PROVIDER_CONTEXT_FLAG_PERSISTENT = 0x00000001,

		/// <summary>Reserved for internal use.</summary>
		FWPM_PROVIDER_CONTEXT_FLAG_DOWNLEVEL = 0x00000002,
	}

	/// <summary>
	/// The <c>FWPM_PROVIDER_CONTEXT_TYPE</c> enumerated type specifies types of provider contexts that may be stored in Base Filtering
	/// Engine (BFE).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_provider_context_type typedef enum
	// FWPM_PROVIDER_CONTEXT_TYPE_ { FWPM_IPSEC_KEYING_CONTEXT = 0, FWPM_IPSEC_IKE_QM_TRANSPORT_CONTEXT, FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT,
	// FWPM_IPSEC_AUTHIP_QM_TRANSPORT_CONTEXT, FWPM_IPSEC_AUTHIP_QM_TUNNEL_CONTEXT, FWPM_IPSEC_IKE_MM_CONTEXT, FWPM_IPSEC_AUTHIP_MM_CONTEXT,
	// FWPM_CLASSIFY_OPTIONS_CONTEXT, FWPM_GENERAL_CONTEXT, FWPM_IPSEC_IKEV2_QM_TUNNEL_CONTEXT, FWPM_IPSEC_IKEV2_MM_CONTEXT,
	// FWPM_IPSEC_DOSP_CONTEXT, FWPM_IPSEC_IKEV2_QM_TRANSPORT_CONTEXT, FWPM_NETWORK_CONNECTION_POLICY_CONTEXT, FWPM_PROVIDER_CONTEXT_TYPE_MAX
	// } FWPM_PROVIDER_CONTEXT_TYPE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_PROVIDER_CONTEXT_TYPE_")]
	public enum FWPM_PROVIDER_CONTEXT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies keying context type.</para>
		/// </summary>
		FWPM_IPSEC_KEYING_CONTEXT,

		/// <summary>Specifies IPsec IKE quick mode transport context type.</summary>
		FWPM_IPSEC_IKE_QM_TRANSPORT_CONTEXT,

		/// <summary>Specifies IPsec IKE quick mode tunnel context type.</summary>
		FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT,

		/// <summary>Specifies IPsec AuthIP quick mode transport context type.</summary>
		FWPM_IPSEC_AUTHIP_QM_TRANSPORT_CONTEXT,

		/// <summary>Specifies IPsec Authip quick mode tunnel context type.</summary>
		FWPM_IPSEC_AUTHIP_QM_TUNNEL_CONTEXT,

		/// <summary>Specifies IKE main mode context type.</summary>
		FWPM_IPSEC_IKE_MM_CONTEXT,

		/// <summary>Specifies AuthIP main mode context type.</summary>
		FWPM_IPSEC_AUTHIP_MM_CONTEXT,

		/// <summary>Specifies classify options context type.</summary>
		FWPM_CLASSIFY_OPTIONS_CONTEXT,

		/// <summary>Specifies general context type.</summary>
		FWPM_GENERAL_CONTEXT,

		/// <summary>
		/// <para>Specifies IKE v2 quick mode tunnel context type.</para>
		/// <para><c>Note</c> Available only in Windows Server 2008 R2, Windows 7, and later.</para>
		/// </summary>
		FWPM_IPSEC_IKEV2_QM_TUNNEL_CONTEXT,

		/// <summary>
		/// <para>Specifies IKE v2 main mode tunnel context type.</para>
		/// <para><c>Note</c> Available only in Windows Server 2008 R2, Windows 7, and later.</para>
		/// </summary>
		FWPM_IPSEC_IKEV2_MM_CONTEXT,

		/// <summary>
		/// <para>Specifies IPsec DoS Protection context type.</para>
		/// <para><c>Note</c> Available only in Windows Server 2008 R2, Windows 7, and later.</para>
		/// </summary>
		FWPM_IPSEC_DOSP_CONTEXT,

		/// <summary>
		/// <para>Specifies IKE v2 quick mode transport context type.</para>
		/// <para><c>Note</c> Available only in Windows 8 and Windows 8.</para>
		/// </summary>
		FWPM_IPSEC_IKEV2_QM_TRANSPORT_CONTEXT,

		/// <summary>Maximum value for testing purposes.</summary>
		FWPM_PROVIDER_CONTEXT_TYPE_MAX,
	}

	/// <summary>Bit flags that indicate information about the persistence of the provider.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER0_")]
	[Flags]
	public enum FWPM_PROVIDER_FLAG : uint
	{
		/// <summary>The provider is persistent.</summary>
		FWPM_PROVIDER_FLAG_PERSISTENT = 0x00000001,

		/// <summary>
		/// Provider's filters were disabled when the BFE started because the provider has no associated Windows service name, or because the
		/// associated service was not set to auto-start.
		/// </summary>
		FWPM_PROVIDER_FLAG_DISABLED = 0x00000010,
	}

	/// <summary>The <c>FWPM_SERVICE_STATE</c> enumeration specifies the current state of the filter engine.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_service_state typedef enum FWPM_SERVICE_STATE_ {
	// FWPM_SERVICE_STOPPED = 0, FWPM_SERVICE_START_PENDING, FWPM_SERVICE_STOP_PENDING, FWPM_SERVICE_RUNNING, FWPM_SERVICE_STATE_MAX } FWPM_SERVICE_STATE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_SERVICE_STATE_")]
	public enum FWPM_SERVICE_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The filter engine is not running.</para>
		/// </summary>
		FWPM_SERVICE_STOPPED,

		/// <summary>The filter engine is starting.</summary>
		FWPM_SERVICE_START_PENDING,

		/// <summary>The filter engine is stopping.</summary>
		FWPM_SERVICE_STOP_PENDING,

		/// <summary>The filter engine is running.</summary>
		FWPM_SERVICE_RUNNING,

		/// <summary>Maximum value for testing purposes.</summary>
		FWPM_SERVICE_STATE_MAX,
	}

	/// <summary>Settings to control session behavior.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SESSION0_")]
	[Flags]
	public enum FWPM_SESSION_FLAG : uint
	{
		/// <summary>When this flag is set, any objects added during the session are automatically deleted when the session ends.</summary>
		FWPM_SESSION_FLAG_DYNAMIC = 0x00000001,

		/// <summary>Reserved.</summary>
		FWPM_SESSION_FLAG_RESERVED = 0x10000000,
	}

	/// <summary>Flags for <c>FWPM_SUBLAYER0</c>.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SUBLAYER0_")]
	[Flags]
	public enum FWPM_SUBLAYER_FLAG : uint
	{
		/// <summary>Causes sublayer to be persistent, surviving across BFE stop/start.</summary>
		FWPM_SUBLAYER_FLAG_PERSISTENT = 0x00000001
	}

	/// <summary>The notification type(s) received by the subscription.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CALLOUT_SUBSCRIPTION0_")]
	[Flags]
	public enum FWPM_SUBSCRIPTION_FLAG : uint
	{
		/// <summary>Subscribe to callout add notifications.</summary>
		FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_ADD = 0x00000001,

		/// <summary>Subscribe to callout delete notifications.</summary>
		FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_DELETE = 0x00000002,
	}

	/// <summary>The <c>FWPM_SYSTEM_PORT_TYPE</c> enumerated type specifies the type of system port.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_system_port_type typedef enum FWPM_SYSTEM_PORT_TYPE_ {
	// FWPM_SYSTEM_PORT_RPC_EPMAP = 0, FWPM_SYSTEM_PORT_TEREDO, FWPM_SYSTEM_PORT_IPHTTPS_IN, FWPM_SYSTEM_PORT_IPHTTPS_OUT,
	// FWPM_SYSTEM_PORT_TYPE_MAX } FWPM_SYSTEM_PORT_TYPE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_SYSTEM_PORT_TYPE_")]
	public enum FWPM_SYSTEM_PORT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies a system port used by an RPC endpoint mapper.</para>
		/// </summary>
		FWPM_SYSTEM_PORT_RPC_EPMAP,

		/// <summary>Specifies a system port used by the Teredo service.</summary>
		FWPM_SYSTEM_PORT_TEREDO,

		/// <summary>Specifies an inbound system port used by the IP in conjunction with HTTPS implementation.</summary>
		FWPM_SYSTEM_PORT_IPHTTPS_IN,

		/// <summary>Specifies an outbound system port used by the IP in conjunction with HTTPS implementation.</summary>
		FWPM_SYSTEM_PORT_IPHTTPS_OUT,

		/// <summary>Maximum value for testing purposes.</summary>
		FWPM_SYSTEM_PORT_TYPE_MAX,
	}

	/// <summary>The <c>FWPM_VSWITCH_EVENT_TYPE</c> enumeration specifies the type of a vSwitch event.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ne-fwpmtypes-fwpm_vswitch_event_type typedef enum
	// FWPM_VSWITCH_EVENT_TYPE_ { FWPM_VSWITCH_EVENT_FILTER_ADD_TO_INCOMPLETE_LAYER = 0,
	// FWPM_VSWITCH_EVENT_FILTER_ENGINE_NOT_IN_REQUIRED_POSITION, FWPM_VSWITCH_EVENT_ENABLED_FOR_INSPECTION,
	// FWPM_VSWITCH_EVENT_DISABLED_FOR_INSPECTION, FWPM_VSWITCH_EVENT_FILTER_ENGINE_REORDER, FWPM_VSWITCH_EVENT_MAX } FWPM_VSWITCH_EVENT_TYPE;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NE:fwpmtypes.FWPM_VSWITCH_EVENT_TYPE_")]
	public enum FWPM_VSWITCH_EVENT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The filter engine is not enabled on all vSwitch instances. As a result, the filter(s) being added may not be fully enforced.</para>
		/// </summary>
		FWPM_VSWITCH_EVENT_FILTER_ADD_TO_INCOMPLETE_LAYER,

		/// <summary>
		/// The filter engine to which the filter(s) are being added is not in its required position (typically the first filtering extension
		/// in the vSwitch instance). As a result, the filter(s) could be bypassed.
		/// </summary>
		FWPM_VSWITCH_EVENT_FILTER_ENGINE_NOT_IN_REQUIRED_POSITION,

		/// <summary>The filter engine is being enabled for the vSwitch instance.</summary>
		FWPM_VSWITCH_EVENT_ENABLED_FOR_INSPECTION,

		/// <summary>The filter engine is being disabled for the vSwitch instance.</summary>
		FWPM_VSWITCH_EVENT_DISABLED_FOR_INSPECTION,

		/// <summary>
		/// <para>The filter engine is being reordered and may not be in the</para>
		/// <para>required position to enforce committed filters.</para>
		/// </summary>
		FWPM_VSWITCH_EVENT_FILTER_ENGINE_REORDER,

		/// <summary>Maximum value for testing purposes.</summary>
		FWPM_VSWITCH_EVENT_MAX,
	}

	/// <summary>The <c>FWPM_ACTION0</c> structure specifies the action taken if all the filter conditions are true.</summary>
	/// <remarks>
	/// <c>FWPM_ACTION0</c> is a specific implementation of FWPM_ACTION. See WFP Version-Independent Names and Targeting Specific Versions of
	/// Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_action0 typedef struct FWPM_ACTION0_ { FWP_ACTION_TYPE
	// type; union { GUID filterType; GUID calloutKey; }; } FWPM_ACTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_ACTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_ACTION0
	{
		/// <summary>
		/// <para>Action type as specified by <c>FWP_ACTION_TYPE</c> which maps to a <c>UINT32</c>.</para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWP_ACTION_BLOCK</c></term>
		/// <term>Block the traffic. 0x00000001 | FWP_ACTION_FLAG_TERMINATING</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_ACTION_PERMIT</c></term>
		/// <term>Permit the traffic. 0x00000002 | FWP_ACTION_FLAG_TERMINATING</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_ACTION_CALLOUT_TERMINATING</c></term>
		/// <term>Invoke a callout that always returns block or permit. 0x00000003 | FWP_ACTION_FLAG_CALLOUT | FWP_ACTION_FLAG_TERMINATING</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_ACTION_CALLOUT_INSPECTION</c></term>
		/// <term>Invoke a callout that never returns block or permit. 0x00000004 | FWP_ACTION_FLAG_CALLOUT | FWP_ACTION_FLAG_NON_TERMINATING</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_ACTION_CALLOUT_UNKNOWN</c></term>
		/// <term>Invoke a callout that may return block or permit. 0x00000005 | FWP_ACTION_FLAG_CALLOUT</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWP_ACTION_TYPE type;

		/// <summary>
		/// <para>An arbitrary GUID chosen by the policy provider.</para>
		/// <para>Available when the action does not invoke a callout, that is, <c>type</c> does not contain <c>FWP_ACTION_FLAG_CALLOUT</c>.</para>
		/// </summary>
		public Guid filterType;

		/// <summary>
		/// <para>The GUID for a valid callout in the layer.</para>
		/// <para>Available when the action invokes a callout, that is, <c>type</c> contains <c>FWP_ACTION_FLAG_CALLOUT</c>.</para>
		/// </summary>
		public Guid calloutKey { get => filterType; set => filterType = value; }
	}

	/// <summary>The <c>FWPM_CALLOUT_CHANGE0</c> structure specifies a change notification dispatched to subscribers.</summary>
	/// <remarks>
	/// <c>FWPM_CALLOUT_CHANGE0</c> is a specific implementation of FWPM_CALLOUT_CHANGE. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_callout_change0 typedef struct FWPM_CALLOUT_CHANGE0_ {
	// FWPM_CHANGE_TYPE changeType; GUID calloutKey; UINT32 calloutId; } FWPM_CALLOUT_CHANGE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CALLOUT_CHANGE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_CALLOUT_CHANGE0
	{
		/// <summary>A FWPM_CHANGE_TYPE value that specifies the type of change.</summary>
		public FWPM_CHANGE_TYPE changeType;

		/// <summary>GUID of the callout that changed.</summary>
		public Guid calloutKey;

		/// <summary>LUID of the callout that changed.</summary>
		public uint calloutId;
	}

	/// <summary>The <c>FWPM_CALLOUT_ENUM_TEMPLATE0</c> structure is used for limiting callout enumerations.</summary>
	/// <remarks>
	/// <c>FWPM_CALLOUT_ENUM_TEMPLATE0</c> is a specific implementation of FWPM_CALLOUT_ENUM_TEMPLATE. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_callout_enum_template0 typedef struct
	// FWPM_CALLOUT_ENUM_TEMPLATE0_ { GUID *providerKey; GUID layerKey; } FWPM_CALLOUT_ENUM_TEMPLATE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CALLOUT_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_CALLOUT_ENUM_TEMPLATE0
	{
		/// <summary>
		/// Uniquely identifies the provider associated with the callout. If this member is non-NULL, only objects associated with the
		/// specified provider will be returned.
		/// </summary>
		public GuidPtr providerKey;

		/// <summary>
		/// Uniquely identifies a layer. If this member is non-NULL, only callouts associated with the specified layer will be returned.
		/// </summary>
		public Guid layerKey;
	}

	/// <summary>The <c>FWPM_CALLOUT_SUBSCRIPTION0</c> structure is used to subscribe for change notifications.</summary>
	/// <remarks>
	/// <para>Notifications are only dispatched for callouts that match the template.</para>
	/// <para>If the template is <c>NULL</c>, it matches all callouts.</para>
	/// <para>
	/// <c>FWPM_CALLOUT_SUBSCRIPTION0</c> is a specific implementation of FWPM_CALLOUT_SUBSCRIPTION. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_callout_subscription0 typedef struct
	// FWPM_CALLOUT_SUBSCRIPTION0_ { FWPM_CALLOUT_ENUM_TEMPLATE0 *enumTemplate; UINT32 flags; GUID sessionKey; } FWPM_CALLOUT_SUBSCRIPTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CALLOUT_SUBSCRIPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_CALLOUT_SUBSCRIPTION0
	{
		/// <summary>A FWPM_CALLOUT_ENUM_TEMPLATE0 structure that is used to limit the subscription.</summary>
		public IntPtr enumTemplate;

		/// <summary>
		/// <para>The notification type(s) received by the subscription.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_ADD</c></term>
		/// <term>Subscribe to callout add notifications.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_DELETE</c></term>
		/// <term>Subscribe to callout delete notifications.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_SUBSCRIPTION_FLAG flags;

		/// <summary>Uniquely identifies this session.</summary>
		public Guid sessionKey;
	}

	/// <summary>The <c>FWPM_CALLOUT0</c> structure stores the state associated with a callout.</summary>
	/// <remarks>
	/// <para>The first six members of this structure contain data supplied when adding objects.</para>
	/// <para>The last member, <c>calloutId</c>, provides additional information returned when getting/enumerating objects.</para>
	/// <para>
	/// <c>FWPM_CALLOUT0</c> is a specific implementation of FWPM_CALLOUT. See WFP Version-Independent Names and Targeting Specific Versions
	/// of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_callout0 typedef struct FWPM_CALLOUT0_ { GUID
	// calloutKey; FWPM_DISPLAY_DATA0 displayData; UINT32 flags; GUID *providerKey; FWP_BYTE_BLOB providerData; GUID applicableLayer; UINT32
	// calloutId; } FWPM_CALLOUT0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CALLOUT0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_CALLOUT0
	{
		/// <summary>
		/// <para>Uniquely identifies the session.</para>
		/// <para>If the GUID is initialized to zero in the call to FwpmCalloutAdd0, the base filtering engine (BFE) will generate one.</para>
		/// </summary>
		public Guid calloutKey;

		/// <summary>
		/// A FWPM_DISPLAY_DATA0 structure that contains human-readable annotations associated with the callout. The <c>name</c> member of
		/// the <c>FWPM_DISPLAY_DATA0</c> structure is required.
		/// </summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_CALLOUT_FLAG_PERSISTENT</c></term>
		/// <term>The callout is persistent across reboots. As a result, it can be referenced by boot-time and other persistent filters.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_CALLOUT_FLAG_USES_PROVIDER_CONTEXT</c></term>
		/// <term>
		/// The callout needs access to the provider context stored in the filter invoking the callout. If this flag is set, the provider
		/// context will be copied from the [FWPM_FILTER0](/windows/desktop/api/fwpmtypes/ns-fwpmtypes-fwpm_filter0) structure to the
		/// <c>FWPS_FILTER0</c> structure. The <c>FWPS_FILTER0</c> structure is documented in the WDK.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_CALLOUT_FLAG_REGISTERED</c></term>
		/// <term>
		/// The callout is currently registered in the kernel. This flag must not be set when adding new callouts. It is used only in
		/// querying the state of existing callouts.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_CALLOUT_FLAG flags;

		/// <summary>
		/// Uniquely identifies the provider associated with the callout. If the member is non-NULL, only objects associated with the
		/// specified provider will be returned.
		/// </summary>
		public GuidPtr providerKey;

		/// <summary>
		/// A FWP_BYTE_BLOB structure that contains optional provider-specific data that allows providers to store additional context
		/// information with the object.
		/// </summary>
		public FWP_BYTE_BLOB providerData;

		/// <summary>
		/// Specifies the layer in which the callout can be used. Only filters in this layer can invoke the callout. For more information,
		/// see Filtering Layer Identifiers.
		/// </summary>
		public Guid applicableLayer;

		/// <summary>
		/// LUID identifying the callout. This is the <c>calloutId</c> stored in the <c>FWPS_ACTION0</c> structure for filters that invoke a
		/// callout. The <c>FWPS_ACTION0</c> structure is documented in the WDK.
		/// </summary>
		public uint calloutId;
	}

	/// <summary>The <c>FWPM_CLASSIFY_OPTION0</c> structure is used to define unicast and multicast timeout options and data.</summary>
	/// <remarks>
	/// <para>The following table lists possible values for the members of a <c>FWPM_CLASSIFY_OPTION0</c> structure.</para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>type</c></term>
	/// <term><c>value</c></term>
	/// </listheader>
	/// <item>
	/// <term>FWP_CLASSIFY_OPTION_MULTICAST_STATE</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>FWP_CLASSIFY_OPTION_LOOSE_SOURCE_MAPPING</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>FWP_CLASSIFY_OPTION_UNICAST_LIFETIME</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>FWP_CLASSIFY_OPTION_MCAST_BCAST_LIFETIME</term>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>
	/// <c>FWPM_CLASSIFY_OPTION0</c> is a specific implementation of FWPM_CLASSIFY_OPTION. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_classify_option0 typedef struct FWPM_CLASSIFY_OPTION0_
	// { FWP_CLASSIFY_OPTION_TYPE type; FWP_VALUE0 value; } FWPM_CLASSIFY_OPTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CLASSIFY_OPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_CLASSIFY_OPTION0
	{
		/// <summary>An FWP_CLASSIFY_OPTION_TYPE value.</summary>
		public FWP_CLASSIFY_OPTION_TYPE type;

		/// <summary>An FWP_VALUE0 structure.</summary>
		public FWP_VALUE0 value;
	}

	/// <summary>The <c>FWPM_CLASSIFY_OPTIONS0</c> structure is used to store <c>FWPM_CLASSIFY_OPTION0</c> structures.</summary>
	/// <remarks>
	/// <c>FWPM_CLASSIFY_OPTIONS0</c> is a specific implementation of FWPM_CLASSIFY_OPTIONS. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_classify_options0 typedef struct
	// FWPM_CLASSIFY_OPTIONS0_ { UINT32 numOptions; FWPM_CLASSIFY_OPTION0 *options; } FWPM_CLASSIFY_OPTIONS0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CLASSIFY_OPTIONS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_CLASSIFY_OPTIONS0
	{
		/// <summary>Number of <c>FWPM_CLASSIFY_OPTION0</c> structures in the <c>options</c> member.</summary>
		public uint numOptions;

		/// <summary>
		/// <para>[size_is(numCredentials)]</para>
		/// <para>Pointer to an array of <see cref="FWPM_CLASSIFY_OPTION0"/> structures.</para>
		/// </summary>
		public IntPtr options;
	}

	/// <summary>The <c>FWPM_CONNECTION_ENUM_TEMPLATE0</c> structure is used for limiting connection object enumerations.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_connection_enum_template0 typedef struct
	// FWPM_CONNECTION_ENUM_TEMPLATE0_ { UINT64 connectionId; UINT32 flags; } FWPM_CONNECTION_ENUM_TEMPLATE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CONNECTION_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_CONNECTION_ENUM_TEMPLATE0
	{
		/// <summary>Uniquely identifies a connection object.</summary>
		public ulong connectionId;

		/// <summary>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_CONNECTION_ENUM_FLAG_QUERY_BYTES_TRANSFERRED</c> 0x00000001</term>
		/// <term>
		/// If set, the IPsec driver will be queried for the current bytes transferred via this connection (allowing monitoring tools to
		/// collect accurate data without requiring that querying capabilities remain constantly on).
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_CONNECTION_ENUM_FLAG flags;
	}

	/// <summary>
	/// The <c>FWPM_CONNECTION_SUBSCRIPTION0</c> structure stores information used to subscribe to notifications about a connection object.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_connection_subscription0 typedef struct
	// FWPM_CONNECTION_SUBSCRIPTION0_ { FWPM_CONNECTION_ENUM_TEMPLATE0 *enumTemplate; UINT32 flags; GUID sessionKey; } FWPM_CONNECTION_SUBSCRIPTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CONNECTION_SUBSCRIPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_CONNECTION_SUBSCRIPTION0
	{
		/// <summary>Enumeration template <see cref="FWPM_CONNECTION_ENUM_TEMPLATE0"/> for limiting the subscription.</summary>
		public IntPtr enumTemplate;

		/// <summary>Reserved for system use.</summary>
		public uint flags;

		/// <summary>Identifies the session that created the subscription.</summary>
		public Guid sessionKey;
	}

	/// <summary>The <c>FWPM_CONNECTION0</c> structure stores the state associated with a connection object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_connection0 typedef struct FWPM_CONNECTION0_ { UINT64
	// connectionId; FWP_IP_VERSION ipVersion; union { UINT32 localV4Address; UINT8 localV6Address[16]; }; union { UINT32 remoteV4Address;
	// UINT8 remoteV6Address[16]; }; GUID *providerKey; IPSEC_TRAFFIC_TYPE ipsecTrafficModeType; IKEEXT_KEY_MODULE_TYPE keyModuleType;
	// IKEEXT_PROPOSAL0 mmCrypto; IKEEXT_CREDENTIAL2 mmPeer; IKEEXT_CREDENTIAL2 emPeer; UINT64 bytesTransferredIn; UINT64
	// bytesTransferredOut; UINT64 bytesTransferredTotal; FILETIME startSysTime; } FWPM_CONNECTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_CONNECTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_CONNECTION0
	{
		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The run-time identifier for the connection.</para>
		/// </summary>
		public ulong connectionId;

		/// <summary>
		/// <para>Type: FWP_IP_VERSION</para>
		/// <para>The IP version being used.</para>
		/// </summary>
		public FWP_IP_VERSION ipVersion;

		private FWP_BYTE_ARRAY_ADDR local;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The IPv4 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR localV4Address { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>Type: <c>UINT8[16]</c></para>
		/// <para>The IPv6 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR localV6Address { get => local.addr6; set => local.addr6 = value; }

		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The IPv4 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR remoteV4Address { get => remote.addr; set => remote.addr = value; }

		/// <summary>
		/// <para>Type: <c>UINT8[16]</c></para>
		/// <para>The IPv6 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR remoteV6Address { get => remote.addr6; set => remote.addr6 = value; }

		/// <summary>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Uniquely identifies the provider associated with this connection.</para>
		/// </summary>
		public GuidPtr providerKey;

		/// <summary>
		/// <para>Type: IPSEC_TRAFFIC_TYPE</para>
		/// <para>The type of IPsec traffic.</para>
		/// </summary>
		public IPSEC_TRAFFIC_TYPE ipsecTrafficModeType;

		/// <summary>
		/// <para>Type: IKEEXT_KEY_MODULE_TYPE</para>
		/// <para>The type of keying module.</para>
		/// </summary>
		public IKEEXT_KEY_MODULE_TYPE keyModuleType;

		/// <summary>
		/// <para>Type: IKEEXT_PROPOSAL0</para>
		/// <para>An IKE/AuthIP main mode proposal.</para>
		/// </summary>
		public IKEEXT_PROPOSAL0 mmCrypto;

		/// <summary>
		/// <para>Type: IKEEXT_CREDENTIAL2</para>
		/// <para>Main mode credential information.</para>
		/// </summary>
		public IKEEXT_CREDENTIAL2 mmPeer;

		/// <summary>
		/// <para>Type: IKEEXT_CREDENTIAL2</para>
		/// <para>Extended mode credential information.</para>
		/// </summary>
		public IKEEXT_CREDENTIAL2 emPeer;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The total number of incoming bytes transferred by the connection.</para>
		/// </summary>
		public ulong bytesTransferredIn;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The total number of outgoing bytes transferred by the connection.</para>
		/// </summary>
		public ulong bytesTransferredOut;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The total number of bytes (incoming and outgoing) transferred by the connection.</para>
		/// </summary>
		public ulong bytesTransferredTotal;

		/// <summary>
		/// <para>Type: <c>FILETIME</c></para>
		/// <para>Time that the connection was created.</para>
		/// </summary>
		public FILETIME startSysTime;
	}

	/// <summary>The <c>FWPM_FIELD0</c> structure specifies schema information for a field.</summary>
	/// <remarks>
	/// <c>FWPM_FIELD0</c> is a specific implementation of FWPM_FIELD. See WFP Version-Independent Names and Targeting Specific Versions of
	/// Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_field0 typedef struct FWPM_FIELD0_ { GUID *fieldKey;
	// FWPM_FIELD_TYPE type; FWP_DATA_TYPE dataType; } FWPM_FIELD0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_FIELD0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_FIELD0
	{
		/// <summary>Uniquely identifies the field. See FWPM_CONDITION_* identifiers in the topic Filtering Condition Identifiers.</summary>
		public GuidPtr fieldKey;

		/// <summary>
		/// <para>Determines how <c>dataType</c> is interpreted.</para>
		/// <para>See FWPM_FIELD_TYPE for more information.</para>
		/// </summary>
		public FWPM_FIELD_TYPE type;

		/// <summary>
		/// <para>Data type passed to classify.</para>
		/// <para>See FWP_DATA_TYPE for more information.</para>
		/// </summary>
		public FWP_DATA_TYPE dataType;
	}

	/// <summary>The <c>FWPM_FILTER_CHANGE0</c> structure stores change notification dispatched to subscribers.</summary>
	/// <remarks>
	/// <c>FWPM_FILTER_CHANGE0</c> is a specific implementation of FWPM_FILTER_CHANGE. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_filter_change0 typedef struct FWPM_FILTER_CHANGE0_ {
	// FWPM_CHANGE_TYPE changeType; GUID filterKey; UINT64 filterId; } FWPM_FILTER_CHANGE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_FILTER_CHANGE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_FILTER_CHANGE0
	{
		/// <summary>A FWPM_CHANGE_TYPE value that specifies the type of change notification to be dispatched.</summary>
		public FWPM_CHANGE_TYPE changeType;

		/// <summary>GUID of the filter that changed.</summary>
		public Guid filterKey;

		/// <summary>LUID of the filter that changed.</summary>
		public ulong filterId;
	}

	/// <summary>The <c>FWPM_FILTER_CONDITION0</c> structure expresses a filter condition that must be true for the action to be taken.</summary>
	/// <remarks>
	/// <para>Field GUIDs are only unique within a layer, so both the field GUID and the layer GUID are required to uniquely identify a field.</para>
	/// <para>The data type of FWP_MATCH_TYPE for detailed compatibility rules.</para>
	/// <para>
	/// <c>FWPM_FILTER_CONDITION0</c> is a specific implementation of FWPM_FILTER_CONDITION. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C++ example shows how to initialize and add conditions to a filter.</para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include &lt;fwpmu.h&gt; #include &lt;stdio.h&gt; #pragma comment(lib, "Fwpuclnt.lib") // Some application to use for filter testing. #define FILE0_PATH L"C:\\Program Files\\AppDirectory\\SomeApplication.exe" void main() { FWP_BYTE_BLOB *fwpApplicationByteBlob; FWPM_FILTER0 fwpFilter; FWPM_FILTER_CONDITION0 fwpConditions[4]; int conCount = 0; DWORD result = ERROR_SUCCESS; fwpApplicationByteBlob = (FWP_BYTE_BLOB*) malloc(sizeof(FWP_BYTE_BLOB)); printf("Retrieving application identifier for filter testing.\n"); result = FwpmGetAppIdFromFileName0(FILE0_PATH, &amp;fwpApplicationByteBlob); if (result != ERROR_SUCCESS) { printf("FwpmGetAppIdFromFileName failed (%d).\n", result); return; } // Application identifier filter condition. fwpConditions[conCount].fieldKey = FWPM_CONDITION_ALE_APP_ID; fwpConditions[conCount].matchType = FWP_MATCH_EQUAL; fwpConditions[conCount].conditionValue.type = FWP_BYTE_BLOB_TYPE; fwpConditions[conCount].conditionValue.byteBlob = fwpApplicationByteBlob; ++conCount; // TCP protocol filter condition fwpConditions[conCount].fieldKey = FWPM_CONDITION_IP_PROTOCOL; fwpConditions[conCount].matchType = FWP_MATCH_EQUAL; fwpConditions[conCount].conditionValue.type = FWP_UINT8; fwpConditions[conCount].conditionValue.uint8 = IPPROTO_TCP; ++conCount; // Add conditions and condition count to a filter. memset(&amp;fwpFilter, 0, sizeof(FWPM_FILTER0)); fwpFilter.numFilterConditions = conCount; if (conCount &gt; 0) fwpFilter.filterCondition = fwpConditions; // Finish initializing filter... return; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_filter_condition0 typedef struct
	// FWPM_FILTER_CONDITION0_ { GUID fieldKey; FWP_MATCH_TYPE matchType; FWP_CONDITION_VALUE0 conditionValue; } FWPM_FILTER_CONDITION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_FILTER_CONDITION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_FILTER_CONDITION0
	{
		/// <summary>GUID of the field to be tested.</summary>
		public Guid fieldKey;

		/// <summary>A FWP_MATCH_TYPE value that specifies the type of match to be performed.</summary>
		public FWP_MATCH_TYPE matchType;

		/// <summary>A FWP_CONDITION_VALUE0 structure that contains the value to match the field against.</summary>
		public FWP_CONDITION_VALUE0 conditionValue;
	}

	/// <summary>The <c>FWPM_FILTER_ENUM_TEMPLATE0</c> structure is used for enumerating filters.</summary>
	/// <remarks>
	/// <c>FWPM_FILTER_ENUM_TEMPLATE0</c> is a specific implementation of FWPM_FILTER_ENUM_TEMPLATE. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_filter_enum_template0 typedef struct
	// FWPM_FILTER_ENUM_TEMPLATE0_ { GUID *providerKey; GUID layerKey; FWP_FILTER_ENUM_TYPE enumType; UINT32 flags;
	// FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0 *providerContextTemplate; UINT32 numFilterConditions; FWPM_FILTER_CONDITION0 *filterCondition;
	// UINT32 actionMask; GUID *calloutKey; } FWPM_FILTER_ENUM_TEMPLATE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_FILTER_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_FILTER_ENUM_TEMPLATE0
	{
		/// <summary>Uniquely identifies the provider associated with this filter.</summary>
		public GuidPtr providerKey;

		/// <summary>Layer whose fields are to be enumerated.</summary>
		public Guid layerKey;

		/// <summary>A FWP_FILTER_ENUM_TYPE value that determines how the filter conditions are interpreted.</summary>
		public FWP_FILTER_ENUM_TYPE enumType;

		/// <summary>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWP_FILTER_ENUM_FLAG_BEST_TERMINATING_MATCH</c></term>
		/// <term>Only return the terminating filter with the highest weight.</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_FILTER_ENUM_FLAG_SORTED</c></term>
		/// <term>Return all matching filters sorted by weight (highest to lowest).</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_FILTER_ENUM_FLAG_BOOTTIME_ONLY</c></term>
		/// <term>Return only boot-time filters.</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_FILTER_ENUM_FLAG_INCLUDE_BOOTTIME</c></term>
		/// <term>Include boot-time filters; ignored if the <c>FWP_FILTER_ENUM_FLAG_BOOTTIME_ONLY</c> flag is set.</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_FILTER_ENUM_FLAG_INCLUDE_DISABLED</c></term>
		/// <term>Include disabled filters; ignored if the <c>FWP_FILTER_ENUM_FLAG_BOOTTIME_ONLY</c> flag is set.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWP_FILTER_ENUM_FLAG flags;

		/// <summary>
		/// A <see cref="FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0"/> structure that is used to limit the number of filters enumerated. If non-
		/// <c>NULL</c>, only enumerate filters whose provider context matches the template.
		/// </summary>
		public IntPtr providerContextTemplate;

		/// <summary>Number of filter conditions. If zero, then all filters match.</summary>
		public uint numFilterConditions;

		/// <summary>
		/// An array of FWPM_FILTER_CONDITION0 structures that contain distinct filter conditions (duplicated filter conditions will generate
		/// an error).
		/// </summary>
		public IntPtr filterCondition;

		/// <summary>
		/// <para>Only filters whose action type contains at least one of the bits in <c>actionMask</c> will be returned.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0xFFFFFFFF</term>
		/// <term>Ignore the filter's action type when enumerating.</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_ACTION_FLAG_CALLOUT</c></term>
		/// <term>Enumerate callouts only.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWP_ACTION_TYPE actionMask;

		/// <summary>Uniquely identifies the callout.</summary>
		public GuidPtr calloutKey;
	}

	/// <summary>The <c>FWPM_FILTER_SUBSCRIPTION0</c> structure is used to subscribe for change notifications.</summary>
	/// <remarks>
	/// <para>Notifications are only dispatched for filters that match the template.</para>
	/// <para>If the template is <c>NULL</c>, it matches all filters.</para>
	/// <para>
	/// <c>FWPM_FILTER_SUBSCRIPTION0</c> is a specific implementation of FWPM_FILTER_SUBSCRIPTION. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_filter_subscription0 typedef struct
	// FWPM_FILTER_SUBSCRIPTION0_ { FWPM_FILTER_ENUM_TEMPLATE0 *enumTemplate; UINT32 flags; GUID sessionKey; } FWPM_FILTER_SUBSCRIPTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_FILTER_SUBSCRIPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_FILTER_SUBSCRIPTION0
	{
		/// <summary>A FWPM_FILTER_ENUM_TEMPLATE0 structure used to limit the subscription.</summary>
		public IntPtr enumTemplate;

		/// <summary>
		/// <para>The notification type(s) received by the subscription.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_ADD</c></term>
		/// <term>Subscribe to filter add notifications.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_DELETE</c></term>
		/// <term>Subscribe to filter delete notifications.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_SUBSCRIPTION_FLAG flags;

		/// <summary>Uniquely identifies this session.</summary>
		public Guid sessionKey;
	}

	/// <summary>The <c>FWPM_FILTER0</c> structure stores the state associated with a filter.</summary>
	/// <remarks>
	/// <para>The first ten members of this structure contain information supplied when adding objects.</para>
	/// <para>The last members, <c>filterId</c> and <c>effectiveWeight</c>, provides additional information when getting/enumerating objects.</para>
	/// <para>
	/// <c>FWPM_FILTER0</c> is a specific implementation of FWPM_FILTER. See WFP Version-Independent Names and Targeting Specific Versions of
	/// Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_filter0 typedef struct FWPM_FILTER0_ { GUID filterKey;
	// FWPM_DISPLAY_DATA0 displayData; UINT32 flags; GUID *providerKey; FWP_BYTE_BLOB providerData; GUID layerKey; GUID subLayerKey;
	// FWP_VALUE0 weight; UINT32 numFilterConditions; FWPM_FILTER_CONDITION0 *filterCondition; FWPM_ACTION0 action; union { UINT64
	// rawContext; GUID providerContextKey; }; GUID *reserved; UINT64 filterId; FWP_VALUE0 effectiveWeight; } FWPM_FILTER0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_FILTER0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_FILTER0
	{
		/// <summary>
		/// <para>Uniquely identifies the session.</para>
		/// <para>If the GUID is initialized to zero in the call to FwpmFilterAdd0, the Base Filtering Engine (BFE) will generate one.</para>
		/// </summary>
		public Guid filterKey;

		/// <summary>
		/// A FWPM_DISPLAY_DATA0 structure that contains human-readable annotations associated with the filter. The <c>name</c> member of the
		/// <c>FWPM_DISPLAY_DATA0</c> structure is required.
		/// </summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Filter flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_FILTER_FLAG_NONE</c></term>
		/// <term>Default.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_FILTER_FLAG_PERSISTENT</c></term>
		/// <term>Filter is persistent, that is, it survives across BFE stop/start.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_FILTER_FLAG_BOOTTIME</c></term>
		/// <term>Filter is enforced at boot-time, even before BFE starts.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_FILTER_FLAG_HAS_PROVIDER_CONTEXT</c></term>
		/// <term>Filter references a provider context.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_FILTER_FLAG_CLEAR_ACTION_RIGHT</c></term>
		/// <term>Clear filter action right.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_FILTER_FLAG_PERMIT_IF_CALLOUT_UNREGISTERED</c></term>
		/// <term>If the callout is not registered, the filter is treated as a permit filter.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_FILTER_FLAG_DISABLED</c></term>
		/// <term>
		/// Filter is disabled. A provider's filters are disabled when the BFE starts if the provider has no associated Windows service name,
		/// or if the associated service is not set to auto-start.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_FILTER_FLAG_INDEXED</c></term>
		/// <term>Filter is indexed to help enable faster lookup during classification.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_FILTER_FLAG flags;

		/// <summary>
		/// Optional GUID of the policy provider that manages this filter. See Built-in Provider Identifiers for a list of predefined policy providers.
		/// </summary>
		public GuidPtr providerKey;

		/// <summary>
		/// A FWP_BYTE_BLOB structure that contains optional provider-specific data used by providers to store additional context information
		/// with the object.
		/// </summary>
		public FWP_BYTE_BLOB providerData;

		/// <summary>GUID of the layer where the filter resides. See Filtering Layer Identifiers for a list of possible values.</summary>
		public Guid layerKey;

		/// <summary>
		/// <para>GUID of the sub-layer where the filter resides. See Filtering Sub-Layer Identifiers for a list of built-in sub-layers.</para>
		/// <para>If this is set to IID_NULL, the filter is added to the default sublayer.</para>
		/// </summary>
		public Guid subLayerKey;

		/// <summary>
		/// <para>A FWP_VALUE0 structure that specifies the weight of the filter. Possible type values for <c>weight</c> are as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term><c>weight</c> type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWP_UINT64</c></term>
		/// <term>BFE will use the supplied value as the filter's weight.</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_UINT8</c> 0–15</term>
		/// <term>
		/// BFE will use the supplied value as a weight range index and will compute the filter's weight in that range. See Filter Weight
		/// Assignment for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FWP_EMPTY</c></term>
		/// <term>BFE will automatically assign a weight based on the filter conditions.</term>
		/// </item>
		/// </list>
		/// <para>See Filter Weight Identifiers for built-in constants that may be used to compute the filter weight.</para>
		/// </summary>
		public FWP_VALUE0 weight;

		/// <summary>Number of filter conditions.</summary>
		public uint numFilterConditions;

		/// <summary>
		/// <para>
		/// Array of FWPM_FILTER_CONDITION0 structures that contain all the filtering conditions. All must be true for the action to be
		/// performed. In other words, the conditions are evaluated using the AND operator. If no conditions are specified, the action is
		/// always performed.
		/// </para>
		/// <para>
		/// <c>Note</c> In Windows 7 and Windows Server 2008 R2, consecutive conditions with the same fieldKey will be evaluated using the OR operator.
		/// </para>
		/// </summary>
		public IntPtr filterCondition;

		/// <summary>
		/// <para>
		/// Array of FWPM_FILTER_CONDITION0 structures that contain all the filtering conditions. All must be true for the action to be
		/// performed. In other words, the conditions are evaluated using the AND operator. If no conditions are specified, the action is
		/// always performed.
		/// </para>
		/// <para>
		/// <c>Note</c> In Windows 7 and Windows Server 2008 R2, consecutive conditions with the same fieldKey will be evaluated using the OR operator.
		/// </para>
		/// </summary>
		public IEnumerable<FWPM_FILTER_CONDITION0> FilterConditions => filterCondition.ToIEnum<FWPM_FILTER_CONDITION0>((int)numFilterConditions);

		/// <summary>A FWPM_ACTION0 structure that specifies the action to be performed if all the filter conditions are true.</summary>
		public FWPM_ACTION0 action;

		/// <summary>
		/// <para>
		/// Available when the filter does not have provider context information, that is, <c>flags</c> does not contain
		/// <c>FWPM_FILTER_FLAG_HAS_PROVIDER_CONTEXT</c>. See Filter Context Identifiers for a list of built-in possible values.
		/// </para>
		/// <para>
		/// The <c>rawContext</c> is placed 'as is' in the <c>context</c> member of the corresponding <c>FWPS_FILTER0</c> structure, which is
		/// documented in the WDK.
		/// </para>
		/// </summary>
		public ulong rawContext
		{
			get => BitConverter.ToUInt64(providerContextKey.ToByteArray(), 0);
			set { var bytes = BitConverter.GetBytes(value); Array.Resize(ref bytes, 16); providerContextKey = new Guid(bytes); }
		}

		/// <summary>
		/// <para>
		/// Available when the filter has provider context information, that is, <c>flags</c> contains
		/// <c>FWPM_FILTER_FLAG_HAS_PROVIDER_CONTEXT</c>. See Built-in Provider Context Identifiers for a list of predefined policy provider contexts.
		/// </para>
		/// <para>
		/// The LUID of the provider context specified by the <c>providerContextKey</c> is used to fill in the <c>context</c> member of the
		/// corresponding <c>FWPS_FILTER0</c> structure, which is documented in the WDK.
		/// </para>
		/// </summary>
		public Guid providerContextKey;

		/// <summary>Reserved for system use.</summary>
		public GuidPtr reserved;

		/// <summary>
		/// <see cref="LUID"/> identifying the filter. This is also the LUID of the corresponding <c>FWPS_FILTER0</c> structure, which is documented in the WDK.
		/// </summary>
		public LUID filterId;

		/// <summary>An FWP_VALUE0 structure that contains the weight assigned to <c>FWPS_FILTER0</c>, which is documented in the WDK.</summary>
		public FWP_VALUE0 effectiveWeight;
	}

	/// <summary>The <c>FWPM_LAYER_ENUM_TEMPLATE0</c> structure is used for enumerating layers.</summary>
	/// <remarks>
	/// <para>Currently, there is no way to limit the enumeration — all layers are returned.</para>
	/// <para>
	/// <c>FWPM_LAYER_ENUM_TEMPLATE0</c> is a specific implementation of FWPM_LAYER_ENUM_TEMPLATE. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_layer_enum_template0 typedef struct
	// FWPM_LAYER_ENUM_TEMPLATE0_ { UINT64 reserved; } FWPM_LAYER_ENUM_TEMPLATE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_LAYER_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_LAYER_ENUM_TEMPLATE0
	{
		/// <summary>Reserved for system use.</summary>
		public ulong reserved;
	}

	/// <summary>The <c>FWPM_LAYER_STATISTICS0</c> structure stores statistics related to a layer.</summary>
	/// <remarks>
	/// <c>FWPM_LAYER_STATISTICS0</c> is a specific implementation of FWPM_LAYER_STATISTICS. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_layer_statistics0 typedef struct
	// FWPM_LAYER_STATISTICS0_ { GUID layerId; UINT32 classifyPermitCount; UINT32 classifyBlockCount; UINT32 classifyVetoCount; UINT32
	// numCacheEntries; } FWPM_LAYER_STATISTICS0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_LAYER_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_LAYER_STATISTICS0
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>Identifier of the layer.</para>
		/// </summary>
		public Guid layerId;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of permitted connections.</para>
		/// </summary>
		public uint classifyPermitCount;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of blocked connections.</para>
		/// </summary>
		public uint classifyBlockCount;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of vetoed connections.</para>
		/// </summary>
		public uint classifyVetoCount;

		/// <summary>Type: <c>UINT32</c></summary>
		public uint numCacheEntries;
	}

	/// <summary>The <c>FWPM_LAYER0</c> structure contains schema information for a layer.</summary>
	/// <remarks>
	/// <c>FWPM_LAYER0</c> is a specific implementation of FWPM_LAYER. See WFP Version-Independent Names and Targeting Specific Versions of
	/// Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_layer0 typedef struct FWPM_LAYER0_ { GUID layerKey;
	// FWPM_DISPLAY_DATA0 displayData; UINT32 flags; UINT32 numFields; FWPM_FIELD0 *field; GUID defaultSubLayerKey; UINT16 layerId; } FWPM_LAYER0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_LAYER0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_LAYER0
	{
		/// <summary>Uniquely identifies the layer.</summary>
		public Guid layerKey;

		/// <summary>Allows layers to be annotated in a human-readable form. The FWPM_DISPLAY_DATA0 structure is not <c>NULL</c>.</summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_LAYER_FLAG_KERNEL</c></term>
		/// <term>Layer classified in kernel-mode.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_LAYER_FLAG_BUILTIN</c></term>
		/// <term>Layer built-in. Cannot be deleted.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_LAYER_FLAG_CLASSIFY_MOSTLY</c></term>
		/// <term>Layer optimized for classification rather than enumeration.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_LAYER_FLAG_BUFFERED</c></term>
		/// <term>Layer is buffered.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_LAYER_FLAG flags;

		/// <summary>Number of fields in the layer.</summary>
		public uint numFields;

		/// <summary>
		/// <para>Schema information for the layer's fields.</para>
		/// <para>See <see cref="FWPM_FIELD0"/> for more information.</para>
		/// </summary>
		public IntPtr field;

		/// <summary>
		/// <para>Schema information for the layer's fields.</para>
		/// <para>See <see cref="FWPM_FIELD0"/> for more information.</para>
		/// </summary>
		public IEnumerable<FWPM_FIELD0> Fields => @field.ToIEnum<FWPM_FIELD0>((int)numFields);

		/// <summary>Sublayer used when a filter is added with a null sublayer.</summary>
		public Guid defaultSubLayerKey;

		/// <summary>LUID that identifies this layer.</summary>
		public ushort layerId;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_CAPABILITY_ALLOW0</c> structure contains information about network traffic allowed in relation to an app
	/// container network capability.. The specified app container network capability grants access to network resources, and the specified
	/// filter identifier enforces allowing access.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_capability_allow0 typedef struct
	// FWPM_NET_EVENT_CAPABILITY_ALLOW0_ { FWPM_APPC_NETWORK_CAPABILITY_TYPE networkCapabilityId; UINT64 filterId; BOOL isLoopback; } FWPM_NET_EVENT_CAPABILITY_ALLOW0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_CAPABILITY_ALLOW0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_CAPABILITY_ALLOW0
	{
		/// <summary>
		/// <para>Type: <c>FWPM_APPC_NETWORK_CAPABILITY_TYPE</c></para>
		/// <para>The specific app container network capability allowing this traffic.</para>
		/// </summary>
		public FWPM_APPC_NETWORK_CAPABILITY_TYPE networkCapabilityId;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>A LUID identifying the WFP filter enforcing the allowed access intended by the capability in <c>networkCapabilityId</c>.</para>
		/// </summary>
		public ulong filterId;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the packet originated from (or was heading to) the loopback adapter; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool isLoopback;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_CAPABILITY_DROP0</c> structure contains information about network traffic dropped in relation to an app
	/// container network capability. Traffic is dropped due to the specified app container network capability and enforced by the specified
	/// filter identifier.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_capability_drop0 typedef struct
	// FWPM_NET_EVENT_CAPABILITY_DROP0_ { FWPM_APPC_NETWORK_CAPABILITY_TYPE networkCapabilityId; UINT64 filterId; BOOL isLoopback; } FWPM_NET_EVENT_CAPABILITY_DROP0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_CAPABILITY_DROP0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_CAPABILITY_DROP0
	{
		/// <summary>
		/// <para>Type: <c>FWPM_APPC_NETWORK_CAPABILITY_TYPE</c></para>
		/// <para>The specific app container network capability which was missing, therefore causing this traffic to be denied.</para>
		/// </summary>
		public FWPM_APPC_NETWORK_CAPABILITY_TYPE networkCapabilityId;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>A LUID identifying the WFP filter where the traffic drop occurred.</para>
		/// </summary>
		public ulong filterId;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the packet originated from (or was heading to) the loopback adapter; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool isLoopback;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_CLASSIFY_ALLOW0</c> structure contains information that describes allowed traffic as enforced by the WFP
	/// classify engine.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_classify_allow0 typedef struct
	// FWPM_NET_EVENT_CLASSIFY_ALLOW0 { UINT64 filterId; UINT16 layerId; UINT32 reauthReason; UINT32 originalProfile; UINT32 currentProfile;
	// UINT32 msFwpDirection; BOOL isLoopback; } FWPM_NET_EVENT_CLASSIFY_ALLOW0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_CLASSIFY_ALLOW0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_CLASSIFY_ALLOW0
	{
		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>A LUID identifying the WFP filter allowing this traffic.</para>
		/// </summary>
		public ulong filterId;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The identifier of the WFP filtering layer where the filter specified in <c>filterId</c> is stored. For more information, see
		/// Filtering Layer Identifiers.
		/// </para>
		/// </summary>
		public ushort layerId;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The reason for reauthorizing a previously authorized connection.</para>
		/// </summary>
		public uint reauthReason;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The identifier of the profile to which the packet was received (or from which the packet was sent).</para>
		/// </summary>
		public uint originalProfile;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The identifier of the profile where the packet was when the failure occurred.</para>
		/// </summary>
		public uint currentProfile;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Indicates the direction of the packet transmission. Possible values are <c>FWP_DIRECTION_INBOUND</c> or <c>FWP_DIRECTION_OUTBOUND</c>.</para>
		/// </summary>
		public FWP_DIRECTION msFwpDirection;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If true, indicates that the packet originated from (or was heading to) the loopback adapter; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool isLoopback;
	}

	/// <summary>The <c>FWPM_NET_EVENT_CLASSIFY_DROP_MAC0</c> structure contains information that describes a MAC layer drop failure.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_classify_drop_mac0 typedef struct
	// FWPM_NET_EVENT_CLASSIFY_DROP_MAC0_ { FWP_BYTE_ARRAY6 localMacAddr; FWP_BYTE_ARRAY6 remoteMacAddr; UINT32 mediaType; UINT32 ifType;
	// UINT16 etherType; UINT32 ndisPortNumber; UINT32 reserved; UINT16 vlanTag; UINT64 ifLuid; UINT64 filterId; UINT16 layerId; UINT32
	// reauthReason; UINT32 originalProfile; UINT32 currentProfile; UINT32 msFwpDirection; BOOL isLoopback; FWP_BYTE_BLOB vSwitchId; UINT32
	// vSwitchSourcePort; UINT32 vSwitchDestinationPort; } FWPM_NET_EVENT_CLASSIFY_DROP_MAC0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_CLASSIFY_DROP_MAC0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_CLASSIFY_DROP_MAC0
	{
		/// <summary>The local MAC address.</summary>
		public FWP_BYTE_ARRAY6 localMacAddr;

		/// <summary>The remote MAC address.</summary>
		public FWP_BYTE_ARRAY6 remoteMacAddr;

		/// <summary>The media type of the NDIS port.</summary>
		public uint mediaType;

		/// <summary>
		/// The interface type, as defined by the Internet Assigned Names Authority (IANA). Possible values for the interface type are listed
		/// in the Ipifcons.h include file.
		/// </summary>
		public uint ifType;

		/// <summary>
		/// Indicates which protocol is encapsulated in the frame data. The values used for this field comes from the Ethernet V2
		/// specification's numbering space.
		/// </summary>
		public ushort etherType;

		/// <summary>The number assigned to the NDIS port.</summary>
		public uint ndisPortNumber;

		/// <summary>Reserved for internal use.</summary>
		public uint reserved;

		/// <summary>The VLAN (802.1p/q) VID, CFI, and Priority fields marshaled into a 16-bit value. (See VLAN_TAG in netiodef.h.)</summary>
		public ushort vlanTag;

		/// <summary>The interface LUID corresponding to the network interface with which this packet is associated.</summary>
		public ulong ifLuid;

		/// <summary>The LUID identifying the filter where the failure occurred.</summary>
		public ulong filterId;

		/// <summary>The identifier of the filtering layer where the failure occurred. For more information, see Filtering Layer Identifiers</summary>
		public ushort layerId;

		/// <summary>Indicates the reason for reauthorizing a previously authorized connection.</summary>
		public uint reauthReason;

		/// <summary>Indicates the identifier of the profile to which the packet was received (or from which the packet was sent).</summary>
		public uint originalProfile;

		/// <summary>Indicates the identifier of the profile where the packet was when the failure occurred.</summary>
		public uint currentProfile;

		/// <summary>
		/// <para>Indicates the direction of the packet transmission.</para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWP_DIRECTION_IN</c></term>
		/// <term>The packet is inbound. 0x00003900L</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_DIRECTION_OUT</c></term>
		/// <term>The packet is outbound. 0x00003901L</term>
		/// </item>
		/// <item>
		/// <term><c>FWP_DIRECTION_FORWARD</c></term>
		/// <term>The packet is traversing an interface which it must pass through on the way to its destination. 0x00003902L</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWP_DIRECTION msFwpDirection;

		/// <summary>Indicates whether the packet originated from (or was heading to) the loopback adapter.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool isLoopback;

		/// <summary>GUID identifier of a vSwitch.</summary>
		public FWP_BYTE_BLOB vSwitchId;

		/// <summary>Transient source port of a packet within the vSwitch.</summary>
		public uint vSwitchSourcePort;

		/// <summary>Transient destination port of a packet within the vSwitch.</summary>
		public uint vSwitchDestinationPort;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_CLASSIFY_DROP0</c> structure contains information that describes a layer drop failure.
	/// FWPM_NET_EVENT_CLASSIFY_DROP1 is available. For Windows 8, FWPM_NET_EVENT_CLASSIFY_DROP2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_classify_drop0 typedef struct
	// FWPM_NET_EVENT_CLASSIFY_DROP0_ { UINT64 filterId; UINT16 layerId; } FWPM_NET_EVENT_CLASSIFY_DROP0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_CLASSIFY_DROP0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_CLASSIFY_DROP0
	{
		/// <summary>A LUID identifying the filter where the failure occurred.</summary>
		public ulong filterId;

		/// <summary>
		/// Indicates the identifier of the filtering layer where the failure occurred. For more information, see Filtering Layer Identifiers.
		/// </summary>
		public ushort layerId;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_CLASSIFY_DROP1</c> structure contains information that describes a layer drop failure.
	/// FWPM_NET_EVENT_CLASSIFY_DROP0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_classify_drop1 typedef struct
	// FWPM_NET_EVENT_CLASSIFY_DROP1_ { UINT64 filterId; UINT16 layerId; UINT32 reauthReason; UINT32 originalProfile; UINT32 currentProfile;
	// UINT32 msFwpDirection; BOOL isLoopback; } FWPM_NET_EVENT_CLASSIFY_DROP1;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_CLASSIFY_DROP1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_CLASSIFY_DROP1
	{
		/// <summary>A LUID identifying the filter where the failure occurred.</summary>
		public ulong filterId;

		/// <summary>
		/// Indicates the identifier of the filtering layer where the failure occurred. For more information, see Filtering Layer Identifiers.
		/// </summary>
		public ushort layerId;

		/// <summary>Indicates the reason for reauthorizing a previously authorized connection.</summary>
		public uint reauthReason;

		/// <summary>Indicates the identifier of the profile to which the packet was received (or from which the packet was sent).</summary>
		public uint originalProfile;

		/// <summary>Indicates the identifier of the profile where the packet was when the failure occurred.</summary>
		public uint currentProfile;

		/// <summary>
		/// <para>Indicates the direction of the packet transmission.</para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWP_DIRECTION_IN 0x00003900L</term>
		/// <term>The packet is inbound.</term>
		/// </item>
		/// <item>
		/// <term>FWP_DIRECTION_OUT 0x00003901L</term>
		/// <term>The packet is outbound.</term>
		/// </item>
		/// <item>
		/// <term>FWP_DIRECTION_FORWARD 0x00003902L</term>
		/// <term>The packet is traversing an interface which it must pass through on the way to its destination.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWP_DIRECTION msFwpDirection;

		/// <summary>Indicates whether the packet originated from (or was heading to) the loopback adapter.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool isLoopback;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_CLASSIFY_DROP2</c> structure contains information that describes a layer drop failure.
	/// FWPM_NET_EVENT_CLASSIFY_DROP1 is available. For Windows Vista, FWPM_NET_EVENT_CLASSIFY_DROP0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_classify_drop2 typedef struct
	// FWPM_NET_EVENT_CLASSIFY_DROP2_ { UINT64 filterId; UINT16 layerId; UINT32 reauthReason; UINT32 originalProfile; UINT32 currentProfile;
	// UINT32 msFwpDirection; BOOL isLoopback; FWP_BYTE_BLOB vSwitchId; UINT32 vSwitchSourcePort; UINT32 vSwitchDestinationPort; } FWPM_NET_EVENT_CLASSIFY_DROP2;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_CLASSIFY_DROP2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_CLASSIFY_DROP2
	{
		/// <summary>A LUID identifying the filter where the failure occurred.</summary>
		public ulong filterId;

		/// <summary>
		/// Indicates the identifier of the filtering layer where the failure occurred. For more information, see Filtering Layer Identifiers.
		/// </summary>
		public ushort layerId;

		/// <summary>Indicates the reason for reauthorizing a previously authorized connection.</summary>
		public uint reauthReason;

		/// <summary>Indicates the identifier of the profile to which the packet was received (or from which the packet was sent).</summary>
		public uint originalProfile;

		/// <summary>Indicates the identifier of the profile where the packet was when the failure occurred.</summary>
		public uint currentProfile;

		/// <summary>
		/// <para>Indicates the direction of the packet transmission.</para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWP_DIRECTION_IN 0x00003900L</term>
		/// <term>The packet is inbound.</term>
		/// </item>
		/// <item>
		/// <term>FWP_DIRECTION_OUT 0x00003901L</term>
		/// <term>The packet is outbound.</term>
		/// </item>
		/// <item>
		/// <term>FWP_DIRECTION_FORWARD 0x00003902L</term>
		/// <term>The packet is traversing an interface which it must pass through on the way to its destination.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWP_DIRECTION msFwpDirection;

		/// <summary>Indicates whether the packet originated from (or was heading to) the loopback adapter.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool isLoopback;

		/// <summary>GUID identifier of a vSwitch.</summary>
		public FWP_BYTE_BLOB vSwitchId;

		/// <summary>Transient source port of a packet within the vSwitch.</summary>
		public uint vSwitchSourcePort;

		/// <summary>Transient destination port of a packet within the vSwitch.</summary>
		public uint vSwitchDestinationPort;
	}

	/// <summary>The <c>FWPM_NET_EVENT_ENUM_TEMPLATE0</c> structure is used for enumerating net events.</summary>
	/// <remarks>
	/// <c>FWPM_NET_EVENT_ENUM_TEMPLATE0</c> is a specific implementation of FWPM_NET_EVENT_ENUM_TEMPLATE. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_enum_template0 typedef struct
	// FWPM_NET_EVENT_ENUM_TEMPLATE0_ { FILETIME startTime; FILETIME endTime; UINT32 numFilterConditions; FWPM_FILTER_CONDITION0
	// *filterCondition; } FWPM_NET_EVENT_ENUM_TEMPLATE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_ENUM_TEMPLATE0
	{
		/// <summary>A FILETIME structure that specifies the start time of the period to be checked for net events.</summary>
		public FILETIME startTime;

		/// <summary>
		/// A FILETIME structure that specifies the end time of the period to be checked for net events. It must be greater than or equal to <c>startTime</c>.
		/// </summary>
		public FILETIME endTime;

		/// <summary>
		/// Indicates the number of filter conditions in the <c>filterCondition</c> member. If this field is 0, all events will be returned.
		/// </summary>
		public uint numFilterConditions;

		/// <summary>
		/// <para>
		/// An array of <see cref="FWPM_FILTER_CONDITION0"/> structures that contain distinct filter conditions (duplicated filter conditions
		/// will generate an error). All conditions must be true for the action to be performed. In other words, the conditions are AND'ed
		/// together. If no conditions are specified, the action is always performed.
		/// </para>
		/// <para>Supported filtering conditions.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_CONDITION_IP_PROTOCOL</c></term>
		/// <term>The IP protocol number, as specified in RFC 1700.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_CONDITION_IP_LOCAL_ADDRESS</c></term>
		/// <term>The local IP address.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_CONDITION_IP_REMOTE_ADDRESS</c></term>
		/// <term>The remote IP address.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_CONDITION_IP_LOCAL_PORT</c></term>
		/// <term>The local transport protocol port number. For ICMP, the message type.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_CONDITION_IP_REMOTE_PORT</c></term>
		/// <term>The remote transport protocol port number. For ICMP, the message code.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_CONDITION_SCOPE_ID</c></term>
		/// <term>The interface IPv6 scope identifier. Reserved for internal use.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_CONDITION_ALE_APP_ID</c></term>
		/// <term>The full path of the application.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_CONDITION_ALE_USER_ID</c></term>
		/// <term>The identification of the local user.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IntPtr filterCondition;
	}

	/// <summary>The <c>FWPM_NET_EVENT_HEADER0</c> structure contains information common to all events. FWPM_NET_EVENT_HEADER2 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_header0 typedef struct
	// FWPM_NET_EVENT_HEADER0_ { FILETIME timeStamp; UINT32 flags; FWP_IP_VERSION ipVersion; UINT8 ipProtocol; union { UINT32 localAddrV4;
	// FWP_BYTE_ARRAY16 localAddrV6; }; union { UINT32 remoteAddrV4; FWP_BYTE_ARRAY16 remoteAddrV6; }; UINT16 localPort; UINT16 remotePort;
	// UINT32 scopeId; FWP_BYTE_BLOB appId; SID *userId; } FWPM_NET_EVENT_HEADER0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_HEADER0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_HEADER0
	{
		/// <summary>A FILETIME structure that specifies the time the event occurred</summary>
		public FILETIME timeStamp;

		/// <summary>
		/// <para>Flags indicating which of the following members are set. Unused fields must be zero-initialized.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Net event flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_IP_PROTOCOL_SET</term>
		/// <term>The <c>ipProtocol</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_LOCAL_ADDR_SET</term>
		/// <term>
		/// Either the <c>localAddrV4</c> member or the <c>localAddrV6</c> member is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REMOTE_ADDR_SET</term>
		/// <term>
		/// Either the <c>remoteAddrV4</c> member of the <c>remoteAddrV6</c> field is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_LOCAL_PORT_SET</term>
		/// <term>The <c>localPort</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REMOTE_PORT_SET</term>
		/// <term>The <c>remotePort</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_APP_ID_SET</term>
		/// <term>The <c>appId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_USER_ID_SET</term>
		/// <term>The <c>userId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_SCOPE_ID_SET</term>
		/// <term>The <c>scopeId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</term>
		/// <term>The <c>ipVersion</c> member is set.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_NET_EVENT_FLAG flags;

		/// <summary>A FWP_IP_VERSION value that specifies the IP version being used.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// IP protocol specified as an IPPROTO value. See the socket reference topic for more information on possible protocol values.
		/// </summary>
		public byte ipProtocol;

		private FWP_BYTE_ARRAY_ADDR local;

		/// <summary>
		/// <para>Specifies an IPv4 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR localAddrV4 { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>A FWP_BYTE_ARRAY16 that contains an IPv6 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR localAddrV6 { get => local.addr6; set => local.addr6 = value; }

		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>
		/// <para>Specifies an IPv4 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR remoteAddrV4 { get => remote.addr; set => remote.addr = value; }

		/// <summary>
		/// <para>A FWP_BYTE_ARRAY16 that contains an IPv6 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR remoteAddrV6 { get => remote.addr6; set => remote.addr6 = value; }

		/// <summary>Specifies a local port.</summary>
		public ushort localPort;

		/// <summary>Specifies a remote port.</summary>
		public ushort remotePort;

		/// <summary>IPv6 scope ID.</summary>
		public uint scopeId;

		/// <summary>A FWP_BYTE_BLOB that contains the application ID of the local application associated with the event.</summary>
		public FWP_BYTE_BLOB appId;

		/// <summary>Contains a user ID that corresponds to the traffic.</summary>
		public PSID userId;
	}

	/// <summary>
	/// <para>The <c>FWPM_NET_EVENT_HEADER1</c> structure contains information common to all events. Reserved.</para>
	/// <para>FWPM_NET_EVENT_HEADER2 is available.</para>
	/// </summary>
	/// <remarks>
	/// <para>The unnamed struct specifies details related to Ethernet traffic. It's available when <c>addressFamily</c> is <c>FWP_AF_ETHER</c>.</para>
	/// <para>This structure is reserved for system use. FWPM_NET_EVENT_HEADER2 should be used in place of <c>FWPM_NET_EVENT_HEADER1</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_header1 typedef struct
	// FWPM_NET_EVENT_HEADER1_ { FILETIME timeStamp; UINT32 flags; FWP_IP_VERSION ipVersion; UINT8 ipProtocol; union { UINT32 localAddrV4;
	// FWP_BYTE_ARRAY16 localAddrV6; }; union { UINT32 remoteAddrV4; FWP_BYTE_ARRAY16 remoteAddrV6; }; UINT16 localPort; UINT16 remotePort;
	// UINT32 scopeId; FWP_BYTE_BLOB appId; SID *userId; union { struct { FWP_AF reserved1; union { struct { FWP_BYTE_ARRAY6 reserved2;
	// FWP_BYTE_ARRAY6 reserved3; UINT32 reserved4; UINT32 reserved5; UINT16 reserved6; UINT32 reserved7; UINT32 reserved8; UINT16 reserved9;
	// UINT64 reserved10; }; }; }; }; } FWPM_NET_EVENT_HEADER1;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_HEADER1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_HEADER1
	{
		/// <summary>A FILETIME structure that specifies the time the event occurred.</summary>
		public FILETIME timeStamp;

		/// <summary>
		/// <para>Flags indicating which of the following members are set. Unused fields must be zero-initialized.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Net event flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_IP_PROTOCOL_SET</term>
		/// <term>The <c>ipProtocol</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_LOCAL_ADDR_SET</term>
		/// <term>
		/// Either the <c>localAddrV4</c> member or the <c>localAddrV6</c> member is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REMOTE_ADDR_SET</term>
		/// <term>
		/// Either the <c>remoteAddrV4</c> member of the <c>remoteAddrV6</c> field is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_LOCAL_PORT_SET</term>
		/// <term>The <c>localPort</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REMOTE_PORT_SET</term>
		/// <term>The <c>remotePort</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_APP_ID_SET</term>
		/// <term>The <c>appId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_USER_ID_SET</term>
		/// <term>The <c>userId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_SCOPE_ID_SET</term>
		/// <term>The <c>scopeId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</term>
		/// <term>The <c>ipVersion</c> member is set.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_NET_EVENT_FLAG flags;

		/// <summary>An FWP_IP_VERSION value that specifies the IP version being used.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// IP protocol specified as an IPPROTO value. See the socket reference topic for more information on possible protocol values.
		/// </summary>
		public IPPROTO ipProtocol;

		private FWP_BYTE_ARRAY_ADDR local;

		/// <summary>
		/// <para>Specifies an IPv4 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR localAddrV4 { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>A FWP_BYTE_ARRAY16 that contains an IPv6 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR localAddrV6 { get => local.addr6; set => local.addr6 = value; }

		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>
		/// <para>Specifies an IPv4 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR remoteAddrV4 { get => remote.addr; set => remote.addr = value; }

		/// <summary>
		/// <para>A FWP_BYTE_ARRAY16 that contains an IPv6 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR remoteAddrV6 { get => remote.addr6; set => remote.addr6 = value; }

		/// <summary>Specifies a local port.</summary>
		public ushort localPort;

		/// <summary>Specifies a remote port.</summary>
		public ushort remotePort;

		/// <summary>IPv6 scope ID.</summary>
		public uint scopeId;

		/// <summary>An FWP_BYTE_BLOB that specifies the application ID of the local application associated with the event.</summary>
		public FWP_BYTE_BLOB appId;

		/// <summary>Contains a user ID that corresponds to the traffic.</summary>
		public PSID userId;

		/// <summary>
		/// <para>Specifies a superset of non-Internet protocols.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_NONE</c>.</para>
		/// </summary>
		public FWP_AF reserved1;

		private readonly uint pad1;

		/// <summary>A FWP_BYTE_ARRAY6 structure.</summary>
		public FWP_BYTE_ARRAY6 reserved2;

		/// <summary>A FWP_BYTE_ARRAY6 structure.</summary>
		public FWP_BYTE_ARRAY6 reserved3;

		/// <summary>A DL_ADDRESS_TYPE enumeration.</summary>
		public uint reserved4;

		/// <summary>A FWP_ETHER_ENCAP_METHOD enumeration.</summary>
		public uint reserved5;

		/// <summary>Indicates which protocol is encapsulated in the frame data.</summary>
		public ushort reserved6;

		/// <summary>The SNAP (IEEE 802.2) DSAP, SSAP, and Control fields marshaled into a 32-bit value.</summary>
		public uint reserved7;

		/// <summary>The SNAP (IEEE 802.2) Organizationally Unique Identifier (OUI) marshaled into a 32-bit value.</summary>
		public uint reserved8;

		/// <summary>The VLAN (802.1p/q) VID, CFI, and Priority bits marshaled into a 16-bit value.</summary>
		public ushort reserved9;

		private readonly uint pad2;

		/// <summary>The interface LUID corresponding to the network interface with which this packet is associated.</summary>
		public ulong reserved10;
	}

	/// <summary>The <c>FWPM_NET_EVENT_HEADER2</c> structure contains information common to all events. FWPM_NET_EVENT_HEADER0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_header2 typedef struct
	// FWPM_NET_EVENT_HEADER2_ { FILETIME timeStamp; UINT32 flags; FWP_IP_VERSION ipVersion; UINT8 ipProtocol; union { UINT32 localAddrV4;
	// FWP_BYTE_ARRAY16 localAddrV6; }; union { UINT32 remoteAddrV4; FWP_BYTE_ARRAY16 remoteAddrV6; }; UINT16 localPort; UINT16 remotePort;
	// UINT32 scopeId; FWP_BYTE_BLOB appId; SID *userId; FWP_AF addressFamily; SID *packageSid; } FWPM_NET_EVENT_HEADER2;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_HEADER2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_HEADER2
	{
		/// <summary>
		/// <para>Type: <c>FILETIME</c></para>
		/// <para>Time that the event occurred.</para>
		/// </summary>
		public FILETIME timeStamp;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Flags indicating which of the following members are set. Unused fields must be zero-initialized.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Net event flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_IP_PROTOCOL_SET</term>
		/// <term>The <c>ipProtocol</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_LOCAL_ADDR_SET</term>
		/// <term>
		/// Either the <c>localAddrV4</c> member or the <c>localAddrV6</c> member is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REMOTE_ADDR_SET</term>
		/// <term>
		/// Either the <c>remoteAddrV4</c> member of the <c>remoteAddrV6</c> field is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_LOCAL_PORT_SET</term>
		/// <term>The <c>localPort</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REMOTE_PORT_SET</term>
		/// <term>The <c>remotePort</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_APP_ID_SET</term>
		/// <term>The <c>appId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_USER_ID_SET</term>
		/// <term>The <c>userId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_SCOPE_ID_SET</term>
		/// <term>The <c>scopeId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</term>
		/// <term>The <c>ipVersion</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REAUTH_REASON_SET</term>
		/// <term>Indicates an existing connection was reauthorized.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_PACKAGE_ID_SET</term>
		/// <term>The <c>packageSid</c> member is set.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_NET_EVENT_FLAG flags;

		/// <summary>
		/// <para>Type: <c>FWP_IP_VERSION</c></para>
		/// <para>The IP version being used.</para>
		/// </summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>
		/// The IP protocol specified as an IPPROTO value. See the socket reference topic for more information on possible protocol values.
		/// </para>
		/// </summary>
		public IPPROTO ipProtocol;

		private FWP_BYTE_ARRAY_ADDR local;

		/// <summary>
		/// <para>Specifies an IPv4 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR localAddrV4 { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>A FWP_BYTE_ARRAY16 that contains an IPv6 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR localAddrV6 { get => local.addr6; set => local.addr6 = value; }

		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>
		/// <para>Specifies an IPv4 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR remoteAddrV4 { get => remote.addr; set => remote.addr = value; }

		/// <summary>
		/// <para>A FWP_BYTE_ARRAY16 that contains an IPv6 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR remoteAddrV6 { get => remote.addr6; set => remote.addr6 = value; }

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The local port.</para>
		/// </summary>
		public ushort localPort;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The remote port.</para>
		/// </summary>
		public ushort remotePort;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The IPv6 scope ID.</para>
		/// </summary>
		public uint scopeId;

		/// <summary>
		/// <para>Type: <c>FWP_BYTE_BLOB</c></para>
		/// <para>The application ID of the local application associated with the event.</para>
		/// </summary>
		public FWP_BYTE_BLOB appId;

		/// <summary>
		/// <para>Type: <c>SID</c>*</para>
		/// <para>The user ID corresponding to the traffic.</para>
		/// </summary>
		public PSID userId;

		/// <summary>
		/// <para>Type: <c>FWP_AF</c></para>
		/// <para>A superset of non-Internet protocols.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_NONE</c>.</para>
		/// </summary>
		public FWP_AF addressFamily;

		/// <summary>
		/// <para>Type: <c>SID</c>*</para>
		/// <para>
		/// The security identifier (SID) representing the package identifier (also referred to as the app container SID) intending to send
		/// or receive the network traffic.
		/// </para>
		/// </summary>
		public PSID packageSid;
	}

	/// <summary>The <c>FWPM_NET_EVENT_HEADER3</c> structure contains information common to all events. FWPM_NET_EVENT_HEADER0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_header3 typedef struct
	// FWPM_NET_EVENT_HEADER3_ { FILETIME timeStamp; UINT32 flags; FWP_IP_VERSION ipVersion; UINT8 ipProtocol; union { UINT32 localAddrV4;
	// FWP_BYTE_ARRAY16 localAddrV6; }; union { UINT32 remoteAddrV4; FWP_BYTE_ARRAY16 remoteAddrV6; }; UINT16 localPort; UINT16 remotePort;
	// UINT32 scopeId; FWP_BYTE_BLOB appId; SID *userId; FWP_AF addressFamily; SID *packageSid; wchar_t *enterpriseId; UINT64 policyFlags;
	// FWP_BYTE_BLOB effectiveName; } FWPM_NET_EVENT_HEADER3;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_HEADER3_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_HEADER3
	{
		/// <summary>Time that the event occurred.</summary>
		public FILETIME timeStamp;

		/// <summary>
		/// <para>Flags indicating which of the following members are set. Unused fields must be zero-initialized.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Net event flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_IP_PROTOCOL_SET</term>
		/// <term>The <c>ipProtocol</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_LOCAL_ADDR_SET</term>
		/// <term>
		/// Either the <c>localAddrV4</c> member or the <c>localAddrV6</c> member is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REMOTE_ADDR_SET</term>
		/// <term>
		/// Either the <c>remoteAddrV4</c> member of the <c>remoteAddrV6</c> field is set. If this flag is present,
		/// <c>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</c> must also be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_LOCAL_PORT_SET</term>
		/// <term>The <c>localPort</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REMOTE_PORT_SET</term>
		/// <term>The <c>remotePort</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_APP_ID_SET</term>
		/// <term>The <c>appId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_USER_ID_SET</term>
		/// <term>The <c>userId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_SCOPE_ID_SET</term>
		/// <term>The <c>scopeId</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_IP_VERSION_SET</term>
		/// <term>The <c>ipVersion</c> member is set.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_REAUTH_REASON_SET</term>
		/// <term>Indicates an existing connection was reauthorized.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_FLAG_PACKAGE_ID_SET</term>
		/// <term>The <c>packageSid</c> member is set.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_NET_EVENT_FLAG flags;

		/// <summary>The IP version being used.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// The IP protocol specified as an IPPROTO value. See the socket reference topic for more information on possible protocol values.
		/// </summary>
		public IPPROTO ipProtocol;

		private FWP_BYTE_ARRAY_ADDR local;

		/// <summary>
		/// <para>Specifies an IPv4 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR localAddrV4 { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>A FWP_BYTE_ARRAY16 that contains an IPv6 local address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR localAddrV6 { get => local.addr6; set => local.addr6 = value; }

		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>
		/// <para>Specifies an IPv4 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR remoteAddrV4 { get => remote.addr; set => remote.addr = value; }

		/// <summary>
		/// <para>A FWP_BYTE_ARRAY16 that contains an IPv6 remote address.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR remoteAddrV6 { get => remote.addr6; set => remote.addr6 = value; }

		/// <summary>The local port.</summary>
		public ushort localPort;

		/// <summary>The remote port.</summary>
		public ushort remotePort;

		/// <summary>The IPv6 scope ID.</summary>
		public uint scopeId;

		/// <summary>The application ID of the local application associated with the event.</summary>
		public FWP_BYTE_BLOB appId;

		/// <summary>The user ID corresponding to the traffic.</summary>
		public PSID userId;

		/// <summary>
		/// <para>A superset of non-Internet protocols.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_NONE</c>.</para>
		/// </summary>
		public FWP_AF addressFamily;

		/// <summary>
		/// The security identifier (SID) representing the package identifier (also referred to as the app container SID) intending to send
		/// or receive the network traffic.
		/// </summary>
		public PSID packageSid;

		/// <summary>The enterprise identifier for use with enterprise data protection (EDP).</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string enterpriseId;

		/// <summary>The policy flags for EDP.</summary>
		public ulong policyFlags;

		/// <summary>The EDP remote server used for name-based policy.</summary>
		public FWP_BYTE_BLOB effectiveName;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_IKEEXT_EM_FAILURE0</c> structure contains information that describes an IKE Extended Mode (EM) failure.
	/// FWPM_NET_EVENT_IKEEXT_EM_FAILURE1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_ikeext_em_failure0 typedef struct
	// FWPM_NET_EVENT_IKEEXT_EM_FAILURE0_ { UINT32 failureErrorCode; IPSEC_FAILURE_POINT failurePoint; UINT32 flags; IKEEXT_EM_SA_STATE
	// emState; IKEEXT_SA_ROLE saRole; IKEEXT_AUTHENTICATION_METHOD_TYPE emAuthMethod; UINT8 endCertHash[20]; UINT64 mmId; UINT64 qmFilterId;
	// } FWPM_NET_EVENT_IKEEXT_EM_FAILURE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_IKEEXT_EM_FAILURE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_IKEEXT_EM_FAILURE0
	{
		/// <summary>Windows error code for the failure.</summary>
		public Win32Error failureErrorCode;

		/// <summary>An IPSEC_FAILURE_POINT value that indicates the IPsec state when the failure occurred.</summary>
		public IPSEC_FAILURE_POINT failurePoint;

		/// <summary>
		/// <para>Flags for the failure event.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_NET_EVENT_IKEEXT_EM_FAILURE_FLAG_MULTIPLE</term>
		/// <term>Indicates that multiple IKE EM failure events have been reported.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_NET_EVENT_IKEEXT_EM_FAILURE_FLAG flags;

		/// <summary>An IKEEXT_EM_SA_STATE value that indicates the EM state when the failure occurred.</summary>
		public IKEEXT_EM_SA_STATE emState;

		/// <summary>An IKEEXT_SA_ROLE value that specifies the SA role when the failure occurred.</summary>
		public IKEEXT_SA_ROLE saRole;

		/// <summary>An IKEEXT_AUTHENTICATION_METHOD_TYPE value that specifies the authentication method.</summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE emAuthMethod;

		/// <summary>
		/// <para>
		/// SHA thumbprint hash of the end certificate corresponding to the failures that happen during building or validating certificate chains.
		/// </para>
		/// <para><c>IKEEXT_CERT_HASH_LEN</c> maps to 20.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] endCertHash;

		/// <summary>LUID for the Main Mode (MM) SA.</summary>
		public ulong mmId;

		/// <summary>Quick Mode (QM) filter ID associated with this failure.</summary>
		public ulong qmFilterId;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_IKEEXT_EM_FAILURE1</c> structure contains information that describes an IKE Extended mode (EM) failure.
	/// FWPM_NET_EVENT_IKEEXT_EM_FAILURE0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_ikeext_em_failure1 typedef struct
	// FWPM_NET_EVENT_IKEEXT_EM_FAILURE1_ { UINT32 failureErrorCode; IPSEC_FAILURE_POINT failurePoint; UINT32 flags; IKEEXT_EM_SA_STATE
	// emState; IKEEXT_SA_ROLE saRole; IKEEXT_AUTHENTICATION_METHOD_TYPE emAuthMethod; UINT8 endCertHash[20]; UINT64 mmId; UINT64 qmFilterId;
	// wchar_t *localPrincipalNameForAuth; wchar_t *remotePrincipalNameForAuth; UINT32 numLocalPrincipalGroupSids; StrPtrUni
	// *localPrincipalGroupSids; UINT32 numRemotePrincipalGroupSids; StrPtrUni *remotePrincipalGroupSids; IPSEC_TRAFFIC_TYPE saTrafficType; } FWPM_NET_EVENT_IKEEXT_EM_FAILURE1;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_IKEEXT_EM_FAILURE1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_IKEEXT_EM_FAILURE1
	{
		/// <summary>Windows error code for the failure.</summary>
		public Win32Error failureErrorCode;

		/// <summary>An IPSEC_FAILURE_POINT value that indicates the IPsec state when the failure occurred.</summary>
		public IPSEC_FAILURE_POINT failurePoint;

		/// <summary>
		/// <para>Flags for the failure event.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_NET_EVENT_IKEEXT_EM_FAILURE_FLAG_MULTIPLE</term>
		/// <term>Indicates that multiple IKE EM failure events have been reported.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_IKEEXT_EM_FAILURE_FLAG_BENIGN</term>
		/// <term>Indicates that IKE EM failure events have been reported, but that the events are benign.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_NET_EVENT_IKEEXT_EM_FAILURE_FLAG flags;

		/// <summary>An IKEEXT_EM_SA_STATE value that indicates the EM state when the failure occurred.</summary>
		public IKEEXT_EM_SA_STATE emState;

		/// <summary>An IKEEXT_SA_ROLE value that specifies the SA role when the failure occurred.</summary>
		public IKEEXT_SA_ROLE saRole;

		/// <summary>An IKEEXT_AUTHENTICATION_METHOD_TYPE value that specifies the authentication method.</summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE emAuthMethod;

		/// <summary>
		/// <para>
		/// SHA thumbprint hash of the end certificate corresponding to the failures that happen during building or validating certificate chains.
		/// </para>
		/// <para><c>IKEEXT_CERT_HASH_LEN</c> maps to 20.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] endCertHash;

		/// <summary>LUID for the Main Mode (MM) SA.</summary>
		public ulong mmId;

		/// <summary>Quick Mode (QM) filter ID associated with this failure.</summary>
		public ulong qmFilterId;

		/// <summary>Name of the EM local security principal.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string localPrincipalNameForAuth;

		/// <summary>Name of the EM remote security principal.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string remotePrincipalNameForAuth;

		/// <summary>Number of groups in the local security principal's token.</summary>
		public uint numLocalPrincipalGroupSids;

		private readonly IntPtr _localPrincipalGroupSids;

		/// <summary>Groups in the local security principal's token.</summary>
		public string[] localPrincipalGroupSids => _localPrincipalGroupSids.ToStringEnum((int)numLocalPrincipalGroupSids, CharSet.Unicode).WhereNotNull().ToArray();

		/// <summary>Number of groups in the remote security principal's token.</summary>
		public uint numRemotePrincipalGroupSids;

		private readonly IntPtr _remotePrincipalGroupSids;

		/// <summary>Groups in the remote security principal's token.</summary>
		public string[] remotePrincipalGroupSids => _remotePrincipalGroupSids.ToStringEnum((int)numRemotePrincipalGroupSids, CharSet.Unicode).WhereNotNull().ToArray();

		/// <summary>Type of traffic for which the embedded quick mode was being negotiated.</summary>
		public IPSEC_TRAFFIC_TYPE saTrafficType;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_IKEEXT_MM_FAILURE0</c> structure contains information that describes an IKE/AuthIP Main Mode (MM) failure.
	/// FWPM_NET_EVENT_IKEEXT_MM_FAILURE1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_ikeext_mm_failure0 typedef struct
	// FWPM_NET_EVENT_IKEEXT_MM_FAILURE0_ { UINT32 failureErrorCode; IPSEC_FAILURE_POINT failurePoint; UINT32 flags; IKEEXT_KEY_MODULE_TYPE
	// keyingModuleType; IKEEXT_MM_SA_STATE mmState; IKEEXT_SA_ROLE saRole; IKEEXT_AUTHENTICATION_METHOD_TYPE mmAuthMethod; UINT8
	// endCertHash[20]; UINT64 mmId; UINT64 mmFilterId; } FWPM_NET_EVENT_IKEEXT_MM_FAILURE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_IKEEXT_MM_FAILURE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_IKEEXT_MM_FAILURE0
	{
		/// <summary>Windows error code for the failure.</summary>
		public Win32Error failureErrorCode;

		/// <summary>An IPSEC_FAILURE_POINT value that indicates the IPsec state when the failure occurred.</summary>
		public IPSEC_FAILURE_POINT failurePoint;

		/// <summary>
		/// <para>Flags for the failure event.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_NET_EVENT_IKEEXT_MM_FAILURE_FLAG_BENIGN</term>
		/// <term>Indicates that the failure was benign or expected.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_IKEEXT_MM_FAILURE_FLAG_MULTIPLE</term>
		/// <term>Indicates that multiple failure events have been reported.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_NET_EVENT_IKEEXT_MM_FAILURE_FLAG flags;

		/// <summary>An IKEEXT_KEY_MODULE_TYPE value that specifies the type of keying module.</summary>
		public IKEEXT_KEY_MODULE_TYPE keyingModuleType;

		/// <summary>An IKEEXT_MM_SA_STATE value that indicates the Main Mode state when the failure occurred.</summary>
		public IKEEXT_MM_SA_STATE mmState;

		/// <summary>An IKEEXT_SA_ROLE value that specifies the security association (SA) role when the failure occurred.</summary>
		public IKEEXT_SA_ROLE saRole;

		/// <summary>An IKEEXT_AUTHENTICATION_METHOD_TYPE value that specifies the authentication method.</summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE mmAuthMethod;

		/// <summary>
		/// <para>
		/// SHA thumbprint hash of the end certificate corresponding to the failures that happen during building or validating certificate chains.
		/// </para>
		/// <para><c>IKEEXT_CERT_HASH_LEN</c> maps to 20.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] endCertHash;

		/// <summary>LUID for the MM SA.</summary>
		public ulong mmId;

		/// <summary>Main mode filter ID.</summary>
		public ulong mmFilterId;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_IKEEXT_MM_FAILURE1</c> structure contains information that describes an IKE/AuthIP Main Mode (MM) failure.
	/// FWPM_NET_EVENT_IKEEXT_MM_FAILURE0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_ikeext_mm_failure1 typedef struct
	// FWPM_NET_EVENT_IKEEXT_MM_FAILURE1_ { UINT32 failureErrorCode; IPSEC_FAILURE_POINT failurePoint; UINT32 flags; IKEEXT_KEY_MODULE_TYPE
	// keyingModuleType; IKEEXT_MM_SA_STATE mmState; IKEEXT_SA_ROLE saRole; IKEEXT_AUTHENTICATION_METHOD_TYPE mmAuthMethod; UINT8
	// endCertHash[20]; UINT64 mmId; UINT64 mmFilterId; wchar_t *localPrincipalNameForAuth; wchar_t *remotePrincipalNameForAuth; UINT32
	// numLocalPrincipalGroupSids; StrPtrUni *localPrincipalGroupSids; UINT32 numRemotePrincipalGroupSids; StrPtrUni *remotePrincipalGroupSids; } FWPM_NET_EVENT_IKEEXT_MM_FAILURE1;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_IKEEXT_MM_FAILURE1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_IKEEXT_MM_FAILURE1
	{
		/// <summary>Windows error code for the failure.</summary>
		public Win32Error failureErrorCode;

		/// <summary>An IPSEC_FAILURE_POINT value that indicates the IPsec state when the failure occurred.</summary>
		public IPSEC_FAILURE_POINT failurePoint;

		/// <summary>
		/// <para>Flags for the failure event.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_NET_EVENT_IKEEXT_MM_FAILURE_FLAG_BENIGN</term>
		/// <term>Indicates that the failure was benign or expected.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_NET_EVENT_IKEEXT_MM_FAILURE_FLAG_MULTIPLE</term>
		/// <term>Indicates that multiple failure events have been reported.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_NET_EVENT_IKEEXT_MM_FAILURE_FLAG flags;

		/// <summary>An IKEEXT_KEY_MODULE_TYPE value that specifies the type of keying module.</summary>
		public IKEEXT_KEY_MODULE_TYPE keyingModuleType;

		/// <summary>An IKEEXT_MM_SA_STATE value that indicates the Main Mode state when the failure occurred.</summary>
		public IKEEXT_MM_SA_STATE mmState;

		/// <summary>An IKEEXT_SA_ROLE value that specifies the security association (SA) role when the failure occurred.</summary>
		public IKEEXT_SA_ROLE saRole;

		/// <summary>An IKEEXT_AUTHENTICATION_METHOD_TYPE value that specifies the authentication method.</summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE mmAuthMethod;

		/// <summary>
		/// <para>
		/// SHA thumbprint hash of the end certificate corresponding to the failures that happen during building or validating certificate chains.
		/// </para>
		/// <para><c>IKEEXT_CERT_HASH_LEN</c> maps to 20.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] endCertHash;

		/// <summary>LUID for the MM SA.</summary>
		public ulong mmId;

		/// <summary>Main mode filter ID.</summary>
		public ulong mmFilterId;

		/// <summary>Name of the MM local security principal.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string localPrincipalNameForAuth;

		/// <summary>Name of the MM remote security principal.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string remotePrincipalNameForAuth;

		/// <summary>Number of groups in the local security principal's token.</summary>
		public uint numLocalPrincipalGroupSids;

		private readonly IntPtr _localPrincipalGroupSids;

		/// <summary>Groups in the local security principal's token.</summary>
		public string[] localPrincipalGroupSids => _localPrincipalGroupSids.ToStringEnum((int)numLocalPrincipalGroupSids, CharSet.Unicode).WhereNotNull().ToArray();

		/// <summary>Number of groups in the remote security principal's token.</summary>
		public uint numRemotePrincipalGroupSids;

		private readonly IntPtr _remotePrincipalGroupSids;

		/// <summary>Groups in the remote security principal's token.</summary>
		public string[] remotePrincipalGroupSids => _remotePrincipalGroupSids.ToStringEnum((int)numRemotePrincipalGroupSids, CharSet.Unicode).WhereNotNull().ToArray();
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_IKEEXT_QM_FAILURE0</c> structure contains information that describes an IKE/AuthIP Quick Mode (QM) failure.
	/// </summary>
	/// <remarks>
	/// <c>FWPM_NET_EVENT_IKEEXT_QM_FAILURE0</c> is a specific implementation of FWPM_NET_EVENT_IKEEXT_QM_FAILURE. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_ikeext_qm_failure0 typedef struct
	// FWPM_NET_EVENT_IKEEXT_QM_FAILURE0_ { UINT32 failureErrorCode; IPSEC_FAILURE_POINT failurePoint; IKEEXT_KEY_MODULE_TYPE
	// keyingModuleType; IKEEXT_QM_SA_STATE qmState; IKEEXT_SA_ROLE saRole; IPSEC_TRAFFIC_TYPE saTrafficType; union { FWP_CONDITION_VALUE0
	// localSubNet; }; union { FWP_CONDITION_VALUE0 remoteSubNet; }; UINT64 qmFilterId; } FWPM_NET_EVENT_IKEEXT_QM_FAILURE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_IKEEXT_QM_FAILURE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_IKEEXT_QM_FAILURE0
	{
		/// <summary>Windows error code for the failure.</summary>
		public Win32Error failureErrorCode;

		/// <summary>An IPSEC_FAILURE_POINT value that indicates the IPsec state when the failure occurred.</summary>
		public IPSEC_FAILURE_POINT failurePoint;

		/// <summary>An IKEEXT_KEY_MODULE_TYPE value that specifies the type of keying module.</summary>
		public IKEEXT_KEY_MODULE_TYPE keyingModuleType;

		/// <summary>An IKEEXT_QM_SA_STATE value that specifies the QM state when the failure occurred.</summary>
		public IKEEXT_QM_SA_STATE qmState;

		/// <summary>An IKEEXT_SA_ROLE value that specifies the SA role when the failure occurred.</summary>
		public IKEEXT_SA_ROLE saRole;

		/// <summary>An IPSEC_TRAFFIC_TYPE value that specifies the type of traffic.</summary>
		public IPSEC_TRAFFIC_TYPE saTrafficType;

		/// <summary>
		/// <para>An FWP_CONDITION_VALUE0 structure that contains values that conditions can use when testing for matches.</para>
		/// <para>Available when <c>saTrafficType</c> is <c>IPSEC_TRAFFIC_TYPE_TUNNEL</c>.</para>
		/// </summary>
		public FWP_CONDITION_VALUE0 localSubNet;

		/// <summary>
		/// <para>An FWP_CONDITION_VALUE0 structure that contains values that conditions can use when testing for matches.</para>
		/// <para>Available when <c>saTrafficType</c> is <c>IPSEC_TRAFFIC_TYPE_TUNNEL</c>.</para>
		/// </summary>
		public FWP_CONDITION_VALUE0 remoteSubNet;

		/// <summary>Quick Mode filter ID.</summary>
		public ulong qmFilterId;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_IPSEC_DOSP_DROP0</c> structure contains information that describes an IPsec DoS Protection drop event.
	/// </summary>
	/// <remarks>
	/// <c>FWPM_NET_EVENT_IPSEC_DOSP_DROP0</c> is a specific implementation of FWPM_NET_EVENT_IPSEC_DOSP_DROP. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_ipsec_dosp_drop0 typedef struct
	// FWPM_NET_EVENT_IPSEC_DOSP_DROP0_ { FWP_IP_VERSION ipVersion; union { UINT32 publicHostV4Addr; UINT8 publicHostV6Addr[16]; }; union {
	// UINT32 internalHostV4Addr; UINT8 internalHostV6Addr[16]; }; INT32 failureStatus; FWP_DIRECTION direction; } FWPM_NET_EVENT_IPSEC_DOSP_DROP0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_IPSEC_DOSP_DROP0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_IPSEC_DOSP_DROP0
	{
		/// <summary>
		/// <para>Internet Protocol (IP) version.</para>
		/// <para>See FWP_IP_VERSION for more information.</para>
		/// </summary>
		public FWP_IP_VERSION ipVersion;

		private FWP_BYTE_ARRAY_ADDR pub;

		/// <summary>
		/// <para>The public IPv4 address of the Internet host.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR publicHostV4Addr { get => pub.addr; set => pub.addr = value; }

		/// <summary>
		/// <para>The public IPv6 address of the Internet host.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR publicHostV6Addr { get => pub.addr6; set => pub.addr6 = value; }

		private FWP_BYTE_ARRAY_ADDR intern;

		/// <summary>
		/// <para>The internal IPv4 address of the Internet host.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR internalHostV4Addr { get => intern.addr; set => intern.addr = value; }

		/// <summary>
		/// <para>The internal IPv6 address of the Internet host.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR internalHostV6Addr { get => intern.addr6; set => intern.addr6 = value; }

		/// <summary>Contains the error code for the failure.</summary>
		public Win32Error failureStatus;

		/// <summary>An FWP_DIRECTION value that specifies whether the dropped packet is inbound or outbound.</summary>
		public FWP_DIRECTION direction;
	}

	/// <summary>The <c>FWPM_NET_EVENT_IPSEC_KERNEL_DROP0</c> structure contains information that describes an IPsec kernel drop event.</summary>
	/// <remarks>
	/// <c>FWPM_NET_EVENT_IPSEC_KERNEL_DROP0</c> is a specific implementation of FWPM_NET_EVENT_IPSEC_KERNEL_DROP. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_ipsec_kernel_drop0 typedef struct
	// FWPM_NET_EVENT_IPSEC_KERNEL_DROP0_ { INT32 failureStatus; FWP_DIRECTION direction; IPSEC_SA_SPI spi; UINT64 filterId; UINT16 layerId;
	// } FWPM_NET_EVENT_IPSEC_KERNEL_DROP0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_IPSEC_KERNEL_DROP0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_IPSEC_KERNEL_DROP0
	{
		/// <summary>Contains the error code for the failure.</summary>
		public Win32Error failureStatus;

		/// <summary>An FWP_DIRECTION value that specifies whether the dropped packet is inbound or outbound.</summary>
		public FWP_DIRECTION direction;

		/// <summary>
		/// Contains the security parameters index (SPI) on the IPsec header of the packet. This will be 0 for clear text packets. The
		/// <c>IPSEC_SA_SPI</c> is identical to a <c>UINT32</c>.
		/// </summary>
		public uint spi;

		/// <summary>
		/// Filter ID that corresponds to the IPsec callout filter. This will be available only if the packet was dropped by the IPsec callout.
		/// </summary>
		public ulong filterId;

		/// <summary>
		/// Layer ID that corresponds to the IPsec callout filter. This will be available only if the packet was dropped by the IPsec callout.
		/// </summary>
		public ushort layerId;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT_SUBSCRIPTION0</c> structure stores information used to subscribe to notifications about a network event.
	/// </summary>
	/// <remarks>
	/// <c>FWPM_NET_EVENT_SUBSCRIPTION0</c> is a specific implementation of FWPM_NET_EVENT_SUBSCRIPTION. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event_subscription0 typedef struct
	// FWPM_NET_EVENT_SUBSCRIPTION0_ { FWPM_NET_EVENT_ENUM_TEMPLATE0 *enumTemplate; UINT32 flags; GUID sessionKey; } FWPM_NET_EVENT_SUBSCRIPTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT_SUBSCRIPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT_SUBSCRIPTION0
	{
		private readonly IntPtr _enumTemplate;

		/// <summary>
		/// Address of an <see cref="FWPM_NET_EVENT_ENUM_TEMPLATE0"/> structure. Notifications are only dispatched for objects that match the
		/// template. If <c>enumTemplate</c> is <c>NULL</c>, it matches all objects.
		/// </summary>
		public FWPM_NET_EVENT_ENUM_TEMPLATE0? enumTemplate => _enumTemplate.ToNullableStructure<FWPM_NET_EVENT_ENUM_TEMPLATE0>();

		/// <summary>Unused.</summary>
		public uint flags;

		/// <summary>Identifies the session which created the subscription.</summary>
		public Guid sessionKey;
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT0</c> structure contains information about all event types. FWPM_NET_EVENT1 is available. For Windows 8,
	/// FWPM_NET_EVENT2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event0 typedef struct FWPM_NET_EVENT0_ {
	// FWPM_NET_EVENT_HEADER0 header; FWPM_NET_EVENT_TYPE type; union { FWPM_NET_EVENT_IKEEXT_MM_FAILURE0 *ikeMmFailure;
	// FWPM_NET_EVENT_IKEEXT_QM_FAILURE0 *ikeQmFailure; FWPM_NET_EVENT_IKEEXT_EM_FAILURE0 *ikeEmFailure; FWPM_NET_EVENT_CLASSIFY_DROP0
	// *classifyDrop; FWPM_NET_EVENT_IPSEC_KERNEL_DROP0 *ipsecDrop; FWPM_NET_EVENT_IPSEC_DOSP_DROP0 *idpDrop; }; } FWPM_NET_EVENT0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT0
	{
		/// <summary>A FWPM_NET_EVENT_HEADER0 structure that contains information common to all events.</summary>
		public FWPM_NET_EVENT_HEADER0 header;

		/// <summary>A FWPM_NET_EVENT_TYPE value that specifies the type of event.</summary>
		public FWPM_NET_EVENT_TYPE type;

		private IntPtr ptr;

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IKEEXT_MM_FAILURE0 structure that contains information about an IKE main mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_MM_FAILURE0> ikeMmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IKEEXT_QM_FAILURE0 structure that contains information about an IKE quick mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_QM_FAILURE0> ikeQmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IKEEXT_EM_FAILURE0 structure that contains information about an IKE user mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_EM_FAILURE0> ikeEmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_CLASSIFY_DROP0 structure that contains information about a drop event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_CLASSIFY_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CLASSIFY_DROP0> classifyDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IPSEC_KERNEL_DROP0 structure that contains information about an IPsec kernel drop event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IPSEC_KERNEL_DROP0> ipsecDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IPSEC_DOSP_DROP0 structure that contains information about an IPsec DoS Protection event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_IPSEC_DOSP_DROP</c>.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>Available only in Windows Server 2008 R2, Windows 7, and later.</para>
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IPSEC_DOSP_DROP0> idpDrop { get => new(ptr, false); set => ptr = value; }
	}

	/// <summary>The <c>FWPM_NET_EVENT1</c> structure contains information about all event types. FWPM_NET_EVENT0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event1 typedef struct FWPM_NET_EVENT1_ {
	// FWPM_NET_EVENT_HEADER1 header; FWPM_NET_EVENT_TYPE type; union { FWPM_NET_EVENT_IKEEXT_MM_FAILURE1 *ikeMmFailure;
	// FWPM_NET_EVENT_IKEEXT_QM_FAILURE0 *ikeQmFailure; FWPM_NET_EVENT_IKEEXT_EM_FAILURE1 *ikeEmFailure; FWPM_NET_EVENT_CLASSIFY_DROP1
	// *classifyDrop; FWPM_NET_EVENT_IPSEC_KERNEL_DROP0 *ipsecDrop; FWPM_NET_EVENT_IPSEC_DOSP_DROP0 *idpDrop; }; } FWPM_NET_EVENT1;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT1
	{
		/// <summary>An FWPM_NET_EVENT_HEADER1 structure that contains information common to all events.</summary>
		public FWPM_NET_EVENT_HEADER1 header;

		/// <summary>An FWPM_NET_EVENT_TYPE value that specifies the type of event.</summary>
		public FWPM_NET_EVENT_TYPE type;

		private IntPtr ptr;

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IKEEXT_MM_FAILURE1 structure that contains information about an IKE main mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_MM_FAILURE1> ikeMmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IKEEXT_QM_FAILURE0 structure that contains information about an IKE quick mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_QM_FAILURE0> ikeQmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IKEEXT_EM_FAILURE1 structure that contains information about an IKE user mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_EM_FAILURE1> ikeEmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_CLASSIFY_DROP1 structure that contains information about a drop event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_CLASSIFY_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CLASSIFY_DROP1> classifyDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IPSEC_KERNEL_DROP0 structure that contains information about an IPsec kernel drop event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IPSEC_KERNEL_DROP0> ipsecDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Address of an FWPM_NET_EVENT_IPSEC_DOSP_DROP0 structure that contains information about an IPsec DoS Protection event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_IPSEC_DOSP_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IPSEC_DOSP_DROP0> idpDrop { get => new(ptr, false); set => ptr = value; }
	}

	/// <summary>The <c>FWPM_NET_EVENT2</c> structure contains information about all event types. FWPM_NET_EVENT0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event2 typedef struct FWPM_NET_EVENT2_ {
	// FWPM_NET_EVENT_HEADER2 header; FWPM_NET_EVENT_TYPE type; union { FWPM_NET_EVENT_IKEEXT_MM_FAILURE1 *ikeMmFailure;
	// FWPM_NET_EVENT_IKEEXT_QM_FAILURE0 *ikeQmFailure; FWPM_NET_EVENT_IKEEXT_EM_FAILURE1 *ikeEmFailure; FWPM_NET_EVENT_CLASSIFY_DROP2
	// *classifyDrop; FWPM_NET_EVENT_IPSEC_KERNEL_DROP0 *ipsecDrop; FWPM_NET_EVENT_IPSEC_DOSP_DROP0 *idpDrop; FWPM_NET_EVENT_CLASSIFY_ALLOW0
	// *classifyAllow; FWPM_NET_EVENT_CAPABILITY_DROP0 *capabilityDrop; FWPM_NET_EVENT_CAPABILITY_ALLOW0 *capabilityAllow;
	// FWPM_NET_EVENT_CLASSIFY_DROP_MAC0 *classifyDropMac; }; } FWPM_NET_EVENT2;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT2
	{
		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_HEADER2</c></para>
		/// <para>Information common to all events.</para>
		/// </summary>
		public FWPM_NET_EVENT_HEADER2 header;

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_TYPE</c></para>
		/// <para>The type of event.</para>
		/// </summary>
		public FWPM_NET_EVENT_TYPE type;

		private IntPtr ptr;

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_IKEEXT_MM_FAILURE1</c>*</para>
		/// <para>Information about an IKE main mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_MM_FAILURE1> ikeMmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_IKEEXT_QM_FAILURE0</c>*</para>
		/// <para>Information about an IKE quick mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_QM_FAILURE0> ikeQmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_IKEEXT_EM_FAILURE1</c>*</para>
		/// <para>Information about an IKE user mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_EM_FAILURE1> ikeEmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_CLASSIFY_DROP2</c>*</para>
		/// <para>Information about a drop event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_CLASSIFY_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CLASSIFY_DROP2> classifyDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_IPSEC_KERNEL_DROP0</c>*</para>
		/// <para>Information about an IPsec kernel drop event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IPSEC_KERNEL_DROP0> ipsecDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_IPSEC_DOSP_DROP0</c>*</para>
		/// <para>Information about an IPsec DoS Protection event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_IPSEC_DOSP_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IPSEC_DOSP_DROP0> idpDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_CLASSIFY_ALLOW0</c>*</para>
		/// <para>Information about an allow event.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CLASSIFY_ALLOW0> classifyAllow { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_CAPABILITY_DROP0</c>*</para>
		/// <para>Information about a capability-related drop event.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CAPABILITY_DROP0> capabilityDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_CAPABILITY_ALLOW0</c>*</para>
		/// <para>Information about a capability-related allow event.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CAPABILITY_ALLOW0> capabilityAllow { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_NET_EVENT_CLASSIFY_DROP_MAC0</c>*</para>
		/// <para>Information about a MAC layer drop event.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CLASSIFY_DROP_MAC0> classifyDropMac { get => new(ptr, false); set => ptr = value; }
	}

	/// <summary>
	/// The <c>FWPM_NET_EVENT3</c> structure contains information about all event types. FWPM_NET_EVENT2 is available. For Windows 7,
	/// FWPM_NET_EVENT1 is available. For Windows Vista, FWPM_NET_EVENT0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_net_event3 typedef struct FWPM_NET_EVENT3_ {
	// FWPM_NET_EVENT_HEADER3 header; FWPM_NET_EVENT_TYPE type; union { FWPM_NET_EVENT_IKEEXT_MM_FAILURE1 *ikeMmFailure;
	// FWPM_NET_EVENT_IKEEXT_QM_FAILURE0 *ikeQmFailure; FWPM_NET_EVENT_IKEEXT_EM_FAILURE1 *ikeEmFailure; FWPM_NET_EVENT_CLASSIFY_DROP2
	// *classifyDrop; FWPM_NET_EVENT_IPSEC_KERNEL_DROP0 *ipsecDrop; FWPM_NET_EVENT_IPSEC_DOSP_DROP0 *idpDrop; FWPM_NET_EVENT_CLASSIFY_ALLOW0
	// *classifyAllow; FWPM_NET_EVENT_CAPABILITY_DROP0 *capabilityDrop; FWPM_NET_EVENT_CAPABILITY_ALLOW0 *capabilityAllow;
	// FWPM_NET_EVENT_CLASSIFY_DROP_MAC0 *classifyDropMac; }; } FWPM_NET_EVENT3;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NET_EVENT3_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_NET_EVENT3
	{
		/// <summary>Information common to all events.</summary>
		public FWPM_NET_EVENT_HEADER3 header;

		/// <summary>The type of event.</summary>
		public FWPM_NET_EVENT_TYPE type;

		private IntPtr ptr;

		/// <summary>
		/// <para>Information about an IKE main mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_MM_FAILURE1> ikeMmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Information about an IKE quick mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_QM_FAILURE0> ikeQmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Information about an IKE user mode failure.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IKEEXT_EM_FAILURE1> ikeEmFailure { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Information about a drop event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_CLASSIFY_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CLASSIFY_DROP2> classifyDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Information about an IPsec kernel drop event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IPSEC_KERNEL_DROP0> ipsecDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Information about an IPsec DoS Protection event.</para>
		/// <para>Available when <c>type</c> is <c>FWPM_NET_EVENT_IPSEC_DOSP_DROP</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_IPSEC_DOSP_DROP0> idpDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>Information about an allow event.</summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CLASSIFY_ALLOW0> classifyAllow { get => new(ptr, false); set => ptr = value; }

		/// <summary>Information about a capability-related drop event.</summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CAPABILITY_DROP0> capabilityDrop { get => new(ptr, false); set => ptr = value; }

		/// <summary>Information about a capability-related allow event.</summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CAPABILITY_ALLOW0> capabilityAllow { get => new(ptr, false); set => ptr = value; }

		/// <summary>Information about a MAC layer drop event.</summary>
		public SafeCoTaskMemStruct<FWPM_NET_EVENT_CLASSIFY_DROP_MAC0> classifyDropMac { get => new(ptr, false); set => ptr = value; }
	}

	/// <summary>Stores a type and value pair for a connection policy setting. You use this structure with <c>FwpmConnectionPolicyAdd0</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_network_connection_policy_setting0 typedef struct
	// FWPM_NETWORK_CONNECTION_POLICY_SETTING0_ { FWP_NETWORK_CONNECTION_POLICY_SETTING_TYPE type; FWP_VALUE0 value; } FWPM_NETWORK_CONNECTION_POLICY_SETTING0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NETWORK_CONNECTION_POLICY_SETTING0_")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FWPM_NETWORK_CONNECTION_POLICY_SETTING0
	{
		/// <summary>A type of connection policy setting. See <c>FWP_NETWORK_CONNECTION_POLICY_SETTING_TYPE</c>.</summary>
		public FWP_NETWORK_CONNECTION_POLICY_SETTING_TYPE type;

		/// <summary>
		/// <para>The value of a connection policy setting.</para>
		/// <para>
		/// <b>FWP_NETWORK_CONNECTION_POLICY_SOURCE_ADDRESS</b>. The source address to use for the connection. The value should be a
		/// <b>FWP_UINT32</b> for an IPv4 address, and a <b>FWP_BYTE_ARRAY16_TYPE</b> for an IPv6 address.
		/// </para>
		/// <para>
		/// <b>FWP_NETWORK_CONNECTION_POLICY_NEXT_HOP_INTERFACE</b>. The LUID of the outgoing interface to use for the connection. The value
		/// should be a <b>FWP_UINT64</b>.
		/// </para>
		/// <para>
		/// <b>FWP_NETWORK_CONNECTION_POLICY_NEXT_HOP</b>. The nexthop address (or gateway) to use for the connection. The value should be a
		/// <b>FWP_UINT32</b> for an IPv4 address, and a <b>FWP_BYTE_ARRAY16_TYPE</b> for an IPv6 address.
		/// </para>
		/// </summary>
		public FWP_VALUE0 value;
	}

	/// <summary>
	/// Stores an array of <c>FWPM_NETWORK_CONNECTION_POLICY_SETTING0</c> values, together with the number of elements in that array.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_network_connection_policy_settings0 typedef struct
	// FWPM_NETWORK_CONNECTION_POLICY_SETTINGS0_ { UINT32 numSettings; FWPM_NETWORK_CONNECTION_POLICY_SETTING0 *settings; } FWPM_NETWORK_CONNECTION_POLICY_SETTINGS0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_NETWORK_CONNECTION_POLICY_SETTINGS0_")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FWPM_NETWORK_CONNECTION_POLICY_SETTINGS0
	{
		/// <summary>The number of <c>FWPM_NETWORK_CONNECTION_POLICY_SETTING0</c> structures contained in settings.</summary>
		public uint numSettings;

		/// <summary>An array of <c>FWPM_NETWORK_CONNECTION_POLICY_SETTING0</c> structures</summary>
		public ArrayPointer<FWPM_NETWORK_CONNECTION_POLICY_SETTING0> settings;
	}

	/// <summary>The <c>FWPM_PROVIDER_CHANGE0</c> structure specifies a change notification dispatched to subscribers.</summary>
	/// <remarks>
	/// <c>FWPM_PROVIDER_CHANGE0</c> is a specific implementation of FWPM_PROVIDER_CHANGE. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_change0 typedef struct FWPM_PROVIDER_CHANGE0_
	// { FWPM_CHANGE_TYPE changeType; GUID providerKey; } FWPM_PROVIDER_CHANGE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_CHANGE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER_CHANGE0
	{
		/// <summary>
		/// <para>Type of change.</para>
		/// <para>See FWPM_CHANGE_TYPE for more information.</para>
		/// </summary>
		public FWPM_CHANGE_TYPE changeType;

		/// <summary>GUID of the provider that changed.</summary>
		public Guid providerKey;
	}

	/// <summary>
	/// Stores the state associated with a provider context. <c>FWPM_PROVIDER_CONTEXT0</c>, <c>FWPM_PROVIDER_CONTEXT1</c>, and
	/// <c>FWPM_PROVIDER_CONTEXT2</c> are available.
	/// </summary>
	/// <remarks>The first seven elements of the union are information supplied when adding objects.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_context3 typedef struct
	// FWPM_PROVIDER_CONTEXT3_ { GUID providerContextKey; FWPM_DISPLAY_DATA0 displayData; UINT32 flags; GUID *providerKey; FWP_BYTE_BLOB
	// providerData; FWPM_PROVIDER_CONTEXT_TYPE type; union { IPSEC_KEYING_POLICY1 *keyingPolicy; IPSEC_TRANSPORT_POLICY2
	// *ikeQmTransportPolicy; IPSEC_TUNNEL_POLICY3 *ikeQmTunnelPolicy; IPSEC_TRANSPORT_POLICY2 *authipQmTransportPolicy; IPSEC_TUNNEL_POLICY3
	// *authipQmTunnelPolicy; IKEEXT_POLICY2 *ikeMmPolicy; IKEEXT_POLICY2 *authIpMmPolicy; FWP_BYTE_BLOB *dataBuffer; FWPM_CLASSIFY_OPTIONS0
	// *classifyOptions; IPSEC_TUNNEL_POLICY3 *ikeV2QmTunnelPolicy; IPSEC_TRANSPORT_POLICY2 *ikeV2QmTransportPolicy; IKEEXT_POLICY2
	// *ikeV2MmPolicy; IPSEC_DOSP_OPTIONS0 *idpOptions; FWPM_NETWORK_CONNECTION_POLICY_SETTINGS0 *networkConnectionPolicy; }; UINT64
	// providerContextId; } FWPM_PROVIDER_CONTEXT3;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_CONTEXT3_")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FWPM_PROVIDER_CONTEXT3
	{
		/// <summary>
		/// <para>Type: <b>GUID</b></para>
		/// <para>
		/// Uniquely identifies the provider context. If the GUID is zero-initialized in the call to <c>FwpmProviderContextAdd2</c>, then
		/// Base Filtering Engine (BFE) will generate one.
		/// </para>
		/// </summary>
		public Guid providerContextKey;

		/// <summary>
		/// <para>Type: <b><c>FWPM_DISPLAY_DATA0</c></b></para>
		/// <para>Allows provider contexts to be annotated in a human-readable form. The <c>FWPM_DISPLAY_DATA0</c> structure is required.</para>
		/// </summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Provider context flag</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>FWPM_PROVIDER_CONTEXT_FLAG_PERSISTENT</description>
		/// <description>The object is persistent, that is, it survives across BFE stop/start.</description>
		/// </item>
		/// <item>
		/// <description>FWPM_PROVIDER_CONTEXT_FLAG_DOWNLEVEL</description>
		/// <description>Reserved for internal use.</description>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_PROVIDER_CONTEXT_FLAG flags;

		/// <summary>
		/// <para>Type: <b>GUID*</b></para>
		/// <para>GUID of the policy provider that manages this object.</para>
		/// </summary>
		public GuidPtr providerKey;

		/// <summary>
		/// <para>Type: <b><c>FWP_BYTE_BLOB</c></b></para>
		/// <para>Optional provider-specific data that allows providers to store additional context info with the object.</para>
		/// </summary>
		public FWP_BYTE_BLOB providerData;

		/// <summary>
		/// <para>Type: <b><c>FWPM_PROVIDER_CONTEXT_TYPE</c></b></para>
		/// <para>The type of provider context.</para>
		/// </summary>
		public FWPM_PROVIDER_CONTEXT_TYPE type;

		/// <summary>The union of policies</summary>
		public FWPM_PROVIDER_CONTEXT3_UNION union;

		/// <summary>The union of policies</summary>
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct FWPM_PROVIDER_CONTEXT3_UNION
		{
			/// <summary>
			/// <para>Type: <b><c>IPSEC_KEYING_POLICY1</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_KEYING_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<IPSEC_KEYING_POLICY1> keyingPolicy;

			/// <summary>
			/// <para>Type: <b><c>IPSEC_TRANSPORT_POLICY2</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_IKE_QM_TRANSPORT_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<IPSEC_TRANSPORT_POLICY2> ikeQmTransportPolicy;

			/// <summary>
			/// <para>Type: <b><c>IPSEC_TUNNEL_POLICY2</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public ManagedStructPointer<IPSEC_TUNNEL_POLICY3> ikeQmTunnelPolicy;

			/// <summary>
			/// <para>Type: <b><c>IPSEC_TRANSPORT_POLICY2</c>*</b></para>
			/// <para>[case()][unique]</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<IPSEC_TRANSPORT_POLICY2> authipQmTransportPolicy;

			/// <summary>
			/// <para>Type: <b><c>IPSEC_TUNNEL_POLICY2</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_AUTHIP_QM_TRANSPORT_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public ManagedStructPointer<IPSEC_TUNNEL_POLICY3> authipQmTunnelPolicy;

			/// <summary>
			/// <para>Type: <b><c>IKEEXT_POLICY2</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_IKE_MM_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<IKEEXT_POLICY2> ikeMmPolicy;

			/// <summary>
			/// <para>Type: <b><c>IKEEXT_POLICY2</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_AUTHIP_MM_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<IKEEXT_POLICY2> authIpMmPolicy;

			/// <summary>
			/// <para>Type: <b><c>FWP_BYTE_BLOB</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_GENERAL_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<FWP_BYTE_BLOB> dataBuffer;

			/// <summary>
			/// <para>Type: <b><c>FWPM_CLASSIFY_OPTIONS0</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_CLASSIFY_OPTIONS_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<FWPM_CLASSIFY_OPTIONS0> classifyOptions;

			/// <summary>
			/// <para>Type: <b><c>IPSEC_TUNNEL_POLICY2</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_IKEV2_QM_TUNNEL_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public ManagedStructPointer<IPSEC_TUNNEL_POLICY3> ikeV2QmTunnelPolicy;

			/// <summary>
			/// <para>Type: <b><c>IPSEC_TRANSPORT_POLICY2</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_IKEV2_QM_TRANSPORT_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<IPSEC_TRANSPORT_POLICY2> ikeV2QmTransportPolicy;

			/// <summary>
			/// <para>Type: <b><c>IKEEXT_POLICY2</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_IKEV2_MM_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<IKEEXT_POLICY2> ikeV2MmPolicy;

			/// <summary>
			/// <para>Type: <b><c>IPSEC_DOSP_OPTIONS0</c>*</b></para>
			/// <para>Available when <b>type</b> is <b>FWPM_IPSEC_DOSP_CONTEXT</b>.</para>
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<IPSEC_DOSP_OPTIONS0> idpOptions;

			/// <summary>
			/// A pointer to a <c>FWPM_NETWORK_CONNECTION_POLICY_SETTINGS0</c> structure containing the number of network connection polices, and
			/// a list of those policies formatted.
			/// </summary>
			[FieldOffset(0)]
			public StructPointer<FWPM_NETWORK_CONNECTION_POLICY_SETTINGS0> networkConnectionPolicy;
		}

		/// <summary>
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// LUID identifying the context. This is the context value stored in the <b>FWPS_FILTER1</b> structure for filters that reference a
		/// provider context. The <b>FWPS_FILTER1</b> structure is documented in the WDK. This is additional information returned when
		/// getting/enumerating objects.
		/// </para>
		/// </summary>
		public ulong providerContextId;
	}

	/// <summary>The <c>FWPM_PROVIDER_CONTEXT_CHANGE0</c> structure contains a change notification dispatched to subscribers.</summary>
	/// <remarks>
	/// <c>FWPM_PROVIDER_CONTEXT_CHANGE0</c> is a specific implementation of FWPM_PROVIDER_CONTEXT_CHANGE. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_context_change0 typedef struct
	// FWPM_PROVIDER_CONTEXT_CHANGE0_ { FWPM_CHANGE_TYPE changeType; GUID providerContextKey; UINT64 providerContextId; } FWPM_PROVIDER_CONTEXT_CHANGE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_CONTEXT_CHANGE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER_CONTEXT_CHANGE0
	{
		/// <summary>
		/// <para>Type of change.</para>
		/// <para>See FWPM_CHANGE_TYPE for more information.</para>
		/// </summary>
		public FWPM_CHANGE_TYPE changeType;

		/// <summary>GUID of the provider context that changed.</summary>
		public Guid providerContextKey;

		/// <summary>LUID of the provider context that changed.</summary>
		public ulong providerContextId;
	}

	/// <summary>The <c>FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0</c> structure is used for enumerating provider contexts.</summary>
	/// <remarks>
	/// <c>FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0</c> is a specific implementation of FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_context_enum_template0 typedef struct
	// FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0_ { GUID *providerKey; FWPM_PROVIDER_CONTEXT_TYPE providerContextType; } FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0
	{
		/// <summary>Uniquely identifies a provider. If this value is non-NULL, only options with the specifies provider will be returned.</summary>
		public GuidPtr providerKey;

		/// <summary>
		/// <para>Only return provider contexts of the specified type.</para>
		/// <para>See FWPM_PROVIDER_CONTEXT_TYPE for more information.</para>
		/// </summary>
		public FWPM_PROVIDER_CONTEXT_TYPE providerContextType;
	}

	/// <summary>The <c>FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0</c> structure is used to subscribe for change notifications.</summary>
	/// <remarks>
	/// <c>FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0</c> is a specific implementation of FWPM_PROVIDER_CONTEXT_SUBSCRIPTION. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_context_subscription0 typedef struct
	// FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0_ { FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0 *enumTemplate; UINT32 flags; GUID sessionKey; } FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0
	{
		private readonly IntPtr _enumTemplate;

		/// <summary>
		/// <para>Notifications are only dispatched for objects that match the template. If the template is <c>NULL</c>, it matches all objects.</para>
		/// <para>See FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0 for more information</para>
		/// </summary>
		public FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0? enumTemplate => _enumTemplate.ToNullableStructure<FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0>();

		/// <summary>
		/// <para>The notifications to subscribe to, as one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Subscription flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_ADD</c></term>
		/// <term>Subscribe to provider add notifications.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_DELETE</c></term>
		/// <term>Subscribe to provider delete notifications.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_SUBSCRIPTION_FLAG flags;

		/// <summary>Uniquely identifies this session.</summary>
		public Guid sessionKey;
	}

	/// <summary>
	/// The <c>FWPM_PROVIDER_CONTEXT0</c> structure stores the state associated with a provider context. FWPM_PROVIDER_CONTEXT2 is available.
	/// </summary>
	/// <remarks>
	/// <para>The first seven elements of the union are information supplied when adding objects.</para>
	/// <para>The last element is additional information returned when getting/enumerating objects.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_context0 typedef struct
	// FWPM_PROVIDER_CONTEXT0_ { GUID providerContextKey; FWPM_DISPLAY_DATA0 displayData; UINT32 flags; GUID *providerKey; FWP_BYTE_BLOB
	// providerData; FWPM_PROVIDER_CONTEXT_TYPE type; union { IPSEC_KEYING_POLICY0 *keyingPolicy; IPSEC_TRANSPORT_POLICY0
	// *ikeQmTransportPolicy; IPSEC_TUNNEL_POLICY0 *ikeQmTunnelPolicy; IPSEC_TRANSPORT_POLICY0 *authipQmTransportPolicy; IPSEC_TUNNEL_POLICY0
	// *authipQmTunnelPolicy; IKEEXT_POLICY0 *ikeMmPolicy; IKEEXT_POLICY0 *authIpMmPolicy; FWP_BYTE_BLOB *dataBuffer; FWPM_CLASSIFY_OPTIONS0
	// *classifyOptions; }; UINT64 providerContextId; } FWPM_PROVIDER_CONTEXT0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_CONTEXT0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER_CONTEXT0
	{
		/// <summary>
		/// Uniquely identifies the provider context. If the GUID is zero-initialized in the call to FwpmProviderContextAdd0, Base Filtering
		/// Engine (BFE) will generate one.
		/// </summary>
		public Guid providerContextKey;

		/// <summary>Allows provider contexts to be annotated in a human-readable form. The FWPM_DISPLAY_DATA0 structure is required.</summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Provider context flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_PROVIDER_CONTEXT_FLAG_PERSISTENT</term>
		/// <term>The object is persistent, that is, it survives across BFE stop/start.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_PROVIDER_CONTEXT_FLAG flags;

		/// <summary>GUID of the policy provider that manages this object.</summary>
		public GuidPtr providerKey;

		/// <summary>
		/// An FWP_BYTE_BLOB structure that contains optional provider-specific data that allows providers to store additional context info
		/// with the object.
		/// </summary>
		public FWP_BYTE_BLOB providerData;

		/// <summary>A FWPM_PROVIDER_CONTEXT_TYPE value specifying the type of provider context..</summary>
		public FWPM_PROVIDER_CONTEXT_TYPE type;

		private IntPtr ptr;

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_KEYING_CONTEXT</c>.</para>
		/// <para>See IPSEC_KEYING_POLICY0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_KEYING_POLICY0> keyingPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKE_QM_TRANSPORT_CONTEXT</c>.</para>
		/// <para>See IPSEC_TRANSPORT_POLICY0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TRANSPORT_POLICY0> ikeQmTransportPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT</c>.</para>
		/// <para>See IPSEC_TUNNEL_POLICY0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TUNNEL_POLICY0> ikeQmTunnelPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_AUTHIP_QM_TRANSPORT_CONTEXT</c>.</para>
		/// <para>See IPSEC_TRANSPORT_POLICY0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TRANSPORT_POLICY0> authipQmTransportPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_AUTHIP_QM_TUNNEL_CONTEXT</c>.</para>
		/// <para>See IPSEC_TUNNEL_POLICY0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TUNNEL_POLICY0> authipQmTunnelPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKE_MM_CONTEXT</c>.</para>
		/// <para>See IKEEXT_POLICY0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_POLICY0> ikeMmPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_AUTHIP_MM_CONTEXT</c>.</para>
		/// <para>See IKEEXT_POLICY0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_POLICY0> authIpMmPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_GENERAL_CONTEXT</c>.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_BLOB> dataBuffer { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_CLASSIFY_OPTIONS_CONTEXT</c>.</para>
		/// <para>See FWPM_CLASSIFY_OPTIONS0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_CLASSIFY_OPTIONS0> classifyOptions { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// LUID identifying the context. This is the context value stored in the <c>FWPS_FILTER0</c> structure for filters that reference a
		/// provider context. The <c>FWPS_FILTER0</c> structure is documented in the WDK.
		/// </summary>
		public ulong providerContextId;
	}

	/// <summary>
	/// The <c>FWPM_PROVIDER_CONTEXT1</c> structure stores the state associated with a provider context. FWPM_PROVIDER_CONTEXT2 is available.
	/// For Windows Vista, FWPM_PROVIDER_CONTEXT0 is available.
	/// </summary>
	/// <remarks>
	/// <para>The first seven elements of the union are information supplied when adding objects.</para>
	/// <para>The last element is additional information returned when getting/enumerating objects.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_context1 typedef struct
	// FWPM_PROVIDER_CONTEXT1_ { GUID providerContextKey; FWPM_DISPLAY_DATA0 displayData; UINT32 flags; GUID *providerKey; FWP_BYTE_BLOB
	// providerData; FWPM_PROVIDER_CONTEXT_TYPE type; union { IPSEC_KEYING_POLICY0 *keyingPolicy; IPSEC_TRANSPORT_POLICY1
	// *ikeQmTransportPolicy; IPSEC_TUNNEL_POLICY1 *ikeQmTunnelPolicy; IPSEC_TRANSPORT_POLICY1 *authipQmTransportPolicy; IPSEC_TUNNEL_POLICY1
	// *authipQmTunnelPolicy; IKEEXT_POLICY1 *ikeMmPolicy; IKEEXT_POLICY1 *authIpMmPolicy; FWP_BYTE_BLOB *dataBuffer; FWPM_CLASSIFY_OPTIONS0
	// *classifyOptions; IPSEC_TUNNEL_POLICY1 *ikeV2QmTunnelPolicy; IKEEXT_POLICY1 *ikeV2MmPolicy; IPSEC_DOSP_OPTIONS0 *idpOptions; }; UINT64
	// providerContextId; } FWPM_PROVIDER_CONTEXT1;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_CONTEXT1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER_CONTEXT1
	{
		/// <summary>
		/// Uniquely identifies the provider context. If the GUID is zero-initialized in the call to FwpmProviderContextAdd1, Base Filtering
		/// Engine (BFE) will generate one.
		/// </summary>
		public Guid providerContextKey;

		/// <summary>Allows provider contexts to be annotated in a human-readable form. The FWPM_DISPLAY_DATA0 structure is required.</summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Provider context flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_PROVIDER_CONTEXT_FLAG_PERSISTENT</term>
		/// <term>The object is persistent, that is, it survives across BFE stop/start.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_PROVIDER_CONTEXT_FLAG flags;

		/// <summary>GUID of the policy provider that manages this object.</summary>
		public GuidPtr providerKey;

		/// <summary>
		/// An FWP_BYTE_BLOB structure that contains optional provider-specific data that allows providers to store additional context info
		/// with the object.
		/// </summary>
		public FWP_BYTE_BLOB providerData;

		/// <summary>A FWPM_PROVIDER_CONTEXT_TYPE value specifying the type of provider context..</summary>
		public FWPM_PROVIDER_CONTEXT_TYPE type;

		private IntPtr ptr;

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_KEYING_CONTEXT</c>.</para>
		/// <para>See IPSEC_KEYING_POLICY0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_KEYING_POLICY0> keyingPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKE_QM_TRANSPORT_CONTEXT</c>.</para>
		/// <para>See IPSEC_TRANSPORT_POLICY1 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TRANSPORT_POLICY1> ikeQmTransportPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT</c>.</para>
		/// <para>See IPSEC_TUNNEL_POLICY1 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TUNNEL_POLICY1> ikeQmTunnelPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_AUTHIP_QM_TRANSPORT_CONTEXT</c>.</para>
		/// <para>See IPSEC_TRANSPORT_POLICY1 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TRANSPORT_POLICY1> authipQmTransportPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_AUTHIP_QM_TUNNEL_CONTEXT</c>.</para>
		/// <para>See IPSEC_TUNNEL_POLICY1 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TUNNEL_POLICY1> authipQmTunnelPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKE_MM_CONTEXT</c>.</para>
		/// <para>See IKEEXT_POLICY1 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_POLICY1> ikeMmPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_AUTHIP_MM_CONTEXT</c>.</para>
		/// <para>See IKEEXT_POLICY1 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_POLICY1> authIpMmPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_GENERAL_CONTEXT</c>.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_BLOB> dataBuffer { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_CLASSIFY_OPTIONS_CONTEXT</c>.</para>
		/// <para>See FWPM_CLASSIFY_OPTIONS0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_CLASSIFY_OPTIONS0> classifyOptions { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKEV2_QM_TUNNEL_CONTEXT</c>.</para>
		/// <para>See IPSEC_TUNNEL_POLICY1 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TUNNEL_POLICY1> ikeV2QmTunnelPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKEV2_MM_CONTEXT</c>.</para>
		/// <para>See IKEEXT_POLICY1 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_POLICY1> ikeV2MmPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_DOSP_CONTEXT</c>.</para>
		/// <para>See IPSEC_DOSP_OPTIONS0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_DOSP_OPTIONS0> idpOptions { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// LUID identifying the context. This is the context value stored in the <c>FWPS_FILTER1</c> structure for filters that reference a
		/// provider context. The <c>FWPS_FILTER1</c> structure is documented in the WDK.
		/// </summary>
		public ulong providerContextId;
	}

	/// <summary>
	/// The <c>FWPM_PROVIDER_CONTEXT2</c> structure stores the state associated with a provider context. FWPM_PROVIDER_CONTEXT0 is available.
	/// </summary>
	/// <remarks>
	/// <para>The first seven elements of the union are information supplied when adding objects.</para>
	/// <para>The last element is additional information returned when getting/enumerating objects.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_context2 typedef struct
	// FWPM_PROVIDER_CONTEXT2_ { GUID providerContextKey; FWPM_DISPLAY_DATA0 displayData; UINT32 flags; GUID *providerKey; FWP_BYTE_BLOB
	// providerData; FWPM_PROVIDER_CONTEXT_TYPE type; union { IPSEC_KEYING_POLICY1 *keyingPolicy; IPSEC_TRANSPORT_POLICY2
	// *ikeQmTransportPolicy; IPSEC_TUNNEL_POLICY2 *ikeQmTunnelPolicy; IPSEC_TRANSPORT_POLICY2 *authipQmTransportPolicy; IPSEC_TUNNEL_POLICY2
	// *authipQmTunnelPolicy; IKEEXT_POLICY2 *ikeMmPolicy; IKEEXT_POLICY2 *authIpMmPolicy; FWP_BYTE_BLOB *dataBuffer; FWPM_CLASSIFY_OPTIONS0
	// *classifyOptions; IPSEC_TUNNEL_POLICY2 *ikeV2QmTunnelPolicy; IPSEC_TRANSPORT_POLICY2 *ikeV2QmTransportPolicy; IKEEXT_POLICY2
	// *ikeV2MmPolicy; IPSEC_DOSP_OPTIONS0 *idpOptions; }; UINT64 providerContextId; } FWPM_PROVIDER_CONTEXT2;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_CONTEXT2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER_CONTEXT2
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>
		/// Uniquely identifies the provider context. If the GUID is zero-initialized in the call to FwpmProviderContextAdd2, Base Filtering
		/// Engine (BFE) will generate one.
		/// </para>
		/// </summary>
		public Guid providerContextKey;

		/// <summary>
		/// <para>Type: <c>FWPM_DISPLAY_DATA0</c></para>
		/// <para>Allows provider contexts to be annotated in a human-readable form. The FWPM_DISPLAY_DATA0 structure is required.</para>
		/// </summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Provider context flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FWPM_PROVIDER_CONTEXT_FLAG_PERSISTENT</term>
		/// <term>The object is persistent, that is, it survives across BFE stop/start.</term>
		/// </item>
		/// <item>
		/// <term>FWPM_PROVIDER_CONTEXT_FLAG_DOWNLEVEL</term>
		/// <term>Reserved for internal use.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_PROVIDER_CONTEXT_FLAG flags;

		/// <summary>
		/// <para>Type: <c>GUID</c>*</para>
		/// <para>GUID of the policy provider that manages this object.</para>
		/// </summary>
		public GuidPtr providerKey;

		/// <summary>
		/// <para>Type: <c>FWP_BYTE_BLOB</c></para>
		/// <para>Optional provider-specific data that allows providers to store additional context info with the object.</para>
		/// </summary>
		public FWP_BYTE_BLOB providerData;

		/// <summary>
		/// <para>Type: <c>FWPM_PROVIDER_CONTEXT_TYPE</c></para>
		/// <para>The type of provider context.</para>
		/// </summary>
		public FWPM_PROVIDER_CONTEXT_TYPE type;

		private IntPtr ptr;

		/// <summary>
		/// <para>Type: <c>IPSEC_KEYING_POLICY1</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_KEYING_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_KEYING_POLICY1> keyingPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IPSEC_TRANSPORT_POLICY2</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKE_QM_TRANSPORT_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TRANSPORT_POLICY2> ikeQmTransportPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IPSEC_TUNNEL_POLICY2</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TUNNEL_POLICY2> ikeQmTunnelPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IPSEC_TRANSPORT_POLICY2</c>*</para>
		/// <para>[case()][unique]</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TRANSPORT_POLICY2> authipQmTransportPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IPSEC_TUNNEL_POLICY2</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_AUTHIP_QM_TRANSPORT_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TUNNEL_POLICY2> authipQmTunnelPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IKEEXT_POLICY2</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKE_MM_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_POLICY2> ikeMmPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IKEEXT_POLICY2</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_AUTHIP_MM_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_POLICY2> authIpMmPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWP_BYTE_BLOB</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_GENERAL_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_BLOB> dataBuffer { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>FWPM_CLASSIFY_OPTIONS0</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_CLASSIFY_OPTIONS_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWPM_CLASSIFY_OPTIONS0> classifyOptions { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IPSEC_TUNNEL_POLICY2</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKEV2_QM_TUNNEL_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TUNNEL_POLICY2> ikeV2QmTunnelPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IPSEC_TRANSPORT_POLICY2</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKEV2_QM_TRANSPORT_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_TRANSPORT_POLICY2> ikeV2QmTransportPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IKEEXT_POLICY2</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_IKEV2_MM_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_POLICY2> ikeV2MmPolicy { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>IPSEC_DOSP_OPTIONS0</c>*</para>
		/// <para>Available when <c>type</c> is <c>FWPM_IPSEC_DOSP_CONTEXT</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_DOSP_OPTIONS0> idpOptions { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>
		/// LUID identifying the context. This is the context value stored in the <c>FWPS_FILTER1</c> structure for filters that reference a
		/// provider context. The <c>FWPS_FILTER1</c> structure is documented in the WDK.
		/// </para>
		/// </summary>
		public ulong providerContextId;
	}

	/// <summary>The <c>FWPM_PROVIDER_ENUM_TEMPLATE0</c> structure is used for enumerating providers.</summary>
	/// <remarks>
	/// <para>Currently, there is no way to limit the enumeration — all providers are returned.</para>
	/// <para>
	/// <c>FWPM_PROVIDER_ENUM_TEMPLATE0</c> is a specific implementation of FWPM_PROVIDER_ENUM_TEMPLATE. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_enum_template0 typedef struct
	// FWPM_PROVIDER_ENUM_TEMPLATE0_ { UINT64 reserved; } FWPM_PROVIDER_ENUM_TEMPLATE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER_ENUM_TEMPLATE0
	{
		/// <summary>Reserved for system use.</summary>
		public ulong reserved;
	}

	/// <summary>The <c>FWPM_PROVIDER_SUBSCRIPTION0</c> structure is used to subscribe for change notifications.</summary>
	/// <remarks>
	/// <para>Notifications are only dispatched for providers that match the template.</para>
	/// <para>If the template is <c>NULL</c>, it matches all providers.</para>
	/// <para>
	/// <c>FWPM_PROVIDER_SUBSCRIPTION0</c> is a specific implementation of FWPM_PROVIDER_SUBSCRIPTION. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider_subscription0 typedef struct
	// FWPM_PROVIDER_SUBSCRIPTION0_ { FWPM_PROVIDER_ENUM_TEMPLATE0 *enumTemplate; UINT32 flags; GUID sessionKey; } FWPM_PROVIDER_SUBSCRIPTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER_SUBSCRIPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER_SUBSCRIPTION0
	{
		/// <summary>
		/// <para>[unique]</para>
		/// <para>Enumeration template for limiting the subscription.</para>
		/// <para>See FWPM_PROVIDER_ENUM_TEMPLATE0 for more information.</para>
		/// </summary>
		public IntPtr _enumTemplate;

		/// <summary>
		/// <para>[unique]</para>
		/// <para>Enumeration template for limiting the subscription.</para>
		/// <para>See FWPM_PROVIDER_ENUM_TEMPLATE0 for more information.</para>
		/// </summary>
		public FWPM_PROVIDER_ENUM_TEMPLATE0? enumTemplate => _enumTemplate.ToNullableStructure<FWPM_PROVIDER_ENUM_TEMPLATE0>();

		/// <summary>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_ADD</c></term>
		/// <term>Subscribe to provider add notifications.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_DELETE</c></term>
		/// <term>Subscribe to provider delete notifications.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_SUBSCRIPTION_FLAG flags;

		/// <summary>Uniquely identifies the session.</summary>
		public Guid sessionKey;
	}

	/// <summary>The <c>FWPM_PROVIDER0</c> structure stores the state associated with a policy provider.</summary>
	/// <remarks>
	/// <c>FWPM_PROVIDER0</c> is a specific implementation of FWPM_PROVIDER. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_provider0 typedef struct FWPM_PROVIDER0_ { GUID
	// providerKey; FWPM_DISPLAY_DATA0 displayData; UINT32 flags; FWP_BYTE_BLOB providerData; wchar_t *serviceName; } FWPM_PROVIDER0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_PROVIDER0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_PROVIDER0
	{
		/// <summary>
		/// <para>Uniquely identifies the provider.</para>
		/// <para>If the GUID is zero-initialized in the call to Add, Base Filtering Engine (BFE) will generate one.</para>
		/// </summary>
		public Guid providerKey;

		/// <summary>Allows providers to be annotated in a human-readable form. The FWPM_DISPLAY_DATA0 structure is required.</summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>Bit flags that indicate information about the persistence of the provider.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Provider flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_PROVIDER_FLAG_PERSISTENT</c></term>
		/// <term>Provider is persistent.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_PROVIDER_FLAG_DISABLED</c></term>
		/// <term>
		/// Provider's filters were disabled when the BFE started because the provider has no associated Windows service name, or because the
		/// associated service was not set to auto-start.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_PROVIDER_FLAG flags;

		/// <summary>
		/// An FWP_BYTE_BLOB structure that contains optional provider-specific data that allows providers to store additional context info
		/// with the object.
		/// </summary>
		public FWP_BYTE_BLOB providerData;

		/// <summary>Optional name of the Windows service hosting the provider. This allows BFE to detect that a provider has been disabled.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? serviceName;
	}

	/// <summary>The <c>FWPM_SESSION_ENUM_TEMPLATE0</c> structure is used for enumerating sessions.</summary>
	/// <remarks>
	/// <para>Currently, there is no way to limit the enumeration — all sessions are returned.</para>
	/// <para>
	/// <c>FWPM_SESSION_ENUM_TEMPLATE0</c> is a specific implementation of FWPM_SESSION_ENUM_TEMPLATE. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_session_enum_template0 typedef struct
	// FWPM_SESSION_ENUM_TEMPLATE0_ { UINT64 reserved; } FWPM_SESSION_ENUM_TEMPLATE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SESSION_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_SESSION_ENUM_TEMPLATE0
	{
		/// <summary>Reserved for system use.</summary>
		public ulong reserved;
	}

	/// <summary>The <c>FWPM_SESSION0</c> structure stores the state associated with a client session.</summary>
	/// <remarks>
	/// <para>
	/// This structure contains information supplied by the client when creating a session by calling FwpmEngineOpen0, or information
	/// retrieved from the system when enumerating sessions by calling FwpmSessionEnum0.
	/// </para>
	/// <para>
	/// The members <c>processId</c>, <c>sid</c>, <c>username</c>, and <c>kernelMode</c> are not supplied by the client. They are supplied by
	/// BFE and can be retrieved when enumerating sessions.
	/// </para>
	/// <para>
	/// <c>FWPM_SESSION0</c> is a specific implementation of FWPM_SESSION. See WFP Version-Independent Names and Targeting Specific Versions
	/// of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_session0 typedef struct FWPM_SESSION0_ { GUID
	// sessionKey; FWPM_DISPLAY_DATA0 displayData; UINT32 flags; UINT32 txnWaitTimeoutInMSec; DWORD processId; SID *sid; wchar_t *username;
	// BOOL kernelMode; } FWPM_SESSION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SESSION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_SESSION0
	{
		/// <summary>
		/// <para>Uniquely identifies the session.</para>
		/// <para>If this member is zero in the call to FwpmEngineOpen0, Base Filtering Engine (BFE) will generate a GUID.</para>
		/// </summary>
		public Guid sessionKey;

		/// <summary>
		/// <para>Allows sessions to be annotated in a human-readable form.</para>
		/// <para>See FWPM_DISPLAY_DATA0 for more information.</para>
		/// </summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>Settings to control session behavior.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Session flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_SESSION_FLAG_DYNAMIC</c></term>
		/// <term>When this flag is set, any objects added during the session are automatically deleted when the session ends.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_SESSION_FLAG_RESERVED</c></term>
		/// <term>Reserved.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_SESSION_FLAG flags;

		/// <summary>
		/// <para>Time in milli-seconds that a client will wait to begin a transaction.</para>
		/// <para>If this member is zero, BFE will use a default timeout.</para>
		/// </summary>
		public uint txnWaitTimeoutInMSec;

		/// <summary>Process ID of the client.</summary>
		public uint processId;

		/// <summary>SID of the client.</summary>
		public PSID sid;

		/// <summary>User name of the client.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string username;

		/// <summary>TRUE if this is a kernel-mode client.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool kernelMode;
	}

	/// <summary>The <c>FWPM_STATISTICS0</c> structure stores statistics related to connections at specific layers.</summary>
	/// <remarks>
	/// <c>FWPM_STATISTICS0</c> is a specific implementation of FWPM_STATISTICS. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_statistics0 typedef struct FWPM_STATISTICS0_ { UINT32
	// numLayerStatistics; FWPM_LAYER_STATISTICS0 *layerStatistics; UINT32 inboundAllowedConnectionsV4; UINT32 inboundBlockedConnectionsV4;
	// UINT32 outboundAllowedConnectionsV4; UINT32 outboundBlockedConnectionsV4; UINT32 inboundAllowedConnectionsV6; UINT32
	// inboundBlockedConnectionsV6; UINT32 outboundAllowedConnectionsV6; UINT32 outboundBlockedConnectionsV6; UINT32
	// inboundActiveConnectionsV4; UINT32 outboundActiveConnectionsV4; UINT32 inboundActiveConnectionsV6; UINT32 outboundActiveConnectionsV6;
	// UINT64 reauthDirInbound; UINT64 reauthDirOutbound; UINT64 reauthFamilyV4; UINT64 reauthFamilyV6; UINT64 reauthProtoOther; UINT64
	// reauthProtoIPv4; UINT64 reauthProtoIPv6; UINT64 reauthProtoICMP; UINT64 reauthProtoICMP6; UINT64 reauthProtoUDP; UINT64
	// reauthProtoTCP; UINT64 reauthReasonPolicyChange; UINT64 reauthReasonNewArrivalInterface; UINT64 reauthReasonNewNextHopInterface;
	// UINT64 reauthReasonProfileCrossing; UINT64 reauthReasonClassifyCompletion; UINT64 reauthReasonIPSecPropertiesChanged; UINT64
	// reauthReasonMidStreamInspection; UINT64 reauthReasonSocketPropertyChanged; UINT64 reauthReasonNewInboundMCastBCastPacket; UINT64
	// reauthReasonEDPPolicyChanged; UINT64 reauthReasonProxyHandleChanged; } FWPM_STATISTICS0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_STATISTICS0
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of FWPM_LAYER_STATISTICS0 structures in the <c>layerStatistics</c> member.</para>
		/// </summary>
		public uint numLayerStatistics;

		/// <summary>
		/// <para>Type: FWPM_LAYER_STATISTICS0*</para>
		/// <para>Statistics related to the layer.</para>
		/// </summary>
		public IntPtr _layerStatistics;

		/// <summary>
		/// <para>Type: FWPM_LAYER_STATISTICS0*</para>
		/// <para>Statistics related to the layer.</para>
		/// </summary>
		public FWPM_LAYER_STATISTICS0? layerStatistics => _layerStatistics.ToNullableStructure<FWPM_LAYER_STATISTICS0>();

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of allowed IPv4 inbound connections.</para>
		/// </summary>
		public uint inboundAllowedConnectionsV4;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of blocked IPv4 inbound connections.</para>
		/// </summary>
		public uint inboundBlockedConnectionsV4;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of allowed IPv4 outbound connections.</para>
		/// </summary>
		public uint outboundAllowedConnectionsV4;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of blocked IPv4 outbound connections.</para>
		/// </summary>
		public uint outboundBlockedConnectionsV4;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of allowed IPv6 inbound connections.</para>
		/// </summary>
		public uint inboundAllowedConnectionsV6;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of blocked IPv6 inbound connections.</para>
		/// </summary>
		public uint inboundBlockedConnectionsV6;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of allowed IPv6 outbound connections.</para>
		/// </summary>
		public uint outboundAllowedConnectionsV6;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of blocked IPv6 outbound connections.</para>
		/// </summary>
		public uint outboundBlockedConnectionsV6;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of active IPv4 inbound connections.</para>
		/// </summary>
		public uint inboundActiveConnectionsV4;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of active IPv4 outbound connections.</para>
		/// </summary>
		public uint outboundActiveConnectionsV4;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of active IPv6 inbound connections.</para>
		/// </summary>
		public uint inboundActiveConnectionsV6;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of active IPv6 outbound connections.</para>
		/// </summary>
		public uint outboundActiveConnectionsV6;

		/// <summary/>
		public ulong reauthDirInbound;

		/// <summary/>
		public ulong reauthDirOutbound;

		/// <summary/>
		public ulong reauthFamilyV4;

		/// <summary/>
		public ulong reauthFamilyV6;

		/// <summary/>
		public ulong reauthProtoOther;

		/// <summary/>
		public ulong reauthProtoIPv4;

		/// <summary/>
		public ulong reauthProtoIPv6;

		/// <summary/>
		public ulong reauthProtoICMP;

		/// <summary/>
		public ulong reauthProtoICMP6;

		/// <summary/>
		public ulong reauthProtoUDP;

		/// <summary/>
		public ulong reauthProtoTCP;

		/// <summary/>
		public ulong reauthReasonPolicyChange;

		/// <summary/>
		public ulong reauthReasonNewArrivalInterface;

		/// <summary/>
		public ulong reauthReasonNewNextHopInterface;

		/// <summary/>
		public ulong reauthReasonProfileCrossing;

		/// <summary/>
		public ulong reauthReasonClassifyCompletion;

		/// <summary/>
		public ulong reauthReasonIPSecPropertiesChanged;

		/// <summary/>
		public ulong reauthReasonMidStreamInspection;

		/// <summary/>
		public ulong reauthReasonSocketPropertyChanged;

		/// <summary/>
		public ulong reauthReasonNewInboundMCastBCastPacket;

		/// <summary/>
		public ulong reauthReasonEDPPolicyChanged;

		/// <summary/>
		public ulong reauthReasonProxyHandleChanged;
	}

	/// <summary>The <c>FWPM_SUBLAYER_CHANGE0</c> structure specifies a change notification dispatched to subscribers.</summary>
	/// <remarks>
	/// <c>FWPM_SUBLAYER_CHANGE0</c> is a specific implementation of FWPM_SUBLAYER_CHANGE. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_sublayer_change0 typedef struct FWPM_SUBLAYER_CHANGE0_
	// { FWPM_CHANGE_TYPE changeType; GUID subLayerKey; } FWPM_SUBLAYER_CHANGE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SUBLAYER_CHANGE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_SUBLAYER_CHANGE0
	{
		/// <summary>Type of change as specified by FWPM_CHANGE_TYPE.</summary>
		public FWPM_CHANGE_TYPE changeType;

		/// <summary>GUID of the sublayer that changed.</summary>
		public Guid subLayerKey;
	}

	/// <summary>The <c>FWPM_SUBLAYER_ENUM_TEMPLATE0</c> structure is used for enumerating sublayers.</summary>
	/// <remarks>
	/// <c>FWPM_SUBLAYER_ENUM_TEMPLATE0</c> is a specific implementation of FWPM_SUBLAYER_ENUM_TEMPLATE. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_sublayer_enum_template0 typedef struct
	// FWPM_SUBLAYER_ENUM_TEMPLATE0_ { GUID *providerKey; } FWPM_SUBLAYER_ENUM_TEMPLATE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SUBLAYER_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_SUBLAYER_ENUM_TEMPLATE0
	{
		/// <summary>
		/// Uniquely identifies the provider associated with this sublayer. If this value is non-NULL, only options with the specifies
		/// provider will be returned.
		/// </summary>
		public GuidPtr providerKey;
	}

	/// <summary>The <c>FWPM_SUBLAYER_SUBSCRIPTION0</c> structure is used to subscribe for change notifications.</summary>
	/// <remarks>
	/// <para>Notifications are only dispatched for sublayers that match the template.</para>
	/// <para>If the template is <c>NULL</c>, it matches all sublayers.</para>
	/// <para>
	/// <c>FWPM_SUBLAYER_SUBSCRIPTION0</c> is a specific implementation of FWPM_SUBLAYER_SUBSCRIPTION. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_sublayer_subscription0 typedef struct
	// FWPM_SUBLAYER_SUBSCRIPTION0_ { FWPM_SUBLAYER_ENUM_TEMPLATE0 *enumTemplate; UINT32 flags; GUID sessionKey; } FWPM_SUBLAYER_SUBSCRIPTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SUBLAYER_SUBSCRIPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_SUBLAYER_SUBSCRIPTION0
	{
		/// <summary>
		/// <para>Enumeration template for limiting the subscription.</para>
		/// <para>See FWPM_SUBLAYER_ENUM_TEMPLATE0 for more information.</para>
		/// </summary>
		public IntPtr _enumTemplate;

		/// <summary>
		/// <para>Enumeration template for limiting the subscription.</para>
		/// <para>See FWPM_SUBLAYER_ENUM_TEMPLATE0 for more information.</para>
		/// </summary>
		public FWPM_SUBLAYER_ENUM_TEMPLATE0? enumTemplate => _enumTemplate.ToNullableStructure<FWPM_SUBLAYER_ENUM_TEMPLATE0>();

		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Subscription flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_ADD</c></term>
		/// <term>Subscribe to sublayer add notifications.</term>
		/// </item>
		/// <item>
		/// <term><c>FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_DELETE</c></term>
		/// <term>Subscribe to sublayer delete notifications.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_SUBSCRIPTION_FLAG flags;

		/// <summary>Uniquely identifies this session.</summary>
		public Guid sessionKey;
	}

	/// <summary>The <c>FWPM_SUBLAYER0</c> structure stores the state associated with a sublayer.</summary>
	/// <remarks>
	/// <c>FWPM_SUBLAYER0</c> is a specific implementation of FWPM_SUBLAYER. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_sublayer0 typedef struct FWPM_SUBLAYER0_ { GUID
	// subLayerKey; FWPM_DISPLAY_DATA0 displayData; UINT32 flags; GUID *providerKey; FWP_BYTE_BLOB providerData; UINT16 weight; } FWPM_SUBLAYER0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SUBLAYER0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_SUBLAYER0
	{
		/// <summary>
		/// <para>Uniquely identifies the sublayer. See Filtering Sublayer Identifiers for a list of built-in sublayers.</para>
		/// <para>If the GUID is zero-initialized in the call to FwpmSubLayerAdd0, the Base Filtering Engine (BFE) will generate one.</para>
		/// </summary>
		public Guid subLayerKey;

		/// <summary>Allows sublayers to be annotated in human-readable form. The FWPM_DISPLAY_DATA0 structure is required.</summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Sublayer flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FWPM_SUBLAYER_FLAG_PERSISTENT</c></term>
		/// <term>Causes sublayer to be persistent, surviving across BFE stop/start.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FWPM_SUBLAYER_FLAG flags;

		/// <summary>Uniquely identifies the provider that manages this sublayer.</summary>
		public GuidPtr providerKey;

		/// <summary>
		/// An FWP_BYTE_BLOB structure that contains optional provider-specific data that allows providers to store additional context info
		/// with the object.
		/// </summary>
		public FWP_BYTE_BLOB providerData;

		/// <summary>
		/// <para>Weight of the sublayer.</para>
		/// <para>Higher-weighted sublayers are invoked first.</para>
		/// </summary>
		public ushort weight;
	}

	/// <summary>The <c>FWPM_SYSTEM_PORTS_BY_TYPE0</c> structure contains information about the system ports of a specified type.</summary>
	/// <remarks>
	/// <c>FWPM_SYSTEM_PORTS_BY_TYPE0</c> is a specific implementation of FWPM_SYSTEM_PORTS_BY_TYPE. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_system_ports_by_type0 typedef struct
	// FWPM_SYSTEM_PORTS_BY_TYPE0_ { FWPM_SYSTEM_PORT_TYPE type; UINT32 numPorts; UINT16 *ports; } FWPM_SYSTEM_PORTS_BY_TYPE0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SYSTEM_PORTS_BY_TYPE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_SYSTEM_PORTS_BY_TYPE0
	{
		/// <summary>An FWPM_SYSTEM_PORT_TYPE enumeration that specifies the type of port.</summary>
		public FWPM_SYSTEM_PORT_TYPE type;

		/// <summary>The number of ports of the specified type.</summary>
		public uint numPorts;

		/// <summary>Array of IP port numbers ( <see cref="ushort"/>) for the specified type.</summary>
		public IntPtr ports;

		/// <summary>Array of IP port numbers ( <see cref="ushort"/>) for the specified type.</summary>
		public ushort[] GetPorts() => ports.ToArray<ushort>((int)numPorts) ?? new ushort[0];
	}

	/// <summary>The <c>FWPM_SYSTEM_PORTS0</c> structure contains information about all of the system ports of all types.</summary>
	/// <remarks>
	/// <c>FWPM_SYSTEM_PORTS0</c> is a specific implementation of FWPM_SYSTEM_PORTS. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_system_ports0 typedef struct FWPM_SYSTEM_PORTS0_ {
	// UINT32 numTypes; FWPM_SYSTEM_PORTS_BY_TYPE0 *types; } FWPM_SYSTEM_PORTS0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_SYSTEM_PORTS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_SYSTEM_PORTS0
	{
		/// <summary>The number of types in the array.</summary>
		public uint numTypes;

		/// <summary>A <see cref="FWPM_SYSTEM_PORTS_BY_TYPE0"/> structure that specifies the array of system port types.</summary>
		public IntPtr types;

		/// <summary>A <see cref="FWPM_SYSTEM_PORTS_BY_TYPE0"/> structure that specifies the array of system port types.</summary>
		public FWPM_SYSTEM_PORTS_BY_TYPE0[] GetTypes() => types.ToArray<FWPM_SYSTEM_PORTS_BY_TYPE0>((int)numTypes) ?? new FWPM_SYSTEM_PORTS_BY_TYPE0[0];
	}

	/// <summary>
	/// The <c>FWPM_VSWITCH_EVENT_SUBSCRIPTION0</c> structure stores information used to subscribe to notifications about a vSwitch event.
	/// </summary>
	/// <remarks>
	/// <c>FWPM_VSWITCH_EVENT_SUBSCRIPTION0</c> is a specific implementation of FWPM_VSWITCH_EVENT_SUBSCRIPTION. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmtypes/ns-fwpmtypes-fwpm_vswitch_event_subscription0 typedef struct
	// FWPM_VSWITCH_EVENT_SUBSCRIPTION0_ { UINT32 flags; GUID sessionKey; } FWPM_VSWITCH_EVENT_SUBSCRIPTION0;
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_VSWITCH_EVENT_SUBSCRIPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_VSWITCH_EVENT_SUBSCRIPTION0
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>This member is reserved for future use.</para>
		/// </summary>
		public uint flags;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>Identifies the session which created the subscription.</para>
		/// </summary>
		public Guid sessionKey;
	}

	/// <summary>The FWPM_VSWITCH_EVENT0 structure contains information about a vSwitch event.</summary>
	[PInvokeData("fwpmtypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_VSWITCH_EVENT0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWPM_VSWITCH_EVENT0
	{
		/// <summary>The type of vSwitch event.</summary>
		public FWPM_VSWITCH_EVENT_TYPE eventType;

		/// <summary>GUID that identifies a vSwitch.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string vSwitchId;

		internal _UNION union;

		/// <summary>Available when eventType is FWPM_VSWITCH_EVENT_FILTER_ADD_TO_FILTER_ENGINE_NOT_IN_REQUIRED_POSITION.</summary>
		public POSITIONINFO positionInfo => eventType == FWPM_VSWITCH_EVENT_TYPE.FWPM_VSWITCH_EVENT_FILTER_ENGINE_NOT_IN_REQUIRED_POSITION ? union.positionInfo : default;

		/// <summary>Available when eventType is FWPM_VSWITCH_EVENT_FILTER_ENGINE_REORDER.</summary>
		public REORDERINFO reorderInfo => eventType == FWPM_VSWITCH_EVENT_TYPE.FWPM_VSWITCH_EVENT_FILTER_ENGINE_REORDER ? union.reorderInfo : default;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		internal struct _UNION
		{
			/// <summary>The position information</summary>
			[FieldOffset(0)]
			public _POSITIONINFO positionInfo;

			/// <summary>The reorder information</summary>
			[FieldOffset(0)]
			public _REORDERINFO reorderInfo;
		}

		/// <summary>Available when eventType is FWPM_VSWITCH_EVENT_FILTER_ADD_TO_FILTER_ENGINE_NOT_IN_REQUIRED_POSITION.</summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct _POSITIONINFO
		{
			/// <summary>The number of vSwitch filter extensions.</summary>
			public uint numvSwitchFilterExtensions;

			/// <summary>Array of strings identifying other vSwitch extensions.</summary>
			public IntPtr vSwitchFilterExtensions;

			/// <summary/>
			public static implicit operator POSITIONINFO(_POSITIONINFO i) => new()
			{
				numvSwitchFilterExtensions = i.numvSwitchFilterExtensions,
				vSwitchFilterExtensions = i.vSwitchFilterExtensions.ToStringEnum((int)i.numvSwitchFilterExtensions, CharSet.Unicode).WhereNotNull().ToArray()
			};
		}

		/// <summary>Available when eventType is FWPM_VSWITCH_EVENT_FILTER_ENGINE_REORDER.</summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct _REORDERINFO
		{
			/// <summary>True if the filter engine is in the required position to correctly enforce committed filters; otherwise, false.</summary>
			public bool inRequiredPosition;

			/// <summary>The number of vSwitch filter extensions.</summary>
			public uint numvSwitchFilterExtensions;

			/// <summary>Array of strings identifying other vSwitch extensions.</summary>
			public IntPtr vSwitchFilterExtensions;

			/// <summary/>
			public static implicit operator REORDERINFO(_REORDERINFO i) => new()
			{
				inRequiredPosition = i.inRequiredPosition,
				numvSwitchFilterExtensions = i.numvSwitchFilterExtensions,
				vSwitchFilterExtensions = i.vSwitchFilterExtensions.ToStringEnum((int)i.numvSwitchFilterExtensions, CharSet.Unicode).WhereNotNull().ToArray()
			};
		}

		/// <summary>Available when eventType is FWPM_VSWITCH_EVENT_FILTER_ADD_TO_FILTER_ENGINE_NOT_IN_REQUIRED_POSITION.</summary>
		public struct POSITIONINFO
		{
			/// <summary>The number of vSwitch filter extensions.</summary>
			public uint numvSwitchFilterExtensions;

			/// <summary>Array of strings identifying other vSwitch extensions.</summary>
			public string[] vSwitchFilterExtensions;
		}

		/// <summary>Available when eventType is FWPM_VSWITCH_EVENT_FILTER_ENGINE_REORDER.</summary>
		public struct REORDERINFO
		{
			/// <summary>True if the filter engine is in the required position to correctly enforce committed filters; otherwise, false.</summary>
			public bool inRequiredPosition;

			/// <summary>The number of vSwitch filter extensions.</summary>
			public uint numvSwitchFilterExtensions;

			/// <summary>Array of strings identifying other vSwitch extensions.</summary>
			public string[] vSwitchFilterExtensions;
		}
	}
}