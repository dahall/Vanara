using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>The OpenProcessToken function opens the access token associated with a process.</summary>
		/// <param name="ProcessHandle">
		/// A handle to the process whose access token is opened. The process must have the PROCESS_QUERY_INFORMATION access permission.
		/// </param>
		/// <param name="DesiredAccess">
		/// Specifies an access mask that specifies the requested types of access to the access token. These requested access types are
		/// compared with the discretionary access control list (DACL) of the token to determine which accesses are granted or denied.
		/// </param>
		/// <param name="TokenHandle">A pointer to a handle that identifies the newly opened access token when the function returns.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "aa379295")]
		public static extern bool OpenProcessToken([In] HPROCESS ProcessHandle, TokenAccess DesiredAccess, out SafeHTOKEN TokenHandle);

		/// <summary>The <c>OpenThreadToken</c> function opens the access token associated with a thread.</summary>
		/// <param name="ThreadHandle">A handle to the thread whose access token is opened.</param>
		/// <param name="DesiredAccess">
		/// <para>
		/// Specifies an access mask that specifies the requested types of access to the access token. These requested access types are
		/// reconciled against the token's discretionary access control list (DACL) to determine which accesses are granted or denied.
		/// </para>
		/// <para>For a list of access rights for access tokens, see Access Rights for Access-Token Objects.</para>
		/// </param>
		/// <param name="OpenAsSelf">
		/// <para>TRUE if the access check is to be made against the process-level security context.</para>
		/// <para>
		/// <c>FALSE</c> if the access check is to be made against the current security context of the thread calling the
		/// <c>OpenThreadToken</c> function.
		/// </para>
		/// <para>
		/// The OpenAsSelf parameter allows the caller of this function to open the access token of a specified thread when the caller is
		/// impersonating a token at <c>SecurityIdentification</c> level. Without this parameter, the calling thread cannot open the access
		/// token on the specified thread because it is impossible to open executive-level objects by using the <c>SecurityIdentification</c>
		/// impersonation level.
		/// </para>
		/// </param>
		/// <param name="TokenHandle">A pointer to a variable that receives the handle to the newly opened access token.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. If the token has
		/// the anonymous impersonation level, the token will not be opened and <c>OpenThreadToken</c> sets ERROR_CANT_OPEN_ANONYMOUS as the error.
		/// </para>
		/// </returns>
		// BOOL WINAPI OpenThreadToken( _In_ HANDLE ThreadHandle, _In_ DWORD DesiredAccess, _In_ BOOL OpenAsSelf, _Out_ PHANDLE TokenHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/aa379296(v=vs.85).aspx
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "aa379296")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool OpenThreadToken([In] HTHREAD ThreadHandle, TokenAccess DesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool OpenAsSelf, out SafeHTOKEN TokenHandle);

		/// <summary>
		/// The <c>SetThreadToken</c> function assigns an impersonation token to a thread. The function can also cause a thread to stop using
		/// an impersonation token.
		/// </summary>
		/// <param name="Thread">
		/// <para>A pointer to a handle to the thread to which the function assigns the impersonation token.</para>
		/// <para>If Thread is <c>NULL</c>, the function assigns the impersonation token to the calling thread.</para>
		/// </param>
		/// <param name="Token">
		/// <para>
		/// A handle to the impersonation token to assign to the thread. This handle must have been opened with TOKEN_IMPERSONATE access
		/// rights. For more information, see Access Rights for Access-Token Objects.
		/// </para>
		/// <para>If Token is <c>NULL</c>, the function causes the thread to stop using an impersonation token.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetThreadToken( _In_opt_ PHANDLE Thread, _In_opt_ HANDLE Token); https://msdn.microsoft.com/en-us/library/windows/desktop/aa379590(v=vs.85).aspx
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "aa379590")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadToken(in HTHREAD Thread, [Optional] HTOKEN Token);

		/// <summary>
		/// The <c>SetThreadToken</c> function assigns an impersonation token to a thread. The function can also cause a thread to stop using
		/// an impersonation token.
		/// </summary>
		/// <param name="Thread">
		/// <para>A pointer to a handle to the thread to which the function assigns the impersonation token.</para>
		/// <para>If Thread is <c>NULL</c>, the function assigns the impersonation token to the calling thread.</para>
		/// </param>
		/// <param name="Token">
		/// <para>
		/// A handle to the impersonation token to assign to the thread. This handle must have been opened with TOKEN_IMPERSONATE access
		/// rights. For more information, see Access Rights for Access-Token Objects.
		/// </para>
		/// <para>If Token is <c>NULL</c>, the function causes the thread to stop using an impersonation token.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetThreadToken( _In_opt_ PHANDLE Thread, _In_opt_ HANDLE Token); https://msdn.microsoft.com/en-us/library/windows/desktop/aa379590(v=vs.85).aspx
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "aa379590")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadToken([Optional] IntPtr Thread, [Optional] HTOKEN Token);
	}
}