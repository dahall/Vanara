using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Functions, enumerations and structures found in ADVAPI32.DLL.</summary>
	public static partial class AdvApi32
	{
		/// <summary>Flags that describe the password properties.</summary>
		[PInvokeData("ntsecapi.h", MSDNShortId = "7dceaf70-d8de-47c0-b940-f0d6a0cca101")]
		[Flags]
		public enum DOMAIN_PASSWORD : uint
		{
			/// <summary>
			/// The password must have a mix of at least two of the following types of characters:
			/// <list type="bullet">
			/// <item>Uppercase characters</item>
			/// <item>Lowercase characters</item>
			/// <item>Numerals</item>
			/// </list>
			/// </summary>
			DOMAIN_PASSWORD_COMPLEX = 0x00000001,

			/// <summary>
			/// The password cannot be changed without logging on. Otherwise, if your password has expired, you can change your password and
			/// then log on.
			/// </summary>
			DOMAIN_PASSWORD_NO_ANON_CHANGE = 0x00000002,

			/// <summary>Forces the client to use a protocol that does not allow the domain controller to get the plaintext password.</summary>
			DOMAIN_PASSWORD_NO_CLEAR_CHANGE = 0x00000004,

			/// <summary>Allows the built-in administrator account to be locked out from network logons.</summary>
			DOMAIN_LOCKOUT_ADMINS = 0x00000008,

			/// <summary>The directory service is storing a plaintext password for all users instead of a hash function of the password.</summary>
			DOMAIN_PASSWORD_STORE_CLEARTEXT = 0x00000010,

			/// <summary>
			/// Removes the requirement that the machine account password be automatically changed every week.
			/// <para>This value should not be used as it can weaken security.</para>
			/// </summary>
			DOMAIN_REFUSE_PASSWORD_CHANGE = 0x00000020,

			/// <summary/>
			DOMAIN_NO_LM_OWF_CHANGE = 0x00000040
		}

		/// <summary>Auditing options for an audit event type.</summary>
		[PInvokeData("ntsecapi.h")]
		[Flags]
		public enum POLICY_AUDIT_EVENT_OPTIONS : uint
		{
			/// <summary>
			/// Do not change auditing options for the specified event type.
			/// <para>This value is valid for the AuditSetSystemPolicy and AuditQuerySystemPolicy functions.</para>
			/// </summary>
			POLICY_AUDIT_EVENT_UNCHANGED = 0x00000000,

			/// <summary>
			/// Audit successful occurrences of the specified event type.
			/// <para>This value is valid for the AuditSetSystemPolicy and AuditQuerySystemPolicy functions.</para>
			/// </summary>
			POLICY_AUDIT_EVENT_SUCCESS = 0x00000001,

			/// <summary>
			/// Audit failed attempts to cause the specified event type.
			/// <para>This value is valid for the AuditSetSystemPolicy and AuditQuerySystemPolicy functions.</para>
			/// </summary>
			POLICY_AUDIT_EVENT_FAILURE = 0x00000002,

			/// <summary>
			/// Do not audit the specified event type.
			/// <para>This value is valid for the AuditSetSystemPolicy and AuditQuerySystemPolicy functions.</para>
			/// </summary>
			POLICY_AUDIT_EVENT_NONE = 0x00000004,
		}

		/// <summary>The <c>POLICY_DOMAIN_INFORMATION_CLASS</c> enumeration defines the type of policy domain information.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-_policy_domain_information_class typedef enum
		// _POLICY_DOMAIN_INFORMATION_CLASS { PolicyDomainQualityOfServiceInformation, PolicyDomainEfsInformation,
		// PolicyDomainKerberosTicketInformation } POLICY_DOMAIN_INFORMATION_CLASS, *PPOLICY_DOMAIN_INFORMATION_CLASS;
		[PInvokeData("ntsecapi.h", MSDNShortId = "b208c479-a262-4120-824f-677ead1ef61a")]
		public enum POLICY_DOMAIN_INFORMATION_CLASS
		{
			/// <summary/>
			[CorrespondingType(typeof(POLICY_DOMAIN_QUALITY_OF_SERVICE_INFO), CorrespondingAction.Set)]
			PolicyDomainQualityOfServiceInformation = 1,

			/// <summary>The information is for Encrypting File System.</summary>
			[CorrespondingType(typeof(POLICY_DOMAIN_EFS_INFO))]
			PolicyDomainEfsInformation,

			/// <summary>The information is for a Kerberos ticket.</summary>
			[CorrespondingType(typeof(POLICY_DOMAIN_KERBEROS_TICKET_INFO))]
			PolicyDomainKerberosTicketInformation,
		}

		/// <summary>
		/// The <c>POLICY_INFORMATION_CLASS</c> enumeration defines values that indicate the type of information to set or query in a Policy object.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-_policy_information_class typedef enum
		// _POLICY_INFORMATION_CLASS { PolicyAuditLogInformation, PolicyAuditEventsInformation, PolicyPrimaryDomainInformation,
		// PolicyPdAccountInformation, PolicyAccountDomainInformation, PolicyLsaServerRoleInformation, PolicyReplicaSourceInformation,
		// PolicyDefaultQuotaInformation, PolicyModificationInformation, PolicyAuditFullSetInformation, PolicyAuditFullQueryInformation,
		// PolicyDnsDomainInformation, PolicyDnsDomainInformationInt, PolicyLocalAccountDomainInformation, PolicyMachineAccountInformation,
		// PolicyLastEntry } POLICY_INFORMATION_CLASS, *PPOLICY_INFORMATION_CLASS;
		[PInvokeData("ntsecapi.h", MSDNShortId = "b734b5e8-1ee9-436b-b2a9-210ae79fbaf5")]
		public enum POLICY_INFORMATION_CLASS
		{
			/// <summary>This value is obsolete.</summary>
			[Obsolete]
			PolicyAuditLogInformation = 1,

			/// <summary>
			/// Query or set the auditing rules of the system. You can enable or disable auditing and specify the types of events that are
			/// audited. Use the POLICY_AUDIT_EVENTS_INFO structure.
			/// </summary>
			[CorrespondingType(typeof(POLICY_AUDIT_EVENTS_INFO))]
			PolicyAuditEventsInformation,

			/// <summary>This value is obsolete. Use the PolicyDnsDomainInformation value instead.</summary>
			[Obsolete]
			PolicyPrimaryDomainInformation,

			/// <summary>This value is obsolete.</summary>
			[Obsolete]
			PolicyPdAccountInformation,

			/// <summary>Query or set the name and SID of the account domain of the system. Use the POLICY_ACCOUNT_DOMAIN_INFO structure.</summary>
			[CorrespondingType(typeof(POLICY_ACCOUNT_DOMAIN_INFO))]
			PolicyAccountDomainInformation,

			/// <summary>Query or set the role of an LSA server. Use the POLICY_LSA_SERVER_ROLE_INFO structure.</summary>
			[CorrespondingType(typeof(POLICY_LSA_SERVER_ROLE_INFO))]
			PolicyLsaServerRoleInformation,

			/// <summary>This value is obsolete.</summary>
			[Obsolete]
			PolicyReplicaSourceInformation,

			/// <summary>This value is obsolete.</summary>
			[Obsolete]
			PolicyDefaultQuotaInformation,

			/// <summary>
			/// Query or set information about the creation time and last modification of the LSA database. Use the POLICY_MODIFICATION_INFO structure.
			/// </summary>
			[CorrespondingType(typeof(POLICY_MODIFICATION_INFO))]
			PolicyModificationInformation,

			/// <summary>This value is obsolete.</summary>
			[Obsolete]
			PolicyAuditFullSetInformation,

			/// <summary>This value is obsolete.</summary>
			[Obsolete]
			PolicyAuditFullQueryInformation,

			/// <summary>
			/// Query or set Domain Name System (DNS) information about the account domain associated with a Policy object. Use the
			/// POLICY_DNS_DOMAIN_INFO structure.
			/// </summary>
			[CorrespondingType(typeof(POLICY_DNS_DOMAIN_INFO))]
			PolicyDnsDomainInformation,

			/// <summary/>
			PolicyDnsDomainInformationInt,

			/// <summary/>
			PolicyLocalAccountDomainInformation,

			/// <summary/>
			PolicyMachineAccountInformation,
		}

		/// <summary>
		/// The <c>POLICY_LSA_SERVER_ROLE</c> enumeration type defines values that indicate the role of an LSA server. The
		/// LsaQueryInformationPolicy and LsaSetInformationPolicy functions use this enumeration type when their InformationClass parameters
		/// are set to <c>PolicyLsaServerRoleInformation</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-policy_lsa_server_role typedef enum
		// _POLICY_LSA_SERVER_ROLE { PolicyServerRoleBackup, PolicyServerRolePrimary } POLICY_LSA_SERVER_ROLE, *PPOLICY_LSA_SERVER_ROLE;
		[PInvokeData("ntsecapi.h", MSDNShortId = "a2bcc380-8873-436b-a0d6-e4deb23669bb")]
		public enum POLICY_LSA_SERVER_ROLE
		{
			/// <summary>Indicates a backup LSA server.</summary>
			PolicyServerRoleBackup = 2,

			/// <summary>Indicates a primary LSA server, a workstation, or a standalone computer.</summary>
			PolicyServerRolePrimary,
		}

		/// <summary>[Undocumented] Used by POLICY_DOMAIN_QUALITY_OF_SERVICE_INFO.</summary>
		[PInvokeData("ntsecapi.h")]
		public enum POLICY_QOS : uint
		{
			POLICY_QOS_SCHANNEL_REQUIRED = 0x00000001,
			POLICY_QOS_OUTBOUND_INTEGRITY = 0x00000002,
			POLICY_QOS_OUTBOUND_CONFIDENTIALITY = 0x00000004,
			POLICY_QOS_INBOUND_INTEGRITY = 0x00000008,
			POLICY_QOS_INBOUND_CONFIDENTIALITY = 0x00000010,
			POLICY_QOS_ALLOW_LOCAL_ROOT_CERT_STORE = 0x00000020,
			POLICY_QOS_RAS_SERVER_ALLOWED = 0x00000040,
			POLICY_QOS_DHCP_SERVER_ALLOWED = 0x00000080,
		}

		/// <summary>
		/// The <c>POLICY_SERVER_ENABLE_STATE</c> enumeration represents the state of the LSA server—that is, whether it is enabled or
		/// disabled. Some operations may only be performed on an enabled LSA server.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-policy_server_enable_state typedef enum
		// _POLICY_SERVER_ENABLE_STATE { PolicyServerEnabled, PolicyServerDisabled } POLICY_SERVER_ENABLE_STATE, *PPOLICY_SERVER_ENABLE_STATE;
		[PInvokeData("ntsecapi.h", MSDNShortId = "aae5875e-ca55-4571-a9a4-684280ae8aa0")]
		public enum POLICY_SERVER_ENABLE_STATE
		{
			/// <summary>The LSA server is enabled.</summary>
			PolicyServerEnabled = 2,

			/// <summary>The LSA server is disabled.</summary>
			PolicyServerDisabled,
		}

		/// <summary>
		/// Specifies one of the following values to indicate the type of authentication information in the <c>AuthInfo</c> buffer.
		/// </summary>
		public enum TRUST_AUTH_TYPE
		{
			/// <summary>The format is unknown and will be ignored.</summary>
			TRUST_AUTH_TYPE_NONE = 0,

			/// <summary>
			/// The Windows NT 4.0 one-way format (OWF) of a plaintext password. Note that you cannot derive the clear password back from the
			/// OWF form of the password. The system sets this information.
			/// </summary>
			TRUST_AUTH_TYPE_NT4OWF = 1,

			/// <summary>Plaintext password to use for the trust.</summary>
			TRUST_AUTH_TYPE_CLEAR = 2,

			/// <summary>Plaintext password version number.</summary>
			TRUST_AUTH_TYPE_VERSION = 3,
		}

		/// <summary>Indicates the attributes of a trust relationship.</summary>
		[PInvokeData("ntsecapi.h", MSDNShortId = "acf9a2b5-f301-4e6a-a515-df338658ad56")]
		[Flags]
		public enum TrustAttributes : uint
		{
			/// <summary>Disallow transitivity.</summary>
			TRUST_ATTRIBUTE_NON_TRANSITIVE = 0x00000001,

			/// <summary>The trust link is not valid for client operating systems earlier than Windows 2000.</summary>
			TRUST_ATTRIBUTE_UPLEVEL_ONLY = 0x00000002,

			/// <summary>Undocumented.</summary>
			TRUST_ATTRIBUTE_TREE_PARENT = 0x00400000,

			/// <summary>Undocumented.</summary>
			TRUST_ATTRIBUTE_TREE_ROOT = 0x00800000,

			/// <summary>Quarantine domains.</summary>
			TRUST_ATTRIBUTE_FILTER_SIDS = 0x00000004,

			/// <summary>The trust link may contain forest trust information.</summary>
			TRUST_ATTRIBUTE_FOREST_TRANSITIVE = 0x00000008,

			/// <summary>This trust is to a domain/forest that is not part of this enterprise.</summary>
			TRUST_ATTRIBUTE_CROSS_ORGANIZATION = 0x00000010,

			/// <summary>Trust is internal to this forest.</summary>
			TRUST_ATTRIBUTE_WITHIN_FOREST = 0x00000020,

			/// <summary>Trust is treated as external for trust boundary purposes.</summary>
			TRUST_ATTRIBUTE_TREAT_AS_EXTERNAL = 0x00000040,

			/// <summary>Undocumented.</summary>
			TRUST_ATTRIBUTE_TRUST_USES_RC4_ENCRYPTION = 0x00000080,

			/// <summary>Undocumented.</summary>
			TRUST_ATTRIBUTE_TRUST_USES_AES_KEYS = 0x00000100,

			/// <summary>Undocumented.</summary>
			TRUST_ATTRIBUTE_CROSS_ORGANIZATION_NO_TGT_DELEGATION = 0x00000200,

			/// <summary>Undocumented.</summary>
			TRUST_ATTRIBUTE_PIM_TRUST = 0x00000400,
		}

		/// <summary>Indicates the direction of the trust.</summary>
		[PInvokeData("ntsecapi.h", MSDNShortId = "acf9a2b5-f301-4e6a-a515-df338658ad56")]
		public enum TrustDirection : uint
		{
			/// <summary>The trust relationship exists, but it has been disabled.</summary>
			TRUST_DIRECTION_DISABLED = 0x00000000,

			/// <summary>The trusted domain trusts the primary domain to perform operations such as name lookups and authentication.</summary>
			TRUST_DIRECTION_INBOUND = 0x00000001,

			/// <summary>The primary domain trusts the trusted domain to perform operations such as name lookups and authentication.</summary>
			TRUST_DIRECTION_OUTBOUND = 0x00000002,

			/// <summary>Both domains trust each other.</summary>
			TRUST_DIRECTION_BIDIRECTIONAL = TRUST_DIRECTION_INBOUND | TRUST_DIRECTION_OUTBOUND
		}

		/// <summary>
		/// <para>
		/// The <c>TRUSTED_INFORMATION_CLASS</c> enumeration type defines values that indicate the type of information to set or query for a
		/// trusted domain.
		/// </para>
		/// <para>
		/// Each value has an associated structure that the LsaQueryTrustedDomainInfo and LsaSetTrustedDomainInformation functions use to
		/// store the information.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-_trusted_information_class typedef enum
		// _TRUSTED_INFORMATION_CLASS { TrustedDomainNameInformation , TrustedControllersInformation , TrustedPosixOffsetInformation ,
		// TrustedPasswordInformation , TrustedDomainInformationBasic , TrustedDomainInformationEx , TrustedDomainAuthInformation ,
		// TrustedDomainFullInformation , TrustedDomainAuthInformationInternal , TrustedDomainFullInformationInternal ,
		// TrustedDomainInformationEx2Internal , TrustedDomainFullInformation2Internal , TrustedDomainSupportedEncryptionTypes }
		// TRUSTED_INFORMATION_CLASS, *PTRUSTED_INFORMATION_CLASS;
		[PInvokeData("ntsecapi.h", MSDNShortId = "442a0944-b498-4d9f-b338-d5aed1663d8d")]
		public enum TRUSTED_INFORMATION_CLASS
		{
			/// <summary>Query or set the name of a trusted domain. Use the TRUSTED_DOMAIN_NAME_INFO structure.</summary>
			[CorrespondingType(typeof(TRUSTED_DOMAIN_NAME_INFO))]
			TrustedDomainNameInformation = 1,

			/// <summary>This value is obsolete.</summary>
			TrustedControllersInformation,

			/// <summary>
			/// Query or set the value used to generate Posix user and group identifiers. Use the TRUSTED_POSIX_OFFSET_INFO structure.
			/// </summary>
			[CorrespondingType(typeof(TRUSTED_POSIX_OFFSET_INFO))]
			TrustedPosixOffsetInformation,

			/// <summary>This value has been superseded by the TrustedDomainAuthInformation value.</summary>
			[CorrespondingType(typeof(TRUSTED_PASSWORD_INFO))]
			TrustedPasswordInformation,

			/// <summary>This value is obsolete.</summary>
			TrustedDomainInformationBasic,

			/// <summary>Query extended information for a trusted domain. Use the TRUSTED_DOMAIN_INFORMATION_EX structure.</summary>
			[CorrespondingType(typeof(TRUSTED_DOMAIN_INFORMATION_EX), CorrespondingAction.Get)]
			TrustedDomainInformationEx,

			/// <summary>Query authentication information for a trusted domain. Use the TRUSTED_DOMAIN_AUTH_INFORMATION structure.</summary>
			[CorrespondingType(typeof(TRUSTED_DOMAIN_AUTH_INFORMATION), CorrespondingAction.Get)]
			TrustedDomainAuthInformation,

			/// <summary>
			/// Query complete information for a trusted domain. This information includes the Posix offset information, authentication
			/// information, and the extended information returned for the TrustedDomainInformationEx value. Use the
			/// TRUSTED_DOMAIN_FULL_INFORMATION structure.
			/// </summary>
			[CorrespondingType(typeof(TRUSTED_DOMAIN_FULL_INFORMATION), CorrespondingAction.Get)]
			TrustedDomainFullInformation,
		}

		/// <summary>Indicates the type of the trust relationship.</summary>
		[PInvokeData("ntsecapi.h", MSDNShortId = "acf9a2b5-f301-4e6a-a515-df338658ad56")]
		public enum TrustType : uint
		{
			/// <summary>The domain controller of the trusted domain is a computer running an operating system earlier than Windows 2000.</summary>
			TRUST_TYPE_DOWNLEVEL = 0x00000001,

			/// <summary>The domain controller of the Microsoft trusted domain is a computer running Windows 2000 or later.</summary>
			TRUST_TYPE_UPLEVEL = 0x00000002,

			/// <summary>The trusted domain is an MIT Kerberos realm.</summary>
			TRUST_TYPE_MIT = 0x00000003,

			/// <summary>The trusted domain is a DCE realm.</summary>
			TRUST_TYPE_DCE = 0x00000004,
		}

		/// <summary>
		/// <para>
		/// The <c>DOMAIN_PASSWORD_INFORMATION</c> structure contains information about a domain's password policy, such as the minimum
		/// length for passwords and how unique passwords must be.
		/// </para>
		/// <para>It is used in the MSV1_0_CHANGEPASSWORD_RESPONSE structure.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-domain_password_information typedef struct
		// _DOMAIN_PASSWORD_INFORMATION { USHORT MinPasswordLength; USHORT PasswordHistoryLength; ULONG PasswordProperties; #if ...
		// OLD_LARGE_INTEGER MaxPasswordAge; #elif OLD_LARGE_INTEGER MaxPasswordAge; #if ... OLD_LARGE_INTEGER MinPasswordAge; #elif
		// OLD_LARGE_INTEGER MinPasswordAge; #elif LARGE_INTEGER MaxPasswordAge; #else LARGE_INTEGER MaxPasswordAge; #endif #elif
		// LARGE_INTEGER MinPasswordAge; #else LARGE_INTEGER MinPasswordAge; #endif } DOMAIN_PASSWORD_INFORMATION, *PDOMAIN_PASSWORD_INFORMATION;
		[PInvokeData("ntsecapi.h", MSDNShortId = "7dceaf70-d8de-47c0-b940-f0d6a0cca101")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DOMAIN_PASSWORD_INFORMATION
		{
			/// <summary>Specifies the minimum length, in characters, of a valid password.</summary>
			public ushort MinPasswordLength;

			/// <summary>
			/// Indicates the number of previous passwords saved in the history list. A user cannot reuse a password in the history list.
			/// </summary>
			public ushort PasswordHistoryLength;

			/// <summary>
			/// <para>Flags that describe the password properties. They can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DOMAIN_PASSWORD_COMPLEX 0x00000001L</term>
			/// <term>The password must have a mix of at least two of the following types of characters:</term>
			/// </item>
			/// <item>
			/// <term>DOMAIN_PASSWORD_NO_ANON_CHANGE 0x00000002L</term>
			/// <term>
			/// The password cannot be changed without logging on. Otherwise, if your password has expired, you can change your password and
			/// then log on.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DOMAIN_PASSWORD_NO_CLEAR_CHANGE 0x00000004L</term>
			/// <term>Forces the client to use a protocol that does not allow the domain controller to get the plaintext password.</term>
			/// </item>
			/// <item>
			/// <term>DOMAIN_LOCKOUT_ADMINS 0x00000008L</term>
			/// <term>Allows the built-in administrator account to be locked out from network logons.</term>
			/// </item>
			/// <item>
			/// <term>DOMAIN_PASSWORD_STORE_CLEARTEXT 0x00000010L</term>
			/// <term>The directory service is storing a plaintext password for all users instead of a hash function of the password.</term>
			/// </item>
			/// <item>
			/// <term>DOMAIN_REFUSE_PASSWORD_CHANGE 0x00000020L</term>
			/// <term>
			/// Removes the requirement that the machine account password be automatically changed every week. This value should not be used
			/// as it can weaken security.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint PasswordProperties;

			/// <summary>
			/// A 64-bit value, with delta time syntax, indicating the policy setting for the maximum time allowed before a password reset or
			/// change is required.
			/// </summary>
			public FILETIME MaxPasswordAge;

			/// <summary>
			/// A 64-bit value, with delta time syntax, indicating the policy setting for the minimum time allowed before a password change
			/// operation is allowed.
			/// </summary>
			public FILETIME MinPasswordAge;
		}

		/// <summary>
		/// <para>The <c>LSA_AUTH_INFORMATION</c> structure contains authentication information for a trusted domain.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_auth_information typedef struct
		// _LSA_AUTH_INFORMATION { LARGE_INTEGER LastUpdateTime; ULONG AuthType; ULONG AuthInfoLength; PUCHAR AuthInfo; }
		// LSA_AUTH_INFORMATION, *PLSA_AUTH_INFORMATION;
		[PInvokeData("ntsecapi.h", MSDNShortId = "61c17831-4a82-4766-b5af-e97a6d467462")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_AUTH_INFORMATION
		{
			/// <summary>
			/// A LARGE_INTEGER structure that uses the Coordinated Universal Time (Greenwich Mean Time) format to indicate the time that
			/// this value was set. For more information about Coordinated Universal Time, see the FILETIME structure.
			/// </summary>
			public FILETIME LastUpdateTime;

			/// <summary>
			/// <para>Specifies one of the following values to indicate the type of authentication information in the <c>AuthInfo</c> buffer.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUST_AUTH_TYPE_NONE</term>
			/// <term>The format is unknown and will be ignored.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_AUTH_TYPE_NT4OWF</term>
			/// <term>
			/// The Windows NT 4.0 one-way format (OWF) of a plaintext password. Note that you cannot derive the clear password back from the
			/// OWF form of the password. The system sets this information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>TRUST_AUTH_TYPE_CLEAR</term>
			/// <term>Plaintext password to use for the trust.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_AUTH_TYPE_VERSION</term>
			/// <term>Plaintext password version number.</term>
			/// </item>
			/// </list>
			/// </summary>
			public TRUST_AUTH_TYPE AuthType;

			/// <summary>
			/// <para>Specifies the size, in bytes, of the <c>AuthInfo</c> member.</para>
			/// </summary>
			public uint AuthInfoLength;

			/// <summary>
			/// Pointer to an array of bytes that contains the type of authentication information indicated by the <c>AuthType</c> member.
			/// </summary>
			public IntPtr AuthInfo;
		}

		/// <summary>
		/// The <c>POLICY_ACCOUNT_DOMAIN_INFO</c> structure is used to set and query the name and SID of the system's account domain. The
		/// LsaQueryInformationPolicy and LsaSetInformationPolicy functions use this structure when their InformationClass parameters are set
		/// to <c>PolicyAccountDomainInformation</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/lsalookup/ns-lsalookup-policy_account_domain_info typedef struct
		// _POLICY_ACCOUNT_DOMAIN_INFO { LSA_UNICODE_STRING DomainName; PSID DomainSid; } POLICY_ACCOUNT_DOMAIN_INFO, *PPOLICY_ACCOUNT_DOMAIN_INFO;
		[PInvokeData("lsalookup.h", MSDNShortId = "0e38ac5f-40db-405d-9394-b6bcb7c652b5")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POLICY_ACCOUNT_DOMAIN_INFO
		{
			/// <summary>An LSA_UNICODE_STRING structure that specifies the name of the account domain.</summary>
			public LSA_UNICODE_STRING DomainName;

			/// <summary>Pointer to the SID of the account domain.</summary>
			public PSID DomainSid;
		}

		/// <summary>
		/// The <c>POLICY_AUDIT_EVENTS_INFO</c> structure is used to set and query the system's auditing rules. The LsaQueryInformationPolicy
		/// and LsaSetInformationPolicy functions use this structure when their InformationClass parameters are set to <c>PolicyAuditEventsInformation</c>.
		/// </summary>
		/// <remarks>
		/// LSA Policy defines a mask for the valid event auditing options. The POLICY_AUDIT_EVENT_MASK mask evaluates to <c>TRUE</c> if it
		/// is set equal to any of the preceding event auditing options.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-policy_audit_events_info typedef struct
		// _POLICY_AUDIT_EVENTS_INFO { BOOLEAN AuditingMode; PPOLICY_AUDIT_EVENT_OPTIONS EventAuditingOptions; ULONG MaximumAuditEventCount;
		// } POLICY_AUDIT_EVENTS_INFO, *PPOLICY_AUDIT_EVENTS_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "3442e5e5-78cf-4bda-ba11-0f51ee40df16")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POLICY_AUDIT_EVENTS_INFO : IVanaraMarshaler
		{
			/// <summary>
			/// <para>Indicates whether auditing is enabled.</para>
			/// <para>
			/// If this flag is <c>TRUE</c>, the system generates audit records according to the event auditing options specified in the
			/// <c>EventAuditingOptions</c> member.
			/// </para>
			/// <para>
			/// If this flag is <c>FALSE</c>, the system does not generate audit records. However, note that set operations update the event
			/// auditing options as specified in the <c>EventAuditingOptions</c> member even when <c>AuditingMode</c> is <c>FALSE</c>.
			/// </para>
			/// </summary>
			public BOOLEAN AuditingMode;

			/// <summary>
			/// <para>
			/// Pointer to an array of POLICY_AUDIT_EVENT_OPTIONS variables. Each element in this array specifies the auditing options for an
			/// audit event type. The index of each array element corresponds to an audit event type value in the POLICY_AUDIT_EVENT_TYPE
			/// enumeration type.
			/// </para>
			/// <para>
			/// Each POLICY_AUDIT_EVENT_OPTIONS variable in the array can specify the following auditing options. You can also combine the
			/// success and failure options, POLICY_AUDIT_EVENT_SUCCESS and POLICY_AUDIT_EVENT_FAILURE.
			/// </para>
			/// <para>
			/// When LSASetInformationPolicy is called to change the audit policy, any new POLICY_AUDIT_EVENT_OPTIONS array elements are
			/// added to any existing audit options. Adding a new POLICY_AUDIT_EVENT_OPTIONS element combined with the
			/// POLICY_AUDIT_EVENT_NONE audit option cancels all previous audit options and begins a new set of options.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>POLICY_AUDIT_EVENT_UNCHANGED</term>
			/// <term>
			/// For set operations, specify this value to leave the current options unchanged. For read operations, this value means that no
			/// audit records for this type are generated. This is the default.
			/// </term>
			/// </item>
			/// <item>
			/// <term>POLICY_AUDIT_EVENT_SUCCESS</term>
			/// <term>Generate audit records for successful events of this type.</term>
			/// </item>
			/// <item>
			/// <term>POLICY_AUDIT_EVENT_FAILURE</term>
			/// <term>Generate audit records for failed attempts to cause an event of this type to occur.</term>
			/// </item>
			/// <item>
			/// <term>POLICY_AUDIT_EVENT_NONE</term>
			/// <term>Do not generate audit records for events of this type.</term>
			/// </item>
			/// </list>
			/// </summary>
			public POLICY_AUDIT_EVENT_OPTIONS[] EventAuditingOptions;

			/// <summary>
			/// Specifies the number of elements in the <c>EventAuditingOptions</c> array. For set operations, if this value is less than the
			/// number of audit event types supported by the system, the system does not change the auditing options for event types with
			/// indexes equal to or higher than the value specified in <c>MaximumAuditEventCount</c>.
			/// </summary>
			public int MaximumAuditEventCount => EventAuditingOptions?.Length ?? 0;

			SizeT IVanaraMarshaler.GetNativeSize() => 8 + IntPtr.Size;

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object obj)
			{
				var i = (POLICY_AUDIT_EVENTS_INFO)obj;
				var mem = new SafeHGlobalHandle(64);
				using (var ret = new NativeMemoryStream(mem))
				{
					ret.Write(i.AuditingMode);
					ret.Position = 4;
					ret.Write(i.EventAuditingOptions, true);
					ret.Write(i.MaximumAuditEventCount);
				}
				return mem;
			}

			object IVanaraMarshaler.MarshalNativeToManaged(IntPtr ptr, SizeT size)
			{
				using var str = new NativeMemoryStream(ptr, size);
				var mode = str.Read<BOOLEAN>();
				str.Position = 4 + IntPtr.Size;
				var cnt = str.Read<int>();
				str.Position = 4;
				return new POLICY_AUDIT_EVENTS_INFO
				{
					AuditingMode = mode,
					EventAuditingOptions = str.ReadArray<POLICY_AUDIT_EVENT_OPTIONS>(cnt, true).ToArray()
				};
			}
		}

		/// <summary>
		/// The <c>POLICY_DNS_DOMAIN_INFO</c> structure is used to set and query Domain Name System (DNS) information about the primary
		/// domain associated with a Policy object. The LsaQueryInformationPolicy and LsaSetInformationPolicy functions use this structure
		/// when their InformationClass parameters are set to <c>PolicyDnsDomainInformation</c>.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>POLICY_DNS_DOMAIN_INFO</c> structure is an extended version of the POLICY_PRIMARY_DOMAIN_INFO structure. Setting
		/// <c>POLICY_DNS_DOMAIN_INFO</c> information will overwrite the corresponding values in the <c>POLICY_PRIMARY_DOMAIN_INFO</c> (name
		/// and SID), and vice versa.
		/// </para>
		/// <para>
		/// If the computer associated with the Policy object is not a member of a domain, all structure members except <c>Name</c> are
		/// <c>NULL</c> or zero.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/lsalookup/ns-lsalookup-policy_dns_domain_info typedef struct
		// _POLICY_DNS_DOMAIN_INFO { LSA_UNICODE_STRING Name; LSA_UNICODE_STRING DnsDomainName; LSA_UNICODE_STRING DnsForestName; GUID
		// DomainGuid; PSID Sid; } POLICY_DNS_DOMAIN_INFO, *PPOLICY_DNS_DOMAIN_INFO;
		[PInvokeData("lsalookup.h", MSDNShortId = "5b2879cf-e0dc-4844-bfe8-bf45460285f1")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POLICY_DNS_DOMAIN_INFO
		{
			/// <summary>
			/// An LSA_UNICODE_STRING structure that specifies the name of the primary domain. This is the same as the primary domain name in
			/// the POLICY_PRIMARY_DOMAIN_INFO structure.
			/// </summary>
			public LSA_UNICODE_STRING Name;

			/// <summary>An LSA_UNICODE_STRING structure that specifies the DNS name of the primary domain.</summary>
			public LSA_UNICODE_STRING DnsDomainName;

			/// <summary>
			/// An LSA_UNICODE_STRING structure that specifies the DNS forest name of the primary domain. This is the DNS name of the domain
			/// at the root of the enterprise.
			/// </summary>
			public LSA_UNICODE_STRING DnsForestName;

			/// <summary>A GUID structure that contains the GUID of the primary domain.</summary>
			public Guid DomainGuid;

			/// <summary>
			/// Pointer to the SID of the primary domain. This is the same as the primary domain SID in the POLICY_PRIMARY_DOMAIN_INFO structure.
			/// </summary>
			public PSID Sid;
		}

		/// <summary>[Undocumented] Used by <see cref="POLICY_DOMAIN_INFORMATION_CLASS.PolicyDomainEfsInformation"/>.</summary>
		[PInvokeData("ntsecapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POLICY_DOMAIN_EFS_INFO
		{
			/// <summary>Length of the EFS Information blob</summary>
			public uint InfoLength;

			/// <summary>Efs blob data</summary>
			public IntPtr EfsBlob;
		}

		/// <summary>[Undocumented] Used by <see cref="POLICY_DOMAIN_INFORMATION_CLASS.PolicyDomainKerberosTicketInformation"/>.</summary>
		[PInvokeData("ntsecapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POLICY_DOMAIN_KERBEROS_TICKET_INFO
		{
			/// <summary>allowed ticket options (POLICY_KERBEROS_* flags )</summary>
			public uint AuthenticationOptions;

			/// <summary>Maximum lifetime for a service ticket</summary>
			public FILETIME MaxServiceTicketAge;

			/// <summary>Maximum lifetime for the initial ticket</summary>
			public FILETIME MaxTicketAge;

			/// <summary>Maximum cumulative age a renewable ticket can be with requring authentication</summary>
			public FILETIME MaxRenewAge;

			/// <summary>Maximum tolerance for synchronization of computer clocks</summary>
			public FILETIME MaxClockSkew;

			/// <summary>Reserved</summary>
			public FILETIME Reserved;
		}

		/// <summary>[Undocumented] Used by <see cref="POLICY_DOMAIN_INFORMATION_CLASS.PolicyDomainQualityOfServiceInformation"/>.</summary>
		[PInvokeData("ntsecapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POLICY_DOMAIN_QUALITY_OF_SERVICE_INFO
		{
			/// <summary>Determines what specific QOS actions a machine should take</summary>
			public POLICY_QOS QualityOfService;
		}

		/// <summary>
		/// The <c>POLICY_LSA_SERVER_ROLE_INFO</c> structure is used to set and query the role of an LSA server. The
		/// LsaQueryInformationPolicy and LsaSetInformationPolicy functions use this structure when their InformationClass parameters are set
		/// to <c>PolicyLsaServerRoleInformation</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-policy_lsa_server_role_info typedef struct
		// _POLICY_LSA_SERVER_ROLE_INFO { POLICY_LSA_SERVER_ROLE LsaServerRole; } POLICY_LSA_SERVER_ROLE_INFO, *PPOLICY_LSA_SERVER_ROLE_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "f66abe33-d8c8-45b8-9b94-d6890d786aaa")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POLICY_LSA_SERVER_ROLE_INFO
		{
			/// <summary>
			/// Specifies one of the values from the POLICY_LSA_SERVER_ROLE enumeration type to indicate a primary or backup LSA server.
			/// </summary>
			public POLICY_LSA_SERVER_ROLE LsaServerRole;
		}

		/// <summary>
		/// The <c>POLICY_MODIFICATION_INFO</c> structure is used to query information about the creation time and last modification of the
		/// LSA database. The LsaQueryInformationPolicy function uses this structure when its InformationClass parameter is set to PolicyModificationInformation.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-policy_modification_info typedef struct
		// _POLICY_MODIFICATION_INFO { LARGE_INTEGER ModifiedId; LARGE_INTEGER DatabaseCreationTime; } POLICY_MODIFICATION_INFO, *PPOLICY_MODIFICATION_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "ef4d1d1d-9b1b-4d67-80b8-2b548ec31a87")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POLICY_MODIFICATION_INFO
		{
			/// <summary>
			/// A LARGE_INTEGER structure containing a 64-bit unsigned integer that is incremented each time anything in the LSA database is
			/// modified. This value is modified only on primary domain controllers.
			/// </summary>
			public long ModifiedId;

			/// <summary>
			/// A LARGE_INTEGER structure that indicates the date and time the LSA database was created. This is a UTC-based time that uses
			/// the FILETIME format. On backup domain controllers, this value is replicated from the primary domain controller. For more
			/// information about UTC-based time, see System Time.
			/// </summary>
			public FILETIME DatabaseCreationTime;
		}

		/// <summary>
		/// The <c>TRUSTED_DOMAIN_AUTH_INFORMATION</c> structure is used to retrieve authentication information for a trusted domain. The
		/// LsaQueryTrustedDomainInfo function uses this structure when its InformationClass parameter is set to <c>TrustedDomainAuthInformation</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_trusted_domain_auth_information typedef struct
		// _TRUSTED_DOMAIN_AUTH_INFORMATION { ULONG IncomingAuthInfos; PLSA_AUTH_INFORMATION IncomingAuthenticationInformation;
		// PLSA_AUTH_INFORMATION IncomingPreviousAuthenticationInformation; ULONG OutgoingAuthInfos; PLSA_AUTH_INFORMATION
		// OutgoingAuthenticationInformation; PLSA_AUTH_INFORMATION OutgoingPreviousAuthenticationInformation; }
		// TRUSTED_DOMAIN_AUTH_INFORMATION, *PTRUSTED_DOMAIN_AUTH_INFORMATION;
		[PInvokeData("ntsecapi.h", MSDNShortId = "2ec606d7-42bd-47cc-a4cd-82908774aa43")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRUSTED_DOMAIN_AUTH_INFORMATION
		{
			/// <summary>
			/// Specifies the number of entries in the <c>IncomingAuthenticationInformation</c> and
			/// <c>IncomingPreviousAuthenticationInformation</c> arrays.
			/// </summary>
			public uint IncomingAuthInfos;

			/// <summary>
			/// Pointer to an array of LSA_AUTH_INFORMATION structures containing the authentication information for the incoming side of a
			/// trust relationship.
			/// </summary>
			public IntPtr IncomingAuthenticationInformation;

			/// <summary>
			/// Pointer to an array of LSA_AUTH_INFORMATION structures containing the previous authentication information (or old password)
			/// for the incoming side of a trust relationship. There must be one of these for every entry in the
			/// <c>IncomingAuthenticationInformation</c> array.
			/// </summary>
			public IntPtr IncomingPreviousAuthenticationInformation;

			/// <summary>
			/// Specifies the number of entries in the <c>OutgoingAuthenticationInformation</c> and
			/// <c>OutgoingPreviousAuthenticationInformation</c> arrays.
			/// </summary>
			public uint OutgoingAuthInfos;

			/// <summary>
			/// Pointer to an array of LSA_AUTH_INFORMATION structures containing the authentication information for the outgoing side of a
			/// trust relationship.
			/// </summary>
			public IntPtr OutgoingAuthenticationInformation;

			/// <summary>
			/// Pointer to an array of LSA_AUTH_INFORMATION structures containing the previous authentication information (or old password)
			/// for the outgoing side of a trust relationship. There must be one of these for every entry in the
			/// <c>OutgoingAuthenticationInformation</c> array.
			/// </summary>
			public IntPtr OutgoingPreviousAuthenticationInformation;
		}

		/// <summary>
		/// The <c>TRUSTED_DOMAIN_FULL_INFORMATION</c> structure is used to retrieve complete information about a trusted domain. The
		/// LsaQueryTrustedDomainInfo function uses this structure when its InformationClass parameter is set to <c>TrustedDomainFullInformation</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_trusted_domain_full_information typedef struct
		// _TRUSTED_DOMAIN_FULL_INFORMATION { TRUSTED_DOMAIN_INFORMATION_EX Information; TRUSTED_POSIX_OFFSET_INFO PosixOffset;
		// TRUSTED_DOMAIN_AUTH_INFORMATION AuthInformation; } TRUSTED_DOMAIN_FULL_INFORMATION, *PTRUSTED_DOMAIN_FULL_INFORMATION;
		[PInvokeData("ntsecapi.h", MSDNShortId = "b7abfe1e-d9e6-4583-a738-c16190ffd44d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRUSTED_DOMAIN_FULL_INFORMATION
		{
			/// <summary>
			/// <para>A TRUSTED_DOMAIN_INFORMATION_EX structure containing extended information for a trusted domain.</para>
			/// </summary>
			public TRUSTED_DOMAIN_INFORMATION_EX Information;

			/// <summary>
			/// A TRUSTED_POSIX_OFFSET_INFO structure containing the value used to generate Posix user and group identifiers for a trusted domain.
			/// </summary>
			public TRUSTED_POSIX_OFFSET_INFO PosixOffset;

			/// <summary>
			/// <para>A TRUSTED_DOMAIN_AUTH_INFORMATION structure containing authentication information for a trusted domain.</para>
			/// </summary>
			public TRUSTED_DOMAIN_AUTH_INFORMATION AuthInformation;
		}

		/// <summary>
		/// The <c>TRUSTED_DOMAIN_INFORMATION_EX</c> structure is used to retrieve extended information about a trusted domain. The
		/// LsaQueryTrustedDomainInfo function uses this structure when its InformationClass parameter is set to TrustedDomainInformationEx.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_trusted_domain_information_ex typedef struct
		// _TRUSTED_DOMAIN_INFORMATION_EX { LSA_UNICODE_STRING Name; LSA_UNICODE_STRING FlatName; PSID Sid; ULONG TrustDirection; ULONG
		// TrustType; ULONG TrustAttributes; } TRUSTED_DOMAIN_INFORMATION_EX, *PTRUSTED_DOMAIN_INFORMATION_EX;
		[PInvokeData("ntsecapi.h", MSDNShortId = "acf9a2b5-f301-4e6a-a515-df338658ad56")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRUSTED_DOMAIN_INFORMATION_EX
		{
			/// <summary>
			/// An LSA_UNICODE_STRING structure that contains the name of the trusted domain. This is the DNS domain name. For non-Microsoft
			/// trusted domains, this is the identifying name of the domain.
			/// </summary>
			public LSA_UNICODE_STRING Name;

			/// <summary>
			/// An LSA_UNICODE_STRING structure that contains the flat name of the trusted domain. For non-Microsoft trusted domains, this is
			/// the identifying name of the domain or it is <c>NULL</c>.
			/// </summary>
			public LSA_UNICODE_STRING FlatName;

			/// <summary>
			/// Pointer to the security identifier (SID) of the trusted domain. For non-Microsoft trusted domains, this member can be <c>NULL</c>.
			/// </summary>
			public PSID Sid;

			/// <summary>
			/// <para>A value that indicates the direction of the trust. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUST_DIRECTION_DISABLED</term>
			/// <term>The trust relationship exists, but it has been disabled.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_DIRECTION_INBOUND</term>
			/// <term>The trusted domain trusts the primary domain to perform operations such as name lookups and authentication.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_DIRECTION_OUTBOUND</term>
			/// <term>The primary domain trusts the trusted domain to perform operations such as name lookups and authentication.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_DIRECTION_BIDIRECTIONAL</term>
			/// <term>Both domains trust each other.</term>
			/// </item>
			/// </list>
			/// </summary>
			public TrustDirection TrustDirection;

			/// <summary>
			/// <para>A value that indicates the type of the trust relationship. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUST_TYPE_DOWNLEVEL</term>
			/// <term>The domain controller of the trusted domain is a computer running an operating system earlier than Windows 2000.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_TYPE_UPLEVEL</term>
			/// <term>The domain controller of the Microsoft trusted domain is a computer running Windows 2000 or later.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_TYPE_MIT</term>
			/// <term>The trusted domain is an MIT Kerberos realm.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_TYPE_DCE</term>
			/// <term>The trusted domain is a DCE realm.</term>
			/// </item>
			/// <item>
			/// <term>0x5 - 0x000FFFFF</term>
			/// <term>Reserved for future use.</term>
			/// </item>
			/// <item>
			/// <term>0x00100000 to 0xFFF00000</term>
			/// <term>Provider-specific trust levels.</term>
			/// </item>
			/// </list>
			/// </summary>
			public TrustType TrustType;

			/// <summary>
			/// <para>A value that indicates the attributes of a trust relationship. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUST_ATTRIBUTE_NON_TRANSITIVE</term>
			/// <term>Disallow transitivity.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_ATTRIBUTE_UPLEVEL_ONLY</term>
			/// <term>The trust link is not valid for client operating systems earlier than Windows 2000.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_ATTRIBUTE_FILTER_SIDS</term>
			/// <term>Quarantine domains.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_ATTRIBUTE_FOREST_TRANSITIVE</term>
			/// <term>The trust link may contain forest trust information.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_ATTRIBUTE_CROSS_ORGANIZATION</term>
			/// <term>This trust is to a domain/forest that is not part of this enterprise.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_ATTRIBUTE_TREAT_AS_EXTERNAL</term>
			/// <term>Trust is treated as external for trust boundary purposes.</term>
			/// </item>
			/// <item>
			/// <term>TRUST_ATTRIBUTE_WITHIN_FOREST</term>
			/// <term>Trust is internal to this forest.</term>
			/// </item>
			/// </list>
			/// </summary>
			public TrustAttributes TrustAttributes;
		}

		/// <summary>
		/// The <c>TRUSTED_DOMAIN_NAME_INFO</c> structure is used to query or set the name of a trusted domain. The LsaQueryTrustedDomainInfo
		/// and LsaSetTrustedDomainInformation functions use this structure when their InformationClass parameters are set to <c>TrustedDomainNameInformation</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_trusted_domain_name_info typedef struct
		// _TRUSTED_DOMAIN_NAME_INFO { LSA_UNICODE_STRING Name; } TRUSTED_DOMAIN_NAME_INFO, *PTRUSTED_DOMAIN_NAME_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "9bc1301b-1d09-4cd2-8590-e7756ee4792d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRUSTED_DOMAIN_NAME_INFO
		{
			/// <summary>
			/// <para>An LSA_UNICODE_STRING structure that contains the name of a trusted domain.</para>
			/// </summary>
			public LSA_UNICODE_STRING Name;
		}

		/// <summary>
		/// The <c>TRUSTED_PASSWORD_INFO</c> structure is used to query or set the password for a trusted domain. The
		/// LsaQueryTrustedDomainInfo and LsaSetTrustedDomainInformation functions use this structure when their InformationClass parameters
		/// are set to TrustedPasswordInformation.
		/// </summary>
		/// <remarks>
		/// When you have finished using the <c>TRUSTED_PASSWORD_INFO</c> structure, clear the sensitive information from memory by calling
		/// the SecureZeroMemory function. For more information about protecting passwords, see Handling Passwords.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_trusted_password_info typedef struct
		// _TRUSTED_PASSWORD_INFO { LSA_UNICODE_STRING Password; LSA_UNICODE_STRING OldPassword; } TRUSTED_PASSWORD_INFO, *PTRUSTED_PASSWORD_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "2c3aca10-8efd-4278-8127-2d31db776c0e")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRUSTED_PASSWORD_INFO
		{
			/// <summary>
			/// An LSA_UNICODE_STRING structure that contains the password to use when creating an authenticated connection to the domain.
			/// </summary>
			public LSA_UNICODE_STRING Password;

			/// <summary>
			/// An LSA_UNICODE_STRING structure that contains the old password. On set operations, if the <c>Buffer</c> member of this
			/// structure is <c>NULL</c>, the old password is set to the current password.
			/// </summary>
			public LSA_UNICODE_STRING OldPassword;
		}

		/// <summary>
		/// The <c>TRUSTED_POSIX_OFFSET_INFO</c> structure is used to query or set the value used to generate Posix user and group
		/// identifiers. The LsaQueryTrustedDomainInfo and LsaSetTrustedDomainInformation functions use this structure when their
		/// InformationClass parameters are set to <c>TrustedPosixOffsetInformation</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_trusted_posix_offset_info typedef struct
		// _TRUSTED_POSIX_OFFSET_INFO { ULONG Offset; } TRUSTED_POSIX_OFFSET_INFO, *PTRUSTED_POSIX_OFFSET_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "0686da5e-43d4-49ac-8c5d-5c56b8d12e50")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRUSTED_POSIX_OFFSET_INFO
		{
			/// <summary>
			/// An offset that the system uses to generate Posix user and group identifiers that correspond to a given SID. To generate a
			/// Posix identifier, the system adds the RID from the SID to the Posix offset of the trusted domain identified by the SID.
			/// </summary>
			public uint Offset;
		}
	}
}