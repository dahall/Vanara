using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Functions, enumerations and structures found in ADVAPI32.DLL.</summary>
	public static partial class AdvApi32
	{
		/// <summary>The <c>POLICY_DOMAIN_INFORMATION_CLASS</c> enumeration defines the type of policy domain information.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-_policy_domain_information_class typedef enum
		// _POLICY_DOMAIN_INFORMATION_CLASS { PolicyDomainQualityOfServiceInformation, PolicyDomainEfsInformation,
		// PolicyDomainKerberosTicketInformation } POLICY_DOMAIN_INFORMATION_CLASS, *PPOLICY_DOMAIN_INFORMATION_CLASS;
		[PInvokeData("ntsecapi.h", MSDNShortId = "b208c479-a262-4120-824f-677ead1ef61a")]
		public enum POLICY_DOMAIN_INFORMATION_CLASS
		{
			/// <summary/>
			PolicyDomainQualityOfServiceInformation = 1,

			/// <summary>The information is for Encrypting File System.</summary>
			PolicyDomainEfsInformation,

			/// <summary>The information is for a Kerberos ticket.</summary>
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
			PolicyAuditLogInformation = 1,

			/// <summary>
			/// Query or set the auditing rules of the system. You can enable or disable auditing and specify the types of events that are
			/// audited. Use the POLICY_AUDIT_EVENTS_INFO structure.
			/// </summary>
			PolicyAuditEventsInformation,

			/// <summary>This value is obsolete. Use the PolicyDnsDomainInformation value instead.</summary>
			PolicyPrimaryDomainInformation,

			/// <summary>This value is obsolete.</summary>
			PolicyPdAccountInformation,

			/// <summary>Query or set the name and SID of the account domain of the system. Use the POLICY_ACCOUNT_DOMAIN_INFO structure.</summary>
			PolicyAccountDomainInformation,

			/// <summary>Query or set the role of an LSA server. Use the POLICY_LSA_SERVER_ROLE_INFO structure.</summary>
			PolicyLsaServerRoleInformation,

			/// <summary>This value is obsolete.</summary>
			PolicyReplicaSourceInformation,

			/// <summary>This value is obsolete.</summary>
			PolicyDefaultQuotaInformation,

			/// <summary>
			/// Query or set information about the creation time and last modification of the LSA database. Use the POLICY_MODIFICATION_INFO structure.
			/// </summary>
			PolicyModificationInformation,

			/// <summary>This value is obsolete.</summary>
			PolicyAuditFullSetInformation,

			/// <summary>This value is obsolete.</summary>
			PolicyAuditFullQueryInformation,

			/// <summary>
			/// Query or set Domain Name System (DNS) information about the account domain associated with a Policy object. Use the
			/// POLICY_DNS_DOMAIN_INFO structure.
			/// </summary>
			PolicyDnsDomainInformation,

			/// <summary/>
			PolicyDnsDomainInformationInt,

			/// <summary/>
			PolicyLocalAccountDomainInformation,

			/// <summary/>
			PolicyMachineAccountInformation,
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
			TrustedDomainNameInformation,

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_domain_password_information typedef struct
		// _DOMAIN_PASSWORD_INFORMATION { USHORT MinPasswordLength; USHORT PasswordHistoryLength; ULONG PasswordProperties; #if ...
		// OLD_LARGE_INTEGER MaxPasswordAge; #if ... OLD_LARGE_INTEGER MinPasswordAge; #else LARGE_INTEGER MaxPasswordAge; #endif #else
		// LARGE_INTEGER MinPasswordAge; #endif } DOMAIN_PASSWORD_INFORMATION, *PDOMAIN_PASSWORD_INFORMATION;
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
			public long MaxPasswordAge;

			/// <summary>
			/// A 64-bit value, with delta time syntax, indicating the policy setting for the minimum time allowed before a password change
			/// operation is allowed.
			/// </summary>
			public long MinPasswordAge;
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
			/// <para>
			/// A LARGE_INTEGER structure that uses the Coordinated Universal Time (Greenwich Mean Time) format to indicate the time that
			/// this value was set. For more information about Coordinated Universal Time, see the FILETIME structure.
			/// </para>
			/// </summary>
			public long LastUpdateTime;

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
			public uint AuthType;

			/// <summary>
			/// <para>Specifies the size, in bytes, of the <c>AuthInfo</c> member.</para>
			/// </summary>
			public uint AuthInfoLength;

			/// <summary>
			/// <para>
			/// Pointer to an array of bytes that contains the type of authentication information indicated by the <c>AuthType</c> member.
			/// </para>
			/// </summary>
			public IntPtr AuthInfo;
		}

		/// <summary>
		/// <para>
		/// The <c>TRUSTED_DOMAIN_AUTH_INFORMATION</c> structure is used to retrieve authentication information for a trusted domain. The
		/// LsaQueryTrustedDomainInfo function uses this structure when its InformationClass parameter is set to <c>TrustedDomainAuthInformation</c>.
		/// </para>
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
			/// <para>
			/// Specifies the number of entries in the <c>IncomingAuthenticationInformation</c> and
			/// <c>IncomingPreviousAuthenticationInformation</c> arrays.
			/// </para>
			/// </summary>
			public uint IncomingAuthInfos;

			/// <summary>
			/// <para>
			/// Pointer to an array of LSA_AUTH_INFORMATION structures containing the authentication information for the incoming side of a
			/// trust relationship.
			/// </para>
			/// </summary>
			public IntPtr IncomingAuthenticationInformation;

			/// <summary>
			/// <para>
			/// Pointer to an array of LSA_AUTH_INFORMATION structures containing the previous authentication information (or old password)
			/// for the incoming side of a trust relationship. There must be one of these for every entry in the
			/// <c>IncomingAuthenticationInformation</c> array.
			/// </para>
			/// </summary>
			public IntPtr IncomingPreviousAuthenticationInformation;

			/// <summary>
			/// <para>
			/// Specifies the number of entries in the <c>OutgoingAuthenticationInformation</c> and
			/// <c>OutgoingPreviousAuthenticationInformation</c> arrays.
			/// </para>
			/// </summary>
			public uint OutgoingAuthInfos;

			/// <summary>
			/// <para>
			/// Pointer to an array of LSA_AUTH_INFORMATION structures containing the authentication information for the outgoing side of a
			/// trust relationship.
			/// </para>
			/// </summary>
			public IntPtr OutgoingAuthenticationInformation;

			/// <summary>
			/// <para>
			/// Pointer to an array of LSA_AUTH_INFORMATION structures containing the previous authentication information (or old password)
			/// for the outgoing side of a trust relationship. There must be one of these for every entry in the
			/// <c>OutgoingAuthenticationInformation</c> array.
			/// </para>
			/// </summary>
			public IntPtr OutgoingPreviousAuthenticationInformation;
		}

		/// <summary>
		/// <para>
		/// The <c>TRUSTED_DOMAIN_FULL_INFORMATION</c> structure is used to retrieve complete information about a trusted domain. The
		/// LsaQueryTrustedDomainInfo function uses this structure when its InformationClass parameter is set to <c>TrustedDomainFullInformation</c>.
		/// </para>
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
			/// <para>
			/// A TRUSTED_POSIX_OFFSET_INFO structure containing the value used to generate Posix user and group identifiers for a trusted domain.
			/// </para>
			/// </summary>
			public TRUSTED_POSIX_OFFSET_INFO PosixOffset;

			/// <summary>
			/// <para>A TRUSTED_DOMAIN_AUTH_INFORMATION structure containing authentication information for a trusted domain.</para>
			/// </summary>
			public TRUSTED_DOMAIN_AUTH_INFORMATION AuthInformation;
		}

		/// <summary>
		/// <para>
		/// The <c>TRUSTED_DOMAIN_INFORMATION_EX</c> structure is used to retrieve extended information about a trusted domain. The
		/// LsaQueryTrustedDomainInfo function uses this structure when its InformationClass parameter is set to TrustedDomainInformationEx.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_trusted_domain_information_ex typedef struct
		// _TRUSTED_DOMAIN_INFORMATION_EX { LSA_UNICODE_STRING Name; LSA_UNICODE_STRING FlatName; PSID Sid; ULONG TrustDirection; ULONG
		// TrustType; ULONG TrustAttributes; } TRUSTED_DOMAIN_INFORMATION_EX, *PTRUSTED_DOMAIN_INFORMATION_EX;
		[PInvokeData("ntsecapi.h", MSDNShortId = "acf9a2b5-f301-4e6a-a515-df338658ad56")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRUSTED_DOMAIN_INFORMATION_EX
		{
			/// <summary>
			/// <para>
			/// An LSA_UNICODE_STRING structure that contains the name of the trusted domain. This is the DNS domain name. For non-Microsoft
			/// trusted domains, this is the identifying name of the domain.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING Name;

			/// <summary>
			/// <para>
			/// An LSA_UNICODE_STRING structure that contains the flat name of the trusted domain. For non-Microsoft trusted domains, this is
			/// the identifying name of the domain or it is <c>NULL</c>.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING FlatName;

			/// <summary>
			/// <para>
			/// Pointer to the security identifier (SID) of the trusted domain. For non-Microsoft trusted domains, this member can be <c>NULL</c>.
			/// </para>
			/// </summary>
			public IntPtr Sid;

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
		/// <para>
		/// The <c>TRUSTED_DOMAIN_NAME_INFO</c> structure is used to query or set the name of a trusted domain. The LsaQueryTrustedDomainInfo
		/// and LsaSetTrustedDomainInformation functions use this structure when their InformationClass parameters are set to <c>TrustedDomainNameInformation</c>.
		/// </para>
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
		/// <para>
		/// The <c>TRUSTED_PASSWORD_INFO</c> structure is used to query or set the password for a trusted domain. The
		/// LsaQueryTrustedDomainInfo and LsaSetTrustedDomainInformation functions use this structure when their InformationClass parameters
		/// are set to TrustedPasswordInformation.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When you have finished using the <c>TRUSTED_PASSWORD_INFO</c> structure, clear the sensitive information from memory by calling
		/// the SecureZeroMemory function. For more information about protecting passwords, see Handling Passwords.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_trusted_password_info typedef struct
		// _TRUSTED_PASSWORD_INFO { LSA_UNICODE_STRING Password; LSA_UNICODE_STRING OldPassword; } TRUSTED_PASSWORD_INFO, *PTRUSTED_PASSWORD_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "2c3aca10-8efd-4278-8127-2d31db776c0e")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRUSTED_PASSWORD_INFO
		{
			/// <summary>
			/// <para>
			/// An LSA_UNICODE_STRING structure that contains the password to use when creating an authenticated connection to the domain.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING Password;

			/// <summary>
			/// <para>
			/// An LSA_UNICODE_STRING structure that contains the old password. On set operations, if the <c>Buffer</c> member of this
			/// structure is <c>NULL</c>, the old password is set to the current password.
			/// </para>
			/// </summary>
			public LSA_UNICODE_STRING OldPassword;
		}

		/// <summary>
		/// <para>
		/// The <c>TRUSTED_POSIX_OFFSET_INFO</c> structure is used to query or set the value used to generate Posix user and group
		/// identifiers. The LsaQueryTrustedDomainInfo and LsaSetTrustedDomainInformation functions use this structure when their
		/// InformationClass parameters are set to <c>TrustedPosixOffsetInformation</c>.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_trusted_posix_offset_info typedef struct
		// _TRUSTED_POSIX_OFFSET_INFO { ULONG Offset; } TRUSTED_POSIX_OFFSET_INFO, *PTRUSTED_POSIX_OFFSET_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "0686da5e-43d4-49ac-8c5d-5c56b8d12e50")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRUSTED_POSIX_OFFSET_INFO
		{
			/// <summary>
			/// <para>
			/// An offset that the system uses to generate Posix user and group identifiers that correspond to a given SID. To generate a
			/// Posix identifier, the system adds the RID from the SID to the Posix offset of the trusted domain identified by the SID.
			/// </para>
			/// </summary>
			public uint Offset;
		}

	}
}