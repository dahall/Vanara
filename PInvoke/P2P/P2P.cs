using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke;

/// <summary>Items from the P2P.dll</summary>
public static partial class P2P
{
	private const string Lib_P2P = "p2p.dll";
	private const string Lib_P2PGraph = "p2pgraph.dll";

	/// <summary/>
	public static readonly Guid PEER_GROUP_ROLE_ADMIN = new(0x04387127, 0xaa56, 0x450a, 0x8c, 0xe5, 0x4f, 0x56, 0x5c, 0x67, 0x90, 0xf4);
	/// <summary/>
	public static readonly Guid PEER_GROUP_ROLE_MEMBER = new(0xf12dc4c7, 0x0857, 0x4ca0, 0x93, 0xfc, 0xb1, 0xbb, 0x19, 0xa3, 0xd8, 0xc2);
	/// <summary/>
	public static readonly Guid PEER_GROUP_ROLE_INVITING_MEMBER = new(0x4370fd89, 0xdc18, 0x4cfb, 0x8d, 0xbf, 0x98, 0x53, 0xa8, 0xa9, 0xf9, 0x05);
	/// <summary/>
	public static readonly Guid PEER_COLLAB_OBJECTID_USER_PICTURE = new(0xdd15f41f, 0xfc4e, 0x4922, 0xb0, 0x35, 0x4c, 0x06, 0xa7, 0x54, 0xd0, 0x1d);


	/// <summary>The <c>PEER_APPLICATION_REGISTRATION_TYPE</c> enumeration defines the set of peer application registration flags.</summary>
	/// <remarks>
	/// <para>
	/// "Peer application" defines the set of software applications or components available for use with the peer collaboration network.
	/// The peer collaboration network enables participants in the network to initiate usage of this application.
	/// </para>
	/// <para>
	/// Applications with the same GUID and registered for the <c>current user</c> take precedence over applications with that same GUID
	/// registered for <c>all users</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_application_registration_type typedef enum
	// peer_application_registration_type_tag { PEER_APPLICATION_CURRENT_USER, PEER_APPLICATION_ALL_USERS } PEER_APPLICATION_REGISTRATION_TYPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_application_registration_type_tag")]
	public enum PEER_APPLICATION_REGISTRATION_TYPE
	{
		/// <summary>The application is available only to the current user account logged into the machine.</summary>
		PEER_APPLICATION_CURRENT_USER,

		/// <summary>The application is available to all user accounts set on the machine.</summary>
		PEER_APPLICATION_ALL_USERS,
	}

	/// <summary>
	/// The <c>PEER_CHANGE_TYPE</c> enumeration defines the set of changes that were performed on a peer object, endpoint, or
	/// application in a peer event. It is used to qualify the peer event associated with the change type.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_change_type typedef enum peer_change_type_tag {
	// PEER_CHANGE_ADDED, PEER_CHANGE_DELETED, PEER_CHANGE_UPDATED } PEER_CHANGE_TYPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_change_type_tag")]
	public enum PEER_CHANGE_TYPE
	{
		/// <summary>The peer object, endpoint, or application has been added.</summary>
		PEER_CHANGE_ADDED,

		/// <summary>The peer object, endpoint, or application has been deleted.</summary>
		PEER_CHANGE_DELETED,

		/// <summary>The peer object, endpoint, or application has been updated with new information.</summary>
		PEER_CHANGE_UPDATED,
	}

	/// <summary>
	/// The <c>PEER_COLLAB_EVENT_TYPE</c> enumeration defines the set of events that can be raised on a peer by the peer collaboration
	/// network event infrastructure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_collab_event_type typedef enum peer_collab_event_type_tag {
	// PEER_EVENT_WATCHLIST_CHANGED, PEER_EVENT_ENDPOINT_CHANGED, PEER_EVENT_ENDPOINT_PRESENCE_CHANGED,
	// PEER_EVENT_ENDPOINT_APPLICATION_CHANGED, PEER_EVENT_ENDPOINT_OBJECT_CHANGED, PEER_EVENT_MY_ENDPOINT_CHANGED,
	// PEER_EVENT_MY_PRESENCE_CHANGED, PEER_EVENT_MY_APPLICATION_CHANGED, PEER_EVENT_MY_OBJECT_CHANGED,
	// PEER_EVENT_PEOPLE_NEAR_ME_CHANGED, PEER_EVENT_REQUEST_STATUS_CHANGED } PEER_COLLAB_EVENT_TYPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_collab_event_type_tag")]
	public enum PEER_COLLAB_EVENT_TYPE
	{
		/// <summary>The peer's list of watched contacts has changed.</summary>
		PEER_EVENT_WATCHLIST_CHANGED = 1,

		/// <summary>The endpoint has changed.</summary>
		PEER_EVENT_ENDPOINT_CHANGED,

		/// <summary>The presence status of an endpoint has changed.</summary>
		PEER_EVENT_ENDPOINT_PRESENCE_CHANGED,

		/// <summary>The registered application of the endpoint has changed.</summary>
		PEER_EVENT_ENDPOINT_APPLICATION_CHANGED,

		/// <summary>A peer object registered to the endpoint has changed.</summary>
		PEER_EVENT_ENDPOINT_OBJECT_CHANGED,

		/// <summary>The local peer's endpoint has changed.</summary>
		PEER_EVENT_MY_ENDPOINT_CHANGED,

		/// <summary>The local peer's presence status has changed.</summary>
		PEER_EVENT_MY_PRESENCE_CHANGED,

		/// <summary>The local peer's registered application has changed.</summary>
		PEER_EVENT_MY_APPLICATION_CHANGED,

		/// <summary>A peer object registered with the local peer has changed.</summary>
		PEER_EVENT_MY_OBJECT_CHANGED,

		/// <summary>An endpoint in the same subnet as the local peer's endpoint has changed.</summary>
		PEER_EVENT_PEOPLE_NEAR_ME_CHANGED,

		/// <summary>The status of a request to refresh endpoint data or subscribe to endpoint data has changed.</summary>
		PEER_EVENT_REQUEST_STATUS_CHANGED,
	}

	/// <summary>The <c>PEER_CONNECTION_FLAGS</c> enumeration specifies the types of connections that a peer can have.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_connection_flags typedef enum peer_connection_flags_tag {
	// PEER_CONNECTION_NEIGHBOR, PEER_CONNECTION_DIRECT } PEER_CONNECTION_FLAGS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_connection_flags_tag")]
	[Flags]
	public enum PEER_CONNECTION_FLAGS
	{
		/// <summary>Specifies that a connection is a neighbor connection.</summary>
		PEER_CONNECTION_NEIGHBOR = 0x0001,

		/// <summary>Specifies that a connection is a direct connection to another node.</summary>
		PEER_CONNECTION_DIRECT = 0x0002,
	}

	/// <summary>The <c>PEER_CONNECTION_STATUS</c> enumeration specifies the status of a peer direct or neighbor connection.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_connection_status typedef enum peer_connection_status_tag {
	// PEER_CONNECTED, PEER_DISCONNECTED, PEER_CONNECTION_FAILED } PEER_CONNECTION_STATUS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_connection_status_tag")]
	public enum PEER_CONNECTION_STATUS
	{
		/// <summary>The peer is connected to another peer.</summary>
		PEER_CONNECTED = 1,

		/// <summary>The peer has disconnected from another peer.</summary>
		PEER_DISCONNECTED,

		/// <summary>The peer failed to connect to another peer.</summary>
		PEER_CONNECTION_FAILED,
	}

	/// <summary>The <c>PEER_GRAPH_EVENT_TYPE</c> enumeration specifies peer event types the application is to be notified for.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_graph_event_type typedef enum peer_graph_event_type_tag {
	// PEER_GRAPH_EVENT_STATUS_CHANGED, PEER_GRAPH_EVENT_PROPERTY_CHANGED, PEER_GRAPH_EVENT_RECORD_CHANGED,
	// PEER_GRAPH_EVENT_DIRECT_CONNECTION, PEER_GRAPH_EVENT_NEIGHBOR_CONNECTION, PEER_GRAPH_EVENT_INCOMING_DATA,
	// PEER_GRAPH_EVENT_CONNECTION_REQUIRED, PEER_GRAPH_EVENT_NODE_CHANGED, PEER_GRAPH_EVENT_SYNCHRONIZED } PEER_GRAPH_EVENT_TYPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_graph_event_type_tag")]
	public enum PEER_GRAPH_EVENT_TYPE
	{
		/// <summary>The peer graph status has changed in some manner. For example, the node has synchronized with the peer graph.</summary>
		PEER_GRAPH_EVENT_STATUS_CHANGED = 1,

		/// <summary>
		/// A field in the peer graph property structure has changed. This peer event does not generate a specific piece of data for an
		/// application to retrieve. The application must use PeerGraphGetProperties to obtain the updated structure.
		/// </summary>
		PEER_GRAPH_EVENT_PROPERTY_CHANGED,

		/// <summary>A record type or specific record has changed in some manner.</summary>
		PEER_GRAPH_EVENT_RECORD_CHANGED,

		/// <summary>A peer's direct connection has changed.</summary>
		PEER_GRAPH_EVENT_DIRECT_CONNECTION,

		/// <summary>A connection to a peer neighbor has changed.</summary>
		PEER_GRAPH_EVENT_NEIGHBOR_CONNECTION,

		/// <summary>Data has been received from a direct or neighbor connection.</summary>
		PEER_GRAPH_EVENT_INCOMING_DATA,

		/// <summary>
		/// The peer graph has become unstable. The client should call PeerGraphConnect on a new node. This peer event does not generate
		/// a specific piece of data for an application to retrieve.
		/// </summary>
		PEER_GRAPH_EVENT_CONNECTION_REQUIRED,

		/// <summary>A node's presence status has changed in the peer graph.</summary>
		PEER_GRAPH_EVENT_NODE_CHANGED,

		/// <summary>A specific record type has been synchronized.</summary>
		PEER_GRAPH_EVENT_SYNCHRONIZED,
	}

	/// <summary>The <c>PEER_GRAPH_PROPERTY_FLAGS</c> enumeration specifies properties of a peer graph.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_graph_property_flags typedef enum
	// peer_graph_property_flags_tag { PEER_GRAPH_PROPERTY_HEARTBEATS, PEER_GRAPH_PROPERTY_DEFER_EXPIRATION } PEER_GRAPH_PROPERTY_FLAGS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_graph_property_flags_tag")]
	[Flags]
	public enum PEER_GRAPH_PROPERTY_FLAGS
	{
		/// <summary>Reserved.</summary>
		PEER_GRAPH_PROPERTY_HEARTBEATS = 0x01,

		/// <summary>Graph records are not expired until the peer connects with a graph.</summary>
		PEER_GRAPH_PROPERTY_DEFER_EXPIRATION = 0x02,
	}

	/// <summary>The <c>PEER_GRAPH_SCOPE</c> enumeration specifies the network scope of a peer graph.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_graph_scope typedef enum peer_graph_scope_tag {
	// PEER_GRAPH_SCOPE_ANY, PEER_GRAPH_SCOPE_GLOBAL, PEER_GRAPH_SCOPE_SITELOCAL, PEER_GRAPH_SCOPE_LINKLOCAL, PEER_GRAPH_SCOPE_LOOPBACK
	// } PEER_GRAPH_SCOPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_graph_scope_tag")]
	public enum PEER_GRAPH_SCOPE
	{
		/// <summary>The peer graph's network scope can contain any IP address, valid or otherwise.</summary>
		PEER_GRAPH_SCOPE_ANY = 0,

		/// <summary>The IP addresses for the peer graph's network scope can be from any unblocked address range.</summary>
		PEER_GRAPH_SCOPE_GLOBAL,

		/// <summary>The IP addresses for the peer graph's network scope must be within the IP range defined for the site.</summary>
		PEER_GRAPH_SCOPE_SITELOCAL,

		/// <summary>The IP addresses for the peer graph's network scope must be within the IP range defined for the local area network.</summary>
		PEER_GRAPH_SCOPE_LINKLOCAL,

		/// <summary>The peer graph's network scope is the local computer's loopback IP address.</summary>
		PEER_GRAPH_SCOPE_LOOPBACK,
	}

	/// <summary>
	/// The <c>PEER_GRAPH_STATUS_FLAGS</c> enumeration is a set of flags that show the current status of a node within the peer graph.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_graph_status_flags typedef enum peer_graph_status_flags_tag {
	// PEER_GRAPH_STATUS_LISTENING, PEER_GRAPH_STATUS_HAS_CONNECTIONS, PEER_GRAPH_STATUS_SYNCHRONIZED } PEER_GRAPH_STATUS_FLAGS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_graph_status_flags_tag")]
	[Flags]
	public enum PEER_GRAPH_STATUS_FLAGS
	{
		/// <summary>Specifies whether or not the node is listening for connections.</summary>
		PEER_GRAPH_STATUS_LISTENING = 0x0001,

		/// <summary>Specifies whether or not the node has connections to other nodes.</summary>
		PEER_GRAPH_STATUS_HAS_CONNECTIONS = 0x0002,

		/// <summary>Specifies whether or not the node's database is synchronized.</summary>
		PEER_GRAPH_STATUS_SYNCHRONIZED = 0x0004,
	}

	/// <summary>
	/// The <c>PEER_GROUP_AUTHENTICATION_SCHEME</c> enumeration defines the set of possible authentication schemes that can be used to
	/// authenticate peers joining a peer group.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_group_authentication_scheme typedef enum
	// peer_group_authentication_scheme_tag { PEER_GROUP_GMC_AUTHENTICATION, PEER_GROUP_PASSWORD_AUTHENTICATION } PEER_GROUP_AUTHENTICATION_SCHEME;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_group_authentication_scheme_tag")]
	[Flags]
	public enum PEER_GROUP_AUTHENTICATION_SCHEME
	{
		/// <summary>Authentication is performed using Group Membership Certificates (GMC).</summary>
		PEER_GROUP_GMC_AUTHENTICATION = 0x00000001,

		/// <summary>Authentication is performed by validating a provided password.</summary>
		PEER_GROUP_PASSWORD_AUTHENTICATION = 0x00000002,
	}

