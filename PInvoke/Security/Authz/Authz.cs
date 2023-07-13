using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

/// <summary>Platform invokable enumerated types, constants and functions from authz.h</summary>
public static partial class Authz
{
	/// <summary>
	/// The AuthzAccessCheckCallback function is an application-defined function that handles callback access control entries (ACEs)
	/// during an access check. AuthzAccessCheckCallback is a placeholder for the application-defined function name. The application
	/// registers this callback by calling AuthzInitializeResourceManager.
	/// </summary>
	/// <param name="hAuthzClientContext">A handle to a client context.</param>
	/// <param name="pAce">A pointer to the ACE to evaluate for inclusion in the call to the AuthzAccessCheck function.</param>
	/// <param name="pArgs">Data passed in the DynamicGroupArgs parameter of the call to AuthzAccessCheck or AuthzCachedAccessCheck.</param>
	/// <param name="pbAceApplicable">
	/// A pointer to a Boolean variable that receives the results of the evaluation of the logic defined by the application.
	/// <para>
	/// The results are TRUE if the logic determines that the ACE is applicable and will be included in the call to AuthzAccessCheck;
	/// otherwise, the results are FALSE.
	/// </para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the function returns TRUE.
	/// <para>
	/// If the function is unable to perform the evaluation, it returns FALSE. Use SetLastError to return an error to the access check function.
	/// </para>
	/// </returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool AuthzAccessCheckCallback(AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, PACE pAce, IntPtr pArgs, [MarshalAs(UnmanagedType.Bool)] ref bool pbAceApplicable);

