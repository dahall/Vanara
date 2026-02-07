using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

/// <summary>Items from the IScsiDsc.dll</summary>
public static partial class IScsiDsc
{
	/// <summary>For apis that take a port number this specifies that all ports should be used</summary>
	public const uint ISCSI_ALL_INITIATOR_PORTS = unchecked((uint)-1);

	/// <summary>For apis that take a port number, this specifies that any port can be used</summary>
	public const uint ISCSI_ANY_INITIATOR_PORT = unchecked((uint)-1);

	/// <summary/>
	public const uint ISCSI_LOGIN_OPTIONS_VERSION = 0;

	/// <summary/>
	public const int MAX_ISCSI_ALIAS_LEN = 255;

	/// <summary>Maximum length of a discovery domain name</summary>
	public const int MAX_ISCSI_DISCOVERY_DOMAIN_LEN = 256;

	/// <summary>Maxiumum length of a Initiator Name</summary>
	public const int MAX_ISCSI_HBANAME_LEN = 256;

	/// <summary>Maximum length of an iscsi name</summary>
	public const int MAX_ISCSI_NAME_LEN = 223;

	/// <summary>Maxiumum length of a text port address. It can be a DNS name or a . name</summary>
	public const int MAX_ISCSI_PORTAL_ADDRESS_LEN = MAX_ISCSI_TEXT_ADDRESS_LEN;

	/// <summary/>
	public const int MAX_ISCSI_PORTAL_ALIAS_LEN = 256;

	/// <summary>Maxiumum length of a portal names</summary>
	public const int MAX_ISCSI_PORTAL_NAME_LEN = 256;

	/// <summary>Maximum length of a text address</summary>
	public const int MAX_ISCSI_TEXT_ADDRESS_LEN = 256;

	/// <summary>Maximum length of a RADIUS server address + two terminating characters</summary>
	public const int MAX_RADIUS_ADDRESS_LEN = 41;

	private const string Lib_Iscsidsc = "iscsidsc.dll";

	private delegate Win32Error GetListDelegate(ref uint sz, IntPtr buf);

	/// <summary>
	/// The <c>IKE_AUTHENTICATION_METHOD</c> enumeration indicates the type of Internet Key Exchange (IKE) authentication method.
	/// </summary>
	/// <remarks>Used in conjunction with the SetIScsiIKEInfo function to establish the IPsec policy to use during iSCSI operations.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ne-iscsidsc-ike_authentication_method typedef enum {
	// IKE_AUTHENTICATION_PRESHARED_KEY_METHOD } IKE_AUTHENTICATION_METHOD, *PIKE_AUTHENTICATION_METHOD;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NE:iscsidsc.__unnamed_enum_2")]
	public enum IKE_AUTHENTICATION_METHOD
	{
		/// <summary>The authentication method was preshared.</summary>
		IKE_AUTHENTICATION_PRESHARED_KEY_METHOD = 1,
	}

	/// <summary>The type of key identifier.</summary>
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_1")]
	public enum IKE_IDENTIFICATION_PAYLOAD_TYPE
	{
		/// <summary>Indicates four bytes of binary data that constitute a version 4 IP address.</summary>
		ID_IPV4_ADDR = 1,

		/// <summary>An ANSI string that contains a fully qualified domain name. This string does not contain terminators.</summary>
		ID_FQDN = 2,

		/// <summary>An ANSI string that contains a fully qualified user name. This string does not contain terminators.</summary>
		ID_USER_FQDN = 3,

		/// <summary>Indicates 16 bytes of binary data that constitute a version 6 IP address.</summary>
		ID_IPV6_ADDR = 5,
	}

	/// <summary>The <c>ISCSI_AUTH_TYPES</c> enumeration indicates the type of authentication method utilized.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ne-iscsidsc-iscsi_auth_types typedef enum { ISCSI_NO_AUTH_TYPE,
	// ISCSI_CHAP_AUTH_TYPE, ISCSI_MUTUAL_CHAP_AUTH_TYPE } ISCSI_AUTH_TYPES, *PISCSI_AUTH_TYPES;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NE:iscsidsc.__unnamed_enum_1")]
	public enum ISCSI_AUTH_TYPES
	{
		/// <summary>No authentication type was specified.</summary>
		ISCSI_NO_AUTH_TYPE = 0,

		/// <summary>Challenge Handshake Authentication Protocol (CHAP) authentication.</summary>
		ISCSI_CHAP_AUTH_TYPE,

		/// <summary>Mutual (2-way) CHAP authentication.</summary>
		ISCSI_MUTUAL_CHAP_AUTH_TYPE,
	}

	/// <summary>The <c>ISCSI_DIGEST_TYPES</c> enumeration indicates the digest type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ne-iscsidsc-iscsi_digest_types typedef enum { ISCSI_DIGEST_TYPE_NONE,
	// ISCSI_DIGEST_TYPE_CRC32C } ISCSI_DIGEST_TYPES, *PISCSI_DIGEST_TYPES;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NE:iscsidsc.__unnamed_enum_0")]
	public enum ISCSI_DIGEST_TYPES
	{
		/// <summary>No digest is in use for guaranteeing data integrity.</summary>
		ISCSI_DIGEST_TYPE_NONE = 0,

		/// <summary>The digest for guaranteeing data integrity uses a 32-bit cyclic redundancy check.</summary>
		ISCSI_DIGEST_TYPE_CRC32C,
	}

	/// <summary>A bitwise OR of login flags that define certain characteristics of the login session.</summary>
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_0")]
	[Flags]
	public enum ISCSI_LOGIN_FLAGS : uint
	{
		/// <summary>Reserved for internal use.</summary>
		ISCSI_LOGIN_FLAG_RESERVED1 = 0x00000004,

		/// <summary>The RADIUS server is permitted to use the portal hopping function for a target if configured to do so.</summary>
		ISCSI_LOGIN_FLAG_ALLOW_PORTAL_HOPPING = 0x00000008,

		/// <summary>The login session must use the IPsec protocol.</summary>
		ISCSI_LOGIN_FLAG_REQUIRE_IPSEC = 0x00000001,

		/// <summary>
		/// Multipathing is allowed. When specified the iSCSI Initiator service will allow multiple sessions to the same target. If
		/// there are multiple sessions to the same target then there must be some sort of multipathing software installed otherwise
		/// data corruption will occur on the target.
		/// </summary>
		ISCSI_LOGIN_FLAG_MULTIPATH_ENABLED = 0x00000002,

		/// <summary/>
		ISCSI_LOGIN_FLAG_USE_RADIUS_RESPONSE = 0x00000010,

		/// <summary/>
		ISCSI_LOGIN_FLAG_USE_RADIUS_VERIFICATION = 0x00000020,
	}

	/// <summary>A bitmap that indicates which parts of the ISCSI_LOGIN_OPTIONS structure contain valid data.</summary>
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_0")]
	[Flags]
	public enum ISCSI_LOGIN_OPTIONS_INFO_SPECIFIED : uint
	{
		/// <summary>Specifies a user name to use in making a login connection.</summary>
		ISCSI_LOGIN_OPTIONS_USERNAME = 0x00000020,

		/// <summary>Specifies a password to use in making a login connection.</summary>
		ISCSI_LOGIN_OPTIONS_PASSWORD = 0x00000040,

		/// <summary>Specifies the type of digest in use for guaranteeing the integrity of header data.</summary>
		ISCSI_LOGIN_OPTIONS_HEADER_DIGEST = 0x00000001,

		/// <summary>Specifies the type of digest in use for guaranteeing the integrity of header data.</summary>
		ISCSI_LOGIN_OPTIONS_DATA_DIGEST = 0x00000002,

		/// <summary>Specifies the maximum number of connections to target devices associated with the login session.</summary>
		ISCSI_LOGIN_OPTIONS_MAXIMUM_CONNECTIONS = 0x00000004,

		/// <summary>
		/// Specifies the minimum time to wait, in seconds, before attempting to reconnect or reassign a connection that was dropped.
		/// </summary>
		ISCSI_LOGIN_OPTIONS_DEFAULT_TIME_2_WAIT = 0x00000008,

		/// <summary>Specifies the maximum time allowed to reassign commands after the initial wait indicated in DefaultTime2Wait.</summary>
		ISCSI_LOGIN_OPTIONS_DEFAULT_TIME_2_RETAIN = 0x00000010,

		/// <summary>Specifies the type of authentication that establishes the login session.</summary>
		ISCSI_LOGIN_OPTIONS_AUTH_TYPE = 0x00000080,
	}

	/// <summary>
	/// A bitmap that specifies the characteristics of the IPsec connection that the initiator uses to establish the connection. If
	/// IPsec security policy between the initiator and the target portal is already configured because of the portal group policy or a
	/// previous connection to the portal, the existing configuration takes precedence over the configuration specified in SecurityFlags
	/// and the security bitmap is ignored.
	/// <para>
	/// If the ISCSI_SECURITY_FLAG_VALID flag is set to 0, the iSCSI initiator service uses default values for the security flags that
	/// are defined in the registry.
	/// </para>
	/// </summary>
	[PInvokeData("iscsidsc.h")]
	public enum ISCSI_SECURITY_FLAGS
	{
		/// <summary>
		/// When set to 1, the initiator should make the connection in IPsec tunnel mode. Caller should set this flag or the
		/// ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED flag, but not both.
		/// </summary>
		ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED = 0x00000040,

		/// <summary>
		/// When set to 1, the initiator should make the connection in IPsec transport mode. Caller should set this flag or the
		/// ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED flag, but not both.
		/// </summary>
		ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED = 0x00000020,

		/// <summary>
		/// When set to 1, the initiator should make the connection with Perfect Forward Secrecy (PFS) mode enabled; otherwise, the
		/// initiator should make the connection with PFS mode disabled.
		/// </summary>
		ISCSI_SECURITY_FLAG_PFS_ENABLED = 0x00000010,

		/// <summary>
		/// When set to 1, the initiator should make the connection with aggressive mode enabled. Caller should set this flag or the
		/// ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED flag, but not both.
		/// <para>Note The Microsoft software initiator driver does not support aggressive mode.</para>
		/// </summary>
		ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED = 0x00000008,

		/// <summary>
		/// When set to 1, the initiator should make the connection with main mode enabled. Caller should set this flag or the
		/// ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED flag, but not both.
		/// </summary>
		ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED = 0x00000004,

		/// <summary>
		/// When set to 1, the initiator should make the connection with the IKE/IPsec protocol enabled; otherwise, the IKE/IPsec
		/// protocol is disabled.
		/// </summary>
		ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED = 0x00000002,

		/// <summary>
		/// When set to 1, the other mask values are valid; otherwise, the iSCSI initiator service will use bitmap values that were
		/// previously defined for the target portal, or if none are available, the initiator service uses the default values defined in
		/// the registry.
		/// </summary>
		ISCSI_SECURITY_FLAG_VALID = 0x00000001,
	}

	/// <summary>A bitmap of flags that affect how, and under what circumstances, a target is discovered and enumerated.</summary>
	[Flags]
	public enum ISCSI_TARGET_FLAGS : uint
	{
		/// <summary>
		/// The target is added to the list of static targets. However, ReportIscsiTargets does not report the target, unless it was
		/// also discovered dynamically by the iSCSI initiator, the Internet Storage Name Service (iSNS), or a SendTargets request.
		/// </summary>
		ISCSI_TARGET_FLAG_HIDE_STATIC_TARGET = 0x00000002,

		/// <summary>
		/// The iSCSI initiator service merges the information (if any) that it already has for this static target with the information
		/// that the caller passes to AddIscsiStaticTarget. If this flag is not set, the iSCSI initiator service overwrites the stored
		/// information with the information that the caller passes in.
		/// </summary>
		ISCSI_TARGET_FLAG_MERGE_TARGET_INFORMATION = 0x00000004
	}

	/// <summary>
	/// The <c>TARGET_INFORMATION_CLASS</c> enumeration specifies information about the indicated target device that the
	/// GetIScsiTargetInformation function retrieves.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ne-iscsidsc-target_information_class typedef enum { ProtocolType,
	// TargetAlias, DiscoveryMechanisms, PortalGroups, PersistentTargetMappings, InitiatorName, TargetFlags, LoginOptions }
	// TARGET_INFORMATION_CLASS, *PTARGET_INFORMATION_CLASS;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NE:iscsidsc.__unnamed_enum_4")]
	public enum TARGET_INFORMATION_CLASS
	{
		/// <summary>
		/// A value of the TARGETPROTOCOLTYPE structure, indicating the protocol that the initiator uses to communicate with the target device.
		/// </summary>
		[CorrespondingType(typeof(TARGETPROTOCOLTYPE))]
		ProtocolType,

		/// <summary>A null-terminated string that contains the alias of the target device.</summary>
		[CorrespondingType(typeof(string))]
		TargetAlias,

		/// <summary>
		/// A list of null-terminated strings that describe the discovery mechanisms that located the indicated target. The list is
		/// terminated by a double null.
		/// </summary>
		[CorrespondingType(typeof(string[]))]
		[CorrespondingType(typeof(IEnumerable<string>))]
		DiscoveryMechanisms,

		/// <summary>
		/// A ISCSI_TARGET_PORTAL_GROUP structure that contains descriptions of the portals in the portal group associated with the target.
		/// </summary>
		[CorrespondingType(typeof(ISCSI_TARGET_PORTAL_GROUP))]
		PortalGroups,

		/// <summary>
		/// An array of ISCSI_TARGET_MAPPING structures that contains information about the HBAs and buses through which the target can
		/// be reached. The array is preceded by a ULONG value that contains the number of elements in the array. Each
		/// ISCSI_TARGET_MAPPING structure is aligned on a 4-byte boundary.
		/// </summary>
		[CorrespondingType(typeof(ISCSI_TARGET_MAPPING))]
		PersistentTargetMappings,

		/// <summary>A null-terminated string that contains the initiator HBA that connects to the target.</summary>
		[CorrespondingType(typeof(string))]
		InitiatorName,

		/// <summary>The flags associated with the target. The following table lists the flags that can be associated with a target.</summary>
		[CorrespondingType(typeof(ISCSI_TARGET_FLAGS))]
		TargetFlags,

		/// <summary>A value of the ISCSI_LOGIN_OPTIONS structure that defines the login data.</summary>
		[CorrespondingType(typeof(ISCSI_LOGIN_OPTIONS))]
		LoginOptions,
	}

	/// <summary>
	/// The <c>TARGETPROTOCOLTYPE</c> enumeration indicates the type of protocol that the initiator must use to communicate with the target.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ne-iscsidsc-targetprotocoltype typedef enum { ISCSI_TCP_PROTOCOL_TYPE
	// } TARGETPROTOCOLTYPE, *PTARGETPROTOCOLTYPE;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NE:iscsidsc.__unnamed_enum_3")]
	public enum TARGETPROTOCOLTYPE
	{
		/// <summary>The target uses the TCP protocol.</summary>
		ISCSI_TCP_PROTOCOL_TYPE,
	}

	/// <summary>The <c>AddIscsiConnection</c> function adds a new iSCSI connection to an existing session.</summary>
	/// <param name="UniqueSessionId">
	/// A pointer to a structure of type ISCSI_UNIQUE_SESSION_ID that, on input, contains the session identifier for the session that
	/// was added.
	/// </param>
	/// <param name="InitiatorInstance">
	/// The name of the Host Bus Adapter (HBA) to use for the <c>SendTargets</c> request. If <c>null</c>, the iSCSI initiator service
	/// uses any HBA that can reach the indicated target portal is chosen.
	/// </param>
	/// <param name="InitiatorPortNumber">
	/// The number of the port on the initiator that the initiator uses to add the connection. A value of
	/// <c>ISCSI_ANY_INITIATOR_PORT</c> indicates that the initiator can use any of its ports to add the connection.
	/// </param>
	/// <param name="TargetPortal">
	/// <para>A pointer to an ISCSI_TARGET_PORTAL-type structure that indicates the target portal to use when adding the connection.</para>
	/// <para>
	/// The portal must belong to the same portal group that the initiator used to login to the target, and it must be a portal that the
	/// initiator discovered. The iSCSI initiator service does not verify that the target portal meets these requirements.
	/// </para>
	/// </param>
	/// <param name="SecurityFlags">
	/// <para>
	/// A bitmap that specifies the characteristics of the IPsec connection that the initiator uses to establish the connection. If
	/// IPsec security policy between the initiator and the target portal is already configured because of the portal group policy or a
	/// previous connection to the portal, the existing configuration takes precedence over the configuration specified in SecurityFlags
	/// and the security bitmap is ignored.
	/// </para>
	/// <para>
	/// If the <c>ISCSI_SECURITY_FLAG_VALID</c> flag is set to 0, the iSCSI initiator service uses default values for the security flags
	/// that are defined in the registry.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec tunnel mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec transport mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_PFS_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with Perfect Forward Secrecy (PFS) mode enabled; otherwise, the
	/// initiator should make the connection with PFS mode disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with aggressive mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with main mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with the IKE/IPsec protocol enabled; otherwise, the IKE/IPsec protocol
	/// is disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_VALID</term>
	/// <term>
	/// When set to 1, the other mask values are valid; otherwise, the iSCSI initiator service will use bitmap values that were
	/// previously defined for the target portal, or if none are available, the initiator service uses the default values defined in the registry.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="LoginOptions">
	/// A pointer to a structure of type ISCSI_LOGIN_OPTIONS that contains the options that specify the characteristics of the login session.
	/// </param>
	/// <param name="KeySize">The size, in bytes, of the preshared key that is passed to the target.</param>
	/// <param name="Key">
	/// If the IPsec security policy between the initiator and the target portal is already configured as a result of the portal group
	/// policy or a previous connection to the portal, the existing key takes precedence over the key currently specified in this member.
	/// </param>
	/// <param name="ConnectionId">
	/// An ISCSI_UNIQUE_CONNECTION_ID-type structure that, on output, receives an opaque value that uniquely identifies the connection
	/// that was added to the session.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines AddIScsiConnection as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-addiscsiconnectiona ISDSC_STATUS ISDSC_API
	// AddIScsiConnectionA( PISCSI_UNIQUE_SESSION_ID UniqueSessionId, PVOID Reserved, ULONG InitiatorPortNumber, PISCSI_TARGET_PORTALA
	// TargetPortal, ISCSI_SECURITY_FLAGS SecurityFlags, PISCSI_LOGIN_OPTIONS LoginOptions, ULONG KeySize, PCHAR Key,
	// PISCSI_UNIQUE_CONNECTION_ID ConnectionId );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.AddIScsiConnectionA")]
	public static extern Win32Error AddIScsiConnection(in ISCSI_UNIQUE_SESSION_ID UniqueSessionId, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance,
		uint InitiatorPortNumber, in ISCSI_TARGET_PORTAL TargetPortal, [Optional] ISCSI_SECURITY_FLAGS SecurityFlags, in ISCSI_LOGIN_OPTIONS LoginOptions,
		[Optional] uint KeySize, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Key, out ISCSI_UNIQUE_SESSION_ID ConnectionId);