	/// <summary>
	/// The <c>PEER_GROUP_EVENT_TYPE</c> enumeration contains the specific peer event types that can occur within a peer group.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_group_event_type typedef enum peer_group_event_type_tag {
	// PEER_GROUP_EVENT_STATUS_CHANGED, PEER_GROUP_EVENT_PROPERTY_CHANGED, PEER_GROUP_EVENT_RECORD_CHANGED,
	// PEER_GROUP_EVENT_DIRECT_CONNECTION, PEER_GROUP_EVENT_NEIGHBOR_CONNECTION, PEER_GROUP_EVENT_INCOMING_DATA,
	// PEER_GROUP_EVENT_MEMBER_CHANGED, PEER_GROUP_EVENT_CONNECTION_FAILED, PEER_GROUP_EVENT_AUTHENTICATION_FAILED } PEER_GROUP_EVENT_TYPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_group_event_type_tag")]
	public enum PEER_GROUP_EVENT_TYPE
	{
		/// <summary>
		/// The status of the group has changed. This peer event is fired when one of the flags listed in the PEER_GROUP_STATUS
		/// enumeration are set or changed for the group.
		/// </summary>
		PEER_GROUP_EVENT_STATUS_CHANGED = 1,

		/// <summary>A member in the PEER_GROUP_EVENT_DATA to retrieve.</summary>
		PEER_GROUP_EVENT_PROPERTY_CHANGED,

		/// <summary>A group record has changed. Information on this change is provided in the PEER_GROUP_EVENT_DATA.</summary>
		PEER_GROUP_EVENT_RECORD_CHANGED,

		/// <summary>The status of a direct connection has changed. Information on this change is provided in the PEER_GROUP_EVENT_DATA.</summary>
		PEER_GROUP_EVENT_DIRECT_CONNECTION,

		/// <summary>The status of a neighbor connection has changed. Information on this change is provided in the PEER_GROUP_EVENT_DATA.</summary>
		PEER_GROUP_EVENT_NEIGHBOR_CONNECTION,

		/// <summary>
		/// Incoming direct connection data from a member is detected. Information on this peer event is provided in the PEER_GROUP_EVENT_DATA.
		/// </summary>
		PEER_GROUP_EVENT_INCOMING_DATA,

		/// <summary>The status of a member has changed. Information on this change is provided in the PEER_GROUP_EVENT_DATA.</summary>
		PEER_GROUP_EVENT_MEMBER_CHANGED = 8,

		/// <summary>
		/// The connection to the peer group has failed. No data is provided when this peer event is raised. This event is also raised
		/// if no members are online in a group you are attempting to connect to for the first time.
		/// </summary>
		PEER_GROUP_EVENT_CONNECTION_FAILED = 10,

		/// <summary/>
		PEER_GROUP_EVENT_AUTHENTICATION_FAILED = 11,
	}

	/// <summary>The <c>PEER_GROUP_ISSUE_CREDENTIAL_FLAGS</c> are used to specify if user credentials are stored within a group.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_group_issue_credential_flags typedef enum
	// peer_issue_credential_flags_tag { PEER_GROUP_STORE_CREDENTIALS } PEER_GROUP_ISSUE_CREDENTIAL_FLAGS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_issue_credential_flags_tag")]
	[Flags]
	public enum PEER_GROUP_ISSUE_CREDENTIAL_FLAGS
	{
		/// <summary>
		/// When the PEER_GROUP_STORE_CREDENTIALS flag is set, the user credentials are stored within a group database to be retrieved
		/// when the user connects. If the flag is not set, any new credentials are returned in string form and must be passed to the
		/// user out-of-band.
		/// </summary>
		PEER_GROUP_STORE_CREDENTIALS = 0x0001,
	}

	/// <summary>The <c>PEER_GROUP_PROPERTY_FLAGS</c> flags are used to specify various peer group membership settings.</summary>
	/// <remarks>These flags can only be set by the peer group creator.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_group_property_flags typedef enum
	// peer_group_property_flags_tag { PEER_MEMBER_DATA_OPTIONAL, PEER_DISABLE_PRESENCE, PEER_DEFER_EXPIRATION } PEER_GROUP_PROPERTY_FLAGS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_group_property_flags_tag")]
	public enum PEER_GROUP_PROPERTY_FLAGS
	{
		/// <summary>
		/// A peer's member data (PEER_MEMBER) is only published when an action if performed, such as publishing a record or issuing a
		/// GMC. If the peer has not performed one of these actions, the membership data will not be available.
		/// </summary>
		PEER_MEMBER_DATA_OPTIONAL = 0x0001,

		/// <summary>The peer presence system is prevented from automatically publishing presence information.</summary>
		PEER_DISABLE_PRESENCE = 0x0002,

		/// <summary>Group records are not expired until the peer connects with a group.</summary>
		PEER_DEFER_EXPIRATION = 0x0004,
	}

	/// <summary>The <c>PEER_GROUP_STATUS</c> flags indicate whether or not the peer group has connections present.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_group_status typedef enum peer_group_status_tag {
	// PEER_GROUP_STATUS_LISTENING, PEER_GROUP_STATUS_HAS_CONNECTIONS } PEER_GROUP_STATUS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_group_status_tag")]
	[Flags]
	public enum PEER_GROUP_STATUS
	{
		/// <summary>The peer group is awaiting new connections.</summary>
		PEER_GROUP_STATUS_LISTENING = 0x0001,

		/// <summary>The peer group has at least one connection.</summary>
		PEER_GROUP_STATUS_HAS_CONNECTIONS = 0x0002,
	}

	/// <summary>
	/// The <c>PEER_INVITATION_RESPONSE_TYPE</c> enumeration defines the type of response received to an invitation to start a Peer
	/// Collaboration activity.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_invitation_response_type typedef enum
	// peer_invitation_response_type_tag { PEER_INVITATION_RESPONSE_DECLINED, PEER_INVITATION_RESPONSE_ACCEPTED,
	// PEER_INVITATION_RESPONSE_EXPIRED, PEER_INVITATION_RESPONSE_ERROR } PEER_INVITATION_RESPONSE_TYPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_invitation_response_type_tag")]
	public enum PEER_INVITATION_RESPONSE_TYPE
	{
		/// <summary>The invitation was declined by the peer.</summary>
		PEER_INVITATION_RESPONSE_DECLINED,

		/// <summary>The invitation was accepted by the peer.</summary>
		PEER_INVITATION_RESPONSE_ACCEPTED,

		/// <summary>The invitation has expired.</summary>
		PEER_INVITATION_RESPONSE_EXPIRED,

		/// <summary>An error occurred during the invitation process.</summary>
		PEER_INVITATION_RESPONSE_ERROR,
	}

	/// <summary>
	/// The <c>PEER_MEMBER_CHANGE_TYPE</c> enumeration defines the set of possible peer group membership and presence states for a peer.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_member_change_type typedef enum peer_member_change_type_tag {
	// PEER_MEMBER_CONNECTED, PEER_MEMBER_DISCONNECTED, PEER_MEMBER_UPDATED, PEER_MEMBER_JOINED, PEER_MEMBER_LEFT } PEER_MEMBER_CHANGE_TYPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_member_change_type_tag")]
	public enum PEER_MEMBER_CHANGE_TYPE
	{
		/// <summary>A member is connected to a peer group.</summary>
		PEER_MEMBER_CONNECTED = 1,

		/// <summary>A member is disconnected from a peer group.</summary>
		PEER_MEMBER_DISCONNECTED,

		/// <summary>A member has updated information (for example, a new address) within a peer group.</summary>
		PEER_MEMBER_UPDATED,

		/// <summary>
		/// New membership information is published for a group member. The peer name of a peer group member is obtained from the
		/// pwzIdentity field of the PEER_EVENT_MEMBER_CHANGE_DATA structure. New membership information is published in one of the
		/// following three scenarios:
		/// </summary>
		PEER_MEMBER_JOINED,

		/// <summary>This peer event does not exist in the Peer Grouping Infrastructure v1.0, and must not be used.</summary>
		PEER_MEMBER_LEFT,
	}

	/// <summary>
	/// The <c>PEER_MEMBER_FLAGS</c> flag allows an application to specify whether all members or only present ones should be enumerated
	/// when the PeerGroupEnumMembers function is called, or to indicate whether or not a member is present within the peer group.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_member_flags typedef enum peer_member_flags_tag {
	// PEER_MEMBER_PRESENT } PEER_MEMBER_FLAGS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_member_flags_tag")]
	[Flags]
	public enum PEER_MEMBER_FLAGS
	{
		/// <summary>The member is present in the peer group.</summary>
		PEER_MEMBER_PRESENT = 0x01,
	}

	/// <summary>The <c>PEER_NODE_CHANGE_TYPE</c> enumeration specifies the types of peer node graph status changes.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_node_change_type typedef enum peer_node_change_type_tag {
	// PEER_NODE_CHANGE_CONNECTED, PEER_NODE_CHANGE_DISCONNECTED, PEER_NODE_CHANGE_UPDATED } PEER_NODE_CHANGE_TYPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_node_change_type_tag")]
	public enum PEER_NODE_CHANGE_TYPE
	{
		/// <summary>The peer node has connected to the graph.</summary>
		PEER_NODE_CHANGE_CONNECTED = 1,

		/// <summary>The peer node has disconnected from the graph.</summary>
		PEER_NODE_CHANGE_DISCONNECTED,

		/// <summary>The peer node's status within the graph has changed.</summary>
		PEER_NODE_CHANGE_UPDATED,
	}

	/// <summary>
	/// The <c>PEER_PRESENCE_STATUS</c> enumeration defines the set of possible presence status settings available to a peer that
	/// participates in a peer collaboration network. These settings can be set by a peer collaboration network endpoint to indicate the
	/// peer's current level of participation to its watchers.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_presence_status typedef enum peer_presence_status_tag {
	// PEER_PRESENCE_OFFLINE, PEER_PRESENCE_OUT_TO_LUNCH, PEER_PRESENCE_AWAY, PEER_PRESENCE_BE_RIGHT_BACK, PEER_PRESENCE_IDLE,
	// PEER_PRESENCE_BUSY, PEER_PRESENCE_ON_THE_PHONE, PEER_PRESENCE_ONLINE } PEER_PRESENCE_STATUS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_presence_status_tag")]
	public enum PEER_PRESENCE_STATUS
	{
		/// <summary>The user is offline.</summary>
		PEER_PRESENCE_OFFLINE,

		/// <summary>The user is currently "out to lunch" and unable to respond.</summary>
		PEER_PRESENCE_OUT_TO_LUNCH,

		/// <summary>The user is away and unable to respond.</summary>
		PEER_PRESENCE_AWAY,

		/// <summary>The user has stepped away from the application and will participate soon.</summary>
		PEER_PRESENCE_BE_RIGHT_BACK,

		/// <summary>The user is idling.</summary>
		PEER_PRESENCE_IDLE,

		/// <summary>The user is busy and does not wish to be disturbed.</summary>
		PEER_PRESENCE_BUSY,

		/// <summary>The user is currently on the phone and does not wish to be disturbed.</summary>
		PEER_PRESENCE_ON_THE_PHONE,

		/// <summary>The user is actively participating in the peer collaboration network.</summary>
		PEER_PRESENCE_ONLINE,
	}

	/// <summary>The <c>PEER_PUBLICATION_SCOPE</c> enumeration defines the set of scopes for the publication of peer objects or data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_publication_scope typedef enum peer_publication_scope_tag {
	// PEER_PUBLICATION_SCOPE_NONE, PEER_PUBLICATION_SCOPE_NEAR_ME, PEER_PUBLICATION_SCOPE_INTERNET, PEER_PUBLICATION_SCOPE_ALL } PEER_PUBLICATION_SCOPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_publication_scope_tag")]
	[Flags]
	public enum PEER_PUBLICATION_SCOPE
	{
		/// <summary>No scope is set for the publication of this data.</summary>
		PEER_PUBLICATION_SCOPE_NONE = 0x0,

		/// <summary>The data is published to peers in the same logical or virtual subnet.</summary>
		PEER_PUBLICATION_SCOPE_NEAR_ME = 0x1,

		/// <summary>The data is published to peers on the Internet.</summary>
		PEER_PUBLICATION_SCOPE_INTERNET = 0x2,

		/// <summary>The data is published to all peers.</summary>
		PEER_PUBLICATION_SCOPE_ALL = PEER_PUBLICATION_SCOPE_NEAR_ME | PEER_PUBLICATION_SCOPE_INTERNET,
	}

	/// <summary>The <c>PEER_RECORD_CHANGE_TYPE</c> enumeration specifies the changes that can occur to a record.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_record_change_type typedef enum peer_record_change_type_tag {
	// PEER_RECORD_ADDED, PEER_RECORD_UPDATED, PEER_RECORD_DELETED, PEER_RECORD_EXPIRED } PEER_RECORD_CHANGE_TYPE;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_record_change_type_tag")]
	public enum PEER_RECORD_CHANGE_TYPE
	{
		/// <summary>Indicates that the specified record is added to the peer graph or group.</summary>
		PEER_RECORD_ADDED = 1,

		/// <summary>Indicates that the specified record is updated in the peer graph or group.</summary>
		PEER_RECORD_UPDATED,

		/// <summary>Indicates that the specified record is deleted from the peer graph or group.</summary>
		PEER_RECORD_DELETED,

		/// <summary>Indicates that the specified record is expired and removed from the peer graph or group.</summary>
		PEER_RECORD_EXPIRED,
	}

	/// <summary>The <c>PEER_RECORD_FLAGS</c> enumeration specifies a set of flags for peer record behaviors.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_record_flags typedef enum peer_record_flags_tag {
	// PEER_RECORD_FLAG_AUTOREFRESH, PEER_RECORD_FLAG_DELETED } PEER_RECORD_FLAGS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_record_flags_tag")]
	[Flags]
	public enum PEER_RECORD_FLAGS
	{
		/// <summary>The peer record must be automatically refreshed any time an event for the record is raised.</summary>
		PEER_RECORD_FLAG_AUTOREFRESH = 0x0001,

		/// <summary>The peer record is marked for deletion but has not yet been physically removed from the local computer.</summary>
		PEER_RECORD_FLAG_DELETED = 0x0002,
	}

	/// <summary>
	/// The <c>PEER_SIGNIN_FLAGS</c> enumeration defines the set of peer presence publication behaviors available when the peer signs in
	/// to a peer collaboration network.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_signin_flags typedef enum peer_signin_flags_tag {
	// PEER_SIGNIN_NONE, PEER_SIGNIN_NEAR_ME, PEER_SIGNIN_INTERNET, PEER_SIGNIN_ALL } PEER_SIGNIN_FLAGS;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_signin_flags_tag")]
	[Flags]
	public enum PEER_SIGNIN_FLAGS
	{
		/// <summary>A peer's presence is not being published in any scope.</summary>
		PEER_SIGNIN_NONE = 0x0,

		/// <summary>
		/// The peer can publish availability information to endpoints in the same subnet or local area network, or query for other
		/// endpoints available on the subnet.
		/// </summary>
		PEER_SIGNIN_NEAR_ME = 0x1,

