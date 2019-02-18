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
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaCreateAccount(LSA_HANDLE PolicyHandle, PSID AccountSid, LsaAccountAccessMask DesiredAccess, out SafeLSA_HANDLE AccountHandle);

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

		/// <summary>Gets system access for an account.</summary>
		/// <param name="AccountHandle">The account handle.</param>
		/// <param name="SystemAccess">The system access.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns one of the following <c>NTSTATUS</c> values.</para>
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaGetSystemAccessAccount(LSA_HANDLE AccountHandle, out int SystemAccess);

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

		/// <summary>Undocumented.</summary>
		/// <param name="AccountHandle">The account handle.</param>
		/// <param name="SystemAccess">The system access.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code, which
		/// can be one of the following values or one of the LSA Policy Function Return Values.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaSetSystemAccessAccount(LSA_HANDLE AccountHandle, int SystemAccess);

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
		/// <para>The <c>LsaFreeReturnBuffer</c> function frees the memory used by a buffer previously allocated by the LSA.</para>
		/// </summary>
		/// <param name="Buffer">
		/// <para>Pointer to the buffer to be freed.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Some of the LSA authentication functions allocate memory buffers to hold returned information, for example, LsaLogonUser and
		/// LsaCallAuthenticationPackage. Your application should call <c>LsaFreeReturnBuffer</c> to free these buffers when they are no
		/// longer needed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsafreereturnbuffer _IRQL_requires_same_ NTSTATUS
		// LsaFreeReturnBuffer( PVOID Buffer );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "e814ed68-07e7-4936-ba96-5411086f43f6")]
		// public static extern _IRQL_requires_same_ NTSTATUS LsaFreeReturnBuffer(IntPtr Buffer);
		private static extern uint LsaFreeReturnBuffer(IntPtr Buffer);

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

		/// <summary>
		/// The <c>LSA_FOREST_TRUST_INFORMATION</c> structure contains Local Security Authority forest trust information.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_forest_trust_information typedef struct
		// _LSA_FOREST_TRUST_INFORMATION { #if ... ULONG RecordCount; #if ... PLSA_FOREST_TRUST_RECORD *Entries; #else ULONG RecordCount;
		// #endif #else PLSA_FOREST_TRUST_RECORD *Entries; #endif } LSA_FOREST_TRUST_INFORMATION, *PLSA_FOREST_TRUST_INFORMATION;
		[PInvokeData("ntsecapi.h", MSDNShortId = "9e456462-59a9-4f18-ba47-92fc2350889b")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LSA_FOREST_TRUST_INFORMATION
		{
			/// <summary>A count of elements in the Entries array.</summary>
			public uint RecordCount;

			/// <summary>An array of LSA_FOREST_TRUST_RECORD structures. If the RecordCount field has a value other than 0, this field MUST NOT be NULL.</summary>
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
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>ForestTrustTopLevelName</term>
			///     <term>Record contains an included top-level name.</term>
			///   </item>
			///   <item>
			///     <term>ForestTrustTopLevelNameEx</term>
			///     <term>Record contains an excluded top-level name.</term>
			///   </item>
			///   <item>
			///     <term>ForestTrustDomainInfo</term>
			///     <term>Record contains an LSA_FOREST_TRUST_DOMAIN_INFO structure.</term>
			///   </item>
			///   <item>
			///     <term>ForestTrustRecordTypeLast</term>
			///     <term>Marks the end of an enumeration.</term>
			///   </item>
			/// </list>
			/// </summary>
			public LSA_FOREST_TRUST_RECORD_TYPE ForestTrustType;

			/// <summary>Time stamp of the record.</summary>
			public FILETIME Time;

			/// <summary>An LSA_UNICODE_STRING or LSA_FOREST_TRUST_DOMAIN_INFO structure, depending on the value ForestTrustType as specified in the structure definition for LSA_FOREST_TRUST_RECORD.</summary>
			public ForestTrustDataUnion ForestTrustData;

			/// <summary>An LSA_UNICODE_STRING or LSA_FOREST_TRUST_DOMAIN_INFO structure, depending on the value ForestTrustType as specified in the structure definition for LSA_FOREST_TRUST_RECORD.</summary>
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

			/// <summary>Represents a LSA_FOREST_TRUST_RECORD.</summary>
			public abstract class LsaForestTrustRecord
			{
				/// <summary>Flags that control the behavior of the operation.</summary>
				public LSA_TLN Flags { get; set; }

				/// <summary>Time stamp of the record.</summary>
				public DateTime Time { get; set; }

				protected virtual internal LSA_FOREST_TRUST_RECORD Convert() =>
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

				public string TopLevelName { get; set; }

				public bool Excluded { get; set; }

				public override string ToString() => $"TopName:{TopLevelName}, Excl:{Excluded}, Time:{Time:u}, Flg:{Flags}";

				protected internal override LSA_FOREST_TRUST_RECORD Convert()
				{
					var ret = base.Convert();
					ret.ForestTrustType = Excluded ? LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustTopLevelNameEx : LSA_FOREST_TRUST_RECORD_TYPE.ForestTrustTopLevelName;
					ret.ForestTrustData.TopLevelName = new LSA_UNICODE_STRING(TopLevelName);
					return ret;
				}
			}

			/// <summary>Represents a LSA_FOREST_TRUST_RECORD with the ForestTrustType value set to ForestTrustDomainInfo.</summary>
			public class LsaForestTrustDomainInfo : LsaForestTrustRecord
			{
				/// <summary>Domain SID for the trusted domain.</summary>
				public PSID Sid { get; set; }

				/// <summary>The DNS name of the domain.</summary>
				public string DnsName { get; set; }

				/// <summary>The NetBIOS name of the domain.</summary>
				public string NetbiosName { get; set; }

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
		/// Provides a <see cref="SafeHandle"/> to a LSA memory handle that releases a created LsaMemoryHandle instance at disposal using LsaFreeMemory.
		/// </summary>
		public class SafeLsaMemoryHandle : SafeHANDLE
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

		/// <summary>A <see cref="SafeHandle"/> for values that must be freed using the <see cref="LsaFreeReturnBuffer(IntPtr)"/> function.</summary>
		public sealed class SafeLsaReturnBufferHandle : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaReturnBufferHandle"/> class.</summary>
			/// <param name="preexistingHandle">The pointer to the memory allocated by an Lsa function.</param>
			/// <param name="ownsHandle">if set to <c>true</c> release the memory when out of scope.</param>
			public SafeLsaReturnBufferHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeLsaReturnBufferHandle"/> class.</summary>
			private SafeLsaReturnBufferHandle() : base() { }

			protected override bool InternalReleaseHandle() => LsaFreeReturnBuffer(handle) == 0;
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