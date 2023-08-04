using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>Access mask for accounts.</summary>
	[Flags]
	[PInvokeData("ntlsa.h")]
	public enum LsaAccountAccessMask : uint
	{
		/// <summary>
		/// This access type is required to read the account information. This includes the privileges assigned to the account, memory
		/// quotas assigned, and any special access types granted.
		/// </summary>
		ACCOUNT_VIEW = 0x00000001,

		/// <summary>This access type is required to assign privileges to or remove privileges from an account.</summary>
		ACCOUNT_ADJUST_PRIVILEGES = 0x00000002,

		/// <summary>This access type is required to change the system quotas assigned to an account.</summary>
		ACCOUNT_ADJUST_QUOTAS = 0x00000004,

		/// <summary>This access type is required to update the system access flags for the account.</summary>
		ACCOUNT_ADJUST_SYSTEM_ACCESS = 0x00000008,

		/// <summary>The account all access</summary>
		ACCOUNT_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED |
							 ACCOUNT_VIEW |
							 ACCOUNT_ADJUST_PRIVILEGES |
							 ACCOUNT_ADJUST_QUOTAS |
							 ACCOUNT_ADJUST_SYSTEM_ACCESS,

		/// <summary>The account read</summary>
		ACCOUNT_READ = ACCESS_MASK.STANDARD_RIGHTS_READ |
					   ACCOUNT_VIEW,

		/// <summary>The account write</summary>
		ACCOUNT_WRITE = ACCESS_MASK.STANDARD_RIGHTS_WRITE |
						ACCOUNT_ADJUST_PRIVILEGES |
						ACCOUNT_ADJUST_QUOTAS |
						ACCOUNT_ADJUST_SYSTEM_ACCESS,

		/// <summary>The account execute</summary>
		ACCOUNT_EXECUTE = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE,
	}

	/// <summary>Flags used by LsaLookupNames2.</summary>
	[Flags]
	[PInvokeData("ntlsa.h")]
	public enum LsaLookupNamesFlags : uint
	{
		/// <summary>
		/// The function searches only on the local systems for names that do not specify a domain. The function does search on remote
		/// systems for names that do specify a domain.
		/// </summary>
		LSA_LOOKUP_ISOLATED_AS_LOCAL = 0x80000000
	}

	/// <summary>Flags used by LsaLookupSids2.</summary>
	[Flags]
	[PInvokeData("ntlsa.h")]
	public enum LsaLookupSidsFlags : uint
	{
		/// <summary>
		/// Internet SIDs from identity providers for connected accounts are disallowed. Connected accounts are those accounts which have
		/// a corresponding shadow account in the local SAM database connected to an online identity provider. For example,
		/// MicrosoftAccount is a connected account.
		/// </summary>
		LSA_LOOKUP_DISALLOW_CONNECTED_ACCOUNT_INTERNET_SID = 0x80000000,

		/// <summary>
		/// Returns the internet names. Otherwise the NT4 style name (domain\username) is returned. The exception is if the Microsoft
		/// Account internet SID is specified, in which case the internet name is returned unless
		/// LSA_LOOKUP_DISALLOW_NON_WINDOWS_INTERNET_SID is specified.
		/// </summary>
		LSA_LOOKUP_PREFER_INTERNET_NAMES = 0x40000000,

		/// <summary>Always returns local SAM account names even for Internet provider identities.</summary>
		LSA_LOOKUP_RETURN_LOCAL_NAMES = 0
	}

	/// <summary>
	/// The <c>LsaGetAppliedCAPIDs</c> function returns an array of central access policies (CAPs) identifiers (CAPIDs) of all the CAPs
	/// applied on a specific computer.
	/// </summary>
	/// <param name="systemName">
	/// A pointer to an LSA_UNICODE_STRING structure that contains the name of the specific computer. The name can have the form of
	/// "ComputerName" or "\ComputerName". If this parameter is <c>NULL</c>, then the function returns the CAPIDs of the local computer.
	/// </param>
	/// <param name="CAPIDs">
	/// A pointer to a variable that receives an array of pointers to CAPIDs that identify the CAPs available on the specified computer.
	/// When you have finished using the CAPIDs, call the LsaFreeMemory function on each element in the array and the entire array.
	/// </param>
	/// <param name="CAPIDCount">
	/// A pointer to a variable that receives the number of CAPs that are available on the specified computer. The array returned in the
	/// CAPIDs parameter contains the same number of elements as the CAPIDCount parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is one of the LSA Policy Function Return Values. You can use the LsaNtStatusToWinError
	/// function to convert the <c>NTSTATUS</c> code to a Windows error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// For specific details about the central access policies, you can query the attributes of the central access policy object in the
	/// Active Directory on the specified computer's domain controller. Look for the object whose <c>msAuthz-CentralAccessPolicyID</c>
	/// attribute matches one of the returned CAPIDs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntlsa/nf-ntlsa-lsagetappliedcapids
	// NTSTATUS LsaGetAppliedCAPIDs( PLSA_UNICODE_STRING SystemName, PSID **CAPIDs, PULONG CAPIDCount );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntlsa.h", MSDNShortId = "DF10F5CE-BBF5-4CA8-919B-F59B7775C983")]
	public static extern NTStatus LsaGetAppliedCAPIDs(
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string? systemName,
		out SafeLsaMemoryHandle CAPIDs, out uint CAPIDCount);

	/// <summary>
	/// The <c>LsaGetAppliedCAPIDs</c> function returns an array of central access policies (CAPs) identifiers (CAPIDs) of all the CAPs
	/// applied on a specific computer.
	/// </summary>
	/// <param name="SystemName">
	/// A pointer to an LSA_UNICODE_STRING structure that contains the name of the specific computer. The name can have the form of
	/// "ComputerName" or "\ComputerName". If this parameter is <c>NULL</c>, then the function returns the CAPIDs of the local computer.
	/// </param>
	/// <returns>An array of pointers to CAPIDs that identify the CAPs available on the specified computer.</returns>
	/// <remarks>
	/// For specific details about the central access policies, you can query the attributes of the central access policy object in the
	/// Active Directory on the specified computer's domain controller. Look for the object whose <c>msAuthz-CentralAccessPolicyID</c>
	/// attribute matches one of the returned CAPIDs.
	/// </remarks>
	[PInvokeData("ntlsa.h", MSDNShortId = "DF10F5CE-BBF5-4CA8-919B-F59B7775C983")]
	public static IEnumerable<PSID> LsaGetAppliedCAPIDs([Optional] string? SystemName)
	{
		LsaGetAppliedCAPIDs(SystemName, out var pCapIds, out var idCnt).ThrowIfFailed();
		return pCapIds.ToArray<PSID>((int)idCnt);
	}

	/// <summary>
	/// <para>
	/// Retrieves the locally unique identifier (LUID) used by the Local Security Authority (LSA) to represent the specified privilege name.
	/// </para>
	/// <para>This function is not declared in a public header.</para>
	/// <para>Do not use this function. Instead, use LookupPrivilegeValue.</para>
	/// </summary>
	/// <param name="PolicyHandle">
	/// <para>A handle to the LSA Policy object.</para>
	/// </param>
	/// <param name="Name">
	/// <para>A pointer to a null-terminated string that specifies the name of the privilege, as defined in the Winnt.h header file.</para>
	/// </param>
	/// <param name="Value">
	/// <para>A pointer to a variable that receives the LUID by which the privilege is known by the LSA.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, return <c>STATUS_SUCCESS</c>.</para>
	/// <para>If the function fails, return an <c>NTSTATUS</c> code that indicates the reason it failed.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntlsa/nf-ntlsa-lsalookupprivilegevalue NTSTATUS LsaLookupPrivilegeValue(
	// LSA_HANDLE PolicyHandle, PLSA_UNICODE_STRING Name, PLUID Value );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntlsa.h", MSDNShortId = "4926fff9-6e1a-475c-95ab-78c9b67aaa87")]
	public static extern NTStatus LsaLookupPrivilegeValue(LSA_HANDLE PolicyHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string Name, out LUID Value);

	/// <summary>
	/// <para>Returns the Central Access Policies (CAPs) for the specified IDs.</para>
	/// </summary>
	/// <param name="CAPIDs">
	/// <para>A pointer to a variable that contains an array of pointers to CAPIDs that identify the CAPs being queried.</para>
	/// </param>
	/// <param name="CAPIDCount">
	/// <para>The number of IDs in the CAPIDs parameter.</para>
	/// </param>
	/// <param name="CAPs">
	/// <para>Receives a pointer to an array of pointers to CENTRAL_ACCESS_POLICY structures representing the queried CAPs.</para>
	/// </param>
	/// <param name="CAPCount">
	/// <para>The number of CENTRAL_ACCESS_POLICY structure pointers returned in the CAPs parameter.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
	/// <para>If the function fails, the return value is an NTSTATUS code, which can be one of the LSA Policy Function Return Values.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntlsa/nf-ntlsa-lsaquerycaps NTSTATUS LsaQueryCAPs( PSID *CAPIDs, ULONG
	// CAPIDCount, PCENTRAL_ACCESS_POLICY *CAPs, PULONG CAPCount );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntlsa.h", MSDNShortId = "55D6FD6F-0FD5-41F6-967B-F5600E19C3EF")]
	public static extern NTStatus LsaQueryCAPs([In] PSID[] CAPIDs, uint CAPIDCount, out SafeLsaMemoryHandle CAPs, out uint CAPCount);

	/// <summary>
	/// <para>Returns the Central Access Policies (CAPs) for the specified IDs.</para>
	/// </summary>
	/// <param name="CAPIDs">
	/// <para>A pointer to a variable that contains an array of pointers to CAPIDs that identify the CAPs being queried.</para>
	/// </param>
	/// <param name="CAPIDCount">
	/// <para>The number of IDs in the CAPIDs parameter.</para>
	/// </param>
	/// <param name="CAPs">
	/// <para>Receives a pointer to an array of pointers to CENTRAL_ACCESS_POLICY structures representing the queried CAPs.</para>
	/// </param>
	/// <param name="CAPCount">
	/// <para>The number of CENTRAL_ACCESS_POLICY structure pointers returned in the CAPs parameter.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
	/// <para>If the function fails, the return value is an NTSTATUS code, which can be one of the LSA Policy Function Return Values.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntlsa/nf-ntlsa-lsaquerycaps NTSTATUS LsaQueryCAPs( PSID *CAPIDs, ULONG
	// CAPIDCount, PCENTRAL_ACCESS_POLICY *CAPs, PULONG CAPCount );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntlsa.h", MSDNShortId = "55D6FD6F-0FD5-41F6-967B-F5600E19C3EF")]
	public static extern NTStatus LsaQueryCAPs([In] IntPtr CAPIDs, uint CAPIDCount, out SafeLsaMemoryHandle CAPs, out uint CAPCount);

	/// <summary>
	/// <para>Represents a central access policy that contains a set of central access policy entries.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntlsa/ns-ntlsa-_central_access_policy typedef struct _CENTRAL_ACCESS_POLICY {
	// PSID CAPID; LSA_UNICODE_STRING Name; LSA_UNICODE_STRING Description; LSA_UNICODE_STRING ChangeId; ULONG Flags; ULONG CAPECount;
	// PCENTRAL_ACCESS_POLICY_ENTRY *CAPEs; } CENTRAL_ACCESS_POLICY, *PCENTRAL_ACCESS_POLICY;
	[PInvokeData("ntlsa.h", MSDNShortId = "C1C2E8AE-0B7F-4620-9C27-31DAF683E342")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CENTRAL_ACCESS_POLICY
	{
		/// <summary>
		/// <para>The identifier of the central access policy.</para>
		/// </summary>
		public PSID CAPID;

		/// <summary>
		/// <para>The name of the central access policy.</para>
		/// </summary>
		public LSA_UNICODE_STRING Name;

		/// <summary>
		/// <para>The description of the central access policy.</para>
		/// </summary>
		public LSA_UNICODE_STRING Description;

		/// <summary>
		/// <para>An identifier that can be used to version the central access policy.</para>
		/// </summary>
		public LSA_UNICODE_STRING ChangeId;

		/// <summary>
		/// <para>Reserved.</para>
		/// </summary>
		public uint Flags;

		/// <summary>
		/// <para>The length of the buffer pointed to by the CAPEs field.</para>
		/// </summary>
		public uint CAPECount;

		/// <summary>
		/// <para>Pointer to a buffer of CENTRAL_ACCESS_POLICY_ENTRY pointers.</para>
		/// </summary>
		public IntPtr CAPEs;
	}

	/// <summary>
	/// <para>Represents a central access policy entry containing a list of security descriptors and staged security descriptors.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntlsa/ns-ntlsa-_central_access_policy_entry typedef struct
	// _CENTRAL_ACCESS_POLICY_ENTRY { LSA_UNICODE_STRING Name; LSA_UNICODE_STRING Description; LSA_UNICODE_STRING ChangeId; ULONG
	// LengthAppliesTo; PUCHAR AppliesTo; ULONG LengthSD; PSECURITY_DESCRIPTOR SD; ULONG LengthStagedSD; PSECURITY_DESCRIPTOR StagedSD;
	// ULONG Flags; } CENTRAL_ACCESS_POLICY_ENTRY, *PCENTRAL_ACCESS_POLICY_ENTRY;
	[PInvokeData("ntlsa.h", MSDNShortId = "8667848D-096C-422E-B4A6-38CC406F0F4A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CENTRAL_ACCESS_POLICY_ENTRY
	{
		/// <summary>
		/// <para>The name of the central access policy entry.</para>
		/// </summary>
		public LSA_UNICODE_STRING Name;

		/// <summary>
		/// <para>The description of the central access policy entry.</para>
		/// </summary>
		public LSA_UNICODE_STRING Description;

		/// <summary>
		/// <para>An identifier that can be used to version the central access policy entry.</para>
		/// </summary>
		public LSA_UNICODE_STRING ChangeId;

		/// <summary>
		/// <para>The length of the buffer pointed to by the AppliesTo field.</para>
		/// </summary>
		public uint LengthAppliesTo;

		/// <summary>
		/// <para>A resource condition in binary form.</para>
		/// </summary>
		public IntPtr AppliesTo;

		/// <summary>
		/// <para>The length of the buffer pointed to by the SD field.</para>
		/// </summary>
		public uint LengthSD;

		/// <summary>
		/// <para>A buffer of security descriptors associated with the entry.</para>
		/// </summary>
		public PSECURITY_DESCRIPTOR SD;

		/// <summary>
		/// <para>The length of the buffer pointed to by the StagedSD field.</para>
		/// </summary>
		public uint LengthStagedSD;

		/// <summary>
		/// <para>A buffer of staged security descriptors associated with the entry.</para>
		/// </summary>
		public PSECURITY_DESCRIPTOR StagedSD;

		/// <summary>
		/// <para>This field is reserved.</para>
		/// </summary>
		public uint Flags;
	}
}