		/// <summary>The peer can publish presence, applications, and objects to all contacts in a peer's contact list.</summary>
		PEER_SIGNIN_INTERNET = 0x2,

		/// <summary>
		/// The peer can publish presence, applications, and objects to all contacts in a peer's contact list, or query for other
		/// endpoints available on the subnet.
		/// </summary>
		PEER_SIGNIN_ALL = PEER_SIGNIN_NEAR_ME | PEER_SIGNIN_INTERNET,
	}

	/// <summary>
	/// The <c>PEER_WATCH_PERMISSION</c> enumeration defines whether a peer contact can receive presence updates from a contact.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ne-p2p-peer_watch_permission typedef enum peer_watch_permission_tag {
	// PEER_WATCH_BLOCKED, PEER_WATCH_ALLOWED } PEER_WATCH_PERMISSION;
	[PInvokeData("p2p.h", MSDNShortId = "NE:p2p.peer_watch_permission_tag")]
	public enum PEER_WATCH_PERMISSION
	{
		/// <summary>The peer contact cannot receive presence updates.</summary>
		PEER_WATCH_BLOCKED,

		/// <summary>The peer contact can receive presence updates.</summary>
		PEER_WATCH_ALLOWED,
	}

	/// <summary>Provides a handle to a Peer Graph.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HGRAPH : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HGRAPH"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HGRAPH(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HGRAPH"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HGRAPH NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HGRAPH"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HGRAPH h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HGRAPH"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGRAPH(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HGRAPH h1, HGRAPH h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HGRAPH h1, HGRAPH h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HGRAPH h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>The <c>PEER_ADDRESS</c> structure specifies the information about the IP address.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_address typedef struct peer_address_tag { DWORD dwSize;
	// SOCKADDR_IN6 sin6; } PEER_ADDRESS, *PEER_ADDRESS*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_address_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_ADDRESS
	{
		/// <summary>Specifies the size of this structure.</summary>
		public uint dwSize;

		/// <summary>Specifies the IP address of the node in the Peer Infrastructure.</summary>
		public SOCKADDR_IN6 sin6;
	}

	/// <summary>
	/// The <c>PEER_APP_LAUNCH_INFO</c> structure contains the peer application application launch information provided by a contact in
	/// a previous peer invite request.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_app_launch_info typedef struct peer_app_launch_info_tag {
	// PEER_CONTACT* pContact; PEER_ENDPOINT* pEndpoint; PEER_INVITATION* pInvitation; } PEER_APP_LAUNCH_INFO, *PEER_APP_LAUNCH_INFO*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_app_launch_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_APP_LAUNCH_INFO
	{
		/// <summary>
		/// Pointer to a PEER_CONTACT structure that contains information about the contact that sent the request to the local peer to
		/// launch the application referenced by the application.
		/// </summary>
		public IntPtr pContact;

		/// <summary>
		/// Pointer to a PEER_ENDPOINT structure that contains information about the specific endpoint of the contact that sent the
		/// request to the local peer to launch the application referenced by the application
		/// </summary>
		public IntPtr pEndpoint;

		/// <summary>
		/// Pointer to the PEER_INVITATION structure that contains the invitation to launch a specific peer application application on
		/// the local peer.
		/// </summary>
		public IntPtr pInvitation;
	}

	/// <summary>
	/// The <c>PEER_APPLICATION</c> structure contains data describing a locally installed software application or component that can be
	/// registered and shared with trusted contacts within a peer collaboration network.
	/// </summary>
	/// <remarks>
	/// <para>
	/// An "application" is a set of software or software features available on the peer's endpoint. Commonly, this refers to software
	/// packages that support peer networking activities, like games or other collaborative applications.
	/// </para>
	/// <para>
	/// A peer application has a GUID representing a single specific application. When an application is registered for a peer, this
	/// GUID and the corresponding application can be made available to all trusted contacts of the peer, indicating the activities the
	/// peer can participate in. To deregister a peer application, call PeerCollabUnregisterApplication with this GUID.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_application typedef struct peer_application_tag { GUID id;
	// PEER_DATA data; PWSTR pwzDescription; } PEER_APPLICATION, *PEER_APPLICATION*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_application_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_APPLICATION
	{
		/// <summary>The GUID value under which the application is registered with the local computer.</summary>
		public Guid id;

		/// <summary>
		/// PEER_DATA structure that contains the application information in a member byte buffer. This information is available to
		/// anyone who can query for the local peer's member information. This data is limited to 16K.
		/// </summary>
		public PEER_DATA data;

		/// <summary>
		/// Pointer to a zero-terminated Unicode string that contains an optional description of the local application. This description
		/// is limited to 255 unicode characters.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzDescription;
	}

	/// <summary>
	/// The <c>PEER_APPLICATION_REGISTRATION_INFO</c> structure contains peer application information for registration with the local computer.
	/// </summary>
	/// <remarks>
	/// <para>
	/// An "application" is a set of software or software components available on the peer's endpoint. Commonly, this refers to software
	/// packages that support peer networking activities, like games or other collaborative applications.
	/// </para>
	/// <para>
	/// A peer application has a GUID representing a single specific application. When an application is registered for a peer, this
	/// GUID and the corresponding application can be made available to all trusted contacts of the peer, indicating the activities the
	/// peer can participate in. To deregister a peer's application, call PeerCollabUnregisterApplication with this GUID.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_application_registration_info typedef struct
	// peer_application_registration_info_tag { PEER_APPLICATION application; PWSTR pwzApplicationToLaunch; PWSTR
	// pwzApplicationArguments; DWORD dwPublicationScope; } PEER_APPLICATION_REGISTRATION_INFO, *PEER_APPLICATION_REGISTRATION_INFO*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_application_registration_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_APPLICATION_REGISTRATION_INFO
	{
		/// <summary>PEER_APPLICATION structure that contains the specific peer application data.</summary>
		public PEER_APPLICATION application;

		/// <summary>
		/// Zero-terminated Unicode string that contains the local path to the executable peer application. Note that this data is for
		/// local use only and that this structure is never transmitted remotely.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzApplicationToLaunch;

		/// <summary>
		/// Zero-terminated Unicode string that contains command-line arguments that must be supplied to the application when the
		/// application is launched. This data is for local use only. The PEER_APPLICATION_REGISTRATION_INFO structure is never
		/// transmitted remotely.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzApplicationArguments;

		/// <summary>
		/// PEER_PUBLICATION_SCOPE enumeration value that specifies the publication scope for this application registration information.
		/// The only valid value for this member is PEER_PUBLICATION_SCOPE_INTERNET.
		/// </summary>
		public PEER_PUBLICATION_SCOPE dwPublicationScope;
	}

	/// <summary>
	/// The <c>PEER_COLLAB_EVENT_DATA</c> union contains variant data for each possible peer collaboration network event raised on a peer.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_collab_event_data-r1 typedef struct peer_collab_event_data_tag
	// { PEER_COLLAB_EVENT_TYPE eventType; union { PEER_EVENT_WATCHLIST_CHANGED_DATA watchListChangedData;
	// PEER_EVENT_PRESENCE_CHANGED_DATA presenceChangedData; PEER_EVENT_APPLICATION_CHANGED_DATA applicationChangedData;
	// PEER_EVENT_OBJECT_CHANGED_DATA objectChangedData; PEER_EVENT_ENDPOINT_CHANGED_DATA endpointChangedData;
	// PEER_EVENT_PEOPLE_NEAR_ME_CHANGED_DATA peopleNearMeChangedData; PEER_EVENT_REQUEST_STATUS_CHANGED_DATA requestStatusChangedData;
	// }; } PEER_COLLAB_EVENT_DATA, *PEER_COLLAB_EVENT_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_collab_event_data_tag~r1")]
	[StructLayout(LayoutKind.Explicit)]
	public struct PEER_COLLAB_EVENT_DATA
	{
		/// <summary>
		/// PEER_COLLAB_EVENT_TYPE enumeration value that contains the type of the event whose corresponding data structure appears in
		/// the subsequent union arm.
		/// </summary>
		[FieldOffset(0)]
		public PEER_COLLAB_EVENT_TYPE eventType;

		/// <summary>
		/// A PEER_EVENT_WATCHLIST_CHANGED_DATA structure. This data structure is present when <c>eventType</c> is set to PEER_EVENT_WATCHLIST_CHANGED.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_WATCHLIST_CHANGED_DATA watchListChangedData;

		/// <summary>
		/// A PEER_EVENT_PRESENCE_CHANGED_DATA structure. This data structure is present when <c>eventType</c> is set to
		/// PEER_EVENT_ENDPOINT_PRESENCE_CHANGED or PEER_EVENT_MY_PRESENCE_CHANGED.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_PRESENCE_CHANGED_DATA presenceChangedData;

		/// <summary>
		/// A PEER_EVENT_APPLICATION_CHANGED_DATA structure. This data structure is present when <c>eventType</c> is set to
		/// PEER_EVENT_ENDPOINT_APPLICATION_CHANGED or PEER_EVENT_MY_APPLICATION_CHANGED.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_APPLICATION_CHANGED_DATA applicationChangedData;

		/// <summary>
		/// A PEER_EVENT_OBJECT_CHANGED_DATA structure. This data structure is present when <c>eventType</c> is set to
		/// PEER_EVENT_ENDPOINT_OBJECT_CHANGED or PEER_EVENT_MY_OBJECT_CHANGED.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_OBJECT_CHANGED_DATA objectChangedData;

		/// <summary>
		/// A PEER_EVENT_ENDPOINT_CHANGED_DATA structure. This data structure is present when <c>eventType</c> is set to
		/// PEER_EVENT_ENDPOINT_CHANGED or PEER_EVENT_MY_ENDPOINT_CHANGED.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_ENDPOINT_CHANGED_DATA endpointChangedData;

		/// <summary>
		/// A PEER_EVENT_PEOPLE_NEAR_ME_CHANGED_DATA structure. This data structure is present when <c>eventType</c> is set to PEER_EVENT_PEOPLE_NEAR_ME_CHANGED.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_PEOPLE_NEAR_ME_CHANGED_DATA peopleNearMeChangedData;

		/// <summary>
		/// A PEER_EVENT_REQUEST_STATUS_CHANGED_DATA structure. This data structure is present when <c>eventType</c> is set to PEER_EVENT_REQUEST_STATUS_CHANGED.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_REQUEST_STATUS_CHANGED_DATA requestStatusChangedData;
	}

	/// <summary>
	/// The <c>PEER_COLLAB_EVENT_REGISTRATION</c> structure contains the data used by a peer to register for specific peer collaboration
	/// network events.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_collab_event_registration typedef struct
	// peer_collab_event_registration_tag { PEER_COLLAB_EVENT_TYPE eventType; GUID *pInstance; } PEER_COLLAB_EVENT_REGISTRATION, *PEER_COLLAB_EVENT_REGISTRATION*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_collab_event_registration_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_COLLAB_EVENT_REGISTRATION
	{
		/// <summary>
		/// PEER_COLLAB_EVENT_TYPE enumeration value that specifies the type of peer collaboration network event for which to register.
		/// </summary>
		public PEER_COLLAB_EVENT_TYPE eventType;

		/// <summary>
		/// <para>GUID value that uniquely identifies the application or object that registers for the specific event.</para>
		/// <para>
		/// This parameter is valid only for PEER_EVENT_ENDPOINT_APPLICATION_CHANGED, PEER_EVENT_ENDPOINT_OBJECT_CHANGED,
		/// PEER_EVENT_MY_APPLICATION_CHANGED, and PEER_EVENT_MY_OBJECT_CHANGED. This GUID represents the application ID for
		/// application-specific events, and the object ID for object-specific events.
		/// </para>
		/// <para>When <c></c> this member is set, notification will be sent only for the specific application or object.</para>
		/// </summary>
		public GuidPtr pInstance;
	}

	/// <summary>
	/// The <c>PEER_CONNECTION_INFO</c> structure contains information about a connection. This structure is returned when you are
	/// enumerating peer graphing or grouping connections.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_connection_info typedef struct peer_connection_info_tag {
	// DWORD dwSize; DWORD dwFlags; ULONGLONG ullConnectionId; ULONGLONG ullNodeId; PWSTR pwzPeerId; PEER_ADDRESS address; } PEER_CONNECTION_INFO;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_connection_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_CONNECTION_INFO
	{
		/// <summary>Specifies the size a structure.</summary>
		public uint dwSize;

		/// <summary>Specifies the type of connection to a remote node. Valid values are specified by PEER_CONNECTION_FLAGS.</summary>
		public PEER_CONNECTION_FLAGS dwFlags;

		/// <summary>Specifies the unique ID of a connection.</summary>
		public ulong ullConnectionId;

		/// <summary>Specifies the unique ID of a node.</summary>
		public ulong ullNodeId;

		/// <summary>Points to a string that identifies the node on the other end of a connection.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzPeerId;

		/// <summary>Specifies the address of a remote node. The address is contained in a PEER_ADDRESS structure.</summary>
		public PEER_ADDRESS address;
	}

	/// <summary>The <c>PEER_CONTACT</c> structure contains information about a specific contact.</summary>
	/// <remarks>
	/// "Contacts" are peers participating in a peer collaboration network who publish presence information available to the local peer.
	/// This associated information enables the peer application to "watch" them for updates and peer application or object status
	/// changes. Lists of contacts are maintained by the peer collaboration infrastructure, and specific status change events are raised
	/// for each individual contact in the list.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_contact typedef struct peer_contact_tag { PWSTR pwzPeerName;
	// PWSTR pwzNickName; PWSTR pwzDisplayName; PWSTR pwzEmailAddress; BOOL fWatch; PEER_WATCH_PERMISSION WatcherPermissions; PEER_DATA
	// credentials; } PEER_CONTACT, *PEER_CONTACT*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_contact_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_CONTACT
	{
		/// <summary>
		/// Zero-terminated Unicode string that contains the peer name of the contact. This is the unique identifier for a contact.
		/// There can only be a single contact associated with any given peername.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzPeerName;

		/// <summary>
		/// <para>
		/// Zero-terminated Unicode string that contains the nickname of the contact and can be modified at any time. This is used when
		/// the peer collaboration scope is set to People Near Me. It is advertised in People Near Me and seen by recipients of sent invitations.
		/// </para>
		/// <para>This member is limited to 255 unicode characters.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzNickName;

		/// <summary>
		/// <para>
		/// Zero-terminated Unicode string that contains the display name of the contact. This corresponds to the display name seen for
		/// the contact in a peer's contacts folder.
		/// </para>
		/// <para>This member is limited to 255 unicode characters.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzDisplayName;

		/// <summary>Zero-terminated Unicode string that contains the email address of the contact.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzEmailAddress;

		/// <summary>If true, the contact is watched by the peer; if false, it is not.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fWatch;

		/// <summary>PEER_WATCH_PERMISSION enumeration value that specifies the watch permissions for this contact.</summary>
		public PEER_WATCH_PERMISSION WatcherPermissions;

		/// <summary>PEER_DATA structure that contains the security credentials for the contact in an opaque byte buffer.</summary>
		public PEER_DATA credentials;
	}

