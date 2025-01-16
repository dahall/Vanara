#pragma warning disable IDE1006 // Naming Styles

namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>
	/// <para>The <c>FWP_CLASSIFY_OPTION_TYPE</c> enumerated type is used by callouts and shims during run-time classification.</para>
	/// <para>
	/// <c>FWP_CLASSIFY_OPTION_TYPE</c> specifies timeout options for unicast, multicast, and loose source mapping states and enables
	/// blocking or permission of state creation on outbound multicast and broadcast traffic.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_classify_option_type typedef enum
	// FWP_CLASSIFY_OPTION_TYPE_ { FWP_CLASSIFY_OPTION_MULTICAST_STATE = 0, FWP_CLASSIFY_OPTION_LOOSE_SOURCE_MAPPING,
	// FWP_CLASSIFY_OPTION_UNICAST_LIFETIME, FWP_CLASSIFY_OPTION_MCAST_BCAST_LIFETIME, FWP_CLASSIFY_OPTION_SECURE_SOCKET_SECURITY_FLAGS,
	// FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_MM_POLICY_KEY, FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_QM_POLICY_KEY,
	// FWP_CLASSIFY_OPTION_LOCAL_ONLY_MAPPING, FWP_CLASSIFY_OPTION_MAX } FWP_CLASSIFY_OPTION_TYPE;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_CLASSIFY_OPTION_TYPE_")]
	public enum FWP_CLASSIFY_OPTION_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies the multicast conditions on outbound traffic. See <c>FWPM_CLASSIFY_OPTION0</c> for possible values.</para>
		/// </summary>
		FWP_CLASSIFY_OPTION_MULTICAST_STATE,

		/// <summary>
		/// <para>Specifies the source mapping conditions for callout filters. See</para>
		/// <para>FWPM_CLASSIFY_OPTION0</para>
		/// <para>for possible values.</para>
		/// <para>
		/// Loose source mapping allows unicast responses from a remote peer to match only the port number, instead of the entire source address.
		/// </para>
		/// </summary>
		FWP_CLASSIFY_OPTION_LOOSE_SOURCE_MAPPING,

		/// <summary>Specifies the unicast state lifetime, in seconds.</summary>
		FWP_CLASSIFY_OPTION_UNICAST_LIFETIME,

		/// <summary>Specifies the multicast/broadcast state lifetime, in seconds.</summary>
		FWP_CLASSIFY_OPTION_MCAST_BCAST_LIFETIME,

		/// <summary>
		/// <para>
		/// Specifies that the callout can set secure socket settings on the endpoint. Such flags are only allowed to increase the overall
		/// security level. The possible values are defined in the
		/// </para>
		/// <para>Mstcpip.h</para>
		/// <para>header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term/>
		/// <term>Value</term>
		/// <term/>
		/// <term>Meaning</term>
		/// <term/>
		/// </listheader>
		/// <item>
		/// <term/>
		/// <term>SOCKET_SETTINGS_GUARANTEE_ENCRYPTION 0x00000001</term>
		/// <term/>
		/// <term>
		/// Indicates that guaranteed encryption of traffic is required. This flag should be set if the default policy prefers methods of
		/// protection that do not use encryption. If this flag is set and encryption is not possible for any reason, no packets will be sent
		/// and a connection will not be established.
		/// </term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>SOCKET_SETTINGS_ALLOW_INSECURE 0x00000002</term>
		/// <term/>
		/// <term>
		/// Indicates that clear text connections are allowed. If this flag is set, some or all of the sent packets will be sent in clear
		/// text, especially if security with the peer could not be negotiated.
		/// </term>
		/// <term/>
		/// </item>
		/// </list>
		/// <para><c>Note</c> Available only in Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		FWP_CLASSIFY_OPTION_SECURE_SOCKET_SECURITY_FLAGS,

		/// <summary>
		/// <para>Allows the callout to specify the specific main mode (MM) policy used for the connection.</para>
		/// <para><c>Note</c> Available only in Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_MM_POLICY_KEY,

		/// <summary>
		/// <para>Allows the callout to specify the specific quick mode (QM) policy used for the connection.</para>
		/// <para><c>Note</c> Available only in Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_QM_POLICY_KEY,

		/// <summary/>
		FWP_CLASSIFY_OPTION_LOCAL_ONLY_MAPPING,

		/// <summary>Maximum value for testing purposes.</summary>
		FWP_CLASSIFY_OPTION_MAX,
	}

	/// <summary>The FWP_VALUE0 or an FWP_CONDITION_VALUE0structure.</summary>
	/// <remarks>Not all data types are valid for each structure; see the tagged union in each structure to determine which are allowed.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_data_type typedef enum FWP_DATA_TYPE_ { FWP_EMPTY = 0,
	// FWP_UINT8, FWP_UINT16, FWP_UINT32, FWP_UINT64, FWP_INT8, FWP_INT16, FWP_INT32, FWP_INT64, FWP_FLOAT, FWP_DOUBLE,
	// FWP_BYTE_ARRAY16_TYPE, FWP_BYTE_BLOB_TYPE, FWP_SID, FWP_SECURITY_DESCRIPTOR_TYPE, FWP_TOKEN_INFORMATION_TYPE,
	// FWP_TOKEN_ACCESS_INFORMATION_TYPE, FWP_UNICODE_STRING_TYPE, FWP_BYTE_ARRAY6_TYPE, FWP_SINGLE_DATA_TYPE_MAX = 0xff, FWP_V4_ADDR_MASK,
	// FWP_V6_ADDR_MASK, FWP_RANGE_TYPE, FWP_DATA_TYPE_MAX } FWP_DATA_TYPE;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_DATA_TYPE_")]
	public enum FWP_DATA_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Indicates no data.</para>
		/// </summary>
		FWP_EMPTY,

		/// <summary>Indicates an unsigned 8-bit integer value.</summary>
		FWP_UINT8,

		/// <summary>Indicates an unsigned 16-bit integer value.</summary>
		FWP_UINT16,

		/// <summary>Indicates an unsigned 32-bit integer value.</summary>
		FWP_UINT32,

		/// <summary>Indicates an unsigned 64-bit integer value.</summary>
		FWP_UINT64,

		/// <summary>Indicates a signed 8-bit integer value.</summary>
		FWP_INT8,

		/// <summary>Indicates a signed 16-bit integer value.</summary>
		FWP_INT16,

		/// <summary>Indicates a signed 32-bit integer value.</summary>
		FWP_INT32,

		/// <summary>Indicates a signed 64-bit integer value.</summary>
		FWP_INT64,

		/// <summary>Indicates a pointer to a single-precision floating-point value.</summary>
		FWP_FLOAT,

		/// <summary>Indicates a pointer to a double-precision floating-point value.</summary>
		FWP_DOUBLE,

		/// <summary>
		/// <para>Indicates a pointer to an</para>
		/// <para>FWP_BYTE_ARRAY16</para>
		/// <para>structure.</para>
		/// </summary>
		FWP_BYTE_ARRAY16_TYPE,

		/// <summary>
		/// <para>Indicates a pointer to an</para>
		/// <para>FWP_BYTE_BLOB</para>
		/// <para>structure.</para>
		/// </summary>
		FWP_BYTE_BLOB_TYPE,

		/// <summary>Indicates a pointer to a SID.</summary>
		FWP_SID,

		/// <summary>
		/// <para>Indicates a pointer to an</para>
		/// <para>FWP_BYTE_BLOB</para>
		/// <para>structure that describes a security descriptor.</para>
		/// </summary>
		FWP_SECURITY_DESCRIPTOR_TYPE,

		/// <summary>
		/// <para>Indicates a pointer to an</para>
		/// <para>FWP_BYTE_BLOB</para>
		/// <para>structure that describes token information.</para>
		/// </summary>
		FWP_TOKEN_INFORMATION_TYPE,

		/// <summary>
		/// <para>Indicates a pointer to an</para>
		/// <para>FWP_BYTE_BLOB</para>
		/// <para>structure that describes token access information.</para>
		/// </summary>
		FWP_TOKEN_ACCESS_INFORMATION_TYPE,

		/// <summary>Indicates a pointer to a null-terminated unicode string.</summary>
		FWP_UNICODE_STRING_TYPE,

		/// <summary>Reserved.</summary>
		FWP_BYTE_ARRAY6_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xff</para>
		/// <para>Reserved for future use.</para>
		/// </summary>
		FWP_SINGLE_DATA_TYPE_MAX = 0xff,

		/// <summary>
		/// <para>Indicates a pointer to an</para>
		/// <para>FWP_V4_ADDR_AND_MASK</para>
		/// <para>structure.</para>
		/// </summary>
		FWP_V4_ADDR_MASK,

		/// <summary>
		/// <para>Indicates a pointer to an</para>
		/// <para>FWP_V6_ADDR_AND_MASK</para>
		/// <para>structure.</para>
		/// </summary>
		FWP_V6_ADDR_MASK,

		/// <summary>
		/// <para>Indicates a pointer to an</para>
		/// <para>FWP_RANGE0</para>
		/// <para>structure.</para>
		/// </summary>
		FWP_RANGE_TYPE,

		/// <summary>Maximum value for testing purposes.</summary>
		FWP_DATA_TYPE_MAX,
	}

	/// <summary>The <c>FWP_DIRECTION</c> enumerated type specifies direction of network traffic.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_direction typedef enum FWP_DIRECTION_ {
	// FWP_DIRECTION_OUTBOUND = 0, FWP_DIRECTION_INBOUND, FWP_DIRECTION_MAX } FWP_DIRECTION;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_DIRECTION_")]
	public enum FWP_DIRECTION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies outbound traffic.</para>
		/// </summary>
		FWP_DIRECTION_OUTBOUND,

		/// <summary>Specifies inbound traffic.</summary>
		FWP_DIRECTION_INBOUND,

		/// <summary>Maximum value for testing purposes.</summary>
		FWP_DIRECTION_MAX,
	}

	/// <summary>
	/// The <c>FWP_ETHER_ENCAP_METHOD</c> enumerated type specifies the method of encapsulating Ethernet II and SNAP traffic. Reserved.
	/// </summary>
	/// <remarks>This enumeration is reserved.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_ether_encap_method typedef enum FWP_ETHER_ENCAP_METHOD_ {
	// FWP_ETHER_ENCAP_METHOD_ETHER_V2 = 0, FWP_ETHER_ENCAP_METHOD_SNAP = 1, FWP_ETHER_ENCAP_METHOD_SNAP_W_OUI_ZERO = 3 } FWP_ETHER_ENCAP_METHOD;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_ETHER_ENCAP_METHOD_")]
	public enum FWP_ETHER_ENCAP_METHOD
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies Ethernet V2 encapsulation.</para>
		/// </summary>
		FWP_ETHER_ENCAP_METHOD_ETHER_V2 = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Specifies Subnet Access Protocol (SNAP) encapsulation with an unknown Organizationally Unique Identifier (OUI) and Service Access
		/// Point (SAP) prefix.
		/// </para>
		/// </summary>
		FWP_ETHER_ENCAP_METHOD_SNAP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Specifies SNAP encapsulation with a recognized OUI and a SAP prefix of 03.AA.AA.00.00.00 + Ethertype.</para>
		/// </summary>
		FWP_ETHER_ENCAP_METHOD_SNAP_W_OUI_ZERO = 3,
	}

	/// <summary>Flags for <c>FWPM_FILTER_ENUM_TEMPLATE0_</c>.</summary>
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwpmtypes.FWPM_FILTER_ENUM_TEMPLATE0_")]
	[Flags]
	public enum FWP_FILTER_ENUM_FLAG : uint
	{
		/// <summary>Only return the terminating filter with the highest weight.</summary>
		FWP_FILTER_ENUM_FLAG_BEST_TERMINATING_MATCH = 0x00000001,

		/// <summary>Return all matching filters sorted by weight (highest to lowest).</summary>
		FWP_FILTER_ENUM_FLAG_SORTED = 0x00000002,

		/// <summary>Return only boot-time filters.</summary>
		FWP_FILTER_ENUM_FLAG_BOOTTIME_ONLY = 0x00000004,

		/// <summary>Include boot-time filters; ignored if the <c>FWP_FILTER_ENUM_FLAG_BOOTTIME_ONLY</c> flag is set.</summary>
		FWP_FILTER_ENUM_FLAG_INCLUDE_BOOTTIME = 0x00000008,

		/// <summary>Include disabled filters; ignored if the <c>FWP_FILTER_ENUM_FLAG_BOOTTIME_ONLY</c> flag is set.</summary>
		FWP_FILTER_ENUM_FLAG_INCLUDE_DISABLED = 0x00000010,

		/// <summary/>
		FWP_FILTER_ENUM_FLAG_RESERVED1 = 0x00000020,
	}

	/// <summary>The <c>FWP_FILTER_ENUM_TYPE</c> enumerated type specifies how the filter enum conditions should be interpreted.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_filter_enum_type typedef enum FWP_FILTER_ENUM_TYPE_ {
	// FWP_FILTER_ENUM_FULLY_CONTAINED = 0, FWP_FILTER_ENUM_OVERLAPPING, FWP_FILTER_ENUM_TYPE_MAX } FWP_FILTER_ENUM_TYPE;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_FILTER_ENUM_TYPE_")]
	public enum FWP_FILTER_ENUM_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Return only filters that fully contain the enum conditions.</para>
		/// </summary>
		FWP_FILTER_ENUM_FULLY_CONTAINED,

		/// <summary>Return filters that overlap with the enum conditions, including filters that fully contain the enum conditions.</summary>
		FWP_FILTER_ENUM_OVERLAPPING,

		/// <summary>Maximum value for testing purposes.</summary>
		FWP_FILTER_ENUM_TYPE_MAX,
	}

	/// <summary>The <c>FWP_IP_VERSION</c> enumerated type specifies the IP version.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_ip_version typedef enum FWP_IP_VERSION_ {
	// FWP_IP_VERSION_V4 = 0, FWP_IP_VERSION_V6, FWP_IP_VERSION_NONE, FWP_IP_VERSION_MAX } FWP_IP_VERSION;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_IP_VERSION_")]
	public enum FWP_IP_VERSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies IPv4.</para>
		/// </summary>
		FWP_IP_VERSION_V4,

		/// <summary>Specifies IPv6.</summary>
		FWP_IP_VERSION_V6,

		/// <summary>Reserved.</summary>
		FWP_IP_VERSION_NONE,

		/// <summary>Maximum value for testing purposes.</summary>
		FWP_IP_VERSION_MAX,
	}

	/// <summary>The <c>FWP_MATCH_TYPE</c> enumerated type specifies different match types allowed in filter conditions.</summary>
	/// <remarks>
	/// <para>
	/// In general, the value data type and the filter condition data type must be the same. The Base Filtering Engine (BFE) does not perform
	/// any data conversion. For example, an FWP_UINT32 value cannot be compared with an FWP_UINT16 value.
	/// </para>
	/// <para>Exceptions to this rule are as follows.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>An FWP_UINT32 field that contains an IPv4 address can be compared with an FWP_V4_ADDR_MASK value.</term>
	/// </item>
	/// <item>
	/// <term>An FWP_BYTE_ARRAY16_TYPE field that contains an IPv6 address can be compared with an FWP_V6_ADDR_MASK value.</term>
	/// </item>
	/// <item>
	/// <term>An FWP_TOKEN_INFORMATION_TYPE field can be compared with an FWP_SECURITY_DESCRIPTOR_TYPE value when adding filters.</term>
	/// </item>
	/// <item>
	/// <term>An FWP_TOKEN_ACCESS_INFORMATION_TYPE field can be compared with an FWP_SECURITY_DESCRIPTOR_TYPE value when adding filters.</term>
	/// </item>
	/// <item>
	/// <term>An FWP_TOKEN_INFORMATION_TYPE field can be compared with an FWP_SID value when enumerating.</term>
	/// </item>
	/// <item>
	/// <term>An FWP_TOKEN_ACCESS_INFORMATION_TYPE field can be compared with an FWP_SID value when enumerating.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_match_type typedef enum FWP_MATCH_TYPE_ { FWP_MATCH_EQUAL
	// = 0, FWP_MATCH_GREATER, FWP_MATCH_LESS, FWP_MATCH_GREATER_OR_EQUAL, FWP_MATCH_LESS_OR_EQUAL, FWP_MATCH_RANGE, FWP_MATCH_FLAGS_ALL_SET,
	// FWP_MATCH_FLAGS_ANY_SET, FWP_MATCH_FLAGS_NONE_SET, FWP_MATCH_EQUAL_CASE_INSENSITIVE, FWP_MATCH_NOT_EQUAL, FWP_MATCH_PREFIX,
	// FWP_MATCH_NOT_PREFIX, FWP_MATCH_TYPE_MAX } FWP_MATCH_TYPE;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_MATCH_TYPE_")]
	public enum FWP_MATCH_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Tests whether the value is equal to the condition value.</para>
		/// <para>All data types support</para>
		/// <para>FWP_MATCH_EQUAL</para>
		/// <para>.</para>
		/// </summary>
		FWP_MATCH_EQUAL,

		/// <summary>
		/// <para>Tests whether the value is greater than the condition value.</para>
		/// <para>Only sortable data types support</para>
		/// <para>FWP_MATCH_GREATER</para>
		/// <para>. Sortable data types consist of all integer types, FWP_BYTE_ARRAY16_TYPE, FWP_BYTE_BLOB_TYPE, and FWP_UNICODE_STRING_TYPE.</para>
		/// </summary>
		FWP_MATCH_GREATER,

		/// <summary>
		/// <para>Tests whether the value is less than the condition value.</para>
		/// <para>Only sortable data types support</para>
		/// <para>FWP_MATCH_LESS</para>
		/// <para>.</para>
		/// </summary>
		FWP_MATCH_LESS,

		/// <summary>
		/// <para>Tests whether the value is greater than or equal to the condition value.</para>
		/// <para>Only sortable data types support</para>
		/// <para>FWP_MATCH_GREATER_OR_EQUAL</para>
		/// <para>.</para>
		/// </summary>
		FWP_MATCH_GREATER_OR_EQUAL,

		/// <summary>
		/// <para>Tests whether the value is less than or equal to the condition value.</para>
		/// <para>Only sortable data types support</para>
		/// <para>FWP_MATCH_LESS_OR_EQUAL</para>
		/// <para>.</para>
		/// </summary>
		FWP_MATCH_LESS_OR_EQUAL,

		/// <summary>
		/// <para>Tests whether the value is within a given range of condition values.</para>
		/// <para>Only sortable data types support</para>
		/// <para>FWP_MATCH_RANGE</para>
		/// <para>.</para>
		/// </summary>
		FWP_MATCH_RANGE,

		/// <summary>
		/// <para>Tests whether all flags are set.</para>
		/// <para>Only unsigned integer data types support</para>
		/// <para>FWP_MATCH_FLAGS_ALL_SET</para>
		/// <para>.</para>
		/// </summary>
		FWP_MATCH_FLAGS_ALL_SET,

		/// <summary>
		/// <para>Tests whether any flags are set.</para>
		/// <para>Only unsigned integer data types support</para>
		/// <para>FWP_MATCH_FLAGS_ANY_SET</para>
		/// <para>.</para>
		/// </summary>
		FWP_MATCH_FLAGS_ANY_SET,

		/// <summary>
		/// <para>Tests whether no flags are set.</para>
		/// <para>Only unsigned integer data types support</para>
		/// <para>FWP_MATCH_FLAGS_NONE_SET</para>
		/// <para>.</para>
		/// </summary>
		FWP_MATCH_FLAGS_NONE_SET,

		/// <summary>
		/// <para>Tests whether the value is equal to the condition value. The test is case insensitive.</para>
		/// <para>Only the FWP_UNICODE_STRING_TYPE data type supports</para>
		/// <para>FWP_MATCH_EQUAL_CASE_INSENSITIVE</para>
		/// <para>.</para>
		/// </summary>
		FWP_MATCH_EQUAL_CASE_INSENSITIVE,

		/// <summary>
		/// <para>Tests whether the value is not equal to the condition value.</para>
		/// <para>Only sortable data types support</para>
		/// <para>FWP_MATCH_NOT_EQUAL</para>
		/// <para>.</para>
		/// <para><c>Note</c> Available only in Windows 7 and Windows Server 2008 R2.</para>
		/// </summary>
		FWP_MATCH_NOT_EQUAL,

		/// <summary/>
		FWP_MATCH_PREFIX,

		/// <summary/>
		FWP_MATCH_NOT_PREFIX,

		/// <summary>Maximum value for testing purposes.</summary>
		FWP_MATCH_TYPE_MAX,
	}

	/// <summary>The <c>FWP_AF</c> enumerated type specifies the address family.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_af typedef enum FWP_NE_FAMILY_ { FWP_AF_INET,
	// FWP_AF_INET6, FWP_AF_ETHER, FWP_AF_NONE } FWP_AF;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_NE_FAMILY_")]
	public enum FWP_NE_FAMILY
	{
		/// <summary>Specifies an address as an IPv4 address.</summary>
		FWP_AF_INET = FWP_IP_VERSION.FWP_IP_VERSION_V4,

		/// <summary>Specifies an address as an IPv6 address.</summary>
		FWP_AF_INET6 = FWP_IP_VERSION.FWP_IP_VERSION_V6,

		/// <summary>Reserved.</summary>
		FWP_AF_ETHER = FWP_IP_VERSION.FWP_IP_VERSION_NONE,

		/// <summary>Placeholder value to be used when the address family is not yet identified.</summary>
		FWP_AF_NONE = FWP_AF_ETHER + 1,
	}

	/// <summary>The <c>FWP_VSWITCH_NETWORK_TYPE</c> enumeration specifies the network type of a vSwitch.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ne-fwptypes-fwp_vswitch_network_type typedef enum
	// FWP_VSWITCH_NETWORK_TYPE_ { FWP_VSWITCH_NETWORK_TYPE_UNKNOWN = 0, FWP_VSWITCH_NETWORK_TYPE_PRIVATE, FWP_VSWITCH_NETWORK_TYPE_INTERNAL,
	// FWP_VSWITCH_NETWORK_TYPE_EXTERNAL } FWP_VSWITCH_NETWORK_TYPE;
	[PInvokeData("fwptypes.h", MSDNShortId = "NE:fwptypes.FWP_VSWITCH_NETWORK_TYPE_")]
	public enum FWP_VSWITCH_NETWORK_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies an unknown network type.</para>
		/// </summary>
		FWP_VSWITCH_NETWORK_TYPE_UNKNOWN,

		/// <summary>Specifies a private network.</summary>
		FWP_VSWITCH_NETWORK_TYPE_PRIVATE,

		/// <summary>Specifies an internal network.</summary>
		FWP_VSWITCH_NETWORK_TYPE_INTERNAL,

		/// <summary>Specifies an external network.</summary>
		FWP_VSWITCH_NETWORK_TYPE_EXTERNAL,
	}

	/// <summary>The <c>FWP_BYTE_ARRAY16</c> structure stores an array of exactly 16 bytes.</summary>
	/// <remarks>This data type is useful for IPv6 addresses.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwp_byte_array16 typedef struct FWP_BYTE_ARRAY16_ { UINT8
	// byteArray16[16]; } FWP_BYTE_ARRAY16;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWP_BYTE_ARRAY16_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWP_BYTE_ARRAY16
	{
		private Guid block;

		/// <summary>Array of 16 bytes.</summary>
		public byte[] byteArray16 { get => block.ToByteArray(); set => block = new(value); }
	}

	[StructLayout(LayoutKind.Explicit, Pack = 4)]
	internal struct FWP_BYTE_ARRAY_ADDR
	{
		[FieldOffset(0)]
		public IN_ADDR addr;

		[FieldOffset(0)]
		public IN6_ADDR addr6;
	}

	/// <summary>The <c>FWP_BYTE_ARRAY6</c> structure stores an array of exactly 6 bytes. Reserved.</summary>
	/// <remarks>This structure is reserved.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwp_byte_array6 typedef struct FWP_BYTE_ARRAY6_ { UINT8
	// byteArray6[6]; } FWP_BYTE_ARRAY6;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWP_BYTE_ARRAY6_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWP_BYTE_ARRAY6
	{
		/// <summary>Array of 6 bytes.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public byte[] byteArray6;
	}

	/// <summary>The <c>FWP_BYTE_BLOB</c> structure stores an array containing a variable number of bytes.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwp_byte_blob typedef struct FWP_BYTE_BLOB_ { UINT32 size;
	// UINT8 *data; } FWP_BYTE_BLOB;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWP_BYTE_BLOB_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWP_BYTE_BLOB : IBlob<byte>
	{
		/// <summary>Number of bytes in the array.</summary>
		public uint size;

		/// <summary>Pointer to the array.</summary>
		public IntPtr data;
	}

	/// <summary>
	/// The <c>FWP_CONDITION_VALUE0</c> structure contains values that are used in filter conditions when testing for matching filters.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The data type of <c>FWP_CONDITION_VALUE0</c> must be compatible with the data type of the FWP_VALUE0 to which it is being compared.
	/// However, this does not mean the data types necessarily need to be the same. For example, an FWP_V4_ADDR_MASK can be compared to an
	/// FWP_UINT32 containing an IPv4 address. See FWP_MATCH_TYPE for detailed information about <c>FWP_CONDITION_VALUE0</c> and
	/// <c>FWP_VALUE0</c> compatibility rules.
	/// </para>
	/// <para>
	/// <c>FWP_CONDITION_VALUE0</c> is a specific implementation of FWP_CONDITION_VALUE. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwp_condition_value0 typedef struct FWP_CONDITION_VALUE0_ {
	// FWP_DATA_TYPE type; union { UINT8 uint8; UINT16 uint16; UINT32 uint32; UINT64 *uint64; INT8 int8; INT16 int16; INT32 int32; INT64
	// *int64; float float32; double *double64; FWP_BYTE_ARRAY16 *byteArray16; FWP_BYTE_BLOB *byteBlob; SID *sid; FWP_BYTE_BLOB *sd;
	// FWP_TOKEN_INFORMATION *tokenInformation; FWP_BYTE_BLOB *tokenAccessInformation; LPWSTR unicodeString; FWP_BYTE_ARRAY6 *byteArray6;
	// FWP_V4_ADDR_AND_MASK *v4AddrMask; FWP_V6_ADDR_AND_MASK *v6AddrMask; FWP_RANGE0 *rangeValue; }; } FWP_CONDITION_VALUE0;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWP_CONDITION_VALUE0_")]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct FWP_CONDITION_VALUE0
	{
		/// <summary>
		/// <para>Specifies the data type of the condition value.</para>
		/// <para>See FWP_DATA_TYPE for more information.</para>
		/// </summary>
		[FieldOffset(0)]
		public FWP_DATA_TYPE type;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_UINT8.</para>
		/// <para>An unsigned 8-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public byte uint8;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_UINT16.</para>
		/// <para>An unsigned 16-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public ushort uint16;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_UINT32.</para>
		/// <para>An unsigned 32-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public uint uint32;

		[FieldOffset(8)]
		private IntPtr ptr;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_UINT64.</para>
		/// <para>A pointer to an unsigned 64-bit integer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This value cannot be null.</para>
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<ulong> uint64 { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_INT8.</para>
		/// <para>A signed 8-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public sbyte int8;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_INT16.</para>
		/// <para>A signed 16-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public short int16;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_INT32.</para>
		/// <para>A signed 32-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public int int32;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_INT64.</para>
		/// <para>A pointer to a signed 64-bit integer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This value cannot be null.</para>
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<long> int64 { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_FLOAT.</para>
		/// <para>A single-precision floating-point value.</para>
		/// </summary>
		[FieldOffset(8)]
		public float float32;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_DOUBLE.</para>
		/// <para>A pointer to a double-precision floating-point value.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This value cannot be null.</para>
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<double> double64 { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_BYTE_ARRAY16_TYPE.</para>
		/// <para>A pointer to a FWP_BYTE_ARRAY16 structure.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This value cannot be null.</para>
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_ARRAY16> byteArray16 { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_BYTE_BLOB_TYPE.</para>
		/// <para>A pointer to a FWP_BYTE_BLOB structure.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>FWP_BYTE_BLOB structure cannot be null.</para>
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_BLOB> byteBlob { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_SID.</para>
		/// <para>A pointer to a security identifier (SID) structure.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This security identifier cannot be null.</para>
		/// </para>
		/// </summary>
		[FieldOffset(8)]
		public PSID sid;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_SECURITY_DESCRIPTOR_TYPE.</para>
		/// <para>A pointer to a security descriptor contained in a FWP_BYTE_BLOB structure.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>Security descriptors cannot be null when used in filter conditions. Moreover, they need to be in self-relative format.</para>
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_BLOB> sd { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_TOKEN_INFORMATION_TYPE.</para>
		/// <para>A pointer to token information contained in a FWP_TOKEN_INFORMATION structure.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_TOKEN_INFORMATION> tokenInformation { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_TOKEN_ACCESS_INFORMATION_TYPE.</para>
		/// <para>A pointer to token access information contained in a FWP_BYTE_BLOB structure.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>FWP_BYTE_BLOB structure cannot be null.</para>
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_BLOB> tokenAccessInformation { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_UNICODE_STRING_TYPE.</para>
		/// <para>A pointer to a null-terminated unicode string.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This value cannot be null.</para>
		/// </para>
		/// </summary>
		[FieldOffset(8)]
		public StrPtrUni unicodeString;

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_BYTE_ARRAY6_TYPE.</para>
		/// <para>A pointer to a FWP_BYTE_ARRAY6 structure.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This value cannot be null.</para>
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Available only in Windows 7 and Windows Server 2008 R2.</para>
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_ARRAY6> byteArray6 { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_V4_ADDR_MASK.</para>
		/// <para>A pointer to an IPv4 address contained in an FWP_V4_ADDR_AND_MASK structure.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_V4_ADDR_AND_MASK> v4AddrMask { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_V6_ADDR_MASK.</para>
		/// <para>A pointer to an IPv6 address contained in an FWP_V6_ADDR_AND_MASK structure.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_V6_ADDR_AND_MASK> v6AddrMask { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>Available when <c>type</c> is FWP_RANGE_TYPE.</para>
		/// <para>A pointer to a range contained in an FWP_RANGE0 structure.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_RANGE0> rangeValue { get => new(ptr, false); set => ptr = value; }
	}

	/// <summary>The <c>FWP_RANGE0</c> structure specifies a range of values.</summary>
	/// <remarks>
	/// <para>
	/// The elements <c>valueLow</c> and <c>valueHigh</c> must be the same data type and <c>valueHigh</c> must be greater than or equal to <c>valueLow</c>.
	/// </para>
	/// <para>Ranges are always inclusive. Thus, if a value equals <c>valueLow</c> or <c>valueHigh</c>, it is contained in the range.</para>
	/// <para>
	/// <c>FWP_RANGE0</c> is a specific implementation of FWP_RANGE. See WFP Version-Independent Names and Targeting Specific Versions of
	/// Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwp_range0 typedef struct FWP_RANGE0_ { FWP_VALUE0 valueLow;
	// FWP_VALUE0 valueHigh; } FWP_RANGE0;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWP_RANGE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWP_RANGE0
	{
		/// <summary>
		/// <para>Low value of the range.</para>
		/// <para>See FWP_VALUE0 for more information.</para>
		/// </summary>
		public FWP_VALUE0 valueLow;

		/// <summary>
		/// <para>High value of the range.</para>
		/// <para>See FWP_VALUE0 for more information.</para>
		/// </summary>
		public FWP_VALUE0 valueHigh;
	}

	/// <summary>The <c>FWP_TOKEN_INFORMATION</c> structure defines a set of security identifiers that are used for user-mode classification.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwp_token_information typedef struct FWP_TOKEN_INFORMATION_ {
	// ULONG sidCount; PSID_AND_ATTRIBUTES sids; ULONG restrictedSidCount; PSID_AND_ATTRIBUTES restrictedSids; } FWP_TOKEN_INFORMATION;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWP_TOKEN_INFORMATION_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWP_TOKEN_INFORMATION
	{
		/// <summary>The number of <see cref="SID_AND_ATTRIBUTES"/> structures stored in the <c>sids</c> array.</summary>
		public uint sidCount;

		/// <summary>An array of SID_AND_ATTRIBUTES structures containing user and group security information.</summary>
		public IntPtr sids;

		/// <summary>The number of SID_AND_ATTRIBUTES structures stored in the <c>restrictedSids</c> array.</summary>
		public uint restrictedSidCount;

		/// <summary>An array of SID_AND_ATTRIBUTES structures containing restricted SIDs security information.</summary>
		public IntPtr restrictedSids;
	}

	/// <summary>The <c>FWP_V4_ADDR_AND_MASK</c> structure specifies IPv4 address and mask in host order..</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwp_v4_addr_and_mask typedef struct FWP_V4_ADDR_AND_MASK_ {
	// UINT32 addr; UINT32 mask; } FWP_V4_ADDR_AND_MASK;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWP_V4_ADDR_AND_MASK_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWP_V4_ADDR_AND_MASK
	{
		/// <summary>Specifies an IPv4 address.</summary>
		public IN_ADDR addr;

		/// <summary>Specifies an IPv4 mask.</summary>
		public IN_ADDR mask;
	}

	/// <summary>The <c>FWP_V6_ADDR_AND_MASK</c> structure specifies an IPv6 address and mask.</summary>
	/// <remarks>
	/// The mask is specified by the width in bits. For example, a prefixLength of 16 specifies a mask consisting of 16 1's followed by 112 0's.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwp_v6_addr_and_mask typedef struct FWP_V6_ADDR_AND_MASK_ {
	// UINT8 addr[16]; UINT8 prefixLength; } FWP_V6_ADDR_AND_MASK;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWP_V6_ADDR_AND_MASK_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FWP_V6_ADDR_AND_MASK
	{
		/// <summary>An array of size <c>FWP_V6_ADDR_SIZE</c> bytes containing an IPv6 address. <c>FWP_V6_ADDR_SIZE</c> maps to 16.</summary>
		public IN6_ADDR addr;

		/// <summary>Value specifying the prefix length of the IPv6 address.</summary>
		public byte prefixLength;
	}

	/// <summary>The <c>FWP_VALUE0</c> structure defines a data value that can be one of a number of different data types.</summary>
	/// <remarks>
	/// <para>For the unnamed union, switch_type(FWP_DATA_TYPE), switch_is(type).</para>
	/// <para>This is primarily used to supply incoming values to the filter engine.</para>
	/// <para>
	/// When IP addresses are stored in FWP_UINT32 format or when IP port is stored in FWP_UINT16 format, they are stored in host-order not network-order.
	/// </para>
	/// <para>
	/// <c>FWP_VALUE0</c> is a specific implementation of FWP_VALUE. See WFP Version-Independent Names and Targeting Specific Versions of
	/// Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwp_value0 typedef struct FWP_VALUE0_ { FWP_DATA_TYPE type;
	// union { UINT8 uint8; UINT16 uint16; UINT32 uint32; UINT64 *uint64; INT8 int8; INT16 int16; INT32 int32; INT64 *int64; float float32;
	// double *double64; FWP_BYTE_ARRAY16 *byteArray16; FWP_BYTE_BLOB *byteBlob; SID *sid; FWP_BYTE_BLOB *sd; FWP_TOKEN_INFORMATION
	// *tokenInformation; FWP_BYTE_BLOB *tokenAccessInformation; LPWSTR unicodeString; FWP_BYTE_ARRAY6 *byteArray6; }; } FWP_VALUE0;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWP_VALUE0_")]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct FWP_VALUE0
	{
		/// <summary>
		/// <para>The type of data for this value.</para>
		/// <para>See FWP_DATA_TYPE for more information.</para>
		/// </summary>
		[FieldOffset(0)]
		public FWP_DATA_TYPE type;

		/// <summary>
		/// <para>case(FWP_UINT8)</para>
		/// <para>An unsigned 8-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public byte uint8;

		/// <summary>
		/// <para>case(FWP_UINT16)</para>
		/// <para>An unsigned 16-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public ushort uint16;

		/// <summary>
		/// <para>case(FWP_UINT32)</para>
		/// <para>An unsigned 32-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public uint uint32;

		[FieldOffset(8)]
		private IntPtr ptr;

		/// <summary>
		/// <para>case(FWP_UINT64)</para>
		/// <para>A pointer to an unsigned 64-bit integer.</para>
		/// </summary>
		public SafeCoTaskMemStruct<ulong> uint64 { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>case(FWP_INT8)</para>
		/// <para>A signed 8-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public sbyte int8;

		/// <summary>
		/// <para>case(FWP_INT16)</para>
		/// <para>A signed 16-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public short int16;

		/// <summary>
		/// <para>case(FWP_INT32)</para>
		/// <para>A signed 32-bit integer.</para>
		/// </summary>
		[FieldOffset(8)]
		public int int32;

		/// <summary>
		/// <para>case(FWP_INT64)</para>
		/// <para>A pointer to a signed 64-bit integer.</para>
		/// </summary>
		public SafeCoTaskMemStruct<long> int64 { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>case(FWP_FLOAT)</para>
		/// <para>A single-precision floating-point value.</para>
		/// </summary>
		[FieldOffset(8)]
		public float float32;

		/// <summary>
		/// <para>case(FWP_DOUBLE)</para>
		/// <para>A pointer to a double-precision floating-point value.</para>
		/// </summary>
		public SafeCoTaskMemStruct<double> double64 { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>case(FWP_BYTE_ARRAY16_TYPE)</para>
		/// <para>A pointer to a FWP_BYTE_ARRAY16 structure.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_ARRAY16> byteArray16 { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>case(FWP_BYTE_BLOB_TYPE)</para>
		/// <para>A pointer to a FWP_BYTE_BLOB structure.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_BLOB> byteBlob { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>case(FWP_SID)</para>
		/// <para>A pointer to a SID.</para>
		/// </summary>
		[FieldOffset(8)]
		public PSID sid;

		/// <summary>
		/// <para>case(FWP_SECURITY_DESCRIPTOR_TYPE)</para>
		/// <para>
		/// A pointer to a security descriptor contained in a FWP_BYTE_BLOB structure. The data contained in the blob is a
		/// SECURITY_DESCRIPTOR structure.
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_BLOB> sd { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>case(FWP_TOKEN_INFORMATION_TYPE)</para>
		/// <para>A pointer to an FWP_TOKEN_INFORMATION structure.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_TOKEN_INFORMATION> tokenInformation { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>case(FWP_TOKEN_ACCESS_INFORMATION_TYPE)</para>
		/// <para>
		/// A pointer to token access information contained in a FWP_BYTE_BLOB structure. The data contained in the blob is a
		/// TOKEN_ACCESS_INFORMATION structure.
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_BLOB> tokenAccessInformation { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>case(FWP_UNICODE_STRING_TYPE)</para>
		/// <para>A pointer to a null-terminated unicode string.</para>
		/// </summary>
		[FieldOffset(8)]
		public StrPtrUni unicodeString;

		/// <summary>
		/// <para>case(FWP_BYTE_ARRAY6_TYPE)</para>
		/// <para>Reserved.</para>
		/// </summary>
		public SafeCoTaskMemStruct<FWP_BYTE_ARRAY6> byteArray6 { get => new(ptr, false); set => ptr = value; }

		/// <summary>Gets the value indicated by <see cref="type"/>.</summary>
		/// <returns>The translated value.</returns>
		public object? GetValue() => type switch
		{
			FWP_DATA_TYPE.FWP_UINT8 => uint8,
			FWP_DATA_TYPE.FWP_UINT16 => uint16,
			FWP_DATA_TYPE.FWP_UINT32 => uint32,
			FWP_DATA_TYPE.FWP_UINT64 => ptr == IntPtr.Zero ? 0UL : (ulong)uint64,
			FWP_DATA_TYPE.FWP_INT8 => int8,
			FWP_DATA_TYPE.FWP_INT16 => int16,
			FWP_DATA_TYPE.FWP_INT32 => int32,
			FWP_DATA_TYPE.FWP_INT64 => ptr == IntPtr.Zero ? 0L : (long)int64,
			FWP_DATA_TYPE.FWP_FLOAT => float32,
			FWP_DATA_TYPE.FWP_DOUBLE => ptr == IntPtr.Zero ? 0.0 : (double)double64,
			FWP_DATA_TYPE.FWP_BYTE_ARRAY16_TYPE => ptr == IntPtr.Zero ? null : byteArray16.AsRef().byteArray16,
			FWP_DATA_TYPE.FWP_BYTE_BLOB_TYPE => ptr == IntPtr.Zero ? null : byteBlob.AsSpan()[0].data.ToByteArray((int)byteBlob.AsSpan()[0].size),
			FWP_DATA_TYPE.FWP_SID => sid,
			FWP_DATA_TYPE.FWP_SECURITY_DESCRIPTOR_TYPE => ptr == IntPtr.Zero ? null : new SafePSECURITY_DESCRIPTOR(byteBlob.AsSpan()[0].data.ToByteArray((int)byteBlob.AsSpan()[0].size)!),
			FWP_DATA_TYPE.FWP_TOKEN_INFORMATION_TYPE => ptr.ToNullableStructure<FWP_TOKEN_INFORMATION>(),
			FWP_DATA_TYPE.FWP_TOKEN_ACCESS_INFORMATION_TYPE => ptr == IntPtr.Zero ? null : tokenAccessInformation.AsSpan()[0].data.ToStructure<TOKEN_ACCESS_INFORMATION>(),
			FWP_DATA_TYPE.FWP_UNICODE_STRING_TYPE => unicodeString.ToString(),
			FWP_DATA_TYPE.FWP_BYTE_ARRAY6_TYPE => ptr == IntPtr.Zero ? null : byteArray6.AsSpan()[0].byteArray6,
			FWP_DATA_TYPE.FWP_V4_ADDR_MASK => ptr.ToNullableStructure<FWP_V4_ADDR_AND_MASK>(),
			FWP_DATA_TYPE.FWP_V6_ADDR_MASK => ptr.ToNullableStructure<FWP_V6_ADDR_AND_MASK>(),
			FWP_DATA_TYPE.FWP_RANGE_TYPE => ptr.ToNullableStructure<FWP_RANGE0>(),
			_ => null,
		};
	}

	/// <summary>The <c>FWPM_DISPLAY_DATA0</c> structure stores an optional friendly name and an optional description for an object.</summary>
	/// <remarks>
	/// <para>In order to support MUI, both strings may contain indirect strings. See SHLoadIndirectString for details.</para>
	/// <para>
	/// <c>FWPM_DISPLAY_DATA0</c> is a specific implementation of FWPM_DISPLAY_DATA. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-fwpm_display_data0 typedef struct FWPM_DISPLAY_DATA0_ {
	// wchar_t *name; wchar_t *description; } FWPM_DISPLAY_DATA0;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.FWPM_DISPLAY_DATA0_")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FWPM_DISPLAY_DATA0
	{
		/// <summary>Optional friendly name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? name;

		/// <summary>Optional description.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? description;
	}

	/// <summary>The <c>IPSEC_VIRTUAL_IF_TUNNEL_INFO0</c> structure is used to store information specific to virtual interface tunneling.</summary>
	/// <remarks>
	/// <para>The <c>IPSEC_VIRTUAL_IF_TUNNEL_INFO0</c> structure is applicable only to Internet Key Exchange version 2 (IKEv2).</para>
	/// <para>
	/// <c>IPSEC_VIRTUAL_IF_TUNNEL_INFO0</c> is a specific implementation of IPSEC_VIRTUAL_IF_TUNNEL_INFO. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwptypes/ns-fwptypes-ipsec_virtual_if_tunnel_info0 typedef struct
	// IPSEC_VIRTUAL_IF_TUNNEL_INFO0_ { UINT64 virtualIfTunnelId; UINT64 trafficSelectorId; } IPSEC_VIRTUAL_IF_TUNNEL_INFO0;
	[PInvokeData("fwptypes.h", MSDNShortId = "NS:fwptypes.IPSEC_VIRTUAL_IF_TUNNEL_INFO0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_VIRTUAL_IF_TUNNEL_INFO0
	{
		/// <summary>ID of the virtual interface tunnel state.</summary>
		public ulong virtualIfTunnelId;

		/// <summary>ID of the virtual interface tunneling traffic selector(s).</summary>
		public ulong trafficSelectorId;
	}
}
