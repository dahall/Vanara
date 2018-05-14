using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>A pointer to the starting address of the thread.</summary>
		/// <param name="lpThreadParameter">
		/// A pointer to a variable to be passed as the lpParameter parameter to the function pointed to by the lpCallbackAddress parameter.
		/// </param>
		/// <returns>Zero if successfull. Otherwise, returns an error code.</returns>
		public delegate uint PTHREAD_START_ROUTINE(IntPtr lpThreadParameter);

		/// <summary>The options to continue the thread that reported the debugging event.</summary>
		public enum DEBUG_CONTINUE : uint
		{
			/// <summary>
			/// If the thread specified by the dwThreadId parameter previously reported an EXCEPTION_DEBUG_EVENT debugging event, the function stops all
			/// exception processing and continues the thread and the exception is marked as handled. For any other debugging event, this flag simply continues
			/// the thread.
			/// </summary>
			DBG_CONTINUE = 0x00010002,
			/// <summary>
			/// If the thread specified by dwThreadId previously reported an EXCEPTION_DEBUG_EVENT debugging event, the function continues exception processing.
			/// If this is a first-chance exception event, the search and dispatch logic of the structured exception handler is used; otherwise, the process is
			/// terminated. For any other debugging event, this flag simply continues the thread.
			/// </summary>
			DBG_EXCEPTION_NOT_HANDLED = 0x80010001,
			/// <summary>
			/// Supported in Windows 10, version 1507 or above, this flag causes dwThreadId to replay the existing breaking event after the target continues. By
			/// calling the SuspendThread API against dwThreadId, a debugger can resume other threads in the process and later return to the breaking.
			/// </summary>
			DBG_REPLY_LATER = 0x40010001,
		}

		/// <summary>The code that identifies the type of debugging event.</summary>
		public enum DEBUG_EVENT_CODE : uint
		{
			/// <summary>Reports a create-process debugging event. The value of u.CreateProcessInfo specifies a CREATE_PROCESS_DEBUG_INFO structure.</summary>
			CREATE_PROCESS_DEBUG_EVENT = 3,

			/// <summary>Reports a create-thread debugging event. The value of u.CreateThread specifies a CREATE_THREAD_DEBUG_INFO structure.</summary>
			CREATE_THREAD_DEBUG_EVENT = 2,

			/// <summary>Reports an exception debugging event. The value of u.Exception specifies an EXCEPTION_DEBUG_INFO structure.</summary>
			EXCEPTION_DEBUG_EVENT = 1,

			/// <summary>Reports an exit-process debugging event. The value of u.ExitProcess specifies an EXIT_PROCESS_DEBUG_INFO structure.</summary>
			EXIT_PROCESS_DEBUG_EVENT = 5,

			/// <summary>Reports an exit-thread debugging event. The value of u.ExitThread specifies an EXIT_THREAD_DEBUG_INFO structure.</summary>
			EXIT_THREAD_DEBUG_EVENT = 4,

			/// <summary>Reports a load-dynamic-link-library (DLL) debugging event. The value of u.LoadDll specifies a LOAD_DLL_DEBUG_INFO structure.</summary>
			LOAD_DLL_DEBUG_EVENT = 6,

			/// <summary>Reports an output-debugging-string debugging event. The value of u.DebugString specifies an OUTPUT_DEBUG_STRING_INFO structure.</summary>
			OUTPUT_DEBUG_STRING_EVENT = 8,

			/// <summary>Reports a RIP-debugging event (system debugging error). The value of u.RipInfo specifies a RIP_INFO structure.</summary>
			RIP_EVENT = 9,

			/// <summary>Reports an unload-DLL debugging event. The value of u.UnloadDll specifies an UNLOAD_DLL_DEBUG_INFO structure.</summary>
			UNLOAD_DLL_DEBUG_EVENT = 7,
		}

		/// <summary>Determines whether the specified process is being debugged.</summary>
		/// <param name="hProcess">A handle to the process.</param>
		/// <param name="pbDebuggerPresent">
		/// A pointer to a variable that the function sets to <c>TRUE</c> if the specified process is being debugged, or <c>FALSE</c> otherwise.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI CheckRemoteDebuggerPresent( _In_ HANDLE hProcess, _Inout_ PBOOL pbDebuggerPresent); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679280(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679280")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckRemoteDebuggerPresent([In] IntPtr hProcess, [MarshalAs(UnmanagedType.Bool)] ref bool pbDebuggerPresent);

		/// <summary>Enables a debugger to continue a thread that previously reported a debugging event.</summary>
		/// <param name="dwProcessId">The process identifier of the process to continue.</param>
		/// <param name="dwThreadId">
		/// The thread identifier of the thread to continue. The combination of process identifier and thread identifier must identify a thread that has
		/// previously reported a debugging event.
		/// </param>
		/// <param name="dwContinueStatus">
		/// <para>The options to continue the thread that reported the debugging event.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DBG_CONTINUE0x00010002L</term>
		/// <term>
		/// If the thread specified by the dwThreadId parameter previously reported an EXCEPTION_DEBUG_EVENT debugging event, the function stops all exception
		/// processing and continues the thread and the exception is marked as handled. For any other debugging event, this flag simply continues the thread.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DBG_EXCEPTION_NOT_HANDLED0x80010001L</term>
		/// <term>
		/// If the thread specified by dwThreadId previously reported an EXCEPTION_DEBUG_EVENT debugging event, the function continues exception processing. If
		/// this is a first-chance exception event, the search and dispatch logic of the structured exception handler is used; otherwise, the process is
		/// terminated. For any other debugging event, this flag simply continues the thread.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DBG_REPLY_LATER0x40010001L</term>
		/// <term>
		/// Supported in Windows 10, version 1507 or above, this flag causes dwThreadId to replay the existing breaking event after the target continues. By
		/// calling the SuspendThread API against dwThreadId, a debugger can resume other threads in the process and later return to the breaking.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI ContinueDebugEvent( _In_ DWORD dwProcessId, _In_ DWORD dwThreadId, _In_ DWORD dwContinueStatus); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679285(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679285")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ContinueDebugEvent(uint dwProcessId, uint dwThreadId, DEBUG_CONTINUE dwContinueStatus);

		/// <summary>Enables a debugger to attach to an active process and debug it.</summary>
		/// <param name="dwProcessId">
		/// The identifier for the process to be debugged. The debugger is granted debugging access to the process as if it created the process with the
		/// <c>DEBUG_ONLY_THIS_PROCESS</c> flag. For more information, see the Remarks section of this topic.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI DebugActiveProcess( _In_ DWORD dwProcessId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679295(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679295")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DebugActiveProcess(uint dwProcessId);

		/// <summary>Stops the debugger from debugging the specified process.</summary>
		/// <param name="dwProcessId">The identifier of the process to stop debugging.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI DebugActiveProcessStop( _In_ DWORD dwProcessId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679296(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679296")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DebugActiveProcessStop(uint dwProcessId);

		/// <summary>
		/// <para>Causes a breakpoint exception to occur in the current process. This allows the calling thread to signal the debugger to handle the exception.</para>
		/// <para>To cause a breakpoint exception in another process, use the <c>DebugBreakProcess</c> function.</para>
		/// </summary>
		/// <returns>This function does not return a value.</returns>
		// void WINAPI DebugBreak(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679297(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679297")]
		public static extern void DebugBreak();

		/// <summary>Determines whether the calling process is being debugged by a user-mode debugger.</summary>
		/// <returns>
		/// <para>If the current process is running in the context of a debugger, the return value is nonzero.</para>
		/// <para>If the current process is not running in the context of a debugger, the return value is zero.</para>
		/// </returns>
		// BOOL WINAPI IsDebuggerPresent(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680345(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680345")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsDebuggerPresent();

		/// <summary>Sends a string to the debugger for display.</summary>
		/// <param name="lpOutputString">The null-terminated string to be displayed.</param>
		/// <returns>This function does not return a value.</returns>
		// void WINAPI OutputDebugString( _In_opt_ LPCTSTR lpOutputString); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363362(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363362")]
		public static extern void OutputDebugString([In] string lpOutputString);

		/// <summary>Waits for a debugging event to occur in a process being debugged.</summary>
		/// <param name="lpDebugEvent">A pointer to a <c>DEBUG_EVENT</c> structure that receives information about the debugging event.</param>
		/// <param name="dwMilliseconds">
		/// The number of milliseconds to wait for a debugging event. If this parameter is zero, the function tests for a debugging event and returns
		/// immediately. If the parameter is INFINITE, the function does not return until a debugging event has occurred.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI WaitForDebugEvent( _Out_ LPDEBUG_EVENT lpDebugEvent, _In_ DWORD dwMilliseconds); https://msdn.microsoft.com/en-us/library/windows/desktop/ms681423(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms681423")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WaitForDebugEvent(out DEBUG_EVENT lpDebugEvent, uint dwMilliseconds);

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released. Microsoft makes no
		/// warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Waits for a debugging event to occur in a process being debugged.</para>
		/// </summary>
		/// <param name="lpDebugEvent">A pointer to a <c>DEBUG_EVENT</c> structure that receives information about the debugging event.</param>
		/// <param name="dwMilliseconds">
		/// The number of milliseconds to wait for a debugging event. If this parameter is zero, the function tests for a debugging event and returns
		/// immediately. If the parameter is INFINITE, the function does not return until a debugging event has occurred.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI WaitForDebugEventEx( _Out_ LPDEBUG_EVENT lpDebugEvent, _In_ DWORD dwMilliseconds); https://msdn.microsoft.com/en-us/library/windows/desktop/mt171594(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "mt171594")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WaitForDebugEventEx(out DEBUG_EVENT lpDebugEvent, uint dwMilliseconds);

		/// <summary>Describes a debugging event.</summary>
		// typedef struct _DEBUG_EVENT { DWORD dwDebugEventCode; DWORD dwProcessId; DWORD dwThreadId; union { EXCEPTION_DEBUG_INFO Exception;
		// CREATE_THREAD_DEBUG_INFO CreateThread; CREATE_PROCESS_DEBUG_INFO CreateProcessInfo; EXIT_THREAD_DEBUG_INFO ExitThread; EXIT_PROCESS_DEBUG_INFO
		// ExitProcess; LOAD_DLL_DEBUG_INFO LoadDll; UNLOAD_DLL_DEBUG_INFO UnloadDll; OUTPUT_DEBUG_STRING_INFO DebugString; RIP_INFO RipInfo; } u;} DEBUG_EVENT,
		// *LPDEBUG_EVENT;// https://msdn.microsoft.com/en-us/library/windows/desktop/ms679308(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms679308")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DEBUG_EVENT
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The code that identifies the type of debugging event. This member can be one of the following values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CREATE_PROCESS_DEBUG_EVENT3</term>
			/// <term>Reports a create-process debugging event. The value of u.CreateProcessInfo specifies a CREATE_PROCESS_DEBUG_INFO structure.</term>
			/// </item>
			/// <item>
			/// <term>CREATE_THREAD_DEBUG_EVENT2</term>
			/// <term>Reports a create-thread debugging event. The value of u.CreateThread specifies a CREATE_THREAD_DEBUG_INFO structure.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_DEBUG_EVENT1</term>
			/// <term>Reports an exception debugging event. The value of u.Exception specifies an EXCEPTION_DEBUG_INFO structure.</term>
			/// </item>
			/// <item>
			/// <term>EXIT_PROCESS_DEBUG_EVENT5</term>
			/// <term>Reports an exit-process debugging event. The value of u.ExitProcess specifies an EXIT_PROCESS_DEBUG_INFO structure.</term>
			/// </item>
			/// <item>
			/// <term>EXIT_THREAD_DEBUG_EVENT4</term>
			/// <term>Reports an exit-thread debugging event. The value of u.ExitThread specifies an EXIT_THREAD_DEBUG_INFO structure.</term>
			/// </item>
			/// <item>
			/// <term>LOAD_DLL_DEBUG_EVENT6</term>
			/// <term>Reports a load-dynamic-link-library (DLL) debugging event. The value of u.LoadDll specifies a LOAD_DLL_DEBUG_INFO structure.</term>
			/// </item>
			/// <item>
			/// <term>OUTPUT_DEBUG_STRING_EVENT8</term>
			/// <term>Reports an output-debugging-string debugging event. The value of u.DebugString specifies an OUTPUT_DEBUG_STRING_INFO structure.</term>
			/// </item>
			/// <item>
			/// <term>RIP_EVENT9</term>
			/// <term>Reports a RIP-debugging event (system debugging error). The value of u.RipInfo specifies a RIP_INFO structure.</term>
			/// </item>
			/// <item>
			/// <term>UNLOAD_DLL_DEBUG_EVENT7</term>
			/// <term>Reports an unload-DLL debugging event. The value of u.UnloadDll specifies an UNLOAD_DLL_DEBUG_INFO structure.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public DEBUG_EVENT_CODE dwDebugEventCode;
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The identifier of the process in which the debugging event occurred. A debugger uses this value to locate the debugger's per-process structure.
			/// These values are not necessarily small integers that can be used as table indices.
			/// </para>
			/// </summary>
			public uint dwProcessId;
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The identifier of the thread in which the debugging event occurred. A debugger uses this value to locate the debugger's per-thread structure.
			/// These values are not necessarily small integers that can be used as table indices.
			/// </para>
			/// </summary>
			public uint dwThreadId;
			/// <summary>
			/// Any additional information relating to the debugging event. This union takes on the type and value appropriate to the type of debugging event, as
			/// described in the <c>dwDebugEventCode</c> member.
			/// </summary>
			public EXCEPTION_INFO u;

			/// <summary>This union takes on the type and value appropriate to the type of debugging event, as described in the <c>dwDebugEventCode</c> member.</summary>
			[PInvokeData("WinBase.h", MSDNShortId = "ms679308")]
			[StructLayout(LayoutKind.Explicit)]
			public struct EXCEPTION_INFO
			{
				/// <summary>If the dwDebugEventCode is EXCEPTION_DEBUG_EVENT (1), u.Exception specifies an EXCEPTION_DEBUG_INFO structure.</summary>
				[FieldOffset(0)]
				public EXCEPTION_DEBUG_INFO Exception;
				/// <summary>If the dwDebugEventCode is CREATE_THREAD_DEBUG_EVENT (2), u.CreateThread specifies an CREATE_THREAD_DEBUG_INFO structure.</summary>
				[FieldOffset(0)]
				public CREATE_THREAD_DEBUG_INFO CreateThread;
				/// <summary>If the dwDebugEventCode is CREATE_PROCESS_DEBUG_EVENT (3), u.CreateProcessInfo specifies an CREATE_PROCESS_DEBUG_INFO structure.</summary>
				[FieldOffset(0)]
				public CREATE_PROCESS_DEBUG_INFO CreateProcessInfo;
				/// <summary>If the dwDebugEventCode is EXIT_THREAD_DEBUG_EVENT (4), u.ExitThread specifies an EXIT_THREAD_DEBUG_INFO structure.</summary>
				[FieldOffset(0)]
				public EXIT_THREAD_DEBUG_INFO ExitThread;
				/// <summary>If the dwDebugEventCode is EXIT_PROCESS_DEBUG_EVENT (5), u.ExitProcess specifies an EXIT_PROCESS_DEBUG_INFO structure.</summary>
				[FieldOffset(0)]
				public EXIT_PROCESS_DEBUG_INFO ExitProcess;
				/// <summary>If the dwDebugEventCode is LOAD_DLL_DEBUG_EVENT (6), u.LoadDll specifies an LOAD_DLL_DEBUG_INFO structure.</summary>
				[FieldOffset(0)]
				public LOAD_DLL_DEBUG_INFO LoadDll;
				/// <summary>If the dwDebugEventCode is UNLOAD_DLL_DEBUG_EVENT (7), u.UnloadDll specifies an UNLOAD_DLL_DEBUG_INFO structure.</summary>
				[FieldOffset(0)]
				public UNLOAD_DLL_DEBUG_INFO UnloadDll;
				/// <summary>If the dwDebugEventCode is OUTPUT_DEBUG_STRING_EVENT (8), u.DebugString specifies an OUTPUT_DEBUG_STRING_INFO structure.</summary>
				[FieldOffset(0)]
				public OUTPUT_DEBUG_STRING_INFO DebugString;
				/// <summary>If the dwDebugEventCode is RIP_EVENT (9), u.RipInfo specifies an RIP_INFO structure.</summary>
				[FieldOffset(0)]
				public RIP_INFO RipInfo;

				/// <summary>Contains exception information that can be used by a debugger.</summary>
				// typedef struct _EXCEPTION_DEBUG_INFO { EXCEPTION_RECORD ExceptionRecord; DWORD dwFirstChance;} EXCEPTION_DEBUG_INFO, *LPEXCEPTION_DEBUG_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/ms679326(v=vs.85).aspx
				[PInvokeData("WinBase.h", MSDNShortId = "ms679326")]
				[StructLayout(LayoutKind.Sequential)]
				public struct EXCEPTION_DEBUG_INFO
				{
					/// <summary>
					/// An <c>EXCEPTION_RECORD</c> structure with information specific to the exception. This includes the exception code, flags, address, a
					/// pointer to a related exception, extra parameters, and so on.
					/// </summary>
					public EXCEPTION_RECORD ExceptionRecord;
					/// <summary>
					/// A value that indicates whether the debugger has previously encountered the exception specified by the <c>ExceptionRecord</c> member. If
					/// the <c>dwFirstChance</c> member is nonzero, this is the first time the debugger has encountered the exception. Debuggers typically handle
					/// breakpoint and single-step exceptions when they are first encountered. If this member is zero, the debugger has previously encountered
					/// the exception. This occurs only if, during the search for structured exception handlers, either no handler was found or the exception was continued.
					/// </summary>
					public uint dwFirstChance;
				}

				/// <summary>Contains thread-creation information that can be used by a debugger.</summary>
				// typedef struct _CREATE_THREAD_DEBUG_INFO { HANDLE hThread; LPVOID lpThreadLocalBase; LPTHREAD_START_ROUTINE lpStartAddress;} CREATE_THREAD_DEBUG_INFO,
				// *LPCREATE_THREAD_DEBUG_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/ms679287(v=vs.85).aspx
				[PInvokeData("WinBase.h", MSDNShortId = "ms679287")]
				[StructLayout(LayoutKind.Sequential)]
				public struct CREATE_THREAD_DEBUG_INFO
				{
					/// <summary>
					/// A handle to the thread whose creation caused the debugging event. If this member is <c>NULL</c>, the handle is not valid. Otherwise, the
					/// debugger has THREAD_GET_CONTEXT, THREAD_SET_CONTEXT, and THREAD_SUSPEND_RESUME access to the thread, allowing the debugger to read from
					/// and write to the registers of the thread and control execution of the thread.
					/// </summary>
					public IntPtr hThread;
					/// <summary>
					/// A pointer to a block of data. At offset 0x2C into this block is another pointer, called ThreadLocalStoragePointer, that points to an
					/// array of per-module thread local storage blocks. This gives a debugger access to per-thread data in the threads of the process being
					/// debugged using the same algorithms that a compiler would use.
					/// </summary>
					public IntPtr lpThreadLocalBase;
					/// <summary>
					/// A pointer to the starting address of the thread. This value may only be an approximation of the thread's starting address, because any
					/// application with appropriate access to the thread can change the thread's context by using the <c>SetThreadContext</c> function.
					/// </summary>
					public PTHREAD_START_ROUTINE lpStartAddress;
				}

				/// <summary>Contains process creation information that can be used by a debugger.</summary>
				// typedef struct _CREATE_PROCESS_DEBUG_INFO { HANDLE hFile; HANDLE hProcess; HANDLE hThread; LPVOID lpBaseOfImage; DWORD dwDebugInfoFileOffset;
				// DWORD nDebugInfoSize; LPVOID lpThreadLocalBase; LPTHREAD_START_ROUTINE lpStartAddress; LPVOID lpImageName; WORD fUnicode;}
				// CREATE_PROCESS_DEBUG_INFO, *LPCREATE_PROCESS_DEBUG_INFO;
				[PInvokeData("WinBase.h", MSDNShortId = "ms679286")]
				[StructLayout(LayoutKind.Sequential)]
				public struct CREATE_PROCESS_DEBUG_INFO
				{
					/// <summary>
					/// <para>
					/// A handle to the process's image file. If this member is <c>NULL</c>, the handle is not valid. Otherwise, the debugger can use the member
					/// to read from and write to the image file.
					/// </para>
					/// <para>When the debugger is finished with this file, it should close the handle using the <c>CloseHandle</c> function.</para>
					/// </summary>
					public IntPtr hFile;
					/// <summary>
					/// A handle to the process. If this member is <c>NULL</c>, the handle is not valid. Otherwise, the debugger can use the member to read from
					/// and write to the process's memory.
					/// </summary>
					public IntPtr hProcess;
					/// <summary>
					/// A handle to the initial thread of the process identified by the <c>hProcess</c> member. If <c>hThread</c> param is <c>NULL</c>, the
					/// handle is not valid. Otherwise, the debugger has <c>THREAD_GET_CONTEXT</c>, <c>THREAD_SET_CONTEXT</c>, and <c>THREAD_SUSPEND_RESUME</c>
					/// access to the thread, allowing the debugger to read from and write to the registers of the thread and to control execution of the thread.
					/// </summary>
					public IntPtr hThread;
					/// <summary>The base address of the executable image that the process is running.</summary>
					public IntPtr lpBaseOfImage;
					/// <summary>The offset to the debugging information in the file identified by the <c>hFile</c> member.</summary>
					public uint dwDebugInfoFileOffset;
					/// <summary>The size of the debugging information in the file, in bytes. If this value is zero, there is no debugging information.</summary>
					public uint nDebugInfoSize;
					/// <summary>
					/// A pointer to a block of data. At offset 0x2C into this block is another pointer, called , that points to an array of per-module thread
					/// local storage blocks. This gives a debugger access to per-thread data in the threads of the process being debugged using the same
					/// algorithms that a compiler would use.
					/// </summary>
					public IntPtr lpThreadLocalBase;
					/// <summary>
					/// A pointer to the starting address of the thread. This value may only be an approximation of the thread's starting address, because any
					/// application with appropriate access to the thread can change the thread's context by using the <c>SetThreadContext</c> function.
					/// </summary>
					public PTHREAD_START_ROUTINE lpStartAddress;
					/// <summary>
					/// <para>
					/// A pointer to the file name associated with the <c>hFile</c> member. This parameter may be <c>NULL</c>, or it may contain the address of a
					/// string pointer in the address space of the process being debugged. That address may, in turn, either be <c>NULL</c> or point to the
					/// actual filename. If <c>fUnicode</c> is a nonzero value, the name string is Unicode; otherwise, it is ANSI.
					/// </para>
					/// <para>
					/// This member is strictly optional. Debuggers must be prepared to handle the case where <c>lpImageName</c> is <c>NULL</c> or *
					/// <c>lpImageName</c> (in the address space of the process being debugged) is <c>NULL</c>. Specifically, the system does not provide an
					/// image name for a create process event, and will not likely pass an image name for the first DLL event. The system also does not provide
					/// this information in the case of debug events that originate from a call to the <c>DebugActiveProcess</c> function.
					/// </para>
					/// </summary>
					public IntPtr lpImageName;
					/// <summary>
					/// A value that indicates whether a file name specified by the <c>lpImageName</c> member is Unicode or ANSI. A nonzero value indicates
					/// Unicode; zero indicates ANSI.
					/// </summary>
					public ushort fUnicode;
				}

				/// <summary>Contains the exit code for a terminating process.</summary>
				// typedef struct _EXIT_PROCESS_DEBUG_INFO { DWORD dwExitCode;} EXIT_PROCESS_DEBUG_INFO, *LPEXIT_PROCESS_DEBUG_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/ms679334(v=vs.85).aspx
				[PInvokeData("WinBase.h", MSDNShortId = "ms679334")]
				[StructLayout(LayoutKind.Sequential)]
				public struct EXIT_PROCESS_DEBUG_INFO
				{
					/// <summary>The exit code for the process.</summary>
					public uint dwExitCode;
				}

				/// <summary>Contains the exit code for a terminating thread.</summary>
				// typedef struct _EXIT_THREAD_DEBUG_INFO { DWORD dwExitCode;} EXIT_THREAD_DEBUG_INFO, *LPEXIT_THREAD_DEBUG_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/ms679335(v=vs.85).aspx
				[PInvokeData("WinBase.h", MSDNShortId = "ms679335")]
				[StructLayout(LayoutKind.Sequential)]
				public struct EXIT_THREAD_DEBUG_INFO
				{
					/// <summary>The exit code for the thread.</summary>
					public uint dwExitCode;
				}

				/// <summary>Contains information about a dynamic-link library (DLL) that has just been loaded.</summary>
				// typedef struct _LOAD_DLL_DEBUG_INFO { HANDLE hFile; LPVOID lpBaseOfDll; DWORD dwDebugInfoFileOffset; DWORD nDebugInfoSize; LPVOID lpImageName;
				// WORD fUnicode;} LOAD_DLL_DEBUG_INFO, *LPLOAD_DLL_DEBUG_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/ms680351(v=vs.85).aspx
				[PInvokeData("WinBase.h", MSDNShortId = "ms680351")]
				[StructLayout(LayoutKind.Sequential)]
				public struct LOAD_DLL_DEBUG_INFO
				{
					/// <summary>
					/// <para>
					/// A handle to the loaded DLL. If this member is <c>NULL</c>, the handle is not valid. Otherwise, the member is opened for reading and
					/// read-sharing in the context of the debugger.
					/// </para>
					/// <para>When the debugger is finished with this file, it should close the handle using the <c>CloseHandle</c> function.</para>
					/// </summary>
					public IntPtr hFile;
					/// <summary>A pointer to the base address of the DLL in the address space of the process loading the DLL.</summary>
					public IntPtr lpBaseOfDll;
					/// <summary>
					/// The offset to the debugging information in the file identified by the <c>hFile</c> member, in bytes. The system expects the debugging
					/// information to be in CodeView 4.0 format. This format is currently a derivative of Common Object File Format (COFF).
					/// </summary>
					public uint dwDebugInfoFileOffset;
					/// <summary>The size of the debugging information in the file, in bytes. If this member is zero, there is no debugging information.</summary>
					public uint nDebugInfoSize;
					/// <summary>
					/// <para>
					/// A pointer to the file name associated with <c>hFile</c>. This member may be <c>NULL</c>, or it may contain the address of a string
					/// pointer in the address space of the process being debugged. That address may, in turn, either be <c>NULL</c> or point to the actual
					/// filename. If <c>fUnicode</c> is a nonzero value, the name string is Unicode; otherwise, it is ANSI.
					/// </para>
					/// <para>
					/// This member is strictly optional. Debuggers must be prepared to handle the case where <c>lpImageName</c> is <c>NULL</c> or *
					/// <c>lpImageName</c> (in the address space of the process being debugged) is <c>NULL</c>. Specifically, the system will never provide an
					/// image name for a create process event, and it will not likely pass an image name for the first DLL event. The system will also never
					/// provide this information in the case of debugging events that originate from a call to the <c>DebugActiveProcess</c> function.
					/// </para>
					/// </summary>
					public IntPtr lpImageName;
					/// <summary>
					/// A value that indicates whether a filename specified by <c>lpImageName</c> is Unicode or ANSI. A nonzero value for this member indicates
					/// Unicode; zero indicates ANSI.
					/// </summary>
					public ushort fUnicode;
				}

				/// <summary>Contains information about a dynamic-link library (DLL) that has just been unloaded.</summary>
				// typedef struct _UNLOAD_DLL_DEBUG_INFO { LPVOID lpBaseOfDll;} UNLOAD_DLL_DEBUG_INFO, *LPUNLOAD_DLL_DEBUG_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/ms681403(v=vs.85).aspx
				[PInvokeData("WinBase.h", MSDNShortId = "ms681403")]
				[StructLayout(LayoutKind.Sequential)]
				public struct UNLOAD_DLL_DEBUG_INFO
				{
					/// <summary>A pointer to the base address of the DLL in the address space of the process unloading the DLL.</summary>
					public IntPtr lpBaseOfDll;
				}

				/// <summary>Contains the address, format, and length, in bytes, of a debugging string.</summary>
				// typedef struct _OUTPUT_DEBUG_STRING_INFO { LPSTR lpDebugStringData; WORD fUnicode; WORD nDebugStringLength;} OUTPUT_DEBUG_STRING_INFO,
				// *LPOUTPUT_DEBUG_STRING_INFO;// https://msdn.microsoft.com/en-us/library/windows/desktop/ms680545(v=vs.85).aspx
				[PInvokeData("WinBase.h", MSDNShortId = "ms680545")]
				[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
				public struct OUTPUT_DEBUG_STRING_INFO
				{
					/// <summary>
					/// The debugging string in the calling process's address space. The debugger can use the <c>ReadProcessMemory</c> function to retrieve the
					/// value of the string.
					/// </summary>
					public string lpDebugStringData;
					/// <summary>
					/// The format of the debugging string. If this member is zero, the debugging string is ANSI; if it is nonzero, the string is Unicode.
					/// </summary>
					public ushort fUnicode;
					/// <summary>The size of the debugging string, in characters. The length includes the string's terminating null character.</summary>
					public ushort nDebugStringLength;
				}

				/// <summary>Contains the error that caused the RIP debug event.</summary>
				// typedef struct _RIP_INFO { DWORD dwError; DWORD dwType;} RIP_INFO, *LPRIP_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/ms680587(v=vs.85).aspx
				[PInvokeData("WinBase.h", MSDNShortId = "ms680587")]
				[StructLayout(LayoutKind.Sequential)]
				public struct RIP_INFO
				{
					/// <summary>The error that caused the RIP debug event. For more information, see Error Handling.</summary>
					public uint dwError;
					/// <summary>
					/// <para>Any additional information about the type of error that caused the RIP debug event. This member can be one of the following values.</para>
					/// <para>
					/// <list type="table">
					/// <listheader>
					/// <term>Value</term>
					/// <term>Meaning</term>
					/// </listheader>
					/// <item>
					/// <term>SLE_ERROR = 0x00000001</term>
					/// <term>Indicates that invalid data was passed to the function that failed. This caused the application to fail.</term>
					/// </item>
					/// <item>
					/// <term>SLE_MINORERROR = 0x00000002</term>
					/// <term>Indicates that invalid data was passed to the function, but the error probably will not cause the application to fail.</term>
					/// </item>
					/// <item>
					/// <term>SLE_WARNING = 0x00000003</term>
					/// <term>Indicates that potentially invalid data was passed to the function, but the function completed processing.</term>
					/// </item>
					/// <item>
					/// <term>0</term>
					/// <term>Indicates that only dwError was set.</term>
					/// </item>
					/// </list>
					/// </para>
					/// </summary>
					public uint dwType;
				}
			}
		}
	}
}