	/// <summary>The <c>PEER_CREDENTIAL_INFO</c> structure defines information used to obtain and issue a peer's security credentials.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_credential_info typedef struct peer_credential_info_tag {
	// DWORD dwSize; DWORD dwFlags; PWSTR pwzFriendlyName; CERT_PUBLIC_KEY_INFO *pPublicKey; PWSTR pwzIssuerPeerName; PWSTR
	// pwzIssuerFriendlyName; FILETIME ftValidityStart; FILETIME ftValidityEnd; ULONG cRoles; PEER_ROLE_ID *pRoles; }
	// PEER_CREDENTIAL_INFO, *PEER_CREDENTIAL_INFO*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_credential_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_CREDENTIAL_INFO
	{
		/// <summary>Specifies the size of this structure, in bytes.</summary>
		public uint dwSize;

		/// <summary>Reserved. This field must be set to 0.</summary>
		public uint dwFlags;

		/// <summary>Pointer to a Unicode string that specifies the friendly (display) name of the issuer.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzFriendlyName;

		/// <summary>
		/// Pointer to a <c>CERT_PUBLIC_KEY_INFO</c> structure that contains the peer group member's public key and the encryption type
		/// it uses.
		/// </summary>
		public IntPtr pPublicKey;

		/// <summary>Pointer to a Unicode string that specifies the membership issuer's PNRP name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzIssuerPeerName;

		/// <summary>Pointer to a Unicode string that specifies the friendly (display) name of the issuer.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzIssuerFriendlyName;

		/// <summary>
		/// Specifies the FILETIME structure that contains the time when the recipient's membership in the peer group becomes valid.
		/// When issuing new credentials this value must be greater than the ValidityStart value for the member's current credentials.
		/// </summary>
		public FILETIME ftValidityStart;

		/// <summary>
		/// Specifies the FILETIME structure that contains the time when the recipient's membership in the peer group becomes invalid.
		/// </summary>
		public FILETIME ftValidityEnd;

		/// <summary>Specifies the number of role GUIDs present in <c>pRoles</c>.</summary>
		public uint cRoles;

		/// <summary>
		/// <para>Pointer to a list of GUIDs that specifies the combined set of available roles. The available roles are as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_GROUP_ROLE_ADMIN</term>
		/// <term>
		/// This role can issue invitations, issue credentials, and renew the GMC of other administrators, as well as behave as a member
		/// of the peer group.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_GROUP_ROLE_MEMBER</term>
		/// <term>The role can add records to the peer group database.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IntPtr pRoles;
	}

	/// <summary>The <c>PEER_DATA</c> structure contains binary data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_data typedef struct peer_data_tag { ULONG cbData; PBYTE
	// pbData; } PEER_DATA, *PEER_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_DATA
	{
		/// <summary>
		/// Size of <c>pbData</c>, in bytes. It is possible for this value to be set to zero if <c>pbData</c> contains no data.
		/// </summary>
		public uint cbData;

		/// <summary>Pointer to a buffer.</summary>
		public IntPtr pbData;
	}

	/// <summary>The <c>PEER_ENDPOINT</c> structure contains the address and friendly name of a peer endpoint.</summary>
	/// <remarks>
	/// <para>
	/// A peer "endpoint" describes a contact's presence location — the unique network address configuration that describes the
	/// currently available instance of the contact within the peer collaboration network. A single contact can be available at multiple
	/// endpoints within the peer collaboration network.
	/// </para>
	/// <para>
	/// A peer watching a contact can query any of the endpoints associated with that contact for specific peer presence, application,
	/// or object updates.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_endpoint typedef struct peer_endpoint_tag { PEER_ADDRESS
	// address; PWSTR pwzEndpointName; } PEER_ENDPOINT, *PEER_ENDPOINT*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_endpoint_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_ENDPOINT
	{
		/// <summary>PEER_ADDRESS structure that contains the IPv6 network address of the endpoint.</summary>
		public PEER_ADDRESS address;

		/// <summary>Zero-terminated Unicode string that contains the specific displayable name of the endpoint.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzEndpointName;
	}

	/// <summary>
	/// The <c>PEER_EVENT_APPLICATION_CHANGED_DATA</c> structure contains information returned when a
	/// PEER_EVENT_ENDPOINT_APPLICATION_CHANGED or PEER_EVENT_MY_APPLICATION_CHANGED event is raised on a peer participating in a peer
	/// collaboration network.
	/// </summary>
	/// <remarks>
	/// <para>
	/// "Application" is a set of software or software features available on the peer's endpoint. Commonly, this refers to software
	/// packages that support peer networking activities, like games or other collaborative applications.
	/// </para>
	/// <para>
	/// A peer's application has a GUID representing a single specific application. When an application is registered for a peer, this
	/// GUID and the corresponding application can be made available to all trusted contacts of the peer, indicating the activities the
	/// peer can participate in. To deregister a peer's application, call PeerCollabUnregisterApplication with this GUID.
	/// </para>
	/// <para>
	/// When a new application is registered locally using PeerCollabRegisterApplication or unregistered using
	/// PeerCollabUnregisterApplication all peers subscribed to the local peer's presence information receive the
	/// PEER_EVENT_ENDPOINT_APPLICATION_CHANGED event. Locally, applications receive the PEER_EVENT_MY_APPLICATION_CHANGED event.
	/// </para>
	/// <para>
	/// The <c>current user</c> scope has priority over the <c>all user</c> scope. If the application is registered in both scopes, the
	/// event will be fired only if the <c>current user</c> scope is changed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_application_changed_data typedef struct
	// peer_event_application_changed_data_tag { PEER_CONTACT* pContact; PEER_ENDPOINT* pEndpoint; PEER_CHANGE_TYPE changeType;
	// PEER_APPLICATION* pApplication; } PEER_EVENT_APPLICATION_CHANGED_DATA, *PEER_EVENT_APPLICATION_CHANGED_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_application_changed_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_APPLICATION_CHANGED_DATA
	{
		/// <summary>
		/// Pointer to a PEER_CONTACT structure that contains the peer contact information for a contact whose change in application
		/// raised the event.
		/// </summary>
		public IntPtr pContact;

		/// <summary>
		/// Pointer to a PEER_ENDPOINT structure that contains the peer endpoint information for a contact whose change in application
		/// information raised the event.
		/// </summary>
		public IntPtr pEndpoint;

		/// <summary>PEER_CHANGE_TYPE enumeration value that specifies the type of application change that occurred.</summary>
		public PEER_CHANGE_TYPE changeType;

		/// <summary>Pointer to a PEER_APPLICATION structure that contains the changed application information.</summary>
		public IntPtr pApplication;
	}

	/// <summary>
	/// <para>
	/// A PEER_GRAPH_EVENT_DATA structure points to the <c>PEER_EVENT_CONNECTION_CHANGE_DATA</c> structure if one of the following peer
	/// events is triggered:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>PEER_GRAPH_EVENT_NEIGHBOR_CONNECTION</c></term>
	/// </item>
	/// <item>
	/// <term><c>PEER_GRAPH_EVENT_DIRECT_CONNECTION</c></term>
	/// </item>
	/// <item>
	/// <term><c>PEER_GROUP_EVENT_NEIGHBOR_CONNECTION</c></term>
	/// </item>
	/// <item>
	/// <term><c>PEER_GROUP_EVENT_DIRECT_CONNECTION</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>PEER_EVENT_CONNECTION_CHANGE_DATA</c> structure contains updated information that includes changes to a neighbor or
	/// direct connection.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_connection_change_data typedef struct
	// peer_event_connection_change_data_tag { DWORD dwSize; PEER_CONNECTION_STATUS status; ULONGLONG ullConnectionId; ULONGLONG
	// ullNodeId; ULONGLONG ullNextConnectionId; HRESULT hrConnectionFailedReason; } PEER_EVENT_CONNECTION_CHANGE_DATA, *PEER_EVENT_CONNECTION_CHANGE_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_connection_change_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_CONNECTION_CHANGE_DATA
	{
		/// <summary>Specifies the size of a structure.</summary>
		public uint dwSize;

		/// <summary>
		/// <para>Specifies the type of change in a neighbor or direct connection. Valid values are the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_CONNECTED</term>
		/// <term>A new incoming or outgoing connection to the local node has been established.</term>
		/// </item>
		/// <item>
		/// <term>PEER_CONNECTION_FAILED</term>
		/// <term>
		/// An attempt to connect to a local node has failed. It is possible for a single attempt to connect to result in multiple
		/// connection failures. This will occur after the initial connection failure, when the peer infrastructure sets the
		/// ullNextConnectionId member to the Node ID and attempts a new connection. If the ullNextConnectionId member is 0, no further
		/// connections will be attempted.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_DISCONNECTED</term>
		/// <term>An existing connection has been disconnected.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PEER_CONNECTION_STATUS status;

		/// <summary>Specifies the unique ID for a connection that has changed.</summary>
		public ulong ullConnectionId;

		/// <summary>Specifies the unique ID for the node that has changed.</summary>
		public ulong ullNodeId;

		/// <summary/>
		public ulong ullNextConnectionId;

		/// <summary>
		/// <para>
		/// <c>Windows Vista or later.</c> Specifies the type of error when a connection fails. <c>hrConnectionFailedReason</c> can
		/// return the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_E_CONNECTION_REFUSED</term>
		/// <term>
		/// A connection has been established and refused. The remote node is already at maximum number of connections or a connection
		/// already exists.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_CONNECTION_FAILED</term>
		/// <term>An attempt to connect to a remote node has failed.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_CONNECTION_NOT_AUTHENTICATED</term>
		/// <term>
		/// A connection is lost during the authentication phase. This is the result of a network failure or the remote node breaking
		/// the connection.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public HRESULT hrConnectionFailedReason;
	}

	/// <summary>
	/// The <c>PEER_EVENT_ENDPOINT_CHANGED_DATA</c> structure contains information returned when a PEER_EVENT_ENDPOINT_CHANGED or
	/// PEER_EVENT_MY_ENDPOINT_CHANGED event is raised on a peer participating in a peer collaboration network.
	/// </summary>
	/// <remarks>
	/// This event is raised when information about the endpoint changes. An example of this being the endpoint name in PEER_ENDPOINT
	/// structure is changed using PeerCollabSetEndpointName.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_endpoint_changed_data typedef struct
	// peer_event_endpoint_changed_data_tag { PEER_CONTACT* pContact; PEER_ENDPOINT* pEndpoint; } PEER_EVENT_ENDPOINT_CHANGED_DATA, *PEER_EVENT_ENDPOINT_CHANGED_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_endpoint_changed_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_ENDPOINT_CHANGED_DATA
	{
		/// <summary>Pointer to a PEER_CONTACT structure that contains the contact information for the contact who changed endpoints.</summary>
		public IntPtr pContact;

		/// <summary>Pointer to a PEER_ENDPOINT structure that contains the new active endpoint for the peer specified in pContact.</summary>
		public IntPtr pEndpoint;
	}

	/// <summary>
	/// <para>
	/// The PEER_GROUP_EVENT_DATA structure points to the <c>PEER_EVENT_INCOMING_DATA</c> structure if one of the following peer events
	/// is triggered:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>PEER_GRAPH_INCOMING_DATA</c></term>
	/// </item>
	/// <item>
	/// <term><c>PEER_GROUP_INCOMING_DATA</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>PEER_EVENT_INCOMING_DATA</c> structure contains updated information that includes data changes a node receives from a
	/// neighbor or direct connection.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_incoming_data typedef struct
	// peer_event_incoming_data_tag { DWORD dwSize; ULONGLONG ullConnectionId; GUID type; PEER_DATA data; } PEER_EVENT_INCOMING_DATA, *PEER_EVENT_INCOMING_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_incoming_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_INCOMING_DATA
	{
		/// <summary>Specifies the size of a structure.</summary>
		public uint dwSize;

		/// <summary>Specifies the unique ID of a data connection.</summary>
		public ulong ullConnectionId;

		/// <summary>Specifies the application-defined data type of incoming data.</summary>
		public Guid type;

		/// <summary>Specifies the actual data received.</summary>
		public PEER_DATA data;
	}

	/// <summary>
	/// The <c>PEER_EVENT_MEMBER_CHANGE_DATA</c> structure contains data that describes a change in the status of a peer group member.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_member_change_data typedef struct
	// peer_event_member_change_data_tag { DWORD dwSize; PEER_MEMBER_CHANGE_TYPE changeType; PWSTR pwzIdentity; }
	// PEER_EVENT_MEMBER_CHANGE_DATA, *PEER_EVENT_MEMBER_CHANGE_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_member_change_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_MEMBER_CHANGE_DATA
	{
		/// <summary>Contains the size of this structure, in bytes.</summary>
		public uint dwSize;

		/// <summary>
		/// <c>PEER_MEMBER_CHANGE_TYPE</c> enumeration value that specifies the change event that occurred, such as a member joining or leaving.
		/// </summary>
		public PEER_MEMBER_CHANGE_TYPE changeType;

		/// <summary>Pointer to a Unicode string that contains the peer name of the peer group member.</summary>
		public StrPtrUni pwzIdentity;
	}

	/// <summary>
	/// The <c>PEER_EVENT_NODE_CHANGE_DATA</c> structure contains a pointer to the data if a <c>PEER_GRAPH_EVENT_NODE_CHANGE</c> event
	/// is triggered.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_node_change_data typedef struct
	// peer_event_node_change_data_tag { DWORD dwSize; PEER_NODE_CHANGE_TYPE changeType; ULONGLONG ullNodeId; PWSTR pwzPeerId; }
	// PEER_EVENT_NODE_CHANGE_DATA, *PEER_EVENT_NODE_CHANGE_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_node_change_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_NODE_CHANGE_DATA
	{
		/// <summary>Specifies the size of the structure. Should set to the size of PEER_EVENT_NODE_CHANGE_DATA.</summary>
		public uint dwSize;

		/// <summary>
		/// <para>Specifies the new state of the node. Valid values are the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_NODE_CHANGE_CONNECTED</term>
		/// <term>The node is present in the graph.</term>
		/// </item>
		/// <item>
		/// <term>PEER_NODE_CHANGE_DISCONNECTED</term>
		/// <term>The node is no longer present in the graph.</term>
		/// </item>
		/// <item>
		/// <term>PEER_NODE_CHANGE_UPDATED</term>
		/// <term>The node has new information, for example, the attributes have changed.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PEER_NODE_CHANGE_TYPE changeType;

		/// <summary>Specifies the unique ID of the node that has changed.</summary>
		public ulong ullNodeId;

		/// <summary>Specifies the peer ID of the node that has changed.</summary>
		public StrPtrUni pwzPeerId;
	}

