using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.NetSecApi;

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
			/// This access type is needed to read the target system's miscellaneous security policy information. This includes the default quota, auditing,
			/// server state and role information, and trust information. This access type is also needed to enumerate trusted domains, accounts, and privileges.
			/// </summary>
			POLICY_VIEW_LOCAL_INFORMATION = 1,

			/// <summary>This access type is needed to view audit trail or audit requirements information.</summary>
			POLICY_VIEW_AUDIT_INFORMATION = 2,

			/// <summary>This access type is needed to view sensitive information, such as the names of accounts established for trusted domain relationships.</summary>
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
			/// This access type is needed to change the characteristics of the audit trail such as its maximum size or the retention period for audit records,
			/// or to clear the log.
			/// </summary>
			POLICY_AUDIT_LOG_ADMIN = 0x200,

			/// <summary>
			/// This access type is needed to modify the server state or role (master/replica) information. It is also needed to change the replica source and
			/// account name information.
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
		/// The LsaAddAccountRights function assigns one or more privileges to an account. If the account does not exist, LsaAddAccountRights creates it.
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. If the account identified by the AccountSid parameter does
		/// not exist, the handle must have the POLICY_CREATE_ACCOUNT access right. For more information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="pSID">Pointer to the SID of the account to which the function assigns privileges.</param>
		/// <param name="UserRights">
		/// Pointer to an array of strings. Each string contains the name of a privilege to add to the account. For a list of privilege names, see Privilege Constants.
		/// </param>
		/// <param name="CountOfRights">Specifies the number of elements in the UserRights array.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code, which can be the following
		/// value or one of the LSA Policy Function Return Values.
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
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code.For more information, see
		/// LSA Policy Function Return Values. You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaCreateAccount(SafeLsaPolicyHandle PolicyHandle, PSID AccountSid, LsaAccountAccessMask DesiredAccess, out SafeLsaPolicyHandle AccountHandle);

		/// <summary>The LsaEnumerateAccountRights function enumerates the privileges assigned to an account.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="AccountSid">Pointer to the SID of the account for which to enumerate privileges.</param>
		/// <param name="UserRights">
		/// Receives a pointer to an array of LSA_UNICODE_STRING structures. Each structure contains the name of a privilege held by the account. For a list of
		/// privilege names, see Privilege Constants.
		/// </param>
		/// <param name="CountOfRights">Pointer to a variable that receives the number of privileges in the UserRights array.</param>
		/// <returns>
		/// If at least one account right is found, the function succeeds and returns STATUS_SUCCESS.
		/// <para>
		/// If no account rights are found or if the function fails for any other reason, the function returns an NTSTATUS code such as FILE_NOT_FOUND. For more
		/// information, see LSA Policy Function Return Values. Use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.
		/// </para>
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaEnumerateAccountRights(
			SafeLsaPolicyHandle PolicyHandle,
			PSID AccountSid,
			out SafeLsaMemoryHandle UserRights,
			out uint CountOfRights);

		/// <summary>The LsaEnumerateAccountRights function enumerates the privileges assigned to an account.</summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="AccountSid">Pointer to the SID of the account for which to enumerate privileges.</param>
		/// <returns>An enumeration of strings containing the names of privileges held by the account. For a list of privilege names, see Privilege Constants.</returns>
		public static IEnumerable<string> LsaEnumerateAccountRights(SafeLsaPolicyHandle PolicyHandle, PSID AccountSid)
		{
			var ret = LsaEnumerateAccountRights(PolicyHandle, AccountSid, out SafeLsaMemoryHandle mem, out uint cnt);
			var winErr = LsaNtStatusToWinError(ret);
			if (winErr == Win32Error.ERROR_FILE_NOT_FOUND) return new string[0];
			winErr.ThrowIfFailed();
			return mem.DangerousGetHandle().ToIEnum<LSA_UNICODE_STRING>((int) cnt).Select(u => (string) u.ToString().Clone());
		}

		/// <summary>
		/// The LsaEnumerateAccountsWithUserRight function returns the accounts in the database of a Local Security Authority (LSA) Policy object that hold a
		/// specified privilege. The accounts returned by this function hold the specified privilege directly through the user account, not as part of membership
		/// to a group.
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have POLICY_LOOKUP_NAMES and POLICY_VIEW_LOCAL_INFORMATION user rights. For more information, see
		/// Opening a Policy Object Handle.
		/// </param>
		/// <param name="UserRights">
		/// A string that specifies the name of a privilege. For a list of privileges, see Privilege Constants and Account Rights Constants.
		/// <para>If this parameter is NULL, the function enumerates all accounts in the LSA database of the system associated with the Policy object.</para>
		/// </param>
		/// <param name="EnumerationBuffer">
		/// Pointer to a variable that receives a pointer to an array of LSA_ENUMERATION_INFORMATION structures. The Sid member of each structure is a pointer to
		/// the security identifier (SID) of an account that holds the specified privilege.
		/// </param>
		/// <param name="CountReturned">Pointer to a variable that receives the number of entries returned in the EnumerationBuffer parameter.</param>
		/// <returns>
		/// If the function succeeds, the function returns STATUS_SUCCESS. If the function fails, it returns an NTSTATUS code, which can be one of the following
		/// values or one of the LSA Policy Function Return Values.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaEnumerateAccountsWithUserRight(
			SafeLsaPolicyHandle PolicyHandle,
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string UserRights,
			out SafeLsaMemoryHandle EnumerationBuffer,
			out int CountReturned);

		/// <summary>
		/// The LsaEnumerateAccountsWithUserRight function returns the accounts in the database of a Local Security Authority (LSA) Policy object that hold a
		/// specified privilege. The accounts returned by this function hold the specified privilege directly through the user account, not as part of membership
		/// to a group.
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have POLICY_LOOKUP_NAMES and POLICY_VIEW_LOCAL_INFORMATION user rights. For more information, see
		/// Opening a Policy Object Handle.
		/// </param>
		/// <param name="UserRights">
		/// A string that specifies the name of a privilege. For a list of privileges, see Privilege Constants and Account Rights Constants.
		/// <para>If this parameter is NULL, the function enumerates all accounts in the LSA database of the system associated with the Policy object.</para>
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
		/// The LsaLookupNames2 function retrieves the security identifiers (SIDs) for specified account names. LsaLookupNames2 can look up the SID for any
		/// account in any domain in a Windows forest.
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="Flags">Values that control the behavior of this function.</param>
		/// <param name="Count">Specifies the number of names in the Names array. This is also the number of entries returned in the Sids array.</param>
		/// <param name="Names">
		/// An array of strings that contain the names to look up. These strings can be the names of user, group, or local group accounts, or the names of
		/// domains. Domain names can be DNS domain names or NetBIOS domain names.
		/// </param>
		/// <param name="ReferencedDomains">
		/// Receives a pointer to an LSA_REFERENCED_DOMAIN_LIST structure. The Domains member of this structure is an array that contains an entry for each
		/// domain in which a name was found. The DomainIndex member of each entry in the Sids array is the index of the Domains array entry for the domain in
		/// which the name was found.
		/// </param>
		/// <param name="Sids">
		/// Receives a pointer to an array of LSA_TRANSLATED_SID2 structures. Each entry in the Sids array contains the SID information for the corresponding
		/// entry in the Names array.
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns one of the following NTSTATUS values. If the function fails, the return value is the following
		/// NTSTATUS value or one of the LSA Policy Function Return Values.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern uint LsaLookupNames2(
			SafeLsaPolicyHandle PolicyHandle,
			LsaLookupNamesFlags Flags,
			uint Count,
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringArrayMarshaler))]
			string[] Names,
			out SafeLsaMemoryHandle ReferencedDomains,
			out SafeLsaMemoryHandle Sids);

		/// <summary>The LsaLookupSids2 function looks up the names that correspond to an array of security identifiers (SIDs) and supports Internet provider identities. If LsaLookupSids2 cannot find a name that corresponds to a SID, the function returns the SID in character form. You should use this function instead of the LsaLookupSids function.</summary>
		/// <param name="PolicyHandle">A handle to a Policy object. This handle must have the POLICY_LOOKUP_NAMES access right.</param>
		/// <param name="LookupOptions">Flags that modify the lookup behavior.</param>
		/// <param name="Count">Specifies the number of SIDs in the Sids array. This is also the number of entries returned in the Names array.</param>
		/// <param name="Sids">Pointer to an array of SID pointers to look up. The SIDs can be well-known SIDs, user, group, or local group account SIDs, or domain SIDs.</param>
		/// <param name="ReferencedDomains">Receives a pointer to a pointer to a LSA_REFERENCED_DOMAIN_LIST structure. The Domains member of this structure is an array that contains an entry for each domain in which a SID was found. The entry for each domain contains the SID and flat name of the domain. For Windows domains, the flat name is the NetBIOS name. For links with non–Windows domains, the flat name is the identifying name of that domain, or it is NULL.
		/// <para>When you no longer need the information, pass the returned pointer to LsaFreeMemory. This memory must be freed even when the function fails with the either of the error codes STATUS_NONE_MAPPED or STATUS_SOME_NOT_MAPPED</para></param>
		/// <param name="Names">Receives a pointer to an array of LSA_TRANSLATED_NAME structures. Each entry in the Names array contains the name information for the corresponding entry in the Sids array. For account SIDs, the Name member of each structure contains the isolated name of the account. For domain SIDs, the Name member is not valid.
		/// <para>The DomainIndex member of each entry in the Names array is the index of an entry in the Domains array returned in the ReferencedDomains parameter. The index identifies the Domains array for the domain in which the SID was found.</para>
		/// <para>When you no longer need the information, pass the returned pointer to LsaFreeMemory. This memory must be freed even when the function fails with the either of the error codes STATUS_NONE_MAPPED or STATUS_SOME_NOT_MAPPED</para></param>
		/// <returns>
		/// If the function succeeds, the function returns one of the following NTSTATUS values. If the function fails, the return value is the following
		/// NTSTATUS value or one of the LSA Policy Function Return Values.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern uint LsaLookupSids2(
			SafeLsaPolicyHandle PolicyHandle,
			LsaLookupSidsFlags LookupOptions,
			uint Count,
			[In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] Sids,
			out SafeLsaMemoryHandle ReferencedDomains,
			out SafeLsaMemoryHandle Names);

		/// <summary>The LsaNtStatusToWinError function converts an NTSTATUS code returned by an LSA function to a Windows error code.</summary>
		/// <param name="NTSTATUS">An NTSTATUS code returned by an LSA function call. This value will be converted to a System error code.</param>
		/// <returns>
		/// The return value is the Windows error code that corresponds to the Status parameter. If there is no corresponding Windows error code, the return
		/// value is ERROR_MR_MID_NOT_FOUND.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern Win32Error LsaNtStatusToWinError(uint NTSTATUS);

		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaOpenAccount(SafeLsaPolicyHandle PolicyHandle, PSID AccountSid, LsaAccountAccessMask DesiredAccess, out SafeLsaPolicyHandle AccountHandle);

		/// <summary>
		/// The LsaOpenPolicy function opens a handle to the Policy object on a local or remote system. You must run the process "As Administrator" so that the
		/// call doesn't fail with ERROR_ACCESS_DENIED.
		/// </summary>
		/// <param name="SystemName">
		/// Name of the target system. The name can have the form "ComputerName" or "\\ComputerName". If this parameter is NULL, the function opens the Policy
		/// object on the local system.
		/// </param>
		/// <param name="ObjectAttributes">
		/// A pointer to an LSA_OBJECT_ATTRIBUTES structure that specifies the connection attributes. The structure members are not used; initialize them to NULL
		/// or zero.
		/// </param>
		/// <param name="DesiredAccess">
		/// An ACCESS_MASK that specifies the requested access rights. The function fails if the DACL of the target system does not allow the caller the
		/// requested access. To determine the access rights that you need, see the documentation for the LSA functions with which you want to use the policy handle.
		/// </param>
		/// <param name="PolicyHandle">A pointer to an LSA_HANDLE variable that receives a handle to the Policy object.</param>
		/// <returns>
		/// If the function succeeds, the function returns STATUS_SUCCESS. If the function fails, it returns an NTSTATUS code.For more information, see LSA
		/// Policy Function Return Values.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true), SuppressUnmanagedCodeSecurity]
		public static extern uint LsaOpenPolicy(
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string SystemName,
			ref LSA_OBJECT_ATTRIBUTES ObjectAttributes,
			LsaPolicyRights DesiredAccess,
			out SafeLsaPolicyHandle PolicyHandle);

		/// <summary>
		/// The LsaOpenPolicy function opens a handle to the Policy object on a local or remote system. You must run the process "As Administrator" so that the
		/// call doesn't fail with ERROR_ACCESS_DENIED.
		/// </summary>
		/// <param name="DesiredAccess">
		/// An ACCESS_MASK that specifies the requested access rights. The function fails if the DACL of the target system does not allow the caller the
		/// requested access. To determine the access rights that you need, see the documentation for the LSA functions with which you want to use the policy handle.
		/// </param>
		/// <param name="SystemName">
		/// Name of the target system. The name can have the form "ComputerName" or "\\ComputerName". If this parameter is NULL, the function opens the Policy
		/// object on the local system.
		/// </param>
		/// <returns>A pointer to an LSA_HANDLE variable that receives a handle to the Policy object.</returns>
		public static SafeLsaPolicyHandle LsaOpenPolicy(LsaPolicyRights DesiredAccess, string SystemName = null)
		{
			var oa = LSA_OBJECT_ATTRIBUTES.Empty;
			LsaNtStatusToWinError(LsaOpenPolicy(SystemName, ref oa, DesiredAccess, out SafeLsaPolicyHandle handle)).ThrowIfFailed();
			return handle;
		}

		/// <summary>
		/// The LsaRemoveAccountRights function removes one or more privileges from an account. You can specify the privileges to be removed, or you can set a
		/// flag to remove all privileges. When you remove all privileges, the function deletes the account. If you specify privileges not held by the account,
		/// the function ignores them.
		/// </summary>
		/// <param name="PolicyHandle">
		/// A handle to a Policy object. The handle must have the POLICY_LOOKUP_NAMES access right. For more information, see Opening a Policy Object Handle.
		/// </param>
		/// <param name="AccountSid">Pointer to the security identifier (SID) of the account from which the privileges are removed.</param>
		/// <param name="AllRights">
		/// If TRUE, the function removes all privileges and deletes the account. In this case, the function ignores the UserRights parameter. If FALSE, the
		/// function removes the privileges specified by the UserRights parameter.
		/// </param>
		/// <param name="UserRights">
		/// An array of strings. Each string contains the name of a privilege to be removed from the account. For a list of privilege names, see Privilege Constants.
		/// </param>
		/// <param name="CountOfRights">Specifies the number of elements in the UserRights array.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code, which can be one of the
		/// following values or one of the LSA Policy Function Return Values.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
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
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code, which can be one of the
		/// following values or one of the LSA Policy Function Return Values.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		public static extern uint LsaSetSystemAccessAccount(SafeLsaPolicyHandle AccountHandle, int SystemAccess);

		/// <summary>The LsaClose function closes a handle to a Policy or TrustedDomain object.</summary>
		/// <param name="ObjectHandle">
		/// A handle to a Policy object returned by the LsaOpenPolicy function or to a TrustedDomain object returned by the LsaOpenTrustedDomainByName function.
		/// Following the completion of this call, the handle is no longer valid.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code.For more information, see
		/// LSA Policy Function Return Values. You can use the LsaNtStatusToWinError function to convert the NTSTATUS code to a Windows error code.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		private static extern uint LsaClose(IntPtr ObjectHandle);

		/// <summary>
		/// The LsaFreeMemory function frees memory allocated for an output buffer by an LSA function call. LSA functions that return variable-length output
		/// buffers always allocate the buffer on behalf of the caller. The caller must free this memory by passing the returned buffer pointer to LsaFreeMemory
		/// when the memory is no longer required.
		/// </summary>
		/// <param name="Buffer">Pointer to memory buffer that was allocated by an LSA function call. If LsaFreeMemory is successful, this buffer is freed.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code, which can be the following
		/// value or one of the LSA Policy Function Return Values.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		private static extern uint LsaFreeMemory(IntPtr Buffer);

		/// <summary>The LsaFreeReturnBuffer function frees the memory used by a buffer previously allocated by the LSA.</summary>
		/// <param name="Buffer">Pointer to the buffer to be freed.</param>
		/// <returns>If the function succeeds, the return value is STATUS_SUCCESS. If the function fails, the return value is an NTSTATUS code.</returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		private static extern uint LsaFreeReturnBuffer(IntPtr Buffer);

		/// <summary>Used with the LsaEnumerateAccountsWithUserRight function to return a pointer to a SID.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_ENUMERATION_INFORMATION
		{
			/// <summary>Pointer to a SID.</summary>
			public IntPtr Sid;
		}

		/// <summary>Contains information about the domains referenced in a lookup operation.</summary>
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

		/// <summary>Identifies a domain.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct LSA_TRUST_INFORMATION
		{
			/// <summary>An LSA_UNICODE_STRING structure that contains the name of the domain.</summary>
			public LSA_UNICODE_STRING Name;

			/// <summary>Pointer to the SID of the domain.</summary>
			public IntPtr Sid;
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

		/// <summary>
		/// The LSA_UNICODE_STRING structure is used by various Local Security Authority (LSA) functions to specify a Unicode string. Also an example of
		/// unnecessary over-engineering and re-engineering.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 8)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "ms721841")]
		public struct LSA_UNICODE_STRING
		{
			/// <summary>
			/// Specifies the length, in bytes, of the string pointed to by the Buffer member, not including the terminating null character, if any.
			/// </summary>
			public ushort length;

			/// <summary>
			/// Specifies the total size, in bytes, of the memory allocated for Buffer. Up to MaximumLength bytes can be written into the buffer without
			/// trampling memory.
			/// </summary>
			public ushort MaximumLength;

			/// <summary>Pointer to a wide character string. Note that the strings returned by the various LSA functions might not be null-terminated.</summary>
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