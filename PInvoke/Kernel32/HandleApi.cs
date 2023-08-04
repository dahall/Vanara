using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>Optional actions.</summary>
	[Flags]
	public enum DUPLICATE_HANDLE_OPTIONS : uint
	{
		/// <summary>Closes the source handle. This occurs regardless of any error status returned.</summary>
		DUPLICATE_CLOSE_SOURCE = 0x00000001,

		/// <summary>Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.</summary>
		DUPLICATE_SAME_ACCESS = 0x00000002,
	}

	/// <summary>A set of bit flags that specify properties of the object handle.</summary>
	[Flags]
	public enum HANDLE_FLAG
	{
		/// <summary>None.</summary>
		NONE = 0,

		/// <summary>
		/// If this flag is set, a child process created with the bInheritHandles parameter of CreateProcess set to TRUE will inherit the
		/// object handle.
		/// </summary>
		HANDLE_FLAG_INHERIT = 1,

		/// <summary>If this flag is set, calling the CloseHandle function will not close the object handle.</summary>
		HANDLE_FLAG_PROTECT_FROM_CLOSE = 2
	}

	/// <summary>Closes an open object handle.</summary>
	/// <param name="hObject">A valid handle to an open object.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// If the application is running under a debugger, the function will throw an exception if it receives either a handle value that is not
	/// valid or a pseudo-handle value. This can happen if you close a handle twice, or if you call <c>CloseHandle</c> on a handle returned
	/// by the FindFirstFile function instead of calling the FindClose function.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>CloseHandle</c> function closes handles to the following objects:</para>
	/// <list type="bullet">
	/// <item><definition>Access token</definition></item>
	/// <item><definition>Communications device</definition></item>
	/// <item><definition>Console input</definition></item>
	/// <item><definition>Console screen buffer</definition></item>
	/// <item><definition>Event</definition></item>
	/// <item><definition>File</definition></item>
	/// <item><definition>File mapping</definition></item>
	/// <item><definition>I/O completion port</definition></item>
	/// <item><definition>Job</definition></item>
	/// <item><definition>Mailslot</definition></item>
	/// <item><definition>Memory resource notification</definition></item>
	/// <item><definition>Mutex</definition></item>
	/// <item><definition>Named pipe</definition></item>
	/// <item><definition>Pipe</definition></item>
	/// <item><definition>Process</definition></item>
	/// <item><definition>Semaphore</definition></item>
	/// <item><definition>Thread</definition></item>
	/// <item><definition>Transaction</definition></item>
	/// <item><definition>Waitable timer</definition></item>
	/// </list>
	/// <para>
	/// The documentation for the functions that create these objects indicates that <c>CloseHandle</c> should be used when you are finished
	/// with the object, and what happens to pending operations on the object after the handle is closed. In general, <c>CloseHandle</c>
	/// invalidates the specified object handle, decrements the object's handle count, and performs object retention checks. After the last
	/// handle to an object is closed, the object is removed from the system. For a summary of the creator functions for these objects, see
	/// Kernel Objects.
	/// </para>
	/// <para>
	/// Generally, an application should call <c>CloseHandle</c> once for each handle it opens. It is usually not necessary to call
	/// <c>CloseHandle</c> if a function that uses a handle fails with ERROR_INVALID_HANDLE, because this error usually indicates that the
	/// handle is already invalidated. However, some functions use ERROR_INVALID_HANDLE to indicate that the object itself is no longer
	/// valid. For example, a function that attempts to use a handle to a file on a network might fail with ERROR_INVALID_HANDLE if the
	/// network connection is severed, because the file object is no longer available. In this case, the application should close the handle.
	/// </para>
	/// <para>
	/// If a handle is transacted, all handles bound to a transaction should be closed before the transaction is committed. If a transacted
	/// handle was opened by calling CreateFileTransacted with the FILE_FLAG_DELETE_ON_CLOSE flag, the file is not deleted until the
	/// application closes the handle and calls CommitTransaction. For more information about transacted objects, see Working With Transactions.
	/// </para>
	/// <para>
	/// Closing a thread handle does not terminate the associated thread or remove the thread object. Closing a process handle does not
	/// terminate the associated process or remove the process object. To remove a thread object, you must terminate the thread, then close
	/// all handles to the thread. For more information, see Terminating a Thread. To remove a process object, you must terminate the
	/// process, then close all handles to the process. For more information, see Terminating a Process.
	/// </para>
	/// <para>
	/// Closing a handle to a file mapping can succeed even when there are file views that are still open. For more information, see Closing
	/// a File Mapping Object.
	/// </para>
	/// <para>
	/// Do not use the <c>CloseHandle</c> function to close a socket. Instead, use the closesocket function, which releases all resources
	/// associated with the socket including the handle to the socket object. For more information, see Socket Closure.
	/// </para>
	/// <para>
	/// Do not use the <c>CloseHandle</c> function to close a handle to an open registry key. Instead, use the RegCloseKey function.
	/// <c>CloseHandle</c> does not close the handle to the registry key, but does not return an error to indicate this failure.
	/// </para>
	/// <para>Examples</para>
	/// <para>To see this example in context, see Taking a Snapshot and Viewing Processes.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-closehandle
	// BOOL CloseHandle( [in] HANDLE hObject );
	[PInvokeData("handleapi.h", MSDNShortId = "NF:handleapi.CloseHandle")]
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseHandle([In] IntPtr hObject);

	/// <summary>Closes an open object handle.</summary>
	/// <typeparam name="THandle">The type of the handle.</typeparam>
	/// <param name="handle">The handle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// <para>
	/// If the application is running under a debugger, the function will throw an exception if it receives either a handle value that
	/// is not valid or a pseudo-handle value. This can happen if you close a handle twice, or if you call <c>CloseHandle</c> on a
	/// handle returned by the <c>FindFirstFile</c> function instead of calling the <c>FindClose</c> function.
	/// </para>
	/// </returns>
	[PInvokeData("Winbase.h", MSDNShortId = "ms724211")]
	public static bool CloseHandle<THandle>(THandle handle) where THandle : struct, IKernelHandle => CloseHandle(handle.DangerousGetHandle());

	/// <summary>Compares two object handles to determine if they refer to the same underlying kernel object.</summary>
	/// <param name="hFirstObjectHandle">The first object handle to compare.</param>
	/// <param name="hSecondObjectHandle">The second object handle to compare.</param>
	/// <returns>
	/// A Boolean value that indicates if the two handles refer to the same underlying kernel object. TRUE if the same, otherwise FALSE.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CompareObjectHandles</c> function is useful to determine if two kernel handles refer to the same kernel object without
	/// imposing a requirement that specific access rights be granted to either handle in order to perform the comparison. For example, if a
	/// process desires to determine whether a process handle is a handle to the current process, a call to <c>CompareObjectHandles</c>
	/// (GetCurrentProcess (), hProcess) can be used to determine if hProcess refers to the current process. Notably, this does not require
	/// the use of object-specific access rights, whereas in this example, calling GetProcessId to check the process IDs of two process
	/// handles imposes a requirement that the handles grant PROCESS_QUERY_LIMITED_INFORMATION access. However it is legal for a process
	/// handle to not have that access right granted depending on how the handle is intended to be used.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample creates three handles, two of which refer to the same object, then compares them to show that identical
	/// underlying kernel objects will return TRUE, while non-identical objects will return FALSE.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-compareobjecthandles
	// BOOL CompareObjectHandles( [in] HANDLE hFirstObjectHandle, [in] HANDLE hSecondObjectHandle );
	[PInvokeData("handleapi.h", MSDNShortId = "NF:handleapi.CompareObjectHandles")]
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CompareObjectHandles([In] IntPtr hFirstObjectHandle, [In] IntPtr hSecondObjectHandle);

	/// <summary>Determines if two object handles refer to the same underlying kernel object.</summary>
	/// <param name="h1">The first object handle to compare.</param>
	/// <param name="h2">The second object handle to compare.</param>
	/// <returns><see langword="true"/> if the two handles refer to the same underlying kernel object; <see langword="false"/> otherwise.</returns>
	public static bool Equals(this IKernelHandle h1, IKernelHandle? h2) => CompareObjectHandles(h1.DangerousGetHandle(), h2?.DangerousGetHandle() ?? IntPtr.Zero);

	/// <summary>Duplicates an object handle.</summary>
	/// <param name="hSourceHandle">
	/// The handle to be duplicated. This is an open object handle that is valid in the context of the source process. For a list of
	/// objects whose handles can be duplicated, see the following Remarks section.
	/// </param>
	/// <param name="bInheritHandle">
	/// A variable that indicates whether the handle is inheritable. If <c>TRUE</c>, the duplicate handle can be inherited by new
	/// processes created by the target process. If <c>FALSE</c>, the new handle cannot be inherited.
	/// </param>
	/// <param name="dwOptions">
	/// <para>Optional actions. This parameter can be zero, or any combination of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DUPLICATE_CLOSE_SOURCE0x00000001</term>
	/// <term>Closes the source handle. This occurs regardless of any error status returned.</term>
	/// </item>
	/// <item>
	/// <term>DUPLICATE_SAME_ACCESS0x00000002</term>
	/// <term>Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>
	/// The access requested for the new handle. For the flags that can be specified for each object type, see the following Remarks section.
	/// </para>
	/// <para>
	/// This parameter is ignored if the dwOptions parameter specifies the DUPLICATE_SAME_ACCESS flag. Otherwise, the flags that can be
	/// specified depend on the type of object whose handle is to be duplicated.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>The duplicate handle. This handle value is valid in the context of the target process.</para>
	/// <para>
	/// If hSourceHandle is a pseudo handle returned by <c>GetCurrentProcess</c> or <c>GetCurrentThread</c>, <c>DuplicateHandle</c>
	/// converts it to a real handle to a process or thread, respectively.
	/// </para>
	/// </returns>
	public static IntPtr Duplicate(this IKernelHandle hSourceHandle, bool bInheritHandle = true, DUPLICATE_HANDLE_OPTIONS dwOptions = DUPLICATE_HANDLE_OPTIONS.DUPLICATE_SAME_ACCESS, uint dwDesiredAccess = default) =>
		DuplicateHandle(GetCurrentProcess(), hSourceHandle.DangerousGetHandle(), GetCurrentProcess(), out var h, dwDesiredAccess, bInheritHandle, dwOptions) ? h : IntPtr.Zero;

	/// <summary>Duplicates an object handle.</summary>
	/// <typeparam name="THandle">The type of the handle.</typeparam>
	/// <typeparam name="TAccess">The type of the access value (enum or uint).</typeparam>
	/// <param name="hSourceHandle">
	/// The handle to be duplicated. This is an open object handle that is valid in the context of the source process. For a list of
	/// objects whose handles can be duplicated, see the following Remarks section.
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>
	/// The access requested for the new handle. For the flags that can be specified for each object type, see the following Remarks section.
	/// </para>
	/// <para>
	/// This parameter is ignored if the dwOptions parameter specifies the DUPLICATE_SAME_ACCESS flag. Otherwise, the flags that can be
	/// specified depend on the type of object whose handle is to be duplicated.
	/// </para>
	/// </param>
	/// <param name="bInheritHandle">
	/// A variable that indicates whether the handle is inheritable. If <c>TRUE</c>, the duplicate handle can be inherited by new
	/// processes created by the target process. If <c>FALSE</c>, the new handle cannot be inherited.
	/// </param>
	/// <param name="dwOptions">
	/// <para>Optional actions. This parameter can be zero, or any combination of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DUPLICATE_CLOSE_SOURCE 0x00000001</term>
	/// <term>Closes the source handle. This occurs regardless of any error status returned.</term>
	/// </item>
	/// <item>
	/// <term>DUPLICATE_SAME_ACCESS 0x00000002</term>
	/// <term>Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>The duplicate handle. This handle value is valid in the context of the target process.</para>
	/// <para>
	/// If hSourceHandle is a pseudo handle returned by <c>GetCurrentProcess</c> or <c>GetCurrentThread</c>, <c>DuplicateHandle</c>
	/// converts it to a real handle to a process or thread, respectively.
	/// </para>
	/// </returns>
	public static THandle Duplicate<THandle, TAccess>(this THandle hSourceHandle, TAccess dwDesiredAccess, bool bInheritHandle = true, DUPLICATE_HANDLE_OPTIONS dwOptions = DUPLICATE_HANDLE_OPTIONS.DUPLICATE_SAME_ACCESS)
		where THandle : SafeKernelHandle where TAccess : struct, IConvertible =>
		SafeKernelHandle.DuplicateHandle(hSourceHandle, out var ret, dwDesiredAccess, default, default, bInheritHandle, dwOptions) ? ret : throw Win32Error.GetLastError().GetException()!;

	/// <summary>Duplicates an object handle.</summary>
	/// <param name="hSourceProcessHandle">
	/// <para>A handle to the process with the handle to be duplicated.</para>
	/// <para>The handle must have the PROCESS_DUP_HANDLE access right. For more information, see Process Security and Access Rights.</para>
	/// </param>
	/// <param name="hSourceHandle">
	/// The handle to be duplicated. This is an open object handle that is valid in the context of the source process. For a list of objects
	/// whose handles can be duplicated, see the following Remarks section.
	/// </param>
	/// <param name="hTargetProcessHandle">
	/// <para>A handle to the process that is to receive the duplicated handle. The handle must have the PROCESS_DUP_HANDLE access right.</para>
	/// <para>This parameter is optional and can be specified as NULL if the <c>DUPLICATE_CLOSE_SOURCE</c> flag is set in Options.</para>
	/// </param>
	/// <param name="lpTargetHandle">
	/// <para>A pointer to a variable that receives the duplicate handle. This handle value is valid in the context of the target process.</para>
	/// <para>
	/// If <c>hSourceHandle</c> is a pseudo handle returned by GetCurrentProcess or GetCurrentThread, <c>DuplicateHandle</c> converts it to a
	/// real handle to a process or thread, respectively.
	/// </para>
	/// <para>
	/// If <c>lpTargetHandle</c> is <c>NULL</c>, the function duplicates the handle, but does not return the duplicate handle value to the
	/// caller. This behavior exists only for backward compatibility with previous versions of this function. You should not use this
	/// feature, as you will lose system resources until the target process terminates.
	/// </para>
	/// <para>This parameter is ignored if hTargetProcessHandle is <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>
	/// The access requested for the new handle. For the flags that can be specified for each object type, see the following Remarks section.
	/// </para>
	/// <para>
	/// This parameter is ignored if the <c>dwOptions</c> parameter specifies the DUPLICATE_SAME_ACCESS flag. Otherwise, the flags that can
	/// be specified depend on the type of object whose handle is to be duplicated.
	/// </para>
	/// <para>This parameter is ignored if hTargetProcessHandle is <c>NULL</c>.</para>
	/// </param>
	/// <param name="bInheritHandle">
	/// <para>
	/// A variable that indicates whether the handle is inheritable. If <c>TRUE</c>, the duplicate handle can be inherited by new processes
	/// created by the target process. If <c>FALSE</c>, the new handle cannot be inherited.
	/// </para>
	/// <para>This parameter is ignored if hTargetProcessHandle is <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwOptions">
	/// <para>Optional actions. This parameter can be zero, or any combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>DUPLICATE_CLOSE_SOURCE</c> 0x00000001</term>
	/// <definition>Closes the source handle. This occurs regardless of any error status returned.</definition>
	/// </item>
	/// <item>
	/// <term><c>DUPLICATE_SAME_ACCESS</c> 0x00000002</term>
	/// <definition>Ignores the <c>dwDesiredAccess</c> parameter. The duplicate handle has the same access as the source handle.</definition>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The duplicate handle refers to the same object as the original handle. Therefore, any changes to the object are reflected through
	/// both handles. For example, if you duplicate a file handle, the current file position is always the same for both handles. For file
	/// handles to have different file positions, use the CreateFile function to create file handles that share access to the same file.
	/// </para>
	/// <para>
	/// <c>DuplicateHandle</c> can be called by either the source process or the target process (or a process that is both the source and
	/// target process). For example, a process can use <c>DuplicateHandle</c> to create a noninheritable duplicate of an inheritable handle,
	/// or a handle with different access than the original handle.
	/// </para>
	/// <para>
	/// The source process uses the GetCurrentProcess function to get a handle to itself. This handle is a pseudo handle, but
	/// <c>DuplicateHandle</c> converts it to a real process handle. To get the target process handle, it may be necessary to use some form
	/// of interprocess communication (for example, a named pipe or shared memory) to communicate the process identifier to the source
	/// process. The source process can use this identifier in the OpenProcess function to obtain a handle to the target process.
	/// </para>
	/// <para>
	/// If the process that calls <c>DuplicateHandle</c> is not also the target process, the source process must use interprocess
	/// communication to pass the value of the duplicate handle to the target process.
	/// </para>
	/// <para>
	/// <c>DuplicateHandle</c> can be used to duplicate a handle between a 32-bit process and a 64-bit process. The resulting handle is
	/// appropriately sized to work in the target process. For more information, see Process Interoperability.
	/// </para>
	/// <para><c>DuplicateHandle</c> can duplicate handles to the following types of objects.</para>
	/// <list type="table">
	/// <listheader>
	/// <definition>Object</definition>
	/// <definition>Description</definition>
	/// </listheader>
	/// <item>
	/// <definition>Access token</definition>
	/// <definition>
	/// The handle is returned by the CreateRestrictedToken, DuplicateToken, DuplicateTokenEx, OpenProcessToken, or OpenThreadToken function.
	/// </definition>
	/// </item>
	/// <item>
	/// <definition>Change notification</definition>
	/// <definition>The handle is returned by the FindFirstChangeNotification function.</definition>
	/// </item>
	/// <item>
	/// <definition>Communications device</definition>
	/// <definition>The handle is returned by the CreateFile function.</definition>
	/// </item>
	/// <item>
	/// <definition>Console input</definition>
	/// <definition>
	/// The handle is returned by the CreateFile function when CONIN$ is specified, or by the GetStdHandle function when STD_INPUT_HANDLE is
	/// specified. Console handles can be duplicated for use only in the same process.
	/// </definition>
	/// </item>
	/// <item>
	/// <definition>Console screen buffer</definition>
	/// <definition>
	/// The handle is returned by the CreateFile function when CONOUT$ is specified, or by the GetStdHandle function when STD_OUTPUT_HANDLE
	/// is specified. Console handles can be duplicated for use only in the same process.
	/// </definition>
	/// </item>
	/// <item>
	/// <definition>Desktop</definition>
	/// <definition>The handle is returned by the GetThreadDesktop function.</definition>
	/// </item>
	/// <item>
	/// <definition>Event</definition>
	/// <definition>The handle is returned by the CreateEvent or OpenEvent function.</definition>
	/// </item>
	/// <item>
	/// <definition>File</definition>
	/// <definition>The handle is returned by the CreateFile function.</definition>
	/// </item>
	/// <item>
	/// <definition>File mapping</definition>
	/// <definition>The handle is returned by the CreateFileMapping function.</definition>
	/// </item>
	/// <item>
	/// <definition>Job</definition>
	/// <definition>The handle is returned by the CreateJobObject function.</definition>
	/// </item>
	/// <item>
	/// <definition>Mailslot</definition>
	/// <definition>The handle is returned by the CreateMailslot function.</definition>
	/// </item>
	/// <item>
	/// <definition>Mutex</definition>
	/// <definition>The handle is returned by the CreateMutex or [OpenMutex](../synchapi/nf-synchapi-openmutexw.md) function.</definition>
	/// </item>
	/// <item>
	/// <definition>Pipe</definition>
	/// <definition>
	/// A named pipe handle is returned by the CreateNamedPipe or CreateFile function. An anonymous pipe handle is returned by the CreatePipe function.
	/// </definition>
	/// </item>
	/// <item>
	/// <definition>Process</definition>
	/// <definition>The handle is returned by the CreateProcess, GetCurrentProcess, or OpenProcess function.</definition>
	/// </item>
	/// <item>
	/// <definition>Registry key</definition>
	/// <definition>
	/// The handle is returned by the RegCreateKey, RegCreateKeyEx, RegOpenKey, or RegOpenKeyEx function. Note that registry key handles
	/// returned by the RegConnectRegistry function cannot be used in a call to <c>DuplicateHandle</c>.
	/// </definition>
	/// </item>
	/// <item>
	/// <definition>Semaphore</definition>
	/// <definition>The handle is returned by the CreateSemaphore or OpenSemaphore function.</definition>
	/// </item>
	/// <item>
	/// <definition>Thread</definition>
	/// <definition>The handle is returned by the CreateProcess, CreateThread, CreateRemoteThread, or GetCurrentThread function</definition>
	/// </item>
	/// <item>
	/// <definition>Timer</definition>
	/// <definition>The handle is returned by the CreateWaitableTimerW or OpenWaitableTimerW function.</definition>
	/// </item>
	/// <item>
	/// <definition>Transaction</definition>
	/// <definition>The handle is returned by the CreateTransaction function.</definition>
	/// </item>
	/// <item>
	/// <definition>Window station</definition>
	/// <definition>The handle is returned by the GetProcessWindowStation function.</definition>
	/// </item>
	/// </list>
	/// <para>You should not use <c>DuplicateHandle</c> to duplicate handles to the following objects:</para>
	/// <list type="bullet">
	/// <item>
	/// <definition>I/O completion ports. No error is returned, but the duplicate handle cannot be used.</definition>
	/// </item>
	/// <item>
	/// <definition>
	/// Sockets. No error is returned, but the duplicate handle may not be recognized by Winsock at the target process. Also, using
	/// <c>DuplicateHandle</c> interferes with internal reference counting on the underlying object. To duplicate a socket handle, use the
	/// WSADuplicateSocket function.
	/// </definition>
	/// </item>
	/// <item>
	/// <definition>Pseudo-handles other than the ones returned by the GetCurrentProcess or GetCurrentThread functions.</definition>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>dwDesiredAccess</c> parameter specifies the new handle's access rights. All objects support the standard access rights.
	/// Objects may also support additional access rights depending on the object type. For more information, see the following topics:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <definition>Desktop Security and Access Rights</definition>
	/// </item>
	/// <item>
	/// <definition>File Security and Access Rights</definition>
	/// </item>
	/// <item>
	/// <definition>File-Mapping Security and Access Rights</definition>
	/// </item>
	/// <item>
	/// <definition>Job Object Security and Access Rights</definition>
	/// </item>
	/// <item>
	/// <definition>Process Security and Access Rights</definition>
	/// </item>
	/// <item>
	/// <definition>Registry Key Security and Access Rights</definition>
	/// </item>
	/// <item>
	/// <definition>Synchronization Object Security and Access Rights</definition>
	/// </item>
	/// <item>
	/// <definition>Thread Security and Access Rights</definition>
	/// </item>
	/// <item>
	/// <definition>Window-Station Security and Access Rights</definition>
	/// </item>
	/// </list>
	/// <para>
	/// In some cases, the new handle can have more access rights than the original handle. However, in other cases, <c>DuplicateHandle</c>
	/// cannot create a handle with more access rights than the original. For example, a file handle created with the GENERIC_READ access
	/// right cannot be duplicated so that it has both the GENERIC_READ and GENERIC_WRITE access right.
	/// </para>
	/// <para>
	/// Normally the target process closes a duplicated handle when that process is finished using the handle. To close a duplicated handle
	/// from the source process, call <c>DuplicateHandle</c> with the following parameters:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <definition>Set <c>hSourceProcessHandle</c> to the target process from the <c>DuplicateHandle</c> call that created the handle.</definition>
	/// </item>
	/// <item>
	/// <definition>Set <c>hSourceHandle</c> to the duplicated handle to close.</definition>
	/// </item>
	/// <item>
	/// <definition>Set <c>hTargetProcessHandle</c> to <c>NULL</c>.</definition>
	/// </item>
	/// <item>
	/// <definition>Set <c>dwOptions</c> to DUPLICATE_CLOSE_SOURCE.</definition>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example creates a mutex, duplicates a handle to the mutex, and passes it to another thread. Duplicating the handle
	/// ensures that the reference count is increased so that the mutex object will not be destroyed until both threads have closed the handle.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-duplicatehandle BOOL DuplicateHandle( [in] HANDLE
	// hSourceProcessHandle, [in] HANDLE hSourceHandle, [in] HANDLE hTargetProcessHandle, [out] LPHANDLE lpTargetHandle, [in] DWORD
	// dwDesiredAccess, [in] BOOL bInheritHandle, [in] DWORD dwOptions );
	[PInvokeData("handleapi.h", MSDNShortId = "NF:handleapi.DuplicateHandle")]
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DuplicateHandle([In] HPROCESS hSourceProcessHandle, [In] IntPtr hSourceHandle, [In, Optional] HPROCESS hTargetProcessHandle,
		[Optional] out IntPtr lpTargetHandle, [Optional] uint dwDesiredAccess, [Optional, MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, [Optional] DUPLICATE_HANDLE_OPTIONS dwOptions);

	/// <summary>Retrieves certain properties of an object handle.</summary>
	/// <param name="hObject">
	/// <para>A handle to an object whose information is to be retrieved.</para>
	/// <para>
	/// You can specify a handle to one of the following types of objects: access token, console input buffer, console screen buffer, event,
	/// file, file mapping, job, mailslot, mutex, pipe, printer, process, registry key, semaphore, serial communication device, socket,
	/// thread, or waitable timer.
	/// </para>
	/// </param>
	/// <param name="lpdwFlags">
	/// <para>
	/// A pointer to a variable that receives a set of bit flags that specify properties of the object handle or 0. The following values are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HANDLE_FLAG_INHERIT</c> 0x00000001</term>
	/// <definition>
	/// If this flag is set, a child process created with the <c>bInheritHandles</c> parameter of CreateProcess set to <c>TRUE</c> will
	/// inherit the object handle.
	/// </definition>
	/// </item>
	/// <item>
	/// <term><c>HANDLE_FLAG_PROTECT_FROM_CLOSE</c> 0x00000002</term>
	/// <definition>If this flag is set, calling the CloseHandle function will not close the object handle.</definition>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-gethandleinformation
	// BOOL GetHandleInformation( [in] HANDLE hObject, [out] LPDWORD lpdwFlags );
	[PInvokeData("handleapi.h", MSDNShortId = "NF:handleapi.GetHandleInformation")]
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetHandleInformation([In] IntPtr hObject, out HANDLE_FLAG lpdwFlags);

	/// <summary>Retrieves certain properties of an object handle.</summary>
	/// <param name="hObj">A handle to an object whose information is to be retrieved.</param>
	/// <returns>A variable that receives a set of bit flags that specify properties of the object handle</returns>
	public static HANDLE_FLAG GetInformation(this IKernelHandle hObj) => GetHandleInformation(hObj.DangerousGetHandle(), out var flag) ? flag : 0;

	/// <summary>Sets certain properties of an object handle.</summary>
	/// <param name="hObject">
	/// <para>A handle to an object whose information is to be set.</para>
	/// <para>
	/// You can specify a handle to one of the following types of objects: access token, console input buffer, console screen buffer,
	/// event, file, file mapping, job, mailslot, mutex, pipe, printer, process, registry key, semaphore, serial communication device,
	/// socket, thread, or waitable timer.
	/// </para>
	/// </param>
	/// <param name="dwMask">
	/// A mask that specifies the bit flags to be changed. Use the same constants shown in the description of dwFlags.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Set of bit flags that specifies properties of the object handle. This parameter can be 0 or one or more of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HANDLE_FLAG_INHERIT0x00000001</term>
	/// <term>
	/// If this flag is set, a child process created with the bInheritHandles parameter of CreateProcess set to TRUE will inherit the
	/// object handle.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HANDLE_FLAG_PROTECT_FROM_CLOSE0x00000002</term>
	/// <term>If this flag is set, calling the CloseHandle function will not close the object handle.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetHandleInformation( _In_ HANDLE hObject, _In_ DWORD dwMask, _In_ DWORD dwFlags);// https://msdn.microsoft.com/en-us/library/windows/desktop/ms724935(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724935")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetHandleInformation([In] IntPtr hObject, HANDLE_FLAG dwMask, HANDLE_FLAG dwFlags);

	/// <summary>Provides a <see cref="SafeHandle"/> to a handle that releases a created HANDLE instance at disposal using CloseHandle.</summary>
	public abstract class SafeKernelHandle : SafeHANDLE, IKernelHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeSyncHandle"/> class.</summary>
		protected SafeKernelHandle() : base() { }

		/// <summary>Initializes a new instance of the <see cref="SafeHANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected SafeKernelHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Duplicates an object handle.</summary>
		/// <typeparam name="THandle">The type of the handle.</typeparam>
		/// <typeparam name="TAccess">The type of the access value (enum or uint).</typeparam>
		/// <param name="hSourceHandle">
		/// The handle to be duplicated. This is an open object handle that is valid in the context of the source process. For a list of
		/// objects whose handles can be duplicated, see the following Remarks section.
		/// </param>
		/// <param name="lpTargetHandle">
		/// <para>
		/// A pointer to a variable that receives the duplicate handle. This handle value is valid in the context of the target process.
		/// </para>
		/// <para>
		/// If hSourceHandle is a pseudo handle returned by <c>GetCurrentProcess</c> or <c>GetCurrentThread</c>, <c>DuplicateHandle</c>
		/// converts it to a real handle to a process or thread, respectively.
		/// </para>
		/// <para>
		/// If lpTargetHandle is <c>NULL</c>, the function duplicates the handle, but does not return the duplicate handle value to the
		/// caller. This behavior exists only for backward compatibility with previous versions of this function. You should not use
		/// this feature, as you will lose system resources until the target process terminates.
		/// </para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The access requested for the new handle. For the flags that can be specified for each object type, see the following Remarks section.
		/// </para>
		/// <para>
		/// This parameter is ignored if the dwOptions parameter specifies the DUPLICATE_SAME_ACCESS flag. Otherwise, the flags that can
		/// be specified depend on the type of object whose handle is to be duplicated.
		/// </para>
		/// </param>
		/// <param name="hSourceProcessHandle">
		/// <para>A handle to the process with the handle to be duplicated.</para>
		/// <para>The handle must have the PROCESS_DUP_HANDLE access right. For more information, see Process Security and Access Rights.</para>
		/// </param>
		/// <param name="hTargetProcessHandle">
		/// A handle to the process that is to receive the duplicated handle. The handle must have the PROCESS_DUP_HANDLE access right.
		/// </param>
		/// <param name="bInheritHandle">
		/// A variable that indicates whether the handle is inheritable. If <c>TRUE</c>, the duplicate handle can be inherited by new
		/// processes created by the target process. If <c>FALSE</c>, the new handle cannot be inherited.
		/// </param>
		/// <param name="dwOptions">
		/// <para>Optional actions. This parameter can be zero, or any combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DUPLICATE_CLOSE_SOURCE0x00000001</term>
		/// <term>Closes the source handle. This occurs regardless of any error status returned.</term>
		/// </item>
		/// <item>
		/// <term>DUPLICATE_SAME_ACCESS0x00000002</term>
		/// <term>Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		public static bool DuplicateHandle<THandle, TAccess>(THandle hSourceHandle, out THandle lpTargetHandle, TAccess dwDesiredAccess,
			HPROCESS hSourceProcessHandle = default, HPROCESS hTargetProcessHandle = default, bool bInheritHandle = false, DUPLICATE_HANDLE_OPTIONS dwOptions = 0)
			where THandle : SafeKernelHandle where TAccess : struct, IConvertible
		{
			var ret = Kernel32.DuplicateHandle(hSourceProcessHandle == default ? GetCurrentProcess() : hSourceProcessHandle, hSourceHandle.DangerousGetHandle(),
				hTargetProcessHandle == default ? GetCurrentProcess() : hTargetProcessHandle, out IntPtr h, Convert.ToUInt32(dwDesiredAccess), bInheritHandle, dwOptions);
			lpTargetHandle = (THandle)Activator.CreateInstance(typeof(THandle), h, true)!;
			return ret;
		}

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => CloseHandle(handle);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to a synchronization object that is automatically disposed using CloseHandle.</summary>
	/// <remarks></remarks>
	public abstract class SafeSyncHandle : SafeKernelHandle, ISyncHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeSyncHandle"/> class.</summary>
		protected SafeSyncHandle() : base() { }

		/// <summary>Initializes a new instance of the <see cref="SafeSyncHandle"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected SafeSyncHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Performs an implicit conversion from <see cref="SafeSyncHandle"/> to <see cref="SafeWaitHandle"/>.</summary>
		/// <param name="h">The SafeSyncHandle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeWaitHandle(SafeSyncHandle h) => new(h.handle, false);

		/// <summary>Waits until this object is in the signaled state or the time-out interval elapses.</summary>
		/// <param name="msec">
		/// <para>
		/// The time-out interval, in milliseconds. If a nonzero value is specified, the function waits until the object is signaled or
		/// the interval elapses. If <paramref name="msec"/> is zero, the function does not enter a wait state if the object is not
		/// signaled; it always returns immediately. If <paramref name="msec"/> is <c>INFINITE</c>, the function will return only when
		/// the object is signaled.
		/// </para>
		/// <para>
		/// <c>Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008 and Windows Server 2008 R2:</c> The
		/// <paramref name="msec"/> value does include time spent in low-power states. For example, the timeout does keep counting down
		/// while the computer is asleep.
		/// </para>
		/// <para>
		/// <c>Windows 8, Windows Server 2012, Windows 8.1, Windows Server 2012 R2, Windows 10 and Windows Server 2016:</c> The <paramref
		/// name="msec"/> value does not include time spent in low-power states. For example, the timeout does not keep counting down
		/// while the computer is asleep.
		/// </para>
		/// </param>
		/// <returns><see langword="true"/> if the current instance receives a signal; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="AbandonedMutexException">The wait completed because a thread exited without releasing a mutex.</exception>
		public bool Wait(uint msec = INFINITE) => WaitForSingleObject(ThrowIfDisposed(this), msec) switch
		{
			WAIT_STATUS.WAIT_OBJECT_0 => true,
			WAIT_STATUS.WAIT_TIMEOUT => false,
			WAIT_STATUS.WAIT_ABANDONED => throw new AbandonedMutexException(),
			_ => throw Win32Error.GetLastError().GetException()!,
		};
	}
}