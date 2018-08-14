using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
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
			SafeLsaPolicyHandle PolicyHandle,
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
		public static extern uint LsaCreateAccount(SafeLsaPolicyHandle PolicyHandle, PSID AccountSid, LsaAccountAccessMask DesiredAccess, out SafeLsaPolicyHandle AccountHandle);

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
			SafeLsaPolicyHandle PolicyHandle,
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
		public static IEnumerable<string> LsaEnumerateAccountRights(SafeLsaPolicyHandle PolicyHandle, PSID AccountSid)
		{
			var ret = LsaEnumerateAccountRights(PolicyHandle, AccountSid, out SafeLsaMemoryHandle mem, out uint cnt);
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
			SafeLsaPolicyHandle PolicyHandle,
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
		public static IEnumerable<PSID> LsaEnumerateAccountsWithUserRight(SafeLsaPolicyHandle PolicyHandle, string UserRights)
		{
			var ret = LsaEnumerateAccountsWithUserRight(PolicyHandle, UserRights, out SafeLsaMemoryHandle mem, out int cnt);
			if (ret == NTStatus.STATUS_NO_MORE_ENTRIES) return new PSID[0];
			var wret = LsaNtStatusToWinError(ret);
			wret.ThrowIfFailed();
			return mem.DangerousGetHandle().ToIEnum<LSA_ENUMERATION_INFORMATION>(cnt).Select(u => PSID.CreateFromPtr(u.Sid));
		}

		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaGetSystemAccessAccount(SafeLsaPolicyHandle AccountHandle, out int SystemAccess);

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
			SafeLsaPolicyHandle PolicyHandle,
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
			SafeLsaPolicyHandle PolicyHandle,
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

		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaOpenAccount(SafeLsaPolicyHandle PolicyHandle, PSID AccountSid, LsaAccountAccessMask DesiredAccess, out SafeLsaPolicyHandle AccountHandle);

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
			out SafeLsaPolicyHandle PolicyHandle);

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
		public static SafeLsaPolicyHandle LsaOpenPolicy(LsaPolicyRights DesiredAccess, string SystemName = null)
		{
			var oa = LSA_OBJECT_ATTRIBUTES.Empty;
			LsaNtStatusToWinError(LsaOpenPolicy(SystemName, ref oa, DesiredAccess, out SafeLsaPolicyHandle handle)).ThrowIfFailed();
			return handle;
		}

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
			SafeLsaPolicyHandle PolicyHandle,
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
		public static extern uint LsaSetSystemAccessAccount(SafeLsaPolicyHandle AccountHandle, int SystemAccess);

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
		private static extern uint LsaClose(IntPtr ObjectHandle);

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

		/// <summary>Used with the LsaEnumerateAccountsWithUserRight function to return a pointer to a SID.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_lsa_enumeration_information typedef struct
		// _LSA_ENUMERATION_INFORMATION { PSID Sid; } LSA_ENUMERATION_INFORMATION, *PLSA_ENUMERATION_INFORMATION;
		[PInvokeData("ntsecapi.h", MSDNShortId = "7577548f-3ceb-43a5-b447-6f66a09963fe")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_ENUMERATION_INFORMATION
		{
			/// <summary>Pointer to a SID.</summary>
			public IntPtr Sid;
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
			public IEnumerable<LSA_TRUST_INFORMATION> DomainList => Domains == IntPtr.Zero ? new LSA_TRUST_INFORMATION[0] : Domains.ToIEnum<LSA_TRUST_INFORMATION>((int)Entries);
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
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 8)]
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
			public override string ToString() => Buffer;

			/// <summary>Performs an implicit conversion from <see cref="LSA_UNICODE_STRING"/> to <see cref="string"/>.</summary>
			/// <param name="value">The value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator string(LSA_UNICODE_STRING value) => value.ToString();
		}

		/// <summary>A <see cref="SafeHandle"/> for values that must be freed using the <see cref="LsaFreeMemory(IntPtr)"/> function.</summary>
		public sealed class SafeLsaMemoryHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaMemoryHandle"/> class.</summary>
			public SafeLsaMemoryHandle() : this(IntPtr.Zero)
			{
			}

			/// <summary>Initializes a new instance of the <see cref="SafeLsaMemoryHandle"/> class.</summary>
			/// <param name="ptr">The pointer to the memory allocated by an Lsa function.</param>
			/// <param name="own">if set to <c>true</c> release the memory when out of scope.</param>
			public SafeLsaMemoryHandle(IntPtr ptr, bool own = true) : base(ptr, Free, own)
			{
			}

			private static bool Free(IntPtr h) => LsaFreeMemory(h) == 0;
		}

		/// <summary>A <see cref="SafeHandle"/> for LSA_HANDLE that calls <see cref="LsaClose(IntPtr)"/> on disposal.</summary>
		/// <seealso cref="GenericSafeHandle"/>
		public sealed class SafeLsaPolicyHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaPolicyHandle"/> class.</summary>
			public SafeLsaPolicyHandle() : base(Release) { }

			/// <summary>Initializes a new instance of the <see cref="SafeLsaPolicyHandle"/> class.</summary>
			/// <param name="ptr">The PTR.</param>
			/// <param name="own">if set to <c>true</c> [own].</param>
			public SafeLsaPolicyHandle(IntPtr ptr, bool own = true) : base(ptr, Release, own) { }

			/// <summary>Releases the specified handle.</summary>
			/// <param name="handle">The handle.</param>
			/// <returns></returns>
			private static bool Release(IntPtr handle) => LsaClose(handle) == 0;
		}

		/// <summary>A <see cref="SafeHandle"/> for values that must be freed using the <see cref="LsaFreeReturnBuffer(IntPtr)"/> function.</summary>
		public sealed class SafeLsaReturnBufferHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaReturnBufferHandle"/> class.</summary>
			public SafeLsaReturnBufferHandle() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafeLsaReturnBufferHandle"/> class.</summary>
			/// <param name="ptr">The pointer to the memory allocated by an Lsa function.</param>
			/// <param name="own">if set to <c>true</c> release the memory when out of scope.</param>
			public SafeLsaReturnBufferHandle(IntPtr ptr, bool own = true) : base(ptr, Free, own) { }

			private static bool Free(IntPtr h) => LsaFreeReturnBuffer(h) == 0;
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
				if (pastCallArraySizes.TryGetValue(pNativeData, out int length))
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
	}
}