	/// <summary>
	/// The <c>PEER_EVENT_OBJECT_CHANGED_DATA</c> structure contains information returned when a PEER_EVENT_ENDPOINT_OBJECT_CHANGED or
	/// PEER_EVENT_MY_OBJECT_CHANGED event is raised on a peer participating in a peer collaboration network.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Peer objects are run-time data items associated with a particular application, such as a picture or avatar, a certificate, or a
	/// specific description. Each peer object must be smaller than 16K in size.
	/// </para>
	/// <para>
	/// Trusted contacts watching this peer object will have a PEER_EVENT_OBJECT_CHANGED event raised on them signaling the peer
	/// object's change in status.
	/// </para>
	/// <para>
	/// The PEER_EVENT_OBJECT_CHANGED event is raised when an object is changed by calling PeerCollabSetObject. If it is the first time
	/// the object is set then <c>changeType</c> is set to PEER_CHANGE_ADDED. On subsequent calls of PeerCollabSetObject for the same
	/// object ID the <c>changeType</c> is set to PEER_CHANGE_UDPATED.
	/// </para>
	/// <para>If PeerCollabDeleteObject is called the PEER_CHANGE_DELETED event is raised.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_object_changed_data typedef struct
	// peer_event_object_changed_data_tag { PEER_CONTACT* pContact; PEER_ENDPOINT* pEndpoint; PEER_CHANGE_TYPE changeType; PEER_OBJECT*
	// pObject; } PEER_EVENT_OBJECT_CHANGED_DATA, *PEER_EVENT_OBJECT_CHANGED_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_object_changed_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_OBJECT_CHANGED_DATA
	{
		/// <summary>
		/// Pointer to a PEER_CONTACT structure that contains the peer contact information for the contact whose peer object data changed.
		/// </summary>
		public IntPtr pContact;

		/// <summary>
		/// Pointer to a PEER_ENDPOINT structure that contains the peer endpoint information for the contact whose peer object data changed.
		/// </summary>
		public IntPtr pEndpoint;

		/// <summary>PEER_CHANGE_TYPE enumeration value that specifies the type of change that occurred.</summary>
		public PEER_CHANGE_TYPE changeType;

		/// <summary>
		/// Pointer to a PEER_OBJECT structure that contains the peer object data whose change raised the event. This most commonly
		/// occurs when a new peer object is received by the peer.
		/// </summary>
		public IntPtr pObject;
	}

	/// <summary>
	/// The <c>PEER_EVENT_PEOPLE_NEAR_ME_CHANGED_DATA</c> structure contains information returned when a
	/// PEER_EVENT_PEOPLE_NEAR_ME_CHANGED event is raised on a peer participating in a subnet-specific peer collaboration network.
	/// </summary>
	/// <remarks>
	/// <para>The information that can be changed in a peer contact include the endpoint's name or its associated IPv6 address.</para>
	/// <para>
	/// If the <c>changeType</c> is set to PEER_CHANGE_ADDED and <c>pEndpoint</c> is set to <c>NULL</c>, then the local peer has signed
	/// in. Otherwise, if <c>changeType</c> is set to PEER_CHANGE_DELETEDimplies the local peer has signed out.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_people_near_me_changed_data typedef struct
	// peer_event_people_near_me_changed_data_tag { PEER_CHANGE_TYPE changeType; PEER_PEOPLE_NEAR_ME* pPeopleNearMe; }
	// PEER_EVENT_PEOPLE_NEAR_ME_CHANGED_DATA, *PEER_EVENT_PEOPLE_NEAR_ME_CHANGED_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_people_near_me_changed_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_PEOPLE_NEAR_ME_CHANGED_DATA
	{
		/// <summary>
		/// PEER_CHANGE_TYPE enumeration value that describes the type of change that occurred for a contact available on the local subnet.
		/// </summary>
		public PEER_CHANGE_TYPE changeType;

		/// <summary>
		/// Pointer to a PEER_PEOPLE_NEAR_ME structure that contains the peer endpoint information for the contact on the subnet that
		/// raised the change event.
		/// </summary>
		public IntPtr pPeopleNearMe;
	}

	/// <summary>
	/// The <c>PEER_EVENT_PRESENCE_CHANGED_DATA</c> structure contains information returned when a PEER_EVENT_ENDPOINT_PRESENCE_CHANGED
	/// or PEER_EVENT_MY_PRESENCE_CHANGED event is raised on a peer participating in a peer collaboration network.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_presence_changed_data typedef struct
	// peer_event_presence_changed_data_tag { PEER_CONTACT* pContact; PEER_ENDPOINT* pEndpoint; PEER_CHANGE_TYPE changeType;
	// PEER_PRESENCE_INFO* pPresenceInfo; } PEER_EVENT_PRESENCE_CHANGED_DATA, *PEER_EVENT_PRESENCE_CHANGED_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_presence_changed_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_PRESENCE_CHANGED_DATA
	{
		/// <summary>
		/// Pointer to a PEER_CONTACT structure that contains the peer contact information for the contact whose change in presence
		/// raised the event.
		/// </summary>
		public IntPtr pContact;

		/// <summary>
		/// Pointer to a PEER_ENDPOINT structure that contains the peer endpoint information for the contact whose change in presence
		/// raised the event.
		/// </summary>
		public IntPtr pEndpoint;

		/// <summary>PEER_CHANGE_TYPE enumeration value that specifies the type of presence change that occurred.</summary>
		public PEER_CHANGE_TYPE changeType;

		/// <summary>
		/// Pointer to a PEER_PRESENCE_INFO structure that contains the updated presence information for the endpoint of the contact
		/// whose change in presence raised the event.
		/// </summary>
		public IntPtr pPresenceInfo;
	}

	/// <summary>
	/// <para>
	/// The PEER_GROUP_EVENT_DATA structure points to the <c>PEER_EVENT_RECORD_CHANGE_DATA</c> structure if one of the following peer
	/// events is triggered:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>PEER_GRAPH_EVENT_RECORD_CHANGE</c></term>
	/// </item>
	/// <item>
	/// <term><c>PEER_GROUP_EVENT_RECORD_CHANGE</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>PEER_EVENT_RECORD_CHANGE_DATA</c> structure contains updated information that an application requests for data changes to
	/// a record or record type.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_record_change_data typedef struct
	// peer_event_record_change_data_tag { DWORD dwSize; PEER_RECORD_CHANGE_TYPE changeType; GUID recordId; GUID recordType; }
	// PEER_EVENT_RECORD_CHANGE_DATA, *PEER_EVENT_RECORD_CHANGE_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_record_change_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_RECORD_CHANGE_DATA
	{
		/// <summary>Specifies the size of a structure.</summary>
		public uint dwSize;

		/// <summary>Specifies the type of change to a record or record type.</summary>
		public PEER_RECORD_CHANGE_TYPE changeType;

		/// <summary>Specifies the unique ID of a changed record.</summary>
		public Guid recordId;

		/// <summary>Specifies the unique record type of a changed record.</summary>
		public Guid recordType;
	}

	/// <summary>
	/// The <c>PEER_EVENT_REQUEST_STATUS_CHANGED_DATA</c> structure contains information returned when a
	/// PEER_EVENT_REQUEST_STATUS_CHANGED event is raised on a peer participating in a peer collaboration network.
	/// </summary>
	/// <remarks>
	/// This event is raised when the infrastructure finishes processing the request for PeerCollabRefreshEndpointData or
	/// PeerCollabSubscribeEndpointData. If the process fails <c>hrChange</c> value will most typically be PEER_E_CONNECTION_FAILED.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_request_status_changed_data typedef struct
	// peer_event_request_status_changed_data_tag { PEER_ENDPOINT* pEndpoint; HRESULT hrChange; }
	// PEER_EVENT_REQUEST_STATUS_CHANGED_DATA, *PEER_EVENT_REQUEST_STATUS_CHANGED_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_request_status_changed_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_REQUEST_STATUS_CHANGED_DATA
	{
		/// <summary>
		/// Pointer to a PEER_ENDPOINT structure that contains the peer endpoint information for the contact whose change in request
		/// status raised the event.
		/// </summary>
		public IntPtr pEndpoint;

		/// <summary>HRESULT value that indicates the change in request status that occurred.</summary>
		public HRESULT hrChange;
	}

	/// <summary>
	/// The <c>PEER_EVENT_SYNCHRONIZED_DATA</c> is pointed to by a PEER_GRAPH_EVENT_DATA structure's union if a
	/// PEER_GRAPH_EVENT_RECORD_CHANGE or PEER_GROUP_EVENT_RECORD_CHANGE event is triggered. The <c>PEER_EVENT_SYNCHRONIZED_DATA</c>
	/// structure indicates the type of record that has been synchronized.
	/// </summary>
	/// <remarks>
	/// This event only occurs if an application has specified a record synchronization precedence in a previous call to PeerGraphOpen.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_synchronized_data typedef struct
	// peer_event_synchronized_data_tag { DWORD dwSize; GUID recordType; } PEER_EVENT_SYNCHRONIZED_DATA, *PEER_EVENT_SYNCHRONIZED_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_synchronized_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_SYNCHRONIZED_DATA
	{
		/// <summary>Specifies the size of the structure.</summary>
		public uint dwSize;

		/// <summary>Specifies the type of record that is being synchronized.</summary>
		public Guid recordType;
	}

	/// <summary>
	/// The <c>PEER_EVENT_WATCHLIST_CHANGED_DATA</c> structure contains information returned when a PEER_EVENT_WATCHLIST_CHANGED event
	/// is raised on a peer participating in a peer collaboration network.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The PEER_EVENT_WATCHLIST_CHANGED event is raised when the watch list is changed. The watch list is composed of the contacts that
	/// have <c>fWatch</c> set to true. If a new contact is added with <c>fWatch</c> set to true, or if an existing contact's
	/// <c>fWatch</c> is changed to true, the <c>changeType</c> member is set to PEER_CHANGE_ADDED. If <c>fWatch</c> is changed to false
	/// or if a contact is deleted, <c>changeType</c> is set to PEER_CHANGE_DELETED.
	/// </para>
	/// <para>
	/// The p2phost.exe service must running to receive this event. P2phost.exe is launched when an application calls
	/// PeerCollabRegisterEvent on this event.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_event_watchlist_changed_data typedef struct
	// peer_event_watchlist_changed_data_tag { PEER_CONTACT* pContact; PEER_CHANGE_TYPE changeType; } PEER_EVENT_WATCHLIST_CHANGED_DATA, *PEER_EVENT_WATCHLIST_CHANGED_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_event_watchlist_changed_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_EVENT_WATCHLIST_CHANGED_DATA
	{
		/// <summary>
		/// Pointer to a PEER_CONTACT structure that contains information about the peer contact in the watchlist whose change raised
		/// the event.
		/// </summary>
		public IntPtr pContact;

		/// <summary>PEER_CHANGE_TYPE enumeration value that specifies the type of change that occurred in the peer's watchlist.</summary>
		public PEER_CHANGE_TYPE changeType;
	}

	/// <summary>The <c>PEER_GRAPH_EVENT_DATA</c> structure contains data associated with a peer event.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_graph_event_data typedef struct peer_graph_event_data_tag {
	// PEER_GRAPH_EVENT_TYPE eventType; union { PEER_GRAPH_STATUS_FLAGS dwStatus; PEER_EVENT_INCOMING_DATA incomingData;
	// PEER_EVENT_RECORD_CHANGE_DATA recordChangeData; PEER_EVENT_CONNECTION_CHANGE_DATA connectionChangeData;
	// PEER_EVENT_NODE_CHANGE_DATA nodeChangeData; PEER_EVENT_SYNCHRONIZED_DATA synchronizedData; }; } PEER_GRAPH_EVENT_DATA, *PEER_GRAPH_EVENT_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_graph_event_data_tag")]
	[StructLayout(LayoutKind.Explicit)]
	public struct PEER_GRAPH_EVENT_DATA
	{
		/// <summary>
		/// The type of peer event this data corresponds to. Must be one of the PEER_GRAPH_EVENT_TYPE values. The members that remain
		/// are given values based on the peer event type that has occurred. Not all members contain data.
		/// </summary>
		[FieldOffset(0)]
		public PEER_GRAPH_EVENT_TYPE eventType;

		/// <summary>
		/// This member is given a value if the PEER_GRAPH_EVENT_STATUS_CHANGE peer event is triggered. A change has been made in
		/// relation to a node's connection to the graph.
		/// </summary>
		[FieldOffset(8)]
		public PEER_GRAPH_STATUS_FLAGS dwStatus;

		/// <summary>
		/// This member is given a value if the PEER_GRAPH_INCOMING_DATA peer event is triggered. A node has received data from a
		/// neighbor or a direct connection.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_INCOMING_DATA incomingData;

		/// <summary>
		/// This member given a value if the PEER_GRAPH_EVENT_RECORD_CHANGE peer event is triggered. A record type the application asked
		/// for notifications of has changed.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_RECORD_CHANGE_DATA recordChangeData;

		/// <summary>
		/// This member is given a value if the PEER_GRAPH_EVENT_NEIGHBOR_CONNECTION or <c>PEER_GRAPH_EVENT_DIRECT_CONNECTION</c> peer
		/// event is triggered. An aspect of a neighbor or direct connection state has changed.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_CONNECTION_CHANGE_DATA connectionChangeData;

		/// <summary>
		/// This member is given a value if the PEER_GRAPH_EVENT_NODE_CHANGED peer event is triggered. A node's presence state has changed.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_NODE_CHANGE_DATA nodeChangeData;

		/// <summary>
		/// This member is given a value if the PEER_GRAPH_EVENT_SYNCHRONIZED peer event is triggered. A record type has completed its synchronization.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_SYNCHRONIZED_DATA synchronizedData;
	}

