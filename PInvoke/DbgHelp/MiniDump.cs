using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class DbgHelp
	{
		private const string Lib_Dbghelp = "dbghelp.dll";

		/// <summary>
		/// <para>An application-defined callback function used with MiniDumpWriteDump. It receives extended minidump information.</para>
		/// <para>
		/// The <c>MINIDUMP_CALLBACK_ROUTINE</c> type defines a pointer to this callback function. <c>MiniDumpCallback</c> is a placeholder
		/// for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="CallbackParam">An application-defined parameter value.</param>
		/// <param name="CallbackInput">A pointer to a MINIDUMP_CALLBACK_INPUT structure that specifies extended minidump information.</param>
		/// <param name="CallbackOutput">
		/// A pointer to a MINIDUMP_CALLBACK_OUTPUT structure that receives application-defined information from the callback function.
		/// </param>
		/// <returns>If the function succeeds, return <c>TRUE</c>; otherwise, return <c>FALSE</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/nc-minidumpapiset-minidump_callback_routine
		// MINIDUMP_CALLBACK_ROUTINE MinidumpCallbackRoutine; BOOL MinidumpCallbackRoutine( PVOID CallbackParam, PMINIDUMP_CALLBACK_INPUT
		// CallbackInput, PMINIDUMP_CALLBACK_OUTPUT CallbackOutput ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NC:minidumpapiset.MINIDUMP_CALLBACK_ROUTINE")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool MINIDUMP_CALLBACK_ROUTINE([In, Out] IntPtr CallbackParam, in MINIDUMP_CALLBACK_INPUT CallbackInput, ref MINIDUMP_CALLBACK_OUTPUT CallbackOutput);

		/// <summary>The flags that indicate the thread state.</summary>
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_THREAD_INFO")]
		[Flags]
		public enum MINIDUMP_THREAD_INFO_FLAG : uint
		{
			/// <summary>A placeholder thread due to an error accessing the thread. No thread information exists beyond the thread identifier.</summary>
			MINIDUMP_THREAD_INFO_ERROR_THREAD = 0x00000001,

			/// <summary>The thread has exited (not running any code) at the time of the dump.</summary>
			MINIDUMP_THREAD_INFO_EXITED_THREAD = 0x00000004,

			/// <summary>Thread context could not be retrieved.</summary>
			MINIDUMP_THREAD_INFO_INVALID_CONTEXT = 0x00000010,

			/// <summary>Thread information could not be retrieved.</summary>
			MINIDUMP_THREAD_INFO_INVALID_INFO = 0x00000008,

			/// <summary>TEB information could not be retrieved.</summary>
			MINIDUMP_THREAD_INFO_INVALID_TEB = 0x00000020,

			/// <summary>This is the thread that called MiniDumpWriteDump.</summary>
			MINIDUMP_THREAD_INFO_WRITING_THREAD = 0x00000002,
		}

		/// <summary>Reads a stream from a user-mode minidump file.</summary>
		/// <param name="BaseOfDump">
		/// A pointer to the base of the mapped minidump file. The file should have been mapped into memory using the MapViewOfFile function.
		/// </param>
		/// <param name="StreamNumber">
		/// The type of data to be read from the minidump file. This member can be one of the values in the MINIDUMP_STREAM_TYPE enumeration.
		/// </param>
		/// <param name="Dir">A pointer to a MINIDUMP_DIRECTORY structure.</param>
		/// <param name="StreamPointer">
		/// A pointer to the beginning of the minidump stream. The format of this stream depends on the value of StreamNumber. For more
		/// information, see MINIDUMP_STREAM_TYPE.
		/// </param>
		/// <param name="StreamSize">The size of the stream pointed to by StreamPointer, in bytes.</param>
		/// <returns>If the function succeeds, the return value is <c>TRUE</c>; otherwise, the return value is <c>FALSE</c>.</returns>
		/// <remarks>In this context, a data stream is a block of data written to a minidump file.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/nf-minidumpapiset-minidumpreaddumpstream BOOL
		// MiniDumpReadDumpStream( PVOID BaseOfDump, ULONG StreamNumber, PMINIDUMP_DIRECTORY *Dir, PVOID *StreamPointer, ULONG *StreamSize );
		[DllImport(Lib_Dbghelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NF:minidumpapiset.MiniDumpReadDumpStream")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MiniDumpReadDumpStream([In] IntPtr BaseOfDump, uint StreamNumber, out IntPtr Dir, out IntPtr StreamPointer, out uint StreamSize);

		/// <summary>Writes user-mode minidump information to the specified file.</summary>
		/// <param name="hProcess">
		/// <para>A handle to the process for which the information is to be generated.</para>
		/// <para>
		/// This handle must have <c>PROCESS_QUERY_INFORMATION</c> and <c>PROCESS_VM_READ</c> access to the process. If handle information
		/// is to be collected then <c>PROCESS_DUP_HANDLE</c> access is also required. For more information, see Process Security and Access
		/// Rights. The caller must also be able to get <c>THREAD_ALL_ACCESS</c> access to the threads in the process. For more information,
		/// see Thread Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="ProcessId">The identifier of the process for which the information is to be generated.</param>
		/// <param name="hFile">A handle to the file in which the information is to be written.</param>
		/// <param name="DumpType">
		/// The type of information to be generated. This parameter can be one or more of the values from the MINIDUMP_TYPE enumeration.
		/// </param>
		/// <param name="ExceptionParam">
		/// A pointer to a MINIDUMP_EXCEPTION_INFORMATION structure describing the client exception that caused the minidump to be
		/// generated. If the value of this parameter is <c>NULL</c>, no exception information is included in the minidump file.
		/// </param>
		/// <param name="UserStreamParam">
		/// A pointer to a MINIDUMP_USER_STREAM_INFORMATION structure. If the value of this parameter is <c>NULL</c>, no user-defined
		/// information is included in the minidump file.
		/// </param>
		/// <param name="CallbackParam">
		/// A pointer to a MINIDUMP_CALLBACK_INFORMATION structure that specifies a callback routine which is to receive extended minidump
		/// information. If the value of this parameter is <c>NULL</c>, no callbacks are performed.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is <c>TRUE</c>; otherwise, the return value is <c>FALSE</c>. To retrieve extended
		/// error information, call GetLastError. Note that the last error will be an <c>HRESULT</c> value.
		/// </para>
		/// <para>If the operation is canceled, the last error code is
		/// <code>HRESULT_FROM_WIN32(ERROR_CANCELLED)</code>
		/// .
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The MiniDumpCallback function receives extended minidump information from <c>MiniDumpWriteDump</c>. It also provides a way for
		/// the caller to determine the granularity of information written to the minidump file, as the callback function can filter the
		/// default information.
		/// </para>
		/// <para>
		/// <c>MiniDumpWriteDump</c> should be called from a separate process if at all possible, rather than from within the target process
		/// being dumped. This is especially true when the target process is already not stable. For example, if it just crashed. A loader
		/// deadlock is one of many potential side effects of calling <c>MiniDumpWriteDump</c> from within the target process.
		/// </para>
		/// <para>
		/// <c>MiniDumpWriteDump</c> may not produce a valid stack trace for the calling thread. To work around this problem, you must
		/// capture the state of the calling thread before calling <c>MiniDumpWriteDump</c> and use it as the ExceptionParam parameter. One
		/// way to do this is to force an exception inside a <c>__try</c>/ <c>__except</c> block and use the EXCEPTION_POINTERS information
		/// provided by GetExceptionInformation. Alternatively, you can call the function from a new worker thread and filter this worker
		/// thread from the dump.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/nf-minidumpapiset-minidumpwritedump BOOL MiniDumpWriteDump(
		// HANDLE hProcess, DWORD ProcessId, HANDLE hFile, MINIDUMP_TYPE DumpType, PMINIDUMP_EXCEPTION_INFORMATION ExceptionParam,
		// PMINIDUMP_USER_STREAM_INFORMATION UserStreamParam, PMINIDUMP_CALLBACK_INFORMATION CallbackParam );
		[DllImport(Lib_Dbghelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NF:minidumpapiset.MiniDumpWriteDump")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool MiniDumpWriteDump(HPROCESS hProcess, uint ProcessId, HFILE hFile, MINIDUMP_TYPE DumpType,
			[In, Optional] in MINIDUMP_EXCEPTION_INFORMATION ExceptionParam, [In, Optional] in MINIDUMP_USER_STREAM_INFORMATION UserStreamParam,
			[In, Optional] in MINIDUMP_CALLBACK_INFORMATION CallbackParam);

		/// <summary>Writes user-mode minidump information to the specified file.</summary>
		/// <param name="hProcess">
		/// <para>A handle to the process for which the information is to be generated.</para>
		/// <para>
		/// This handle must have <c>PROCESS_QUERY_INFORMATION</c> and <c>PROCESS_VM_READ</c> access to the process. If handle information
		/// is to be collected then <c>PROCESS_DUP_HANDLE</c> access is also required. For more information, see Process Security and Access
		/// Rights. The caller must also be able to get <c>THREAD_ALL_ACCESS</c> access to the threads in the process. For more information,
		/// see Thread Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="ProcessId">The identifier of the process for which the information is to be generated.</param>
		/// <param name="hFile">A handle to the file in which the information is to be written.</param>
		/// <param name="DumpType">
		/// The type of information to be generated. This parameter can be one or more of the values from the MINIDUMP_TYPE enumeration.
		/// </param>
		/// <param name="ExceptionParam">
		/// A pointer to a MINIDUMP_EXCEPTION_INFORMATION structure describing the client exception that caused the minidump to be
		/// generated. If the value of this parameter is <c>NULL</c>, no exception information is included in the minidump file.
		/// </param>
		/// <param name="UserStreamParam">
		/// A pointer to a MINIDUMP_USER_STREAM_INFORMATION structure. If the value of this parameter is <c>NULL</c>, no user-defined
		/// information is included in the minidump file.
		/// </param>
		/// <param name="CallbackParam">
		/// A pointer to a MINIDUMP_CALLBACK_INFORMATION structure that specifies a callback routine which is to receive extended minidump
		/// information. If the value of this parameter is <c>NULL</c>, no callbacks are performed.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is <c>TRUE</c>; otherwise, the return value is <c>FALSE</c>. To retrieve extended
		/// error information, call GetLastError. Note that the last error will be an <c>HRESULT</c> value.
		/// </para>
		/// <para>If the operation is canceled, the last error code is
		/// <code>HRESULT_FROM_WIN32(ERROR_CANCELLED)</code>
		/// .
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The MiniDumpCallback function receives extended minidump information from <c>MiniDumpWriteDump</c>. It also provides a way for
		/// the caller to determine the granularity of information written to the minidump file, as the callback function can filter the
		/// default information.
		/// </para>
		/// <para>
		/// <c>MiniDumpWriteDump</c> should be called from a separate process if at all possible, rather than from within the target process
		/// being dumped. This is especially true when the target process is already not stable. For example, if it just crashed. A loader
		/// deadlock is one of many potential side effects of calling <c>MiniDumpWriteDump</c> from within the target process.
		/// </para>
		/// <para>
		/// <c>MiniDumpWriteDump</c> may not produce a valid stack trace for the calling thread. To work around this problem, you must
		/// capture the state of the calling thread before calling <c>MiniDumpWriteDump</c> and use it as the ExceptionParam parameter. One
		/// way to do this is to force an exception inside a <c>__try</c>/ <c>__except</c> block and use the EXCEPTION_POINTERS information
		/// provided by GetExceptionInformation. Alternatively, you can call the function from a new worker thread and filter this worker
		/// thread from the dump.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/nf-minidumpapiset-minidumpwritedump BOOL MiniDumpWriteDump(
		// HANDLE hProcess, DWORD ProcessId, HANDLE hFile, MINIDUMP_TYPE DumpType, PMINIDUMP_EXCEPTION_INFORMATION ExceptionParam,
		// PMINIDUMP_USER_STREAM_INFORMATION UserStreamParam, PMINIDUMP_CALLBACK_INFORMATION CallbackParam );
		[DllImport(Lib_Dbghelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NF:minidumpapiset.MiniDumpWriteDump")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool MiniDumpWriteDump(HPROCESS hProcess, uint ProcessId, HFILE hFile, MINIDUMP_TYPE DumpType,
			[In, Optional] IntPtr ExceptionParam, [In, Optional] IntPtr UserStreamParam,
			[In, Optional] IntPtr CallbackParam);

		/// <summary/>
		[StructLayout(LayoutKind.Sequential, Size =
#if x64
			1232)]
#else
			716)]
#endif
		public struct CONTEXT
		{
			private ulong f0;
		}

		/// <summary></summary>
		[PInvokeData("minidumpapiset.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CPU_INFORMATION
		{
			/// <summary>X86 platforms use CPUID function to obtain processor information.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct X86CPUINFO
			{
				/// <summary>CPUID Subfunction 0, register EAX (VendorId [0]), EBX (VendorId [1]) and ECX (VendorId [2]).</summary>
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
				public uint[] VendorId;

				/// <summary>CPUID Subfunction 1, register EAX</summary>
				public uint VersionInformation;

				/// <summary>CPUID Subfunction 1, register EDX</summary>
				public uint FeatureInformation;

				/// <summary>CPUID, Subfunction 80000001, register EBX. This will only be obtained if the vendor id is "AuthenticAMD".</summary>
				public uint AMDExtendedCpuFeatures;
			}

			/// <summary>X86 platforms use CPUID function to obtain processor information.</summary>
			public X86CPUINFO X86CpuInfo;

			/// <summary>Non-x86 platforms use processor feature flags.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct OTHERCPUINFO
			{
				/// <summary>Non-x86 platforms use processor feature flags.</summary>
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
				public ulong[] ProcessorFeatures;
			}

			/// <summary>Non-x86 platforms use processor feature flags.</summary>
			public OTHERCPUINFO OtherCpuInfo;
		}

		/// <summary>Contains a pointer to an optional callback function that can be used by the MiniDumpWriteDump function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_callback_information typedef struct
		// _MINIDUMP_CALLBACK_INFORMATION { MINIDUMP_CALLBACK_ROUTINE CallbackRoutine; PVOID CallbackParam; } MINIDUMP_CALLBACK_INFORMATION, *PMINIDUMP_CALLBACK_INFORMATION;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_CALLBACK_INFORMATION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_CALLBACK_INFORMATION
		{
			/// <summary>A pointer to the MiniDumpCallback callback function.</summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public MINIDUMP_CALLBACK_ROUTINE CallbackRoutine;

			/// <summary>The application-defined data for <c>CallbackRoutine</c>.</summary>
			public IntPtr CallbackParam;
		}

		/// <summary>Contains information used by the MiniDumpCallback function.</summary>
		/// <remarks>
		/// If <c>CallbackType</c> is <c>CancelCallback</c> or <c>MemoryCallback</c>, the <c>ProcessId</c>, <c>ProcessHandle</c>, and
		/// <c>CallbackType</c> members are valid but no other input is specified.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_callback_input typedef struct
		// _MINIDUMP_CALLBACK_INPUT { ULONG ProcessId; HANDLE ProcessHandle; ULONG CallbackType; union { HRESULT Status;
		// MINIDUMP_THREAD_CALLBACK Thread; MINIDUMP_THREAD_EX_CALLBACK ThreadEx; MINIDUMP_MODULE_CALLBACK Module;
		// MINIDUMP_INCLUDE_THREAD_CALLBACK IncludeThread; MINIDUMP_INCLUDE_MODULE_CALLBACK IncludeModule; MINIDUMP_IO_CALLBACK Io;
		// MINIDUMP_READ_MEMORY_FAILURE_CALLBACK ReadMemoryFailure; ULONG SecondaryFlags; MINIDUMP_VM_QUERY_CALLBACK VmQuery;
		// MINIDUMP_VM_PRE_READ_CALLBACK VmPreRead; MINIDUMP_VM_POST_READ_CALLBACK VmPostRead; }; } MINIDUMP_CALLBACK_INPUT, *PMINIDUMP_CALLBACK_INPUT;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_CALLBACK_INPUT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_CALLBACK_INPUT
		{
			/// <summary>
			/// <para>The identifier of the process that contains callback function.</para>
			/// <para>This member is not used if <c>CallbackType</c> is <c>IoStartCallback</c>.</para>
			/// </summary>
			public uint ProcessId;

			/// <summary>
			/// <para>A handle to the process that contains the callback function.</para>
			/// <para>This member is not used if <c>CallbackType</c> is <c>IoStartCallback</c>.</para>
			/// </summary>
			public HPROCESS ProcessHandle;

			/// <summary>The type of callback function. This member can be one of the values in the MINIDUMP_CALLBACK_TYPE enumeration.</summary>
			public MINIDUMP_CALLBACK_TYPE CallbackType;

			/// <summary>Internal union.</summary>
			private UNION Union;

			/// <summary>
			/// If <c>CallbackType</c> is <c>KernelMinidumpStatusCallback</c>, the union is an <c>HRESULT</c> value that indicates the
			/// status of the kernel minidump write attempt.
			/// </summary>
			public HRESULT Status { get => Union.Status; set => Union.Status = value; }

			/// <summary>If <c>CallbackType</c> is <c>ThreadCallback</c>, the union is a MINIDUMP_THREAD_CALLBACK structure.</summary>
			public MINIDUMP_THREAD_CALLBACK Thread { get => Union.Thread; set => Union.Thread = value; }

			/// <summary>If <c>CallbackType</c> is <c>ThreadExCallback</c>, the union is a MINIDUMP_THREAD_EX_CALLBACK structure.</summary>
			public MINIDUMP_THREAD_EX_CALLBACK ThreadEx { get => Union.ThreadEx; set => Union.ThreadEx = value; }

			/// <summary>If <c>CallbackType</c> is <c>ModuleCallback</c>, the union is a MINIDUMP_MODULE_CALLBACK structure.</summary>
			public MINIDUMP_MODULE_CALLBACK Module { get => Union.Module; set => Union.Module = value; }

			/// <summary>
			/// <para>If <c>CallbackType</c> is <c>IncludeThreadCallback</c>, the union is a MINIDUMP_INCLUDE_THREAD_CALLBACK structure.</para>
			/// <para><c>DbgHelp 6.2 and earlier:</c> This member is not available.</para>
			/// </summary>
			public MINIDUMP_INCLUDE_THREAD_CALLBACK IncludeThread { get => Union.IncludeThread; set => Union.IncludeThread = value; }

			/// <summary>
			/// <para>If <c>CallbackType</c> is <c>IncludeModuleCallback</c>, the union is a MINIDUMP_INCLUDE_MODULE_CALLBACK structure.</para>
			/// <para><c>DbgHelp 6.2 and earlier:</c> This member is not available.</para>
			/// </summary>
			public MINIDUMP_INCLUDE_MODULE_CALLBACK IncludeModule { get => Union.IncludeModule; set => Union.IncludeModule = value; }

			/// <summary>
			/// <para>
			/// If <c>CallbackType</c> is <c>IoStartCallback</c>, <c>IoWriteAllCallback</c>, or <c>IoFinishCallback</c>, the union is a
			/// MINIDUMP_IO_CALLBACK structure.
			/// </para>
			/// <para><c>DbgHelp 6.4 and earlier:</c> This member is not available.</para>
			/// </summary>
			public MINIDUMP_IO_CALLBACK Io { get => Union.Io; set => Union.Io = value; }

			/// <summary>
			/// <para>
			/// If <c>CallbackType</c> is <c>ReadMemoryFailureCallback</c>, the union is a MINIDUMP_READ_MEMORY_FAILURE_CALLBACK structure.
			/// </para>
			/// <para><c>DbgHelp 6.4 and earlier:</c> This member is not available.</para>
			/// </summary>
			public MINIDUMP_READ_MEMORY_FAILURE_CALLBACK ReadMemoryFailure { get => Union.ReadMemoryFailure; set => Union.ReadMemoryFailure = value; }

			/// <summary>
			/// <para>Contains a value from the MINIDUMP_SECONDARY_FLAGS enumeration type.</para>
			/// <para><c>DbgHelp 6.5 and earlier:</c> This member is not available.</para>
			/// </summary>
			public MINIDUMP_SECONDARY_FLAGS SecondaryFlags { get => Union.SecondaryFlags; set => Union.SecondaryFlags = value; }

			/// <summary/>
			public MINIDUMP_VM_QUERY_CALLBACK VmQuery { get => Union.VmQuery; set => Union.VmQuery = value; }

			/// <summary/>
			public MINIDUMP_VM_PRE_READ_CALLBACK VmPreRead { get => Union.VmPreRead; set => Union.VmPreRead = value; }

			/// <summary/>
			public MINIDUMP_VM_POST_READ_CALLBACK VmPostRead { get => Union.VmPostRead; set => Union.VmPostRead = value; }
			/// <summary>Internal union.</summary>
			[StructLayout(LayoutKind.Explicit)]
			private struct UNION
			{
				[FieldOffset(0)]
				private HRESULT Status;

				[FieldOffset(0)]
				private MINIDUMP_THREAD_CALLBACK Thread;

				[FieldOffset(0)]
				private MINIDUMP_THREAD_EX_CALLBACK ThreadEx;

				[FieldOffset(0)]
				private MINIDUMP_MODULE_CALLBACK Module;

				[FieldOffset(0)]
				private MINIDUMP_INCLUDE_THREAD_CALLBACK IncludeThread;

				[FieldOffset(0)]
				private MINIDUMP_INCLUDE_MODULE_CALLBACK IncludeModule;

				[FieldOffset(0)]
				private MINIDUMP_IO_CALLBACK Io;

				[FieldOffset(0)]
				private MINIDUMP_READ_MEMORY_FAILURE_CALLBACK ReadMemoryFailure;

				[FieldOffset(0)]
				private MINIDUMP_SECONDARY_FLAGS SecondaryFlags;

				[FieldOffset(0)]
				private MINIDUMP_VM_QUERY_CALLBACK VmQuery;

				[FieldOffset(0)]
				private MINIDUMP_VM_PRE_READ_CALLBACK VmPreRead;

				[FieldOffset(0)]
				private MINIDUMP_VM_POST_READ_CALLBACK VmPostRead;
			}
		}

		/// <summary>Contains information returned by the MiniDumpCallback function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_callback_output typedef struct
		// _MINIDUMP_CALLBACK_OUTPUT { union { ULONG ModuleWriteFlags; ULONG ThreadWriteFlags; ULONG SecondaryFlags; struct { ULONG64
		// MemoryBase; ULONG MemorySize; }; struct { BOOL CheckCancel; BOOL Cancel; }; HANDLE Handle; struct { MINIDUMP_MEMORY_INFO
		// VmRegion; BOOL Continue; }; struct { HRESULT VmQueryStatus; MINIDUMP_MEMORY_INFO VmQueryResult; }; struct { HRESULT VmReadStatus;
		// ULONG VmReadBytesCompleted; }; HRESULT Status; }; } MINIDUMP_CALLBACK_OUTPUT, *PMINIDUMP_CALLBACK_OUTPUT;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_CALLBACK_OUTPUT")]
		[StructLayout(LayoutKind.Explicit)]
		public struct MINIDUMP_CALLBACK_OUTPUT
		{
			/// <summary>
			/// <para>
			/// The module write operation flags. This member can be one or more of the values in the MODULE_WRITE_FLAGS enumeration. The
			/// flags are set to their default values on entry to the callback.
			/// </para>
			/// <para>This member is ignored unless the callback type is <c>IncludeModuleCallback</c> or <c>ModuleCallback</c>.</para>
			/// </summary>
			[FieldOffset(0)]
			public MODULE_WRITE_FLAGS ModuleWriteFlags;

			/// <summary>
			/// <para>
			/// The thread write operation flags. This member can be one or more of the values in the THREAD_WRITE_FLAGS enumeration. The
			/// flags are set to their default values on entry to the callback.
			/// </para>
			/// <para>This member is ignored unless the callback type is <c>IncludeThreadCallback</c>, <c>ThreadCallback</c>, or <c>ThreadExCallback</c>.</para>
			/// </summary>
			[FieldOffset(0)]
			public THREAD_WRITE_FLAGS ThreadWriteFlags;

			/// <summary>
			/// <para>Contains a value from the MINIDUMP_SECONDARY_FLAGS enumeration type.</para>
			/// <para><c>DbgHelp 6.5 and earlier:</c> This member is not available.</para>
			/// </summary>
			[FieldOffset(0)]
			public MINIDUMP_SECONDARY_FLAGS SecondaryFlags;

			/// <summary>
			/// <para>The base address of the memory region to be included in the dump.</para>
			/// <para>This member is ignored unless the callback type is <c>MemoryCallback</c> or <c>RemoveMemoryCallback</c>.</para>
			/// </summary>
			[FieldOffset(0)]
			public ulong MemoryBase;

			/// <summary>
			/// <para>The size of the memory region to be included in the dump, in bytes.</para>
			/// <para>This member is ignored unless the callback type is <c>MemoryCallback</c> or <c>RemoveMemoryCallback</c>.</para>
			/// </summary>
			[FieldOffset(8)]
			public uint MemorySize;

			/// <summary>
			/// <para>
			/// Controls whether the callback function should receive cancel callbacks. If this member is <c>TRUE</c>, the cancel callbacks
			/// will continue. Otherwise, they will not.
			/// </para>
			/// <para>This member is ignored unless the callback type is <c>CancelCallback</c>.</para>
			/// </summary>
			[FieldOffset(0)]
			[MarshalAs(UnmanagedType.Bool)] public bool CheckCancel;

			/// <summary>
			/// <para>
			/// Controls whether the dump should be canceled. If the callback function returns <c>TRUE</c> and <c>Cancel</c> is <c>TRUE</c>,
			/// the dump will be canceled. In this case, the MiniDumpWriteDump function fails and the dump is not valid.
			/// </para>
			/// <para>This member is ignored unless the callback type is <c>CancelCallback</c>.</para>
			/// </summary>
			[FieldOffset(4)]
			[MarshalAs(UnmanagedType.Bool)] public bool Cancel;

			/// <summary>
			/// <para>A handle to the file to which a kernel minidump will be written.</para>
			/// <para>This member is ignored unless the callback type is <c>WriteKernelMinidumpCallback</c>.</para>
			/// </summary>
			[FieldOffset(0)]
			public HFILE Handle;

			/// <summary>
			/// <para>
			/// A MINIDUMP_MEMORY_INFO structure that describes the virtual memory region. The region base and size must be aligned on a
			/// page boundary. The region size can be set to 0 to filter out the region.
			/// </para>
			/// <para>This member is ignored unless the callback type is <c>IncludeVmRegionCallback</c>.</para>
			/// </summary>
			[FieldOffset(0)]
			public MINIDUMP_MEMORY_INFO VmRegion;

			/// <summary>
			/// <para>
			/// Controls whether the dump should be continued. If the callback function returns <c>TRUE</c> and <c>Continue</c> is
			/// <c>TRUE</c>, the dump will be continued. Otherwise, the MiniDumpWriteDump function fails and the dump is not valid.
			/// </para>
			/// <para>This member is ignored unless the callback type is <c>IncludeVmRegionCallback</c>.</para>
			/// </summary>
			[FieldOffset(48)]
			[MarshalAs(UnmanagedType.Bool)]
			public bool Continue;

			/// <summary/>
			[FieldOffset(0)]
			public HRESULT VmQueryStatus;

			/// <summary/>
			public MINIDUMP_MEMORY_INFO VmQueryResult { get => ptrmi.f1; set => ptrmi.f1 = value; }

			/// <summary/>
			[FieldOffset(0)]
			public HRESULT VmReadStatus;

			/// <summary/>
			public uint VmReadBytesCompleted { get => ptrUint.f1; set => ptrUint.f1 = value; }

			/// <summary>
			/// <para>The status of the operation.</para>
			/// <para>
			/// This member is ignored unless the callback type is <c>ReadMemoryFailureCallback</c>, <c>IoStartCallback</c>,
			/// <c>IoWriteAllCallback</c>, or <c>IoFinishCallback</c>.
			/// </para>
			/// </summary>
			[FieldOffset(0)]
			public HRESULT Status;

			[FieldOffset(0)]
			private PtrUint ptrUint;

			[FieldOffset(0)]
			private PtrMI ptrmi;

			[StructLayout(LayoutKind.Sequential)]
			private struct PtrUint
			{
				private IntPtr f0;
				internal uint f1;
			}
			[StructLayout(LayoutKind.Sequential)]
			private struct PtrMI
			{
				private IntPtr f0;
				internal MINIDUMP_MEMORY_INFO f1;
			}
		}

		/// <summary>Contains the information needed to access a specific data stream in a minidump file.</summary>
		/// <remarks>In this context, a data stream is a block of data within a minidump file.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_directory typedef struct
		// _MINIDUMP_DIRECTORY { ULONG32 StreamType; MINIDUMP_LOCATION_DESCRIPTOR Location; } MINIDUMP_DIRECTORY, *PMINIDUMP_DIRECTORY;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_DIRECTORY")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_DIRECTORY
		{
			/// <summary>The type of data stream. This member can be one of the values in the MINIDUMP_STREAM_TYPE enumeration.</summary>
			public MINIDUMP_STREAM_TYPE StreamType;

			/// <summary>A MINIDUMP_LOCATION_DESCRIPTOR structure that specifies the location of the data stream.</summary>
			public MINIDUMP_LOCATION_DESCRIPTOR Location;
		}

		/// <summary>Contains exception information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_exception typedef struct
		// _MINIDUMP_EXCEPTION { ULONG32 ExceptionCode; ULONG32 ExceptionFlags; ULONG64 ExceptionRecord; ULONG64 ExceptionAddress; ULONG32
		// NumberParameters; ULONG32 __unusedAlignment; ULONG64 ExceptionInformation[EXCEPTION_MAXIMUM_PARAMETERS]; } MINIDUMP_EXCEPTION, *PMINIDUMP_EXCEPTION;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_EXCEPTION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_EXCEPTION
		{
			/// <summary>
			/// <para>
			/// The reason the exception occurred. This is the code generated by a hardware exception, or the code specified in the
			/// RaiseException function for a software-generated exception. Following are the exception codes likely to occur due to common
			/// programming errors.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>EXCEPTION_ACCESS_VIOLATION</term>
			/// <term>The thread tried to read from or write to a virtual address for which it does not have the appropriate access.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_ARRAY_BOUNDS_EXCEEDED</term>
			/// <term>The thread tried to access an array element that is out of bounds and the underlying hardware supports bounds checking.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_BREAKPOINT</term>
			/// <term>A breakpoint was encountered.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_DATATYPE_MISALIGNMENT</term>
			/// <term>
			/// The thread tried to read or write data that is misaligned on hardware that does not provide alignment. For example, 16-bit
			/// values must be aligned on 2-byte boundaries; 32-bit values on 4-byte boundaries, and so on.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_FLT_DENORMAL_OPERAND</term>
			/// <term>
			/// One of the operands in a floating-point operation is denormal. A denormal value is one that is too small to represent as a
			/// standard floating-point value.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_FLT_DIVIDE_BY_ZERO</term>
			/// <term>The thread tried to divide a floating-point value by a floating-point divisor of zero.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_FLT_INEXACT_RESULT</term>
			/// <term>The result of a floating-point operation cannot be represented exactly as a decimal fraction.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_FLT_INVALID_OPERATION</term>
			/// <term>This exception represents any floating-point exception not included in this list.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_FLT_OVERFLOW</term>
			/// <term>The exponent of a floating-point operation is greater than the magnitude allowed by the corresponding type.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_FLT_STACK_CHECK</term>
			/// <term>The stack overflowed or underflowed as the result of a floating-point operation.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_FLT_UNDERFLOW</term>
			/// <term>The exponent of a floating-point operation is less than the magnitude allowed by the corresponding type.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_ILLEGAL_INSTRUCTION</term>
			/// <term>The thread tried to execute an invalid instruction.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_IN_PAGE_ERROR</term>
			/// <term>
			/// The thread tried to access a page that was not present, and the system was unable to load the page. For example, this
			/// exception might occur if a network connection is lost while running a program over the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_INT_DIVIDE_BY_ZERO</term>
			/// <term>The thread tried to divide an integer value by an integer divisor of zero.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_INT_OVERFLOW</term>
			/// <term>The result of an integer operation caused a carry out of the most significant bit of the result.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_INVALID_DISPOSITION</term>
			/// <term>
			/// An exception handler returned an invalid disposition to the exception dispatcher. Programmers using a high-level language
			/// such as C should never encounter this exception.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_NONCONTINUABLE_EXCEPTION</term>
			/// <term>The thread tried to continue execution after a noncontinuable exception occurred.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_PRIV_INSTRUCTION</term>
			/// <term>The thread tried to execute an instruction whose operation is not allowed in the current machine mode.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_SINGLE_STEP</term>
			/// <term>A trace trap or other single-instruction mechanism signaled that one instruction has been executed.</term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_STACK_OVERFLOW</term>
			/// <term>The thread used up its stack.</term>
			/// </item>
			/// </list>
			/// <para>
			/// Another exception code is likely to occur when debugging console processes. It does not arise because of a programming
			/// error. The DBG_CONTROL_C exception code occurs when CTRL+C is input to a console process that handles CTRL+C signals and is
			/// being debugged. This exception code is not meant to be handled by applications. It is raised only for the benefit of the
			/// debugger, and is raised only when a debugger is attached to the console process.
			/// </para>
			/// </summary>
			public NTStatus ExceptionCode;

			/// <summary>
			/// This member can be either zero, indicating a continuable exception, or EXCEPTION_NONCONTINUABLE, indicating a noncontinuable
			/// exception. Any attempt to continue execution after a noncontinuable exception causes the EXCEPTION_NONCONTINUABLE_EXCEPTION exception.
			/// </summary>
			public Kernel32.EXCEPTION_FLAG ExceptionFlags;

			/// <summary>
			/// A pointer to an associated <c>MINIDUMP_EXCEPTION</c> structure. Exception records can be chained together to provide
			/// additional information when nested exceptions occur.
			/// </summary>
			public ulong ExceptionRecord;

			/// <summary>The address where the exception occurred.</summary>
			public ulong ExceptionAddress;

			/// <summary>
			/// The number of parameters associated with the exception. This is the number of defined elements in the
			/// <c>ExceptionInformation</c> array.
			/// </summary>
			public uint NumberParameters;

			/// <summary>Reserved for cross-platform structure member alignment. Do not set.</summary>
			private uint unusedAlignment;

			/// <summary>
			/// <para>
			/// An array of additional arguments that describe the exception. The RaiseException function can specify this array of
			/// arguments. For most exception codes, the array elements are undefined. For the following exception code, the array elements
			/// are defined as follows.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Exception code</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>EXCEPTION_ACCESS_VIOLATION</term>
			/// <term>
			/// The first element of the array contains a read/write flag that indicates the type of operation that caused the access
			/// violation. If this value is zero, the thread attempted to read the inaccessible data. If this value is 1, the thread
			/// attempted to write to an inaccessible address. The second array element specifies the virtual address of the inaccessible data.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
			public ulong[] ExceptionInformation;
		}

		/// <summary>Contains the exception information written to the minidump file by the MiniDumpWriteDump function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_exception_information typedef struct
		// _MINIDUMP_EXCEPTION_INFORMATION { DWORD ThreadId; PEXCEPTION_POINTERS ExceptionPointers; BOOL ClientPointers; }
		// MINIDUMP_EXCEPTION_INFORMATION, *PMINIDUMP_EXCEPTION_INFORMATION;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_EXCEPTION_INFORMATION")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct MINIDUMP_EXCEPTION_INFORMATION
		{
			/// <summary>The identifier of the thread throwing the exception.</summary>
			public uint ThreadId;

			/// <summary>
			/// A pointer to an EXCEPTION_POINTERS structure specifying a computer-independent description of the exception and the
			/// processor context at the time of the exception.
			/// </summary>
			public IntPtr ExceptionPointers;

			/// <summary>
			/// Determines where to get the memory regions pointed to by the <c>ExceptionPointers</c> member. Set to <c>TRUE</c> if the
			/// memory resides in the process being debugged (the target process of the debugger). Otherwise, set to <c>FALSE</c> if the
			/// memory resides in the address space of the calling program (the debugger process). If you are accessing local memory (in the
			/// calling process) you should not set this member to <c>TRUE</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool ClientPointers;
		}

		/// <summary>Represents an exception information stream.</summary>
		/// <remarks>In this context, a data stream is a set of data in a minidump file.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_exception_stream typedef struct
		// MINIDUMP_EXCEPTION_STREAM { ULONG32 ThreadId; ULONG32 __alignment; MINIDUMP_EXCEPTION ExceptionRecord;
		// MINIDUMP_LOCATION_DESCRIPTOR ThreadContext; } MINIDUMP_EXCEPTION_STREAM, *PMINIDUMP_EXCEPTION_STREAM;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset.MINIDUMP_EXCEPTION_STREAM")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_EXCEPTION_STREAM
		{
			/// <summary>The identifier of the thread that caused the exception.</summary>
			public uint ThreadId;

			/// <summary>A variable for alignment.</summary>
			private uint __alignment;

			/// <summary>A MINIDUMP_EXCEPTION structure.</summary>
			public MINIDUMP_EXCEPTION ExceptionRecord;

			/// <summary>A MINIDUMP_LOCATION_DESCRIPTOR structure.</summary>
			public MINIDUMP_LOCATION_DESCRIPTOR ThreadContext;
		}

		/// <summary>Represents a function table stream.</summary>
		/// <remarks>
		/// The first descriptor in the function table stream follows the header, MINIDUMP_FUNCTION_TABLE_STREAM. The generic descriptor is
		/// followed by a native system descriptor, then by <c>EntryCount</c> native system function entry structures.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_function_table_descriptor typedef
		// struct _MINIDUMP_FUNCTION_TABLE_DESCRIPTOR { ULONG64 MinimumAddress; ULONG64 MaximumAddress; ULONG64 BaseAddress; ULONG32
		// EntryCount; ULONG32 SizeOfAlignPad; } MINIDUMP_FUNCTION_TABLE_DESCRIPTOR, *PMINIDUMP_FUNCTION_TABLE_DESCRIPTOR;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_FUNCTION_TABLE_DESCRIPTOR")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_FUNCTION_TABLE_DESCRIPTOR
		{
			/// <summary>The minimum address of functions described by the table.</summary>
			public ulong MinimumAddress;

			/// <summary>The maximum address of functions described by the table.</summary>
			public ulong MaximumAddress;

			/// <summary>The base address to use when computing full virtual addresses from relative virtual addresses in function entries.</summary>
			public ulong BaseAddress;

			/// <summary>The number of entries in the function table.</summary>
			public uint EntryCount;

			/// <summary>
			/// The size of alignment padding that follows the function entry data, in bytes. The function entry data in the stream is
			/// guaranteed to be aligned appropriately for access to the data members. If a minidump is directly mapped in memory, it is
			/// always possible to directly reference structure members in the stream.
			/// </summary>
			public uint SizeOfAlignPad;
		}

		/// <summary>Represents the header for the function table stream.</summary>
		/// <remarks>
		/// In this context, a data stream is a set of data in a minidump file. This header structure is followed by
		/// <c>NumberOfDescriptors</c> function tables. For each function table there is a MINIDUMP_FUNCTION_TABLE_DESCRIPTOR structure,
		/// then the raw system descriptor for the table, then the raw system function entry data. If necessary, alignment padding is placed
		/// between tables to properly align the initial structures.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_function_table_stream typedef struct
		// _MINIDUMP_FUNCTION_TABLE_STREAM { ULONG32 SizeOfHeader; ULONG32 SizeOfDescriptor; ULONG32 SizeOfNativeDescriptor; ULONG32
		// SizeOfFunctionEntry; ULONG32 NumberOfDescriptors; ULONG32 SizeOfAlignPad; } MINIDUMP_FUNCTION_TABLE_STREAM, *PMINIDUMP_FUNCTION_TABLE_STREAM;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_FUNCTION_TABLE_STREAM")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_FUNCTION_TABLE_STREAM
		{
			/// <summary>
			/// The size of header information for the stream, in bytes. This value is
			/// <code>sizeof(MINIDUMP_FUNCTION_TABLE_STREAM)</code>
			/// .
			/// </summary>
			public uint SizeOfHeader;

			/// <summary>
			/// The size of a descriptor in the stream, in bytes. This value is
			/// <code>sizeof(MINIDUMP_FUNCTION_TABLE_DESCRIPTOR)</code>
			/// .
			/// </summary>
			public uint SizeOfDescriptor;

			/// <summary>
			/// The size of a raw system descriptor in the stream, in bytes. This value depends on the particular platform and system
			/// version on which the minidump was generated.
			/// </summary>
			public uint SizeOfNativeDescriptor;

			/// <summary>
			/// The size of a raw system function table entry, in bytes. This value depends on the particular platform and system version on
			/// which the minidump was generated.
			/// </summary>
			public uint SizeOfFunctionEntry;

			/// <summary>The number of descriptors in the stream.</summary>
			public uint NumberOfDescriptors;

			/// <summary>The size of alignment padding that follows the header, in bytes.</summary>
			public uint SizeOfAlignPad;
		}

		/// <summary>Represents the header for a handle data stream.</summary>
		/// <remarks>
		/// In this context, a data stream is a set of data in a minidump file. This header structure is followed by
		/// <c>NumberOfDescriptors</c> MINIDUMP_HANDLE_DESCRIPTOR or MINIDUMP_HANDLE_DESCRIPTOR_2 structures.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_handle_data_stream typedef struct
		// _MINIDUMP_HANDLE_DATA_STREAM { ULONG32 SizeOfHeader; ULONG32 SizeOfDescriptor; ULONG32 NumberOfDescriptors; ULONG32 Reserved; }
		// MINIDUMP_HANDLE_DATA_STREAM, *PMINIDUMP_HANDLE_DATA_STREAM;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_HANDLE_DATA_STREAM")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_HANDLE_DATA_STREAM
		{
			/// <summary>
			/// The size of the header information for the stream, in bytes. This value is
			/// <code>sizeof(MINIDUMP_HANDLE_DATA_STREAM)</code>
			/// .
			/// </summary>
			public uint SizeOfHeader;

			/// <summary>
			/// The size of a descriptor in the stream, in bytes. This value is
			/// <code>sizeof(MINIDUMP_HANDLE_DESCRIPTOR)</code>
			/// or
			/// <code>sizeof(MINIDUMP_HANDLE_DESCRIPTOR_2)</code>
			/// .
			/// </summary>
			public uint SizeOfDescriptor;

			/// <summary>The number of descriptors in the stream.</summary>
			public uint NumberOfDescriptors;

			/// <summary>Reserved for future use; must be zero.</summary>
			public uint Reserved;
		}

		/// <summary>Contains the state of an individual system handle at the time the minidump was written.</summary>
		/// <remarks>The first descriptor in the handle data stream follows the header, MINIDUMP_HANDLE_DATA_STREAM.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_handle_descriptor typedef struct
		// _MINIDUMP_HANDLE_DESCRIPTOR { ULONG64 Handle; RVA TypeNameRva; RVA ObjectNameRva; ULONG32 Attributes; ULONG32 GrantedAccess;
		// ULONG32 HandleCount; ULONG32 PointerCount; } MINIDUMP_HANDLE_DESCRIPTOR, *PMINIDUMP_HANDLE_DESCRIPTOR;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_HANDLE_DESCRIPTOR")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_HANDLE_DESCRIPTOR
		{
			/// <summary>The operating system handle value.</summary>
			public ulong Handle;

			/// <summary>An RVA to a MINIDUMP_STRING structure that specifies the object type of the handle. This member can be zero.</summary>
			public uint TypeNameRva;

			/// <summary>An RVA to a MINIDUMP_STRING structure that specifies the object name of the handle. This member can be zero.</summary>
			public uint ObjectNameRva;

			/// <summary>The meaning of this member depends on the handle type and the operating system.</summary>
			public uint Attributes;

			/// <summary>The meaning of this member depends on the handle type and the operating system.</summary>
			public uint GrantedAccess;

			/// <summary>The meaning of this member depends on the handle type and the operating system.</summary>
			public uint HandleCount;

			/// <summary>The meaning of this member depends on the handle type and the operating system.</summary>
			public uint PointerCount;
		}

		/// <summary>Describes the state of an individual system handle at the time the minidump was written.</summary>
		/// <remarks>The first descriptor in the handle data stream follows the header, MINIDUMP_HANDLE_DATA_STREAM.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_handle_descriptor_2 typedef struct
		// _MINIDUMP_HANDLE_DESCRIPTOR_2 { ULONG64 Handle; RVA TypeNameRva; RVA ObjectNameRva; ULONG32 Attributes; ULONG32 GrantedAccess;
		// ULONG32 HandleCount; ULONG32 PointerCount; RVA ObjectInfoRva; ULONG32 Reserved0; } MINIDUMP_HANDLE_DESCRIPTOR_2, *PMINIDUMP_HANDLE_DESCRIPTOR_2;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_HANDLE_DESCRIPTOR_2")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_HANDLE_DESCRIPTOR_2
		{
			/// <summary>The operating system handle value.</summary>
			public ulong Handle;

			/// <summary>An RVA to a MINIDUMP_STRING structure that specifies the object type of the handle. This member can be zero.</summary>
			public uint TypeNameRva;

			/// <summary>An RVA to a MINIDUMP_STRING structure that specifies the object name of the handle. This member can be 0.</summary>
			public uint ObjectNameRva;

			/// <summary>The meaning of this member depends on the handle type and the operating system.</summary>
			public uint Attributes;

			/// <summary>The meaning of this member depends on the handle type and the operating system.</summary>
			public uint GrantedAccess;

			/// <summary>The meaning of this member depends on the handle type and the operating system.</summary>
			public uint HandleCount;

			/// <summary>The meaning of this member depends on the handle type and the operating system.</summary>
			public uint PointerCount;

			/// <summary>
			/// An RVA to a MINIDUMP_HANDLE_OBJECT_INFORMATION structure that specifies object-specific information. This member can be 0 if
			/// there is no extra information.
			/// </summary>
			public uint ObjectInfoRva;

			/// <summary>Reserved for future use; must be zero.</summary>
			public uint Reserved0;
		}

		/// <summary>Contains object-specific information for a handle.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_handle_object_information typedef
		// struct _MINIDUMP_HANDLE_OBJECT_INFORMATION { RVA NextInfoRva; ULONG32 InfoType; ULONG32 SizeOfInfo; } MINIDUMP_HANDLE_OBJECT_INFORMATION;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_HANDLE_OBJECT_INFORMATION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_HANDLE_OBJECT_INFORMATION
		{
			/// <summary>
			/// An RVA to a <c>MINIDUMP_HANDLE_OBJECT_INFORMATION</c> structure that specifies additional object-specific information. This
			/// member is 0 if there are no more elements in the list.
			/// </summary>
			public uint NextInfoRva;

			/// <summary>
			/// The object information type. This member is one of the values from the MINIDUMP_HANDLE_OBJECT_INFORMATION_TYPE enumeration.
			/// </summary>
			public MINIDUMP_HANDLE_OBJECT_INFORMATION_TYPE InfoType;

			/// <summary>The size of the information that follows this member, in bytes.</summary>
			public uint SizeOfInfo;
		}

		/// <summary>Contains a list of handle operations.</summary>
		/// <remarks>For a definition of the <c>AVRF_HANDLE_OPERATION</c> structure, see the Avrfsdk.h header file.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_handle_operation_list typedef struct
		// _MINIDUMP_HANDLE_OPERATION_LIST { ULONG32 SizeOfHeader; ULONG32 SizeOfEntry; ULONG32 NumberOfEntries; ULONG32 Reserved; }
		// MINIDUMP_HANDLE_OPERATION_LIST, *PMINIDUMP_HANDLE_OPERATION_LIST;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_HANDLE_OPERATION_LIST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_HANDLE_OPERATION_LIST
		{
			/// <summary>
			/// The size of the header data for the stream, in bytes. This is generally
			/// <code>sizeof(MINIDUMP_HANDLE_OPERATION_LIST)</code>
			/// .
			/// </summary>
			public uint SizeOfHeader;

			/// <summary>
			/// The size of each entry following the header, in bytes. This is generally
			/// <code>sizeof(AVRF_HANDLE_OPERATION)</code>
			/// .
			/// </summary>
			public uint SizeOfEntry;

			/// <summary>
			/// The number of entries in the stream. These are generally <c>AVRF_HANDLE_OPERATION</c> structures. The entries follow the header.
			/// </summary>
			public uint NumberOfEntries;

			/// <summary>This member is reserved for future use.</summary>
			public uint Reserved;
		}

		/// <summary>Contains header information for the minidump file.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_header typedef struct
		// _MINIDUMP_HEADER { ULONG32 Signature; ULONG32 Version; ULONG32 NumberOfStreams; RVA StreamDirectoryRva; ULONG32 CheckSum; union {
		// ULONG32 Reserved; ULONG32 TimeDateStamp; }; ULONG64 Flags; } MINIDUMP_HEADER, *PMINIDUMP_HEADER;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_HEADER")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_HEADER
		{
			/// <summary>The signature. Set this member to MINIDUMP_SIGNATURE.</summary>
			public uint Signature;

			/// <summary>
			/// The version of the minidump format. The low-order word is MINIDUMP_VERSION. The high-order word is an internal value that is
			/// implementation specific.
			/// </summary>
			public uint Version;

			/// <summary>The number of streams in the minidump directory.</summary>
			public uint NumberOfStreams;

			/// <summary>The base RVA of the minidump directory. The directory is an array of MINIDUMP_DIRECTORY structures.</summary>
			public uint StreamDirectoryRva;

			/// <summary>The checksum for the minidump file. This member can be zero.</summary>
			public uint CheckSum;

			/// <summary>Time and date, in <c>time_t</c> format.</summary>
			public time_t TimeDateStamp;

			/// <summary>One or more values from the MINIDUMP_TYPE enumeration type.</summary>
			public ulong Flags;
		}

		/// <summary>Contains information for the MiniDumpCallback function when the callback type is <c>IncludeModuleCallback</c>.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_include_module_callback typedef
		// struct _MINIDUMP_INCLUDE_MODULE_CALLBACK { ULONG64 BaseOfImage; } MINIDUMP_INCLUDE_MODULE_CALLBACK, *PMINIDUMP_INCLUDE_MODULE_CALLBACK;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_INCLUDE_MODULE_CALLBACK")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_INCLUDE_MODULE_CALLBACK
		{
			/// <summary>The base address of the executable image in memory.</summary>
			public ulong BaseOfImage;
		}

		/// <summary>Contains information for the MiniDumpCallback function when the callback type is <c>IncludeThreadCallback</c>.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_include_thread_callback typedef
		// struct _MINIDUMP_INCLUDE_THREAD_CALLBACK { ULONG ThreadId; } MINIDUMP_INCLUDE_THREAD_CALLBACK, *PMINIDUMP_INCLUDE_THREAD_CALLBACK;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_INCLUDE_THREAD_CALLBACK")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_INCLUDE_THREAD_CALLBACK
		{
			/// <summary>The identifier of the thread.</summary>
			public uint ThreadId;
		}

		/// <summary>
		/// Contains I/O callback information. This structure is used by the MiniDumpCallbackfunction when the callback type is
		/// <c>IoStartCallback</c>, <c>IoWriteAllCallback</c>, or <c>IoFinishCallback</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_io_callback typedef struct
		// _MINIDUMP_IO_CALLBACK { HANDLE Handle; ULONG64 Offset; PVOID Buffer; ULONG BufferBytes; } MINIDUMP_IO_CALLBACK, *PMINIDUMP_IO_CALLBACK;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_IO_CALLBACK")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_IO_CALLBACK
		{
			/// <summary>The file handle passed to the MiniDumpWriteDump function.</summary>
			public HFILE Handle;

			/// <summary>The offset for the write operation from the start of the minidump data. This member is used only with <c>IoWriteAllCallback</c>.</summary>
			public ulong Offset;

			/// <summary>A pointer to a buffer that contains the data to be written. This member is used only with <c>IoWriteAllCallback</c>.</summary>
			public IntPtr Buffer;

			/// <summary>The size of the data buffer, in bytes. This member is used only with <c>IoWriteAllCallback</c>.</summary>
			public uint BufferBytes;
		}

		/// <summary>Contains information describing the location of a data stream within a minidump file.</summary>
		/// <remarks>
		/// <para>In this context, a data stream refers to a block of data within a minidump file.</para>
		/// <para>
		/// This structure uses 32-bit locations for RVAs in the first 4GB and 64-bit locations are used for larger RVAs. The
		/// <c>MINIDUMP_LOCATION_DESCRIPTOR64</c> structure is defined as follows.
		/// </para>
		/// <para>
		/// <code> typedef struct _MINIDUMP_LOCATION_DESCRIPTOR64 { ULONG64 DataSize; RVA64 Rva; } MINIDUMP_LOCATION_DESCRIPTOR64;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_location_descriptor typedef struct
		// _MINIDUMP_LOCATION_DESCRIPTOR { ULONG32 DataSize; RVA Rva; } MINIDUMP_LOCATION_DESCRIPTOR;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_LOCATION_DESCRIPTOR")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_LOCATION_DESCRIPTOR
		{
			/// <summary>The size of the data stream, in bytes.</summary>
			public uint DataSize;

			/// <summary>
			/// The relative virtual address (RVA) of the data. This is the byte offset of the data stream from the beginning of the
			/// minidump file.
			/// </summary>
			public uint Rva;
		}

		/// <summary>Describes a range of memory.</summary>
		/// <remarks>
		/// <para>
		/// <c>MINIDUMP_MEMORY_DESCRIPTOR64</c> is used for full-memory minidumps where all of the raw memory is sequential at the end of
		/// the minidump. There is no need for individual relative virtual addresses (RVAs), because the RVA is the base RVA plus the sum of
		/// the preceding data blocks. The <c>MINIDUMP_MEMORY_DESCRIPTOR64</c> structure is defined as follows.
		/// </para>
		/// <para>
		/// <code> typedef struct _MINIDUMP_MEMORY_DESCRIPTOR64 { ULONG64 StartOfMemoryRange; ULONG64 DataSize; } MINIDUMP_MEMORY_DESCRIPTOR64, *PMINIDUMP_MEMORY_DESCRIPTOR64;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_memory_descriptor typedef struct
		// _MINIDUMP_MEMORY_DESCRIPTOR { ULONG64 StartOfMemoryRange; MINIDUMP_LOCATION_DESCRIPTOR Memory; } MINIDUMP_MEMORY_DESCRIPTOR, *PMINIDUMP_MEMORY_DESCRIPTOR;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_MEMORY_DESCRIPTOR")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_MEMORY_DESCRIPTOR
		{
			/// <summary>The starting address of the memory range.</summary>
			public ulong StartOfMemoryRange;

			/// <summary>A MINIDUMP_LOCATION_DESCRIPTOR structure.</summary>
			public MINIDUMP_LOCATION_DESCRIPTOR Memory;
		}

		/// <summary>Describes a region of memory.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_memory_info typedef struct
		// _MINIDUMP_MEMORY_INFO { ULONG64 BaseAddress; ULONG64 AllocationBase; ULONG32 AllocationProtect; ULONG32 __alignment1; ULONG64
		// RegionSize; ULONG32 State; ULONG32 Protect; ULONG32 Type; ULONG32 __alignment2; } MINIDUMP_MEMORY_INFO, *PMINIDUMP_MEMORY_INFO;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_MEMORY_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_MEMORY_INFO
		{
			/// <summary>The base address of the region of pages.</summary>
			public ulong BaseAddress;

			/// <summary>The base address of a range of pages in this region. The page is contained within this memory region.</summary>
			public ulong AllocationBase;

			/// <summary>
			/// The memory protection when the region was initially allocated. This member can be one of the memory protection options,
			/// along with PAGE_GUARD or PAGE_NOCACHE, as needed.
			/// </summary>
			public uint AllocationProtect;

			/// <summary>A variable for alignment.</summary>
			private uint __alignment1;

			/// <summary>The size of the region beginning at the base address in which all pages have identical attributes, in bytes.</summary>
			public ulong RegionSize;

			/// <summary>
			/// <para>The state of the pages in the region. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>State</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MEM_COMMIT 0x1000</term>
			/// <term>
			/// Indicates committed pages for which physical storage has been allocated, either in memory or in the paging file on disk.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MEM_FREE 0x10000</term>
			/// <term>
			/// Indicates free pages not accessible to the calling process and available to be allocated. For free pages, the information in
			/// the AllocationBase, AllocationProtect, Protect, and Type members is undefined.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MEM_RESERVE 0x2000</term>
			/// <term>
			/// Indicates reserved pages where a range of the process's virtual address space is reserved without any physical storage being
			/// allocated. For reserved pages, the information in the Protect member is undefined.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint State;

			/// <summary>
			/// The access protection of the pages in the region. This member is one of the values listed for the <c>AllocationProtect</c> member.
			/// </summary>
			public uint Protect;

			/// <summary>
			/// <para>The type of pages in the region. The following types are defined.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Type</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MEM_IMAGE 0x1000000</term>
			/// <term>Indicates that the memory pages within the region are mapped into the view of an image section.</term>
			/// </item>
			/// <item>
			/// <term>MEM_MAPPED 0x40000</term>
			/// <term>Indicates that the memory pages within the region are mapped into the view of a section.</term>
			/// </item>
			/// <item>
			/// <term>MEM_PRIVATE 0x20000</term>
			/// <term>Indicates that the memory pages within the region are private (that is, not shared by other processes).</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Type;

			/// <summary>A variable for alignment.</summary>
			private uint __alignment2;
		}

		/// <summary>Contains a list of memory regions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_memory_info_list typedef struct
		// _MINIDUMP_MEMORY_INFO_LIST { ULONG SizeOfHeader; ULONG SizeOfEntry; ULONG64 NumberOfEntries; } MINIDUMP_MEMORY_INFO_LIST, *PMINIDUMP_MEMORY_INFO_LIST;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_MEMORY_INFO_LIST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_MEMORY_INFO_LIST
		{
			/// <summary>
			/// The size of the header data for the stream, in bytes. This is generally
			/// <code>sizeof(MINIDUMP_MEMORY_INFO_LIST)</code>
			/// .
			/// </summary>
			public uint SizeOfHeader;

			/// <summary>
			/// The size of each entry following the header, in bytes. This is generally
			/// <code>sizeof(MINIDUMP_MEMORY_INFO)</code>
			/// .
			/// </summary>
			public uint SizeOfEntry;

			/// <summary>
			/// The number of entries in the stream. These are generally MINIDUMP_MEMORY_INFO structures. The entries follow the header.
			/// </summary>
			public ulong NumberOfEntries;
		}

		/// <summary>Contains a list of memory ranges.</summary>
		/// <remarks>
		/// <para>The <c>MINIDUMP_MEMORY64_LIST</c> structure is defined as follows. It is used for full-memory minidumps.</para>
		/// <para>
		/// <code> typedef struct _MINIDUMP_MEMORY64_LIST { ULONG64 NumberOfMemoryRanges; RVA64 BaseRva; MINIDUMP_MEMORY_DESCRIPTOR64 MemoryRanges [0]; } MINIDUMP_MEMORY64_LIST, *PMINIDUMP_MEMORY64_LIST;</code>
		/// </para>
		/// <para>
		/// Note that <c>BaseRva</c> is the overall base RVA for the memory list. To locate the data for a particular descriptor, start at
		/// <c>BaseRva</c> and increment by the size of a descriptor until you reach the descriptor.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_memory_list typedef struct
		// _MINIDUMP_MEMORY_LIST { ULONG32 NumberOfMemoryRanges; MINIDUMP_MEMORY_DESCRIPTOR MemoryRanges[0]; } MINIDUMP_MEMORY_LIST, *PMINIDUMP_MEMORY_LIST;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_MEMORY_LIST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_MEMORY_LIST
		{
			/// <summary>The number of structures in the <c>MemoryRanges</c> array.</summary>
			public uint NumberOfMemoryRanges;

			/// <summary>An array of MINIDUMP_MEMORY_DESCRIPTOR structures.</summary>
			public MINIDUMP_MEMORY_DESCRIPTOR[] MemoryRanges;
		}

		/// <summary>Contains a variety of information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_misc_info typedef struct
		// _MINIDUMP_MISC_INFO { ULONG32 SizeOfInfo; ULONG32 Flags1; ULONG32 ProcessId; ULONG32 ProcessCreateTime; ULONG32 ProcessUserTime;
		// ULONG32 ProcessKernelTime; } MINIDUMP_MISC_INFO, *PMINIDUMP_MISC_INFO;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_MISC_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_MISC_INFO
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint SizeOfInfo;

			/// <summary>
			/// <para>The flags that indicate the valid members of this structure. This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MINIDUMP_MISC1_PROCESS_ID 0x00000001</term>
			/// <term>ProcessId is used.</term>
			/// </item>
			/// <item>
			/// <term>MINIDUMP_MISC1_PROCESS_TIMES 0x00000002</term>
			/// <term>ProcessCreateTime, ProcessKernelTime, and ProcessUserTime are used.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Flags1;

			/// <summary>The identifier of the process. If <c>Flags1</c> does not specify MINIDUMP_MISC1_PROCESS_ID, this member is unused.</summary>
			public uint ProcessId;

			/// <summary>
			/// The creation time of the process, in <c>time_t</c> format. If <c>Flags1</c> does not specify MINIDUMP_MISC1_PROCESS_TIMES,
			/// this member is unused.
			/// </summary>
			public uint ProcessCreateTime;

			/// <summary>
			/// The time the process has executed in user mode, in seconds. The time that each of the threads of the process has executed in
			/// user mode is determined, then all these times are summed to obtain this value. If <c>Flags1</c> does not specify
			/// MINIDUMP_MISC1_PROCESS_TIMES, this member is unused.
			/// </summary>
			public uint ProcessUserTime;

			/// <summary>
			/// The time the process has executed in kernel mode, in seconds. The time that each of the threads of the process has executed
			/// in kernel mode is determined, then all these times are summed to obtain this value. If <c>Flags1</c> does not specify
			/// MINIDUMP_MISC1_PROCESS_TIMES, this member is unused.
			/// </summary>
			public uint ProcessKernelTime;
		}

		/// <summary>Represents information in the miscellaneous information stream.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_misc_info_2 typedef struct
		// _MINIDUMP_MISC_INFO_2 { ULONG32 SizeOfInfo; ULONG32 Flags1; ULONG32 ProcessId; ULONG32 ProcessCreateTime; ULONG32
		// ProcessUserTime; ULONG32 ProcessKernelTime; ULONG32 ProcessorMaxMhz; ULONG32 ProcessorCurrentMhz; ULONG32 ProcessorMhzLimit;
		// ULONG32 ProcessorMaxIdleState; ULONG32 ProcessorCurrentIdleState; } MINIDUMP_MISC_INFO_2, *PMINIDUMP_MISC_INFO_2;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_MISC_INFO_2")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_MISC_INFO_2
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint SizeOfInfo;

			/// <summary>
			/// <para>The flags that indicate the valid members of this structure. This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MINIDUMP_MISC1_PROCESS_ID 0x00000001</term>
			/// <term>ProcessId is used.</term>
			/// </item>
			/// <item>
			/// <term>MINIDUMP_MISC1_PROCESS_TIMES 0x00000002</term>
			/// <term>ProcessCreateTime, ProcessKernelTime, and ProcessUserTime are used.</term>
			/// </item>
			/// <item>
			/// <term>MINIDUMP_MISC1_PROCESSOR_POWER_INFO 0x00000004</term>
			/// <term>
			/// ProcessorMaxMhz, ProcessorCurrentMhz, ProcessorMhzLimit, ProcessorMaxIdleState, and ProcessorCurrentIdleState are used.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Flags1;

			/// <summary>
			/// The identifier of the process. If <c>Flags1</c> does not specify <c>MINIDUMP_MISC1_PROCESS_ID</c>, this member is unused.
			/// </summary>
			public uint ProcessId;

			/// <summary>
			/// The creation time of the process, in <c>time_t</c> format. If <c>Flags1</c> does not specify
			/// <c>MINIDUMP_MISC1_PROCESS_TIMES</c>, this member is unused.
			/// </summary>
			public uint ProcessCreateTime;

			/// <summary>
			/// The time the process has executed in user mode, in seconds. The time that each of the threads of the process has executed in
			/// user mode is determined, then all these times are summed to obtain this value. If <c>Flags1</c> does not specify
			/// <c>MINIDUMP_MISC1_PROCESS_TIMES</c>, this member is unused.
			/// </summary>
			public uint ProcessUserTime;

			/// <summary>
			/// The time the process has executed in kernel mode, in seconds. The time that each of the threads of the process has executed
			/// in kernel mode is determined, then all these times are summed to obtain this value. If <c>Flags1</c> does not specify
			/// <c>MINIDUMP_MISC1_PROCESS_TIMES</c>, this member is unused.
			/// </summary>
			public uint ProcessKernelTime;

			/// <summary>
			/// The maximum specified clock frequency of the system processor, in MHz. If <c>Flags1</c> does not specify
			/// <c>MINIDUMP_MISC1_PROCESSOR_POWER_INFO</c>, this member is unused.
			/// </summary>
			public uint ProcessorMaxMhz;

			/// <summary>
			/// The processor clock frequency, in MHz. This number is the maximum specified processor clock frequency multiplied by the
			/// current processor throttle. If <c>Flags1</c> does not specify <c>MINIDUMP_MISC1_PROCESSOR_POWER_INFO</c>, this member is unused.
			/// </summary>
			public uint ProcessorCurrentMhz;

			/// <summary>
			/// The limit on the processor clock frequency, in MHz. This number is the maximum specified processor clock frequency
			/// multiplied by the current processor thermal throttle limit. If <c>Flags1</c> does not specify
			/// <c>MINIDUMP_MISC1_PROCESSOR_POWER_INFO</c>, this member is unused.
			/// </summary>
			public uint ProcessorMhzLimit;

			/// <summary>
			/// The maximum idle state of the processor. If <c>Flags1</c> does not specify <c>MINIDUMP_MISC1_PROCESSOR_POWER_INFO</c>, this
			/// member is unused.
			/// </summary>
			public uint ProcessorMaxIdleState;

			/// <summary>
			/// The current idle state of the processor. If <c>Flags1</c> does not specify <c>MINIDUMP_MISC1_PROCESSOR_POWER_INFO</c>, this
			/// member is unused.
			/// </summary>
			public uint ProcessorCurrentIdleState;
		}

		/// <summary>Contains information for a specific module.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_module typedef struct
		// _MINIDUMP_MODULE { ULONG64 BaseOfImage; ULONG32 SizeOfImage; ULONG32 CheckSum; ULONG32 TimeDateStamp; RVA ModuleNameRva;
		// VS_FIXEDFILEINFO VersionInfo; MINIDUMP_LOCATION_DESCRIPTOR CvRecord; MINIDUMP_LOCATION_DESCRIPTOR MiscRecord; ULONG64 Reserved0;
		// ULONG64 Reserved1; } MINIDUMP_MODULE, *PMINIDUMP_MODULE;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_MODULE")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_MODULE
		{
			/// <summary>The base address of the module executable image in memory.</summary>
			public ulong BaseOfImage;

			/// <summary>The size of the module executable image in memory, in bytes.</summary>
			public uint SizeOfImage;

			/// <summary>The checksum value of the module executable image.</summary>
			public uint CheckSum;

			/// <summary>The timestamp value of the module executable image, in <c>time_t</c> format.</summary>
			public uint TimeDateStamp;

			/// <summary>An RVA to a MINIDUMP_STRING structure that specifies the name of the module.</summary>
			public uint ModuleNameRva;

			/// <summary>A VS_FIXEDFILEINFO structure that specifies the version of the module.</summary>
			public WinVer.VS_FIXEDFILEINFO VersionInfo;

			/// <summary>A MINIDUMP_LOCATION_DESCRIPTOR structure that specifies the CodeView record of the module.</summary>
			public MINIDUMP_LOCATION_DESCRIPTOR CvRecord;

			/// <summary>A MINIDUMP_LOCATION_DESCRIPTOR structure that specifies the miscellaneous record of the module.</summary>
			public MINIDUMP_LOCATION_DESCRIPTOR MiscRecord;

			/// <summary>Reserved for future use.</summary>
			public ulong Reserved0;

			/// <summary>Reserved for future use.</summary>
			public ulong Reserved1;
		}

		/// <summary>Contains module information for the MiniDumpCallback function when the callback type is ModuleCallback.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_module_callback typedef struct
		// _MINIDUMP_MODULE_CALLBACK { PWCHAR FullPath; ULONG64 BaseOfImage; ULONG SizeOfImage; ULONG CheckSum; ULONG TimeDateStamp;
		// VS_FIXEDFILEINFO VersionInfo; PVOID CvRecord; ULONG SizeOfCvRecord; PVOID MiscRecord; ULONG SizeOfMiscRecord; }
		// MINIDUMP_MODULE_CALLBACK, *PMINIDUMP_MODULE_CALLBACK;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_MODULE_CALLBACK")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_MODULE_CALLBACK
		{
			/// <summary>The fully qualified path of the module executable.</summary>
			public StrPtrUni FullPath;

			/// <summary>The base address of the module executable image in memory.</summary>
			public ulong BaseOfImage;

			/// <summary>The size of the module executable image in memory, in bytes.</summary>
			public uint SizeOfImage;

			/// <summary>The checksum value of the module executable image.</summary>
			public uint CheckSum;

			/// <summary>The timestamp value of the module executable image, in <c>time_t</c> format.</summary>
			public time_t TimeDateStamp;

			/// <summary>A VS_FIXEDFILEINFO structure that specifies the version of the module.</summary>
			public WinVer.VS_FIXEDFILEINFO VersionInfo;

			/// <summary>A pointer to a string containing the CodeView record of the module.</summary>
			public IntPtr CvRecord;

			/// <summary>The size of the Codeview record of the module in the <c>CvRecord</c> member, in bytes.</summary>
			public uint SizeOfCvRecord;

			/// <summary>A pointer to a string that specifies the miscellaneous record of the module.</summary>
			public IntPtr MiscRecord;

			/// <summary>The size of the miscellaneous record of the module in the <c>MiscRecord</c> member, in bytes.</summary>
			public uint SizeOfMiscRecord;
		}

		/// <summary>Contains a list of modules.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_module_list typedef struct
		// _MINIDUMP_MODULE_LIST { ULONG32 NumberOfModules; MINIDUMP_MODULE Modules[0]; } MINIDUMP_MODULE_LIST, *PMINIDUMP_MODULE_LIST;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_MODULE_LIST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_MODULE_LIST
		{
			/// <summary>The number of structures in the <c>Modules</c> array.</summary>
			public uint NumberOfModules;

			/// <summary>An array of MINIDUMP_MODULE structures.</summary>
			public MINIDUMP_MODULE[] Modules;
		}

		/// <summary>
		/// Contains information about a failed memory read operation. This structure is used by the MiniDumpCallbackfunction when the
		/// callback type is ReadMemoryFailureCallback.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_read_memory_failure_callback typedef
		// struct _MINIDUMP_READ_MEMORY_FAILURE_CALLBACK { ULONG64 Offset; ULONG Bytes; HRESULT FailureStatus; }
		// MINIDUMP_READ_MEMORY_FAILURE_CALLBACK, *PMINIDUMP_READ_MEMORY_FAILURE_CALLBACK;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_READ_MEMORY_FAILURE_CALLBACK")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_READ_MEMORY_FAILURE_CALLBACK
		{
			/// <summary>The offset of the address for the failed memory read operation.</summary>
			public ulong Offset;

			/// <summary>The size of the failed memory read operation, in bytes.</summary>
			public uint Bytes;

			/// <summary>The resulting error code from the failed memory read operation.</summary>
			public HRESULT FailureStatus;
		}

		/// <summary>Describes a string.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_string typedef struct
		// _MINIDUMP_STRING { ULONG32 Length; WCHAR Buffer[0]; } MINIDUMP_STRING, *PMINIDUMP_STRING;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_STRING")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct MINIDUMP_STRING
		{
			/// <summary>
			/// The size of the string in the <c>Buffer</c> member, in bytes. This size does not include the null-terminating character.
			/// </summary>
			public uint Length;

			/// <summary>The null-terminated string.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0)]
			public string Buffer;
		}

		/// <summary>Contains processor and operating system information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_system_info typedef struct
		// _MINIDUMP_SYSTEM_INFO { USHORT ProcessorArchitecture; USHORT ProcessorLevel; USHORT ProcessorRevision; union { USHORT Reserved0;
		// struct { UCHAR NumberOfProcessors; UCHAR ProductType; }; }; ULONG32 MajorVersion; ULONG32 MinorVersion; ULONG32 BuildNumber;
		// ULONG32 PlatformId; RVA CSDVersionRva; union { ULONG32 Reserved1; struct { USHORT SuiteMask; USHORT Reserved2; }; };
		// CPU_INFORMATION Cpu; } MINIDUMP_SYSTEM_INFO, *PMINIDUMP_SYSTEM_INFO;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_SYSTEM_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_SYSTEM_INFO
		{
			/// <summary>
			/// <para>The system's processor architecture. <see cref="Kernel32.SYSTEM_INFO"/> This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PROCESSOR_ARCHITECTURE_AMD64 9</term>
			/// <term>x64 (AMD or Intel)</term>
			/// </item>
			/// <item>
			/// <term>PROCESSOR_ARCHITECTURE_ARM 5</term>
			/// <term>ARM</term>
			/// </item>
			/// <item>
			/// <term>PROCESSOR_ARCHITECTURE_IA64 6</term>
			/// <term>Intel Itanium</term>
			/// </item>
			/// <item>
			/// <term>PROCESSOR_ARCHITECTURE_INTEL 0</term>
			/// <term>x86</term>
			/// </item>
			/// <item>
			/// <term>PROCESSOR_ARCHITECTURE_UNKNOWN 0xffff</term>
			/// <term>Unknown processor.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ProcessorArchitecture ProcessorArchitecture;

			/// <summary>
			/// <para>The system's architecture-dependent processor level.</para>
			/// <para>
			/// If <c>ProcessorArchitecture</c> is <c>PROCESSOR_ARCHITECTURE_INTEL</c>, <c>ProcessorLevel</c> can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>3</term>
			/// <term>Intel 80386</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>Intel 80486</term>
			/// </item>
			/// <item>
			/// <term>5</term>
			/// <term>Intel Pentium</term>
			/// </item>
			/// <item>
			/// <term>6</term>
			/// <term>Intel Pentium Pro or Pentium II</term>
			/// </item>
			/// </list>
			/// <para>If <c>ProcessorArchitecture</c> is <c>PROCESSOR_ARCHITECTURE_IA64</c>, <c>ProcessorLevel</c> is set to 1.</para>
			/// </summary>
			public ushort ProcessorLevel;

			/// <summary>
			/// <para>The architecture-dependent processor revision.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Processor</term>
			/// <term>Value</term>
			/// </listheader>
			/// <item>
			/// <term>Intel 80386 or 80486</term>
			/// <term>
			/// A value of the form xxyz. If xx is equal to 0xFF, y - 0xA is the model number, and z is the stepping identifier. For
			/// example, an Intel 80486-D0 system returns 0xFFD0. If xx is not equal to 0xFF, xx + 'A' is the stepping letter and yz is the
			/// minor stepping.
			/// </term>
			/// </item>
			/// <item>
			/// <term>Intel Pentium, Cyrix, or NextGen 586</term>
			/// <term>
			/// A value of the form xxyy, where xx is the model number and yy is the stepping. Display this value of 0x0201 as follows:
			/// Model xx, Stepping yy
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort ProcessorRevision;

			/// <summary>The number of processors in the system.</summary>
			public byte NumberOfProcessors;

			/// <summary>
			/// <para>Any additional information about the system. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VER_NT_DOMAIN_CONTROLLER 0x0000002</term>
			/// <term>The system is a domain controller.</term>
			/// </item>
			/// <item>
			/// <term>VER_NT_SERVER 0x0000003</term>
			/// <term>The system is a server.</term>
			/// </item>
			/// <item>
			/// <term>VER_NT_WORKSTATION 0x0000001</term>
			/// <term>The system is running Windows XP, Windows Vista, Windows 7, or Windows 8.</term>
			/// </item>
			/// </list>
			/// </summary>
			public Kernel32.ProductType ProductType;

			/// <summary>The major version number of the operating system. This member can be 4, 5, or 6.</summary>
			public uint MajorVersion;

			/// <summary>The minor version number of the operating system.</summary>
			public uint MinorVersion;

			/// <summary>The build number of the operating system.</summary>
			public uint BuildNumber;

			/// <summary>
			/// <para>The operating system platform. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VER_PLATFORM_WIN32s 0</term>
			/// <term>Not supported</term>
			/// </item>
			/// <item>
			/// <term>VER_PLATFORM_WIN32_WINDOWS 1</term>
			/// <term>Not supported.</term>
			/// </item>
			/// <item>
			/// <term>VER_PLATFORM_WIN32_NT 2</term>
			/// <term>The operating system platform is Windows.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PlatformID PlatformId;

			/// <summary>
			/// An RVA (from the beginning of the dump) to a MINIDUMP_STRING that describes the latest Service Pack installed on the system.
			/// If no Service Pack has been installed, the string is empty.
			/// </summary>
			public uint CSDVersionRva;

			/// <summary>
			/// <para>
			/// The bit flags that identify the product suites available on the system. This member can be a combination of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VER_SUITE_BACKOFFICE 0x00000004</term>
			/// <term>Microsoft BackOffice components are installed.</term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_BLADE 0x00000400</term>
			/// <term>Windows Server 2003, Web Edition is installed.</term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_COMPUTE_SERVER 0x00004000</term>
			/// <term>Windows Server 2003, Compute Cluster Edition is installed.</term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_DATACENTER 0x00000080</term>
			/// <term>Windows Server 2008 R2 Datacenter, Windows Server 2008 Datacenter, or Windows Server 2003, Datacenter Edition is installed.</term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_ENTERPRISE 0x00000002</term>
			/// <term>Windows Server 2008 R2 Enterprise, Windows Server 2008 Enterprise, or Windows Server 2003, Enterprise Edition is installed.</term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_EMBEDDEDNT 0x00000040</term>
			/// <term>Windows Embedded is installed.</term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_PERSONAL 0x00000200</term>
			/// <term>Windows XP Home Edition is installed.</term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_SINGLEUSERTS 0x00000100</term>
			/// <term>
			/// Remote Desktop is supported, but only one interactive session is supported. This value is set unless the system is running
			/// in application server mode.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_SMALLBUSINESS 0x00000001</term>
			/// <term>
			/// Microsoft Small Business Server was once installed on the system, but may have been upgraded to another version of Windows.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_SMALLBUSINESS_RESTRICTED 0x00000020</term>
			/// <term>Microsoft Small Business Server is installed with the restrictive client license in force.</term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_STORAGE_SERVER 0x00002000</term>
			/// <term>Windows Storage Server is installed.</term>
			/// </item>
			/// <item>
			/// <term>VER_SUITE_TERMINAL 0x00000010</term>
			/// <term>
			/// Terminal Services is installed. This value is always set. If VER_SUITE_TERMINAL is set but VER_SUITE_SINGLEUSERTS is not
			/// set, the system is running in application server mode.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public Kernel32.SuiteMask SuiteMask;

			/// <summary>This member is reserved for future use.</summary>
			public ushort Reserved2;

			/// <summary>
			/// <para>X86CpuInfo</para>
			/// <para>The CPU information obtained from the CPUID instruction. This structure is supported only for x86 computers.</para>
			/// <para>VendorId</para>
			/// <para>CPUID subfunction 0. The array elements are as follows:</para>
			/// <para>VersionInformation</para>
			/// <para>CPUID subfunction 1. Value of EAX.</para>
			/// <para>FeatureInformation</para>
			/// <para>CPUID subfunction 1. Value of EDX.</para>
			/// <para>AMDExtendedCpuFeatures</para>
			/// <para>CPUID subfunction 80000001. Value of EBX. This member is supported only if the vendor is "AuthenticAMD".</para>
			/// <para>OtherCpuInfo</para>
			/// <para>Other CPU information. This structure is supported only for non-x86 computers.</para>
			/// <para>ProcessorFeatures</para>
			/// <para>For a list of possible values, see the IsProcessorFeaturePresent function.</para>
			/// </summary>
			public CPU_INFORMATION Cpu;
		}

		/// <summary>Contains information for a specific thread.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_thread typedef struct
		// _MINIDUMP_THREAD { ULONG32 ThreadId; ULONG32 SuspendCount; ULONG32 PriorityClass; ULONG32 Priority; ULONG64 Teb;
		// MINIDUMP_MEMORY_DESCRIPTOR Stack; MINIDUMP_LOCATION_DESCRIPTOR ThreadContext; } MINIDUMP_THREAD, *PMINIDUMP_THREAD;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_THREAD")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_THREAD
		{
			/// <summary>The identifier of the thread.</summary>
			public uint ThreadId;

			/// <summary>
			/// The suspend count for the thread. If the suspend count is greater than zero, the thread is suspended; otherwise, the thread
			/// is not suspended. The maximum value is MAXIMUM_SUSPEND_COUNT.
			/// </summary>
			public uint SuspendCount;

			/// <summary>The priority class of the thread. See Scheduling Priorities.</summary>
			public uint PriorityClass;

			/// <summary>The priority level of the thread.</summary>
			public uint Priority;

			/// <summary>The thread environment block.</summary>
			public ulong Teb;

			/// <summary>A MINIDUMP_MEMORY_DESCRIPTOR structure.</summary>
			public MINIDUMP_MEMORY_DESCRIPTOR Stack;

			/// <summary>A MINIDUMP_LOCATION_DESCRIPTOR structure.</summary>
			public MINIDUMP_LOCATION_DESCRIPTOR ThreadContext;
		}

		/// <summary>Contains thread information for the MiniDumpCallback function when the callback type is ThreadCallback.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_thread_callback typedef struct
		// _MINIDUMP_THREAD_CALLBACK { ULONG ThreadId; HANDLE ThreadHandle; ULONG Pad; CONTEXT Context; ULONG SizeOfContext; ULONG64
		// StackBase; ULONG64 StackEnd; } MINIDUMP_THREAD_CALLBACK, *PMINIDUMP_THREAD_CALLBACK;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_THREAD_CALLBACK")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_THREAD_CALLBACK
		{
			/// <summary>The identifier of the thread.</summary>
			public uint ThreadId;

			/// <summary>A handle to the thread</summary>
			public HTHREAD ThreadHandle;

			/// <summary/>
			public uint Pad;

			/// <summary>A CONTEXT structure that contains the processor-specific data.</summary>
			public CONTEXT Context;

			/// <summary>The size of the returned processor-specific data in the <c>Context</c> member, in bytes.</summary>
			public uint SizeOfContext;

			/// <summary>The base address of the thread stack.</summary>
			public ulong StackBase;

			/// <summary>The ending address of the thread stack.</summary>
			public ulong StackEnd;
		}

		/// <summary>Contains extended information for a specific thread.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_thread_ex typedef struct
		// _MINIDUMP_THREAD_EX { ULONG32 ThreadId; ULONG32 SuspendCount; ULONG32 PriorityClass; ULONG32 Priority; ULONG64 Teb;
		// MINIDUMP_MEMORY_DESCRIPTOR Stack; MINIDUMP_LOCATION_DESCRIPTOR ThreadContext; MINIDUMP_MEMORY_DESCRIPTOR BackingStore; }
		// MINIDUMP_THREAD_EX, *PMINIDUMP_THREAD_EX;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_THREAD_EX")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_THREAD_EX
		{
			/// <summary>The identifier of the thread.</summary>
			public uint ThreadId;

			/// <summary>
			/// The suspend count for the thread. If the suspend count is greater than zero, the thread is suspended; otherwise, the thread
			/// is not suspended. The maximum value is MAXIMUM_SUSPEND_COUNT.
			/// </summary>
			public uint SuspendCount;

			/// <summary>The priority class of the thread. See Scheduling Priorities.</summary>
			public uint PriorityClass;

			/// <summary>The priority level of the thread.</summary>
			public uint Priority;

			/// <summary>The thread environment block.</summary>
			public ulong Teb;

			/// <summary>A MINIDUMP_MEMORY_DESCRIPTOR structure.</summary>
			public MINIDUMP_MEMORY_DESCRIPTOR Stack;

			/// <summary>A MINIDUMP_LOCATION_DESCRIPTOR structure.</summary>
			public MINIDUMP_LOCATION_DESCRIPTOR ThreadContext;

			/// <summary><c>Intel Itanium:</c> The backing store for the thread.</summary>
			public MINIDUMP_MEMORY_DESCRIPTOR BackingStore;
		}

		/// <summary>Contains extended thread information for the MiniDumpCallback function when the callback type is ThreadExCallback.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_thread_ex_callback typedef struct
		// _MINIDUMP_THREAD_EX_CALLBACK { ULONG ThreadId; HANDLE ThreadHandle; ULONG Pad; CONTEXT Context; ULONG SizeOfContext; ULONG64
		// StackBase; ULONG64 StackEnd; ULONG64 BackingStoreBase; ULONG64 BackingStoreEnd; } MINIDUMP_THREAD_EX_CALLBACK, *PMINIDUMP_THREAD_EX_CALLBACK;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_THREAD_EX_CALLBACK")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_THREAD_EX_CALLBACK
		{
			/// <summary>The identifier of the thread.</summary>
			public uint ThreadId;

			/// <summary>A handle to the thread</summary>
			public HTHREAD ThreadHandle;

			/// <summary/>
			public uint Pad;

			/// <summary>A CONTEXT structure that contains the processor-specific data.</summary>
			public CONTEXT Context;

			/// <summary>The size of the returned processor-specific data in the <c>Context</c> member, in bytes.</summary>
			public uint SizeOfContext;

			/// <summary>The base address of the thread stack.</summary>
			public ulong StackBase;

			/// <summary>The ending address of the thread stack.</summary>
			public ulong StackEnd;

			/// <summary><c>Intel Itanium:</c> The base address of the thread backing store.</summary>
			public ulong BackingStoreBase;

			/// <summary><c>Intel Itanium:</c> The ending address of the thread backing store.</summary>
			public ulong BackingStoreEnd;
		}

		/// <summary>Contains a list of threads.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_thread_ex_list typedef struct
		// _MINIDUMP_THREAD_EX_LIST { ULONG32 NumberOfThreads; MINIDUMP_THREAD_EX Threads[0]; } MINIDUMP_THREAD_EX_LIST, *PMINIDUMP_THREAD_EX_LIST;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_THREAD_EX_LIST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_THREAD_EX_LIST
		{
			/// <summary>The number of structures in the <c>Threads</c> array.</summary>
			public uint NumberOfThreads;

			/// <summary>An array of MINIDUMP_THREAD_EX structures.</summary>
			public MINIDUMP_THREAD_EX[] Threads;
		}

		/// <summary>Contains thread state information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_thread_info typedef struct
		// _MINIDUMP_THREAD_INFO { ULONG32 ThreadId; ULONG32 DumpFlags; ULONG32 DumpError; ULONG32 ExitStatus; ULONG64 CreateTime; ULONG64
		// ExitTime; ULONG64 KernelTime; ULONG64 UserTime; ULONG64 StartAddress; ULONG64 Affinity; } MINIDUMP_THREAD_INFO, *PMINIDUMP_THREAD_INFO;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_THREAD_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_THREAD_INFO
		{
			/// <summary>The identifier of the thread.</summary>
			public uint ThreadId;

			/// <summary>
			/// <para>The flags that indicate the thread state. This member can be 0 or one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MINIDUMP_THREAD_INFO_ERROR_THREAD 0x00000001</term>
			/// <term>A placeholder thread due to an error accessing the thread. No thread information exists beyond the thread identifier.</term>
			/// </item>
			/// <item>
			/// <term>MINIDUMP_THREAD_INFO_EXITED_THREAD 0x00000004</term>
			/// <term>The thread has exited (not running any code) at the time of the dump.</term>
			/// </item>
			/// <item>
			/// <term>MINIDUMP_THREAD_INFO_INVALID_CONTEXT 0x00000010</term>
			/// <term>Thread context could not be retrieved.</term>
			/// </item>
			/// <item>
			/// <term>MINIDUMP_THREAD_INFO_INVALID_INFO 0x00000008</term>
			/// <term>Thread information could not be retrieved.</term>
			/// </item>
			/// <item>
			/// <term>MINIDUMP_THREAD_INFO_INVALID_TEB 0x00000020</term>
			/// <term>TEB information could not be retrieved.</term>
			/// </item>
			/// <item>
			/// <term>MINIDUMP_THREAD_INFO_WRITING_THREAD 0x00000002</term>
			/// <term>This is the thread that called MiniDumpWriteDump.</term>
			/// </item>
			/// </list>
			/// </summary>
			public MINIDUMP_THREAD_INFO_FLAG DumpFlags;

			/// <summary>An <c>HRESULT</c> value that indicates the dump status.</summary>
			public HRESULT DumpError;

			/// <summary>The thread termination status code.</summary>
			public uint ExitStatus;

			/// <summary>The time when the thread was created, in 100-nanosecond intervals since January 1, 1601 (UTC).</summary>
			public ulong CreateTime;

			/// <summary>The time when the thread exited, in 100-nanosecond intervals since January 1, 1601 (UTC).</summary>
			public ulong ExitTime;

			/// <summary>The time executed in kernel mode, in 100-nanosecond intervals.</summary>
			public ulong KernelTime;

			/// <summary>The time executed in user mode, in 100-nanosecond intervals.</summary>
			public ulong UserTime;

			/// <summary>The starting address of the thread.</summary>
			public ulong StartAddress;

			/// <summary>The processor affinity mask.</summary>
			public ulong Affinity;
		}

		/// <summary>Contains a list of threads.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_thread_info_list typedef struct
		// _MINIDUMP_THREAD_INFO_LIST { ULONG SizeOfHeader; ULONG SizeOfEntry; ULONG NumberOfEntries; } MINIDUMP_THREAD_INFO_LIST, *PMINIDUMP_THREAD_INFO_LIST;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_THREAD_INFO_LIST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_THREAD_INFO_LIST
		{
			/// <summary>
			/// The size of the header data for the stream, in bytes. This is generally
			/// <code>sizeof(MINIDUMP_THREAD_INFO_LIST)</code>
			/// .
			/// </summary>
			public uint SizeOfHeader;

			/// <summary>
			/// The size of each entry following the header, in bytes. This is generally
			/// <code>sizeof(MINIDUMP_THREAD_INFO)</code>
			/// .
			/// </summary>
			public uint SizeOfEntry;

			/// <summary>
			/// The number of entries in the stream. These are generally MINIDUMP_THREAD_INFO structures. The entries follow the header.
			/// </summary>
			public uint NumberOfEntries;
		}

		/// <summary>Contains a list of threads.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_thread_list typedef struct
		// _MINIDUMP_THREAD_LIST { ULONG32 NumberOfThreads; MINIDUMP_THREAD Threads[0]; } MINIDUMP_THREAD_LIST, *PMINIDUMP_THREAD_LIST;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_THREAD_LIST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_THREAD_LIST
		{
			/// <summary>The number of structures in the <c>Threads</c> array.</summary>
			public uint NumberOfThreads;

			/// <summary>An array of MINIDUMP_THREAD structures.</summary>
			public MINIDUMP_THREAD[] Threads;
		}

		/// <summary>
		/// Contains information about a module that has been unloaded. This information can help diagnose problems calling code that is no
		/// longer loaded.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_unloaded_module typedef struct
		// _MINIDUMP_UNLOADED_MODULE { ULONG64 BaseOfImage; ULONG32 SizeOfImage; ULONG32 CheckSum; ULONG32 TimeDateStamp; RVA ModuleNameRva;
		// } MINIDUMP_UNLOADED_MODULE, *PMINIDUMP_UNLOADED_MODULE;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_UNLOADED_MODULE")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_UNLOADED_MODULE
		{
			/// <summary>The base address of the module executable image in memory.</summary>
			public ulong BaseOfImage;

			/// <summary>The size of the module executable image in memory, in bytes.</summary>
			public uint SizeOfImage;

			/// <summary>The checksum value of the module executable image.</summary>
			public uint CheckSum;

			/// <summary>The timestamp value of the module executable image, in <c>time_t</c> format.</summary>
			public time_t TimeDateStamp;

			/// <summary>An RVA to a MINIDUMP_STRING structure that specifies the name of the module.</summary>
			public uint ModuleNameRva;
		}

		/// <summary>Contains a list of unloaded modules.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_unloaded_module_list typedef struct
		// _MINIDUMP_UNLOADED_MODULE_LIST { ULONG32 SizeOfHeader; ULONG32 SizeOfEntry; ULONG32 NumberOfEntries; }
		// MINIDUMP_UNLOADED_MODULE_LIST, *PMINIDUMP_UNLOADED_MODULE_LIST;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_UNLOADED_MODULE_LIST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_UNLOADED_MODULE_LIST
		{
			/// <summary>
			/// The size of the header data for the stream, in bytes. This is generally
			/// <code>sizeof(MINIDUMP_UNLOADED_MODULE_LIST)</code>
			/// .
			/// </summary>
			public uint SizeOfHeader;

			/// <summary>
			/// The size of each entry following the header, in bytes. This is generally
			/// <code>sizeof(MINIDUMP_UNLOADED_MODULE)</code>
			/// .
			/// </summary>
			public uint SizeOfEntry;

			/// <summary>
			/// The number of entries in the stream. These are generally MINIDUMP_UNLOADED_MODULE structures. The entries follow the header.
			/// </summary>
			public uint NumberOfEntries;
		}

		/// <summary>Contains user-defined information stored in a data stream.</summary>
		/// <remarks>In this context, a data stream refers to a block of data within a minidump file.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_user_stream typedef struct
		// _MINIDUMP_USER_STREAM { ULONG32 Type; ULONG BufferSize; PVOID Buffer; } MINIDUMP_USER_STREAM, *PMINIDUMP_USER_STREAM;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_USER_STREAM")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_USER_STREAM
		{
			/// <summary>The type of data stream. For more information, see MINIDUMP_STREAM_TYPE.</summary>
			public uint Type;

			/// <summary>The size of the user-defined data stream buffer, in bytes.</summary>
			public uint BufferSize;

			/// <summary>A pointer to a buffer that contains the user-defined data stream.</summary>
			public IntPtr Buffer;
		}

		/// <summary>Contains a list of user data streams used by the MiniDumpWriteDump function.</summary>
		/// <remarks>In this context, a data stream refers to a block of data within a minidump file.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_user_stream_information typedef
		// struct _MINIDUMP_USER_STREAM_INFORMATION { ULONG UserStreamCount; PMINIDUMP_USER_STREAM UserStreamArray; }
		// MINIDUMP_USER_STREAM_INFORMATION, *PMINIDUMP_USER_STREAM_INFORMATION;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_USER_STREAM_INFORMATION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_USER_STREAM_INFORMATION
		{
			/// <summary>The number of user streams.</summary>
			public uint UserStreamCount;

			/// <summary>An array of MINIDUMP_USER_STREAM structures.</summary>
			public MINIDUMP_USER_STREAM[] UserStreamArray;
		}

		[PInvokeData("minidumpapiset.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_VM_POST_READ_CALLBACK
		{
			public ulong Offset;
			public IntPtr Buffer;
			public uint Size;
			public uint Completed;
			public HRESULT Status;
		}

		[PInvokeData("minidumpapiset.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_VM_PRE_READ_CALLBACK
		{
			public ulong Offset;
			public IntPtr Buffer;
			public uint Size;
		}

		[PInvokeData("minidumpapiset.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_VM_QUERY_CALLBACK
		{
			public ulong Offset;
		}
	}
}