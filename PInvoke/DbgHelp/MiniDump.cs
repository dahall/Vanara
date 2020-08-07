using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class DbgHelp
	{
		/*
		/// <summary>
		/// <para>An application-defined callback function used with MiniDumpWriteDump. It receives extended minidump information.</para>
		/// <para>The <c>MINIDUMP_CALLBACK_ROUTINE</c> type defines a pointer to this callback function. <c>MiniDumpCallback</c> is a placeholder for the application-defined function name.</para>
		/// </summary>
		/// <param name="CallbackParam">An application-defined parameter value.</param>
		/// <param name="CallbackInput">A pointer to a MINIDUMP_CALLBACK_INPUT structure that specifies extended minidump information.</param>
		/// <param name="CallbackOutput">A pointer to a MINIDUMP_CALLBACK_OUTPUT structure that receives application-defined information from the callback function.</param>
		/// <returns>If the function succeeds, return <c>TRUE</c>; otherwise, return <c>FALSE</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/nc-minidumpapiset-minidump_callback_routine
		// MINIDUMP_CALLBACK_ROUTINE MinidumpCallbackRoutine; BOOL MinidumpCallbackRoutine( PVOID CallbackParam, PMINIDUMP_CALLBACK_INPUT CallbackInput, PMINIDUMP_CALLBACK_OUTPUT CallbackOutput ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NC:minidumpapiset.MINIDUMP_CALLBACK_ROUTINE")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool MINIDUMP_CALLBACK_ROUTINE([In, Out] IntPtr CallbackParam, in MINIDUMP_CALLBACK_INPUT CallbackInput, ref MINIDUMP_CALLBACK_OUTPUT CallbackOutput);

		/// <summary>Reads a stream from a user-mode minidump file.</summary>
		/// <param name="BaseOfDump">A pointer to the base of the mapped minidump file. The file should have been mapped into memory using the MapViewOfFile function.</param>
		/// <param name="StreamNumber">The type of data to be read from the minidump file. This member can be one of the values in the MINIDUMP_STREAM_TYPE enumeration.</param>
		/// <param name="Dir">A pointer to a MINIDUMP_DIRECTORY structure.</param>
		/// <param name="StreamPointer">A pointer to the beginning of the minidump stream. The format of this stream depends on the value of StreamNumber. For more information, see MINIDUMP_STREAM_TYPE.</param>
		/// <param name="StreamSize">The size of the stream pointed to by StreamPointer, in bytes.</param>
		/// <returns>If the function succeeds, the return value is <c>TRUE</c>; otherwise, the return value is <c>FALSE</c>.</returns>
		/// <remarks>In this context, a data stream is a block of data written to a minidump file.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/nf-minidumpapiset-minidumpreaddumpstream
		// BOOL MiniDumpReadDumpStream( PVOID BaseOfDump, ULONG StreamNumber, PMINIDUMP_DIRECTORY *Dir, PVOID *StreamPointer, ULONG *StreamSize );
		[DllImport(Lib.Dbghelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NF:minidumpapiset.MiniDumpReadDumpStream")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MiniDumpReadDumpStream([In] IntPtr BaseOfDump, uint StreamNumber, out IntPtr Dir, out IntPtr StreamPointer, out uint StreamSize);

		/// <summary>Writes user-mode minidump information to the specified file.</summary>
		/// <param name="hProcess">
		/// <para>A handle to the process for which the information is to be generated.</para>
		/// <para>This handle must have <c>PROCESS_QUERY_INFORMATION</c> and <c>PROCESS_VM_READ</c> access to the process. If handle information is to be collected then <c>PROCESS_DUP_HANDLE</c> access is also required. For more information, see Process Security and Access Rights. The caller must also be able to get <c>THREAD_ALL_ACCESS</c> access to the threads in the process. For more information, see Thread Security and Access Rights.</para>
		/// </param>
		/// <param name="ProcessId">The identifier of the process for which the information is to be generated.</param>
		/// <param name="hFile">A handle to the file in which the information is to be written.</param>
		/// <param name="DumpType">The type of information to be generated. This parameter can be one or more of the values from the MINIDUMP_TYPE enumeration.</param>
		/// <param name="ExceptionParam">A pointer to a MINIDUMP_EXCEPTION_INFORMATION structure describing the client exception that caused the minidump to be generated. If the value of this parameter is <c>NULL</c>, no exception information is included in the minidump file.</param>
		/// <param name="UserStreamParam">A pointer to a MINIDUMP_USER_STREAM_INFORMATION structure. If the value of this parameter is <c>NULL</c>, no user-defined information is included in the minidump file.</param>
		/// <param name="CallbackParam">A pointer to a MINIDUMP_CALLBACK_INFORMATION structure that specifies a callback routine which is to receive extended minidump information. If the value of this parameter is <c>NULL</c>, no callbacks are performed.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>; otherwise, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError. Note that the last error will be an <c>HRESULT</c> value.</para>
		/// <para>If the operation is canceled, the last error code is <code>HRESULT_FROM_WIN32(ERROR_CANCELLED)</code>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The MiniDumpCallback function receives extended minidump information from <c>MiniDumpWriteDump</c>. It also provides a way for the caller to determine the granularity of information written to the minidump file, as the callback function can filter the default information.</para>
		/// <para><c>MiniDumpWriteDump</c> should be called from a separate process if at all possible, rather than from within the target process being dumped. This is especially true when the target process is already not stable. For example, if it just crashed. A loader deadlock is one of many potential side effects of calling <c>MiniDumpWriteDump</c> from within the target process.</para>
		/// <para><c>MiniDumpWriteDump</c> may not produce a valid stack trace for the calling thread. To work around this problem, you must capture the state of the calling thread before calling <c>MiniDumpWriteDump</c> and use it as the ExceptionParam parameter. One way to do this is to force an exception inside a <c>__try</c>/<c>__except</c> block and use the EXCEPTION_POINTERS information provided by GetExceptionInformation. Alternatively, you can call the function from a new worker thread and filter this worker thread from the dump.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/nf-minidumpapiset-minidumpwritedump
		// BOOL MiniDumpWriteDump( HANDLE hProcess, DWORD ProcessId, HANDLE hFile, MINIDUMP_TYPE DumpType, PMINIDUMP_EXCEPTION_INFORMATION ExceptionParam, PMINIDUMP_USER_STREAM_INFORMATION UserStreamParam, PMINIDUMP_CALLBACK_INFORMATION CallbackParam );
		[DllImport(Lib.Dbghelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NF:minidumpapiset.MiniDumpWriteDump")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool MiniDumpWriteDump(HPROCESS hProcess, uint ProcessId, HFILE hFile, MINIDUMP_TYPE DumpType,
			[In, Optional] MINIDUMP_EXCEPTION_INFORMATION* ExceptionParam, [In, Optional] MINIDUMP_USER_STREAM_INFORMATION* UserStreamParam,
			[In, Optional] MINIDUMP_CALLBACK_INFORMATION* CallbackParam);
		

		/// <summary>Contains a pointer to an optional callback function that can be used by the MiniDumpWriteDump function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_callback_information
		// typedef struct _MINIDUMP_CALLBACK_INFORMATION { MINIDUMP_CALLBACK_ROUTINE CallbackRoutine; PVOID CallbackParam; } MINIDUMP_CALLBACK_INFORMATION, *PMINIDUMP_CALLBACK_INFORMATION;
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
		/// <remarks>If <c>CallbackType</c> is <c>CancelCallback</c> or <c>MemoryCallback</c>, the <c>ProcessId</c>, <c>ProcessHandle</c>, and <c>CallbackType</c> members are valid but no other input is specified.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_callback_input
		// typedef struct _MINIDUMP_CALLBACK_INPUT { ULONG ProcessId; HANDLE ProcessHandle; ULONG CallbackType; union { HRESULT Status; MINIDUMP_THREAD_CALLBACK Thread; MINIDUMP_THREAD_EX_CALLBACK ThreadEx; MINIDUMP_MODULE_CALLBACK Module; MINIDUMP_INCLUDE_THREAD_CALLBACK IncludeThread; MINIDUMP_INCLUDE_MODULE_CALLBACK IncludeModule; MINIDUMP_IO_CALLBACK Io; MINIDUMP_READ_MEMORY_FAILURE_CALLBACK ReadMemoryFailure; ULONG SecondaryFlags; MINIDUMP_VM_QUERY_CALLBACK VmQuery; MINIDUMP_VM_PRE_READ_CALLBACK VmPreRead; MINIDUMP_VM_POST_READ_CALLBACK VmPostRead; }; } MINIDUMP_CALLBACK_INPUT, *PMINIDUMP_CALLBACK_INPUT;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_CALLBACK_INPUT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_CALLBACK_INPUT
		{
			/// <summary>
			///   <para>The identifier of the process that contains callback function.</para>
			///   <para>This member is not used if <c>CallbackType</c> is <c>IoStartCallback</c>.</para>
			/// </summary>
			public uint ProcessId;
			/// <summary>
			///   <para>A handle to the process that contains the callback function.</para>
			///   <para>This member is not used if <c>CallbackType</c> is <c>IoStartCallback</c>.</para>
			/// </summary>
			public HPROCESS ProcessHandle;
			/// <summary>The type of callback function. This member can be one of the values in the MINIDUMP_CALLBACK_TYPE enumeration.</summary>
			public MINIDUMP_CALLBACK_TYPE CallbackType;
			/// <summary>If <c>CallbackType</c> is <c>KernelMinidumpStatusCallback</c>, the union is an <c>HRESULT</c> value that indicates the status of the kernel minidump write attempt.</summary>
			public HRESULT Status;
			/// <summary>If <c>CallbackType</c> is <c>ThreadCallback</c>, the union is a MINIDUMP_THREAD_CALLBACK structure.</summary>
			public MINIDUMP_THREAD_CALLBACK Thread;
			/// <summary>If <c>CallbackType</c> is <c>ThreadExCallback</c>, the union is a MINIDUMP_THREAD_EX_CALLBACK structure.</summary>
			public MINIDUMP_THREAD_EX_CALLBACK ThreadEx;
			/// <summary>If <c>CallbackType</c> is <c>ModuleCallback</c>, the union is a MINIDUMP_MODULE_CALLBACK structure.</summary>
			public MINIDUMP_MODULE_CALLBACK Module;
			/// <summary>
			///   <para>If <c>CallbackType</c> is <c>IncludeThreadCallback</c>, the union is a MINIDUMP_INCLUDE_THREAD_CALLBACK structure.</para>
			///   <para>
			///     <c>DbgHelp 6.2 and earlier: </c>This member is not available.</para>
			/// </summary>
			public MINIDUMP_INCLUDE_THREAD_CALLBACK IncludeThread;
			/// <summary>
			///   <para>If <c>CallbackType</c> is <c>IncludeModuleCallback</c>, the union is a MINIDUMP_INCLUDE_MODULE_CALLBACK structure.</para>
			///   <para>
			///     <c>DbgHelp 6.2 and earlier: </c>This member is not available.</para>
			/// </summary>
			public MINIDUMP_INCLUDE_MODULE_CALLBACK IncludeModule;
			/// <summary>
			///   <para>If <c>CallbackType</c> is <c>IoStartCallback</c>, <c>IoWriteAllCallback</c>, or <c>IoFinishCallback</c>, the union is a MINIDUMP_IO_CALLBACK structure.</para>
			///   <para>
			///     <c>DbgHelp 6.4 and earlier: </c>This member is not available.</para>
			/// </summary>
			public MINIDUMP_IO_CALLBACK Io;
			/// <summary>
			///   <para>If <c>CallbackType</c> is <c>ReadMemoryFailureCallback</c>, the union is a MINIDUMP_READ_MEMORY_FAILURE_CALLBACK structure.</para>
			///   <para>
			///     <c>DbgHelp 6.4 and earlier: </c>This member is not available.</para>
			/// </summary>
			public MINIDUMP_READ_MEMORY_FAILURE_CALLBACK ReadMemoryFailure;
			/// <summary>
			///   <para>Contains a value from the MINIDUMP_SECONDARY_FLAGS enumeration type.</para>
			///   <para>
			///     <c>DbgHelp 6.5 and earlier: </c>This member is not available.</para>
			/// </summary>
			public MINIDUMP_SECONDARY_FLAGS SecondaryFlags;
			/// <summary />
			public MINIDUMP_VM_QUERY_CALLBACK VmQuery;
			/// <summary />
			public MINIDUMP_VM_PRE_READ_CALLBACK VmPreRead;
			/// <summary />
			public MINIDUMP_VM_POST_READ_CALLBACK VmPostRead;
		}

		/// <summary>Contains information returned by the MiniDumpCallback function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_callback_output
		// typedef struct _MINIDUMP_CALLBACK_OUTPUT { union { ULONG ModuleWriteFlags; ULONG ThreadWriteFlags; ULONG SecondaryFlags; struct { ULONG64 MemoryBase; ULONG MemorySize; }; struct { BOOL CheckCancel; BOOL Cancel; }; HANDLE Handle; struct { MINIDUMP_MEMORY_INFO VmRegion; BOOL Continue; }; struct { HRESULT VmQueryStatus; MINIDUMP_MEMORY_INFO VmQueryResult; }; struct { HRESULT VmReadStatus; ULONG VmReadBytesCompleted; }; HRESULT Status; }; } MINIDUMP_CALLBACK_OUTPUT, *PMINIDUMP_CALLBACK_OUTPUT;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_CALLBACK_OUTPUT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_CALLBACK_OUTPUT
		{
			/// <summary>
			///   <para>The module write operation flags. This member can be one or more of the values in the MODULE_WRITE_FLAGS enumeration. The flags are set to their default values on entry to the callback.</para>
			///   <para>This member is ignored unless the callback type is <c>IncludeModuleCallback</c> or <c>ModuleCallback</c>.</para>
			/// </summary>
			public MODULE_WRITE_FLAGS ModuleWriteFlags;
			/// <summary>
			///   <para>The thread write operation flags. This member can be one or more of the values in the THREAD_WRITE_FLAGS enumeration. The flags are set to their default values on entry to the callback.</para>
			///   <para>This member is ignored unless the callback type is <c>IncludeThreadCallback</c>, <c>ThreadCallback</c>, or <c>ThreadExCallback</c>.</para>
			/// </summary>
			public THREAD_WRITE_FLAGS ThreadWriteFlags;
			/// <summary>
			///   <para>Contains a value from the MINIDUMP_SECONDARY_FLAGS enumeration type.</para>
			///   <para>
			///     <c>DbgHelp 6.5 and earlier: </c>This member is not available.</para>
			/// </summary>
			public MINIDUMP_SECONDARY_FLAGS SecondaryFlags;
			/// <summary>
			///   <para>The base address of the memory region to be included in the dump.</para>
			///   <para>This member is ignored unless the callback type is <c>MemoryCallback</c> or <c>RemoveMemoryCallback</c>.</para>
			/// </summary>
			public ulong MemoryBase;
			/// <summary>
			///   <para>The size of the memory region to be included in the dump, in bytes.</para>
			///   <para>This member is ignored unless the callback type is <c>MemoryCallback</c> or <c>RemoveMemoryCallback</c>.</para>
			/// </summary>
			public uint MemorySize;
			/// <summary>
			///   <para>Controls whether the callback function should receive cancel callbacks. If this member is <c>TRUE</c>, the cancel callbacks will continue. Otherwise, they will not.</para>
			///   <para>This member is ignored unless the callback type is <c>CancelCallback</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool CheckCancel;
			/// <summary>
			///   <para>Controls whether the dump should be canceled. If the callback function returns <c>TRUE</c> and <c>Cancel</c> is <c>TRUE</c>, the dump will be canceled. In this case, the MiniDumpWriteDump function fails and the dump is not valid.</para>
			///   <para>This member is ignored unless the callback type is <c>CancelCallback</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Cancel;
			/// <summary>
			///   <para>A handle to the file to which a kernel minidump will be written.</para>
			///   <para>This member is ignored unless the callback type is <c>WriteKernelMinidumpCallback</c>.</para>
			/// </summary>
			public HFILE Handle;
			/// <summary>
			///   <para>A MINIDUMP_MEMORY_INFO structure that describes the virtual memory region. The region base and size must be aligned on a page boundary. The region size can be set to 0 to filter out the region.</para>
			///   <para>This member is ignored unless the callback type is <c>IncludeVmRegionCallback</c>.</para>
			/// </summary>
			public MINIDUMP_MEMORY_INFO VmRegion;
			/// <summary>
			///   <para>Controls whether the dump should be continued. If the callback function returns <c>TRUE</c> and <c>Continue</c> is <c>TRUE</c>, the dump will be continued. Otherwise, the MiniDumpWriteDump function fails and the dump is not valid.</para>
			///   <para>This member is ignored unless the callback type is <c>IncludeVmRegionCallback</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Continue;
			/// <summary />
			public HRESULT VmQueryStatus;
			/// <summary />
			public MINIDUMP_MEMORY_INFO VmQueryResult;
			/// <summary />
			public HRESULT VmReadStatus;
			/// <summary />
			public uint VmReadBytesCompleted;
			/// <summary>
			///   <para>The status of the operation.</para>
			///   <para>This member is ignored unless the callback type is <c>ReadMemoryFailureCallback</c>, <c>IoStartCallback</c>, <c>IoWriteAllCallback</c>, or <c>IoFinishCallback</c>.</para>
			/// </summary>
			public HRESULT Status;
		}

		/// <summary>Contains the information needed to access a specific data stream in a minidump file.</summary>
		/// <remarks>In this context, a data stream is a block of data within a minidump file.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_directory
		// typedef struct _MINIDUMP_DIRECTORY { ULONG32 StreamType; MINIDUMP_LOCATION_DESCRIPTOR Location; } MINIDUMP_DIRECTORY, *PMINIDUMP_DIRECTORY;
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
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_exception
		// typedef struct _MINIDUMP_EXCEPTION { ULONG32 ExceptionCode; ULONG32 ExceptionFlags; ULONG64 ExceptionRecord; ULONG64 ExceptionAddress; ULONG32 NumberParameters; ULONG32 __unusedAlignment; ULONG64 ExceptionInformation[EXCEPTION_MAXIMUM_PARAMETERS]; } MINIDUMP_EXCEPTION, *PMINIDUMP_EXCEPTION;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_EXCEPTION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_EXCEPTION
		{
			/// <summary>
			///   <para>The reason the exception occurred. This is the code generated by a hardware exception, or the code specified in the RaiseException function for a software-generated exception. Following are the exception codes likely to occur due to common programming errors.</para>
			///   <list type="table">
			///     <listheader>
			///       <term>Value</term>
			///       <term>Meaning</term>
			///     </listheader>
			///     <item>
			///       <term>EXCEPTION_ACCESS_VIOLATION</term>
			///       <term>The thread tried to read from or write to a virtual address for which it does not have the appropriate access.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_ARRAY_BOUNDS_EXCEEDED</term>
			///       <term>The thread tried to access an array element that is out of bounds and the underlying hardware supports bounds checking.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_BREAKPOINT</term>
			///       <term>A breakpoint was encountered.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_DATATYPE_MISALIGNMENT</term>
			///       <term>The thread tried to read or write data that is misaligned on hardware that does not provide alignment. For example, 16-bit values must be aligned on 2-byte boundaries; 32-bit values on 4-byte boundaries, and so on.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_FLT_DENORMAL_OPERAND</term>
			///       <term>One of the operands in a floating-point operation is denormal. A denormal value is one that is too small to represent as a standard floating-point value.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_FLT_DIVIDE_BY_ZERO</term>
			///       <term>The thread tried to divide a floating-point value by a floating-point divisor of zero.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_FLT_INEXACT_RESULT</term>
			///       <term>The result of a floating-point operation cannot be represented exactly as a decimal fraction.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_FLT_INVALID_OPERATION</term>
			///       <term>This exception represents any floating-point exception not included in this list.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_FLT_OVERFLOW</term>
			///       <term>The exponent of a floating-point operation is greater than the magnitude allowed by the corresponding type.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_FLT_STACK_CHECK</term>
			///       <term>The stack overflowed or underflowed as the result of a floating-point operation.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_FLT_UNDERFLOW</term>
			///       <term>The exponent of a floating-point operation is less than the magnitude allowed by the corresponding type.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_ILLEGAL_INSTRUCTION</term>
			///       <term>The thread tried to execute an invalid instruction.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_IN_PAGE_ERROR</term>
			///       <term>The thread tried to access a page that was not present, and the system was unable to load the page. For example, this exception might occur if a network connection is lost while running a program over the network.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_INT_DIVIDE_BY_ZERO</term>
			///       <term>The thread tried to divide an integer value by an integer divisor of zero.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_INT_OVERFLOW</term>
			///       <term>The result of an integer operation caused a carry out of the most significant bit of the result.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_INVALID_DISPOSITION</term>
			///       <term>An exception handler returned an invalid disposition to the exception dispatcher. Programmers using a high-level language such as C should never encounter this exception.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_NONCONTINUABLE_EXCEPTION</term>
			///       <term>The thread tried to continue execution after a noncontinuable exception occurred.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_PRIV_INSTRUCTION</term>
			///       <term>The thread tried to execute an instruction whose operation is not allowed in the current machine mode.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_SINGLE_STEP</term>
			///       <term>A trace trap or other single-instruction mechanism signaled that one instruction has been executed.</term>
			///     </item>
			///     <item>
			///       <term>EXCEPTION_STACK_OVERFLOW</term>
			///       <term>The thread used up its stack.</term>
			///     </item>
			///   </list>
			///   <para>Another exception code is likely to occur when debugging console processes. It does not arise because of a programming error. The DBG_CONTROL_C exception code occurs when CTRL+C is input to a console process that handles CTRL+C signals and is being debugged. This exception code is not meant to be handled by applications. It is raised only for the benefit of the debugger, and is raised only when a debugger is attached to the console process.</para>
			/// </summary>
			public uint ExceptionCode;
			/// <summary>This member can be either zero, indicating a continuable exception, or EXCEPTION_NONCONTINUABLE, indicating a noncontinuable exception. Any attempt to continue execution after a noncontinuable exception causes the EXCEPTION_NONCONTINUABLE_EXCEPTION exception.</summary>
			public uint ExceptionFlags;
			/// <summary>A pointer to an associated <c>MINIDUMP_EXCEPTION</c> structure. Exception records can be chained together to provide additional information when nested exceptions occur.</summary>
			public ulong ExceptionRecord;
			/// <summary>The address where the exception occurred.</summary>
			public ulong ExceptionAddress;
			/// <summary>The number of parameters associated with the exception. This is the number of defined elements in the <c>ExceptionInformation</c> array.</summary>
			public uint NumberParameters;
			/// <summary>Reserved for cross-platform structure member alignment. Do not set.</summary>
			private uint unusedAlignment;
			/// <summary>
			///   <para>An array of additional arguments that describe the exception. The RaiseException function can specify this array of arguments. For most exception codes, the array elements are undefined. For the following exception code, the array elements are defined as follows.</para>
			///   <list type="table">
			///     <listheader>
			///       <term>Exception code</term>
			///       <term>Meaning</term>
			///     </listheader>
			///     <item>
			///       <term>EXCEPTION_ACCESS_VIOLATION</term>
			///       <term>The first element of the array contains a read/write flag that indicates the type of operation that caused the access violation. If this value is zero, the thread attempted to read the inaccessible data. If this value is 1, the thread attempted to write to an inaccessible address. The second array element specifies the virtual address of the inaccessible data.</term>
			///     </item>
			///   </list>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
			public ulong[] ExceptionInformation;
		}

		/// <summary>Contains the exception information written to the minidump file by the MiniDumpWriteDump function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_exception_information
		// typedef struct _MINIDUMP_EXCEPTION_INFORMATION { DWORD ThreadId; PEXCEPTION_POINTERS ExceptionPointers; BOOL ClientPointers; } MINIDUMP_EXCEPTION_INFORMATION, *PMINIDUMP_EXCEPTION_INFORMATION;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_EXCEPTION_INFORMATION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_EXCEPTION_INFORMATION
		{
			/// <summary>The identifier of the thread throwing the exception.</summary>
			public uint ThreadId;
			/// <summary>A pointer to an EXCEPTION_POINTERS structure specifying a computer-independent description of the exception and the processor context at the time of the exception.</summary>
			public IntPtr ExceptionPointers;
			/// <summary>Determines where to get the memory regions pointed to by the <c>ExceptionPointers</c> member. Set to <c>TRUE</c> if the memory resides in the process being debugged (the target process of the debugger). Otherwise, set to <c>FALSE</c> if the memory resides in the address space of the calling program (the debugger process). If you are accessing local memory (in the calling process) you should not set this member to <c>TRUE</c>.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool ClientPointers;
		}

		/// <summary>Represents an exception information stream.</summary>
		/// <remarks>In this context, a data stream is a set of data in a minidump file.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_exception_stream
		// typedef struct MINIDUMP_EXCEPTION_STREAM { ULONG32 ThreadId; ULONG32 __alignment; MINIDUMP_EXCEPTION ExceptionRecord; MINIDUMP_LOCATION_DESCRIPTOR ThreadContext; } MINIDUMP_EXCEPTION_STREAM, *PMINIDUMP_EXCEPTION_STREAM;
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
		/// <remarks>The first descriptor in the function table stream follows the header, MINIDUMP_FUNCTION_TABLE_STREAM. The generic descriptor is followed by a native system descriptor, then by <c>EntryCount</c> native system function entry structures.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_function_table_descriptor
		// typedef struct _MINIDUMP_FUNCTION_TABLE_DESCRIPTOR { ULONG64 MinimumAddress; ULONG64 MaximumAddress; ULONG64 BaseAddress; ULONG32 EntryCount; ULONG32 SizeOfAlignPad; } MINIDUMP_FUNCTION_TABLE_DESCRIPTOR, *PMINIDUMP_FUNCTION_TABLE_DESCRIPTOR;
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
			/// <summary>The size of alignment padding that follows the function entry data, in bytes. The function entry data in the stream is guaranteed to be aligned appropriately for access to the data members. If a minidump is directly mapped in memory, it is always possible to directly reference structure members in the stream.</summary>
			public uint SizeOfAlignPad;
		}

		/// <summary>Represents the header for the function table stream.</summary>
		/// <remarks>In this context, a data stream is a set of data in a minidump file. This header structure is followed by <c>NumberOfDescriptors</c> function tables. For each function table there is a MINIDUMP_FUNCTION_TABLE_DESCRIPTOR structure, then the raw system descriptor for the table, then the raw system function entry data. If necessary, alignment padding is placed between tables to properly align the initial structures.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_function_table_stream
		// typedef struct _MINIDUMP_FUNCTION_TABLE_STREAM { ULONG32 SizeOfHeader; ULONG32 SizeOfDescriptor; ULONG32 SizeOfNativeDescriptor; ULONG32 SizeOfFunctionEntry; ULONG32 NumberOfDescriptors; ULONG32 SizeOfAlignPad; } MINIDUMP_FUNCTION_TABLE_STREAM, *PMINIDUMP_FUNCTION_TABLE_STREAM;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NS:minidumpapiset._MINIDUMP_FUNCTION_TABLE_STREAM")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MINIDUMP_FUNCTION_TABLE_STREAM
		{
			/// <summary>The size of header information for the stream, in bytes. This value is <code>sizeof(MINIDUMP_FUNCTION_TABLE_STREAM)</code>.</summary>
			public uint SizeOfHeader;
			/// <summary>The size of a descriptor in the stream, in bytes. This value is <code>sizeof(MINIDUMP_FUNCTION_TABLE_DESCRIPTOR)</code>.</summary>
			public uint SizeOfDescriptor;
			/// <summary>The size of a raw system descriptor in the stream, in bytes. This value depends on the particular platform and system version on which the minidump was generated.</summary>
			public uint SizeOfNativeDescriptor;
			/// <summary>The size of a raw system function table entry, in bytes. This value depends on the particular platform and system version on which the minidump was generated.</summary>
			public uint SizeOfFunctionEntry;
			/// <summary>The number of descriptors in the stream.</summary>
			public uint NumberOfDescriptors;
			/// <summary>The size of alignment padding that follows the header, in bytes.</summary>
			public uint SizeOfAlignPad;
		}

		MINIDUMP_HANDLE_DATA_STREAM
MINIDUMP_HANDLE_DESCRIPTOR
MINIDUMP_HANDLE_DESCRIPTOR_2
MINIDUMP_HANDLE_OBJECT_INFORMATION
MINIDUMP_HANDLE_OPERATION_LIST
MINIDUMP_HEADER
MINIDUMP_INCLUDE_MODULE_CALLBACK
MINIDUMP_INCLUDE_THREAD_CALLBACK
MINIDUMP_IO_CALLBACK
MINIDUMP_LOCATION_DESCRIPTOR
MINIDUMP_MEMORY_DESCRIPTOR
MINIDUMP_MEMORY_INFO
MINIDUMP_MEMORY_INFO_LIST
MINIDUMP_MEMORY_LIST
MINIDUMP_MISC_INFO
MINIDUMP_MISC_INFO_2
MINIDUMP_MODULE
MINIDUMP_MODULE_CALLBACK
MINIDUMP_MODULE_LIST
MINIDUMP_READ_MEMORY_FAILURE_CALLBACK
MINIDUMP_STRING
MINIDUMP_SYSTEM_INFO
MINIDUMP_THREAD
MINIDUMP_THREAD_CALLBACK
MINIDUMP_THREAD_EX
MINIDUMP_THREAD_EX_CALLBACK
MINIDUMP_THREAD_EX_LIST
MINIDUMP_THREAD_INFO
MINIDUMP_THREAD_INFO_LIST
MINIDUMP_THREAD_LIST
MINIDUMP_UNLOADED_MODULE
MINIDUMP_UNLOADED_MODULE_LIST
MINIDUMP_USER_STREAM
MINIDUMP_USER_STREAM_INFORMATION
		*/
	}
}