using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// <para>
		/// The <c>AddResourceAttributeAce</c> function adds a SYSTEM_RESOURCE_ATTRIBUTE_ACE access control entry (ACE) to the end of a
		/// system access control list (SACL). A <c>SYSTEM_RESOURCE_ATTRIBUTE_ACE</c> structure specifies an attribute name and a
		/// value-ordered list of elements that is associated with a resource and potentially used during access checks. The set of standard
		/// access rights are defined in the Standard Access Rights topic.
		/// </para>
		/// </summary>
		/// <param name="pAcl">
		/// <para>
		/// A pointer to an access control list (ACL). This function adds an ACE to this ACL. The value of this parameter cannot be
		/// <c>NULL</c>. The ACE is in the form of a SYSTEM_RESOURCE_ATTRIBUTE_ACE structure.
		/// </para>
		/// </param>
		/// <param name="dwAceRevision">
		/// <para>
		/// Specifies the revision level of the ACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if
		/// the ACL contains object-specific ACEs.
		/// </para>
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE.
		/// </para>
		/// <para>
		/// For consistency with the Windows 8 Advanced File Permissions UI, applications should specify the CONTAINER_INHERIT_ACE and
		/// OBJECT_INHERIT_ACE flags in the parameter.
		/// </para>
		/// <para>This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE 2 (0x2)</term>
		/// <term>The ACE is inherited by the container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE 8 (0x8)</term>
		/// <term>The ACE does not apply to the object the ACE is assigned to, but it can be inherited by child objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE 16 (0x10)</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE 4 (0x4)</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE 1 (0x1)</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// <para>Must be zero for Windows 8 and Windows Server 2012.</para>
		/// </param>
		/// <param name="pSid">
		/// <para>Must be the Everyone SID (S-1-1-0) for Windows 8 and Windows Server 2012.</para>
		/// </param>
		/// <param name="pAttributeInfo">
		/// <para>Specifies the attribute information that will be appended after the SID in the ACE.</para>
		/// </param>
		/// <param name="pReturnLength">
		/// <para>
		/// The size, in bytes, of the actual ACL buffer used. If the buffer specified by the parameter is not big enough, the value of this
		/// parameter is the total size required for the ACL buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addresourceattributeace BOOL
		// AddResourceAttributeAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, PSID pSid,
		// PCLAIM_SECURITY_ATTRIBUTES_INFORMATION pAttributeInfo, PDWORD pReturnLength );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "AA2064E4-6F76-4D7B-8540-D55A91168825")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddResourceAttributeAce(PACL pAcl, uint dwAceRevision, uint AceFlags, uint AccessMask, PSID pSid, in CLAIM_SECURITY_ATTRIBUTES_INFORMATION pAttributeInfo, ref uint pReturnLength);

		/// <summary>
		/// <para>
		/// The <c>AddScopedPolicyIDAce</c> function adds a SYSTEM_SCOPED_POLICY_ID_ACE access control entry (ACE) to the end of a system
		/// access control list (SACL). A <c>SYSTEM_SCOPED_POLICY_ID_ACE</c> structure specifies a central access policy (CAP) to be
		/// associated with the resource and can be used during access checks. The set of standard access rights are defined in the Standard
		/// Access Rights topic.
		/// </para>
		/// </summary>
		/// <param name="pAcl">
		/// <para>
		/// A pointer to an access control list (ACL). This function adds an ACE to this ACL. The value of this parameter cannot be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwAceRevision">
		/// <para>
		/// Specifies the revision level of the ACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if
		/// the ACL contains object-specific ACEs.
		/// </para>
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE.
		/// </para>
		/// <para>
		/// For consistency with the Windows 8 Advanced File Permissions UI, applications should specify the CONTAINER_INHERIT_ACE and
		/// OBJECT_INHERIT_ACE flags in the parameter.
		/// </para>
		/// <para>This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE 2 (0x2)</term>
		/// <term>The ACE is inherited by the container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE 8 (0x8)</term>
		/// <term>The ACE does not apply to the object the ACE is assigned to, but it can be inherited by child objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE 16 (0x10)</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE 4 (0x4)</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE 1 (0x1)</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// <para>Must be zero for Windows 8 and Windows Server 2012.</para>
		/// </param>
		/// <param name="pSid">
		/// <para>A pointer to the SID (S-1-17-*) that identifies the Central Access Policy to be associated with the resource.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addscopedpolicyidace BOOL
		// AddScopedPolicyIDAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, PSID pSid );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "30AA5730-566C-4B02-A904-5A38237EE8E3")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddScopedPolicyIDAce(PACL pAcl, uint dwAceRevision, uint AceFlags, uint AccessMask, PSID pSid);

		/// <summary>
		/// <para>The <c>CheckTokenCapability</c> function checks the capabilities of a given token.</para>
		/// </summary>
		/// <param name="TokenHandle">
		/// <para>
		/// A handle to an access token. The handle must have TOKEN_QUERY access to the token. The token must be an impersonation token.
		/// </para>
		/// <para>
		/// If is <c>NULL</c>, <c>CheckTokenCapability</c> uses the impersonation token of the calling thread. If the thread is not
		/// impersonating, the function duplicates the thread's primary token to create an impersonation token.
		/// </para>
		/// </param>
		/// <param name="CapabilitySidToCheck">
		/// <para>
		/// A pointer to a capability SID structure. The <c>CheckTokenCapability</c> function checks the capabilities of this access token.
		/// </para>
		/// </param>
		/// <param name="HasCapability">
		/// <para>
		/// Receives the results of the check. If the access token has the capability, it returns <c>TRUE</c>, otherwise, it returns <c>FALSE</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-checktokencapability BOOL
		// CheckTokenCapability( HANDLE TokenHandle, PSID CapabilitySidToCheck, PBOOL HasCapability );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "436A5110-B79E-4E64-92E8-1C9E713D0948")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckTokenCapability(HTOKEN TokenHandle, PSID CapabilitySidToCheck, [MarshalAs(UnmanagedType.Bool)] out bool HasCapability);

		/// <summary>
		/// <para>
		/// This function constructs two arrays of SIDs out of a capability name. One is an array group SID with NT Authority, and the other
		/// is an array of capability SIDs with AppAuthority.
		/// </para>
		/// </summary>
		/// <param name="CapName">
		/// <para>Name of the capability in string form.</para>
		/// </param>
		/// <param name="CapabilityGroupSids">
		/// <para>The GroupSids with NTAuthority.</para>
		/// </param>
		/// <param name="CapabilityGroupSidCount">
		/// <para>The count of GroupSids in the array.</para>
		/// </param>
		/// <param name="CapabilitySids">
		/// <para>CapabilitySids with AppAuthority.</para>
		/// </param>
		/// <param name="CapabilitySidCount">
		/// <para>The count of CapabilitySid with AppAuthority.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller is expected to free the individual SIDs returned in each array by calling LocalFree. as well as memory allocated for
		/// the array itself.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-derivecapabilitysidsfromname BOOL
		// DeriveCapabilitySidsFromName( LPCWSTR CapName, PSID **CapabilityGroupSids, DWORD *CapabilityGroupSidCount, PSID **CapabilitySids,
		// DWORD *CapabilitySidCount );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "1A911FCC-6D11-4185-B532-20FE6C7C4B0B")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeriveCapabilitySidsFromName([MarshalAs(UnmanagedType.LPWStr)] string CapName, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] CapabilityGroupSids, ref uint CapabilityGroupSidCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] IntPtr[] CapabilitySids, ref uint CapabilitySidCount);
	}
}