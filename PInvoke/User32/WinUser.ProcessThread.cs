namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>Attaches or detaches the input processing mechanism of one thread to that of another thread.</summary>
	/// <param name="idAttach">
	/// The identifier of the thread to be attached to another thread. The thread to be attached cannot be a system thread.
	/// </param>
	/// <param name="idAttachTo">
	/// <para>The identifier of the thread to which idAttach will be attached. This thread cannot be a system thread.</para>
	/// <para>A thread cannot attach to itself. Therefore, idAttachTo cannot equal idAttach.</para>
	/// </param>
	/// <param name="fAttach">
	/// If this parameter is <c>TRUE</c>, the two threads are attached. If the parameter is <c>FALSE</c>, the threads are detached.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> There is no extended error information; do not call GetLastError. This behavior
	/// changed as of Windows Vista.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// By using the <c>AttachThreadInput</c> function, a thread can share its input states (such as keyboard states and the current
	/// focus window) with another thread. Keyboard and mouse events received by both threads are processed in the order they were
	/// received until the threads are detached by calling <c>AttachThreadInput</c> a second time and specifying <c>FALSE</c> for the
	/// fAttach parameter.
	/// </para>
	/// <para>
	/// The <c>AttachThreadInput</c> function fails if either of the specified threads does not have a message queue. The system creates
	/// a thread's message queue when the thread makes its first call to one of the USER or GDI functions. The <c>AttachThreadInput</c>
	/// function also fails if a journal record hook is installed. Journal record hooks attach all input queues together.
	/// </para>
	/// <para>
	/// Note that key state, which can be ascertained by calls to the GetKeyState or GetKeyboardState function, is reset after a call to
	/// <c>AttachThreadInput</c>. You cannot attach a thread to a thread in another desktop.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-attachthreadinput BOOL AttachThreadInput( DWORD idAttach,
	// DWORD idAttachTo, BOOL fAttach );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "0c343fab-56ae-4c70-a79e-0c5f827158a3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, [MarshalAs(UnmanagedType.Bool)] bool fAttach);

	/// <summary>
	/// <para>Determines whether the process belongs to a Windows Store app.</para>
	/// </summary>
	/// <param name="hProcess">
	/// <para>Target process handle.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isimmersiveprocess BOOL IsImmersiveProcess( HANDLE
	// hProcess );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "E95FD9C0-8E4A-44FA-BBA6-0A7F53A0E584")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsImmersiveProcess(HPROCESS hProcess);

	/// <summary>
	/// <para>
	/// Exempts the calling process from restrictions preventing desktop processes from interacting with the Windows Store app
	/// environment. This function is used by development and debugging tools.
	/// </para>
	/// <para>
	/// This function only succeeds if a developer license is present on the system. Once successful the calling process will be able to
	/// perform the following actions, subject to User Interface Privilege Isolation (UIPI) restrictions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Attach global hooks (and event hooks) to Windows Store app processes.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Attach input queues between Windows Store app processes, Windows Store app browsers, system processes, and desktop application processes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Change foreground arbitrarily between the Windows Store app and desktop environments.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <param name="fEnableExemption">When set to TRUE, indicates a request to disable exemption for the calling process.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// Any process can call this function, including desktop and Windows Store app processes and processes that use IL code.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setprocessrestrictionexemption BOOL
	// SetProcessRestrictionExemption( BOOL fEnableExemption );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "CC7EE5D7-ADFC-4859-88F8-C5C21AEBF315")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetProcessRestrictionExemption([MarshalAs(UnmanagedType.Bool)] bool fEnableExemption);

	/// <summary>
	/// Waits until the specified process has finished processing its initial input and is waiting for user input with no input pending,
	/// or until the time-out interval has elapsed.
	/// </summary>
	/// <param name="hProcess">
	/// A handle to the process. If this process is a console application or does not have a message queue, <c>WaitForInputIdle</c>
	/// returns immediately.
	/// </param>
	/// <param name="dwMilliseconds">
	/// The time-out interval, in milliseconds. If dwMilliseconds is <see cref="Kernel32.INFINITE"/>, the function does not return until the process is idle.
	/// </param>
	/// <returns>
	/// <para>The following table shows the possible return values for this function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The wait was satisfied successfully.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_TIMEOUT</term>
	/// <term>The wait was terminated because the time-out interval elapsed.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_FAILED</term>
	/// <term>An error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WaitForInputIdle</c> function enables a thread to suspend its execution until the specified process has finished its
	/// initialization and is waiting for user input with no input pending. If the process has multiple threads, the
	/// <c>WaitForInputIdle</c> function returns as soon as any thread becomes idle.
	/// </para>
	/// <para>
	/// <c>WaitForInputIdle</c> can be used at any time, not just during application startup. However, <c>WaitForInputIdle</c> waits only
	/// once for a process to become idle; subsequent <c>WaitForInputIdle</c> calls return immediately, whether the process is idle or busy.
	/// </para>
	/// <para>
	/// <c>WaitForInputIdle</c> can be useful for synchronizing a parent process and a newly created child process. When a parent process
	/// creates a child process, the CreateProcess function returns without waiting for the child process to finish its initialization.
	/// Before trying to communicate with the child process, the parent process can use the <c>WaitForInputIdle</c> function to determine
	/// when the child's initialization has been completed. For example, the parent process should use the <c>WaitForInputIdle</c>
	/// function before trying to find a window associated with the child process.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-waitforinputidle DWORD WaitForInputIdle( HANDLE hProcess,
	// DWORD dwMilliseconds );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "2a684921-36f1-438c-895c-5bebc242635a")]
	public static extern Kernel32.WAIT_STATUS WaitForInputIdle([In] HPROCESS hProcess, uint dwMilliseconds);
}