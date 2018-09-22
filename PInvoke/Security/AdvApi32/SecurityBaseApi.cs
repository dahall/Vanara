using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>
		/// <para>
		/// The <c>ImpersonateLoggedOnUser</c> function lets the calling thread impersonate the security context of a logged-on user. The
		/// user is represented by a token handle.
		/// </para>
		/// </summary>
		/// <param name="hToken">
		/// <para>
		/// A handle to a primary or impersonation access token that represents a logged-on user. This can be a token handle returned by a
		/// call to LogonUser, CreateRestrictedToken, DuplicateToken, DuplicateTokenEx, OpenProcessToken, or OpenThreadToken functions. If
		/// hToken is a handle to a primary token, the token must have <c>TOKEN_QUERY</c> and <c>TOKEN_DUPLICATE</c> access. If hToken is a
		/// handle to an impersonation token, the token must have <c>TOKEN_QUERY</c> and <c>TOKEN_IMPERSONATE</c> access.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The impersonation lasts until the thread exits or until it calls RevertToSelf.</para>
		/// <para>The calling thread does not need to have any particular privileges to call <c>ImpersonateLoggedOnUser</c>.</para>
		/// <para>
		/// If the call to <c>ImpersonateLoggedOnUser</c> fails, the client connection is not impersonated and the client request is made in
		/// the security context of the process. If the process is running as a highly privileged account, such as LocalSystem, or as a
		/// member of an administrative group, the user may be able to perform actions they would otherwise be disallowed. Therefore, it is
		/// important to always check the return value of the call, and if it fails, raise an error; do not continue execution of the client request.
		/// </para>
		/// <para>
		/// All impersonate functions, including <c>ImpersonateLoggedOnUser</c> allow the requested impersonation if one of the following is true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The requested impersonation level of the token is less than <c>SecurityImpersonation</c>, such as <c>SecurityIdentification</c>
		/// or <c>SecurityAnonymous</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The caller has the <c>SeImpersonatePrivilege</c> privilege.</term>
		/// </item>
		/// <item>
		/// <term>
		/// A process (or another process in the caller's logon session) created the token using explicit credentials through LogonUser or
		/// LsaLogonUser function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The authenticated identity is same as the caller.</term>
		/// </item>
		/// </list>
		/// <para><c>Windows XP with SP1 and earlier:</c> The <c>SeImpersonatePrivilege</c> privilege is not supported.</para>
		/// <para>For more information about impersonation, see Client Impersonation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-impersonateloggedonuser
		// BOOL ImpersonateLoggedOnUser( HANDLE hToken );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "cf5c31ae-6749-45c2-888f-697060cc8c75")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ImpersonateLoggedOnUser(SafeHTOKEN hToken);
	}
}
