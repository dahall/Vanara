using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Adds a dynamic function table to the dynamic function table list.</summary>
		/// <param name="FunctionTable">
		/// A pointer to an array of function entries. For a definition of the <c>PRUNTIME_FUNCTION</c> type, see WinNT.h. For more information on runtime
		/// function entries, see the calling convention documentation for the processor.
		/// </param>
		/// <param name="EntryCount">The number of entries in the FunctionTable array.</param>
		/// <param name="BaseAddress">The base address to use when computing full virtual addresses from relative virtual addresses of function table entries.</param>
		/// <param name="TargetGp">
		/// <para>The target global pointer. This is part of the Intel IPF calling convention. It is a pointer to a data area in an image.</para>
		/// <para>This parameter does not exist on x64.</para>
		/// </param>
		/// <returns>If the function succeeds, the return value is <c>TRUE</c>. Otherwise, the return value is <c>FALSE</c>.</returns>
		// BOOLEAN WINAPI RtlAddFunctionTable( _In_ PRUNTIME_FUNCTION FunctionTable, _In_ DWORD EntryCount, _In_ DWORD64 BaseAddress, _In_ ULONGLONG TargetGp);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms680588(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680588")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool RtlAddFunctionTable(IntPtr FunctionTable, uint EntryCount, ulong BaseAddress, ulong TargetGp);

		/// <summary>Retrieves a context record in the context of the caller.</summary>
		/// <param name="ContextRecord">A pointer to a <c>CONTEXT</c> structure.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI RtlCaptureContext( _Out_ PCONTEXT ContextRecord); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680591(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680591")]
		public static extern void RtlCaptureContext(ref CONTEXT ContextRecord);

		/// <summary>Removes a dynamic function table from the dynamic function table list.</summary><param name="FunctionTable">A pointer to an array of function entries that were previously passed to <c>RtlAddFunctionTable</c> or an identifier previously passed to <c>RtlInstallFunctionTableCallback</c>. For a definition of the <c>PRUNTIME_FUNCTION</c> type, see WinNT.h.</param><returns>If the function succeeds, the return value is <c>TRUE</c>. Otherwise, the return value is <c>FALSE</c>.</returns>
		// BOOLEAN WINAPI RtlDeleteFunctionTable( _In_ PRUNTIME_FUNCTION FunctionTable);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms680593(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680593")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool RtlDeleteFunctionTable(IntPtr FunctionTable);

		/// <summary>Adds a dynamic function table to the dynamic function table list.</summary><param name="TableIdentifier">The identifier for the dynamic function table callback. The two low-order bits must be set. For example, BaseAddress|0x3.</param><param name="BaseAddress">The base address of the region of memory managed by the callback function.</param><param name="Length">The size of the region of memory managed by the callback function, in bytes.</param><param name="Callback">A pointer to the callback function that is called to retrieve the function table entries for the functions in the specified region of memory. For a definition of the <c>PGET_RUNTIME_FUNCTION_CALLBACK</c> type, see WinNT.h.</param><param name="Context">A pointer to the user-defined data to be passed to the callback function.</param><param name="OutOfProcessCallbackDll"><para>An optional pointer to a string that specifies the path of a DLL that provides function table entries that are outside the process.</para><para>When a debugger unwinds to a function in the range of addresses managed by the callback function, it loads this DLL and calls the <c>OUT_OF_PROCESS_FUNCTION_TABLE_CALLBACK_EXPORT_NAME</c> function, whose type is <c>POUT_OF_PROCESS_FUNCTION_TABLE_CALLBACK</c>. For more information, see the definitions of these items in WinNT.h.</para></param><returns>If the function succeeds, the return value is <c>TRUE</c>. If the function fails, the return value is <c>FALSE</c>.</returns>
		// BOOLEAN WINAPI RtlInstallFunctionTableCallback( _In_ DWORD64 TableIdentifier, _In_ DWORD64 BaseAddress, _In_ DWORD Length, _In_ PGET_RUNTIME_FUNCTION_CALLBACK Callback, _In_ PVOID Context, _In_ PCWSTR OutOfProcessCallbackDll);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms680595(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680595")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool RtlInstallFunctionTableCallback(ulong TableIdentifier, ulong BaseAddress, uint Length, PGET_RUNTIME_FUNCTION_CALLBACK Callback, IntPtr Context, [Optional] string OutOfProcessCallbackDll);

		/// <summary>Retrieves the function table entries for the functions in the specified region of memory.</summary>
		/// <param name="ControlPc">The control address.</param>
		/// <param name="Context">A pointer to the user-defined data to be passed from the function call.</param>
		/// <returns></returns>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("WinNT.h")]
		public delegate IntPtr PGET_RUNTIME_FUNCTION_CALLBACK(uint ControlPc, IntPtr Context);

		/// <summary>Searches the active function tables for an entry that corresponds to the specified PC value.</summary>
		/// <param name="ControlPc">The virtual address of an instruction bundle within the function.</param>
		/// <param name="ImageBase">The base address of module to which the function belongs.</param>
		/// <param name="TargetGp">
		/// <para>The global pointer value of the module.</para>
		/// <para>This parameter has a different declaration on x64 and ARM systems. For more information, see x64 Definition and ARM Definition.</para>
		/// </param>
		/// <returns>
		/// If there is no entry in the function table for the specified PC, the function returns <c>NULL</c>. Otherwise, the function returns the address of the
		/// function table entry that corresponds to the specified PC.
		/// </returns>
		// PVOID WINAPI RtlLookupFunctionEntry( _In_ ULONGLONG ControlPc, _Out_ PULONGLONG ImageBase, _Out_ PULONGLONG TargetGp);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms680597(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680597")]
		public static extern IntPtr RtlLookupFunctionEntry(ulong ControlPc, out ulong ImageBase, out ulong TargetGp);

		/// <summary>Moves a block of memory from one location to another.</summary>
		/// <param name="Destination">A pointer to the starting address of the move destination.</param>
		/// <param name="Source">A pointer to the starting address of the block of memory to be moved.</param>
		/// <param name="Length">The size of the block of memory to move, in bytes.</param>
		/// <returns>This function has no return value.</returns>
		// void MoveMemory( _In_ PVOID Destination, _In_ const VOID *Source, _In_ SIZE_T Length);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa366788(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, EntryPoint = "RtlMoveMemory")]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366788")]
		public static extern void MoveMemory(IntPtr Destination, IntPtr Source, SizeT Length);

		/// <summary>Retrieves the base address of the image that contains the specified PC value.</summary>
		/// <param name="PcValue">
		/// The PC value. The function searches all modules mapped into the address space of the calling process for a module that contains this value.
		/// </param>
		/// <param name="BaseOfImage">
		/// The base address of the image containing the PC value. This value must be added to any relative addresses in the headers to locate the image.
		/// </param>
		/// <returns>
		/// <para>If the PC value is found, the function returns the base address of the image that contains the PC value.</para>
		/// <para>If no image contains the PC value, the function returns <c>NULL</c>.</para>
		/// </returns>
		// PVOID WINAPI RtlPcToFileHeader( _In_ PVOID PcValue, _Out_ PVOID *BaseOfImage);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms680603(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680603")]
		public static extern IntPtr RtlPcToFileHeader(IntPtr PcValue, out IntPtr BaseOfImage);

		/// <summary>Restores the context of the caller to the specified context record.</summary>
		/// <param name="ContextRecord">A pointer to a <c>CONTEXT</c> structure.</param>
		/// <param name="ExceptionRecord">
		/// <para>A pointer to an <c>EXCEPTION_RECORD</c> structure. This parameter is optional and should typically be <c>NULL</c>.</para>
		/// <para>
		/// An exception record is used primarily with long jump and C++ catch-throw support. If the <c>ExceptionCode</c> member is STATUS_LONGJUMP, the
		/// <c>ExceptionInformation</c> member contains a pointer to a jump buffer. <c>RtlRestoreContext</c> will copy the non-volatile state from the jump
		/// buffer in to the context record before the context record is restored.
		/// </para>
		/// <para>
		/// If the <c>ExceptionCode</c> member is STATUS_UNWIND_CONSOLIDATE, the <c>ExceptionInformation</c> member contains a pointer to a callback function,
		/// such as a catch handler. <c>RtlRestoreContext</c> consolidates the call frames between its frame and the frame specified in the context record before
		/// calling the callback function. This hides frames from any exception handling that might occur in the callback function. The difference between this
		/// and a typical unwind is that the data on the stack is still present, so frame data such as a throw object is still available. The callback function
		/// returns a new program counter to update in the context record, which is then used in a normal restore context.
		/// </para>
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI RtlRestoreContext( _In_ PCONTEXT ContextRecord, _In_ PEXCEPTION_RECORD ExceptionRecord); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680605(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680605")]
		public static extern void RtlRestoreContext(ref CONTEXT ContextRecord, ref EXCEPTION_RECORD ExceptionRecord);

		/// <summary>Initiates an unwind of procedure call frames.</summary>
		/// <param name="TargetFrame">
		/// A pointer to the call frame that is the target of the unwind. If this parameter is <c>NULL</c>, the function performs an exit unwind.
		/// </param>
		/// <param name="TargetIp">The continuation address of the unwind. This parameter is ignored if TargetFrame is <c>NULL</c>.</param>
		/// <param name="ExceptionRecord">A pointer to an <c>EXCEPTION_RECORD</c> structure.</param>
		/// <param name="ReturnValue">A value to be placed in the integer function return register before continuing execution.</param>
		/// <returns>This function does not return a value.</returns>
		// void WINAPI RtlUnwind( _In_opt_ PVOID TargetFrame, _In_opt_ PVOID TargetIp, _In_opt_ PEXCEPTION_RECORD ExceptionRecord, _In_ PVOID ReturnValue); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680609(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680609")]
		public static extern void RtlUnwind(IntPtr TargetFrame, IntPtr TargetIp, ref EXCEPTION_RECORD ExceptionRecord, IntPtr ReturnValue);

		/// <summary>Initiates an unwind of procedure call frames.</summary>
		/// <param name="TargetFrame">
		/// A pointer to the call frame that is the target of the unwind. If this parameter is <c>NULL</c>, the function performs an exit unwind.
		/// </param>
		/// <param name="TargetIp">The continuation address of the unwind. This parameter is ignored if TargetFrame is <c>NULL</c>.</param>
		/// <param name="ExceptionRecord">A pointer to an <c>EXCEPTION_RECORD</c> structure.</param>
		/// <param name="ReturnValue">A value to be placed in the integer function return register before continuing execution.</param>
		/// <param name="OriginalContext">A pointer to a <c>CONTEXT</c> structure that stores context during the unwind operation.</param>
		/// <param name="HistoryTable">
		/// A pointer to the unwind history table. This structure is processor specific. For definitions of this structure, see Winternl.h.
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// void WINAPI RtlUnwindEx( _In_opt_ PVOID TargetFrame, _In_opt_ PVOID TargetIp, _In_opt_ PEXCEPTION_RECORD ExceptionRecord, _In_ PVOID ReturnValue, _In_
		// PCONTEXT OriginalContext, _In_opt_ PUNWIND_HISTORY_TABLE HistoryTable); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680615(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680615")]
		public static extern void RtlUnwindEx(IntPtr TargetFrame, IntPtr TargetIp, ref EXCEPTION_RECORD ExceptionRecord, IntPtr ReturnValue, ref CONTEXT OriginalContext, IntPtr HistoryTable);

		/*
		public static extern void RtlCaptureStackBackTrace();
		public static extern void RtlCompareMemory();
		public static extern void RtlCopyMemory();
		public static extern void RtlFillMemory();

		/// <summary>Retrieves the invocation context of the function that precedes the specified function context.</summary>
		/// <param name="HandlerType">
		/// <para>The handler type. This parameter can be one of the following values.</para>
		/// <para>This parameter is only present on x64.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>UNW_FLAG_NHANDLER0x0</term>
		/// <term>The function has no handler.</term>
		/// </item>
		/// <item>
		/// <term>UNW_FLAG_EHANDLER0x1</term>
		/// <term>The function has an exception handler that should be called.</term>
		/// </item>
		/// <item>
		/// <term>UNW_FLAG_UHANDLER0x2</term>
		/// <term>The function has a termination handler that should be called when unwinding an exception.</term>
		/// </item>
		/// <item>
		/// <term>UNW_FLAG_CHAININFO0x4</term>
		/// <term>The FunctionEntry member is the contents of a previous function table entry.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="ImageBase">The base address of the module to which the function belongs.</param>
		/// <param name="ControlPC">The virtual address where control left the specified function.</param>
		/// <param name="FunctionEntry">
		/// The address of the function table entry for the specified function. To obtain the function table entry, call the <c>RtlLookupFunctionEntry</c> function.
		/// </param>
		/// <param name="ContextRecord">A pointer to a <c>CONTEXT</c> structure that represents the context of the previous frame.</param>
		/// <param name="InFunction">
		/// <para>
		/// The location of the PC. If this parameter is 0, the PC is in the prologue, epilogue, or a null frame region of the function. If this parameter is 1,
		/// the PC is in the body of the function.
		/// </para>
		/// <para>This parameter is not present on x64.</para>
		/// </param>
		/// <param name="EstablisherFrame">
		/// <para>
		/// A pointer to a <c>FRAME_POINTERS</c> structure that receives the establisher frame pointer value. The real frame pointer is defined only if
		/// InFunction is 1.
		/// </para>
		/// <para>This parameter is of type <c>PULONG64</c> on x64.</para>
		/// </param>
		/// <param name="ContextPointers">An optional pointer to a context pointers structure.</param>
		/// <returns>This function returns a pointer to an EXCEPTION_ROUTINE callback function.</returns>
		// PEXCEPTION_ROUTINE WINAPI RtlVirtualUnwind( _In_ HandlerType, _In_ ImageBase, _In_ ControlPC, _In_ FunctionEntry, _Inout_ ContextRecord, _Out_ InFunction, _Out_ EstablisherFrame, _Inout_opt_ ContextPointers);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms680617(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, EntryPoint = "RtlVirtualUnwind")]
		[PInvokeData("WinNT.h", MSDNShortId = "ms680617")]
		public static extern EXCEPTION_ROUTINE RtlVirtualUnwindX64(UNW_FLAGS HandlerType, UIntPtr ImageBase, UIntPtr ControlPC, IntPtr FunctionEntry, ref CONTEXT ContextRecord, out IntPtr HandlerData, out ulong EstablisherFrame, IntPtr ContextPointers);

		/// <summary>The handler type.</summary>
		[Flags]
		public enum UNW_FLAGS : uint
		{
			/// <summary>The function has no handler.</summary>
			UNW_FLAG_NHANDLER = 0x0,
			/// <summary>The function has an exception handler that should be called.</summary>
			UNW_FLAG_EHANDLER = 0x1,
			/// <summary>The function has a termination handler that should be called when unwinding an exception.</summary>
			UNW_FLAG_UHANDLER = 0x2,
			/// <summary>The FunctionEntry member is the contents of a previous function table entry.</summary>
			UNW_FLAG_CHAININFO = 0x4,
			/// <summary>Undocumented.</summary>
			UNW_FLAG_NO_EPILOGUE = 0x80000000,
		}

		public delegate EXCEPTION_DISPOSITION EXCEPTION_ROUTINE(ref EXCEPTION_RECORD ExceptionRecord, IntPtr EstablisherFrame, ref CONTEXT ContextRecord, IntPtr DispatcherContext);
		*/

		/// <summary>The RtlZeroMemory routine fills a block of memory with zeros, given a pointer to the block and the length, in bytes, to be filled.</summary>
		/// <param name="Destination">A pointer to the memory block to be filled with zeros.</param>
		/// <param name="Length">The number of bytes to fill with zeros.</param>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-rtlzeromemory
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinNT.h")]
		public static extern void RtlZeroMemory(IntPtr Destination, SizeT Length);
	}
}