	/// <summary>
	/// The <c>PEER_GRAPH_EVENT_REGISTRATION</c> structure is used during registration for peer event notification. During registration
	/// it specifies which peer events an application requires notifications for.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_graph_event_registration typedef struct
	// peer_graph_event_registration_tag { PEER_GRAPH_EVENT_TYPE eventType; GUID *pType; } PEER_GRAPH_EVENT_REGISTRATION, *PEER_GRAPH_EVENT_REGISTRATION*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_graph_event_registration_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_GRAPH_EVENT_REGISTRATION
	{
		/// <summary>
		/// Specifies the type of peer event the application requires notifications for. The per events that can be registered for are
		/// specified by the PEER_GRAPH_EVENT_TYPE enumeration.
		/// </summary>
		public PEER_GRAPH_EVENT_TYPE eventType;

		/// <summary>
		/// If the peer event specified by <c>eventType</c> relates to records, use this member to specify which types of records the
		/// application requires notifications for. Specify <c>NULL</c> to receive notifications for all record types. This member is
		/// ignored if the event specified by <c>eventType</c> does not relate to records.
		/// </summary>
		public IntPtr pType;
	}

	/// <summary>
	/// The <c>PEER_GRAPH_PROPERTIES</c> structure contains data about the policy of a peer graph, ID, scope, and other information.
	/// </summary>
	/// <remarks>
	/// <para>An application can force the Peer Graphing Infrastructure to publish presence information by using PeerGraphSetPresence.</para>
	/// <para>
	/// Only specific fields in the <c>PEER_GRAPH_PROPERTIES</c> can be updated when calling PeerGraphSetProperties. The following
	/// members can be updated:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>pwzFriendlyName</c></term>
	/// </item>
	/// <item>
	/// <term><c>pwzComment</c></term>
	/// </item>
	/// <item>
	/// <term><c>ulPresenceLifetime</c></term>
	/// </item>
	/// <item>
	/// <term><c>cPresenceMax</c></term>
	/// </item>
	/// </list>
	/// <para>The remaining members cannot be modified.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_graph_properties typedef struct peer_graph_properties_tag {
	// DWORD dwSize; DWORD dwFlags; DWORD dwScope; DWORD dwMaxRecordSize; PWSTR pwzGraphId; PWSTR pwzCreatorId; PWSTR pwzFriendlyName;
	// PWSTR pwzComment; ULONG ulPresenceLifetime; ULONG cPresenceMax; } PEER_GRAPH_PROPERTIES, *PEER_GRAPH_PROPERTIES*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_graph_properties_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_GRAPH_PROPERTIES
	{
		/// <summary>
		/// Specifies the size, in bytes, of this data structure. The <c>dwSize</c> member must be set to the size of
		/// <c>PEER_GRAPH_PROPERTIES</c> before calling PeerGraphCreate. This member is required. There is not a default value.
		/// </summary>
		public uint dwSize;

		/// <summary>
		/// <para>
		/// Flags that control the behavior of a peer in a graph. The default is does not have flags set. The valid value is identified
		/// in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_GRAPH_PROPERTY_DEFER_EXPIRATION</term>
		/// <term>
		/// Specifies when to expire a graph record. When a graph is not connected and this flag is set, expiration does not occur until
		/// the graph connects to at least one other member.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PEER_GRAPH_PROPERTY_FLAGS dwFlags;

		/// <summary>
		/// <para>
		/// Specifies the scope in which the peer graph ID is published. The default value is global. Valid values are identified in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_GRAPH_SCOPE_GLOBAL</term>
		/// <term>Scope includes the Internet.</term>
		/// </item>
		/// <item>
		/// <term>PEER_GRAPH_SCOPE_LINK_LOCAL</term>
		/// <term>Scope is restricted to a local subnet.</term>
		/// </item>
		/// <item>
		/// <term>PEER_GRAPH_SCOPE_SITE_LOCAL</term>
		/// <term>Scope is restricted to a site, for example, a corporation intranet.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwScope;

		/// <summary>
		/// Specifies the value that indicates the largest record that can be added to a peer graph. A valid value is zero (0), which
		/// indicates that the default maximum record size is used (60 megabytes), and any value between 1024 bytes and 60 megabytes.
		/// </summary>
		public uint dwMaxRecordSize;

		/// <summary>
		/// Specifies the unique identifier for a peer graph. This ID must be unique for the computer/user pair. This member is required
		/// and has no default value. If the string value is greater than 256 characters (including the null terminator), an error is returned.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzGraphId;

		/// <summary>
		/// Specifies the unique identifier for the creator of a peer graph. This member is required and has no default value. If the
		/// string value is greater than 256 characters (including the null terminator), an error is returned.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzCreatorId;

		/// <summary>
		/// Specifies the friendly name of a peer graph. This member is optional and can be <c>NULL</c>. The default value is
		/// <c>NULL</c>. The maximum length of this string is 256 characters, including the null terminator.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzFriendlyName;

		/// <summary>
		/// Specifies the comment used to describe a peer graph. This member is optional and can be <c>NULL</c>. The default value is
		/// <c>NULL</c>. The maximum length of this string is 512 characters, including the null terminator.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzComment;

		/// <summary>
		/// Specifies the number of seconds before a presence record expires. The default value is 300 seconds (5 minutes). Do not set
		/// the value of <c>ulPresenceLifetime</c> to less than 300 seconds. If this member is set less than the 300 (5 minutes) default
		/// value, then undefined behavior can occur.
		/// </summary>
		public uint ulPresenceLifetime;

		/// <summary>
		/// <para>
		/// Specifies how many presence records the Peer Infrastructure keeps in a peer graph at one time. A node that has its presence
		/// published can be enumerated by all other nodes with PeerGraphEnumNodes. Specify how presence records for users are published
		/// by specifying one of the values identified in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>-1</term>
		/// <term>Presence records are automatically published for all users.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Presence records are not automatically published.</term>
		/// </item>
		/// <item>
		/// <term>1-N</term>
		/// <term>
		/// Up to N number of presence records are published at one time. The presence records that are published are randomly chosen by
		/// the Peer Graphing Infrastructure.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public uint cPresenceMax;
	}

	/// <summary>The <c>PEER_GROUP_EVENT_DATA</c> structure contains information about a specific peer group event that has occurred.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_group_event_data-r1 typedef struct peer_group_event_data_tag {
	// PEER_GROUP_EVENT_TYPE eventType; union { PEER_GROUP_STATUS dwStatus; PEER_EVENT_INCOMING_DATA incomingData;
	// PEER_EVENT_RECORD_CHANGE_DATA recordChangeData; PEER_EVENT_CONNECTION_CHANGE_DATA connectionChangeData;
	// PEER_EVENT_MEMBER_CHANGE_DATA memberChangeData; HRESULT hrConnectionFailedReason; }; } PEER_GROUP_EVENT_DATA, *PEER_GROUP_EVENT_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_group_event_data_tag~r1")]
	[StructLayout(LayoutKind.Explicit)]
	public struct PEER_GROUP_EVENT_DATA
	{
		/// <summary>
		/// PEER_GROUP_EVENT_TYPE enumeration value that specifies the type of peer group event that occurred. The type of event
		/// dictates the subsequent structure chosen from the union; for example, if this value is set to
		/// PEER_GROUP_EVENT_INCOMING_DATA, the populated union member is <c>incomingData</c>.
		/// </summary>
		[FieldOffset(0)]
		public PEER_GROUP_EVENT_TYPE eventType;

		/// <summary>
		/// Specifies the PEER_GROUP_STATUS flag values that indicate the new status of the peer group. This field is populated if a
		/// PEER_GROUP_EVENT_STATUS_CHANGED event is raised.
		/// </summary>
		[FieldOffset(8)]
		public PEER_GROUP_STATUS dwStatus;

		/// <summary>
		/// Specifies the PEER_EVENT_INCOMING_DATA structure that contains information on incoming data from a peer. This structure is
		/// populated if a PEER_GROUP_EVENT_INCOMING_DATA event is raised.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_INCOMING_DATA incomingData;

		/// <summary>
		/// Specifies the PEER_EVENT_RECORD_CHANGE_DATA structure that contains data that describes a record change. This structure is
		/// populated if a PEER_GROUP_EVENT_RECORD_CHANGED event is raised.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_RECORD_CHANGE_DATA recordChangeData;

		/// <summary>
		/// PEER_EVENT_CONNECTION_CHANGE_DATA structure that contains information when a direct or neighbor connection has changed. This
		/// structure is populated if a PEER_GROUP_EVENT_DIRECT_CONNECTION or PEER_GROUP_EVENT_NEIGHBOR_CONNECTION event is raised.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_CONNECTION_CHANGE_DATA connectionChangeData;

		/// <summary>
		/// PEER_EVENT_MEMBER_CHANGE_DATA structure that contains data when the status of a peer group member changes. This structure is
		/// populated if a PEER_GROUP_EVENT_MEMBER_CHANGED event is raised.
		/// </summary>
		[FieldOffset(8)]
		public PEER_EVENT_MEMBER_CHANGE_DATA memberChangeData;

		/// <summary>
		/// <para>
		/// <c>HRESULT</c> that indicates the type of connection failure that occurred. This value is populated if a
		/// PEER_GROUP_EVENT_CONNECTION_FAILED event is raised. This value is one of the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_E_NO_MEMBERS_FOUND</term>
		/// <term>No available peers within the peer group were found to connect to.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_MEMBER_CONNECTIONS</term>
		/// <term>No member connections were available.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_UNABLE_TO_LISTEN</term>
		/// <term>The peer was unable to receive connection data for an unspecified reason.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_AUTHORIZED</term>
		/// <term>
		/// An attempt has been made to perform an unauthorized operation. For example, attempting to join a group with an invalid password.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		[FieldOffset(8)]
		public HRESULT hrConnectionFailedReason;
	}

	/// <summary>
	/// The <c>PEER_GROUP_EVENT_REGISTRATION</c> structure defines the particular peer group event a member can register for.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_group_event_registration typedef struct
	// peer_group_event_registration_tag { PEER_GROUP_EVENT_TYPE eventType; GUID *pType; } PEER_GROUP_EVENT_REGISTRATION, *PEER_GROUP_EVENT_REGISTRATION*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_group_event_registration_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_GROUP_EVENT_REGISTRATION
	{
		/// <summary>PEER_GROUP_EVENT_TYPE that specifies the peer group event type to register for.</summary>
		public PEER_GROUP_EVENT_TYPE eventType;

		/// <summary>
		/// <para>
		/// GUID value that identifies the type of record or data message that raises an event of the type specified by
		/// <c>eventType</c>. For example, if the peer wishes to be notified about all changes to a specific record type, the GUID that
		/// corresponds to this record type must be supplied in this field and PEER_GROUP_RECORD_CHANGED must be in <c>eventType</c>.
		/// </para>
		/// <para>This member is only populated (not NULL) when <c>eventType</c> is either PEER_GROUP_EVENT_RECORD_CHANGED or PEER_GROUP_EVENT_INCOMING_DATA.</para>
		/// </summary>
		public IntPtr pType;
	}

	/// <summary>The <c>PEER_GROUP_PROPERTIES</c> structure contains data about the membership policy of a peer group.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_group_properties typedef struct peer_group_properties_tag {
	// DWORD dwSize; DWORD dwFlags; PWSTR pwzCloud; PWSTR pwzClassifier; PWSTR pwzGroupPeerName; PWSTR pwzCreatorPeerName; PWSTR
	// pwzFriendlyName; PWSTR pwzComment; ULONG ulMemberDataLifetime; ULONG ulPresenceLifetime; DWORD dwAuthenticationSchemes; PWSTR
	// pwzGroupPassword; PEER_ROLE_ID groupPasswordRole; } PEER_GROUP_PROPERTIES, *PEER_GROUP_PROPERTIES*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_group_properties_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_GROUP_PROPERTIES
	{
		/// <summary>Size of the structure, in bytes.</summary>
		public uint dwSize;

		/// <summary>
		/// PEER_GROUP_PROPERTY_FLAGS flags that describe the behavior of a peer group. The default value is zero (0), which indicates
		/// that flags are not set.
		/// </summary>
		public PEER_GROUP_PROPERTY_FLAGS dwFlags;

		/// <summary>
		/// Specifies the name of the Peer Name Resolution Protocol (PNRP) cloud that a peer group participates in. The default value is
		/// "global", if this member is <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzCloud;

		/// <summary>
		/// Specifies the classifier used to identify the authority of a peer group peer name for registration or resolution within a
		/// PNRP cloud. The maximum size of this field is 149 Unicode characters. This member can be <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzClassifier;

		/// <summary>
		/// Specifies the name of a peer group that is registered with the PNRP service. The maximum size of this field is 137 Unicode characters.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzGroupPeerName;

		/// <summary>
		/// Specifies the peer name associated with the Peer group creator. The maximum size of this field is 137 Unicode characters. If
		/// this structure member is <c>NULL</c>, the implementation uses the identity obtained from PeerIdentityGetDefault.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzCreatorPeerName;

		/// <summary>Specifies the friendly (display) name of a peer group. The maximum size of this field is 255 characters.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzFriendlyName;

		/// <summary>Contains a comment used to describe a peer group. The maximum size of this field is 255 characters.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzComment;

		/// <summary>
		/// <para>
		/// Specifies the lifetime, in seconds, of peer group member data (PEER_MEMBER). The minimum value for this field is 8 hours,
		/// and the maximum is 10 years. The default value is 2,419,200 seconds, or 28 days.
		/// </para>
		/// <para>
		/// If this value is set to zero (0), member data has the maximum allowable lifetime, which is the time remaining in the
		/// lifetime of the administrator who issues the credentials for a member.
		/// </para>
		/// </summary>
		public uint ulMemberDataLifetime;

		/// <summary>
		/// Specifies the lifetime, in seconds, of presence information published to a peer group. The default value is 300 seconds. Do
		/// not set the value of <c>ulPresenceLifetime</c> to less than 300 seconds. If this member is set to less than the 300–second
		/// default value, then undefined behavior can occur.
		/// </summary>
		public uint ulPresenceLifetime;

		/// <summary>
		/// <c>Windows Vista or later.</c> Logical OR of PEER_GROUP_AUTHENTICATION_SCHEME enumeration values that indicate the types of
		/// authentication supported by the peer group.
		/// </summary>
		public PEER_GROUP_AUTHENTICATION_SCHEME dwAuthenticationSchemes;

		/// <summary>
		/// <c>Windows Vista or later.</c> Pointer to a Unicode string that contains the password used to authenticate peers attempting
		/// to join the peer group.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzGroupPassword;

		/// <summary>
		/// <c>Windows Vista or later.</c> GUID value that indicates the peer group role for which the password is required for authentication.
		/// </summary>
		public Guid groupPasswordRole;
	}