	/// <summary>
	/// The <c>AuthzComputeGroupsCallback</c> function is an application-defined function that creates a list of security identifiers
	/// (SIDs) that apply to a client. <c>AuthzComputeGroupsCallback</c> is a placeholder for the application-defined function name.
	/// </summary>
	/// <param name="hAuthzClientContext">A handle to a client context.</param>
	/// <param name="pArgs">
	/// Data passed in the DynamicGroupArgs parameter of a call to the AuthzInitializeContextFromAuthzContext,
	/// AuthzInitializeContextFromSid, or AuthzInitializeContextFromToken function.
	/// </param>
	/// <param name="pSidAttrArray">
	/// A pointer to a pointer variable that receives the address of an array of SID_AND_ATTRIBUTES structures. These structures
	/// represent the groups to which the client belongs.
	/// </param>
	/// <param name="pSidCount">The number of structures in pSidAttrArray.</param>
	/// <param name="pRestrictedSidAttrArray">
	/// A pointer to a pointer variable that receives the address of an array of SID_AND_ATTRIBUTES structures. These structures
	/// represent the groups from which the client is restricted.
	/// </param>
	/// <param name="pRestrictedSidCount">The number of structures in pSidRestrictedAttrArray.</param>
	/// <returns>
	/// <para>If the function successfully returns a list of SIDs, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>Applications can also add SIDs to the client context by calling <c>AuthzAddSidsToContext</c>.</para>
	/// <para>
	/// Attribute variables must be in the form of an expression when used with logical operators; otherwise, they are evaluated as unknown.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/SecAuthZ/authzcomputegroupscallback BOOL CALLBACK AuthzComputeGroupsCallback(
	// _In_ AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, _In_ PVOID Args, _Out_ PSID_AND_ATTRIBUTES *pSidAttrArray, _Out_ PDWORD
	// pSidCount, _Out_ PSID_AND_ATTRIBUTES *pRestrictedSidAttrArray, _Out_ PDWORD pRestrictedSidCount );
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("authz.h", MSDNShortId = "c20a02a0-5303-4433-a484-5a89999b32b9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool AuthzComputeGroupsCallback(AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, IntPtr pArgs, out IntPtr pSidAttrArray, out uint pSidCount, out IntPtr pRestrictedSidAttrArray, out uint pRestrictedSidCount);

	/// <summary>
	/// The AuthzFreeCentralAccessPolicyCallback function is an application-defined function that frees memory allocated by the
	/// AuthzGetCentralAccessPolicyCallback function. AuthzFreeCentralAccessPolicyCallback is a placeholder for the application-defined
	/// function name.
	/// </summary>
	/// <param name="pCentralAccessPolicy">Pointer to the central access policy to be freed.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function is unable to perform the evaluation, it returns <c>FALSE</c>. Use <c>SetLastError</c> to return an error to the
	/// access check function.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/SecAuthZ/authzfreecentralaccesspolicycallback BOOL CALLBACK
	// AuthzFreeCentralAccessPolicyCallback( _In_ PVOID pCentralAccessPolicy );
	[PInvokeData("authz.h", MSDNShortId = "F0859A67-4D20-4189-8F35-A78034E41E6A")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool AuthzFreeCentralAccessPolicyCallback(IntPtr pCentralAccessPolicy);

	/// <summary>
	/// The AuthzFreeGroupsCallback function is an application-defined function that frees memory allocated by the
	/// AuthzComputeGroupsCallback function. AuthzFreeGroupsCallback is a placeholder for the application-defined function name.
	/// </summary>
	/// <param name="pSidAttrArray">A pointer to memory allocated by AuthzComputeGroupsCallback.</param>
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
	[SuppressUnmanagedCodeSecurity]
	public delegate void AuthzFreeGroupsCallback(IntPtr pSidAttrArray);

	/// <summary>
	/// The AuthzGetCentralAccessPolicyCallback function is an application-defined function that retrieves the central access policy.
	/// AuthzGetCentralAccessPolicyCallback is a placeholder for the application-defined function name.
	/// </summary>
	/// <param name="hAuthzClientContext">Handle to the client context.</param>
	/// <param name="capid">ID of the central access policy to retrieve.</param>
	/// <param name="pArgs">
	/// Optional arguments that were passed to the AuthzAccessCheck function through the OptionalArguments member of the
	/// AUTHZ_ACCESS_REQUEST structure.
	/// </param>
	/// <param name="pCentralAccessPolicyApplicable">
	/// Pointer to a Boolean value that the resource manager uses to indicate whether a central access policy should be used during
	/// access evaluation.
	/// </param>
	/// <param name="ppCentralAccessPolicy">
	/// Pointer to the central access policy (CAP) to be used for evaluating access. If this value is NULL, the default CAP is applied.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function is unable to perform the evaluation, it returns <c>FALSE</c>. Use <c>SetLastError</c> to return an error to the
	/// access check function.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/SecAuthZ/authzgetcentralaccesspolicycallback- BOOL CALLBACK
	// AuthzGetCentralAccessPolicyCallback ( _In_ AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, _In_ PSID capid, _In_opt_ PVOID pArgs,
	// _Out_ PBOOL pCentralAccessPolicyApplicable, _Out_ PVOID ppCentralAccessPolicy );
	[PInvokeData("authz.h", MSDNShortId = "1D5831EF-ACA8-4EE9-A7C1-E1A3CB74CEC0")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool AuthzGetCentralAccessPolicyCallback([In] AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, [In] PSID capid, [In, Optional] IntPtr pArgs, [MarshalAs(UnmanagedType.Bool)] out bool pCentralAccessPolicyApplicable, out IntPtr ppCentralAccessPolicy);

	/// <summary>Flags that specify the type of audit generated.</summary>
	[PInvokeData("authz.h", MSDNShortId = "95d561ef-3233-433a-a1e7-b914df1dd211")]
	[Flags]
	public enum APF
	{
		/// <summary>Failure audits are generated.</summary>
		APF_AuditFailure = 0x00000000,

		/// <summary>Success audits are generated.</summary>
		APF_AuditSuccess = 0x00000001,
	}

	/// <summary>
	/// <para>
	/// The <c>AUTHZ_CONTEXT_INFORMATION_CLASS</c> enumeration specifies the type of information to be retrieved from an existing
	/// AuthzClientContext. This enumeration is used by the AuthzGetInformationFromContext function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ne-authz-_authz_context_information_class typedef enum
	// _AUTHZ_CONTEXT_INFORMATION_CLASS { AuthzContextInfoUserSid , AuthzContextInfoGroupsSids , AuthzContextInfoRestrictedSids ,
	// AuthzContextInfoPrivileges , AuthzContextInfoExpirationTime , AuthzContextInfoServerContext , AuthzContextInfoIdentifier ,
	// AuthzContextInfoSource , AuthzContextInfoAll , AuthzContextInfoAuthenticationId , AuthzContextInfoSecurityAttributes ,
	// AuthzContextInfoDeviceSids , AuthzContextInfoUserClaims , AuthzContextInfoDeviceClaims , AuthzContextInfoAppContainerSid ,
	// AuthzContextInfoCapabilitySids } AUTHZ_CONTEXT_INFORMATION_CLASS;
	[PInvokeData("authz.h", MSDNShortId = "5eb752dc-17f7-4510-8aef-d18280322e76")]
	public enum AUTHZ_CONTEXT_INFORMATION_CLASS
	{
		/// <summary>Retrieves a TOKEN_USER structure that contains a user security identifier (SID) and its attribute.</summary>
		[CorrespondingType(typeof(TOKEN_USER))]
		AuthzContextInfoUserSid = 1,

		/// <summary>Retrieves a TOKEN_GROUPS structure that contains the group SIDs to which the user belongs and their attributes.</summary>
		[CorrespondingType(typeof(TOKEN_GROUPS))]
		AuthzContextInfoGroupsSids,

		/// <summary>Retrieves a TOKEN_GROUPS structure that contains the restricted group SIDs in the context and their attributes.</summary>
		[CorrespondingType(typeof(TOKEN_GROUPS))]
		AuthzContextInfoRestrictedSids,

		/// <summary>Retrieves a TOKEN_PRIVILEGES structure that contains the privileges held by the user.</summary>
		[CorrespondingType(typeof(TOKEN_PRIVILEGES))]
		AuthzContextInfoPrivileges,

		/// <summary>Retrieves the expiration time set on the context.</summary>
		[CorrespondingType(typeof(long))]
		AuthzContextInfoExpirationTime,

		/// <summary>This constant is reserved. Do not use it.</summary>
		AuthzContextInfoServerContext,

		/// <summary>Retrieves an LUID structures used by the resource manager to identify the context.</summary>
		[CorrespondingType(typeof(LUID))]
		AuthzContextInfoIdentifier,

		/// <summary>This constant is reserved. Do not use it.</summary>
		AuthzContextInfoSource,

		/// <summary>This constant is reserved. Do not use it.</summary>
		AuthzContextInfoAll,

		/// <summary>This constant is reserved. Do not use it.</summary>
		AuthzContextInfoAuthenticationId,

		/// <summary>
		/// Retrieves an AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structure that contains security attributes.
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </summary>
		[CorrespondingType(typeof(AUTHZ_SECURITY_ATTRIBUTES_INFORMATION))]
		AuthzContextInfoSecurityAttributes,

		/// <summary>
		/// Retrieves a TOKEN_GROUPS structure that contains device SIDs and their attributes.
		/// <para>
		/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
		/// is not supported.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(TOKEN_GROUPS))]
		AuthzContextInfoDeviceSids,

		/// <summary>
		/// Retrieves a AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structure that contains user claims.
		/// <para>
		/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
		/// is not supported.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(AUTHZ_SECURITY_ATTRIBUTES_INFORMATION))]
		AuthzContextInfoUserClaims,

		/// <summary>
		/// Retrieves a AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structure that contains device claims.
		/// <para>
		/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
		/// is not supported.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(AUTHZ_SECURITY_ATTRIBUTES_INFORMATION))]
		AuthzContextInfoDeviceClaims,

		/// <summary>
		/// Retrieves a TOKEN_APPCONTAINER_INFORMATION structure that contains the app container SID.
		/// <para>
		/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
		/// is not supported.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(TOKEN_APPCONTAINER_INFORMATION))]
		AuthzContextInfoAppContainerSid,

		/// <summary>
		/// Retrieves a TOKEN_GROUPS structure that contains capability SIDs.
		/// <para>
		/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
		/// is not supported.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(TOKEN_GROUPS))]
		AuthzContextInfoCapabilitySids,
	}

	/// <summary>Used by the <see cref="AUTHZ_SECURITY_ATTRIBUTE_V1"/> structure.</summary>
	[PInvokeData("authz.h")]
	public enum AUTHZ_SECURITY_ATTRIBUTE_DATATYPE : ushort
	{
		/// <summary>Invalid value.</summary>
		AUTHZ_SECURITY_ATTRIBUTE_TYPE_INVALID = 0x00,

		/// <summary>The Values member refers to a security attribute that is of INT64 type.</summary>
		AUTHZ_SECURITY_ATTRIBUTE_TYPE_INT64 = 0x01,

		/// <summary>The Values member refers to a security attribute that is of UINT64 type.</summary>
		AUTHZ_SECURITY_ATTRIBUTE_TYPE_UINT64 = 0x02,

		/// <summary>The Values member refers to a security attribute that is of STRING type.</summary>
		AUTHZ_SECURITY_ATTRIBUTE_TYPE_STRING = 0x03,

		/// <summary>The Values member refers to a security attribute that is of AUTHZ_SECURITY_ATTRIBUTE_TYPE_FQBN type.</summary>
		AUTHZ_SECURITY_ATTRIBUTE_TYPE_FQBN = 0x04,

		/// <summary>
		/// The Values member refers to a security attribute that is of AUTHZ_SECURITY_ATTRIBUTE_TYPE_SID type.
		/// <para><c>Windows Server 2008 R2 and Windows 7:</c> This value type is not available.</para>
		/// </summary>
		AUTHZ_SECURITY_ATTRIBUTE_TYPE_SID = 0x05,

		/// <summary>
		/// The Values member refers to a security attribute that is of AUTHZ_SECURITY_ATTRIBUTE_TYPE_BOOLEAN type.
		/// <para><c>Windows Server 2008 R2 and Windows 7:</c> This value type is not available.</para>
		/// </summary>
		AUTHZ_SECURITY_ATTRIBUTE_TYPE_BOOLEAN = 0x06,

		/// <summary>The Values member refers to a security attribute that is of AUTHZ_SECURITY_ATTRIBUTE_TYPE_OCTET_STRING type.</summary>
		AUTHZ_SECURITY_ATTRIBUTE_TYPE_OCTET_STRING = 0x10
	}

	/// <summary>Used by the <see cref="AUTHZ_SECURITY_ATTRIBUTE_V1"/> structure.</summary>
	[PInvokeData("authz.h")]
	public enum AUTHZ_SECURITY_ATTRIBUTE_FLAGS
	{
		/// <summary>No flags specified.</summary>
		NONE = 0,

		/// <summary>This security attribute is not inherited across processes.</summary>
		AUTHZ_SECURITY_ATTRIBUTE_NON_INHERITABLE = 1,

		/// <summary>The value of the attribute is case sensitive. This flag is valid for values that contain string types.</summary>
		AUTHZ_SECURITY_ATTRIBUTE_VALUE_CASE_SENSITIVE = 2
	}

	/// <summary>
	/// The AUTHZ_SECURITY_ATTRIBUTE_OPERATION enumeration indicates the type of modification to be made to security attributes by a call
	/// to the AuthzModifySecurityAttributes function.
	/// </summary>
	/// <summary>
	/// <para>
	/// The <c>AUTHZ_SECURITY_ATTRIBUTE_OPERATION</c> enumeration indicates the type of modification to be made to security attributes by
	/// a call to the AuthzModifySecurityAttributes function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ne-authz-authz_security_attribute_operation typedef enum
	// AUTHZ_SECURITY_ATTRIBUTE_OPERATION { AUTHZ_SECURITY_ATTRIBUTE_OPERATION_NONE , AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE_ALL ,
	// AUTHZ_SECURITY_ATTRIBUTE_OPERATION_ADD , AUTHZ_SECURITY_ATTRIBUTE_OPERATION_DELETE , AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE } *PAUTHZ_SECURITY_ATTRIBUTE_OPERATION;
	[PInvokeData("authz.h", MSDNShortId = "c1716cdb-87f9-47d6-bfc3-ae6cc043e917")]
	public enum AUTHZ_SECURITY_ATTRIBUTE_OPERATION
	{
		/// <summary>Do not perform any modification.</summary>
		AUTHZ_SECURITY_ATTRIBUTE_OPERATION_NONE = 0,

		/// <summary>
		/// Delete all existing security attributes and their values in the token and replace them with the specified attributes and values.
		/// <para>If no new attributes are specified, all existing attributes and values are deleted.</para>
		/// <para>
		/// This operation must be the only operation specified and can be specified only once in a single call to
		/// AuthzModifySecurityAttributes. If the operation is not specified as the first in the list of operations, the call to
		/// AuthzModifySecurityAttributes fails. If the operation is specified as the first in the array of operations performed, the
		/// rest of the operations are ignored.
		/// </para>
		/// </summary>
		AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE_ALL,

		/// <summary>
		/// Add a new attribute or a new value to an existing attribute.
		/// <para>
		/// If the value specified for any attribute already exists for that attribute, the call to AuthzModifySecurityAttributes fails.
		/// </para>
		/// </summary>
		AUTHZ_SECURITY_ATTRIBUTE_OPERATION_ADD,

		/// <summary>
		/// Delete the specified values of the specified attributes. If an attribute is specified without a value, that attribute is deleted.
		/// <para>If this operation results in an attribute that does not contain any values, that attribute is deleted.</para>
		/// <para>
		/// If a value is specified that does not match an existing attribute, no modifications are performed and the call to
		/// AuthzModifySecurityAttributes fails.
		/// </para>
		/// </summary>
		AUTHZ_SECURITY_ATTRIBUTE_OPERATION_DELETE,

		/// <summary>
		/// The existing values of the specified security attributes are replaced by the specified new values.
		/// <para>If any of the specified attributes does not already exist, they are added.</para>
		/// <para>
		/// When no value is specified for an attribute, that attribute is deleted. Otherwise, the operation is simply ignored and no
		/// failure is reported.
		/// </para>
		/// </summary>
		AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE
	}

	/// <summary>
	/// The AUTHZ_SID_OPERATION enumeration indicates the type of SID operations that can be made by a call to the AuthzModifySids function.
	/// </summary>
	/// <summary>
	/// <para>
	/// The <c>AUTHZ_SID_OPERATION</c> enumeration indicates the type of SID operations that can be made by a call to the AuthzModifySids function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ne-authz-authz_sid_operation typedef enum AUTHZ_SID_OPERATION {
	// AUTHZ_SID_OPERATION_NONE , AUTHZ_SID_OPERATION_REPLACE_ALL , AUTHZ_SID_OPERATION_ADD , AUTHZ_SID_OPERATION_DELETE ,
	// AUTHZ_SID_OPERATION_REPLACE } *PAUTHZ_SID_OPERATION;
	[PInvokeData("authz.h", MSDNShortId = "C312BE7D-DA1B-47FE-80BA-7506B9A26E9E")]
	public enum AUTHZ_SID_OPERATION
	{
		/// <summary>Do not modify anything.</summary>
		AUTHZ_SID_OPERATION_NONE = 0,

		/// <summary>
		/// Deletes all existing SIDs and replaces them with the specified SIDs. If the replacement SIDs are not specified, all existing
		/// SIDs are deleted. This operation can be specified only once and must be the only operation specified.
		/// </summary>
		AUTHZ_SID_OPERATION_REPLACE_ALL = 1,

		/// <summary>Adds a new SID. If the SID already exists, the call fails.</summary>
		AUTHZ_SID_OPERATION_ADD = 2,

		/// <summary>Deletes the specified SID. If no matching SID is found, no modifications are done and the call fails.</summary>
		AUTHZ_SID_OPERATION_DELETE = 3,

		/// <summary>Replaces the existing SID with the specified SID. If the SID does not already exist, then adds the SID.</summary>
		AUTHZ_SID_OPERATION_REPLACE = 4
	}

	/// <summary>
	/// Flags used in the
	/// <see cref="AuthzAccessCheck(AuthzAccessCheckFlags, AUTHZ_CLIENT_CONTEXT_HANDLE, in AUTHZ_ACCESS_REQUEST, AUTHZ_AUDIT_EVENT_HANDLE, PSECURITY_DESCRIPTOR, SECURITY_DESCRIPTOR[], uint, AUTHZ_ACCESS_REPLY, IntPtr)"/> method.
	/// </summary>
	[PInvokeData("authz.h")]
	[Flags]
	public enum AuthzAccessCheckFlags
	{
		/// <summary>
		/// If phAccessCheckResults is not NULL, a deep copy of the security descriptor is copied to the handle referenced by phAccessCheckResults.
		/// </summary>
		NONE = 0,

		/// <summary>
		/// A deep copy of the security descriptor is not performed. The calling application must pass the address of an
		/// AUTHZ_ACCESS_CHECK_RESULTS_HANDLE handle in phAccessCheckResults. The AuthzAccessCheck function sets this handle to a
		/// security descriptor that must remain valid during subsequent calls to AuthzCachedAccessCheck.
		/// </summary>
		AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD = 0x00000001,
	}

	/// <summary>Flags for the <see cref="AuthzInitializeObjectAccessAuditEvent"/> method.</summary>
	[PInvokeData("authz.h")]
	[Flags]
	public enum AuthzAuditEventFlags
	{
		/// <summary>No flags set.</summary>
		NONE = 0,

		/// <summary>Disable generation of success audits.</summary>
		AUTHZ_NO_SUCCESS_AUDIT = 0x00000001,

		/// <summary>Disable generation of failure audits.</summary>
		AUTHZ_NO_FAILURE_AUDIT = 0x00000002,

		/// <summary>
		/// Use pointers to the passed strings instead of allocating memory and copying the strings. The calling application must ensure
		/// that the passed memory stays valid during access checks.
		/// </summary>
		AUTHZ_NO_ALLOC_STRINGS = 0x00000004,

		/// <summary>Undocumented.</summary>
		AUTHZ_WPD_CATEGORY_FLAG = 0x00000010,
	}

	/// <summary>Flags for the <see cref="Authz.AuthzInitializeContextFromSid"/> method.</summary>
	[PInvokeData("authz.h")]
	[Flags]
	public enum AuthzContextFlags
	{
		/// <summary>
		/// Default value.
		/// <para>AuthzInitializeContextFromSid attempts to retrieve the user's token group information by performing an S4U logon.</para>
		/// <para>
		/// If S4U logon is not supported by the user's domain or the calling computer, AuthzInitializeContextFromSid queries the user's
		/// account object for group information. When an account is queried directly, some groups that represent logon characteristics,
		/// such as Network, Interactive, Anonymous, Network Service, or Local Service, are omitted. Applications can explicitly add such
		/// group SIDs by implementing the AuthzComputeGroupsCallback function or calling the AuthzAddSidsToContext function.
		/// </para>
		/// </summary>
		DEFAULT = 0,

		/// <summary>
		/// Causes AuthzInitializeContextFromSid to skip all group evaluations. When this flag is used, the context returned contains
		/// only the SID specified by the UserSid parameter. The specified SID can be an arbitrary or application-specific SID. Other
		/// SIDs can be added to this context by implementing the AuthzComputeGroupsCallback function or by calling the
		/// AuthzAddSidsToContext function.
		/// </summary>
		AUTHZ_SKIP_TOKEN_GROUPS = 0x2,

		/// <summary>
		/// Causes AuthzInitializeContextFromSid to fail if Windows Services For User is not available to retrieve token group information.
		/// <para><c>Windows XP:</c> This flag is not supported.</para>
		/// </summary>
		AUTHZ_REQUIRE_S4U_LOGON = 0x4,

		/// <summary>
		/// Causes AuthzInitializeContextFromSid to retrieve privileges for the new context. If this function performs an S4U logon, it
		/// retrieves privileges from the token. Otherwise, the function retrieves privileges from all SIDs in the context.
		/// </summary>
		AUTHZ_COMPUTE_PRIVILEGES = 0x8
	}

	/// <summary>Flags for the <see cref="Authz.AuthzInitializeResourceManager"/> method.</summary>
	[PInvokeData("authz.h")]
	[Flags]
	public enum AuthzResourceManagerFlags
	{
		/// <summary>
		/// Default call to the function. The resource manager is initialized as the principal identified in the process token, and
		/// auditing is in effect. Note that unless the AUTHZ_RM_FLAG_NO_AUDIT flag is set, SeAuditPrivilege must be enabled for the
		/// function to succeed.
		/// </summary>
		DEFAULT = 0,

		/// <summary>
		/// Auditing is not in effect. If this flag is set, the caller does not need to have SeAuditPrivilege enabled to call this function.
		/// </summary>
		AUTHZ_RM_FLAG_NO_AUDIT = 0x1,

		/// <summary>The resource manager is initialized as the identity of the thread token.</summary>
		AUTHZ_RM_FLAG_INITIALIZE_UNDER_IMPERSONATION = 0x2,

		/// <summary>The resource manager ignores CAP IDs and does not evaluate centralized access policies.</summary>
		AUTHZ_RM_FLAG_NO_CENTRALIZED_ACCESS_POLICIES = 0x4
	}

	/// <summary>Flags that control the behavior of the operation.</summary>
	[PInvokeData("authz.h", MSDNShortId = "8b4d6e14-fb9c-428a-bd94-34eba668edc6")]
	[Flags]
	public enum SOURCE_SCHEMA_REGISTRATION_FLAGS
	{
		/// <summary>
		/// Allows registration of multiple sources with the same name. Use of this flag means that more than one source can call the
		/// AuthzRegisterSecurityEventSource function with the same szEventSourceName at runtime.
		/// </summary>
		AUTHZ_ALLOW_MULTIPLE_SOURCE_INSTANCES = 0x1,

		/// <summary>
		/// The caller is a migrated publisher that has registered a manifest with WEvtUtil.exe. The GUID of the provider specified by
		/// the pProviderGuid member is stored in the registry.
		/// </summary>
		AUTHZ_MIGRATED_LEGACY_PUBLISHER = 0x2,
	}

	/// <summary>
	/// <para>
	/// The <c>AuthzAccessCheck</c> function determines which access bits can be granted to a client for a given set of security
	/// descriptors. The AUTHZ_ACCESS_REPLY structure returns an array of granted access masks and error status. Optionally, access masks
	/// that will always be granted can be cached, and a handle to cached values is returned.
	/// </para>
	/// </summary>
	/// <param name="Flags">
	/// <para>
	/// A <c>DWORD</c> value that specifies how the security descriptor is copied. This parameter can be one of the following values.
	/// </para>
	/// <para>
	/// Starting with Windows 8 and Windows Server 2012, when you call this function on a remote context handle, the upper 16 bits must
	/// be zero.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>If phAccessCheckResults is not NULL, a deep copy of the security descriptor is copied to the handle referenced by phAccessCheckResults.</term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD 1</term>
	/// <term>
	/// A deep copy of the security descriptor is not performed. The calling application must pass the address of an
	/// AUTHZ_ACCESS_CHECK_RESULTS_HANDLE handle in phAccessCheckResults. The AuthzAccessCheck function sets this handle to a security
	/// descriptor that must remain valid during subsequent calls to AuthzCachedAccessCheck.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hAuthzClientContext">
	/// <para>A handle to a structure that represents the client.</para>
	/// <para>Starting with Windows 8 and Windows Server 2012, the client context can be local or remote.</para>
	/// </param>
	/// <param name="pRequest">
	/// <para>
	/// A pointer to an AUTHZ_ACCESS_REQUEST structure that specifies the desired access mask, principal self security identifier (SID),
	/// and the object type list structure, if it exists.
	/// </para>
	/// </param>
	/// <param name="hAuditEvent">
	/// <para>
	/// A structure that contains object-specific audit information. When the value of this parameter is not <c>null</c>, an audit is
	/// automatically requested. Static audit information is read from the resource manager structure.
	/// </para>
	/// <para>
	/// Starting with Windows 8 and Windows Server 2012, when you use this function with a remote context handle, the value of the
	/// parameter must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// <para>
	/// A pointer to a SECURITY_DESCRIPTOR structure to be used for access checks. The owner SID for the object is picked from this
	/// security descriptor. A <c>NULL</c> discretionary access control list (DACL) in this security descriptor represents a <c>NULL</c>
	/// DACL for the entire object. Make sure the security descriptor contains OWNER and DACL information, or an error code 87 or
	/// "invalid parameter" message will be generated.
	/// </para>
	/// <para>
	/// <c>Important</c><c>NULL</c> DACLs permit all types of access to all users; therefore, do not use <c>NULL</c> DACLs. For
	/// information about creating a DACL, see Creating a DACL.
	/// </para>
	/// <para>A</para>
	/// <para>NULL</para>
	/// <para>system access control list</para>
	/// <para>(SACL) in this security descriptor is treated the same way as an empty SACL.</para>
	/// </param>
	/// <param name="OptionalSecurityDescriptorArray">
	/// <para>
	/// An array of SECURITY_DESCRIPTOR structures. <c>NULL</c> access control lists (ACLs) in these security descriptors are treated as
	/// empty ACLs. The ACL for the entire object is the logical concatenation of all of the ACLs.
	/// </para>
	/// </param>
	/// <param name="OptionalSecurityDescriptorCount">
	/// <para>The number of security descriptors not including the primary security descriptor.</para>
	/// </param>
	/// <param name="pReply">
	/// <para>
	/// A pointer to an AUTHZ_ACCESS_REPLY structure that contains the results of the access check. Before calling the
	/// <c>AuthzAccessCheck</c> function, an application must allocate memory for the <c>GrantedAccessMask</c> and
	/// <c>SaclEvaluationResults</c> members of the <c>AUTHZ_ACCESS_REPLY</c> structure referenced by pReply.
	/// </para>
	/// </param>
	/// <param name="phAccessCheckResults">
	/// <para>
	/// A pointer to return a handle to the cached results of the access check. When this parameter value is not <c>null</c>, the results
	/// of this access check call will be cached. This results in a MAXIMUM_ALLOWED check.
	/// </para>
	/// <para>
	/// Starting with Windows 8 and Windows Server 2012, when you use this function with a remote context handle, the value of the
	/// parameter must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The AuthzAccessCheckCallback callback function will be called if the DACL of the SECURITY_DESCRIPTOR structure pointed to by the
	/// pSecurityDescriptor parameter contains a callback access control entry (ACE).
	/// </para>
	/// <para>
	/// Security attribute variables must be present in the client context if referred to in a conditional expression, otherwise the
	/// conditional expression term referencing them will evaluate to unknown. For more information, see the Security Descriptor
	/// Definition Language for Conditional ACEs topic.
	/// </para>
	/// <para>For more information, see the How AccessCheck Works and Centralized Authorization Policy overviews.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzaccesscheck AUTHZAPI BOOL AuthzAccessCheck( DWORD Flags,
	// AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, PAUTHZ_ACCESS_REQUEST pRequest, AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent,
	// PSECURITY_DESCRIPTOR pSecurityDescriptor, PSECURITY_DESCRIPTOR *OptionalSecurityDescriptorArray, DWORD
	// OptionalSecurityDescriptorCount, PAUTHZ_ACCESS_REPLY pReply, PAUTHZ_ACCESS_CHECK_RESULTS_HANDLE phAccessCheckResults );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "633c2a73-169c-4e0c-abb6-96c360bd63cf")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzAccessCheck(AuthzAccessCheckFlags Flags, AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, in AUTHZ_ACCESS_REQUEST pRequest,
		[Optional] AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent, PSECURITY_DESCRIPTOR pSecurityDescriptor,
		[Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] SECURITY_DESCRIPTOR[]? OptionalSecurityDescriptorArray,
		uint OptionalSecurityDescriptorCount, [In, Out] AUTHZ_ACCESS_REPLY pReply, out SafeAUTHZ_ACCESS_CHECK_RESULTS_HANDLE phAccessCheckResults);

	/// <summary>
	/// <para>
	/// The <c>AuthzAccessCheck</c> function determines which access bits can be granted to a client for a given set of security
	/// descriptors. The AUTHZ_ACCESS_REPLY structure returns an array of granted access masks and error status. Optionally, access masks
	/// that will always be granted can be cached, and a handle to cached values is returned.
	/// </para>
	/// </summary>
	/// <param name="Flags">
	/// <para>
	/// A <c>DWORD</c> value that specifies how the security descriptor is copied. This parameter can be one of the following values.
	/// </para>
	/// <para>
	/// Starting with Windows 8 and Windows Server 2012, when you call this function on a remote context handle, the upper 16 bits must
	/// be zero.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>If phAccessCheckResults is not NULL, a deep copy of the security descriptor is copied to the handle referenced by phAccessCheckResults.</term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD 1</term>
	/// <term>
	/// A deep copy of the security descriptor is not performed. The calling application must pass the address of an
	/// AUTHZ_ACCESS_CHECK_RESULTS_HANDLE handle in phAccessCheckResults. The AuthzAccessCheck function sets this handle to a security
	/// descriptor that must remain valid during subsequent calls to AuthzCachedAccessCheck.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hAuthzClientContext">
	/// <para>A handle to a structure that represents the client.</para>
	/// <para>Starting with Windows 8 and Windows Server 2012, the client context can be local or remote.</para>
	/// </param>
	/// <param name="pRequest">
	/// <para>
	/// A pointer to an AUTHZ_ACCESS_REQUEST structure that specifies the desired access mask, principal self security identifier (SID),
	/// and the object type list structure, if it exists.
	/// </para>
	/// </param>
	/// <param name="hAuditEvent">
	/// <para>
	/// A structure that contains object-specific audit information. When the value of this parameter is not <c>null</c>, an audit is
	/// automatically requested. Static audit information is read from the resource manager structure.
	/// </para>
	/// <para>
	/// Starting with Windows 8 and Windows Server 2012, when you use this function with a remote context handle, the value of the
	/// parameter must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// <para>
	/// A pointer to a SECURITY_DESCRIPTOR structure to be used for access checks. The owner SID for the object is picked from this
	/// security descriptor. A <c>NULL</c> discretionary access control list (DACL) in this security descriptor represents a <c>NULL</c>
	/// DACL for the entire object. Make sure the security descriptor contains OWNER and DACL information, or an error code 87 or
	/// "invalid parameter" message will be generated.
	/// </para>
	/// <para>
	/// <c>Important</c><c>NULL</c> DACLs permit all types of access to all users; therefore, do not use <c>NULL</c> DACLs. For
	/// information about creating a DACL, see Creating a DACL.
	/// </para>
	/// <para>A</para>
	/// <para>NULL</para>
	/// <para>system access control list</para>
	/// <para>(SACL) in this security descriptor is treated the same way as an empty SACL.</para>
	/// </param>
	/// <param name="OptionalSecurityDescriptorArray">
	/// <para>
	/// An array of SECURITY_DESCRIPTOR structures. <c>NULL</c> access control lists (ACLs) in these security descriptors are treated as
	/// empty ACLs. The ACL for the entire object is the logical concatenation of all of the ACLs.
	/// </para>
	/// </param>
	/// <param name="OptionalSecurityDescriptorCount">
	/// <para>The number of security descriptors not including the primary security descriptor.</para>
	/// </param>
	/// <param name="pReply">
	/// <para>
	/// A pointer to an AUTHZ_ACCESS_REPLY structure that contains the results of the access check. Before calling the
	/// <c>AuthzAccessCheck</c> function, an application must allocate memory for the <c>GrantedAccessMask</c> and
	/// <c>SaclEvaluationResults</c> members of the <c>AUTHZ_ACCESS_REPLY</c> structure referenced by pReply.
	/// </para>
	/// </param>
	/// <param name="phAccessCheckResults">
	/// <para>
	/// A pointer to return a handle to the cached results of the access check. When this parameter value is not <c>null</c>, the results
	/// of this access check call will be cached. This results in a MAXIMUM_ALLOWED check.
	/// </para>
	/// <para>
	/// Starting with Windows 8 and Windows Server 2012, when you use this function with a remote context handle, the value of the
	/// parameter must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The AuthzAccessCheckCallback callback function will be called if the DACL of the SECURITY_DESCRIPTOR structure pointed to by the
	/// pSecurityDescriptor parameter contains a callback access control entry (ACE).
	/// </para>
	/// <para>
	/// Security attribute variables must be present in the client context if referred to in a conditional expression, otherwise the
	/// conditional expression term referencing them will evaluate to unknown. For more information, see the Security Descriptor
	/// Definition Language for Conditional ACEs topic.
	/// </para>
	/// <para>For more information, see the How AccessCheck Works and Centralized Authorization Policy overviews.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzaccesscheck AUTHZAPI BOOL AuthzAccessCheck( DWORD Flags,
	// AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, PAUTHZ_ACCESS_REQUEST pRequest, AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent,
	// PSECURITY_DESCRIPTOR pSecurityDescriptor, PSECURITY_DESCRIPTOR *OptionalSecurityDescriptorArray, DWORD
	// OptionalSecurityDescriptorCount, PAUTHZ_ACCESS_REPLY pReply, PAUTHZ_ACCESS_CHECK_RESULTS_HANDLE phAccessCheckResults );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "633c2a73-169c-4e0c-abb6-96c360bd63cf")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzAccessCheck(AuthzAccessCheckFlags Flags, AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, in AUTHZ_ACCESS_REQUEST pRequest,
		[Optional] AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent, PSECURITY_DESCRIPTOR pSecurityDescriptor,
		[Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] SECURITY_DESCRIPTOR[]? OptionalSecurityDescriptorArray,
		uint OptionalSecurityDescriptorCount, [In, Out] AUTHZ_ACCESS_REPLY pReply, [Optional] IntPtr phAccessCheckResults);

	/// <summary>
	/// The <c>AuthzAddSidsToContext</c> function creates a copy of an existing context and appends a given set of security identifiers
	/// (SIDs) and restricted SIDs.
	/// </summary>
	/// <param name="hAuthzClientContext">An <c>AUTHZ_CLIENT_CONTEXT_HANDLE</c> structure to be copied as the basis for NewClientContext.</param>
	/// <param name="Sids">
	/// A pointer to a SID_AND_ATTRIBUTES structure containing the SIDs and attributes to be added to the unrestricted part of the client context.
	/// </param>
	/// <param name="SidCount">The number of SIDs to be added.</param>
	/// <param name="RestrictedSids">
	/// A pointer to a SID_AND_ATTRIBUTES structure containing the SIDs and attributes to be added to the restricted part of the client context.
	/// </param>
	/// <param name="RestrictedSidCount">Number of restricted SIDs to be added.</param>
	/// <param name="phNewAuthzClientContext">
	/// A pointer to the created <c>AUTHZ_CLIENT_CONTEXT_HANDLE</c> structure containing input values for expiration time, identifier,
	/// flags, additional SIDs and restricted SIDs.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzaddsidstocontext AUTHZAPI BOOL AuthzAddSidsToContext(
	// AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, PSID_AND_ATTRIBUTES Sids, DWORD SidCount, PSID_AND_ATTRIBUTES RestrictedSids,
	// DWORD RestrictedSidCount, PAUTHZ_CLIENT_CONTEXT_HANDLE phNewAuthzClientContext );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "4744013b-7f2e-4ebb-8944-10ffcc6006d0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzAddSidsToContext(AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SID_AND_ATTRIBUTES[]? Sids,
		[Optional] uint SidCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] SID_AND_ATTRIBUTES[]? RestrictedSids, [Optional] uint RestrictedSidCount,
		out SafeAUTHZ_CLIENT_CONTEXT_HANDLE phNewAuthzClientContext);

	/// <summary>
	/// The <c>AuthzCachedAccessCheck</c> function performs a fast access check based on a cached handle containing the static granted
	/// bits from a previous AuthzAccessCheck call.
	/// </summary>
	/// <param name="Flags">Reserved for future use.</param>
	/// <param name="hAccessCheckResults">A handle to the cached access check results.</param>
	/// <param name="pRequest">
	/// Access request handle specifying the desired access mask, principal self SID, and the object type list structure (if any).
	/// </param>
	/// <param name="hAuditEvent">
	/// A structure that contains object-specific audit information. When the value of this parameter is not null, an audit is
	/// automatically requested. Static audit information is read from the resource manager structure.
	/// </param>
	/// <param name="pReply">
	/// A pointer to an AUTHZ_ACCESS_REPLY handle that returns the results of access check as an array of GrantedAccessMask/ErrorValue
	/// pairs. The number of pairs returned is supplied by the caller in the <c>ResultListLength</c> member of the
	/// <c>AUTHZ_ACCESS_REPLY</c> structure.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// <para>Expected values of the Error members of array elements returned are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// All the access bits, not including MAXIMUM_ALLOWED, are granted and the GrantedAccessMask member of the pReply parameter is not zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_PRIVILEGE_NOT_HELD</term>
	/// <term>
	/// The DesiredAccess member of the pRequest parameter includes ACCESS_SYSTEM_SECURITY, and the client does not have the
	/// SeSecurityPrivilege privilege.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>One or more of the following is true:</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The client context pointer is stored in the AuthzHandle parameter. The structure of the client context must be exactly the same
	/// as it was at the time AuthzHandle was created. This restriction is for the following fields:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>SIDs</term>
	/// </item>
	/// <item>
	/// <term>RestrictedSids</term>
	/// </item>
	/// <item>
	/// <term>Privileges</term>
	/// </item>
	/// </list>
	/// <para>
	/// Pointers to the primary security descriptor and the optional security descriptor array are stored in AuthzHandle at the time of
	/// handle creation. These pointers must still be valid.
	/// </para>
	/// <para>
	/// The <c>AuthzCachedAccessCheck</c> function maintains a cache as a result of evaluating Central Access Policies (CAP) on objects
	/// unless CAPs are ignored, for example when the AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES flag is used. The client may call the
	/// AuthzFreeCentralAccessPolicyCache function to free up this cache. Note that this requires a subsequent call to
	/// <c>AuthzCachedAccessCheck</c> to rebuild the cache if necessary.
	/// </para>
	/// <para>For more information, see the How AccessCheck Works and Centralized Authorization Policy overviews.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzcachedaccesscheck AUTHZAPI BOOL AuthzCachedAccessCheck(
	// DWORD Flags, AUTHZ_ACCESS_CHECK_RESULTS_HANDLE hAccessCheckResults, PAUTHZ_ACCESS_REQUEST pRequest, AUTHZ_AUDIT_EVENT_HANDLE
	// hAuditEvent, PAUTHZ_ACCESS_REPLY pReply );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "8b3bb69f-7bf9-4e4a-b870-081dd92c7ee4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzCachedAccessCheck([Optional] uint Flags, AUTHZ_ACCESS_CHECK_RESULTS_HANDLE hAccessCheckResults, in AUTHZ_ACCESS_REQUEST pRequest, [Optional] AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent, AUTHZ_ACCESS_REPLY pReply);

	/// <summary>
	/// The <c>AuthzEnumerateSecurityEventSources</c> function retrieves the registered security event sources that are not installed by default.
	/// </summary>
	/// <param name="dwFlags">Reserved for future use; set this parameter to zero.</param>
	/// <param name="Buffer">
	/// A pointer to an array of AUTHZ_SOURCE_SCHEMA_REGISTRATION structures that returns the registered security event sources.
	/// </param>
	/// <param name="pdwCount">A pointer to a variable that receives the number of event sources found.</param>
	/// <param name="pdwLength">
	/// A pointer to a variable that specifies the length of the Buffer parameter in bytes. On output, this parameter receives the number
	/// of bytes used or required.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzenumeratesecurityeventsources AUTHZAPI BOOL
	// AuthzEnumerateSecurityEventSources( DWORD dwFlags, PAUTHZ_SOURCE_SCHEMA_REGISTRATION Buffer, PDWORD pdwCount, PDWORD pdwLength );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "2a20ccc9-f2ac-41e4-9d86-745004775e67")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzEnumerateSecurityEventSources([Optional] uint dwFlags, IntPtr Buffer, out uint pdwCount, ref uint pdwLength);

	/// <summary>
	/// The <c>AuthzEnumerateSecurityEventSources</c> function retrieves the registered security event sources that are not installed by default.
	/// </summary>
	/// <returns>An array of AUTHZ_SOURCE_SCHEMA_REGISTRATION structures that returns the registered security event sources.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzenumeratesecurityeventsources AUTHZAPI BOOL
	[PInvokeData("authz.h", MSDNShortId = "2a20ccc9-f2ac-41e4-9d86-745004775e67")]
	public static IEnumerable<AUTHZ_SOURCE_SCHEMA_REGISTRATION> AuthzEnumerateSecurityEventSources()
	{
		var len = 0U;
		if (!AuthzEnumerateSecurityEventSources(0, IntPtr.Zero, out _, ref len) && len == 0)
			Win32Error.ThrowLastError();
		using var mem = new SafeHGlobalHandle((int)len);
		Win32Error.ThrowLastErrorIfFalse(AuthzEnumerateSecurityEventSources(0, mem, out var cnt, ref len));
		return mem.ToEnumerable<AUTHZ_SOURCE_SCHEMA_REGISTRATION>((int)cnt).ToArray();
	}

	/// <summary>
	/// <para>The <c>AuthzFreeAuditEvent</c> function frees the structure allocated by the AuthzInitializeObjectAccessAuditEvent function.</para>
	/// </summary>
	/// <param name="hAuditEvent">
	/// <para>A pointer to the <c>AUTHZ_AUDIT_EVENT_HANDLE</c> structure to be freed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzfreeauditevent AUTHZAPI BOOL AuthzFreeAuditEvent(
	// AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "e2980ef7-45dd-47c7-ba4d-f36b52bbd7dc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzFreeAuditEvent(AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent);

	/// <summary>
	/// The <c>AuthzFreeCentralAccessPolicyCache</c> function frees the cache maintained as a result of AuthzCachedAccessCheck evaluating
	/// the Central Access Policies (CAP) that applies for the resource.
	/// </summary>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>For more information, see the How AccessCheck Works and Centralized Authorization Policy overviews.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzfreecentralaccesspolicycache AUTHZAPI BOOL
	// AuthzFreeCentralAccessPolicyCache( );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "0F972A95-3CD7-4C86-99DE-5B3D50CE9A34")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzFreeCentralAccessPolicyCache();

	/// <summary>
	/// <para>
	/// The <c>AuthzFreeContext</c> function frees all structures and memory associated with the client context. The list of handles for
	/// a client is freed in this call.
	/// </para>
	/// <para>
	/// Starting with Windows Server 2012 and Windows 8, this function also frees the memory associated with device groups, user claims,
	/// and device claims.
	/// </para>
	/// </summary>
	/// <param name="hAuthzClientContext">
	/// <para>The <c>AUTHZ_CLIENT_CONTEXT_HANDLE</c> structure to be freed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzfreecontext
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "cad9fff0-9aa6-4cb2-a34f-94cf72f66bca")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzFreeContext(AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext);

	/// <summary>
	/// <para>The <c>AuthzFreeHandle</c> function finds and deletes a handle from the handle list.</para>
	/// </summary>
	/// <param name="hAccessCheckResults">
	/// <para>A handle to be freed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzfreehandle AUTHZAPI BOOL AuthzFreeHandle(
	// AUTHZ_ACCESS_CHECK_RESULTS_HANDLE hAccessCheckResults );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "8d2e2ae9-b515-4a02-b366-5b107b4f7ffa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzFreeHandle(AUTHZ_ACCESS_CHECK_RESULTS_HANDLE hAccessCheckResults);

	/// <summary>
	/// <para>The <c>AuthzFreeResourceManager</c> function frees a resource manager object.</para>
	/// </summary>
	/// <param name="hAuthzResourceManager">
	/// <para>The <c>AUTHZ_RESOURCE_MANAGER_HANDLE</c> to be freed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzfreeresourcemanager AUTHZAPI BOOL
	// AuthzFreeResourceManager( AUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "8b716368-8d81-4c62-9086-0976b39bbcf8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzFreeResourceManager(AUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager);

	/// <summary>
	/// <para>The <c>AuthzGetInformationFromContext</c> function returns information about an Authz context.</para>
	/// <para>
	/// Starting with Windows Server 2012 and Windows 8, device groups are returned as a TOKEN_GROUPS structure. User and device claims
	/// are returned as an AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structure.
	/// </para>
	/// </summary>
	/// <param name="hAuthzClientContext">
	/// <para>A handle to the context.</para>
	/// </param>
	/// <param name="InfoClass">
	/// <para>A value of the AUTHZ_CONTEXT_INFORMATION_CLASS enumeration that indicates the type of information to be returned.</para>
	/// </param>
	/// <param name="BufferSize">
	/// <para>Size of the buffer passed.</para>
	/// </param>
	/// <param name="pSizeRequired">
	/// <para>A pointer to a <c>DWORD</c> of the buffer size required for returning the structure.</para>
	/// </param>
	/// <param name="Buffer">
	/// <para>
	/// A pointer to memory that can receive the information. The structure returned depends on the information requested in the
	/// InfoClass parameter.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzgetinformationfromcontext AUTHZAPI BOOL
	// AuthzGetInformationFromContext( AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, AUTHZ_CONTEXT_INFORMATION_CLASS InfoClass, DWORD
	// BufferSize, PDWORD pSizeRequired, PVOID Buffer );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "c365029a-3ff3-49c1-9dfc-b52948e466f3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzGetInformationFromContext(AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext,
		AUTHZ_CONTEXT_INFORMATION_CLASS InfoClass, uint BufferSize, out uint pSizeRequired, IntPtr Buffer);

	/// <summary>
	/// <para>The <c>AuthzGetInformationFromContext</c> function returns information about an Authz context.</para>
	/// <para>
	/// Starting with Windows Server 2012 and Windows 8, device groups are returned as a TOKEN_GROUPS structure. User and device claims are
	/// returned as an AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structure.
	/// </para>
	/// </summary>
	/// <typeparam name="T">The type of information requested.</typeparam>
	/// <param name="hAuthzClientContext">A handle to the context.</param>
	/// <param name="InfoClass">
	/// A value of the AUTHZ_CONTEXT_INFORMATION_CLASS enumeration that indicates the type of information to be returned.
	/// </param>
	/// <returns>The information requested in the InfoClass parameter.</returns>
	/// <exception cref="System.ArgumentException">No corresponding AUTHZ_CONTEXT_INFORMATION_CLASS for type " + typeof(T).Name</exception>
	[PInvokeData("authz.h", MSDNShortId = "c365029a-3ff3-49c1-9dfc-b52948e466f3")]
	public static T? AuthzGetInformationFromContext<T>(AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, AUTHZ_CONTEXT_INFORMATION_CLASS? InfoClass = null)
	{
		if (!CorrespondingTypeAttribute.CanGet<T, AUTHZ_CONTEXT_INFORMATION_CLASS>(InfoClass, out var iClass))
			throw new ArgumentException("No corresponding AUTHZ_CONTEXT_INFORMATION_CLASS for type " + typeof(T).Name);
		if (!AuthzGetInformationFromContext(hAuthzClientContext, iClass, 0, out var sz, default) && sz == 0)
			throw Win32Error.GetLastError().GetException()!;
		using var mem = new SafeHGlobalHandle(sz);
		Win32Error.ThrowLastErrorIfFalse(AuthzGetInformationFromContext(hAuthzClientContext, iClass, mem.Size, out sz, mem));
		return mem.ToType<T>();
	}

	/// <summary>
	/// <para>
	/// The <c>AuthzInitializeCompoundContext</c> function creates a user-mode context from the given user and device security contexts.
	/// </para>
	/// </summary>
	/// <param name="UserContext">
	/// <para>User context to create the compound context from.</para>
	/// </param>
	/// <param name="DeviceContext">
	/// <para>Device context to create the compound context from. This must not be the same as the user context.</para>
	/// </param>
	/// <param name="phCompoundContext">
	/// <para>Used to return the resultant compound context.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinitializecompoundcontext AUTHZAPI BOOL
	// AuthzInitializeCompoundContext( AUTHZ_CLIENT_CONTEXT_HANDLE UserContext, AUTHZ_CLIENT_CONTEXT_HANDLE DeviceContext,
	// PAUTHZ_CLIENT_CONTEXT_HANDLE phCompoundContext );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "2EC9EE76-9A92-40DF-9884-547D96FF3E09")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeCompoundContext(AUTHZ_CLIENT_CONTEXT_HANDLE UserContext, AUTHZ_CLIENT_CONTEXT_HANDLE DeviceContext, out SafeAUTHZ_CLIENT_CONTEXT_HANDLE phCompoundContext);

	/// <summary>
	/// <para>The <c>AuthzInitializeContextFromAuthzContext</c> function creates a new client context based on an existing client context.</para>
	/// <para>
	/// Starting with Windows Server 2012 and Windows 8, this function also duplicates device groups, user claims, and device claims.
	/// </para>
	/// </summary>
	/// <param name="Flags">Reserved for future use.</param>
	/// <param name="hAuthzClientContext">The handle to an existing client context.</param>
	/// <param name="pExpirationTime">
	/// Sets the time limit for how long the returned context structure is valid. If no value is passed, then the token never expires.
	/// Expiration time is not currently enforced.
	/// </param>
	/// <param name="Identifier">The specific identifier for the resource manager.</param>
	/// <param name="DynamicGroupArgs">
	/// A pointer to parameters to be passed to the callback function that computes dynamic groups. If the value is <c>NULL</c>, then the
	/// callback function is not called.
	/// </param>
	/// <param name="phNewAuthzClientContext">
	/// A pointer to the duplicated AUTHZ_CLIENT_CONTEXT_HANDLE handle. When you have finished using the handle, release it by calling
	/// the AuthzFreeContext function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// This function calls the AuthzComputeGroupsCallback callback function to add security identifiers to the newly created context.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinitializecontextfromauthzcontext AUTHZAPI BOOL
	// AuthzInitializeContextFromAuthzContext( DWORD Flags, AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, PLARGE_INTEGER
	// pExpirationTime, LUID Identifier, PVOID DynamicGroupArgs, PAUTHZ_CLIENT_CONTEXT_HANDLE phNewAuthzClientContext );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "dac5e354-ee31-45e3-9eb8-8f3263161ad2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeContextFromAuthzContext([Optional] uint Flags, AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, in long pExpirationTime, LUID Identifier, IntPtr DynamicGroupArgs, out SafeAUTHZ_CLIENT_CONTEXT_HANDLE phNewAuthzClientContext);

	/// <summary>
	/// <para>The <c>AuthzInitializeContextFromAuthzContext</c> function creates a new client context based on an existing client context.</para>
	/// <para>
	/// Starting with Windows Server 2012 and Windows 8, this function also duplicates device groups, user claims, and device claims.
	/// </para>
	/// </summary>
	/// <param name="Flags">Reserved for future use.</param>
	/// <param name="hAuthzClientContext">The handle to an existing client context.</param>
	/// <param name="pExpirationTime">
	/// Sets the time limit for how long the returned context structure is valid. If no value is passed, then the token never expires.
	/// Expiration time is not currently enforced.
	/// </param>
	/// <param name="Identifier">The specific identifier for the resource manager.</param>
	/// <param name="DynamicGroupArgs">
	/// A pointer to parameters to be passed to the callback function that computes dynamic groups. If the value is <c>NULL</c>, then the
	/// callback function is not called.
	/// </param>
	/// <param name="phNewAuthzClientContext">
	/// A pointer to the duplicated AUTHZ_CLIENT_CONTEXT_HANDLE handle. When you have finished using the handle, release it by calling
	/// the AuthzFreeContext function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// This function calls the AuthzComputeGroupsCallback callback function to add security identifiers to the newly created context.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinitializecontextfromauthzcontext AUTHZAPI BOOL
	// AuthzInitializeContextFromAuthzContext( DWORD Flags, AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, PLARGE_INTEGER
	// pExpirationTime, LUID Identifier, PVOID DynamicGroupArgs, PAUTHZ_CLIENT_CONTEXT_HANDLE phNewAuthzClientContext );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "dac5e354-ee31-45e3-9eb8-8f3263161ad2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeContextFromAuthzContext([Optional] uint Flags, AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, [Optional] IntPtr pExpirationTime, LUID Identifier, IntPtr DynamicGroupArgs, out SafeAUTHZ_CLIENT_CONTEXT_HANDLE phNewAuthzClientContext);

	/// <summary>
	/// <para>
	/// The <c>AuthzInitializeContextFromSid</c> function creates a user-mode client context from a user security identifier (SID).
	/// Domain SIDs retrieve token group attributes from the Active Directory.
	/// </para>
	/// </summary>
	/// <param name="Flags">
	/// <para>The following flags are defined.</para>
	/// <para>
	/// Starting with Windows 8 and Windows Server 2012, when you call this function on a remote context handle, the upper 16 bits must
	/// be zero.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0 (0x0)</term>
	/// <term>
	/// Default value. AuthzInitializeContextFromSid attempts to retrieve the user's token group information by performing an S4U logon.
	/// If S4U logon is not supported by the user's domain or the calling computer, AuthzInitializeContextFromSid queries the user's
	/// account object for group information. When an account is queried directly, some groups that represent logon characteristics, such
	/// as Network, Interactive, Anonymous, Network Service, or Local Service, are omitted. Applications can explicitly add such group
	/// SIDs by implementing the AuthzComputeGroupsCallback function or calling the AuthzAddSidsToContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_SKIP_TOKEN_GROUPS 2 (0x2)</term>
	/// <term>
	/// Causes AuthzInitializeContextFromSid to skip all group evaluations. When this flag is used, the context returned contains only
	/// the SID specified by the UserSid parameter. The specified SID can be an arbitrary or application-specific SID. Other SIDs can be
	/// added to this context by implementing the AuthzComputeGroupsCallback function or by calling the AuthzAddSidsToContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_REQUIRE_S4U_LOGON 4 (0x4)</term>
	/// <term>
	/// Causes AuthzInitializeContextFromSid to fail if Windows Services For User is not available to retrieve token group information.
	/// Windows XP: This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_COMPUTE_PRIVILEGES 8 (0x8)</term>
	/// <term>
	/// Causes AuthzInitializeContextFromSid to retrieve privileges for the new context. If this function performs an S4U logon, it
	/// retrieves privileges from the token. Otherwise, the function retrieves privileges from all SIDs in the context.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="UserSid">
	/// <para>
	/// The SID of the user for whom a client context will be created. This must be a valid user or computer account unless the
	/// AUTHZ_SKIP_TOKEN_GROUPS flag is used.
	/// </para>
	/// </param>
	/// <param name="hAuthzResourceManager">
	/// <para>A handle to the resource manager creating this client context. This handle is stored in the client context structure.</para>
	/// <para>
	/// Starting with Windows 8 and Windows Server 2012, the resource manager can be local or remote and is obtained by calling the
	/// AuthzInitializeRemoteResourceManager function.
	/// </para>
	/// </param>
	/// <param name="pExpirationTime">
	/// <para>
	/// Expiration date and time of the token. If no value is passed, the token never expires. Expiration time is not currently enforced.
	/// </para>
	/// </param>
	/// <param name="Identifier">
	/// <para>Specific identifier of the resource manager. This parameter is not currently used.</para>
	/// </param>
	/// <param name="DynamicGroupArgs">
	/// <para>
	/// A pointer to parameters to be passed to the callback function that computes dynamic groups. This parameter can be <c>NULL</c> if
	/// no dynamic parameters are passed to the callback function.
	/// </para>
	/// <para>
	/// Starting with Windows 8 and Windows Server 2012, this parameter must be <c>NULL</c> if the resource manager is remote. Otherwise,
	/// ERROR_NOT_SUPPORTED will be set.
	/// </para>
	/// </param>
	/// <param name="phAuthzClientContext">
	/// <para>
	/// A pointer to the handle to the client context that the <c>AuthzInitializeContextFromSid</c> function creates. When you have
	/// finished using the handle, free it by calling the AuthzFreeContext function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If possible, call the AuthzInitializeContextFromToken function instead of <c>AuthzInitializeContextFromSid</c>.
	/// <c>AuthzInitializeContextFromSid</c> attempts to retrieve the information available in a logon token had the client actually
	/// logged on. An actual logon token provides more information, such as logon type and logon properties, and reflects the behavior of
	/// the authentication package used for the logon. The client context created by <c>AuthzInitializeContextFromToken</c> uses a logon
	/// token, and the resulting client context is more complete and accurate than a client context created by <c>AuthzInitializeContextFromSid</c>.
	/// </para>
	/// <para>This function resolves valid user SIDs only.</para>
	/// <para>
	/// <c>Windows XP:</c> This function resolves group memberships for valid user and group SIDs (unless the AUTHZ_SKIP_TOKEN_GROUPS
	/// flag is used). Support for resolving memberships of group SIDs may be altered or unavailable in subsequent versions.
	/// </para>
	/// <para>This function calls the AuthzComputeGroupsCallback callback function to add SIDs to the newly created context.</para>
	/// <para>
	/// <c>Important</c> Applications should not assume that the calling context has permission to use this function. The
	/// <c>AuthzInitializeContextFromSid</c> function reads the tokenGroupsGlobalAndUniversal attribute of the SID specified in the call
	/// to determine the current user's group memberships. If the user's object is in Active Directory, the calling context must have
	/// read access to the tokenGroupsGlobalAndUniversal attribute on the user object. When a new domain is created, the default access
	/// compatibility selection is <c>Permissions compatible with Windows 2000 and Windows Server 2003 operating systems</c>. When this
	/// option is set, the <c>Pre-Windows 2000 Compatible Access</c> group includes only the <c>Authenticated Users</c> built-in security
	/// identifiers. Therefore, applications may not have access to the tokenGroupsGlobalAndUniversal attribute; in this case, the
	/// <c>AuthzInitializeContextFromSid</c> function fails with ACCESS_DENIED. Applications that use this function should correctly
	/// handle this error and provide supporting documentation. To simplify granting accounts permission to query a user's group
	/// information, add accounts that need the ability to look up group information to the Windows Authorization Access Group.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinitializecontextfromsid AUTHZAPI BOOL
	// AuthzInitializeContextFromSid( DWORD Flags, PSID UserSid, AUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager, PLARGE_INTEGER
	// pExpirationTime, LUID Identifier, PVOID DynamicGroupArgs, PAUTHZ_CLIENT_CONTEXT_HANDLE phAuthzClientContext );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "402a8641-5644-45c1-80e9-c60321c1ac38")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeContextFromSid(
		AuthzContextFlags Flags,
		PSID UserSid,
		[Optional] AUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager,
		[Optional] IntPtr pExpirationTime,
		LUID Identifier,
		[Optional] IntPtr DynamicGroupArgs,
		out SafeAUTHZ_CLIENT_CONTEXT_HANDLE phAuthzClientContext);

	/// <summary>
	/// <para>
	/// The <c>AuthzInitializeContextFromToken</c> function initializes a client authorization context from a kernel token. The kernel
	/// token must have been opened for TOKEN_QUERY.
	/// </para>
	/// <para>Starting with Windows Server 2012 and Windows 8, this function can also copy device groups, user claims, and device claims.</para>
	/// </summary>
	/// <param name="Flags">
	/// <para>Reserved for future use.</para>
	/// </param>
	/// <param name="TokenHandle">
	/// <para>
	/// A handle to the client token used to initialize the pAuthzClientContext parameter. The token must have been opened with
	/// TOKEN_QUERY access.
	/// </para>
	/// </param>
	/// <param name="hAuthzResourceManager">
	/// <para>A handle to the resource manager that created this client context. This handle is stored in the client context structure.</para>
	/// </param>
	/// <param name="pExpirationTime">
	/// <para>
	/// Expiration date and time of the token. If no value is passed, the token never expires. Expiration time is not currently enforced.
	/// </para>
	/// </param>
	/// <param name="Identifier">
	/// <para>Identifier that is specific to the resource manager. This parameter is not currently used.</para>
	/// </param>
	/// <param name="DynamicGroupArgs">
	/// <para>A pointer to parameters to be passed to the callback function that computes dynamic groups.</para>
	/// </param>
	/// <param name="phAuthzClientContext">
	/// <para>A pointer to the AuthzClientContext handle returned. Call AuthzFreeContext when done with the client context.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function calls the AuthzComputeGroupsCallback callback function to add security identifiers to the newly created context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinitializecontextfromtoken AUTHZAPI BOOL
	// AuthzInitializeContextFromToken( DWORD Flags, HANDLE TokenHandle, AUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager,
	// PLARGE_INTEGER pExpirationTime, LUID Identifier, PVOID DynamicGroupArgs, PAUTHZ_CLIENT_CONTEXT_HANDLE phAuthzClientContext );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "75a7fb3f-6b3a-42ca-b467-f57baf6c60c6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeContextFromToken(uint Flags, HTOKEN TokenHandle, AUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager,
		[Optional] IntPtr pExpirationTime, LUID Identifier, [Optional] IntPtr DynamicGroupArgs, out SafeAUTHZ_CLIENT_CONTEXT_HANDLE phAuthzClientContext);

	/// <summary>
	/// <para>The <c>AuthzInitializeObjectAccessAuditEvent</c> function initializes auditing for an object.</para>
	/// </summary>
	/// <param name="Flags">
	/// <para>Modifies the audit. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AUTHZ_NO_SUCCESS_AUDIT</term>
	/// <term>Disable generation of success audits.</term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_NO_FAILURE_AUDIT</term>
	/// <term>Disable generation of failure audits.</term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_NO_ALLOC_STRINGS</term>
	/// <term>
	/// Use pointers to the passed strings instead of allocating memory and copying the strings. The calling application must ensure that
	/// the passed memory stays valid during access checks.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hAuditEventType">
	/// <para>Reserved. This parameter should be set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="szOperationType">
	/// <para>String that indicates the operation that is to be audited.</para>
	/// </param>
	/// <param name="szObjectType">
	/// <para>String that indicates the type of object being accessed.</para>
	/// </param>
	/// <param name="szObjectName">
	/// <para>String the indicates the name of the object being accessed.</para>
	/// </param>
	/// <param name="szAdditionalInfo">
	/// <para>String, defined by the Resource Manager, for additional audit information.</para>
	/// </param>
	/// <param name="phAuditEvent">
	/// <para>Pointer that receives an <c>AUTHZ_AUDIT_EVENT_HANDLE</c> structure.</para>
	/// </param>
	/// <param name="dwAdditionalParameterCount">
	/// <para>Must be set to zero.</para>
	/// </param>
	/// <param name="parameters">Additional parameters.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinitializeobjectaccessauditevent AUTHZAPI BOOL
	// AuthzInitializeObjectAccessAuditEvent( DWORD Flags, AUTHZ_AUDIT_EVENT_TYPE_HANDLE hAuditEventType, PWSTR szOperationType, PWSTR
	// szObjectType, PWSTR szObjectName, PWSTR szAdditionalInfo, PAUTHZ_AUDIT_EVENT_HANDLE phAuditEvent, DWORD
	// dwAdditionalParameterCount, ... );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("authz.h", MSDNShortId = "cf79a92f-31e0-47cf-8990-4dbd46056a90")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeObjectAccessAuditEvent(AuthzAuditEventFlags Flags, [Optional] IntPtr hAuditEventType, string szOperationType, string szObjectType,
		string szObjectName, string szAdditionalInfo, out SafeAUTHZ_AUDIT_EVENT_HANDLE phAuditEvent, uint dwAdditionalParameterCount = 0, IntPtr parameters = default);

	/// <summary>
	/// The <c>AuthzInitializeObjectAccessAuditEvent2</c> function allocates and initializes an <c>AUTHZ_AUDIT_EVENT_HANDLE</c> handle
	/// for use with the AuthzAccessCheck function.
	/// </summary>
	/// <param name="Flags">
	/// <para>Flags that modify the behavior of the audit. The following table shows the possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AUTHZ_NO_ALLOC_STRINGS</term>
	/// <term>
	/// Uses pointers to the passed strings instead of allocating memory and copying the strings. The calling application must ensure
	/// that the passed memory remains valid during access checks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_NO_FAILURE_AUDIT</term>
	/// <term>Disables generation of failure audits.</term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_NO_SUCCESS_AUDIT</term>
	/// <term>Disables generation of success audits.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hAuditEventType">Reserved. This parameter should be set to <c>NULL</c>.</param>
	/// <param name="szOperationType">A pointer to a string that indicates the operation that is to be audited.</param>
	/// <param name="szObjectType">A pointer to a string that indicates the type of object accessed.</param>
	/// <param name="szObjectName">A pointer to a string that indicates the name of the object accessed.</param>
	/// <param name="szAdditionalInfo">Pointer to a string defined by the Resource Manager that contains additional audit information.</param>
	/// <param name="szAdditionalInfo2">Pointer to a string defined by the Resource Manager that contains additional audit information.</param>
	/// <param name="phAuditEvent">A pointer to the returned <c>AUTHZ_AUDIT_EVENT_HANDLE</c> handle.</param>
	/// <param name="dwAdditionalParameterCount">Must be set to zero.</param>
	/// <param name="parameters">Additional parameters.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinitializeobjectaccessauditevent2 AUTHZAPI BOOL
	// AuthzInitializeObjectAccessAuditEvent2( DWORD Flags, AUTHZ_AUDIT_EVENT_TYPE_HANDLE hAuditEventType, PWSTR szOperationType, PWSTR
	// szObjectType, PWSTR szObjectName, PWSTR szAdditionalInfo, PWSTR szAdditionalInfo2, PAUTHZ_AUDIT_EVENT_HANDLE phAuditEvent, DWORD
	// dwAdditionalParameterCount, ... );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("authz.h", MSDNShortId = "c65bb799-0158-496a-b428-0331c4474b74")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeObjectAccessAuditEvent2(AuthzAuditEventFlags Flags, [Optional] IntPtr hAuditEventType, string szOperationType, string szObjectType,
		string szObjectName, string szAdditionalInfo, string szAdditionalInfo2, out SafeAUTHZ_AUDIT_EVENT_HANDLE phAuditEvent, uint dwAdditionalParameterCount = 0, IntPtr parameters = default);

	/// <summary>
	/// <para>
	/// The <c>AuthzInitializeRemoteResourceManager</c> function allocates and initializes a remote resource manager. The caller can use
	/// the resulting handle to make AuthZ calls over RPC to a remote instance of the resource manager configured on a server.
	/// </para>
	/// </summary>
	/// <param name="pRpcInitInfo">
	/// <para>Pointer to an AUTHZ_RPC_INIT_INFO_CLIENT structure containing the initial information needed to configure the connection.</para>
	/// </param>
	/// <param name="phAuthzResourceManager">
	/// <para>
	/// A handle to the resource manager. When you have finished using the handle, free it by calling the AuthzFreeResourceManager function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinitializeremoteresourcemanager AUTHZAPI BOOL
	// AuthzInitializeRemoteResourceManager( PAUTHZ_RPC_INIT_INFO_CLIENT pRpcInitInfo, PAUTHZ_RESOURCE_MANAGER_HANDLE
	// phAuthzResourceManager );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "C3B6C75B-13A5-49CC-BB01-DA1EEC292C20")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeRemoteResourceManager(in AUTHZ_RPC_INIT_INFO_CLIENT pRpcInitInfo, out SafeAUTHZ_RESOURCE_MANAGER_HANDLE phAuthzResourceManager);

	/// <summary>The AuthzInitializeResourceManager function uses Authz to verify that clients have access to various resources.</summary>
	/// <param name="flags">
	/// A DWORD value that defines how the resource manager is initialized.
	/// <para>AUTHZ_RM_FLAG_NO_AUDIT and AUTHZ_RM_FLAG_INITIALIZE_UNDER_IMPERSONATION can be bitwise-combined.</para>
	/// </param>
	/// <param name="pfnAccessCheck">
	/// A pointer to the AuthzAccessCheckCallback callback function that the resource manager calls each time it encounters a callback
	/// access control entry (ACE) during access control list (ACL) evaluation in AuthzAccessCheck or AuthzCachedAccessCheck. This
	/// parameter can be NULL if no access check callback function is used.
	/// </param>
	/// <param name="pfnComputeDynamicGroups">
	/// A pointer to the AuthzComputeGroupsCallback callback function called by the resource manager during initialization of an
	/// AuthzClientContext handle. This parameter can be NULL if no callback function is used to compute dynamic groups.
	/// </param>
	/// <param name="pfnFreeDynamicGroups">
	/// A pointer to the AuthzFreeGroupsCallback callback function called by the resource manager to free security identifier (SID)
	/// attribute arrays allocated by the compute dynamic groups callback. This parameter can be NULL if no callback function is used to
	/// compute dynamic groups.
	/// </param>
	/// <param name="name">
	/// A string that identifies the resource manager. This parameter can be NULL if the resource manager does not need a name.
	/// </param>
	/// <param name="rm">
	/// A pointer to the returned resource manager handle. When you have finished using the handle, free it by calling the
	/// AuthzFreeResourceManager function.
	/// </param>
	/// <returns>
	/// If the function succeeds, the function returns TRUE. If the function fails, it returns FALSE. To get extended error information,
	/// call GetLastError.
	/// </returns>
	[DllImport(Lib.Authz, ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("authz.h", MSDNShortId = "aa376313")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeResourceManager(AuthzResourceManagerFlags flags, [Optional] AuthzAccessCheckCallback? pfnAccessCheck,
		[Optional] AuthzComputeGroupsCallback? pfnComputeDynamicGroups, [Optional] AuthzFreeGroupsCallback? pfnFreeDynamicGroups,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? name, out SafeAUTHZ_RESOURCE_MANAGER_HANDLE rm);

	/// <summary>
	/// The <c>AuthzInitializeResourceManagerEx</c> function initializes an Authz resource manager and returns a handle to it. Use this
	/// function rather than AuthzInitializeResourceManager when you want the resource manager to manage Central Access Policies (CAPs).
	/// </summary>
	/// <param name="Flags">
	/// <para>
	/// A <c>DWORD</c> value that defines how the resource manager is initialized. This parameter can be one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// Default call to the function. The resource manager is initialized as the principal identified in the process token, and auditing
	/// is in effect. Unless the AUTHZ_RM_FLAG_NO_AUDIT flag is set, SeAuditPrivilege must be enabled for the function to succeed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_RM_FLAG_NO_AUDIT 1</term>
	/// <term>
	/// Auditing is not in effect. If this flag is set, the caller does not need to have SeAuditPrivilege enabled to call this function.
	/// Use this flag if the resource manager will never generate an audit for best performance.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_RM_FLAG_INITIALIZE_UNDER_IMPERSONATION 2</term>
	/// <term>
	/// The resource manager is initialized as the identity of the thread token. If the current thread is impersonating, then use the
	/// impersonation token as the identity of the resource manager.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES 4</term>
	/// <term>The central access policy IDs are ignored. Do not evaluate central access policies.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pAuthzInitInfo">
	/// A pointer to a AUTHZ_INIT_INFO structure that contains the authorization resource manager initialization information.
	/// </param>
	/// <param name="phAuthzResourceManager">
	/// A pointer to the returned resource manager handle. When you have finished using the handle, free it by using the
	/// AuthzFreeResourceManager function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns a value of <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns a value of <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES flag is specified, then AuthzAccessCheck and AuthzCachedAccessCheck ignore CAPID
	/// (Central Access Policies ID) access control entriesSYSTEM_SCOPED_POLICY_ID_ACE and will not evaluate CAPs.
	/// </para>
	/// <para>
	/// If the AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES flag is not specified and pfnGetCentralAccessPolicy is <c>NULL</c>, then
	/// AuthzAccessCheck and AuthzCachedAccessCheck will get CAPs from LSA. For more information, see LsaGetAppliedCAPIDs.
	/// </para>
	/// <para>
	/// If the AUTHZ_RM_FLAG_NO_CENTRAL_ACCESS_POLICIES flag is not specified and a central access policy callback is provided by the
	/// resource manager, then AuthzAccessCheck and AuthzCachedAccessCheck will get CAPs from the resource manager by invoking the callback.
	/// </para>
	/// <para>
	/// The LSA and the central access policy callback can indicate that CAPs are not supported, in which case AuthzAccessCheck and
	/// AuthzCachedAccessCheck ignore CAPID ACEs and will not evaluate CAPs.
	/// </para>
	/// <para>
	/// The LSA and the central access policy callback may fail to return a CAP that corresponds to a particular CAPID, in which case
	/// <c>AuthzAccessCheck</c> and <c>AuthzCachedAccessCheck</c> use the same default CAP as the kernel AccessCheck.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinitializeresourcemanagerex AUTHZAPI BOOL
	// AuthzInitializeResourceManagerEx( DWORD Flags, PAUTHZ_INIT_INFO pAuthzInitInfo, PAUTHZ_RESOURCE_MANAGER_HANDLE
	// phAuthzResourceManager );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "CDB78606-1B53-4516-90E6-1FF096B3D7D9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInitializeResourceManagerEx(AuthzResourceManagerFlags Flags, in AUTHZ_INIT_INFO pAuthzInitInfo, out SafeAUTHZ_RESOURCE_MANAGER_HANDLE phAuthzResourceManager);

	/// <summary>The <c>AuthzInstallSecurityEventSource</c> function installs the specified source as a security event source.</summary>
	/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
	/// <param name="pRegistration">
	/// <para>
	/// A pointer to an AUTHZ_SOURCE_SCHEMA_REGISTRATION structure that contains information about the security event source to be added.
	/// </para>
	/// <para>
	/// The members of the AUTHZ_SOURCE_SCHEMA_REGISTRATION structure are used as follows to install the security event source in the
	/// security log key:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The <c>szEventSourceName</c> member is added as a registry key under</term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>szEventMessageFile</c> member is added as the data in a REG_SZ value named <c>EventMessageFile</c> under the event source key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>szEventAccessStringsFile</c> member is added as the data in a REG_SZ value named <c>ParameterMessageFile</c> under the
	/// event source key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the registry path does not exist, it is created.</term>
	/// </item>
	/// </list>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the <c>szEventSourceXmlSchemaFile</c> member is not <c>NULL</c>, it is added as the data in a REG_SZ value named
	/// <c>XmlSchemaFile</c> under the event source key. This value is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The <c>szExecutableImagePath</c> member may be set to <c>NULL</c>.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzinstallsecurityeventsource AUTHZAPI BOOL
	// AuthzInstallSecurityEventSource( DWORD dwFlags, PAUTHZ_SOURCE_SCHEMA_REGISTRATION pRegistration );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "77cb5c6c-1634-4449-8d05-ce6357ad4e4b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzInstallSecurityEventSource([Optional] uint dwFlags,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(VanaraCustomMarshaler<AUTHZ_SOURCE_SCHEMA_REGISTRATION>))] AUTHZ_SOURCE_SCHEMA_REGISTRATION pRegistration);

	/// <summary>
	/// <para>The <c>AuthzModifyClaims</c> function adds, deletes, or modifies user and device claims in the Authz client context.</para>
	/// </summary>
	/// <param name="hAuthzClientContext">
	/// <para>A handle to the client context to be modified.</para>
	/// </param>
	/// <param name="ClaimClass">
	/// <para>Type of information to be modified. The caller can specify AuthzContextInfoUserClaims or AuthzContextInfoDeviceClaims.</para>
	/// </param>
	/// <param name="pClaimOperations">
	/// <para>
	/// A pointer to an array of AUTHZ_SECURITY_ATTRIBUTE_OPERATION enumeration values that specify the type of claim modification to make.
	/// </para>
	/// </param>
	/// <param name="pClaims">
	/// <para>A pointer to an AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structure that specifies the claims to modify.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The AUTHZ_SECURITY_ATTRIBUTE_OPERATION enumeration must have only one element if the value of that element is
	/// AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE_ALL. Otherwise, the array has the same number of elements as the corresponding PAUTHZ_SECURITY_ATTRIBUTES_INFORMATION.
	/// </para>
	/// <para>
	/// If the AUTHZ_SECURITY_ATTRIBUTE_OPERATION enumeration is AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE and the function fails, call
	/// GetLastError. If the error code is ERROR_ALREADY_EXISTS, the claim's values have duplicate entries.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzmodifyclaims AUTHZAPI BOOL AuthzModifyClaims(
	// AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, AUTHZ_CONTEXT_INFORMATION_CLASS ClaimClass, PAUTHZ_SECURITY_ATTRIBUTE_OPERATION
	// pClaimOperations, PAUTHZ_SECURITY_ATTRIBUTES_INFORMATION pClaims );
	[PInvokeData("authz.h", MSDNShortId = "A93CD1DD-4E87-4C6A-928A-F90AD7F1085E")]
	[DllImport(Lib.Authz, ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzModifyClaims(AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, AUTHZ_CONTEXT_INFORMATION_CLASS ClaimClass,
		[MarshalAs(UnmanagedType.LPArray)] AUTHZ_SECURITY_ATTRIBUTE_OPERATION[] pClaimOperations,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AUTHZ_SECURITY_ATTRIBUTES_INFORMATION_Marshaler))] AUTHZ_SECURITY_ATTRIBUTES_INFORMATION pClaims);

	/// <summary>
	/// <para>
	/// The <c>AuthzModifySecurityAttributes</c> function modifies the security attribute information in the specified client context.
	/// </para>
	/// </summary>
	/// <param name="hAuthzClientContext">
	/// <para>A handle to the client context to be modified.</para>
	/// </param>
	/// <param name="pOperations">
	/// <para>
	/// A pointer to an array of AUTHZ_SECURITY_ATTRIBUTE_OPERATION enumeration values that specify the types of modifications to make.
	/// </para>
	/// <para>
	/// This array must have only one element if the value of that element is <c>AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE_ALL</c>.
	/// Otherwise, the array has the same number of elements as the pAttributes array.
	/// </para>
	/// </param>
	/// <param name="pAttributes">
	/// <para>A pointer to an AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structure that specifies the attributes to modify.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzmodifysecurityattributes AUTHZAPI BOOL
	// AuthzModifySecurityAttributes( AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, PAUTHZ_SECURITY_ATTRIBUTE_OPERATION pOperations,
	// PAUTHZ_SECURITY_ATTRIBUTES_INFORMATION pAttributes );
	[DllImport(Lib.Authz, ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("authz.h", MSDNShortId = "d84873e2-ecfe-45cf-9048-7ed173117efa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzModifySecurityAttributes(AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext,
		[MarshalAs(UnmanagedType.LPArray)] AUTHZ_SECURITY_ATTRIBUTE_OPERATION[] pOperations,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AUTHZ_SECURITY_ATTRIBUTES_INFORMATION_Marshaler))] AUTHZ_SECURITY_ATTRIBUTES_INFORMATION pAttributes);

	/// <summary>
	/// <para>The <c>AuthzModifySids</c> function adds, deletes, or modifies user and device groups in the Authz client context.</para>
	/// </summary>
	/// <param name="hAuthzClientContext">
	/// <para>A handle to the client context to be modified.</para>
	/// </param>
	/// <param name="SidClass">
	/// <para>
	/// Type of information to be modified. The caller can specify AuthzContextInfoGroupsSids, AuthzContextInfoRestrictedSids, or AuthzContextInfoDeviceSids.
	/// </para>
	/// </param>
	/// <param name="pSidOperations">
	/// <para>A pointer to an array of AUTHZ_SID_OPERATION enumeration values that specify the group modifications to make.</para>
	/// </param>
	/// <param name="pSids">
	/// <para>A pointer to a TOKEN_GROUPS structure that specifies the groups to modify.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The AUTHZ_SID_OPERATION enumeration must have only one element if the value of that element is AUTHZ_SID_OPERATION_REPLACE_ALL.
	/// Otherwise, the array has the same number of elements as the corresponding PTOKEN_GROUPS.
	/// </para>
	/// <para>
	/// When you want to use <c>AuthzModifySids</c> to delete, the SIDs are matched but not the SID flags. If no matching SID is found,
	/// no modifications are done and the call fails.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzmodifysids AUTHZAPI BOOL AuthzModifySids(
	// AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, AUTHZ_CONTEXT_INFORMATION_CLASS SidClass, PAUTHZ_SID_OPERATION pSidOperations,
	// PTOKEN_GROUPS pSids );
	[DllImport(Lib.Authz, ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("authz.h", MSDNShortId = "740569A5-6159-409B-B8CB-B3A8BAE4F398")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzModifySids(AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, AUTHZ_CONTEXT_INFORMATION_CLASS SidClass,
		[MarshalAs(UnmanagedType.LPArray)] AUTHZ_SID_OPERATION[] pSidOperations, in TOKEN_GROUPS pSids);

	/// <summary>
	/// The <c>AuthzOpenObjectAudit</c> function reads the system access control list (SACL) of the specified security descriptor and
	/// generates any appropriate audits specified by that SACL.
	/// </summary>
	/// <param name="Flags">Reserved for future use.</param>
	/// <param name="hAuthzClientContext">A handle to the client context of the object to open.</param>
	/// <param name="pRequest">A pointer to an AUTHZ_ACCESS_REQUEST structure.</param>
	/// <param name="hAuditEvent">A handle to the audit event to use.</param>
	/// <param name="pSecurityDescriptor">A pointer to the SECURITY_DESCRIPTOR structure for the object.</param>
	/// <param name="OptionalSecurityDescriptorArray">A pointer to an array of SECURITY_DESCRIPTOR structures.</param>
	/// <param name="OptionalSecurityDescriptorCount">The number of elements in SecurityDescriptorArray.</param>
	/// <param name="pReply">A pointer to an AUTHZ_ACCESS_REPLY structure.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns a nonzero value.</para>
	/// <para>If the function fails, it returns a zero value. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzopenobjectaudit AUTHZAPI BOOL AuthzOpenObjectAudit( DWORD
	// Flags, AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, PAUTHZ_ACCESS_REQUEST pRequest, AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent,
	// PSECURITY_DESCRIPTOR pSecurityDescriptor, PSECURITY_DESCRIPTOR *OptionalSecurityDescriptorArray, DWORD
	// OptionalSecurityDescriptorCount, PAUTHZ_ACCESS_REPLY pReply );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "39c6f0bc-72bf-4a82-b417-c0c5b2626344")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzOpenObjectAudit([Optional] uint Flags, AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, in AUTHZ_ACCESS_REQUEST pRequest,
		AUTHZ_AUDIT_EVENT_HANDLE hAuditEvent, [In] PSECURITY_DESCRIPTOR pSecurityDescriptor,
		[In, Optional] PSECURITY_DESCRIPTOR[]? OptionalSecurityDescriptorArray, uint OptionalSecurityDescriptorCount,
		in AUTHZ_ACCESS_REPLY pReply);

	/// <summary>The <c>AuthzRegisterCapChangeNotification</c> function registers a CAP update notification callback.</summary>
	/// <param name="phCapChangeSubscription">
	/// Pointer to the CAP change notification subscription handle. When you have finished using the handle, unsubscribe by passing this
	/// parameter to the AuthzUnregisterCapChangeNotification function.
	/// </param>
	/// <param name="pfnCapChangeCallback">The CAP change notification callback function.</param>
	/// <param name="pCallbackContext">The context of the user to be passed to the callback function.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// This function is intended for applications that manually manage CAP usage to get notified of CAP changes in the system.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzregistercapchangenotification AUTHZAPI BOOL
	// AuthzRegisterCapChangeNotification( PAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE phCapChangeSubscription, LPTHREAD_START_ROUTINE
	// pfnCapChangeCallback, PVOID pCallbackContext );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "B0675BB3-62FA-462E-8DFB-55C47576DFEC")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzRegisterCapChangeNotification(out SafeAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE phCapChangeSubscription, ThreadProc pfnCapChangeCallback, IntPtr pCallbackContext);

	/// <summary>
	/// The <c>AuthzRegisterSecurityEventSource</c> function registers a security event source with the Local Security Authority (LSA).
	/// </summary>
	/// <param name="dwFlags">This parameter is reserved for future use. Set this parameter to zero.</param>
	/// <param name="szEventSourceName">A pointer to the name of the security event source to register.</param>
	/// <param name="phEventProvider">A pointer to a handle to the registered security event source.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function validates the szEventSourceName parameter and sets up the appropriate structures and RPC connections to log events
	/// with that source name. The validation is handled by an underlying call to an LSA API.
	/// </para>
	/// <para>The LSA API verifies the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The caller has the SeAuditPrivilege access right.</term>
	/// </item>
	/// <item>
	/// <term>The event source is not already in use.</term>
	/// </item>
	/// <item>
	/// <term>The event source is registered.</term>
	/// </item>
	/// <item>
	/// <term>The calling application matches the executable image path in the event source registration, if one exists.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzregistersecurityeventsource AUTHZAPI BOOL
	// AuthzRegisterSecurityEventSource( DWORD dwFlags, PCWSTR szEventSourceName, PAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE phEventProvider );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "726e480d-1a34-4fd6-ac2d-876fa08f4eae")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzRegisterSecurityEventSource([Optional] uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string szEventSourceName, out SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE phEventProvider);

	/// <summary>
	/// <para>The <c>AuthzReportSecurityEvent</c> function generates a security audit for a registered security event source.</para>
	/// <para>
	/// Auditing for the object access event category must be enabled for the <c>AuthzReportSecurityEvent</c> function to generate a
	/// security audit. The available audit types are defined in the AUDIT_PARAM_TYPE enumeration.
	/// </para>
	/// </summary>
	/// <param name="dwFlags">
	/// <para>Flags that specify the type of audit generated. The following table shows the possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>APF_AuditFailure 0x00000000</term>
	/// <term>Failure audits are generated.</term>
	/// </item>
	/// <item>
	/// <term>APF_AuditSuccess 0x00000001</term>
	/// <term>Success audits are generated.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hEventProvider">A handle to the registered security event source to use for the audit.</param>
	/// <param name="dwAuditId">The identifier of the audit.</param>
	/// <param name="pUserSid">
	/// A pointer to the security identifier (SID) that will be listed as the source of the audit in the event log.
	/// </param>
	/// <param name="dwCount">
	/// The number of AuditParamFlag type/value pairs that appear in the variable arguments section that follows this parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzreportsecurityevent AUTHZAPI BOOL
	// AuthzReportSecurityEvent( DWORD dwFlags, AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE hEventProvider, DWORD dwAuditId, PSID pUserSid,
	// DWORD dwCount, ... );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
	[PInvokeData("authz.h", MSDNShortId = "95d561ef-3233-433a-a1e7-b914df1dd211")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzReportSecurityEvent(APF dwFlags, AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE hEventProvider, uint dwAuditId,
		[Optional] PSID pUserSid, uint dwCount, __arglist);

	/// <summary>
	/// The <c>AuthzReportSecurityEventFromParams</c> function generates a security audit for a registered security event source by
	/// using the specified array of audit parameters.
	/// </summary>
	/// <param name="dwFlags">Reserved for future use.</param>
	/// <param name="hEventProvider">A handle to the registered security event source to use for the audit.</param>
	/// <param name="dwAuditId">The identifier of the audit.</param>
	/// <param name="pUserSid">
	/// A pointer to the security identifier (SID) that will be listed as the source of the audit in the event log.
	/// </param>
	/// <param name="pParams">An array of audit parameters.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzreportsecurityeventfromparams AUTHZAPI BOOL
	// AuthzReportSecurityEventFromParams( DWORD dwFlags, AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE hEventProvider, DWORD dwAuditId, PSID
	// pUserSid, PAUDIT_PARAMS pParams );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("authz.h", MSDNShortId = "ee5b598a-0a89-4b32-a9bc-e9c811573b08")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzReportSecurityEventFromParams([Optional] uint dwFlags, AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE hEventProvider,
		uint dwAuditId, [Optional] PSID pUserSid, in AUDIT_PARAMS pParams);

	/// <summary>
	/// The <c>AuthzReportSecurityEventFromParams</c> function generates a security audit for a registered security event source by
	/// using the specified array of audit parameters.
	/// </summary>
	/// <param name="dwFlags">Reserved for future use.</param>
	/// <param name="hEventProvider">A handle to the registered security event source to use for the audit.</param>
	/// <param name="dwAuditId">The identifier of the audit.</param>
	/// <param name="pUserSid">
	/// A pointer to the security identifier (SID) that will be listed as the source of the audit in the event log.
	/// </param>
	/// <param name="pParams">An array of audit parameters.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzreportsecurityeventfromparams AUTHZAPI BOOL
	// AuthzReportSecurityEventFromParams( DWORD dwFlags, AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE hEventProvider, DWORD dwAuditId, PSID
	// pUserSid, PAUDIT_PARAMS pParams );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("authz.h", MSDNShortId = "ee5b598a-0a89-4b32-a9bc-e9c811573b08")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzReportSecurityEventFromParams([Optional] uint dwFlags, AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE hEventProvider,
		uint dwAuditId, [Optional] PSID pUserSid, [In, MarshalAs(UnmanagedType.LPArray)] AUDIT_PARAMS[] pParams);

	/// <summary>
	/// The <c>AuthzSetAppContainerInformation</c> function sets the app container and capability information in a current Authz context.
	/// If the passed in context already has an app container security identifier (SID) set or if the passed in context is not a valid
	/// app container SID, this function fails.
	/// </summary>
	/// <param name="hAuthzClientContext">
	/// The handle to the client context to which the given app container SID and capability SIDs will be added.
	/// </param>
	/// <param name="pAppContainerSid">The app container SID.</param>
	/// <param name="CapabilityCount">The number of capability SIDs to be added. This value can be zero if no capability is to be added.</param>
	/// <param name="pCapabilitySids">
	/// The capability SIDs to be added to the context. This value must be <c>NULL</c> when the CapabilityCount parameter is zero.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzsetappcontainerinformation AUTHZAPI BOOL
	// AuthzSetAppContainerInformation( AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, PSID pAppContainerSid, DWORD CapabilityCount,
	// PSID_AND_ATTRIBUTES pCapabilitySids );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "CD01C5E1-2367-4CC1-A495-A295E3C82B46")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzSetAppContainerInformation([In] AUTHZ_CLIENT_CONTEXT_HANDLE hAuthzClientContext, [In] PSID pAppContainerSid, uint CapabilityCount, [In] SID_AND_ATTRIBUTES[]? pCapabilitySids);

	/// <summary>
	/// The <c>AuthzUninstallSecurityEventSource</c> function removes the specified source from the list of valid security event sources.
	/// </summary>
	/// <param name="dwFlags">Reserved for future use; set this parameter to zero.</param>
	/// <param name="szEventSourceName">
	/// <para>
	/// Name of the source to remove from the list of valid security event sources. This corresponds to the <c>szEventSourceName</c>
	/// member of the AUTHZ_SOURCE_SCHEMA_REGISTRATION structure that defines the source.
	/// </para>
	/// <para>
	/// This function removes the source information from the registry. For more information about the registry keys and values affected,
	/// see the AuthzInstallSecurityEventSource function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzuninstallsecurityeventsource AUTHZAPI BOOL
	// AuthzUninstallSecurityEventSource( DWORD dwFlags, PCWSTR szEventSourceName );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "495157da-d4ed-42ff-bcb4-5c07ab9ec0e6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzUninstallSecurityEventSource([Optional] uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string szEventSourceName);

	/// <summary>
	/// The <c>AuthzUnregisterCapChangeNotification</c> function removes a previously registered CAP update notification callback.
	/// </summary>
	/// <param name="hCapChangeSubscription">Handle of the CAP change notification subscription to unregister.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// This function blocks operations until all callbacks are complete. Do not call this function from inside a callback function
	/// because it will cause a deadlock.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzunregistercapchangenotification AUTHZAPI BOOL
	// AuthzUnregisterCapChangeNotification( AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE hCapChangeSubscription );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "79374C66-CD50-4351-A16B-AF79A579AF74")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzUnregisterCapChangeNotification(AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE hCapChangeSubscription);

	/// <summary>
	/// The <c>AuthzUnregisterSecurityEventSource</c> function unregisters a security event source with the Local Security Authority (LSA).
	/// </summary>
	/// <param name="dwFlags">This parameter is reserved for future use. Set this parameter to zero.</param>
	/// <param name="phEventProvider">A pointer to a handle to the security event source to unregister.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// This function deallocates any resources and closes any RPC connections associated with a previous call to the
	/// AuthzRegisterSecurityEventSource function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/nf-authz-authzunregistersecurityeventsource AUTHZAPI BOOL
	// AuthzUnregisterSecurityEventSource( DWORD dwFlags, PAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE phEventProvider );
	[DllImport(Lib.Authz, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("authz.h", MSDNShortId = "3ca3086b-f9c9-4305-aaf3-c41b5dba30ad")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AuthzUnregisterSecurityEventSource([Optional] uint dwFlags, in AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE phEventProvider);

	/// <summary>Provides a handle to an access check results.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct AUTHZ_ACCESS_CHECK_RESULTS_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_ACCESS_CHECK_RESULTS_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public AUTHZ_ACCESS_CHECK_RESULTS_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="AUTHZ_ACCESS_CHECK_RESULTS_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static AUTHZ_ACCESS_CHECK_RESULTS_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="AUTHZ_ACCESS_CHECK_RESULTS_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(AUTHZ_ACCESS_CHECK_RESULTS_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="AUTHZ_ACCESS_CHECK_RESULTS_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_ACCESS_CHECK_RESULTS_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(AUTHZ_ACCESS_CHECK_RESULTS_HANDLE h1, AUTHZ_ACCESS_CHECK_RESULTS_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(AUTHZ_ACCESS_CHECK_RESULTS_HANDLE h1, AUTHZ_ACCESS_CHECK_RESULTS_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is AUTHZ_ACCESS_CHECK_RESULTS_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// <para>The <c>AUTHZ_ACCESS_REQUEST</c> structure defines an access check request.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ns-authz-_authz_access_request typedef struct _AUTHZ_ACCESS_REQUEST {
	// ACCESS_MASK DesiredAccess; PSID PrincipalSelfSid; POBJECT_TYPE_LIST ObjectTypeList; DWORD ObjectTypeListLength; PVOID
	// OptionalArguments; } AUTHZ_ACCESS_REQUEST, *PAUTHZ_ACCESS_REQUEST;
	[PInvokeData("authz.h", MSDNShortId = "3748075c-b31a-4669-b8a6-1a540449d8fa")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AUTHZ_ACCESS_REQUEST
	{
		/// <summary>The type of access to test for.</summary>
		public ACCESS_MASK DesiredAccess;

		/// <summary>The security identifier (SID) to use for the principal self SID in the access control list (ACL).</summary>
		public PSID PrincipalSelfSid;

		/// <summary>
		/// An array of OBJECT_TYPE_LIST structures in the object tree for the object. Set to NULL unless the application checks access
		/// at the property level.
		/// </summary>
		public IntPtr ObjectTypeList;

		/// <summary>
		/// The number of elements in the ObjectTypeList array. This member is necessary only if the application checks access at the
		/// property level.
		/// </summary>
		public uint ObjectTypeListLength;

		/// <summary>A pointer to memory to pass to AuthzAccessCheckCallback when checking callback access control entries (ACEs).</summary>
		public IntPtr OptionalArguments;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_ACCESS_REQUEST"/> struct.</summary>
		/// <param name="access">The access.</param>
		public AUTHZ_ACCESS_REQUEST(ACCESS_MASK access) : this() => DesiredAccess = access;

		/// <summary>Gets or sets the object types.</summary>
		/// <value>The object types.</value>
		public OBJECT_TYPE_LIST[] ObjectTypes => ObjectTypeList.ToIEnum<IntPtr>((int)ObjectTypeListLength).Select(p => p.ToStructure<OBJECT_TYPE_LIST>()).ToArray();
	}

	/// <summary>Provides a handle to an Audit event.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct AUTHZ_AUDIT_EVENT_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_AUDIT_EVENT_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public AUTHZ_AUDIT_EVENT_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="AUTHZ_AUDIT_EVENT_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static AUTHZ_AUDIT_EVENT_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="AUTHZ_AUDIT_EVENT_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(AUTHZ_AUDIT_EVENT_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="AUTHZ_AUDIT_EVENT_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_AUDIT_EVENT_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(AUTHZ_AUDIT_EVENT_HANDLE h1, AUTHZ_AUDIT_EVENT_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(AUTHZ_AUDIT_EVENT_HANDLE h1, AUTHZ_AUDIT_EVENT_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is AUTHZ_AUDIT_EVENT_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a CAP change notification subscription handle.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>
		/// Returns an invalid handle by instantiating a <see cref="AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE"/> object with <see cref="IntPtr.Zero"/>.
		/// </summary>
		public static AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE h1, AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE h1, AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a client context.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct AUTHZ_CLIENT_CONTEXT_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public AUTHZ_CLIENT_CONTEXT_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static AUTHZ_CLIENT_CONTEXT_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(AUTHZ_CLIENT_CONTEXT_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_CLIENT_CONTEXT_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(AUTHZ_CLIENT_CONTEXT_HANDLE h1, AUTHZ_CLIENT_CONTEXT_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(AUTHZ_CLIENT_CONTEXT_HANDLE h1, AUTHZ_CLIENT_CONTEXT_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is AUTHZ_CLIENT_CONTEXT_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>The <c>AUTHZ_INIT_INFO</c> structure defines the initialization information for the resource manager.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ns-authz-_authz_init_info typedef struct _AUTHZ_INIT_INFO { USHORT
	// version; PCWSTR szResourceManagerName; PFN_AUTHZ_DYNAMIC_ACCESS_CHECK pfnDynamicAccessCheck; PFN_AUTHZ_COMPUTE_DYNAMIC_GROUPS
	// pfnComputeDynamicGroups; PFN_AUTHZ_FREE_DYNAMIC_GROUPS pfnFreeDynamicGroups; PFN_AUTHZ_GET_CENTRAL_ACCESS_POLICY
	// pfnGetCentralAccessPolicy; PFN_AUTHZ_FREE_CENTRAL_ACCESS_POLICY pfnFreeCentralAccessPolicy; } AUTHZ_INIT_INFO, *PAUTHZ_INIT_INFO;
	[PInvokeData("authz.h", MSDNShortId = "30489BE7-5B95-413E-8134-039AD3220A50")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AUTHZ_INIT_INFO
	{
		/// <summary>Highest supported version for this structure.</summary>
		public const ushort AUTHZ_INIT_INFO_VERSION_V1 = 1;

		/// <summary>
		/// The version of the authorization resource manager initialization information structure. This must be set to
		/// AUTHZ_INIT_INFO_VERSION_V1 (1).
		/// </summary>
		public ushort version;

		/// <summary>
		/// Pointer to a Unicode string that identifies the resource manager. This parameter can be <c>NULL</c> if the resource manager
		/// does not need a name.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string szResourceManagerName;

		/// <summary>
		/// Pointer to an AuthzAccessCheckCallback callback function that the resource manager calls each time it encounters a callback
		/// access control entry (ACE) during access control list (ACL) evaluation in AuthzAccessCheck or AuthzCachedAccessCheck. This
		/// parameter can be <c>NULL</c> if no access check callback function is used.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public AuthzAccessCheckCallback pfnDynamicAccessCheck;

		/// <summary>
		/// Pointer to the AuthzComputeGroupsCallback callback function called by the resource manager during initialization of an
		/// AuthzClientContext handle. This parameter can be <c>NULL</c> if no callback function is used to compute dynamic groups.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public AuthzComputeGroupsCallback pfnComputeDynamicGroups;

		/// <summary>
		/// Pointer to the AuthzFreeGroupsCallback callback function called by the resource manager to free security identifier (SID)
		/// attribute arrays allocated by the compute dynamic groups callback. This parameter can be <c>NULL</c> if no callback function
		/// is used to compute dynamic groups.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public AuthzFreeGroupsCallback pfnFreeDynamicGroups;

		/// <summary>
		/// Pointer to the AuthzGetCentralAccessPolicyCallback callback function to be called by the resource manager to resolve any
		/// Central Access Policy ID ACE (SYSTEM_SCOPED_POLICY_ID_ACE) encountered by AuthzAccessCheck or AuthzCachedAccessCheck. If this
		/// parameter is <c>NULL</c>, the <c>AuthzAccessCheck</c> function will fall back to LSA to resolve the Central Access Policy ID ACE.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public AuthzGetCentralAccessPolicyCallback pfnGetCentralAccessPolicy;

		/// <summary>
		/// Pointer to the AuthzFreeCentralAccessPolicyCallback callback function called by the resource manager to free the Central
		/// Access Policy allocated by the callback to get a central access policy. This parameter can be <c>NULL</c> if no callback
		/// function is specified for pfnGetCentralAccessPolicy
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public AuthzFreeCentralAccessPolicyCallback pfnFreeCentralAccessPolicy;
	}

	/// <summary>
	/// The <c>AUTHZ_REGISTRATION_OBJECT_TYPE_NAME_OFFSET</c> structure specifies the offset of a registration object type name.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ns-authz-authz_registration_object_type_name_offset typedef struct
	// _AUTHZ_REGISTRATION_OBJECT_TYPE_NAME_OFFSET { PWSTR szObjectTypeName; DWORD dwOffset; }
	// AUTHZ_REGISTRATION_OBJECT_TYPE_NAME_OFFSET, *PAUTHZ_REGISTRATION_OBJECT_TYPE_NAME_OFFSET;
	[PInvokeData("authz.h", MSDNShortId = "2ec39edc-7819-41a5-8798-dc51c00ba85e")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AUTHZ_REGISTRATION_OBJECT_TYPE_NAME_OFFSET
	{
		/// <summary>A pointer to a wide character string that represents the name of the object type.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string szObjectTypeName;

		/// <summary>Offset of the object type name in an object types message DLL.</summary>
		public uint dwOffset;
	}

	/// <summary>Provides a handle to a resource manager.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct AUTHZ_RESOURCE_MANAGER_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_RESOURCE_MANAGER_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public AUTHZ_RESOURCE_MANAGER_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="AUTHZ_RESOURCE_MANAGER_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static AUTHZ_RESOURCE_MANAGER_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="AUTHZ_RESOURCE_MANAGER_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(AUTHZ_RESOURCE_MANAGER_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="AUTHZ_RESOURCE_MANAGER_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_RESOURCE_MANAGER_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(AUTHZ_RESOURCE_MANAGER_HANDLE h1, AUTHZ_RESOURCE_MANAGER_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(AUTHZ_RESOURCE_MANAGER_HANDLE h1, AUTHZ_RESOURCE_MANAGER_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is AUTHZ_RESOURCE_MANAGER_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>The AUTHZ_RPC_INIT_INFO_CLIENT structure initializes a remote resource manager for a client.</summary>
	[PInvokeData("authz.h", MSDNShortId = "6859A0CB-F88E-42BF-A350-293D28E908DD")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AUTHZ_RPC_INIT_INFO_CLIENT
	{
		/// <summary>Highest supported version of the AUTHZ_RPC_INIT_INFO_CLIENT structure.</summary>
		public const ushort AUTHZ_RPC_INIT_INFO_CLIENT_VERSION_V1 = 1;

		/// <summary>Version of the structure. The highest currently supported version is AUTHZ_RPC_INIT_INFO_CLIENT_VERSION_V1.</summary>
		public ushort version;

		/// <summary>
		/// Null-terminated string representation of the resource manager UUID. Only the following values are valid.
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Use “5fc860e0-6f6e-4fc2-83cd-46324f25e90b” for remote effective access evaluation that ignores central policy.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Use “9a81c2bd-a525-471d-a4ed-49907c0b23da” for remote effective access evaluation that takes central policy into account.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ObjectUuid;

		/// <summary>
		/// Null-terminated string representation of a protocol sequence. This can be the following value.
		/// <list type="bullet">
		/// <item>
		/// <description>"ncacn_ip_tcp".</description>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ProtSeq;

		/// <summary>
		/// Null-terminated string representation of a network address. The network-address format is associated with the protocol sequence.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string NetworkAddr;

		/// <summary>
		/// Null-terminated string representation of an endpoint. The endpoint format and content are associated with the protocol
		/// sequence. For example, the endpoint associated with the protocol sequence ncacn_np is a pipe name in the format \\Pipe\PipeName.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Endpoint;

		/// <summary>
		/// Null-terminated string representation of network options. The option string is associated with the protocol sequence.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Options;

		/// <summary>
		/// Server Principal Name (SPN) of the server. If this member is missing, it is constructed from NetworkAddr assuming "host"
		/// service class.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ServerSpn;
	}

	/// <summary>
	/// <para>
	/// The <c>AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE</c> structure specifies a fully qualified binary name value associated with a security attribute.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ns-authz-_authz_security_attribute_fqbn_value typedef struct
	// _AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE { ULONG64 Version; PWSTR pName; } AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE, *PAUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE;
	[PInvokeData("authz.h", MSDNShortId = "05b4bf7d-a0d9-473c-b215-9cf566b2a996")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE
	{
		/// <summary>The version number of the structure.</summary>
		public ulong Version;

		/// <summary>
		/// A pointer to strings that specify the names of the publisher, the product, and the original binary file of the value.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pName;
	}

	/// <summary>
	/// <para>The <c>AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE</c> structure specifies an octet string value for a security attribute.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ns-authz-_authz_security_attribute_octet_string_value typedef struct
	// _AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE { PVOID pValue; ULONG ValueLength; } AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE, *PAUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE;
	[PInvokeData("authz.h", MSDNShortId = "aebe20d5-280f-45d3-a11d-279a08a1a165")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE
	{
		/// <summary>A pointer to the value.</summary>
		public IntPtr pValue;

		/// <summary>The length, in bytes, of the pValue member.</summary>
		public uint ValueLength;
	}

	/// <summary>
	/// <para>
	/// The <c>AUTHZ_SECURITY_ATTRIBUTE_V1</c> structure defines a security attribute that can be associated with an authorization context.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ns-authz-_authz_security_attribute_v1 typedef struct
	// _AUTHZ_SECURITY_ATTRIBUTE_V1 { PWSTR pName; USHORT ValueType; USHORT Reserved; ULONG Flags; ULONG ValueCount; union { PLONG64
	// pInt64; PULONG64 pUint64; PWSTR *ppString; PAUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE pFqbn;
	// PAUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE pOctetString; } Values; } AUTHZ_SECURITY_ATTRIBUTE_V1, *PAUTHZ_SECURITY_ATTRIBUTE_V1;
	[PInvokeData("authz.h", MSDNShortId = "0c4778bb-1b5d-4422-b066-d2a6aaa1f351")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AUTHZ_SECURITY_ATTRIBUTE_V1
	{
		/// <summary>A pointer to a name of a security attribute.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pName;

		/// <summary>The data type of the values pointed to by the Values member.</summary>
		public AUTHZ_SECURITY_ATTRIBUTE_DATATYPE ValueType;

		/// <summary>Reserved for future use.</summary>
		public ushort Reserved;

		/// <summary>A combination of one or more of the following values.</summary>
		public AUTHZ_SECURITY_ATTRIBUTE_FLAGS Flags;

		/// <summary>The number of values specified in the Values member.</summary>
		public uint ValueCount;

		/// <summary>A pointer to the value.</summary>
		public AUTHZ_SECURITY_ATTRIBUTE_V1_Union Values;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_SECURITY_ATTRIBUTE_V1"/> struct.</summary>
		/// <param name="name">The name.</param>
		/// <param name="values">The value.</param>
		public AUTHZ_SECURITY_ATTRIBUTE_V1(string? name, params long[] values) : this(name, AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_INT64, values.Length) => Values.pInt64 = values;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_SECURITY_ATTRIBUTE_V1"/> struct.</summary>
		/// <param name="name">The name.</param>
		/// <param name="values">The value.</param>
		public AUTHZ_SECURITY_ATTRIBUTE_V1(string? name, params ulong[] values) : this(name, AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_UINT64, values.Length) => Values.pUInt64 = values;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_SECURITY_ATTRIBUTE_V1"/> struct.</summary>
		/// <param name="name">The name.</param>
		/// <param name="values">The value.</param>
		public AUTHZ_SECURITY_ATTRIBUTE_V1(string? name, params bool[] values) : this(name, AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_BOOLEAN, values.Length) => Values.pInt64 = Array.ConvertAll(values, Convert.ToInt64);

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_SECURITY_ATTRIBUTE_V1"/> struct.</summary>
		/// <param name="name">The name.</param>
		/// <param name="values">The value.</param>
		public AUTHZ_SECURITY_ATTRIBUTE_V1(string? name, params string[] values) : this(name, AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_STRING, values.Length) => Values.ppString = values;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_SECURITY_ATTRIBUTE_V1"/> struct.</summary>
		/// <param name="name">The name.</param>
		/// <param name="values">The value.</param>
		public AUTHZ_SECURITY_ATTRIBUTE_V1(string? name, params AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE[] values) : this(name, AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_FQBN, values.Length) => Values.pFqbn = values;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_SECURITY_ATTRIBUTE_V1"/> struct.</summary>
		/// <param name="name">The name.</param>
		/// <param name="values">The value.</param>
		public AUTHZ_SECURITY_ATTRIBUTE_V1(string? name, params AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE[] values) : this(name, AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_OCTET_STRING, values.Length) => Values.pOctetString = values;

		private AUTHZ_SECURITY_ATTRIBUTE_V1(string? name, AUTHZ_SECURITY_ATTRIBUTE_DATATYPE type, int count) : this()
		{
			pName = name;
			ValueType = type;
			ValueCount = (uint)count;
		}

		/// <summary>Union.</summary>
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct AUTHZ_SECURITY_ATTRIBUTE_V1_Union
		{
			/// <summary>A pointer to one or more numeric attribute values.</summary>
			[FieldOffset(0)] public long[] pInt64;

			/// <summary>A pointer to one or more numeric attribute values.</summary>
			[FieldOffset(0)] public ulong[] pUInt64;

			/// <summary>A pointer to one or more string attribute values.</summary>
			[FieldOffset(0)] public string[] ppString;

			/// <summary>A pointer to one or more AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE structures.</summary>
			[FieldOffset(0)] public AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE[] pFqbn;

			/// <summary>A pointer to one or more AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE structures.</summary>
			[FieldOffset(0)] public AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE[] pOctetString;
		}
	}

	/// <summary>Provides a handle to the registered security event source.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>
		/// Returns an invalid handle by instantiating a <see cref="AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE"/> object with <see cref="IntPtr.Zero"/>.
		/// </summary>
		public static AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE h1, AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE h1, AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>The <c>AUTHZ_SOURCE_SCHEMA_REGISTRATION</c> structure specifies information about source schema registration.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ns-authz-_authz_source_schema_registration typedef struct
	// _AUTHZ_SOURCE_SCHEMA_REGISTRATION { DWORD dwFlags; PWSTR szEventSourceName; PWSTR szEventMessageFile; PWSTR
	// szEventSourceXmlSchemaFile; PWSTR szEventAccessStringsFile; PWSTR szExecutableImagePath; union { PVOID pReserved; GUID
	// *pProviderGuid; } DUMMYUNIONNAME; DWORD dwObjectTypeNameCount; AUTHZ_REGISTRATION_OBJECT_TYPE_NAME_OFFSET
	// ObjectTypeNames[ANYSIZE_ARRAY]; } AUTHZ_SOURCE_SCHEMA_REGISTRATION, *PAUTHZ_SOURCE_SCHEMA_REGISTRATION;
	[PInvokeData("authz.h", MSDNShortId = "8b4d6e14-fb9c-428a-bd94-34eba668edc6")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<AUTHZ_SOURCE_SCHEMA_REGISTRATION>), nameof(dwObjectTypeNameCount))]
	public class AUTHZ_SOURCE_SCHEMA_REGISTRATION
	{
		/// <summary>
		/// <para>Flags that control the behavior of the operation. The following table shows a possible value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AUTHZ_ALLOW_MULTIPLE_SOURCE_INSTANCES 0x1</term>
		/// <term>
		/// Allows registration of multiple sources with the same name. Use of this flag means that more than one source can call the
		/// AuthzRegisterSecurityEventSource function with the same szEventSourceName at runtime.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUTHZ_MIGRATED_LEGACY_PUBLISHER 0x2</term>
		/// <term>
		/// The caller is a migrated publisher that has registered a manifest with WEvtUtil.exe. The GUID of the provider specified by
		/// the pProviderGuid member is stored in the registry.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SOURCE_SCHEMA_REGISTRATION_FLAGS dwFlags;

		/// <summary>A pointer to a wide character string that represents the name of the event source.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? szEventSourceName;

		/// <summary>A pointer to a wide character string that represents the name of the resource that contains the event messages.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? szEventMessageFile;

		/// <summary>A pointer to a wide character string that represents the name of the XML schema file for the event source.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? szEventSourceXmlSchemaFile;

		/// <summary>
		/// A pointer to a wide character string that represents the name of the resource that contains the event parameter strings.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? szEventAccessStringsFile;

		/// <summary>This member is reserved and must be set to <c>NULL</c>.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? szExecutableImagePath;

		/// <summary>
		/// The GUID of a migrated publisher. The value of this member is converted to a string and stored in the registry if the caller
		/// is a migrated publisher.
		/// </summary>
		public GuidPtr pProviderGuid;

		/// <summary>The number of objects in the ObjectTypeNames array.</summary>
		public uint dwObjectTypeNameCount;

		/// <summary>An array of AUTHZ_REGISTRATION_OBJECT_TYPE_NAME_OFFSET structures that represents the object types for the events.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public AUTHZ_REGISTRATION_OBJECT_TYPE_NAME_OFFSET[]? ObjectTypeNames;
	}

	/// <summary>
	/// <para>The <c>AUTHZ_ACCESS_REPLY</c> structure defines an access check reply.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ns-authz-_authz_access_reply typedef struct _AUTHZ_ACCESS_REPLY { DWORD
	// ResultListLength; PACCESS_MASK GrantedAccessMask; PDWORD SaclEvaluationResults; PDWORD Error; } AUTHZ_ACCESS_REPLY, *PAUTHZ_ACCESS_REPLY;
	[PInvokeData("authz.h", MSDNShortId = "7162bf80-3730-46d7-a603-2a55b969c9ba")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public sealed class AUTHZ_ACCESS_REPLY : IDisposable
	{
		/// <summary>
		/// The number of elements in the GrantedAccessMask, SaclEvaluationResults, and Error arrays. This number matches the number of
		/// entries in the object type list structure used in the access check. If no object type is used to represent the object, then
		/// set ResultListLength to one.
		/// </summary>
		public int ResultListLength;

		/// <summary>An array of granted access masks. Memory for this array is allocated by the application before calling AccessCheck.</summary>
		public IntPtr GrantedAccessMask;

		/// <summary>
		/// An array of system access control list (SACL) evaluation results. Memory for this array is allocated by the application
		/// before calling AccessCheck. SACL evaluation will only be performed if auditing is requested.
		/// </summary>
		public IntPtr SaclEvaluationResults;

		/// <summary>
		/// An array of results for each element of the array. Memory for this array is allocated by the application before calling AccessCheck.
		/// </summary>
		public IntPtr Error;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_ACCESS_REPLY"/> struct.</summary>
		/// <param name="count">The count of array members in each of the three arrays.</param>
		public AUTHZ_ACCESS_REPLY(uint count)
		{
			if (count == 0) return;
			ResultListLength = (int)count;
			var sz = Marshal.SizeOf(typeof(uint)) * (int)count;
			GrantedAccessMask = Marshal.AllocHGlobal(sz);
			SaclEvaluationResults = Marshal.AllocHGlobal(sz);
			Error = Marshal.AllocHGlobal(sz);
		}

		/// <summary>Gets or sets the granted access mask values. The length of this array must match the value in <see cref="ResultListLength"/>.</summary>
		/// <value>The granted access mask values.</value>
		public uint[] GrantedAccessMaskValues
		{
			get => GrantedAccessMask != IntPtr.Zero && ResultListLength > 0 ? GrantedAccessMask.ToArray<uint>(ResultListLength)! : new uint[0];
			set
			{
				if (value.Length != ResultListLength)
					throw new ArgumentOutOfRangeException(nameof(GrantedAccessMaskValues), $"Number of items must match value of {nameof(ResultListLength)} field.");
				Marshal.FreeHGlobal(GrantedAccessMask);
				if (ResultListLength == 0)
					GrantedAccessMask = IntPtr.Zero;
				else
					CopyArrayToPtr(value, GrantedAccessMask);
			}
		}

		private static void CopyArrayToPtr(uint[] items, IntPtr ptr) => ptr = items.MarshalToPtr(Marshal.AllocHGlobal, out _);

		/// <summary>
		/// Gets or sets the system access control list (SACL) evaluation results values. The length of this array must match the value
		/// in <see cref="ResultListLength"/>.
		/// </summary>
		/// <value>The system access control list (SACL) evaluation results values.</value>
		public uint[] SaclEvaluationResultsValues
		{
			get => SaclEvaluationResults != IntPtr.Zero && ResultListLength > 0
					? SaclEvaluationResults.ToArray<uint>(ResultListLength)!
					: new uint[0];
			set
			{
				if (value.Length != ResultListLength)
					throw new ArgumentOutOfRangeException(nameof(SaclEvaluationResultsValues), $"Number of items must match value of {nameof(ResultListLength)} field.");
				Marshal.FreeHGlobal(SaclEvaluationResults);
				if (ResultListLength == 0)
					SaclEvaluationResults = IntPtr.Zero;
				else
					CopyArrayToPtr(value, SaclEvaluationResults);
			}
		}

		/// <summary>Gets or sets the results for each element of the array. The length of this array must match the value in <see cref="ResultListLength"/>.</summary>
		/// <value>The results values.</value>
		public uint[] ErrorValues
		{
			get => Error != IntPtr.Zero && ResultListLength > 0 ? Error.ToArray<uint>(ResultListLength)! : new uint[0];
			set
			{
				if (value.Length != ResultListLength)
					throw new ArgumentOutOfRangeException(nameof(ErrorValues), $"Number of items must match value of {nameof(ResultListLength)} field.");
				Marshal.FreeHGlobal(Error);
				if (ResultListLength == 0)
					Error = IntPtr.Zero;
				else
					CopyArrayToPtr(value, Error);
			}
		}

		void IDisposable.Dispose()
		{
			Marshal.FreeHGlobal(GrantedAccessMask);
			Marshal.FreeHGlobal(SaclEvaluationResults);
			Marshal.FreeHGlobal(Error);
			ResultListLength = 0;
		}
	}

	/// <summary>
	/// <para>The <c>AUTHZ_SECURITY_ATTRIBUTES_INFORMATION</c> structure specifies one or more security attributes.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/authz/ns-authz-_authz_security_attributes_information typedef struct
	// _AUTHZ_SECURITY_ATTRIBUTES_INFORMATION { USHORT Version; USHORT Reserved; ULONG AttributeCount; union {
	// PAUTHZ_SECURITY_ATTRIBUTE_V1 pAttributeV1; } Attribute; } AUTHZ_SECURITY_ATTRIBUTES_INFORMATION, *PAUTHZ_SECURITY_ATTRIBUTES_INFORMATION;
	[PInvokeData("authz.h", MSDNShortId = "1db95ab0-951f-488c-b522-b3f38fc74c7c")]
	public class AUTHZ_SECURITY_ATTRIBUTES_INFORMATION
	{
		/// <summary>The number of attributes specified by the Attribute member.</summary>
		public uint AttributeCount;

		/// <summary>An array of AUTHZ_SECURITY_ATTRIBUTE_V1 structures of the length of the AttributeCount member.</summary>
		public AUTHZ_SECURITY_ATTRIBUTE_V1[] pAttributeV1;

		/// <summary>Reserved. Do not use.</summary>
		public ushort Reserved;

		/// <summary>The version of this structure. Currently the only value supported is 1.</summary>
		public ushort Version;

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_SECURITY_ATTRIBUTES_INFORMATION"/> class.</summary>
		/// <param name="attributes">The attributes.</param>
		public AUTHZ_SECURITY_ATTRIBUTES_INFORMATION(AUTHZ_SECURITY_ATTRIBUTE_V1[]? attributes)
		{
			Version = 1;
			Reserved = 0;
			AttributeCount = (uint)(attributes?.Length ?? 0);
			pAttributeV1 = attributes ?? new AUTHZ_SECURITY_ATTRIBUTE_V1[0];
		}

		/// <summary>Create a AUTHZ_SECURITY_ATTRIBUTES_INFORMATION from a pointer.</summary>
		/// <param name="ptr">The pointer to a block of memory.</param>
		/// <returns>A AUTHZ_SECURITY_ATTRIBUTES_INFORMATION instance.</returns>
		public static AUTHZ_SECURITY_ATTRIBUTES_INFORMATION FromPtr(IntPtr ptr) => (AUTHZ_SECURITY_ATTRIBUTES_INFORMATION)AUTHZ_SECURITY_ATTRIBUTES_INFORMATION_Marshaler.GetInstance(null).MarshalNativeToManaged(ptr);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to a check results value that releases a created AUTHZ_ACCESS_CHECK_RESULTS_HANDLE instance
	/// at disposal using AuthzFreeHandle.
	/// </summary>
	public class SafeAUTHZ_ACCESS_CHECK_RESULTS_HANDLE : SafeHANDLE
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AUTHZ_ACCESS_CHECK_RESULTS_HANDLE"/> class and assigns an existing handle.
		/// </summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeAUTHZ_ACCESS_CHECK_RESULTS_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_ACCESS_CHECK_RESULTS_HANDLE"/> class.</summary>
		private SafeAUTHZ_ACCESS_CHECK_RESULTS_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeAUTHZ_ACCESS_CHECK_RESULTS_HANDLE"/> to <see cref="AUTHZ_ACCESS_CHECK_RESULTS_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_ACCESS_CHECK_RESULTS_HANDLE(SafeAUTHZ_ACCESS_CHECK_RESULTS_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => AuthzFreeHandle(this);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to an audit event that releases a created AUTHZ_AUDIT_EVENT_HANDLE instance at disposal using AuthzFreeAuditEvent.
	/// </summary>
	public class SafeAUTHZ_AUDIT_EVENT_HANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="AUTHZ_AUDIT_EVENT_HANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeAUTHZ_AUDIT_EVENT_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="AUTHZ_AUDIT_EVENT_HANDLE"/> class.</summary>
		private SafeAUTHZ_AUDIT_EVENT_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeAUTHZ_AUDIT_EVENT_HANDLE"/> to <see cref="AUTHZ_AUDIT_EVENT_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_AUDIT_EVENT_HANDLE(SafeAUTHZ_AUDIT_EVENT_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => AuthzFreeAuditEvent(this);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> for <see cref="AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE"/> that is disposed using <see cref="AuthzUnregisterCapChangeNotification"/>.
	/// </summary>
	public class SafeAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE : SafeHANDLE
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SafeAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE"/> class and assigns an existing handle.
		/// </summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE"/> class.</summary>
		private SafeAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE"/> to <see cref="AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE(SafeAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => AuthzUnregisterCapChangeNotification(this);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/> that is disposed using <see cref="AuthzFreeContext"/>.</summary>
	public class SafeAUTHZ_CLIENT_CONTEXT_HANDLE : SafeHANDLE
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SafeAUTHZ_CLIENT_CONTEXT_HANDLE"/> class and assigns an existing handle.
		/// </summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeAUTHZ_CLIENT_CONTEXT_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeAUTHZ_CLIENT_CONTEXT_HANDLE"/> class.</summary>
		private SafeAUTHZ_CLIENT_CONTEXT_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeAUTHZ_CLIENT_CONTEXT_HANDLE"/> to <see cref="AUTHZ_CLIENT_CONTEXT_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_CLIENT_CONTEXT_HANDLE(SafeAUTHZ_CLIENT_CONTEXT_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => AuthzFreeContext(this);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="AUTHZ_RESOURCE_MANAGER_HANDLE"/> that is disposed using <see cref="AuthzFreeResourceManager"/>.</summary>
	public class SafeAUTHZ_RESOURCE_MANAGER_HANDLE : SafeHANDLE
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SafeAUTHZ_RESOURCE_MANAGER_HANDLE"/> class and assigns an existing handle.
		/// </summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeAUTHZ_RESOURCE_MANAGER_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeAUTHZ_RESOURCE_MANAGER_HANDLE"/> class.</summary>
		private SafeAUTHZ_RESOURCE_MANAGER_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeAUTHZ_RESOURCE_MANAGER_HANDLE"/> to <see cref="AUTHZ_RESOURCE_MANAGER_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_RESOURCE_MANAGER_HANDLE(SafeAUTHZ_RESOURCE_MANAGER_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => AuthzFreeResourceManager(this);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> for <see cref="AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE"/> that is disposed using <see cref="AuthzUnregisterSecurityEventSource"/>.
	/// </summary>
	public class SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE : SafeHANDLE
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE"/> class and assigns an existing handle.
		/// </summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE"/> class.</summary>
		private SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE"/> to <see cref="AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator AUTHZ_SECURITY_EVENT_PROVIDER_HANDLE(SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => AuthzUnregisterSecurityEventSource(0, this);
	}

	internal class AUTHZ_SECURITY_ATTRIBUTES_INFORMATION_Marshaler : ICustomMarshaler
	{
		public static ICustomMarshaler GetInstance(string? _) => new AUTHZ_SECURITY_ATTRIBUTES_INFORMATION_Marshaler();

		public void CleanUpManagedData(object ManagedObj)
		{
		}

		public void CleanUpNativeData(IntPtr pNativeData) => Marshal.FreeHGlobal(pNativeData);

		public int GetNativeDataSize() => -1;

		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			// Determine size
			if (ManagedObj is not AUTHZ_SECURITY_ATTRIBUTES_INFORMATION attrInfo) throw new InvalidOperationException("This marshaler only works on AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structures.");
			var sz1 = Marshal.SizeOf(typeof(Internal_AUTHZ_SECURITY_ATTRIBUTES_INFORMATION)) +
					 attrInfo.AttributeCount * Marshal.SizeOf(typeof(Internal_AUTHZ_SECURITY_ATTRIBUTE_V1));
			var sz2 = 0L;
			for (var i = 0; i < attrInfo.AttributeCount; i++)
			{
				var v1 = attrInfo.pAttributeV1[i];
				if (string.IsNullOrEmpty(v1.pName))
					throw new InvalidOperationException("Every instance of AUTHZ_SECURITY_ATTRIBUTE_V1 in the AUTHZ_SECURITY_ATTRIBUTES_INFORMATION.Values field must have a valid string for pName.");
				sz2 += ((v1.pName?.Length ?? 0) + 1) * 2;
				switch (v1.ValueType)
				{
					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_BOOLEAN:
					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_INT64:
					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_UINT64:
						sz2 += Marshal.SizeOf(typeof(long)) * v1.ValueCount;
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_STRING:
						foreach (var s in v1.Values.ppString)
							sz2 += (s.Length + 1) * 2 + IntPtr.Size;
						sz2 += IntPtr.Size;
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_FQBN:
						foreach (var s in v1.Values.pFqbn)
							sz2 += (s.pName.Length + 1) * 2 + Marshal.SizeOf(s.Version);
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_OCTET_STRING:
						foreach (var s in v1.Values.pOctetString)
							sz2 += s.ValueLength + Marshal.SizeOf(s.ValueLength);
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_SID:
					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_INVALID:
					default:
						throw new InvalidOperationException(
							"An instance of AUTHZ_SECURITY_ATTRIBUTE_V1 in the AUTHZ_SECURITY_ATTRIBUTES_INFORMATION.Values has an invalid data type.");
				}
			}

			// Pack it all behind a pointer
			var retPtr = Marshal.AllocHGlobal((int)(sz1 + sz2));
#pragma warning disable CS0618 // Type or member is obsolete
			var ms = new MarshalingStream(retPtr, (int)sz1);
			var ms2 = new MarshalingStream(retPtr.Offset(sz1), (int)sz2);
#pragma warning restore CS0618 // Type or member is obsolete
			var iV1s = new Internal_AUTHZ_SECURITY_ATTRIBUTE_V1[attrInfo.AttributeCount];
			for (var i = 0; i < attrInfo.AttributeCount; i++)
			{
				iV1s[i] = new Internal_AUTHZ_SECURITY_ATTRIBUTE_V1(attrInfo.pAttributeV1[i]) { pName = ms2.PositionPtr };
				ms2.Write(attrInfo.pAttributeV1[i].pName);
				iV1s[i].Values = ms2.PositionPtr;
				switch (iV1s[i].ValueType)
				{
					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_BOOLEAN:
					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_INT64:
						ms2.Write(attrInfo.pAttributeV1[i].Values.pInt64);
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_UINT64:
						ms2.Write(attrInfo.pAttributeV1[i].Values.pUInt64);
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_STRING:
						ms2.Write(attrInfo.pAttributeV1[i].Values.ppString);
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_FQBN:
						ms2.Write(attrInfo.pAttributeV1[i].Values.pFqbn);
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_OCTET_STRING:
						ms2.Write(attrInfo.pAttributeV1[i].Values.pOctetString);
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			var iInfo = new Internal_AUTHZ_SECURITY_ATTRIBUTES_INFORMATION
			{
				AttributeCount = attrInfo.AttributeCount,
				Version = attrInfo.Version
			};
			ms.Write(iInfo);
			if (attrInfo.AttributeCount > 0)
			{
				ms.Poke(ms.PositionPtr, Marshal.OffsetOf(typeof(Internal_AUTHZ_SECURITY_ATTRIBUTES_INFORMATION), "pAttributeV1").ToInt64());
				ms.Write(iV1s);
			}
			return retPtr;
		}

		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero) return new ();
			var attrInfo = pNativeData.ToStructure<Internal_AUTHZ_SECURITY_ATTRIBUTES_INFORMATION>();
			return new AUTHZ_SECURITY_ATTRIBUTES_INFORMATION(attrInfo.pAttributeV1 == IntPtr.Zero ? null :
				Array.ConvertAll(attrInfo.pAttributeV1.ToArray<Internal_AUTHZ_SECURITY_ATTRIBUTE_V1>((int)attrInfo.AttributeCount)!, Conv));

			static AUTHZ_SECURITY_ATTRIBUTE_V1 Conv(Internal_AUTHZ_SECURITY_ATTRIBUTE_V1 input)
			{
				var v1 = new AUTHZ_SECURITY_ATTRIBUTE_V1 { pName = (string?)input.pName ?? "", Flags = input.Flags, ValueCount = input.ValueCount, ValueType = input.ValueType };
				switch (v1.ValueType)
				{
					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_BOOLEAN:
					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_INT64:
						v1.Values.pInt64 = input.Values.ToArray<long>((int)v1.ValueCount) ?? new long[0];
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_UINT64:
						v1.Values.pUInt64 = input.Values.ToArray<ulong>((int)v1.ValueCount) ?? new ulong[0];
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_STRING:
						v1.Values.ppString = input.Values.ToStringEnum((int)v1.ValueCount, CharSet.Unicode).Select(s => s ?? "").ToArray();
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_FQBN:
						v1.Values.pFqbn = input.Values.ToArray<AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE>((int)v1.ValueCount) ?? new AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE[0];
						break;

					case AUTHZ_SECURITY_ATTRIBUTE_DATATYPE.AUTHZ_SECURITY_ATTRIBUTE_TYPE_OCTET_STRING:
						v1.Values.pOctetString = input.Values.ToArray<AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE>((int)v1.ValueCount) ?? new AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE[0];
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
				return v1;
			}
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct Internal_AUTHZ_SECURITY_ATTRIBUTE_V1
		{
			/// <summary>A pointer to a name of a security attribute.</summary>
			public StrPtrUni pName;

			/// <summary>The data type of the values pointed to by the Values member.</summary>
			public AUTHZ_SECURITY_ATTRIBUTE_DATATYPE ValueType;

			/// <summary>Reserved for future use.</summary>
			public ushort Reserved;

			/// <summary>A combination of one or more of the following values.</summary>
			public AUTHZ_SECURITY_ATTRIBUTE_FLAGS Flags;

			/// <summary>The number of values specified in the Values member.</summary>
			public uint ValueCount;

			/// <summary>A pointer to the value.</summary>
			public IntPtr Values;

			public Internal_AUTHZ_SECURITY_ATTRIBUTE_V1(AUTHZ_SECURITY_ATTRIBUTE_V1 v1) : this()
			{
				ValueType = v1.ValueType;
				Flags = v1.Flags;
				ValueCount = v1.ValueCount;
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct Internal_AUTHZ_SECURITY_ATTRIBUTES_INFORMATION
		{
			/// <summary>The version of this structure. Currently the only value supported is 1.</summary>
			public ushort Version;

			/// <summary>Reserved. Do not use.</summary>
			public ushort Reserved;

			/// <summary>The number of attributes specified by the Attribute member.</summary>
			public uint AttributeCount;

			/// <summary>An array of AUTHZ_SECURITY_ATTRIBUTE_V1 structures of the length of the AttributeCount member.</summary>
			public IntPtr pAttributeV1;
		}
	}
}