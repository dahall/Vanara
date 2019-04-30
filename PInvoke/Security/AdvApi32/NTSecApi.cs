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
		/// <summary>Flags that provide more information about the collision.</summary>
		[PInvokeData("ntsecapi.h", MSDNShortId = "9f9d2f57-0e7f-4222-be35-e3f026b60e93")]
		[Flags]
		public enum CollisionFlags
		{
			LSA_TLN_DISABLED_NEW = 0x00000001,
			LSA_TLN_DISABLED_ADMIN = 0x00000002,
			LSA_TLN_DISABLED_CONFLICT = 0x00000004,
			LSA_SID_DISABLED_ADMIN = 0x00000001,
			LSA_SID_DISABLED_CONFLICT = 0x00000002,
			LSA_NB_DISABLED_ADMIN = 0x00000004,
			LSA_NB_DISABLED_CONFLICT = 0x00000008,
		}

		/// <summary>
		/// <para>
		/// The <c>LSA_FOREST_TRUST_COLLISION_RECORD_TYPE</c> enumeration defines the types of collision that can occur between Local
		/// Security Authority forest trust records.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>This enumeration is used by the LSA_FOREST_TRUST_COLLISION_RECORD structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-lsa_forest_trust_collision_record_type typedef enum {
		// CollisionTdo, CollisionXref, CollisionOther } ;
		[PInvokeData("ntsecapi.h", MSDNShortId = "67c89d75-2c2d-4980-a1c9-32e7f64a7b49")]
		public enum LSA_FOREST_TRUST_COLLISION_RECORD_TYPE
		{
			/// <summary>Collision between TrustedDomain objects. This indicates a collision with a namespace element of another forest.</summary>
			CollisionTdo,

			/// <summary>Collision between cross-references. This indicates a collision with a domain in the same forest.</summary>
			CollisionXref,

			/// <summary>Collision that is not a collision between TrustedDomain objects or cross-references.</summary>
			CollisionOther,
		}

		/// <summary>
		/// <para>The <c>LSA_FOREST_TRUST_RECORD_TYPE</c> enumeration defines the type of a Local Security Authority forest trust record.</para>
		/// </summary>
		/// <remarks>
		/// <para>This enumeration is used by the LSA_FOREST_TRUST_RECORD structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-lsa_forest_trust_record_type typedef enum
		// LSA_FOREST_TRUST_RECORD_TYPE { ForestTrustTopLevelName , ForestTrustTopLevelNameEx , ForestTrustDomainInfo ,
		// ForestTrustRecordTypeLast } ;
		[PInvokeData("ntsecapi.h", MSDNShortId = "8a4a7080-fab0-4ab2-a0b4-e929cce21f0c")]
		public enum LSA_FOREST_TRUST_RECORD_TYPE
		{
			/// <summary>Record contains an included top-level name.</summary>
			ForestTrustTopLevelName,

			/// <summary>Record contains an excluded top-level name.</summary>
			ForestTrustTopLevelNameEx,

			/// <summary>Record contains an LSA_FOREST_TRUST_DOMAIN_INFO structure.</summary>
			ForestTrustDomainInfo,

			/// <summary>Marks the end of an enumeration.</summary>
			ForestTrustRecordTypeLast,
		}

		/// <summary>Flags used by LSA_FOREST_TRUST_RECORD.</summary>
		[PInvokeData("ntsecapi.h", MSDNShortId = "19b4ee56-664f-4f37-bfc9-129032ebeb22")]
		[Flags]
		public enum LSA_TLN
		{
			/// <summary>The top-level name trust record is disabled during initial creation.<note type="note>This flag MUST be used only
			/// with forest trust record types of ForestTrustTopLevelName and ForestTrustTopLevelNameEx.</note></summary>
			LSA_TLN_DISABLED_NEW = 0x00000001,

			/// <summary>The top-level name trust record is disabled by the domain administrator.<note type="note>This flag MUST be used only
			/// with forest trust record types of ForestTrustTopLevelName and ForestTrustTopLevelNameEx.</note></summary>
			LSA_TLN_DISABLED_ADMIN = 0x00000002,

			/// <summary>The top-level name trust record is disabled due to a conflict.<note type="note>This flag MUST be used only with
			/// forest trust record types of ForestTrustTopLevelName and ForestTrustTopLevelNameEx.</note></summary>
			LSA_TLN_DISABLED_CONFLICT = 0x00000004,

			/// <summary>The domain information trust record is disabled by the domain administrator.<note type="note>This flag MUST be used
			/// only with a forest trust record type of ForestTrustDomainInfo.</note></summary>
			LSA_SID_DISABLED_ADMIN = 0x00000001,

			/// <summary>The domain information trust record is disabled due to a conflict.<note type="note>This flag MUST be used only with
			/// a forest trust record type of ForestTrustDomainInfo.</note></summary>
			LSA_SID_DISABLED_CONFLICT = 0x00000002,

			/// <summary>The domain information trust record is disabled by the domain administrator.<note type="note>This flag MUST be used
			/// only with a forest trust record type of ForestTrustDomainInfo.</note></summary>
			LSA_NB_DISABLED_ADMIN = 0x00000004,

			/// <summary>The domain information trust record is disabled due to a conflict.<note type="note>This flag MUST be used only with
			/// a forest trust record type of ForestTrustDomainInfo.</note></summary>
			LSA_NB_DISABLED_CONFLICT = 0x00000008,

			/// <summary>The domain information trust record is disabled.<note type="note>This set of flags is reserved; for current and
			/// future reasons, the trust is disabled.</note></summary>
			LSA_FTRECORD_DISABLED_REASONS = 0x0000FFFF,
		}

		/// <summary>The Policy object has the following object-specific access types:</summary>
		[Flags]
		[PInvokeData("ntsecapi.h")]
		public enum LsaPolicyRights : uint
		{
			/// <summary>
			/// This access type is needed to read the target system's miscellaneous security policy information. This includes the default
			/// quota, auditing, server state and role information, and trust information. This access type is also needed to enumerate
			/// trusted domains, accounts, and privileges.
			/// </summary>
			POLICY_VIEW_LOCAL_INFORMATION = 1,

			/// <summary>This access type is needed to view audit trail or audit requirements information.</summary>
			POLICY_VIEW_AUDIT_INFORMATION = 2,

			/// <summary>
			/// This access type is needed to view sensitive information, such as the names of accounts established for trusted domain relationships.
			/// </summary>
			POLICY_GET_PRIVATE_INFORMATION = 4,

			/// <summary>This access type is needed to change the account domain or primary domain information.</summary>
			POLICY_TRUST_ADMIN = 8,

			/// <summary>This access type is needed to create a new Account object.</summary>
			POLICY_CREATE_ACCOUNT = 0x10,

			/// <summary>This access type is needed to create a new Private Data object.</summary>
			POLICY_CREATE_SECRET = 0x20,

			/// <summary>Not yet supported.</summary>
			POLICY_CREATE_PRIVILEGE = 0x40,

			/// <summary>Set the default system quotas that are applied to user accounts.</summary>
			POLICY_SET_DEFAULT_QUOTA_LIMITS = 0x80,

			/// <summary>This access type is needed to update the auditing requirements of the system.</summary>
			POLICY_SET_AUDIT_REQUIREMENTS = 0x100,

			/// <summary>
			/// This access type is needed to change the characteristics of the audit trail such as its maximum size or the retention period
			/// for audit records, or to clear the log.
			/// </summary>
			POLICY_AUDIT_LOG_ADMIN = 0x200,

			/// <summary>
			/// This access type is needed to modify the server state or role (master/replica) information. It is also needed to change the
			/// replica source and account name information.
			/// </summary>
			POLICY_SERVER_ADMIN = 0x400,

			/// <summary>This access type is needed to translate between names and SIDs.</summary>
			POLICY_LOOKUP_NAMES = 0x800,

			/// <summary>The policy notification</summary>
			POLICY_NOTIFICATION = 0x1000,

			/// <summary>All access</summary>
			POLICY_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED |
								POLICY_VIEW_LOCAL_INFORMATION |
								POLICY_VIEW_AUDIT_INFORMATION |
								POLICY_GET_PRIVATE_INFORMATION |
								POLICY_TRUST_ADMIN |
								POLICY_CREATE_ACCOUNT |
								POLICY_CREATE_SECRET |
								POLICY_CREATE_PRIVILEGE |
								POLICY_SET_DEFAULT_QUOTA_LIMITS |
								POLICY_SET_AUDIT_REQUIREMENTS |
								POLICY_AUDIT_LOG_ADMIN |
								POLICY_SERVER_ADMIN |
								POLICY_LOOKUP_NAMES,

			/// <summary>Read access</summary>
			POLICY_READ = ACCESS_MASK.STANDARD_RIGHTS_READ |
						  POLICY_VIEW_AUDIT_INFORMATION |
						  POLICY_GET_PRIVATE_INFORMATION,

			/// <summary>Write access</summary>
			POLICY_WRITE = ACCESS_MASK.STANDARD_RIGHTS_WRITE |
						   POLICY_TRUST_ADMIN |
						   POLICY_CREATE_ACCOUNT |
						   POLICY_CREATE_SECRET |
						   POLICY_CREATE_PRIVILEGE |
						   POLICY_SET_DEFAULT_QUOTA_LIMITS |
						   POLICY_SET_AUDIT_REQUIREMENTS |
						   POLICY_AUDIT_LOG_ADMIN |
						   POLICY_SERVER_ADMIN,

			/// <summary>Execute access</summary>
			POLICY_EXECUTE = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE |
							 POLICY_VIEW_LOCAL_INFORMATION |
							 POLICY_LOOKUP_NAMES,
		}

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
			[CorrespondingType(typeof(TRUSTED_DOMAIN_INFORMATION_EX), CorrepsondingAction.Get)]
			TrustedDomainInformationEx,

			/// <summary>Query authentication information for a trusted domain. Use the TRUSTED_DOMAIN_AUTH_INFORMATION structure.</summary>
			[CorrespondingType(typeof(TRUSTED_DOMAIN_AUTH_INFORMATION), CorrepsondingAction.Get)]
			TrustedDomainAuthInformation,

			/// <summary>
			/// Query complete information for a trusted domain. This information includes the Posix offset information, authentication
			/// information, and the extended information returned for the TrustedDomainInformationEx value. Use the
			/// TRUSTED_DOMAIN_FULL_INFORMATION structure.
			/// </summary>
			[CorrespondingType(typeof(TRUSTED_DOMAIN_FULL_INFORMATION), CorrepsondingAction.Get)]
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
		/// The LsaAddAccountRights function assigns one or more privileges to an account. If the account does not exist, LsaAddAccountRights
		/// creates it.
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. If the account identified by the
		/// AccountSid parameter does not exist, the handle must have the POLICY_CREATE_ACCOUNT access right. For more information, see
		/// Opening a Policy Object Handle.
		/// </param>
		/// <param name="pSID">Pointer to the SID of the account to which the function assigns privileges.</param>
		/// <param name="UserRights">
		/// Pointer to an array of strings. Each string contains the name of a privilege to add to the account. For a list of privilege
		/// names, see Privilege Constants.
		/// </param>
		/// <param name="CountOfRights">Specifies the number of elements in the UserRights array.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code, which
		/// can be the following value or one of the LSA Policy Function Return Values.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true), SuppressUnmanagedCodeSecurity]
		[PInvokeData("ntsecapi.h", MSDNShortId = "ms721786")]
		public static extern uint LsaAddAccountRights(
			LSA_HANDLE PolicyHandle,
			PSID pSID,
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringArrayMarshaler))]
			string[] UserRights,
			int CountOfRights);

		/// <summary>Undocumented function for creating an account.</summary>
		/// <param name="PolicyHandle">A handle to a Policy object. For more information, see Opening a Policy Object Handle.</param>
		/// <param name="AccountSid">Pointer to the SID of the account for which to enumerate privileges.</param>
		/// <param name="DesiredAccess">The desired access.</param>
		/// <param name="AccountHandle">The account handle.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code.For
		/// more information, see LSA Policy Function Return Values. You can use the LsaNtStatusToWinError function to convert the NTSTATUS
		/// code to a Windows error code.
		/// </returns>
		[PInvokeData("ntlsa.h")]
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaCreateAccount(LSA_HANDLE PolicyHandle, PSID AccountSid, LsaAccountAccessMask DesiredAccess, out SafeLSA_HANDLE AccountHandle);

		/// <summary>The <c>LsaCreateTrustedDomainEx</c> function establishes a new trusted domain by creating a new TrustedDomain object.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. For the object to be created, the caller must have permission to create children on the
		/// <c>System</c> container. For information about policy object handles, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="TrustedDomainInformation">
		/// Pointer to a TRUSTED_DOMAIN_INFORMATION_EX structure that contains the name and SID of the new trusted domain.
		/// </param>
		/// <param name="AuthenticationInformation">
		/// Pointer to a TRUSTED_DOMAIN_AUTH_INFORMATION structure that contains authentication information for the new trusted domain.
		/// </param>
		/// <param name="DesiredAccess">An ACCESS_MASK structure that specifies the accesses to be granted for the new trusted domain.</param>
		/// <param name="TrustedDomainHandle">
		/// <para>
		/// Receives the LSA policy handle of the remote trusted domain. You can pass this handle into LSA function calls to manage the LSA
		/// policy of the trusted domain.
		/// </para>
		/// <para>When your application no longer needs this handle, it should call LsaClose to delete the handle.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, it returns an <c>NTSTATUS</c> code, which can be one of the following values or one of the LSA Policy
		/// Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_DIRECTORY_SERVICE_REQUIRED</term>
		/// <term>The target system (specified in the TrustedDomainInformation parameter) for the TrustedDomain object is not a domain controller.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_SID</term>
		/// <term>The specified SID is not valid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_UNSUCCESSFUL</term>
		/// <term>Unable to determine whether the target system is a domain controller.</term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <c>LsaCreateTrustedDomainEx</c> does not check whether the specified domain name matches the specified SID or whether the SID and
		/// name represent an actual domain.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsacreatetrusteddomainex NTSTATUS
		// LsaCreateTrustedDomainEx( LSA_HANDLE PolicyHandle, PTRUSTED_DOMAIN_INFORMATION_EX TrustedDomainInformation,
		// PTRUSTED_DOMAIN_AUTH_INFORMATION AuthenticationInformation, ACCESS_MASK DesiredAccess, PLSA_HANDLE TrustedDomainHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "2f458098-9498-4f08-bd13-ac572678d734")]
		public static extern NTStatus LsaCreateTrustedDomainEx(LSA_HANDLE PolicyHandle, in TRUSTED_DOMAIN_INFORMATION_EX TrustedDomainInformation, in TRUSTED_DOMAIN_AUTH_INFORMATION AuthenticationInformation, ACCESS_MASK DesiredAccess, out SafeLSA_HANDLE TrustedDomainHandle);

		/// <summary>
		/// The <c>LsaDeleteTrustedDomain</c> function removes a trusted domain from the list of trusted domains for a system and deletes the
		/// associated TrustedDomain object.
		/// </summary>
		/// <param name="PolicyHandle">A handle to a Policy object. For more information, see Opening a Policy Object Handle.</param>
		/// <param name="TrustedDomainSid">Pointer to the SID of the trusted domain to be removed.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsadeletetrusteddomain NTSTATUS LsaDeleteTrustedDomain(
		// LSA_HANDLE PolicyHandle, PSID TrustedDomainSid );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "4a7afa28-1786-4a58-a955-d2d8b12e62e4")]
		public static extern NTStatus LsaDeleteTrustedDomain(LSA_HANDLE PolicyHandle, PSID TrustedDomainSid);

		/// <summary>
		/// <para>The <c>LsaEnumerateAccountRights</c> function enumerates the privileges assigned to an account.</para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// <para>
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a
		/// Policy Object Handle.
		/// </para>
		/// </param>
		/// <param name="AccountSid">
		/// <para>Pointer to the SID of the account for which to enumerate privileges.</para>
		/// </param>
		/// <param name="UserRights">
		/// <para>
		/// Receives a pointer to an array of LSA_UNICODE_STRING structures. Each structure contains the name of a privilege held by the
		/// account. For a list of privilege names, see Privilege Constants
		/// </para>
		/// <para>When you no longer need the information, pass the returned pointer to LsaFreeMemory.</para>
		/// </param>
		/// <param name="CountOfRights">
		/// <para>Pointer to a variable that receives the number of privileges in the UserRights array.</para>
		/// </param>
		/// <returns>
		/// <para>If at least one account right is found, the function succeeds and returns STATUS_SUCCESS.</para>
		/// <para>
		/// If no account rights are found or if the function fails for any other reason, the function returns an NTSTATUS code such as
		/// FILE_NOT_FOUND. For more information, see LSA Policy Function Return Values. Use the LsaNtStatusToWinError function to convert
		/// the NTSTATUS code to a Windows error code.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaenumerateaccountrights NTSTATUS
		// LsaEnumerateAccountRights( LSA_HANDLE PolicyHandle, PSID AccountSid, PLSA_UNICODE_STRING *UserRights, PULONG CountOfRights );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "3f4a4a9a-66ca-410a-8bdc-c390e8b966e3")]
		public static extern uint LsaEnumerateAccountRights(
			LSA_HANDLE PolicyHandle,
			PSID AccountSid,
			out SafeLsaMemoryHandle UserRights,
			out uint CountOfRights);

		/// <summary>The LsaEnumerateAccountRights function enumerates the privileges assigned to an account.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a
		/// Policy Object Handle.
		/// </param>
		/// <param name="AccountSid">Pointer to the SID of the account for which to enumerate privileges.</param>
		/// <returns>
		/// An enumeration of strings containing the names of privileges held by the account. For a list of privilege names, see Privilege Constants.
		/// </returns>
		public static IEnumerable<string> LsaEnumerateAccountRights(LSA_HANDLE PolicyHandle, PSID AccountSid)
		{
			var ret = LsaEnumerateAccountRights(PolicyHandle, AccountSid, out var mem, out var cnt);
			var winErr = LsaNtStatusToWinError(ret);
			if (winErr == Win32Error.ERROR_FILE_NOT_FOUND) return new string[0];
			winErr.ThrowIfFailed();
			return mem.DangerousGetHandle().ToIEnum<LSA_UNICODE_STRING>((int)cnt).Select(u => (string)u.ToString().Clone());
		}

		/// <summary>
		/// <para>
		/// The <c>LsaEnumerateAccountsWithUserRight</c> function returns the accounts in the database of a Local Security Authority (LSA)
		/// Policy object that hold a specified privilege. The accounts returned by this function hold the specified privilege directly
		/// through the user account, not as part of membership to a group.
		/// </para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// <para>
		/// A handle to a Policy object. The handle must have POLICY_LOOKUP_NAMES and POLICY_VIEW_LOCAL_INFORMATION user rights. For more
		/// information, see Opening a Policy Object Handle.
		/// </para>
		/// </param>
		/// <param name="UserRight">
		/// <para>
		/// Pointer to an LSA_UNICODE_STRING structure that specifies the name of a privilege. For a list of privileges, see Privilege
		/// Constants and Account Rights Constants.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the function enumerates all accounts in the LSA database of the system associated with the
		/// Policy object.
		/// </para>
		/// </param>
		/// <param name="Buffer">
		/// <para>
		/// Pointer to a variable that receives a pointer to an array of LSA_ENUMERATION_INFORMATION structures. The <c>Sid</c> member of
		/// each structure is a pointer to the security identifier (SID) of an account that holds the specified privilege.
		/// </para>
		/// <para>When you no longer need the information, free the memory by passing the returned pointer to the LsaFreeMemory function.</para>
		/// </param>
		/// <param name="CountReturned">
		/// <para>Pointer to a variable that receives the number of entries returned in the EnumerationBuffer parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, it returns an <c>NTSTATUS</c> code, which can be one of the following values or one of the LSA Policy
		/// Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_NO_SUCH_PRIVILEGE</term>
		/// <term>The privilege string specified was not a valid privilege.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_NO_MORE_ENTRIES</term>
		/// <term>There were no accounts with the specified privilege.</term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaenumerateaccountswithuserright NTSTATUS
		// LsaEnumerateAccountsWithUserRight( LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING UserRight, PVOID *Buffer, PULONG CountReturned );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "97e7180e-4edb-4edd-915e-0477e7e7a9ff")]
		// public static extern NTSTATUS LsaEnumerateAccountsWithUserRight(LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING UserRight, ref IntPtr
		// Buffer, ref uint CountReturned);
		public static extern uint LsaEnumerateAccountsWithUserRight(
			LSA_HANDLE PolicyHandle,
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string UserRight,
			out SafeLsaMemoryHandle Buffer,
			out int CountReturned);

		/// <summary>
		/// The LsaEnumerateAccountsWithUserRight function returns the accounts in the database of a Local Security Authority (LSA) Policy
		/// object that hold a specified privilege. The accounts returned by this function hold the specified privilege directly through the
		/// user account, not as part of membership to a group.
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have POLICY_LOOKUP_NAMES and POLICY_VIEW_LOCAL_INFORMATION user rights. For more
		/// information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="UserRights">
		/// A string that specifies the name of a privilege. For a list of privileges, see Privilege Constants and Account Rights Constants.
		/// <para>
		/// If this parameter is NULL, the function enumerates all accounts in the LSA database of the system associated with the Policy object.
		/// </para>
		/// </param>
		/// <returns>An enumeration of security identifiers (SID) of accounts that holds the specified privilege.</returns>
		public static IEnumerable<PSID> LsaEnumerateAccountsWithUserRight(LSA_HANDLE PolicyHandle, string UserRights)
		{
			var ret = LsaEnumerateAccountsWithUserRight(PolicyHandle, UserRights, out var mem, out var cnt);
			if (ret == NTStatus.STATUS_NO_MORE_ENTRIES) return new PSID[0];
			var wret = LsaNtStatusToWinError(ret);
			wret.ThrowIfFailed();
			return mem.DangerousGetHandle().ToIEnum<LSA_ENUMERATION_INFORMATION>(cnt).Select(u => u.Sid);
		}

		/// <summary>
		/// <para>
		/// The <c>LsaEnumerateTrustedDomains</c> function retrieves the names and SIDs of domains trusted to authenticate logon credentials.
		/// <c>LsaEnumerateTrustedDomains</c> is intended for use on systems running Windows NT 4.0 or earlier versions of Windows NT. Use
		/// DsEnumerateDomainTrusts for any other trust enumeration purpose. Specifically, <c>LsaEnumerateTrustedDomains</c> can only be used
		/// if one or more of the following is true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The calling system is running Windows NT 4.0 or an earlier version of Windows NT.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The target system (specified using the PolicyHandle parameter), is a domain controller running Windows NT 4.0 or an earlier version.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The calling system is running Windows NT 4.0 or earlier version and is not a domain controller, and the target system is a domain
		/// controller in the calling system's domain. The target system can be running any version of Windows NT, including Windows 2000 and
		/// Windows XP.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_VIEW_LOCAL_INFORMATION access right. For more information, see
		/// Opening a Policy Object Handle.
		/// </param>
		/// <param name="EnumerationContext">
		/// Pointer to an enumeration handle that enables you to make multiple calls to enumerate all the trusted domains. On the first call
		/// to <c>LsaEnumerateTrustedDomains</c>, EnumerationContext must point to a variable that has been initialized to zero. On
		/// subsequent calls to <c>LsaEnumerateTrustedDomains</c>, EnumerationContext must point to the enumeration handle returned by the
		/// previous call.
		/// </param>
		/// <param name="Buffer">
		/// <para>
		/// Receives a pointer to an array of LSA_TRUST_INFORMATION structures that contain the names and SIDs of one or more trusted domains.
		/// </para>
		/// <para>When you no longer need the information, pass the returned pointer to LsaFreeMemory.</para>
		/// </param>
		/// <param name="PreferedMaximumLength">
		/// Specifies the preferred maximum size, in bytes, of the returned buffer. This information is approximate; the actual number of
		/// bytes returned may be greater than this value.
		/// </param>
		/// <param name="CountReturned">Pointer to a variable that receives the number of elements returned in the Buffer parameter.</param>
		/// <returns>
		/// <para>If the function is successful, the return value is one of the following NTSTATUS values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_SUCCESS</term>
		/// <term>The enumeration has been successfully completed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_MORE_ENTRIES</term>
		/// <term>
		/// The call was successful, but there are more trusted domains to be enumerated. Call LsaEnumerateTrustedDomains again, passing the
		/// value returned in the EnumerationContext parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_NO_MORE_ENTRIES</term>
		/// <term>There are no more trusted domains to enumerate.</term>
		/// </item>
		/// </list>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For domains with domain controllers running only Windows NT 4.0 or earlier versions of Windows NT,
		/// <c>LsaEnumerateTrustedDomains</c> returns a list of all trusted domains. In releases of Windows NT up to and including release
		/// 4.0, all trusted domains are directly trusted.
		/// </para>
		/// <para>
		/// In Windows XP and Windows 2000 mixed-mode domains, domain controllers may be running Windows XP, Windows 2000, or Windows NT.
		/// Therefore, in mixed-mode domains, some trusted domains are directly trusted and others are indirectly trusted. When enumerating
		/// the trusted domains of a system in a mixed-mode domain, <c>LsaEnumerateTrustedDomains</c> returns only directly trusted domains.
		/// </para>
		/// <para>
		/// In contrast, Windows XP and Windows 2000 native-mode domains contain only Windows 2000 domain controllers, even though there may
		/// be members in the domain running Windows NT 4.0 or earlier versions. When enumerating the trusted domains of a system in a
		/// native-mode Windows XP and Windows 2000 domain, <c>LsaEnumerateTrustedDomains</c> returns both directly trusted and indirectly
		/// trusted domains.
		/// </para>
		/// <para>
		/// Retrieving all trust information may require more than a single <c>LsaEnumerateTrustedDomains</c> call. You can use the
		/// EnumerationContext parameter to make multiple calls, as follows: On the first call, set the variable pointed to by
		/// EnumerationContext to zero. If <c>LsaEnumerateTrustedDomains</c> returns STATUS_SUCCESS or STATUS_MORE_ENTRIES, call the function
		/// again, passing in the EnumerationContext value returned by the previous call. The enumeration is complete when the function
		/// returns STATUS_NO_MORE_ENTRIES.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaenumeratetrusteddomains NTSTATUS
		// LsaEnumerateTrustedDomains( LSA_HANDLE PolicyHandle, PLSA_ENUMERATION_HANDLE EnumerationContext, PVOID *Buffer, ULONG
		// PreferedMaximumLength, PULONG CountReturned );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "5c371d5a-26cf-4a99-a8e1-006b6b3cc91f")]
		public static extern NTStatus LsaEnumerateTrustedDomains(LSA_HANDLE PolicyHandle, ref LSA_ENUMERATION_HANDLE EnumerationContext, out SafeLsaMemoryHandle Buffer, uint PreferedMaximumLength, out uint CountReturned);

		/// <summary>
		/// <para>
		/// The <c>LsaEnumerateTrustedDomains</c> function retrieves the names and SIDs of domains trusted to authenticate logon credentials.
		/// <c>LsaEnumerateTrustedDomains</c> is intended for use on systems running Windows NT 4.0 or earlier versions of Windows NT. Use
		/// DsEnumerateDomainTrusts for any other trust enumeration purpose. Specifically, <c>LsaEnumerateTrustedDomains</c> can only be used
		/// if one or more of the following is true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The calling system is running Windows NT 4.0 or an earlier version of Windows NT.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The target system (specified using the PolicyHandle parameter), is a domain controller running Windows NT 4.0 or an earlier version.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The calling system is running Windows NT 4.0 or earlier version and is not a domain controller, and the target system is a domain
		/// controller in the calling system's domain. The target system can be running any version of Windows NT, including Windows 2000 and
		/// Windows XP.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_VIEW_LOCAL_INFORMATION access right. For more information, see
		/// Opening a Policy Object Handle.
		/// </param>
		/// <returns>An enumeration of LSA_TRUST_INFORMATION structures that contain the names and SIDs of one or more trusted domains.</returns>
		[PInvokeData("ntsecapi.h", MSDNShortId = "5c371d5a-26cf-4a99-a8e1-006b6b3cc91f")]
		public static IEnumerable<LSA_TRUST_INFORMATION> LsaEnumerateTrustedDomains(LSA_HANDLE PolicyHandle)
		{
			const uint maxBuf = 4096;
			var hEnum = LSA_ENUMERATION_HANDLE.NULL;
			NTStatus ret = NTStatus.STATUS_SUCCESS;
			while ((ret = LsaEnumerateTrustedDomains(PolicyHandle, ref hEnum, out var buf, maxBuf, out var count)) == NTStatus.STATUS_MORE_ENTRIES)
			{
				foreach (var i in buf.ToArray<LSA_TRUST_INFORMATION>((int)count))
					yield return i;
			}
			ret.ThrowIfFailed();
		}

		/// <summary>
		/// The <c>LsaEnumerateTrustedDomainsEx</c> function returns information about the domains trusted by the local system.
		/// <c>LsaEnumerateTrustedDomainsEx</c> returns information only on direct trusts. DsEnumerateDomainTrusts is recommended for more
		/// complete trust enumeration purposes.
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. This call requires POLICY_VIEW_LOCAL_INFORMATION access to the <c>Policy</c> object. For more
		/// information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="EnumerationContext">
		/// A pointer to an LSA_ENUMERATION_HANDLE that you can use to make multiple calls to <c>LsaEnumerateTrustedDomainsEx</c> to retrieve
		/// all of the trusted domain information. For more information, see Remarks.
		/// </param>
		/// <param name="Buffer">
		/// <para>
		/// Pointer to a buffer that receives a list of TRUSTED_DOMAIN_INFORMATION_EX structures that contain information about the
		/// enumerated trusted domains.
		/// </para>
		/// <para>Your application should free this buffer when it is no longer needed by calling LsaFreeMemory.</para>
		/// </param>
		/// <param name="PreferedMaximumLength">
		/// Preferred maximum length, in bytes, of returned data. This is not a hard upper limit, but serves as a guide. Due to data
		/// conversion between systems with different natural data sizes, the actual amount of data returned may be greater than this value.
		/// </param>
		/// <param name="CountReturned">Pointer to a <c>LONG</c> that receives the number of trusted domain objects returned.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, it returns an <c>NTSTATUS</c> code, which can be one of the following values or one of the LSA Policy
		/// Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>Caller does not have the appropriate access to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_NO_MORE_ENTRIES</term>
		/// <term>
		/// There are no more entries. This warning is returned if no objects have been enumerated because the EnumerationContext value is
		/// too high.
		/// </term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Retrieving all trust information may require more than a single <c>LsaEnumerateTrustedDomainsEx</c> call.</para>
		/// <para><c>To use the EnumerationContext parameter to make multiple calls</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Set the variable pointed to by EnumerationContext to zero.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If <c>LsaEnumerateTrustedDomainsEx</c> returns STATUS_SUCCESS or STATUS_MORE_ENTRIES, call the function again, passing in the
		/// EnumerationContext value returned by the previous call.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The enumeration is complete when the function returns STATUS_NO_MORE_ENTRIES.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaenumeratetrusteddomainsex NTSTATUS
		// LsaEnumerateTrustedDomainsEx( LSA_HANDLE PolicyHandle, PLSA_ENUMERATION_HANDLE EnumerationContext, PVOID *Buffer, ULONG
		// PreferedMaximumLength, PULONG CountReturned );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "4a203bff-c3e1-4d95-b556-617dc8c2e8c2")]
		public static extern NTStatus LsaEnumerateTrustedDomainsEx(LSA_HANDLE PolicyHandle, ref LSA_ENUMERATION_HANDLE EnumerationContext, out SafeLsaMemoryHandle Buffer, uint PreferedMaximumLength, out uint CountReturned);

		/// <summary>Gets system access for an account.</summary>
		/// <param name="AccountHandle">The account handle.</param>
		/// <param name="SystemAccess">The system access.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns one of the following <c>NTSTATUS</c> values.</para>
		/// </returns>
		[PInvokeData("ntlsa.h")]
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaGetSystemAccessAccount(LSA_HANDLE AccountHandle, out int SystemAccess);

		/// <summary>
		/// <para>
		/// The <c>LsaLookupNames</c> function retrieves the security identifiers (SIDs) that correspond to an array of user, group, or local
		/// group names.
		/// </para>
		/// <para>
		/// The <c>LsaLookupNames</c> function is superseded by the LsaLookupNames2 function. Applications should use the
		/// <c>LsaLookupNames2</c> function to ensure future compatibility.
		/// </para>
		/// <para>The <c>LsaLookupNames</c> function can also retrieve computer accounts.</para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a
		/// Policy Object Handle.
		/// </param>
		/// <param name="Count">
		/// Specifies the number of names in the Names array. This is also the number of entries returned in the Sids array.
		/// </param>
		/// <param name="Names">
		/// <para>
		/// Pointer to an array of LSA_UNICODE_STRING structures that contain the names to look up. The strings in these structures can be
		/// the names of user, group, or local group accounts, or the names of domains. Domain names can be DNS domain names or NetBIOS
		/// domain names.
		/// </para>
		/// <para>For more information about the format of the name strings, see Remarks.</para>
		/// </param>
		/// <param name="ReferencedDomains">
		/// <para>
		/// Receives a pointer to an LSA_REFERENCED_DOMAIN_LIST structure. The <c>Domains</c> member of this structure is an array that
		/// contains an entry for each domain in which a name was found. The <c>DomainIndex</c> member of each entry in the Sids array is the
		/// index of the <c>Domains</c> array entry for the domain in which the name was found.
		/// </para>
		/// <para>
		/// When you have finished using the returned pointer, free the memory by calling the LsaFreeMemory function. This memory must be
		/// freed even when the function fails with the either of the error codes <c>STATUS_NONE_MAPPED</c> or <c>STATUS_SOME_NOT_MAPPED</c>
		/// </para>
		/// </param>
		/// <param name="Sids">
		/// <para>
		/// Receives a pointer to an array of LSA_TRANSLATED_SID structures. Each entry in the Sids array contains the SID information for
		/// the corresponding entry in the Names array.
		/// </para>
		/// <para>
		/// When you have finished using the returned pointer, free the memory by calling the LsaFreeMemory function. This memory must be
		/// freed even when the function fails with the either of the error codes <c>STATUS_NONE_MAPPED</c> or <c>STATUS_SOME_NOT_MAPPED</c>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns one of the following <c>NTSTATUS</c> values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_SOME_NOT_MAPPED</term>
		/// <term>Some of the names could not be translated. This is an informational-level return value.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_SUCCESS</term>
		/// <term>All of the names were found and successfully translated.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the function fails, the return value is the following <c>NTSTATUS</c> value or one of the LSA Policy Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_NONE_MAPPED</term>
		/// <term>None of the names were translated.</term>
		/// </item>
		/// </list>
		/// <para>Use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use fully qualified account names (for example, domain_name\user_name) instead of isolated names (for example, user_name). Fully
		/// qualified names are unambiguous and provide better performance when the lookup is performed. This function also supports fully
		/// qualified DNS names (for example, example.example.com\user_name) and user principal names (UPN) (for example, someone@example.com).
		/// </para>
		/// <para>
		/// Translation of isolated names introduces the possibility of name collisions because the same name may be used in multiple
		/// domains. The <c>LsaLookupNames</c> function uses the following algorithm to translate isolated names
		/// </para>
		/// <para><c>To translate isolated names</c></para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// If the name is a well-known name, such as Local or Interactive, the function returns the corresponding well-known security
		/// identifier (SID).
		/// </term>
		/// </item>
		/// <item>
		/// <term>If the name is the name of the built-in domain, the function returns the SID of that domain.</term>
		/// </item>
		/// <item>
		/// <term>If the name is the name of the account domain, the function returns the SID of that domain.</term>
		/// </item>
		/// <item>
		/// <term>If the name is the name of the primary domain, the function returns the SID of that domain.</term>
		/// </item>
		/// <item>
		/// <term>If the name is one of the names of the trusted domain, the function returns the SID of that domain.</term>
		/// </item>
		/// <item>
		/// <term>If the name is a user, group, or local group account in the built-in domain, the function returns the SID of that account.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the name is a user, group, or local group account in the account domain on the local system, the function returns the SID of
		/// that account.
		/// </term>
		/// </item>
		/// <item>
		/// <term>If the name is a user, group, or a local group in the primary domain, the function returns the SID of that account.</term>
		/// </item>
		/// <item>
		/// <term>After looking in the primary domain, the primary domain looks in each of its trusted domains.</term>
		/// </item>
		/// <item>
		/// <term>Otherwise, the name is not translated.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In addition to looking up local accounts, local domain accounts, and explicitly trusted domain accounts, <c>LsaLookupNames</c>
		/// can look up the name of any account in any domain in the Windows forest.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that calls this function, see Translating Between Names and SIDs.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsalookupnames NTSTATUS LsaLookupNames( LSA_HANDLE
		// PolicyHandle, ULONG Count, PLSA_UNICODE_STRING Names, PLSA_REFERENCED_DOMAIN_LIST *ReferencedDomains, PLSA_TRANSLATED_SID *Sids );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "867604aa-7a39-4da7-b189-a9183461e9a0")]
		public static extern NTStatus LsaLookupNames(LSA_HANDLE PolicyHandle, uint Count, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringArrayMarshaler))] string[] Names,
			out SafeLsaMemoryHandle ReferencedDomains, out SafeLsaMemoryHandle Sids);

		/// <summary>
		/// <para>
		/// The <c>LsaLookupNames2</c> function retrieves the security identifiers (SIDs) for specified account names. <c>LsaLookupNames2</c>
		/// can look up the SID for any account in any domain in a Windows forest.
		/// </para>
		/// <para>
		/// The LsaLookupNames function is superseded by the <c>LsaLookupNames2</c> function. Applications should use the
		/// <c>LsaLookupNames2</c> function to ensure future compatibility.
		/// </para>
		/// <para>
		/// This function differs from the LsaLookupNames function in that <c>LsaLookupNames2</c> returns each SID as a single element, while
		/// <c>LsaLookupNames</c> divides each SID into an RID/domain pair.
		/// </para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// <para>
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a
		/// Policy Object Handle.
		/// </para>
		/// </param>
		/// <param name="Flags">
		/// <para>Values that control the behavior of this function. The following value is currently defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LSA_LOOKUP_ISOLATED_AS_LOCAL 0x80000000</term>
		/// <term>
		/// The function searches only on the local systems for names that do not specify a domain. The function does search on remote
		/// systems for names that do specify a domain.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Count">
		/// <para>Specifies the number of names in the Names array. This is also the number of entries returned in the Sids array.</para>
		/// </param>
		/// <param name="Names">
		/// <para>
		/// Pointer to an array of LSA_UNICODE_STRING structures that contain the names to look up. These strings can be the names of user,
		/// group, or local group accounts, or the names of domains. Domain names can be DNS domain names or NetBIOS domain names.
		/// </para>
		/// <para>For more information about the format of the name strings, see Remarks.</para>
		/// </param>
		/// <param name="ReferencedDomains">
		/// <para>
		/// Receives a pointer to an LSA_REFERENCED_DOMAIN_LIST structure. The <c>Domains</c> member of this structure is an array that
		/// contains an entry for each domain in which a name was found. The <c>DomainIndex</c> member of each entry in the Sids array is the
		/// index of the <c>Domains</c> array entry for the domain in which the name was found.
		/// </para>
		/// <para>
		/// When you have finished using the returned pointer, free it by calling the LsaFreeMemory function. This memory must be freed even
		/// when the function fails with the either of the error codes <c>STATUS_NONE_MAPPED</c> or <c>STATUS_SOME_NOT_MAPPED</c>
		/// </para>
		/// </param>
		/// <param name="Sids">
		/// <para>
		/// Receives a pointer to an array of LSA_TRANSLATED_SID2 structures. Each entry in the Sids array contains the SID information for
		/// the corresponding entry in the Names array.
		/// </para>
		/// <para>
		/// When you have finished using the returned pointer, free it by calling the LsaFreeMemory function. This memory must be freed even
		/// when the function fails with the either of the error codes <c>STATUS_NONE_MAPPED</c> or <c>STATUS_SOME_NOT_MAPPED</c>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns one of the following <c>NTSTATUS</c> values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_SOME_NOT_MAPPED</term>
		/// <term>Some of the names could not be translated. This is an informational-level return value.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_SUCCESS</term>
		/// <term>All of the names were found and successfully translated.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the function fails, the return value is the following <c>NTSTATUS</c> value or one of the LSA Policy Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_NONE_MAPPED</term>
		/// <term>None of the names were translated.</term>
		/// </item>
		/// </list>
		/// <para>Use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use fully qualified account names (for example, DomainName&lt;i&gt;UserName) instead of isolated names (for example, UserName).
		/// Fully qualified names are unambiguous and provide better performance when the lookup is performed. This function also supports
		/// fully qualified DNS names (for example, Example.Example.com&lt;i&gt;UserName) and user principal names (UPN) (for example, Someone@Example.com).
		/// </para>
		/// <para>
		/// Translation of isolated names introduces the possibility of name collisions because the same name may be used in multiple
		/// domains. The <c>LsaLookupNames2</c> function uses the following algorithm to translate isolated names.
		/// </para>
		/// <para><c>To translate isolated names</c></para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// If the name is a well-known name, such as Local or Interactive, the function returns the corresponding well-known security
		/// identifier (SID).
		/// </term>
		/// </item>
		/// <item>
		/// <term>If the name is the name of the built-in domain, the function returns the SID of that domain.</term>
		/// </item>
		/// <item>
		/// <term>If the name is the name of the account domain, the function returns the SID of that domain.</term>
		/// </item>
		/// <item>
		/// <term>If the name is the name of the primary domain, the function returns the SID of that domain.</term>
		/// </item>
		/// <item>
		/// <term>If the name is one of the names of the trusted domain, the function returns the SID of that domain.</term>
		/// </item>
		/// <item>
		/// <term>If the name is a user, group, or local group account in the built-in domain, the function returns the SID of that account.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the name is a user, group, or local group account in the account domain on the local system, the function returns the SID of
		/// that account.
		/// </term>
		/// </item>
		/// <item>
		/// <term>If the name is a user, group, or a local group in the primary domain, the function returns the SID of that account.</term>
		/// </item>
		/// <item>
		/// <term>After looking in the primary domain, the function looks in each of the primary domain's trusted domains.</term>
		/// </item>
		/// <item>
		/// <term>Otherwise, the name is not translated.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsalookupnames2 NTSTATUS LsaLookupNames2( LSA_HANDLE
		// PolicyHandle, ULONG Flags, ULONG Count, PLSA_UNICODE_STRING Names, PLSA_REFERENCED_DOMAIN_LIST *ReferencedDomains,
		// PLSA_TRANSLATED_SID2 *Sids );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "fe219070-6a00-4b8c-b2e4-2ad290a1cb9c")]
		// public static extern NTSTATUS LsaLookupNames2(LSA_HANDLE PolicyHandle, uint Flags, uint Count, PLSA_UNICODE_STRING Names, ref
		// PLSA_REFERENCED_DOMAIN_LIST ReferencedDomains, ref PLSA_TRANSLATED_SID2 Sids);
		public static extern uint LsaLookupNames2(
			LSA_HANDLE PolicyHandle,
			LsaLookupNamesFlags Flags,
			uint Count,
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringArrayMarshaler))]
			string[] Names,
			out SafeLsaMemoryHandle ReferencedDomains,
			out SafeLsaMemoryHandle Sids);

		/// <summary>
		/// <para>
		/// [ <c>LsaLookupSids</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
		/// unavailable in subsequent versions. Instead, use LsaLookupSids2.]
		/// </para>
		/// <para>
		/// The <c>LsaLookupSids</c> function looks up the names that correspond to an array of security identifiers (SIDs). If
		/// <c>LsaLookupSids</c> cannot find a name that corresponds to a SID, the function returns the SID in character form.
		/// </para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. This handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a
		/// Policy Object Handle.
		/// </param>
		/// <param name="Count">
		/// Specifies the number of SIDs in the Sids array. This is also the number of entries returned in the Names array.
		/// </param>
		/// <param name="Sids">
		/// Pointer to an array of SID pointers to look up. The SIDs can be well-known SIDs, user, group, or local group account SIDs, or
		/// domain SIDs.
		/// </param>
		/// <param name="ReferencedDomains">
		/// <para>
		/// Receives a pointer to a pointer to a LSA_REFERENCED_DOMAIN_LIST structure. The <c>Domains</c> member of this structure is an
		/// array that contains an entry for each domain in which a SID was found. The entry for each domain contains the SID and flat name
		/// of the domain. For Windows domains, the flat name is the NetBIOS name. For links with non–Windows domains, the flat name is the
		/// identifying name of that domain, or it is <c>NULL</c>.
		/// </para>
		/// <para>
		/// When you no longer need the information, pass the returned pointer to LsaFreeMemory. This memory must be freed even when the
		/// function fails with the either of the error codes <c>STATUS_NONE_MAPPED</c> or <c>STATUS_SOME_NOT_MAPPED</c>
		/// </para>
		/// </param>
		/// <param name="Names">
		/// <para>
		/// Receives a pointer to an array of LSA_TRANSLATED_NAME structures. Each entry in the Names array contains the name information for
		/// the corresponding entry in the Sids array. For account SIDs, the <c>Name</c> member of each structure contains the isolated name
		/// of the account. For domain SIDs, the <c>Name</c> member is not valid.
		/// </para>
		/// <para>
		/// The <c>DomainIndex</c> member of each entry in the Names array is the index of an entry in the <c>Domains</c> array returned in
		/// the ReferencedDomains parameter. The index identifies the <c>Domains</c> array for the domain in which the SID was found.
		/// </para>
		/// <para>
		/// When you no longer need the information, pass the returned pointer to LsaFreeMemory. This memory must be freed even when the
		/// function fails with the either of the error codes <c>STATUS_NONE_MAPPED</c> or <c>STATUS_SOME_NOT_MAPPED</c>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is one of the following <c>NTSTATUS</c> values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_SOME_NOT_MAPPED</term>
		/// <term>Some of the SIDs could not be translated. This is an informational-level return value.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_SUCCESS</term>
		/// <term>All of the SIDs were found and successfully translated.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the function fails, the return value is an <c>NTSTATUS</c> code, which can be one of the following values or one of the LSA
		/// Policy Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_NONE_MAPPED</term>
		/// <term>None of the SIDs were translated. This is an error-level return value.</term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For account SIDs, the string returned in the <c>Name</c> member is the isolated name of the account (for example, user_name). If
		/// you need the composite name of the account (for example, Acctg\user_name), get the domain name from the ReferencedDomains buffer
		/// and append a backslash and the isolated name.
		/// </para>
		/// <para>If the <c>LsaLookupSids</c> function cannot translate a SID, the function uses the following algorithm:</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// If the SID's domain is known, the ReferencedDomains buffer contains an entry for the domain, and the string returned in the Names
		/// parameter is a Unicode representation of the account's relative identifier (RID) from the SID.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the SID's domain is not known, the string returned in the Names parameter is a Unicode representation of the entire SID, and
		/// there is no domain record for this SID in the ReferencedDomains buffer.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// In addition to looking up SIDs for local accounts, local domain accounts, and explicitly trusted domain accounts,
		/// <c>LsaLookupSids</c> can look up SIDs for any account in any domain in the Windows forest, including SIDs that appear only in the
		/// <c>SIDhistory</c> field of an account in the forest. The <c>SIDhistory</c> field stores the former SIDs of an account that has
		/// been moved from another domain. To perform these searches, the function queries the global catalog of the forest.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsalookupsids NTSTATUS LsaLookupSids( LSA_HANDLE
		// PolicyHandle, ULONG Count, PSID *Sids, PLSA_REFERENCED_DOMAIN_LIST *ReferencedDomains, PLSA_TRANSLATED_NAME *Names );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "69051bad-91e7-469d-9010-48ac3d20f8af")]
		public static extern NTStatus LsaLookupSids(LSA_HANDLE PolicyHandle, uint Count, [In] PSID[] Sids, out SafeLsaMemoryHandle ReferencedDomains, out SafeLsaMemoryHandle Names);

		/// <summary>
		/// <para>
		/// The <c>LsaLookupSids2</c> function looks up the names that correspond to an array of security identifiers (SIDs) and supports
		/// Internet provider identities. If <c>LsaLookupSids2</c> cannot find a name that corresponds to a SID, the function returns the SID
		/// in character form. You should use this function instead of the LsaLookupSids function.
		/// </para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// <para>
		/// A handle to a Policy object. This handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a
		/// Policy Object Handle.
		/// </para>
		/// </param>
		/// <param name="LookupOptions">
		/// <para>Flags that modify the lookup behavior.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LSA_LOOKUP_DISALLOW_CONNECTED_ACCOUNT_INTERNET_SID</term>
		/// <term>
		/// Internet SIDs from identity providers for connected accounts are disallowed. Connected accounts are those accounts which have a
		/// corresponding shadow account in the local SAM database connected to an online identity provider. For example, MicrosoftAccount is
		/// a connected account.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LSA_LOOKUP_PREFER_INTERNET_NAMES</term>
		/// <term>
		/// Returns the internet names. Otherwise the NT4 style name (domain\username) is returned. The exception is if the Microsoft Account
		/// internet SID is specified, in which case the internet name is returned unless LSA_LOOKUP_DISALLOW_NON_WINDOWS_INTERNET_SID is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LSA_LOOKUP_RETURN_LOCAL_NAMES</term>
		/// <term>Always returns local SAM account names even for Internet provider identities.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Count">
		/// <para>Specifies the number of SIDs in the Sids array. This is also the number of entries returned in the Names array.</para>
		/// </param>
		/// <param name="Sids">
		/// <para>
		/// Pointer to an array of SID pointers to look up. The SIDs can be well-known SIDs, user, group, or local group account SIDs, or
		/// domain SIDs.
		/// </para>
		/// </param>
		/// <param name="ReferencedDomains">
		/// <para>
		/// Receives a pointer to a pointer to a LSA_REFERENCED_DOMAIN_LIST structure. The <c>Domains</c> member of this structure is an
		/// array that contains an entry for each domain in which a SID was found. The entry for each domain contains the SID and flat name
		/// of the domain. For Windows domains, the flat name is the NetBIOS name. For links with non–Windows domains, the flat name is the
		/// identifying name of that domain, or it is <c>NULL</c>.
		/// </para>
		/// <para>
		/// When you no longer need the information, pass the returned pointer to LsaFreeMemory. This memory must be freed even when the
		/// function fails with the either of the error codes <c>STATUS_NONE_MAPPED</c> or <c>STATUS_SOME_NOT_MAPPED</c>
		/// </para>
		/// </param>
		/// <param name="Names">
		/// <para>
		/// Receives a pointer to an array of LSA_TRANSLATED_NAME structures. Each entry in the Names array contains the name information for
		/// the corresponding entry in the Sids array. For account SIDs, the <c>Name</c> member of each structure contains the isolated name
		/// of the account. For domain SIDs, the <c>Name</c> member is not valid.
		/// </para>
		/// <para>
		/// The <c>DomainIndex</c> member of each entry in the Names array is the index of an entry in the <c>Domains</c> array returned in
		/// the ReferencedDomains parameter. The index identifies the <c>Domains</c> array for the domain in which the SID was found.
		/// </para>
		/// <para>
		/// When you no longer need the information, pass the returned pointer to LsaFreeMemory. This memory must be freed even when the
		/// function fails with the either of the error codes <c>STATUS_NONE_MAPPED</c> or <c>STATUS_SOME_NOT_MAPPED</c>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is one of the following <c>NTSTATUS</c> values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_SOME_NOT_MAPPED</term>
		/// <term>Some of the SIDs could not be translated. This is an informational-level return value.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_SUCCESS</term>
		/// <term>All of the SIDs were found and successfully translated.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the function fails, the return value is an <c>NTSTATUS</c> code, which can be one of the following values or one of the LSA
		/// Policy Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_NONE_MAPPED</term>
		/// <term>None of the SIDs were translated. This is an error-level return value.</term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The flag LSA_LOOKUP_PREFER_INTERNET_NAMES should be used for internet accounts such as MicrosoftAccount and Azure Active
		/// Directory accounts. When this flag is specified then SID-Name lookup returns the UPN of the account in the form
		/// MicrosoftAccount\foo@outlook.com or AzureAD\foo@contoso.com. For Microsoft Accounts both the local SAM SID and the internet SID
		/// result in the UPN being returned if this flag is specified. If LSA_LOOKUP_PREFER_INTERNET_NAMES is not specified then for AAD
		/// accounts the NT4 style name of the form AzureAD\foo is returned. The NT4 style name is machine specific and its usage should be
		/// carefully evaluated and if possible should be avoided. For MicrosoftAccounts if LSA_LOOKUP_PREFER_INTERNET_NAMES is not specified
		/// then the local SID of the account translates to the local SAM name, and the internet SID translates to the UPN name.
		/// </para>
		/// <para>
		/// For account SIDs, the string returned in the <c>Name</c> member is the isolated name of the account (for example, user_name). If
		/// you need the composite name of the account (for example, Acctg\user_name), get the domain name from the ReferencedDomains buffer
		/// and append a backslash and the isolated name.
		/// </para>
		/// <para>If the <c>LsaLookupSids2</c> function cannot translate a SID, the function uses the following algorithm:</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// If the SID's domain is known, the ReferencedDomains buffer contains an entry for the domain, and the string returned in the Names
		/// parameter is a Unicode representation of the account's relative identifier (RID) from the SID.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the SID's domain is not known, the string returned in the Names parameter is a Unicode representation of the entire SID, and
		/// there is no domain record for this SID in the ReferencedDomains buffer.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// In addition to looking up SIDs for local accounts, local domain accounts, and explicitly trusted domain accounts,
		/// <c>LsaLookupSids2</c> can look up SIDs for any account in any domain in the Windows forest, including SIDs that appear only in
		/// the <c>SIDhistory</c> field of an account in the forest. The <c>SIDhistory</c> field stores the former SIDs of an account that
		/// has been moved from another domain. To perform these searches, the function queries the global catalog of the forest.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsalookupsids2 NTSTATUS LsaLookupSids2( LSA_HANDLE
		// PolicyHandle, ULONG LookupOptions, ULONG Count, PSID *Sids, PLSA_REFERENCED_DOMAIN_LIST *ReferencedDomains, PLSA_TRANSLATED_NAME
		// *Names ); public static extern NTSTATUS LsaLookupSids2(LSA_HANDLE PolicyHandle, uint LookupOptions, uint Count, ref PSID Sids, ref
		// PLSA_REFERENCED_DOMAIN_LIST ReferencedDomains, ref PLSA_TRANSLATED_NAME Names);
		[PInvokeData("ntsecapi.h", MSDNShortId = "6B30D1FF-35DC-44E8-A765-36A5761EC0CE")]
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern uint LsaLookupSids2(
			LSA_HANDLE PolicyHandle,
			LsaLookupSidsFlags LookupOptions,
			uint Count,
			[In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] Sids,
			out SafeLsaMemoryHandle ReferencedDomains,
			out SafeLsaMemoryHandle Names);

		/// <summary>
		/// <para>The <c>LsaNtStatusToWinError</c> function converts an NTSTATUS code returned by an LSA function to a Windows error code.</para>
		/// </summary>
		/// <param name="Status">
		/// <para>An NTSTATUS code returned by an LSA function call. This value will be converted to a System error code.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// The return value is the Windows error code that corresponds to the Status parameter. If there is no corresponding Windows error
		/// code, the return value is ERROR_MR_MID_NOT_FOUND.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsantstatustowinerror ULONG LsaNtStatusToWinError(
		// NTSTATUS Status );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "fa91794c-c502-4b36-84cc-a8d77c8e9d9f")]
		// public static extern uint LsaNtStatusToWinError(NTSTATUS Status);
		public static extern Win32Error LsaNtStatusToWinError(uint Status);

		/// <summary>Undocumented. Opens an account.</summary>
		/// <param name="PolicyHandle">The policy handle.</param>
		/// <param name="AccountSid">The account sid.</param>
		/// <param name="DesiredAccess">The desired access.</param>
		/// <param name="AccountHandle">The account handle.</param>
		/// <returns>NTSTATUS</returns>
		[PInvokeData("ntlsa.h")]
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaOpenAccount(LSA_HANDLE PolicyHandle, PSID AccountSid, LsaAccountAccessMask DesiredAccess, out SafeLSA_HANDLE AccountHandle);

		/// <summary>
		/// <para>The <c>LsaOpenPolicy</c> function opens a handle to the Policy object on a local or remote system.</para>
		/// <para>You must run the process "As Administrator" so that the call doesn't fail with ERROR_ACCESS_DENIED.</para>
		/// </summary>
		/// <param name="SystemName">
		/// <para>
		/// A pointer to an LSA_UNICODE_STRING structure that contains the name of the target system. The name can have the form
		/// "ComputerName" or "\ComputerName". If this parameter is <c>NULL</c>, the function opens the Policy object on the local system.
		/// </para>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an LSA_OBJECT_ATTRIBUTES structure that specifies the connection attributes. The structure members are not used;
		/// initialize them to <c>NULL</c> or zero.
		/// </para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK that specifies the requested access rights. The function fails if the DACL of the target system does not allow the
		/// caller the requested access. To determine the access rights that you need, see the documentation for the LSA functions with which
		/// you want to use the policy handle.
		/// </para>
		/// </param>
		/// <param name="PolicyHandle">
		/// <para>A pointer to an LSA_HANDLE variable that receives a handle to the Policy object.</para>
		/// <para>When you no longer need this handle, pass it to the LsaClose function to close it.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns STATUS_SUCCESS.</para>
		/// <para>If the function fails, it returns an <c>NTSTATUS</c> code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To administer the local security policy of a local or remote system, you must call the <c>LsaOpenPolicy</c> function to establish
		/// a session with that system's LSA subsystem. <c>LsaOpenPolicy</c> connects to the LSA of the target system and returns a handle to
		/// the Policy object of that system. You can use this handle in subsequent LSA function calls to administer the local security
		/// policy information of the target system.
		/// </para>
		/// <para>For an example that demonstrates calling this function see Opening a Policy Object Handle.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaopenpolicy NTSTATUS LsaOpenPolicy(
		// PLSA_UNICODE_STRING SystemName, PLSA_OBJECT_ATTRIBUTES ObjectAttributes, ACCESS_MASK DesiredAccess, PLSA_HANDLE PolicyHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "361bc962-1e97-4606-a835-cbce37692c55")]
		// public static extern NTSTATUS LsaOpenPolicy(PLSA_UNICODE_STRING SystemName, PLSA_OBJECT_ATTRIBUTES ObjectAttributes, ACCESS_MASK
		// DesiredAccess, PLSA_HANDLE PolicyHandle);
		public static extern uint LsaOpenPolicy(
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string SystemName,
			ref LSA_OBJECT_ATTRIBUTES ObjectAttributes,
			LsaPolicyRights DesiredAccess,
			out SafeLSA_HANDLE PolicyHandle);

		/// <summary>
		/// The LsaOpenPolicy function opens a handle to the Policy object on a local or remote system. You must run the process "As
		/// Administrator" so that the call doesn't fail with ERROR_ACCESS_DENIED.
		/// </summary>
		/// <param name="DesiredAccess">
		/// An ACCESS_MASK that specifies the requested access rights. The function fails if the DACL of the target system does not allow the
		/// caller the requested access. To determine the access rights that you need, see the documentation for the LSA functions with which
		/// you want to use the policy handle.
		/// </param>
		/// <param name="SystemName">
		/// Name of the target system. The name can have the form "ComputerName" or "\\ComputerName". If this parameter is NULL, the function
		/// opens the Policy object on the local system.
		/// </param>
		/// <returns>A pointer to an LSA_HANDLE variable that receives a handle to the Policy object.</returns>
		public static SafeLSA_HANDLE LsaOpenPolicy(LsaPolicyRights DesiredAccess, string SystemName = null)
		{
			var oa = LSA_OBJECT_ATTRIBUTES.Empty;
			LsaNtStatusToWinError(LsaOpenPolicy(SystemName, ref oa, DesiredAccess, out var handle)).ThrowIfFailed();
			return handle;
		}

		/// <summary>
		/// The <c>LsaOpenTrustedDomainByName</c> function opens the LSA policy handle of a remote trusted domain. You can pass this handle
		/// into LSA function calls in order to set or query the LSA policy of the remote machine.
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. This is the policy handle of the local machine. For more information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="TrustedDomainName">
		/// Name of the trusted domain. This name can be either the flat name, or the Domain Name System (DNS) domain name.
		/// </param>
		/// <param name="DesiredAccess">
		/// An ACCESS_MASK structure that specifies the access permissions requested on the remote trusted domain object.
		/// </param>
		/// <param name="TrustedDomainHandle">
		/// <para>
		/// Pointer that receives the address of the LSA policy handle of the remote trusted domain. You can pass this handle into LSA
		/// function calls in order to query and manage the LSA policy of the remote machine.
		/// </para>
		/// <para>When your application no longer needs this handle, it should call LsaClose to delete the handle.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is an NTSTATUS code, which can be one of the following values or one of the LSA Policy
		/// Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>Caller does not have the appropriate access to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_NOT_FOUND</term>
		/// <term>There is no Trusted Domain object in the target system's LSA Database having the specified name.</term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaopentrusteddomainbyname NTSTATUS
		// LsaOpenTrustedDomainByName( LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING TrustedDomainName, ACCESS_MASK DesiredAccess, PLSA_HANDLE
		// TrustedDomainHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "6c55f8b4-d8a2-48e3-8074-b3ca22ce487a")]
		public static extern NTStatus LsaOpenTrustedDomainByName(LSA_HANDLE PolicyHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string TrustedDomainName, ACCESS_MASK DesiredAccess, out SafeLSA_HANDLE TrustedDomainHandle);

		/// <summary>The <c>LsaQueryDomainInformationPolicy</c> function retrieves domain information from the Policyobject.</summary>
		/// <param name="PolicyHandle">A handle to the Policy object for the system.</param>
		/// <param name="InformationClass">
		/// <para>
		/// POLICY_DOMAIN_INFORMATION_CLASS enumeration that specifies the information to be returned from the Policyobject. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PolicyDomainEfsInformation</term>
		/// <term>The information is for Encrypting File System.</term>
		/// </item>
		/// <item>
		/// <term>PolicyDomainKerberosTicketInformation</term>
		/// <term>The information is for a Kerberos ticket.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Buffer">Pointer to a buffer that receives the requested information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is an NTSTATUS code, which can be the following value or one of the LSA Policy Function
		/// Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INTERNAL_DB_CORRUPTION</term>
		/// <term>The policy database is corrupt. The returned policy information is not valid for the given class.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The POLICY_VIEW_LOCAL_INFORMATION access type is required to retrieve domain information from the Policyobject. For more
		/// information, see Policy Object Access Rights.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaquerydomaininformationpolicy NTSTATUS
		// LsaQueryDomainInformationPolicy( LSA_HANDLE PolicyHandle, POLICY_DOMAIN_INFORMATION_CLASS InformationClass, PVOID *Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "39a511d7-46fc-4d12-ba43-771f6db2a33b")]
		public static extern NTStatus LsaQueryDomainInformationPolicy(LSA_HANDLE PolicyHandle, POLICY_DOMAIN_INFORMATION_CLASS InformationClass, out IntPtr Buffer);

		/// <summary>
		/// The <c>LsaQueryForestTrustInformation</c> function retrieves forest trust information for the specified Local Security Authority
		/// TrustedDomain object.
		/// </summary>
		/// <param name="PolicyHandle">A handle to the Policy object for the system.</param>
		/// <param name="TrustedDomainName">
		/// Pointer to an LSA_UNICODE_STRING structure that contains the name of the TrustedDomain object for which to retrieve forest trust information.
		/// </param>
		/// <param name="ForestTrustInfo">
		/// Pointer to an LSA_FOREST_TRUST_INFORMATION structure that returns the forest trust information for the TrustedDomain object
		/// specified by the TrustedDomainName parameter.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is an NTSTATUS code, which can be one of the following values or one of the LSA Policy
		/// Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_DOMAIN_ROLE</term>
		/// <term>The operation is legal only on the primary domain controller.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_DOMAIN_STATE</term>
		/// <term>The operation is legal only on domain controllers in the root domain.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_NO_SUCH_DOMAIN</term>
		/// <term>The specified TrustedDomain object does not exist.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_NOT_FOUND</term>
		/// <term>The specified TrustedDomain object does not contain forest trust information.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Access to this function is protected by a securable object.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaqueryforesttrustinformation NTSTATUS
		// LsaQueryForestTrustInformation( LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING TrustedDomainName, PLSA_FOREST_TRUST_INFORMATION
		// *ForestTrustInfo );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "38857f1f-e2c7-4ce5-a928-335bc3bd2176")]
		public static extern NTStatus LsaQueryForestTrustInformation(LSA_HANDLE PolicyHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string TrustedDomainName,
			out SafeLsaMemoryHandle ForestTrustInfo);

		/// <summary>The <c>LsaQueryInformationPolicy</c> function retrieves information about a Policy object.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The required access rights for this handle depend on the value of the InformationClass parameter.
		/// For more information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="InformationClass">
		/// <para>
		/// Specifies one of the following values from the POLICY_INFORMATION_CLASS enumeration type. The value indicates the type of
		/// information to retrieve.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PolicyAuditEventsInformation</term>
		/// <term>
		/// Retrieves the system's auditing rules. The handle passed in the PolicyHandle parameter must have the
		/// POLICY_VIEW_AUDIT_INFORMATION access right. The Buffer parameter receives a pointer to a POLICY_AUDIT_EVENTS_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PolicyPrimaryDomainInformation</term>
		/// <term>
		/// Retrieves the name and SID of the system's primary domain. The handle passed in the PolicyHandle parameter must have the
		/// POLICY_VIEW_LOCAL_INFORMATION access right. The Buffer parameter receives a pointer to a POLICY_PRIMARY_DOMAIN_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PolicyAccountDomainInformation</term>
		/// <term>
		/// Retrieves the name and SID of the system's account domain. The handle passed in the PolicyHandle parameter must have the
		/// POLICY_VIEW_LOCAL_INFORMATION access right. The Buffer parameter receives a pointer to a POLICY_ACCOUNT_DOMAIN_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PolicyLsaServerRoleInformation</term>
		/// <term>
		/// Retrieves the role of an LSA server. The handle passed in the PolicyHandle parameter must have the POLICY_VIEW_LOCAL_INFORMATION
		/// access right. The Buffer parameter receives a pointer to a POLICY_LSA_SERVER_ROLE_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PolicyModificationInformation</term>
		/// <term>
		/// Retrieves information about the creation time and last modification of the LSA database. The handle passed in the PolicyHandle
		/// parameter must have the POLICY_VIEW_LOCAL_INFORMATION access right. The Buffer parameter receives a pointer to a
		/// POLICY_MODIFICATION_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PolicyDnsDomainInformation</term>
		/// <term>
		/// Retrieves the Domain Name System (DNS) information about the primary domain associated with the Policy object. The handle passed
		/// in the PolicyHandle parameter must have the POLICY_VIEW_LOCAL_INFORMATION access right. The Buffer parameter receives a pointer
		/// to a POLICY_DNS_DOMAIN_INFO structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Buffer">
		/// <para>
		/// Pointer to a variable that receives a pointer to a structure containing the requested information. The type of structure depends
		/// on the value of the InformationClass parameter.
		/// </para>
		/// <para>When you no longer need the information, pass the returned pointer to LsaFreeMemory.</para>
		/// </param>
		/// <returns>
		/// <para>If the <c>LsaQueryInformationPolicy</c> function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		/// <remarks>For an example that demonstrates calling this function see Managing Policy Information.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaqueryinformationpolicy NTSTATUS
		// LsaQueryInformationPolicy( LSA_HANDLE PolicyHandle, POLICY_INFORMATION_CLASS InformationClass, PVOID *Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "2d543500-f639-4ef7-91f4-cdc5060dd567")]
		public static extern NTStatus LsaQueryInformationPolicy(LSA_HANDLE PolicyHandle, POLICY_INFORMATION_CLASS InformationClass, out SafeLsaMemoryHandle Buffer);

		/// <summary>
		/// <para>The <c>LsaQueryTrustedDomainInfo</c> function retrieves information about a trusted domain.</para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// <para>
		/// A handle to the Policy object of a domain controller that has a trust relationship with the domain identified by the
		/// TrustedDomainSid parameter. The handle must have the POLICY_VIEW_LOCAL_INFORMATION access right. For more information, see
		/// Opening a Policy Object Handle.
		/// </para>
		/// </param>
		/// <param name="TrustedDomainSid">
		/// <para>Pointer to the SID of the trusted domain to query.</para>
		/// </param>
		/// <param name="InformationClass">
		/// <para>
		/// Specifies one of the following values from the TRUSTED_INFORMATION_CLASS enumeration type. The value indicates the type of
		/// information being requested.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TrustedDomainNameInformation</term>
		/// <term>Retrieves the name of the trusted domain. The Buffer parameter receives a pointer to a TRUSTED_DOMAIN_NAME_INFO structure.</term>
		/// </item>
		/// <item>
		/// <term>TrustedPosixOffsetInformation</term>
		/// <term>
		/// Retrieves the value used to generate Posix user and group identifiers for the trusted domain. The Buffer parameter receives a
		/// pointer to a TRUSTED_POSIX_OFFSET_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TrustedPasswordInformation</term>
		/// <term>
		/// Retrieves the password for the trusted domain. The Buffer parameter receives a pointer to a TRUSTED_PASSWORD_INFO structure. The
		/// handle passed in the PolicyHandle parameter must have the POLICY_GET_PRIVATE_INFORMATION access right.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TrustedDomainInformationEx</term>
		/// <term>
		/// Retrieves extended information for the trusted domain. The Buffer parameter receives a pointer to a TRUSTED_DOMAIN_INFORMATION_EX structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TrustedDomainInformationBasic</term>
		/// <term>This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>TrustedDomainFullInformation</term>
		/// <term>
		/// Retrieves complete information for the trusted domain. This information includes the Posix offset information, authentication
		/// information, and the extended information returned for the TrustedDomainInformationEx value. The Buffer parameter receives a
		/// pointer to a TRUSTED_DOMAIN_FULL_INFORMATION structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Buffer">
		/// <para>
		/// A pointer to a buffer that receives a pointer to a structure that contains the requested information. The type of structure
		/// depends on the value of the InformationClass parameter.
		/// </para>
		/// <para>When you have finished using the information, free the returned pointer by passing it to LsaFreeMemory.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, it returns an <c>NTSTATUS</c> value that indicates the error. For more information, see LSA Policy
		/// Function Return Values.
		/// </para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> value to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaquerytrusteddomaininfo NTSTATUS
		// LsaQueryTrustedDomainInfo( LSA_HANDLE PolicyHandle, PSID TrustedDomainSid, TRUSTED_INFORMATION_CLASS InformationClass, PVOID
		// *Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "62925515-a6f3-4b5f-bf97-edb968af19a3")]
		public static extern NTStatus LsaQueryTrustedDomainInfo(LSA_HANDLE PolicyHandle, PSID TrustedDomainSid, TRUSTED_INFORMATION_CLASS InformationClass, out SafeLsaMemoryHandle Buffer);

		/// <summary>The <c>LsaQueryTrustedDomainInfoByName</c> function returns information about a trusted domain.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. This handle must have the POLICY_VIEW_LOCAL_INFORMATION access right. For more information, see
		/// Opening a Policy Object Handle.
		/// </param>
		/// <param name="TrustedDomainName">
		/// String that contains the name of the trusted domain. This can either be the domain name or the flat name.
		/// </param>
		/// <param name="InformationClass">
		/// <para>Specifies the type of information to retrieve. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TrustedDomainNameInformation</term>
		/// <term>Name of the trusted domain.</term>
		/// </item>
		/// <item>
		/// <term>TrustedPosixInformation</term>
		/// <term>Posix offset of the trusted domain.</term>
		/// </item>
		/// <item>
		/// <term>TrustedPasswordInformation</term>
		/// <term>Returns the password on the outbound side of the trust.</term>
		/// </item>
		/// <item>
		/// <term>TrustedDomainInformationBasic</term>
		/// <term>This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>TrustedDomainInformationEx</term>
		/// <term>Extended trust information, including the basic information and DNS domain name, and attributes about the trust.</term>
		/// </item>
		/// <item>
		/// <term>TrustedDomainFullInformation</term>
		/// <term>Full information, including the Posix offset and the authentication information.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Buffer">
		/// <para>
		/// Receives a pointer to the returned buffer that contains the requested information. The format and content of this buffer depend
		/// on the information class. For example, if InformationClass is set to TrustedDomainInformationEx, Buffer receives a pointer to a
		/// TRUSTED_DOMAIN_INFORMATION_EX structure. For more information, see TRUSTED_INFORMATION_CLASS.
		/// </para>
		/// <para>When you have finished using the buffer, free it by calling the LsaFreeMemory function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, it returns an <c>NTSTATUS</c> value, which can be one of the following values or one of the LSA Policy
		/// Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>
		/// Caller does not have the appropriate access to complete the operation. For a list of the required access types, see the
		/// description of the InformationClass parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_INSUFFICIENT_ RESOURCES</term>
		/// <term>Insufficient system resources, such as memory, to complete the call.</term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> value to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaquerytrusteddomaininfobyname NTSTATUS
		// LsaQueryTrustedDomainInfoByName( LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING TrustedDomainName, TRUSTED_INFORMATION_CLASS
		// InformationClass, PVOID *Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "d33d6cee-bd8b-49f4-8e65-07cdc65bec7c")]
		public static extern NTStatus LsaQueryTrustedDomainInfoByName(LSA_HANDLE PolicyHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string TrustedDomainName, TRUSTED_INFORMATION_CLASS InformationClass, out SafeLsaMemoryHandle Buffer);

		/// <summary>
		/// <para>
		/// The <c>LsaRemoveAccountRights</c> function removes one or more privileges from an account. You can specify the privileges to be
		/// removed, or you can set a flag to remove all privileges. When you remove all privileges, the function deletes the account. If you
		/// specify privileges not held by the account, the function ignores them.
		/// </para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// <para>
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a
		/// Policy Object Handle.
		/// </para>
		/// </param>
		/// <param name="AccountSid">
		/// <para>Pointer to the security identifier (SID) of the account from which the privileges are removed.</para>
		/// </param>
		/// <param name="AllRights">
		/// <para>
		/// If <c>TRUE</c>, the function removes all privileges and deletes the account. In this case, the function ignores the UserRights
		/// parameter. If <c>FALSE</c>, the function removes the privileges specified by the UserRights parameter.
		/// </para>
		/// </param>
		/// <param name="UserRights">
		/// <para>
		/// Pointer to an array of LSA_UNICODE_STRING structures. Each structure contains the name of a privilege to be removed from the
		/// account. For a list of privilege names, see Privilege Constants.
		/// </para>
		/// </param>
		/// <param name="CountOfRights">
		/// <para>Specifies the number of elements in the UserRights array.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is an NTSTATUS code, which can be one of the following values or one of the LSA Policy
		/// Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_NO_SUCH_PRIVILEGE</term>
		/// <term>One of the privilege names is not valid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>Indicates the UserRights parameter was NULL and the AllRights parameter was FALSE.</term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaremoveaccountrights NTSTATUS LsaRemoveAccountRights(
		// LSA_HANDLE PolicyHandle, PSID AccountSid, BOOLEAN AllRights, PLSA_UNICODE_STRING UserRights, ULONG CountOfRights );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "ad250a01-7a24-4fae-975c-aa3e65731c82")]
		// public static extern NTSTATUS LsaRemoveAccountRights(LSA_HANDLE PolicyHandle, PSID AccountSid, [MarshalAs(UnmanagedType.U1)] bool
		// AllRights, PLSA_UNICODE_STRING UserRights, uint CountOfRights);
		public static extern uint LsaRemoveAccountRights(
			LSA_HANDLE PolicyHandle,
			PSID AccountSid,
			[MarshalAs(UnmanagedType.Bool)] bool AllRights,
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringArrayMarshaler))]
			string[] UserRights,
			int CountOfRights);

		/// <summary>Do not use the LSA private data functions. Instead, use the CryptProtectData and CryptUnprotectData functions.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_GET_PRIVATE_INFORMATION access right. For more information, see
		/// Opening a Policy Object Handle.
		/// </param>
		/// <param name="KeyName">
		/// <para>Pointer to an LSA_UNICODE_STRING structure that contains the name of the key under which the private data is stored.</para>
		/// <para>To create a specialized object, add one of the following prefixes to the key name.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Prefix</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>L$</term>
		/// <term>For local objects.</term>
		/// </item>
		/// <item>
		/// <term>G$</term>
		/// <term>For global objects.</term>
		/// </item>
		/// <item>
		/// <term>M$</term>
		/// <term>For computer objects.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If you are not creating one of these specialized types, you do not need to specify a key name prefix. For more information, see
		/// Private Data Object.
		/// </para>
		/// </param>
		/// <param name="PrivateData">
		/// <para>Pointer to a variable that receives a pointer to an LSA_UNICODE_STRING structure that contains the private data.</para>
		/// <para>When you no longer need the information, pass the returned pointer to LsaFreeMemory.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, it returns an <c>NTSTATUS</c> value, which can be the following value or one of the LSA Policy Function
		/// Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_NOT_FOUND</term>
		/// <term>No private data is stored under the name specified by the KeyName parameter.</term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the <c>NTSTATUS</c> value to a Windows error code.</para>
		/// </returns>
		/// <remarks>You must run this process "As Administrator" or the call fails with ERROR_ACCESS_DENIED.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaretrieveprivatedata NTSTATUS LsaRetrievePrivateData(
		// LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING KeyName, PLSA_UNICODE_STRING *PrivateData );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "005460db-0919-46eb-b057-37c5b6042243")]
		public static extern NTStatus LsaRetrievePrivateData(LSA_HANDLE PolicyHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string KeyName, [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] out string PrivateData);

		/// <summary>The <c>LsaSetDomainInformationPolicy</c> function sets domain information to the Policyobject.</summary>
		/// <param name="PolicyHandle">A handle to the Policy object for the system.</param>
		/// <param name="InformationClass">
		/// <para>
		/// POLICY_DOMAIN_INFORMATION_CLASS enumeration that specifies the information to be set to the Policyobject. The following table
		/// shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PolicyDomainEfsInformation</term>
		/// <term>The information is for Encrypting File System.</term>
		/// </item>
		/// <item>
		/// <term>PolicyDomainKerberosTicketInformation</term>
		/// <term>The information is for a Kerberos ticket.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Buffer">Pointer to a buffer that contains the information to set to the Policyobject.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is an NTSTATUS code, which can be the following value or one of the LSA Policy Function
		/// Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INTERNAL_DB_CORRUPTION</term>
		/// <term>The policy database is corrupt. The returned policy information is not valid for the given class.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The POLICY_TRUST_ADMIN access type is required to set domain information to the Policyobject. For more information, see Policy
		/// Object Access Rights.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsasetdomaininformationpolicy NTSTATUS
		// LsaSetDomainInformationPolicy( LSA_HANDLE PolicyHandle, POLICY_DOMAIN_INFORMATION_CLASS InformationClass, PVOID Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "77af6fdc-a52e-476c-9de2-36ee48133a87")]
		public static extern NTStatus LsaSetDomainInformationPolicy(LSA_HANDLE PolicyHandle, POLICY_DOMAIN_INFORMATION_CLASS InformationClass, IntPtr Buffer);

		/// <summary>
		/// <para>
		/// The <c>LsaSetForestTrustInformation</c> function sets the forest trust information for a specified Local Security Authority
		/// TrustedDomain object.
		/// </para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// <para>A handle to the Policy object for the system.</para>
		/// </param>
		/// <param name="TrustedDomainName">
		/// <para>
		/// Pointer to an LSA_UNICODE_STRING structure that contains the name of the TrustedDomain object to which to set the forest trust
		/// information specified by the ForestTrustInfo parameter.
		/// </para>
		/// </param>
		/// <param name="ForestTrustInfo">
		/// <para>
		/// Pointer to an LSA_FOREST_TRUST_INFORMATION structure that contains the forest trust information to set to the TrustedDomain
		/// object specified by the TrustedDomainName parameter.
		/// </para>
		/// </param>
		/// <param name="CheckOnly">
		/// <para>
		/// Boolean value that specifies whether changes to the TrustedDomain object are persisted. If this value is <c>TRUE</c>, this
		/// function will check for collisions with the specified parameters but will not set the forest trust information specified by the
		/// ForestTrustInfo parameter to the <c>TrustedDomain</c> object specified by the TrustedDomainName parameter. If this value is
		/// <c>FALSE</c>, the forest trust information will be set to the <c>TrustedDomain</c> object.
		/// </para>
		/// </param>
		/// <param name="CollisionInfo">
		/// <para>
		/// Pointer to a pointer to an LSA_FOREST_TRUST_COLLISION_INFORMATION structure that returns information about any collisions that occurred.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is an NTSTATUS code, which can be one of the following values or one of the LSA Policy
		/// Function Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_DOMAIN_STATE</term>
		/// <term>The operation is legal only on domain controllers in the root domain.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_DOMAIN_ROLE</term>
		/// <term>The operation is legal only on the primary domain controller.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsasetforesttrustinformation NTSTATUS
		// LsaSetForestTrustInformation( LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING TrustedDomainName, PLSA_FOREST_TRUST_INFORMATION
		// ForestTrustInfo, BOOLEAN CheckOnly, PLSA_FOREST_TRUST_COLLISION_INFORMATION *CollisionInfo );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "8b0f90ed-7dd4-4803-97c6-31d191b6d2b3")]
		public static extern NTStatus LsaSetForestTrustInformation(LSA_HANDLE PolicyHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string TrustedDomainName,
			in LSA_FOREST_TRUST_INFORMATION ForestTrustInfo, [MarshalAs(UnmanagedType.U1)] bool CheckOnly, out SafeLsaMemoryHandle CollisionInfo);

		/// <summary>The <c>LsaSetInformationPolicy</c> function modifies information in a Policy object.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The required access rights for this handle depend on the value of the InformationClass parameter.
		/// For more information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="InformationClass">
		/// <para>
		/// Specifies one of the following values from the POLICY_INFORMATION_CLASS enumeration type. The value indicates the type of
		/// information to set.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PolicyAuditEventsInformation</term>
		/// <term>
		/// Sets the system's auditing rules. The handle passed in the PolicyHandle parameter must have the POLICY_SET_AUDIT_REQUIREMENTS
		/// access right. The Buffer parameter must be a pointer to a POLICY_AUDIT_EVENTS_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PolicyPrimaryDomainInformation</term>
		/// <term>
		/// Sets the name and SID of the system's primary domain. The handle passed in the PolicyHandle parameter must have the
		/// POLICY_TRUST_ADMIN access right. The Buffer parameter must be a pointer to a POLICY_PRIMARY_DOMAIN_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PolicyAccountDomainInformation</term>
		/// <term>
		/// Sets the name and SID of the system's account domain. The handle passed in the PolicyHandle parameter must have the
		/// POLICY_TRUST_ADMIN access right. The Buffer parameter must be a pointer to a POLICY_ACCOUNT_DOMAIN_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PolicyDnsDomainInformation</term>
		/// <term>
		/// Sets Domain Name System (DNS) information about the primary domain associated with the Policy object. The handle passed in the
		/// PolicyHandle parameter must have the POLICY_TRUST_ADMIN access right. The Buffer parameter must be a pointer to a
		/// POLICY_DNS_DOMAIN_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PolicyLsaServerRoleInformation</term>
		/// <term>
		/// Sets the role of an LSA server. The handle passed in the PolicyHandle parameter must have the POLICY_SERVER_ADMIN access right.
		/// The Buffer parameter must be a pointer to a POLICY_LSA_SERVER_ROLE_INFO structure. Changing a server's role from primary to
		/// backup has no effect (although the function returns STATUS_SUCCESS). Changing a server's role from backup to primary requires
		/// extensive network operations and may be slow.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Buffer">
		/// Pointer to a structure containing the information to set. The type of structure depends on the value of the InformationClass parameter.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsasetinformationpolicy NTSTATUS
		// LsaSetInformationPolicy( LSA_HANDLE PolicyHandle, POLICY_INFORMATION_CLASS InformationClass, PVOID Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "2aa3b09e-2cd9-4a09-bfd6-b37c97266dcb")]
		public static extern NTStatus LsaSetInformationPolicy(LSA_HANDLE PolicyHandle, POLICY_INFORMATION_CLASS InformationClass, IntPtr Buffer);

		/// <summary>Undocumented.</summary>
		/// <param name="AccountHandle">The account handle.</param>
		/// <param name="SystemAccess">The system access.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code, which
		/// can be one of the following values or one of the LSA Policy Function Return Values.
		/// </returns>
		[PInvokeData("ntlsa.h")]
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaSetSystemAccessAccount(LSA_HANDLE AccountHandle, int SystemAccess);

		/// <summary>The <c>LsaSetTrustedDomainInfoByName</c> function sets values for a TrustedDomain object.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The security descriptor of the trusted domain object determines whether the caller's changes are
		/// accepted. For information about policy object handles, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="TrustedDomainName">
		/// Name of the trusted domain to set values for. This can either be the domain name or the flat name.
		/// </param>
		/// <param name="InformationClass">
		/// <para>Specifies the type of information to set. Specify one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TrustedPosixInformation</term>
		/// <term>Posix offset of the trusted domain.</term>
		/// </item>
		/// <item>
		/// <term>TrustedDomainInformationEx</term>
		/// <term>Extended trust information, including the basic information and DNS domain name, and attributes about the trust.</term>
		/// </item>
		/// <item>
		/// <term>TrustedDomainAuthInformation</term>
		/// <term>
		/// Authentication information for the trust, including authentication information for both the inbound and outbound side of the
		/// trust (if it exists).
		/// </term>
		/// </item>
		/// <item>
		/// <term>TrustedDomainFullInformation</term>
		/// <term>Full information, including the Posix offset and the authentication information.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Buffer">
		/// Pointer to a structure that contains the information to set. The type of structure depends on the value of the InformationClass parameter.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is an NTSTATUS code. For more information, see the "LSA Policy Function Return Values"
		/// section of Security Management Return Values.
		/// </para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsasettrusteddomaininfobyname NTSTATUS
		// LsaSetTrustedDomainInfoByName( LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING TrustedDomainName, TRUSTED_INFORMATION_CLASS
		// InformationClass, PVOID Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "263e1025-1010-463d-8bc7-cdf916ce9872")]
		public static extern NTStatus LsaSetTrustedDomainInfoByName(LSA_HANDLE PolicyHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string TrustedDomainName,
			TRUSTED_INFORMATION_CLASS InformationClass, IntPtr Buffer);

		/// <summary>
		/// <para>The <c>LsaSetTrustedDomainInformation</c> function modifies a Policy object's information about a trusted domain.</para>
		/// </summary>
		/// <param name="PolicyHandle">
		/// <para>
		/// A handle to the Policy object of a domain controller. The required user rights for this handle depend on the value of the
		/// InformationClass parameter. For more information, see Opening a Policy Object Handle.
		/// </para>
		/// </param>
		/// <param name="TrustedDomainSid">
		/// <para>
		/// Pointer to the SID of the trusted domain whose information is modified. If the InformationClass parameter is set to
		/// TrustedDomainNameInformation, this parameter must point to the SID of the domain to add to the list of trusted domains.
		/// </para>
		/// </param>
		/// <param name="InformationClass">
		/// <para>
		/// Specifies one of the following values from the TRUSTED_INFORMATION_CLASS enumeration type. The value indicates the type of
		/// information being set.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TrustedDomainNameInformation</term>
		/// <term>
		/// If the specified domain is not in the list of trusted domains, the LsaSetTrustedDomainInformation function adds it. The
		/// TrustedDomainSid parameter must be the SID of the domain to add. The Buffer parameter must be a pointer to a
		/// TRUSTED_DOMAIN_NAME_INFO structure containing the name of the domain to add. If the specified domain is already in the list of
		/// trusted domains, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TrustedPosixOffsetInformation</term>
		/// <term>
		/// Sets the value used to generate Posix user and group identifiers. The Buffer parameter must be a pointer to a
		/// TRUSTED_POSIX_OFFSET_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TrustedPasswordInformation</term>
		/// <term>
		/// Sets the password for the trusted domain. The Buffer parameter must be a pointer to a TRUSTED_PASSWORD_INFO structure containing
		/// the old and new passwords for the specified domain. The handle passed in the PolicyHandle parameter must have the
		/// POLICY_CREATE_SECRET access right. The old password string can be NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Buffer">
		/// <para>
		/// Pointer to a structure containing the information to set. The type of structure depends on the value of the InformationClass parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsasettrusteddomaininformation NTSTATUS
		// LsaSetTrustedDomainInformation( LSA_HANDLE PolicyHandle, PSID TrustedDomainSid, TRUSTED_INFORMATION_CLASS InformationClass, PVOID
		// Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "a7b89ea7-af92-46ba-ac73-2fba1cc27680")]
		public static extern NTStatus LsaSetTrustedDomainInformation(LSA_HANDLE PolicyHandle, PSID TrustedDomainSid, TRUSTED_INFORMATION_CLASS InformationClass, IntPtr Buffer);

		/// <summary>Do not use the LSA private data functions. Instead, use the CryptProtectData and CryptUnprotectData functions.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_CREATE_SECRET access right if this is the first time data is being
		/// stored under the key specified by the KeyName parameter. For more information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="KeyName">
		/// Pointer to an LSA_UNICODE_STRING structure containing the name of the key under which the private data is stored.
		/// </param>
		/// <param name="PrivateData">
		/// <para>
		/// Pointer to an LSA_UNICODE_STRING structure containing the private data to store. The function encrypts this data before storing it.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the function deletes any private data stored under the key and deletes the key. Subsequent
		/// attempts to retrieve data from the key will return the STATUS_OBJECT_NAME_NOT_FOUND error code.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>LsaStorePrivateData</c> function can be used by server applications to store client and machine passwords.</para>
		/// <para>
		/// As described in Private Data Object, private data objects include three specialized types: local, global, and machine.
		/// Specialized objects are identified by a prefix in the key name: "L$" for local objects, "G$" for global objects, and "M$" for
		/// machine objects. Local objects cannot be accessed remotely. Machine objects can be accessed only by the operating system.
		/// </para>
		/// <para>
		/// In addition to these prefixes, the following values also indicate local or machine objects. These values are supported for
		/// backward compatibility and should not be used when you create new local or machine objects. The key name of local private data
		/// objects may also be "$machine.acc", "SAC", "SAI", "SANSC", or start with "RasDialParms" or "RasCredentials". The key name for
		/// machine objects may also start with, "NL$" or "sc".
		/// </para>
		/// <para>
		/// Private data objects which do not use any of the preceding key name conventions can be accessed remotely and are not replicated
		/// to other domains.
		/// </para>
		/// <para>
		/// The data stored by the <c>LsaStorePrivateData</c> function is not absolutely protected. However, the data is encrypted before
		/// being stored, and the key has a DACL that allows only the creator and administrators to read the data.
		/// </para>
		/// <para>Use the LsaRetrievePrivateData function to retrieve the value stored by <c>LsaStorePrivateData</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsastoreprivatedata NTSTATUS LsaStorePrivateData(
		// LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING KeyName, PLSA_UNICODE_STRING PrivateData );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "95d6cf30-fd08-473e-b0b3-3f7ca5e85357")]
		public static extern NTStatus LsaStorePrivateData(LSA_HANDLE PolicyHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string KeyName,
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string PrivateData);

		/// <summary>
		/// <para>The <c>LsaClose</c> function closes a handle to a Policy or TrustedDomain object.</para>
		/// </summary>
		/// <param name="ObjectHandle">
		/// <para>
		/// A handle to a Policy object returned by the LsaOpenPolicy function or to a TrustedDomain object returned by the
		/// LsaOpenTrustedDomainByName function. Following the completion of this call, the handle is no longer valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaclose NTSTATUS LsaClose( LSA_HANDLE ObjectHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "6283b1da-4ec3-48e1-91f6-321c6390befe")]
		// public static extern NTSTATUS LsaClose(LSA_HANDLE ObjectHandle);
		private static extern uint LsaClose(LSA_HANDLE ObjectHandle);

		/// <summary>
		/// <para>
		/// The <c>LsaFreeMemory</c> function frees memory allocated for an output buffer by an LSA function call. LSA functions that return
		/// variable-length output buffers always allocate the buffer on behalf of the caller. The caller must free this memory by passing
		/// the returned buffer pointer to <c>LsaFreeMemory</c> when the memory is no longer required.
		/// </para>
		/// </summary>
		/// <param name="Buffer">
		/// <para>
		/// Pointer to memory buffer that was allocated by an LSA function call. If <c>LsaFreeMemory</c> is successful, this buffer is freed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is an NTSTATUS code, which can be the following value or one of the LSA Policy Function
		/// Return Values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_UNSUCCESSFUL</term>
		/// <term>Memory could not be freed because it was not allocated by an LSA function call.</term>
		/// </item>
		/// </list>
		/// <para>You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsafreememory NTSTATUS LsaFreeMemory( PVOID Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "6eb3d18f-c54c-4e51-8a4b-b7a3f930cfa9")]
		// public static extern NTSTATUS LsaFreeMemory(IntPtr Buffer);
		private static extern uint LsaFreeMemory(IntPtr Buffer);

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

		/// <summary>Provides a handle to an LSA enumeration.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_ENUMERATION_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="LSA_ENUMERATION_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public LSA_ENUMERATION_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="LSA_ENUMERATION_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static LSA_ENUMERATION_HANDLE NULL => new LSA_ENUMERATION_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="LSA_ENUMERATION_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(LSA_ENUMERATION_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LSA_ENUMERATION_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LSA_ENUMERATION_HANDLE(IntPtr h) => new LSA_ENUMERATION_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(LSA_ENUMERATION_HANDLE h1, LSA_ENUMERATION_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(LSA_ENUMERATION_HANDLE h1, LSA_ENUMERATION_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is LSA_ENUMERATION_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Used with the LsaEnumerateAccountsWithUserRight function to return a pointer to a SID.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_enumeration_information typedef struct
		// _LSA_ENUMERATION_INFORMATION { PSID Sid; } LSA_ENUMERATION_INFORMATION, *PLSA_ENUMERATION_INFORMATION;
		[PInvokeData("ntsecapi.h", MSDNShortId = "7577548f-3ceb-43a5-b447-6f66a09963fe")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_ENUMERATION_INFORMATION
		{
			/// <summary>Pointer to a SID.</summary>
			public PSID Sid;
		}

		/// <summary>
		/// The <c>LSA_FOREST_TRUST_BINARY_DATA</c> structure contains binary data used in Local Security Authority forest trust operations.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_forest_trust_binary_data typedef struct
		// _LSA_FOREST_TRUST_BINARY_DATA { #if ... ULONG Length; #if ... PUCHAR Buffer; #else ULONG Length; #endif #else PUCHAR Buffer;
		// #endif } LSA_FOREST_TRUST_BINARY_DATA, *PLSA_FOREST_TRUST_BINARY_DATA;
		[PInvokeData("ntsecapi.h", MSDNShortId = "2ddcf54e-c30f-4146-8cb6-71fcdd42ae68")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LSA_FOREST_TRUST_BINARY_DATA
		{
			/// <summary>The count of bytes in Buffer.</summary>
			public uint Length;

			/// <summary>The trust record. If the Length field has a value other than 0, this field MUST NOT be NULL.</summary>
			public IntPtr Buffer;
		}

		/// <summary>
		/// The <c>LSA_FOREST_TRUST_COLLISION_INFORMATION</c> structure contains information about Local Security Authority forest trust collisions.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-lsa_forest_trust_collision_information typedef struct
		// _LSA_FOREST_TRUST_COLLISION_INFORMATION { ULONG RecordCount; PLSA_FOREST_TRUST_COLLISION_RECORD *Entries; }
		// LSA_FOREST_TRUST_COLLISION_INFORMATION, *PLSA_FOREST_TRUST_COLLISION_INFORMATION;
		[PInvokeData("ntsecapi.h", MSDNShortId = "a4a3b040-c074-4756-a30f-408d8bca87ba")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LSA_FOREST_TRUST_COLLISION_INFORMATION
		{
			/// <summary>Number of LSA_FOREST_TRUST_COLLISION_RECORD structures in the array pointed to by the <c>Entries</c> member.</summary>
			public uint RecordCount;

			/// <summary>
			/// Pointer to a pointer to an array of LSA_FOREST_TRUST_COLLISION_RECORD structures, each of which contains information about a
			/// single collision.
			/// </summary>
			public IntPtr Entries;
		}

		/// <summary>
		/// The <c>LSA_FOREST_TRUST_COLLISION_RECORD</c> structure contains information about a Local Security Authority forest trust collision.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-lsa_forest_trust_collision_record typedef struct
		// _LSA_FOREST_TRUST_COLLISION_RECORD { ULONG Index; LSA_FOREST_TRUST_COLLISION_RECORD_TYPE Type; ULONG Flags; LSA_UNICODE_STRING
		// Name; } LSA_FOREST_TRUST_COLLISION_RECORD, *PLSA_FOREST_TRUST_COLLISION_RECORD;
		[PInvokeData("ntsecapi.h", MSDNShortId = "9f9d2f57-0e7f-4222-be35-e3f026b60e93")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LSA_FOREST_TRUST_COLLISION_RECORD
		{
			/// <summary>
			/// Index of this collision record in the array of <c>LSA_FOREST_TRUST_COLLISION_RECORD</c> structures pointed to by the
			/// <c>Entries</c> member of the LSA_FOREST_TRUST_COLLISION_INFORMATION structure.
			/// </summary>
			public uint Index;

			/// <summary>
			/// <para>Type of the collision. The following table shows the possible values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CollisionTdo</term>
			/// <term>Collision between TrustedDomain objects.</term>
			/// </item>
			/// <item>
			/// <term>CollisionXref</term>
			/// <term>Collision between cross-references.</term>
			/// </item>
			/// <item>
			/// <term>CollisionOther</term>
			/// <term>Collision that is not a collision between TrustedDomain objects or cross-references.</term>
			/// </item>
			/// </list>
			/// </summary>
			public LSA_FOREST_TRUST_COLLISION_RECORD_TYPE Type;

			/// <summary>
			/// <para>
			/// Flags that provide more information about the collision. The following table lists the possible values for this member when
			/// the <c>Type</c> member is CollisionTdo.
			/// </para>
			/// <para>LSA_TLN_DISABLED_NEW (0x00000001)</para>
			/// <para>LSA_TLN_DISABLED_ADMIN (0x00000002)</para>
			/// <para>LSA_TLN_DISABLED_CONFLICT (0x00000004)</para>
			/// <para>The following table lists the possible values for this member when the <c>Type</c> member is CollisionXref.</para>
			/// <para>LSA_SID_DISABLED_ADMIN (0x00000001)</para>
			/// <para>LSA_SID_DISABLED_CONFLICT (0x00000002)</para>
			/// <para>LSA_NB_DISABLED_ADMIN (0x00000004)</para>
			/// <para>LSA_NB_DISABLED_CONFLICT (0x00000008)</para>
			/// </summary>
			public CollisionFlags Flags;

			/// <summary>LSA_UNICODE_STRING structure that contains the name of the collision record.</summary>
			public LSA_UNICODE_STRING Name;
		}

		/// <summary>The <c>LSA_FOREST_TRUST_DOMAIN_INFO</c> structure contains identifying information for a domain.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_forest_trust_domain_info typedef struct
		// _LSA_FOREST_TRUST_DOMAIN_INFO { #if ... PISID Sid; #else PSID Sid; #endif LSA_UNICODE_STRING DnsName; LSA_UNICODE_STRING
		// NetbiosName; } LSA_FOREST_TRUST_DOMAIN_INFO, *PLSA_FOREST_TRUST_DOMAIN_INFO;
		[PInvokeData("ntsecapi.h", MSDNShortId = "c0e06735-ca10-4bee-a45b-6db5b6666e31")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LSA_FOREST_TRUST_DOMAIN_INFO
		{
			/// <summary>Domain SID for the trusted domain.</summary>
			public IntPtr Sid;

			/// <summary>LSA_UNICODE_STRING structure that contains the DNS name of the domain.</summary>
			public LSA_UNICODE_STRING DnsName;

			/// <summary>LSA_UNICODE_STRING structure that contains the NetBIOS name of the domain.</summary>
			public LSA_UNICODE_STRING NetbiosName;
		}

		/// <summary>The <c>LSA_FOREST_TRUST_INFORMATION</c> structure contains Local Security Authority forest trust information.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_forest_trust_information typedef struct
		// _LSA_FOREST_TRUST_INFORMATION { #if ... ULONG RecordCount; #if ... PLSA_FOREST_TRUST_RECORD *Entries; #else ULONG RecordCount;
		// #endif #else PLSA_FOREST_TRUST_RECORD *Entries; #endif } LSA_FOREST_TRUST_INFORMATION, *PLSA_FOREST_TRUST_INFORMATION;
		[PInvokeData("ntsecapi.h", MSDNShortId = "9e456462-59a9-4f18-ba47-92fc2350889b")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LSA_FOREST_TRUST_INFORMATION
		{
			/// <summary>A count of elements in the Entries array.</summary>
			public uint RecordCount;

			/// <summary>
			/// An array of LSA_FOREST_TRUST_RECORD structures. If the RecordCount field has a value other than 0, this field MUST NOT be NULL.
			/// </summary>
			public IntPtr Entries;
		}

		/// <summary>
		/// <para>The <c>LSA_FOREST_TRUST_RECORD</c> structure represents a Local Security Authority forest trust record.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_forest_trust_record typedef struct
		// _LSA_FOREST_TRUST_RECORD { ULONG Flags; LSA_FOREST_TRUST_RECORD_TYPE ForestTrustType; LARGE_INTEGER Time; #if ... union {
		// LSA_UNICODE_STRING TopLevelName; LSA_FOREST_TRUST_DOMAIN_INFO DomainInfo; LSA_FOREST_TRUST_BINARY_DATA Data; } ForestTrustData;
		// #else union { LSA_UNICODE_STRING TopLevelName; LSA_FOREST_TRUST_DOMAIN_INFO DomainInfo; LSA_FOREST_TRUST_BINARY_DATA Data; }
		// ForestTrustData; #endif } LSA_FOREST_TRUST_RECORD, *PLSA_FOREST_TRUST_RECORD;
		[PInvokeData("ntsecapi.h", MSDNShortId = "19b4ee56-664f-4f37-bfc9-129032ebeb22")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LSA_FOREST_TRUST_RECORD
		{
			/// <summary>Flags that control the behavior of the operation.</summary>
			public LSA_TLN Flags;

			/// <summary>
			/// <para>
			/// LSA_FOREST_TRUST_RECORD_TYPE enumeration that indicates the type of the record. The following table shows the possible values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ForestTrustTopLevelName</term>
			/// <term>Record contains an included top-level name.</term>
			/// </item>
			/// <item>
			/// <term>ForestTrustTopLevelNameEx</term>
			/// <term>Record contains an excluded top-level name.</term>
			/// </item>
			/// <item>
			/// <term>ForestTrustDomainInfo</term>
			/// <term>Record contains an LSA_FOREST_TRUST_DOMAIN_INFO structure.</term>
			/// </item>
			/// <item>
			/// <term>ForestTrustRecordTypeLast</term>
			/// <term>Marks the end of an enumeration.</term>
			/// </item>
			/// </list>
			/// </summary>
			public LSA_FOREST_TRUST_RECORD_TYPE ForestTrustType;

			/// <summary>Time stamp of the record.</summary>
			public FILETIME Time;

			/// <summary>
			/// An LSA_UNICODE_STRING or LSA_FOREST_TRUST_DOMAIN_INFO structure, depending on the value ForestTrustType as specified in the
			/// structure definition for LSA_FOREST_TRUST_RECORD.
			/// </summary>
			public ForestTrustDataUnion ForestTrustData;

			/// <summary>
			/// An LSA_UNICODE_STRING or LSA_FOREST_TRUST_DOMAIN_INFO structure, depending on the value ForestTrustType as specified in the
			/// structure definition for LSA_FOREST_TRUST_RECORD.
			/// </summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct ForestTrustDataUnion
			{
				/// <summary>Top-level name. This member is used only if the ForestTrustType member is ForestTrustTopLevelName or ForestTrustTopLevelNameEx.</summary>
				[FieldOffset(0)]
				public LSA_UNICODE_STRING TopLevelName;

				/// <summary>Domain information. This member is used only if the ForestTrustType member is ForestTrustDomainInfo.</summary>
				[FieldOffset(0)]
				public LSA_FOREST_TRUST_DOMAIN_INFO DomainInfo;

				/// <summary>Binary data. This member is used for unrecognized entries after ForestTrustRecordTypeLast.</summary>
				[FieldOffset(0)]
				public LSA_FOREST_TRUST_BINARY_DATA Data;
			}
		}

		/// <summary>Provides a handle to a LSA handle.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="LSA_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public LSA_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="LSA_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static LSA_HANDLE NULL => new LSA_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="LSA_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(LSA_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LSA_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LSA_HANDLE(IntPtr h) => new LSA_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(LSA_HANDLE h1, LSA_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(LSA_HANDLE h1, LSA_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is LSA_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>The <c>LSA_REFERENCED_DOMAIN_LIST</c> structure contains information about the domains referenced in a lookup operation.</summary>
		// typedef struct _LSA_REFERENCED_DOMAIN_LIST { ULONG Entries; PLSA_TRUST_INFORMATION Domains;} LSA_REFERENCED_DOMAIN_LIST,
		// *PLSA_REFERENCED_DOMAIN_LIST; https://msdn.microsoft.com/en-us/library/windows/desktop/ms721834(v=vs.85).aspx
		[PInvokeData("Ntsecapi.h", MSDNShortId = "ms721834")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_REFERENCED_DOMAIN_LIST
		{
			/// <summary>Specifies the number of entries in the Domains array.</summary>
			public uint Entries;

			/// <summary>Pointer to an array of LSA_TRUST_INFORMATION structures that identify the referenced domains.</summary>
			public IntPtr Domains;

			/// <summary>Gets the list of <see cref="LSA_TRUST_INFORMATION"/> structures from the <see cref="Domains"/> field.</summary>
			public IEnumerable<LSA_TRUST_INFORMATION> DomainList => Domains.ToIEnum<LSA_TRUST_INFORMATION>((int)Entries);
		}

		/// <summary>
		/// The <c>LSA_TRANSLATED_SID</c> structure is used with the LsaLookupNames function to return information about the SID that
		/// identifies an account.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_translated_sid typedef struct _LSA_TRANSLATED_SID {
		// SID_NAME_USE Use; ULONG RelativeId; LONG DomainIndex; } LSA_TRANSLATED_SID, *PLSA_TRANSLATED_SID;
		[PInvokeData("ntsecapi.h", MSDNShortId = "1fa8fb74-3e61-4982-aa6b-a0ffe979abd4")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LSA_TRANSLATED_SID
		{
			/// <summary>
			/// <para>A value from the SID_NAME_USE enumeration type that identifies the type of SID.</para>
			/// <para>
			/// If <c>Use</c> has one of the following values, one or both of the <c>RelativeId</c> or <c>DomainIndex</c> members of
			/// <c>LSA_TRANSLATED_SID</c> is not valid. These members are valid if <c>Use</c> has any other value.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SidTypeDomain</term>
			/// <term>The DomainIndex member is valid, but the RelativeId member is not valid and must be ignored.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeInvalid</term>
			/// <term>Both DomainIndex and RelativeId are not valid and must be ignored.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeUnknown</term>
			/// <term>Both DomainIndex and RelativeId members are not valid and must be ignored.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SID_NAME_USE Use;

			/// <summary>
			/// Specifies the relative identifier (RID) of the account's SID. The RID identifies the account relative to the domain
			/// referenced by the <c>DomainIndex</c> member. The account's complete SID consists of the domain SID followed by the RID.
			/// </summary>
			public uint RelativeId;

			/// <summary>
			/// <para>
			/// Specifies the zero-based index of an entry in the LSA_REFERENCED_DOMAIN_LIST structure returned by the LsaLookupNames
			/// function. This entry contains the name and SID of the domain in which the account was found.
			/// </para>
			/// <para>If there is no corresponding domain for an account, this member contains a negative value.</para>
			/// </summary>
			public int DomainIndex;
		}

		/// <summary>
		/// <para>The <c>LSA_TRUST_INFORMATION</c> structure identifies a domain.</para>
		/// </summary>
		/// <remarks>
		/// <para>TRUSTED_DOMAIN_INFORMATION_BASIC is an alias for this structure.</para>
		/// <para>
		/// The TRUSTED_DOMAIN_INFORMATION_BASIC structure identifies a domain. This structure is used by the LsaQueryTrustedDomainInfo
		/// function when its InformationClass parameter is set to <c>TrustedDomainInformationBasic</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lsalookup/ns-lsalookup-_lsa_trust_information typedef struct
		// _LSA_TRUST_INFORMATION { LSA_UNICODE_STRING Name; PSID Sid; } LSA_TRUST_INFORMATION, *PLSA_TRUST_INFORMATION;
		[PInvokeData("lsalookup.h", MSDNShortId = "2b5e6f79-b97a-4018-a45a-37c300c3dc0d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_TRUST_INFORMATION
		{
			/// <summary>An LSA_UNICODE_STRING structure that contains the name of the domain.</summary>
			public LSA_UNICODE_STRING Name;

			/// <summary>Pointer to the SID of the domain.</summary>
			public IntPtr Sid;
		}

		/// <summary>
		/// The LSA_UNICODE_STRING structure is used by various Local Security Authority (LSA) functions to specify a Unicode string. Also an
		/// example of unnecessary over-engineering and re-engineering.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 8, Pack = 2)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "ms721841")]
		public struct LSA_UNICODE_STRING
		{
			/// <summary>
			/// Specifies the length, in bytes, of the string pointed to by the Buffer member, not including the terminating null character,
			/// if any.
			/// </summary>
			public ushort length;

			/// <summary>
			/// Specifies the total size, in bytes, of the memory allocated for Buffer. Up to MaximumLength bytes can be written into the
			/// buffer without trampling memory.
			/// </summary>
			public ushort MaximumLength;

			/// <summary>
			/// Pointer to a wide character string. Note that the strings returned by the various LSA functions might not be null-terminated.
			/// </summary>
			public string Buffer;

			/// <summary>Initializes a new instance of the <see cref="LSA_UNICODE_STRING"/> struct from a string.</summary>
			/// <param name="s">The string value.</param>
			/// <exception cref="System.ArgumentException">String exceeds 32Kb of data.</exception>
			public LSA_UNICODE_STRING(string s)
			{
				if (s == null)
				{
					length = MaximumLength = 0;
					Buffer = null;
				}
				else
				{
					var l = s.Length * UnicodeEncoding.CharSize;
					// Unicode strings max. 32KB
					if (l >= ushort.MaxValue)
						throw new ArgumentException("String too long");
					Buffer = s;
					length = (ushort)l;
					MaximumLength = (ushort)(l + UnicodeEncoding.CharSize);
				}
			}

			/// <summary>Gets the number of characters in the string.</summary>
			public int Length => length / UnicodeEncoding.CharSize;

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() => Buffer.Substring(0, Length);

			/// <summary>Performs an implicit conversion from <see cref="LSA_UNICODE_STRING"/> to <see cref="string"/>.</summary>
			/// <param name="value">The value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator string(LSA_UNICODE_STRING value) => value.ToString();
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

		/// <summary>Smart wrapper for LSA_FOREST_TRUST_INFORMATION.</summary>
		public class LsaForestTrustInformation : IDisposable
		{
			private SafeAllocatedMemoryHandle allocatedMemory;

			/// <summary>A list of LsaForestTrustRecord entries that wrap LSA_FOREST_TRUST_RECORD.</summary>
			/// <value>Returns a <see cref="List{LsaForestTrustRecord}"/> value.</value>
			public List<LsaForestTrustRecord> Entries { get; } = new List<LsaForestTrustRecord>();

			/// <summary>Creates a new instance from a memory pointer. This can fail if the memory is not allocated properly.</summary>
			/// <param name="ptr">The memory pointer.</param>
			/// <returns>A new instance of <see cref="LsaForestTrustInformation"/>.</returns>
			public static LsaForestTrustInformation FromBuffer(IntPtr ptr)
			{
				var ret = new LsaForestTrustInformation();
				var info = ptr.ToStructure<LSA_FOREST_TRUST_INFORMATION>();
				foreach (var e in info.Entries.ToIEnum<LSA_FOREST_TRUST_RECORD>((int)info.RecordCount))
				{
					if (e.ForestTrustType == LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustRecordTypeLast) break;
					LsaForestTrustRecord rec = null;
					switch (e.ForestTrustType)
					{
						case LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustTopLevelName:
							rec = new LsaForestTrustTopLevelName(e.ForestTrustData.TopLevelName, false);
							break;

						case LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustTopLevelNameEx:
							rec = new LsaForestTrustTopLevelName(e.ForestTrustData.TopLevelName, true);
							break;

						case LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustDomainInfo:
							rec = new LsaForestTrustDomainInfo { DnsName = e.ForestTrustData.DomainInfo.DnsName, NetbiosName = e.ForestTrustData.DomainInfo.NetbiosName, Sid = new PSID(e.ForestTrustData.DomainInfo.Sid) };
							break;

						default:
							throw new ArgumentException("Unrecognized record type.", nameof(ptr));
					}
					rec.Flags = e.Flags;
					rec.Time = e.Time.ToDateTime();
					ret.Entries.Add(rec);
				}
				return ret;
			}

			/// <summary>
			/// Returns an instance of <see cref="LSA_FOREST_TRUST_INFORMATION"/>. Warning! The memory allocated for the entries is tied to
			/// this instance and will be disposed with it. Thus, if the returned structure is copied, the pointers within it may become
			/// invalid if its scope outlives this instance's scope. Subsequent calls to this method will also invalidate the pointers within
			/// any previous structures. In other words, just use this method to extract the structure for one time use and ensure this
			/// instance does not go out of scope while the structure's being used.
			/// </summary>
			/// <returns>A <see cref="LSA_FOREST_TRUST_INFORMATION"/> instance matching the values of this instance.</returns>
			public LSA_FOREST_TRUST_INFORMATION DangerousGetLSA_FOREST_TRUST_INFORMATION()
			{
				((IDisposable)this).Dispose();
				allocatedMemory = SafeHGlobalHandle.CreateFromList(Entries.Select(e => e.Convert())); //.Concat(new[] { new LSA_FOREST_TRUST_RECORD { ForestTrustType = LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustRecordTypeLast } }));

				return new LSA_FOREST_TRUST_INFORMATION { RecordCount = (uint)Entries.Count, Entries = allocatedMemory.DangerousGetHandle() };
			}

			/// <summary>Releases the unmanaged resources used by this object, and optionally releases the managed resources.</summary>
			void IDisposable.Dispose() => allocatedMemory?.Dispose();

			/// <summary>Represents a LSA_FOREST_TRUST_RECORD with the ForestTrustType value set to ForestTrustDomainInfo.</summary>
			public class LsaForestTrustDomainInfo : LsaForestTrustRecord
			{
				/// <summary>The DNS name of the domain.</summary>
				public string DnsName { get; set; }

				/// <summary>The NetBIOS name of the domain.</summary>
				public string NetbiosName { get; set; }

				/// <summary>Domain SID for the trusted domain.</summary>
				public PSID Sid { get; set; }

				public override string ToString() => $"DnsName:{DnsName}, NB:{NetbiosName}, Time:{Time:u}, Flg:{Flags}";

				protected internal override LSA_FOREST_TRUST_RECORD Convert()
				{
					var ret = base.Convert();
					ret.ForestTrustType = LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustDomainInfo;
					ret.ForestTrustData.DomainInfo.DnsName = new LSA_UNICODE_STRING(DnsName);
					ret.ForestTrustData.DomainInfo.NetbiosName = new LSA_UNICODE_STRING(NetbiosName);
					ret.ForestTrustData.DomainInfo.Sid = (IntPtr)Sid;
					return ret;
				}
			}

			/// <summary>Represents a LSA_FOREST_TRUST_RECORD.</summary>
			public abstract class LsaForestTrustRecord
			{
				/// <summary>Flags that control the behavior of the operation.</summary>
				public LSA_TLN Flags { get; set; }

				/// <summary>Time stamp of the record.</summary>
				public DateTime Time { get; set; }

				protected internal virtual LSA_FOREST_TRUST_RECORD Convert() =>
					new LSA_FOREST_TRUST_RECORD { Flags = Flags, Time = Time.ToFileTimeStruct() };
			}

			/// <summary>
			/// Represents a LSA_FOREST_TRUST_RECORD with the ForestTrustType value set to ForestTrustTopLevelNameEx if the
			/// <see cref="Excluded"/> property is <see langword="true"/> and ForestTrustTopLevelName if the <see cref="Excluded"/> property
			/// is <see langword="true"/>.
			/// </summary>
			public class LsaForestTrustTopLevelName : LsaForestTrustRecord
			{
				public LsaForestTrustTopLevelName(string name = null, bool exclude = false)
				{
					TopLevelName = name;
					Excluded = exclude;
				}

				public bool Excluded { get; set; }
				public string TopLevelName { get; set; }

				public override string ToString() => $"TopName:{TopLevelName}, Excl:{Excluded}, Time:{Time:u}, Flg:{Flags}";

				protected internal override LSA_FOREST_TRUST_RECORD Convert()
				{
					var ret = base.Convert();
					ret.ForestTrustType = Excluded ? LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustTopLevelNameEx : LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustTopLevelName;
					ret.ForestTrustData.TopLevelName = new LSA_UNICODE_STRING(TopLevelName);
					return ret;
				}
			}
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a LSA handle that releases a created LSA_HANDLE instance at disposal using LsaClose.
		/// </summary>
		public class SafeLSA_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="LSA_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeLSA_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="LSA_HANDLE"/> class.</summary>
			private SafeLSA_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeLSA_HANDLE"/> to <see cref="LSA_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LSA_HANDLE(SafeLSA_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => LsaClose(this) == 0;
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a LSA memory handle that releases a created LsaMemoryHandle instance at disposal using <see cref="LsaFreeMemory"/>.
		/// </summary>
		public class SafeLsaMemoryHandle : SafeLsaMemoryHandleBase
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaMemoryHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeLsaMemoryHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeLsaMemoryHandle"/> class.</summary>
			private SafeLsaMemoryHandle() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => LsaFreeMemory(handle) == 0;
		}

		/// <summary>Base class for other LSA memory handles.</summary>
		public abstract class SafeLsaMemoryHandleBase : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaMemoryHandleBase"/> class.</summary>
			protected SafeLsaMemoryHandleBase() : base()
			{
			}

			/// <summary>Initializes a new instance of the <see cref="SafeHANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			protected SafeLsaMemoryHandleBase(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) => SetHandle(preexistingHandle);

			/// <summary>
			/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note type="note">This
			/// call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
			/// </summary>
			/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
			/// <param name="count">The number of structures to retrieve.</param>
			/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
			/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
			public T[] ToArray<T>(int count, int prefixBytes = 0)
			{
				if (IsInvalid) return null;
				//if (Size < Marshal.SizeOf(typeof(T)) * count + prefixBytes)
				//	throw new InsufficientMemoryException("Requested array is larger than the memory allocated.");
				if (!typeof(T).IsBlittable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");
				return handle.ToArray<T>(count, prefixBytes);
			}

			/// <summary>
			/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
			/// </summary>
			/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
			/// <returns>A managed object that contains the data that this <see cref="SafeMemoryHandleExt{T}"/> holds.</returns>
			public T ToStructure<T>()
			{
				if (IsInvalid) return default;
				return handle.ToStructure<T>();
			}
		}

		/// <summary>A <see cref="SafeHandle"/> for values that must be freed using the <see cref="LsaFreeReturnBuffer(IntPtr)"/> function.</summary>
		public sealed class SafeLsaReturnBufferHandle : SafeLsaMemoryHandleBase
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaReturnBufferHandle"/> class.</summary>
			/// <param name="preexistingHandle">The pointer to the memory allocated by an Lsa function.</param>
			/// <param name="ownsHandle">if set to <c>true</c> release the memory when out of scope.</param>
			public SafeLsaReturnBufferHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeLsaReturnBufferHandle"/> class.</summary>
			private SafeLsaReturnBufferHandle() : base() { }

			protected override bool InternalReleaseHandle() => Secur32.LsaFreeReturnBuffer(handle) == 0;
		}

		/// <summary>A custom marshaler for functions using LSA_UNICODE_STRING arrays so that managed string arrays can be used.</summary>
		/// <seealso cref="ICustomMarshaler"/>
		internal class LsaUnicodeStringArrayMarshaler : ICustomMarshaler
		{
			private static readonly Dictionary<IntPtr, int> pastCallArraySizes = new Dictionary<IntPtr, int>();

			public static ICustomMarshaler GetInstance(string cookie) => new LsaUnicodeStringArrayMarshaler();

			public void CleanUpManagedData(object ManagedObj)
			{
			}

			public void CleanUpNativeData(IntPtr pNativeData)
			{
				if (pNativeData == IntPtr.Zero) return;
				if (pastCallArraySizes.TryGetValue(pNativeData, out var length))
				{
					var sz = Marshal.SizeOf(typeof(LSA_UNICODE_STRING));
					for (var i = 0; i < length; i++)
						Marshal.DestroyStructure(pNativeData.Offset(sz * i), typeof(LSA_UNICODE_STRING));
					pastCallArraySizes.Remove(pNativeData);
				}
				Marshal.FreeCoTaskMem(pNativeData);
				pNativeData = IntPtr.Zero;
			}

			public int GetNativeDataSize() => -1;

			public IntPtr MarshalManagedToNative(object ManagedObj)
			{
				if (ManagedObj is string[] a)
				{
					var uma = Array.ConvertAll(a, p => new LSA_UNICODE_STRING(p));
					var sz = Marshal.SizeOf(typeof(LSA_UNICODE_STRING));
					var result = Marshal.AllocCoTaskMem(sz * a.Length);
					pastCallArraySizes.Add(result, a.Length);
					var ptr = result;
					foreach (var value in uma)
					{
						Marshal.StructureToPtr(value, ptr, false);
						ptr = ptr.Offset(sz);
					}
					return result;
				}
				return IntPtr.Zero;
			}

			public object MarshalNativeToManaged(IntPtr pNativeData)
			{
				if (pNativeData == IntPtr.Zero) return null;
				throw new InvalidOperationException(@"Unable to marshal LSA_UNICODE_STRING arrays from unmanaged to managed code.");
			}
		}

		/// <summary>A custom marshaler for functions using LSA_UNICODE_STRING so that managed strings can be used.</summary>
		/// <seealso cref="ICustomMarshaler"/>
		internal class LsaUnicodeStringMarshaler : ICustomMarshaler
		{
			public static ICustomMarshaler GetInstance(string cookie) => new LsaUnicodeStringMarshaler();

			public void CleanUpManagedData(object ManagedObj)
			{
			}

			public void CleanUpNativeData(IntPtr pNativeData)
			{
				if (pNativeData == IntPtr.Zero) return;
				Marshal.FreeCoTaskMem(pNativeData);
				pNativeData = IntPtr.Zero;
			}

			public int GetNativeDataSize() => Marshal.SizeOf(typeof(LSA_UNICODE_STRING));

			public IntPtr MarshalManagedToNative(object ManagedObj)
			{
				var s = ManagedObj as string;
				if (s == null) return IntPtr.Zero;
				var str = new LSA_UNICODE_STRING(s);
				var ret = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(LSA_UNICODE_STRING)));
				Marshal.StructureToPtr(str, ret, false);
				return ret;
			}

			public object MarshalNativeToManaged(IntPtr pNativeData)
			{
				if (pNativeData == IntPtr.Zero) return null;
				var ret = pNativeData.ToStructure<LSA_UNICODE_STRING>();
				var s = (string)ret.ToString().Clone();
				LsaFreeMemory(pNativeData);
				return s;
			}
		}

		/*
		AuditComputeEffectivePolicyBySid function
		AuditComputeEffectivePolicyByToken function
		AuditEnumerateCategories function
		AuditEnumeratePerUserPolicy function
		AuditEnumerateSubCategories function
		AuditFree function
		AuditLookupCategoryGuidFromCategoryId function
		AuditLookupCategoryIdFromCategoryGuid function
		AuditLookupCategoryNameA function
		AuditLookupCategoryNameW function
		AuditLookupSubCategoryNameA function
		AuditLookupSubCategoryNameW function
		AuditQueryGlobalSaclA function
		AuditQueryGlobalSaclW function
		AuditQueryPerUserPolicy function
		AuditQuerySecurity function
		AuditQuerySystemPolicy function
		AuditSetGlobalSaclA function
		AuditSetGlobalSaclW function
		AuditSetPerUserPolicy function
		AuditSetSecurity function
		AuditSetSystemPolicy function
		KERB_CRYPTO_KEY structure
		LsaCallAuthenticationPackage function
		LsaCreateTrustedDomainEx function
		LsaDeleteTrustedDomain function
		LsaEnumerateLogonSessions function
		LsaEnumerateTrustedDomains function
		LsaEnumerateTrustedDomainsEx function
		LsaGetLogonSessionData function
		LsaLogonUser function
		LsaLookupNames function
		LsaLookupSids function
		LsaOpenTrustedDomainByName function
		LsaQueryDomainInformationPolicy function
		LsaQueryForestTrustInformation function
		LsaQueryInformationPolicy function
		LsaQueryTrustedDomainInfoByName function
		LsaRegisterPolicyChangeNotification function
		LsaRetrievePrivateData function
		LsaSetDomainInformationPolicy function
		LsaSetForestTrustInformation function
		LsaSetInformationPolicy function
		LsaSetTrustedDomainInfoByName function
		LsaStorePrivateData function
		LsaUnregisterPolicyChangeNotification function
		PSAM_INIT_NOTIFICATION_ROUTINE callback function
		PSAM_PASSWORD_FILTER_ROUTINE callback function
		PSAM_PASSWORD_NOTIFICATION_ROUTINE callback function
		RtlDecryptMemory function
		RtlEncryptMemory function
		RtlGenRandom function
		*/
	}
}