	/// <summary>The <c>PEER_INVITATION</c> structure contains a request to initiate or join a peer collaboration activity.</summary>
	/// <remarks>
	/// An invitation request is typically sent by a peer after a contact appears online within the peer collaboration network and a
	/// call to PeerCollabEnumApplications returns a common software application (represented as a application GUID) available on the
	/// contact's endpoint.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_invitation typedef struct peer_invitation_tag { GUID
	// applicationId; PEER_DATA applicationData; PWSTR pwzMessage; } PEER_INVITATION, *PEER_INVITATION*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_invitation_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_INVITATION
	{
		/// <summary>
		/// GUID value that uniquely identifies the registered software or software component for the peer collaboration activity.
		/// </summary>
		public Guid applicationId;

		/// <summary>
		/// PEER_DATA structure that contains opaque data describing possible additional application-specific settings (for example, an
		/// address and port on which the activity will occur, or a specific video codec to use). This data is limited to 16K.
		/// </summary>
		public PEER_DATA applicationData;

		/// <summary>
		/// Zero-terminated Unicode string that contains a specific request message to the invitation recipient. The message is limited
		/// to 255 unicode characters.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzMessage;
	}

	/// <summary>
	/// The <c>PEER_INVITATION_INFO</c> structure defines information about an invitation to join a peer group. Invitations are
	/// represented as Unicode strings. To obtain this structure, pass the XML invitation string created by PeerGroupCreateInvitation to PeerGroupParseInvitation.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_invitation_info typedef struct peer_invitation_info_tag {
	// DWORD dwSize; DWORD dwFlags; PWSTR pwzCloudName; DWORD dwScope; DWORD dwCloudFlags; PWSTR pwzGroupPeerName; PWSTR
	// pwzIssuerPeerName; PWSTR pwzSubjectPeerName; PWSTR pwzGroupFriendlyName; PWSTR pwzIssuerFriendlyName; PWSTR
	// pwzSubjectFriendlyName; FILETIME ftValidityStart; FILETIME ftValidityEnd; ULONG cRoles; PEER_ROLE_ID *pRoles; ULONG cClassifiers;
	// PWSTR *ppwzClassifiers; CERT_PUBLIC_KEY_INFO *pSubjectPublicKey; PEER_GROUP_AUTHENTICATION_SCHEME authScheme; }
	// PEER_INVITATION_INFO, *PEER_INVITATION_INFO*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_invitation_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_INVITATION_INFO
	{
		/// <summary>Specifies the size of this structure, in bytes.</summary>
		public uint dwSize;

		/// <summary>Must be set to 0x00000000.</summary>
		public uint dwFlags;

		/// <summary>Pointer to a Unicode string that specifies the PNRP cloud name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzCloudName;

		/// <summary>
		/// <para>Specifies the scope under which the peer group was registered.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PNRP_GLOBAL_SCOPE</term>
		/// <term>Global scope, including the Internet.</term>
		/// </item>
		/// <item>
		/// <term>PNRP_LOCAL_SCOPE</term>
		/// <term>Local scope.</term>
		/// </item>
		/// <item>
		/// <term>PNRP_LINK_LOCAL_SCOPE</term>
		/// <term>Link-local scope.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PNRP_SCOPE dwScope;

		/// <summary>
		/// <para>Specifies a set of flags that describe PNRP cloud features.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PNRP_CLOUD_NO_FLAGS 0</term>
		/// <term>No flags are set.</term>
		/// </item>
		/// <item>
		/// <term>PNRP_CLOUD_NAME_LOCAL 1</term>
		/// <term>The cloud name is not available on other computers; it is locally defined.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PNRP_CLOUD_FLAGS dwCloudFlags;

		/// <summary>Pointer to a Unicode string that specifies the peer name of the peer group.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzGroupPeerName;

		/// <summary>Pointer to a Unicode string that specifies the PNRP name of the peer issuing the invitation.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzIssuerPeerName;

		/// <summary>Pointer to a Unicode string that specifies the PNRP name of the peer that receives the invitation.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzSubjectPeerName;

		/// <summary>Pointer to a Unicode string that specifies the friendly (display) name of the peer group.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzGroupFriendlyName;

		/// <summary>Pointer to a Unicode string that specifies the friendly (display) name of the peer issuing the invitation.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzIssuerFriendlyName;

		/// <summary>Pointer to a Unicode string that specifies the friendly (display) name of the peer that receives the invitation.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzSubjectFriendlyName;

		/// <summary>Specifies a UTC <c>FILETIME</c> value that indicates when the invitation becomes valid.</summary>
		public FILETIME ftValidityStart;

		/// <summary>Specifies a UTC <c>FILETIME</c> value that indicates when the invitation becomes invalid.</summary>
		public FILETIME ftValidityEnd;

		/// <summary>Specifies the number of role GUIDs present in <c>pRoles</c>.</summary>
		public uint cRoles;

		/// <summary>
		/// <para>Pointer to a list of GUIDs that specifies the combined set of available roles. The available roles are as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_GROUP_ROLE_ADMIN</term>
		/// <term>
		/// This role can issue invitations, renew memberships, modify peer group properties, publish and update records, and renew the
		/// GMC of other administrators.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_GROUP_ROLE_MEMBER</term>
		/// <term>The role can publish records to the peer group database.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IntPtr pRoles;

		/// <summary>
		/// Unsigned integer value that contains the number of string values listed in <c>ppwzClassifiers</c>. This field is reserved
		/// for future use.
		/// </summary>
		public uint cClassifiers;

		/// <summary>List of pointers to Unicode strings. This field is reserved for future use.</summary>
		public IntPtr ppwzClassifiers;

		/// <summary>
		/// Pointer to a <c>CERT_PUBLIC_KEY_INFO</c> structure that contains the recipient's returned public key and the encryption
		/// algorithm type it uses.
		/// </summary>
		public IntPtr pSubjectPublicKey;

		/// <summary>
		/// <c>Windows Vista or later.</c> The PEER_GROUP_AUTHENTICATION_SCHEME enumeration value that indicates the type of
		/// authentication used to validate the peer group invitee.
		/// </summary>
		public PEER_GROUP_AUTHENTICATION_SCHEME authScheme;
	}

	/// <summary>
	/// The <c>PEER_INVITATION_RESPONSE</c> structure contains a response to an invitation to join a peer collaboration activity.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_invitation_response typedef struct
	// peer_invitation_response_tag { PEER_INVITATION_RESPONSE_TYPE action; PWSTR pwzMessage; HRESULT hrExtendedInfo; }
	// PEER_INVITATION_RESPONSE, *PEER_INVITATION_RESPONSE*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_invitation_response_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_INVITATION_RESPONSE
	{
		/// <summary>
		/// PEER_INVITATION_RESPONSE_TYPE enumeration value that specifies the action the peer takes in response to the invitation.
		/// </summary>
		public PEER_INVITATION_RESPONSE_TYPE action;

		/// <summary>Reserved. This member must be set to <c>NULL</c>, and is set exclusively by the Peer Collaboration infrastructure.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzMessage;

		/// <summary>
		/// Any extended information that is part of the response. This can include an error code corresponding to the failure on the
		/// recipient of the invitation.
		/// </summary>
		public HRESULT hrExtendedInfo;
	}

	/// <summary>The <c>PEER_MEMBER</c> structure contains information that describes a member of a peer group.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_member typedef struct peer_member_tag { DWORD dwSize; DWORD
	// dwFlags; PWSTR pwzIdentity; PWSTR pwzAttributes; ULONGLONG ullNodeId; ULONG cAddresses; PEER_ADDRESS *pAddresses;
	// PEER_CREDENTIAL_INFO *pCredentialInfo; } PEER_MEMBER, *PEER_MEMBER*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_member_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_MEMBER
	{
		/// <summary>Specifies the size of this structure, in bytes.</summary>
		public uint dwSize;

		/// <summary>
		/// <para>PEER_MEMBER_FLAGS enumeration value that specifies the state of the member.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_MEMBER_PRESENT</term>
		/// <term>The member is present in the peer group.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PEER_MEMBER_FLAGS dwFlags;

		/// <summary>Pointer to a Unicode string that specifies the peer name of the member.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzIdentity;

		/// <summary>
		/// Pointer to a unicode string that specifies the attributes of the member. The format of this string is defined by the application.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzAttributes;

		/// <summary>
		/// Unsigned 64-bit integer that contains the node ID. The same peer can have several node IDs, each identifying a different
		/// node that participates in a different peer group.
		/// </summary>
		public ulong ullNodeId;

		/// <summary>Specifies the number of IP addresses listed in <c>pAddress</c>.</summary>
		public uint cAddresses;

		/// <summary>Pointer to a list of PEER_ADDRESS structures used by the member.</summary>
		public IntPtr pAddresses;

		/// <summary>Pointer to a PEER_CREDENTIAL_INFO structure that contains information about the security credentials of a member.</summary>
		public IntPtr pCredentialInfo;
	}

	/// <summary>The <c>PEER_NAME_PAIR</c> structure contains the results of a call to PeerGetNextItem.</summary>
	/// <remarks>
	/// <para>This structure is used when enumerating peer identities and peer groups associated with a specific identity.</para>
	/// <para>
	/// When enumerating peer identities, each <c>PEER_NAME_PAIR</c> structure contains a peer name and the friendly name of the identity.
	/// </para>
	/// <para>
	/// When enumerating peer groups, each <c>PEER_NAME_PAIR</c> structure contains the peer name and friendly name of the corresponding
	/// peer group.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_name_pair typedef struct peer_name_pair_tag { DWORD dwSize;
	// PWSTR pwzPeerName; PWSTR pwzFriendlyName; } PEER_NAME_PAIR, *PEER_NAME_PAIR*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_name_pair_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_NAME_PAIR
	{
		/// <summary>Specifies the size, in bytes, of this structure.</summary>
		public uint dwSize;

		/// <summary>Specifies the peer name of the peer identity or peer group.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzPeerName;

		/// <summary>Specifies the friendly name of the peer identity or peer group.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzFriendlyName;

		/// <summary>Converts to string.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => pwzFriendlyName;
	}

	/// <summary>The <c>PEER_NODE_INFO</c> structure contains information that is specific to a particular node in a peer graph.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_node_info typedef struct peer_node_info_tag { DWORD dwSize;
	// ULONGLONG ullNodeId; PWSTR pwzPeerId; ULONG cAddresses; PEER_ADDRESS* pAddresses; PWSTR pwzAttributes; } PEER_NODE_INFO, *PEER_NODE_INFO*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_node_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_NODE_INFO
	{
		/// <summary>
		/// Specifies the size of the data structure. Set the value to sizeof( <c>PEER_NODE_INFO</c>). This member is required and has
		/// no default value.
		/// </summary>
		public uint dwSize;

		/// <summary>
		/// Specifies a unique ID that identifies an application's connection to its neighbor. An application cannot set the value of
		/// this member, it is created by the Peer Graphing Infrastructure.
		/// </summary>
		public ulong ullNodeId;

		/// <summary>
		/// Specifies the ID of this peer. This value is set for the application by the Peer Graphing Infrastructure. when the
		/// application creates or opens a peer graph.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzPeerId;

		/// <summary>Specifies the number of addresses in <c>pAddresses</c>. This member is required and has no default value.</summary>
		public uint cAddresses;

		/// <summary>
		/// Points to an array of PEER_ADDRESS structures that indicate which addresses and ports this instance is listening to for
		/// group traffic. This member is required and has no default value.
		/// </summary>
		public IntPtr pAddresses;

		/// <summary>
		/// Points to a string that contains the attributes that describe this particular node. This string is a free-form text string
		/// that is specific to the application. This parameter is optional; the default value is <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzAttributes;
	}

	/// <summary>
	/// The <c>PEER_OBJECT</c> structure contains application-specific run-time information that can be shared with trusted contacts
	/// within a peer collaboration network.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Peer objects are run-time data items associated with a particular application, such as a picture or avatar, a certificate, or a
	/// specific description. Each peer object must be smaller than 16K in size.
	/// </para>
	/// <para>
	/// Trusted contacts watching this peer object will have a PEER_EVENT_OBJECT_CHANGED event raised on them signaling this peer
	/// object's change in status.
	/// </para>
	/// <para>
	/// Peer object information is contained in the <c>data</c> member of this structure and represented as a byte buffer with a maximum
	/// size of 16K.
	/// </para>
	/// <para>The lifetime of a peer object is tied to the lifetime of the application that registered it.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_object typedef struct peer_object_tag { GUID id; PEER_DATA
	// data; DWORD dwPublicationScope; } PEER_OBJECT, *PEER_OBJECT*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_object_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_OBJECT
	{
		/// <summary>GUID value under which the peer object is uniquely registered.</summary>
		public Guid id;

		/// <summary>PEER_DATA structure that contains information which describes the peer object.</summary>
		public PEER_DATA data;

		/// <summary>PEER_PUBLICATION_SCOPE enumeration value that specifies the publication scope for this peer object.</summary>
		public PEER_PUBLICATION_SCOPE dwPublicationScope;
	}

	/// <summary>The <c>PEER_PEOPLE_NEAR_ME</c> structure contains information about a peer in the same logical or virtual subnet.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_people_near_me typedef struct peer_people_near_me_tag { PWSTR
	// pwzNickName; PEER_ENDPOINT endpoint; GUID id; } PEER_PEOPLE_NEAR_ME, *PEER_PEOPLE_NEAR_ME*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_people_near_me_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_PEOPLE_NEAR_ME
	{
		/// <summary>Zero-terminated Unicode string that contains the nickname of the contact.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzNickName;

		/// <summary>PEER_ENDPOINT structure that contains the IPv6 network address of the peer whose endpoint shares the same subnet.</summary>
		public PEER_ENDPOINT endpoint;

		/// <summary>
		/// GUID value that contains the unique ID value for this peer. Since this value uniquely identifies a peer endpoint, the
		/// display name and even the associated IPv6 address can be changed with deleting the rest of the peer information.
		/// </summary>
		public Guid id;
	}

	/// <summary>The <c>PEER_PNRP_CLOUD_INFO</c> structure contains information about a Peer Name Resolution Protocol (PNRP) cloud.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_pnrp_cloud_info typedef struct peer_pnrp_cloud_info_tag {
	// PWSTR pwzCloudName; PNRP_SCOPE dwScope; DWORD dwScopeId; } PEER_PNRP_CLOUD_INFO, *PEER_PNRP_CLOUD_INFO*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_pnrp_cloud_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_PNRP_CLOUD_INFO
	{
		/// <summary>
		/// Pointer to a zero-terminated Unicode string that contains the name of the PNRP cloud. The maximum size of this name is 256 characters.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzCloudName;

		/// <summary>
		/// <para>Constant value that specifies the network scope of the PNRP cloud.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PNRP_SCOPE_ANY 0</term>
		/// <term>All IP addresses are allowed to register with the PNRP cloud.</term>
		/// </item>
		/// <item>
		/// <term>PNRP_GLOBAL_SCOPE 1</term>
		/// <term>The scope is global; all valid IP addresses are allowed to register with the PNRP cloud.</term>
		/// </item>
		/// <item>
		/// <term>PNRP_SITE_LOCAL_SCOPE 2</term>
		/// <term>The scope is site-local; only IP addresses defined for the site are allowed to register with the PNRP cloud.</term>
		/// </item>
		/// <item>
		/// <term>PNRP_LINK_LOCAL_SCOPE 3</term>
		/// <term>
		/// The scope is link-local; only IP addresses defined for the local area network are allowed to register with the PNRP cloud.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PNRP_SCOPE dwScope;

		/// <summary>The ID of a specific IP address scope defined for the PNRP cloud.</summary>
		public uint dwScopeId;
	}

