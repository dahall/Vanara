using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the P2P.dll</summary>
	public static partial class P2P
	{
		/// <summary/>
		public const int PNRP_MAX_ENDPOINT_ADDRESSES = 10;

		/// <summary/>
		public const int PNRP_MAX_EXTENDED_PAYLOAD_BYTES = 0x1000;

		/// <summary/>
		public const string WSZ_SCOPE_GLOBAL = "GLOBAL";

		/// <summary/>
		public const string WSZ_SCOPE_LINKLOCAL = "LINKLOCAL";

		/// <summary/>
		public const string WSZ_SCOPE_SITELOCAL = "SITELOCAL";

		/// <summary>The <c>PNRP_CLOUD_FLAGS</c> enumeration specifies the validity of a cloud name.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/pnrpdef/ne-pnrpdef-pnrp_cloud_flags typedef enum _PNRP_CLOUD_FLAGS {
		// PNRP_CLOUD_NO_FLAGS, PNRP_CLOUD_NAME_LOCAL, PNRP_CLOUD_RESOLVE_ONLY, PNRP_CLOUD_FULL_PARTICIPANT } PNRP_CLOUD_FLAGS;
		[PInvokeData("pnrpdef.h", MSDNShortId = "NE:pnrpdef._PNRP_CLOUD_FLAGS")]
		[Flags]
		public enum PNRP_CLOUD_FLAGS
		{
			/// <summary>The cloud name is valid on the network.</summary>
			PNRP_CLOUD_NO_FLAGS = 0x0,

			/// <summary>The cloud name is not valid on other computers.</summary>
			PNRP_CLOUD_NAME_LOCAL = 0x1,

			/// <summary>The cloud is configured to be resolve only. Names cannot be published to the cloud from this computer.</summary>
			PNRP_CLOUD_RESOLVE_ONLY = 0x2,

			/// <summary>This machine is a full participant in the cloud, and can publish and resolve names.</summary>
			PNRP_CLOUD_FULL_PARTICIPANT = 0x4,
		}

		/// <summary>The <c>PNRP_CLOUD_STATE</c> enumeration specifies the different states a PNRP cloud can be in.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/pnrpdef/ne-pnrpdef-pnrp_cloud_state typedef enum _PNRP_CLOUD_STATE {
		// PNRP_CLOUD_STATE_VIRTUAL, PNRP_CLOUD_STATE_SYNCHRONISING, PNRP_CLOUD_STATE_ACTIVE, PNRP_CLOUD_STATE_DEAD,
		// PNRP_CLOUD_STATE_DISABLED, PNRP_CLOUD_STATE_NO_NET, PNRP_CLOUD_STATE_ALONE } PNRP_CLOUD_STATE;
		[PInvokeData("pnrpdef.h", MSDNShortId = "NE:pnrpdef._PNRP_CLOUD_STATE")]
		public enum PNRP_CLOUD_STATE
		{
			/// <summary>The cloud is not yet initialized.</summary>
			PNRP_CLOUD_STATE_VIRTUAL = 0,

			/// <summary>The cloud is in the process of being initialized.</summary>
			PNRP_CLOUD_STATE_SYNCHRONISING,

			/// <summary>The cloud is active.</summary>
			PNRP_CLOUD_STATE_ACTIVE,

			/// <summary>The cloud is initialized, but has lost its connection to the network.</summary>
			PNRP_CLOUD_STATE_DEAD,

			/// <summary>The cloud is disabled in the registry.</summary>
			PNRP_CLOUD_STATE_DISABLED,

			/// <summary>
			/// The cloud was active, but has lost access to the network. In this state the cloud can still be used for registration but it
			/// is not capable of resolving addresses.
			/// </summary>
			PNRP_CLOUD_STATE_NO_NET,

			/// <summary>
			/// The local node bootstrapped, but found no other nodes in the cloud. This can also be the result of a network issue, like a
			/// firewall, preventing the local node from locating other nodes within the cloud. It is also important to note that a cloud in
			/// the PNRP_CLOUD_STATE_ALONE state may not have registered IP addresses.
			/// </summary>
			PNRP_CLOUD_STATE_ALONE,
		}

		/// <summary/>
		[PInvokeData("pnrpdef.h")]
		public enum PNRP_EXTENDED_PAYLOAD_TYPE
		{
			/// <summary/>
			PNRP_EXTENDED_PAYLOAD_TYPE_NONE = 0,

			/// <summary/>
			PNRP_EXTENDED_PAYLOAD_TYPE_BINARY,

			/// <summary/>
			PNRP_EXTENDED_PAYLOAD_TYPE_STRING,
		}

		/// <summary>Registered name state.</summary>
		[PInvokeData("pnrpdef.h")]
		public enum PNRP_REGISTERED_ID_STATE
		{
			/// <summary>Id is active in cloud</summary>
			PNRP_REGISTERED_ID_STATE_OK = 1,

			/// <summary>Id is no longer registered in cloud</summary>
			PNRP_REGISTERED_ID_STATE_PROBLEM = 2
		}

		/// <summary>The <c>PNRP_RESOLVE_CRITERIA</c> enumeration specifies the criteria that PNRP uses to resolve searches.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/pnrpdef/ne-pnrpdef-pnrp_resolve_criteria typedef enum _PNRP_RESOLVE_CRITERIA {
		// PNRP_RESOLVE_CRITERIA_DEFAULT, PNRP_RESOLVE_CRITERIA_REMOTE_PEER_NAME, PNRP_RESOLVE_CRITERIA_NEAREST_REMOTE_PEER_NAME,
		// PNRP_RESOLVE_CRITERIA_NON_CURRENT_PROCESS_PEER_NAME, PNRP_RESOLVE_CRITERIA_NEAREST_NON_CURRENT_PROCESS_PEER_NAME,
		// PNRP_RESOLVE_CRITERIA_ANY_PEER_NAME, PNRP_RESOLVE_CRITERIA_NEAREST_PEER_NAME } PNRP_RESOLVE_CRITERIA;
		[PInvokeData("pnrpdef.h", MSDNShortId = "NE:pnrpdef._PNRP_RESOLVE_CRITERIA")]
		public enum PNRP_RESOLVE_CRITERIA
		{
			/// <summary>
			/// Use the PNRP_RESOLVE_CRITERIA_NON_CURRENT_PROCESS_PEER_NAME criteria. This is also the default behavior if PNRPINFO is not specified.
			/// </summary>
			PNRP_RESOLVE_CRITERIA_DEFAULT = 0,

			/// <summary>Match a peer name. The resolve request excludes any peer name registered locally on this computer.</summary>
			PNRP_RESOLVE_CRITERIA_REMOTE_PEER_NAME,

			/// <summary>
			/// Match a peer name by finding the name with a service location closest to the supplied hint, or if no hint is supplied,
			/// closest to the local IP address. The resolve request excludes any peer name registered locally on this computer.
			/// </summary>
			PNRP_RESOLVE_CRITERIA_NEAREST_REMOTE_PEER_NAME,

			/// <summary>
			/// Match a peer name. The matching peer name can be registered locally or remotely, but the resolve request excludes any peer
			/// name registered by the process making the resolve request.
			/// </summary>
			PNRP_RESOLVE_CRITERIA_NON_CURRENT_PROCESS_PEER_NAME,

			/// <summary>
			/// Match a peer name by finding the name with a service location closest to the supplied hint, or if no hint is supplied,
			/// closest to the local IP address. The matching peer name can be registered locally or remotely, but the resolve request
			/// excludes any peer name registered by the process making the resolve request.
			/// </summary>
			PNRP_RESOLVE_CRITERIA_NEAREST_NON_CURRENT_PROCESS_PEER_NAME,

			/// <summary>Match a peer name. The matching peer name can be registered locally or remotely.</summary>
			PNRP_RESOLVE_CRITERIA_ANY_PEER_NAME,

			/// <summary>
			/// Match a peer name by finding the name with a service location closest to the supplied hint, or if no hint is supplied,
			/// closest to the local IP address. The matching peer name can be registered locally or remotely.
			/// </summary>
			PNRP_RESOLVE_CRITERIA_NEAREST_PEER_NAME,
		}

		/// <summary>Specifies the scope under which the peer group was registered.</summary>
		[PInvokeData("pnrpdef.h")]
		public enum PNRP_SCOPE
		{
			/// <summary>Any scope.</summary>
			PNRP_SCOPE_ANY = 0,    //  Any

			/// <summary>Global scope, including the Internet.</summary>
			PNRP_GLOBAL_SCOPE = 1,    //  global

			/// <summary>Local scope.</summary>
			PNRP_SITE_LOCAL_SCOPE = 2,    //  site local

			/// <summary>Link-local scope.</summary>
			PNRP_LINK_LOCAL_SCOPE = 3     //  link local
		}

		/// <summary>The <c>PNRP_CLOUD_ID</c> structure contains the values that define a network cloud.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/pnrpdef/ns-pnrpdef-pnrp_cloud_id typedef struct _PNRP_CLOUD_ID { INT
		// AddressFamily; PNRP_SCOPE Scope; ULONG ScopeId; } PNRP_CLOUD_ID, *PPNRP_CLOUD_ID;
		[PInvokeData("pnrpdef.h", MSDNShortId = "NS:pnrpdef._PNRP_CLOUD_ID")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PNRP_CLOUD_ID
		{
			/// <summary>Must be AF_INET6.</summary>
			public System.Net.Sockets.AddressFamily AddressFamily;

			/// <summary>
			/// <para>Specifies the scope of the cloud. Use one of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>PNRP_SCOPE_ANY</term>
			/// <term>The cloud can be in any scope.</term>
			/// </item>
			/// <item>
			/// <term>PNRP_GLOBAL_SCOPE</term>
			/// <term>The cloud must be a global scope.</term>
			/// </item>
			/// <item>
			/// <term>PNRP_SITE_LOCAL_SCOPE</term>
			/// <term>The cloud must be a site-local scope.</term>
			/// </item>
			/// <item>
			/// <term>PNRP_LINK_LOCAL_SCOPE</term>
			/// <term>The cloud must be a link-local scope.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PNRP_SCOPE Scope;

			/// <summary>Specifies the ID for this scope.</summary>
			public uint ScopeId;
		}
	}
}