	/// <summary>The <c>AddIscsiConnection</c> function adds a new iSCSI connection to an existing session.</summary>
	/// <param name="UniqueSessionId">
	/// A pointer to a structure of type ISCSI_UNIQUE_SESSION_ID that, on input, contains the session identifier for the session that
	/// was added.
	/// </param>
	/// <param name="InitiatorInstance">
	/// The name of the Host Bus Adapter (HBA) to use for the <c>SendTargets</c> request. If <c>null</c>, the iSCSI initiator service
	/// uses any HBA that can reach the indicated target portal is chosen.
	/// </param>
	/// <param name="InitiatorPortNumber">
	/// The number of the port on the initiator that the initiator uses to add the connection. A value of
	/// <c>ISCSI_ANY_INITIATOR_PORT</c> indicates that the initiator can use any of its ports to add the connection.
	/// </param>
	/// <param name="TargetPortal">
	/// <para>A pointer to an ISCSI_TARGET_PORTAL-type structure that indicates the target portal to use when adding the connection.</para>
	/// <para>
	/// The portal must belong to the same portal group that the initiator used to login to the target, and it must be a portal that the
	/// initiator discovered. The iSCSI initiator service does not verify that the target portal meets these requirements.
	/// </para>
	/// </param>
	/// <param name="SecurityFlags">
	/// <para>
	/// A bitmap that specifies the characteristics of the IPsec connection that the initiator uses to establish the connection. If
	/// IPsec security policy between the initiator and the target portal is already configured because of the portal group policy or a
	/// previous connection to the portal, the existing configuration takes precedence over the configuration specified in SecurityFlags
	/// and the security bitmap is ignored.
	/// </para>
	/// <para>
	/// If the <c>ISCSI_SECURITY_FLAG_VALID</c> flag is set to 0, the iSCSI initiator service uses default values for the security flags
	/// that are defined in the registry.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec tunnel mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec transport mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_PFS_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with Perfect Forward Secrecy (PFS) mode enabled; otherwise, the
	/// initiator should make the connection with PFS mode disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with aggressive mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with main mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with the IKE/IPsec protocol enabled; otherwise, the IKE/IPsec protocol
	/// is disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_VALID</term>
	/// <term>
	/// When set to 1, the other mask values are valid; otherwise, the iSCSI initiator service will use bitmap values that were
	/// previously defined for the target portal, or if none are available, the initiator service uses the default values defined in the registry.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="LoginOptions">
	/// A pointer to a structure of type ISCSI_LOGIN_OPTIONS that contains the options that specify the characteristics of the login session.
	/// </param>
	/// <param name="KeySize">The size, in bytes, of the preshared key that is passed to the target.</param>
	/// <param name="Key">
	/// If the IPsec security policy between the initiator and the target portal is already configured as a result of the portal group
	/// policy or a previous connection to the portal, the existing key takes precedence over the key currently specified in this member.
	/// </param>
	/// <param name="ConnectionId">
	/// An ISCSI_UNIQUE_CONNECTION_ID-type structure that, on output, receives an opaque value that uniquely identifies the connection
	/// that was added to the session.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines AddIScsiConnection as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-addiscsiconnectiona ISDSC_STATUS ISDSC_API
	// AddIScsiConnectionA( PISCSI_UNIQUE_SESSION_ID UniqueSessionId, PVOID Reserved, ULONG InitiatorPortNumber, PISCSI_TARGET_PORTALA
	// TargetPortal, ISCSI_SECURITY_FLAGS SecurityFlags, PISCSI_LOGIN_OPTIONS LoginOptions, ULONG KeySize, PCHAR Key,
	// PISCSI_UNIQUE_CONNECTION_ID ConnectionId );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.AddIScsiConnectionA")]
	public static extern Win32Error AddIScsiConnection(in ISCSI_UNIQUE_SESSION_ID UniqueSessionId, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance,
		uint InitiatorPortNumber, [In, Optional] IntPtr TargetPortal, [Optional] ISCSI_SECURITY_FLAGS SecurityFlags, [In, Optional] IntPtr LoginOptions,
		[Optional] uint KeySize, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Key, out ISCSI_UNIQUE_SESSION_ID ConnectionId);

