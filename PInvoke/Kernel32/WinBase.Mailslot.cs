using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Waits forever for a message.</summary>
		public const uint MAILSLOT_WAIT_FOREVER = unchecked((uint)-1);

		/// <summary>
		/// Creates a mailslot with the specified name and returns a handle that a mailslot server can use to perform operations on the
		/// mailslot. The mailslot is local to the computer that creates it. An error occurs if a mailslot with the specified name already exists.
		/// </summary>
		/// <param name="lpName">
		/// <para>The name of the mailslot. This name must have the following form:</para>
		/// <para>\\.\mailslot\[path]name</para>
		/// <para>
		/// The name field must be unique. The name may include multiple levels of pseudo directories separated by backslashes. For example,
		/// both \\.\mailslot\example_mailslot_name and \\.\mailslot\abc\def\ghi are valid names.
		/// </para>
		/// </param>
		/// <param name="nMaxMessageSize">
		/// The maximum size of a single message that can be written to the mailslot, in bytes. To specify that the message can be of any
		/// size, set this value to zero.
		/// </param>
		/// <param name="lReadTimeout">
		/// <para>
		/// The time a read operation can wait for a message to be written to the mailslot before a time-out occurs, in milliseconds. The
		/// following values have special meanings.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Returns immediately if no message is present. (The system does not treat an immediate return as an error.)</term>
		/// </item>
		/// <item>
		/// <term>MAILSLOT_WAIT_FOREVER((DWORD)-1)</term>
		/// <term>Waits forever for a message.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>This time-out value applies to all subsequent read operations and all inherited mailslot handles.</para>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. The <c>bInheritHandle</c> member of the structure determines whether the
		/// returned handle can be inherited by child processes. If lpSecurityAttributes is <c>NULL</c>, the handle cannot be inherited.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a handle to the mailslot, for use in server mailslot operations. The handle
		/// returned by this function is asynchronous, or overlapped.
		/// </para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI CreateMailslot( _In_ LPCTSTR lpName, _In_ DWORD nMaxMessageSize, _In_ DWORD lReadTimeout, _In_opt_
		// LPSECURITY_ATTRIBUTES lpSecurityAttributes); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365147(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa365147")]
		public static extern SafeMailslotHandle CreateMailslot(string lpName, uint nMaxMessageSize, uint lReadTimeout, [In] SECURITY_ATTRIBUTES lpSecurityAttributes);

		/// <summary>Retrieves information about the specified mailslot.</summary>
		/// <param name="hMailslot">A handle to a mailslot. The <c>CreateMailslot</c> function must create this handle.</param>
		/// <param name="lpMaxMessageSize">
		/// The maximum message size, in bytes, allowed for this mailslot. This value can be greater than or equal to the value specified in
		/// the cbMaxMsg parameter of the <c>CreateMailslot</c> function that created the mailslot. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="lpNextSize">
		/// <para>The size of the next message, in bytes. The following value has special meaning.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MAILSLOT_NO_MESSAGE((DWORD)-1)</term>
		/// <term>There is no next message.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="lpMessageCount">
		/// The total number of messages waiting to be read, when the function returns. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="lpReadTimeout">
		/// The amount of time, in milliseconds, a read operation can wait for a message to be written to the mailslot before a time-out
		/// occurs. This parameter is filled in when the function returns. This parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetMailslotInfo( _In_ HANDLE hMailslot, _Out_opt_ LPDWORD lpMaxMessageSize, _Out_opt_ LPDWORD lpNextSize, _Out_opt_
		// LPDWORD lpMessageCount, _Out_opt_ LPDWORD lpReadTimeout); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365435(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa365435")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetMailslotInfo([In] SafeMailslotHandle hMailslot, out uint lpMaxMessageSize, out uint lpNextSize, out uint lpMessageCount, out uint lpReadTimeout);

		/// <summary>Sets the time-out value used by the specified mailslot for a read operation.</summary>
		/// <param name="hMailslot">A handle to a mailslot. The <c>CreateMailslot</c> function must create this handle.</param>
		/// <param name="lReadTimeout">
		/// <para>
		/// The time a read operation can wait for a message to be written to the mailslot before a time-out occurs, in milliseconds. The
		/// following values have special meanings.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Returns immediately if no message is present. (The system does not treat an immediate return as an error.)</term>
		/// </item>
		/// <item>
		/// <term>MAILSLOT_WAIT_FOREVER((DWORD)-1)</term>
		/// <term>Waits forever for a message.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>This time-out value applies to all subsequent read operations and to all inherited mailslot handles.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetMailslotInfo( _In_ HANDLE hMailslot, _In_ DWORD lReadTimeout); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365786(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa365786")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetMailslotInfo([In] SafeMailslotHandle hMailslot, uint lReadTimeout);

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a mailslot that releases a created MailslotHandle instance at disposal using CloseHandle.
		/// </summary>
		public class SafeMailslotHandle : SafeKernelHandle
		{
			/// <summary>Initializes a new instance of the <see cref="MailslotHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeMailslotHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="MailslotHandle"/> class.</summary>
			private SafeMailslotHandle() : base() { }
		}
	}
}