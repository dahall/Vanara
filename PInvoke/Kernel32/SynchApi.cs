using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary/>
	public const int INIT_ONCE_CTX_RESERVED_BITS = 2;

	// PINIT_ONCE_FN PTIMERAPCROUTINE

	/// <summary>
	/// An application-defined callback function. Specify a pointer to this function when calling the InitOnceExecuteOnce function. The
	/// PINIT_ONCE_FN type defines a pointer to this callback function.
	/// </summary>
	/// <param name="InitOnce">A pointer to the one-time initialization structure.</param>
	/// <param name="Parameter">An optional parameter that was passed to the callback function.</param>
	/// <param name="Context">
	/// The data to be stored with the one-time initialization structure. If Context references a value, the low-order
	/// INIT_ONCE_CTX_RESERVED_BITS of the value must be zero. If Context points to a data structure, the data structure must be DWORD-aligned.
	/// </param>
	/// <returns>
	/// <para>If the function returns TRUE, the block is marked as initialized.</para>
	/// <para>
	/// If the function returns FALSE, the block is not marked as initialized and the call to InitOnceExecuteOnce fails. To communicate
	/// additional error information, call SetLastError before returning FALSE.
	/// </para>
	/// </returns>
	[PInvokeData("synchapi.h")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool InitOnceCallback(ref INIT_ONCE InitOnce, [In, Out, Optional] IntPtr Parameter, [Optional] out IntPtr Context);

	/// <summary>
	/// An application-defined timer completion routine. Specify this address when calling the SetWaitableTimer function. The
	/// PTIMERAPCROUTINE type defines a pointer to this callback function.
	/// </summary>
	/// <param name="lpArgToCompletionRoutine">
	/// The value passed to the function using the lpArgToCompletionRoutine parameter of the SetWaitableTimer function.
	/// </param>
	/// <param name="dwTimerLowValue">
	/// The low-order portion of the UTC-based time at which the timer was signaled. This value corresponds to the dwLowDateTime member of
	/// the FILETIME structure. For more information about UTC-based time, see System Time.
	/// </param>
	/// <param name="dwTimerHighValue">
	/// The high-order portion of the UTC-based time at which the timer was signaled. This value corresponds to the dwHighDateTime member of
	/// the FILETIME structure.
	/// </param>
	[PInvokeData("synchapi.h")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void TimerAPCProc([In, Optional] IntPtr lpArgToCompletionRoutine, uint dwTimerLowValue, uint dwTimerHighValue);

	/// <summary>Used by <see cref="SleepConditionVariableSRW"/>.</summary>
	[PInvokeData("synchapi.h")]
	[Flags]
	public enum CONDITION_VARIABLE_FLAGS
	{
		/// <summary>The SRW lock is in exclusive mode.</summary>
		CONDITION_VARIABLE_INIT = 0,

		/// <summary>The SRW lock is in shared mode.</summary>
		CONDITION_VARIABLE_LOCKMODE_SHARED = 1,
	}

	/// <summary>Flags used by <see cref="CreateEventEx"/>.</summary>
	[PInvokeData("synchapi.h")]
	[Flags]
	public enum CREATE_EVENT_FLAGS : uint
	{
		/// <summary>
		/// The event must be manually reset using the ResetEvent function. Any number of waiting threads, or threads that subsequently begin
		/// wait operations for the specified event object, can be released while the object's state is signaled.If this flag is not
		/// specified, the system automatically resets the event after releasing a single waiting thread.
		/// </summary>
		CREATE_EVENT_MANUAL_RESET = 0x00000001,

		/// <summary>The initial state of the event object is signaled; otherwise, it is nonsignaled.</summary>
		CREATE_EVENT_INITIAL_SET = 0x00000002,
	}

	/// <summary>Flags used by CreateMutexEx</summary>
	[PInvokeData("synchapi.h")]
	[Flags]
	public enum CREATE_MUTEX_FLAGS : uint
	{
		/// <summary>The object creator is the initial owner of the mutex.</summary>
		CREATE_MUTEX_INITIAL_OWNER = 0x00000001
	}

	/// <summary>Used by CreateWaitableTimerEx</summary>
	[PInvokeData("synchapi.h")]
	[Flags]
	public enum CREATE_WAITABLE_TIMER_FLAG
	{
		/// <summary>The system automatically resets the timer after releasing a single waiting thread.</summary>
		CREATE_WAITABLE_TIMER_AUTOMATIC_RESET = 0x00000000,

		/// <summary>The timer must be manually reset.</summary>
		CREATE_WAITABLE_TIMER_MANUAL_RESET = 0x00000001,

		/// <summary>Creates a high resolution timer.</summary>
		CREATE_WAITABLE_TIMER_HIGH_RESOLUTION = 0x00000002,
	}

	/// <summary>Define the upper byte of the critical section SpinCount field.</summary>
	[PInvokeData("synchapi.h")]
	[Flags]
	public enum CRITICAL_SECTION_FLAGS : uint
	{
		/// <summary>The critical section is created without debug information.</summary>
		CRITICAL_SECTION_FLAG_NO_DEBUG_INFO = 0x01000000,

		/// <summary/>
		CRITICAL_SECTION_FLAG_DYNAMIC_SPIN = 0x02000000,

		/// <summary/>
		CRITICAL_SECTION_FLAG_STATIC_INIT = 0x04000000,

		/// <summary/>
		CRITICAL_SECTION_FLAG_RESOURCE_TYPE = 0x08000000,

		/// <summary/>
		CRITICAL_SECTION_FLAG_FORCE_DEBUG_INFO = 0x10000000,

		/// <summary/>
		CRITICAL_SECTION_ALL_FLAG_BITS = 0xFF000000,
	}

	/// <summary>Used by <c>REASON_CONTEXT</c>.</summary>
	[PInvokeData("synchapi.h")]
	public enum DIAGNOSTIC_REASON : uint
	{
		/// <summary>
		/// The SimpleReasonString parameter contains a simple, non-localizable string that describes the reason for the power request.
		/// </summary>
		DIAGNOSTIC_REASON_SIMPLE_STRING = 0x00000001,

		/// <summary>The Detailed structure identifies a localizable string resource that describes the reason for the power request.</summary>
		DIAGNOSTIC_REASON_DETAILED_STRING = 0x00000002,

		/// <summary>Unspecified.</summary>
		DIAGNOSTIC_REASON_NOT_SPECIFIED = 0x80000000
	}

	/// <summary>Used by <c>REASON_CONTEXT</c>.</summary>
	[PInvokeData("synchapi.h")]
	public enum DIAGNOSTIC_REASON_VERSION
	{
		/// <summary>The diagnostic reason version</summary>
		DIAGNOSTIC_REASON_VERSION = 0
	}

	/// <summary>Flags for InitOnceBeginInitialize.</summary>
	[PInvokeData("synchapi.h")]
	[Flags]
	public enum INIT_ONCE_FLAGS : uint
	{
		/// <summary>
		/// This function call does not begin initialization. The return value indicates whether initialization has already completed. If the
		/// function returns TRUE, the lpContext parameter receives the data.
		/// </summary>
		INIT_ONCE_CHECK_ONLY = 0x00000001,

		/// <summary>
		/// Enables multiple initialization attempts to execute in parallel. If this flag is used, subsequent calls to this function will
		/// fail unless this flag is also specified.
		/// </summary>
		INIT_ONCE_ASYNC = 0x00000002,

		/// <summary>The initialize once initialize failed</summary>
		INIT_ONCE_INIT_FAILED = 0x00000004,
	}

	/// <summary>Flags that control the behavior of threads that enter this barrier.</summary>
	[PInvokeData("synchapi.h")]
	[Flags]
	public enum SYNC_BARRIER_FLAGS
	{
		/// <summary>
		/// Specifies that the thread entering the barrier should spin until the last thread enters the barrier, even if the spinning thread
		/// exceeds the barrier's maximum spin count.
		/// </summary>
		SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY = 0x01,

		/// <summary>Specifies that the thread entering the barrier should block immediately until the last thread enters the barrier.</summary>
		SYNCHRONIZATION_BARRIER_FLAGS_BLOCK_ONLY = 0x02,

		/// <summary>
		/// Specifies that the function can skip the work required to ensure that it is safe to delete the barrier, which can improve
		/// performance. All threads that enter this barrier must specify the flag; otherwise, the flag is ignored. This flag should be used
		/// only if the barrier will never be deleted.
		/// </summary>
		SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE = 0x04,
	}

	/// <summary>Synchronization object access flags.</summary>
	[PInvokeData("synchapi.h")]
	[Flags]
	public enum SynchronizationObjectAccess : uint
	{
		/// <summary>Modify state access, which is required for the SetEvent, ResetEvent and PulseEvent functions.</summary>
		EVENT_MODIFY_STATE = 0x0002,

		/// <summary>
		/// All possible access rights for an event object. Use this right only if your application requires access beyond that granted by
		/// the standard access rights and EVENT_MODIFY_STATE. Using this access right increases the possibility that your application must
		/// be run by an Administrator.
		/// </summary>
		EVENT_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | ACCESS_MASK.SYNCHRONIZE | 0x3,

		/// <summary>Reserved for future use.</summary>
		MUTEX_QUERY_STATE = 0x0001,

		/// <summary>
		/// All possible access rights for a mutex object. Use this right only if your application requires access beyond that granted by the
		/// standard access rights. Using this access right increases the possibility that your application must be run by an Administrator.
		/// </summary>
		MUTEX_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | ACCESS_MASK.SYNCHRONIZE | MUTEX_QUERY_STATE,

		/// <summary>Modify state access, which is required for the ReleaseSemaphore function.</summary>
		SEMAPHORE_MODIFY_STATE = 0x0002,

		/// <summary>
		/// All possible access rights for a semaphore object. Use this right only if your application requires access beyond that granted by
		/// the standard access rights and SEMAPHORE_MODIFY_STATE. Using this access right increases the possibility that your application
		/// must be run by an Administrator.
		/// </summary>
		SEMAPHORE_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | ACCESS_MASK.SYNCHRONIZE | 0x3,

		/// <summary>Reserved for future use.</summary>
		TIMER_QUERY_STATE = 0x0001,

		/// <summary>Modify state access, which is required for the SetWaitableTimer and CancelWaitableTimer functions.</summary>
		TIMER_MODIFY_STATE = 0x0002,

		/// <summary>
		/// All possible access rights for a waitable timer object. Use this right only if your application requires access beyond that
		/// granted by the standard access rights and TIMER_MODIFY_STATE. Using this access right increases the possibility that your
		/// application must be run by an Administrator.
		/// </summary>
		TIMER_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | ACCESS_MASK.SYNCHRONIZE | TIMER_QUERY_STATE | TIMER_MODIFY_STATE,
	}

	/// <summary>Values returned by <see cref="SignalObjectAndWait(IntPtr, IntPtr, uint, bool)"/>.</summary>
	[PInvokeData("synchapi.h")]
	public enum WAIT_STATUS : uint
	{
		/// <summary>
		/// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread
		/// terminated. Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.If the mutex was
		/// protecting persistent state information, you should check it for consistency.
		/// </summary>
		WAIT_ABANDONED = 0x00000080,

		/// <summary>The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.</summary>
		WAIT_IO_COMPLETION = 0x000000C0,

		/// <summary>The state of the specified object is signaled.</summary>
		WAIT_OBJECT_0 = 0x00000000,

		/// <summary>The time-out interval elapsed, and the object's state is nonsignaled.</summary>
		WAIT_TIMEOUT = 0x00000102,

		/// <summary>The function has failed. To get extended error information, call GetLastError.</summary>
		WAIT_FAILED = 0xFFFFFFFF,
	}

	/// <summary>Acquires a slim reader/writer (SRW) lock in exclusive mode.</summary>
	/// <param name="SRWLock">A pointer to the SRW lock.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI AcquireSRWLockExclusive( _Inout_ PSRWLOCK SRWLock); https://msdn.microsoft.com/en-us/library/windows/desktop/ms681930(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms681930")]
	public static extern void AcquireSRWLockExclusive(ref SRWLOCK SRWLock);

	/// <summary>Acquires a slim reader/writer (SRW) lock in shared mode.</summary>
	/// <param name="SRWLock">A pointer to the SRW lock.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI AcquireSRWLockShared( _Inout_ PSRWLOCK SRWLock); https://msdn.microsoft.com/en-us/library/windows/desktop/ms681934(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms681934")]
	public static extern void AcquireSRWLockShared(ref SRWLOCK SRWLock);

	/// <summary>Sets the specified waitable timer to the inactive state.</summary>
	/// <param name="hTimer">
	/// A handle to the timer object. The <c>CreateWaitableTimer</c> or <c>OpenWaitableTimer</c> function returns this handle. The handle
	/// must have the <c>TIMER_MODIFY_STATE</c> access right. For more information, see Synchronization Object Security and Access Rights.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI CancelWaitableTimer( _In_ HANDLE hTimer); https://msdn.microsoft.com/en-us/library/windows/desktop/ms681985(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms681985")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CancelWaitableTimer([In] SafeWaitableTimerHandle hTimer);

	/// <summary>
	/// <para>Creates or opens a named or unnamed event object.</para>
	/// <para>To specify an access mask for the object, use the <c>CreateEventEx</c> function.</para>
	/// </summary>
	/// <param name="lpEventAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. If this parameter is <c>NULL</c>, the handle cannot be inherited by child processes.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new event. If lpEventAttributes is
	/// <c>NULL</c>, the event gets a default security descriptor. The ACLs in the default security descriptor for an event come from the
	/// primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="bManualReset">
	/// If this parameter is <c>TRUE</c>, the function creates a manual-reset event object, which requires the use of the <c>ResetEvent</c>
	/// function to set the event state to nonsignaled. If this parameter is <c>FALSE</c>, the function creates an auto-reset event object,
	/// and system automatically resets the event state to nonsignaled after a single waiting thread has been released.
	/// </param>
	/// <param name="bInitialState">
	/// If this parameter is <c>TRUE</c>, the initial state of the event object is signaled; otherwise, it is nonsignaled.
	/// </param>
	/// <param name="lpName">
	/// <para>The name of the event object. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case sensitive.</para>
	/// <para>
	/// If lpName matches the name of an existing named event object, this function requests the <c>EVENT_ALL_ACCESS</c> access right. In
	/// this case, the bManualReset and bInitialState parameters are ignored because they have already been set by the creating process. If
	/// the lpEventAttributes parameter is not <c>NULL</c>, it determines whether the handle can be inherited, but its security-descriptor
	/// member is ignored.
	/// </para>
	/// <para>If lpName is <c>NULL</c>, the event object is created without a name.</para>
	/// <para>
	/// If lpName matches the name of another kind of object in the same namespace (such as an existing semaphore, mutex, waitable timer,
	/// job, or file-mapping object), the function fails and the <c>GetLastError</c> function returns <c>ERROR_INVALID_HANDLE</c>. This
	/// occurs because these objects share the same namespace.
	/// </para>
	/// <para>
	/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of
	/// the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces. Fast user
	/// switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for Terminal
	/// Services so that applications can support multiple users.
	/// </para>
	/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the event object. If the named event object existed before the function
	/// call, the function returns a handle to the existing object and <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI CreateEvent( _In_opt_ LPSECURITY_ATTRIBUTES lpEventAttributes, _In_ BOOL bManualReset, _In_ BOOL bInitialState, _In_opt_
	// LPCTSTR lpName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682396(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682396")]
	[return: AddAsCtor]
	public static extern SafeEventHandle CreateEvent([In, Optional] SECURITY_ATTRIBUTES? lpEventAttributes, [Optional, MarshalAs(UnmanagedType.Bool)] bool bManualReset,
		[Optional, MarshalAs(UnmanagedType.Bool)] bool bInitialState, [In, Optional] string? lpName);

	/// <summary>Creates or opens a named or unnamed event object and returns a handle to the object.</summary>
	/// <param name="lpEventAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. If lpEventAttributes is <c>NULL</c>, the event handle cannot be inherited by
	/// child processes.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new event. If lpEventAttributes is
	/// <c>NULL</c>, the event gets a default security descriptor. The ACLs in the default security descriptor for an event come from the
	/// primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>The name of the event object. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case sensitive.</para>
	/// <para>If lpName is <c>NULL</c>, the event object is created without a name.</para>
	/// <para>
	/// If lpName matches the name of another kind of object in the same namespace (such as an existing semaphore, mutex, waitable timer,
	/// job, or file-mapping object), the function fails and the <c>GetLastError</c> function returns <c>ERROR_INVALID_HANDLE</c>. This
	/// occurs because these objects share the same namespace.
	/// </para>
	/// <para>
	/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of
	/// the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces. Fast user
	/// switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for Terminal
	/// Services so that applications can support multiple users.
	/// </para>
	/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one or more of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CREATE_EVENT_INITIAL_SET = 0x00000002</term>
	/// <term>The initial state of the event object is signaled; otherwise, it is nonsignaled.</term>
	/// </item>
	/// <item>
	/// <term>CREATE_EVENT_MANUAL_RESET = 0x00000001</term>
	/// <term>
	/// The event must be manually reset using the ResetEvent function. Any number of waiting threads, or threads that subsequently begin
	/// wait operations for the specified event object, can be released while the object's state is signaled.If this flag is not specified,
	/// the system automatically resets the event after releasing a single waiting thread.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// The access mask for the event object. For a list of access rights, see Synchronization Object Security and Access Rights.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the event object. If the named event object existed before the function
	/// call, the function returns a handle to the existing object and <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI CreateEventEx( _In_opt_ LPSECURITY_ATTRIBUTES lpEventAttributes, _In_opt_ LPCTSTR lpName, _In_ DWORD dwFlags, _In_ DWORD
	// dwDesiredAccess); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682400(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682400")]
	[return: AddAsCtor]
	public static extern SafeEventHandle CreateEventEx([In, Optional] SECURITY_ATTRIBUTES? lpEventAttributes, [In, Optional] string? lpName,
		[Optional] CREATE_EVENT_FLAGS dwFlags, ACCESS_MASK dwDesiredAccess);

	/// <summary>
	/// <para>Creates or opens a named or unnamed mutex object.</para>
	/// <para>To specify an access mask for the object, use the <c>CreateMutexEx</c> function.</para>
	/// </summary>
	/// <param name="lpMutexAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. If this parameter is <c>NULL</c>, the handle cannot be inherited by child processes.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new mutex. If lpMutexAttributes is
	/// <c>NULL</c>, the mutex gets a default security descriptor. The ACLs in the default security descriptor for a mutex come from the
	/// primary or impersonation token of the creator. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="bInitialOwner">
	/// If this value is <c>TRUE</c> and the caller created the mutex, the calling thread obtains initial ownership of the mutex object.
	/// Otherwise, the calling thread does not obtain ownership of the mutex. To determine if the caller created the mutex, see the Return
	/// Values section.
	/// </param>
	/// <param name="lpName">
	/// <para>The name of the mutex object. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case sensitive.</para>
	/// <para>
	/// If lpName matches the name of an existing named mutex object, this function requests the <c>MUTEX_ALL_ACCESS</c> access right. In
	/// this case, the bInitialOwner parameter is ignored because it has already been set by the creating process. If the lpMutexAttributes
	/// parameter is not <c>NULL</c>, it determines whether the handle can be inherited, but its security-descriptor member is ignored.
	/// </para>
	/// <para>If lpName is <c>NULL</c>, the mutex object is created without a name.</para>
	/// <para>
	/// If lpName matches the name of an existing event, semaphore, waitable timer, job, or file-mapping object, the function fails and the
	/// <c>GetLastError</c> function returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
	/// </para>
	/// <para>
	/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of
	/// the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces. Fast user
	/// switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for Terminal
	/// Services so that applications can support multiple users.
	/// </para>
	/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the newly created mutex object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// <para>
	/// If the mutex is a named mutex and the object existed before this function call, the return value is a handle to the existing object,
	/// <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>, bInitialOwner is ignored, and the calling thread is not granted ownership.
	/// However, if the caller has limited access rights, the function will fail with <c>ERROR_ACCESS_DENIED</c> and the caller should use
	/// the <c>OpenMutex</c> function.
	/// </para>
	/// </returns>
	// HANDLE WINAPI CreateMutex( _In_opt_ LPSECURITY_ATTRIBUTES lpMutexAttributes, _In_ BOOL bInitialOwner, _In_opt_ LPCTSTR lpName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682411(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682411")]
	[return: AddAsCtor]
	public static extern SafeMutexHandle CreateMutex([In, Optional] SECURITY_ATTRIBUTES? lpMutexAttributes, [MarshalAs(UnmanagedType.Bool)] bool bInitialOwner,
		[In, Optional] string? lpName);

	/// <summary>Creates or opens a named or unnamed mutex object and returns a handle to the object.</summary>
	/// <param name="lpMutexAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. If this parameter is <c>NULL</c>, the mutex handle cannot be inherited by child processes.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new mutex. If lpMutexAttributes is
	/// <c>NULL</c>, the mutex gets a default security descriptor. The ACLs in the default security descriptor for a mutex come from the
	/// primary or impersonation token of the creator. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>The name of the mutex object. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case sensitive.</para>
	/// <para>If lpName is <c>NULL</c>, the mutex object is created without a name.</para>
	/// <para>
	/// If lpName matches the name of an existing event, semaphore, waitable timer, job, or file-mapping object, the function fails and the
	/// <c>GetLastError</c> function returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
	/// </para>
	/// <para>
	/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of
	/// the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces. Fast user
	/// switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for Terminal
	/// Services so that applications can support multiple users.
	/// </para>
	/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be 0 or the following value.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CREATE_MUTEX_INITIAL_OWNER = 0x00000001</term>
	/// <term>The object creator is the initial owner of the mutex.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// The access mask for the mutex object. For a list of access rights, see Synchronization Object Security and Access Rights.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the newly created mutex object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// <para>
	/// If the mutex is a named mutex and the object existed before this function call, the return value is a handle to the existing object,
	/// <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>, bInitialOwner is ignored, and the calling thread is not granted ownership.
	/// However, if the caller has limited access rights, the function will fail with <c>ERROR_ACCESS_DENIED</c> and the caller should use
	/// the <c>OpenMutex</c> function.
	/// </para>
	/// </returns>
	// HANDLE WINAPI CreateMutexEx( _In_opt_ LPSECURITY_ATTRIBUTES lpMutexAttributes, _In_opt_ LPCTSTR lpName, _In_ DWORD dwFlags, _In_ DWORD
	// dwDesiredAccess); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682418(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682418")]
	[return: AddAsCtor]
	public static extern SafeMutexHandle CreateMutexEx([In, Optional] SECURITY_ATTRIBUTES? lpMutexAttributes, [In, Optional] string? lpName,
		[Optional] CREATE_MUTEX_FLAGS dwFlags, ACCESS_MASK dwDesiredAccess);

	/// <summary>
	/// <para>Creates or opens a named or unnamed semaphore object.</para>
	/// <para>To specify an access mask for the object, use the <c>CreateSemaphoreEx</c> function.</para>
	/// </summary>
	/// <param name="lpSemaphoreAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. If this parameter is <c>NULL</c>, the handle cannot be inherited by child processes.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new semaphore. If this parameter is
	/// <c>NULL</c>, the semaphore gets a default security descriptor. The ACLs in the default security descriptor for a semaphore come from
	/// the primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="lInitialCount">
	/// The initial count for the semaphore object. This value must be greater than or equal to zero and less than or equal to lMaximumCount.
	/// The state of a semaphore is signaled when its count is greater than zero and nonsignaled when it is zero. The count is decreased by
	/// one whenever a wait function releases a thread that was waiting for the semaphore. The count is increased by a specified amount by
	/// calling the <c>ReleaseSemaphore</c> function.
	/// </param>
	/// <param name="lMaximumCount">The maximum count for the semaphore object. This value must be greater than zero.</param>
	/// <param name="lpName">
	/// <para>The name of the semaphore object. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case sensitive.</para>
	/// <para>
	/// If lpName matches the name of an existing named semaphore object, this function requests the <c>SEMAPHORE_ALL_ACCESS</c> access
	/// right. In this case, the lInitialCount and lMaximumCount parameters are ignored because they have already been set by the creating
	/// process. If the lpSemaphoreAttributes parameter is not <c>NULL</c>, it determines whether the handle can be inherited, but its
	/// security-descriptor member is ignored.
	/// </para>
	/// <para>If lpName is <c>NULL</c>, the semaphore object is created without a name.</para>
	/// <para>
	/// If lpName matches the name of an existing event, mutex, waitable timer, job, or file-mapping object, the function fails and the
	/// <c>GetLastError</c> function returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
	/// </para>
	/// <para>
	/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of
	/// the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces. Fast user
	/// switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for Terminal
	/// Services so that applications can support multiple users.
	/// </para>
	/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the semaphore object. If the named semaphore object existed before the
	/// function call, the function returns a handle to the existing object and <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI CreateSemaphore( _In_opt_ LPSECURITY_ATTRIBUTES lpSemaphoreAttributes, _In_ LONG lInitialCount, _In_ LONG lMaximumCount,
	// _In_opt_ LPCTSTR lpName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682438(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682438")]
	[return: AddAsCtor]
	public static extern SafeSemaphoreHandle CreateSemaphore([In, Optional] SECURITY_ATTRIBUTES? lpSemaphoreAttributes, int lInitialCount,
		int lMaximumCount, [In, Optional] string? lpName);

	/// <summary>Creates or opens a named or unnamed semaphore object and returns a handle to the object.</summary>
	/// <param name="lpSemaphoreAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. If this parameter is <c>NULL</c>, the semaphore handle cannot be inherited by
	/// child processes.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new semaphore. If this parameter is
	/// <c>NULL</c>, the semaphore gets a default security descriptor. The ACLs in the default security descriptor for a semaphore come from
	/// the primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="lInitialCount">
	/// The initial count for the semaphore object. This value must be greater than or equal to zero and less than or equal to lMaximumCount.
	/// The state of a semaphore is signaled when its count is greater than zero and nonsignaled when it is zero. The count is decreased by
	/// one whenever a wait function releases a thread that was waiting for the semaphore. The count is increased by a specified amount by
	/// calling the <c>ReleaseSemaphore</c> function.
	/// </param>
	/// <param name="lMaximumCount">The maximum count for the semaphore object. This value must be greater than zero.</param>
	/// <param name="lpName">
	/// <para>
	/// A pointer to a null-terminated string specifying the name of the semaphore object. The name is limited to <c>MAX_PATH</c> characters.
	/// Name comparison is case sensitive.
	/// </para>
	/// <para>
	/// If lpName matches the name of an existing named semaphore object, the lInitialCount and lMaximumCount parameters are ignored because
	/// they have already been set by the creating process. If the lpSemaphoreAttributes parameter is not <c>NULL</c>, it determines whether
	/// the handle can be inherited.
	/// </para>
	/// <para>If lpName is <c>NULL</c>, the semaphore object is created without a name.</para>
	/// <para>
	/// If lpName matches the name of an existing event, mutex, waitable timer, job, or file-mapping object, the function fails and the
	/// <c>GetLastError</c> function returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
	/// </para>
	/// <para>
	/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of
	/// the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces. Fast user
	/// switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for Terminal
	/// Services so that applications can support multiple users.
	/// </para>
	/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
	/// </param>
	/// <param name="dwFlags">This parameter is reserved and must be 0.</param>
	/// <param name="dwDesiredAccess">
	/// The access mask for the semaphore object. For a list of access rights, see Synchronization Object Security and Access Rights.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the semaphore object. If the named semaphore object existed before the
	/// function call, the function returns a handle to the existing object and <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI CreateSemaphoreEx( _In_opt_ LPSECURITY_ATTRIBUTES lpSemaphoreAttributes, _In_ LONG lInitialCount, _In_ LONG
	// lMaximumCount, _In_opt_ LPCTSTR lpName, _Reserved_ DWORD dwFlags, _In_ DWORD dwDesiredAccess); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682446(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682446")]
	[return: AddAsCtor]
	public static extern SafeSemaphoreHandle CreateSemaphoreEx([In, Optional] SECURITY_ATTRIBUTES? lpSemaphoreAttributes, int lInitialCount,
		int lMaximumCount, [In, Optional] string? lpName, [Optional] uint dwFlags, ACCESS_MASK dwDesiredAccess);

	/// <summary>
	/// <para>Creates or opens a waitable timer object.</para>
	/// <para>To specify an access mask for the object, use the <c>CreateWaitableTimerEx</c> function.</para>
	/// </summary>
	/// <param name="lpTimerAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new timer object and determines
	/// whether child processes can inherit the returned handle.
	/// </para>
	/// <para>
	/// If lpTimerAttributes is <c>NULL</c>, the timer object gets a default security descriptor and the handle cannot be inherited. The ACLs
	/// in the default security descriptor for a timer come from the primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="bManualReset">
	/// If this parameter is <c>TRUE</c>, the timer is a manual-reset notification timer. Otherwise, the timer is a synchronization timer.
	/// </param>
	/// <param name="lpTimerName">
	/// <para>The name of the timer object. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case sensitive.</para>
	/// <para>If lpTimerName is <c>NULL</c>, the timer object is created without a name.</para>
	/// <para>
	/// If lpTimerName matches the name of an existing event, semaphore, mutex, job, or file-mapping object, the function fails and
	/// <c>GetLastError</c> returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
	/// </para>
	/// <para>
	/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of
	/// the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces. Fast user
	/// switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for Terminal
	/// Services so that applications can support multiple users.
	/// </para>
	/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the timer object. If the named timer object exists before the function
	/// call, the function returns a handle to the existing object and <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI CreateWaitableTimer( _In_opt_ LPSECURITY_ATTRIBUTES lpTimerAttributes, _In_ BOOL bManualReset, _In_opt_ LPCTSTR
	// lpTimerName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682492(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682492")]
	[return: AddAsCtor]
	public static extern SafeWaitableTimerHandle CreateWaitableTimer([In, Optional] SECURITY_ATTRIBUTES? lpTimerAttributes,
		[MarshalAs(UnmanagedType.Bool)] bool bManualReset, [In, Optional] string? lpTimerName);

	/// <summary>Creates or opens a waitable timer object and returns a handle to the object.</summary>
	/// <param name="lpTimerAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. If this parameter is <c>NULL</c>, the timer handle cannot be inherited by child processes.
	/// </para>
	/// <para>
	/// If lpTimerAttributes is <c>NULL</c>, the timer object gets a default security descriptor and the handle cannot be inherited. The ACLs
	/// in the default security descriptor for a timer come from the primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="lpTimerName">
	/// <para>The name of the timer object. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case sensitive.</para>
	/// <para>If lpTimerName is <c>NULL</c>, the timer object is created without a name.</para>
	/// <para>
	/// If lpTimerName matches the name of an existing event, semaphore, mutex, job, or file-mapping object, the function fails and
	/// <c>GetLastError</c> returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
	/// </para>
	/// <para>
	/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of
	/// the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces. Fast user
	/// switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for Terminal
	/// Services so that applications can support multiple users.
	/// </para>
	/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be 0 or the following value.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CREATE_WAITABLE_TIMER_MANUAL_RESET0x00000001</term>
	/// <term>The timer must be manually reset. Otherwise, the system automatically resets the timer after releasing a single waiting thread.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// The access mask for the timer object. For a list of access rights, see Synchronization Object Security and Access Rights.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the timer object. If the named timer object exists before the function
	/// call, the function returns a handle to the existing object and <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI CreateWaitableTimerEx( _In_opt_ LPSECURITY_ATTRIBUTES lpTimerAttributes, _In_opt_ LPCTSTR lpTimerName, _In_ DWORD
	// dwFlags, _In_ DWORD dwDesiredAccess); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682494(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682494")]
	[return: AddAsCtor]
	public static extern SafeWaitableTimerHandle CreateWaitableTimerEx([In, Optional] SECURITY_ATTRIBUTES? lpTimerAttributes,
		[In, Optional] string? lpTimerName, [Optional] CREATE_WAITABLE_TIMER_FLAG dwFlags, ACCESS_MASK dwDesiredAccess);

	/// <summary>Releases all resources used by an unowned critical section object.</summary>
	/// <param name="lpCriticalSection">
	/// A pointer to the critical section object. The object must have been previously initialized with the <c>InitializeCriticalSection</c> function.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// void WINAPI DeleteCriticalSection( _Inout_ LPCRITICAL_SECTION lpCriticalSection); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682552(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682552")]
	public static extern void DeleteCriticalSection(ref CRITICAL_SECTION lpCriticalSection);

	/// <summary>Deletes a synchronization barrier.</summary>
	/// <param name="lpBarrier">A pointer to the synchronization barrier to delete.</param>
	/// <returns>The <c>DeleteSynchronizationBarrier</c> function always returns <c>TRUE</c>.</returns>
	// BOOL WINAPI DeleteSynchronizationBarrier( _Inout_ LPSYNCHRONIZATION_BARRIER lpBarrier); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706887(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("SynchAPI.h", MSDNShortId = "hh706887")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteSynchronizationBarrier(ref SYNCHRONIZATION_BARRIER lpBarrier);

	/// <summary>Deletes a timer queue. Any pending timers in the queue are canceled and deleted.</summary>
	/// <param name="TimerQueue">A handle to the timer queue. This handle is returned by the <c>CreateTimerQueue</c> function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI DeleteTimerQueue( _In_ HANDLE TimerQueue); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682565(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682565")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteTimerQueue([In] IntPtr TimerQueue);

	/// <summary>
	/// Waits for ownership of the specified critical section object. The function returns when the calling thread is granted ownership.
	/// </summary>
	/// <param name="lpCriticalSection">A pointer to the critical section object.</param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// <para>
	/// This function can raise <c>EXCEPTION_POSSIBLE_DEADLOCK</c> if a wait operation on the critical section times out. The timeout
	/// interval is specified by the following registry value: <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager</c>\
	/// <c>CriticalSectionTimeout</c>. Do not handle a possible deadlock exception; instead, debug the application.
	/// </para>
	/// </returns>
	// void WINAPI EnterCriticalSection( _Inout_ LPCRITICAL_SECTION lpCriticalSection); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682608(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682608")]
	public static extern void EnterCriticalSection(ref CRITICAL_SECTION lpCriticalSection);

	/// <summary>Causes the calling thread to wait at a synchronization barrier until the maximum number of threads have entered the barrier.</summary>
	/// <param name="lpBarrier">
	/// A pointer to an initialized synchronization barrier. Use the <c>InitializeSynchronizationBarrier</c> function to initialize the
	/// barrier. <c>SYNCHRONIZATION_BARRIER</c> is an opaque structure that should not be modified by the application.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that control the behavior of threads that enter this barrier. This parameter can be one or more of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SYNCHRONIZATION_BARRIER_FLAGS_BLOCK_ONLY</term>
	/// <term>
	/// Specifies that the thread entering the barrier should block immediately until the last thread enters the barrier. For more
	/// information, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY</term>
	/// <term>
	/// Specifies that the thread entering the barrier should spin until the last thread enters the barrier, even if the spinning thread
	/// exceeds the barrier's maximum spin count. For more information, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE</term>
	/// <term>
	/// Specifies that the function can skip the work required to ensure that it is safe to delete the barrier, which can improve
	/// performance. All threads that enter this barrier must specify the flag; otherwise, the flag is ignored. This flag should be used only
	/// if the barrier will never be deleted.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <c>TRUE</c> for the last thread to signal the barrier. Threads that signal the barrier before the last thread signals it receive a
	/// return value of <c>FALSE</c>.
	/// </returns>
	// BOOL WINAPI EnterSynchronizationBarrier( _Inout_ LPSYNCHRONIZATION_BARRIER lpBarrier, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706889(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Synchapi.h", MSDNShortId = "hh706889")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnterSynchronizationBarrier(ref SYNCHRONIZATION_BARRIER lpBarrier, SYNC_BARRIER_FLAGS dwFlags);

	/// <summary>Initializes a condition variable.</summary>
	/// <param name="ConditionVariable">A pointer to the condition variable.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI InitializeConditionVariable( _Out_ PCONDITION_VARIABLE ConditionVariable); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683469(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683469")]
	public static extern void InitializeConditionVariable(out CONDITION_VARIABLE ConditionVariable);

	/// <summary>Initializes a critical section object.</summary>
	/// <param name="lpCriticalSection">A pointer to the critical section object.</param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> In low memory situations, <c>InitializeCriticalSection</c> can raise a
	/// <c>STATUS_NO_MEMORY</c> exception. Starting with Windows Vista, this exception was eliminated and <c>InitializeCriticalSection</c>
	/// always succeeds, even in low memory situations.
	/// </para>
	/// </returns>
	// void WINAPI InitializeCriticalSection( _Out_ LPCRITICAL_SECTION lpCriticalSection); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683472(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683472")]
	public static extern void InitializeCriticalSection(out CRITICAL_SECTION lpCriticalSection);

	/// <summary>
	/// Initializes a critical section object and sets the spin count for the critical section. When a thread tries to acquire a critical
	/// section that is locked, the thread spins: it enters a loop which iterates spin count times, checking to see if the lock is released.
	/// If the lock is not released before the loop finishes, the thread goes to sleep to wait for the lock to be released.
	/// </summary>
	/// <param name="lpCriticalSection">A pointer to the critical section object.</param>
	/// <param name="dwSpinCount">
	/// The spin count for the critical section object. On single-processor systems, the spin count is ignored and the critical section spin
	/// count is set to 0 (zero). On multiprocessor systems, if the critical section is unavailable, the calling thread spins dwSpinCount
	/// times before performing a wait operation on a semaphore associated with the critical section. If the critical section becomes free
	/// during the spin operation, the calling thread avoids the wait operation.
	/// </param>
	/// <returns>
	/// <para>This function always succeeds and returns a nonzero value.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> If the function succeeds, the return value is nonzero. If the function fails, the return
	/// value is zero (0). To get extended error information, call <c>GetLastError</c>. Starting with Windows Vista, the
	/// <c>InitializeCriticalSectionAndSpinCount</c> function always succeeds, even in low memory situations.
	/// </para>
	/// </returns>
	// BOOL WINAPI InitializeCriticalSectionAndSpinCount( _Out_ LPCRITICAL_SECTION lpCriticalSection, _In_ DWORD dwSpinCount); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683476(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683476")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitializeCriticalSectionAndSpinCount(out CRITICAL_SECTION lpCriticalSection, [Optional] uint dwSpinCount);

	/// <summary>Initializes a critical section object with a spin count and optional flags.</summary>
	/// <param name="lpCriticalSection">A pointer to the critical section object.</param>
	/// <param name="dwSpinCount">
	/// The spin count for the critical section object. On single-processor systems, the spin count is ignored and the critical section spin
	/// count is set to 0 (zero). On multiprocessor systems, if the critical section is unavailable, the calling thread spin dwSpinCount
	/// times before performing a wait operation on a semaphore associated with the critical section. If the critical section becomes free
	/// during the spin operation, the calling thread avoids the wait operation.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be 0 or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRITICAL_SECTION_NO_DEBUG_INFO</term>
	/// <term>The critical section is created without debug information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The threads of a single process can use a critical section object for mutual-exclusion synchronization. There is no guarantee about
	/// the order that threads obtain ownership of the critical section, however, the system is fair to all threads.
	/// </para>
	/// <para>
	/// The process is responsible for allocating the memory used by a critical section object, which it can do by declaring a variable of
	/// type <c>CRITICAL_SECTION</c>. Before using a critical section, some thread of the process must initialize the object. You can
	/// subsequently modify the spin count by calling the SetCriticalSectionSpinCount function.
	/// </para>
	/// <para>
	/// After a critical section object is initialized, the threads of the process can specify the object in the EnterCriticalSection,
	/// TryEnterCriticalSection, or LeaveCriticalSection function to provide mutually exclusive access to a shared resource. For similar
	/// synchronization between the threads of different processes, use a mutex object.
	/// </para>
	/// <para>
	/// A critical section object cannot be moved or copied. The process must also not modify the object, but must treat it as logically
	/// opaque. Use only the critical section functions to manage critical section objects. When you have finished using the critical
	/// section, call the DeleteCriticalSection function.
	/// </para>
	/// <para>
	/// A critical section object must be deleted before it can be reinitialized. Initializing a critical section that is already initialized
	/// results in undefined behavior.
	/// </para>
	/// <para>
	/// The spin count is useful for critical sections of short duration that can experience high levels of contention. Consider a worst-case
	/// scenario, in which an application on an SMP system has two or three threads constantly allocating and releasing memory from the heap.
	/// The application serializes the heap with a critical section. In the worst-case scenario, contention for the critical section is
	/// constant, and each thread makes an processing-intensive call to the WaitForSingleObject function. However, if the spin count is set
	/// properly, the calling thread does not immediately call <c>WaitForSingleObject</c> when contention occurs. Instead, the calling thread
	/// can acquire ownership of the critical section if it is released during the spin operation.
	/// </para>
	/// <para>
	/// You can improve performance significantly by choosing a small spin count for a critical section of short duration. The heap manager
	/// uses a spin count of roughly 4000 for its per-heap critical sections. This gives great performance and scalability in almost all
	/// worst-case scenarios.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initializecriticalsectionex BOOL InitializeCriticalSectionEx(
	// LPCRITICAL_SECTION lpCriticalSection, DWORD dwSpinCount, DWORD Flags );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("synchapi.h", MSDNShortId = "da84b187-0eb7-4363-8e68-8a525586d7d9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitializeCriticalSectionEx(out CRITICAL_SECTION lpCriticalSection, [Optional] uint dwSpinCount,
		[Optional] CRITICAL_SECTION_FLAGS Flags);

	/// <summary>Initialize a slim reader/writer (SRW) lock.</summary>
	/// <param name="SRWLock">A pointer to the SRW lock.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI InitializeSRWLock( _Out_ PSRWLOCK SRWLock); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683483(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683483")]
	public static extern void InitializeSRWLock(out SRWLOCK SRWLock);

	/// <summary>Initializes a new synchronization barrier.</summary>
	/// <param name="lpBarrier">
	/// A pointer to the <c>SYNCHRONIZATION_BARRIER</c> structure to initialize. This is an opaque structure that should not be modified by applications.
	/// </param>
	/// <param name="lTotalThreads">
	/// The maximum number of threads that can enter this barrier. After the maximum number of threads have entered the barrier, all threads continue.
	/// </param>
	/// <param name="lSpinCount">
	/// The number of times an individual thread should spin while waiting for other threads to arrive at the barrier. If this parameter is
	/// -1, the thread spins 2000 times. If the thread exceeds lSpinCount, the thread blocks unless it called
	/// <c>EnterSynchronizationBarrier</c> with <c>SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY</c>.
	/// </param>
	/// <returns>
	/// <c>TRUE</c> if the barrier was successfully initialized. If the barrier was not successfully initialized, this function returns
	/// <c>FALSE</c>. Use <c>GetLastError</c> to get extended error information.
	/// </returns>
	// BOOL WINAPI InitializeSynchronizationBarrier( _Out_ LPSYNCHRONIZATION_BARRIER lpBarrier, _In_ LONG lTotalThreads, _In_ LONG
	// lSpinCount); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706890(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("SynchAPI.h", MSDNShortId = "hh706890")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitializeSynchronizationBarrier(out SYNCHRONIZATION_BARRIER lpBarrier, int lTotalThreads, int lSpinCount);

	/// <summary>Begins one-time initialization.</summary>
	/// <param name="lpInitOnce">A pointer to the one-time initialization structure.</param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one or more of the following flags.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INIT_ONCE_ASYNC = 0x00000002UL</term>
	/// <term>
	/// Enables multiple initialization attempts to execute in parallel. If this flag is used, subsequent calls to this function will fail
	/// unless this flag is also specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INIT_ONCE_CHECK_ONLY = 0x00000001UL</term>
	/// <term>
	/// This function call does not begin initialization. The return value indicates whether initialization has already completed. If the
	/// function returns TRUE, the lpContext parameter receives the data.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="fPending">
	/// <para>If the function succeeds, this parameter indicates the current initialization status.</para>
	/// <para>
	/// If this parameter is <c>TRUE</c> and dwFlags contains <c>INIT_ONCE_CHECK_ONLY</c>, the initialization is pending and the context data
	/// is invalid.
	/// </para>
	/// <para>
	/// If this parameter is <c>FALSE</c>, initialization has already completed and the caller can retrieve the context data from the
	/// lpContext parameter.
	/// </para>
	/// <para>
	/// If this parameter is <c>TRUE</c> and dwFlags does not contain <c>INIT_ONCE_CHECK_ONLY</c>, initialization has been started and the
	/// caller can perform the initialization tasks.
	/// </para>
	/// </param>
	/// <param name="lpContext">
	/// An optional parameter that receives the data stored with the one-time initialization structure upon success. The low-order
	/// <c>INIT_ONCE_CTX_RESERVED_BITS</c> bits of the data are always zero.
	/// </param>
	/// <returns>
	/// <para>If <c>INIT_ONCE_CHECK_ONLY</c> is not specified and the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If <c>INIT_ONCE_CHECK_ONLY</c> is specified and initialization has completed, the return value is <c>TRUE</c>.</para>
	/// <para>Otherwise, the return value is <c>FALSE</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI InitOnceBeginInitialize( _Inout_ LPINIT_ONCE lpInitOnce, _In_ DWORD dwFlags, _Out_ PBOOL fPending, _Out_opt_ LPVOID
	// *lpContext); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683487(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683487")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitOnceBeginInitialize(ref INIT_ONCE lpInitOnce, INIT_ONCE_FLAGS dwFlags,
		[MarshalAs(UnmanagedType.Bool)] out bool fPending, [Optional] out IntPtr lpContext);

	/// <summary>Completes one-time initialization started with the <c>InitOnceBeginInitialize</c> function.</summary>
	/// <param name="lpInitOnce">A pointer to the one-time initialization structure.</param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following flags.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INIT_ONCE_ASYNC0x00000002UL</term>
	/// <term>
	/// Operate in asynchronous mode. This enables multiple completion attempts to execute in parallel. This flag must match the flag passed
	/// in the corresponding call to the InitOnceBeginInitialize function. This flag may not be combined with INIT_ONCE_INIT_FAILED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INIT_ONCE_INIT_FAILED0x00000004UL</term>
	/// <term>
	/// The initialization attempt failed. This flag may not be combined with INIT_ONCE_ASYNC. To fail an asynchronous initialization, merely
	/// abandon it (that is, do not call the InitOnceComplete function).
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpContext">
	/// A pointer to the data to be stored with the one-time initialization structure. This data is returned in the lpContext parameter
	/// passed to subsequent calls to the <c>InitOnceBeginInitialize</c> function. If lpContext points to a value, the low-order
	/// <c>INIT_ONCE_CTX_RESERVED_BITS</c> of the value must be zero. If lpContext points to a data structure, the data structure must be <c>DWORD</c>-aligned.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI InitOnceComplete( _Inout_ LPINIT_ONCE lpInitOnce, _In_ DWORD dwFlags, _In_opt_ LPVOID lpContext); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683491(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683491")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitOnceComplete(ref INIT_ONCE lpInitOnce, INIT_ONCE_FLAGS dwFlags, [Optional] IntPtr lpContext);

	/// <summary>
	/// Executes the specified function successfully one time. No other threads that specify the same one-time initialization structure can
	/// execute the specified function while it is being executed by the current thread.
	/// </summary>
	/// <param name="InitOnce">A pointer to the one-time initialization structure.</param>
	/// <param name="InitFn">A pointer to an application-defined InitOnceCallback function.</param>
	/// <param name="Parameter">A parameter to be passed to the callback function.</param>
	/// <param name="Context">
	/// A parameter that receives data stored with the one-time initialization structure upon success. The low-order
	/// <c>INIT_ONCE_CTX_RESERVED_BITS</c> bits of the data are always zero.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI InitOnceExecuteOnce( _Inout_ PINIT_ONCE InitOnce, _In_ PINIT_ONCE_FN InitFn, _Inout_opt_ PVOID Parameter, _Out_opt_ LPVOID
	// *Context); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683493(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683493")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitOnceExecuteOnce(ref INIT_ONCE InitOnce, InitOnceCallback InitFn, [Optional] IntPtr Parameter, [Optional] out IntPtr Context);

	/// <summary>Initializes a one-time initialization structure.</summary>
	/// <param name="InitOnce">A pointer to the one-time initialization structure.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI InitOnceInitialize( _Out_ PINIT_ONCE InitOnce); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683495(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683495")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitOnceInitialize(out INIT_ONCE InitOnce);

	/// <summary>
	/// <para>
	/// Performs an atomic compare-and-exchange operation on the specified values. The function compares two specified 32-bit values and
	/// exchanges with another 32-bit value based on the outcome of the comparison.
	/// </para>
	/// <para>If you are exchanging pointer values, this function has been superseded by the <c>InterlockedCompareExchangePointer</c> function.</para>
	/// <para>To operate on 64-bit values, use the <c>InterlockedCompareExchange64</c> function.</para>
	/// </summary>
	/// <param name="Destination">A pointer to the destination value.</param>
	/// <param name="Exchange">The exchange value.</param>
	/// <param name="Comparand">The value to compare to Destination.</param>
	/// <returns>The function returns the initial value of the Destination parameter.</returns>
	// LONG __cdecl InterlockedCompareExchange( _Inout_ LONG volatile *Destination, _In_ LONG Exchange, _In_ LONG Comparand); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683560(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms683560")]
	public static int InterlockedCompareExchange(ref int Destination, int Exchange, int Comparand) => Interlocked.CompareExchange(ref Destination, Exchange, Comparand);

	/// <summary>
	/// <para>Decrements (decreases by one) the value of the specified 32-bit variable as an atomic operation.</para>
	/// <para>To operate on 64-bit values, use the <c>InterlockedDecrement64</c> function.</para>
	/// </summary>
	/// <param name="Addend">A pointer to the variable to be decremented.</param>
	/// <returns>The function returns the resulting decremented value.</returns>
	// LONG __cdecl InterlockedDecrement( _Inout_ LONG volatile *Addend); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683580(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms683580")]
	public static int InterlockedDecrement(ref int Addend) => Interlocked.Decrement(ref Addend);

	/// <summary>
	/// <para>Sets a 32-bit variable to the specified value as an atomic operation.</para>
	/// <para>To operate on a pointer variable, use the <c>InterlockedExchangePointer</c> function.</para>
	/// <para>To operate on a 16-bit variable, use the <c>InterlockedExchange16</c> function.</para>
	/// <para>To operate on a 64-bit variable, use the <c>InterlockedExchange64</c> function.</para>
	/// </summary>
	/// <param name="Target">A pointer to the value to be exchanged. The function sets this variable to Value, and returns its prior value.</param>
	/// <param name="Value">The value to be exchanged with the value pointed to by Target.</param>
	/// <returns>The function returns the initial value of the Target parameter.</returns>
	// LONG __cdecl InterlockedExchange( _Inout_ LONG volatile *Target, _In_ LONG Value); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683590(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms683590")]
	public static int InterlockedExchange(ref int Target, int Value) => Interlocked.Exchange(ref Target, Value);

	/// <summary>
	/// <para>Performs an atomic addition of two 32-bit values.</para>
	/// <para>To operate on 64-bit values, use the <c>InterlockedExchangeAdd64</c> function.</para>
	/// </summary>
	/// <param name="Addend">A pointer to a variable. The value of this variable will be replaced with the result of the operation.</param>
	/// <param name="Value">The value to be added to the variable pointed to by the Addend parameter.</param>
	/// <returns>The function returns the initial value of the Addend parameter.</returns>
	// LONG __cdecl InterlockedExchangeAdd( _Inout_ LONG volatile *Addend, _In_ LONG Value); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683597(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms683597")]
	public static int InterlockedExchangeAdd(ref int Addend, int Value) => throw new NotImplementedException("Machine level export not found in Kernel32.dll or .NET assemblies.");

	/// <summary>
	/// <para>Increments (increases by one) the value of the specified 32-bit variable as an atomic operation.</para>
	/// <para>To operate on 64-bit values, use the <c>InterlockedIncrement64</c> function.</para>
	/// </summary>
	/// <param name="Addend">A pointer to the variable to be incremented.</param>
	/// <returns>The function returns the resulting incremented value.</returns>
	// LONG __cdecl InterlockedIncrement( _Inout_ LONG volatile *Addend); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683614(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms683614")]
	public static int InterlockedIncrement(ref int Addend) => Interlocked.Increment(ref Addend);

	/// <summary>Releases ownership of the specified critical section object.</summary>
	/// <param name="lpCriticalSection">A pointer to the critical section object.</param>
	/// <returns>This function does not return a value.</returns>
	// void WINAPI LeaveCriticalSection( _Inout_ LPCRITICAL_SECTION lpCriticalSection); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684169(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms684169")]
	public static extern void LeaveCriticalSection(ref CRITICAL_SECTION lpCriticalSection);

	/// <summary>Opens an existing named event object.</summary>
	/// <param name="dwDesiredAccess">
	/// The access to the event object. The function fails if the security descriptor of the specified object does not permit the requested
	/// access for the calling process. For a list of access rights, see Synchronization Object Security and Access Rights.
	/// </param>
	/// <param name="bInheritHandle">
	/// If this value is <c>TRUE</c>, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.
	/// </param>
	/// <param name="lpName">
	/// <para>The name of the event to be opened. Name comparisons are case sensitive.</para>
	/// <para>This function can open objects in a private namespace. For more information, see Object Namespaces.</para>
	/// <para>
	/// <c>Terminal Services:</c> The name can have a "Global\" or "Local\" prefix to explicitly open an object in the global or session
	/// namespace. The remainder of the name can contain any character except the backslash character (\). For more information, see Kernel
	/// Object Namespaces.
	/// </para>
	/// <para>
	/// <c>Note</c> Fast user switching is implemented using Terminal Services sessions. The first user to log on uses session 0, the next
	/// user to log on uses session 1, and so on. Kernel object names must follow the guidelines outlined for Terminal Services so that
	/// applications can support multiple users.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the event object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI OpenEvent( _In_ DWORD dwDesiredAccess, _In_ BOOL bInheritHandle, _In_ LPCTSTR lpName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684305(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms684305")]
	[return: AddAsCtor]
	public static extern SafeEventHandle OpenEvent(ACCESS_MASK dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, string lpName);

	/// <summary>Opens an existing named mutex object.</summary>
	/// <param name="dwDesiredAccess">
	/// The access to the mutex object. Only the <c>SYNCHRONIZE</c> access right is required to use a mutex; to change the mutex's security,
	/// specify <c>MUTEX_ALL_ACCESS</c>. The function fails if the security descriptor of the specified object does not permit the requested
	/// access for the calling process. For a list of access rights, see Synchronization Object Security and Access Rights.
	/// </param>
	/// <param name="bInheritHandle">
	/// If this value is <c>TRUE</c>, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.
	/// </param>
	/// <param name="lpName">
	/// <para>The name of the mutex to be opened. Name comparisons are case sensitive.</para>
	/// <para>This function can open objects in a private namespace. For more information, see Object Namespaces.</para>
	/// <para>
	/// <c>Terminal Services:</c> The name can have a "Global\" or "Local\" prefix to explicitly open an object in the global or session
	/// namespace. The remainder of the name can contain any character except the backslash character (\). For more information, see Kernel
	/// Object Namespaces.
	/// </para>
	/// <para>
	/// <c>Note</c> Fast user switching is implemented using Terminal Services sessions. The first user to log on uses session 0, the next
	/// user to log on uses session 1, and so on. Kernel object names must follow the guidelines outlined for Terminal Services so that
	/// applications can support multiple users.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the mutex object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// <para>If a named mutex does not exist, the function fails and <c>GetLastError</c> returns <c>ERROR_FILE_NOT_FOUND</c>.</para>
	/// </returns>
	// HANDLE WINAPI OpenMutex( _In_ DWORD dwDesiredAccess, _In_ BOOL bInheritHandle, _In_ LPCTSTR lpName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684315(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms684315")]
	[return: AddAsCtor]
	public static extern SafeMutexHandle OpenMutex(ACCESS_MASK dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, string lpName);

	/// <summary>Opens an existing named semaphore object.</summary>
	/// <param name="dwDesiredAccess">
	/// The access to the semaphore object. The function fails if the security descriptor of the specified object does not permit the
	/// requested access for the calling process. For a list of access rights, see Synchronization Object Security and Access Rights.
	/// </param>
	/// <param name="bInheritHandle">
	/// If this value is <c>TRUE</c>, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.
	/// </param>
	/// <param name="lpName">
	/// <para>The name of the semaphore to be opened. Name comparisons are case sensitive.</para>
	/// <para>This function can open objects in a private namespace. For more information, see Object Namespaces.</para>
	/// <para>
	/// <c>Terminal Services:</c> The name can have a "Global\" or "Local\" prefix to explicitly open an object in the global or session
	/// namespace. The remainder of the name can contain any character except the backslash character (\). For more information, see Kernel
	/// Object Namespaces.
	/// </para>
	/// <para>
	/// <c>Note</c> Fast user switching is implemented using Terminal Services sessions. The first user to log on uses session 0, the next
	/// user to log on uses session 1, and so on. Kernel object names must follow the guidelines outlined for Terminal Services so that
	/// applications can support multiple users.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the semaphore object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI OpenSemaphore( _In_ DWORD dwDesiredAccess, _In_ BOOL bInheritHandle, _In_ LPCTSTR lpName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684326(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms684326")]
	[return: AddAsCtor]
	public static extern SafeSemaphoreHandle OpenSemaphore(ACCESS_MASK dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, string lpName);

	/// <summary>Opens an existing named waitable timer object.</summary>
	/// <param name="dwDesiredAccess">
	/// The access to the timer object. The function fails if the security descriptor of the specified object does not permit the requested
	/// access for the calling process. For a list of access rights, see Synchronization Object Security and Access Rights.
	/// </param>
	/// <param name="bInheritHandle">
	/// If this value is <c>TRUE</c>, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.
	/// </param>
	/// <param name="lpTimerName">
	/// <para>The name of the timer object. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case sensitive.</para>
	/// <para>This function can open objects in a private namespace. For more information, see Object Namespaces.</para>
	/// <para>
	/// <c>Terminal Services:</c> The name can have a "Global\" or "Local\" prefix to explicitly open an object in the global or session
	/// namespace. The remainder of the name can contain any character except the backslash character (\). For more information, see Kernel
	/// Object Namespaces.
	/// </para>
	/// <para>
	/// <c>Note</c> Fast user switching is implemented using Terminal Services sessions. The first user to log on uses session 0, the next
	/// user to log on uses session 1, and so on. Kernel object names must follow the guidelines outlined for Terminal Services so that
	/// applications can support multiple users.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the timer object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI OpenWaitableTimer( _In_ DWORD dwDesiredAccess, _In_ BOOL bInheritHandle, _In_ LPCTSTR lpTimerName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684337(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms684337")]
	[return: AddAsCtor]
	public static extern SafeWaitableTimerHandle OpenWaitableTimer(ACCESS_MASK dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, string lpTimerName);

	/// <summary>
	/// Sets the specified event object to the signaled state and then resets it to the nonsignaled state after releasing the appropriate
	/// number of waiting threads.
	/// </summary>
	/// <param name="hEvent">
	/// <para>A handle to the event object. The <c>CreateEvent</c> or <c>OpenEvent</c> function returns this handle.</para>
	/// <para>
	/// The handle must have the EVENT_MODIFY_STATE access right. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI PulseEvent( _In_ HANDLE hEvent); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684914(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms684914")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PulseEvent([In, AddAsMember] HEVENT hEvent);

	/// <summary>Releases ownership of the specified mutex object.</summary>
	/// <param name="hMutex">A handle to the mutex object. The <c>CreateMutex</c> or <c>OpenMutex</c> function returns this handle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI ReleaseMutex( _In_ HANDLE hMutex); https://msdn.microsoft.com/en-us/library/windows/desktop/ms685066(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms685066")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReleaseMutex([In, AddAsMember] SafeMutexHandle hMutex);

	/// <summary>Increases the count of the specified semaphore object by a specified amount.</summary>
	/// <param name="hSemaphore">
	/// <para>A handle to the semaphore object. The <c>CreateSemaphore</c> or <c>OpenSemaphore</c> function returns this handle.</para>
	/// <para>
	/// This handle must have the <c>SEMAPHORE_MODIFY_STATE</c> access right. For more information, see Synchronization Object Security and
	/// Access Rights.
	/// </para>
	/// </param>
	/// <param name="lReleaseCount">
	/// The amount by which the semaphore object's current count is to be increased. The value must be greater than zero. If the specified
	/// amount would cause the semaphore's count to exceed the maximum count that was specified when the semaphore was created, the count is
	/// not changed and the function returns <c>FALSE</c>.
	/// </param>
	/// <param name="lpPreviousCount">
	/// A pointer to a variable to receive the previous count for the semaphore. This parameter can be <c>NULL</c> if the previous count is
	/// not required.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI ReleaseSemaphore( _In_ HANDLE hSemaphore, _In_ LONG lReleaseCount, _Out_opt_ LPLONG lpPreviousCount); https://msdn.microsoft.com/en-us/library/windows/desktop/ms685071(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms685071")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReleaseSemaphore([In, AddAsMember] SafeSemaphoreHandle hSemaphore, int lReleaseCount, out int lpPreviousCount);

	/// <summary>Releases a slim reader/writer (SRW) lock that was acquired in exclusive mode.</summary>
	/// <param name="SRWLock">A pointer to the SRW lock.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI ReleaseSRWLockExclusive( _Inout_ PSRWLOCK SRWLock); https://msdn.microsoft.com/en-us/library/windows/desktop/ms685076(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms685076")]
	public static extern void ReleaseSRWLockExclusive(ref SRWLOCK SRWLock);

	/// <summary>Releases a slim reader/writer (SRW) lock that was acquired in shared mode.</summary>
	/// <param name="SRWLock">A pointer to the SRW lock.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI ReleaseSRWLockShared( _Inout_ PSRWLOCK SRWLock); https://msdn.microsoft.com/en-us/library/windows/desktop/ms685080(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms685080")]
	public static extern void ReleaseSRWLockShared(ref SRWLOCK SRWLock);

	/// <summary>Sets the specified event object to the nonsignaled state.</summary>
	/// <param name="hEvent">
	/// <para>A handle to the event object. The <c>CreateEvent</c> or <c>OpenEvent</c> function returns this handle.</para>
	/// <para>
	/// The handle must have the EVENT_MODIFY_STATE access right. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI ResetEvent( _In_ HANDLE hEvent); https://msdn.microsoft.com/en-us/library/windows/desktop/ms685081(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms685081")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ResetEvent([In, AddAsMember] HEVENT hEvent);

	/// <summary>
	/// Sets the spin count for the specified critical section. Spinning means that when a thread tries to acquire a critical section that is
	/// locked, the thread enters a loop, checks to see if the lock is released, and if the lock is not released, the thread goes to sleep.
	/// </summary>
	/// <param name="lpCriticalSection">A pointer to the critical section object.</param>
	/// <param name="dwSpinCount">
	/// The spin count for the critical section object. On single-processor systems, the spin count is ignored and the critical section spin
	/// count is set to zero (0). On multiprocessor systems, if the critical section is unavailable, the calling thread spins dwSpinCount
	/// times before performing a wait operation on a semaphore associated with the critical section. If the critical section becomes free
	/// during the spin operation, the calling thread avoids the wait operation.
	/// </param>
	/// <returns>The function returns the previous spin count for the critical section.</returns>
	// DWORD WINAPI SetCriticalSectionSpinCount( _Inout_ LPCRITICAL_SECTION lpCriticalSection, _In_ DWORD dwSpinCount); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686197(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686197")]
	public static extern uint SetCriticalSectionSpinCount(ref CRITICAL_SECTION lpCriticalSection, uint dwSpinCount);

	/// <summary>Sets the specified event object to the signaled state.</summary>
	/// <param name="hEvent">
	/// <para>A handle to the event object. The <c>CreateEvent</c> or <c>OpenEvent</c> function returns this handle.</para>
	/// <para>
	/// The handle must have the EVENT_MODIFY_STATE access right. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetEvent( _In_ HANDLE hEvent); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686211(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686211")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetEvent([In, AddAsMember] HEVENT hEvent);

	/// <summary>
	/// Activates the specified waitable timer. When the due time arrives, the timer is signaled and the thread that set the timer calls the
	/// optional completion routine.
	/// </summary>
	/// <param name="hTimer">
	/// <para>A handle to the timer object. The <c>CreateWaitableTimer</c> or <c>OpenWaitableTimer</c> function returns this handle.</para>
	/// <para>
	/// The handle must have the <c>TIMER_MODIFY_STATE</c> access right. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="pDueTime">
	/// The time after which the state of the timer is to be set to signaled, in 100 nanosecond intervals. Use the format described by the
	/// <c>FILETIME</c> structure. Positive values indicate absolute time. Be sure to use a UTC-based absolute time, as the system uses
	/// UTC-based time internally. Negative values indicate relative time. The actual timer accuracy depends on the capability of your
	/// hardware. For more information about UTC-based time, see System Time.
	/// </param>
	/// <param name="lPeriod">
	/// The period of the timer, in milliseconds. If lPeriod is zero, the timer is signaled once. If lPeriod is greater than zero, the timer
	/// is periodic. A periodic timer automatically reactivates each time the period elapses, until the timer is canceled using the
	/// <c>CancelWaitableTimer</c> function or reset using <c>SetWaitableTimer</c>. If lPeriod is less than zero, the function fails.
	/// </param>
	/// <param name="pfnCompletionRoutine">
	/// A pointer to an optional completion routine. The completion routine is application-defined function of type <c>PTIMERAPCROUTINE</c>
	/// to be executed when the timer is signaled. For more information on the timer callback function, see <c>TimerAPCProc</c>. For more
	/// information about APCs and thread pool threads, see Remarks.
	/// </param>
	/// <param name="lpArgToCompletionRoutine">A pointer to a structure that is passed to the completion routine.</param>
	/// <param name="fResume">
	/// If this parameter is <c>TRUE</c>, restores a system in suspended power conservation mode when the timer state is set to signaled.
	/// Otherwise, the system is not restored. If the system does not support a restore, the call succeeds, but <c>GetLastError</c> returns <c>ERROR_NOT_SUPPORTED</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetWaitableTimer( _In_ HANDLE hTimer, _In_ const LARGE_INTEGER *pDueTime, _In_ LONG lPeriod, _In_opt_ PTIMERAPCROUTINE
	// pfnCompletionRoutine, _In_opt_ LPVOID lpArgToCompletionRoutine, _In_ BOOL fResume); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686289(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686289")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWaitableTimer([In] SafeWaitableTimerHandle hTimer, in FILETIME pDueTime, [Optional] int lPeriod,
		[Optional] TimerAPCProc? pfnCompletionRoutine, [In, Optional] IntPtr lpArgToCompletionRoutine, [MarshalAs(UnmanagedType.Bool)] bool fResume = false);

	/// <summary>
	/// Activates the specified waitable timer. When the due time arrives, the timer is signaled and the thread that set the timer calls the
	/// optional completion routine.
	/// </summary>
	/// <param name="hTimer">
	/// <para>A handle to the timer object. The <c>CreateWaitableTimer</c> or <c>OpenWaitableTimer</c> function returns this handle.</para>
	/// <para>
	/// The handle must have the <c>TIMER_MODIFY_STATE</c> access right. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="pDueTime">
	/// The time after which the state of the timer is to be set to signaled, in 100 nanosecond intervals. Use the format described by the
	/// <c>FILETIME</c> structure. Positive values indicate absolute time. Be sure to use a UTC-based absolute time, as the system uses
	/// UTC-based time internally. Negative values indicate relative time. The actual timer accuracy depends on the capability of your
	/// hardware. For more information about UTC-based time, see System Time.
	/// </param>
	/// <param name="lPeriod">
	/// The period of the timer, in milliseconds. If lPeriod is zero, the timer is signaled once. If lPeriod is greater than zero, the timer
	/// is periodic. A periodic timer automatically reactivates each time the period elapses, until the timer is canceled using the
	/// <c>CancelWaitableTimer</c> function or reset using <c>SetWaitableTimer</c>. If lPeriod is less than zero, the function fails.
	/// </param>
	/// <param name="pfnCompletionRoutine">
	/// A pointer to an optional completion routine. The completion routine is application-defined function of type <c>PTIMERAPCROUTINE</c>
	/// to be executed when the timer is signaled. For more information on the timer callback function, see <c>TimerAPCProc</c>. For more
	/// information about APCs and thread pool threads, see Remarks.
	/// </param>
	/// <param name="lpArgToCompletionRoutine">A pointer to a structure that is passed to the completion routine.</param>
	/// <param name="fResume">
	/// If this parameter is <c>TRUE</c>, restores a system in suspended power conservation mode when the timer state is set to signaled.
	/// Otherwise, the system is not restored. If the system does not support a restore, the call succeeds, but <c>GetLastError</c> returns <c>ERROR_NOT_SUPPORTED</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetWaitableTimer( _In_ HANDLE hTimer, _In_ const LARGE_INTEGER *pDueTime, _In_ LONG lPeriod, _In_opt_ PTIMERAPCROUTINE
	// pfnCompletionRoutine, _In_opt_ LPVOID lpArgToCompletionRoutine, _In_ BOOL fResume); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686289(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686289")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWaitableTimer([In] SafeWaitableTimerHandle hTimer, in long pDueTime, [Optional] int lPeriod, [Optional] TimerAPCProc? pfnCompletionRoutine,
		[In, Optional] IntPtr lpArgToCompletionRoutine, [MarshalAs(UnmanagedType.Bool)] bool fResume = false);

	/// <summary>
	/// Activates the specified waitable timer and provides context information for the timer. When the due time arrives, the timer is
	/// signaled and the thread that set the timer calls the optional completion routine.
	/// </summary>
	/// <param name="hTimer">
	/// <para>A handle to the timer object. The <c>CreateWaitableTimer</c> or <c>OpenWaitableTimer</c> function returns this handle.</para>
	/// <para>
	/// The handle must have the <c>TIMER_MODIFY_STATE</c> access right. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpDueTime">
	/// The time after which the state of the timer is to be set to signaled, in 100 nanosecond intervals. Use the format described by the
	/// <c>FILETIME</c> structure. Positive values indicate absolute time. Be sure to use a UTC-based absolute time, as the system uses
	/// UTC-based time internally. Negative values indicate relative time. The actual timer accuracy depends on the capability of your
	/// hardware. For more information about UTC-based time, see System Time.
	/// </param>
	/// <param name="lPeriod">
	/// The period of the timer, in milliseconds. If lPeriod is zero, the timer is signaled once. If lPeriod is greater than zero, the timer
	/// is periodic. A periodic timer automatically reactivates each time the period elapses, until the timer is canceled using the
	/// <c>CancelWaitableTimer</c> function or reset using <c>SetWaitableTimerEx</c>. If lPeriod is less than zero, the function fails.
	/// </param>
	/// <param name="pfnCompletionRoutine">
	/// A pointer to an optional completion routine. The completion routine is application-defined function of type <c>PTIMERAPCROUTINE</c>
	/// to be executed when the timer is signaled. For more information on the timer callback function, see <c>TimerAPCProc</c>. For more
	/// information about APCs and thread pool threads, see Remarks.
	/// </param>
	/// <param name="lpArgToCompletionRoutine">A pointer to a structure that is passed to the completion routine.</param>
	/// <param name="WakeContext">Pointer to a <c>REASON_CONTEXT</c> structure that contains context information for the timer.</param>
	/// <param name="TolerableDelay">The tolerable delay for expiration time, in milliseconds.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetWaitableTimerEx( _In_ HANDLE hTimer, _In_ const LARGE_INTEGER *lpDueTime, _In_ LONG lPeriod, _In_ PTIMERAPCROUTINE
	// pfnCompletionRoutine, _In_ LPVOID lpArgToCompletionRoutine, _In_ PREASON_CONTEXT WakeContext, _In_ ULONG TolerableDelay); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405521(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "dd405521")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWaitableTimerEx([In, AddAsMember] SafeWaitableTimerHandle hTimer, in FILETIME lpDueTime, [Optional] int lPeriod, [Optional] TimerAPCProc? pfnCompletionRoutine,
		[In, Optional] IntPtr lpArgToCompletionRoutine, [In] REASON_CONTEXT WakeContext, uint TolerableDelay);

	/// <summary>
	/// Activates the specified waitable timer and provides context information for the timer. When the due time arrives, the timer is
	/// signaled and the thread that set the timer calls the optional completion routine.
	/// </summary>
	/// <param name="hTimer">
	/// <para>A handle to the timer object. The <c>CreateWaitableTimer</c> or <c>OpenWaitableTimer</c> function returns this handle.</para>
	/// <para>
	/// The handle must have the <c>TIMER_MODIFY_STATE</c> access right. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpDueTime">
	/// The time after which the state of the timer is to be set to signaled, in 100 nanosecond intervals. Use the format described by the
	/// <c>FILETIME</c> structure. Positive values indicate absolute time. Be sure to use a UTC-based absolute time, as the system uses
	/// UTC-based time internally. Negative values indicate relative time. The actual timer accuracy depends on the capability of your
	/// hardware. For more information about UTC-based time, see System Time.
	/// </param>
	/// <param name="lPeriod">
	/// The period of the timer, in milliseconds. If lPeriod is zero, the timer is signaled once. If lPeriod is greater than zero, the timer
	/// is periodic. A periodic timer automatically reactivates each time the period elapses, until the timer is canceled using the
	/// <c>CancelWaitableTimer</c> function or reset using <c>SetWaitableTimerEx</c>. If lPeriod is less than zero, the function fails.
	/// </param>
	/// <param name="pfnCompletionRoutine">
	/// A pointer to an optional completion routine. The completion routine is application-defined function of type <c>PTIMERAPCROUTINE</c>
	/// to be executed when the timer is signaled. For more information on the timer callback function, see <c>TimerAPCProc</c>. For more
	/// information about APCs and thread pool threads, see Remarks.
	/// </param>
	/// <param name="lpArgToCompletionRoutine">A pointer to a structure that is passed to the completion routine.</param>
	/// <param name="WakeContext">Pointer to a <c>REASON_CONTEXT</c> structure that contains context information for the timer.</param>
	/// <param name="TolerableDelay">The tolerable delay for expiration time, in milliseconds.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetWaitableTimerEx( _In_ HANDLE hTimer, _In_ const LARGE_INTEGER *lpDueTime, _In_ LONG lPeriod, _In_ PTIMERAPCROUTINE
	// pfnCompletionRoutine, _In_ LPVOID lpArgToCompletionRoutine, _In_ PREASON_CONTEXT WakeContext, _In_ ULONG TolerableDelay); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405521(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "dd405521")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWaitableTimerEx([In] SafeWaitableTimerHandle hTimer, in long lpDueTime, [Optional] int lPeriod, [Optional] TimerAPCProc? pfnCompletionRoutine,
		[In, Optional] IntPtr lpArgToCompletionRoutine, [In] REASON_CONTEXT WakeContext, uint TolerableDelay);

	/// <summary>
	/// Activates the specified waitable timer and provides context information for the timer. When the due time arrives, the timer is
	/// signaled and the thread that set the timer calls the optional completion routine.
	/// </summary>
	/// <param name="hTimer">
	/// <para>A handle to the timer object. The <c>CreateWaitableTimer</c> or <c>OpenWaitableTimer</c> function returns this handle.</para>
	/// <para>
	/// The handle must have the <c>TIMER_MODIFY_STATE</c> access right. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpDueTime">
	/// The time after which the state of the timer is to be set to signaled, in 100 nanosecond intervals. Use the format described by the
	/// <c>FILETIME</c> structure. Positive values indicate absolute time. Be sure to use a UTC-based absolute time, as the system uses
	/// UTC-based time internally. Negative values indicate relative time. The actual timer accuracy depends on the capability of your
	/// hardware. For more information about UTC-based time, see System Time.
	/// </param>
	/// <param name="lPeriod">
	/// The period of the timer, in milliseconds. If lPeriod is zero, the timer is signaled once. If lPeriod is greater than zero, the timer
	/// is periodic. A periodic timer automatically reactivates each time the period elapses, until the timer is canceled using the
	/// <c>CancelWaitableTimer</c> function or reset using <c>SetWaitableTimerEx</c>. If lPeriod is less than zero, the function fails.
	/// </param>
	/// <param name="pfnCompletionRoutine">
	/// A pointer to an optional completion routine. The completion routine is application-defined function of type <c>PTIMERAPCROUTINE</c>
	/// to be executed when the timer is signaled. For more information on the timer callback function, see <c>TimerAPCProc</c>. For more
	/// information about APCs and thread pool threads, see Remarks.
	/// </param>
	/// <param name="lpArgToCompletionRoutine">A pointer to a structure that is passed to the completion routine.</param>
	/// <param name="WakeContext">Pointer to a <c>REASON_CONTEXT</c> structure that contains context information for the timer.</param>
	/// <param name="TolerableDelay">The tolerable delay for expiration time, in milliseconds.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetWaitableTimerEx( _In_ HANDLE hTimer, _In_ const LARGE_INTEGER *lpDueTime, _In_ LONG lPeriod, _In_ PTIMERAPCROUTINE
	// pfnCompletionRoutine, _In_ LPVOID lpArgToCompletionRoutine, _In_ PREASON_CONTEXT WakeContext, _In_ ULONG TolerableDelay); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405521(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "dd405521")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWaitableTimerEx([In, AddAsMember] SafeWaitableTimerHandle hTimer, in FILETIME lpDueTime, [Optional] int lPeriod, [Optional] TimerAPCProc? pfnCompletionRoutine,
		[In, Optional] IntPtr lpArgToCompletionRoutine, [Optional] IntPtr WakeContext, uint TolerableDelay);

	/// <summary>
	/// Activates the specified waitable timer and provides context information for the timer. When the due time arrives, the timer is
	/// signaled and the thread that set the timer calls the optional completion routine.
	/// </summary>
	/// <param name="hTimer">
	/// <para>A handle to the timer object. The <c>CreateWaitableTimer</c> or <c>OpenWaitableTimer</c> function returns this handle.</para>
	/// <para>
	/// The handle must have the <c>TIMER_MODIFY_STATE</c> access right. For more information, see Synchronization Object Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpDueTime">
	/// The time after which the state of the timer is to be set to signaled, in 100 nanosecond intervals. Use the format described by the
	/// <c>FILETIME</c> structure. Positive values indicate absolute time. Be sure to use a UTC-based absolute time, as the system uses
	/// UTC-based time internally. Negative values indicate relative time. The actual timer accuracy depends on the capability of your
	/// hardware. For more information about UTC-based time, see System Time.
	/// </param>
	/// <param name="lPeriod">
	/// The period of the timer, in milliseconds. If lPeriod is zero, the timer is signaled once. If lPeriod is greater than zero, the timer
	/// is periodic. A periodic timer automatically reactivates each time the period elapses, until the timer is canceled using the
	/// <c>CancelWaitableTimer</c> function or reset using <c>SetWaitableTimerEx</c>. If lPeriod is less than zero, the function fails.
	/// </param>
	/// <param name="pfnCompletionRoutine">
	/// A pointer to an optional completion routine. The completion routine is application-defined function of type <c>PTIMERAPCROUTINE</c>
	/// to be executed when the timer is signaled. For more information on the timer callback function, see <c>TimerAPCProc</c>. For more
	/// information about APCs and thread pool threads, see Remarks.
	/// </param>
	/// <param name="lpArgToCompletionRoutine">A pointer to a structure that is passed to the completion routine.</param>
	/// <param name="WakeContext">Pointer to a <c>REASON_CONTEXT</c> structure that contains context information for the timer.</param>
	/// <param name="TolerableDelay">The tolerable delay for expiration time, in milliseconds.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetWaitableTimerEx( _In_ HANDLE hTimer, _In_ const LARGE_INTEGER *lpDueTime, _In_ LONG lPeriod, _In_ PTIMERAPCROUTINE
	// pfnCompletionRoutine, _In_ LPVOID lpArgToCompletionRoutine, _In_ PREASON_CONTEXT WakeContext, _In_ ULONG TolerableDelay); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405521(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "dd405521")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWaitableTimerEx([In] SafeWaitableTimerHandle hTimer, in long lpDueTime, [Optional] int lPeriod, [Optional] TimerAPCProc? pfnCompletionRoutine,
		[In, Optional] IntPtr lpArgToCompletionRoutine, [Optional] IntPtr WakeContext, uint TolerableDelay);

	/// <summary>Signals one object and waits on another object as a single operation.</summary>
	/// <param name="hObjectToSignal">
	/// <para>A handle to the object to be signaled. This object can be a semaphore, a mutex, or an event.</para>
	/// <para>
	/// If the handle is a semaphore, the <c>SEMAPHORE_MODIFY_STATE</c> access right is required. If the handle is an event, the
	/// <c>EVENT_MODIFY_STATE</c> access right is required. If the handle is a mutex and the caller does not own the mutex, the function
	/// fails with <c>ERROR_NOT_OWNER</c>.
	/// </para>
	/// </param>
	/// <param name="hObjectToWaitOn">
	/// A handle to the object to wait on. The <c>SYNCHRONIZE</c> access right is required; for more information, see Synchronization Object
	/// Security and Access Rights. For a list of the object types whose handles you can specify, see the Remarks section.
	/// </param>
	/// <param name="dwMilliseconds">
	/// The time-out interval, in milliseconds. The function returns if the interval elapses, even if the object's state is nonsignaled and
	/// no completion or asynchronous procedure call (APC) objects are queued. If dwMilliseconds is zero, the function tests the object's
	/// state, checks for queued completion routines or APCs, and returns immediately. If dwMilliseconds is <c>INFINITE</c>, the function's
	/// time-out interval never elapses.
	/// </param>
	/// <param name="bAlertable">
	/// <para>
	/// If this parameter is <c>TRUE</c>, the function returns when the system queues an I/O completion routine or APC function, and the
	/// thread calls the function. If <c>FALSE</c>, the function does not return, and the thread does not call the completion routine or APC function.
	/// </para>
	/// <para>
	/// A completion routine is queued when the function call that queued the APC has completed. This function returns and the completion
	/// routine is called only if bAlertable is <c>TRUE</c>, and the calling thread is the thread that queued the APC.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value indicates the event that caused the function to return. It can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>WAIT_ABANDONED = 0x00000080L</term>
	/// <term>
	/// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread
	/// terminated. Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.If the mutex was
	/// protecting persistent state information, you should check it for consistency.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WAIT_IO_COMPLETION = 0x000000C0L</term>
	/// <term>The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_OBJECT_0 = 0x00000000L</term>
	/// <term>The state of the specified object is signaled.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_TIMEOUT = 0x00000102L</term>
	/// <term>The time-out interval elapsed, and the object's state is nonsignaled.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_FAILED = (DWORD)0xFFFFFFFF</term>
	/// <term>The function has failed. To get extended error information, call GetLastError.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WINAPI SignalObjectAndWait( _In_ HANDLE hObjectToSignal, _In_ HANDLE hObjectToWaitOn, _In_ DWORD dwMilliseconds, _In_ BOOL
	// bAlertable); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686293(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms686293")]
	public static WAIT_STATUS SignalObjectAndWait([In] ISyncHandle hObjectToSignal, [In] ISyncHandle hObjectToWaitOn, uint dwMilliseconds, bool bAlertable) =>
		SignalObjectAndWait(hObjectToSignal?.DangerousGetHandle() ?? IntPtr.Zero, hObjectToWaitOn?.DangerousGetHandle() ?? IntPtr.Zero, dwMilliseconds, bAlertable);

	/// <summary>
	/// <para>Suspends the execution of the current thread until the time-out interval elapses.</para>
	/// <para>To enter an alertable wait state, use the <c>SleepEx</c> function.</para>
	/// </summary>
	/// <param name="dwMilliseconds">
	/// <para>The time interval for which execution is to be suspended, in milliseconds.</para>
	/// <para>
	/// A value of zero causes the thread to relinquish the remainder of its time slice to any other thread that is ready to run. If there
	/// are no other threads ready to run, the function returns immediately, and the thread continues execution.
	/// </para>
	/// <para>
	/// <c>Windows XP:</c> A value of zero causes the thread to relinquish the remainder of its time slice to any other thread of equal
	/// priority that is ready to run. If there are no other threads of equal priority ready to run, the function returns immediately, and
	/// the thread continues execution. This behavior changed starting with Windows Server 2003.
	/// </para>
	/// <para>A value of INFINITE indicates that the suspension should not time out.</para>
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI Sleep( _In_ DWORD dwMilliseconds); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686298(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686298")]
	public static extern void Sleep(uint dwMilliseconds);

	/// <summary>Sleeps on the specified condition variable and releases the specified critical section as an atomic operation.</summary>
	/// <param name="ConditionVariable">
	/// A pointer to the condition variable. This variable must be initialized using the <c>InitializeConditionVariable</c> function.
	/// </param>
	/// <param name="CriticalSection">
	/// A pointer to the critical section object. This critical section must be entered exactly once by the caller at the time
	/// <c>SleepConditionVariableCS</c> is called.
	/// </param>
	/// <param name="dwMilliseconds">
	/// The time-out interval, in milliseconds. If the time-out interval elapses, the function re-acquires the critical section and returns
	/// zero. If dwMilliseconds is zero, the function tests the states of the specified objects and returns immediately. If dwMilliseconds is
	/// <c>INFINITE</c>, the function's time-out interval never elapses. For more information, see Remarks.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails or the time-out interval elapses, the return value is zero. To get extended error information, call
	/// <c>GetLastError</c>. Possible error codes include <c>ERROR_TIMEOUT</c>, which indicates that the time-out interval has elapsed before
	/// another thread has attempted to wake the sleeping thread.
	/// </para>
	/// </returns>
	// BOOL WINAPI SleepConditionVariableCS( _Inout_ PCONDITION_VARIABLE ConditionVariable, _Inout_ PCRITICAL_SECTION CriticalSection, _In_
	// DWORD dwMilliseconds); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686301(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686301")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SleepConditionVariableCS(ref CONDITION_VARIABLE ConditionVariable, ref CRITICAL_SECTION CriticalSection, uint dwMilliseconds);

	/// <summary>Sleeps on the specified condition variable and releases the specified lock as an atomic operation.</summary>
	/// <param name="ConditionVariable">
	/// A pointer to the condition variable. This variable must be initialized using the <c>InitializeConditionVariable</c> function.
	/// </param>
	/// <param name="SRWLock">A pointer to the lock. This lock must be held in the manner specified by the Flags parameter.</param>
	/// <param name="dwMilliseconds">
	/// The time-out interval, in milliseconds. The function returns if the interval elapses. If dwMilliseconds is zero, the function tests
	/// the states of the specified objects and returns immediately. If dwMilliseconds is <c>INFINITE</c>, the function's time-out interval
	/// never elapses.
	/// </param>
	/// <param name="Flags">
	/// If this parameter is <c>CONDITION_VARIABLE_LOCKMODE_SHARED</c>, the SRW lock is in shared mode. Otherwise, the lock is in exclusive mode.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// <para>If the timeout expires the function returns FALSE and <c>GetLastError</c> returns ERROR_TIMEOUT.</para>
	/// </returns>
	// BOOL WINAPI SleepConditionVariableSRW( _Inout_ PCONDITION_VARIABLE ConditionVariable, _Inout_ PSRWLOCK SRWLock, _In_ DWORD
	// dwMilliseconds, _In_ ULONG Flags); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686304(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686304")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SleepConditionVariableSRW(ref CONDITION_VARIABLE ConditionVariable, ref SRWLOCK SRWLock, uint dwMilliseconds, CONDITION_VARIABLE_FLAGS Flags);

	/// <summary>Suspends the current thread until the specified condition is met. Execution resumes when one of the following occurs:</summary>
	/// <param name="dwMilliseconds">
	/// <para>The time interval for which execution is to be suspended, in milliseconds.</para>
	/// <para>
	/// A value of zero causes the thread to relinquish the remainder of its time slice to any other thread that is ready to run. If there
	/// are no other threads ready to run, the function returns immediately, and the thread continues execution.
	/// </para>
	/// <para>
	/// <c>Windows XP:</c> A value of zero causes the thread to relinquish the remainder of its time slice to any other thread of equal
	/// priority that is ready to run. If there are no other threads of equal priority ready to run, the function returns immediately, and
	/// the thread continues execution. This behavior changed starting with Windows Server 2003.
	/// </para>
	/// <para>A value of INFINITE indicates that the suspension should not time out.</para>
	/// </param>
	/// <param name="bAlertable">
	/// <para>
	/// If this parameter is FALSE, the function does not return until the time-out period has elapsed. If an I/O completion callback occurs,
	/// the function does not return and the I/O completion function is not executed. If an APC is queued to the thread, the function does
	/// not return and the APC function is not executed.
	/// </para>
	/// <para>
	/// If the parameter is TRUE and the thread that called this function is the same thread that called the extended I/O function (
	/// <c>ReadFileEx</c> or <c>WriteFileEx</c>), the function returns when either the time-out period has elapsed or when an I/O completion
	/// callback function occurs. If an I/O completion callback occurs, the I/O completion function is called. If an APC is queued to the
	/// thread ( <c>QueueUserAPC</c>), the function returns when either the timer-out period has elapsed or when the APC function is called.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>The return value is zero if the specified time interval expired.</para>
	/// <para>
	/// The return value is <c>WAIT_IO_COMPLETION</c> if the function returned due to one or more I/O completion callback functions. This can
	/// happen only if bAlertable is TRUE, and if the thread that called the <c>SleepEx</c> function is the same thread that called the
	/// extended I/O function.
	/// </para>
	/// </returns>
	// DWORD WINAPI SleepEx( _In_ DWORD dwMilliseconds, _In_ BOOL bAlertable); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686307(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686307")]
	public static extern uint SleepEx(uint dwMilliseconds, [MarshalAs(UnmanagedType.Bool)] bool bAlertable);

	/// <summary>
	/// Attempts to acquire a slim reader/writer (SRW) lock in exclusive mode. If the call is successful, the calling thread takes ownership
	/// of the lock.
	/// </summary>
	/// <param name="SRWLock">A pointer to the SRW lock.</param>
	/// <returns>
	/// <para>If the lock is successfully acquired, the return value is nonzero.</para>
	/// <para>if the current thread could not acquire the lock, the return value is zero.</para>
	/// </returns>
	// BOOLEAN WINAPI TryAcquireSRWLockExclusive( _Inout_ PSRWLOCK SRWLock); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405523(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "dd405523")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TryAcquireSRWLockExclusive(ref SRWLOCK SRWLock);

	/// <summary>
	/// Attempts to acquire a slim reader/writer (SRW) lock in shared mode. If the call is successful, the calling thread takes ownership of
	/// the lock.
	/// </summary>
	/// <param name="SRWLock">A pointer to the SRW lock.</param>
	/// <returns>
	/// <para>If the lock is successfully acquired, the return value is nonzero.</para>
	/// <para>if the current thread could not acquire the lock, the return value is zero.</para>
	/// </returns>
	// BOOLEAN WINAPI TryAcquireSRWLockShared( _Inout_ PSRWLOCK SRWLock); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405524(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "dd405524")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TryAcquireSRWLockShared(ref SRWLOCK SRWLock);

	/// <summary>
	/// Attempts to enter a critical section without blocking. If the call is successful, the calling thread takes ownership of the critical section.
	/// </summary>
	/// <param name="lpCriticalSection">A pointer to the critical section object.</param>
	/// <returns>
	/// <para>
	/// If the critical section is successfully entered or the current thread already owns the critical section, the return value is nonzero.
	/// </para>
	/// <para>If another thread already owns the critical section, the return value is zero.</para>
	/// </returns>
	// BOOL WINAPI TryEnterCriticalSection( _Inout_ LPCRITICAL_SECTION lpCriticalSection); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686857(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686857")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TryEnterCriticalSection(ref CRITICAL_SECTION lpCriticalSection);

	/// <summary>
	/// <para>
	/// Cancels a registered wait operation issued by the <see cref="RegisterWaitForSingleObject(out SafeRegisteredWaitHandle, IntPtr,
	/// WaitOrTimerCallback, IntPtr, uint, WT)"/> function.
	/// </para>
	/// <para>To use a completion event, call the <c>UnregisterWaitEx</c> function.</para>
	/// </summary>
	/// <param name="WaitHandle">The wait handle. This handle is returned by the <c>RegisterWaitForSingleObject</c> function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI UnregisterWait( _In_ HANDLE WaitHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686870(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms686870")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnregisterWait([In, AddAsMember] SafeRegisteredWaitHandle WaitHandle);

	/// <summary>
	/// <para>Waits until one or all of the specified objects are in the signaled state or the time-out interval elapses.</para>
	/// <para>To enter an alertable wait state, use the <c>WaitForMultipleObjectsEx</c> function.</para>
	/// </summary>
	/// <param name="lpHandles">
	/// <para>
	/// An array of object handles. For a list of the object types whose handles can be specified, see the following Remarks section. The
	/// array can contain handles to objects of different types. It may not contain multiple copies of the same handle.
	/// </para>
	/// <para>If one of these handles is closed while the wait is still pending, the function's behavior is undefined.</para>
	/// <para>The handles must have the <c>SYNCHRONIZE</c> access right. For more information, see Standard Access Rights.</para>
	/// </param>
	/// <param name="bWaitAll">
	/// If this parameter is <c>TRUE</c>, the function returns when the state of all objects in the lpHandles array is signaled. If
	/// <c>FALSE</c>, the function returns when the state of any one of the objects is set to signaled. In the latter case, the return value
	/// indicates the object whose state caused the function to return.
	/// </param>
	/// <param name="dwMilliseconds">
	/// The time-out interval, in milliseconds. If a nonzero value is specified, the function waits until the specified objects are signaled
	/// or the interval elapses. If dwMilliseconds is zero, the function does not enter a wait state if the specified objects are not
	/// signaled; it always returns immediately. If dwMilliseconds is <c>INFINITE</c>, the function will return only when the specified
	/// objects are signaled.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value indicates the event that caused the function to return. It can be one of the following
	/// values. (Note that <c>WAIT_OBJECT_0</c> is defined as 0 and <c>WAIT_ABANDONED_0</c> is defined as 0x00000080L.)
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>WAIT_OBJECT_0 to (WAIT_OBJECT_0 + nCount– 1)</term>
	/// <term>
	/// If bWaitAll is TRUE, the return value indicates that the state of all specified objects is signaled. If bWaitAll is FALSE, the return
	/// value minus WAIT_OBJECT_0 indicates the lpHandles array index of the object that satisfied the wait. If more than one object became
	/// signaled during the call, this is the array index of the signaled object with the smallest index value of all the signaled objects.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WAIT_ABANDONED_0 to (WAIT_ABANDONED_0 + nCount– 1)</term>
	/// <term>
	/// If bWaitAll is TRUE, the return value indicates that the state of all specified objects is signaled and at least one of the objects
	/// is an abandoned mutex object. If bWaitAll is FALSE, the return value minus WAIT_ABANDONED_0 indicates the lpHandles array index of an
	/// abandoned mutex object that satisfied the wait. Ownership of the mutex object is granted to the calling thread, and the mutex is set
	/// to nonsignaled.If a mutex was protecting persistent state information, you should check it for consistency.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WAIT_TIMEOUT0x00000102L</term>
	/// <term>The time-out interval elapsed and the conditions specified by the bWaitAll parameter are not satisfied.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_FAILED(DWORD)0xFFFFFFFF</term>
	/// <term>The function has failed. To get extended error information, call GetLastError.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WINAPI WaitForMultipleObjects( _In_ DWORD nCount, _In_ const HANDLE *lpHandles, _In_ BOOL bWaitAll, _In_ DWORD dwMilliseconds); https://msdn.microsoft.com/en-us/library/windows/desktop/ms687025(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms687025")]
	public static WAIT_STATUS WaitForMultipleObjects<T>(IEnumerable<T>? lpHandles, bool bWaitAll, uint dwMilliseconds) where T : ISyncHandle
	{
		var h = lpHandles?.Select(i => i.DangerousGetHandle()).ToArray();
		return WaitForMultipleObjects((uint)(h?.Length ?? 0), h, bWaitAll, dwMilliseconds);
	}

	/// <summary>
	/// Waits until one or all of the specified objects are in the signaled state, an I/O completion routine or asynchronous procedure call
	/// (APC) is queued to the thread, or the time-out interval elapses.
	/// </summary>
	/// <param name="lpHandles">
	/// <para>
	/// An array of object handles. For a list of the object types whose handles can be specified, see the following Remarks section. The
	/// array can contain handles of objects of different types. It may not contain multiple copies of the same handle.
	/// </para>
	/// <para>If one of these handles is closed while the wait is still pending, the function's behavior is undefined.</para>
	/// <para>The handles must have the <c>SYNCHRONIZE</c> access right. For more information, see Standard Access Rights.</para>
	/// </param>
	/// <param name="bWaitAll">
	/// If this parameter is <c>TRUE</c>, the function returns when the state of all objects in the lpHandles array is set to signaled. If
	/// <c>FALSE</c>, the function returns when the state of any one of the objects is set to signaled. In the latter case, the return value
	/// indicates the object whose state caused the function to return.
	/// </param>
	/// <param name="dwMilliseconds">
	/// The time-out interval, in milliseconds. If a nonzero value is specified, the function waits until the specified objects are signaled,
	/// an I/O completion routine or APC is queued, or the interval elapses. If dwMilliseconds is zero, the function does not enter a wait
	/// state if the criteria is not met; it always returns immediately. If dwMilliseconds is <c>INFINITE</c>, the function will return only
	/// when the specified objects are signaled or an I/O completion routine or APC is queued.
	/// </param>
	/// <param name="bAlertable">
	/// <para>
	/// If this parameter is <c>TRUE</c> and the thread is in the waiting state, the function returns when the system queues an I/O
	/// completion routine or APC, and the thread runs the routine or function. Otherwise, the function does not return and the completion
	/// routine or APC function is not executed.
	/// </para>
	/// <para>
	/// A completion routine is queued when the <c>ReadFileEx</c> or <c>WriteFileEx</c> function in which it was specified has completed. The
	/// wait function returns and the completion routine is called only if bAlertable is <c>TRUE</c> and the calling thread is the thread
	/// that initiated the read or write operation. An APC is queued when you call <c>QueueUserAPC</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value indicates the event that caused the function to return. It can be one of the following
	/// values. (Note that <c>WAIT_OBJECT_0</c> is defined as 0 and <c>WAIT_ABANDONED_0</c> is defined as 0x00000080L.)
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>WAIT_OBJECT_0 to (WAIT_OBJECT_0 + nCount– 1)</term>
	/// <term>
	/// If bWaitAll is TRUE, a return value in this range indicates that the state of all specified objects is signaled. If bWaitAll is
	/// FALSE, the return value minus WAIT_OBJECT_0 indicates the lpHandles array index of the object that satisfied the wait. If more than
	/// one object became signaled during the call, this is the array index of the signaled object with the smallest index value of all the
	/// signaled objects.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WAIT_ABANDONED_0 to (WAIT_ABANDONED_0 + nCount– 1)</term>
	/// <term>
	/// If bWaitAll is TRUE, a return value in this range indicates that the state of all specified objects is signaled, and at least one of
	/// the objects is an abandoned mutex object. If bWaitAll is FALSE, the return value minus WAIT_ABANDONED_0 indicates the lpHandles array
	/// index of an abandoned mutex object that satisfied the wait. Ownership of the mutex object is granted to the calling thread, and the
	/// mutex is set to nonsignaled.If a mutex was protecting persistent state information, you should check it for consistency.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WAIT_IO_COMPLETION0x000000C0L</term>
	/// <term>The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_TIMEOUT0x00000102L</term>
	/// <term>
	/// The time-out interval elapsed, the conditions specified by the bWaitAll parameter were not satisfied, and no completion routines are queued.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WAIT_FAILED(DWORD)0xFFFFFFFF</term>
	/// <term>The function has failed. To get extended error information, call GetLastError.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WINAPI WaitForMultipleObjectsEx( _In_ DWORD nCount, _In_ const HANDLE *lpHandles, _In_ BOOL bWaitAll, _In_ DWORD dwMilliseconds,
	// _In_ BOOL bAlertable); https://msdn.microsoft.com/en-us/library/windows/desktop/ms687028(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms687028")]
	public static WAIT_STATUS WaitForMultipleObjectsEx<T>(IEnumerable<T>? lpHandles, bool bWaitAll, uint dwMilliseconds, bool bAlertable) where T : ISyncHandle
	{
		var h = lpHandles?.Select(i => i.DangerousGetHandle()).ToArray();
		return WaitForMultipleObjectsEx((uint)(h?.Length ?? 0), h, bWaitAll, dwMilliseconds, bAlertable);
	}

	/// <summary>
	/// <para>Waits until the specified object is in the signaled state or the time-out interval elapses.</para>
	/// <para>To enter an alertable wait state, use the <c>WaitForSingleObjectEx</c> function. To wait for multiple objects, use <c>WaitForMultipleObjects</c>.</para>
	/// </summary>
	/// <param name="hHandle">
	/// <para>A handle to the object. For a list of the object types whose handles can be specified, see the following Remarks section.</para>
	/// <para>If this handle is closed while the wait is still pending, the function's behavior is undefined.</para>
	/// <para>The handle must have the <c>SYNCHRONIZE</c> access right. For more information, see Standard Access Rights.</para>
	/// </param>
	/// <param name="dwMilliseconds">
	/// <para>
	/// The time-out interval, in milliseconds. If a nonzero value is specified, the function waits until the object is signaled or the
	/// interval elapses. If dwMilliseconds is zero, the function does not enter a wait state if the object is not signaled; it always
	/// returns immediately. If dwMilliseconds is <c>INFINITE</c>, the function will return only when the object is signaled.
	/// </para>
	/// <para>
	/// <c>Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008 and Windows Server 2008 R2:</c> The dwMilliseconds
	/// value does include time spent in low-power states. For example, the timeout does keep counting down while the computer is asleep.
	/// </para>
	/// <para>
	/// <c>Windows 8, Windows Server 2012, Windows 8.1, Windows Server 2012 R2, Windows 10 and Windows Server 2016:</c> The dwMilliseconds
	/// value does not include time spent in low-power states. For example, the timeout does not keep counting down while the computer is asleep.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value indicates the event that caused the function to return. It can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>WAIT_ABANDONED0x00000080L</term>
	/// <term>
	/// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread
	/// terminated. Ownership of the mutex object is granted to the calling thread and the mutex state is set to nonsignaled.If the mutex was
	/// protecting persistent state information, you should check it for consistency.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WAIT_OBJECT_00x00000000L</term>
	/// <term>The state of the specified object is signaled.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_TIMEOUT0x00000102L</term>
	/// <term>The time-out interval elapsed, and the object's state is nonsignaled.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_FAILED(DWORD)0xFFFFFFFF</term>
	/// <term>The function has failed. To get extended error information, call GetLastError.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WINAPI WaitForSingleObject( _In_ HANDLE hHandle, _In_ DWORD dwMilliseconds); https://msdn.microsoft.com/en-us/library/windows/desktop/ms687032(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms687032")]
	public static WAIT_STATUS WaitForSingleObject([In] ISyncHandle hHandle, uint dwMilliseconds) => WaitForSingleObject(hHandle?.DangerousGetHandle() ?? IntPtr.Zero, dwMilliseconds);

	/// <summary>
	/// <para>
	/// Waits until the specified object is in the signaled state, an I/O completion routine or asynchronous procedure call (APC) is queued
	/// to the thread, or the time-out interval elapses.
	/// </para>
	/// <para>To wait for multiple objects, use the <c>WaitForMultipleObjectsEx</c>.</para>
	/// </summary>
	/// <param name="hHandle">
	/// <para>A handle to the object. For a list of the object types whose handles can be specified, see the following Remarks section.</para>
	/// <para>If this handle is closed while the wait is still pending, the function's behavior is undefined.</para>
	/// <para>The handle must have the <c>SYNCHRONIZE</c> access right. For more information, see Standard Access Rights.</para>
	/// </param>
	/// <param name="dwMilliseconds">
	/// The time-out interval, in milliseconds. If a nonzero value is specified, the function waits until the object is signaled, an I/O
	/// completion routine or APC is queued, or the interval elapses. If dwMilliseconds is zero, the function does not enter a wait state if
	/// the criteria is not met; it always returns immediately. If dwMilliseconds is <c>INFINITE</c>, the function will return only when the
	/// object is signaled or an I/O completion routine or APC is queued.
	/// </param>
	/// <param name="bAlertable">
	/// <para>
	/// If this parameter is <c>TRUE</c> and the thread is in the waiting state, the function returns when the system queues an I/O
	/// completion routine or APC, and the thread runs the routine or function. Otherwise, the function does not return, and the completion
	/// routine or APC function is not executed.
	/// </para>
	/// <para>
	/// A completion routine is queued when the <c>ReadFileEx</c> or <c>WriteFileEx</c> function in which it was specified has completed. The
	/// wait function returns and the completion routine is called only if bAlertable is <c>TRUE</c>, and the calling thread is the thread
	/// that initiated the read or write operation. An APC is queued when you call <c>QueueUserAPC</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value indicates the event that caused the function to return. It can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>WAIT_ABANDONED0x00000080L</term>
	/// <term>
	/// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread
	/// terminated. Ownership of the mutex object is granted to the calling thread and the mutex is set to nonsignaled.If the mutex was
	/// protecting persistent state information, you should check it for consistency.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WAIT_IO_COMPLETION0x000000C0L</term>
	/// <term>The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_OBJECT_00x00000000L</term>
	/// <term>The state of the specified object is signaled.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_TIMEOUT0x00000102L</term>
	/// <term>The time-out interval elapsed, and the object's state is nonsignaled.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_FAILED(DWORD)0xFFFFFFFF</term>
	/// <term>The function has failed. To get extended error information, call GetLastError.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WINAPI WaitForSingleObjectEx( _In_ HANDLE hHandle, _In_ DWORD dwMilliseconds, _In_ BOOL bAlertable); https://msdn.microsoft.com/en-us/library/windows/desktop/ms687036(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms687036")]
	public static WAIT_STATUS WaitForSingleObjectEx([In] ISyncHandle hHandle, uint dwMilliseconds, bool bAlertable) => WaitForSingleObjectEx(hHandle?.DangerousGetHandle() ?? IntPtr.Zero, dwMilliseconds, bAlertable);

	/// <summary>Waits for the value at the specified address to change.</summary>
	/// <param name="Address">
	/// The address on which to wait. If the value at Address differs from the value at CompareAddress, the function returns immediately. If
	/// the values are the same, the function does not return until another thread in the same process signals that the value at Address has
	/// changed by calling <c>WakeByAddressSingle</c> or <c>WakeByAddressAll</c> or the timeout elapses, whichever comes first.
	/// </param>
	/// <param name="CompareAddress">
	/// A pointer to the location of the previously observed value at Address. The function returns when the value at Address differs from
	/// the value at CompareAddress.
	/// </param>
	/// <param name="AddressSize">The size of the value, in bytes. This parameter can be 1, 2, 4, or 8.</param>
	/// <param name="dwMilliseconds">
	/// The number of milliseconds to wait before the operation times out. If this parameter is <c>INFINITE</c>, the thread waits indefinitely.
	/// </param>
	/// <returns>
	/// TRUE if the wait succeeded. If the operation fails, the function returns FALSE. If the wait fails, call <c>GetLastError</c> to obtain
	/// extended error information. In particular, if the operation times out, <c>GetLastError</c> returns <c>ERROR_TIMEOUT</c>.
	/// </returns>
	// BOOL WINAPI WaitOnAddress( _In_ VOID volatile *Address, _In_ PVOID CompareAddress, _In_ SIZE_T AddressSize, _In_opt_ DWORD
	// dwMilliseconds); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706898(v=vs.85).aspx
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("SynchAPI.h", MSDNShortId = "hh706898")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern unsafe bool WaitOnAddress(void* Address, void* CompareAddress, SizeT AddressSize, uint dwMilliseconds);

	/// <summary>Wake all threads waiting on the specified condition variable.</summary>
	/// <param name="ConditionVariable">A pointer to the condition variable.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI WakeAllConditionVariable( _Inout_ PCONDITION_VARIABLE ConditionVariable); https://msdn.microsoft.com/en-us/library/windows/desktop/ms687076(v=vs.85).aspx
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms687076")]
	public static extern void WakeAllConditionVariable(ref CONDITION_VARIABLE ConditionVariable);

	/// <summary>Wakes all threads that are waiting for the value of an address to change.</summary>
	/// <param name="Address">
	/// The address to signal. If any threads have previously called <c>WaitOnAddress</c> for this address, the system wakes all of the
	/// waiting threads.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI WakeByAddressAll( _In_ PVOID Address); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706899(v=vs.85).aspx
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("SynchAPI.h", MSDNShortId = "hh706899")]
	public static extern unsafe void WakeByAddressAll(void* Address);

	/// <summary>Wakes one thread that is waiting for the value of an address to change.</summary>
	/// <param name="Address">
	/// The address to signal. If another thread has previously called <c>WaitOnAddress</c> for this address, the system wakes the waiting
	/// thread. If multiple threads are waiting for this address, the system wakes the first thread to wait.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI WakeByAddressSingle( _In_ PVOID Address); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706900(v=vs.85).aspx
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("SynchAPI.h", MSDNShortId = "hh706900")]
	public static extern unsafe void WakeByAddressSingle(void* Address);

	/// <summary>Wake a single thread waiting on the specified condition variable.</summary>
	/// <param name="ConditionVariable">A pointer to the condition variable.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI WakeConditionVariable( _Inout_ PCONDITION_VARIABLE ConditionVariable); https://msdn.microsoft.com/en-us/library/windows/desktop/ms687080(v=vs.85).aspx
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms687080")]
	public static extern void WakeConditionVariable(ref CONDITION_VARIABLE ConditionVariable);

	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	private static extern WAIT_STATUS SignalObjectAndWait([In] IntPtr hObjectToSignal, [In] IntPtr hObjectToWaitOn, uint dwMilliseconds, [MarshalAs(UnmanagedType.Bool)] bool bAlertable);

	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	private static extern WAIT_STATUS WaitForMultipleObjects(uint nCount, [Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 0)] IntPtr[]? lpHandles,
		[MarshalAs(UnmanagedType.Bool)] bool bWaitAll, uint dwMilliseconds);

	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	private static extern WAIT_STATUS WaitForMultipleObjectsEx(uint nCount, [Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 0)] IntPtr[]? lpHandles,
		[MarshalAs(UnmanagedType.Bool)] bool bWaitAll, uint dwMilliseconds, [MarshalAs(UnmanagedType.Bool)] bool bAlertable);

	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	private static extern WAIT_STATUS WaitForSingleObject([In] IntPtr hHandle, uint dwMilliseconds);

	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	private static extern WAIT_STATUS WaitForSingleObjectEx([In] IntPtr hHandle, uint dwMilliseconds, [MarshalAs(UnmanagedType.Bool)] bool bAlertable);

	/// <summary>A condition variable.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct CONDITION_VARIABLE
	{
		private readonly IntPtr ptr;
	}

	/// <summary>A critical section object.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct CRITICAL_SECTION
	{
		private readonly IntPtr DebugInfo;
		private readonly int LockCount;
		private readonly int RecursionCount;
		private readonly IntPtr OwningThread;
		private readonly IntPtr LockSemaphore;
		private readonly nuint SpinCount;
	}

	/// <summary>A one-time initialization structure.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct INIT_ONCE
	{
		private readonly IntPtr ptr;

		/// <summary/>
		public static readonly INIT_ONCE INIT_ONCE_STATIC_INIT = new();
	}

	/// <summary>
	/// Contains information about a power request. This structure is used by the <c>PowerCreateRequest</c> and <c>SetWaitableTimerEx</c> functions.
	/// </summary>
	// typedef struct _REASON_CONTEXT { ULONG Version; DWORD Flags; union { struct { HMODULE LocalizedReasonModule; ULONG LocalizedReasonId;
	// ULONG ReasonStringCount; LPWSTR *ReasonStrings; } Detailed; LPWSTR SimpleReasonString; } Reason;} REASON_CONTEXT, *PREASON_CONTEXT; https://msdn.microsoft.com/en-us/library/windows/desktop/dd405536(v=vs.85).aspx
	[PInvokeData("MinWinBase.h", MSDNShortId = "dd405536")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class REASON_CONTEXT : IDisposable
	{
		/// <summary>The version number of the structure. This parameter must be set to <c>DIAGNOSTIC_REASON_VERSION</c>.</summary>
		public DIAGNOSTIC_REASON_VERSION Version;

		/// <summary>
		/// <para>The format of the reason for the power request. This parameter can be one of the following values:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>POWER_REQUEST_CONTEXT_DETAILED_STRING = 0x00000002</term>
		/// <term>The Detailed structure identifies a localizable string resource that describes the reason for the power request.</term>
		/// </item>
		/// <item>
		/// <term>POWER_REQUEST_CONTEXT_SIMPLE_STRING = 0x00000001</term>
		/// <term>The SimpleReasonString parameter contains a simple, non-localizable string that describes the reason for the power request.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public DIAGNOSTIC_REASON Flags;

		private DETAIL _reason;

		/// <summary>A structure that identifies a localizable string resource to describe the reason for the power request.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DETAIL
		{
			/// <summary>The module that contains the string resource.</summary>
			public IntPtr LocalizedReasonModule;

			/// <summary>The ID of the string resource.</summary>
			public uint LocalizedReasonId;

			/// <summary>The number of strings in the ReasonStrings parameter.</summary>
			public uint ReasonStringCount;

			/// <summary>An array of strings to be substituted in the string resource at run time.</summary>
			public IntPtr ReasonStrings;
		}

		/// <summary>Initializes a new instance of the <see cref="REASON_CONTEXT"/> class.</summary>
		/// <param name="reason">The reason.</param>
		public REASON_CONTEXT(string reason)
		{
			Version = DIAGNOSTIC_REASON_VERSION.DIAGNOSTIC_REASON_VERSION;
			Flags = DIAGNOSTIC_REASON.DIAGNOSTIC_REASON_SIMPLE_STRING;
			_reason.LocalizedReasonModule = Marshal.StringToHGlobalUni(reason);
		}

		/// <summary>Initializes a new instance of the <see cref="REASON_CONTEXT"/> class.</summary>
		/// <param name="localizedReasonModule">The localized reason module.</param>
		/// <param name="reasonId">The reason identifier.</param>
		/// <param name="substituionValues">The substituion values.</param>
		public REASON_CONTEXT(HINSTANCE localizedReasonModule, uint reasonId, string[]? substituionValues = null)
		{
			Version = DIAGNOSTIC_REASON_VERSION.DIAGNOSTIC_REASON_VERSION;
			Flags = DIAGNOSTIC_REASON.DIAGNOSTIC_REASON_DETAILED_STRING;
			_reason.LocalizedReasonModule = (IntPtr)localizedReasonModule;
			_reason.LocalizedReasonId = reasonId;
			_reason.ReasonStringCount = (uint)(substituionValues?.Length ?? 0);
			_reason.ReasonStrings = substituionValues?.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out var _, CharSet.Unicode) ?? IntPtr.Zero;
		}

		void IDisposable.Dispose()
		{
			if (Flags == DIAGNOSTIC_REASON.DIAGNOSTIC_REASON_SIMPLE_STRING)
				Marshal.FreeHGlobal(_reason.LocalizedReasonModule);
			else if (Flags == DIAGNOSTIC_REASON.DIAGNOSTIC_REASON_DETAILED_STRING)
				Marshal.FreeHGlobal(_reason.ReasonStrings);
		}
	}

	/// <summary>A slim reader/writer (SRW) lock.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SRWLOCK
	{
		private readonly IntPtr ptr;
	}

	/// <summary>Provides a handle to a synchronization barrier.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SYNCHRONIZATION_BARRIER
	{
		private readonly uint Reserved1;
		private readonly uint Reserved2;
		private readonly IntPtr Reserved3_1;
		private readonly IntPtr Reserved3_2;
		private readonly uint Reserved4;
		private readonly uint Reserved5;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to an event that is automatically disposed using CloseHandle.</summary>
	[AutoSafeHandle(null, typeof(HEVENT), typeof(SafeSyncHandle))]
	[AdjustAutoMethodNamePattern(@"Event|Ex\b", "")]
	public partial class SafeEventHandle
	{
		/// <summary>Performs an implicit conversion from <see cref="EventWaitHandle"/> to <see cref="SafeWaitHandle"/>.</summary>
		/// <param name="h">The SafeSyncHandle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeEventHandle(EventWaitHandle h) => new(h.Handle, false);

		/// <summary>Gets an invalid event handle.</summary>
		public static SafeEventHandle InvalidHandle => new(new IntPtr(-1), false);

		/// <summary>
		/// <para>Creates or opens a named or unnamed event object.</para>
		/// <para>To specify an access mask for the object, use the <c>CreateEventEx</c> function.</para>
		/// </summary>
		/// <param name="initialState">
		/// If this parameter is <see langword="true"/>, the initial state of the event object is signaled; otherwise, it is nonsignaled.
		/// </param>
		/// <param name="manualReset">
		/// If this parameter is <see langword="true"/>, the function creates a manual-reset event object, which requires the use of the
		/// <c>ResetEvent</c> function to set the event state to nonsignaled. If this parameter is <see langword="false"/>, the function
		/// creates an auto-reset event object, and system automatically resets the event state to nonsignaled after a single waiting thread
		/// has been released.
		/// </param>
		/// <param name="name">
		/// <para>The name of the event object. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case sensitive.</para>
		/// <para>
		/// If <paramref name="name"/> matches the name of an existing named event object, this function requests the <c>EVENT_ALL_ACCESS</c>
		/// access right. In this case, the bManualReset and bInitialState parameters are ignored because they have already been set by the
		/// creating process. If the <paramref name="attributes"/> parameter is not <see langword="null"/>, it determines whether the handle
		/// can be inherited, but its security-descriptor member is ignored.
		/// </para>
		/// <para>If <paramref name="name"/> is <see langword="null"/>, the event object is created without a name.</para>
		/// <para>
		/// If <paramref name="name"/> matches the name of another kind of object in the same namespace (such as an existing semaphore,
		/// mutex, waitable timer, job, or file-mapping object), the function fails and the <c>GetLastError</c> function returns
		/// <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
		/// </para>
		/// <para>
		/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The
		/// remainder of the name can contain any character except the backslash character (\). For more information, see Kernel Object
		/// Namespaces. Fast user switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines
		/// outlined for Terminal Services so that applications can support multiple users.
		/// </para>
		/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
		/// </param>
		/// <param name="attributes">
		/// <para>
		/// A <c>SECURITY_ATTRIBUTES</c> instance. If this parameter is <see langword="null"/>, the handle cannot be inherited by child processes.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new event. If <paramref
		/// name="attributes"/> is <see langword="null"/>, the event gets a default security descriptor. The ACLs in the default security
		/// descriptor for an event come from the primary or impersonation token of the creator.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a handle to the event object. If the named event object existed before the function
		/// call, the function returns a handle to the existing object and <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>.
		/// </para>
		/// <para>If the function fails, the return value is <c>Null</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		public static SafeEventHandle Create(bool initialState = false, bool manualReset = false, string? name = null, SECURITY_ATTRIBUTES? attributes = default) =>
			CreateEvent(attributes, manualReset, initialState, name);

		/// <summary>Opens an existing named event object.</summary>
		/// <param name="name">
		/// <para>The name of the event to be opened. Name comparisons are case sensitive.</para>
		/// <para>This function can open objects in a private namespace. For more information, see Object Namespaces.</para>
		/// <para>
		/// <c>Terminal Services:</c> The name can have a "Global\" or "Local\" prefix to explicitly open an object in the global or session
		/// namespace. The remainder of the name can contain any character except the backslash character (\). For more information, see
		/// Kernel Object Namespaces.
		/// </para>
		/// <para>
		/// <c>Note</c> Fast user switching is implemented using Terminal Services sessions. The first user to log on uses session 0, the
		/// next user to log on uses session 1, and so on. Kernel object names must follow the guidelines outlined for Terminal Services so
		/// that applications can support multiple users.
		/// </para>
		/// </param>
		/// <param name="inherit">
		/// If this value is <c>TRUE</c>, processes created by this process will inherit the handle. Otherwise, the processes do not inherit
		/// this handle.
		/// </param>
		/// <param name="access">
		/// The access to the event object. The function fails if the security descriptor of the specified object does not permit the
		/// requested access for the calling process. For a list of access rights, see Synchronization Object Security and Access Rights.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the event object.</para>
		/// <para>If the function fails, the return value is <c>Null</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		public static SafeEventHandle Open(string name, bool inherit = false, SynchronizationObjectAccess access = SynchronizationObjectAccess.EVENT_ALL_ACCESS) => OpenEvent((uint)access, inherit, name);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to a mutex that is automatically disposed using CloseHandle.</summary>
	[AutoSafeHandle(null, null, typeof(SafeSyncHandle))]
	[AdjustAutoMethodNamePattern(@"Mutex|Ex\b", "")]
	public partial class SafeMutexHandle
	{
		/// <summary>Performs an implicit conversion from <see cref="SafeSyncHandle"/> to <see cref="SafeWaitHandle"/>.</summary>
		/// <param name="h">The SafeSyncHandle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeMutexHandle(SafeWaitHandle h) => new(h.DangerousGetHandle(), false);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to a wait handle created by RegisterWaitForSingleObject and closed on disposal by UnregisterWaitEx.
	/// </summary>
	[AutoSafeHandle]
	[AdjustAutoMethodNamePattern(@"WaitFor|Wait", "")]
	public partial class SafeRegisteredWaitHandle
	{
		/// <summary>
		/// Gets or sets the event object to be signaled when the wait operation has been unregistered. This property can be <see langword="null"/>.
		/// </summary>
		/// <value>The completion event.</value>
		public SafeEventHandle? CompletionEvent { get; set; }

		/// <summary>Gets or sets a value indicating whether the disposal waits for all callback functions to complete before returning.</summary>
		/// <value><c>true</c> if disposal wait for all functions to complete; otherwise, <c>false</c>.</value>
		public bool WaitForAllFunctions { get; set; } = false;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() =>
			UnregisterWaitEx(handle, CompletionEvent ?? (WaitForAllFunctions ? HEVENT.INVALID_HANDLE_VALUE : HEVENT.NULL)) ||
			CompletionEvent is not null && Win32Error.GetLastError() == Win32Error.ERROR_IO_PENDING && CompletionEvent.Wait();
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to a semaphore that is automatically disposed using CloseHandle.</summary>
	[AutoSafeHandle(null, null, typeof(SafeSyncHandle))]
	[AdjustAutoMethodNamePattern(@"Semaphore|Ex\b", "")]
	public partial class SafeSemaphoreHandle
	{
		/// <summary>Performs an implicit conversion from <see cref="SafeSyncHandle"/> to <see cref="SafeWaitHandle"/>.</summary>
		/// <param name="h">The SafeSyncHandle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeSemaphoreHandle(SafeWaitHandle h) => new(h.DangerousGetHandle(), false);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to a waitable timer that is automatically disposed using CloseHandle.</summary>
	[AutoSafeHandle(null, null, typeof(SafeSyncHandle))]
	[AdjustAutoMethodNamePattern(@"WaitableTimer|Ex\b", "")]
	public partial class SafeWaitableTimerHandle
	{
		/// <summary>Performs an implicit conversion from <see cref="SafeSyncHandle"/> to <see cref="SafeWaitHandle"/>.</summary>
		/// <param name="h">The SafeSyncHandle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeWaitableTimerHandle(SafeWaitHandle h) => new(h.DangerousGetHandle(), false);
	}
}