	/// <summary>
	/// The <c>AddIscsiSendTargetPortal</c> function adds a static target portal to the list of target portals to which the iSCSI
	/// initiator service transmits <c>SendTargets</c> requests.
	/// </summary>
	/// <param name="InitiatorInstance">
	/// The initiator that the iSCSI initiator service utilizes to transmit <c>SendTargets</c> requests to the specified target portal.
	/// If <c>null</c>, the iSCSI initiator service will use any initiator that can reach the target portal.
	/// </param>
	/// <param name="InitiatorPortNumber">
	/// The port number to use for the <c>SendTargets</c> request. This port number corresponds to the source IP address on the Host-Bus
	/// Adapter (HBA). A value of <c>ISCSI_ALL_INITIATOR_PORTS</c> indicates that the initiator must select the appropriate port based
	/// upon current routing information.
	/// </param>
	/// <param name="LoginOptions">
	/// A pointer to a structure of type ISCSI_LOGIN_OPTIONS that contains the login options to use with the target portal.
	/// </param>
	/// <param name="SecurityFlags">
	/// <para>
	/// A bitmap that specifies the characteristics of the IPsec connection that the initiator adds to the session. If IPsec security
	/// policy between the initiator and the target portal is already configured as a result of the portal group policy or a previous
	/// connection to the portal, the existing configuration takes precedence over the configuration specified in SecurityFlags and the
	/// security bitmap is ignored.
	/// </para>
	/// <para>
	/// If the <c>ISCSI_SECURITY_FLAG_VALID</c> flag is set to 0, the iSCSI initiator service uses default values for the security flags
	/// that are defined in the registry.
	/// </para>
	/// <para>Caller can set any of the following flags in the bitmap:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec tunnel mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec transport mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_PFS_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with Perfect Forward Secrecy (PFS) mode enabled; otherwise, the
	/// initiator should make the connection with PFS mode disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with aggressive mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with main mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with the IKE/IPsec protocol enabled; otherwise, the IKE/IPsec protocol
	/// is disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_VALID</term>
	/// <term>
	/// When set to 1, the other mask values are valid; otherwise, the iSCSI initiator service will use bitmap values that were
	/// previously defined for the target portal, or if none are available, the initiator service uses the default values defined in the registry.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Portal">
	/// A pointer to a structure of type ISCSI_TARGET_PORTAL that indicates the portal to which SendTargets will be sent for target discovery.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines AddIScsiSendTargetPortal as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-addiscsisendtargetportala ISDSC_STATUS ISDSC_API
	// AddIScsiSendTargetPortalA( StrPtrAnsi InitiatorInstance, ULONG InitiatorPortNumber, PISCSI_LOGIN_OPTIONS LoginOptions,
	// ISCSI_SECURITY_FLAGS SecurityFlags, PISCSI_TARGET_PORTALA Portal );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.AddIScsiSendTargetPortalA")]
	public static extern Win32Error AddIScsiSendTargetPortal([Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance,
		[Optional] uint InitiatorPortNumber, in ISCSI_LOGIN_OPTIONS LoginOptions, [Optional] ISCSI_SECURITY_FLAGS SecurityFlags, in ISCSI_TARGET_PORTAL Portal);

	/// <summary>
	/// The <c>AddIscsiSendTargetPortal</c> function adds a static target portal to the list of target portals to which the iSCSI
	/// initiator service transmits <c>SendTargets</c> requests.
	/// </summary>
	/// <param name="InitiatorInstance">
	/// The initiator that the iSCSI initiator service utilizes to transmit <c>SendTargets</c> requests to the specified target portal.
	/// If <c>null</c>, the iSCSI initiator service will use any initiator that can reach the target portal.
	/// </param>
	/// <param name="InitiatorPortNumber">
	/// The port number to use for the <c>SendTargets</c> request. This port number corresponds to the source IP address on the Host-Bus
	/// Adapter (HBA). A value of <c>ISCSI_ALL_INITIATOR_PORTS</c> indicates that the initiator must select the appropriate port based
	/// upon current routing information.
	/// </param>
	/// <param name="LoginOptions">
	/// A pointer to a structure of type ISCSI_LOGIN_OPTIONS that contains the login options to use with the target portal.
	/// </param>
	/// <param name="SecurityFlags">
	/// <para>
	/// A bitmap that specifies the characteristics of the IPsec connection that the initiator adds to the session. If IPsec security
	/// policy between the initiator and the target portal is already configured as a result of the portal group policy or a previous
	/// connection to the portal, the existing configuration takes precedence over the configuration specified in SecurityFlags and the
	/// security bitmap is ignored.
	/// </para>
	/// <para>
	/// If the <c>ISCSI_SECURITY_FLAG_VALID</c> flag is set to 0, the iSCSI initiator service uses default values for the security flags
	/// that are defined in the registry.
	/// </para>
	/// <para>Caller can set any of the following flags in the bitmap:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec tunnel mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec transport mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_PFS_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with Perfect Forward Secrecy (PFS) mode enabled; otherwise, the
	/// initiator should make the connection with PFS mode disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with aggressive mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with main mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with the IKE/IPsec protocol enabled; otherwise, the IKE/IPsec protocol
	/// is disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_VALID</term>
	/// <term>
	/// When set to 1, the other mask values are valid; otherwise, the iSCSI initiator service will use bitmap values that were
	/// previously defined for the target portal, or if none are available, the initiator service uses the default values defined in the registry.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Portal">
	/// A pointer to a structure of type ISCSI_TARGET_PORTAL that indicates the portal to which SendTargets will be sent for target discovery.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines AddIScsiSendTargetPortal as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-addiscsisendtargetportala ISDSC_STATUS ISDSC_API
	// AddIScsiSendTargetPortalA( StrPtrAnsi InitiatorInstance, ULONG InitiatorPortNumber, PISCSI_LOGIN_OPTIONS LoginOptions,
	// ISCSI_SECURITY_FLAGS SecurityFlags, PISCSI_TARGET_PORTALA Portal );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.AddIScsiSendTargetPortalA")]
	public static extern Win32Error AddIScsiSendTargetPortal([Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance,
		[Optional] uint InitiatorPortNumber, [In, Optional] IntPtr LoginOptions, [Optional] ISCSI_SECURITY_FLAGS SecurityFlags, in ISCSI_TARGET_PORTAL Portal);

	/// <summary>The <c>AddIscsiStaticTarget</c> function adds a target to the list of static targets available to the iSCSI initiator.</summary>
	/// <param name="TargetName">The name of the target to add to the static target list.</param>
	/// <param name="TargetAlias">An alias associated with the TargetName.</param>
	/// <param name="TargetFlags">
	/// <para>A bitmap of flags that affect how, and under what circumstances, a target is discovered and enumerated.</para>
	/// <para>The following table lists the flags that can be associated with a target and the meaning of each flag.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ISCSI_TARGET_FLAG_HIDE_STATIC_TARGET</term>
	/// <term>
	/// The target is added to the list of static targets. However, ReportIscsiTargets does not report the target, unless it was also
	/// discovered dynamically by the iSCSI initiator, the Internet Storage Name Service (iSNS), or a SendTargets request.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_TARGET_FLAG_MERGE_TARGET_INFORMATION</term>
	/// <term>
	/// The iSCSI initiator service merges the information (if any) that it already has for this static target with the information that
	/// the caller passes to AddIscsiStaticTarget. If this flag is not set, the iSCSI initiator service overwrites the stored
	/// information with the information that the caller passes in.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Persist">If <c>true</c>, the target information persists across restarts of the iSCSI initiator service.</param>
	/// <param name="Mappings">
	/// A pointer to a structure of type ISCSI_TARGET_MAPPING that contains a set of mappings that the initiator uses when assigning
	/// values for the bus, target, and LUN numbers to the iSCSI LUNs associated with the target. If Mappings is <c>null</c>, the
	/// initiator will select the bus, target, and LUN numbers.
	/// </param>
	/// <param name="LoginOptions">
	/// A pointer to a structure of type ISCSI_LOGIN_OPTIONS that contains the options that specify the default login parameters that an
	/// initiator uses to login to a target.
	/// </param>
	/// <param name="PortalGroup">
	/// A pointer to a structure of type ISCSI_TARGET_PORTAL_GROUP that indicates the group of portals that an initiator can use login
	/// to the target.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>
	/// This routine adds a target to the iSCSI initiator service's list of static targets. If the caller specifies a value of
	/// <c>true</c> in Persist, the target is stored in the registry and information about the target persists across restarts of the
	/// initiator service and reboots of the operating system.
	/// </para>
	/// <para>
	/// By setting the <c>ISCSI_TARGET_FLAG_HIDE_STATIC_TARGET</c> flag, callers can configure default login information for a target
	/// prior to its discovery by an iSCSI initiator, the iSNS service, or a SendTargets request.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines AddIScsiStaticTarget as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-addiscsistatictargeta ISDSC_STATUS ISDSC_API
	// AddIScsiStaticTargetA( StrPtrAnsi TargetName, StrPtrAnsi TargetAlias, ISCSI_TARGET_FLAGS TargetFlags, BOOLEAN Persist, PISCSI_TARGET_MAPPINGA
	// Mappings, PISCSI_LOGIN_OPTIONS LoginOptions, PISCSI_TARGET_PORTAL_GROUPA PortalGroup );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.AddIScsiStaticTargetA")]
	public static extern Win32Error AddIScsiStaticTarget([MarshalAs(UnmanagedType.LPTStr)] string TargetName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? TargetAlias, ISCSI_TARGET_FLAGS TargetFlags, [MarshalAs(UnmanagedType.U1)] bool Persist,
		in ISCSI_TARGET_MAPPING Mappings, in ISCSI_LOGIN_OPTIONS LoginOptions, in ISCSI_TARGET_PORTAL_GROUP PortalGroup);

	/// <summary>The <c>AddIscsiStaticTarget</c> function adds a target to the list of static targets available to the iSCSI initiator.</summary>
	/// <param name="TargetName">The name of the target to add to the static target list.</param>
	/// <param name="TargetAlias">An alias associated with the TargetName.</param>
	/// <param name="TargetFlags">
	/// <para>A bitmap of flags that affect how, and under what circumstances, a target is discovered and enumerated.</para>
	/// <para>The following table lists the flags that can be associated with a target and the meaning of each flag.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ISCSI_TARGET_FLAG_HIDE_STATIC_TARGET</term>
	/// <term>
	/// The target is added to the list of static targets. However, ReportIscsiTargets does not report the target, unless it was also
	/// discovered dynamically by the iSCSI initiator, the Internet Storage Name Service (iSNS), or a SendTargets request.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_TARGET_FLAG_MERGE_TARGET_INFORMATION</term>
	/// <term>
	/// The iSCSI initiator service merges the information (if any) that it already has for this static target with the information that
	/// the caller passes to AddIscsiStaticTarget. If this flag is not set, the iSCSI initiator service overwrites the stored
	/// information with the information that the caller passes in.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Persist">If <c>true</c>, the target information persists across restarts of the iSCSI initiator service.</param>
	/// <param name="Mappings">
	/// A pointer to a structure of type ISCSI_TARGET_MAPPING that contains a set of mappings that the initiator uses when assigning
	/// values for the bus, target, and LUN numbers to the iSCSI LUNs associated with the target. If Mappings is <c>null</c>, the
	/// initiator will select the bus, target, and LUN numbers.
	/// </param>
	/// <param name="LoginOptions">
	/// A pointer to a structure of type ISCSI_LOGIN_OPTIONS that contains the options that specify the default login parameters that an
	/// initiator uses to login to a target.
	/// </param>
	/// <param name="PortalGroup">
	/// A pointer to a structure of type ISCSI_TARGET_PORTAL_GROUP that indicates the group of portals that an initiator can use login
	/// to the target.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>
	/// This routine adds a target to the iSCSI initiator service's list of static targets. If the caller specifies a value of
	/// <c>true</c> in Persist, the target is stored in the registry and information about the target persists across restarts of the
	/// initiator service and reboots of the operating system.
	/// </para>
	/// <para>
	/// By setting the <c>ISCSI_TARGET_FLAG_HIDE_STATIC_TARGET</c> flag, callers can configure default login information for a target
	/// prior to its discovery by an iSCSI initiator, the iSNS service, or a SendTargets request.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines AddIScsiStaticTarget as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-addiscsistatictargeta ISDSC_STATUS ISDSC_API
	// AddIScsiStaticTargetA( StrPtrAnsi TargetName, StrPtrAnsi TargetAlias, ISCSI_TARGET_FLAGS TargetFlags, BOOLEAN Persist, PISCSI_TARGET_MAPPINGA
	// Mappings, PISCSI_LOGIN_OPTIONS LoginOptions, PISCSI_TARGET_PORTAL_GROUPA PortalGroup );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.AddIScsiStaticTargetA")]
	public static extern Win32Error AddIScsiStaticTarget([MarshalAs(UnmanagedType.LPTStr)] string TargetName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? TargetAlias, ISCSI_TARGET_FLAGS TargetFlags, [MarshalAs(UnmanagedType.U1)] bool Persist,
		[In, Optional] IntPtr Mappings, [In, Optional] IntPtr LoginOptions, [In, Optional] IntPtr PortalGroup);

	/// <summary>
	/// The <c>AddIsnsServer</c> function adds a new server to the list of Internet Storage Name Service (iSNS) servers that the iSCSI
	/// initiator service uses to discover targets.
	/// </summary>
	/// <param name="Address">IP address or the DNS name of the server.</param>
	/// <returns>
	/// Returns ERROR_SUCCESS if the operation succeeds. If the operation fails, because of a problem with a socket connection,
	/// <c>AddIsnsServer</c> returns a Winsock error code. If the Address parameter does not point to a valid iSNS server name, the
	/// <c>AddIsnsServer</c> routine returns ERROR_INVALID_PARAMETER.
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the iSCSI initiator service receives a request from the <c>AddIsnsServer</c> user-mode library function to add an iSNS
	/// server, the initiator service saves relevant data about the iSNS server in non-volatile storage. The iSCSI initiator service
	/// queries the newly added server for discovered targets immediately after adding it. From that point forward, the iSCSI initiator
	/// service automatically queries the iSNS server whenever the initiator service refreshes the target list of the iSNS server. The
	/// initiator service also refreshes the target list of the iSNS server at startup or whenever the iSNS server indicates a change.
	/// </para>
	/// <para>
	/// If management software does not call <c>AddIsnsServer</c> to manually add the new iSNS servers to the service list of the iSCSI
	/// initiator service, the initiator service must rely on automatic discovery mechanisms, such as DHCP, to add new iSNS servers to
	/// the list.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines AddISNSServer as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-addisnsserverw ISDSC_STATUS ISDSC_API AddISNSServerW(
	// StrPtrUni Address );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.AddISNSServerW")]
	public static extern Win32Error AddISNSServer([MarshalAs(UnmanagedType.LPTStr)] string Address);

	/// <summary>
	/// The <c>AddPersistentIscsiDevice</c> function adds a volume device name, drive letter, or mount point symbolic link to the list
	/// of iSCSI persistently bound volumes and devices.
	/// </summary>
	/// <param name="DevicePath">A drive letter or symbolic link for a mount point of the volume.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns one of the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ISDSC_DEVICE_NOT_ISCSI_OR_PERSISTENT</term>
	/// <term>The volume or device is not located on a iSCSI target or the session to the iSCSI target is not persistent.</term>
	/// </item>
	/// <item>
	/// <term>ISDSC_VOLUME_ALREADY_PERSISTENTLY_BOUND</term>
	/// <term>The volume or device is already in the persistent volume or device list.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines AddPersistentIScsiDevice as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-addpersistentiscsidevicea ISDSC_STATUS ISDSC_API
	// AddPersistentIScsiDeviceA( StrPtrAnsi DevicePath );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.AddPersistentIScsiDeviceA")]
	public static extern Win32Error AddPersistentIScsiDevice([MarshalAs(UnmanagedType.LPTStr)] string DevicePath);

	/// <summary>
	/// The <c>AddRadiusServer</c> function adds a new Remote Authentication Dial-In User Service (RADIUS) server to the list referenced
	/// by the iSCSI initiator service during authentication.
	/// </summary>
	/// <param name="Address">A string that represents the IP address or DNS name associated with the RADIUS server.</param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation is successful. If the operation fails due to a socket connection error, this function
	/// will return a Winsock error code. Other possible error values include:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The supplied Address is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the iSCSI initiator service receives a request from the <c>AddRadiusServer</c> user-mode library function to add a RADIUS
	/// server, the initiator service saves data associated with the server in non-volatile storage. This allows the iSCSI initiator
	/// service to utilize the RADIUS server to authenticate targets or obtain authentication information.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines AddRadiusServer as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-addradiusserverw ISDSC_STATUS ISDSC_API AddRadiusServerW(
	// StrPtrUni Address );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.AddRadiusServerW")]
	public static extern Win32Error AddRadiusServer([MarshalAs(UnmanagedType.LPTStr)] string Address);

	/// <summary>
	/// The <c>ClearPersistentIscsiDevices</c> function removes all volumes and devices from the list of persistently bound iSCSI volumes.
	/// </summary>
	/// <returns>returns ERROR_SUCCESS if the operation succeeds and the appropriate Win32 or iSCSI error code if the operation fails.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-clearpersistentiscsidevices ISDSC_STATUS ISDSC_API ClearPersistentIScsiDevices();
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ClearPersistentIScsiDevices")]
	public static extern Win32Error ClearPersistentIScsiDevices();

	/// <summary>
	/// The <c>GetDevicesForIscsiSession</c> function retrieves information about the devices associated with the current session.
	/// </summary>
	/// <param name="UniqueSessionId">
	/// A pointer to a structure of type ISCSI_UNIQUE_SESSION_ID that contains the session identifier for the session.
	/// </param>
	/// <param name="DeviceCount">
	/// A pointer to a location that, on input, contains the number of elements of type ISCSI_DEVICE_ON_SESSION that can fit in the
	/// buffer that Devices points to. If the operation succeeds, the location receives the number of elements retrieved. If
	/// <c>GetDevicesForIscsiSession</c> returns ERROR_INSUFFICIENT_BUFFER, the location still receives the number of elements the
	/// buffer is capable of containing.
	/// </param>
	/// <param name="Devices">
	/// An array of ISCSI_DEVICE_ON_SESSION-type structures that, on output, receives information about each device associated with the session.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the caller allocated insufficient buffer space
	/// for the array in Devices.
	/// </para>
	/// <para>Otherwise, <c>GetDevicesForIscsiSession</c> returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines GetDevicesForIScsiSession as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-getdevicesforiscsisessiona ISDSC_STATUS ISDSC_API
	// GetDevicesForIScsiSessionA( PISCSI_UNIQUE_SESSION_ID UniqueSessionId, ULONG *DeviceCount, PISCSI_DEVICE_ON_SESSIONA Devices );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.GetDevicesForIScsiSessionA")]
	public static extern Win32Error GetDevicesForIScsiSession(in ISCSI_UNIQUE_SESSION_ID UniqueSessionId, ref uint DeviceCount,
		[Out, Optional, MarshalAs(UnmanagedType.LPArray)] ISCSI_DEVICE_ON_SESSION[]? Devices);

	/// <summary>
	/// The <c>GetIscsiIKEInfo</c> function retrieves the IPsec policy and any established pre-shared key values associated with an
	/// initiator Host-Bus Adapter (HBA).
	/// </summary>
	/// <param name="InitiatorName">A string that represents the name of the initiator HBA for which the IPsec policy is established.</param>
	/// <param name="InitiatorPortNumber">
	/// A <c>ULONG</c> value that represents the port on the initiator HBA with which to associate the key. If this parameter specifies
	/// a value of <c>ISCSI_ALL_INITIATOR_PORTS</c>, all ports on the initiator are associated with the key.
	/// </param>
	/// <param name="Reserved">This value is reserved.</param>
	/// <param name="AuthInfo">
	/// A pointer to an IKE_AUTHENTICATION_INFORMATION structure that contains data specifying the authentication method. Currently,
	/// only the <c>IKE_AUTHENTICATION_PRESHARED_KEY_METHOD</c> is supported.
	/// </param>
	/// <returns>
	/// Returns ERROR_SUCCESS if the operation is successful. If the operation fails due to a socket connection error, this function
	/// will return a Winsock error code.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines GetIScsiIKEInfo as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-getiscsiikeinfoa ISDSC_STATUS ISDSC_API GetIScsiIKEInfoA(
	// StrPtrAnsi InitiatorName, ULONG InitiatorPortNumber, PULONG Reserved, PIKE_AUTHENTICATION_INFORMATION AuthInfo );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.GetIScsiIKEInfoA")]
	public static extern Win32Error GetIScsiIKEInfo([Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorName,
		uint InitiatorPortNumber, [In, Optional] IntPtr Reserved, ref IKE_AUTHENTICATION_INFORMATION AuthInfo);

	/// <summary>
	/// The <c>GetIscsiInitiatorNodeName</c> function retrieves the common initiator node name that is used when establishing sessions
	/// from the local machine.
	/// </summary>
	/// <param name="InitiatorNodeName">
	/// A caller-allocated buffer that, on output, receives the node name. The buffer must be large enough to hold
	/// <c>MAX_ISCSI_NAME_LEN+1</c> bytes.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds and the appropriate Win32 or iSCSI error code if the operation fails.</returns>
	/// <remarks>
	/// <para>All initiator Host Bus Adapters, both software and hardware, use the same node name when establishing sessions.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines GetIScsiInitiatorNodeName as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-getiscsiinitiatornodenamea ISDSC_STATUS ISDSC_API
	// GetIScsiInitiatorNodeNameA( PCHAR InitiatorNodeName );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.GetIScsiInitiatorNodeNameA")]
	public static extern Win32Error GetIScsiInitiatorNodeName([MarshalAs(UnmanagedType.LPTStr)] StringBuilder InitiatorNodeName);

	/// <summary>The <c>GetIscsiSessionList</c> function retrieves the list of active iSCSI sessions.</summary>
	/// <param name="BufferSize">
	/// <para>
	/// A pointer to a location that, on input, contains the size, in bytes, of the caller-allocated buffer that SessionInfo points to.
	/// If the operation succeeds, the location receives the size, in bytes, of the session information data that was retrieved.
	/// </para>
	/// <para>
	/// If the operation fails because the output buffer size was insufficient, the location receives the size, in bytes, of the buffer
	/// size required to contain the output data.
	/// </para>
	/// </param>
	/// <param name="SessionCount">
	/// A pointer to a location that, on input, contains the number of ISCSI_SESSION_INFO structures that the buffer that SessionInfo
	/// points to can contain. If the operation succeeds, the location receives the number of <c>ISCSI_SESSION_INFO</c> structures that
	/// were retrieved.
	/// </param>
	/// <param name="SessionInfo">
	/// A pointer to a buffer that contains a series of contiguous structures of type ISCSI_SESSION_INFO that describe the active login sessions.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the size of the buffer at SessionInfo was
	/// insufficient to hold the output data.
	/// </para>
	/// <para>Otherwise, <c>GetIscsiSessionList</c> returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines GetIScsiSessionList as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-getiscsisessionlista ISDSC_STATUS ISDSC_API
	// GetIScsiSessionListA( ULONG *BufferSize, ULONG *SessionCount, PISCSI_SESSION_INFOA SessionInfo );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.GetIScsiSessionListA")]
	public static extern Win32Error GetIScsiSessionList(ref uint BufferSize, out uint SessionCount, [Out, Optional] IntPtr SessionInfo);

	/// <summary>The <c>GetIscsiSessionList</c> function retrieves the list of active iSCSI sessions.</summary>
	/// <param name="SessionInfo">
	/// A pointer to a buffer that contains a series of contiguous structures of type ISCSI_SESSION_INFO that describe the active login sessions.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the size of the buffer at <c>SessionInfo</c> was
	/// insufficient to hold the output data.
	/// </para>
	/// <para>Otherwise, <c>GetIscsiSessionList</c> returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines GetIScsiSessionList as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-getiscsisessionlista
	// ISDSC_STATUS ISDSC_API GetIScsiSessionListA( [in, out] ULONG *BufferSize, [out] ULONG *SessionCount, [out] PISCSI_SESSION_INFOA SessionInfo );
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.GetIScsiSessionListA")]
	public static Win32Error GetIScsiSessionList(out ISCSI_SESSION_INFO_MGD[]? SessionInfo)
	{
		SessionInfo = null;
		uint sz = 0;
		var ret = GetIScsiSessionList(ref sz, out _);
		if (ret != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			return ret;
		using var mem = new SafeHGlobalHandle((int)sz);
		ret = GetIScsiSessionList(ref sz, out var cnt, mem);
		if (ret.Succeeded)
			SessionInfo = Array.ConvertAll(mem.ToArray<ISCSI_SESSION_INFO>((int)cnt), a => (ISCSI_SESSION_INFO_MGD)a);
		return ret;
	}

	/// <summary>The <c>GetIscsiTargetInformation</c> function retrieves information about the specified target.</summary>
	/// <param name="TargetName">The name of the target for which information is retrieved.</param>
	/// <param name="DiscoveryMechanism">
	/// A text description of the mechanism that was used to discover the target (for example, "iSNS:", "SendTargets:" or "HBA:"). A
	/// value of <c>null</c> indicates that no discovery mechanism is specified.
	/// </param>
	/// <param name="InfoClass">A value of type TARGET_INFORMATION_CLASS that indicates the type of information to retrieve.</param>
	/// <param name="BufferSize">
	/// A pointer to a location that, on input, contains the size (in bytes) of the buffer that Buffer points to. If the operation
	/// succeeds, the location receives the number of bytes retrieved. If the operation fails, the location receives the size of the
	/// buffer required to contain the output data.
	/// </param>
	/// <param name="Buffer">
	/// The buffer that contains the output data. The output data consists in <c>null</c>-terminated strings, with a double <c>null</c>
	/// termination after the last string.
	/// </param>
	/// <returns>
	/// Returns ERROR_SUCCESS if successful and ERROR_INSUFFICIENT_BUFFER if the buffer size at Buffer was insufficient to contain the
	/// output data. Otherwise, <c>GetIscsiTargetInformation</c> returns the appropriate Win32 or iSCSI error code on failure.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The iSCSI initiator service can acquire information about a single target through multiple discovery mechanisms and initiators,
	/// and the information can be different in each case, so the iSCSI initiator service maintains a list of target instances which are
	/// organized according to the discovery method.
	/// </para>
	/// <para>
	/// For instance, if a single target is discovered by multiple initiators, each of which uses a different target portal group to
	/// discover the target, the iSCSI initiator will create multiple target instances for the target, each of which refers to a
	/// different target portal group.
	/// </para>
	/// <para>
	/// Since the information associated with a target is relative to the way in which it was discovered, the caller must specify the
	/// discovery mechanism in the DiscoveryMechanism parameter, using a correctly formatted string identifier for the discovery
	/// mechanism. The caller can retrieve a list of valid identifiers for discovery mechanisms by setting the InfoClass parameter to <c>null</c>.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines GetIScsiTargetInformation as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-getiscsitargetinformationa ISDSC_STATUS ISDSC_API
	// GetIScsiTargetInformationA( StrPtrAnsi TargetName, StrPtrAnsi DiscoveryMechanism, TARGET_INFORMATION_CLASS InfoClass, PULONG BufferSize,
	// PVOID Buffer );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.GetIScsiTargetInformationA")]
	public static extern Win32Error GetIScsiTargetInformation([MarshalAs(UnmanagedType.LPTStr)] string TargetName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? DiscoveryMechanism, TARGET_INFORMATION_CLASS InfoClass, ref uint BufferSize, [Out] IntPtr Buffer);

	/// <summary>The <c>GetIscsiTargetInformation</c> function retrieves information about the specified target.</summary>
	/// <param name="TargetName">The name of the target for which information is retrieved.</param>
	/// <param name="DiscoveryMechanism">
	/// A text description of the mechanism that was used to discover the target (for example, "iSNS:", "SendTargets:" or "HBA:"). A
	/// value of <c>null</c> indicates that no discovery mechanism is specified.
	/// </param>
	/// <param name="InfoClass">A value of type TARGET_INFORMATION_CLASS that indicates the type of information to retrieve.</param>
	/// <returns>The output data.</returns>
	/// <remarks>
	/// <para>
	/// The iSCSI initiator service can acquire information about a single target through multiple discovery mechanisms and initiators,
	/// and the information can be different in each case, so the iSCSI initiator service maintains a list of target instances which are
	/// organized according to the discovery method.
	/// </para>
	/// <para>
	/// For instance, if a single target is discovered by multiple initiators, each of which uses a different target portal group to
	/// discover the target, the iSCSI initiator will create multiple target instances for the target, each of which refers to a
	/// different target portal group.
	/// </para>
	/// <para>
	/// Since the information associated with a target is relative to the way in which it was discovered, the caller must specify the
	/// discovery mechanism in the DiscoveryMechanism parameter, using a correctly formatted string identifier for the discovery
	/// mechanism. The caller can retrieve a list of valid identifiers for discovery mechanisms by setting the InfoClass parameter to <c>0</c>.
	/// </para>
	/// </remarks>
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.GetIScsiTargetInformationA")]
	public static T? GetIScsiTargetInformation<T>(string TargetName, TARGET_INFORMATION_CLASS InfoClass, [Optional] string? DiscoveryMechanism)
	{
		if (!CorrespondingTypeAttribute.CanGet(InfoClass, typeof(T)))
			throw new ArgumentException("Invalid return type for specified InfoClass.");
		var sz = 0U;
		var err = GetIScsiTargetInformation(TargetName, DiscoveryMechanism, InfoClass, ref sz, IntPtr.Zero);
		if (err == Win32Error.ERROR_INSUFFICIENT_BUFFER)
		{
			using var mem = new SafeCoTaskMemHandle(sz);
			GetIScsiTargetInformation(TargetName, DiscoveryMechanism, InfoClass, ref sz, IntPtr.Zero).ThrowIfFailed();
			if (typeof(IEnumerable<string>).IsAssignableFrom(typeof(T)))
				return (T)(object)mem.ToStringEnum().ToArray();
			else
				return mem.ToType<T>();
		}
		err.ThrowIfFailed();
		return default;
	}

	/// <summary>The <c>GetIscsiVersionInformation</c> function retrieves information about the initiator version.</summary>
	/// <param name="VersionInfo">Pointer to an ISCSI_VERSION_INFO structure that contains initiator version information.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if the operation is successful. If the operation fails due to a socket connection error, this
	/// function will return a Winsock error code.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-getiscsiversioninformation ISDSC_STATUS ISDSC_API
	// GetIScsiVersionInformation( PISCSI_VERSION_INFO VersionInfo );
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.GetIScsiVersionInformation")]
	public static extern Win32Error GetIScsiVersionInformation(out ISCSI_VERSION_INFO VersionInfo);

	/// <summary>The <c>LoginIscsiTarget</c> function establishes a full featured login session with the indicated target.</summary>
	/// <param name="TargetName">
	/// The name of the target with which to establish a login session. The target must already exist in the list of discovered targets
	/// for the iSCSI initiator service.
	/// </param>
	/// <param name="IsInformationalSession">
	/// <para>
	/// If <c>true</c>, the <c>LoginIscsiTarget</c> function establishes a login session, but the operation does not report the LUNs on
	/// the target to the "Plug and Play" Manager. If the login succeeds, management applications will be able to query the target for
	/// information with the SendScsiReportLuns and SendScsiReadCapacity functions, but the storage stack will not enumerate the target
	/// or load a driver for it.
	/// </para>
	/// <para>
	/// If IsInformationalSession is <c>false</c>, <c>LoginIscsiTarget</c> reports the LUNs associated with the target to the "Plug and
	/// Play" Manager, and the system loads drivers for the LUNs.
	/// </para>
	/// </param>
	/// <param name="InitiatorInstance">
	/// The name of the initiator that logs in to the target. If InitiatorName is <c>null</c>, the iSCSI initiator service selects an initiator.
	/// </param>
	/// <param name="InitiatorPortNumber">
	/// <para>
	/// The port number of the Host Bus Adapter (HBA) that initiates the login session. If this parameter is
	/// <c>ISCSI_ANY_INITIATOR_PORT</c>, the caller did not specify a port for the initiator HBA to use when logging in to the target.
	/// </para>
	/// <para>If InitiatorName is <c>null</c>, InitiatorPortNumber must be <c>ISCSI_ANY_INITIATOR_PORT</c>.</para>
	/// </param>
	/// <param name="TargetPortal">
	/// Pointer to a structure of type ISCSI_TARGET_PORTAL that indicates the portal that the initiator uses to open the session. The
	/// specified portal must belong to a portal group that is associated with the TargetName. If TargetPortal is <c>null</c>, the iSCSI
	/// initiator service instructs the initiator to use any portal through which the target is accessible to the initiator. If the
	/// caller specifies the value for TargetPortal, the iSCSI initiator service will not verify that the TargetPortal is accessible to
	/// the initiator HBA.
	/// </param>
	/// <param name="SecurityFlags">
	/// <para>
	/// A bitmap that specifies the characteristics of the IPsec connection that the initiator adds to the session. If an IPsec security
	/// policy between the initiator and the target portal is already configured as a result of the current portal group policy or a
	/// previous connection to the target, the existing configuration takes precedence over the configuration specified in SecurityFlags.
	/// </para>
	/// <para>
	/// If the ISCSI_SECURITY_FLAG_VALID flag is set to 0, the iSCSI initiator service uses default values for the security flags that
	/// are defined in the registry.
	/// </para>
	/// <para>Caller can set any of the following flags in the bitmap:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec tunnel mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec transport mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_PFS_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with Perfect Forward Secrecy (PFS) mode enabled; otherwise, the
	/// initiator should make the connection with PFS mode disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with aggressive mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with main mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with the IKE/IPsec protocol enabled; otherwise, the IKE/IPsec protocol
	/// is disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_VALID</term>
	/// <term>
	/// When set to 1, the other mask values are valid; otherwise, the iSCSI initiator service will use bitmap values that were
	/// previously defined for the target portal, or if none are available, the initiator service uses the default values defined in the registry.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Mappings">
	/// An array of structures of type ISCSI_TARGET_MAPPING, each of which holds information that the initiator uses to assign bus,
	/// target and LUN numbers to the devices that are associated with the target. If Mappings is <c>null</c>, the initiator will select
	/// the bus, target and LUN numbers.
	/// </param>
	/// <param name="LoginOptions">
	/// A pointer to a structure of type ISCSI_LOGIN_OPTIONS that contains the options that specify the characteristics of the login session.
	/// </param>
	/// <param name="KeySize">The size, in bytes, of the target's preshared key specified by the Key parameter.</param>
	/// <param name="Key">
	/// <para>A preshared key to use when logging in to the target portal that exposes this target.</para>
	/// <para><c>Note</c> If an IPsec policy is already associated with the target portal, the IPsec settings in this call are ignored.</para>
	/// </param>
	/// <param name="IsPersistent">
	/// <para>
	/// If <c>true</c>, the initiator should save the characteristics of the login session in non-volatile storage, so that the
	/// information persists across restarts of the initiator device and reboots of the operating system. The initiator should not
	/// establish the login session until after saving the persistent data.
	/// </para>
	/// <para>
	/// Whenever the initiator device restarts, it should automatically attempt to re-establish the login session with the same
	/// characteristics. If <c>false</c>, the initiator device simply logs in to the target without saving the characteristics of the
	/// login session.
	/// </para>
	/// </param>
	/// <param name="UniqueSessionId">
	/// A pointer to a structure of type ISCSI_UNIQUE_SESSION_ID that, on return, contains a unique session identifier for the login session.
	/// </param>
	/// <param name="UniqueConnectionId">
	/// A pointer to a structure of type ISCSI_UNIQUE_CONNECTION_ID that, on return, contains a unique connection identifier for the
	/// login session.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>
	/// The <c>LoginIscsiTarget</c> function either establishes a single login session with a target, or creates a persistent login to a
	/// target. If <c>LoginIscsiTarget</c> creates a persistent login, the specified initiator should log in to the target each time the
	/// initiator is started, typically at system boot. Callers to <c>LoginIscsiTarget</c> can request the creation of a persistent
	/// login by setting the IsPersistent parameter to <c>true</c>.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines LoginIScsiTarget as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-loginiscsitargeta ISDSC_STATUS ISDSC_API
	// LoginIScsiTargetA( StrPtrAnsi TargetName, BOOLEAN IsInformationalSession, StrPtrAnsi InitiatorInstance, ULONG InitiatorPortNumber,
	// PISCSI_TARGET_PORTALA TargetPortal, ISCSI_SECURITY_FLAGS SecurityFlags, PISCSI_TARGET_MAPPINGA Mappings, PISCSI_LOGIN_OPTIONS
	// LoginOptions, ULONG KeySize, PCHAR Key, BOOLEAN IsPersistent, PISCSI_UNIQUE_SESSION_ID UniqueSessionId,
	// PISCSI_UNIQUE_CONNECTION_ID UniqueConnectionId );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.LoginIScsiTargetA")]
	public static extern Win32Error LoginIScsiTarget([MarshalAs(UnmanagedType.LPTStr)] string TargetName, [MarshalAs(UnmanagedType.U1)] bool IsInformationalSession,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance, [Optional] uint InitiatorPortNumber, in ISCSI_TARGET_PORTAL TargetPortal,
		[Optional] ISCSI_SECURITY_FLAGS SecurityFlags, in ISCSI_TARGET_MAPPING Mappings, in ISCSI_LOGIN_OPTIONS LoginOptions, [Optional] uint KeySize,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? Key, [MarshalAs(UnmanagedType.U1)] bool IsPersistent, out ISCSI_UNIQUE_SESSION_ID UniqueSessionId,
		out ISCSI_UNIQUE_SESSION_ID UniqueConnectionId);

	/// <summary>The <c>LoginIscsiTarget</c> function establishes a full featured login session with the indicated target.</summary>
	/// <param name="TargetName">
	/// The name of the target with which to establish a login session. The target must already exist in the list of discovered targets
	/// for the iSCSI initiator service.
	/// </param>
	/// <param name="IsInformationalSession">
	/// <para>
	/// If <c>true</c>, the <c>LoginIscsiTarget</c> function establishes a login session, but the operation does not report the LUNs on
	/// the target to the "Plug and Play" Manager. If the login succeeds, management applications will be able to query the target for
	/// information with the SendScsiReportLuns and SendScsiReadCapacity functions, but the storage stack will not enumerate the target
	/// or load a driver for it.
	/// </para>
	/// <para>
	/// If IsInformationalSession is <c>false</c>, <c>LoginIscsiTarget</c> reports the LUNs associated with the target to the "Plug and
	/// Play" Manager, and the system loads drivers for the LUNs.
	/// </para>
	/// </param>
	/// <param name="InitiatorInstance">
	/// The name of the initiator that logs in to the target. If InitiatorName is <c>null</c>, the iSCSI initiator service selects an initiator.
	/// </param>
	/// <param name="InitiatorPortNumber">
	/// <para>
	/// The port number of the Host Bus Adapter (HBA) that initiates the login session. If this parameter is
	/// <c>ISCSI_ANY_INITIATOR_PORT</c>, the caller did not specify a port for the initiator HBA to use when logging in to the target.
	/// </para>
	/// <para>If InitiatorName is <c>null</c>, InitiatorPortNumber must be <c>ISCSI_ANY_INITIATOR_PORT</c>.</para>
	/// </param>
	/// <param name="TargetPortal">
	/// Pointer to a structure of type ISCSI_TARGET_PORTAL that indicates the portal that the initiator uses to open the session. The
	/// specified portal must belong to a portal group that is associated with the TargetName. If TargetPortal is <c>null</c>, the iSCSI
	/// initiator service instructs the initiator to use any portal through which the target is accessible to the initiator. If the
	/// caller specifies the value for TargetPortal, the iSCSI initiator service will not verify that the TargetPortal is accessible to
	/// the initiator HBA.
	/// </param>
	/// <param name="SecurityFlags">
	/// <para>
	/// A bitmap that specifies the characteristics of the IPsec connection that the initiator adds to the session. If an IPsec security
	/// policy between the initiator and the target portal is already configured as a result of the current portal group policy or a
	/// previous connection to the target, the existing configuration takes precedence over the configuration specified in SecurityFlags.
	/// </para>
	/// <para>
	/// If the ISCSI_SECURITY_FLAG_VALID flag is set to 0, the iSCSI initiator service uses default values for the security flags that
	/// are defined in the registry.
	/// </para>
	/// <para>Caller can set any of the following flags in the bitmap:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec tunnel mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection in IPsec transport mode. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_PFS_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with Perfect Forward Secrecy (PFS) mode enabled; otherwise, the
	/// initiator should make the connection with PFS mode disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with aggressive mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with main mode enabled. Caller should set this flag or the
	/// ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED flag, but not both.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED</term>
	/// <term>
	/// When set to 1, the initiator should make the connection with the IKE/IPsec protocol enabled; otherwise, the IKE/IPsec protocol
	/// is disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ISCSI_SECURITY_FLAG_VALID</term>
	/// <term>
	/// When set to 1, the other mask values are valid; otherwise, the iSCSI initiator service will use bitmap values that were
	/// previously defined for the target portal, or if none are available, the initiator service uses the default values defined in the registry.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Mappings">
	/// An array of structures of type ISCSI_TARGET_MAPPING, each of which holds information that the initiator uses to assign bus,
	/// target and LUN numbers to the devices that are associated with the target. If Mappings is <c>null</c>, the initiator will select
	/// the bus, target and LUN numbers.
	/// </param>
	/// <param name="LoginOptions">
	/// A pointer to a structure of type ISCSI_LOGIN_OPTIONS that contains the options that specify the characteristics of the login session.
	/// </param>
	/// <param name="KeySize">The size, in bytes, of the target's preshared key specified by the Key parameter.</param>
	/// <param name="Key">
	/// <para>A preshared key to use when logging in to the target portal that exposes this target.</para>
	/// <para><c>Note</c> If an IPsec policy is already associated with the target portal, the IPsec settings in this call are ignored.</para>
	/// </param>
	/// <param name="IsPersistent">
	/// <para>
	/// If <c>true</c>, the initiator should save the characteristics of the login session in non-volatile storage, so that the
	/// information persists across restarts of the initiator device and reboots of the operating system. The initiator should not
	/// establish the login session until after saving the persistent data.
	/// </para>
	/// <para>
	/// Whenever the initiator device restarts, it should automatically attempt to re-establish the login session with the same
	/// characteristics. If <c>false</c>, the initiator device simply logs in to the target without saving the characteristics of the
	/// login session.
	/// </para>
	/// </param>
	/// <param name="UniqueSessionId">
	/// A pointer to a structure of type ISCSI_UNIQUE_SESSION_ID that, on return, contains a unique session identifier for the login session.
	/// </param>
	/// <param name="UniqueConnectionId">
	/// A pointer to a structure of type ISCSI_UNIQUE_CONNECTION_ID that, on return, contains a unique connection identifier for the
	/// login session.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>
	/// The <c>LoginIscsiTarget</c> function either establishes a single login session with a target, or creates a persistent login to a
	/// target. If <c>LoginIscsiTarget</c> creates a persistent login, the specified initiator should log in to the target each time the
	/// initiator is started, typically at system boot. Callers to <c>LoginIscsiTarget</c> can request the creation of a persistent
	/// login by setting the IsPersistent parameter to <c>true</c>.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines LoginIScsiTarget as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-loginiscsitargeta ISDSC_STATUS ISDSC_API
	// LoginIScsiTargetA( StrPtrAnsi TargetName, BOOLEAN IsInformationalSession, StrPtrAnsi InitiatorInstance, ULONG InitiatorPortNumber,
	// PISCSI_TARGET_PORTALA TargetPortal, ISCSI_SECURITY_FLAGS SecurityFlags, PISCSI_TARGET_MAPPINGA Mappings, PISCSI_LOGIN_OPTIONS
	// LoginOptions, ULONG KeySize, PCHAR Key, BOOLEAN IsPersistent, PISCSI_UNIQUE_SESSION_ID UniqueSessionId,
	// PISCSI_UNIQUE_CONNECTION_ID UniqueConnectionId );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.LoginIScsiTargetA")]
	public static extern Win32Error LoginIScsiTarget([MarshalAs(UnmanagedType.LPTStr)] string TargetName, [MarshalAs(UnmanagedType.U1)] bool IsInformationalSession,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance, [Optional] uint InitiatorPortNumber, [In, Optional] IntPtr TargetPortal,
		[Optional] ISCSI_SECURITY_FLAGS SecurityFlags, [In, Optional] IntPtr Mappings, [In, Optional] IntPtr LoginOptions,
		[Optional] uint KeySize, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Key, [MarshalAs(UnmanagedType.U1)] bool IsPersistent,
		out ISCSI_UNIQUE_SESSION_ID UniqueSessionId, out ISCSI_UNIQUE_SESSION_ID UniqueConnectionId);

	/// <summary>The <c>LogoutIscsiTarget</c> routine closes the specified login session.</summary>
	/// <param name="UniqueSessionId">
	/// A pointer to a structure of type ISCSI_UNIQUE_SESSION_ID that contains a unique session identifier for the login session end.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// If the login session is not for informational purposes, the iSCSI initiator service ensures that all devices associated with the
	/// session can be safely removed from the device stack before allowing the initiator to close the session. If the session is an
	/// informational session, the iSCSI initiator service closes the session immediately.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-logoutiscsitarget ISDSC_STATUS ISDSC_API
	// LogoutIScsiTarget( PISCSI_UNIQUE_SESSION_ID UniqueSessionId );
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.LogoutIScsiTarget")]
	public static extern Win32Error LogoutIScsiTarget(in ISCSI_UNIQUE_SESSION_ID UniqueSessionId);

	/// <summary>
	/// The <c>RefreshIscsiSendTargetPortal</c> function instructs the iSCSI initiator service to establish a discovery session with the
	/// indicated target portal and transmit a <c>SendTargets</c> request to refresh the list of discovered targets for the iSCSI
	/// initiator service.
	/// </summary>
	/// <param name="InitiatorInstance">
	/// The name of the Host Bus Adapter (HBA) to use for the <c>SendTargets</c> request. If <c>null</c>, the iSCSI initiator service
	/// uses any HBA that can reach the indicated target portal is chosen.
	/// </param>
	/// <param name="InitiatorPortNumber">
	/// The port number on the HBA to use for the <c>SendTargets</c> request. If the value is <c>ISCSI_ALL_INITIATOR_PORTS</c>, the
	/// initiator HBA will choose the appropriate port based upon current routing information.
	/// </param>
	/// <param name="Portal">
	/// A pointer to a structure of type ISCSI_TARGET_PORTAL indicating the portal to which the iSCSI initiator service sends the
	/// <c>SendTargets</c> request to refresh the list of targets.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines RefreshIScsiSendTargetPortal as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-refreshiscsisendtargetportala ISDSC_STATUS ISDSC_API
	// RefreshIScsiSendTargetPortalA( StrPtrAnsi InitiatorInstance, ULONG InitiatorPortNumber, PISCSI_TARGET_PORTALA Portal );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RefreshIScsiSendTargetPortalA")]
	public static extern Win32Error RefreshIScsiSendTargetPortal([Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance,
		[Optional] uint InitiatorPortNumber, in ISCSI_TARGET_PORTAL Portal);

	/// <summary>
	/// The <c>RefreshIsnsServer</c> function instructs the iSCSI initiator service to query the indicated Internet Storage Name Service
	/// (iSNS) server to refresh the list of discovered targets for the iSCSI initiator service.
	/// </summary>
	/// <param name="Address">The DNS or IP Address of the iSNS server.</param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>
	/// If the refresh succeeds, the iSCSI initiator service replaces the previous list of targets discovered by the indicated iSNS
	/// server with the updated list.
	/// </para>
	/// <para>
	/// If the iSNS server supports State Change Notifications (SCN), the iSCSI initiator can keep the iSNS target list up to date,
	/// without requiring calls of the <c>RefreshIsnsServer</c> function.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines RefreshISNSServer as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-refreshisnsservera ISDSC_STATUS ISDSC_API
	// RefreshISNSServerA( StrPtrAnsi Address );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RefreshISNSServerA")]
	public static extern Win32Error RefreshISNSServer([MarshalAs(UnmanagedType.LPTStr)] string? Address);

	/// <summary>The <c>RemoveIscsiConnection</c> function removes a connection from an active session.</summary>
	/// <param name="UniqueSessionId">
	/// A pointer to a structure of type ISCSI_UNIQUE_SESSION_ID that specifies the unique session identifier of the session that the
	/// connection belongs to.
	/// </param>
	/// <param name="ConnectionId">A pointer to a structure of type ISCSI_UNIQUE_CONNECTION_ID that specifies the connection to remove.</param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// The <c>RemoveIscsiConnection</c> function will not remove the last connection of a session or the leading connection of a
	/// session. The caller must close the session by calling LogoutIscsiTarget to remove the last connection.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-removeiscsiconnection ISDSC_STATUS ISDSC_API
	// RemoveIScsiConnection( PISCSI_UNIQUE_SESSION_ID UniqueSessionId, PISCSI_UNIQUE_CONNECTION_ID ConnectionId );
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RemoveIScsiConnection")]
	public static extern Win32Error RemoveIScsiConnection(in ISCSI_UNIQUE_SESSION_ID UniqueSessionId, in ISCSI_UNIQUE_SESSION_ID ConnectionId);

	/// <summary>
	/// The <c>RemoveIscsiPersistentTarget</c> function removes a persistent login for the specified hardware initiator Host Bus Adapter
	/// (HBA), initiator port, and target portal.
	/// </summary>
	/// <param name="InitiatorInstance">The name of the initiator that maintains the persistent login to remove.</param>
	/// <param name="InitiatorPortNumber">
	/// The port number on which the initiator connects to TargetName. If InitiatorPortNumber is <c>ISCSI_ALL_INITIATOR_PORTS</c> the
	/// miniport driver for the initiator HBA removes the TargetName from the persistent login lists for all initiator ports.
	/// </param>
	/// <param name="TargetName">The name of the target.</param>
	/// <param name="Portal">
	/// The portal through which the initiator connects to the target. If Portal is <c>null</c> or contains no information, the miniport
	/// driver for the initiator HBA removes persistent logins for the target on all portals.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines RemoveIScsiPersistentTarget as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-removeiscsipersistenttargeta ISDSC_STATUS ISDSC_API
	// RemoveIScsiPersistentTargetA( StrPtrAnsi InitiatorInstance, ULONG InitiatorPortNumber, StrPtrAnsi TargetName, PISCSI_TARGET_PORTALA Portal );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RemoveIScsiPersistentTargetA")]
	public static extern Win32Error RemoveIScsiPersistentTarget([MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance, [Optional] uint InitiatorPortNumber,
		[MarshalAs(UnmanagedType.LPTStr)] string TargetName, in ISCSI_TARGET_PORTAL Portal);

	/// <summary>
	/// The <c>RemoveIscsiPersistentTarget</c> function removes a persistent login for the specified hardware initiator Host Bus Adapter
	/// (HBA), initiator port, and target portal.
	/// </summary>
	/// <param name="InitiatorInstance">The name of the initiator that maintains the persistent login to remove.</param>
	/// <param name="InitiatorPortNumber">
	/// The port number on which the initiator connects to TargetName. If InitiatorPortNumber is <c>ISCSI_ALL_INITIATOR_PORTS</c> the
	/// miniport driver for the initiator HBA removes the TargetName from the persistent login lists for all initiator ports.
	/// </param>
	/// <param name="TargetName">The name of the target.</param>
	/// <param name="Portal">
	/// The portal through which the initiator connects to the target. If Portal is <c>null</c> or contains no information, the miniport
	/// driver for the initiator HBA removes persistent logins for the target on all portals.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines RemoveIScsiPersistentTarget as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-removeiscsipersistenttargeta ISDSC_STATUS ISDSC_API
	// RemoveIScsiPersistentTargetA( StrPtrAnsi InitiatorInstance, ULONG InitiatorPortNumber, StrPtrAnsi TargetName, PISCSI_TARGET_PORTALA Portal );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RemoveIScsiPersistentTargetA")]
	public static extern Win32Error RemoveIScsiPersistentTarget([MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance, [Optional] uint InitiatorPortNumber,
		[MarshalAs(UnmanagedType.LPTStr)] string TargetName, [In, Optional] IntPtr Portal);

	/// <summary>
	/// The <c>RemoveIscsiSendTargetPortal</c> function removes a portal from the list of portals to which the iSCSI initiator service
	/// sends <c>SendTargets</c> requests for target discovery.
	/// </summary>
	/// <param name="InitiatorInstance">
	/// The name of the Host Bus Adapter (HBA) that the iSCSI initiator service uses to establish a discovery session and perform
	/// <c>SendTargets</c> requests. A value of <c>null</c> indicates that the iSCSI initiator service will use any HBA that is capable
	/// of accessing the target portal.
	/// </param>
	/// <param name="InitiatorPortNumber">
	/// The port number on the HBA that the iSCSI initiator service use to perform <c>SendTargets</c> requests.
	/// </param>
	/// <param name="Portal">
	/// A pointer to a structure of type ISCSI_TARGET_PORTAL that specifies the target portal that the iSCSI initiator service removes
	/// from its list of portals.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines RemoveIScsiSendTargetPortal as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-removeiscsisendtargetportala ISDSC_STATUS ISDSC_API
	// RemoveIScsiSendTargetPortalA( StrPtrAnsi InitiatorInstance, ULONG InitiatorPortNumber, PISCSI_TARGET_PORTALA Portal );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RemoveIScsiSendTargetPortalA")]
	public static extern Win32Error RemoveIScsiSendTargetPortal([Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorInstance,
		[Optional] uint InitiatorPortNumber, in ISCSI_TARGET_PORTAL Portal);

	/// <summary>
	/// The <c>RemoveIscsiStaticTarget</c> function removes a target from the list of static targets made available to the machine.
	/// </summary>
	/// <param name="TargetName">The name of the iSCSI target to remove from the static list.</param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines RemoveIScsiStaticTarget as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-removeiscsistatictargetw ISDSC_STATUS ISDSC_API
	// RemoveIScsiStaticTargetW( StrPtrUni TargetName );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RemoveIScsiStaticTargetW")]
	public static extern Win32Error RemoveIScsiStaticTarget([MarshalAs(UnmanagedType.LPTStr)] string TargetName);

	/// <summary>
	/// The <c>RemoveIsnsServer</c> function removes a server from the list of Internet Storage Name Service (iSNS) servers that the
	/// iSCSI initiator service uses to discover targets.
	/// </summary>
	/// <param name="Address">The DNS or IP Address of the server to remove.</param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>
	/// The <c>RemoveIsnsServer</c> function does not affect the list of discovered targets for the iSCSI initiator service. Targets
	/// previously discovered by the iSNS server that is being removed remain on the list of discovered targets. However, the iSNS
	/// server is also removed from the persistent list of iSNS servers.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines RemoveISNSServer as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-removeisnsservera ISDSC_STATUS ISDSC_API
	// RemoveISNSServerA( StrPtrAnsi Address );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RemoveISNSServerA")]
	public static extern Win32Error RemoveISNSServer([MarshalAs(UnmanagedType.LPTStr)] string Address);

	/// <summary>
	/// The <c>RemovePersistentIscsiDevice</c> function removes a device or volume from the list of persistently bound iSCSI volumes.
	/// </summary>
	/// <param name="DevicePath">A drive letter, mount point, or device path for the volume or device.</param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ISDSC_DEVICE_NOT_FOUND if the volume that is specified by VolumePath is not
	/// in the list of persistently bound volumes.
	/// </para>
	/// <para>Otherwise, <c>RemovePersistentIscsiDevice</c> returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines RemovePersistentIScsiDevice as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-removepersistentiscsidevicea ISDSC_STATUS ISDSC_API
	// RemovePersistentIScsiDeviceA( StrPtrAnsi DevicePath );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RemovePersistentIScsiDeviceA")]
	public static extern Win32Error RemovePersistentIScsiDevice([MarshalAs(UnmanagedType.LPTStr)] string DevicePath);

	/// <summary>
	/// The <c>RemoveRadiusServer</c> function removes a Remote Authentication Dial-In User Service (RADIUS) server entry from the
	/// RADIUS server list with which an iSCSI initiator is configured.
	/// </summary>
	/// <param name="Address">A string that represents the IP address or RADIUS server name.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if the operation is successful. If the operation fails due to a socket connection error, this
	/// function will return a Winsock error code.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines RemoveRadiusServer as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-removeradiusservera ISDSC_STATUS ISDSC_API
	// RemoveRadiusServerA( StrPtrAnsi Address );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.RemoveRadiusServerA")]
	public static extern Win32Error RemoveRadiusServer([MarshalAs(UnmanagedType.LPTStr)] string Address);

	/// <summary>
	/// <c>ReportActiveIscsiTargetMappings</c> function retrieves the target mappings that are currently active for all initiators on
	/// the computer.
	/// </summary>
	/// <param name="BufferSize">
	/// A pointer to a location that, on input, contains the size, in bytes, of the buffer that Mappings points to. If the operation
	/// succeeds, the location receives the size, in bytes, of the mapping data that was retrieved. If the buffer that Mappings points
	/// to is not sufficient to contain the output data, the location receives the buffer size, in bytes, that is required.
	/// </param>
	/// <param name="MappingCount">
	/// If the operation succeeds, the location pointed to by MappingCount receives the number of mappings that were retrieved.
	/// </param>
	/// <param name="Mappings">
	/// A pointer to an array of type ISCSI_TARGET_MAPPING that, on output, is filled with the active target mappings for all initiators.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the buffer is not large enough.</para>
	/// <para>Otherwise, <c>ReportActiveIscsiTargetMappings</c> returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>Target mappings associate bus, target and LUN numbers with the LUNs on a target device.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ReportActiveIScsiTargetMappings as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportactiveiscsitargetmappingsw ISDSC_STATUS ISDSC_API
	// ReportActiveIScsiTargetMappingsW( PULONG BufferSize, PULONG MappingCount, PISCSI_TARGET_MAPPINGW Mappings );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportActiveIScsiTargetMappingsW")]
	public static extern Win32Error ReportActiveIScsiTargetMappings(ref uint BufferSize, out uint MappingCount, [Out, Optional] IntPtr Mappings);

	/// <summary>
	/// The <c>ReportIscsiInitiatorList</c> function retrieves the list of initiator Host Bus Adapters that are running on the machine.
	/// </summary>
	/// <param name="BufferSize">
	/// A <c>ULONG</c> value that specifies the number of list elements contained by the Buffer parameter. If the operation succeeds,
	/// this location receives the size, represented by a number of elements, that corresponds to the retreived data.
	/// </param>
	/// <param name="Buffer">
	/// A buffer that, on output, is filled with the list of initiator names. Each initiator name is a <c>null</c>-terminated string,
	/// except for the last initiator name, which is double- <c>null</c> terminated.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the buffer size of Buffer is insufficient to
	/// contain the output data.
	/// </para>
	/// <para>Otherwise, <c>ReportIscsiInitiatorList</c> returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ReportIScsiInitiatorList as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportiscsiinitiatorlista ISDSC_STATUS ISDSC_API
	// ReportIScsiInitiatorListA( PULONG BufferSize, PCHAR Buffer );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportIScsiInitiatorListA")]
	public static extern Win32Error ReportIScsiInitiatorList(ref uint BufferSize, [Out, Optional] IntPtr Buffer);

	/// <summary>
	/// The <c>ReportIscsiInitiatorList</c> function retrieves the list of initiator Host Bus Adapters that are running on the machine.
	/// </summary>
	/// <returns>The list of initiator names.</returns>
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportIScsiInitiatorListA")]
	public static string[] ReportIScsiInitiatorList() => GetStringList(ReportIScsiInitiatorList);

	/// <summary>The <c>ReportIscsiPersistentLogins</c> function retrieves the list of persistent login targets.</summary>
	/// <param name="Count">A pointer to the location that receives a count of the elements specified by PersistentLoginInfo.</param>
	/// <param name="PersistentLoginInfo">
	/// An array of PERSISTENT_ISCSI_LOGIN_INFO structures that, on output, describe the persistent login targets.
	/// </param>
	/// <param name="BufferSizeInBytes">
	/// A pointer to a location that, on input, contains the byte-size of the buffer space that PersistentLoginInfo specifies. If the
	/// buffer size is insufficient, this parameter specifies what is required to contain the output data.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the buffer specified by PersistentLoginInfo is
	/// insufficient to contain the output data.
	/// </para>
	/// <para>Otherwise, <c>ReportIscsiPersistentLogins</c> returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The PERSISTENT_ISCSI_LOGIN_INFO structure provides an initiator with the information required to log in to a target each time
	/// the initiator device is started.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ReportIScsiPersistentLogins as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportiscsipersistentloginsa ISDSC_STATUS ISDSC_API
	// ReportIScsiPersistentLoginsA( ULONG *Count, PPERSISTENT_ISCSI_LOGIN_INFOA PersistentLoginInfo, PULONG BufferSizeInBytes );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportIScsiPersistentLoginsA")]
	public static extern Win32Error ReportIScsiPersistentLogins(out uint Count, [Out, Optional] IntPtr PersistentLoginInfo, ref uint BufferSizeInBytes);

	/// <summary>
	/// The <c>ReportIscsiSendTargetPortals</c> function retrieves a list of target portals that the iSCSI initiator service uses to
	/// perform automatic discovery with <c>SendTarget</c> requests.
	/// </summary>
	/// <param name="PortalCount">
	/// A pointer to a location that, on input, contains the number of entries in the PortalInfo array. On output, this parameter
	/// specifies the number of elements that contain return data.
	/// </param>
	/// <param name="PortalInfo">
	/// Pointer to an array of elements contained in ISCSI_TARGET_PORTAL_INFO structures that describe the portals that the iSCSI
	/// initiator service utilizes to perform discovery with <c>SendTargets</c> requests.
	/// </param>
	/// <returns>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the buffer size of Buffer is insufficient to
	/// contain the output data.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ReportIScsiSendTargetPortals as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportiscsisendtargetportalsa ISDSC_STATUS ISDSC_API
	// ReportIScsiSendTargetPortalsA( PULONG PortalCount, PISCSI_TARGET_PORTAL_INFOA PortalInfo );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportIScsiSendTargetPortalsA")]
	public static extern Win32Error ReportIScsiSendTargetPortals(ref uint PortalCount, [Out, MarshalAs(UnmanagedType.LPArray)] ISCSI_TARGET_PORTAL_INFO[] PortalInfo);

	/// <summary>
	/// The <c>ReportIscsiSendTargetPortalsEx</c> function retrieves a list of static target portals that the iSCSI initiator service
	/// uses to perform automatic discovery with <c>SendTarget</c> requests.
	/// </summary>
	/// <param name="PortalCount">
	/// A pointer to a location that, on input, contains the number of entries in the PortalInfo array. On output, this parameter
	/// specifies the number of elements that contain return data.
	/// </param>
	/// <param name="PortalInfoSize">
	/// A pointer to a location that, on input, contains the byte-size of the buffer specified by PortalInfo. On output, this parameter
	/// specifies the number of bytes retrieved.
	/// </param>
	/// <param name="PortalInfo">
	/// Pointer to an array of elements contained in a <see cref="ISCSI_TARGET_PORTAL_INFO_EX"/> structure that describe the portals
	/// that the iSCSI initiator service utilizes to perform discovery with <c>SendTargets</c> requests.
	/// </param>
	/// <returns>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the size of the buffer at PortalInfo is
	/// insufficient to contain the output data. Otherwise, <c>ReportIscsiSendTargetPortalsEx</c> returns the appropriate Win32 or iSCSI
	/// error code on failure.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ReportIScsiSendTargetPortalsEx as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportiscsisendtargetportalsexa ISDSC_STATUS ISDSC_API
	// ReportIScsiSendTargetPortalsExA( PULONG PortalCount, PULONG PortalInfoSize, PISCSI_TARGET_PORTAL_INFO_EXA PortalInfo );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportIScsiSendTargetPortalsExA")]
	public static extern Win32Error ReportIScsiSendTargetPortalsEx(out uint PortalCount, ref uint PortalInfoSize, [In, Out, Optional] IntPtr PortalInfo);

	/// <summary>
	/// The <c>ReportIscsiTargetPortals</c> function retrieves target portal information discovered by the iSCSI initiator service.
	/// </summary>
	/// <param name="InitiatorName">A string that represents the name of the initiator node.</param>
	/// <param name="TargetName">A string that represents the name of the target for which the portal information is retrieved.</param>
	/// <param name="TargetPortalTag">A <c>USHORT</c> value that represents a tag associated with the portal.</param>
	/// <param name="ElementCount">A <c>ULONG</c> value that specifies the number of portals currently reported for the specified target.</param>
	/// <param name="Portals">
	/// A variable-length array of an <c>ISCSI_TARGET_PORTALW</c> structure. The number of elements contained in this array is specified
	/// by the value of ElementCount.
	/// </param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if the operation is successful. If the operation fails due to a socket connection error, this
	/// function will return a Winsock error code.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ReportIScsiTargetPortals as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportiscsitargetportalsa ISDSC_STATUS ISDSC_API
	// ReportIScsiTargetPortalsA( StrPtrAnsi InitiatorName, StrPtrAnsi TargetName, PUSHORT TargetPortalTag, PULONG ElementCount,
	// PISCSI_TARGET_PORTALA Portals );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportIScsiTargetPortalsA")]
	public static extern Win32Error ReportIScsiTargetPortals([Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorName,
		[MarshalAs(UnmanagedType.LPTStr)] string TargetName, in ushort TargetPortalTag, ref uint ElementCount, out ISCSI_TARGET_PORTAL Portals);

	/// <summary>
	/// The <c>ReportIscsiTargets</c> function retrieves the list of targets that the iSCSI initiator service has discovered, and can
	/// also instruct the iSCSI initiator service to refresh the list.
	/// </summary>
	/// <param name="ForceUpdate">
	/// If <c>true</c>, the iSCSI initiator service updates the list of discovered targets before returning the target list data to the caller.
	/// </param>
	/// <param name="BufferSize">A <c>ULONG</c> value that specifies the number of list elements contained by the Buffer parameter.</param>
	/// <param name="Buffer">
	/// Pointer to a buffer that receives and contains the list of targets. The list consists of <c>null</c>-terminated strings. The
	/// last string, however, is double <c>null</c>-terminated.
	/// </param>
	/// <returns>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the buffer size is insufficient to contain the
	/// output data. Otherwise, <c>ReportIscsiTargets</c> returns the appropriate Win32 or iSCSI error code on failure.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ReportIScsiTargets as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportiscsitargetsa ISDSC_STATUS ISDSC_API
	// ReportIScsiTargetsA( BOOLEAN ForceUpdate, PULONG BufferSize, PCHAR Buffer );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportIScsiTargetsA")]
	public static extern Win32Error ReportIScsiTargets([MarshalAs(UnmanagedType.U1)] bool ForceUpdate, ref uint BufferSize,
		[Out, Optional] IntPtr Buffer);

	/// <summary>
	/// The <c>ReportIscsiTargets</c> function retrieves the list of targets that the iSCSI initiator service has discovered, and can
	/// also instruct the iSCSI initiator service to refresh the list.
	/// </summary>
	/// <param name="ForceUpdate">
	/// If <c>true</c>, the iSCSI initiator service updates the list of discovered targets before returning the target list data to the caller.
	/// </param>
	/// <returns>The list of targets.</returns>
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportIScsiTargetsA")]
	public static string[] ReportIScsiTargets(bool ForceUpdate) => GetStringList((ref uint sz, IntPtr p) => ReportIScsiTargets(ForceUpdate, ref sz, p));

	/// <summary>
	/// The <c>ReportIsnsServerList</c> function retrieves the list of Internet Storage Name Service (iSNS) servers that the iSCSI
	/// initiator service queries for discovered targets.
	/// </summary>
	/// <param name="BufferSizeInChar">
	/// A <c>ULONG</c> value that specifies the number of list elements contained by the Buffer parameter. If the operation succeeds,
	/// this location receives the size, represented by a number of elements, that corresponds to the number of retrieved iSNS servrs.
	/// </param>
	/// <param name="Buffer">
	/// The buffer that holds the list of iSNS servers on output. Each server name is <c>null</c> terminated, except for the last server
	/// name, which is double <c>null</c> terminated.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the buffer is too small to hold the output data.
	/// </para>
	/// <para>Otherwise, <c>ReportIsnsServerList</c> returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ReportISNSServerList as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportisnsserverlista ISDSC_STATUS ISDSC_API
	// ReportISNSServerListA( PULONG BufferSizeInChar, PCHAR Buffer );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportISNSServerListA")]
	public static extern Win32Error ReportISNSServerList(ref uint BufferSizeInChar, [Out, Optional] IntPtr Buffer);

	/// <summary>
	/// The <c>ReportIsnsServerList</c> function retrieves the list of Internet Storage Name Service (iSNS) servers that the iSCSI
	/// initiator service queries for discovered targets.
	/// </summary>
	/// <returns>The list of iSNS servers on output.</returns>
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportISNSServerListA")]
	public static string[] ReportISNSServerList() => GetStringList(ReportISNSServerList);

	/// <summary>The <c>ReportPersistentIscsiDevices</c> function retrieves the list of persistently bound volumes and devices.</summary>
	/// <param name="BufferSizeInChar">A <c>ULONG</c> value that specifies the number of list elements contained by the Buffer parameter.</param>
	/// <param name="Buffer">
	/// Pointer to a buffer that receives the list of volumes and devices that are persistently bound. The list consists of
	/// <c>null</c>-terminated strings. The last string, however, is double <c>null</c>-terminated.
	/// </param>
	/// <returns>
	/// Returns ERROR_SUCCESS if the operation succeeds or ERROR_INSUFFICIENT_BUFFER if the buffer was insufficient to receive the
	/// output data. Otherwise, <c>ReportPersistentiScsiDevices</c> returns the appropriate Win32 or iSCSI error code on failure.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportpersistentiscsidevicesa ISDSC_STATUS ISDSC_API
	// ReportPersistentIScsiDevicesA( PULONG BufferSizeInChar, PCHAR Buffer );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportPersistentIScsiDevicesA")]
	public static extern Win32Error ReportPersistentIScsiDevices(ref uint BufferSizeInChar, IntPtr Buffer);

	/// <summary>The <c>ReportPersistentIscsiDevices</c> function retrieves the list of persistently bound volumes and devices.</summary>
	/// <returns>The list of volumes and devices that are persistently bound.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportpersistentiscsidevicesa ISDSC_STATUS ISDSC_API
	// ReportPersistentIScsiDevicesA( PULONG BufferSizeInChar, PCHAR Buffer );
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportPersistentIScsiDevicesA")]
	public static string[] ReportPersistentIScsiDevices() => GetStringList(ReportPersistentIScsiDevices);

	/// <summary>
	/// The <c>ReportRadiusServerList</c> function retrieves the list of Remote Authentication Dail-In Service (RADIUS) servers the
	/// iSCSI initiator service uses during authentication.
	/// </summary>
	/// <param name="BufferSizeInChar">A <c>ULONG</c> value that specifies the number of list elements contained by the Buffer parameter.</param>
	/// <param name="Buffer">
	/// Pointer to a buffer that receives the list of Remote Authentication Dail-In Service (RADIUS) servers on output. Each server name
	/// is null terminated, except for the last server name, which is double null-terminated.
	/// </param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if the operation is successful. If the operation fails due to a socket connection error, this
	/// function will return a Winsock error code.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ReportRadiusServerList as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-reportradiusserverlista ISDSC_STATUS ISDSC_API
	// ReportRadiusServerListA( PULONG BufferSizeInChar, PCHAR Buffer );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportRadiusServerListA")]
	public static extern Win32Error ReportRadiusServerList(ref uint BufferSizeInChar, [Out, Optional] IntPtr Buffer);

	/// <summary>
	/// The <c>ReportRadiusServerList</c> function retrieves the list of Remote Authentication Dail-In Service (RADIUS) servers the
	/// iSCSI initiator service uses during authentication.
	/// </summary>
	/// <returns>The list of Remote Authentication Dail-In Service (RADIUS) servers on output.</returns>
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.ReportRadiusServerListA")]
	public static string[] ReportRadiusServerList() => GetStringList(ReportRadiusServerList);

	/// <summary>The <c>SendScsiInquiry</c> function sends a SCSI INQUIRY command to the specified target.</summary>
	/// <param name="UniqueSessionId">
	/// A pointer to a ISCSI_UNIQUE_SESSION_ID structure containing the session identifier for the login session specific to the target
	/// to which the READ CAPACITY command is sent.
	/// </param>
	/// <param name="Lun">The logical unit to query for SCSI inquiry data.</param>
	/// <param name="EvpdCmddt">
	/// The values to assign to the EVP (enable the vital product data) and CmdDt (command support data) bits in the INQUIRY command.
	/// Bits 0 (EVP) and 1 (CmdDt) of the EvpdCmddt parameter are inserted into bits 0 and 1, respectively, of the second byte of the
	/// Command Descriptor Block (CDB) of the <c>INQUIRY</c> command.
	/// </param>
	/// <param name="PageCode">The page code. This code is inserted into the third byte of the CDB of the <c>INQUIRY</c> command.</param>
	/// <param name="ScsiStatus">A pointer to a location that reports the execution status of the CDB.</param>
	/// <param name="ResponseSize">
	/// A pointer to the location that, on input, specifies the byte-size of ResponseBuffer. On output, this location specifies the
	/// number of bytes required to contain the response data for the READ CAPACITY command in the ResponseBuffer.
	/// </param>
	/// <param name="ResponseBuffer">The buffer that holds the inquiry data.</param>
	/// <param name="SenseSize">
	/// A pointer to a location that, on input, contains the byte-size of SenseBuffer. On output, the location pointed to receives the
	/// byte-size required for SenseBuffer to contain the sense data. This value will always be greater than or equal to 18 bytes.
	/// </param>
	/// <param name="SenseBuffer">The buffer that holds the sense data.</param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the buffer specified by ResponseBuffer is
	/// insufficient to contain the sense data.
	/// </para>
	/// <para>
	/// If the device returns a SCSI error while processing the REPORT LUNS request, SendScsiReportLuns returns an error code of
	/// ISDSC_SCSI_REQUEST_FAILED, and the locations pointed to by ScsiStatus and SenseBuffer contain information detailing the SCSI error.
	/// </para>
	/// <para>Otherwise, <c>SendScsiInquiry</c> returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-sendscsiinquiry ISDSC_STATUS ISDSC_API SendScsiInquiry(
	// PISCSI_UNIQUE_SESSION_ID UniqueSessionId, ULONGLONG Lun, UCHAR EvpdCmddt, UCHAR PageCode, PUCHAR ScsiStatus, PULONG ResponseSize,
	// PUCHAR ResponseBuffer, PULONG SenseSize, PUCHAR SenseBuffer );
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SendScsiInquiry")]
	public static extern Win32Error SendScsiInquiry(in ISCSI_UNIQUE_SESSION_ID UniqueSessionId, ulong Lun, byte EvpdCmddt,
		byte PageCode, out byte ScsiStatus, ref uint ResponseSize, [Out] IntPtr ResponseBuffer, ref uint SenseSize, [Out] IntPtr SenseBuffer);

	/// <summary>The <c>SendScsiReadCapacity</c> function sends a SCSI READ CAPACITY command to the indicated target.</summary>
	/// <param name="UniqueSessionId">
	/// A pointer to a ISCSI_UNIQUE_SESSION_ID structure containing the session identifier for the login session specific to the target
	/// to which the READ CAPACITY command is sent.
	/// </param>
	/// <param name="Lun">The logical unit on the target to query with the READ CAPACITY command.</param>
	/// <param name="ScsiStatus">A pointer to a location that contains the execution status of the CDB.</param>
	/// <param name="ResponseSize">
	/// A pointer to the location that, on input, specifies the byte-size of ResponseBuffer. On output, this location specifies the
	/// number of bytes required to contain the response data for the READ CAPACITY command in the ResponseBuffer.
	/// </param>
	/// <param name="ResponseBuffer">The buffer that receives the response data from the READ CAPACITY command.</param>
	/// <param name="SenseSize">
	/// A pointer to a location that, on input, contains the byte-size of SenseBuffer. On output, the location pointed to receives the
	/// byte-size required for SenseBuffer to contain the sense data. This value will always be greater than or equal to 18 bytes.
	/// </param>
	/// <param name="SenseBuffer">The buffer that receives the sense data.</param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the buffer specified by ResponseBuffer is
	/// insufficient to contain the sense data.
	/// </para>
	/// <para>
	/// If the device returns a SCSI error while processing the REPORT LUNS request, SendScsiReportLuns returns an error code of
	/// ISDSC_SCSI_REQUEST_FAILED, and the locations pointed to by ScsiStatus and SenseBuffer contain information detailing the SCSI error.
	/// </para>
	/// <para>Otherwise, this function returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-sendscsireadcapacity ISDSC_STATUS ISDSC_API
	// SendScsiReadCapacity( PISCSI_UNIQUE_SESSION_ID UniqueSessionId, ULONGLONG Lun, PUCHAR ScsiStatus, PULONG ResponseSize, PUCHAR
	// ResponseBuffer, PULONG SenseSize, PUCHAR SenseBuffer );
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SendScsiReadCapacity")]
	public static extern Win32Error SendScsiReadCapacity(in ISCSI_UNIQUE_SESSION_ID UniqueSessionId, ulong Lun,
		out byte ScsiStatus, ref uint ResponseSize, [Out] IntPtr ResponseBuffer, ref uint SenseSize, [Out] IntPtr SenseBuffer);

	/// <summary><c>SendScsiReportLuns</c> function sends a SCSI REPORT LUNS command to a specified target.</summary>
	/// <param name="UniqueSessionId">
	/// A pointer to a ISCSI_UNIQUE_SESSION_ID structure that contains the session identifier for the login session of the target to
	/// query with the SCSI REPORT LUNS command.
	/// </param>
	/// <param name="ScsiStatus">A pointer to the location that receives the execution status of the CDB.</param>
	/// <param name="ResponseSize">
	/// A pointer to the location that, on input, specifies the byte-size of ResponseBuffer. On output, this location specifies the
	/// number of bytes required to contain the response data for the READ CAPACITY command in the ResponseBuffer.
	/// </param>
	/// <param name="ResponseBuffer">The buffer that receives response data for the READ CAPACITY command.</param>
	/// <param name="SenseSize">
	/// A pointer to a location that, on input, contains the byte-size of SenseBuffer. On output, the location pointed to receives the
	/// byte-size required for SenseBuffer to contain the sense data. This value will always be greater than or equal to 18 bytes.
	/// </param>
	/// <param name="SenseBuffer">The buffer that receives the sense data.</param>
	/// <returns>
	/// <para>
	/// Returns ERROR_SUCCESS if the operation succeeds and ERROR_INSUFFICIENT_BUFFER if the buffer specified by ResponseBuffer is
	/// insufficient to hold the sense data.
	/// </para>
	/// <para>
	/// If the device returns a SCSI error while processing the REPORT LUNS request, <c>SendScsiReportLuns</c> returns an error code of
	/// ISDSC_SCSI_REQUEST_FAILED, and the locations pointed to by ScsiStatus and SenseBuffer contain information detailing the SCSI error.
	/// </para>
	/// <para>Otherwise, this function returns the appropriate Win32 or iSCSI error code on failure.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-sendscsireportluns ISDSC_STATUS ISDSC_API
	// SendScsiReportLuns( PISCSI_UNIQUE_SESSION_ID UniqueSessionId, PUCHAR ScsiStatus, PULONG ResponseSize, PUCHAR ResponseBuffer,
	// PULONG SenseSize, PUCHAR SenseBuffer );
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SendScsiReportLuns")]
	public static extern Win32Error SendScsiReportLuns(in ISCSI_UNIQUE_SESSION_ID UniqueSessionId, out byte ScsiStatus,
		ref uint ResponseSize, [Out] IntPtr ResponseBuffer, ref uint SenseSize, [Out] IntPtr SenseBuffer);

	/// <summary>
	/// The <c>SetIscsiGroupPresharedKey</c> function establishes the default group preshared key for all initiators on the computer.
	/// </summary>
	/// <param name="KeyLength">The size, in bytes, of the preshared key.</param>
	/// <param name="Key">The buffer that contains the preshared key.</param>
	/// <param name="Persist">
	/// If <c>true</c>, this parameter indicates that the preshared key information will be stored in non-volatile memory and will
	/// persist across restarts of the computer or the iSCSI initiator service.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-setiscsigrouppresharedkey ISDSC_STATUS ISDSC_API
	// SetIScsiGroupPresharedKey( ULONG KeyLength, PUCHAR Key, BOOLEAN Persist );
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SetIScsiGroupPresharedKey")]
	public static extern Win32Error SetIScsiGroupPresharedKey(uint KeyLength, [In, MarshalAs(UnmanagedType.LPStr)] string? Key,
		[MarshalAs(UnmanagedType.U1)] bool Persist);

	/// <summary>
	/// The <c>SetIscsiIKEInfo</c> function establishes the IPsec policy and preshared key for the indicated initiator to use when
	/// performing iSCSI connections.
	/// </summary>
	/// <param name="InitiatorName">The name of the initiator HBA for which the IPsec policy is established.</param>
	/// <param name="InitiatorPortNumber">
	/// The port on the initiator HBA with which to associate the key. If this parameter contains a value of
	/// <c>ISCSI_ALL_INITIATOR_PORTS</c>, all ports on the initiator are associated with the key.
	/// </param>
	/// <param name="AuthInfo">
	/// A pointer to a IKE_AUTHENTICATION_INFORMATION structure that contains the authentication method. Currently, only the
	/// IKE_AUTHENTICATION_PRESHARED_KEY_METHOD is supported.
	/// </param>
	/// <param name="Persist">
	/// If <c>true</c>, this parameter indicates that the preshared key information will be stored in non-volatile memory and will
	/// persist across restarts of the computer or the iSCSI initiator service.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines SetIScsiIKEInfo as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-setiscsiikeinfoa ISDSC_STATUS ISDSC_API SetIScsiIKEInfoA(
	// StrPtrAnsi InitiatorName, ULONG InitiatorPortNumber, PIKE_AUTHENTICATION_INFORMATION AuthInfo, BOOLEAN Persist );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SetIScsiIKEInfoA")]
	public static extern Win32Error SetIScsiIKEInfo([Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorName,
		uint InitiatorPortNumber, in IKE_AUTHENTICATION_INFORMATION AuthInfo, [MarshalAs(UnmanagedType.U1)] bool Persist);

	/// <summary>
	/// The <c>SetIscsiInitiatorCHAPSharedSecret</c> function establishes the default Challenge Handshake Authentication Protocol (CHAP)
	/// shared secret for all initiators on the computer.
	/// </summary>
	/// <param name="SharedSecretLength">
	/// The size, in bytes, of the shared secret contained by the buffer specified by SharedSecret. The shared secret must be at least
	/// 96 bits (12 bytes) for non-IPsec connections, at least 8 bits (1 byte) for IPsec connections, and less than 128 bits (16 bytes)
	/// for all connection types.
	/// </param>
	/// <param name="SharedSecret">The buffer that contains the shared secret.</param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>
	/// When an initiator attempts to log in to a target, the initiator can issue a challenge if mutual CHAP is used. The target must
	/// respond to the challenge with the initiator CHAP shared secret.
	/// </para>
	/// <para>
	/// The <c>SetIscsiInitiatorCHAPSharedSecret</c> function specifies the default CHAP secret that all initiators on the computer use
	/// to authenticate a target when performing mutual CHAP. Management software can specify the CHAP secret for the initiator to
	/// provide when challenged by the target when the initiator calls the LoginIscsiTarget or AddIscsiStaticTarget function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-setiscsiinitiatorchapsharedsecret ISDSC_STATUS ISDSC_API
	// SetIScsiInitiatorCHAPSharedSecret( ULONG SharedSecretLength, PUCHAR SharedSecret );
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SetIScsiInitiatorCHAPSharedSecret")]
	public static extern Win32Error SetIScsiInitiatorCHAPSharedSecret(uint SharedSecretLength, [In] IntPtr SharedSecret);

	/// <summary>
	/// The <c>SetIscsiInitiatorNodeName</c> function establishes an initiator node name for the computer. This name is utilized by any
	/// initiator nodes on the computer that are communicating with other nodes.
	/// </summary>
	/// <param name="InitiatorNodeName">
	/// The initiator node name. If this parameter is <c>null</c>, initiators use a default initiator node name based upon the computer name.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>The <c>SetIscsiInitiatorNodeName</c> routine does not verify that the format of the name in InitiatorNodeName is correct.</para>
	/// <para>
	/// Some hardware initiator drivers can respond immediately to a change of the node name, while others must be restarted to finalize
	/// the change to the node name.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines SetIScsiInitiatorNodeName as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-setiscsiinitiatornodenamew ISDSC_STATUS ISDSC_API
	// SetIScsiInitiatorNodeNameW( StrPtrUni InitiatorNodeName );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SetIScsiInitiatorNodeNameW")]
	public static extern Win32Error SetIScsiInitiatorNodeName([Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorNodeName);

	/// <summary>
	/// The <c>SetIscsiInitiatorRADIUSSharedSecret</c> function establishes the Remote Authentication Dial-In User Service (RADIUS)
	/// shared secret.
	/// </summary>
	/// <param name="SharedSecretLength">
	/// A <c>ULONG</c> value that represents the size, in bytes, of the shared secret contained by the buffer specified by SharedSecret.
	/// The shared secret must be at least 22 bytes, and less than, or equal to, 26 bytes in size.
	/// </param>
	/// <param name="SharedSecret">A string that specifies the buffer containing the shared secret.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if the operation is successful. If the operation fails due to a socket connection error, this
	/// function will return a Winsock error code.
	/// </returns>
	/// <remarks>
	/// When an initiator attempts to log in to a target, the initiator can use the RADIUS server for authentication, or to authenticate
	/// a target. During this process the initiator uses the SharedSecret to communicate with the RADIUS server.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-setiscsiinitiatorradiussharedsecret ISDSC_STATUS
	// ISDSC_API SetIScsiInitiatorRADIUSSharedSecret( ULONG SharedSecretLength, PUCHAR SharedSecret );
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SetIScsiInitiatorRADIUSSharedSecret")]
	public static extern Win32Error SetIScsiInitiatorRADIUSSharedSecret(uint SharedSecretLength, [MarshalAs(UnmanagedType.LPStr)] string SharedSecret);

	/// <summary>
	/// <c>SetIscsiTunnelModeOuterAddress</c> function establishes the tunnel-mode outer address that the indicated initiator Host Bus
	/// Adapter (HBA) uses when communicating in IPsec tunnel mode through the specified port.
	/// </summary>
	/// <param name="InitiatorName">
	/// The name of the initiator with which the tunnel-mode outer address will be associated. If this parameter is <c>null</c>, all HBA
	/// initiators are configured to use the indicated tunnel-mode outer address.
	/// </param>
	/// <param name="InitiatorPortNumber">
	/// Indicates the number of the port with which the tunnel-mode outer address is associated. If this parameter contains
	/// <c>ISCSI_ALL_PORTS</c>, all ports on the indicated initiator are associated with the tunnel-mode outer address.
	/// </param>
	/// <param name="DestinationAddress">The destination address to associate with the tunnel-mode outer address indicated by OuterModeAddress.</param>
	/// <param name="OuterModeAddress">The tunnel-mode outer address to associate with indicated initiators and ports.</param>
	/// <param name="Persist">
	/// When <c>true</c>, this parameter indicates that the iSCSI initiator service stores the tunnel-mode outer address in non-volatile
	/// memory and that the address will persist across restarts of the initiator and the iSCSI initiator service.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds.Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines SetIScsiTunnelModeOuterAddress as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-setiscsitunnelmodeouteraddressa ISDSC_STATUS ISDSC_API
	// SetIScsiTunnelModeOuterAddressA( StrPtrAnsi InitiatorName, ULONG InitiatorPortNumber, StrPtrAnsi DestinationAddress, StrPtrAnsi OuterModeAddress,
	// BOOLEAN Persist );
	[DllImport(Lib_Iscsidsc, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SetIScsiTunnelModeOuterAddressA")]
	public static extern Win32Error SetIScsiTunnelModeOuterAddress([In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? InitiatorName,
		uint InitiatorPortNumber, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? DestinationAddress,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? OuterModeAddress, [MarshalAs(UnmanagedType.U1)] bool Persist);

	/// <summary>
	/// The <c>SetupPersistentIscsiDevices</c> function builds the list of devices and volumes assigned to iSCSI targets that are
	/// connected to the computer, and saves this list in non-volatile cache of the iSCSI initiator service.
	/// </summary>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	/// <remarks>
	/// <para>
	/// When the iSCSI Initiator service starts, it does not complete initialization until the storage stack can access and enumerate
	/// all persistent iSCSI volumes and devices. If there is a service that is dependent on data stored on a persistent volume or
	/// device, it should be configured to have a dependency on the iSCSI service (MSiSCSI).
	/// </para>
	/// <para>The correct procedure for a system administrator to configure a computer to use external persistent volumes is as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Login to all of the targets that contain the volumes</term>
	/// </item>
	/// <item>
	/// <term>Configure all volumes on top of the disks</term>
	/// </item>
	/// <item>
	/// <term>
	/// Use management software to call the <c>SetupPersistentIscsiDevices</c> routine, so that the iSCSI initiator service will add the
	/// volumes to its list of persistent volumes.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/nf-iscsidsc-setuppersistentiscsidevices ISDSC_STATUS ISDSC_API SetupPersistentIScsiDevices();
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h", MSDNShortId = "NF:iscsidsc.SetupPersistentIScsiDevices")]
	public static extern Win32Error SetupPersistentIScsiDevices();

	/// <summary>The SetupPersistentIscsiVolumes method sets iSCSI volumes to be persistent.</summary>
	/// <returns>Returns ERROR_SUCCESS if the operation succeeds. Otherwise, it returns the appropriate Win32 or iSCSI error code.</returns>
	[DllImport(Lib_Iscsidsc, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("iscsidsc.h")]
	public static extern Win32Error SetupPersistentIScsiVolumes();

	private static string[] GetStringList(GetListDelegate func, CharSet charSet = CharSet.Auto)
	{
		var sz = 0U;
		var err = func(ref sz, IntPtr.Zero);
		if (err == Win32Error.ERROR_INSUFFICIENT_BUFFER)
		{
			using var mem = new SafeCoTaskMemHandle(sz);
			func(ref sz, mem).ThrowIfFailed();
			return mem.ToStringEnum(charSet).ToArray();
		}
		err.ThrowIfFailed();
		return new string[0];
	}

	/// <summary>
	/// The <c>IKE_AUTHENTICATION_INFORMATION</c> structure contains Internet Key Exchange (IKE) authentication information used to
	/// establish a secure channel between two key management daemons.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-ike_authentication_information typedef struct {
	// IKE_AUTHENTICATION_METHOD AuthMethod; union { IKE_AUTHENTICATION_PRESHARED_KEY PsKey; }; } IKE_AUTHENTICATION_INFORMATION, *PIKE_AUTHENTICATION_INFORMATION;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKE_AUTHENTICATION_INFORMATION
	{
		/// <summary>A IKE_AUTHENTICATION_METHOD structure that indicates the authentication method.</summary>
		public IKE_AUTHENTICATION_METHOD AuthMethod;

		/// <summary/>
		public IKE_AUTHENTICATION_PRESHARED_KEY PsKey;
	}

	/// <summary>
	/// The <c>IKE_AUTHENTICATION_PRESHARED_KEY</c> structure contains information about the preshared key used in the Internet Key
	/// Exchange (IKE) protocol.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-ike_authentication_preshared_key typedef struct {
	// ISCSI_SECURITY_FLAGS SecurityFlags; IKE_IDENTIFICATION_PAYLOAD_TYPE IdType; ULONG IdLengthInBytes; PUCHAR Id; ULONG
	// KeyLengthInBytes; PUCHAR Key; } IKE_AUTHENTICATION_PRESHARED_KEY, *PIKE_AUTHENTICATION_PRESHARED_KEY;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKE_AUTHENTICATION_PRESHARED_KEY
	{
		/// <summary>
		/// <para>A bitmap that defines the security characteristics of a login connection.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED</term>
		/// <term>
		/// The Host Bus Adapter (HBA) initiator should establish the TCP/IP connection to the target portal using IPsec tunnel mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED</term>
		/// <term>The HBA initiator should establish the TCP/IP connection to the target portal using IPsec transport mode.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_PFS_ENABLED</term>
		/// <term>
		/// The HBA initiator should establish the TCP/IP connection to the target portal with Perfect Forward Secrecy (PFS) mode
		/// enabled if IPsec is required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED</term>
		/// <term>The HBA initiator should establish the TCP/IP connection to the target portal with aggressive mode enabled.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED</term>
		/// <term>The HBA initiator should establish the TCP/IP connection to the target portal with main mode enabled.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED</term>
		/// <term>
		/// The HBA initiator should establish the TCP/IP connection to the target portal using IKE/IPsec protocol. If not set then
		/// IPsec is not required to login to the target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_VALID</term>
		/// <term>The other mask values are valid; otherwise, security flags are not specified.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ISCSI_SECURITY_FLAGS SecurityFlags;

		/// <summary>
		/// <para>The type of key identifier. The following table specifies the values that can be assigned to this member:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>ID Types</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ID_IPV4_ADDR</term>
		/// <term>Indicates four bytes of binary data that constitute a version 4 IP address.</term>
		/// </item>
		/// <item>
		/// <term>ID_FQDN</term>
		/// <term>An ANSI string that contains a fully qualified domain name. This string does not contain terminators.</term>
		/// </item>
		/// <item>
		/// <term>ID_USER_FQDN</term>
		/// <term>An ANSI string that contains a fully qualified user name. This string does not contain terminators.</term>
		/// </item>
		/// <item>
		/// <term>ID_IPV6_ADDR</term>
		/// <term>Indicates 16 bytes of binary data that constitute a version 6 IP address.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IKE_IDENTIFICATION_PAYLOAD_TYPE IdType;

		/// <summary>The length, in bytes, of the key identifier.</summary>
		public uint IdLengthInBytes;

		/// <summary>The identifier of the preshared key used in the IKE protocol.</summary>
		public IntPtr Id;

		/// <summary>The length, in bytes, of the preshared key.</summary>
		public uint KeyLengthInBytes;

		/// <summary>The preshared key.</summary>
		public IntPtr Key;
	}

	/// <summary>The <c>ISCSI_CONNECTION_INFO</c> structure contains information about a connection.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ISCSI_CONNECTION_INFO as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_connection_infow typedef struct {
	// ISCSI_UNIQUE_CONNECTION_ID ConnectionId; PWCHAR InitiatorAddress; PWCHAR TargetAddress; USHORT InitiatorSocket; USHORT
	// TargetSocket; UCHAR CID[2]; } ISCSI_CONNECTION_INFOW, *PISCSI_CONNECTION_INFOW;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_14")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ISCSI_CONNECTION_INFO
	{
		/// <summary>
		/// A ISCSI_UNIQUE_CONNECTION_ID structure that contains the unique identifier for a connection. The LoginIScsiTarget and
		/// AddIScsiConnection functions return this value via the UniqueConnectionId parameter.
		/// </summary>
		public ISCSI_UNIQUE_SESSION_ID ConnectionId;

		/// <summary>A string that represents the IP address of the initiator.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string InitiatorAddress;

		/// <summary>A string that represents the IP address of the target.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string TargetAddress;

		/// <summary>The socket number on the initiator that establishes the connection.</summary>
		public ushort InitiatorSocket;

		/// <summary>The socket number on the target that establishes the connection.</summary>
		public ushort TargetSocket;

		/// <summary>The connection identifier for the connection.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] CID;
	}

	/// <summary>
	/// The <c>ISCSI_DEVICE_ON_SESSION</c> structure specifies multiple methods for identifying a device associated with an iSCSI login session.
	/// </summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ISCSI_DEVICE_ON_SESSION as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_device_on_sessionw typedef struct { WCHAR
	// InitiatorName[MAX_ISCSI_HBANAME_LEN]; WCHAR TargetName[MAX_ISCSI_NAME_LEN + 1]; SCSI_ADDRESS ScsiAddress; GUID
	// DeviceInterfaceType; WCHAR DeviceInterfaceName[MAX_PATH]; WCHAR LegacyName[MAX_PATH]; STORAGE_DEVICE_NUMBER StorageDeviceNumber;
	// DWORD DeviceInstance; } ISCSI_DEVICE_ON_SESSIONW, *PISCSI_DEVICE_ON_SESSIONW;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_20")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ISCSI_DEVICE_ON_SESSION
	{
		/// <summary>A string that indicates the initiator name.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_HBANAME_LEN)]
		public string InitiatorName;

		/// <summary>A string that indicates the target name.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_NAME_LEN + 1)]
		public string TargetName;

		/// <summary>A SCSI_ADDRESS structure that contains the SCSI address of the device.</summary>
		public SCSI_ADDRESS ScsiAddress;

		/// <summary>
		/// <para>
		/// A GUID that specifies the device interface class associated with the device. Device interface class GUIDs include, but are
		/// not limited to, the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>GUID</term>
		/// <term>Type of Device</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_DEVINTERFACE_DISK</term>
		/// <term>Disk</term>
		/// </item>
		/// <item>
		/// <term>GUID_DEVINTERFACE_TAPE</term>
		/// <term>Tape</term>
		/// </item>
		/// <item>
		/// <term>GUID_DEVINTERFACE_CDROM</term>
		/// <term>CD-ROM</term>
		/// </item>
		/// <item>
		/// <term>GUID_DEVINTERFACE_WRITEONCEDISK</term>
		/// <term>Write Once Disk</term>
		/// </item>
		/// <item>
		/// <term>GUID_DEVINTERFACE_CDCHANGER</term>
		/// <term>CD Changer</term>
		/// </item>
		/// <item>
		/// <term>GUID_DEVINTERFACE_MEDIUMCHANGER</term>
		/// <term>Medium Changer</term>
		/// </item>
		/// <item>
		/// <term>GUID_DEVINTERFACE_FLOPPY</term>
		/// <term>Floppy</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid DeviceInterfaceType;

		/// <summary>A string that specifies the name of the device interface class.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
		public string DeviceInterfaceName;

		/// <summary>A string that specifies the legacy device name.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
		public string LegacyName;

		/// <summary>A <c>STORAGE_DEVICE_NUMBER</c> structure containing the storage device number.</summary>
		public STORAGE_DEVICE_NUMBER StorageDeviceNumber;

		/// <summary>
		/// A handle to the instance of the device in the devnode tree. For information on the cfgmgr32Xxx functions that utilize this
		/// handle, see PnP Configuration Manager Functions.
		/// </summary>
		public uint DeviceInstance;
	}

	/// <summary>The <c>ISCSI_LOGIN_OPTIONS</c> structure is used by initiators to specify the characteristics of a login session.</summary>
	/// <remarks>
	/// <para>Initiators use the <c>ISCSI_LOGIN_OPTIONS</c> structure when creating a login session with the LoginIScsiTarget routine.</para>
	/// <para>
	/// The <c>Username</c> and <c>Password</c> members are either strings or binary values that are used for iSCSI authentication. The
	/// exact meaning and function of these two values depends on the type of authentication used. For the Challenge Handshake
	/// Authentication Protocol (CHAP), the value in the <c>Username</c> member is the CHAP name, and the value in the <c>Password</c>
	/// member is the shared secret of the target. If there is no value specified in <c>Username</c>, the initiator node name is used as
	/// the CHAP name.
	/// </para>
	/// <para>If the authentication protocol requires that these two values be strings, they must be ANSI strings.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_login_options typedef struct { ULONG Version;
	// ISCSI_LOGIN_OPTIONS_INFO_SPECIFIED InformationSpecified; ISCSI_LOGIN_FLAGS LoginFlags; ISCSI_AUTH_TYPES AuthType;
	// ISCSI_DIGEST_TYPES HeaderDigest; ISCSI_DIGEST_TYPES DataDigest; ULONG MaximumConnections; ULONG DefaultTime2Wait; ULONG
	// DefaultTime2Retain; ULONG UsernameLength; ULONG PasswordLength; PUCHAR Username; PUCHAR Password; } ISCSI_LOGIN_OPTIONS, *PISCSI_LOGIN_OPTIONS;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ISCSI_LOGIN_OPTIONS
	{
		/// <summary>
		/// The version of login option definitions that define the data in the structure. This member must be set to
		/// ISCSI_LOGIN_OPTIONS_VERSION 0.
		/// </summary>
		public uint Version;

		/// <summary>
		/// <para>A bitmap that indicates which parts of the <c>ISCSI_LOGIN_OPTIONS</c> structure contain valid data.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bit</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ISCSI_LOGIN_OPTIONS_USERNAME</term>
		/// <term>Specifies a user name to use in making a login connection.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_OPTIONS_PASSWORD</term>
		/// <term>Specifies a password to use in making a login connection.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_OPTIONS_HEADER_DIGEST</term>
		/// <term>Specifies the type of digest in use for guaranteeing the integrity of header data.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_OPTIONS_DATA_DIGEST</term>
		/// <term>Specifies the type of digest in use for guaranteeing the integrity of header data.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_OPTIONS_MAXIMUM_CONNECTIONS</term>
		/// <term>Specifies the maximum number of connections to target devices associated with the login session.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_OPTIONS_DEFAULT_TIME_2_WAIT</term>
		/// <term>Specifies the minimum time to wait, in seconds, before attempting to reconnect or reassign a connection that was dropped.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_OPTIONS_DEFAULT_TIME_2_RETAIN</term>
		/// <term>Specifies the maximum time allowed to reassign commands after the initial wait indicated in DefaultTime2Wait.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_OPTIONS_AUTH_TYPE</term>
		/// <term>Specifies the type of authentication that establishes the login session.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ISCSI_LOGIN_OPTIONS_INFO_SPECIFIED InformationSpecified;

		/// <summary>
		/// <para>
		/// A bitwise OR of login flags that define certain characteristics of the login session. The following table indicates the
		/// values that can be assigned to this member:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ISCSI_LOGIN_FLAG_RESERVED1</term>
		/// <term>Reserved for internal use.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_FLAG_ALLOW_PORTAL_HOPPING</term>
		/// <term>The RADIUS server is permitted to use the portal hopping function for a target if configured to do so.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_FLAG_REQUIRE_IPSEC</term>
		/// <term>The login session must use the IPsec protocol.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_LOGIN_FLAG_MULTIPATH_ENABLED</term>
		/// <term>
		/// Multipathing is allowed. When specified the iSCSI Initiator service will allow multiple sessions to the same target. If
		/// there are multiple sessions to the same target then there must be some sort of multipathing software installed otherwise
		/// data corruption will occur on the target.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ISCSI_LOGIN_FLAGS LoginFlags;

		/// <summary>An enumerator value of type ISCSI_AUTH_TYPES that indicates the authentication type.</summary>
		public ISCSI_AUTH_TYPES AuthType;

		/// <summary>
		/// An enumerator value of type ISCSI_DIGEST_TYPES that indicates the type of digest for guaranteeing the integrity of header data.
		/// </summary>
		public ISCSI_DIGEST_TYPES HeaderDigest;

		/// <summary>
		/// An enumerator value of type ISCSI_DIGEST_TYPES that indicates the type of digest for guaranteeing the integrity of
		/// non-header data.
		/// </summary>
		public ISCSI_DIGEST_TYPES DataDigest;

		/// <summary>
		/// A value between 1 and 65535 that specifies the maximum number of connections to the target device that can be associated
		/// with the login session.
		/// </summary>
		public uint MaximumConnections;

		/// <summary>
		/// The minimum time to wait, in seconds, before attempting to reconnect or reassign a connection that has been dropped.
		/// </summary>
		public uint DefaultTime2Wait;

		/// <summary>
		/// The maximum time allowed to reassign a connection after the initial wait indicated in <c>DefaultTime2Wait</c> has elapsed.
		/// </summary>
		public uint DefaultTime2Retain;

		/// <summary>The length, in bytes, of the user name specified in the <c>Username</c> member.</summary>
		public uint UsernameLength;

		/// <summary>The length, in bytes, of the user name specified in the <c>Password</c> member.</summary>
		public uint PasswordLength;

		/// <summary>
		/// The user name to authenticate to establish the login session. This value is not necessarily a string. For more information,
		/// see the Remarks section in this document.
		/// </summary>
		public IntPtr Username;

		/// <summary>
		/// The user name to authenticate to establish the login session. This value is not necessarily a string. For more information,
		/// see the Remarks section in this document.
		/// </summary>
		public IntPtr Password;
	}

	/// <summary>The <c>ISCSI_SESSION_INFO</c> structure contains session information.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ISCSI_SESSION_INFO as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_session_infoa typedef struct {
	// ISCSI_UNIQUE_SESSION_ID SessionId; PCHAR InitiatorName; PCHAR TargetNodeName; PCHAR TargetName; UCHAR ISID[6]; UCHAR TSID[2];
	// ULONG ConnectionCount; PISCSI_CONNECTION_INFOA Connections; } ISCSI_SESSION_INFOA, *PISCSI_SESSION_INFOA;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_17")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ISCSI_SESSION_INFO
	{
		/// <summary>A ISCSI_UNIQUE_SESSION_ID structure containing a unique identifier that represents the session.</summary>
		public ISCSI_UNIQUE_SESSION_ID SessionId;

		/// <summary>A string that represents the initiator name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string InitiatorName;

		/// <summary>A string that represents the target node name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string TargetNodeName;

		/// <summary>A string that represents the target name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string TargetName;

		/// <summary>The initiator-side identifier (ISID) used in the iSCSI protocol.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public byte[] ISID;

		/// <summary>The target-side identifier (TSID) used in the iSCSI protocol.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] TSID;

		/// <summary>The number of connections associated with the session.</summary>
		public uint ConnectionCount;

		/// <summary>A pointer to a <see cref="ISCSI_CONNECTION_INFO"/> structure.</summary>
		public IntPtr Connections;
	}

	/// <summary>The <c>ISCSI_SESSION_INFO</c> structure contains session information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_session_infoa typedef struct {
	// ISCSI_UNIQUE_SESSION_ID SessionId; PCHAR InitiatorName; PCHAR TargetNodeName; PCHAR TargetName; UCHAR ISID[6]; UCHAR TSID[2];
	// ULONG ConnectionCount; PISCSI_CONNECTION_INFOA Connections; } ISCSI_SESSION_INFOA, *PISCSI_SESSION_INFOA;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_17")]
	public struct ISCSI_SESSION_INFO_MGD
	{
		/// <summary>A ISCSI_UNIQUE_SESSION_ID structure containing a unique identifier that represents the session.</summary>
		public ISCSI_UNIQUE_SESSION_ID SessionId;

		/// <summary>A string that represents the initiator name.</summary>
		public string InitiatorName;

		/// <summary>A string that represents the target node name.</summary>
		public string TargetNodeName;

		/// <summary>A string that represents the target name.</summary>
		public string TargetName;

		/// <summary>The initiator-side identifier (ISID) used in the iSCSI protocol.</summary>
		public byte[] ISID;

		/// <summary>The target-side identifier (TSID) used in the iSCSI protocol.</summary>
		public byte[] TSID;

		/// <summary>The connections associated with the session.</summary>
		public ISCSI_CONNECTION_INFO[] Connections;

		internal ISCSI_SESSION_INFO_MGD(in ISCSI_SESSION_INFO info)
		{
			SessionId = info.SessionId;
			InitiatorName = info.InitiatorName;
			TargetNodeName = info.TargetNodeName;
			TargetName = info.TargetName;
			ISID = info.ISID;
			TSID = info.TSID;
			Connections = info.Connections.ToArray<ISCSI_CONNECTION_INFO>((int)info.ConnectionCount) ?? new ISCSI_CONNECTION_INFO[0];
		}

		/// <summary>Performs an implicit conversion from <see cref="ISCSI_SESSION_INFO"/> to <see cref="ISCSI_SESSION_INFO_MGD"/>.</summary>
		/// <param name="info">The information.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ISCSI_SESSION_INFO_MGD(in ISCSI_SESSION_INFO info) => new(info);
	}

	/// <summary>
	/// The ISCSI_TARGET_MAPPING structure contains information about a target and the Host-Bus Adapters (HBAs) and buses through which
	/// the target is reached.
	/// </summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ISCSI_TARGET_MAPPING as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_target_mappinga typedef struct { CHAR
	// InitiatorName[MAX_ISCSI_HBANAME_LEN]; CHAR TargetName[MAX_ISCSI_NAME_LEN + 1]; CHAR OSDeviceName[MAX_PATH];
	// ISCSI_UNIQUE_SESSION_ID SessionId; ULONG OSBusNumber; ULONG OSTargetNumber; ULONG LUNCount; PSCSI_LUN_LIST LUNList; }
	// ISCSI_TARGET_MAPPINGA, *PISCSI_TARGET_MAPPINGA;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_5")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ISCSI_TARGET_MAPPING
	{
		/// <summary>A string representing the name of the HBA initiator through which the target is accessed.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_HBANAME_LEN)]
		public string InitiatorName;

		/// <summary>A string representing the target name.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_NAME_LEN + 1)]
		public string TargetName;

		/// <summary>A string representing the device name of the HBA initiator; for example ' <c>\device\ScsiPort3</c>'.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
		public string OSDeviceName;

		/// <summary>A ISCSI_UNIQUE_SESSION_ID structure containing information that uniquely identifies the session..</summary>
		public ISCSI_UNIQUE_SESSION_ID SessionId;

		/// <summary>The bus number used by the initiator as the local SCSI address of the target.</summary>
		public uint OSBusNumber;

		/// <summary>The target number used by the initiator as the local SCSI address of the target.</summary>
		public uint OSTargetNumber;

		/// <summary>The number of logical units (LUN) on the target.</summary>
		public uint LUNCount;

		/// <summary>A list of SCSI_LUN_LIST structures that contain information about the LUNs associated with the target.</summary>
		public IntPtr LUNList;
	}

	/// <summary>The <c>ISCSI_TARGET_PORTAL</c> structure contains information about a portal.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ISCSI_TARGET_PORTAL as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_target_portala typedef struct { CHAR
	// SymbolicName[MAX_ISCSI_PORTAL_NAME_LEN]; CHAR Address[MAX_ISCSI_PORTAL_ADDRESS_LEN]; USHORT Socket; } ISCSI_TARGET_PORTALA, *PISCSI_TARGET_PORTALA;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_7")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ISCSI_TARGET_PORTAL
	{
		/// <summary>A string representing the name of the portal.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_PORTAL_NAME_LEN)]
		public string SymbolicName;

		/// <summary>A string representing the IP address or DNS name of the portal.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_PORTAL_ADDRESS_LEN)]
		public string Address;

		/// <summary>The socket number of the portal.</summary>
		public ushort Socket;
	}

	/// <summary>The <c>ISCSI_TARGET_PORTAL_GROUP</c> structure contains information about the portals associated with a portal group.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ISCSI_TARGET_PORTAL_GROUP as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_target_portal_groupw typedef struct { ULONG Count;
	// ISCSI_TARGET_PORTALW Portals[1]; } ISCSI_TARGET_PORTAL_GROUPW, *PISCSI_TARGET_PORTAL_GROUPW;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_12")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<ISCSI_TARGET_PORTAL_GROUP>), nameof(Count))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ISCSI_TARGET_PORTAL_GROUP
	{
		/// <summary>The number of portals in the portal group.</summary>
		public uint Count;

		/// <summary>
		/// An array of ISCSI_TARGET_PORTAL structures that describe the portals associated with the portal group. Portal names and
		/// addresses are described by either wide-character or ascii strings, depending upon implementation.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public ISCSI_TARGET_PORTAL[] Portals;
	}

	/// <summary>The <c>ISCSI_TARGET_PORTAL_INFO</c> structure contains information about a target portal.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ISCSI_TARGET_PORTAL_INFO as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_target_portal_infoa typedef struct { CHAR
	// InitiatorName[MAX_ISCSI_HBANAME_LEN]; ULONG InitiatorPortNumber; CHAR SymbolicName[MAX_ISCSI_PORTAL_NAME_LEN]; CHAR
	// Address[MAX_ISCSI_PORTAL_ADDRESS_LEN]; USHORT Socket; } ISCSI_TARGET_PORTAL_INFOA, *PISCSI_TARGET_PORTAL_INFOA;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ISCSI_TARGET_PORTAL_INFO
	{
		/// <summary>A string representing the name of the Host-Bus Adapter initiator.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_HBANAME_LEN)]
		public string InitiatorName;

		/// <summary>
		/// The port number on the Host-Bus Adapter (HBA) associated with the portal. This port number corresponds to the source IP
		/// address on the HBA
		/// </summary>
		public uint InitiatorPortNumber;

		/// <summary>A string representing the symbolic name of the portal.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_PORTAL_NAME_LEN)]
		public string SymbolicName;

		/// <summary>A string representing the IP address or DNS name of the portal.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_PORTAL_ADDRESS_LEN)]
		public string Address;

		/// <summary>The socket number.</summary>
		public ushort Socket;
	}

	/// <summary>The <c>ISCSI_TARGET_PORTAL_INFO_EX</c> structure contains information about login credentials to a target portal.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines ISCSI_TARGET_PORTAL_INFO_EX as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_target_portal_info_exa typedef struct { CHAR
	// InitiatorName[MAX_ISCSI_HBANAME_LEN]; ULONG InitiatorPortNumber; CHAR SymbolicName[MAX_ISCSI_PORTAL_NAME_LEN]; CHAR
	// Address[MAX_ISCSI_PORTAL_ADDRESS_LEN]; USHORT Socket; ISCSI_SECURITY_FLAGS SecurityFlags; ISCSI_LOGIN_OPTIONS LoginOptions; }
	// ISCSI_TARGET_PORTAL_INFO_EXA, *PISCSI_TARGET_PORTAL_INFO_EXA;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_11")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ISCSI_TARGET_PORTAL_INFO_EX
	{
		/// <summary>A string that represents the name of the Host-Bus Adapter (HBA) initiator.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_HBANAME_LEN)]
		public string InitiatorName;

		/// <summary>A <c>ULONG</c> value that represents the port number on the HBA associated with the portal.</summary>
		public uint InitiatorPortNumber;

		/// <summary>A string that represents the symbolic name associated with the portal.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_PORTAL_NAME_LEN)]
		public string SymbolicName;

		/// <summary>A string that represents the IP address or DNS name associated with the portal.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_PORTAL_ADDRESS_LEN)]
		public string Address;

		/// <summary>A <c>USHORT</c> value that represents the socket number.</summary>
		public ushort Socket;

		/// <summary>
		/// <para>
		/// A pointer to an <c>ISCSI_SECURITY_FLAGS</c> structure that contains a bitmap that defines the security charactaristics of a
		/// login connection.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED</term>
		/// <term>
		/// When set to 1, the initiator should make the connection in IPsec tunnel mode. Caller should set this flag or the
		/// ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED flag, but not both.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED</term>
		/// <term>
		/// When set to 1, the initiator should make the connection in IPsec transport mode. Caller should set this flag or the
		/// ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED flag, but not both.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_PFS_ENABLED</term>
		/// <term>
		/// When set to 1, the initiator should make the connection with Perfect Forward Secrecy (PFS) mode enabled; otherwise, the
		/// initiator should make the connection with PFS mode disabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED</term>
		/// <term>
		/// When set to 1, the initiator should make the connection with aggressive mode enabled. Caller should set this flag or the
		/// ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED flag, but not both.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED</term>
		/// <term>
		/// When set to 1, the initiator should make the connection with main mode enabled. Caller should set this flag or the
		/// ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED flag, but not both.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED</term>
		/// <term>
		/// When set to 1, the initiator should make the connection with the IKE/IPsec protocol enabled; otherwise, the IKE/IPsec
		/// protocol is disabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_VALID</term>
		/// <term>
		/// When set to 1, the other mask values are valid; otherwise, the iSCSI initiator service will use bitmap values that were
		/// previously defined for the target portal, or if none are available, the initiator service uses the default values defined in
		/// the registry.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ISCSI_SECURITY_FLAGS SecurityFlags;

		/// <summary>A pointer to an ISCSI_LOGIN_OPTIONS structure that defines the login data.</summary>
		public ISCSI_LOGIN_OPTIONS LoginOptions;
	}

	/// <summary>The <c>ISCSI_UNIQUE_SESSION_ID</c> structure is an opaque entity that contains data that uniquely identifies a session.</summary>
	/// <remarks>
	/// The <c>ISCSI_UNIQUE_CONNECTION_ID</c> is an alias for <c>ISCSI_UNIQUE_SESSION_ID</c>. The <c>ISCSI_UNIQUE_CONNECTION_ID</c>
	/// structure is an opaque entity that contains data that uniquely identifies a connection.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_unique_session_id typedef struct
	// _ISCSI_UNIQUE_SESSION_ID { ULONGLONG AdapterUnique; ULONGLONG AdapterSpecific; } ISCSI_UNIQUE_SESSION_ID,
	// *PISCSI_UNIQUE_SESSION_ID, ISCSI_UNIQUE_CONNECTION_ID, *PISCSI_UNIQUE_CONNECTION_ID;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc._ISCSI_UNIQUE_SESSION_ID")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ISCSI_UNIQUE_SESSION_ID
	{
		/// <summary/>
		public ulong AdapterUnique;

		/// <summary/>
		public ulong AdapterSpecific;
	}

	/// <summary>
	/// The <c>ISCSI_VERSION_INFO</c> structure contains the version and build numbers of the iSCSI software initiator and the initiator service.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-iscsi_version_info typedef struct { ULONG MajorVersion;
	// ULONG MinorVersion; ULONG BuildNumber; } ISCSI_VERSION_INFO, *PISCSI_VERSION_INFO;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_24")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ISCSI_VERSION_INFO
	{
		/// <summary>
		/// The major version number of the iSCSI software initiator and initiator service. This may be different from the version
		/// number of the Operating System.
		/// </summary>
		public uint MajorVersion;

		/// <summary>
		/// The minor version number of the iSCSI software initiator and initiator service. This may be different from the version
		/// number of the Operating System.
		/// </summary>
		public uint MinorVersion;

		/// <summary>
		/// The build number of the iSCSI software initiator and initiator service. This may be different from the build number of the
		/// Operating System.
		/// </summary>
		public uint BuildNumber;
	}

	/// <summary>
	/// The <c>PERSISTENT_ISCSI_LOGIN_INFO</c> structure contains information that describes a login session established by the
	/// Microsoft iSCSI initiator service after the machine boots up.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>PERSISTENT_ISCSI_LOGIN_INFO</c> structure is used in conjunction with the ReportIScsiPersistentLogins function to
	/// retrieve the list of targets for which the Microsoft Discovery Service (iscsiexe.exe) automatically opens a login session after
	/// the machine boots up.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The iscsidsc.h header defines PERSISTENT_ISCSI_LOGIN_INFO as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-persistent_iscsi_login_infoa typedef struct { CHAR
	// TargetName[MAX_ISCSI_NAME_LEN + 1]; BOOLEAN IsInformationalSession; CHAR InitiatorInstance[MAX_ISCSI_HBANAME_LEN]; ULONG
	// InitiatorPortNumber; ISCSI_TARGET_PORTALA TargetPortal; ISCSI_SECURITY_FLAGS SecurityFlags; PISCSI_TARGET_MAPPINGA Mappings;
	// ISCSI_LOGIN_OPTIONS LoginOptions; } PERSISTENT_ISCSI_LOGIN_INFOA, *PPERSISTENT_ISCSI_LOGIN_INFOA;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_23")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERSISTENT_ISCSI_LOGIN_INFO
	{
		/// <summary>A string representing the name of the target the initiator will login to.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_NAME_LEN + 1)]
		public string TargetName;

		/// <summary>
		/// <para>
		/// If set <c>TRUE</c>, the login session is for informational purposes only and will not result in the enumeration of the
		/// specified target on the local computer. For an informational login session, the LUNs on the target are not reported to the
		/// Plug and Play Manager and the device drivers for the target are not loaded.
		/// </para>
		/// <para>
		/// A management application can still access targets not enumerated by the system via the SendScsiInquiry, SendScsiReportLuns,
		/// and SendScsiReadCapcity functions.
		/// </para>
		/// <para>If set <c>FALSE</c>, the LUNs on the target are reported to the Plug and Play manager for enumeration.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool IsInformationalSession;

		/// <summary>A string representing the name of the initiator used to login to the target.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ISCSI_HBANAME_LEN)]
		public string InitiatorInstance;

		/// <summary>
		/// The port number of the Host-Bus Adapter (HBA) through which the session login is established. A value of
		/// <c>ISCSI_ANY_INITIATOR_PORT</c> indicates that a port on the initiator is not currently specified.
		/// </summary>
		public uint InitiatorPortNumber;

		/// <summary>
		/// A ISCSI_TARGET_PORTAL structure that describes the portal used by the Microsoft iSCSI initiator service to log on to the target.
		/// </summary>
		public ISCSI_TARGET_PORTAL TargetPortal;

		/// <summary>
		/// <para>A bitmap that defines the security characteristics of a login connection.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_TUNNEL_MODE_PREFERRED</term>
		/// <term>
		/// The Host Bus Adapter (HBA) initiator should establish the TCP/IP connection to the target portal using IPsec tunnel mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_TRANSPORT_MODE_PREFERRED</term>
		/// <term>The HBA initiator should establish the TCP/IP connection to the target portal using IPsec transport mode.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_PFS_ENABLED</term>
		/// <term>
		/// The HBA initiator should establish the TCP/IP connection to the target portal with Perfect Forward Secrecy (PFS) mode
		/// enabled if IPsec is required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_AGGRESSIVE_MODE_ENABLED</term>
		/// <term>The HBA initiator should establish the TCP/IP connection to the target portal with aggressive mode enabled.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_MAIN_MODE_ENABLED</term>
		/// <term>The HBA initiator should establish the TCP/IP connection to the target portal with main mode enabled.</term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_IKE_IPSEC_ENABLED</term>
		/// <term>
		/// The HBA initiator should establish the TCP/IP connection to the target portal using IKE/IPsec protocol. If not set then
		/// IPsec is not required to login to the target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISCSI_SECURITY_FLAG_VALID</term>
		/// <term>The other mask values are valid; otherwise, security flags are not specified.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ISCSI_SECURITY_FLAGS SecurityFlags;

		/// <summary>
		/// A pointer to a <see cref="ISCSI_TARGET_MAPPING"/> structure that contains information about a target, its logical units,
		/// HBAs, and buses through which it is reached.
		/// </summary>
		public IntPtr Mappings;

		/// <summary>An ISCSI_LOGIN_OPTIONS structure that contains the persistent login characteristics.</summary>
		public ISCSI_LOGIN_OPTIONS LoginOptions;
	}

	/// <summary>
	/// <para>
	/// The SCSI_ADDRESS structure is used in conjunction with the IOCTL_SCSI_GET_ADDRESS request to retrieve the address information,
	/// such as the target ID (TID) and the logical unit number (LUN) of a particular SCSI target.
	/// </para>
	/// <para>
	/// <c>Note</c> The SCSI port driver and SCSI miniport driver models may be altered or unavailable in the future. Instead, we
	/// recommend using the Storport driver and Storport miniport driver models.
	/// </para>
	/// </summary>
	/// <remarks>
	/// Legacy class drivers issue the IOCTL_SCSI_GET_ADDRESS request to the port driver to obtain the address of their devices.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntddscsi/ns-ntddscsi-_scsi_address typedef struct _SCSI_ADDRESS {
	// ULONG Length; UCHAR PortNumber; UCHAR PathId; UCHAR TargetId; UCHAR Lun; } SCSI_ADDRESS, *PSCSI_ADDRESS;
	[PInvokeData("ntddscsi.h", MSDNShortId = "NS:ntddscsi._SCSI_ADDRESS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SCSI_ADDRESS
	{
		/// <summary>Contains the length of this structure in bytes.</summary>
		public uint Length;

		/// <summary>Contains the number of the SCSI adapter.</summary>
		public byte PortNumber;

		/// <summary>Contains the number of the bus.</summary>
		public byte PathId;

		/// <summary>Contains the number of the target device.</summary>
		public byte TargetId;

		/// <summary>Contains the logical unit number.</summary>
		public byte Lun;
	}

	/// <summary>
	/// The <c>SCSI_LUN_LIST</c> structure is used to construct a list of logical unit numbers (LUNs) associated with target devices.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iscsidsc/ns-iscsidsc-scsi_lun_list typedef struct { ULONG OSLUN; ULONGLONG
	// TargetLUN; } SCSI_LUN_LIST, *PSCSI_LUN_LIST;
	[PInvokeData("iscsidsc.h", MSDNShortId = "NS:iscsidsc.__unnamed_struct_3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCSI_LUN_LIST
	{
		/// <summary>
		/// The LUN assigned by the operating system to the target device when it was enumerated by the initiator Host Bus Adapter (HBA).
		/// </summary>
		public uint OSLUN;

		/// <summary>The LUN assigned by the target subsystem to the target device.</summary>
		public ulong TargetLUN;
	}

	/// <summary>Contains information about a device. This structure is used by the IOCTL_STORAGE_GET_DEVICE_NUMBER control code.</summary>
	/// <remarks>
	/// The values in the <c>STORAGE_DEVICE_NUMBER</c> structure are guaranteed to remain unchanged until the device is removed or the
	/// system is restarted. They are not guaranteed to be persistent across device or system restarts.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_device_number typedef struct
	// _STORAGE_DEVICE_NUMBER { DEVICE_TYPE DeviceType; DWORD DeviceNumber; DWORD PartitionNumber; } STORAGE_DEVICE_NUMBER, *PSTORAGE_DEVICE_NUMBER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_DEVICE_NUMBER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_NUMBER
	{
		/// <summary>
		/// <para>
		/// The type of device. Values from 0 through 32,767 are reserved for use by Microsoft. Values from 32,768 through 65,535 are
		/// reserved for use by other vendors. The following values are defined by Microsoft:
		/// </para>
		/// <para>FILE_DEVICE_8042_PORT</para>
		/// <para>FILE_DEVICE_ACPI</para>
		/// <para>FILE_DEVICE_BATTERY</para>
		/// <para>FILE_DEVICE_BEEP</para>
		/// <para>FILE_DEVICE_BLUETOOTH</para>
		/// <para>FILE_DEVICE_BUS_EXTENDER</para>
		/// <para>FILE_DEVICE_CD_ROM</para>
		/// <para>FILE_DEVICE_CD_ROM_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_CHANGER</para>
		/// <para>FILE_DEVICE_CONTROLLER</para>
		/// <para>FILE_DEVICE_CRYPT_PROVIDER</para>
		/// <para>FILE_DEVICE_DATALINK</para>
		/// <para>FILE_DEVICE_DFS</para>
		/// <para>FILE_DEVICE_DFS_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_DFS_VOLUME</para>
		/// <para>FILE_DEVICE_DISK</para>
		/// <para>FILE_DEVICE_DISK_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_DVD</para>
		/// <para>FILE_DEVICE_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_FIPS</para>
		/// <para>FILE_DEVICE_FULLSCREEN_VIDEO</para>
		/// <para>FILE_DEVICE_INFINIBAND</para>
		/// <para>FILE_DEVICE_INPORT_PORT</para>
		/// <para>FILE_DEVICE_KEYBOARD</para>
		/// <para>FILE_DEVICE_KS</para>
		/// <para>FILE_DEVICE_KSEC</para>
		/// <para>FILE_DEVICE_MAILSLOT</para>
		/// <para>FILE_DEVICE_MASS_STORAGE</para>
		/// <para>FILE_DEVICE_MIDI_IN</para>
		/// <para>FILE_DEVICE_MIDI_OUT</para>
		/// <para>FILE_DEVICE_MODEM</para>
		/// <para>FILE_DEVICE_MOUSE</para>
		/// <para>FILE_DEVICE_MULTI_UNC_PROVIDER</para>
		/// <para>FILE_DEVICE_NAMED_PIPE</para>
		/// <para>FILE_DEVICE_NETWORK</para>
		/// <para>FILE_DEVICE_NETWORK_BROWSER</para>
		/// <para>FILE_DEVICE_NETWORK_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_NETWORK_REDIRECTOR</para>
		/// <para>FILE_DEVICE_NULL</para>
		/// <para>FILE_DEVICE_PARALLEL_PORT</para>
		/// <para>FILE_DEVICE_PHYSICAL_NETCARD</para>
		/// <para>FILE_DEVICE_PRINTER</para>
		/// <para>FILE_DEVICE_SCANNER</para>
		/// <para>FILE_DEVICE_SCREEN</para>
		/// <para>FILE_DEVICE_SERENUM</para>
		/// <para>FILE_DEVICE_SERIAL_MOUSE_PORT</para>
		/// <para>FILE_DEVICE_SERIAL_PORT</para>
		/// <para>FILE_DEVICE_SMARTCARD</para>
		/// <para>FILE_DEVICE_SMB</para>
		/// <para>FILE_DEVICE_SOUND</para>
		/// <para>FILE_DEVICE_STREAMS</para>
		/// <para>FILE_DEVICE_TAPE</para>
		/// <para>FILE_DEVICE_TAPE_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_TERMSRV</para>
		/// <para>FILE_DEVICE_TRANSPORT</para>
		/// <para>FILE_DEVICE_UNKNOWN</para>
		/// <para>FILE_DEVICE_VDM</para>
		/// <para>FILE_DEVICE_VIDEO</para>
		/// <para>FILE_DEVICE_VIRTUAL_DISK</para>
		/// <para>FILE_DEVICE_VMBUS</para>
		/// <para>FILE_DEVICE_WAVE_IN</para>
		/// <para>FILE_DEVICE_WAVE_OUT</para>
		/// <para>FILE_DEVICE_WPD</para>
		/// </summary>
		public DEVICE_TYPE DeviceType;

		/// <summary>The number of this device.</summary>
		public uint DeviceNumber;

		/// <summary>The partition number of the device, if the device can be partitioned. Otherwise, this member is –1.</summary>
		public uint PartitionNumber;
	}
}