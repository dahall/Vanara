using System.Collections.Generic;
using System.Linq;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>
	/// Flags that specify the conditions under which the security event type specified by the AuditSubCategoryGuid and AuditCategoryGuid members are audited.
	/// </summary>
	[PInvokeData("ntsecapi.h")]
	[Flags]
	public enum AuditCondition : uint
	{
		/// <summary>Do not change auditing options for the specified event type.
		/// <para>This value is valid for the AuditSetSystemPolicy and AuditQuerySystemPolicy functions.</para></summary>
		POLICY_AUDIT_EVENT_UNCHANGED = 0x00000000,

		/// <summary>Audit successful occurrences of the specified event type.
		/// <para>This value is valid for the AuditSetSystemPolicy and AuditQuerySystemPolicy functions.</para></summary>
		POLICY_AUDIT_EVENT_SUCCESS = 0x00000001,

		/// <summary>Audit failed attempts to cause the specified event type.
		/// <para>This value is valid for the AuditSetSystemPolicy and AuditQuerySystemPolicy functions.</para></summary>
		POLICY_AUDIT_EVENT_FAILURE = 0x00000002,

		/// <summary>Do not audit the specified event type.
		/// <para>This value is valid for the AuditSetSystemPolicy and AuditQuerySystemPolicy functions.</para></summary>
		POLICY_AUDIT_EVENT_NONE = 0x00000004,

		/// <summary>Do not change auditing options for the specified event type.
		/// <para>This value is valid for the AuditSetPerUserPolicy and AuditQueryPerUserPolicy functions.</para></summary>
		PER_USER_POLICY_UNCHANGED = 0x00,

		/// <summary>Audit successful occurrences of the specified event type.
		/// <para>This value is valid for the AuditSetPerUserPolicy and AuditQueryPerUserPolicy functions.</para></summary>
		PER_USER_AUDIT_SUCCESS_INCLUDE = 0x01,

		/// <summary>Do not audit successful occurrences of the specified event type.
		/// <para>This value is valid for the AuditSetPerUserPolicy and AuditQueryPerUserPolicy functions.</para></summary>
		PER_USER_AUDIT_SUCCESS_EXCLUDE = 0x02,

		/// <summary>Audit failed attempts to cause the specified event type.
		/// <para>This value is valid for the AuditSetPerUserPolicy and AuditQueryPerUserPolicy functions.</para></summary>
		PER_USER_AUDIT_FAILURE_INCLUDE = 0x04,

		/// <summary>Do not audit failed attempts to cause the specified event type.
		/// <para>This value is valid for the AuditSetPerUserPolicy and AuditQueryPerUserPolicy functions.</para></summary>
		PER_USER_AUDIT_FAILURE_EXCLUDE = 0x08,

		/// <summary>Do not audit the specified event type.
		/// <para>This value is valid for the AuditSetPerUserPolicy and AuditQueryPerUserPolicy functions.</para></summary>
		PER_USER_AUDIT_NONE = 0x10,
	}

	/// <summary>
	/// The <c>POLICY_AUDIT_EVENT_TYPE</c> enumeration defines values that indicate the types of events the system can audit. The
	/// LsaQueryInformationPolicy and LsaSetInformationPolicy functions use this enumeration when their InformationClass parameters are
	/// set to PolicyAuditEventsInformation.
	/// </summary>
	/// <remarks>
	/// The <c>POLICY_AUDIT_EVENT_TYPE</c> enumeration may expand in future versions of Windows. Because of this, you should not compute
	/// the number of values in this enumeration directly. Instead, you should obtain the count of values by calling
	/// LsaQueryInformationPolicy with the InformationClass parameter set to PolicyAuditEventsInformation and extract the count from the
	/// <c>MaximumAuditEventCount</c> member of the returned POLICY_AUDIT_EVENTS_INFO structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ne-ntsecapi-_policy_audit_event_type typedef enum
	// _POLICY_AUDIT_EVENT_TYPE { AuditCategorySystem, AuditCategoryLogon, AuditCategoryObjectAccess, AuditCategoryPrivilegeUse,
	// AuditCategoryDetailedTracking, AuditCategoryPolicyChange, AuditCategoryAccountManagement, AuditCategoryDirectoryServiceAccess,
	// AuditCategoryAccountLogon } POLICY_AUDIT_EVENT_TYPE, *PPOLICY_AUDIT_EVENT_TYPE;
	[PInvokeData("ntsecapi.h", MSDNShortId = "e8dbd1d5-37d5-4a97-9d1c-c645871dc7a5")]
	public enum POLICY_AUDIT_EVENT_TYPE
	{
		/// <summary>Determines whether the operating system must audit any of the following attempts:</summary>
		AuditCategorySystem,

		/// <summary>
		/// Determines whether the operating system must audit each time this computer validates the credentials of an account. Account
		/// logon events are generated whenever a computer validates the credentials of one of its local accounts. The credential
		/// validation can be in support of a local logon or, in the case of an Active Directory domain account on a domain controller,
		/// can be in support of a logon to another computer. Audited events for local accounts must be logged on the local security log
		/// of the computer. Account logoff does not generate an event that can be audited.
		/// </summary>
		AuditCategoryLogon,

		/// <summary>
		/// Determines whether the operating system must audit each instance of user attempts to access a non-Active Directory object,
		/// such as a file, that has its own system access control list (SACL) specified. The type of access request, such as Write,
		/// Read, or Modify, and the account that is making the request must match the settings in the SACL.
		/// </summary>
		AuditCategoryObjectAccess,

		/// <summary>Determines whether the operating system must audit each instance of user attempts to use privileges.</summary>
		AuditCategoryPrivilegeUse,

		/// <summary>
		/// Determines whether the operating system must audit specific events, such as program activation, some forms of handle
		/// duplication, indirect access to an object, and process exit.
		/// </summary>
		AuditCategoryDetailedTracking,

		/// <summary>
		/// Determines whether the operating system must audit attempts to change Policy object rules, such as user rights assignment
		/// policy, audit policy, account policy, or trust policy.
		/// </summary>
		AuditCategoryPolicyChange,

		/// <summary>
		/// Determines whether the operating system must audit attempts to create, delete, or change user or group accounts. Also, audit
		/// password changes.
		/// </summary>
		AuditCategoryAccountManagement,

		/// <summary>
		/// Determines whether the operating system must audit attempts to access the directory service. The Active Directory object has
		/// its own SACL specified. The type of access request, such as Write, Read, or Modify, and the account that is making the
		/// request must match the settings in the SACL.
		/// </summary>
		AuditCategoryDirectoryServiceAccess,

		/// <summary>
		/// Determines whether the operating system must audit each instance of a user attempt to log on or log off this computer. Also
		/// audits logon attempts by privileged accounts that log on to the domain controller. These audit events are generated when the
		/// Kerberos Key Distribution Center (KDC) logs on to the domain controller. Logoff attempts are generated whenever the logon
		/// session of a logged-on user account is terminated.
		/// </summary>
		AuditCategoryAccountLogon,
	}

	/// <summary>
	/// The <c>AuditComputeEffectivePolicyBySid</c> function computes the effective audit policy for one or more subcategories for the
	/// specified security principal. The function computes effective audit policy by combining system audit policy with per-user policy.
	/// </summary>
	/// <param name="pSid">
	/// A pointer to the SID structure associated with the principal for which to compute effective audit policy. Per-user policy for
	/// group SIDs is not currently supported.
	/// </param>
	/// <param name="pSubCategoryGuids">
	/// A pointer to an array of <c>GUID</c> values that specify the subcategories for which to compute effective audit policy. For a
	/// list of defined subcategories, see Auditing Constants.
	/// </param>
	/// <param name="dwPolicyCount">The number of elements in each of the pSubCategoryGuids and ppAuditPolicy arrays.</param>
	/// <param name="ppAuditPolicy">
	/// <para>
	/// A pointer to a single buffer that contains both an array of pointers to AUDIT_POLICY_INFORMATION structures and the structures
	/// themselves. The <c>AUDIT_POLICY_INFORMATION</c> structures specify the effective audit policy for the subcategories specified by
	/// the pSubCategoryGuids array.
	/// </para>
	/// <para>When you have finished using this buffer, free it by calling the AuditFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87 (0x57)</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND 2 (0x2)</term>
	/// <term>No per-user audit policy exists for the principal specified by the pSid parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have <c>AUDIT_QUERY_SYSTEM_POLICY</c> and
	/// <c>AUDIT_QUERY_USER_POLICY</c> access on the Audit security object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditcomputeeffectivepolicybysid BOOLEAN
	// AuditComputeEffectivePolicyBySid( const PSID pSid, const GUID *pSubCategoryGuids, ULONG dwPolicyCount, PAUDIT_POLICY_INFORMATION
	// *ppAuditPolicy );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "cac928e5-8d8f-4b2f-9c1b-c00dc891e3d1")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditComputeEffectivePolicyBySid(PSID pSid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[] pSubCategoryGuids, uint dwPolicyCount, out SafeAuditMemoryHandle ppAuditPolicy);

	/// <summary>
	/// The <c>AuditComputeEffectivePolicyBySid</c> function computes the effective audit policy for one or more subcategories for the
	/// specified security principal. The function computes effective audit policy by combining system audit policy with per-user policy.
	/// </summary>
	/// <param name="pSid">
	/// A pointer to the SID structure associated with the principal for which to compute effective audit policy. Per-user policy for
	/// group SIDs is not currently supported.
	/// </param>
	/// <param name="pSubCategoryGuids">
	/// A pointer to an array of <c>GUID</c> values that specify the subcategories for which to compute effective audit policy. For a
	/// list of defined subcategories, see Auditing Constants.
	/// </param>
	/// <returns>
	/// A list of AUDIT_POLICY_INFORMATION structures that specify the effective audit policy for the subcategories specified by the
	/// pSubCategoryGuids array.
	/// </returns>
	[PInvokeData("ntsecapi.h", MSDNShortId = "cac928e5-8d8f-4b2f-9c1b-c00dc891e3d1")]
	public static IEnumerable<AUDIT_POLICY_INFORMATION> AuditComputeEffectivePolicyBySid(PSID pSid, [In] Guid[] pSubCategoryGuids) =>
		AuditComputeEffectivePolicyBySid(pSid, pSubCategoryGuids, (uint)pSubCategoryGuids.Length, out var h) ? h.ToIEnum<AUDIT_POLICY_INFORMATION>(pSubCategoryGuids.Length) : throw Win32Error.GetLastError().GetException()!;

	/// <summary>
	/// The <c>AuditComputeEffectivePolicyByToken</c> function computes the effective audit policy for one or more subcategories for the
	/// security principal associated with the specified token. The function computes effective audit policy by combining system audit
	/// policy with per-user policy.
	/// </summary>
	/// <param name="hTokenHandle">
	/// A handle to the access token associated with the principal for which to compute effective audit policy. The token must have been
	/// opened with <c>TOKEN_QUERY</c> access. Per-user policy for group SIDs is not currently supported.
	/// </param>
	/// <param name="pSubCategoryGuids">
	/// A pointer to an array of <c>GUID</c> values that specify the subcategories for which to compute effective audit policy. For a
	/// list of defined subcategories, see Auditing Constants.
	/// </param>
	/// <param name="dwPolicyCount">The number of elements in each of the pSubCategoryGuids and ppAuditPolicy arrays.</param>
	/// <param name="ppAuditPolicy">
	/// <para>
	/// A pointer to a single buffer that contains both an array of pointers to AUDIT_POLICY_INFORMATION structures and the structures
	/// themselves. The <c>AUDIT_POLICY_INFORMATION</c> structures specify the effective audit policy for the subcategories specified by
	/// the pSubCategoryGuids array.
	/// </para>
	/// <para>When you have finished using this buffer, free it by calling the AuditFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND 2 (0x2)</term>
	/// <term>No per-user audit policy exists for the principal specified by the pSid parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have both <c>AUDIT_QUERY_SYSTEM_POLICY</c>
	/// and <c>AUDIT_QUERY_USER_POLICY</c> access on the Audit security object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditcomputeeffectivepolicybytoken BOOLEAN
	// AuditComputeEffectivePolicyByToken( HANDLE hTokenHandle, const GUID *pSubCategoryGuids, ULONG dwPolicyCount,
	// PAUDIT_POLICY_INFORMATION *ppAuditPolicy );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "e5fc9b8d-a61e-48c2-9093-f27167232cc8")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditComputeEffectivePolicyByToken(HTOKEN hTokenHandle, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[] pSubCategoryGuids, uint dwPolicyCount, out SafeAuditMemoryHandle ppAuditPolicy);

	/// <summary>
	/// The <c>AuditComputeEffectivePolicyByToken</c> function computes the effective audit policy for one or more subcategories for the
	/// security principal associated with the specified token. The function computes effective audit policy by combining system audit
	/// policy with per-user policy.
	/// </summary>
	/// <param name="hTokenHandle">
	/// A handle to the access token associated with the principal for which to compute effective audit policy. The token must have been
	/// opened with <c>TOKEN_QUERY</c> access. Per-user policy for group SIDs is not currently supported.
	/// </param>
	/// <param name="pSubCategoryGuids">
	/// A pointer to an array of <c>GUID</c> values that specify the subcategories for which to compute effective audit policy. For a
	/// list of defined subcategories, see Auditing Constants.
	/// </param>
	/// <returns>
	/// A list of <c>AUDIT_POLICY_INFORMATION</c> structures that specify the effective audit policy for the subcategories specified by
	/// the pSubCategoryGuids array.
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have both <c>AUDIT_QUERY_SYSTEM_POLICY</c>
	/// and <c>AUDIT_QUERY_USER_POLICY</c> access on the Audit security object.
	/// </remarks>
	[PInvokeData("ntsecapi.h", MSDNShortId = "e5fc9b8d-a61e-48c2-9093-f27167232cc8")]
	public static IEnumerable<AUDIT_POLICY_INFORMATION> AuditComputeEffectivePolicyByToken(HTOKEN hTokenHandle, [In] Guid[] pSubCategoryGuids) =>
		AuditComputeEffectivePolicyByToken(hTokenHandle, pSubCategoryGuids, (uint)pSubCategoryGuids.Length, out var h) ? h.ToIEnum<AUDIT_POLICY_INFORMATION>(pSubCategoryGuids.Length) : throw Win32Error.GetLastError().GetException()!;

	/// <summary>The <c>AuditEnumerateCategories</c> function enumerates the available audit-policy categories.</summary>
	/// <param name="ppAuditCategoriesArray">
	/// <para>
	/// A pointer to a single buffer that contains both an array of pointers to <c>GUID</c> structures and the structures themselves. The
	/// <c>GUID</c> structures specify the audit-policy categories available on the computer.
	/// </para>
	/// <para>When you have finished using this buffer, free it by calling the AuditFree function.</para>
	/// </param>
	/// <param name="pdwCountReturned">A pointer to the number of elements in the ppAuditCategoriesArray array.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditenumeratecategories BOOLEAN
	// AuditEnumerateCategories( GUID **ppAuditCategoriesArray, PULONG pdwCountReturned );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "bcfdb24b-182e-4845-95c0-a210915435ae")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditEnumerateCategories(out SafeAuditMemoryHandle ppAuditCategoriesArray, out uint pdwCountReturned);

	/// <summary>The <c>AuditEnumerateCategories</c> function enumerates the available audit-policy categories.</summary>
	/// <returns>The <c>GUID</c> structures that specify the audit-policy categories available on the computer.</returns>
	[PInvokeData("ntsecapi.h", MSDNShortId = "bcfdb24b-182e-4845-95c0-a210915435ae")]
	public static IEnumerable<Guid> AuditEnumerateCategories() => AuditEnumerateCategories(out var h, out var i) ? h.ToIEnum<Guid>((int)i) : throw Win32Error.GetLastError().GetException()!;

	/// <summary>The <c>AuditEnumeratePerUserPolicy</c> function enumerates users for whom per-user auditing policy is specified.</summary>
	/// <param name="ppAuditSidArray">
	/// <para>
	/// A pointer to a single buffer that contains both an array of pointers to POLICY_AUDIT_SID_ARRAY structures and the structures
	/// themselves. The <c>POLICY_AUDIT_SID_ARRAY</c> structures specify the users for whom per-user audit policy is specified.
	/// </para>
	/// <para>When you have finished using this buffer, free it by calling the AuditFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have <c>AUDIT_ENUMERATE_USERS</c> access
	/// on the Audit security object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditenumerateperuserpolicy BOOLEAN
	// AuditEnumeratePerUserPolicy( PPOLICY_AUDIT_SID_ARRAY *ppAuditSidArray );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "4b13f021-ba08-4eb8-9c7a-0512992ef272")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditEnumeratePerUserPolicy(out SafeAuditMemoryHandle ppAuditSidArray);

	/// <summary>The <c>AuditEnumeratePerUserPolicy</c> function enumerates users for whom per-user auditing policy is specified.</summary>
	/// <returns>The user SIDs for whom per-user audit policy is specified.</returns>
	[PInvokeData("ntsecapi.h", MSDNShortId = "4b13f021-ba08-4eb8-9c7a-0512992ef272")]
	public static IEnumerable<PSID> AuditEnumeratePerUserPolicy() => AuditEnumeratePerUserPolicy(out var h) ? h.ToStructure<POLICY_AUDIT_SID_ARRAY>().UserSidArray : throw Win32Error.GetLastError().GetException()!;

	/// <summary>The <c>AuditEnumerateSubCategories</c> function enumerates the available audit-policy subcategories.</summary>
	/// <param name="pAuditCategoryGuid">
	/// The <c>GUID</c> of an audit-policy category for which subcategories are enumerated. If the value of the bRetrieveAllSubCategories
	/// parameter is <c>TRUE</c>, this parameter is ignored.
	/// </param>
	/// <param name="bRetrieveAllSubCategories">
	/// <c>TRUE</c> to enumerate all audit-policy subcategories; <c>FALSE</c> to enumerate only the subcategories of the audit-policy
	/// category specified by the pAuditCategoryGuid parameter.
	/// </param>
	/// <param name="ppAuditSubCategoriesArray">
	/// <para>
	/// A pointer to a single buffer that contains both an array of pointers to <c>GUID</c> structures and the structures themselves. The
	/// <c>GUID</c> structures specify the audit-policy subcategories available on the computer.
	/// </para>
	/// <para>When you have finished using this buffer, free it by calling the AuditFree function.</para>
	/// </param>
	/// <param name="pdwCountReturned">
	/// A pointer to the number of audit-policy subcategories returned in the ppAuditSubCategoriesArray array.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditenumeratesubcategories BOOLEAN
	// AuditEnumerateSubCategories( const GUID *pAuditCategoryGuid, BOOLEAN bRetrieveAllSubCategories, GUID **ppAuditSubCategoriesArray,
	// PULONG pdwCountReturned );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "c5af83f4-9524-4a39-ad1d-39b21bb073bd")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditEnumerateSubCategories(in Guid pAuditCategoryGuid, [MarshalAs(UnmanagedType.U1)] bool bRetrieveAllSubCategories, out SafeAuditMemoryHandle ppAuditSubCategoriesArray, out uint pdwCountReturned);

	/// <summary>The <c>AuditEnumerateSubCategories</c> function enumerates the available audit-policy subcategories.</summary>
	/// <param name="pAuditCategoryGuid">
	/// The <c>GUID</c> of an audit-policy category for which subcategories are enumerated. If the value is <see langword="null"/>, then
	/// all subcategories are enumerated.
	/// </param>
	/// <returns>A list of <c>GUID</c> structures specify the audit-policy subcategories available on the computer.</returns>
	[PInvokeData("ntsecapi.h", MSDNShortId = "c5af83f4-9524-4a39-ad1d-39b21bb073bd")]
	public static IEnumerable<Guid> AuditEnumerateSubCategories(Guid? pAuditCategoryGuid = null)
	{
		var guid = pAuditCategoryGuid.HasValue ? pAuditCategoryGuid.Value : Guid.Empty;
		return AuditEnumerateSubCategories(guid, !pAuditCategoryGuid.HasValue, out var h, out var c) ? h.ToIEnum<Guid>((int)c) : throw Win32Error.GetLastError().GetException()!;
	}

	/// <summary>The <c>AuditFree</c> function frees the memory allocated by audit functions for the specified buffer.</summary>
	/// <param name="Buffer">A pointer to the buffer to free.</param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditfree void AuditFree( PVOID Buffer );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "697baf9b-91c4-4a88-a190-e9f6812e08af")]
	public static extern void AuditFree(IntPtr Buffer);

	/// <summary>
	/// The <c>AuditLookupCategoryGuidFromCategoryId</c> function retrieves a <c>GUID</c> structure that represents the specified
	/// audit-policy category.
	/// </summary>
	/// <param name="AuditCategoryId">An element of the POLICY_AUDIT_EVENT_TYPE enumeration that specifies an audit-policy category.</param>
	/// <param name="pAuditCategoryGuid">
	/// A pointer to a <c>GUID</c> structure that represents the audit-policy category specified by the AuditCategoryId
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditlookupcategoryguidfromcategoryid BOOLEAN
	// AuditLookupCategoryGuidFromCategoryId( POLICY_AUDIT_EVENT_TYPE AuditCategoryId, GUID *pAuditCategoryGuid );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "2f00fe52-2e94-473a-be13-252b50b58522")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditLookupCategoryGuidFromCategoryId(POLICY_AUDIT_EVENT_TYPE AuditCategoryId, out Guid pAuditCategoryGuid);

	/// <summary>
	/// The <c>AuditLookupCategoryIdFromCategoryGuid</c> function retrieves an element of the POLICY_AUDIT_EVENT_TYPE enumeration that
	/// represents the specified audit-policy category.
	/// </summary>
	/// <param name="pAuditCategoryGuid">A pointer to a <c>GUID</c> structure that specifies an audit-policy category.</param>
	/// <param name="pAuditCategoryId">
	/// A pointer to an element of the POLICY_AUDIT_EVENT_TYPE enumeration that represents the audit-policy category specified by the
	/// pAuditCategoryGuid parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditlookupcategoryidfromcategoryguid BOOLEAN
	// AuditLookupCategoryIdFromCategoryGuid( const GUID *pAuditCategoryGuid, PPOLICY_AUDIT_EVENT_TYPE pAuditCategoryId );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "c50e39f0-d45f-4deb-abe5-6261775b507c")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditLookupCategoryIdFromCategoryGuid(in Guid pAuditCategoryGuid, out POLICY_AUDIT_EVENT_TYPE pAuditCategoryId);

	/// <summary>The <c>AuditLookupCategoryName</c> function retrieves the display name of the specified audit-policy category.</summary>
	/// <param name="pAuditCategoryGuid">A pointer to a <c>GUID</c> structure that specifies an audit-policy category.</param>
	/// <param name="ppszCategoryName">
	/// <para>
	/// The address of a pointer to a null-terminated string that contains the display name of the audit-policy category specified by the
	/// pAuditCategoryGuid function.
	/// </para>
	/// <para>When you have finished using this string, free it by calling the AuditFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditlookupcategorynamea BOOLEAN
	// AuditLookupCategoryNameA( const GUID *pAuditCategoryGuid, PSTR *ppszCategoryName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "8b30d864-8eb5-42d8-bc9a-a9eae1de5187")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditLookupCategoryName(in Guid pAuditCategoryGuid, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AuditStringMarshaler))] out string ppszCategoryName);

	/// <summary>The <c>AuditLookupSubCategoryName</c> function retrieves the display name of the specified audit-policy subcategory.</summary>
	/// <param name="pAuditSubCategoryGuid">A pointer to a <c>GUID</c> structure that specifies an audit-policy subcategory.</param>
	/// <param name="ppszSubCategoryName">
	/// <para>
	/// The address of a pointer to a null-terminated string that contains the display name of the audit-policy subcategory specified by
	/// the pAuditSubCategoryGuid parameter.
	/// </para>
	/// <para>When you have finished using this string, free it by calling the AuditFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditlookupsubcategorynamea BOOLEAN
	// AuditLookupSubCategoryNameA( const GUID *pAuditSubCategoryGuid, PSTR *ppszSubCategoryName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "65ccd0f6-ee43-4b4d-98fd-b7a49f23ad9d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditLookupSubCategoryName(in Guid pAuditSubCategoryGuid, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AuditStringMarshaler))] out string ppszSubCategoryName);

	/// <summary>
	/// The <c>AuditQueryGlobalSacl</c> function retrieves a global system access control list (SACL) that delegates access to the audit
	/// messages. Updating the global SACL requires the <c>SeSecurityPrivilege</c> which protects the global SACL from being updated by
	/// any user without administrator privileges.
	/// </summary>
	/// <param name="ObjectTypeName">
	/// A pointer to a null-terminated string specifying the type of object being accessed. This parameter must be either "File" or
	/// "Key", depending on whether the object is a file or registry. This string appears in any audit message that the function generates.
	/// </param>
	/// <param name="Acl">
	/// A pointer to an ACL structure that contains the SACL information. This should be freed later by calling the LocalFree function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To successfully call this function, the caller must have <c>SeSecurityPrivilege</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditqueryglobalsacla BOOLEAN AuditQueryGlobalSaclA(
	// PCSTR ObjectTypeName, PACL *Acl );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "133BBC94-9C89-437A-9146-75A9898A6566")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditQueryGlobalSacl(string ObjectTypeName, out SafePACL Acl);

	/// <summary>
	/// The <c>AuditQueryPerUserPolicy</c> function retrieves per-user audit policy in one or more audit-policy subcategories for the
	/// specified principal.
	/// </summary>
	/// <param name="pSid">
	/// A pointer to the SID structure associated with the principal for which to query audit policy. Per-user policy for group SIDs is
	/// not currently supported.
	/// </param>
	/// <param name="pSubCategoryGuids">
	/// A pointer to an array of <c>GUID</c> values that specify the subcategories for which to query audit policy. For a list of defined
	/// audit-policy subcategories, see Auditing Constants.
	/// </param>
	/// <param name="dwPolicyCount">The number of elements in each of the pSubCategoryGuids and ppAuditPolicy arrays.</param>
	/// <param name="ppAuditPolicy">
	/// <para>
	/// A pointer to a single buffer that contains both an array of pointers to AUDIT_POLICY_INFORMATION structures and the structures
	/// themselves. The <c>AUDIT_POLICY_INFORMATION</c> structures specify the per-user audit policy for the subcategories specified by
	/// the pSubCategoryGuids array.
	/// </para>
	/// <para>When you have finished using this buffer, free it by calling the AuditFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND 2</term>
	/// <term>No per-user audit policy exists for the principal specified by the pSid parameter.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have <c>AUDIT_QUERY_USER_POLICY</c> access
	/// on the Audit security object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditqueryperuserpolicy BOOLEAN AuditQueryPerUserPolicy(
	// const PSID pSid, const GUID *pSubCategoryGuids, ULONG dwPolicyCount, PAUDIT_POLICY_INFORMATION *ppAuditPolicy );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "7d4790de-ebd6-4840-b532-7158b8d80db2")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditQueryPerUserPolicy(PSID pSid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[] pSubCategoryGuids, uint dwPolicyCount, out SafeAuditMemoryHandle ppAuditPolicy);

	/// <summary>
	/// The <c>AuditQueryPerUserPolicy</c> function retrieves per-user audit policy in one or more audit-policy subcategories for the
	/// specified principal.
	/// </summary>
	/// <param name="pSid">
	/// A pointer to the SID structure associated with the principal for which to query audit policy. Per-user policy for group SIDs is
	/// not currently supported.
	/// </param>
	/// <param name="pSubCategoryGuids">
	/// A pointer to an array of <c>GUID</c> values that specify the subcategories for which to query audit policy. For a list of defined
	/// audit-policy subcategories, see Auditing Constants.
	/// </param>
	/// <returns>
	/// A list of <c>AUDIT_POLICY_INFORMATION</c> structures that specify the per-user audit policy for the subcategories specified by
	/// the pSubCategoryGuids array.
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have <c>AUDIT_QUERY_USER_POLICY</c> access
	/// on the Audit security object.
	/// </remarks>
	[PInvokeData("ntsecapi.h", MSDNShortId = "7d4790de-ebd6-4840-b532-7158b8d80db2")]
	public static IEnumerable<AUDIT_POLICY_INFORMATION> AuditQueryPerUserPolicy(PSID pSid, [In] Guid[] pSubCategoryGuids)
	{
		var b = AuditQueryPerUserPolicy(pSid, pSubCategoryGuids, (uint)(pSubCategoryGuids?.Length ?? 0), out var h);
		if (b)
			return h.ToIEnum<AUDIT_POLICY_INFORMATION>(pSubCategoryGuids?.Length ?? 0);
		var err = Win32Error.GetLastError();
		return err == Win32Error.ERROR_FILE_NOT_FOUND ? new AUDIT_POLICY_INFORMATION[0] : throw err.GetException()!;
	}

	/// <summary>The <c>AuditQuerySecurity</c> function retrieves security descriptor that delegates access to audit policy.</summary>
	/// <param name="SecurityInformation">
	/// A SECURITY_INFORMATION value that specifies which parts of the security descriptor this function sets. Only
	/// <c>SACL_SECURITY_INFORMATION</c> and <c>DACL_SECURITY_INFORMATION</c> are supported. Any other values are ignored. If neither
	/// <c>SACL_SECURITY_INFORMATION</c> nor <c>DACL_SECURITY_INFORMATION</c> is specified, this function fails and returns <c>ERROR_INVALID_PARAMETER</c>.
	/// </param>
	/// <param name="ppSecurityDescriptor">
	/// The address of a pointer to a well-formed SECURITY_DESCRIPTOR structure that controls access to the Audit security object.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To successfully call this function, the caller must have <c>SeSecurityPrivilege</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/nf-ntsecapi-auditquerysecurity
	// BOOLEAN AuditQuerySecurity( SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR *ppSecurityDescriptor );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "496c9659-0c03-42c9-93c4-eb4d97e950e2")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditQuerySecurity(SECURITY_INFORMATION SecurityInformation, out SafePSECURITY_DESCRIPTOR ppSecurityDescriptor);

	/// <summary>The <c>AuditQuerySystemPolicy</c> function retrieves system audit policy for one or more audit-policy subcategories.</summary>
	/// <param name="pSubCategoryGuids">
	/// A pointer to an array of <c>GUID</c> values that specify the subcategories for which to query audit policy. For a list of defined
	/// audit-policy subcategories, see Auditing Constants.
	/// </param>
	/// <param name="dwPolicyCount">The number of elements in each of the pSubCategoryGuids and ppAuditPolicy arrays.</param>
	/// <param name="ppAuditPolicy">
	/// <para>
	/// A pointer to a single buffer that contains both an array of pointers to AUDIT_POLICY_INFORMATION structures and the structures
	/// themselves. The <c>AUDIT_POLICY_INFORMATION</c> structures specify the system audit policy for the subcategories specified by the
	/// pSubCategoryGuids array.
	/// </para>
	/// <para>When you have finished using this buffer, free it by calling the AuditFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND 2</term>
	/// <term>No per-user audit policy exists for the principal specified by the pSid parameter.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have <c>AUDIT_QUERY_SYSTEM_POLICY</c>
	/// access on the audit security object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditquerysystempolicy BOOLEAN AuditQuerySystemPolicy(
	// const GUID *pSubCategoryGuids, ULONG dwPolicyCount, PAUDIT_POLICY_INFORMATION *ppAuditPolicy );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "5c268033-65fd-4a74-90a1-4b9e1e18daf1")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditQuerySystemPolicy([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[] pSubCategoryGuids, uint dwPolicyCount, out SafeAuditMemoryHandle ppAuditPolicy);

	/// <summary>The <c>AuditQuerySystemPolicy</c> function retrieves system audit policy for one or more audit-policy subcategories.</summary>
	/// <param name="pSubCategoryGuids">
	/// A pointer to an array of <c>GUID</c> values that specify the subcategories for which to query audit policy. For a list of defined
	/// audit-policy subcategories, see Auditing Constants.
	/// </param>
	/// <returns>
	/// A list of <c>AUDIT_POLICY_INFORMATION</c> structures that specify the system audit policy for the subcategories specified by the
	/// pSubCategoryGuids array.
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have <c>AUDIT_QUERY_SYSTEM_POLICY</c>
	/// access on the audit security object.
	/// </remarks>
	[PInvokeData("ntsecapi.h", MSDNShortId = "5c268033-65fd-4a74-90a1-4b9e1e18daf1")]
	public static IEnumerable<AUDIT_POLICY_INFORMATION> AuditQuerySystemPolicy([In] Guid[] pSubCategoryGuids) =>
		AuditQuerySystemPolicy(pSubCategoryGuids, (uint)(pSubCategoryGuids?.Length ?? 0), out var h) ? h.ToIEnum<AUDIT_POLICY_INFORMATION>(pSubCategoryGuids?.Length ?? 0) : throw Win32Error.GetLastError().GetException()!;

	/// <summary>
	/// The <c>AuditSetGlobalSacl</c> function sets a global system access control list (SACL) that delegates access to the audit
	/// messages. Updating the global SACL requires the <c>SeSecurityPrivilege</c> which protects the global SACL from being updated by
	/// any user without administrator privileges.
	/// </summary>
	/// <param name="ObjectTypeName">
	/// A pointer to a null-terminated string specifying the type of object being created or accessed. For setting the global SACL on
	/// files, this should be set to "File" and for setting the global SACL on registry, this should be set to "Key". This string appears
	/// in any audit message that the function generates.
	/// </param>
	/// <param name="Acl">A pointer to an ACL structure.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To successfully call this function, the caller must have <c>SeSecurityPrivilege</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditsetglobalsacla BOOLEAN AuditSetGlobalSaclA( PCSTR
	// ObjectTypeName, PACL Acl );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "48A41E3F-DDB0-431F-BCF0-E2452FEA57FA")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditSetGlobalSacl(string ObjectTypeName, PACL Acl);

	/// <summary>
	/// The <c>AuditSetPerUserPolicy</c> function sets per-user audit policy in one or more audit subcategories for the specified principal.
	/// </summary>
	/// <param name="pSid">
	/// A pointer to the SID structure associated with the principal for which to set audit policy. Per-user policy for group SIDs is not
	/// currently supported.
	/// </param>
	/// <param name="pAuditPolicy">
	/// <para>
	/// A pointer to an array of AUDIT_POLICY_INFORMATION structures. Each structure specifies per-user audit policy for one audit subcategory.
	/// </para>
	/// <para>The <c>AuditCategoryGuid</c> member of these structures is ignored.</para>
	/// </param>
	/// <param name="dwPolicyCount">The number of elements in the pAuditPolicy array.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_USER 1317</term>
	/// <term>The SID structure specified by the pSID parameter is not associated with an existing user.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have <c>AUDIT_SET_USER_POLICY</c> access
	/// on the Audit security object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditsetperuserpolicy BOOLEAN AuditSetPerUserPolicy(
	// const PSID pSid, PCAUDIT_POLICY_INFORMATION pAuditPolicy, ULONG dwPolicyCount );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "a6cef640-5658-4c13-96fb-a664d2a61b57")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditSetPerUserPolicy(PSID pSid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] AUDIT_POLICY_INFORMATION[] pAuditPolicy, uint dwPolicyCount);

	/// <summary>The <c>AuditSetSecurity</c> function sets a security descriptor that delegates access to audit policy.</summary>
	/// <param name="SecurityInformation">
	/// A SECURITY_INFORMATION value that specifies which parts of the security descriptor this function sets. Only
	/// <c>SACL_SECURITY_INFORMATION</c> and <c>DACL_SECURITY_INFORMATION</c> are supported. Any other values are ignored. If neither
	/// <c>SACL_SECURITY_INFORMATION</c> nor <c>DACL_SECURITY_INFORMATION</c> is specified, this function fails and returns <c>ERROR_INVALID_PARAMETER</c>.
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// A pointer to a well-formed SECURITY_DESCRIPTOR structure that controls access to the Audit security object. If this parameter is
	/// <c>NULL</c>, the function fails and returns <c>ERROR_INVALID_PARAMETER</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To successfully call this function, the caller must have <c>SeSecurityPrivilege</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditsetsecurity BOOLEAN AuditSetSecurity(
	// SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "2f4d6198-775a-40e4-9158-a69e71bfe050")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditSetSecurity(SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor);

	/// <summary>The <c>AuditSetSystemPolicy</c> function sets system audit policy for one or more audit-policy subcategories.</summary>
	/// <param name="pAuditPolicy">
	/// <para>
	/// A pointer to an array of AUDIT_POLICY_INFORMATION structures. Each structure specifies system audit policy for one audit-policy subcategory.
	/// </para>
	/// <para>The <c>AuditCategoryGuid</c> member of these structures is ignored.</para>
	/// </param>
	/// <param name="dwPolicyCount">The number of elements in the pAuditPolicy array.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes defined in WinError.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>The caller does not have the privilege or access rights necessary to call this function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To successfully call this function, the caller must have <c>SeSecurityPrivilege</c> or have <c>AUDIT_SET_SYSTEM_POLICY</c> access
	/// on the Audit security object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-auditsetsystempolicy BOOLEAN AuditSetSystemPolicy(
	// PCAUDIT_POLICY_INFORMATION pAuditPolicy, ULONG dwPolicyCount );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ntsecapi.h", MSDNShortId = "9692ebe3-a676-45bb-a58d-b3fdbb1bbc2a")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool AuditSetSystemPolicy([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] AUDIT_POLICY_INFORMATION[] pAuditPolicy, uint dwPolicyCount);

	/// <summary>The <c>AUDIT_POLICY_INFORMATION</c> structure specifies a security event type and when to audit that type.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/ns-ntsecapi-_audit_policy_information typedef struct
	// _AUDIT_POLICY_INFORMATION { GUID AuditSubCategoryGuid; ULONG AuditingInformation; GUID AuditCategoryGuid; }
	// AUDIT_POLICY_INFORMATION, *PAUDIT_POLICY_INFORMATION;
	[PInvokeData("ntsecapi.h", MSDNShortId = "3fafeec9-a028-4a65-933e-fb973eb257b0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIT_POLICY_INFORMATION
	{
		/// <summary>A <c>GUID</c> structure that specifies an audit subcategory.</summary>
		public Guid AuditSubCategoryGuid;

		/// <summary>
		/// <para>
		/// A set of bit flags that specify the conditions under which the security event type specified by the
		/// <c>AuditSubCategoryGuid</c> and <c>AuditCategoryGuid</c> members are audited. The following values are defined.
		/// </para>
		/// <para><c>Important</c> Note that the meaning of these values differs depending on which function is using this structure.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>POLICY_AUDIT_EVENT_UNCHANGED 0x00000000</term>
		/// <term>
		/// Do not change auditing options for the specified event type. This value is valid for the AuditSetSystemPolicy and
		/// AuditQuerySystemPolicy functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>POLICY_AUDIT_EVENT_SUCCESS 0x00000001</term>
		/// <term>
		/// Audit successful occurrences of the specified event type. This value is valid for the AuditSetSystemPolicy and
		/// AuditQuerySystemPolicy functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>POLICY_AUDIT_EVENT_FAILURE 0x00000002</term>
		/// <term>
		/// Audit failed attempts to cause the specified event type. This value is valid for the AuditSetSystemPolicy and
		/// AuditQuerySystemPolicy functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>POLICY_AUDIT_EVENT_NONE 0x00000004</term>
		/// <term>
		/// Do not audit the specified event type. This value is valid for the AuditSetSystemPolicy and AuditQuerySystemPolicy functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PER_USER_POLICY_UNCHANGED 0x00</term>
		/// <term>
		/// Do not change auditing options for the specified event type. This value is valid for the AuditSetPerUserPolicy and
		/// AuditQueryPerUserPolicy functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PER_USER_AUDIT_SUCCESS_INCLUDE 0x01</term>
		/// <term>
		/// Audit successful occurrences of the specified event type. This value is valid for the AuditSetPerUserPolicy and
		/// AuditQueryPerUserPolicy functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PER_USER_AUDIT_SUCCESS_EXCLUDE 0x02</term>
		/// <term>
		/// Do not audit successful occurrences of the specified event type. This value is valid for the AuditSetPerUserPolicy and
		/// AuditQueryPerUserPolicy functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PER_USER_AUDIT_FAILURE_INCLUDE 0x04</term>
		/// <term>
		/// Audit failed attempts to cause the specified event type. This value is valid for the AuditSetPerUserPolicy and
		/// AuditQueryPerUserPolicy functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PER_USER_AUDIT_FAILURE_EXCLUDE 0x08</term>
		/// <term>
		/// Do not audit failed attempts to cause the specified event type. This value is valid for the AuditSetPerUserPolicy and
		/// AuditQueryPerUserPolicy functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PER_USER_AUDIT_NONE 0x10</term>
		/// <term>
		/// Do not audit the specified event type. This value is valid for the AuditSetPerUserPolicy and AuditQueryPerUserPolicy functions.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public AuditCondition AuditingInformation;

		/// <summary>A <c>GUID</c> structure that specifies an audit-policy category.</summary>
		public Guid AuditCategoryGuid;
	}

	/// <summary>The POLICY_AUDIT_SID_ARRAY structure specifies an array of SID structures that represent Windows users or groups.</summary>
	[PInvokeData("ntsecapi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct POLICY_AUDIT_SID_ARRAY
	{
		/// <summary>The number of SID structures in the UserSidArray array.</summary>
		public uint UsersCount;

		/// <summary>An array of SID pointers.</summary>
		private readonly IntPtr _UserSidArray;

		/// <summary>An array of SID pointers.</summary>
		public PSID[] UserSidArray => _UserSidArray == IntPtr.Zero ? new PSID[0] : _UserSidArray.ToArray<PSID>((int)UsersCount)!;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for memory allocated by audit functions that is disposed using <see cref="AuditFree"/>.</summary>
	[AutoSafeHandle("{ AuditFree(handle); return true; }")]
	public partial class SafeAuditMemoryHandle
	{
		/// <summary>
		/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note type="note">This
		/// call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
		/// </summary>
		/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
		/// <param name="count">The number of structures to retrieve.</param>
		/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
		/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
		public IEnumerable<T> ToIEnum<T>(int count, int prefixBytes = 0) where T : struct
		{
			if (IsInvalid) return Enumerable.Empty<T>();
			if (!typeof(T).IsBlittable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");
			return this.ToIEnum<T>(count, prefixBytes);
		}

		/// <summary>
		/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
		/// </summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
		/// <returns>A managed object that contains the data that this <see cref="SafeMemoryHandleExt{T}"/> holds.</returns>
		public T ToStructure<T>() where T : struct
		{
			if (IsInvalid) return default;
			return handle.ToStructure<T>();
		}
	}

	/// <summary>A custom marshaler for functions using memeroy allocated by audit functions so that managed strings can be used.</summary>
	/// <seealso cref="ICustomMarshaler"/>
	internal class AuditStringMarshaler : ICustomMarshaler
	{
		public static ICustomMarshaler GetInstance(string _) => new AuditStringMarshaler();

		public void CleanUpManagedData(object ManagedObj)
		{
		}

		public void CleanUpNativeData(IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero) return;
			AuditFree(pNativeData);
		}

		public int GetNativeDataSize() => -1;

		public IntPtr MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

		public object MarshalNativeToManaged(IntPtr pNativeData) => (string?)StringHelper.GetString(pNativeData)?.Clone() ?? string.Empty;
	}
}