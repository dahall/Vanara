using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>The delegate for a hook procedure set by SetWindowsHookEx.</summary>
		/// <param name="nCode">
		/// A hook code that the hook procedure uses to determine the action to perform. The value of the hook code depends on the type of
		/// the hook; each type has its own characteristic set of hook codes.
		/// </param>
		/// <param name="wParam">
		/// The value depends on the hook code, but typically contains information about a message that was sent or posted.
		/// </param>
		/// <param name="lParam">
		/// The value depends on the hook code, but typically contains information about a message that was sent or posted.
		/// </param>
		/// <returns>The value depends on the hook code.</returns>
		[PInvokeData("WinUser.h")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

		/// <summary>The type of hook procedure to be installed.</summary>
		[PInvokeData("WinUser.h", MSDNShortId = "ms644990")]
		public enum HookType
		{
			/// <summary>
			/// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu,
			/// or scroll bar. For more information, see the MessageProc hook procedure.
			/// </summary>
			WH_MSGFILTER = -1,

			/// <summary>
			/// Installs a hook procedure that records input messages posted to the system message queue. This hook is useful for recording
			/// macros. For more information, see the JournalRecordProc hook procedure.
			/// </summary>
			WH_JOURNALRECORD = 0,

			/// <summary>
			/// Installs a hook procedure that posts messages previously recorded by a WH_JOURNALRECORD hook procedure. For more information,
			/// see the JournalPlaybackProc hook procedure.
			/// </summary>
			WH_JOURNALPLAYBACK = 1,

			/// <summary>
			/// Installs a hook procedure that monitors keystroke messages. For more information, see the KeyboardProc hook procedure.
			/// </summary>
			WH_KEYBOARD = 2,

			/// <summary>
			/// Installs a hook procedure that monitors messages posted to a message queue. For more information, see the GetMsgProc hook procedure.
			/// </summary>
			WH_GETMESSAGE = 3,

			/// <summary>
			/// Installs a hook procedure that monitors messages before the system sends them to the destination window procedure. For more
			/// information, see the CallWndProc hook procedure.
			/// </summary>
			WH_CALLWNDPROC = 4,

			/// <summary>
			/// Installs a hook procedure that receives notifications useful to a CBT application. For more information, see the CBTProc hook procedure.
			/// </summary>
			WH_CBT = 5,

			/// <summary>
			/// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu,
			/// or scroll bar. The hook procedure monitors these messages for all applications in the same desktop as the calling thread. For
			/// more information, see the SysMsgProc hook procedure.
			/// </summary>
			WH_SYSMSGFILTER = 6,

			/// <summary>Installs a hook procedure that monitors mouse messages. For more information, see the MouseProc hook procedure.</summary>
			WH_MOUSE = 7,

			/// <summary></summary>
			WH_HARDWARE = 8,

			/// <summary>
			/// Installs a hook procedure useful for debugging other hook procedures. For more information, see the DebugProc hook procedure.
			/// </summary>
			WH_DEBUG = 9,

			/// <summary>
			/// Installs a hook procedure that receives notifications useful to shell applications. For more information, see the ShellProc
			/// hook procedure.
			/// </summary>
			WH_SHELL = 10,

			/// <summary>
			/// Installs a hook procedure that will be called when the application's foreground thread is about to become idle. This hook is
			/// useful for performing low priority tasks during idle time. For more information, see the ForegroundIdleProc hook procedure.
			/// </summary>
			WH_FOREGROUNDIDLE = 11,

			/// <summary>
			/// Installs a hook procedure that monitors messages after they have been processed by the destination window procedure. For more
			/// information, see the CallWndRetProc hook procedure.
			/// </summary>
			WH_CALLWNDPROCRET = 12,

			/// <summary>
			/// Installs a hook procedure that monitors low-level keyboard input events. For more information, see the LowLevelKeyboardProc
			/// hook procedure.
			/// </summary>
			WH_KEYBOARD_LL = 13,

			/// <summary>
			/// Installs a hook procedure that monitors low-level mouse input events. For more information, see the LowLevelMouseProc hook procedure.
			/// </summary>
			WH_MOUSE_LL = 14
		}

		/// <summary>
		/// <para>
		/// Passes the specified message and hook code to the hook procedures associated with the WH_SYSMSGFILTER and WH_MSGFILTER hooks. A
		/// <c>WH_SYSMSGFILTER</c> or <c>WH_MSGFILTER</c> hook procedure is an application-defined callback function that examines and,
		/// optionally, modifies messages for a dialog box, message box, menu, or scroll bar.
		/// </para>
		/// </summary>
		/// <param name="lpMsg">
		/// <para>Type: <c>LPMSG</c></para>
		/// <para>A pointer to an MSG structure that contains the message to be passed to the hook procedures.</para>
		/// </param>
		/// <param name="nCode">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// An application-defined code used by the hook procedure to determine how to process the message. The code must not have the same
		/// value as system-defined hook codes (MSGF_ and HC_) associated with the WH_SYSMSGFILTER and <c>WH_MSGFILTER</c> hooks.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the application should process the message further, the return value is zero.</para>
		/// <para>If the application should not process the message further, the return value is nonzero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system calls <c>CallMsgFilter</c> to enable applications to examine and control the flow of messages during internal
		/// processing of dialog boxes, message boxes, menus, and scroll bars, or when the user activates a different window by pressing the
		/// ALT+TAB key combination.
		/// </para>
		/// <para>Install this hook procedure by using the SetWindowsHookEx function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see WH_MSGFILTER and WH_SYSMSGFILTER Hooks.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-callmsgfiltera BOOL CallMsgFilterA( LPMSG lpMsg, int nCode );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "callmsgfilter")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CallMsgFilter(ref MSG lpMsg, int nCode);

		/// <summary>
		/// <para>
		/// Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call this function either
		/// before or after processing the hook information.
		/// </para>
		/// </summary>
		/// <param name="hhk">
		/// <para>Type: <c>HHOOK</c></para>
		/// <para>This parameter is ignored.</para>
		/// </param>
		/// <param name="nCode">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The hook code passed to the current hook procedure. The next hook procedure uses this code to determine how to process the hook information.
		/// </para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>
		/// The wParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with
		/// the current hook chain.
		/// </para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>
		/// The lParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with
		/// the current hook chain.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>LRESULT</c></c></para>
		/// <para>
		/// This value is returned by the next hook procedure in the chain. The current hook procedure must also return this value. The
		/// meaning of the return value depends on the hook type. For more information, see the descriptions of the individual hook procedures.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>Hook procedures are installed in chains for particular hook types. <c>CallNextHookEx</c> calls the next hook in the chain.</para>
		/// <para>
		/// Calling <c>CallNextHookEx</c> is optional, but it is highly recommended; otherwise, other applications that have installed hooks
		/// will not receive hook notifications and may behave incorrectly as a result. You should call <c>CallNextHookEx</c> unless you
		/// absolutely need to prevent the notification from being seen by other applications.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-callnexthookex LRESULT CallNextHookEx( HHOOK hhk, int
		// nCode, WPARAM wParam, LPARAM lParam );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "callnexthookex")]
		public static extern IntPtr CallNextHookEx(HHOOK hhk, int nCode, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// <para>
		/// Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to monitor the system for
		/// certain types of events. These events are associated either with a specific thread or with all threads in the same desktop as the
		/// calling thread.
		/// </para>
		/// </summary>
		/// <param name="idHook">
		/// <para>Type: <c>int</c></para>
		/// <para>The type of hook procedure to be installed. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WH_CALLWNDPROC 4</term>
		/// <term>
		/// Installs a hook procedure that monitors messages before the system sends them to the destination window procedure. For more
		/// information, see the CallWndProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_CALLWNDPROCRET 12</term>
		/// <term>
		/// Installs a hook procedure that monitors messages after they have been processed by the destination window procedure. For more
		/// information, see the CallWndRetProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_CBT 5</term>
		/// <term>
		/// Installs a hook procedure that receives notifications useful to a CBT application. For more information, see the CBTProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_DEBUG 9</term>
		/// <term>Installs a hook procedure useful for debugging other hook procedures. For more information, see the DebugProc hook procedure.</term>
		/// </item>
		/// <item>
		/// <term>WH_FOREGROUNDIDLE 11</term>
		/// <term>
		/// Installs a hook procedure that will be called when the application's foreground thread is about to become idle. This hook is
		/// useful for performing low priority tasks during idle time. For more information, see the ForegroundIdleProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_GETMESSAGE 3</term>
		/// <term>
		/// Installs a hook procedure that monitors messages posted to a message queue. For more information, see the GetMsgProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_JOURNALPLAYBACK 1</term>
		/// <term>
		/// Installs a hook procedure that posts messages previously recorded by a WH_JOURNALRECORD hook procedure. For more information, see
		/// the JournalPlaybackProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_JOURNALRECORD 0</term>
		/// <term>
		/// Installs a hook procedure that records input messages posted to the system message queue. This hook is useful for recording
		/// macros. For more information, see the JournalRecordProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_KEYBOARD 2</term>
		/// <term>Installs a hook procedure that monitors keystroke messages. For more information, see the KeyboardProc hook procedure.</term>
		/// </item>
		/// <item>
		/// <term>WH_KEYBOARD_LL 13</term>
		/// <term>
		/// Installs a hook procedure that monitors low-level keyboard input events. For more information, see the LowLevelKeyboardProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_MOUSE 7</term>
		/// <term>Installs a hook procedure that monitors mouse messages. For more information, see the MouseProc hook procedure.</term>
		/// </item>
		/// <item>
		/// <term>WH_MOUSE_LL 14</term>
		/// <term>
		/// Installs a hook procedure that monitors low-level mouse input events. For more information, see the LowLevelMouseProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_MSGFILTER -1</term>
		/// <term>
		/// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or
		/// scroll bar. For more information, see the MessageProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_SHELL 10</term>
		/// <term>
		/// Installs a hook procedure that receives notifications useful to shell applications. For more information, see the ShellProc hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WH_SYSMSGFILTER 6</term>
		/// <term>
		/// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or
		/// scroll bar. The hook procedure monitors these messages for all applications in the same desktop as the calling thread. For more
		/// information, see the SysMsgProc hook procedure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpfn">
		/// <para>Type: <c>HOOKPROC</c></para>
		/// <para>
		/// A pointer to the hook procedure. If the dwThreadId parameter is zero or specifies the identifier of a thread created by a
		/// different process, the lpfn parameter must point to a hook procedure in a DLL. Otherwise, lpfn can point to a hook procedure in
		/// the code associated with the current process.
		/// </para>
		/// </param>
		/// <param name="hmod">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod parameter must be set to <c>NULL</c>
		/// if the dwThreadId parameter specifies a thread created by the current process and if the hook procedure is within the code
		/// associated with the current process.
		/// </para>
		/// </param>
		/// <param name="dwThreadId">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero, the
		/// hook procedure is associated with all existing threads running in the same desktop as the calling thread. For Windows Store apps,
		/// see the Remarks section.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>HHOOK</c></c></para>
		/// <para>If the function succeeds, the return value is the handle to the hook procedure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>SetWindowsHookEx</c> can be used to inject a DLL into another process. A 32-bit DLL cannot be injected into a 64-bit process,
		/// and a 64-bit DLL cannot be injected into a 32-bit process. If an application requires the use of hooks in other processes, it is
		/// required that a 32-bit application call <c>SetWindowsHookEx</c> to inject a 32-bit DLL into 32-bit processes, and a 64-bit
		/// application call <c>SetWindowsHookEx</c> to inject a 64-bit DLL into 64-bit processes. The 32-bit and 64-bit DLLs must have
		/// different names.
		/// </para>
		/// <para>
		/// Because hooks run in the context of an application, they must match the "bitness" of the application. If a 32-bit application
		/// installs a global hook on 64-bit Windows, the 32-bit hook is injected into each 32-bit process (the usual security boundaries
		/// apply). In a 64-bit process, the threads are still marked as "hooked." However, because a 32-bit application must run the hook
		/// code, the system executes the hook in the hooking app's context; specifically, on the thread that called <c>SetWindowsHookEx</c>.
		/// This means that the hooking application must continue to pump messages or it might block the normal functioning of the 64-bit processes.
		/// </para>
		/// <para>
		/// If a 64-bit application installs a global hook on 64-bit Windows, the 64-bit hook is injected into each 64-bit process, while all
		/// 32-bit processes use a callback to the hooking application.
		/// </para>
		/// <para>
		/// To hook all applications on the desktop of a 64-bit Windows installation, install a 32-bit global hook and a 64-bit global hook,
		/// each from appropriate processes, and be sure to keep pumping messages in the hooking application to avoid blocking normal
		/// functioning. If you already have a 32-bit global hooking application and it doesn't need to run in each application's context,
		/// you may not need to create a 64-bit version.
		/// </para>
		/// <para>
		/// An error may occur if the hMod parameter is <c>NULL</c> and the dwThreadId parameter is zero or specifies the identifier of a
		/// thread created by another process.
		/// </para>
		/// <para>
		/// Calling the CallNextHookEx function to chain to the next hook procedure is optional, but it is highly recommended; otherwise,
		/// other applications that have installed hooks will not receive hook notifications and may behave incorrectly as a result. You
		/// should call <c>CallNextHookEx</c> unless you absolutely need to prevent the notification from being seen by other applications.
		/// </para>
		/// <para>
		/// Before terminating, an application must call the UnhookWindowsHookEx function to free system resources associated with the hook.
		/// </para>
		/// <para>
		/// The scope of a hook depends on the hook type. Some hooks can be set only with global scope; others can also be set for only a
		/// specific thread, as shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Hook</term>
		/// <term>Scope</term>
		/// </listheader>
		/// <item>
		/// <term>WH_CALLWNDPROC</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_CALLWNDPROCRET</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_CBT</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_DEBUG</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_FOREGROUNDIDLE</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_GETMESSAGE</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_JOURNALPLAYBACK</term>
		/// <term>Global only</term>
		/// </item>
		/// <item>
		/// <term>WH_JOURNALRECORD</term>
		/// <term>Global only</term>
		/// </item>
		/// <item>
		/// <term>WH_KEYBOARD</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_KEYBOARD_LL</term>
		/// <term>Global only</term>
		/// </item>
		/// <item>
		/// <term>WH_MOUSE</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_MOUSE_LL</term>
		/// <term>Global only</term>
		/// </item>
		/// <item>
		/// <term>WH_MSGFILTER</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_SHELL</term>
		/// <term>Thread or global</term>
		/// </item>
		/// <item>
		/// <term>WH_SYSMSGFILTER</term>
		/// <term>Global only</term>
		/// </item>
		/// </list>
		/// <para>
		/// For a specified hook type, thread hooks are called first, then global hooks. Be aware that the WH_MOUSE, WH_KEYBOARD,
		/// WH_JOURNAL*, WH_SHELL, and low-level hooks can be called on the thread that installed the hook rather than the thread processing
		/// the hook. For these hooks, it is possible that both the 32-bit and 64-bit hooks will be called if a 32-bit hook is ahead of a
		/// 64-bit hook in the hook chain.
		/// </para>
		/// <para>
		/// The global hooks are a shared resource, and installing one affects all applications in the same desktop as the calling thread.
		/// All global hook functions must be in libraries. Global hooks should be restricted to special-purpose applications or to use as a
		/// development aid during application debugging. Libraries that no longer need a hook should remove its hook procedure.
		/// </para>
		/// <para>
		/// <c>Windows Store app development</c> If dwThreadId is zero, then window hook DLLs are not loaded in-process for the Windows Store
		/// app processes and the Windows Runtime broker process unless they are installed by either UIAccess processes (accessibility
		/// tools). The notification is delivered on the installer's thread for these hooks:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>WH_JOURNALPLAYBACK</term>
		/// </item>
		/// <item>
		/// <term>WH_JOURNALRECORD</term>
		/// </item>
		/// <item>
		/// <term>WH_KEYBOARD</term>
		/// </item>
		/// <item>
		/// <term>WH_KEYBOARD_LL</term>
		/// </item>
		/// <item>
		/// <term>WH_MOUSE</term>
		/// </item>
		/// <item>
		/// <term>WH_MOUSE_LL</term>
		/// </item>
		/// </list>
		/// <para>
		/// This behavior is similar to what happens when there is an architecture mismatch between the hook DLL and the target application
		/// process, for example, when the hook DLL is 32-bit and the application process 64-bit.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Installing and Releasing Hook Procedures.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowshookexa HHOOK SetWindowsHookExA( int idHook,
		// HOOKPROC lpfn, HINSTANCE hmod, DWORD dwThreadId );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "setwindowshookex")]
		public static extern SafeHHOOK SetWindowsHookEx(HookType idHook, HookProc lpfn, HINSTANCE hmod, int dwThreadId);

		/// <summary>
		/// <para>Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.</para>
		/// </summary>
		/// <param name="hhk">
		/// <para>Type: <c>HHOOK</c></para>
		/// <para>A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to SetWindowsHookEx.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The hook procedure can be in the state of being called by another thread even after <c>UnhookWindowsHookEx</c> returns. If the
		/// hook procedure is not being called concurrently, the hook procedure is removed immediately before <c>UnhookWindowsHookEx</c> returns.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Monitoring System Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unhookwindowshookex BOOL UnhookWindowsHookEx( HHOOK hhk );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "unhookwindowshookex")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnhookWindowsHookEx(HHOOK hhk);

		/// <summary>
		/// <para>Contains information passed to a <c>WH_CBT</c> hook procedure, CBTProc, before a window is created.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagcbt_createwnda typedef struct tagCBT_CREATEWNDA {
		// struct tagCREATESTRUCTA *lpcs; HWND hwndInsertAfter; } CBT_CREATEWNDA, *LPCBT_CREATEWNDA;
		[PInvokeData("winuser.h", MSDNShortId = "cbt_createwnd.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CBT_CREATEWND
		{
			/// <summary>
			/// <para>Type: <c>LPCREATESTRUCT</c></para>
			/// <para>A pointer to a CREATESTRUCT structure that contains initialization parameters for the window about to be created.</para>
			/// </summary>
			public IntPtr lpcs;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// A handle to the window whose position in the Z order precedes that of the window being created. This member can also be <c>NULL</c>.
			/// </para>
			/// </summary>
			public HWND hwndInsertAfter;
		}

		/// <summary>
		/// <para>Contains information passed to a <c>WH_CBT</c> hook procedure, CBTProc, before a window is activated.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagcbtactivatestruct typedef struct tagCBTACTIVATESTRUCT {
		// BOOL fMouse; HWND hWndActive; } CBTACTIVATESTRUCT, *LPCBTACTIVATESTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "cbtactivatestruct.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CBTACTIVATESTRUCT
		{
			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>This member is <c>TRUE</c> if a mouse click is causing the activation or <c>FALSE</c> if it is not.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fMouse;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the active window.</para>
			/// </summary>
			public HWND hWndActive;
		}

		/// <summary>
		/// <para>Defines the message parameters passed to a <c>WH_CALLWNDPROCRET</c> hook procedure, CallWndRetProc.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagcwpretstruct typedef struct tagCWPRETSTRUCT { LRESULT
		// lResult; LPARAM lParam; WPARAM wParam; UINT message; HWND hwnd; } CWPRETSTRUCT, *PCWPRETSTRUCT, *NPCWPRETSTRUCT, *LPCWPRETSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "cwpretstruct.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CWPRETSTRUCT
		{
			/// <summary>
			/// <para>Type: <c>LRESULT</c></para>
			/// <para>The return value of the window procedure that processed the message specified by the <c>message</c> value.</para>
			/// </summary>
			public IntPtr lResult;

			/// <summary>
			/// <para>Type: <c>LPARAM</c></para>
			/// <para>Additional information about the message. The exact meaning depends on the <c>message</c> value.</para>
			/// </summary>
			public IntPtr lParam;

			/// <summary>
			/// <para>Type: <c>WPARAM</c></para>
			/// <para>Additional information about the message. The exact meaning depends on the <c>message</c> value.</para>
			/// </summary>
			public IntPtr wParam;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The message.</para>
			/// </summary>
			public uint message;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the window that processed the message specified by the <c>message</c> value.</para>
			/// </summary>
			public HWND hwnd;
		}

		/// <summary>
		/// <para>Defines the message parameters passed to a <c>WH_CALLWNDPROC</c> hook procedure, CallWndProc.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagcwpstruct typedef struct tagCWPSTRUCT { LPARAM lParam;
		// WPARAM wParam; UINT message; HWND hwnd; } CWPSTRUCT, *PCWPSTRUCT, *NPCWPSTRUCT, *LPCWPSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "cwpstruct.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CWPSTRUCT
		{
			/// <summary>
			/// <para>Type: <c>LPARAM</c></para>
			/// <para>Additional information about the message. The exact meaning depends on the <c>message</c> value.</para>
			/// </summary>
			public IntPtr lParam;

			/// <summary>
			/// <para>Type: <c>WPARAM</c></para>
			/// <para>Additional information about the message. The exact meaning depends on the <c>message</c> value.</para>
			/// </summary>
			public IntPtr wParam;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The message.</para>
			/// </summary>
			public uint message;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the window to receive the message.</para>
			/// </summary>
			public HWND hwnd;
		}

		/// <summary>
		/// <para>Contains debugging information passed to a <c>WH_DEBUG</c> hook procedure, DebugProc.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagdebughookinfo typedef struct tagDEBUGHOOKINFO { DWORD
		// idThread; DWORD idThreadInstaller; LPARAM lParam; WPARAM wParam; int code; } DEBUGHOOKINFO, *PDEBUGHOOKINFO, *NPDEBUGHOOKINFO, *LPDEBUGHOOKINFO;
		[PInvokeData("winuser.h", MSDNShortId = "debughookinfo.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DEBUGHOOKINFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A handle to the thread containing the filter function.</para>
			/// </summary>
			public uint idThread;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A handle to the thread that installed the debugging filter function.</para>
			/// </summary>
			public uint idThreadInstaller;

			/// <summary>
			/// <para>Type: <c>LPARAM</c></para>
			/// <para>The value to be passed to the hook in the lParam parameter of the DebugProc callback function.</para>
			/// </summary>
			public IntPtr lParam;

			/// <summary>
			/// <para>Type: <c>WPARAM</c></para>
			/// <para>The value to be passed to the hook in the wParam parameter of the DebugProc callback function.</para>
			/// </summary>
			public IntPtr wParam;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The value to be passed to the hook in the nCode parameter of the DebugProc callback function.</para>
			/// </summary>
			public int code;
		}

		/// <summary>
		/// <para>
		/// Contains information about a hardware message sent to the system message queue. This structure is used to store message
		/// information for the JournalPlaybackProc callback function.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tageventmsg typedef struct tagEVENTMSG { UINT message;
		// UINT paramL; UINT paramH; DWORD time; HWND hwnd; } EVENTMSG, *PEVENTMSGMSG, *NPEVENTMSGMSG, *LPEVENTMSGMSG, *PEVENTMSG,
		// *NPEVENTMSG, *LPEVENTMSG;
		[PInvokeData("winuser.h", MSDNShortId = "eventmsg.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct EVENTMSG
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The message.</para>
			/// </summary>
			public uint message;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>Additional information about the message. The exact meaning depends on the <c>message</c> value.</para>
			/// </summary>
			public uint paramL;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>Additional information about the message. The exact meaning depends on the <c>message</c> value.</para>
			/// </summary>
			public uint paramH;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The time at which the message was posted.</para>
			/// </summary>
			public uint time;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the window to which the message was posted.</para>
			/// </summary>
			public HWND hwnd;
		}

		/// <summary>Provides a handle to a hook.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HHOOK : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HHOOK"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HHOOK(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HHOOK"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HHOOK NULL => new HHOOK(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HHOOK"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HHOOK h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HHOOK"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HHOOK(IntPtr h) => new HHOOK(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HHOOK h1, HHOOK h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HHOOK h1, HHOOK h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HHOOK h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// <para>Contains information about a low-level keyboard input event.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagkbdllhookstruct typedef struct tagKBDLLHOOKSTRUCT {
		// DWORD vkCode; DWORD scanCode; DWORD flags; DWORD time; ULONG_PTR dwExtraInfo; } KBDLLHOOKSTRUCT, *LPKBDLLHOOKSTRUCT, *PKBDLLHOOKSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "kbdllhookstruct.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct KBDLLHOOKSTRUCT
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A virtual-key code. The code must be a value in the range 1 to 254.</para>
			/// </summary>
			public uint vkCode;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A hardware scan code for the key.</para>
			/// </summary>
			public uint scanCode;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The extended-key flag, event-injected flags, context code, and transition-state flag. This member is specified as follows. An
			/// application can use the following values to test the keystroke flags. Testing LLKHF_INJECTED (bit 4) will tell you whether
			/// the event was injected. If it was, then testing LLKHF_LOWER_IL_INJECTED (bit 1) will tell you whether or not the event was
			/// injected from a process running at lower integrity level.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>LLKHF_EXTENDED (KF_EXTENDED &gt;&gt; 8)</term>
			/// <term>Test the extended-key flag.</term>
			/// </item>
			/// <item>
			/// <term>LLKHF_LOWER_IL_INJECTED 0x00000002</term>
			/// <term>Test the event-injected (from a process running at lower integrity level) flag.</term>
			/// </item>
			/// <item>
			/// <term>LLKHF_INJECTED 0x00000010</term>
			/// <term>Test the event-injected (from any process) flag.</term>
			/// </item>
			/// <item>
			/// <term>LLKHF_ALTDOWN (KF_ALTDOWN &gt;&gt; 8)</term>
			/// <term>Test the context code.</term>
			/// </item>
			/// <item>
			/// <term>LLKHF_UP (KF_UP &gt;&gt; 8)</term>
			/// <term>Test the transition-state flag.</term>
			/// </item>
			/// </list>
			/// <para>The following table describes the layout of this value.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Bits</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>
			/// Specifies whether the key is an extended key, such as a function key or a key on the numeric keypad. The value is 1 if the
			/// key is an extended key; otherwise, it is 0.
			/// </term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>
			/// Specifies whether the event was injected from a process running at lower integrity level. The value is 1 if that is the case;
			/// otherwise, it is 0. Note that bit 4 is also set whenever bit 1 is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>2-3</term>
			/// <term>Reserved.</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>
			/// Specifies whether the event was injected. The value is 1 if that is the case; otherwise, it is 0. Note that bit 1 is not
			/// necessarily set when bit 4 is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>5</term>
			/// <term>The context code. The value is 1 if the ALT key is pressed; otherwise, it is 0.</term>
			/// </item>
			/// <item>
			/// <term>6</term>
			/// <term>Reserved.</term>
			/// </item>
			/// <item>
			/// <term>7</term>
			/// <term>The transition state. The value is 0 if the key is pressed and 1 if it is being released.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint flags;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The time stamp for this message, equivalent to what GetMessageTime would return for this message.</para>
			/// </summary>
			public uint time;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>Additional information associated with the message.</para>
			/// </summary>
			public UIntPtr dwExtraInfo;
		}

		/// <summary>
		/// <para>Contains information about a mouse event passed to a <c>WH_MOUSE</c> hook procedure, MouseProc.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmousehookstruct typedef struct tagMOUSEHOOKSTRUCT {
		// POINT pt; HWND hwnd; UINT wHitTestCode; ULONG_PTR dwExtraInfo; } MOUSEHOOKSTRUCT, *LPMOUSEHOOKSTRUCT, *PMOUSEHOOKSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "mousehookstruct.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MOUSEHOOKSTRUCT
		{
			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>The x- and y-coordinates of the cursor, in screen coordinates.</para>
			/// </summary>
			public System.Drawing.Point pt;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the window that will receive the mouse message corresponding to the mouse event.</para>
			/// </summary>
			public HWND hwnd;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The hit-test value. For a list of hit-test values, see the description of the WM_NCHITTEST message.</para>
			/// </summary>
			public uint wHitTestCode;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>Additional information associated with the message.</para>
			/// </summary>
			public UIntPtr dwExtraInfo;
		}

		/// <summary>
		/// <para>Contains information about a mouse event passed to a <c>WH_MOUSE</c> hook procedure, MouseProc.</para>
		/// <para>
		/// This is an extension of the MOUSEHOOKSTRUCT structure that includes information about wheel movement or the use of the X button.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmousehookstructex typedef struct tagMOUSEHOOKSTRUCTEX {
		// DWORD mouseData; base_class tagMOUSEHOOKSTRUCT; } MOUSEHOOKSTRUCTEX, *LPMOUSEHOOKSTRUCTEX, *PMOUSEHOOKSTRUCTEX;
		[PInvokeData("winuser.h", MSDNShortId = "mousehookstructex.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MOUSEHOOKSTRUCTEX
		{
			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>The x- and y-coordinates of the cursor, in screen coordinates.</para>
			/// </summary>
			public System.Drawing.Point pt;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the window that will receive the mouse message corresponding to the mouse event.</para>
			/// </summary>
			public HWND hwnd;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The hit-test value. For a list of hit-test values, see the description of the WM_NCHITTEST message.</para>
			/// </summary>
			public uint wHitTestCode;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>Additional information associated with the message.</para>
			/// </summary>
			public UIntPtr dwExtraInfo;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// If the message is WM_MOUSEWHEEL, the HIWORD of this member is the wheel delta. The LOWORD is undefined and reserved. A
			/// positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel
			/// was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.
			/// </para>
			/// <para>
			/// If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, or WM_NCXBUTTONDBLCLK,
			/// the HIWORD of <c>mouseData</c> specifies which X button was pressed or released, and the LOWORD is undefined and reserved.
			/// This member can be one or more of the following values. Otherwise, <c>mouseData</c> is not used.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>XBUTTON1 0x0001</term>
			/// <term>The first X button was pressed or released.</term>
			/// </item>
			/// <item>
			/// <term>XBUTTON2 0x0002</term>
			/// <term>The second X button was pressed or released.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint mouseData;
		}

		/// <summary>
		/// <para>Contains information about a low-level mouse input event.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmsllhookstruct typedef struct tagMSLLHOOKSTRUCT { POINT
		// pt; DWORD mouseData; DWORD flags; DWORD time; ULONG_PTR dwExtraInfo; } MSLLHOOKSTRUCT, *LPMSLLHOOKSTRUCT, *PMSLLHOOKSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "msllhookstruct.htm")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MSLLHOOKSTRUCT
		{
			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>The x- and y-coordinates of the cursor, in per-monitor-aware screen coordinates.</para>
			/// </summary>
			public System.Drawing.Point pt;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// If the message is WM_MOUSEWHEEL, the high-order word of this member is the wheel delta. The low-order word is reserved. A
			/// positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel
			/// was rotated backward, toward the user. One wheel click is defined as <c>WHEEL_DELTA</c>, which is 120.
			/// </para>
			/// <para>
			/// If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, or WM_NCXBUTTONDBLCLK,
			/// the high-order word specifies which X button was pressed or released, and the low-order word is reserved. This value can be
			/// one or more of the following values. Otherwise, <c>mouseData</c> is not used.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>XBUTTON1 0x0001</term>
			/// <term>The first X button was pressed or released.</term>
			/// </item>
			/// <item>
			/// <term>XBUTTON2 0x0002</term>
			/// <term>The second X button was pressed or released.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint mouseData;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The event-injected flags. An application can use the following values to test the flags. Testing LLMHF_INJECTED (bit 0) will
			/// tell you whether the event was injected. If it was, then testing LLMHF_LOWER_IL_INJECTED (bit 1) will tell you whether or not
			/// the event was injected from a process running at lower integrity level.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>LLMHF_INJECTED 0x00000001</term>
			/// <term>Test the event-injected (from any process) flag.</term>
			/// </item>
			/// <item>
			/// <term>LLMHF_LOWER_IL_INJECTED 0x00000002</term>
			/// <term>Test the event-injected (from a process running at lower integrity level) flag.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint flags;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The time stamp for this message.</para>
			/// </summary>
			public uint time;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>Additional information associated with the message.</para>
			/// </summary>
			public UIntPtr dwExtraInfo;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HHOOK"/> that is disposed using <see cref="UnhookWindowsHookEx"/>.</summary>
		public class SafeHHOOK : HANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHHOOK"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHHOOK(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHHOOK"/> class.</summary>
			private SafeHHOOK() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHHOOK"/> to <see cref="HHOOK"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HHOOK(SafeHHOOK h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => UnhookWindowsHookEx(this);
		}
	}
}