	/// <summary>The <c>PEER_PNRP_ENDPOINT_INFO</c> structure contains the IP addresses and data associated with a peer endpoint.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_pnrp_endpoint_info typedef struct peer_pnrp_endpoint_info_tag
	// { PWSTR pwzPeerName; ULONG cAddresses; SOCKADDR **ppAddresses; PWSTR pwzComment; PEER_DATA payload; } PEER_PNRP_ENDPOINT_INFO, *PEER_PNRP_ENDPOINT_INFO*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_pnrp_endpoint_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_PNRP_ENDPOINT_INFO
	{
		/// <summary>The peer name associated with this peer endpoint.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzPeerName;

		/// <summary>The number of SOCKADDR structures in <c>pAddresses</c>.</summary>
		public uint cAddresses;

		/// <summary>
		/// Pointer to an array of pointers to SOCKADDR structures that contain the IP addresses for the peer endpoint's network interface.
		/// </summary>
		public IntPtr ppAddresses;

		/// <summary>Pointer to a zero-terminated Unicode string that contains a comment for this peer endpoint.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzComment;

		/// <summary>
		/// Pointer to a PEER_DATA structure that contains application-specific data for the peer endpoint (such as a message or an image).
		/// </summary>
		public PEER_DATA payload;
	}

	/// <summary>
	/// The <c>PEER_PNRP_REGISTRATION_INFO</c> structure contains the information provided by a peer identity when it registers with a
	/// PNRP cloud.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_pnrp_registration_info typedef struct
	// peer_pnrp_registration_info_tag { PWSTR pwzCloudName; PWSTR pwzPublishingIdentity; ULONG cAddresses; SOCKADDR **ppAddresses; WORD
	// wPort; PWSTR pwzComment; PEER_DATA payload; } PEER_PNRP_REGISTRATION_INFO, *PEER_PNRP_REGISTRATION_INFO*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_pnrp_registration_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_PNRP_REGISTRATION_INFO
	{
		/// <summary>
		/// Pointer to a Unicode string that contains the name of the PNRP cloud for which this peer identity is requesting
		/// registration. If <c>NULL</c>, the registration will be made in all clouds. It is possible to use the special value
		/// PEER_PNRP_ALL_LINK_CLOUDS to register in all link local clouds.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzCloudName;

		/// <summary>Pointer to a Unicode string that contains the name of the peer identity requesting registration.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzPublishingIdentity;

		/// <summary>
		/// The number of SOCKADDR structures in <c>ppAddresses</c>. It is possible to use the special value PEER_PNRP_AUTO_ADDRESSES to
		/// have the infrastructure automatically choose addresses.
		/// </summary>
		public uint cAddresses;

		/// <summary>
		/// Pointer to an array of pointers to SOCKADDR structures that contain the IP addresses bound to the network interface of the
		/// peer identity requesting registration.
		/// </summary>
		public IntPtr ppAddresses;

		/// <summary>The network interface port assigned to the address that the peer is publishing.</summary>
		public ushort wPort;

		/// <summary>Pointer to a zero-terminated Unicode string that contains a comment for this peer endpoint.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzComment;

		/// <summary>
		/// A PEER_DATA structure that contains a pointer to an opaque byte buffer containing application-specific data for the peer
		/// endpoint (such as a message or an image).
		/// </summary>
		public PEER_DATA payload;
	}

	/// <summary>The <c>PEER_PRESENCE_INFO</c> structure contains specific peer presence information.</summary>
	/// <remarks>
	/// Peer "presence" is information about a specific peer's level of participation in a peer collaboration network, such as whether
	/// or not the peer has logged into or out of the peer collaboration network, or has set a specific status (for example, "Busy, "Away").
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_presence_info typedef struct peer_presence_info_tag {
	// PEER_PRESENCE_STATUS status; PWSTR pwzDescriptiveText; } PEER_PRESENCE_INFO, *PEER_PRESENCE_INFO*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_presence_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_PRESENCE_INFO
	{
		/// <summary>
		/// PEER_PRESENCE_STATUS enumeration value that indicates the current availability or level of participation by the peer in a
		/// peer collaboration network.
		/// </summary>
		public PEER_PRESENCE_STATUS status;

		/// <summary>
		/// Zero-terminated Unicode string that contains a user- or application-defined message that expands upon the current status
		/// value. This string is limited to 255 characters.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzDescriptiveText;
	}

	/// <summary>The <c>PEER_RECORD</c> structure contains the record object that an application uses.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_record typedef struct peer_record_tag { DWORD dwSize; GUID
	// type; GUID id; DWORD dwVersion; DWORD dwFlags; PWSTR pwzCreatorId; PWSTR pwzModifiedById; PWSTR pwzAttributes; FILETIME
	// ftCreation; FILETIME ftExpiration; FILETIME ftLastModified; PEER_DATA securityData; PEER_DATA data; } PEER_RECORD, *PEER_RECORD*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_record_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_RECORD
	{
		/// <summary>Specifies the size of a structure. Set the value to sizeof( <c>PEER_RECORD</c>).</summary>
		public uint dwSize;

		/// <summary>
		/// Specifies the type of record. The type is a <c>GUID</c> that an application must specify. The <c>GUID</c> represents a
		/// unique record type, for example, a chat record.
		/// </summary>
		public Guid type;

		/// <summary>
		/// Specifies the unique ID of a record. The Peer Infrastructure supplies this ID. This parameter is ignored in calls to
		/// PeerGroupAddRecord. An application cannot modify this member.
		/// </summary>
		public Guid id;

		/// <summary>
		/// Specifies the version of a record that the Peer Infrastructure supplies when an application calls PeerGraphAddRecord or
		/// PeerGraphUpdateRecord. An application cannot modify this member.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// <para>
		/// Specifies the flags that indicate special processing, which must be applied to a record. The following table identifies the
		/// valid values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_RECORD_FLAG_AUTOREFRESH</term>
		/// <term>Indicates that a record is automatically refreshed when it is ready to expire.</term>
		/// </item>
		/// <item>
		/// <term>PEER_RECORD_FLAG_DELETED</term>
		/// <term>Indicates that a record is marked as deleted.</term>
		/// </item>
		/// </list>
		/// <para><c>Note</c> An application cannot set these flags.</para>
		/// </summary>
		public PEER_RECORD_FLAGS dwFlags;

		/// <summary>
		/// Pointer to the unique ID of a record creator. This member is set to <c>NULL</c> for calls to PeerGraphAddRecord and
		/// PeerGraphUpdateRecord. An application cannot set this member.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwzCreatorId;

		/// <summary>Specifies the unique ID of the last person who changes a record. An application cannot set this member.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzModifiedById;

		/// <summary>
		/// <para>
		/// Pointer to the set of attribute name and value pairs that are associated with a record. This member points to an XML string.
		/// Record attributes are specified as an XML string, and they must be consistent with the Peer Infrastructure record attribute
		/// schema. For a complete explanation of the XML schema, see Record Attribute Schema.
		/// </para>
		/// <para>
		/// The Peer Infrastructure reserves several attribute names that a user cannot set. The following list identifies the reserved
		/// attribute names:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>peerlastmodifiedby</c></term>
		/// </item>
		/// <item>
		/// <term><c>peercreatorid</c></term>
		/// </item>
		/// <item>
		/// <term><c>peerlastmodificationtime</c></term>
		/// </item>
		/// <item>
		/// <term><c>peerrecordid</c></term>
		/// </item>
		/// <item>
		/// <term><c>peerrecordtype</c></term>
		/// </item>
		/// <item>
		/// <term><c>peercreationtime</c></term>
		/// </item>
		/// <item>
		/// <term><c>peerlastmodificationtime</c></term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzAttributes;

		/// <summary>
		/// Specifies the Coordinated Universal Time (UTC) that a record is created. The Peer Infrastructure supplies this value, and
		/// the value is set to zero (0) in calls to PeerGroupAddRecord. An application cannot set this member.
		/// </summary>
		public FILETIME ftCreation;

		/// <summary>
		/// <para>
		/// The UTC time that a record expires. This member is required. It can be updated to a time value greater than the originally
		/// specified time value, but it cannot be less than the originally specified value.
		/// </para>
		/// <para>
		/// <c>Note</c> If <c>dwFlags</c> is set to <c>PEER_RECORD_FLAG_AUTOREFRESH</c>, do not set the value of <c>ftExpiration</c> to
		/// less than four (4) minutes. If this member is set to less than four (4) minutes, undefined behavior can occur.
		/// </para>
		/// </summary>
		public FILETIME ftExpiration;

		/// <summary>
		/// The UTC time that a record is modified. The Peer Infrastructure supplies this value. Set this member to <c>NULL</c> when
		/// calling PeerGraphAddRecord, PeerGraphUpdateRecord, PeerGroupAddRecord, and PeerGroupUpdateRecord. An application cannot set
		/// this member.
		/// </summary>
		public FILETIME ftLastModified;

		/// <summary>
		/// Specifies the security data contained in a PEER_DATA structure. The Graphing API uses this member, and provides the security
		/// provider with a place to store security data, for example, a signature. The Grouping API cannot modify this member.
		/// </summary>
		public PEER_DATA securityData;

		/// <summary>Specifies the actual data that this record contains.</summary>
		public PEER_DATA data;
	}

	/// <summary>
	/// The <c>PEER_SECURITY_INTERFACE</c> structure specifies the security interfaces that calls to Peer Graphing APIs use to validate,
	/// secure, and free records. Additionally, it allows an application to specify the path to the .DLL that contains an implementation
	/// of a security service provider (SSP).
	/// </summary>
	/// <remarks>
	/// If you have developed your own SSP, your application must not call the Peer Graphing API to access data in the graphing
	/// database; doing so can lead to a deadlock situation. Instead, the application should look at a cached copy of the information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_security_interface typedef struct peer_security_interface_tag
	// { DWORD dwSize; PWSTR pwzSspFilename; PWSTR pwzPackageName; ULONG cbSecurityInfo; PBYTE pbSecurityInfo; PVOID pvContext;
	// PFNPEER_VALIDATE_RECORD pfnValidateRecord; PFNPEER_SECURE_RECORD pfnSecureRecord; PFNPEER_FREE_SECURITY_DATA pfnFreeSecurityData;
	// PFNPEER_ON_PASSWORD_AUTH_FAILED pfnAuthFailed; } PEER_SECURITY_INTERFACE, *PEER_SECURITY_INTERFACE*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_security_interface_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_SECURITY_INTERFACE
	{
		/// <summary>
		/// Specifies the size of the structure. Set the value to sizeof( <c>PEER_SECURITY_INTERFACE</c>). This member is required and
		/// has no default value.
		/// </summary>
		public uint dwSize;

		/// <summary>
		/// Specifies the full path and file name of a .DLL that implements the SSP interface. See the SSPI documentation for further
		/// information on the SSP interface.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzSspFilename;

		/// <summary>Specifies the ID of the security module in the SSP to use.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzPackageName;

		/// <summary>
		/// Specifies the byte count of the <c>pbSecurityInfo</c> member. This member is not required if <c>pbSecurityInfo</c> is
		/// <c>NULL</c>. However, if <c>pbSecurityInfo</c> is not <c>NULL</c>, this member must have a value.
		/// </summary>
		public uint cbSecurityInfo;

		/// <summary>
		/// <para>
		/// Pointer to a buffer that contains the information used to create or open a peer graph. This member is optional and can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// The security data blob pointed to by <c>pbSecurityInfo</c> is copied and then passed to the SSPI function call of AcquireCredentialsHandle.
		/// </para>
		/// </summary>
		public IntPtr pbSecurityInfo;

		/// <summary>
		/// Pointer to the security context. This security context is then passed as the first parameter to PFNPEER_VALIDATE_RECORD,
		/// PFNPEER_FREE_SECURITY_DATA, and PFNPEER_SECURE_RECORD. This member is optional and can be <c>NULL</c>.
		/// </summary>
		public IntPtr pvContext;

		/// <summary>
		/// Pointer to a callback function that is called when a record requires validation. This member is optional and can be
		/// <c>NULL</c>. If <c>pfnSecureRecord</c> is <c>NULL</c>, this member must also be <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFNPEER_VALIDATE_RECORD? pfnValidateRecord;

		/// <summary>
		/// Pointer to a callback function that is called when a record must be secured. This member is optional and can be <c>NULL</c>.
		/// If <c>pfnValidateRecord</c> is <c>NULL</c>, this member must also be <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFNPEER_SECURE_RECORD pfnSecureRecord;

		/// <summary>
		/// Pointer to a callback function used to free any data allocated by the callback pointed to by <c>pfnSecureRecord</c>. This
		/// member is optional and can be <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFNPEER_FREE_SECURITY_DATA? pfnFreeSecurityData;

		/// <summary/>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFNPEER_ON_PASSWORD_AUTH_FAILED? pfnAuthFailed;
	}

	/// <summary>The <c>PEER_VERSION_DATA</c> structure contains the version information about the Peer Graphing and Grouping APIs.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/ns-p2p-peer_version_data typedef struct peer_version_data_tag { WORD
	// wVersion; WORD wHighestVersion; } PEER_VERSION_DATA, *PEER_VERSION_DATA*;
	[PInvokeData("p2p.h", MSDNShortId = "NS:p2p.peer_version_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEER_VERSION_DATA
	{
		/// <summary>
		/// Specifies the version of the Peer Infrastructure for a caller to use. The version to use is based on the Peer Infrastructure
		/// DLL installed on a local computer. A high order-byte specifies the minor version (revision) number. A low-order byte
		/// specifies the major version number.
		/// </summary>
		public ushort wVersion;

		/// <summary>
		/// Specifies the highest version of the Peer Infrastructure that the Peer DLL installed on the local computer can support.
		/// Typically, this value is the same as <c>wVersion</c>.
		/// </summary>
		public ushort wHighestVersion;
	}
}