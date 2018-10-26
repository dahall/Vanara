using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// The <c>GetAppContainerNamedObjectPath</c> function retrieves the named object path for the app container. Each app container has its own named object path.
		/// </summary>
		/// <param name="Token">
		/// A handle pertaining to the token. If <c>NULL</c> is passed in and no AppContainerSid parameter is passed in, the caller's current process token is
		/// used, or the thread token if impersonating.
		/// </param>
		/// <param name="AppContainerSid">The SID of the app container.</param>
		/// <param name="ObjectPathLength">The length of the buffer.</param>
		/// <param name="ObjectPath">Buffer that is filled with the named object path.</param>
		/// <param name="ReturnLength">Returns the length required to accommodate the length of the named object path.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns a value of <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns a value of <c>FALSE</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL GetAppContainerNamedObjectPath( _In_opt_ HANDLE Token, _In_opt_ PSID AppContainerSid, _In_ ULONG ObjectPathLength, _Out_opt_ LPWSTR ObjectPath, _Out_ PULONG ReturnLength);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/hh448493(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Securityappcontainer.h", MSDNShortId = "hh448493")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetAppContainerNamedObjectPath([Optional] HTOKEN Token, IntPtr AppContainerSid, uint ObjectPathLength, StringBuilder ObjectPath, out uint ReturnLength);
	}
}